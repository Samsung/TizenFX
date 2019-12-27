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
    /// <summary>CoreUI screen interface</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.IScreenNativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    public interface IScreen : 
        CoreUI.Wrapper.IWrapper, IDisposable
    {
        /// <summary>Screen size (in pixels) for the screen.
        /// 
        /// Note that on some display systems this information is not available and a value of 0x0 will be returned.</summary>
        /// <returns>The screen size in pixels.</returns>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.DataTypes.Size2D GetScreenSizeInPixels();

        /// <summary>Screen scaling factor.
        /// 
        /// This is the factor by which window contents will be scaled on the screen.
        /// 
        /// Note that on some display systems this information is not available and a value of 1.0 will be returned.</summary>
        /// <returns>The screen scaling factor.</returns>
        /// <since_tizen> 6 </since_tizen>
        float GetScreenScaleFactor();

        /// <summary>The rotation of the screen.
        /// 
        /// Most engines only return multiples of 90.</summary>
        /// <returns>Screen rotation in degrees.</returns>
        /// <since_tizen> 6 </since_tizen>
        int GetScreenRotation();

        /// <summary>The pixel density in DPI (Dots Per Inch) for the screen that a window is on.</summary>
        /// <param name="xdpi">Horizontal DPI.</param>
        /// <param name="ydpi">Vertical DPI.</param>
        /// <since_tizen> 6 </since_tizen>
        void GetScreenDpi(out int xdpi, out int ydpi);

        /// <summary>Screen size (in pixels) for the screen.
        /// 
        /// Note that on some display systems this information is not available and a value of 0x0 will be returned.</summary>
        /// <value>The screen size in pixels.</value>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.DataTypes.Size2D ScreenSizeInPixels {
            get;
        }

        /// <summary>Screen scaling factor.
        /// 
        /// This is the factor by which window contents will be scaled on the screen.
        /// 
        /// Note that on some display systems this information is not available and a value of 1.0 will be returned.</summary>
        /// <value>The screen scaling factor.</value>
        /// <since_tizen> 6 </since_tizen>
        float ScreenScaleFactor {
            get;
        }

        /// <summary>The rotation of the screen.
        /// 
        /// Most engines only return multiples of 90.</summary>
        /// <value>Screen rotation in degrees.</value>
        /// <since_tizen> 6 </since_tizen>
        int ScreenRotation {
            get;
        }

        /// <summary>The pixel density in DPI (Dots Per Inch) for the screen that a window is on.</summary>
        /// <since_tizen> 6 </since_tizen>
        (int, int) ScreenDpi {
            get;
        }

    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class IScreenNativeMethods : CoreUI.Wrapper.ObjectWrapper.NativeMethods
    {
        [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
            efl_screen_interface_get();
        private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.CoreUI);

        /// <summary>Gets the list of Eo operations to override.
    /// </summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
            var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

            if (efl_screen_size_in_pixels_get_static_delegate == null)
            {
                efl_screen_size_in_pixels_get_static_delegate = new efl_screen_size_in_pixels_get_delegate(screen_size_in_pixels_get);
            }

            if (methods.Contains("GetScreenSizeInPixels"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_screen_size_in_pixels_get"), func = Marshal.GetFunctionPointerForDelegate(efl_screen_size_in_pixels_get_static_delegate) });
            }

            if (efl_screen_scale_factor_get_static_delegate == null)
            {
                efl_screen_scale_factor_get_static_delegate = new efl_screen_scale_factor_get_delegate(screen_scale_factor_get);
            }

            if (methods.Contains("GetScreenScaleFactor"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_screen_scale_factor_get"), func = Marshal.GetFunctionPointerForDelegate(efl_screen_scale_factor_get_static_delegate) });
            }

            if (efl_screen_rotation_get_static_delegate == null)
            {
                efl_screen_rotation_get_static_delegate = new efl_screen_rotation_get_delegate(screen_rotation_get);
            }

            if (methods.Contains("GetScreenRotation"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_screen_rotation_get"), func = Marshal.GetFunctionPointerForDelegate(efl_screen_rotation_get_static_delegate) });
            }

            if (efl_screen_dpi_get_static_delegate == null)
            {
                efl_screen_dpi_get_static_delegate = new efl_screen_dpi_get_delegate(screen_dpi_get);
            }

            if (methods.Contains("GetScreenDpi"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_screen_dpi_get"), func = Marshal.GetFunctionPointerForDelegate(efl_screen_dpi_get_static_delegate) });
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
            return efl_screen_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate CoreUI.DataTypes.Size2D efl_screen_size_in_pixels_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate CoreUI.DataTypes.Size2D efl_screen_size_in_pixels_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_screen_size_in_pixels_get_api_delegate> efl_screen_size_in_pixels_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_screen_size_in_pixels_get_api_delegate>(Module, "efl_screen_size_in_pixels_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static CoreUI.DataTypes.Size2D screen_size_in_pixels_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_screen_size_in_pixels_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.DataTypes.Size2D _ret_var = default(CoreUI.DataTypes.Size2D);
                try
                {
                    _ret_var = ((IScreen)ws.Target).GetScreenSizeInPixels();
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
                return efl_screen_size_in_pixels_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_screen_size_in_pixels_get_delegate efl_screen_size_in_pixels_get_static_delegate;

        
        private delegate float efl_screen_scale_factor_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate float efl_screen_scale_factor_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_screen_scale_factor_get_api_delegate> efl_screen_scale_factor_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_screen_scale_factor_get_api_delegate>(Module, "efl_screen_scale_factor_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static float screen_scale_factor_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_screen_scale_factor_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                float _ret_var = default(float);
                try
                {
                    _ret_var = ((IScreen)ws.Target).GetScreenScaleFactor();
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
                return efl_screen_scale_factor_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_screen_scale_factor_get_delegate efl_screen_scale_factor_get_static_delegate;

        
        private delegate int efl_screen_rotation_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate int efl_screen_rotation_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_screen_rotation_get_api_delegate> efl_screen_rotation_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_screen_rotation_get_api_delegate>(Module, "efl_screen_rotation_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static int screen_rotation_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_screen_rotation_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                int _ret_var = default(int);
                try
                {
                    _ret_var = ((IScreen)ws.Target).GetScreenRotation();
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
                return efl_screen_rotation_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_screen_rotation_get_delegate efl_screen_rotation_get_static_delegate;

        
        private delegate void efl_screen_dpi_get_delegate(System.IntPtr obj, System.IntPtr pd,  out int xdpi,  out int ydpi);

        
        internal delegate void efl_screen_dpi_get_api_delegate(System.IntPtr obj,  out int xdpi,  out int ydpi);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_screen_dpi_get_api_delegate> efl_screen_dpi_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_screen_dpi_get_api_delegate>(Module, "efl_screen_dpi_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void screen_dpi_get(System.IntPtr obj, System.IntPtr pd, out int xdpi, out int ydpi)
        {
            CoreUI.DataTypes.Log.Debug("function efl_screen_dpi_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                xdpi = default(int);ydpi = default(int);
                try
                {
                    ((IScreen)ws.Target).GetScreenDpi(out xdpi, out ydpi);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_screen_dpi_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), out xdpi, out ydpi);
            }
        }

        private static efl_screen_dpi_get_delegate efl_screen_dpi_get_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

    }
}

