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
namespace CoreUI.Layout {
    /// <summary>APIs representing static data from a group in an edje file.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Layout.IGroupNativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    public interface IGroup : 
        CoreUI.Wrapper.IWrapper, IDisposable
    {
        /// <summary>The minimum size specified -- as an EDC property -- for a given Edje object
        /// 
        /// This property retrieves the obj object&apos;s minimum size values, as declared in its EDC group definition. For instance, for an Edje object of minimum size 100x100 pixels: collections { group { name: &quot;a_group&quot;; min: 100 100; } }
        /// 
        /// <b>NOTE: </b>If the <c>min</c> EDC property was not declared for this object, this call will return 0x0.
        /// 
        /// <b>NOTE: </b>On failure, this function also return 0x0.
        /// 
        /// See also <see cref="CoreUI.Layout.IGroup.GetGroupSizeMax"/>.</summary>
        /// <returns>The minimum size as set in EDC.</returns>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.DataTypes.Size2D GetGroupSizeMin();

        /// <summary>The maximum size specified -- as an EDC property -- for a given Edje object
        /// 
        /// This property retrieves the object&apos;s maximum size values, as declared in its EDC group definition. For instance, for an Edje object of maximum size 100x100 pixels: collections { group { name: &quot;a_group&quot;; max: 100 100; } }
        /// 
        /// <b>NOTE: </b>If the <c>max</c> EDC property was not declared for the object, this call will return the maximum size a given Edje object may have, for each axis.
        /// 
        /// <b>NOTE: </b>On failure, this function will return 0x0.
        /// 
        /// See also <see cref="CoreUI.Layout.IGroup.GetGroupSizeMin"/>.</summary>
        /// <returns>The maximum size as set in EDC.</returns>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.DataTypes.Size2D GetGroupSizeMax();

        /// <summary>The EDC data field&apos;s value from a given Edje object&apos;s group.
        /// 
        /// This property represents an EDC data field&apos;s value, which is declared on the objects building EDC file, under its group. EDC data blocks are most commonly used to pass arbitrary parameters from an application&apos;s theme to its code.
        /// 
        /// EDC data fields always hold  strings as values, hence the return type of this function. Check the complete &quot;syntax reference&quot; for EDC files.
        /// 
        /// This is how a data item is defined in EDC: collections { group { name: &quot;a_group&quot;; data { item: &quot;key1&quot; &quot;value1&quot;; item: &quot;key2&quot; &quot;value2&quot;; } } }
        /// 
        /// <b>WARNING: </b>Do not confuse this call with edje_file_data_get(), which queries for a global EDC data field on an EDC declaration file.</summary>
        /// <param name="key">The data field&apos;s key string</param>
        /// <returns>The data&apos;s value string.</returns>
        /// <since_tizen> 6 </since_tizen>
        System.String GetGroupData(System.String key);

        /// <summary>Whether the given part exists in this group.
        /// 
        /// This is mostly equivalent to verifying the part type on the object as would be done in C as follows: (efl_canvas_layout_part_type_get(efl_part(obj, &quot;partname&quot;)) != EFL_CANVAS_LAYOUT_PART_TYPE_NONE)
        /// 
        /// The differences are that will silently return <c>false</c> if the part does not exist, and this will return <c>true</c> if the part is of type <c>SPACER</c> in the EDC file (<c>SPACER</c> parts have type <c>NONE</c>).
        /// 
        /// See also <span class="text-muted">CoreUI.Canvas.LayoutPart.GetPartType (object still in beta stage)</span>.</summary>
        /// <param name="part">The part name to check.</param>
        /// <returns><c>true</c> if the part exists, <c>false</c> otherwise.</returns>
        /// <since_tizen> 6 </since_tizen>
        bool GetPartExist(System.String part);

        /// <summary>The minimum size specified -- as an EDC property -- for a given Edje object
        /// 
        /// This property retrieves the obj object&apos;s minimum size values, as declared in its EDC group definition. For instance, for an Edje object of minimum size 100x100 pixels: collections { group { name: &quot;a_group&quot;; min: 100 100; } }
        /// 
        /// <b>NOTE: </b>If the <c>min</c> EDC property was not declared for this object, this call will return 0x0.
        /// 
        /// <b>NOTE: </b>On failure, this function also return 0x0.
        /// 
        /// See also <see cref="CoreUI.Layout.IGroup.GetGroupSizeMax"/>.</summary>
        /// <value>The minimum size as set in EDC.</value>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.DataTypes.Size2D GroupSizeMin {
            get;
        }

        /// <summary>The maximum size specified -- as an EDC property -- for a given Edje object
        /// 
        /// This property retrieves the object&apos;s maximum size values, as declared in its EDC group definition. For instance, for an Edje object of maximum size 100x100 pixels: collections { group { name: &quot;a_group&quot;; max: 100 100; } }
        /// 
        /// <b>NOTE: </b>If the <c>max</c> EDC property was not declared for the object, this call will return the maximum size a given Edje object may have, for each axis.
        /// 
        /// <b>NOTE: </b>On failure, this function will return 0x0.
        /// 
        /// See also <see cref="CoreUI.Layout.IGroup.GetGroupSizeMin"/>.</summary>
        /// <value>The maximum size as set in EDC.</value>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.DataTypes.Size2D GroupSizeMax {
            get;
        }

    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class IGroupNativeMethods : CoreUI.Wrapper.ObjectWrapper.NativeMethods
    {
        [System.Runtime.InteropServices.DllImport(CoreUI.Libs.Edje)] internal static extern System.IntPtr
            efl_layout_group_interface_get();
        private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.Edje);

        /// <summary>Gets the list of Eo operations to override.
    /// </summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
            var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

            if (efl_layout_group_size_min_get_static_delegate == null)
            {
                efl_layout_group_size_min_get_static_delegate = new efl_layout_group_size_min_get_delegate(group_size_min_get);
            }

            if (methods.Contains("GetGroupSizeMin"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_layout_group_size_min_get"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_group_size_min_get_static_delegate) });
            }

            if (efl_layout_group_size_max_get_static_delegate == null)
            {
                efl_layout_group_size_max_get_static_delegate = new efl_layout_group_size_max_get_delegate(group_size_max_get);
            }

            if (methods.Contains("GetGroupSizeMax"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_layout_group_size_max_get"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_group_size_max_get_static_delegate) });
            }

            if (efl_layout_group_data_get_static_delegate == null)
            {
                efl_layout_group_data_get_static_delegate = new efl_layout_group_data_get_delegate(group_data_get);
            }

            if (methods.Contains("GetGroupData"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_layout_group_data_get"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_group_data_get_static_delegate) });
            }

            if (efl_layout_group_part_exist_get_static_delegate == null)
            {
                efl_layout_group_part_exist_get_static_delegate = new efl_layout_group_part_exist_get_delegate(part_exist_get);
            }

            if (methods.Contains("GetPartExist"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_layout_group_part_exist_get"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_group_part_exist_get_static_delegate) });
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
            return efl_layout_group_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate CoreUI.DataTypes.Size2D efl_layout_group_size_min_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate CoreUI.DataTypes.Size2D efl_layout_group_size_min_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_layout_group_size_min_get_api_delegate> efl_layout_group_size_min_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_layout_group_size_min_get_api_delegate>(Module, "efl_layout_group_size_min_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static CoreUI.DataTypes.Size2D group_size_min_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_layout_group_size_min_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.DataTypes.Size2D _ret_var = default(CoreUI.DataTypes.Size2D);
                try
                {
                    _ret_var = ((IGroup)ws.Target).GetGroupSizeMin();
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
                return efl_layout_group_size_min_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_layout_group_size_min_get_delegate efl_layout_group_size_min_get_static_delegate;

        
        private delegate CoreUI.DataTypes.Size2D efl_layout_group_size_max_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate CoreUI.DataTypes.Size2D efl_layout_group_size_max_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_layout_group_size_max_get_api_delegate> efl_layout_group_size_max_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_layout_group_size_max_get_api_delegate>(Module, "efl_layout_group_size_max_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static CoreUI.DataTypes.Size2D group_size_max_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_layout_group_size_max_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.DataTypes.Size2D _ret_var = default(CoreUI.DataTypes.Size2D);
                try
                {
                    _ret_var = ((IGroup)ws.Target).GetGroupSizeMax();
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
                return efl_layout_group_size_max_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_layout_group_size_max_get_delegate efl_layout_group_size_max_get_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_layout_group_data_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String key);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))]
        internal delegate System.String efl_layout_group_data_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String key);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_layout_group_data_get_api_delegate> efl_layout_group_data_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_layout_group_data_get_api_delegate>(Module, "efl_layout_group_data_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static System.String group_data_get(System.IntPtr obj, System.IntPtr pd, System.String key)
        {
            CoreUI.DataTypes.Log.Debug("function efl_layout_group_data_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((IGroup)ws.Target).GetGroupData(key);
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
                return efl_layout_group_data_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), key);
            }
        }

        private static efl_layout_group_data_get_delegate efl_layout_group_data_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_layout_group_part_exist_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String part);

        [return: MarshalAs(UnmanagedType.U1)]
        internal delegate bool efl_layout_group_part_exist_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String part);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_layout_group_part_exist_get_api_delegate> efl_layout_group_part_exist_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_layout_group_part_exist_get_api_delegate>(Module, "efl_layout_group_part_exist_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static bool part_exist_get(System.IntPtr obj, System.IntPtr pd, System.String part)
        {
            CoreUI.DataTypes.Log.Debug("function efl_layout_group_part_exist_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IGroup)ws.Target).GetPartExist(part);
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
                return efl_layout_group_part_exist_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), part);
            }
        }

        private static efl_layout_group_part_exist_get_delegate efl_layout_group_part_exist_get_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

    }
}

