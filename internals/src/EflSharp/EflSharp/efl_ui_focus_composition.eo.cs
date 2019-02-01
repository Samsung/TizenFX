#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { namespace Focus { 
/// <summary>This defines the inheriting widget as Composition widget.
/// A composition widget is a widget that&apos;s the logical parent of another set of widgets which can be used for interaction.</summary>
[CompositionConcreteNativeInherit]
public interface Composition : 
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>Set the order of elements that will be used for composition
/// Elements of the list can be either an Efl.Ui.Widget, an Efl.Ui.Focus.Object or an Efl.Gfx.
/// 
/// If the element is an Efl.Gfx.Entity, then the geometry is used as focus geometry, the focus property is redirected to the evas focus property. The mixin will take care of registration.
/// 
/// If the element is an Efl.Ui.Focus.Object, then the mixin will take care of registering the element.
/// 
/// If the element is a Efl.Ui.Widget nothing is done and the widget is simply part of the order.</summary>
/// <returns>The order to use</returns>
Eina.List<Efl.Gfx.Entity> GetCompositionElements();
   /// <summary>Set the order of elements that will be used for composition
/// Elements of the list can be either an Efl.Ui.Widget, an Efl.Ui.Focus.Object or an Efl.Gfx.
/// 
/// If the element is an Efl.Gfx.Entity, then the geometry is used as focus geometry, the focus property is redirected to the evas focus property. The mixin will take care of registration.
/// 
/// If the element is an Efl.Ui.Focus.Object, then the mixin will take care of registering the element.
/// 
/// If the element is a Efl.Ui.Widget nothing is done and the widget is simply part of the order.</summary>
/// <param name="logical_order">The order to use</param>
/// <returns></returns>
 void SetCompositionElements( Eina.List<Efl.Gfx.Entity> logical_order);
   /// <summary>Register all children in this manager
/// Set to <c>null</c> to register them in the same manager as the implementor is</summary>
/// <returns>EFL focus manager</returns>
Efl.Ui.Focus.Manager GetCustomManager();
   /// <summary>Register all children in this manager
/// Set to <c>null</c> to register them in the same manager as the implementor is</summary>
/// <param name="custom_manager">EFL focus manager</param>
/// <returns></returns>
 void SetCustomManager( Efl.Ui.Focus.Manager custom_manager);
   /// <summary>Set to true if all children should be registered as logicals</summary>
/// <returns><c>true</c> or <c>false</c></returns>
bool GetLogicalMode();
   /// <summary>Set to true if all children should be registered as logicals</summary>
/// <param name="logical_mode"><c>true</c> or <c>false</c></param>
/// <returns></returns>
 void SetLogicalMode( bool logical_mode);
   /// <summary>Mark this widget as dirty, the children can be considered to be changed after that call</summary>
/// <returns></returns>
 void Dirty();
   /// <summary>A call to prepare the children of this element, called if marked as dirty
/// You can use this function to call composition_elements.</summary>
/// <returns></returns>
 void Prepare();
                           /// <summary>Set the order of elements that will be used for composition
/// Elements of the list can be either an Efl.Ui.Widget, an Efl.Ui.Focus.Object or an Efl.Gfx.
/// 
/// If the element is an Efl.Gfx.Entity, then the geometry is used as focus geometry, the focus property is redirected to the evas focus property. The mixin will take care of registration.
/// 
/// If the element is an Efl.Ui.Focus.Object, then the mixin will take care of registering the element.
/// 
/// If the element is a Efl.Ui.Widget nothing is done and the widget is simply part of the order.</summary>
   Eina.List<Efl.Gfx.Entity> CompositionElements {
      get ;
      set ;
   }
   /// <summary>Register all children in this manager
/// Set to <c>null</c> to register them in the same manager as the implementor is</summary>
   Efl.Ui.Focus.Manager CustomManager {
      get ;
      set ;
   }
   /// <summary>Set to true if all children should be registered as logicals</summary>
   bool LogicalMode {
      get ;
      set ;
   }
}
/// <summary>This defines the inheriting widget as Composition widget.
/// A composition widget is a widget that&apos;s the logical parent of another set of widgets which can be used for interaction.</summary>
sealed public class CompositionConcrete : 

Composition
   
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (CompositionConcrete))
            return Efl.Ui.Focus.CompositionConcreteNativeInherit.GetEflClassStatic();
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
      efl_ui_focus_composition_mixin_get();
   ///<summary>Constructs an instance from a native pointer.</summary>
   public CompositionConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~CompositionConcrete()
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
   public static CompositionConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new CompositionConcrete(obj.NativeHandle);
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
    private static extern  System.IntPtr efl_ui_focus_composition_elements_get(System.IntPtr obj);
   /// <summary>Set the order of elements that will be used for composition
   /// Elements of the list can be either an Efl.Ui.Widget, an Efl.Ui.Focus.Object or an Efl.Gfx.
   /// 
   /// If the element is an Efl.Gfx.Entity, then the geometry is used as focus geometry, the focus property is redirected to the evas focus property. The mixin will take care of registration.
   /// 
   /// If the element is an Efl.Ui.Focus.Object, then the mixin will take care of registering the element.
   /// 
   /// If the element is a Efl.Ui.Widget nothing is done and the widget is simply part of the order.</summary>
   /// <returns>The order to use</returns>
   public Eina.List<Efl.Gfx.Entity> GetCompositionElements() {
       var _ret_var = efl_ui_focus_composition_elements_get(Efl.Ui.Focus.CompositionConcrete.efl_ui_focus_composition_mixin_get());
      Eina.Error.RaiseIfUnhandledException();
      return new Eina.List<Efl.Gfx.Entity>(_ret_var, true, false);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    private static extern  void efl_ui_focus_composition_elements_set(System.IntPtr obj,    System.IntPtr logical_order);
   /// <summary>Set the order of elements that will be used for composition
   /// Elements of the list can be either an Efl.Ui.Widget, an Efl.Ui.Focus.Object or an Efl.Gfx.
   /// 
   /// If the element is an Efl.Gfx.Entity, then the geometry is used as focus geometry, the focus property is redirected to the evas focus property. The mixin will take care of registration.
   /// 
   /// If the element is an Efl.Ui.Focus.Object, then the mixin will take care of registering the element.
   /// 
   /// If the element is a Efl.Ui.Widget nothing is done and the widget is simply part of the order.</summary>
   /// <param name="logical_order">The order to use</param>
   /// <returns></returns>
   public  void SetCompositionElements( Eina.List<Efl.Gfx.Entity> logical_order) {
       var _in_logical_order = logical_order.Handle;
logical_order.Own = false;
                  efl_ui_focus_composition_elements_set(Efl.Ui.Focus.CompositionConcrete.efl_ui_focus_composition_mixin_get(),  _in_logical_order);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ManagerConcrete, Efl.Eo.NonOwnTag>))] private static extern Efl.Ui.Focus.Manager efl_ui_focus_composition_custom_manager_get(System.IntPtr obj);
   /// <summary>Register all children in this manager
   /// Set to <c>null</c> to register them in the same manager as the implementor is</summary>
   /// <returns>EFL focus manager</returns>
   public Efl.Ui.Focus.Manager GetCustomManager() {
       var _ret_var = efl_ui_focus_composition_custom_manager_get(Efl.Ui.Focus.CompositionConcrete.efl_ui_focus_composition_mixin_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    private static extern  void efl_ui_focus_composition_custom_manager_set(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ManagerConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Focus.Manager custom_manager);
   /// <summary>Register all children in this manager
   /// Set to <c>null</c> to register them in the same manager as the implementor is</summary>
   /// <param name="custom_manager">EFL focus manager</param>
   /// <returns></returns>
   public  void SetCustomManager( Efl.Ui.Focus.Manager custom_manager) {
                         efl_ui_focus_composition_custom_manager_set(Efl.Ui.Focus.CompositionConcrete.efl_ui_focus_composition_mixin_get(),  custom_manager);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_focus_composition_logical_mode_get(System.IntPtr obj);
   /// <summary>Set to true if all children should be registered as logicals</summary>
   /// <returns><c>true</c> or <c>false</c></returns>
   public bool GetLogicalMode() {
       var _ret_var = efl_ui_focus_composition_logical_mode_get(Efl.Ui.Focus.CompositionConcrete.efl_ui_focus_composition_mixin_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    private static extern  void efl_ui_focus_composition_logical_mode_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool logical_mode);
   /// <summary>Set to true if all children should be registered as logicals</summary>
   /// <param name="logical_mode"><c>true</c> or <c>false</c></param>
   /// <returns></returns>
   public  void SetLogicalMode( bool logical_mode) {
                         efl_ui_focus_composition_logical_mode_set(Efl.Ui.Focus.CompositionConcrete.efl_ui_focus_composition_mixin_get(),  logical_mode);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    private static extern  void efl_ui_focus_composition_dirty(System.IntPtr obj);
   /// <summary>Mark this widget as dirty, the children can be considered to be changed after that call</summary>
   /// <returns></returns>
   public  void Dirty() {
       efl_ui_focus_composition_dirty(Efl.Ui.Focus.CompositionConcrete.efl_ui_focus_composition_mixin_get());
      Eina.Error.RaiseIfUnhandledException();
       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    private static extern  void efl_ui_focus_composition_prepare(System.IntPtr obj);
   /// <summary>A call to prepare the children of this element, called if marked as dirty
   /// You can use this function to call composition_elements.</summary>
   /// <returns></returns>
   public  void Prepare() {
       efl_ui_focus_composition_prepare(Efl.Ui.Focus.CompositionConcrete.efl_ui_focus_composition_mixin_get());
      Eina.Error.RaiseIfUnhandledException();
       }
   /// <summary>Set the order of elements that will be used for composition
/// Elements of the list can be either an Efl.Ui.Widget, an Efl.Ui.Focus.Object or an Efl.Gfx.
/// 
/// If the element is an Efl.Gfx.Entity, then the geometry is used as focus geometry, the focus property is redirected to the evas focus property. The mixin will take care of registration.
/// 
/// If the element is an Efl.Ui.Focus.Object, then the mixin will take care of registering the element.
/// 
/// If the element is a Efl.Ui.Widget nothing is done and the widget is simply part of the order.</summary>
   public Eina.List<Efl.Gfx.Entity> CompositionElements {
      get { return GetCompositionElements(); }
      set { SetCompositionElements( value); }
   }
   /// <summary>Register all children in this manager
/// Set to <c>null</c> to register them in the same manager as the implementor is</summary>
   public Efl.Ui.Focus.Manager CustomManager {
      get { return GetCustomManager(); }
      set { SetCustomManager( value); }
   }
   /// <summary>Set to true if all children should be registered as logicals</summary>
   public bool LogicalMode {
      get { return GetLogicalMode(); }
      set { SetLogicalMode( value); }
   }
}
public class CompositionConcreteNativeInherit : Efl.Eo.NativeClass{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_ui_focus_composition_elements_get_static_delegate = new efl_ui_focus_composition_elements_get_delegate(composition_elements_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_focus_composition_elements_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_composition_elements_get_static_delegate)});
      efl_ui_focus_composition_elements_set_static_delegate = new efl_ui_focus_composition_elements_set_delegate(composition_elements_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_focus_composition_elements_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_composition_elements_set_static_delegate)});
      efl_ui_focus_composition_custom_manager_get_static_delegate = new efl_ui_focus_composition_custom_manager_get_delegate(custom_manager_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_focus_composition_custom_manager_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_composition_custom_manager_get_static_delegate)});
      efl_ui_focus_composition_custom_manager_set_static_delegate = new efl_ui_focus_composition_custom_manager_set_delegate(custom_manager_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_focus_composition_custom_manager_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_composition_custom_manager_set_static_delegate)});
      efl_ui_focus_composition_logical_mode_get_static_delegate = new efl_ui_focus_composition_logical_mode_get_delegate(logical_mode_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_focus_composition_logical_mode_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_composition_logical_mode_get_static_delegate)});
      efl_ui_focus_composition_logical_mode_set_static_delegate = new efl_ui_focus_composition_logical_mode_set_delegate(logical_mode_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_focus_composition_logical_mode_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_composition_logical_mode_set_static_delegate)});
      efl_ui_focus_composition_dirty_static_delegate = new efl_ui_focus_composition_dirty_delegate(dirty);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_focus_composition_dirty"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_composition_dirty_static_delegate)});
      efl_ui_focus_composition_prepare_static_delegate = new efl_ui_focus_composition_prepare_delegate(prepare);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_focus_composition_prepare"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_composition_prepare_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Ui.Focus.CompositionConcrete.efl_ui_focus_composition_mixin_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.Focus.CompositionConcrete.efl_ui_focus_composition_mixin_get();
   }


    private delegate  System.IntPtr efl_ui_focus_composition_elements_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  System.IntPtr efl_ui_focus_composition_elements_get(System.IntPtr obj);
    private static  System.IntPtr composition_elements_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_focus_composition_elements_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.List<Efl.Gfx.Entity> _ret_var = default(Eina.List<Efl.Gfx.Entity>);
         try {
            _ret_var = ((CompositionConcrete)wrapper).GetCompositionElements();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      _ret_var.Own = false; return _ret_var.Handle;
      } else {
         return efl_ui_focus_composition_elements_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_focus_composition_elements_get_delegate efl_ui_focus_composition_elements_get_static_delegate;


    private delegate  void efl_ui_focus_composition_elements_set_delegate(System.IntPtr obj, System.IntPtr pd,    System.IntPtr logical_order);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_focus_composition_elements_set(System.IntPtr obj,    System.IntPtr logical_order);
    private static  void composition_elements_set(System.IntPtr obj, System.IntPtr pd,   System.IntPtr logical_order)
   {
      Eina.Log.Debug("function efl_ui_focus_composition_elements_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_logical_order = new Eina.List<Efl.Gfx.Entity>(logical_order, true, false);
                     
         try {
            ((CompositionConcrete)wrapper).SetCompositionElements( _in_logical_order);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_focus_composition_elements_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  logical_order);
      }
   }
   private efl_ui_focus_composition_elements_set_delegate efl_ui_focus_composition_elements_set_static_delegate;


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ManagerConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.Ui.Focus.Manager efl_ui_focus_composition_custom_manager_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ManagerConcrete, Efl.Eo.NonOwnTag>))] private static extern Efl.Ui.Focus.Manager efl_ui_focus_composition_custom_manager_get(System.IntPtr obj);
    private static Efl.Ui.Focus.Manager custom_manager_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_focus_composition_custom_manager_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Ui.Focus.Manager _ret_var = default(Efl.Ui.Focus.Manager);
         try {
            _ret_var = ((CompositionConcrete)wrapper).GetCustomManager();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_focus_composition_custom_manager_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_focus_composition_custom_manager_get_delegate efl_ui_focus_composition_custom_manager_get_static_delegate;


    private delegate  void efl_ui_focus_composition_custom_manager_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ManagerConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Focus.Manager custom_manager);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_focus_composition_custom_manager_set(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ManagerConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Focus.Manager custom_manager);
    private static  void custom_manager_set(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.Focus.Manager custom_manager)
   {
      Eina.Log.Debug("function efl_ui_focus_composition_custom_manager_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((CompositionConcrete)wrapper).SetCustomManager( custom_manager);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_focus_composition_custom_manager_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  custom_manager);
      }
   }
   private efl_ui_focus_composition_custom_manager_set_delegate efl_ui_focus_composition_custom_manager_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_focus_composition_logical_mode_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_focus_composition_logical_mode_get(System.IntPtr obj);
    private static bool logical_mode_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_focus_composition_logical_mode_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((CompositionConcrete)wrapper).GetLogicalMode();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_focus_composition_logical_mode_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_focus_composition_logical_mode_get_delegate efl_ui_focus_composition_logical_mode_get_static_delegate;


    private delegate  void efl_ui_focus_composition_logical_mode_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool logical_mode);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_focus_composition_logical_mode_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool logical_mode);
    private static  void logical_mode_set(System.IntPtr obj, System.IntPtr pd,  bool logical_mode)
   {
      Eina.Log.Debug("function efl_ui_focus_composition_logical_mode_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((CompositionConcrete)wrapper).SetLogicalMode( logical_mode);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_focus_composition_logical_mode_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  logical_mode);
      }
   }
   private efl_ui_focus_composition_logical_mode_set_delegate efl_ui_focus_composition_logical_mode_set_static_delegate;


    private delegate  void efl_ui_focus_composition_dirty_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_focus_composition_dirty(System.IntPtr obj);
    private static  void dirty(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_focus_composition_dirty was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((CompositionConcrete)wrapper).Dirty();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_ui_focus_composition_dirty(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_focus_composition_dirty_delegate efl_ui_focus_composition_dirty_static_delegate;


    private delegate  void efl_ui_focus_composition_prepare_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_focus_composition_prepare(System.IntPtr obj);
    private static  void prepare(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_focus_composition_prepare was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((CompositionConcrete)wrapper).Prepare();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_ui_focus_composition_prepare(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_focus_composition_prepare_delegate efl_ui_focus_composition_prepare_static_delegate;
}
} } } 
