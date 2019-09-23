#define EFL_BETA
#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Canvas {

namespace Vg {

/// <summary>Efl vector graphics image class</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Canvas.Vg.Image.NativeMethods]
[Efl.Eo.BindingEntity]
public class Image : Efl.Canvas.Vg.Node, Efl.Gfx.IImage
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(Image))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] internal static extern System.IntPtr
        efl_canvas_vg_image_class_get();
    /// <summary>Initializes a new instance of the <see cref="Image"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public Image(Efl.Object parent= null
            ) : base(efl_canvas_vg_image_class_get(), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected Image(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Image"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected Image(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Image"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected Image(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }

    /// <summary>Image data has been preloaded.</summary>
    public event EventHandler ImagePreloadEvent
    {
        add
        {
            lock (eflBindingEventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        EventArgs args = EventArgs.Empty;
                        try
                        {
                            value?.Invoke(obj, args);
                        }
                        catch (Exception e)
                        {
                            Eina.Log.Error(e.ToString());
                            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                        }
                    }
                };

                string key = "_EFL_GFX_IMAGE_EVENT_IMAGE_PRELOAD";
                AddNativeEventHandler(efl.Libs.Evas, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_GFX_IMAGE_EVENT_IMAGE_PRELOAD";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }
    /// <summary>Method to raise event ImagePreloadEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnImagePreloadEvent(EventArgs e)
    {
        var key = "_EFL_GFX_IMAGE_EVENT_IMAGE_PRELOAD";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Evas, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Image was resized (its pixel data). The event data is the image&apos;s new size.</summary>
    /// <value><see cref="Efl.Gfx.ImageImageResizedEventArgs"/></value>
    public event EventHandler<Efl.Gfx.ImageImageResizedEventArgs> ImageResizedEvent
    {
        add
        {
            lock (eflBindingEventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        Efl.Gfx.ImageImageResizedEventArgs args = new Efl.Gfx.ImageImageResizedEventArgs();
                        args.arg =  evt.Info;
                        try
                        {
                            value?.Invoke(obj, args);
                        }
                        catch (Exception e)
                        {
                            Eina.Log.Error(e.ToString());
                            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                        }
                    }
                };

                string key = "_EFL_GFX_IMAGE_EVENT_IMAGE_RESIZED";
                AddNativeEventHandler(efl.Libs.Evas, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_GFX_IMAGE_EVENT_IMAGE_RESIZED";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }
    /// <summary>Method to raise event ImageResizedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnImageResizedEvent(Efl.Gfx.ImageImageResizedEventArgs e)
    {
        var key = "_EFL_GFX_IMAGE_EVENT_IMAGE_RESIZED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Evas, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = Marshal.AllocHGlobal(Marshal.SizeOf(e.arg));
        try
        {
            Marshal.StructureToPtr(e.arg, info, false);
            Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Marshal.FreeHGlobal(info);
        }
    }
    /// <summary>Image data has been unloaded (by some mechanism in EFL that threw out the original image data).</summary>
    public event EventHandler ImageUnloadEvent
    {
        add
        {
            lock (eflBindingEventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        EventArgs args = EventArgs.Empty;
                        try
                        {
                            value?.Invoke(obj, args);
                        }
                        catch (Exception e)
                        {
                            Eina.Log.Error(e.ToString());
                            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                        }
                    }
                };

                string key = "_EFL_GFX_IMAGE_EVENT_IMAGE_UNLOAD";
                AddNativeEventHandler(efl.Libs.Evas, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_GFX_IMAGE_EVENT_IMAGE_UNLOAD";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }
    /// <summary>Method to raise event ImageUnloadEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnImageUnloadEvent(EventArgs e)
    {
        var key = "_EFL_GFX_IMAGE_EVENT_IMAGE_UNLOAD";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Evas, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Set image data</summary>
    /// <param name="pixels">Image pixels data. The pixel data type is 32bit RGBA</param>
    /// <param name="size">The size in pixels.</param>
    public virtual void SetData(System.IntPtr pixels, Eina.Size2D size) {
                 Eina.Size2D.NativeStruct _in_size = size;
                                        Efl.Canvas.Vg.Image.NativeMethods.efl_canvas_vg_image_data_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),pixels, _in_size);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Whether to use high-quality image scaling algorithm for this image.
    /// When enabled, a higher quality image scaling algorithm is used when scaling images to sizes other than the source image&apos;s original one. This gives better results but is more computationally expensive.</summary>
    /// <returns>Whether to use smooth scale or not. The default value is <c>true</c>.</returns>
    public virtual bool GetSmoothScale() {
         var _ret_var = Efl.Gfx.ImageConcrete.NativeMethods.efl_gfx_image_smooth_scale_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Whether to use high-quality image scaling algorithm for this image.
    /// When enabled, a higher quality image scaling algorithm is used when scaling images to sizes other than the source image&apos;s original one. This gives better results but is more computationally expensive.</summary>
    /// <param name="smooth_scale">Whether to use smooth scale or not. The default value is <c>true</c>.</param>
    public virtual void SetSmoothScale(bool smooth_scale) {
                                 Efl.Gfx.ImageConcrete.NativeMethods.efl_gfx_image_smooth_scale_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),smooth_scale);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Determine how the image is scaled at render time.
    /// This allows more granular controls for how an image object should display its internal buffer. The underlying image data will not be modified.</summary>
    /// <returns>Image scale type to use. The default value is <see cref="Efl.Gfx.ImageScaleMethod.None"/>.</returns>
    public virtual Efl.Gfx.ImageScaleMethod GetScaleMethod() {
         var _ret_var = Efl.Gfx.ImageConcrete.NativeMethods.efl_gfx_image_scale_method_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Determine how the image is scaled at render time.
    /// This allows more granular controls for how an image object should display its internal buffer. The underlying image data will not be modified.</summary>
    /// <param name="scale_method">Image scale type to use. The default value is <see cref="Efl.Gfx.ImageScaleMethod.None"/>.</param>
    public virtual void SetScaleMethod(Efl.Gfx.ImageScaleMethod scale_method) {
                                 Efl.Gfx.ImageConcrete.NativeMethods.efl_gfx_image_scale_method_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),scale_method);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>If <c>true</c>, the image may be scaled to a larger size. If <c>false</c>, the image will never be resized larger than its native size.</summary>
    /// <returns>Whether to allow image upscaling. The default value is <c>true</c>.</returns>
    public virtual bool GetCanUpscale() {
         var _ret_var = Efl.Gfx.ImageConcrete.NativeMethods.efl_gfx_image_can_upscale_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>If <c>true</c>, the image may be scaled to a larger size. If <c>false</c>, the image will never be resized larger than its native size.</summary>
    /// <param name="upscale">Whether to allow image upscaling. The default value is <c>true</c>.</param>
    public virtual void SetCanUpscale(bool upscale) {
                                 Efl.Gfx.ImageConcrete.NativeMethods.efl_gfx_image_can_upscale_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),upscale);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>If <c>true</c>, the image may be scaled to a smaller size. If <c>false</c>, the image will never be resized smaller than its native size.</summary>
    /// <returns>Whether to allow image downscaling. The default value is <c>true</c>.</returns>
    public virtual bool GetCanDownscale() {
         var _ret_var = Efl.Gfx.ImageConcrete.NativeMethods.efl_gfx_image_can_downscale_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>If <c>true</c>, the image may be scaled to a smaller size. If <c>false</c>, the image will never be resized smaller than its native size.</summary>
    /// <param name="downscale">Whether to allow image downscaling. The default value is <c>true</c>.</param>
    public virtual void SetCanDownscale(bool downscale) {
                                 Efl.Gfx.ImageConcrete.NativeMethods.efl_gfx_image_can_downscale_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),downscale);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The native width/height ratio of the image.
    /// The ratio will be 1.0 if it cannot be calculated (e.g. height = 0).</summary>
    /// <returns>The image&apos;s ratio. The default value is <c>1.0</c>.</returns>
    public virtual double GetRatio() {
         var _ret_var = Efl.Gfx.ImageConcrete.NativeMethods.efl_gfx_image_ratio_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Return the relative area enclosed inside the image where content is expected.
    /// We do expect content to be inside the limit defined by the border or inside the stretch region. If a stretch region is provided, the content region will encompass the non-stretchable area that are surrounded by stretchable area. If no border and no stretch region is set, they are assumed to be zero and the full object geometry is where content can be layout on top. The area size change with the object size.
    /// 
    /// The geometry of the area is expressed relative to the geometry of the object.</summary>
    /// <returns>A rectangle inside the object boundary where content is expected. The default value is the image object&apos;s geometry with the <see cref="Efl.Gfx.IImage.GetBorder"/> values subtracted.</returns>
    public virtual Eina.Rect GetContentRegion() {
         var _ret_var = Efl.Gfx.ImageConcrete.NativeMethods.efl_gfx_image_content_region_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Dimensions of this image&apos;s border, a region that does not scale with the center area.
    /// When EFL renders an image, its source may be scaled to fit the size of the object. This function sets an area from the borders of the image inwards which is not to be scaled. This function is useful for making frames and for widget theming, where, for example, buttons may be of varying sizes, but their border size must remain constant.
    /// 
    /// The units used for <c>l</c>, <c>r</c>, <c>t</c> and <c>b</c> are canvas units (pixels).
    /// 
    /// Note: The border region itself may be scaled by the <see cref="Efl.Gfx.IImage.SetBorderScale"/> function.
    /// 
    /// Note: By default, image objects have no borders set, i.e. <c>l</c>, <c>r</c>, <c>t</c> and <c>b</c> start as 0.
    /// 
    /// Note: Similar to the concepts of 9-patch images or cap insets.</summary>
    /// <param name="l">The border&apos;s left width. The default value is $0.</param>
    /// <param name="r">The border&apos;s right width. The default value is $0.</param>
    /// <param name="t">The border&apos;s top height. The default value is $0.</param>
    /// <param name="b">The border&apos;s bottom height. The default value is $0.</param>
    public virtual void GetBorder(out int l, out int r, out int t, out int b) {
                                                                                                         Efl.Gfx.ImageConcrete.NativeMethods.efl_gfx_image_border_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out l, out r, out t, out b);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Dimensions of this image&apos;s border, a region that does not scale with the center area.
    /// When EFL renders an image, its source may be scaled to fit the size of the object. This function sets an area from the borders of the image inwards which is not to be scaled. This function is useful for making frames and for widget theming, where, for example, buttons may be of varying sizes, but their border size must remain constant.
    /// 
    /// The units used for <c>l</c>, <c>r</c>, <c>t</c> and <c>b</c> are canvas units (pixels).
    /// 
    /// Note: The border region itself may be scaled by the <see cref="Efl.Gfx.IImage.SetBorderScale"/> function.
    /// 
    /// Note: By default, image objects have no borders set, i.e. <c>l</c>, <c>r</c>, <c>t</c> and <c>b</c> start as 0.
    /// 
    /// Note: Similar to the concepts of 9-patch images or cap insets.</summary>
    /// <param name="l">The border&apos;s left width. The default value is $0.</param>
    /// <param name="r">The border&apos;s right width. The default value is $0.</param>
    /// <param name="t">The border&apos;s top height. The default value is $0.</param>
    /// <param name="b">The border&apos;s bottom height. The default value is $0.</param>
    public virtual void SetBorder(int l, int r, int t, int b) {
                                                                                                         Efl.Gfx.ImageConcrete.NativeMethods.efl_gfx_image_border_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),l, r, t, b);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Scaling factor applied to the image borders.
    /// This value multiplies the size of the <see cref="Efl.Gfx.IImage.GetBorder"/> when scaling an object.</summary>
    /// <returns>The scale factor. The default value is <c>1.0</c>.</returns>
    public virtual double GetBorderScale() {
         var _ret_var = Efl.Gfx.ImageConcrete.NativeMethods.efl_gfx_image_border_scale_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Scaling factor applied to the image borders.
    /// This value multiplies the size of the <see cref="Efl.Gfx.IImage.GetBorder"/> when scaling an object.</summary>
    /// <param name="scale">The scale factor. The default value is <c>1.0</c>.</param>
    public virtual void SetBorderScale(double scale) {
                                 Efl.Gfx.ImageConcrete.NativeMethods.efl_gfx_image_border_scale_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),scale);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Specifies how the center part of the object (not the borders) should be drawn when EFL is rendering it.
    /// This function sets how the center part of the image object&apos;s source image is to be drawn, which must be one of the values in <see cref="Efl.Gfx.CenterFillMode"/>. By center we mean the complementary part of that defined by <see cref="Efl.Gfx.IImage.GetBorder"/>. This is very useful for making frames and decorations. You would most probably also be using a filled image (as in <see cref="Efl.Gfx.IFill.FillAuto"/>) to use as a frame.</summary>
    /// <returns>Fill mode of the center region. The default value is <see cref="Efl.Gfx.CenterFillMode.Default"/>, i.e. render and scale the center area, respecting its transparency.</returns>
    public virtual Efl.Gfx.CenterFillMode GetCenterFillMode() {
         var _ret_var = Efl.Gfx.ImageConcrete.NativeMethods.efl_gfx_image_center_fill_mode_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Specifies how the center part of the object (not the borders) should be drawn when EFL is rendering it.
    /// This function sets how the center part of the image object&apos;s source image is to be drawn, which must be one of the values in <see cref="Efl.Gfx.CenterFillMode"/>. By center we mean the complementary part of that defined by <see cref="Efl.Gfx.IImage.GetBorder"/>. This is very useful for making frames and decorations. You would most probably also be using a filled image (as in <see cref="Efl.Gfx.IFill.FillAuto"/>) to use as a frame.</summary>
    /// <param name="fill">Fill mode of the center region. The default value is <see cref="Efl.Gfx.CenterFillMode.Default"/>, i.e. render and scale the center area, respecting its transparency.</param>
    public virtual void SetCenterFillMode(Efl.Gfx.CenterFillMode fill) {
                                 Efl.Gfx.ImageConcrete.NativeMethods.efl_gfx_image_center_fill_mode_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),fill);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>This property defines the stretchable pixels region of an image.
    /// When the regions are set by the user, the method will walk the iterators once and then destroy them. When the regions are retrieved by the user, it is his responsibility to destroy the iterators.. It will remember the information for the lifetime of the object. It will ignore all value of <see cref="Efl.Gfx.IImage.GetBorder"/>, <see cref="Efl.Gfx.IImage.BorderScale"/> and <see cref="Efl.Gfx.IImage.CenterFillMode"/> . To reset the object you can just pass <c>null</c> to both horizontal and vertical at the same time.</summary>
    /// <param name="horizontal">Representation of areas that are stretchable in the image horizontal space. The default value is <c>NULL</c>.</param>
    /// <param name="vertical">Representation of areas that are stretchable in the image vertical space. The default value is <c>NULL</c>.</param>
    public virtual void GetStretchRegion(out Eina.Iterator<Efl.Gfx.ImageStretchRegion> horizontal, out Eina.Iterator<Efl.Gfx.ImageStretchRegion> vertical) {
                         System.IntPtr _out_horizontal = System.IntPtr.Zero;
        System.IntPtr _out_vertical = System.IntPtr.Zero;
                        Efl.Gfx.ImageConcrete.NativeMethods.efl_gfx_image_stretch_region_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out _out_horizontal, out _out_vertical);
        Eina.Error.RaiseIfUnhandledException();
        horizontal = new Eina.Iterator<Efl.Gfx.ImageStretchRegion>(_out_horizontal, false);
        vertical = new Eina.Iterator<Efl.Gfx.ImageStretchRegion>(_out_vertical, false);
                         }
    /// <summary>This property defines the stretchable pixels region of an image.
    /// When the regions are set by the user, the method will walk the iterators once and then destroy them. When the regions are retrieved by the user, it is his responsibility to destroy the iterators.. It will remember the information for the lifetime of the object. It will ignore all value of <see cref="Efl.Gfx.IImage.GetBorder"/>, <see cref="Efl.Gfx.IImage.BorderScale"/> and <see cref="Efl.Gfx.IImage.CenterFillMode"/> . To reset the object you can just pass <c>null</c> to both horizontal and vertical at the same time.</summary>
    /// <param name="horizontal">Representation of areas that are stretchable in the image horizontal space. The default value is <c>NULL</c>.</param>
    /// <param name="vertical">Representation of areas that are stretchable in the image vertical space. The default value is <c>NULL</c>.</param>
    /// <returns>Return an error code if the provided values are incorrect.</returns>
    public virtual Eina.Error SetStretchRegion(Eina.Iterator<Efl.Gfx.ImageStretchRegion> horizontal, Eina.Iterator<Efl.Gfx.ImageStretchRegion> vertical) {
         var _in_horizontal = horizontal.Handle;
        var _in_vertical = vertical.Handle;
                                        var _ret_var = Efl.Gfx.ImageConcrete.NativeMethods.efl_gfx_image_stretch_region_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_horizontal, _in_vertical);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>This represents the size of the original image in pixels.
    /// This may be different from the actual geometry on screen or even the size of the loaded pixel buffer. This is the size of the image as stored in the original file.
    /// 
    /// This is a read-only property and may return 0x0.</summary>
    /// <returns>The size in pixels. The default value is the size of the image&apos;s internal buffer.</returns>
    public virtual Eina.Size2D GetImageSize() {
         var _ret_var = Efl.Gfx.ImageConcrete.NativeMethods.efl_gfx_image_size_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Content hint setting for the image. These hints might be used by EFL to enable optimizations.
    /// For example, if you&apos;re on the GL engine and your driver implementation supports it, setting this hint to <see cref="Efl.Gfx.ImageContentHint.Dynamic"/> will make it need zero copies at texture upload time, which is an &quot;expensive&quot; operation.</summary>
    /// <returns>Dynamic or static content hint. The default value is <see cref="Efl.Gfx.ImageContentHint.None"/>.</returns>
    public virtual Efl.Gfx.ImageContentHint GetContentHint() {
         var _ret_var = Efl.Gfx.ImageConcrete.NativeMethods.efl_gfx_image_content_hint_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Content hint setting for the image. These hints might be used by EFL to enable optimizations.
    /// For example, if you&apos;re on the GL engine and your driver implementation supports it, setting this hint to <see cref="Efl.Gfx.ImageContentHint.Dynamic"/> will make it need zero copies at texture upload time, which is an &quot;expensive&quot; operation.</summary>
    /// <param name="hint">Dynamic or static content hint. The default value is <see cref="Efl.Gfx.ImageContentHint.None"/>.</param>
    public virtual void SetContentHint(Efl.Gfx.ImageContentHint hint) {
                                 Efl.Gfx.ImageConcrete.NativeMethods.efl_gfx_image_content_hint_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),hint);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The scale hint of a given image of the canvas.
    /// The scale hint affects how EFL is to cache scaled versions of its original source image.</summary>
    /// <returns>Scalable or static size hint. The default value is <see cref="Efl.Gfx.ImageScaleHint.None"/>.</returns>
    public virtual Efl.Gfx.ImageScaleHint GetScaleHint() {
         var _ret_var = Efl.Gfx.ImageConcrete.NativeMethods.efl_gfx_image_scale_hint_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The scale hint of a given image of the canvas.
    /// The scale hint affects how EFL is to cache scaled versions of its original source image.</summary>
    /// <param name="hint">Scalable or static size hint. The default value is <see cref="Efl.Gfx.ImageScaleHint.None"/>.</param>
    public virtual void SetScaleHint(Efl.Gfx.ImageScaleHint hint) {
                                 Efl.Gfx.ImageConcrete.NativeMethods.efl_gfx_image_scale_hint_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),hint);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The (last) file loading error for a given object. This value is set to a nonzero value if an error has occurred.</summary>
    /// <returns>The load error code. A value of $0 indicates no error.</returns>
    public virtual Eina.Error GetImageLoadError() {
         var _ret_var = Efl.Gfx.ImageConcrete.NativeMethods.efl_gfx_image_load_error_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set image data</summary>
    /// <value>Image pixels data. The pixel data type is 32bit RGBA</value>
    public (System.IntPtr, Eina.Size2D) Data {
        set { SetData( value.Item1,  value.Item2); }
    }
    /// <summary>Whether to use high-quality image scaling algorithm for this image.
    /// When enabled, a higher quality image scaling algorithm is used when scaling images to sizes other than the source image&apos;s original one. This gives better results but is more computationally expensive.</summary>
    /// <value>Whether to use smooth scale or not. The default value is <c>true</c>.</value>
    public bool SmoothScale {
        get { return GetSmoothScale(); }
        set { SetSmoothScale(value); }
    }
    /// <summary>Determine how the image is scaled at render time.
    /// This allows more granular controls for how an image object should display its internal buffer. The underlying image data will not be modified.</summary>
    /// <value>Image scale type to use. The default value is <see cref="Efl.Gfx.ImageScaleMethod.None"/>.</value>
    public Efl.Gfx.ImageScaleMethod ScaleMethod {
        get { return GetScaleMethod(); }
        set { SetScaleMethod(value); }
    }
    /// <summary>If <c>true</c>, the image may be scaled to a larger size. If <c>false</c>, the image will never be resized larger than its native size.</summary>
    /// <value>Whether to allow image upscaling. The default value is <c>true</c>.</value>
    public bool CanUpscale {
        get { return GetCanUpscale(); }
        set { SetCanUpscale(value); }
    }
    /// <summary>If <c>true</c>, the image may be scaled to a smaller size. If <c>false</c>, the image will never be resized smaller than its native size.</summary>
    /// <value>Whether to allow image downscaling. The default value is <c>true</c>.</value>
    public bool CanDownscale {
        get { return GetCanDownscale(); }
        set { SetCanDownscale(value); }
    }
    /// <summary>The native width/height ratio of the image.
    /// The ratio will be 1.0 if it cannot be calculated (e.g. height = 0).</summary>
    /// <value>The image&apos;s ratio. The default value is <c>1.0</c>.</value>
    public double Ratio {
        get { return GetRatio(); }
    }
    /// <summary>Return the relative area enclosed inside the image where content is expected.
    /// We do expect content to be inside the limit defined by the border or inside the stretch region. If a stretch region is provided, the content region will encompass the non-stretchable area that are surrounded by stretchable area. If no border and no stretch region is set, they are assumed to be zero and the full object geometry is where content can be layout on top. The area size change with the object size.
    /// 
    /// The geometry of the area is expressed relative to the geometry of the object.</summary>
    /// <value>A rectangle inside the object boundary where content is expected. The default value is the image object&apos;s geometry with the <see cref="Efl.Gfx.IImage.GetBorder"/> values subtracted.</value>
    public Eina.Rect ContentRegion {
        get { return GetContentRegion(); }
    }
    /// <summary>Dimensions of this image&apos;s border, a region that does not scale with the center area.
    /// When EFL renders an image, its source may be scaled to fit the size of the object. This function sets an area from the borders of the image inwards which is not to be scaled. This function is useful for making frames and for widget theming, where, for example, buttons may be of varying sizes, but their border size must remain constant.
    /// 
    /// The units used for <c>l</c>, <c>r</c>, <c>t</c> and <c>b</c> are canvas units (pixels).
    /// 
    /// Note: The border region itself may be scaled by the <see cref="Efl.Gfx.IImage.SetBorderScale"/> function.
    /// 
    /// Note: By default, image objects have no borders set, i.e. <c>l</c>, <c>r</c>, <c>t</c> and <c>b</c> start as 0.
    /// 
    /// Note: Similar to the concepts of 9-patch images or cap insets.</summary>
    /// <value>The border&apos;s left width. The default value is $0.</value>
    public (int, int, int, int) Border {
        get {
            int _out_l = default(int);
            int _out_r = default(int);
            int _out_t = default(int);
            int _out_b = default(int);
            GetBorder(out _out_l,out _out_r,out _out_t,out _out_b);
            return (_out_l,_out_r,_out_t,_out_b);
        }
        set { SetBorder( value.Item1,  value.Item2,  value.Item3,  value.Item4); }
    }
    /// <summary>Scaling factor applied to the image borders.
    /// This value multiplies the size of the <see cref="Efl.Gfx.IImage.GetBorder"/> when scaling an object.</summary>
    /// <value>The scale factor. The default value is <c>1.0</c>.</value>
    public double BorderScale {
        get { return GetBorderScale(); }
        set { SetBorderScale(value); }
    }
    /// <summary>Specifies how the center part of the object (not the borders) should be drawn when EFL is rendering it.
    /// This function sets how the center part of the image object&apos;s source image is to be drawn, which must be one of the values in <see cref="Efl.Gfx.CenterFillMode"/>. By center we mean the complementary part of that defined by <see cref="Efl.Gfx.IImage.GetBorder"/>. This is very useful for making frames and decorations. You would most probably also be using a filled image (as in <see cref="Efl.Gfx.IFill.FillAuto"/>) to use as a frame.</summary>
    /// <value>Fill mode of the center region. The default value is <see cref="Efl.Gfx.CenterFillMode.Default"/>, i.e. render and scale the center area, respecting its transparency.</value>
    public Efl.Gfx.CenterFillMode CenterFillMode {
        get { return GetCenterFillMode(); }
        set { SetCenterFillMode(value); }
    }
    /// <summary>This property defines the stretchable pixels region of an image.
    /// When the regions are set by the user, the method will walk the iterators once and then destroy them. When the regions are retrieved by the user, it is his responsibility to destroy the iterators.. It will remember the information for the lifetime of the object. It will ignore all value of <see cref="Efl.Gfx.IImage.GetBorder"/>, <see cref="Efl.Gfx.IImage.BorderScale"/> and <see cref="Efl.Gfx.IImage.CenterFillMode"/> . To reset the object you can just pass <c>null</c> to both horizontal and vertical at the same time.</summary>
    /// <value>Representation of areas that are stretchable in the image horizontal space. The default value is <c>NULL</c>.</value>
    public (Eina.Iterator<Efl.Gfx.ImageStretchRegion>, Eina.Iterator<Efl.Gfx.ImageStretchRegion>) StretchRegion {
        get {
            Eina.Iterator<Efl.Gfx.ImageStretchRegion> _out_horizontal = default(Eina.Iterator<Efl.Gfx.ImageStretchRegion>);
            Eina.Iterator<Efl.Gfx.ImageStretchRegion> _out_vertical = default(Eina.Iterator<Efl.Gfx.ImageStretchRegion>);
            GetStretchRegion(out _out_horizontal,out _out_vertical);
            return (_out_horizontal,_out_vertical);
        }
        set { SetStretchRegion( value.Item1,  value.Item2); }
    }
    /// <summary>This represents the size of the original image in pixels.
    /// This may be different from the actual geometry on screen or even the size of the loaded pixel buffer. This is the size of the image as stored in the original file.
    /// 
    /// This is a read-only property and may return 0x0.</summary>
    /// <value>The size in pixels. The default value is the size of the image&apos;s internal buffer.</value>
    public Eina.Size2D ImageSize {
        get { return GetImageSize(); }
    }
    /// <summary>Content hint setting for the image. These hints might be used by EFL to enable optimizations.
    /// For example, if you&apos;re on the GL engine and your driver implementation supports it, setting this hint to <see cref="Efl.Gfx.ImageContentHint.Dynamic"/> will make it need zero copies at texture upload time, which is an &quot;expensive&quot; operation.</summary>
    /// <value>Dynamic or static content hint. The default value is <see cref="Efl.Gfx.ImageContentHint.None"/>.</value>
    public Efl.Gfx.ImageContentHint ContentHint {
        get { return GetContentHint(); }
        set { SetContentHint(value); }
    }
    /// <summary>The scale hint of a given image of the canvas.
    /// The scale hint affects how EFL is to cache scaled versions of its original source image.</summary>
    /// <value>Scalable or static size hint. The default value is <see cref="Efl.Gfx.ImageScaleHint.None"/>.</value>
    public Efl.Gfx.ImageScaleHint ScaleHint {
        get { return GetScaleHint(); }
        set { SetScaleHint(value); }
    }
    /// <summary>The (last) file loading error for a given object. This value is set to a nonzero value if an error has occurred.</summary>
    /// <value>The load error code. A value of $0 indicates no error.</value>
    public Eina.Error ImageLoadError {
        get { return GetImageLoadError(); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Canvas.Vg.Image.efl_canvas_vg_image_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Canvas.Vg.Node.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Evas);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_canvas_vg_image_data_set_static_delegate == null)
            {
                efl_canvas_vg_image_data_set_static_delegate = new efl_canvas_vg_image_data_set_delegate(data_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetData") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_vg_image_data_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_vg_image_data_set_static_delegate) });
            }

            if (includeInherited)
            {
                var all_interfaces = type.GetInterfaces();
                foreach (var iface in all_interfaces)
                {
                    var moredescs = ((Efl.Eo.NativeClass)iface.GetCustomAttributes(false)?.FirstOrDefault(attr => attr is Efl.Eo.NativeClass))?.GetEoOps(type, false);
                    if (moredescs != null)
                        descs.AddRange(moredescs);
                }
            }
            descs.AddRange(base.GetEoOps(type, false));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Canvas.Vg.Image.efl_canvas_vg_image_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate void efl_canvas_vg_image_data_set_delegate(System.IntPtr obj, System.IntPtr pd,  System.IntPtr pixels,  Eina.Size2D.NativeStruct size);

        
        public delegate void efl_canvas_vg_image_data_set_api_delegate(System.IntPtr obj,  System.IntPtr pixels,  Eina.Size2D.NativeStruct size);

        public static Efl.Eo.FunctionWrapper<efl_canvas_vg_image_data_set_api_delegate> efl_canvas_vg_image_data_set_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_vg_image_data_set_api_delegate>(Module, "efl_canvas_vg_image_data_set");

        private static void data_set(System.IntPtr obj, System.IntPtr pd, System.IntPtr pixels, Eina.Size2D.NativeStruct size)
        {
            Eina.Log.Debug("function efl_canvas_vg_image_data_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                Eina.Size2D _in_size = size;
                                            
                try
                {
                    ((Image)ws.Target).SetData(pixels, _in_size);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_canvas_vg_image_data_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), pixels, size);
            }
        }

        private static efl_canvas_vg_image_data_set_delegate efl_canvas_vg_image_data_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_Canvas_VgImage_ExtensionMethods {
    
    public static Efl.BindableProperty<bool> SmoothScale<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Vg.Image, T>magic = null) where T : Efl.Canvas.Vg.Image {
        return new Efl.BindableProperty<bool>("smooth_scale", fac);
    }

    public static Efl.BindableProperty<Efl.Gfx.ImageScaleMethod> ScaleMethod<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Vg.Image, T>magic = null) where T : Efl.Canvas.Vg.Image {
        return new Efl.BindableProperty<Efl.Gfx.ImageScaleMethod>("scale_method", fac);
    }

    public static Efl.BindableProperty<bool> CanUpscale<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Vg.Image, T>magic = null) where T : Efl.Canvas.Vg.Image {
        return new Efl.BindableProperty<bool>("can_upscale", fac);
    }

    public static Efl.BindableProperty<bool> CanDownscale<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Vg.Image, T>magic = null) where T : Efl.Canvas.Vg.Image {
        return new Efl.BindableProperty<bool>("can_downscale", fac);
    }

    
    
    
    public static Efl.BindableProperty<double> BorderScale<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Vg.Image, T>magic = null) where T : Efl.Canvas.Vg.Image {
        return new Efl.BindableProperty<double>("border_scale", fac);
    }

    public static Efl.BindableProperty<Efl.Gfx.CenterFillMode> CenterFillMode<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Vg.Image, T>magic = null) where T : Efl.Canvas.Vg.Image {
        return new Efl.BindableProperty<Efl.Gfx.CenterFillMode>("center_fill_mode", fac);
    }

    
    
    public static Efl.BindableProperty<Efl.Gfx.ImageContentHint> ContentHint<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Vg.Image, T>magic = null) where T : Efl.Canvas.Vg.Image {
        return new Efl.BindableProperty<Efl.Gfx.ImageContentHint>("content_hint", fac);
    }

    public static Efl.BindableProperty<Efl.Gfx.ImageScaleHint> ScaleHint<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Vg.Image, T>magic = null) where T : Efl.Canvas.Vg.Image {
        return new Efl.BindableProperty<Efl.Gfx.ImageScaleHint>("scale_hint", fac);
    }

    
}
#pragma warning restore CS1591
#endif
