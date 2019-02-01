#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary>Efl UI factory interface</summary>
[FactoryConcreteNativeInherit]
public interface Factory : 
   Efl.Ui.Model.Connect ,
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>Create a UI object from the necessary properties in the specified model.</summary>
/// <param name="model">Efl model</param>
/// <param name="parent">Efl canvas</param>
/// <returns>Created UI object</returns>
 Eina.Future Create( Efl.Model model,  Efl.Gfx.Entity parent);
   /// <summary>Release a UI object and disconnect from models.</summary>
/// <param name="ui_view">Efl canvas</param>
/// <returns></returns>
 void Release( Efl.Gfx.Entity ui_view);
   /// <summary>Connect factory to a model</summary>
/// <param name="name">Model name</param>
/// <param name="factory">Efl factory</param>
/// <returns></returns>
 void ModelConnect(  System.String name,  Efl.Ui.Factory factory);
      System.Threading.Tasks.Task<Eina.Value> CreateAsync( Efl.Model model, Efl.Gfx.Entity parent, System.Threading.CancellationToken token=default(System.Threading.CancellationToken));
         /// <summary>Event triggered when an item has been successfully created.</summary>
   event EventHandler<Efl.Ui.FactoryCreatedEvt_Args> CreatedEvt;
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.Factory.CreatedEvt"/>.</summary>
public class FactoryCreatedEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public Efl.Ui.FactoryItemCreatedEvent arg { get; set; }
}
/// <summary>Efl UI factory interface</summary>
sealed public class FactoryConcrete : 

Factory
   , Efl.Ui.Model.Connect
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (FactoryConcrete))
            return Efl.Ui.FactoryConcreteNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   private EventHandlerList eventHandlers = new EventHandlerList();
   private  System.IntPtr handle;
   public Dictionary<String, IntPtr> cached_strings = new Dictionary<String, IntPtr>();
   public Dictionary<String, IntPtr> cached_stringshares = new Dictionary<String, IntPtr>();
   ///<summary>Pointer to the native instance.</summary>
   public System.IntPtr NativeHandle {
      get { return handle; }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] internal static extern System.IntPtr
      efl_ui_factory_interface_get();
   ///<summary>Constructs an instance from a native pointer.</summary>
   public FactoryConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~FactoryConcrete()
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
   public static FactoryConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new FactoryConcrete(obj.NativeHandle);
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
   private readonly object eventLock = new object();
   private Dictionary<string, int> event_cb_count = new Dictionary<string, int>();
   private bool add_cpp_event_handler(string key, Efl.EventCb evt_delegate) {
      int event_count = 0;
      if (!event_cb_count.TryGetValue(key, out event_count))
         event_cb_count[key] = event_count;
      if (event_count == 0) {
         IntPtr desc = Efl.EventDescription.GetNative(key);
         if (desc == IntPtr.Zero) {
            Eina.Log.Error($"Failed to get native event {key}");
            return false;
         }
          bool result = Efl.Eo.Globals.efl_event_callback_priority_add(handle, desc, 0, evt_delegate, System.IntPtr.Zero);
         if (!result) {
            Eina.Log.Error($"Failed to add event proxy for event {key}");
            return false;
         }
         Eina.Error.RaiseIfUnhandledException();
      } 
      event_cb_count[key]++;
      return true;
   }
   private bool remove_cpp_event_handler(string key, Efl.EventCb evt_delegate) {
      int event_count = 0;
      if (!event_cb_count.TryGetValue(key, out event_count))
         event_cb_count[key] = event_count;
      if (event_count == 1) {
         IntPtr desc = Efl.EventDescription.GetNative(key);
         if (desc == IntPtr.Zero) {
            Eina.Log.Error($"Failed to get native event {key}");
            return false;
         }
         bool result = Efl.Eo.Globals.efl_event_callback_del(handle, desc, evt_delegate, System.IntPtr.Zero);
         if (!result) {
            Eina.Log.Error($"Failed to remove event proxy for event {key}");
            return false;
         }
         Eina.Error.RaiseIfUnhandledException();
      } else if (event_count == 0) {
         Eina.Log.Error($"Trying to remove proxy for event {key} when there is nothing registered.");
         return false;
      } 
      event_cb_count[key]--;
      return true;
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

    void register_event_proxies()
   {
      evt_CreatedEvt_delegate = new Efl.EventCb(on_CreatedEvt_NativeCallback);
   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))] private static extern  Eina.Future efl_ui_factory_create(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.ModelConcrete, Efl.Eo.NonOwnTag>))]  Efl.Model model, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity parent);
   /// <summary>Create a UI object from the necessary properties in the specified model.</summary>
   /// <param name="model">Efl model</param>
   /// <param name="parent">Efl canvas</param>
   /// <returns>Created UI object</returns>
   public  Eina.Future Create( Efl.Model model,  Efl.Gfx.Entity parent) {
                                           var _ret_var = efl_ui_factory_create(Efl.Ui.FactoryConcrete.efl_ui_factory_interface_get(),  model,  parent);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_ui_factory_release(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity ui_view);
   /// <summary>Release a UI object and disconnect from models.</summary>
   /// <param name="ui_view">Efl canvas</param>
   /// <returns></returns>
   public  void Release( Efl.Gfx.Entity ui_view) {
                         efl_ui_factory_release(Efl.Ui.FactoryConcrete.efl_ui_factory_interface_get(),  ui_view);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_ui_factory_model_connect(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.FactoryConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Factory factory);
   /// <summary>Connect factory to a model</summary>
   /// <param name="name">Model name</param>
   /// <param name="factory">Efl factory</param>
   /// <returns></returns>
   public  void ModelConnect(  System.String name,  Efl.Ui.Factory factory) {
                                           efl_ui_factory_model_connect(Efl.Ui.FactoryConcrete.efl_ui_factory_interface_get(),  name,  factory);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_ui_model_connect(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String property);
   /// <summary>Connect property</summary>
   /// <param name="name">Model name</param>
   /// <param name="property">Property name</param>
   /// <returns></returns>
   public  void DoConnect(  System.String name,   System.String property) {
                                           efl_ui_model_connect(Efl.Ui.Model.ConnectConcrete.efl_ui_model_connect_interface_get(),  name,  property);
      Eina.Error.RaiseIfUnhandledException();
                               }
   public System.Threading.Tasks.Task<Eina.Value> CreateAsync( Efl.Model model, Efl.Gfx.Entity parent, System.Threading.CancellationToken token=default(System.Threading.CancellationToken))
   {
      Eina.Future future = Create(  model,  parent);
      return Efl.Eo.Globals.WrapAsync(future, token);
   }
}
public class FactoryConcreteNativeInherit : Efl.Eo.NativeClass{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_ui_factory_create_static_delegate = new efl_ui_factory_create_delegate(create);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_factory_create"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_factory_create_static_delegate)});
      efl_ui_factory_release_static_delegate = new efl_ui_factory_release_delegate(release);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_factory_release"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_factory_release_static_delegate)});
      efl_ui_factory_model_connect_static_delegate = new efl_ui_factory_model_connect_delegate(model_connect);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_factory_model_connect"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_factory_model_connect_static_delegate)});
      efl_ui_model_connect_static_delegate = new efl_ui_model_connect_delegate(connect);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_model_connect"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_model_connect_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Ui.FactoryConcrete.efl_ui_factory_interface_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.FactoryConcrete.efl_ui_factory_interface_get();
   }


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))] private delegate  Eina.Future efl_ui_factory_create_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.ModelConcrete, Efl.Eo.NonOwnTag>))]  Efl.Model model, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity parent);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))] private static extern  Eina.Future efl_ui_factory_create(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.ModelConcrete, Efl.Eo.NonOwnTag>))]  Efl.Model model, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity parent);
    private static  Eina.Future create(System.IntPtr obj, System.IntPtr pd,  Efl.Model model,  Efl.Gfx.Entity parent)
   {
      Eina.Log.Debug("function efl_ui_factory_create was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                       Eina.Future _ret_var = default( Eina.Future);
         try {
            _ret_var = ((Factory)wrapper).Create( model,  parent);
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
            ((Factory)wrapper).Release( ui_view);
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
            ((Factory)wrapper).ModelConnect( name,  factory);
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
            ((Factory)wrapper).DoConnect( name,  property);
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
namespace Efl { namespace Ui { 
/// <summary>EFL Ui Factory event structure provided when an item was just created.</summary>
[StructLayout(LayoutKind.Sequential)]
public struct FactoryItemCreatedEvent
{
   /// <summary>The model already set on the new item.</summary>
   public Efl.Model Model;
   /// <summary>The item that was just created.</summary>
   public Efl.Gfx.Entity Item;
   ///<summary>Constructor for FactoryItemCreatedEvent.</summary>
   public FactoryItemCreatedEvent(
      Efl.Model Model=default(Efl.Model),
      Efl.Gfx.Entity Item=default(Efl.Gfx.Entity)   )
   {
      this.Model = Model;
      this.Item = Item;
   }
public static implicit operator FactoryItemCreatedEvent(IntPtr ptr)
   {
      var tmp = (FactoryItemCreatedEvent_StructInternal)Marshal.PtrToStructure(ptr, typeof(FactoryItemCreatedEvent_StructInternal));
      return FactoryItemCreatedEvent_StructConversion.ToManaged(tmp);
   }
}
///<summary>Internal wrapper for struct FactoryItemCreatedEvent.</summary>
[StructLayout(LayoutKind.Sequential)]
public struct FactoryItemCreatedEvent_StructInternal
{
///<summary>Internal wrapper for field Model</summary>
public System.IntPtr Model;
///<summary>Internal wrapper for field Item</summary>
public System.IntPtr Item;
   ///<summary>Implicit conversion to the internal/marshalling representation.</summary>
   public static implicit operator FactoryItemCreatedEvent(FactoryItemCreatedEvent_StructInternal struct_)
   {
      return FactoryItemCreatedEvent_StructConversion.ToManaged(struct_);
   }
   ///<summary>Implicit conversion to the managed representation.</summary>
   public static implicit operator FactoryItemCreatedEvent_StructInternal(FactoryItemCreatedEvent struct_)
   {
      return FactoryItemCreatedEvent_StructConversion.ToInternal(struct_);
   }
}
/// <summary>Conversion class for struct FactoryItemCreatedEvent</summary>
public static class FactoryItemCreatedEvent_StructConversion
{
   internal static FactoryItemCreatedEvent_StructInternal ToInternal(FactoryItemCreatedEvent _external_struct)
   {
      var _internal_struct = new FactoryItemCreatedEvent_StructInternal();

      _internal_struct.Model = _external_struct.Model.NativeHandle;
      _internal_struct.Item = _external_struct.Item.NativeHandle;

      return _internal_struct;
   }

   internal static FactoryItemCreatedEvent ToManaged(FactoryItemCreatedEvent_StructInternal _internal_struct)
   {
      var _external_struct = new FactoryItemCreatedEvent();


      _external_struct.Model = (Efl.ModelConcrete) System.Activator.CreateInstance(typeof(Efl.ModelConcrete), new System.Object[] {_internal_struct.Model});
      Efl.Eo.Globals.efl_ref(_internal_struct.Model);


      _external_struct.Item = (Efl.Gfx.EntityConcrete) System.Activator.CreateInstance(typeof(Efl.Gfx.EntityConcrete), new System.Object[] {_internal_struct.Item});
      Efl.Eo.Globals.efl_ref(_internal_struct.Item);


      return _external_struct;
   }

}
} } 
