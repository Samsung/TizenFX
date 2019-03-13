#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary>Efl Ui Factory that provides <see cref="Efl.Ui.Widget"/>.
/// This factory is designed to build <see cref="Efl.Ui.Widget"/> and optionally set their <see cref="Efl.Ui.Widget.Style"/> if it was connected with <see cref="Efl.Ui.PropertyBind.PropertyBind"/> &quot;<c>style</c>&quot;.</summary>
[WidgetFactoryNativeInherit]
public class WidgetFactory : Efl.LoopConsumer, Efl.Eo.IWrapper,Efl.Ui.Factory,Efl.Ui.FactoryBind,Efl.Ui.PropertyBind
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Ui.WidgetFactoryNativeInherit nativeInherit = new Efl.Ui.WidgetFactoryNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (WidgetFactory))
            return Efl.Ui.WidgetFactoryNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
      }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
      efl_ui_widget_factory_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="itemClass">Define the class of the item returned by this factory. See <see cref="Efl.Ui.WidgetFactory.SetItemClass"/></param>
   public WidgetFactory(Efl.Object parent
         , Type itemClass = null) :
      base(efl_ui_widget_factory_class_get(), typeof(WidgetFactory), parent)
   {
      if (Efl.Eo.Globals.ParamHelperCheck(itemClass))
         SetItemClass(Efl.Eo.Globals.GetParamHelper(itemClass));
      FinishInstantiation();
   }
   ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
   public WidgetFactory(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
   protected WidgetFactory(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static WidgetFactory static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new WidgetFactory(obj.NativeHandle);
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
private static object CreatedEvtKey = new object();
   /// <summary>Event triggered when an item has been successfully created.</summary>
   public event EventHandler<Efl.Ui.FactoryCreatedEvt_Args> CreatedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_FACTORY_EVENT_CREATED";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_CreatedEvt_delegate)) {
               eventHandlers.AddHandler(CreatedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_FACTORY_EVENT_CREATED";
            if (remove_cpp_event_handler(key, this.evt_CreatedEvt_delegate)) { 
               eventHandlers.RemoveHandler(CreatedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event CreatedEvt.</summary>
   public void On_CreatedEvt(Efl.Ui.FactoryCreatedEvt_Args e)
   {
      EventHandler<Efl.Ui.FactoryCreatedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Ui.FactoryCreatedEvt_Args>)eventHandlers[CreatedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_CreatedEvt_delegate;
   private void on_CreatedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Ui.FactoryCreatedEvt_Args args = new Efl.Ui.FactoryCreatedEvt_Args();
      args.arg =  evt.Info;;
      try {
         On_CreatedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

   protected override void register_event_proxies()
   {
      base.register_event_proxies();
      evt_CreatedEvt_delegate = new Efl.EventCb(on_CreatedEvt_NativeCallback);
   }
   /// <summary>Define the class of the item returned by this factory.</summary>
   /// <returns>The class identifier to create item from.</returns>
   virtual public Type GetItemClass() {
       var _ret_var = Efl.Ui.WidgetFactoryNativeInherit.efl_ui_widget_factory_item_class_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Define the class of the item returned by this factory.</summary>
   /// <param name="klass">The class identifier to create item from.</param>
   /// <returns></returns>
   virtual public  void SetItemClass( Type klass) {
                         Efl.Ui.WidgetFactoryNativeInherit.efl_ui_widget_factory_item_class_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), klass);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Create a UI object from the necessary properties in the specified model.</summary>
   /// <param name="model">Efl model</param>
   /// <param name="parent">Efl canvas</param>
   /// <returns>Created UI object</returns>
   virtual public  Eina.Future Create( Efl.Model model,  Efl.Gfx.Entity parent) {
                                           var _ret_var = Efl.Ui.FactoryNativeInherit.efl_ui_factory_create_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), model,  parent);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }
   /// <summary>Release a UI object and disconnect from models.</summary>
   /// <param name="ui_view">Efl canvas</param>
   /// <returns></returns>
   virtual public  void Release( Efl.Gfx.Entity ui_view) {
                         Efl.Ui.FactoryNativeInherit.efl_ui_factory_release_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), ui_view);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>bind the factory with the given key string. when the data is ready or changed, factory create the object and bind the data to the key action and process promised work. Note: the input <see cref="Efl.Ui.Factory"/> need to be <see cref="Efl.Ui.PropertyBind.PropertyBind"/> at least once.</summary>
   /// <param name="key">Key string for bind model property data</param>
   /// <param name="factory"><see cref="Efl.Ui.Factory"/> for create and bind model property data</param>
   /// <returns></returns>
   virtual public  void FactoryBind(  System.String key,  Efl.Ui.Factory factory) {
                                           Efl.Ui.FactoryBindNativeInherit.efl_ui_factory_bind_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), key,  factory);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>bind property data with the given key string. when the data is ready or changed, bind the data to the key action and process promised work.</summary>
   /// <param name="key">key string for bind model property data</param>
   /// <param name="property">Model property name</param>
   /// <returns></returns>
   virtual public  void PropertyBind(  System.String key,   System.String property) {
                                           Efl.Ui.PropertyBindNativeInherit.efl_ui_property_bind_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), key,  property);
      Eina.Error.RaiseIfUnhandledException();
                               }
   public System.Threading.Tasks.Task<Eina.Value> CreateAsync( Efl.Model model, Efl.Gfx.Entity parent, System.Threading.CancellationToken token=default(System.Threading.CancellationToken))
   {
      Eina.Future future = Create(  model,  parent);
      return Efl.Eo.Globals.WrapAsync(future, token);
   }
   /// <summary>Define the class of the item returned by this factory.</summary>
/// <value>The class identifier to create item from.</value>
   public Type ItemClass {
      get { return GetItemClass(); }
      set { SetItemClass( value); }
   }
   private static new  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.WidgetFactory.efl_ui_widget_factory_class_get();
   }
}
public class WidgetFactoryNativeInherit : Efl.LoopConsumerNativeInherit{
   public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Elementary);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      if (efl_ui_widget_factory_item_class_get_static_delegate == null)
      efl_ui_widget_factory_item_class_get_static_delegate = new efl_ui_widget_factory_item_class_get_delegate(item_class_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_widget_factory_item_class_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_factory_item_class_get_static_delegate)});
      if (efl_ui_widget_factory_item_class_set_static_delegate == null)
      efl_ui_widget_factory_item_class_set_static_delegate = new efl_ui_widget_factory_item_class_set_delegate(item_class_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_widget_factory_item_class_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_factory_item_class_set_static_delegate)});
      if (efl_ui_factory_create_static_delegate == null)
      efl_ui_factory_create_static_delegate = new efl_ui_factory_create_delegate(create);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_factory_create"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_factory_create_static_delegate)});
      if (efl_ui_factory_release_static_delegate == null)
      efl_ui_factory_release_static_delegate = new efl_ui_factory_release_delegate(release);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_factory_release"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_factory_release_static_delegate)});
      if (efl_ui_factory_bind_static_delegate == null)
      efl_ui_factory_bind_static_delegate = new efl_ui_factory_bind_delegate(factory_bind);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_factory_bind"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_factory_bind_static_delegate)});
      if (efl_ui_property_bind_static_delegate == null)
      efl_ui_property_bind_static_delegate = new efl_ui_property_bind_delegate(property_bind);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_property_bind"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_property_bind_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Ui.WidgetFactory.efl_ui_widget_factory_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.WidgetFactory.efl_ui_widget_factory_class_get();
   }


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEflClass))] private delegate Type efl_ui_widget_factory_item_class_get_delegate(System.IntPtr obj, System.IntPtr pd);


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEflClass))] public delegate Type efl_ui_widget_factory_item_class_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_widget_factory_item_class_get_api_delegate> efl_ui_widget_factory_item_class_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_factory_item_class_get_api_delegate>(_Module, "efl_ui_widget_factory_item_class_get");
    private static Type item_class_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_widget_factory_item_class_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Type _ret_var = default(Type);
         try {
            _ret_var = ((WidgetFactory)wrapper).GetItemClass();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_widget_factory_item_class_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_widget_factory_item_class_get_delegate efl_ui_widget_factory_item_class_get_static_delegate;


    private delegate  void efl_ui_widget_factory_item_class_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEflClass))]  Type klass);


    public delegate  void efl_ui_widget_factory_item_class_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEflClass))]  Type klass);
    public static Efl.Eo.FunctionWrapper<efl_ui_widget_factory_item_class_set_api_delegate> efl_ui_widget_factory_item_class_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_factory_item_class_set_api_delegate>(_Module, "efl_ui_widget_factory_item_class_set");
    private static  void item_class_set(System.IntPtr obj, System.IntPtr pd,  Type klass)
   {
      Eina.Log.Debug("function efl_ui_widget_factory_item_class_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((WidgetFactory)wrapper).SetItemClass( klass);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_widget_factory_item_class_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  klass);
      }
   }
   private static efl_ui_widget_factory_item_class_set_delegate efl_ui_widget_factory_item_class_set_static_delegate;


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))] private delegate  Eina.Future efl_ui_factory_create_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.ModelConcrete, Efl.Eo.NonOwnTag>))]  Efl.Model model, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity parent);


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))] public delegate  Eina.Future efl_ui_factory_create_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.ModelConcrete, Efl.Eo.NonOwnTag>))]  Efl.Model model, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity parent);
    public static Efl.Eo.FunctionWrapper<efl_ui_factory_create_api_delegate> efl_ui_factory_create_ptr = new Efl.Eo.FunctionWrapper<efl_ui_factory_create_api_delegate>(_Module, "efl_ui_factory_create");
    private static  Eina.Future create(System.IntPtr obj, System.IntPtr pd,  Efl.Model model,  Efl.Gfx.Entity parent)
   {
      Eina.Log.Debug("function efl_ui_factory_create was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                       Eina.Future _ret_var = default( Eina.Future);
         try {
            _ret_var = ((WidgetFactory)wrapper).Create( model,  parent);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_ui_factory_create_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  model,  parent);
      }
   }
   private static efl_ui_factory_create_delegate efl_ui_factory_create_static_delegate;


    private delegate  void efl_ui_factory_release_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity ui_view);


    public delegate  void efl_ui_factory_release_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity ui_view);
    public static Efl.Eo.FunctionWrapper<efl_ui_factory_release_api_delegate> efl_ui_factory_release_ptr = new Efl.Eo.FunctionWrapper<efl_ui_factory_release_api_delegate>(_Module, "efl_ui_factory_release");
    private static  void release(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.Entity ui_view)
   {
      Eina.Log.Debug("function efl_ui_factory_release was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((WidgetFactory)wrapper).Release( ui_view);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_factory_release_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  ui_view);
      }
   }
   private static efl_ui_factory_release_delegate efl_ui_factory_release_static_delegate;


    private delegate  void efl_ui_factory_bind_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Ui.FactoryConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Factory factory);


    public delegate  void efl_ui_factory_bind_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Ui.FactoryConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Factory factory);
    public static Efl.Eo.FunctionWrapper<efl_ui_factory_bind_api_delegate> efl_ui_factory_bind_ptr = new Efl.Eo.FunctionWrapper<efl_ui_factory_bind_api_delegate>(_Module, "efl_ui_factory_bind");
    private static  void factory_bind(System.IntPtr obj, System.IntPtr pd,   System.String key,  Efl.Ui.Factory factory)
   {
      Eina.Log.Debug("function efl_ui_factory_bind was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((WidgetFactory)wrapper).FactoryBind( key,  factory);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_ui_factory_bind_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  key,  factory);
      }
   }
   private static efl_ui_factory_bind_delegate efl_ui_factory_bind_static_delegate;


    private delegate  void efl_ui_property_bind_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String property);


    public delegate  void efl_ui_property_bind_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String property);
    public static Efl.Eo.FunctionWrapper<efl_ui_property_bind_api_delegate> efl_ui_property_bind_ptr = new Efl.Eo.FunctionWrapper<efl_ui_property_bind_api_delegate>(_Module, "efl_ui_property_bind");
    private static  void property_bind(System.IntPtr obj, System.IntPtr pd,   System.String key,   System.String property)
   {
      Eina.Log.Debug("function efl_ui_property_bind was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((WidgetFactory)wrapper).PropertyBind( key,  property);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_ui_property_bind_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  key,  property);
      }
   }
   private static efl_ui_property_bind_delegate efl_ui_property_bind_static_delegate;
}
} } 
