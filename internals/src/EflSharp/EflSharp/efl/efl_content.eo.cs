#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { 
/// <summary>Common interface for objects that have a (single) content.
/// This is used for the default content part of widgets, as well as for individual parts through <see cref="Efl.IPart"/>.
/// (Since EFL 1.22)</summary>
[IContentNativeInherit]
public interface IContent : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Swallowed sub-object contained in this object.
/// (Since EFL 1.22)</summary>
/// <returns>The object to swallow.</returns>
Efl.Gfx.IEntity GetContent();
    /// <summary>Swallowed sub-object contained in this object.
/// (Since EFL 1.22)</summary>
/// <param name="content">The object to swallow.</param>
/// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
bool SetContent( Efl.Gfx.IEntity content);
    /// <summary>Unswallow the object in the current container and return it.
/// (Since EFL 1.22)</summary>
/// <returns>Unswallowed object</returns>
Efl.Gfx.IEntity UnsetContent();
                /// <summary>Sent after the content is set or unset using the current content object.
    /// (Since EFL 1.22)</summary>
    event EventHandler<Efl.IContentContentChangedEvt_Args> ContentChangedEvt;
    /// <summary>Swallowed sub-object contained in this object.
/// (Since EFL 1.22)</summary>
/// <value>The object to swallow.</value>
    Efl.Gfx.IEntity Content {
        get ;
        set ;
    }
}
///<summary>Event argument wrapper for event <see cref="Efl.IContent.ContentChangedEvt"/>.</summary>
public class IContentContentChangedEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Efl.Gfx.IEntity arg { get; set; }
}
/// <summary>Common interface for objects that have a (single) content.
/// This is used for the default content part of widgets, as well as for individual parts through <see cref="Efl.IPart"/>.
/// (Since EFL 1.22)</summary>
sealed public class IContentConcrete : 

IContent
    
{
    ///<summary>Pointer to the native class description.</summary>
    public System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (IContentConcrete))
                return Efl.IContentNativeInherit.GetEflClassStatic();
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
        efl_content_interface_get();
    ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    private IContentConcrete(System.IntPtr raw)
    {
        handle = raw;
        RegisterEventProxies();
    }
    ///<summary>Destructor.</summary>
    ~IContentConcrete()
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
private static object ContentChangedEvtKey = new object();
    /// <summary>Sent after the content is set or unset using the current content object.
    /// (Since EFL 1.22)</summary>
    public event EventHandler<Efl.IContentContentChangedEvt_Args> ContentChangedEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_CONTENT_EVENT_CONTENT_CHANGED";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_ContentChangedEvt_delegate)) {
                    eventHandlers.AddHandler(ContentChangedEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_CONTENT_EVENT_CONTENT_CHANGED";
                if (RemoveNativeEventHandler(key, this.evt_ContentChangedEvt_delegate)) { 
                    eventHandlers.RemoveHandler(ContentChangedEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event ContentChangedEvt.</summary>
    public void On_ContentChangedEvt(Efl.IContentContentChangedEvt_Args e)
    {
        EventHandler<Efl.IContentContentChangedEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.IContentContentChangedEvt_Args>)eventHandlers[ContentChangedEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_ContentChangedEvt_delegate;
    private void on_ContentChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.IContentContentChangedEvt_Args args = new Efl.IContentContentChangedEvt_Args();
      args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Gfx.IEntityConcrete);
        try {
            On_ContentChangedEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

    ///<summary>Register the Eo event wrappers making the bridge to C# events. Internal usage only.</summary>
     void RegisterEventProxies()
    {
        evt_ContentChangedEvt_delegate = new Efl.EventCb(on_ContentChangedEvt_NativeCallback);
    }
    /// <summary>Swallowed sub-object contained in this object.
    /// (Since EFL 1.22)</summary>
    /// <returns>The object to swallow.</returns>
    public Efl.Gfx.IEntity GetContent() {
         var _ret_var = Efl.IContentNativeInherit.efl_content_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Swallowed sub-object contained in this object.
    /// (Since EFL 1.22)</summary>
    /// <param name="content">The object to swallow.</param>
    /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
    public bool SetContent( Efl.Gfx.IEntity content) {
                                 var _ret_var = Efl.IContentNativeInherit.efl_content_set_ptr.Value.Delegate(this.NativeHandle, content);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Unswallow the object in the current container and return it.
    /// (Since EFL 1.22)</summary>
    /// <returns>Unswallowed object</returns>
    public Efl.Gfx.IEntity UnsetContent() {
         var _ret_var = Efl.IContentNativeInherit.efl_content_unset_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Swallowed sub-object contained in this object.
/// (Since EFL 1.22)</summary>
/// <value>The object to swallow.</value>
    public Efl.Gfx.IEntity Content {
        get { return GetContent(); }
        set { SetContent( value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.IContentConcrete.efl_content_interface_get();
    }
}
public class IContentNativeInherit  : Efl.Eo.NativeClass{
    public  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Efl);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
        if (efl_content_get_static_delegate == null)
            efl_content_get_static_delegate = new efl_content_get_delegate(content_get);
        if (methods.FirstOrDefault(m => m.Name == "GetContent") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_content_get"), func = Marshal.GetFunctionPointerForDelegate(efl_content_get_static_delegate)});
        if (efl_content_set_static_delegate == null)
            efl_content_set_static_delegate = new efl_content_set_delegate(content_set);
        if (methods.FirstOrDefault(m => m.Name == "SetContent") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_content_set"), func = Marshal.GetFunctionPointerForDelegate(efl_content_set_static_delegate)});
        if (efl_content_unset_static_delegate == null)
            efl_content_unset_static_delegate = new efl_content_unset_delegate(content_unset);
        if (methods.FirstOrDefault(m => m.Name == "UnsetContent") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_content_unset"), func = Marshal.GetFunctionPointerForDelegate(efl_content_unset_static_delegate)});
        return descs;
    }
    public override IntPtr GetEflClass()
    {
        return Efl.IContentConcrete.efl_content_interface_get();
    }
    public static  IntPtr GetEflClassStatic()
    {
        return Efl.IContentConcrete.efl_content_interface_get();
    }


    [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.IEntityConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.Gfx.IEntity efl_content_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.IEntityConcrete, Efl.Eo.NonOwnTag>))] public delegate Efl.Gfx.IEntity efl_content_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_content_get_api_delegate> efl_content_get_ptr = new Efl.Eo.FunctionWrapper<efl_content_get_api_delegate>(_Module, "efl_content_get");
     private static Efl.Gfx.IEntity content_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_content_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Efl.Gfx.IEntity _ret_var = default(Efl.Gfx.IEntity);
            try {
                _ret_var = ((IContent)wrapper).GetContent();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_content_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_content_get_delegate efl_content_get_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_content_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.IEntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.IEntity content);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_content_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.IEntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.IEntity content);
     public static Efl.Eo.FunctionWrapper<efl_content_set_api_delegate> efl_content_set_ptr = new Efl.Eo.FunctionWrapper<efl_content_set_api_delegate>(_Module, "efl_content_set");
     private static bool content_set(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.IEntity content)
    {
        Eina.Log.Debug("function efl_content_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                bool _ret_var = default(bool);
            try {
                _ret_var = ((IContent)wrapper).SetContent( content);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                        return _ret_var;
        } else {
            return efl_content_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  content);
        }
    }
    private static efl_content_set_delegate efl_content_set_static_delegate;


    [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.IEntityConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.Gfx.IEntity efl_content_unset_delegate(System.IntPtr obj, System.IntPtr pd);


    [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.IEntityConcrete, Efl.Eo.NonOwnTag>))] public delegate Efl.Gfx.IEntity efl_content_unset_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_content_unset_api_delegate> efl_content_unset_ptr = new Efl.Eo.FunctionWrapper<efl_content_unset_api_delegate>(_Module, "efl_content_unset");
     private static Efl.Gfx.IEntity content_unset(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_content_unset was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Efl.Gfx.IEntity _ret_var = default(Efl.Gfx.IEntity);
            try {
                _ret_var = ((IContent)wrapper).UnsetContent();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_content_unset_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_content_unset_delegate efl_content_unset_static_delegate;
}
} 
