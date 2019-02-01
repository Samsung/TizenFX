#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { 
/// <summary>Common interface for objects that have multiple contents (sub objects).
/// APIs in this interface deal with containers of multiple sub objects, not with individual parts.</summary>
[ContainerConcreteNativeInherit]
public interface Container : 
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>Unswallow an object from this container.</summary>
/// <param name="content">To be removed content</param>
/// <returns><c>false</c> if <c>content</c> was not a child or can not be removed.</returns>
bool ContentRemove( Efl.Gfx.Entity content);
   /// <summary>Begin iterating over this object&apos;s contents.</summary>
/// <returns>Iterator to object content</returns>
Eina.Iterator<Efl.Gfx.Entity> ContentIterate();
   /// <summary>Returns the number of UI elements packed in this container.</summary>
/// <returns>Number of packed UI elements</returns>
 int ContentCount();
            /// <summary>Sent after a new item was added.</summary>
   event EventHandler<Efl.ContainerContentAddedEvt_Args> ContentAddedEvt;
   /// <summary>Sent after an item was removed, before unref.</summary>
   event EventHandler<Efl.ContainerContentRemovedEvt_Args> ContentRemovedEvt;
}
///<summary>Event argument wrapper for event <see cref="Efl.Container.ContentAddedEvt"/>.</summary>
public class ContainerContentAddedEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public Efl.Gfx.Entity arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Container.ContentRemovedEvt"/>.</summary>
public class ContainerContentRemovedEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public Efl.Gfx.Entity arg { get; set; }
}
/// <summary>Common interface for objects that have multiple contents (sub objects).
/// APIs in this interface deal with containers of multiple sub objects, not with individual parts.</summary>
sealed public class ContainerConcrete : 

Container
   
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (ContainerConcrete))
            return Efl.ContainerConcreteNativeInherit.GetEflClassStatic();
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
      efl_container_interface_get();
   ///<summary>Constructs an instance from a native pointer.</summary>
   public ContainerConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~ContainerConcrete()
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
   public static ContainerConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new ContainerConcrete(obj.NativeHandle);
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
private static object ContentAddedEvtKey = new object();
   /// <summary>Sent after a new item was added.</summary>
   public event EventHandler<Efl.ContainerContentAddedEvt_Args> ContentAddedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_CONTAINER_EVENT_CONTENT_ADDED";
            if (add_cpp_event_handler(key, this.evt_ContentAddedEvt_delegate)) {
               eventHandlers.AddHandler(ContentAddedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_CONTAINER_EVENT_CONTENT_ADDED";
            if (remove_cpp_event_handler(key, this.evt_ContentAddedEvt_delegate)) { 
               eventHandlers.RemoveHandler(ContentAddedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ContentAddedEvt.</summary>
   public void On_ContentAddedEvt(Efl.ContainerContentAddedEvt_Args e)
   {
      EventHandler<Efl.ContainerContentAddedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.ContainerContentAddedEvt_Args>)eventHandlers[ContentAddedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ContentAddedEvt_delegate;
   private void on_ContentAddedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.ContainerContentAddedEvt_Args args = new Efl.ContainerContentAddedEvt_Args();
      args.arg = new Efl.Gfx.EntityConcrete(evt.Info);
      try {
         On_ContentAddedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object ContentRemovedEvtKey = new object();
   /// <summary>Sent after an item was removed, before unref.</summary>
   public event EventHandler<Efl.ContainerContentRemovedEvt_Args> ContentRemovedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_CONTAINER_EVENT_CONTENT_REMOVED";
            if (add_cpp_event_handler(key, this.evt_ContentRemovedEvt_delegate)) {
               eventHandlers.AddHandler(ContentRemovedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_CONTAINER_EVENT_CONTENT_REMOVED";
            if (remove_cpp_event_handler(key, this.evt_ContentRemovedEvt_delegate)) { 
               eventHandlers.RemoveHandler(ContentRemovedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ContentRemovedEvt.</summary>
   public void On_ContentRemovedEvt(Efl.ContainerContentRemovedEvt_Args e)
   {
      EventHandler<Efl.ContainerContentRemovedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.ContainerContentRemovedEvt_Args>)eventHandlers[ContentRemovedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ContentRemovedEvt_delegate;
   private void on_ContentRemovedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.ContainerContentRemovedEvt_Args args = new Efl.ContainerContentRemovedEvt_Args();
      args.arg = new Efl.Gfx.EntityConcrete(evt.Info);
      try {
         On_ContentRemovedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

    void register_event_proxies()
   {
      evt_ContentAddedEvt_delegate = new Efl.EventCb(on_ContentAddedEvt_NativeCallback);
      evt_ContentRemovedEvt_delegate = new Efl.EventCb(on_ContentRemovedEvt_NativeCallback);
   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_content_remove(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity content);
   /// <summary>Unswallow an object from this container.</summary>
   /// <param name="content">To be removed content</param>
   /// <returns><c>false</c> if <c>content</c> was not a child or can not be removed.</returns>
   public bool ContentRemove( Efl.Gfx.Entity content) {
                         var _ret_var = efl_content_remove(Efl.ContainerConcrete.efl_container_interface_get(),  content);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  System.IntPtr efl_content_iterate(System.IntPtr obj);
   /// <summary>Begin iterating over this object&apos;s contents.</summary>
   /// <returns>Iterator to object content</returns>
   public Eina.Iterator<Efl.Gfx.Entity> ContentIterate() {
       var _ret_var = efl_content_iterate(Efl.ContainerConcrete.efl_container_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return new Eina.Iterator<Efl.Gfx.Entity>(_ret_var, true, false);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  int efl_content_count(System.IntPtr obj);
   /// <summary>Returns the number of UI elements packed in this container.</summary>
   /// <returns>Number of packed UI elements</returns>
   public  int ContentCount() {
       var _ret_var = efl_content_count(Efl.ContainerConcrete.efl_container_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
}
public class ContainerConcreteNativeInherit : Efl.Eo.NativeClass{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_content_remove_static_delegate = new efl_content_remove_delegate(content_remove);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_content_remove"), func = Marshal.GetFunctionPointerForDelegate(efl_content_remove_static_delegate)});
      efl_content_iterate_static_delegate = new efl_content_iterate_delegate(content_iterate);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_content_iterate"), func = Marshal.GetFunctionPointerForDelegate(efl_content_iterate_static_delegate)});
      efl_content_count_static_delegate = new efl_content_count_delegate(content_count);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_content_count"), func = Marshal.GetFunctionPointerForDelegate(efl_content_count_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.ContainerConcrete.efl_container_interface_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.ContainerConcrete.efl_container_interface_get();
   }


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_content_remove_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity content);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_content_remove(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity content);
    private static bool content_remove(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.Entity content)
   {
      Eina.Log.Debug("function efl_content_remove was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((Container)wrapper).ContentRemove( content);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_content_remove(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  content);
      }
   }
   private efl_content_remove_delegate efl_content_remove_static_delegate;


    private delegate  System.IntPtr efl_content_iterate_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  System.IntPtr efl_content_iterate(System.IntPtr obj);
    private static  System.IntPtr content_iterate(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_content_iterate was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Iterator<Efl.Gfx.Entity> _ret_var = default(Eina.Iterator<Efl.Gfx.Entity>);
         try {
            _ret_var = ((Container)wrapper).ContentIterate();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      _ret_var.Own = false; return _ret_var.Handle;
      } else {
         return efl_content_iterate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_content_iterate_delegate efl_content_iterate_static_delegate;


    private delegate  int efl_content_count_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  int efl_content_count(System.IntPtr obj);
    private static  int content_count(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_content_count was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   int _ret_var = default( int);
         try {
            _ret_var = ((Container)wrapper).ContentCount();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_content_count(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_content_count_delegate efl_content_count_static_delegate;
}
} 
