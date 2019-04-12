#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Canvas { 
///<summary>Event argument wrapper for event <see cref="Efl.Canvas.Layout.PartInvalidEvt"/>.</summary>
public class LayoutPartInvalidEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public  System.String arg { get; set; }
}
/// <summary>Edje object class</summary>
[LayoutNativeInherit]
public class Layout : Efl.Canvas.Group, Efl.Eo.IWrapper,Efl.Container,Efl.File,Efl.Observer,Efl.Part,Efl.Player,Efl.Gfx.ColorClass,Efl.Gfx.SizeClass,Efl.Gfx.TextClass,Efl.Layout.Calc,Efl.Layout.Group,Efl.Layout.Signal
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Canvas.LayoutNativeInherit nativeInherit = new Efl.Canvas.LayoutNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (Layout))
            return Efl.Canvas.LayoutNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
      }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Edje)] internal static extern System.IntPtr
      efl_canvas_layout_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   public Layout(Efl.Object parent= null
         ) :
      base(efl_canvas_layout_class_get(), typeof(Layout), parent)
   {
      FinishInstantiation();
   }
   ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
   public Layout(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
   protected Layout(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static Layout static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new Layout(obj.NativeHandle);
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
private static object PartInvalidEvtKey = new object();
   /// <summary>Emitted when trying to use an invalid part. The value passed is the part name.</summary>
   public event EventHandler<Efl.Canvas.LayoutPartInvalidEvt_Args> PartInvalidEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_LAYOUT_EVENT_PART_INVALID";
            if (add_cpp_event_handler(efl.Libs.Edje, key, this.evt_PartInvalidEvt_delegate)) {
               eventHandlers.AddHandler(PartInvalidEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_LAYOUT_EVENT_PART_INVALID";
            if (remove_cpp_event_handler(key, this.evt_PartInvalidEvt_delegate)) { 
               eventHandlers.RemoveHandler(PartInvalidEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event PartInvalidEvt.</summary>
   public void On_PartInvalidEvt(Efl.Canvas.LayoutPartInvalidEvt_Args e)
   {
      EventHandler<Efl.Canvas.LayoutPartInvalidEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Canvas.LayoutPartInvalidEvt_Args>)eventHandlers[PartInvalidEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_PartInvalidEvt_delegate;
   private void on_PartInvalidEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Canvas.LayoutPartInvalidEvt_Args args = new Efl.Canvas.LayoutPartInvalidEvt_Args();
      args.arg = Eina.StringConversion.NativeUtf8ToManagedString(evt.Info);
      try {
         On_PartInvalidEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object ContentAddedEvtKey = new object();
   /// <summary>Sent after a new item was added.</summary>
   public event EventHandler<Efl.ContainerContentAddedEvt_Args> ContentAddedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_CONTAINER_EVENT_CONTENT_ADDED";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_ContentAddedEvt_delegate)) {
               eventHandlers.AddHandler(ContentAddedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_CONTAINER_EVENT_CONTENT_ADDED";
            if (remove_cpp_event_handler(key, this.evt_ContentAddedEvt_delegate)) { 
               eventHandlers.RemoveHandler(ContentAddedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ContentAddedEvt.</summary>
   public void On_ContentAddedEvt(Efl.ContainerContentAddedEvt_Args e)
   {
      EventHandler<Efl.ContainerContentAddedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.ContainerContentAddedEvt_Args>)eventHandlers[ContentAddedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ContentAddedEvt_delegate;
   private void on_ContentAddedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.ContainerContentAddedEvt_Args args = new Efl.ContainerContentAddedEvt_Args();
      args.arg = new Efl.Gfx.EntityConcrete(evt.Info);
      try {
         On_ContentAddedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object ContentRemovedEvtKey = new object();
   /// <summary>Sent after an item was removed, before unref.</summary>
   public event EventHandler<Efl.ContainerContentRemovedEvt_Args> ContentRemovedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_CONTAINER_EVENT_CONTENT_REMOVED";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_ContentRemovedEvt_delegate)) {
               eventHandlers.AddHandler(ContentRemovedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_CONTAINER_EVENT_CONTENT_REMOVED";
            if (remove_cpp_event_handler(key, this.evt_ContentRemovedEvt_delegate)) { 
               eventHandlers.RemoveHandler(ContentRemovedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ContentRemovedEvt.</summary>
   public void On_ContentRemovedEvt(Efl.ContainerContentRemovedEvt_Args e)
   {
      EventHandler<Efl.ContainerContentRemovedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.ContainerContentRemovedEvt_Args>)eventHandlers[ContentRemovedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ContentRemovedEvt_delegate;
   private void on_ContentRemovedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.ContainerContentRemovedEvt_Args args = new Efl.ContainerContentRemovedEvt_Args();
      args.arg = new Efl.Gfx.EntityConcrete(evt.Info);
      try {
         On_ContentRemovedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object RecalcEvtKey = new object();
   /// <summary>The layout was recalculated.
   /// 1.21</summary>
   public event EventHandler RecalcEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_LAYOUT_EVENT_RECALC";
            if (add_cpp_event_handler(efl.Libs.Edje, key, this.evt_RecalcEvt_delegate)) {
               eventHandlers.AddHandler(RecalcEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_LAYOUT_EVENT_RECALC";
            if (remove_cpp_event_handler(key, this.evt_RecalcEvt_delegate)) { 
               eventHandlers.RemoveHandler(RecalcEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event RecalcEvt.</summary>
   public void On_RecalcEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[RecalcEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_RecalcEvt_delegate;
   private void on_RecalcEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_RecalcEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object CircularDependencyEvtKey = new object();
   /// <summary>A circular dependency between parts of the object was found.
   /// 1.21</summary>
   public event EventHandler CircularDependencyEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_LAYOUT_EVENT_CIRCULAR_DEPENDENCY";
            if (add_cpp_event_handler(efl.Libs.Edje, key, this.evt_CircularDependencyEvt_delegate)) {
               eventHandlers.AddHandler(CircularDependencyEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_LAYOUT_EVENT_CIRCULAR_DEPENDENCY";
            if (remove_cpp_event_handler(key, this.evt_CircularDependencyEvt_delegate)) { 
               eventHandlers.RemoveHandler(CircularDependencyEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event CircularDependencyEvt.</summary>
   public void On_CircularDependencyEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[CircularDependencyEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_CircularDependencyEvt_delegate;
   private void on_CircularDependencyEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_CircularDependencyEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

   protected override void register_event_proxies()
   {
      base.register_event_proxies();
      evt_PartInvalidEvt_delegate = new Efl.EventCb(on_PartInvalidEvt_NativeCallback);
      evt_ContentAddedEvt_delegate = new Efl.EventCb(on_ContentAddedEvt_NativeCallback);
      evt_ContentRemovedEvt_delegate = new Efl.EventCb(on_ContentRemovedEvt_NativeCallback);
      evt_RecalcEvt_delegate = new Efl.EventCb(on_RecalcEvt_NativeCallback);
      evt_CircularDependencyEvt_delegate = new Efl.EventCb(on_CircularDependencyEvt_NativeCallback);
   }
   /// <summary>Get the current state of animation, <c>true</c> by default.</summary>
   /// <returns>The animation state, <c>true</c> by default.</returns>
   virtual public bool GetAnimation() {
       var _ret_var = Efl.Canvas.LayoutNativeInherit.efl_canvas_layout_animation_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Start or stop animating this object.</summary>
   /// <param name="on">The animation state, <c>true</c> by default.</param>
   /// <returns></returns>
   virtual public  void SetAnimation( bool on) {
                         Efl.Canvas.LayoutNativeInherit.efl_canvas_layout_animation_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), on);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Returns the seat device given its Edje&apos;s name.
   /// Edje references seats by a name that differs from Evas. Edje naming follows a incrementional convention: first registered name is &quot;seat1&quot;, second is &quot;seat2&quot;, differently from Evas.
   /// 1.19</summary>
   /// <param name="name">The name&apos;s character string.</param>
   /// <returns>The seat device or <c>null</c> if not found.</returns>
   virtual public Efl.Input.Device GetSeat(  System.String name) {
                         var _ret_var = Efl.Canvas.LayoutNativeInherit.efl_canvas_layout_seat_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), name);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Gets the name given to a set by Edje.
   /// Edje references seats by a name that differs from Evas. Edje naming follows a incrementional convention: first registered name is &quot;seat1&quot;, second is &quot;seat2&quot;, differently from Evas.
   /// 1.19</summary>
   /// <param name="device">The seat device</param>
   /// <returns>The name&apos;s character string or <c>null</c> if not found.</returns>
   virtual public  System.String GetSeatName( Efl.Input.Device device) {
                         var _ret_var = Efl.Canvas.LayoutNativeInherit.efl_canvas_layout_seat_name_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), device);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Gets the (last) file loading error for a given object.</summary>
   /// <returns>The load error code.</returns>
   virtual public Efl.Gfx.ImageLoadError GetLayoutLoadError() {
       var _ret_var = Efl.Canvas.LayoutNativeInherit.efl_canvas_layout_load_error_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Gets the object text min calculation policy.
   /// Do not use this API without understanding whats going on. It is made for internal usage.
   /// 
   /// @if MOBILE @since_tizen 3.0 @elseif WEARABLE @since_tizen 3.0 @endif @internal</summary>
   /// <param name="part">The part name</param>
   /// <param name="state_name">The state name</param>
   /// <param name="min_x">The min width policy</param>
   /// <param name="min_y">The min height policy</param>
   /// <returns><c>true</c> on success, or <c>false</c> on error</returns>
   virtual public bool GetPartTextMinPolicy(  System.String part,   System.String state_name,  out bool min_x,  out bool min_y) {
                                                                               var _ret_var = Efl.Canvas.LayoutNativeInherit.efl_canvas_layout_part_text_min_policy_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), part,  state_name,  out min_x,  out min_y);
      Eina.Error.RaiseIfUnhandledException();
                                                      return _ret_var;
 }
   /// <summary>Sets the object text min calculation policy.
   /// Do not use this API without understanding whats going on. It is made for internal usage.
   /// 
   /// @if MOBILE @since_tizen 3.0 @elseif WEARABLE @since_tizen 3.0 @endif @internal</summary>
   /// <param name="part">The part name</param>
   /// <param name="state_name">The state name</param>
   /// <param name="min_x">The min width policy</param>
   /// <param name="min_y">The min height policy</param>
   /// <returns><c>true</c> on success, or <c>false</c> on error</returns>
   virtual public bool SetPartTextMinPolicy(  System.String part,   System.String state_name,  bool min_x,  bool min_y) {
                                                                               var _ret_var = Efl.Canvas.LayoutNativeInherit.efl_canvas_layout_part_text_min_policy_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), part,  state_name,  min_x,  min_y);
      Eina.Error.RaiseIfUnhandledException();
                                                      return _ret_var;
 }
   /// <summary>Gets the valign for text.
   /// Do not use this API without understanding whats going on. It is made for internal usage. @internal</summary>
   /// <param name="part">The part name</param>
   /// <returns>The valign 0.0~1.0. -1.0 for respect EDC&apos;s align value.</returns>
   virtual public double GetPartTextValign(  System.String part) {
                         var _ret_var = Efl.Canvas.LayoutNativeInherit.efl_canvas_layout_part_text_valign_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), part);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Sets the valign for text.
   /// Do not use this API without understanding whats going on. It is made for internal usage. @internal</summary>
   /// <param name="part">The part name</param>
   /// <param name="valign">The valign 0.0~1.0. -1.0 for respect EDC&apos;s align value.</param>
   /// <returns><c>true</c>, on success or <c>false</c>, on error</returns>
   virtual public bool SetPartTextValign(  System.String part,  double valign) {
                                           var _ret_var = Efl.Canvas.LayoutNativeInherit.efl_canvas_layout_part_text_valign_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), part,  valign);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }
   /// <summary>Gets the duration for text&apos;s marquee.
   /// Do not use this API without understanding whats going on. It is made for internal usage. @internal</summary>
   /// <param name="part">The part name</param>
   /// <returns>The duration. 0.0 for respect EDC&apos;s duration value.</returns>
   virtual public double GetPartTextMarqueeDuration(  System.String part) {
                         var _ret_var = Efl.Canvas.LayoutNativeInherit.efl_canvas_layout_part_text_marquee_duration_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), part);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Sets the duration for text&apos;s marquee.
   /// Do not use this API without understanding whats going on. It is made for internal usage. @internal</summary>
   /// <param name="part">The part name</param>
   /// <param name="duration">The duration. 0.0 for respect EDC&apos;s duration value.</param>
   /// <returns><c>true</c>, on success or <c>false</c>, on error</returns>
   virtual public bool SetPartTextMarqueeDuration(  System.String part,  double duration) {
                                           var _ret_var = Efl.Canvas.LayoutNativeInherit.efl_canvas_layout_part_text_marquee_duration_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), part,  duration);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }
   /// <summary>Gets the speed for text&apos;s marquee.
   /// Do not use this API without understanding whats going on. It is made for internal usage. @internal</summary>
   /// <param name="part">The part name</param>
   /// <returns>The speed. 0.0 for respect EDC&apos;s speed value.</returns>
   virtual public double GetPartTextMarqueeSpeed(  System.String part) {
                         var _ret_var = Efl.Canvas.LayoutNativeInherit.efl_canvas_layout_part_text_marquee_speed_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), part);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Sets the speed for text&apos;s marquee.
   /// Do not use this API without understanding whats going on. It is made for internal usage. @internal</summary>
   /// <param name="part">The part name</param>
   /// <param name="speed">The speed. 0.0 for respect EDC&apos;s speed value.</param>
   /// <returns><c>true</c>, on success or <c>false</c>, on error</returns>
   virtual public bool SetPartTextMarqueeSpeed(  System.String part,  double speed) {
                                           var _ret_var = Efl.Canvas.LayoutNativeInherit.efl_canvas_layout_part_text_marquee_speed_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), part,  speed);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }
   /// <summary>Gets the always mode for text&apos;s marquee.
   /// Do not use this API without understanding whats going on. It is made for internal usage. @internal</summary>
   /// <param name="part">The part name</param>
   /// <returns>The always mode</returns>
   virtual public bool GetPartTextMarqueeAlways(  System.String part) {
                         var _ret_var = Efl.Canvas.LayoutNativeInherit.efl_canvas_layout_part_text_marquee_always_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), part);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Sets the always mode for text&apos;s marquee.
   /// Do not use this API without understanding whats going on. It is made for internal usage. @internal</summary>
   /// <param name="part">The part name</param>
   /// <param name="always">The always mode</param>
   /// <returns><c>true</c>, on success or <c>false</c>, on error</returns>
   virtual public bool SetPartTextMarqueeAlways(  System.String part,  bool always) {
                                           var _ret_var = Efl.Canvas.LayoutNativeInherit.efl_canvas_layout_part_text_marquee_always_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), part,  always);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }
   /// <summary>Gets the valign for a common description.
   /// Do not use this API without understanding whats going on. It is made for internal usage. @internal</summary>
   /// <param name="part">The part name</param>
   /// <returns>The valign 0.0~1.0. -1.0 for respect EDC&apos;s align value.</returns>
   virtual public double GetPartValign(  System.String part) {
                         var _ret_var = Efl.Canvas.LayoutNativeInherit.efl_canvas_layout_part_valign_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), part);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Sets the valign for a common description.
   /// Do not use this API without understanding whats going on. It is made for internal usage. @internal</summary>
   /// <param name="part">The part name</param>
   /// <param name="valign">The valign 0.0~1.0. -1.0 for respect EDC&apos;s align value.</param>
   /// <returns><c>true</c>, on success or <c>false</c>, on error</returns>
   virtual public bool SetPartValign(  System.String part,  double valign) {
                                           var _ret_var = Efl.Canvas.LayoutNativeInherit.efl_canvas_layout_part_valign_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), part,  valign);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }
   /// <summary>Iterates over all accessibility-enabled part names.</summary>
   /// <returns>Part name iterator</returns>
   virtual public Eina.Iterator< System.String> AccessPartIterate() {
       var _ret_var = Efl.Canvas.LayoutNativeInherit.efl_canvas_layout_access_part_iterate_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return new Eina.Iterator< System.String>(_ret_var, true, false);
 }
   /// <summary>Unswallow an object from this Edje.</summary>
   /// <param name="content">To be removed content.</param>
   /// <returns><c>false</c> if <c>content</c> was not a child or can not be removed.</returns>
   virtual public bool ContentRemove( Efl.Gfx.Entity content) {
                         var _ret_var = Efl.Canvas.LayoutNativeInherit.efl_canvas_layout_content_remove_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), content);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Sets the parent object for color class.
   /// @if MOBILE @since_tizen 3.0 @elseif WEARABLE @since_tizen 3.0 @endif @internal</summary>
   /// <param name="parent">The parent object for color class</param>
   /// <returns></returns>
   virtual public  void SetColorClassParent( Efl.Object parent) {
                         Efl.Canvas.LayoutNativeInherit.efl_canvas_layout_color_class_parent_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), parent);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Unsets the parent object for color class.
   /// @if MOBILE @since_tizen 3.0 @elseif WEARABLE @since_tizen 3.0 @endif @internal</summary>
   /// <returns></returns>
   virtual public  void UnsetColorClassParent() {
       Efl.Canvas.LayoutNativeInherit.efl_canvas_layout_color_class_parent_unset_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }
   /// <summary>Get a position of the given cursor
   /// @internal</summary>
   /// <param name="part">The part name</param>
   /// <param name="cur">cursor type</param>
   /// <param name="x">w</param>
   /// <param name="y">h</param>
   /// <returns></returns>
   virtual public  void GetPartTextCursorCoord(  System.String part,  Edje.Cursor cur,  out  int x,  out  int y) {
                                                                               Efl.Canvas.LayoutNativeInherit.efl_canvas_layout_part_text_cursor_coord_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), part,  cur,  out x,  out y);
      Eina.Error.RaiseIfUnhandledException();
                                                       }
   /// <summary>Get a size of the given cursor
   /// @internal</summary>
   /// <param name="part">The part name</param>
   /// <param name="cur">cursor type</param>
   /// <param name="w">w</param>
   /// <param name="h">h</param>
   /// <returns></returns>
   virtual public  void GetPartTextCursorSize(  System.String part,  Edje.Cursor cur,  out  int w,  out  int h) {
                                                                               Efl.Canvas.LayoutNativeInherit.efl_canvas_layout_part_text_cursor_size_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), part,  cur,  out w,  out h);
      Eina.Error.RaiseIfUnhandledException();
                                                       }
   /// <summary>Returns the cursor geometry of the part relative to the edje object. The cursor geometry is kept in mouse down and move.
   /// @internal @if MOBILE @since_tizen 3.0 @elseif WEARABLE @since_tizen 3.0 @endif</summary>
   /// <param name="part">The part name</param>
   /// <param name="x">Cursor X position</param>
   /// <param name="y">Cursor Y position</param>
   /// <param name="w">Cursor width</param>
   /// <param name="h">Cursor height</param>
   /// <returns></returns>
   virtual public  void GetPartTextCursorOnMouseGeometry(  System.String part,  out  int x,  out  int y,  out  int w,  out  int h) {
                                                                                                 Efl.Canvas.LayoutNativeInherit.efl_canvas_layout_part_text_cursor_on_mouse_geometry_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), part,  out x,  out y,  out w,  out h);
      Eina.Error.RaiseIfUnhandledException();
                                                                   }
   /// <summary>Begin iterating over this object&apos;s contents.</summary>
   /// <returns>Iterator to object content</returns>
   virtual public Eina.Iterator<Efl.Gfx.Entity> ContentIterate() {
       var _ret_var = Efl.ContainerNativeInherit.efl_content_iterate_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return new Eina.Iterator<Efl.Gfx.Entity>(_ret_var, true, false);
 }
   /// <summary>Returns the number of UI elements packed in this container.</summary>
   /// <returns>Number of packed UI elements</returns>
   virtual public  int ContentCount() {
       var _ret_var = Efl.ContainerNativeInherit.efl_content_count_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Get the mmaped file from where an object will fetch the real data (it must be an Eina_File).</summary>
   /// <returns>The handle to an Eina_File that will be used</returns>
   virtual public Eina.File GetMmap() {
       var _ret_var = Efl.FileNativeInherit.efl_file_mmap_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Set the mmaped file from where an object will fetch the real data (it must be an Eina_File).
   /// If mmap is set during object construction, the object will automatically call <see cref="Efl.File.Load"/> during the finalize phase of construction.</summary>
   /// <param name="f">The handle to an Eina_File that will be used</param>
   /// <returns>0 on success, error code otherwise</returns>
   virtual public  Eina.Error SetMmap( Eina.File f) {
                         var _ret_var = Efl.FileNativeInherit.efl_file_mmap_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), f);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Retrieve the file path from where an object is to fetch the data.
   /// You must not modify the strings on the returned pointers.</summary>
   /// <returns>The file path.</returns>
   virtual public  System.String GetFile() {
       var _ret_var = Efl.FileNativeInherit.efl_file_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Set the file path from where an object will fetch the data.
   /// If file is set during object construction, the object will automatically call <see cref="Efl.File.Load"/> during the finalize phase of construction.</summary>
   /// <param name="file">The file path.</param>
   /// <returns>0 on success, error code otherwise</returns>
   virtual public  Eina.Error SetFile(  System.String file) {
                         var _ret_var = Efl.FileNativeInherit.efl_file_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), file);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Get the previously-set key which corresponds to the target data within a file.
   /// Some filetypes can contain multiple data streams which are indexed by a key. Use this property for such cases.
   /// 
   /// You must not modify the strings on the returned pointers.</summary>
   /// <returns>The group that the image belongs to, in case  it&apos;s an EET(including Edje case) file. This can be used as a key inside evas image cache if this is a normal image file not eet file.</returns>
   virtual public  System.String GetKey() {
       var _ret_var = Efl.FileNativeInherit.efl_file_key_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Set the key which corresponds to the target data within a file.
   /// Some filetypes can contain multiple data streams which are indexed by a key. Use this property for such cases.</summary>
   /// <param name="key">The group that the image belongs to, in case  it&apos;s an EET(including Edje case) file. This can be used as a key inside evas image cache if this is a normal image file not eet file.</param>
   /// <returns></returns>
   virtual public  void SetKey(  System.String key) {
                         Efl.FileNativeInherit.efl_file_key_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), key);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Get the load state of the object.</summary>
   /// <returns>True if the object is loaded, otherwise false.</returns>
   virtual public bool GetLoaded() {
       var _ret_var = Efl.FileNativeInherit.efl_file_loaded_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Perform all necessary operations to open and load file data into the object using the <see cref="Efl.File.File"/> (or <see cref="Efl.File.Mmap"/>) and <see cref="Efl.File.Key"/> properties.
   /// In the case where <see cref="Efl.File.SetFile"/> has been called on an object, this will internally open the file and call <see cref="Efl.File.SetMmap"/> on the object using the opened file handle.
   /// 
   /// Calling <see cref="Efl.File.Load"/> on an object which has already performed file operations based on the currently set properties will have no effect.</summary>
   /// <returns>0 on success, error code otherwise</returns>
   virtual public  Eina.Error Load() {
       var _ret_var = Efl.FileNativeInherit.efl_file_load_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Perform all necessary operations to unload file data from the object.
   /// In the case where <see cref="Efl.File.SetMmap"/> has been externally called on an object, the file handle stored in the object will be preserved.
   /// 
   /// Calling <see cref="Efl.File.Unload"/> on an object which is not currently loaded will have no effect.</summary>
   /// <returns></returns>
   virtual public  void Unload() {
       Efl.FileNativeInherit.efl_file_unload_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }
   /// <summary>Update observer according to the changes of observable object.
   /// 1.19</summary>
   /// <param name="obs">An observable object</param>
   /// <param name="key">A key to classify observer groups</param>
   /// <param name="data">Required data to update the observer, usually passed by observable object</param>
   /// <returns></returns>
   virtual public  void Update( Efl.Object obs,   System.String key,   System.IntPtr data) {
                                                             Efl.ObserverNativeInherit.efl_observer_update_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), obs,  key,  data);
      Eina.Error.RaiseIfUnhandledException();
                                           }
   /// <summary>Get a proxy object referring to a part of an object.</summary>
   /// <param name="name">The part name.</param>
   /// <returns>A (proxy) object, valid for a single call.</returns>
   virtual public Efl.Object GetPart(  System.String name) {
                         var _ret_var = Efl.PartNativeInherit.efl_part_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), name);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Whether or not the playable can be played.</summary>
   /// <returns><c>true</c> if the object have playable data, <c>false</c> otherwise</returns>
   virtual public bool GetPlayable() {
       var _ret_var = Efl.PlayerNativeInherit.efl_player_playable_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Get play/pause state of the media file.</summary>
   /// <returns><c>true</c> if playing, <c>false</c> otherwise.</returns>
   virtual public bool GetPlay() {
       var _ret_var = Efl.PlayerNativeInherit.efl_player_play_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Set play/pause state of the media file.
   /// This functions sets the currently playing status of the video. Using this function to play or pause the video doesn&apos;t alter it&apos;s current position.</summary>
   /// <param name="play"><c>true</c> if playing, <c>false</c> otherwise.</param>
   /// <returns></returns>
   virtual public  void SetPlay( bool play) {
                         Efl.PlayerNativeInherit.efl_player_play_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), play);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Get the position in the media file.
   /// The position is returned as the number of seconds since the beginning of the media file.</summary>
   /// <returns>The position (in seconds).</returns>
   virtual public double GetPos() {
       var _ret_var = Efl.PlayerNativeInherit.efl_player_pos_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Set the position in the media file.
   /// This functions sets the current position of the media file to &quot;sec&quot;, this only works on seekable streams. Setting the position doesn&apos;t change the playing state of the media file.</summary>
   /// <param name="sec">The position (in seconds).</param>
   /// <returns></returns>
   virtual public  void SetPos( double sec) {
                         Efl.PlayerNativeInherit.efl_player_pos_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), sec);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Get how much of the file has been played.
   /// This function gets the progress in playing the file, the return value is in the [0, 1] range.</summary>
   /// <returns>The progress within the [0, 1] range.</returns>
   virtual public double GetProgress() {
       var _ret_var = Efl.PlayerNativeInherit.efl_player_progress_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Control the play speed of the media file.
   /// This function control the speed with which the media file will be played. 1.0 represents the normal speed, 2 double speed, 0.5 half speed and so on.</summary>
   /// <returns>The play speed in the [0, infinity) range.</returns>
   virtual public double GetPlaySpeed() {
       var _ret_var = Efl.PlayerNativeInherit.efl_player_play_speed_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Control the play speed of the media file.
   /// This function control the speed with which the media file will be played. 1.0 represents the normal speed, 2 double speed, 0.5 half speed and so on.</summary>
   /// <param name="speed">The play speed in the [0, infinity) range.</param>
   /// <returns></returns>
   virtual public  void SetPlaySpeed( double speed) {
                         Efl.PlayerNativeInherit.efl_player_play_speed_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), speed);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Control the audio volume.
   /// Controls the audio volume of the stream being played. This has nothing to do with the system volume. This volume will be multiplied by the system volume. e.g.: if the current volume level is 0.5, and the system volume is 50%, it will be 0.5 * 0.5 = 0.25.</summary>
   /// <returns>The volume level</returns>
   virtual public double GetVolume() {
       var _ret_var = Efl.PlayerNativeInherit.efl_player_volume_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Control the audio volume.
   /// Controls the audio volume of the stream being played. This has nothing to do with the system volume. This volume will be multiplied by the system volume. e.g.: if the current volume level is 0.5, and the system volume is 50%, it will be 0.5 * 0.5 = 0.25.</summary>
   /// <param name="volume">The volume level</param>
   /// <returns></returns>
   virtual public  void SetVolume( double volume) {
                         Efl.PlayerNativeInherit.efl_player_volume_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), volume);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>This property controls the audio mute state.</summary>
   /// <returns>The mute state. <c>true</c> or <c>false</c>.</returns>
   virtual public bool GetMute() {
       var _ret_var = Efl.PlayerNativeInherit.efl_player_mute_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>This property controls the audio mute state.</summary>
   /// <param name="mute">The mute state. <c>true</c> or <c>false</c>.</param>
   /// <returns></returns>
   virtual public  void SetMute( bool mute) {
                         Efl.PlayerNativeInherit.efl_player_mute_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), mute);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Get the length of play for the media file.</summary>
   /// <returns>The length of the stream in seconds.</returns>
   virtual public double GetLength() {
       var _ret_var = Efl.PlayerNativeInherit.efl_player_length_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Get whether the media file is seekable.</summary>
   /// <returns><c>true</c> if seekable.</returns>
   virtual public bool GetSeekable() {
       var _ret_var = Efl.PlayerNativeInherit.efl_player_seekable_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Start a playing playable object.</summary>
   /// <returns></returns>
   virtual public  void Start() {
       Efl.PlayerNativeInherit.efl_player_start_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }
   /// <summary>Stop playable object.</summary>
   /// <returns></returns>
   virtual public  void Stop() {
       Efl.PlayerNativeInherit.efl_player_stop_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }
   /// <summary>Get the color of color class.
   /// This function gets the color values for a color class. If no explicit object color is set, then global values will be used.
   /// 
   /// The first color is the object, the second is the text outline, and the third is the text shadow. (Note that the second two only apply to text parts).
   /// 
   /// Note: These color values are expected to be premultiplied by <c>a</c>.</summary>
   /// <param name="color_class">The name of color class</param>
   /// <param name="layer">The layer to set the color</param>
   /// <param name="r">The intensity of the red color</param>
   /// <param name="g">The intensity of the green color</param>
   /// <param name="b">The intensity of the blue color</param>
   /// <param name="a">The alpha value</param>
   /// <returns><c>true</c> if getting the color succeeded, <c>false</c> otherwise</returns>
   virtual public bool GetColorClass(  System.String color_class,  Efl.Gfx.ColorClassLayer layer,  out  int r,  out  int g,  out  int b,  out  int a) {
                                                                                                                   var _ret_var = Efl.Gfx.ColorClassNativeInherit.efl_gfx_color_class_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), color_class,  layer,  out r,  out g,  out b,  out a);
      Eina.Error.RaiseIfUnhandledException();
                                                                              return _ret_var;
 }
   /// <summary>Set the color of color class.
   /// This function sets the color values for a color class. This will cause all edje parts in the specified object that have the specified color class to have their colors multiplied by these values.
   /// 
   /// The first color is the object, the second is the text outline, and the third is the text shadow. (Note that the second two only apply to text parts).
   /// 
   /// Setting color emits a signal &quot;color_class,set&quot; with source being the given color.
   /// 
   /// Note: These color values are expected to be premultiplied by <c>a</c>.</summary>
   /// <param name="color_class">The name of color class</param>
   /// <param name="layer">The layer to set the color</param>
   /// <param name="r">The intensity of the red color</param>
   /// <param name="g">The intensity of the green color</param>
   /// <param name="b">The intensity of the blue color</param>
   /// <param name="a">The alpha value</param>
   /// <returns><c>true</c> if setting the color succeeded, <c>false</c> otherwise</returns>
   virtual public bool SetColorClass(  System.String color_class,  Efl.Gfx.ColorClassLayer layer,   int r,   int g,   int b,   int a) {
                                                                                                                   var _ret_var = Efl.Gfx.ColorClassNativeInherit.efl_gfx_color_class_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), color_class,  layer,  r,  g,  b,  a);
      Eina.Error.RaiseIfUnhandledException();
                                                                              return _ret_var;
 }
   /// <summary>Get the hex color string of color class.
   /// This function gets the color values for a color class. If no explicit object color is set, then global values will be used.
   /// 
   /// The first color is the object, the second is the text outline, and the third is the text shadow. (Note that the second two only apply to text parts).
   /// 
   /// Returns NULL if the color class cannot be fetched.
   /// 
   /// Note: These color values are expected to be premultiplied by <c>a</c>.</summary>
   /// <param name="color_class">The name of color class</param>
   /// <param name="layer">The layer to set the color</param>
   /// <returns>the hex color code.</returns>
   virtual public  System.String GetColorClassCode(  System.String color_class,  Efl.Gfx.ColorClassLayer layer) {
                                           var _ret_var = Efl.Gfx.ColorClassNativeInherit.efl_gfx_color_class_code_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), color_class,  layer);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }
   /// <summary>Set the hex color string of color class.
   /// This function sets the color values for a color class. This will cause all edje parts in the specified object that have the specified color class to have their colors multiplied by these values.
   /// 
   /// The first color is the object, the second is the text outline, and the third is the text shadow. (Note that the second two only apply to text parts).
   /// 
   /// Setting color emits a signal &quot;color_class,set&quot; with source being the given color.
   /// 
   /// Note: These color values are expected to be premultiplied by the alpha.</summary>
   /// <param name="color_class">The name of color class</param>
   /// <param name="layer">The layer to set the color</param>
   /// <param name="colorcode">the hex color code.</param>
   /// <returns><c>true</c> if setting the color succeeded, <c>false</c> otherwise</returns>
   virtual public bool SetColorClassCode(  System.String color_class,  Efl.Gfx.ColorClassLayer layer,   System.String colorcode) {
                                                             var _ret_var = Efl.Gfx.ColorClassNativeInherit.efl_gfx_color_class_code_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), color_class,  layer,  colorcode);
      Eina.Error.RaiseIfUnhandledException();
                                          return _ret_var;
 }
   /// <summary>Get the description of a color class.
   /// This function gets the description of a color class in use by an object.</summary>
   /// <param name="color_class">The name of color class</param>
   /// <returns>The description of the target color class or <c>null</c> if not found</returns>
   virtual public  System.String GetColorClassDescription(  System.String color_class) {
                         var _ret_var = Efl.Gfx.ColorClassNativeInherit.efl_gfx_color_class_description_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), color_class);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Delete the color class.
   /// This function deletes any values for the specified color class.
   /// 
   /// Deleting the color class will revert it to the values defined by <see cref="Efl.Gfx.ColorClass.GetColorClass"/> or the color class defined in the theme file.
   /// 
   /// Deleting the color class will emit the signal &quot;color_class,del&quot; for the given Edje object.</summary>
   /// <param name="color_class">The name of color_class</param>
   /// <returns></returns>
   virtual public  void DelColorClass(  System.String color_class) {
                         Efl.Gfx.ColorClassNativeInherit.efl_gfx_color_class_del_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), color_class);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Delete all color classes defined in object level.
   /// This function deletes any color classes defined in object level. Clearing color classes will revert the color of all edje parts to the values defined in global level or theme file.
   /// 1.17.0</summary>
   /// <returns></returns>
   virtual public  void ClearColorClass() {
       Efl.Gfx.ColorClassNativeInherit.efl_gfx_color_class_clear_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }
   /// <summary>Get width and height of size class.
   /// This function gets width and height for a size class. These values will only be valid until the size class is changed or the edje object is deleted.
   /// 1.17</summary>
   /// <param name="size_class">The name of size class</param>
   /// <param name="minw">minimum width</param>
   /// <param name="minh">minimum height</param>
   /// <param name="maxw">maximum width</param>
   /// <param name="maxh">maximum height</param>
   /// <returns><c>true</c>, on success or <c>false</c>, on error</returns>
   virtual public bool GetSizeClass(  System.String size_class,  out  int minw,  out  int minh,  out  int maxw,  out  int maxh) {
                                                                                                 var _ret_var = Efl.Gfx.SizeClassNativeInherit.efl_gfx_size_class_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), size_class,  out minw,  out minh,  out maxw,  out maxh);
      Eina.Error.RaiseIfUnhandledException();
                                                                  return _ret_var;
 }
   /// <summary>Set width and height of size class.
   /// This function sets width and height for a size class. This will make all edje parts in the specified object that have the specified size class update their size with given values.
   /// 1.17</summary>
   /// <param name="size_class">The name of size class</param>
   /// <param name="minw">minimum width</param>
   /// <param name="minh">minimum height</param>
   /// <param name="maxw">maximum width</param>
   /// <param name="maxh">maximum height</param>
   /// <returns><c>true</c>, on success or <c>false</c>, on error</returns>
   virtual public bool SetSizeClass(  System.String size_class,   int minw,   int minh,   int maxw,   int maxh) {
                                                                                                 var _ret_var = Efl.Gfx.SizeClassNativeInherit.efl_gfx_size_class_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), size_class,  minw,  minh,  maxw,  maxh);
      Eina.Error.RaiseIfUnhandledException();
                                                                  return _ret_var;
 }
   /// <summary>Delete the size class.
   /// This function deletes any values for the specified size class.
   /// 
   /// Deleting the size class will revert it to the values defined by <see cref="Efl.Gfx.SizeClass.GetSizeClass"/> or the size class defined in the theme file.
   /// 1.17</summary>
   /// <param name="size_class">The size class to be deleted.</param>
   /// <returns></returns>
   virtual public  void DelSizeClass(  System.String size_class) {
                         Efl.Gfx.SizeClassNativeInherit.efl_gfx_size_class_del_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), size_class);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Get font and font size from edje text class.
   /// This function gets the font and the font size from text class. The font string will only be valid until the text class is changed or the edje object is deleted.</summary>
   /// <param name="text_class">The text class name</param>
   /// <param name="font">Font name</param>
   /// <param name="size">Font Size</param>
   /// <returns><c>true</c>, on success or <c>false</c>, on error</returns>
   virtual public bool GetTextClass(  System.String text_class,  out  System.String font,  out Efl.Font.Size size) {
                                                             var _ret_var = Efl.Gfx.TextClassNativeInherit.efl_gfx_text_class_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), text_class,  out font,  out size);
      Eina.Error.RaiseIfUnhandledException();
                                          return _ret_var;
 }
   /// <summary>Set Edje text class.
   /// This function sets the text class for the Edje.</summary>
   /// <param name="text_class">The text class name</param>
   /// <param name="font">Font name</param>
   /// <param name="size">Font Size</param>
   /// <returns><c>true</c>, on success or <c>false</c>, on error</returns>
   virtual public bool SetTextClass(  System.String text_class,   System.String font,  Efl.Font.Size size) {
                                                             var _ret_var = Efl.Gfx.TextClassNativeInherit.efl_gfx_text_class_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), text_class,  font,  size);
      Eina.Error.RaiseIfUnhandledException();
                                          return _ret_var;
 }
   /// <summary>Delete the text class.
   /// This function deletes any values for the specified text class.
   /// 
   /// Deleting the text class will revert it to the values defined by <see cref="Efl.Gfx.TextClass.GetTextClass"/> or the text class defined in the theme file.
   /// 1.17</summary>
   /// <param name="text_class">The text class to be deleted.</param>
   /// <returns></returns>
   virtual public  void DelTextClass(  System.String text_class) {
                         Efl.Gfx.TextClassNativeInherit.efl_gfx_text_class_del_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), text_class);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Whether this object updates its size hints automatically.
   /// 1.21</summary>
   /// <returns>Whether or not update the size hints.
   /// 1.21</returns>
   virtual public bool GetCalcAutoUpdateHints() {
       var _ret_var = Efl.Layout.CalcNativeInherit.efl_layout_calc_auto_update_hints_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Enable or disable auto-update of size hints.
   /// 1.21</summary>
   /// <param name="update">Whether or not update the size hints.
   /// 1.21</param>
   /// <returns></returns>
   virtual public  void SetCalcAutoUpdateHints( bool update) {
                         Efl.Layout.CalcNativeInherit.efl_layout_calc_auto_update_hints_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), update);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Calculates the minimum required size for a given layout object.
   /// This call will trigger an internal recalculation of all parts of the object, in order to return its minimum required dimensions for width and height. The user might choose to impose those minimum sizes, making the resulting calculation to get to values greater or equal than <c>restricted</c> in both directions.
   /// 
   /// Note: At the end of this call, the object won&apos;t be automatically resized to the new dimensions, but just return the calculated sizes. The caller is the one up to change its geometry or not.
   /// 
   /// Warning: Be advised that invisible parts in the object will be taken into account in this calculation.
   /// 1.21</summary>
   /// <param name="restricted">The minimum size constraint as input, the returned size can not be lower than this (in both directions).
   /// 1.21</param>
   /// <returns>The minimum required size.
   /// 1.21</returns>
   virtual public Eina.Size2D CalcSizeMin( Eina.Size2D restricted) {
       var _in_restricted = Eina.Size2D_StructConversion.ToInternal(restricted);
                  var _ret_var = Efl.Layout.CalcNativeInherit.efl_layout_calc_size_min_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), _in_restricted);
      Eina.Error.RaiseIfUnhandledException();
                  return Eina.Size2D_StructConversion.ToManaged(_ret_var);
 }
   /// <summary>Calculates the geometry of the region, relative to a given layout object&apos;s area, occupied by all parts in the object.
   /// This function gets the geometry of the rectangle equal to the area required to group all parts in obj&apos;s group/collection. The x and y coordinates are relative to the top left corner of the whole obj object&apos;s area. Parts placed out of the group&apos;s boundaries will also be taken in account, so that x and y may be negative.
   /// 
   /// Note: On failure, this function will make all non-<c>null</c> geometry pointers&apos; pointed variables be set to zero.
   /// 1.21</summary>
   /// <returns>The calculated region.
   /// 1.21</returns>
   virtual public Eina.Rect CalcPartsExtends() {
       var _ret_var = Efl.Layout.CalcNativeInherit.efl_layout_calc_parts_extends_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return Eina.Rect_StructConversion.ToManaged(_ret_var);
 }
   /// <summary>Freezes the layout object.
   /// This function puts all changes on hold. Successive freezes will nest, requiring an equal number of thaws.
   /// 
   /// See also <see cref="Efl.Layout.Calc.ThawCalc"/>.
   /// 1.21</summary>
   /// <returns>The frozen state or 0 on error
   /// 1.21</returns>
   virtual public  int FreezeCalc() {
       var _ret_var = Efl.Layout.CalcNativeInherit.efl_layout_calc_freeze_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Thaws the layout object.
   /// This function thaws (in other words &quot;unfreezes&quot;) the given layout object.
   /// 
   /// Note: If sucessive freezes were done, an equal number of thaws will be required.
   /// 
   /// See also <see cref="Efl.Layout.Calc.FreezeCalc"/>.
   /// 1.21</summary>
   /// <returns>The frozen state or 0 if the object is not frozen or on error.
   /// 1.21</returns>
   virtual public  int ThawCalc() {
       var _ret_var = Efl.Layout.CalcNativeInherit.efl_layout_calc_thaw_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Forces a Size/Geometry calculation.
   /// Forces the object to recalculate its layout regardless of freeze/thaw. This API should be used carefully.
   /// 
   /// See also <see cref="Efl.Layout.Calc.FreezeCalc"/> and <see cref="Efl.Layout.Calc.ThawCalc"/>.
   /// 1.21</summary>
   /// <returns></returns>
   virtual public  void CalcForce() {
       Efl.Layout.CalcNativeInherit.efl_layout_calc_force_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }
   /// <summary>Gets the minimum size specified -- as an EDC property -- for a given Edje object
   /// This function retrieves the obj object&apos;s minimum size values, as declared in its EDC group definition. For instance, for an Edje object of minimum size 100x100 pixels: collections { group { name: &quot;a_group&quot;; min: 100 100; } }
   /// 
   /// Note: If the <c>min</c> EDC property was not declared for this object, this call will return 0x0.
   /// 
   /// Note: On failure, this function also return 0x0.
   /// 
   /// See also <see cref="Efl.Layout.Group.GetGroupSizeMax"/>.
   /// 1.21</summary>
   /// <returns>The minimum size as set in EDC.
   /// 1.21</returns>
   virtual public Eina.Size2D GetGroupSizeMin() {
       var _ret_var = Efl.Layout.GroupNativeInherit.efl_layout_group_size_min_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return Eina.Size2D_StructConversion.ToManaged(_ret_var);
 }
   /// <summary>Gets the maximum size specified -- as an EDC property -- for a given Edje object
   /// This function retrieves the object&apos;s maximum size values, as declared in its EDC group definition. For instance, for an Edje object of maximum size 100x100 pixels: collections { group { name: &quot;a_group&quot;; max: 100 100; } }
   /// 
   /// Note: If the <c>max</c> EDC property was not declared for the object, this call will return the maximum size a given Edje object may have, for each axis.
   /// 
   /// Note: On failure, this function will return 0x0.
   /// 
   /// See also <see cref="Efl.Layout.Group.GetGroupSizeMin"/>.
   /// 1.21</summary>
   /// <returns>The maximum size as set in EDC.
   /// 1.21</returns>
   virtual public Eina.Size2D GetGroupSizeMax() {
       var _ret_var = Efl.Layout.GroupNativeInherit.efl_layout_group_size_max_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return Eina.Size2D_StructConversion.ToManaged(_ret_var);
 }
   /// <summary>Retrives an EDC data field&apos;s value from a given Edje object&apos;s group.
   /// This function fetches an EDC data field&apos;s value, which is declared on the objects building EDC file, under its group. EDC data blocks are most commonly used to pass arbitrary parameters from an application&apos;s theme to its code.
   /// 
   /// EDC data fields always hold  strings as values, hence the return type of this function. Check the complete &quot;syntax reference&quot; for EDC files.
   /// 
   /// This is how a data item is defined in EDC: collections { group { name: &quot;a_group&quot;; data { item: &quot;key1&quot; &quot;value1&quot;; item: &quot;key2&quot; &quot;value2&quot;; } } }
   /// 
   /// Warning: Do not confuse this call with edje_file_data_get(), which queries for a global EDC data field on an EDC declaration file.
   /// 1.21</summary>
   /// <param name="key">The data field&apos;s key string
   /// 1.21</param>
   /// <returns>The data&apos;s value string.
   /// 1.21</returns>
   virtual public  System.String GetGroupData(  System.String key) {
                         var _ret_var = Efl.Layout.GroupNativeInherit.efl_layout_group_data_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), key);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Returns <c>true</c> if the part exists in the EDC group.
   /// 1.21</summary>
   /// <param name="part">The part name to check.
   /// 1.21</param>
   /// <returns><c>true</c> if the part exists, <c>false</c> otherwise.
   /// 1.21</returns>
   virtual public bool GetPartExist(  System.String part) {
                         var _ret_var = Efl.Layout.GroupNativeInherit.efl_layout_group_part_exist_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), part);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Sends an (Edje) message to a given Edje object
   /// This function sends an Edje message to obj and to all of its child objects, if it has any (swallowed objects are one kind of child object). Only a few types are supported: - int, - float/double, - string/stringshare, - arrays of int, float, double or strings.
   /// 
   /// Messages can go both ways, from code to theme, or theme to code.
   /// 
   /// The id argument as a form of code and theme defining a common interface on message communication. One should define the same IDs on both code and EDC declaration, to individualize messages (binding them to a given context).
   /// 1.21</summary>
   /// <param name="id">A identification number for the message to be sent
   /// 1.21</param>
   /// <param name="msg">The message&apos;s payload
   /// 1.21</param>
   /// <returns></returns>
   virtual public  void MessageSend(  int id,   Eina.Value msg) {
                                           Efl.Layout.SignalNativeInherit.efl_layout_signal_message_send_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), id,  msg);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Adds a callback for an arriving Edje signal, emitted by a given Edje object.
   /// Edje signals are one of the communication interfaces between code and a given Edje object&apos;s theme. With signals, one can communicate two string values at a time, which are: - &quot;emission&quot; value: the name of the signal, in general - &quot;source&quot; value: a name for the signal&apos;s context, in general
   /// 
   /// Signals can go both ways, from code to theme, or theme to code.
   /// 
   /// Though there are those common uses for the two strings, one is free to use them however they like.
   /// 
   /// Signal callback registration is powerful, in the way that blobs may be used to match multiple signals at once. All the &quot;*?[&quot; set of <c>fnmatch</c>() operators can be used, both for emission and source.
   /// 
   /// Edje has internal signals it will emit, automatically, on various actions taking place on group parts. For example, the mouse cursor being moved, pressed, released, etc., over a given part&apos;s area, all generate individual signals.
   /// 
   /// With something like emission = &quot;mouse,down,*&quot;, source = &quot;button.*&quot; where &quot;button.*&quot; is the pattern for the names of parts implementing buttons on an interface, you&apos;d be registering for notifications on events of mouse buttons being pressed down on either of those parts (those events all have the &quot;mouse,down,&quot; common prefix on their names, with a suffix giving the button number). The actual emission and source strings of an event will be passed in as the emission and source parameters of the callback function (e.g. &quot;mouse,down,2&quot; and &quot;button.close&quot;), for each of those events.
   /// 
   /// See also the Edje Data Collection Reference for EDC files.
   /// 
   /// See <see cref="Efl.Layout.Signal.EmitSignal"/> on how to emit signals from code to a an object See <see cref="Efl.Layout.Signal.DelSignalCallback"/>.
   /// 1.21</summary>
   /// <param name="emission">The signal&apos;s &quot;emission&quot; string
   /// 1.21</param>
   /// <param name="source">The signal&apos;s &quot;source&quot; string
   /// 1.21</param>
   /// <param name="func">The callback function to be executed when the signal is emitted.
   /// 1.21</param>
   /// <returns><c>true</c> in case of success, <c>false</c> in case of error.
   /// 1.21</returns>
   virtual public bool AddSignalCallback(  System.String emission,   System.String source,  EflLayoutSignalCb func) {
                                                       GCHandle func_handle = GCHandle.Alloc(func);
      var _ret_var = Efl.Layout.SignalNativeInherit.efl_layout_signal_callback_add_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), emission,  source, GCHandle.ToIntPtr(func_handle), EflLayoutSignalCbWrapper.Cb, Efl.Eo.Globals.free_gchandle);
      Eina.Error.RaiseIfUnhandledException();
                                          return _ret_var;
 }
   /// <summary>Removes a signal-triggered callback from an object.
   /// This function removes a callback, previously attached to the emission of a signal, from the object  obj. The parameters emission, source and func must match exactly those passed to a previous call to <see cref="Efl.Layout.Signal.AddSignalCallback"/>.
   /// 
   /// See <see cref="Efl.Layout.Signal.AddSignalCallback"/>.
   /// 1.21</summary>
   /// <param name="emission">The signal&apos;s &quot;emission&quot; string
   /// 1.21</param>
   /// <param name="source">The signal&apos;s &quot;source&quot; string
   /// 1.21</param>
   /// <param name="func">The callback function to be executed when the signal is emitted.
   /// 1.21</param>
   /// <returns><c>true</c> in case of success, <c>false</c> in case of error.
   /// 1.21</returns>
   virtual public bool DelSignalCallback(  System.String emission,   System.String source,  EflLayoutSignalCb func) {
                                                       GCHandle func_handle = GCHandle.Alloc(func);
      var _ret_var = Efl.Layout.SignalNativeInherit.efl_layout_signal_callback_del_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), emission,  source, GCHandle.ToIntPtr(func_handle), EflLayoutSignalCbWrapper.Cb, Efl.Eo.Globals.free_gchandle);
      Eina.Error.RaiseIfUnhandledException();
                                          return _ret_var;
 }
   /// <summary>Sends/emits an Edje signal to this layout.
   /// This function sends a signal to the object. An Edje program, at the EDC specification level, can respond to a signal by having declared matching &quot;signal&quot; and &quot;source&quot; fields on its block.
   /// 
   /// See also the Edje Data Collection Reference for EDC files.
   /// 
   /// See <see cref="Efl.Layout.Signal.AddSignalCallback"/> for more on Edje signals.
   /// 1.21</summary>
   /// <param name="emission">The signal&apos;s &quot;emission&quot; string
   /// 1.21</param>
   /// <param name="source">The signal&apos;s &quot;source&quot; string
   /// 1.21</param>
   /// <returns></returns>
   virtual public  void EmitSignal(  System.String emission,   System.String source) {
                                           Efl.Layout.SignalNativeInherit.efl_layout_signal_emit_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), emission,  source);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Processes an object&apos;s messages and signals queue.
   /// This function goes through the object message queue processing the pending messages for this specific Edje object. Normally they&apos;d be processed only at idle time.
   /// 
   /// If <c>recurse</c> is <c>true</c>, this function will be called recursively on all subobjects.
   /// 1.21</summary>
   /// <param name="recurse">Whether to process messages on children objects.
   /// 1.21</param>
   /// <returns></returns>
   virtual public  void SignalProcess( bool recurse) {
                         Efl.Layout.SignalNativeInherit.efl_layout_signal_process_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), recurse);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Whether this object is animating or not.
/// This property indicates whether animations are stopped or not. Animations here refer to transitions between states.
/// 
/// If animations are disabled, transitions between states (as defined in EDC) are then instantaneous. This is conceptually similar to setting the <see cref="Efl.Player.PlaySpeed"/> to an infinitely high value.</summary>
/// <value>The animation state, <c>true</c> by default.</value>
   public bool Animation {
      get { return GetAnimation(); }
      set { SetAnimation( value); }
   }
   /// <summary>Gets the (last) file loading error for a given object.</summary>
/// <value>The load error code.</value>
   public Efl.Gfx.ImageLoadError LayoutLoadError {
      get { return GetLayoutLoadError(); }
   }
   /// <summary>Get the mmaped file from where an object will fetch the real data (it must be an Eina_File).</summary>
/// <value>The handle to an Eina_File that will be used</value>
   public Eina.File Mmap {
      get { return GetMmap(); }
      set { SetMmap( value); }
   }
   /// <summary>Retrieve the file path from where an object is to fetch the data.
/// You must not modify the strings on the returned pointers.</summary>
/// <value>The file path.</value>
   public  System.String File {
      get { return GetFile(); }
      set { SetFile( value); }
   }
   /// <summary>Get the previously-set key which corresponds to the target data within a file.
/// Some filetypes can contain multiple data streams which are indexed by a key. Use this property for such cases.
/// 
/// You must not modify the strings on the returned pointers.</summary>
/// <value>The group that the image belongs to, in case  it&apos;s an EET(including Edje case) file. This can be used as a key inside evas image cache if this is a normal image file not eet file.</value>
   public  System.String Key {
      get { return GetKey(); }
      set { SetKey( value); }
   }
   /// <summary>Get the load state of the object.</summary>
/// <value>True if the object is loaded, otherwise false.</value>
   public bool Loaded {
      get { return GetLoaded(); }
   }
   /// <summary>Whether or not the playable can be played.</summary>
/// <value><c>true</c> if the object have playable data, <c>false</c> otherwise</value>
   public bool Playable {
      get { return GetPlayable(); }
   }
   /// <summary>Get play/pause state of the media file.</summary>
/// <value><c>true</c> if playing, <c>false</c> otherwise.</value>
   public bool Play {
      get { return GetPlay(); }
      set { SetPlay( value); }
   }
   /// <summary>Get the position in the media file.
/// The position is returned as the number of seconds since the beginning of the media file.</summary>
/// <value>The position (in seconds).</value>
   public double Pos {
      get { return GetPos(); }
      set { SetPos( value); }
   }
   /// <summary>Get how much of the file has been played.
/// This function gets the progress in playing the file, the return value is in the [0, 1] range.</summary>
/// <value>The progress within the [0, 1] range.</value>
   public double Progress {
      get { return GetProgress(); }
   }
   /// <summary>Control the play speed of the media file.
/// This function control the speed with which the media file will be played. 1.0 represents the normal speed, 2 double speed, 0.5 half speed and so on.</summary>
/// <value>The play speed in the [0, infinity) range.</value>
   public double PlaySpeed {
      get { return GetPlaySpeed(); }
      set { SetPlaySpeed( value); }
   }
   /// <summary>Control the audio volume.
/// Controls the audio volume of the stream being played. This has nothing to do with the system volume. This volume will be multiplied by the system volume. e.g.: if the current volume level is 0.5, and the system volume is 50%, it will be 0.5 * 0.5 = 0.25.</summary>
/// <value>The volume level</value>
   public double Volume {
      get { return GetVolume(); }
      set { SetVolume( value); }
   }
   /// <summary>This property controls the audio mute state.</summary>
/// <value>The mute state. <c>true</c> or <c>false</c>.</value>
   public bool Mute {
      get { return GetMute(); }
      set { SetMute( value); }
   }
   /// <summary>Get the length of play for the media file.</summary>
/// <value>The length of the stream in seconds.</value>
   public double Length {
      get { return GetLength(); }
   }
   /// <summary>Get whether the media file is seekable.</summary>
/// <value><c>true</c> if seekable.</value>
   public bool Seekable {
      get { return GetSeekable(); }
   }
   /// <summary>Whether this object updates its size hints automatically.
/// By default edje doesn&apos;t set size hints on itself. If this property is set to <c>true</c>, size hints will be updated after recalculation. Be careful, as recalculation may happen often, enabling this property may have a considerable performance impact as other widgets will be notified of the size hints changes.
/// 
/// A layout recalculation can be triggered by <see cref="Efl.Layout.Calc.CalcSizeMin"/>, <see cref="Efl.Layout.Calc.CalcSizeMin"/>, <see cref="Efl.Layout.Calc.CalcPartsExtends"/> or even any other internal event.
/// 1.21</summary>
/// <value>Whether or not update the size hints.
/// 1.21</value>
   public bool CalcAutoUpdateHints {
      get { return GetCalcAutoUpdateHints(); }
      set { SetCalcAutoUpdateHints( value); }
   }
   /// <summary>Gets the minimum size specified -- as an EDC property -- for a given Edje object
/// This function retrieves the obj object&apos;s minimum size values, as declared in its EDC group definition. For instance, for an Edje object of minimum size 100x100 pixels: collections { group { name: &quot;a_group&quot;; min: 100 100; } }
/// 
/// Note: If the <c>min</c> EDC property was not declared for this object, this call will return 0x0.
/// 
/// Note: On failure, this function also return 0x0.
/// 
/// See also <see cref="Efl.Layout.Group.GetGroupSizeMax"/>.
/// 1.21</summary>
/// <value>The minimum size as set in EDC.
/// 1.21</value>
   public Eina.Size2D GroupSizeMin {
      get { return GetGroupSizeMin(); }
   }
   /// <summary>Gets the maximum size specified -- as an EDC property -- for a given Edje object
/// This function retrieves the object&apos;s maximum size values, as declared in its EDC group definition. For instance, for an Edje object of maximum size 100x100 pixels: collections { group { name: &quot;a_group&quot;; max: 100 100; } }
/// 
/// Note: If the <c>max</c> EDC property was not declared for the object, this call will return the maximum size a given Edje object may have, for each axis.
/// 
/// Note: On failure, this function will return 0x0.
/// 
/// See also <see cref="Efl.Layout.Group.GetGroupSizeMin"/>.
/// 1.21</summary>
/// <value>The maximum size as set in EDC.
/// 1.21</value>
   public Eina.Size2D GroupSizeMax {
      get { return GetGroupSizeMax(); }
   }
   private static new  IntPtr GetEflClassStatic()
   {
      return Efl.Canvas.Layout.efl_canvas_layout_class_get();
   }
}
public class LayoutNativeInherit : Efl.Canvas.GroupNativeInherit{
   public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Edje);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      if (efl_canvas_layout_animation_get_static_delegate == null)
      efl_canvas_layout_animation_get_static_delegate = new efl_canvas_layout_animation_get_delegate(animation_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_layout_animation_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_layout_animation_get_static_delegate)});
      if (efl_canvas_layout_animation_set_static_delegate == null)
      efl_canvas_layout_animation_set_static_delegate = new efl_canvas_layout_animation_set_delegate(animation_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_layout_animation_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_layout_animation_set_static_delegate)});
      if (efl_canvas_layout_seat_get_static_delegate == null)
      efl_canvas_layout_seat_get_static_delegate = new efl_canvas_layout_seat_get_delegate(seat_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_layout_seat_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_layout_seat_get_static_delegate)});
      if (efl_canvas_layout_seat_name_get_static_delegate == null)
      efl_canvas_layout_seat_name_get_static_delegate = new efl_canvas_layout_seat_name_get_delegate(seat_name_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_layout_seat_name_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_layout_seat_name_get_static_delegate)});
      if (efl_canvas_layout_load_error_get_static_delegate == null)
      efl_canvas_layout_load_error_get_static_delegate = new efl_canvas_layout_load_error_get_delegate(layout_load_error_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_layout_load_error_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_layout_load_error_get_static_delegate)});
      if (efl_canvas_layout_part_text_min_policy_get_static_delegate == null)
      efl_canvas_layout_part_text_min_policy_get_static_delegate = new efl_canvas_layout_part_text_min_policy_get_delegate(part_text_min_policy_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_layout_part_text_min_policy_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_layout_part_text_min_policy_get_static_delegate)});
      if (efl_canvas_layout_part_text_min_policy_set_static_delegate == null)
      efl_canvas_layout_part_text_min_policy_set_static_delegate = new efl_canvas_layout_part_text_min_policy_set_delegate(part_text_min_policy_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_layout_part_text_min_policy_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_layout_part_text_min_policy_set_static_delegate)});
      if (efl_canvas_layout_part_text_valign_get_static_delegate == null)
      efl_canvas_layout_part_text_valign_get_static_delegate = new efl_canvas_layout_part_text_valign_get_delegate(part_text_valign_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_layout_part_text_valign_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_layout_part_text_valign_get_static_delegate)});
      if (efl_canvas_layout_part_text_valign_set_static_delegate == null)
      efl_canvas_layout_part_text_valign_set_static_delegate = new efl_canvas_layout_part_text_valign_set_delegate(part_text_valign_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_layout_part_text_valign_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_layout_part_text_valign_set_static_delegate)});
      if (efl_canvas_layout_part_text_marquee_duration_get_static_delegate == null)
      efl_canvas_layout_part_text_marquee_duration_get_static_delegate = new efl_canvas_layout_part_text_marquee_duration_get_delegate(part_text_marquee_duration_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_layout_part_text_marquee_duration_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_layout_part_text_marquee_duration_get_static_delegate)});
      if (efl_canvas_layout_part_text_marquee_duration_set_static_delegate == null)
      efl_canvas_layout_part_text_marquee_duration_set_static_delegate = new efl_canvas_layout_part_text_marquee_duration_set_delegate(part_text_marquee_duration_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_layout_part_text_marquee_duration_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_layout_part_text_marquee_duration_set_static_delegate)});
      if (efl_canvas_layout_part_text_marquee_speed_get_static_delegate == null)
      efl_canvas_layout_part_text_marquee_speed_get_static_delegate = new efl_canvas_layout_part_text_marquee_speed_get_delegate(part_text_marquee_speed_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_layout_part_text_marquee_speed_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_layout_part_text_marquee_speed_get_static_delegate)});
      if (efl_canvas_layout_part_text_marquee_speed_set_static_delegate == null)
      efl_canvas_layout_part_text_marquee_speed_set_static_delegate = new efl_canvas_layout_part_text_marquee_speed_set_delegate(part_text_marquee_speed_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_layout_part_text_marquee_speed_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_layout_part_text_marquee_speed_set_static_delegate)});
      if (efl_canvas_layout_part_text_marquee_always_get_static_delegate == null)
      efl_canvas_layout_part_text_marquee_always_get_static_delegate = new efl_canvas_layout_part_text_marquee_always_get_delegate(part_text_marquee_always_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_layout_part_text_marquee_always_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_layout_part_text_marquee_always_get_static_delegate)});
      if (efl_canvas_layout_part_text_marquee_always_set_static_delegate == null)
      efl_canvas_layout_part_text_marquee_always_set_static_delegate = new efl_canvas_layout_part_text_marquee_always_set_delegate(part_text_marquee_always_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_layout_part_text_marquee_always_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_layout_part_text_marquee_always_set_static_delegate)});
      if (efl_canvas_layout_part_valign_get_static_delegate == null)
      efl_canvas_layout_part_valign_get_static_delegate = new efl_canvas_layout_part_valign_get_delegate(part_valign_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_layout_part_valign_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_layout_part_valign_get_static_delegate)});
      if (efl_canvas_layout_part_valign_set_static_delegate == null)
      efl_canvas_layout_part_valign_set_static_delegate = new efl_canvas_layout_part_valign_set_delegate(part_valign_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_layout_part_valign_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_layout_part_valign_set_static_delegate)});
      if (efl_canvas_layout_access_part_iterate_static_delegate == null)
      efl_canvas_layout_access_part_iterate_static_delegate = new efl_canvas_layout_access_part_iterate_delegate(access_part_iterate);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_layout_access_part_iterate"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_layout_access_part_iterate_static_delegate)});
      if (efl_canvas_layout_content_remove_static_delegate == null)
      efl_canvas_layout_content_remove_static_delegate = new efl_canvas_layout_content_remove_delegate(content_remove);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_layout_content_remove"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_layout_content_remove_static_delegate)});
      if (efl_canvas_layout_color_class_parent_set_static_delegate == null)
      efl_canvas_layout_color_class_parent_set_static_delegate = new efl_canvas_layout_color_class_parent_set_delegate(color_class_parent_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_layout_color_class_parent_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_layout_color_class_parent_set_static_delegate)});
      if (efl_canvas_layout_color_class_parent_unset_static_delegate == null)
      efl_canvas_layout_color_class_parent_unset_static_delegate = new efl_canvas_layout_color_class_parent_unset_delegate(color_class_parent_unset);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_layout_color_class_parent_unset"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_layout_color_class_parent_unset_static_delegate)});
      if (efl_canvas_layout_part_text_cursor_coord_get_static_delegate == null)
      efl_canvas_layout_part_text_cursor_coord_get_static_delegate = new efl_canvas_layout_part_text_cursor_coord_get_delegate(part_text_cursor_coord_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_layout_part_text_cursor_coord_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_layout_part_text_cursor_coord_get_static_delegate)});
      if (efl_canvas_layout_part_text_cursor_size_get_static_delegate == null)
      efl_canvas_layout_part_text_cursor_size_get_static_delegate = new efl_canvas_layout_part_text_cursor_size_get_delegate(part_text_cursor_size_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_layout_part_text_cursor_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_layout_part_text_cursor_size_get_static_delegate)});
      if (efl_canvas_layout_part_text_cursor_on_mouse_geometry_get_static_delegate == null)
      efl_canvas_layout_part_text_cursor_on_mouse_geometry_get_static_delegate = new efl_canvas_layout_part_text_cursor_on_mouse_geometry_get_delegate(part_text_cursor_on_mouse_geometry_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_layout_part_text_cursor_on_mouse_geometry_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_layout_part_text_cursor_on_mouse_geometry_get_static_delegate)});
      if (efl_content_iterate_static_delegate == null)
      efl_content_iterate_static_delegate = new efl_content_iterate_delegate(content_iterate);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_content_iterate"), func = Marshal.GetFunctionPointerForDelegate(efl_content_iterate_static_delegate)});
      if (efl_content_count_static_delegate == null)
      efl_content_count_static_delegate = new efl_content_count_delegate(content_count);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_content_count"), func = Marshal.GetFunctionPointerForDelegate(efl_content_count_static_delegate)});
      if (efl_file_mmap_get_static_delegate == null)
      efl_file_mmap_get_static_delegate = new efl_file_mmap_get_delegate(mmap_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_file_mmap_get"), func = Marshal.GetFunctionPointerForDelegate(efl_file_mmap_get_static_delegate)});
      if (efl_file_mmap_set_static_delegate == null)
      efl_file_mmap_set_static_delegate = new efl_file_mmap_set_delegate(mmap_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_file_mmap_set"), func = Marshal.GetFunctionPointerForDelegate(efl_file_mmap_set_static_delegate)});
      if (efl_file_get_static_delegate == null)
      efl_file_get_static_delegate = new efl_file_get_delegate(file_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_file_get"), func = Marshal.GetFunctionPointerForDelegate(efl_file_get_static_delegate)});
      if (efl_file_set_static_delegate == null)
      efl_file_set_static_delegate = new efl_file_set_delegate(file_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_file_set"), func = Marshal.GetFunctionPointerForDelegate(efl_file_set_static_delegate)});
      if (efl_file_key_get_static_delegate == null)
      efl_file_key_get_static_delegate = new efl_file_key_get_delegate(key_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_file_key_get"), func = Marshal.GetFunctionPointerForDelegate(efl_file_key_get_static_delegate)});
      if (efl_file_key_set_static_delegate == null)
      efl_file_key_set_static_delegate = new efl_file_key_set_delegate(key_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_file_key_set"), func = Marshal.GetFunctionPointerForDelegate(efl_file_key_set_static_delegate)});
      if (efl_file_loaded_get_static_delegate == null)
      efl_file_loaded_get_static_delegate = new efl_file_loaded_get_delegate(loaded_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_file_loaded_get"), func = Marshal.GetFunctionPointerForDelegate(efl_file_loaded_get_static_delegate)});
      if (efl_file_load_static_delegate == null)
      efl_file_load_static_delegate = new efl_file_load_delegate(load);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_file_load"), func = Marshal.GetFunctionPointerForDelegate(efl_file_load_static_delegate)});
      if (efl_file_unload_static_delegate == null)
      efl_file_unload_static_delegate = new efl_file_unload_delegate(unload);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_file_unload"), func = Marshal.GetFunctionPointerForDelegate(efl_file_unload_static_delegate)});
      if (efl_observer_update_static_delegate == null)
      efl_observer_update_static_delegate = new efl_observer_update_delegate(update);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_observer_update"), func = Marshal.GetFunctionPointerForDelegate(efl_observer_update_static_delegate)});
      if (efl_part_get_static_delegate == null)
      efl_part_get_static_delegate = new efl_part_get_delegate(part_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_part_get"), func = Marshal.GetFunctionPointerForDelegate(efl_part_get_static_delegate)});
      if (efl_player_playable_get_static_delegate == null)
      efl_player_playable_get_static_delegate = new efl_player_playable_get_delegate(playable_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_player_playable_get"), func = Marshal.GetFunctionPointerForDelegate(efl_player_playable_get_static_delegate)});
      if (efl_player_play_get_static_delegate == null)
      efl_player_play_get_static_delegate = new efl_player_play_get_delegate(play_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_player_play_get"), func = Marshal.GetFunctionPointerForDelegate(efl_player_play_get_static_delegate)});
      if (efl_player_play_set_static_delegate == null)
      efl_player_play_set_static_delegate = new efl_player_play_set_delegate(play_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_player_play_set"), func = Marshal.GetFunctionPointerForDelegate(efl_player_play_set_static_delegate)});
      if (efl_player_pos_get_static_delegate == null)
      efl_player_pos_get_static_delegate = new efl_player_pos_get_delegate(pos_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_player_pos_get"), func = Marshal.GetFunctionPointerForDelegate(efl_player_pos_get_static_delegate)});
      if (efl_player_pos_set_static_delegate == null)
      efl_player_pos_set_static_delegate = new efl_player_pos_set_delegate(pos_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_player_pos_set"), func = Marshal.GetFunctionPointerForDelegate(efl_player_pos_set_static_delegate)});
      if (efl_player_progress_get_static_delegate == null)
      efl_player_progress_get_static_delegate = new efl_player_progress_get_delegate(progress_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_player_progress_get"), func = Marshal.GetFunctionPointerForDelegate(efl_player_progress_get_static_delegate)});
      if (efl_player_play_speed_get_static_delegate == null)
      efl_player_play_speed_get_static_delegate = new efl_player_play_speed_get_delegate(play_speed_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_player_play_speed_get"), func = Marshal.GetFunctionPointerForDelegate(efl_player_play_speed_get_static_delegate)});
      if (efl_player_play_speed_set_static_delegate == null)
      efl_player_play_speed_set_static_delegate = new efl_player_play_speed_set_delegate(play_speed_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_player_play_speed_set"), func = Marshal.GetFunctionPointerForDelegate(efl_player_play_speed_set_static_delegate)});
      if (efl_player_volume_get_static_delegate == null)
      efl_player_volume_get_static_delegate = new efl_player_volume_get_delegate(volume_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_player_volume_get"), func = Marshal.GetFunctionPointerForDelegate(efl_player_volume_get_static_delegate)});
      if (efl_player_volume_set_static_delegate == null)
      efl_player_volume_set_static_delegate = new efl_player_volume_set_delegate(volume_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_player_volume_set"), func = Marshal.GetFunctionPointerForDelegate(efl_player_volume_set_static_delegate)});
      if (efl_player_mute_get_static_delegate == null)
      efl_player_mute_get_static_delegate = new efl_player_mute_get_delegate(mute_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_player_mute_get"), func = Marshal.GetFunctionPointerForDelegate(efl_player_mute_get_static_delegate)});
      if (efl_player_mute_set_static_delegate == null)
      efl_player_mute_set_static_delegate = new efl_player_mute_set_delegate(mute_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_player_mute_set"), func = Marshal.GetFunctionPointerForDelegate(efl_player_mute_set_static_delegate)});
      if (efl_player_length_get_static_delegate == null)
      efl_player_length_get_static_delegate = new efl_player_length_get_delegate(length_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_player_length_get"), func = Marshal.GetFunctionPointerForDelegate(efl_player_length_get_static_delegate)});
      if (efl_player_seekable_get_static_delegate == null)
      efl_player_seekable_get_static_delegate = new efl_player_seekable_get_delegate(seekable_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_player_seekable_get"), func = Marshal.GetFunctionPointerForDelegate(efl_player_seekable_get_static_delegate)});
      if (efl_player_start_static_delegate == null)
      efl_player_start_static_delegate = new efl_player_start_delegate(start);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_player_start"), func = Marshal.GetFunctionPointerForDelegate(efl_player_start_static_delegate)});
      if (efl_player_stop_static_delegate == null)
      efl_player_stop_static_delegate = new efl_player_stop_delegate(stop);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_player_stop"), func = Marshal.GetFunctionPointerForDelegate(efl_player_stop_static_delegate)});
      if (efl_gfx_color_class_get_static_delegate == null)
      efl_gfx_color_class_get_static_delegate = new efl_gfx_color_class_get_delegate(color_class_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_color_class_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_color_class_get_static_delegate)});
      if (efl_gfx_color_class_set_static_delegate == null)
      efl_gfx_color_class_set_static_delegate = new efl_gfx_color_class_set_delegate(color_class_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_color_class_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_color_class_set_static_delegate)});
      if (efl_gfx_color_class_code_get_static_delegate == null)
      efl_gfx_color_class_code_get_static_delegate = new efl_gfx_color_class_code_get_delegate(color_class_code_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_color_class_code_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_color_class_code_get_static_delegate)});
      if (efl_gfx_color_class_code_set_static_delegate == null)
      efl_gfx_color_class_code_set_static_delegate = new efl_gfx_color_class_code_set_delegate(color_class_code_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_color_class_code_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_color_class_code_set_static_delegate)});
      if (efl_gfx_color_class_description_get_static_delegate == null)
      efl_gfx_color_class_description_get_static_delegate = new efl_gfx_color_class_description_get_delegate(color_class_description_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_color_class_description_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_color_class_description_get_static_delegate)});
      if (efl_gfx_color_class_del_static_delegate == null)
      efl_gfx_color_class_del_static_delegate = new efl_gfx_color_class_del_delegate(color_class_del);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_color_class_del"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_color_class_del_static_delegate)});
      if (efl_gfx_color_class_clear_static_delegate == null)
      efl_gfx_color_class_clear_static_delegate = new efl_gfx_color_class_clear_delegate(color_class_clear);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_color_class_clear"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_color_class_clear_static_delegate)});
      if (efl_gfx_size_class_get_static_delegate == null)
      efl_gfx_size_class_get_static_delegate = new efl_gfx_size_class_get_delegate(size_class_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_size_class_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_size_class_get_static_delegate)});
      if (efl_gfx_size_class_set_static_delegate == null)
      efl_gfx_size_class_set_static_delegate = new efl_gfx_size_class_set_delegate(size_class_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_size_class_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_size_class_set_static_delegate)});
      if (efl_gfx_size_class_del_static_delegate == null)
      efl_gfx_size_class_del_static_delegate = new efl_gfx_size_class_del_delegate(size_class_del);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_size_class_del"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_size_class_del_static_delegate)});
      if (efl_gfx_text_class_get_static_delegate == null)
      efl_gfx_text_class_get_static_delegate = new efl_gfx_text_class_get_delegate(text_class_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_text_class_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_text_class_get_static_delegate)});
      if (efl_gfx_text_class_set_static_delegate == null)
      efl_gfx_text_class_set_static_delegate = new efl_gfx_text_class_set_delegate(text_class_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_text_class_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_text_class_set_static_delegate)});
      if (efl_gfx_text_class_del_static_delegate == null)
      efl_gfx_text_class_del_static_delegate = new efl_gfx_text_class_del_delegate(text_class_del);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_text_class_del"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_text_class_del_static_delegate)});
      if (efl_layout_calc_auto_update_hints_get_static_delegate == null)
      efl_layout_calc_auto_update_hints_get_static_delegate = new efl_layout_calc_auto_update_hints_get_delegate(calc_auto_update_hints_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_layout_calc_auto_update_hints_get"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_calc_auto_update_hints_get_static_delegate)});
      if (efl_layout_calc_auto_update_hints_set_static_delegate == null)
      efl_layout_calc_auto_update_hints_set_static_delegate = new efl_layout_calc_auto_update_hints_set_delegate(calc_auto_update_hints_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_layout_calc_auto_update_hints_set"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_calc_auto_update_hints_set_static_delegate)});
      if (efl_layout_calc_size_min_static_delegate == null)
      efl_layout_calc_size_min_static_delegate = new efl_layout_calc_size_min_delegate(calc_size_min);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_layout_calc_size_min"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_calc_size_min_static_delegate)});
      if (efl_layout_calc_parts_extends_static_delegate == null)
      efl_layout_calc_parts_extends_static_delegate = new efl_layout_calc_parts_extends_delegate(calc_parts_extends);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_layout_calc_parts_extends"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_calc_parts_extends_static_delegate)});
      if (efl_layout_calc_freeze_static_delegate == null)
      efl_layout_calc_freeze_static_delegate = new efl_layout_calc_freeze_delegate(calc_freeze);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_layout_calc_freeze"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_calc_freeze_static_delegate)});
      if (efl_layout_calc_thaw_static_delegate == null)
      efl_layout_calc_thaw_static_delegate = new efl_layout_calc_thaw_delegate(calc_thaw);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_layout_calc_thaw"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_calc_thaw_static_delegate)});
      if (efl_layout_calc_force_static_delegate == null)
      efl_layout_calc_force_static_delegate = new efl_layout_calc_force_delegate(calc_force);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_layout_calc_force"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_calc_force_static_delegate)});
      if (efl_layout_group_size_min_get_static_delegate == null)
      efl_layout_group_size_min_get_static_delegate = new efl_layout_group_size_min_get_delegate(group_size_min_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_layout_group_size_min_get"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_group_size_min_get_static_delegate)});
      if (efl_layout_group_size_max_get_static_delegate == null)
      efl_layout_group_size_max_get_static_delegate = new efl_layout_group_size_max_get_delegate(group_size_max_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_layout_group_size_max_get"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_group_size_max_get_static_delegate)});
      if (efl_layout_group_data_get_static_delegate == null)
      efl_layout_group_data_get_static_delegate = new efl_layout_group_data_get_delegate(group_data_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_layout_group_data_get"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_group_data_get_static_delegate)});
      if (efl_layout_group_part_exist_get_static_delegate == null)
      efl_layout_group_part_exist_get_static_delegate = new efl_layout_group_part_exist_get_delegate(part_exist_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_layout_group_part_exist_get"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_group_part_exist_get_static_delegate)});
      if (efl_layout_signal_message_send_static_delegate == null)
      efl_layout_signal_message_send_static_delegate = new efl_layout_signal_message_send_delegate(message_send);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_layout_signal_message_send"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_signal_message_send_static_delegate)});
      if (efl_layout_signal_callback_add_static_delegate == null)
      efl_layout_signal_callback_add_static_delegate = new efl_layout_signal_callback_add_delegate(signal_callback_add);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_layout_signal_callback_add"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_signal_callback_add_static_delegate)});
      if (efl_layout_signal_callback_del_static_delegate == null)
      efl_layout_signal_callback_del_static_delegate = new efl_layout_signal_callback_del_delegate(signal_callback_del);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_layout_signal_callback_del"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_signal_callback_del_static_delegate)});
      if (efl_layout_signal_emit_static_delegate == null)
      efl_layout_signal_emit_static_delegate = new efl_layout_signal_emit_delegate(signal_emit);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_layout_signal_emit"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_signal_emit_static_delegate)});
      if (efl_layout_signal_process_static_delegate == null)
      efl_layout_signal_process_static_delegate = new efl_layout_signal_process_delegate(signal_process);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_layout_signal_process"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_signal_process_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Canvas.Layout.efl_canvas_layout_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Canvas.Layout.efl_canvas_layout_class_get();
   }


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_canvas_layout_animation_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_canvas_layout_animation_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_canvas_layout_animation_get_api_delegate> efl_canvas_layout_animation_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_layout_animation_get_api_delegate>(_Module, "efl_canvas_layout_animation_get");
    private static bool animation_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_canvas_layout_animation_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Layout)wrapper).GetAnimation();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_canvas_layout_animation_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_canvas_layout_animation_get_delegate efl_canvas_layout_animation_get_static_delegate;


    private delegate  void efl_canvas_layout_animation_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool on);


    public delegate  void efl_canvas_layout_animation_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool on);
    public static Efl.Eo.FunctionWrapper<efl_canvas_layout_animation_set_api_delegate> efl_canvas_layout_animation_set_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_layout_animation_set_api_delegate>(_Module, "efl_canvas_layout_animation_set");
    private static  void animation_set(System.IntPtr obj, System.IntPtr pd,  bool on)
   {
      Eina.Log.Debug("function efl_canvas_layout_animation_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Layout)wrapper).SetAnimation( on);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_canvas_layout_animation_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  on);
      }
   }
   private static efl_canvas_layout_animation_set_delegate efl_canvas_layout_animation_set_static_delegate;


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))] private delegate Efl.Input.Device efl_canvas_layout_seat_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringshareKeepOwnershipMarshaler))]   System.String name);


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))] public delegate Efl.Input.Device efl_canvas_layout_seat_get_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringshareKeepOwnershipMarshaler))]   System.String name);
    public static Efl.Eo.FunctionWrapper<efl_canvas_layout_seat_get_api_delegate> efl_canvas_layout_seat_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_layout_seat_get_api_delegate>(_Module, "efl_canvas_layout_seat_get");
    private static Efl.Input.Device seat_get(System.IntPtr obj, System.IntPtr pd,   System.String name)
   {
      Eina.Log.Debug("function efl_canvas_layout_seat_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    Efl.Input.Device _ret_var = default(Efl.Input.Device);
         try {
            _ret_var = ((Layout)wrapper).GetSeat( name);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_canvas_layout_seat_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  name);
      }
   }
   private static efl_canvas_layout_seat_get_delegate efl_canvas_layout_seat_get_static_delegate;


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringshareKeepOwnershipMarshaler))] private delegate  System.String efl_canvas_layout_seat_name_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device device);


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringshareKeepOwnershipMarshaler))] public delegate  System.String efl_canvas_layout_seat_name_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device device);
    public static Efl.Eo.FunctionWrapper<efl_canvas_layout_seat_name_get_api_delegate> efl_canvas_layout_seat_name_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_layout_seat_name_get_api_delegate>(_Module, "efl_canvas_layout_seat_name_get");
    private static  System.String seat_name_get(System.IntPtr obj, System.IntPtr pd,  Efl.Input.Device device)
   {
      Eina.Log.Debug("function efl_canvas_layout_seat_name_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                     System.String _ret_var = default( System.String);
         try {
            _ret_var = ((Layout)wrapper).GetSeatName( device);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_canvas_layout_seat_name_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  device);
      }
   }
   private static efl_canvas_layout_seat_name_get_delegate efl_canvas_layout_seat_name_get_static_delegate;


    private delegate Efl.Gfx.ImageLoadError efl_canvas_layout_load_error_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Efl.Gfx.ImageLoadError efl_canvas_layout_load_error_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_canvas_layout_load_error_get_api_delegate> efl_canvas_layout_load_error_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_layout_load_error_get_api_delegate>(_Module, "efl_canvas_layout_load_error_get");
    private static Efl.Gfx.ImageLoadError layout_load_error_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_canvas_layout_load_error_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Gfx.ImageLoadError _ret_var = default(Efl.Gfx.ImageLoadError);
         try {
            _ret_var = ((Layout)wrapper).GetLayoutLoadError();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_canvas_layout_load_error_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_canvas_layout_load_error_get_delegate efl_canvas_layout_load_error_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_canvas_layout_part_text_min_policy_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String part,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String state_name,  [MarshalAs(UnmanagedType.U1)]  out bool min_x,  [MarshalAs(UnmanagedType.U1)]  out bool min_y);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_canvas_layout_part_text_min_policy_get_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String part,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String state_name,  [MarshalAs(UnmanagedType.U1)]  out bool min_x,  [MarshalAs(UnmanagedType.U1)]  out bool min_y);
    public static Efl.Eo.FunctionWrapper<efl_canvas_layout_part_text_min_policy_get_api_delegate> efl_canvas_layout_part_text_min_policy_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_layout_part_text_min_policy_get_api_delegate>(_Module, "efl_canvas_layout_part_text_min_policy_get");
    private static bool part_text_min_policy_get(System.IntPtr obj, System.IntPtr pd,   System.String part,   System.String state_name,  out bool min_x,  out bool min_y)
   {
      Eina.Log.Debug("function efl_canvas_layout_part_text_min_policy_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                   min_x = default(bool);      min_y = default(bool);                                 bool _ret_var = default(bool);
         try {
            _ret_var = ((Layout)wrapper).GetPartTextMinPolicy( part,  state_name,  out min_x,  out min_y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                      return _ret_var;
      } else {
         return efl_canvas_layout_part_text_min_policy_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  part,  state_name,  out min_x,  out min_y);
      }
   }
   private static efl_canvas_layout_part_text_min_policy_get_delegate efl_canvas_layout_part_text_min_policy_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_canvas_layout_part_text_min_policy_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String part,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String state_name,  [MarshalAs(UnmanagedType.U1)]  bool min_x,  [MarshalAs(UnmanagedType.U1)]  bool min_y);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_canvas_layout_part_text_min_policy_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String part,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String state_name,  [MarshalAs(UnmanagedType.U1)]  bool min_x,  [MarshalAs(UnmanagedType.U1)]  bool min_y);
    public static Efl.Eo.FunctionWrapper<efl_canvas_layout_part_text_min_policy_set_api_delegate> efl_canvas_layout_part_text_min_policy_set_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_layout_part_text_min_policy_set_api_delegate>(_Module, "efl_canvas_layout_part_text_min_policy_set");
    private static bool part_text_min_policy_set(System.IntPtr obj, System.IntPtr pd,   System.String part,   System.String state_name,  bool min_x,  bool min_y)
   {
      Eina.Log.Debug("function efl_canvas_layout_part_text_min_policy_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                          bool _ret_var = default(bool);
         try {
            _ret_var = ((Layout)wrapper).SetPartTextMinPolicy( part,  state_name,  min_x,  min_y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                      return _ret_var;
      } else {
         return efl_canvas_layout_part_text_min_policy_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  part,  state_name,  min_x,  min_y);
      }
   }
   private static efl_canvas_layout_part_text_min_policy_set_delegate efl_canvas_layout_part_text_min_policy_set_static_delegate;


    private delegate double efl_canvas_layout_part_text_valign_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String part);


    public delegate double efl_canvas_layout_part_text_valign_get_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String part);
    public static Efl.Eo.FunctionWrapper<efl_canvas_layout_part_text_valign_get_api_delegate> efl_canvas_layout_part_text_valign_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_layout_part_text_valign_get_api_delegate>(_Module, "efl_canvas_layout_part_text_valign_get");
    private static double part_text_valign_get(System.IntPtr obj, System.IntPtr pd,   System.String part)
   {
      Eina.Log.Debug("function efl_canvas_layout_part_text_valign_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    double _ret_var = default(double);
         try {
            _ret_var = ((Layout)wrapper).GetPartTextValign( part);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_canvas_layout_part_text_valign_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  part);
      }
   }
   private static efl_canvas_layout_part_text_valign_get_delegate efl_canvas_layout_part_text_valign_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_canvas_layout_part_text_valign_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String part,   double valign);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_canvas_layout_part_text_valign_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String part,   double valign);
    public static Efl.Eo.FunctionWrapper<efl_canvas_layout_part_text_valign_set_api_delegate> efl_canvas_layout_part_text_valign_set_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_layout_part_text_valign_set_api_delegate>(_Module, "efl_canvas_layout_part_text_valign_set");
    private static bool part_text_valign_set(System.IntPtr obj, System.IntPtr pd,   System.String part,  double valign)
   {
      Eina.Log.Debug("function efl_canvas_layout_part_text_valign_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      bool _ret_var = default(bool);
         try {
            _ret_var = ((Layout)wrapper).SetPartTextValign( part,  valign);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_canvas_layout_part_text_valign_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  part,  valign);
      }
   }
   private static efl_canvas_layout_part_text_valign_set_delegate efl_canvas_layout_part_text_valign_set_static_delegate;


    private delegate double efl_canvas_layout_part_text_marquee_duration_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String part);


    public delegate double efl_canvas_layout_part_text_marquee_duration_get_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String part);
    public static Efl.Eo.FunctionWrapper<efl_canvas_layout_part_text_marquee_duration_get_api_delegate> efl_canvas_layout_part_text_marquee_duration_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_layout_part_text_marquee_duration_get_api_delegate>(_Module, "efl_canvas_layout_part_text_marquee_duration_get");
    private static double part_text_marquee_duration_get(System.IntPtr obj, System.IntPtr pd,   System.String part)
   {
      Eina.Log.Debug("function efl_canvas_layout_part_text_marquee_duration_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    double _ret_var = default(double);
         try {
            _ret_var = ((Layout)wrapper).GetPartTextMarqueeDuration( part);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_canvas_layout_part_text_marquee_duration_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  part);
      }
   }
   private static efl_canvas_layout_part_text_marquee_duration_get_delegate efl_canvas_layout_part_text_marquee_duration_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_canvas_layout_part_text_marquee_duration_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String part,   double duration);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_canvas_layout_part_text_marquee_duration_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String part,   double duration);
    public static Efl.Eo.FunctionWrapper<efl_canvas_layout_part_text_marquee_duration_set_api_delegate> efl_canvas_layout_part_text_marquee_duration_set_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_layout_part_text_marquee_duration_set_api_delegate>(_Module, "efl_canvas_layout_part_text_marquee_duration_set");
    private static bool part_text_marquee_duration_set(System.IntPtr obj, System.IntPtr pd,   System.String part,  double duration)
   {
      Eina.Log.Debug("function efl_canvas_layout_part_text_marquee_duration_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      bool _ret_var = default(bool);
         try {
            _ret_var = ((Layout)wrapper).SetPartTextMarqueeDuration( part,  duration);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_canvas_layout_part_text_marquee_duration_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  part,  duration);
      }
   }
   private static efl_canvas_layout_part_text_marquee_duration_set_delegate efl_canvas_layout_part_text_marquee_duration_set_static_delegate;


    private delegate double efl_canvas_layout_part_text_marquee_speed_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String part);


    public delegate double efl_canvas_layout_part_text_marquee_speed_get_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String part);
    public static Efl.Eo.FunctionWrapper<efl_canvas_layout_part_text_marquee_speed_get_api_delegate> efl_canvas_layout_part_text_marquee_speed_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_layout_part_text_marquee_speed_get_api_delegate>(_Module, "efl_canvas_layout_part_text_marquee_speed_get");
    private static double part_text_marquee_speed_get(System.IntPtr obj, System.IntPtr pd,   System.String part)
   {
      Eina.Log.Debug("function efl_canvas_layout_part_text_marquee_speed_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    double _ret_var = default(double);
         try {
            _ret_var = ((Layout)wrapper).GetPartTextMarqueeSpeed( part);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_canvas_layout_part_text_marquee_speed_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  part);
      }
   }
   private static efl_canvas_layout_part_text_marquee_speed_get_delegate efl_canvas_layout_part_text_marquee_speed_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_canvas_layout_part_text_marquee_speed_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String part,   double speed);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_canvas_layout_part_text_marquee_speed_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String part,   double speed);
    public static Efl.Eo.FunctionWrapper<efl_canvas_layout_part_text_marquee_speed_set_api_delegate> efl_canvas_layout_part_text_marquee_speed_set_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_layout_part_text_marquee_speed_set_api_delegate>(_Module, "efl_canvas_layout_part_text_marquee_speed_set");
    private static bool part_text_marquee_speed_set(System.IntPtr obj, System.IntPtr pd,   System.String part,  double speed)
   {
      Eina.Log.Debug("function efl_canvas_layout_part_text_marquee_speed_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      bool _ret_var = default(bool);
         try {
            _ret_var = ((Layout)wrapper).SetPartTextMarqueeSpeed( part,  speed);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_canvas_layout_part_text_marquee_speed_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  part,  speed);
      }
   }
   private static efl_canvas_layout_part_text_marquee_speed_set_delegate efl_canvas_layout_part_text_marquee_speed_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_canvas_layout_part_text_marquee_always_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String part);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_canvas_layout_part_text_marquee_always_get_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String part);
    public static Efl.Eo.FunctionWrapper<efl_canvas_layout_part_text_marquee_always_get_api_delegate> efl_canvas_layout_part_text_marquee_always_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_layout_part_text_marquee_always_get_api_delegate>(_Module, "efl_canvas_layout_part_text_marquee_always_get");
    private static bool part_text_marquee_always_get(System.IntPtr obj, System.IntPtr pd,   System.String part)
   {
      Eina.Log.Debug("function efl_canvas_layout_part_text_marquee_always_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((Layout)wrapper).GetPartTextMarqueeAlways( part);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_canvas_layout_part_text_marquee_always_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  part);
      }
   }
   private static efl_canvas_layout_part_text_marquee_always_get_delegate efl_canvas_layout_part_text_marquee_always_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_canvas_layout_part_text_marquee_always_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String part,  [MarshalAs(UnmanagedType.U1)]  bool always);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_canvas_layout_part_text_marquee_always_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String part,  [MarshalAs(UnmanagedType.U1)]  bool always);
    public static Efl.Eo.FunctionWrapper<efl_canvas_layout_part_text_marquee_always_set_api_delegate> efl_canvas_layout_part_text_marquee_always_set_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_layout_part_text_marquee_always_set_api_delegate>(_Module, "efl_canvas_layout_part_text_marquee_always_set");
    private static bool part_text_marquee_always_set(System.IntPtr obj, System.IntPtr pd,   System.String part,  bool always)
   {
      Eina.Log.Debug("function efl_canvas_layout_part_text_marquee_always_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      bool _ret_var = default(bool);
         try {
            _ret_var = ((Layout)wrapper).SetPartTextMarqueeAlways( part,  always);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_canvas_layout_part_text_marquee_always_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  part,  always);
      }
   }
   private static efl_canvas_layout_part_text_marquee_always_set_delegate efl_canvas_layout_part_text_marquee_always_set_static_delegate;


    private delegate double efl_canvas_layout_part_valign_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String part);


    public delegate double efl_canvas_layout_part_valign_get_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String part);
    public static Efl.Eo.FunctionWrapper<efl_canvas_layout_part_valign_get_api_delegate> efl_canvas_layout_part_valign_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_layout_part_valign_get_api_delegate>(_Module, "efl_canvas_layout_part_valign_get");
    private static double part_valign_get(System.IntPtr obj, System.IntPtr pd,   System.String part)
   {
      Eina.Log.Debug("function efl_canvas_layout_part_valign_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    double _ret_var = default(double);
         try {
            _ret_var = ((Layout)wrapper).GetPartValign( part);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_canvas_layout_part_valign_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  part);
      }
   }
   private static efl_canvas_layout_part_valign_get_delegate efl_canvas_layout_part_valign_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_canvas_layout_part_valign_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String part,   double valign);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_canvas_layout_part_valign_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String part,   double valign);
    public static Efl.Eo.FunctionWrapper<efl_canvas_layout_part_valign_set_api_delegate> efl_canvas_layout_part_valign_set_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_layout_part_valign_set_api_delegate>(_Module, "efl_canvas_layout_part_valign_set");
    private static bool part_valign_set(System.IntPtr obj, System.IntPtr pd,   System.String part,  double valign)
   {
      Eina.Log.Debug("function efl_canvas_layout_part_valign_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      bool _ret_var = default(bool);
         try {
            _ret_var = ((Layout)wrapper).SetPartValign( part,  valign);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_canvas_layout_part_valign_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  part,  valign);
      }
   }
   private static efl_canvas_layout_part_valign_set_delegate efl_canvas_layout_part_valign_set_static_delegate;


    private delegate  System.IntPtr efl_canvas_layout_access_part_iterate_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  System.IntPtr efl_canvas_layout_access_part_iterate_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_canvas_layout_access_part_iterate_api_delegate> efl_canvas_layout_access_part_iterate_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_layout_access_part_iterate_api_delegate>(_Module, "efl_canvas_layout_access_part_iterate");
    private static  System.IntPtr access_part_iterate(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_canvas_layout_access_part_iterate was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Iterator< System.String> _ret_var = default(Eina.Iterator< System.String>);
         try {
            _ret_var = ((Layout)wrapper).AccessPartIterate();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      _ret_var.Own = false; return _ret_var.Handle;
      } else {
         return efl_canvas_layout_access_part_iterate_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_canvas_layout_access_part_iterate_delegate efl_canvas_layout_access_part_iterate_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_canvas_layout_content_remove_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity content);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_canvas_layout_content_remove_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity content);
    public static Efl.Eo.FunctionWrapper<efl_canvas_layout_content_remove_api_delegate> efl_canvas_layout_content_remove_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_layout_content_remove_api_delegate>(_Module, "efl_canvas_layout_content_remove");
    private static bool content_remove(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.Entity content)
   {
      Eina.Log.Debug("function efl_canvas_layout_content_remove was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((Layout)wrapper).ContentRemove( content);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_canvas_layout_content_remove_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  content);
      }
   }
   private static efl_canvas_layout_content_remove_delegate efl_canvas_layout_content_remove_static_delegate;


    private delegate  void efl_canvas_layout_color_class_parent_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object parent);


    public delegate  void efl_canvas_layout_color_class_parent_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object parent);
    public static Efl.Eo.FunctionWrapper<efl_canvas_layout_color_class_parent_set_api_delegate> efl_canvas_layout_color_class_parent_set_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_layout_color_class_parent_set_api_delegate>(_Module, "efl_canvas_layout_color_class_parent_set");
    private static  void color_class_parent_set(System.IntPtr obj, System.IntPtr pd,  Efl.Object parent)
   {
      Eina.Log.Debug("function efl_canvas_layout_color_class_parent_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Layout)wrapper).SetColorClassParent( parent);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_canvas_layout_color_class_parent_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  parent);
      }
   }
   private static efl_canvas_layout_color_class_parent_set_delegate efl_canvas_layout_color_class_parent_set_static_delegate;


    private delegate  void efl_canvas_layout_color_class_parent_unset_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  void efl_canvas_layout_color_class_parent_unset_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_canvas_layout_color_class_parent_unset_api_delegate> efl_canvas_layout_color_class_parent_unset_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_layout_color_class_parent_unset_api_delegate>(_Module, "efl_canvas_layout_color_class_parent_unset");
    private static  void color_class_parent_unset(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_canvas_layout_color_class_parent_unset was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Layout)wrapper).UnsetColorClassParent();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_canvas_layout_color_class_parent_unset_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_canvas_layout_color_class_parent_unset_delegate efl_canvas_layout_color_class_parent_unset_static_delegate;


    private delegate  void efl_canvas_layout_part_text_cursor_coord_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String part,   Edje.Cursor cur,   out  int x,   out  int y);


    public delegate  void efl_canvas_layout_part_text_cursor_coord_get_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String part,   Edje.Cursor cur,   out  int x,   out  int y);
    public static Efl.Eo.FunctionWrapper<efl_canvas_layout_part_text_cursor_coord_get_api_delegate> efl_canvas_layout_part_text_cursor_coord_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_layout_part_text_cursor_coord_get_api_delegate>(_Module, "efl_canvas_layout_part_text_cursor_coord_get");
    private static  void part_text_cursor_coord_get(System.IntPtr obj, System.IntPtr pd,   System.String part,  Edje.Cursor cur,  out  int x,  out  int y)
   {
      Eina.Log.Debug("function efl_canvas_layout_part_text_cursor_coord_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                   x = default( int);      y = default( int);                                 
         try {
            ((Layout)wrapper).GetPartTextCursorCoord( part,  cur,  out x,  out y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_canvas_layout_part_text_cursor_coord_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  part,  cur,  out x,  out y);
      }
   }
   private static efl_canvas_layout_part_text_cursor_coord_get_delegate efl_canvas_layout_part_text_cursor_coord_get_static_delegate;


    private delegate  void efl_canvas_layout_part_text_cursor_size_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String part,   Edje.Cursor cur,   out  int w,   out  int h);


    public delegate  void efl_canvas_layout_part_text_cursor_size_get_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String part,   Edje.Cursor cur,   out  int w,   out  int h);
    public static Efl.Eo.FunctionWrapper<efl_canvas_layout_part_text_cursor_size_get_api_delegate> efl_canvas_layout_part_text_cursor_size_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_layout_part_text_cursor_size_get_api_delegate>(_Module, "efl_canvas_layout_part_text_cursor_size_get");
    private static  void part_text_cursor_size_get(System.IntPtr obj, System.IntPtr pd,   System.String part,  Edje.Cursor cur,  out  int w,  out  int h)
   {
      Eina.Log.Debug("function efl_canvas_layout_part_text_cursor_size_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                   w = default( int);      h = default( int);                                 
         try {
            ((Layout)wrapper).GetPartTextCursorSize( part,  cur,  out w,  out h);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_canvas_layout_part_text_cursor_size_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  part,  cur,  out w,  out h);
      }
   }
   private static efl_canvas_layout_part_text_cursor_size_get_delegate efl_canvas_layout_part_text_cursor_size_get_static_delegate;


    private delegate  void efl_canvas_layout_part_text_cursor_on_mouse_geometry_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String part,   out  int x,   out  int y,   out  int w,   out  int h);


    public delegate  void efl_canvas_layout_part_text_cursor_on_mouse_geometry_get_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String part,   out  int x,   out  int y,   out  int w,   out  int h);
    public static Efl.Eo.FunctionWrapper<efl_canvas_layout_part_text_cursor_on_mouse_geometry_get_api_delegate> efl_canvas_layout_part_text_cursor_on_mouse_geometry_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_layout_part_text_cursor_on_mouse_geometry_get_api_delegate>(_Module, "efl_canvas_layout_part_text_cursor_on_mouse_geometry_get");
    private static  void part_text_cursor_on_mouse_geometry_get(System.IntPtr obj, System.IntPtr pd,   System.String part,  out  int x,  out  int y,  out  int w,  out  int h)
   {
      Eina.Log.Debug("function efl_canvas_layout_part_text_cursor_on_mouse_geometry_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                   x = default( int);      y = default( int);      w = default( int);      h = default( int);                                       
         try {
            ((Layout)wrapper).GetPartTextCursorOnMouseGeometry( part,  out x,  out y,  out w,  out h);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                        } else {
         efl_canvas_layout_part_text_cursor_on_mouse_geometry_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  part,  out x,  out y,  out w,  out h);
      }
   }
   private static efl_canvas_layout_part_text_cursor_on_mouse_geometry_get_delegate efl_canvas_layout_part_text_cursor_on_mouse_geometry_get_static_delegate;


    private delegate  System.IntPtr efl_content_iterate_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  System.IntPtr efl_content_iterate_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_content_iterate_api_delegate> efl_content_iterate_ptr = new Efl.Eo.FunctionWrapper<efl_content_iterate_api_delegate>(_Module, "efl_content_iterate");
    private static  System.IntPtr content_iterate(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_content_iterate was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Iterator<Efl.Gfx.Entity> _ret_var = default(Eina.Iterator<Efl.Gfx.Entity>);
         try {
            _ret_var = ((Layout)wrapper).ContentIterate();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      _ret_var.Own = false; return _ret_var.Handle;
      } else {
         return efl_content_iterate_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_content_iterate_delegate efl_content_iterate_static_delegate;


    private delegate  int efl_content_count_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  int efl_content_count_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_content_count_api_delegate> efl_content_count_ptr = new Efl.Eo.FunctionWrapper<efl_content_count_api_delegate>(_Module, "efl_content_count");
    private static  int content_count(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_content_count was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   int _ret_var = default( int);
         try {
            _ret_var = ((Layout)wrapper).ContentCount();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_content_count_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_content_count_delegate efl_content_count_static_delegate;


    private delegate Eina.File efl_file_mmap_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Eina.File efl_file_mmap_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_file_mmap_get_api_delegate> efl_file_mmap_get_ptr = new Efl.Eo.FunctionWrapper<efl_file_mmap_get_api_delegate>(_Module, "efl_file_mmap_get");
    private static Eina.File mmap_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_file_mmap_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.File _ret_var = default(Eina.File);
         try {
            _ret_var = ((Layout)wrapper).GetMmap();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_file_mmap_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_file_mmap_get_delegate efl_file_mmap_get_static_delegate;


    private delegate  Eina.Error efl_file_mmap_set_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.File f);


    public delegate  Eina.Error efl_file_mmap_set_api_delegate(System.IntPtr obj,   Eina.File f);
    public static Efl.Eo.FunctionWrapper<efl_file_mmap_set_api_delegate> efl_file_mmap_set_ptr = new Efl.Eo.FunctionWrapper<efl_file_mmap_set_api_delegate>(_Module, "efl_file_mmap_set");
    private static  Eina.Error mmap_set(System.IntPtr obj, System.IntPtr pd,  Eina.File f)
   {
      Eina.Log.Debug("function efl_file_mmap_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                     Eina.Error _ret_var = default( Eina.Error);
         try {
            _ret_var = ((Layout)wrapper).SetMmap( f);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_file_mmap_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  f);
      }
   }
   private static efl_file_mmap_set_delegate efl_file_mmap_set_static_delegate;


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate  System.String efl_file_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate  System.String efl_file_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_file_get_api_delegate> efl_file_get_ptr = new Efl.Eo.FunctionWrapper<efl_file_get_api_delegate>(_Module, "efl_file_get");
    private static  System.String file_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_file_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((Layout)wrapper).GetFile();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_file_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_file_get_delegate efl_file_get_static_delegate;


    private delegate  Eina.Error efl_file_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String file);


    public delegate  Eina.Error efl_file_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String file);
    public static Efl.Eo.FunctionWrapper<efl_file_set_api_delegate> efl_file_set_ptr = new Efl.Eo.FunctionWrapper<efl_file_set_api_delegate>(_Module, "efl_file_set");
    private static  Eina.Error file_set(System.IntPtr obj, System.IntPtr pd,   System.String file)
   {
      Eina.Log.Debug("function efl_file_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                     Eina.Error _ret_var = default( Eina.Error);
         try {
            _ret_var = ((Layout)wrapper).SetFile( file);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_file_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  file);
      }
   }
   private static efl_file_set_delegate efl_file_set_static_delegate;


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate  System.String efl_file_key_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate  System.String efl_file_key_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_file_key_get_api_delegate> efl_file_key_get_ptr = new Efl.Eo.FunctionWrapper<efl_file_key_get_api_delegate>(_Module, "efl_file_key_get");
    private static  System.String key_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_file_key_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((Layout)wrapper).GetKey();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_file_key_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_file_key_get_delegate efl_file_key_get_static_delegate;


    private delegate  void efl_file_key_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key);


    public delegate  void efl_file_key_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key);
    public static Efl.Eo.FunctionWrapper<efl_file_key_set_api_delegate> efl_file_key_set_ptr = new Efl.Eo.FunctionWrapper<efl_file_key_set_api_delegate>(_Module, "efl_file_key_set");
    private static  void key_set(System.IntPtr obj, System.IntPtr pd,   System.String key)
   {
      Eina.Log.Debug("function efl_file_key_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Layout)wrapper).SetKey( key);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_file_key_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  key);
      }
   }
   private static efl_file_key_set_delegate efl_file_key_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_file_loaded_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_file_loaded_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_file_loaded_get_api_delegate> efl_file_loaded_get_ptr = new Efl.Eo.FunctionWrapper<efl_file_loaded_get_api_delegate>(_Module, "efl_file_loaded_get");
    private static bool loaded_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_file_loaded_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Layout)wrapper).GetLoaded();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_file_loaded_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_file_loaded_get_delegate efl_file_loaded_get_static_delegate;


    private delegate  Eina.Error efl_file_load_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  Eina.Error efl_file_load_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_file_load_api_delegate> efl_file_load_ptr = new Efl.Eo.FunctionWrapper<efl_file_load_api_delegate>(_Module, "efl_file_load");
    private static  Eina.Error load(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_file_load was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   Eina.Error _ret_var = default( Eina.Error);
         try {
            _ret_var = ((Layout)wrapper).Load();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_file_load_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_file_load_delegate efl_file_load_static_delegate;


    private delegate  void efl_file_unload_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  void efl_file_unload_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_file_unload_api_delegate> efl_file_unload_ptr = new Efl.Eo.FunctionWrapper<efl_file_unload_api_delegate>(_Module, "efl_file_unload");
    private static  void unload(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_file_unload was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Layout)wrapper).Unload();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_file_unload_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_file_unload_delegate efl_file_unload_static_delegate;


    private delegate  void efl_observer_update_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object obs,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key,    System.IntPtr data);


    public delegate  void efl_observer_update_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object obs,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key,    System.IntPtr data);
    public static Efl.Eo.FunctionWrapper<efl_observer_update_api_delegate> efl_observer_update_ptr = new Efl.Eo.FunctionWrapper<efl_observer_update_api_delegate>(_Module, "efl_observer_update");
    private static  void update(System.IntPtr obj, System.IntPtr pd,  Efl.Object obs,   System.String key,   System.IntPtr data)
   {
      Eina.Log.Debug("function efl_observer_update was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                        
         try {
            ((Layout)wrapper).Update( obs,  key,  data);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                } else {
         efl_observer_update_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  obs,  key,  data);
      }
   }
   private static efl_observer_update_delegate efl_observer_update_static_delegate;


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))] private delegate Efl.Object efl_part_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name);


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))] public delegate Efl.Object efl_part_get_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name);
    public static Efl.Eo.FunctionWrapper<efl_part_get_api_delegate> efl_part_get_ptr = new Efl.Eo.FunctionWrapper<efl_part_get_api_delegate>(_Module, "efl_part_get");
    private static Efl.Object part_get(System.IntPtr obj, System.IntPtr pd,   System.String name)
   {
      Eina.Log.Debug("function efl_part_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    Efl.Object _ret_var = default(Efl.Object);
         try {
            _ret_var = ((Layout)wrapper).GetPart( name);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_part_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  name);
      }
   }
   private static efl_part_get_delegate efl_part_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_player_playable_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_player_playable_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_player_playable_get_api_delegate> efl_player_playable_get_ptr = new Efl.Eo.FunctionWrapper<efl_player_playable_get_api_delegate>(_Module, "efl_player_playable_get");
    private static bool playable_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_player_playable_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Layout)wrapper).GetPlayable();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_player_playable_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_player_playable_get_delegate efl_player_playable_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_player_play_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_player_play_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_player_play_get_api_delegate> efl_player_play_get_ptr = new Efl.Eo.FunctionWrapper<efl_player_play_get_api_delegate>(_Module, "efl_player_play_get");
    private static bool play_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_player_play_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Layout)wrapper).GetPlay();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_player_play_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_player_play_get_delegate efl_player_play_get_static_delegate;


    private delegate  void efl_player_play_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool play);


    public delegate  void efl_player_play_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool play);
    public static Efl.Eo.FunctionWrapper<efl_player_play_set_api_delegate> efl_player_play_set_ptr = new Efl.Eo.FunctionWrapper<efl_player_play_set_api_delegate>(_Module, "efl_player_play_set");
    private static  void play_set(System.IntPtr obj, System.IntPtr pd,  bool play)
   {
      Eina.Log.Debug("function efl_player_play_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Layout)wrapper).SetPlay( play);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_player_play_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  play);
      }
   }
   private static efl_player_play_set_delegate efl_player_play_set_static_delegate;


    private delegate double efl_player_pos_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate double efl_player_pos_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_player_pos_get_api_delegate> efl_player_pos_get_ptr = new Efl.Eo.FunctionWrapper<efl_player_pos_get_api_delegate>(_Module, "efl_player_pos_get");
    private static double pos_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_player_pos_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  double _ret_var = default(double);
         try {
            _ret_var = ((Layout)wrapper).GetPos();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_player_pos_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_player_pos_get_delegate efl_player_pos_get_static_delegate;


    private delegate  void efl_player_pos_set_delegate(System.IntPtr obj, System.IntPtr pd,   double sec);


    public delegate  void efl_player_pos_set_api_delegate(System.IntPtr obj,   double sec);
    public static Efl.Eo.FunctionWrapper<efl_player_pos_set_api_delegate> efl_player_pos_set_ptr = new Efl.Eo.FunctionWrapper<efl_player_pos_set_api_delegate>(_Module, "efl_player_pos_set");
    private static  void pos_set(System.IntPtr obj, System.IntPtr pd,  double sec)
   {
      Eina.Log.Debug("function efl_player_pos_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Layout)wrapper).SetPos( sec);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_player_pos_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  sec);
      }
   }
   private static efl_player_pos_set_delegate efl_player_pos_set_static_delegate;


    private delegate double efl_player_progress_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate double efl_player_progress_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_player_progress_get_api_delegate> efl_player_progress_get_ptr = new Efl.Eo.FunctionWrapper<efl_player_progress_get_api_delegate>(_Module, "efl_player_progress_get");
    private static double progress_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_player_progress_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  double _ret_var = default(double);
         try {
            _ret_var = ((Layout)wrapper).GetProgress();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_player_progress_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_player_progress_get_delegate efl_player_progress_get_static_delegate;


    private delegate double efl_player_play_speed_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate double efl_player_play_speed_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_player_play_speed_get_api_delegate> efl_player_play_speed_get_ptr = new Efl.Eo.FunctionWrapper<efl_player_play_speed_get_api_delegate>(_Module, "efl_player_play_speed_get");
    private static double play_speed_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_player_play_speed_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  double _ret_var = default(double);
         try {
            _ret_var = ((Layout)wrapper).GetPlaySpeed();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_player_play_speed_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_player_play_speed_get_delegate efl_player_play_speed_get_static_delegate;


    private delegate  void efl_player_play_speed_set_delegate(System.IntPtr obj, System.IntPtr pd,   double speed);


    public delegate  void efl_player_play_speed_set_api_delegate(System.IntPtr obj,   double speed);
    public static Efl.Eo.FunctionWrapper<efl_player_play_speed_set_api_delegate> efl_player_play_speed_set_ptr = new Efl.Eo.FunctionWrapper<efl_player_play_speed_set_api_delegate>(_Module, "efl_player_play_speed_set");
    private static  void play_speed_set(System.IntPtr obj, System.IntPtr pd,  double speed)
   {
      Eina.Log.Debug("function efl_player_play_speed_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Layout)wrapper).SetPlaySpeed( speed);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_player_play_speed_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  speed);
      }
   }
   private static efl_player_play_speed_set_delegate efl_player_play_speed_set_static_delegate;


    private delegate double efl_player_volume_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate double efl_player_volume_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_player_volume_get_api_delegate> efl_player_volume_get_ptr = new Efl.Eo.FunctionWrapper<efl_player_volume_get_api_delegate>(_Module, "efl_player_volume_get");
    private static double volume_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_player_volume_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  double _ret_var = default(double);
         try {
            _ret_var = ((Layout)wrapper).GetVolume();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_player_volume_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_player_volume_get_delegate efl_player_volume_get_static_delegate;


    private delegate  void efl_player_volume_set_delegate(System.IntPtr obj, System.IntPtr pd,   double volume);


    public delegate  void efl_player_volume_set_api_delegate(System.IntPtr obj,   double volume);
    public static Efl.Eo.FunctionWrapper<efl_player_volume_set_api_delegate> efl_player_volume_set_ptr = new Efl.Eo.FunctionWrapper<efl_player_volume_set_api_delegate>(_Module, "efl_player_volume_set");
    private static  void volume_set(System.IntPtr obj, System.IntPtr pd,  double volume)
   {
      Eina.Log.Debug("function efl_player_volume_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Layout)wrapper).SetVolume( volume);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_player_volume_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  volume);
      }
   }
   private static efl_player_volume_set_delegate efl_player_volume_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_player_mute_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_player_mute_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_player_mute_get_api_delegate> efl_player_mute_get_ptr = new Efl.Eo.FunctionWrapper<efl_player_mute_get_api_delegate>(_Module, "efl_player_mute_get");
    private static bool mute_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_player_mute_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Layout)wrapper).GetMute();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_player_mute_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_player_mute_get_delegate efl_player_mute_get_static_delegate;


    private delegate  void efl_player_mute_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool mute);


    public delegate  void efl_player_mute_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool mute);
    public static Efl.Eo.FunctionWrapper<efl_player_mute_set_api_delegate> efl_player_mute_set_ptr = new Efl.Eo.FunctionWrapper<efl_player_mute_set_api_delegate>(_Module, "efl_player_mute_set");
    private static  void mute_set(System.IntPtr obj, System.IntPtr pd,  bool mute)
   {
      Eina.Log.Debug("function efl_player_mute_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Layout)wrapper).SetMute( mute);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_player_mute_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  mute);
      }
   }
   private static efl_player_mute_set_delegate efl_player_mute_set_static_delegate;


    private delegate double efl_player_length_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate double efl_player_length_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_player_length_get_api_delegate> efl_player_length_get_ptr = new Efl.Eo.FunctionWrapper<efl_player_length_get_api_delegate>(_Module, "efl_player_length_get");
    private static double length_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_player_length_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  double _ret_var = default(double);
         try {
            _ret_var = ((Layout)wrapper).GetLength();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_player_length_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_player_length_get_delegate efl_player_length_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_player_seekable_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_player_seekable_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_player_seekable_get_api_delegate> efl_player_seekable_get_ptr = new Efl.Eo.FunctionWrapper<efl_player_seekable_get_api_delegate>(_Module, "efl_player_seekable_get");
    private static bool seekable_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_player_seekable_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Layout)wrapper).GetSeekable();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_player_seekable_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_player_seekable_get_delegate efl_player_seekable_get_static_delegate;


    private delegate  void efl_player_start_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  void efl_player_start_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_player_start_api_delegate> efl_player_start_ptr = new Efl.Eo.FunctionWrapper<efl_player_start_api_delegate>(_Module, "efl_player_start");
    private static  void start(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_player_start was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Layout)wrapper).Start();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_player_start_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_player_start_delegate efl_player_start_static_delegate;


    private delegate  void efl_player_stop_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  void efl_player_stop_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_player_stop_api_delegate> efl_player_stop_ptr = new Efl.Eo.FunctionWrapper<efl_player_stop_api_delegate>(_Module, "efl_player_stop");
    private static  void stop(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_player_stop was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Layout)wrapper).Stop();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_player_stop_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_player_stop_delegate efl_player_stop_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_gfx_color_class_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String color_class,   Efl.Gfx.ColorClassLayer layer,   out  int r,   out  int g,   out  int b,   out  int a);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_gfx_color_class_get_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String color_class,   Efl.Gfx.ColorClassLayer layer,   out  int r,   out  int g,   out  int b,   out  int a);
    public static Efl.Eo.FunctionWrapper<efl_gfx_color_class_get_api_delegate> efl_gfx_color_class_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_color_class_get_api_delegate>(_Module, "efl_gfx_color_class_get");
    private static bool color_class_get(System.IntPtr obj, System.IntPtr pd,   System.String color_class,  Efl.Gfx.ColorClassLayer layer,  out  int r,  out  int g,  out  int b,  out  int a)
   {
      Eina.Log.Debug("function efl_gfx_color_class_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                               r = default( int);      g = default( int);      b = default( int);      a = default( int);                                             bool _ret_var = default(bool);
         try {
            _ret_var = ((Layout)wrapper).GetColorClass( color_class,  layer,  out r,  out g,  out b,  out a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                              return _ret_var;
      } else {
         return efl_gfx_color_class_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  color_class,  layer,  out r,  out g,  out b,  out a);
      }
   }
   private static efl_gfx_color_class_get_delegate efl_gfx_color_class_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_gfx_color_class_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String color_class,   Efl.Gfx.ColorClassLayer layer,    int r,    int g,    int b,    int a);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_gfx_color_class_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String color_class,   Efl.Gfx.ColorClassLayer layer,    int r,    int g,    int b,    int a);
    public static Efl.Eo.FunctionWrapper<efl_gfx_color_class_set_api_delegate> efl_gfx_color_class_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_color_class_set_api_delegate>(_Module, "efl_gfx_color_class_set");
    private static bool color_class_set(System.IntPtr obj, System.IntPtr pd,   System.String color_class,  Efl.Gfx.ColorClassLayer layer,   int r,   int g,   int b,   int a)
   {
      Eina.Log.Debug("function efl_gfx_color_class_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                                                              bool _ret_var = default(bool);
         try {
            _ret_var = ((Layout)wrapper).SetColorClass( color_class,  layer,  r,  g,  b,  a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                              return _ret_var;
      } else {
         return efl_gfx_color_class_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  color_class,  layer,  r,  g,  b,  a);
      }
   }
   private static efl_gfx_color_class_set_delegate efl_gfx_color_class_set_static_delegate;


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate  System.String efl_gfx_color_class_code_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String color_class,   Efl.Gfx.ColorClassLayer layer);


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate  System.String efl_gfx_color_class_code_get_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String color_class,   Efl.Gfx.ColorClassLayer layer);
    public static Efl.Eo.FunctionWrapper<efl_gfx_color_class_code_get_api_delegate> efl_gfx_color_class_code_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_color_class_code_get_api_delegate>(_Module, "efl_gfx_color_class_code_get");
    private static  System.String color_class_code_get(System.IntPtr obj, System.IntPtr pd,   System.String color_class,  Efl.Gfx.ColorClassLayer layer)
   {
      Eina.Log.Debug("function efl_gfx_color_class_code_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                       System.String _ret_var = default( System.String);
         try {
            _ret_var = ((Layout)wrapper).GetColorClassCode( color_class,  layer);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_gfx_color_class_code_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  color_class,  layer);
      }
   }
   private static efl_gfx_color_class_code_get_delegate efl_gfx_color_class_code_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_gfx_color_class_code_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String color_class,   Efl.Gfx.ColorClassLayer layer,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String colorcode);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_gfx_color_class_code_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String color_class,   Efl.Gfx.ColorClassLayer layer,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String colorcode);
    public static Efl.Eo.FunctionWrapper<efl_gfx_color_class_code_set_api_delegate> efl_gfx_color_class_code_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_color_class_code_set_api_delegate>(_Module, "efl_gfx_color_class_code_set");
    private static bool color_class_code_set(System.IntPtr obj, System.IntPtr pd,   System.String color_class,  Efl.Gfx.ColorClassLayer layer,   System.String colorcode)
   {
      Eina.Log.Debug("function efl_gfx_color_class_code_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                        bool _ret_var = default(bool);
         try {
            _ret_var = ((Layout)wrapper).SetColorClassCode( color_class,  layer,  colorcode);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                          return _ret_var;
      } else {
         return efl_gfx_color_class_code_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  color_class,  layer,  colorcode);
      }
   }
   private static efl_gfx_color_class_code_set_delegate efl_gfx_color_class_code_set_static_delegate;


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate  System.String efl_gfx_color_class_description_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String color_class);


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate  System.String efl_gfx_color_class_description_get_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String color_class);
    public static Efl.Eo.FunctionWrapper<efl_gfx_color_class_description_get_api_delegate> efl_gfx_color_class_description_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_color_class_description_get_api_delegate>(_Module, "efl_gfx_color_class_description_get");
    private static  System.String color_class_description_get(System.IntPtr obj, System.IntPtr pd,   System.String color_class)
   {
      Eina.Log.Debug("function efl_gfx_color_class_description_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                     System.String _ret_var = default( System.String);
         try {
            _ret_var = ((Layout)wrapper).GetColorClassDescription( color_class);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_gfx_color_class_description_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  color_class);
      }
   }
   private static efl_gfx_color_class_description_get_delegate efl_gfx_color_class_description_get_static_delegate;


    private delegate  void efl_gfx_color_class_del_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String color_class);


    public delegate  void efl_gfx_color_class_del_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String color_class);
    public static Efl.Eo.FunctionWrapper<efl_gfx_color_class_del_api_delegate> efl_gfx_color_class_del_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_color_class_del_api_delegate>(_Module, "efl_gfx_color_class_del");
    private static  void color_class_del(System.IntPtr obj, System.IntPtr pd,   System.String color_class)
   {
      Eina.Log.Debug("function efl_gfx_color_class_del was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Layout)wrapper).DelColorClass( color_class);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_color_class_del_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  color_class);
      }
   }
   private static efl_gfx_color_class_del_delegate efl_gfx_color_class_del_static_delegate;


    private delegate  void efl_gfx_color_class_clear_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  void efl_gfx_color_class_clear_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_gfx_color_class_clear_api_delegate> efl_gfx_color_class_clear_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_color_class_clear_api_delegate>(_Module, "efl_gfx_color_class_clear");
    private static  void color_class_clear(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_color_class_clear was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Layout)wrapper).ClearColorClass();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_gfx_color_class_clear_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_gfx_color_class_clear_delegate efl_gfx_color_class_clear_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_gfx_size_class_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String size_class,   out  int minw,   out  int minh,   out  int maxw,   out  int maxh);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_gfx_size_class_get_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String size_class,   out  int minw,   out  int minh,   out  int maxw,   out  int maxh);
    public static Efl.Eo.FunctionWrapper<efl_gfx_size_class_get_api_delegate> efl_gfx_size_class_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_size_class_get_api_delegate>(_Module, "efl_gfx_size_class_get");
    private static bool size_class_get(System.IntPtr obj, System.IntPtr pd,   System.String size_class,  out  int minw,  out  int minh,  out  int maxw,  out  int maxh)
   {
      Eina.Log.Debug("function efl_gfx_size_class_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                   minw = default( int);      minh = default( int);      maxw = default( int);      maxh = default( int);                                       bool _ret_var = default(bool);
         try {
            _ret_var = ((Layout)wrapper).GetSizeClass( size_class,  out minw,  out minh,  out maxw,  out maxh);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                  return _ret_var;
      } else {
         return efl_gfx_size_class_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  size_class,  out minw,  out minh,  out maxw,  out maxh);
      }
   }
   private static efl_gfx_size_class_get_delegate efl_gfx_size_class_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_gfx_size_class_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String size_class,    int minw,    int minh,    int maxw,    int maxh);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_gfx_size_class_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String size_class,    int minw,    int minh,    int maxw,    int maxh);
    public static Efl.Eo.FunctionWrapper<efl_gfx_size_class_set_api_delegate> efl_gfx_size_class_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_size_class_set_api_delegate>(_Module, "efl_gfx_size_class_set");
    private static bool size_class_set(System.IntPtr obj, System.IntPtr pd,   System.String size_class,   int minw,   int minh,   int maxw,   int maxh)
   {
      Eina.Log.Debug("function efl_gfx_size_class_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                                            bool _ret_var = default(bool);
         try {
            _ret_var = ((Layout)wrapper).SetSizeClass( size_class,  minw,  minh,  maxw,  maxh);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                  return _ret_var;
      } else {
         return efl_gfx_size_class_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  size_class,  minw,  minh,  maxw,  maxh);
      }
   }
   private static efl_gfx_size_class_set_delegate efl_gfx_size_class_set_static_delegate;


    private delegate  void efl_gfx_size_class_del_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String size_class);


    public delegate  void efl_gfx_size_class_del_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String size_class);
    public static Efl.Eo.FunctionWrapper<efl_gfx_size_class_del_api_delegate> efl_gfx_size_class_del_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_size_class_del_api_delegate>(_Module, "efl_gfx_size_class_del");
    private static  void size_class_del(System.IntPtr obj, System.IntPtr pd,   System.String size_class)
   {
      Eina.Log.Debug("function efl_gfx_size_class_del was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Layout)wrapper).DelSizeClass( size_class);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_size_class_del_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  size_class);
      }
   }
   private static efl_gfx_size_class_del_delegate efl_gfx_size_class_del_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_gfx_text_class_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String text_class,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  out  System.String font,   out Efl.Font.Size size);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_gfx_text_class_get_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String text_class,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  out  System.String font,   out Efl.Font.Size size);
    public static Efl.Eo.FunctionWrapper<efl_gfx_text_class_get_api_delegate> efl_gfx_text_class_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_text_class_get_api_delegate>(_Module, "efl_gfx_text_class_get");
    private static bool text_class_get(System.IntPtr obj, System.IntPtr pd,   System.String text_class,  out  System.String font,  out Efl.Font.Size size)
   {
      Eina.Log.Debug("function efl_gfx_text_class_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                        System.String _out_font = default( System.String);
      size = default(Efl.Font.Size);                           bool _ret_var = default(bool);
         try {
            _ret_var = ((Layout)wrapper).GetTextClass( text_class,  out _out_font,  out size);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            font = _out_font;
                              return _ret_var;
      } else {
         return efl_gfx_text_class_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  text_class,  out font,  out size);
      }
   }
   private static efl_gfx_text_class_get_delegate efl_gfx_text_class_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_gfx_text_class_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String text_class,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String font,   Efl.Font.Size size);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_gfx_text_class_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String text_class,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String font,   Efl.Font.Size size);
    public static Efl.Eo.FunctionWrapper<efl_gfx_text_class_set_api_delegate> efl_gfx_text_class_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_text_class_set_api_delegate>(_Module, "efl_gfx_text_class_set");
    private static bool text_class_set(System.IntPtr obj, System.IntPtr pd,   System.String text_class,   System.String font,  Efl.Font.Size size)
   {
      Eina.Log.Debug("function efl_gfx_text_class_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                        bool _ret_var = default(bool);
         try {
            _ret_var = ((Layout)wrapper).SetTextClass( text_class,  font,  size);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                          return _ret_var;
      } else {
         return efl_gfx_text_class_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  text_class,  font,  size);
      }
   }
   private static efl_gfx_text_class_set_delegate efl_gfx_text_class_set_static_delegate;


    private delegate  void efl_gfx_text_class_del_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String text_class);


    public delegate  void efl_gfx_text_class_del_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String text_class);
    public static Efl.Eo.FunctionWrapper<efl_gfx_text_class_del_api_delegate> efl_gfx_text_class_del_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_text_class_del_api_delegate>(_Module, "efl_gfx_text_class_del");
    private static  void text_class_del(System.IntPtr obj, System.IntPtr pd,   System.String text_class)
   {
      Eina.Log.Debug("function efl_gfx_text_class_del was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Layout)wrapper).DelTextClass( text_class);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_text_class_del_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  text_class);
      }
   }
   private static efl_gfx_text_class_del_delegate efl_gfx_text_class_del_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_layout_calc_auto_update_hints_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_layout_calc_auto_update_hints_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_layout_calc_auto_update_hints_get_api_delegate> efl_layout_calc_auto_update_hints_get_ptr = new Efl.Eo.FunctionWrapper<efl_layout_calc_auto_update_hints_get_api_delegate>(_Module, "efl_layout_calc_auto_update_hints_get");
    private static bool calc_auto_update_hints_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_layout_calc_auto_update_hints_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Layout)wrapper).GetCalcAutoUpdateHints();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_layout_calc_auto_update_hints_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_layout_calc_auto_update_hints_get_delegate efl_layout_calc_auto_update_hints_get_static_delegate;


    private delegate  void efl_layout_calc_auto_update_hints_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool update);


    public delegate  void efl_layout_calc_auto_update_hints_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool update);
    public static Efl.Eo.FunctionWrapper<efl_layout_calc_auto_update_hints_set_api_delegate> efl_layout_calc_auto_update_hints_set_ptr = new Efl.Eo.FunctionWrapper<efl_layout_calc_auto_update_hints_set_api_delegate>(_Module, "efl_layout_calc_auto_update_hints_set");
    private static  void calc_auto_update_hints_set(System.IntPtr obj, System.IntPtr pd,  bool update)
   {
      Eina.Log.Debug("function efl_layout_calc_auto_update_hints_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Layout)wrapper).SetCalcAutoUpdateHints( update);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_layout_calc_auto_update_hints_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  update);
      }
   }
   private static efl_layout_calc_auto_update_hints_set_delegate efl_layout_calc_auto_update_hints_set_static_delegate;


    private delegate Eina.Size2D_StructInternal efl_layout_calc_size_min_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Size2D_StructInternal restricted);


    public delegate Eina.Size2D_StructInternal efl_layout_calc_size_min_api_delegate(System.IntPtr obj,   Eina.Size2D_StructInternal restricted);
    public static Efl.Eo.FunctionWrapper<efl_layout_calc_size_min_api_delegate> efl_layout_calc_size_min_ptr = new Efl.Eo.FunctionWrapper<efl_layout_calc_size_min_api_delegate>(_Module, "efl_layout_calc_size_min");
    private static Eina.Size2D_StructInternal calc_size_min(System.IntPtr obj, System.IntPtr pd,  Eina.Size2D_StructInternal restricted)
   {
      Eina.Log.Debug("function efl_layout_calc_size_min was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_restricted = Eina.Size2D_StructConversion.ToManaged(restricted);
                     Eina.Size2D _ret_var = default(Eina.Size2D);
         try {
            _ret_var = ((Layout)wrapper).CalcSizeMin( _in_restricted);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return Eina.Size2D_StructConversion.ToInternal(_ret_var);
      } else {
         return efl_layout_calc_size_min_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  restricted);
      }
   }
   private static efl_layout_calc_size_min_delegate efl_layout_calc_size_min_static_delegate;


    private delegate Eina.Rect_StructInternal efl_layout_calc_parts_extends_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Eina.Rect_StructInternal efl_layout_calc_parts_extends_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_layout_calc_parts_extends_api_delegate> efl_layout_calc_parts_extends_ptr = new Efl.Eo.FunctionWrapper<efl_layout_calc_parts_extends_api_delegate>(_Module, "efl_layout_calc_parts_extends");
    private static Eina.Rect_StructInternal calc_parts_extends(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_layout_calc_parts_extends was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Rect _ret_var = default(Eina.Rect);
         try {
            _ret_var = ((Layout)wrapper).CalcPartsExtends();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Eina.Rect_StructConversion.ToInternal(_ret_var);
      } else {
         return efl_layout_calc_parts_extends_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_layout_calc_parts_extends_delegate efl_layout_calc_parts_extends_static_delegate;


    private delegate  int efl_layout_calc_freeze_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  int efl_layout_calc_freeze_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_layout_calc_freeze_api_delegate> efl_layout_calc_freeze_ptr = new Efl.Eo.FunctionWrapper<efl_layout_calc_freeze_api_delegate>(_Module, "efl_layout_calc_freeze");
    private static  int calc_freeze(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_layout_calc_freeze was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   int _ret_var = default( int);
         try {
            _ret_var = ((Layout)wrapper).FreezeCalc();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_layout_calc_freeze_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_layout_calc_freeze_delegate efl_layout_calc_freeze_static_delegate;


    private delegate  int efl_layout_calc_thaw_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  int efl_layout_calc_thaw_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_layout_calc_thaw_api_delegate> efl_layout_calc_thaw_ptr = new Efl.Eo.FunctionWrapper<efl_layout_calc_thaw_api_delegate>(_Module, "efl_layout_calc_thaw");
    private static  int calc_thaw(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_layout_calc_thaw was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   int _ret_var = default( int);
         try {
            _ret_var = ((Layout)wrapper).ThawCalc();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_layout_calc_thaw_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_layout_calc_thaw_delegate efl_layout_calc_thaw_static_delegate;


    private delegate  void efl_layout_calc_force_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  void efl_layout_calc_force_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_layout_calc_force_api_delegate> efl_layout_calc_force_ptr = new Efl.Eo.FunctionWrapper<efl_layout_calc_force_api_delegate>(_Module, "efl_layout_calc_force");
    private static  void calc_force(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_layout_calc_force was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Layout)wrapper).CalcForce();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_layout_calc_force_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_layout_calc_force_delegate efl_layout_calc_force_static_delegate;


    private delegate Eina.Size2D_StructInternal efl_layout_group_size_min_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Eina.Size2D_StructInternal efl_layout_group_size_min_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_layout_group_size_min_get_api_delegate> efl_layout_group_size_min_get_ptr = new Efl.Eo.FunctionWrapper<efl_layout_group_size_min_get_api_delegate>(_Module, "efl_layout_group_size_min_get");
    private static Eina.Size2D_StructInternal group_size_min_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_layout_group_size_min_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Size2D _ret_var = default(Eina.Size2D);
         try {
            _ret_var = ((Layout)wrapper).GetGroupSizeMin();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Eina.Size2D_StructConversion.ToInternal(_ret_var);
      } else {
         return efl_layout_group_size_min_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_layout_group_size_min_get_delegate efl_layout_group_size_min_get_static_delegate;


    private delegate Eina.Size2D_StructInternal efl_layout_group_size_max_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Eina.Size2D_StructInternal efl_layout_group_size_max_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_layout_group_size_max_get_api_delegate> efl_layout_group_size_max_get_ptr = new Efl.Eo.FunctionWrapper<efl_layout_group_size_max_get_api_delegate>(_Module, "efl_layout_group_size_max_get");
    private static Eina.Size2D_StructInternal group_size_max_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_layout_group_size_max_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Size2D _ret_var = default(Eina.Size2D);
         try {
            _ret_var = ((Layout)wrapper).GetGroupSizeMax();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Eina.Size2D_StructConversion.ToInternal(_ret_var);
      } else {
         return efl_layout_group_size_max_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_layout_group_size_max_get_delegate efl_layout_group_size_max_get_static_delegate;


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate  System.String efl_layout_group_data_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key);


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate  System.String efl_layout_group_data_get_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key);
    public static Efl.Eo.FunctionWrapper<efl_layout_group_data_get_api_delegate> efl_layout_group_data_get_ptr = new Efl.Eo.FunctionWrapper<efl_layout_group_data_get_api_delegate>(_Module, "efl_layout_group_data_get");
    private static  System.String group_data_get(System.IntPtr obj, System.IntPtr pd,   System.String key)
   {
      Eina.Log.Debug("function efl_layout_group_data_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                     System.String _ret_var = default( System.String);
         try {
            _ret_var = ((Layout)wrapper).GetGroupData( key);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_layout_group_data_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  key);
      }
   }
   private static efl_layout_group_data_get_delegate efl_layout_group_data_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_layout_group_part_exist_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String part);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_layout_group_part_exist_get_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String part);
    public static Efl.Eo.FunctionWrapper<efl_layout_group_part_exist_get_api_delegate> efl_layout_group_part_exist_get_ptr = new Efl.Eo.FunctionWrapper<efl_layout_group_part_exist_get_api_delegate>(_Module, "efl_layout_group_part_exist_get");
    private static bool part_exist_get(System.IntPtr obj, System.IntPtr pd,   System.String part)
   {
      Eina.Log.Debug("function efl_layout_group_part_exist_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((Layout)wrapper).GetPartExist( part);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_layout_group_part_exist_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  part);
      }
   }
   private static efl_layout_group_part_exist_get_delegate efl_layout_group_part_exist_get_static_delegate;


    private delegate  void efl_layout_signal_message_send_delegate(System.IntPtr obj, System.IntPtr pd,    int id,    Eina.ValueNative msg);


    public delegate  void efl_layout_signal_message_send_api_delegate(System.IntPtr obj,    int id,    Eina.ValueNative msg);
    public static Efl.Eo.FunctionWrapper<efl_layout_signal_message_send_api_delegate> efl_layout_signal_message_send_ptr = new Efl.Eo.FunctionWrapper<efl_layout_signal_message_send_api_delegate>(_Module, "efl_layout_signal_message_send");
    private static  void message_send(System.IntPtr obj, System.IntPtr pd,   int id,   Eina.ValueNative msg)
   {
      Eina.Log.Debug("function efl_layout_signal_message_send was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((Layout)wrapper).MessageSend( id,  msg);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_layout_signal_message_send_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  id,  msg);
      }
   }
   private static efl_layout_signal_message_send_delegate efl_layout_signal_message_send_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_layout_signal_callback_add_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String emission,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String source,  IntPtr func_data, EflLayoutSignalCbInternal func, EinaFreeCb func_free_cb);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_layout_signal_callback_add_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String emission,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String source,  IntPtr func_data, EflLayoutSignalCbInternal func, EinaFreeCb func_free_cb);
    public static Efl.Eo.FunctionWrapper<efl_layout_signal_callback_add_api_delegate> efl_layout_signal_callback_add_ptr = new Efl.Eo.FunctionWrapper<efl_layout_signal_callback_add_api_delegate>(_Module, "efl_layout_signal_callback_add");
    private static bool signal_callback_add(System.IntPtr obj, System.IntPtr pd,   System.String emission,   System.String source, IntPtr func_data, EflLayoutSignalCbInternal func, EinaFreeCb func_free_cb)
   {
      Eina.Log.Debug("function efl_layout_signal_callback_add was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                  EflLayoutSignalCbWrapper func_wrapper = new EflLayoutSignalCbWrapper(func, func_data, func_free_cb);
         bool _ret_var = default(bool);
         try {
            _ret_var = ((Layout)wrapper).AddSignalCallback( emission,  source,  func_wrapper.ManagedCb);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                          return _ret_var;
      } else {
         return efl_layout_signal_callback_add_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  emission,  source, func_data, func, func_free_cb);
      }
   }
   private static efl_layout_signal_callback_add_delegate efl_layout_signal_callback_add_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_layout_signal_callback_del_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String emission,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String source,  IntPtr func_data, EflLayoutSignalCbInternal func, EinaFreeCb func_free_cb);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_layout_signal_callback_del_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String emission,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String source,  IntPtr func_data, EflLayoutSignalCbInternal func, EinaFreeCb func_free_cb);
    public static Efl.Eo.FunctionWrapper<efl_layout_signal_callback_del_api_delegate> efl_layout_signal_callback_del_ptr = new Efl.Eo.FunctionWrapper<efl_layout_signal_callback_del_api_delegate>(_Module, "efl_layout_signal_callback_del");
    private static bool signal_callback_del(System.IntPtr obj, System.IntPtr pd,   System.String emission,   System.String source, IntPtr func_data, EflLayoutSignalCbInternal func, EinaFreeCb func_free_cb)
   {
      Eina.Log.Debug("function efl_layout_signal_callback_del was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                  EflLayoutSignalCbWrapper func_wrapper = new EflLayoutSignalCbWrapper(func, func_data, func_free_cb);
         bool _ret_var = default(bool);
         try {
            _ret_var = ((Layout)wrapper).DelSignalCallback( emission,  source,  func_wrapper.ManagedCb);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                          return _ret_var;
      } else {
         return efl_layout_signal_callback_del_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  emission,  source, func_data, func, func_free_cb);
      }
   }
   private static efl_layout_signal_callback_del_delegate efl_layout_signal_callback_del_static_delegate;


    private delegate  void efl_layout_signal_emit_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String emission,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String source);


    public delegate  void efl_layout_signal_emit_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String emission,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String source);
    public static Efl.Eo.FunctionWrapper<efl_layout_signal_emit_api_delegate> efl_layout_signal_emit_ptr = new Efl.Eo.FunctionWrapper<efl_layout_signal_emit_api_delegate>(_Module, "efl_layout_signal_emit");
    private static  void signal_emit(System.IntPtr obj, System.IntPtr pd,   System.String emission,   System.String source)
   {
      Eina.Log.Debug("function efl_layout_signal_emit was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((Layout)wrapper).EmitSignal( emission,  source);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_layout_signal_emit_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  emission,  source);
      }
   }
   private static efl_layout_signal_emit_delegate efl_layout_signal_emit_static_delegate;


    private delegate  void efl_layout_signal_process_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool recurse);


    public delegate  void efl_layout_signal_process_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool recurse);
    public static Efl.Eo.FunctionWrapper<efl_layout_signal_process_api_delegate> efl_layout_signal_process_ptr = new Efl.Eo.FunctionWrapper<efl_layout_signal_process_api_delegate>(_Module, "efl_layout_signal_process");
    private static  void signal_process(System.IntPtr obj, System.IntPtr pd,  bool recurse)
   {
      Eina.Log.Debug("function efl_layout_signal_process was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Layout)wrapper).SignalProcess( recurse);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_layout_signal_process_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  recurse);
      }
   }
   private static efl_layout_signal_process_delegate efl_layout_signal_process_static_delegate;
}
} } 
