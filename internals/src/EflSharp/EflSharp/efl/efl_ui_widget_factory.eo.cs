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

/// <summary>Efl Ui Factory that provides <see cref="Efl.Ui.Widget"/>.
/// This factory is designed to build <see cref="Efl.Ui.Widget"/> and optionally set their <see cref="Efl.Ui.Widget.Style"/> if it was connected with <see cref="Efl.Ui.IPropertyBind.PropertyBind"/> &quot;<c>style</c>&quot;.</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Ui.WidgetFactory.NativeMethods]
[Efl.Eo.BindingEntity]
public class WidgetFactory : Efl.LoopConsumer, Efl.IPart, Efl.Ui.IFactory, Efl.Ui.IFactoryBind, Efl.Ui.IPropertyBind
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(WidgetFactory))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_ui_widget_factory_class_get();
    /// <summary>Initializes a new instance of the <see cref="WidgetFactory"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    /// <param name="itemClass">Define the class of the item returned by this factory. See <see cref="Efl.Ui.WidgetFactory.SetItemClass" /></param>
    public WidgetFactory(Efl.Object parent
            , Type itemClass = null) : base(efl_ui_widget_factory_class_get(), parent)
    {
        if (Efl.Eo.Globals.ParamHelperCheck(itemClass))
        {
            SetItemClass(Efl.Eo.Globals.GetParamHelper(itemClass));
        }

        FinishInstantiation();
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected WidgetFactory(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="WidgetFactory"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected WidgetFactory(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="WidgetFactory"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected WidgetFactory(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }

    /// <summary>Event triggered when an item has been successfully created.</summary>
    /// <value><see cref="Efl.Ui.FactoryCreatedEventArgs"/></value>
    public event EventHandler<Efl.Ui.FactoryCreatedEventArgs> CreatedEvent
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
                        Efl.Ui.FactoryCreatedEventArgs args = new Efl.Ui.FactoryCreatedEventArgs();
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
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_FACTORY_EVENT_CREATED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event CreatedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnCreatedEvent(Efl.Ui.FactoryCreatedEventArgs e)
    {
        var key = "_EFL_UI_FACTORY_EVENT_CREATED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
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
    /// <summary>Event dispatched when a property on the object has changed due to a user interaction on the object that a model could be interested in.</summary>
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
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_PROPERTY_BIND_EVENT_PROPERTIES_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event PropertiesChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnPropertiesChangedEvent(Efl.Ui.PropertyBindPropertiesChangedEventArgs e)
    {
        var key = "_EFL_UI_PROPERTY_BIND_EVENT_PROPERTIES_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
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
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_PROPERTY_BIND_EVENT_PROPERTY_BOUND";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event PropertyBoundEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnPropertyBoundEvent(Efl.Ui.PropertyBindPropertyBoundEventArgs e)
    {
        var key = "_EFL_UI_PROPERTY_BIND_EVENT_PROPERTY_BOUND";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
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
    /// <summary>Define the class of the item returned by this factory.</summary>
    /// <returns>The class identifier to create item from.</returns>
    public virtual Type GetItemClass() {
         var _ret_var = Efl.Ui.WidgetFactory.NativeMethods.efl_ui_widget_factory_item_class_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Define the class of the item returned by this factory.</summary>
    /// <param name="klass">The class identifier to create item from.</param>
    public virtual void SetItemClass(Type klass) {
                                 Efl.Ui.WidgetFactory.NativeMethods.efl_ui_widget_factory_item_class_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),klass);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get a proxy object referring to a part of an object.
    /// (Since EFL 1.22)</summary>
    /// <param name="name">The part name.</param>
    /// <returns>A (proxy) object, valid for a single call.</returns>
    protected virtual Efl.Object GetPart(System.String name) {
                                 var _ret_var = Efl.PartConcrete.NativeMethods.efl_part_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),name);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Create a UI object from the necessary properties in the specified model.
    /// Note: This is the function you need to implement for a custom factory, but if you want to use a factory, you should rely on <see cref="Efl.Ui.ViewFactory.CreateWithEvent"/>.</summary>
    /// <param name="models">Efl iterator providing the model to be associated to the new item. It should remain valid until the end of the function call.</param>
    /// <param name="parent">Efl canvas</param>
    /// <returns>Created UI object</returns>
    protected virtual  Eina.Future Create(Eina.Iterator<Efl.IModel> models, Efl.Gfx.IEntity parent) {
         var _in_models = models.Handle;
                                                var _ret_var = Efl.Ui.FactoryConcrete.NativeMethods.efl_ui_factory_create_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_models, parent);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Release a UI object and disconnect from models.</summary>
    /// <param name="ui_view">Efl canvas</param>
    public virtual void Release(Efl.Gfx.IEntity ui_view) {
                                 Efl.Ui.FactoryConcrete.NativeMethods.efl_ui_factory_release_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),ui_view);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>This function is called during the creation of an UI object between the Efl.Object.constructor and <see cref="Efl.Object.FinalizeAdd"/> call.
    /// Note: If the <see cref="Efl.Ui.IFactory"/> does keep a cache of objects, this won&apos;t be called when objects are pulled out of the cache.</summary>
    /// <param name="ui_view">The UI object being created.</param>
    public virtual void Building(Efl.Gfx.IEntity ui_view) {
                                 Efl.Ui.FactoryConcrete.NativeMethods.efl_ui_factory_building_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),ui_view);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>bind the factory with the given key string. when the data is ready or changed, factory create the object and bind the data to the key action and process promised work. Note: the input <see cref="Efl.Ui.IFactory"/> need to be <see cref="Efl.Ui.IPropertyBind.PropertyBind"/> at least once.</summary>
    /// <param name="key">Key string for bind model property data</param>
    /// <param name="factory"><see cref="Efl.Ui.IFactory"/> for create and bind model property data</param>
    public virtual void FactoryBind(System.String key, Efl.Ui.IFactory factory) {
                                                         Efl.Ui.FactoryBindConcrete.NativeMethods.efl_ui_factory_bind_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),key, factory);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>bind property data with the given key string. when the data is ready or changed, bind the data to the key action and process promised work.</summary>
    /// <param name="key">key string for bind model property data</param>
    /// <param name="property">Model property name</param>
    /// <returns>0 when it succeed, an error code otherwise.</returns>
    public virtual Eina.Error PropertyBind(System.String key, System.String property) {
                                                         var _ret_var = Efl.Ui.PropertyBindConcrete.NativeMethods.efl_ui_property_bind_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),key, property);
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

    /// <summary>Define the class of the item returned by this factory.</summary>
    /// <value>The class identifier to create item from.</value>
    public Type ItemClass {
        get { return GetItemClass(); }
        set { SetItemClass(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.WidgetFactory.efl_ui_widget_factory_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.LoopConsumer.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Elementary);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_ui_widget_factory_item_class_get_static_delegate == null)
            {
                efl_ui_widget_factory_item_class_get_static_delegate = new efl_ui_widget_factory_item_class_get_delegate(item_class_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetItemClass") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_factory_item_class_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_factory_item_class_get_static_delegate) });
            }

            if (efl_ui_widget_factory_item_class_set_static_delegate == null)
            {
                efl_ui_widget_factory_item_class_set_static_delegate = new efl_ui_widget_factory_item_class_set_delegate(item_class_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetItemClass") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_factory_item_class_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_factory_item_class_set_static_delegate) });
            }

            if (efl_part_get_static_delegate == null)
            {
                efl_part_get_static_delegate = new efl_part_get_delegate(part_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetPart") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_part_get"), func = Marshal.GetFunctionPointerForDelegate(efl_part_get_static_delegate) });
            }

            if (efl_ui_factory_create_static_delegate == null)
            {
                efl_ui_factory_create_static_delegate = new efl_ui_factory_create_delegate(create);
            }

            if (methods.FirstOrDefault(m => m.Name == "Create") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_factory_create"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_factory_create_static_delegate) });
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
            descs.AddRange(base.GetEoOps(type, false));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.WidgetFactory.efl_ui_widget_factory_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEflClass))]
        private delegate Type efl_ui_widget_factory_item_class_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEflClass))]
        public delegate Type efl_ui_widget_factory_item_class_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_factory_item_class_get_api_delegate> efl_ui_widget_factory_item_class_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_factory_item_class_get_api_delegate>(Module, "efl_ui_widget_factory_item_class_get");

        private static Type item_class_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_widget_factory_item_class_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Type _ret_var = default(Type);
                try
                {
                    _ret_var = ((WidgetFactory)ws.Target).GetItemClass();
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
                return efl_ui_widget_factory_item_class_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_widget_factory_item_class_get_delegate efl_ui_widget_factory_item_class_get_static_delegate;

        
        private delegate void efl_ui_widget_factory_item_class_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEflClass))] Type klass);

        
        public delegate void efl_ui_widget_factory_item_class_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEflClass))] Type klass);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_factory_item_class_set_api_delegate> efl_ui_widget_factory_item_class_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_factory_item_class_set_api_delegate>(Module, "efl_ui_widget_factory_item_class_set");

        private static void item_class_set(System.IntPtr obj, System.IntPtr pd, Type klass)
        {
            Eina.Log.Debug("function efl_ui_widget_factory_item_class_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((WidgetFactory)ws.Target).SetItemClass(klass);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_widget_factory_item_class_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), klass);
            }
        }

        private static efl_ui_widget_factory_item_class_set_delegate efl_ui_widget_factory_item_class_set_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Object efl_part_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String name);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Object efl_part_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String name);

        public static Efl.Eo.FunctionWrapper<efl_part_get_api_delegate> efl_part_get_ptr = new Efl.Eo.FunctionWrapper<efl_part_get_api_delegate>(Module, "efl_part_get");

        private static Efl.Object part_get(System.IntPtr obj, System.IntPtr pd, System.String name)
        {
            Eina.Log.Debug("function efl_part_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    Efl.Object _ret_var = default(Efl.Object);
                try
                {
                    _ret_var = ((WidgetFactory)ws.Target).GetPart(name);
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
                return efl_part_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), name);
            }
        }

        private static efl_part_get_delegate efl_part_get_static_delegate;

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
                    _ret_var = ((WidgetFactory)ws.Target).Create(_in_models, parent);
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

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_UiWidgetFactory_ExtensionMethods {
    public static Efl.BindableProperty<Type> ItemClass<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.WidgetFactory, T>magic = null) where T : Efl.Ui.WidgetFactory {
        return new Efl.BindableProperty<Type>("item_class", fac);
    }

}
#pragma warning restore CS1591
#endif
