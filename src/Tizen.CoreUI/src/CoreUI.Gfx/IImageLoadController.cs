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
    /// <summary>Common APIs for all loadable 2D images.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Gfx.IImageLoadControllerNativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    public interface IImageLoadController : 
        CoreUI.Wrapper.IWrapper, IDisposable
    {
        /// <summary>The load size of an image.
        /// 
        /// The image will be loaded into memory as if it was the specified size instead of its original size. This can save a lot of memory and is important for scalable types like SVG.
        /// 
        /// EFL will try to load an image of the requested size but does not guarantee an exact match between the request and the loaded image dimensions.
        /// 
        /// By default, the load size is not specified, so it is <c>0x0</c>.</summary>
        /// <returns>The image load size.</returns>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.DataTypes.Size2D GetLoadSize();

        /// <summary>The load size of an image.
        /// 
        /// The image will be loaded into memory as if it was the specified size instead of its original size. This can save a lot of memory and is important for scalable types like SVG.
        /// 
        /// EFL will try to load an image of the requested size but does not guarantee an exact match between the request and the loaded image dimensions.
        /// 
        /// By default, the load size is not specified, so it is <c>0x0</c>.</summary>
        /// <param name="size">The image load size.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetLoadSize(CoreUI.DataTypes.Size2D size);

        /// <summary>The DPI resolution of an image object&apos;s source image.
        /// 
        /// Most useful for the SVG image loader.</summary>
        /// <returns>The DPI resolution.</returns>
        /// <since_tizen> 6 </since_tizen>
        double GetLoadDpi();

        /// <summary>The DPI resolution of an image object&apos;s source image.
        /// 
        /// Most useful for the SVG image loader.</summary>
        /// <param name="dpi">The DPI resolution.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetLoadDpi(double dpi);

        /// <summary>Indicates whether the <see cref="CoreUI.Gfx.IImageLoadController.LoadRegion"/> property is supported for the current file.</summary>
        /// <returns><c>true</c> if region load of the image is supported, <c>false</c> otherwise.</returns>
        /// <since_tizen> 6 </since_tizen>
        bool GetLoadRegionSupport();

        /// <summary>Inform a given image object to load a selective region of its source image.
        /// 
        /// This property is useful when one is not showing all of an image&apos;s area on its image object.
        /// 
        /// <b>NOTE: </b>The image loader for the image format in question has to support selective region loading in order for this function to work (see <see cref="CoreUI.Gfx.IImageLoadController.GetLoadRegionSupport"/>).</summary>
        /// <returns>A region of the image.</returns>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.DataTypes.Rect GetLoadRegion();

        /// <summary>Inform a given image object to load a selective region of its source image.
        /// 
        /// This property is useful when one is not showing all of an image&apos;s area on its image object.
        /// 
        /// <b>NOTE: </b>The image loader for the image format in question has to support selective region loading in order for this function to work (see <see cref="CoreUI.Gfx.IImageLoadController.GetLoadRegionSupport"/>).</summary>
        /// <param name="region">A region of the image.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetLoadRegion(CoreUI.DataTypes.Rect region);

        /// <summary>Defines whether the orientation information in the image file should be honored.
        /// 
        /// The orientation can for instance be set in the EXIF tags of a JPEG image. If this flag is <c>false</c>, then the orientation will be ignored at load time, otherwise the image will be loaded with the proper orientation.</summary>
        /// <returns><c>true</c> means that it should honor the orientation information.</returns>
        /// <since_tizen> 6 </since_tizen>
        bool GetLoadOrientation();

        /// <summary>Defines whether the orientation information in the image file should be honored.
        /// 
        /// The orientation can for instance be set in the EXIF tags of a JPEG image. If this flag is <c>false</c>, then the orientation will be ignored at load time, otherwise the image will be loaded with the proper orientation.</summary>
        /// <param name="enable"><c>true</c> means that it should honor the orientation information.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetLoadOrientation(bool enable);

        /// <summary>The scale down factor is a divider on the original image size.
        /// 
        /// Setting the scale down factor can reduce load time and memory usage at the cost of having a scaled down image in memory.
        /// 
        /// This function sets the scale down factor of a given canvas image. Most useful for the SVG image loader but also applies to JPEG, PNG and BMP.
        /// 
        /// Powers of two (2, 4, 8, ...) are best supported (especially with JPEG).</summary>
        /// <returns>The scale down dividing factor.</returns>
        /// <since_tizen> 6 </since_tizen>
        int GetLoadScaleDown();

        /// <summary>The scale down factor is a divider on the original image size.
        /// 
        /// Setting the scale down factor can reduce load time and memory usage at the cost of having a scaled down image in memory.
        /// 
        /// This function sets the scale down factor of a given canvas image. Most useful for the SVG image loader but also applies to JPEG, PNG and BMP.
        /// 
        /// Powers of two (2, 4, 8, ...) are best supported (especially with JPEG).</summary>
        /// <param name="div">The scale down dividing factor.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetLoadScaleDown(int div);

        /// <summary>Initial load should skip header check and leave it all to data load.
        /// 
        /// If this is <c>true</c>, then future loads of images will defer header loading to a preload stage and/or data load later on rather than at the start when the load begins (e.g. when file is set).</summary>
        /// <returns><c>true</c> if header is to be skipped.</returns>
        /// <since_tizen> 6 </since_tizen>
        bool GetLoadSkipHeader();

        /// <summary>Initial load should skip header check and leave it all to data load.
        /// 
        /// If this is <c>true</c>, then future loads of images will defer header loading to a preload stage and/or data load later on rather than at the start when the load begins (e.g. when file is set).</summary>
        /// <param name="skip"><c>true</c> if header is to be skipped.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetLoadSkipHeader(bool skip);

        /// <summary>Begin preloading an image object&apos;s image data in the background.
        /// 
        /// Once the background task is complete the event @[.load,done] will be emitted if loading succeeded, @[.load,error] otherwise.</summary>
        /// <since_tizen> 6 </since_tizen>
        void LoadAsyncStart();

        /// <summary>Cancel preloading an image object&apos;s image data in the background.
        /// 
        /// The object should be left in a state where it has no image data. If cancel is called too late, the image will be kept in memory.</summary>
        /// <since_tizen> 6 </since_tizen>
        void CancelLoadAsync();

        /// <summary>The load size of an image.
        /// 
        /// The image will be loaded into memory as if it was the specified size instead of its original size. This can save a lot of memory and is important for scalable types like SVG.
        /// 
        /// EFL will try to load an image of the requested size but does not guarantee an exact match between the request and the loaded image dimensions.
        /// 
        /// By default, the load size is not specified, so it is <c>0x0</c>.</summary>
        /// <value>The image load size.</value>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.DataTypes.Size2D LoadSize {
            get;
            set;
        }

        /// <summary>The DPI resolution of an image object&apos;s source image.
        /// 
        /// Most useful for the SVG image loader.</summary>
        /// <value>The DPI resolution.</value>
        /// <since_tizen> 6 </since_tizen>
        double LoadDpi {
            get;
            set;
        }

        /// <summary>Indicates whether the <see cref="CoreUI.Gfx.IImageLoadController.LoadRegion"/> property is supported for the current file.</summary>
        /// <value><c>true</c> if region load of the image is supported, <c>false</c> otherwise.</value>
        /// <since_tizen> 6 </since_tizen>
        bool LoadRegionSupport {
            get;
        }

        /// <summary>Inform a given image object to load a selective region of its source image.
        /// 
        /// This property is useful when one is not showing all of an image&apos;s area on its image object.
        /// 
        /// <b>NOTE: </b>The image loader for the image format in question has to support selective region loading in order for this function to work (see <see cref="CoreUI.Gfx.IImageLoadController.GetLoadRegionSupport"/>).</summary>
        /// <value>A region of the image.</value>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.DataTypes.Rect LoadRegion {
            get;
            set;
        }

        /// <summary>Defines whether the orientation information in the image file should be honored.
        /// 
        /// The orientation can for instance be set in the EXIF tags of a JPEG image. If this flag is <c>false</c>, then the orientation will be ignored at load time, otherwise the image will be loaded with the proper orientation.</summary>
        /// <value><c>true</c> means that it should honor the orientation information.</value>
        /// <since_tizen> 6 </since_tizen>
        bool LoadOrientation {
            get;
            set;
        }

        /// <summary>The scale down factor is a divider on the original image size.
        /// 
        /// Setting the scale down factor can reduce load time and memory usage at the cost of having a scaled down image in memory.
        /// 
        /// This function sets the scale down factor of a given canvas image. Most useful for the SVG image loader but also applies to JPEG, PNG and BMP.
        /// 
        /// Powers of two (2, 4, 8, ...) are best supported (especially with JPEG).</summary>
        /// <value>The scale down dividing factor.</value>
        /// <since_tizen> 6 </since_tizen>
        int LoadScaleDown {
            get;
            set;
        }

        /// <summary>Initial load should skip header check and leave it all to data load.
        /// 
        /// If this is <c>true</c>, then future loads of images will defer header loading to a preload stage and/or data load later on rather than at the start when the load begins (e.g. when file is set).</summary>
        /// <value><c>true</c> if header is to be skipped.</value>
        /// <since_tizen> 6 </since_tizen>
        bool LoadSkipHeader {
            get;
            set;
        }

    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class IImageLoadControllerNativeMethods : CoreUI.Wrapper.ObjectWrapper.NativeMethods
    {
        [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
            efl_gfx_image_load_controller_interface_get();
        private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.CoreUI);

        /// <summary>Gets the list of Eo operations to override.
    /// </summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
            var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

            if (efl_gfx_image_load_controller_load_size_get_static_delegate == null)
            {
                efl_gfx_image_load_controller_load_size_get_static_delegate = new efl_gfx_image_load_controller_load_size_get_delegate(load_size_get);
            }

            if (methods.Contains("GetLoadSize"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_load_controller_load_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_size_get_static_delegate) });
            }

            if (efl_gfx_image_load_controller_load_size_set_static_delegate == null)
            {
                efl_gfx_image_load_controller_load_size_set_static_delegate = new efl_gfx_image_load_controller_load_size_set_delegate(load_size_set);
            }

            if (methods.Contains("SetLoadSize"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_load_controller_load_size_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_size_set_static_delegate) });
            }

            if (efl_gfx_image_load_controller_load_dpi_get_static_delegate == null)
            {
                efl_gfx_image_load_controller_load_dpi_get_static_delegate = new efl_gfx_image_load_controller_load_dpi_get_delegate(load_dpi_get);
            }

            if (methods.Contains("GetLoadDpi"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_load_controller_load_dpi_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_dpi_get_static_delegate) });
            }

            if (efl_gfx_image_load_controller_load_dpi_set_static_delegate == null)
            {
                efl_gfx_image_load_controller_load_dpi_set_static_delegate = new efl_gfx_image_load_controller_load_dpi_set_delegate(load_dpi_set);
            }

            if (methods.Contains("SetLoadDpi"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_load_controller_load_dpi_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_dpi_set_static_delegate) });
            }

            if (efl_gfx_image_load_controller_load_region_support_get_static_delegate == null)
            {
                efl_gfx_image_load_controller_load_region_support_get_static_delegate = new efl_gfx_image_load_controller_load_region_support_get_delegate(load_region_support_get);
            }

            if (methods.Contains("GetLoadRegionSupport"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_load_controller_load_region_support_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_region_support_get_static_delegate) });
            }

            if (efl_gfx_image_load_controller_load_region_get_static_delegate == null)
            {
                efl_gfx_image_load_controller_load_region_get_static_delegate = new efl_gfx_image_load_controller_load_region_get_delegate(load_region_get);
            }

            if (methods.Contains("GetLoadRegion"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_load_controller_load_region_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_region_get_static_delegate) });
            }

            if (efl_gfx_image_load_controller_load_region_set_static_delegate == null)
            {
                efl_gfx_image_load_controller_load_region_set_static_delegate = new efl_gfx_image_load_controller_load_region_set_delegate(load_region_set);
            }

            if (methods.Contains("SetLoadRegion"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_load_controller_load_region_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_region_set_static_delegate) });
            }

            if (efl_gfx_image_load_controller_load_orientation_get_static_delegate == null)
            {
                efl_gfx_image_load_controller_load_orientation_get_static_delegate = new efl_gfx_image_load_controller_load_orientation_get_delegate(load_orientation_get);
            }

            if (methods.Contains("GetLoadOrientation"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_load_controller_load_orientation_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_orientation_get_static_delegate) });
            }

            if (efl_gfx_image_load_controller_load_orientation_set_static_delegate == null)
            {
                efl_gfx_image_load_controller_load_orientation_set_static_delegate = new efl_gfx_image_load_controller_load_orientation_set_delegate(load_orientation_set);
            }

            if (methods.Contains("SetLoadOrientation"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_load_controller_load_orientation_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_orientation_set_static_delegate) });
            }

            if (efl_gfx_image_load_controller_load_scale_down_get_static_delegate == null)
            {
                efl_gfx_image_load_controller_load_scale_down_get_static_delegate = new efl_gfx_image_load_controller_load_scale_down_get_delegate(load_scale_down_get);
            }

            if (methods.Contains("GetLoadScaleDown"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_load_controller_load_scale_down_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_scale_down_get_static_delegate) });
            }

            if (efl_gfx_image_load_controller_load_scale_down_set_static_delegate == null)
            {
                efl_gfx_image_load_controller_load_scale_down_set_static_delegate = new efl_gfx_image_load_controller_load_scale_down_set_delegate(load_scale_down_set);
            }

            if (methods.Contains("SetLoadScaleDown"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_load_controller_load_scale_down_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_scale_down_set_static_delegate) });
            }

            if (efl_gfx_image_load_controller_load_skip_header_get_static_delegate == null)
            {
                efl_gfx_image_load_controller_load_skip_header_get_static_delegate = new efl_gfx_image_load_controller_load_skip_header_get_delegate(load_skip_header_get);
            }

            if (methods.Contains("GetLoadSkipHeader"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_load_controller_load_skip_header_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_skip_header_get_static_delegate) });
            }

            if (efl_gfx_image_load_controller_load_skip_header_set_static_delegate == null)
            {
                efl_gfx_image_load_controller_load_skip_header_set_static_delegate = new efl_gfx_image_load_controller_load_skip_header_set_delegate(load_skip_header_set);
            }

            if (methods.Contains("SetLoadSkipHeader"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_load_controller_load_skip_header_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_skip_header_set_static_delegate) });
            }

            if (efl_gfx_image_load_controller_load_async_start_static_delegate == null)
            {
                efl_gfx_image_load_controller_load_async_start_static_delegate = new efl_gfx_image_load_controller_load_async_start_delegate(load_async_start);
            }

            if (methods.Contains("LoadAsyncStart"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_load_controller_load_async_start"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_async_start_static_delegate) });
            }

            if (efl_gfx_image_load_controller_load_async_cancel_static_delegate == null)
            {
                efl_gfx_image_load_controller_load_async_cancel_static_delegate = new efl_gfx_image_load_controller_load_async_cancel_delegate(load_async_cancel);
            }

            if (methods.Contains("CancelLoadAsync"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_load_controller_load_async_cancel"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_async_cancel_static_delegate) });
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
            return efl_gfx_image_load_controller_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate CoreUI.DataTypes.Size2D efl_gfx_image_load_controller_load_size_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate CoreUI.DataTypes.Size2D efl_gfx_image_load_controller_load_size_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_load_controller_load_size_get_api_delegate> efl_gfx_image_load_controller_load_size_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_load_controller_load_size_get_api_delegate>(Module, "efl_gfx_image_load_controller_load_size_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static CoreUI.DataTypes.Size2D load_size_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_image_load_controller_load_size_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.DataTypes.Size2D _ret_var = default(CoreUI.DataTypes.Size2D);
                try
                {
                    _ret_var = ((IImageLoadController)ws.Target).GetLoadSize();
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
                return efl_gfx_image_load_controller_load_size_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_gfx_image_load_controller_load_size_get_delegate efl_gfx_image_load_controller_load_size_get_static_delegate;

        
        private delegate void efl_gfx_image_load_controller_load_size_set_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.DataTypes.Size2D size);

        
        internal delegate void efl_gfx_image_load_controller_load_size_set_api_delegate(System.IntPtr obj,  CoreUI.DataTypes.Size2D size);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_load_controller_load_size_set_api_delegate> efl_gfx_image_load_controller_load_size_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_load_controller_load_size_set_api_delegate>(Module, "efl_gfx_image_load_controller_load_size_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void load_size_set(System.IntPtr obj, System.IntPtr pd, CoreUI.DataTypes.Size2D size)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_image_load_controller_load_size_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.DataTypes.Size2D _in_size = size;

                try
                {
                    ((IImageLoadController)ws.Target).SetLoadSize(_in_size);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_image_load_controller_load_size_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), size);
            }
        }

        private static efl_gfx_image_load_controller_load_size_set_delegate efl_gfx_image_load_controller_load_size_set_static_delegate;

        
        private delegate double efl_gfx_image_load_controller_load_dpi_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate double efl_gfx_image_load_controller_load_dpi_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_load_controller_load_dpi_get_api_delegate> efl_gfx_image_load_controller_load_dpi_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_load_controller_load_dpi_get_api_delegate>(Module, "efl_gfx_image_load_controller_load_dpi_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static double load_dpi_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_image_load_controller_load_dpi_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                double _ret_var = default(double);
                try
                {
                    _ret_var = ((IImageLoadController)ws.Target).GetLoadDpi();
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
                return efl_gfx_image_load_controller_load_dpi_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_gfx_image_load_controller_load_dpi_get_delegate efl_gfx_image_load_controller_load_dpi_get_static_delegate;

        
        private delegate void efl_gfx_image_load_controller_load_dpi_set_delegate(System.IntPtr obj, System.IntPtr pd,  double dpi);

        
        internal delegate void efl_gfx_image_load_controller_load_dpi_set_api_delegate(System.IntPtr obj,  double dpi);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_load_controller_load_dpi_set_api_delegate> efl_gfx_image_load_controller_load_dpi_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_load_controller_load_dpi_set_api_delegate>(Module, "efl_gfx_image_load_controller_load_dpi_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void load_dpi_set(System.IntPtr obj, System.IntPtr pd, double dpi)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_image_load_controller_load_dpi_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IImageLoadController)ws.Target).SetLoadDpi(dpi);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_image_load_controller_load_dpi_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), dpi);
            }
        }

        private static efl_gfx_image_load_controller_load_dpi_set_delegate efl_gfx_image_load_controller_load_dpi_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_gfx_image_load_controller_load_region_support_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        internal delegate bool efl_gfx_image_load_controller_load_region_support_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_load_controller_load_region_support_get_api_delegate> efl_gfx_image_load_controller_load_region_support_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_load_controller_load_region_support_get_api_delegate>(Module, "efl_gfx_image_load_controller_load_region_support_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static bool load_region_support_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_image_load_controller_load_region_support_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IImageLoadController)ws.Target).GetLoadRegionSupport();
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
                return efl_gfx_image_load_controller_load_region_support_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_gfx_image_load_controller_load_region_support_get_delegate efl_gfx_image_load_controller_load_region_support_get_static_delegate;

        
        private delegate CoreUI.DataTypes.Rect efl_gfx_image_load_controller_load_region_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate CoreUI.DataTypes.Rect efl_gfx_image_load_controller_load_region_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_load_controller_load_region_get_api_delegate> efl_gfx_image_load_controller_load_region_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_load_controller_load_region_get_api_delegate>(Module, "efl_gfx_image_load_controller_load_region_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static CoreUI.DataTypes.Rect load_region_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_image_load_controller_load_region_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.DataTypes.Rect _ret_var = default(CoreUI.DataTypes.Rect);
                try
                {
                    _ret_var = ((IImageLoadController)ws.Target).GetLoadRegion();
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
                return efl_gfx_image_load_controller_load_region_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_gfx_image_load_controller_load_region_get_delegate efl_gfx_image_load_controller_load_region_get_static_delegate;

        
        private delegate void efl_gfx_image_load_controller_load_region_set_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.DataTypes.Rect region);

        
        internal delegate void efl_gfx_image_load_controller_load_region_set_api_delegate(System.IntPtr obj,  CoreUI.DataTypes.Rect region);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_load_controller_load_region_set_api_delegate> efl_gfx_image_load_controller_load_region_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_load_controller_load_region_set_api_delegate>(Module, "efl_gfx_image_load_controller_load_region_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void load_region_set(System.IntPtr obj, System.IntPtr pd, CoreUI.DataTypes.Rect region)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_image_load_controller_load_region_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.DataTypes.Rect _in_region = region;

                try
                {
                    ((IImageLoadController)ws.Target).SetLoadRegion(_in_region);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_image_load_controller_load_region_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), region);
            }
        }

        private static efl_gfx_image_load_controller_load_region_set_delegate efl_gfx_image_load_controller_load_region_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_gfx_image_load_controller_load_orientation_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        internal delegate bool efl_gfx_image_load_controller_load_orientation_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_load_controller_load_orientation_get_api_delegate> efl_gfx_image_load_controller_load_orientation_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_load_controller_load_orientation_get_api_delegate>(Module, "efl_gfx_image_load_controller_load_orientation_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static bool load_orientation_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_image_load_controller_load_orientation_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IImageLoadController)ws.Target).GetLoadOrientation();
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
                return efl_gfx_image_load_controller_load_orientation_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_gfx_image_load_controller_load_orientation_get_delegate efl_gfx_image_load_controller_load_orientation_get_static_delegate;

        
        private delegate void efl_gfx_image_load_controller_load_orientation_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool enable);

        
        internal delegate void efl_gfx_image_load_controller_load_orientation_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool enable);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_load_controller_load_orientation_set_api_delegate> efl_gfx_image_load_controller_load_orientation_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_load_controller_load_orientation_set_api_delegate>(Module, "efl_gfx_image_load_controller_load_orientation_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void load_orientation_set(System.IntPtr obj, System.IntPtr pd, bool enable)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_image_load_controller_load_orientation_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IImageLoadController)ws.Target).SetLoadOrientation(enable);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_image_load_controller_load_orientation_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), enable);
            }
        }

        private static efl_gfx_image_load_controller_load_orientation_set_delegate efl_gfx_image_load_controller_load_orientation_set_static_delegate;

        
        private delegate int efl_gfx_image_load_controller_load_scale_down_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate int efl_gfx_image_load_controller_load_scale_down_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_load_controller_load_scale_down_get_api_delegate> efl_gfx_image_load_controller_load_scale_down_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_load_controller_load_scale_down_get_api_delegate>(Module, "efl_gfx_image_load_controller_load_scale_down_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static int load_scale_down_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_image_load_controller_load_scale_down_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                int _ret_var = default(int);
                try
                {
                    _ret_var = ((IImageLoadController)ws.Target).GetLoadScaleDown();
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
                return efl_gfx_image_load_controller_load_scale_down_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_gfx_image_load_controller_load_scale_down_get_delegate efl_gfx_image_load_controller_load_scale_down_get_static_delegate;

        
        private delegate void efl_gfx_image_load_controller_load_scale_down_set_delegate(System.IntPtr obj, System.IntPtr pd,  int div);

        
        internal delegate void efl_gfx_image_load_controller_load_scale_down_set_api_delegate(System.IntPtr obj,  int div);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_load_controller_load_scale_down_set_api_delegate> efl_gfx_image_load_controller_load_scale_down_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_load_controller_load_scale_down_set_api_delegate>(Module, "efl_gfx_image_load_controller_load_scale_down_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void load_scale_down_set(System.IntPtr obj, System.IntPtr pd, int div)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_image_load_controller_load_scale_down_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IImageLoadController)ws.Target).SetLoadScaleDown(div);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_image_load_controller_load_scale_down_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), div);
            }
        }

        private static efl_gfx_image_load_controller_load_scale_down_set_delegate efl_gfx_image_load_controller_load_scale_down_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_gfx_image_load_controller_load_skip_header_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        internal delegate bool efl_gfx_image_load_controller_load_skip_header_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_load_controller_load_skip_header_get_api_delegate> efl_gfx_image_load_controller_load_skip_header_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_load_controller_load_skip_header_get_api_delegate>(Module, "efl_gfx_image_load_controller_load_skip_header_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static bool load_skip_header_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_image_load_controller_load_skip_header_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IImageLoadController)ws.Target).GetLoadSkipHeader();
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
                return efl_gfx_image_load_controller_load_skip_header_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_gfx_image_load_controller_load_skip_header_get_delegate efl_gfx_image_load_controller_load_skip_header_get_static_delegate;

        
        private delegate void efl_gfx_image_load_controller_load_skip_header_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool skip);

        
        internal delegate void efl_gfx_image_load_controller_load_skip_header_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool skip);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_load_controller_load_skip_header_set_api_delegate> efl_gfx_image_load_controller_load_skip_header_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_load_controller_load_skip_header_set_api_delegate>(Module, "efl_gfx_image_load_controller_load_skip_header_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void load_skip_header_set(System.IntPtr obj, System.IntPtr pd, bool skip)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_image_load_controller_load_skip_header_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IImageLoadController)ws.Target).SetLoadSkipHeader(skip);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_image_load_controller_load_skip_header_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), skip);
            }
        }

        private static efl_gfx_image_load_controller_load_skip_header_set_delegate efl_gfx_image_load_controller_load_skip_header_set_static_delegate;

        
        private delegate void efl_gfx_image_load_controller_load_async_start_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate void efl_gfx_image_load_controller_load_async_start_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_load_controller_load_async_start_api_delegate> efl_gfx_image_load_controller_load_async_start_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_load_controller_load_async_start_api_delegate>(Module, "efl_gfx_image_load_controller_load_async_start");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void load_async_start(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_image_load_controller_load_async_start was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IImageLoadController)ws.Target).LoadAsyncStart();
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_image_load_controller_load_async_start_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_gfx_image_load_controller_load_async_start_delegate efl_gfx_image_load_controller_load_async_start_static_delegate;

        
        private delegate void efl_gfx_image_load_controller_load_async_cancel_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate void efl_gfx_image_load_controller_load_async_cancel_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_load_controller_load_async_cancel_api_delegate> efl_gfx_image_load_controller_load_async_cancel_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_load_controller_load_async_cancel_api_delegate>(Module, "efl_gfx_image_load_controller_load_async_cancel");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void load_async_cancel(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_image_load_controller_load_async_cancel was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IImageLoadController)ws.Target).CancelLoadAsync();
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_image_load_controller_load_async_cancel_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_gfx_image_load_controller_load_async_cancel_delegate efl_gfx_image_load_controller_load_async_cancel_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

    }
}

namespace CoreUI.Gfx {
#pragma warning disable CS1591
    /// <since_tizen> 6 </since_tizen>
    public static class ImageLoadControllerExtensions {
        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.DataTypes.Size2D> LoadSize<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Gfx.IImageLoadController, T>magic = null) where T : CoreUI.Gfx.IImageLoadController {
            return new CoreUI.BindableProperty<CoreUI.DataTypes.Size2D>("load_size", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<double> LoadDpi<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Gfx.IImageLoadController, T>magic = null) where T : CoreUI.Gfx.IImageLoadController {
            return new CoreUI.BindableProperty<double>("load_dpi", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.DataTypes.Rect> LoadRegion<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Gfx.IImageLoadController, T>magic = null) where T : CoreUI.Gfx.IImageLoadController {
            return new CoreUI.BindableProperty<CoreUI.DataTypes.Rect>("load_region", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> LoadOrientation<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Gfx.IImageLoadController, T>magic = null) where T : CoreUI.Gfx.IImageLoadController {
            return new CoreUI.BindableProperty<bool>("load_orientation", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<int> LoadScaleDown<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Gfx.IImageLoadController, T>magic = null) where T : CoreUI.Gfx.IImageLoadController {
            return new CoreUI.BindableProperty<int>("load_scale_down", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> LoadSkipHeader<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Gfx.IImageLoadController, T>magic = null) where T : CoreUI.Gfx.IImageLoadController {
            return new CoreUI.BindableProperty<bool>("load_skip_header", fac.GetPropBind());
        }

    }
#pragma warning restore CS1591
}

