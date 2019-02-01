#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary>Efl UI zoom interface</summary>
[ZoomConcreteNativeInherit]
public interface Zoom : 
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>Disable zoom animation
/// This gets the current zoom animation state for the zoomable object.</summary>
/// <returns>The pause state.</returns>
bool GetZoomAnimation();
   /// <summary>Enable zoom animation
/// This sets the zoom animation state to on or off for zoomable. The default is off. This will stop zooming using animation on zoom level changes and change instantly. This will stop any existing animations that are running.</summary>
/// <param name="paused">The pause state.</param>
/// <returns></returns>
 void SetZoomAnimation( bool paused);
   /// <summary>Get the zoom level of the photo
/// This returns the current zoom level of the zoomable object. Note that if you set the fill mode to other than #EFL_UI_ZOOM_MODE_MANUAL (which is the default), the zoom level may be changed at any time by the  zoomable object itself to account for photo size and zoomable viewport size.</summary>
/// <returns>The zoom level to set</returns>
double GetZoomLevel();
   /// <summary>Set the zoom level of the photo
/// This sets the zoom level. If <c>zoom</c> is 1, it means no zoom. If it&apos;s smaller than 1, it means zoom in. If it&apos;s bigger than 1, it means zoom out. For  example, <c>zoom</c> 1 will be 1:1 pixel for pixel. <c>zoom</c> 2 will be 2:1 (that is 2x2 photo pixels will display as 1 on-screen pixel) which is a zoom out. 4:1 will be 4x4 photo pixels as 1 screen pixel, and so on. The <c>zoom</c> parameter must be greater than 0. It is suggested to stick to powers of 2. (1, 2, 4, 8, 16, 32, etc.).</summary>
/// <param name="zoom">The zoom level to set</param>
/// <returns></returns>
 void SetZoomLevel( double zoom);
   /// <summary>Get the zoom mode
/// This gets the current zoom mode of the zoomable object.</summary>
/// <returns>The zoom mode.</returns>
Efl.Ui.ZoomMode GetZoomMode();
   /// <summary>Set the zoom mode
/// This sets the zoom mode to manual or one of several automatic levels. Manual (EFL_UI_ZOOM_MODE_MANUAL) means that zoom is set manually by <see cref="Efl.Ui.Zoom.SetZoomLevel"/> and will stay at that level until changed by code or until zoom mode is changed. This is the default mode. The Automatic modes will allow the zoomable object to automatically adjust zoom mode based on properties.
/// 
/// #EFL_UI_ZOOM_MODE_AUTO_FIT) will adjust zoom so the photo fits EXACTLY inside the scroll frame with no pixels outside this region. #EFL_UI_ZOOM_MODE_AUTO_FILL will be similar but ensure no pixels within the frame are left unfilled.</summary>
/// <param name="mode">The zoom mode.</param>
/// <returns></returns>
 void SetZoomMode( Efl.Ui.ZoomMode mode);
                     /// <summary>Called when zooming started</summary>
   event EventHandler ZoomStartEvt;
   /// <summary>Called when zooming stopped</summary>
   event EventHandler ZoomStopEvt;
   /// <summary>Called when zooming changed</summary>
   event EventHandler ZoomChangeEvt;
   /// <summary>Disable zoom animation
/// This gets the current zoom animation state for the zoomable object.</summary>
   bool ZoomAnimation {
      get ;
      set ;
   }
   /// <summary>Get the zoom level of the photo
/// This returns the current zoom level of the zoomable object. Note that if you set the fill mode to other than #EFL_UI_ZOOM_MODE_MANUAL (which is the default), the zoom level may be changed at any time by the  zoomable object itself to account for photo size and zoomable viewport size.</summary>
   double ZoomLevel {
      get ;
      set ;
   }
   /// <summary>Get the zoom mode
/// This gets the current zoom mode of the zoomable object.</summary>
   Efl.Ui.ZoomMode ZoomMode {
      get ;
      set ;
   }
}
/// <summary>Efl UI zoom interface</summary>
sealed public class ZoomConcrete : 

Zoom
   
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (ZoomConcrete))
            return Efl.Ui.ZoomConcreteNativeInherit.GetEflClassStatic();
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
      efl_ui_zoom_interface_get();
   ///<summary>Constructs an instance from a native pointer.</summary>
   public ZoomConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~ZoomConcrete()
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
   public static ZoomConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new ZoomConcrete(obj.NativeHandle);
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
private static object ZoomStartEvtKey = new object();
   /// <summary>Called when zooming started</summary>
   public event EventHandler ZoomStartEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_ZOOM_START";
            if (add_cpp_event_handler(key, this.evt_ZoomStartEvt_delegate)) {
               eventHandlers.AddHandler(ZoomStartEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_ZOOM_START";
            if (remove_cpp_event_handler(key, this.evt_ZoomStartEvt_delegate)) { 
               eventHandlers.RemoveHandler(ZoomStartEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ZoomStartEvt.</summary>
   public void On_ZoomStartEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[ZoomStartEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ZoomStartEvt_delegate;
   private void on_ZoomStartEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_ZoomStartEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object ZoomStopEvtKey = new object();
   /// <summary>Called when zooming stopped</summary>
   public event EventHandler ZoomStopEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_ZOOM_STOP";
            if (add_cpp_event_handler(key, this.evt_ZoomStopEvt_delegate)) {
               eventHandlers.AddHandler(ZoomStopEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_ZOOM_STOP";
            if (remove_cpp_event_handler(key, this.evt_ZoomStopEvt_delegate)) { 
               eventHandlers.RemoveHandler(ZoomStopEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ZoomStopEvt.</summary>
   public void On_ZoomStopEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[ZoomStopEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ZoomStopEvt_delegate;
   private void on_ZoomStopEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_ZoomStopEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object ZoomChangeEvtKey = new object();
   /// <summary>Called when zooming changed</summary>
   public event EventHandler ZoomChangeEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_ZOOM_CHANGE";
            if (add_cpp_event_handler(key, this.evt_ZoomChangeEvt_delegate)) {
               eventHandlers.AddHandler(ZoomChangeEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_ZOOM_CHANGE";
            if (remove_cpp_event_handler(key, this.evt_ZoomChangeEvt_delegate)) { 
               eventHandlers.RemoveHandler(ZoomChangeEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ZoomChangeEvt.</summary>
   public void On_ZoomChangeEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[ZoomChangeEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ZoomChangeEvt_delegate;
   private void on_ZoomChangeEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_ZoomChangeEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

    void register_event_proxies()
   {
      evt_ZoomStartEvt_delegate = new Efl.EventCb(on_ZoomStartEvt_NativeCallback);
      evt_ZoomStopEvt_delegate = new Efl.EventCb(on_ZoomStopEvt_NativeCallback);
      evt_ZoomChangeEvt_delegate = new Efl.EventCb(on_ZoomChangeEvt_NativeCallback);
   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_zoom_animation_get(System.IntPtr obj);
   /// <summary>Disable zoom animation
   /// This gets the current zoom animation state for the zoomable object.</summary>
   /// <returns>The pause state.</returns>
   public bool GetZoomAnimation() {
       var _ret_var = efl_ui_zoom_animation_get(Efl.Ui.ZoomConcrete.efl_ui_zoom_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_ui_zoom_animation_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool paused);
   /// <summary>Enable zoom animation
   /// This sets the zoom animation state to on or off for zoomable. The default is off. This will stop zooming using animation on zoom level changes and change instantly. This will stop any existing animations that are running.</summary>
   /// <param name="paused">The pause state.</param>
   /// <returns></returns>
   public  void SetZoomAnimation( bool paused) {
                         efl_ui_zoom_animation_set(Efl.Ui.ZoomConcrete.efl_ui_zoom_interface_get(),  paused);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern double efl_ui_zoom_level_get(System.IntPtr obj);
   /// <summary>Get the zoom level of the photo
   /// This returns the current zoom level of the zoomable object. Note that if you set the fill mode to other than #EFL_UI_ZOOM_MODE_MANUAL (which is the default), the zoom level may be changed at any time by the  zoomable object itself to account for photo size and zoomable viewport size.</summary>
   /// <returns>The zoom level to set</returns>
   public double GetZoomLevel() {
       var _ret_var = efl_ui_zoom_level_get(Efl.Ui.ZoomConcrete.efl_ui_zoom_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_ui_zoom_level_set(System.IntPtr obj,   double zoom);
   /// <summary>Set the zoom level of the photo
   /// This sets the zoom level. If <c>zoom</c> is 1, it means no zoom. If it&apos;s smaller than 1, it means zoom in. If it&apos;s bigger than 1, it means zoom out. For  example, <c>zoom</c> 1 will be 1:1 pixel for pixel. <c>zoom</c> 2 will be 2:1 (that is 2x2 photo pixels will display as 1 on-screen pixel) which is a zoom out. 4:1 will be 4x4 photo pixels as 1 screen pixel, and so on. The <c>zoom</c> parameter must be greater than 0. It is suggested to stick to powers of 2. (1, 2, 4, 8, 16, 32, etc.).</summary>
   /// <param name="zoom">The zoom level to set</param>
   /// <returns></returns>
   public  void SetZoomLevel( double zoom) {
                         efl_ui_zoom_level_set(Efl.Ui.ZoomConcrete.efl_ui_zoom_interface_get(),  zoom);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern Efl.Ui.ZoomMode efl_ui_zoom_mode_get(System.IntPtr obj);
   /// <summary>Get the zoom mode
   /// This gets the current zoom mode of the zoomable object.</summary>
   /// <returns>The zoom mode.</returns>
   public Efl.Ui.ZoomMode GetZoomMode() {
       var _ret_var = efl_ui_zoom_mode_get(Efl.Ui.ZoomConcrete.efl_ui_zoom_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_ui_zoom_mode_set(System.IntPtr obj,   Efl.Ui.ZoomMode mode);
   /// <summary>Set the zoom mode
   /// This sets the zoom mode to manual or one of several automatic levels. Manual (EFL_UI_ZOOM_MODE_MANUAL) means that zoom is set manually by <see cref="Efl.Ui.Zoom.SetZoomLevel"/> and will stay at that level until changed by code or until zoom mode is changed. This is the default mode. The Automatic modes will allow the zoomable object to automatically adjust zoom mode based on properties.
   /// 
   /// #EFL_UI_ZOOM_MODE_AUTO_FIT) will adjust zoom so the photo fits EXACTLY inside the scroll frame with no pixels outside this region. #EFL_UI_ZOOM_MODE_AUTO_FILL will be similar but ensure no pixels within the frame are left unfilled.</summary>
   /// <param name="mode">The zoom mode.</param>
   /// <returns></returns>
   public  void SetZoomMode( Efl.Ui.ZoomMode mode) {
                         efl_ui_zoom_mode_set(Efl.Ui.ZoomConcrete.efl_ui_zoom_interface_get(),  mode);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Disable zoom animation
/// This gets the current zoom animation state for the zoomable object.</summary>
   public bool ZoomAnimation {
      get { return GetZoomAnimation(); }
      set { SetZoomAnimation( value); }
   }
   /// <summary>Get the zoom level of the photo
/// This returns the current zoom level of the zoomable object. Note that if you set the fill mode to other than #EFL_UI_ZOOM_MODE_MANUAL (which is the default), the zoom level may be changed at any time by the  zoomable object itself to account for photo size and zoomable viewport size.</summary>
   public double ZoomLevel {
      get { return GetZoomLevel(); }
      set { SetZoomLevel( value); }
   }
   /// <summary>Get the zoom mode
/// This gets the current zoom mode of the zoomable object.</summary>
   public Efl.Ui.ZoomMode ZoomMode {
      get { return GetZoomMode(); }
      set { SetZoomMode( value); }
   }
}
public class ZoomConcreteNativeInherit : Efl.Eo.NativeClass{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_ui_zoom_animation_get_static_delegate = new efl_ui_zoom_animation_get_delegate(zoom_animation_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_zoom_animation_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_zoom_animation_get_static_delegate)});
      efl_ui_zoom_animation_set_static_delegate = new efl_ui_zoom_animation_set_delegate(zoom_animation_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_zoom_animation_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_zoom_animation_set_static_delegate)});
      efl_ui_zoom_level_get_static_delegate = new efl_ui_zoom_level_get_delegate(zoom_level_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_zoom_level_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_zoom_level_get_static_delegate)});
      efl_ui_zoom_level_set_static_delegate = new efl_ui_zoom_level_set_delegate(zoom_level_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_zoom_level_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_zoom_level_set_static_delegate)});
      efl_ui_zoom_mode_get_static_delegate = new efl_ui_zoom_mode_get_delegate(zoom_mode_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_zoom_mode_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_zoom_mode_get_static_delegate)});
      efl_ui_zoom_mode_set_static_delegate = new efl_ui_zoom_mode_set_delegate(zoom_mode_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_zoom_mode_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_zoom_mode_set_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Ui.ZoomConcrete.efl_ui_zoom_interface_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.ZoomConcrete.efl_ui_zoom_interface_get();
   }


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_zoom_animation_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_zoom_animation_get(System.IntPtr obj);
    private static bool zoom_animation_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_zoom_animation_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Zoom)wrapper).GetZoomAnimation();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_zoom_animation_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_zoom_animation_get_delegate efl_ui_zoom_animation_get_static_delegate;


    private delegate  void efl_ui_zoom_animation_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool paused);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_ui_zoom_animation_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool paused);
    private static  void zoom_animation_set(System.IntPtr obj, System.IntPtr pd,  bool paused)
   {
      Eina.Log.Debug("function efl_ui_zoom_animation_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Zoom)wrapper).SetZoomAnimation( paused);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_zoom_animation_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  paused);
      }
   }
   private efl_ui_zoom_animation_set_delegate efl_ui_zoom_animation_set_static_delegate;


    private delegate double efl_ui_zoom_level_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern double efl_ui_zoom_level_get(System.IntPtr obj);
    private static double zoom_level_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_zoom_level_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  double _ret_var = default(double);
         try {
            _ret_var = ((Zoom)wrapper).GetZoomLevel();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_zoom_level_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_zoom_level_get_delegate efl_ui_zoom_level_get_static_delegate;


    private delegate  void efl_ui_zoom_level_set_delegate(System.IntPtr obj, System.IntPtr pd,   double zoom);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_ui_zoom_level_set(System.IntPtr obj,   double zoom);
    private static  void zoom_level_set(System.IntPtr obj, System.IntPtr pd,  double zoom)
   {
      Eina.Log.Debug("function efl_ui_zoom_level_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Zoom)wrapper).SetZoomLevel( zoom);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_zoom_level_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  zoom);
      }
   }
   private efl_ui_zoom_level_set_delegate efl_ui_zoom_level_set_static_delegate;


    private delegate Efl.Ui.ZoomMode efl_ui_zoom_mode_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Efl.Ui.ZoomMode efl_ui_zoom_mode_get(System.IntPtr obj);
    private static Efl.Ui.ZoomMode zoom_mode_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_zoom_mode_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Ui.ZoomMode _ret_var = default(Efl.Ui.ZoomMode);
         try {
            _ret_var = ((Zoom)wrapper).GetZoomMode();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_zoom_mode_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_zoom_mode_get_delegate efl_ui_zoom_mode_get_static_delegate;


    private delegate  void efl_ui_zoom_mode_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.ZoomMode mode);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_ui_zoom_mode_set(System.IntPtr obj,   Efl.Ui.ZoomMode mode);
    private static  void zoom_mode_set(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.ZoomMode mode)
   {
      Eina.Log.Debug("function efl_ui_zoom_mode_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Zoom)wrapper).SetZoomMode( mode);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_zoom_mode_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  mode);
      }
   }
   private efl_ui_zoom_mode_set_delegate efl_ui_zoom_mode_set_static_delegate;
}
} } 
namespace Efl { namespace Ui { 
/// <summary>Types of zoom available.</summary>
public enum ZoomMode
{
/// <summary>Zoom controlled normally by efl_ui_zoom_set</summary>
Manual = 0,
/// <summary>Zoom until photo fits in zoomable object</summary>
AutoFit = 1,
/// <summary>Zoom until photo fills zoomable object</summary>
AutoFill = 2,
/// <summary>Zoom in until photo fits in zoomable object</summary>
AutoFitIn = 3,
/// <summary>Sentinel value to indicate last enum field during iteration</summary>
Last = 4,
}
} } 
