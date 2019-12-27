/*
 * Copyright 2019 by its authors. See AUTHORS.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
namespace CoreUI {
    /// <summary>Object representing the application itself.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.App.NativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public abstract class App : CoreUI.Loop
    {
        /// <summary>Pointer to the native class description.</summary>
        public override System.IntPtr NativeClass
        {
            get
            {
                if (((object)this).GetType() == typeof(App))
                {
                    return GetCoreUIClassStatic();
                }
                else
                {
                    return CoreUI.Wrapper.ClassRegister.klassFromType[((object)this).GetType()];
                }
            }
        }

        [System.Runtime.InteropServices.DllImport(CoreUI.Libs.Ecore)] internal static extern System.IntPtr
            efl_app_class_get();

        /// <summary>Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        /// <param name="parent">Parent instance.</param>
        public App(CoreUI.Object parent= null) : base(efl_app_class_get(), parent)
        {
            FinishInstantiation();
        }

        /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
        /// Do not call this constructor directly.
        /// </summary>
        /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
        protected App(ConstructingHandle ch) : base(ch)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="App"/> class.
        /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.
        /// </summary>
        /// <param name="wh">The native pointer to be wrapped.</param>
        internal App(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
        {
        }

        [CoreUI.Wrapper.PrivateNativeClass]
        private class AppRealized : App
        {
            private AppRealized(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
            {
            }
        }
        /// <summary>Initializes a new instance of the <see cref="App"/> class.
        /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.
        /// </summary>
        /// <param name="baseKlass">The pointer to the base native Eo class.</param>
        /// <param name="parent">The CoreUI.Object parent of this instance.</param>
        protected App(IntPtr baseKlass, CoreUI.Object parent) : base(baseKlass, parent)
        {
        }

        /// <summary>Called when the application is not going be displayed or otherwise used by a user for some time</summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler Pause
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value);
                string key = "_EFL_APP_EVENT_PAUSE";
                AddNativeEventHandler(CoreUI.Libs.Ecore, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_APP_EVENT_PAUSE";
                RemoveNativeEventHandler(CoreUI.Libs.Ecore, key, value);
            }
        }

        /// <summary>Method to raise event Pause.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnPause()
        {
            CallNativeEventCallback(CoreUI.Libs.Ecore, "_EFL_APP_EVENT_PAUSE", IntPtr.Zero, null);
        }

        /// <summary>Called before a window is rendered after a pause event</summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler Resume
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value);
                string key = "_EFL_APP_EVENT_RESUME";
                AddNativeEventHandler(CoreUI.Libs.Ecore, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_APP_EVENT_RESUME";
                RemoveNativeEventHandler(CoreUI.Libs.Ecore, key, value);
            }
        }

        /// <summary>Method to raise event Resume.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnResume()
        {
            CallNativeEventCallback(CoreUI.Libs.Ecore, "_EFL_APP_EVENT_RESUME", IntPtr.Zero, null);
        }

        /// <summary>Called when the application&apos;s windows are all destroyed</summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler Standby
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value);
                string key = "_EFL_APP_EVENT_STANDBY";
                AddNativeEventHandler(CoreUI.Libs.Ecore, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_APP_EVENT_STANDBY";
                RemoveNativeEventHandler(CoreUI.Libs.Ecore, key, value);
            }
        }

        /// <summary>Method to raise event Standby.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnStandby()
        {
            CallNativeEventCallback(CoreUI.Libs.Ecore, "_EFL_APP_EVENT_STANDBY", IntPtr.Zero, null);
        }

        /// <summary>Called before starting the shutdown of the application</summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler Terminate
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value);
                string key = "_EFL_APP_EVENT_TERMINATE";
                AddNativeEventHandler(CoreUI.Libs.Ecore, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_APP_EVENT_TERMINATE";
                RemoveNativeEventHandler(CoreUI.Libs.Ecore, key, value);
            }
        }

        /// <summary>Method to raise event Terminate.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnTerminate()
        {
            CallNativeEventCallback(CoreUI.Libs.Ecore, "_EFL_APP_EVENT_TERMINATE", IntPtr.Zero, null);
        }

        /// <summary>System specific, but on unix maps to SIGUSR1 signal to the process - only called on main loop object</summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler SignalUsr1
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value);
                string key = "_EFL_APP_EVENT_SIGNAL_USR1";
                AddNativeEventHandler(CoreUI.Libs.Ecore, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_APP_EVENT_SIGNAL_USR1";
                RemoveNativeEventHandler(CoreUI.Libs.Ecore, key, value);
            }
        }

        /// <summary>Method to raise event SignalUsr1.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnSignalUsr1()
        {
            CallNativeEventCallback(CoreUI.Libs.Ecore, "_EFL_APP_EVENT_SIGNAL_USR1", IntPtr.Zero, null);
        }

        /// <summary>System specific, but on unix maps to SIGUSR2 signal to the process - only called on main loop object</summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler SignalUsr2
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value);
                string key = "_EFL_APP_EVENT_SIGNAL_USR2";
                AddNativeEventHandler(CoreUI.Libs.Ecore, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_APP_EVENT_SIGNAL_USR2";
                RemoveNativeEventHandler(CoreUI.Libs.Ecore, key, value);
            }
        }

        /// <summary>Method to raise event SignalUsr2.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnSignalUsr2()
        {
            CallNativeEventCallback(CoreUI.Libs.Ecore, "_EFL_APP_EVENT_SIGNAL_USR2", IntPtr.Zero, null);
        }

        /// <summary>System specific, but on unix maps to SIGHUP signal to the process - only called on main loop object</summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler SignalHup
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value);
                string key = "_EFL_APP_EVENT_SIGNAL_HUP";
                AddNativeEventHandler(CoreUI.Libs.Ecore, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_APP_EVENT_SIGNAL_HUP";
                RemoveNativeEventHandler(CoreUI.Libs.Ecore, key, value);
            }
        }

        /// <summary>Method to raise event SignalHup.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnSignalHup()
        {
            CallNativeEventCallback(CoreUI.Libs.Ecore, "_EFL_APP_EVENT_SIGNAL_HUP", IntPtr.Zero, null);
        }


        /// <summary>Returns the app object that is representing this process
        /// 
        /// <b>NOTE: </b>This function call only works in the main loop thread of the process.</summary>
        /// <returns>Application for this process</returns>
        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.App GetAppMain() {
            var _ret_var = CoreUI.App.NativeMethods.efl_app_main_get_ptr.Value.Delegate();
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Indicates the version of EFL with which this application was compiled against/for.
        /// 
        /// This might differ from <see cref="CoreUI.App.GetCoreUIVersion"/>.</summary>
        /// <returns>CoreUI build version</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.Version GetBuildCoreUIVersion() {
            var _ret_var = CoreUI.App.NativeMethods.efl_app_build_efl_version_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            var __ret_tmp = CoreUI.DataTypes.PrimitiveConversion.PointerToManaged<CoreUI.Version>(_ret_var);
        
        return __ret_tmp;

        }

        /// <summary>Indicates the currently running version of EFL.
        /// 
        /// This might differ from <see cref="CoreUI.App.GetBuildCoreUIVersion"/>.</summary>
        /// <returns>CoreUI version</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.Version GetCoreUIVersion() {
            var _ret_var = CoreUI.App.NativeMethods.efl_app_efl_version_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            var __ret_tmp = CoreUI.DataTypes.PrimitiveConversion.PointerToManaged<CoreUI.Version>(_ret_var);
        
        return __ret_tmp;

        }

        /// <summary>Returns the app object that is representing this process
        /// 
        /// <b>NOTE: </b>This function call only works in the main loop thread of the process.</summary>
        /// <value>Application for this process</value>
        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.App AppMain {
            get { return GetAppMain(); }
        }

        /// <summary>Indicates the version of EFL with which this application was compiled against/for.
        /// 
        /// This might differ from <see cref="CoreUI.App.GetCoreUIVersion"/>.</summary>
        /// <value>CoreUI build version</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.Version BuildCoreUIVersion {
            get { return GetBuildCoreUIVersion(); }
        }

        /// <summary>Indicates the currently running version of EFL.
        /// 
        /// This might differ from <see cref="CoreUI.App.GetBuildCoreUIVersion"/>.</summary>
        /// <value>CoreUI version</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.Version CoreUIVersion {
            get { return GetCoreUIVersion(); }
        }

        private static IntPtr GetCoreUIClassStatic()
        {
            return CoreUI.App.efl_app_class_get();
        }

        /// <summary>Wrapper for native methods and virtual method delegates.
        /// For internal use by generated code only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal new class NativeMethods : CoreUI.Loop.NativeMethods
        {
            private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.Ecore);

            /// <summary>Gets the list of Eo operations to override.
        /// </summary>
            /// <returns>The list of Eo operations to be overload.</returns>
            internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
            {
                var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
                var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

                if (efl_app_build_efl_version_get_static_delegate == null)
                {
                    efl_app_build_efl_version_get_static_delegate = new efl_app_build_efl_version_get_delegate(build_efl_version_get);
                }

                if (methods.Contains("GetBuildCoreUIVersion"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_app_build_efl_version_get"), func = Marshal.GetFunctionPointerForDelegate(efl_app_build_efl_version_get_static_delegate) });
                }

                if (efl_app_efl_version_get_static_delegate == null)
                {
                    efl_app_efl_version_get_static_delegate = new efl_app_efl_version_get_delegate(efl_version_get);
                }

                if (methods.Contains("GetCoreUIVersion"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_app_efl_version_get"), func = Marshal.GetFunctionPointerForDelegate(efl_app_efl_version_get_static_delegate) });
                }

                if (includeInherited)
                {
                    var all_interfaces = type.GetInterfaces();
                    foreach (var iface in all_interfaces)
                    {
                        var moredescs = ((CoreUI.Wrapper.NativeClass)iface.GetCustomAttributes(false)?.FirstOrDefault(attr => attr is CoreUI.Wrapper.NativeClass))?.GetEoOps(type, false);
                        if (moredescs != null)
                            descs.AddRange(moredescs);
                    }
                }
                descs.AddRange(base.GetEoOps(type, false));
                return descs;
            }

            /// <summary>Returns the Eo class for the native methods of this class.
            /// </summary>
            /// <returns>The native class pointer.</returns>
            internal override IntPtr GetCoreUIClass()
            {
                return CoreUI.App.efl_app_class_get();
            }

            #pragma warning disable CA1707, CS1591, SA1300, SA1600

            [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
            private delegate CoreUI.App efl_app_main_get_delegate();

            [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
            internal delegate CoreUI.App efl_app_main_get_api_delegate();

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_app_main_get_api_delegate> efl_app_main_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_app_main_get_api_delegate>(Module, "efl_app_main_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static CoreUI.App app_main_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_app_main_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.App _ret_var = default(CoreUI.App);
                    try
                    {
                        _ret_var = App.GetAppMain();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return _ret_var;
                }
                else
                {
                    return efl_app_main_get_ptr.Value.Delegate();
                }
            }

            
            private delegate System.IntPtr efl_app_build_efl_version_get_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate System.IntPtr efl_app_build_efl_version_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_app_build_efl_version_get_api_delegate> efl_app_build_efl_version_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_app_build_efl_version_get_api_delegate>(Module, "efl_app_build_efl_version_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static System.IntPtr build_efl_version_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_app_build_efl_version_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.Version _ret_var = default(CoreUI.Version);
                    try
                    {
                        _ret_var = ((App)ws.Target).GetBuildCoreUIVersion();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return CoreUI.DataTypes.PrimitiveConversion.ManagedToPointerAlloc(_ret_var);
                }
                else
                {
                    return efl_app_build_efl_version_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_app_build_efl_version_get_delegate efl_app_build_efl_version_get_static_delegate;

            
            private delegate System.IntPtr efl_app_efl_version_get_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate System.IntPtr efl_app_efl_version_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_app_efl_version_get_api_delegate> efl_app_efl_version_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_app_efl_version_get_api_delegate>(Module, "efl_app_efl_version_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static System.IntPtr efl_version_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_app_efl_version_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.Version _ret_var = default(CoreUI.Version);
                    try
                    {
                        _ret_var = ((App)ws.Target).GetCoreUIVersion();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return CoreUI.DataTypes.PrimitiveConversion.ManagedToPointerAlloc(_ret_var);
                }
                else
                {
                    return efl_app_efl_version_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_app_efl_version_get_delegate efl_app_efl_version_get_static_delegate;

            #pragma warning restore CA1707, CS1591, SA1300, SA1600

        }
    }
}

