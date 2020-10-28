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

/// <summary>Efl UI factory interface</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Ui.IFactoryConcrete.NativeMethods]
[Efl.Eo.BindingEntity]
public interface IFactory : 
    Efl.Ui.IFactoryBind ,
    Efl.Ui.IPropertyBind ,
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Create a UI object from the necessary properties in the specified model.
/// Note: This is the function you need to implement for a custom factory, but if you want to use a factory, you should rely on <see cref="Efl.Ui.ViewFactory.CreateWithEvent"/>.</summary>
/// <param name="models">Efl iterator providing the model to be associated to the new item. It should remain valid until the end of the function call.</param>
/// <param name="parent">Efl canvas</param>
/// <returns>Created UI object</returns>
 Eina.Future Create(Eina.Iterator<Efl.IModel> models, Efl.Gfx.IEntity parent);
    /// <summary>Release a UI object and disconnect from models.</summary>
/// <param name="ui_view">Efl canvas</param>
void Release(Efl.Gfx.IEntity ui_view);
    /// <summary>This function is called during the creation of an UI object between the Efl.Object.constructor and <see cref="Efl.Object.FinalizeAdd"/> call.
/// Note: if the <see cref="Efl.Ui.IFactory"/> does keep a cache of object, this won&apos;t be called when object are pulled out of the cache.</summary>
/// <param name="ui_view">The UI object being created.</param>
void Building(Efl.Gfx.IEntity ui_view);
        /// <summary>Async wrapper for <see cref="Create" />.</summary>
    /// <param name="models">Efl iterator providing the model to be associated to the new item. It should remain valid until the end of the function call.</param>
    /// <param name="parent">Efl canvas</param>
    /// <param name="token">Token to notify the async operation of external request to cancel.</param>
    /// <returns>An async task wrapping the result of the operation.</returns>
    System.Threading.Tasks.Task<Eina.Value> CreateAsync(Eina.Iterator<Efl.IModel> models,Efl.Gfx.IEntity parent, System.Threading.CancellationToken token = default(System.Threading.CancellationToken));

            /// <summary>Event triggered when an item has been successfully created.</summary>
    /// <value><see cref="Efl.Ui.IFactoryCreatedEvt_Args"/></value>
    event EventHandler<Efl.Ui.IFactoryCreatedEvt_Args> CreatedEvt;
}
/// <summary>Event argument wrapper for event <see cref="Efl.Ui.IFactory.CreatedEvt"/>.</summary>
[Efl.Eo.BindingEntity]
public class IFactoryCreatedEvt_Args : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Event triggered when an item has been successfully created.</value>
    public Efl.Ui.FactoryItemCreatedEvent arg { get; set; }
}
/// <summary>Efl UI factory interface</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
sealed public  class IFactoryConcrete :
    Efl.Eo.EoWrapper
    , IFactory
    , Efl.Ui.IFactoryBind, Efl.Ui.IPropertyBind
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(IFactoryConcrete))
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
    private IFactoryConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
        efl_ui_factory_interface_get();
    /// <summary>Initializes a new instance of the <see cref="IFactory"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private IFactoryConcrete(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Event triggered when an item has been successfully created.</summary>
    /// <value><see cref="Efl.Ui.IFactoryCreatedEvt_Args"/></value>
    public event EventHandler<Efl.Ui.IFactoryCreatedEvt_Args> CreatedEvt
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
                        Efl.Ui.IFactoryCreatedEvt_Args args = new Efl.Ui.IFactoryCreatedEvt_Args();
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

                string key = "_EFL_UI_FACTORY_EVENT_CREATED";
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_FACTORY_EVENT_CREATED";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    /// <summary>Method to raise event CreatedEvt.</summary>
    public void OnCreatedEvt(Efl.Ui.IFactoryCreatedEvt_Args e)
    {
        var key = "_EFL_UI_FACTORY_EVENT_CREATED";
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
    /// <summary>Event dispatched when a property on the object has changed due to an user interaction on the object that a model could be interested in.</summary>
    /// <value><see cref="Efl.Ui.IPropertyBindPropertiesChangedEvt_Args"/></value>
    public event EventHandler<Efl.Ui.IPropertyBindPropertiesChangedEvt_Args> PropertiesChangedEvt
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
                        Efl.Ui.IPropertyBindPropertiesChangedEvt_Args args = new Efl.Ui.IPropertyBindPropertiesChangedEvt_Args();
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
    /// <summary>Method to raise event PropertiesChangedEvt.</summary>
    public void OnPropertiesChangedEvt(Efl.Ui.IPropertyBindPropertiesChangedEvt_Args e)
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
    /// <summary>Event dispatched when a property on the object is bound to a model. This is useful to not overgenerate event.</summary>
    /// <value><see cref="Efl.Ui.IPropertyBindPropertyBoundEvt_Args"/></value>
    public event EventHandler<Efl.Ui.IPropertyBindPropertyBoundEvt_Args> PropertyBoundEvt
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
                        Efl.Ui.IPropertyBindPropertyBoundEvt_Args args = new Efl.Ui.IPropertyBindPropertyBoundEvt_Args();
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
    /// <summary>Method to raise event PropertyBoundEvt.</summary>
    public void OnPropertyBoundEvt(Efl.Ui.IPropertyBindPropertyBoundEvt_Args e)
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
    /// <summary>Create a UI object from the necessary properties in the specified model.
    /// Note: This is the function you need to implement for a custom factory, but if you want to use a factory, you should rely on <see cref="Efl.Ui.ViewFactory.CreateWithEvent"/>.</summary>
    /// <param name="models">Efl iterator providing the model to be associated to the new item. It should remain valid until the end of the function call.</param>
    /// <param name="parent">Efl canvas</param>
    /// <returns>Created UI object</returns>
    public  Eina.Future Create(Eina.Iterator<Efl.IModel> models, Efl.Gfx.IEntity parent) {
         var _in_models = models.Handle;
                                                var _ret_var = Efl.Ui.IFactoryConcrete.NativeMethods.efl_ui_factory_create_ptr.Value.Delegate(this.NativeHandle,_in_models, parent);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Release a UI object and disconnect from models.</summary>
    /// <param name="ui_view">Efl canvas</param>
    public void Release(Efl.Gfx.IEntity ui_view) {
                                 Efl.Ui.IFactoryConcrete.NativeMethods.efl_ui_factory_release_ptr.Value.Delegate(this.NativeHandle,ui_view);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>This function is called during the creation of an UI object between the Efl.Object.constructor and <see cref="Efl.Object.FinalizeAdd"/> call.
    /// Note: if the <see cref="Efl.Ui.IFactory"/> does keep a cache of object, this won&apos;t be called when object are pulled out of the cache.</summary>
    /// <param name="ui_view">The UI object being created.</param>
    public void Building(Efl.Gfx.IEntity ui_view) {
                                 Efl.Ui.IFactoryConcrete.NativeMethods.efl_ui_factory_building_ptr.Value.Delegate(this.NativeHandle,ui_view);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>bind the factory with the given key string. when the data is ready or changed, factory create the object and bind the data to the key action and process promised work. Note: the input <see cref="Efl.Ui.IFactory"/> need to be <see cref="Efl.Ui.IPropertyBind.PropertyBind"/> at least once.</summary>
    /// <param name="key">Key string for bind model property data</param>
    /// <param name="factory"><see cref="Efl.Ui.IFactory"/> for create and bind model property data</param>
    public void FactoryBind(System.String key, Efl.Ui.IFactory factory) {
                                                         Efl.Ui.IFactoryBindConcrete.NativeMethods.efl_ui_factory_bind_ptr.Value.Delegate(this.NativeHandle,key, factory);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>bind property data with the given key string. when the data is ready or changed, bind the data to the key action and process promised work.</summary>
    /// <param name="key">key string for bind model property data</param>
    /// <param name="property">Model property name</param>
    /// <returns>0 when it succeed, an error code otherwise.</returns>
    public Eina.Error PropertyBind(System.String key, System.String property) {
                                                         var _ret_var = Efl.Ui.IPropertyBindConcrete.NativeMethods.efl_ui_property_bind_ptr.Value.Delegate(this.NativeHandle,key, property);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Async wrapper for <see cref="Create" />.</summary>
    /// <param name="models">Efl iterator providing the model to be associated to the new item. It should remain valid until the end of the function call.</param>
    /// <param name="parent">Efl canvas</param>
    /// <param name="token">Token to notify the async operation of external request to cancel.</param>
    /// <returns>An async task wrapping the result of the operation.</returns>
    public System.Threading.Tasks.Task<Eina.Value> CreateAsync(Eina.Iterator<Efl.IModel> models,Efl.Gfx.IEntity parent, System.Threading.CancellationToken token = default(System.Threading.CancellationToken))
    {
        Eina.Future future = Create( models, parent);
        return Efl.Eo.Globals.WrapAsync(future, token);
    }

    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.IFactoryConcrete.efl_ui_factory_interface_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Eo.EoWrapper.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Efl);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_ui_factory_create_static_delegate == null)
            {
                efl_ui_factory_create_static_delegate = new efl_ui_factory_create_delegate(create);
            }

            if (methods.FirstOrDefault(m => m.Name == "Create") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_factory_create"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_factory_create_static_delegate) });
            }

            if (efl_ui_factory_release_static_delegate == null)
            {
                efl_ui_factory_release_static_delegate = new efl_ui_factory_release_delegate(release);
            }

            if (methods.FirstOrDefault(m => m.Name == "Release") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_factory_release"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_factory_release_static_delegate) });
            }

            if (efl_ui_factory_building_static_delegate == null)
            {
                efl_ui_factory_building_static_delegate = new efl_ui_factory_building_delegate(building);
            }

            if (methods.FirstOrDefault(m => m.Name == "Building") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_factory_building"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_factory_building_static_delegate) });
            }

            if (efl_ui_factory_bind_static_delegate == null)
            {
                efl_ui_factory_bind_static_delegate = new efl_ui_factory_bind_delegate(factory_bind);
            }

            if (methods.FirstOrDefault(m => m.Name == "FactoryBind") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_factory_bind"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_factory_bind_static_delegate) });
            }

            if (efl_ui_property_bind_static_delegate == null)
            {
                efl_ui_property_bind_static_delegate = new efl_ui_property_bind_delegate(property_bind);
            }

            if (methods.FirstOrDefault(m => m.Name == "PropertyBind") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_property_bind"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_property_bind_static_delegate) });
            }

            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.IFactoryConcrete.efl_ui_factory_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))]
        private delegate  Eina.Future efl_ui_factory_create_delegate(System.IntPtr obj, System.IntPtr pd,  System.IntPtr models, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity parent);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))]
        public delegate  Eina.Future efl_ui_factory_create_api_delegate(System.IntPtr obj,  System.IntPtr models, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity parent);

        public static Efl.Eo.FunctionWrapper<efl_ui_factory_create_api_delegate> efl_ui_factory_create_ptr = new Efl.Eo.FunctionWrapper<efl_ui_factory_create_api_delegate>(Module, "efl_ui_factory_create");

        private static  Eina.Future create(System.IntPtr obj, System.IntPtr pd, System.IntPtr models, Efl.Gfx.IEntity parent)
        {
            Eina.Log.Debug("function efl_ui_factory_create was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        var _in_models = new Eina.Iterator<Efl.IModel>(models, false);
                                                     Eina.Future _ret_var = default( Eina.Future);
                try
                {
                    _ret_var = ((IFactory)ws.Target).Create(_in_models, parent);
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
                return efl_ui_factory_create_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), models, parent);
            }
        }

        private static efl_ui_factory_create_delegate efl_ui_factory_create_static_delegate;

        
        private delegate void efl_ui_factory_release_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity ui_view);

        
        public delegate void efl_ui_factory_release_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity ui_view);

        public static Efl.Eo.FunctionWrapper<efl_ui_factory_release_api_delegate> efl_ui_factory_release_ptr = new Efl.Eo.FunctionWrapper<efl_ui_factory_release_api_delegate>(Module, "efl_ui_factory_release");

        private static void release(System.IntPtr obj, System.IntPtr pd, Efl.Gfx.IEntity ui_view)
        {
            Eina.Log.Debug("function efl_ui_factory_release was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((IFactory)ws.Target).Release(ui_view);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_factory_release_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), ui_view);
            }
        }

        private static efl_ui_factory_release_delegate efl_ui_factory_release_static_delegate;

        
        private delegate void efl_ui_factory_building_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity ui_view);

        
        public delegate void efl_ui_factory_building_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity ui_view);

        public static Efl.Eo.FunctionWrapper<efl_ui_factory_building_api_delegate> efl_ui_factory_building_ptr = new Efl.Eo.FunctionWrapper<efl_ui_factory_building_api_delegate>(Module, "efl_ui_factory_building");

        private static void building(System.IntPtr obj, System.IntPtr pd, Efl.Gfx.IEntity ui_view)
        {
            Eina.Log.Debug("function efl_ui_factory_building was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((IFactory)ws.Target).Building(ui_view);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_factory_building_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), ui_view);
            }
        }

        private static efl_ui_factory_building_delegate efl_ui_factory_building_static_delegate;

        
        private delegate void efl_ui_factory_bind_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String key, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Ui.IFactory factory);

        
        public delegate void efl_ui_factory_bind_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String key, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Ui.IFactory factory);

        public static Efl.Eo.FunctionWrapper<efl_ui_factory_bind_api_delegate> efl_ui_factory_bind_ptr = new Efl.Eo.FunctionWrapper<efl_ui_factory_bind_api_delegate>(Module, "efl_ui_factory_bind");

        private static void factory_bind(System.IntPtr obj, System.IntPtr pd, System.String key, Efl.Ui.IFactory factory)
        {
            Eina.Log.Debug("function efl_ui_factory_bind was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((IFactory)ws.Target).FactoryBind(key, factory);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_factory_bind_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), key, factory);
            }
        }

        private static efl_ui_factory_bind_delegate efl_ui_factory_bind_static_delegate;

        
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
                    _ret_var = ((IFactory)ws.Target).PropertyBind(key, property);
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
public static class Efl_UiIFactoryConcrete_ExtensionMethods {
}
#pragma warning restore CS1591
#endif
namespace Efl {

namespace Ui {

/// <summary>EFL Ui Factory event structure provided when an item was just created.</summary>
[StructLayout(LayoutKind.Sequential)]
[Efl.Eo.BindingEntity]
public struct FactoryItemCreatedEvent
{
    /// <summary>The model already set on the new item.</summary>
    public Efl.IModel Model;
    /// <summary>The item that was just created.</summary>
    public Efl.Gfx.IEntity Item;
    /// <summary>Constructor for FactoryItemCreatedEvent.</summary>
    /// <param name="Model">The model already set on the new item.</param>;
    /// <param name="Item">The item that was just created.</param>;
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

            _external_struct.Model = (Efl.IModelConcrete) Efl.Eo.Globals.CreateWrapperFor(_internal_struct.Model);

            _external_struct.Item = (Efl.Gfx.IEntityConcrete) Efl.Eo.Globals.CreateWrapperFor(_internal_struct.Item);
            return _external_struct;
        }

    }

    #pragma warning restore CS1591

}

}

}

