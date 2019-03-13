#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Gfx { 
/// <summary>Common APIs for all 2D images that can be rendered on the canvas.</summary>
[ImageNativeInherit]
public interface Image : 
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>Whether to use high-quality image scaling algorithm for this image.
/// When enabled, a higher quality image scaling algorithm is used when scaling images to sizes other than the source image&apos;s original one. This gives better results but is more computationally expensive.
/// 
/// <c>true</c> by default</summary>
/// <returns>Whether to use smooth scale or not.</returns>
bool GetSmoothScale();
   /// <summary>Whether to use high-quality image scaling algorithm for this image.
/// When enabled, a higher quality image scaling algorithm is used when scaling images to sizes other than the source image&apos;s original one. This gives better results but is more computationally expensive.
/// 
/// <c>true</c> by default</summary>
/// <param name="smooth_scale">Whether to use smooth scale or not.</param>
/// <returns></returns>
 void SetSmoothScale( bool smooth_scale);
   /// <summary>Control how the image is scaled.</summary>
/// <returns>Image scale type</returns>
Efl.Gfx.ImageScaleType GetScaleType();
   /// <summary>Control how the image is scaled.</summary>
/// <param name="scale_type">Image scale type</param>
/// <returns></returns>
 void SetScaleType( Efl.Gfx.ImageScaleType scale_type);
   /// <summary>Returns 1.0 if not applicable (eg. height = 0).</summary>
/// <returns>The image&apos;s ratio.</returns>
double GetRatio();
   /// <summary>Dimensions of this image&apos;s border, a region that does not scale with the center area.
/// When EFL renders an image, its source may be scaled to fit the size of the object. This function sets an area from the borders of the image inwards which is not to be scaled. This function is useful for making frames and for widget theming, where, for example, buttons may be of varying sizes, but their border size must remain constant.
/// 
/// The units used for <c>l</c>, <c>r</c>, <c>t</c> and <c>b</c> are canvas units (pixels).
/// 
/// Note: The border region itself may be scaled by the <see cref="Efl.Gfx.Image.SetBorderScale"/> function.
/// 
/// Note: By default, image objects have no borders set, i.e. <c>l</c>, <c>r</c>, <c>t</c> and <c>b</c> start as 0.
/// 
/// Note: Similar to the concepts of 9-patch images or cap insets.</summary>
/// <param name="l">The border&apos;s left width.</param>
/// <param name="r">The border&apos;s right width.</param>
/// <param name="t">The border&apos;s top height.</param>
/// <param name="b">The border&apos;s bottom height.</param>
/// <returns></returns>
 void GetBorder( out  int l,  out  int r,  out  int t,  out  int b);
   /// <summary>Dimensions of this image&apos;s border, a region that does not scale with the center area.
/// When EFL renders an image, its source may be scaled to fit the size of the object. This function sets an area from the borders of the image inwards which is not to be scaled. This function is useful for making frames and for widget theming, where, for example, buttons may be of varying sizes, but their border size must remain constant.
/// 
/// The units used for <c>l</c>, <c>r</c>, <c>t</c> and <c>b</c> are canvas units (pixels).
/// 
/// Note: The border region itself may be scaled by the <see cref="Efl.Gfx.Image.SetBorderScale"/> function.
/// 
/// Note: By default, image objects have no borders set, i.e. <c>l</c>, <c>r</c>, <c>t</c> and <c>b</c> start as 0.
/// 
/// Note: Similar to the concepts of 9-patch images or cap insets.</summary>
/// <param name="l">The border&apos;s left width.</param>
/// <param name="r">The border&apos;s right width.</param>
/// <param name="t">The border&apos;s top height.</param>
/// <param name="b">The border&apos;s bottom height.</param>
/// <returns></returns>
 void SetBorder(  int l,   int r,   int t,   int b);
   /// <summary>Scaling factor applied to the image borders.
/// This value multiplies the size of the <see cref="Efl.Gfx.Image.GetBorder"/> when scaling an object.
/// 
/// Default value is 1.0 (no scaling).</summary>
/// <returns>The scale factor.</returns>
double GetBorderScale();
   /// <summary>Scaling factor applied to the image borders.
/// This value multiplies the size of the <see cref="Efl.Gfx.Image.GetBorder"/> when scaling an object.
/// 
/// Default value is 1.0 (no scaling).</summary>
/// <param name="scale">The scale factor.</param>
/// <returns></returns>
 void SetBorderScale( double scale);
   /// <summary>Specifies how the center part of the object (not the borders) should be drawn when EFL is rendering it.
/// This function sets how the center part of the image object&apos;s source image is to be drawn, which must be one of the values in <see cref="Efl.Gfx.BorderFillMode"/>. By center we mean the complementary part of that defined by <see cref="Efl.Gfx.Image.GetBorder"/>. This is very useful for making frames and decorations. You would most probably also be using a filled image (as in <see cref="Efl.Gfx.Fill.FillAuto"/>) to use as a frame.
/// 
/// The default value is <see cref="Efl.Gfx.BorderFillMode.Default"/>, ie. render and scale the center area, respecting its transparency.</summary>
/// <returns>Fill mode of the center region.</returns>
Efl.Gfx.BorderFillMode GetBorderCenterFill();
   /// <summary>Specifies how the center part of the object (not the borders) should be drawn when EFL is rendering it.
/// This function sets how the center part of the image object&apos;s source image is to be drawn, which must be one of the values in <see cref="Efl.Gfx.BorderFillMode"/>. By center we mean the complementary part of that defined by <see cref="Efl.Gfx.Image.GetBorder"/>. This is very useful for making frames and decorations. You would most probably also be using a filled image (as in <see cref="Efl.Gfx.Fill.FillAuto"/>) to use as a frame.
/// 
/// The default value is <see cref="Efl.Gfx.BorderFillMode.Default"/>, ie. render and scale the center area, respecting its transparency.</summary>
/// <param name="fill">Fill mode of the center region.</param>
/// <returns></returns>
 void SetBorderCenterFill( Efl.Gfx.BorderFillMode fill);
   /// <summary>This represents the size of the original image in pixels.
/// This may be different from the actual geometry on screen or even the size of the loaded pixel buffer. This is the size of the image as stored in the original file.
/// 
/// This is a read-only property, and may return 0x0.
/// 1.20</summary>
/// <returns>The size in pixels.</returns>
Eina.Size2D GetImageSize();
   /// <summary>Get the content hint setting of a given image object of the canvas.
/// This returns #EVAS_IMAGE_CONTENT_HINT_NONE on error.</summary>
/// <returns>Dynamic or static content hint, see <see cref="Efl.Gfx.ImageContentHint"/></returns>
Efl.Gfx.ImageContentHint GetContentHint();
   /// <summary>Set the content hint setting of a given image object of the canvas.
/// This function sets the content hint value of the given image of the canvas. For example, if you&apos;re on the GL engine and your driver implementation supports it, setting this hint to #EVAS_IMAGE_CONTENT_HINT_DYNAMIC will make it need zero copies at texture upload time, which is an &quot;expensive&quot; operation.</summary>
/// <param name="hint">Dynamic or static content hint, see <see cref="Efl.Gfx.ImageContentHint"/></param>
/// <returns></returns>
 void SetContentHint( Efl.Gfx.ImageContentHint hint);
   /// <summary>Get the scale hint of a given image of the canvas.
/// This function returns the scale hint value of the given image object of the canvas.</summary>
/// <returns>Scalable or static size hint, see <see cref="Efl.Gfx.ImageScaleHint"/></returns>
Efl.Gfx.ImageScaleHint GetScaleHint();
   /// <summary>Set the scale hint of a given image of the canvas.
/// This function sets the scale hint value of the given image object in the canvas, which will affect how Evas is to cache scaled versions of its original source image.</summary>
/// <param name="hint">Scalable or static size hint, see <see cref="Efl.Gfx.ImageScaleHint"/></param>
/// <returns></returns>
 void SetScaleHint( Efl.Gfx.ImageScaleHint hint);
   /// <summary>Gets the (last) file loading error for a given object.</summary>
/// <returns>The load error code.</returns>
Efl.Gfx.ImageLoadError GetImageLoadError();
                                                      /// <summary>Image data has been preloaded.</summary>
   event EventHandler PreloadEvt;
   /// <summary>Image was resized (its pixel data).</summary>
   event EventHandler ResizeEvt;
   /// <summary>Image data has been unloaded (by some mechanism in EFL that threw out the original image data).</summary>
   event EventHandler UnloadEvt;
   /// <summary>Whether to use high-quality image scaling algorithm for this image.
/// When enabled, a higher quality image scaling algorithm is used when scaling images to sizes other than the source image&apos;s original one. This gives better results but is more computationally expensive.
/// 
/// <c>true</c> by default</summary>
/// <value>Whether to use smooth scale or not.</value>
   bool SmoothScale {
      get ;
      set ;
   }
   /// <summary>Control how the image is scaled.</summary>
/// <value>Image scale type</value>
   Efl.Gfx.ImageScaleType ScaleType {
      get ;
      set ;
   }
   /// <summary>The native width/height ratio of the image.</summary>
/// <value>The image&apos;s ratio.</value>
   double Ratio {
      get ;
   }
   /// <summary>Scaling factor applied to the image borders.
/// This value multiplies the size of the <see cref="Efl.Gfx.Image.GetBorder"/> when scaling an object.
/// 
/// Default value is 1.0 (no scaling).</summary>
/// <value>The scale factor.</value>
   double BorderScale {
      get ;
      set ;
   }
   /// <summary>Specifies how the center part of the object (not the borders) should be drawn when EFL is rendering it.
/// This function sets how the center part of the image object&apos;s source image is to be drawn, which must be one of the values in <see cref="Efl.Gfx.BorderFillMode"/>. By center we mean the complementary part of that defined by <see cref="Efl.Gfx.Image.GetBorder"/>. This is very useful for making frames and decorations. You would most probably also be using a filled image (as in <see cref="Efl.Gfx.Fill.FillAuto"/>) to use as a frame.
/// 
/// The default value is <see cref="Efl.Gfx.BorderFillMode.Default"/>, ie. render and scale the center area, respecting its transparency.</summary>
/// <value>Fill mode of the center region.</value>
   Efl.Gfx.BorderFillMode BorderCenterFill {
      get ;
      set ;
   }
   /// <summary>This represents the size of the original image in pixels.
/// This may be different from the actual geometry on screen or even the size of the loaded pixel buffer. This is the size of the image as stored in the original file.
/// 
/// This is a read-only property, and may return 0x0.
/// 1.20</summary>
/// <value>The size in pixels.</value>
   Eina.Size2D ImageSize {
      get ;
   }
   /// <summary>Get the content hint setting of a given image object of the canvas.
/// This returns #EVAS_IMAGE_CONTENT_HINT_NONE on error.</summary>
/// <value>Dynamic or static content hint, see <see cref="Efl.Gfx.ImageContentHint"/></value>
   Efl.Gfx.ImageContentHint ContentHint {
      get ;
      set ;
   }
   /// <summary>Get the scale hint of a given image of the canvas.
/// This function returns the scale hint value of the given image object of the canvas.</summary>
/// <value>Scalable or static size hint, see <see cref="Efl.Gfx.ImageScaleHint"/></value>
   Efl.Gfx.ImageScaleHint ScaleHint {
      get ;
      set ;
   }
   /// <summary>Gets the (last) file loading error for a given object.</summary>
/// <value>The load error code.</value>
   Efl.Gfx.ImageLoadError ImageLoadError {
      get ;
   }
}
/// <summary>Common APIs for all 2D images that can be rendered on the canvas.</summary>
sealed public class ImageConcrete : 

Image
   
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (ImageConcrete))
            return Efl.Gfx.ImageNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
      }
   }
   private EventHandlerList eventHandlers = new EventHandlerList();
   private  System.IntPtr handle;
   ///<summary>Pointer to the native instance.</summary>
   public System.IntPtr NativeHandle {
      get { return handle; }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] internal static extern System.IntPtr
      efl_gfx_image_interface_get();
   ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
   public ImageConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~ImageConcrete()
   {
      Dispose(false);
   }
   ///<summary>Releases the underlying native instance.</summary>
   void Dispose(bool disposing)
   {
      if (handle != System.IntPtr.Zero) {
         Efl.Eo.Globals.efl_unref(handle);
         handle = System.IntPtr.Zero;
      }
   }
   ///<summary>Releases the underlying native instance.</summary>
   public void Dispose()
   {
      Dispose(true);
      GC.SuppressFinalize(this);
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public static ImageConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new ImageConcrete(obj.NativeHandle);
   }
   ///<summary>Verifies if the given object is equal to this one.</summary>
   public override bool Equals(object obj)
   {
      var other = obj as Efl.Object;
      if (other == null)
         return false;
      return this.NativeHandle == other.NativeHandle;
   }
   ///<summary>Gets the hash code for this object based on the native pointer it points to.</summary>
   public override int GetHashCode()
   {
      return this.NativeHandle.ToInt32();
   }
   ///<summary>Turns the native pointer into a string representation.</summary>
   public override String ToString()
   {
      return $"{this.GetType().Name}@[{this.NativeHandle.ToInt32():x}]";
   }
   private readonly object eventLock = new object();
   private Dictionary<string, int> event_cb_count = new Dictionary<string, int>();
   private bool add_cpp_event_handler(string lib, string key, Efl.EventCb evt_delegate) {
      int event_count = 0;
      if (!event_cb_count.TryGetValue(key, out event_count))
         event_cb_count[key] = event_count;
      if (event_count == 0) {
         IntPtr desc = Efl.EventDescription.GetNative(lib, key);
         if (desc == IntPtr.Zero) {
            Eina.Log.Error($"Failed to get native event {key}");
            return false;
         }
          bool result = Efl.Eo.Globals.efl_event_callback_priority_add(handle, desc, 0, evt_delegate, System.IntPtr.Zero);
         if (!result) {
            Eina.Log.Error($"Failed to add event proxy for event {key}");
            return false;
         }
         Eina.Error.RaiseIfUnhandledException();
      } 
      event_cb_count[key]++;
      return true;
   }
   private bool remove_cpp_event_handler(string key, Efl.EventCb evt_delegate) {
      int event_count = 0;
      if (!event_cb_count.TryGetValue(key, out event_count))
         event_cb_count[key] = event_count;
      if (event_count == 1) {
         IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
         if (desc == IntPtr.Zero) {
            Eina.Log.Error($"Failed to get native event {key}");
            return false;
         }
         bool result = Efl.Eo.Globals.efl_event_callback_del(handle, desc, evt_delegate, System.IntPtr.Zero);
         if (!result) {
            Eina.Log.Error($"Failed to remove event proxy for event {key}");
            return false;
         }
         Eina.Error.RaiseIfUnhandledException();
      } else if (event_count == 0) {
         Eina.Log.Error($"Trying to remove proxy for event {key} when there is nothing registered.");
         return false;
      } 
      event_cb_count[key]--;
      return true;
   }
private static object PreloadEvtKey = new object();
   /// <summary>Image data has been preloaded.</summary>
   public event EventHandler PreloadEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_GFX_IMAGE_EVENT_PRELOAD";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_PreloadEvt_delegate)) {
               eventHandlers.AddHandler(PreloadEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_GFX_IMAGE_EVENT_PRELOAD";
            if (remove_cpp_event_handler(key, this.evt_PreloadEvt_delegate)) { 
               eventHandlers.RemoveHandler(PreloadEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event PreloadEvt.</summary>
   public void On_PreloadEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[PreloadEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_PreloadEvt_delegate;
   private void on_PreloadEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_PreloadEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object ResizeEvtKey = new object();
   /// <summary>Image was resized (its pixel data).</summary>
   public event EventHandler ResizeEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_GFX_IMAGE_EVENT_RESIZE";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_ResizeEvt_delegate)) {
               eventHandlers.AddHandler(ResizeEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_GFX_IMAGE_EVENT_RESIZE";
            if (remove_cpp_event_handler(key, this.evt_ResizeEvt_delegate)) { 
               eventHandlers.RemoveHandler(ResizeEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ResizeEvt.</summary>
   public void On_ResizeEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[ResizeEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ResizeEvt_delegate;
   private void on_ResizeEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_ResizeEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object UnloadEvtKey = new object();
   /// <summary>Image data has been unloaded (by some mechanism in EFL that threw out the original image data).</summary>
   public event EventHandler UnloadEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_GFX_IMAGE_EVENT_UNLOAD";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_UnloadEvt_delegate)) {
               eventHandlers.AddHandler(UnloadEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_GFX_IMAGE_EVENT_UNLOAD";
            if (remove_cpp_event_handler(key, this.evt_UnloadEvt_delegate)) { 
               eventHandlers.RemoveHandler(UnloadEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event UnloadEvt.</summary>
   public void On_UnloadEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[UnloadEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_UnloadEvt_delegate;
   private void on_UnloadEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_UnloadEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

    void register_event_proxies()
   {
      evt_PreloadEvt_delegate = new Efl.EventCb(on_PreloadEvt_NativeCallback);
      evt_ResizeEvt_delegate = new Efl.EventCb(on_ResizeEvt_NativeCallback);
      evt_UnloadEvt_delegate = new Efl.EventCb(on_UnloadEvt_NativeCallback);
   }
   /// <summary>Whether to use high-quality image scaling algorithm for this image.
   /// When enabled, a higher quality image scaling algorithm is used when scaling images to sizes other than the source image&apos;s original one. This gives better results but is more computationally expensive.
   /// 
   /// <c>true</c> by default</summary>
   /// <returns>Whether to use smooth scale or not.</returns>
   public bool GetSmoothScale() {
       var _ret_var = Efl.Gfx.ImageNativeInherit.efl_gfx_image_smooth_scale_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Whether to use high-quality image scaling algorithm for this image.
   /// When enabled, a higher quality image scaling algorithm is used when scaling images to sizes other than the source image&apos;s original one. This gives better results but is more computationally expensive.
   /// 
   /// <c>true</c> by default</summary>
   /// <param name="smooth_scale">Whether to use smooth scale or not.</param>
   /// <returns></returns>
   public  void SetSmoothScale( bool smooth_scale) {
                         Efl.Gfx.ImageNativeInherit.efl_gfx_image_smooth_scale_set_ptr.Value.Delegate(this.NativeHandle, smooth_scale);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Control how the image is scaled.</summary>
   /// <returns>Image scale type</returns>
   public Efl.Gfx.ImageScaleType GetScaleType() {
       var _ret_var = Efl.Gfx.ImageNativeInherit.efl_gfx_image_scale_type_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Control how the image is scaled.</summary>
   /// <param name="scale_type">Image scale type</param>
   /// <returns></returns>
   public  void SetScaleType( Efl.Gfx.ImageScaleType scale_type) {
                         Efl.Gfx.ImageNativeInherit.efl_gfx_image_scale_type_set_ptr.Value.Delegate(this.NativeHandle, scale_type);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Returns 1.0 if not applicable (eg. height = 0).</summary>
   /// <returns>The image&apos;s ratio.</returns>
   public double GetRatio() {
       var _ret_var = Efl.Gfx.ImageNativeInherit.efl_gfx_image_ratio_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Dimensions of this image&apos;s border, a region that does not scale with the center area.
   /// When EFL renders an image, its source may be scaled to fit the size of the object. This function sets an area from the borders of the image inwards which is not to be scaled. This function is useful for making frames and for widget theming, where, for example, buttons may be of varying sizes, but their border size must remain constant.
   /// 
   /// The units used for <c>l</c>, <c>r</c>, <c>t</c> and <c>b</c> are canvas units (pixels).
   /// 
   /// Note: The border region itself may be scaled by the <see cref="Efl.Gfx.Image.SetBorderScale"/> function.
   /// 
   /// Note: By default, image objects have no borders set, i.e. <c>l</c>, <c>r</c>, <c>t</c> and <c>b</c> start as 0.
   /// 
   /// Note: Similar to the concepts of 9-patch images or cap insets.</summary>
   /// <param name="l">The border&apos;s left width.</param>
   /// <param name="r">The border&apos;s right width.</param>
   /// <param name="t">The border&apos;s top height.</param>
   /// <param name="b">The border&apos;s bottom height.</param>
   /// <returns></returns>
   public  void GetBorder( out  int l,  out  int r,  out  int t,  out  int b) {
                                                                               Efl.Gfx.ImageNativeInherit.efl_gfx_image_border_get_ptr.Value.Delegate(this.NativeHandle, out l,  out r,  out t,  out b);
      Eina.Error.RaiseIfUnhandledException();
                                                       }
   /// <summary>Dimensions of this image&apos;s border, a region that does not scale with the center area.
   /// When EFL renders an image, its source may be scaled to fit the size of the object. This function sets an area from the borders of the image inwards which is not to be scaled. This function is useful for making frames and for widget theming, where, for example, buttons may be of varying sizes, but their border size must remain constant.
   /// 
   /// The units used for <c>l</c>, <c>r</c>, <c>t</c> and <c>b</c> are canvas units (pixels).
   /// 
   /// Note: The border region itself may be scaled by the <see cref="Efl.Gfx.Image.SetBorderScale"/> function.
   /// 
   /// Note: By default, image objects have no borders set, i.e. <c>l</c>, <c>r</c>, <c>t</c> and <c>b</c> start as 0.
   /// 
   /// Note: Similar to the concepts of 9-patch images or cap insets.</summary>
   /// <param name="l">The border&apos;s left width.</param>
   /// <param name="r">The border&apos;s right width.</param>
   /// <param name="t">The border&apos;s top height.</param>
   /// <param name="b">The border&apos;s bottom height.</param>
   /// <returns></returns>
   public  void SetBorder(  int l,   int r,   int t,   int b) {
                                                                               Efl.Gfx.ImageNativeInherit.efl_gfx_image_border_set_ptr.Value.Delegate(this.NativeHandle, l,  r,  t,  b);
      Eina.Error.RaiseIfUnhandledException();
                                                       }
   /// <summary>Scaling factor applied to the image borders.
   /// This value multiplies the size of the <see cref="Efl.Gfx.Image.GetBorder"/> when scaling an object.
   /// 
   /// Default value is 1.0 (no scaling).</summary>
   /// <returns>The scale factor.</returns>
   public double GetBorderScale() {
       var _ret_var = Efl.Gfx.ImageNativeInherit.efl_gfx_image_border_scale_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Scaling factor applied to the image borders.
   /// This value multiplies the size of the <see cref="Efl.Gfx.Image.GetBorder"/> when scaling an object.
   /// 
   /// Default value is 1.0 (no scaling).</summary>
   /// <param name="scale">The scale factor.</param>
   /// <returns></returns>
   public  void SetBorderScale( double scale) {
                         Efl.Gfx.ImageNativeInherit.efl_gfx_image_border_scale_set_ptr.Value.Delegate(this.NativeHandle, scale);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Specifies how the center part of the object (not the borders) should be drawn when EFL is rendering it.
   /// This function sets how the center part of the image object&apos;s source image is to be drawn, which must be one of the values in <see cref="Efl.Gfx.BorderFillMode"/>. By center we mean the complementary part of that defined by <see cref="Efl.Gfx.Image.GetBorder"/>. This is very useful for making frames and decorations. You would most probably also be using a filled image (as in <see cref="Efl.Gfx.Fill.FillAuto"/>) to use as a frame.
   /// 
   /// The default value is <see cref="Efl.Gfx.BorderFillMode.Default"/>, ie. render and scale the center area, respecting its transparency.</summary>
   /// <returns>Fill mode of the center region.</returns>
   public Efl.Gfx.BorderFillMode GetBorderCenterFill() {
       var _ret_var = Efl.Gfx.ImageNativeInherit.efl_gfx_image_border_center_fill_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Specifies how the center part of the object (not the borders) should be drawn when EFL is rendering it.
   /// This function sets how the center part of the image object&apos;s source image is to be drawn, which must be one of the values in <see cref="Efl.Gfx.BorderFillMode"/>. By center we mean the complementary part of that defined by <see cref="Efl.Gfx.Image.GetBorder"/>. This is very useful for making frames and decorations. You would most probably also be using a filled image (as in <see cref="Efl.Gfx.Fill.FillAuto"/>) to use as a frame.
   /// 
   /// The default value is <see cref="Efl.Gfx.BorderFillMode.Default"/>, ie. render and scale the center area, respecting its transparency.</summary>
   /// <param name="fill">Fill mode of the center region.</param>
   /// <returns></returns>
   public  void SetBorderCenterFill( Efl.Gfx.BorderFillMode fill) {
                         Efl.Gfx.ImageNativeInherit.efl_gfx_image_border_center_fill_set_ptr.Value.Delegate(this.NativeHandle, fill);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>This represents the size of the original image in pixels.
   /// This may be different from the actual geometry on screen or even the size of the loaded pixel buffer. This is the size of the image as stored in the original file.
   /// 
   /// This is a read-only property, and may return 0x0.
   /// 1.20</summary>
   /// <returns>The size in pixels.</returns>
   public Eina.Size2D GetImageSize() {
       var _ret_var = Efl.Gfx.ImageNativeInherit.efl_gfx_image_size_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return Eina.Size2D_StructConversion.ToManaged(_ret_var);
 }
   /// <summary>Get the content hint setting of a given image object of the canvas.
   /// This returns #EVAS_IMAGE_CONTENT_HINT_NONE on error.</summary>
   /// <returns>Dynamic or static content hint, see <see cref="Efl.Gfx.ImageContentHint"/></returns>
   public Efl.Gfx.ImageContentHint GetContentHint() {
       var _ret_var = Efl.Gfx.ImageNativeInherit.efl_gfx_image_content_hint_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Set the content hint setting of a given image object of the canvas.
   /// This function sets the content hint value of the given image of the canvas. For example, if you&apos;re on the GL engine and your driver implementation supports it, setting this hint to #EVAS_IMAGE_CONTENT_HINT_DYNAMIC will make it need zero copies at texture upload time, which is an &quot;expensive&quot; operation.</summary>
   /// <param name="hint">Dynamic or static content hint, see <see cref="Efl.Gfx.ImageContentHint"/></param>
   /// <returns></returns>
   public  void SetContentHint( Efl.Gfx.ImageContentHint hint) {
                         Efl.Gfx.ImageNativeInherit.efl_gfx_image_content_hint_set_ptr.Value.Delegate(this.NativeHandle, hint);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Get the scale hint of a given image of the canvas.
   /// This function returns the scale hint value of the given image object of the canvas.</summary>
   /// <returns>Scalable or static size hint, see <see cref="Efl.Gfx.ImageScaleHint"/></returns>
   public Efl.Gfx.ImageScaleHint GetScaleHint() {
       var _ret_var = Efl.Gfx.ImageNativeInherit.efl_gfx_image_scale_hint_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Set the scale hint of a given image of the canvas.
   /// This function sets the scale hint value of the given image object in the canvas, which will affect how Evas is to cache scaled versions of its original source image.</summary>
   /// <param name="hint">Scalable or static size hint, see <see cref="Efl.Gfx.ImageScaleHint"/></param>
   /// <returns></returns>
   public  void SetScaleHint( Efl.Gfx.ImageScaleHint hint) {
                         Efl.Gfx.ImageNativeInherit.efl_gfx_image_scale_hint_set_ptr.Value.Delegate(this.NativeHandle, hint);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Gets the (last) file loading error for a given object.</summary>
   /// <returns>The load error code.</returns>
   public Efl.Gfx.ImageLoadError GetImageLoadError() {
       var _ret_var = Efl.Gfx.ImageNativeInherit.efl_gfx_image_load_error_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Whether to use high-quality image scaling algorithm for this image.
/// When enabled, a higher quality image scaling algorithm is used when scaling images to sizes other than the source image&apos;s original one. This gives better results but is more computationally expensive.
/// 
/// <c>true</c> by default</summary>
/// <value>Whether to use smooth scale or not.</value>
   public bool SmoothScale {
      get { return GetSmoothScale(); }
      set { SetSmoothScale( value); }
   }
   /// <summary>Control how the image is scaled.</summary>
/// <value>Image scale type</value>
   public Efl.Gfx.ImageScaleType ScaleType {
      get { return GetScaleType(); }
      set { SetScaleType( value); }
   }
   /// <summary>The native width/height ratio of the image.</summary>
/// <value>The image&apos;s ratio.</value>
   public double Ratio {
      get { return GetRatio(); }
   }
   /// <summary>Scaling factor applied to the image borders.
/// This value multiplies the size of the <see cref="Efl.Gfx.Image.GetBorder"/> when scaling an object.
/// 
/// Default value is 1.0 (no scaling).</summary>
/// <value>The scale factor.</value>
   public double BorderScale {
      get { return GetBorderScale(); }
      set { SetBorderScale( value); }
   }
   /// <summary>Specifies how the center part of the object (not the borders) should be drawn when EFL is rendering it.
/// This function sets how the center part of the image object&apos;s source image is to be drawn, which must be one of the values in <see cref="Efl.Gfx.BorderFillMode"/>. By center we mean the complementary part of that defined by <see cref="Efl.Gfx.Image.GetBorder"/>. This is very useful for making frames and decorations. You would most probably also be using a filled image (as in <see cref="Efl.Gfx.Fill.FillAuto"/>) to use as a frame.
/// 
/// The default value is <see cref="Efl.Gfx.BorderFillMode.Default"/>, ie. render and scale the center area, respecting its transparency.</summary>
/// <value>Fill mode of the center region.</value>
   public Efl.Gfx.BorderFillMode BorderCenterFill {
      get { return GetBorderCenterFill(); }
      set { SetBorderCenterFill( value); }
   }
   /// <summary>This represents the size of the original image in pixels.
/// This may be different from the actual geometry on screen or even the size of the loaded pixel buffer. This is the size of the image as stored in the original file.
/// 
/// This is a read-only property, and may return 0x0.
/// 1.20</summary>
/// <value>The size in pixels.</value>
   public Eina.Size2D ImageSize {
      get { return GetImageSize(); }
   }
   /// <summary>Get the content hint setting of a given image object of the canvas.
/// This returns #EVAS_IMAGE_CONTENT_HINT_NONE on error.</summary>
/// <value>Dynamic or static content hint, see <see cref="Efl.Gfx.ImageContentHint"/></value>
   public Efl.Gfx.ImageContentHint ContentHint {
      get { return GetContentHint(); }
      set { SetContentHint( value); }
   }
   /// <summary>Get the scale hint of a given image of the canvas.
/// This function returns the scale hint value of the given image object of the canvas.</summary>
/// <value>Scalable or static size hint, see <see cref="Efl.Gfx.ImageScaleHint"/></value>
   public Efl.Gfx.ImageScaleHint ScaleHint {
      get { return GetScaleHint(); }
      set { SetScaleHint( value); }
   }
   /// <summary>Gets the (last) file loading error for a given object.</summary>
/// <value>The load error code.</value>
   public Efl.Gfx.ImageLoadError ImageLoadError {
      get { return GetImageLoadError(); }
   }
}
public class ImageNativeInherit  : Efl.Eo.NativeClass{
   public  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Efl);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      if (efl_gfx_image_smooth_scale_get_static_delegate == null)
      efl_gfx_image_smooth_scale_get_static_delegate = new efl_gfx_image_smooth_scale_get_delegate(smooth_scale_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_image_smooth_scale_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_smooth_scale_get_static_delegate)});
      if (efl_gfx_image_smooth_scale_set_static_delegate == null)
      efl_gfx_image_smooth_scale_set_static_delegate = new efl_gfx_image_smooth_scale_set_delegate(smooth_scale_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_image_smooth_scale_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_smooth_scale_set_static_delegate)});
      if (efl_gfx_image_scale_type_get_static_delegate == null)
      efl_gfx_image_scale_type_get_static_delegate = new efl_gfx_image_scale_type_get_delegate(scale_type_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_image_scale_type_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_scale_type_get_static_delegate)});
      if (efl_gfx_image_scale_type_set_static_delegate == null)
      efl_gfx_image_scale_type_set_static_delegate = new efl_gfx_image_scale_type_set_delegate(scale_type_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_image_scale_type_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_scale_type_set_static_delegate)});
      if (efl_gfx_image_ratio_get_static_delegate == null)
      efl_gfx_image_ratio_get_static_delegate = new efl_gfx_image_ratio_get_delegate(ratio_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_image_ratio_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_ratio_get_static_delegate)});
      if (efl_gfx_image_border_get_static_delegate == null)
      efl_gfx_image_border_get_static_delegate = new efl_gfx_image_border_get_delegate(border_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_image_border_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_border_get_static_delegate)});
      if (efl_gfx_image_border_set_static_delegate == null)
      efl_gfx_image_border_set_static_delegate = new efl_gfx_image_border_set_delegate(border_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_image_border_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_border_set_static_delegate)});
      if (efl_gfx_image_border_scale_get_static_delegate == null)
      efl_gfx_image_border_scale_get_static_delegate = new efl_gfx_image_border_scale_get_delegate(border_scale_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_image_border_scale_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_border_scale_get_static_delegate)});
      if (efl_gfx_image_border_scale_set_static_delegate == null)
      efl_gfx_image_border_scale_set_static_delegate = new efl_gfx_image_border_scale_set_delegate(border_scale_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_image_border_scale_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_border_scale_set_static_delegate)});
      if (efl_gfx_image_border_center_fill_get_static_delegate == null)
      efl_gfx_image_border_center_fill_get_static_delegate = new efl_gfx_image_border_center_fill_get_delegate(border_center_fill_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_image_border_center_fill_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_border_center_fill_get_static_delegate)});
      if (efl_gfx_image_border_center_fill_set_static_delegate == null)
      efl_gfx_image_border_center_fill_set_static_delegate = new efl_gfx_image_border_center_fill_set_delegate(border_center_fill_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_image_border_center_fill_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_border_center_fill_set_static_delegate)});
      if (efl_gfx_image_size_get_static_delegate == null)
      efl_gfx_image_size_get_static_delegate = new efl_gfx_image_size_get_delegate(image_size_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_image_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_size_get_static_delegate)});
      if (efl_gfx_image_content_hint_get_static_delegate == null)
      efl_gfx_image_content_hint_get_static_delegate = new efl_gfx_image_content_hint_get_delegate(content_hint_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_image_content_hint_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_content_hint_get_static_delegate)});
      if (efl_gfx_image_content_hint_set_static_delegate == null)
      efl_gfx_image_content_hint_set_static_delegate = new efl_gfx_image_content_hint_set_delegate(content_hint_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_image_content_hint_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_content_hint_set_static_delegate)});
      if (efl_gfx_image_scale_hint_get_static_delegate == null)
      efl_gfx_image_scale_hint_get_static_delegate = new efl_gfx_image_scale_hint_get_delegate(scale_hint_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_image_scale_hint_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_scale_hint_get_static_delegate)});
      if (efl_gfx_image_scale_hint_set_static_delegate == null)
      efl_gfx_image_scale_hint_set_static_delegate = new efl_gfx_image_scale_hint_set_delegate(scale_hint_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_image_scale_hint_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_scale_hint_set_static_delegate)});
      if (efl_gfx_image_load_error_get_static_delegate == null)
      efl_gfx_image_load_error_get_static_delegate = new efl_gfx_image_load_error_get_delegate(image_load_error_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_image_load_error_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_error_get_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Gfx.ImageConcrete.efl_gfx_image_interface_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.Gfx.ImageConcrete.efl_gfx_image_interface_get();
   }


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_gfx_image_smooth_scale_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_gfx_image_smooth_scale_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_gfx_image_smooth_scale_get_api_delegate> efl_gfx_image_smooth_scale_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_smooth_scale_get_api_delegate>(_Module, "efl_gfx_image_smooth_scale_get");
    private static bool smooth_scale_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_image_smooth_scale_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Image)wrapper).GetSmoothScale();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_image_smooth_scale_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_gfx_image_smooth_scale_get_delegate efl_gfx_image_smooth_scale_get_static_delegate;


    private delegate  void efl_gfx_image_smooth_scale_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool smooth_scale);


    public delegate  void efl_gfx_image_smooth_scale_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool smooth_scale);
    public static Efl.Eo.FunctionWrapper<efl_gfx_image_smooth_scale_set_api_delegate> efl_gfx_image_smooth_scale_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_smooth_scale_set_api_delegate>(_Module, "efl_gfx_image_smooth_scale_set");
    private static  void smooth_scale_set(System.IntPtr obj, System.IntPtr pd,  bool smooth_scale)
   {
      Eina.Log.Debug("function efl_gfx_image_smooth_scale_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Image)wrapper).SetSmoothScale( smooth_scale);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_image_smooth_scale_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  smooth_scale);
      }
   }
   private static efl_gfx_image_smooth_scale_set_delegate efl_gfx_image_smooth_scale_set_static_delegate;


    private delegate Efl.Gfx.ImageScaleType efl_gfx_image_scale_type_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Efl.Gfx.ImageScaleType efl_gfx_image_scale_type_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_gfx_image_scale_type_get_api_delegate> efl_gfx_image_scale_type_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_scale_type_get_api_delegate>(_Module, "efl_gfx_image_scale_type_get");
    private static Efl.Gfx.ImageScaleType scale_type_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_image_scale_type_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Gfx.ImageScaleType _ret_var = default(Efl.Gfx.ImageScaleType);
         try {
            _ret_var = ((Image)wrapper).GetScaleType();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_image_scale_type_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_gfx_image_scale_type_get_delegate efl_gfx_image_scale_type_get_static_delegate;


    private delegate  void efl_gfx_image_scale_type_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Gfx.ImageScaleType scale_type);


    public delegate  void efl_gfx_image_scale_type_set_api_delegate(System.IntPtr obj,   Efl.Gfx.ImageScaleType scale_type);
    public static Efl.Eo.FunctionWrapper<efl_gfx_image_scale_type_set_api_delegate> efl_gfx_image_scale_type_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_scale_type_set_api_delegate>(_Module, "efl_gfx_image_scale_type_set");
    private static  void scale_type_set(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.ImageScaleType scale_type)
   {
      Eina.Log.Debug("function efl_gfx_image_scale_type_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Image)wrapper).SetScaleType( scale_type);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_image_scale_type_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  scale_type);
      }
   }
   private static efl_gfx_image_scale_type_set_delegate efl_gfx_image_scale_type_set_static_delegate;


    private delegate double efl_gfx_image_ratio_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate double efl_gfx_image_ratio_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_gfx_image_ratio_get_api_delegate> efl_gfx_image_ratio_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_ratio_get_api_delegate>(_Module, "efl_gfx_image_ratio_get");
    private static double ratio_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_image_ratio_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  double _ret_var = default(double);
         try {
            _ret_var = ((Image)wrapper).GetRatio();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_image_ratio_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_gfx_image_ratio_get_delegate efl_gfx_image_ratio_get_static_delegate;


    private delegate  void efl_gfx_image_border_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  int l,   out  int r,   out  int t,   out  int b);


    public delegate  void efl_gfx_image_border_get_api_delegate(System.IntPtr obj,   out  int l,   out  int r,   out  int t,   out  int b);
    public static Efl.Eo.FunctionWrapper<efl_gfx_image_border_get_api_delegate> efl_gfx_image_border_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_border_get_api_delegate>(_Module, "efl_gfx_image_border_get");
    private static  void border_get(System.IntPtr obj, System.IntPtr pd,  out  int l,  out  int r,  out  int t,  out  int b)
   {
      Eina.Log.Debug("function efl_gfx_image_border_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                       l = default( int);      r = default( int);      t = default( int);      b = default( int);                                 
         try {
            ((Image)wrapper).GetBorder( out l,  out r,  out t,  out b);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_gfx_image_border_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out l,  out r,  out t,  out b);
      }
   }
   private static efl_gfx_image_border_get_delegate efl_gfx_image_border_get_static_delegate;


    private delegate  void efl_gfx_image_border_set_delegate(System.IntPtr obj, System.IntPtr pd,    int l,    int r,    int t,    int b);


    public delegate  void efl_gfx_image_border_set_api_delegate(System.IntPtr obj,    int l,    int r,    int t,    int b);
    public static Efl.Eo.FunctionWrapper<efl_gfx_image_border_set_api_delegate> efl_gfx_image_border_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_border_set_api_delegate>(_Module, "efl_gfx_image_border_set");
    private static  void border_set(System.IntPtr obj, System.IntPtr pd,   int l,   int r,   int t,   int b)
   {
      Eina.Log.Debug("function efl_gfx_image_border_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                          
         try {
            ((Image)wrapper).SetBorder( l,  r,  t,  b);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_gfx_image_border_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  l,  r,  t,  b);
      }
   }
   private static efl_gfx_image_border_set_delegate efl_gfx_image_border_set_static_delegate;


    private delegate double efl_gfx_image_border_scale_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate double efl_gfx_image_border_scale_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_gfx_image_border_scale_get_api_delegate> efl_gfx_image_border_scale_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_border_scale_get_api_delegate>(_Module, "efl_gfx_image_border_scale_get");
    private static double border_scale_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_image_border_scale_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  double _ret_var = default(double);
         try {
            _ret_var = ((Image)wrapper).GetBorderScale();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_image_border_scale_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_gfx_image_border_scale_get_delegate efl_gfx_image_border_scale_get_static_delegate;


    private delegate  void efl_gfx_image_border_scale_set_delegate(System.IntPtr obj, System.IntPtr pd,   double scale);


    public delegate  void efl_gfx_image_border_scale_set_api_delegate(System.IntPtr obj,   double scale);
    public static Efl.Eo.FunctionWrapper<efl_gfx_image_border_scale_set_api_delegate> efl_gfx_image_border_scale_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_border_scale_set_api_delegate>(_Module, "efl_gfx_image_border_scale_set");
    private static  void border_scale_set(System.IntPtr obj, System.IntPtr pd,  double scale)
   {
      Eina.Log.Debug("function efl_gfx_image_border_scale_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Image)wrapper).SetBorderScale( scale);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_image_border_scale_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  scale);
      }
   }
   private static efl_gfx_image_border_scale_set_delegate efl_gfx_image_border_scale_set_static_delegate;


    private delegate Efl.Gfx.BorderFillMode efl_gfx_image_border_center_fill_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Efl.Gfx.BorderFillMode efl_gfx_image_border_center_fill_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_gfx_image_border_center_fill_get_api_delegate> efl_gfx_image_border_center_fill_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_border_center_fill_get_api_delegate>(_Module, "efl_gfx_image_border_center_fill_get");
    private static Efl.Gfx.BorderFillMode border_center_fill_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_image_border_center_fill_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Gfx.BorderFillMode _ret_var = default(Efl.Gfx.BorderFillMode);
         try {
            _ret_var = ((Image)wrapper).GetBorderCenterFill();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_image_border_center_fill_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_gfx_image_border_center_fill_get_delegate efl_gfx_image_border_center_fill_get_static_delegate;


    private delegate  void efl_gfx_image_border_center_fill_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Gfx.BorderFillMode fill);


    public delegate  void efl_gfx_image_border_center_fill_set_api_delegate(System.IntPtr obj,   Efl.Gfx.BorderFillMode fill);
    public static Efl.Eo.FunctionWrapper<efl_gfx_image_border_center_fill_set_api_delegate> efl_gfx_image_border_center_fill_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_border_center_fill_set_api_delegate>(_Module, "efl_gfx_image_border_center_fill_set");
    private static  void border_center_fill_set(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.BorderFillMode fill)
   {
      Eina.Log.Debug("function efl_gfx_image_border_center_fill_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Image)wrapper).SetBorderCenterFill( fill);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_image_border_center_fill_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  fill);
      }
   }
   private static efl_gfx_image_border_center_fill_set_delegate efl_gfx_image_border_center_fill_set_static_delegate;


    private delegate Eina.Size2D_StructInternal efl_gfx_image_size_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Eina.Size2D_StructInternal efl_gfx_image_size_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_gfx_image_size_get_api_delegate> efl_gfx_image_size_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_size_get_api_delegate>(_Module, "efl_gfx_image_size_get");
    private static Eina.Size2D_StructInternal image_size_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_image_size_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Size2D _ret_var = default(Eina.Size2D);
         try {
            _ret_var = ((Image)wrapper).GetImageSize();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Eina.Size2D_StructConversion.ToInternal(_ret_var);
      } else {
         return efl_gfx_image_size_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_gfx_image_size_get_delegate efl_gfx_image_size_get_static_delegate;


    private delegate Efl.Gfx.ImageContentHint efl_gfx_image_content_hint_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Efl.Gfx.ImageContentHint efl_gfx_image_content_hint_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_gfx_image_content_hint_get_api_delegate> efl_gfx_image_content_hint_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_content_hint_get_api_delegate>(_Module, "efl_gfx_image_content_hint_get");
    private static Efl.Gfx.ImageContentHint content_hint_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_image_content_hint_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Gfx.ImageContentHint _ret_var = default(Efl.Gfx.ImageContentHint);
         try {
            _ret_var = ((Image)wrapper).GetContentHint();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_image_content_hint_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_gfx_image_content_hint_get_delegate efl_gfx_image_content_hint_get_static_delegate;


    private delegate  void efl_gfx_image_content_hint_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Gfx.ImageContentHint hint);


    public delegate  void efl_gfx_image_content_hint_set_api_delegate(System.IntPtr obj,   Efl.Gfx.ImageContentHint hint);
    public static Efl.Eo.FunctionWrapper<efl_gfx_image_content_hint_set_api_delegate> efl_gfx_image_content_hint_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_content_hint_set_api_delegate>(_Module, "efl_gfx_image_content_hint_set");
    private static  void content_hint_set(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.ImageContentHint hint)
   {
      Eina.Log.Debug("function efl_gfx_image_content_hint_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Image)wrapper).SetContentHint( hint);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_image_content_hint_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  hint);
      }
   }
   private static efl_gfx_image_content_hint_set_delegate efl_gfx_image_content_hint_set_static_delegate;


    private delegate Efl.Gfx.ImageScaleHint efl_gfx_image_scale_hint_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Efl.Gfx.ImageScaleHint efl_gfx_image_scale_hint_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_gfx_image_scale_hint_get_api_delegate> efl_gfx_image_scale_hint_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_scale_hint_get_api_delegate>(_Module, "efl_gfx_image_scale_hint_get");
    private static Efl.Gfx.ImageScaleHint scale_hint_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_image_scale_hint_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Gfx.ImageScaleHint _ret_var = default(Efl.Gfx.ImageScaleHint);
         try {
            _ret_var = ((Image)wrapper).GetScaleHint();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_image_scale_hint_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_gfx_image_scale_hint_get_delegate efl_gfx_image_scale_hint_get_static_delegate;


    private delegate  void efl_gfx_image_scale_hint_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Gfx.ImageScaleHint hint);


    public delegate  void efl_gfx_image_scale_hint_set_api_delegate(System.IntPtr obj,   Efl.Gfx.ImageScaleHint hint);
    public static Efl.Eo.FunctionWrapper<efl_gfx_image_scale_hint_set_api_delegate> efl_gfx_image_scale_hint_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_scale_hint_set_api_delegate>(_Module, "efl_gfx_image_scale_hint_set");
    private static  void scale_hint_set(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.ImageScaleHint hint)
   {
      Eina.Log.Debug("function efl_gfx_image_scale_hint_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Image)wrapper).SetScaleHint( hint);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_image_scale_hint_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  hint);
      }
   }
   private static efl_gfx_image_scale_hint_set_delegate efl_gfx_image_scale_hint_set_static_delegate;


    private delegate Efl.Gfx.ImageLoadError efl_gfx_image_load_error_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Efl.Gfx.ImageLoadError efl_gfx_image_load_error_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_gfx_image_load_error_get_api_delegate> efl_gfx_image_load_error_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_load_error_get_api_delegate>(_Module, "efl_gfx_image_load_error_get");
    private static Efl.Gfx.ImageLoadError image_load_error_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_image_load_error_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Gfx.ImageLoadError _ret_var = default(Efl.Gfx.ImageLoadError);
         try {
            _ret_var = ((Image)wrapper).GetImageLoadError();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_image_load_error_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_gfx_image_load_error_get_delegate efl_gfx_image_load_error_get_static_delegate;
}
} } 
namespace Efl { namespace Gfx { 
/// <summary>How an image&apos;s data is to be treated by EFL, for optimization.</summary>
public enum ImageContentHint
{
/// <summary>No hint on the content (default).</summary>
None = 0,
/// <summary>The content will change over time.</summary>
Dynamic = 1,
/// <summary>The content won&apos;t change over time.</summary>
Static = 2,
}
} } 
namespace Efl { namespace Gfx { 
/// <summary>How an image&apos;s data is to be treated by EFL, with regard to scaling cache.</summary>
public enum ImageScaleHint
{
/// <summary>No hint on the scaling (default).</summary>
None = 0,
/// <summary>Image will be re-scaled over time, thus turning scaling cache OFF for its data.</summary>
Dynamic = 1,
/// <summary>Image will not be re-scaled over time, thus turning scaling cache ON for its data.</summary>
Static = 2,
}
} } 
namespace Efl { namespace Gfx { 
/// <summary>Enumeration that defines scale types of an image.</summary>
public enum ImageScaleType
{
/// <summary>Scale the image so that it matches the object&apos;s area exactly. The image&apos;s aspect ratio might be changed.</summary>
Fill = 0,
/// <summary>Scale the image so that it fits inside the object&apos;s area while maintaining the aspect ratio. At least one of the dimensions of the image should be equal to the corresponding dimension of the object.</summary>
FitInside = 1,
/// <summary>Scale the image so that it covers the entire object area while maintaining the aspect ratio. At least one of the dimensions of the image should be equal to the corresponding dimension of the object.</summary>
FitOutside = 2,
/// <summary>Tile image at its original size.</summary>
Tile = 3,
/// <summary>Not scale the image</summary>
None = 4,
}
} } 
