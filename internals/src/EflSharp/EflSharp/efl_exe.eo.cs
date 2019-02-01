#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { 
/// <summary>No description supplied.</summary>
[ExeNativeInherit]
public class Exe : Efl.Task, Efl.Eo.IWrapper
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.ExeNativeInherit nativeInherit = new Efl.ExeNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (Exe))
            return Efl.ExeNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   ///<summary>Delegate for function to be called from inside the native constructor.</summary>
   public new delegate void ConstructingMethod(Exe obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)] internal static extern System.IntPtr
      efl_exe_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="init_cb">Delegate to call constructing methods that should be run inside the constructor.</param>
   public Exe(Efl.Object parent = null, ConstructingMethod init_cb=null) : base("Exe", efl_exe_class_get(), typeof(Exe), parent)
   {
      if (init_cb != null) {
         init_cb(this);
      }
      FinishInstantiation();
   }
   ///<summary>Internal constructor to forward the wrapper initialization to the root class.</summary>
   protected Exe(String klass_name, IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(klass_name, base_klass, managed_type, parent) {}
   ///<summary>Constructs an instance from a native pointer.</summary>
   public Exe(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static Exe static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new Exe(obj.NativeHandle);
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


   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]
    protected static extern Efl.ExeFlags efl_exe_flags_get(System.IntPtr obj);
   /// <summary></summary>
   /// <returns>No description supplied.</returns>
   virtual public Efl.ExeFlags GetExeFlags() {
       var _ret_var = efl_exe_flags_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]
    protected static extern  void efl_exe_flags_set(System.IntPtr obj,   Efl.ExeFlags flags);
   /// <summary></summary>
   /// <param name="flags">No description supplied.</param>
   /// <returns></returns>
   virtual public  void SetExeFlags( Efl.ExeFlags flags) {
                         efl_exe_flags_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  flags);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]
    protected static extern  int efl_exe_exit_signal_get(System.IntPtr obj);
   /// <summary>The final exit signal of this task.</summary>
   /// <returns>The exit signal, or -1 if no exit signal happened</returns>
   virtual public  int GetExitSignal() {
       var _ret_var = efl_exe_exit_signal_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]
    protected static extern  void efl_exe_signal(System.IntPtr obj,   Efl.ExeSignal sig);
   /// <summary></summary>
   /// <param name="sig">Send this signal to the task</param>
   /// <returns></returns>
   virtual public  void Signal( Efl.ExeSignal sig) {
                         efl_exe_signal((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  sig);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary></summary>
   public Efl.ExeFlags ExeFlags {
      get { return GetExeFlags(); }
      set { SetExeFlags( value); }
   }
   /// <summary>The final exit signal of this task.</summary>
   public  int ExitSignal {
      get { return GetExitSignal(); }
   }
}
public class ExeNativeInherit : Efl.TaskNativeInherit{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_exe_flags_get_static_delegate = new efl_exe_flags_get_delegate(exe_flags_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_exe_flags_get"), func = Marshal.GetFunctionPointerForDelegate(efl_exe_flags_get_static_delegate)});
      efl_exe_flags_set_static_delegate = new efl_exe_flags_set_delegate(exe_flags_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_exe_flags_set"), func = Marshal.GetFunctionPointerForDelegate(efl_exe_flags_set_static_delegate)});
      efl_exe_exit_signal_get_static_delegate = new efl_exe_exit_signal_get_delegate(exit_signal_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_exe_exit_signal_get"), func = Marshal.GetFunctionPointerForDelegate(efl_exe_exit_signal_get_static_delegate)});
      efl_exe_signal_static_delegate = new efl_exe_signal_delegate(signal);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_exe_signal"), func = Marshal.GetFunctionPointerForDelegate(efl_exe_signal_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Exe.efl_exe_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Exe.efl_exe_class_get();
   }


    private delegate Efl.ExeFlags efl_exe_flags_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]  private static extern Efl.ExeFlags efl_exe_flags_get(System.IntPtr obj);
    private static Efl.ExeFlags exe_flags_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_exe_flags_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.ExeFlags _ret_var = default(Efl.ExeFlags);
         try {
            _ret_var = ((Exe)wrapper).GetExeFlags();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_exe_flags_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_exe_flags_get_delegate efl_exe_flags_get_static_delegate;


    private delegate  void efl_exe_flags_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.ExeFlags flags);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]  private static extern  void efl_exe_flags_set(System.IntPtr obj,   Efl.ExeFlags flags);
    private static  void exe_flags_set(System.IntPtr obj, System.IntPtr pd,  Efl.ExeFlags flags)
   {
      Eina.Log.Debug("function efl_exe_flags_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Exe)wrapper).SetExeFlags( flags);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_exe_flags_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  flags);
      }
   }
   private efl_exe_flags_set_delegate efl_exe_flags_set_static_delegate;


    private delegate  int efl_exe_exit_signal_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]  private static extern  int efl_exe_exit_signal_get(System.IntPtr obj);
    private static  int exit_signal_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_exe_exit_signal_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   int _ret_var = default( int);
         try {
            _ret_var = ((Exe)wrapper).GetExitSignal();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_exe_exit_signal_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_exe_exit_signal_get_delegate efl_exe_exit_signal_get_static_delegate;


    private delegate  void efl_exe_signal_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.ExeSignal sig);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]  private static extern  void efl_exe_signal(System.IntPtr obj,   Efl.ExeSignal sig);
    private static  void signal(System.IntPtr obj, System.IntPtr pd,  Efl.ExeSignal sig)
   {
      Eina.Log.Debug("function efl_exe_signal was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Exe)wrapper).Signal( sig);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_exe_signal(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  sig);
      }
   }
   private efl_exe_signal_delegate efl_exe_signal_static_delegate;
}
} 
namespace Efl { 
/// <summary>No description supplied.</summary>
public enum ExeSignal
{
/// <summary></summary>
Int = 0,
/// <summary></summary>
Quit = 1,
/// <summary></summary>
Term = 2,
/// <summary></summary>
Kill = 3,
/// <summary></summary>
Cont = 4,
/// <summary></summary>
Stop = 5,
/// <summary></summary>
Hup = 6,
/// <summary></summary>
Usr1 = 7,
/// <summary></summary>
Usr2 = 8,
}
} 
namespace Efl { 
/// <summary>No description supplied.</summary>
public enum ExeFlags
{
/// <summary></summary>
None = 0,
/// <summary></summary>
GroupLeader = 1,
/// <summary></summary>
ExitWithParent = 2,
/// <summary></summary>
HideIo = 4,
}
} 
