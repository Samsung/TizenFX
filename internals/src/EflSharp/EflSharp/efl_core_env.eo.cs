#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Core { 
/// <summary>This object can maintain a set of key value pairs
/// A object of this type alone does not apply the object to the system. For getting the value into the system, see <see cref="Efl.Core.ProcEnv"/>.
/// 
/// A object can be forked, which will only copy its values, changes to the returned object will not change the object where it is forked off.</summary>
[EnvNativeInherit]
public class Env : Efl.Object, Efl.Eo.IWrapper,Efl.Duplicate
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Core.EnvNativeInherit nativeInherit = new Efl.Core.EnvNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (Env))
            return Efl.Core.EnvNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
      }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)] internal static extern System.IntPtr
      efl_core_env_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   public Env(Efl.Object parent= null
         ) :
      base(efl_core_env_class_get(), typeof(Env), parent)
   {
      FinishInstantiation();
   }
   ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
   public Env(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
   protected Env(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static Env static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new Env(obj.NativeHandle);
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
   /// <summary>Get the value of the <c>var</c>, or <c>null</c> if no such <c>var</c> exists in the object</summary>
   /// <param name="var">The name of the variable</param>
   /// <returns>Set var to this value if not <c>NULL</c>, otherwise clear this env value if value is <c>NULL</c> or if it is an empty string</returns>
   virtual public  System.String GetEnv(  System.String var) {
                         var _ret_var = Efl.Core.EnvNativeInherit.efl_core_env_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), var);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Add a new pair to this object</summary>
   /// <param name="var">The name of the variable</param>
   /// <param name="value">Set var to this value if not <c>NULL</c>, otherwise clear this env value if value is <c>NULL</c> or if it is an empty string</param>
   /// <returns></returns>
   virtual public  void SetEnv(  System.String var,   System.String value) {
                                           Efl.Core.EnvNativeInherit.efl_core_env_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), var,  value);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Get the content of this object.
   /// This will return a iterator that contains all keys that are part of this object.</summary>
   /// <returns></returns>
   virtual public Eina.Iterator< System.String> GetContent() {
       var _ret_var = Efl.Core.EnvNativeInherit.efl_core_env_content_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return new Eina.Iterator< System.String>(_ret_var, false, false);
 }
   /// <summary>Remove the pair with the matching <c>var</c> from this object</summary>
   /// <param name="var">The name of the variable</param>
   /// <returns></returns>
   virtual public  void Unset(  System.String var) {
                         Efl.Core.EnvNativeInherit.efl_core_env_unset_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), var);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Remove all pairs from this object</summary>
   /// <returns></returns>
   virtual public  void Clear() {
       Efl.Core.EnvNativeInherit.efl_core_env_clear_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }
   /// <summary>Creates a carbon copy of this object and returns it.
   /// The newly created object will have no event handlers or anything of the sort.</summary>
   /// <returns>Returned carbon copy</returns>
   virtual public Efl.Duplicate DoDuplicate() {
       var _ret_var = Efl.DuplicateNativeInherit.efl_duplicate_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Get the content of this object.
/// This will return a iterator that contains all keys that are part of this object.</summary>
/// <value></value>
   public Eina.Iterator< System.String> Content {
      get { return GetContent(); }
   }
   private static new  IntPtr GetEflClassStatic()
   {
      return Efl.Core.Env.efl_core_env_class_get();
   }
}
public class EnvNativeInherit : Efl.ObjectNativeInherit{
   public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Ecore);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      if (efl_core_env_get_static_delegate == null)
      efl_core_env_get_static_delegate = new efl_core_env_get_delegate(env_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_core_env_get"), func = Marshal.GetFunctionPointerForDelegate(efl_core_env_get_static_delegate)});
      if (efl_core_env_set_static_delegate == null)
      efl_core_env_set_static_delegate = new efl_core_env_set_delegate(env_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_core_env_set"), func = Marshal.GetFunctionPointerForDelegate(efl_core_env_set_static_delegate)});
      if (efl_core_env_content_get_static_delegate == null)
      efl_core_env_content_get_static_delegate = new efl_core_env_content_get_delegate(content_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_core_env_content_get"), func = Marshal.GetFunctionPointerForDelegate(efl_core_env_content_get_static_delegate)});
      if (efl_core_env_unset_static_delegate == null)
      efl_core_env_unset_static_delegate = new efl_core_env_unset_delegate(unset);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_core_env_unset"), func = Marshal.GetFunctionPointerForDelegate(efl_core_env_unset_static_delegate)});
      if (efl_core_env_clear_static_delegate == null)
      efl_core_env_clear_static_delegate = new efl_core_env_clear_delegate(clear);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_core_env_clear"), func = Marshal.GetFunctionPointerForDelegate(efl_core_env_clear_static_delegate)});
      if (efl_duplicate_static_delegate == null)
      efl_duplicate_static_delegate = new efl_duplicate_delegate(duplicate);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_duplicate"), func = Marshal.GetFunctionPointerForDelegate(efl_duplicate_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Core.Env.efl_core_env_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Core.Env.efl_core_env_class_get();
   }


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate  System.String efl_core_env_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String var);


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate  System.String efl_core_env_get_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String var);
    public static Efl.Eo.FunctionWrapper<efl_core_env_get_api_delegate> efl_core_env_get_ptr = new Efl.Eo.FunctionWrapper<efl_core_env_get_api_delegate>(_Module, "efl_core_env_get");
    private static  System.String env_get(System.IntPtr obj, System.IntPtr pd,   System.String var)
   {
      Eina.Log.Debug("function efl_core_env_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                     System.String _ret_var = default( System.String);
         try {
            _ret_var = ((Env)wrapper).GetEnv( var);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_core_env_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  var);
      }
   }
   private static efl_core_env_get_delegate efl_core_env_get_static_delegate;


    private delegate  void efl_core_env_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String var,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String value);


    public delegate  void efl_core_env_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String var,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String value);
    public static Efl.Eo.FunctionWrapper<efl_core_env_set_api_delegate> efl_core_env_set_ptr = new Efl.Eo.FunctionWrapper<efl_core_env_set_api_delegate>(_Module, "efl_core_env_set");
    private static  void env_set(System.IntPtr obj, System.IntPtr pd,   System.String var,   System.String value)
   {
      Eina.Log.Debug("function efl_core_env_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((Env)wrapper).SetEnv( var,  value);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_core_env_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  var,  value);
      }
   }
   private static efl_core_env_set_delegate efl_core_env_set_static_delegate;


    private delegate  System.IntPtr efl_core_env_content_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  System.IntPtr efl_core_env_content_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_core_env_content_get_api_delegate> efl_core_env_content_get_ptr = new Efl.Eo.FunctionWrapper<efl_core_env_content_get_api_delegate>(_Module, "efl_core_env_content_get");
    private static  System.IntPtr content_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_core_env_content_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Iterator< System.String> _ret_var = default(Eina.Iterator< System.String>);
         try {
            _ret_var = ((Env)wrapper).GetContent();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var.Handle;
      } else {
         return efl_core_env_content_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_core_env_content_get_delegate efl_core_env_content_get_static_delegate;


    private delegate  void efl_core_env_unset_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String var);


    public delegate  void efl_core_env_unset_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String var);
    public static Efl.Eo.FunctionWrapper<efl_core_env_unset_api_delegate> efl_core_env_unset_ptr = new Efl.Eo.FunctionWrapper<efl_core_env_unset_api_delegate>(_Module, "efl_core_env_unset");
    private static  void unset(System.IntPtr obj, System.IntPtr pd,   System.String var)
   {
      Eina.Log.Debug("function efl_core_env_unset was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Env)wrapper).Unset( var);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_core_env_unset_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  var);
      }
   }
   private static efl_core_env_unset_delegate efl_core_env_unset_static_delegate;


    private delegate  void efl_core_env_clear_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  void efl_core_env_clear_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_core_env_clear_api_delegate> efl_core_env_clear_ptr = new Efl.Eo.FunctionWrapper<efl_core_env_clear_api_delegate>(_Module, "efl_core_env_clear");
    private static  void clear(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_core_env_clear was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Env)wrapper).Clear();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_core_env_clear_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_core_env_clear_delegate efl_core_env_clear_static_delegate;


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.DuplicateConcrete, Efl.Eo.OwnTag>))] private delegate Efl.Duplicate efl_duplicate_delegate(System.IntPtr obj, System.IntPtr pd);


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.DuplicateConcrete, Efl.Eo.OwnTag>))] public delegate Efl.Duplicate efl_duplicate_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_duplicate_api_delegate> efl_duplicate_ptr = new Efl.Eo.FunctionWrapper<efl_duplicate_api_delegate>(_Module, "efl_duplicate");
    private static Efl.Duplicate duplicate(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_duplicate was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Duplicate _ret_var = default(Efl.Duplicate);
         try {
            _ret_var = ((Env)wrapper).DoDuplicate();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_duplicate_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_duplicate_delegate efl_duplicate_static_delegate;
}
} } 
