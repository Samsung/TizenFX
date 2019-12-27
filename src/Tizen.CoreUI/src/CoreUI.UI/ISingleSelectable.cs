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
    /// <summary>Interface for getting access to a single selected item in the implementor.
    /// 
    /// The implementor is free to allow a specific number of selectables being selected or not. This interface just covers always the latest selected selectable.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.UI.ISingleSelectableNativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    public interface ISingleSelectable : 
        CoreUI.Wrapper.IWrapper, IDisposable
    {
        /// <summary>The selectable that was selected most recently.</summary>
        /// <returns>The latest selected item.</returns>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.UI.ISelectable GetLastSelected();

        /// <summary>A object that will be selected in case nothing is selected
        /// 
        /// A object set to this property will be selected instead of no item being selected. Which means, there will be always at least one element selected. If this property is <c>NULL</c>, the state of &quot;no item is selected&quot; can be reached.
        /// 
        /// Setting this property as a result of selection events results in undefined behavior.</summary>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.UI.ISelectable GetFallbackSelection();

        /// <summary>A object that will be selected in case nothing is selected
        /// 
        /// A object set to this property will be selected instead of no item being selected. Which means, there will be always at least one element selected. If this property is <c>NULL</c>, the state of &quot;no item is selected&quot; can be reached.
        /// 
        /// Setting this property as a result of selection events results in undefined behavior.</summary>
        /// <since_tizen> 6 </since_tizen>
        void SetFallbackSelection(CoreUI.UI.ISelectable fallback);

        /// <summary>This controlls if a selected item can be deselected due to clicking</summary>
        /// <returns><c>true</c> if clicking while selected results in a state change to unselected</returns>
        /// <since_tizen> 6 </since_tizen>
        bool GetAllowManualDeselection();

        /// <summary>This controlls if a selected item can be deselected due to clicking</summary>
        /// <param name="allow_manual_deselection"><c>true</c> if clicking while selected results in a state change to unselected</param>
        /// <since_tizen> 6 </since_tizen>
        void SetAllowManualDeselection(bool allow_manual_deselection);

        /// <summary>Emitted when there is a change in the selection state. This event will collect all the item selection change events that are happening within one loop iteration. This means, you will only get this event once, even if a lot of items have changed. If you are interested in detailed changes, subscribe to the individual <see cref="CoreUI.UI.ISelectable.SelectedChanged"/> events of each item.</summary>
        /// <since_tizen> 6 </since_tizen>
        event EventHandler SelectionChanged;
        /// <summary>The selectable that was selected most recently.</summary>
        /// <value>The latest selected item.</value>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.UI.ISelectable LastSelected {
            get;
        }

        /// <summary>A object that will be selected in case nothing is selected
        /// 
        /// A object set to this property will be selected instead of no item being selected. Which means, there will be always at least one element selected. If this property is <c>NULL</c>, the state of &quot;no item is selected&quot; can be reached.
        /// 
        /// Setting this property as a result of selection events results in undefined behavior.</summary>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.UI.ISelectable FallbackSelection {
            get;
            set;
        }

        /// <summary>This controlls if a selected item can be deselected due to clicking</summary>
        /// <value><c>true</c> if clicking while selected results in a state change to unselected</value>
        /// <since_tizen> 6 </since_tizen>
        bool AllowManualDeselection {
            get;
            set;
        }

    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class ISingleSelectableNativeMethods : CoreUI.Wrapper.ObjectWrapper.NativeMethods
    {
        [System.Runtime.InteropServices.DllImport(CoreUI.Libs.Elementary)] internal static extern System.IntPtr
            efl_ui_single_selectable_interface_get();
        private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.Elementary);

        /// <summary>Gets the list of Eo operations to override.
    /// </summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
            var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

            if (efl_ui_selectable_last_selected_get_static_delegate == null)
            {
                efl_ui_selectable_last_selected_get_static_delegate = new efl_ui_selectable_last_selected_get_delegate(last_selected_get);
            }

            if (methods.Contains("GetLastSelected"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_selectable_last_selected_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_selectable_last_selected_get_static_delegate) });
            }

            if (efl_ui_selectable_fallback_selection_get_static_delegate == null)
            {
                efl_ui_selectable_fallback_selection_get_static_delegate = new efl_ui_selectable_fallback_selection_get_delegate(fallback_selection_get);
            }

            if (methods.Contains("GetFallbackSelection"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_selectable_fallback_selection_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_selectable_fallback_selection_get_static_delegate) });
            }

            if (efl_ui_selectable_fallback_selection_set_static_delegate == null)
            {
                efl_ui_selectable_fallback_selection_set_static_delegate = new efl_ui_selectable_fallback_selection_set_delegate(fallback_selection_set);
            }

            if (methods.Contains("SetFallbackSelection"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_selectable_fallback_selection_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_selectable_fallback_selection_set_static_delegate) });
            }

            if (efl_ui_selectable_allow_manual_deselection_get_static_delegate == null)
            {
                efl_ui_selectable_allow_manual_deselection_get_static_delegate = new efl_ui_selectable_allow_manual_deselection_get_delegate(allow_manual_deselection_get);
            }

            if (methods.Contains("GetAllowManualDeselection"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_selectable_allow_manual_deselection_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_selectable_allow_manual_deselection_get_static_delegate) });
            }

            if (efl_ui_selectable_allow_manual_deselection_set_static_delegate == null)
            {
                efl_ui_selectable_allow_manual_deselection_set_static_delegate = new efl_ui_selectable_allow_manual_deselection_set_delegate(allow_manual_deselection_set);
            }

            if (methods.Contains("SetAllowManualDeselection"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_selectable_allow_manual_deselection_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_selectable_allow_manual_deselection_set_static_delegate) });
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
            return efl_ui_single_selectable_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
        private delegate CoreUI.UI.ISelectable efl_ui_selectable_last_selected_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
        internal delegate CoreUI.UI.ISelectable efl_ui_selectable_last_selected_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_selectable_last_selected_get_api_delegate> efl_ui_selectable_last_selected_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_selectable_last_selected_get_api_delegate>(Module, "efl_ui_selectable_last_selected_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static CoreUI.UI.ISelectable last_selected_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_selectable_last_selected_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.UI.ISelectable _ret_var = default(CoreUI.UI.ISelectable);
                try
                {
                    _ret_var = ((ISingleSelectable)ws.Target).GetLastSelected();
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
                return efl_ui_selectable_last_selected_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_ui_selectable_last_selected_get_delegate efl_ui_selectable_last_selected_get_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
        private delegate CoreUI.UI.ISelectable efl_ui_selectable_fallback_selection_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
        internal delegate CoreUI.UI.ISelectable efl_ui_selectable_fallback_selection_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_selectable_fallback_selection_get_api_delegate> efl_ui_selectable_fallback_selection_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_selectable_fallback_selection_get_api_delegate>(Module, "efl_ui_selectable_fallback_selection_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static CoreUI.UI.ISelectable fallback_selection_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_selectable_fallback_selection_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.UI.ISelectable _ret_var = default(CoreUI.UI.ISelectable);
                try
                {
                    _ret_var = ((ISingleSelectable)ws.Target).GetFallbackSelection();
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
                return efl_ui_selectable_fallback_selection_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_ui_selectable_fallback_selection_get_delegate efl_ui_selectable_fallback_selection_get_static_delegate;

        
        private delegate void efl_ui_selectable_fallback_selection_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.UI.ISelectable fallback);

        
        internal delegate void efl_ui_selectable_fallback_selection_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.UI.ISelectable fallback);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_selectable_fallback_selection_set_api_delegate> efl_ui_selectable_fallback_selection_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_selectable_fallback_selection_set_api_delegate>(Module, "efl_ui_selectable_fallback_selection_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void fallback_selection_set(System.IntPtr obj, System.IntPtr pd, CoreUI.UI.ISelectable fallback)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_selectable_fallback_selection_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((ISingleSelectable)ws.Target).SetFallbackSelection(fallback);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_selectable_fallback_selection_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), fallback);
            }
        }

        private static efl_ui_selectable_fallback_selection_set_delegate efl_ui_selectable_fallback_selection_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_selectable_allow_manual_deselection_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        internal delegate bool efl_ui_selectable_allow_manual_deselection_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_selectable_allow_manual_deselection_get_api_delegate> efl_ui_selectable_allow_manual_deselection_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_selectable_allow_manual_deselection_get_api_delegate>(Module, "efl_ui_selectable_allow_manual_deselection_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static bool allow_manual_deselection_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_selectable_allow_manual_deselection_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((ISingleSelectable)ws.Target).GetAllowManualDeselection();
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
                return efl_ui_selectable_allow_manual_deselection_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_ui_selectable_allow_manual_deselection_get_delegate efl_ui_selectable_allow_manual_deselection_get_static_delegate;

        
        private delegate void efl_ui_selectable_allow_manual_deselection_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool allow_manual_deselection);

        
        internal delegate void efl_ui_selectable_allow_manual_deselection_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool allow_manual_deselection);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_selectable_allow_manual_deselection_set_api_delegate> efl_ui_selectable_allow_manual_deselection_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_selectable_allow_manual_deselection_set_api_delegate>(Module, "efl_ui_selectable_allow_manual_deselection_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void allow_manual_deselection_set(System.IntPtr obj, System.IntPtr pd, bool allow_manual_deselection)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_selectable_allow_manual_deselection_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((ISingleSelectable)ws.Target).SetAllowManualDeselection(allow_manual_deselection);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_selectable_allow_manual_deselection_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), allow_manual_deselection);
            }
        }

        private static efl_ui_selectable_allow_manual_deselection_set_delegate efl_ui_selectable_allow_manual_deselection_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

    }
}

namespace CoreUI.UI {
#pragma warning disable CS1591
    /// <since_tizen> 6 </since_tizen>
    public static class SingleSelectableExtensions {
        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.UI.ISelectable> FallbackSelection<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.ISingleSelectable, T>magic = null) where T : CoreUI.UI.ISingleSelectable {
            return new CoreUI.BindableProperty<CoreUI.UI.ISelectable>("fallback_selection", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> AllowManualDeselection<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.ISingleSelectable, T>magic = null) where T : CoreUI.UI.ISingleSelectable {
            return new CoreUI.BindableProperty<bool>("allow_manual_deselection", fac.GetPropBind());
        }

    }
#pragma warning restore CS1591
}

