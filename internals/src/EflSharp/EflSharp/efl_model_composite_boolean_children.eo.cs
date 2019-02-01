#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { 
/// <summary>Efl model composite boolean children class</summary>
[ModelCompositeBooleanChildrenNativeInherit]
public class ModelCompositeBooleanChildren : Efl.ModelComposite, Efl.Eo.IWrapper
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.ModelCompositeBooleanChildrenNativeInherit nativeInherit = new Efl.ModelCompositeBooleanChildrenNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (ModelCompositeBooleanChildren))
            return Efl.ModelCompositeBooleanChildrenNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   ///<summary>Delegate for function to be called from inside the native constructor.</summary>
   public new delegate void ConstructingMethod(ModelCompositeBooleanChildren obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)] internal static extern System.IntPtr
      efl_model_composite_boolean_children_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="init_cb">Delegate to call constructing methods that should be run inside the constructor.</param>
   public ModelCompositeBooleanChildren(Efl.Object parent = null, ConstructingMethod init_cb=null) : base("ModelCompositeBooleanChildren", efl_model_composite_boolean_children_class_get(), typeof(ModelCompositeBooleanChildren), parent)
   {
      if (init_cb != null) {
         init_cb(this);
      }
      FinishInstantiation();
   }
   ///<summary>Internal constructor to forward the wrapper initialization to the root class.</summary>
   protected ModelCompositeBooleanChildren(String klass_name, IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(klass_name, base_klass, managed_type, parent) {}
   ///<summary>Constructs an instance from a native pointer.</summary>
   public ModelCompositeBooleanChildren(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static ModelCompositeBooleanChildren static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new ModelCompositeBooleanChildren(obj.NativeHandle);
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
    protected static extern  uint efl_model_composite_boolean_children_index_get(System.IntPtr obj);
   /// <summary>Get the index.</summary>
   /// <returns>The index of the child in the parent model.</returns>
   virtual public  uint GetIndex() {
       var _ret_var = efl_model_composite_boolean_children_index_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]
    protected static extern  void efl_model_composite_boolean_children_index_set(System.IntPtr obj,    uint index);
   /// <summary>Set the index. It can only be set before the object is finalized.</summary>
   /// <param name="index">The index of the child in the parent model.</param>
   /// <returns></returns>
   virtual public  void SetIndex(  uint index) {
                         efl_model_composite_boolean_children_index_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  index);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Position of children in the parent model.</summary>
   public  uint Index {
      get { return GetIndex(); }
      set { SetIndex( value); }
   }
}
public class ModelCompositeBooleanChildrenNativeInherit : Efl.ModelCompositeNativeInherit{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_model_composite_boolean_children_index_get_static_delegate = new efl_model_composite_boolean_children_index_get_delegate(index_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_model_composite_boolean_children_index_get"), func = Marshal.GetFunctionPointerForDelegate(efl_model_composite_boolean_children_index_get_static_delegate)});
      efl_model_composite_boolean_children_index_set_static_delegate = new efl_model_composite_boolean_children_index_set_delegate(index_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_model_composite_boolean_children_index_set"), func = Marshal.GetFunctionPointerForDelegate(efl_model_composite_boolean_children_index_set_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.ModelCompositeBooleanChildren.efl_model_composite_boolean_children_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.ModelCompositeBooleanChildren.efl_model_composite_boolean_children_class_get();
   }


    private delegate  uint efl_model_composite_boolean_children_index_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]  private static extern  uint efl_model_composite_boolean_children_index_get(System.IntPtr obj);
    private static  uint index_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_model_composite_boolean_children_index_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   uint _ret_var = default( uint);
         try {
            _ret_var = ((ModelCompositeBooleanChildren)wrapper).GetIndex();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_model_composite_boolean_children_index_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_model_composite_boolean_children_index_get_delegate efl_model_composite_boolean_children_index_get_static_delegate;


    private delegate  void efl_model_composite_boolean_children_index_set_delegate(System.IntPtr obj, System.IntPtr pd,    uint index);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]  private static extern  void efl_model_composite_boolean_children_index_set(System.IntPtr obj,    uint index);
    private static  void index_set(System.IntPtr obj, System.IntPtr pd,   uint index)
   {
      Eina.Log.Debug("function efl_model_composite_boolean_children_index_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((ModelCompositeBooleanChildren)wrapper).SetIndex( index);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_model_composite_boolean_children_index_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  index);
      }
   }
   private efl_model_composite_boolean_children_index_set_delegate efl_model_composite_boolean_children_index_set_static_delegate;
}
} 
