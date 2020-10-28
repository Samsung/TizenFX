#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { 
/// <summary>Common interface for objects that have multiple contents (sub objects).
/// APIs in this interface deal with containers of multiple sub objects, not with individual parts.
/// (Since EFL 1.22)</summary>
[IContainerNativeInherit]
public interface IContainer : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Begin iterating over this object&apos;s contents.
/// (Since EFL 1.22)</summary>
/// <returns>Iterator to object content</returns>
Eina.Iterator<Efl.Gfx.IEntity> ContentIterate();
    /// <summary>Returns the number of UI elements packed in this container.
/// (Since EFL 1.22)</summary>
/// <returns>Number of packed UI elements</returns>
int ContentCount();
            /// <summary>Sent after a new item was added.
    /// (Since EFL 1.22)</summary>
    event EventHandler<Efl.IContainerContentAddedEvt_Args> ContentAddedEvt;
    /// <summary>Sent after an item was removed, before unref.
    /// (Since EFL 1.22)</summary>
    event EventHandler<Efl.IContainerContentRemovedEvt_Args> ContentRemovedEvt;
}
///<summary>Event argument wrapper for event <see cref="Efl.IContainer.ContentAddedEvt"/>.</summary>
public class IContainerContentAddedEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Efl.Gfx.IEntity arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.IContainer.ContentRemovedEvt"/>.</summary>
public class IContainerContentRemovedEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Efl.Gfx.IEntity arg { get; set; }
}
/// <summary>Common interface for objects that have multiple contents (sub objects).
/// APIs in this interface deal with containers of multiple sub objects, not with individual parts.
/// (Since EFL 1.22)</summary>
sealed public class IContainerConcrete : 

IContainer
    
{
    ///<summary>Pointer to the native class description.</summary>
    public System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (IContainerConcrete))
                return Efl.IContainerNativeInherit.GetEflClassStatic();
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
        efl_container_interface_get();
    ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    private IContainerConcrete(System.IntPtr raw)
    {
        handle = raw;
        RegisterEventProxies();
    }
    ///<summary>Destructor.</summary>
    ~IContainerConcrete()
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
    ///<summary>Adds a new event handler, registering it to the native event. For internal use only.</summary>
    ///<param name="lib">The name of the native library definining the event.</param>
    ///<param name="key">The name of the native event.</param>
    ///<param name="evt_delegate">The delegate to be called on event raising.</param>
    ///<returns>True if the delegate was successfully registered.</returns>
    private bool AddNativeEventHandler(string lib, string key, Efl.EventCb evt_delegate) {
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
    ///<summary>Removes the given event handler for the given event. For internal use only.</summary>
    ///<param name="key">The name of the native event.</param>
    ///<param name="evt_delegate">The delegate to be removed.</param>
    ///<returns>True if the delegate was successfully registered.</returns>
    private bool RemoveNativeEventHandler(string key, Efl.EventCb evt_delegate) {
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
private static object ContentAddedEvtKey = new object();
    /// <summary>Sent after a new item was added.
    /// (Since EFL 1.22)</summary>
    public event EventHandler<Efl.IContainerContentAddedEvt_Args> ContentAddedEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_CONTAINER_EVENT_CONTENT_ADDED";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_ContentAddedEvt_delegate)) {
                    eventHandlers.AddHandler(ContentAddedEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_CONTAINER_EVENT_CONTENT_ADDED";
                if (RemoveNativeEventHandler(key, this.evt_ContentAddedEvt_delegate)) { 
                    eventHandlers.RemoveHandler(ContentAddedEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event ContentAddedEvt.</summary>
    public void On_ContentAddedEvt(Efl.IContainerContentAddedEvt_Args e)
    {
        EventHandler<Efl.IContainerContentAddedEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.IContainerContentAddedEvt_Args>)eventHandlers[ContentAddedEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_ContentAddedEvt_delegate;
    private void on_ContentAddedEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.IContainerContentAddedEvt_Args args = new Efl.IContainerContentAddedEvt_Args();
      args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Gfx.IEntityConcrete);
        try {
            On_ContentAddedEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object ContentRemovedEvtKey = new object();
    /// <summary>Sent after an item was removed, before unref.
    /// (Since EFL 1.22)</summary>
    public event EventHandler<Efl.IContainerContentRemovedEvt_Args> ContentRemovedEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_CONTAINER_EVENT_CONTENT_REMOVED";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_ContentRemovedEvt_delegate)) {
                    eventHandlers.AddHandler(ContentRemovedEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_CONTAINER_EVENT_CONTENT_REMOVED";
                if (RemoveNativeEventHandler(key, this.evt_ContentRemovedEvt_delegate)) { 
                    eventHandlers.RemoveHandler(ContentRemovedEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event ContentRemovedEvt.</summary>
    public void On_ContentRemovedEvt(Efl.IContainerContentRemovedEvt_Args e)
    {
        EventHandler<Efl.IContainerContentRemovedEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.IContainerContentRemovedEvt_Args>)eventHandlers[ContentRemovedEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_ContentRemovedEvt_delegate;
    private void on_ContentRemovedEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.IContainerContentRemovedEvt_Args args = new Efl.IContainerContentRemovedEvt_Args();
      args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Gfx.IEntityConcrete);
        try {
            On_ContentRemovedEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

    ///<summary>Register the Eo event wrappers making the bridge to C# events. Internal usage only.</summary>
     void RegisterEventProxies()
    {
        evt_ContentAddedEvt_delegate = new Efl.EventCb(on_ContentAddedEvt_NativeCallback);
        evt_ContentRemovedEvt_delegate = new Efl.EventCb(on_ContentRemovedEvt_NativeCallback);
    }
    /// <summary>Begin iterating over this object&apos;s contents.
    /// (Since EFL 1.22)</summary>
    /// <returns>Iterator to object content</returns>
    public Eina.Iterator<Efl.Gfx.IEntity> ContentIterate() {
         var _ret_var = Efl.IContainerNativeInherit.efl_content_iterate_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return new Eina.Iterator<Efl.Gfx.IEntity>(_ret_var, true, false);
 }
    /// <summary>Returns the number of UI elements packed in this container.
    /// (Since EFL 1.22)</summary>
    /// <returns>Number of packed UI elements</returns>
    public int ContentCount() {
         var _ret_var = Efl.IContainerNativeInherit.efl_content_count_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.IContainerConcrete.efl_container_interface_get();
    }
}
public class IContainerNativeInherit  : Efl.Eo.NativeClass{
    public  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Efl);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
        if (efl_content_iterate_static_delegate == null)
            efl_content_iterate_static_delegate = new efl_content_iterate_delegate(content_iterate);
        if (methods.FirstOrDefault(m => m.Name == "ContentIterate") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_content_iterate"), func = Marshal.GetFunctionPointerForDelegate(efl_content_iterate_static_delegate)});
        if (efl_content_count_static_delegate == null)
            efl_content_count_static_delegate = new efl_content_count_delegate(content_count);
        if (methods.FirstOrDefault(m => m.Name == "ContentCount") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_content_count"), func = Marshal.GetFunctionPointerForDelegate(efl_content_count_static_delegate)});
        return descs;
    }
    public override IntPtr GetEflClass()
    {
        return Efl.IContainerConcrete.efl_container_interface_get();
    }
    public static  IntPtr GetEflClassStatic()
    {
        return Efl.IContainerConcrete.efl_container_interface_get();
    }


     private delegate System.IntPtr efl_content_iterate_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate System.IntPtr efl_content_iterate_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_content_iterate_api_delegate> efl_content_iterate_ptr = new Efl.Eo.FunctionWrapper<efl_content_iterate_api_delegate>(_Module, "efl_content_iterate");
     private static System.IntPtr content_iterate(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_content_iterate was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Eina.Iterator<Efl.Gfx.IEntity> _ret_var = default(Eina.Iterator<Efl.Gfx.IEntity>);
            try {
                _ret_var = ((IContainer)wrapper).ContentIterate();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        _ret_var.Own = false; return _ret_var.Handle;
        } else {
            return efl_content_iterate_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_content_iterate_delegate efl_content_iterate_static_delegate;


     private delegate int efl_content_count_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate int efl_content_count_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_content_count_api_delegate> efl_content_count_ptr = new Efl.Eo.FunctionWrapper<efl_content_count_api_delegate>(_Module, "efl_content_count");
     private static int content_count(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_content_count was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        int _ret_var = default(int);
            try {
                _ret_var = ((IContainer)wrapper).ContentCount();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_content_count_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_content_count_delegate efl_content_count_static_delegate;
}
} 
