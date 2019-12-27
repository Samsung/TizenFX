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
namespace CoreUI.Gfx {
    /// <summary>CoreUI Gfx Color mixin class</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Gfx.IColorNativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    public interface IColor : 
        CoreUI.Wrapper.IWrapper, IDisposable
    {
        /// <summary>The general/main color of the given Evas object.
        /// 
        /// Represents the main color&apos;s RGB component (and alpha channel) values, which range from 0 to 255. For the alpha channel, which defines the object&apos;s transparency level, 0 means totally transparent, while 255 means opaque. These color values are premultiplied by the alpha value.
        /// 
        /// Usually you&apos;ll use this attribute for text and rectangle objects, where the main color is the only color. If set for objects which themselves have colors, like the images one, those colors get modulated by this one.
        /// 
        /// All newly created Evas rectangles get the default color values of 255 255 255 255 (opaque white).
        /// 
        /// When reading this property, use <c>NULL</c> pointers on the components you&apos;re not interested in and they&apos;ll be ignored by the function.</summary>
        /// <since_tizen> 6 </since_tizen>
        void GetColor(out int r, out int g, out int b, out int a);

        /// <summary>The general/main color of the given Evas object.
        /// 
        /// Represents the main color&apos;s RGB component (and alpha channel) values, which range from 0 to 255. For the alpha channel, which defines the object&apos;s transparency level, 0 means totally transparent, while 255 means opaque. These color values are premultiplied by the alpha value.
        /// 
        /// Usually you&apos;ll use this attribute for text and rectangle objects, where the main color is the only color. If set for objects which themselves have colors, like the images one, those colors get modulated by this one.
        /// 
        /// All newly created Evas rectangles get the default color values of 255 255 255 255 (opaque white).
        /// 
        /// When reading this property, use <c>NULL</c> pointers on the components you&apos;re not interested in and they&apos;ll be ignored by the function.</summary>
        /// <since_tizen> 6 </since_tizen>
        void SetColor(int r, int g, int b, int a);

        /// <summary>Hexadecimal color code of given Evas object (#RRGGBBAA).</summary>
        /// <returns>the hex color code.</returns>
        /// <since_tizen> 6 </since_tizen>
        System.String GetColorCode();

        /// <summary>Hexadecimal color code of given Evas object (#RRGGBBAA).</summary>
        /// <param name="colorcode">the hex color code.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetColorCode(System.String colorcode);

        /// <summary>The general/main color of the given Evas object.
        /// 
        /// Represents the main color&apos;s RGB component (and alpha channel) values, which range from 0 to 255. For the alpha channel, which defines the object&apos;s transparency level, 0 means totally transparent, while 255 means opaque. These color values are premultiplied by the alpha value.
        /// 
        /// Usually you&apos;ll use this attribute for text and rectangle objects, where the main color is the only color. If set for objects which themselves have colors, like the images one, those colors get modulated by this one.
        /// 
        /// All newly created Evas rectangles get the default color values of 255 255 255 255 (opaque white).
        /// 
        /// When reading this property, use <c>NULL</c> pointers on the components you&apos;re not interested in and they&apos;ll be ignored by the function.</summary>
        /// <since_tizen> 6 </since_tizen>
        (int, int, int, int) Color {
            get;
            set;
        }

        /// <summary>Hexadecimal color code of given Evas object (#RRGGBBAA).</summary>
        /// <value>the hex color code.</value>
        /// <since_tizen> 6 </since_tizen>
        System.String ColorCode {
            get;
            set;
        }

    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class IColorNativeMethods : CoreUI.Wrapper.ObjectWrapper.NativeMethods
    {
        [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
            efl_gfx_color_mixin_get();
        private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.CoreUI);

        /// <summary>Gets the list of Eo operations to override.
    /// </summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
            var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

            if (efl_gfx_color_get_static_delegate == null)
            {
                efl_gfx_color_get_static_delegate = new efl_gfx_color_get_delegate(color_get);
            }

            if (methods.Contains("GetColor"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_color_get_static_delegate) });
            }

            if (efl_gfx_color_set_static_delegate == null)
            {
                efl_gfx_color_set_static_delegate = new efl_gfx_color_set_delegate(color_set);
            }

            if (methods.Contains("SetColor"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_color_set_static_delegate) });
            }

            if (efl_gfx_color_code_get_static_delegate == null)
            {
                efl_gfx_color_code_get_static_delegate = new efl_gfx_color_code_get_delegate(color_code_get);
            }

            if (methods.Contains("GetColorCode"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_color_code_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_color_code_get_static_delegate) });
            }

            if (efl_gfx_color_code_set_static_delegate == null)
            {
                efl_gfx_color_code_set_static_delegate = new efl_gfx_color_code_set_delegate(color_code_set);
            }

            if (methods.Contains("SetColorCode"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_color_code_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_color_code_set_static_delegate) });
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
            return efl_gfx_color_mixin_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate void efl_gfx_color_get_delegate(System.IntPtr obj, System.IntPtr pd,  out int r,  out int g,  out int b,  out int a);

        
        internal delegate void efl_gfx_color_get_api_delegate(System.IntPtr obj,  out int r,  out int g,  out int b,  out int a);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_color_get_api_delegate> efl_gfx_color_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_color_get_api_delegate>(Module, "efl_gfx_color_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void color_get(System.IntPtr obj, System.IntPtr pd, out int r, out int g, out int b, out int a)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_color_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                r = default(int);g = default(int);b = default(int);a = default(int);
                try
                {
                    ((IColor)ws.Target).GetColor(out r, out g, out b, out a);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_color_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), out r, out g, out b, out a);
            }
        }

        private static efl_gfx_color_get_delegate efl_gfx_color_get_static_delegate;

        
        private delegate void efl_gfx_color_set_delegate(System.IntPtr obj, System.IntPtr pd,  int r,  int g,  int b,  int a);

        
        internal delegate void efl_gfx_color_set_api_delegate(System.IntPtr obj,  int r,  int g,  int b,  int a);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_color_set_api_delegate> efl_gfx_color_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_color_set_api_delegate>(Module, "efl_gfx_color_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void color_set(System.IntPtr obj, System.IntPtr pd, int r, int g, int b, int a)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_color_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IColor)ws.Target).SetColor(r, g, b, a);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_color_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), r, g, b, a);
            }
        }

        private static efl_gfx_color_set_delegate efl_gfx_color_set_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_gfx_color_code_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))]
        internal delegate System.String efl_gfx_color_code_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_color_code_get_api_delegate> efl_gfx_color_code_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_color_code_get_api_delegate>(Module, "efl_gfx_color_code_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static System.String color_code_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_color_code_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((IColor)ws.Target).GetColorCode();
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
                return efl_gfx_color_code_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_gfx_color_code_get_delegate efl_gfx_color_code_get_static_delegate;

        
        private delegate void efl_gfx_color_code_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String colorcode);

        
        internal delegate void efl_gfx_color_code_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String colorcode);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_color_code_set_api_delegate> efl_gfx_color_code_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_color_code_set_api_delegate>(Module, "efl_gfx_color_code_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void color_code_set(System.IntPtr obj, System.IntPtr pd, System.String colorcode)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_color_code_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IColor)ws.Target).SetColorCode(colorcode);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_color_code_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), colorcode);
            }
        }

        private static efl_gfx_color_code_set_delegate efl_gfx_color_code_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

    }
}

namespace CoreUI.Gfx {
#pragma warning disable CS1591
    /// <since_tizen> 6 </since_tizen>
    public static class ColorExtensions {
        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<System.String> ColorCode<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Gfx.IColor, T>magic = null) where T : CoreUI.Gfx.IColor {
            return new CoreUI.BindableProperty<System.String>("color_code", fac.GetPropBind());
        }

    }
#pragma warning restore CS1591
}

