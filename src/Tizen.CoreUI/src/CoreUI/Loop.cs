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
    /// <summary>Event argument wrapper for event <see cref="CoreUI.Loop.Arguments"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Wrapper.BindingEntity]
    public class LoopArgumentsEventArgs : EventArgs {
        /// <summary>Actual event payload.
        /// </summary>
        /// <value>Event happens when args are provided to the loop by args_add().</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.LoopArguments Arg { get; set; }
    }

    /// <summary>The CoreUI Main Loop
    /// 
    /// The CoreUI main loop provides a clean and tiny event loop library with many modules to do lots of convenient things for a programmer, saving time and effort. It&apos;s lean and designed to work on anything from embedded systems all the way up to large and powerful multi-cpu workstations. The main loop has a number of primitives you can use. It serializes these and allows for greater responsiveness without the need for threads (or any other concurrency). However you can provide these if you need to.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Loop.NativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public abstract class Loop : CoreUI.Task
    {
        /// <summary>Pointer to the native class description.</summary>
        public override System.IntPtr NativeClass
        {
            get
            {
                if (((object)this).GetType() == typeof(Loop))
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
            efl_loop_class_get();

        /// <summary>Initializes a new instance of the <see cref="Loop"/> class.
        /// </summary>
        /// <param name="parent">Parent instance.</param>
        public Loop(CoreUI.Object parent= null) : base(efl_loop_class_get(), parent)
        {
            FinishInstantiation();
        }

        /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
        /// Do not call this constructor directly.
        /// </summary>
        /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
        protected Loop(ConstructingHandle ch) : base(ch)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="Loop"/> class.
        /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.
        /// </summary>
        /// <param name="wh">The native pointer to be wrapped.</param>
        internal Loop(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
        {
        }

        [CoreUI.Wrapper.PrivateNativeClass]
        private class LoopRealized : Loop
        {
            private LoopRealized(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
            {
            }
        }
        /// <summary>Initializes a new instance of the <see cref="Loop"/> class.
        /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.
        /// </summary>
        /// <param name="baseKlass">The pointer to the base native Eo class.</param>
        /// <param name="parent">The CoreUI.Object parent of this instance.</param>
        protected Loop(IntPtr baseKlass, CoreUI.Object parent) : base(baseKlass, parent)
        {
        }

        /// <summary>Event occurs once the main loop enters the idle state.</summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler IdleEnter
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value);
                string key = "_EFL_LOOP_EVENT_IDLE_ENTER";
                AddNativeEventHandler(CoreUI.Libs.Ecore, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_LOOP_EVENT_IDLE_ENTER";
                RemoveNativeEventHandler(CoreUI.Libs.Ecore, key, value);
            }
        }

        /// <summary>Method to raise event IdleEnter.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnIdleEnter()
        {
            CallNativeEventCallback(CoreUI.Libs.Ecore, "_EFL_LOOP_EVENT_IDLE_ENTER", IntPtr.Zero, null);
        }

        /// <summary>Event occurs once the main loop exits the idle state.</summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler IdleExit
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value);
                string key = "_EFL_LOOP_EVENT_IDLE_EXIT";
                AddNativeEventHandler(CoreUI.Libs.Ecore, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_LOOP_EVENT_IDLE_EXIT";
                RemoveNativeEventHandler(CoreUI.Libs.Ecore, key, value);
            }
        }

        /// <summary>Method to raise event IdleExit.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnIdleExit()
        {
            CallNativeEventCallback(CoreUI.Libs.Ecore, "_EFL_LOOP_EVENT_IDLE_EXIT", IntPtr.Zero, null);
        }

        /// <summary>Event happens when args are provided to the loop by args_add().</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.LoopArgumentsEventArgs"/></value>
        public event EventHandler<CoreUI.LoopArgumentsEventArgs> Arguments
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.LoopArgumentsEventArgs{ Arg =  info });
                string key = "_EFL_LOOP_EVENT_ARGUMENTS";
                AddNativeEventHandler(CoreUI.Libs.Ecore, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_LOOP_EVENT_ARGUMENTS";
                RemoveNativeEventHandler(CoreUI.Libs.Ecore, key, value);
            }
        }

        /// <summary>Method to raise event Arguments.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnArguments(CoreUI.LoopArgumentsEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = Marshal.AllocHGlobal(Marshal.SizeOf(e.Arg));
            CallNativeEventCallback(CoreUI.Libs.Ecore, "_EFL_LOOP_EVENT_ARGUMENTS", info, (p) => Marshal.FreeHGlobal(p));
        }

        /// <summary>Event occurs multiple times per second. The exact tick is undefined and can be adjusted system-wide.</summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler PollHigh
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value);
                string key = "_EFL_LOOP_EVENT_POLL_HIGH";
                AddNativeEventHandler(CoreUI.Libs.Ecore, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_LOOP_EVENT_POLL_HIGH";
                RemoveNativeEventHandler(CoreUI.Libs.Ecore, key, value);
            }
        }

        /// <summary>Method to raise event PollHigh.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnPollHigh()
        {
            CallNativeEventCallback(CoreUI.Libs.Ecore, "_EFL_LOOP_EVENT_POLL_HIGH", IntPtr.Zero, null);
        }

        /// <summary>Event occurs multiple times per minute. The exact tick is undefined and can be adjusted system-wide.</summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler PollMedium
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value);
                string key = "_EFL_LOOP_EVENT_POLL_MEDIUM";
                AddNativeEventHandler(CoreUI.Libs.Ecore, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_LOOP_EVENT_POLL_MEDIUM";
                RemoveNativeEventHandler(CoreUI.Libs.Ecore, key, value);
            }
        }

        /// <summary>Method to raise event PollMedium.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnPollMedium()
        {
            CallNativeEventCallback(CoreUI.Libs.Ecore, "_EFL_LOOP_EVENT_POLL_MEDIUM", IntPtr.Zero, null);
        }

        /// <summary>Event occurs multiple times every 15 minutes. The exact tick is undefined and can be adjusted system-wide.</summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler PollLow
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value);
                string key = "_EFL_LOOP_EVENT_POLL_LOW";
                AddNativeEventHandler(CoreUI.Libs.Ecore, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_LOOP_EVENT_POLL_LOW";
                RemoveNativeEventHandler(CoreUI.Libs.Ecore, key, value);
            }
        }

        /// <summary>Method to raise event PollLow.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnPollLow()
        {
            CallNativeEventCallback(CoreUI.Libs.Ecore, "_EFL_LOOP_EVENT_POLL_LOW", IntPtr.Zero, null);
        }


        /// <summary>Slow down the loop execution by forcing sleep for a small period of time every time the loop iterates/loops.</summary>
        /// <returns>Time to sleep for each &quot;loop iteration&quot;</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual double GetThrottle() {
            var _ret_var = CoreUI.Loop.NativeMethods.efl_loop_throttle_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Slow down the loop execution by forcing sleep for a small period of time every time the loop iterates/loops.</summary>
        /// <param name="amount">Time to sleep for each &quot;loop iteration&quot;</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetThrottle(double amount) {
            CoreUI.Loop.NativeMethods.efl_loop_throttle_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), amount);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Retrieves the time at which the last loop stopped waiting for timeouts or events.<br/>
        /// <b>Note:</b> This gets the time that the main loop ceased waiting for timouts and/or events to come in or for signals or any other interrupt source. This should be considered a reference point for all time based activity that should calculate its timepoint from the return of ecore_loop_time_get(). Note that this time is meant to be used as relative to other times obtained on this run. If you need absolute time references, use a unix timestamp instead.</summary>
        /// <returns>Time in seconds</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual double GetTime() {
            var _ret_var = CoreUI.Loop.NativeMethods.efl_loop_time_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Retrieves the time at which the last loop stopped waiting for timeouts or events.<br/>
        /// <b>Note:</b> You should never need/call this, unless you are implementing a custom tick source for an animator.
        /// 
        /// <b>NOTE: </b>The time point must match whatever zero time you get from ecore_time_get() and <see cref="CoreUI.Loop.GetTime"/> (same 0 point). What this point is is undefined, so unless your source uses the same 0 time, then you may have to adjust and do some guessing.</summary>
        /// <param name="timepoint">Time in seconds</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void SetTime(double timepoint) {
            CoreUI.Loop.NativeMethods.efl_loop_time_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), timepoint);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Runs a single iteration of the main loop to process everything on the queue.</summary>
        /// <since_tizen> 6 </since_tizen>
        public virtual void Iterate() {
            CoreUI.Loop.NativeMethods.efl_loop_iterate_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Runs a single iteration of the main loop to process everything on the queue with block/non-blocking status.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="may_block">A flag if the main loop has a possibility of blocking.</param>
        /// <returns>Return from single iteration run</returns>
        public virtual int IterateMayBlock(int may_block) {
            var _ret_var = CoreUI.Loop.NativeMethods.efl_loop_iterate_may_block_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), may_block);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Runs the application main loop.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <returns>Value set by quit()</returns>
        public virtual CoreUI.DataTypes.Value Begin() {
            var _ret_var = CoreUI.Loop.NativeMethods.efl_loop_begin_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Quits the main loop once all the events currently on the queue have been processed.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="exit_code">Returned value by begin()</param>
        public virtual void Quit(CoreUI.DataTypes.Value exit_code) {
            Contract.Requires(exit_code != null, nameof(exit_code));
var _in_exit_code = exit_code.GetNative();
CoreUI.Loop.NativeMethods.efl_loop_quit_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), _in_exit_code);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>A future promise that will be resolved from a clean main loop context as soon as possible.
        /// 
        /// This has higher priority, for low priority use <see cref="CoreUI.Loop.Idle"/></summary>
        /// <since_tizen> 6 </since_tizen>
        /// <returns>The future handle.</returns>
        public virtual  CoreUI.DataTypes.Future Job() {
            var _ret_var = CoreUI.Loop.NativeMethods.efl_loop_job_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>A future promise that will be resolved from a clean main loop context as soon as the main loop is idle.
        /// 
        /// This is a low priority version of <see cref="CoreUI.Loop.Job"/></summary>
        /// <since_tizen> 6 </since_tizen>
        /// <returns>The future handle.</returns>
        public virtual  CoreUI.DataTypes.Future Idle() {
            var _ret_var = CoreUI.Loop.NativeMethods.efl_loop_idle_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>A future promise that will be resolved from a clean main loop context after <c>time</c> seconds.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="time">The time from now in second that the main loop will wait before triggering it.</param>
        /// <returns>The future handle.</returns>
        public virtual  CoreUI.DataTypes.Future Timeout(double time) {
            var _ret_var = CoreUI.Loop.NativeMethods.efl_loop_timeout_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), time);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Async wrapper for <see cref="Job" />.
        /// </summary>
        /// <param name="token">Token to notify the async operation of external request to cancel.</param>
        /// <returns>An async task wrapping the result of the operation.</returns>
        public System.Threading.Tasks.Task<CoreUI.DataTypes.Value> JobAsync( System.Threading.CancellationToken token = default(System.Threading.CancellationToken))
        {
            CoreUI.DataTypes.Future future = Job();
            return CoreUI.Wrapper.Globals.WrapAsync(future, token);
        }

        /// <summary>Async wrapper for <see cref="Idle" />.
        /// </summary>
        /// <param name="token">Token to notify the async operation of external request to cancel.</param>
        /// <returns>An async task wrapping the result of the operation.</returns>
        public System.Threading.Tasks.Task<CoreUI.DataTypes.Value> IdleAsync( System.Threading.CancellationToken token = default(System.Threading.CancellationToken))
        {
            CoreUI.DataTypes.Future future = Idle();
            return CoreUI.Wrapper.Globals.WrapAsync(future, token);
        }

        /// <summary>Async wrapper for <see cref="Timeout" />.
        /// </summary>
    /// <param name="time">The time from now in second that the main loop will wait before triggering it.</param>
        /// <param name="token">Token to notify the async operation of external request to cancel.</param>
        /// <returns>An async task wrapping the result of the operation.</returns>
        public System.Threading.Tasks.Task<CoreUI.DataTypes.Value> TimeoutAsync(double time,  System.Threading.CancellationToken token = default(System.Threading.CancellationToken))
        {
            CoreUI.DataTypes.Future future = Timeout( time);
            return CoreUI.Wrapper.Globals.WrapAsync(future, token);
        }

        /// <summary>Slow down the loop execution by forcing sleep for a small period of time every time the loop iterates/loops.</summary>
        /// <value>Time to sleep for each &quot;loop iteration&quot;</value>
        /// <since_tizen> 6 </since_tizen>
        public double Throttle {
            get { return GetThrottle(); }
            set { SetThrottle(value); }
        }

        /// <summary>Retrieves the time at which the last loop stopped waiting for timeouts or events.<br/>
        /// <b>Note on writing:</b> You should never need/call this, unless you are implementing a custom tick source for an animator.
        /// 
        /// <b>NOTE: </b>The time point must match whatever zero time you get from ecore_time_get() and <see cref="CoreUI.Loop.GetTime"/> (same 0 point). What this point is is undefined, so unless your source uses the same 0 time, then you may have to adjust and do some guessing.<br/>
        /// <b>Note on reading:</b> This gets the time that the main loop ceased waiting for timouts and/or events to come in or for signals or any other interrupt source. This should be considered a reference point for all time based activity that should calculate its timepoint from the return of ecore_loop_time_get(). Note that this time is meant to be used as relative to other times obtained on this run. If you need absolute time references, use a unix timestamp instead.</summary>
        /// <value>Time in seconds</value>
        /// <since_tizen> 6 </since_tizen>
        public double Time {
            get { return GetTime(); }
            protected set { SetTime(value); }
        }

        private static IntPtr GetCoreUIClassStatic()
        {
            return CoreUI.Loop.efl_loop_class_get();
        }

        /// <summary>Wrapper for native methods and virtual method delegates.
        /// For internal use by generated code only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal new class NativeMethods : CoreUI.Task.NativeMethods
        {
            private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.Ecore);

            /// <summary>Gets the list of Eo operations to override.
        /// </summary>
            /// <returns>The list of Eo operations to be overload.</returns>
            internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
            {
                var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
                var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

                if (efl_loop_throttle_get_static_delegate == null)
                {
                    efl_loop_throttle_get_static_delegate = new efl_loop_throttle_get_delegate(throttle_get);
                }

                if (methods.Contains("GetThrottle"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_loop_throttle_get"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_throttle_get_static_delegate) });
                }

                if (efl_loop_throttle_set_static_delegate == null)
                {
                    efl_loop_throttle_set_static_delegate = new efl_loop_throttle_set_delegate(throttle_set);
                }

                if (methods.Contains("SetThrottle"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_loop_throttle_set"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_throttle_set_static_delegate) });
                }

                if (efl_loop_time_get_static_delegate == null)
                {
                    efl_loop_time_get_static_delegate = new efl_loop_time_get_delegate(time_get);
                }

                if (methods.Contains("GetTime"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_loop_time_get"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_time_get_static_delegate) });
                }

                if (efl_loop_time_set_static_delegate == null)
                {
                    efl_loop_time_set_static_delegate = new efl_loop_time_set_delegate(time_set);
                }

                if (methods.Contains("SetTime"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_loop_time_set"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_time_set_static_delegate) });
                }

                if (efl_loop_iterate_static_delegate == null)
                {
                    efl_loop_iterate_static_delegate = new efl_loop_iterate_delegate(iterate);
                }

                if (methods.Contains("Iterate"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_loop_iterate"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_iterate_static_delegate) });
                }

                if (efl_loop_iterate_may_block_static_delegate == null)
                {
                    efl_loop_iterate_may_block_static_delegate = new efl_loop_iterate_may_block_delegate(iterate_may_block);
                }

                if (methods.Contains("IterateMayBlock"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_loop_iterate_may_block"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_iterate_may_block_static_delegate) });
                }

                if (efl_loop_begin_static_delegate == null)
                {
                    efl_loop_begin_static_delegate = new efl_loop_begin_delegate(begin);
                }

                if (methods.Contains("Begin"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_loop_begin"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_begin_static_delegate) });
                }

                if (efl_loop_quit_static_delegate == null)
                {
                    efl_loop_quit_static_delegate = new efl_loop_quit_delegate(quit);
                }

                if (methods.Contains("Quit"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_loop_quit"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_quit_static_delegate) });
                }

                if (efl_loop_job_static_delegate == null)
                {
                    efl_loop_job_static_delegate = new efl_loop_job_delegate(job);
                }

                if (methods.Contains("Job"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_loop_job"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_job_static_delegate) });
                }

                if (efl_loop_idle_static_delegate == null)
                {
                    efl_loop_idle_static_delegate = new efl_loop_idle_delegate(idle);
                }

                if (methods.Contains("Idle"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_loop_idle"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_idle_static_delegate) });
                }

                if (efl_loop_timeout_static_delegate == null)
                {
                    efl_loop_timeout_static_delegate = new efl_loop_timeout_delegate(timeout);
                }

                if (methods.Contains("Timeout"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_loop_timeout"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_timeout_static_delegate) });
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
                return CoreUI.Loop.efl_loop_class_get();
            }

            #pragma warning disable CA1707, CS1591, SA1300, SA1600

            
            private delegate double efl_loop_throttle_get_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate double efl_loop_throttle_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_loop_throttle_get_api_delegate> efl_loop_throttle_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_loop_throttle_get_api_delegate>(Module, "efl_loop_throttle_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static double throttle_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_loop_throttle_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    double _ret_var = default(double);
                    try
                    {
                        _ret_var = ((Loop)ws.Target).GetThrottle();
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
                    return efl_loop_throttle_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_loop_throttle_get_delegate efl_loop_throttle_get_static_delegate;

            
            private delegate void efl_loop_throttle_set_delegate(System.IntPtr obj, System.IntPtr pd,  double amount);

            
            internal delegate void efl_loop_throttle_set_api_delegate(System.IntPtr obj,  double amount);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_loop_throttle_set_api_delegate> efl_loop_throttle_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_loop_throttle_set_api_delegate>(Module, "efl_loop_throttle_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void throttle_set(System.IntPtr obj, System.IntPtr pd, double amount)
            {
                CoreUI.DataTypes.Log.Debug("function efl_loop_throttle_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Loop)ws.Target).SetThrottle(amount);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_loop_throttle_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), amount);
                }
            }

            private static efl_loop_throttle_set_delegate efl_loop_throttle_set_static_delegate;

            
            private delegate double efl_loop_time_get_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate double efl_loop_time_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_loop_time_get_api_delegate> efl_loop_time_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_loop_time_get_api_delegate>(Module, "efl_loop_time_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static double time_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_loop_time_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    double _ret_var = default(double);
                    try
                    {
                        _ret_var = ((Loop)ws.Target).GetTime();
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
                    return efl_loop_time_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_loop_time_get_delegate efl_loop_time_get_static_delegate;

            
            private delegate void efl_loop_time_set_delegate(System.IntPtr obj, System.IntPtr pd,  double timepoint);

            
            internal delegate void efl_loop_time_set_api_delegate(System.IntPtr obj,  double timepoint);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_loop_time_set_api_delegate> efl_loop_time_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_loop_time_set_api_delegate>(Module, "efl_loop_time_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void time_set(System.IntPtr obj, System.IntPtr pd, double timepoint)
            {
                CoreUI.DataTypes.Log.Debug("function efl_loop_time_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Loop)ws.Target).SetTime(timepoint);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_loop_time_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), timepoint);
                }
            }

            private static efl_loop_time_set_delegate efl_loop_time_set_static_delegate;

            
            private delegate void efl_loop_iterate_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate void efl_loop_iterate_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_loop_iterate_api_delegate> efl_loop_iterate_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_loop_iterate_api_delegate>(Module, "efl_loop_iterate");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void iterate(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_loop_iterate was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Loop)ws.Target).Iterate();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_loop_iterate_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_loop_iterate_delegate efl_loop_iterate_static_delegate;

            
            private delegate int efl_loop_iterate_may_block_delegate(System.IntPtr obj, System.IntPtr pd,  int may_block);

            
            internal delegate int efl_loop_iterate_may_block_api_delegate(System.IntPtr obj,  int may_block);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_loop_iterate_may_block_api_delegate> efl_loop_iterate_may_block_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_loop_iterate_may_block_api_delegate>(Module, "efl_loop_iterate_may_block");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static int iterate_may_block(System.IntPtr obj, System.IntPtr pd, int may_block)
            {
                CoreUI.DataTypes.Log.Debug("function efl_loop_iterate_may_block was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    int _ret_var = default(int);
                    try
                    {
                        _ret_var = ((Loop)ws.Target).IterateMayBlock(may_block);
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
                    return efl_loop_iterate_may_block_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), may_block);
                }
            }

            private static efl_loop_iterate_may_block_delegate efl_loop_iterate_may_block_static_delegate;

            [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.DataTypes.ValueMarshaler))]
            private delegate CoreUI.DataTypes.Value efl_loop_begin_delegate(System.IntPtr obj, System.IntPtr pd);

            [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.DataTypes.ValueMarshaler))]
            internal delegate CoreUI.DataTypes.Value efl_loop_begin_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_loop_begin_api_delegate> efl_loop_begin_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_loop_begin_api_delegate>(Module, "efl_loop_begin");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static CoreUI.DataTypes.Value begin(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_loop_begin was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.DataTypes.Value _ret_var = default(CoreUI.DataTypes.Value);
                    try
                    {
                        _ret_var = ((Loop)ws.Target).Begin();
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
                    return efl_loop_begin_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_loop_begin_delegate efl_loop_begin_static_delegate;

            
            private delegate void efl_loop_quit_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.DataTypes.ValueNative exit_code);

            
            internal delegate void efl_loop_quit_api_delegate(System.IntPtr obj,  CoreUI.DataTypes.ValueNative exit_code);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_loop_quit_api_delegate> efl_loop_quit_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_loop_quit_api_delegate>(Module, "efl_loop_quit");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void quit(System.IntPtr obj, System.IntPtr pd, CoreUI.DataTypes.ValueNative exit_code)
            {
                CoreUI.DataTypes.Log.Debug("function efl_loop_quit was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    var _in_exit_code = new CoreUI.DataTypes.Value(exit_code);

                    try
                    {
                        ((Loop)ws.Target).Quit(_in_exit_code);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_loop_quit_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), exit_code);
                }
            }

            private static efl_loop_quit_delegate efl_loop_quit_static_delegate;

            [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.DataTypes.FutureMarshaler))]
            private delegate  CoreUI.DataTypes.Future efl_loop_job_delegate(System.IntPtr obj, System.IntPtr pd);

            [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.DataTypes.FutureMarshaler))]
            internal delegate  CoreUI.DataTypes.Future efl_loop_job_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_loop_job_api_delegate> efl_loop_job_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_loop_job_api_delegate>(Module, "efl_loop_job");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static  CoreUI.DataTypes.Future job(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_loop_job was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                     CoreUI.DataTypes.Future _ret_var = default( CoreUI.DataTypes.Future);
                    try
                    {
                        _ret_var = ((Loop)ws.Target).Job();
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
                    return efl_loop_job_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_loop_job_delegate efl_loop_job_static_delegate;

            [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.DataTypes.FutureMarshaler))]
            private delegate  CoreUI.DataTypes.Future efl_loop_idle_delegate(System.IntPtr obj, System.IntPtr pd);

            [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.DataTypes.FutureMarshaler))]
            internal delegate  CoreUI.DataTypes.Future efl_loop_idle_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_loop_idle_api_delegate> efl_loop_idle_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_loop_idle_api_delegate>(Module, "efl_loop_idle");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static  CoreUI.DataTypes.Future idle(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_loop_idle was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                     CoreUI.DataTypes.Future _ret_var = default( CoreUI.DataTypes.Future);
                    try
                    {
                        _ret_var = ((Loop)ws.Target).Idle();
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
                    return efl_loop_idle_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_loop_idle_delegate efl_loop_idle_static_delegate;

            [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.DataTypes.FutureMarshaler))]
            private delegate  CoreUI.DataTypes.Future efl_loop_timeout_delegate(System.IntPtr obj, System.IntPtr pd,  double time);

            [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.DataTypes.FutureMarshaler))]
            internal delegate  CoreUI.DataTypes.Future efl_loop_timeout_api_delegate(System.IntPtr obj,  double time);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_loop_timeout_api_delegate> efl_loop_timeout_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_loop_timeout_api_delegate>(Module, "efl_loop_timeout");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static  CoreUI.DataTypes.Future timeout(System.IntPtr obj, System.IntPtr pd, double time)
            {
                CoreUI.DataTypes.Log.Debug("function efl_loop_timeout was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                     CoreUI.DataTypes.Future _ret_var = default( CoreUI.DataTypes.Future);
                    try
                    {
                        _ret_var = ((Loop)ws.Target).Timeout(time);
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
                    return efl_loop_timeout_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), time);
                }
            }

            private static efl_loop_timeout_delegate efl_loop_timeout_static_delegate;

            #pragma warning restore CA1707, CS1591, SA1300, SA1600

        }
    }
}

namespace CoreUI {
#pragma warning disable CS1591
    /// <since_tizen> 6 </since_tizen>
    public static class LoopExtensions {
        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<double> Throttle<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Loop, T>magic = null) where T : CoreUI.Loop {
            return new CoreUI.BindableProperty<double>("throttle", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<double> Time<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Loop, T>magic = null) where T : CoreUI.Loop {
            return new CoreUI.BindableProperty<double>("time", fac.GetPropBind());
        }

    }
#pragma warning restore CS1591
}

namespace CoreUI {
    /// <summary>EFL loop arguments data structure</summary>
    /// <since_tizen> 6 </since_tizen>
    [StructLayout(LayoutKind.Sequential)]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public struct LoopArguments : IEquatable<LoopArguments>
    {
        
        private System.IntPtr argv;
        /// <summary>Internal wrapper for field initialization</summary>
        private System.Byte initialization;

        /// <summary>Array with loop arguments</summary>
        /// <since_tizen> 6 </since_tizen>
        public IList<CoreUI.DataTypes.Stringshare> Argv { get => CoreUI.Wrapper.Globals.NativeArrayToIList<CoreUI.DataTypes.Stringshare>(argv); }
        /// <summary>Set to <c>true</c> when the program should initialize its internal state. This happens once per process instance.</summary>
        /// <since_tizen> 6 </since_tizen>
        public bool Initialization { get => initialization != 0; }
        /// <summary>Constructor for LoopArguments.
        /// </summary>
        /// <param name="argv">Array with loop arguments</param>
        /// <param name="initialization">Set to <c>true</c> when the program should initialize its internal state. This happens once per process instance.</param>
        /// <since_tizen> 6 </since_tizen>
        public LoopArguments(
            IList<CoreUI.DataTypes.Stringshare> argv = default(IList<CoreUI.DataTypes.Stringshare>),
            bool initialization = default(bool))
        {
            this.argv = CoreUI.Wrapper.Globals.IListToNativeArray(argv, false);
            this.initialization = initialization ? (byte)1 : (byte)0;
        }

        /// <summary>Packs tuple into LoopArguments object.
        ///<para>Since EFL 1.24.</para>
        ///</summary>
        public static implicit operator LoopArguments((IList<CoreUI.DataTypes.Stringshare> argv, bool initialization) tuple)
            => new LoopArguments(tuple.argv, tuple.initialization);

        /// <summary>Unpacks LoopArguments into tuple.
        /// <para>Since EFL 1.24.</para>
        /// </summary>
        public void Deconstruct(
            out IList<CoreUI.DataTypes.Stringshare> argv,
            out bool initialization
        )
        {
            argv = this.Argv;
            initialization = this.Initialization;
        }
        /// <summary>Get a hash code for this item.
        /// </summary>
        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + Argv.GetHashCode();
            hash = hash * 23 + Initialization.GetHashCode();
            return hash;
        }
        /// <summary>Equality comparison.
        /// </summary>
        public bool Equals(LoopArguments other)
        {
            return Argv == other.Argv && Initialization == other.Initialization;
        }
        /// <summary>Equality comparison.
        /// </summary>
        public override bool Equals(object other)
            => ((other is LoopArguments) ? Equals((LoopArguments)other) : false);
        /// <summary>Equality comparison.
        /// </summary>
        public static bool operator ==(LoopArguments lhs, LoopArguments rhs)
            => lhs.Equals(rhs);        /// <summary>Equality comparison.
        /// </summary>
        public static bool operator !=(LoopArguments lhs, LoopArguments rhs)
            => !lhs.Equals(rhs);        /// <summary>Implicit conversion to the managed representation from a native pointer.
        /// </summary>
        /// <param name="ptr">Native pointer to be converted.</param>
        public static implicit operator LoopArguments(IntPtr ptr)
        {
            return (LoopArguments)Marshal.PtrToStructure(ptr, typeof(LoopArguments));
        }

        /// <summary>Conversion to the managed representation from a native pointer.
        /// </summary>
        /// <param name="ptr">Native pointer to be converted.</param>
        public static LoopArguments FromIntPtr(IntPtr ptr)
        {
            return ptr;
        }

    }

}

