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
    /// <summary>The bg (background) widget is used for setting (solid) background decorations for a window (unless it has transparency enabled) or for any container object. It works just like an image, but has some properties useful for backgrounds, such as setting it to tiled, centered, scaled or stretched.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.UI.Bg.NativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public class Bg : CoreUI.UI.LayoutBase, CoreUI.IFile, CoreUI.Gfx.IImage, CoreUI.Gfx.IImageLoadController
    {
        /// <summary>Pointer to the native class description.</summary>
        public override System.IntPtr NativeClass
        {
            get
            {
                if (((object)this).GetType() == typeof(Bg))
                {
                    return GetCoreUIClassStatic();
                }
                else
                {
                    return CoreUI.Wrapper.ClassRegister.klassFromType[((object)this).GetType()];
                }
            }
        }

        [System.Runtime.InteropServices.DllImport(CoreUI.Libs.Elementary)] internal static extern System.IntPtr
            efl_ui_bg_class_get();

        /// <summary>Initializes a new instance of the <see cref="Bg"/> class.
        /// </summary>
        /// <param name="parent">Parent instance.</param>
    /// <param name="style">The widget style to use. See <see cref="CoreUI.UI.Widget.SetStyle" /></param>
        public Bg(CoreUI.Object parent, System.String style = null) : base(efl_ui_bg_class_get(), parent)
        {
            if (CoreUI.Wrapper.Globals.ParamHelperCheck(style))
            {
                SetStyle(CoreUI.Wrapper.Globals.GetParamHelper(style));
            }

            FinishInstantiation();
        }

        /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
        /// Do not call this constructor directly.
        /// </summary>
        /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
        protected Bg(ConstructingHandle ch) : base(ch)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="Bg"/> class.
        /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.
        /// </summary>
        /// <param name="wh">The native pointer to be wrapped.</param>
        internal Bg(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="Bg"/> class.
        /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.
        /// </summary>
        /// <param name="baseKlass">The pointer to the base native Eo class.</param>
        /// <param name="parent">The CoreUI.Object parent of this instance.</param>
        protected Bg(IntPtr baseKlass, CoreUI.Object parent) : base(baseKlass, parent)
        {
        }


        /// <summary>If <c>true</c>, image data has been preloaded and can be displayed. If <c>false</c>, the image data has been unloaded and can no longer be displayed.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.Gfx.ImageImagePreloadStateChangedEventArgs"/></value>
        public event EventHandler<CoreUI.Gfx.ImageImagePreloadStateChangedEventArgs> ImagePreloadStateChanged
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.Gfx.ImageImagePreloadStateChangedEventArgs{ Arg = Marshal.ReadByte(info) != 0 });
                string key = "_EFL_GFX_IMAGE_EVENT_IMAGE_PRELOAD_STATE_CHANGED";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_GFX_IMAGE_EVENT_IMAGE_PRELOAD_STATE_CHANGED";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event ImagePreloadStateChanged.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnImagePreloadStateChanged(CoreUI.Gfx.ImageImagePreloadStateChangedEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = CoreUI.DataTypes.PrimitiveConversion.ManagedToPointerAlloc(e.Arg ? (byte) 1 : (byte) 0);
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_GFX_IMAGE_EVENT_IMAGE_PRELOAD_STATE_CHANGED", info, (p) => Marshal.FreeHGlobal(p));
        }

        /// <summary>Image was resized (its pixel data). The event data is the image&apos;s new size.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.Gfx.ImageImageResizedEventArgs"/></value>
        public event EventHandler<CoreUI.Gfx.ImageImageResizedEventArgs> ImageResized
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.Gfx.ImageImageResizedEventArgs{ Arg =  info });
                string key = "_EFL_GFX_IMAGE_EVENT_IMAGE_RESIZED";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_GFX_IMAGE_EVENT_IMAGE_RESIZED";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event ImageResized.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnImageResized(CoreUI.Gfx.ImageImageResizedEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = Marshal.AllocHGlobal(Marshal.SizeOf(e.Arg));
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_GFX_IMAGE_EVENT_IMAGE_RESIZED", info, (p) => Marshal.FreeHGlobal(p));
        }

        /// <summary>The mmaped file from where an object will fetch the real data (it must be an <see cref="CoreUI.DataTypes.File"/>).
        /// 
        /// If mmap is set during object construction, the object will automatically call <see cref="CoreUI.IFile.Load"/> during the finalize phase of construction.</summary>
        /// <returns>The handle to the <see cref="CoreUI.DataTypes.File"/> that will be used</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.DataTypes.File GetMmap() {
            var _ret_var = CoreUI.IFileNativeMethods.efl_file_mmap_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The mmaped file from where an object will fetch the real data (it must be an <see cref="CoreUI.DataTypes.File"/>).
        /// 
        /// If mmap is set during object construction, the object will automatically call <see cref="CoreUI.IFile.Load"/> during the finalize phase of construction.</summary>
        /// <param name="f">The handle to the <see cref="CoreUI.DataTypes.File"/> that will be used</param>
        /// <returns>0 on success, error code otherwise</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.DataTypes.Error SetMmap(CoreUI.DataTypes.File f) {
            var _ret_var = CoreUI.IFileNativeMethods.efl_file_mmap_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), f);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The file path from where an object will fetch the data.
        /// 
        /// If file is set during object construction, the object will automatically call <see cref="CoreUI.IFile.Load"/> during the finalize phase of construction.
        /// 
        /// You must not modify the strings on the returned pointers.</summary>
        /// <returns>The file path.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual System.String GetFile() {
            var _ret_var = CoreUI.IFileNativeMethods.efl_file_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The file path from where an object will fetch the data.
        /// 
        /// If file is set during object construction, the object will automatically call <see cref="CoreUI.IFile.Load"/> during the finalize phase of construction.
        /// 
        /// You must not modify the strings on the returned pointers.</summary>
        /// <param name="file">The file path.</param>
        /// <returns>0 on success, error code otherwise</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.DataTypes.Error SetFile(System.String file) {
            var _ret_var = CoreUI.IFileNativeMethods.efl_file_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), file);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The key which corresponds to the target data within a file.
        /// 
        /// Some file types can contain multiple data streams which are indexed by a key. Use this property for such cases (See for example <see cref="CoreUI.UI.Image"/> or <see cref="CoreUI.UI.Layout"/>).
        /// 
        /// You must not modify the strings on the returned pointers.</summary>
        /// <returns>The group that the data belongs to. See the class documentation for particular implementations of this interface to see how this property is used.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual System.String GetKey() {
            var _ret_var = CoreUI.IFileNativeMethods.efl_file_key_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The key which corresponds to the target data within a file.
        /// 
        /// Some file types can contain multiple data streams which are indexed by a key. Use this property for such cases (See for example <see cref="CoreUI.UI.Image"/> or <see cref="CoreUI.UI.Layout"/>).
        /// 
        /// You must not modify the strings on the returned pointers.</summary>
        /// <param name="key">The group that the data belongs to. See the class documentation for particular implementations of this interface to see how this property is used.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetKey(System.String key) {
            CoreUI.IFileNativeMethods.efl_file_key_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), key);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The load state of the object.</summary>
        /// <returns><c>true</c> if the object is loaded, <c>false</c> otherwise.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetLoaded() {
            var _ret_var = CoreUI.IFileNativeMethods.efl_file_loaded_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Perform all necessary operations to open and load file data into the object using the <see cref="CoreUI.IFile.File"/> (or <see cref="CoreUI.IFile.Mmap"/>) and <see cref="CoreUI.IFile.Key"/> properties.
        /// 
        /// In the case where <see cref="CoreUI.IFile.SetFile"/> has been called on an object, this will internally open the file and call <see cref="CoreUI.IFile.SetMmap"/> on the object using the opened file handle.
        /// 
        /// Calling <see cref="CoreUI.IFile.Load"/> on an object which has already performed file operations based on the currently set properties will have no effect.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <returns>0 on success, error code otherwise</returns>
        public virtual CoreUI.DataTypes.Error Load() {
            var _ret_var = CoreUI.IFileNativeMethods.efl_file_load_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Perform all necessary operations to unload file data from the object.
        /// 
        /// In the case where <see cref="CoreUI.IFile.SetMmap"/> has been externally called on an object, the file handle stored in the object will be preserved.
        /// 
        /// Calling <see cref="CoreUI.IFile.Unload"/> on an object which is not currently loaded will have no effect.</summary>
        /// <since_tizen> 6 </since_tizen>
        public virtual void Unload() {
            CoreUI.IFileNativeMethods.efl_file_unload_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Whether to use high-quality image scaling algorithm for this image.
        /// 
        /// When enabled, a higher quality image scaling algorithm is used when scaling images to sizes other than the source image&apos;s original one. This gives better results but is more computationally expensive.</summary>
        /// <returns>Whether to use smooth scale or not.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetSmoothScale() {
            var _ret_var = CoreUI.Gfx.IImageNativeMethods.efl_gfx_image_smooth_scale_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Whether to use high-quality image scaling algorithm for this image.
        /// 
        /// When enabled, a higher quality image scaling algorithm is used when scaling images to sizes other than the source image&apos;s original one. This gives better results but is more computationally expensive.</summary>
        /// <param name="smooth_scale">Whether to use smooth scale or not.<br/>The default value is <c>true</c>.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetSmoothScale(bool smooth_scale) {
            CoreUI.Gfx.IImageNativeMethods.efl_gfx_image_smooth_scale_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), smooth_scale);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Determine how the image is scaled at render time.
        /// 
        /// This allows more granular controls for how an image object should display its internal buffer. The underlying image data will not be modified.</summary>
        /// <returns>Image scale type to use.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.Gfx.ImageScaleMethod GetScaleMethod() {
            var _ret_var = CoreUI.Gfx.IImageNativeMethods.efl_gfx_image_scale_method_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Determine how the image is scaled at render time.
        /// 
        /// This allows more granular controls for how an image object should display its internal buffer. The underlying image data will not be modified.</summary>
        /// <param name="scale_method">Image scale type to use.<br/>The default value is <see cref="CoreUI.Gfx.ImageScaleMethod.None"/>.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetScaleMethod(CoreUI.Gfx.ImageScaleMethod scale_method) {
            CoreUI.Gfx.IImageNativeMethods.efl_gfx_image_scale_method_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), scale_method);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>If <c>true</c>, the image may be scaled to a larger size. If <c>false</c>, the image will never be resized larger than its native size.</summary>
        /// <returns>Whether to allow image upscaling.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetCanUpscale() {
            var _ret_var = CoreUI.Gfx.IImageNativeMethods.efl_gfx_image_can_upscale_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>If <c>true</c>, the image may be scaled to a larger size. If <c>false</c>, the image will never be resized larger than its native size.</summary>
        /// <param name="upscale">Whether to allow image upscaling.<br/>The default value is <c>true</c>.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetCanUpscale(bool upscale) {
            CoreUI.Gfx.IImageNativeMethods.efl_gfx_image_can_upscale_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), upscale);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>If <c>true</c>, the image may be scaled to a smaller size. If <c>false</c>, the image will never be resized smaller than its native size.</summary>
        /// <returns>Whether to allow image downscaling.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetCanDownscale() {
            var _ret_var = CoreUI.Gfx.IImageNativeMethods.efl_gfx_image_can_downscale_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>If <c>true</c>, the image may be scaled to a smaller size. If <c>false</c>, the image will never be resized smaller than its native size.</summary>
        /// <param name="downscale">Whether to allow image downscaling.<br/>The default value is <c>true</c>.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetCanDownscale(bool downscale) {
            CoreUI.Gfx.IImageNativeMethods.efl_gfx_image_can_downscale_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), downscale);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The native width/height ratio of the image.
        /// 
        /// The ratio will be 1.0 if it cannot be calculated (e.g. height = 0).</summary>
        /// <returns>The image&apos;s ratio.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual double GetRatio() {
            var _ret_var = CoreUI.Gfx.IImageNativeMethods.efl_gfx_image_ratio_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Return the relative area enclosed inside the image where content is expected.
        /// 
        /// We do expect content to be inside the limit defined by the border or inside the stretch region. If a stretch region is provided, the content region will encompass the non-stretchable area that are surrounded by stretchable area. If no border and no stretch region is set, they are assumed to be zero and the full object geometry is where content can be layout on top. The area size change with the object size.
        /// 
        /// The geometry of the area is expressed relative to the geometry of the object.</summary>
        /// <returns>A rectangle inside the object boundary where content is expected. The default value is the image object&apos;s geometry with the <see cref="CoreUI.Gfx.IImage.BorderInsets"/> values subtracted.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.DataTypes.Rect GetContentRegion() {
            var _ret_var = CoreUI.Gfx.IImageNativeMethods.efl_gfx_image_content_region_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Dimensions of this image&apos;s border, a region that does not scale with the center area.
        /// 
        /// When EFL renders an image, its source may be scaled to fit the size of the object. This function sets an area from the borders of the image inwards which is not to be scaled. This function is useful for making frames and for widget theming, where, for example, buttons may be of varying sizes, but their border size must remain constant.
        /// 
        /// The units used for <c>l</c>, <c>r</c>, <c>t</c> and <c>b</c> are canvas units (pixels).
        /// 
        /// <b>NOTE: </b>The border region itself may be scaled by the <see cref="CoreUI.Gfx.IImage.SetBorderInsetsScale"/> function.
        /// 
        /// <b>NOTE: </b>By default, image objects have no borders set, i.e. <c>l</c>, <c>r</c>, <c>t</c> and <c>b</c> start as 0.
        /// 
        /// <b>NOTE: </b>Similar to the concepts of 9-patch images or cap insets.</summary>
        /// <param name="l">The border&apos;s left width.<br/>The default value is <c>0</c>.</param>
        /// <param name="r">The border&apos;s right width.<br/>The default value is <c>0</c>.</param>
        /// <param name="t">The border&apos;s top height.<br/>The default value is <c>0</c>.</param>
        /// <param name="b">The border&apos;s bottom height.<br/>The default value is <c>0</c>.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void GetBorderInsets(out int l, out int r, out int t, out int b) {
            CoreUI.Gfx.IImageNativeMethods.efl_gfx_image_border_insets_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), out l, out r, out t, out b);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Dimensions of this image&apos;s border, a region that does not scale with the center area.
        /// 
        /// When EFL renders an image, its source may be scaled to fit the size of the object. This function sets an area from the borders of the image inwards which is not to be scaled. This function is useful for making frames and for widget theming, where, for example, buttons may be of varying sizes, but their border size must remain constant.
        /// 
        /// The units used for <c>l</c>, <c>r</c>, <c>t</c> and <c>b</c> are canvas units (pixels).
        /// 
        /// <b>NOTE: </b>The border region itself may be scaled by the <see cref="CoreUI.Gfx.IImage.SetBorderInsetsScale"/> function.
        /// 
        /// <b>NOTE: </b>By default, image objects have no borders set, i.e. <c>l</c>, <c>r</c>, <c>t</c> and <c>b</c> start as 0.
        /// 
        /// <b>NOTE: </b>Similar to the concepts of 9-patch images or cap insets.</summary>
        /// <param name="l">The border&apos;s left width.<br/>The default value is <c>0</c>.</param>
        /// <param name="r">The border&apos;s right width.<br/>The default value is <c>0</c>.</param>
        /// <param name="t">The border&apos;s top height.<br/>The default value is <c>0</c>.</param>
        /// <param name="b">The border&apos;s bottom height.<br/>The default value is <c>0</c>.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetBorderInsets(int l, int r, int t, int b) {
            CoreUI.Gfx.IImageNativeMethods.efl_gfx_image_border_insets_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), l, r, t, b);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Scaling factor applied to the image borders.
        /// 
        /// This value multiplies the size of the <see cref="CoreUI.Gfx.IImage.BorderInsets"/> when scaling an object.</summary>
        /// <returns>The scale factor.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual double GetBorderInsetsScale() {
            var _ret_var = CoreUI.Gfx.IImageNativeMethods.efl_gfx_image_border_insets_scale_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Scaling factor applied to the image borders.
        /// 
        /// This value multiplies the size of the <see cref="CoreUI.Gfx.IImage.BorderInsets"/> when scaling an object.</summary>
        /// <param name="scale">The scale factor.<br/>The default value is <c>1.000000</c>.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetBorderInsetsScale(double scale) {
            CoreUI.Gfx.IImageNativeMethods.efl_gfx_image_border_insets_scale_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), scale);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Specifies how the center part of the object (not the borders) should be drawn when EFL is rendering it.
        /// 
        /// This function sets how the center part of the image object&apos;s source image is to be drawn, which must be one of the values in <see cref="CoreUI.Gfx.CenterFillMode"/>. By center we mean the complementary part of that defined by <see cref="CoreUI.Gfx.IImage.SetBorderInsets"/>. This is very useful for making frames and decorations. You would most probably also be using a filled image (as in <span class="text-muted">CoreUI.Gfx.IFill.FillAuto (object still in beta stage)</span>) to use as a frame.</summary>
        /// <returns>Fill mode of the center region. The default behavior is to render and scale the center area, respecting its transparency.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.Gfx.CenterFillMode GetCenterFillMode() {
            var _ret_var = CoreUI.Gfx.IImageNativeMethods.efl_gfx_image_center_fill_mode_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Specifies how the center part of the object (not the borders) should be drawn when EFL is rendering it.
        /// 
        /// This function sets how the center part of the image object&apos;s source image is to be drawn, which must be one of the values in <see cref="CoreUI.Gfx.CenterFillMode"/>. By center we mean the complementary part of that defined by <see cref="CoreUI.Gfx.IImage.SetBorderInsets"/>. This is very useful for making frames and decorations. You would most probably also be using a filled image (as in <span class="text-muted">CoreUI.Gfx.IFill.FillAuto (object still in beta stage)</span>) to use as a frame.</summary>
        /// <param name="fill">Fill mode of the center region. The default behavior is to render and scale the center area, respecting its transparency.<br/>The default value is <see cref="CoreUI.Gfx.CenterFillMode.Default"/>.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetCenterFillMode(CoreUI.Gfx.CenterFillMode fill) {
            CoreUI.Gfx.IImageNativeMethods.efl_gfx_image_center_fill_mode_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), fill);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>This property defines the stretchable pixels region of an image.
        /// 
        /// When the regions are set by the user, the method will walk the iterators once and then destroy them. When the regions are retrieved by the user, it is his responsibility to destroy the iterators.. It will remember the information for the lifetime of the object. It will ignore all value of <see cref="CoreUI.Gfx.IImage.BorderInsets"/>, <see cref="CoreUI.Gfx.IImage.BorderInsetsScale"/> and <see cref="CoreUI.Gfx.IImage.CenterFillMode"/> . To reset the object you can just pass <c>null</c> to both horizontal and vertical at the same time.</summary>
        /// <param name="horizontal">Representation of areas that are stretchable in the image horizontal space.<br/>The default value is <c>null</c>.</param>
        /// <param name="vertical">Representation of areas that are stretchable in the image vertical space.<br/>The default value is <c>null</c>.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void GetStretchRegion(out IEnumerable<CoreUI.Gfx.ImageStretchRegion> horizontal, out IEnumerable<CoreUI.Gfx.ImageStretchRegion> vertical) {
            System.IntPtr _out_horizontal = System.IntPtr.Zero;
System.IntPtr _out_vertical = System.IntPtr.Zero;
CoreUI.Gfx.IImageNativeMethods.efl_gfx_image_stretch_region_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), out _out_horizontal, out _out_vertical);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
horizontal = CoreUI.Wrapper.Globals.IteratorToIEnumerable<CoreUI.Gfx.ImageStretchRegion>(_out_horizontal);
vertical = CoreUI.Wrapper.Globals.IteratorToIEnumerable<CoreUI.Gfx.ImageStretchRegion>(_out_vertical);
            
        }

        /// <summary>This property defines the stretchable pixels region of an image.
        /// 
        /// When the regions are set by the user, the method will walk the iterators once and then destroy them. When the regions are retrieved by the user, it is his responsibility to destroy the iterators.. It will remember the information for the lifetime of the object. It will ignore all value of <see cref="CoreUI.Gfx.IImage.BorderInsets"/>, <see cref="CoreUI.Gfx.IImage.BorderInsetsScale"/> and <see cref="CoreUI.Gfx.IImage.CenterFillMode"/> . To reset the object you can just pass <c>null</c> to both horizontal and vertical at the same time.</summary>
        /// <param name="horizontal">Representation of areas that are stretchable in the image horizontal space.<br/>The default value is <c>null</c>.</param>
        /// <param name="vertical">Representation of areas that are stretchable in the image vertical space.<br/>The default value is <c>null</c>.</param>
        /// <returns>Return an error code if the provided values are incorrect.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.DataTypes.Error SetStretchRegion(IEnumerable<CoreUI.Gfx.ImageStretchRegion> horizontal, IEnumerable<CoreUI.Gfx.ImageStretchRegion> vertical) {
            var _in_horizontal = CoreUI.Wrapper.Globals.IEnumerableToIterator(horizontal, true);
var _in_vertical = CoreUI.Wrapper.Globals.IEnumerableToIterator(vertical, true);
var _ret_var = CoreUI.Gfx.IImageNativeMethods.efl_gfx_image_stretch_region_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), _in_horizontal, _in_vertical);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>This represents the size of the original image in pixels.
        /// 
        /// This may be different from the actual geometry on screen or even the size of the loaded pixel buffer. This is the size of the image as stored in the original file.
        /// 
        /// This is a read-only property and may return 0x0.</summary>
        /// <returns>The size in pixels. The default value is the size of the image&apos;s internal buffer.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.DataTypes.Size2D GetImageSize() {
            var _ret_var = CoreUI.Gfx.IImageNativeMethods.efl_gfx_image_size_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Content hint setting for the image. These hints might be used by EFL to enable optimizations.
        /// 
        /// For example, if you&apos;re on the GL engine and your driver implementation supports it, setting this hint to <see cref="CoreUI.Gfx.ImageContentHint.Dynamic"/> will make it need zero copies at texture upload time, which is an &quot;expensive&quot; operation.</summary>
        /// <returns>Dynamic or static content hint.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.Gfx.ImageContentHint GetContentHint() {
            var _ret_var = CoreUI.Gfx.IImageNativeMethods.efl_gfx_image_content_hint_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Content hint setting for the image. These hints might be used by EFL to enable optimizations.
        /// 
        /// For example, if you&apos;re on the GL engine and your driver implementation supports it, setting this hint to <see cref="CoreUI.Gfx.ImageContentHint.Dynamic"/> will make it need zero copies at texture upload time, which is an &quot;expensive&quot; operation.</summary>
        /// <param name="hint">Dynamic or static content hint.<br/>The default value is <see cref="CoreUI.Gfx.ImageContentHint.None"/>.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetContentHint(CoreUI.Gfx.ImageContentHint hint) {
            CoreUI.Gfx.IImageNativeMethods.efl_gfx_image_content_hint_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), hint);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The scale hint of a given image of the canvas.
        /// 
        /// The scale hint affects how EFL is to cache scaled versions of its original source image.</summary>
        /// <returns>Scalable or static size hint.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.Gfx.ImageScaleHint GetScaleHint() {
            var _ret_var = CoreUI.Gfx.IImageNativeMethods.efl_gfx_image_scale_hint_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The scale hint of a given image of the canvas.
        /// 
        /// The scale hint affects how EFL is to cache scaled versions of its original source image.</summary>
        /// <param name="hint">Scalable or static size hint.<br/>The default value is <see cref="CoreUI.Gfx.ImageScaleHint.None"/>.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetScaleHint(CoreUI.Gfx.ImageScaleHint hint) {
            CoreUI.Gfx.IImageNativeMethods.efl_gfx_image_scale_hint_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), hint);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The (last) file loading error for a given object. This value is set to a nonzero value if an error has occurred.</summary>
        /// <returns>The load error code. A value of $0 indicates no error.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.DataTypes.Error GetImageLoadError() {
            var _ret_var = CoreUI.Gfx.IImageNativeMethods.efl_gfx_image_load_error_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The load size of an image.
        /// 
        /// The image will be loaded into memory as if it was the specified size instead of its original size. This can save a lot of memory and is important for scalable types like SVG.
        /// 
        /// EFL will try to load an image of the requested size but does not guarantee an exact match between the request and the loaded image dimensions.
        /// 
        /// By default, the load size is not specified, so it is <c>0x0</c>.</summary>
        /// <returns>The image load size.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.DataTypes.Size2D GetLoadSize() {
            var _ret_var = CoreUI.Gfx.IImageLoadControllerNativeMethods.efl_gfx_image_load_controller_load_size_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The load size of an image.
        /// 
        /// The image will be loaded into memory as if it was the specified size instead of its original size. This can save a lot of memory and is important for scalable types like SVG.
        /// 
        /// EFL will try to load an image of the requested size but does not guarantee an exact match between the request and the loaded image dimensions.
        /// 
        /// By default, the load size is not specified, so it is <c>0x0</c>.</summary>
        /// <param name="size">The image load size.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetLoadSize(CoreUI.DataTypes.Size2D size) {
            CoreUI.DataTypes.Size2D _in_size = size;
CoreUI.Gfx.IImageLoadControllerNativeMethods.efl_gfx_image_load_controller_load_size_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), _in_size);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The DPI resolution of an image object&apos;s source image.
        /// 
        /// Most useful for the SVG image loader.</summary>
        /// <returns>The DPI resolution.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual double GetLoadDpi() {
            var _ret_var = CoreUI.Gfx.IImageLoadControllerNativeMethods.efl_gfx_image_load_controller_load_dpi_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The DPI resolution of an image object&apos;s source image.
        /// 
        /// Most useful for the SVG image loader.</summary>
        /// <param name="dpi">The DPI resolution.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetLoadDpi(double dpi) {
            CoreUI.Gfx.IImageLoadControllerNativeMethods.efl_gfx_image_load_controller_load_dpi_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), dpi);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Indicates whether the <see cref="CoreUI.Gfx.IImageLoadController.LoadRegion"/> property is supported for the current file.</summary>
        /// <returns><c>true</c> if region load of the image is supported, <c>false</c> otherwise.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetLoadRegionSupport() {
            var _ret_var = CoreUI.Gfx.IImageLoadControllerNativeMethods.efl_gfx_image_load_controller_load_region_support_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Inform a given image object to load a selective region of its source image.
        /// 
        /// This property is useful when one is not showing all of an image&apos;s area on its image object.
        /// 
        /// <b>NOTE: </b>The image loader for the image format in question has to support selective region loading in order for this function to work (see <see cref="CoreUI.Gfx.IImageLoadController.GetLoadRegionSupport"/>).</summary>
        /// <returns>A region of the image.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.DataTypes.Rect GetLoadRegion() {
            var _ret_var = CoreUI.Gfx.IImageLoadControllerNativeMethods.efl_gfx_image_load_controller_load_region_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Inform a given image object to load a selective region of its source image.
        /// 
        /// This property is useful when one is not showing all of an image&apos;s area on its image object.
        /// 
        /// <b>NOTE: </b>The image loader for the image format in question has to support selective region loading in order for this function to work (see <see cref="CoreUI.Gfx.IImageLoadController.GetLoadRegionSupport"/>).</summary>
        /// <param name="region">A region of the image.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetLoadRegion(CoreUI.DataTypes.Rect region) {
            CoreUI.DataTypes.Rect _in_region = region;
CoreUI.Gfx.IImageLoadControllerNativeMethods.efl_gfx_image_load_controller_load_region_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), _in_region);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Defines whether the orientation information in the image file should be honored.
        /// 
        /// The orientation can for instance be set in the EXIF tags of a JPEG image. If this flag is <c>false</c>, then the orientation will be ignored at load time, otherwise the image will be loaded with the proper orientation.</summary>
        /// <returns><c>true</c> means that it should honor the orientation information.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetLoadOrientation() {
            var _ret_var = CoreUI.Gfx.IImageLoadControllerNativeMethods.efl_gfx_image_load_controller_load_orientation_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Defines whether the orientation information in the image file should be honored.
        /// 
        /// The orientation can for instance be set in the EXIF tags of a JPEG image. If this flag is <c>false</c>, then the orientation will be ignored at load time, otherwise the image will be loaded with the proper orientation.</summary>
        /// <param name="enable"><c>true</c> means that it should honor the orientation information.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetLoadOrientation(bool enable) {
            CoreUI.Gfx.IImageLoadControllerNativeMethods.efl_gfx_image_load_controller_load_orientation_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), enable);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The scale down factor is a divider on the original image size.
        /// 
        /// Setting the scale down factor can reduce load time and memory usage at the cost of having a scaled down image in memory.
        /// 
        /// This function sets the scale down factor of a given canvas image. Most useful for the SVG image loader but also applies to JPEG, PNG and BMP.
        /// 
        /// Powers of two (2, 4, 8, ...) are best supported (especially with JPEG).</summary>
        /// <returns>The scale down dividing factor.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual int GetLoadScaleDown() {
            var _ret_var = CoreUI.Gfx.IImageLoadControllerNativeMethods.efl_gfx_image_load_controller_load_scale_down_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The scale down factor is a divider on the original image size.
        /// 
        /// Setting the scale down factor can reduce load time and memory usage at the cost of having a scaled down image in memory.
        /// 
        /// This function sets the scale down factor of a given canvas image. Most useful for the SVG image loader but also applies to JPEG, PNG and BMP.
        /// 
        /// Powers of two (2, 4, 8, ...) are best supported (especially with JPEG).</summary>
        /// <param name="div">The scale down dividing factor.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetLoadScaleDown(int div) {
            CoreUI.Gfx.IImageLoadControllerNativeMethods.efl_gfx_image_load_controller_load_scale_down_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), div);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Initial load should skip header check and leave it all to data load.
        /// 
        /// If this is <c>true</c>, then future loads of images will defer header loading to a preload stage and/or data load later on rather than at the start when the load begins (e.g. when file is set).</summary>
        /// <returns><c>true</c> if header is to be skipped.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetLoadSkipHeader() {
            var _ret_var = CoreUI.Gfx.IImageLoadControllerNativeMethods.efl_gfx_image_load_controller_load_skip_header_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Initial load should skip header check and leave it all to data load.
        /// 
        /// If this is <c>true</c>, then future loads of images will defer header loading to a preload stage and/or data load later on rather than at the start when the load begins (e.g. when file is set).</summary>
        /// <param name="skip"><c>true</c> if header is to be skipped.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetLoadSkipHeader(bool skip) {
            CoreUI.Gfx.IImageLoadControllerNativeMethods.efl_gfx_image_load_controller_load_skip_header_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), skip);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Begin preloading an image object&apos;s image data in the background.
        /// 
        /// Once the background task is complete the event @[.load,done] will be emitted if loading succeeded, @[.load,error] otherwise.</summary>
        /// <since_tizen> 6 </since_tizen>
        public virtual void LoadAsyncStart() {
            CoreUI.Gfx.IImageLoadControllerNativeMethods.efl_gfx_image_load_controller_load_async_start_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Cancel preloading an image object&apos;s image data in the background.
        /// 
        /// The object should be left in a state where it has no image data. If cancel is called too late, the image will be kept in memory.</summary>
        /// <since_tizen> 6 </since_tizen>
        public virtual void CancelLoadAsync() {
            CoreUI.Gfx.IImageLoadControllerNativeMethods.efl_gfx_image_load_controller_load_async_cancel_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The mmaped file from where an object will fetch the real data (it must be an <see cref="CoreUI.DataTypes.File"/>).
        /// 
        /// If mmap is set during object construction, the object will automatically call <see cref="CoreUI.IFile.Load"/> during the finalize phase of construction.</summary>
        /// <value>The handle to the <see cref="CoreUI.DataTypes.File"/> that will be used</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.DataTypes.File Mmap {
            get { return GetMmap(); }
            set { SetMmap(value); }
        }

        /// <summary>The file path from where an object will fetch the data.
        /// 
        /// If file is set during object construction, the object will automatically call <see cref="CoreUI.IFile.Load"/> during the finalize phase of construction.
        /// 
        /// You must not modify the strings on the returned pointers.</summary>
        /// <value>The file path.</value>
        /// <since_tizen> 6 </since_tizen>
        public System.String File {
            get { return GetFile(); }
            set { SetFile(value); }
        }

        /// <summary>The key which corresponds to the target data within a file.
        /// 
        /// Some file types can contain multiple data streams which are indexed by a key. Use this property for such cases (See for example <see cref="CoreUI.UI.Image"/> or <see cref="CoreUI.UI.Layout"/>).
        /// 
        /// You must not modify the strings on the returned pointers.</summary>
        /// <value>The group that the data belongs to. See the class documentation for particular implementations of this interface to see how this property is used.</value>
        /// <since_tizen> 6 </since_tizen>
        public System.String Key {
            get { return GetKey(); }
            set { SetKey(value); }
        }

        /// <summary>The load state of the object.</summary>
        /// <value><c>true</c> if the object is loaded, <c>false</c> otherwise.</value>
        /// <since_tizen> 6 </since_tizen>
        public bool Loaded {
            get { return GetLoaded(); }
        }

        /// <summary>Whether to use high-quality image scaling algorithm for this image.
        /// 
        /// When enabled, a higher quality image scaling algorithm is used when scaling images to sizes other than the source image&apos;s original one. This gives better results but is more computationally expensive.</summary>
        /// <value>Whether to use smooth scale or not.</value>
        /// <since_tizen> 6 </since_tizen>
        public bool SmoothScale {
            get { return GetSmoothScale(); }
            set { SetSmoothScale(value); }
        }

        /// <summary>Determine how the image is scaled at render time.
        /// 
        /// This allows more granular controls for how an image object should display its internal buffer. The underlying image data will not be modified.</summary>
        /// <value>Image scale type to use.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.Gfx.ImageScaleMethod ScaleMethod {
            get { return GetScaleMethod(); }
            set { SetScaleMethod(value); }
        }

        /// <summary>If <c>true</c>, the image may be scaled to a larger size. If <c>false</c>, the image will never be resized larger than its native size.</summary>
        /// <value>Whether to allow image upscaling.</value>
        /// <since_tizen> 6 </since_tizen>
        public bool CanUpscale {
            get { return GetCanUpscale(); }
            set { SetCanUpscale(value); }
        }

        /// <summary>If <c>true</c>, the image may be scaled to a smaller size. If <c>false</c>, the image will never be resized smaller than its native size.</summary>
        /// <value>Whether to allow image downscaling.</value>
        /// <since_tizen> 6 </since_tizen>
        public bool CanDownscale {
            get { return GetCanDownscale(); }
            set { SetCanDownscale(value); }
        }

        /// <summary>The native width/height ratio of the image.
        /// 
        /// The ratio will be 1.0 if it cannot be calculated (e.g. height = 0).</summary>
        /// <value>The image&apos;s ratio.</value>
        /// <since_tizen> 6 </since_tizen>
        public double Ratio {
            get { return GetRatio(); }
        }

        /// <summary>Return the relative area enclosed inside the image where content is expected.
        /// 
        /// We do expect content to be inside the limit defined by the border or inside the stretch region. If a stretch region is provided, the content region will encompass the non-stretchable area that are surrounded by stretchable area. If no border and no stretch region is set, they are assumed to be zero and the full object geometry is where content can be layout on top. The area size change with the object size.
        /// 
        /// The geometry of the area is expressed relative to the geometry of the object.</summary>
        /// <value>A rectangle inside the object boundary where content is expected. The default value is the image object&apos;s geometry with the <see cref="CoreUI.Gfx.IImage.BorderInsets"/> values subtracted.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.DataTypes.Rect ContentRegion {
            get { return GetContentRegion(); }
        }

        /// <summary>Dimensions of this image&apos;s border, a region that does not scale with the center area.
        /// 
        /// When EFL renders an image, its source may be scaled to fit the size of the object. This function sets an area from the borders of the image inwards which is not to be scaled. This function is useful for making frames and for widget theming, where, for example, buttons may be of varying sizes, but their border size must remain constant.
        /// 
        /// The units used for <c>l</c>, <c>r</c>, <c>t</c> and <c>b</c> are canvas units (pixels).
        /// 
        /// <b>NOTE: </b>The border region itself may be scaled by the <see cref="CoreUI.Gfx.IImage.SetBorderInsetsScale"/> function.
        /// 
        /// <b>NOTE: </b>By default, image objects have no borders set, i.e. <c>l</c>, <c>r</c>, <c>t</c> and <c>b</c> start as 0.
        /// 
        /// <b>NOTE: </b>Similar to the concepts of 9-patch images or cap insets.</summary>
        /// <value>The border&apos;s left width.</value>
        /// <since_tizen> 6 </since_tizen>
        public (int, int, int, int) BorderInsets {
            get {
                int _out_l = default(int);
                int _out_r = default(int);
                int _out_t = default(int);
                int _out_b = default(int);
                GetBorderInsets(out _out_l, out _out_r, out _out_t, out _out_b);
                return (_out_l, _out_r, _out_t, _out_b);
            }
            set { SetBorderInsets( value.Item1,  value.Item2,  value.Item3,  value.Item4); }
        }

        /// <summary>Scaling factor applied to the image borders.
        /// 
        /// This value multiplies the size of the <see cref="CoreUI.Gfx.IImage.BorderInsets"/> when scaling an object.</summary>
        /// <value>The scale factor.</value>
        /// <since_tizen> 6 </since_tizen>
        public double BorderInsetsScale {
            get { return GetBorderInsetsScale(); }
            set { SetBorderInsetsScale(value); }
        }

        /// <summary>Specifies how the center part of the object (not the borders) should be drawn when EFL is rendering it.
        /// 
        /// This function sets how the center part of the image object&apos;s source image is to be drawn, which must be one of the values in <see cref="CoreUI.Gfx.CenterFillMode"/>. By center we mean the complementary part of that defined by <see cref="CoreUI.Gfx.IImage.SetBorderInsets"/>. This is very useful for making frames and decorations. You would most probably also be using a filled image (as in <span class="text-muted">CoreUI.Gfx.IFill.FillAuto (object still in beta stage)</span>) to use as a frame.</summary>
        /// <value>Fill mode of the center region. The default behavior is to render and scale the center area, respecting its transparency.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.Gfx.CenterFillMode CenterFillMode {
            get { return GetCenterFillMode(); }
            set { SetCenterFillMode(value); }
        }

        /// <summary>This property defines the stretchable pixels region of an image.
        /// 
        /// When the regions are set by the user, the method will walk the iterators once and then destroy them. When the regions are retrieved by the user, it is his responsibility to destroy the iterators.. It will remember the information for the lifetime of the object. It will ignore all value of <see cref="CoreUI.Gfx.IImage.BorderInsets"/>, <see cref="CoreUI.Gfx.IImage.BorderInsetsScale"/> and <see cref="CoreUI.Gfx.IImage.CenterFillMode"/> . To reset the object you can just pass <c>null</c> to both horizontal and vertical at the same time.</summary>
        /// <value>Representation of areas that are stretchable in the image horizontal space.</value>
        /// <since_tizen> 6 </since_tizen>
        public (IEnumerable<CoreUI.Gfx.ImageStretchRegion>, IEnumerable<CoreUI.Gfx.ImageStretchRegion>) StretchRegion {
            get {
                IEnumerable<CoreUI.Gfx.ImageStretchRegion> _out_horizontal = default(IEnumerable<CoreUI.Gfx.ImageStretchRegion>);
                IEnumerable<CoreUI.Gfx.ImageStretchRegion> _out_vertical = default(IEnumerable<CoreUI.Gfx.ImageStretchRegion>);
                GetStretchRegion(out _out_horizontal, out _out_vertical);
                return (_out_horizontal, _out_vertical);
            }
            set { SetStretchRegion( value.Item1,  value.Item2); }
        }

        /// <summary>This represents the size of the original image in pixels.
        /// 
        /// This may be different from the actual geometry on screen or even the size of the loaded pixel buffer. This is the size of the image as stored in the original file.
        /// 
        /// This is a read-only property and may return 0x0.</summary>
        /// <value>The size in pixels. The default value is the size of the image&apos;s internal buffer.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.DataTypes.Size2D ImageSize {
            get { return GetImageSize(); }
        }

        /// <summary>Content hint setting for the image. These hints might be used by EFL to enable optimizations.
        /// 
        /// For example, if you&apos;re on the GL engine and your driver implementation supports it, setting this hint to <see cref="CoreUI.Gfx.ImageContentHint.Dynamic"/> will make it need zero copies at texture upload time, which is an &quot;expensive&quot; operation.</summary>
        /// <value>Dynamic or static content hint.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.Gfx.ImageContentHint ContentHint {
            get { return GetContentHint(); }
            set { SetContentHint(value); }
        }

        /// <summary>The scale hint of a given image of the canvas.
        /// 
        /// The scale hint affects how EFL is to cache scaled versions of its original source image.</summary>
        /// <value>Scalable or static size hint.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.Gfx.ImageScaleHint ScaleHint {
            get { return GetScaleHint(); }
            set { SetScaleHint(value); }
        }

        /// <summary>The (last) file loading error for a given object. This value is set to a nonzero value if an error has occurred.</summary>
        /// <value>The load error code. A value of $0 indicates no error.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.DataTypes.Error ImageLoadError {
            get { return GetImageLoadError(); }
        }

        /// <summary>The load size of an image.
        /// 
        /// The image will be loaded into memory as if it was the specified size instead of its original size. This can save a lot of memory and is important for scalable types like SVG.
        /// 
        /// EFL will try to load an image of the requested size but does not guarantee an exact match between the request and the loaded image dimensions.
        /// 
        /// By default, the load size is not specified, so it is <c>0x0</c>.</summary>
        /// <value>The image load size.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.DataTypes.Size2D LoadSize {
            get { return GetLoadSize(); }
            set { SetLoadSize(value); }
        }

        /// <summary>The DPI resolution of an image object&apos;s source image.
        /// 
        /// Most useful for the SVG image loader.</summary>
        /// <value>The DPI resolution.</value>
        /// <since_tizen> 6 </since_tizen>
        public double LoadDpi {
            get { return GetLoadDpi(); }
            set { SetLoadDpi(value); }
        }

        /// <summary>Indicates whether the <see cref="CoreUI.Gfx.IImageLoadController.LoadRegion"/> property is supported for the current file.</summary>
        /// <value><c>true</c> if region load of the image is supported, <c>false</c> otherwise.</value>
        /// <since_tizen> 6 </since_tizen>
        public bool LoadRegionSupport {
            get { return GetLoadRegionSupport(); }
        }

        /// <summary>Inform a given image object to load a selective region of its source image.
        /// 
        /// This property is useful when one is not showing all of an image&apos;s area on its image object.
        /// 
        /// <b>NOTE: </b>The image loader for the image format in question has to support selective region loading in order for this function to work (see <see cref="CoreUI.Gfx.IImageLoadController.GetLoadRegionSupport"/>).</summary>
        /// <value>A region of the image.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.DataTypes.Rect LoadRegion {
            get { return GetLoadRegion(); }
            set { SetLoadRegion(value); }
        }

        /// <summary>Defines whether the orientation information in the image file should be honored.
        /// 
        /// The orientation can for instance be set in the EXIF tags of a JPEG image. If this flag is <c>false</c>, then the orientation will be ignored at load time, otherwise the image will be loaded with the proper orientation.</summary>
        /// <value><c>true</c> means that it should honor the orientation information.</value>
        /// <since_tizen> 6 </since_tizen>
        public bool LoadOrientation {
            get { return GetLoadOrientation(); }
            set { SetLoadOrientation(value); }
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
        public int LoadScaleDown {
            get { return GetLoadScaleDown(); }
            set { SetLoadScaleDown(value); }
        }

        /// <summary>Initial load should skip header check and leave it all to data load.
        /// 
        /// If this is <c>true</c>, then future loads of images will defer header loading to a preload stage and/or data load later on rather than at the start when the load begins (e.g. when file is set).</summary>
        /// <value><c>true</c> if header is to be skipped.</value>
        /// <since_tizen> 6 </since_tizen>
        public bool LoadSkipHeader {
            get { return GetLoadSkipHeader(); }
            set { SetLoadSkipHeader(value); }
        }

        private static IntPtr GetCoreUIClassStatic()
        {
            return CoreUI.UI.Bg.efl_ui_bg_class_get();
        }

        /// <summary>Wrapper for native methods and virtual method delegates.
        /// For internal use by generated code only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal new class NativeMethods : CoreUI.UI.LayoutBase.NativeMethods
        {
            /// <summary>Gets the list of Eo operations to override.
        /// </summary>
            /// <returns>The list of Eo operations to be overload.</returns>
            internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
            {
                var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
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
                descs.AddRange(base.GetEoOps(type, false));
                return descs;
            }

            /// <summary>Returns the Eo class for the native methods of this class.
            /// </summary>
            /// <returns>The native class pointer.</returns>
            internal override IntPtr GetCoreUIClass()
            {
                return CoreUI.UI.Bg.efl_ui_bg_class_get();
            }

            #pragma warning disable CA1707, CS1591, SA1300, SA1600

            #pragma warning restore CA1707, CS1591, SA1300, SA1600

        }
    }
}

namespace CoreUI.UI {
#pragma warning disable CS1591
    /// <since_tizen> 6 </since_tizen>
    public static class BgExtensions {
        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.DataTypes.File> Mmap<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Bg, T>magic = null) where T : CoreUI.UI.Bg {
            return new CoreUI.BindableProperty<CoreUI.DataTypes.File>("mmap", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<System.String> File<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Bg, T>magic = null) where T : CoreUI.UI.Bg {
            return new CoreUI.BindableProperty<System.String>("file", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<System.String> Key<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Bg, T>magic = null) where T : CoreUI.UI.Bg {
            return new CoreUI.BindableProperty<System.String>("key", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> SmoothScale<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Bg, T>magic = null) where T : CoreUI.UI.Bg {
            return new CoreUI.BindableProperty<bool>("smooth_scale", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.Gfx.ImageScaleMethod> ScaleMethod<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Bg, T>magic = null) where T : CoreUI.UI.Bg {
            return new CoreUI.BindableProperty<CoreUI.Gfx.ImageScaleMethod>("scale_method", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> CanUpscale<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Bg, T>magic = null) where T : CoreUI.UI.Bg {
            return new CoreUI.BindableProperty<bool>("can_upscale", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> CanDownscale<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Bg, T>magic = null) where T : CoreUI.UI.Bg {
            return new CoreUI.BindableProperty<bool>("can_downscale", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<double> BorderInsetsScale<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Bg, T>magic = null) where T : CoreUI.UI.Bg {
            return new CoreUI.BindableProperty<double>("border_insets_scale", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.Gfx.CenterFillMode> CenterFillMode<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Bg, T>magic = null) where T : CoreUI.UI.Bg {
            return new CoreUI.BindableProperty<CoreUI.Gfx.CenterFillMode>("center_fill_mode", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.Gfx.ImageContentHint> ContentHint<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Bg, T>magic = null) where T : CoreUI.UI.Bg {
            return new CoreUI.BindableProperty<CoreUI.Gfx.ImageContentHint>("content_hint", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.Gfx.ImageScaleHint> ScaleHint<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Bg, T>magic = null) where T : CoreUI.UI.Bg {
            return new CoreUI.BindableProperty<CoreUI.Gfx.ImageScaleHint>("scale_hint", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.DataTypes.Size2D> LoadSize<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Bg, T>magic = null) where T : CoreUI.UI.Bg {
            return new CoreUI.BindableProperty<CoreUI.DataTypes.Size2D>("load_size", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<double> LoadDpi<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Bg, T>magic = null) where T : CoreUI.UI.Bg {
            return new CoreUI.BindableProperty<double>("load_dpi", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.DataTypes.Rect> LoadRegion<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Bg, T>magic = null) where T : CoreUI.UI.Bg {
            return new CoreUI.BindableProperty<CoreUI.DataTypes.Rect>("load_region", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> LoadOrientation<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Bg, T>magic = null) where T : CoreUI.UI.Bg {
            return new CoreUI.BindableProperty<bool>("load_orientation", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<int> LoadScaleDown<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Bg, T>magic = null) where T : CoreUI.UI.Bg {
            return new CoreUI.BindableProperty<int>("load_scale_down", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> LoadSkipHeader<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Bg, T>magic = null) where T : CoreUI.UI.Bg {
            return new CoreUI.BindableProperty<bool>("load_skip_header", fac.GetPropBind());
        }

    }
#pragma warning restore CS1591
}

