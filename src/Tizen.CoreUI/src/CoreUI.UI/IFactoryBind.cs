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
    /// <summary>CoreUI UI Property interface. view object can have <see cref="CoreUI.IModel"/> and need to set cotent with those model stored data. the interface can help binding the factory to create object with model property data. see <see cref="CoreUI.IModel"/> see <see cref="CoreUI.UI.IFactory"/></summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.UI.IFactoryBindNativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    public interface IFactoryBind : 
        CoreUI.Wrapper.IWrapper, IDisposable
    {
        /// <summary>bind the factory with the given key string. when the data is ready or changed, factory create the object and bind the data to the key action and process promised work. Note: the input <see cref="CoreUI.UI.IFactory"/> need to be <see cref="CoreUI.UI.IPropertyBind.BindProperty"/> at least once.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="key">Key string for bind model property data</param>
        /// <param name="factory"><see cref="CoreUI.UI.IFactory"/> for create and bind model property data</param>
        /// <returns>0 when it succeed, an error code otherwise.</returns>
        CoreUI.DataTypes.Error BindFactory(System.String key, CoreUI.UI.IFactory factory);

    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class IFactoryBindNativeMethods : CoreUI.Wrapper.ObjectWrapper.NativeMethods
    {
        [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
            efl_ui_factory_bind_interface_get();
        private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.CoreUI);

        /// <summary>Gets the list of Eo operations to override.
    /// </summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
            var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

            if (efl_ui_factory_bind_static_delegate == null)
            {
                efl_ui_factory_bind_static_delegate = new efl_ui_factory_bind_delegate(factory_bind);
            }

            if (methods.Contains("BindFactory"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_factory_bind"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_factory_bind_static_delegate) });
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
            return efl_ui_factory_bind_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate CoreUI.DataTypes.Error efl_ui_factory_bind_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String key, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.UI.IFactory factory);

        
        internal delegate CoreUI.DataTypes.Error efl_ui_factory_bind_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String key, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.UI.IFactory factory);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_factory_bind_api_delegate> efl_ui_factory_bind_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_factory_bind_api_delegate>(Module, "efl_ui_factory_bind");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static CoreUI.DataTypes.Error factory_bind(System.IntPtr obj, System.IntPtr pd, System.String key, CoreUI.UI.IFactory factory)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_factory_bind was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.DataTypes.Error _ret_var = default(CoreUI.DataTypes.Error);
                try
                {
                    _ret_var = ((IFactoryBind)ws.Target).BindFactory(key, factory);
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
                return efl_ui_factory_bind_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), key, factory);
            }
        }

        private static efl_ui_factory_bind_delegate efl_ui_factory_bind_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

    }
}

