/*
 * Copyright 2019 by its authors. See AUTHORS.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
namespace CoreUI.UI {
    /// <summary>CoreUI UI Factory that provides <see cref="CoreUI.UI.Widget"/>.
    /// 
    /// This factory is designed to build <see cref="CoreUI.UI.Widget"/> and optionally set their <see cref="CoreUI.UI.Widget.Style"/> if it was connected with <see cref="CoreUI.UI.IPropertyBind.BindProperty"/> &quot;<c>style</c>&quot;.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.UI.WidgetFactory.NativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public class WidgetFactory : CoreUI.LoopConsumer, CoreUI.IPart, CoreUI.UI.IFactory, CoreUI.UI.IFactoryBind, CoreUI.UI.IPropertyBind
    {
        /// <summary>Pointer to the native class description.</summary>
        public override System.IntPtr NativeClass
        {
            get
            {
                if (((object)this).GetType() == typeof(WidgetFactory))
                {
                    return GetCoreUIClassStatic();
                }
                else
                {
                    return CoreUI.Wrapper.ClassRegister.klassFromType[((object)this).GetType()];
                }
            }
        }

        [System.Runtime.InteropServices.DllImport(CoreUI.Libs.Elementary)] internal static extern System.IntPtr
            efl_ui_widget_factory_class_get();

        /// <summary>Initializes a new instance of the <see cref="WidgetFactory"/> class.
        /// </summary>
        /// <param name="parent">Parent instance.</param>
    /// <param name="itemClass">Define the class of the item returned by this factory. See <see cref="CoreUI.UI.WidgetFactory.SetItemClass" /></param>
        public WidgetFactory(CoreUI.Object parent, Type itemClass = null) : base(efl_ui_widget_factory_class_get(), parent)
        {
            if (CoreUI.Wrapper.Globals.ParamHelperCheck(itemClass))
            {
                SetItemClass(CoreUI.Wrapper.Globals.GetParamHelper(itemClass));
            }

            FinishInstantiation();
        }

        /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
        /// Do not call this constructor directly.
        /// </summary>
        /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
        protected WidgetFactory(ConstructingHandle ch) : base(ch)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="WidgetFactory"/> class.
        /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.
        /// </summary>
        /// <param name="wh">The native pointer to be wrapped.</param>
        internal WidgetFactory(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="WidgetFactory"/> class.
        /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.
        /// </summary>
        /// <param name="baseKlass">The pointer to the base native Eo class.</param>
        /// <param name="parent">The CoreUI.Object parent of this instance.</param>
        protected WidgetFactory(IntPtr baseKlass, CoreUI.Object parent) : base(baseKlass, parent)
        {
        }


        /// <summary>Event emitted when an item is under construction (between the CoreUI.Object.constructor and <see cref="CoreUI.Object.FinalizeAdd"/> call on the item). Note: If the <see cref="CoreUI.UI.IFactory"/> keeps a cache of objects, this won&apos;t be called when objects are pulled from the cache.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.UI.FactoryItemConstructingEventArgs"/></value>
        public event EventHandler<CoreUI.UI.FactoryItemConstructingEventArgs> ItemConstructing
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.UI.FactoryItemConstructingEventArgs{ Arg = (CoreUI.Wrapper.Globals.CreateWrapperFor(info) as CoreUI.Gfx.IEntity) });
                string key = "_EFL_UI_FACTORY_EVENT_ITEM_CONSTRUCTING";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_UI_FACTORY_EVENT_ITEM_CONSTRUCTING";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event ItemConstructing.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnItemConstructing(CoreUI.UI.FactoryItemConstructingEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = e.Arg.NativeHandle;
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_UI_FACTORY_EVENT_ITEM_CONSTRUCTING", info, null);
        }

        /// <summary>Event emitted when an item has processed <see cref="CoreUI.Object.FinalizeAdd"/>, but before all the factory are done building it. Note: If the <see cref="CoreUI.UI.IFactory"/> keeps a cache of objects, this will be called when objects are pulled from the cache.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.UI.FactoryItemBuildingEventArgs"/></value>
        public event EventHandler<CoreUI.UI.FactoryItemBuildingEventArgs> ItemBuilding
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.UI.FactoryItemBuildingEventArgs{ Arg = (CoreUI.Wrapper.Globals.CreateWrapperFor(info) as CoreUI.Gfx.IEntity) });
                string key = "_EFL_UI_FACTORY_EVENT_ITEM_BUILDING";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_UI_FACTORY_EVENT_ITEM_BUILDING";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event ItemBuilding.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnItemBuilding(CoreUI.UI.FactoryItemBuildingEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = e.Arg.NativeHandle;
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_UI_FACTORY_EVENT_ITEM_BUILDING", info, null);
        }

        /// <summary>Event emitted when an item has been successfully created by the factory and is about to be used by an <see cref="CoreUI.UI.IView"/>.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.UI.FactoryItemCreatedEventArgs"/></value>
        public event EventHandler<CoreUI.UI.FactoryItemCreatedEventArgs> ItemCreated
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.UI.FactoryItemCreatedEventArgs{ Arg = (CoreUI.Wrapper.Globals.CreateWrapperFor(info) as CoreUI.Gfx.IEntity) });
                string key = "_EFL_UI_FACTORY_EVENT_ITEM_CREATED";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_UI_FACTORY_EVENT_ITEM_CREATED";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event ItemCreated.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnItemCreated(CoreUI.UI.FactoryItemCreatedEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = e.Arg.NativeHandle;
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_UI_FACTORY_EVENT_ITEM_CREATED", info, null);
        }

        /// <summary>Event emitted when an item is being released by the <see cref="CoreUI.UI.IFactory"/>. It must be assumed that after this call, the object can be recycles to another <see cref="CoreUI.UI.IView"/> and there can be more than one call for the same item.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.UI.FactoryItemReleasingEventArgs"/></value>
        public event EventHandler<CoreUI.UI.FactoryItemReleasingEventArgs> ItemReleasing
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.UI.FactoryItemReleasingEventArgs{ Arg = (CoreUI.Wrapper.Globals.CreateWrapperFor(info) as CoreUI.Gfx.IEntity) });
                string key = "_EFL_UI_FACTORY_EVENT_ITEM_RELEASING";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_UI_FACTORY_EVENT_ITEM_RELEASING";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event ItemReleasing.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnItemReleasing(CoreUI.UI.FactoryItemReleasingEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = e.Arg.NativeHandle;
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_UI_FACTORY_EVENT_ITEM_RELEASING", info, null);
        }

        /// <summary>Event dispatched when a property on the object has changed due to a user interaction on the object that a model could be interested in.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.UI.PropertyBindPropertiesChangedEventArgs"/></value>
        public event EventHandler<CoreUI.UI.PropertyBindPropertiesChangedEventArgs> PropertiesChanged
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.UI.PropertyBindPropertiesChangedEventArgs{ Arg =  info });
                string key = "_EFL_UI_PROPERTY_BIND_EVENT_PROPERTIES_CHANGED";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_UI_PROPERTY_BIND_EVENT_PROPERTIES_CHANGED";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event PropertiesChanged.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnPropertiesChanged(CoreUI.UI.PropertyBindPropertiesChangedEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = Marshal.AllocHGlobal(Marshal.SizeOf(e.Arg));
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_UI_PROPERTY_BIND_EVENT_PROPERTIES_CHANGED", info, (p) => Marshal.FreeHGlobal(p));
        }

        /// <summary>Event dispatched when a property on the object is bound to a model. This is useful to avoid generating too many events.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.UI.PropertyBindPropertyBoundEventArgs"/></value>
        public event EventHandler<CoreUI.UI.PropertyBindPropertyBoundEventArgs> PropertyBound
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.UI.PropertyBindPropertyBoundEventArgs{ Arg = CoreUI.DataTypes.StringConversion.NativeUtf8ToManagedString(info) });
                string key = "_EFL_UI_PROPERTY_BIND_EVENT_PROPERTY_BOUND";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_UI_PROPERTY_BIND_EVENT_PROPERTY_BOUND";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event PropertyBound.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnPropertyBound(CoreUI.UI.PropertyBindPropertyBoundEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = CoreUI.DataTypes.StringConversion.ManagedStringToNativeUtf8Alloc(e.Arg);
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_UI_PROPERTY_BIND_EVENT_PROPERTY_BOUND", info, (p) => CoreUI.DataTypes.MemoryNative.Free(p));
        }

        /// <summary>Define the class of the item returned by this factory.</summary>
        /// <returns>The class identifier to create item from.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual Type GetItemClass() {
            var _ret_var = CoreUI.UI.WidgetFactory.NativeMethods.efl_ui_widget_factory_item_class_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Define the class of the item returned by this factory.</summary>
        /// <param name="klass">The class identifier to create item from.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetItemClass(Type klass) {
            CoreUI.UI.WidgetFactory.NativeMethods.efl_ui_widget_factory_item_class_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), klass);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Get a proxy object referring to a part of an object.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="name">The part name.</param>
        /// <returns>A (proxy) object, valid for a single call.</returns>
        public virtual CoreUI.Object GetPart(System.String name) {
            var _ret_var = CoreUI.IPartNativeMethods.efl_part_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), name);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Create a UI object from the necessary properties in the specified model.
        /// 
        /// <b>NOTE: </b>This is the function you need to implement for a custom factory, but if you want to use a factory, you should rely on <span class="text-muted">CoreUI.UI.ViewFactory.CreateWithEvent (object still in beta stage)</span>.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="models">CoreUI iterator providing the model to be associated to the new item. It should remain valid until the end of the function call.</param>
        /// <returns>Created UI object.</returns>
        protected virtual  CoreUI.DataTypes.Future Create(IEnumerable<CoreUI.IModel> models) {
            var _in_models = CoreUI.Wrapper.Globals.IEnumerableToIterator(models, true);
var _ret_var = CoreUI.UI.IFactoryNativeMethods.efl_ui_factory_create_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), _in_models);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Release a UI object and disconnect from models.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="ui_views">Object to remove.</param>
        public virtual void Release(IEnumerable<CoreUI.Gfx.IEntity> ui_views) {
            var _in_ui_views = CoreUI.Wrapper.Globals.IEnumerableToIterator(ui_views, true);
CoreUI.UI.IFactoryNativeMethods.efl_ui_factory_release_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), _in_ui_views);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>bind the factory with the given key string. when the data is ready or changed, factory create the object and bind the data to the key action and process promised work. Note: the input <see cref="CoreUI.UI.IFactory"/> need to be <see cref="CoreUI.UI.IPropertyBind.BindProperty"/> at least once.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="key">Key string for bind model property data</param>
        /// <param name="factory"><see cref="CoreUI.UI.IFactory"/> for create and bind model property data</param>
        /// <returns>0 when it succeed, an error code otherwise.</returns>
        public virtual CoreUI.DataTypes.Error BindFactory(System.String key, CoreUI.UI.IFactory factory) {
            var _ret_var = CoreUI.UI.IFactoryBindNativeMethods.efl_ui_factory_bind_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), key, factory);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>bind property data with the given key string. when the data is ready or changed, bind the data to the key action and process promised work.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="key">key string for bind model property data</param>
        /// <param name="property">Model property name</param>
        /// <returns>0 when it succeed, an error code otherwise.</returns>
        public virtual CoreUI.DataTypes.Error BindProperty(System.String key, System.String property) {
            var _ret_var = CoreUI.UI.IPropertyBindNativeMethods.efl_ui_property_bind_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), key, property);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Async wrapper for <see cref="Create" />.
        /// </summary>
    /// <param name="models">CoreUI iterator providing the model to be associated to the new item. It should remain valid until the end of the function call.</param>
        /// <param name="token">Token to notify the async operation of external request to cancel.</param>
        /// <returns>An async task wrapping the result of the operation.</returns>
        public System.Threading.Tasks.Task<CoreUI.DataTypes.Value> CreateAsync(IEnumerable<CoreUI.IModel> models,  System.Threading.CancellationToken token = default(System.Threading.CancellationToken))
        {
            CoreUI.DataTypes.Future future = Create( models);
            return CoreUI.Wrapper.Globals.WrapAsync(future, token);
        }

        /// <summary>Define the class of the item returned by this factory.</summary>
        /// <value>The class identifier to create item from.</value>
        /// <since_tizen> 6 </since_tizen>
        public Type ItemClass {
            get { return GetItemClass(); }
            set { SetItemClass(value); }
        }

        private static IntPtr GetCoreUIClassStatic()
        {
            return CoreUI.UI.WidgetFactory.efl_ui_widget_factory_class_get();
        }

        /// <summary>Wrapper for native methods and virtual method delegates.
        /// For internal use by generated code only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal new class NativeMethods : CoreUI.LoopConsumer.NativeMethods
        {
            private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.Elementary);

            /// <summary>Gets the list of Eo operations to override.
        /// </summary>
            /// <returns>The list of Eo operations to be overload.</returns>
            internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
            {
                var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
                var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

                if (efl_ui_widget_factory_item_class_get_static_delegate == null)
                {
                    efl_ui_widget_factory_item_class_get_static_delegate = new efl_ui_widget_factory_item_class_get_delegate(item_class_get);
                }

                if (methods.Contains("GetItemClass"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_factory_item_class_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_factory_item_class_get_static_delegate) });
                }

                if (efl_ui_widget_factory_item_class_set_static_delegate == null)
                {
                    efl_ui_widget_factory_item_class_set_static_delegate = new efl_ui_widget_factory_item_class_set_delegate(item_class_set);
                }

                if (methods.Contains("SetItemClass"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_factory_item_class_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_factory_item_class_set_static_delegate) });
                }

                if (efl_part_get_static_delegate == null)
                {
                    efl_part_get_static_delegate = new efl_part_get_delegate(part_get);
                }

                if (methods.Contains("GetPart"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_part_get"), func = Marshal.GetFunctionPointerForDelegate(efl_part_get_static_delegate) });
                }

                if (efl_ui_factory_create_static_delegate == null)
                {
                    efl_ui_factory_create_static_delegate = new efl_ui_factory_create_delegate(create);
                }

                if (methods.Contains("Create"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_factory_create"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_factory_create_static_delegate) });
                }

                if (includeInherited)
                {
                    var all_interfaces = type.GetInterfaces();
                    foreach (var iface in all_interfaces)
                    {
                        var moredescs = ((CoreUI.Wrapper.NativeClass)iface.GetCustomAttributes(false)?.FirstOrDefault(attr => attr is CoreUI.Wrapper.NativeClass))?.GetEoOps(type, false);
                        if (moredescs != null)
                            descs.AddRange(moredescs);
                    }
                }
                descs.AddRange(base.GetEoOps(type, false));
                return descs;
            }

            /// <summary>Returns the Eo class for the native methods of this class.
            /// </summary>
            /// <returns>The native class pointer.</returns>
            internal override IntPtr GetCoreUIClass()
            {
                return CoreUI.UI.WidgetFactory.efl_ui_widget_factory_class_get();
            }

            #pragma warning disable CA1707, CS1591, SA1300, SA1600

            [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalCoreUIClass))]
            private delegate Type efl_ui_widget_factory_item_class_get_delegate(System.IntPtr obj, System.IntPtr pd);

            [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalCoreUIClass))]
            internal delegate Type efl_ui_widget_factory_item_class_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_widget_factory_item_class_get_api_delegate> efl_ui_widget_factory_item_class_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_widget_factory_item_class_get_api_delegate>(Module, "efl_ui_widget_factory_item_class_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static Type item_class_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_widget_factory_item_class_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    Type _ret_var = default(Type);
                    try
                    {
                        _ret_var = ((WidgetFactory)ws.Target).GetItemClass();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return _ret_var;
                }
                else
                {
                    return efl_ui_widget_factory_item_class_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_ui_widget_factory_item_class_get_delegate efl_ui_widget_factory_item_class_get_static_delegate;

            
            private delegate void efl_ui_widget_factory_item_class_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalCoreUIClass))] Type klass);

            
            internal delegate void efl_ui_widget_factory_item_class_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalCoreUIClass))] Type klass);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_widget_factory_item_class_set_api_delegate> efl_ui_widget_factory_item_class_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_widget_factory_item_class_set_api_delegate>(Module, "efl_ui_widget_factory_item_class_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void item_class_set(System.IntPtr obj, System.IntPtr pd, Type klass)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_widget_factory_item_class_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((WidgetFactory)ws.Target).SetItemClass(klass);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_ui_widget_factory_item_class_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), klass);
                }
            }

            private static efl_ui_widget_factory_item_class_set_delegate efl_ui_widget_factory_item_class_set_static_delegate;

            [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
            private delegate CoreUI.Object efl_part_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String name);

            [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
            internal delegate CoreUI.Object efl_part_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String name);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_part_get_api_delegate> efl_part_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_part_get_api_delegate>(Module, "efl_part_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static CoreUI.Object part_get(System.IntPtr obj, System.IntPtr pd, System.String name)
            {
                CoreUI.DataTypes.Log.Debug("function efl_part_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.Object _ret_var = default(CoreUI.Object);
                    try
                    {
                        _ret_var = ((WidgetFactory)ws.Target).GetPart(name);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return _ret_var;
                }
                else
                {
                    return efl_part_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), name);
                }
            }

            private static efl_part_get_delegate efl_part_get_static_delegate;

            [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.DataTypes.FutureMarshaler))]
            private delegate  CoreUI.DataTypes.Future efl_ui_factory_create_delegate(System.IntPtr obj, System.IntPtr pd,  System.IntPtr models);

            [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.DataTypes.FutureMarshaler))]
            internal delegate  CoreUI.DataTypes.Future efl_ui_factory_create_api_delegate(System.IntPtr obj,  System.IntPtr models);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_factory_create_api_delegate> efl_ui_factory_create_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_factory_create_api_delegate>(Module, "efl_ui_factory_create");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static  CoreUI.DataTypes.Future create(System.IntPtr obj, System.IntPtr pd, System.IntPtr models)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_factory_create was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    var _in_models = CoreUI.Wrapper.Globals.IteratorToIEnumerable<CoreUI.IModel>(models);
 CoreUI.DataTypes.Future _ret_var = default( CoreUI.DataTypes.Future);
                    try
                    {
                        _ret_var = ((WidgetFactory)ws.Target).Create(_in_models);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return _ret_var;
                }
                else
                {
                    return efl_ui_factory_create_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), models);
                }
            }

            private static efl_ui_factory_create_delegate efl_ui_factory_create_static_delegate;

            #pragma warning restore CA1707, CS1591, SA1300, SA1600

        }
    }
}

namespace CoreUI.UI {
#pragma warning disable CS1591
    /// <since_tizen> 6 </since_tizen>
    public static class WidgetFactoryExtensions {
        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<Type> ItemClass<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.WidgetFactory, T>magic = null) where T : CoreUI.UI.WidgetFactory {
            return new CoreUI.BindableProperty<Type>("item_class", fac.GetPropBind());
        }

    }
#pragma warning restore CS1591
}

