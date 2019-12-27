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
namespace CoreUI {
    /// <summary>The CoreUI Loop Model class</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.LoopModel.NativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public abstract class LoopModel : CoreUI.LoopConsumer, CoreUI.IModel
    {
        /// <summary>Pointer to the native class description.</summary>
        public override System.IntPtr NativeClass
        {
            get
            {
                if (((object)this).GetType() == typeof(LoopModel))
                {
                    return GetCoreUIClassStatic();
                }
                else
                {
                    return CoreUI.Wrapper.ClassRegister.klassFromType[((object)this).GetType()];
                }
            }
        }

        [System.Runtime.InteropServices.DllImport(CoreUI.Libs.Ecore)] internal static extern System.IntPtr
            efl_loop_model_class_get();

        /// <summary>Initializes a new instance of the <see cref="LoopModel"/> class.
        /// </summary>
        /// <param name="parent">Parent instance.</param>
        public LoopModel(CoreUI.Object parent= null) : base(efl_loop_model_class_get(), parent)
        {
            FinishInstantiation();
        }

        /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
        /// Do not call this constructor directly.
        /// </summary>
        /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
        protected LoopModel(ConstructingHandle ch) : base(ch)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="LoopModel"/> class.
        /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.
        /// </summary>
        /// <param name="wh">The native pointer to be wrapped.</param>
        internal LoopModel(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
        {
        }

        [CoreUI.Wrapper.PrivateNativeClass]
        private class LoopModelRealized : LoopModel
        {
            private LoopModelRealized(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
            {
            }
        }
        /// <summary>Initializes a new instance of the <see cref="LoopModel"/> class.
        /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.
        /// </summary>
        /// <param name="baseKlass">The pointer to the base native Eo class.</param>
        /// <param name="parent">The CoreUI.Object parent of this instance.</param>
        protected LoopModel(IntPtr baseKlass, CoreUI.Object parent) : base(baseKlass, parent)
        {
        }


        /// <summary>Event dispatched when properties list is available.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.ModelPropertiesChangedEventArgs"/></value>
        public event EventHandler<CoreUI.ModelPropertiesChangedEventArgs> PropertiesChanged
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.ModelPropertiesChangedEventArgs{ Arg =  info });
                string key = "_EFL_MODEL_EVENT_PROPERTIES_CHANGED";
                AddNativeEventHandler(CoreUI.Libs.Ecore, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_MODEL_EVENT_PROPERTIES_CHANGED";
                RemoveNativeEventHandler(CoreUI.Libs.Ecore, key, value);
            }
        }

        /// <summary>Method to raise event PropertiesChanged.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnPropertiesChanged(CoreUI.ModelPropertiesChangedEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = Marshal.AllocHGlobal(Marshal.SizeOf(e.Arg));
            CallNativeEventCallback(CoreUI.Libs.Ecore, "_EFL_MODEL_EVENT_PROPERTIES_CHANGED", info, (p) => Marshal.FreeHGlobal(p));
        }

        /// <summary>Event dispatched when new child is added.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.ModelChildAddedEventArgs"/></value>
        public event EventHandler<CoreUI.ModelChildAddedEventArgs> ChildAdded
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.ModelChildAddedEventArgs{ Arg =  info });
                string key = "_EFL_MODEL_EVENT_CHILD_ADDED";
                AddNativeEventHandler(CoreUI.Libs.Ecore, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_MODEL_EVENT_CHILD_ADDED";
                RemoveNativeEventHandler(CoreUI.Libs.Ecore, key, value);
            }
        }

        /// <summary>Method to raise event ChildAdded.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnChildAdded(CoreUI.ModelChildAddedEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = Marshal.AllocHGlobal(Marshal.SizeOf(e.Arg));
            CallNativeEventCallback(CoreUI.Libs.Ecore, "_EFL_MODEL_EVENT_CHILD_ADDED", info, (p) => Marshal.FreeHGlobal(p));
        }

        /// <summary>Event dispatched when child is removed.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.ModelChildRemovedEventArgs"/></value>
        public event EventHandler<CoreUI.ModelChildRemovedEventArgs> ChildRemoved
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.ModelChildRemovedEventArgs{ Arg =  info });
                string key = "_EFL_MODEL_EVENT_CHILD_REMOVED";
                AddNativeEventHandler(CoreUI.Libs.Ecore, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_MODEL_EVENT_CHILD_REMOVED";
                RemoveNativeEventHandler(CoreUI.Libs.Ecore, key, value);
            }
        }

        /// <summary>Method to raise event ChildRemoved.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnChildRemoved(CoreUI.ModelChildRemovedEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = Marshal.AllocHGlobal(Marshal.SizeOf(e.Arg));
            CallNativeEventCallback(CoreUI.Libs.Ecore, "_EFL_MODEL_EVENT_CHILD_REMOVED", info, (p) => Marshal.FreeHGlobal(p));
        }

        /// <summary>Event dispatched when children count is finished.</summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler ChildrenCountChanged
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value);
                string key = "_EFL_MODEL_EVENT_CHILDREN_COUNT_CHANGED";
                AddNativeEventHandler(CoreUI.Libs.Ecore, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_MODEL_EVENT_CHILDREN_COUNT_CHANGED";
                RemoveNativeEventHandler(CoreUI.Libs.Ecore, key, value);
            }
        }

        /// <summary>Method to raise event ChildrenCountChanged.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnChildrenCountChanged()
        {
            CallNativeEventCallback(CoreUI.Libs.Ecore, "_EFL_MODEL_EVENT_CHILDREN_COUNT_CHANGED", IntPtr.Zero, null);
        }

        /// <summary>To be called when a Child model is created by <see cref="CoreUI.IModel.GetChildrenSlice"/> by the one creating the child object.
        /// 
        /// This function is used to properly define the lifecycle of the new Child Model object and make sure that once it has 0 ref except its parent Model, it will be destroyed. This function should only be called once per child. It is useful for <see cref="CoreUI.IModel"/> who have a lot of children and shouldn&apos;t keep more than what is used in memory.</summary>
        /// <since_tizen> 6 </since_tizen>
        public virtual void VolatileMake() {
            CoreUI.LoopModel.NativeMethods.efl_loop_model_volatile_make_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Get properties from model.
        /// 
        /// Properties_get is due to provide callers a way the fetch the current properties implemented/used by the model. The event <see cref="CoreUI.IModel.PropertiesChanged"/> will be raised to notify listeners of any modifications in the properties.
        /// 
        /// See also <see cref="CoreUI.IModel.PropertiesChanged"/>.</summary>
        /// <returns>Array of current properties</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual IEnumerable<System.String> GetProperties() {
            var _ret_var = CoreUI.IModelNativeMethods.efl_model_properties_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return CoreUI.Wrapper.Globals.IteratorToIEnumerable<System.String>(_ret_var);
        }

        /// <summary><br/>
        /// <b>Note:</b> Retrieve the value of a given property name.
        /// 
        /// At this point the caller is free to get values from properties. The event <see cref="CoreUI.IModel.PropertiesChanged"/> may be raised to notify listeners of the property/value.
        /// 
        /// See <see cref="CoreUI.IModel.GetProperties"/>, <see cref="CoreUI.IModel.PropertiesChanged"/></summary>
        /// <param name="property">Property name</param>
        /// <returns>Property value</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.DataTypes.Value GetProperty(System.String property) {
            var _ret_var = CoreUI.IModelNativeMethods.efl_model_property_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), property);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary><br/>
        /// <b>Note:</b> Set a property value of a given property name.
        /// 
        /// The caller must first read <see cref="CoreUI.IModel.GetProperties"/> to obtain the list of available properties before being able to access them through <see cref="CoreUI.IModel.GetProperty"/>. This function sets a new property value into given property name. Once the operation is completed the concrete implementation should raise <see cref="CoreUI.IModel.PropertiesChanged"/> event in order to notify listeners of the new value of the property.
        /// 
        /// If the model doesn&apos;t have the property then there are two possibilities, either raise an error or create the new property in model
        /// 
        /// See <see cref="CoreUI.IModel.GetProperty"/>, <see cref="CoreUI.IModel.PropertiesChanged"/></summary>
        /// <param name="property">Property name</param>
        /// <param name="value">Property value</param>
        /// <returns>Return an error in case the property could not be set, or the value that was set otherwise.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual  CoreUI.DataTypes.Future SetProperty(System.String property, CoreUI.DataTypes.Value value) {
            var _ret_var = CoreUI.IModelNativeMethods.efl_model_property_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), property, value);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Number of children.
        /// 
        /// After @[.properties,changed] is emitted, <see cref="CoreUI.IModel.GetChildrenCount"/> can be used to get the number of children. <see cref="CoreUI.IModel.GetChildrenCount"/> can also be used before calling <see cref="CoreUI.IModel.GetChildrenSlice"/> so a valid range is known. Event <see cref="CoreUI.IModel.ChildrenCountChanged"/> is emitted when count is finished.
        /// 
        /// See also <see cref="CoreUI.IModel.GetChildrenSlice"/>.</summary>
        /// <returns>Current known children count</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual uint GetChildrenCount() {
            var _ret_var = CoreUI.IModelNativeMethods.efl_model_children_count_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Get a future value when it changes to something that is not error:EAGAIN
        /// 
        /// <see cref="CoreUI.IModel.GetProperty"/> can return an error with code EAGAIN when it doesn&apos;t have any meaningful value. To make life easier, this future will resolve when the error:EAGAIN disappears. Either into a failed future in case the error code changed to something else or a success with the value of the property whenever the property finally changes.
        /// 
        /// The future can also be canceled if the model itself gets destroyed.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="property">Property name.</param>
        /// <returns>Future to be resolved when the property changes to anything other than error:EAGAIN</returns>
        public virtual  CoreUI.DataTypes.Future GetPropertyReady(System.String property) {
            var _ret_var = CoreUI.IModelNativeMethods.efl_model_property_ready_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), property);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Get children slice OR full range.
        /// 
        /// <see cref="CoreUI.IModel.GetChildrenSlice"/> behaves in two different ways, it may provide the slice if <c>count</c> is non-zero OR full range otherwise.
        /// 
        /// Since &apos;slice&apos; is a range, for example if we have 20 children a slice could be the range from 3(start) with 4(count), see:
        /// 
        /// child 0  [no] child 1  [no] child 2  [no] child 3  [yes] child 4  [yes] child 5  [yes] child 6  [yes] child 7  [no]
        /// 
        /// Optionally the user can call <see cref="CoreUI.IModel.GetChildrenCount"/> to know the number of children so a valid range can be known in advance.
        /// 
        /// See <see cref="CoreUI.IModel.GetChildrenCount"/>
        /// 
        /// <b>NOTE: </b>The returned children will live only as long as the future itself. Once the future is done, if you want to keep the object alive, you need to take a reference for yourself.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="start">Range begin - start from here.</param>
        /// <param name="count">Range size. If count is 0, start is ignored.</param>
        /// <returns>Array of children</returns>
        public virtual  CoreUI.DataTypes.Future GetChildrenSlice(uint start, uint count) {
            var _ret_var = CoreUI.IModelNativeMethods.efl_model_children_slice_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), start, count);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Add a new child.
        /// 
        /// Add a new child, possibly dummy, depending on the implementation, of a internal keeping. When the child is effectively added the event <see cref="CoreUI.IModel.ChildAdded"/> is then raised and the new child is kept along with other children.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <returns>Child object</returns>
        public virtual CoreUI.Object AddChild() {
            var _ret_var = CoreUI.IModelNativeMethods.efl_model_child_add_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Remove a child.
        /// 
        /// Remove a child of a internal keeping. When the child is effectively removed the event <see cref="CoreUI.IModel.ChildRemoved"/> is then raised to give a chance for listeners to perform any cleanup and/or update references.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="child">Child to be removed</param>
        public virtual void DelChild(CoreUI.Object child) {
            CoreUI.IModelNativeMethods.efl_model_child_del_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), child);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Async wrapper for <see cref="SetProperty" />.
        /// </summary>
    /// <param name="property">Property name</param>
    /// <param name="value">Property value</param>
        /// <param name="token">Token to notify the async operation of external request to cancel.</param>
        /// <returns>An async task wrapping the result of the operation.</returns>
        public System.Threading.Tasks.Task<CoreUI.DataTypes.Value> SetPropertyAsync(System.String property, CoreUI.DataTypes.Value value,  System.Threading.CancellationToken token = default(System.Threading.CancellationToken))
        {
            CoreUI.DataTypes.Future future = SetProperty( property,  value);
            return CoreUI.Wrapper.Globals.WrapAsync(future, token);
        }

        /// <summary>Async wrapper for <see cref="GetPropertyReady" />.
        /// </summary>
    /// <param name="property">Property name.</param>
        /// <param name="token">Token to notify the async operation of external request to cancel.</param>
        /// <returns>An async task wrapping the result of the operation.</returns>
        public System.Threading.Tasks.Task<CoreUI.DataTypes.Value> GetPropertyReadyAsync(System.String property,  System.Threading.CancellationToken token = default(System.Threading.CancellationToken))
        {
            CoreUI.DataTypes.Future future = GetPropertyReady( property);
            return CoreUI.Wrapper.Globals.WrapAsync(future, token);
        }

        /// <summary>Async wrapper for <see cref="GetChildrenSlice" />.
        /// </summary>
    /// <param name="start">Range begin - start from here.</param>
    /// <param name="count">Range size. If count is 0, start is ignored.</param>
        /// <param name="token">Token to notify the async operation of external request to cancel.</param>
        /// <returns>An async task wrapping the result of the operation.</returns>
        public System.Threading.Tasks.Task<CoreUI.DataTypes.Value> GetChildrenSliceAsync(uint start, uint count,  System.Threading.CancellationToken token = default(System.Threading.CancellationToken))
        {
            CoreUI.DataTypes.Future future = GetChildrenSlice( start,  count);
            return CoreUI.Wrapper.Globals.WrapAsync(future, token);
        }

        /// <summary>Get properties from model.
        /// 
        /// Properties_get is due to provide callers a way the fetch the current properties implemented/used by the model. The event <see cref="CoreUI.IModel.PropertiesChanged"/> will be raised to notify listeners of any modifications in the properties.
        /// 
        /// See also <see cref="CoreUI.IModel.PropertiesChanged"/>.</summary>
        /// <value>Array of current properties</value>
        /// <since_tizen> 6 </since_tizen>
        public IEnumerable<System.String> Properties {
            get { return GetProperties(); }
        }

        /// <summary>Number of children.
        /// 
        /// After @[.properties,changed] is emitted, <see cref="CoreUI.IModel.GetChildrenCount"/> can be used to get the number of children. <see cref="CoreUI.IModel.GetChildrenCount"/> can also be used before calling <see cref="CoreUI.IModel.GetChildrenSlice"/> so a valid range is known. Event <see cref="CoreUI.IModel.ChildrenCountChanged"/> is emitted when count is finished.
        /// 
        /// See also <see cref="CoreUI.IModel.GetChildrenSlice"/>.</summary>
        /// <value>Current known children count</value>
        /// <since_tizen> 6 </since_tizen>
        public uint ChildrenCount {
            get { return GetChildrenCount(); }
        }

        private static IntPtr GetCoreUIClassStatic()
        {
            return CoreUI.LoopModel.efl_loop_model_class_get();
        }

        /// <summary>Wrapper for native methods and virtual method delegates.
        /// For internal use by generated code only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal new class NativeMethods : CoreUI.LoopConsumer.NativeMethods
        {
            private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.Ecore);

            /// <summary>Gets the list of Eo operations to override.
        /// </summary>
            /// <returns>The list of Eo operations to be overload.</returns>
            internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
            {
                var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
                var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

                if (efl_loop_model_volatile_make_static_delegate == null)
                {
                    efl_loop_model_volatile_make_static_delegate = new efl_loop_model_volatile_make_delegate(volatile_make);
                }

                if (methods.Contains("VolatileMake"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_loop_model_volatile_make"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_model_volatile_make_static_delegate) });
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
                return CoreUI.LoopModel.efl_loop_model_class_get();
            }

            #pragma warning disable CA1707, CS1591, SA1300, SA1600

            
            private delegate void efl_loop_model_volatile_make_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate void efl_loop_model_volatile_make_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_loop_model_volatile_make_api_delegate> efl_loop_model_volatile_make_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_loop_model_volatile_make_api_delegate>(Module, "efl_loop_model_volatile_make");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void volatile_make(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_loop_model_volatile_make was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((LoopModel)ws.Target).VolatileMake();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_loop_model_volatile_make_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_loop_model_volatile_make_delegate efl_loop_model_volatile_make_static_delegate;

            #pragma warning restore CA1707, CS1591, SA1300, SA1600

        }
    }
}

