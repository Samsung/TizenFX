#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary>The bg (background) widget is used for setting (solid) background decorations for a window (unless it has transparency enabled) or for any container object. It works just like an image, but has some properties useful for backgrounds, such as setting it to tiled, centered, scaled or stretched.</summary>
[BgNativeInherit]
public class Bg : Efl.Ui.Layout, Efl.Eo.IWrapper,Efl.Gfx.Image,Efl.Gfx.ImageLoadController
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Ui.BgNativeInherit nativeInherit = new Efl.Ui.BgNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (Bg))
            return Efl.Ui.BgNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   ///<summary>Delegate for function to be called from inside the native constructor.</summary>
   public new delegate void ConstructingMethod(Bg obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
      efl_ui_bg_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="init_cb">Delegate to call constructing methods that should be run inside the constructor.</param>
   public Bg(Efl.Object parent = null, ConstructingMethod init_cb=null) : base("Bg", efl_ui_bg_class_get(), typeof(Bg), parent)
   {
      if (init_cb != null) {
         init_cb(this);
      }
      FinishInstantiation();
   }
   ///<summary>Internal constructor to forward the wrapper initialization to the root class.</summary>
   protected Bg(String klass_name, IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(klass_name, base_klass, managed_type, parent) {}
   ///<summary>Constructs an instance from a native pointer.</summary>
   public Bg(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static Bg static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new Bg(obj.NativeHandle);
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
private static object PreloadEvtKey = new object();
   /// <summary>Image data has been preloaded.</summary>
   public event EventHandler PreloadEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_GFX_IMAGE_EVENT_PRELOAD";
            if (add_cpp_event_handler(key, this.evt_PreloadEvt_delegate)) {
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

private static object Efl_Gfx_Image_ResizeEvtKey = new object();
   /// <summary>Image was resized (its pixel data).</summary>
    event EventHandler Efl.Gfx.Image.ResizeEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_GFX_IMAGE_EVENT_RESIZE";
            if (add_cpp_event_handler(key, this.evt_Efl_Gfx_Image_ResizeEvt_delegate)) {
               eventHandlers.AddHandler(Efl_Gfx_Image_ResizeEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_GFX_IMAGE_EVENT_RESIZE";
            if (remove_cpp_event_handler(key, this.evt_Efl_Gfx_Image_ResizeEvt_delegate)) { 
               eventHandlers.RemoveHandler(Efl_Gfx_Image_ResizeEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event Efl_Gfx_Image_ResizeEvt.</summary>
   public void On_Efl_Gfx_Image_ResizeEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[Efl_Gfx_Image_ResizeEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_Efl_Gfx_Image_ResizeEvt_delegate;
   private void on_Efl_Gfx_Image_ResizeEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_Efl_Gfx_Image_ResizeEvt(args);
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
            if (add_cpp_event_handler(key, this.evt_UnloadEvt_delegate)) {
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

private static object LoadDoneEvtKey = new object();
   /// <summary>Called when he image was loaded</summary>
   public event EventHandler LoadDoneEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_GFX_IMAGE_LOAD_CONTROLLER_EVENT_LOAD_DONE";
            if (add_cpp_event_handler(key, this.evt_LoadDoneEvt_delegate)) {
               eventHandlers.AddHandler(LoadDoneEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_GFX_IMAGE_LOAD_CONTROLLER_EVENT_LOAD_DONE";
            if (remove_cpp_event_handler(key, this.evt_LoadDoneEvt_delegate)) { 
               eventHandlers.RemoveHandler(LoadDoneEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event LoadDoneEvt.</summary>
   public void On_LoadDoneEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[LoadDoneEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_LoadDoneEvt_delegate;
   private void on_LoadDoneEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_LoadDoneEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object LoadErrorEvtKey = new object();
   /// <summary>Called when an error happened during image loading</summary>
   public event EventHandler<Efl.Gfx.ImageLoadControllerLoadErrorEvt_Args> LoadErrorEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_GFX_IMAGE_LOAD_CONTROLLER_EVENT_LOAD_ERROR";
            if (add_cpp_event_handler(key, this.evt_LoadErrorEvt_delegate)) {
               eventHandlers.AddHandler(LoadErrorEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_GFX_IMAGE_LOAD_CONTROLLER_EVENT_LOAD_ERROR";
            if (remove_cpp_event_handler(key, this.evt_LoadErrorEvt_delegate)) { 
               eventHandlers.RemoveHandler(LoadErrorEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event LoadErrorEvt.</summary>
   public void On_LoadErrorEvt(Efl.Gfx.ImageLoadControllerLoadErrorEvt_Args e)
   {
      EventHandler<Efl.Gfx.ImageLoadControllerLoadErrorEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Gfx.ImageLoadControllerLoadErrorEvt_Args>)eventHandlers[LoadErrorEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_LoadErrorEvt_delegate;
   private void on_LoadErrorEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Gfx.ImageLoadControllerLoadErrorEvt_Args args = new Efl.Gfx.ImageLoadControllerLoadErrorEvt_Args();
      args.arg = default(Efl.Gfx.ImageLoadError);
      try {
         On_LoadErrorEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

   protected override void register_event_proxies()
   {
      base.register_event_proxies();
      evt_PreloadEvt_delegate = new Efl.EventCb(on_PreloadEvt_NativeCallback);
      evt_Efl_Gfx_Image_ResizeEvt_delegate = new Efl.EventCb(on_Efl_Gfx_Image_ResizeEvt_NativeCallback);
      evt_UnloadEvt_delegate = new Efl.EventCb(on_UnloadEvt_NativeCallback);
      evt_LoadDoneEvt_delegate = new Efl.EventCb(on_LoadDoneEvt_NativeCallback);
      evt_LoadErrorEvt_delegate = new Efl.EventCb(on_LoadErrorEvt_NativeCallback);
   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_gfx_image_smooth_scale_get(System.IntPtr obj);
   /// <summary>Whether to use high-quality image scaling algorithm for this image.
   /// When enabled, a higher quality image scaling algorithm is used when scaling images to sizes other than the source image&apos;s original one. This gives better results but is more computationally expensive.
   /// 
   /// <c>true</c> by default</summary>
   /// <returns>Whether to use smooth scale or not.</returns>
   virtual public bool GetSmoothScale() {
       var _ret_var = efl_gfx_image_smooth_scale_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_image_smooth_scale_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool smooth_scale);
   /// <summary>Whether to use high-quality image scaling algorithm for this image.
   /// When enabled, a higher quality image scaling algorithm is used when scaling images to sizes other than the source image&apos;s original one. This gives better results but is more computationally expensive.
   /// 
   /// <c>true</c> by default</summary>
   /// <param name="smooth_scale">Whether to use smooth scale or not.</param>
   /// <returns></returns>
   virtual public  void SetSmoothScale( bool smooth_scale) {
                         efl_gfx_image_smooth_scale_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  smooth_scale);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern Efl.Gfx.ImageScaleType efl_gfx_image_scale_type_get(System.IntPtr obj);
   /// <summary>Control how the image is scaled.</summary>
   /// <returns>Image scale type</returns>
   virtual public Efl.Gfx.ImageScaleType GetScaleType() {
       var _ret_var = efl_gfx_image_scale_type_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_image_scale_type_set(System.IntPtr obj,   Efl.Gfx.ImageScaleType scale_type);
   /// <summary>Control how the image is scaled.</summary>
   /// <param name="scale_type">Image scale type</param>
   /// <returns></returns>
   virtual public  void SetScaleType( Efl.Gfx.ImageScaleType scale_type) {
                         efl_gfx_image_scale_type_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  scale_type);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern double efl_gfx_image_ratio_get(System.IntPtr obj);
   /// <summary>Returns 1.0 if not applicable (eg. height = 0).</summary>
   /// <returns>The image&apos;s ratio.</returns>
   virtual public double GetRatio() {
       var _ret_var = efl_gfx_image_ratio_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_image_border_get(System.IntPtr obj,   out  int l,   out  int r,   out  int t,   out  int b);
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
   virtual public  void GetBorder( out  int l,  out  int r,  out  int t,  out  int b) {
                                                                               efl_gfx_image_border_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  out l,  out r,  out t,  out b);
      Eina.Error.RaiseIfUnhandledException();
                                                       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_image_border_set(System.IntPtr obj,    int l,    int r,    int t,    int b);
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
   virtual public  void SetBorder(  int l,   int r,   int t,   int b) {
                                                                               efl_gfx_image_border_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  l,  r,  t,  b);
      Eina.Error.RaiseIfUnhandledException();
                                                       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern double efl_gfx_image_border_scale_get(System.IntPtr obj);
   /// <summary>Scaling factor applied to the image borders.
   /// This value multiplies the size of the <see cref="Efl.Gfx.Image.GetBorder"/> when scaling an object.
   /// 
   /// Default value is 1.0 (no scaling).</summary>
   /// <returns>The scale factor.</returns>
   virtual public double GetBorderScale() {
       var _ret_var = efl_gfx_image_border_scale_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_image_border_scale_set(System.IntPtr obj,   double scale);
   /// <summary>Scaling factor applied to the image borders.
   /// This value multiplies the size of the <see cref="Efl.Gfx.Image.GetBorder"/> when scaling an object.
   /// 
   /// Default value is 1.0 (no scaling).</summary>
   /// <param name="scale">The scale factor.</param>
   /// <returns></returns>
   virtual public  void SetBorderScale( double scale) {
                         efl_gfx_image_border_scale_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  scale);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern Efl.Gfx.BorderFillMode efl_gfx_image_border_center_fill_get(System.IntPtr obj);
   /// <summary>Specifies how the center part of the object (not the borders) should be drawn when EFL is rendering it.
   /// This function sets how the center part of the image object&apos;s source image is to be drawn, which must be one of the values in <see cref="Efl.Gfx.BorderFillMode"/>. By center we mean the complementary part of that defined by <see cref="Efl.Gfx.Image.GetBorder"/>. This is very useful for making frames and decorations. You would most probably also be using a filled image (as in <see cref="Efl.Gfx.Fill.FillAuto"/>) to use as a frame.
   /// 
   /// The default value is <see cref="Efl.Gfx.BorderFillMode.Default"/>, ie. render and scale the center area, respecting its transparency.</summary>
   /// <returns>Fill mode of the center region.</returns>
   virtual public Efl.Gfx.BorderFillMode GetBorderCenterFill() {
       var _ret_var = efl_gfx_image_border_center_fill_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_image_border_center_fill_set(System.IntPtr obj,   Efl.Gfx.BorderFillMode fill);
   /// <summary>Specifies how the center part of the object (not the borders) should be drawn when EFL is rendering it.
   /// This function sets how the center part of the image object&apos;s source image is to be drawn, which must be one of the values in <see cref="Efl.Gfx.BorderFillMode"/>. By center we mean the complementary part of that defined by <see cref="Efl.Gfx.Image.GetBorder"/>. This is very useful for making frames and decorations. You would most probably also be using a filled image (as in <see cref="Efl.Gfx.Fill.FillAuto"/>) to use as a frame.
   /// 
   /// The default value is <see cref="Efl.Gfx.BorderFillMode.Default"/>, ie. render and scale the center area, respecting its transparency.</summary>
   /// <param name="fill">Fill mode of the center region.</param>
   /// <returns></returns>
   virtual public  void SetBorderCenterFill( Efl.Gfx.BorderFillMode fill) {
                         efl_gfx_image_border_center_fill_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  fill);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern Eina.Size2D_StructInternal efl_gfx_image_size_get(System.IntPtr obj);
   /// <summary>This represents the size of the original image in pixels.
   /// This may be different from the actual geometry on screen or even the size of the loaded pixel buffer. This is the size of the image as stored in the original file.
   /// 
   /// This is a read-only property, and may return 0x0.
   /// 1.20</summary>
   /// <returns>The size in pixels.</returns>
   virtual public Eina.Size2D GetImageSize() {
       var _ret_var = efl_gfx_image_size_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return Eina.Size2D_StructConversion.ToManaged(_ret_var);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern Efl.Gfx.ImageContentHint efl_gfx_image_content_hint_get(System.IntPtr obj);
   /// <summary>Get the content hint setting of a given image object of the canvas.
   /// This returns #EVAS_IMAGE_CONTENT_HINT_NONE on error.</summary>
   /// <returns>Dynamic or static content hint, see <see cref="Efl.Gfx.ImageContentHint"/></returns>
   virtual public Efl.Gfx.ImageContentHint GetContentHint() {
       var _ret_var = efl_gfx_image_content_hint_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_image_content_hint_set(System.IntPtr obj,   Efl.Gfx.ImageContentHint hint);
   /// <summary>Set the content hint setting of a given image object of the canvas.
   /// This function sets the content hint value of the given image of the canvas. For example, if you&apos;re on the GL engine and your driver implementation supports it, setting this hint to #EVAS_IMAGE_CONTENT_HINT_DYNAMIC will make it need zero copies at texture upload time, which is an &quot;expensive&quot; operation.</summary>
   /// <param name="hint">Dynamic or static content hint, see <see cref="Efl.Gfx.ImageContentHint"/></param>
   /// <returns></returns>
   virtual public  void SetContentHint( Efl.Gfx.ImageContentHint hint) {
                         efl_gfx_image_content_hint_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  hint);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern Efl.Gfx.ImageScaleHint efl_gfx_image_scale_hint_get(System.IntPtr obj);
   /// <summary>Get the scale hint of a given image of the canvas.
   /// This function returns the scale hint value of the given image object of the canvas.</summary>
   /// <returns>Scalable or static size hint, see <see cref="Efl.Gfx.ImageScaleHint"/></returns>
   virtual public Efl.Gfx.ImageScaleHint GetScaleHint() {
       var _ret_var = efl_gfx_image_scale_hint_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_image_scale_hint_set(System.IntPtr obj,   Efl.Gfx.ImageScaleHint hint);
   /// <summary>Set the scale hint of a given image of the canvas.
   /// This function sets the scale hint value of the given image object in the canvas, which will affect how Evas is to cache scaled versions of its original source image.</summary>
   /// <param name="hint">Scalable or static size hint, see <see cref="Efl.Gfx.ImageScaleHint"/></param>
   /// <returns></returns>
   virtual public  void SetScaleHint( Efl.Gfx.ImageScaleHint hint) {
                         efl_gfx_image_scale_hint_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  hint);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern Eina.Size2D_StructInternal efl_gfx_image_load_controller_load_size_get(System.IntPtr obj);
   /// <summary>Returns the requested load size.</summary>
   /// <returns>The image load size.</returns>
   virtual public Eina.Size2D GetLoadSize() {
       var _ret_var = efl_gfx_image_load_controller_load_size_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return Eina.Size2D_StructConversion.ToManaged(_ret_var);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_image_load_controller_load_size_set(System.IntPtr obj,   Eina.Size2D_StructInternal size);
   /// <summary>Requests the canvas to load the image at the given size.
   /// EFL will try to load an image of the requested size but does not guarantee an exact match between the request and the loaded image dimensions.</summary>
   /// <param name="size">The image load size.</param>
   /// <returns></returns>
   virtual public  void SetLoadSize( Eina.Size2D size) {
       var _in_size = Eina.Size2D_StructConversion.ToInternal(size);
                  efl_gfx_image_load_controller_load_size_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  _in_size);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern double efl_gfx_image_load_controller_load_dpi_get(System.IntPtr obj);
   /// <summary>Get the DPI resolution of a loaded image object in the canvas.
   /// This function returns the DPI resolution of the given canvas image.</summary>
   /// <returns>The DPI resolution.</returns>
   virtual public double GetLoadDpi() {
       var _ret_var = efl_gfx_image_load_controller_load_dpi_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_image_load_controller_load_dpi_set(System.IntPtr obj,   double dpi);
   /// <summary>Set the DPI resolution of an image object&apos;s source image.
   /// This function sets the DPI resolution of a given loaded canvas image. Most useful for the SVG image loader.</summary>
   /// <param name="dpi">The DPI resolution.</param>
   /// <returns></returns>
   virtual public  void SetLoadDpi( double dpi) {
                         efl_gfx_image_load_controller_load_dpi_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  dpi);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_gfx_image_load_controller_load_region_support_get(System.IntPtr obj);
   /// <summary>Indicates whether the <see cref="Efl.Gfx.ImageLoadController.LoadRegion"/> property is supported for the current file.
   /// 1.2</summary>
   /// <returns><c>true</c> if region load of the image is supported, <c>false</c> otherwise</returns>
   virtual public bool GetLoadRegionSupport() {
       var _ret_var = efl_gfx_image_load_controller_load_region_support_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern Eina.Rect_StructInternal efl_gfx_image_load_controller_load_region_get(System.IntPtr obj);
   /// <summary>Retrieve the coordinates of a given image object&apos;s selective (source image) load region.</summary>
   /// <returns>A region of the image.</returns>
   virtual public Eina.Rect GetLoadRegion() {
       var _ret_var = efl_gfx_image_load_controller_load_region_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return Eina.Rect_StructConversion.ToManaged(_ret_var);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_image_load_controller_load_region_set(System.IntPtr obj,   Eina.Rect_StructInternal region);
   /// <summary>Inform a given image object to load a selective region of its source image.
   /// This function is useful when one is not showing all of an image&apos;s area on its image object.
   /// 
   /// Note: The image loader for the image format in question has to support selective region loading in order for this function to work.</summary>
   /// <param name="region">A region of the image.</param>
   /// <returns></returns>
   virtual public  void SetLoadRegion( Eina.Rect region) {
       var _in_region = Eina.Rect_StructConversion.ToInternal(region);
                  efl_gfx_image_load_controller_load_region_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  _in_region);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_gfx_image_load_controller_load_orientation_get(System.IntPtr obj);
   /// <summary>Defines whether the orientation information in the image file should be honored.
   /// The orientation can for instance be set in the EXIF tags of a JPEG image. If this flag is <c>false</c>, then the orientation will be ignored at load time, otherwise the image will be loaded with the proper orientation.
   /// 1.1</summary>
   /// <returns><c>true</c> means that it should honor the orientation information.</returns>
   virtual public bool GetLoadOrientation() {
       var _ret_var = efl_gfx_image_load_controller_load_orientation_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_image_load_controller_load_orientation_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool enable);
   /// <summary>Defines whether the orientation information in the image file should be honored.
   /// The orientation can for instance be set in the EXIF tags of a JPEG image. If this flag is <c>false</c>, then the orientation will be ignored at load time, otherwise the image will be loaded with the proper orientation.
   /// 1.1</summary>
   /// <param name="enable"><c>true</c> means that it should honor the orientation information.</param>
   /// <returns></returns>
   virtual public  void SetLoadOrientation( bool enable) {
                         efl_gfx_image_load_controller_load_orientation_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  enable);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  int efl_gfx_image_load_controller_load_scale_down_get(System.IntPtr obj);
   /// <summary>The scale down factor is a divider on the original image size.
   /// Setting the scale down factor can reduce load time and memory usage at the cost of having a scaled down image in memory.
   /// 
   /// This function sets the scale down factor of a given canvas image. Most useful for the SVG image loader but also applies to JPEG, PNG and BMP.
   /// 
   /// Powers of two (2, 4, 8) are best supported (especially with JPEG)</summary>
   /// <returns>The scale down dividing factor.</returns>
   virtual public  int GetLoadScaleDown() {
       var _ret_var = efl_gfx_image_load_controller_load_scale_down_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_image_load_controller_load_scale_down_set(System.IntPtr obj,    int div);
   /// <summary>Requests the image loader to scale down by <c>div</c> times. Call this before starting the actual image load.</summary>
   /// <param name="div">The scale down dividing factor.</param>
   /// <returns></returns>
   virtual public  void SetLoadScaleDown(  int div) {
                         efl_gfx_image_load_controller_load_scale_down_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  div);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_gfx_image_load_controller_load_skip_header_get(System.IntPtr obj);
   /// <summary>Initial load should skip header check and leave it all to data load
   /// If this is true, then future loads of images will defer header loading to a preload stage and/or data load later on rather than at the start when the load begins (e.g. when file is set).</summary>
   /// <returns>Will be true if header is to be skipped.</returns>
   virtual public bool GetLoadSkipHeader() {
       var _ret_var = efl_gfx_image_load_controller_load_skip_header_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_image_load_controller_load_skip_header_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool skip);
   /// <summary>Set the skip header state for susbsequent loads of a file.</summary>
   /// <param name="skip">Will be true if header is to be skipped.</param>
   /// <returns></returns>
   virtual public  void SetLoadSkipHeader( bool skip) {
                         efl_gfx_image_load_controller_load_skip_header_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  skip);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_image_load_controller_load_async_start(System.IntPtr obj);
   /// <summary>Begin preloading an image object&apos;s image data in the background.
   /// Once the background task is complete the event <c>load</c>,done will be emitted.</summary>
   /// <returns></returns>
   virtual public  void LoadAsyncStart() {
       efl_gfx_image_load_controller_load_async_start((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_image_load_controller_load_async_cancel(System.IntPtr obj);
   /// <summary>Cancel preloading an image object&apos;s image data in the background.
   /// The object should be left in a state where it has no image data. If cancel is called too late, the image will be kept in memory.</summary>
   /// <returns></returns>
   virtual public  void LoadAsyncCancel() {
       efl_gfx_image_load_controller_load_async_cancel((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }
   /// <summary>Whether to use high-quality image scaling algorithm for this image.
/// When enabled, a higher quality image scaling algorithm is used when scaling images to sizes other than the source image&apos;s original one. This gives better results but is more computationally expensive.
/// 
/// <c>true</c> by default</summary>
   public bool SmoothScale {
      get { return GetSmoothScale(); }
      set { SetSmoothScale( value); }
   }
   /// <summary>Control how the image is scaled.</summary>
   public Efl.Gfx.ImageScaleType ScaleType {
      get { return GetScaleType(); }
      set { SetScaleType( value); }
   }
   /// <summary>The native width/height ratio of the image.</summary>
   public double Ratio {
      get { return GetRatio(); }
   }
   /// <summary>Scaling factor applied to the image borders.
/// This value multiplies the size of the <see cref="Efl.Gfx.Image.GetBorder"/> when scaling an object.
/// 
/// Default value is 1.0 (no scaling).</summary>
   public double BorderScale {
      get { return GetBorderScale(); }
      set { SetBorderScale( value); }
   }
   /// <summary>Specifies how the center part of the object (not the borders) should be drawn when EFL is rendering it.
/// This function sets how the center part of the image object&apos;s source image is to be drawn, which must be one of the values in <see cref="Efl.Gfx.BorderFillMode"/>. By center we mean the complementary part of that defined by <see cref="Efl.Gfx.Image.GetBorder"/>. This is very useful for making frames and decorations. You would most probably also be using a filled image (as in <see cref="Efl.Gfx.Fill.FillAuto"/>) to use as a frame.
/// 
/// The default value is <see cref="Efl.Gfx.BorderFillMode.Default"/>, ie. render and scale the center area, respecting its transparency.</summary>
   public Efl.Gfx.BorderFillMode BorderCenterFill {
      get { return GetBorderCenterFill(); }
      set { SetBorderCenterFill( value); }
   }
   /// <summary>This represents the size of the original image in pixels.
/// This may be different from the actual geometry on screen or even the size of the loaded pixel buffer. This is the size of the image as stored in the original file.
/// 
/// This is a read-only property, and may return 0x0.
/// 1.20</summary>
   public Eina.Size2D ImageSize {
      get { return GetImageSize(); }
   }
   /// <summary>Get the content hint setting of a given image object of the canvas.
/// This returns #EVAS_IMAGE_CONTENT_HINT_NONE on error.</summary>
   public Efl.Gfx.ImageContentHint ContentHint {
      get { return GetContentHint(); }
      set { SetContentHint( value); }
   }
   /// <summary>Get the scale hint of a given image of the canvas.
/// This function returns the scale hint value of the given image object of the canvas.</summary>
   public Efl.Gfx.ImageScaleHint ScaleHint {
      get { return GetScaleHint(); }
      set { SetScaleHint( value); }
   }
   /// <summary>The load size of an image.
/// The image will be loaded into memory as if it was the specified size instead of its original size. This can save a lot of memory and is important for scalable types like svg.
/// 
/// By default, the load size is not specified, so it is 0x0.</summary>
   public Eina.Size2D LoadSize {
      get { return GetLoadSize(); }
      set { SetLoadSize( value); }
   }
   /// <summary>Get the DPI resolution of a loaded image object in the canvas.
/// This function returns the DPI resolution of the given canvas image.</summary>
   public double LoadDpi {
      get { return GetLoadDpi(); }
      set { SetLoadDpi( value); }
   }
   /// <summary>Indicates whether the <see cref="Efl.Gfx.ImageLoadController.LoadRegion"/> property is supported for the current file.
/// 1.2</summary>
   public bool LoadRegionSupport {
      get { return GetLoadRegionSupport(); }
   }
   /// <summary>Retrieve the coordinates of a given image object&apos;s selective (source image) load region.</summary>
   public Eina.Rect LoadRegion {
      get { return GetLoadRegion(); }
      set { SetLoadRegion( value); }
   }
   /// <summary>Defines whether the orientation information in the image file should be honored.
/// The orientation can for instance be set in the EXIF tags of a JPEG image. If this flag is <c>false</c>, then the orientation will be ignored at load time, otherwise the image will be loaded with the proper orientation.
/// 1.1</summary>
   public bool LoadOrientation {
      get { return GetLoadOrientation(); }
      set { SetLoadOrientation( value); }
   }
   /// <summary>The scale down factor is a divider on the original image size.
/// Setting the scale down factor can reduce load time and memory usage at the cost of having a scaled down image in memory.
/// 
/// This function sets the scale down factor of a given canvas image. Most useful for the SVG image loader but also applies to JPEG, PNG and BMP.
/// 
/// Powers of two (2, 4, 8) are best supported (especially with JPEG)</summary>
   public  int LoadScaleDown {
      get { return GetLoadScaleDown(); }
      set { SetLoadScaleDown( value); }
   }
   /// <summary>Initial load should skip header check and leave it all to data load
/// If this is true, then future loads of images will defer header loading to a preload stage and/or data load later on rather than at the start when the load begins (e.g. when file is set).</summary>
   public bool LoadSkipHeader {
      get { return GetLoadSkipHeader(); }
      set { SetLoadSkipHeader( value); }
   }
}
public class BgNativeInherit : Efl.Ui.LayoutNativeInherit{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_gfx_image_smooth_scale_get_static_delegate = new efl_gfx_image_smooth_scale_get_delegate(smooth_scale_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_image_smooth_scale_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_smooth_scale_get_static_delegate)});
      efl_gfx_image_smooth_scale_set_static_delegate = new efl_gfx_image_smooth_scale_set_delegate(smooth_scale_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_image_smooth_scale_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_smooth_scale_set_static_delegate)});
      efl_gfx_image_scale_type_get_static_delegate = new efl_gfx_image_scale_type_get_delegate(scale_type_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_image_scale_type_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_scale_type_get_static_delegate)});
      efl_gfx_image_scale_type_set_static_delegate = new efl_gfx_image_scale_type_set_delegate(scale_type_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_image_scale_type_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_scale_type_set_static_delegate)});
      efl_gfx_image_ratio_get_static_delegate = new efl_gfx_image_ratio_get_delegate(ratio_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_image_ratio_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_ratio_get_static_delegate)});
      efl_gfx_image_border_get_static_delegate = new efl_gfx_image_border_get_delegate(border_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_image_border_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_border_get_static_delegate)});
      efl_gfx_image_border_set_static_delegate = new efl_gfx_image_border_set_delegate(border_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_image_border_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_border_set_static_delegate)});
      efl_gfx_image_border_scale_get_static_delegate = new efl_gfx_image_border_scale_get_delegate(border_scale_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_image_border_scale_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_border_scale_get_static_delegate)});
      efl_gfx_image_border_scale_set_static_delegate = new efl_gfx_image_border_scale_set_delegate(border_scale_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_image_border_scale_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_border_scale_set_static_delegate)});
      efl_gfx_image_border_center_fill_get_static_delegate = new efl_gfx_image_border_center_fill_get_delegate(border_center_fill_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_image_border_center_fill_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_border_center_fill_get_static_delegate)});
      efl_gfx_image_border_center_fill_set_static_delegate = new efl_gfx_image_border_center_fill_set_delegate(border_center_fill_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_image_border_center_fill_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_border_center_fill_set_static_delegate)});
      efl_gfx_image_size_get_static_delegate = new efl_gfx_image_size_get_delegate(image_size_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_image_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_size_get_static_delegate)});
      efl_gfx_image_content_hint_get_static_delegate = new efl_gfx_image_content_hint_get_delegate(content_hint_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_image_content_hint_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_content_hint_get_static_delegate)});
      efl_gfx_image_content_hint_set_static_delegate = new efl_gfx_image_content_hint_set_delegate(content_hint_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_image_content_hint_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_content_hint_set_static_delegate)});
      efl_gfx_image_scale_hint_get_static_delegate = new efl_gfx_image_scale_hint_get_delegate(scale_hint_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_image_scale_hint_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_scale_hint_get_static_delegate)});
      efl_gfx_image_scale_hint_set_static_delegate = new efl_gfx_image_scale_hint_set_delegate(scale_hint_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_image_scale_hint_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_scale_hint_set_static_delegate)});
      efl_gfx_image_load_controller_load_size_get_static_delegate = new efl_gfx_image_load_controller_load_size_get_delegate(load_size_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_image_load_controller_load_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_size_get_static_delegate)});
      efl_gfx_image_load_controller_load_size_set_static_delegate = new efl_gfx_image_load_controller_load_size_set_delegate(load_size_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_image_load_controller_load_size_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_size_set_static_delegate)});
      efl_gfx_image_load_controller_load_dpi_get_static_delegate = new efl_gfx_image_load_controller_load_dpi_get_delegate(load_dpi_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_image_load_controller_load_dpi_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_dpi_get_static_delegate)});
      efl_gfx_image_load_controller_load_dpi_set_static_delegate = new efl_gfx_image_load_controller_load_dpi_set_delegate(load_dpi_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_image_load_controller_load_dpi_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_dpi_set_static_delegate)});
      efl_gfx_image_load_controller_load_region_support_get_static_delegate = new efl_gfx_image_load_controller_load_region_support_get_delegate(load_region_support_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_image_load_controller_load_region_support_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_region_support_get_static_delegate)});
      efl_gfx_image_load_controller_load_region_get_static_delegate = new efl_gfx_image_load_controller_load_region_get_delegate(load_region_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_image_load_controller_load_region_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_region_get_static_delegate)});
      efl_gfx_image_load_controller_load_region_set_static_delegate = new efl_gfx_image_load_controller_load_region_set_delegate(load_region_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_image_load_controller_load_region_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_region_set_static_delegate)});
      efl_gfx_image_load_controller_load_orientation_get_static_delegate = new efl_gfx_image_load_controller_load_orientation_get_delegate(load_orientation_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_image_load_controller_load_orientation_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_orientation_get_static_delegate)});
      efl_gfx_image_load_controller_load_orientation_set_static_delegate = new efl_gfx_image_load_controller_load_orientation_set_delegate(load_orientation_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_image_load_controller_load_orientation_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_orientation_set_static_delegate)});
      efl_gfx_image_load_controller_load_scale_down_get_static_delegate = new efl_gfx_image_load_controller_load_scale_down_get_delegate(load_scale_down_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_image_load_controller_load_scale_down_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_scale_down_get_static_delegate)});
      efl_gfx_image_load_controller_load_scale_down_set_static_delegate = new efl_gfx_image_load_controller_load_scale_down_set_delegate(load_scale_down_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_image_load_controller_load_scale_down_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_scale_down_set_static_delegate)});
      efl_gfx_image_load_controller_load_skip_header_get_static_delegate = new efl_gfx_image_load_controller_load_skip_header_get_delegate(load_skip_header_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_image_load_controller_load_skip_header_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_skip_header_get_static_delegate)});
      efl_gfx_image_load_controller_load_skip_header_set_static_delegate = new efl_gfx_image_load_controller_load_skip_header_set_delegate(load_skip_header_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_image_load_controller_load_skip_header_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_skip_header_set_static_delegate)});
      efl_gfx_image_load_controller_load_async_start_static_delegate = new efl_gfx_image_load_controller_load_async_start_delegate(load_async_start);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_image_load_controller_load_async_start"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_async_start_static_delegate)});
      efl_gfx_image_load_controller_load_async_cancel_static_delegate = new efl_gfx_image_load_controller_load_async_cancel_delegate(load_async_cancel);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_image_load_controller_load_async_cancel"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_async_cancel_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Ui.Bg.efl_ui_bg_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.Bg.efl_ui_bg_class_get();
   }


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_gfx_image_smooth_scale_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_gfx_image_smooth_scale_get(System.IntPtr obj);
    private static bool smooth_scale_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_image_smooth_scale_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Bg)wrapper).GetSmoothScale();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_image_smooth_scale_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_image_smooth_scale_get_delegate efl_gfx_image_smooth_scale_get_static_delegate;


    private delegate  void efl_gfx_image_smooth_scale_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool smooth_scale);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_image_smooth_scale_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool smooth_scale);
    private static  void smooth_scale_set(System.IntPtr obj, System.IntPtr pd,  bool smooth_scale)
   {
      Eina.Log.Debug("function efl_gfx_image_smooth_scale_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Bg)wrapper).SetSmoothScale( smooth_scale);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_image_smooth_scale_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  smooth_scale);
      }
   }
   private efl_gfx_image_smooth_scale_set_delegate efl_gfx_image_smooth_scale_set_static_delegate;


    private delegate Efl.Gfx.ImageScaleType efl_gfx_image_scale_type_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Efl.Gfx.ImageScaleType efl_gfx_image_scale_type_get(System.IntPtr obj);
    private static Efl.Gfx.ImageScaleType scale_type_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_image_scale_type_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Gfx.ImageScaleType _ret_var = default(Efl.Gfx.ImageScaleType);
         try {
            _ret_var = ((Bg)wrapper).GetScaleType();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_image_scale_type_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_image_scale_type_get_delegate efl_gfx_image_scale_type_get_static_delegate;


    private delegate  void efl_gfx_image_scale_type_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Gfx.ImageScaleType scale_type);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_image_scale_type_set(System.IntPtr obj,   Efl.Gfx.ImageScaleType scale_type);
    private static  void scale_type_set(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.ImageScaleType scale_type)
   {
      Eina.Log.Debug("function efl_gfx_image_scale_type_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Bg)wrapper).SetScaleType( scale_type);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_image_scale_type_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  scale_type);
      }
   }
   private efl_gfx_image_scale_type_set_delegate efl_gfx_image_scale_type_set_static_delegate;


    private delegate double efl_gfx_image_ratio_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern double efl_gfx_image_ratio_get(System.IntPtr obj);
    private static double ratio_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_image_ratio_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  double _ret_var = default(double);
         try {
            _ret_var = ((Bg)wrapper).GetRatio();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_image_ratio_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_image_ratio_get_delegate efl_gfx_image_ratio_get_static_delegate;


    private delegate  void efl_gfx_image_border_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  int l,   out  int r,   out  int t,   out  int b);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_image_border_get(System.IntPtr obj,   out  int l,   out  int r,   out  int t,   out  int b);
    private static  void border_get(System.IntPtr obj, System.IntPtr pd,  out  int l,  out  int r,  out  int t,  out  int b)
   {
      Eina.Log.Debug("function efl_gfx_image_border_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                       l = default( int);      r = default( int);      t = default( int);      b = default( int);                                 
         try {
            ((Bg)wrapper).GetBorder( out l,  out r,  out t,  out b);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_gfx_image_border_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out l,  out r,  out t,  out b);
      }
   }
   private efl_gfx_image_border_get_delegate efl_gfx_image_border_get_static_delegate;


    private delegate  void efl_gfx_image_border_set_delegate(System.IntPtr obj, System.IntPtr pd,    int l,    int r,    int t,    int b);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_image_border_set(System.IntPtr obj,    int l,    int r,    int t,    int b);
    private static  void border_set(System.IntPtr obj, System.IntPtr pd,   int l,   int r,   int t,   int b)
   {
      Eina.Log.Debug("function efl_gfx_image_border_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                          
         try {
            ((Bg)wrapper).SetBorder( l,  r,  t,  b);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_gfx_image_border_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  l,  r,  t,  b);
      }
   }
   private efl_gfx_image_border_set_delegate efl_gfx_image_border_set_static_delegate;


    private delegate double efl_gfx_image_border_scale_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern double efl_gfx_image_border_scale_get(System.IntPtr obj);
    private static double border_scale_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_image_border_scale_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  double _ret_var = default(double);
         try {
            _ret_var = ((Bg)wrapper).GetBorderScale();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_image_border_scale_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_image_border_scale_get_delegate efl_gfx_image_border_scale_get_static_delegate;


    private delegate  void efl_gfx_image_border_scale_set_delegate(System.IntPtr obj, System.IntPtr pd,   double scale);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_image_border_scale_set(System.IntPtr obj,   double scale);
    private static  void border_scale_set(System.IntPtr obj, System.IntPtr pd,  double scale)
   {
      Eina.Log.Debug("function efl_gfx_image_border_scale_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Bg)wrapper).SetBorderScale( scale);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_image_border_scale_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  scale);
      }
   }
   private efl_gfx_image_border_scale_set_delegate efl_gfx_image_border_scale_set_static_delegate;


    private delegate Efl.Gfx.BorderFillMode efl_gfx_image_border_center_fill_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Efl.Gfx.BorderFillMode efl_gfx_image_border_center_fill_get(System.IntPtr obj);
    private static Efl.Gfx.BorderFillMode border_center_fill_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_image_border_center_fill_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Gfx.BorderFillMode _ret_var = default(Efl.Gfx.BorderFillMode);
         try {
            _ret_var = ((Bg)wrapper).GetBorderCenterFill();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_image_border_center_fill_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_image_border_center_fill_get_delegate efl_gfx_image_border_center_fill_get_static_delegate;


    private delegate  void efl_gfx_image_border_center_fill_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Gfx.BorderFillMode fill);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_image_border_center_fill_set(System.IntPtr obj,   Efl.Gfx.BorderFillMode fill);
    private static  void border_center_fill_set(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.BorderFillMode fill)
   {
      Eina.Log.Debug("function efl_gfx_image_border_center_fill_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Bg)wrapper).SetBorderCenterFill( fill);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_image_border_center_fill_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  fill);
      }
   }
   private efl_gfx_image_border_center_fill_set_delegate efl_gfx_image_border_center_fill_set_static_delegate;


    private delegate Eina.Size2D_StructInternal efl_gfx_image_size_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Eina.Size2D_StructInternal efl_gfx_image_size_get(System.IntPtr obj);
    private static Eina.Size2D_StructInternal image_size_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_image_size_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Size2D _ret_var = default(Eina.Size2D);
         try {
            _ret_var = ((Bg)wrapper).GetImageSize();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Eina.Size2D_StructConversion.ToInternal(_ret_var);
      } else {
         return efl_gfx_image_size_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_image_size_get_delegate efl_gfx_image_size_get_static_delegate;


    private delegate Efl.Gfx.ImageContentHint efl_gfx_image_content_hint_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Efl.Gfx.ImageContentHint efl_gfx_image_content_hint_get(System.IntPtr obj);
    private static Efl.Gfx.ImageContentHint content_hint_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_image_content_hint_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Gfx.ImageContentHint _ret_var = default(Efl.Gfx.ImageContentHint);
         try {
            _ret_var = ((Bg)wrapper).GetContentHint();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_image_content_hint_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_image_content_hint_get_delegate efl_gfx_image_content_hint_get_static_delegate;


    private delegate  void efl_gfx_image_content_hint_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Gfx.ImageContentHint hint);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_image_content_hint_set(System.IntPtr obj,   Efl.Gfx.ImageContentHint hint);
    private static  void content_hint_set(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.ImageContentHint hint)
   {
      Eina.Log.Debug("function efl_gfx_image_content_hint_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Bg)wrapper).SetContentHint( hint);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_image_content_hint_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  hint);
      }
   }
   private efl_gfx_image_content_hint_set_delegate efl_gfx_image_content_hint_set_static_delegate;


    private delegate Efl.Gfx.ImageScaleHint efl_gfx_image_scale_hint_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Efl.Gfx.ImageScaleHint efl_gfx_image_scale_hint_get(System.IntPtr obj);
    private static Efl.Gfx.ImageScaleHint scale_hint_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_image_scale_hint_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Gfx.ImageScaleHint _ret_var = default(Efl.Gfx.ImageScaleHint);
         try {
            _ret_var = ((Bg)wrapper).GetScaleHint();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_image_scale_hint_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_image_scale_hint_get_delegate efl_gfx_image_scale_hint_get_static_delegate;


    private delegate  void efl_gfx_image_scale_hint_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Gfx.ImageScaleHint hint);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_image_scale_hint_set(System.IntPtr obj,   Efl.Gfx.ImageScaleHint hint);
    private static  void scale_hint_set(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.ImageScaleHint hint)
   {
      Eina.Log.Debug("function efl_gfx_image_scale_hint_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Bg)wrapper).SetScaleHint( hint);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_image_scale_hint_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  hint);
      }
   }
   private efl_gfx_image_scale_hint_set_delegate efl_gfx_image_scale_hint_set_static_delegate;


    private delegate Eina.Size2D_StructInternal efl_gfx_image_load_controller_load_size_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Eina.Size2D_StructInternal efl_gfx_image_load_controller_load_size_get(System.IntPtr obj);
    private static Eina.Size2D_StructInternal load_size_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_image_load_controller_load_size_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Size2D _ret_var = default(Eina.Size2D);
         try {
            _ret_var = ((Bg)wrapper).GetLoadSize();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Eina.Size2D_StructConversion.ToInternal(_ret_var);
      } else {
         return efl_gfx_image_load_controller_load_size_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_image_load_controller_load_size_get_delegate efl_gfx_image_load_controller_load_size_get_static_delegate;


    private delegate  void efl_gfx_image_load_controller_load_size_set_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Size2D_StructInternal size);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_image_load_controller_load_size_set(System.IntPtr obj,   Eina.Size2D_StructInternal size);
    private static  void load_size_set(System.IntPtr obj, System.IntPtr pd,  Eina.Size2D_StructInternal size)
   {
      Eina.Log.Debug("function efl_gfx_image_load_controller_load_size_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_size = Eina.Size2D_StructConversion.ToManaged(size);
                     
         try {
            ((Bg)wrapper).SetLoadSize( _in_size);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_image_load_controller_load_size_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  size);
      }
   }
   private efl_gfx_image_load_controller_load_size_set_delegate efl_gfx_image_load_controller_load_size_set_static_delegate;


    private delegate double efl_gfx_image_load_controller_load_dpi_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern double efl_gfx_image_load_controller_load_dpi_get(System.IntPtr obj);
    private static double load_dpi_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_image_load_controller_load_dpi_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  double _ret_var = default(double);
         try {
            _ret_var = ((Bg)wrapper).GetLoadDpi();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_image_load_controller_load_dpi_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_image_load_controller_load_dpi_get_delegate efl_gfx_image_load_controller_load_dpi_get_static_delegate;


    private delegate  void efl_gfx_image_load_controller_load_dpi_set_delegate(System.IntPtr obj, System.IntPtr pd,   double dpi);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_image_load_controller_load_dpi_set(System.IntPtr obj,   double dpi);
    private static  void load_dpi_set(System.IntPtr obj, System.IntPtr pd,  double dpi)
   {
      Eina.Log.Debug("function efl_gfx_image_load_controller_load_dpi_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Bg)wrapper).SetLoadDpi( dpi);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_image_load_controller_load_dpi_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  dpi);
      }
   }
   private efl_gfx_image_load_controller_load_dpi_set_delegate efl_gfx_image_load_controller_load_dpi_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_gfx_image_load_controller_load_region_support_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_gfx_image_load_controller_load_region_support_get(System.IntPtr obj);
    private static bool load_region_support_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_image_load_controller_load_region_support_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Bg)wrapper).GetLoadRegionSupport();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_image_load_controller_load_region_support_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_image_load_controller_load_region_support_get_delegate efl_gfx_image_load_controller_load_region_support_get_static_delegate;


    private delegate Eina.Rect_StructInternal efl_gfx_image_load_controller_load_region_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Eina.Rect_StructInternal efl_gfx_image_load_controller_load_region_get(System.IntPtr obj);
    private static Eina.Rect_StructInternal load_region_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_image_load_controller_load_region_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Rect _ret_var = default(Eina.Rect);
         try {
            _ret_var = ((Bg)wrapper).GetLoadRegion();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Eina.Rect_StructConversion.ToInternal(_ret_var);
      } else {
         return efl_gfx_image_load_controller_load_region_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_image_load_controller_load_region_get_delegate efl_gfx_image_load_controller_load_region_get_static_delegate;


    private delegate  void efl_gfx_image_load_controller_load_region_set_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Rect_StructInternal region);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_image_load_controller_load_region_set(System.IntPtr obj,   Eina.Rect_StructInternal region);
    private static  void load_region_set(System.IntPtr obj, System.IntPtr pd,  Eina.Rect_StructInternal region)
   {
      Eina.Log.Debug("function efl_gfx_image_load_controller_load_region_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_region = Eina.Rect_StructConversion.ToManaged(region);
                     
         try {
            ((Bg)wrapper).SetLoadRegion( _in_region);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_image_load_controller_load_region_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  region);
      }
   }
   private efl_gfx_image_load_controller_load_region_set_delegate efl_gfx_image_load_controller_load_region_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_gfx_image_load_controller_load_orientation_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_gfx_image_load_controller_load_orientation_get(System.IntPtr obj);
    private static bool load_orientation_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_image_load_controller_load_orientation_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Bg)wrapper).GetLoadOrientation();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_image_load_controller_load_orientation_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_image_load_controller_load_orientation_get_delegate efl_gfx_image_load_controller_load_orientation_get_static_delegate;


    private delegate  void efl_gfx_image_load_controller_load_orientation_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool enable);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_image_load_controller_load_orientation_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool enable);
    private static  void load_orientation_set(System.IntPtr obj, System.IntPtr pd,  bool enable)
   {
      Eina.Log.Debug("function efl_gfx_image_load_controller_load_orientation_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Bg)wrapper).SetLoadOrientation( enable);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_image_load_controller_load_orientation_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  enable);
      }
   }
   private efl_gfx_image_load_controller_load_orientation_set_delegate efl_gfx_image_load_controller_load_orientation_set_static_delegate;


    private delegate  int efl_gfx_image_load_controller_load_scale_down_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  int efl_gfx_image_load_controller_load_scale_down_get(System.IntPtr obj);
    private static  int load_scale_down_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_image_load_controller_load_scale_down_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   int _ret_var = default( int);
         try {
            _ret_var = ((Bg)wrapper).GetLoadScaleDown();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_image_load_controller_load_scale_down_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_image_load_controller_load_scale_down_get_delegate efl_gfx_image_load_controller_load_scale_down_get_static_delegate;


    private delegate  void efl_gfx_image_load_controller_load_scale_down_set_delegate(System.IntPtr obj, System.IntPtr pd,    int div);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_image_load_controller_load_scale_down_set(System.IntPtr obj,    int div);
    private static  void load_scale_down_set(System.IntPtr obj, System.IntPtr pd,   int div)
   {
      Eina.Log.Debug("function efl_gfx_image_load_controller_load_scale_down_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Bg)wrapper).SetLoadScaleDown( div);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_image_load_controller_load_scale_down_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  div);
      }
   }
   private efl_gfx_image_load_controller_load_scale_down_set_delegate efl_gfx_image_load_controller_load_scale_down_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_gfx_image_load_controller_load_skip_header_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_gfx_image_load_controller_load_skip_header_get(System.IntPtr obj);
    private static bool load_skip_header_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_image_load_controller_load_skip_header_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Bg)wrapper).GetLoadSkipHeader();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_image_load_controller_load_skip_header_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_image_load_controller_load_skip_header_get_delegate efl_gfx_image_load_controller_load_skip_header_get_static_delegate;


    private delegate  void efl_gfx_image_load_controller_load_skip_header_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool skip);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_image_load_controller_load_skip_header_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool skip);
    private static  void load_skip_header_set(System.IntPtr obj, System.IntPtr pd,  bool skip)
   {
      Eina.Log.Debug("function efl_gfx_image_load_controller_load_skip_header_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Bg)wrapper).SetLoadSkipHeader( skip);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_image_load_controller_load_skip_header_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  skip);
      }
   }
   private efl_gfx_image_load_controller_load_skip_header_set_delegate efl_gfx_image_load_controller_load_skip_header_set_static_delegate;


    private delegate  void efl_gfx_image_load_controller_load_async_start_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_image_load_controller_load_async_start(System.IntPtr obj);
    private static  void load_async_start(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_image_load_controller_load_async_start was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Bg)wrapper).LoadAsyncStart();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_gfx_image_load_controller_load_async_start(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_image_load_controller_load_async_start_delegate efl_gfx_image_load_controller_load_async_start_static_delegate;


    private delegate  void efl_gfx_image_load_controller_load_async_cancel_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_image_load_controller_load_async_cancel(System.IntPtr obj);
    private static  void load_async_cancel(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_image_load_controller_load_async_cancel was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Bg)wrapper).LoadAsyncCancel();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_gfx_image_load_controller_load_async_cancel(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_image_load_controller_load_async_cancel_delegate efl_gfx_image_load_controller_load_async_cancel_static_delegate;
}
} } 
