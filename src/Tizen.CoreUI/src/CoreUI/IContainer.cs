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
    /// <summary>Common interface for objects (containers) that can have multiple contents (sub-objects).
    /// 
    /// APIs in this interface deal with containers of multiple sub-objects, not with individual parts.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.IContainerNativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    public interface IContainer : 
        CoreUI.Wrapper.IWrapper, IDisposable
    {
        /// <summary>Begin iterating over this object&apos;s contents.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <returns>Iterator on object&apos;s content.</returns>
        IEnumerable<CoreUI.Gfx.IEntity> IterateContent();

        /// <summary>Returns the number of contained sub-objects.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <returns>Number of sub-objects.</returns>
        int ContentCount();

        /// <summary>Sent after a new sub-object was added.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.ContainerContentAddedEventArgs"/></value>
        event EventHandler<CoreUI.ContainerContentAddedEventArgs> ContentAdded;
        /// <summary>Sent after a sub-object was removed, before unref.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.ContainerContentRemovedEventArgs"/></value>
        event EventHandler<CoreUI.ContainerContentRemovedEventArgs> ContentRemoved;
    }

    /// <summary>Event argument wrapper for event <see cref="CoreUI.IContainer.ContentAdded"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Wrapper.BindingEntity]
    public class ContainerContentAddedEventArgs : EventArgs {
        /// <summary>Actual event payload.
        /// </summary>
        /// <value>Sent after a new sub-object was added.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.Gfx.IEntity Arg { get; set; }
    }

    /// <summary>Event argument wrapper for event <see cref="CoreUI.IContainer.ContentRemoved"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Wrapper.BindingEntity]
    public class ContainerContentRemovedEventArgs : EventArgs {
        /// <summary>Actual event payload.
        /// </summary>
        /// <value>Sent after a sub-object was removed, before unref.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.Gfx.IEntity Arg { get; set; }
    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class IContainerNativeMethods : CoreUI.Wrapper.ObjectWrapper.NativeMethods
    {
        [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
            efl_container_interface_get();
        private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.CoreUI);

        /// <summary>Gets the list of Eo operations to override.
    /// </summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
            var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

            if (efl_content_iterate_static_delegate == null)
            {
                efl_content_iterate_static_delegate = new efl_content_iterate_delegate(content_iterate);
            }

            if (methods.Contains("IterateContent"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_content_iterate"), func = Marshal.GetFunctionPointerForDelegate(efl_content_iterate_static_delegate) });
            }

            if (efl_content_count_static_delegate == null)
            {
                efl_content_count_static_delegate = new efl_content_count_delegate(content_count);
            }

            if (methods.Contains("ContentCount"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_content_count"), func = Marshal.GetFunctionPointerForDelegate(efl_content_count_static_delegate) });
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
            return efl_container_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate System.IntPtr efl_content_iterate_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate System.IntPtr efl_content_iterate_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_content_iterate_api_delegate> efl_content_iterate_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_content_iterate_api_delegate>(Module, "efl_content_iterate");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static System.IntPtr content_iterate(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_content_iterate was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                IEnumerable<CoreUI.Gfx.IEntity> _ret_var = null;
                try
                {
                    _ret_var = ((IContainer)ws.Target).IterateContent();
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
                return efl_content_iterate_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_content_iterate_delegate efl_content_iterate_static_delegate;

        
        private delegate int efl_content_count_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate int efl_content_count_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_content_count_api_delegate> efl_content_count_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_content_count_api_delegate>(Module, "efl_content_count");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static int content_count(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_content_count was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                int _ret_var = default(int);
                try
                {
                    _ret_var = ((IContainer)ws.Target).ContentCount();
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
                return efl_content_count_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_content_count_delegate efl_content_count_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

    }
}

