#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary></summary>
[ListViewSegArrayNativeInherit]
public class ListViewSegArray : Efl.Object, Efl.Eo.IWrapper
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Ui.ListViewSegArrayNativeInherit nativeInherit = new Efl.Ui.ListViewSegArrayNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (ListViewSegArray))
            return Efl.Ui.ListViewSegArrayNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   ///<summary>Delegate for function to be called from inside the native constructor.</summary>
   public new delegate void ConstructingMethod(ListViewSegArray obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
      efl_ui_list_view_seg_array_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="init_cb">Delegate to call constructing methods that should be run inside the constructor.</param>
   public ListViewSegArray(Efl.Object parent = null, ConstructingMethod init_cb=null) : base("ListViewSegArray", efl_ui_list_view_seg_array_class_get(), typeof(ListViewSegArray), parent)
   {
      if (init_cb != null) {
         init_cb(this);
      }
      FinishInstantiation();
   }
   ///<summary>Internal constructor to forward the wrapper initialization to the root class.</summary>
   protected ListViewSegArray(String klass_name, IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(klass_name, base_klass, managed_type, parent) {}
   ///<summary>Constructs an instance from a native pointer.</summary>
   public ListViewSegArray(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static ListViewSegArray static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new ListViewSegArray(obj.NativeHandle);
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


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  System.IntPtr efl_ui_list_view_seg_array_accessor_get(System.IntPtr obj);
   /// <summary>Get a Seg_Array List items accessor</summary>
   /// <returns></returns>
   virtual public Eina.Accessor<Efl.Ui.ListViewLayoutItem> GetAccessor() {
       var _ret_var = efl_ui_list_view_seg_array_accessor_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return new Eina.Accessor<Efl.Ui.ListViewLayoutItem>(_ret_var, false, false);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  System.IntPtr efl_ui_list_view_seg_array_node_accessor_get(System.IntPtr obj);
   /// <summary>Get a Seg_Array node accessor</summary>
   /// <returns></returns>
   virtual public Eina.Accessor<Efl.Ui.ListViewSegArrayNode> GetNodeAccessor() {
       var _ret_var = efl_ui_list_view_seg_array_node_accessor_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return new Eina.Accessor<Efl.Ui.ListViewSegArrayNode>(_ret_var, false, false);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_list_view_seg_array_insert_value(System.IntPtr obj,    int first,    Eina.ValueNative v);
   /// <summary>Insert a accessor in segarray tree</summary>
   /// <param name="first"></param>
   /// <param name="v"></param>
   /// <returns></returns>
   virtual public  void InsertValue(  int first,   Eina.Value v) {
             var _in_v = v.GetNative();
                              efl_ui_list_view_seg_array_insert_value((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  first,  _in_v);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  int efl_ui_list_view_seg_array_count(System.IntPtr obj);
   /// <summary>Get the number of items in Seg_Array tree</summary>
   /// <returns></returns>
   virtual public  int Count() {
       var _ret_var = efl_ui_list_view_seg_array_count((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_list_view_seg_array_setup(System.IntPtr obj,    int initial_step_size);
   /// <summary>Configure a step of Seg_Array tree, this is the max node size</summary>
   /// <param name="initial_step_size"></param>
   /// <returns></returns>
   virtual public  void Setup(  int initial_step_size) {
                         efl_ui_list_view_seg_array_setup((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  initial_step_size);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_list_view_seg_array_flush(System.IntPtr obj);
   /// <summary>flush the Seg_Array tree</summary>
   /// <returns></returns>
   virtual public  void Flush() {
       efl_ui_list_view_seg_array_flush((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_list_view_seg_array_insert(System.IntPtr obj,    int index, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.ModelConcrete, Efl.Eo.NonOwnTag>))]  Efl.Model model);
   /// <summary>Insert a new model in Seg_Array tree at index position</summary>
   /// <param name="index"></param>
   /// <param name="model"></param>
   /// <returns></returns>
   virtual public  void Insert(  int index,  Efl.Model model) {
                                           efl_ui_list_view_seg_array_insert((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  index,  model);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  System.IntPtr efl_ui_list_view_seg_array_remove(System.IntPtr obj,    int index);
   /// <summary>Remove the item at index position in Seg_Array tree</summary>
   /// <param name="index"></param>
   /// <returns></returns>
   virtual public Efl.Ui.ListViewLayoutItem Remove(  int index) {
                         var _ret_var = efl_ui_list_view_seg_array_remove((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  index);
      Eina.Error.RaiseIfUnhandledException();
                  var __ret_tmp = Eina.PrimitiveConversion.PointerToManaged<Efl.Ui.ListViewLayoutItem>(_ret_var);
      Marshal.FreeHGlobal(_ret_var);
      return __ret_tmp;
 }
   /// <summary>Get a Seg_Array List items accessor</summary>
   public Eina.Accessor<Efl.Ui.ListViewLayoutItem> Accessor {
      get { return GetAccessor(); }
   }
   /// <summary>Get a Seg_Array node accessor</summary>
   public Eina.Accessor<Efl.Ui.ListViewSegArrayNode> NodeAccessor {
      get { return GetNodeAccessor(); }
   }
}
public class ListViewSegArrayNativeInherit : Efl.ObjectNativeInherit{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_ui_list_view_seg_array_accessor_get_static_delegate = new efl_ui_list_view_seg_array_accessor_get_delegate(accessor_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_list_view_seg_array_accessor_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_list_view_seg_array_accessor_get_static_delegate)});
      efl_ui_list_view_seg_array_node_accessor_get_static_delegate = new efl_ui_list_view_seg_array_node_accessor_get_delegate(node_accessor_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_list_view_seg_array_node_accessor_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_list_view_seg_array_node_accessor_get_static_delegate)});
      efl_ui_list_view_seg_array_insert_value_static_delegate = new efl_ui_list_view_seg_array_insert_value_delegate(insert_value);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_list_view_seg_array_insert_value"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_list_view_seg_array_insert_value_static_delegate)});
      efl_ui_list_view_seg_array_count_static_delegate = new efl_ui_list_view_seg_array_count_delegate(count);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_list_view_seg_array_count"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_list_view_seg_array_count_static_delegate)});
      efl_ui_list_view_seg_array_setup_static_delegate = new efl_ui_list_view_seg_array_setup_delegate(setup);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_list_view_seg_array_setup"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_list_view_seg_array_setup_static_delegate)});
      efl_ui_list_view_seg_array_flush_static_delegate = new efl_ui_list_view_seg_array_flush_delegate(flush);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_list_view_seg_array_flush"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_list_view_seg_array_flush_static_delegate)});
      efl_ui_list_view_seg_array_insert_static_delegate = new efl_ui_list_view_seg_array_insert_delegate(insert);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_list_view_seg_array_insert"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_list_view_seg_array_insert_static_delegate)});
      efl_ui_list_view_seg_array_remove_static_delegate = new efl_ui_list_view_seg_array_remove_delegate(remove);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_list_view_seg_array_remove"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_list_view_seg_array_remove_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Ui.ListViewSegArray.efl_ui_list_view_seg_array_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.ListViewSegArray.efl_ui_list_view_seg_array_class_get();
   }


    private delegate  System.IntPtr efl_ui_list_view_seg_array_accessor_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  System.IntPtr efl_ui_list_view_seg_array_accessor_get(System.IntPtr obj);
    private static  System.IntPtr accessor_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_list_view_seg_array_accessor_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Accessor<Efl.Ui.ListViewLayoutItem> _ret_var = default(Eina.Accessor<Efl.Ui.ListViewLayoutItem>);
         try {
            _ret_var = ((ListViewSegArray)wrapper).GetAccessor();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var.Handle;
      } else {
         return efl_ui_list_view_seg_array_accessor_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_list_view_seg_array_accessor_get_delegate efl_ui_list_view_seg_array_accessor_get_static_delegate;


    private delegate  System.IntPtr efl_ui_list_view_seg_array_node_accessor_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  System.IntPtr efl_ui_list_view_seg_array_node_accessor_get(System.IntPtr obj);
    private static  System.IntPtr node_accessor_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_list_view_seg_array_node_accessor_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Accessor<Efl.Ui.ListViewSegArrayNode> _ret_var = default(Eina.Accessor<Efl.Ui.ListViewSegArrayNode>);
         try {
            _ret_var = ((ListViewSegArray)wrapper).GetNodeAccessor();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var.Handle;
      } else {
         return efl_ui_list_view_seg_array_node_accessor_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_list_view_seg_array_node_accessor_get_delegate efl_ui_list_view_seg_array_node_accessor_get_static_delegate;


    private delegate  void efl_ui_list_view_seg_array_insert_value_delegate(System.IntPtr obj, System.IntPtr pd,    int first,    Eina.ValueNative v);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_list_view_seg_array_insert_value(System.IntPtr obj,    int first,    Eina.ValueNative v);
    private static  void insert_value(System.IntPtr obj, System.IntPtr pd,   int first,   Eina.ValueNative v)
   {
      Eina.Log.Debug("function efl_ui_list_view_seg_array_insert_value was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                     var _in_v = new  Eina.Value(v);
                                 
         try {
            ((ListViewSegArray)wrapper).InsertValue( first,  _in_v);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_ui_list_view_seg_array_insert_value(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  first,  v);
      }
   }
   private efl_ui_list_view_seg_array_insert_value_delegate efl_ui_list_view_seg_array_insert_value_static_delegate;


    private delegate  int efl_ui_list_view_seg_array_count_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  int efl_ui_list_view_seg_array_count(System.IntPtr obj);
    private static  int count(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_list_view_seg_array_count was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   int _ret_var = default( int);
         try {
            _ret_var = ((ListViewSegArray)wrapper).Count();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_list_view_seg_array_count(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_list_view_seg_array_count_delegate efl_ui_list_view_seg_array_count_static_delegate;


    private delegate  void efl_ui_list_view_seg_array_setup_delegate(System.IntPtr obj, System.IntPtr pd,    int initial_step_size);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_list_view_seg_array_setup(System.IntPtr obj,    int initial_step_size);
    private static  void setup(System.IntPtr obj, System.IntPtr pd,   int initial_step_size)
   {
      Eina.Log.Debug("function efl_ui_list_view_seg_array_setup was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((ListViewSegArray)wrapper).Setup( initial_step_size);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_list_view_seg_array_setup(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  initial_step_size);
      }
   }
   private efl_ui_list_view_seg_array_setup_delegate efl_ui_list_view_seg_array_setup_static_delegate;


    private delegate  void efl_ui_list_view_seg_array_flush_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_list_view_seg_array_flush(System.IntPtr obj);
    private static  void flush(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_list_view_seg_array_flush was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((ListViewSegArray)wrapper).Flush();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_ui_list_view_seg_array_flush(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_list_view_seg_array_flush_delegate efl_ui_list_view_seg_array_flush_static_delegate;


    private delegate  void efl_ui_list_view_seg_array_insert_delegate(System.IntPtr obj, System.IntPtr pd,    int index, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.ModelConcrete, Efl.Eo.NonOwnTag>))]  Efl.Model model);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_list_view_seg_array_insert(System.IntPtr obj,    int index, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.ModelConcrete, Efl.Eo.NonOwnTag>))]  Efl.Model model);
    private static  void insert(System.IntPtr obj, System.IntPtr pd,   int index,  Efl.Model model)
   {
      Eina.Log.Debug("function efl_ui_list_view_seg_array_insert was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((ListViewSegArray)wrapper).Insert( index,  model);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_ui_list_view_seg_array_insert(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  index,  model);
      }
   }
   private efl_ui_list_view_seg_array_insert_delegate efl_ui_list_view_seg_array_insert_static_delegate;


    private delegate  System.IntPtr efl_ui_list_view_seg_array_remove_delegate(System.IntPtr obj, System.IntPtr pd,    int index);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  System.IntPtr efl_ui_list_view_seg_array_remove(System.IntPtr obj,    int index);
    private static  System.IntPtr remove(System.IntPtr obj, System.IntPtr pd,   int index)
   {
      Eina.Log.Debug("function efl_ui_list_view_seg_array_remove was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    Efl.Ui.ListViewLayoutItem _ret_var = default(Efl.Ui.ListViewLayoutItem);
         try {
            _ret_var = ((ListViewSegArray)wrapper).Remove( index);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return Eina.PrimitiveConversion.ManagedToPointerAlloc(_ret_var);
      } else {
         return efl_ui_list_view_seg_array_remove(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  index);
      }
   }
   private efl_ui_list_view_seg_array_remove_delegate efl_ui_list_view_seg_array_remove_static_delegate;
}
} } 
