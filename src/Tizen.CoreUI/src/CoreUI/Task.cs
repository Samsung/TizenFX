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
    /// <summary>EFL&apos;s abstraction for a task (process).</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Task.NativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public abstract class Task : CoreUI.LoopConsumer
    {
        /// <summary>Pointer to the native class description.</summary>
        public override System.IntPtr NativeClass
        {
            get
            {
                if (((object)this).GetType() == typeof(Task))
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
            efl_task_class_get();

        /// <summary>Initializes a new instance of the <see cref="Task"/> class.
        /// </summary>
        /// <param name="parent">Parent instance.</param>
        public Task(CoreUI.Object parent= null) : base(efl_task_class_get(), parent)
        {
            FinishInstantiation();
        }

        /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
        /// Do not call this constructor directly.
        /// </summary>
        /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
        protected Task(ConstructingHandle ch) : base(ch)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="Task"/> class.
        /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.
        /// </summary>
        /// <param name="wh">The native pointer to be wrapped.</param>
        internal Task(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
        {
        }

        [CoreUI.Wrapper.PrivateNativeClass]
        private class TaskRealized : Task
        {
            private TaskRealized(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
            {
            }
        }
        /// <summary>Initializes a new instance of the <see cref="Task"/> class.
        /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.
        /// </summary>
        /// <param name="baseKlass">The pointer to the base native Eo class.</param>
        /// <param name="parent">The CoreUI.Object parent of this instance.</param>
        protected Task(IntPtr baseKlass, CoreUI.Object parent) : base(baseKlass, parent)
        {
        }

        /// <summary>Called when the task exits. You can pick up any information you need at this point such as exit_code etc.</summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler Exit
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value);
                string key = "_EFL_TASK_EVENT_EXIT";
                AddNativeEventHandler(CoreUI.Libs.Ecore, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_TASK_EVENT_EXIT";
                RemoveNativeEventHandler(CoreUI.Libs.Ecore, key, value);
            }
        }

        /// <summary>Method to raise event Exit.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnExit()
        {
            CallNativeEventCallback(CoreUI.Libs.Ecore, "_EFL_TASK_EVENT_EXIT", IntPtr.Zero, null);
        }


        /// <summary>The priority of this task.</summary>
        /// <returns>Desired priority.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.TaskPriority GetPriority() {
            var _ret_var = CoreUI.Task.NativeMethods.efl_task_priority_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The priority of this task.</summary>
        /// <param name="priority">Desired priority.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetPriority(CoreUI.TaskPriority priority) {
            CoreUI.Task.NativeMethods.efl_task_priority_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), priority);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The final exit code of this task. This is the code that will be produced upon task completion.</summary>
        /// <returns>The exit code.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual int GetExitCode() {
            var _ret_var = CoreUI.Task.NativeMethods.efl_task_exit_code_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Flags to further customize task&apos;s behavior.</summary>
        /// <returns>Desired task flags.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.TaskFlags GetFlags() {
            var _ret_var = CoreUI.Task.NativeMethods.efl_task_flags_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Flags to further customize task&apos;s behavior.</summary>
        /// <param name="flags">Desired task flags.<br/>The default value is <see cref="CoreUI.TaskFlags.ExitWithParent"/>.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetFlags(CoreUI.TaskFlags flags) {
            CoreUI.Task.NativeMethods.efl_task_flags_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), flags);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Actually run the task.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <returns>On success in starting the task, return true, otherwise false</returns>
        public virtual bool Run() {
            var _ret_var = CoreUI.Task.NativeMethods.efl_task_run_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Request the task end (may send a signal or interrupt signal resulting in a terminate event being triggered in the target task loop).</summary>
        /// <since_tizen> 6 </since_tizen>
        public virtual void End() {
            CoreUI.Task.NativeMethods.efl_task_end_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The priority of this task.</summary>
        /// <value>Desired priority.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.TaskPriority Priority {
            get { return GetPriority(); }
            set { SetPriority(value); }
        }

        /// <summary>The final exit code of this task. This is the code that will be produced upon task completion.</summary>
        /// <value>The exit code.</value>
        /// <since_tizen> 6 </since_tizen>
        public int ExitCode {
            get { return GetExitCode(); }
        }

        /// <summary>Flags to further customize task&apos;s behavior.</summary>
        /// <value>Desired task flags.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.TaskFlags Flags {
            get { return GetFlags(); }
            set { SetFlags(value); }
        }

        private static IntPtr GetCoreUIClassStatic()
        {
            return CoreUI.Task.efl_task_class_get();
        }

        /// <summary>Wrapper for native methods and virtual method delegates.
        /// For internal use by generated code only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal new class NativeMethods : CoreUI.LoopConsumer.NativeMethods
        {
            private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.Ecore);

            /// <summary>Gets the list of Eo operations to override.
        /// </summary>
            /// <returns>The list of Eo operations to be overload.</returns>
            internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
            {
                var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
                var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

                if (efl_task_priority_get_static_delegate == null)
                {
                    efl_task_priority_get_static_delegate = new efl_task_priority_get_delegate(priority_get);
                }

                if (methods.Contains("GetPriority"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_task_priority_get"), func = Marshal.GetFunctionPointerForDelegate(efl_task_priority_get_static_delegate) });
                }

                if (efl_task_priority_set_static_delegate == null)
                {
                    efl_task_priority_set_static_delegate = new efl_task_priority_set_delegate(priority_set);
                }

                if (methods.Contains("SetPriority"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_task_priority_set"), func = Marshal.GetFunctionPointerForDelegate(efl_task_priority_set_static_delegate) });
                }

                if (efl_task_exit_code_get_static_delegate == null)
                {
                    efl_task_exit_code_get_static_delegate = new efl_task_exit_code_get_delegate(exit_code_get);
                }

                if (methods.Contains("GetExitCode"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_task_exit_code_get"), func = Marshal.GetFunctionPointerForDelegate(efl_task_exit_code_get_static_delegate) });
                }

                if (efl_task_flags_get_static_delegate == null)
                {
                    efl_task_flags_get_static_delegate = new efl_task_flags_get_delegate(flags_get);
                }

                if (methods.Contains("GetFlags"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_task_flags_get"), func = Marshal.GetFunctionPointerForDelegate(efl_task_flags_get_static_delegate) });
                }

                if (efl_task_flags_set_static_delegate == null)
                {
                    efl_task_flags_set_static_delegate = new efl_task_flags_set_delegate(flags_set);
                }

                if (methods.Contains("SetFlags"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_task_flags_set"), func = Marshal.GetFunctionPointerForDelegate(efl_task_flags_set_static_delegate) });
                }

                if (efl_task_run_static_delegate == null)
                {
                    efl_task_run_static_delegate = new efl_task_run_delegate(run);
                }

                if (methods.Contains("Run"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_task_run"), func = Marshal.GetFunctionPointerForDelegate(efl_task_run_static_delegate) });
                }

                if (efl_task_end_static_delegate == null)
                {
                    efl_task_end_static_delegate = new efl_task_end_delegate(end);
                }

                if (methods.Contains("End"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_task_end"), func = Marshal.GetFunctionPointerForDelegate(efl_task_end_static_delegate) });
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
                return CoreUI.Task.efl_task_class_get();
            }

            #pragma warning disable CA1707, CS1591, SA1300, SA1600

            
            private delegate CoreUI.TaskPriority efl_task_priority_get_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate CoreUI.TaskPriority efl_task_priority_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_task_priority_get_api_delegate> efl_task_priority_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_task_priority_get_api_delegate>(Module, "efl_task_priority_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static CoreUI.TaskPriority priority_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_task_priority_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.TaskPriority _ret_var = default(CoreUI.TaskPriority);
                    try
                    {
                        _ret_var = ((Task)ws.Target).GetPriority();
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
                    return efl_task_priority_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_task_priority_get_delegate efl_task_priority_get_static_delegate;

            
            private delegate void efl_task_priority_set_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.TaskPriority priority);

            
            internal delegate void efl_task_priority_set_api_delegate(System.IntPtr obj,  CoreUI.TaskPriority priority);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_task_priority_set_api_delegate> efl_task_priority_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_task_priority_set_api_delegate>(Module, "efl_task_priority_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void priority_set(System.IntPtr obj, System.IntPtr pd, CoreUI.TaskPriority priority)
            {
                CoreUI.DataTypes.Log.Debug("function efl_task_priority_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Task)ws.Target).SetPriority(priority);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_task_priority_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), priority);
                }
            }

            private static efl_task_priority_set_delegate efl_task_priority_set_static_delegate;

            
            private delegate int efl_task_exit_code_get_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate int efl_task_exit_code_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_task_exit_code_get_api_delegate> efl_task_exit_code_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_task_exit_code_get_api_delegate>(Module, "efl_task_exit_code_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static int exit_code_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_task_exit_code_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    int _ret_var = default(int);
                    try
                    {
                        _ret_var = ((Task)ws.Target).GetExitCode();
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
                    return efl_task_exit_code_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_task_exit_code_get_delegate efl_task_exit_code_get_static_delegate;

            
            private delegate CoreUI.TaskFlags efl_task_flags_get_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate CoreUI.TaskFlags efl_task_flags_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_task_flags_get_api_delegate> efl_task_flags_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_task_flags_get_api_delegate>(Module, "efl_task_flags_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static CoreUI.TaskFlags flags_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_task_flags_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.TaskFlags _ret_var = default(CoreUI.TaskFlags);
                    try
                    {
                        _ret_var = ((Task)ws.Target).GetFlags();
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
                    return efl_task_flags_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_task_flags_get_delegate efl_task_flags_get_static_delegate;

            
            private delegate void efl_task_flags_set_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.TaskFlags flags);

            
            internal delegate void efl_task_flags_set_api_delegate(System.IntPtr obj,  CoreUI.TaskFlags flags);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_task_flags_set_api_delegate> efl_task_flags_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_task_flags_set_api_delegate>(Module, "efl_task_flags_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void flags_set(System.IntPtr obj, System.IntPtr pd, CoreUI.TaskFlags flags)
            {
                CoreUI.DataTypes.Log.Debug("function efl_task_flags_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Task)ws.Target).SetFlags(flags);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_task_flags_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), flags);
                }
            }

            private static efl_task_flags_set_delegate efl_task_flags_set_static_delegate;

            [return: MarshalAs(UnmanagedType.U1)]
            private delegate bool efl_task_run_delegate(System.IntPtr obj, System.IntPtr pd);

            [return: MarshalAs(UnmanagedType.U1)]
            internal delegate bool efl_task_run_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_task_run_api_delegate> efl_task_run_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_task_run_api_delegate>(Module, "efl_task_run");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static bool run(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_task_run was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    bool _ret_var = default(bool);
                    try
                    {
                        _ret_var = ((Task)ws.Target).Run();
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
                    return efl_task_run_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_task_run_delegate efl_task_run_static_delegate;

            
            private delegate void efl_task_end_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate void efl_task_end_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_task_end_api_delegate> efl_task_end_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_task_end_api_delegate>(Module, "efl_task_end");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void end(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_task_end was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Task)ws.Target).End();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_task_end_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_task_end_delegate efl_task_end_static_delegate;

            #pragma warning restore CA1707, CS1591, SA1300, SA1600

        }
    }
}

namespace CoreUI {
#pragma warning disable CS1591
    /// <since_tizen> 6 </since_tizen>
    public static class TaskExtensions {
        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.TaskPriority> Priority<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Task, T>magic = null) where T : CoreUI.Task {
            return new CoreUI.BindableProperty<CoreUI.TaskPriority>("priority", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.TaskFlags> Flags<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Task, T>magic = null) where T : CoreUI.Task {
            return new CoreUI.BindableProperty<CoreUI.TaskFlags>("flags", fac.GetPropBind());
        }

    }
#pragma warning restore CS1591
}

namespace CoreUI {
    /// <summary>How much processor time will this task get compared to other tasks running on the same processor.</summary>
    /// <since_tizen> 6 </since_tizen>
    
    [CoreUI.Wrapper.BindingEntity]
    public enum TaskPriority
    {
        /// <summary>Neither above nor below average priority. This is the default.</summary>
        /// <since_tizen> 6 </since_tizen>
        Normal = 0,
        /// <summary>Far below average priority.</summary>
        /// <since_tizen> 6 </since_tizen>
        Background = 1,
        /// <summary>Below average priority.</summary>
        /// <since_tizen> 6 </since_tizen>
        Low = 2,
        /// <summary>Above average priority.</summary>
        /// <since_tizen> 6 </since_tizen>
        High = 3,
        /// <summary>Far above average priority.</summary>
        /// <since_tizen> 6 </since_tizen>
        Ultra = 4,
    }
}

namespace CoreUI {
    /// <summary>Flags to further customize task&apos;s behavior.</summary>
    /// <since_tizen> 6 </since_tizen>
    [Flags]
    [CoreUI.Wrapper.BindingEntity]
    public enum TaskFlags
    {
        /// <summary>No special flags.</summary>
        /// <since_tizen> 6 </since_tizen>
        None = 0,
        /// <summary>Task will require console input.</summary>
        /// <since_tizen> 6 </since_tizen>
        UseStdin = 1,
        /// <summary>Task will require console output.</summary>
        /// <since_tizen> 6 </since_tizen>
        UseStdout = 2,
        /// <summary>Task will not produce an exit code upon termination.</summary>
        /// <since_tizen> 6 </since_tizen>
        NoExitCodeError = 4,
        /// <summary>Exit when parent exits.</summary>
        /// <since_tizen> 6 </since_tizen>
        ExitWithParent = 8,
    }
}

