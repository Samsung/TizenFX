#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
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
[LoopNativeInherit]
public abstract class Loop : Efl.Task, Efl.Eo.IWrapper
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (Loop))
                return Efl.LoopNativeInherit.GetEflClassStatic();
            else
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
        }
    }
    [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)] internal static extern System.IntPtr
        efl_loop_class_get();
    ///<summary>Creates a new instance.</summary>
    ///<param name="parent">Parent instance.</param>
    public Loop(Efl.Object parent= null
            ) :
        base(efl_loop_class_get(), typeof(Loop), parent)
    {
        FinishInstantiation();
    }
    ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    protected Loop(System.IntPtr raw) : base(raw)
    {
                RegisterEventProxies();
    }
    [Efl.Eo.PrivateNativeClass]
    private class LoopRealized : Loop
    {
        private LoopRealized(IntPtr ptr) : base(ptr)
        {
        }
    }
    ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    protected Loop(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
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
private static object IdleEnterEvtKey = new object();
    /// <summary>Event occurs once the main loop enters the idle state.
    /// (Since EFL 1.22)</summary>
    public event EventHandler IdleEnterEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_LOOP_EVENT_IDLE_ENTER";
                if (AddNativeEventHandler(efl.Libs.Ecore, key, this.evt_IdleEnterEvt_delegate)) {
                    eventHandlers.AddHandler(IdleEnterEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_LOOP_EVENT_IDLE_ENTER";
                if (RemoveNativeEventHandler(key, this.evt_IdleEnterEvt_delegate)) { 
                    eventHandlers.RemoveHandler(IdleEnterEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event IdleEnterEvt.</summary>
    public void On_IdleEnterEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[IdleEnterEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_IdleEnterEvt_delegate;
    private void on_IdleEnterEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_IdleEnterEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object IdleExitEvtKey = new object();
    /// <summary>Event occurs once the main loop exits the idle state.
    /// (Since EFL 1.22)</summary>
    public event EventHandler IdleExitEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_LOOP_EVENT_IDLE_EXIT";
                if (AddNativeEventHandler(efl.Libs.Ecore, key, this.evt_IdleExitEvt_delegate)) {
                    eventHandlers.AddHandler(IdleExitEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_LOOP_EVENT_IDLE_EXIT";
                if (RemoveNativeEventHandler(key, this.evt_IdleExitEvt_delegate)) { 
                    eventHandlers.RemoveHandler(IdleExitEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event IdleExitEvt.</summary>
    public void On_IdleExitEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[IdleExitEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_IdleExitEvt_delegate;
    private void on_IdleExitEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_IdleExitEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object IdleEvtKey = new object();
    /// <summary>Event occurs once the main loop is idle. If you keep listening on this event it may increase the burden on your CPU.
    /// (Since EFL 1.22)</summary>
    public event EventHandler IdleEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_LOOP_EVENT_IDLE";
                if (AddNativeEventHandler(efl.Libs.Ecore, key, this.evt_IdleEvt_delegate)) {
                    eventHandlers.AddHandler(IdleEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_LOOP_EVENT_IDLE";
                if (RemoveNativeEventHandler(key, this.evt_IdleEvt_delegate)) { 
                    eventHandlers.RemoveHandler(IdleEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event IdleEvt.</summary>
    public void On_IdleEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[IdleEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_IdleEvt_delegate;
    private void on_IdleEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_IdleEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object ArgumentsEvtKey = new object();
    /// <summary>Event happens when args are provided to the loop by args_add().
    /// (Since EFL 1.22)</summary>
    public event EventHandler<Efl.LoopArgumentsEvt_Args> ArgumentsEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_LOOP_EVENT_ARGUMENTS";
                if (AddNativeEventHandler(efl.Libs.Ecore, key, this.evt_ArgumentsEvt_delegate)) {
                    eventHandlers.AddHandler(ArgumentsEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_LOOP_EVENT_ARGUMENTS";
                if (RemoveNativeEventHandler(key, this.evt_ArgumentsEvt_delegate)) { 
                    eventHandlers.RemoveHandler(ArgumentsEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event ArgumentsEvt.</summary>
    public void On_ArgumentsEvt(Efl.LoopArgumentsEvt_Args e)
    {
        EventHandler<Efl.LoopArgumentsEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.LoopArgumentsEvt_Args>)eventHandlers[ArgumentsEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_ArgumentsEvt_delegate;
    private void on_ArgumentsEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.LoopArgumentsEvt_Args args = new Efl.LoopArgumentsEvt_Args();
      args.arg =  evt.Info;;
        try {
            On_ArgumentsEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object PollHighEvtKey = new object();
    /// <summary>Event occurs multiple times per second. The exact tick is undefined and can be adjusted system wide.
    /// (Since EFL 1.22)</summary>
    public event EventHandler PollHighEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_LOOP_EVENT_POLL_HIGH";
                if (AddNativeEventHandler(efl.Libs.Ecore, key, this.evt_PollHighEvt_delegate)) {
                    eventHandlers.AddHandler(PollHighEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_LOOP_EVENT_POLL_HIGH";
                if (RemoveNativeEventHandler(key, this.evt_PollHighEvt_delegate)) { 
                    eventHandlers.RemoveHandler(PollHighEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event PollHighEvt.</summary>
    public void On_PollHighEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[PollHighEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_PollHighEvt_delegate;
    private void on_PollHighEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_PollHighEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object PollMediumEvtKey = new object();
    /// <summary>Event occurs multiple times per minute. The exact tick is undefined and can be adjusted system wide.
    /// (Since EFL 1.22)</summary>
    public event EventHandler PollMediumEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_LOOP_EVENT_POLL_MEDIUM";
                if (AddNativeEventHandler(efl.Libs.Ecore, key, this.evt_PollMediumEvt_delegate)) {
                    eventHandlers.AddHandler(PollMediumEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_LOOP_EVENT_POLL_MEDIUM";
                if (RemoveNativeEventHandler(key, this.evt_PollMediumEvt_delegate)) { 
                    eventHandlers.RemoveHandler(PollMediumEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event PollMediumEvt.</summary>
    public void On_PollMediumEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[PollMediumEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_PollMediumEvt_delegate;
    private void on_PollMediumEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_PollMediumEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object PollLowEvtKey = new object();
    /// <summary>Event occurs multiple times every 15 minutes. The exact tick is undefined and can be adjusted system wide.
    /// (Since EFL 1.22)</summary>
    public event EventHandler PollLowEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_LOOP_EVENT_POLL_LOW";
                if (AddNativeEventHandler(efl.Libs.Ecore, key, this.evt_PollLowEvt_delegate)) {
                    eventHandlers.AddHandler(PollLowEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_LOOP_EVENT_POLL_LOW";
                if (RemoveNativeEventHandler(key, this.evt_PollLowEvt_delegate)) { 
                    eventHandlers.RemoveHandler(PollLowEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event PollLowEvt.</summary>
    public void On_PollLowEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[PollLowEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_PollLowEvt_delegate;
    private void on_PollLowEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_PollLowEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object QuitEvtKey = new object();
    /// <summary>Event occurs when the loop was requested to quit externally e.g. by a ctrl+c signal or a request from a parent loop/thread to have the child exit.
    /// (Since EFL 1.22)</summary>
    public event EventHandler QuitEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_LOOP_EVENT_QUIT";
                if (AddNativeEventHandler(efl.Libs.Ecore, key, this.evt_QuitEvt_delegate)) {
                    eventHandlers.AddHandler(QuitEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_LOOP_EVENT_QUIT";
                if (RemoveNativeEventHandler(key, this.evt_QuitEvt_delegate)) { 
                    eventHandlers.RemoveHandler(QuitEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event QuitEvt.</summary>
    public void On_QuitEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[QuitEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_QuitEvt_delegate;
    private void on_QuitEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_QuitEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

    ///<summary>Register the Eo event wrappers making the bridge to C# events. Internal usage only.</summary>
    protected override void RegisterEventProxies()
    {
        base.RegisterEventProxies();
        evt_IdleEnterEvt_delegate = new Efl.EventCb(on_IdleEnterEvt_NativeCallback);
        evt_IdleExitEvt_delegate = new Efl.EventCb(on_IdleExitEvt_NativeCallback);
        evt_IdleEvt_delegate = new Efl.EventCb(on_IdleEvt_NativeCallback);
        evt_ArgumentsEvt_delegate = new Efl.EventCb(on_ArgumentsEvt_NativeCallback);
        evt_PollHighEvt_delegate = new Efl.EventCb(on_PollHighEvt_NativeCallback);
        evt_PollMediumEvt_delegate = new Efl.EventCb(on_PollMediumEvt_NativeCallback);
        evt_PollLowEvt_delegate = new Efl.EventCb(on_PollLowEvt_NativeCallback);
        evt_QuitEvt_delegate = new Efl.EventCb(on_QuitEvt_NativeCallback);
    }
    /// <summary>Slow down the loop execution by forcing sleep for a small period of time every time the loop iterates/loops.
    /// (Since EFL 1.22)</summary>
    /// <returns>Time to sleep for each &quot;loop iteration&quot;</returns>
    virtual public double GetThrottle() {
         var _ret_var = Efl.LoopNativeInherit.efl_loop_throttle_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Slow down the loop execution by forcing sleep for a small period of time every time the loop iterates/loops.
    /// (Since EFL 1.22)</summary>
    /// <param name="amount">Time to sleep for each &quot;loop iteration&quot;</param>
    /// <returns></returns>
    virtual public void SetThrottle( double amount) {
                                 Efl.LoopNativeInherit.efl_loop_throttle_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), amount);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>This gets the time that the main loop ceased waiting for timouts and/or events to come in or for signals or any other interrupt source. This should be considered a reference point for all time based activity that should calculate its timepoint from the return of ecore_loop_time_get(). Note that this time is meant to be used as relative to other times obtained on this run. If you need absolute time references, use a unix timestamp instead.
    /// (Since EFL 1.22)</summary>
    /// <returns>Time in seconds</returns>
    virtual public double GetTime() {
         var _ret_var = Efl.LoopNativeInherit.efl_loop_time_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>You should never need/call this, unless you are implementing a custom tick source for an animator.
    /// Note: The time point must match whatever zero time you get from ecore_time_get() and <see cref="Efl.Loop.GetTime"/> (same 0 point). What this point is is undefined, so unless your source uses the same 0 time, then you may have to adjust and do some guessing.
    /// (Since EFL 1.22)</summary>
    /// <param name="timepoint">Time in seconds</param>
    /// <returns></returns>
    virtual public void SetTime( double timepoint) {
                                 Efl.LoopNativeInherit.efl_loop_time_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), timepoint);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Runs a single iteration of the main loop to process everything on the queue.
    /// (Since EFL 1.22)</summary>
    /// <returns></returns>
    virtual public void Iterate() {
         Efl.LoopNativeInherit.efl_loop_iterate_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Runs a single iteration of the main loop to process everything on the queue with block/non-blocking status.
    /// (Since EFL 1.22)</summary>
    /// <param name="may_block">A flag if the main loop has a possibility of blocking.</param>
    /// <returns>Return from single iteration run</returns>
    virtual public int IterateMayBlock( int may_block) {
                                 var _ret_var = Efl.LoopNativeInherit.efl_loop_iterate_may_block_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), may_block);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Runs the application main loop.
    /// (Since EFL 1.22)</summary>
    /// <returns>Value set by quit()</returns>
    virtual public Eina.Value Begin() {
         var _ret_var = Efl.LoopNativeInherit.efl_loop_begin_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Quits the main loop once all the events currently on the queue have been processed.
    /// (Since EFL 1.22)</summary>
    /// <param name="exit_code">Returned value by begin()</param>
    /// <returns></returns>
    virtual public void Quit( Eina.Value exit_code) {
         var _in_exit_code = exit_code.GetNative();
                        Efl.LoopNativeInherit.efl_loop_quit_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), _in_exit_code);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>A future promise that will be resolved from a clean main loop context as soon as possible.
    /// This has higher priority, for low priority use <see cref="Efl.Loop.Idle"/>
    /// (Since EFL 1.22)</summary>
    /// <returns>The future handle.</returns>
    virtual public  Eina.Future Job() {
         var _ret_var = Efl.LoopNativeInherit.efl_loop_job_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>A future promise that will be resolved from a clean main loop context as soon as the main loop is idle.
    /// This is a low priority version of <see cref="Efl.Loop.Job"/>
    /// (Since EFL 1.22)</summary>
    /// <returns>The future handle.</returns>
    virtual public  Eina.Future Idle() {
         var _ret_var = Efl.LoopNativeInherit.efl_loop_idle_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>A future promise that will be resolved from a clean main loop context after <c>time</c> seconds.
    /// (Since EFL 1.22)</summary>
    /// <param name="time">The time from now in second that the main loop will wait before triggering it.</param>
    /// <returns>The future handle.</returns>
    virtual public  Eina.Future Timeout( double time) {
                                 var _ret_var = Efl.LoopNativeInherit.efl_loop_timeout_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), time);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Will register a manager of a specific class to be answered by eo.provider_find.
    /// (Since EFL 1.22)</summary>
    /// <param name="klass">The class provided by the registered provider.</param>
    /// <param name="provider">The provider for the newly registered class that has to provide that said Efl.Class.</param>
    /// <returns><c>true</c> if successfully register, <c>false</c> otherwise.</returns>
    virtual public bool Register( Type klass,  Efl.Object provider) {
                                                         var _ret_var = Efl.LoopNativeInherit.efl_loop_register_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), klass,  provider);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Will unregister a manager of a specific class that was previously registered and answered by eo.provider_find.
    /// (Since EFL 1.22)</summary>
    /// <param name="klass">The class provided by the provider to unregister for.</param>
    /// <param name="provider">The provider for the registered class to unregister.</param>
    /// <returns><c>true</c> if successfully unregistered, <c>false</c> otherwise.</returns>
    virtual public bool Unregister( Type klass,  Efl.Object provider) {
                                                         var _ret_var = Efl.LoopNativeInherit.efl_loop_unregister_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), klass,  provider);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    public System.Threading.Tasks.Task<Eina.Value> JobAsync( System.Threading.CancellationToken token=default(System.Threading.CancellationToken))
    {
        Eina.Future future = Job();
        return Efl.Eo.Globals.WrapAsync(future, token);
    }
    public System.Threading.Tasks.Task<Eina.Value> IdleAsync( System.Threading.CancellationToken token=default(System.Threading.CancellationToken))
    {
        Eina.Future future = Idle();
        return Efl.Eo.Globals.WrapAsync(future, token);
    }
    public System.Threading.Tasks.Task<Eina.Value> TimeoutAsync( double time, System.Threading.CancellationToken token=default(System.Threading.CancellationToken))
    {
        Eina.Future future = Timeout(  time);
        return Efl.Eo.Globals.WrapAsync(future, token);
    }
    /// <summary>Slow down the loop execution by forcing sleep for a small period of time every time the loop iterates/loops.
/// (Since EFL 1.22)</summary>
/// <value>Time to sleep for each &quot;loop iteration&quot;</value>
    public double Throttle {
        get { return GetThrottle(); }
        set { SetThrottle( value); }
    }
    /// <summary>Retrieves the time at which the last loop stopped waiting for timeouts or events.
/// (Since EFL 1.22)</summary>
/// <value>Time in seconds</value>
    public double Time {
        get { return GetTime(); }
        set { SetTime( value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Loop.efl_loop_class_get();
    }
}
public class LoopNativeInherit : Efl.TaskNativeInherit{
    public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Ecore);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
        if (efl_loop_throttle_get_static_delegate == null)
            efl_loop_throttle_get_static_delegate = new efl_loop_throttle_get_delegate(throttle_get);
        if (methods.FirstOrDefault(m => m.Name == "GetThrottle") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_loop_throttle_get"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_throttle_get_static_delegate)});
        if (efl_loop_throttle_set_static_delegate == null)
            efl_loop_throttle_set_static_delegate = new efl_loop_throttle_set_delegate(throttle_set);
        if (methods.FirstOrDefault(m => m.Name == "SetThrottle") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_loop_throttle_set"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_throttle_set_static_delegate)});
        if (efl_loop_time_get_static_delegate == null)
            efl_loop_time_get_static_delegate = new efl_loop_time_get_delegate(time_get);
        if (methods.FirstOrDefault(m => m.Name == "GetTime") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_loop_time_get"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_time_get_static_delegate)});
        if (efl_loop_time_set_static_delegate == null)
            efl_loop_time_set_static_delegate = new efl_loop_time_set_delegate(time_set);
        if (methods.FirstOrDefault(m => m.Name == "SetTime") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_loop_time_set"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_time_set_static_delegate)});
        if (efl_loop_iterate_static_delegate == null)
            efl_loop_iterate_static_delegate = new efl_loop_iterate_delegate(iterate);
        if (methods.FirstOrDefault(m => m.Name == "Iterate") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_loop_iterate"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_iterate_static_delegate)});
        if (efl_loop_iterate_may_block_static_delegate == null)
            efl_loop_iterate_may_block_static_delegate = new efl_loop_iterate_may_block_delegate(iterate_may_block);
        if (methods.FirstOrDefault(m => m.Name == "IterateMayBlock") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_loop_iterate_may_block"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_iterate_may_block_static_delegate)});
        if (efl_loop_begin_static_delegate == null)
            efl_loop_begin_static_delegate = new efl_loop_begin_delegate(begin);
        if (methods.FirstOrDefault(m => m.Name == "Begin") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_loop_begin"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_begin_static_delegate)});
        if (efl_loop_quit_static_delegate == null)
            efl_loop_quit_static_delegate = new efl_loop_quit_delegate(quit);
        if (methods.FirstOrDefault(m => m.Name == "Quit") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_loop_quit"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_quit_static_delegate)});
        if (efl_loop_job_static_delegate == null)
            efl_loop_job_static_delegate = new efl_loop_job_delegate(job);
        if (methods.FirstOrDefault(m => m.Name == "Job") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_loop_job"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_job_static_delegate)});
        if (efl_loop_idle_static_delegate == null)
            efl_loop_idle_static_delegate = new efl_loop_idle_delegate(idle);
        if (methods.FirstOrDefault(m => m.Name == "Idle") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_loop_idle"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_idle_static_delegate)});
        if (efl_loop_timeout_static_delegate == null)
            efl_loop_timeout_static_delegate = new efl_loop_timeout_delegate(timeout);
        if (methods.FirstOrDefault(m => m.Name == "Timeout") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_loop_timeout"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_timeout_static_delegate)});
        if (efl_loop_register_static_delegate == null)
            efl_loop_register_static_delegate = new efl_loop_register_delegate(register);
        if (methods.FirstOrDefault(m => m.Name == "Register") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_loop_register"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_register_static_delegate)});
        if (efl_loop_unregister_static_delegate == null)
            efl_loop_unregister_static_delegate = new efl_loop_unregister_delegate(unregister);
        if (methods.FirstOrDefault(m => m.Name == "Unregister") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_loop_unregister"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_unregister_static_delegate)});
        descs.AddRange(base.GetEoOps(type));
        return descs;
    }
    public override IntPtr GetEflClass()
    {
        return Efl.Loop.efl_loop_class_get();
    }
    public static new  IntPtr GetEflClassStatic()
    {
        return Efl.Loop.efl_loop_class_get();
    }


     private delegate double efl_loop_throttle_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate double efl_loop_throttle_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_loop_throttle_get_api_delegate> efl_loop_throttle_get_ptr = new Efl.Eo.FunctionWrapper<efl_loop_throttle_get_api_delegate>(_Module, "efl_loop_throttle_get");
     private static double throttle_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_loop_throttle_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        double _ret_var = default(double);
            try {
                _ret_var = ((Loop)wrapper).GetThrottle();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_loop_throttle_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_loop_throttle_get_delegate efl_loop_throttle_get_static_delegate;


     private delegate void efl_loop_throttle_set_delegate(System.IntPtr obj, System.IntPtr pd,   double amount);


     public delegate void efl_loop_throttle_set_api_delegate(System.IntPtr obj,   double amount);
     public static Efl.Eo.FunctionWrapper<efl_loop_throttle_set_api_delegate> efl_loop_throttle_set_ptr = new Efl.Eo.FunctionWrapper<efl_loop_throttle_set_api_delegate>(_Module, "efl_loop_throttle_set");
     private static void throttle_set(System.IntPtr obj, System.IntPtr pd,  double amount)
    {
        Eina.Log.Debug("function efl_loop_throttle_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((Loop)wrapper).SetThrottle( amount);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_loop_throttle_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  amount);
        }
    }
    private static efl_loop_throttle_set_delegate efl_loop_throttle_set_static_delegate;


     private delegate double efl_loop_time_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate double efl_loop_time_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_loop_time_get_api_delegate> efl_loop_time_get_ptr = new Efl.Eo.FunctionWrapper<efl_loop_time_get_api_delegate>(_Module, "efl_loop_time_get");
     private static double time_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_loop_time_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        double _ret_var = default(double);
            try {
                _ret_var = ((Loop)wrapper).GetTime();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_loop_time_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_loop_time_get_delegate efl_loop_time_get_static_delegate;


     private delegate void efl_loop_time_set_delegate(System.IntPtr obj, System.IntPtr pd,   double timepoint);


     public delegate void efl_loop_time_set_api_delegate(System.IntPtr obj,   double timepoint);
     public static Efl.Eo.FunctionWrapper<efl_loop_time_set_api_delegate> efl_loop_time_set_ptr = new Efl.Eo.FunctionWrapper<efl_loop_time_set_api_delegate>(_Module, "efl_loop_time_set");
     private static void time_set(System.IntPtr obj, System.IntPtr pd,  double timepoint)
    {
        Eina.Log.Debug("function efl_loop_time_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((Loop)wrapper).SetTime( timepoint);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_loop_time_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  timepoint);
        }
    }
    private static efl_loop_time_set_delegate efl_loop_time_set_static_delegate;


     private delegate void efl_loop_iterate_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate void efl_loop_iterate_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_loop_iterate_api_delegate> efl_loop_iterate_ptr = new Efl.Eo.FunctionWrapper<efl_loop_iterate_api_delegate>(_Module, "efl_loop_iterate");
     private static void iterate(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_loop_iterate was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        
            try {
                ((Loop)wrapper).Iterate();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                } else {
            efl_loop_iterate_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_loop_iterate_delegate efl_loop_iterate_static_delegate;


     private delegate int efl_loop_iterate_may_block_delegate(System.IntPtr obj, System.IntPtr pd,   int may_block);


     public delegate int efl_loop_iterate_may_block_api_delegate(System.IntPtr obj,   int may_block);
     public static Efl.Eo.FunctionWrapper<efl_loop_iterate_may_block_api_delegate> efl_loop_iterate_may_block_ptr = new Efl.Eo.FunctionWrapper<efl_loop_iterate_may_block_api_delegate>(_Module, "efl_loop_iterate_may_block");
     private static int iterate_may_block(System.IntPtr obj, System.IntPtr pd,  int may_block)
    {
        Eina.Log.Debug("function efl_loop_iterate_may_block was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                int _ret_var = default(int);
            try {
                _ret_var = ((Loop)wrapper).IterateMayBlock( may_block);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                        return _ret_var;
        } else {
            return efl_loop_iterate_may_block_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  may_block);
        }
    }
    private static efl_loop_iterate_may_block_delegate efl_loop_iterate_may_block_static_delegate;


     [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.ValueMarshaler))] private delegate Eina.Value efl_loop_begin_delegate(System.IntPtr obj, System.IntPtr pd);


     [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.ValueMarshaler))] public delegate Eina.Value efl_loop_begin_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_loop_begin_api_delegate> efl_loop_begin_ptr = new Efl.Eo.FunctionWrapper<efl_loop_begin_api_delegate>(_Module, "efl_loop_begin");
     private static Eina.Value begin(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_loop_begin was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Eina.Value _ret_var = default(Eina.Value);
            try {
                _ret_var = ((Loop)wrapper).Begin();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_loop_begin_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_loop_begin_delegate efl_loop_begin_static_delegate;


     private delegate void efl_loop_quit_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.ValueNative exit_code);


     public delegate void efl_loop_quit_api_delegate(System.IntPtr obj,   Eina.ValueNative exit_code);
     public static Efl.Eo.FunctionWrapper<efl_loop_quit_api_delegate> efl_loop_quit_ptr = new Efl.Eo.FunctionWrapper<efl_loop_quit_api_delegate>(_Module, "efl_loop_quit");
     private static void quit(System.IntPtr obj, System.IntPtr pd,  Eina.ValueNative exit_code)
    {
        Eina.Log.Debug("function efl_loop_quit was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                    var _in_exit_code = new Eina.Value(exit_code);
                            
            try {
                ((Loop)wrapper).Quit( _in_exit_code);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_loop_quit_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  exit_code);
        }
    }
    private static efl_loop_quit_delegate efl_loop_quit_static_delegate;


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))] private delegate  Eina.Future efl_loop_job_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))] public delegate  Eina.Future efl_loop_job_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_loop_job_api_delegate> efl_loop_job_ptr = new Efl.Eo.FunctionWrapper<efl_loop_job_api_delegate>(_Module, "efl_loop_job");
     private static  Eina.Future job(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_loop_job was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                         Eina.Future _ret_var = default( Eina.Future);
            try {
                _ret_var = ((Loop)wrapper).Job();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_loop_job_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_loop_job_delegate efl_loop_job_static_delegate;


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))] private delegate  Eina.Future efl_loop_idle_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))] public delegate  Eina.Future efl_loop_idle_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_loop_idle_api_delegate> efl_loop_idle_ptr = new Efl.Eo.FunctionWrapper<efl_loop_idle_api_delegate>(_Module, "efl_loop_idle");
     private static  Eina.Future idle(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_loop_idle was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                         Eina.Future _ret_var = default( Eina.Future);
            try {
                _ret_var = ((Loop)wrapper).Idle();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_loop_idle_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_loop_idle_delegate efl_loop_idle_static_delegate;


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))] private delegate  Eina.Future efl_loop_timeout_delegate(System.IntPtr obj, System.IntPtr pd,   double time);


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))] public delegate  Eina.Future efl_loop_timeout_api_delegate(System.IntPtr obj,   double time);
     public static Efl.Eo.FunctionWrapper<efl_loop_timeout_api_delegate> efl_loop_timeout_ptr = new Efl.Eo.FunctionWrapper<efl_loop_timeout_api_delegate>(_Module, "efl_loop_timeout");
     private static  Eina.Future timeout(System.IntPtr obj, System.IntPtr pd,  double time)
    {
        Eina.Log.Debug("function efl_loop_timeout was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                 Eina.Future _ret_var = default( Eina.Future);
            try {
                _ret_var = ((Loop)wrapper).Timeout( time);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                        return _ret_var;
        } else {
            return efl_loop_timeout_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  time);
        }
    }
    private static efl_loop_timeout_delegate efl_loop_timeout_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_loop_register_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEflClass))]  Type klass, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object provider);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_loop_register_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEflClass))]  Type klass, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object provider);
     public static Efl.Eo.FunctionWrapper<efl_loop_register_api_delegate> efl_loop_register_ptr = new Efl.Eo.FunctionWrapper<efl_loop_register_api_delegate>(_Module, "efl_loop_register");
     private static bool register(System.IntPtr obj, System.IntPtr pd,  Type klass,  Efl.Object provider)
    {
        Eina.Log.Debug("function efl_loop_register was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                        bool _ret_var = default(bool);
            try {
                _ret_var = ((Loop)wrapper).Register( klass,  provider);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                        return _ret_var;
        } else {
            return efl_loop_register_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  klass,  provider);
        }
    }
    private static efl_loop_register_delegate efl_loop_register_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_loop_unregister_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEflClass))]  Type klass, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object provider);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_loop_unregister_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEflClass))]  Type klass, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object provider);
     public static Efl.Eo.FunctionWrapper<efl_loop_unregister_api_delegate> efl_loop_unregister_ptr = new Efl.Eo.FunctionWrapper<efl_loop_unregister_api_delegate>(_Module, "efl_loop_unregister");
     private static bool unregister(System.IntPtr obj, System.IntPtr pd,  Type klass,  Efl.Object provider)
    {
        Eina.Log.Debug("function efl_loop_unregister was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                        bool _ret_var = default(bool);
            try {
                _ret_var = ((Loop)wrapper).Unregister( klass,  provider);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                        return _ret_var;
        } else {
            return efl_loop_unregister_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  klass,  provider);
        }
    }
    private static efl_loop_unregister_delegate efl_loop_unregister_static_delegate;
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
        Eina.Array<System.String> Argv=default(Eina.Array<System.String>),
        bool Initialization=default(bool)    )
    {
        this.Argv = Argv;
        this.Initialization = Initialization;
    }

    public static implicit operator LoopArguments(IntPtr ptr)
    {
        var tmp = (LoopArguments.NativeStruct)Marshal.PtrToStructure(ptr, typeof(LoopArguments.NativeStruct));
        return tmp;
    }

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

}

} 
