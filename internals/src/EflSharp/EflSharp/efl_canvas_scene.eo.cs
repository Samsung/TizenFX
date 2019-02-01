#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Canvas { 
/// <summary>Common interface for window and some internal classes in EFL.</summary>
[SceneConcreteNativeInherit]
public interface Scene : 
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>Get the maximum image size evas can possibly handle.
/// This function returns the largest image or surface size that evas can handle in pixels, and if there is one, returns <c>true</c>. It returns <c>false</c> if no extra constraint on maximum image size exists. You still should check the return values of <c>maxw</c> and <c>maxh</c> as there may still be a limit, just a much higher one.</summary>
/// <param name="max">The maximum image size (in pixels).</param>
/// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
bool GetImageMaxSize( out Eina.Size2D max);
   /// <summary>Get if the canvas is currently calculating smart objects.</summary>
/// <returns><c>true</c> if currently calculating smart objects.</returns>
bool GetSmartObjectsCalculating();
   /// <summary>Get a device by name.</summary>
/// <param name="name">The name of the seat to find.</param>
/// <returns>The device or seat, <c>null</c> if not found.</returns>
Efl.Input.Device GetDevice(  System.String name);
   /// <summary>Get a seat by id.</summary>
/// <param name="id">The id of the seat to find.</param>
/// <returns>The seat or <c>null</c> if not found.</returns>
Efl.Input.Device GetSeat(  int id);
   /// <summary>This function returns the current known pointer coordinates
/// This function returns the current position of the main input pointer (mouse, pen, etc...).</summary>
/// <returns>The pointer position in pixels.</returns>
Eina.Position2D GetPointerPosition();
   /// <summary>Call user-provided <c>calculate</c> smart functions and unset the flag signalling that the object needs to get recalculated to all smart objects in the canvas.</summary>
/// <returns></returns>
 void CalculateSmartObjects();
   /// <summary>Retrieve a list of objects lying over a given position in a canvas.
/// This function will traverse all the layers of the given canvas, from top to bottom, querying for objects with areas covering the given position. The user can remove from query objects which are hidden and/or which are set to pass events.
/// 
/// Warning: This function will skip objects parented by smart objects, acting only on the ones at the &quot;top level&quot;, with regard to object parenting.</summary>
/// <param name="pos">The pixel position.</param>
/// <param name="include_pass_events_objects">Boolean flag to include or not objects which pass events in this calculation.</param>
/// <param name="include_hidden_objects">Boolean flag to include or not hidden objects in this calculation.</param>
/// <returns>The list of objects that are over the given position in <c>e</c>.</returns>
Eina.Iterator<Efl.Gfx.Entity> GetObjectsAtXy( Eina.Position2D pos,  bool include_pass_events_objects,  bool include_hidden_objects);
   /// <summary>Retrieve the object stacked at the top of a given position in a canvas.
/// This function will traverse all the layers of the given canvas, from top to bottom, querying for objects with areas covering the given position. The user can remove from the query objects which are hidden and/or which are set to pass events.
/// 
/// Warning: This function will skip objects parented by smart objects, acting only on the ones at the &quot;top level&quot;, with regard to object parenting.</summary>
/// <param name="pos">The pixel position.</param>
/// <param name="include_pass_events_objects">Boolean flag to include or not objects which pass events in this calculation.</param>
/// <param name="include_hidden_objects">Boolean flag to include or not hidden objects in this calculation.</param>
/// <returns>The Evas object that is over all other objects at the given position.</returns>
Efl.Gfx.Entity GetObjectTopAtXy( Eina.Position2D pos,  bool include_pass_events_objects,  bool include_hidden_objects);
   /// <summary>Retrieve a list of objects lying over a given rectangular region in a canvas.
/// This function will traverse all the layers of the given canvas, from top to bottom, querying for objects with areas overlapping with the given rectangular region inside <c>e</c>. The user can remove from the query objects which are hidden and/or which are set to pass events.
/// 
/// Warning: This function will skip objects parented by smart objects, acting only on the ones at the &quot;top level&quot;, with regard to object parenting.</summary>
/// <param name="rect">The rectangular region.</param>
/// <param name="include_pass_events_objects">Boolean flag to include or not objects which pass events in this calculation.</param>
/// <param name="include_hidden_objects">Boolean flag to include or not hidden objects in this calculation.</param>
/// <returns>Iterator to objects</returns>
Eina.Iterator<Efl.Gfx.Entity> GetObjectsInRectangle( Eina.Rect rect,  bool include_pass_events_objects,  bool include_hidden_objects);
   /// <summary>Retrieve the Evas object stacked at the top of a given rectangular region in a canvas
/// This function will traverse all the layers of the given canvas, from top to bottom, querying for objects with areas overlapping with the given rectangular region inside <c>e</c>. The user can remove from the query objects which are hidden and/or which are set to pass events.
/// 
/// Warning: This function will skip objects parented by smart objects, acting only on the ones at the &quot;top level&quot;, with regard to object parenting.</summary>
/// <param name="rect">The rectangular region.</param>
/// <param name="include_pass_events_objects">Boolean flag to include or not objects which pass events in this calculation.</param>
/// <param name="include_hidden_objects">Boolean flag to include or not hidden objects in this calculation.</param>
/// <returns>The object that is over all other objects at the given rectangular region.</returns>
Efl.Gfx.Entity GetObjectTopInRectangle( Eina.Rect rect,  bool include_pass_events_objects,  bool include_hidden_objects);
   /// <summary>Iterate over the input device seats.
/// 1.20</summary>
/// <returns>An iterator over the attached seats.</returns>
Eina.Iterator<Efl.Input.Device> Seats();
   /// <summary>Returns an iterator over the current known pointer positions.
/// This is used to iterate over the current known multi-touch positions, including the first finger. Each pointer position is represented by an object of type <see cref="Efl.Input.Pointer"/>.
/// 
/// Each finger in a multi touch environment can then be identified by the <see cref="Efl.Input.Pointer.Tool"/> property. The order of the pointers in this iterator is not defined.
/// 
/// Note: If the input surface supports hovering input, some pointers may not be in a &quot;down&quot; state. To retrieve the list of such pointers, set the <c>hover</c> value to <c>true</c>. Remember though that most devices currently don&apos;t support this.</summary>
/// <param name="hover"><c>false</c> by default, <c>true</c> means to include fingers that are currently hovering.</param>
/// <returns>Iterator to pointer positions</returns>
Eina.Iterator<Efl.Input.Pointer> PointerIterate( bool hover);
                                       /// <summary>Called when canvas got focus</summary>
   event EventHandler<Efl.Canvas.SceneFocusInEvt_Args> FocusInEvt;
   /// <summary>Called when canvas lost focus</summary>
   event EventHandler<Efl.Canvas.SceneFocusOutEvt_Args> FocusOutEvt;
   /// <summary>Called when object got focus</summary>
   event EventHandler<Efl.Canvas.SceneObjectFocusInEvt_Args> ObjectFocusInEvt;
   /// <summary>Called when object lost focus</summary>
   event EventHandler<Efl.Canvas.SceneObjectFocusOutEvt_Args> ObjectFocusOutEvt;
   /// <summary>Called when pre render happens</summary>
   event EventHandler RenderPreEvt;
   /// <summary>Called when post render happens</summary>
   event EventHandler<Efl.Canvas.SceneRenderPostEvt_Args> RenderPostEvt;
   /// <summary>Called when input device changed</summary>
   event EventHandler<Efl.Canvas.SceneDeviceChangedEvt_Args> DeviceChangedEvt;
   /// <summary>Called when input device was added</summary>
   event EventHandler<Efl.Canvas.SceneDeviceAddedEvt_Args> DeviceAddedEvt;
   /// <summary>Called when input device was removed</summary>
   event EventHandler<Efl.Canvas.SceneDeviceRemovedEvt_Args> DeviceRemovedEvt;
   /// <summary>Get if the canvas is currently calculating smart objects.</summary>
   bool SmartObjectsCalculating {
      get ;
   }
   /// <summary>This function returns the current known pointer coordinates
/// This function returns the current position of the main input pointer (mouse, pen, etc...).</summary>
   Eina.Position2D PointerPosition {
      get ;
   }
}
///<summary>Event argument wrapper for event <see cref="Efl.Canvas.Scene.FocusInEvt"/>.</summary>
public class SceneFocusInEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public Efl.Input.Focus arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Canvas.Scene.FocusOutEvt"/>.</summary>
public class SceneFocusOutEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public Efl.Input.Focus arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Canvas.Scene.ObjectFocusInEvt"/>.</summary>
public class SceneObjectFocusInEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public Efl.Input.Focus arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Canvas.Scene.ObjectFocusOutEvt"/>.</summary>
public class SceneObjectFocusOutEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public Efl.Input.Focus arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Canvas.Scene.RenderPostEvt"/>.</summary>
public class SceneRenderPostEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public Efl.Gfx.Event.RenderPost arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Canvas.Scene.DeviceChangedEvt"/>.</summary>
public class SceneDeviceChangedEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public Efl.Input.Device arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Canvas.Scene.DeviceAddedEvt"/>.</summary>
public class SceneDeviceAddedEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public Efl.Input.Device arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Canvas.Scene.DeviceRemovedEvt"/>.</summary>
public class SceneDeviceRemovedEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public Efl.Input.Device arg { get; set; }
}
/// <summary>Common interface for window and some internal classes in EFL.</summary>
sealed public class SceneConcrete : 

Scene
   
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (SceneConcrete))
            return Efl.Canvas.SceneConcreteNativeInherit.GetEflClassStatic();
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
      efl_canvas_scene_interface_get();
   ///<summary>Constructs an instance from a native pointer.</summary>
   public SceneConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~SceneConcrete()
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
   public static SceneConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new SceneConcrete(obj.NativeHandle);
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
private static object FocusInEvtKey = new object();
   /// <summary>Called when canvas got focus</summary>
   public event EventHandler<Efl.Canvas.SceneFocusInEvt_Args> FocusInEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_CANVAS_SCENE_EVENT_FOCUS_IN";
            if (add_cpp_event_handler(key, this.evt_FocusInEvt_delegate)) {
               eventHandlers.AddHandler(FocusInEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_CANVAS_SCENE_EVENT_FOCUS_IN";
            if (remove_cpp_event_handler(key, this.evt_FocusInEvt_delegate)) { 
               eventHandlers.RemoveHandler(FocusInEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event FocusInEvt.</summary>
   public void On_FocusInEvt(Efl.Canvas.SceneFocusInEvt_Args e)
   {
      EventHandler<Efl.Canvas.SceneFocusInEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Canvas.SceneFocusInEvt_Args>)eventHandlers[FocusInEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_FocusInEvt_delegate;
   private void on_FocusInEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Canvas.SceneFocusInEvt_Args args = new Efl.Canvas.SceneFocusInEvt_Args();
      args.arg = new Efl.Input.Focus(evt.Info);
      try {
         On_FocusInEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object FocusOutEvtKey = new object();
   /// <summary>Called when canvas lost focus</summary>
   public event EventHandler<Efl.Canvas.SceneFocusOutEvt_Args> FocusOutEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_CANVAS_SCENE_EVENT_FOCUS_OUT";
            if (add_cpp_event_handler(key, this.evt_FocusOutEvt_delegate)) {
               eventHandlers.AddHandler(FocusOutEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_CANVAS_SCENE_EVENT_FOCUS_OUT";
            if (remove_cpp_event_handler(key, this.evt_FocusOutEvt_delegate)) { 
               eventHandlers.RemoveHandler(FocusOutEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event FocusOutEvt.</summary>
   public void On_FocusOutEvt(Efl.Canvas.SceneFocusOutEvt_Args e)
   {
      EventHandler<Efl.Canvas.SceneFocusOutEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Canvas.SceneFocusOutEvt_Args>)eventHandlers[FocusOutEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_FocusOutEvt_delegate;
   private void on_FocusOutEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Canvas.SceneFocusOutEvt_Args args = new Efl.Canvas.SceneFocusOutEvt_Args();
      args.arg = new Efl.Input.Focus(evt.Info);
      try {
         On_FocusOutEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object ObjectFocusInEvtKey = new object();
   /// <summary>Called when object got focus</summary>
   public event EventHandler<Efl.Canvas.SceneObjectFocusInEvt_Args> ObjectFocusInEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_CANVAS_SCENE_EVENT_OBJECT_FOCUS_IN";
            if (add_cpp_event_handler(key, this.evt_ObjectFocusInEvt_delegate)) {
               eventHandlers.AddHandler(ObjectFocusInEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_CANVAS_SCENE_EVENT_OBJECT_FOCUS_IN";
            if (remove_cpp_event_handler(key, this.evt_ObjectFocusInEvt_delegate)) { 
               eventHandlers.RemoveHandler(ObjectFocusInEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ObjectFocusInEvt.</summary>
   public void On_ObjectFocusInEvt(Efl.Canvas.SceneObjectFocusInEvt_Args e)
   {
      EventHandler<Efl.Canvas.SceneObjectFocusInEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Canvas.SceneObjectFocusInEvt_Args>)eventHandlers[ObjectFocusInEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ObjectFocusInEvt_delegate;
   private void on_ObjectFocusInEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Canvas.SceneObjectFocusInEvt_Args args = new Efl.Canvas.SceneObjectFocusInEvt_Args();
      args.arg = new Efl.Input.Focus(evt.Info);
      try {
         On_ObjectFocusInEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object ObjectFocusOutEvtKey = new object();
   /// <summary>Called when object lost focus</summary>
   public event EventHandler<Efl.Canvas.SceneObjectFocusOutEvt_Args> ObjectFocusOutEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_CANVAS_SCENE_EVENT_OBJECT_FOCUS_OUT";
            if (add_cpp_event_handler(key, this.evt_ObjectFocusOutEvt_delegate)) {
               eventHandlers.AddHandler(ObjectFocusOutEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_CANVAS_SCENE_EVENT_OBJECT_FOCUS_OUT";
            if (remove_cpp_event_handler(key, this.evt_ObjectFocusOutEvt_delegate)) { 
               eventHandlers.RemoveHandler(ObjectFocusOutEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ObjectFocusOutEvt.</summary>
   public void On_ObjectFocusOutEvt(Efl.Canvas.SceneObjectFocusOutEvt_Args e)
   {
      EventHandler<Efl.Canvas.SceneObjectFocusOutEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Canvas.SceneObjectFocusOutEvt_Args>)eventHandlers[ObjectFocusOutEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ObjectFocusOutEvt_delegate;
   private void on_ObjectFocusOutEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Canvas.SceneObjectFocusOutEvt_Args args = new Efl.Canvas.SceneObjectFocusOutEvt_Args();
      args.arg = new Efl.Input.Focus(evt.Info);
      try {
         On_ObjectFocusOutEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object RenderPreEvtKey = new object();
   /// <summary>Called when pre render happens</summary>
   public event EventHandler RenderPreEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_CANVAS_SCENE_EVENT_RENDER_PRE";
            if (add_cpp_event_handler(key, this.evt_RenderPreEvt_delegate)) {
               eventHandlers.AddHandler(RenderPreEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_CANVAS_SCENE_EVENT_RENDER_PRE";
            if (remove_cpp_event_handler(key, this.evt_RenderPreEvt_delegate)) { 
               eventHandlers.RemoveHandler(RenderPreEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event RenderPreEvt.</summary>
   public void On_RenderPreEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[RenderPreEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_RenderPreEvt_delegate;
   private void on_RenderPreEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_RenderPreEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object RenderPostEvtKey = new object();
   /// <summary>Called when post render happens</summary>
   public event EventHandler<Efl.Canvas.SceneRenderPostEvt_Args> RenderPostEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_CANVAS_SCENE_EVENT_RENDER_POST";
            if (add_cpp_event_handler(key, this.evt_RenderPostEvt_delegate)) {
               eventHandlers.AddHandler(RenderPostEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_CANVAS_SCENE_EVENT_RENDER_POST";
            if (remove_cpp_event_handler(key, this.evt_RenderPostEvt_delegate)) { 
               eventHandlers.RemoveHandler(RenderPostEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event RenderPostEvt.</summary>
   public void On_RenderPostEvt(Efl.Canvas.SceneRenderPostEvt_Args e)
   {
      EventHandler<Efl.Canvas.SceneRenderPostEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Canvas.SceneRenderPostEvt_Args>)eventHandlers[RenderPostEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_RenderPostEvt_delegate;
   private void on_RenderPostEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Canvas.SceneRenderPostEvt_Args args = new Efl.Canvas.SceneRenderPostEvt_Args();
      args.arg =  evt.Info;;
      try {
         On_RenderPostEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object DeviceChangedEvtKey = new object();
   /// <summary>Called when input device changed</summary>
   public event EventHandler<Efl.Canvas.SceneDeviceChangedEvt_Args> DeviceChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_CANVAS_SCENE_EVENT_DEVICE_CHANGED";
            if (add_cpp_event_handler(key, this.evt_DeviceChangedEvt_delegate)) {
               eventHandlers.AddHandler(DeviceChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_CANVAS_SCENE_EVENT_DEVICE_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_DeviceChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(DeviceChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event DeviceChangedEvt.</summary>
   public void On_DeviceChangedEvt(Efl.Canvas.SceneDeviceChangedEvt_Args e)
   {
      EventHandler<Efl.Canvas.SceneDeviceChangedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Canvas.SceneDeviceChangedEvt_Args>)eventHandlers[DeviceChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_DeviceChangedEvt_delegate;
   private void on_DeviceChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Canvas.SceneDeviceChangedEvt_Args args = new Efl.Canvas.SceneDeviceChangedEvt_Args();
      args.arg = new Efl.Input.Device(evt.Info);
      try {
         On_DeviceChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object DeviceAddedEvtKey = new object();
   /// <summary>Called when input device was added</summary>
   public event EventHandler<Efl.Canvas.SceneDeviceAddedEvt_Args> DeviceAddedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_CANVAS_SCENE_EVENT_DEVICE_ADDED";
            if (add_cpp_event_handler(key, this.evt_DeviceAddedEvt_delegate)) {
               eventHandlers.AddHandler(DeviceAddedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_CANVAS_SCENE_EVENT_DEVICE_ADDED";
            if (remove_cpp_event_handler(key, this.evt_DeviceAddedEvt_delegate)) { 
               eventHandlers.RemoveHandler(DeviceAddedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event DeviceAddedEvt.</summary>
   public void On_DeviceAddedEvt(Efl.Canvas.SceneDeviceAddedEvt_Args e)
   {
      EventHandler<Efl.Canvas.SceneDeviceAddedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Canvas.SceneDeviceAddedEvt_Args>)eventHandlers[DeviceAddedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_DeviceAddedEvt_delegate;
   private void on_DeviceAddedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Canvas.SceneDeviceAddedEvt_Args args = new Efl.Canvas.SceneDeviceAddedEvt_Args();
      args.arg = new Efl.Input.Device(evt.Info);
      try {
         On_DeviceAddedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object DeviceRemovedEvtKey = new object();
   /// <summary>Called when input device was removed</summary>
   public event EventHandler<Efl.Canvas.SceneDeviceRemovedEvt_Args> DeviceRemovedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_CANVAS_SCENE_EVENT_DEVICE_REMOVED";
            if (add_cpp_event_handler(key, this.evt_DeviceRemovedEvt_delegate)) {
               eventHandlers.AddHandler(DeviceRemovedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_CANVAS_SCENE_EVENT_DEVICE_REMOVED";
            if (remove_cpp_event_handler(key, this.evt_DeviceRemovedEvt_delegate)) { 
               eventHandlers.RemoveHandler(DeviceRemovedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event DeviceRemovedEvt.</summary>
   public void On_DeviceRemovedEvt(Efl.Canvas.SceneDeviceRemovedEvt_Args e)
   {
      EventHandler<Efl.Canvas.SceneDeviceRemovedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Canvas.SceneDeviceRemovedEvt_Args>)eventHandlers[DeviceRemovedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_DeviceRemovedEvt_delegate;
   private void on_DeviceRemovedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Canvas.SceneDeviceRemovedEvt_Args args = new Efl.Canvas.SceneDeviceRemovedEvt_Args();
      args.arg = new Efl.Input.Device(evt.Info);
      try {
         On_DeviceRemovedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

    void register_event_proxies()
   {
      evt_FocusInEvt_delegate = new Efl.EventCb(on_FocusInEvt_NativeCallback);
      evt_FocusOutEvt_delegate = new Efl.EventCb(on_FocusOutEvt_NativeCallback);
      evt_ObjectFocusInEvt_delegate = new Efl.EventCb(on_ObjectFocusInEvt_NativeCallback);
      evt_ObjectFocusOutEvt_delegate = new Efl.EventCb(on_ObjectFocusOutEvt_NativeCallback);
      evt_RenderPreEvt_delegate = new Efl.EventCb(on_RenderPreEvt_NativeCallback);
      evt_RenderPostEvt_delegate = new Efl.EventCb(on_RenderPostEvt_NativeCallback);
      evt_DeviceChangedEvt_delegate = new Efl.EventCb(on_DeviceChangedEvt_NativeCallback);
      evt_DeviceAddedEvt_delegate = new Efl.EventCb(on_DeviceAddedEvt_NativeCallback);
      evt_DeviceRemovedEvt_delegate = new Efl.EventCb(on_DeviceRemovedEvt_NativeCallback);
   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_canvas_scene_image_max_size_get(System.IntPtr obj,   out Eina.Size2D_StructInternal max);
   /// <summary>Get the maximum image size evas can possibly handle.
   /// This function returns the largest image or surface size that evas can handle in pixels, and if there is one, returns <c>true</c>. It returns <c>false</c> if no extra constraint on maximum image size exists. You still should check the return values of <c>maxw</c> and <c>maxh</c> as there may still be a limit, just a much higher one.</summary>
   /// <param name="max">The maximum image size (in pixels).</param>
   /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
   public bool GetImageMaxSize( out Eina.Size2D max) {
             var _out_max = new Eina.Size2D_StructInternal();
            var _ret_var = efl_canvas_scene_image_max_size_get(Efl.Canvas.SceneConcrete.efl_canvas_scene_interface_get(),  out _out_max);
      Eina.Error.RaiseIfUnhandledException();
      max = Eina.Size2D_StructConversion.ToManaged(_out_max);
            return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_canvas_scene_smart_objects_calculating_get(System.IntPtr obj);
   /// <summary>Get if the canvas is currently calculating smart objects.</summary>
   /// <returns><c>true</c> if currently calculating smart objects.</returns>
   public bool GetSmartObjectsCalculating() {
       var _ret_var = efl_canvas_scene_smart_objects_calculating_get(Efl.Canvas.SceneConcrete.efl_canvas_scene_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))] private static extern Efl.Input.Device efl_canvas_scene_device_get(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name);
   /// <summary>Get a device by name.</summary>
   /// <param name="name">The name of the seat to find.</param>
   /// <returns>The device or seat, <c>null</c> if not found.</returns>
   public Efl.Input.Device GetDevice(  System.String name) {
                         var _ret_var = efl_canvas_scene_device_get(Efl.Canvas.SceneConcrete.efl_canvas_scene_interface_get(),  name);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))] private static extern Efl.Input.Device efl_canvas_scene_seat_get(System.IntPtr obj,    int id);
   /// <summary>Get a seat by id.</summary>
   /// <param name="id">The id of the seat to find.</param>
   /// <returns>The seat or <c>null</c> if not found.</returns>
   public Efl.Input.Device GetSeat(  int id) {
                         var _ret_var = efl_canvas_scene_seat_get(Efl.Canvas.SceneConcrete.efl_canvas_scene_interface_get(),  id);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern Eina.Position2D_StructInternal efl_canvas_scene_pointer_position_get(System.IntPtr obj);
   /// <summary>This function returns the current known pointer coordinates
   /// This function returns the current position of the main input pointer (mouse, pen, etc...).</summary>
   /// <returns>The pointer position in pixels.</returns>
   public Eina.Position2D GetPointerPosition() {
       var _ret_var = efl_canvas_scene_pointer_position_get(Efl.Canvas.SceneConcrete.efl_canvas_scene_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return Eina.Position2D_StructConversion.ToManaged(_ret_var);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_canvas_scene_smart_objects_calculate(System.IntPtr obj);
   /// <summary>Call user-provided <c>calculate</c> smart functions and unset the flag signalling that the object needs to get recalculated to all smart objects in the canvas.</summary>
   /// <returns></returns>
   public  void CalculateSmartObjects() {
       efl_canvas_scene_smart_objects_calculate(Efl.Canvas.SceneConcrete.efl_canvas_scene_interface_get());
      Eina.Error.RaiseIfUnhandledException();
       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  System.IntPtr efl_canvas_scene_objects_at_xy_get(System.IntPtr obj,   Eina.Position2D_StructInternal pos,  [MarshalAs(UnmanagedType.U1)]  bool include_pass_events_objects,  [MarshalAs(UnmanagedType.U1)]  bool include_hidden_objects);
   /// <summary>Retrieve a list of objects lying over a given position in a canvas.
   /// This function will traverse all the layers of the given canvas, from top to bottom, querying for objects with areas covering the given position. The user can remove from query objects which are hidden and/or which are set to pass events.
   /// 
   /// Warning: This function will skip objects parented by smart objects, acting only on the ones at the &quot;top level&quot;, with regard to object parenting.</summary>
   /// <param name="pos">The pixel position.</param>
   /// <param name="include_pass_events_objects">Boolean flag to include or not objects which pass events in this calculation.</param>
   /// <param name="include_hidden_objects">Boolean flag to include or not hidden objects in this calculation.</param>
   /// <returns>The list of objects that are over the given position in <c>e</c>.</returns>
   public Eina.Iterator<Efl.Gfx.Entity> GetObjectsAtXy( Eina.Position2D pos,  bool include_pass_events_objects,  bool include_hidden_objects) {
       var _in_pos = Eina.Position2D_StructConversion.ToInternal(pos);
                                                      var _ret_var = efl_canvas_scene_objects_at_xy_get(Efl.Canvas.SceneConcrete.efl_canvas_scene_interface_get(),  _in_pos,  include_pass_events_objects,  include_hidden_objects);
      Eina.Error.RaiseIfUnhandledException();
                                          return new Eina.Iterator<Efl.Gfx.Entity>(_ret_var, true, false);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))] private static extern Efl.Gfx.Entity efl_canvas_scene_object_top_at_xy_get(System.IntPtr obj,   Eina.Position2D_StructInternal pos,  [MarshalAs(UnmanagedType.U1)]  bool include_pass_events_objects,  [MarshalAs(UnmanagedType.U1)]  bool include_hidden_objects);
   /// <summary>Retrieve the object stacked at the top of a given position in a canvas.
   /// This function will traverse all the layers of the given canvas, from top to bottom, querying for objects with areas covering the given position. The user can remove from the query objects which are hidden and/or which are set to pass events.
   /// 
   /// Warning: This function will skip objects parented by smart objects, acting only on the ones at the &quot;top level&quot;, with regard to object parenting.</summary>
   /// <param name="pos">The pixel position.</param>
   /// <param name="include_pass_events_objects">Boolean flag to include or not objects which pass events in this calculation.</param>
   /// <param name="include_hidden_objects">Boolean flag to include or not hidden objects in this calculation.</param>
   /// <returns>The Evas object that is over all other objects at the given position.</returns>
   public Efl.Gfx.Entity GetObjectTopAtXy( Eina.Position2D pos,  bool include_pass_events_objects,  bool include_hidden_objects) {
       var _in_pos = Eina.Position2D_StructConversion.ToInternal(pos);
                                                      var _ret_var = efl_canvas_scene_object_top_at_xy_get(Efl.Canvas.SceneConcrete.efl_canvas_scene_interface_get(),  _in_pos,  include_pass_events_objects,  include_hidden_objects);
      Eina.Error.RaiseIfUnhandledException();
                                          return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  System.IntPtr efl_canvas_scene_objects_in_rectangle_get(System.IntPtr obj,   Eina.Rect_StructInternal rect,  [MarshalAs(UnmanagedType.U1)]  bool include_pass_events_objects,  [MarshalAs(UnmanagedType.U1)]  bool include_hidden_objects);
   /// <summary>Retrieve a list of objects lying over a given rectangular region in a canvas.
   /// This function will traverse all the layers of the given canvas, from top to bottom, querying for objects with areas overlapping with the given rectangular region inside <c>e</c>. The user can remove from the query objects which are hidden and/or which are set to pass events.
   /// 
   /// Warning: This function will skip objects parented by smart objects, acting only on the ones at the &quot;top level&quot;, with regard to object parenting.</summary>
   /// <param name="rect">The rectangular region.</param>
   /// <param name="include_pass_events_objects">Boolean flag to include or not objects which pass events in this calculation.</param>
   /// <param name="include_hidden_objects">Boolean flag to include or not hidden objects in this calculation.</param>
   /// <returns>Iterator to objects</returns>
   public Eina.Iterator<Efl.Gfx.Entity> GetObjectsInRectangle( Eina.Rect rect,  bool include_pass_events_objects,  bool include_hidden_objects) {
       var _in_rect = Eina.Rect_StructConversion.ToInternal(rect);
                                                      var _ret_var = efl_canvas_scene_objects_in_rectangle_get(Efl.Canvas.SceneConcrete.efl_canvas_scene_interface_get(),  _in_rect,  include_pass_events_objects,  include_hidden_objects);
      Eina.Error.RaiseIfUnhandledException();
                                          return new Eina.Iterator<Efl.Gfx.Entity>(_ret_var, true, false);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))] private static extern Efl.Gfx.Entity efl_canvas_scene_object_top_in_rectangle_get(System.IntPtr obj,   Eina.Rect_StructInternal rect,  [MarshalAs(UnmanagedType.U1)]  bool include_pass_events_objects,  [MarshalAs(UnmanagedType.U1)]  bool include_hidden_objects);
   /// <summary>Retrieve the Evas object stacked at the top of a given rectangular region in a canvas
   /// This function will traverse all the layers of the given canvas, from top to bottom, querying for objects with areas overlapping with the given rectangular region inside <c>e</c>. The user can remove from the query objects which are hidden and/or which are set to pass events.
   /// 
   /// Warning: This function will skip objects parented by smart objects, acting only on the ones at the &quot;top level&quot;, with regard to object parenting.</summary>
   /// <param name="rect">The rectangular region.</param>
   /// <param name="include_pass_events_objects">Boolean flag to include or not objects which pass events in this calculation.</param>
   /// <param name="include_hidden_objects">Boolean flag to include or not hidden objects in this calculation.</param>
   /// <returns>The object that is over all other objects at the given rectangular region.</returns>
   public Efl.Gfx.Entity GetObjectTopInRectangle( Eina.Rect rect,  bool include_pass_events_objects,  bool include_hidden_objects) {
       var _in_rect = Eina.Rect_StructConversion.ToInternal(rect);
                                                      var _ret_var = efl_canvas_scene_object_top_in_rectangle_get(Efl.Canvas.SceneConcrete.efl_canvas_scene_interface_get(),  _in_rect,  include_pass_events_objects,  include_hidden_objects);
      Eina.Error.RaiseIfUnhandledException();
                                          return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  System.IntPtr efl_canvas_scene_seats(System.IntPtr obj);
   /// <summary>Iterate over the input device seats.
   /// 1.20</summary>
   /// <returns>An iterator over the attached seats.</returns>
   public Eina.Iterator<Efl.Input.Device> Seats() {
       var _ret_var = efl_canvas_scene_seats(Efl.Canvas.SceneConcrete.efl_canvas_scene_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return new Eina.Iterator<Efl.Input.Device>(_ret_var, true, false);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  System.IntPtr efl_canvas_scene_pointer_iterate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool hover);
   /// <summary>Returns an iterator over the current known pointer positions.
   /// This is used to iterate over the current known multi-touch positions, including the first finger. Each pointer position is represented by an object of type <see cref="Efl.Input.Pointer"/>.
   /// 
   /// Each finger in a multi touch environment can then be identified by the <see cref="Efl.Input.Pointer.Tool"/> property. The order of the pointers in this iterator is not defined.
   /// 
   /// Note: If the input surface supports hovering input, some pointers may not be in a &quot;down&quot; state. To retrieve the list of such pointers, set the <c>hover</c> value to <c>true</c>. Remember though that most devices currently don&apos;t support this.</summary>
   /// <param name="hover"><c>false</c> by default, <c>true</c> means to include fingers that are currently hovering.</param>
   /// <returns>Iterator to pointer positions</returns>
   public Eina.Iterator<Efl.Input.Pointer> PointerIterate( bool hover) {
                         var _ret_var = efl_canvas_scene_pointer_iterate(Efl.Canvas.SceneConcrete.efl_canvas_scene_interface_get(),  hover);
      Eina.Error.RaiseIfUnhandledException();
                  return new Eina.Iterator<Efl.Input.Pointer>(_ret_var, false, false);
 }
   /// <summary>Get if the canvas is currently calculating smart objects.</summary>
   public bool SmartObjectsCalculating {
      get { return GetSmartObjectsCalculating(); }
   }
   /// <summary>This function returns the current known pointer coordinates
/// This function returns the current position of the main input pointer (mouse, pen, etc...).</summary>
   public Eina.Position2D PointerPosition {
      get { return GetPointerPosition(); }
   }
}
public class SceneConcreteNativeInherit : Efl.Eo.NativeClass{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_canvas_scene_image_max_size_get_static_delegate = new efl_canvas_scene_image_max_size_get_delegate(image_max_size_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_scene_image_max_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_scene_image_max_size_get_static_delegate)});
      efl_canvas_scene_smart_objects_calculating_get_static_delegate = new efl_canvas_scene_smart_objects_calculating_get_delegate(smart_objects_calculating_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_scene_smart_objects_calculating_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_scene_smart_objects_calculating_get_static_delegate)});
      efl_canvas_scene_device_get_static_delegate = new efl_canvas_scene_device_get_delegate(device_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_scene_device_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_scene_device_get_static_delegate)});
      efl_canvas_scene_seat_get_static_delegate = new efl_canvas_scene_seat_get_delegate(seat_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_scene_seat_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_scene_seat_get_static_delegate)});
      efl_canvas_scene_pointer_position_get_static_delegate = new efl_canvas_scene_pointer_position_get_delegate(pointer_position_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_scene_pointer_position_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_scene_pointer_position_get_static_delegate)});
      efl_canvas_scene_smart_objects_calculate_static_delegate = new efl_canvas_scene_smart_objects_calculate_delegate(smart_objects_calculate);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_scene_smart_objects_calculate"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_scene_smart_objects_calculate_static_delegate)});
      efl_canvas_scene_objects_at_xy_get_static_delegate = new efl_canvas_scene_objects_at_xy_get_delegate(objects_at_xy_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_scene_objects_at_xy_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_scene_objects_at_xy_get_static_delegate)});
      efl_canvas_scene_object_top_at_xy_get_static_delegate = new efl_canvas_scene_object_top_at_xy_get_delegate(object_top_at_xy_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_scene_object_top_at_xy_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_scene_object_top_at_xy_get_static_delegate)});
      efl_canvas_scene_objects_in_rectangle_get_static_delegate = new efl_canvas_scene_objects_in_rectangle_get_delegate(objects_in_rectangle_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_scene_objects_in_rectangle_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_scene_objects_in_rectangle_get_static_delegate)});
      efl_canvas_scene_object_top_in_rectangle_get_static_delegate = new efl_canvas_scene_object_top_in_rectangle_get_delegate(object_top_in_rectangle_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_scene_object_top_in_rectangle_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_scene_object_top_in_rectangle_get_static_delegate)});
      efl_canvas_scene_seats_static_delegate = new efl_canvas_scene_seats_delegate(seats);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_scene_seats"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_scene_seats_static_delegate)});
      efl_canvas_scene_pointer_iterate_static_delegate = new efl_canvas_scene_pointer_iterate_delegate(pointer_iterate);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_scene_pointer_iterate"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_scene_pointer_iterate_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Canvas.SceneConcrete.efl_canvas_scene_interface_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.Canvas.SceneConcrete.efl_canvas_scene_interface_get();
   }


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_canvas_scene_image_max_size_get_delegate(System.IntPtr obj, System.IntPtr pd,   out Eina.Size2D_StructInternal max);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_canvas_scene_image_max_size_get(System.IntPtr obj,   out Eina.Size2D_StructInternal max);
    private static bool image_max_size_get(System.IntPtr obj, System.IntPtr pd,  out Eina.Size2D_StructInternal max)
   {
      Eina.Log.Debug("function efl_canvas_scene_image_max_size_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                     Eina.Size2D _out_max = default(Eina.Size2D);
               bool _ret_var = default(bool);
         try {
            _ret_var = ((Scene)wrapper).GetImageMaxSize( out _out_max);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      max = Eina.Size2D_StructConversion.ToInternal(_out_max);
            return _ret_var;
      } else {
         return efl_canvas_scene_image_max_size_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out max);
      }
   }
   private efl_canvas_scene_image_max_size_get_delegate efl_canvas_scene_image_max_size_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_canvas_scene_smart_objects_calculating_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_canvas_scene_smart_objects_calculating_get(System.IntPtr obj);
    private static bool smart_objects_calculating_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_canvas_scene_smart_objects_calculating_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Scene)wrapper).GetSmartObjectsCalculating();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_canvas_scene_smart_objects_calculating_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_canvas_scene_smart_objects_calculating_get_delegate efl_canvas_scene_smart_objects_calculating_get_static_delegate;


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))] private delegate Efl.Input.Device efl_canvas_scene_device_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))] private static extern Efl.Input.Device efl_canvas_scene_device_get(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name);
    private static Efl.Input.Device device_get(System.IntPtr obj, System.IntPtr pd,   System.String name)
   {
      Eina.Log.Debug("function efl_canvas_scene_device_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    Efl.Input.Device _ret_var = default(Efl.Input.Device);
         try {
            _ret_var = ((Scene)wrapper).GetDevice( name);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_canvas_scene_device_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  name);
      }
   }
   private efl_canvas_scene_device_get_delegate efl_canvas_scene_device_get_static_delegate;


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))] private delegate Efl.Input.Device efl_canvas_scene_seat_get_delegate(System.IntPtr obj, System.IntPtr pd,    int id);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))] private static extern Efl.Input.Device efl_canvas_scene_seat_get(System.IntPtr obj,    int id);
    private static Efl.Input.Device seat_get(System.IntPtr obj, System.IntPtr pd,   int id)
   {
      Eina.Log.Debug("function efl_canvas_scene_seat_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    Efl.Input.Device _ret_var = default(Efl.Input.Device);
         try {
            _ret_var = ((Scene)wrapper).GetSeat( id);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_canvas_scene_seat_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  id);
      }
   }
   private efl_canvas_scene_seat_get_delegate efl_canvas_scene_seat_get_static_delegate;


    private delegate Eina.Position2D_StructInternal efl_canvas_scene_pointer_position_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Eina.Position2D_StructInternal efl_canvas_scene_pointer_position_get(System.IntPtr obj);
    private static Eina.Position2D_StructInternal pointer_position_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_canvas_scene_pointer_position_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Position2D _ret_var = default(Eina.Position2D);
         try {
            _ret_var = ((Scene)wrapper).GetPointerPosition();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Eina.Position2D_StructConversion.ToInternal(_ret_var);
      } else {
         return efl_canvas_scene_pointer_position_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_canvas_scene_pointer_position_get_delegate efl_canvas_scene_pointer_position_get_static_delegate;


    private delegate  void efl_canvas_scene_smart_objects_calculate_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_canvas_scene_smart_objects_calculate(System.IntPtr obj);
    private static  void smart_objects_calculate(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_canvas_scene_smart_objects_calculate was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Scene)wrapper).CalculateSmartObjects();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_canvas_scene_smart_objects_calculate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_canvas_scene_smart_objects_calculate_delegate efl_canvas_scene_smart_objects_calculate_static_delegate;


    private delegate  System.IntPtr efl_canvas_scene_objects_at_xy_get_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Position2D_StructInternal pos,  [MarshalAs(UnmanagedType.U1)]  bool include_pass_events_objects,  [MarshalAs(UnmanagedType.U1)]  bool include_hidden_objects);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  System.IntPtr efl_canvas_scene_objects_at_xy_get(System.IntPtr obj,   Eina.Position2D_StructInternal pos,  [MarshalAs(UnmanagedType.U1)]  bool include_pass_events_objects,  [MarshalAs(UnmanagedType.U1)]  bool include_hidden_objects);
    private static  System.IntPtr objects_at_xy_get(System.IntPtr obj, System.IntPtr pd,  Eina.Position2D_StructInternal pos,  bool include_pass_events_objects,  bool include_hidden_objects)
   {
      Eina.Log.Debug("function efl_canvas_scene_objects_at_xy_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_pos = Eina.Position2D_StructConversion.ToManaged(pos);
                                                         Eina.Iterator<Efl.Gfx.Entity> _ret_var = default(Eina.Iterator<Efl.Gfx.Entity>);
         try {
            _ret_var = ((Scene)wrapper).GetObjectsAtXy( _in_pos,  include_pass_events_objects,  include_hidden_objects);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                          _ret_var.Own = false; return _ret_var.Handle;
      } else {
         return efl_canvas_scene_objects_at_xy_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  pos,  include_pass_events_objects,  include_hidden_objects);
      }
   }
   private efl_canvas_scene_objects_at_xy_get_delegate efl_canvas_scene_objects_at_xy_get_static_delegate;


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.Gfx.Entity efl_canvas_scene_object_top_at_xy_get_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Position2D_StructInternal pos,  [MarshalAs(UnmanagedType.U1)]  bool include_pass_events_objects,  [MarshalAs(UnmanagedType.U1)]  bool include_hidden_objects);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))] private static extern Efl.Gfx.Entity efl_canvas_scene_object_top_at_xy_get(System.IntPtr obj,   Eina.Position2D_StructInternal pos,  [MarshalAs(UnmanagedType.U1)]  bool include_pass_events_objects,  [MarshalAs(UnmanagedType.U1)]  bool include_hidden_objects);
    private static Efl.Gfx.Entity object_top_at_xy_get(System.IntPtr obj, System.IntPtr pd,  Eina.Position2D_StructInternal pos,  bool include_pass_events_objects,  bool include_hidden_objects)
   {
      Eina.Log.Debug("function efl_canvas_scene_object_top_at_xy_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_pos = Eina.Position2D_StructConversion.ToManaged(pos);
                                                         Efl.Gfx.Entity _ret_var = default(Efl.Gfx.Entity);
         try {
            _ret_var = ((Scene)wrapper).GetObjectTopAtXy( _in_pos,  include_pass_events_objects,  include_hidden_objects);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                          return _ret_var;
      } else {
         return efl_canvas_scene_object_top_at_xy_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  pos,  include_pass_events_objects,  include_hidden_objects);
      }
   }
   private efl_canvas_scene_object_top_at_xy_get_delegate efl_canvas_scene_object_top_at_xy_get_static_delegate;


    private delegate  System.IntPtr efl_canvas_scene_objects_in_rectangle_get_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Rect_StructInternal rect,  [MarshalAs(UnmanagedType.U1)]  bool include_pass_events_objects,  [MarshalAs(UnmanagedType.U1)]  bool include_hidden_objects);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  System.IntPtr efl_canvas_scene_objects_in_rectangle_get(System.IntPtr obj,   Eina.Rect_StructInternal rect,  [MarshalAs(UnmanagedType.U1)]  bool include_pass_events_objects,  [MarshalAs(UnmanagedType.U1)]  bool include_hidden_objects);
    private static  System.IntPtr objects_in_rectangle_get(System.IntPtr obj, System.IntPtr pd,  Eina.Rect_StructInternal rect,  bool include_pass_events_objects,  bool include_hidden_objects)
   {
      Eina.Log.Debug("function efl_canvas_scene_objects_in_rectangle_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_rect = Eina.Rect_StructConversion.ToManaged(rect);
                                                         Eina.Iterator<Efl.Gfx.Entity> _ret_var = default(Eina.Iterator<Efl.Gfx.Entity>);
         try {
            _ret_var = ((Scene)wrapper).GetObjectsInRectangle( _in_rect,  include_pass_events_objects,  include_hidden_objects);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                          _ret_var.Own = false; return _ret_var.Handle;
      } else {
         return efl_canvas_scene_objects_in_rectangle_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  rect,  include_pass_events_objects,  include_hidden_objects);
      }
   }
   private efl_canvas_scene_objects_in_rectangle_get_delegate efl_canvas_scene_objects_in_rectangle_get_static_delegate;


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.Gfx.Entity efl_canvas_scene_object_top_in_rectangle_get_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Rect_StructInternal rect,  [MarshalAs(UnmanagedType.U1)]  bool include_pass_events_objects,  [MarshalAs(UnmanagedType.U1)]  bool include_hidden_objects);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))] private static extern Efl.Gfx.Entity efl_canvas_scene_object_top_in_rectangle_get(System.IntPtr obj,   Eina.Rect_StructInternal rect,  [MarshalAs(UnmanagedType.U1)]  bool include_pass_events_objects,  [MarshalAs(UnmanagedType.U1)]  bool include_hidden_objects);
    private static Efl.Gfx.Entity object_top_in_rectangle_get(System.IntPtr obj, System.IntPtr pd,  Eina.Rect_StructInternal rect,  bool include_pass_events_objects,  bool include_hidden_objects)
   {
      Eina.Log.Debug("function efl_canvas_scene_object_top_in_rectangle_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_rect = Eina.Rect_StructConversion.ToManaged(rect);
                                                         Efl.Gfx.Entity _ret_var = default(Efl.Gfx.Entity);
         try {
            _ret_var = ((Scene)wrapper).GetObjectTopInRectangle( _in_rect,  include_pass_events_objects,  include_hidden_objects);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                          return _ret_var;
      } else {
         return efl_canvas_scene_object_top_in_rectangle_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  rect,  include_pass_events_objects,  include_hidden_objects);
      }
   }
   private efl_canvas_scene_object_top_in_rectangle_get_delegate efl_canvas_scene_object_top_in_rectangle_get_static_delegate;


    private delegate  System.IntPtr efl_canvas_scene_seats_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  System.IntPtr efl_canvas_scene_seats(System.IntPtr obj);
    private static  System.IntPtr seats(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_canvas_scene_seats was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Iterator<Efl.Input.Device> _ret_var = default(Eina.Iterator<Efl.Input.Device>);
         try {
            _ret_var = ((Scene)wrapper).Seats();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      _ret_var.Own = false; return _ret_var.Handle;
      } else {
         return efl_canvas_scene_seats(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_canvas_scene_seats_delegate efl_canvas_scene_seats_static_delegate;


    private delegate  System.IntPtr efl_canvas_scene_pointer_iterate_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool hover);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  System.IntPtr efl_canvas_scene_pointer_iterate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool hover);
    private static  System.IntPtr pointer_iterate(System.IntPtr obj, System.IntPtr pd,  bool hover)
   {
      Eina.Log.Debug("function efl_canvas_scene_pointer_iterate was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    Eina.Iterator<Efl.Input.Pointer> _ret_var = default(Eina.Iterator<Efl.Input.Pointer>);
         try {
            _ret_var = ((Scene)wrapper).PointerIterate( hover);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var.Handle;
      } else {
         return efl_canvas_scene_pointer_iterate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  hover);
      }
   }
   private efl_canvas_scene_pointer_iterate_delegate efl_canvas_scene_pointer_iterate_static_delegate;
}
} } 
