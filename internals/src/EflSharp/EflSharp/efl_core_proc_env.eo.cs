#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Core { 
/// <summary></summary>
[ProcEnvNativeInherit]
public class ProcEnv : Efl.Core.Env, Efl.Eo.IWrapper
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Core.ProcEnvNativeInherit nativeInherit = new Efl.Core.ProcEnvNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (ProcEnv))
            return Efl.Core.ProcEnvNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
      }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)] internal static extern System.IntPtr
      efl_core_proc_env_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   public ProcEnv(Efl.Object parent= null
         ) :
      base(efl_core_proc_env_class_get(), typeof(ProcEnv), parent)
   {
      FinishInstantiation();
   }
   ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
   public ProcEnv(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
   protected ProcEnv(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static ProcEnv static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new ProcEnv(obj.NativeHandle);
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
   /// <summary>Get a instance of this object
   /// The object will apply the environment operations onto this process.</summary>
   /// <returns></returns>
   public static Efl.Core.Env Self() {
       var _ret_var = Efl.Core.ProcEnvNativeInherit.efl_env_self_ptr.Value.Delegate();
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   private static new  IntPtr GetEflClassStatic()
   {
      return Efl.Core.ProcEnv.efl_core_proc_env_class_get();
   }
}
public class ProcEnvNativeInherit : Efl.Core.EnvNativeInherit{
   public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Ecore);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Core.ProcEnv.efl_core_proc_env_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Core.ProcEnv.efl_core_proc_env_class_get();
   }


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Core.Env, Efl.Eo.NonOwnTag>))] private delegate Efl.Core.Env efl_env_self_delegate();


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Core.Env, Efl.Eo.NonOwnTag>))] public delegate Efl.Core.Env efl_env_self_api_delegate();
    public static Efl.Eo.FunctionWrapper<efl_env_self_api_delegate> efl_env_self_ptr = new Efl.Eo.FunctionWrapper<efl_env_self_api_delegate>(_Module, "efl_env_self");
    private static Efl.Core.Env self(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_env_self was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Core.Env _ret_var = default(Efl.Core.Env);
         try {
            _ret_var = ProcEnv.Self();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_env_self_ptr.Value.Delegate();
      }
   }
}
} } 
