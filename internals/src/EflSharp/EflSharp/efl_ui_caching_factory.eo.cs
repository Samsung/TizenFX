#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary>Efl Ui Factory that provides object caching.
/// This factory handles caching of one type of object and automatically empties the cache when the application goes into pause.
/// 
/// Creating objects is costly and time consuming, keeping a few on hand for when you next will need them helps a lot. This is what this factory caching infrastructure provides. It will create the object from the class defined on it and set the parent and the model as needed for all created items. The View has to release the Item using the release function of the Factory interface for all of this to work properly.
/// 
/// The cache might decide to flush itself when the application event pause is triggered.</summary>
[CachingFactoryNativeInherit]
public class CachingFactory : Efl.LoopConsumer, Efl.Eo.IWrapper,Efl.Ui.Factory,Efl.Ui.Model.Connect
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Ui.CachingFactoryNativeInherit nativeInherit = new Efl.Ui.CachingFactoryNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (CachingFactory))
            return Efl.Ui.CachingFactoryNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   ///<summary>Delegate for function to be called from inside the native constructor.</summary>
   public new delegate void ConstructingMethod(CachingFactory obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
      efl_ui_caching_factory_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="init_cb">Delegate to call constructing methods that should be run inside the constructor.</param>
   public CachingFactory(Efl.Object parent = null, ConstructingMethod init_cb=null) : base("CachingFactory", efl_ui_caching_factory_class_get(), typeof(CachingFactory), parent)
   {
      if (init_cb != null) {
         init_cb(this);
      }
      FinishInstantiation();
   }
   ///<summary>Internal constructor to forward the wrapper initialization to the root class.</summary>
   protected CachingFactory(String klass_name, IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(klass_name, base_klass, managed_type, parent) {}
   ///<summary>Constructs an instance from a native pointer.</summary>
   public CachingFactory(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static CachingFactory static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new CachingFactory(obj.NativeHandle);
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
            if (add_cpp_event_handler(key, this.evt_CreatedEvt_delegate)) {
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


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Class, Efl.Eo.NonOwnTag>))] protected static extern Efl.Class efl_ui_caching_factory_item_class_get(System.IntPtr obj);
   /// <summary>Define the class of the item returned by this factory.</summary>
   /// <returns>The class identifier to create item from.</returns>
   virtual public Efl.Class GetItemClass() {
       var _ret_var = efl_ui_caching_factory_item_class_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_caching_factory_item_class_set(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Class, Efl.Eo.NonOwnTag>))]  Efl.Class klass);
   /// <summary>Define the class of the item returned by this factory.</summary>
   /// <param name="klass">The class identifier to create item from.</param>
   /// <returns></returns>
   virtual public  void SetItemClass( Efl.Class klass) {
                         efl_ui_caching_factory_item_class_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  klass);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  uint efl_ui_caching_factory_memory_limit_get(System.IntPtr obj);
   /// <summary>Define the maxium size in Bytes that all the object waiting on standby in the cache take. They must provide the <see cref="Efl.Cached.Item"/> interface for an accurate accounting.</summary>
   /// <returns>When set to zero, there is no limit on the amount of memory the cache will use.</returns>
   virtual public  uint GetMemoryLimit() {
       var _ret_var = efl_ui_caching_factory_memory_limit_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_caching_factory_memory_limit_set(System.IntPtr obj,    uint limit);
   /// <summary>Define the maxium size in Bytes that all the object waiting on standby in the cache take. They must provide the <see cref="Efl.Cached.Item"/> interface for an accurate accounting.</summary>
   /// <param name="limit">When set to zero, there is no limit on the amount of memory the cache will use.</param>
   /// <returns></returns>
   virtual public  void SetMemoryLimit(  uint limit) {
                         efl_ui_caching_factory_memory_limit_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  limit);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  uint efl_ui_caching_factory_items_limit_get(System.IntPtr obj);
   /// <summary>Define how many maximum number of items are waiting on standby in the cache.</summary>
   /// <returns>When set to zero, there is no limit to the amount of items stored in the cache.</returns>
   virtual public  uint GetItemsLimit() {
       var _ret_var = efl_ui_caching_factory_items_limit_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_caching_factory_items_limit_set(System.IntPtr obj,    uint limit);
   /// <summary>Define how many maximum number of items are waiting on standby in the cache.</summary>
   /// <param name="limit">When set to zero, there is no limit to the amount of items stored in the cache.</param>
   /// <returns></returns>
   virtual public  void SetItemsLimit(  uint limit) {
                         efl_ui_caching_factory_items_limit_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  limit);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))] protected static extern  Eina.Future efl_ui_factory_create(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.ModelConcrete, Efl.Eo.NonOwnTag>))]  Efl.Model model, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity parent);
   /// <summary>Create a UI object from the necessary properties in the specified model.</summary>
   /// <param name="model">Efl model</param>
   /// <param name="parent">Efl canvas</param>
   /// <returns>Created UI object</returns>
   virtual public  Eina.Future Create( Efl.Model model,  Efl.Gfx.Entity parent) {
                                           var _ret_var = efl_ui_factory_create((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  model,  parent);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_ui_factory_release(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity ui_view);
   /// <summary>Release a UI object and disconnect from models.</summary>
   /// <param name="ui_view">Efl canvas</param>
   /// <returns></returns>
   virtual public  void Release( Efl.Gfx.Entity ui_view) {
                         efl_ui_factory_release((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  ui_view);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_ui_factory_model_connect(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.FactoryConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Factory factory);
   /// <summary>Connect factory to a model</summary>
   /// <param name="name">Model name</param>
   /// <param name="factory">Efl factory</param>
   /// <returns></returns>
   virtual public  void ModelConnect(  System.String name,  Efl.Ui.Factory factory) {
                                           efl_ui_factory_model_connect((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  name,  factory);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_ui_model_connect(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String property);
   /// <summary>Connect property</summary>
   /// <param name="name">Model name</param>
   /// <param name="property">Property name</param>
   /// <returns></returns>
   virtual public  void DoConnect(  System.String name,   System.String property) {
                                           efl_ui_model_connect((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  name,  property);
      Eina.Error.RaiseIfUnhandledException();
                               }
   public System.Threading.Tasks.Task<Eina.Value> CreateAsync( Efl.Model model, Efl.Gfx.Entity parent, System.Threading.CancellationToken token=default(System.Threading.CancellationToken))
   {
      Eina.Future future = Create(  model,  parent);
      return Efl.Eo.Globals.WrapAsync(future, token);
   }
   /// <summary>Define the class of the item returned by this factory.</summary>
   public Efl.Class ItemClass {
      get { return GetItemClass(); }
      set { SetItemClass( value); }
   }
   /// <summary>Define the maxium size in Bytes that all the object waiting on standby in the cache take. They must provide the <see cref="Efl.Cached.Item"/> interface for an accurate accounting.</summary>
   public  uint MemoryLimit {
      get { return GetMemoryLimit(); }
      set { SetMemoryLimit( value); }
   }
   /// <summary>Define how many maximum number of items are waiting on standby in the cache.</summary>
   public  uint ItemsLimit {
      get { return GetItemsLimit(); }
      set { SetItemsLimit( value); }
   }
}
public class CachingFactoryNativeInherit : Efl.LoopConsumerNativeInherit{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_ui_caching_factory_item_class_get_static_delegate = new efl_ui_caching_factory_item_class_get_delegate(item_class_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_caching_factory_item_class_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_caching_factory_item_class_get_static_delegate)});
      efl_ui_caching_factory_item_class_set_static_delegate = new efl_ui_caching_factory_item_class_set_delegate(item_class_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_caching_factory_item_class_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_caching_factory_item_class_set_static_delegate)});
      efl_ui_caching_factory_memory_limit_get_static_delegate = new efl_ui_caching_factory_memory_limit_get_delegate(memory_limit_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_caching_factory_memory_limit_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_caching_factory_memory_limit_get_static_delegate)});
      efl_ui_caching_factory_memory_limit_set_static_delegate = new efl_ui_caching_factory_memory_limit_set_delegate(memory_limit_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_caching_factory_memory_limit_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_caching_factory_memory_limit_set_static_delegate)});
      efl_ui_caching_factory_items_limit_get_static_delegate = new efl_ui_caching_factory_items_limit_get_delegate(items_limit_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_caching_factory_items_limit_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_caching_factory_items_limit_get_static_delegate)});
      efl_ui_caching_factory_items_limit_set_static_delegate = new efl_ui_caching_factory_items_limit_set_delegate(items_limit_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_caching_factory_items_limit_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_caching_factory_items_limit_set_static_delegate)});
      efl_ui_factory_create_static_delegate = new efl_ui_factory_create_delegate(create);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_factory_create"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_factory_create_static_delegate)});
      efl_ui_factory_release_static_delegate = new efl_ui_factory_release_delegate(release);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_factory_release"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_factory_release_static_delegate)});
      efl_ui_factory_model_connect_static_delegate = new efl_ui_factory_model_connect_delegate(model_connect);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_factory_model_connect"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_factory_model_connect_static_delegate)});
      efl_ui_model_connect_static_delegate = new efl_ui_model_connect_delegate(connect);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_model_connect"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_model_connect_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Ui.CachingFactory.efl_ui_caching_factory_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.CachingFactory.efl_ui_caching_factory_class_get();
   }


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Class, Efl.Eo.NonOwnTag>))] private delegate Efl.Class efl_ui_caching_factory_item_class_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Class, Efl.Eo.NonOwnTag>))] private static extern Efl.Class efl_ui_caching_factory_item_class_get(System.IntPtr obj);
    private static Efl.Class item_class_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_caching_factory_item_class_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Class _ret_var = default(Efl.Class);
         try {
            _ret_var = ((CachingFactory)wrapper).GetItemClass();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_caching_factory_item_class_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_caching_factory_item_class_get_delegate efl_ui_caching_factory_item_class_get_static_delegate;


    private delegate  void efl_ui_caching_factory_item_class_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Class, Efl.Eo.NonOwnTag>))]  Efl.Class klass);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_caching_factory_item_class_set(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Class, Efl.Eo.NonOwnTag>))]  Efl.Class klass);
    private static  void item_class_set(System.IntPtr obj, System.IntPtr pd,  Efl.Class klass)
   {
      Eina.Log.Debug("function efl_ui_caching_factory_item_class_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((CachingFactory)wrapper).SetItemClass( klass);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_caching_factory_item_class_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  klass);
      }
   }
   private efl_ui_caching_factory_item_class_set_delegate efl_ui_caching_factory_item_class_set_static_delegate;


    private delegate  uint efl_ui_caching_factory_memory_limit_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  uint efl_ui_caching_factory_memory_limit_get(System.IntPtr obj);
    private static  uint memory_limit_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_caching_factory_memory_limit_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   uint _ret_var = default( uint);
         try {
            _ret_var = ((CachingFactory)wrapper).GetMemoryLimit();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_caching_factory_memory_limit_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_caching_factory_memory_limit_get_delegate efl_ui_caching_factory_memory_limit_get_static_delegate;


    private delegate  void efl_ui_caching_factory_memory_limit_set_delegate(System.IntPtr obj, System.IntPtr pd,    uint limit);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_caching_factory_memory_limit_set(System.IntPtr obj,    uint limit);
    private static  void memory_limit_set(System.IntPtr obj, System.IntPtr pd,   uint limit)
   {
      Eina.Log.Debug("function efl_ui_caching_factory_memory_limit_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((CachingFactory)wrapper).SetMemoryLimit( limit);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_caching_factory_memory_limit_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  limit);
      }
   }
   private efl_ui_caching_factory_memory_limit_set_delegate efl_ui_caching_factory_memory_limit_set_static_delegate;


    private delegate  uint efl_ui_caching_factory_items_limit_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  uint efl_ui_caching_factory_items_limit_get(System.IntPtr obj);
    private static  uint items_limit_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_caching_factory_items_limit_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   uint _ret_var = default( uint);
         try {
            _ret_var = ((CachingFactory)wrapper).GetItemsLimit();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_caching_factory_items_limit_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_caching_factory_items_limit_get_delegate efl_ui_caching_factory_items_limit_get_static_delegate;


    private delegate  void efl_ui_caching_factory_items_limit_set_delegate(System.IntPtr obj, System.IntPtr pd,    uint limit);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_caching_factory_items_limit_set(System.IntPtr obj,    uint limit);
    private static  void items_limit_set(System.IntPtr obj, System.IntPtr pd,   uint limit)
   {
      Eina.Log.Debug("function efl_ui_caching_factory_items_limit_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((CachingFactory)wrapper).SetItemsLimit( limit);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_caching_factory_items_limit_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  limit);
      }
   }
   private efl_ui_caching_factory_items_limit_set_delegate efl_ui_caching_factory_items_limit_set_static_delegate;


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))] private delegate  Eina.Future efl_ui_factory_create_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.ModelConcrete, Efl.Eo.NonOwnTag>))]  Efl.Model model, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity parent);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))] private static extern  Eina.Future efl_ui_factory_create(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.ModelConcrete, Efl.Eo.NonOwnTag>))]  Efl.Model model, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity parent);
    private static  Eina.Future create(System.IntPtr obj, System.IntPtr pd,  Efl.Model model,  Efl.Gfx.Entity parent)
   {
      Eina.Log.Debug("function efl_ui_factory_create was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                       Eina.Future _ret_var = default( Eina.Future);
         try {
            _ret_var = ((CachingFactory)wrapper).Create( model,  parent);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_ui_factory_create(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  model,  parent);
      }
   }
   private efl_ui_factory_create_delegate efl_ui_factory_create_static_delegate;


    private delegate  void efl_ui_factory_release_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity ui_view);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_ui_factory_release(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity ui_view);
    private static  void release(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.Entity ui_view)
   {
      Eina.Log.Debug("function efl_ui_factory_release was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((CachingFactory)wrapper).Release( ui_view);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_factory_release(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  ui_view);
      }
   }
   private efl_ui_factory_release_delegate efl_ui_factory_release_static_delegate;


    private delegate  void efl_ui_factory_model_connect_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.FactoryConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Factory factory);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_ui_factory_model_connect(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.FactoryConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Factory factory);
    private static  void model_connect(System.IntPtr obj, System.IntPtr pd,   System.String name,  Efl.Ui.Factory factory)
   {
      Eina.Log.Debug("function efl_ui_factory_model_connect was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((CachingFactory)wrapper).ModelConnect( name,  factory);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_ui_factory_model_connect(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  name,  factory);
      }
   }
   private efl_ui_factory_model_connect_delegate efl_ui_factory_model_connect_static_delegate;


    private delegate  void efl_ui_model_connect_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String property);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_ui_model_connect(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String property);
    private static  void connect(System.IntPtr obj, System.IntPtr pd,   System.String name,   System.String property)
   {
      Eina.Log.Debug("function efl_ui_model_connect was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((CachingFactory)wrapper).DoConnect( name,  property);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_ui_model_connect(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  name,  property);
      }
   }
   private efl_ui_model_connect_delegate efl_ui_model_connect_static_delegate;
}
} } 
