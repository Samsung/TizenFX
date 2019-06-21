#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Gfx {

/// <summary>Common APIs for all loadable 2D images.</summary>
[Efl.Gfx.IImageLoadControllerConcrete.NativeMethods]
public interface IImageLoadController : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Returns the requested load size.</summary>
/// <returns>The image load size.</returns>
Eina.Size2D GetLoadSize();
    /// <summary>Requests the canvas to load the image at the given size.
/// EFL will try to load an image of the requested size but does not guarantee an exact match between the request and the loaded image dimensions.</summary>
/// <param name="size">The image load size.</param>
void SetLoadSize(Eina.Size2D size);
    /// <summary>Get the DPI resolution of a loaded image object in the canvas.
/// This function returns the DPI resolution of the given canvas image.</summary>
/// <returns>The DPI resolution.</returns>
double GetLoadDpi();
    /// <summary>Set the DPI resolution of an image object&apos;s source image.
/// This function sets the DPI resolution of a given loaded canvas image. Most useful for the SVG image loader.</summary>
/// <param name="dpi">The DPI resolution.</param>
void SetLoadDpi(double dpi);
    /// <summary>Indicates whether the <see cref="Efl.Gfx.IImageLoadController.LoadRegion"/> property is supported for the current file.</summary>
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
void SetLoadRegion(Eina.Rect region);
    /// <summary>Defines whether the orientation information in the image file should be honored.
/// The orientation can for instance be set in the EXIF tags of a JPEG image. If this flag is <c>false</c>, then the orientation will be ignored at load time, otherwise the image will be loaded with the proper orientation.</summary>
/// <returns><c>true</c> means that it should honor the orientation information.</returns>
bool GetLoadOrientation();
    /// <summary>Defines whether the orientation information in the image file should be honored.
/// The orientation can for instance be set in the EXIF tags of a JPEG image. If this flag is <c>false</c>, then the orientation will be ignored at load time, otherwise the image will be loaded with the proper orientation.</summary>
/// <param name="enable"><c>true</c> means that it should honor the orientation information.</param>
void SetLoadOrientation(bool enable);
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
void SetLoadScaleDown(int div);
    /// <summary>Initial load should skip header check and leave it all to data load
/// If this is true, then future loads of images will defer header loading to a preload stage and/or data load later on rather than at the start when the load begins (e.g. when file is set).</summary>
/// <returns>Will be true if header is to be skipped.</returns>
bool GetLoadSkipHeader();
    /// <summary>Set the skip header state for susbsequent loads of a file.</summary>
/// <param name="skip">Will be true if header is to be skipped.</param>
void SetLoadSkipHeader(bool skip);
    /// <summary>Begin preloading an image object&apos;s image data in the background.
/// Once the background task is complete the event <c>load</c>,done will be emitted.</summary>
void LoadAsyncStart();
    /// <summary>Cancel preloading an image object&apos;s image data in the background.
/// The object should be left in a state where it has no image data. If cancel is called too late, the image will be kept in memory.</summary>
void LoadAsyncCancel();
                                                                /// <summary>Called when he image was loaded</summary>
    event EventHandler LoadDoneEvt;
    /// <summary>Called when an error happened during image loading</summary>
    event EventHandler<Efl.Gfx.IImageLoadControllerLoadErrorEvt_Args> LoadErrorEvt;
    /// <summary>The load size of an image.
    /// The image will be loaded into memory as if it was the specified size instead of its original size. This can save a lot of memory and is important for scalable types like svg.
    /// 
    /// By default, the load size is not specified, so it is 0x0.</summary>
    /// <value>The image load size.</value>
    Eina.Size2D LoadSize {
        get ;
        set ;
    }
    /// <summary>Get the DPI resolution of a loaded image object in the canvas.
    /// This function returns the DPI resolution of the given canvas image.</summary>
    /// <value>The DPI resolution.</value>
    double LoadDpi {
        get ;
        set ;
    }
    /// <summary>Indicates whether the <see cref="Efl.Gfx.IImageLoadController.LoadRegion"/> property is supported for the current file.</summary>
    /// <value><c>true</c> if region load of the image is supported, <c>false</c> otherwise</value>
    bool LoadRegionSupport {
        get ;
    }
    /// <summary>Retrieve the coordinates of a given image object&apos;s selective (source image) load region.</summary>
    /// <value>A region of the image.</value>
    Eina.Rect LoadRegion {
        get ;
        set ;
    }
    /// <summary>Defines whether the orientation information in the image file should be honored.
    /// The orientation can for instance be set in the EXIF tags of a JPEG image. If this flag is <c>false</c>, then the orientation will be ignored at load time, otherwise the image will be loaded with the proper orientation.</summary>
    /// <value><c>true</c> means that it should honor the orientation information.</value>
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
    /// <value>The scale down dividing factor.</value>
    int LoadScaleDown {
        get ;
        set ;
    }
    /// <summary>Initial load should skip header check and leave it all to data load
    /// If this is true, then future loads of images will defer header loading to a preload stage and/or data load later on rather than at the start when the load begins (e.g. when file is set).</summary>
    /// <value>Will be true if header is to be skipped.</value>
    bool LoadSkipHeader {
        get ;
        set ;
    }
}
///<summary>Event argument wrapper for event <see cref="Efl.Gfx.IImageLoadController.LoadErrorEvt"/>.</summary>
public class IImageLoadControllerLoadErrorEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Eina.Error arg { get; set; }
}
/// <summary>Common APIs for all loadable 2D images.</summary>
sealed public class IImageLoadControllerConcrete :
    Efl.Eo.EoWrapper
    , IImageLoadController
    
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(IImageLoadControllerConcrete))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] internal static extern System.IntPtr
        efl_gfx_image_load_controller_interface_get();
    /// <summary>Initializes a new instance of the <see cref="IImageLoadController"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    private IImageLoadControllerConcrete(System.IntPtr raw) : base(raw)
    {
    }

    /// <summary>Called when he image was loaded</summary>
    public event EventHandler LoadDoneEvt
    {
        add
        {
            lock (eventLock)
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

                string key = "_EFL_GFX_IMAGE_LOAD_CONTROLLER_EVENT_LOAD_DONE";
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_GFX_IMAGE_LOAD_CONTROLLER_EVENT_LOAD_DONE";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    ///<summary>Method to raise event LoadDoneEvt.</summary>
    public void OnLoadDoneEvt(EventArgs e)
    {
        var key = "_EFL_GFX_IMAGE_LOAD_CONTROLLER_EVENT_LOAD_DONE";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when an error happened during image loading</summary>
    public event EventHandler<Efl.Gfx.IImageLoadControllerLoadErrorEvt_Args> LoadErrorEvt
    {
        add
        {
            lock (eventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        Efl.Gfx.IImageLoadControllerLoadErrorEvt_Args args = new Efl.Gfx.IImageLoadControllerLoadErrorEvt_Args();
                        args.arg = (Eina.Error)Marshal.PtrToStructure(evt.Info, typeof(Eina.Error));
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

                string key = "_EFL_GFX_IMAGE_LOAD_CONTROLLER_EVENT_LOAD_ERROR";
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_GFX_IMAGE_LOAD_CONTROLLER_EVENT_LOAD_ERROR";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    ///<summary>Method to raise event LoadErrorEvt.</summary>
    public void OnLoadErrorEvt(Efl.Gfx.IImageLoadControllerLoadErrorEvt_Args e)
    {
        var key = "_EFL_GFX_IMAGE_LOAD_CONTROLLER_EVENT_LOAD_ERROR";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = Eina.PrimitiveConversion.ManagedToPointerAlloc((int)e.arg);
        try
        {
            Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Marshal.FreeHGlobal(info);
        }
    }
    /// <summary>Returns the requested load size.</summary>
    /// <returns>The image load size.</returns>
    public Eina.Size2D GetLoadSize() {
         var _ret_var = Efl.Gfx.IImageLoadControllerConcrete.NativeMethods.efl_gfx_image_load_controller_load_size_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Requests the canvas to load the image at the given size.
    /// EFL will try to load an image of the requested size but does not guarantee an exact match between the request and the loaded image dimensions.</summary>
    /// <param name="size">The image load size.</param>
    public void SetLoadSize(Eina.Size2D size) {
         Eina.Size2D.NativeStruct _in_size = size;
                        Efl.Gfx.IImageLoadControllerConcrete.NativeMethods.efl_gfx_image_load_controller_load_size_set_ptr.Value.Delegate(this.NativeHandle,_in_size);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get the DPI resolution of a loaded image object in the canvas.
    /// This function returns the DPI resolution of the given canvas image.</summary>
    /// <returns>The DPI resolution.</returns>
    public double GetLoadDpi() {
         var _ret_var = Efl.Gfx.IImageLoadControllerConcrete.NativeMethods.efl_gfx_image_load_controller_load_dpi_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the DPI resolution of an image object&apos;s source image.
    /// This function sets the DPI resolution of a given loaded canvas image. Most useful for the SVG image loader.</summary>
    /// <param name="dpi">The DPI resolution.</param>
    public void SetLoadDpi(double dpi) {
                                 Efl.Gfx.IImageLoadControllerConcrete.NativeMethods.efl_gfx_image_load_controller_load_dpi_set_ptr.Value.Delegate(this.NativeHandle,dpi);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Indicates whether the <see cref="Efl.Gfx.IImageLoadController.LoadRegion"/> property is supported for the current file.</summary>
    /// <returns><c>true</c> if region load of the image is supported, <c>false</c> otherwise</returns>
    public bool GetLoadRegionSupport() {
         var _ret_var = Efl.Gfx.IImageLoadControllerConcrete.NativeMethods.efl_gfx_image_load_controller_load_region_support_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Retrieve the coordinates of a given image object&apos;s selective (source image) load region.</summary>
    /// <returns>A region of the image.</returns>
    public Eina.Rect GetLoadRegion() {
         var _ret_var = Efl.Gfx.IImageLoadControllerConcrete.NativeMethods.efl_gfx_image_load_controller_load_region_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Inform a given image object to load a selective region of its source image.
    /// This function is useful when one is not showing all of an image&apos;s area on its image object.
    /// 
    /// Note: The image loader for the image format in question has to support selective region loading in order for this function to work.</summary>
    /// <param name="region">A region of the image.</param>
    public void SetLoadRegion(Eina.Rect region) {
         Eina.Rect.NativeStruct _in_region = region;
                        Efl.Gfx.IImageLoadControllerConcrete.NativeMethods.efl_gfx_image_load_controller_load_region_set_ptr.Value.Delegate(this.NativeHandle,_in_region);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Defines whether the orientation information in the image file should be honored.
    /// The orientation can for instance be set in the EXIF tags of a JPEG image. If this flag is <c>false</c>, then the orientation will be ignored at load time, otherwise the image will be loaded with the proper orientation.</summary>
    /// <returns><c>true</c> means that it should honor the orientation information.</returns>
    public bool GetLoadOrientation() {
         var _ret_var = Efl.Gfx.IImageLoadControllerConcrete.NativeMethods.efl_gfx_image_load_controller_load_orientation_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Defines whether the orientation information in the image file should be honored.
    /// The orientation can for instance be set in the EXIF tags of a JPEG image. If this flag is <c>false</c>, then the orientation will be ignored at load time, otherwise the image will be loaded with the proper orientation.</summary>
    /// <param name="enable"><c>true</c> means that it should honor the orientation information.</param>
    public void SetLoadOrientation(bool enable) {
                                 Efl.Gfx.IImageLoadControllerConcrete.NativeMethods.efl_gfx_image_load_controller_load_orientation_set_ptr.Value.Delegate(this.NativeHandle,enable);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The scale down factor is a divider on the original image size.
    /// Setting the scale down factor can reduce load time and memory usage at the cost of having a scaled down image in memory.
    /// 
    /// This function sets the scale down factor of a given canvas image. Most useful for the SVG image loader but also applies to JPEG, PNG and BMP.
    /// 
    /// Powers of two (2, 4, 8) are best supported (especially with JPEG)</summary>
    /// <returns>The scale down dividing factor.</returns>
    public int GetLoadScaleDown() {
         var _ret_var = Efl.Gfx.IImageLoadControllerConcrete.NativeMethods.efl_gfx_image_load_controller_load_scale_down_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Requests the image loader to scale down by <c>div</c> times. Call this before starting the actual image load.</summary>
    /// <param name="div">The scale down dividing factor.</param>
    public void SetLoadScaleDown(int div) {
                                 Efl.Gfx.IImageLoadControllerConcrete.NativeMethods.efl_gfx_image_load_controller_load_scale_down_set_ptr.Value.Delegate(this.NativeHandle,div);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Initial load should skip header check and leave it all to data load
    /// If this is true, then future loads of images will defer header loading to a preload stage and/or data load later on rather than at the start when the load begins (e.g. when file is set).</summary>
    /// <returns>Will be true if header is to be skipped.</returns>
    public bool GetLoadSkipHeader() {
         var _ret_var = Efl.Gfx.IImageLoadControllerConcrete.NativeMethods.efl_gfx_image_load_controller_load_skip_header_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the skip header state for susbsequent loads of a file.</summary>
    /// <param name="skip">Will be true if header is to be skipped.</param>
    public void SetLoadSkipHeader(bool skip) {
                                 Efl.Gfx.IImageLoadControllerConcrete.NativeMethods.efl_gfx_image_load_controller_load_skip_header_set_ptr.Value.Delegate(this.NativeHandle,skip);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Begin preloading an image object&apos;s image data in the background.
    /// Once the background task is complete the event <c>load</c>,done will be emitted.</summary>
    public void LoadAsyncStart() {
         Efl.Gfx.IImageLoadControllerConcrete.NativeMethods.efl_gfx_image_load_controller_load_async_start_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Cancel preloading an image object&apos;s image data in the background.
    /// The object should be left in a state where it has no image data. If cancel is called too late, the image will be kept in memory.</summary>
    public void LoadAsyncCancel() {
         Efl.Gfx.IImageLoadControllerConcrete.NativeMethods.efl_gfx_image_load_controller_load_async_cancel_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>The load size of an image.
    /// The image will be loaded into memory as if it was the specified size instead of its original size. This can save a lot of memory and is important for scalable types like svg.
    /// 
    /// By default, the load size is not specified, so it is 0x0.</summary>
    /// <value>The image load size.</value>
    public Eina.Size2D LoadSize {
        get { return GetLoadSize(); }
        set { SetLoadSize(value); }
    }
    /// <summary>Get the DPI resolution of a loaded image object in the canvas.
    /// This function returns the DPI resolution of the given canvas image.</summary>
    /// <value>The DPI resolution.</value>
    public double LoadDpi {
        get { return GetLoadDpi(); }
        set { SetLoadDpi(value); }
    }
    /// <summary>Indicates whether the <see cref="Efl.Gfx.IImageLoadController.LoadRegion"/> property is supported for the current file.</summary>
    /// <value><c>true</c> if region load of the image is supported, <c>false</c> otherwise</value>
    public bool LoadRegionSupport {
        get { return GetLoadRegionSupport(); }
    }
    /// <summary>Retrieve the coordinates of a given image object&apos;s selective (source image) load region.</summary>
    /// <value>A region of the image.</value>
    public Eina.Rect LoadRegion {
        get { return GetLoadRegion(); }
        set { SetLoadRegion(value); }
    }
    /// <summary>Defines whether the orientation information in the image file should be honored.
    /// The orientation can for instance be set in the EXIF tags of a JPEG image. If this flag is <c>false</c>, then the orientation will be ignored at load time, otherwise the image will be loaded with the proper orientation.</summary>
    /// <value><c>true</c> means that it should honor the orientation information.</value>
    public bool LoadOrientation {
        get { return GetLoadOrientation(); }
        set { SetLoadOrientation(value); }
    }
    /// <summary>The scale down factor is a divider on the original image size.
    /// Setting the scale down factor can reduce load time and memory usage at the cost of having a scaled down image in memory.
    /// 
    /// This function sets the scale down factor of a given canvas image. Most useful for the SVG image loader but also applies to JPEG, PNG and BMP.
    /// 
    /// Powers of two (2, 4, 8) are best supported (especially with JPEG)</summary>
    /// <value>The scale down dividing factor.</value>
    public int LoadScaleDown {
        get { return GetLoadScaleDown(); }
        set { SetLoadScaleDown(value); }
    }
    /// <summary>Initial load should skip header check and leave it all to data load
    /// If this is true, then future loads of images will defer header loading to a preload stage and/or data load later on rather than at the start when the load begins (e.g. when file is set).</summary>
    /// <value>Will be true if header is to be skipped.</value>
    public bool LoadSkipHeader {
        get { return GetLoadSkipHeader(); }
        set { SetLoadSkipHeader(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Gfx.IImageLoadControllerConcrete.efl_gfx_image_load_controller_interface_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public class NativeMethods  : Efl.Eo.NativeClass
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Efl);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_gfx_image_load_controller_load_size_get_static_delegate == null)
            {
                efl_gfx_image_load_controller_load_size_get_static_delegate = new efl_gfx_image_load_controller_load_size_get_delegate(load_size_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetLoadSize") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_load_controller_load_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_size_get_static_delegate) });
            }

            if (efl_gfx_image_load_controller_load_size_set_static_delegate == null)
            {
                efl_gfx_image_load_controller_load_size_set_static_delegate = new efl_gfx_image_load_controller_load_size_set_delegate(load_size_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetLoadSize") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_load_controller_load_size_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_size_set_static_delegate) });
            }

            if (efl_gfx_image_load_controller_load_dpi_get_static_delegate == null)
            {
                efl_gfx_image_load_controller_load_dpi_get_static_delegate = new efl_gfx_image_load_controller_load_dpi_get_delegate(load_dpi_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetLoadDpi") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_load_controller_load_dpi_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_dpi_get_static_delegate) });
            }

            if (efl_gfx_image_load_controller_load_dpi_set_static_delegate == null)
            {
                efl_gfx_image_load_controller_load_dpi_set_static_delegate = new efl_gfx_image_load_controller_load_dpi_set_delegate(load_dpi_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetLoadDpi") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_load_controller_load_dpi_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_dpi_set_static_delegate) });
            }

            if (efl_gfx_image_load_controller_load_region_support_get_static_delegate == null)
            {
                efl_gfx_image_load_controller_load_region_support_get_static_delegate = new efl_gfx_image_load_controller_load_region_support_get_delegate(load_region_support_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetLoadRegionSupport") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_load_controller_load_region_support_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_region_support_get_static_delegate) });
            }

            if (efl_gfx_image_load_controller_load_region_get_static_delegate == null)
            {
                efl_gfx_image_load_controller_load_region_get_static_delegate = new efl_gfx_image_load_controller_load_region_get_delegate(load_region_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetLoadRegion") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_load_controller_load_region_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_region_get_static_delegate) });
            }

            if (efl_gfx_image_load_controller_load_region_set_static_delegate == null)
            {
                efl_gfx_image_load_controller_load_region_set_static_delegate = new efl_gfx_image_load_controller_load_region_set_delegate(load_region_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetLoadRegion") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_load_controller_load_region_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_region_set_static_delegate) });
            }

            if (efl_gfx_image_load_controller_load_orientation_get_static_delegate == null)
            {
                efl_gfx_image_load_controller_load_orientation_get_static_delegate = new efl_gfx_image_load_controller_load_orientation_get_delegate(load_orientation_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetLoadOrientation") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_load_controller_load_orientation_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_orientation_get_static_delegate) });
            }

            if (efl_gfx_image_load_controller_load_orientation_set_static_delegate == null)
            {
                efl_gfx_image_load_controller_load_orientation_set_static_delegate = new efl_gfx_image_load_controller_load_orientation_set_delegate(load_orientation_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetLoadOrientation") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_load_controller_load_orientation_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_orientation_set_static_delegate) });
            }

            if (efl_gfx_image_load_controller_load_scale_down_get_static_delegate == null)
            {
                efl_gfx_image_load_controller_load_scale_down_get_static_delegate = new efl_gfx_image_load_controller_load_scale_down_get_delegate(load_scale_down_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetLoadScaleDown") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_load_controller_load_scale_down_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_scale_down_get_static_delegate) });
            }

            if (efl_gfx_image_load_controller_load_scale_down_set_static_delegate == null)
            {
                efl_gfx_image_load_controller_load_scale_down_set_static_delegate = new efl_gfx_image_load_controller_load_scale_down_set_delegate(load_scale_down_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetLoadScaleDown") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_load_controller_load_scale_down_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_scale_down_set_static_delegate) });
            }

            if (efl_gfx_image_load_controller_load_skip_header_get_static_delegate == null)
            {
                efl_gfx_image_load_controller_load_skip_header_get_static_delegate = new efl_gfx_image_load_controller_load_skip_header_get_delegate(load_skip_header_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetLoadSkipHeader") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_load_controller_load_skip_header_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_skip_header_get_static_delegate) });
            }

            if (efl_gfx_image_load_controller_load_skip_header_set_static_delegate == null)
            {
                efl_gfx_image_load_controller_load_skip_header_set_static_delegate = new efl_gfx_image_load_controller_load_skip_header_set_delegate(load_skip_header_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetLoadSkipHeader") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_load_controller_load_skip_header_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_skip_header_set_static_delegate) });
            }

            if (efl_gfx_image_load_controller_load_async_start_static_delegate == null)
            {
                efl_gfx_image_load_controller_load_async_start_static_delegate = new efl_gfx_image_load_controller_load_async_start_delegate(load_async_start);
            }

            if (methods.FirstOrDefault(m => m.Name == "LoadAsyncStart") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_load_controller_load_async_start"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_async_start_static_delegate) });
            }

            if (efl_gfx_image_load_controller_load_async_cancel_static_delegate == null)
            {
                efl_gfx_image_load_controller_load_async_cancel_static_delegate = new efl_gfx_image_load_controller_load_async_cancel_delegate(load_async_cancel);
            }

            if (methods.FirstOrDefault(m => m.Name == "LoadAsyncCancel") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_load_controller_load_async_cancel"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_async_cancel_static_delegate) });
            }

            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Gfx.IImageLoadControllerConcrete.efl_gfx_image_load_controller_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate Eina.Size2D.NativeStruct efl_gfx_image_load_controller_load_size_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Size2D.NativeStruct efl_gfx_image_load_controller_load_size_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_size_get_api_delegate> efl_gfx_image_load_controller_load_size_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_size_get_api_delegate>(Module, "efl_gfx_image_load_controller_load_size_get");

        private static Eina.Size2D.NativeStruct load_size_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_image_load_controller_load_size_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Size2D _ret_var = default(Eina.Size2D);
                try
                {
                    _ret_var = ((IImageLoadController)ws.Target).GetLoadSize();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        return _ret_var;

            }
            else
            {
                return efl_gfx_image_load_controller_load_size_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_image_load_controller_load_size_get_delegate efl_gfx_image_load_controller_load_size_get_static_delegate;

        
        private delegate void efl_gfx_image_load_controller_load_size_set_delegate(System.IntPtr obj, System.IntPtr pd,  Eina.Size2D.NativeStruct size);

        
        public delegate void efl_gfx_image_load_controller_load_size_set_api_delegate(System.IntPtr obj,  Eina.Size2D.NativeStruct size);

        public static Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_size_set_api_delegate> efl_gfx_image_load_controller_load_size_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_size_set_api_delegate>(Module, "efl_gfx_image_load_controller_load_size_set");

        private static void load_size_set(System.IntPtr obj, System.IntPtr pd, Eina.Size2D.NativeStruct size)
        {
            Eina.Log.Debug("function efl_gfx_image_load_controller_load_size_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        Eina.Size2D _in_size = size;
                            
                try
                {
                    ((IImageLoadController)ws.Target).SetLoadSize(_in_size);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gfx_image_load_controller_load_size_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), size);
            }
        }

        private static efl_gfx_image_load_controller_load_size_set_delegate efl_gfx_image_load_controller_load_size_set_static_delegate;

        
        private delegate double efl_gfx_image_load_controller_load_dpi_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate double efl_gfx_image_load_controller_load_dpi_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_dpi_get_api_delegate> efl_gfx_image_load_controller_load_dpi_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_dpi_get_api_delegate>(Module, "efl_gfx_image_load_controller_load_dpi_get");

        private static double load_dpi_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_image_load_controller_load_dpi_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            double _ret_var = default(double);
                try
                {
                    _ret_var = ((IImageLoadController)ws.Target).GetLoadDpi();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        return _ret_var;

            }
            else
            {
                return efl_gfx_image_load_controller_load_dpi_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_image_load_controller_load_dpi_get_delegate efl_gfx_image_load_controller_load_dpi_get_static_delegate;

        
        private delegate void efl_gfx_image_load_controller_load_dpi_set_delegate(System.IntPtr obj, System.IntPtr pd,  double dpi);

        
        public delegate void efl_gfx_image_load_controller_load_dpi_set_api_delegate(System.IntPtr obj,  double dpi);

        public static Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_dpi_set_api_delegate> efl_gfx_image_load_controller_load_dpi_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_dpi_set_api_delegate>(Module, "efl_gfx_image_load_controller_load_dpi_set");

        private static void load_dpi_set(System.IntPtr obj, System.IntPtr pd, double dpi)
        {
            Eina.Log.Debug("function efl_gfx_image_load_controller_load_dpi_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((IImageLoadController)ws.Target).SetLoadDpi(dpi);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gfx_image_load_controller_load_dpi_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), dpi);
            }
        }

        private static efl_gfx_image_load_controller_load_dpi_set_delegate efl_gfx_image_load_controller_load_dpi_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_gfx_image_load_controller_load_region_support_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_gfx_image_load_controller_load_region_support_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_region_support_get_api_delegate> efl_gfx_image_load_controller_load_region_support_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_region_support_get_api_delegate>(Module, "efl_gfx_image_load_controller_load_region_support_get");

        private static bool load_region_support_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_image_load_controller_load_region_support_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IImageLoadController)ws.Target).GetLoadRegionSupport();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        return _ret_var;

            }
            else
            {
                return efl_gfx_image_load_controller_load_region_support_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_image_load_controller_load_region_support_get_delegate efl_gfx_image_load_controller_load_region_support_get_static_delegate;

        
        private delegate Eina.Rect.NativeStruct efl_gfx_image_load_controller_load_region_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Rect.NativeStruct efl_gfx_image_load_controller_load_region_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_region_get_api_delegate> efl_gfx_image_load_controller_load_region_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_region_get_api_delegate>(Module, "efl_gfx_image_load_controller_load_region_get");

        private static Eina.Rect.NativeStruct load_region_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_image_load_controller_load_region_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Rect _ret_var = default(Eina.Rect);
                try
                {
                    _ret_var = ((IImageLoadController)ws.Target).GetLoadRegion();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        return _ret_var;

            }
            else
            {
                return efl_gfx_image_load_controller_load_region_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_image_load_controller_load_region_get_delegate efl_gfx_image_load_controller_load_region_get_static_delegate;

        
        private delegate void efl_gfx_image_load_controller_load_region_set_delegate(System.IntPtr obj, System.IntPtr pd,  Eina.Rect.NativeStruct region);

        
        public delegate void efl_gfx_image_load_controller_load_region_set_api_delegate(System.IntPtr obj,  Eina.Rect.NativeStruct region);

        public static Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_region_set_api_delegate> efl_gfx_image_load_controller_load_region_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_region_set_api_delegate>(Module, "efl_gfx_image_load_controller_load_region_set");

        private static void load_region_set(System.IntPtr obj, System.IntPtr pd, Eina.Rect.NativeStruct region)
        {
            Eina.Log.Debug("function efl_gfx_image_load_controller_load_region_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        Eina.Rect _in_region = region;
                            
                try
                {
                    ((IImageLoadController)ws.Target).SetLoadRegion(_in_region);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gfx_image_load_controller_load_region_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), region);
            }
        }

        private static efl_gfx_image_load_controller_load_region_set_delegate efl_gfx_image_load_controller_load_region_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_gfx_image_load_controller_load_orientation_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_gfx_image_load_controller_load_orientation_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_orientation_get_api_delegate> efl_gfx_image_load_controller_load_orientation_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_orientation_get_api_delegate>(Module, "efl_gfx_image_load_controller_load_orientation_get");

        private static bool load_orientation_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_image_load_controller_load_orientation_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IImageLoadController)ws.Target).GetLoadOrientation();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        return _ret_var;

            }
            else
            {
                return efl_gfx_image_load_controller_load_orientation_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_image_load_controller_load_orientation_get_delegate efl_gfx_image_load_controller_load_orientation_get_static_delegate;

        
        private delegate void efl_gfx_image_load_controller_load_orientation_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool enable);

        
        public delegate void efl_gfx_image_load_controller_load_orientation_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool enable);

        public static Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_orientation_set_api_delegate> efl_gfx_image_load_controller_load_orientation_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_orientation_set_api_delegate>(Module, "efl_gfx_image_load_controller_load_orientation_set");

        private static void load_orientation_set(System.IntPtr obj, System.IntPtr pd, bool enable)
        {
            Eina.Log.Debug("function efl_gfx_image_load_controller_load_orientation_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((IImageLoadController)ws.Target).SetLoadOrientation(enable);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gfx_image_load_controller_load_orientation_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), enable);
            }
        }

        private static efl_gfx_image_load_controller_load_orientation_set_delegate efl_gfx_image_load_controller_load_orientation_set_static_delegate;

        
        private delegate int efl_gfx_image_load_controller_load_scale_down_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_gfx_image_load_controller_load_scale_down_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_scale_down_get_api_delegate> efl_gfx_image_load_controller_load_scale_down_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_scale_down_get_api_delegate>(Module, "efl_gfx_image_load_controller_load_scale_down_get");

        private static int load_scale_down_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_image_load_controller_load_scale_down_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            int _ret_var = default(int);
                try
                {
                    _ret_var = ((IImageLoadController)ws.Target).GetLoadScaleDown();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        return _ret_var;

            }
            else
            {
                return efl_gfx_image_load_controller_load_scale_down_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_image_load_controller_load_scale_down_get_delegate efl_gfx_image_load_controller_load_scale_down_get_static_delegate;

        
        private delegate void efl_gfx_image_load_controller_load_scale_down_set_delegate(System.IntPtr obj, System.IntPtr pd,  int div);

        
        public delegate void efl_gfx_image_load_controller_load_scale_down_set_api_delegate(System.IntPtr obj,  int div);

        public static Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_scale_down_set_api_delegate> efl_gfx_image_load_controller_load_scale_down_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_scale_down_set_api_delegate>(Module, "efl_gfx_image_load_controller_load_scale_down_set");

        private static void load_scale_down_set(System.IntPtr obj, System.IntPtr pd, int div)
        {
            Eina.Log.Debug("function efl_gfx_image_load_controller_load_scale_down_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((IImageLoadController)ws.Target).SetLoadScaleDown(div);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gfx_image_load_controller_load_scale_down_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), div);
            }
        }

        private static efl_gfx_image_load_controller_load_scale_down_set_delegate efl_gfx_image_load_controller_load_scale_down_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_gfx_image_load_controller_load_skip_header_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_gfx_image_load_controller_load_skip_header_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_skip_header_get_api_delegate> efl_gfx_image_load_controller_load_skip_header_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_skip_header_get_api_delegate>(Module, "efl_gfx_image_load_controller_load_skip_header_get");

        private static bool load_skip_header_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_image_load_controller_load_skip_header_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IImageLoadController)ws.Target).GetLoadSkipHeader();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        return _ret_var;

            }
            else
            {
                return efl_gfx_image_load_controller_load_skip_header_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_image_load_controller_load_skip_header_get_delegate efl_gfx_image_load_controller_load_skip_header_get_static_delegate;

        
        private delegate void efl_gfx_image_load_controller_load_skip_header_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool skip);

        
        public delegate void efl_gfx_image_load_controller_load_skip_header_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool skip);

        public static Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_skip_header_set_api_delegate> efl_gfx_image_load_controller_load_skip_header_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_skip_header_set_api_delegate>(Module, "efl_gfx_image_load_controller_load_skip_header_set");

        private static void load_skip_header_set(System.IntPtr obj, System.IntPtr pd, bool skip)
        {
            Eina.Log.Debug("function efl_gfx_image_load_controller_load_skip_header_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((IImageLoadController)ws.Target).SetLoadSkipHeader(skip);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gfx_image_load_controller_load_skip_header_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), skip);
            }
        }

        private static efl_gfx_image_load_controller_load_skip_header_set_delegate efl_gfx_image_load_controller_load_skip_header_set_static_delegate;

        
        private delegate void efl_gfx_image_load_controller_load_async_start_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_gfx_image_load_controller_load_async_start_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_async_start_api_delegate> efl_gfx_image_load_controller_load_async_start_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_async_start_api_delegate>(Module, "efl_gfx_image_load_controller_load_async_start");

        private static void load_async_start(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_image_load_controller_load_async_start was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((IImageLoadController)ws.Target).LoadAsyncStart();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_gfx_image_load_controller_load_async_start_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_image_load_controller_load_async_start_delegate efl_gfx_image_load_controller_load_async_start_static_delegate;

        
        private delegate void efl_gfx_image_load_controller_load_async_cancel_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_gfx_image_load_controller_load_async_cancel_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_async_cancel_api_delegate> efl_gfx_image_load_controller_load_async_cancel_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_async_cancel_api_delegate>(Module, "efl_gfx_image_load_controller_load_async_cancel");

        private static void load_async_cancel(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_image_load_controller_load_async_cancel was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((IImageLoadController)ws.Target).LoadAsyncCancel();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_gfx_image_load_controller_load_async_cancel_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_image_load_controller_load_async_cancel_delegate efl_gfx_image_load_controller_load_async_cancel_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

