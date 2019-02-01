#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

/// <summary></summary>
/// <param name="model_view">The ModelView object the @.property.get is issued on.</param>
/// <param name="property">The property name the @.property.get is issued on.</param>
/// <returns></returns>
public delegate  Eina.Value EflModelViewPropertyGet( Efl.ModelView model_view,   System.String property);
public delegate  Eina.Value EflModelViewPropertyGetInternal(IntPtr data, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.ModelView, Efl.Eo.NonOwnTag>))]  Efl.ModelView model_view,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringshareKeepOwnershipMarshaler))]   System.String property);
internal class EflModelViewPropertyGetWrapper
{

   private EflModelViewPropertyGetInternal _cb;
   private IntPtr _cb_data;
   private EinaFreeCb _cb_free_cb;

   internal EflModelViewPropertyGetWrapper (EflModelViewPropertyGetInternal _cb, IntPtr _cb_data, EinaFreeCb _cb_free_cb)
   {
      this._cb = _cb;
      this._cb_data = _cb_data;
      this._cb_free_cb = _cb_free_cb;
   }

   ~EflModelViewPropertyGetWrapper()
   {
      if (this._cb_free_cb != null)
         this._cb_free_cb(this._cb_data);
   }

   internal  Eina.Value ManagedCb( Efl.ModelView model_view,  System.String property)
   {
                                          var _ret_var = _cb(_cb_data,  model_view,  property);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
   }

      internal static  Eina.Value Cb(IntPtr cb_data, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.ModelView, Efl.Eo.NonOwnTag>))]  Efl.ModelView model_view,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringshareKeepOwnershipMarshaler))]   System.String property)
   {
      GCHandle handle = GCHandle.FromIntPtr(cb_data);
      EflModelViewPropertyGet cb = (EflModelViewPropertyGet)handle.Target;
                                              Eina.Value _ret_var = default( Eina.Value);
      try {
         _ret_var = cb( model_view,  property);
      } catch (Exception e) {
         Eina.Log.Warning($"Callback error: {e.ToString()}");
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
                              return _ret_var;
   }
}


/// <summary></summary>
/// <param name="model_view">The ModelView object the @.property.set is issued on.</param>
/// <param name="property">The property name the @.property.set is issued on.</param>
/// <param name="value">The new value to set.</param>
/// <returns></returns>
public delegate  Eina.Future EflModelViewPropertySet( Efl.ModelView model_view,   System.String property,   Eina.Value value);
[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))]public delegate  Eina.Future EflModelViewPropertySetInternal(IntPtr data, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.ModelView, Efl.Eo.NonOwnTag>))]  Efl.ModelView model_view,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringshareKeepOwnershipMarshaler))]   System.String property,    Eina.Value value);
internal class EflModelViewPropertySetWrapper
{

   private EflModelViewPropertySetInternal _cb;
   private IntPtr _cb_data;
   private EinaFreeCb _cb_free_cb;

   internal EflModelViewPropertySetWrapper (EflModelViewPropertySetInternal _cb, IntPtr _cb_data, EinaFreeCb _cb_free_cb)
   {
      this._cb = _cb;
      this._cb_data = _cb_data;
      this._cb_free_cb = _cb_free_cb;
   }

   ~EflModelViewPropertySetWrapper()
   {
      if (this._cb_free_cb != null)
         this._cb_free_cb(this._cb_data);
   }

   internal  Eina.Future ManagedCb( Efl.ModelView model_view,  System.String property,  Eina.Value value)
   {
                                                            var _ret_var = _cb(_cb_data,  model_view,  property,  value);
      Eina.Error.RaiseIfUnhandledException();
                                          return _ret_var;
   }

   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))]   internal static  Eina.Future Cb(IntPtr cb_data, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.ModelView, Efl.Eo.NonOwnTag>))]  Efl.ModelView model_view,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringshareKeepOwnershipMarshaler))]   System.String property,    Eina.Value value)
   {
      GCHandle handle = GCHandle.FromIntPtr(cb_data);
      EflModelViewPropertySet cb = (EflModelViewPropertySet)handle.Target;
                                                                Eina.Future _ret_var = default( Eina.Future);
      try {
         _ret_var = cb( model_view,  property,  value);
      } catch (Exception e) {
         Eina.Log.Warning($"Callback error: {e.ToString()}");
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
                                          return _ret_var;
   }
}

namespace Efl { 
/// <summary>Efl model providing helpers for custom properties used when linking a model to a view and you need to generate/adapt values for display.
/// There is two ways to use this class, you can either inherit from it and have a custom constructor for example. Or you can just instantiate it and manually define your property on it via callbacks.</summary>
[ModelViewNativeInherit]
public class ModelView : Efl.ModelComposite, Efl.Eo.IWrapper
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.ModelViewNativeInherit nativeInherit = new Efl.ModelViewNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (ModelView))
            return Efl.ModelViewNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   ///<summary>Delegate for function to be called from inside the native constructor.</summary>
   public new delegate void ConstructingMethod(ModelView obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)] internal static extern System.IntPtr
      efl_model_view_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="init_cb">Delegate to call constructing methods that should be run inside the constructor.</param>
   public ModelView(Efl.Object parent = null, ConstructingMethod init_cb=null) : base("ModelView", efl_model_view_class_get(), typeof(ModelView), parent)
   {
      if (init_cb != null) {
         init_cb(this);
      }
      FinishInstantiation();
   }
   ///<summary>Internal constructor to forward the wrapper initialization to the root class.</summary>
   protected ModelView(String klass_name, IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(klass_name, base_klass, managed_type, parent) {}
   ///<summary>Constructs an instance from a native pointer.</summary>
   public ModelView(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static ModelView static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new ModelView(obj.NativeHandle);
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
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_model_view_children_bind_get(System.IntPtr obj);
   /// <summary>Get the state of the automatic binding of children object.</summary>
   /// <returns>Do you automatically bind children. Default to true.</returns>
   virtual public bool GetChildrenBind() {
       var _ret_var = efl_model_view_children_bind_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]
    protected static extern  void efl_model_view_children_bind_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool enable);
   /// <summary>Set the state of the automatic binding of children object.</summary>
   /// <param name="enable">Do you automatically bind children. Default to true.</param>
   /// <returns></returns>
   virtual public  void SetChildrenBind( bool enable) {
                         efl_model_view_children_bind_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  enable);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]
    protected static extern  Eina.Error efl_model_view_property_logic_add(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String property,  IntPtr get_data, EflModelViewPropertyGetInternal get, EinaFreeCb get_free_cb,  IntPtr set_data, EflModelViewPropertySetInternal set, EinaFreeCb set_free_cb,    System.IntPtr binded);
   /// <summary>Add callbacks that will be triggered when someone ask for the specified property name when getting or setting a property.
   /// A get or set should at least be provided for this call to succeed.
   /// 
   /// See <see cref="Efl.ModelView.DelPropertyLogic"/></summary>
   /// <param name="property">The property to bind on to.</param>
   /// <param name="get">Define the get callback called when the <see cref="Efl.Model.GetProperty"/> is called with the above property name.</param>
   /// <param name="set">Define the set callback called when the <see cref="Efl.Model.GetProperty"/> is called with the above property name.</param>
   /// <param name="binded">Iterator of property name to bind with this defined property see <see cref="Efl.ModelView.PropertyBind"/>.</param>
   /// <returns></returns>
   virtual public  Eina.Error AddPropertyLogic(  System.String property,  EflModelViewPropertyGet get,  EflModelViewPropertySet set,  Eina.Iterator< System.String> binded) {
                         var _in_binded = binded.Handle;
                                    GCHandle get_handle = GCHandle.Alloc(get);
      GCHandle set_handle = GCHandle.Alloc(set);
            var _ret_var = efl_model_view_property_logic_add((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  property, GCHandle.ToIntPtr(get_handle), EflModelViewPropertyGetWrapper.Cb, Efl.Eo.Globals.free_gchandle, GCHandle.ToIntPtr(set_handle), EflModelViewPropertySetWrapper.Cb, Efl.Eo.Globals.free_gchandle,  _in_binded);
      Eina.Error.RaiseIfUnhandledException();
                                                      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]
    protected static extern  Eina.Error efl_model_view_property_logic_del(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String property);
   /// <summary>Delete previously added callbacks that were triggered when someone asked for the specified property name when getting or setting a property.
   /// A get or set should at least be provided for this call to succeed.
   /// 
   /// See <see cref="Efl.ModelView.AddPropertyLogic"/></summary>
   /// <param name="property">The property to bind on to.</param>
   /// <returns></returns>
   virtual public  Eina.Error DelPropertyLogic(  System.String property) {
                         var _ret_var = efl_model_view_property_logic_del((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  property);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]
    protected static extern  void efl_model_view_property_bind(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String source,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String destination);
   /// <summary>Automatically update the field for the event <see cref="Efl.Model.PropertiesChangedEvt"/> to include property that are impacted with change in a property from the composited model.
   /// The source doesn&apos;t have to be provided at this point by the composited model.</summary>
   /// <param name="source">Property name in the composited model.</param>
   /// <param name="destination">Property name in the <see cref="Efl.ModelView"/></param>
   /// <returns></returns>
   virtual public  void PropertyBind(  System.String source,   System.String destination) {
                                           efl_model_view_property_bind((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  source,  destination);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]
    protected static extern  void efl_model_view_property_unbind(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String source,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String destination);
   /// <summary>Stop automatically updating the field for the event <see cref="Efl.Model.PropertiesChangedEvt"/> to include property that are impacted with change in a property from the composited model.</summary>
   /// <param name="source">Property name in the composited model.</param>
   /// <param name="destination">Property name in the <see cref="Efl.ModelView"/></param>
   /// <returns></returns>
   virtual public  void PropertyUnbind(  System.String source,   System.String destination) {
                                           efl_model_view_property_unbind((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  source,  destination);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Define if we will intercept all childrens object reference and bind them through the ModelView with the same property logic as this one. Be careful of recursivity.
/// This can only be applied at construction time.</summary>
   public bool ChildrenBind {
      get { return GetChildrenBind(); }
      set { SetChildrenBind( value); }
   }
}
public class ModelViewNativeInherit : Efl.ModelCompositeNativeInherit{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_model_view_children_bind_get_static_delegate = new efl_model_view_children_bind_get_delegate(children_bind_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_model_view_children_bind_get"), func = Marshal.GetFunctionPointerForDelegate(efl_model_view_children_bind_get_static_delegate)});
      efl_model_view_children_bind_set_static_delegate = new efl_model_view_children_bind_set_delegate(children_bind_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_model_view_children_bind_set"), func = Marshal.GetFunctionPointerForDelegate(efl_model_view_children_bind_set_static_delegate)});
      efl_model_view_property_logic_add_static_delegate = new efl_model_view_property_logic_add_delegate(property_logic_add);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_model_view_property_logic_add"), func = Marshal.GetFunctionPointerForDelegate(efl_model_view_property_logic_add_static_delegate)});
      efl_model_view_property_logic_del_static_delegate = new efl_model_view_property_logic_del_delegate(property_logic_del);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_model_view_property_logic_del"), func = Marshal.GetFunctionPointerForDelegate(efl_model_view_property_logic_del_static_delegate)});
      efl_model_view_property_bind_static_delegate = new efl_model_view_property_bind_delegate(property_bind);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_model_view_property_bind"), func = Marshal.GetFunctionPointerForDelegate(efl_model_view_property_bind_static_delegate)});
      efl_model_view_property_unbind_static_delegate = new efl_model_view_property_unbind_delegate(property_unbind);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_model_view_property_unbind"), func = Marshal.GetFunctionPointerForDelegate(efl_model_view_property_unbind_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.ModelView.efl_model_view_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.ModelView.efl_model_view_class_get();
   }


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_model_view_children_bind_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_model_view_children_bind_get(System.IntPtr obj);
    private static bool children_bind_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_model_view_children_bind_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((ModelView)wrapper).GetChildrenBind();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_model_view_children_bind_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_model_view_children_bind_get_delegate efl_model_view_children_bind_get_static_delegate;


    private delegate  void efl_model_view_children_bind_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool enable);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]  private static extern  void efl_model_view_children_bind_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool enable);
    private static  void children_bind_set(System.IntPtr obj, System.IntPtr pd,  bool enable)
   {
      Eina.Log.Debug("function efl_model_view_children_bind_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((ModelView)wrapper).SetChildrenBind( enable);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_model_view_children_bind_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  enable);
      }
   }
   private efl_model_view_children_bind_set_delegate efl_model_view_children_bind_set_static_delegate;


    private delegate  Eina.Error efl_model_view_property_logic_add_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String property,  IntPtr get_data, EflModelViewPropertyGetInternal get, EinaFreeCb get_free_cb,  IntPtr set_data, EflModelViewPropertySetInternal set, EinaFreeCb set_free_cb,    System.IntPtr binded);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]  private static extern  Eina.Error efl_model_view_property_logic_add(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String property,  IntPtr get_data, EflModelViewPropertyGetInternal get, EinaFreeCb get_free_cb,  IntPtr set_data, EflModelViewPropertySetInternal set, EinaFreeCb set_free_cb,    System.IntPtr binded);
    private static  Eina.Error property_logic_add(System.IntPtr obj, System.IntPtr pd,   System.String property, IntPtr get_data, EflModelViewPropertyGetInternal get, EinaFreeCb get_free_cb, IntPtr set_data, EflModelViewPropertySetInternal set, EinaFreeCb set_free_cb,   System.IntPtr binded)
   {
      Eina.Log.Debug("function efl_model_view_property_logic_add was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                 var _in_binded = new Eina.Iterator< System.String>(binded, false, false);
                                       EflModelViewPropertyGetWrapper get_wrapper = new EflModelViewPropertyGetWrapper(get, get_data, get_free_cb);
         EflModelViewPropertySetWrapper set_wrapper = new EflModelViewPropertySetWrapper(set, set_data, set_free_cb);
                Eina.Error _ret_var = default( Eina.Error);
         try {
            _ret_var = ((ModelView)wrapper).AddPropertyLogic( property,  get_wrapper.ManagedCb,  set_wrapper.ManagedCb,  _in_binded);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                      return _ret_var;
      } else {
         return efl_model_view_property_logic_add(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  property, get_data, get, get_free_cb, set_data, set, set_free_cb,  binded);
      }
   }
   private efl_model_view_property_logic_add_delegate efl_model_view_property_logic_add_static_delegate;


    private delegate  Eina.Error efl_model_view_property_logic_del_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String property);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]  private static extern  Eina.Error efl_model_view_property_logic_del(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String property);
    private static  Eina.Error property_logic_del(System.IntPtr obj, System.IntPtr pd,   System.String property)
   {
      Eina.Log.Debug("function efl_model_view_property_logic_del was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                     Eina.Error _ret_var = default( Eina.Error);
         try {
            _ret_var = ((ModelView)wrapper).DelPropertyLogic( property);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_model_view_property_logic_del(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  property);
      }
   }
   private efl_model_view_property_logic_del_delegate efl_model_view_property_logic_del_static_delegate;


    private delegate  void efl_model_view_property_bind_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String source,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String destination);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]  private static extern  void efl_model_view_property_bind(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String source,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String destination);
    private static  void property_bind(System.IntPtr obj, System.IntPtr pd,   System.String source,   System.String destination)
   {
      Eina.Log.Debug("function efl_model_view_property_bind was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((ModelView)wrapper).PropertyBind( source,  destination);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_model_view_property_bind(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  source,  destination);
      }
   }
   private efl_model_view_property_bind_delegate efl_model_view_property_bind_static_delegate;


    private delegate  void efl_model_view_property_unbind_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String source,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String destination);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]  private static extern  void efl_model_view_property_unbind(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String source,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String destination);
    private static  void property_unbind(System.IntPtr obj, System.IntPtr pd,   System.String source,   System.String destination)
   {
      Eina.Log.Debug("function efl_model_view_property_unbind was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((ModelView)wrapper).PropertyUnbind( source,  destination);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_model_view_property_unbind(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  source,  destination);
      }
   }
   private efl_model_view_property_unbind_delegate efl_model_view_property_unbind_static_delegate;
}
} 
