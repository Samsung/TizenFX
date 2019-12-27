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
    /// <summary>CoreUI UI Property_Bind interface. view object can have <see cref="CoreUI.IModel"/> to manage the data, the interface can help loading and tracking child data from the model property. see <see cref="CoreUI.IModel"/> see <see cref="CoreUI.UI.IFactory"/></summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.UI.IPropertyBindNativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    public interface IPropertyBind : 
        CoreUI.Wrapper.IWrapper, IDisposable
    {
        /// <summary>bind property data with the given key string. when the data is ready or changed, bind the data to the key action and process promised work.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="key">key string for bind model property data</param>
        /// <param name="property">Model property name</param>
        /// <returns>0 when it succeed, an error code otherwise.</returns>
        CoreUI.DataTypes.Error BindProperty(System.String key, System.String property);

        /// <summary>Event dispatched when a property on the object has changed due to a user interaction on the object that a model could be interested in.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.UI.PropertyBindPropertiesChangedEventArgs"/></value>
        event EventHandler<CoreUI.UI.PropertyBindPropertiesChangedEventArgs> PropertiesChanged;
        /// <summary>Event dispatched when a property on the object is bound to a model. This is useful to avoid generating too many events.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.UI.PropertyBindPropertyBoundEventArgs"/></value>
        event EventHandler<CoreUI.UI.PropertyBindPropertyBoundEventArgs> PropertyBound;
    }

    /// <summary>Event argument wrapper for event <see cref="CoreUI.UI.IPropertyBind.PropertiesChanged"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Wrapper.BindingEntity]
    public class PropertyBindPropertiesChangedEventArgs : EventArgs {
        /// <summary>Actual event payload.
        /// </summary>
        /// <value>Event dispatched when a property on the object has changed due to a user interaction on the object that a model could be interested in.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.UI.PropertyEvent Arg { get; set; }
    }

    /// <summary>Event argument wrapper for event <see cref="CoreUI.UI.IPropertyBind.PropertyBound"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Wrapper.BindingEntity]
    public class PropertyBindPropertyBoundEventArgs : EventArgs {
        /// <summary>Actual event payload.
        /// </summary>
        /// <value>Event dispatched when a property on the object is bound to a model. This is useful to avoid generating too many events.</value>
        /// <since_tizen> 6 </since_tizen>
        public System.String Arg { get; set; }
    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class IPropertyBindNativeMethods : CoreUI.Wrapper.ObjectWrapper.NativeMethods
    {
        [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
            efl_ui_property_bind_interface_get();
        private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.CoreUI);

        /// <summary>Gets the list of Eo operations to override.
    /// </summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
            var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

            if (efl_ui_property_bind_static_delegate == null)
            {
                efl_ui_property_bind_static_delegate = new efl_ui_property_bind_delegate(property_bind);
            }

            if (methods.Contains("BindProperty"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_property_bind"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_property_bind_static_delegate) });
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
            return efl_ui_property_bind_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate CoreUI.DataTypes.Error efl_ui_property_bind_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String key, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String property);

        
        internal delegate CoreUI.DataTypes.Error efl_ui_property_bind_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String key, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String property);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_property_bind_api_delegate> efl_ui_property_bind_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_property_bind_api_delegate>(Module, "efl_ui_property_bind");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static CoreUI.DataTypes.Error property_bind(System.IntPtr obj, System.IntPtr pd, System.String key, System.String property)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_property_bind was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.DataTypes.Error _ret_var = default(CoreUI.DataTypes.Error);
                try
                {
                    _ret_var = ((IPropertyBind)ws.Target).BindProperty(key, property);
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
                return efl_ui_property_bind_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), key, property);
            }
        }

        private static efl_ui_property_bind_delegate efl_ui_property_bind_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

    }
}

namespace CoreUI.UI {
    /// <summary>EFL UI property event data structure triggered when an object property change due to the interaction on the object.</summary>
    /// <since_tizen> 6 </since_tizen>
    [StructLayout(LayoutKind.Sequential)]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public struct PropertyEvent : IEquatable<PropertyEvent>
    {
        
        private System.IntPtr changedProperties;

        /// <summary>List of changed properties</summary>
        /// <since_tizen> 6 </since_tizen>
        public IList<CoreUI.DataTypes.Stringshare> ChangedProperties { get => CoreUI.Wrapper.Globals.NativeArrayToIList<CoreUI.DataTypes.Stringshare>(changedProperties); }
        /// <summary>Constructor for PropertyEvent.
        /// </summary>
        /// <param name="changedProperties">List of changed properties</param>
        /// <since_tizen> 6 </since_tizen>
        public PropertyEvent(
            IList<CoreUI.DataTypes.Stringshare> changedProperties = default(IList<CoreUI.DataTypes.Stringshare>))
        {
            this.changedProperties = CoreUI.Wrapper.Globals.IListToNativeArray(changedProperties, false);
        }

        /// <summary>Unpacks PropertyEvent into tuple.
        /// <para>Since EFL 1.24.</para>
        /// </summary>
        public void Deconstruct(
            out IList<CoreUI.DataTypes.Stringshare> changedProperties
        )
        {
            changedProperties = this.ChangedProperties;
        }
        /// <summary>Get a hash code for this item.
        /// </summary>
        public override int GetHashCode()
        {
            return ChangedProperties.GetHashCode();
        }
        /// <summary>Equality comparison.
        /// </summary>
        public bool Equals(PropertyEvent other)
        {
            return ChangedProperties == other.ChangedProperties;
        }
        /// <summary>Equality comparison.
        /// </summary>
        public override bool Equals(object other)
            => ((other is PropertyEvent) ? Equals((PropertyEvent)other) : false);
        /// <summary>Equality comparison.
        /// </summary>
        public static bool operator ==(PropertyEvent lhs, PropertyEvent rhs)
            => lhs.Equals(rhs);        /// <summary>Equality comparison.
        /// </summary>
        public static bool operator !=(PropertyEvent lhs, PropertyEvent rhs)
            => !lhs.Equals(rhs);        /// <summary>Implicit conversion to the managed representation from a native pointer.
        /// </summary>
        /// <param name="ptr">Native pointer to be converted.</param>
        public static implicit operator PropertyEvent(IntPtr ptr)
        {
            return (PropertyEvent)Marshal.PtrToStructure(ptr, typeof(PropertyEvent));
        }

        /// <summary>Conversion to the managed representation from a native pointer.
        /// </summary>
        /// <param name="ptr">Native pointer to be converted.</param>
        public static PropertyEvent FromIntPtr(IntPtr ptr)
        {
            return ptr;
        }

    }

}

