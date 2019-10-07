#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace UIKit {

/// <summary>Object representing the application itself.</summary>
/// <since_tizen> 6 </since_tizen>
[UIKit.App.NativeMethods]
[UIKit.Wrapper.BindingEntity]
public abstract class App : UIKit.Loop
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(App))
            {
                return GetUIKitClassStatic();
            }
            else
            {
                return UIKit.Wrapper.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    [System.Runtime.InteropServices.DllImport(UIKit.Libs.Ecore)] internal static extern System.IntPtr
        efl_app_class_get();

    /// <summary>Initializes a new instance of the <see cref="App"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    /// <since_tizen> 6 </since_tizen>
    public App(UIKit.Object parent= null
            ) : base(efl_app_class_get(), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    /// <since_tizen> 6 </since_tizen>
    protected App(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="App"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    /// <since_tizen> 6 </since_tizen>
    protected App(UIKit.Wrapper.Globals.WrappingHandle wh) : base(wh)
    {
    }

    [UIKit.Wrapper.PrivateNativeClass]
    private class AppRealized : App
    {
        private AppRealized(UIKit.Wrapper.Globals.WrappingHandle wh) : base(wh)
        {
        }
    }
    /// <summary>Initializes a new instance of the <see cref="App"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The UIKit.Object parent of this instance.</param>
    protected App(IntPtr baseKlass, UIKit.Object parent) : base(baseKlass, parent)
    {
    }

    /// <summary>Called when the application is not going be displayed or otherwise used by a user for some time</summary>
    /// <since_tizen> 6 </since_tizen>
    public event EventHandler PauseEvent
    {
        add
        {
            UIKit.EventCb callerCb = (IntPtr data, ref UIKit.Event.NativeStruct evt) =>
            {
                var obj = UIKit.Wrapper.Globals.WrapperSupervisorPtrToManaged(data).Target;
                if (obj != null)
                {
                    EventArgs args = EventArgs.Empty;
                    try
                    {
                        value?.Invoke(obj, args);
                    }
                    catch (Exception e)
                    {
                        UIKit.DataTypes.Log.Error(e.ToString());
                        UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }
                }
            };

            string key = "_EFL_APP_EVENT_PAUSE";
            AddNativeEventHandler(UIKit.Libs.Ecore, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_APP_EVENT_PAUSE";
            RemoveNativeEventHandler(UIKit.Libs.Ecore, key, value);
        }
    }

    /// <summary>Method to raise event PauseEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnPauseEvent(EventArgs e)
    {
        var key = "_EFL_APP_EVENT_PAUSE";
        IntPtr desc = UIKit.EventDescription.GetNative(UIKit.Libs.Ecore, key);
        if (desc == IntPtr.Zero)
        {
            UIKit.DataTypes.Log.Error($"Failed to get native event {key}");
            return;
        }

        UIKit.Wrapper.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }

    /// <summary>Called before a window is rendered after a pause event</summary>
    /// <since_tizen> 6 </since_tizen>
    public event EventHandler ResumeEvent
    {
        add
        {
            UIKit.EventCb callerCb = (IntPtr data, ref UIKit.Event.NativeStruct evt) =>
            {
                var obj = UIKit.Wrapper.Globals.WrapperSupervisorPtrToManaged(data).Target;
                if (obj != null)
                {
                    EventArgs args = EventArgs.Empty;
                    try
                    {
                        value?.Invoke(obj, args);
                    }
                    catch (Exception e)
                    {
                        UIKit.DataTypes.Log.Error(e.ToString());
                        UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }
                }
            };

            string key = "_EFL_APP_EVENT_RESUME";
            AddNativeEventHandler(UIKit.Libs.Ecore, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_APP_EVENT_RESUME";
            RemoveNativeEventHandler(UIKit.Libs.Ecore, key, value);
        }
    }

    /// <summary>Method to raise event ResumeEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnResumeEvent(EventArgs e)
    {
        var key = "_EFL_APP_EVENT_RESUME";
        IntPtr desc = UIKit.EventDescription.GetNative(UIKit.Libs.Ecore, key);
        if (desc == IntPtr.Zero)
        {
            UIKit.DataTypes.Log.Error($"Failed to get native event {key}");
            return;
        }

        UIKit.Wrapper.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }

    /// <summary>Called when the application&apos;s windows are all destroyed</summary>
    /// <since_tizen> 6 </since_tizen>
    public event EventHandler StandbyEvent
    {
        add
        {
            UIKit.EventCb callerCb = (IntPtr data, ref UIKit.Event.NativeStruct evt) =>
            {
                var obj = UIKit.Wrapper.Globals.WrapperSupervisorPtrToManaged(data).Target;
                if (obj != null)
                {
                    EventArgs args = EventArgs.Empty;
                    try
                    {
                        value?.Invoke(obj, args);
                    }
                    catch (Exception e)
                    {
                        UIKit.DataTypes.Log.Error(e.ToString());
                        UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }
                }
            };

            string key = "_EFL_APP_EVENT_STANDBY";
            AddNativeEventHandler(UIKit.Libs.Ecore, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_APP_EVENT_STANDBY";
            RemoveNativeEventHandler(UIKit.Libs.Ecore, key, value);
        }
    }

    /// <summary>Method to raise event StandbyEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnStandbyEvent(EventArgs e)
    {
        var key = "_EFL_APP_EVENT_STANDBY";
        IntPtr desc = UIKit.EventDescription.GetNative(UIKit.Libs.Ecore, key);
        if (desc == IntPtr.Zero)
        {
            UIKit.DataTypes.Log.Error($"Failed to get native event {key}");
            return;
        }

        UIKit.Wrapper.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }

    /// <summary>Called before starting the shutdown of the application</summary>
    /// <since_tizen> 6 </since_tizen>
    public event EventHandler TerminateEvent
    {
        add
        {
            UIKit.EventCb callerCb = (IntPtr data, ref UIKit.Event.NativeStruct evt) =>
            {
                var obj = UIKit.Wrapper.Globals.WrapperSupervisorPtrToManaged(data).Target;
                if (obj != null)
                {
                    EventArgs args = EventArgs.Empty;
                    try
                    {
                        value?.Invoke(obj, args);
                    }
                    catch (Exception e)
                    {
                        UIKit.DataTypes.Log.Error(e.ToString());
                        UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }
                }
            };

            string key = "_EFL_APP_EVENT_TERMINATE";
            AddNativeEventHandler(UIKit.Libs.Ecore, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_APP_EVENT_TERMINATE";
            RemoveNativeEventHandler(UIKit.Libs.Ecore, key, value);
        }
    }

    /// <summary>Method to raise event TerminateEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnTerminateEvent(EventArgs e)
    {
        var key = "_EFL_APP_EVENT_TERMINATE";
        IntPtr desc = UIKit.EventDescription.GetNative(UIKit.Libs.Ecore, key);
        if (desc == IntPtr.Zero)
        {
            UIKit.DataTypes.Log.Error($"Failed to get native event {key}");
            return;
        }

        UIKit.Wrapper.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }

    /// <summary>System specific, but on unix maps to SIGUSR1 signal to the process - only called on main loop object</summary>
    /// <since_tizen> 6 </since_tizen>
    public event EventHandler SignalUsr1Event
    {
        add
        {
            UIKit.EventCb callerCb = (IntPtr data, ref UIKit.Event.NativeStruct evt) =>
            {
                var obj = UIKit.Wrapper.Globals.WrapperSupervisorPtrToManaged(data).Target;
                if (obj != null)
                {
                    EventArgs args = EventArgs.Empty;
                    try
                    {
                        value?.Invoke(obj, args);
                    }
                    catch (Exception e)
                    {
                        UIKit.DataTypes.Log.Error(e.ToString());
                        UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }
                }
            };

            string key = "_EFL_APP_EVENT_SIGNAL_USR1";
            AddNativeEventHandler(UIKit.Libs.Ecore, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_APP_EVENT_SIGNAL_USR1";
            RemoveNativeEventHandler(UIKit.Libs.Ecore, key, value);
        }
    }

    /// <summary>Method to raise event SignalUsr1Event.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnSignalUsr1Event(EventArgs e)
    {
        var key = "_EFL_APP_EVENT_SIGNAL_USR1";
        IntPtr desc = UIKit.EventDescription.GetNative(UIKit.Libs.Ecore, key);
        if (desc == IntPtr.Zero)
        {
            UIKit.DataTypes.Log.Error($"Failed to get native event {key}");
            return;
        }

        UIKit.Wrapper.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }

    /// <summary>System specific, but on unix maps to SIGUSR2 signal to the process - only called on main loop object</summary>
    /// <since_tizen> 6 </since_tizen>
    public event EventHandler SignalUsr2Event
    {
        add
        {
            UIKit.EventCb callerCb = (IntPtr data, ref UIKit.Event.NativeStruct evt) =>
            {
                var obj = UIKit.Wrapper.Globals.WrapperSupervisorPtrToManaged(data).Target;
                if (obj != null)
                {
                    EventArgs args = EventArgs.Empty;
                    try
                    {
                        value?.Invoke(obj, args);
                    }
                    catch (Exception e)
                    {
                        UIKit.DataTypes.Log.Error(e.ToString());
                        UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }
                }
            };

            string key = "_EFL_APP_EVENT_SIGNAL_USR2";
            AddNativeEventHandler(UIKit.Libs.Ecore, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_APP_EVENT_SIGNAL_USR2";
            RemoveNativeEventHandler(UIKit.Libs.Ecore, key, value);
        }
    }

    /// <summary>Method to raise event SignalUsr2Event.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnSignalUsr2Event(EventArgs e)
    {
        var key = "_EFL_APP_EVENT_SIGNAL_USR2";
        IntPtr desc = UIKit.EventDescription.GetNative(UIKit.Libs.Ecore, key);
        if (desc == IntPtr.Zero)
        {
            UIKit.DataTypes.Log.Error($"Failed to get native event {key}");
            return;
        }

        UIKit.Wrapper.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }

    /// <summary>System specific, but on unix maps to SIGHUP signal to the process - only called on main loop object</summary>
    /// <since_tizen> 6 </since_tizen>
    public event EventHandler SignalHupEvent
    {
        add
        {
            UIKit.EventCb callerCb = (IntPtr data, ref UIKit.Event.NativeStruct evt) =>
            {
                var obj = UIKit.Wrapper.Globals.WrapperSupervisorPtrToManaged(data).Target;
                if (obj != null)
                {
                    EventArgs args = EventArgs.Empty;
                    try
                    {
                        value?.Invoke(obj, args);
                    }
                    catch (Exception e)
                    {
                        UIKit.DataTypes.Log.Error(e.ToString());
                        UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }
                }
            };

            string key = "_EFL_APP_EVENT_SIGNAL_HUP";
            AddNativeEventHandler(UIKit.Libs.Ecore, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_APP_EVENT_SIGNAL_HUP";
            RemoveNativeEventHandler(UIKit.Libs.Ecore, key, value);
        }
    }

    /// <summary>Method to raise event SignalHupEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnSignalHupEvent(EventArgs e)
    {
        var key = "_EFL_APP_EVENT_SIGNAL_HUP";
        IntPtr desc = UIKit.EventDescription.GetNative(UIKit.Libs.Ecore, key);
        if (desc == IntPtr.Zero)
        {
            UIKit.DataTypes.Log.Error($"Failed to get native event {key}");
            return;
        }

        UIKit.Wrapper.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }


    /// <summary>Returns the app object that is representing this process
    /// Note: This function call only works in the main loop thread of the process.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>Application for this process</returns>
    public static UIKit.App GetAppMain() {
        var _ret_var = UIKit.App.NativeMethods.efl_app_main_get_ptr.Value.Delegate();
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Indicates the version of EFL with which this application was compiled against/for.
    /// This might differ from <see cref="UIKit.App.GetUIKitVersion"/>.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>UIKit build version</returns>
    public virtual UIKit.Version GetBuildUIKitVersion() {
        var _ret_var = UIKit.App.NativeMethods.efl_app_build_efl_version_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        var __ret_tmp = UIKit.DataTypes.PrimitiveConversion.PointerToManaged<UIKit.Version>(_ret_var);
        
        return __ret_tmp;

    }

    /// <summary>Indicates the currently running version of EFL.
    /// This might differ from <see cref="UIKit.App.GetBuildUIKitVersion"/>.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>UIKit version</returns>
    public virtual UIKit.Version GetUIKitVersion() {
        var _ret_var = UIKit.App.NativeMethods.efl_app_efl_version_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        var __ret_tmp = UIKit.DataTypes.PrimitiveConversion.PointerToManaged<UIKit.Version>(_ret_var);
        
        return __ret_tmp;

    }

    /// <summary>Returns the app object that is representing this process
    /// Note: This function call only works in the main loop thread of the process.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>Application for this process</value>
    public static UIKit.App AppMain {
        get { return GetAppMain(); }
    }

    /// <summary>Indicates the version of EFL with which this application was compiled against/for.
    /// This might differ from <see cref="UIKit.App.GetUIKitVersion"/>.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>UIKit build version</value>
    public UIKit.Version BuildUIKitVersion {
        get { return GetBuildUIKitVersion(); }
    }

    /// <summary>Indicates the currently running version of EFL.
    /// This might differ from <see cref="UIKit.App.GetBuildUIKitVersion"/>.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>UIKit version</value>
    public UIKit.Version UIKitVersion {
        get { return GetUIKitVersion(); }
    }

    private static IntPtr GetUIKitClassStatic()
    {
        return UIKit.App.efl_app_class_get();
    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : UIKit.Loop.NativeMethods
    {
        private static UIKit.Wrapper.NativeModule Module = new UIKit.Wrapper.NativeModule(UIKit.Libs.Ecore);

        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<UIKit_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<UIKit_Op_Description>();
            var methods = UIKit.Wrapper.Globals.GetUserMethods(type);

            if (efl_app_build_efl_version_get_static_delegate == null)
            {
                efl_app_build_efl_version_get_static_delegate = new efl_app_build_efl_version_get_delegate(build_efl_version_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetBuildUIKitVersion") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_app_build_efl_version_get"), func = Marshal.GetFunctionPointerForDelegate(efl_app_build_efl_version_get_static_delegate) });
            }

            if (efl_app_efl_version_get_static_delegate == null)
            {
                efl_app_efl_version_get_static_delegate = new efl_app_efl_version_get_delegate(efl_version_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetUIKitVersion") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_app_efl_version_get"), func = Marshal.GetFunctionPointerForDelegate(efl_app_efl_version_get_static_delegate) });
            }

            if (includeInherited)
            {
                var all_interfaces = type.GetInterfaces();
                foreach (var iface in all_interfaces)
                {
                    var moredescs = ((UIKit.Wrapper.NativeClass)iface.GetCustomAttributes(false)?.FirstOrDefault(attr => attr is UIKit.Wrapper.NativeClass))?.GetEoOps(type, false);
                    if (moredescs != null)
                        descs.AddRange(moredescs);
                }
            }
            descs.AddRange(base.GetEoOps(type, false));
            return descs;
        }

        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetUIKitClass()
        {
            return UIKit.App.efl_app_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(UIKit.Wrapper.MarshalEo<UIKit.Wrapper.NonOwnTag>))]
        private delegate UIKit.App efl_app_main_get_delegate();

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(UIKit.Wrapper.MarshalEo<UIKit.Wrapper.NonOwnTag>))]
        public delegate UIKit.App efl_app_main_get_api_delegate();

        public static UIKit.Wrapper.FunctionWrapper<efl_app_main_get_api_delegate> efl_app_main_get_ptr = new UIKit.Wrapper.FunctionWrapper<efl_app_main_get_api_delegate>(Module, "efl_app_main_get");

        private static UIKit.App app_main_get(System.IntPtr obj, System.IntPtr pd)
        {
            UIKit.DataTypes.Log.Debug("function efl_app_main_get was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                UIKit.App _ret_var = default(UIKit.App);
                try
                {
                    _ret_var = App.GetAppMain();
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_app_main_get_ptr.Value.Delegate();
            }
        }

        
        private delegate System.IntPtr efl_app_build_efl_version_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate System.IntPtr efl_app_build_efl_version_get_api_delegate(System.IntPtr obj);

        public static UIKit.Wrapper.FunctionWrapper<efl_app_build_efl_version_get_api_delegate> efl_app_build_efl_version_get_ptr = new UIKit.Wrapper.FunctionWrapper<efl_app_build_efl_version_get_api_delegate>(Module, "efl_app_build_efl_version_get");

        private static System.IntPtr build_efl_version_get(System.IntPtr obj, System.IntPtr pd)
        {
            UIKit.DataTypes.Log.Debug("function efl_app_build_efl_version_get was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                UIKit.Version _ret_var = default(UIKit.Version);
                try
                {
                    _ret_var = ((App)ws.Target).GetBuildUIKitVersion();
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return UIKit.DataTypes.PrimitiveConversion.ManagedToPointerAlloc(_ret_var);
            }
            else
            {
                return efl_app_build_efl_version_get_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)));
            }
        }

        private static efl_app_build_efl_version_get_delegate efl_app_build_efl_version_get_static_delegate;

        
        private delegate System.IntPtr efl_app_efl_version_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate System.IntPtr efl_app_efl_version_get_api_delegate(System.IntPtr obj);

        public static UIKit.Wrapper.FunctionWrapper<efl_app_efl_version_get_api_delegate> efl_app_efl_version_get_ptr = new UIKit.Wrapper.FunctionWrapper<efl_app_efl_version_get_api_delegate>(Module, "efl_app_efl_version_get");

        private static System.IntPtr efl_version_get(System.IntPtr obj, System.IntPtr pd)
        {
            UIKit.DataTypes.Log.Debug("function efl_app_efl_version_get was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                UIKit.Version _ret_var = default(UIKit.Version);
                try
                {
                    _ret_var = ((App)ws.Target).GetUIKitVersion();
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return UIKit.DataTypes.PrimitiveConversion.ManagedToPointerAlloc(_ret_var);
            }
            else
            {
                return efl_app_efl_version_get_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)));
            }
        }

        private static efl_app_efl_version_get_delegate efl_app_efl_version_get_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

#if EFL_BETA
#pragma warning disable CS1591
public static class UIKitApp_ExtensionMethods {
}
#pragma warning restore CS1591
#endif
