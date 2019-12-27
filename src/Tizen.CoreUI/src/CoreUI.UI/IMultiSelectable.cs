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
    /// <summary>Interface for getting access to a range of selected items.
    /// 
    /// The implementor of this interface provides the possibility to select multiple Selectables. If not, only <see cref="CoreUI.UI.ISingleSelectable"/> should be implemented.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.UI.IMultiSelectableNativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    public interface IMultiSelectable : 
    CoreUI.UI.ISingleSelectable,
        CoreUI.Wrapper.IWrapper, IDisposable
    {
        /// <summary>The mode type for children selection.</summary>
        /// <returns>Type of selection of children</returns>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.UI.SelectMode GetSelectMode();

        /// <summary>The mode type for children selection.</summary>
        /// <param name="mode">Type of selection of children</param>
        /// <since_tizen> 6 </since_tizen>
        void SetSelectMode(CoreUI.UI.SelectMode mode);

        /// <summary>Select all <see cref="CoreUI.UI.ISelectable"/></summary>
        /// <since_tizen> 6 </since_tizen>
        void SelectAll();

        /// <summary>Unselect all <see cref="CoreUI.UI.ISelectable"/></summary>
        /// <since_tizen> 6 </since_tizen>
        void UnselectAll();

        /// <summary>The mode type for children selection.</summary>
        /// <value>Type of selection of children</value>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.UI.SelectMode SelectMode {
            get;
            set;
        }

    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class IMultiSelectableNativeMethods : CoreUI.Wrapper.ObjectWrapper.NativeMethods
    {
        [System.Runtime.InteropServices.DllImport(CoreUI.Libs.Elementary)] internal static extern System.IntPtr
            efl_ui_multi_selectable_interface_get();
        private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.Elementary);

        /// <summary>Gets the list of Eo operations to override.
    /// </summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
            var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

            if (efl_ui_multi_selectable_select_mode_get_static_delegate == null)
            {
                efl_ui_multi_selectable_select_mode_get_static_delegate = new efl_ui_multi_selectable_select_mode_get_delegate(select_mode_get);
            }

            if (methods.Contains("GetSelectMode"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_multi_selectable_select_mode_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_multi_selectable_select_mode_get_static_delegate) });
            }

            if (efl_ui_multi_selectable_select_mode_set_static_delegate == null)
            {
                efl_ui_multi_selectable_select_mode_set_static_delegate = new efl_ui_multi_selectable_select_mode_set_delegate(select_mode_set);
            }

            if (methods.Contains("SetSelectMode"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_multi_selectable_select_mode_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_multi_selectable_select_mode_set_static_delegate) });
            }

            if (efl_ui_multi_selectable_all_select_static_delegate == null)
            {
                efl_ui_multi_selectable_all_select_static_delegate = new efl_ui_multi_selectable_all_select_delegate(all_select);
            }

            if (methods.Contains("SelectAll"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_multi_selectable_all_select"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_multi_selectable_all_select_static_delegate) });
            }

            if (efl_ui_multi_selectable_all_unselect_static_delegate == null)
            {
                efl_ui_multi_selectable_all_unselect_static_delegate = new efl_ui_multi_selectable_all_unselect_delegate(all_unselect);
            }

            if (methods.Contains("UnselectAll"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_multi_selectable_all_unselect"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_multi_selectable_all_unselect_static_delegate) });
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
            return efl_ui_multi_selectable_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate CoreUI.UI.SelectMode efl_ui_multi_selectable_select_mode_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate CoreUI.UI.SelectMode efl_ui_multi_selectable_select_mode_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_multi_selectable_select_mode_get_api_delegate> efl_ui_multi_selectable_select_mode_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_multi_selectable_select_mode_get_api_delegate>(Module, "efl_ui_multi_selectable_select_mode_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static CoreUI.UI.SelectMode select_mode_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_multi_selectable_select_mode_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.UI.SelectMode _ret_var = default(CoreUI.UI.SelectMode);
                try
                {
                    _ret_var = ((IMultiSelectable)ws.Target).GetSelectMode();
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
                return efl_ui_multi_selectable_select_mode_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_ui_multi_selectable_select_mode_get_delegate efl_ui_multi_selectable_select_mode_get_static_delegate;

        
        private delegate void efl_ui_multi_selectable_select_mode_set_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.UI.SelectMode mode);

        
        internal delegate void efl_ui_multi_selectable_select_mode_set_api_delegate(System.IntPtr obj,  CoreUI.UI.SelectMode mode);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_multi_selectable_select_mode_set_api_delegate> efl_ui_multi_selectable_select_mode_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_multi_selectable_select_mode_set_api_delegate>(Module, "efl_ui_multi_selectable_select_mode_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void select_mode_set(System.IntPtr obj, System.IntPtr pd, CoreUI.UI.SelectMode mode)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_multi_selectable_select_mode_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IMultiSelectable)ws.Target).SetSelectMode(mode);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_multi_selectable_select_mode_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), mode);
            }
        }

        private static efl_ui_multi_selectable_select_mode_set_delegate efl_ui_multi_selectable_select_mode_set_static_delegate;

        
        private delegate void efl_ui_multi_selectable_all_select_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate void efl_ui_multi_selectable_all_select_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_multi_selectable_all_select_api_delegate> efl_ui_multi_selectable_all_select_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_multi_selectable_all_select_api_delegate>(Module, "efl_ui_multi_selectable_all_select");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void all_select(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_multi_selectable_all_select was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IMultiSelectable)ws.Target).SelectAll();
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_multi_selectable_all_select_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_ui_multi_selectable_all_select_delegate efl_ui_multi_selectable_all_select_static_delegate;

        
        private delegate void efl_ui_multi_selectable_all_unselect_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate void efl_ui_multi_selectable_all_unselect_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_multi_selectable_all_unselect_api_delegate> efl_ui_multi_selectable_all_unselect_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_multi_selectable_all_unselect_api_delegate>(Module, "efl_ui_multi_selectable_all_unselect");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void all_unselect(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_multi_selectable_all_unselect was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IMultiSelectable)ws.Target).UnselectAll();
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_multi_selectable_all_unselect_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_ui_multi_selectable_all_unselect_delegate efl_ui_multi_selectable_all_unselect_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

    }
}

namespace CoreUI.UI {
#pragma warning disable CS1591
    /// <since_tizen> 6 </since_tizen>
    public static class MultiSelectableExtensions {
        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.UI.SelectMode> SelectMode<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.IMultiSelectable, T>magic = null) where T : CoreUI.UI.IMultiSelectable {
            return new CoreUI.BindableProperty<CoreUI.UI.SelectMode>("select_mode", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.UI.ISelectable> FallbackSelection<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.IMultiSelectable, T>magic = null) where T : CoreUI.UI.IMultiSelectable {
            return new CoreUI.BindableProperty<CoreUI.UI.ISelectable>("fallback_selection", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> AllowManualDeselection<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.IMultiSelectable, T>magic = null) where T : CoreUI.UI.IMultiSelectable {
            return new CoreUI.BindableProperty<bool>("allow_manual_deselection", fac.GetPropBind());
        }

    }
#pragma warning restore CS1591
}

