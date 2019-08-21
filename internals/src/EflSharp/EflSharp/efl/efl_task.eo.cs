#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

/// <summary>EFL&apos;s abstraction for a task (process).
/// (Since EFL 1.22)</summary>
[Efl.Task.NativeMethods]
[Efl.Eo.BindingEntity]
public abstract class Task : Efl.LoopConsumer
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(Task))
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
        efl_task_class_get();
    /// <summary>Initializes a new instance of the <see cref="Task"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public Task(Efl.Object parent= null
            ) : base(efl_task_class_get(), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Constructor to be used when objects are expected to be constructed from native code.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected Task(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Task"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected Task(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    [Efl.Eo.PrivateNativeClass]
    private class TaskRealized : Task
    {
        private TaskRealized(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
        {
        }
    }
    /// <summary>Initializes a new instance of the <see cref="Task"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected Task(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }

    /// <summary>The priority of this task.
    /// (Since EFL 1.22)</summary>
    /// <returns>Desired priority.</returns>
    virtual public Efl.TaskPriority GetPriority() {
         var _ret_var = Efl.Task.NativeMethods.efl_task_priority_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The priority of this task.
    /// (Since EFL 1.22)</summary>
    /// <param name="priority">Desired priority.</param>
    virtual public void SetPriority(Efl.TaskPriority priority) {
                                 Efl.Task.NativeMethods.efl_task_priority_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),priority);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The final exit code of this task. This is the code that will be produced upon task completion.
    /// (Since EFL 1.22)</summary>
    /// <returns>The exit code.</returns>
    virtual public int GetExitCode() {
         var _ret_var = Efl.Task.NativeMethods.efl_task_exit_code_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Flags to further customize task&apos;s behavior.
    /// (Since EFL 1.22)</summary>
    /// <returns>Desired task flags.</returns>
    virtual public Efl.TaskFlags GetFlags() {
         var _ret_var = Efl.Task.NativeMethods.efl_task_flags_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Flags to further customize task&apos;s behavior.
    /// (Since EFL 1.22)</summary>
    /// <param name="flags">Desired task flags.</param>
    virtual public void SetFlags(Efl.TaskFlags flags) {
                                 Efl.Task.NativeMethods.efl_task_flags_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),flags);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Actually run the task.
    /// (Since EFL 1.22)</summary>
    /// <returns>A future triggered when task exits and is passed int exit code.</returns>
    virtual public  Eina.Future Run() {
         var _ret_var = Efl.Task.NativeMethods.efl_task_run_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Request the task end (may send a signal or interrupt signal resulting in a terminate event being tiggered in the target task loop).
    /// (Since EFL 1.22)</summary>
    virtual public void End() {
         Efl.Task.NativeMethods.efl_task_end_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Async wrapper for <see cref="Run" />.</summary>
    /// <param name="token">Token to notify the async operation of external request to cancel.</param>
    /// <returns>An async task wrapping the result of the operation.</returns>
    public System.Threading.Tasks.Task<Eina.Value> RunAsync( System.Threading.CancellationToken token = default(System.Threading.CancellationToken))
    {
        Eina.Future future = Run();
        return Efl.Eo.Globals.WrapAsync(future, token);
    }

    /// <summary>The priority of this task.
    /// (Since EFL 1.22)</summary>
    /// <value>Desired priority.</value>
    public Efl.TaskPriority Priority {
        get { return GetPriority(); }
        set { SetPriority(value); }
    }
    /// <summary>The final exit code of this task. This is the code that will be produced upon task completion.
    /// (Since EFL 1.22)</summary>
    /// <value>The exit code.</value>
    public int ExitCode {
        get { return GetExitCode(); }
    }
    /// <summary>Flags to further customize task&apos;s behavior.
    /// (Since EFL 1.22)</summary>
    /// <value>Desired task flags.</value>
    public Efl.TaskFlags Flags {
        get { return GetFlags(); }
        set { SetFlags(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Task.efl_task_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.LoopConsumer.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Ecore);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_task_priority_get_static_delegate == null)
            {
                efl_task_priority_get_static_delegate = new efl_task_priority_get_delegate(priority_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetPriority") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_task_priority_get"), func = Marshal.GetFunctionPointerForDelegate(efl_task_priority_get_static_delegate) });
            }

            if (efl_task_priority_set_static_delegate == null)
            {
                efl_task_priority_set_static_delegate = new efl_task_priority_set_delegate(priority_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetPriority") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_task_priority_set"), func = Marshal.GetFunctionPointerForDelegate(efl_task_priority_set_static_delegate) });
            }

            if (efl_task_exit_code_get_static_delegate == null)
            {
                efl_task_exit_code_get_static_delegate = new efl_task_exit_code_get_delegate(exit_code_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetExitCode") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_task_exit_code_get"), func = Marshal.GetFunctionPointerForDelegate(efl_task_exit_code_get_static_delegate) });
            }

            if (efl_task_flags_get_static_delegate == null)
            {
                efl_task_flags_get_static_delegate = new efl_task_flags_get_delegate(flags_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFlags") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_task_flags_get"), func = Marshal.GetFunctionPointerForDelegate(efl_task_flags_get_static_delegate) });
            }

            if (efl_task_flags_set_static_delegate == null)
            {
                efl_task_flags_set_static_delegate = new efl_task_flags_set_delegate(flags_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFlags") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_task_flags_set"), func = Marshal.GetFunctionPointerForDelegate(efl_task_flags_set_static_delegate) });
            }

            if (efl_task_run_static_delegate == null)
            {
                efl_task_run_static_delegate = new efl_task_run_delegate(run);
            }

            if (methods.FirstOrDefault(m => m.Name == "Run") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_task_run"), func = Marshal.GetFunctionPointerForDelegate(efl_task_run_static_delegate) });
            }

            if (efl_task_end_static_delegate == null)
            {
                efl_task_end_static_delegate = new efl_task_end_delegate(end);
            }

            if (methods.FirstOrDefault(m => m.Name == "End") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_task_end"), func = Marshal.GetFunctionPointerForDelegate(efl_task_end_static_delegate) });
            }

            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Task.efl_task_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate Efl.TaskPriority efl_task_priority_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.TaskPriority efl_task_priority_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_task_priority_get_api_delegate> efl_task_priority_get_ptr = new Efl.Eo.FunctionWrapper<efl_task_priority_get_api_delegate>(Module, "efl_task_priority_get");

        private static Efl.TaskPriority priority_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_task_priority_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.TaskPriority _ret_var = default(Efl.TaskPriority);
                try
                {
                    _ret_var = ((Task)ws.Target).GetPriority();
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
                return efl_task_priority_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_task_priority_get_delegate efl_task_priority_get_static_delegate;

        
        private delegate void efl_task_priority_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TaskPriority priority);

        
        public delegate void efl_task_priority_set_api_delegate(System.IntPtr obj,  Efl.TaskPriority priority);

        public static Efl.Eo.FunctionWrapper<efl_task_priority_set_api_delegate> efl_task_priority_set_ptr = new Efl.Eo.FunctionWrapper<efl_task_priority_set_api_delegate>(Module, "efl_task_priority_set");

        private static void priority_set(System.IntPtr obj, System.IntPtr pd, Efl.TaskPriority priority)
        {
            Eina.Log.Debug("function efl_task_priority_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Task)ws.Target).SetPriority(priority);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_task_priority_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), priority);
            }
        }

        private static efl_task_priority_set_delegate efl_task_priority_set_static_delegate;

        
        private delegate int efl_task_exit_code_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_task_exit_code_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_task_exit_code_get_api_delegate> efl_task_exit_code_get_ptr = new Efl.Eo.FunctionWrapper<efl_task_exit_code_get_api_delegate>(Module, "efl_task_exit_code_get");

        private static int exit_code_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_task_exit_code_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            int _ret_var = default(int);
                try
                {
                    _ret_var = ((Task)ws.Target).GetExitCode();
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
                return efl_task_exit_code_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_task_exit_code_get_delegate efl_task_exit_code_get_static_delegate;

        
        private delegate Efl.TaskFlags efl_task_flags_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.TaskFlags efl_task_flags_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_task_flags_get_api_delegate> efl_task_flags_get_ptr = new Efl.Eo.FunctionWrapper<efl_task_flags_get_api_delegate>(Module, "efl_task_flags_get");

        private static Efl.TaskFlags flags_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_task_flags_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.TaskFlags _ret_var = default(Efl.TaskFlags);
                try
                {
                    _ret_var = ((Task)ws.Target).GetFlags();
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
                return efl_task_flags_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_task_flags_get_delegate efl_task_flags_get_static_delegate;

        
        private delegate void efl_task_flags_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TaskFlags flags);

        
        public delegate void efl_task_flags_set_api_delegate(System.IntPtr obj,  Efl.TaskFlags flags);

        public static Efl.Eo.FunctionWrapper<efl_task_flags_set_api_delegate> efl_task_flags_set_ptr = new Efl.Eo.FunctionWrapper<efl_task_flags_set_api_delegate>(Module, "efl_task_flags_set");

        private static void flags_set(System.IntPtr obj, System.IntPtr pd, Efl.TaskFlags flags)
        {
            Eina.Log.Debug("function efl_task_flags_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Task)ws.Target).SetFlags(flags);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_task_flags_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), flags);
            }
        }

        private static efl_task_flags_set_delegate efl_task_flags_set_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))]
        private delegate  Eina.Future efl_task_run_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))]
        public delegate  Eina.Future efl_task_run_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_task_run_api_delegate> efl_task_run_ptr = new Efl.Eo.FunctionWrapper<efl_task_run_api_delegate>(Module, "efl_task_run");

        private static  Eina.Future run(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_task_run was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
             Eina.Future _ret_var = default( Eina.Future);
                try
                {
                    _ret_var = ((Task)ws.Target).Run();
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
                return efl_task_run_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_task_run_delegate efl_task_run_static_delegate;

        
        private delegate void efl_task_end_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_task_end_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_task_end_api_delegate> efl_task_end_ptr = new Efl.Eo.FunctionWrapper<efl_task_end_api_delegate>(Module, "efl_task_end");

        private static void end(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_task_end was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((Task)ws.Target).End();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_task_end_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_task_end_delegate efl_task_end_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

namespace Efl {

/// <summary>How much processor time will this task get compared to other tasks running on the same processor.
/// (Since EFL 1.22)</summary>
[Efl.Eo.BindingEntity]
public enum TaskPriority
{
/// <summary>Neither above nor below average priority. This is the default.</summary>
Normal = 0,
/// <summary>Far below average priority.</summary>
Background = 1,
/// <summary>Below average priority.</summary>
Low = 2,
/// <summary>Above average priority.</summary>
High = 3,
/// <summary>Far above average priority.</summary>
Ultra = 4,
}

}

namespace Efl {

/// <summary>Flags to further customize task&apos;s behavior.
/// (Since EFL 1.22)</summary>
[Efl.Eo.BindingEntity]
public enum TaskFlags
{
/// <summary>No special flags.</summary>
None = 0,
/// <summary>Task will require console input.</summary>
UseStdin = 1,
/// <summary>Task will require console output.</summary>
UseStdout = 2,
/// <summary>Task will not produce an exit code upon termination.</summary>
NoExitCodeError = 4,
}

}

