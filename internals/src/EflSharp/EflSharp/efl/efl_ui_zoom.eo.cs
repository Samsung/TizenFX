#define EFL_BETA
#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Ui {

/// <summary>Efl UI zoom interface</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Ui.IZoomConcrete.NativeMethods]
[Efl.Eo.BindingEntity]
public interface IZoom : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>This sets the zoom animation state to on or off for zoomable. The default is off. When <c>paused</c> is <c>true</c>, it will stop zooming using animation on zoom level changes and change instantly, stopping any existing animations that are running.</summary>
/// <returns>The paused state.</returns>
bool GetZoomAnimation();
    /// <summary>This sets the zoom animation state to on or off for zoomable. The default is off. When <c>paused</c> is <c>true</c>, it will stop zooming using animation on zoom level changes and change instantly, stopping any existing animations that are running.</summary>
/// <param name="paused">The paused state.</param>
void SetZoomAnimation(bool paused);
    /// <summary>Get the zoom level of the photo
/// This returns the current zoom level of the zoomable object. Note that if you set the fill mode to other than #EFL_UI_ZOOM_MODE_MANUAL (which is the default), the zoom level may be changed at any time by the  zoomable object itself to account for photo size and zoomable viewport size.</summary>
/// <returns>The zoom level to set</returns>
double GetZoomLevel();
    /// <summary>Set the zoom level of the photo
/// This sets the zoom level. If <c>zoom</c> is 1, it means no zoom. If it&apos;s smaller than 1, it means zoom in. If it&apos;s bigger than 1, it means zoom out. For  example, <c>zoom</c> 1 will be 1:1 pixel for pixel. <c>zoom</c> 2 will be 2:1 (that is 2x2 photo pixels will display as 1 on-screen pixel) which is a zoom out. 4:1 will be 4x4 photo pixels as 1 screen pixel, and so on. The <c>zoom</c> parameter must be greater than 0. It is suggested to stick to powers of 2. (1, 2, 4, 8, 16, 32, etc.).</summary>
/// <param name="zoom">The zoom level to set</param>
void SetZoomLevel(double zoom);
    /// <summary>Get the zoom mode
/// This gets the current zoom mode of the zoomable object.</summary>
/// <returns>The zoom mode.</returns>
Efl.Ui.ZoomMode GetZoomMode();
    /// <summary>Set the zoom mode
/// This sets the zoom mode to manual or one of several automatic levels. Manual (EFL_UI_ZOOM_MODE_MANUAL) means that zoom is set manually by <see cref="Efl.Ui.IZoom.SetZoomLevel"/> and will stay at that level until changed by code or until zoom mode is changed. This is the default mode. The Automatic modes will allow the zoomable object to automatically adjust zoom mode based on properties.
/// 
/// #EFL_UI_ZOOM_MODE_AUTO_FIT) will adjust zoom so the photo fits EXACTLY inside the scroll frame with no pixels outside this region. #EFL_UI_ZOOM_MODE_AUTO_FILL will be similar but ensure no pixels within the frame are left unfilled.</summary>
/// <param name="mode">The zoom mode.</param>
void SetZoomMode(Efl.Ui.ZoomMode mode);
                            /// <summary>Called when zooming started</summary>
    event EventHandler ZoomStartEvt;
    /// <summary>Called when zooming stopped</summary>
    event EventHandler ZoomStopEvt;
    /// <summary>Called when zooming changed</summary>
    event EventHandler ZoomChangeEvt;
    /// <summary>This sets the zoom animation state to on or off for zoomable. The default is off. When <c>paused</c> is <c>true</c>, it will stop zooming using animation on zoom level changes and change instantly, stopping any existing animations that are running.</summary>
    /// <value>The paused state.</value>
    bool ZoomAnimation {
        get;
        set;
    }
    /// <summary>Get the zoom level of the photo
    /// This returns the current zoom level of the zoomable object. Note that if you set the fill mode to other than #EFL_UI_ZOOM_MODE_MANUAL (which is the default), the zoom level may be changed at any time by the  zoomable object itself to account for photo size and zoomable viewport size.</summary>
    /// <value>The zoom level to set</value>
    double ZoomLevel {
        get;
        set;
    }
    /// <summary>Get the zoom mode
    /// This gets the current zoom mode of the zoomable object.</summary>
    /// <value>The zoom mode.</value>
    Efl.Ui.ZoomMode ZoomMode {
        get;
        set;
    }
}
/// <summary>Efl UI zoom interface</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
sealed public  class IZoomConcrete :
    Efl.Eo.EoWrapper
    , IZoom
    
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(IZoomConcrete))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    private IZoomConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
        efl_ui_zoom_interface_get();
    /// <summary>Initializes a new instance of the <see cref="IZoom"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private IZoomConcrete(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Called when zooming started</summary>
    public event EventHandler ZoomStartEvt
    {
        add
        {
            lock (eflBindingEventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        EventArgs args = EventArgs.Empty;
                        try
                        {
                            value?.Invoke(obj, args);
                        }
                        catch (Exception e)
                        {
                            Eina.Log.Error(e.ToString());
                            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                        }
                    }
                };

                string key = "_EFL_UI_EVENT_ZOOM_START";
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_ZOOM_START";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    /// <summary>Method to raise event ZoomStartEvt.</summary>
    public void OnZoomStartEvt(EventArgs e)
    {
        var key = "_EFL_UI_EVENT_ZOOM_START";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when zooming stopped</summary>
    public event EventHandler ZoomStopEvt
    {
        add
        {
            lock (eflBindingEventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        EventArgs args = EventArgs.Empty;
                        try
                        {
                            value?.Invoke(obj, args);
                        }
                        catch (Exception e)
                        {
                            Eina.Log.Error(e.ToString());
                            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                        }
                    }
                };

                string key = "_EFL_UI_EVENT_ZOOM_STOP";
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_ZOOM_STOP";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    /// <summary>Method to raise event ZoomStopEvt.</summary>
    public void OnZoomStopEvt(EventArgs e)
    {
        var key = "_EFL_UI_EVENT_ZOOM_STOP";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when zooming changed</summary>
    public event EventHandler ZoomChangeEvt
    {
        add
        {
            lock (eflBindingEventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        EventArgs args = EventArgs.Empty;
                        try
                        {
                            value?.Invoke(obj, args);
                        }
                        catch (Exception e)
                        {
                            Eina.Log.Error(e.ToString());
                            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                        }
                    }
                };

                string key = "_EFL_UI_EVENT_ZOOM_CHANGE";
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_ZOOM_CHANGE";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    /// <summary>Method to raise event ZoomChangeEvt.</summary>
    public void OnZoomChangeEvt(EventArgs e)
    {
        var key = "_EFL_UI_EVENT_ZOOM_CHANGE";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>This sets the zoom animation state to on or off for zoomable. The default is off. When <c>paused</c> is <c>true</c>, it will stop zooming using animation on zoom level changes and change instantly, stopping any existing animations that are running.</summary>
    /// <returns>The paused state.</returns>
    public bool GetZoomAnimation() {
         var _ret_var = Efl.Ui.IZoomConcrete.NativeMethods.efl_ui_zoom_animation_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>This sets the zoom animation state to on or off for zoomable. The default is off. When <c>paused</c> is <c>true</c>, it will stop zooming using animation on zoom level changes and change instantly, stopping any existing animations that are running.</summary>
    /// <param name="paused">The paused state.</param>
    public void SetZoomAnimation(bool paused) {
                                 Efl.Ui.IZoomConcrete.NativeMethods.efl_ui_zoom_animation_set_ptr.Value.Delegate(this.NativeHandle,paused);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get the zoom level of the photo
    /// This returns the current zoom level of the zoomable object. Note that if you set the fill mode to other than #EFL_UI_ZOOM_MODE_MANUAL (which is the default), the zoom level may be changed at any time by the  zoomable object itself to account for photo size and zoomable viewport size.</summary>
    /// <returns>The zoom level to set</returns>
    public double GetZoomLevel() {
         var _ret_var = Efl.Ui.IZoomConcrete.NativeMethods.efl_ui_zoom_level_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the zoom level of the photo
    /// This sets the zoom level. If <c>zoom</c> is 1, it means no zoom. If it&apos;s smaller than 1, it means zoom in. If it&apos;s bigger than 1, it means zoom out. For  example, <c>zoom</c> 1 will be 1:1 pixel for pixel. <c>zoom</c> 2 will be 2:1 (that is 2x2 photo pixels will display as 1 on-screen pixel) which is a zoom out. 4:1 will be 4x4 photo pixels as 1 screen pixel, and so on. The <c>zoom</c> parameter must be greater than 0. It is suggested to stick to powers of 2. (1, 2, 4, 8, 16, 32, etc.).</summary>
    /// <param name="zoom">The zoom level to set</param>
    public void SetZoomLevel(double zoom) {
                                 Efl.Ui.IZoomConcrete.NativeMethods.efl_ui_zoom_level_set_ptr.Value.Delegate(this.NativeHandle,zoom);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get the zoom mode
    /// This gets the current zoom mode of the zoomable object.</summary>
    /// <returns>The zoom mode.</returns>
    public Efl.Ui.ZoomMode GetZoomMode() {
         var _ret_var = Efl.Ui.IZoomConcrete.NativeMethods.efl_ui_zoom_mode_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the zoom mode
    /// This sets the zoom mode to manual or one of several automatic levels. Manual (EFL_UI_ZOOM_MODE_MANUAL) means that zoom is set manually by <see cref="Efl.Ui.IZoom.SetZoomLevel"/> and will stay at that level until changed by code or until zoom mode is changed. This is the default mode. The Automatic modes will allow the zoomable object to automatically adjust zoom mode based on properties.
    /// 
    /// #EFL_UI_ZOOM_MODE_AUTO_FIT) will adjust zoom so the photo fits EXACTLY inside the scroll frame with no pixels outside this region. #EFL_UI_ZOOM_MODE_AUTO_FILL will be similar but ensure no pixels within the frame are left unfilled.</summary>
    /// <param name="mode">The zoom mode.</param>
    public void SetZoomMode(Efl.Ui.ZoomMode mode) {
                                 Efl.Ui.IZoomConcrete.NativeMethods.efl_ui_zoom_mode_set_ptr.Value.Delegate(this.NativeHandle,mode);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>This sets the zoom animation state to on or off for zoomable. The default is off. When <c>paused</c> is <c>true</c>, it will stop zooming using animation on zoom level changes and change instantly, stopping any existing animations that are running.</summary>
    /// <value>The paused state.</value>
    public bool ZoomAnimation {
        get { return GetZoomAnimation(); }
        set { SetZoomAnimation(value); }
    }
    /// <summary>Get the zoom level of the photo
    /// This returns the current zoom level of the zoomable object. Note that if you set the fill mode to other than #EFL_UI_ZOOM_MODE_MANUAL (which is the default), the zoom level may be changed at any time by the  zoomable object itself to account for photo size and zoomable viewport size.</summary>
    /// <value>The zoom level to set</value>
    public double ZoomLevel {
        get { return GetZoomLevel(); }
        set { SetZoomLevel(value); }
    }
    /// <summary>Get the zoom mode
    /// This gets the current zoom mode of the zoomable object.</summary>
    /// <value>The zoom mode.</value>
    public Efl.Ui.ZoomMode ZoomMode {
        get { return GetZoomMode(); }
        set { SetZoomMode(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.IZoomConcrete.efl_ui_zoom_interface_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Eo.EoWrapper.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Efl);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_ui_zoom_animation_get_static_delegate == null)
            {
                efl_ui_zoom_animation_get_static_delegate = new efl_ui_zoom_animation_get_delegate(zoom_animation_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetZoomAnimation") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_zoom_animation_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_zoom_animation_get_static_delegate) });
            }

            if (efl_ui_zoom_animation_set_static_delegate == null)
            {
                efl_ui_zoom_animation_set_static_delegate = new efl_ui_zoom_animation_set_delegate(zoom_animation_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetZoomAnimation") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_zoom_animation_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_zoom_animation_set_static_delegate) });
            }

            if (efl_ui_zoom_level_get_static_delegate == null)
            {
                efl_ui_zoom_level_get_static_delegate = new efl_ui_zoom_level_get_delegate(zoom_level_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetZoomLevel") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_zoom_level_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_zoom_level_get_static_delegate) });
            }

            if (efl_ui_zoom_level_set_static_delegate == null)
            {
                efl_ui_zoom_level_set_static_delegate = new efl_ui_zoom_level_set_delegate(zoom_level_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetZoomLevel") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_zoom_level_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_zoom_level_set_static_delegate) });
            }

            if (efl_ui_zoom_mode_get_static_delegate == null)
            {
                efl_ui_zoom_mode_get_static_delegate = new efl_ui_zoom_mode_get_delegate(zoom_mode_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetZoomMode") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_zoom_mode_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_zoom_mode_get_static_delegate) });
            }

            if (efl_ui_zoom_mode_set_static_delegate == null)
            {
                efl_ui_zoom_mode_set_static_delegate = new efl_ui_zoom_mode_set_delegate(zoom_mode_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetZoomMode") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_zoom_mode_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_zoom_mode_set_static_delegate) });
            }

            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.IZoomConcrete.efl_ui_zoom_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_zoom_animation_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_zoom_animation_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_zoom_animation_get_api_delegate> efl_ui_zoom_animation_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_zoom_animation_get_api_delegate>(Module, "efl_ui_zoom_animation_get");

        private static bool zoom_animation_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_zoom_animation_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IZoom)ws.Target).GetZoomAnimation();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        return _ret_var;

            }
            else
            {
                return efl_ui_zoom_animation_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_zoom_animation_get_delegate efl_ui_zoom_animation_get_static_delegate;

        
        private delegate void efl_ui_zoom_animation_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool paused);

        
        public delegate void efl_ui_zoom_animation_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool paused);

        public static Efl.Eo.FunctionWrapper<efl_ui_zoom_animation_set_api_delegate> efl_ui_zoom_animation_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_zoom_animation_set_api_delegate>(Module, "efl_ui_zoom_animation_set");

        private static void zoom_animation_set(System.IntPtr obj, System.IntPtr pd, bool paused)
        {
            Eina.Log.Debug("function efl_ui_zoom_animation_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((IZoom)ws.Target).SetZoomAnimation(paused);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_zoom_animation_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), paused);
            }
        }

        private static efl_ui_zoom_animation_set_delegate efl_ui_zoom_animation_set_static_delegate;

        
        private delegate double efl_ui_zoom_level_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate double efl_ui_zoom_level_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_zoom_level_get_api_delegate> efl_ui_zoom_level_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_zoom_level_get_api_delegate>(Module, "efl_ui_zoom_level_get");

        private static double zoom_level_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_zoom_level_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            double _ret_var = default(double);
                try
                {
                    _ret_var = ((IZoom)ws.Target).GetZoomLevel();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        return _ret_var;

            }
            else
            {
                return efl_ui_zoom_level_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_zoom_level_get_delegate efl_ui_zoom_level_get_static_delegate;

        
        private delegate void efl_ui_zoom_level_set_delegate(System.IntPtr obj, System.IntPtr pd,  double zoom);

        
        public delegate void efl_ui_zoom_level_set_api_delegate(System.IntPtr obj,  double zoom);

        public static Efl.Eo.FunctionWrapper<efl_ui_zoom_level_set_api_delegate> efl_ui_zoom_level_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_zoom_level_set_api_delegate>(Module, "efl_ui_zoom_level_set");

        private static void zoom_level_set(System.IntPtr obj, System.IntPtr pd, double zoom)
        {
            Eina.Log.Debug("function efl_ui_zoom_level_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((IZoom)ws.Target).SetZoomLevel(zoom);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_zoom_level_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), zoom);
            }
        }

        private static efl_ui_zoom_level_set_delegate efl_ui_zoom_level_set_static_delegate;

        
        private delegate Efl.Ui.ZoomMode efl_ui_zoom_mode_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.Ui.ZoomMode efl_ui_zoom_mode_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_zoom_mode_get_api_delegate> efl_ui_zoom_mode_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_zoom_mode_get_api_delegate>(Module, "efl_ui_zoom_mode_get");

        private static Efl.Ui.ZoomMode zoom_mode_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_zoom_mode_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Ui.ZoomMode _ret_var = default(Efl.Ui.ZoomMode);
                try
                {
                    _ret_var = ((IZoom)ws.Target).GetZoomMode();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        return _ret_var;

            }
            else
            {
                return efl_ui_zoom_mode_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_zoom_mode_get_delegate efl_ui_zoom_mode_get_static_delegate;

        
        private delegate void efl_ui_zoom_mode_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.ZoomMode mode);

        
        public delegate void efl_ui_zoom_mode_set_api_delegate(System.IntPtr obj,  Efl.Ui.ZoomMode mode);

        public static Efl.Eo.FunctionWrapper<efl_ui_zoom_mode_set_api_delegate> efl_ui_zoom_mode_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_zoom_mode_set_api_delegate>(Module, "efl_ui_zoom_mode_set");

        private static void zoom_mode_set(System.IntPtr obj, System.IntPtr pd, Efl.Ui.ZoomMode mode)
        {
            Eina.Log.Debug("function efl_ui_zoom_mode_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((IZoom)ws.Target).SetZoomMode(mode);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_zoom_mode_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), mode);
            }
        }

        private static efl_ui_zoom_mode_set_delegate efl_ui_zoom_mode_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_UiIZoomConcrete_ExtensionMethods {
    public static Efl.BindableProperty<bool> ZoomAnimation<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.IZoom, T>magic = null) where T : Efl.Ui.IZoom {
        return new Efl.BindableProperty<bool>("zoom_animation", fac);
    }

    public static Efl.BindableProperty<double> ZoomLevel<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.IZoom, T>magic = null) where T : Efl.Ui.IZoom {
        return new Efl.BindableProperty<double>("zoom_level", fac);
    }

    public static Efl.BindableProperty<Efl.Ui.ZoomMode> ZoomMode<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.IZoom, T>magic = null) where T : Efl.Ui.IZoom {
        return new Efl.BindableProperty<Efl.Ui.ZoomMode>("zoom_mode", fac);
    }

}
#pragma warning restore CS1591
#endif
namespace Efl {

namespace Ui {

/// <summary>Types of zoom available.</summary>
[Efl.Eo.BindingEntity]
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

}

}

