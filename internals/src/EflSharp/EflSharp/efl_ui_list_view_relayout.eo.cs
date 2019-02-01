#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary></summary>
[ListViewRelayoutConcreteNativeInherit]
public interface ListViewRelayout : 
   Efl.Interface ,
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>Model that is/will be</summary>
/// <param name="model">Efl model</param>
/// <returns></returns>
 void SetModel( Efl.Model model);
   /// <summary></summary>
/// <returns>The order to use</returns>
Eina.List<Efl.Gfx.Entity> GetElements();
   /// <summary></summary>
/// <param name="modeler"></param>
/// <param name="first"></param>
/// <param name="children"></param>
/// <returns></returns>
 void LayoutDo( Efl.Ui.ListViewModel modeler,   int first,  Efl.Ui.ListViewSegArray children);
   /// <summary></summary>
/// <param name="item"></param>
/// <returns></returns>
 void ContentCreated( ref Efl.Ui.ListViewLayoutItem item);
               /// <summary>Model that is/will be</summary>
   Efl.Model Model {
      set ;
   }
   /// <summary></summary>
   Eina.List<Efl.Gfx.Entity> Elements {
      get ;
   }
}
/// <summary></summary>
sealed public class ListViewRelayoutConcrete : 

ListViewRelayout
   , Efl.Interface
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (ListViewRelayoutConcrete))
            return Efl.Ui.ListViewRelayoutConcreteNativeInherit.GetEflClassStatic();
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
      efl_ui_list_view_relayout_interface_get();
   ///<summary>Constructs an instance from a native pointer.</summary>
   public ListViewRelayoutConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~ListViewRelayoutConcrete()
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
   public static ListViewRelayoutConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new ListViewRelayoutConcrete(obj.NativeHandle);
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
    private static extern  void efl_ui_list_view_relayout_model_set(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.ModelConcrete, Efl.Eo.NonOwnTag>))]  Efl.Model model);
   /// <summary>Model that is/will be</summary>
   /// <param name="model">Efl model</param>
   /// <returns></returns>
   public  void SetModel( Efl.Model model) {
                         efl_ui_list_view_relayout_model_set(Efl.Ui.ListViewRelayoutConcrete.efl_ui_list_view_relayout_interface_get(),  model);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    private static extern  System.IntPtr efl_ui_list_view_relayout_elements_get(System.IntPtr obj);
   /// <summary></summary>
   /// <returns>The order to use</returns>
   public Eina.List<Efl.Gfx.Entity> GetElements() {
       var _ret_var = efl_ui_list_view_relayout_elements_get(Efl.Ui.ListViewRelayoutConcrete.efl_ui_list_view_relayout_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return new Eina.List<Efl.Gfx.Entity>(_ret_var, false, false);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    private static extern  void efl_ui_list_view_relayout_layout_do(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.ListViewModelConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.ListViewModel modeler,    int first, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.ListViewSegArray, Efl.Eo.NonOwnTag>))]  Efl.Ui.ListViewSegArray children);
   /// <summary></summary>
   /// <param name="modeler"></param>
   /// <param name="first"></param>
   /// <param name="children"></param>
   /// <returns></returns>
   public  void LayoutDo( Efl.Ui.ListViewModel modeler,   int first,  Efl.Ui.ListViewSegArray children) {
                                                             efl_ui_list_view_relayout_layout_do(Efl.Ui.ListViewRelayoutConcrete.efl_ui_list_view_relayout_interface_get(),  modeler,  first,  children);
      Eina.Error.RaiseIfUnhandledException();
                                           }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    private static extern  void efl_ui_list_view_relayout_content_created(System.IntPtr obj,   ref Efl.Ui.ListViewLayoutItem_StructInternal item);
   /// <summary></summary>
   /// <param name="item"></param>
   /// <returns></returns>
   public  void ContentCreated( ref Efl.Ui.ListViewLayoutItem item) {
       var _in_item = Efl.Ui.ListViewLayoutItem_StructConversion.ToInternal(item);
                  efl_ui_list_view_relayout_content_created(Efl.Ui.ListViewRelayoutConcrete.efl_ui_list_view_relayout_interface_get(),  ref _in_item);
      Eina.Error.RaiseIfUnhandledException();
            item = Efl.Ui.ListViewLayoutItem_StructConversion.ToManaged(_in_item);
       }
   /// <summary>Model that is/will be</summary>
   public Efl.Model Model {
      set { SetModel( value); }
   }
   /// <summary></summary>
   public Eina.List<Efl.Gfx.Entity> Elements {
      get { return GetElements(); }
   }
}
public class ListViewRelayoutConcreteNativeInherit : Efl.Eo.NativeClass{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_ui_list_view_relayout_model_set_static_delegate = new efl_ui_list_view_relayout_model_set_delegate(model_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_list_view_relayout_model_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_list_view_relayout_model_set_static_delegate)});
      efl_ui_list_view_relayout_elements_get_static_delegate = new efl_ui_list_view_relayout_elements_get_delegate(elements_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_list_view_relayout_elements_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_list_view_relayout_elements_get_static_delegate)});
      efl_ui_list_view_relayout_layout_do_static_delegate = new efl_ui_list_view_relayout_layout_do_delegate(layout_do);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_list_view_relayout_layout_do"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_list_view_relayout_layout_do_static_delegate)});
      efl_ui_list_view_relayout_content_created_static_delegate = new efl_ui_list_view_relayout_content_created_delegate(content_created);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_list_view_relayout_content_created"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_list_view_relayout_content_created_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Ui.ListViewRelayoutConcrete.efl_ui_list_view_relayout_interface_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.ListViewRelayoutConcrete.efl_ui_list_view_relayout_interface_get();
   }


    private delegate  void efl_ui_list_view_relayout_model_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.ModelConcrete, Efl.Eo.NonOwnTag>))]  Efl.Model model);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_list_view_relayout_model_set(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.ModelConcrete, Efl.Eo.NonOwnTag>))]  Efl.Model model);
    private static  void model_set(System.IntPtr obj, System.IntPtr pd,  Efl.Model model)
   {
      Eina.Log.Debug("function efl_ui_list_view_relayout_model_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((ListViewRelayout)wrapper).SetModel( model);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_list_view_relayout_model_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  model);
      }
   }
   private efl_ui_list_view_relayout_model_set_delegate efl_ui_list_view_relayout_model_set_static_delegate;


    private delegate  System.IntPtr efl_ui_list_view_relayout_elements_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  System.IntPtr efl_ui_list_view_relayout_elements_get(System.IntPtr obj);
    private static  System.IntPtr elements_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_list_view_relayout_elements_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.List<Efl.Gfx.Entity> _ret_var = default(Eina.List<Efl.Gfx.Entity>);
         try {
            _ret_var = ((ListViewRelayout)wrapper).GetElements();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var.Handle;
      } else {
         return efl_ui_list_view_relayout_elements_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_list_view_relayout_elements_get_delegate efl_ui_list_view_relayout_elements_get_static_delegate;


    private delegate  void efl_ui_list_view_relayout_layout_do_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.ListViewModelConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.ListViewModel modeler,    int first, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.ListViewSegArray, Efl.Eo.NonOwnTag>))]  Efl.Ui.ListViewSegArray children);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_list_view_relayout_layout_do(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.ListViewModelConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.ListViewModel modeler,    int first, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.ListViewSegArray, Efl.Eo.NonOwnTag>))]  Efl.Ui.ListViewSegArray children);
    private static  void layout_do(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.ListViewModel modeler,   int first,  Efl.Ui.ListViewSegArray children)
   {
      Eina.Log.Debug("function efl_ui_list_view_relayout_layout_do was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                        
         try {
            ((ListViewRelayout)wrapper).LayoutDo( modeler,  first,  children);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                } else {
         efl_ui_list_view_relayout_layout_do(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  modeler,  first,  children);
      }
   }
   private efl_ui_list_view_relayout_layout_do_delegate efl_ui_list_view_relayout_layout_do_static_delegate;


    private delegate  void efl_ui_list_view_relayout_content_created_delegate(System.IntPtr obj, System.IntPtr pd,   ref Efl.Ui.ListViewLayoutItem_StructInternal item);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_list_view_relayout_content_created(System.IntPtr obj,   ref Efl.Ui.ListViewLayoutItem_StructInternal item);
    private static  void content_created(System.IntPtr obj, System.IntPtr pd,  ref Efl.Ui.ListViewLayoutItem_StructInternal item)
   {
      Eina.Log.Debug("function efl_ui_list_view_relayout_content_created was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_item = Efl.Ui.ListViewLayoutItem_StructConversion.ToManaged(item);
                     
         try {
            ((ListViewRelayout)wrapper).ContentCreated( ref _in_item);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            item = Efl.Ui.ListViewLayoutItem_StructConversion.ToInternal(_in_item);
            } else {
         efl_ui_list_view_relayout_content_created(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  ref item);
      }
   }
   private efl_ui_list_view_relayout_content_created_delegate efl_ui_list_view_relayout_content_created_static_delegate;
}
} } 
