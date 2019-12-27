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
    /// <summary>Selectable interface for UI objects
    /// 
    /// An object implementing this interface can be selected. When the selected property of this object changes, the <see cref="CoreUI.UI.ISelectable.SelectedChanged"/> event is emitted.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.UI.ISelectableNativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    public interface ISelectable : 
        CoreUI.Wrapper.IWrapper, IDisposable
    {
        /// <summary>The selected state of this object
        /// 
        /// A change to this property emits the changed event.</summary>
        /// <returns>The selected state of this object.</returns>
        /// <since_tizen> 6 </since_tizen>
        bool GetSelected();

        /// <summary>The selected state of this object
        /// 
        /// A change to this property emits the changed event.</summary>
        /// <param name="selected">The selected state of this object.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetSelected(bool selected);

        /// <summary>Called when the selected state has changed.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.UI.SelectableSelectedChangedEventArgs"/></value>
        event EventHandler<CoreUI.UI.SelectableSelectedChangedEventArgs> SelectedChanged;
        /// <summary>The selected state of this object
        /// 
        /// A change to this property emits the changed event.</summary>
        /// <value>The selected state of this object.</value>
        /// <since_tizen> 6 </since_tizen>
        bool Selected {
            get;
            set;
        }

    }

    /// <summary>Event argument wrapper for event <see cref="CoreUI.UI.ISelectable.SelectedChanged"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Wrapper.BindingEntity]
    public class SelectableSelectedChangedEventArgs : EventArgs {
        /// <summary>Actual event payload.
        /// </summary>
        /// <value>Called when the selected state has changed.</value>
        /// <since_tizen> 6 </since_tizen>
        public bool Arg { get; set; }
    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class ISelectableNativeMethods : CoreUI.Wrapper.ObjectWrapper.NativeMethods
    {
        [System.Runtime.InteropServices.DllImport(CoreUI.Libs.Elementary)] internal static extern System.IntPtr
            efl_ui_selectable_interface_get();
        private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.Elementary);

        /// <summary>Gets the list of Eo operations to override.
    /// </summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
            var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

            if (efl_ui_selectable_selected_get_static_delegate == null)
            {
                efl_ui_selectable_selected_get_static_delegate = new efl_ui_selectable_selected_get_delegate(selected_get);
            }

            if (methods.Contains("GetSelected"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_selectable_selected_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_selectable_selected_get_static_delegate) });
            }

            if (efl_ui_selectable_selected_set_static_delegate == null)
            {
                efl_ui_selectable_selected_set_static_delegate = new efl_ui_selectable_selected_set_delegate(selected_set);
            }

            if (methods.Contains("SetSelected"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_selectable_selected_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_selectable_selected_set_static_delegate) });
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
            return efl_ui_selectable_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_selectable_selected_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        internal delegate bool efl_ui_selectable_selected_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_selectable_selected_get_api_delegate> efl_ui_selectable_selected_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_selectable_selected_get_api_delegate>(Module, "efl_ui_selectable_selected_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static bool selected_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_selectable_selected_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((ISelectable)ws.Target).GetSelected();
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
                return efl_ui_selectable_selected_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_ui_selectable_selected_get_delegate efl_ui_selectable_selected_get_static_delegate;

        
        private delegate void efl_ui_selectable_selected_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool selected);

        
        internal delegate void efl_ui_selectable_selected_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool selected);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_selectable_selected_set_api_delegate> efl_ui_selectable_selected_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_selectable_selected_set_api_delegate>(Module, "efl_ui_selectable_selected_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void selected_set(System.IntPtr obj, System.IntPtr pd, bool selected)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_selectable_selected_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((ISelectable)ws.Target).SetSelected(selected);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_selectable_selected_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), selected);
            }
        }

        private static efl_ui_selectable_selected_set_delegate efl_ui_selectable_selected_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

    }
}

namespace CoreUI.UI {
#pragma warning disable CS1591
    /// <since_tizen> 6 </since_tizen>
    public static class SelectableExtensions {
        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> Selected<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.ISelectable, T>magic = null) where T : CoreUI.UI.ISelectable {
            return new CoreUI.BindableProperty<bool>("selected", fac.GetPropBind());
        }

    }
#pragma warning restore CS1591
}

