#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary>Efl UI Property_Bind interface. view object can have <see cref="Efl.IModel"/> to manage the data, the interface can help loading and tracking child data from the model property. see <see cref="Efl.IModel"/> see <see cref="Efl.Ui.IFactory"/></summary>
[IPropertyBindNativeInherit]
public interface IPropertyBind : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>bind property data with the given key string. when the data is ready or changed, bind the data to the key action and process promised work.</summary>
/// <param name="key">key string for bind model property data</param>
/// <param name="property">Model property name</param>
/// <returns>0 when it succeed, an error code otherwise.</returns>
Eina.Error PropertyBind( System.String key,  System.String property);
        /// <summary>Event dispatched when a property on the object has changed due to an user interaction on the object that a model could be interested in.</summary>
    event EventHandler<Efl.Ui.IPropertyBindPropertiesChangedEvt_Args> PropertiesChangedEvt;
    /// <summary>Event dispatched when a property on the object is bound to a model. This is useful to not overgenerate event.</summary>
    event EventHandler<Efl.Ui.IPropertyBindPropertyBoundEvt_Args> PropertyBoundEvt;
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.IPropertyBind.PropertiesChangedEvt"/>.</summary>
public class IPropertyBindPropertiesChangedEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Efl.Ui.PropertyEvent arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.IPropertyBind.PropertyBoundEvt"/>.</summary>
public class IPropertyBindPropertyBoundEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public System.String arg { get; set; }
}
/// <summary>Efl UI Property_Bind interface. view object can have <see cref="Efl.IModel"/> to manage the data, the interface can help loading and tracking child data from the model property. see <see cref="Efl.IModel"/> see <see cref="Efl.Ui.IFactory"/></summary>
sealed public class IPropertyBindConcrete : 

IPropertyBind
    
{
    ///<summary>Pointer to the native class description.</summary>
    public System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (IPropertyBindConcrete))
                return Efl.Ui.IPropertyBindNativeInherit.GetEflClassStatic();
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
        efl_ui_property_bind_interface_get();
    ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    private IPropertyBindConcrete(System.IntPtr raw)
    {
        handle = raw;
        RegisterEventProxies();
    }
    ///<summary>Destructor.</summary>
    ~IPropertyBindConcrete()
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
private static object PropertiesChangedEvtKey = new object();
    /// <summary>Event dispatched when a property on the object has changed due to an user interaction on the object that a model could be interested in.</summary>
    public event EventHandler<Efl.Ui.IPropertyBindPropertiesChangedEvt_Args> PropertiesChangedEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_PROPERTY_BIND_EVENT_PROPERTIES_CHANGED";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_PropertiesChangedEvt_delegate)) {
                    eventHandlers.AddHandler(PropertiesChangedEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_PROPERTY_BIND_EVENT_PROPERTIES_CHANGED";
                if (RemoveNativeEventHandler(key, this.evt_PropertiesChangedEvt_delegate)) { 
                    eventHandlers.RemoveHandler(PropertiesChangedEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event PropertiesChangedEvt.</summary>
    public void On_PropertiesChangedEvt(Efl.Ui.IPropertyBindPropertiesChangedEvt_Args e)
    {
        EventHandler<Efl.Ui.IPropertyBindPropertiesChangedEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.Ui.IPropertyBindPropertiesChangedEvt_Args>)eventHandlers[PropertiesChangedEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_PropertiesChangedEvt_delegate;
    private void on_PropertiesChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.Ui.IPropertyBindPropertiesChangedEvt_Args args = new Efl.Ui.IPropertyBindPropertiesChangedEvt_Args();
      args.arg =  evt.Info;;
        try {
            On_PropertiesChangedEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object PropertyBoundEvtKey = new object();
    /// <summary>Event dispatched when a property on the object is bound to a model. This is useful to not overgenerate event.</summary>
    public event EventHandler<Efl.Ui.IPropertyBindPropertyBoundEvt_Args> PropertyBoundEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_PROPERTY_BIND_EVENT_PROPERTY_BOUND";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_PropertyBoundEvt_delegate)) {
                    eventHandlers.AddHandler(PropertyBoundEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_PROPERTY_BIND_EVENT_PROPERTY_BOUND";
                if (RemoveNativeEventHandler(key, this.evt_PropertyBoundEvt_delegate)) { 
                    eventHandlers.RemoveHandler(PropertyBoundEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event PropertyBoundEvt.</summary>
    public void On_PropertyBoundEvt(Efl.Ui.IPropertyBindPropertyBoundEvt_Args e)
    {
        EventHandler<Efl.Ui.IPropertyBindPropertyBoundEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.Ui.IPropertyBindPropertyBoundEvt_Args>)eventHandlers[PropertyBoundEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_PropertyBoundEvt_delegate;
    private void on_PropertyBoundEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.Ui.IPropertyBindPropertyBoundEvt_Args args = new Efl.Ui.IPropertyBindPropertyBoundEvt_Args();
      args.arg = Eina.StringConversion.NativeUtf8ToManagedString(evt.Info);
        try {
            On_PropertyBoundEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

    ///<summary>Register the Eo event wrappers making the bridge to C# events. Internal usage only.</summary>
     void RegisterEventProxies()
    {
        evt_PropertiesChangedEvt_delegate = new Efl.EventCb(on_PropertiesChangedEvt_NativeCallback);
        evt_PropertyBoundEvt_delegate = new Efl.EventCb(on_PropertyBoundEvt_NativeCallback);
    }
    /// <summary>bind property data with the given key string. when the data is ready or changed, bind the data to the key action and process promised work.</summary>
    /// <param name="key">key string for bind model property data</param>
    /// <param name="property">Model property name</param>
    /// <returns>0 when it succeed, an error code otherwise.</returns>
    public Eina.Error PropertyBind( System.String key,  System.String property) {
                                                         var _ret_var = Efl.Ui.IPropertyBindNativeInherit.efl_ui_property_bind_ptr.Value.Delegate(this.NativeHandle, key,  property);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.IPropertyBindConcrete.efl_ui_property_bind_interface_get();
    }
}
public class IPropertyBindNativeInherit  : Efl.Eo.NativeClass{
    public  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Efl);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
        if (efl_ui_property_bind_static_delegate == null)
            efl_ui_property_bind_static_delegate = new efl_ui_property_bind_delegate(property_bind);
        if (methods.FirstOrDefault(m => m.Name == "PropertyBind") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_property_bind"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_property_bind_static_delegate)});
        return descs;
    }
    public override IntPtr GetEflClass()
    {
        return Efl.Ui.IPropertyBindConcrete.efl_ui_property_bind_interface_get();
    }
    public static  IntPtr GetEflClassStatic()
    {
        return Efl.Ui.IPropertyBindConcrete.efl_ui_property_bind_interface_get();
    }


     private delegate Eina.Error efl_ui_property_bind_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String key,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String property);


     public delegate Eina.Error efl_ui_property_bind_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String key,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String property);
     public static Efl.Eo.FunctionWrapper<efl_ui_property_bind_api_delegate> efl_ui_property_bind_ptr = new Efl.Eo.FunctionWrapper<efl_ui_property_bind_api_delegate>(_Module, "efl_ui_property_bind");
     private static Eina.Error property_bind(System.IntPtr obj, System.IntPtr pd,  System.String key,  System.String property)
    {
        Eina.Log.Debug("function efl_ui_property_bind was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                        Eina.Error _ret_var = default(Eina.Error);
            try {
                _ret_var = ((IPropertyBind)wrapper).PropertyBind( key,  property);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                        return _ret_var;
        } else {
            return efl_ui_property_bind_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  key,  property);
        }
    }
    private static efl_ui_property_bind_delegate efl_ui_property_bind_static_delegate;
}
} } 
namespace Efl { namespace Ui { 
/// <summary>EFL Ui property event data structure triggered when an object property change due to the interaction on the object.</summary>
[StructLayout(LayoutKind.Sequential)]
public struct PropertyEvent
{
    /// <summary>List of changed properties</summary>
    public Eina.Array<System.String> Changed_properties;
    ///<summary>Constructor for PropertyEvent.</summary>
    public PropertyEvent(
        Eina.Array<System.String> Changed_properties=default(Eina.Array<System.String>)    )
    {
        this.Changed_properties = Changed_properties;
    }

    public static implicit operator PropertyEvent(IntPtr ptr)
    {
        var tmp = (PropertyEvent.NativeStruct)Marshal.PtrToStructure(ptr, typeof(PropertyEvent.NativeStruct));
        return tmp;
    }

    ///<summary>Internal wrapper for struct PropertyEvent.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        
        public System.IntPtr Changed_properties;
        ///<summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator PropertyEvent.NativeStruct(PropertyEvent _external_struct)
        {
            var _internal_struct = new PropertyEvent.NativeStruct();
            _internal_struct.Changed_properties = _external_struct.Changed_properties.Handle;
            return _internal_struct;
        }

        ///<summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator PropertyEvent(PropertyEvent.NativeStruct _internal_struct)
        {
            var _external_struct = new PropertyEvent();
            _external_struct.Changed_properties = new Eina.Array<System.String>(_internal_struct.Changed_properties, false, false);
            return _external_struct;
        }

    }

}

} } 
