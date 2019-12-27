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
    /// <summary>Interface for images which can be rotated or flipped (mirrored).
    /// 
    /// Compare with <see cref="CoreUI.UI.ILayoutOrientable"/> which works for layout objects and does not include rotation.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Gfx.IImageOrientableNativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    public interface IImageOrientable : 
        CoreUI.Wrapper.IWrapper, IDisposable
    {
        /// <summary>Control the orientation (rotation and flipping) of a visual object.
        /// 
        /// This can be used to set the rotation on an image or a window, for instance.</summary>
        /// <returns>The final orientation of the object.</returns>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.Gfx.ImageOrientation GetImageOrientation();

        /// <summary>Control the orientation (rotation and flipping) of a visual object.
        /// 
        /// This can be used to set the rotation on an image or a window, for instance.</summary>
        /// <param name="dir">The final orientation of the object.<br/>The default value is <see cref="CoreUI.Gfx.ImageOrientation.None"/>.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetImageOrientation(CoreUI.Gfx.ImageOrientation dir);

        /// <summary>Control the orientation (rotation and flipping) of a visual object.
        /// 
        /// This can be used to set the rotation on an image or a window, for instance.</summary>
        /// <value>The final orientation of the object.</value>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.Gfx.ImageOrientation ImageOrientation {
            get;
            set;
        }

    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class IImageOrientableNativeMethods : CoreUI.Wrapper.ObjectWrapper.NativeMethods
    {
        [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
            efl_gfx_image_orientable_interface_get();
        private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.CoreUI);

        /// <summary>Gets the list of Eo operations to override.
    /// </summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
            var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

            if (efl_gfx_image_orientation_get_static_delegate == null)
            {
                efl_gfx_image_orientation_get_static_delegate = new efl_gfx_image_orientation_get_delegate(image_orientation_get);
            }

            if (methods.Contains("GetImageOrientation"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_orientation_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_orientation_get_static_delegate) });
            }

            if (efl_gfx_image_orientation_set_static_delegate == null)
            {
                efl_gfx_image_orientation_set_static_delegate = new efl_gfx_image_orientation_set_delegate(image_orientation_set);
            }

            if (methods.Contains("SetImageOrientation"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_orientation_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_orientation_set_static_delegate) });
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
            return efl_gfx_image_orientable_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate CoreUI.Gfx.ImageOrientation efl_gfx_image_orientation_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate CoreUI.Gfx.ImageOrientation efl_gfx_image_orientation_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_orientation_get_api_delegate> efl_gfx_image_orientation_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_orientation_get_api_delegate>(Module, "efl_gfx_image_orientation_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static CoreUI.Gfx.ImageOrientation image_orientation_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_image_orientation_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.Gfx.ImageOrientation _ret_var = default(CoreUI.Gfx.ImageOrientation);
                try
                {
                    _ret_var = ((IImageOrientable)ws.Target).GetImageOrientation();
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
                return efl_gfx_image_orientation_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_gfx_image_orientation_get_delegate efl_gfx_image_orientation_get_static_delegate;

        
        private delegate void efl_gfx_image_orientation_set_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.Gfx.ImageOrientation dir);

        
        internal delegate void efl_gfx_image_orientation_set_api_delegate(System.IntPtr obj,  CoreUI.Gfx.ImageOrientation dir);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_orientation_set_api_delegate> efl_gfx_image_orientation_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_orientation_set_api_delegate>(Module, "efl_gfx_image_orientation_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void image_orientation_set(System.IntPtr obj, System.IntPtr pd, CoreUI.Gfx.ImageOrientation dir)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_image_orientation_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IImageOrientable)ws.Target).SetImageOrientation(dir);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_image_orientation_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), dir);
            }
        }

        private static efl_gfx_image_orientation_set_delegate efl_gfx_image_orientation_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

    }
}

namespace CoreUI.Gfx {
#pragma warning disable CS1591
    /// <since_tizen> 6 </since_tizen>
    public static class ImageOrientableExtensions {
        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.Gfx.ImageOrientation> ImageOrientation<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Gfx.IImageOrientable, T>magic = null) where T : CoreUI.Gfx.IImageOrientable {
            return new CoreUI.BindableProperty<CoreUI.Gfx.ImageOrientation>("image_orientation", fac.GetPropBind());
        }

    }
#pragma warning restore CS1591
}

namespace CoreUI.Gfx {
    /// <summary>An orientation type, to rotate and flip images.
    /// 
    /// This is similar to EXIF&apos;s orientation. Directional values (<c>up</c>, <c>down</c>, <c>left</c>, <c>right</c>) indicate the final direction in which the top of the image will be facing (e.g. a picture of a house will have its roof pointing to the right if the <c>right</c> orientation is used). Flipping values (<c>flip_horizontal</c> and <c>flip_vertical</c>) can be additionally added to produce a mirroring in each axis. Not to be confused with <see cref="CoreUI.UI.LayoutOrientation"/> which is meant for widgets, rather than images and canvases. This enum is used to rotate images, videos and the like.</summary>
    /// <since_tizen> 6 </since_tizen>
    
    [CoreUI.Wrapper.BindingEntity]
    public enum ImageOrientation
    {
        /// <summary>Default, same as up, do not rotate.</summary>
        /// <since_tizen> 6 </since_tizen>
        None = 0,
        /// <summary>Orient up, do not rotate.</summary>
        /// <since_tizen> 6 </since_tizen>
        Up = 0,
        /// <summary>Orient right, rotate 90 degrees clock-wise.</summary>
        /// <since_tizen> 6 </since_tizen>
        Right = 1,
        /// <summary>Orient down, rotate 180 degrees.</summary>
        /// <since_tizen> 6 </since_tizen>
        Down = 2,
        /// <summary>Orient left, rotate 270 degrees clock-wise.</summary>
        /// <since_tizen> 6 </since_tizen>
        Left = 3,
        /// <summary>Bitmask that can be used to isolate rotation values, that is, <c>none</c>, <c>up</c>, <c>down</c>, <c>left</c> and <c>right</c>.</summary>
        /// <since_tizen> 6 </since_tizen>
        RotationBitmask = 3,
        /// <summary>Mirror horizontally. Can be added to the other values.</summary>
        /// <since_tizen> 6 </since_tizen>
        FlipHorizontal = 4,
        /// <summary>Mirror vertically. Can be added to the other values.</summary>
        /// <since_tizen> 6 </since_tizen>
        FlipVertical = 8,
        /// <summary>Bitmask that can be used to isolate flipping values, that is, <c>flip_vertical</c> and <c>flip_horizontal</c>.</summary>
        /// <since_tizen> 6 </since_tizen>
        FlipBitmask = 12,
    }
}

