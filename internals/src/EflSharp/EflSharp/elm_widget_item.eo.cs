#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Elm { namespace Widget { 
/// <summary>Elementary widget item class</summary>
[ItemNativeInherit]
public class Item : Efl.Object, Efl.Eo.IWrapper,Efl.Access.Action,Efl.Access.Component,Efl.Access.Object,Efl.Access.Widget.Action,Efl.Gfx.Entity,Efl.Gfx.Stack
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Elm.Widget.ItemNativeInherit nativeInherit = new Elm.Widget.ItemNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (Item))
            return Elm.Widget.ItemNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
      }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
      elm_widget_item_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   public Item(Efl.Object parent= null
         ) :
      base(elm_widget_item_class_get(), typeof(Item), parent)
   {
      FinishInstantiation();
   }
   ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
   public Item(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
   protected Item(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static Item static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new Item(obj.NativeHandle);
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
private static object PropertyChangedEvtKey = new object();
   /// <summary>Called when property has changed</summary>
   public event EventHandler<Efl.Access.ObjectPropertyChangedEvt_Args> PropertyChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_ACCESS_OBJECT_EVENT_PROPERTY_CHANGED";
            if (add_cpp_event_handler(efl.Libs.Elementary, key, this.evt_PropertyChangedEvt_delegate)) {
               eventHandlers.AddHandler(PropertyChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_ACCESS_OBJECT_EVENT_PROPERTY_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_PropertyChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(PropertyChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event PropertyChangedEvt.</summary>
   public void On_PropertyChangedEvt(Efl.Access.ObjectPropertyChangedEvt_Args e)
   {
      EventHandler<Efl.Access.ObjectPropertyChangedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Access.ObjectPropertyChangedEvt_Args>)eventHandlers[PropertyChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_PropertyChangedEvt_delegate;
   private void on_PropertyChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Access.ObjectPropertyChangedEvt_Args args = new Efl.Access.ObjectPropertyChangedEvt_Args();
      args.arg = Eina.StringConversion.NativeUtf8ToManagedString(evt.Info);
      try {
         On_PropertyChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object ChildrenChangedEvtKey = new object();
   /// <summary>Called when children have changed</summary>
   public event EventHandler<Efl.Access.ObjectChildrenChangedEvt_Args> ChildrenChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_ACCESS_OBJECT_EVENT_CHILDREN_CHANGED";
            if (add_cpp_event_handler(efl.Libs.Elementary, key, this.evt_ChildrenChangedEvt_delegate)) {
               eventHandlers.AddHandler(ChildrenChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_ACCESS_OBJECT_EVENT_CHILDREN_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_ChildrenChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(ChildrenChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ChildrenChangedEvt.</summary>
   public void On_ChildrenChangedEvt(Efl.Access.ObjectChildrenChangedEvt_Args e)
   {
      EventHandler<Efl.Access.ObjectChildrenChangedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Access.ObjectChildrenChangedEvt_Args>)eventHandlers[ChildrenChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ChildrenChangedEvt_delegate;
   private void on_ChildrenChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Access.ObjectChildrenChangedEvt_Args args = new Efl.Access.ObjectChildrenChangedEvt_Args();
      args.arg =  evt.Info;;
      try {
         On_ChildrenChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object StateChangedEvtKey = new object();
   /// <summary>Called when state has changed</summary>
   public event EventHandler<Efl.Access.ObjectStateChangedEvt_Args> StateChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_ACCESS_OBJECT_EVENT_STATE_CHANGED";
            if (add_cpp_event_handler(efl.Libs.Elementary, key, this.evt_StateChangedEvt_delegate)) {
               eventHandlers.AddHandler(StateChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_ACCESS_OBJECT_EVENT_STATE_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_StateChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(StateChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event StateChangedEvt.</summary>
   public void On_StateChangedEvt(Efl.Access.ObjectStateChangedEvt_Args e)
   {
      EventHandler<Efl.Access.ObjectStateChangedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Access.ObjectStateChangedEvt_Args>)eventHandlers[StateChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_StateChangedEvt_delegate;
   private void on_StateChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Access.ObjectStateChangedEvt_Args args = new Efl.Access.ObjectStateChangedEvt_Args();
      args.arg =  evt.Info;;
      try {
         On_StateChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object BoundsChangedEvtKey = new object();
   /// <summary>Called when boundaries have changed</summary>
   public event EventHandler<Efl.Access.ObjectBoundsChangedEvt_Args> BoundsChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_ACCESS_OBJECT_EVENT_BOUNDS_CHANGED";
            if (add_cpp_event_handler(efl.Libs.Elementary, key, this.evt_BoundsChangedEvt_delegate)) {
               eventHandlers.AddHandler(BoundsChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_ACCESS_OBJECT_EVENT_BOUNDS_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_BoundsChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(BoundsChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event BoundsChangedEvt.</summary>
   public void On_BoundsChangedEvt(Efl.Access.ObjectBoundsChangedEvt_Args e)
   {
      EventHandler<Efl.Access.ObjectBoundsChangedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Access.ObjectBoundsChangedEvt_Args>)eventHandlers[BoundsChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_BoundsChangedEvt_delegate;
   private void on_BoundsChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Access.ObjectBoundsChangedEvt_Args args = new Efl.Access.ObjectBoundsChangedEvt_Args();
      args.arg =  evt.Info;;
      try {
         On_BoundsChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object VisibleDataChangedEvtKey = new object();
   /// <summary>Called when visibility has changed</summary>
   public event EventHandler VisibleDataChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_ACCESS_OBJECT_EVENT_VISIBLE_DATA_CHANGED";
            if (add_cpp_event_handler(efl.Libs.Elementary, key, this.evt_VisibleDataChangedEvt_delegate)) {
               eventHandlers.AddHandler(VisibleDataChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_ACCESS_OBJECT_EVENT_VISIBLE_DATA_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_VisibleDataChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(VisibleDataChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event VisibleDataChangedEvt.</summary>
   public void On_VisibleDataChangedEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[VisibleDataChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_VisibleDataChangedEvt_delegate;
   private void on_VisibleDataChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_VisibleDataChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object ActiveDescendantChangedEvtKey = new object();
   /// <summary>Called when active state of descendant has changed</summary>
   public event EventHandler<Efl.Access.ObjectActiveDescendantChangedEvt_Args> ActiveDescendantChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_ACCESS_OBJECT_EVENT_ACTIVE_DESCENDANT_CHANGED";
            if (add_cpp_event_handler(efl.Libs.Elementary, key, this.evt_ActiveDescendantChangedEvt_delegate)) {
               eventHandlers.AddHandler(ActiveDescendantChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_ACCESS_OBJECT_EVENT_ACTIVE_DESCENDANT_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_ActiveDescendantChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(ActiveDescendantChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ActiveDescendantChangedEvt.</summary>
   public void On_ActiveDescendantChangedEvt(Efl.Access.ObjectActiveDescendantChangedEvt_Args e)
   {
      EventHandler<Efl.Access.ObjectActiveDescendantChangedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Access.ObjectActiveDescendantChangedEvt_Args>)eventHandlers[ActiveDescendantChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ActiveDescendantChangedEvt_delegate;
   private void on_ActiveDescendantChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Access.ObjectActiveDescendantChangedEvt_Args args = new Efl.Access.ObjectActiveDescendantChangedEvt_Args();
      args.arg = new Efl.Object(evt.Info);
      try {
         On_ActiveDescendantChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object AddedEvtKey = new object();
   /// <summary>Called when item is added</summary>
   public event EventHandler AddedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_ACCESS_OBJECT_EVENT_ADDED";
            if (add_cpp_event_handler(efl.Libs.Elementary, key, this.evt_AddedEvt_delegate)) {
               eventHandlers.AddHandler(AddedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_ACCESS_OBJECT_EVENT_ADDED";
            if (remove_cpp_event_handler(key, this.evt_AddedEvt_delegate)) { 
               eventHandlers.RemoveHandler(AddedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event AddedEvt.</summary>
   public void On_AddedEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[AddedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_AddedEvt_delegate;
   private void on_AddedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_AddedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object RemovedEvtKey = new object();
   /// <summary>Called when item is removed</summary>
   public event EventHandler RemovedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_ACCESS_OBJECT_EVENT_REMOVED";
            if (add_cpp_event_handler(efl.Libs.Elementary, key, this.evt_RemovedEvt_delegate)) {
               eventHandlers.AddHandler(RemovedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_ACCESS_OBJECT_EVENT_REMOVED";
            if (remove_cpp_event_handler(key, this.evt_RemovedEvt_delegate)) { 
               eventHandlers.RemoveHandler(RemovedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event RemovedEvt.</summary>
   public void On_RemovedEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[RemovedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_RemovedEvt_delegate;
   private void on_RemovedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_RemovedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object MoveOutedEvtKey = new object();
   /// <summary></summary>
   public event EventHandler MoveOutedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_ACCESS_OBJECT_EVENT_MOVE_OUTED";
            if (add_cpp_event_handler(efl.Libs.Elementary, key, this.evt_MoveOutedEvt_delegate)) {
               eventHandlers.AddHandler(MoveOutedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_ACCESS_OBJECT_EVENT_MOVE_OUTED";
            if (remove_cpp_event_handler(key, this.evt_MoveOutedEvt_delegate)) { 
               eventHandlers.RemoveHandler(MoveOutedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event MoveOutedEvt.</summary>
   public void On_MoveOutedEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[MoveOutedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_MoveOutedEvt_delegate;
   private void on_MoveOutedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_MoveOutedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object ReadingStateChangedEvtKey = new object();
   /// <summary></summary>
   public event EventHandler ReadingStateChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_ACCESS_WIDGET_ACTION_EVENT_READING_STATE_CHANGED";
            if (add_cpp_event_handler(efl.Libs.Elementary, key, this.evt_ReadingStateChangedEvt_delegate)) {
               eventHandlers.AddHandler(ReadingStateChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_ACCESS_WIDGET_ACTION_EVENT_READING_STATE_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_ReadingStateChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(ReadingStateChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ReadingStateChangedEvt.</summary>
   public void On_ReadingStateChangedEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[ReadingStateChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ReadingStateChangedEvt_delegate;
   private void on_ReadingStateChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_ReadingStateChangedEvt(args);
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

   protected override void register_event_proxies()
   {
      base.register_event_proxies();
      evt_PropertyChangedEvt_delegate = new Efl.EventCb(on_PropertyChangedEvt_NativeCallback);
      evt_ChildrenChangedEvt_delegate = new Efl.EventCb(on_ChildrenChangedEvt_NativeCallback);
      evt_StateChangedEvt_delegate = new Efl.EventCb(on_StateChangedEvt_NativeCallback);
      evt_BoundsChangedEvt_delegate = new Efl.EventCb(on_BoundsChangedEvt_NativeCallback);
      evt_VisibleDataChangedEvt_delegate = new Efl.EventCb(on_VisibleDataChangedEvt_NativeCallback);
      evt_ActiveDescendantChangedEvt_delegate = new Efl.EventCb(on_ActiveDescendantChangedEvt_NativeCallback);
      evt_AddedEvt_delegate = new Efl.EventCb(on_AddedEvt_NativeCallback);
      evt_RemovedEvt_delegate = new Efl.EventCb(on_RemovedEvt_NativeCallback);
      evt_MoveOutedEvt_delegate = new Efl.EventCb(on_MoveOutedEvt_NativeCallback);
      evt_ReadingStateChangedEvt_delegate = new Efl.EventCb(on_ReadingStateChangedEvt_NativeCallback);
      evt_VisibilityChangedEvt_delegate = new Efl.EventCb(on_VisibilityChangedEvt_NativeCallback);
      evt_PositionChangedEvt_delegate = new Efl.EventCb(on_PositionChangedEvt_NativeCallback);
      evt_SizeChangedEvt_delegate = new Efl.EventCb(on_SizeChangedEvt_NativeCallback);
      evt_StackingChangedEvt_delegate = new Efl.EventCb(on_StackingChangedEvt_NativeCallback);
   }
   /// <summary>Control size restriction state of an object&apos;s tooltip
   /// This function returns whether a tooltip is allowed to expand beyond its parent window&apos;s canvas. It will instead be limited only by the size of the display.</summary>
   /// <returns>If <c>true</c>, size restrictions are disabled</returns>
   virtual public bool GetTooltipWindowMode() {
       var _ret_var = Elm.Widget.ItemNativeInherit.elm_wdg_item_tooltip_window_mode_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Control size restriction state of an object&apos;s tooltip
   /// This function returns whether a tooltip is allowed to expand beyond its parent window&apos;s canvas. It will instead be limited only by the size of the display.</summary>
   /// <param name="disable">If <c>true</c>, size restrictions are disabled</param>
   /// <returns><c>false</c> on failure, <c>true</c> on success</returns>
   virtual public bool SetTooltipWindowMode( bool disable) {
                         var _ret_var = Elm.Widget.ItemNativeInherit.elm_wdg_item_tooltip_window_mode_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), disable);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Control a different style for this item tooltip.
   /// Note: before you set a style you should define a tooltip with <see cref="Elm.Widget.Item.SetTooltipContentCb"/> or <see cref="Elm.Widget.Item.SetTooltipText"/>
   /// 
   /// See: elm_object_tooltip_style_set() for more details.</summary>
   /// <returns>The theme style used/to use (default, transparent, ...)</returns>
   virtual public  System.String GetTooltipStyle() {
       var _ret_var = Elm.Widget.ItemNativeInherit.elm_wdg_item_tooltip_style_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Control a different style for this item tooltip.
   /// Note: before you set a style you should define a tooltip with <see cref="Elm.Widget.Item.SetTooltipContentCb"/> or <see cref="Elm.Widget.Item.SetTooltipText"/>
   /// 
   /// See: elm_object_tooltip_style_set() for more details.</summary>
   /// <param name="style">The theme style used/to use (default, transparent, ...)</param>
   /// <returns></returns>
   virtual public  void SetTooltipStyle(  System.String style) {
                         Elm.Widget.ItemNativeInherit.elm_wdg_item_tooltip_style_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), style);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Control the type of mouse pointer/cursor decoration to be shown, when the mouse pointer is over the given item
   /// This function works analogously as elm_object_cursor_set(), but here the cursor&apos;s changing area is restricted to the item&apos;s area, and not the whole widget&apos;s. Note that that item cursors have precedence over widget cursors, so that a mouse over an item with custom cursor set will always show that cursor.
   /// 
   /// If this function is called twice for an object, a previously set cursor will be unset on the second call.</summary>
   /// <returns>The cursor type&apos;s name</returns>
   virtual public  System.String GetCursor() {
       var _ret_var = Elm.Widget.ItemNativeInherit.elm_wdg_item_cursor_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Control the type of mouse pointer/cursor decoration to be shown, when the mouse pointer is over the given item
   /// This function works analogously as elm_object_cursor_set(), but here the cursor&apos;s changing area is restricted to the item&apos;s area, and not the whole widget&apos;s. Note that that item cursors have precedence over widget cursors, so that a mouse over an item with custom cursor set will always show that cursor.
   /// 
   /// If this function is called twice for an object, a previously set cursor will be unset on the second call.</summary>
   /// <param name="cursor">The cursor type&apos;s name</param>
   /// <returns></returns>
   virtual public  void SetCursor(  System.String cursor) {
                         Elm.Widget.ItemNativeInherit.elm_wdg_item_cursor_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), cursor);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Control a different <c>style</c> for a given custom cursor set for an item.
   /// This function only makes sense when one is using custom mouse cursor decorations defined in a theme file, which can have, given a cursor name/type, alternate styles on it. It works analogously as elm_object_cursor_style_set(), but here applies only to item objects.
   /// 
   /// Warning: Before you set a cursor style you should have defined a custom cursor previously on the item, with <see cref="Elm.Widget.Item.SetCursor"/></summary>
   /// <returns>The theme style to use/in use (e.g. $&quot;default&quot;, $&quot;transparent&quot;, etc)</returns>
   virtual public  System.String GetCursorStyle() {
       var _ret_var = Elm.Widget.ItemNativeInherit.elm_wdg_item_cursor_style_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Control a different <c>style</c> for a given custom cursor set for an item.
   /// This function only makes sense when one is using custom mouse cursor decorations defined in a theme file, which can have, given a cursor name/type, alternate styles on it. It works analogously as elm_object_cursor_style_set(), but here applies only to item objects.
   /// 
   /// Warning: Before you set a cursor style you should have defined a custom cursor previously on the item, with <see cref="Elm.Widget.Item.SetCursor"/></summary>
   /// <param name="style">The theme style to use/in use (e.g. $&quot;default&quot;, $&quot;transparent&quot;, etc)</param>
   /// <returns></returns>
   virtual public  void SetCursorStyle(  System.String style) {
                         Elm.Widget.ItemNativeInherit.elm_wdg_item_cursor_style_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), style);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Control if the (custom)cursor for a given item should be searched in its theme, also, or should only rely on the rendering engine.
   /// Note: This call is of use only if you&apos;ve set a custom cursor for items, with <see cref="Elm.Widget.Item.SetCursor"/>.
   /// 
   /// Note: By default, cursors will only be looked for between those provided by the rendering engine.</summary>
   /// <returns>Use <c>true</c> to have cursors looked for only on those provided by the rendering engine, <c>false</c> to have them searched on the widget&apos;s theme, as well.</returns>
   virtual public bool GetCursorEngineOnly() {
       var _ret_var = Elm.Widget.ItemNativeInherit.elm_wdg_item_cursor_engine_only_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Control if the (custom)cursor for a given item should be searched in its theme, also, or should only rely on the rendering engine.
   /// Note: This call is of use only if you&apos;ve set a custom cursor for items, with <see cref="Elm.Widget.Item.SetCursor"/>.
   /// 
   /// Note: By default, cursors will only be looked for between those provided by the rendering engine.</summary>
   /// <param name="engine_only">Use <c>true</c> to have cursors looked for only on those provided by the rendering engine, <c>false</c> to have them searched on the widget&apos;s theme, as well.</param>
   /// <returns></returns>
   virtual public  void SetCursorEngineOnly( bool engine_only) {
                         Elm.Widget.ItemNativeInherit.elm_wdg_item_cursor_engine_only_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), engine_only);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Control a content of an object item
   /// This sets a new object to an item as a content object. If any object was already set as a content object in the same part, previous object will be deleted automatically.</summary>
   /// <param name="part">The content part name  (NULL for the default content)</param>
   /// <returns>The content of the object item</returns>
   virtual public Efl.Canvas.Object GetPartContent(  System.String part) {
                         var _ret_var = Elm.Widget.ItemNativeInherit.elm_wdg_item_part_content_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), part);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Control a content of an object item
   /// This sets a new object to an item as a content object. If any object was already set as a content object in the same part, previous object will be deleted automatically.</summary>
   /// <param name="part">The content part name  (NULL for the default content)</param>
   /// <param name="content">The content of the object item</param>
   /// <returns></returns>
   virtual public  void SetPartContent(  System.String part,  Efl.Canvas.Object content) {
                                           Elm.Widget.ItemNativeInherit.elm_wdg_item_part_content_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), part,  content);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Control a label of an object item
   /// Note: Elementary object items may have many labels</summary>
   /// <param name="part">The text part name (NULL for the default label)</param>
   /// <returns>Text of the label</returns>
   virtual public  System.String GetPartText(  System.String part) {
                         var _ret_var = Elm.Widget.ItemNativeInherit.elm_wdg_item_part_text_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), part);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Control a label of an object item
   /// Note: Elementary object items may have many labels</summary>
   /// <param name="part">The text part name (NULL for the default label)</param>
   /// <param name="label">Text of the label</param>
   /// <returns></returns>
   virtual public  void SetPartText(  System.String part,   System.String label) {
                                           Elm.Widget.ItemNativeInherit.elm_wdg_item_part_text_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), part,  label);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Get additional text part content</summary>
   /// <param name="part">Part name</param>
   /// <returns>Label name</returns>
   virtual public  System.String GetPartTextCustom(  System.String part) {
                         var _ret_var = Elm.Widget.ItemNativeInherit.elm_wdg_item_part_text_custom_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), part);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Save additional text part content</summary>
   /// <param name="part">Part name</param>
   /// <param name="label">Label name</param>
   /// <returns></returns>
   virtual public  void SetPartTextCustom(  System.String part,   System.String label) {
                                           Elm.Widget.ItemNativeInherit.elm_wdg_item_part_text_custom_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), part,  label);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Control the object item focused
   /// 1.10</summary>
   /// <returns>The focused state</returns>
   virtual public bool GetItemFocus() {
       var _ret_var = Elm.Widget.ItemNativeInherit.elm_wdg_item_focus_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Control the object item focused
   /// 1.10</summary>
   /// <param name="focused">The focused state</param>
   /// <returns></returns>
   virtual public  void SetItemFocus( bool focused) {
                         Elm.Widget.ItemNativeInherit.elm_wdg_item_focus_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), focused);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Control the style of an object item
   /// 1.9</summary>
   /// <returns>The style of object item</returns>
   virtual public  System.String GetStyle() {
       var _ret_var = Elm.Widget.ItemNativeInherit.elm_wdg_item_style_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Control the style of an object item
   /// 1.9</summary>
   /// <param name="style">The style of object item</param>
   /// <returns></returns>
   virtual public  void SetStyle(  System.String style) {
                         Elm.Widget.ItemNativeInherit.elm_wdg_item_style_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), style);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Control the disabled state of a widget item.
   /// Elementary object item can be disabled, in which state they won&apos;t receive input and, in general, will be themed differently from their normal state, usually greyed out. Useful for contexts where you don&apos;t want your users to interact with some of the parts of you interface.
   /// 
   /// This sets the state for the widget item, either disabling it or enabling it back.</summary>
   /// <returns><c>true</c>, if the widget item is disabled, <c>false</c> if it&apos;s enabled (or on errors)</returns>
   virtual public bool GetDisabled() {
       var _ret_var = Elm.Widget.ItemNativeInherit.elm_wdg_item_disabled_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Control the disabled state of a widget item.
   /// Elementary object item can be disabled, in which state they won&apos;t receive input and, in general, will be themed differently from their normal state, usually greyed out. Useful for contexts where you don&apos;t want your users to interact with some of the parts of you interface.
   /// 
   /// This sets the state for the widget item, either disabling it or enabling it back.</summary>
   /// <param name="disable"><c>true</c>, if the widget item is disabled, <c>false</c> if it&apos;s enabled (or on errors)</param>
   /// <returns></returns>
   virtual public  void SetDisabled( bool disable) {
                         Elm.Widget.ItemNativeInherit.elm_wdg_item_disabled_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), disable);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Get highlight order
   /// 1.8</summary>
   /// <returns>List of evas canvas objects</returns>
   virtual public Eina.List<Efl.Canvas.Object> GetAccessOrder() {
       var _ret_var = Elm.Widget.ItemNativeInherit.elm_wdg_item_access_order_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return new Eina.List<Efl.Canvas.Object>(_ret_var, false, false);
 }
   /// <summary>Set highlight order
   /// 1.8</summary>
   /// <param name="objs">Order of objects to pass highlight</param>
   /// <returns></returns>
   virtual public  void SetAccessOrder( Eina.List<Efl.Canvas.Object> objs) {
       var _in_objs = objs.Handle;
objs.Own = false;
                  Elm.Widget.ItemNativeInherit.elm_wdg_item_access_order_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), _in_objs);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Get the widget object&apos;s handle which contains a given item
   /// Note: This returns the widget object itself that an item belongs to. Note: Every elm_object_item supports this API</summary>
   /// <returns>The widget object</returns>
   virtual public Efl.Canvas.Object GetWidget() {
       var _ret_var = Elm.Widget.ItemNativeInherit.elm_wdg_item_widget_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>notify deletion of widget item</summary>
   /// <returns></returns>
   virtual public  void DelPreNotify() {
       Elm.Widget.ItemNativeInherit.elm_wdg_item_pre_notify_del_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }
   /// <summary>Set the text to be shown in a given object item&apos;s tooltips.
   /// Setup the text as tooltip to object. The item can have only one tooltip, so any previous tooltip data - set with this function or <see cref="Elm.Widget.Item.SetTooltipContentCb"/> - is removed.
   /// 
   /// See: elm_object_tooltip_text_set() for more details.</summary>
   /// <param name="text">The text to set in the content.</param>
   /// <returns></returns>
   virtual public  void SetTooltipText(  System.String text) {
                         Elm.Widget.ItemNativeInherit.elm_wdg_item_tooltip_text_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), text);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Set widget item tooltip as a text string</summary>
   /// <param name="text">Tooltip text</param>
   /// <returns></returns>
   virtual public  void SetTooltipTranslatableText(  System.String text) {
                         Elm.Widget.ItemNativeInherit.elm_wdg_item_tooltip_translatable_text_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), text);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Unset tooltip from item.
   /// Remove tooltip from item. The callback provided as del_cb to <see cref="Elm.Widget.Item.SetTooltipContentCb"/> will be called to notify it is not used anymore.
   /// 
   /// See: elm_object_tooltip_unset() for more details. See: <see cref="Elm.Widget.Item.SetTooltipContentCb"/></summary>
   /// <returns></returns>
   virtual public  void UnsetTooltip() {
       Elm.Widget.ItemNativeInherit.elm_wdg_item_tooltip_unset_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }
   /// <summary>Unset any custom mouse pointer/cursor decoration set to be shown, when the mouse pointer is over the given item, thus making it show the default cursor again.
   /// Use this call to undo any custom settings on this item&apos;s cursor decoration, bringing it back to defaults (no custom style set).
   /// 
   /// See: elm_object_cursor_unset() See: <see cref="Elm.Widget.Item.SetCursor"/></summary>
   /// <returns></returns>
   virtual public  void UnsetCursor() {
       Elm.Widget.ItemNativeInherit.elm_wdg_item_cursor_unset_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }
   /// <summary>Unset a content of an object item
   /// Note: Elementary object items may have many contents</summary>
   /// <param name="part">The content part name to unset (NULL for the default content)</param>
   /// <returns>Content object</returns>
   virtual public Efl.Canvas.Object UnsetPartContent(  System.String part) {
                         var _ret_var = Elm.Widget.ItemNativeInherit.elm_wdg_item_part_content_unset_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), part);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Update additional text part content</summary>
   /// <returns></returns>
   virtual public  void UpdatePartTextCustom() {
       Elm.Widget.ItemNativeInherit.elm_wdg_item_part_text_custom_update_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }
   /// <summary>Add a callback for a signal emitted by object item edje.
   /// This function connects a callback function to a signal emitted by the edje object of the object item. Globs can occur in either the emission or source name.
   /// 1.8</summary>
   /// <param name="emission">The signal&apos;s name.</param>
   /// <param name="source">The signal&apos;s source.</param>
   /// <param name="func">The callback function to be executed when the signal is emitted.</param>
   /// <param name="data">A pointer to data to pass to the callback function.</param>
   /// <returns></returns>
   virtual public  void AddSignalCallback(  System.String emission,   System.String source,  ElmObjectItemSignalCb func,   System.IntPtr data) {
                                                                               Elm.Widget.ItemNativeInherit.elm_wdg_item_signal_callback_add_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), emission,  source,  func,  data);
      Eina.Error.RaiseIfUnhandledException();
                                                       }
   /// <summary>Remove a signal-triggered callback from a object item edje object.
   /// This function removes the last callback, previously attached to a signal emitted by an underlying Edje object of <c>it</c>, whose parameters <c>emission</c>, <c>source</c> and <c>func</c> match exactly with those passed to a previous call to <see cref="Elm.Widget.Item.AddSignalCallback"/>. The data pointer that was passed to this call will be returned.
   /// 
   /// See: <see cref="Elm.Widget.Item.AddSignalCallback"/>
   /// 1.8</summary>
   /// <param name="emission">The signal&apos;s name.</param>
   /// <param name="source">The signal&apos;s source.</param>
   /// <param name="func">The callback function to be executed when the signal is emitted.</param>
   /// <returns>The data pointer of the signal callback or <c>NULL</c>, on errors.</returns>
   virtual public  System.IntPtr DelSignalCallback(  System.String emission,   System.String source,  ElmObjectItemSignalCb func) {
                                                             var _ret_var = Elm.Widget.ItemNativeInherit.elm_wdg_item_signal_callback_del_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), emission,  source,  func);
      Eina.Error.RaiseIfUnhandledException();
                                          return _ret_var;
 }
   /// <summary>Send a signal to the edje object of the widget item.
   /// This function sends a signal to the edje object of the obj item. An edje program can respond to a signal by specifying matching &apos;signal&apos; and &apos;source&apos; fields. Don&apos;t use this unless you want to also handle resetting of part states to default on every unrealize in case of genlist/gengrid.</summary>
   /// <param name="emission">The signal&apos;s name.</param>
   /// <param name="source">The signal&apos;s source.</param>
   /// <returns></returns>
   virtual public  void EmitSignal(  System.String emission,   System.String source) {
                                           Elm.Widget.ItemNativeInherit.elm_wdg_item_signal_emit_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), emission,  source);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Set the text to read out when in accessibility mode</summary>
   /// <param name="txt">The text that describes the widget to people with poor or no vision</param>
   /// <returns></returns>
   virtual public  void SetAccessInfo(  System.String txt) {
                         Elm.Widget.ItemNativeInherit.elm_wdg_item_access_info_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), txt);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Get an accessible object of the object item.
   /// 1.8</summary>
   /// <returns>Accessible object of the object item or NULL for any error</returns>
   virtual public Efl.Canvas.Object GetAccessObject() {
       var _ret_var = Elm.Widget.ItemNativeInherit.elm_wdg_item_access_object_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Set the text for an object item&apos;s part, marking it as translatable.
   /// The string to set as <c>text</c> must be the original one. Do not pass the return of <c>gettext</c>() here. Elementary will translate the string internally and set it on the object item using <see cref="Elm.Widget.Item.GetPartText"/>, also storing the original string so that it can be automatically translated when the language is changed with elm_language_set(). The <c>domain</c> will be stored along to find the translation in the correct catalog. It can be NULL, in which case it will use whatever domain was set by the application with <c>textdomain</c>(). This is useful in case you are building a library on top of Elementary that will have its own translatable strings, that should not be mixed with those of programs using the library.
   /// 1.8</summary>
   /// <param name="part">The name of the part to set</param>
   /// <param name="domain">The translation domain to use</param>
   /// <param name="label">The original, non-translated text to set</param>
   /// <returns></returns>
   virtual public  void SetDomainTranslatablePartText(  System.String part,   System.String domain,   System.String label) {
                                                             Elm.Widget.ItemNativeInherit.elm_wdg_item_domain_translatable_part_text_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), part,  domain,  label);
      Eina.Error.RaiseIfUnhandledException();
                                           }
   /// <summary>Get the original string set as translatable for an object item.
   /// When setting translated strings, the function <see cref="Elm.Widget.Item.GetPartText"/> will return the translation returned by <c>gettext</c>(). To get the original string use this function.
   /// 1.8</summary>
   /// <param name="part">The name of the part that was set</param>
   /// <returns>The original, untranslated string</returns>
   virtual public  System.String GetTranslatablePartText(  System.String part) {
                         var _ret_var = Elm.Widget.ItemNativeInherit.elm_wdg_item_translatable_part_text_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), part);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Query translate</summary>
   /// <returns></returns>
   virtual public  void Translate() {
       Elm.Widget.ItemNativeInherit.elm_wdg_item_translate_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }
   /// <summary>Mark the part text to be translatable or not.
   /// Once you mark the part text to be translatable, the text will be translated internally regardless of <see cref="Elm.Widget.Item.GetPartText"/> and <see cref="Elm.Widget.Item.SetDomainTranslatablePartText"/>. In other case, if you set the Elementary policy that all text will be translatable in default, you can set the part text to not be translated by calling this API.
   /// 
   /// See: <see cref="Elm.Widget.Item.SetDomainTranslatablePartText"/> See: <see cref="Elm.Widget.Item.GetPartText"/> See: elm_policy()
   /// 1.8</summary>
   /// <param name="part">The part name of the translatable text</param>
   /// <param name="domain">The translation domain to use</param>
   /// <param name="translatable"><c>true</c>, the part text will be translated internally. <c>false</c>, otherwise.</param>
   /// <returns></returns>
   virtual public  void SetDomainPartTextTranslatable(  System.String part,   System.String domain,  bool translatable) {
                                                             Elm.Widget.ItemNativeInherit.elm_wdg_item_domain_part_text_translatable_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), part,  domain,  translatable);
      Eina.Error.RaiseIfUnhandledException();
                                           }
   /// <summary>This returns track object of the item.
   /// Note: This gets a rectangle object that represents the object item&apos;s internal object. If you want to check the geometry, visibility of the item, you can call the evas apis such as evas_object_geometry_get(), evas_object_visible_get() to the track object. Note that all of the widget items may/may not have the internal object so this api may return <c>NULL</c> if the widget item doesn&apos;t have it. Additionally, the widget item is managed/controlled by the widget, the widget item could be changed(moved, resized even deleted) anytime by it&apos;s own widget&apos;s decision. So please dont&apos; change the track object as well as don&apos;t keep the track object in your side as possible but get the track object at the moment you need to refer. Otherwise, you need to add some callbacks to the track object to track it&apos;s attributes changes.
   /// 
   /// Warning: After use the track object, please call the <see cref="Elm.Widget.Item.Untrack"/> paired to elm_object_item_track definitely to free the track object properly. Don&apos;t delete the track object.
   /// 
   /// See: <see cref="Elm.Widget.Item.Untrack"/> See: <see cref="Elm.Widget.Item.GetTrack"/>
   /// 1.8</summary>
   /// <returns>The track object</returns>
   virtual public Efl.Canvas.Object Track() {
       var _ret_var = Elm.Widget.ItemNativeInherit.elm_wdg_item_track_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>This retrieve the track object of the item.
   /// Note: This retrieves the track object that was returned from <see cref="Elm.Widget.Item.Track"/>.
   /// 
   /// See: <see cref="Elm.Widget.Item.Track"/> See: <see cref="Elm.Widget.Item.GetTrack"/>
   /// 1.8</summary>
   /// <returns></returns>
   virtual public  void Untrack() {
       Elm.Widget.ItemNativeInherit.elm_wdg_item_untrack_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }
   /// <summary>Get the track object reference count.
   /// Note: This gets the reference count for the track object. Whenever you call the <see cref="Elm.Widget.Item.Track"/>, the reference count will be increased by one. Likely the reference count will be decreased again when you call the <see cref="Elm.Widget.Item.Untrack"/>. Unless the reference count reaches to zero, the track object won&apos;t be deleted. So please be sure to call <see cref="Elm.Widget.Item.Untrack"/> paired to the elm_object_item_track call count.
   /// 
   /// See: <see cref="Elm.Widget.Item.Track"/> See: <see cref="Elm.Widget.Item.GetTrack"/>
   /// 1.8</summary>
   /// <returns>Track object reference count</returns>
   virtual public  int GetTrack() {
       var _ret_var = Elm.Widget.ItemNativeInherit.elm_wdg_item_track_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Query track_cancel</summary>
   /// <returns></returns>
   virtual public  void TrackCancel() {
       Elm.Widget.ItemNativeInherit.elm_wdg_item_track_cancel_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }
   /// <summary>Set the function to be called when an item from the widget is freed.
   /// Note: Every elm_object_item supports this API</summary>
   /// <param name="del_cb">The function called</param>
   /// <returns></returns>
   virtual public  void SetDelCb( EvasSmartCb del_cb) {
                         Elm.Widget.ItemNativeInherit.elm_wdg_item_del_cb_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), del_cb);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Set the content to be shown in the tooltip item.
   /// Setup the tooltip to item. The item can have only one tooltip, so any previous tooltip data is removed. <c>func</c>(with <c>data</c>) will be called every time that need show the tooltip and it should return a valid Evas_Object. This object is then managed fully by tooltip system and is deleted when the tooltip is gone.
   /// 
   /// See: elm_object_tooltip_content_cb_set() for more details.</summary>
   /// <param name="func">The function used to create the tooltip contents.</param>
   /// <param name="data">What to provide to <c>func</c> as callback data/context.</param>
   /// <param name="del_cb">Called when data is not needed anymore, either when another callback replaces <c>func</c>, the tooltip is unset with <see cref="Elm.Widget.Item.UnsetTooltip"/> or the owner <c>item</c> dies. This callback receives as the first parameter the given <c>data</c>, and <c>event_info</c> is the item.</param>
   /// <returns></returns>
   virtual public  void SetTooltipContentCb( ElmTooltipItemContentCb func,   System.IntPtr data,  EvasSmartCb del_cb) {
                                                             Elm.Widget.ItemNativeInherit.elm_wdg_item_tooltip_content_cb_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), func,  data,  del_cb);
      Eina.Error.RaiseIfUnhandledException();
                                           }
   /// <summary>Register object item as an accessible object.
   /// 1.8</summary>
   /// <returns>Accessible object of the object item or NULL for any error</returns>
   virtual public Efl.Canvas.Object AccessRegister() {
       var _ret_var = Elm.Widget.ItemNativeInherit.elm_wdg_item_access_register_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Unregister accessible object of the object item.
   /// 1.8</summary>
   /// <returns></returns>
   virtual public  void AccessUnregister() {
       Elm.Widget.ItemNativeInherit.elm_wdg_item_access_unregister_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }
   /// <summary>Unset highlight order
   /// 1.8</summary>
   /// <returns></returns>
   virtual public  void UnsetAccessOrder() {
       Elm.Widget.ItemNativeInherit.elm_wdg_item_access_order_unset_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }
   /// <summary>Disable widget item</summary>
   /// <returns></returns>
   virtual public  void Disable() {
       Elm.Widget.ItemNativeInherit.elm_wdg_item_disable_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }
   /// <summary>Delete pre widget item</summary>
   /// <returns></returns>
   virtual public  void DelPre() {
       Elm.Widget.ItemNativeInherit.elm_wdg_item_del_pre_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }
   /// <summary>Get the next object with specific focus direction.
   /// 1.16</summary>
   /// <param name="dir">Focus direction</param>
   /// <returns>Focus next object</returns>
   virtual public Efl.Canvas.Object GetFocusNextObject( Efl.Ui.Focus.Direction dir) {
                         var _ret_var = Elm.Widget.ItemNativeInherit.elm_wdg_item_focus_next_object_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), dir);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Set the next object with specific focus direction.
   /// 1.16</summary>
   /// <param name="next">Focus next object</param>
   /// <param name="dir">Focus direction</param>
   /// <returns></returns>
   virtual public  void SetFocusNextObject( Efl.Canvas.Object next,  Efl.Ui.Focus.Direction dir) {
                                           Elm.Widget.ItemNativeInherit.elm_wdg_item_focus_next_object_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), next,  dir);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Get the next object item with specific focus direction.
   /// 1.16</summary>
   /// <param name="dir">Focus direction</param>
   /// <returns>Focus next object item</returns>
   virtual public Elm.Widget.Item GetFocusNextItem( Efl.Ui.Focus.Direction dir) {
                         var _ret_var = Elm.Widget.ItemNativeInherit.elm_wdg_item_focus_next_item_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), dir);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Set the next object item with specific focus direction.
   /// 1.16</summary>
   /// <param name="next_item">Focus next object item</param>
   /// <param name="dir">Focus direction</param>
   /// <returns></returns>
   virtual public  void SetFocusNextItem( Elm.Widget.Item next_item,  Efl.Ui.Focus.Direction dir) {
                                           Elm.Widget.ItemNativeInherit.elm_wdg_item_focus_next_item_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), next_item,  dir);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Gets action name for given id</summary>
   /// <param name="id">ID to get action name for</param>
   /// <returns>Action name</returns>
   virtual public  System.String GetActionName(  int id) {
                         var _ret_var = Efl.Access.ActionNativeInherit.efl_access_action_name_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), id);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Gets localized action name for given id</summary>
   /// <param name="id">ID to get localized name for</param>
   /// <returns>Localized name</returns>
   virtual public  System.String GetActionLocalizedName(  int id) {
                         var _ret_var = Efl.Access.ActionNativeInherit.efl_access_action_localized_name_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), id);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Get list of available widget actions</summary>
   /// <returns>Contains statically allocated strings.</returns>
   virtual public Eina.List<Efl.Access.ActionData> GetActions() {
       var _ret_var = Efl.Access.ActionNativeInherit.efl_access_action_actions_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return new Eina.List<Efl.Access.ActionData>(_ret_var, false, false);
 }
   /// <summary>Performs action on given widget.</summary>
   /// <param name="id">ID for widget</param>
   /// <returns><c>true</c> if action was performed, <c>false</c> otherwise</returns>
   virtual public bool ActionDo(  int id) {
                         var _ret_var = Efl.Access.ActionNativeInherit.efl_access_action_do_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), id);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Gets configured keybinding for specific action and widget.</summary>
   /// <param name="id">ID for widget</param>
   /// <returns>Should be freed by the user.</returns>
   virtual public  System.String GetActionKeybinding(  int id) {
                         var _ret_var = Efl.Access.ActionNativeInherit.efl_access_action_keybinding_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), id);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Gets the depth at which the component is shown in relation to other components in the same container.</summary>
   /// <returns>Z order of component</returns>
   virtual public  int GetZOrder() {
       var _ret_var = Efl.Access.ComponentNativeInherit.efl_access_component_z_order_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Geometry of accessible widget.</summary>
   /// <param name="screen_coords">If <c>true</c> x and y values will be relative to screen origin, otherwise relative to canvas</param>
   /// <returns>The geometry.</returns>
   virtual public Eina.Rect GetExtents( bool screen_coords) {
                         var _ret_var = Efl.Access.ComponentNativeInherit.efl_access_component_extents_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), screen_coords);
      Eina.Error.RaiseIfUnhandledException();
                  return Eina.Rect_StructConversion.ToManaged(_ret_var);
 }
   /// <summary>Geometry of accessible widget.</summary>
   /// <param name="screen_coords">If <c>true</c> x and y values will be relative to screen origin, otherwise relative to canvas</param>
   /// <param name="rect">The geometry.</param>
   /// <returns><c>true</c> if geometry was set, <c>false</c> otherwise</returns>
   virtual public bool SetExtents( bool screen_coords,  Eina.Rect rect) {
             var _in_rect = Eina.Rect_StructConversion.ToInternal(rect);
                              var _ret_var = Efl.Access.ComponentNativeInherit.efl_access_component_extents_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), screen_coords,  _in_rect);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }
   /// <summary>Position of accessible widget.</summary>
   /// <param name="x">X coordinate</param>
   /// <param name="y">Y coordinate</param>
   /// <returns></returns>
   virtual public  void GetScreenPosition( out  int x,  out  int y) {
                                           Efl.Access.ComponentNativeInherit.efl_access_component_screen_position_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), out x,  out y);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Position of accessible widget.</summary>
   /// <param name="x">X coordinate</param>
   /// <param name="y">Y coordinate</param>
   /// <returns><c>true</c> if position was set, <c>false</c> otherwise</returns>
   virtual public bool SetScreenPosition(  int x,   int y) {
                                           var _ret_var = Efl.Access.ComponentNativeInherit.efl_access_component_screen_position_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), x,  y);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }
   /// <summary>Gets position of socket offset.</summary>
   /// <param name="x"></param>
   /// <param name="y"></param>
   /// <returns></returns>
   virtual public  void GetSocketOffset( out  int x,  out  int y) {
                                           Efl.Access.ComponentNativeInherit.efl_access_component_socket_offset_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), out x,  out y);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Sets position of socket offset.</summary>
   /// <param name="x"></param>
   /// <param name="y"></param>
   /// <returns></returns>
   virtual public  void SetSocketOffset(  int x,   int y) {
                                           Efl.Access.ComponentNativeInherit.efl_access_component_socket_offset_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), x,  y);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Contains accessible widget</summary>
   /// <param name="screen_coords">If <c>true</c> x and y values will be relative to screen origin, otherwise relative to canvas</param>
   /// <param name="x">X coordinate</param>
   /// <param name="y">Y coordinate</param>
   /// <returns><c>true</c> if params have been set, <c>false</c> otherwise</returns>
   virtual public bool Contains( bool screen_coords,   int x,   int y) {
                                                             var _ret_var = Efl.Access.ComponentNativeInherit.efl_access_component_contains_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), screen_coords,  x,  y);
      Eina.Error.RaiseIfUnhandledException();
                                          return _ret_var;
 }
   /// <summary>Focuses accessible widget.</summary>
   /// <returns><c>true</c> if focus grab focus succeed, <c>false</c> otherwise.</returns>
   virtual public bool GrabFocus() {
       var _ret_var = Efl.Access.ComponentNativeInherit.efl_access_component_focus_grab_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Gets top component object occupying space at given coordinates.</summary>
   /// <param name="screen_coords">If <c>true</c> x and y values will be relative to screen origin, otherwise relative to canvas</param>
   /// <param name="x">X coordinate</param>
   /// <param name="y">Y coordinate</param>
   /// <returns>Top component object at given coordinate</returns>
   virtual public Efl.Object GetAccessibleAtPoint( bool screen_coords,   int x,   int y) {
                                                             var _ret_var = Efl.Access.ComponentNativeInherit.efl_access_component_accessible_at_point_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), screen_coords,  x,  y);
      Eina.Error.RaiseIfUnhandledException();
                                          return _ret_var;
 }
   /// <summary>Highlights accessible widget. returns true if highlight grab has successed, false otherwise.
   /// @if MOBILE @since_tizen 4.0 @elseif WEARABLE @since_tizen 3.0 @endif</summary>
   /// <returns></returns>
   virtual public bool GrabHighlight() {
       var _ret_var = Efl.Access.ComponentNativeInherit.efl_access_component_highlight_grab_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Clears highlight of accessible widget. returns true if clear has successed, false otherwise.
   /// @if MOBILE @since_tizen 4.0 @elseif WEARABLE @since_tizen 3.0 @endif</summary>
   /// <returns></returns>
   virtual public bool ClearHighlight() {
       var _ret_var = Efl.Access.ComponentNativeInherit.efl_access_component_highlight_clear_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Gets an localized string describing accessible object role name.</summary>
   /// <returns>Localized accessible object role name</returns>
   virtual public  System.String GetLocalizedRoleName() {
       var _ret_var = Efl.Access.ObjectNativeInherit.efl_access_object_localized_role_name_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Accessible name of the object.</summary>
   /// <returns>Accessible name</returns>
   virtual public  System.String GetI18nName() {
       var _ret_var = Efl.Access.ObjectNativeInherit.efl_access_object_i18n_name_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Accessible name of the object.</summary>
   /// <param name="i18n_name">Accessible name</param>
   /// <returns></returns>
   virtual public  void SetI18nName(  System.String i18n_name) {
                         Efl.Access.ObjectNativeInherit.efl_access_object_i18n_name_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), i18n_name);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Sets name information callback about widget.
   /// @if WEARABLE @since_tizen 3.0 @endif</summary>
   /// <param name="name_cb">reading information callback</param>
   /// <param name="data"></param>
   /// <returns></returns>
   virtual public  void SetNameCb( Efl.Access.ReadingInfoCb name_cb,   System.IntPtr data) {
                                           Efl.Access.ObjectNativeInherit.efl_access_object_name_cb_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), name_cb,  data);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Gets an all relations between accessible object and other accessible objects.</summary>
   /// <returns>Accessible relation set</returns>
   virtual public Efl.Access.RelationSet GetRelationSet() {
       var _ret_var = Efl.Access.ObjectNativeInherit.efl_access_object_relation_set_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>The role of the object in accessibility domain.</summary>
   /// <returns>Accessible role</returns>
   virtual public Efl.Access.Role GetRole() {
       var _ret_var = Efl.Access.ObjectNativeInherit.efl_access_object_role_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Sets the role of the object in accessibility domain.</summary>
   /// <param name="role">Accessible role</param>
   /// <returns></returns>
   virtual public  void SetRole( Efl.Access.Role role) {
                         Efl.Access.ObjectNativeInherit.efl_access_object_role_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), role);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Gets object&apos;s accessible parent.</summary>
   /// <returns>Accessible parent</returns>
   virtual public Efl.Access.Object GetAccessParent() {
       var _ret_var = Efl.Access.ObjectNativeInherit.efl_access_object_access_parent_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Gets object&apos;s accessible parent.</summary>
   /// <param name="parent">Accessible parent</param>
   /// <returns></returns>
   virtual public  void SetAccessParent( Efl.Access.Object parent) {
                         Efl.Access.ObjectNativeInherit.efl_access_object_access_parent_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), parent);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Sets contextual information callback about widget.
   /// @if WEARABLE @since_tizen 3.0 @endif</summary>
   /// <param name="description_cb">The function called to provide the accessible description.</param>
   /// <param name="data">The data passed to @c description_cb.</param>
   /// <returns></returns>
   virtual public  void SetDescriptionCb( Efl.Access.ReadingInfoCb description_cb,   System.IntPtr data) {
                                           Efl.Access.ObjectNativeInherit.efl_access_object_description_cb_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), description_cb,  data);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Sets gesture callback to give widget.
   /// Warning: Please do not abuse this API. The purpose of this API is to support special application such as screen-reader guidance. Before using this API, please check if there is another way.
   /// 
   /// @if WEARABLE @since_tizen 3.0 @endif</summary>
   /// <param name="gesture_cb"></param>
   /// <param name="data"></param>
   /// <returns></returns>
   virtual public  void SetGestureCb( Efl.Access.GestureCb gesture_cb,   System.IntPtr data) {
                                           Efl.Access.ObjectNativeInherit.efl_access_object_gesture_cb_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), gesture_cb,  data);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Gets object&apos;s accessible children.</summary>
   /// <returns>List of widget&apos;s children</returns>
   virtual public Eina.List<Efl.Access.Object> GetAccessChildren() {
       var _ret_var = Efl.Access.ObjectNativeInherit.efl_access_object_access_children_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return new Eina.List<Efl.Access.Object>(_ret_var, true, false);
 }
   /// <summary>Gets human-readable string indentifying object accessibility role.</summary>
   /// <returns>Accessible role name</returns>
   virtual public  System.String GetRoleName() {
       var _ret_var = Efl.Access.ObjectNativeInherit.efl_access_object_role_name_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Gets key-value pairs indentifying object extra attributes. Must be free by a user.</summary>
   /// <returns>List of object attributes, Must be freed by the user</returns>
   virtual public Eina.List<Efl.Access.Attribute> GetAttributes() {
       var _ret_var = Efl.Access.ObjectNativeInherit.efl_access_object_attributes_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return new Eina.List<Efl.Access.Attribute>(_ret_var, true, true);
 }
   /// <summary>Gets reading information types of an accessible object.
   /// @if WEARABLE @since_tizen 3.0 @endif</summary>
   /// <returns>Reading information types</returns>
   virtual public Efl.Access.ReadingInfoTypeMask GetReadingInfoType() {
       var _ret_var = Efl.Access.ObjectNativeInherit.efl_access_object_reading_info_type_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Sets reading information of an accessible object.
   /// @if WEARABLE @since_tizen 3.0 @endif</summary>
   /// <param name="reading_info">Reading information types</param>
   /// <returns></returns>
   virtual public  void SetReadingInfoType( Efl.Access.ReadingInfoTypeMask reading_info) {
                         Efl.Access.ObjectNativeInherit.efl_access_object_reading_info_type_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), reading_info);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Gets index of the child in parent&apos;s children list.</summary>
   /// <returns>Index in children list</returns>
   virtual public  int GetIndexInParent() {
       var _ret_var = Efl.Access.ObjectNativeInherit.efl_access_object_index_in_parent_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Gets contextual information about object.</summary>
   /// <returns>Accessible contextual information</returns>
   virtual public  System.String GetDescription() {
       var _ret_var = Efl.Access.ObjectNativeInherit.efl_access_object_description_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Sets widget contextual information.</summary>
   /// <param name="description">Accessible contextual information</param>
   /// <returns></returns>
   virtual public  void SetDescription(  System.String description) {
                         Efl.Access.ObjectNativeInherit.efl_access_object_description_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), description);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Gets set describing object accessible states.</summary>
   /// <returns>Accessible state set</returns>
   virtual public Efl.Access.StateSet GetStateSet() {
       var _ret_var = Efl.Access.ObjectNativeInherit.efl_access_object_state_set_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Gets highlightable of given widget.
   /// @if WEARABLE @since_tizen 3.0 @endif</summary>
   /// <returns>If @c true, the object is highlightable.</returns>
   virtual public bool GetCanHighlight() {
       var _ret_var = Efl.Access.ObjectNativeInherit.efl_access_object_can_highlight_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Sets highlightable to given widget.
   /// @if WEARABLE @since_tizen 3.0 @endif</summary>
   /// <param name="can_highlight">If @c true, the object is highlightable.</param>
   /// <returns></returns>
   virtual public  void SetCanHighlight( bool can_highlight) {
                         Efl.Access.ObjectNativeInherit.efl_access_object_can_highlight_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), can_highlight);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>The translation domain of &quot;name&quot; and &quot;description&quot; properties.
   /// Translation domain should be set if the application wants to support i18n for accessibility &quot;name&quot; and &quot;description&quot; properties.
   /// 
   /// When translation domain is set, values of &quot;name&quot; and &quot;description&quot; properties will be translated with the dgettext function using the current translation domain as the &quot;domainname&quot; parameter.
   /// 
   /// It is the application developer&apos;s responsibility to ensure that translation files are loaded and bound to the translation domain when accessibility is enabled.</summary>
   /// <returns>Translation domain</returns>
   virtual public  System.String GetTranslationDomain() {
       var _ret_var = Efl.Access.ObjectNativeInherit.efl_access_object_translation_domain_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>The translation domain of &quot;name&quot; and &quot;description&quot; properties.
   /// Translation domain should be set if the application wants to support i18n for accessibility &quot;name&quot; and &quot;description&quot; properties.
   /// 
   /// When translation domain is set, values of &quot;name&quot; and &quot;description&quot; properties will be translated with the dgettext function using the current translation domain as the &quot;domainname&quot; parameter.
   /// 
   /// It is the application developer&apos;s responsibility to ensure that translation files are loaded and bound to the translation domain when accessibility is enabled.</summary>
   /// <param name="domain">Translation domain</param>
   /// <returns></returns>
   virtual public  void SetTranslationDomain(  System.String domain) {
                         Efl.Access.ObjectNativeInherit.efl_access_object_translation_domain_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), domain);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Get root object of accessible object hierarchy</summary>
   /// <returns>Root object</returns>
   public static Efl.Object GetAccessRoot() {
       var _ret_var = Efl.Access.ObjectNativeInherit.efl_access_object_access_root_get_ptr.Value.Delegate();
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Handles gesture on given widget.</summary>
   /// <param name="gesture_info"></param>
   /// <returns></returns>
   virtual public bool GestureDo( Efl.Access.GestureInfo gesture_info) {
       var _in_gesture_info = Efl.Access.GestureInfo_StructConversion.ToInternal(gesture_info);
                  var _ret_var = Efl.Access.ObjectNativeInherit.efl_access_object_gesture_do_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), _in_gesture_info);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Add key-value pair identifying object extra attribute
   /// @if WEARABLE @since_tizen 3.0 @endif</summary>
   /// <param name="key">The string key to give extra information</param>
   /// <param name="value">The string value to give extra information</param>
   /// <returns></returns>
   virtual public  void AppendAttribute(  System.String key,   System.String value) {
                                           Efl.Access.ObjectNativeInherit.efl_access_object_attribute_append_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), key,  value);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Removes all attributes in accessible object.</summary>
   /// <returns></returns>
   virtual public  void ClearAttributes() {
       Efl.Access.ObjectNativeInherit.efl_access_object_attributes_clear_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }
   /// <summary>Register accessibility event listener</summary>
   /// <param name="cb">Callback</param>
   /// <param name="data">Data</param>
   /// <returns>Event handler</returns>
   public static Efl.Access.Event.Handler AddEventHandler( Efl.EventCb cb,   System.IntPtr data) {
                                           var _ret_var = Efl.Access.ObjectNativeInherit.efl_access_object_event_handler_add_ptr.Value.Delegate( cb,  data);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }
   /// <summary>Deregister accessibility event listener</summary>
   /// <param name="handler">Event handler</param>
   /// <returns></returns>
   public static  void DelEventHandler( Efl.Access.Event.Handler handler) {
                         Efl.Access.ObjectNativeInherit.efl_access_object_event_handler_del_ptr.Value.Delegate( handler);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Emit event</summary>
   /// <param name="accessible">Accessibility object.</param>
   /// <param name="kw_event">Accessibility event type.</param>
   /// <param name="event_info">Accessibility event details.</param>
   /// <returns></returns>
   public static  void EmitEvent( Efl.Access.Object accessible,  Efl.EventDescription kw_event,   System.IntPtr event_info) {
             var _in_kw_event = Eina.PrimitiveConversion.ManagedToPointerAlloc(kw_event);
                                                Efl.Access.ObjectNativeInherit.efl_access_object_event_emit_ptr.Value.Delegate( accessible,  _in_kw_event,  event_info);
      Eina.Error.RaiseIfUnhandledException();
                                           }
   /// <summary>Defines the relationship between two accessible objects.
   /// Adds a unique relationship between source object and relation_object of a given type.
   /// 
   /// Relationships can be queried by Assistive Technology clients to provide customized feedback, improving overall user experience.
   /// 
   /// Relationship_append API is asymmetric, which means that appending, for example, relation EFL_ACCESS_RELATION_FLOWS_TO from object A to B, do NOT append relation EFL_ACCESS_RELATION_FLOWS_FROM from object B to object A.</summary>
   /// <param name="type">Relation type</param>
   /// <param name="relation_object">Object to relate to</param>
   /// <returns><c>true</c> if relationship was successfully appended, <c>false</c> otherwise</returns>
   virtual public bool AppendRelationship( Efl.Access.RelationType type,  Efl.Access.Object relation_object) {
                                           var _ret_var = Efl.Access.ObjectNativeInherit.efl_access_object_relationship_append_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), type,  relation_object);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }
   /// <summary>Removes the relationship between two accessible objects.
   /// If relation_object is NULL function removes all relations of the given type.</summary>
   /// <param name="type">Relation type</param>
   /// <param name="relation_object">Object to remove relation from</param>
   /// <returns></returns>
   virtual public  void RelationshipRemove( Efl.Access.RelationType type,  Efl.Access.Object relation_object) {
                                           Efl.Access.ObjectNativeInherit.efl_access_object_relationship_remove_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), type,  relation_object);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Removes all relationships in accessible object.</summary>
   /// <returns></returns>
   virtual public  void ClearRelationships() {
       Efl.Access.ObjectNativeInherit.efl_access_object_relationships_clear_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }
   /// <summary>Notifies accessibility clients about current state of the accessible object.
   /// Function limits information broadcast to clients to types specified by state_types_mask parameter.
   /// 
   /// if recursive parameter is set, function will traverse all accessible children and call state_notify function on them.</summary>
   /// <param name="state_types_mask"></param>
   /// <param name="recursive"></param>
   /// <returns></returns>
   virtual public  void StateNotify( Efl.Access.StateSet state_types_mask,  bool recursive) {
                                           Efl.Access.ObjectNativeInherit.efl_access_object_state_notify_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), state_types_mask,  recursive);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Elementary actions</summary>
   /// <returns>NULL-terminated array of Efl.Access.Action_Data.</returns>
   virtual public Efl.Access.ActionData GetElmActions() {
       var _ret_var = Efl.Access.Widget.ActionNativeInherit.efl_access_widget_action_elm_actions_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
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
   /// <summary>Control size restriction state of an object&apos;s tooltip
/// This function returns whether a tooltip is allowed to expand beyond its parent window&apos;s canvas. It will instead be limited only by the size of the display.</summary>
/// <value>If <c>true</c>, size restrictions are disabled</value>
   public bool TooltipWindowMode {
      get { return GetTooltipWindowMode(); }
      set { SetTooltipWindowMode( value); }
   }
   /// <summary>Control a different style for this item tooltip.
/// Note: before you set a style you should define a tooltip with <see cref="Elm.Widget.Item.SetTooltipContentCb"/> or <see cref="Elm.Widget.Item.SetTooltipText"/>
/// 
/// See: elm_object_tooltip_style_set() for more details.</summary>
/// <value>The theme style used/to use (default, transparent, ...)</value>
   public  System.String TooltipStyle {
      get { return GetTooltipStyle(); }
      set { SetTooltipStyle( value); }
   }
   /// <summary>Control the type of mouse pointer/cursor decoration to be shown, when the mouse pointer is over the given item
/// This function works analogously as elm_object_cursor_set(), but here the cursor&apos;s changing area is restricted to the item&apos;s area, and not the whole widget&apos;s. Note that that item cursors have precedence over widget cursors, so that a mouse over an item with custom cursor set will always show that cursor.
/// 
/// If this function is called twice for an object, a previously set cursor will be unset on the second call.</summary>
/// <value>The cursor type&apos;s name</value>
   public  System.String Cursor {
      get { return GetCursor(); }
      set { SetCursor( value); }
   }
   /// <summary>Control a different <c>style</c> for a given custom cursor set for an item.
/// This function only makes sense when one is using custom mouse cursor decorations defined in a theme file, which can have, given a cursor name/type, alternate styles on it. It works analogously as elm_object_cursor_style_set(), but here applies only to item objects.
/// 
/// Warning: Before you set a cursor style you should have defined a custom cursor previously on the item, with <see cref="Elm.Widget.Item.SetCursor"/></summary>
/// <value>The theme style to use/in use (e.g. $&quot;default&quot;, $&quot;transparent&quot;, etc)</value>
   public  System.String CursorStyle {
      get { return GetCursorStyle(); }
      set { SetCursorStyle( value); }
   }
   /// <summary>Control if the (custom)cursor for a given item should be searched in its theme, also, or should only rely on the rendering engine.
/// Note: This call is of use only if you&apos;ve set a custom cursor for items, with <see cref="Elm.Widget.Item.SetCursor"/>.
/// 
/// Note: By default, cursors will only be looked for between those provided by the rendering engine.</summary>
/// <value>Use <c>true</c> to have cursors looked for only on those provided by the rendering engine, <c>false</c> to have them searched on the widget&apos;s theme, as well.</value>
   public bool CursorEngineOnly {
      get { return GetCursorEngineOnly(); }
      set { SetCursorEngineOnly( value); }
   }
   /// <summary>Control the object item focused
/// 1.10</summary>
/// <value>The focused state</value>
   public bool ItemFocus {
      get { return GetItemFocus(); }
      set { SetItemFocus( value); }
   }
   /// <summary>Control the style of an object item
/// 1.9</summary>
/// <value>The style of object item</value>
   public  System.String Style {
      get { return GetStyle(); }
      set { SetStyle( value); }
   }
   /// <summary>Control the disabled state of a widget item.
/// Elementary object item can be disabled, in which state they won&apos;t receive input and, in general, will be themed differently from their normal state, usually greyed out. Useful for contexts where you don&apos;t want your users to interact with some of the parts of you interface.
/// 
/// This sets the state for the widget item, either disabling it or enabling it back.</summary>
/// <value><c>true</c>, if the widget item is disabled, <c>false</c> if it&apos;s enabled (or on errors)</value>
   public bool Disabled {
      get { return GetDisabled(); }
      set { SetDisabled( value); }
   }
   /// <summary>Get list of available widget actions</summary>
/// <value>Contains statically allocated strings.</value>
   public Eina.List<Efl.Access.ActionData> Actions {
      get { return GetActions(); }
   }
   /// <summary>Gets the depth at which the component is shown in relation to other components in the same container.</summary>
/// <value>Z order of component</value>
   public  int ZOrder {
      get { return GetZOrder(); }
   }
   /// <summary>Gets an localized string describing accessible object role name.</summary>
/// <value>Localized accessible object role name</value>
   public  System.String LocalizedRoleName {
      get { return GetLocalizedRoleName(); }
   }
   /// <summary>Accessible name of the object.</summary>
/// <value>Accessible name</value>
   public  System.String I18nName {
      get { return GetI18nName(); }
      set { SetI18nName( value); }
   }
   /// <summary>Gets an all relations between accessible object and other accessible objects.</summary>
/// <value>Accessible relation set</value>
   public Efl.Access.RelationSet RelationSet {
      get { return GetRelationSet(); }
   }
   /// <summary>The role of the object in accessibility domain.</summary>
/// <value>Accessible role</value>
   public Efl.Access.Role Role {
      get { return GetRole(); }
      set { SetRole( value); }
   }
   /// <summary>Gets object&apos;s accessible parent.</summary>
/// <value>Accessible parent</value>
   public Efl.Access.Object AccessParent {
      get { return GetAccessParent(); }
      set { SetAccessParent( value); }
   }
   /// <summary>Gets object&apos;s accessible children.</summary>
/// <value>List of widget&apos;s children</value>
   public Eina.List<Efl.Access.Object> AccessChildren {
      get { return GetAccessChildren(); }
   }
   /// <summary>Gets human-readable string indentifying object accessibility role.</summary>
/// <value>Accessible role name</value>
   public  System.String RoleName {
      get { return GetRoleName(); }
   }
   /// <summary>Gets key-value pairs indentifying object extra attributes. Must be free by a user.</summary>
/// <value>List of object attributes, Must be freed by the user</value>
   public Eina.List<Efl.Access.Attribute> Attributes {
      get { return GetAttributes(); }
   }
   /// <summary>Gets reading information types of an accessible object.
/// @if WEARABLE @since_tizen 3.0 @endif</summary>
/// <value>Reading information types</value>
   public Efl.Access.ReadingInfoTypeMask ReadingInfoType {
      get { return GetReadingInfoType(); }
      set { SetReadingInfoType( value); }
   }
   /// <summary>Gets index of the child in parent&apos;s children list.</summary>
/// <value>Index in children list</value>
   public  int IndexInParent {
      get { return GetIndexInParent(); }
   }
   /// <summary>Gets contextual information about object.</summary>
/// <value>Accessible contextual information</value>
   public  System.String Description {
      get { return GetDescription(); }
      set { SetDescription( value); }
   }
   /// <summary>Gets set describing object accessible states.</summary>
/// <value>Accessible state set</value>
   public Efl.Access.StateSet StateSet {
      get { return GetStateSet(); }
   }
   /// <summary>Gets highlightable of given widget.
/// @if WEARABLE @since_tizen 3.0 @endif</summary>
/// <value>If @c true, the object is highlightable.</value>
   public bool CanHighlight {
      get { return GetCanHighlight(); }
      set { SetCanHighlight( value); }
   }
   /// <summary>The translation domain of &quot;name&quot; and &quot;description&quot; properties.
/// Translation domain should be set if the application wants to support i18n for accessibility &quot;name&quot; and &quot;description&quot; properties.
/// 
/// When translation domain is set, values of &quot;name&quot; and &quot;description&quot; properties will be translated with the dgettext function using the current translation domain as the &quot;domainname&quot; parameter.
/// 
/// It is the application developer&apos;s responsibility to ensure that translation files are loaded and bound to the translation domain when accessibility is enabled.</summary>
/// <value>Translation domain</value>
   public  System.String TranslationDomain {
      get { return GetTranslationDomain(); }
      set { SetTranslationDomain( value); }
   }
   /// <summary>Get root object of accessible object hierarchy</summary>
/// <value>Root object</value>
   public static Efl.Object AccessRoot {
      get { return GetAccessRoot(); }
   }
   /// <summary>Elementary actions</summary>
/// <value>NULL-terminated array of Efl.Access.Action_Data.</value>
   public Efl.Access.ActionData ElmActions {
      get { return GetElmActions(); }
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
   private static new  IntPtr GetEflClassStatic()
   {
      return Elm.Widget.Item.elm_widget_item_class_get();
   }
}
public class ItemNativeInherit : Efl.ObjectNativeInherit{
   public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Elementary);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      if (elm_wdg_item_tooltip_window_mode_get_static_delegate == null)
      elm_wdg_item_tooltip_window_mode_get_static_delegate = new elm_wdg_item_tooltip_window_mode_get_delegate(tooltip_window_mode_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "elm_wdg_item_tooltip_window_mode_get"), func = Marshal.GetFunctionPointerForDelegate(elm_wdg_item_tooltip_window_mode_get_static_delegate)});
      if (elm_wdg_item_tooltip_window_mode_set_static_delegate == null)
      elm_wdg_item_tooltip_window_mode_set_static_delegate = new elm_wdg_item_tooltip_window_mode_set_delegate(tooltip_window_mode_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "elm_wdg_item_tooltip_window_mode_set"), func = Marshal.GetFunctionPointerForDelegate(elm_wdg_item_tooltip_window_mode_set_static_delegate)});
      if (elm_wdg_item_tooltip_style_get_static_delegate == null)
      elm_wdg_item_tooltip_style_get_static_delegate = new elm_wdg_item_tooltip_style_get_delegate(tooltip_style_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "elm_wdg_item_tooltip_style_get"), func = Marshal.GetFunctionPointerForDelegate(elm_wdg_item_tooltip_style_get_static_delegate)});
      if (elm_wdg_item_tooltip_style_set_static_delegate == null)
      elm_wdg_item_tooltip_style_set_static_delegate = new elm_wdg_item_tooltip_style_set_delegate(tooltip_style_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "elm_wdg_item_tooltip_style_set"), func = Marshal.GetFunctionPointerForDelegate(elm_wdg_item_tooltip_style_set_static_delegate)});
      if (elm_wdg_item_cursor_get_static_delegate == null)
      elm_wdg_item_cursor_get_static_delegate = new elm_wdg_item_cursor_get_delegate(cursor_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "elm_wdg_item_cursor_get"), func = Marshal.GetFunctionPointerForDelegate(elm_wdg_item_cursor_get_static_delegate)});
      if (elm_wdg_item_cursor_set_static_delegate == null)
      elm_wdg_item_cursor_set_static_delegate = new elm_wdg_item_cursor_set_delegate(cursor_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "elm_wdg_item_cursor_set"), func = Marshal.GetFunctionPointerForDelegate(elm_wdg_item_cursor_set_static_delegate)});
      if (elm_wdg_item_cursor_style_get_static_delegate == null)
      elm_wdg_item_cursor_style_get_static_delegate = new elm_wdg_item_cursor_style_get_delegate(cursor_style_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "elm_wdg_item_cursor_style_get"), func = Marshal.GetFunctionPointerForDelegate(elm_wdg_item_cursor_style_get_static_delegate)});
      if (elm_wdg_item_cursor_style_set_static_delegate == null)
      elm_wdg_item_cursor_style_set_static_delegate = new elm_wdg_item_cursor_style_set_delegate(cursor_style_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "elm_wdg_item_cursor_style_set"), func = Marshal.GetFunctionPointerForDelegate(elm_wdg_item_cursor_style_set_static_delegate)});
      if (elm_wdg_item_cursor_engine_only_get_static_delegate == null)
      elm_wdg_item_cursor_engine_only_get_static_delegate = new elm_wdg_item_cursor_engine_only_get_delegate(cursor_engine_only_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "elm_wdg_item_cursor_engine_only_get"), func = Marshal.GetFunctionPointerForDelegate(elm_wdg_item_cursor_engine_only_get_static_delegate)});
      if (elm_wdg_item_cursor_engine_only_set_static_delegate == null)
      elm_wdg_item_cursor_engine_only_set_static_delegate = new elm_wdg_item_cursor_engine_only_set_delegate(cursor_engine_only_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "elm_wdg_item_cursor_engine_only_set"), func = Marshal.GetFunctionPointerForDelegate(elm_wdg_item_cursor_engine_only_set_static_delegate)});
      if (elm_wdg_item_part_content_get_static_delegate == null)
      elm_wdg_item_part_content_get_static_delegate = new elm_wdg_item_part_content_get_delegate(part_content_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "elm_wdg_item_part_content_get"), func = Marshal.GetFunctionPointerForDelegate(elm_wdg_item_part_content_get_static_delegate)});
      if (elm_wdg_item_part_content_set_static_delegate == null)
      elm_wdg_item_part_content_set_static_delegate = new elm_wdg_item_part_content_set_delegate(part_content_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "elm_wdg_item_part_content_set"), func = Marshal.GetFunctionPointerForDelegate(elm_wdg_item_part_content_set_static_delegate)});
      if (elm_wdg_item_part_text_get_static_delegate == null)
      elm_wdg_item_part_text_get_static_delegate = new elm_wdg_item_part_text_get_delegate(part_text_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "elm_wdg_item_part_text_get"), func = Marshal.GetFunctionPointerForDelegate(elm_wdg_item_part_text_get_static_delegate)});
      if (elm_wdg_item_part_text_set_static_delegate == null)
      elm_wdg_item_part_text_set_static_delegate = new elm_wdg_item_part_text_set_delegate(part_text_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "elm_wdg_item_part_text_set"), func = Marshal.GetFunctionPointerForDelegate(elm_wdg_item_part_text_set_static_delegate)});
      if (elm_wdg_item_part_text_custom_get_static_delegate == null)
      elm_wdg_item_part_text_custom_get_static_delegate = new elm_wdg_item_part_text_custom_get_delegate(part_text_custom_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "elm_wdg_item_part_text_custom_get"), func = Marshal.GetFunctionPointerForDelegate(elm_wdg_item_part_text_custom_get_static_delegate)});
      if (elm_wdg_item_part_text_custom_set_static_delegate == null)
      elm_wdg_item_part_text_custom_set_static_delegate = new elm_wdg_item_part_text_custom_set_delegate(part_text_custom_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "elm_wdg_item_part_text_custom_set"), func = Marshal.GetFunctionPointerForDelegate(elm_wdg_item_part_text_custom_set_static_delegate)});
      if (elm_wdg_item_focus_get_static_delegate == null)
      elm_wdg_item_focus_get_static_delegate = new elm_wdg_item_focus_get_delegate(item_focus_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "elm_wdg_item_focus_get"), func = Marshal.GetFunctionPointerForDelegate(elm_wdg_item_focus_get_static_delegate)});
      if (elm_wdg_item_focus_set_static_delegate == null)
      elm_wdg_item_focus_set_static_delegate = new elm_wdg_item_focus_set_delegate(item_focus_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "elm_wdg_item_focus_set"), func = Marshal.GetFunctionPointerForDelegate(elm_wdg_item_focus_set_static_delegate)});
      if (elm_wdg_item_style_get_static_delegate == null)
      elm_wdg_item_style_get_static_delegate = new elm_wdg_item_style_get_delegate(style_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "elm_wdg_item_style_get"), func = Marshal.GetFunctionPointerForDelegate(elm_wdg_item_style_get_static_delegate)});
      if (elm_wdg_item_style_set_static_delegate == null)
      elm_wdg_item_style_set_static_delegate = new elm_wdg_item_style_set_delegate(style_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "elm_wdg_item_style_set"), func = Marshal.GetFunctionPointerForDelegate(elm_wdg_item_style_set_static_delegate)});
      if (elm_wdg_item_disabled_get_static_delegate == null)
      elm_wdg_item_disabled_get_static_delegate = new elm_wdg_item_disabled_get_delegate(disabled_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "elm_wdg_item_disabled_get"), func = Marshal.GetFunctionPointerForDelegate(elm_wdg_item_disabled_get_static_delegate)});
      if (elm_wdg_item_disabled_set_static_delegate == null)
      elm_wdg_item_disabled_set_static_delegate = new elm_wdg_item_disabled_set_delegate(disabled_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "elm_wdg_item_disabled_set"), func = Marshal.GetFunctionPointerForDelegate(elm_wdg_item_disabled_set_static_delegate)});
      if (elm_wdg_item_access_order_get_static_delegate == null)
      elm_wdg_item_access_order_get_static_delegate = new elm_wdg_item_access_order_get_delegate(access_order_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "elm_wdg_item_access_order_get"), func = Marshal.GetFunctionPointerForDelegate(elm_wdg_item_access_order_get_static_delegate)});
      if (elm_wdg_item_access_order_set_static_delegate == null)
      elm_wdg_item_access_order_set_static_delegate = new elm_wdg_item_access_order_set_delegate(access_order_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "elm_wdg_item_access_order_set"), func = Marshal.GetFunctionPointerForDelegate(elm_wdg_item_access_order_set_static_delegate)});
      if (elm_wdg_item_widget_get_static_delegate == null)
      elm_wdg_item_widget_get_static_delegate = new elm_wdg_item_widget_get_delegate(widget_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "elm_wdg_item_widget_get"), func = Marshal.GetFunctionPointerForDelegate(elm_wdg_item_widget_get_static_delegate)});
      if (elm_wdg_item_pre_notify_del_static_delegate == null)
      elm_wdg_item_pre_notify_del_static_delegate = new elm_wdg_item_pre_notify_del_delegate(pre_notify_del);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "elm_wdg_item_pre_notify_del"), func = Marshal.GetFunctionPointerForDelegate(elm_wdg_item_pre_notify_del_static_delegate)});
      if (elm_wdg_item_tooltip_text_set_static_delegate == null)
      elm_wdg_item_tooltip_text_set_static_delegate = new elm_wdg_item_tooltip_text_set_delegate(tooltip_text_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "elm_wdg_item_tooltip_text_set"), func = Marshal.GetFunctionPointerForDelegate(elm_wdg_item_tooltip_text_set_static_delegate)});
      if (elm_wdg_item_tooltip_translatable_text_set_static_delegate == null)
      elm_wdg_item_tooltip_translatable_text_set_static_delegate = new elm_wdg_item_tooltip_translatable_text_set_delegate(tooltip_translatable_text_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "elm_wdg_item_tooltip_translatable_text_set"), func = Marshal.GetFunctionPointerForDelegate(elm_wdg_item_tooltip_translatable_text_set_static_delegate)});
      if (elm_wdg_item_tooltip_unset_static_delegate == null)
      elm_wdg_item_tooltip_unset_static_delegate = new elm_wdg_item_tooltip_unset_delegate(tooltip_unset);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "elm_wdg_item_tooltip_unset"), func = Marshal.GetFunctionPointerForDelegate(elm_wdg_item_tooltip_unset_static_delegate)});
      if (elm_wdg_item_cursor_unset_static_delegate == null)
      elm_wdg_item_cursor_unset_static_delegate = new elm_wdg_item_cursor_unset_delegate(cursor_unset);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "elm_wdg_item_cursor_unset"), func = Marshal.GetFunctionPointerForDelegate(elm_wdg_item_cursor_unset_static_delegate)});
      if (elm_wdg_item_part_content_unset_static_delegate == null)
      elm_wdg_item_part_content_unset_static_delegate = new elm_wdg_item_part_content_unset_delegate(part_content_unset);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "elm_wdg_item_part_content_unset"), func = Marshal.GetFunctionPointerForDelegate(elm_wdg_item_part_content_unset_static_delegate)});
      if (elm_wdg_item_part_text_custom_update_static_delegate == null)
      elm_wdg_item_part_text_custom_update_static_delegate = new elm_wdg_item_part_text_custom_update_delegate(part_text_custom_update);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "elm_wdg_item_part_text_custom_update"), func = Marshal.GetFunctionPointerForDelegate(elm_wdg_item_part_text_custom_update_static_delegate)});
      if (elm_wdg_item_signal_callback_add_static_delegate == null)
      elm_wdg_item_signal_callback_add_static_delegate = new elm_wdg_item_signal_callback_add_delegate(signal_callback_add);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "elm_wdg_item_signal_callback_add"), func = Marshal.GetFunctionPointerForDelegate(elm_wdg_item_signal_callback_add_static_delegate)});
      if (elm_wdg_item_signal_callback_del_static_delegate == null)
      elm_wdg_item_signal_callback_del_static_delegate = new elm_wdg_item_signal_callback_del_delegate(signal_callback_del);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "elm_wdg_item_signal_callback_del"), func = Marshal.GetFunctionPointerForDelegate(elm_wdg_item_signal_callback_del_static_delegate)});
      if (elm_wdg_item_signal_emit_static_delegate == null)
      elm_wdg_item_signal_emit_static_delegate = new elm_wdg_item_signal_emit_delegate(signal_emit);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "elm_wdg_item_signal_emit"), func = Marshal.GetFunctionPointerForDelegate(elm_wdg_item_signal_emit_static_delegate)});
      if (elm_wdg_item_access_info_set_static_delegate == null)
      elm_wdg_item_access_info_set_static_delegate = new elm_wdg_item_access_info_set_delegate(access_info_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "elm_wdg_item_access_info_set"), func = Marshal.GetFunctionPointerForDelegate(elm_wdg_item_access_info_set_static_delegate)});
      if (elm_wdg_item_access_object_get_static_delegate == null)
      elm_wdg_item_access_object_get_static_delegate = new elm_wdg_item_access_object_get_delegate(access_object_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "elm_wdg_item_access_object_get"), func = Marshal.GetFunctionPointerForDelegate(elm_wdg_item_access_object_get_static_delegate)});
      if (elm_wdg_item_domain_translatable_part_text_set_static_delegate == null)
      elm_wdg_item_domain_translatable_part_text_set_static_delegate = new elm_wdg_item_domain_translatable_part_text_set_delegate(domain_translatable_part_text_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "elm_wdg_item_domain_translatable_part_text_set"), func = Marshal.GetFunctionPointerForDelegate(elm_wdg_item_domain_translatable_part_text_set_static_delegate)});
      if (elm_wdg_item_translatable_part_text_get_static_delegate == null)
      elm_wdg_item_translatable_part_text_get_static_delegate = new elm_wdg_item_translatable_part_text_get_delegate(translatable_part_text_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "elm_wdg_item_translatable_part_text_get"), func = Marshal.GetFunctionPointerForDelegate(elm_wdg_item_translatable_part_text_get_static_delegate)});
      if (elm_wdg_item_translate_static_delegate == null)
      elm_wdg_item_translate_static_delegate = new elm_wdg_item_translate_delegate(translate);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "elm_wdg_item_translate"), func = Marshal.GetFunctionPointerForDelegate(elm_wdg_item_translate_static_delegate)});
      if (elm_wdg_item_domain_part_text_translatable_set_static_delegate == null)
      elm_wdg_item_domain_part_text_translatable_set_static_delegate = new elm_wdg_item_domain_part_text_translatable_set_delegate(domain_part_text_translatable_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "elm_wdg_item_domain_part_text_translatable_set"), func = Marshal.GetFunctionPointerForDelegate(elm_wdg_item_domain_part_text_translatable_set_static_delegate)});
      if (elm_wdg_item_track_static_delegate == null)
      elm_wdg_item_track_static_delegate = new elm_wdg_item_track_delegate(track);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "elm_wdg_item_track"), func = Marshal.GetFunctionPointerForDelegate(elm_wdg_item_track_static_delegate)});
      if (elm_wdg_item_untrack_static_delegate == null)
      elm_wdg_item_untrack_static_delegate = new elm_wdg_item_untrack_delegate(untrack);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "elm_wdg_item_untrack"), func = Marshal.GetFunctionPointerForDelegate(elm_wdg_item_untrack_static_delegate)});
      if (elm_wdg_item_track_get_static_delegate == null)
      elm_wdg_item_track_get_static_delegate = new elm_wdg_item_track_get_delegate(track_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "elm_wdg_item_track_get"), func = Marshal.GetFunctionPointerForDelegate(elm_wdg_item_track_get_static_delegate)});
      if (elm_wdg_item_track_cancel_static_delegate == null)
      elm_wdg_item_track_cancel_static_delegate = new elm_wdg_item_track_cancel_delegate(track_cancel);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "elm_wdg_item_track_cancel"), func = Marshal.GetFunctionPointerForDelegate(elm_wdg_item_track_cancel_static_delegate)});
      if (elm_wdg_item_del_cb_set_static_delegate == null)
      elm_wdg_item_del_cb_set_static_delegate = new elm_wdg_item_del_cb_set_delegate(del_cb_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "elm_wdg_item_del_cb_set"), func = Marshal.GetFunctionPointerForDelegate(elm_wdg_item_del_cb_set_static_delegate)});
      if (elm_wdg_item_tooltip_content_cb_set_static_delegate == null)
      elm_wdg_item_tooltip_content_cb_set_static_delegate = new elm_wdg_item_tooltip_content_cb_set_delegate(tooltip_content_cb_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "elm_wdg_item_tooltip_content_cb_set"), func = Marshal.GetFunctionPointerForDelegate(elm_wdg_item_tooltip_content_cb_set_static_delegate)});
      if (elm_wdg_item_access_register_static_delegate == null)
      elm_wdg_item_access_register_static_delegate = new elm_wdg_item_access_register_delegate(access_register);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "elm_wdg_item_access_register"), func = Marshal.GetFunctionPointerForDelegate(elm_wdg_item_access_register_static_delegate)});
      if (elm_wdg_item_access_unregister_static_delegate == null)
      elm_wdg_item_access_unregister_static_delegate = new elm_wdg_item_access_unregister_delegate(access_unregister);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "elm_wdg_item_access_unregister"), func = Marshal.GetFunctionPointerForDelegate(elm_wdg_item_access_unregister_static_delegate)});
      if (elm_wdg_item_access_order_unset_static_delegate == null)
      elm_wdg_item_access_order_unset_static_delegate = new elm_wdg_item_access_order_unset_delegate(access_order_unset);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "elm_wdg_item_access_order_unset"), func = Marshal.GetFunctionPointerForDelegate(elm_wdg_item_access_order_unset_static_delegate)});
      if (elm_wdg_item_disable_static_delegate == null)
      elm_wdg_item_disable_static_delegate = new elm_wdg_item_disable_delegate(disable);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "elm_wdg_item_disable"), func = Marshal.GetFunctionPointerForDelegate(elm_wdg_item_disable_static_delegate)});
      if (elm_wdg_item_del_pre_static_delegate == null)
      elm_wdg_item_del_pre_static_delegate = new elm_wdg_item_del_pre_delegate(del_pre);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "elm_wdg_item_del_pre"), func = Marshal.GetFunctionPointerForDelegate(elm_wdg_item_del_pre_static_delegate)});
      if (elm_wdg_item_focus_next_object_get_static_delegate == null)
      elm_wdg_item_focus_next_object_get_static_delegate = new elm_wdg_item_focus_next_object_get_delegate(focus_next_object_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "elm_wdg_item_focus_next_object_get"), func = Marshal.GetFunctionPointerForDelegate(elm_wdg_item_focus_next_object_get_static_delegate)});
      if (elm_wdg_item_focus_next_object_set_static_delegate == null)
      elm_wdg_item_focus_next_object_set_static_delegate = new elm_wdg_item_focus_next_object_set_delegate(focus_next_object_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "elm_wdg_item_focus_next_object_set"), func = Marshal.GetFunctionPointerForDelegate(elm_wdg_item_focus_next_object_set_static_delegate)});
      if (elm_wdg_item_focus_next_item_get_static_delegate == null)
      elm_wdg_item_focus_next_item_get_static_delegate = new elm_wdg_item_focus_next_item_get_delegate(focus_next_item_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "elm_wdg_item_focus_next_item_get"), func = Marshal.GetFunctionPointerForDelegate(elm_wdg_item_focus_next_item_get_static_delegate)});
      if (elm_wdg_item_focus_next_item_set_static_delegate == null)
      elm_wdg_item_focus_next_item_set_static_delegate = new elm_wdg_item_focus_next_item_set_delegate(focus_next_item_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "elm_wdg_item_focus_next_item_set"), func = Marshal.GetFunctionPointerForDelegate(elm_wdg_item_focus_next_item_set_static_delegate)});
      if (efl_access_action_name_get_static_delegate == null)
      efl_access_action_name_get_static_delegate = new efl_access_action_name_get_delegate(action_name_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_action_name_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_action_name_get_static_delegate)});
      if (efl_access_action_localized_name_get_static_delegate == null)
      efl_access_action_localized_name_get_static_delegate = new efl_access_action_localized_name_get_delegate(action_localized_name_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_action_localized_name_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_action_localized_name_get_static_delegate)});
      if (efl_access_action_actions_get_static_delegate == null)
      efl_access_action_actions_get_static_delegate = new efl_access_action_actions_get_delegate(actions_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_action_actions_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_action_actions_get_static_delegate)});
      if (efl_access_action_do_static_delegate == null)
      efl_access_action_do_static_delegate = new efl_access_action_do_delegate(action_do);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_action_do"), func = Marshal.GetFunctionPointerForDelegate(efl_access_action_do_static_delegate)});
      if (efl_access_action_keybinding_get_static_delegate == null)
      efl_access_action_keybinding_get_static_delegate = new efl_access_action_keybinding_get_delegate(action_keybinding_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_action_keybinding_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_action_keybinding_get_static_delegate)});
      if (efl_access_component_z_order_get_static_delegate == null)
      efl_access_component_z_order_get_static_delegate = new efl_access_component_z_order_get_delegate(z_order_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_component_z_order_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_component_z_order_get_static_delegate)});
      if (efl_access_component_extents_get_static_delegate == null)
      efl_access_component_extents_get_static_delegate = new efl_access_component_extents_get_delegate(extents_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_component_extents_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_component_extents_get_static_delegate)});
      if (efl_access_component_extents_set_static_delegate == null)
      efl_access_component_extents_set_static_delegate = new efl_access_component_extents_set_delegate(extents_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_component_extents_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_component_extents_set_static_delegate)});
      if (efl_access_component_screen_position_get_static_delegate == null)
      efl_access_component_screen_position_get_static_delegate = new efl_access_component_screen_position_get_delegate(screen_position_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_component_screen_position_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_component_screen_position_get_static_delegate)});
      if (efl_access_component_screen_position_set_static_delegate == null)
      efl_access_component_screen_position_set_static_delegate = new efl_access_component_screen_position_set_delegate(screen_position_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_component_screen_position_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_component_screen_position_set_static_delegate)});
      if (efl_access_component_socket_offset_get_static_delegate == null)
      efl_access_component_socket_offset_get_static_delegate = new efl_access_component_socket_offset_get_delegate(socket_offset_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_component_socket_offset_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_component_socket_offset_get_static_delegate)});
      if (efl_access_component_socket_offset_set_static_delegate == null)
      efl_access_component_socket_offset_set_static_delegate = new efl_access_component_socket_offset_set_delegate(socket_offset_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_component_socket_offset_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_component_socket_offset_set_static_delegate)});
      if (efl_access_component_contains_static_delegate == null)
      efl_access_component_contains_static_delegate = new efl_access_component_contains_delegate(contains);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_component_contains"), func = Marshal.GetFunctionPointerForDelegate(efl_access_component_contains_static_delegate)});
      if (efl_access_component_focus_grab_static_delegate == null)
      efl_access_component_focus_grab_static_delegate = new efl_access_component_focus_grab_delegate(focus_grab);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_component_focus_grab"), func = Marshal.GetFunctionPointerForDelegate(efl_access_component_focus_grab_static_delegate)});
      if (efl_access_component_accessible_at_point_get_static_delegate == null)
      efl_access_component_accessible_at_point_get_static_delegate = new efl_access_component_accessible_at_point_get_delegate(accessible_at_point_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_component_accessible_at_point_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_component_accessible_at_point_get_static_delegate)});
      if (efl_access_component_highlight_grab_static_delegate == null)
      efl_access_component_highlight_grab_static_delegate = new efl_access_component_highlight_grab_delegate(highlight_grab);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_component_highlight_grab"), func = Marshal.GetFunctionPointerForDelegate(efl_access_component_highlight_grab_static_delegate)});
      if (efl_access_component_highlight_clear_static_delegate == null)
      efl_access_component_highlight_clear_static_delegate = new efl_access_component_highlight_clear_delegate(highlight_clear);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_component_highlight_clear"), func = Marshal.GetFunctionPointerForDelegate(efl_access_component_highlight_clear_static_delegate)});
      if (efl_access_object_localized_role_name_get_static_delegate == null)
      efl_access_object_localized_role_name_get_static_delegate = new efl_access_object_localized_role_name_get_delegate(localized_role_name_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_object_localized_role_name_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_localized_role_name_get_static_delegate)});
      if (efl_access_object_i18n_name_get_static_delegate == null)
      efl_access_object_i18n_name_get_static_delegate = new efl_access_object_i18n_name_get_delegate(i18n_name_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_object_i18n_name_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_i18n_name_get_static_delegate)});
      if (efl_access_object_i18n_name_set_static_delegate == null)
      efl_access_object_i18n_name_set_static_delegate = new efl_access_object_i18n_name_set_delegate(i18n_name_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_object_i18n_name_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_i18n_name_set_static_delegate)});
      if (efl_access_object_name_cb_set_static_delegate == null)
      efl_access_object_name_cb_set_static_delegate = new efl_access_object_name_cb_set_delegate(name_cb_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_object_name_cb_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_name_cb_set_static_delegate)});
      if (efl_access_object_relation_set_get_static_delegate == null)
      efl_access_object_relation_set_get_static_delegate = new efl_access_object_relation_set_get_delegate(relation_set_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_object_relation_set_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_relation_set_get_static_delegate)});
      if (efl_access_object_role_get_static_delegate == null)
      efl_access_object_role_get_static_delegate = new efl_access_object_role_get_delegate(role_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_object_role_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_role_get_static_delegate)});
      if (efl_access_object_role_set_static_delegate == null)
      efl_access_object_role_set_static_delegate = new efl_access_object_role_set_delegate(role_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_object_role_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_role_set_static_delegate)});
      if (efl_access_object_access_parent_get_static_delegate == null)
      efl_access_object_access_parent_get_static_delegate = new efl_access_object_access_parent_get_delegate(access_parent_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_object_access_parent_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_access_parent_get_static_delegate)});
      if (efl_access_object_access_parent_set_static_delegate == null)
      efl_access_object_access_parent_set_static_delegate = new efl_access_object_access_parent_set_delegate(access_parent_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_object_access_parent_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_access_parent_set_static_delegate)});
      if (efl_access_object_description_cb_set_static_delegate == null)
      efl_access_object_description_cb_set_static_delegate = new efl_access_object_description_cb_set_delegate(description_cb_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_object_description_cb_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_description_cb_set_static_delegate)});
      if (efl_access_object_gesture_cb_set_static_delegate == null)
      efl_access_object_gesture_cb_set_static_delegate = new efl_access_object_gesture_cb_set_delegate(gesture_cb_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_object_gesture_cb_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_gesture_cb_set_static_delegate)});
      if (efl_access_object_access_children_get_static_delegate == null)
      efl_access_object_access_children_get_static_delegate = new efl_access_object_access_children_get_delegate(access_children_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_object_access_children_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_access_children_get_static_delegate)});
      if (efl_access_object_role_name_get_static_delegate == null)
      efl_access_object_role_name_get_static_delegate = new efl_access_object_role_name_get_delegate(role_name_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_object_role_name_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_role_name_get_static_delegate)});
      if (efl_access_object_attributes_get_static_delegate == null)
      efl_access_object_attributes_get_static_delegate = new efl_access_object_attributes_get_delegate(attributes_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_object_attributes_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_attributes_get_static_delegate)});
      if (efl_access_object_reading_info_type_get_static_delegate == null)
      efl_access_object_reading_info_type_get_static_delegate = new efl_access_object_reading_info_type_get_delegate(reading_info_type_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_object_reading_info_type_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_reading_info_type_get_static_delegate)});
      if (efl_access_object_reading_info_type_set_static_delegate == null)
      efl_access_object_reading_info_type_set_static_delegate = new efl_access_object_reading_info_type_set_delegate(reading_info_type_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_object_reading_info_type_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_reading_info_type_set_static_delegate)});
      if (efl_access_object_index_in_parent_get_static_delegate == null)
      efl_access_object_index_in_parent_get_static_delegate = new efl_access_object_index_in_parent_get_delegate(index_in_parent_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_object_index_in_parent_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_index_in_parent_get_static_delegate)});
      if (efl_access_object_description_get_static_delegate == null)
      efl_access_object_description_get_static_delegate = new efl_access_object_description_get_delegate(description_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_object_description_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_description_get_static_delegate)});
      if (efl_access_object_description_set_static_delegate == null)
      efl_access_object_description_set_static_delegate = new efl_access_object_description_set_delegate(description_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_object_description_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_description_set_static_delegate)});
      if (efl_access_object_state_set_get_static_delegate == null)
      efl_access_object_state_set_get_static_delegate = new efl_access_object_state_set_get_delegate(state_set_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_object_state_set_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_state_set_get_static_delegate)});
      if (efl_access_object_can_highlight_get_static_delegate == null)
      efl_access_object_can_highlight_get_static_delegate = new efl_access_object_can_highlight_get_delegate(can_highlight_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_object_can_highlight_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_can_highlight_get_static_delegate)});
      if (efl_access_object_can_highlight_set_static_delegate == null)
      efl_access_object_can_highlight_set_static_delegate = new efl_access_object_can_highlight_set_delegate(can_highlight_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_object_can_highlight_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_can_highlight_set_static_delegate)});
      if (efl_access_object_translation_domain_get_static_delegate == null)
      efl_access_object_translation_domain_get_static_delegate = new efl_access_object_translation_domain_get_delegate(translation_domain_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_object_translation_domain_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_translation_domain_get_static_delegate)});
      if (efl_access_object_translation_domain_set_static_delegate == null)
      efl_access_object_translation_domain_set_static_delegate = new efl_access_object_translation_domain_set_delegate(translation_domain_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_object_translation_domain_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_translation_domain_set_static_delegate)});
      if (efl_access_object_gesture_do_static_delegate == null)
      efl_access_object_gesture_do_static_delegate = new efl_access_object_gesture_do_delegate(gesture_do);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_object_gesture_do"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_gesture_do_static_delegate)});
      if (efl_access_object_attribute_append_static_delegate == null)
      efl_access_object_attribute_append_static_delegate = new efl_access_object_attribute_append_delegate(attribute_append);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_object_attribute_append"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_attribute_append_static_delegate)});
      if (efl_access_object_attributes_clear_static_delegate == null)
      efl_access_object_attributes_clear_static_delegate = new efl_access_object_attributes_clear_delegate(attributes_clear);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_object_attributes_clear"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_attributes_clear_static_delegate)});
      if (efl_access_object_relationship_append_static_delegate == null)
      efl_access_object_relationship_append_static_delegate = new efl_access_object_relationship_append_delegate(relationship_append);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_object_relationship_append"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_relationship_append_static_delegate)});
      if (efl_access_object_relationship_remove_static_delegate == null)
      efl_access_object_relationship_remove_static_delegate = new efl_access_object_relationship_remove_delegate(relationship_remove);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_object_relationship_remove"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_relationship_remove_static_delegate)});
      if (efl_access_object_relationships_clear_static_delegate == null)
      efl_access_object_relationships_clear_static_delegate = new efl_access_object_relationships_clear_delegate(relationships_clear);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_object_relationships_clear"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_relationships_clear_static_delegate)});
      if (efl_access_object_state_notify_static_delegate == null)
      efl_access_object_state_notify_static_delegate = new efl_access_object_state_notify_delegate(state_notify);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_object_state_notify"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_state_notify_static_delegate)});
      if (efl_access_widget_action_elm_actions_get_static_delegate == null)
      efl_access_widget_action_elm_actions_get_static_delegate = new efl_access_widget_action_elm_actions_get_delegate(elm_actions_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_widget_action_elm_actions_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_widget_action_elm_actions_get_static_delegate)});
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
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Elm.Widget.Item.elm_widget_item_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Elm.Widget.Item.elm_widget_item_class_get();
   }


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool elm_wdg_item_tooltip_window_mode_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool elm_wdg_item_tooltip_window_mode_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<elm_wdg_item_tooltip_window_mode_get_api_delegate> elm_wdg_item_tooltip_window_mode_get_ptr = new Efl.Eo.FunctionWrapper<elm_wdg_item_tooltip_window_mode_get_api_delegate>(_Module, "elm_wdg_item_tooltip_window_mode_get");
    private static bool tooltip_window_mode_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function elm_wdg_item_tooltip_window_mode_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Item)wrapper).GetTooltipWindowMode();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return elm_wdg_item_tooltip_window_mode_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static elm_wdg_item_tooltip_window_mode_get_delegate elm_wdg_item_tooltip_window_mode_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool elm_wdg_item_tooltip_window_mode_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool disable);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool elm_wdg_item_tooltip_window_mode_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool disable);
    public static Efl.Eo.FunctionWrapper<elm_wdg_item_tooltip_window_mode_set_api_delegate> elm_wdg_item_tooltip_window_mode_set_ptr = new Efl.Eo.FunctionWrapper<elm_wdg_item_tooltip_window_mode_set_api_delegate>(_Module, "elm_wdg_item_tooltip_window_mode_set");
    private static bool tooltip_window_mode_set(System.IntPtr obj, System.IntPtr pd,  bool disable)
   {
      Eina.Log.Debug("function elm_wdg_item_tooltip_window_mode_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((Item)wrapper).SetTooltipWindowMode( disable);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return elm_wdg_item_tooltip_window_mode_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  disable);
      }
   }
   private static elm_wdg_item_tooltip_window_mode_set_delegate elm_wdg_item_tooltip_window_mode_set_static_delegate;


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate  System.String elm_wdg_item_tooltip_style_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate  System.String elm_wdg_item_tooltip_style_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<elm_wdg_item_tooltip_style_get_api_delegate> elm_wdg_item_tooltip_style_get_ptr = new Efl.Eo.FunctionWrapper<elm_wdg_item_tooltip_style_get_api_delegate>(_Module, "elm_wdg_item_tooltip_style_get");
    private static  System.String tooltip_style_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function elm_wdg_item_tooltip_style_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((Item)wrapper).GetTooltipStyle();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return elm_wdg_item_tooltip_style_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static elm_wdg_item_tooltip_style_get_delegate elm_wdg_item_tooltip_style_get_static_delegate;


    private delegate  void elm_wdg_item_tooltip_style_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String style);


    public delegate  void elm_wdg_item_tooltip_style_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String style);
    public static Efl.Eo.FunctionWrapper<elm_wdg_item_tooltip_style_set_api_delegate> elm_wdg_item_tooltip_style_set_ptr = new Efl.Eo.FunctionWrapper<elm_wdg_item_tooltip_style_set_api_delegate>(_Module, "elm_wdg_item_tooltip_style_set");
    private static  void tooltip_style_set(System.IntPtr obj, System.IntPtr pd,   System.String style)
   {
      Eina.Log.Debug("function elm_wdg_item_tooltip_style_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Item)wrapper).SetTooltipStyle( style);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         elm_wdg_item_tooltip_style_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  style);
      }
   }
   private static elm_wdg_item_tooltip_style_set_delegate elm_wdg_item_tooltip_style_set_static_delegate;


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate  System.String elm_wdg_item_cursor_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate  System.String elm_wdg_item_cursor_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<elm_wdg_item_cursor_get_api_delegate> elm_wdg_item_cursor_get_ptr = new Efl.Eo.FunctionWrapper<elm_wdg_item_cursor_get_api_delegate>(_Module, "elm_wdg_item_cursor_get");
    private static  System.String cursor_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function elm_wdg_item_cursor_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((Item)wrapper).GetCursor();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return elm_wdg_item_cursor_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static elm_wdg_item_cursor_get_delegate elm_wdg_item_cursor_get_static_delegate;


    private delegate  void elm_wdg_item_cursor_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String cursor);


    public delegate  void elm_wdg_item_cursor_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String cursor);
    public static Efl.Eo.FunctionWrapper<elm_wdg_item_cursor_set_api_delegate> elm_wdg_item_cursor_set_ptr = new Efl.Eo.FunctionWrapper<elm_wdg_item_cursor_set_api_delegate>(_Module, "elm_wdg_item_cursor_set");
    private static  void cursor_set(System.IntPtr obj, System.IntPtr pd,   System.String cursor)
   {
      Eina.Log.Debug("function elm_wdg_item_cursor_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Item)wrapper).SetCursor( cursor);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         elm_wdg_item_cursor_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cursor);
      }
   }
   private static elm_wdg_item_cursor_set_delegate elm_wdg_item_cursor_set_static_delegate;


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate  System.String elm_wdg_item_cursor_style_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate  System.String elm_wdg_item_cursor_style_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<elm_wdg_item_cursor_style_get_api_delegate> elm_wdg_item_cursor_style_get_ptr = new Efl.Eo.FunctionWrapper<elm_wdg_item_cursor_style_get_api_delegate>(_Module, "elm_wdg_item_cursor_style_get");
    private static  System.String cursor_style_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function elm_wdg_item_cursor_style_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((Item)wrapper).GetCursorStyle();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return elm_wdg_item_cursor_style_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static elm_wdg_item_cursor_style_get_delegate elm_wdg_item_cursor_style_get_static_delegate;


    private delegate  void elm_wdg_item_cursor_style_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String style);


    public delegate  void elm_wdg_item_cursor_style_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String style);
    public static Efl.Eo.FunctionWrapper<elm_wdg_item_cursor_style_set_api_delegate> elm_wdg_item_cursor_style_set_ptr = new Efl.Eo.FunctionWrapper<elm_wdg_item_cursor_style_set_api_delegate>(_Module, "elm_wdg_item_cursor_style_set");
    private static  void cursor_style_set(System.IntPtr obj, System.IntPtr pd,   System.String style)
   {
      Eina.Log.Debug("function elm_wdg_item_cursor_style_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Item)wrapper).SetCursorStyle( style);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         elm_wdg_item_cursor_style_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  style);
      }
   }
   private static elm_wdg_item_cursor_style_set_delegate elm_wdg_item_cursor_style_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool elm_wdg_item_cursor_engine_only_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool elm_wdg_item_cursor_engine_only_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<elm_wdg_item_cursor_engine_only_get_api_delegate> elm_wdg_item_cursor_engine_only_get_ptr = new Efl.Eo.FunctionWrapper<elm_wdg_item_cursor_engine_only_get_api_delegate>(_Module, "elm_wdg_item_cursor_engine_only_get");
    private static bool cursor_engine_only_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function elm_wdg_item_cursor_engine_only_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Item)wrapper).GetCursorEngineOnly();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return elm_wdg_item_cursor_engine_only_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static elm_wdg_item_cursor_engine_only_get_delegate elm_wdg_item_cursor_engine_only_get_static_delegate;


    private delegate  void elm_wdg_item_cursor_engine_only_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool engine_only);


    public delegate  void elm_wdg_item_cursor_engine_only_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool engine_only);
    public static Efl.Eo.FunctionWrapper<elm_wdg_item_cursor_engine_only_set_api_delegate> elm_wdg_item_cursor_engine_only_set_ptr = new Efl.Eo.FunctionWrapper<elm_wdg_item_cursor_engine_only_set_api_delegate>(_Module, "elm_wdg_item_cursor_engine_only_set");
    private static  void cursor_engine_only_set(System.IntPtr obj, System.IntPtr pd,  bool engine_only)
   {
      Eina.Log.Debug("function elm_wdg_item_cursor_engine_only_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Item)wrapper).SetCursorEngineOnly( engine_only);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         elm_wdg_item_cursor_engine_only_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  engine_only);
      }
   }
   private static elm_wdg_item_cursor_engine_only_set_delegate elm_wdg_item_cursor_engine_only_set_static_delegate;


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))] private delegate Efl.Canvas.Object elm_wdg_item_part_content_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String part);


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))] public delegate Efl.Canvas.Object elm_wdg_item_part_content_get_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String part);
    public static Efl.Eo.FunctionWrapper<elm_wdg_item_part_content_get_api_delegate> elm_wdg_item_part_content_get_ptr = new Efl.Eo.FunctionWrapper<elm_wdg_item_part_content_get_api_delegate>(_Module, "elm_wdg_item_part_content_get");
    private static Efl.Canvas.Object part_content_get(System.IntPtr obj, System.IntPtr pd,   System.String part)
   {
      Eina.Log.Debug("function elm_wdg_item_part_content_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    Efl.Canvas.Object _ret_var = default(Efl.Canvas.Object);
         try {
            _ret_var = ((Item)wrapper).GetPartContent( part);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return elm_wdg_item_part_content_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  part);
      }
   }
   private static elm_wdg_item_part_content_get_delegate elm_wdg_item_part_content_get_static_delegate;


    private delegate  void elm_wdg_item_part_content_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String part, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object content);


    public delegate  void elm_wdg_item_part_content_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String part, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object content);
    public static Efl.Eo.FunctionWrapper<elm_wdg_item_part_content_set_api_delegate> elm_wdg_item_part_content_set_ptr = new Efl.Eo.FunctionWrapper<elm_wdg_item_part_content_set_api_delegate>(_Module, "elm_wdg_item_part_content_set");
    private static  void part_content_set(System.IntPtr obj, System.IntPtr pd,   System.String part,  Efl.Canvas.Object content)
   {
      Eina.Log.Debug("function elm_wdg_item_part_content_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((Item)wrapper).SetPartContent( part,  content);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         elm_wdg_item_part_content_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  part,  content);
      }
   }
   private static elm_wdg_item_part_content_set_delegate elm_wdg_item_part_content_set_static_delegate;


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate  System.String elm_wdg_item_part_text_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String part);


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate  System.String elm_wdg_item_part_text_get_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String part);
    public static Efl.Eo.FunctionWrapper<elm_wdg_item_part_text_get_api_delegate> elm_wdg_item_part_text_get_ptr = new Efl.Eo.FunctionWrapper<elm_wdg_item_part_text_get_api_delegate>(_Module, "elm_wdg_item_part_text_get");
    private static  System.String part_text_get(System.IntPtr obj, System.IntPtr pd,   System.String part)
   {
      Eina.Log.Debug("function elm_wdg_item_part_text_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                     System.String _ret_var = default( System.String);
         try {
            _ret_var = ((Item)wrapper).GetPartText( part);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return elm_wdg_item_part_text_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  part);
      }
   }
   private static elm_wdg_item_part_text_get_delegate elm_wdg_item_part_text_get_static_delegate;


    private delegate  void elm_wdg_item_part_text_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String part,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String label);


    public delegate  void elm_wdg_item_part_text_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String part,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String label);
    public static Efl.Eo.FunctionWrapper<elm_wdg_item_part_text_set_api_delegate> elm_wdg_item_part_text_set_ptr = new Efl.Eo.FunctionWrapper<elm_wdg_item_part_text_set_api_delegate>(_Module, "elm_wdg_item_part_text_set");
    private static  void part_text_set(System.IntPtr obj, System.IntPtr pd,   System.String part,   System.String label)
   {
      Eina.Log.Debug("function elm_wdg_item_part_text_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((Item)wrapper).SetPartText( part,  label);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         elm_wdg_item_part_text_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  part,  label);
      }
   }
   private static elm_wdg_item_part_text_set_delegate elm_wdg_item_part_text_set_static_delegate;


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate  System.String elm_wdg_item_part_text_custom_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String part);


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate  System.String elm_wdg_item_part_text_custom_get_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String part);
    public static Efl.Eo.FunctionWrapper<elm_wdg_item_part_text_custom_get_api_delegate> elm_wdg_item_part_text_custom_get_ptr = new Efl.Eo.FunctionWrapper<elm_wdg_item_part_text_custom_get_api_delegate>(_Module, "elm_wdg_item_part_text_custom_get");
    private static  System.String part_text_custom_get(System.IntPtr obj, System.IntPtr pd,   System.String part)
   {
      Eina.Log.Debug("function elm_wdg_item_part_text_custom_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                     System.String _ret_var = default( System.String);
         try {
            _ret_var = ((Item)wrapper).GetPartTextCustom( part);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return elm_wdg_item_part_text_custom_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  part);
      }
   }
   private static elm_wdg_item_part_text_custom_get_delegate elm_wdg_item_part_text_custom_get_static_delegate;


    private delegate  void elm_wdg_item_part_text_custom_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String part,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String label);


    public delegate  void elm_wdg_item_part_text_custom_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String part,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String label);
    public static Efl.Eo.FunctionWrapper<elm_wdg_item_part_text_custom_set_api_delegate> elm_wdg_item_part_text_custom_set_ptr = new Efl.Eo.FunctionWrapper<elm_wdg_item_part_text_custom_set_api_delegate>(_Module, "elm_wdg_item_part_text_custom_set");
    private static  void part_text_custom_set(System.IntPtr obj, System.IntPtr pd,   System.String part,   System.String label)
   {
      Eina.Log.Debug("function elm_wdg_item_part_text_custom_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((Item)wrapper).SetPartTextCustom( part,  label);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         elm_wdg_item_part_text_custom_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  part,  label);
      }
   }
   private static elm_wdg_item_part_text_custom_set_delegate elm_wdg_item_part_text_custom_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool elm_wdg_item_focus_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool elm_wdg_item_focus_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<elm_wdg_item_focus_get_api_delegate> elm_wdg_item_focus_get_ptr = new Efl.Eo.FunctionWrapper<elm_wdg_item_focus_get_api_delegate>(_Module, "elm_wdg_item_focus_get");
    private static bool item_focus_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function elm_wdg_item_focus_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Item)wrapper).GetItemFocus();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return elm_wdg_item_focus_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static elm_wdg_item_focus_get_delegate elm_wdg_item_focus_get_static_delegate;


    private delegate  void elm_wdg_item_focus_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool focused);


    public delegate  void elm_wdg_item_focus_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool focused);
    public static Efl.Eo.FunctionWrapper<elm_wdg_item_focus_set_api_delegate> elm_wdg_item_focus_set_ptr = new Efl.Eo.FunctionWrapper<elm_wdg_item_focus_set_api_delegate>(_Module, "elm_wdg_item_focus_set");
    private static  void item_focus_set(System.IntPtr obj, System.IntPtr pd,  bool focused)
   {
      Eina.Log.Debug("function elm_wdg_item_focus_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Item)wrapper).SetItemFocus( focused);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         elm_wdg_item_focus_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  focused);
      }
   }
   private static elm_wdg_item_focus_set_delegate elm_wdg_item_focus_set_static_delegate;


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate  System.String elm_wdg_item_style_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate  System.String elm_wdg_item_style_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<elm_wdg_item_style_get_api_delegate> elm_wdg_item_style_get_ptr = new Efl.Eo.FunctionWrapper<elm_wdg_item_style_get_api_delegate>(_Module, "elm_wdg_item_style_get");
    private static  System.String style_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function elm_wdg_item_style_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((Item)wrapper).GetStyle();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return elm_wdg_item_style_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static elm_wdg_item_style_get_delegate elm_wdg_item_style_get_static_delegate;


    private delegate  void elm_wdg_item_style_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String style);


    public delegate  void elm_wdg_item_style_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String style);
    public static Efl.Eo.FunctionWrapper<elm_wdg_item_style_set_api_delegate> elm_wdg_item_style_set_ptr = new Efl.Eo.FunctionWrapper<elm_wdg_item_style_set_api_delegate>(_Module, "elm_wdg_item_style_set");
    private static  void style_set(System.IntPtr obj, System.IntPtr pd,   System.String style)
   {
      Eina.Log.Debug("function elm_wdg_item_style_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Item)wrapper).SetStyle( style);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         elm_wdg_item_style_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  style);
      }
   }
   private static elm_wdg_item_style_set_delegate elm_wdg_item_style_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool elm_wdg_item_disabled_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool elm_wdg_item_disabled_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<elm_wdg_item_disabled_get_api_delegate> elm_wdg_item_disabled_get_ptr = new Efl.Eo.FunctionWrapper<elm_wdg_item_disabled_get_api_delegate>(_Module, "elm_wdg_item_disabled_get");
    private static bool disabled_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function elm_wdg_item_disabled_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Item)wrapper).GetDisabled();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return elm_wdg_item_disabled_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static elm_wdg_item_disabled_get_delegate elm_wdg_item_disabled_get_static_delegate;


    private delegate  void elm_wdg_item_disabled_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool disable);


    public delegate  void elm_wdg_item_disabled_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool disable);
    public static Efl.Eo.FunctionWrapper<elm_wdg_item_disabled_set_api_delegate> elm_wdg_item_disabled_set_ptr = new Efl.Eo.FunctionWrapper<elm_wdg_item_disabled_set_api_delegate>(_Module, "elm_wdg_item_disabled_set");
    private static  void disabled_set(System.IntPtr obj, System.IntPtr pd,  bool disable)
   {
      Eina.Log.Debug("function elm_wdg_item_disabled_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Item)wrapper).SetDisabled( disable);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         elm_wdg_item_disabled_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  disable);
      }
   }
   private static elm_wdg_item_disabled_set_delegate elm_wdg_item_disabled_set_static_delegate;


    private delegate  System.IntPtr elm_wdg_item_access_order_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  System.IntPtr elm_wdg_item_access_order_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<elm_wdg_item_access_order_get_api_delegate> elm_wdg_item_access_order_get_ptr = new Efl.Eo.FunctionWrapper<elm_wdg_item_access_order_get_api_delegate>(_Module, "elm_wdg_item_access_order_get");
    private static  System.IntPtr access_order_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function elm_wdg_item_access_order_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.List<Efl.Canvas.Object> _ret_var = default(Eina.List<Efl.Canvas.Object>);
         try {
            _ret_var = ((Item)wrapper).GetAccessOrder();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var.Handle;
      } else {
         return elm_wdg_item_access_order_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static elm_wdg_item_access_order_get_delegate elm_wdg_item_access_order_get_static_delegate;


    private delegate  void elm_wdg_item_access_order_set_delegate(System.IntPtr obj, System.IntPtr pd,    System.IntPtr objs);


    public delegate  void elm_wdg_item_access_order_set_api_delegate(System.IntPtr obj,    System.IntPtr objs);
    public static Efl.Eo.FunctionWrapper<elm_wdg_item_access_order_set_api_delegate> elm_wdg_item_access_order_set_ptr = new Efl.Eo.FunctionWrapper<elm_wdg_item_access_order_set_api_delegate>(_Module, "elm_wdg_item_access_order_set");
    private static  void access_order_set(System.IntPtr obj, System.IntPtr pd,   System.IntPtr objs)
   {
      Eina.Log.Debug("function elm_wdg_item_access_order_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_objs = new Eina.List<Efl.Canvas.Object>(objs, true, false);
                     
         try {
            ((Item)wrapper).SetAccessOrder( _in_objs);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         elm_wdg_item_access_order_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  objs);
      }
   }
   private static elm_wdg_item_access_order_set_delegate elm_wdg_item_access_order_set_static_delegate;


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))] private delegate Efl.Canvas.Object elm_wdg_item_widget_get_delegate(System.IntPtr obj, System.IntPtr pd);


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))] public delegate Efl.Canvas.Object elm_wdg_item_widget_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<elm_wdg_item_widget_get_api_delegate> elm_wdg_item_widget_get_ptr = new Efl.Eo.FunctionWrapper<elm_wdg_item_widget_get_api_delegate>(_Module, "elm_wdg_item_widget_get");
    private static Efl.Canvas.Object widget_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function elm_wdg_item_widget_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Canvas.Object _ret_var = default(Efl.Canvas.Object);
         try {
            _ret_var = ((Item)wrapper).GetWidget();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return elm_wdg_item_widget_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static elm_wdg_item_widget_get_delegate elm_wdg_item_widget_get_static_delegate;


    private delegate  void elm_wdg_item_pre_notify_del_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  void elm_wdg_item_pre_notify_del_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<elm_wdg_item_pre_notify_del_api_delegate> elm_wdg_item_pre_notify_del_ptr = new Efl.Eo.FunctionWrapper<elm_wdg_item_pre_notify_del_api_delegate>(_Module, "elm_wdg_item_pre_notify_del");
    private static  void pre_notify_del(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function elm_wdg_item_pre_notify_del was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Item)wrapper).DelPreNotify();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         elm_wdg_item_pre_notify_del_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static elm_wdg_item_pre_notify_del_delegate elm_wdg_item_pre_notify_del_static_delegate;


    private delegate  void elm_wdg_item_tooltip_text_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String text);


    public delegate  void elm_wdg_item_tooltip_text_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String text);
    public static Efl.Eo.FunctionWrapper<elm_wdg_item_tooltip_text_set_api_delegate> elm_wdg_item_tooltip_text_set_ptr = new Efl.Eo.FunctionWrapper<elm_wdg_item_tooltip_text_set_api_delegate>(_Module, "elm_wdg_item_tooltip_text_set");
    private static  void tooltip_text_set(System.IntPtr obj, System.IntPtr pd,   System.String text)
   {
      Eina.Log.Debug("function elm_wdg_item_tooltip_text_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Item)wrapper).SetTooltipText( text);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         elm_wdg_item_tooltip_text_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  text);
      }
   }
   private static elm_wdg_item_tooltip_text_set_delegate elm_wdg_item_tooltip_text_set_static_delegate;


    private delegate  void elm_wdg_item_tooltip_translatable_text_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String text);


    public delegate  void elm_wdg_item_tooltip_translatable_text_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String text);
    public static Efl.Eo.FunctionWrapper<elm_wdg_item_tooltip_translatable_text_set_api_delegate> elm_wdg_item_tooltip_translatable_text_set_ptr = new Efl.Eo.FunctionWrapper<elm_wdg_item_tooltip_translatable_text_set_api_delegate>(_Module, "elm_wdg_item_tooltip_translatable_text_set");
    private static  void tooltip_translatable_text_set(System.IntPtr obj, System.IntPtr pd,   System.String text)
   {
      Eina.Log.Debug("function elm_wdg_item_tooltip_translatable_text_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Item)wrapper).SetTooltipTranslatableText( text);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         elm_wdg_item_tooltip_translatable_text_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  text);
      }
   }
   private static elm_wdg_item_tooltip_translatable_text_set_delegate elm_wdg_item_tooltip_translatable_text_set_static_delegate;


    private delegate  void elm_wdg_item_tooltip_unset_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  void elm_wdg_item_tooltip_unset_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<elm_wdg_item_tooltip_unset_api_delegate> elm_wdg_item_tooltip_unset_ptr = new Efl.Eo.FunctionWrapper<elm_wdg_item_tooltip_unset_api_delegate>(_Module, "elm_wdg_item_tooltip_unset");
    private static  void tooltip_unset(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function elm_wdg_item_tooltip_unset was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Item)wrapper).UnsetTooltip();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         elm_wdg_item_tooltip_unset_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static elm_wdg_item_tooltip_unset_delegate elm_wdg_item_tooltip_unset_static_delegate;


    private delegate  void elm_wdg_item_cursor_unset_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  void elm_wdg_item_cursor_unset_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<elm_wdg_item_cursor_unset_api_delegate> elm_wdg_item_cursor_unset_ptr = new Efl.Eo.FunctionWrapper<elm_wdg_item_cursor_unset_api_delegate>(_Module, "elm_wdg_item_cursor_unset");
    private static  void cursor_unset(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function elm_wdg_item_cursor_unset was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Item)wrapper).UnsetCursor();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         elm_wdg_item_cursor_unset_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static elm_wdg_item_cursor_unset_delegate elm_wdg_item_cursor_unset_static_delegate;


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))] private delegate Efl.Canvas.Object elm_wdg_item_part_content_unset_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String part);


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))] public delegate Efl.Canvas.Object elm_wdg_item_part_content_unset_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String part);
    public static Efl.Eo.FunctionWrapper<elm_wdg_item_part_content_unset_api_delegate> elm_wdg_item_part_content_unset_ptr = new Efl.Eo.FunctionWrapper<elm_wdg_item_part_content_unset_api_delegate>(_Module, "elm_wdg_item_part_content_unset");
    private static Efl.Canvas.Object part_content_unset(System.IntPtr obj, System.IntPtr pd,   System.String part)
   {
      Eina.Log.Debug("function elm_wdg_item_part_content_unset was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    Efl.Canvas.Object _ret_var = default(Efl.Canvas.Object);
         try {
            _ret_var = ((Item)wrapper).UnsetPartContent( part);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return elm_wdg_item_part_content_unset_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  part);
      }
   }
   private static elm_wdg_item_part_content_unset_delegate elm_wdg_item_part_content_unset_static_delegate;


    private delegate  void elm_wdg_item_part_text_custom_update_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  void elm_wdg_item_part_text_custom_update_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<elm_wdg_item_part_text_custom_update_api_delegate> elm_wdg_item_part_text_custom_update_ptr = new Efl.Eo.FunctionWrapper<elm_wdg_item_part_text_custom_update_api_delegate>(_Module, "elm_wdg_item_part_text_custom_update");
    private static  void part_text_custom_update(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function elm_wdg_item_part_text_custom_update was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Item)wrapper).UpdatePartTextCustom();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         elm_wdg_item_part_text_custom_update_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static elm_wdg_item_part_text_custom_update_delegate elm_wdg_item_part_text_custom_update_static_delegate;


    private delegate  void elm_wdg_item_signal_callback_add_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String emission,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String source,   ElmObjectItemSignalCb func,    System.IntPtr data);


    public delegate  void elm_wdg_item_signal_callback_add_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String emission,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String source,   ElmObjectItemSignalCb func,    System.IntPtr data);
    public static Efl.Eo.FunctionWrapper<elm_wdg_item_signal_callback_add_api_delegate> elm_wdg_item_signal_callback_add_ptr = new Efl.Eo.FunctionWrapper<elm_wdg_item_signal_callback_add_api_delegate>(_Module, "elm_wdg_item_signal_callback_add");
    private static  void signal_callback_add(System.IntPtr obj, System.IntPtr pd,   System.String emission,   System.String source,  ElmObjectItemSignalCb func,   System.IntPtr data)
   {
      Eina.Log.Debug("function elm_wdg_item_signal_callback_add was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                          
         try {
            ((Item)wrapper).AddSignalCallback( emission,  source,  func,  data);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         elm_wdg_item_signal_callback_add_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  emission,  source,  func,  data);
      }
   }
   private static elm_wdg_item_signal_callback_add_delegate elm_wdg_item_signal_callback_add_static_delegate;


    private delegate  System.IntPtr elm_wdg_item_signal_callback_del_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String emission,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String source,   ElmObjectItemSignalCb func);


    public delegate  System.IntPtr elm_wdg_item_signal_callback_del_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String emission,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String source,   ElmObjectItemSignalCb func);
    public static Efl.Eo.FunctionWrapper<elm_wdg_item_signal_callback_del_api_delegate> elm_wdg_item_signal_callback_del_ptr = new Efl.Eo.FunctionWrapper<elm_wdg_item_signal_callback_del_api_delegate>(_Module, "elm_wdg_item_signal_callback_del");
    private static  System.IntPtr signal_callback_del(System.IntPtr obj, System.IntPtr pd,   System.String emission,   System.String source,  ElmObjectItemSignalCb func)
   {
      Eina.Log.Debug("function elm_wdg_item_signal_callback_del was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                         System.IntPtr _ret_var = default( System.IntPtr);
         try {
            _ret_var = ((Item)wrapper).DelSignalCallback( emission,  source,  func);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                          return _ret_var;
      } else {
         return elm_wdg_item_signal_callback_del_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  emission,  source,  func);
      }
   }
   private static elm_wdg_item_signal_callback_del_delegate elm_wdg_item_signal_callback_del_static_delegate;


    private delegate  void elm_wdg_item_signal_emit_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String emission,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String source);


    public delegate  void elm_wdg_item_signal_emit_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String emission,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String source);
    public static Efl.Eo.FunctionWrapper<elm_wdg_item_signal_emit_api_delegate> elm_wdg_item_signal_emit_ptr = new Efl.Eo.FunctionWrapper<elm_wdg_item_signal_emit_api_delegate>(_Module, "elm_wdg_item_signal_emit");
    private static  void signal_emit(System.IntPtr obj, System.IntPtr pd,   System.String emission,   System.String source)
   {
      Eina.Log.Debug("function elm_wdg_item_signal_emit was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((Item)wrapper).EmitSignal( emission,  source);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         elm_wdg_item_signal_emit_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  emission,  source);
      }
   }
   private static elm_wdg_item_signal_emit_delegate elm_wdg_item_signal_emit_static_delegate;


    private delegate  void elm_wdg_item_access_info_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String txt);


    public delegate  void elm_wdg_item_access_info_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String txt);
    public static Efl.Eo.FunctionWrapper<elm_wdg_item_access_info_set_api_delegate> elm_wdg_item_access_info_set_ptr = new Efl.Eo.FunctionWrapper<elm_wdg_item_access_info_set_api_delegate>(_Module, "elm_wdg_item_access_info_set");
    private static  void access_info_set(System.IntPtr obj, System.IntPtr pd,   System.String txt)
   {
      Eina.Log.Debug("function elm_wdg_item_access_info_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Item)wrapper).SetAccessInfo( txt);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         elm_wdg_item_access_info_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  txt);
      }
   }
   private static elm_wdg_item_access_info_set_delegate elm_wdg_item_access_info_set_static_delegate;


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))] private delegate Efl.Canvas.Object elm_wdg_item_access_object_get_delegate(System.IntPtr obj, System.IntPtr pd);


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))] public delegate Efl.Canvas.Object elm_wdg_item_access_object_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<elm_wdg_item_access_object_get_api_delegate> elm_wdg_item_access_object_get_ptr = new Efl.Eo.FunctionWrapper<elm_wdg_item_access_object_get_api_delegate>(_Module, "elm_wdg_item_access_object_get");
    private static Efl.Canvas.Object access_object_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function elm_wdg_item_access_object_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Canvas.Object _ret_var = default(Efl.Canvas.Object);
         try {
            _ret_var = ((Item)wrapper).GetAccessObject();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return elm_wdg_item_access_object_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static elm_wdg_item_access_object_get_delegate elm_wdg_item_access_object_get_static_delegate;


    private delegate  void elm_wdg_item_domain_translatable_part_text_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String part,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String domain,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String label);


    public delegate  void elm_wdg_item_domain_translatable_part_text_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String part,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String domain,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String label);
    public static Efl.Eo.FunctionWrapper<elm_wdg_item_domain_translatable_part_text_set_api_delegate> elm_wdg_item_domain_translatable_part_text_set_ptr = new Efl.Eo.FunctionWrapper<elm_wdg_item_domain_translatable_part_text_set_api_delegate>(_Module, "elm_wdg_item_domain_translatable_part_text_set");
    private static  void domain_translatable_part_text_set(System.IntPtr obj, System.IntPtr pd,   System.String part,   System.String domain,   System.String label)
   {
      Eina.Log.Debug("function elm_wdg_item_domain_translatable_part_text_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                        
         try {
            ((Item)wrapper).SetDomainTranslatablePartText( part,  domain,  label);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                } else {
         elm_wdg_item_domain_translatable_part_text_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  part,  domain,  label);
      }
   }
   private static elm_wdg_item_domain_translatable_part_text_set_delegate elm_wdg_item_domain_translatable_part_text_set_static_delegate;


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate  System.String elm_wdg_item_translatable_part_text_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String part);


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate  System.String elm_wdg_item_translatable_part_text_get_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String part);
    public static Efl.Eo.FunctionWrapper<elm_wdg_item_translatable_part_text_get_api_delegate> elm_wdg_item_translatable_part_text_get_ptr = new Efl.Eo.FunctionWrapper<elm_wdg_item_translatable_part_text_get_api_delegate>(_Module, "elm_wdg_item_translatable_part_text_get");
    private static  System.String translatable_part_text_get(System.IntPtr obj, System.IntPtr pd,   System.String part)
   {
      Eina.Log.Debug("function elm_wdg_item_translatable_part_text_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                     System.String _ret_var = default( System.String);
         try {
            _ret_var = ((Item)wrapper).GetTranslatablePartText( part);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return elm_wdg_item_translatable_part_text_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  part);
      }
   }
   private static elm_wdg_item_translatable_part_text_get_delegate elm_wdg_item_translatable_part_text_get_static_delegate;


    private delegate  void elm_wdg_item_translate_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  void elm_wdg_item_translate_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<elm_wdg_item_translate_api_delegate> elm_wdg_item_translate_ptr = new Efl.Eo.FunctionWrapper<elm_wdg_item_translate_api_delegate>(_Module, "elm_wdg_item_translate");
    private static  void translate(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function elm_wdg_item_translate was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Item)wrapper).Translate();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         elm_wdg_item_translate_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static elm_wdg_item_translate_delegate elm_wdg_item_translate_static_delegate;


    private delegate  void elm_wdg_item_domain_part_text_translatable_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String part,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String domain,  [MarshalAs(UnmanagedType.U1)]  bool translatable);


    public delegate  void elm_wdg_item_domain_part_text_translatable_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String part,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String domain,  [MarshalAs(UnmanagedType.U1)]  bool translatable);
    public static Efl.Eo.FunctionWrapper<elm_wdg_item_domain_part_text_translatable_set_api_delegate> elm_wdg_item_domain_part_text_translatable_set_ptr = new Efl.Eo.FunctionWrapper<elm_wdg_item_domain_part_text_translatable_set_api_delegate>(_Module, "elm_wdg_item_domain_part_text_translatable_set");
    private static  void domain_part_text_translatable_set(System.IntPtr obj, System.IntPtr pd,   System.String part,   System.String domain,  bool translatable)
   {
      Eina.Log.Debug("function elm_wdg_item_domain_part_text_translatable_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                        
         try {
            ((Item)wrapper).SetDomainPartTextTranslatable( part,  domain,  translatable);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                } else {
         elm_wdg_item_domain_part_text_translatable_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  part,  domain,  translatable);
      }
   }
   private static elm_wdg_item_domain_part_text_translatable_set_delegate elm_wdg_item_domain_part_text_translatable_set_static_delegate;


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))] private delegate Efl.Canvas.Object elm_wdg_item_track_delegate(System.IntPtr obj, System.IntPtr pd);


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))] public delegate Efl.Canvas.Object elm_wdg_item_track_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<elm_wdg_item_track_api_delegate> elm_wdg_item_track_ptr = new Efl.Eo.FunctionWrapper<elm_wdg_item_track_api_delegate>(_Module, "elm_wdg_item_track");
    private static Efl.Canvas.Object track(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function elm_wdg_item_track was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Canvas.Object _ret_var = default(Efl.Canvas.Object);
         try {
            _ret_var = ((Item)wrapper).Track();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return elm_wdg_item_track_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static elm_wdg_item_track_delegate elm_wdg_item_track_static_delegate;


    private delegate  void elm_wdg_item_untrack_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  void elm_wdg_item_untrack_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<elm_wdg_item_untrack_api_delegate> elm_wdg_item_untrack_ptr = new Efl.Eo.FunctionWrapper<elm_wdg_item_untrack_api_delegate>(_Module, "elm_wdg_item_untrack");
    private static  void untrack(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function elm_wdg_item_untrack was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Item)wrapper).Untrack();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         elm_wdg_item_untrack_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static elm_wdg_item_untrack_delegate elm_wdg_item_untrack_static_delegate;


    private delegate  int elm_wdg_item_track_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  int elm_wdg_item_track_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<elm_wdg_item_track_get_api_delegate> elm_wdg_item_track_get_ptr = new Efl.Eo.FunctionWrapper<elm_wdg_item_track_get_api_delegate>(_Module, "elm_wdg_item_track_get");
    private static  int track_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function elm_wdg_item_track_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   int _ret_var = default( int);
         try {
            _ret_var = ((Item)wrapper).GetTrack();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return elm_wdg_item_track_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static elm_wdg_item_track_get_delegate elm_wdg_item_track_get_static_delegate;


    private delegate  void elm_wdg_item_track_cancel_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  void elm_wdg_item_track_cancel_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<elm_wdg_item_track_cancel_api_delegate> elm_wdg_item_track_cancel_ptr = new Efl.Eo.FunctionWrapper<elm_wdg_item_track_cancel_api_delegate>(_Module, "elm_wdg_item_track_cancel");
    private static  void track_cancel(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function elm_wdg_item_track_cancel was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Item)wrapper).TrackCancel();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         elm_wdg_item_track_cancel_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static elm_wdg_item_track_cancel_delegate elm_wdg_item_track_cancel_static_delegate;


    private delegate  void elm_wdg_item_del_cb_set_delegate(System.IntPtr obj, System.IntPtr pd,   EvasSmartCb del_cb);


    public delegate  void elm_wdg_item_del_cb_set_api_delegate(System.IntPtr obj,   EvasSmartCb del_cb);
    public static Efl.Eo.FunctionWrapper<elm_wdg_item_del_cb_set_api_delegate> elm_wdg_item_del_cb_set_ptr = new Efl.Eo.FunctionWrapper<elm_wdg_item_del_cb_set_api_delegate>(_Module, "elm_wdg_item_del_cb_set");
    private static  void del_cb_set(System.IntPtr obj, System.IntPtr pd,  EvasSmartCb del_cb)
   {
      Eina.Log.Debug("function elm_wdg_item_del_cb_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Item)wrapper).SetDelCb( del_cb);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         elm_wdg_item_del_cb_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  del_cb);
      }
   }
   private static elm_wdg_item_del_cb_set_delegate elm_wdg_item_del_cb_set_static_delegate;


    private delegate  void elm_wdg_item_tooltip_content_cb_set_delegate(System.IntPtr obj, System.IntPtr pd,   ElmTooltipItemContentCb func,    System.IntPtr data,   EvasSmartCb del_cb);


    public delegate  void elm_wdg_item_tooltip_content_cb_set_api_delegate(System.IntPtr obj,   ElmTooltipItemContentCb func,    System.IntPtr data,   EvasSmartCb del_cb);
    public static Efl.Eo.FunctionWrapper<elm_wdg_item_tooltip_content_cb_set_api_delegate> elm_wdg_item_tooltip_content_cb_set_ptr = new Efl.Eo.FunctionWrapper<elm_wdg_item_tooltip_content_cb_set_api_delegate>(_Module, "elm_wdg_item_tooltip_content_cb_set");
    private static  void tooltip_content_cb_set(System.IntPtr obj, System.IntPtr pd,  ElmTooltipItemContentCb func,   System.IntPtr data,  EvasSmartCb del_cb)
   {
      Eina.Log.Debug("function elm_wdg_item_tooltip_content_cb_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                        
         try {
            ((Item)wrapper).SetTooltipContentCb( func,  data,  del_cb);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                } else {
         elm_wdg_item_tooltip_content_cb_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  func,  data,  del_cb);
      }
   }
   private static elm_wdg_item_tooltip_content_cb_set_delegate elm_wdg_item_tooltip_content_cb_set_static_delegate;


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))] private delegate Efl.Canvas.Object elm_wdg_item_access_register_delegate(System.IntPtr obj, System.IntPtr pd);


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))] public delegate Efl.Canvas.Object elm_wdg_item_access_register_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<elm_wdg_item_access_register_api_delegate> elm_wdg_item_access_register_ptr = new Efl.Eo.FunctionWrapper<elm_wdg_item_access_register_api_delegate>(_Module, "elm_wdg_item_access_register");
    private static Efl.Canvas.Object access_register(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function elm_wdg_item_access_register was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Canvas.Object _ret_var = default(Efl.Canvas.Object);
         try {
            _ret_var = ((Item)wrapper).AccessRegister();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return elm_wdg_item_access_register_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static elm_wdg_item_access_register_delegate elm_wdg_item_access_register_static_delegate;


    private delegate  void elm_wdg_item_access_unregister_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  void elm_wdg_item_access_unregister_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<elm_wdg_item_access_unregister_api_delegate> elm_wdg_item_access_unregister_ptr = new Efl.Eo.FunctionWrapper<elm_wdg_item_access_unregister_api_delegate>(_Module, "elm_wdg_item_access_unregister");
    private static  void access_unregister(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function elm_wdg_item_access_unregister was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Item)wrapper).AccessUnregister();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         elm_wdg_item_access_unregister_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static elm_wdg_item_access_unregister_delegate elm_wdg_item_access_unregister_static_delegate;


    private delegate  void elm_wdg_item_access_order_unset_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  void elm_wdg_item_access_order_unset_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<elm_wdg_item_access_order_unset_api_delegate> elm_wdg_item_access_order_unset_ptr = new Efl.Eo.FunctionWrapper<elm_wdg_item_access_order_unset_api_delegate>(_Module, "elm_wdg_item_access_order_unset");
    private static  void access_order_unset(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function elm_wdg_item_access_order_unset was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Item)wrapper).UnsetAccessOrder();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         elm_wdg_item_access_order_unset_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static elm_wdg_item_access_order_unset_delegate elm_wdg_item_access_order_unset_static_delegate;


    private delegate  void elm_wdg_item_disable_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  void elm_wdg_item_disable_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<elm_wdg_item_disable_api_delegate> elm_wdg_item_disable_ptr = new Efl.Eo.FunctionWrapper<elm_wdg_item_disable_api_delegate>(_Module, "elm_wdg_item_disable");
    private static  void disable(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function elm_wdg_item_disable was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Item)wrapper).Disable();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         elm_wdg_item_disable_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static elm_wdg_item_disable_delegate elm_wdg_item_disable_static_delegate;


    private delegate  void elm_wdg_item_del_pre_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  void elm_wdg_item_del_pre_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<elm_wdg_item_del_pre_api_delegate> elm_wdg_item_del_pre_ptr = new Efl.Eo.FunctionWrapper<elm_wdg_item_del_pre_api_delegate>(_Module, "elm_wdg_item_del_pre");
    private static  void del_pre(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function elm_wdg_item_del_pre was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Item)wrapper).DelPre();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         elm_wdg_item_del_pre_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static elm_wdg_item_del_pre_delegate elm_wdg_item_del_pre_static_delegate;


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))] private delegate Efl.Canvas.Object elm_wdg_item_focus_next_object_get_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.Focus.Direction dir);


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))] public delegate Efl.Canvas.Object elm_wdg_item_focus_next_object_get_api_delegate(System.IntPtr obj,   Efl.Ui.Focus.Direction dir);
    public static Efl.Eo.FunctionWrapper<elm_wdg_item_focus_next_object_get_api_delegate> elm_wdg_item_focus_next_object_get_ptr = new Efl.Eo.FunctionWrapper<elm_wdg_item_focus_next_object_get_api_delegate>(_Module, "elm_wdg_item_focus_next_object_get");
    private static Efl.Canvas.Object focus_next_object_get(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.Focus.Direction dir)
   {
      Eina.Log.Debug("function elm_wdg_item_focus_next_object_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    Efl.Canvas.Object _ret_var = default(Efl.Canvas.Object);
         try {
            _ret_var = ((Item)wrapper).GetFocusNextObject( dir);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return elm_wdg_item_focus_next_object_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  dir);
      }
   }
   private static elm_wdg_item_focus_next_object_get_delegate elm_wdg_item_focus_next_object_get_static_delegate;


    private delegate  void elm_wdg_item_focus_next_object_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object next,   Efl.Ui.Focus.Direction dir);


    public delegate  void elm_wdg_item_focus_next_object_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object next,   Efl.Ui.Focus.Direction dir);
    public static Efl.Eo.FunctionWrapper<elm_wdg_item_focus_next_object_set_api_delegate> elm_wdg_item_focus_next_object_set_ptr = new Efl.Eo.FunctionWrapper<elm_wdg_item_focus_next_object_set_api_delegate>(_Module, "elm_wdg_item_focus_next_object_set");
    private static  void focus_next_object_set(System.IntPtr obj, System.IntPtr pd,  Efl.Canvas.Object next,  Efl.Ui.Focus.Direction dir)
   {
      Eina.Log.Debug("function elm_wdg_item_focus_next_object_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((Item)wrapper).SetFocusNextObject( next,  dir);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         elm_wdg_item_focus_next_object_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  next,  dir);
      }
   }
   private static elm_wdg_item_focus_next_object_set_delegate elm_wdg_item_focus_next_object_set_static_delegate;


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Elm.Widget.Item, Efl.Eo.NonOwnTag>))] private delegate Elm.Widget.Item elm_wdg_item_focus_next_item_get_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.Focus.Direction dir);


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Elm.Widget.Item, Efl.Eo.NonOwnTag>))] public delegate Elm.Widget.Item elm_wdg_item_focus_next_item_get_api_delegate(System.IntPtr obj,   Efl.Ui.Focus.Direction dir);
    public static Efl.Eo.FunctionWrapper<elm_wdg_item_focus_next_item_get_api_delegate> elm_wdg_item_focus_next_item_get_ptr = new Efl.Eo.FunctionWrapper<elm_wdg_item_focus_next_item_get_api_delegate>(_Module, "elm_wdg_item_focus_next_item_get");
    private static Elm.Widget.Item focus_next_item_get(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.Focus.Direction dir)
   {
      Eina.Log.Debug("function elm_wdg_item_focus_next_item_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    Elm.Widget.Item _ret_var = default(Elm.Widget.Item);
         try {
            _ret_var = ((Item)wrapper).GetFocusNextItem( dir);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return elm_wdg_item_focus_next_item_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  dir);
      }
   }
   private static elm_wdg_item_focus_next_item_get_delegate elm_wdg_item_focus_next_item_get_static_delegate;


    private delegate  void elm_wdg_item_focus_next_item_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Elm.Widget.Item, Efl.Eo.NonOwnTag>))]  Elm.Widget.Item next_item,   Efl.Ui.Focus.Direction dir);


    public delegate  void elm_wdg_item_focus_next_item_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Elm.Widget.Item, Efl.Eo.NonOwnTag>))]  Elm.Widget.Item next_item,   Efl.Ui.Focus.Direction dir);
    public static Efl.Eo.FunctionWrapper<elm_wdg_item_focus_next_item_set_api_delegate> elm_wdg_item_focus_next_item_set_ptr = new Efl.Eo.FunctionWrapper<elm_wdg_item_focus_next_item_set_api_delegate>(_Module, "elm_wdg_item_focus_next_item_set");
    private static  void focus_next_item_set(System.IntPtr obj, System.IntPtr pd,  Elm.Widget.Item next_item,  Efl.Ui.Focus.Direction dir)
   {
      Eina.Log.Debug("function elm_wdg_item_focus_next_item_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((Item)wrapper).SetFocusNextItem( next_item,  dir);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         elm_wdg_item_focus_next_item_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  next_item,  dir);
      }
   }
   private static elm_wdg_item_focus_next_item_set_delegate elm_wdg_item_focus_next_item_set_static_delegate;


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate  System.String efl_access_action_name_get_delegate(System.IntPtr obj, System.IntPtr pd,    int id);


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate  System.String efl_access_action_name_get_api_delegate(System.IntPtr obj,    int id);
    public static Efl.Eo.FunctionWrapper<efl_access_action_name_get_api_delegate> efl_access_action_name_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_action_name_get_api_delegate>(_Module, "efl_access_action_name_get");
    private static  System.String action_name_get(System.IntPtr obj, System.IntPtr pd,   int id)
   {
      Eina.Log.Debug("function efl_access_action_name_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                     System.String _ret_var = default( System.String);
         try {
            _ret_var = ((Item)wrapper).GetActionName( id);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_access_action_name_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  id);
      }
   }
   private static efl_access_action_name_get_delegate efl_access_action_name_get_static_delegate;


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate  System.String efl_access_action_localized_name_get_delegate(System.IntPtr obj, System.IntPtr pd,    int id);


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate  System.String efl_access_action_localized_name_get_api_delegate(System.IntPtr obj,    int id);
    public static Efl.Eo.FunctionWrapper<efl_access_action_localized_name_get_api_delegate> efl_access_action_localized_name_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_action_localized_name_get_api_delegate>(_Module, "efl_access_action_localized_name_get");
    private static  System.String action_localized_name_get(System.IntPtr obj, System.IntPtr pd,   int id)
   {
      Eina.Log.Debug("function efl_access_action_localized_name_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                     System.String _ret_var = default( System.String);
         try {
            _ret_var = ((Item)wrapper).GetActionLocalizedName( id);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_access_action_localized_name_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  id);
      }
   }
   private static efl_access_action_localized_name_get_delegate efl_access_action_localized_name_get_static_delegate;


    private delegate  System.IntPtr efl_access_action_actions_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  System.IntPtr efl_access_action_actions_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_access_action_actions_get_api_delegate> efl_access_action_actions_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_action_actions_get_api_delegate>(_Module, "efl_access_action_actions_get");
    private static  System.IntPtr actions_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_action_actions_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.List<Efl.Access.ActionData> _ret_var = default(Eina.List<Efl.Access.ActionData>);
         try {
            _ret_var = ((Item)wrapper).GetActions();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var.Handle;
      } else {
         return efl_access_action_actions_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_access_action_actions_get_delegate efl_access_action_actions_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_access_action_do_delegate(System.IntPtr obj, System.IntPtr pd,    int id);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_access_action_do_api_delegate(System.IntPtr obj,    int id);
    public static Efl.Eo.FunctionWrapper<efl_access_action_do_api_delegate> efl_access_action_do_ptr = new Efl.Eo.FunctionWrapper<efl_access_action_do_api_delegate>(_Module, "efl_access_action_do");
    private static bool action_do(System.IntPtr obj, System.IntPtr pd,   int id)
   {
      Eina.Log.Debug("function efl_access_action_do was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((Item)wrapper).ActionDo( id);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_access_action_do_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  id);
      }
   }
   private static efl_access_action_do_delegate efl_access_action_do_static_delegate;


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringPassOwnershipMarshaler))] private delegate  System.String efl_access_action_keybinding_get_delegate(System.IntPtr obj, System.IntPtr pd,    int id);


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringPassOwnershipMarshaler))] public delegate  System.String efl_access_action_keybinding_get_api_delegate(System.IntPtr obj,    int id);
    public static Efl.Eo.FunctionWrapper<efl_access_action_keybinding_get_api_delegate> efl_access_action_keybinding_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_action_keybinding_get_api_delegate>(_Module, "efl_access_action_keybinding_get");
    private static  System.String action_keybinding_get(System.IntPtr obj, System.IntPtr pd,   int id)
   {
      Eina.Log.Debug("function efl_access_action_keybinding_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                     System.String _ret_var = default( System.String);
         try {
            _ret_var = ((Item)wrapper).GetActionKeybinding( id);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_access_action_keybinding_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  id);
      }
   }
   private static efl_access_action_keybinding_get_delegate efl_access_action_keybinding_get_static_delegate;


    private delegate  int efl_access_component_z_order_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  int efl_access_component_z_order_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_access_component_z_order_get_api_delegate> efl_access_component_z_order_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_component_z_order_get_api_delegate>(_Module, "efl_access_component_z_order_get");
    private static  int z_order_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_component_z_order_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   int _ret_var = default( int);
         try {
            _ret_var = ((Item)wrapper).GetZOrder();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_access_component_z_order_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_access_component_z_order_get_delegate efl_access_component_z_order_get_static_delegate;


    private delegate Eina.Rect_StructInternal efl_access_component_extents_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool screen_coords);


    public delegate Eina.Rect_StructInternal efl_access_component_extents_get_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool screen_coords);
    public static Efl.Eo.FunctionWrapper<efl_access_component_extents_get_api_delegate> efl_access_component_extents_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_component_extents_get_api_delegate>(_Module, "efl_access_component_extents_get");
    private static Eina.Rect_StructInternal extents_get(System.IntPtr obj, System.IntPtr pd,  bool screen_coords)
   {
      Eina.Log.Debug("function efl_access_component_extents_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    Eina.Rect _ret_var = default(Eina.Rect);
         try {
            _ret_var = ((Item)wrapper).GetExtents( screen_coords);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return Eina.Rect_StructConversion.ToInternal(_ret_var);
      } else {
         return efl_access_component_extents_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  screen_coords);
      }
   }
   private static efl_access_component_extents_get_delegate efl_access_component_extents_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_access_component_extents_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool screen_coords,   Eina.Rect_StructInternal rect);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_access_component_extents_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool screen_coords,   Eina.Rect_StructInternal rect);
    public static Efl.Eo.FunctionWrapper<efl_access_component_extents_set_api_delegate> efl_access_component_extents_set_ptr = new Efl.Eo.FunctionWrapper<efl_access_component_extents_set_api_delegate>(_Module, "efl_access_component_extents_set");
    private static bool extents_set(System.IntPtr obj, System.IntPtr pd,  bool screen_coords,  Eina.Rect_StructInternal rect)
   {
      Eina.Log.Debug("function efl_access_component_extents_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                     var _in_rect = Eina.Rect_StructConversion.ToManaged(rect);
                                 bool _ret_var = default(bool);
         try {
            _ret_var = ((Item)wrapper).SetExtents( screen_coords,  _in_rect);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_access_component_extents_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  screen_coords,  rect);
      }
   }
   private static efl_access_component_extents_set_delegate efl_access_component_extents_set_static_delegate;


    private delegate  void efl_access_component_screen_position_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  int x,   out  int y);


    public delegate  void efl_access_component_screen_position_get_api_delegate(System.IntPtr obj,   out  int x,   out  int y);
    public static Efl.Eo.FunctionWrapper<efl_access_component_screen_position_get_api_delegate> efl_access_component_screen_position_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_component_screen_position_get_api_delegate>(_Module, "efl_access_component_screen_position_get");
    private static  void screen_position_get(System.IntPtr obj, System.IntPtr pd,  out  int x,  out  int y)
   {
      Eina.Log.Debug("function efl_access_component_screen_position_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           x = default( int);      y = default( int);                     
         try {
            ((Item)wrapper).GetScreenPosition( out x,  out y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_access_component_screen_position_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out x,  out y);
      }
   }
   private static efl_access_component_screen_position_get_delegate efl_access_component_screen_position_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_access_component_screen_position_set_delegate(System.IntPtr obj, System.IntPtr pd,    int x,    int y);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_access_component_screen_position_set_api_delegate(System.IntPtr obj,    int x,    int y);
    public static Efl.Eo.FunctionWrapper<efl_access_component_screen_position_set_api_delegate> efl_access_component_screen_position_set_ptr = new Efl.Eo.FunctionWrapper<efl_access_component_screen_position_set_api_delegate>(_Module, "efl_access_component_screen_position_set");
    private static bool screen_position_set(System.IntPtr obj, System.IntPtr pd,   int x,   int y)
   {
      Eina.Log.Debug("function efl_access_component_screen_position_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      bool _ret_var = default(bool);
         try {
            _ret_var = ((Item)wrapper).SetScreenPosition( x,  y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_access_component_screen_position_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  x,  y);
      }
   }
   private static efl_access_component_screen_position_set_delegate efl_access_component_screen_position_set_static_delegate;


    private delegate  void efl_access_component_socket_offset_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  int x,   out  int y);


    public delegate  void efl_access_component_socket_offset_get_api_delegate(System.IntPtr obj,   out  int x,   out  int y);
    public static Efl.Eo.FunctionWrapper<efl_access_component_socket_offset_get_api_delegate> efl_access_component_socket_offset_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_component_socket_offset_get_api_delegate>(_Module, "efl_access_component_socket_offset_get");
    private static  void socket_offset_get(System.IntPtr obj, System.IntPtr pd,  out  int x,  out  int y)
   {
      Eina.Log.Debug("function efl_access_component_socket_offset_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           x = default( int);      y = default( int);                     
         try {
            ((Item)wrapper).GetSocketOffset( out x,  out y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_access_component_socket_offset_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out x,  out y);
      }
   }
   private static efl_access_component_socket_offset_get_delegate efl_access_component_socket_offset_get_static_delegate;


    private delegate  void efl_access_component_socket_offset_set_delegate(System.IntPtr obj, System.IntPtr pd,    int x,    int y);


    public delegate  void efl_access_component_socket_offset_set_api_delegate(System.IntPtr obj,    int x,    int y);
    public static Efl.Eo.FunctionWrapper<efl_access_component_socket_offset_set_api_delegate> efl_access_component_socket_offset_set_ptr = new Efl.Eo.FunctionWrapper<efl_access_component_socket_offset_set_api_delegate>(_Module, "efl_access_component_socket_offset_set");
    private static  void socket_offset_set(System.IntPtr obj, System.IntPtr pd,   int x,   int y)
   {
      Eina.Log.Debug("function efl_access_component_socket_offset_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((Item)wrapper).SetSocketOffset( x,  y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_access_component_socket_offset_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  x,  y);
      }
   }
   private static efl_access_component_socket_offset_set_delegate efl_access_component_socket_offset_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_access_component_contains_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool screen_coords,    int x,    int y);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_access_component_contains_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool screen_coords,    int x,    int y);
    public static Efl.Eo.FunctionWrapper<efl_access_component_contains_api_delegate> efl_access_component_contains_ptr = new Efl.Eo.FunctionWrapper<efl_access_component_contains_api_delegate>(_Module, "efl_access_component_contains");
    private static bool contains(System.IntPtr obj, System.IntPtr pd,  bool screen_coords,   int x,   int y)
   {
      Eina.Log.Debug("function efl_access_component_contains was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                        bool _ret_var = default(bool);
         try {
            _ret_var = ((Item)wrapper).Contains( screen_coords,  x,  y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                          return _ret_var;
      } else {
         return efl_access_component_contains_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  screen_coords,  x,  y);
      }
   }
   private static efl_access_component_contains_delegate efl_access_component_contains_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_access_component_focus_grab_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_access_component_focus_grab_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_access_component_focus_grab_api_delegate> efl_access_component_focus_grab_ptr = new Efl.Eo.FunctionWrapper<efl_access_component_focus_grab_api_delegate>(_Module, "efl_access_component_focus_grab");
    private static bool focus_grab(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_component_focus_grab was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Item)wrapper).GrabFocus();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_access_component_focus_grab_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_access_component_focus_grab_delegate efl_access_component_focus_grab_static_delegate;


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))] private delegate Efl.Object efl_access_component_accessible_at_point_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool screen_coords,    int x,    int y);


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))] public delegate Efl.Object efl_access_component_accessible_at_point_get_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool screen_coords,    int x,    int y);
    public static Efl.Eo.FunctionWrapper<efl_access_component_accessible_at_point_get_api_delegate> efl_access_component_accessible_at_point_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_component_accessible_at_point_get_api_delegate>(_Module, "efl_access_component_accessible_at_point_get");
    private static Efl.Object accessible_at_point_get(System.IntPtr obj, System.IntPtr pd,  bool screen_coords,   int x,   int y)
   {
      Eina.Log.Debug("function efl_access_component_accessible_at_point_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                        Efl.Object _ret_var = default(Efl.Object);
         try {
            _ret_var = ((Item)wrapper).GetAccessibleAtPoint( screen_coords,  x,  y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                          return _ret_var;
      } else {
         return efl_access_component_accessible_at_point_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  screen_coords,  x,  y);
      }
   }
   private static efl_access_component_accessible_at_point_get_delegate efl_access_component_accessible_at_point_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_access_component_highlight_grab_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_access_component_highlight_grab_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_access_component_highlight_grab_api_delegate> efl_access_component_highlight_grab_ptr = new Efl.Eo.FunctionWrapper<efl_access_component_highlight_grab_api_delegate>(_Module, "efl_access_component_highlight_grab");
    private static bool highlight_grab(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_component_highlight_grab was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Item)wrapper).GrabHighlight();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_access_component_highlight_grab_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_access_component_highlight_grab_delegate efl_access_component_highlight_grab_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_access_component_highlight_clear_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_access_component_highlight_clear_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_access_component_highlight_clear_api_delegate> efl_access_component_highlight_clear_ptr = new Efl.Eo.FunctionWrapper<efl_access_component_highlight_clear_api_delegate>(_Module, "efl_access_component_highlight_clear");
    private static bool highlight_clear(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_component_highlight_clear was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Item)wrapper).ClearHighlight();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_access_component_highlight_clear_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_access_component_highlight_clear_delegate efl_access_component_highlight_clear_static_delegate;


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate  System.String efl_access_object_localized_role_name_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate  System.String efl_access_object_localized_role_name_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_access_object_localized_role_name_get_api_delegate> efl_access_object_localized_role_name_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_localized_role_name_get_api_delegate>(_Module, "efl_access_object_localized_role_name_get");
    private static  System.String localized_role_name_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_object_localized_role_name_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((Item)wrapper).GetLocalizedRoleName();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_access_object_localized_role_name_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_access_object_localized_role_name_get_delegate efl_access_object_localized_role_name_get_static_delegate;


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate  System.String efl_access_object_i18n_name_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate  System.String efl_access_object_i18n_name_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_access_object_i18n_name_get_api_delegate> efl_access_object_i18n_name_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_i18n_name_get_api_delegate>(_Module, "efl_access_object_i18n_name_get");
    private static  System.String i18n_name_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_object_i18n_name_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((Item)wrapper).GetI18nName();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_access_object_i18n_name_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_access_object_i18n_name_get_delegate efl_access_object_i18n_name_get_static_delegate;


    private delegate  void efl_access_object_i18n_name_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String i18n_name);


    public delegate  void efl_access_object_i18n_name_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String i18n_name);
    public static Efl.Eo.FunctionWrapper<efl_access_object_i18n_name_set_api_delegate> efl_access_object_i18n_name_set_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_i18n_name_set_api_delegate>(_Module, "efl_access_object_i18n_name_set");
    private static  void i18n_name_set(System.IntPtr obj, System.IntPtr pd,   System.String i18n_name)
   {
      Eina.Log.Debug("function efl_access_object_i18n_name_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Item)wrapper).SetI18nName( i18n_name);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_access_object_i18n_name_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  i18n_name);
      }
   }
   private static efl_access_object_i18n_name_set_delegate efl_access_object_i18n_name_set_static_delegate;


    private delegate  void efl_access_object_name_cb_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Access.ReadingInfoCb name_cb,    System.IntPtr data);


    public delegate  void efl_access_object_name_cb_set_api_delegate(System.IntPtr obj,   Efl.Access.ReadingInfoCb name_cb,    System.IntPtr data);
    public static Efl.Eo.FunctionWrapper<efl_access_object_name_cb_set_api_delegate> efl_access_object_name_cb_set_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_name_cb_set_api_delegate>(_Module, "efl_access_object_name_cb_set");
    private static  void name_cb_set(System.IntPtr obj, System.IntPtr pd,  Efl.Access.ReadingInfoCb name_cb,   System.IntPtr data)
   {
      Eina.Log.Debug("function efl_access_object_name_cb_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((Item)wrapper).SetNameCb( name_cb,  data);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_access_object_name_cb_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  name_cb,  data);
      }
   }
   private static efl_access_object_name_cb_set_delegate efl_access_object_name_cb_set_static_delegate;


    private delegate Efl.Access.RelationSet efl_access_object_relation_set_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Efl.Access.RelationSet efl_access_object_relation_set_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_access_object_relation_set_get_api_delegate> efl_access_object_relation_set_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_relation_set_get_api_delegate>(_Module, "efl_access_object_relation_set_get");
    private static Efl.Access.RelationSet relation_set_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_object_relation_set_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Access.RelationSet _ret_var = default(Efl.Access.RelationSet);
         try {
            _ret_var = ((Item)wrapper).GetRelationSet();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_access_object_relation_set_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_access_object_relation_set_get_delegate efl_access_object_relation_set_get_static_delegate;


    private delegate Efl.Access.Role efl_access_object_role_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Efl.Access.Role efl_access_object_role_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_access_object_role_get_api_delegate> efl_access_object_role_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_role_get_api_delegate>(_Module, "efl_access_object_role_get");
    private static Efl.Access.Role role_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_object_role_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Access.Role _ret_var = default(Efl.Access.Role);
         try {
            _ret_var = ((Item)wrapper).GetRole();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_access_object_role_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_access_object_role_get_delegate efl_access_object_role_get_static_delegate;


    private delegate  void efl_access_object_role_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Access.Role role);


    public delegate  void efl_access_object_role_set_api_delegate(System.IntPtr obj,   Efl.Access.Role role);
    public static Efl.Eo.FunctionWrapper<efl_access_object_role_set_api_delegate> efl_access_object_role_set_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_role_set_api_delegate>(_Module, "efl_access_object_role_set");
    private static  void role_set(System.IntPtr obj, System.IntPtr pd,  Efl.Access.Role role)
   {
      Eina.Log.Debug("function efl_access_object_role_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Item)wrapper).SetRole( role);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_access_object_role_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  role);
      }
   }
   private static efl_access_object_role_set_delegate efl_access_object_role_set_static_delegate;


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Access.ObjectConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.Access.Object efl_access_object_access_parent_get_delegate(System.IntPtr obj, System.IntPtr pd);


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Access.ObjectConcrete, Efl.Eo.NonOwnTag>))] public delegate Efl.Access.Object efl_access_object_access_parent_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_access_object_access_parent_get_api_delegate> efl_access_object_access_parent_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_access_parent_get_api_delegate>(_Module, "efl_access_object_access_parent_get");
    private static Efl.Access.Object access_parent_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_object_access_parent_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Access.Object _ret_var = default(Efl.Access.Object);
         try {
            _ret_var = ((Item)wrapper).GetAccessParent();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_access_object_access_parent_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_access_object_access_parent_get_delegate efl_access_object_access_parent_get_static_delegate;


    private delegate  void efl_access_object_access_parent_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Access.ObjectConcrete, Efl.Eo.NonOwnTag>))]  Efl.Access.Object parent);


    public delegate  void efl_access_object_access_parent_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Access.ObjectConcrete, Efl.Eo.NonOwnTag>))]  Efl.Access.Object parent);
    public static Efl.Eo.FunctionWrapper<efl_access_object_access_parent_set_api_delegate> efl_access_object_access_parent_set_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_access_parent_set_api_delegate>(_Module, "efl_access_object_access_parent_set");
    private static  void access_parent_set(System.IntPtr obj, System.IntPtr pd,  Efl.Access.Object parent)
   {
      Eina.Log.Debug("function efl_access_object_access_parent_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Item)wrapper).SetAccessParent( parent);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_access_object_access_parent_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  parent);
      }
   }
   private static efl_access_object_access_parent_set_delegate efl_access_object_access_parent_set_static_delegate;


    private delegate  void efl_access_object_description_cb_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Access.ReadingInfoCb description_cb,    System.IntPtr data);


    public delegate  void efl_access_object_description_cb_set_api_delegate(System.IntPtr obj,   Efl.Access.ReadingInfoCb description_cb,    System.IntPtr data);
    public static Efl.Eo.FunctionWrapper<efl_access_object_description_cb_set_api_delegate> efl_access_object_description_cb_set_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_description_cb_set_api_delegate>(_Module, "efl_access_object_description_cb_set");
    private static  void description_cb_set(System.IntPtr obj, System.IntPtr pd,  Efl.Access.ReadingInfoCb description_cb,   System.IntPtr data)
   {
      Eina.Log.Debug("function efl_access_object_description_cb_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((Item)wrapper).SetDescriptionCb( description_cb,  data);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_access_object_description_cb_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  description_cb,  data);
      }
   }
   private static efl_access_object_description_cb_set_delegate efl_access_object_description_cb_set_static_delegate;


    private delegate  void efl_access_object_gesture_cb_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Access.GestureCb gesture_cb,    System.IntPtr data);


    public delegate  void efl_access_object_gesture_cb_set_api_delegate(System.IntPtr obj,   Efl.Access.GestureCb gesture_cb,    System.IntPtr data);
    public static Efl.Eo.FunctionWrapper<efl_access_object_gesture_cb_set_api_delegate> efl_access_object_gesture_cb_set_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_gesture_cb_set_api_delegate>(_Module, "efl_access_object_gesture_cb_set");
    private static  void gesture_cb_set(System.IntPtr obj, System.IntPtr pd,  Efl.Access.GestureCb gesture_cb,   System.IntPtr data)
   {
      Eina.Log.Debug("function efl_access_object_gesture_cb_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((Item)wrapper).SetGestureCb( gesture_cb,  data);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_access_object_gesture_cb_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  gesture_cb,  data);
      }
   }
   private static efl_access_object_gesture_cb_set_delegate efl_access_object_gesture_cb_set_static_delegate;


    private delegate  System.IntPtr efl_access_object_access_children_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  System.IntPtr efl_access_object_access_children_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_access_object_access_children_get_api_delegate> efl_access_object_access_children_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_access_children_get_api_delegate>(_Module, "efl_access_object_access_children_get");
    private static  System.IntPtr access_children_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_object_access_children_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.List<Efl.Access.Object> _ret_var = default(Eina.List<Efl.Access.Object>);
         try {
            _ret_var = ((Item)wrapper).GetAccessChildren();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      _ret_var.Own = false; return _ret_var.Handle;
      } else {
         return efl_access_object_access_children_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_access_object_access_children_get_delegate efl_access_object_access_children_get_static_delegate;


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate  System.String efl_access_object_role_name_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate  System.String efl_access_object_role_name_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_access_object_role_name_get_api_delegate> efl_access_object_role_name_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_role_name_get_api_delegate>(_Module, "efl_access_object_role_name_get");
    private static  System.String role_name_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_object_role_name_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((Item)wrapper).GetRoleName();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_access_object_role_name_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_access_object_role_name_get_delegate efl_access_object_role_name_get_static_delegate;


    private delegate  System.IntPtr efl_access_object_attributes_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  System.IntPtr efl_access_object_attributes_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_access_object_attributes_get_api_delegate> efl_access_object_attributes_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_attributes_get_api_delegate>(_Module, "efl_access_object_attributes_get");
    private static  System.IntPtr attributes_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_object_attributes_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.List<Efl.Access.Attribute> _ret_var = default(Eina.List<Efl.Access.Attribute>);
         try {
            _ret_var = ((Item)wrapper).GetAttributes();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      _ret_var.Own = false; _ret_var.OwnContent = false; return _ret_var.Handle;
      } else {
         return efl_access_object_attributes_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_access_object_attributes_get_delegate efl_access_object_attributes_get_static_delegate;


    private delegate Efl.Access.ReadingInfoTypeMask efl_access_object_reading_info_type_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Efl.Access.ReadingInfoTypeMask efl_access_object_reading_info_type_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_access_object_reading_info_type_get_api_delegate> efl_access_object_reading_info_type_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_reading_info_type_get_api_delegate>(_Module, "efl_access_object_reading_info_type_get");
    private static Efl.Access.ReadingInfoTypeMask reading_info_type_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_object_reading_info_type_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Access.ReadingInfoTypeMask _ret_var = default(Efl.Access.ReadingInfoTypeMask);
         try {
            _ret_var = ((Item)wrapper).GetReadingInfoType();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_access_object_reading_info_type_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_access_object_reading_info_type_get_delegate efl_access_object_reading_info_type_get_static_delegate;


    private delegate  void efl_access_object_reading_info_type_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Access.ReadingInfoTypeMask reading_info);


    public delegate  void efl_access_object_reading_info_type_set_api_delegate(System.IntPtr obj,   Efl.Access.ReadingInfoTypeMask reading_info);
    public static Efl.Eo.FunctionWrapper<efl_access_object_reading_info_type_set_api_delegate> efl_access_object_reading_info_type_set_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_reading_info_type_set_api_delegate>(_Module, "efl_access_object_reading_info_type_set");
    private static  void reading_info_type_set(System.IntPtr obj, System.IntPtr pd,  Efl.Access.ReadingInfoTypeMask reading_info)
   {
      Eina.Log.Debug("function efl_access_object_reading_info_type_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Item)wrapper).SetReadingInfoType( reading_info);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_access_object_reading_info_type_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  reading_info);
      }
   }
   private static efl_access_object_reading_info_type_set_delegate efl_access_object_reading_info_type_set_static_delegate;


    private delegate  int efl_access_object_index_in_parent_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  int efl_access_object_index_in_parent_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_access_object_index_in_parent_get_api_delegate> efl_access_object_index_in_parent_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_index_in_parent_get_api_delegate>(_Module, "efl_access_object_index_in_parent_get");
    private static  int index_in_parent_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_object_index_in_parent_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   int _ret_var = default( int);
         try {
            _ret_var = ((Item)wrapper).GetIndexInParent();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_access_object_index_in_parent_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_access_object_index_in_parent_get_delegate efl_access_object_index_in_parent_get_static_delegate;


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate  System.String efl_access_object_description_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate  System.String efl_access_object_description_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_access_object_description_get_api_delegate> efl_access_object_description_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_description_get_api_delegate>(_Module, "efl_access_object_description_get");
    private static  System.String description_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_object_description_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((Item)wrapper).GetDescription();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_access_object_description_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_access_object_description_get_delegate efl_access_object_description_get_static_delegate;


    private delegate  void efl_access_object_description_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String description);


    public delegate  void efl_access_object_description_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String description);
    public static Efl.Eo.FunctionWrapper<efl_access_object_description_set_api_delegate> efl_access_object_description_set_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_description_set_api_delegate>(_Module, "efl_access_object_description_set");
    private static  void description_set(System.IntPtr obj, System.IntPtr pd,   System.String description)
   {
      Eina.Log.Debug("function efl_access_object_description_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Item)wrapper).SetDescription( description);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_access_object_description_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  description);
      }
   }
   private static efl_access_object_description_set_delegate efl_access_object_description_set_static_delegate;


    private delegate Efl.Access.StateSet efl_access_object_state_set_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Efl.Access.StateSet efl_access_object_state_set_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_access_object_state_set_get_api_delegate> efl_access_object_state_set_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_state_set_get_api_delegate>(_Module, "efl_access_object_state_set_get");
    private static Efl.Access.StateSet state_set_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_object_state_set_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Access.StateSet _ret_var = default(Efl.Access.StateSet);
         try {
            _ret_var = ((Item)wrapper).GetStateSet();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_access_object_state_set_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_access_object_state_set_get_delegate efl_access_object_state_set_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_access_object_can_highlight_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_access_object_can_highlight_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_access_object_can_highlight_get_api_delegate> efl_access_object_can_highlight_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_can_highlight_get_api_delegate>(_Module, "efl_access_object_can_highlight_get");
    private static bool can_highlight_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_object_can_highlight_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Item)wrapper).GetCanHighlight();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_access_object_can_highlight_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_access_object_can_highlight_get_delegate efl_access_object_can_highlight_get_static_delegate;


    private delegate  void efl_access_object_can_highlight_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool can_highlight);


    public delegate  void efl_access_object_can_highlight_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool can_highlight);
    public static Efl.Eo.FunctionWrapper<efl_access_object_can_highlight_set_api_delegate> efl_access_object_can_highlight_set_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_can_highlight_set_api_delegate>(_Module, "efl_access_object_can_highlight_set");
    private static  void can_highlight_set(System.IntPtr obj, System.IntPtr pd,  bool can_highlight)
   {
      Eina.Log.Debug("function efl_access_object_can_highlight_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Item)wrapper).SetCanHighlight( can_highlight);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_access_object_can_highlight_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  can_highlight);
      }
   }
   private static efl_access_object_can_highlight_set_delegate efl_access_object_can_highlight_set_static_delegate;


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate  System.String efl_access_object_translation_domain_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate  System.String efl_access_object_translation_domain_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_access_object_translation_domain_get_api_delegate> efl_access_object_translation_domain_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_translation_domain_get_api_delegate>(_Module, "efl_access_object_translation_domain_get");
    private static  System.String translation_domain_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_object_translation_domain_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((Item)wrapper).GetTranslationDomain();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_access_object_translation_domain_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_access_object_translation_domain_get_delegate efl_access_object_translation_domain_get_static_delegate;


    private delegate  void efl_access_object_translation_domain_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String domain);


    public delegate  void efl_access_object_translation_domain_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String domain);
    public static Efl.Eo.FunctionWrapper<efl_access_object_translation_domain_set_api_delegate> efl_access_object_translation_domain_set_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_translation_domain_set_api_delegate>(_Module, "efl_access_object_translation_domain_set");
    private static  void translation_domain_set(System.IntPtr obj, System.IntPtr pd,   System.String domain)
   {
      Eina.Log.Debug("function efl_access_object_translation_domain_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Item)wrapper).SetTranslationDomain( domain);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_access_object_translation_domain_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  domain);
      }
   }
   private static efl_access_object_translation_domain_set_delegate efl_access_object_translation_domain_set_static_delegate;


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))] private delegate Efl.Object efl_access_object_access_root_get_delegate();


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))] public delegate Efl.Object efl_access_object_access_root_get_api_delegate();
    public static Efl.Eo.FunctionWrapper<efl_access_object_access_root_get_api_delegate> efl_access_object_access_root_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_access_root_get_api_delegate>(_Module, "efl_access_object_access_root_get");
    private static Efl.Object access_root_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_object_access_root_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Object _ret_var = default(Efl.Object);
         try {
            _ret_var = Item.GetAccessRoot();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_access_object_access_root_get_ptr.Value.Delegate();
      }
   }


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_access_object_gesture_do_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Access.GestureInfo_StructInternal gesture_info);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_access_object_gesture_do_api_delegate(System.IntPtr obj,   Efl.Access.GestureInfo_StructInternal gesture_info);
    public static Efl.Eo.FunctionWrapper<efl_access_object_gesture_do_api_delegate> efl_access_object_gesture_do_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_gesture_do_api_delegate>(_Module, "efl_access_object_gesture_do");
    private static bool gesture_do(System.IntPtr obj, System.IntPtr pd,  Efl.Access.GestureInfo_StructInternal gesture_info)
   {
      Eina.Log.Debug("function efl_access_object_gesture_do was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_gesture_info = Efl.Access.GestureInfo_StructConversion.ToManaged(gesture_info);
                     bool _ret_var = default(bool);
         try {
            _ret_var = ((Item)wrapper).GestureDo( _in_gesture_info);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_access_object_gesture_do_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  gesture_info);
      }
   }
   private static efl_access_object_gesture_do_delegate efl_access_object_gesture_do_static_delegate;


    private delegate  void efl_access_object_attribute_append_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String value);


    public delegate  void efl_access_object_attribute_append_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String value);
    public static Efl.Eo.FunctionWrapper<efl_access_object_attribute_append_api_delegate> efl_access_object_attribute_append_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_attribute_append_api_delegate>(_Module, "efl_access_object_attribute_append");
    private static  void attribute_append(System.IntPtr obj, System.IntPtr pd,   System.String key,   System.String value)
   {
      Eina.Log.Debug("function efl_access_object_attribute_append was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((Item)wrapper).AppendAttribute( key,  value);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_access_object_attribute_append_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  key,  value);
      }
   }
   private static efl_access_object_attribute_append_delegate efl_access_object_attribute_append_static_delegate;


    private delegate  void efl_access_object_attributes_clear_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  void efl_access_object_attributes_clear_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_access_object_attributes_clear_api_delegate> efl_access_object_attributes_clear_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_attributes_clear_api_delegate>(_Module, "efl_access_object_attributes_clear");
    private static  void attributes_clear(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_object_attributes_clear was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Item)wrapper).ClearAttributes();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_access_object_attributes_clear_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_access_object_attributes_clear_delegate efl_access_object_attributes_clear_static_delegate;


    private delegate Efl.Access.Event.Handler efl_access_object_event_handler_add_delegate(  Efl.EventCb cb,    System.IntPtr data);


    public delegate Efl.Access.Event.Handler efl_access_object_event_handler_add_api_delegate(  Efl.EventCb cb,    System.IntPtr data);
    public static Efl.Eo.FunctionWrapper<efl_access_object_event_handler_add_api_delegate> efl_access_object_event_handler_add_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_event_handler_add_api_delegate>(_Module, "efl_access_object_event_handler_add");
    private static Efl.Access.Event.Handler event_handler_add(System.IntPtr obj, System.IntPtr pd,  Efl.EventCb cb,   System.IntPtr data)
   {
      Eina.Log.Debug("function efl_access_object_event_handler_add was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      Efl.Access.Event.Handler _ret_var = default(Efl.Access.Event.Handler);
         try {
            _ret_var = Item.AddEventHandler( cb,  data);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_access_object_event_handler_add_ptr.Value.Delegate( cb,  data);
      }
   }


    private delegate  void efl_access_object_event_handler_del_delegate(  Efl.Access.Event.Handler handler);


    public delegate  void efl_access_object_event_handler_del_api_delegate(  Efl.Access.Event.Handler handler);
    public static Efl.Eo.FunctionWrapper<efl_access_object_event_handler_del_api_delegate> efl_access_object_event_handler_del_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_event_handler_del_api_delegate>(_Module, "efl_access_object_event_handler_del");
    private static  void event_handler_del(System.IntPtr obj, System.IntPtr pd,  Efl.Access.Event.Handler handler)
   {
      Eina.Log.Debug("function efl_access_object_event_handler_del was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            Item.DelEventHandler( handler);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_access_object_event_handler_del_ptr.Value.Delegate( handler);
      }
   }


    private delegate  void efl_access_object_event_emit_delegate([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Access.ObjectConcrete, Efl.Eo.NonOwnTag>))]  Efl.Access.Object accessible,    System.IntPtr kw_event,    System.IntPtr event_info);


    public delegate  void efl_access_object_event_emit_api_delegate([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Access.ObjectConcrete, Efl.Eo.NonOwnTag>))]  Efl.Access.Object accessible,    System.IntPtr kw_event,    System.IntPtr event_info);
    public static Efl.Eo.FunctionWrapper<efl_access_object_event_emit_api_delegate> efl_access_object_event_emit_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_event_emit_api_delegate>(_Module, "efl_access_object_event_emit");
    private static  void event_emit(System.IntPtr obj, System.IntPtr pd,  Efl.Access.Object accessible,   System.IntPtr kw_event,   System.IntPtr event_info)
   {
      Eina.Log.Debug("function efl_access_object_event_emit was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                     var _in_kw_event = Eina.PrimitiveConversion.PointerToManaged<Efl.EventDescription>(kw_event);
                                                   
         try {
            Item.EmitEvent( accessible,  _in_kw_event,  event_info);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                } else {
         efl_access_object_event_emit_ptr.Value.Delegate( accessible,  kw_event,  event_info);
      }
   }


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_access_object_relationship_append_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Access.RelationType type, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Access.ObjectConcrete, Efl.Eo.NonOwnTag>))]  Efl.Access.Object relation_object);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_access_object_relationship_append_api_delegate(System.IntPtr obj,   Efl.Access.RelationType type, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Access.ObjectConcrete, Efl.Eo.NonOwnTag>))]  Efl.Access.Object relation_object);
    public static Efl.Eo.FunctionWrapper<efl_access_object_relationship_append_api_delegate> efl_access_object_relationship_append_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_relationship_append_api_delegate>(_Module, "efl_access_object_relationship_append");
    private static bool relationship_append(System.IntPtr obj, System.IntPtr pd,  Efl.Access.RelationType type,  Efl.Access.Object relation_object)
   {
      Eina.Log.Debug("function efl_access_object_relationship_append was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      bool _ret_var = default(bool);
         try {
            _ret_var = ((Item)wrapper).AppendRelationship( type,  relation_object);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_access_object_relationship_append_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  type,  relation_object);
      }
   }
   private static efl_access_object_relationship_append_delegate efl_access_object_relationship_append_static_delegate;


    private delegate  void efl_access_object_relationship_remove_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Access.RelationType type, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Access.ObjectConcrete, Efl.Eo.NonOwnTag>))]  Efl.Access.Object relation_object);


    public delegate  void efl_access_object_relationship_remove_api_delegate(System.IntPtr obj,   Efl.Access.RelationType type, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Access.ObjectConcrete, Efl.Eo.NonOwnTag>))]  Efl.Access.Object relation_object);
    public static Efl.Eo.FunctionWrapper<efl_access_object_relationship_remove_api_delegate> efl_access_object_relationship_remove_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_relationship_remove_api_delegate>(_Module, "efl_access_object_relationship_remove");
    private static  void relationship_remove(System.IntPtr obj, System.IntPtr pd,  Efl.Access.RelationType type,  Efl.Access.Object relation_object)
   {
      Eina.Log.Debug("function efl_access_object_relationship_remove was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((Item)wrapper).RelationshipRemove( type,  relation_object);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_access_object_relationship_remove_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  type,  relation_object);
      }
   }
   private static efl_access_object_relationship_remove_delegate efl_access_object_relationship_remove_static_delegate;


    private delegate  void efl_access_object_relationships_clear_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  void efl_access_object_relationships_clear_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_access_object_relationships_clear_api_delegate> efl_access_object_relationships_clear_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_relationships_clear_api_delegate>(_Module, "efl_access_object_relationships_clear");
    private static  void relationships_clear(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_object_relationships_clear was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Item)wrapper).ClearRelationships();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_access_object_relationships_clear_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_access_object_relationships_clear_delegate efl_access_object_relationships_clear_static_delegate;


    private delegate  void efl_access_object_state_notify_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Access.StateSet state_types_mask,  [MarshalAs(UnmanagedType.U1)]  bool recursive);


    public delegate  void efl_access_object_state_notify_api_delegate(System.IntPtr obj,   Efl.Access.StateSet state_types_mask,  [MarshalAs(UnmanagedType.U1)]  bool recursive);
    public static Efl.Eo.FunctionWrapper<efl_access_object_state_notify_api_delegate> efl_access_object_state_notify_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_state_notify_api_delegate>(_Module, "efl_access_object_state_notify");
    private static  void state_notify(System.IntPtr obj, System.IntPtr pd,  Efl.Access.StateSet state_types_mask,  bool recursive)
   {
      Eina.Log.Debug("function efl_access_object_state_notify was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((Item)wrapper).StateNotify( state_types_mask,  recursive);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_access_object_state_notify_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  state_types_mask,  recursive);
      }
   }
   private static efl_access_object_state_notify_delegate efl_access_object_state_notify_static_delegate;


    private delegate Efl.Access.ActionData efl_access_widget_action_elm_actions_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Efl.Access.ActionData efl_access_widget_action_elm_actions_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_access_widget_action_elm_actions_get_api_delegate> efl_access_widget_action_elm_actions_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_widget_action_elm_actions_get_api_delegate>(_Module, "efl_access_widget_action_elm_actions_get");
    private static Efl.Access.ActionData elm_actions_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_widget_action_elm_actions_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Access.ActionData _ret_var = default(Efl.Access.ActionData);
         try {
            _ret_var = ((Item)wrapper).GetElmActions();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_access_widget_action_elm_actions_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_access_widget_action_elm_actions_get_delegate efl_access_widget_action_elm_actions_get_static_delegate;


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
            _ret_var = ((Item)wrapper).GetPosition();
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
            ((Item)wrapper).SetPosition( _in_pos);
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
            _ret_var = ((Item)wrapper).GetSize();
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
            ((Item)wrapper).SetSize( _in_size);
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
            _ret_var = ((Item)wrapper).GetGeometry();
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
            ((Item)wrapper).SetGeometry( _in_rect);
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
            _ret_var = ((Item)wrapper).GetVisible();
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
            ((Item)wrapper).SetVisible( v);
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
            _ret_var = ((Item)wrapper).GetScale();
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
            ((Item)wrapper).SetScale( scale);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_entity_scale_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  scale);
      }
   }
   private static efl_gfx_entity_scale_set_delegate efl_gfx_entity_scale_set_static_delegate;


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
            _ret_var = ((Item)wrapper).GetLayer();
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
            ((Item)wrapper).SetLayer( l);
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
            _ret_var = ((Item)wrapper).GetBelow();
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
            _ret_var = ((Item)wrapper).GetAbove();
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
            ((Item)wrapper).StackBelow( below);
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
            ((Item)wrapper).RaiseToTop();
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
            ((Item)wrapper).StackAbove( above);
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
            ((Item)wrapper).LowerToBottom();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_gfx_stack_lower_to_bottom_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_gfx_stack_lower_to_bottom_delegate efl_gfx_stack_lower_to_bottom_static_delegate;
}
} } 
