#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { 
/// <summary>Class used to create data models from Eina containers.
/// Each container supplied represents a series of property values, each item being the property value for a child object.
/// 
/// The data in the given containers are copied and stored internally.
/// 
/// Several containers can be supplied and the number of allocated children is based on the container of the largest size.</summary>
[ContainerModelNativeInherit]
public class ContainerModel : Efl.CompositeModel, Efl.Eo.IWrapper
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.ContainerModelNativeInherit nativeInherit = new Efl.ContainerModelNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (ContainerModel))
            return Efl.ContainerModelNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
      }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)] internal static extern System.IntPtr
      efl_container_model_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="model">Model that is/will be See <see cref="Efl.Ui.View.SetModel"/></param>
   ///<param name="index">Position of this object in the parent model. See <see cref="Efl.CompositeModel.SetIndex"/></param>
   public ContainerModel(Efl.Object parent
         , Efl.Model model,  uint? index = null) :
      base(efl_container_model_class_get(), typeof(ContainerModel), parent)
   {
      if (Efl.Eo.Globals.ParamHelperCheck(model))
         SetModel(Efl.Eo.Globals.GetParamHelper(model));
      if (Efl.Eo.Globals.ParamHelperCheck(index))
         SetIndex(Efl.Eo.Globals.GetParamHelper(index));
      FinishInstantiation();
   }
   ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
   public ContainerModel(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
   protected ContainerModel(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static ContainerModel static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new ContainerModel(obj.NativeHandle);
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
   /// <summary>Gets the type of the given property.</summary>
   /// <param name="name">Property name</param>
   /// <returns>Property type</returns>
   virtual public Eina.ValueType GetChildPropertyValueType(  System.String name) {
                         var _ret_var = Efl.ContainerModelNativeInherit.efl_container_model_child_property_value_type_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), name);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Adds the given property to child objects and supply the values.
   /// Each item will represent the value of the given property in the respective child within the data model.
   /// 
   /// New children objects are allocated as necessary.
   /// 
   /// Value type is required for compatibility with the <see cref="Efl.Model"/> API.</summary>
   /// <param name="name">Property name</param>
   /// <param name="type">Property type</param>
   /// <param name="values">Values to be added</param>
   /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
   virtual public bool AddChildProperty(  System.String name,  Eina.ValueType type,  Eina.Iterator< System.IntPtr> values) {
                   var _in_values = values.Handle;
values.Own = false;
                                          var _ret_var = Efl.ContainerModelNativeInherit.efl_container_model_child_property_add_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), name,  type,  _in_values);
      Eina.Error.RaiseIfUnhandledException();
                                          return _ret_var;
 }
   private static new  IntPtr GetEflClassStatic()
   {
      return Efl.ContainerModel.efl_container_model_class_get();
   }
}
public class ContainerModelNativeInherit : Efl.CompositeModelNativeInherit{
   public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Ecore);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      if (efl_container_model_child_property_value_type_get_static_delegate == null)
      efl_container_model_child_property_value_type_get_static_delegate = new efl_container_model_child_property_value_type_get_delegate(child_property_value_type_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_container_model_child_property_value_type_get"), func = Marshal.GetFunctionPointerForDelegate(efl_container_model_child_property_value_type_get_static_delegate)});
      if (efl_container_model_child_property_add_static_delegate == null)
      efl_container_model_child_property_add_static_delegate = new efl_container_model_child_property_add_delegate(child_property_add);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_container_model_child_property_add"), func = Marshal.GetFunctionPointerForDelegate(efl_container_model_child_property_add_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.ContainerModel.efl_container_model_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.ContainerModel.efl_container_model_class_get();
   }


    private delegate Eina.ValueType efl_container_model_child_property_value_type_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name);


    public delegate Eina.ValueType efl_container_model_child_property_value_type_get_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name);
    public static Efl.Eo.FunctionWrapper<efl_container_model_child_property_value_type_get_api_delegate> efl_container_model_child_property_value_type_get_ptr = new Efl.Eo.FunctionWrapper<efl_container_model_child_property_value_type_get_api_delegate>(_Module, "efl_container_model_child_property_value_type_get");
    private static Eina.ValueType child_property_value_type_get(System.IntPtr obj, System.IntPtr pd,   System.String name)
   {
      Eina.Log.Debug("function efl_container_model_child_property_value_type_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    Eina.ValueType _ret_var = default(Eina.ValueType);
         try {
            _ret_var = ((ContainerModel)wrapper).GetChildPropertyValueType( name);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_container_model_child_property_value_type_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  name);
      }
   }
   private static efl_container_model_child_property_value_type_get_delegate efl_container_model_child_property_value_type_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_container_model_child_property_add_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name,   Eina.ValueType type,    System.IntPtr values);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_container_model_child_property_add_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name,   Eina.ValueType type,    System.IntPtr values);
    public static Efl.Eo.FunctionWrapper<efl_container_model_child_property_add_api_delegate> efl_container_model_child_property_add_ptr = new Efl.Eo.FunctionWrapper<efl_container_model_child_property_add_api_delegate>(_Module, "efl_container_model_child_property_add");
    private static bool child_property_add(System.IntPtr obj, System.IntPtr pd,   System.String name,  Eina.ValueType type,   System.IntPtr values)
   {
      Eina.Log.Debug("function efl_container_model_child_property_add was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           var _in_values = new Eina.Iterator< System.IntPtr>(values, true, false);
                                             bool _ret_var = default(bool);
         try {
            _ret_var = ((ContainerModel)wrapper).AddChildProperty( name,  type,  _in_values);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                          return _ret_var;
      } else {
         return efl_container_model_child_property_add_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  name,  type,  values);
      }
   }
   private static efl_container_model_child_property_add_delegate efl_container_model_child_property_add_static_delegate;
}
} 
