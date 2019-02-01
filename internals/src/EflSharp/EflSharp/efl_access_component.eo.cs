#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Access { 
/// <summary>AT-SPI component mixin</summary>
[ComponentConcreteNativeInherit]
public interface Component : 
   Efl.Gfx.Entity ,
   Efl.Gfx.Stack ,
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>Gets the depth at which the component is shown in relation to other components in the same container.</summary>
/// <returns>Z order of component</returns>
 int GetZOrder();
   /// <summary>Geometry of accessible widget.</summary>
/// <param name="screen_coords">If <c>true</c> x and y values will be relative to screen origin, otherwise relative to canvas</param>
/// <returns>The geometry.</returns>
Eina.Rect GetExtents( bool screen_coords);
   /// <summary>Geometry of accessible widget.</summary>
/// <param name="screen_coords">If <c>true</c> x and y values will be relative to screen origin, otherwise relative to canvas</param>
/// <param name="rect">The geometry.</param>
/// <returns><c>true</c> if geometry was set, <c>false</c> otherwise</returns>
bool SetExtents( bool screen_coords,  Eina.Rect rect);
   /// <summary>Position of accessible widget.</summary>
/// <param name="x">X coordinate</param>
/// <param name="y">Y coordinate</param>
/// <returns></returns>
 void GetScreenPosition( out  int x,  out  int y);
   /// <summary>Position of accessible widget.</summary>
/// <param name="x">X coordinate</param>
/// <param name="y">Y coordinate</param>
/// <returns><c>true</c> if position was set, <c>false</c> otherwise</returns>
bool SetScreenPosition(  int x,   int y);
   /// <summary>Gets position of socket offset.</summary>
/// <param name="x"></param>
/// <param name="y"></param>
/// <returns></returns>
 void GetSocketOffset( out  int x,  out  int y);
   /// <summary>Sets position of socket offset.</summary>
/// <param name="x"></param>
/// <param name="y"></param>
/// <returns></returns>
 void SetSocketOffset(  int x,   int y);
   /// <summary>Contains accessible widget</summary>
/// <param name="screen_coords">If <c>true</c> x and y values will be relative to screen origin, otherwise relative to canvas</param>
/// <param name="x">X coordinate</param>
/// <param name="y">Y coordinate</param>
/// <returns><c>true</c> if params have been set, <c>false</c> otherwise</returns>
bool Contains( bool screen_coords,   int x,   int y);
   /// <summary>Focuses accessible widget.</summary>
/// <returns><c>true</c> if focus grab focus succeed, <c>false</c> otherwise.</returns>
bool GrabFocus();
   /// <summary>Gets top component object occupying space at given coordinates.</summary>
/// <param name="screen_coords">If <c>true</c> x and y values will be relative to screen origin, otherwise relative to canvas</param>
/// <param name="x">X coordinate</param>
/// <param name="y">Y coordinate</param>
/// <returns>Top component object at given coordinate</returns>
Efl.Object GetAccessibleAtPoint( bool screen_coords,   int x,   int y);
   /// <summary>Highlights accessible widget. returns true if highlight grab has successed, false otherwise.
/// @if MOBILE @since_tizen 4.0 @elseif WEARABLE @since_tizen 3.0 @endif</summary>
/// <returns></returns>
bool GrabHighlight();
   /// <summary>Clears highlight of accessible widget. returns true if clear has successed, false otherwise.
/// @if MOBILE @since_tizen 4.0 @elseif WEARABLE @since_tizen 3.0 @endif</summary>
/// <returns></returns>
bool ClearHighlight();
                                       /// <summary>Gets the depth at which the component is shown in relation to other components in the same container.</summary>
    int ZOrder {
      get ;
   }
}
/// <summary>AT-SPI component mixin</summary>
sealed public class ComponentConcrete : 

Component
   , Efl.Gfx.Entity, Efl.Gfx.Stack
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (ComponentConcrete))
            return Efl.Access.ComponentConcreteNativeInherit.GetEflClassStatic();
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
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
      efl_access_component_mixin_get();
   ///<summary>Constructs an instance from a native pointer.</summary>
   public ComponentConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~ComponentConcrete()
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
   public static ComponentConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new ComponentConcrete(obj.NativeHandle);
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

    void register_event_proxies()
   {
      evt_ShowEvt_delegate = new Efl.EventCb(on_ShowEvt_NativeCallback);
      evt_HideEvt_delegate = new Efl.EventCb(on_HideEvt_NativeCallback);
      evt_MoveEvt_delegate = new Efl.EventCb(on_MoveEvt_NativeCallback);
      evt_ResizeEvt_delegate = new Efl.EventCb(on_ResizeEvt_NativeCallback);
      evt_RestackEvt_delegate = new Efl.EventCb(on_RestackEvt_NativeCallback);
   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    private static extern  int efl_access_component_z_order_get(System.IntPtr obj);
   /// <summary>Gets the depth at which the component is shown in relation to other components in the same container.</summary>
   /// <returns>Z order of component</returns>
   public  int GetZOrder() {
       var _ret_var = efl_access_component_z_order_get(Efl.Access.ComponentConcrete.efl_access_component_mixin_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    private static extern Eina.Rect_StructInternal efl_access_component_extents_get(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool screen_coords);
   /// <summary>Geometry of accessible widget.</summary>
   /// <param name="screen_coords">If <c>true</c> x and y values will be relative to screen origin, otherwise relative to canvas</param>
   /// <returns>The geometry.</returns>
   public Eina.Rect GetExtents( bool screen_coords) {
                         var _ret_var = efl_access_component_extents_get(Efl.Access.ComponentConcrete.efl_access_component_mixin_get(),  screen_coords);
      Eina.Error.RaiseIfUnhandledException();
                  return Eina.Rect_StructConversion.ToManaged(_ret_var);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_access_component_extents_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool screen_coords,   Eina.Rect_StructInternal rect);
   /// <summary>Geometry of accessible widget.</summary>
   /// <param name="screen_coords">If <c>true</c> x and y values will be relative to screen origin, otherwise relative to canvas</param>
   /// <param name="rect">The geometry.</param>
   /// <returns><c>true</c> if geometry was set, <c>false</c> otherwise</returns>
   public bool SetExtents( bool screen_coords,  Eina.Rect rect) {
             var _in_rect = Eina.Rect_StructConversion.ToInternal(rect);
                              var _ret_var = efl_access_component_extents_set(Efl.Access.ComponentConcrete.efl_access_component_mixin_get(),  screen_coords,  _in_rect);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    private static extern  void efl_access_component_screen_position_get(System.IntPtr obj,   out  int x,   out  int y);
   /// <summary>Position of accessible widget.</summary>
   /// <param name="x">X coordinate</param>
   /// <param name="y">Y coordinate</param>
   /// <returns></returns>
   public  void GetScreenPosition( out  int x,  out  int y) {
                                           efl_access_component_screen_position_get(Efl.Access.ComponentConcrete.efl_access_component_mixin_get(),  out x,  out y);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_access_component_screen_position_set(System.IntPtr obj,    int x,    int y);
   /// <summary>Position of accessible widget.</summary>
   /// <param name="x">X coordinate</param>
   /// <param name="y">Y coordinate</param>
   /// <returns><c>true</c> if position was set, <c>false</c> otherwise</returns>
   public bool SetScreenPosition(  int x,   int y) {
                                           var _ret_var = efl_access_component_screen_position_set(Efl.Access.ComponentConcrete.efl_access_component_mixin_get(),  x,  y);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    private static extern  void efl_access_component_socket_offset_get(System.IntPtr obj,   out  int x,   out  int y);
   /// <summary>Gets position of socket offset.</summary>
   /// <param name="x"></param>
   /// <param name="y"></param>
   /// <returns></returns>
   public  void GetSocketOffset( out  int x,  out  int y) {
                                           efl_access_component_socket_offset_get(Efl.Access.ComponentConcrete.efl_access_component_mixin_get(),  out x,  out y);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    private static extern  void efl_access_component_socket_offset_set(System.IntPtr obj,    int x,    int y);
   /// <summary>Sets position of socket offset.</summary>
   /// <param name="x"></param>
   /// <param name="y"></param>
   /// <returns></returns>
   public  void SetSocketOffset(  int x,   int y) {
                                           efl_access_component_socket_offset_set(Efl.Access.ComponentConcrete.efl_access_component_mixin_get(),  x,  y);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_access_component_contains(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool screen_coords,    int x,    int y);
   /// <summary>Contains accessible widget</summary>
   /// <param name="screen_coords">If <c>true</c> x and y values will be relative to screen origin, otherwise relative to canvas</param>
   /// <param name="x">X coordinate</param>
   /// <param name="y">Y coordinate</param>
   /// <returns><c>true</c> if params have been set, <c>false</c> otherwise</returns>
   public bool Contains( bool screen_coords,   int x,   int y) {
                                                             var _ret_var = efl_access_component_contains(Efl.Access.ComponentConcrete.efl_access_component_mixin_get(),  screen_coords,  x,  y);
      Eina.Error.RaiseIfUnhandledException();
                                          return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_access_component_focus_grab(System.IntPtr obj);
   /// <summary>Focuses accessible widget.</summary>
   /// <returns><c>true</c> if focus grab focus succeed, <c>false</c> otherwise.</returns>
   public bool GrabFocus() {
       var _ret_var = efl_access_component_focus_grab(Efl.Access.ComponentConcrete.efl_access_component_mixin_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))] private static extern Efl.Object efl_access_component_accessible_at_point_get(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool screen_coords,    int x,    int y);
   /// <summary>Gets top component object occupying space at given coordinates.</summary>
   /// <param name="screen_coords">If <c>true</c> x and y values will be relative to screen origin, otherwise relative to canvas</param>
   /// <param name="x">X coordinate</param>
   /// <param name="y">Y coordinate</param>
   /// <returns>Top component object at given coordinate</returns>
   public Efl.Object GetAccessibleAtPoint( bool screen_coords,   int x,   int y) {
                                                             var _ret_var = efl_access_component_accessible_at_point_get(Efl.Access.ComponentConcrete.efl_access_component_mixin_get(),  screen_coords,  x,  y);
      Eina.Error.RaiseIfUnhandledException();
                                          return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_access_component_highlight_grab(System.IntPtr obj);
   /// <summary>Highlights accessible widget. returns true if highlight grab has successed, false otherwise.
   /// @if MOBILE @since_tizen 4.0 @elseif WEARABLE @since_tizen 3.0 @endif</summary>
   /// <returns></returns>
   public bool GrabHighlight() {
       var _ret_var = efl_access_component_highlight_grab(Efl.Access.ComponentConcrete.efl_access_component_mixin_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_access_component_highlight_clear(System.IntPtr obj);
   /// <summary>Clears highlight of accessible widget. returns true if clear has successed, false otherwise.
   /// @if MOBILE @since_tizen 4.0 @elseif WEARABLE @since_tizen 3.0 @endif</summary>
   /// <returns></returns>
   public bool ClearHighlight() {
       var _ret_var = efl_access_component_highlight_clear(Efl.Access.ComponentConcrete.efl_access_component_mixin_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern Eina.Position2D_StructInternal efl_gfx_entity_position_get(System.IntPtr obj);
   /// <summary>Retrieves the position of the given canvas object.</summary>
   /// <returns>A 2D coordinate in pixel units.</returns>
   public Eina.Position2D GetPosition() {
       var _ret_var = efl_gfx_entity_position_get(Efl.Gfx.EntityConcrete.efl_gfx_entity_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return Eina.Position2D_StructConversion.ToManaged(_ret_var);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_entity_position_set(System.IntPtr obj,   Eina.Position2D_StructInternal pos);
   /// <summary>Moves the given canvas object to the given location inside its canvas&apos; viewport. If unchanged this call may be entirely skipped, but if changed this will trigger move events, as well as potential pointer,in or pointer,out events.</summary>
   /// <param name="pos">A 2D coordinate in pixel units.</param>
   /// <returns></returns>
   public  void SetPosition( Eina.Position2D pos) {
       var _in_pos = Eina.Position2D_StructConversion.ToInternal(pos);
                  efl_gfx_entity_position_set(Efl.Gfx.EntityConcrete.efl_gfx_entity_interface_get(),  _in_pos);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern Eina.Size2D_StructInternal efl_gfx_entity_size_get(System.IntPtr obj);
   /// <summary>Retrieves the (rectangular) size of the given Evas object.</summary>
   /// <returns>A 2D size in pixel units.</returns>
   public Eina.Size2D GetSize() {
       var _ret_var = efl_gfx_entity_size_get(Efl.Gfx.EntityConcrete.efl_gfx_entity_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return Eina.Size2D_StructConversion.ToManaged(_ret_var);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_entity_size_set(System.IntPtr obj,   Eina.Size2D_StructInternal size);
   /// <summary>Changes the size of the given object.
   /// Note that setting the actual size of an object might be the job of its container, so this function might have no effect. Look at <see cref="Efl.Gfx.SizeHint"/> instead, when manipulating widgets.</summary>
   /// <param name="size">A 2D size in pixel units.</param>
   /// <returns></returns>
   public  void SetSize( Eina.Size2D size) {
       var _in_size = Eina.Size2D_StructConversion.ToInternal(size);
                  efl_gfx_entity_size_set(Efl.Gfx.EntityConcrete.efl_gfx_entity_interface_get(),  _in_size);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern Eina.Rect_StructInternal efl_gfx_entity_geometry_get(System.IntPtr obj);
   /// <summary>Rectangular geometry that combines both position and size.</summary>
   /// <returns>The X,Y position and W,H size, in pixels.</returns>
   public Eina.Rect GetGeometry() {
       var _ret_var = efl_gfx_entity_geometry_get(Efl.Gfx.EntityConcrete.efl_gfx_entity_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return Eina.Rect_StructConversion.ToManaged(_ret_var);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_entity_geometry_set(System.IntPtr obj,   Eina.Rect_StructInternal rect);
   /// <summary>Rectangular geometry that combines both position and size.</summary>
   /// <param name="rect">The X,Y position and W,H size, in pixels.</param>
   /// <returns></returns>
   public  void SetGeometry( Eina.Rect rect) {
       var _in_rect = Eina.Rect_StructConversion.ToInternal(rect);
                  efl_gfx_entity_geometry_set(Efl.Gfx.EntityConcrete.efl_gfx_entity_interface_get(),  _in_rect);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_gfx_entity_visible_get(System.IntPtr obj);
   /// <summary>Retrieves whether or not the given canvas object is visible.</summary>
   /// <returns><c>true</c> if to make the object visible, <c>false</c> otherwise</returns>
   public bool GetVisible() {
       var _ret_var = efl_gfx_entity_visible_get(Efl.Gfx.EntityConcrete.efl_gfx_entity_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_entity_visible_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool v);
   /// <summary>Shows or hides this object.</summary>
   /// <param name="v"><c>true</c> if to make the object visible, <c>false</c> otherwise</param>
   /// <returns></returns>
   public  void SetVisible( bool v) {
                         efl_gfx_entity_visible_set(Efl.Gfx.EntityConcrete.efl_gfx_entity_interface_get(),  v);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern double efl_gfx_entity_scale_get(System.IntPtr obj);
   /// <summary>Gets an object&apos;s scaling factor.</summary>
   /// <returns>The scaling factor (the default value is 0.0, meaning individual scaling is not set)</returns>
   public double GetScale() {
       var _ret_var = efl_gfx_entity_scale_get(Efl.Gfx.EntityConcrete.efl_gfx_entity_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_entity_scale_set(System.IntPtr obj,   double scale);
   /// <summary>Sets the scaling factor of an object.</summary>
   /// <param name="scale">The scaling factor (the default value is 0.0, meaning individual scaling is not set)</param>
   /// <returns></returns>
   public  void SetScale( double scale) {
                         efl_gfx_entity_scale_set(Efl.Gfx.EntityConcrete.efl_gfx_entity_interface_get(),  scale);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  short efl_gfx_stack_layer_get(System.IntPtr obj);
   /// <summary>Retrieves the layer of its canvas that the given object is part of.
   /// See also <see cref="Efl.Gfx.Stack.SetLayer"/></summary>
   /// <returns>The number of the layer to place the object on. Must be between #EFL_GFX_STACK_LAYER_MIN and #EFL_GFX_STACK_LAYER_MAX.</returns>
   public  short GetLayer() {
       var _ret_var = efl_gfx_stack_layer_get(Efl.Gfx.StackConcrete.efl_gfx_stack_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_stack_layer_set(System.IntPtr obj,    short l);
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
   public  void SetLayer(  short l) {
                         efl_gfx_stack_layer_set(Efl.Gfx.StackConcrete.efl_gfx_stack_interface_get(),  l);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.StackConcrete, Efl.Eo.NonOwnTag>))] private static extern Efl.Gfx.Stack efl_gfx_stack_below_get(System.IntPtr obj);
   /// <summary>Get the Evas object stacked right below <c>obj</c>
   /// This function will traverse layers in its search, if there are objects on layers below the one <c>obj</c> is placed at.
   /// 
   /// See also <see cref="Efl.Gfx.Stack.GetLayer"/>, <see cref="Efl.Gfx.Stack.SetLayer"/> and <see cref="Efl.Gfx.Stack.GetBelow"/></summary>
   /// <returns>The #Efl_Gfx_Stack directly below <c>obj</c>, if any, or <c>null</c>, if none</returns>
   public Efl.Gfx.Stack GetBelow() {
       var _ret_var = efl_gfx_stack_below_get(Efl.Gfx.StackConcrete.efl_gfx_stack_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.StackConcrete, Efl.Eo.NonOwnTag>))] private static extern Efl.Gfx.Stack efl_gfx_stack_above_get(System.IntPtr obj);
   /// <summary>Get the Evas object stacked right above <c>obj</c>
   /// This function will traverse layers in its search, if there are objects on layers above the one <c>obj</c> is placed at.
   /// 
   /// See also <see cref="Efl.Gfx.Stack.GetLayer"/>, <see cref="Efl.Gfx.Stack.SetLayer"/> and <see cref="Efl.Gfx.Stack.GetBelow"/></summary>
   /// <returns>The #Efl_Gfx_Stack directly below <c>obj</c>, if any, or <c>null</c>, if none</returns>
   public Efl.Gfx.Stack GetAbove() {
       var _ret_var = efl_gfx_stack_above_get(Efl.Gfx.StackConcrete.efl_gfx_stack_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_stack_below(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.StackConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Stack below);
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
   public  void StackBelow( Efl.Gfx.Stack below) {
                         efl_gfx_stack_below(Efl.Gfx.StackConcrete.efl_gfx_stack_interface_get(),  below);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_stack_raise(System.IntPtr obj);
   /// <summary>Raise <c>obj</c> to the top of its layer.
   /// <c>obj</c> will, then, be the highest one in the layer it belongs to. Object on other layers won&apos;t get touched.
   /// 
   /// See also <see cref="Efl.Gfx.Stack.StackAbove"/>, <see cref="Efl.Gfx.Stack.StackBelow"/> and <see cref="Efl.Gfx.Stack.Lower"/></summary>
   /// <returns></returns>
   public  void Raise() {
       efl_gfx_stack_raise(Efl.Gfx.StackConcrete.efl_gfx_stack_interface_get());
      Eina.Error.RaiseIfUnhandledException();
       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_stack_above(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.StackConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Stack above);
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
   public  void StackAbove( Efl.Gfx.Stack above) {
                         efl_gfx_stack_above(Efl.Gfx.StackConcrete.efl_gfx_stack_interface_get(),  above);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_stack_lower(System.IntPtr obj);
   /// <summary>Lower <c>obj</c> to the bottom of its layer.
   /// <c>obj</c> will, then, be the lowest one in the layer it belongs to. Objects on other layers won&apos;t get touched.
   /// 
   /// See also <see cref="Efl.Gfx.Stack.StackAbove"/>, <see cref="Efl.Gfx.Stack.StackBelow"/> and <see cref="Efl.Gfx.Stack.Raise"/></summary>
   /// <returns></returns>
   public  void Lower() {
       efl_gfx_stack_lower(Efl.Gfx.StackConcrete.efl_gfx_stack_interface_get());
      Eina.Error.RaiseIfUnhandledException();
       }
   /// <summary>Gets the depth at which the component is shown in relation to other components in the same container.</summary>
   public  int ZOrder {
      get { return GetZOrder(); }
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
}
public class ComponentConcreteNativeInherit : Efl.Eo.NativeClass{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_access_component_z_order_get_static_delegate = new efl_access_component_z_order_get_delegate(z_order_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_component_z_order_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_component_z_order_get_static_delegate)});
      efl_access_component_extents_get_static_delegate = new efl_access_component_extents_get_delegate(extents_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_component_extents_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_component_extents_get_static_delegate)});
      efl_access_component_extents_set_static_delegate = new efl_access_component_extents_set_delegate(extents_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_component_extents_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_component_extents_set_static_delegate)});
      efl_access_component_screen_position_get_static_delegate = new efl_access_component_screen_position_get_delegate(screen_position_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_component_screen_position_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_component_screen_position_get_static_delegate)});
      efl_access_component_screen_position_set_static_delegate = new efl_access_component_screen_position_set_delegate(screen_position_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_component_screen_position_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_component_screen_position_set_static_delegate)});
      efl_access_component_socket_offset_get_static_delegate = new efl_access_component_socket_offset_get_delegate(socket_offset_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_component_socket_offset_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_component_socket_offset_get_static_delegate)});
      efl_access_component_socket_offset_set_static_delegate = new efl_access_component_socket_offset_set_delegate(socket_offset_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_component_socket_offset_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_component_socket_offset_set_static_delegate)});
      efl_access_component_contains_static_delegate = new efl_access_component_contains_delegate(contains);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_component_contains"), func = Marshal.GetFunctionPointerForDelegate(efl_access_component_contains_static_delegate)});
      efl_access_component_focus_grab_static_delegate = new efl_access_component_focus_grab_delegate(focus_grab);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_component_focus_grab"), func = Marshal.GetFunctionPointerForDelegate(efl_access_component_focus_grab_static_delegate)});
      efl_access_component_accessible_at_point_get_static_delegate = new efl_access_component_accessible_at_point_get_delegate(accessible_at_point_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_component_accessible_at_point_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_component_accessible_at_point_get_static_delegate)});
      efl_access_component_highlight_grab_static_delegate = new efl_access_component_highlight_grab_delegate(highlight_grab);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_component_highlight_grab"), func = Marshal.GetFunctionPointerForDelegate(efl_access_component_highlight_grab_static_delegate)});
      efl_access_component_highlight_clear_static_delegate = new efl_access_component_highlight_clear_delegate(highlight_clear);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_component_highlight_clear"), func = Marshal.GetFunctionPointerForDelegate(efl_access_component_highlight_clear_static_delegate)});
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
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Access.ComponentConcrete.efl_access_component_mixin_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.Access.ComponentConcrete.efl_access_component_mixin_get();
   }


    private delegate  int efl_access_component_z_order_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  int efl_access_component_z_order_get(System.IntPtr obj);
    private static  int z_order_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_component_z_order_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   int _ret_var = default( int);
         try {
            _ret_var = ((ComponentConcrete)wrapper).GetZOrder();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_access_component_z_order_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_access_component_z_order_get_delegate efl_access_component_z_order_get_static_delegate;


    private delegate Eina.Rect_StructInternal efl_access_component_extents_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool screen_coords);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern Eina.Rect_StructInternal efl_access_component_extents_get(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool screen_coords);
    private static Eina.Rect_StructInternal extents_get(System.IntPtr obj, System.IntPtr pd,  bool screen_coords)
   {
      Eina.Log.Debug("function efl_access_component_extents_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    Eina.Rect _ret_var = default(Eina.Rect);
         try {
            _ret_var = ((ComponentConcrete)wrapper).GetExtents( screen_coords);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return Eina.Rect_StructConversion.ToInternal(_ret_var);
      } else {
         return efl_access_component_extents_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  screen_coords);
      }
   }
   private efl_access_component_extents_get_delegate efl_access_component_extents_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_access_component_extents_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool screen_coords,   Eina.Rect_StructInternal rect);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_access_component_extents_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool screen_coords,   Eina.Rect_StructInternal rect);
    private static bool extents_set(System.IntPtr obj, System.IntPtr pd,  bool screen_coords,  Eina.Rect_StructInternal rect)
   {
      Eina.Log.Debug("function efl_access_component_extents_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                     var _in_rect = Eina.Rect_StructConversion.ToManaged(rect);
                                 bool _ret_var = default(bool);
         try {
            _ret_var = ((ComponentConcrete)wrapper).SetExtents( screen_coords,  _in_rect);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_access_component_extents_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  screen_coords,  rect);
      }
   }
   private efl_access_component_extents_set_delegate efl_access_component_extents_set_static_delegate;


    private delegate  void efl_access_component_screen_position_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  int x,   out  int y);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_access_component_screen_position_get(System.IntPtr obj,   out  int x,   out  int y);
    private static  void screen_position_get(System.IntPtr obj, System.IntPtr pd,  out  int x,  out  int y)
   {
      Eina.Log.Debug("function efl_access_component_screen_position_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           x = default( int);      y = default( int);                     
         try {
            ((ComponentConcrete)wrapper).GetScreenPosition( out x,  out y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_access_component_screen_position_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out x,  out y);
      }
   }
   private efl_access_component_screen_position_get_delegate efl_access_component_screen_position_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_access_component_screen_position_set_delegate(System.IntPtr obj, System.IntPtr pd,    int x,    int y);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_access_component_screen_position_set(System.IntPtr obj,    int x,    int y);
    private static bool screen_position_set(System.IntPtr obj, System.IntPtr pd,   int x,   int y)
   {
      Eina.Log.Debug("function efl_access_component_screen_position_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      bool _ret_var = default(bool);
         try {
            _ret_var = ((ComponentConcrete)wrapper).SetScreenPosition( x,  y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_access_component_screen_position_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  x,  y);
      }
   }
   private efl_access_component_screen_position_set_delegate efl_access_component_screen_position_set_static_delegate;


    private delegate  void efl_access_component_socket_offset_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  int x,   out  int y);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_access_component_socket_offset_get(System.IntPtr obj,   out  int x,   out  int y);
    private static  void socket_offset_get(System.IntPtr obj, System.IntPtr pd,  out  int x,  out  int y)
   {
      Eina.Log.Debug("function efl_access_component_socket_offset_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           x = default( int);      y = default( int);                     
         try {
            ((ComponentConcrete)wrapper).GetSocketOffset( out x,  out y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_access_component_socket_offset_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out x,  out y);
      }
   }
   private efl_access_component_socket_offset_get_delegate efl_access_component_socket_offset_get_static_delegate;


    private delegate  void efl_access_component_socket_offset_set_delegate(System.IntPtr obj, System.IntPtr pd,    int x,    int y);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_access_component_socket_offset_set(System.IntPtr obj,    int x,    int y);
    private static  void socket_offset_set(System.IntPtr obj, System.IntPtr pd,   int x,   int y)
   {
      Eina.Log.Debug("function efl_access_component_socket_offset_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((ComponentConcrete)wrapper).SetSocketOffset( x,  y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_access_component_socket_offset_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  x,  y);
      }
   }
   private efl_access_component_socket_offset_set_delegate efl_access_component_socket_offset_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_access_component_contains_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool screen_coords,    int x,    int y);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_access_component_contains(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool screen_coords,    int x,    int y);
    private static bool contains(System.IntPtr obj, System.IntPtr pd,  bool screen_coords,   int x,   int y)
   {
      Eina.Log.Debug("function efl_access_component_contains was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                        bool _ret_var = default(bool);
         try {
            _ret_var = ((ComponentConcrete)wrapper).Contains( screen_coords,  x,  y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                          return _ret_var;
      } else {
         return efl_access_component_contains(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  screen_coords,  x,  y);
      }
   }
   private efl_access_component_contains_delegate efl_access_component_contains_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_access_component_focus_grab_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_access_component_focus_grab(System.IntPtr obj);
    private static bool focus_grab(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_component_focus_grab was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((ComponentConcrete)wrapper).GrabFocus();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_access_component_focus_grab(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_access_component_focus_grab_delegate efl_access_component_focus_grab_static_delegate;


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))] private delegate Efl.Object efl_access_component_accessible_at_point_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool screen_coords,    int x,    int y);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))] private static extern Efl.Object efl_access_component_accessible_at_point_get(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool screen_coords,    int x,    int y);
    private static Efl.Object accessible_at_point_get(System.IntPtr obj, System.IntPtr pd,  bool screen_coords,   int x,   int y)
   {
      Eina.Log.Debug("function efl_access_component_accessible_at_point_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                        Efl.Object _ret_var = default(Efl.Object);
         try {
            _ret_var = ((ComponentConcrete)wrapper).GetAccessibleAtPoint( screen_coords,  x,  y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                          return _ret_var;
      } else {
         return efl_access_component_accessible_at_point_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  screen_coords,  x,  y);
      }
   }
   private efl_access_component_accessible_at_point_get_delegate efl_access_component_accessible_at_point_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_access_component_highlight_grab_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_access_component_highlight_grab(System.IntPtr obj);
    private static bool highlight_grab(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_component_highlight_grab was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((ComponentConcrete)wrapper).GrabHighlight();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_access_component_highlight_grab(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_access_component_highlight_grab_delegate efl_access_component_highlight_grab_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_access_component_highlight_clear_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_access_component_highlight_clear(System.IntPtr obj);
    private static bool highlight_clear(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_component_highlight_clear was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((ComponentConcrete)wrapper).ClearHighlight();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_access_component_highlight_clear(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_access_component_highlight_clear_delegate efl_access_component_highlight_clear_static_delegate;


    private delegate Eina.Position2D_StructInternal efl_gfx_entity_position_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Eina.Position2D_StructInternal efl_gfx_entity_position_get(System.IntPtr obj);
    private static Eina.Position2D_StructInternal position_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_entity_position_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Position2D _ret_var = default(Eina.Position2D);
         try {
            _ret_var = ((ComponentConcrete)wrapper).GetPosition();
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
            ((ComponentConcrete)wrapper).SetPosition( _in_pos);
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
            _ret_var = ((ComponentConcrete)wrapper).GetSize();
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
            ((ComponentConcrete)wrapper).SetSize( _in_size);
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
            _ret_var = ((ComponentConcrete)wrapper).GetGeometry();
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
            ((ComponentConcrete)wrapper).SetGeometry( _in_rect);
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
            _ret_var = ((ComponentConcrete)wrapper).GetVisible();
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
            ((ComponentConcrete)wrapper).SetVisible( v);
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
            _ret_var = ((ComponentConcrete)wrapper).GetScale();
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
            ((ComponentConcrete)wrapper).SetScale( scale);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_entity_scale_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  scale);
      }
   }
   private efl_gfx_entity_scale_set_delegate efl_gfx_entity_scale_set_static_delegate;


    private delegate  short efl_gfx_stack_layer_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  short efl_gfx_stack_layer_get(System.IntPtr obj);
    private static  short layer_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_stack_layer_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   short _ret_var = default( short);
         try {
            _ret_var = ((ComponentConcrete)wrapper).GetLayer();
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
            ((ComponentConcrete)wrapper).SetLayer( l);
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
            _ret_var = ((ComponentConcrete)wrapper).GetBelow();
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
            _ret_var = ((ComponentConcrete)wrapper).GetAbove();
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
            ((ComponentConcrete)wrapper).StackBelow( below);
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
            ((ComponentConcrete)wrapper).Raise();
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
            ((ComponentConcrete)wrapper).StackAbove( above);
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
            ((ComponentConcrete)wrapper).Lower();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_gfx_stack_lower(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_stack_lower_delegate efl_gfx_stack_lower_static_delegate;
}
} } 
