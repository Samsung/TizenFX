#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Canvas { 
/// <summary>Common class for part proxy objects for <see cref="Efl.Canvas.Layout"/>.
/// As an <see cref="Efl.Part"/> implementation class, all objects of this class are meant to be used for one and only one function call. In pseudo-code, the use of object of this type looks like the following: rect = layout.part(&quot;somepart&quot;).geometry_get();
/// 1.20</summary>
[LayoutPartNativeInherit]
public class LayoutPart : Efl.Object, Efl.Eo.IWrapper,Efl.Gfx.Entity,Efl.Ui.Drag
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Canvas.LayoutPartNativeInherit nativeInherit = new Efl.Canvas.LayoutPartNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (LayoutPart))
            return Efl.Canvas.LayoutPartNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
      }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Edje)] internal static extern System.IntPtr
      efl_canvas_layout_part_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   public LayoutPart(Efl.Object parent= null
         ) :
      base(efl_canvas_layout_part_class_get(), typeof(LayoutPart), parent)
   {
      FinishInstantiation();
   }
   ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
   public LayoutPart(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
   protected LayoutPart(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static LayoutPart static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new LayoutPart(obj.NativeHandle);
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

   protected override void register_event_proxies()
   {
      base.register_event_proxies();
      evt_VisibilityChangedEvt_delegate = new Efl.EventCb(on_VisibilityChangedEvt_NativeCallback);
      evt_PositionChangedEvt_delegate = new Efl.EventCb(on_PositionChangedEvt_NativeCallback);
      evt_SizeChangedEvt_delegate = new Efl.EventCb(on_SizeChangedEvt_NativeCallback);
   }
   /// <summary>The name and value of the current state of this part (read-only).
   /// This is the state name as it appears in EDC description blocks. A state has both a name and a value (double). The default state is &quot;default&quot; 0.0, but this function will return &quot;&quot; if the part is invalid.
   /// 1.20</summary>
   /// <param name="state">The name of the state.
   /// 1.20</param>
   /// <param name="val">The value of the state.
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void GetState( out  System.String state,  out double val) {
                                           Efl.Canvas.LayoutPartNativeInherit.efl_canvas_layout_part_state_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), out state,  out val);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Returns the type of the part.
   /// 1.20</summary>
   /// <returns>One of the types or <c>none</c> if not an existing part.
   /// 1.20</returns>
   virtual public Efl.Canvas.LayoutPartType GetPartType() {
       var _ret_var = Efl.Canvas.LayoutPartNativeInherit.efl_canvas_layout_part_type_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
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
   /// <summary>Gets the draggable object location.
   /// 1.20</summary>
   /// <param name="dx">The x relative position, from 0 to 1.
   /// 1.20</param>
   /// <param name="dy">The y relative position, from 0 to 1.
   /// 1.20</param>
   /// <returns><c>true</c> on success, <c>false</c> otherwise
   /// 1.20</returns>
   virtual public bool GetDragValue( out double dx,  out double dy) {
                                           var _ret_var = Efl.Ui.DragNativeInherit.efl_ui_drag_value_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), out dx,  out dy);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }
   /// <summary>Sets the draggable object location.
   /// This places the draggable object at the given location.
   /// 1.20</summary>
   /// <param name="dx">The x relative position, from 0 to 1.
   /// 1.20</param>
   /// <param name="dy">The y relative position, from 0 to 1.
   /// 1.20</param>
   /// <returns><c>true</c> on success, <c>false</c> otherwise
   /// 1.20</returns>
   virtual public bool SetDragValue( double dx,  double dy) {
                                           var _ret_var = Efl.Ui.DragNativeInherit.efl_ui_drag_value_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), dx,  dy);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }
   /// <summary>Gets the size of the dradgable object.
   /// 1.20</summary>
   /// <param name="dw">The drag relative width, from 0 to 1.
   /// 1.20</param>
   /// <param name="dh">The drag relative height, from 0 to 1.
   /// 1.20</param>
   /// <returns><c>true</c> on success, <c>false</c> otherwise
   /// 1.20</returns>
   virtual public bool GetDragSize( out double dw,  out double dh) {
                                           var _ret_var = Efl.Ui.DragNativeInherit.efl_ui_drag_size_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), out dw,  out dh);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }
   /// <summary>Sets the size of the draggable object.
   /// 1.20</summary>
   /// <param name="dw">The drag relative width, from 0 to 1.
   /// 1.20</param>
   /// <param name="dh">The drag relative height, from 0 to 1.
   /// 1.20</param>
   /// <returns><c>true</c> on success, <c>false</c> otherwise
   /// 1.20</returns>
   virtual public bool SetDragSize( double dw,  double dh) {
                                           var _ret_var = Efl.Ui.DragNativeInherit.efl_ui_drag_size_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), dw,  dh);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }
   /// <summary>Gets the draggable direction.
   /// 1.20</summary>
   /// <returns>The direction(s) premitted for drag.
   /// 1.20</returns>
   virtual public Efl.Ui.DragDir GetDragDir() {
       var _ret_var = Efl.Ui.DragNativeInherit.efl_ui_drag_dir_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Gets the x and y step increments for the draggable object.
   /// 1.20</summary>
   /// <param name="dx">The x step relative amount, from 0 to 1.
   /// 1.20</param>
   /// <param name="dy">The y step relative amount, from 0 to 1.
   /// 1.20</param>
   /// <returns><c>true</c> on success, <c>false</c> otherwise
   /// 1.20</returns>
   virtual public bool GetDragStep( out double dx,  out double dy) {
                                           var _ret_var = Efl.Ui.DragNativeInherit.efl_ui_drag_step_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), out dx,  out dy);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }
   /// <summary>Sets the x,y step increments for a draggable object.
   /// 1.20</summary>
   /// <param name="dx">The x step relative amount, from 0 to 1.
   /// 1.20</param>
   /// <param name="dy">The y step relative amount, from 0 to 1.
   /// 1.20</param>
   /// <returns><c>true</c> on success, <c>false</c> otherwise
   /// 1.20</returns>
   virtual public bool SetDragStep( double dx,  double dy) {
                                           var _ret_var = Efl.Ui.DragNativeInherit.efl_ui_drag_step_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), dx,  dy);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }
   /// <summary>Gets the x,y page step increments for the draggable object.
   /// 1.20</summary>
   /// <param name="dx">The x page step increment
   /// 1.20</param>
   /// <param name="dy">The y page step increment
   /// 1.20</param>
   /// <returns><c>true</c> on success, <c>false</c> otherwise
   /// 1.20</returns>
   virtual public bool GetDragPage( out double dx,  out double dy) {
                                           var _ret_var = Efl.Ui.DragNativeInherit.efl_ui_drag_page_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), out dx,  out dy);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }
   /// <summary>Sets the x,y page step increment values.
   /// 1.20</summary>
   /// <param name="dx">The x page step increment
   /// 1.20</param>
   /// <param name="dy">The y page step increment
   /// 1.20</param>
   /// <returns><c>true</c> on success, <c>false</c> otherwise
   /// 1.20</returns>
   virtual public bool SetDragPage( double dx,  double dy) {
                                           var _ret_var = Efl.Ui.DragNativeInherit.efl_ui_drag_page_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), dx,  dy);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }
   /// <summary>Moves the draggable by <c>dx</c>,<c>dy</c> steps.
   /// This moves the draggable part by <c>dx</c>,<c>dy</c> steps where the step increment is the amount set by <see cref="Efl.Ui.Drag.GetDragStep"/>.
   /// 
   /// <c>dx</c> and <c>dy</c> can be positive or negative numbers, integer values are recommended.
   /// 1.20</summary>
   /// <param name="dx">The number of steps horizontally.
   /// 1.20</param>
   /// <param name="dy">The number of steps vertically.
   /// 1.20</param>
   /// <returns><c>true</c> on success, <c>false</c> otherwise
   /// 1.20</returns>
   virtual public bool MoveDragStep( double dx,  double dy) {
                                           var _ret_var = Efl.Ui.DragNativeInherit.efl_ui_drag_step_move_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), dx,  dy);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }
   /// <summary>Moves the draggable by <c>dx</c>,<c>dy</c> pages.
   /// This moves the draggable by <c>dx</c>,<c>dy</c> pages. The increment is defined by <see cref="Efl.Ui.Drag.GetDragPage"/>.
   /// 
   /// <c>dx</c> and <c>dy</c> can be positive or negative numbers, integer values are recommended.
   /// 
   /// Warning: Paging is bugged!
   /// 1.20</summary>
   /// <param name="dx">The number of pages horizontally.
   /// 1.20</param>
   /// <param name="dy">The number of pages vertically.
   /// 1.20</param>
   /// <returns><c>true</c> on success, <c>false</c> otherwise
   /// 1.20</returns>
   virtual public bool MoveDragPage( double dx,  double dy) {
                                           var _ret_var = Efl.Ui.DragNativeInherit.efl_ui_drag_page_move_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), dx,  dy);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }
   /// <summary>Type of this part in the layout.
/// 1.20</summary>
/// <value>One of the types or <c>none</c> if not an existing part.
/// 1.20</value>
   public Efl.Canvas.LayoutPartType PartType {
      get { return GetPartType(); }
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
   /// <summary>Determines the draggable directions (read-only).
/// The draggable directions are defined in the EDC file, inside the &quot;draggable&quot; section, by the attributes <c>x</c> and <c>y</c>. See the EDC reference documentation for more information.
/// 1.20</summary>
/// <value>The direction(s) premitted for drag.
/// 1.20</value>
   public Efl.Ui.DragDir DragDir {
      get { return GetDragDir(); }
   }
   private static new  IntPtr GetEflClassStatic()
   {
      return Efl.Canvas.LayoutPart.efl_canvas_layout_part_class_get();
   }
}
public class LayoutPartNativeInherit : Efl.ObjectNativeInherit{
   public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Edje);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      if (efl_canvas_layout_part_state_get_static_delegate == null)
      efl_canvas_layout_part_state_get_static_delegate = new efl_canvas_layout_part_state_get_delegate(state_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_layout_part_state_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_layout_part_state_get_static_delegate)});
      if (efl_canvas_layout_part_type_get_static_delegate == null)
      efl_canvas_layout_part_type_get_static_delegate = new efl_canvas_layout_part_type_get_delegate(part_type_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_layout_part_type_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_layout_part_type_get_static_delegate)});
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
      if (efl_ui_drag_value_get_static_delegate == null)
      efl_ui_drag_value_get_static_delegate = new efl_ui_drag_value_get_delegate(drag_value_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_drag_value_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_drag_value_get_static_delegate)});
      if (efl_ui_drag_value_set_static_delegate == null)
      efl_ui_drag_value_set_static_delegate = new efl_ui_drag_value_set_delegate(drag_value_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_drag_value_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_drag_value_set_static_delegate)});
      if (efl_ui_drag_size_get_static_delegate == null)
      efl_ui_drag_size_get_static_delegate = new efl_ui_drag_size_get_delegate(drag_size_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_drag_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_drag_size_get_static_delegate)});
      if (efl_ui_drag_size_set_static_delegate == null)
      efl_ui_drag_size_set_static_delegate = new efl_ui_drag_size_set_delegate(drag_size_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_drag_size_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_drag_size_set_static_delegate)});
      if (efl_ui_drag_dir_get_static_delegate == null)
      efl_ui_drag_dir_get_static_delegate = new efl_ui_drag_dir_get_delegate(drag_dir_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_drag_dir_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_drag_dir_get_static_delegate)});
      if (efl_ui_drag_step_get_static_delegate == null)
      efl_ui_drag_step_get_static_delegate = new efl_ui_drag_step_get_delegate(drag_step_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_drag_step_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_drag_step_get_static_delegate)});
      if (efl_ui_drag_step_set_static_delegate == null)
      efl_ui_drag_step_set_static_delegate = new efl_ui_drag_step_set_delegate(drag_step_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_drag_step_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_drag_step_set_static_delegate)});
      if (efl_ui_drag_page_get_static_delegate == null)
      efl_ui_drag_page_get_static_delegate = new efl_ui_drag_page_get_delegate(drag_page_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_drag_page_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_drag_page_get_static_delegate)});
      if (efl_ui_drag_page_set_static_delegate == null)
      efl_ui_drag_page_set_static_delegate = new efl_ui_drag_page_set_delegate(drag_page_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_drag_page_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_drag_page_set_static_delegate)});
      if (efl_ui_drag_step_move_static_delegate == null)
      efl_ui_drag_step_move_static_delegate = new efl_ui_drag_step_move_delegate(drag_step_move);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_drag_step_move"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_drag_step_move_static_delegate)});
      if (efl_ui_drag_page_move_static_delegate == null)
      efl_ui_drag_page_move_static_delegate = new efl_ui_drag_page_move_delegate(drag_page_move);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_drag_page_move"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_drag_page_move_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Canvas.LayoutPart.efl_canvas_layout_part_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Canvas.LayoutPart.efl_canvas_layout_part_class_get();
   }


    private delegate  void efl_canvas_layout_part_state_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  out  System.String state,   out double val);


    public delegate  void efl_canvas_layout_part_state_get_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  out  System.String state,   out double val);
    public static Efl.Eo.FunctionWrapper<efl_canvas_layout_part_state_get_api_delegate> efl_canvas_layout_part_state_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_layout_part_state_get_api_delegate>(_Module, "efl_canvas_layout_part_state_get");
    private static  void state_get(System.IntPtr obj, System.IntPtr pd,  out  System.String state,  out double val)
   {
      Eina.Log.Debug("function efl_canvas_layout_part_state_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                            System.String _out_state = default( System.String);
      val = default(double);                     
         try {
            ((LayoutPart)wrapper).GetState( out _out_state,  out val);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      state = _out_state;
                              } else {
         efl_canvas_layout_part_state_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out state,  out val);
      }
   }
   private static efl_canvas_layout_part_state_get_delegate efl_canvas_layout_part_state_get_static_delegate;


    private delegate Efl.Canvas.LayoutPartType efl_canvas_layout_part_type_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Efl.Canvas.LayoutPartType efl_canvas_layout_part_type_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_canvas_layout_part_type_get_api_delegate> efl_canvas_layout_part_type_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_layout_part_type_get_api_delegate>(_Module, "efl_canvas_layout_part_type_get");
    private static Efl.Canvas.LayoutPartType part_type_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_canvas_layout_part_type_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Canvas.LayoutPartType _ret_var = default(Efl.Canvas.LayoutPartType);
         try {
            _ret_var = ((LayoutPart)wrapper).GetPartType();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_canvas_layout_part_type_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_canvas_layout_part_type_get_delegate efl_canvas_layout_part_type_get_static_delegate;


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
            _ret_var = ((LayoutPart)wrapper).GetPosition();
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
            ((LayoutPart)wrapper).SetPosition( _in_pos);
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
            _ret_var = ((LayoutPart)wrapper).GetSize();
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
            ((LayoutPart)wrapper).SetSize( _in_size);
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
            _ret_var = ((LayoutPart)wrapper).GetGeometry();
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
            ((LayoutPart)wrapper).SetGeometry( _in_rect);
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
            _ret_var = ((LayoutPart)wrapper).GetVisible();
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
            ((LayoutPart)wrapper).SetVisible( v);
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
            _ret_var = ((LayoutPart)wrapper).GetScale();
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
            ((LayoutPart)wrapper).SetScale( scale);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_entity_scale_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  scale);
      }
   }
   private static efl_gfx_entity_scale_set_delegate efl_gfx_entity_scale_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_drag_value_get_delegate(System.IntPtr obj, System.IntPtr pd,   out double dx,   out double dy);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_drag_value_get_api_delegate(System.IntPtr obj,   out double dx,   out double dy);
    public static Efl.Eo.FunctionWrapper<efl_ui_drag_value_get_api_delegate> efl_ui_drag_value_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_drag_value_get_api_delegate>(_Module, "efl_ui_drag_value_get");
    private static bool drag_value_get(System.IntPtr obj, System.IntPtr pd,  out double dx,  out double dy)
   {
      Eina.Log.Debug("function efl_ui_drag_value_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           dx = default(double);      dy = default(double);                     bool _ret_var = default(bool);
         try {
            _ret_var = ((LayoutPart)wrapper).GetDragValue( out dx,  out dy);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_ui_drag_value_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out dx,  out dy);
      }
   }
   private static efl_ui_drag_value_get_delegate efl_ui_drag_value_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_drag_value_set_delegate(System.IntPtr obj, System.IntPtr pd,   double dx,   double dy);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_drag_value_set_api_delegate(System.IntPtr obj,   double dx,   double dy);
    public static Efl.Eo.FunctionWrapper<efl_ui_drag_value_set_api_delegate> efl_ui_drag_value_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_drag_value_set_api_delegate>(_Module, "efl_ui_drag_value_set");
    private static bool drag_value_set(System.IntPtr obj, System.IntPtr pd,  double dx,  double dy)
   {
      Eina.Log.Debug("function efl_ui_drag_value_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      bool _ret_var = default(bool);
         try {
            _ret_var = ((LayoutPart)wrapper).SetDragValue( dx,  dy);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_ui_drag_value_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  dx,  dy);
      }
   }
   private static efl_ui_drag_value_set_delegate efl_ui_drag_value_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_drag_size_get_delegate(System.IntPtr obj, System.IntPtr pd,   out double dw,   out double dh);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_drag_size_get_api_delegate(System.IntPtr obj,   out double dw,   out double dh);
    public static Efl.Eo.FunctionWrapper<efl_ui_drag_size_get_api_delegate> efl_ui_drag_size_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_drag_size_get_api_delegate>(_Module, "efl_ui_drag_size_get");
    private static bool drag_size_get(System.IntPtr obj, System.IntPtr pd,  out double dw,  out double dh)
   {
      Eina.Log.Debug("function efl_ui_drag_size_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           dw = default(double);      dh = default(double);                     bool _ret_var = default(bool);
         try {
            _ret_var = ((LayoutPart)wrapper).GetDragSize( out dw,  out dh);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_ui_drag_size_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out dw,  out dh);
      }
   }
   private static efl_ui_drag_size_get_delegate efl_ui_drag_size_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_drag_size_set_delegate(System.IntPtr obj, System.IntPtr pd,   double dw,   double dh);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_drag_size_set_api_delegate(System.IntPtr obj,   double dw,   double dh);
    public static Efl.Eo.FunctionWrapper<efl_ui_drag_size_set_api_delegate> efl_ui_drag_size_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_drag_size_set_api_delegate>(_Module, "efl_ui_drag_size_set");
    private static bool drag_size_set(System.IntPtr obj, System.IntPtr pd,  double dw,  double dh)
   {
      Eina.Log.Debug("function efl_ui_drag_size_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      bool _ret_var = default(bool);
         try {
            _ret_var = ((LayoutPart)wrapper).SetDragSize( dw,  dh);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_ui_drag_size_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  dw,  dh);
      }
   }
   private static efl_ui_drag_size_set_delegate efl_ui_drag_size_set_static_delegate;


    private delegate Efl.Ui.DragDir efl_ui_drag_dir_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Efl.Ui.DragDir efl_ui_drag_dir_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_drag_dir_get_api_delegate> efl_ui_drag_dir_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_drag_dir_get_api_delegate>(_Module, "efl_ui_drag_dir_get");
    private static Efl.Ui.DragDir drag_dir_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_drag_dir_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Ui.DragDir _ret_var = default(Efl.Ui.DragDir);
         try {
            _ret_var = ((LayoutPart)wrapper).GetDragDir();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_drag_dir_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_drag_dir_get_delegate efl_ui_drag_dir_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_drag_step_get_delegate(System.IntPtr obj, System.IntPtr pd,   out double dx,   out double dy);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_drag_step_get_api_delegate(System.IntPtr obj,   out double dx,   out double dy);
    public static Efl.Eo.FunctionWrapper<efl_ui_drag_step_get_api_delegate> efl_ui_drag_step_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_drag_step_get_api_delegate>(_Module, "efl_ui_drag_step_get");
    private static bool drag_step_get(System.IntPtr obj, System.IntPtr pd,  out double dx,  out double dy)
   {
      Eina.Log.Debug("function efl_ui_drag_step_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           dx = default(double);      dy = default(double);                     bool _ret_var = default(bool);
         try {
            _ret_var = ((LayoutPart)wrapper).GetDragStep( out dx,  out dy);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_ui_drag_step_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out dx,  out dy);
      }
   }
   private static efl_ui_drag_step_get_delegate efl_ui_drag_step_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_drag_step_set_delegate(System.IntPtr obj, System.IntPtr pd,   double dx,   double dy);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_drag_step_set_api_delegate(System.IntPtr obj,   double dx,   double dy);
    public static Efl.Eo.FunctionWrapper<efl_ui_drag_step_set_api_delegate> efl_ui_drag_step_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_drag_step_set_api_delegate>(_Module, "efl_ui_drag_step_set");
    private static bool drag_step_set(System.IntPtr obj, System.IntPtr pd,  double dx,  double dy)
   {
      Eina.Log.Debug("function efl_ui_drag_step_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      bool _ret_var = default(bool);
         try {
            _ret_var = ((LayoutPart)wrapper).SetDragStep( dx,  dy);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_ui_drag_step_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  dx,  dy);
      }
   }
   private static efl_ui_drag_step_set_delegate efl_ui_drag_step_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_drag_page_get_delegate(System.IntPtr obj, System.IntPtr pd,   out double dx,   out double dy);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_drag_page_get_api_delegate(System.IntPtr obj,   out double dx,   out double dy);
    public static Efl.Eo.FunctionWrapper<efl_ui_drag_page_get_api_delegate> efl_ui_drag_page_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_drag_page_get_api_delegate>(_Module, "efl_ui_drag_page_get");
    private static bool drag_page_get(System.IntPtr obj, System.IntPtr pd,  out double dx,  out double dy)
   {
      Eina.Log.Debug("function efl_ui_drag_page_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           dx = default(double);      dy = default(double);                     bool _ret_var = default(bool);
         try {
            _ret_var = ((LayoutPart)wrapper).GetDragPage( out dx,  out dy);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_ui_drag_page_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out dx,  out dy);
      }
   }
   private static efl_ui_drag_page_get_delegate efl_ui_drag_page_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_drag_page_set_delegate(System.IntPtr obj, System.IntPtr pd,   double dx,   double dy);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_drag_page_set_api_delegate(System.IntPtr obj,   double dx,   double dy);
    public static Efl.Eo.FunctionWrapper<efl_ui_drag_page_set_api_delegate> efl_ui_drag_page_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_drag_page_set_api_delegate>(_Module, "efl_ui_drag_page_set");
    private static bool drag_page_set(System.IntPtr obj, System.IntPtr pd,  double dx,  double dy)
   {
      Eina.Log.Debug("function efl_ui_drag_page_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      bool _ret_var = default(bool);
         try {
            _ret_var = ((LayoutPart)wrapper).SetDragPage( dx,  dy);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_ui_drag_page_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  dx,  dy);
      }
   }
   private static efl_ui_drag_page_set_delegate efl_ui_drag_page_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_drag_step_move_delegate(System.IntPtr obj, System.IntPtr pd,   double dx,   double dy);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_drag_step_move_api_delegate(System.IntPtr obj,   double dx,   double dy);
    public static Efl.Eo.FunctionWrapper<efl_ui_drag_step_move_api_delegate> efl_ui_drag_step_move_ptr = new Efl.Eo.FunctionWrapper<efl_ui_drag_step_move_api_delegate>(_Module, "efl_ui_drag_step_move");
    private static bool drag_step_move(System.IntPtr obj, System.IntPtr pd,  double dx,  double dy)
   {
      Eina.Log.Debug("function efl_ui_drag_step_move was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      bool _ret_var = default(bool);
         try {
            _ret_var = ((LayoutPart)wrapper).MoveDragStep( dx,  dy);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_ui_drag_step_move_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  dx,  dy);
      }
   }
   private static efl_ui_drag_step_move_delegate efl_ui_drag_step_move_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_drag_page_move_delegate(System.IntPtr obj, System.IntPtr pd,   double dx,   double dy);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_drag_page_move_api_delegate(System.IntPtr obj,   double dx,   double dy);
    public static Efl.Eo.FunctionWrapper<efl_ui_drag_page_move_api_delegate> efl_ui_drag_page_move_ptr = new Efl.Eo.FunctionWrapper<efl_ui_drag_page_move_api_delegate>(_Module, "efl_ui_drag_page_move");
    private static bool drag_page_move(System.IntPtr obj, System.IntPtr pd,  double dx,  double dy)
   {
      Eina.Log.Debug("function efl_ui_drag_page_move was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      bool _ret_var = default(bool);
         try {
            _ret_var = ((LayoutPart)wrapper).MoveDragPage( dx,  dy);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_ui_drag_page_move_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  dx,  dy);
      }
   }
   private static efl_ui_drag_page_move_delegate efl_ui_drag_page_move_static_delegate;
}
} } 
