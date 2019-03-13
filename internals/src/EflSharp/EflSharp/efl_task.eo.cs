#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { 
/// <summary>No description supplied.</summary>
[TaskNativeInherit]
public class Task : Efl.LoopConsumer, Efl.Eo.IWrapper
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.TaskNativeInherit nativeInherit = new Efl.TaskNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (Task))
            return Efl.TaskNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
      }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)] internal static extern System.IntPtr
      efl_task_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   public Task(Efl.Object parent= null
         ) :
      base(efl_task_class_get(), typeof(Task), parent)
   {
      FinishInstantiation();
   }
   ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
   public Task(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
   protected Task(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static Task static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new Task(obj.NativeHandle);
   }
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
   protected override void register_event_proxies()
   {
      base.register_event_proxies();
   }
   /// <summary>The priority of this task.</summary>
   /// <returns>No description supplied.</returns>
   virtual public Efl.TaskPriority GetPriority() {
       var _ret_var = Efl.TaskNativeInherit.efl_task_priority_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>The priority of this task.</summary>
   /// <param name="priority">No description supplied.</param>
   /// <returns></returns>
   virtual public  void SetPriority( Efl.TaskPriority priority) {
                         Efl.TaskNativeInherit.efl_task_priority_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), priority);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>The final exit code of this task.</summary>
   /// <returns>No description supplied.</returns>
   virtual public  int GetExitCode() {
       var _ret_var = Efl.TaskNativeInherit.efl_task_exit_code_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary></summary>
   /// <returns>No description supplied.</returns>
   virtual public Efl.TaskFlags GetFlags() {
       var _ret_var = Efl.TaskNativeInherit.efl_task_flags_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary></summary>
   /// <param name="flags">No description supplied.</param>
   /// <returns></returns>
   virtual public  void SetFlags( Efl.TaskFlags flags) {
                         Efl.TaskNativeInherit.efl_task_flags_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), flags);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Actually run the task</summary>
   /// <returns>A future triggered when task exits and is passed int exit code</returns>
   virtual public  Eina.Future Run() {
       var _ret_var = Efl.TaskNativeInherit.efl_task_run_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Request the task end (may send a signal or interrupt signal resulting in a terminate event being tiggered in the target task loop)</summary>
   /// <returns></returns>
   virtual public  void End() {
       Efl.TaskNativeInherit.efl_task_end_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }
   public System.Threading.Tasks.Task<Eina.Value> RunAsync( System.Threading.CancellationToken token=default(System.Threading.CancellationToken))
   {
      Eina.Future future = Run();
      return Efl.Eo.Globals.WrapAsync(future, token);
   }
   /// <summary>The priority of this task.</summary>
/// <value>No description supplied.</value>
   public Efl.TaskPriority Priority {
      get { return GetPriority(); }
      set { SetPriority( value); }
   }
   /// <summary>The final exit code of this task.</summary>
/// <value>No description supplied.</value>
   public  int ExitCode {
      get { return GetExitCode(); }
   }
   /// <summary></summary>
/// <value>No description supplied.</value>
   public Efl.TaskFlags Flags {
      get { return GetFlags(); }
      set { SetFlags( value); }
   }
   private static new  IntPtr GetEflClassStatic()
   {
      return Efl.Task.efl_task_class_get();
   }
}
public class TaskNativeInherit : Efl.LoopConsumerNativeInherit{
   public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Ecore);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      if (efl_task_priority_get_static_delegate == null)
      efl_task_priority_get_static_delegate = new efl_task_priority_get_delegate(priority_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_task_priority_get"), func = Marshal.GetFunctionPointerForDelegate(efl_task_priority_get_static_delegate)});
      if (efl_task_priority_set_static_delegate == null)
      efl_task_priority_set_static_delegate = new efl_task_priority_set_delegate(priority_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_task_priority_set"), func = Marshal.GetFunctionPointerForDelegate(efl_task_priority_set_static_delegate)});
      if (efl_task_exit_code_get_static_delegate == null)
      efl_task_exit_code_get_static_delegate = new efl_task_exit_code_get_delegate(exit_code_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_task_exit_code_get"), func = Marshal.GetFunctionPointerForDelegate(efl_task_exit_code_get_static_delegate)});
      if (efl_task_flags_get_static_delegate == null)
      efl_task_flags_get_static_delegate = new efl_task_flags_get_delegate(flags_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_task_flags_get"), func = Marshal.GetFunctionPointerForDelegate(efl_task_flags_get_static_delegate)});
      if (efl_task_flags_set_static_delegate == null)
      efl_task_flags_set_static_delegate = new efl_task_flags_set_delegate(flags_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_task_flags_set"), func = Marshal.GetFunctionPointerForDelegate(efl_task_flags_set_static_delegate)});
      if (efl_task_run_static_delegate == null)
      efl_task_run_static_delegate = new efl_task_run_delegate(run);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_task_run"), func = Marshal.GetFunctionPointerForDelegate(efl_task_run_static_delegate)});
      if (efl_task_end_static_delegate == null)
      efl_task_end_static_delegate = new efl_task_end_delegate(end);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_task_end"), func = Marshal.GetFunctionPointerForDelegate(efl_task_end_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Task.efl_task_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Task.efl_task_class_get();
   }


    private delegate Efl.TaskPriority efl_task_priority_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Efl.TaskPriority efl_task_priority_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_task_priority_get_api_delegate> efl_task_priority_get_ptr = new Efl.Eo.FunctionWrapper<efl_task_priority_get_api_delegate>(_Module, "efl_task_priority_get");
    private static Efl.TaskPriority priority_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_task_priority_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.TaskPriority _ret_var = default(Efl.TaskPriority);
         try {
            _ret_var = ((Task)wrapper).GetPriority();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_task_priority_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_task_priority_get_delegate efl_task_priority_get_static_delegate;


    private delegate  void efl_task_priority_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TaskPriority priority);


    public delegate  void efl_task_priority_set_api_delegate(System.IntPtr obj,   Efl.TaskPriority priority);
    public static Efl.Eo.FunctionWrapper<efl_task_priority_set_api_delegate> efl_task_priority_set_ptr = new Efl.Eo.FunctionWrapper<efl_task_priority_set_api_delegate>(_Module, "efl_task_priority_set");
    private static  void priority_set(System.IntPtr obj, System.IntPtr pd,  Efl.TaskPriority priority)
   {
      Eina.Log.Debug("function efl_task_priority_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Task)wrapper).SetPriority( priority);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_task_priority_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  priority);
      }
   }
   private static efl_task_priority_set_delegate efl_task_priority_set_static_delegate;


    private delegate  int efl_task_exit_code_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  int efl_task_exit_code_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_task_exit_code_get_api_delegate> efl_task_exit_code_get_ptr = new Efl.Eo.FunctionWrapper<efl_task_exit_code_get_api_delegate>(_Module, "efl_task_exit_code_get");
    private static  int exit_code_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_task_exit_code_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   int _ret_var = default( int);
         try {
            _ret_var = ((Task)wrapper).GetExitCode();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_task_exit_code_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_task_exit_code_get_delegate efl_task_exit_code_get_static_delegate;


    private delegate Efl.TaskFlags efl_task_flags_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Efl.TaskFlags efl_task_flags_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_task_flags_get_api_delegate> efl_task_flags_get_ptr = new Efl.Eo.FunctionWrapper<efl_task_flags_get_api_delegate>(_Module, "efl_task_flags_get");
    private static Efl.TaskFlags flags_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_task_flags_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.TaskFlags _ret_var = default(Efl.TaskFlags);
         try {
            _ret_var = ((Task)wrapper).GetFlags();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_task_flags_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_task_flags_get_delegate efl_task_flags_get_static_delegate;


    private delegate  void efl_task_flags_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TaskFlags flags);


    public delegate  void efl_task_flags_set_api_delegate(System.IntPtr obj,   Efl.TaskFlags flags);
    public static Efl.Eo.FunctionWrapper<efl_task_flags_set_api_delegate> efl_task_flags_set_ptr = new Efl.Eo.FunctionWrapper<efl_task_flags_set_api_delegate>(_Module, "efl_task_flags_set");
    private static  void flags_set(System.IntPtr obj, System.IntPtr pd,  Efl.TaskFlags flags)
   {
      Eina.Log.Debug("function efl_task_flags_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Task)wrapper).SetFlags( flags);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_task_flags_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  flags);
      }
   }
   private static efl_task_flags_set_delegate efl_task_flags_set_static_delegate;


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))] private delegate  Eina.Future efl_task_run_delegate(System.IntPtr obj, System.IntPtr pd);


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))] public delegate  Eina.Future efl_task_run_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_task_run_api_delegate> efl_task_run_ptr = new Efl.Eo.FunctionWrapper<efl_task_run_api_delegate>(_Module, "efl_task_run");
    private static  Eina.Future run(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_task_run was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   Eina.Future _ret_var = default( Eina.Future);
         try {
            _ret_var = ((Task)wrapper).Run();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_task_run_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_task_run_delegate efl_task_run_static_delegate;


    private delegate  void efl_task_end_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  void efl_task_end_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_task_end_api_delegate> efl_task_end_ptr = new Efl.Eo.FunctionWrapper<efl_task_end_api_delegate>(_Module, "efl_task_end");
    private static  void end(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_task_end was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Task)wrapper).End();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_task_end_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_task_end_delegate efl_task_end_static_delegate;
}
} 
namespace Efl { 
/// <summary>No description supplied.</summary>
public enum TaskPriority
{
/// <summary></summary>
Normal = 0,
/// <summary></summary>
Background = 1,
/// <summary></summary>
Low = 2,
/// <summary></summary>
High = 3,
/// <summary></summary>
Ultra = 4,
}
} 
namespace Efl { 
/// <summary>No description supplied.</summary>
public enum TaskFlags
{
/// <summary></summary>
None = 0,
/// <summary></summary>
UseStdin = 1,
/// <summary></summary>
UseStdout = 2,
/// <summary></summary>
NoExitCodeError = 4,
}
} 
