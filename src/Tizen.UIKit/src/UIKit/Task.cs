#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace UIKit {

/// <summary>EFL&apos;s abstraction for a task (process).</summary>
/// <since_tizen> 6 </since_tizen>
[UIKit.Task.NativeMethods]
[UIKit.Wrapper.BindingEntity]
public abstract class Task : UIKit.LoopConsumer
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(Task))
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
        efl_task_class_get();

    /// <summary>Initializes a new instance of the <see cref="Task"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    /// <since_tizen> 6 </since_tizen>
    public Task(UIKit.Object parent= null
            ) : base(efl_task_class_get(), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    /// <since_tizen> 6 </since_tizen>
    protected Task(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Task"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    /// <since_tizen> 6 </since_tizen>
    protected Task(UIKit.Wrapper.Globals.WrappingHandle wh) : base(wh)
    {
    }

    [UIKit.Wrapper.PrivateNativeClass]
    private class TaskRealized : Task
    {
        private TaskRealized(UIKit.Wrapper.Globals.WrappingHandle wh) : base(wh)
        {
        }
    }
    /// <summary>Initializes a new instance of the <see cref="Task"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The UIKit.Object parent of this instance.</param>
    protected Task(IntPtr baseKlass, UIKit.Object parent) : base(baseKlass, parent)
    {
    }

    /// <summary>Called when the task exits. You can pick up any information you need at this point such as exit_code etc.</summary>
    /// <since_tizen> 6 </since_tizen>
    public event EventHandler ExitEvent
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

            string key = "_EFL_TASK_EVENT_EXIT";
            AddNativeEventHandler(UIKit.Libs.Ecore, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_TASK_EVENT_EXIT";
            RemoveNativeEventHandler(UIKit.Libs.Ecore, key, value);
        }
    }

    /// <summary>Method to raise event ExitEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnExitEvent(EventArgs e)
    {
        var key = "_EFL_TASK_EVENT_EXIT";
        IntPtr desc = UIKit.EventDescription.GetNative(UIKit.Libs.Ecore, key);
        if (desc == IntPtr.Zero)
        {
            UIKit.DataTypes.Log.Error($"Failed to get native event {key}");
            return;
        }

        UIKit.Wrapper.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }


    /// <summary>The priority of this task.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>Desired priority.</returns>
    public virtual UIKit.TaskPriority GetPriority() {
        var _ret_var = UIKit.Task.NativeMethods.efl_task_priority_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>The priority of this task.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="priority">Desired priority.</param>
    public virtual void SetPriority(UIKit.TaskPriority priority) {
        UIKit.Task.NativeMethods.efl_task_priority_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),priority);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>The final exit code of this task. This is the code that will be produced upon task completion.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The exit code.</returns>
    public virtual int GetExitCode() {
        var _ret_var = UIKit.Task.NativeMethods.efl_task_exit_code_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Flags to further customize task&apos;s behavior.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>Desired task flags.</returns>
    public virtual UIKit.TaskFlags GetFlags() {
        var _ret_var = UIKit.Task.NativeMethods.efl_task_flags_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Flags to further customize task&apos;s behavior.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="flags">Desired task flags.<br/>The default value is <see cref="UIKit.TaskFlags.ExitWithParent"/>.</param>
    public virtual void SetFlags(UIKit.TaskFlags flags) {
        UIKit.Task.NativeMethods.efl_task_flags_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),flags);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Actually run the task.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>On success in starting the task, return true, otherwise false</returns>
    public virtual bool Run() {
        var _ret_var = UIKit.Task.NativeMethods.efl_task_run_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Request the task end (may send a signal or interrupt signal resulting in a terminate event being triggered in the target task loop).</summary>
    /// <since_tizen> 6 </since_tizen>
    public virtual void End() {
        UIKit.Task.NativeMethods.efl_task_end_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>The priority of this task.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>Desired priority.</value>
    public UIKit.TaskPriority Priority {
        get { return GetPriority(); }
        set { SetPriority(value); }
    }

    /// <summary>The final exit code of this task. This is the code that will be produced upon task completion.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>The exit code.</value>
    public int ExitCode {
        get { return GetExitCode(); }
    }

    /// <summary>Flags to further customize task&apos;s behavior.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>Desired task flags.</value>
    public UIKit.TaskFlags Flags {
        get { return GetFlags(); }
        set { SetFlags(value); }
    }

    private static IntPtr GetUIKitClassStatic()
    {
        return UIKit.Task.efl_task_class_get();
    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : UIKit.LoopConsumer.NativeMethods
    {
        private static UIKit.Wrapper.NativeModule Module = new UIKit.Wrapper.NativeModule(UIKit.Libs.Ecore);

        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<UIKit_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<UIKit_Op_Description>();
            var methods = UIKit.Wrapper.Globals.GetUserMethods(type);

            if (efl_task_priority_get_static_delegate == null)
            {
                efl_task_priority_get_static_delegate = new efl_task_priority_get_delegate(priority_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetPriority") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_task_priority_get"), func = Marshal.GetFunctionPointerForDelegate(efl_task_priority_get_static_delegate) });
            }

            if (efl_task_priority_set_static_delegate == null)
            {
                efl_task_priority_set_static_delegate = new efl_task_priority_set_delegate(priority_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetPriority") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_task_priority_set"), func = Marshal.GetFunctionPointerForDelegate(efl_task_priority_set_static_delegate) });
            }

            if (efl_task_exit_code_get_static_delegate == null)
            {
                efl_task_exit_code_get_static_delegate = new efl_task_exit_code_get_delegate(exit_code_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetExitCode") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_task_exit_code_get"), func = Marshal.GetFunctionPointerForDelegate(efl_task_exit_code_get_static_delegate) });
            }

            if (efl_task_flags_get_static_delegate == null)
            {
                efl_task_flags_get_static_delegate = new efl_task_flags_get_delegate(flags_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFlags") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_task_flags_get"), func = Marshal.GetFunctionPointerForDelegate(efl_task_flags_get_static_delegate) });
            }

            if (efl_task_flags_set_static_delegate == null)
            {
                efl_task_flags_set_static_delegate = new efl_task_flags_set_delegate(flags_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFlags") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_task_flags_set"), func = Marshal.GetFunctionPointerForDelegate(efl_task_flags_set_static_delegate) });
            }

            if (efl_task_run_static_delegate == null)
            {
                efl_task_run_static_delegate = new efl_task_run_delegate(run);
            }

            if (methods.FirstOrDefault(m => m.Name == "Run") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_task_run"), func = Marshal.GetFunctionPointerForDelegate(efl_task_run_static_delegate) });
            }

            if (efl_task_end_static_delegate == null)
            {
                efl_task_end_static_delegate = new efl_task_end_delegate(end);
            }

            if (methods.FirstOrDefault(m => m.Name == "End") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_task_end"), func = Marshal.GetFunctionPointerForDelegate(efl_task_end_static_delegate) });
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
            return UIKit.Task.efl_task_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate UIKit.TaskPriority efl_task_priority_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate UIKit.TaskPriority efl_task_priority_get_api_delegate(System.IntPtr obj);

        public static UIKit.Wrapper.FunctionWrapper<efl_task_priority_get_api_delegate> efl_task_priority_get_ptr = new UIKit.Wrapper.FunctionWrapper<efl_task_priority_get_api_delegate>(Module, "efl_task_priority_get");

        private static UIKit.TaskPriority priority_get(System.IntPtr obj, System.IntPtr pd)
        {
            UIKit.DataTypes.Log.Debug("function efl_task_priority_get was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                UIKit.TaskPriority _ret_var = default(UIKit.TaskPriority);
                try
                {
                    _ret_var = ((Task)ws.Target).GetPriority();
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
                return efl_task_priority_get_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)));
            }
        }

        private static efl_task_priority_get_delegate efl_task_priority_get_static_delegate;

        
        private delegate void efl_task_priority_set_delegate(System.IntPtr obj, System.IntPtr pd,  UIKit.TaskPriority priority);

        
        public delegate void efl_task_priority_set_api_delegate(System.IntPtr obj,  UIKit.TaskPriority priority);

        public static UIKit.Wrapper.FunctionWrapper<efl_task_priority_set_api_delegate> efl_task_priority_set_ptr = new UIKit.Wrapper.FunctionWrapper<efl_task_priority_set_api_delegate>(Module, "efl_task_priority_set");

        private static void priority_set(System.IntPtr obj, System.IntPtr pd, UIKit.TaskPriority priority)
        {
            UIKit.DataTypes.Log.Debug("function efl_task_priority_set was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((Task)ws.Target).SetPriority(priority);
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_task_priority_set_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)), priority);
            }
        }

        private static efl_task_priority_set_delegate efl_task_priority_set_static_delegate;

        
        private delegate int efl_task_exit_code_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_task_exit_code_get_api_delegate(System.IntPtr obj);

        public static UIKit.Wrapper.FunctionWrapper<efl_task_exit_code_get_api_delegate> efl_task_exit_code_get_ptr = new UIKit.Wrapper.FunctionWrapper<efl_task_exit_code_get_api_delegate>(Module, "efl_task_exit_code_get");

        private static int exit_code_get(System.IntPtr obj, System.IntPtr pd)
        {
            UIKit.DataTypes.Log.Debug("function efl_task_exit_code_get was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                int _ret_var = default(int);
                try
                {
                    _ret_var = ((Task)ws.Target).GetExitCode();
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
                return efl_task_exit_code_get_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)));
            }
        }

        private static efl_task_exit_code_get_delegate efl_task_exit_code_get_static_delegate;

        
        private delegate UIKit.TaskFlags efl_task_flags_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate UIKit.TaskFlags efl_task_flags_get_api_delegate(System.IntPtr obj);

        public static UIKit.Wrapper.FunctionWrapper<efl_task_flags_get_api_delegate> efl_task_flags_get_ptr = new UIKit.Wrapper.FunctionWrapper<efl_task_flags_get_api_delegate>(Module, "efl_task_flags_get");

        private static UIKit.TaskFlags flags_get(System.IntPtr obj, System.IntPtr pd)
        {
            UIKit.DataTypes.Log.Debug("function efl_task_flags_get was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                UIKit.TaskFlags _ret_var = default(UIKit.TaskFlags);
                try
                {
                    _ret_var = ((Task)ws.Target).GetFlags();
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
                return efl_task_flags_get_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)));
            }
        }

        private static efl_task_flags_get_delegate efl_task_flags_get_static_delegate;

        
        private delegate void efl_task_flags_set_delegate(System.IntPtr obj, System.IntPtr pd,  UIKit.TaskFlags flags);

        
        public delegate void efl_task_flags_set_api_delegate(System.IntPtr obj,  UIKit.TaskFlags flags);

        public static UIKit.Wrapper.FunctionWrapper<efl_task_flags_set_api_delegate> efl_task_flags_set_ptr = new UIKit.Wrapper.FunctionWrapper<efl_task_flags_set_api_delegate>(Module, "efl_task_flags_set");

        private static void flags_set(System.IntPtr obj, System.IntPtr pd, UIKit.TaskFlags flags)
        {
            UIKit.DataTypes.Log.Debug("function efl_task_flags_set was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((Task)ws.Target).SetFlags(flags);
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_task_flags_set_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)), flags);
            }
        }

        private static efl_task_flags_set_delegate efl_task_flags_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_task_run_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_task_run_api_delegate(System.IntPtr obj);

        public static UIKit.Wrapper.FunctionWrapper<efl_task_run_api_delegate> efl_task_run_ptr = new UIKit.Wrapper.FunctionWrapper<efl_task_run_api_delegate>(Module, "efl_task_run");

        private static bool run(System.IntPtr obj, System.IntPtr pd)
        {
            UIKit.DataTypes.Log.Debug("function efl_task_run was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Task)ws.Target).Run();
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
                return efl_task_run_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)));
            }
        }

        private static efl_task_run_delegate efl_task_run_static_delegate;

        
        private delegate void efl_task_end_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_task_end_api_delegate(System.IntPtr obj);

        public static UIKit.Wrapper.FunctionWrapper<efl_task_end_api_delegate> efl_task_end_ptr = new UIKit.Wrapper.FunctionWrapper<efl_task_end_api_delegate>(Module, "efl_task_end");

        private static void end(System.IntPtr obj, System.IntPtr pd)
        {
            UIKit.DataTypes.Log.Debug("function efl_task_end was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((Task)ws.Target).End();
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_task_end_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)));
            }
        }

        private static efl_task_end_delegate efl_task_end_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

#if EFL_BETA
#pragma warning disable CS1591
public static class UIKitTask_ExtensionMethods {
}
#pragma warning restore CS1591
#endif
namespace UIKit {

/// <summary>How much processor time will this task get compared to other tasks running on the same processor.</summary>
/// <since_tizen> 6 </since_tizen>
[UIKit.Wrapper.BindingEntity]
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

namespace UIKit {

/// <summary>Flags to further customize task&apos;s behavior.</summary>
/// <since_tizen> 6 </since_tizen>
[UIKit.Wrapper.BindingEntity]
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
/// <summary>Exit when parent exits.</summary>
ExitWithParent = 8,
}
}

