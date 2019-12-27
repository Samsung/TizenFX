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
    /// <summary>This interface defines a set of common APIs which should be implemented by image objects.
    /// 
    /// These APIs provide the ability to manipulate how images will be rendered, e.g., determining whether to allow upscaling and downscaling at render time, as well as functionality for detecting errors during the loading process.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Gfx.IImageNativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    public interface IImage : 
        CoreUI.Wrapper.IWrapper, IDisposable
    {
        /// <summary>Whether to use high-quality image scaling algorithm for this image.
        /// 
        /// When enabled, a higher quality image scaling algorithm is used when scaling images to sizes other than the source image&apos;s original one. This gives better results but is more computationally expensive.</summary>
        /// <returns>Whether to use smooth scale or not.</returns>
        /// <since_tizen> 6 </since_tizen>
        bool GetSmoothScale();

        /// <summary>Whether to use high-quality image scaling algorithm for this image.
        /// 
        /// When enabled, a higher quality image scaling algorithm is used when scaling images to sizes other than the source image&apos;s original one. This gives better results but is more computationally expensive.</summary>
        /// <param name="smooth_scale">Whether to use smooth scale or not.<br/>The default value is <c>true</c>.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetSmoothScale(bool smooth_scale);

        /// <summary>Determine how the image is scaled at render time.
        /// 
        /// This allows more granular controls for how an image object should display its internal buffer. The underlying image data will not be modified.</summary>
        /// <returns>Image scale type to use.</returns>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.Gfx.ImageScaleMethod GetScaleMethod();

        /// <summary>Determine how the image is scaled at render time.
        /// 
        /// This allows more granular controls for how an image object should display its internal buffer. The underlying image data will not be modified.</summary>
        /// <param name="scale_method">Image scale type to use.<br/>The default value is <see cref="CoreUI.Gfx.ImageScaleMethod.None"/>.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetScaleMethod(CoreUI.Gfx.ImageScaleMethod scale_method);

        /// <summary>If <c>true</c>, the image may be scaled to a larger size. If <c>false</c>, the image will never be resized larger than its native size.</summary>
        /// <returns>Whether to allow image upscaling.</returns>
        /// <since_tizen> 6 </since_tizen>
        bool GetCanUpscale();

        /// <summary>If <c>true</c>, the image may be scaled to a larger size. If <c>false</c>, the image will never be resized larger than its native size.</summary>
        /// <param name="upscale">Whether to allow image upscaling.<br/>The default value is <c>true</c>.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetCanUpscale(bool upscale);

        /// <summary>If <c>true</c>, the image may be scaled to a smaller size. If <c>false</c>, the image will never be resized smaller than its native size.</summary>
        /// <returns>Whether to allow image downscaling.</returns>
        /// <since_tizen> 6 </since_tizen>
        bool GetCanDownscale();

        /// <summary>If <c>true</c>, the image may be scaled to a smaller size. If <c>false</c>, the image will never be resized smaller than its native size.</summary>
        /// <param name="downscale">Whether to allow image downscaling.<br/>The default value is <c>true</c>.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetCanDownscale(bool downscale);

        /// <summary>The native width/height ratio of the image.
        /// 
        /// The ratio will be 1.0 if it cannot be calculated (e.g. height = 0).</summary>
        /// <returns>The image&apos;s ratio.</returns>
        /// <since_tizen> 6 </since_tizen>
        double GetRatio();

        /// <summary>Return the relative area enclosed inside the image where content is expected.
        /// 
        /// We do expect content to be inside the limit defined by the border or inside the stretch region. If a stretch region is provided, the content region will encompass the non-stretchable area that are surrounded by stretchable area. If no border and no stretch region is set, they are assumed to be zero and the full object geometry is where content can be layout on top. The area size change with the object size.
        /// 
        /// The geometry of the area is expressed relative to the geometry of the object.</summary>
        /// <returns>A rectangle inside the object boundary where content is expected. The default value is the image object&apos;s geometry with the <see cref="CoreUI.Gfx.IImage.BorderInsets"/> values subtracted.</returns>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.DataTypes.Rect GetContentRegion();

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
        void GetBorderInsets(out int l, out int r, out int t, out int b);

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
        void SetBorderInsets(int l, int r, int t, int b);

        /// <summary>Scaling factor applied to the image borders.
        /// 
        /// This value multiplies the size of the <see cref="CoreUI.Gfx.IImage.BorderInsets"/> when scaling an object.</summary>
        /// <returns>The scale factor.</returns>
        /// <since_tizen> 6 </since_tizen>
        double GetBorderInsetsScale();

        /// <summary>Scaling factor applied to the image borders.
        /// 
        /// This value multiplies the size of the <see cref="CoreUI.Gfx.IImage.BorderInsets"/> when scaling an object.</summary>
        /// <param name="scale">The scale factor.<br/>The default value is <c>1.000000</c>.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetBorderInsetsScale(double scale);

        /// <summary>Specifies how the center part of the object (not the borders) should be drawn when EFL is rendering it.
        /// 
        /// This function sets how the center part of the image object&apos;s source image is to be drawn, which must be one of the values in <see cref="CoreUI.Gfx.CenterFillMode"/>. By center we mean the complementary part of that defined by <see cref="CoreUI.Gfx.IImage.SetBorderInsets"/>. This is very useful for making frames and decorations. You would most probably also be using a filled image (as in <span class="text-muted">CoreUI.Gfx.IFill.FillAuto (object still in beta stage)</span>) to use as a frame.</summary>
        /// <returns>Fill mode of the center region. The default behavior is to render and scale the center area, respecting its transparency.</returns>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.Gfx.CenterFillMode GetCenterFillMode();

        /// <summary>Specifies how the center part of the object (not the borders) should be drawn when EFL is rendering it.
        /// 
        /// This function sets how the center part of the image object&apos;s source image is to be drawn, which must be one of the values in <see cref="CoreUI.Gfx.CenterFillMode"/>. By center we mean the complementary part of that defined by <see cref="CoreUI.Gfx.IImage.SetBorderInsets"/>. This is very useful for making frames and decorations. You would most probably also be using a filled image (as in <span class="text-muted">CoreUI.Gfx.IFill.FillAuto (object still in beta stage)</span>) to use as a frame.</summary>
        /// <param name="fill">Fill mode of the center region. The default behavior is to render and scale the center area, respecting its transparency.<br/>The default value is <see cref="CoreUI.Gfx.CenterFillMode.Default"/>.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetCenterFillMode(CoreUI.Gfx.CenterFillMode fill);

        /// <summary>This property defines the stretchable pixels region of an image.
        /// 
        /// When the regions are set by the user, the method will walk the iterators once and then destroy them. When the regions are retrieved by the user, it is his responsibility to destroy the iterators.. It will remember the information for the lifetime of the object. It will ignore all value of <see cref="CoreUI.Gfx.IImage.BorderInsets"/>, <see cref="CoreUI.Gfx.IImage.BorderInsetsScale"/> and <see cref="CoreUI.Gfx.IImage.CenterFillMode"/> . To reset the object you can just pass <c>null</c> to both horizontal and vertical at the same time.</summary>
        /// <param name="horizontal">Representation of areas that are stretchable in the image horizontal space.<br/>The default value is <c>null</c>.</param>
        /// <param name="vertical">Representation of areas that are stretchable in the image vertical space.<br/>The default value is <c>null</c>.</param>
        /// <since_tizen> 6 </since_tizen>
        void GetStretchRegion(out IEnumerable<CoreUI.Gfx.ImageStretchRegion> horizontal, out IEnumerable<CoreUI.Gfx.ImageStretchRegion> vertical);

        /// <summary>This property defines the stretchable pixels region of an image.
        /// 
        /// When the regions are set by the user, the method will walk the iterators once and then destroy them. When the regions are retrieved by the user, it is his responsibility to destroy the iterators.. It will remember the information for the lifetime of the object. It will ignore all value of <see cref="CoreUI.Gfx.IImage.BorderInsets"/>, <see cref="CoreUI.Gfx.IImage.BorderInsetsScale"/> and <see cref="CoreUI.Gfx.IImage.CenterFillMode"/> . To reset the object you can just pass <c>null</c> to both horizontal and vertical at the same time.</summary>
        /// <param name="horizontal">Representation of areas that are stretchable in the image horizontal space.<br/>The default value is <c>null</c>.</param>
        /// <param name="vertical">Representation of areas that are stretchable in the image vertical space.<br/>The default value is <c>null</c>.</param>
        /// <returns>Return an error code if the provided values are incorrect.</returns>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.DataTypes.Error SetStretchRegion(IEnumerable<CoreUI.Gfx.ImageStretchRegion> horizontal, IEnumerable<CoreUI.Gfx.ImageStretchRegion> vertical);

        /// <summary>This represents the size of the original image in pixels.
        /// 
        /// This may be different from the actual geometry on screen or even the size of the loaded pixel buffer. This is the size of the image as stored in the original file.
        /// 
        /// This is a read-only property and may return 0x0.</summary>
        /// <returns>The size in pixels. The default value is the size of the image&apos;s internal buffer.</returns>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.DataTypes.Size2D GetImageSize();

        /// <summary>Content hint setting for the image. These hints might be used by EFL to enable optimizations.
        /// 
        /// For example, if you&apos;re on the GL engine and your driver implementation supports it, setting this hint to <see cref="CoreUI.Gfx.ImageContentHint.Dynamic"/> will make it need zero copies at texture upload time, which is an &quot;expensive&quot; operation.</summary>
        /// <returns>Dynamic or static content hint.</returns>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.Gfx.ImageContentHint GetContentHint();

        /// <summary>Content hint setting for the image. These hints might be used by EFL to enable optimizations.
        /// 
        /// For example, if you&apos;re on the GL engine and your driver implementation supports it, setting this hint to <see cref="CoreUI.Gfx.ImageContentHint.Dynamic"/> will make it need zero copies at texture upload time, which is an &quot;expensive&quot; operation.</summary>
        /// <param name="hint">Dynamic or static content hint.<br/>The default value is <see cref="CoreUI.Gfx.ImageContentHint.None"/>.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetContentHint(CoreUI.Gfx.ImageContentHint hint);

        /// <summary>The scale hint of a given image of the canvas.
        /// 
        /// The scale hint affects how EFL is to cache scaled versions of its original source image.</summary>
        /// <returns>Scalable or static size hint.</returns>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.Gfx.ImageScaleHint GetScaleHint();

        /// <summary>The scale hint of a given image of the canvas.
        /// 
        /// The scale hint affects how EFL is to cache scaled versions of its original source image.</summary>
        /// <param name="hint">Scalable or static size hint.<br/>The default value is <see cref="CoreUI.Gfx.ImageScaleHint.None"/>.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetScaleHint(CoreUI.Gfx.ImageScaleHint hint);

        /// <summary>The (last) file loading error for a given object. This value is set to a nonzero value if an error has occurred.</summary>
        /// <returns>The load error code. A value of $0 indicates no error.</returns>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.DataTypes.Error GetImageLoadError();

        /// <summary>If <c>true</c>, image data has been preloaded and can be displayed. If <c>false</c>, the image data has been unloaded and can no longer be displayed.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.Gfx.ImageImagePreloadStateChangedEventArgs"/></value>
        event EventHandler<CoreUI.Gfx.ImageImagePreloadStateChangedEventArgs> ImagePreloadStateChanged;
        /// <summary>Image was resized (its pixel data). The event data is the image&apos;s new size.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.Gfx.ImageImageResizedEventArgs"/></value>
        event EventHandler<CoreUI.Gfx.ImageImageResizedEventArgs> ImageResized;
        /// <summary>Whether to use high-quality image scaling algorithm for this image.
        /// 
        /// When enabled, a higher quality image scaling algorithm is used when scaling images to sizes other than the source image&apos;s original one. This gives better results but is more computationally expensive.</summary>
        /// <value>Whether to use smooth scale or not.</value>
        /// <since_tizen> 6 </since_tizen>
        bool SmoothScale {
            get;
            set;
        }

        /// <summary>Determine how the image is scaled at render time.
        /// 
        /// This allows more granular controls for how an image object should display its internal buffer. The underlying image data will not be modified.</summary>
        /// <value>Image scale type to use.</value>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.Gfx.ImageScaleMethod ScaleMethod {
            get;
            set;
        }

        /// <summary>If <c>true</c>, the image may be scaled to a larger size. If <c>false</c>, the image will never be resized larger than its native size.</summary>
        /// <value>Whether to allow image upscaling.</value>
        /// <since_tizen> 6 </since_tizen>
        bool CanUpscale {
            get;
            set;
        }

        /// <summary>If <c>true</c>, the image may be scaled to a smaller size. If <c>false</c>, the image will never be resized smaller than its native size.</summary>
        /// <value>Whether to allow image downscaling.</value>
        /// <since_tizen> 6 </since_tizen>
        bool CanDownscale {
            get;
            set;
        }

        /// <summary>The native width/height ratio of the image.
        /// 
        /// The ratio will be 1.0 if it cannot be calculated (e.g. height = 0).</summary>
        /// <value>The image&apos;s ratio.</value>
        /// <since_tizen> 6 </since_tizen>
        double Ratio {
            get;
        }

        /// <summary>Return the relative area enclosed inside the image where content is expected.
        /// 
        /// We do expect content to be inside the limit defined by the border or inside the stretch region. If a stretch region is provided, the content region will encompass the non-stretchable area that are surrounded by stretchable area. If no border and no stretch region is set, they are assumed to be zero and the full object geometry is where content can be layout on top. The area size change with the object size.
        /// 
        /// The geometry of the area is expressed relative to the geometry of the object.</summary>
        /// <value>A rectangle inside the object boundary where content is expected. The default value is the image object&apos;s geometry with the <see cref="CoreUI.Gfx.IImage.BorderInsets"/> values subtracted.</value>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.DataTypes.Rect ContentRegion {
            get;
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
        (int, int, int, int) BorderInsets {
            get;
            set;
        }

        /// <summary>Scaling factor applied to the image borders.
        /// 
        /// This value multiplies the size of the <see cref="CoreUI.Gfx.IImage.BorderInsets"/> when scaling an object.</summary>
        /// <value>The scale factor.</value>
        /// <since_tizen> 6 </since_tizen>
        double BorderInsetsScale {
            get;
            set;
        }

        /// <summary>Specifies how the center part of the object (not the borders) should be drawn when EFL is rendering it.
        /// 
        /// This function sets how the center part of the image object&apos;s source image is to be drawn, which must be one of the values in <see cref="CoreUI.Gfx.CenterFillMode"/>. By center we mean the complementary part of that defined by <see cref="CoreUI.Gfx.IImage.SetBorderInsets"/>. This is very useful for making frames and decorations. You would most probably also be using a filled image (as in <span class="text-muted">CoreUI.Gfx.IFill.FillAuto (object still in beta stage)</span>) to use as a frame.</summary>
        /// <value>Fill mode of the center region. The default behavior is to render and scale the center area, respecting its transparency.</value>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.Gfx.CenterFillMode CenterFillMode {
            get;
            set;
        }

        /// <summary>This property defines the stretchable pixels region of an image.
        /// 
        /// When the regions are set by the user, the method will walk the iterators once and then destroy them. When the regions are retrieved by the user, it is his responsibility to destroy the iterators.. It will remember the information for the lifetime of the object. It will ignore all value of <see cref="CoreUI.Gfx.IImage.BorderInsets"/>, <see cref="CoreUI.Gfx.IImage.BorderInsetsScale"/> and <see cref="CoreUI.Gfx.IImage.CenterFillMode"/> . To reset the object you can just pass <c>null</c> to both horizontal and vertical at the same time.</summary>
        /// <value>Representation of areas that are stretchable in the image horizontal space.</value>
        /// <since_tizen> 6 </since_tizen>
        (IEnumerable<CoreUI.Gfx.ImageStretchRegion>, IEnumerable<CoreUI.Gfx.ImageStretchRegion>) StretchRegion {
            get;
            set;
        }

        /// <summary>This represents the size of the original image in pixels.
        /// 
        /// This may be different from the actual geometry on screen or even the size of the loaded pixel buffer. This is the size of the image as stored in the original file.
        /// 
        /// This is a read-only property and may return 0x0.</summary>
        /// <value>The size in pixels. The default value is the size of the image&apos;s internal buffer.</value>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.DataTypes.Size2D ImageSize {
            get;
        }

        /// <summary>Content hint setting for the image. These hints might be used by EFL to enable optimizations.
        /// 
        /// For example, if you&apos;re on the GL engine and your driver implementation supports it, setting this hint to <see cref="CoreUI.Gfx.ImageContentHint.Dynamic"/> will make it need zero copies at texture upload time, which is an &quot;expensive&quot; operation.</summary>
        /// <value>Dynamic or static content hint.</value>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.Gfx.ImageContentHint ContentHint {
            get;
            set;
        }

        /// <summary>The scale hint of a given image of the canvas.
        /// 
        /// The scale hint affects how EFL is to cache scaled versions of its original source image.</summary>
        /// <value>Scalable or static size hint.</value>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.Gfx.ImageScaleHint ScaleHint {
            get;
            set;
        }

        /// <summary>The (last) file loading error for a given object. This value is set to a nonzero value if an error has occurred.</summary>
        /// <value>The load error code. A value of $0 indicates no error.</value>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.DataTypes.Error ImageLoadError {
            get;
        }

    }

    /// <summary>Event argument wrapper for event <see cref="CoreUI.Gfx.IImage.ImagePreloadStateChanged"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Wrapper.BindingEntity]
    public class ImageImagePreloadStateChangedEventArgs : EventArgs {
        /// <summary>Actual event payload.
        /// </summary>
        /// <value>If <c>true</c>, image data has been preloaded and can be displayed. If <c>false</c>, the image data has been unloaded and can no longer be displayed.</value>
        /// <since_tizen> 6 </since_tizen>
        public bool Arg { get; set; }
    }

    /// <summary>Event argument wrapper for event <see cref="CoreUI.Gfx.IImage.ImageResized"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Wrapper.BindingEntity]
    public class ImageImageResizedEventArgs : EventArgs {
        /// <summary>Actual event payload.
        /// </summary>
        /// <value>Image was resized (its pixel data). The event data is the image&apos;s new size.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.DataTypes.Size2D Arg { get; set; }
    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class IImageNativeMethods : CoreUI.Wrapper.ObjectWrapper.NativeMethods
    {
        [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
            efl_gfx_image_interface_get();
        private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.CoreUI);

        /// <summary>Gets the list of Eo operations to override.
    /// </summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
            var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

            if (efl_gfx_image_smooth_scale_get_static_delegate == null)
            {
                efl_gfx_image_smooth_scale_get_static_delegate = new efl_gfx_image_smooth_scale_get_delegate(smooth_scale_get);
            }

            if (methods.Contains("GetSmoothScale"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_smooth_scale_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_smooth_scale_get_static_delegate) });
            }

            if (efl_gfx_image_smooth_scale_set_static_delegate == null)
            {
                efl_gfx_image_smooth_scale_set_static_delegate = new efl_gfx_image_smooth_scale_set_delegate(smooth_scale_set);
            }

            if (methods.Contains("SetSmoothScale"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_smooth_scale_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_smooth_scale_set_static_delegate) });
            }

            if (efl_gfx_image_scale_method_get_static_delegate == null)
            {
                efl_gfx_image_scale_method_get_static_delegate = new efl_gfx_image_scale_method_get_delegate(scale_method_get);
            }

            if (methods.Contains("GetScaleMethod"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_scale_method_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_scale_method_get_static_delegate) });
            }

            if (efl_gfx_image_scale_method_set_static_delegate == null)
            {
                efl_gfx_image_scale_method_set_static_delegate = new efl_gfx_image_scale_method_set_delegate(scale_method_set);
            }

            if (methods.Contains("SetScaleMethod"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_scale_method_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_scale_method_set_static_delegate) });
            }

            if (efl_gfx_image_can_upscale_get_static_delegate == null)
            {
                efl_gfx_image_can_upscale_get_static_delegate = new efl_gfx_image_can_upscale_get_delegate(can_upscale_get);
            }

            if (methods.Contains("GetCanUpscale"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_can_upscale_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_can_upscale_get_static_delegate) });
            }

            if (efl_gfx_image_can_upscale_set_static_delegate == null)
            {
                efl_gfx_image_can_upscale_set_static_delegate = new efl_gfx_image_can_upscale_set_delegate(can_upscale_set);
            }

            if (methods.Contains("SetCanUpscale"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_can_upscale_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_can_upscale_set_static_delegate) });
            }

            if (efl_gfx_image_can_downscale_get_static_delegate == null)
            {
                efl_gfx_image_can_downscale_get_static_delegate = new efl_gfx_image_can_downscale_get_delegate(can_downscale_get);
            }

            if (methods.Contains("GetCanDownscale"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_can_downscale_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_can_downscale_get_static_delegate) });
            }

            if (efl_gfx_image_can_downscale_set_static_delegate == null)
            {
                efl_gfx_image_can_downscale_set_static_delegate = new efl_gfx_image_can_downscale_set_delegate(can_downscale_set);
            }

            if (methods.Contains("SetCanDownscale"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_can_downscale_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_can_downscale_set_static_delegate) });
            }

            if (efl_gfx_image_ratio_get_static_delegate == null)
            {
                efl_gfx_image_ratio_get_static_delegate = new efl_gfx_image_ratio_get_delegate(ratio_get);
            }

            if (methods.Contains("GetRatio"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_ratio_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_ratio_get_static_delegate) });
            }

            if (efl_gfx_image_content_region_get_static_delegate == null)
            {
                efl_gfx_image_content_region_get_static_delegate = new efl_gfx_image_content_region_get_delegate(content_region_get);
            }

            if (methods.Contains("GetContentRegion"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_content_region_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_content_region_get_static_delegate) });
            }

            if (efl_gfx_image_border_insets_get_static_delegate == null)
            {
                efl_gfx_image_border_insets_get_static_delegate = new efl_gfx_image_border_insets_get_delegate(border_insets_get);
            }

            if (methods.Contains("GetBorderInsets"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_border_insets_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_border_insets_get_static_delegate) });
            }

            if (efl_gfx_image_border_insets_set_static_delegate == null)
            {
                efl_gfx_image_border_insets_set_static_delegate = new efl_gfx_image_border_insets_set_delegate(border_insets_set);
            }

            if (methods.Contains("SetBorderInsets"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_border_insets_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_border_insets_set_static_delegate) });
            }

            if (efl_gfx_image_border_insets_scale_get_static_delegate == null)
            {
                efl_gfx_image_border_insets_scale_get_static_delegate = new efl_gfx_image_border_insets_scale_get_delegate(border_insets_scale_get);
            }

            if (methods.Contains("GetBorderInsetsScale"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_border_insets_scale_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_border_insets_scale_get_static_delegate) });
            }

            if (efl_gfx_image_border_insets_scale_set_static_delegate == null)
            {
                efl_gfx_image_border_insets_scale_set_static_delegate = new efl_gfx_image_border_insets_scale_set_delegate(border_insets_scale_set);
            }

            if (methods.Contains("SetBorderInsetsScale"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_border_insets_scale_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_border_insets_scale_set_static_delegate) });
            }

            if (efl_gfx_image_center_fill_mode_get_static_delegate == null)
            {
                efl_gfx_image_center_fill_mode_get_static_delegate = new efl_gfx_image_center_fill_mode_get_delegate(center_fill_mode_get);
            }

            if (methods.Contains("GetCenterFillMode"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_center_fill_mode_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_center_fill_mode_get_static_delegate) });
            }

            if (efl_gfx_image_center_fill_mode_set_static_delegate == null)
            {
                efl_gfx_image_center_fill_mode_set_static_delegate = new efl_gfx_image_center_fill_mode_set_delegate(center_fill_mode_set);
            }

            if (methods.Contains("SetCenterFillMode"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_center_fill_mode_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_center_fill_mode_set_static_delegate) });
            }

            if (efl_gfx_image_stretch_region_get_static_delegate == null)
            {
                efl_gfx_image_stretch_region_get_static_delegate = new efl_gfx_image_stretch_region_get_delegate(stretch_region_get);
            }

            if (methods.Contains("GetStretchRegion"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_stretch_region_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_stretch_region_get_static_delegate) });
            }

            if (efl_gfx_image_stretch_region_set_static_delegate == null)
            {
                efl_gfx_image_stretch_region_set_static_delegate = new efl_gfx_image_stretch_region_set_delegate(stretch_region_set);
            }

            if (methods.Contains("SetStretchRegion"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_stretch_region_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_stretch_region_set_static_delegate) });
            }

            if (efl_gfx_image_size_get_static_delegate == null)
            {
                efl_gfx_image_size_get_static_delegate = new efl_gfx_image_size_get_delegate(image_size_get);
            }

            if (methods.Contains("GetImageSize"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_size_get_static_delegate) });
            }

            if (efl_gfx_image_content_hint_get_static_delegate == null)
            {
                efl_gfx_image_content_hint_get_static_delegate = new efl_gfx_image_content_hint_get_delegate(content_hint_get);
            }

            if (methods.Contains("GetContentHint"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_content_hint_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_content_hint_get_static_delegate) });
            }

            if (efl_gfx_image_content_hint_set_static_delegate == null)
            {
                efl_gfx_image_content_hint_set_static_delegate = new efl_gfx_image_content_hint_set_delegate(content_hint_set);
            }

            if (methods.Contains("SetContentHint"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_content_hint_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_content_hint_set_static_delegate) });
            }

            if (efl_gfx_image_scale_hint_get_static_delegate == null)
            {
                efl_gfx_image_scale_hint_get_static_delegate = new efl_gfx_image_scale_hint_get_delegate(scale_hint_get);
            }

            if (methods.Contains("GetScaleHint"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_scale_hint_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_scale_hint_get_static_delegate) });
            }

            if (efl_gfx_image_scale_hint_set_static_delegate == null)
            {
                efl_gfx_image_scale_hint_set_static_delegate = new efl_gfx_image_scale_hint_set_delegate(scale_hint_set);
            }

            if (methods.Contains("SetScaleHint"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_scale_hint_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_scale_hint_set_static_delegate) });
            }

            if (efl_gfx_image_load_error_get_static_delegate == null)
            {
                efl_gfx_image_load_error_get_static_delegate = new efl_gfx_image_load_error_get_delegate(image_load_error_get);
            }

            if (methods.Contains("GetImageLoadError"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_load_error_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_error_get_static_delegate) });
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
            return efl_gfx_image_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_gfx_image_smooth_scale_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        internal delegate bool efl_gfx_image_smooth_scale_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_smooth_scale_get_api_delegate> efl_gfx_image_smooth_scale_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_smooth_scale_get_api_delegate>(Module, "efl_gfx_image_smooth_scale_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static bool smooth_scale_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_image_smooth_scale_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IImage)ws.Target).GetSmoothScale();
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
                return efl_gfx_image_smooth_scale_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_gfx_image_smooth_scale_get_delegate efl_gfx_image_smooth_scale_get_static_delegate;

        
        private delegate void efl_gfx_image_smooth_scale_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool smooth_scale);

        
        internal delegate void efl_gfx_image_smooth_scale_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool smooth_scale);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_smooth_scale_set_api_delegate> efl_gfx_image_smooth_scale_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_smooth_scale_set_api_delegate>(Module, "efl_gfx_image_smooth_scale_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void smooth_scale_set(System.IntPtr obj, System.IntPtr pd, bool smooth_scale)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_image_smooth_scale_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IImage)ws.Target).SetSmoothScale(smooth_scale);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_image_smooth_scale_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), smooth_scale);
            }
        }

        private static efl_gfx_image_smooth_scale_set_delegate efl_gfx_image_smooth_scale_set_static_delegate;

        
        private delegate CoreUI.Gfx.ImageScaleMethod efl_gfx_image_scale_method_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate CoreUI.Gfx.ImageScaleMethod efl_gfx_image_scale_method_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_scale_method_get_api_delegate> efl_gfx_image_scale_method_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_scale_method_get_api_delegate>(Module, "efl_gfx_image_scale_method_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static CoreUI.Gfx.ImageScaleMethod scale_method_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_image_scale_method_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.Gfx.ImageScaleMethod _ret_var = default(CoreUI.Gfx.ImageScaleMethod);
                try
                {
                    _ret_var = ((IImage)ws.Target).GetScaleMethod();
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
                return efl_gfx_image_scale_method_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_gfx_image_scale_method_get_delegate efl_gfx_image_scale_method_get_static_delegate;

        
        private delegate void efl_gfx_image_scale_method_set_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.Gfx.ImageScaleMethod scale_method);

        
        internal delegate void efl_gfx_image_scale_method_set_api_delegate(System.IntPtr obj,  CoreUI.Gfx.ImageScaleMethod scale_method);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_scale_method_set_api_delegate> efl_gfx_image_scale_method_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_scale_method_set_api_delegate>(Module, "efl_gfx_image_scale_method_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void scale_method_set(System.IntPtr obj, System.IntPtr pd, CoreUI.Gfx.ImageScaleMethod scale_method)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_image_scale_method_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IImage)ws.Target).SetScaleMethod(scale_method);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_image_scale_method_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), scale_method);
            }
        }

        private static efl_gfx_image_scale_method_set_delegate efl_gfx_image_scale_method_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_gfx_image_can_upscale_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        internal delegate bool efl_gfx_image_can_upscale_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_can_upscale_get_api_delegate> efl_gfx_image_can_upscale_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_can_upscale_get_api_delegate>(Module, "efl_gfx_image_can_upscale_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static bool can_upscale_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_image_can_upscale_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IImage)ws.Target).GetCanUpscale();
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
                return efl_gfx_image_can_upscale_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_gfx_image_can_upscale_get_delegate efl_gfx_image_can_upscale_get_static_delegate;

        
        private delegate void efl_gfx_image_can_upscale_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool upscale);

        
        internal delegate void efl_gfx_image_can_upscale_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool upscale);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_can_upscale_set_api_delegate> efl_gfx_image_can_upscale_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_can_upscale_set_api_delegate>(Module, "efl_gfx_image_can_upscale_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void can_upscale_set(System.IntPtr obj, System.IntPtr pd, bool upscale)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_image_can_upscale_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IImage)ws.Target).SetCanUpscale(upscale);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_image_can_upscale_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), upscale);
            }
        }

        private static efl_gfx_image_can_upscale_set_delegate efl_gfx_image_can_upscale_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_gfx_image_can_downscale_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        internal delegate bool efl_gfx_image_can_downscale_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_can_downscale_get_api_delegate> efl_gfx_image_can_downscale_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_can_downscale_get_api_delegate>(Module, "efl_gfx_image_can_downscale_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static bool can_downscale_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_image_can_downscale_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IImage)ws.Target).GetCanDownscale();
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
                return efl_gfx_image_can_downscale_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_gfx_image_can_downscale_get_delegate efl_gfx_image_can_downscale_get_static_delegate;

        
        private delegate void efl_gfx_image_can_downscale_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool downscale);

        
        internal delegate void efl_gfx_image_can_downscale_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool downscale);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_can_downscale_set_api_delegate> efl_gfx_image_can_downscale_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_can_downscale_set_api_delegate>(Module, "efl_gfx_image_can_downscale_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void can_downscale_set(System.IntPtr obj, System.IntPtr pd, bool downscale)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_image_can_downscale_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IImage)ws.Target).SetCanDownscale(downscale);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_image_can_downscale_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), downscale);
            }
        }

        private static efl_gfx_image_can_downscale_set_delegate efl_gfx_image_can_downscale_set_static_delegate;

        
        private delegate double efl_gfx_image_ratio_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate double efl_gfx_image_ratio_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_ratio_get_api_delegate> efl_gfx_image_ratio_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_ratio_get_api_delegate>(Module, "efl_gfx_image_ratio_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static double ratio_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_image_ratio_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                double _ret_var = default(double);
                try
                {
                    _ret_var = ((IImage)ws.Target).GetRatio();
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
                return efl_gfx_image_ratio_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_gfx_image_ratio_get_delegate efl_gfx_image_ratio_get_static_delegate;

        
        private delegate CoreUI.DataTypes.Rect efl_gfx_image_content_region_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate CoreUI.DataTypes.Rect efl_gfx_image_content_region_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_content_region_get_api_delegate> efl_gfx_image_content_region_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_content_region_get_api_delegate>(Module, "efl_gfx_image_content_region_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static CoreUI.DataTypes.Rect content_region_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_image_content_region_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.DataTypes.Rect _ret_var = default(CoreUI.DataTypes.Rect);
                try
                {
                    _ret_var = ((IImage)ws.Target).GetContentRegion();
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
                return efl_gfx_image_content_region_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_gfx_image_content_region_get_delegate efl_gfx_image_content_region_get_static_delegate;

        
        private delegate void efl_gfx_image_border_insets_get_delegate(System.IntPtr obj, System.IntPtr pd,  out int l,  out int r,  out int t,  out int b);

        
        internal delegate void efl_gfx_image_border_insets_get_api_delegate(System.IntPtr obj,  out int l,  out int r,  out int t,  out int b);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_border_insets_get_api_delegate> efl_gfx_image_border_insets_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_border_insets_get_api_delegate>(Module, "efl_gfx_image_border_insets_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void border_insets_get(System.IntPtr obj, System.IntPtr pd, out int l, out int r, out int t, out int b)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_image_border_insets_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                l = default(int);r = default(int);t = default(int);b = default(int);
                try
                {
                    ((IImage)ws.Target).GetBorderInsets(out l, out r, out t, out b);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_image_border_insets_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), out l, out r, out t, out b);
            }
        }

        private static efl_gfx_image_border_insets_get_delegate efl_gfx_image_border_insets_get_static_delegate;

        
        private delegate void efl_gfx_image_border_insets_set_delegate(System.IntPtr obj, System.IntPtr pd,  int l,  int r,  int t,  int b);

        
        internal delegate void efl_gfx_image_border_insets_set_api_delegate(System.IntPtr obj,  int l,  int r,  int t,  int b);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_border_insets_set_api_delegate> efl_gfx_image_border_insets_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_border_insets_set_api_delegate>(Module, "efl_gfx_image_border_insets_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void border_insets_set(System.IntPtr obj, System.IntPtr pd, int l, int r, int t, int b)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_image_border_insets_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IImage)ws.Target).SetBorderInsets(l, r, t, b);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_image_border_insets_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), l, r, t, b);
            }
        }

        private static efl_gfx_image_border_insets_set_delegate efl_gfx_image_border_insets_set_static_delegate;

        
        private delegate double efl_gfx_image_border_insets_scale_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate double efl_gfx_image_border_insets_scale_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_border_insets_scale_get_api_delegate> efl_gfx_image_border_insets_scale_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_border_insets_scale_get_api_delegate>(Module, "efl_gfx_image_border_insets_scale_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static double border_insets_scale_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_image_border_insets_scale_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                double _ret_var = default(double);
                try
                {
                    _ret_var = ((IImage)ws.Target).GetBorderInsetsScale();
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
                return efl_gfx_image_border_insets_scale_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_gfx_image_border_insets_scale_get_delegate efl_gfx_image_border_insets_scale_get_static_delegate;

        
        private delegate void efl_gfx_image_border_insets_scale_set_delegate(System.IntPtr obj, System.IntPtr pd,  double scale);

        
        internal delegate void efl_gfx_image_border_insets_scale_set_api_delegate(System.IntPtr obj,  double scale);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_border_insets_scale_set_api_delegate> efl_gfx_image_border_insets_scale_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_border_insets_scale_set_api_delegate>(Module, "efl_gfx_image_border_insets_scale_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void border_insets_scale_set(System.IntPtr obj, System.IntPtr pd, double scale)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_image_border_insets_scale_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IImage)ws.Target).SetBorderInsetsScale(scale);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_image_border_insets_scale_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), scale);
            }
        }

        private static efl_gfx_image_border_insets_scale_set_delegate efl_gfx_image_border_insets_scale_set_static_delegate;

        
        private delegate CoreUI.Gfx.CenterFillMode efl_gfx_image_center_fill_mode_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate CoreUI.Gfx.CenterFillMode efl_gfx_image_center_fill_mode_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_center_fill_mode_get_api_delegate> efl_gfx_image_center_fill_mode_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_center_fill_mode_get_api_delegate>(Module, "efl_gfx_image_center_fill_mode_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static CoreUI.Gfx.CenterFillMode center_fill_mode_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_image_center_fill_mode_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.Gfx.CenterFillMode _ret_var = default(CoreUI.Gfx.CenterFillMode);
                try
                {
                    _ret_var = ((IImage)ws.Target).GetCenterFillMode();
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
                return efl_gfx_image_center_fill_mode_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_gfx_image_center_fill_mode_get_delegate efl_gfx_image_center_fill_mode_get_static_delegate;

        
        private delegate void efl_gfx_image_center_fill_mode_set_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.Gfx.CenterFillMode fill);

        
        internal delegate void efl_gfx_image_center_fill_mode_set_api_delegate(System.IntPtr obj,  CoreUI.Gfx.CenterFillMode fill);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_center_fill_mode_set_api_delegate> efl_gfx_image_center_fill_mode_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_center_fill_mode_set_api_delegate>(Module, "efl_gfx_image_center_fill_mode_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void center_fill_mode_set(System.IntPtr obj, System.IntPtr pd, CoreUI.Gfx.CenterFillMode fill)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_image_center_fill_mode_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IImage)ws.Target).SetCenterFillMode(fill);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_image_center_fill_mode_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), fill);
            }
        }

        private static efl_gfx_image_center_fill_mode_set_delegate efl_gfx_image_center_fill_mode_set_static_delegate;

        
        private delegate void efl_gfx_image_stretch_region_get_delegate(System.IntPtr obj, System.IntPtr pd,  out System.IntPtr horizontal,  out System.IntPtr vertical);

        
        internal delegate void efl_gfx_image_stretch_region_get_api_delegate(System.IntPtr obj,  out System.IntPtr horizontal,  out System.IntPtr vertical);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_stretch_region_get_api_delegate> efl_gfx_image_stretch_region_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_stretch_region_get_api_delegate>(Module, "efl_gfx_image_stretch_region_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void stretch_region_get(System.IntPtr obj, System.IntPtr pd, out System.IntPtr horizontal, out System.IntPtr vertical)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_image_stretch_region_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                IEnumerable<CoreUI.Gfx.ImageStretchRegion> _out_horizontal = default(IEnumerable<CoreUI.Gfx.ImageStretchRegion>);
IEnumerable<CoreUI.Gfx.ImageStretchRegion> _out_vertical = default(IEnumerable<CoreUI.Gfx.ImageStretchRegion>);

                try
                {
                    ((IImage)ws.Target).GetStretchRegion(out _out_horizontal, out _out_vertical);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

        horizontal = CoreUI.Wrapper.Globals.IEnumerableToIterator(_out_horizontal, true);
vertical = CoreUI.Wrapper.Globals.IEnumerableToIterator(_out_vertical, true);
        
            }
            else
            {
                efl_gfx_image_stretch_region_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), out horizontal, out vertical);
            }
        }

        private static efl_gfx_image_stretch_region_get_delegate efl_gfx_image_stretch_region_get_static_delegate;

        
        private delegate CoreUI.DataTypes.Error efl_gfx_image_stretch_region_set_delegate(System.IntPtr obj, System.IntPtr pd,  System.IntPtr horizontal,  System.IntPtr vertical);

        
        internal delegate CoreUI.DataTypes.Error efl_gfx_image_stretch_region_set_api_delegate(System.IntPtr obj,  System.IntPtr horizontal,  System.IntPtr vertical);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_stretch_region_set_api_delegate> efl_gfx_image_stretch_region_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_stretch_region_set_api_delegate>(Module, "efl_gfx_image_stretch_region_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static CoreUI.DataTypes.Error stretch_region_set(System.IntPtr obj, System.IntPtr pd, System.IntPtr horizontal, System.IntPtr vertical)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_image_stretch_region_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                var _in_horizontal = CoreUI.Wrapper.Globals.IteratorToIEnumerable<CoreUI.Gfx.ImageStretchRegion>(horizontal);
var _in_vertical = CoreUI.Wrapper.Globals.IteratorToIEnumerable<CoreUI.Gfx.ImageStretchRegion>(vertical);
CoreUI.DataTypes.Error _ret_var = default(CoreUI.DataTypes.Error);
                try
                {
                    _ret_var = ((IImage)ws.Target).SetStretchRegion(_in_horizontal, _in_vertical);
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
                return efl_gfx_image_stretch_region_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), horizontal, vertical);
            }
        }

        private static efl_gfx_image_stretch_region_set_delegate efl_gfx_image_stretch_region_set_static_delegate;

        
        private delegate CoreUI.DataTypes.Size2D efl_gfx_image_size_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate CoreUI.DataTypes.Size2D efl_gfx_image_size_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_size_get_api_delegate> efl_gfx_image_size_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_size_get_api_delegate>(Module, "efl_gfx_image_size_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static CoreUI.DataTypes.Size2D image_size_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_image_size_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.DataTypes.Size2D _ret_var = default(CoreUI.DataTypes.Size2D);
                try
                {
                    _ret_var = ((IImage)ws.Target).GetImageSize();
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
                return efl_gfx_image_size_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_gfx_image_size_get_delegate efl_gfx_image_size_get_static_delegate;

        
        private delegate CoreUI.Gfx.ImageContentHint efl_gfx_image_content_hint_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate CoreUI.Gfx.ImageContentHint efl_gfx_image_content_hint_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_content_hint_get_api_delegate> efl_gfx_image_content_hint_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_content_hint_get_api_delegate>(Module, "efl_gfx_image_content_hint_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static CoreUI.Gfx.ImageContentHint content_hint_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_image_content_hint_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.Gfx.ImageContentHint _ret_var = default(CoreUI.Gfx.ImageContentHint);
                try
                {
                    _ret_var = ((IImage)ws.Target).GetContentHint();
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
                return efl_gfx_image_content_hint_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_gfx_image_content_hint_get_delegate efl_gfx_image_content_hint_get_static_delegate;

        
        private delegate void efl_gfx_image_content_hint_set_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.Gfx.ImageContentHint hint);

        
        internal delegate void efl_gfx_image_content_hint_set_api_delegate(System.IntPtr obj,  CoreUI.Gfx.ImageContentHint hint);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_content_hint_set_api_delegate> efl_gfx_image_content_hint_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_content_hint_set_api_delegate>(Module, "efl_gfx_image_content_hint_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void content_hint_set(System.IntPtr obj, System.IntPtr pd, CoreUI.Gfx.ImageContentHint hint)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_image_content_hint_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IImage)ws.Target).SetContentHint(hint);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_image_content_hint_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), hint);
            }
        }

        private static efl_gfx_image_content_hint_set_delegate efl_gfx_image_content_hint_set_static_delegate;

        
        private delegate CoreUI.Gfx.ImageScaleHint efl_gfx_image_scale_hint_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate CoreUI.Gfx.ImageScaleHint efl_gfx_image_scale_hint_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_scale_hint_get_api_delegate> efl_gfx_image_scale_hint_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_scale_hint_get_api_delegate>(Module, "efl_gfx_image_scale_hint_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static CoreUI.Gfx.ImageScaleHint scale_hint_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_image_scale_hint_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.Gfx.ImageScaleHint _ret_var = default(CoreUI.Gfx.ImageScaleHint);
                try
                {
                    _ret_var = ((IImage)ws.Target).GetScaleHint();
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
                return efl_gfx_image_scale_hint_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_gfx_image_scale_hint_get_delegate efl_gfx_image_scale_hint_get_static_delegate;

        
        private delegate void efl_gfx_image_scale_hint_set_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.Gfx.ImageScaleHint hint);

        
        internal delegate void efl_gfx_image_scale_hint_set_api_delegate(System.IntPtr obj,  CoreUI.Gfx.ImageScaleHint hint);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_scale_hint_set_api_delegate> efl_gfx_image_scale_hint_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_scale_hint_set_api_delegate>(Module, "efl_gfx_image_scale_hint_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void scale_hint_set(System.IntPtr obj, System.IntPtr pd, CoreUI.Gfx.ImageScaleHint hint)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_image_scale_hint_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IImage)ws.Target).SetScaleHint(hint);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_image_scale_hint_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), hint);
            }
        }

        private static efl_gfx_image_scale_hint_set_delegate efl_gfx_image_scale_hint_set_static_delegate;

        
        private delegate CoreUI.DataTypes.Error efl_gfx_image_load_error_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate CoreUI.DataTypes.Error efl_gfx_image_load_error_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_load_error_get_api_delegate> efl_gfx_image_load_error_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_image_load_error_get_api_delegate>(Module, "efl_gfx_image_load_error_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static CoreUI.DataTypes.Error image_load_error_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_image_load_error_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.DataTypes.Error _ret_var = default(CoreUI.DataTypes.Error);
                try
                {
                    _ret_var = ((IImage)ws.Target).GetImageLoadError();
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
                return efl_gfx_image_load_error_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_gfx_image_load_error_get_delegate efl_gfx_image_load_error_get_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

    }
}

namespace CoreUI.Gfx {
#pragma warning disable CS1591
    /// <since_tizen> 6 </since_tizen>
    public static class ImageExtensions {
        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> SmoothScale<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Gfx.IImage, T>magic = null) where T : CoreUI.Gfx.IImage {
            return new CoreUI.BindableProperty<bool>("smooth_scale", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.Gfx.ImageScaleMethod> ScaleMethod<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Gfx.IImage, T>magic = null) where T : CoreUI.Gfx.IImage {
            return new CoreUI.BindableProperty<CoreUI.Gfx.ImageScaleMethod>("scale_method", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> CanUpscale<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Gfx.IImage, T>magic = null) where T : CoreUI.Gfx.IImage {
            return new CoreUI.BindableProperty<bool>("can_upscale", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> CanDownscale<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Gfx.IImage, T>magic = null) where T : CoreUI.Gfx.IImage {
            return new CoreUI.BindableProperty<bool>("can_downscale", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<double> BorderInsetsScale<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Gfx.IImage, T>magic = null) where T : CoreUI.Gfx.IImage {
            return new CoreUI.BindableProperty<double>("border_insets_scale", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.Gfx.CenterFillMode> CenterFillMode<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Gfx.IImage, T>magic = null) where T : CoreUI.Gfx.IImage {
            return new CoreUI.BindableProperty<CoreUI.Gfx.CenterFillMode>("center_fill_mode", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.Gfx.ImageContentHint> ContentHint<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Gfx.IImage, T>magic = null) where T : CoreUI.Gfx.IImage {
            return new CoreUI.BindableProperty<CoreUI.Gfx.ImageContentHint>("content_hint", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.Gfx.ImageScaleHint> ScaleHint<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Gfx.IImage, T>magic = null) where T : CoreUI.Gfx.IImage {
            return new CoreUI.BindableProperty<CoreUI.Gfx.ImageScaleHint>("scale_hint", fac.GetPropBind());
        }

    }
#pragma warning restore CS1591
}

namespace CoreUI.Gfx {
    /// <summary>How an image&apos;s data is to be treated by EFL, for optimization.</summary>
    /// <since_tizen> 6 </since_tizen>
    
    [CoreUI.Wrapper.BindingEntity]
    public enum ImageContentHint
    {
        /// <summary>No hint on the content (default).</summary>
        /// <since_tizen> 6 </since_tizen>
        None = 0,
        /// <summary>The content will change over time.</summary>
        /// <since_tizen> 6 </since_tizen>
        Dynamic = 1,
        /// <summary>The content won&apos;t change over time.</summary>
        /// <since_tizen> 6 </since_tizen>
        Static = 2,
    }
}

namespace CoreUI.Gfx {
    /// <summary>How an image&apos;s data is to be treated by EFL, with regard to scaling cache.</summary>
    /// <since_tizen> 6 </since_tizen>
    
    [CoreUI.Wrapper.BindingEntity]
    public enum ImageScaleHint
    {
        /// <summary>No hint on the scaling (default).</summary>
        /// <since_tizen> 6 </since_tizen>
        None = 0,
        /// <summary>Image will be re-scaled over time, thus turning scaling cache OFF for its data.</summary>
        /// <since_tizen> 6 </since_tizen>
        Dynamic = 1,
        /// <summary>Image will not be re-scaled over time, thus turning scaling cache ON for its data.</summary>
        /// <since_tizen> 6 </since_tizen>
        Static = 2,
    }
}

namespace CoreUI.Gfx {
    /// <summary>Enumeration that defines scaling methods to be used when rendering an image.</summary>
    /// <since_tizen> 6 </since_tizen>
    
    [CoreUI.Wrapper.BindingEntity]
    public enum ImageScaleMethod
    {
        /// <summary>Use the image&apos;s natural size.</summary>
        /// <since_tizen> 6 </since_tizen>
        None = 0,
        /// <summary>Scale the image so that it matches the object&apos;s area exactly. The image&apos;s aspect ratio might be changed.</summary>
        /// <since_tizen> 6 </since_tizen>
        Fill = 1,
        /// <summary>Scale the image so that it fits completely inside the object&apos;s area while maintaining the aspect ratio. At least one of the dimensions of the image will be equal to the corresponding dimension of the object.</summary>
        /// <since_tizen> 6 </since_tizen>
        Fit = 2,
        /// <summary>Scale the image so that it covers the entire object area horizontally while maintaining the aspect ratio. The image may become taller than the object.</summary>
        /// <since_tizen> 6 </since_tizen>
        FitWidth = 3,
        /// <summary>Scale the image so that it covers the entire object area vertically while maintaining the aspect ratio. The image may become wider than the object.</summary>
        /// <since_tizen> 6 </since_tizen>
        FitHeight = 4,
        /// <summary>Scale the image so that it covers the entire object area on one axis while maintaining the aspect ratio, preferring whichever axis is largest. The image may become larger than the object.</summary>
        /// <since_tizen> 6 </since_tizen>
        Expand = 5,
        /// <summary>Tile image at its original size.</summary>
        /// <since_tizen> 6 </since_tizen>
        Tile = 6,
    }
}

namespace CoreUI.Gfx {
    /// <summary>This struct holds the description of a stretchable region in one dimension (vertical or horizontal). Used when scaling an image.
    /// 
    /// <c>offset</c> + <c>length</c> should be smaller than image size in that dimension.</summary>
    /// <since_tizen> 6 </since_tizen>
    [StructLayout(LayoutKind.Sequential)]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public struct ImageStretchRegion : IEquatable<ImageStretchRegion>
    {
        
        private uint offset;
        
        private uint length;

        /// <summary>First pixel of the stretchable region, starting at 0.</summary>
        /// <since_tizen> 6 </since_tizen>
        public uint Offset { get => offset; }
        /// <summary>Length of the stretchable region in pixels.</summary>
        /// <since_tizen> 6 </since_tizen>
        public uint Length { get => length; }
        /// <summary>Constructor for ImageStretchRegion.
        /// </summary>
        /// <param name="offset">First pixel of the stretchable region, starting at 0.</param>
        /// <param name="length">Length of the stretchable region in pixels.</param>
        /// <since_tizen> 6 </since_tizen>
        public ImageStretchRegion(
            uint offset = default(uint),
            uint length = default(uint))
        {
            this.offset = offset;
            this.length = length;
        }

        /// <summary>Packs tuple into ImageStretchRegion object.
        ///<para>Since EFL 1.24.</para>
        ///</summary>
        public static implicit operator ImageStretchRegion((uint offset, uint length) tuple)
            => new ImageStretchRegion(tuple.offset, tuple.length);

        /// <summary>Unpacks ImageStretchRegion into tuple.
        /// <para>Since EFL 1.24.</para>
        /// </summary>
        public void Deconstruct(
            out uint offset,
            out uint length
        )
        {
            offset = this.Offset;
            length = this.Length;
        }
        /// <summary>Get a hash code for this item.
        /// </summary>
        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + Offset.GetHashCode();
            hash = hash * 23 + Length.GetHashCode();
            return hash;
        }
        /// <summary>Equality comparison.
        /// </summary>
        public bool Equals(ImageStretchRegion other)
        {
            return Offset == other.Offset && Length == other.Length;
        }
        /// <summary>Equality comparison.
        /// </summary>
        public override bool Equals(object other)
            => ((other is ImageStretchRegion) ? Equals((ImageStretchRegion)other) : false);
        /// <summary>Equality comparison.
        /// </summary>
        public static bool operator ==(ImageStretchRegion lhs, ImageStretchRegion rhs)
            => lhs.Equals(rhs);        /// <summary>Equality comparison.
        /// </summary>
        public static bool operator !=(ImageStretchRegion lhs, ImageStretchRegion rhs)
            => !lhs.Equals(rhs);        /// <summary>Implicit conversion to the managed representation from a native pointer.
        /// </summary>
        /// <param name="ptr">Native pointer to be converted.</param>
        public static implicit operator ImageStretchRegion(IntPtr ptr)
        {
            return (ImageStretchRegion)Marshal.PtrToStructure(ptr, typeof(ImageStretchRegion));
        }

        /// <summary>Conversion to the managed representation from a native pointer.
        /// </summary>
        /// <param name="ptr">Native pointer to be converted.</param>
        public static ImageStretchRegion FromIntPtr(IntPtr ptr)
        {
            return ptr;
        }

    }

}

