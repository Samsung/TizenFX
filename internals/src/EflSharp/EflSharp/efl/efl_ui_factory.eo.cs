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

/// <summary>Interface for factory-pattern object creation.
/// This object represents a Factory in the factory pattern. Objects should be created via the method <see cref="Efl.Ui.ViewFactory.CreateWithEvent"/>, which will in turn call the necessary APIs from this interface. Objects created this way should be removed using <see cref="Efl.Ui.IFactory.Release"/>.
/// 
/// It is recommended to not create your own <see cref="Efl.Ui.IFactory"/> and use event handler as much as possible.</summary>
[Efl.Ui.FactoryConcrete.NativeMethods]
[Efl.Eo.BindingEntity]
public interface IFactory : 
    Efl.Ui.IFactoryBind ,
    Efl.Ui.IPropertyBind ,
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Release a UI object and disconnect from models.</summary>
    /// <param name="ui_views">Object to remove.</param>
    void Release(Eina.Iterator<Efl.Gfx.IEntity> ui_views);

    /// <summary>Event triggered when an item is under construction (between the Efl.Object.constructor and <see cref="Efl.Object.FinalizeAdd"/> call on the item). Note:  If the <see cref="Efl.Ui.IFactory"/> does keep a cache of objects, this won&apos;t be called when objects are pulled out of the cache.</summary>
    /// <value><see cref="Efl.Ui.FactoryItemConstructingEventArgs"/></value>
    event EventHandler<Efl.Ui.FactoryItemConstructingEventArgs> ItemConstructingEvent;
    /// <summary>Event triggered when an item has processed <see cref="Efl.Object.FinalizeAdd"/>, but before all the factory are done building it. Note: if the <see cref="Efl.Ui.IFactory"/> does keep a cache of object, this will be called when object are pulled out of the cache.</summary>
    /// <value><see cref="Efl.Ui.FactoryItemBuildingEventArgs"/></value>
    event EventHandler<Efl.Ui.FactoryItemBuildingEventArgs> ItemBuildingEvent;
    /// <summary>Event triggered when an item has been successfully created by the factory and is about to be used by an <see cref="Efl.Ui.IView"/>.</summary>
    /// <value><see cref="Efl.Ui.FactoryItemCreatedEventArgs"/></value>
    event EventHandler<Efl.Ui.FactoryItemCreatedEventArgs> ItemCreatedEvent;
    /// <summary>Event triggered when an item is being released by the <see cref="Efl.Ui.IFactory"/>. It must be assumed that after this call, the object can be recycle to another <see cref="Efl.Ui.IView"/> and there can be more than one call for the same item.</summary>
    /// <value><see cref="Efl.Ui.FactoryItemReleasingEventArgs"/></value>
    event EventHandler<Efl.Ui.FactoryItemReleasingEventArgs> ItemReleasingEvent;
}

/// <summary>Event argument wrapper for event <see cref="Efl.Ui.IFactory.ItemConstructingEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class FactoryItemConstructingEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Event triggered when an item is under construction (between the Efl.Object.constructor and <see cref="Efl.Object.FinalizeAdd"/> call on the item). Note:  If the <see cref="Efl.Ui.IFactory"/> does keep a cache of objects, this won&apos;t be called when objects are pulled out of the cache.</value>
    public Efl.Gfx.IEntity arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="Efl.Ui.IFactory.ItemBuildingEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class FactoryItemBuildingEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Event triggered when an item has processed <see cref="Efl.Object.FinalizeAdd"/>, but before all the factory are done building it. Note: if the <see cref="Efl.Ui.IFactory"/> does keep a cache of object, this will be called when object are pulled out of the cache.</value>
    public Efl.Gfx.IEntity arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="Efl.Ui.IFactory.ItemCreatedEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class FactoryItemCreatedEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Event triggered when an item has been successfully created by the factory and is about to be used by an <see cref="Efl.Ui.IView"/>.</value>
    public Efl.Gfx.IEntity arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="Efl.Ui.IFactory.ItemReleasingEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class FactoryItemReleasingEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Event triggered when an item is being released by the <see cref="Efl.Ui.IFactory"/>. It must be assumed that after this call, the object can be recycle to another <see cref="Efl.Ui.IView"/> and there can be more than one call for the same item.</value>
    public Efl.Gfx.IEntity arg { get; set; }
}

/// <summary>Interface for factory-pattern object creation.
/// This object represents a Factory in the factory pattern. Objects should be created via the method <see cref="Efl.Ui.ViewFactory.CreateWithEvent"/>, which will in turn call the necessary APIs from this interface. Objects created this way should be removed using <see cref="Efl.Ui.IFactory.Release"/>.
/// 
/// It is recommended to not create your own <see cref="Efl.Ui.IFactory"/> and use event handler as much as possible.</summary>
public sealed class FactoryConcrete :
    Efl.Eo.EoWrapper
    , IFactory
    , Efl.Ui.IFactoryBind, Efl.Ui.IPropertyBind
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(FactoryConcrete))
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
    private FactoryConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
        efl_ui_factory_interface_get();

    /// <summary>Initializes a new instance of the <see cref="IFactory"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private FactoryConcrete(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Event triggered when an item is under construction (between the Efl.Object.constructor and <see cref="Efl.Object.FinalizeAdd"/> call on the item). Note:  If the <see cref="Efl.Ui.IFactory"/> does keep a cache of objects, this won&apos;t be called when objects are pulled out of the cache.</summary>
    /// <value><see cref="Efl.Ui.FactoryItemConstructingEventArgs"/></value>
    public event EventHandler<Efl.Ui.FactoryItemConstructingEventArgs> ItemConstructingEvent
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
                        Efl.Ui.FactoryItemConstructingEventArgs args = new Efl.Ui.FactoryItemConstructingEventArgs();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Gfx.EntityConcrete);
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

                string key = "_EFL_UI_FACTORY_EVENT_ITEM_CONSTRUCTING";
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_FACTORY_EVENT_ITEM_CONSTRUCTING";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }

    /// <summary>Method to raise event ItemConstructingEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnItemConstructingEvent(Efl.Ui.FactoryItemConstructingEventArgs e)
    {
        var key = "_EFL_UI_FACTORY_EVENT_ITEM_CONSTRUCTING";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }

    /// <summary>Event triggered when an item has processed <see cref="Efl.Object.FinalizeAdd"/>, but before all the factory are done building it. Note: if the <see cref="Efl.Ui.IFactory"/> does keep a cache of object, this will be called when object are pulled out of the cache.</summary>
    /// <value><see cref="Efl.Ui.FactoryItemBuildingEventArgs"/></value>
    public event EventHandler<Efl.Ui.FactoryItemBuildingEventArgs> ItemBuildingEvent
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
                        Efl.Ui.FactoryItemBuildingEventArgs args = new Efl.Ui.FactoryItemBuildingEventArgs();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Gfx.EntityConcrete);
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

                string key = "_EFL_UI_FACTORY_EVENT_ITEM_BUILDING";
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_FACTORY_EVENT_ITEM_BUILDING";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }

    /// <summary>Method to raise event ItemBuildingEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnItemBuildingEvent(Efl.Ui.FactoryItemBuildingEventArgs e)
    {
        var key = "_EFL_UI_FACTORY_EVENT_ITEM_BUILDING";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }

    /// <summary>Event triggered when an item has been successfully created by the factory and is about to be used by an <see cref="Efl.Ui.IView"/>.</summary>
    /// <value><see cref="Efl.Ui.FactoryItemCreatedEventArgs"/></value>
    public event EventHandler<Efl.Ui.FactoryItemCreatedEventArgs> ItemCreatedEvent
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
                        Efl.Ui.FactoryItemCreatedEventArgs args = new Efl.Ui.FactoryItemCreatedEventArgs();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Gfx.EntityConcrete);
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

                string key = "_EFL_UI_FACTORY_EVENT_ITEM_CREATED";
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_FACTORY_EVENT_ITEM_CREATED";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }

    /// <summary>Method to raise event ItemCreatedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnItemCreatedEvent(Efl.Ui.FactoryItemCreatedEventArgs e)
    {
        var key = "_EFL_UI_FACTORY_EVENT_ITEM_CREATED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }

    /// <summary>Event triggered when an item is being released by the <see cref="Efl.Ui.IFactory"/>. It must be assumed that after this call, the object can be recycle to another <see cref="Efl.Ui.IView"/> and there can be more than one call for the same item.</summary>
    /// <value><see cref="Efl.Ui.FactoryItemReleasingEventArgs"/></value>
    public event EventHandler<Efl.Ui.FactoryItemReleasingEventArgs> ItemReleasingEvent
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
                        Efl.Ui.FactoryItemReleasingEventArgs args = new Efl.Ui.FactoryItemReleasingEventArgs();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Gfx.EntityConcrete);
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

                string key = "_EFL_UI_FACTORY_EVENT_ITEM_RELEASING";
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_FACTORY_EVENT_ITEM_RELEASING";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }

    /// <summary>Method to raise event ItemReleasingEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnItemReleasingEvent(Efl.Ui.FactoryItemReleasingEventArgs e)
    {
        var key = "_EFL_UI_FACTORY_EVENT_ITEM_RELEASING";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
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
    /// <summary>Create a UI object from the necessary properties in the specified model.
    /// Note: This is the function you need to implement for a custom factory, but if you want to use a factory, you should rely on <see cref="Efl.Ui.ViewFactory.CreateWithEvent"/>.</summary>
    /// <param name="models">Efl iterator providing the model to be associated to the new item. It should remain valid until the end of the function call.</param>
    /// <returns>Created UI object.</returns>
    protected  Eina.Future Create(Eina.Iterator<Efl.IModel> models) {
        var _in_models = models.Handle;
models.Own = false;
var _ret_var = Efl.Ui.FactoryConcrete.NativeMethods.efl_ui_factory_create_ptr.Value.Delegate(this.NativeHandle,_in_models);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Release a UI object and disconnect from models.</summary>
    /// <param name="ui_views">Object to remove.</param>
    public void Release(Eina.Iterator<Efl.Gfx.IEntity> ui_views) {
        var _in_ui_views = ui_views.Handle;
ui_views.Own = false;
Efl.Ui.FactoryConcrete.NativeMethods.efl_ui_factory_release_ptr.Value.Delegate(this.NativeHandle,_in_ui_views);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>bind the factory with the given key string. when the data is ready or changed, factory create the object and bind the data to the key action and process promised work. Note: the input <see cref="Efl.Ui.IFactory"/> need to be <see cref="Efl.Ui.IPropertyBind.BindProperty"/> at least once.</summary>
    /// <param name="key">Key string for bind model property data</param>
    /// <param name="factory"><see cref="Efl.Ui.IFactory"/> for create and bind model property data</param>
    /// <returns>0 when it succeed, an error code otherwise.</returns>
    public Eina.Error BindFactory(System.String key, Efl.Ui.IFactory factory) {
        var _ret_var = Efl.Ui.FactoryBindConcrete.NativeMethods.efl_ui_factory_bind_ptr.Value.Delegate(this.NativeHandle,key, factory);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

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

    /// <summary>Async wrapper for <see cref="Create" />.</summary>
    /// <param name="models">Efl iterator providing the model to be associated to the new item. It should remain valid until the end of the function call.</param>
    /// <param name="token">Token to notify the async operation of external request to cancel.</param>
    /// <returns>An async task wrapping the result of the operation.</returns>
    public System.Threading.Tasks.Task<Eina.Value> CreateAsync(Eina.Iterator<Efl.IModel> models, System.Threading.CancellationToken token = default(System.Threading.CancellationToken))
    {
        Eina.Future future = Create( models);
        return Efl.Eo.Globals.WrapAsync(future, token);
    }

#pragma warning restore CS0628
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.FactoryConcrete.efl_ui_factory_interface_get();
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

            if (efl_ui_factory_release_static_delegate == null)
            {
                efl_ui_factory_release_static_delegate = new efl_ui_factory_release_delegate(release);
            }

            if (methods.FirstOrDefault(m => m.Name == "Release") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_factory_release"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_factory_release_static_delegate) });
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
            return Efl.Ui.FactoryConcrete.efl_ui_factory_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))]
        private delegate  Eina.Future efl_ui_factory_create_delegate(System.IntPtr obj, System.IntPtr pd,  System.IntPtr models);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))]
        public delegate  Eina.Future efl_ui_factory_create_api_delegate(System.IntPtr obj,  System.IntPtr models);

        public static Efl.Eo.FunctionWrapper<efl_ui_factory_create_api_delegate> efl_ui_factory_create_ptr = new Efl.Eo.FunctionWrapper<efl_ui_factory_create_api_delegate>(Module, "efl_ui_factory_create");

        
        private delegate void efl_ui_factory_release_delegate(System.IntPtr obj, System.IntPtr pd,  System.IntPtr ui_views);

        
        public delegate void efl_ui_factory_release_api_delegate(System.IntPtr obj,  System.IntPtr ui_views);

        public static Efl.Eo.FunctionWrapper<efl_ui_factory_release_api_delegate> efl_ui_factory_release_ptr = new Efl.Eo.FunctionWrapper<efl_ui_factory_release_api_delegate>(Module, "efl_ui_factory_release");

        private static void release(System.IntPtr obj, System.IntPtr pd, System.IntPtr ui_views)
        {
            Eina.Log.Debug("function efl_ui_factory_release was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                var _in_ui_views = new Eina.Iterator<Efl.Gfx.IEntity>(ui_views, true);

                try
                {
                    ((IFactory)ws.Target).Release(_in_ui_views);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_factory_release_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), ui_views);
            }
        }

        private static efl_ui_factory_release_delegate efl_ui_factory_release_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}
}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_UiFactoryConcrete_ExtensionMethods {
}
#pragma warning restore CS1591
#endif
namespace Efl {

namespace Ui {

/// <summary>EFL UI Factory event structure provided when an item was just created.</summary>
[StructLayout(LayoutKind.Sequential)]
[Efl.Eo.BindingEntity]
public struct FactoryItemCreatedEvent
{
    /// <summary>The model already set on the new item.</summary>
    public Efl.IModel Model;
    /// <summary>The item that was just created.</summary>
    public Efl.Gfx.IEntity Item;
    /// <summary>Constructor for FactoryItemCreatedEvent.</summary>
    /// <param name="Model">The model already set on the new item.</param>
    /// <param name="Item">The item that was just created.</param>
    public FactoryItemCreatedEvent(
        Efl.IModel Model = default(Efl.IModel),
        Efl.Gfx.IEntity Item = default(Efl.Gfx.IEntity)    )
    {
        this.Model = Model;
        this.Item = Item;
    }

    /// <summary>Implicit conversion to the managed representation from a native pointer.</summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator FactoryItemCreatedEvent(IntPtr ptr)
    {
        var tmp = (FactoryItemCreatedEvent.NativeStruct)Marshal.PtrToStructure(ptr, typeof(FactoryItemCreatedEvent.NativeStruct));
        return tmp;
    }

    #pragma warning disable CS1591

    /// <summary>Internal wrapper for struct FactoryItemCreatedEvent.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        /// <summary>Internal wrapper for field Model</summary>
        public System.IntPtr Model;
        /// <summary>Internal wrapper for field Item</summary>
        public System.IntPtr Item;
        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator FactoryItemCreatedEvent.NativeStruct(FactoryItemCreatedEvent _external_struct)
        {
            var _internal_struct = new FactoryItemCreatedEvent.NativeStruct();
            _internal_struct.Model = _external_struct.Model?.NativeHandle ?? System.IntPtr.Zero;
            _internal_struct.Item = _external_struct.Item?.NativeHandle ?? System.IntPtr.Zero;
            return _internal_struct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator FactoryItemCreatedEvent(FactoryItemCreatedEvent.NativeStruct _internal_struct)
        {
            var _external_struct = new FactoryItemCreatedEvent();

            _external_struct.Model = (Efl.ModelConcrete) Efl.Eo.Globals.CreateWrapperFor(_internal_struct.Model);

            _external_struct.Item = (Efl.Gfx.EntityConcrete) Efl.Eo.Globals.CreateWrapperFor(_internal_struct.Item);
            return _external_struct;
        }
    }
    #pragma warning restore CS1591
}

}
}

