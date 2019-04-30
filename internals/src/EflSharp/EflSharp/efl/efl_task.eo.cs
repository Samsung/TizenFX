#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

/// <summary>No description supplied.
/// (Since EFL 1.22)</summary>
[Efl.Task.NativeMethods]
public abstract class Task : Efl.LoopConsumer, Efl.Eo.IWrapper
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
            ) : base(efl_task_class_get(), typeof(Task), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Initializes a new instance of the <see cref="Task"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="raw">The native pointer to be wrapped.</param>
    protected Task(System.IntPtr raw) : base(raw)
    {
            }

    [Efl.Eo.PrivateNativeClass]
    private class TaskRealized : Task
    {
        private TaskRealized(IntPtr ptr) : base(ptr)
        {
        }
    }
    /// <summary>Initializes a new instance of the <see cref="Task"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="managedType">The managed type of the public constructor that originated this call.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected Task(IntPtr baseKlass, System.Type managedType, Efl.Object parent) : base(baseKlass, managedType, parent)
    {
    }

    /// <summary>Verifies if the given object is equal to this one.</summary>
    /// <param name="instance">The object to compare to.</param>
    /// <returns>True if both objects point to the same native object.</returns>
    public override bool Equals(object instance)
    {
        var other = instance as Efl.Object;
        if (other == null)
        {
            return false;
        }
        return this.NativeHandle == other.NativeHandle;
    }

    /// <summary>Gets the hash code for this object based on the native pointer it points to.</summary>
    /// <returns>The value of the pointer, to be used as the hash code of this object.</returns>
    public override int GetHashCode()
    {
        return this.NativeHandle.ToInt32();
    }

    /// <summary>Turns the native pointer into a string representation.</summary>
    /// <returns>A string with the type and the native pointer for this object.</returns>
    public override String ToString()
    {
        return $"{this.GetType().Name}@[{this.NativeHandle.ToInt32():x}]";
    }

    /// <summary>The priority of this task.
    /// (Since EFL 1.22)</summary>
    /// <returns>No description supplied.</returns>
    virtual public Efl.TaskPriority GetPriority() {
         var _ret_var = Efl.Task.NativeMethods.efl_task_priority_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The priority of this task.
    /// (Since EFL 1.22)</summary>
    /// <param name="priority">No description supplied.</param>
    virtual public void SetPriority(Efl.TaskPriority priority) {
                                 Efl.Task.NativeMethods.efl_task_priority_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),priority);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The final exit code of this task.
    /// (Since EFL 1.22)</summary>
    /// <returns>No description supplied.</returns>
    virtual public int GetExitCode() {
         var _ret_var = Efl.Task.NativeMethods.efl_task_exit_code_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <returns>No description supplied.</returns>
    virtual public Efl.TaskFlags GetFlags() {
         var _ret_var = Efl.Task.NativeMethods.efl_task_flags_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <param name="flags">No description supplied.</param>
    virtual public void SetFlags(Efl.TaskFlags flags) {
                                 Efl.Task.NativeMethods.efl_task_flags_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),flags);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Actually run the task
    /// (Since EFL 1.22)</summary>
    /// <returns>A future triggered when task exits and is passed int exit code</returns>
    virtual public  Eina.Future Run() {
         var _ret_var = Efl.Task.NativeMethods.efl_task_run_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Request the task end (may send a signal or interrupt signal resulting in a terminate event being tiggered in the target task loop)
    /// (Since EFL 1.22)</summary>
    virtual public void End() {
         Efl.Task.NativeMethods.efl_task_end_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
         }
    public System.Threading.Tasks.Task<Eina.Value> RunAsync( System.Threading.CancellationToken token = default(System.Threading.CancellationToken))
    {
        Eina.Future future = Run();
        return Efl.Eo.Globals.WrapAsync(future, token);
    }
    /// <summary>The priority of this task.
/// (Since EFL 1.22)</summary>
/// <value>No description supplied.</value>
    public Efl.TaskPriority Priority {
        get { return GetPriority(); }
        set { SetPriority(value); }
    }
    /// <summary>The final exit code of this task.
/// (Since EFL 1.22)</summary>
/// <value>No description supplied.</value>
    public int ExitCode {
        get { return GetExitCode(); }
    }
    /// <value>No description supplied.</value>
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

        #pragma warning disable CA1707, SA1300, SA1600

        
        private delegate Efl.TaskPriority efl_task_priority_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.TaskPriority efl_task_priority_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_task_priority_get_api_delegate> efl_task_priority_get_ptr = new Efl.Eo.FunctionWrapper<efl_task_priority_get_api_delegate>(Module, "efl_task_priority_get");

        private static Efl.TaskPriority priority_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_task_priority_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            Efl.TaskPriority _ret_var = default(Efl.TaskPriority);
                try
                {
                    _ret_var = ((Task)wrapper).GetPriority();
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
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    
                try
                {
                    ((Task)wrapper).SetPriority(priority);
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
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            int _ret_var = default(int);
                try
                {
                    _ret_var = ((Task)wrapper).GetExitCode();
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
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            Efl.TaskFlags _ret_var = default(Efl.TaskFlags);
                try
                {
                    _ret_var = ((Task)wrapper).GetFlags();
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
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    
                try
                {
                    ((Task)wrapper).SetFlags(flags);
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
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
             Eina.Future _ret_var = default( Eina.Future);
                try
                {
                    _ret_var = ((Task)wrapper).Run();
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
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            
                try
                {
                    ((Task)wrapper).End();
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

        #pragma warning restore CA1707, SA1300, SA1600

}
}
}

namespace Efl {

/// <summary>No description supplied.
/// (Since EFL 1.22)</summary>
public enum TaskPriority
{
Normal = 0,
Background = 1,
Low = 2,
High = 3,
Ultra = 4,
}

}

namespace Efl {

/// <summary>No description supplied.
/// (Since EFL 1.22)</summary>
public enum TaskFlags
{
None = 0,
UseStdin = 1,
UseStdout = 2,
NoExitCodeError = 4,
}

}

