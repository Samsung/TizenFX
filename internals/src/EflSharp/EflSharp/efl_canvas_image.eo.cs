#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Canvas { 
/// <summary>Low-level Image object.
/// This replaces the legacy Evas Object Image, with only image-related interfaces: file and data images only. This object does not implement any special features such as proxy, snapshot or GL.</summary>
[ImageNativeInherit]
public class Image : Efl.Canvas.ImageInternal, Efl.Eo.IWrapper,Efl.Gfx.ImageAnimationController,Efl.Gfx.ImageLoadController
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Canvas.ImageNativeInherit nativeInherit = new Efl.Canvas.ImageNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (Image))
            return Efl.Canvas.ImageNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   ///<summary>Delegate for function to be called from inside the native constructor.</summary>
   public new delegate void ConstructingMethod(Image obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] internal static extern System.IntPtr
      efl_canvas_image_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="init_cb">Delegate to call constructing methods that should be run inside the constructor.</param>
   public Image(Efl.Object parent = null, ConstructingMethod init_cb=null) : base("Image", efl_canvas_image_class_get(), typeof(Image), parent)
   {
      if (init_cb != null) {
         init_cb(this);
      }
      FinishInstantiation();
   }
   ///<summary>Internal constructor to forward the wrapper initialization to the root class.</summary>
   protected Image(String klass_name, IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(klass_name, base_klass, managed_type, parent) {}
   ///<summary>Constructs an instance from a native pointer.</summary>
   public Image(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static Image static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new Image(obj.NativeHandle);
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
      evt_LoadDoneEvt_delegate = new Efl.EventCb(on_LoadDoneEvt_NativeCallback);
      evt_LoadErrorEvt_delegate = new Efl.EventCb(on_LoadErrorEvt_NativeCallback);
   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_gfx_image_animated_get(System.IntPtr obj);
   /// <summary>Check if an image can be animated (has multiple frames).
   /// This will be <c>true</c> for animated Gif files for instance but <c>false</c> for still images.
   /// 1.1</summary>
   /// <returns><c>true</c> if the image is animated</returns>
   virtual public bool GetAnimated() {
       var _ret_var = efl_gfx_image_animated_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  int efl_gfx_image_animated_frame_get(System.IntPtr obj);
   /// <summary>Index of the current frame of an animated image.
   /// Ranges from 1 to <see cref="Efl.Gfx.ImageAnimationController.GetAnimatedFrameCount"/>. Valid only if <see cref="Efl.Gfx.ImageAnimationController.GetAnimated"/>.</summary>
   /// <returns>The index of current frame.</returns>
   virtual public  int GetAnimatedFrame() {
       var _ret_var = efl_gfx_image_animated_frame_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_gfx_image_animated_frame_set(System.IntPtr obj,    int frame_index);
   /// <summary>Set the frame to current frame of an image object.
   /// 1.1</summary>
   /// <param name="frame_index">The index of current frame.</param>
   /// <returns>Returns <c>true</c> if the frame index is valid.</returns>
   virtual public bool SetAnimatedFrame(  int frame_index) {
                         var _ret_var = efl_gfx_image_animated_frame_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  frame_index);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  int efl_gfx_image_animated_frame_count_get(System.IntPtr obj);
   /// <summary>Get the total number of frames of the image, if animated.
   /// Returns -1 if not animated.
   /// 1.1</summary>
   /// <returns>The number of frames in the animated image.</returns>
   virtual public  int GetAnimatedFrameCount() {
       var _ret_var = efl_gfx_image_animated_frame_count_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern Efl.Gfx.ImageAnimationControllerLoopHint efl_gfx_image_animated_loop_type_get(System.IntPtr obj);
   /// <summary>Get the kind of looping the image object does.
   /// This returns the kind of looping the image object wants to do.
   /// 
   /// If it returns <see cref="Efl.Gfx.ImageAnimationControllerLoopHint.Loop"/>, you should display frames in a sequence like: 1-&gt;2-&gt;3-&gt;1-&gt;2-&gt;3-&gt;1...
   /// 
   /// If it returns <see cref="Efl.Gfx.ImageAnimationControllerLoopHint.Pingpong"/>, it is better to display frames in a sequence like: 1-&gt;2-&gt;3-&gt;2-&gt;1-&gt;2-&gt;3-&gt;1...
   /// 
   /// The default type is <see cref="Efl.Gfx.ImageAnimationControllerLoopHint.Loop"/>.
   /// 1.1</summary>
   /// <returns>Loop type of the image object.</returns>
   virtual public Efl.Gfx.ImageAnimationControllerLoopHint GetAnimatedLoopType() {
       var _ret_var = efl_gfx_image_animated_loop_type_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  int efl_gfx_image_animated_loop_count_get(System.IntPtr obj);
   /// <summary>Get the number times the animation of the object loops.
   /// This returns loop count of image. The loop count is the number of times the animation will play fully from first to last frame until the animation should stop (at the final frame).
   /// 
   /// If 0 is returned, then looping should happen indefinitely (no limit to the number of times it loops).
   /// 1.1</summary>
   /// <returns>The number of loop of an animated image object.</returns>
   virtual public  int GetAnimatedLoopCount() {
       var _ret_var = efl_gfx_image_animated_loop_count_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern double efl_gfx_image_animated_frame_duration_get(System.IntPtr obj,    int start_frame,    int frame_num);
   /// <summary>Get the duration of a sequence of frames.
   /// This returns total duration in seconds that the specified sequence of frames should take.
   /// 
   /// If <c>start_frame</c> is 1 and <c>frame_num</c> is 0, this returns the duration of frame 1. If <c>start_frame</c> is 1 and <c>frame_num</c> is 1, this returns the total duration of frame 1 + frame 2.
   /// 1.1</summary>
   /// <param name="start_frame">The first frame, rangers from 1 to <see cref="Efl.Gfx.ImageAnimationController.GetAnimatedFrameCount"/>.</param>
   /// <param name="frame_num">Number of frames in the sequence, starts from 0.</param>
   /// <returns>Duration in seconds</returns>
   virtual public double GetAnimatedFrameDuration(  int start_frame,   int frame_num) {
                                           var _ret_var = efl_gfx_image_animated_frame_duration_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  start_frame,  frame_num);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
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
   /// <summary>Check if an image can be animated (has multiple frames).
/// This will be <c>true</c> for animated Gif files for instance but <c>false</c> for still images.
/// 1.1</summary>
   public bool Animated {
      get { return GetAnimated(); }
   }
   /// <summary>Index of the current frame of an animated image.
/// Ranges from 1 to <see cref="Efl.Gfx.ImageAnimationController.GetAnimatedFrameCount"/>. Valid only if <see cref="Efl.Gfx.ImageAnimationController.GetAnimated"/>.</summary>
   public  int AnimatedFrame {
      get { return GetAnimatedFrame(); }
      set { SetAnimatedFrame( value); }
   }
   /// <summary>Get the total number of frames of the image, if animated.
/// Returns -1 if not animated.
/// 1.1</summary>
   public  int AnimatedFrameCount {
      get { return GetAnimatedFrameCount(); }
   }
   /// <summary>Get the kind of looping the image object does.
/// This returns the kind of looping the image object wants to do.
/// 
/// If it returns <see cref="Efl.Gfx.ImageAnimationControllerLoopHint.Loop"/>, you should display frames in a sequence like: 1-&gt;2-&gt;3-&gt;1-&gt;2-&gt;3-&gt;1...
/// 
/// If it returns <see cref="Efl.Gfx.ImageAnimationControllerLoopHint.Pingpong"/>, it is better to display frames in a sequence like: 1-&gt;2-&gt;3-&gt;2-&gt;1-&gt;2-&gt;3-&gt;1...
/// 
/// The default type is <see cref="Efl.Gfx.ImageAnimationControllerLoopHint.Loop"/>.
/// 1.1</summary>
   public Efl.Gfx.ImageAnimationControllerLoopHint AnimatedLoopType {
      get { return GetAnimatedLoopType(); }
   }
   /// <summary>Get the number times the animation of the object loops.
/// This returns loop count of image. The loop count is the number of times the animation will play fully from first to last frame until the animation should stop (at the final frame).
/// 
/// If 0 is returned, then looping should happen indefinitely (no limit to the number of times it loops).
/// 1.1</summary>
   public  int AnimatedLoopCount {
      get { return GetAnimatedLoopCount(); }
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
public class ImageNativeInherit : Efl.Canvas.ImageInternalNativeInherit{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_gfx_image_animated_get_static_delegate = new efl_gfx_image_animated_get_delegate(animated_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_image_animated_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_animated_get_static_delegate)});
      efl_gfx_image_animated_frame_get_static_delegate = new efl_gfx_image_animated_frame_get_delegate(animated_frame_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_image_animated_frame_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_animated_frame_get_static_delegate)});
      efl_gfx_image_animated_frame_set_static_delegate = new efl_gfx_image_animated_frame_set_delegate(animated_frame_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_image_animated_frame_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_animated_frame_set_static_delegate)});
      efl_gfx_image_animated_frame_count_get_static_delegate = new efl_gfx_image_animated_frame_count_get_delegate(animated_frame_count_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_image_animated_frame_count_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_animated_frame_count_get_static_delegate)});
      efl_gfx_image_animated_loop_type_get_static_delegate = new efl_gfx_image_animated_loop_type_get_delegate(animated_loop_type_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_image_animated_loop_type_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_animated_loop_type_get_static_delegate)});
      efl_gfx_image_animated_loop_count_get_static_delegate = new efl_gfx_image_animated_loop_count_get_delegate(animated_loop_count_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_image_animated_loop_count_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_animated_loop_count_get_static_delegate)});
      efl_gfx_image_animated_frame_duration_get_static_delegate = new efl_gfx_image_animated_frame_duration_get_delegate(animated_frame_duration_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_image_animated_frame_duration_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_animated_frame_duration_get_static_delegate)});
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
      return Efl.Canvas.Image.efl_canvas_image_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Canvas.Image.efl_canvas_image_class_get();
   }


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_gfx_image_animated_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_gfx_image_animated_get(System.IntPtr obj);
    private static bool animated_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_image_animated_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Image)wrapper).GetAnimated();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_image_animated_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_image_animated_get_delegate efl_gfx_image_animated_get_static_delegate;


    private delegate  int efl_gfx_image_animated_frame_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  int efl_gfx_image_animated_frame_get(System.IntPtr obj);
    private static  int animated_frame_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_image_animated_frame_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   int _ret_var = default( int);
         try {
            _ret_var = ((Image)wrapper).GetAnimatedFrame();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_image_animated_frame_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_image_animated_frame_get_delegate efl_gfx_image_animated_frame_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_gfx_image_animated_frame_set_delegate(System.IntPtr obj, System.IntPtr pd,    int frame_index);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_gfx_image_animated_frame_set(System.IntPtr obj,    int frame_index);
    private static bool animated_frame_set(System.IntPtr obj, System.IntPtr pd,   int frame_index)
   {
      Eina.Log.Debug("function efl_gfx_image_animated_frame_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((Image)wrapper).SetAnimatedFrame( frame_index);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_gfx_image_animated_frame_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  frame_index);
      }
   }
   private efl_gfx_image_animated_frame_set_delegate efl_gfx_image_animated_frame_set_static_delegate;


    private delegate  int efl_gfx_image_animated_frame_count_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  int efl_gfx_image_animated_frame_count_get(System.IntPtr obj);
    private static  int animated_frame_count_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_image_animated_frame_count_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   int _ret_var = default( int);
         try {
            _ret_var = ((Image)wrapper).GetAnimatedFrameCount();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_image_animated_frame_count_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_image_animated_frame_count_get_delegate efl_gfx_image_animated_frame_count_get_static_delegate;


    private delegate Efl.Gfx.ImageAnimationControllerLoopHint efl_gfx_image_animated_loop_type_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Efl.Gfx.ImageAnimationControllerLoopHint efl_gfx_image_animated_loop_type_get(System.IntPtr obj);
    private static Efl.Gfx.ImageAnimationControllerLoopHint animated_loop_type_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_image_animated_loop_type_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Gfx.ImageAnimationControllerLoopHint _ret_var = default(Efl.Gfx.ImageAnimationControllerLoopHint);
         try {
            _ret_var = ((Image)wrapper).GetAnimatedLoopType();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_image_animated_loop_type_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_image_animated_loop_type_get_delegate efl_gfx_image_animated_loop_type_get_static_delegate;


    private delegate  int efl_gfx_image_animated_loop_count_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  int efl_gfx_image_animated_loop_count_get(System.IntPtr obj);
    private static  int animated_loop_count_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_image_animated_loop_count_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   int _ret_var = default( int);
         try {
            _ret_var = ((Image)wrapper).GetAnimatedLoopCount();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_image_animated_loop_count_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_image_animated_loop_count_get_delegate efl_gfx_image_animated_loop_count_get_static_delegate;


    private delegate double efl_gfx_image_animated_frame_duration_get_delegate(System.IntPtr obj, System.IntPtr pd,    int start_frame,    int frame_num);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern double efl_gfx_image_animated_frame_duration_get(System.IntPtr obj,    int start_frame,    int frame_num);
    private static double animated_frame_duration_get(System.IntPtr obj, System.IntPtr pd,   int start_frame,   int frame_num)
   {
      Eina.Log.Debug("function efl_gfx_image_animated_frame_duration_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      double _ret_var = default(double);
         try {
            _ret_var = ((Image)wrapper).GetAnimatedFrameDuration( start_frame,  frame_num);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_gfx_image_animated_frame_duration_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  start_frame,  frame_num);
      }
   }
   private efl_gfx_image_animated_frame_duration_get_delegate efl_gfx_image_animated_frame_duration_get_static_delegate;


    private delegate Eina.Size2D_StructInternal efl_gfx_image_load_controller_load_size_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Eina.Size2D_StructInternal efl_gfx_image_load_controller_load_size_get(System.IntPtr obj);
    private static Eina.Size2D_StructInternal load_size_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_image_load_controller_load_size_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Size2D _ret_var = default(Eina.Size2D);
         try {
            _ret_var = ((Image)wrapper).GetLoadSize();
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
            ((Image)wrapper).SetLoadSize( _in_size);
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
            _ret_var = ((Image)wrapper).GetLoadDpi();
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
            ((Image)wrapper).SetLoadDpi( dpi);
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
            _ret_var = ((Image)wrapper).GetLoadRegionSupport();
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
            _ret_var = ((Image)wrapper).GetLoadRegion();
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
            ((Image)wrapper).SetLoadRegion( _in_region);
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
            _ret_var = ((Image)wrapper).GetLoadOrientation();
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
            ((Image)wrapper).SetLoadOrientation( enable);
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
            _ret_var = ((Image)wrapper).GetLoadScaleDown();
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
            ((Image)wrapper).SetLoadScaleDown( div);
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
            _ret_var = ((Image)wrapper).GetLoadSkipHeader();
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
            ((Image)wrapper).SetLoadSkipHeader( skip);
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
            ((Image)wrapper).LoadAsyncStart();
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
            ((Image)wrapper).LoadAsyncCancel();
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
