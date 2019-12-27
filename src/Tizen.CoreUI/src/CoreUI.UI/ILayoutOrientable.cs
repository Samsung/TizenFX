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
    /// <summary>Interface for UI objects which can have more than one orientation.
    /// 
    /// For example, sliders, which can be horizontal or vertical, or container boxes, which can arrange their elements in a horizontal or vertical fashion.
    /// 
    /// Compare with <see cref="CoreUI.Gfx.IImageOrientable"/> that works for images and includes rotation.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.UI.ILayoutOrientableNativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    public interface ILayoutOrientable : 
        CoreUI.Wrapper.IWrapper, IDisposable
    {
        /// <summary>Control the direction of a given widget.
        /// 
        /// Use this function to change how your widget is to be disposed: vertically or horizontally or inverted vertically or inverted horizontally.
        /// 
        /// Mirroring as defined in <span class="text-muted">CoreUI.UI.II18n (object still in beta stage)</span> can invert the <c>horizontal</c> direction: it is <c>ltr</c> by default, but becomes <c>rtl</c> if the object is mirrored.</summary>
        /// <returns>Direction of the widget.</returns>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.UI.LayoutOrientation GetOrientation();

        /// <summary>Control the direction of a given widget.
        /// 
        /// Use this function to change how your widget is to be disposed: vertically or horizontally or inverted vertically or inverted horizontally.
        /// 
        /// Mirroring as defined in <span class="text-muted">CoreUI.UI.II18n (object still in beta stage)</span> can invert the <c>horizontal</c> direction: it is <c>ltr</c> by default, but becomes <c>rtl</c> if the object is mirrored.</summary>
        /// <param name="dir">Direction of the widget.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetOrientation(CoreUI.UI.LayoutOrientation dir);

        /// <summary>Control the direction of a given widget.
        /// 
        /// Use this function to change how your widget is to be disposed: vertically or horizontally or inverted vertically or inverted horizontally.
        /// 
        /// Mirroring as defined in <span class="text-muted">CoreUI.UI.II18n (object still in beta stage)</span> can invert the <c>horizontal</c> direction: it is <c>ltr</c> by default, but becomes <c>rtl</c> if the object is mirrored.</summary>
        /// <value>Direction of the widget.</value>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.UI.LayoutOrientation Orientation {
            get;
            set;
        }

    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class ILayoutOrientableNativeMethods : CoreUI.Wrapper.ObjectWrapper.NativeMethods
    {
        [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
            efl_ui_layout_orientable_interface_get();
        private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.CoreUI);

        /// <summary>Gets the list of Eo operations to override.
    /// </summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
            var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

            if (efl_ui_layout_orientation_get_static_delegate == null)
            {
                efl_ui_layout_orientation_get_static_delegate = new efl_ui_layout_orientation_get_delegate(orientation_get);
            }

            if (methods.Contains("GetOrientation"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_layout_orientation_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_layout_orientation_get_static_delegate) });
            }

            if (efl_ui_layout_orientation_set_static_delegate == null)
            {
                efl_ui_layout_orientation_set_static_delegate = new efl_ui_layout_orientation_set_delegate(orientation_set);
            }

            if (methods.Contains("SetOrientation"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_layout_orientation_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_layout_orientation_set_static_delegate) });
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
            return efl_ui_layout_orientable_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate CoreUI.UI.LayoutOrientation efl_ui_layout_orientation_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate CoreUI.UI.LayoutOrientation efl_ui_layout_orientation_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_layout_orientation_get_api_delegate> efl_ui_layout_orientation_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_layout_orientation_get_api_delegate>(Module, "efl_ui_layout_orientation_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static CoreUI.UI.LayoutOrientation orientation_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_layout_orientation_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.UI.LayoutOrientation _ret_var = default(CoreUI.UI.LayoutOrientation);
                try
                {
                    _ret_var = ((ILayoutOrientable)ws.Target).GetOrientation();
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
                return efl_ui_layout_orientation_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_ui_layout_orientation_get_delegate efl_ui_layout_orientation_get_static_delegate;

        
        private delegate void efl_ui_layout_orientation_set_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.UI.LayoutOrientation dir);

        
        internal delegate void efl_ui_layout_orientation_set_api_delegate(System.IntPtr obj,  CoreUI.UI.LayoutOrientation dir);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_layout_orientation_set_api_delegate> efl_ui_layout_orientation_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_layout_orientation_set_api_delegate>(Module, "efl_ui_layout_orientation_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void orientation_set(System.IntPtr obj, System.IntPtr pd, CoreUI.UI.LayoutOrientation dir)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_layout_orientation_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((ILayoutOrientable)ws.Target).SetOrientation(dir);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_layout_orientation_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), dir);
            }
        }

        private static efl_ui_layout_orientation_set_delegate efl_ui_layout_orientation_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

    }
}

namespace CoreUI.UI {
#pragma warning disable CS1591
    /// <since_tizen> 6 </since_tizen>
    public static class LayoutOrientableExtensions {
        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.UI.LayoutOrientation> Orientation<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.ILayoutOrientable, T>magic = null) where T : CoreUI.UI.ILayoutOrientable {
            return new CoreUI.BindableProperty<CoreUI.UI.LayoutOrientation>("orientation", fac.GetPropBind());
        }

    }
#pragma warning restore CS1591
}

namespace CoreUI.UI {
    /// <summary>Orientation for UI objects and layouts that can have multiple configurations.
    /// 
    /// Select among <c>horizontal</c> or <c>vertical</c> orientations (or use <c>default</c> to let the object decide). Additionally, <c>inverted</c> can be added to reverse the direction along the selected axis.
    /// 
    /// Not to be confused with <see cref="CoreUI.Gfx.ImageOrientation"/> which is for images and canvases. This enum is used to define how widgets should expand and orient themselves, not to rotate images.
    /// 
    /// See also <see cref="CoreUI.UI.ILayoutOrientable"/>.</summary>
    /// <since_tizen> 6 </since_tizen>
    
    [CoreUI.Wrapper.BindingEntity]
    public enum LayoutOrientation
    {
        /// <summary>Default direction. Each widget may have a different default.</summary>
        /// <since_tizen> 6 </since_tizen>
        Default = 0,
        /// <summary>Horizontal direction, along the X axis. Usually left-to-right, but can be inverted.</summary>
        /// <since_tizen> 6 </since_tizen>
        Horizontal = 1,
        /// <summary>Vertical direction, along the Y axis. Usually downwards but can be inverted.</summary>
        /// <since_tizen> 6 </since_tizen>
        Vertical = 2,
        /// <summary>This bitmask can be used to isolate the axis value from the rest of bits.</summary>
        /// <since_tizen> 6 </since_tizen>
        AxisBitmask = 3,
        /// <summary>Add this value to make the object invert its default direction along the selected axis.</summary>
        /// <since_tizen> 6 </since_tizen>
        Inverted = 4,
    }
}

