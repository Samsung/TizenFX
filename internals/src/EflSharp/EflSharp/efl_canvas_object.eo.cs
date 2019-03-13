#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Canvas { 
///<summary>Event argument wrapper for event <see cref="Efl.Canvas.Object.AnimatorTickEvt"/>.</summary>
public class ObjectAnimatorTickEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public Efl.EventAnimatorTick arg { get; set; }
}
/// <summary>Efl canvas object abstract class</summary>
[ObjectNativeInherit]
public class Object : Efl.LoopConsumer, Efl.Eo.IWrapper,Efl.Canvas.Pointer,Efl.Gfx.Color,Efl.Gfx.Entity,Efl.Gfx.Hint,Efl.Gfx.Mapping,Efl.Gfx.Stack,Efl.Input.Interface,Efl.Ui.I18n
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Canvas.ObjectNativeInherit nativeInherit = new Efl.Canvas.ObjectNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (Object))
            return Efl.Canvas.ObjectNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
      }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] internal static extern System.IntPtr
      efl_canvas_object_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   public Object(Efl.Object parent= null
         ) :
      base(efl_canvas_object_class_get(), typeof(Object), parent)
   {
      FinishInstantiation();
   }
   ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
   public Object(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
   protected Object(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
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
private static object AnimatorTickEvtKey = new object();
   /// <summary>Animator tick synchronized with screen vsync if possible.</summary>
   public event EventHandler<Efl.Canvas.ObjectAnimatorTickEvt_Args> AnimatorTickEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_CANVAS_OBJECT_EVENT_ANIMATOR_TICK";
            if (add_cpp_event_handler(efl.Libs.Evas, key, this.evt_AnimatorTickEvt_delegate)) {
               eventHandlers.AddHandler(AnimatorTickEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_CANVAS_OBJECT_EVENT_ANIMATOR_TICK";
            if (remove_cpp_event_handler(key, this.evt_AnimatorTickEvt_delegate)) { 
               eventHandlers.RemoveHandler(AnimatorTickEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event AnimatorTickEvt.</summary>
   public void On_AnimatorTickEvt(Efl.Canvas.ObjectAnimatorTickEvt_Args e)
   {
      EventHandler<Efl.Canvas.ObjectAnimatorTickEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Canvas.ObjectAnimatorTickEvt_Args>)eventHandlers[AnimatorTickEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_AnimatorTickEvt_delegate;
   private void on_AnimatorTickEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Canvas.ObjectAnimatorTickEvt_Args args = new Efl.Canvas.ObjectAnimatorTickEvt_Args();
      args.arg =  evt.Info;;
      try {
         On_AnimatorTickEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object VisibilityChangedEvtKey = new object();
   /// <summary>Object&apos;s visibility state changed, the event value is the new state.</summary>
   public event EventHandler<Efl.Gfx.EntityVisibilityChangedEvt_Args> VisibilityChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_GFX_ENTITY_EVENT_VISIBILITY_CHANGED";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_VisibilityChangedEvt_delegate)) {
               eventHandlers.AddHandler(VisibilityChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_GFX_ENTITY_EVENT_VISIBILITY_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_VisibilityChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(VisibilityChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event VisibilityChangedEvt.</summary>
   public void On_VisibilityChangedEvt(Efl.Gfx.EntityVisibilityChangedEvt_Args e)
   {
      EventHandler<Efl.Gfx.EntityVisibilityChangedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Gfx.EntityVisibilityChangedEvt_Args>)eventHandlers[VisibilityChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_VisibilityChangedEvt_delegate;
   private void on_VisibilityChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Gfx.EntityVisibilityChangedEvt_Args args = new Efl.Gfx.EntityVisibilityChangedEvt_Args();
      args.arg = evt.Info != IntPtr.Zero;
      try {
         On_VisibilityChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object PositionChangedEvtKey = new object();
   /// <summary>Object was moved, its position during the event is the new one.</summary>
   public event EventHandler<Efl.Gfx.EntityPositionChangedEvt_Args> PositionChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_GFX_ENTITY_EVENT_POSITION_CHANGED";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_PositionChangedEvt_delegate)) {
               eventHandlers.AddHandler(PositionChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_GFX_ENTITY_EVENT_POSITION_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_PositionChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(PositionChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event PositionChangedEvt.</summary>
   public void On_PositionChangedEvt(Efl.Gfx.EntityPositionChangedEvt_Args e)
   {
      EventHandler<Efl.Gfx.EntityPositionChangedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Gfx.EntityPositionChangedEvt_Args>)eventHandlers[PositionChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_PositionChangedEvt_delegate;
   private void on_PositionChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Gfx.EntityPositionChangedEvt_Args args = new Efl.Gfx.EntityPositionChangedEvt_Args();
      args.arg =  evt.Info;;
      try {
         On_PositionChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object SizeChangedEvtKey = new object();
   /// <summary>Object was resized, its size during the event is the new one.</summary>
   public event EventHandler<Efl.Gfx.EntitySizeChangedEvt_Args> SizeChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_GFX_ENTITY_EVENT_SIZE_CHANGED";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_SizeChangedEvt_delegate)) {
               eventHandlers.AddHandler(SizeChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_GFX_ENTITY_EVENT_SIZE_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_SizeChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(SizeChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event SizeChangedEvt.</summary>
   public void On_SizeChangedEvt(Efl.Gfx.EntitySizeChangedEvt_Args e)
   {
      EventHandler<Efl.Gfx.EntitySizeChangedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Gfx.EntitySizeChangedEvt_Args>)eventHandlers[SizeChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_SizeChangedEvt_delegate;
   private void on_SizeChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Gfx.EntitySizeChangedEvt_Args args = new Efl.Gfx.EntitySizeChangedEvt_Args();
      args.arg =  evt.Info;;
      try {
         On_SizeChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object HintsChangedEvtKey = new object();
   /// <summary>Object hints changed.</summary>
   public event EventHandler HintsChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_GFX_ENTITY_EVENT_HINTS_CHANGED";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_HintsChangedEvt_delegate)) {
               eventHandlers.AddHandler(HintsChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_GFX_ENTITY_EVENT_HINTS_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_HintsChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(HintsChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event HintsChangedEvt.</summary>
   public void On_HintsChangedEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[HintsChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_HintsChangedEvt_delegate;
   private void on_HintsChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_HintsChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object StackingChangedEvtKey = new object();
   /// <summary>Object stacking was changed.</summary>
   public event EventHandler StackingChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_GFX_ENTITY_EVENT_STACKING_CHANGED";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_StackingChangedEvt_delegate)) {
               eventHandlers.AddHandler(StackingChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_GFX_ENTITY_EVENT_STACKING_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_StackingChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(StackingChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event StackingChangedEvt.</summary>
   public void On_StackingChangedEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[StackingChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_StackingChangedEvt_delegate;
   private void on_StackingChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_StackingChangedEvt(args);
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
            if (add_cpp_event_handler(efl.Libs.Evas, key, this.evt_PointerMoveEvt_delegate)) {
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
            if (add_cpp_event_handler(efl.Libs.Evas, key, this.evt_PointerDownEvt_delegate)) {
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
            if (add_cpp_event_handler(efl.Libs.Evas, key, this.evt_PointerUpEvt_delegate)) {
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
            if (add_cpp_event_handler(efl.Libs.Evas, key, this.evt_PointerCancelEvt_delegate)) {
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
            if (add_cpp_event_handler(efl.Libs.Evas, key, this.evt_PointerInEvt_delegate)) {
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
            if (add_cpp_event_handler(efl.Libs.Evas, key, this.evt_PointerOutEvt_delegate)) {
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
            if (add_cpp_event_handler(efl.Libs.Evas, key, this.evt_PointerWheelEvt_delegate)) {
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
            if (add_cpp_event_handler(efl.Libs.Evas, key, this.evt_PointerAxisEvt_delegate)) {
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
            if (add_cpp_event_handler(efl.Libs.Evas, key, this.evt_FingerMoveEvt_delegate)) {
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
            if (add_cpp_event_handler(efl.Libs.Evas, key, this.evt_FingerDownEvt_delegate)) {
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
            if (add_cpp_event_handler(efl.Libs.Evas, key, this.evt_FingerUpEvt_delegate)) {
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
            if (add_cpp_event_handler(efl.Libs.Evas, key, this.evt_KeyDownEvt_delegate)) {
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
            if (add_cpp_event_handler(efl.Libs.Evas, key, this.evt_KeyUpEvt_delegate)) {
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
            if (add_cpp_event_handler(efl.Libs.Evas, key, this.evt_HoldEvt_delegate)) {
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
            if (add_cpp_event_handler(efl.Libs.Evas, key, this.evt_FocusInEvt_delegate)) {
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
            if (add_cpp_event_handler(efl.Libs.Evas, key, this.evt_FocusOutEvt_delegate)) {
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
      evt_AnimatorTickEvt_delegate = new Efl.EventCb(on_AnimatorTickEvt_NativeCallback);
      evt_VisibilityChangedEvt_delegate = new Efl.EventCb(on_VisibilityChangedEvt_NativeCallback);
      evt_PositionChangedEvt_delegate = new Efl.EventCb(on_PositionChangedEvt_NativeCallback);
      evt_SizeChangedEvt_delegate = new Efl.EventCb(on_SizeChangedEvt_NativeCallback);
      evt_HintsChangedEvt_delegate = new Efl.EventCb(on_HintsChangedEvt_NativeCallback);
      evt_StackingChangedEvt_delegate = new Efl.EventCb(on_StackingChangedEvt_NativeCallback);
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
   /// <summary>Low-level pointer behaviour by device. See <see cref="Efl.Canvas.Object.GetPointerMode"/> and <see cref="Efl.Canvas.Object.SetPointerMode"/> for more explanation.
   /// 1.19</summary>
   /// <param name="dev">The pointer device to set/get the mode. Use <c>null</c> for the default pointer.</param>
   /// <returns>The pointer mode</returns>
   virtual public Efl.Input.ObjectPointerMode GetPointerModeByDevice( Efl.Input.Device dev) {
                         var _ret_var = Efl.Canvas.ObjectNativeInherit.efl_canvas_object_pointer_mode_by_device_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), dev);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Low-level pointer behaviour by device. See <see cref="Efl.Canvas.Object.GetPointerMode"/> and <see cref="Efl.Canvas.Object.SetPointerMode"/> for more explanation.
   /// 1.19</summary>
   /// <param name="dev">The pointer device to set/get the mode. Use <c>null</c> for the default pointer.</param>
   /// <param name="pointer_mode">The pointer mode</param>
   /// <returns><c>true</c> if pointer mode was set, <c>false</c> otherwise</returns>
   virtual public bool SetPointerModeByDevice( Efl.Input.Device dev,  Efl.Input.ObjectPointerMode pointer_mode) {
                                           var _ret_var = Efl.Canvas.ObjectNativeInherit.efl_canvas_object_pointer_mode_by_device_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), dev,  pointer_mode);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }
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
       var _ret_var = Efl.Canvas.ObjectNativeInherit.efl_canvas_object_pointer_mode_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
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
                         var _ret_var = Efl.Canvas.ObjectNativeInherit.efl_canvas_object_pointer_mode_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), pointer_mode);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Render mode to be used for compositing the Evas object.
   /// Only two modes are supported: - <see cref="Efl.Gfx.RenderOp.Blend"/> means the object will be merged on top of objects below it using simple alpha compositing. - <see cref="Efl.Gfx.RenderOp.Copy"/> means this object&apos;s pixels will replace everything that is below, making this object opaque.
   /// 
   /// Please do not assume that <see cref="Efl.Gfx.RenderOp.Copy"/> mode can be used to &quot;poke&quot; holes in a window (to see through it), as only the compositor can ensure that. Copy mode should only be used with otherwise opaque widgets or inside non-window surfaces (eg. a transparent background inside a buffer canvas).</summary>
   /// <returns>Blend or copy.</returns>
   virtual public Efl.Gfx.RenderOp GetRenderOp() {
       var _ret_var = Efl.Canvas.ObjectNativeInherit.efl_canvas_object_render_op_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Render mode to be used for compositing the Evas object.
   /// Only two modes are supported: - <see cref="Efl.Gfx.RenderOp.Blend"/> means the object will be merged on top of objects below it using simple alpha compositing. - <see cref="Efl.Gfx.RenderOp.Copy"/> means this object&apos;s pixels will replace everything that is below, making this object opaque.
   /// 
   /// Please do not assume that <see cref="Efl.Gfx.RenderOp.Copy"/> mode can be used to &quot;poke&quot; holes in a window (to see through it), as only the compositor can ensure that. Copy mode should only be used with otherwise opaque widgets or inside non-window surfaces (eg. a transparent background inside a buffer canvas).</summary>
   /// <param name="render_op">Blend or copy.</param>
   /// <returns></returns>
   virtual public  void SetRenderOp( Efl.Gfx.RenderOp render_op) {
                         Efl.Canvas.ObjectNativeInherit.efl_canvas_object_render_op_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), render_op);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Get the object clipping <c>obj</c> (if any).
   /// This function returns the object clipping <c>obj</c>. If <c>obj</c> is not being clipped at all, <c>null</c> is returned. The object <c>obj</c> must be a valid Evas_Object.</summary>
   /// <returns>The object to clip <c>obj</c> by.</returns>
   virtual public Efl.Canvas.Object GetClipper() {
       var _ret_var = Efl.Canvas.ObjectNativeInherit.efl_canvas_object_clipper_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
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
   /// <param name="clipper">The object to clip <c>obj</c> by.</param>
   /// <returns></returns>
   virtual public  void SetClipper( Efl.Canvas.Object clipper) {
                         Efl.Canvas.ObjectNativeInherit.efl_canvas_object_clipper_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), clipper);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Determine whether an object is set to repeat events.</summary>
   /// <returns>Whether <c>obj</c> is to repeat events (<c>true</c>) or not (<c>false</c>).</returns>
   virtual public bool GetRepeatEvents() {
       var _ret_var = Efl.Canvas.ObjectNativeInherit.efl_canvas_object_repeat_events_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Set whether an Evas object is to repeat events.
   /// If <c>repeat</c> is <c>true</c>, it will make events on <c>obj</c> to also be repeated for the next lower object in the objects&apos; stack (see see <see cref="Efl.Gfx.Stack.GetBelow"/>).
   /// 
   /// If <c>repeat</c> is <c>false</c>, events occurring on <c>obj</c> will be processed only on it.</summary>
   /// <param name="repeat">Whether <c>obj</c> is to repeat events (<c>true</c>) or not (<c>false</c>).</param>
   /// <returns></returns>
   virtual public  void SetRepeatEvents( bool repeat) {
                         Efl.Canvas.ObjectNativeInherit.efl_canvas_object_repeat_events_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), repeat);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Indicates that this object is the keyboard event receiver on its canvas.
   /// Changing focus only affects where (key) input events go. There can be only one object focused at any time. If <c>focus</c> is <c>true</c>, <c>obj</c> will be set as the currently focused object and it will receive all keyboard events that are not exclusive key grabs on other objects. See also <see cref="Efl.Canvas.Object.CheckSeatFocus"/>, <see cref="Efl.Canvas.Object.AddSeatFocus"/>, <see cref="Efl.Canvas.Object.DelSeatFocus"/>.</summary>
   /// <returns><c>true</c> when set as focused or <c>false</c> otherwise.</returns>
   virtual public bool GetKeyFocus() {
       var _ret_var = Efl.Canvas.ObjectNativeInherit.efl_canvas_object_key_focus_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Indicates that this object is the keyboard event receiver on its canvas.
   /// Changing focus only affects where (key) input events go. There can be only one object focused at any time. If <c>focus</c> is <c>true</c>, <c>obj</c> will be set as the currently focused object and it will receive all keyboard events that are not exclusive key grabs on other objects. See also <see cref="Efl.Canvas.Object.CheckSeatFocus"/>, <see cref="Efl.Canvas.Object.AddSeatFocus"/>, <see cref="Efl.Canvas.Object.DelSeatFocus"/>.</summary>
   /// <param name="focus"><c>true</c> when set as focused or <c>false</c> otherwise.</param>
   /// <returns></returns>
   virtual public  void SetKeyFocus( bool focus) {
                         Efl.Canvas.ObjectNativeInherit.efl_canvas_object_key_focus_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), focus);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Check if this object is focused.
   /// 1.19</summary>
   /// <returns><c>true</c> if focused by at least one seat or <c>false</c> otherwise.</returns>
   virtual public bool GetSeatFocus() {
       var _ret_var = Efl.Canvas.ObjectNativeInherit.efl_canvas_object_seat_focus_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Determine whether an object is set to use precise point collision detection.</summary>
   /// <returns>Whether to use precise point collision detection or not. The default value is false.</returns>
   virtual public bool GetPreciseIsInside() {
       var _ret_var = Efl.Canvas.ObjectNativeInherit.efl_canvas_object_precise_is_inside_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Set whether to use precise (usually expensive) point collision detection for a given Evas object.
   /// Use this function to make Evas treat objects&apos; transparent areas as not belonging to it with regard to mouse pointer events. By default, all of the object&apos;s boundary rectangle will be taken in account for them.
   /// 
   /// Warning: By using precise point collision detection you&apos;ll be making Evas more resource intensive.</summary>
   /// <param name="precise">Whether to use precise point collision detection or not. The default value is false.</param>
   /// <returns></returns>
   virtual public  void SetPreciseIsInside( bool precise) {
                         Efl.Canvas.ObjectNativeInherit.efl_canvas_object_precise_is_inside_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), precise);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Retrieve whether an Evas object is set to propagate events.
   /// See also <see cref="Efl.Canvas.Object.GetRepeatEvents"/>, <see cref="Efl.Canvas.Object.GetPassEvents"/>.</summary>
   /// <returns>Whether to propagate events (<c>true</c>) or not (<c>false</c>).</returns>
   virtual public bool GetPropagateEvents() {
       var _ret_var = Efl.Canvas.ObjectNativeInherit.efl_canvas_object_propagate_events_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Set whether events on a smart object&apos;s member should be propagated up to its parent.
   /// This function has no effect if <c>obj</c> is not a member of a smart object.
   /// 
   /// If <c>prop</c> is <c>true</c>, events occurring on this object will be propagated on to the smart object of which <c>obj</c> is a member. If <c>prop</c> is <c>false</c>, events occurring on this object will not be propagated on to the smart object of which <c>obj</c> is a member. The default value is <c>true</c>.
   /// 
   /// See also <see cref="Efl.Canvas.Object.SetRepeatEvents"/>, <see cref="Efl.Canvas.Object.SetPassEvents"/>.</summary>
   /// <param name="propagate">Whether to propagate events (<c>true</c>) or not (<c>false</c>).</param>
   /// <returns></returns>
   virtual public  void SetPropagateEvents( bool propagate) {
                         Efl.Canvas.ObjectNativeInherit.efl_canvas_object_propagate_events_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), propagate);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Determine whether an object is set to pass (ignore) events.
   /// See also <see cref="Efl.Canvas.Object.GetRepeatEvents"/>, <see cref="Efl.Canvas.Object.GetPropagateEvents"/>.</summary>
   /// <returns>Whether <c>obj</c> is to pass events (<c>true</c>) or not (<c>false</c>).</returns>
   virtual public bool GetPassEvents() {
       var _ret_var = Efl.Canvas.ObjectNativeInherit.efl_canvas_object_pass_events_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Set whether an Evas object is to pass (ignore) events.
   /// If <c>pass</c> is <c>true</c>, it will make events on <c>obj</c> to be ignored. They will be triggered on the next lower object (that is not set to pass events), instead (see <see cref="Efl.Gfx.Stack.GetBelow"/>).
   /// 
   /// If <c>pass</c> is <c>false</c> events will be processed on that object as normal.
   /// 
   /// See also <see cref="Efl.Canvas.Object.SetRepeatEvents"/>, <see cref="Efl.Canvas.Object.SetPropagateEvents"/></summary>
   /// <param name="pass">Whether <c>obj</c> is to pass events (<c>true</c>) or not (<c>false</c>).</param>
   /// <returns></returns>
   virtual public  void SetPassEvents( bool pass) {
                         Efl.Canvas.ObjectNativeInherit.efl_canvas_object_pass_events_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), pass);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Retrieves whether or not the given Evas object is to be drawn anti_aliased.</summary>
   /// <returns><c>true</c> if the object is to be anti_aliased, <c>false</c> otherwise.</returns>
   virtual public bool GetAntiAlias() {
       var _ret_var = Efl.Canvas.ObjectNativeInherit.efl_canvas_object_anti_alias_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Sets whether or not the given Evas object is to be drawn anti-aliased.</summary>
   /// <param name="anti_alias"><c>true</c> if the object is to be anti_aliased, <c>false</c> otherwise.</param>
   /// <returns></returns>
   virtual public  void SetAntiAlias( bool anti_alias) {
                         Efl.Canvas.ObjectNativeInherit.efl_canvas_object_anti_alias_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), anti_alias);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Return a list of objects currently clipped by <c>obj</c>.
   /// This returns the internal list handle containing all objects clipped by the object <c>obj</c>. If none are clipped by it, the call returns <c>null</c>. This list is only valid until the clip list is changed and should be fetched again with another call to this function if any objects being clipped by this object are unclipped, clipped by a new object, deleted or get the clipper deleted. These operations will invalidate the list returned, so it should not be used anymore after that point. Any use of the list after this may have undefined results, possibly leading to crashes.
   /// 
   /// See also <see cref="Efl.Canvas.Object.Clipper"/>.</summary>
   /// <returns>An iterator over the list of objects clipped by <c>obj</c>.</returns>
   virtual public Eina.Iterator<Efl.Canvas.Object> GetClippedObjects() {
       var _ret_var = Efl.Canvas.ObjectNativeInherit.efl_canvas_object_clipped_objects_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return new Eina.Iterator<Efl.Canvas.Object>(_ret_var, false, false);
 }
   /// <summary>Gets the parent smart object of a given Evas object, if it has one.
   /// This can be different from <see cref="Efl.Object.Parent"/> because this one is used internally for rendering and the normal parent is what the user expects to be the parent.
   /// 1.18</summary>
   /// <returns>The parent smart object of <c>obj</c> or <c>null</c>.</returns>
   virtual public Efl.Canvas.Object GetRenderParent() {
       var _ret_var = Efl.Canvas.ObjectNativeInherit.efl_canvas_object_render_parent_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>This handles text paragraph direction of the given object. Even if the given object is not textblock or text, its smart child objects can inherit the paragraph direction from the given object. The default paragraph direction is <c>inherit</c>.</summary>
   /// <returns>Paragraph direction for the given object.</returns>
   virtual public Efl.TextBidirectionalType GetParagraphDirection() {
       var _ret_var = Efl.Canvas.ObjectNativeInherit.efl_canvas_object_paragraph_direction_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>This handles text paragraph direction of the given object. Even if the given object is not textblock or text, its smart child objects can inherit the paragraph direction from the given object. The default paragraph direction is <c>inherit</c>.</summary>
   /// <param name="dir">Paragraph direction for the given object.</param>
   /// <returns></returns>
   virtual public  void SetParagraphDirection( Efl.TextBidirectionalType dir) {
                         Efl.Canvas.ObjectNativeInherit.efl_canvas_object_paragraph_direction_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), dir);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Returns the state of the &quot;no-render&quot; flag, which means, when true, that an object should never be rendered on the canvas.
   /// This flag can be used to avoid rendering visible clippers on the canvas, even if they currently don&apos;t clip any object.
   /// 1.15</summary>
   /// <returns>Enable &quot;no-render&quot; mode.</returns>
   virtual public bool GetNoRender() {
       var _ret_var = Efl.Canvas.ObjectNativeInherit.efl_canvas_object_no_render_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Disable all rendering on the canvas.
   /// This flag will be used to indicate to Evas that this object should never be rendered on the canvas under any circumstances. In particular, this is useful to avoid drawing clipper objects (or masks) even when they don&apos;t clip any object. This can also be used to replace the old source_visible flag with proxy objects.
   /// 
   /// This is different to the visible property, as even visible objects marked as &quot;no-render&quot; will never appear on screen. But those objects can still be used as proxy sources or clippers. When hidden, all &quot;no-render&quot; objects will completely disappear from the canvas, and hide their clippees or be invisible when used as proxy sources.
   /// 1.15</summary>
   /// <param name="enable">Enable &quot;no-render&quot; mode.</param>
   /// <returns></returns>
   virtual public  void SetNoRender( bool enable) {
                         Efl.Canvas.ObjectNativeInherit.efl_canvas_object_no_render_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), enable);
      Eina.Error.RaiseIfUnhandledException();
                   }
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
                  var _ret_var = Efl.Canvas.ObjectNativeInherit.efl_canvas_object_coords_inside_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), _in_pos);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Check if this object is focused by a given seat
   /// 1.19</summary>
   /// <param name="seat">The seat to check if the object is focused. Use <c>null</c> for the default seat.</param>
   /// <returns><c>true</c> if focused or <c>false</c> otherwise.</returns>
   virtual public bool CheckSeatFocus( Efl.Input.Device seat) {
                         var _ret_var = Efl.Canvas.ObjectNativeInherit.efl_canvas_object_seat_focus_check_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), seat);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Add a seat to the focus list.
   /// Evas allows the Efl.Canvas.Object to be focused by multiple seats at the same time. This function adds a new seat to the focus list. In other words, after the seat is added to the list this object will now be also focused by this new seat.
   /// 
   /// Note: The old focus APIs still work, however they will only act on the default seat.
   /// 1.19</summary>
   /// <param name="seat">The seat that should be added to the focus list. Use <c>null</c> for the default seat.</param>
   /// <returns><c>true</c> if the focus has been set or <c>false</c> otherwise.</returns>
   virtual public bool AddSeatFocus( Efl.Input.Device seat) {
                         var _ret_var = Efl.Canvas.ObjectNativeInherit.efl_canvas_object_seat_focus_add_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), seat);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Remove a seat from the focus list.
   /// 1.19</summary>
   /// <param name="seat">The seat that should be removed from the focus list. Use <c>null</c> for the default seat.</param>
   /// <returns><c>true</c> if the seat was removed from the focus list or <c>false</c> otherwise.</returns>
   virtual public bool DelSeatFocus( Efl.Input.Device seat) {
                         var _ret_var = Efl.Canvas.ObjectNativeInherit.efl_canvas_object_seat_focus_del_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), seat);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Returns the number of objects clipped by <c>obj</c></summary>
   /// <returns>The number of objects clipped by <c>obj</c></returns>
   virtual public  uint ClippedObjectsCount() {
       var _ret_var = Efl.Canvas.ObjectNativeInherit.efl_canvas_object_clipped_objects_count_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
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
                                                                               var _ret_var = Efl.Canvas.ObjectNativeInherit.efl_canvas_object_key_grab_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), keyname,  modifiers,  not_modifiers,  exclusive);
      Eina.Error.RaiseIfUnhandledException();
                                                      return _ret_var;
 }
   /// <summary>Removes the grab on <c>keyname</c> key events by <c>obj</c>.
   /// Removes a key grab on <c>obj</c> if <c>keyname</c>, <c>modifiers</c>, and <c>not_modifiers</c> match.
   /// 
   /// See also <see cref="Efl.Canvas.Object.GrabKey"/>, <see cref="Efl.Canvas.Object.GetKeyFocus"/>, <see cref="Efl.Canvas.Object.SetKeyFocus"/>, and the legacy API evas_focus_get.</summary>
   /// <param name="keyname">The key the grab is set for.</param>
   /// <param name="modifiers">A mask of modifiers that must be present to trigger the event.</param>
   /// <param name="not_modifiers">A mask of modifiers that must not not be present to trigger the event.</param>
   /// <returns></returns>
   virtual public  void UngrabKey(  System.String keyname,  Efl.Input.Modifier modifiers,  Efl.Input.Modifier not_modifiers) {
                                                             Efl.Canvas.ObjectNativeInherit.efl_canvas_object_key_ungrab_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), keyname,  modifiers,  not_modifiers);
      Eina.Error.RaiseIfUnhandledException();
                                           }
   /// <summary>Returns whether the mouse pointer is logically inside the canvas.
   /// When this function is called it will return a value of either <c>false</c> or <c>true</c>, depending on whether a pointer,in or pointer,out event has been called previously.
   /// 
   /// A return value of <c>true</c> indicates the mouse is logically inside the canvas, and <c>false</c> implies it is logically outside the canvas.
   /// 
   /// A canvas begins with the mouse being assumed outside (<c>false</c>).</summary>
   /// <param name="seat">The seat to consider, if <c>null</c> then the default seat will be used.</param>
   /// <returns><c>true</c> if the mouse pointer is inside the canvas, <c>false</c> otherwise</returns>
   virtual public bool GetPointerInside( Efl.Input.Device seat) {
                         var _ret_var = Efl.Canvas.PointerNativeInherit.efl_canvas_pointer_inside_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), seat);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
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
                                                                               Efl.Gfx.ColorNativeInherit.efl_gfx_color_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), out r,  out g,  out b,  out a);
      Eina.Error.RaiseIfUnhandledException();
                                                       }
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
                                                                               Efl.Gfx.ColorNativeInherit.efl_gfx_color_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), r,  g,  b,  a);
      Eina.Error.RaiseIfUnhandledException();
                                                       }
   /// <summary>Get hex color code of given Evas object. This returns a short lived hex color code string.</summary>
   /// <returns>the hex color code.</returns>
   virtual public  System.String GetColorCode() {
       var _ret_var = Efl.Gfx.ColorNativeInherit.efl_gfx_color_code_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Set the color of given Evas object to the given hex color code(#RRGGBBAA). e.g. efl_gfx_color_code_set(obj, &quot;#FFCCAACC&quot;);</summary>
   /// <param name="colorcode">the hex color code.</param>
   /// <returns></returns>
   virtual public  void SetColorCode(  System.String colorcode) {
                         Efl.Gfx.ColorNativeInherit.efl_gfx_color_code_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), colorcode);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Retrieves the position of the given canvas object.</summary>
   /// <returns>A 2D coordinate in pixel units.</returns>
   virtual public Eina.Position2D GetPosition() {
       var _ret_var = Efl.Gfx.EntityNativeInherit.efl_gfx_entity_position_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return Eina.Position2D_StructConversion.ToManaged(_ret_var);
 }
   /// <summary>Moves the given canvas object to the given location inside its canvas&apos; viewport. If unchanged this call may be entirely skipped, but if changed this will trigger move events, as well as potential pointer,in or pointer,out events.</summary>
   /// <param name="pos">A 2D coordinate in pixel units.</param>
   /// <returns></returns>
   virtual public  void SetPosition( Eina.Position2D pos) {
       var _in_pos = Eina.Position2D_StructConversion.ToInternal(pos);
                  Efl.Gfx.EntityNativeInherit.efl_gfx_entity_position_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), _in_pos);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Retrieves the (rectangular) size of the given Evas object.</summary>
   /// <returns>A 2D size in pixel units.</returns>
   virtual public Eina.Size2D GetSize() {
       var _ret_var = Efl.Gfx.EntityNativeInherit.efl_gfx_entity_size_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return Eina.Size2D_StructConversion.ToManaged(_ret_var);
 }
   /// <summary>Changes the size of the given object.
   /// Note that setting the actual size of an object might be the job of its container, so this function might have no effect. Look at <see cref="Efl.Gfx.Hint"/> instead, when manipulating widgets.</summary>
   /// <param name="size">A 2D size in pixel units.</param>
   /// <returns></returns>
   virtual public  void SetSize( Eina.Size2D size) {
       var _in_size = Eina.Size2D_StructConversion.ToInternal(size);
                  Efl.Gfx.EntityNativeInherit.efl_gfx_entity_size_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), _in_size);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Rectangular geometry that combines both position and size.</summary>
   /// <returns>The X,Y position and W,H size, in pixels.</returns>
   virtual public Eina.Rect GetGeometry() {
       var _ret_var = Efl.Gfx.EntityNativeInherit.efl_gfx_entity_geometry_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return Eina.Rect_StructConversion.ToManaged(_ret_var);
 }
   /// <summary>Rectangular geometry that combines both position and size.</summary>
   /// <param name="rect">The X,Y position and W,H size, in pixels.</param>
   /// <returns></returns>
   virtual public  void SetGeometry( Eina.Rect rect) {
       var _in_rect = Eina.Rect_StructConversion.ToInternal(rect);
                  Efl.Gfx.EntityNativeInherit.efl_gfx_entity_geometry_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), _in_rect);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Retrieves whether or not the given canvas object is visible.</summary>
   /// <returns><c>true</c> if to make the object visible, <c>false</c> otherwise</returns>
   virtual public bool GetVisible() {
       var _ret_var = Efl.Gfx.EntityNativeInherit.efl_gfx_entity_visible_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Shows or hides this object.</summary>
   /// <param name="v"><c>true</c> if to make the object visible, <c>false</c> otherwise</param>
   /// <returns></returns>
   virtual public  void SetVisible( bool v) {
                         Efl.Gfx.EntityNativeInherit.efl_gfx_entity_visible_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), v);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Gets an object&apos;s scaling factor.</summary>
   /// <returns>The scaling factor (the default value is 0.0, meaning individual scaling is not set)</returns>
   virtual public double GetScale() {
       var _ret_var = Efl.Gfx.EntityNativeInherit.efl_gfx_entity_scale_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Sets the scaling factor of an object.</summary>
   /// <param name="scale">The scaling factor (the default value is 0.0, meaning individual scaling is not set)</param>
   /// <returns></returns>
   virtual public  void SetScale( double scale) {
                         Efl.Gfx.EntityNativeInherit.efl_gfx_entity_scale_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), scale);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Defines the aspect ratio to respect when scaling this object.
   /// The aspect ratio is defined as the width / height ratio of the object. Depending on the object and its container, this hint may or may not be fully respected.
   /// 
   /// If any of the given aspect ratio terms are 0, the object&apos;s container will ignore the aspect and scale this object to occupy the whole available area, for any given policy.</summary>
   /// <param name="mode">Mode of interpretation.</param>
   /// <param name="sz">Base size to use for aspecting.</param>
   /// <returns></returns>
   virtual public  void GetHintAspect( out Efl.Gfx.HintAspect mode,  out Eina.Size2D sz) {
                         var _out_sz = new Eina.Size2D_StructInternal();
                  Efl.Gfx.HintNativeInherit.efl_gfx_hint_aspect_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), out mode,  out _out_sz);
      Eina.Error.RaiseIfUnhandledException();
            sz = Eina.Size2D_StructConversion.ToManaged(_out_sz);
                   }
   /// <summary>Defines the aspect ratio to respect when scaling this object.
   /// The aspect ratio is defined as the width / height ratio of the object. Depending on the object and its container, this hint may or may not be fully respected.
   /// 
   /// If any of the given aspect ratio terms are 0, the object&apos;s container will ignore the aspect and scale this object to occupy the whole available area, for any given policy.</summary>
   /// <param name="mode">Mode of interpretation.</param>
   /// <param name="sz">Base size to use for aspecting.</param>
   /// <returns></returns>
   virtual public  void SetHintAspect( Efl.Gfx.HintAspect mode,  Eina.Size2D sz) {
             var _in_sz = Eina.Size2D_StructConversion.ToInternal(sz);
                              Efl.Gfx.HintNativeInherit.efl_gfx_hint_aspect_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), mode,  _in_sz);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Hints on the object&apos;s maximum size.
   /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
   /// 
   /// The object container is in charge of fetching this property and placing the object accordingly.
   /// 
   /// Values -1 will be treated as unset hint components, when queried by managers.
   /// 
   /// Note: Smart objects (such as elementary) can have their own hint policy. So calling this API may or may not affect the size of smart objects.</summary>
   /// <returns>Maximum size (hint) in pixels, (-1, -1) by default for canvas objects).</returns>
   virtual public Eina.Size2D GetHintSizeMax() {
       var _ret_var = Efl.Gfx.HintNativeInherit.efl_gfx_hint_size_max_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return Eina.Size2D_StructConversion.ToManaged(_ret_var);
 }
   /// <summary>Hints on the object&apos;s maximum size.
   /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
   /// 
   /// The object container is in charge of fetching this property and placing the object accordingly.
   /// 
   /// Values -1 will be treated as unset hint components, when queried by managers.
   /// 
   /// Note: Smart objects (such as elementary) can have their own hint policy. So calling this API may or may not affect the size of smart objects.</summary>
   /// <param name="sz">Maximum size (hint) in pixels, (-1, -1) by default for canvas objects).</param>
   /// <returns></returns>
   virtual public  void SetHintSizeMax( Eina.Size2D sz) {
       var _in_sz = Eina.Size2D_StructConversion.ToInternal(sz);
                  Efl.Gfx.HintNativeInherit.efl_gfx_hint_size_max_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), _in_sz);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Hints on the object&apos;s minimum size.
   /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate. The object container is in charge of fetching this property and placing the object accordingly.
   /// 
   /// Value 0 will be treated as unset hint components, when queried by managers.
   /// 
   /// Note: This property is meant to be set by applications and not by EFL itself. Use this to request a specific size (treated as minimum size).</summary>
   /// <returns>Minimum size (hint) in pixels.</returns>
   virtual public Eina.Size2D GetHintSizeMin() {
       var _ret_var = Efl.Gfx.HintNativeInherit.efl_gfx_hint_size_min_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return Eina.Size2D_StructConversion.ToManaged(_ret_var);
 }
   /// <summary>Hints on the object&apos;s minimum size.
   /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate. The object container is in charge of fetching this property and placing the object accordingly.
   /// 
   /// Value 0 will be treated as unset hint components, when queried by managers.
   /// 
   /// Note: This property is meant to be set by applications and not by EFL itself. Use this to request a specific size (treated as minimum size).</summary>
   /// <param name="sz">Minimum size (hint) in pixels.</param>
   /// <returns></returns>
   virtual public  void SetHintSizeMin( Eina.Size2D sz) {
       var _in_sz = Eina.Size2D_StructConversion.ToInternal(sz);
                  Efl.Gfx.HintNativeInherit.efl_gfx_hint_size_min_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), _in_sz);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Get the &quot;intrinsic&quot; minimum size of this object.</summary>
   /// <returns>Minimum size (hint) in pixels.</returns>
   virtual public Eina.Size2D GetHintSizeRestrictedMin() {
       var _ret_var = Efl.Gfx.HintNativeInherit.efl_gfx_hint_size_restricted_min_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return Eina.Size2D_StructConversion.ToManaged(_ret_var);
 }
   /// <summary>This function is protected as it is meant for widgets to indicate their &quot;intrinsic&quot; minimum size.</summary>
   /// <param name="sz">Minimum size (hint) in pixels.</param>
   /// <returns></returns>
   virtual public  void SetHintSizeRestrictedMin( Eina.Size2D sz) {
       var _in_sz = Eina.Size2D_StructConversion.ToInternal(sz);
                  Efl.Gfx.HintNativeInherit.efl_gfx_hint_size_restricted_min_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), _in_sz);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Read-only minimum size combining both <see cref="Efl.Gfx.Hint.HintSizeRestrictedMin"/> and <see cref="Efl.Gfx.Hint.HintSizeMin"/> hints.
   /// <see cref="Efl.Gfx.Hint.HintSizeRestrictedMin"/> is intended for mostly internal usage and widget developers, and <see cref="Efl.Gfx.Hint.HintSizeMin"/> is intended to be set from application side. <see cref="Efl.Gfx.Hint.GetHintSizeCombinedMin"/> combines both values by taking their repective maximum (in both width and height), and is used internally to get an object&apos;s minimum size.</summary>
   /// <returns>Minimum size (hint) in pixels.</returns>
   virtual public Eina.Size2D GetHintSizeCombinedMin() {
       var _ret_var = Efl.Gfx.HintNativeInherit.efl_gfx_hint_size_combined_min_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return Eina.Size2D_StructConversion.ToManaged(_ret_var);
 }
   /// <summary>Hints for an object&apos;s margin or padding space.
   /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
   /// 
   /// The object container is in charge of fetching this property and placing the object accordingly.
   /// 
   /// Note: Smart objects (such as elementary) can have their own hint policy. So calling this API may or may not affect the size of smart objects.</summary>
   /// <param name="l">Integer to specify left padding.</param>
   /// <param name="r">Integer to specify right padding.</param>
   /// <param name="t">Integer to specify top padding.</param>
   /// <param name="b">Integer to specify bottom padding.</param>
   /// <returns></returns>
   virtual public  void GetHintMargin( out  int l,  out  int r,  out  int t,  out  int b) {
                                                                               Efl.Gfx.HintNativeInherit.efl_gfx_hint_margin_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), out l,  out r,  out t,  out b);
      Eina.Error.RaiseIfUnhandledException();
                                                       }
   /// <summary>Hints for an object&apos;s margin or padding space.
   /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
   /// 
   /// The object container is in charge of fetching this property and placing the object accordingly.
   /// 
   /// Note: Smart objects (such as elementary) can have their own hint policy. So calling this API may or may not affect the size of smart objects.</summary>
   /// <param name="l">Integer to specify left padding.</param>
   /// <param name="r">Integer to specify right padding.</param>
   /// <param name="t">Integer to specify top padding.</param>
   /// <param name="b">Integer to specify bottom padding.</param>
   /// <returns></returns>
   virtual public  void SetHintMargin(  int l,   int r,   int t,   int b) {
                                                                               Efl.Gfx.HintNativeInherit.efl_gfx_hint_margin_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), l,  r,  t,  b);
      Eina.Error.RaiseIfUnhandledException();
                                                       }
   /// <summary>Hints for an object&apos;s weight.
   /// This is a hint on how a container object should resize a given child within its area. Containers may adhere to the simpler logic of just expanding the child object&apos;s dimensions to fit its own (see the <see cref="Efl.Gfx.Constants.HintExpand"/> helper weight macro) or the complete one of taking each child&apos;s weight hint as real weights to how much of its size to allocate for them in each axis. A container is supposed to, after normalizing the weights of its children (with weight  hints), distribut the space it has to layout them by those factors -- most weighted children get larger in this process than the least ones.
   /// 
   /// Accepted values are zero or positive values. Some containers might use this hint as a boolean, but some others might consider it as a proportion, see documentation of each container.
   /// 
   /// Note: Default weight hint values are 0.0, for both axis.</summary>
   /// <param name="x">Non-negative double value to use as horizontal weight hint.</param>
   /// <param name="y">Non-negative double value to use as vertical weight hint.</param>
   /// <returns></returns>
   virtual public  void GetHintWeight( out double x,  out double y) {
                                           Efl.Gfx.HintNativeInherit.efl_gfx_hint_weight_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), out x,  out y);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Hints for an object&apos;s weight.
   /// This is a hint on how a container object should resize a given child within its area. Containers may adhere to the simpler logic of just expanding the child object&apos;s dimensions to fit its own (see the <see cref="Efl.Gfx.Constants.HintExpand"/> helper weight macro) or the complete one of taking each child&apos;s weight hint as real weights to how much of its size to allocate for them in each axis. A container is supposed to, after normalizing the weights of its children (with weight  hints), distribut the space it has to layout them by those factors -- most weighted children get larger in this process than the least ones.
   /// 
   /// Accepted values are zero or positive values. Some containers might use this hint as a boolean, but some others might consider it as a proportion, see documentation of each container.
   /// 
   /// Note: Default weight hint values are 0.0, for both axis.</summary>
   /// <param name="x">Non-negative double value to use as horizontal weight hint.</param>
   /// <param name="y">Non-negative double value to use as vertical weight hint.</param>
   /// <returns></returns>
   virtual public  void SetHintWeight( double x,  double y) {
                                           Efl.Gfx.HintNativeInherit.efl_gfx_hint_weight_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), x,  y);
      Eina.Error.RaiseIfUnhandledException();
                               }
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
                                           Efl.Gfx.HintNativeInherit.efl_gfx_hint_align_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), out x,  out y);
      Eina.Error.RaiseIfUnhandledException();
                               }
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
                                           Efl.Gfx.HintNativeInherit.efl_gfx_hint_align_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), x,  y);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Hints for an object&apos;s fill property that used to specify &quot;justify&quot; or &quot;fill&quot; by some users. <see cref="Efl.Gfx.Hint.GetHintFill"/> specify whether to fill the space inside the boundaries of a container/manager.
   /// Maximum hints should be enforced with higher priority, if they are set. Also, any <see cref="Efl.Gfx.Hint.GetHintMargin"/> set on objects should add up to the object space on the final scene composition.
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
                                           Efl.Gfx.HintNativeInherit.efl_gfx_hint_fill_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), out x,  out y);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Hints for an object&apos;s fill property that used to specify &quot;justify&quot; or &quot;fill&quot; by some users. <see cref="Efl.Gfx.Hint.GetHintFill"/> specify whether to fill the space inside the boundaries of a container/manager.
   /// Maximum hints should be enforced with higher priority, if they are set. Also, any <see cref="Efl.Gfx.Hint.GetHintMargin"/> set on objects should add up to the object space on the final scene composition.
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
                                           Efl.Gfx.HintNativeInherit.efl_gfx_hint_fill_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), x,  y);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Number of points of a map.
   /// This sets the number of points of map. Currently, the number of points must be multiples of 4.
   /// 1.20</summary>
   /// <returns>The number of points of map
   /// 1.20</returns>
   virtual public  int GetMappingPointCount() {
       var _ret_var = Efl.Gfx.MappingNativeInherit.efl_gfx_mapping_point_count_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Number of points of a map.
   /// This sets the number of points of map. Currently, the number of points must be multiples of 4.
   /// 1.20</summary>
   /// <param name="count">The number of points of map
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetMappingPointCount(  int count) {
                         Efl.Gfx.MappingNativeInherit.efl_gfx_mapping_point_count_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), count);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Clockwise state of a map (read-only).
   /// This determines if the output points (X and Y. Z is not used) are clockwise or counter-clockwise. This can be used for &quot;back-face culling&quot;. This is where you hide objects that &quot;face away&quot; from you. In this case objects that are not clockwise.
   /// 1.20</summary>
   /// <returns><c>true</c> if clockwise, <c>false</c> if counter clockwise
   /// 1.20</returns>
   virtual public bool GetMappingClockwise() {
       var _ret_var = Efl.Gfx.MappingNativeInherit.efl_gfx_mapping_clockwise_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Smoothing state for map rendering.
   /// This sets smoothing for map rendering. If the object is a type that has its own smoothing settings, then both the smooth settings for this object and the map must be turned off. By default smooth maps are enabled.
   /// 1.20</summary>
   /// <returns><c>true</c> by default.
   /// 1.20</returns>
   virtual public bool GetMappingSmooth() {
       var _ret_var = Efl.Gfx.MappingNativeInherit.efl_gfx_mapping_smooth_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Smoothing state for map rendering.
   /// This sets smoothing for map rendering. If the object is a type that has its own smoothing settings, then both the smooth settings for this object and the map must be turned off. By default smooth maps are enabled.
   /// 1.20</summary>
   /// <param name="smooth"><c>true</c> by default.
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetMappingSmooth( bool smooth) {
                         Efl.Gfx.MappingNativeInherit.efl_gfx_mapping_smooth_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), smooth);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Alpha flag for map rendering.
   /// This sets alpha flag for map rendering. If the object is a type that has its own alpha settings, then this will take precedence. Only image objects support this currently (<see cref="Efl.Canvas.Image"/> and its friends). Setting this to off stops alpha blending of the map area, and is useful if you know the object and/or all sub-objects is 100% solid.
   /// 
   /// Note that this may conflict with <see cref="Efl.Gfx.Mapping.MappingSmooth"/> depending on which algorithm is used for anti-aliasing.
   /// 1.20</summary>
   /// <returns><c>true</c> by default.
   /// 1.20</returns>
   virtual public bool GetMappingAlpha() {
       var _ret_var = Efl.Gfx.MappingNativeInherit.efl_gfx_mapping_alpha_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Alpha flag for map rendering.
   /// This sets alpha flag for map rendering. If the object is a type that has its own alpha settings, then this will take precedence. Only image objects support this currently (<see cref="Efl.Canvas.Image"/> and its friends). Setting this to off stops alpha blending of the map area, and is useful if you know the object and/or all sub-objects is 100% solid.
   /// 
   /// Note that this may conflict with <see cref="Efl.Gfx.Mapping.MappingSmooth"/> depending on which algorithm is used for anti-aliasing.
   /// 1.20</summary>
   /// <param name="alpha"><c>true</c> by default.
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetMappingAlpha( bool alpha) {
                         Efl.Gfx.MappingNativeInherit.efl_gfx_mapping_alpha_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), alpha);
      Eina.Error.RaiseIfUnhandledException();
                   }
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
   virtual public  void GetMappingCoordAbsolute(  int idx,  out double x,  out double y,  out double z) {
                                                                               Efl.Gfx.MappingNativeInherit.efl_gfx_mapping_coord_absolute_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), idx,  out x,  out y,  out z);
      Eina.Error.RaiseIfUnhandledException();
                                                       }
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
   virtual public  void SetMappingCoordAbsolute(  int idx,  double x,  double y,  double z) {
                                                                               Efl.Gfx.MappingNativeInherit.efl_gfx_mapping_coord_absolute_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), idx,  x,  y,  z);
      Eina.Error.RaiseIfUnhandledException();
                                                       }
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
   virtual public  void GetMappingUv(  int idx,  out double u,  out double v) {
                                                             Efl.Gfx.MappingNativeInherit.efl_gfx_mapping_uv_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), idx,  out u,  out v);
      Eina.Error.RaiseIfUnhandledException();
                                           }
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
   virtual public  void SetMappingUv(  int idx,  double u,  double v) {
                                                             Efl.Gfx.MappingNativeInherit.efl_gfx_mapping_uv_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), idx,  u,  v);
      Eina.Error.RaiseIfUnhandledException();
                                           }
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
   virtual public  void GetMappingColor(  int idx,  out  int r,  out  int g,  out  int b,  out  int a) {
                                                                                                 Efl.Gfx.MappingNativeInherit.efl_gfx_mapping_color_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), idx,  out r,  out g,  out b,  out a);
      Eina.Error.RaiseIfUnhandledException();
                                                                   }
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
   virtual public  void SetMappingColor(  int idx,   int r,   int g,   int b,   int a) {
                                                                                                 Efl.Gfx.MappingNativeInherit.efl_gfx_mapping_color_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), idx,  r,  g,  b,  a);
      Eina.Error.RaiseIfUnhandledException();
                                                                   }
   /// <summary>Read-only property indicating whether an object is mapped.
   /// This will be <c>true</c> if any transformation is applied to this object.
   /// 1.20</summary>
   /// <returns><c>true</c> if the object is mapped.
   /// 1.20</returns>
   virtual public bool HasMapping() {
       var _ret_var = Efl.Gfx.MappingNativeInherit.efl_gfx_mapping_has_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Resets the map transformation to its default state.
   /// This will reset all transformations to identity, meaning the points&apos; colors, positions and UV coordinates will be reset to their default values. <see cref="Efl.Gfx.Mapping.HasMapping"/> will then return <c>false</c>. This function will not modify the values of <see cref="Efl.Gfx.Mapping.MappingSmooth"/> or <see cref="Efl.Gfx.Mapping.MappingAlpha"/>.
   /// 1.20</summary>
   /// <returns></returns>
   virtual public  void ResetMapping() {
       Efl.Gfx.MappingNativeInherit.efl_gfx_mapping_reset_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }
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
                                                             Efl.Gfx.MappingNativeInherit.efl_gfx_mapping_translate_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), dx,  dy,  dz);
      Eina.Error.RaiseIfUnhandledException();
                                           }
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
                                                                               Efl.Gfx.MappingNativeInherit.efl_gfx_mapping_rotate_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), degrees,  pivot,  cx,  cy);
      Eina.Error.RaiseIfUnhandledException();
                                                       }
   /// <summary>Rotate the object around 3 axes in 3D.
   /// This will rotate in 3D, not just around the &quot;Z&quot; axis as is the case with <see cref="Efl.Gfx.Mapping.Rotate"/>. You can rotate around the X, Y and Z axes. The Z axis points &quot;into&quot; the screen with low values at the screen and higher values further away. The X axis runs from left to right on the screen and the Y axis from top to bottom.
   /// 
   /// As with <see cref="Efl.Gfx.Mapping.Rotate"/>, you provide a pivot and center point to rotate around (in 3D). The Z coordinate of this center point is an absolute value, and not a relative one like X and Y, as objects are flat in a 2D space.
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
                                                                                                                                     Efl.Gfx.MappingNativeInherit.efl_gfx_mapping_rotate_3d_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), dx,  dy,  dz,  pivot,  cx,  cy,  cz);
      Eina.Error.RaiseIfUnhandledException();
                                                                                           }
   /// <summary>Rotate the object in 3D using a unit quaternion.
   /// This is similar to <see cref="Efl.Gfx.Mapping.Rotate3d"/> but uses a unit quaternion (also known as versor) rather than a direct angle-based rotation around a center point. Use this to avoid gimbal locks.
   /// 
   /// As with <see cref="Efl.Gfx.Mapping.Rotate"/>, you provide a pivot and center point to rotate around (in 3D). The Z coordinate of this center point is an absolute value, and not a relative one like X and Y, as objects are flat in a 2D space.
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
                                                                                                                                                       Efl.Gfx.MappingNativeInherit.efl_gfx_mapping_rotate_quat_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), qx,  qy,  qz,  qw,  pivot,  cx,  cy,  cz);
      Eina.Error.RaiseIfUnhandledException();
                                                                                                       }
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
                                                                                                 Efl.Gfx.MappingNativeInherit.efl_gfx_mapping_zoom_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), zoomx,  zoomy,  pivot,  cx,  cy);
      Eina.Error.RaiseIfUnhandledException();
                                                                   }
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
   virtual public  void Lighting3d( Efl.Gfx.Entity pivot,  double lx,  double ly,  double lz,   int lr,   int lg,   int lb,   int ar,   int ag,   int ab) {
                                                                                                                                                                                           Efl.Gfx.MappingNativeInherit.efl_gfx_mapping_lighting_3d_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), pivot,  lx,  ly,  lz,  lr,  lg,  lb,  ar,  ag,  ab);
      Eina.Error.RaiseIfUnhandledException();
                                                                                                                               }
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
                                                                                                 Efl.Gfx.MappingNativeInherit.efl_gfx_mapping_perspective_3d_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), pivot,  px,  py,  z0,  foc);
      Eina.Error.RaiseIfUnhandledException();
                                                                   }
   /// <summary>Apply a rotation to the object, using absolute coordinates.
   /// This rotates the object clockwise by <c>degrees</c> degrees, around the center specified by the relative position (<c>cx</c>, <c>cy</c>) in the <c>pivot</c> object. If <c>pivot</c> is <c>null</c> then this object is used as its own pivot center. 360 degrees is a full rotation, equivalent to no rotation. Negative values for <c>degrees</c> will rotate clockwise by that amount.
   /// 
   /// The given coordinates are absolute values in pixels. See also <see cref="Efl.Gfx.Mapping.Rotate"/> for a relative coordinate version.
   /// 1.20</summary>
   /// <param name="degrees">CCW rotation in degrees.
   /// 1.20</param>
   /// <param name="cx">X absolute coordinate in pixels of the center point.
   /// 1.20</param>
   /// <param name="cy">y absolute coordinate in pixels of the center point.
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void RotateAbsolute( double degrees,  double cx,  double cy) {
                                                             Efl.Gfx.MappingNativeInherit.efl_gfx_mapping_rotate_absolute_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), degrees,  cx,  cy);
      Eina.Error.RaiseIfUnhandledException();
                                           }
   /// <summary>Rotate the object around 3 axes in 3D, using absolute coordinates.
   /// This will rotate in 3D and not just around the &quot;Z&quot; axis as the case with <see cref="Efl.Gfx.Mapping.Rotate"/>. This will rotate around the X, Y and Z axes. The Z axis points &quot;into&quot; the screen with low values at the screen and higher values further away. The X axis runs from left to right on the screen and the Y axis from top to bottom.
   /// 
   /// The coordinates of the center point are given in absolute canvas coordinates. See also <see cref="Efl.Gfx.Mapping.Rotate3d"/> for a pivot-based 3D rotation.
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
                                                                                                                   Efl.Gfx.MappingNativeInherit.efl_gfx_mapping_rotate_3d_absolute_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), dx,  dy,  dz,  cx,  cy,  cz);
      Eina.Error.RaiseIfUnhandledException();
                                                                               }
   /// <summary>Rotate the object in 3D using a unit quaternion, using absolute coordinates.
   /// This is similar to <see cref="Efl.Gfx.Mapping.Rotate3d"/> but uses a unit quaternion (also known as versor) rather than a direct angle-based rotation around a center point. Use this to avoid gimbal locks.
   /// 
   /// The coordinates of the center point are given in absolute canvas coordinates. See also <see cref="Efl.Gfx.Mapping.RotateQuat"/> for a pivot-based 3D rotation.
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
                                                                                                                                     Efl.Gfx.MappingNativeInherit.efl_gfx_mapping_rotate_quat_absolute_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), qx,  qy,  qz,  qw,  cx,  cy,  cz);
      Eina.Error.RaiseIfUnhandledException();
                                                                                           }
   /// <summary>Apply a zoom to the object, using absolute coordinates.
   /// This zooms the points of the map from a center point. That center is defined by <c>cx</c> and <c>cy</c>. The <c>zoomx</c> and <c>zoomy</c> parameters specify how much to zoom in the X and Y direction respectively. A value of 1.0 means &quot;don&apos;t zoom&quot;. 2.0 means &quot;double the size&quot;. 0.5 is &quot;half the size&quot; etc.
   /// 
   /// The coordinates of the center point are given in absolute canvas coordinates. See also <see cref="Efl.Gfx.Mapping.Zoom"/> for a pivot-based zoom.
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
                                                                               Efl.Gfx.MappingNativeInherit.efl_gfx_mapping_zoom_absolute_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), zoomx,  zoomy,  cx,  cy);
      Eina.Error.RaiseIfUnhandledException();
                                                       }
   /// <summary>Apply a lighting effect to the object.
   /// This is used to apply lighting calculations (from a single light source) to a given mapped object. The RGB values of each vertex will be modified to reflect the lighting based on the light point coordinates, the light color, the ambient color and at what angle the map is facing the light source. A surface should have its points be declared in a clockwise fashion if the face is &quot;facing&quot; towards you (as opposed to away from you) as faces have a &quot;logical&quot; side for lighting.
   /// 
   /// The coordinates of the center point are given in absolute canvas coordinates. See also <see cref="Efl.Gfx.Mapping.Lighting3d"/> for a pivot-based lighting effect.
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
   virtual public  void Lighting3dAbsolute( double lx,  double ly,  double lz,   int lr,   int lg,   int lb,   int ar,   int ag,   int ab) {
                                                                                                                                                                         Efl.Gfx.MappingNativeInherit.efl_gfx_mapping_lighting_3d_absolute_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), lx,  ly,  lz,  lr,  lg,  lb,  ar,  ag,  ab);
      Eina.Error.RaiseIfUnhandledException();
                                                                                                                   }
   /// <summary>Apply a perspective transform to the map
   /// This applies a given perspective (3D) to the map coordinates. X, Y and Z values are used. The px and py points specify the &quot;infinite distance&quot; point in the 3D conversion (where all lines converge to like when artists draw 3D by hand). The <c>z0</c> value specifies the z value at which there is a 1:1 mapping between spatial coordinates and screen coordinates. Any points on this z value will not have their X and Y values modified in the transform. Those further away (Z value higher) will shrink into the distance, and those less than this value will expand and become bigger. The <c>foc</c> value determines the &quot;focal length&quot; of the camera. This is in reality the distance between the camera lens plane itself (at or closer than this rendering results are undefined) and the &quot;z0&quot; z value. This allows for some &quot;depth&quot; control and <c>foc</c> must be greater than 0.
   /// 
   /// The coordinates of the center point are given in absolute canvas coordinates. See also <see cref="Efl.Gfx.Mapping.Perspective3d"/> for a pivot-based perspective effect.
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
                                                                               Efl.Gfx.MappingNativeInherit.efl_gfx_mapping_perspective_3d_absolute_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), px,  py,  z0,  foc);
      Eina.Error.RaiseIfUnhandledException();
                                                       }
   /// <summary>Retrieves the layer of its canvas that the given object is part of.
   /// See also <see cref="Efl.Gfx.Stack.SetLayer"/></summary>
   /// <returns>The number of the layer to place the object on. Must be between <see cref="Efl.Gfx.Constants.StackLayerMin"/> and <see cref="Efl.Gfx.Constants.StackLayerMax"/>.</returns>
   virtual public  short GetLayer() {
       var _ret_var = Efl.Gfx.StackNativeInherit.efl_gfx_stack_layer_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Sets the layer of its canvas that the given object will be part of.
   /// If you don&apos;t use this function, you&apos;ll be dealing with an unique layer of objects (the default one). Additional layers are handy when you don&apos;t want a set of objects to interfere with another set with regard to stacking. Two layers are completely disjoint in that matter.
   /// 
   /// This is a low-level function, which you&apos;d be using when something should be always on top, for example.
   /// 
   /// Warning: Don&apos;t change the layer of smart objects&apos; children. Smart objects have a layer of their own, which should contain all their child objects.
   /// 
   /// See also <see cref="Efl.Gfx.Stack.GetLayer"/></summary>
   /// <param name="l">The number of the layer to place the object on. Must be between <see cref="Efl.Gfx.Constants.StackLayerMin"/> and <see cref="Efl.Gfx.Constants.StackLayerMax"/>.</param>
   /// <returns></returns>
   virtual public  void SetLayer(  short l) {
                         Efl.Gfx.StackNativeInherit.efl_gfx_stack_layer_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), l);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Get the Evas object stacked right below <c>obj</c>
   /// This function will traverse layers in its search, if there are objects on layers below the one <c>obj</c> is placed at.
   /// 
   /// See also <see cref="Efl.Gfx.Stack.GetLayer"/>, <see cref="Efl.Gfx.Stack.SetLayer"/> and <see cref="Efl.Gfx.Stack.GetBelow"/></summary>
   /// <returns>The <see cref="Efl.Gfx.Stack"/> object directly below <c>obj</c>, if any, or <c>null</c>, if none.</returns>
   virtual public Efl.Gfx.Stack GetBelow() {
       var _ret_var = Efl.Gfx.StackNativeInherit.efl_gfx_stack_below_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Get the Evas object stacked right above <c>obj</c>
   /// This function will traverse layers in its search, if there are objects on layers above the one <c>obj</c> is placed at.
   /// 
   /// See also <see cref="Efl.Gfx.Stack.GetLayer"/>, <see cref="Efl.Gfx.Stack.SetLayer"/> and <see cref="Efl.Gfx.Stack.GetBelow"/></summary>
   /// <returns>The <see cref="Efl.Gfx.Stack"/> object directly below <c>obj</c>, if any, or <c>null</c>, if none.</returns>
   virtual public Efl.Gfx.Stack GetAbove() {
       var _ret_var = Efl.Gfx.StackNativeInherit.efl_gfx_stack_above_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
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
                         Efl.Gfx.StackNativeInherit.efl_gfx_stack_below_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), below);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Raise <c>obj</c> to the top of its layer.
   /// <c>obj</c> will, then, be the highest one in the layer it belongs to. Object on other layers won&apos;t get touched.
   /// 
   /// See also <see cref="Efl.Gfx.Stack.StackAbove"/>, <see cref="Efl.Gfx.Stack.StackBelow"/> and <see cref="Efl.Gfx.Stack.LowerToBottom"/></summary>
   /// <returns></returns>
   virtual public  void RaiseToTop() {
       Efl.Gfx.StackNativeInherit.efl_gfx_stack_raise_to_top_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }
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
                         Efl.Gfx.StackNativeInherit.efl_gfx_stack_above_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), above);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Lower <c>obj</c> to the bottom of its layer.
   /// <c>obj</c> will, then, be the lowest one in the layer it belongs to. Objects on other layers won&apos;t get touched.
   /// 
   /// See also <see cref="Efl.Gfx.Stack.StackAbove"/>, <see cref="Efl.Gfx.Stack.StackBelow"/> and <see cref="Efl.Gfx.Stack.RaiseToTop"/></summary>
   /// <returns></returns>
   virtual public  void LowerToBottom() {
       Efl.Gfx.StackNativeInherit.efl_gfx_stack_lower_to_bottom_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }
   /// <summary>Check if input events from a given seat is enabled.
   /// 1.19</summary>
   /// <param name="seat">The seat to act on.
   /// 1.19</param>
   /// <returns><c>true</c> to enable events for a seat or <c>false</c> otherwise.
   /// 1.19</returns>
   virtual public bool GetSeatEventFilter( Efl.Input.Device seat) {
                         var _ret_var = Efl.Input.InterfaceNativeInherit.efl_input_seat_event_filter_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), seat);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Add or remove a given seat to the filter list. If the filter list is empty this object will report mouse, keyboard and focus events from any seat, otherwise those events will only be reported if the event comes from a seat that is in the list.
   /// 1.19</summary>
   /// <param name="seat">The seat to act on.
   /// 1.19</param>
   /// <param name="enable"><c>true</c> to enable events for a seat or <c>false</c> otherwise.
   /// 1.19</param>
   /// <returns></returns>
   virtual public  void SetSeatEventFilter( Efl.Input.Device seat,  bool enable) {
                                           Efl.Input.InterfaceNativeInherit.efl_input_seat_event_filter_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), seat,  enable);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Whether this object should be mirrored.
   /// If mirrored, an object is in RTL (right to left) mode instead of LTR (left to right).</summary>
   /// <returns><c>true</c> for RTL, <c>false</c> for LTR (default).</returns>
   virtual public bool GetMirrored() {
       var _ret_var = Efl.Ui.I18nNativeInherit.efl_ui_mirrored_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Whether this object should be mirrored.
   /// If mirrored, an object is in RTL (right to left) mode instead of LTR (left to right).</summary>
   /// <param name="rtl"><c>true</c> for RTL, <c>false</c> for LTR (default).</param>
   /// <returns></returns>
   virtual public  void SetMirrored( bool rtl) {
                         Efl.Ui.I18nNativeInherit.efl_ui_mirrored_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), rtl);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Whether the property <see cref="Efl.Ui.I18n.Mirrored"/> should be set automatically.
   /// If enabled, the system or application configuration will be used to set the value of <see cref="Efl.Ui.I18n.Mirrored"/>.
   /// 
   /// This property may be implemented by high-level widgets (in Efl.Ui) but not by low-level widgets (in <see cref="Efl.Canvas.Scene"/>) as the configuration should affect only high-level widgets.</summary>
   /// <returns>Whether the widget uses automatic mirroring</returns>
   virtual public bool GetMirroredAutomatic() {
       var _ret_var = Efl.Ui.I18nNativeInherit.efl_ui_mirrored_automatic_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Whether the property <see cref="Efl.Ui.I18n.Mirrored"/> should be set automatically.
   /// If enabled, the system or application configuration will be used to set the value of <see cref="Efl.Ui.I18n.Mirrored"/>.
   /// 
   /// This property may be implemented by high-level widgets (in Efl.Ui) but not by low-level widgets (in <see cref="Efl.Canvas.Scene"/>) as the configuration should affect only high-level widgets.</summary>
   /// <param name="automatic">Whether the widget uses automatic mirroring</param>
   /// <returns></returns>
   virtual public  void SetMirroredAutomatic( bool automatic) {
                         Efl.Ui.I18nNativeInherit.efl_ui_mirrored_automatic_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), automatic);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Gets the language for this object.</summary>
   /// <returns>The current language.</returns>
   virtual public  System.String GetLanguage() {
       var _ret_var = Efl.Ui.I18nNativeInherit.efl_ui_language_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Sets the language for this object.</summary>
   /// <param name="language">The current language.</param>
   /// <returns></returns>
   virtual public  void SetLanguage(  System.String language) {
                         Efl.Ui.I18nNativeInherit.efl_ui_language_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), language);
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
/// <value>Input pointer mode</value>
   public Efl.Input.ObjectPointerMode PointerMode {
      get { return GetPointerMode(); }
      set { SetPointerMode( value); }
   }
   /// <summary>Render mode to be used for compositing the Evas object.
/// Only two modes are supported: - <see cref="Efl.Gfx.RenderOp.Blend"/> means the object will be merged on top of objects below it using simple alpha compositing. - <see cref="Efl.Gfx.RenderOp.Copy"/> means this object&apos;s pixels will replace everything that is below, making this object opaque.
/// 
/// Please do not assume that <see cref="Efl.Gfx.RenderOp.Copy"/> mode can be used to &quot;poke&quot; holes in a window (to see through it), as only the compositor can ensure that. Copy mode should only be used with otherwise opaque widgets or inside non-window surfaces (eg. a transparent background inside a buffer canvas).</summary>
/// <value>Blend or copy.</value>
   public Efl.Gfx.RenderOp RenderOp {
      get { return GetRenderOp(); }
      set { SetRenderOp( value); }
   }
   /// <summary>Get the object clipping <c>obj</c> (if any).
/// This function returns the object clipping <c>obj</c>. If <c>obj</c> is not being clipped at all, <c>null</c> is returned. The object <c>obj</c> must be a valid Evas_Object.</summary>
/// <value>The object to clip <c>obj</c> by.</value>
   public Efl.Canvas.Object Clipper {
      get { return GetClipper(); }
      set { SetClipper( value); }
   }
   /// <summary>Determine whether an object is set to repeat events.</summary>
/// <value>Whether <c>obj</c> is to repeat events (<c>true</c>) or not (<c>false</c>).</value>
   public bool RepeatEvents {
      get { return GetRepeatEvents(); }
      set { SetRepeatEvents( value); }
   }
   /// <summary>Indicates that this object is the keyboard event receiver on its canvas.
/// Changing focus only affects where (key) input events go. There can be only one object focused at any time. If <c>focus</c> is <c>true</c>, <c>obj</c> will be set as the currently focused object and it will receive all keyboard events that are not exclusive key grabs on other objects. See also <see cref="Efl.Canvas.Object.CheckSeatFocus"/>, <see cref="Efl.Canvas.Object.AddSeatFocus"/>, <see cref="Efl.Canvas.Object.DelSeatFocus"/>.</summary>
/// <value><c>true</c> when set as focused or <c>false</c> otherwise.</value>
   public bool KeyFocus {
      get { return GetKeyFocus(); }
      set { SetKeyFocus( value); }
   }
   /// <summary>Check if this object is focused.
/// 1.19</summary>
/// <value><c>true</c> if focused by at least one seat or <c>false</c> otherwise.</value>
   public bool SeatFocus {
      get { return GetSeatFocus(); }
   }
   /// <summary>Determine whether an object is set to use precise point collision detection.</summary>
/// <value>Whether to use precise point collision detection or not. The default value is false.</value>
   public bool PreciseIsInside {
      get { return GetPreciseIsInside(); }
      set { SetPreciseIsInside( value); }
   }
   /// <summary>Retrieve whether an Evas object is set to propagate events.
/// See also <see cref="Efl.Canvas.Object.GetRepeatEvents"/>, <see cref="Efl.Canvas.Object.GetPassEvents"/>.</summary>
/// <value>Whether to propagate events (<c>true</c>) or not (<c>false</c>).</value>
   public bool PropagateEvents {
      get { return GetPropagateEvents(); }
      set { SetPropagateEvents( value); }
   }
   /// <summary>Determine whether an object is set to pass (ignore) events.
/// See also <see cref="Efl.Canvas.Object.GetRepeatEvents"/>, <see cref="Efl.Canvas.Object.GetPropagateEvents"/>.</summary>
/// <value>Whether <c>obj</c> is to pass events (<c>true</c>) or not (<c>false</c>).</value>
   public bool PassEvents {
      get { return GetPassEvents(); }
      set { SetPassEvents( value); }
   }
   /// <summary>Retrieves whether or not the given Evas object is to be drawn anti_aliased.</summary>
/// <value><c>true</c> if the object is to be anti_aliased, <c>false</c> otherwise.</value>
   public bool AntiAlias {
      get { return GetAntiAlias(); }
      set { SetAntiAlias( value); }
   }
   /// <summary>Return a list of objects currently clipped by <c>obj</c>.
/// This returns the internal list handle containing all objects clipped by the object <c>obj</c>. If none are clipped by it, the call returns <c>null</c>. This list is only valid until the clip list is changed and should be fetched again with another call to this function if any objects being clipped by this object are unclipped, clipped by a new object, deleted or get the clipper deleted. These operations will invalidate the list returned, so it should not be used anymore after that point. Any use of the list after this may have undefined results, possibly leading to crashes.
/// 
/// See also <see cref="Efl.Canvas.Object.Clipper"/>.</summary>
/// <value>An iterator over the list of objects clipped by <c>obj</c>.</value>
   public Eina.Iterator<Efl.Canvas.Object> ClippedObjects {
      get { return GetClippedObjects(); }
   }
   /// <summary>Gets the parent smart object of a given Evas object, if it has one.
/// This can be different from <see cref="Efl.Object.Parent"/> because this one is used internally for rendering and the normal parent is what the user expects to be the parent.
/// 1.18</summary>
/// <value>The parent smart object of <c>obj</c> or <c>null</c>.</value>
   public Efl.Canvas.Object RenderParent {
      get { return GetRenderParent(); }
   }
   /// <summary>This handles text paragraph direction of the given object. Even if the given object is not textblock or text, its smart child objects can inherit the paragraph direction from the given object. The default paragraph direction is <c>inherit</c>.</summary>
/// <value>Paragraph direction for the given object.</value>
   public Efl.TextBidirectionalType ParagraphDirection {
      get { return GetParagraphDirection(); }
      set { SetParagraphDirection( value); }
   }
   /// <summary>Returns the state of the &quot;no-render&quot; flag, which means, when true, that an object should never be rendered on the canvas.
/// This flag can be used to avoid rendering visible clippers on the canvas, even if they currently don&apos;t clip any object.
/// 1.15</summary>
/// <value>Enable &quot;no-render&quot; mode.</value>
   public bool NoRender {
      get { return GetNoRender(); }
      set { SetNoRender( value); }
   }
   /// <summary>Get hex color code of given Evas object. This returns a short lived hex color code string.</summary>
/// <value>the hex color code.</value>
   public  System.String ColorCode {
      get { return GetColorCode(); }
      set { SetColorCode( value); }
   }
   /// <summary>The 2D position of a canvas object.
/// The position is absolute, in pixels, relative to the top-left corner of the window, within its border decorations (application space).</summary>
/// <value>A 2D coordinate in pixel units.</value>
   public Eina.Position2D Position {
      get { return GetPosition(); }
      set { SetPosition( value); }
   }
   /// <summary>The 2D size of a canvas object.</summary>
/// <value>A 2D size in pixel units.</value>
   public Eina.Size2D Size {
      get { return GetSize(); }
      set { SetSize( value); }
   }
   /// <summary>Rectangular geometry that combines both position and size.</summary>
/// <value>The X,Y position and W,H size, in pixels.</value>
   public Eina.Rect Geometry {
      get { return GetGeometry(); }
      set { SetGeometry( value); }
   }
   /// <summary>The visibility of a canvas object.
/// All canvas objects will become visible by default just before render. This means that it is not required to call <see cref="Efl.Gfx.Entity.SetVisible"/> after creating an object unless you want to create it without showing it. Note that this behavior is new since 1.21, and only applies to canvas objects created with the EO API (i.e. not the legacy C-only API). Other types of Gfx objects may or may not be visible by default.
/// 
/// Note that many other parameters can prevent a visible object from actually being &quot;visible&quot; on screen. For instance if its color is fully transparent, or its parent is hidden, or it is clipped out, etc...</summary>
/// <value><c>true</c> if to make the object visible, <c>false</c> otherwise</value>
   public bool Visible {
      get { return GetVisible(); }
      set { SetVisible( value); }
   }
   /// <summary>The scaling factor of an object.
/// This property is an individual scaling factor on the object (Edje or UI widget). This property (or Edje&apos;s global scaling factor, when applicable), will affect this object&apos;s part sizes. If scale is not zero, than the individual scaling will override any global scaling set, for the object obj&apos;s parts. Set it back to zero to get the effects of the global scaling again.
/// 
/// Warning: In Edje, only parts which, at EDC level, had the &quot;scale&quot; property set to 1, will be affected by this function. Check the complete &quot;syntax reference&quot; for EDC files.</summary>
/// <value>The scaling factor (the default value is 0.0, meaning individual scaling is not set)</value>
   public double Scale {
      get { return GetScale(); }
      set { SetScale( value); }
   }
   /// <summary>Hints on the object&apos;s maximum size.
/// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
/// 
/// The object container is in charge of fetching this property and placing the object accordingly.
/// 
/// Values -1 will be treated as unset hint components, when queried by managers.
/// 
/// Note: Smart objects (such as elementary) can have their own hint policy. So calling this API may or may not affect the size of smart objects.</summary>
/// <value>Maximum size (hint) in pixels, (-1, -1) by default for canvas objects).</value>
   public Eina.Size2D HintSizeMax {
      get { return GetHintSizeMax(); }
      set { SetHintSizeMax( value); }
   }
   /// <summary>Hints on the object&apos;s minimum size.
/// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate. The object container is in charge of fetching this property and placing the object accordingly.
/// 
/// Value 0 will be treated as unset hint components, when queried by managers.
/// 
/// Note: This property is meant to be set by applications and not by EFL itself. Use this to request a specific size (treated as minimum size).</summary>
/// <value>Minimum size (hint) in pixels.</value>
   public Eina.Size2D HintSizeMin {
      get { return GetHintSizeMin(); }
      set { SetHintSizeMin( value); }
   }
   /// <summary>Internal hints for an object&apos;s minimum size.
/// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
/// 
/// Values 0 will be treated as unset hint components, when queried by managers.
/// 
/// Note: This property is internal and meant for widget developers to define the absolute minimum size of the object. EFL itself sets this size internally, so any change to it from an application might be ignored. Use <see cref="Efl.Gfx.Hint.HintSizeMin"/> instead.</summary>
/// <value>Minimum size (hint) in pixels.</value>
   public Eina.Size2D HintSizeRestrictedMin {
      get { return GetHintSizeRestrictedMin(); }
      set { SetHintSizeRestrictedMin( value); }
   }
   /// <summary>Read-only minimum size combining both <see cref="Efl.Gfx.Hint.HintSizeRestrictedMin"/> and <see cref="Efl.Gfx.Hint.HintSizeMin"/> hints.
/// <see cref="Efl.Gfx.Hint.HintSizeRestrictedMin"/> is intended for mostly internal usage and widget developers, and <see cref="Efl.Gfx.Hint.HintSizeMin"/> is intended to be set from application side. <see cref="Efl.Gfx.Hint.GetHintSizeCombinedMin"/> combines both values by taking their repective maximum (in both width and height), and is used internally to get an object&apos;s minimum size.</summary>
/// <value>Minimum size (hint) in pixels.</value>
   public Eina.Size2D HintSizeCombinedMin {
      get { return GetHintSizeCombinedMin(); }
   }
   /// <summary>Number of points of a map.
/// This sets the number of points of map. Currently, the number of points must be multiples of 4.
/// 1.20</summary>
/// <value>The number of points of map
/// 1.20</value>
   public  int MappingPointCount {
      get { return GetMappingPointCount(); }
      set { SetMappingPointCount( value); }
   }
   /// <summary>Clockwise state of a map (read-only).
/// This determines if the output points (X and Y. Z is not used) are clockwise or counter-clockwise. This can be used for &quot;back-face culling&quot;. This is where you hide objects that &quot;face away&quot; from you. In this case objects that are not clockwise.
/// 1.20</summary>
/// <value><c>true</c> if clockwise, <c>false</c> if counter clockwise
/// 1.20</value>
   public bool MappingClockwise {
      get { return GetMappingClockwise(); }
   }
   /// <summary>Smoothing state for map rendering.
/// This sets smoothing for map rendering. If the object is a type that has its own smoothing settings, then both the smooth settings for this object and the map must be turned off. By default smooth maps are enabled.
/// 1.20</summary>
/// <value><c>true</c> by default.
/// 1.20</value>
   public bool MappingSmooth {
      get { return GetMappingSmooth(); }
      set { SetMappingSmooth( value); }
   }
   /// <summary>Alpha flag for map rendering.
/// This sets alpha flag for map rendering. If the object is a type that has its own alpha settings, then this will take precedence. Only image objects support this currently (<see cref="Efl.Canvas.Image"/> and its friends). Setting this to off stops alpha blending of the map area, and is useful if you know the object and/or all sub-objects is 100% solid.
/// 
/// Note that this may conflict with <see cref="Efl.Gfx.Mapping.MappingSmooth"/> depending on which algorithm is used for anti-aliasing.
/// 1.20</summary>
/// <value><c>true</c> by default.
/// 1.20</value>
   public bool MappingAlpha {
      get { return GetMappingAlpha(); }
      set { SetMappingAlpha( value); }
   }
   /// <summary>Retrieves the layer of its canvas that the given object is part of.
/// See also <see cref="Efl.Gfx.Stack.SetLayer"/></summary>
/// <value>The number of the layer to place the object on. Must be between <see cref="Efl.Gfx.Constants.StackLayerMin"/> and <see cref="Efl.Gfx.Constants.StackLayerMax"/>.</value>
   public  short Layer {
      get { return GetLayer(); }
      set { SetLayer( value); }
   }
   /// <summary>Get the Evas object stacked right below <c>obj</c>
/// This function will traverse layers in its search, if there are objects on layers below the one <c>obj</c> is placed at.
/// 
/// See also <see cref="Efl.Gfx.Stack.GetLayer"/>, <see cref="Efl.Gfx.Stack.SetLayer"/> and <see cref="Efl.Gfx.Stack.GetBelow"/></summary>
/// <value>The <see cref="Efl.Gfx.Stack"/> object directly below <c>obj</c>, if any, or <c>null</c>, if none.</value>
   public Efl.Gfx.Stack Below {
      get { return GetBelow(); }
   }
   /// <summary>Get the Evas object stacked right above <c>obj</c>
/// This function will traverse layers in its search, if there are objects on layers above the one <c>obj</c> is placed at.
/// 
/// See also <see cref="Efl.Gfx.Stack.GetLayer"/>, <see cref="Efl.Gfx.Stack.SetLayer"/> and <see cref="Efl.Gfx.Stack.GetBelow"/></summary>
/// <value>The <see cref="Efl.Gfx.Stack"/> object directly below <c>obj</c>, if any, or <c>null</c>, if none.</value>
   public Efl.Gfx.Stack Above {
      get { return GetAbove(); }
   }
   /// <summary>Whether this object should be mirrored.
/// If mirrored, an object is in RTL (right to left) mode instead of LTR (left to right).</summary>
/// <value><c>true</c> for RTL, <c>false</c> for LTR (default).</value>
   public bool Mirrored {
      get { return GetMirrored(); }
      set { SetMirrored( value); }
   }
   /// <summary>Whether the property <see cref="Efl.Ui.I18n.Mirrored"/> should be set automatically.
/// If enabled, the system or application configuration will be used to set the value of <see cref="Efl.Ui.I18n.Mirrored"/>.
/// 
/// This property may be implemented by high-level widgets (in Efl.Ui) but not by low-level widgets (in <see cref="Efl.Canvas.Scene"/>) as the configuration should affect only high-level widgets.</summary>
/// <value>Whether the widget uses automatic mirroring</value>
   public bool MirroredAutomatic {
      get { return GetMirroredAutomatic(); }
      set { SetMirroredAutomatic( value); }
   }
   /// <summary>The (human) language for this object.</summary>
/// <value>The current language.</value>
   public  System.String Language {
      get { return GetLanguage(); }
      set { SetLanguage( value); }
   }
   private static new  IntPtr GetEflClassStatic()
   {
      return Efl.Canvas.Object.efl_canvas_object_class_get();
   }
}
public class ObjectNativeInherit : Efl.LoopConsumerNativeInherit{
   public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Evas);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      if (efl_canvas_object_pointer_mode_by_device_get_static_delegate == null)
      efl_canvas_object_pointer_mode_by_device_get_static_delegate = new efl_canvas_object_pointer_mode_by_device_get_delegate(pointer_mode_by_device_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_object_pointer_mode_by_device_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_pointer_mode_by_device_get_static_delegate)});
      if (efl_canvas_object_pointer_mode_by_device_set_static_delegate == null)
      efl_canvas_object_pointer_mode_by_device_set_static_delegate = new efl_canvas_object_pointer_mode_by_device_set_delegate(pointer_mode_by_device_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_object_pointer_mode_by_device_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_pointer_mode_by_device_set_static_delegate)});
      if (efl_canvas_object_pointer_mode_get_static_delegate == null)
      efl_canvas_object_pointer_mode_get_static_delegate = new efl_canvas_object_pointer_mode_get_delegate(pointer_mode_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_object_pointer_mode_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_pointer_mode_get_static_delegate)});
      if (efl_canvas_object_pointer_mode_set_static_delegate == null)
      efl_canvas_object_pointer_mode_set_static_delegate = new efl_canvas_object_pointer_mode_set_delegate(pointer_mode_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_object_pointer_mode_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_pointer_mode_set_static_delegate)});
      if (efl_canvas_object_render_op_get_static_delegate == null)
      efl_canvas_object_render_op_get_static_delegate = new efl_canvas_object_render_op_get_delegate(render_op_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_object_render_op_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_render_op_get_static_delegate)});
      if (efl_canvas_object_render_op_set_static_delegate == null)
      efl_canvas_object_render_op_set_static_delegate = new efl_canvas_object_render_op_set_delegate(render_op_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_object_render_op_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_render_op_set_static_delegate)});
      if (efl_canvas_object_clipper_get_static_delegate == null)
      efl_canvas_object_clipper_get_static_delegate = new efl_canvas_object_clipper_get_delegate(clipper_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_object_clipper_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_clipper_get_static_delegate)});
      if (efl_canvas_object_clipper_set_static_delegate == null)
      efl_canvas_object_clipper_set_static_delegate = new efl_canvas_object_clipper_set_delegate(clipper_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_object_clipper_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_clipper_set_static_delegate)});
      if (efl_canvas_object_repeat_events_get_static_delegate == null)
      efl_canvas_object_repeat_events_get_static_delegate = new efl_canvas_object_repeat_events_get_delegate(repeat_events_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_object_repeat_events_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_repeat_events_get_static_delegate)});
      if (efl_canvas_object_repeat_events_set_static_delegate == null)
      efl_canvas_object_repeat_events_set_static_delegate = new efl_canvas_object_repeat_events_set_delegate(repeat_events_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_object_repeat_events_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_repeat_events_set_static_delegate)});
      if (efl_canvas_object_key_focus_get_static_delegate == null)
      efl_canvas_object_key_focus_get_static_delegate = new efl_canvas_object_key_focus_get_delegate(key_focus_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_object_key_focus_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_key_focus_get_static_delegate)});
      if (efl_canvas_object_key_focus_set_static_delegate == null)
      efl_canvas_object_key_focus_set_static_delegate = new efl_canvas_object_key_focus_set_delegate(key_focus_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_object_key_focus_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_key_focus_set_static_delegate)});
      if (efl_canvas_object_seat_focus_get_static_delegate == null)
      efl_canvas_object_seat_focus_get_static_delegate = new efl_canvas_object_seat_focus_get_delegate(seat_focus_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_object_seat_focus_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_seat_focus_get_static_delegate)});
      if (efl_canvas_object_precise_is_inside_get_static_delegate == null)
      efl_canvas_object_precise_is_inside_get_static_delegate = new efl_canvas_object_precise_is_inside_get_delegate(precise_is_inside_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_object_precise_is_inside_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_precise_is_inside_get_static_delegate)});
      if (efl_canvas_object_precise_is_inside_set_static_delegate == null)
      efl_canvas_object_precise_is_inside_set_static_delegate = new efl_canvas_object_precise_is_inside_set_delegate(precise_is_inside_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_object_precise_is_inside_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_precise_is_inside_set_static_delegate)});
      if (efl_canvas_object_propagate_events_get_static_delegate == null)
      efl_canvas_object_propagate_events_get_static_delegate = new efl_canvas_object_propagate_events_get_delegate(propagate_events_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_object_propagate_events_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_propagate_events_get_static_delegate)});
      if (efl_canvas_object_propagate_events_set_static_delegate == null)
      efl_canvas_object_propagate_events_set_static_delegate = new efl_canvas_object_propagate_events_set_delegate(propagate_events_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_object_propagate_events_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_propagate_events_set_static_delegate)});
      if (efl_canvas_object_pass_events_get_static_delegate == null)
      efl_canvas_object_pass_events_get_static_delegate = new efl_canvas_object_pass_events_get_delegate(pass_events_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_object_pass_events_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_pass_events_get_static_delegate)});
      if (efl_canvas_object_pass_events_set_static_delegate == null)
      efl_canvas_object_pass_events_set_static_delegate = new efl_canvas_object_pass_events_set_delegate(pass_events_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_object_pass_events_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_pass_events_set_static_delegate)});
      if (efl_canvas_object_anti_alias_get_static_delegate == null)
      efl_canvas_object_anti_alias_get_static_delegate = new efl_canvas_object_anti_alias_get_delegate(anti_alias_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_object_anti_alias_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_anti_alias_get_static_delegate)});
      if (efl_canvas_object_anti_alias_set_static_delegate == null)
      efl_canvas_object_anti_alias_set_static_delegate = new efl_canvas_object_anti_alias_set_delegate(anti_alias_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_object_anti_alias_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_anti_alias_set_static_delegate)});
      if (efl_canvas_object_clipped_objects_get_static_delegate == null)
      efl_canvas_object_clipped_objects_get_static_delegate = new efl_canvas_object_clipped_objects_get_delegate(clipped_objects_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_object_clipped_objects_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_clipped_objects_get_static_delegate)});
      if (efl_canvas_object_render_parent_get_static_delegate == null)
      efl_canvas_object_render_parent_get_static_delegate = new efl_canvas_object_render_parent_get_delegate(render_parent_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_object_render_parent_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_render_parent_get_static_delegate)});
      if (efl_canvas_object_paragraph_direction_get_static_delegate == null)
      efl_canvas_object_paragraph_direction_get_static_delegate = new efl_canvas_object_paragraph_direction_get_delegate(paragraph_direction_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_object_paragraph_direction_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_paragraph_direction_get_static_delegate)});
      if (efl_canvas_object_paragraph_direction_set_static_delegate == null)
      efl_canvas_object_paragraph_direction_set_static_delegate = new efl_canvas_object_paragraph_direction_set_delegate(paragraph_direction_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_object_paragraph_direction_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_paragraph_direction_set_static_delegate)});
      if (efl_canvas_object_no_render_get_static_delegate == null)
      efl_canvas_object_no_render_get_static_delegate = new efl_canvas_object_no_render_get_delegate(no_render_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_object_no_render_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_no_render_get_static_delegate)});
      if (efl_canvas_object_no_render_set_static_delegate == null)
      efl_canvas_object_no_render_set_static_delegate = new efl_canvas_object_no_render_set_delegate(no_render_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_object_no_render_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_no_render_set_static_delegate)});
      if (efl_canvas_object_coords_inside_get_static_delegate == null)
      efl_canvas_object_coords_inside_get_static_delegate = new efl_canvas_object_coords_inside_get_delegate(coords_inside_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_object_coords_inside_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_coords_inside_get_static_delegate)});
      if (efl_canvas_object_seat_focus_check_static_delegate == null)
      efl_canvas_object_seat_focus_check_static_delegate = new efl_canvas_object_seat_focus_check_delegate(seat_focus_check);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_object_seat_focus_check"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_seat_focus_check_static_delegate)});
      if (efl_canvas_object_seat_focus_add_static_delegate == null)
      efl_canvas_object_seat_focus_add_static_delegate = new efl_canvas_object_seat_focus_add_delegate(seat_focus_add);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_object_seat_focus_add"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_seat_focus_add_static_delegate)});
      if (efl_canvas_object_seat_focus_del_static_delegate == null)
      efl_canvas_object_seat_focus_del_static_delegate = new efl_canvas_object_seat_focus_del_delegate(seat_focus_del);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_object_seat_focus_del"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_seat_focus_del_static_delegate)});
      if (efl_canvas_object_clipped_objects_count_static_delegate == null)
      efl_canvas_object_clipped_objects_count_static_delegate = new efl_canvas_object_clipped_objects_count_delegate(clipped_objects_count);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_object_clipped_objects_count"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_clipped_objects_count_static_delegate)});
      if (efl_canvas_object_key_grab_static_delegate == null)
      efl_canvas_object_key_grab_static_delegate = new efl_canvas_object_key_grab_delegate(key_grab);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_object_key_grab"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_key_grab_static_delegate)});
      if (efl_canvas_object_key_ungrab_static_delegate == null)
      efl_canvas_object_key_ungrab_static_delegate = new efl_canvas_object_key_ungrab_delegate(key_ungrab);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_object_key_ungrab"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_key_ungrab_static_delegate)});
      if (efl_canvas_pointer_inside_get_static_delegate == null)
      efl_canvas_pointer_inside_get_static_delegate = new efl_canvas_pointer_inside_get_delegate(pointer_inside_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_pointer_inside_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_pointer_inside_get_static_delegate)});
      if (efl_gfx_color_get_static_delegate == null)
      efl_gfx_color_get_static_delegate = new efl_gfx_color_get_delegate(color_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_color_get_static_delegate)});
      if (efl_gfx_color_set_static_delegate == null)
      efl_gfx_color_set_static_delegate = new efl_gfx_color_set_delegate(color_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_color_set_static_delegate)});
      if (efl_gfx_color_code_get_static_delegate == null)
      efl_gfx_color_code_get_static_delegate = new efl_gfx_color_code_get_delegate(color_code_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_color_code_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_color_code_get_static_delegate)});
      if (efl_gfx_color_code_set_static_delegate == null)
      efl_gfx_color_code_set_static_delegate = new efl_gfx_color_code_set_delegate(color_code_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_color_code_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_color_code_set_static_delegate)});
      if (efl_gfx_entity_position_get_static_delegate == null)
      efl_gfx_entity_position_get_static_delegate = new efl_gfx_entity_position_get_delegate(position_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_entity_position_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_position_get_static_delegate)});
      if (efl_gfx_entity_position_set_static_delegate == null)
      efl_gfx_entity_position_set_static_delegate = new efl_gfx_entity_position_set_delegate(position_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_entity_position_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_position_set_static_delegate)});
      if (efl_gfx_entity_size_get_static_delegate == null)
      efl_gfx_entity_size_get_static_delegate = new efl_gfx_entity_size_get_delegate(size_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_entity_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_size_get_static_delegate)});
      if (efl_gfx_entity_size_set_static_delegate == null)
      efl_gfx_entity_size_set_static_delegate = new efl_gfx_entity_size_set_delegate(size_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_entity_size_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_size_set_static_delegate)});
      if (efl_gfx_entity_geometry_get_static_delegate == null)
      efl_gfx_entity_geometry_get_static_delegate = new efl_gfx_entity_geometry_get_delegate(geometry_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_entity_geometry_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_geometry_get_static_delegate)});
      if (efl_gfx_entity_geometry_set_static_delegate == null)
      efl_gfx_entity_geometry_set_static_delegate = new efl_gfx_entity_geometry_set_delegate(geometry_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_entity_geometry_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_geometry_set_static_delegate)});
      if (efl_gfx_entity_visible_get_static_delegate == null)
      efl_gfx_entity_visible_get_static_delegate = new efl_gfx_entity_visible_get_delegate(visible_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_entity_visible_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_visible_get_static_delegate)});
      if (efl_gfx_entity_visible_set_static_delegate == null)
      efl_gfx_entity_visible_set_static_delegate = new efl_gfx_entity_visible_set_delegate(visible_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_entity_visible_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_visible_set_static_delegate)});
      if (efl_gfx_entity_scale_get_static_delegate == null)
      efl_gfx_entity_scale_get_static_delegate = new efl_gfx_entity_scale_get_delegate(scale_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_entity_scale_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_scale_get_static_delegate)});
      if (efl_gfx_entity_scale_set_static_delegate == null)
      efl_gfx_entity_scale_set_static_delegate = new efl_gfx_entity_scale_set_delegate(scale_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_entity_scale_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_scale_set_static_delegate)});
      if (efl_gfx_hint_aspect_get_static_delegate == null)
      efl_gfx_hint_aspect_get_static_delegate = new efl_gfx_hint_aspect_get_delegate(hint_aspect_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_hint_aspect_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_aspect_get_static_delegate)});
      if (efl_gfx_hint_aspect_set_static_delegate == null)
      efl_gfx_hint_aspect_set_static_delegate = new efl_gfx_hint_aspect_set_delegate(hint_aspect_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_hint_aspect_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_aspect_set_static_delegate)});
      if (efl_gfx_hint_size_max_get_static_delegate == null)
      efl_gfx_hint_size_max_get_static_delegate = new efl_gfx_hint_size_max_get_delegate(hint_size_max_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_hint_size_max_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_size_max_get_static_delegate)});
      if (efl_gfx_hint_size_max_set_static_delegate == null)
      efl_gfx_hint_size_max_set_static_delegate = new efl_gfx_hint_size_max_set_delegate(hint_size_max_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_hint_size_max_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_size_max_set_static_delegate)});
      if (efl_gfx_hint_size_min_get_static_delegate == null)
      efl_gfx_hint_size_min_get_static_delegate = new efl_gfx_hint_size_min_get_delegate(hint_size_min_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_hint_size_min_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_size_min_get_static_delegate)});
      if (efl_gfx_hint_size_min_set_static_delegate == null)
      efl_gfx_hint_size_min_set_static_delegate = new efl_gfx_hint_size_min_set_delegate(hint_size_min_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_hint_size_min_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_size_min_set_static_delegate)});
      if (efl_gfx_hint_size_restricted_min_get_static_delegate == null)
      efl_gfx_hint_size_restricted_min_get_static_delegate = new efl_gfx_hint_size_restricted_min_get_delegate(hint_size_restricted_min_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_hint_size_restricted_min_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_size_restricted_min_get_static_delegate)});
      if (efl_gfx_hint_size_restricted_min_set_static_delegate == null)
      efl_gfx_hint_size_restricted_min_set_static_delegate = new efl_gfx_hint_size_restricted_min_set_delegate(hint_size_restricted_min_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_hint_size_restricted_min_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_size_restricted_min_set_static_delegate)});
      if (efl_gfx_hint_size_combined_min_get_static_delegate == null)
      efl_gfx_hint_size_combined_min_get_static_delegate = new efl_gfx_hint_size_combined_min_get_delegate(hint_size_combined_min_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_hint_size_combined_min_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_size_combined_min_get_static_delegate)});
      if (efl_gfx_hint_margin_get_static_delegate == null)
      efl_gfx_hint_margin_get_static_delegate = new efl_gfx_hint_margin_get_delegate(hint_margin_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_hint_margin_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_margin_get_static_delegate)});
      if (efl_gfx_hint_margin_set_static_delegate == null)
      efl_gfx_hint_margin_set_static_delegate = new efl_gfx_hint_margin_set_delegate(hint_margin_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_hint_margin_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_margin_set_static_delegate)});
      if (efl_gfx_hint_weight_get_static_delegate == null)
      efl_gfx_hint_weight_get_static_delegate = new efl_gfx_hint_weight_get_delegate(hint_weight_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_hint_weight_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_weight_get_static_delegate)});
      if (efl_gfx_hint_weight_set_static_delegate == null)
      efl_gfx_hint_weight_set_static_delegate = new efl_gfx_hint_weight_set_delegate(hint_weight_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_hint_weight_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_weight_set_static_delegate)});
      if (efl_gfx_hint_align_get_static_delegate == null)
      efl_gfx_hint_align_get_static_delegate = new efl_gfx_hint_align_get_delegate(hint_align_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_hint_align_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_align_get_static_delegate)});
      if (efl_gfx_hint_align_set_static_delegate == null)
      efl_gfx_hint_align_set_static_delegate = new efl_gfx_hint_align_set_delegate(hint_align_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_hint_align_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_align_set_static_delegate)});
      if (efl_gfx_hint_fill_get_static_delegate == null)
      efl_gfx_hint_fill_get_static_delegate = new efl_gfx_hint_fill_get_delegate(hint_fill_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_hint_fill_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_fill_get_static_delegate)});
      if (efl_gfx_hint_fill_set_static_delegate == null)
      efl_gfx_hint_fill_set_static_delegate = new efl_gfx_hint_fill_set_delegate(hint_fill_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_hint_fill_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_fill_set_static_delegate)});
      if (efl_gfx_mapping_point_count_get_static_delegate == null)
      efl_gfx_mapping_point_count_get_static_delegate = new efl_gfx_mapping_point_count_get_delegate(mapping_point_count_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_mapping_point_count_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_point_count_get_static_delegate)});
      if (efl_gfx_mapping_point_count_set_static_delegate == null)
      efl_gfx_mapping_point_count_set_static_delegate = new efl_gfx_mapping_point_count_set_delegate(mapping_point_count_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_mapping_point_count_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_point_count_set_static_delegate)});
      if (efl_gfx_mapping_clockwise_get_static_delegate == null)
      efl_gfx_mapping_clockwise_get_static_delegate = new efl_gfx_mapping_clockwise_get_delegate(mapping_clockwise_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_mapping_clockwise_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_clockwise_get_static_delegate)});
      if (efl_gfx_mapping_smooth_get_static_delegate == null)
      efl_gfx_mapping_smooth_get_static_delegate = new efl_gfx_mapping_smooth_get_delegate(mapping_smooth_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_mapping_smooth_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_smooth_get_static_delegate)});
      if (efl_gfx_mapping_smooth_set_static_delegate == null)
      efl_gfx_mapping_smooth_set_static_delegate = new efl_gfx_mapping_smooth_set_delegate(mapping_smooth_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_mapping_smooth_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_smooth_set_static_delegate)});
      if (efl_gfx_mapping_alpha_get_static_delegate == null)
      efl_gfx_mapping_alpha_get_static_delegate = new efl_gfx_mapping_alpha_get_delegate(mapping_alpha_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_mapping_alpha_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_alpha_get_static_delegate)});
      if (efl_gfx_mapping_alpha_set_static_delegate == null)
      efl_gfx_mapping_alpha_set_static_delegate = new efl_gfx_mapping_alpha_set_delegate(mapping_alpha_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_mapping_alpha_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_alpha_set_static_delegate)});
      if (efl_gfx_mapping_coord_absolute_get_static_delegate == null)
      efl_gfx_mapping_coord_absolute_get_static_delegate = new efl_gfx_mapping_coord_absolute_get_delegate(mapping_coord_absolute_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_mapping_coord_absolute_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_coord_absolute_get_static_delegate)});
      if (efl_gfx_mapping_coord_absolute_set_static_delegate == null)
      efl_gfx_mapping_coord_absolute_set_static_delegate = new efl_gfx_mapping_coord_absolute_set_delegate(mapping_coord_absolute_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_mapping_coord_absolute_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_coord_absolute_set_static_delegate)});
      if (efl_gfx_mapping_uv_get_static_delegate == null)
      efl_gfx_mapping_uv_get_static_delegate = new efl_gfx_mapping_uv_get_delegate(mapping_uv_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_mapping_uv_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_uv_get_static_delegate)});
      if (efl_gfx_mapping_uv_set_static_delegate == null)
      efl_gfx_mapping_uv_set_static_delegate = new efl_gfx_mapping_uv_set_delegate(mapping_uv_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_mapping_uv_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_uv_set_static_delegate)});
      if (efl_gfx_mapping_color_get_static_delegate == null)
      efl_gfx_mapping_color_get_static_delegate = new efl_gfx_mapping_color_get_delegate(mapping_color_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_mapping_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_color_get_static_delegate)});
      if (efl_gfx_mapping_color_set_static_delegate == null)
      efl_gfx_mapping_color_set_static_delegate = new efl_gfx_mapping_color_set_delegate(mapping_color_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_mapping_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_color_set_static_delegate)});
      if (efl_gfx_mapping_has_static_delegate == null)
      efl_gfx_mapping_has_static_delegate = new efl_gfx_mapping_has_delegate(mapping_has);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_mapping_has"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_has_static_delegate)});
      if (efl_gfx_mapping_reset_static_delegate == null)
      efl_gfx_mapping_reset_static_delegate = new efl_gfx_mapping_reset_delegate(mapping_reset);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_mapping_reset"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_reset_static_delegate)});
      if (efl_gfx_mapping_translate_static_delegate == null)
      efl_gfx_mapping_translate_static_delegate = new efl_gfx_mapping_translate_delegate(translate);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_mapping_translate"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_translate_static_delegate)});
      if (efl_gfx_mapping_rotate_static_delegate == null)
      efl_gfx_mapping_rotate_static_delegate = new efl_gfx_mapping_rotate_delegate(rotate);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_mapping_rotate"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_rotate_static_delegate)});
      if (efl_gfx_mapping_rotate_3d_static_delegate == null)
      efl_gfx_mapping_rotate_3d_static_delegate = new efl_gfx_mapping_rotate_3d_delegate(rotate_3d);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_mapping_rotate_3d"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_rotate_3d_static_delegate)});
      if (efl_gfx_mapping_rotate_quat_static_delegate == null)
      efl_gfx_mapping_rotate_quat_static_delegate = new efl_gfx_mapping_rotate_quat_delegate(rotate_quat);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_mapping_rotate_quat"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_rotate_quat_static_delegate)});
      if (efl_gfx_mapping_zoom_static_delegate == null)
      efl_gfx_mapping_zoom_static_delegate = new efl_gfx_mapping_zoom_delegate(zoom);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_mapping_zoom"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_zoom_static_delegate)});
      if (efl_gfx_mapping_lighting_3d_static_delegate == null)
      efl_gfx_mapping_lighting_3d_static_delegate = new efl_gfx_mapping_lighting_3d_delegate(lighting_3d);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_mapping_lighting_3d"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_lighting_3d_static_delegate)});
      if (efl_gfx_mapping_perspective_3d_static_delegate == null)
      efl_gfx_mapping_perspective_3d_static_delegate = new efl_gfx_mapping_perspective_3d_delegate(perspective_3d);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_mapping_perspective_3d"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_perspective_3d_static_delegate)});
      if (efl_gfx_mapping_rotate_absolute_static_delegate == null)
      efl_gfx_mapping_rotate_absolute_static_delegate = new efl_gfx_mapping_rotate_absolute_delegate(rotate_absolute);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_mapping_rotate_absolute"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_rotate_absolute_static_delegate)});
      if (efl_gfx_mapping_rotate_3d_absolute_static_delegate == null)
      efl_gfx_mapping_rotate_3d_absolute_static_delegate = new efl_gfx_mapping_rotate_3d_absolute_delegate(rotate_3d_absolute);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_mapping_rotate_3d_absolute"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_rotate_3d_absolute_static_delegate)});
      if (efl_gfx_mapping_rotate_quat_absolute_static_delegate == null)
      efl_gfx_mapping_rotate_quat_absolute_static_delegate = new efl_gfx_mapping_rotate_quat_absolute_delegate(rotate_quat_absolute);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_mapping_rotate_quat_absolute"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_rotate_quat_absolute_static_delegate)});
      if (efl_gfx_mapping_zoom_absolute_static_delegate == null)
      efl_gfx_mapping_zoom_absolute_static_delegate = new efl_gfx_mapping_zoom_absolute_delegate(zoom_absolute);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_mapping_zoom_absolute"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_zoom_absolute_static_delegate)});
      if (efl_gfx_mapping_lighting_3d_absolute_static_delegate == null)
      efl_gfx_mapping_lighting_3d_absolute_static_delegate = new efl_gfx_mapping_lighting_3d_absolute_delegate(lighting_3d_absolute);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_mapping_lighting_3d_absolute"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_lighting_3d_absolute_static_delegate)});
      if (efl_gfx_mapping_perspective_3d_absolute_static_delegate == null)
      efl_gfx_mapping_perspective_3d_absolute_static_delegate = new efl_gfx_mapping_perspective_3d_absolute_delegate(perspective_3d_absolute);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_mapping_perspective_3d_absolute"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_perspective_3d_absolute_static_delegate)});
      if (efl_gfx_stack_layer_get_static_delegate == null)
      efl_gfx_stack_layer_get_static_delegate = new efl_gfx_stack_layer_get_delegate(layer_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_stack_layer_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_stack_layer_get_static_delegate)});
      if (efl_gfx_stack_layer_set_static_delegate == null)
      efl_gfx_stack_layer_set_static_delegate = new efl_gfx_stack_layer_set_delegate(layer_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_stack_layer_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_stack_layer_set_static_delegate)});
      if (efl_gfx_stack_below_get_static_delegate == null)
      efl_gfx_stack_below_get_static_delegate = new efl_gfx_stack_below_get_delegate(below_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_stack_below_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_stack_below_get_static_delegate)});
      if (efl_gfx_stack_above_get_static_delegate == null)
      efl_gfx_stack_above_get_static_delegate = new efl_gfx_stack_above_get_delegate(above_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_stack_above_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_stack_above_get_static_delegate)});
      if (efl_gfx_stack_below_static_delegate == null)
      efl_gfx_stack_below_static_delegate = new efl_gfx_stack_below_delegate(stack_below);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_stack_below"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_stack_below_static_delegate)});
      if (efl_gfx_stack_raise_to_top_static_delegate == null)
      efl_gfx_stack_raise_to_top_static_delegate = new efl_gfx_stack_raise_to_top_delegate(raise_to_top);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_stack_raise_to_top"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_stack_raise_to_top_static_delegate)});
      if (efl_gfx_stack_above_static_delegate == null)
      efl_gfx_stack_above_static_delegate = new efl_gfx_stack_above_delegate(stack_above);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_stack_above"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_stack_above_static_delegate)});
      if (efl_gfx_stack_lower_to_bottom_static_delegate == null)
      efl_gfx_stack_lower_to_bottom_static_delegate = new efl_gfx_stack_lower_to_bottom_delegate(lower_to_bottom);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_stack_lower_to_bottom"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_stack_lower_to_bottom_static_delegate)});
      if (efl_input_seat_event_filter_get_static_delegate == null)
      efl_input_seat_event_filter_get_static_delegate = new efl_input_seat_event_filter_get_delegate(seat_event_filter_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_seat_event_filter_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_seat_event_filter_get_static_delegate)});
      if (efl_input_seat_event_filter_set_static_delegate == null)
      efl_input_seat_event_filter_set_static_delegate = new efl_input_seat_event_filter_set_delegate(seat_event_filter_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_seat_event_filter_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_seat_event_filter_set_static_delegate)});
      if (efl_ui_mirrored_get_static_delegate == null)
      efl_ui_mirrored_get_static_delegate = new efl_ui_mirrored_get_delegate(mirrored_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_mirrored_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_mirrored_get_static_delegate)});
      if (efl_ui_mirrored_set_static_delegate == null)
      efl_ui_mirrored_set_static_delegate = new efl_ui_mirrored_set_delegate(mirrored_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_mirrored_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_mirrored_set_static_delegate)});
      if (efl_ui_mirrored_automatic_get_static_delegate == null)
      efl_ui_mirrored_automatic_get_static_delegate = new efl_ui_mirrored_automatic_get_delegate(mirrored_automatic_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_mirrored_automatic_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_mirrored_automatic_get_static_delegate)});
      if (efl_ui_mirrored_automatic_set_static_delegate == null)
      efl_ui_mirrored_automatic_set_static_delegate = new efl_ui_mirrored_automatic_set_delegate(mirrored_automatic_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_mirrored_automatic_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_mirrored_automatic_set_static_delegate)});
      if (efl_ui_language_get_static_delegate == null)
      efl_ui_language_get_static_delegate = new efl_ui_language_get_delegate(language_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_language_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_language_get_static_delegate)});
      if (efl_ui_language_set_static_delegate == null)
      efl_ui_language_set_static_delegate = new efl_ui_language_set_delegate(language_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_language_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_language_set_static_delegate)});
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


    private delegate Efl.Input.ObjectPointerMode efl_canvas_object_pointer_mode_by_device_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device dev);


    public delegate Efl.Input.ObjectPointerMode efl_canvas_object_pointer_mode_by_device_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device dev);
    public static Efl.Eo.FunctionWrapper<efl_canvas_object_pointer_mode_by_device_get_api_delegate> efl_canvas_object_pointer_mode_by_device_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_object_pointer_mode_by_device_get_api_delegate>(_Module, "efl_canvas_object_pointer_mode_by_device_get");
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
         return efl_canvas_object_pointer_mode_by_device_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  dev);
      }
   }
   private static efl_canvas_object_pointer_mode_by_device_get_delegate efl_canvas_object_pointer_mode_by_device_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_canvas_object_pointer_mode_by_device_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device dev,   Efl.Input.ObjectPointerMode pointer_mode);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_canvas_object_pointer_mode_by_device_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device dev,   Efl.Input.ObjectPointerMode pointer_mode);
    public static Efl.Eo.FunctionWrapper<efl_canvas_object_pointer_mode_by_device_set_api_delegate> efl_canvas_object_pointer_mode_by_device_set_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_object_pointer_mode_by_device_set_api_delegate>(_Module, "efl_canvas_object_pointer_mode_by_device_set");
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
         return efl_canvas_object_pointer_mode_by_device_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  dev,  pointer_mode);
      }
   }
   private static efl_canvas_object_pointer_mode_by_device_set_delegate efl_canvas_object_pointer_mode_by_device_set_static_delegate;


    private delegate Efl.Input.ObjectPointerMode efl_canvas_object_pointer_mode_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Efl.Input.ObjectPointerMode efl_canvas_object_pointer_mode_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_canvas_object_pointer_mode_get_api_delegate> efl_canvas_object_pointer_mode_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_object_pointer_mode_get_api_delegate>(_Module, "efl_canvas_object_pointer_mode_get");
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
         return efl_canvas_object_pointer_mode_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_canvas_object_pointer_mode_get_delegate efl_canvas_object_pointer_mode_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_canvas_object_pointer_mode_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Input.ObjectPointerMode pointer_mode);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_canvas_object_pointer_mode_set_api_delegate(System.IntPtr obj,   Efl.Input.ObjectPointerMode pointer_mode);
    public static Efl.Eo.FunctionWrapper<efl_canvas_object_pointer_mode_set_api_delegate> efl_canvas_object_pointer_mode_set_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_object_pointer_mode_set_api_delegate>(_Module, "efl_canvas_object_pointer_mode_set");
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
         return efl_canvas_object_pointer_mode_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  pointer_mode);
      }
   }
   private static efl_canvas_object_pointer_mode_set_delegate efl_canvas_object_pointer_mode_set_static_delegate;


    private delegate Efl.Gfx.RenderOp efl_canvas_object_render_op_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Efl.Gfx.RenderOp efl_canvas_object_render_op_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_canvas_object_render_op_get_api_delegate> efl_canvas_object_render_op_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_object_render_op_get_api_delegate>(_Module, "efl_canvas_object_render_op_get");
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
         return efl_canvas_object_render_op_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_canvas_object_render_op_get_delegate efl_canvas_object_render_op_get_static_delegate;


    private delegate  void efl_canvas_object_render_op_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Gfx.RenderOp render_op);


    public delegate  void efl_canvas_object_render_op_set_api_delegate(System.IntPtr obj,   Efl.Gfx.RenderOp render_op);
    public static Efl.Eo.FunctionWrapper<efl_canvas_object_render_op_set_api_delegate> efl_canvas_object_render_op_set_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_object_render_op_set_api_delegate>(_Module, "efl_canvas_object_render_op_set");
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
         efl_canvas_object_render_op_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  render_op);
      }
   }
   private static efl_canvas_object_render_op_set_delegate efl_canvas_object_render_op_set_static_delegate;


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))] private delegate Efl.Canvas.Object efl_canvas_object_clipper_get_delegate(System.IntPtr obj, System.IntPtr pd);


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))] public delegate Efl.Canvas.Object efl_canvas_object_clipper_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_canvas_object_clipper_get_api_delegate> efl_canvas_object_clipper_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_object_clipper_get_api_delegate>(_Module, "efl_canvas_object_clipper_get");
    private static Efl.Canvas.Object clipper_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_canvas_object_clipper_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Canvas.Object _ret_var = default(Efl.Canvas.Object);
         try {
            _ret_var = ((Object)wrapper).GetClipper();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_canvas_object_clipper_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_canvas_object_clipper_get_delegate efl_canvas_object_clipper_get_static_delegate;


    private delegate  void efl_canvas_object_clipper_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object clipper);


    public delegate  void efl_canvas_object_clipper_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object clipper);
    public static Efl.Eo.FunctionWrapper<efl_canvas_object_clipper_set_api_delegate> efl_canvas_object_clipper_set_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_object_clipper_set_api_delegate>(_Module, "efl_canvas_object_clipper_set");
    private static  void clipper_set(System.IntPtr obj, System.IntPtr pd,  Efl.Canvas.Object clipper)
   {
      Eina.Log.Debug("function efl_canvas_object_clipper_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Object)wrapper).SetClipper( clipper);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_canvas_object_clipper_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  clipper);
      }
   }
   private static efl_canvas_object_clipper_set_delegate efl_canvas_object_clipper_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_canvas_object_repeat_events_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_canvas_object_repeat_events_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_canvas_object_repeat_events_get_api_delegate> efl_canvas_object_repeat_events_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_object_repeat_events_get_api_delegate>(_Module, "efl_canvas_object_repeat_events_get");
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
         return efl_canvas_object_repeat_events_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_canvas_object_repeat_events_get_delegate efl_canvas_object_repeat_events_get_static_delegate;


    private delegate  void efl_canvas_object_repeat_events_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool repeat);


    public delegate  void efl_canvas_object_repeat_events_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool repeat);
    public static Efl.Eo.FunctionWrapper<efl_canvas_object_repeat_events_set_api_delegate> efl_canvas_object_repeat_events_set_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_object_repeat_events_set_api_delegate>(_Module, "efl_canvas_object_repeat_events_set");
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
         efl_canvas_object_repeat_events_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  repeat);
      }
   }
   private static efl_canvas_object_repeat_events_set_delegate efl_canvas_object_repeat_events_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_canvas_object_key_focus_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_canvas_object_key_focus_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_canvas_object_key_focus_get_api_delegate> efl_canvas_object_key_focus_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_object_key_focus_get_api_delegate>(_Module, "efl_canvas_object_key_focus_get");
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
         return efl_canvas_object_key_focus_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_canvas_object_key_focus_get_delegate efl_canvas_object_key_focus_get_static_delegate;


    private delegate  void efl_canvas_object_key_focus_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool focus);


    public delegate  void efl_canvas_object_key_focus_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool focus);
    public static Efl.Eo.FunctionWrapper<efl_canvas_object_key_focus_set_api_delegate> efl_canvas_object_key_focus_set_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_object_key_focus_set_api_delegate>(_Module, "efl_canvas_object_key_focus_set");
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
         efl_canvas_object_key_focus_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  focus);
      }
   }
   private static efl_canvas_object_key_focus_set_delegate efl_canvas_object_key_focus_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_canvas_object_seat_focus_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_canvas_object_seat_focus_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_canvas_object_seat_focus_get_api_delegate> efl_canvas_object_seat_focus_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_object_seat_focus_get_api_delegate>(_Module, "efl_canvas_object_seat_focus_get");
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
         return efl_canvas_object_seat_focus_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_canvas_object_seat_focus_get_delegate efl_canvas_object_seat_focus_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_canvas_object_precise_is_inside_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_canvas_object_precise_is_inside_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_canvas_object_precise_is_inside_get_api_delegate> efl_canvas_object_precise_is_inside_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_object_precise_is_inside_get_api_delegate>(_Module, "efl_canvas_object_precise_is_inside_get");
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
         return efl_canvas_object_precise_is_inside_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_canvas_object_precise_is_inside_get_delegate efl_canvas_object_precise_is_inside_get_static_delegate;


    private delegate  void efl_canvas_object_precise_is_inside_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool precise);


    public delegate  void efl_canvas_object_precise_is_inside_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool precise);
    public static Efl.Eo.FunctionWrapper<efl_canvas_object_precise_is_inside_set_api_delegate> efl_canvas_object_precise_is_inside_set_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_object_precise_is_inside_set_api_delegate>(_Module, "efl_canvas_object_precise_is_inside_set");
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
         efl_canvas_object_precise_is_inside_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  precise);
      }
   }
   private static efl_canvas_object_precise_is_inside_set_delegate efl_canvas_object_precise_is_inside_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_canvas_object_propagate_events_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_canvas_object_propagate_events_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_canvas_object_propagate_events_get_api_delegate> efl_canvas_object_propagate_events_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_object_propagate_events_get_api_delegate>(_Module, "efl_canvas_object_propagate_events_get");
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
         return efl_canvas_object_propagate_events_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_canvas_object_propagate_events_get_delegate efl_canvas_object_propagate_events_get_static_delegate;


    private delegate  void efl_canvas_object_propagate_events_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool propagate);


    public delegate  void efl_canvas_object_propagate_events_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool propagate);
    public static Efl.Eo.FunctionWrapper<efl_canvas_object_propagate_events_set_api_delegate> efl_canvas_object_propagate_events_set_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_object_propagate_events_set_api_delegate>(_Module, "efl_canvas_object_propagate_events_set");
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
         efl_canvas_object_propagate_events_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  propagate);
      }
   }
   private static efl_canvas_object_propagate_events_set_delegate efl_canvas_object_propagate_events_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_canvas_object_pass_events_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_canvas_object_pass_events_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_canvas_object_pass_events_get_api_delegate> efl_canvas_object_pass_events_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_object_pass_events_get_api_delegate>(_Module, "efl_canvas_object_pass_events_get");
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
         return efl_canvas_object_pass_events_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_canvas_object_pass_events_get_delegate efl_canvas_object_pass_events_get_static_delegate;


    private delegate  void efl_canvas_object_pass_events_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool pass);


    public delegate  void efl_canvas_object_pass_events_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool pass);
    public static Efl.Eo.FunctionWrapper<efl_canvas_object_pass_events_set_api_delegate> efl_canvas_object_pass_events_set_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_object_pass_events_set_api_delegate>(_Module, "efl_canvas_object_pass_events_set");
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
         efl_canvas_object_pass_events_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  pass);
      }
   }
   private static efl_canvas_object_pass_events_set_delegate efl_canvas_object_pass_events_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_canvas_object_anti_alias_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_canvas_object_anti_alias_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_canvas_object_anti_alias_get_api_delegate> efl_canvas_object_anti_alias_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_object_anti_alias_get_api_delegate>(_Module, "efl_canvas_object_anti_alias_get");
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
         return efl_canvas_object_anti_alias_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_canvas_object_anti_alias_get_delegate efl_canvas_object_anti_alias_get_static_delegate;


    private delegate  void efl_canvas_object_anti_alias_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool anti_alias);


    public delegate  void efl_canvas_object_anti_alias_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool anti_alias);
    public static Efl.Eo.FunctionWrapper<efl_canvas_object_anti_alias_set_api_delegate> efl_canvas_object_anti_alias_set_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_object_anti_alias_set_api_delegate>(_Module, "efl_canvas_object_anti_alias_set");
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
         efl_canvas_object_anti_alias_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  anti_alias);
      }
   }
   private static efl_canvas_object_anti_alias_set_delegate efl_canvas_object_anti_alias_set_static_delegate;


    private delegate  System.IntPtr efl_canvas_object_clipped_objects_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  System.IntPtr efl_canvas_object_clipped_objects_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_canvas_object_clipped_objects_get_api_delegate> efl_canvas_object_clipped_objects_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_object_clipped_objects_get_api_delegate>(_Module, "efl_canvas_object_clipped_objects_get");
    private static  System.IntPtr clipped_objects_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_canvas_object_clipped_objects_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Iterator<Efl.Canvas.Object> _ret_var = default(Eina.Iterator<Efl.Canvas.Object>);
         try {
            _ret_var = ((Object)wrapper).GetClippedObjects();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var.Handle;
      } else {
         return efl_canvas_object_clipped_objects_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_canvas_object_clipped_objects_get_delegate efl_canvas_object_clipped_objects_get_static_delegate;


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))] private delegate Efl.Canvas.Object efl_canvas_object_render_parent_get_delegate(System.IntPtr obj, System.IntPtr pd);


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))] public delegate Efl.Canvas.Object efl_canvas_object_render_parent_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_canvas_object_render_parent_get_api_delegate> efl_canvas_object_render_parent_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_object_render_parent_get_api_delegate>(_Module, "efl_canvas_object_render_parent_get");
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
         return efl_canvas_object_render_parent_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_canvas_object_render_parent_get_delegate efl_canvas_object_render_parent_get_static_delegate;


    private delegate Efl.TextBidirectionalType efl_canvas_object_paragraph_direction_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Efl.TextBidirectionalType efl_canvas_object_paragraph_direction_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_canvas_object_paragraph_direction_get_api_delegate> efl_canvas_object_paragraph_direction_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_object_paragraph_direction_get_api_delegate>(_Module, "efl_canvas_object_paragraph_direction_get");
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
         return efl_canvas_object_paragraph_direction_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_canvas_object_paragraph_direction_get_delegate efl_canvas_object_paragraph_direction_get_static_delegate;


    private delegate  void efl_canvas_object_paragraph_direction_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextBidirectionalType dir);


    public delegate  void efl_canvas_object_paragraph_direction_set_api_delegate(System.IntPtr obj,   Efl.TextBidirectionalType dir);
    public static Efl.Eo.FunctionWrapper<efl_canvas_object_paragraph_direction_set_api_delegate> efl_canvas_object_paragraph_direction_set_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_object_paragraph_direction_set_api_delegate>(_Module, "efl_canvas_object_paragraph_direction_set");
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
         efl_canvas_object_paragraph_direction_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  dir);
      }
   }
   private static efl_canvas_object_paragraph_direction_set_delegate efl_canvas_object_paragraph_direction_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_canvas_object_no_render_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_canvas_object_no_render_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_canvas_object_no_render_get_api_delegate> efl_canvas_object_no_render_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_object_no_render_get_api_delegate>(_Module, "efl_canvas_object_no_render_get");
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
         return efl_canvas_object_no_render_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_canvas_object_no_render_get_delegate efl_canvas_object_no_render_get_static_delegate;


    private delegate  void efl_canvas_object_no_render_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool enable);


    public delegate  void efl_canvas_object_no_render_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool enable);
    public static Efl.Eo.FunctionWrapper<efl_canvas_object_no_render_set_api_delegate> efl_canvas_object_no_render_set_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_object_no_render_set_api_delegate>(_Module, "efl_canvas_object_no_render_set");
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
         efl_canvas_object_no_render_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  enable);
      }
   }
   private static efl_canvas_object_no_render_set_delegate efl_canvas_object_no_render_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_canvas_object_coords_inside_get_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Position2D_StructInternal pos);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_canvas_object_coords_inside_get_api_delegate(System.IntPtr obj,   Eina.Position2D_StructInternal pos);
    public static Efl.Eo.FunctionWrapper<efl_canvas_object_coords_inside_get_api_delegate> efl_canvas_object_coords_inside_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_object_coords_inside_get_api_delegate>(_Module, "efl_canvas_object_coords_inside_get");
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
         return efl_canvas_object_coords_inside_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  pos);
      }
   }
   private static efl_canvas_object_coords_inside_get_delegate efl_canvas_object_coords_inside_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_canvas_object_seat_focus_check_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device seat);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_canvas_object_seat_focus_check_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device seat);
    public static Efl.Eo.FunctionWrapper<efl_canvas_object_seat_focus_check_api_delegate> efl_canvas_object_seat_focus_check_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_object_seat_focus_check_api_delegate>(_Module, "efl_canvas_object_seat_focus_check");
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
         return efl_canvas_object_seat_focus_check_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  seat);
      }
   }
   private static efl_canvas_object_seat_focus_check_delegate efl_canvas_object_seat_focus_check_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_canvas_object_seat_focus_add_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device seat);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_canvas_object_seat_focus_add_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device seat);
    public static Efl.Eo.FunctionWrapper<efl_canvas_object_seat_focus_add_api_delegate> efl_canvas_object_seat_focus_add_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_object_seat_focus_add_api_delegate>(_Module, "efl_canvas_object_seat_focus_add");
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
         return efl_canvas_object_seat_focus_add_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  seat);
      }
   }
   private static efl_canvas_object_seat_focus_add_delegate efl_canvas_object_seat_focus_add_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_canvas_object_seat_focus_del_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device seat);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_canvas_object_seat_focus_del_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device seat);
    public static Efl.Eo.FunctionWrapper<efl_canvas_object_seat_focus_del_api_delegate> efl_canvas_object_seat_focus_del_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_object_seat_focus_del_api_delegate>(_Module, "efl_canvas_object_seat_focus_del");
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
         return efl_canvas_object_seat_focus_del_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  seat);
      }
   }
   private static efl_canvas_object_seat_focus_del_delegate efl_canvas_object_seat_focus_del_static_delegate;


    private delegate  uint efl_canvas_object_clipped_objects_count_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  uint efl_canvas_object_clipped_objects_count_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_canvas_object_clipped_objects_count_api_delegate> efl_canvas_object_clipped_objects_count_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_object_clipped_objects_count_api_delegate>(_Module, "efl_canvas_object_clipped_objects_count");
    private static  uint clipped_objects_count(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_canvas_object_clipped_objects_count was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   uint _ret_var = default( uint);
         try {
            _ret_var = ((Object)wrapper).ClippedObjectsCount();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_canvas_object_clipped_objects_count_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_canvas_object_clipped_objects_count_delegate efl_canvas_object_clipped_objects_count_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_canvas_object_key_grab_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String keyname,   Efl.Input.Modifier modifiers,   Efl.Input.Modifier not_modifiers,  [MarshalAs(UnmanagedType.U1)]  bool exclusive);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_canvas_object_key_grab_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String keyname,   Efl.Input.Modifier modifiers,   Efl.Input.Modifier not_modifiers,  [MarshalAs(UnmanagedType.U1)]  bool exclusive);
    public static Efl.Eo.FunctionWrapper<efl_canvas_object_key_grab_api_delegate> efl_canvas_object_key_grab_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_object_key_grab_api_delegate>(_Module, "efl_canvas_object_key_grab");
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
         return efl_canvas_object_key_grab_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  keyname,  modifiers,  not_modifiers,  exclusive);
      }
   }
   private static efl_canvas_object_key_grab_delegate efl_canvas_object_key_grab_static_delegate;


    private delegate  void efl_canvas_object_key_ungrab_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String keyname,   Efl.Input.Modifier modifiers,   Efl.Input.Modifier not_modifiers);


    public delegate  void efl_canvas_object_key_ungrab_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String keyname,   Efl.Input.Modifier modifiers,   Efl.Input.Modifier not_modifiers);
    public static Efl.Eo.FunctionWrapper<efl_canvas_object_key_ungrab_api_delegate> efl_canvas_object_key_ungrab_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_object_key_ungrab_api_delegate>(_Module, "efl_canvas_object_key_ungrab");
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
         efl_canvas_object_key_ungrab_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  keyname,  modifiers,  not_modifiers);
      }
   }
   private static efl_canvas_object_key_ungrab_delegate efl_canvas_object_key_ungrab_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_canvas_pointer_inside_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device seat);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_canvas_pointer_inside_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device seat);
    public static Efl.Eo.FunctionWrapper<efl_canvas_pointer_inside_get_api_delegate> efl_canvas_pointer_inside_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_pointer_inside_get_api_delegate>(_Module, "efl_canvas_pointer_inside_get");
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
         return efl_canvas_pointer_inside_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  seat);
      }
   }
   private static efl_canvas_pointer_inside_get_delegate efl_canvas_pointer_inside_get_static_delegate;


    private delegate  void efl_gfx_color_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  int r,   out  int g,   out  int b,   out  int a);


    public delegate  void efl_gfx_color_get_api_delegate(System.IntPtr obj,   out  int r,   out  int g,   out  int b,   out  int a);
    public static Efl.Eo.FunctionWrapper<efl_gfx_color_get_api_delegate> efl_gfx_color_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_color_get_api_delegate>(_Module, "efl_gfx_color_get");
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
         efl_gfx_color_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out r,  out g,  out b,  out a);
      }
   }
   private static efl_gfx_color_get_delegate efl_gfx_color_get_static_delegate;


    private delegate  void efl_gfx_color_set_delegate(System.IntPtr obj, System.IntPtr pd,    int r,    int g,    int b,    int a);


    public delegate  void efl_gfx_color_set_api_delegate(System.IntPtr obj,    int r,    int g,    int b,    int a);
    public static Efl.Eo.FunctionWrapper<efl_gfx_color_set_api_delegate> efl_gfx_color_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_color_set_api_delegate>(_Module, "efl_gfx_color_set");
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
         efl_gfx_color_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  r,  g,  b,  a);
      }
   }
   private static efl_gfx_color_set_delegate efl_gfx_color_set_static_delegate;


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate  System.String efl_gfx_color_code_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate  System.String efl_gfx_color_code_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_gfx_color_code_get_api_delegate> efl_gfx_color_code_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_color_code_get_api_delegate>(_Module, "efl_gfx_color_code_get");
    private static  System.String color_code_get(System.IntPtr obj, System.IntPtr pd)
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
      return _ret_var;
      } else {
         return efl_gfx_color_code_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_gfx_color_code_get_delegate efl_gfx_color_code_get_static_delegate;


    private delegate  void efl_gfx_color_code_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String colorcode);


    public delegate  void efl_gfx_color_code_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String colorcode);
    public static Efl.Eo.FunctionWrapper<efl_gfx_color_code_set_api_delegate> efl_gfx_color_code_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_color_code_set_api_delegate>(_Module, "efl_gfx_color_code_set");
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
         efl_gfx_color_code_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  colorcode);
      }
   }
   private static efl_gfx_color_code_set_delegate efl_gfx_color_code_set_static_delegate;


    private delegate Eina.Position2D_StructInternal efl_gfx_entity_position_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Eina.Position2D_StructInternal efl_gfx_entity_position_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_gfx_entity_position_get_api_delegate> efl_gfx_entity_position_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_entity_position_get_api_delegate>(_Module, "efl_gfx_entity_position_get");
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
         return efl_gfx_entity_position_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_gfx_entity_position_get_delegate efl_gfx_entity_position_get_static_delegate;


    private delegate  void efl_gfx_entity_position_set_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Position2D_StructInternal pos);


    public delegate  void efl_gfx_entity_position_set_api_delegate(System.IntPtr obj,   Eina.Position2D_StructInternal pos);
    public static Efl.Eo.FunctionWrapper<efl_gfx_entity_position_set_api_delegate> efl_gfx_entity_position_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_entity_position_set_api_delegate>(_Module, "efl_gfx_entity_position_set");
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
         efl_gfx_entity_position_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  pos);
      }
   }
   private static efl_gfx_entity_position_set_delegate efl_gfx_entity_position_set_static_delegate;


    private delegate Eina.Size2D_StructInternal efl_gfx_entity_size_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Eina.Size2D_StructInternal efl_gfx_entity_size_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_gfx_entity_size_get_api_delegate> efl_gfx_entity_size_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_entity_size_get_api_delegate>(_Module, "efl_gfx_entity_size_get");
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
         return efl_gfx_entity_size_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_gfx_entity_size_get_delegate efl_gfx_entity_size_get_static_delegate;


    private delegate  void efl_gfx_entity_size_set_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Size2D_StructInternal size);


    public delegate  void efl_gfx_entity_size_set_api_delegate(System.IntPtr obj,   Eina.Size2D_StructInternal size);
    public static Efl.Eo.FunctionWrapper<efl_gfx_entity_size_set_api_delegate> efl_gfx_entity_size_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_entity_size_set_api_delegate>(_Module, "efl_gfx_entity_size_set");
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
         efl_gfx_entity_size_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  size);
      }
   }
   private static efl_gfx_entity_size_set_delegate efl_gfx_entity_size_set_static_delegate;


    private delegate Eina.Rect_StructInternal efl_gfx_entity_geometry_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Eina.Rect_StructInternal efl_gfx_entity_geometry_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_gfx_entity_geometry_get_api_delegate> efl_gfx_entity_geometry_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_entity_geometry_get_api_delegate>(_Module, "efl_gfx_entity_geometry_get");
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
         return efl_gfx_entity_geometry_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_gfx_entity_geometry_get_delegate efl_gfx_entity_geometry_get_static_delegate;


    private delegate  void efl_gfx_entity_geometry_set_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Rect_StructInternal rect);


    public delegate  void efl_gfx_entity_geometry_set_api_delegate(System.IntPtr obj,   Eina.Rect_StructInternal rect);
    public static Efl.Eo.FunctionWrapper<efl_gfx_entity_geometry_set_api_delegate> efl_gfx_entity_geometry_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_entity_geometry_set_api_delegate>(_Module, "efl_gfx_entity_geometry_set");
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
         efl_gfx_entity_geometry_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  rect);
      }
   }
   private static efl_gfx_entity_geometry_set_delegate efl_gfx_entity_geometry_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_gfx_entity_visible_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_gfx_entity_visible_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_gfx_entity_visible_get_api_delegate> efl_gfx_entity_visible_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_entity_visible_get_api_delegate>(_Module, "efl_gfx_entity_visible_get");
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
         return efl_gfx_entity_visible_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_gfx_entity_visible_get_delegate efl_gfx_entity_visible_get_static_delegate;


    private delegate  void efl_gfx_entity_visible_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool v);


    public delegate  void efl_gfx_entity_visible_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool v);
    public static Efl.Eo.FunctionWrapper<efl_gfx_entity_visible_set_api_delegate> efl_gfx_entity_visible_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_entity_visible_set_api_delegate>(_Module, "efl_gfx_entity_visible_set");
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
         efl_gfx_entity_visible_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  v);
      }
   }
   private static efl_gfx_entity_visible_set_delegate efl_gfx_entity_visible_set_static_delegate;


    private delegate double efl_gfx_entity_scale_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate double efl_gfx_entity_scale_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_gfx_entity_scale_get_api_delegate> efl_gfx_entity_scale_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_entity_scale_get_api_delegate>(_Module, "efl_gfx_entity_scale_get");
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
         return efl_gfx_entity_scale_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_gfx_entity_scale_get_delegate efl_gfx_entity_scale_get_static_delegate;


    private delegate  void efl_gfx_entity_scale_set_delegate(System.IntPtr obj, System.IntPtr pd,   double scale);


    public delegate  void efl_gfx_entity_scale_set_api_delegate(System.IntPtr obj,   double scale);
    public static Efl.Eo.FunctionWrapper<efl_gfx_entity_scale_set_api_delegate> efl_gfx_entity_scale_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_entity_scale_set_api_delegate>(_Module, "efl_gfx_entity_scale_set");
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
         efl_gfx_entity_scale_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  scale);
      }
   }
   private static efl_gfx_entity_scale_set_delegate efl_gfx_entity_scale_set_static_delegate;


    private delegate  void efl_gfx_hint_aspect_get_delegate(System.IntPtr obj, System.IntPtr pd,   out Efl.Gfx.HintAspect mode,   out Eina.Size2D_StructInternal sz);


    public delegate  void efl_gfx_hint_aspect_get_api_delegate(System.IntPtr obj,   out Efl.Gfx.HintAspect mode,   out Eina.Size2D_StructInternal sz);
    public static Efl.Eo.FunctionWrapper<efl_gfx_hint_aspect_get_api_delegate> efl_gfx_hint_aspect_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_hint_aspect_get_api_delegate>(_Module, "efl_gfx_hint_aspect_get");
    private static  void hint_aspect_get(System.IntPtr obj, System.IntPtr pd,  out Efl.Gfx.HintAspect mode,  out Eina.Size2D_StructInternal sz)
   {
      Eina.Log.Debug("function efl_gfx_hint_aspect_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           mode = default(Efl.Gfx.HintAspect);      Eina.Size2D _out_sz = default(Eina.Size2D);
                     
         try {
            ((Object)wrapper).GetHintAspect( out mode,  out _out_sz);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            sz = Eina.Size2D_StructConversion.ToInternal(_out_sz);
                        } else {
         efl_gfx_hint_aspect_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out mode,  out sz);
      }
   }
   private static efl_gfx_hint_aspect_get_delegate efl_gfx_hint_aspect_get_static_delegate;


    private delegate  void efl_gfx_hint_aspect_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Gfx.HintAspect mode,   Eina.Size2D_StructInternal sz);


    public delegate  void efl_gfx_hint_aspect_set_api_delegate(System.IntPtr obj,   Efl.Gfx.HintAspect mode,   Eina.Size2D_StructInternal sz);
    public static Efl.Eo.FunctionWrapper<efl_gfx_hint_aspect_set_api_delegate> efl_gfx_hint_aspect_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_hint_aspect_set_api_delegate>(_Module, "efl_gfx_hint_aspect_set");
    private static  void hint_aspect_set(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.HintAspect mode,  Eina.Size2D_StructInternal sz)
   {
      Eina.Log.Debug("function efl_gfx_hint_aspect_set was called");
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
         efl_gfx_hint_aspect_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  mode,  sz);
      }
   }
   private static efl_gfx_hint_aspect_set_delegate efl_gfx_hint_aspect_set_static_delegate;


    private delegate Eina.Size2D_StructInternal efl_gfx_hint_size_max_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Eina.Size2D_StructInternal efl_gfx_hint_size_max_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_gfx_hint_size_max_get_api_delegate> efl_gfx_hint_size_max_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_hint_size_max_get_api_delegate>(_Module, "efl_gfx_hint_size_max_get");
    private static Eina.Size2D_StructInternal hint_size_max_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_hint_size_max_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Size2D _ret_var = default(Eina.Size2D);
         try {
            _ret_var = ((Object)wrapper).GetHintSizeMax();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Eina.Size2D_StructConversion.ToInternal(_ret_var);
      } else {
         return efl_gfx_hint_size_max_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_gfx_hint_size_max_get_delegate efl_gfx_hint_size_max_get_static_delegate;


    private delegate  void efl_gfx_hint_size_max_set_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Size2D_StructInternal sz);


    public delegate  void efl_gfx_hint_size_max_set_api_delegate(System.IntPtr obj,   Eina.Size2D_StructInternal sz);
    public static Efl.Eo.FunctionWrapper<efl_gfx_hint_size_max_set_api_delegate> efl_gfx_hint_size_max_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_hint_size_max_set_api_delegate>(_Module, "efl_gfx_hint_size_max_set");
    private static  void hint_size_max_set(System.IntPtr obj, System.IntPtr pd,  Eina.Size2D_StructInternal sz)
   {
      Eina.Log.Debug("function efl_gfx_hint_size_max_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_sz = Eina.Size2D_StructConversion.ToManaged(sz);
                     
         try {
            ((Object)wrapper).SetHintSizeMax( _in_sz);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_hint_size_max_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  sz);
      }
   }
   private static efl_gfx_hint_size_max_set_delegate efl_gfx_hint_size_max_set_static_delegate;


    private delegate Eina.Size2D_StructInternal efl_gfx_hint_size_min_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Eina.Size2D_StructInternal efl_gfx_hint_size_min_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_gfx_hint_size_min_get_api_delegate> efl_gfx_hint_size_min_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_hint_size_min_get_api_delegate>(_Module, "efl_gfx_hint_size_min_get");
    private static Eina.Size2D_StructInternal hint_size_min_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_hint_size_min_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Size2D _ret_var = default(Eina.Size2D);
         try {
            _ret_var = ((Object)wrapper).GetHintSizeMin();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Eina.Size2D_StructConversion.ToInternal(_ret_var);
      } else {
         return efl_gfx_hint_size_min_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_gfx_hint_size_min_get_delegate efl_gfx_hint_size_min_get_static_delegate;


    private delegate  void efl_gfx_hint_size_min_set_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Size2D_StructInternal sz);


    public delegate  void efl_gfx_hint_size_min_set_api_delegate(System.IntPtr obj,   Eina.Size2D_StructInternal sz);
    public static Efl.Eo.FunctionWrapper<efl_gfx_hint_size_min_set_api_delegate> efl_gfx_hint_size_min_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_hint_size_min_set_api_delegate>(_Module, "efl_gfx_hint_size_min_set");
    private static  void hint_size_min_set(System.IntPtr obj, System.IntPtr pd,  Eina.Size2D_StructInternal sz)
   {
      Eina.Log.Debug("function efl_gfx_hint_size_min_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_sz = Eina.Size2D_StructConversion.ToManaged(sz);
                     
         try {
            ((Object)wrapper).SetHintSizeMin( _in_sz);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_hint_size_min_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  sz);
      }
   }
   private static efl_gfx_hint_size_min_set_delegate efl_gfx_hint_size_min_set_static_delegate;


    private delegate Eina.Size2D_StructInternal efl_gfx_hint_size_restricted_min_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Eina.Size2D_StructInternal efl_gfx_hint_size_restricted_min_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_gfx_hint_size_restricted_min_get_api_delegate> efl_gfx_hint_size_restricted_min_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_hint_size_restricted_min_get_api_delegate>(_Module, "efl_gfx_hint_size_restricted_min_get");
    private static Eina.Size2D_StructInternal hint_size_restricted_min_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_hint_size_restricted_min_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Size2D _ret_var = default(Eina.Size2D);
         try {
            _ret_var = ((Object)wrapper).GetHintSizeRestrictedMin();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Eina.Size2D_StructConversion.ToInternal(_ret_var);
      } else {
         return efl_gfx_hint_size_restricted_min_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_gfx_hint_size_restricted_min_get_delegate efl_gfx_hint_size_restricted_min_get_static_delegate;


    private delegate  void efl_gfx_hint_size_restricted_min_set_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Size2D_StructInternal sz);


    public delegate  void efl_gfx_hint_size_restricted_min_set_api_delegate(System.IntPtr obj,   Eina.Size2D_StructInternal sz);
    public static Efl.Eo.FunctionWrapper<efl_gfx_hint_size_restricted_min_set_api_delegate> efl_gfx_hint_size_restricted_min_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_hint_size_restricted_min_set_api_delegate>(_Module, "efl_gfx_hint_size_restricted_min_set");
    private static  void hint_size_restricted_min_set(System.IntPtr obj, System.IntPtr pd,  Eina.Size2D_StructInternal sz)
   {
      Eina.Log.Debug("function efl_gfx_hint_size_restricted_min_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_sz = Eina.Size2D_StructConversion.ToManaged(sz);
                     
         try {
            ((Object)wrapper).SetHintSizeRestrictedMin( _in_sz);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_hint_size_restricted_min_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  sz);
      }
   }
   private static efl_gfx_hint_size_restricted_min_set_delegate efl_gfx_hint_size_restricted_min_set_static_delegate;


    private delegate Eina.Size2D_StructInternal efl_gfx_hint_size_combined_min_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Eina.Size2D_StructInternal efl_gfx_hint_size_combined_min_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_gfx_hint_size_combined_min_get_api_delegate> efl_gfx_hint_size_combined_min_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_hint_size_combined_min_get_api_delegate>(_Module, "efl_gfx_hint_size_combined_min_get");
    private static Eina.Size2D_StructInternal hint_size_combined_min_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_hint_size_combined_min_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Size2D _ret_var = default(Eina.Size2D);
         try {
            _ret_var = ((Object)wrapper).GetHintSizeCombinedMin();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Eina.Size2D_StructConversion.ToInternal(_ret_var);
      } else {
         return efl_gfx_hint_size_combined_min_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_gfx_hint_size_combined_min_get_delegate efl_gfx_hint_size_combined_min_get_static_delegate;


    private delegate  void efl_gfx_hint_margin_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  int l,   out  int r,   out  int t,   out  int b);


    public delegate  void efl_gfx_hint_margin_get_api_delegate(System.IntPtr obj,   out  int l,   out  int r,   out  int t,   out  int b);
    public static Efl.Eo.FunctionWrapper<efl_gfx_hint_margin_get_api_delegate> efl_gfx_hint_margin_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_hint_margin_get_api_delegate>(_Module, "efl_gfx_hint_margin_get");
    private static  void hint_margin_get(System.IntPtr obj, System.IntPtr pd,  out  int l,  out  int r,  out  int t,  out  int b)
   {
      Eina.Log.Debug("function efl_gfx_hint_margin_get was called");
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
         efl_gfx_hint_margin_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out l,  out r,  out t,  out b);
      }
   }
   private static efl_gfx_hint_margin_get_delegate efl_gfx_hint_margin_get_static_delegate;


    private delegate  void efl_gfx_hint_margin_set_delegate(System.IntPtr obj, System.IntPtr pd,    int l,    int r,    int t,    int b);


    public delegate  void efl_gfx_hint_margin_set_api_delegate(System.IntPtr obj,    int l,    int r,    int t,    int b);
    public static Efl.Eo.FunctionWrapper<efl_gfx_hint_margin_set_api_delegate> efl_gfx_hint_margin_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_hint_margin_set_api_delegate>(_Module, "efl_gfx_hint_margin_set");
    private static  void hint_margin_set(System.IntPtr obj, System.IntPtr pd,   int l,   int r,   int t,   int b)
   {
      Eina.Log.Debug("function efl_gfx_hint_margin_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                          
         try {
            ((Object)wrapper).SetHintMargin( l,  r,  t,  b);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_gfx_hint_margin_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  l,  r,  t,  b);
      }
   }
   private static efl_gfx_hint_margin_set_delegate efl_gfx_hint_margin_set_static_delegate;


    private delegate  void efl_gfx_hint_weight_get_delegate(System.IntPtr obj, System.IntPtr pd,   out double x,   out double y);


    public delegate  void efl_gfx_hint_weight_get_api_delegate(System.IntPtr obj,   out double x,   out double y);
    public static Efl.Eo.FunctionWrapper<efl_gfx_hint_weight_get_api_delegate> efl_gfx_hint_weight_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_hint_weight_get_api_delegate>(_Module, "efl_gfx_hint_weight_get");
    private static  void hint_weight_get(System.IntPtr obj, System.IntPtr pd,  out double x,  out double y)
   {
      Eina.Log.Debug("function efl_gfx_hint_weight_get was called");
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
         efl_gfx_hint_weight_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out x,  out y);
      }
   }
   private static efl_gfx_hint_weight_get_delegate efl_gfx_hint_weight_get_static_delegate;


    private delegate  void efl_gfx_hint_weight_set_delegate(System.IntPtr obj, System.IntPtr pd,   double x,   double y);


    public delegate  void efl_gfx_hint_weight_set_api_delegate(System.IntPtr obj,   double x,   double y);
    public static Efl.Eo.FunctionWrapper<efl_gfx_hint_weight_set_api_delegate> efl_gfx_hint_weight_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_hint_weight_set_api_delegate>(_Module, "efl_gfx_hint_weight_set");
    private static  void hint_weight_set(System.IntPtr obj, System.IntPtr pd,  double x,  double y)
   {
      Eina.Log.Debug("function efl_gfx_hint_weight_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((Object)wrapper).SetHintWeight( x,  y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_gfx_hint_weight_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  x,  y);
      }
   }
   private static efl_gfx_hint_weight_set_delegate efl_gfx_hint_weight_set_static_delegate;


    private delegate  void efl_gfx_hint_align_get_delegate(System.IntPtr obj, System.IntPtr pd,   out double x,   out double y);


    public delegate  void efl_gfx_hint_align_get_api_delegate(System.IntPtr obj,   out double x,   out double y);
    public static Efl.Eo.FunctionWrapper<efl_gfx_hint_align_get_api_delegate> efl_gfx_hint_align_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_hint_align_get_api_delegate>(_Module, "efl_gfx_hint_align_get");
    private static  void hint_align_get(System.IntPtr obj, System.IntPtr pd,  out double x,  out double y)
   {
      Eina.Log.Debug("function efl_gfx_hint_align_get was called");
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
         efl_gfx_hint_align_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out x,  out y);
      }
   }
   private static efl_gfx_hint_align_get_delegate efl_gfx_hint_align_get_static_delegate;


    private delegate  void efl_gfx_hint_align_set_delegate(System.IntPtr obj, System.IntPtr pd,   double x,   double y);


    public delegate  void efl_gfx_hint_align_set_api_delegate(System.IntPtr obj,   double x,   double y);
    public static Efl.Eo.FunctionWrapper<efl_gfx_hint_align_set_api_delegate> efl_gfx_hint_align_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_hint_align_set_api_delegate>(_Module, "efl_gfx_hint_align_set");
    private static  void hint_align_set(System.IntPtr obj, System.IntPtr pd,  double x,  double y)
   {
      Eina.Log.Debug("function efl_gfx_hint_align_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((Object)wrapper).SetHintAlign( x,  y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_gfx_hint_align_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  x,  y);
      }
   }
   private static efl_gfx_hint_align_set_delegate efl_gfx_hint_align_set_static_delegate;


    private delegate  void efl_gfx_hint_fill_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  out bool x,  [MarshalAs(UnmanagedType.U1)]  out bool y);


    public delegate  void efl_gfx_hint_fill_get_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  out bool x,  [MarshalAs(UnmanagedType.U1)]  out bool y);
    public static Efl.Eo.FunctionWrapper<efl_gfx_hint_fill_get_api_delegate> efl_gfx_hint_fill_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_hint_fill_get_api_delegate>(_Module, "efl_gfx_hint_fill_get");
    private static  void hint_fill_get(System.IntPtr obj, System.IntPtr pd,  out bool x,  out bool y)
   {
      Eina.Log.Debug("function efl_gfx_hint_fill_get was called");
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
         efl_gfx_hint_fill_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out x,  out y);
      }
   }
   private static efl_gfx_hint_fill_get_delegate efl_gfx_hint_fill_get_static_delegate;


    private delegate  void efl_gfx_hint_fill_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool x,  [MarshalAs(UnmanagedType.U1)]  bool y);


    public delegate  void efl_gfx_hint_fill_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool x,  [MarshalAs(UnmanagedType.U1)]  bool y);
    public static Efl.Eo.FunctionWrapper<efl_gfx_hint_fill_set_api_delegate> efl_gfx_hint_fill_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_hint_fill_set_api_delegate>(_Module, "efl_gfx_hint_fill_set");
    private static  void hint_fill_set(System.IntPtr obj, System.IntPtr pd,  bool x,  bool y)
   {
      Eina.Log.Debug("function efl_gfx_hint_fill_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((Object)wrapper).SetHintFill( x,  y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_gfx_hint_fill_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  x,  y);
      }
   }
   private static efl_gfx_hint_fill_set_delegate efl_gfx_hint_fill_set_static_delegate;


    private delegate  int efl_gfx_mapping_point_count_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  int efl_gfx_mapping_point_count_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_point_count_get_api_delegate> efl_gfx_mapping_point_count_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_point_count_get_api_delegate>(_Module, "efl_gfx_mapping_point_count_get");
    private static  int mapping_point_count_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_mapping_point_count_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   int _ret_var = default( int);
         try {
            _ret_var = ((Object)wrapper).GetMappingPointCount();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_mapping_point_count_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_gfx_mapping_point_count_get_delegate efl_gfx_mapping_point_count_get_static_delegate;


    private delegate  void efl_gfx_mapping_point_count_set_delegate(System.IntPtr obj, System.IntPtr pd,    int count);


    public delegate  void efl_gfx_mapping_point_count_set_api_delegate(System.IntPtr obj,    int count);
    public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_point_count_set_api_delegate> efl_gfx_mapping_point_count_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_point_count_set_api_delegate>(_Module, "efl_gfx_mapping_point_count_set");
    private static  void mapping_point_count_set(System.IntPtr obj, System.IntPtr pd,   int count)
   {
      Eina.Log.Debug("function efl_gfx_mapping_point_count_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Object)wrapper).SetMappingPointCount( count);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_mapping_point_count_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  count);
      }
   }
   private static efl_gfx_mapping_point_count_set_delegate efl_gfx_mapping_point_count_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_gfx_mapping_clockwise_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_gfx_mapping_clockwise_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_clockwise_get_api_delegate> efl_gfx_mapping_clockwise_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_clockwise_get_api_delegate>(_Module, "efl_gfx_mapping_clockwise_get");
    private static bool mapping_clockwise_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_mapping_clockwise_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Object)wrapper).GetMappingClockwise();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_mapping_clockwise_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_gfx_mapping_clockwise_get_delegate efl_gfx_mapping_clockwise_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_gfx_mapping_smooth_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_gfx_mapping_smooth_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_smooth_get_api_delegate> efl_gfx_mapping_smooth_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_smooth_get_api_delegate>(_Module, "efl_gfx_mapping_smooth_get");
    private static bool mapping_smooth_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_mapping_smooth_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Object)wrapper).GetMappingSmooth();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_mapping_smooth_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_gfx_mapping_smooth_get_delegate efl_gfx_mapping_smooth_get_static_delegate;


    private delegate  void efl_gfx_mapping_smooth_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool smooth);


    public delegate  void efl_gfx_mapping_smooth_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool smooth);
    public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_smooth_set_api_delegate> efl_gfx_mapping_smooth_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_smooth_set_api_delegate>(_Module, "efl_gfx_mapping_smooth_set");
    private static  void mapping_smooth_set(System.IntPtr obj, System.IntPtr pd,  bool smooth)
   {
      Eina.Log.Debug("function efl_gfx_mapping_smooth_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Object)wrapper).SetMappingSmooth( smooth);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_mapping_smooth_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  smooth);
      }
   }
   private static efl_gfx_mapping_smooth_set_delegate efl_gfx_mapping_smooth_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_gfx_mapping_alpha_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_gfx_mapping_alpha_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_alpha_get_api_delegate> efl_gfx_mapping_alpha_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_alpha_get_api_delegate>(_Module, "efl_gfx_mapping_alpha_get");
    private static bool mapping_alpha_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_mapping_alpha_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Object)wrapper).GetMappingAlpha();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_mapping_alpha_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_gfx_mapping_alpha_get_delegate efl_gfx_mapping_alpha_get_static_delegate;


    private delegate  void efl_gfx_mapping_alpha_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool alpha);


    public delegate  void efl_gfx_mapping_alpha_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool alpha);
    public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_alpha_set_api_delegate> efl_gfx_mapping_alpha_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_alpha_set_api_delegate>(_Module, "efl_gfx_mapping_alpha_set");
    private static  void mapping_alpha_set(System.IntPtr obj, System.IntPtr pd,  bool alpha)
   {
      Eina.Log.Debug("function efl_gfx_mapping_alpha_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Object)wrapper).SetMappingAlpha( alpha);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_mapping_alpha_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  alpha);
      }
   }
   private static efl_gfx_mapping_alpha_set_delegate efl_gfx_mapping_alpha_set_static_delegate;


    private delegate  void efl_gfx_mapping_coord_absolute_get_delegate(System.IntPtr obj, System.IntPtr pd,    int idx,   out double x,   out double y,   out double z);


    public delegate  void efl_gfx_mapping_coord_absolute_get_api_delegate(System.IntPtr obj,    int idx,   out double x,   out double y,   out double z);
    public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_coord_absolute_get_api_delegate> efl_gfx_mapping_coord_absolute_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_coord_absolute_get_api_delegate>(_Module, "efl_gfx_mapping_coord_absolute_get");
    private static  void mapping_coord_absolute_get(System.IntPtr obj, System.IntPtr pd,   int idx,  out double x,  out double y,  out double z)
   {
      Eina.Log.Debug("function efl_gfx_mapping_coord_absolute_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                             x = default(double);      y = default(double);      z = default(double);                                 
         try {
            ((Object)wrapper).GetMappingCoordAbsolute( idx,  out x,  out y,  out z);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_gfx_mapping_coord_absolute_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  idx,  out x,  out y,  out z);
      }
   }
   private static efl_gfx_mapping_coord_absolute_get_delegate efl_gfx_mapping_coord_absolute_get_static_delegate;


    private delegate  void efl_gfx_mapping_coord_absolute_set_delegate(System.IntPtr obj, System.IntPtr pd,    int idx,   double x,   double y,   double z);


    public delegate  void efl_gfx_mapping_coord_absolute_set_api_delegate(System.IntPtr obj,    int idx,   double x,   double y,   double z);
    public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_coord_absolute_set_api_delegate> efl_gfx_mapping_coord_absolute_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_coord_absolute_set_api_delegate>(_Module, "efl_gfx_mapping_coord_absolute_set");
    private static  void mapping_coord_absolute_set(System.IntPtr obj, System.IntPtr pd,   int idx,  double x,  double y,  double z)
   {
      Eina.Log.Debug("function efl_gfx_mapping_coord_absolute_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                          
         try {
            ((Object)wrapper).SetMappingCoordAbsolute( idx,  x,  y,  z);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_gfx_mapping_coord_absolute_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  idx,  x,  y,  z);
      }
   }
   private static efl_gfx_mapping_coord_absolute_set_delegate efl_gfx_mapping_coord_absolute_set_static_delegate;


    private delegate  void efl_gfx_mapping_uv_get_delegate(System.IntPtr obj, System.IntPtr pd,    int idx,   out double u,   out double v);


    public delegate  void efl_gfx_mapping_uv_get_api_delegate(System.IntPtr obj,    int idx,   out double u,   out double v);
    public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_uv_get_api_delegate> efl_gfx_mapping_uv_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_uv_get_api_delegate>(_Module, "efl_gfx_mapping_uv_get");
    private static  void mapping_uv_get(System.IntPtr obj, System.IntPtr pd,   int idx,  out double u,  out double v)
   {
      Eina.Log.Debug("function efl_gfx_mapping_uv_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                       u = default(double);      v = default(double);                           
         try {
            ((Object)wrapper).GetMappingUv( idx,  out u,  out v);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                } else {
         efl_gfx_mapping_uv_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  idx,  out u,  out v);
      }
   }
   private static efl_gfx_mapping_uv_get_delegate efl_gfx_mapping_uv_get_static_delegate;


    private delegate  void efl_gfx_mapping_uv_set_delegate(System.IntPtr obj, System.IntPtr pd,    int idx,   double u,   double v);


    public delegate  void efl_gfx_mapping_uv_set_api_delegate(System.IntPtr obj,    int idx,   double u,   double v);
    public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_uv_set_api_delegate> efl_gfx_mapping_uv_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_uv_set_api_delegate>(_Module, "efl_gfx_mapping_uv_set");
    private static  void mapping_uv_set(System.IntPtr obj, System.IntPtr pd,   int idx,  double u,  double v)
   {
      Eina.Log.Debug("function efl_gfx_mapping_uv_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                        
         try {
            ((Object)wrapper).SetMappingUv( idx,  u,  v);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                } else {
         efl_gfx_mapping_uv_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  idx,  u,  v);
      }
   }
   private static efl_gfx_mapping_uv_set_delegate efl_gfx_mapping_uv_set_static_delegate;


    private delegate  void efl_gfx_mapping_color_get_delegate(System.IntPtr obj, System.IntPtr pd,    int idx,   out  int r,   out  int g,   out  int b,   out  int a);


    public delegate  void efl_gfx_mapping_color_get_api_delegate(System.IntPtr obj,    int idx,   out  int r,   out  int g,   out  int b,   out  int a);
    public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_color_get_api_delegate> efl_gfx_mapping_color_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_color_get_api_delegate>(_Module, "efl_gfx_mapping_color_get");
    private static  void mapping_color_get(System.IntPtr obj, System.IntPtr pd,   int idx,  out  int r,  out  int g,  out  int b,  out  int a)
   {
      Eina.Log.Debug("function efl_gfx_mapping_color_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                   r = default( int);      g = default( int);      b = default( int);      a = default( int);                                       
         try {
            ((Object)wrapper).GetMappingColor( idx,  out r,  out g,  out b,  out a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                        } else {
         efl_gfx_mapping_color_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  idx,  out r,  out g,  out b,  out a);
      }
   }
   private static efl_gfx_mapping_color_get_delegate efl_gfx_mapping_color_get_static_delegate;


    private delegate  void efl_gfx_mapping_color_set_delegate(System.IntPtr obj, System.IntPtr pd,    int idx,    int r,    int g,    int b,    int a);


    public delegate  void efl_gfx_mapping_color_set_api_delegate(System.IntPtr obj,    int idx,    int r,    int g,    int b,    int a);
    public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_color_set_api_delegate> efl_gfx_mapping_color_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_color_set_api_delegate>(_Module, "efl_gfx_mapping_color_set");
    private static  void mapping_color_set(System.IntPtr obj, System.IntPtr pd,   int idx,   int r,   int g,   int b,   int a)
   {
      Eina.Log.Debug("function efl_gfx_mapping_color_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                                            
         try {
            ((Object)wrapper).SetMappingColor( idx,  r,  g,  b,  a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                        } else {
         efl_gfx_mapping_color_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  idx,  r,  g,  b,  a);
      }
   }
   private static efl_gfx_mapping_color_set_delegate efl_gfx_mapping_color_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_gfx_mapping_has_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_gfx_mapping_has_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_has_api_delegate> efl_gfx_mapping_has_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_has_api_delegate>(_Module, "efl_gfx_mapping_has");
    private static bool mapping_has(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_mapping_has was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Object)wrapper).HasMapping();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_mapping_has_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_gfx_mapping_has_delegate efl_gfx_mapping_has_static_delegate;


    private delegate  void efl_gfx_mapping_reset_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  void efl_gfx_mapping_reset_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_reset_api_delegate> efl_gfx_mapping_reset_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_reset_api_delegate>(_Module, "efl_gfx_mapping_reset");
    private static  void mapping_reset(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_mapping_reset was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Object)wrapper).ResetMapping();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_gfx_mapping_reset_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_gfx_mapping_reset_delegate efl_gfx_mapping_reset_static_delegate;


    private delegate  void efl_gfx_mapping_translate_delegate(System.IntPtr obj, System.IntPtr pd,   double dx,   double dy,   double dz);


    public delegate  void efl_gfx_mapping_translate_api_delegate(System.IntPtr obj,   double dx,   double dy,   double dz);
    public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_translate_api_delegate> efl_gfx_mapping_translate_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_translate_api_delegate>(_Module, "efl_gfx_mapping_translate");
    private static  void translate(System.IntPtr obj, System.IntPtr pd,  double dx,  double dy,  double dz)
   {
      Eina.Log.Debug("function efl_gfx_mapping_translate was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                        
         try {
            ((Object)wrapper).Translate( dx,  dy,  dz);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                } else {
         efl_gfx_mapping_translate_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  dx,  dy,  dz);
      }
   }
   private static efl_gfx_mapping_translate_delegate efl_gfx_mapping_translate_static_delegate;


    private delegate  void efl_gfx_mapping_rotate_delegate(System.IntPtr obj, System.IntPtr pd,   double degrees, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity pivot,   double cx,   double cy);


    public delegate  void efl_gfx_mapping_rotate_api_delegate(System.IntPtr obj,   double degrees, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity pivot,   double cx,   double cy);
    public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_rotate_api_delegate> efl_gfx_mapping_rotate_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_rotate_api_delegate>(_Module, "efl_gfx_mapping_rotate");
    private static  void rotate(System.IntPtr obj, System.IntPtr pd,  double degrees,  Efl.Gfx.Entity pivot,  double cx,  double cy)
   {
      Eina.Log.Debug("function efl_gfx_mapping_rotate was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                          
         try {
            ((Object)wrapper).Rotate( degrees,  pivot,  cx,  cy);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_gfx_mapping_rotate_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  degrees,  pivot,  cx,  cy);
      }
   }
   private static efl_gfx_mapping_rotate_delegate efl_gfx_mapping_rotate_static_delegate;


    private delegate  void efl_gfx_mapping_rotate_3d_delegate(System.IntPtr obj, System.IntPtr pd,   double dx,   double dy,   double dz, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity pivot,   double cx,   double cy,   double cz);


    public delegate  void efl_gfx_mapping_rotate_3d_api_delegate(System.IntPtr obj,   double dx,   double dy,   double dz, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity pivot,   double cx,   double cy,   double cz);
    public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_rotate_3d_api_delegate> efl_gfx_mapping_rotate_3d_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_rotate_3d_api_delegate>(_Module, "efl_gfx_mapping_rotate_3d");
    private static  void rotate_3d(System.IntPtr obj, System.IntPtr pd,  double dx,  double dy,  double dz,  Efl.Gfx.Entity pivot,  double cx,  double cy,  double cz)
   {
      Eina.Log.Debug("function efl_gfx_mapping_rotate_3d was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                                                                                
         try {
            ((Object)wrapper).Rotate3d( dx,  dy,  dz,  pivot,  cx,  cy,  cz);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                                                } else {
         efl_gfx_mapping_rotate_3d_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  dx,  dy,  dz,  pivot,  cx,  cy,  cz);
      }
   }
   private static efl_gfx_mapping_rotate_3d_delegate efl_gfx_mapping_rotate_3d_static_delegate;


    private delegate  void efl_gfx_mapping_rotate_quat_delegate(System.IntPtr obj, System.IntPtr pd,   double qx,   double qy,   double qz,   double qw, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity pivot,   double cx,   double cy,   double cz);


    public delegate  void efl_gfx_mapping_rotate_quat_api_delegate(System.IntPtr obj,   double qx,   double qy,   double qz,   double qw, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity pivot,   double cx,   double cy,   double cz);
    public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_rotate_quat_api_delegate> efl_gfx_mapping_rotate_quat_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_rotate_quat_api_delegate>(_Module, "efl_gfx_mapping_rotate_quat");
    private static  void rotate_quat(System.IntPtr obj, System.IntPtr pd,  double qx,  double qy,  double qz,  double qw,  Efl.Gfx.Entity pivot,  double cx,  double cy,  double cz)
   {
      Eina.Log.Debug("function efl_gfx_mapping_rotate_quat was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                                                                                                  
         try {
            ((Object)wrapper).RotateQuat( qx,  qy,  qz,  qw,  pivot,  cx,  cy,  cz);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                                                            } else {
         efl_gfx_mapping_rotate_quat_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  qx,  qy,  qz,  qw,  pivot,  cx,  cy,  cz);
      }
   }
   private static efl_gfx_mapping_rotate_quat_delegate efl_gfx_mapping_rotate_quat_static_delegate;


    private delegate  void efl_gfx_mapping_zoom_delegate(System.IntPtr obj, System.IntPtr pd,   double zoomx,   double zoomy, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity pivot,   double cx,   double cy);


    public delegate  void efl_gfx_mapping_zoom_api_delegate(System.IntPtr obj,   double zoomx,   double zoomy, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity pivot,   double cx,   double cy);
    public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_zoom_api_delegate> efl_gfx_mapping_zoom_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_zoom_api_delegate>(_Module, "efl_gfx_mapping_zoom");
    private static  void zoom(System.IntPtr obj, System.IntPtr pd,  double zoomx,  double zoomy,  Efl.Gfx.Entity pivot,  double cx,  double cy)
   {
      Eina.Log.Debug("function efl_gfx_mapping_zoom was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                                            
         try {
            ((Object)wrapper).Zoom( zoomx,  zoomy,  pivot,  cx,  cy);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                        } else {
         efl_gfx_mapping_zoom_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  zoomx,  zoomy,  pivot,  cx,  cy);
      }
   }
   private static efl_gfx_mapping_zoom_delegate efl_gfx_mapping_zoom_static_delegate;


    private delegate  void efl_gfx_mapping_lighting_3d_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity pivot,   double lx,   double ly,   double lz,    int lr,    int lg,    int lb,    int ar,    int ag,    int ab);


    public delegate  void efl_gfx_mapping_lighting_3d_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity pivot,   double lx,   double ly,   double lz,    int lr,    int lg,    int lb,    int ar,    int ag,    int ab);
    public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_lighting_3d_api_delegate> efl_gfx_mapping_lighting_3d_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_lighting_3d_api_delegate>(_Module, "efl_gfx_mapping_lighting_3d");
    private static  void lighting_3d(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.Entity pivot,  double lx,  double ly,  double lz,   int lr,   int lg,   int lb,   int ar,   int ag,   int ab)
   {
      Eina.Log.Debug("function efl_gfx_mapping_lighting_3d was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                                                                                                                                      
         try {
            ((Object)wrapper).Lighting3d( pivot,  lx,  ly,  lz,  lr,  lg,  lb,  ar,  ag,  ab);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                                                                                    } else {
         efl_gfx_mapping_lighting_3d_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  pivot,  lx,  ly,  lz,  lr,  lg,  lb,  ar,  ag,  ab);
      }
   }
   private static efl_gfx_mapping_lighting_3d_delegate efl_gfx_mapping_lighting_3d_static_delegate;


    private delegate  void efl_gfx_mapping_perspective_3d_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity pivot,   double px,   double py,   double z0,   double foc);


    public delegate  void efl_gfx_mapping_perspective_3d_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity pivot,   double px,   double py,   double z0,   double foc);
    public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_perspective_3d_api_delegate> efl_gfx_mapping_perspective_3d_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_perspective_3d_api_delegate>(_Module, "efl_gfx_mapping_perspective_3d");
    private static  void perspective_3d(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.Entity pivot,  double px,  double py,  double z0,  double foc)
   {
      Eina.Log.Debug("function efl_gfx_mapping_perspective_3d was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                                            
         try {
            ((Object)wrapper).Perspective3d( pivot,  px,  py,  z0,  foc);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                        } else {
         efl_gfx_mapping_perspective_3d_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  pivot,  px,  py,  z0,  foc);
      }
   }
   private static efl_gfx_mapping_perspective_3d_delegate efl_gfx_mapping_perspective_3d_static_delegate;


    private delegate  void efl_gfx_mapping_rotate_absolute_delegate(System.IntPtr obj, System.IntPtr pd,   double degrees,   double cx,   double cy);


    public delegate  void efl_gfx_mapping_rotate_absolute_api_delegate(System.IntPtr obj,   double degrees,   double cx,   double cy);
    public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_rotate_absolute_api_delegate> efl_gfx_mapping_rotate_absolute_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_rotate_absolute_api_delegate>(_Module, "efl_gfx_mapping_rotate_absolute");
    private static  void rotate_absolute(System.IntPtr obj, System.IntPtr pd,  double degrees,  double cx,  double cy)
   {
      Eina.Log.Debug("function efl_gfx_mapping_rotate_absolute was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                        
         try {
            ((Object)wrapper).RotateAbsolute( degrees,  cx,  cy);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                } else {
         efl_gfx_mapping_rotate_absolute_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  degrees,  cx,  cy);
      }
   }
   private static efl_gfx_mapping_rotate_absolute_delegate efl_gfx_mapping_rotate_absolute_static_delegate;


    private delegate  void efl_gfx_mapping_rotate_3d_absolute_delegate(System.IntPtr obj, System.IntPtr pd,   double dx,   double dy,   double dz,   double cx,   double cy,   double cz);


    public delegate  void efl_gfx_mapping_rotate_3d_absolute_api_delegate(System.IntPtr obj,   double dx,   double dy,   double dz,   double cx,   double cy,   double cz);
    public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_rotate_3d_absolute_api_delegate> efl_gfx_mapping_rotate_3d_absolute_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_rotate_3d_absolute_api_delegate>(_Module, "efl_gfx_mapping_rotate_3d_absolute");
    private static  void rotate_3d_absolute(System.IntPtr obj, System.IntPtr pd,  double dx,  double dy,  double dz,  double cx,  double cy,  double cz)
   {
      Eina.Log.Debug("function efl_gfx_mapping_rotate_3d_absolute was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                                                              
         try {
            ((Object)wrapper).Rotate3dAbsolute( dx,  dy,  dz,  cx,  cy,  cz);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                                    } else {
         efl_gfx_mapping_rotate_3d_absolute_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  dx,  dy,  dz,  cx,  cy,  cz);
      }
   }
   private static efl_gfx_mapping_rotate_3d_absolute_delegate efl_gfx_mapping_rotate_3d_absolute_static_delegate;


    private delegate  void efl_gfx_mapping_rotate_quat_absolute_delegate(System.IntPtr obj, System.IntPtr pd,   double qx,   double qy,   double qz,   double qw,   double cx,   double cy,   double cz);


    public delegate  void efl_gfx_mapping_rotate_quat_absolute_api_delegate(System.IntPtr obj,   double qx,   double qy,   double qz,   double qw,   double cx,   double cy,   double cz);
    public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_rotate_quat_absolute_api_delegate> efl_gfx_mapping_rotate_quat_absolute_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_rotate_quat_absolute_api_delegate>(_Module, "efl_gfx_mapping_rotate_quat_absolute");
    private static  void rotate_quat_absolute(System.IntPtr obj, System.IntPtr pd,  double qx,  double qy,  double qz,  double qw,  double cx,  double cy,  double cz)
   {
      Eina.Log.Debug("function efl_gfx_mapping_rotate_quat_absolute was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                                                                                
         try {
            ((Object)wrapper).RotateQuatAbsolute( qx,  qy,  qz,  qw,  cx,  cy,  cz);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                                                } else {
         efl_gfx_mapping_rotate_quat_absolute_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  qx,  qy,  qz,  qw,  cx,  cy,  cz);
      }
   }
   private static efl_gfx_mapping_rotate_quat_absolute_delegate efl_gfx_mapping_rotate_quat_absolute_static_delegate;


    private delegate  void efl_gfx_mapping_zoom_absolute_delegate(System.IntPtr obj, System.IntPtr pd,   double zoomx,   double zoomy,   double cx,   double cy);


    public delegate  void efl_gfx_mapping_zoom_absolute_api_delegate(System.IntPtr obj,   double zoomx,   double zoomy,   double cx,   double cy);
    public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_zoom_absolute_api_delegate> efl_gfx_mapping_zoom_absolute_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_zoom_absolute_api_delegate>(_Module, "efl_gfx_mapping_zoom_absolute");
    private static  void zoom_absolute(System.IntPtr obj, System.IntPtr pd,  double zoomx,  double zoomy,  double cx,  double cy)
   {
      Eina.Log.Debug("function efl_gfx_mapping_zoom_absolute was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                          
         try {
            ((Object)wrapper).ZoomAbsolute( zoomx,  zoomy,  cx,  cy);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_gfx_mapping_zoom_absolute_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  zoomx,  zoomy,  cx,  cy);
      }
   }
   private static efl_gfx_mapping_zoom_absolute_delegate efl_gfx_mapping_zoom_absolute_static_delegate;


    private delegate  void efl_gfx_mapping_lighting_3d_absolute_delegate(System.IntPtr obj, System.IntPtr pd,   double lx,   double ly,   double lz,    int lr,    int lg,    int lb,    int ar,    int ag,    int ab);


    public delegate  void efl_gfx_mapping_lighting_3d_absolute_api_delegate(System.IntPtr obj,   double lx,   double ly,   double lz,    int lr,    int lg,    int lb,    int ar,    int ag,    int ab);
    public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_lighting_3d_absolute_api_delegate> efl_gfx_mapping_lighting_3d_absolute_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_lighting_3d_absolute_api_delegate>(_Module, "efl_gfx_mapping_lighting_3d_absolute");
    private static  void lighting_3d_absolute(System.IntPtr obj, System.IntPtr pd,  double lx,  double ly,  double lz,   int lr,   int lg,   int lb,   int ar,   int ag,   int ab)
   {
      Eina.Log.Debug("function efl_gfx_mapping_lighting_3d_absolute was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                                                                                                                    
         try {
            ((Object)wrapper).Lighting3dAbsolute( lx,  ly,  lz,  lr,  lg,  lb,  ar,  ag,  ab);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                                                                        } else {
         efl_gfx_mapping_lighting_3d_absolute_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  lx,  ly,  lz,  lr,  lg,  lb,  ar,  ag,  ab);
      }
   }
   private static efl_gfx_mapping_lighting_3d_absolute_delegate efl_gfx_mapping_lighting_3d_absolute_static_delegate;


    private delegate  void efl_gfx_mapping_perspective_3d_absolute_delegate(System.IntPtr obj, System.IntPtr pd,   double px,   double py,   double z0,   double foc);


    public delegate  void efl_gfx_mapping_perspective_3d_absolute_api_delegate(System.IntPtr obj,   double px,   double py,   double z0,   double foc);
    public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_perspective_3d_absolute_api_delegate> efl_gfx_mapping_perspective_3d_absolute_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_perspective_3d_absolute_api_delegate>(_Module, "efl_gfx_mapping_perspective_3d_absolute");
    private static  void perspective_3d_absolute(System.IntPtr obj, System.IntPtr pd,  double px,  double py,  double z0,  double foc)
   {
      Eina.Log.Debug("function efl_gfx_mapping_perspective_3d_absolute was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                          
         try {
            ((Object)wrapper).Perspective3dAbsolute( px,  py,  z0,  foc);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_gfx_mapping_perspective_3d_absolute_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  px,  py,  z0,  foc);
      }
   }
   private static efl_gfx_mapping_perspective_3d_absolute_delegate efl_gfx_mapping_perspective_3d_absolute_static_delegate;


    private delegate  short efl_gfx_stack_layer_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  short efl_gfx_stack_layer_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_gfx_stack_layer_get_api_delegate> efl_gfx_stack_layer_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_stack_layer_get_api_delegate>(_Module, "efl_gfx_stack_layer_get");
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
         return efl_gfx_stack_layer_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_gfx_stack_layer_get_delegate efl_gfx_stack_layer_get_static_delegate;


    private delegate  void efl_gfx_stack_layer_set_delegate(System.IntPtr obj, System.IntPtr pd,    short l);


    public delegate  void efl_gfx_stack_layer_set_api_delegate(System.IntPtr obj,    short l);
    public static Efl.Eo.FunctionWrapper<efl_gfx_stack_layer_set_api_delegate> efl_gfx_stack_layer_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_stack_layer_set_api_delegate>(_Module, "efl_gfx_stack_layer_set");
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
         efl_gfx_stack_layer_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  l);
      }
   }
   private static efl_gfx_stack_layer_set_delegate efl_gfx_stack_layer_set_static_delegate;


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.StackConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.Gfx.Stack efl_gfx_stack_below_get_delegate(System.IntPtr obj, System.IntPtr pd);


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.StackConcrete, Efl.Eo.NonOwnTag>))] public delegate Efl.Gfx.Stack efl_gfx_stack_below_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_gfx_stack_below_get_api_delegate> efl_gfx_stack_below_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_stack_below_get_api_delegate>(_Module, "efl_gfx_stack_below_get");
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
         return efl_gfx_stack_below_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_gfx_stack_below_get_delegate efl_gfx_stack_below_get_static_delegate;


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.StackConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.Gfx.Stack efl_gfx_stack_above_get_delegate(System.IntPtr obj, System.IntPtr pd);


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.StackConcrete, Efl.Eo.NonOwnTag>))] public delegate Efl.Gfx.Stack efl_gfx_stack_above_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_gfx_stack_above_get_api_delegate> efl_gfx_stack_above_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_stack_above_get_api_delegate>(_Module, "efl_gfx_stack_above_get");
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
         return efl_gfx_stack_above_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_gfx_stack_above_get_delegate efl_gfx_stack_above_get_static_delegate;


    private delegate  void efl_gfx_stack_below_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.StackConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Stack below);


    public delegate  void efl_gfx_stack_below_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.StackConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Stack below);
    public static Efl.Eo.FunctionWrapper<efl_gfx_stack_below_api_delegate> efl_gfx_stack_below_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_stack_below_api_delegate>(_Module, "efl_gfx_stack_below");
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
         efl_gfx_stack_below_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  below);
      }
   }
   private static efl_gfx_stack_below_delegate efl_gfx_stack_below_static_delegate;


    private delegate  void efl_gfx_stack_raise_to_top_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  void efl_gfx_stack_raise_to_top_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_gfx_stack_raise_to_top_api_delegate> efl_gfx_stack_raise_to_top_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_stack_raise_to_top_api_delegate>(_Module, "efl_gfx_stack_raise_to_top");
    private static  void raise_to_top(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_stack_raise_to_top was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Object)wrapper).RaiseToTop();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_gfx_stack_raise_to_top_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_gfx_stack_raise_to_top_delegate efl_gfx_stack_raise_to_top_static_delegate;


    private delegate  void efl_gfx_stack_above_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.StackConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Stack above);


    public delegate  void efl_gfx_stack_above_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.StackConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Stack above);
    public static Efl.Eo.FunctionWrapper<efl_gfx_stack_above_api_delegate> efl_gfx_stack_above_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_stack_above_api_delegate>(_Module, "efl_gfx_stack_above");
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
         efl_gfx_stack_above_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  above);
      }
   }
   private static efl_gfx_stack_above_delegate efl_gfx_stack_above_static_delegate;


    private delegate  void efl_gfx_stack_lower_to_bottom_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  void efl_gfx_stack_lower_to_bottom_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_gfx_stack_lower_to_bottom_api_delegate> efl_gfx_stack_lower_to_bottom_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_stack_lower_to_bottom_api_delegate>(_Module, "efl_gfx_stack_lower_to_bottom");
    private static  void lower_to_bottom(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_stack_lower_to_bottom was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Object)wrapper).LowerToBottom();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_gfx_stack_lower_to_bottom_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_gfx_stack_lower_to_bottom_delegate efl_gfx_stack_lower_to_bottom_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_input_seat_event_filter_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device seat);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_input_seat_event_filter_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device seat);
    public static Efl.Eo.FunctionWrapper<efl_input_seat_event_filter_get_api_delegate> efl_input_seat_event_filter_get_ptr = new Efl.Eo.FunctionWrapper<efl_input_seat_event_filter_get_api_delegate>(_Module, "efl_input_seat_event_filter_get");
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
         return efl_input_seat_event_filter_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  seat);
      }
   }
   private static efl_input_seat_event_filter_get_delegate efl_input_seat_event_filter_get_static_delegate;


    private delegate  void efl_input_seat_event_filter_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device seat,  [MarshalAs(UnmanagedType.U1)]  bool enable);


    public delegate  void efl_input_seat_event_filter_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device seat,  [MarshalAs(UnmanagedType.U1)]  bool enable);
    public static Efl.Eo.FunctionWrapper<efl_input_seat_event_filter_set_api_delegate> efl_input_seat_event_filter_set_ptr = new Efl.Eo.FunctionWrapper<efl_input_seat_event_filter_set_api_delegate>(_Module, "efl_input_seat_event_filter_set");
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
         efl_input_seat_event_filter_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  seat,  enable);
      }
   }
   private static efl_input_seat_event_filter_set_delegate efl_input_seat_event_filter_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_mirrored_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_mirrored_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_mirrored_get_api_delegate> efl_ui_mirrored_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_mirrored_get_api_delegate>(_Module, "efl_ui_mirrored_get");
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
         return efl_ui_mirrored_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_mirrored_get_delegate efl_ui_mirrored_get_static_delegate;


    private delegate  void efl_ui_mirrored_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool rtl);


    public delegate  void efl_ui_mirrored_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool rtl);
    public static Efl.Eo.FunctionWrapper<efl_ui_mirrored_set_api_delegate> efl_ui_mirrored_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_mirrored_set_api_delegate>(_Module, "efl_ui_mirrored_set");
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
         efl_ui_mirrored_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  rtl);
      }
   }
   private static efl_ui_mirrored_set_delegate efl_ui_mirrored_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_mirrored_automatic_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_mirrored_automatic_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_mirrored_automatic_get_api_delegate> efl_ui_mirrored_automatic_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_mirrored_automatic_get_api_delegate>(_Module, "efl_ui_mirrored_automatic_get");
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
         return efl_ui_mirrored_automatic_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_mirrored_automatic_get_delegate efl_ui_mirrored_automatic_get_static_delegate;


    private delegate  void efl_ui_mirrored_automatic_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool automatic);


    public delegate  void efl_ui_mirrored_automatic_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool automatic);
    public static Efl.Eo.FunctionWrapper<efl_ui_mirrored_automatic_set_api_delegate> efl_ui_mirrored_automatic_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_mirrored_automatic_set_api_delegate>(_Module, "efl_ui_mirrored_automatic_set");
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
         efl_ui_mirrored_automatic_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  automatic);
      }
   }
   private static efl_ui_mirrored_automatic_set_delegate efl_ui_mirrored_automatic_set_static_delegate;


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate  System.String efl_ui_language_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate  System.String efl_ui_language_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_language_get_api_delegate> efl_ui_language_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_language_get_api_delegate>(_Module, "efl_ui_language_get");
    private static  System.String language_get(System.IntPtr obj, System.IntPtr pd)
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
      return _ret_var;
      } else {
         return efl_ui_language_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_language_get_delegate efl_ui_language_get_static_delegate;


    private delegate  void efl_ui_language_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String language);


    public delegate  void efl_ui_language_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String language);
    public static Efl.Eo.FunctionWrapper<efl_ui_language_set_api_delegate> efl_ui_language_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_language_set_api_delegate>(_Module, "efl_ui_language_set");
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
         efl_ui_language_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  language);
      }
   }
   private static efl_ui_language_set_delegate efl_ui_language_set_static_delegate;
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
