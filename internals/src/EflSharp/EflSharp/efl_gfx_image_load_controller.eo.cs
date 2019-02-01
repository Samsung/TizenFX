#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Gfx { 
/// <summary>Common APIs for all loadable 2D images.</summary>
[ImageLoadControllerConcreteNativeInherit]
public interface ImageLoadController : 
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>Returns the requested load size.</summary>
/// <returns>The image load size.</returns>
Eina.Size2D GetLoadSize();
   /// <summary>Requests the canvas to load the image at the given size.
/// EFL will try to load an image of the requested size but does not guarantee an exact match between the request and the loaded image dimensions.</summary>
/// <param name="size">The image load size.</param>
/// <returns></returns>
 void SetLoadSize( Eina.Size2D size);
   /// <summary>Get the DPI resolution of a loaded image object in the canvas.
/// This function returns the DPI resolution of the given canvas image.</summary>
/// <returns>The DPI resolution.</returns>
double GetLoadDpi();
   /// <summary>Set the DPI resolution of an image object&apos;s source image.
/// This function sets the DPI resolution of a given loaded canvas image. Most useful for the SVG image loader.</summary>
/// <param name="dpi">The DPI resolution.</param>
/// <returns></returns>
 void SetLoadDpi( double dpi);
   /// <summary>Indicates whether the <see cref="Efl.Gfx.ImageLoadController.LoadRegion"/> property is supported for the current file.
/// 1.2</summary>
/// <returns><c>true</c> if region load of the image is supported, <c>false</c> otherwise</returns>
bool GetLoadRegionSupport();
   /// <summary>Retrieve the coordinates of a given image object&apos;s selective (source image) load region.</summary>
/// <returns>A region of the image.</returns>
Eina.Rect GetLoadRegion();
   /// <summary>Inform a given image object to load a selective region of its source image.
/// This function is useful when one is not showing all of an image&apos;s area on its image object.
/// 
/// Note: The image loader for the image format in question has to support selective region loading in order for this function to work.</summary>
/// <param name="region">A region of the image.</param>
/// <returns></returns>
 void SetLoadRegion( Eina.Rect region);
   /// <summary>Defines whether the orientation information in the image file should be honored.
/// The orientation can for instance be set in the EXIF tags of a JPEG image. If this flag is <c>false</c>, then the orientation will be ignored at load time, otherwise the image will be loaded with the proper orientation.
/// 1.1</summary>
/// <returns><c>true</c> means that it should honor the orientation information.</returns>
bool GetLoadOrientation();
   /// <summary>Defines whether the orientation information in the image file should be honored.
/// The orientation can for instance be set in the EXIF tags of a JPEG image. If this flag is <c>false</c>, then the orientation will be ignored at load time, otherwise the image will be loaded with the proper orientation.
/// 1.1</summary>
/// <param name="enable"><c>true</c> means that it should honor the orientation information.</param>
/// <returns></returns>
 void SetLoadOrientation( bool enable);
   /// <summary>The scale down factor is a divider on the original image size.
/// Setting the scale down factor can reduce load time and memory usage at the cost of having a scaled down image in memory.
/// 
/// This function sets the scale down factor of a given canvas image. Most useful for the SVG image loader but also applies to JPEG, PNG and BMP.
/// 
/// Powers of two (2, 4, 8) are best supported (especially with JPEG)</summary>
/// <returns>The scale down dividing factor.</returns>
 int GetLoadScaleDown();
   /// <summary>Requests the image loader to scale down by <c>div</c> times. Call this before starting the actual image load.</summary>
/// <param name="div">The scale down dividing factor.</param>
/// <returns></returns>
 void SetLoadScaleDown(  int div);
   /// <summary>Initial load should skip header check and leave it all to data load
/// If this is true, then future loads of images will defer header loading to a preload stage and/or data load later on rather than at the start when the load begins (e.g. when file is set).</summary>
/// <returns>Will be true if header is to be skipped.</returns>
bool GetLoadSkipHeader();
   /// <summary>Set the skip header state for susbsequent loads of a file.</summary>
/// <param name="skip">Will be true if header is to be skipped.</param>
/// <returns></returns>
 void SetLoadSkipHeader( bool skip);
   /// <summary>Begin preloading an image object&apos;s image data in the background.
/// Once the background task is complete the event <c>load</c>,done will be emitted.</summary>
/// <returns></returns>
 void LoadAsyncStart();
   /// <summary>Cancel preloading an image object&apos;s image data in the background.
/// The object should be left in a state where it has no image data. If cancel is called too late, the image will be kept in memory.</summary>
/// <returns></returns>
 void LoadAsyncCancel();
                                                /// <summary>Called when he image was loaded</summary>
   event EventHandler LoadDoneEvt;
   /// <summary>Called when an error happened during image loading</summary>
   event EventHandler<Efl.Gfx.ImageLoadControllerLoadErrorEvt_Args> LoadErrorEvt;
   /// <summary>The load size of an image.
/// The image will be loaded into memory as if it was the specified size instead of its original size. This can save a lot of memory and is important for scalable types like svg.
/// 
/// By default, the load size is not specified, so it is 0x0.</summary>
   Eina.Size2D LoadSize {
      get ;
      set ;
   }
   /// <summary>Get the DPI resolution of a loaded image object in the canvas.
/// This function returns the DPI resolution of the given canvas image.</summary>
   double LoadDpi {
      get ;
      set ;
   }
   /// <summary>Indicates whether the <see cref="Efl.Gfx.ImageLoadController.LoadRegion"/> property is supported for the current file.
/// 1.2</summary>
   bool LoadRegionSupport {
      get ;
   }
   /// <summary>Retrieve the coordinates of a given image object&apos;s selective (source image) load region.</summary>
   Eina.Rect LoadRegion {
      get ;
      set ;
   }
   /// <summary>Defines whether the orientation information in the image file should be honored.
/// The orientation can for instance be set in the EXIF tags of a JPEG image. If this flag is <c>false</c>, then the orientation will be ignored at load time, otherwise the image will be loaded with the proper orientation.
/// 1.1</summary>
   bool LoadOrientation {
      get ;
      set ;
   }
   /// <summary>The scale down factor is a divider on the original image size.
/// Setting the scale down factor can reduce load time and memory usage at the cost of having a scaled down image in memory.
/// 
/// This function sets the scale down factor of a given canvas image. Most useful for the SVG image loader but also applies to JPEG, PNG and BMP.
/// 
/// Powers of two (2, 4, 8) are best supported (especially with JPEG)</summary>
    int LoadScaleDown {
      get ;
      set ;
   }
   /// <summary>Initial load should skip header check and leave it all to data load
/// If this is true, then future loads of images will defer header loading to a preload stage and/or data load later on rather than at the start when the load begins (e.g. when file is set).</summary>
   bool LoadSkipHeader {
      get ;
      set ;
   }
}
///<summary>Event argument wrapper for event <see cref="Efl.Gfx.ImageLoadController.LoadErrorEvt"/>.</summary>
public class ImageLoadControllerLoadErrorEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public Efl.Gfx.ImageLoadError arg { get; set; }
}
/// <summary>Common APIs for all loadable 2D images.</summary>
sealed public class ImageLoadControllerConcrete : 

ImageLoadController
   
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (ImageLoadControllerConcrete))
            return Efl.Gfx.ImageLoadControllerConcreteNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   private EventHandlerList eventHandlers = new EventHandlerList();
   private  System.IntPtr handle;
   public Dictionary<String, IntPtr> cached_strings = new Dictionary<String, IntPtr>();
   public Dictionary<String, IntPtr> cached_stringshares = new Dictionary<String, IntPtr>();
   ///<summary>Pointer to the native instance.</summary>
   public System.IntPtr NativeHandle {
      get { return handle; }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] internal static extern System.IntPtr
      efl_gfx_image_load_controller_interface_get();
   ///<summary>Constructs an instance from a native pointer.</summary>
   public ImageLoadControllerConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~ImageLoadControllerConcrete()
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
   Efl.Eo.Globals.free_dict_values(cached_strings);
   Efl.Eo.Globals.free_stringshare_values(cached_stringshares);
      Dispose(true);
      GC.SuppressFinalize(this);
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public static ImageLoadControllerConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new ImageLoadControllerConcrete(obj.NativeHandle);
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
   private bool add_cpp_event_handler(string key, Efl.EventCb evt_delegate) {
      int event_count = 0;
      if (!event_cb_count.TryGetValue(key, out event_count))
         event_cb_count[key] = event_count;
      if (event_count == 0) {
         IntPtr desc = Efl.EventDescription.GetNative(key);
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
         IntPtr desc = Efl.EventDescription.GetNative(key);
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

    void register_event_proxies()
   {
      evt_LoadDoneEvt_delegate = new Efl.EventCb(on_LoadDoneEvt_NativeCallback);
      evt_LoadErrorEvt_delegate = new Efl.EventCb(on_LoadErrorEvt_NativeCallback);
   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern Eina.Size2D_StructInternal efl_gfx_image_load_controller_load_size_get(System.IntPtr obj);
   /// <summary>Returns the requested load size.</summary>
   /// <returns>The image load size.</returns>
   public Eina.Size2D GetLoadSize() {
       var _ret_var = efl_gfx_image_load_controller_load_size_get(Efl.Gfx.ImageLoadControllerConcrete.efl_gfx_image_load_controller_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return Eina.Size2D_StructConversion.ToManaged(_ret_var);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_image_load_controller_load_size_set(System.IntPtr obj,   Eina.Size2D_StructInternal size);
   /// <summary>Requests the canvas to load the image at the given size.
   /// EFL will try to load an image of the requested size but does not guarantee an exact match between the request and the loaded image dimensions.</summary>
   /// <param name="size">The image load size.</param>
   /// <returns></returns>
   public  void SetLoadSize( Eina.Size2D size) {
       var _in_size = Eina.Size2D_StructConversion.ToInternal(size);
                  efl_gfx_image_load_controller_load_size_set(Efl.Gfx.ImageLoadControllerConcrete.efl_gfx_image_load_controller_interface_get(),  _in_size);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern double efl_gfx_image_load_controller_load_dpi_get(System.IntPtr obj);
   /// <summary>Get the DPI resolution of a loaded image object in the canvas.
   /// This function returns the DPI resolution of the given canvas image.</summary>
   /// <returns>The DPI resolution.</returns>
   public double GetLoadDpi() {
       var _ret_var = efl_gfx_image_load_controller_load_dpi_get(Efl.Gfx.ImageLoadControllerConcrete.efl_gfx_image_load_controller_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_image_load_controller_load_dpi_set(System.IntPtr obj,   double dpi);
   /// <summary>Set the DPI resolution of an image object&apos;s source image.
   /// This function sets the DPI resolution of a given loaded canvas image. Most useful for the SVG image loader.</summary>
   /// <param name="dpi">The DPI resolution.</param>
   /// <returns></returns>
   public  void SetLoadDpi( double dpi) {
                         efl_gfx_image_load_controller_load_dpi_set(Efl.Gfx.ImageLoadControllerConcrete.efl_gfx_image_load_controller_interface_get(),  dpi);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_gfx_image_load_controller_load_region_support_get(System.IntPtr obj);
   /// <summary>Indicates whether the <see cref="Efl.Gfx.ImageLoadController.LoadRegion"/> property is supported for the current file.
   /// 1.2</summary>
   /// <returns><c>true</c> if region load of the image is supported, <c>false</c> otherwise</returns>
   public bool GetLoadRegionSupport() {
       var _ret_var = efl_gfx_image_load_controller_load_region_support_get(Efl.Gfx.ImageLoadControllerConcrete.efl_gfx_image_load_controller_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern Eina.Rect_StructInternal efl_gfx_image_load_controller_load_region_get(System.IntPtr obj);
   /// <summary>Retrieve the coordinates of a given image object&apos;s selective (source image) load region.</summary>
   /// <returns>A region of the image.</returns>
   public Eina.Rect GetLoadRegion() {
       var _ret_var = efl_gfx_image_load_controller_load_region_get(Efl.Gfx.ImageLoadControllerConcrete.efl_gfx_image_load_controller_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return Eina.Rect_StructConversion.ToManaged(_ret_var);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_image_load_controller_load_region_set(System.IntPtr obj,   Eina.Rect_StructInternal region);
   /// <summary>Inform a given image object to load a selective region of its source image.
   /// This function is useful when one is not showing all of an image&apos;s area on its image object.
   /// 
   /// Note: The image loader for the image format in question has to support selective region loading in order for this function to work.</summary>
   /// <param name="region">A region of the image.</param>
   /// <returns></returns>
   public  void SetLoadRegion( Eina.Rect region) {
       var _in_region = Eina.Rect_StructConversion.ToInternal(region);
                  efl_gfx_image_load_controller_load_region_set(Efl.Gfx.ImageLoadControllerConcrete.efl_gfx_image_load_controller_interface_get(),  _in_region);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_gfx_image_load_controller_load_orientation_get(System.IntPtr obj);
   /// <summary>Defines whether the orientation information in the image file should be honored.
   /// The orientation can for instance be set in the EXIF tags of a JPEG image. If this flag is <c>false</c>, then the orientation will be ignored at load time, otherwise the image will be loaded with the proper orientation.
   /// 1.1</summary>
   /// <returns><c>true</c> means that it should honor the orientation information.</returns>
   public bool GetLoadOrientation() {
       var _ret_var = efl_gfx_image_load_controller_load_orientation_get(Efl.Gfx.ImageLoadControllerConcrete.efl_gfx_image_load_controller_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_image_load_controller_load_orientation_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool enable);
   /// <summary>Defines whether the orientation information in the image file should be honored.
   /// The orientation can for instance be set in the EXIF tags of a JPEG image. If this flag is <c>false</c>, then the orientation will be ignored at load time, otherwise the image will be loaded with the proper orientation.
   /// 1.1</summary>
   /// <param name="enable"><c>true</c> means that it should honor the orientation information.</param>
   /// <returns></returns>
   public  void SetLoadOrientation( bool enable) {
                         efl_gfx_image_load_controller_load_orientation_set(Efl.Gfx.ImageLoadControllerConcrete.efl_gfx_image_load_controller_interface_get(),  enable);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  int efl_gfx_image_load_controller_load_scale_down_get(System.IntPtr obj);
   /// <summary>The scale down factor is a divider on the original image size.
   /// Setting the scale down factor can reduce load time and memory usage at the cost of having a scaled down image in memory.
   /// 
   /// This function sets the scale down factor of a given canvas image. Most useful for the SVG image loader but also applies to JPEG, PNG and BMP.
   /// 
   /// Powers of two (2, 4, 8) are best supported (especially with JPEG)</summary>
   /// <returns>The scale down dividing factor.</returns>
   public  int GetLoadScaleDown() {
       var _ret_var = efl_gfx_image_load_controller_load_scale_down_get(Efl.Gfx.ImageLoadControllerConcrete.efl_gfx_image_load_controller_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_image_load_controller_load_scale_down_set(System.IntPtr obj,    int div);
   /// <summary>Requests the image loader to scale down by <c>div</c> times. Call this before starting the actual image load.</summary>
   /// <param name="div">The scale down dividing factor.</param>
   /// <returns></returns>
   public  void SetLoadScaleDown(  int div) {
                         efl_gfx_image_load_controller_load_scale_down_set(Efl.Gfx.ImageLoadControllerConcrete.efl_gfx_image_load_controller_interface_get(),  div);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_gfx_image_load_controller_load_skip_header_get(System.IntPtr obj);
   /// <summary>Initial load should skip header check and leave it all to data load
   /// If this is true, then future loads of images will defer header loading to a preload stage and/or data load later on rather than at the start when the load begins (e.g. when file is set).</summary>
   /// <returns>Will be true if header is to be skipped.</returns>
   public bool GetLoadSkipHeader() {
       var _ret_var = efl_gfx_image_load_controller_load_skip_header_get(Efl.Gfx.ImageLoadControllerConcrete.efl_gfx_image_load_controller_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_image_load_controller_load_skip_header_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool skip);
   /// <summary>Set the skip header state for susbsequent loads of a file.</summary>
   /// <param name="skip">Will be true if header is to be skipped.</param>
   /// <returns></returns>
   public  void SetLoadSkipHeader( bool skip) {
                         efl_gfx_image_load_controller_load_skip_header_set(Efl.Gfx.ImageLoadControllerConcrete.efl_gfx_image_load_controller_interface_get(),  skip);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_image_load_controller_load_async_start(System.IntPtr obj);
   /// <summary>Begin preloading an image object&apos;s image data in the background.
   /// Once the background task is complete the event <c>load</c>,done will be emitted.</summary>
   /// <returns></returns>
   public  void LoadAsyncStart() {
       efl_gfx_image_load_controller_load_async_start(Efl.Gfx.ImageLoadControllerConcrete.efl_gfx_image_load_controller_interface_get());
      Eina.Error.RaiseIfUnhandledException();
       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_image_load_controller_load_async_cancel(System.IntPtr obj);
   /// <summary>Cancel preloading an image object&apos;s image data in the background.
   /// The object should be left in a state where it has no image data. If cancel is called too late, the image will be kept in memory.</summary>
   /// <returns></returns>
   public  void LoadAsyncCancel() {
       efl_gfx_image_load_controller_load_async_cancel(Efl.Gfx.ImageLoadControllerConcrete.efl_gfx_image_load_controller_interface_get());
      Eina.Error.RaiseIfUnhandledException();
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
public class ImageLoadControllerConcreteNativeInherit : Efl.Eo.NativeClass{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
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
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Gfx.ImageLoadControllerConcrete.efl_gfx_image_load_controller_interface_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.Gfx.ImageLoadControllerConcrete.efl_gfx_image_load_controller_interface_get();
   }


    private delegate Eina.Size2D_StructInternal efl_gfx_image_load_controller_load_size_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Eina.Size2D_StructInternal efl_gfx_image_load_controller_load_size_get(System.IntPtr obj);
    private static Eina.Size2D_StructInternal load_size_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_image_load_controller_load_size_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Size2D _ret_var = default(Eina.Size2D);
         try {
            _ret_var = ((ImageLoadController)wrapper).GetLoadSize();
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
            ((ImageLoadController)wrapper).SetLoadSize( _in_size);
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
            _ret_var = ((ImageLoadController)wrapper).GetLoadDpi();
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
            ((ImageLoadController)wrapper).SetLoadDpi( dpi);
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
            _ret_var = ((ImageLoadController)wrapper).GetLoadRegionSupport();
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
            _ret_var = ((ImageLoadController)wrapper).GetLoadRegion();
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
            ((ImageLoadController)wrapper).SetLoadRegion( _in_region);
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
            _ret_var = ((ImageLoadController)wrapper).GetLoadOrientation();
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
            ((ImageLoadController)wrapper).SetLoadOrientation( enable);
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
            _ret_var = ((ImageLoadController)wrapper).GetLoadScaleDown();
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
            ((ImageLoadController)wrapper).SetLoadScaleDown( div);
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
            _ret_var = ((ImageLoadController)wrapper).GetLoadSkipHeader();
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
            ((ImageLoadController)wrapper).SetLoadSkipHeader( skip);
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
            ((ImageLoadController)wrapper).LoadAsyncStart();
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
            ((ImageLoadController)wrapper).LoadAsyncCancel();
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
