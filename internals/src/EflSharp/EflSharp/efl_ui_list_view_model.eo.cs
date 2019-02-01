#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary></summary>
[ListViewModelConcreteNativeInherit]
public interface ListViewModel : 
   Efl.Interface ,
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
    int ModelSize {
      get ;
   }
   /// <summary>Minimal content size.</summary>
   Eina.Size2D MinSize {
      get ;
      set ;
   }
}
/// <summary></summary>
sealed public class ListViewModelConcrete : 

ListViewModel
   , Efl.Interface
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (ListViewModelConcrete))
            return Efl.Ui.ListViewModelConcreteNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   private  System.IntPtr handle;
   public Dictionary<String, IntPtr> cached_strings = new Dictionary<String, IntPtr>();
   public Dictionary<String, IntPtr> cached_stringshares = new Dictionary<String, IntPtr>();
   ///<summary>Pointer to the native instance.</summary>
   public System.IntPtr NativeHandle {
      get { return handle; }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
      efl_ui_list_view_model_interface_get();
   ///<summary>Constructs an instance from a native pointer.</summary>
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
   Efl.Eo.Globals.free_dict_values(cached_strings);
   Efl.Eo.Globals.free_stringshare_values(cached_stringshares);
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


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    private static extern  void efl_ui_list_view_model_load_range_set(System.IntPtr obj,    int first,    int count);
   /// <summary></summary>
   /// <param name="first"></param>
   /// <param name="count"></param>
   /// <returns></returns>
   public  void SetLoadRange(  int first,   int count) {
                                           efl_ui_list_view_model_load_range_set(Efl.Ui.ListViewModelConcrete.efl_ui_list_view_model_interface_get(),  first,  count);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    private static extern  int efl_ui_list_view_model_size_get(System.IntPtr obj);
   /// <summary></summary>
   /// <returns></returns>
   public  int GetModelSize() {
       var _ret_var = efl_ui_list_view_model_size_get(Efl.Ui.ListViewModelConcrete.efl_ui_list_view_model_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    private static extern Eina.Size2D_StructInternal efl_ui_list_view_model_min_size_get(System.IntPtr obj);
   /// <summary>Minimal content size.</summary>
   /// <returns></returns>
   public Eina.Size2D GetMinSize() {
       var _ret_var = efl_ui_list_view_model_min_size_get(Efl.Ui.ListViewModelConcrete.efl_ui_list_view_model_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return Eina.Size2D_StructConversion.ToManaged(_ret_var);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    private static extern  void efl_ui_list_view_model_min_size_set(System.IntPtr obj,   Eina.Size2D_StructInternal min);
   /// <summary>Minimal content size.</summary>
   /// <param name="min"></param>
   /// <returns></returns>
   public  void SetMinSize( Eina.Size2D min) {
       var _in_min = Eina.Size2D_StructConversion.ToInternal(min);
                  efl_ui_list_view_model_min_size_set(Efl.Ui.ListViewModelConcrete.efl_ui_list_view_model_interface_get(),  _in_min);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    private static extern  System.IntPtr efl_ui_list_view_model_realize(System.IntPtr obj,   ref Efl.Ui.ListViewLayoutItem_StructInternal item);
   /// <summary></summary>
   /// <param name="item"></param>
   /// <returns></returns>
   public Efl.Ui.ListViewLayoutItem Realize( ref Efl.Ui.ListViewLayoutItem item) {
       var _in_item = Efl.Ui.ListViewLayoutItem_StructConversion.ToInternal(item);
                  var _ret_var = efl_ui_list_view_model_realize(Efl.Ui.ListViewModelConcrete.efl_ui_list_view_model_interface_get(),  ref _in_item);
      Eina.Error.RaiseIfUnhandledException();
            item = Efl.Ui.ListViewLayoutItem_StructConversion.ToManaged(_in_item);
      var __ret_tmp = Eina.PrimitiveConversion.PointerToManaged<Efl.Ui.ListViewLayoutItem>(_ret_var);
      
      return __ret_tmp;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    private static extern  void efl_ui_list_view_model_unrealize(System.IntPtr obj,   ref Efl.Ui.ListViewLayoutItem_StructInternal item);
   /// <summary></summary>
   /// <param name="item"></param>
   /// <returns></returns>
   public  void Unrealize( ref Efl.Ui.ListViewLayoutItem item) {
       var _in_item = Efl.Ui.ListViewLayoutItem_StructConversion.ToInternal(item);
                  efl_ui_list_view_model_unrealize(Efl.Ui.ListViewModelConcrete.efl_ui_list_view_model_interface_get(),  ref _in_item);
      Eina.Error.RaiseIfUnhandledException();
            item = Efl.Ui.ListViewLayoutItem_StructConversion.ToManaged(_in_item);
       }
   /// <summary></summary>
   public  int ModelSize {
      get { return GetModelSize(); }
   }
   /// <summary>Minimal content size.</summary>
   public Eina.Size2D MinSize {
      get { return GetMinSize(); }
      set { SetMinSize( value); }
   }
}
public class ListViewModelConcreteNativeInherit : Efl.Eo.NativeClass{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_ui_list_view_model_load_range_set_static_delegate = new efl_ui_list_view_model_load_range_set_delegate(load_range_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_list_view_model_load_range_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_list_view_model_load_range_set_static_delegate)});
      efl_ui_list_view_model_size_get_static_delegate = new efl_ui_list_view_model_size_get_delegate(model_size_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_list_view_model_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_list_view_model_size_get_static_delegate)});
      efl_ui_list_view_model_min_size_get_static_delegate = new efl_ui_list_view_model_min_size_get_delegate(min_size_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_list_view_model_min_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_list_view_model_min_size_get_static_delegate)});
      efl_ui_list_view_model_min_size_set_static_delegate = new efl_ui_list_view_model_min_size_set_delegate(min_size_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_list_view_model_min_size_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_list_view_model_min_size_set_static_delegate)});
      efl_ui_list_view_model_realize_static_delegate = new efl_ui_list_view_model_realize_delegate(realize);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_list_view_model_realize"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_list_view_model_realize_static_delegate)});
      efl_ui_list_view_model_unrealize_static_delegate = new efl_ui_list_view_model_unrealize_delegate(unrealize);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_list_view_model_unrealize"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_list_view_model_unrealize_static_delegate)});
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
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_list_view_model_load_range_set(System.IntPtr obj,    int first,    int count);
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
         efl_ui_list_view_model_load_range_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  first,  count);
      }
   }
   private efl_ui_list_view_model_load_range_set_delegate efl_ui_list_view_model_load_range_set_static_delegate;


    private delegate  int efl_ui_list_view_model_size_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  int efl_ui_list_view_model_size_get(System.IntPtr obj);
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
         return efl_ui_list_view_model_size_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_list_view_model_size_get_delegate efl_ui_list_view_model_size_get_static_delegate;


    private delegate Eina.Size2D_StructInternal efl_ui_list_view_model_min_size_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern Eina.Size2D_StructInternal efl_ui_list_view_model_min_size_get(System.IntPtr obj);
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
         return efl_ui_list_view_model_min_size_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_list_view_model_min_size_get_delegate efl_ui_list_view_model_min_size_get_static_delegate;


    private delegate  void efl_ui_list_view_model_min_size_set_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Size2D_StructInternal min);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_list_view_model_min_size_set(System.IntPtr obj,   Eina.Size2D_StructInternal min);
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
         efl_ui_list_view_model_min_size_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  min);
      }
   }
   private efl_ui_list_view_model_min_size_set_delegate efl_ui_list_view_model_min_size_set_static_delegate;


    private delegate  System.IntPtr efl_ui_list_view_model_realize_delegate(System.IntPtr obj, System.IntPtr pd,   ref Efl.Ui.ListViewLayoutItem_StructInternal item);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  System.IntPtr efl_ui_list_view_model_realize(System.IntPtr obj,   ref Efl.Ui.ListViewLayoutItem_StructInternal item);
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
         return efl_ui_list_view_model_realize(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  ref item);
      }
   }
   private efl_ui_list_view_model_realize_delegate efl_ui_list_view_model_realize_static_delegate;


    private delegate  void efl_ui_list_view_model_unrealize_delegate(System.IntPtr obj, System.IntPtr pd,   ref Efl.Ui.ListViewLayoutItem_StructInternal item);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_list_view_model_unrealize(System.IntPtr obj,   ref Efl.Ui.ListViewLayoutItem_StructInternal item);
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
         efl_ui_list_view_model_unrealize(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  ref item);
      }
   }
   private efl_ui_list_view_model_unrealize_delegate efl_ui_list_view_model_unrealize_static_delegate;
}
} } 
