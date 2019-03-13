#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary>Efl UI factory interface</summary>
[FactoryNativeInherit]
public interface Factory : 
   Efl.Ui.FactoryBind ,
   Efl.Ui.PropertyBind ,
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
   , Efl.Ui.FactoryBind, Efl.Ui.PropertyBind
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (FactoryConcrete))
            return Efl.Ui.FactoryNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
      }
   }
   private EventHandlerList eventHandlers = new EventHandlerList();
   private  System.IntPtr handle;
   ///<summary>Pointer to the native instance.</summary>
   public System.IntPtr NativeHandle {
      get { return handle; }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] internal static extern System.IntPtr
      efl_ui_factory_interface_get();
   ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
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
   private bool add_cpp_event_handler(string lib, string key, Efl.EventCb evt_delegate) {
      int event_count = 0;
      if (!event_cb_count.TryGetValue(key, out event_count))
         event_cb_count[key] = event_count;
      if (event_count == 0) {
         IntPtr desc = Efl.EventDescription.GetNative(lib, key);
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
         IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
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

    void register_event_proxies()
   {
      evt_CreatedEvt_delegate = new Efl.EventCb(on_CreatedEvt_NativeCallback);
   }
   /// <summary>Create a UI object from the necessary properties in the specified model.</summary>
   /// <param name="model">Efl model</param>
   /// <param name="parent">Efl canvas</param>
   /// <returns>Created UI object</returns>
   public  Eina.Future Create( Efl.Model model,  Efl.Gfx.Entity parent) {
                                           var _ret_var = Efl.Ui.FactoryNativeInherit.efl_ui_factory_create_ptr.Value.Delegate(this.NativeHandle, model,  parent);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }
   /// <summary>Release a UI object and disconnect from models.</summary>
   /// <param name="ui_view">Efl canvas</param>
   /// <returns></returns>
   public  void Release( Efl.Gfx.Entity ui_view) {
                         Efl.Ui.FactoryNativeInherit.efl_ui_factory_release_ptr.Value.Delegate(this.NativeHandle, ui_view);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>bind the factory with the given key string. when the data is ready or changed, factory create the object and bind the data to the key action and process promised work. Note: the input <see cref="Efl.Ui.Factory"/> need to be <see cref="Efl.Ui.PropertyBind.PropertyBind"/> at least once.</summary>
   /// <param name="key">Key string for bind model property data</param>
   /// <param name="factory"><see cref="Efl.Ui.Factory"/> for create and bind model property data</param>
   /// <returns></returns>
   public  void FactoryBind(  System.String key,  Efl.Ui.Factory factory) {
                                           Efl.Ui.FactoryBindNativeInherit.efl_ui_factory_bind_ptr.Value.Delegate(this.NativeHandle, key,  factory);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>bind property data with the given key string. when the data is ready or changed, bind the data to the key action and process promised work.</summary>
   /// <param name="key">key string for bind model property data</param>
   /// <param name="property">Model property name</param>
   /// <returns></returns>
   public  void PropertyBind(  System.String key,   System.String property) {
                                           Efl.Ui.PropertyBindNativeInherit.efl_ui_property_bind_ptr.Value.Delegate(this.NativeHandle, key,  property);
      Eina.Error.RaiseIfUnhandledException();
                               }
   public System.Threading.Tasks.Task<Eina.Value> CreateAsync( Efl.Model model, Efl.Gfx.Entity parent, System.Threading.CancellationToken token=default(System.Threading.CancellationToken))
   {
      Eina.Future future = Create(  model,  parent);
      return Efl.Eo.Globals.WrapAsync(future, token);
   }
}
public class FactoryNativeInherit  : Efl.Eo.NativeClass{
   public  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Efl);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
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
            _ret_var = ((Factory)wrapper).Create( model,  parent);
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
            ((Factory)wrapper).Release( ui_view);
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
            ((Factory)wrapper).FactoryBind( key,  factory);
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
            ((Factory)wrapper).PropertyBind( key,  property);
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
