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
    /// <summary>Interface for getting access to a range of selected items through their indices.
    /// 
    /// The implementor of this interface provides the possibility to select multiple <see cref="CoreUI.UI.ISelectable"/> objects. If not, only <see cref="CoreUI.UI.ISingleSelectable"/> should be implemented. A widget can only provide either this interface or <see cref="CoreUI.UI.IMultiSelectableObjectRange"/>, but not both.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.UI.IMultiSelectableIndexRangeNativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    public interface IMultiSelectableIndexRange : 
    CoreUI.UI.IMultiSelectable,
        CoreUI.Wrapper.IWrapper, IDisposable
    {
        /// <summary>Gets an iterator over the indices of all the selected children.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <returns>The iterator gives the indices of the selected children. It is valid until any change is made to the selection state.</returns>
        IEnumerable<uint> NewSelectedNdxIterator();

        /// <summary>Gets an iterator over the indices of all the unselected children.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <returns>The iterator gives the indices of the unselected children. It is valid until any change is made to the selection state.</returns>
        IEnumerable<uint> NewUnselectedNdxIterator();

    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class IMultiSelectableIndexRangeNativeMethods : CoreUI.Wrapper.ObjectWrapper.NativeMethods
    {
        [System.Runtime.InteropServices.DllImport(CoreUI.Libs.Elementary)] internal static extern System.IntPtr
            efl_ui_multi_selectable_index_range_interface_get();
        private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.Elementary);

        /// <summary>Gets the list of Eo operations to override.
    /// </summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
            var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

            if (efl_ui_multi_selectable_selected_ndx_iterator_new_static_delegate == null)
            {
                efl_ui_multi_selectable_selected_ndx_iterator_new_static_delegate = new efl_ui_multi_selectable_selected_ndx_iterator_new_delegate(selected_ndx_iterator_new);
            }

            if (methods.Contains("NewSelectedNdxIterator"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_multi_selectable_selected_ndx_iterator_new"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_multi_selectable_selected_ndx_iterator_new_static_delegate) });
            }

            if (efl_ui_multi_selectable_unselected_ndx_iterator_new_static_delegate == null)
            {
                efl_ui_multi_selectable_unselected_ndx_iterator_new_static_delegate = new efl_ui_multi_selectable_unselected_ndx_iterator_new_delegate(unselected_ndx_iterator_new);
            }

            if (methods.Contains("NewUnselectedNdxIterator"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_multi_selectable_unselected_ndx_iterator_new"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_multi_selectable_unselected_ndx_iterator_new_static_delegate) });
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
            return efl_ui_multi_selectable_index_range_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate System.IntPtr efl_ui_multi_selectable_selected_ndx_iterator_new_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate System.IntPtr efl_ui_multi_selectable_selected_ndx_iterator_new_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_multi_selectable_selected_ndx_iterator_new_api_delegate> efl_ui_multi_selectable_selected_ndx_iterator_new_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_multi_selectable_selected_ndx_iterator_new_api_delegate>(Module, "efl_ui_multi_selectable_selected_ndx_iterator_new");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static System.IntPtr selected_ndx_iterator_new(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_multi_selectable_selected_ndx_iterator_new was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                IEnumerable<uint> _ret_var = null;
                try
                {
                    _ret_var = ((IMultiSelectableIndexRange)ws.Target).NewSelectedNdxIterator();
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
                return efl_ui_multi_selectable_selected_ndx_iterator_new_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_ui_multi_selectable_selected_ndx_iterator_new_delegate efl_ui_multi_selectable_selected_ndx_iterator_new_static_delegate;

        
        private delegate System.IntPtr efl_ui_multi_selectable_unselected_ndx_iterator_new_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate System.IntPtr efl_ui_multi_selectable_unselected_ndx_iterator_new_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_multi_selectable_unselected_ndx_iterator_new_api_delegate> efl_ui_multi_selectable_unselected_ndx_iterator_new_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_multi_selectable_unselected_ndx_iterator_new_api_delegate>(Module, "efl_ui_multi_selectable_unselected_ndx_iterator_new");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static System.IntPtr unselected_ndx_iterator_new(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_multi_selectable_unselected_ndx_iterator_new was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                IEnumerable<uint> _ret_var = null;
                try
                {
                    _ret_var = ((IMultiSelectableIndexRange)ws.Target).NewUnselectedNdxIterator();
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
                return efl_ui_multi_selectable_unselected_ndx_iterator_new_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_ui_multi_selectable_unselected_ndx_iterator_new_delegate efl_ui_multi_selectable_unselected_ndx_iterator_new_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

    }
}

namespace CoreUI.UI {
#pragma warning disable CS1591
    /// <since_tizen> 6 </since_tizen>
    public static class MultiSelectableIndexRangeExtensions {
        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.UI.SelectMode> SelectMode<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.IMultiSelectableIndexRange, T>magic = null) where T : CoreUI.UI.IMultiSelectableIndexRange {
            return new CoreUI.BindableProperty<CoreUI.UI.SelectMode>("select_mode", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.UI.ISelectable> FallbackSelection<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.IMultiSelectableIndexRange, T>magic = null) where T : CoreUI.UI.IMultiSelectableIndexRange {
            return new CoreUI.BindableProperty<CoreUI.UI.ISelectable>("fallback_selection", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> AllowManualDeselection<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.IMultiSelectableIndexRange, T>magic = null) where T : CoreUI.UI.IMultiSelectableIndexRange {
            return new CoreUI.BindableProperty<bool>("allow_manual_deselection", fac.GetPropBind());
        }

    }
#pragma warning restore CS1591
}

