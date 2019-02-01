#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { 
/// <summary>Class used to create data models from Eina containers.
/// Each container supplied represents a series of property values, each item being the property value for a child object (<see cref="Efl.ModelContainerItem"/>).
/// 
/// The data in the given containers are copied and stored internally.
/// 
/// Several containers can be supplied and the number of allocated children is based on the container of the largest size.</summary>
[ModelContainerNativeInherit]
public class ModelContainer : Efl.ModelLoop, Efl.Eo.IWrapper
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.ModelContainerNativeInherit nativeInherit = new Efl.ModelContainerNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (ModelContainer))
            return Efl.ModelContainerNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   ///<summary>Delegate for function to be called from inside the native constructor.</summary>
   public new delegate void ConstructingMethod(ModelContainer obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)] internal static extern System.IntPtr
      efl_model_container_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="init_cb">Delegate to call constructing methods that should be run inside the constructor.</param>
   public ModelContainer(Efl.Object parent = null, ConstructingMethod init_cb=null) : base("ModelContainer", efl_model_container_class_get(), typeof(ModelContainer), parent)
   {
      if (init_cb != null) {
         init_cb(this);
      }
      FinishInstantiation();
   }
   ///<summary>Internal constructor to forward the wrapper initialization to the root class.</summary>
   protected ModelContainer(String klass_name, IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(klass_name, base_klass, managed_type, parent) {}
   ///<summary>Constructs an instance from a native pointer.</summary>
   public ModelContainer(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static ModelContainer static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new ModelContainer(obj.NativeHandle);
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
    protected static extern Eina.ValueType efl_model_container_child_property_value_type_get(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name);
   /// <summary>Gets the type of the given property.</summary>
   /// <param name="name">Property name</param>
   /// <returns>Property type</returns>
   virtual public Eina.ValueType GetChildPropertyValueType(  System.String name) {
                         var _ret_var = efl_model_container_child_property_value_type_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  name);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]
    protected static extern  System.IntPtr efl_model_container_child_property_values_get(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name);
   /// <summary>Gets the values for the given property.</summary>
   /// <param name="name">Property name</param>
   /// <returns>The currently wrapped values</returns>
   virtual public Eina.Iterator< System.IntPtr> GetChildPropertyValues(  System.String name) {
                         var _ret_var = efl_model_container_child_property_values_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  name);
      Eina.Error.RaiseIfUnhandledException();
                  return new Eina.Iterator< System.IntPtr>(_ret_var, true, false);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_model_container_child_property_add(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name,   Eina.ValueType type,    System.IntPtr values);
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
                                          var _ret_var = efl_model_container_child_property_add((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  name,  type,  _in_values);
      Eina.Error.RaiseIfUnhandledException();
                                          return _ret_var;
 }
}
public class ModelContainerNativeInherit : Efl.ModelLoopNativeInherit{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_model_container_child_property_value_type_get_static_delegate = new efl_model_container_child_property_value_type_get_delegate(child_property_value_type_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_model_container_child_property_value_type_get"), func = Marshal.GetFunctionPointerForDelegate(efl_model_container_child_property_value_type_get_static_delegate)});
      efl_model_container_child_property_values_get_static_delegate = new efl_model_container_child_property_values_get_delegate(child_property_values_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_model_container_child_property_values_get"), func = Marshal.GetFunctionPointerForDelegate(efl_model_container_child_property_values_get_static_delegate)});
      efl_model_container_child_property_add_static_delegate = new efl_model_container_child_property_add_delegate(child_property_add);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_model_container_child_property_add"), func = Marshal.GetFunctionPointerForDelegate(efl_model_container_child_property_add_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.ModelContainer.efl_model_container_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.ModelContainer.efl_model_container_class_get();
   }


    private delegate Eina.ValueType efl_model_container_child_property_value_type_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]  private static extern Eina.ValueType efl_model_container_child_property_value_type_get(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name);
    private static Eina.ValueType child_property_value_type_get(System.IntPtr obj, System.IntPtr pd,   System.String name)
   {
      Eina.Log.Debug("function efl_model_container_child_property_value_type_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    Eina.ValueType _ret_var = default(Eina.ValueType);
         try {
            _ret_var = ((ModelContainer)wrapper).GetChildPropertyValueType( name);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_model_container_child_property_value_type_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  name);
      }
   }
   private efl_model_container_child_property_value_type_get_delegate efl_model_container_child_property_value_type_get_static_delegate;


    private delegate  System.IntPtr efl_model_container_child_property_values_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]  private static extern  System.IntPtr efl_model_container_child_property_values_get(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name);
    private static  System.IntPtr child_property_values_get(System.IntPtr obj, System.IntPtr pd,   System.String name)
   {
      Eina.Log.Debug("function efl_model_container_child_property_values_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    Eina.Iterator< System.IntPtr> _ret_var = default(Eina.Iterator< System.IntPtr>);
         try {
            _ret_var = ((ModelContainer)wrapper).GetChildPropertyValues( name);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  _ret_var.Own = false; return _ret_var.Handle;
      } else {
         return efl_model_container_child_property_values_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  name);
      }
   }
   private efl_model_container_child_property_values_get_delegate efl_model_container_child_property_values_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_model_container_child_property_add_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name,   Eina.ValueType type,    System.IntPtr values);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_model_container_child_property_add(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name,   Eina.ValueType type,    System.IntPtr values);
    private static bool child_property_add(System.IntPtr obj, System.IntPtr pd,   System.String name,  Eina.ValueType type,   System.IntPtr values)
   {
      Eina.Log.Debug("function efl_model_container_child_property_add was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           var _in_values = new Eina.Iterator< System.IntPtr>(values, true, false);
                                             bool _ret_var = default(bool);
         try {
            _ret_var = ((ModelContainer)wrapper).AddChildProperty( name,  type,  _in_values);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                          return _ret_var;
      } else {
         return efl_model_container_child_property_add(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  name,  type,  values);
      }
   }
   private efl_model_container_child_property_add_delegate efl_model_container_child_property_add_static_delegate;
}
} 
