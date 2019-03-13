#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { 
/// <summary>Efl boolean model class</summary>
[BooleanModelNativeInherit]
public class BooleanModel : Efl.CompositeModel, Efl.Eo.IWrapper
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.BooleanModelNativeInherit nativeInherit = new Efl.BooleanModelNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (BooleanModel))
            return Efl.BooleanModelNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
      }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)] internal static extern System.IntPtr
      efl_boolean_model_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="model">Model that is/will be See <see cref="Efl.Ui.View.SetModel"/></param>
   ///<param name="index">Position of this object in the parent model. See <see cref="Efl.CompositeModel.SetIndex"/></param>
   public BooleanModel(Efl.Object parent
         , Efl.Model model,  uint? index = null) :
      base(efl_boolean_model_class_get(), typeof(BooleanModel), parent)
   {
      if (Efl.Eo.Globals.ParamHelperCheck(model))
         SetModel(Efl.Eo.Globals.GetParamHelper(model));
      if (Efl.Eo.Globals.ParamHelperCheck(index))
         SetIndex(Efl.Eo.Globals.GetParamHelper(index));
      FinishInstantiation();
   }
   ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
   public BooleanModel(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
   protected BooleanModel(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static BooleanModel static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new BooleanModel(obj.NativeHandle);
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
   /// <summary>Add a new named boolean property with a defined default value.</summary>
   /// <param name="name"></param>
   /// <param name="default_value"></param>
   /// <returns></returns>
   virtual public  void AddBoolean(  System.String name,  bool default_value) {
                                           Efl.BooleanModelNativeInherit.efl_boolean_model_boolean_add_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), name,  default_value);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Delete an existing named boolean property</summary>
   /// <param name="name"></param>
   /// <returns></returns>
   virtual public  void DelBoolean(  System.String name) {
                         Efl.BooleanModelNativeInherit.efl_boolean_model_boolean_del_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), name);
      Eina.Error.RaiseIfUnhandledException();
                   }
   private static new  IntPtr GetEflClassStatic()
   {
      return Efl.BooleanModel.efl_boolean_model_class_get();
   }
}
public class BooleanModelNativeInherit : Efl.CompositeModelNativeInherit{
   public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Ecore);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      if (efl_boolean_model_boolean_add_static_delegate == null)
      efl_boolean_model_boolean_add_static_delegate = new efl_boolean_model_boolean_add_delegate(boolean_add);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_boolean_model_boolean_add"), func = Marshal.GetFunctionPointerForDelegate(efl_boolean_model_boolean_add_static_delegate)});
      if (efl_boolean_model_boolean_del_static_delegate == null)
      efl_boolean_model_boolean_del_static_delegate = new efl_boolean_model_boolean_del_delegate(boolean_del);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_boolean_model_boolean_del"), func = Marshal.GetFunctionPointerForDelegate(efl_boolean_model_boolean_del_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.BooleanModel.efl_boolean_model_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.BooleanModel.efl_boolean_model_class_get();
   }


    private delegate  void efl_boolean_model_boolean_add_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name,  [MarshalAs(UnmanagedType.U1)]  bool default_value);


    public delegate  void efl_boolean_model_boolean_add_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name,  [MarshalAs(UnmanagedType.U1)]  bool default_value);
    public static Efl.Eo.FunctionWrapper<efl_boolean_model_boolean_add_api_delegate> efl_boolean_model_boolean_add_ptr = new Efl.Eo.FunctionWrapper<efl_boolean_model_boolean_add_api_delegate>(_Module, "efl_boolean_model_boolean_add");
    private static  void boolean_add(System.IntPtr obj, System.IntPtr pd,   System.String name,  bool default_value)
   {
      Eina.Log.Debug("function efl_boolean_model_boolean_add was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((BooleanModel)wrapper).AddBoolean( name,  default_value);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_boolean_model_boolean_add_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  name,  default_value);
      }
   }
   private static efl_boolean_model_boolean_add_delegate efl_boolean_model_boolean_add_static_delegate;


    private delegate  void efl_boolean_model_boolean_del_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name);


    public delegate  void efl_boolean_model_boolean_del_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name);
    public static Efl.Eo.FunctionWrapper<efl_boolean_model_boolean_del_api_delegate> efl_boolean_model_boolean_del_ptr = new Efl.Eo.FunctionWrapper<efl_boolean_model_boolean_del_api_delegate>(_Module, "efl_boolean_model_boolean_del");
    private static  void boolean_del(System.IntPtr obj, System.IntPtr pd,   System.String name)
   {
      Eina.Log.Debug("function efl_boolean_model_boolean_del was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((BooleanModel)wrapper).DelBoolean( name);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_boolean_model_boolean_del_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  name);
      }
   }
   private static efl_boolean_model_boolean_del_delegate efl_boolean_model_boolean_del_static_delegate;
}
} 
