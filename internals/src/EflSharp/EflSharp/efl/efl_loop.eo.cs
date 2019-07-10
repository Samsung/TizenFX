#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

///<summary>Event argument wrapper for event <see cref="Efl.Loop.ArgumentsEvt"/>.</summary>
public class LoopArgumentsEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Efl.LoopArguments arg { get; set; }
}
/// <summary>The Efl Main Loop
/// The Efl main loop provides a clean and tiny event loop library with many modules to do lots of convenient things for a programmer, saving time and effort. It&apos;s lean and designed to work on anything from embedded systems all the way up to large and powerful multi-cpu workstations. The main loop has a number of primitives you can use. It serializes these and allows for greater responsiveness without the need for threads (or any other concurrency). However you can provide these if you need to.
/// (Since EFL 1.22)</summary>
[Efl.Loop.NativeMethods]
public abstract class Loop : Efl.Task
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(Loop))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)] internal static extern System.IntPtr
        efl_loop_class_get();
    /// <summary>Initializes a new instance of the <see cref="Loop"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public Loop(Efl.Object parent= null
            ) : base(efl_loop_class_get(), typeof(Loop), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Initializes a new instance of the <see cref="Loop"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="raw">The native pointer to be wrapped.</param>
    protected Loop(System.IntPtr raw) : base(raw)
    {
    }

    [Efl.Eo.PrivateNativeClass]
    private class LoopRealized : Loop
    {
        private LoopRealized(IntPtr ptr) : base(ptr)
        {
        }
    }
    /// <summary>Initializes a new instance of the <see cref="Loop"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="managedType">The managed type of the public constructor that originated this call.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected Loop(IntPtr baseKlass, System.Type managedType, Efl.Object parent) : base(baseKlass, managedType, parent)
    {
    }

    /// <summary>Event occurs once the main loop enters the idle state.
    /// (Since EFL 1.22)</summary>
    public event EventHandler IdleEnterEvt
    {
        add
        {
            lock (eventLock)
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

                string key = "_EFL_LOOP_EVENT_IDLE_ENTER";
                AddNativeEventHandler(efl.Libs.Ecore, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_LOOP_EVENT_IDLE_ENTER";
                RemoveNativeEventHandler(efl.Libs.Ecore, key, value);
            }
        }
    }
    ///<summary>Method to raise event IdleEnterEvt.</summary>
    public void OnIdleEnterEvt(EventArgs e)
    {
        var key = "_EFL_LOOP_EVENT_IDLE_ENTER";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Ecore, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Event occurs once the main loop exits the idle state.
    /// (Since EFL 1.22)</summary>
    public event EventHandler IdleExitEvt
    {
        add
        {
            lock (eventLock)
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

                string key = "_EFL_LOOP_EVENT_IDLE_EXIT";
                AddNativeEventHandler(efl.Libs.Ecore, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_LOOP_EVENT_IDLE_EXIT";
                RemoveNativeEventHandler(efl.Libs.Ecore, key, value);
            }
        }
    }
    ///<summary>Method to raise event IdleExitEvt.</summary>
    public void OnIdleExitEvt(EventArgs e)
    {
        var key = "_EFL_LOOP_EVENT_IDLE_EXIT";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Ecore, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Event occurs once the main loop is idle. If you keep listening on this event it may increase the burden on your CPU.
    /// (Since EFL 1.22)</summary>
    public event EventHandler IdleEvt
    {
        add
        {
            lock (eventLock)
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

                string key = "_EFL_LOOP_EVENT_IDLE";
                AddNativeEventHandler(efl.Libs.Ecore, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_LOOP_EVENT_IDLE";
                RemoveNativeEventHandler(efl.Libs.Ecore, key, value);
            }
        }
    }
    ///<summary>Method to raise event IdleEvt.</summary>
    public void OnIdleEvt(EventArgs e)
    {
        var key = "_EFL_LOOP_EVENT_IDLE";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Ecore, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Event happens when args are provided to the loop by args_add().
    /// (Since EFL 1.22)</summary>
    public event EventHandler<Efl.LoopArgumentsEvt_Args> ArgumentsEvt
    {
        add
        {
            lock (eventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        Efl.LoopArgumentsEvt_Args args = new Efl.LoopArgumentsEvt_Args();
                        args.arg =  evt.Info;
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

                string key = "_EFL_LOOP_EVENT_ARGUMENTS";
                AddNativeEventHandler(efl.Libs.Ecore, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_LOOP_EVENT_ARGUMENTS";
                RemoveNativeEventHandler(efl.Libs.Ecore, key, value);
            }
        }
    }
    ///<summary>Method to raise event ArgumentsEvt.</summary>
    public void OnArgumentsEvt(Efl.LoopArgumentsEvt_Args e)
    {
        var key = "_EFL_LOOP_EVENT_ARGUMENTS";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Ecore, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = Marshal.AllocHGlobal(Marshal.SizeOf(e.arg));
        try
        {
            Marshal.StructureToPtr(e.arg, info, false);
            Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Marshal.FreeHGlobal(info);
        }
    }
    /// <summary>Event occurs multiple times per second. The exact tick is undefined and can be adjusted system wide.
    /// (Since EFL 1.22)</summary>
    public event EventHandler PollHighEvt
    {
        add
        {
            lock (eventLock)
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

                string key = "_EFL_LOOP_EVENT_POLL_HIGH";
                AddNativeEventHandler(efl.Libs.Ecore, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_LOOP_EVENT_POLL_HIGH";
                RemoveNativeEventHandler(efl.Libs.Ecore, key, value);
            }
        }
    }
    ///<summary>Method to raise event PollHighEvt.</summary>
    public void OnPollHighEvt(EventArgs e)
    {
        var key = "_EFL_LOOP_EVENT_POLL_HIGH";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Ecore, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Event occurs multiple times per minute. The exact tick is undefined and can be adjusted system wide.
    /// (Since EFL 1.22)</summary>
    public event EventHandler PollMediumEvt
    {
        add
        {
            lock (eventLock)
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

                string key = "_EFL_LOOP_EVENT_POLL_MEDIUM";
                AddNativeEventHandler(efl.Libs.Ecore, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_LOOP_EVENT_POLL_MEDIUM";
                RemoveNativeEventHandler(efl.Libs.Ecore, key, value);
            }
        }
    }
    ///<summary>Method to raise event PollMediumEvt.</summary>
    public void OnPollMediumEvt(EventArgs e)
    {
        var key = "_EFL_LOOP_EVENT_POLL_MEDIUM";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Ecore, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Event occurs multiple times every 15 minutes. The exact tick is undefined and can be adjusted system wide.
    /// (Since EFL 1.22)</summary>
    public event EventHandler PollLowEvt
    {
        add
        {
            lock (eventLock)
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

                string key = "_EFL_LOOP_EVENT_POLL_LOW";
                AddNativeEventHandler(efl.Libs.Ecore, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_LOOP_EVENT_POLL_LOW";
                RemoveNativeEventHandler(efl.Libs.Ecore, key, value);
            }
        }
    }
    ///<summary>Method to raise event PollLowEvt.</summary>
    public void OnPollLowEvt(EventArgs e)
    {
        var key = "_EFL_LOOP_EVENT_POLL_LOW";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Ecore, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Event occurs when the loop was requested to quit externally e.g. by a ctrl+c signal or a request from a parent loop/thread to have the child exit.
    /// (Since EFL 1.22)</summary>
    public event EventHandler QuitEvt
    {
        add
        {
            lock (eventLock)
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

                string key = "_EFL_LOOP_EVENT_QUIT";
                AddNativeEventHandler(efl.Libs.Ecore, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_LOOP_EVENT_QUIT";
                RemoveNativeEventHandler(efl.Libs.Ecore, key, value);
            }
        }
    }
    ///<summary>Method to raise event QuitEvt.</summary>
    public void OnQuitEvt(EventArgs e)
    {
        var key = "_EFL_LOOP_EVENT_QUIT";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Ecore, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Slow down the loop execution by forcing sleep for a small period of time every time the loop iterates/loops.
    /// (Since EFL 1.22)</summary>
    /// <returns>Time to sleep for each &quot;loop iteration&quot;</returns>
    virtual public double GetThrottle() {
         var _ret_var = Efl.Loop.NativeMethods.efl_loop_throttle_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Slow down the loop execution by forcing sleep for a small period of time every time the loop iterates/loops.
    /// (Since EFL 1.22)</summary>
    /// <param name="amount">Time to sleep for each &quot;loop iteration&quot;</param>
    virtual public void SetThrottle(double amount) {
                                 Efl.Loop.NativeMethods.efl_loop_throttle_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),amount);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>This gets the time that the main loop ceased waiting for timouts and/or events to come in or for signals or any other interrupt source. This should be considered a reference point for all time based activity that should calculate its timepoint from the return of ecore_loop_time_get(). Note that this time is meant to be used as relative to other times obtained on this run. If you need absolute time references, use a unix timestamp instead.
    /// (Since EFL 1.22)</summary>
    /// <returns>Time in seconds</returns>
    virtual public double GetTime() {
         var _ret_var = Efl.Loop.NativeMethods.efl_loop_time_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>You should never need/call this, unless you are implementing a custom tick source for an animator.
    /// Note: The time point must match whatever zero time you get from ecore_time_get() and <see cref="Efl.Loop.GetTime"/> (same 0 point). What this point is is undefined, so unless your source uses the same 0 time, then you may have to adjust and do some guessing.
    /// (Since EFL 1.22)</summary>
    /// <param name="timepoint">Time in seconds</param>
    virtual protected void SetTime(double timepoint) {
                                 Efl.Loop.NativeMethods.efl_loop_time_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),timepoint);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Runs a single iteration of the main loop to process everything on the queue.
    /// (Since EFL 1.22)</summary>
    virtual public void Iterate() {
         Efl.Loop.NativeMethods.efl_loop_iterate_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Runs a single iteration of the main loop to process everything on the queue with block/non-blocking status.
    /// (Since EFL 1.22)</summary>
    /// <param name="may_block">A flag if the main loop has a possibility of blocking.</param>
    /// <returns>Return from single iteration run</returns>
    virtual public int IterateMayBlock(int may_block) {
                                 var _ret_var = Efl.Loop.NativeMethods.efl_loop_iterate_may_block_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),may_block);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Runs the application main loop.
    /// (Since EFL 1.22)</summary>
    /// <returns>Value set by quit()</returns>
    virtual public Eina.Value Begin() {
         var _ret_var = Efl.Loop.NativeMethods.efl_loop_begin_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Quits the main loop once all the events currently on the queue have been processed.
    /// (Since EFL 1.22)</summary>
    /// <param name="exit_code">Returned value by begin()</param>
    virtual public void Quit(Eina.Value exit_code) {
         var _in_exit_code = exit_code.GetNative();
                        Efl.Loop.NativeMethods.efl_loop_quit_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),_in_exit_code);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>A future promise that will be resolved from a clean main loop context as soon as possible.
    /// This has higher priority, for low priority use <see cref="Efl.Loop.Idle"/>
    /// (Since EFL 1.22)</summary>
    /// <returns>The future handle.</returns>
    virtual public  Eina.Future Job() {
         var _ret_var = Efl.Loop.NativeMethods.efl_loop_job_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>A future promise that will be resolved from a clean main loop context as soon as the main loop is idle.
    /// This is a low priority version of <see cref="Efl.Loop.Job"/>
    /// (Since EFL 1.22)</summary>
    /// <returns>The future handle.</returns>
    virtual public  Eina.Future Idle() {
         var _ret_var = Efl.Loop.NativeMethods.efl_loop_idle_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>A future promise that will be resolved from a clean main loop context after <c>time</c> seconds.
    /// (Since EFL 1.22)</summary>
    /// <param name="time">The time from now in second that the main loop will wait before triggering it.</param>
    /// <returns>The future handle.</returns>
    virtual public  Eina.Future Timeout(double time) {
                                 var _ret_var = Efl.Loop.NativeMethods.efl_loop_timeout_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),time);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Will register a manager of a specific class to be answered by eo.provider_find.
    /// (Since EFL 1.22)</summary>
    /// <param name="klass">The class provided by the registered provider.</param>
    /// <param name="provider">The provider for the newly registered class that has to provide that said Efl.Class.</param>
    /// <returns><c>true</c> if successfully register, <c>false</c> otherwise.</returns>
    virtual public bool Register(Type klass, Efl.Object provider) {
                                                         var _ret_var = Efl.Loop.NativeMethods.efl_loop_register_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),klass, provider);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Will unregister a manager of a specific class that was previously registered and answered by eo.provider_find.
    /// (Since EFL 1.22)</summary>
    /// <param name="klass">The class provided by the provider to unregister for.</param>
    /// <param name="provider">The provider for the registered class to unregister.</param>
    /// <returns><c>true</c> if successfully unregistered, <c>false</c> otherwise.</returns>
    virtual public bool Unregister(Type klass, Efl.Object provider) {
                                                         var _ret_var = Efl.Loop.NativeMethods.efl_loop_unregister_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),klass, provider);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Async wrapper for <see cref="Job" />.</summary>
    /// <param name="token">Token to notify the async operation of external request to cancel.</param>
    /// <returns>An async task wrapping the result of the operation.</returns>
    public System.Threading.Tasks.Task<Eina.Value> JobAsync( System.Threading.CancellationToken token = default(System.Threading.CancellationToken))
    {
        Eina.Future future = Job();
        return Efl.Eo.Globals.WrapAsync(future, token);
    }

    /// <summary>Async wrapper for <see cref="Idle" />.</summary>
    /// <param name="token">Token to notify the async operation of external request to cancel.</param>
    /// <returns>An async task wrapping the result of the operation.</returns>
    public System.Threading.Tasks.Task<Eina.Value> IdleAsync( System.Threading.CancellationToken token = default(System.Threading.CancellationToken))
    {
        Eina.Future future = Idle();
        return Efl.Eo.Globals.WrapAsync(future, token);
    }

    /// <summary>Async wrapper for <see cref="Timeout" />.</summary>
    /// <param name="time">The time from now in second that the main loop will wait before triggering it.</param>
    /// <param name="token">Token to notify the async operation of external request to cancel.</param>
    /// <returns>An async task wrapping the result of the operation.</returns>
    public System.Threading.Tasks.Task<Eina.Value> TimeoutAsync(double time, System.Threading.CancellationToken token = default(System.Threading.CancellationToken))
    {
        Eina.Future future = Timeout( time);
        return Efl.Eo.Globals.WrapAsync(future, token);
    }

    /// <summary>Slow down the loop execution by forcing sleep for a small period of time every time the loop iterates/loops.
    /// (Since EFL 1.22)</summary>
    /// <value>Time to sleep for each &quot;loop iteration&quot;</value>
    public double Throttle {
        get { return GetThrottle(); }
        set { SetThrottle(value); }
    }
    /// <summary>Retrieves the time at which the last loop stopped waiting for timeouts or events.
    /// (Since EFL 1.22)</summary>
    /// <value>Time in seconds</value>
    public double Time {
        get { return GetTime(); }
        protected set { SetTime(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Loop.efl_loop_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Task.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Ecore);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_loop_throttle_get_static_delegate == null)
            {
                efl_loop_throttle_get_static_delegate = new efl_loop_throttle_get_delegate(throttle_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetThrottle") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_loop_throttle_get"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_throttle_get_static_delegate) });
            }

            if (efl_loop_throttle_set_static_delegate == null)
            {
                efl_loop_throttle_set_static_delegate = new efl_loop_throttle_set_delegate(throttle_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetThrottle") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_loop_throttle_set"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_throttle_set_static_delegate) });
            }

            if (efl_loop_time_get_static_delegate == null)
            {
                efl_loop_time_get_static_delegate = new efl_loop_time_get_delegate(time_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetTime") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_loop_time_get"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_time_get_static_delegate) });
            }

            if (efl_loop_time_set_static_delegate == null)
            {
                efl_loop_time_set_static_delegate = new efl_loop_time_set_delegate(time_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetTime") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_loop_time_set"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_time_set_static_delegate) });
            }

            if (efl_loop_iterate_static_delegate == null)
            {
                efl_loop_iterate_static_delegate = new efl_loop_iterate_delegate(iterate);
            }

            if (methods.FirstOrDefault(m => m.Name == "Iterate") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_loop_iterate"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_iterate_static_delegate) });
            }

            if (efl_loop_iterate_may_block_static_delegate == null)
            {
                efl_loop_iterate_may_block_static_delegate = new efl_loop_iterate_may_block_delegate(iterate_may_block);
            }

            if (methods.FirstOrDefault(m => m.Name == "IterateMayBlock") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_loop_iterate_may_block"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_iterate_may_block_static_delegate) });
            }

            if (efl_loop_begin_static_delegate == null)
            {
                efl_loop_begin_static_delegate = new efl_loop_begin_delegate(begin);
            }

            if (methods.FirstOrDefault(m => m.Name == "Begin") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_loop_begin"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_begin_static_delegate) });
            }

            if (efl_loop_quit_static_delegate == null)
            {
                efl_loop_quit_static_delegate = new efl_loop_quit_delegate(quit);
            }

            if (methods.FirstOrDefault(m => m.Name == "Quit") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_loop_quit"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_quit_static_delegate) });
            }

            if (efl_loop_job_static_delegate == null)
            {
                efl_loop_job_static_delegate = new efl_loop_job_delegate(job);
            }

            if (methods.FirstOrDefault(m => m.Name == "Job") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_loop_job"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_job_static_delegate) });
            }

            if (efl_loop_idle_static_delegate == null)
            {
                efl_loop_idle_static_delegate = new efl_loop_idle_delegate(idle);
            }

            if (methods.FirstOrDefault(m => m.Name == "Idle") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_loop_idle"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_idle_static_delegate) });
            }

            if (efl_loop_timeout_static_delegate == null)
            {
                efl_loop_timeout_static_delegate = new efl_loop_timeout_delegate(timeout);
            }

            if (methods.FirstOrDefault(m => m.Name == "Timeout") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_loop_timeout"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_timeout_static_delegate) });
            }

            if (efl_loop_register_static_delegate == null)
            {
                efl_loop_register_static_delegate = new efl_loop_register_delegate(register);
            }

            if (methods.FirstOrDefault(m => m.Name == "Register") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_loop_register"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_register_static_delegate) });
            }

            if (efl_loop_unregister_static_delegate == null)
            {
                efl_loop_unregister_static_delegate = new efl_loop_unregister_delegate(unregister);
            }

            if (methods.FirstOrDefault(m => m.Name == "Unregister") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_loop_unregister"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_unregister_static_delegate) });
            }

            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Loop.efl_loop_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate double efl_loop_throttle_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate double efl_loop_throttle_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_loop_throttle_get_api_delegate> efl_loop_throttle_get_ptr = new Efl.Eo.FunctionWrapper<efl_loop_throttle_get_api_delegate>(Module, "efl_loop_throttle_get");

        private static double throttle_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_loop_throttle_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            double _ret_var = default(double);
                try
                {
                    _ret_var = ((Loop)ws.Target).GetThrottle();
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
                return efl_loop_throttle_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_loop_throttle_get_delegate efl_loop_throttle_get_static_delegate;

        
        private delegate void efl_loop_throttle_set_delegate(System.IntPtr obj, System.IntPtr pd,  double amount);

        
        public delegate void efl_loop_throttle_set_api_delegate(System.IntPtr obj,  double amount);

        public static Efl.Eo.FunctionWrapper<efl_loop_throttle_set_api_delegate> efl_loop_throttle_set_ptr = new Efl.Eo.FunctionWrapper<efl_loop_throttle_set_api_delegate>(Module, "efl_loop_throttle_set");

        private static void throttle_set(System.IntPtr obj, System.IntPtr pd, double amount)
        {
            Eina.Log.Debug("function efl_loop_throttle_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Loop)ws.Target).SetThrottle(amount);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_loop_throttle_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), amount);
            }
        }

        private static efl_loop_throttle_set_delegate efl_loop_throttle_set_static_delegate;

        
        private delegate double efl_loop_time_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate double efl_loop_time_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_loop_time_get_api_delegate> efl_loop_time_get_ptr = new Efl.Eo.FunctionWrapper<efl_loop_time_get_api_delegate>(Module, "efl_loop_time_get");

        private static double time_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_loop_time_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            double _ret_var = default(double);
                try
                {
                    _ret_var = ((Loop)ws.Target).GetTime();
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
                return efl_loop_time_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_loop_time_get_delegate efl_loop_time_get_static_delegate;

        
        private delegate void efl_loop_time_set_delegate(System.IntPtr obj, System.IntPtr pd,  double timepoint);

        
        public delegate void efl_loop_time_set_api_delegate(System.IntPtr obj,  double timepoint);

        public static Efl.Eo.FunctionWrapper<efl_loop_time_set_api_delegate> efl_loop_time_set_ptr = new Efl.Eo.FunctionWrapper<efl_loop_time_set_api_delegate>(Module, "efl_loop_time_set");

        private static void time_set(System.IntPtr obj, System.IntPtr pd, double timepoint)
        {
            Eina.Log.Debug("function efl_loop_time_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Loop)ws.Target).SetTime(timepoint);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_loop_time_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), timepoint);
            }
        }

        private static efl_loop_time_set_delegate efl_loop_time_set_static_delegate;

        
        private delegate void efl_loop_iterate_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_loop_iterate_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_loop_iterate_api_delegate> efl_loop_iterate_ptr = new Efl.Eo.FunctionWrapper<efl_loop_iterate_api_delegate>(Module, "efl_loop_iterate");

        private static void iterate(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_loop_iterate was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((Loop)ws.Target).Iterate();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_loop_iterate_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_loop_iterate_delegate efl_loop_iterate_static_delegate;

        
        private delegate int efl_loop_iterate_may_block_delegate(System.IntPtr obj, System.IntPtr pd,  int may_block);

        
        public delegate int efl_loop_iterate_may_block_api_delegate(System.IntPtr obj,  int may_block);

        public static Efl.Eo.FunctionWrapper<efl_loop_iterate_may_block_api_delegate> efl_loop_iterate_may_block_ptr = new Efl.Eo.FunctionWrapper<efl_loop_iterate_may_block_api_delegate>(Module, "efl_loop_iterate_may_block");

        private static int iterate_may_block(System.IntPtr obj, System.IntPtr pd, int may_block)
        {
            Eina.Log.Debug("function efl_loop_iterate_may_block was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    int _ret_var = default(int);
                try
                {
                    _ret_var = ((Loop)ws.Target).IterateMayBlock(may_block);
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
                return efl_loop_iterate_may_block_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), may_block);
            }
        }

        private static efl_loop_iterate_may_block_delegate efl_loop_iterate_may_block_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.ValueMarshaler))]
        private delegate Eina.Value efl_loop_begin_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.ValueMarshaler))]
        public delegate Eina.Value efl_loop_begin_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_loop_begin_api_delegate> efl_loop_begin_ptr = new Efl.Eo.FunctionWrapper<efl_loop_begin_api_delegate>(Module, "efl_loop_begin");

        private static Eina.Value begin(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_loop_begin was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Value _ret_var = default(Eina.Value);
                try
                {
                    _ret_var = ((Loop)ws.Target).Begin();
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
                return efl_loop_begin_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_loop_begin_delegate efl_loop_begin_static_delegate;

        
        private delegate void efl_loop_quit_delegate(System.IntPtr obj, System.IntPtr pd,  Eina.ValueNative exit_code);

        
        public delegate void efl_loop_quit_api_delegate(System.IntPtr obj,  Eina.ValueNative exit_code);

        public static Efl.Eo.FunctionWrapper<efl_loop_quit_api_delegate> efl_loop_quit_ptr = new Efl.Eo.FunctionWrapper<efl_loop_quit_api_delegate>(Module, "efl_loop_quit");

        private static void quit(System.IntPtr obj, System.IntPtr pd, Eina.ValueNative exit_code)
        {
            Eina.Log.Debug("function efl_loop_quit was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        var _in_exit_code = new Eina.Value(exit_code);
                            
                try
                {
                    ((Loop)ws.Target).Quit(_in_exit_code);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_loop_quit_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), exit_code);
            }
        }

        private static efl_loop_quit_delegate efl_loop_quit_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))]
        private delegate  Eina.Future efl_loop_job_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))]
        public delegate  Eina.Future efl_loop_job_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_loop_job_api_delegate> efl_loop_job_ptr = new Efl.Eo.FunctionWrapper<efl_loop_job_api_delegate>(Module, "efl_loop_job");

        private static  Eina.Future job(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_loop_job was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
             Eina.Future _ret_var = default( Eina.Future);
                try
                {
                    _ret_var = ((Loop)ws.Target).Job();
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
                return efl_loop_job_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_loop_job_delegate efl_loop_job_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))]
        private delegate  Eina.Future efl_loop_idle_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))]
        public delegate  Eina.Future efl_loop_idle_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_loop_idle_api_delegate> efl_loop_idle_ptr = new Efl.Eo.FunctionWrapper<efl_loop_idle_api_delegate>(Module, "efl_loop_idle");

        private static  Eina.Future idle(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_loop_idle was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
             Eina.Future _ret_var = default( Eina.Future);
                try
                {
                    _ret_var = ((Loop)ws.Target).Idle();
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
                return efl_loop_idle_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_loop_idle_delegate efl_loop_idle_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))]
        private delegate  Eina.Future efl_loop_timeout_delegate(System.IntPtr obj, System.IntPtr pd,  double time);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))]
        public delegate  Eina.Future efl_loop_timeout_api_delegate(System.IntPtr obj,  double time);

        public static Efl.Eo.FunctionWrapper<efl_loop_timeout_api_delegate> efl_loop_timeout_ptr = new Efl.Eo.FunctionWrapper<efl_loop_timeout_api_delegate>(Module, "efl_loop_timeout");

        private static  Eina.Future timeout(System.IntPtr obj, System.IntPtr pd, double time)
        {
            Eina.Log.Debug("function efl_loop_timeout was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                     Eina.Future _ret_var = default( Eina.Future);
                try
                {
                    _ret_var = ((Loop)ws.Target).Timeout(time);
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
                return efl_loop_timeout_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), time);
            }
        }

        private static efl_loop_timeout_delegate efl_loop_timeout_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_loop_register_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEflClass))] Type klass, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Object provider);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_loop_register_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEflClass))] Type klass, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Object provider);

        public static Efl.Eo.FunctionWrapper<efl_loop_register_api_delegate> efl_loop_register_ptr = new Efl.Eo.FunctionWrapper<efl_loop_register_api_delegate>(Module, "efl_loop_register");

        private static bool register(System.IntPtr obj, System.IntPtr pd, Type klass, Efl.Object provider)
        {
            Eina.Log.Debug("function efl_loop_register was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Loop)ws.Target).Register(klass, provider);
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
                return efl_loop_register_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), klass, provider);
            }
        }

        private static efl_loop_register_delegate efl_loop_register_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_loop_unregister_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEflClass))] Type klass, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Object provider);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_loop_unregister_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEflClass))] Type klass, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Object provider);

        public static Efl.Eo.FunctionWrapper<efl_loop_unregister_api_delegate> efl_loop_unregister_ptr = new Efl.Eo.FunctionWrapper<efl_loop_unregister_api_delegate>(Module, "efl_loop_unregister");

        private static bool unregister(System.IntPtr obj, System.IntPtr pd, Type klass, Efl.Object provider)
        {
            Eina.Log.Debug("function efl_loop_unregister was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Loop)ws.Target).Unregister(klass, provider);
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
                return efl_loop_unregister_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), klass, provider);
            }
        }

        private static efl_loop_unregister_delegate efl_loop_unregister_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

namespace Efl {

/// <summary>EFL loop arguments data structure
/// (Since EFL 1.22)</summary>
[StructLayout(LayoutKind.Sequential)]
public struct LoopArguments
{
    /// <summary>Array with loop arguments</summary>
    public Eina.Array<System.String> Argv;
    /// <summary>Set to <c>true</c> when the program should initialize its internal state. This happen once per process instance.</summary>
    public bool Initialization;
    ///<summary>Constructor for LoopArguments.</summary>
    public LoopArguments(
        Eina.Array<System.String> Argv = default(Eina.Array<System.String>),
        bool Initialization = default(bool)    )
    {
        this.Argv = Argv;
        this.Initialization = Initialization;
    }

    ///<summary>Implicit conversion to the managed representation from a native pointer.</summary>
    ///<param name="ptr">Native pointer to be converted.</param>
    public static implicit operator LoopArguments(IntPtr ptr)
    {
        var tmp = (LoopArguments.NativeStruct)Marshal.PtrToStructure(ptr, typeof(LoopArguments.NativeStruct));
        return tmp;
    }

    #pragma warning disable CS1591

    ///<summary>Internal wrapper for struct LoopArguments.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        
        public System.IntPtr Argv;
        ///<summary>Internal wrapper for field Initialization</summary>
        public System.Byte Initialization;
        ///<summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator LoopArguments.NativeStruct(LoopArguments _external_struct)
        {
            var _internal_struct = new LoopArguments.NativeStruct();
            _internal_struct.Argv = _external_struct.Argv.Handle;
            _internal_struct.Initialization = _external_struct.Initialization ? (byte)1 : (byte)0;
            return _internal_struct;
        }

        ///<summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator LoopArguments(LoopArguments.NativeStruct _internal_struct)
        {
            var _external_struct = new LoopArguments();
            _external_struct.Argv = new Eina.Array<System.String>(_internal_struct.Argv, false, false);
            _external_struct.Initialization = _internal_struct.Initialization != 0;
            return _external_struct;
        }

    }

    #pragma warning restore CS1591

}

}

