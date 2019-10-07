#define EFL_BETA
#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Ui {

/// <summary>Efl UI Property_Bind interface. view object can have <see cref="Efl.IModel"/> to manage the data, the interface can help loading and tracking child data from the model property. see <see cref="Efl.IModel"/> see <see cref="Efl.Ui.IFactory"/></summary>
/// <since_tizen> 6 </since_tizen>
[Efl.Ui.PropertyBindConcrete.NativeMethods]
[Efl.Eo.BindingEntity]
public interface IPropertyBind : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>bind property data with the given key string. when the data is ready or changed, bind the data to the key action and process promised work.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="key">key string for bind model property data</param>
    /// <param name="property">Model property name</param>
    /// <returns>0 when it succeed, an error code otherwise.</returns>
    Eina.Error BindProperty(System.String key, System.String property);

    /// <summary>Event dispatched when a property on the object has changed due to a user interaction on the object that a model could be interested in.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="Efl.Ui.PropertyBindPropertiesChangedEventArgs"/></value>
    event EventHandler<Efl.Ui.PropertyBindPropertiesChangedEventArgs> PropertiesChangedEvent;
    /// <summary>Event dispatched when a property on the object is bound to a model. This is useful to avoid generating too many events.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="Efl.Ui.PropertyBindPropertyBoundEventArgs"/></value>
    event EventHandler<Efl.Ui.PropertyBindPropertyBoundEventArgs> PropertyBoundEvent;
}

/// <summary>Event argument wrapper for event <see cref="Efl.Ui.IPropertyBind.PropertiesChangedEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class PropertyBindPropertiesChangedEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Event dispatched when a property on the object has changed due to a user interaction on the object that a model could be interested in.</value>
    public Efl.Ui.PropertyEvent arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="Efl.Ui.IPropertyBind.PropertyBoundEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class PropertyBindPropertyBoundEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Event dispatched when a property on the object is bound to a model. This is useful to avoid generating too many events.</value>
    public System.String arg { get; set; }
}

/// <summary>Efl UI Property_Bind interface. view object can have <see cref="Efl.IModel"/> to manage the data, the interface can help loading and tracking child data from the model property. see <see cref="Efl.IModel"/> see <see cref="Efl.Ui.IFactory"/></summary>
/// <since_tizen> 6 </since_tizen>
public sealed class PropertyBindConcrete :
    Efl.Eo.EoWrapper
    , IPropertyBind
    
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(PropertyBindConcrete))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    private PropertyBindConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
        efl_ui_property_bind_interface_get();

    /// <summary>Initializes a new instance of the <see cref="IPropertyBind"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private PropertyBindConcrete(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Event dispatched when a property on the object has changed due to a user interaction on the object that a model could be interested in.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="Efl.Ui.PropertyBindPropertiesChangedEventArgs"/></value>
    public event EventHandler<Efl.Ui.PropertyBindPropertiesChangedEventArgs> PropertiesChangedEvent
    {
        add
        {
            lock (eflBindingEventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        Efl.Ui.PropertyBindPropertiesChangedEventArgs args = new Efl.Ui.PropertyBindPropertiesChangedEventArgs();
                        args.arg =  evt.Info;
                        try
                        {
                            value?.Invoke(obj, args);
                        }
                        catch (Exception e)
                        {
                            Eina.Log.Error(e.ToString());
                            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                        }
                    }
                };

                string key = "_EFL_UI_PROPERTY_BIND_EVENT_PROPERTIES_CHANGED";
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_PROPERTY_BIND_EVENT_PROPERTIES_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }

    /// <summary>Method to raise event PropertiesChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnPropertiesChangedEvent(Efl.Ui.PropertyBindPropertiesChangedEventArgs e)
    {
        var key = "_EFL_UI_PROPERTY_BIND_EVENT_PROPERTIES_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = Marshal.AllocHGlobal(Marshal.SizeOf(e.arg));
        try
        {
            Marshal.StructureToPtr(e.arg, info, false);
            Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Marshal.FreeHGlobal(info);
        }
    }

    /// <summary>Event dispatched when a property on the object is bound to a model. This is useful to avoid generating too many events.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="Efl.Ui.PropertyBindPropertyBoundEventArgs"/></value>
    public event EventHandler<Efl.Ui.PropertyBindPropertyBoundEventArgs> PropertyBoundEvent
    {
        add
        {
            lock (eflBindingEventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        Efl.Ui.PropertyBindPropertyBoundEventArgs args = new Efl.Ui.PropertyBindPropertyBoundEventArgs();
                        args.arg = Eina.StringConversion.NativeUtf8ToManagedString(evt.Info);
                        try
                        {
                            value?.Invoke(obj, args);
                        }
                        catch (Exception e)
                        {
                            Eina.Log.Error(e.ToString());
                            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                        }
                    }
                };

                string key = "_EFL_UI_PROPERTY_BIND_EVENT_PROPERTY_BOUND";
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_PROPERTY_BIND_EVENT_PROPERTY_BOUND";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }

    /// <summary>Method to raise event PropertyBoundEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnPropertyBoundEvent(Efl.Ui.PropertyBindPropertyBoundEventArgs e)
    {
        var key = "_EFL_UI_PROPERTY_BIND_EVENT_PROPERTY_BOUND";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = Eina.StringConversion.ManagedStringToNativeUtf8Alloc(e.arg);
        try
        {
            Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Eina.MemoryNative.Free(info);
        }
    }


#pragma warning disable CS0628
    /// <summary>bind property data with the given key string. when the data is ready or changed, bind the data to the key action and process promised work.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="key">key string for bind model property data</param>
    /// <param name="property">Model property name</param>
    /// <returns>0 when it succeed, an error code otherwise.</returns>
    public Eina.Error BindProperty(System.String key, System.String property) {
        var _ret_var = Efl.Ui.PropertyBindConcrete.NativeMethods.efl_ui_property_bind_ptr.Value.Delegate(this.NativeHandle,key, property);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

#pragma warning restore CS0628
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.PropertyBindConcrete.efl_ui_property_bind_interface_get();
    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Eo.EoWrapper.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(efl.Libs.Efl);

        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_ui_property_bind_static_delegate == null)
            {
                efl_ui_property_bind_static_delegate = new efl_ui_property_bind_delegate(property_bind);
            }

            if (methods.FirstOrDefault(m => m.Name == "BindProperty") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_property_bind"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_property_bind_static_delegate) });
            }

            if (includeInherited)
            {
                var all_interfaces = type.GetInterfaces();
                foreach (var iface in all_interfaces)
                {
                    var moredescs = ((Efl.Eo.NativeClass)iface.GetCustomAttributes(false)?.FirstOrDefault(attr => attr is Efl.Eo.NativeClass))?.GetEoOps(type, false);
                    if (moredescs != null)
                        descs.AddRange(moredescs);
                }
            }
            return descs;
        }

        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.PropertyBindConcrete.efl_ui_property_bind_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate Eina.Error efl_ui_property_bind_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String key, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String property);

        
        public delegate Eina.Error efl_ui_property_bind_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String key, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String property);

        public static Efl.Eo.FunctionWrapper<efl_ui_property_bind_api_delegate> efl_ui_property_bind_ptr = new Efl.Eo.FunctionWrapper<efl_ui_property_bind_api_delegate>(Module, "efl_ui_property_bind");

        private static Eina.Error property_bind(System.IntPtr obj, System.IntPtr pd, System.String key, System.String property)
        {
            Eina.Log.Debug("function efl_ui_property_bind was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                Eina.Error _ret_var = default(Eina.Error);
                try
                {
                    _ret_var = ((IPropertyBind)ws.Target).BindProperty(key, property);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_ui_property_bind_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), key, property);
            }
        }

        private static efl_ui_property_bind_delegate efl_ui_property_bind_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}
}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_UiPropertyBindConcrete_ExtensionMethods {
}
#pragma warning restore CS1591
#endif
namespace Efl {

namespace Ui {

/// <summary>EFL Ui property event data structure triggered when an object property change due to the interaction on the object.</summary>
/// <since_tizen> 6 </since_tizen>
[StructLayout(LayoutKind.Sequential)]
[Efl.Eo.BindingEntity]
public struct PropertyEvent
{
    /// <summary>List of changed properties</summary>
    public Eina.Array<Eina.Stringshare> Changed_properties;
    /// <summary>Constructor for PropertyEvent.</summary>
    /// <param name="Changed_properties">List of changed properties</param>
    public PropertyEvent(
        Eina.Array<Eina.Stringshare> Changed_properties = default(Eina.Array<Eina.Stringshare>)    )
    {
        this.Changed_properties = Changed_properties;
    }

    /// <summary>Implicit conversion to the managed representation from a native pointer.</summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator PropertyEvent(IntPtr ptr)
    {
        var tmp = (PropertyEvent.NativeStruct)Marshal.PtrToStructure(ptr, typeof(PropertyEvent.NativeStruct));
        return tmp;
    }

    #pragma warning disable CS1591

    /// <summary>Internal wrapper for struct PropertyEvent.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        
        public System.IntPtr Changed_properties;
        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator PropertyEvent.NativeStruct(PropertyEvent _external_struct)
        {
            var _internal_struct = new PropertyEvent.NativeStruct();
            _internal_struct.Changed_properties = _external_struct.Changed_properties.Handle;
            return _internal_struct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator PropertyEvent(PropertyEvent.NativeStruct _internal_struct)
        {
            var _external_struct = new PropertyEvent();
            _external_struct.Changed_properties = new Eina.Array<Eina.Stringshare>(_internal_struct.Changed_properties, false, false);
            return _external_struct;
        }
    }
    #pragma warning restore CS1591
}

}
}

