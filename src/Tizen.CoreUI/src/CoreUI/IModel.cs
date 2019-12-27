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
    /// <summary>Basic Model abstraction.
    /// 
    /// A model in EFL can have a set of key-value properties, where key can only be a string. The value can be anything within an Eina_Value. If a property is not yet available EAGAIN is returned.
    /// 
    /// Additionally a model can have a list of children. The fetching of the children is asynchronous, this has the advantage of having as few data sets as possible in the memory itself.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.IModelNativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    public interface IModel : 
        CoreUI.Wrapper.IWrapper, IDisposable
    {
        /// <summary>Get properties from model.
        /// 
        /// Properties_get is due to provide callers a way the fetch the current properties implemented/used by the model. The event <see cref="CoreUI.IModel.PropertiesChanged"/> will be raised to notify listeners of any modifications in the properties.
        /// 
        /// See also <see cref="CoreUI.IModel.PropertiesChanged"/>.</summary>
        /// <returns>Array of current properties</returns>
        /// <since_tizen> 6 </since_tizen>
        IEnumerable<System.String> GetProperties();

        /// <summary><br/>
        /// <b>Note:</b> Retrieve the value of a given property name.
        /// 
        /// At this point the caller is free to get values from properties. The event <see cref="CoreUI.IModel.PropertiesChanged"/> may be raised to notify listeners of the property/value.
        /// 
        /// See <see cref="CoreUI.IModel.GetProperties"/>, <see cref="CoreUI.IModel.PropertiesChanged"/></summary>
        /// <param name="property">Property name</param>
        /// <returns>Property value</returns>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.DataTypes.Value GetProperty(System.String property);

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
         CoreUI.DataTypes.Future SetProperty(System.String property, CoreUI.DataTypes.Value value);

        /// <summary>Number of children.
        /// 
        /// After @[.properties,changed] is emitted, <see cref="CoreUI.IModel.GetChildrenCount"/> can be used to get the number of children. <see cref="CoreUI.IModel.GetChildrenCount"/> can also be used before calling <see cref="CoreUI.IModel.GetChildrenSlice"/> so a valid range is known. Event <see cref="CoreUI.IModel.ChildrenCountChanged"/> is emitted when count is finished.
        /// 
        /// See also <see cref="CoreUI.IModel.GetChildrenSlice"/>.</summary>
        /// <returns>Current known children count</returns>
        /// <since_tizen> 6 </since_tizen>
        uint GetChildrenCount();

        /// <summary>Get a future value when it changes to something that is not error:EAGAIN
        /// 
        /// <see cref="CoreUI.IModel.GetProperty"/> can return an error with code EAGAIN when it doesn&apos;t have any meaningful value. To make life easier, this future will resolve when the error:EAGAIN disappears. Either into a failed future in case the error code changed to something else or a success with the value of the property whenever the property finally changes.
        /// 
        /// The future can also be canceled if the model itself gets destroyed.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="property">Property name.</param>
        /// <returns>Future to be resolved when the property changes to anything other than error:EAGAIN</returns>
         CoreUI.DataTypes.Future GetPropertyReady(System.String property);

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
         CoreUI.DataTypes.Future GetChildrenSlice(uint start, uint count);

        /// <summary>Add a new child.
        /// 
        /// Add a new child, possibly dummy, depending on the implementation, of a internal keeping. When the child is effectively added the event <see cref="CoreUI.IModel.ChildAdded"/> is then raised and the new child is kept along with other children.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <returns>Child object</returns>
        CoreUI.Object AddChild();

        /// <summary>Remove a child.
        /// 
        /// Remove a child of a internal keeping. When the child is effectively removed the event <see cref="CoreUI.IModel.ChildRemoved"/> is then raised to give a chance for listeners to perform any cleanup and/or update references.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="child">Child to be removed</param>
        void DelChild(CoreUI.Object child);

        /// <summary>Async wrapper for <see cref="SetProperty" />.
        /// </summary>
        /// <param name="property">Property name</param>
        /// <param name="value">Property value</param>
        /// <param name="token">Token to notify the async operation of external request to cancel.</param>
        /// <returns>An async task wrapping the result of the operation.</returns>
        System.Threading.Tasks.Task<CoreUI.DataTypes.Value> SetPropertyAsync(System.String property, CoreUI.DataTypes.Value value,  System.Threading.CancellationToken token = default(System.Threading.CancellationToken));

        /// <summary>Async wrapper for <see cref="GetPropertyReady" />.
        /// </summary>
        /// <param name="property">Property name.</param>
        /// <param name="token">Token to notify the async operation of external request to cancel.</param>
        /// <returns>An async task wrapping the result of the operation.</returns>
        System.Threading.Tasks.Task<CoreUI.DataTypes.Value> GetPropertyReadyAsync(System.String property,  System.Threading.CancellationToken token = default(System.Threading.CancellationToken));

        /// <summary>Async wrapper for <see cref="GetChildrenSlice" />.
        /// </summary>
        /// <param name="start">Range begin - start from here.</param>
        /// <param name="count">Range size. If count is 0, start is ignored.</param>
        /// <param name="token">Token to notify the async operation of external request to cancel.</param>
        /// <returns>An async task wrapping the result of the operation.</returns>
        System.Threading.Tasks.Task<CoreUI.DataTypes.Value> GetChildrenSliceAsync(uint start, uint count,  System.Threading.CancellationToken token = default(System.Threading.CancellationToken));

        /// <summary>Event dispatched when properties list is available.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.ModelPropertiesChangedEventArgs"/></value>
        event EventHandler<CoreUI.ModelPropertiesChangedEventArgs> PropertiesChanged;
        /// <summary>Event dispatched when new child is added.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.ModelChildAddedEventArgs"/></value>
        event EventHandler<CoreUI.ModelChildAddedEventArgs> ChildAdded;
        /// <summary>Event dispatched when child is removed.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.ModelChildRemovedEventArgs"/></value>
        event EventHandler<CoreUI.ModelChildRemovedEventArgs> ChildRemoved;
        /// <summary>Event dispatched when children count is finished.</summary>
        /// <since_tizen> 6 </since_tizen>
        event EventHandler ChildrenCountChanged;
        /// <summary>Get properties from model.
        /// 
        /// Properties_get is due to provide callers a way the fetch the current properties implemented/used by the model. The event <see cref="CoreUI.IModel.PropertiesChanged"/> will be raised to notify listeners of any modifications in the properties.
        /// 
        /// See also <see cref="CoreUI.IModel.PropertiesChanged"/>.</summary>
        /// <value>Array of current properties</value>
        /// <since_tizen> 6 </since_tizen>
        IEnumerable<System.String> Properties {
            get;
        }

        /// <summary>Number of children.
        /// 
        /// After @[.properties,changed] is emitted, <see cref="CoreUI.IModel.GetChildrenCount"/> can be used to get the number of children. <see cref="CoreUI.IModel.GetChildrenCount"/> can also be used before calling <see cref="CoreUI.IModel.GetChildrenSlice"/> so a valid range is known. Event <see cref="CoreUI.IModel.ChildrenCountChanged"/> is emitted when count is finished.
        /// 
        /// See also <see cref="CoreUI.IModel.GetChildrenSlice"/>.</summary>
        /// <value>Current known children count</value>
        /// <since_tizen> 6 </since_tizen>
        uint ChildrenCount {
            get;
        }

    }

    /// <summary>Event argument wrapper for event <see cref="CoreUI.IModel.PropertiesChanged"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Wrapper.BindingEntity]
    public class ModelPropertiesChangedEventArgs : EventArgs {
        /// <summary>Actual event payload.
        /// </summary>
        /// <value>Event dispatched when properties list is available.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.ModelPropertyEvent Arg { get; set; }
    }

    /// <summary>Event argument wrapper for event <see cref="CoreUI.IModel.ChildAdded"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Wrapper.BindingEntity]
    public class ModelChildAddedEventArgs : EventArgs {
        /// <summary>Actual event payload.
        /// </summary>
        /// <value>Event dispatched when new child is added.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.ModelChildrenEvent Arg { get; set; }
    }

    /// <summary>Event argument wrapper for event <see cref="CoreUI.IModel.ChildRemoved"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Wrapper.BindingEntity]
    public class ModelChildRemovedEventArgs : EventArgs {
        /// <summary>Actual event payload.
        /// </summary>
        /// <value>Event dispatched when child is removed.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.ModelChildrenEvent Arg { get; set; }
    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class IModelNativeMethods : CoreUI.Wrapper.ObjectWrapper.NativeMethods
    {
        [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
            efl_model_interface_get();
        private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.CoreUI);

        /// <summary>Gets the list of Eo operations to override.
    /// </summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
            var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

            if (efl_model_properties_get_static_delegate == null)
            {
                efl_model_properties_get_static_delegate = new efl_model_properties_get_delegate(properties_get);
            }

            if (methods.Contains("GetProperties"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_model_properties_get"), func = Marshal.GetFunctionPointerForDelegate(efl_model_properties_get_static_delegate) });
            }

            if (efl_model_property_get_static_delegate == null)
            {
                efl_model_property_get_static_delegate = new efl_model_property_get_delegate(property_get);
            }

            if (methods.Contains("GetProperty"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_model_property_get"), func = Marshal.GetFunctionPointerForDelegate(efl_model_property_get_static_delegate) });
            }

            if (efl_model_property_set_static_delegate == null)
            {
                efl_model_property_set_static_delegate = new efl_model_property_set_delegate(property_set);
            }

            if (methods.Contains("SetProperty"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_model_property_set"), func = Marshal.GetFunctionPointerForDelegate(efl_model_property_set_static_delegate) });
            }

            if (efl_model_children_count_get_static_delegate == null)
            {
                efl_model_children_count_get_static_delegate = new efl_model_children_count_get_delegate(children_count_get);
            }

            if (methods.Contains("GetChildrenCount"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_model_children_count_get"), func = Marshal.GetFunctionPointerForDelegate(efl_model_children_count_get_static_delegate) });
            }

            if (efl_model_property_ready_get_static_delegate == null)
            {
                efl_model_property_ready_get_static_delegate = new efl_model_property_ready_get_delegate(property_ready_get);
            }

            if (methods.Contains("GetPropertyReady"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_model_property_ready_get"), func = Marshal.GetFunctionPointerForDelegate(efl_model_property_ready_get_static_delegate) });
            }

            if (efl_model_children_slice_get_static_delegate == null)
            {
                efl_model_children_slice_get_static_delegate = new efl_model_children_slice_get_delegate(children_slice_get);
            }

            if (methods.Contains("GetChildrenSlice"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_model_children_slice_get"), func = Marshal.GetFunctionPointerForDelegate(efl_model_children_slice_get_static_delegate) });
            }

            if (efl_model_child_add_static_delegate == null)
            {
                efl_model_child_add_static_delegate = new efl_model_child_add_delegate(child_add);
            }

            if (methods.Contains("AddChild"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_model_child_add"), func = Marshal.GetFunctionPointerForDelegate(efl_model_child_add_static_delegate) });
            }

            if (efl_model_child_del_static_delegate == null)
            {
                efl_model_child_del_static_delegate = new efl_model_child_del_delegate(child_del);
            }

            if (methods.Contains("DelChild"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_model_child_del"), func = Marshal.GetFunctionPointerForDelegate(efl_model_child_del_static_delegate) });
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
            return descs;
        }

        /// <summary>Returns the Eo class for the native methods of this class.
        /// </summary>
        /// <returns>The native class pointer.</returns>
        internal override IntPtr GetCoreUIClass()
        {
            return efl_model_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate System.IntPtr efl_model_properties_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate System.IntPtr efl_model_properties_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_model_properties_get_api_delegate> efl_model_properties_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_model_properties_get_api_delegate>(Module, "efl_model_properties_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static System.IntPtr properties_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_model_properties_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                IEnumerable<System.String> _ret_var = null;
                try
                {
                    _ret_var = ((IModel)ws.Target).GetProperties();
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return CoreUI.Wrapper.Globals.IEnumerableToIterator(_ret_var, true);
            }
            else
            {
                return efl_model_properties_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_model_properties_get_delegate efl_model_properties_get_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.DataTypes.ValueMarshaler))]
        private delegate CoreUI.DataTypes.Value efl_model_property_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String property);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.DataTypes.ValueMarshaler))]
        internal delegate CoreUI.DataTypes.Value efl_model_property_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String property);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_model_property_get_api_delegate> efl_model_property_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_model_property_get_api_delegate>(Module, "efl_model_property_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static CoreUI.DataTypes.Value property_get(System.IntPtr obj, System.IntPtr pd, System.String property)
        {
            CoreUI.DataTypes.Log.Debug("function efl_model_property_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.DataTypes.Value _ret_var = default(CoreUI.DataTypes.Value);
                try
                {
                    _ret_var = ((IModel)ws.Target).GetProperty(property);
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
                return efl_model_property_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), property);
            }
        }

        private static efl_model_property_get_delegate efl_model_property_get_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.DataTypes.FutureMarshaler))]
        private delegate  CoreUI.DataTypes.Future efl_model_property_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String property, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.DataTypes.ValueMarshaler))] CoreUI.DataTypes.Value value);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.DataTypes.FutureMarshaler))]
        internal delegate  CoreUI.DataTypes.Future efl_model_property_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String property, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.DataTypes.ValueMarshaler))] CoreUI.DataTypes.Value value);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_model_property_set_api_delegate> efl_model_property_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_model_property_set_api_delegate>(Module, "efl_model_property_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static  CoreUI.DataTypes.Future property_set(System.IntPtr obj, System.IntPtr pd, System.String property, CoreUI.DataTypes.Value value)
        {
            CoreUI.DataTypes.Log.Debug("function efl_model_property_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                 CoreUI.DataTypes.Future _ret_var = default( CoreUI.DataTypes.Future);
                try
                {
                    _ret_var = ((IModel)ws.Target).SetProperty(property, value);
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
                return efl_model_property_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), property, value);
            }
        }

        private static efl_model_property_set_delegate efl_model_property_set_static_delegate;

        
        private delegate uint efl_model_children_count_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate uint efl_model_children_count_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_model_children_count_get_api_delegate> efl_model_children_count_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_model_children_count_get_api_delegate>(Module, "efl_model_children_count_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static uint children_count_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_model_children_count_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                uint _ret_var = default(uint);
                try
                {
                    _ret_var = ((IModel)ws.Target).GetChildrenCount();
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
                return efl_model_children_count_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_model_children_count_get_delegate efl_model_children_count_get_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.DataTypes.FutureMarshaler))]
        private delegate  CoreUI.DataTypes.Future efl_model_property_ready_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String property);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.DataTypes.FutureMarshaler))]
        internal delegate  CoreUI.DataTypes.Future efl_model_property_ready_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String property);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_model_property_ready_get_api_delegate> efl_model_property_ready_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_model_property_ready_get_api_delegate>(Module, "efl_model_property_ready_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static  CoreUI.DataTypes.Future property_ready_get(System.IntPtr obj, System.IntPtr pd, System.String property)
        {
            CoreUI.DataTypes.Log.Debug("function efl_model_property_ready_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                 CoreUI.DataTypes.Future _ret_var = default( CoreUI.DataTypes.Future);
                try
                {
                    _ret_var = ((IModel)ws.Target).GetPropertyReady(property);
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
                return efl_model_property_ready_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), property);
            }
        }

        private static efl_model_property_ready_get_delegate efl_model_property_ready_get_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.DataTypes.FutureMarshaler))]
        private delegate  CoreUI.DataTypes.Future efl_model_children_slice_get_delegate(System.IntPtr obj, System.IntPtr pd,  uint start,  uint count);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.DataTypes.FutureMarshaler))]
        internal delegate  CoreUI.DataTypes.Future efl_model_children_slice_get_api_delegate(System.IntPtr obj,  uint start,  uint count);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_model_children_slice_get_api_delegate> efl_model_children_slice_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_model_children_slice_get_api_delegate>(Module, "efl_model_children_slice_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static  CoreUI.DataTypes.Future children_slice_get(System.IntPtr obj, System.IntPtr pd, uint start, uint count)
        {
            CoreUI.DataTypes.Log.Debug("function efl_model_children_slice_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                 CoreUI.DataTypes.Future _ret_var = default( CoreUI.DataTypes.Future);
                try
                {
                    _ret_var = ((IModel)ws.Target).GetChildrenSlice(start, count);
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
                return efl_model_children_slice_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), start, count);
            }
        }

        private static efl_model_children_slice_get_delegate efl_model_children_slice_get_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
        private delegate CoreUI.Object efl_model_child_add_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
        internal delegate CoreUI.Object efl_model_child_add_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_model_child_add_api_delegate> efl_model_child_add_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_model_child_add_api_delegate>(Module, "efl_model_child_add");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static CoreUI.Object child_add(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_model_child_add was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.Object _ret_var = default(CoreUI.Object);
                try
                {
                    _ret_var = ((IModel)ws.Target).AddChild();
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
                return efl_model_child_add_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_model_child_add_delegate efl_model_child_add_static_delegate;

        
        private delegate void efl_model_child_del_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Object child);

        
        internal delegate void efl_model_child_del_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Object child);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_model_child_del_api_delegate> efl_model_child_del_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_model_child_del_api_delegate>(Module, "efl_model_child_del");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void child_del(System.IntPtr obj, System.IntPtr pd, CoreUI.Object child)
        {
            CoreUI.DataTypes.Log.Debug("function efl_model_child_del was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IModel)ws.Target).DelChild(child);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_model_child_del_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), child);
            }
        }

        private static efl_model_child_del_delegate efl_model_child_del_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

    }
}

namespace CoreUI {
    /// <summary>EFL model property event data structure</summary>
    /// <since_tizen> 6 </since_tizen>
    [StructLayout(LayoutKind.Sequential)]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public struct ModelPropertyEvent : IEquatable<ModelPropertyEvent>
    {
        
        private System.IntPtr changedProperties;
        
        private System.IntPtr invalidatedProperties;

        /// <summary>List of changed properties</summary>
        /// <since_tizen> 6 </since_tizen>
        public IList<CoreUI.DataTypes.Stringshare> ChangedProperties { get => CoreUI.Wrapper.Globals.NativeArrayToIList<CoreUI.DataTypes.Stringshare>(changedProperties); }
        /// <summary>Removed properties identified by name</summary>
        /// <since_tizen> 6 </since_tizen>
        public IList<CoreUI.DataTypes.Stringshare> InvalidatedProperties { get => CoreUI.Wrapper.Globals.NativeArrayToIList<CoreUI.DataTypes.Stringshare>(invalidatedProperties); }
        /// <summary>Constructor for ModelPropertyEvent.
        /// </summary>
        /// <param name="changedProperties">List of changed properties</param>
        /// <param name="invalidatedProperties">Removed properties identified by name</param>
        /// <since_tizen> 6 </since_tizen>
        public ModelPropertyEvent(
            IList<CoreUI.DataTypes.Stringshare> changedProperties = default(IList<CoreUI.DataTypes.Stringshare>),
            IList<CoreUI.DataTypes.Stringshare> invalidatedProperties = default(IList<CoreUI.DataTypes.Stringshare>))
        {
            this.changedProperties = CoreUI.Wrapper.Globals.IListToNativeArray(changedProperties, false);
            this.invalidatedProperties = CoreUI.Wrapper.Globals.IListToNativeArray(invalidatedProperties, false);
        }

        /// <summary>Packs tuple into ModelPropertyEvent object.
        ///<para>Since EFL 1.24.</para>
        ///</summary>
        public static implicit operator ModelPropertyEvent((IList<CoreUI.DataTypes.Stringshare> changedProperties, IList<CoreUI.DataTypes.Stringshare> invalidatedProperties) tuple)
            => new ModelPropertyEvent(tuple.changedProperties, tuple.invalidatedProperties);

        /// <summary>Unpacks ModelPropertyEvent into tuple.
        /// <para>Since EFL 1.24.</para>
        /// </summary>
        public void Deconstruct(
            out IList<CoreUI.DataTypes.Stringshare> changedProperties,
            out IList<CoreUI.DataTypes.Stringshare> invalidatedProperties
        )
        {
            changedProperties = this.ChangedProperties;
            invalidatedProperties = this.InvalidatedProperties;
        }
        /// <summary>Get a hash code for this item.
        /// </summary>
        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + ChangedProperties.GetHashCode();
            hash = hash * 23 + InvalidatedProperties.GetHashCode();
            return hash;
        }
        /// <summary>Equality comparison.
        /// </summary>
        public bool Equals(ModelPropertyEvent other)
        {
            return ChangedProperties == other.ChangedProperties && InvalidatedProperties == other.InvalidatedProperties;
        }
        /// <summary>Equality comparison.
        /// </summary>
        public override bool Equals(object other)
            => ((other is ModelPropertyEvent) ? Equals((ModelPropertyEvent)other) : false);
        /// <summary>Equality comparison.
        /// </summary>
        public static bool operator ==(ModelPropertyEvent lhs, ModelPropertyEvent rhs)
            => lhs.Equals(rhs);        /// <summary>Equality comparison.
        /// </summary>
        public static bool operator !=(ModelPropertyEvent lhs, ModelPropertyEvent rhs)
            => !lhs.Equals(rhs);        /// <summary>Implicit conversion to the managed representation from a native pointer.
        /// </summary>
        /// <param name="ptr">Native pointer to be converted.</param>
        public static implicit operator ModelPropertyEvent(IntPtr ptr)
        {
            return (ModelPropertyEvent)Marshal.PtrToStructure(ptr, typeof(ModelPropertyEvent));
        }

        /// <summary>Conversion to the managed representation from a native pointer.
        /// </summary>
        /// <param name="ptr">Native pointer to be converted.</param>
        public static ModelPropertyEvent FromIntPtr(IntPtr ptr)
        {
            return ptr;
        }

    }

}

namespace CoreUI {
    /// <summary>Every time a child is added the event <see cref="CoreUI.IModel.ChildAdded"/> is dispatched passing along this structure.</summary>
    /// <since_tizen> 6 </since_tizen>
    [StructLayout(LayoutKind.Sequential)]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public struct ModelChildrenEvent : IEquatable<ModelChildrenEvent>
    {
        
        private uint index;
        /// <summary>Internal wrapper for field child</summary>
        private System.IntPtr child;

        /// <summary>index is a hint and is intended to provide a way for applications to control/know children relative positions through listings.</summary>
        /// <since_tizen> 6 </since_tizen>
        public uint Index { get => index; }
        /// <summary>If an object has been built for this index and it is currently tracked by the parent, it will be available here.</summary>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.Object Child { get => (CoreUI.Object) CoreUI.Wrapper.Globals.CreateWrapperFor(child); }
        /// <summary>Constructor for ModelChildrenEvent.
        /// </summary>
        /// <param name="index">index is a hint and is intended to provide a way for applications to control/know children relative positions through listings.</param>
        /// <param name="child">If an object has been built for this index and it is currently tracked by the parent, it will be available here.</param>
        /// <since_tizen> 6 </since_tizen>
        public ModelChildrenEvent(
            uint index = default(uint),
            CoreUI.Object child = default(CoreUI.Object))
        {
            this.index = index;
            this.child = child?.NativeHandle ?? System.IntPtr.Zero;
        }

        /// <summary>Packs tuple into ModelChildrenEvent object.
        ///<para>Since EFL 1.24.</para>
        ///</summary>
        public static implicit operator ModelChildrenEvent((uint index, CoreUI.Object child) tuple)
            => new ModelChildrenEvent(tuple.index, tuple.child);

        /// <summary>Unpacks ModelChildrenEvent into tuple.
        /// <para>Since EFL 1.24.</para>
        /// </summary>
        public void Deconstruct(
            out uint index,
            out CoreUI.Object child
        )
        {
            index = this.Index;
            child = this.Child;
        }
        /// <summary>Get a hash code for this item.
        /// </summary>
        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + Index.GetHashCode();
            hash = hash * 23 + Child.GetHashCode();
            return hash;
        }
        /// <summary>Equality comparison.
        /// </summary>
        public bool Equals(ModelChildrenEvent other)
        {
            return Index == other.Index && Child == other.Child;
        }
        /// <summary>Equality comparison.
        /// </summary>
        public override bool Equals(object other)
            => ((other is ModelChildrenEvent) ? Equals((ModelChildrenEvent)other) : false);
        /// <summary>Equality comparison.
        /// </summary>
        public static bool operator ==(ModelChildrenEvent lhs, ModelChildrenEvent rhs)
            => lhs.Equals(rhs);        /// <summary>Equality comparison.
        /// </summary>
        public static bool operator !=(ModelChildrenEvent lhs, ModelChildrenEvent rhs)
            => !lhs.Equals(rhs);        /// <summary>Implicit conversion to the managed representation from a native pointer.
        /// </summary>
        /// <param name="ptr">Native pointer to be converted.</param>
        public static implicit operator ModelChildrenEvent(IntPtr ptr)
        {
            return (ModelChildrenEvent)Marshal.PtrToStructure(ptr, typeof(ModelChildrenEvent));
        }

        /// <summary>Conversion to the managed representation from a native pointer.
        /// </summary>
        /// <param name="ptr">Native pointer to be converted.</param>
        public static ModelChildrenEvent FromIntPtr(IntPtr ptr)
        {
            return ptr;
        }

    }

}

