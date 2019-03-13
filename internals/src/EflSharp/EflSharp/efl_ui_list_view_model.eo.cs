#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary></summary>
[ListViewModelNativeInherit]
public interface ListViewModel : 
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary></summary>
/// <param name="first"></param>
/// <param name="count"></param>
/// <returns></returns>
 void SetLoadRange(  int first,   int count);
   /// <summary></summary>
/// <returns></returns>
 int GetModelSize();
   /// <summary>Minimal content size.</summary>
/// <returns></returns>
Eina.Size2D GetMinSize();
   /// <summary>Minimal content size.</summary>
/// <param name="min"></param>
/// <returns></returns>
 void SetMinSize( Eina.Size2D min);
   /// <summary></summary>
/// <param name="item"></param>
/// <returns></returns>
Efl.Ui.ListViewLayoutItem Realize( ref Efl.Ui.ListViewLayoutItem item);
   /// <summary></summary>
/// <param name="item"></param>
/// <returns></returns>
 void Unrealize( ref Efl.Ui.ListViewLayoutItem item);
                     /// <summary></summary>
/// <value></value>
    int ModelSize {
      get ;
   }
   /// <summary>Minimal content size.</summary>
/// <value></value>
   Eina.Size2D MinSize {
      get ;
      set ;
   }
}
/// <summary></summary>
sealed public class ListViewModelConcrete : 

ListViewModel
   
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (ListViewModelConcrete))
            return Efl.Ui.ListViewModelNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
      }
   }
   private  System.IntPtr handle;
   ///<summary>Pointer to the native instance.</summary>
   public System.IntPtr NativeHandle {
      get { return handle; }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
      efl_ui_list_view_model_interface_get();
   ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
   public ListViewModelConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~ListViewModelConcrete()
   {
      Dispose(false);
   }
   ///<summary>Releases the underlying native instance.</summary>
   void Dispose(bool disposing)
   {
      if (handle != System.IntPtr.Zero) {
         Efl.Eo.Globals.efl_unref(handle);
         handle = System.IntPtr.Zero;
      }
   }
   ///<summary>Releases the underlying native instance.</summary>
   public void Dispose()
   {
      Dispose(true);
      GC.SuppressFinalize(this);
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public static ListViewModelConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new ListViewModelConcrete(obj.NativeHandle);
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
    void register_event_proxies()
   {
   }
   /// <summary></summary>
   /// <param name="first"></param>
   /// <param name="count"></param>
   /// <returns></returns>
   public  void SetLoadRange(  int first,   int count) {
                                           Efl.Ui.ListViewModelNativeInherit.efl_ui_list_view_model_load_range_set_ptr.Value.Delegate(this.NativeHandle, first,  count);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary></summary>
   /// <returns></returns>
   public  int GetModelSize() {
       var _ret_var = Efl.Ui.ListViewModelNativeInherit.efl_ui_list_view_model_size_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Minimal content size.</summary>
   /// <returns></returns>
   public Eina.Size2D GetMinSize() {
       var _ret_var = Efl.Ui.ListViewModelNativeInherit.efl_ui_list_view_model_min_size_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return Eina.Size2D_StructConversion.ToManaged(_ret_var);
 }
   /// <summary>Minimal content size.</summary>
   /// <param name="min"></param>
   /// <returns></returns>
   public  void SetMinSize( Eina.Size2D min) {
       var _in_min = Eina.Size2D_StructConversion.ToInternal(min);
                  Efl.Ui.ListViewModelNativeInherit.efl_ui_list_view_model_min_size_set_ptr.Value.Delegate(this.NativeHandle, _in_min);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary></summary>
   /// <param name="item"></param>
   /// <returns></returns>
   public Efl.Ui.ListViewLayoutItem Realize( ref Efl.Ui.ListViewLayoutItem item) {
       var _in_item = Efl.Ui.ListViewLayoutItem_StructConversion.ToInternal(item);
                  var _ret_var = Efl.Ui.ListViewModelNativeInherit.efl_ui_list_view_model_realize_ptr.Value.Delegate(this.NativeHandle, ref _in_item);
      Eina.Error.RaiseIfUnhandledException();
            item = Efl.Ui.ListViewLayoutItem_StructConversion.ToManaged(_in_item);
      var __ret_tmp = Eina.PrimitiveConversion.PointerToManaged<Efl.Ui.ListViewLayoutItem>(_ret_var);
      
      return __ret_tmp;
 }
   /// <summary></summary>
   /// <param name="item"></param>
   /// <returns></returns>
   public  void Unrealize( ref Efl.Ui.ListViewLayoutItem item) {
       var _in_item = Efl.Ui.ListViewLayoutItem_StructConversion.ToInternal(item);
                  Efl.Ui.ListViewModelNativeInherit.efl_ui_list_view_model_unrealize_ptr.Value.Delegate(this.NativeHandle, ref _in_item);
      Eina.Error.RaiseIfUnhandledException();
            item = Efl.Ui.ListViewLayoutItem_StructConversion.ToManaged(_in_item);
       }
   /// <summary></summary>
/// <value></value>
   public  int ModelSize {
      get { return GetModelSize(); }
   }
   /// <summary>Minimal content size.</summary>
/// <value></value>
   public Eina.Size2D MinSize {
      get { return GetMinSize(); }
      set { SetMinSize( value); }
   }
}
public class ListViewModelNativeInherit  : Efl.Eo.NativeClass{
   public  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Elementary);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      if (efl_ui_list_view_model_load_range_set_static_delegate == null)
      efl_ui_list_view_model_load_range_set_static_delegate = new efl_ui_list_view_model_load_range_set_delegate(load_range_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_list_view_model_load_range_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_list_view_model_load_range_set_static_delegate)});
      if (efl_ui_list_view_model_size_get_static_delegate == null)
      efl_ui_list_view_model_size_get_static_delegate = new efl_ui_list_view_model_size_get_delegate(model_size_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_list_view_model_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_list_view_model_size_get_static_delegate)});
      if (efl_ui_list_view_model_min_size_get_static_delegate == null)
      efl_ui_list_view_model_min_size_get_static_delegate = new efl_ui_list_view_model_min_size_get_delegate(min_size_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_list_view_model_min_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_list_view_model_min_size_get_static_delegate)});
      if (efl_ui_list_view_model_min_size_set_static_delegate == null)
      efl_ui_list_view_model_min_size_set_static_delegate = new efl_ui_list_view_model_min_size_set_delegate(min_size_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_list_view_model_min_size_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_list_view_model_min_size_set_static_delegate)});
      if (efl_ui_list_view_model_realize_static_delegate == null)
      efl_ui_list_view_model_realize_static_delegate = new efl_ui_list_view_model_realize_delegate(realize);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_list_view_model_realize"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_list_view_model_realize_static_delegate)});
      if (efl_ui_list_view_model_unrealize_static_delegate == null)
      efl_ui_list_view_model_unrealize_static_delegate = new efl_ui_list_view_model_unrealize_delegate(unrealize);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_list_view_model_unrealize"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_list_view_model_unrealize_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Ui.ListViewModelConcrete.efl_ui_list_view_model_interface_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.ListViewModelConcrete.efl_ui_list_view_model_interface_get();
   }


    private delegate  void efl_ui_list_view_model_load_range_set_delegate(System.IntPtr obj, System.IntPtr pd,    int first,    int count);


    public delegate  void efl_ui_list_view_model_load_range_set_api_delegate(System.IntPtr obj,    int first,    int count);
    public static Efl.Eo.FunctionWrapper<efl_ui_list_view_model_load_range_set_api_delegate> efl_ui_list_view_model_load_range_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_list_view_model_load_range_set_api_delegate>(_Module, "efl_ui_list_view_model_load_range_set");
    private static  void load_range_set(System.IntPtr obj, System.IntPtr pd,   int first,   int count)
   {
      Eina.Log.Debug("function efl_ui_list_view_model_load_range_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((ListViewModel)wrapper).SetLoadRange( first,  count);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_ui_list_view_model_load_range_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  first,  count);
      }
   }
   private static efl_ui_list_view_model_load_range_set_delegate efl_ui_list_view_model_load_range_set_static_delegate;


    private delegate  int efl_ui_list_view_model_size_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  int efl_ui_list_view_model_size_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_list_view_model_size_get_api_delegate> efl_ui_list_view_model_size_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_list_view_model_size_get_api_delegate>(_Module, "efl_ui_list_view_model_size_get");
    private static  int model_size_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_list_view_model_size_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   int _ret_var = default( int);
         try {
            _ret_var = ((ListViewModel)wrapper).GetModelSize();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_list_view_model_size_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_list_view_model_size_get_delegate efl_ui_list_view_model_size_get_static_delegate;


    private delegate Eina.Size2D_StructInternal efl_ui_list_view_model_min_size_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Eina.Size2D_StructInternal efl_ui_list_view_model_min_size_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_list_view_model_min_size_get_api_delegate> efl_ui_list_view_model_min_size_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_list_view_model_min_size_get_api_delegate>(_Module, "efl_ui_list_view_model_min_size_get");
    private static Eina.Size2D_StructInternal min_size_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_list_view_model_min_size_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Size2D _ret_var = default(Eina.Size2D);
         try {
            _ret_var = ((ListViewModel)wrapper).GetMinSize();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Eina.Size2D_StructConversion.ToInternal(_ret_var);
      } else {
         return efl_ui_list_view_model_min_size_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_list_view_model_min_size_get_delegate efl_ui_list_view_model_min_size_get_static_delegate;


    private delegate  void efl_ui_list_view_model_min_size_set_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Size2D_StructInternal min);


    public delegate  void efl_ui_list_view_model_min_size_set_api_delegate(System.IntPtr obj,   Eina.Size2D_StructInternal min);
    public static Efl.Eo.FunctionWrapper<efl_ui_list_view_model_min_size_set_api_delegate> efl_ui_list_view_model_min_size_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_list_view_model_min_size_set_api_delegate>(_Module, "efl_ui_list_view_model_min_size_set");
    private static  void min_size_set(System.IntPtr obj, System.IntPtr pd,  Eina.Size2D_StructInternal min)
   {
      Eina.Log.Debug("function efl_ui_list_view_model_min_size_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_min = Eina.Size2D_StructConversion.ToManaged(min);
                     
         try {
            ((ListViewModel)wrapper).SetMinSize( _in_min);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_list_view_model_min_size_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  min);
      }
   }
   private static efl_ui_list_view_model_min_size_set_delegate efl_ui_list_view_model_min_size_set_static_delegate;


    private delegate  System.IntPtr efl_ui_list_view_model_realize_delegate(System.IntPtr obj, System.IntPtr pd,   ref Efl.Ui.ListViewLayoutItem_StructInternal item);


    public delegate  System.IntPtr efl_ui_list_view_model_realize_api_delegate(System.IntPtr obj,   ref Efl.Ui.ListViewLayoutItem_StructInternal item);
    public static Efl.Eo.FunctionWrapper<efl_ui_list_view_model_realize_api_delegate> efl_ui_list_view_model_realize_ptr = new Efl.Eo.FunctionWrapper<efl_ui_list_view_model_realize_api_delegate>(_Module, "efl_ui_list_view_model_realize");
    private static  System.IntPtr realize(System.IntPtr obj, System.IntPtr pd,  ref Efl.Ui.ListViewLayoutItem_StructInternal item)
   {
      Eina.Log.Debug("function efl_ui_list_view_model_realize was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_item = Efl.Ui.ListViewLayoutItem_StructConversion.ToManaged(item);
                     Efl.Ui.ListViewLayoutItem _ret_var = default(Efl.Ui.ListViewLayoutItem);
         try {
            _ret_var = ((ListViewModel)wrapper).Realize( ref _in_item);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            item = Efl.Ui.ListViewLayoutItem_StructConversion.ToInternal(_in_item);
      return Eina.PrimitiveConversion.ManagedToPointerAlloc(_ret_var);
      } else {
         return efl_ui_list_view_model_realize_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  ref item);
      }
   }
   private static efl_ui_list_view_model_realize_delegate efl_ui_list_view_model_realize_static_delegate;


    private delegate  void efl_ui_list_view_model_unrealize_delegate(System.IntPtr obj, System.IntPtr pd,   ref Efl.Ui.ListViewLayoutItem_StructInternal item);


    public delegate  void efl_ui_list_view_model_unrealize_api_delegate(System.IntPtr obj,   ref Efl.Ui.ListViewLayoutItem_StructInternal item);
    public static Efl.Eo.FunctionWrapper<efl_ui_list_view_model_unrealize_api_delegate> efl_ui_list_view_model_unrealize_ptr = new Efl.Eo.FunctionWrapper<efl_ui_list_view_model_unrealize_api_delegate>(_Module, "efl_ui_list_view_model_unrealize");
    private static  void unrealize(System.IntPtr obj, System.IntPtr pd,  ref Efl.Ui.ListViewLayoutItem_StructInternal item)
   {
      Eina.Log.Debug("function efl_ui_list_view_model_unrealize was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_item = Efl.Ui.ListViewLayoutItem_StructConversion.ToManaged(item);
                     
         try {
            ((ListViewModel)wrapper).Unrealize( ref _in_item);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            item = Efl.Ui.ListViewLayoutItem_StructConversion.ToInternal(_in_item);
            } else {
         efl_ui_list_view_model_unrealize_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  ref item);
      }
   }
   private static efl_ui_list_view_model_unrealize_delegate efl_ui_list_view_model_unrealize_static_delegate;
}
} } 
