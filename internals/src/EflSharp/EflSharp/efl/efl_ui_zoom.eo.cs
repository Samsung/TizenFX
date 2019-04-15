#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary>Efl UI zoom interface</summary>
[IZoomNativeInherit]
public interface IZoom : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>This sets the zoom animation state to on or off for zoomable. The default is off. When <c>paused</c> is <c>true</c>, it will stop zooming using animation on zoom level changes and change instantly, stopping any existing animations that are running.</summary>
/// <returns>The paused state.</returns>
bool GetZoomAnimation();
    /// <summary>This sets the zoom animation state to on or off for zoomable. The default is off. When <c>paused</c> is <c>true</c>, it will stop zooming using animation on zoom level changes and change instantly, stopping any existing animations that are running.</summary>
/// <param name="paused">The paused state.</param>
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
/// This sets the zoom mode to manual or one of several automatic levels. Manual (EFL_UI_ZOOM_MODE_MANUAL) means that zoom is set manually by <see cref="Efl.Ui.IZoom.SetZoomLevel"/> and will stay at that level until changed by code or until zoom mode is changed. This is the default mode. The Automatic modes will allow the zoomable object to automatically adjust zoom mode based on properties.
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
    /// <summary>This sets the zoom animation state to on or off for zoomable. The default is off. When <c>paused</c> is <c>true</c>, it will stop zooming using animation on zoom level changes and change instantly, stopping any existing animations that are running.</summary>
/// <value>The paused state.</value>
    bool ZoomAnimation {
        get ;
        set ;
    }
    /// <summary>Get the zoom level of the photo
/// This returns the current zoom level of the zoomable object. Note that if you set the fill mode to other than #EFL_UI_ZOOM_MODE_MANUAL (which is the default), the zoom level may be changed at any time by the  zoomable object itself to account for photo size and zoomable viewport size.</summary>
/// <value>The zoom level to set</value>
    double ZoomLevel {
        get ;
        set ;
    }
    /// <summary>Get the zoom mode
/// This gets the current zoom mode of the zoomable object.</summary>
/// <value>The zoom mode.</value>
    Efl.Ui.ZoomMode ZoomMode {
        get ;
        set ;
    }
}
/// <summary>Efl UI zoom interface</summary>
sealed public class IZoomConcrete : 

IZoom
    
{
    ///<summary>Pointer to the native class description.</summary>
    public System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (IZoomConcrete))
                return Efl.Ui.IZoomNativeInherit.GetEflClassStatic();
            else
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
        }
    }
    private EventHandlerList eventHandlers = new EventHandlerList();
    private  System.IntPtr handle;
    ///<summary>Pointer to the native instance.</summary>
    public System.IntPtr NativeHandle {
        get { return handle; }
    }
    [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] internal static extern System.IntPtr
        efl_ui_zoom_interface_get();
    ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    private IZoomConcrete(System.IntPtr raw)
    {
        handle = raw;
        RegisterEventProxies();
    }
    ///<summary>Destructor.</summary>
    ~IZoomConcrete()
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
        Dispose(true);
        GC.SuppressFinalize(this);
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
    ///<summary>Adds a new event handler, registering it to the native event. For internal use only.</summary>
    ///<param name="lib">The name of the native library definining the event.</param>
    ///<param name="key">The name of the native event.</param>
    ///<param name="evt_delegate">The delegate to be called on event raising.</param>
    ///<returns>True if the delegate was successfully registered.</returns>
    private bool AddNativeEventHandler(string lib, string key, Efl.EventCb evt_delegate) {
        int event_count = 0;
        if (!event_cb_count.TryGetValue(key, out event_count))
            event_cb_count[key] = event_count;
        if (event_count == 0) {
            IntPtr desc = Efl.EventDescription.GetNative(lib, key);
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
    ///<summary>Removes the given event handler for the given event. For internal use only.</summary>
    ///<param name="key">The name of the native event.</param>
    ///<param name="evt_delegate">The delegate to be removed.</param>
    ///<returns>True if the delegate was successfully registered.</returns>
    private bool RemoveNativeEventHandler(string key, Efl.EventCb evt_delegate) {
        int event_count = 0;
        if (!event_cb_count.TryGetValue(key, out event_count))
            event_cb_count[key] = event_count;
        if (event_count == 1) {
            IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
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
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_ZoomStartEvt_delegate)) {
                    eventHandlers.AddHandler(ZoomStartEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_ZOOM_START";
                if (RemoveNativeEventHandler(key, this.evt_ZoomStartEvt_delegate)) { 
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
    private void on_ZoomStartEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
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
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_ZoomStopEvt_delegate)) {
                    eventHandlers.AddHandler(ZoomStopEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_ZOOM_STOP";
                if (RemoveNativeEventHandler(key, this.evt_ZoomStopEvt_delegate)) { 
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
    private void on_ZoomStopEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
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
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_ZoomChangeEvt_delegate)) {
                    eventHandlers.AddHandler(ZoomChangeEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_ZOOM_CHANGE";
                if (RemoveNativeEventHandler(key, this.evt_ZoomChangeEvt_delegate)) { 
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
    private void on_ZoomChangeEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_ZoomChangeEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

    ///<summary>Register the Eo event wrappers making the bridge to C# events. Internal usage only.</summary>
     void RegisterEventProxies()
    {
        evt_ZoomStartEvt_delegate = new Efl.EventCb(on_ZoomStartEvt_NativeCallback);
        evt_ZoomStopEvt_delegate = new Efl.EventCb(on_ZoomStopEvt_NativeCallback);
        evt_ZoomChangeEvt_delegate = new Efl.EventCb(on_ZoomChangeEvt_NativeCallback);
    }
    /// <summary>This sets the zoom animation state to on or off for zoomable. The default is off. When <c>paused</c> is <c>true</c>, it will stop zooming using animation on zoom level changes and change instantly, stopping any existing animations that are running.</summary>
    /// <returns>The paused state.</returns>
    public bool GetZoomAnimation() {
         var _ret_var = Efl.Ui.IZoomNativeInherit.efl_ui_zoom_animation_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>This sets the zoom animation state to on or off for zoomable. The default is off. When <c>paused</c> is <c>true</c>, it will stop zooming using animation on zoom level changes and change instantly, stopping any existing animations that are running.</summary>
    /// <param name="paused">The paused state.</param>
    /// <returns></returns>
    public void SetZoomAnimation( bool paused) {
                                 Efl.Ui.IZoomNativeInherit.efl_ui_zoom_animation_set_ptr.Value.Delegate(this.NativeHandle, paused);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get the zoom level of the photo
    /// This returns the current zoom level of the zoomable object. Note that if you set the fill mode to other than #EFL_UI_ZOOM_MODE_MANUAL (which is the default), the zoom level may be changed at any time by the  zoomable object itself to account for photo size and zoomable viewport size.</summary>
    /// <returns>The zoom level to set</returns>
    public double GetZoomLevel() {
         var _ret_var = Efl.Ui.IZoomNativeInherit.efl_ui_zoom_level_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the zoom level of the photo
    /// This sets the zoom level. If <c>zoom</c> is 1, it means no zoom. If it&apos;s smaller than 1, it means zoom in. If it&apos;s bigger than 1, it means zoom out. For  example, <c>zoom</c> 1 will be 1:1 pixel for pixel. <c>zoom</c> 2 will be 2:1 (that is 2x2 photo pixels will display as 1 on-screen pixel) which is a zoom out. 4:1 will be 4x4 photo pixels as 1 screen pixel, and so on. The <c>zoom</c> parameter must be greater than 0. It is suggested to stick to powers of 2. (1, 2, 4, 8, 16, 32, etc.).</summary>
    /// <param name="zoom">The zoom level to set</param>
    /// <returns></returns>
    public void SetZoomLevel( double zoom) {
                                 Efl.Ui.IZoomNativeInherit.efl_ui_zoom_level_set_ptr.Value.Delegate(this.NativeHandle, zoom);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get the zoom mode
    /// This gets the current zoom mode of the zoomable object.</summary>
    /// <returns>The zoom mode.</returns>
    public Efl.Ui.ZoomMode GetZoomMode() {
         var _ret_var = Efl.Ui.IZoomNativeInherit.efl_ui_zoom_mode_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the zoom mode
    /// This sets the zoom mode to manual or one of several automatic levels. Manual (EFL_UI_ZOOM_MODE_MANUAL) means that zoom is set manually by <see cref="Efl.Ui.IZoom.SetZoomLevel"/> and will stay at that level until changed by code or until zoom mode is changed. This is the default mode. The Automatic modes will allow the zoomable object to automatically adjust zoom mode based on properties.
    /// 
    /// #EFL_UI_ZOOM_MODE_AUTO_FIT) will adjust zoom so the photo fits EXACTLY inside the scroll frame with no pixels outside this region. #EFL_UI_ZOOM_MODE_AUTO_FILL will be similar but ensure no pixels within the frame are left unfilled.</summary>
    /// <param name="mode">The zoom mode.</param>
    /// <returns></returns>
    public void SetZoomMode( Efl.Ui.ZoomMode mode) {
                                 Efl.Ui.IZoomNativeInherit.efl_ui_zoom_mode_set_ptr.Value.Delegate(this.NativeHandle, mode);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>This sets the zoom animation state to on or off for zoomable. The default is off. When <c>paused</c> is <c>true</c>, it will stop zooming using animation on zoom level changes and change instantly, stopping any existing animations that are running.</summary>
/// <value>The paused state.</value>
    public bool ZoomAnimation {
        get { return GetZoomAnimation(); }
        set { SetZoomAnimation( value); }
    }
    /// <summary>Get the zoom level of the photo
/// This returns the current zoom level of the zoomable object. Note that if you set the fill mode to other than #EFL_UI_ZOOM_MODE_MANUAL (which is the default), the zoom level may be changed at any time by the  zoomable object itself to account for photo size and zoomable viewport size.</summary>
/// <value>The zoom level to set</value>
    public double ZoomLevel {
        get { return GetZoomLevel(); }
        set { SetZoomLevel( value); }
    }
    /// <summary>Get the zoom mode
/// This gets the current zoom mode of the zoomable object.</summary>
/// <value>The zoom mode.</value>
    public Efl.Ui.ZoomMode ZoomMode {
        get { return GetZoomMode(); }
        set { SetZoomMode( value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.IZoomConcrete.efl_ui_zoom_interface_get();
    }
}
public class IZoomNativeInherit  : Efl.Eo.NativeClass{
    public  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Efl);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
        if (efl_ui_zoom_animation_get_static_delegate == null)
            efl_ui_zoom_animation_get_static_delegate = new efl_ui_zoom_animation_get_delegate(zoom_animation_get);
        if (methods.FirstOrDefault(m => m.Name == "GetZoomAnimation") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_zoom_animation_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_zoom_animation_get_static_delegate)});
        if (efl_ui_zoom_animation_set_static_delegate == null)
            efl_ui_zoom_animation_set_static_delegate = new efl_ui_zoom_animation_set_delegate(zoom_animation_set);
        if (methods.FirstOrDefault(m => m.Name == "SetZoomAnimation") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_zoom_animation_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_zoom_animation_set_static_delegate)});
        if (efl_ui_zoom_level_get_static_delegate == null)
            efl_ui_zoom_level_get_static_delegate = new efl_ui_zoom_level_get_delegate(zoom_level_get);
        if (methods.FirstOrDefault(m => m.Name == "GetZoomLevel") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_zoom_level_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_zoom_level_get_static_delegate)});
        if (efl_ui_zoom_level_set_static_delegate == null)
            efl_ui_zoom_level_set_static_delegate = new efl_ui_zoom_level_set_delegate(zoom_level_set);
        if (methods.FirstOrDefault(m => m.Name == "SetZoomLevel") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_zoom_level_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_zoom_level_set_static_delegate)});
        if (efl_ui_zoom_mode_get_static_delegate == null)
            efl_ui_zoom_mode_get_static_delegate = new efl_ui_zoom_mode_get_delegate(zoom_mode_get);
        if (methods.FirstOrDefault(m => m.Name == "GetZoomMode") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_zoom_mode_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_zoom_mode_get_static_delegate)});
        if (efl_ui_zoom_mode_set_static_delegate == null)
            efl_ui_zoom_mode_set_static_delegate = new efl_ui_zoom_mode_set_delegate(zoom_mode_set);
        if (methods.FirstOrDefault(m => m.Name == "SetZoomMode") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_zoom_mode_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_zoom_mode_set_static_delegate)});
        return descs;
    }
    public override IntPtr GetEflClass()
    {
        return Efl.Ui.IZoomConcrete.efl_ui_zoom_interface_get();
    }
    public static  IntPtr GetEflClassStatic()
    {
        return Efl.Ui.IZoomConcrete.efl_ui_zoom_interface_get();
    }


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_zoom_animation_get_delegate(System.IntPtr obj, System.IntPtr pd);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_zoom_animation_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_ui_zoom_animation_get_api_delegate> efl_ui_zoom_animation_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_zoom_animation_get_api_delegate>(_Module, "efl_ui_zoom_animation_get");
     private static bool zoom_animation_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_ui_zoom_animation_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        bool _ret_var = default(bool);
            try {
                _ret_var = ((IZoom)wrapper).GetZoomAnimation();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_ui_zoom_animation_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_ui_zoom_animation_get_delegate efl_ui_zoom_animation_get_static_delegate;


     private delegate void efl_ui_zoom_animation_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool paused);


     public delegate void efl_ui_zoom_animation_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool paused);
     public static Efl.Eo.FunctionWrapper<efl_ui_zoom_animation_set_api_delegate> efl_ui_zoom_animation_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_zoom_animation_set_api_delegate>(_Module, "efl_ui_zoom_animation_set");
     private static void zoom_animation_set(System.IntPtr obj, System.IntPtr pd,  bool paused)
    {
        Eina.Log.Debug("function efl_ui_zoom_animation_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((IZoom)wrapper).SetZoomAnimation( paused);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_ui_zoom_animation_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  paused);
        }
    }
    private static efl_ui_zoom_animation_set_delegate efl_ui_zoom_animation_set_static_delegate;


     private delegate double efl_ui_zoom_level_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate double efl_ui_zoom_level_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_ui_zoom_level_get_api_delegate> efl_ui_zoom_level_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_zoom_level_get_api_delegate>(_Module, "efl_ui_zoom_level_get");
     private static double zoom_level_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_ui_zoom_level_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        double _ret_var = default(double);
            try {
                _ret_var = ((IZoom)wrapper).GetZoomLevel();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_ui_zoom_level_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_ui_zoom_level_get_delegate efl_ui_zoom_level_get_static_delegate;


     private delegate void efl_ui_zoom_level_set_delegate(System.IntPtr obj, System.IntPtr pd,   double zoom);


     public delegate void efl_ui_zoom_level_set_api_delegate(System.IntPtr obj,   double zoom);
     public static Efl.Eo.FunctionWrapper<efl_ui_zoom_level_set_api_delegate> efl_ui_zoom_level_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_zoom_level_set_api_delegate>(_Module, "efl_ui_zoom_level_set");
     private static void zoom_level_set(System.IntPtr obj, System.IntPtr pd,  double zoom)
    {
        Eina.Log.Debug("function efl_ui_zoom_level_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((IZoom)wrapper).SetZoomLevel( zoom);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_ui_zoom_level_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  zoom);
        }
    }
    private static efl_ui_zoom_level_set_delegate efl_ui_zoom_level_set_static_delegate;


     private delegate Efl.Ui.ZoomMode efl_ui_zoom_mode_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate Efl.Ui.ZoomMode efl_ui_zoom_mode_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_ui_zoom_mode_get_api_delegate> efl_ui_zoom_mode_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_zoom_mode_get_api_delegate>(_Module, "efl_ui_zoom_mode_get");
     private static Efl.Ui.ZoomMode zoom_mode_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_ui_zoom_mode_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Efl.Ui.ZoomMode _ret_var = default(Efl.Ui.ZoomMode);
            try {
                _ret_var = ((IZoom)wrapper).GetZoomMode();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_ui_zoom_mode_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_ui_zoom_mode_get_delegate efl_ui_zoom_mode_get_static_delegate;


     private delegate void efl_ui_zoom_mode_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.ZoomMode mode);


     public delegate void efl_ui_zoom_mode_set_api_delegate(System.IntPtr obj,   Efl.Ui.ZoomMode mode);
     public static Efl.Eo.FunctionWrapper<efl_ui_zoom_mode_set_api_delegate> efl_ui_zoom_mode_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_zoom_mode_set_api_delegate>(_Module, "efl_ui_zoom_mode_set");
     private static void zoom_mode_set(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.ZoomMode mode)
    {
        Eina.Log.Debug("function efl_ui_zoom_mode_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((IZoom)wrapper).SetZoomMode( mode);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_ui_zoom_mode_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  mode);
        }
    }
    private static efl_ui_zoom_mode_set_delegate efl_ui_zoom_mode_set_static_delegate;
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
