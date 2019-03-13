#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { 
/// <summary>Efl model for all composite class which provide a unified API to set source of data.
/// This class also provide an <see cref="Efl.Model.GetProperty"/> &quot;<c>child</c>.index&quot; that match the value of <see cref="Efl.CompositeModel.Index"/>.</summary>
[CompositeModelNativeInherit]
public class CompositeModel : Efl.LoopModel, Efl.Eo.IWrapper,Efl.Ui.View
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.CompositeModelNativeInherit nativeInherit = new Efl.CompositeModelNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (CompositeModel))
            return Efl.CompositeModelNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
      }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)] internal static extern System.IntPtr
      efl_composite_model_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="model">Model that is/will be See <see cref="Efl.Ui.View.SetModel"/></param>
   ///<param name="index">Position of this object in the parent model. See <see cref="Efl.CompositeModel.SetIndex"/></param>
   public CompositeModel(Efl.Object parent
         , Efl.Model model,  uint? index = null) :
      base(efl_composite_model_class_get(), typeof(CompositeModel), parent)
   {
      if (Efl.Eo.Globals.ParamHelperCheck(model))
         SetModel(Efl.Eo.Globals.GetParamHelper(model));
      if (Efl.Eo.Globals.ParamHelperCheck(index))
         SetIndex(Efl.Eo.Globals.GetParamHelper(index));
      FinishInstantiation();
   }
   ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
   public CompositeModel(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
   protected CompositeModel(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static CompositeModel static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new CompositeModel(obj.NativeHandle);
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
   /// <summary>Get the index. It will only work after the object has been finalized.</summary>
   /// <returns>Index of the object in the parent model. The index is uniq and start from zero.</returns>
   virtual public  uint GetIndex() {
       var _ret_var = Efl.CompositeModelNativeInherit.efl_composite_model_index_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Set the index. It can only be set before the object is finalized, but after the Model it compose is set and only if that Model does not provide an index already.</summary>
   /// <param name="index">Index of the object in the parent model. The index is uniq and start from zero.</param>
   /// <returns></returns>
   virtual public  void SetIndex(  uint index) {
                         Efl.CompositeModelNativeInherit.efl_composite_model_index_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), index);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Model that is/will be</summary>
   /// <returns>Efl model</returns>
   virtual public Efl.Model GetModel() {
       var _ret_var = Efl.Ui.ViewNativeInherit.efl_ui_view_model_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Model that is/will be</summary>
   /// <param name="model">Efl model</param>
   /// <returns></returns>
   virtual public  void SetModel( Efl.Model model) {
                         Efl.Ui.ViewNativeInherit.efl_ui_view_model_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), model);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Position of this object in the parent model.</summary>
/// <value>Index of the object in the parent model. The index is uniq and start from zero.</value>
   public  uint Index {
      get { return GetIndex(); }
      set { SetIndex( value); }
   }
   /// <summary>Model that is/will be</summary>
/// <value>Efl model</value>
   public Efl.Model Model {
      get { return GetModel(); }
      set { SetModel( value); }
   }
   private static new  IntPtr GetEflClassStatic()
   {
      return Efl.CompositeModel.efl_composite_model_class_get();
   }
}
public class CompositeModelNativeInherit : Efl.LoopModelNativeInherit{
   public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Ecore);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      if (efl_composite_model_index_get_static_delegate == null)
      efl_composite_model_index_get_static_delegate = new efl_composite_model_index_get_delegate(index_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_composite_model_index_get"), func = Marshal.GetFunctionPointerForDelegate(efl_composite_model_index_get_static_delegate)});
      if (efl_composite_model_index_set_static_delegate == null)
      efl_composite_model_index_set_static_delegate = new efl_composite_model_index_set_delegate(index_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_composite_model_index_set"), func = Marshal.GetFunctionPointerForDelegate(efl_composite_model_index_set_static_delegate)});
      if (efl_ui_view_model_get_static_delegate == null)
      efl_ui_view_model_get_static_delegate = new efl_ui_view_model_get_delegate(model_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_view_model_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_view_model_get_static_delegate)});
      if (efl_ui_view_model_set_static_delegate == null)
      efl_ui_view_model_set_static_delegate = new efl_ui_view_model_set_delegate(model_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_view_model_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_view_model_set_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.CompositeModel.efl_composite_model_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.CompositeModel.efl_composite_model_class_get();
   }


    private delegate  uint efl_composite_model_index_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  uint efl_composite_model_index_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_composite_model_index_get_api_delegate> efl_composite_model_index_get_ptr = new Efl.Eo.FunctionWrapper<efl_composite_model_index_get_api_delegate>(_Module, "efl_composite_model_index_get");
    private static  uint index_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_composite_model_index_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   uint _ret_var = default( uint);
         try {
            _ret_var = ((CompositeModel)wrapper).GetIndex();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_composite_model_index_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_composite_model_index_get_delegate efl_composite_model_index_get_static_delegate;


    private delegate  void efl_composite_model_index_set_delegate(System.IntPtr obj, System.IntPtr pd,    uint index);


    public delegate  void efl_composite_model_index_set_api_delegate(System.IntPtr obj,    uint index);
    public static Efl.Eo.FunctionWrapper<efl_composite_model_index_set_api_delegate> efl_composite_model_index_set_ptr = new Efl.Eo.FunctionWrapper<efl_composite_model_index_set_api_delegate>(_Module, "efl_composite_model_index_set");
    private static  void index_set(System.IntPtr obj, System.IntPtr pd,   uint index)
   {
      Eina.Log.Debug("function efl_composite_model_index_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((CompositeModel)wrapper).SetIndex( index);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_composite_model_index_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  index);
      }
   }
   private static efl_composite_model_index_set_delegate efl_composite_model_index_set_static_delegate;


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.ModelConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.Model efl_ui_view_model_get_delegate(System.IntPtr obj, System.IntPtr pd);


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.ModelConcrete, Efl.Eo.NonOwnTag>))] public delegate Efl.Model efl_ui_view_model_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_view_model_get_api_delegate> efl_ui_view_model_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_view_model_get_api_delegate>(_Module, "efl_ui_view_model_get");
    private static Efl.Model model_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_view_model_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Model _ret_var = default(Efl.Model);
         try {
            _ret_var = ((CompositeModel)wrapper).GetModel();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_view_model_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_view_model_get_delegate efl_ui_view_model_get_static_delegate;


    private delegate  void efl_ui_view_model_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.ModelConcrete, Efl.Eo.NonOwnTag>))]  Efl.Model model);


    public delegate  void efl_ui_view_model_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.ModelConcrete, Efl.Eo.NonOwnTag>))]  Efl.Model model);
    public static Efl.Eo.FunctionWrapper<efl_ui_view_model_set_api_delegate> efl_ui_view_model_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_view_model_set_api_delegate>(_Module, "efl_ui_view_model_set");
    private static  void model_set(System.IntPtr obj, System.IntPtr pd,  Efl.Model model)
   {
      Eina.Log.Debug("function efl_ui_view_model_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((CompositeModel)wrapper).SetModel( model);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_view_model_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  model);
      }
   }
   private static efl_ui_view_model_set_delegate efl_ui_view_model_set_static_delegate;
}
} 
