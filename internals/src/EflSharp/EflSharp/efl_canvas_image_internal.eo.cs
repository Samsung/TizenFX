#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Canvas { 
/// <summary>Efl canvas internal image class</summary>
[ImageInternalNativeInherit]
public class ImageInternal : Efl.Canvas.Object, Efl.Eo.IWrapper,Efl.File,Efl.Orientation,Efl.Canvas.Filter.Internal,Efl.Gfx.Buffer,Efl.Gfx.Fill,Efl.Gfx.Filter,Efl.Gfx.Image,Efl.Gfx.View
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Canvas.ImageInternalNativeInherit nativeInherit = new Efl.Canvas.ImageInternalNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (ImageInternal))
            return Efl.Canvas.ImageInternalNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   ///<summary>Delegate for function to be called from inside the native constructor.</summary>
   public new delegate void ConstructingMethod(ImageInternal obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] internal static extern System.IntPtr
      efl_canvas_image_internal_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="init_cb">Delegate to call constructing methods that should be run inside the constructor.</param>
   public ImageInternal(Efl.Object parent = null, ConstructingMethod init_cb=null) : base("ImageInternal", efl_canvas_image_internal_class_get(), typeof(ImageInternal), parent)
   {
      if (init_cb != null) {
         init_cb(this);
      }
      FinishInstantiation();
   }
   ///<summary>Internal constructor to forward the wrapper initialization to the root class.</summary>
   protected ImageInternal(String klass_name, IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(klass_name, base_klass, managed_type, parent) {}
   ///<summary>Constructs an instance from a native pointer.</summary>
   public ImageInternal(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static ImageInternal static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new ImageInternal(obj.NativeHandle);
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

   protected override void register_event_proxies()
   {
      base.register_event_proxies();
      evt_PreloadEvt_delegate = new Efl.EventCb(on_PreloadEvt_NativeCallback);
      evt_Efl_Gfx_Image_ResizeEvt_delegate = new Efl.EventCb(on_Efl_Gfx_Image_ResizeEvt_NativeCallback);
      evt_UnloadEvt_delegate = new Efl.EventCb(on_UnloadEvt_NativeCallback);
   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern Efl.Gfx.ImageLoadError efl_file_load_error_get(System.IntPtr obj);
   /// <summary>Gets the (last) file loading error for a given object.</summary>
   /// <returns>The load error code.</returns>
   virtual public Efl.Gfx.ImageLoadError GetLoadError() {
       var _ret_var = efl_file_load_error_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_file_mmap_get(System.IntPtr obj,   out Eina.File f,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  out  System.String key);
   /// <summary>Get the source mmaped file from where an image object must fetch the real image data (it must be an Eina_File).
   /// If the file supports multiple data stored in it (as Eet files do), you can get the key to be used as the index of the image in this file.
   /// 1.10</summary>
   /// <param name="f">The handler to an Eina_File that will be used as image source</param>
   /// <param name="key">The group that the image belongs to, in case  it&apos;s an EET(including Edje case) file. This can be used as a key inside evas image cache if this is a normal image file not eet file.</param>
   /// <returns></returns>
   virtual public  void GetMmap( out Eina.File f,  out  System.String key) {
                                           efl_file_mmap_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  out f,  out key);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_file_mmap_set(System.IntPtr obj,   Eina.File f,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key);
   /// <summary>Set the source mmaped file from where an image object must fetch the real image data (it must be an Eina_File).
   /// If the file supports multiple data stored in it (as Eet files do), you can specify the key to be used as the index of the image in this file.
   /// 1.8</summary>
   /// <param name="f">The handler to an Eina_File that will be used as image source</param>
   /// <param name="key">The group that the image belongs to, in case  it&apos;s an EET(including Edje case) file. This can be used as a key inside evas image cache if this is a normal image file not eet file.</param>
   /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
   virtual public bool SetMmap( Eina.File f,   System.String key) {
                                           var _ret_var = efl_file_mmap_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  f,  key);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_file_get(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  out  System.String file,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  out  System.String key);
   /// <summary>Retrieve the source file from where an image object is to fetch the real image data (it may be an Eet file, besides pure image ones).
   /// You must not modify the strings on the returned pointers.
   /// 
   /// Note: Use <c>null</c> pointers on the file components you&apos;re not interested in: they&apos;ll be ignored by the function.</summary>
   /// <param name="file">The image file path.</param>
   /// <param name="key">The image key in <c>file</c> (if its an Eet one), or <c>null</c>, otherwise.</param>
   /// <returns></returns>
   virtual public  void GetFile( out  System.String file,  out  System.String key) {
                                           efl_file_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  out file,  out key);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_file_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String file,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key);
   /// <summary>Set the source file from where an image object must fetch the real image data (it may be an Eet file, besides pure image ones).
   /// If the file supports multiple data stored in it (as Eet files do), you can specify the key to be used as the index of the image in this file.</summary>
   /// <param name="file">The image file path.</param>
   /// <param name="key">The image key in <c>file</c> (if its an Eet one), or <c>null</c>, otherwise.</param>
   /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
   virtual public bool SetFile(  System.String file,   System.String key) {
                                           var _ret_var = efl_file_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  file,  key);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_file_save(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String file,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String flags);
   /// <summary>Save the given image object&apos;s contents to an (image) file.
   /// The extension suffix on <c>file</c> will determine which saver module Evas is to use when saving, thus the final file&apos;s format. If the file supports multiple data stored in it (Eet ones), you can specify the key to be used as the index of the image in it.
   /// 
   /// You can specify some flags when saving the image.  Currently acceptable flags are <c>quality</c> and <c>compress</c>. Eg.: &quot;quality=100 compress=9&quot;.</summary>
   /// <param name="file">The filename to be used to save the image (extension obligatory).</param>
   /// <param name="key">The image key in the file (if an Eet one), or <c>null</c>, otherwise.</param>
   /// <param name="flags">String containing the flags to be used (<c>null</c> for none).</param>
   /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
   virtual public bool Save(  System.String file,   System.String key,   System.String flags) {
                                                             var _ret_var = efl_file_save((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  file,  key,  flags);
      Eina.Error.RaiseIfUnhandledException();
                                          return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern Efl.Orient efl_orientation_get(System.IntPtr obj);
   /// <summary>Control the orientation of a given object.
   /// This can be used to set the rotation on an image or a window, for instance.</summary>
   /// <returns>The rotation angle (CCW), see <see cref="Efl.Orient"/>.</returns>
   virtual public Efl.Orient GetOrientation() {
       var _ret_var = efl_orientation_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_orientation_set(System.IntPtr obj,   Efl.Orient dir);
   /// <summary>Control the orientation of a given object.
   /// This can be used to set the rotation on an image or a window, for instance.</summary>
   /// <param name="dir">The rotation angle (CCW), see <see cref="Efl.Orient"/>.</param>
   /// <returns></returns>
   virtual public  void SetOrientation( Efl.Orient dir) {
                         efl_orientation_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  dir);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern Efl.Flip efl_orientation_flip_get(System.IntPtr obj);
   /// <summary>Control the flip of the given image
   /// Use this function to change how your image is to be flipped: vertically or horizontally or transpose or traverse.</summary>
   /// <returns>Flip method</returns>
   virtual public Efl.Flip GetFlip() {
       var _ret_var = efl_orientation_flip_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_orientation_flip_set(System.IntPtr obj,   Efl.Flip flip);
   /// <summary>Control the flip of the given image
   /// Use this function to change how your image is to be flipped: vertically or horizontally or transpose or traverse.</summary>
   /// <param name="flip">Flip method</param>
   /// <returns></returns>
   virtual public  void SetFlip( Efl.Flip flip) {
                         efl_orientation_flip_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  flip);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void evas_filter_changed_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool val);
   /// <summary>Marks this filter as changed.</summary>
   /// <param name="val"><c>true</c> if filter changed, <c>false</c> otherwise</param>
   /// <returns></returns>
   virtual public  void SetFilterChanged( bool val) {
                         evas_filter_changed_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  val);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void evas_filter_invalid_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool val);
   /// <summary>Marks this filter as invalid.</summary>
   /// <param name="val"><c>true</c> if filter is invalid, <c>false</c> otherwise</param>
   /// <returns></returns>
   virtual public  void SetFilterInvalid( bool val) {
                         evas_filter_invalid_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  val);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  System.IntPtr evas_filter_output_buffer_get(System.IntPtr obj);
   /// <summary>Retrieve cached output buffer, if any.
   /// Does not increment the reference count.</summary>
   /// <returns>Output buffer</returns>
   virtual public  System.IntPtr GetFilterOutputBuffer() {
       var _ret_var = evas_filter_output_buffer_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool evas_filter_input_alpha(System.IntPtr obj);
   /// <summary>Called by Efl.Canvas.Filter.Internal to determine whether the input is alpha or rgba.</summary>
   /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
   virtual public bool FilterInputAlpha() {
       var _ret_var = evas_filter_input_alpha((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void evas_filter_state_prepare(System.IntPtr obj,   out Efl.Canvas.Filter.State_StructInternal state,    System.IntPtr data);
   /// <summary>Called by Efl.Canvas.Filter.Internal to request the parent class for state information (color, etc...).</summary>
   /// <param name="state">State info to fill in</param>
   /// <param name="data">Private data for the class</param>
   /// <returns></returns>
   virtual public  void FilterStatePrepare( out Efl.Canvas.Filter.State state,   System.IntPtr data) {
                   var _out_state = new Efl.Canvas.Filter.State_StructInternal();
                        evas_filter_state_prepare((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  out _out_state,  data);
      Eina.Error.RaiseIfUnhandledException();
      state = Efl.Canvas.Filter.State_StructConversion.ToManaged(_out_state);
                         }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool evas_filter_input_render(System.IntPtr obj,    System.IntPtr filter,    System.IntPtr engine,    System.IntPtr output,    System.IntPtr drawctx,    System.IntPtr data,    int l,    int r,    int t,    int b,    int x,    int y,  [MarshalAs(UnmanagedType.U1)]  bool do_async);
   /// <summary>Called by Efl.Canvas.Filter.Internal when the parent class must render the input.</summary>
   /// <param name="filter">Current filter context</param>
   /// <param name="engine">Engine context</param>
   /// <param name="output">Output context</param>
   /// <param name="drawctx">Draw context (for evas engine)</param>
   /// <param name="data">Private data used by textblock</param>
   /// <param name="l">Left</param>
   /// <param name="r">Right</param>
   /// <param name="t">Top</param>
   /// <param name="b">Bottom</param>
   /// <param name="x">X offset</param>
   /// <param name="y">Y offset</param>
   /// <param name="do_async"><c>true</c> when the operation should be done asynchronously, <c>false</c> otherwise</param>
   /// <returns>Indicates success from the object render function.</returns>
   virtual public bool FilterInputRender(  System.IntPtr filter,   System.IntPtr engine,   System.IntPtr output,   System.IntPtr drawctx,   System.IntPtr data,   int l,   int r,   int t,   int b,   int x,   int y,  bool do_async) {
                                                                                                                                                                                                                               var _ret_var = evas_filter_input_render((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  filter,  engine,  output,  drawctx,  data,  l,  r,  t,  b,  x,  y,  do_async);
      Eina.Error.RaiseIfUnhandledException();
                                                                                                                                                      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void evas_filter_dirty(System.IntPtr obj);
   /// <summary>Called when filter changes must trigger a redraw of the object.
   /// Virtual, to be implemented in the parent class.</summary>
   /// <returns></returns>
   virtual public  void FilterDirty() {
       evas_filter_dirty((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern Eina.Size2D_StructInternal efl_gfx_buffer_size_get(System.IntPtr obj);
   /// <summary>Rectangular size of the pixel buffer as allocated in memory.</summary>
   /// <returns>Size of the buffer in pixels.</returns>
   virtual public Eina.Size2D GetBufferSize() {
       var _ret_var = efl_gfx_buffer_size_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return Eina.Size2D_StructConversion.ToManaged(_ret_var);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_buffer_size_set(System.IntPtr obj,   Eina.Size2D_StructInternal sz);
   /// <summary>Potentially not implemented, <see cref="Efl.Gfx.Buffer.BufferSize"/> may be read-only.</summary>
   /// <param name="sz">Size of the buffer in pixels.</param>
   /// <returns></returns>
   virtual public  void SetBufferSize( Eina.Size2D sz) {
       var _in_sz = Eina.Size2D_StructConversion.ToInternal(sz);
                  efl_gfx_buffer_size_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  _in_sz);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern Efl.Gfx.Colorspace efl_gfx_buffer_colorspace_get(System.IntPtr obj);
   /// <summary>Returns the current encoding of this buffer&apos;s pixels.
   /// See <see cref="Efl.Gfx.Colorspace"/> for more information on the supported formats.</summary>
   /// <returns>Colorspace</returns>
   virtual public Efl.Gfx.Colorspace GetColorspace() {
       var _ret_var = efl_gfx_buffer_colorspace_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_gfx_buffer_alpha_get(System.IntPtr obj);
   /// <summary>Retrieve whether alpha channel data is used on this object.</summary>
   /// <returns>Whether to use alpha channel (<c>true</c>) data or not (<c>false</c>).</returns>
   virtual public bool GetAlpha() {
       var _ret_var = efl_gfx_buffer_alpha_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_buffer_alpha_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool alpha);
   /// <summary>Change alpha channel usage for this object.
   /// This function sets a flag on an image object indicating whether or not to use alpha channel data. A value of <c>true</c> makes it use alpha channel data, and <c>false</c> makes it ignore that data. Note that this has nothing to do with an object&apos;s color as manipulated by <see cref="Efl.Gfx.Color.GetColor"/>.</summary>
   /// <param name="alpha">Whether to use alpha channel (<c>true</c>) data or not (<c>false</c>).</param>
   /// <returns></returns>
   virtual public  void SetAlpha( bool alpha) {
                         efl_gfx_buffer_alpha_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  alpha);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  int efl_gfx_buffer_stride_get(System.IntPtr obj);
   /// <summary>Length in bytes of one row of pixels in memory.
   /// Usually this will be equal to width * 4, with a plain BGRA image. This may return 0 if the stride is not applicable.
   /// 
   /// When applicable, this will include the <see cref="Efl.Gfx.Buffer.GetBufferBorders"/> as well as potential extra padding.</summary>
   /// <returns>Stride</returns>
   virtual public  int GetStride() {
       var _ret_var = efl_gfx_buffer_stride_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_buffer_borders_get(System.IntPtr obj,   out  uint l,   out  uint r,   out  uint t,   out  uint b);
   /// <summary>Duplicated pixel borders inside this buffer.
   /// Internally, EFL may require an image to have its border pixels duplicated, in particular for GL textures. This property exposes the internal duplicated borders to allow calling <see cref="Efl.Gfx.Buffer.BufferMap"/> with the entire pixel data, including those edge pixels.</summary>
   /// <param name="l">Left border pixels, usually 0 or 1</param>
   /// <param name="r">Right border pixels, usually 0 or 1</param>
   /// <param name="t">Top border pixels, usually 0 or 1</param>
   /// <param name="b">Bottom border pixels, usually 0 or 1</param>
   /// <returns></returns>
   virtual public  void GetBufferBorders( out  uint l,  out  uint r,  out  uint t,  out  uint b) {
                                                                               efl_gfx_buffer_borders_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  out l,  out r,  out t,  out b);
      Eina.Error.RaiseIfUnhandledException();
                                                       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_buffer_update_add(System.IntPtr obj,   ref Eina.Rect_StructInternal region);
   /// <summary>Mark a sub-region of the given image object to be redrawn.
   /// This function schedules a particular rectangular region of an image object to be updated (redrawn) at the next rendering cycle.</summary>
   /// <param name="region">The updated region.</param>
   /// <returns></returns>
   virtual public  void AddBufferUpdate( ref Eina.Rect region) {
       var _in_region = Eina.Rect_StructConversion.ToInternal(region);
                  efl_gfx_buffer_update_add((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  ref _in_region);
      Eina.Error.RaiseIfUnhandledException();
            region = Eina.Rect_StructConversion.ToManaged(_in_region);
       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern Eina.RwSlice efl_gfx_buffer_map(System.IntPtr obj,   Efl.Gfx.BufferAccessMode mode,   ref Eina.Rect_StructInternal region,   Efl.Gfx.Colorspace cspace,    int plane,   out  int stride);
   /// <summary>Map a region of this buffer for read or write access by the CPU.
   /// Fetches data from the GPU if needed. This operation may be slow if cpu_readable_fast or cpu_writeable_fast are not true, or if the required colorspace is different from the internal one.
   /// 
   /// Note that if the buffer has <see cref="Efl.Gfx.Buffer.GetBufferBorders"/>, then <c>x</c> and <c>y</c> may be negative.</summary>
   /// <param name="mode">Specifies whether to map for read-only, write-only or read-write access (OR combination of flags).</param>
   /// <param name="region">The region to map.</param>
   /// <param name="cspace">Requested colorspace. If different from the internal cspace, map should try to convert the data into a new buffer. argb8888 by default.</param>
   /// <param name="plane">Plane ID. 0 by default. Useful for planar formats only.</param>
   /// <param name="stride">Returns the length in bytes of a mapped line</param>
   /// <returns>The data slice. In case of failure, the memory pointer will be <c>null</c>.</returns>
   virtual public Eina.RwSlice BufferMap( Efl.Gfx.BufferAccessMode mode,  ref Eina.Rect region,  Efl.Gfx.Colorspace cspace,   int plane,  out  int stride) {
             var _in_region = Eina.Rect_StructConversion.ToInternal(region);
                                                                                    var _ret_var = efl_gfx_buffer_map((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  mode,  ref _in_region,  cspace,  plane,  out stride);
      Eina.Error.RaiseIfUnhandledException();
                                          region = Eina.Rect_StructConversion.ToManaged(_in_region);
                        return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_gfx_buffer_unmap(System.IntPtr obj,   Eina.RwSlice slice);
   /// <summary>Unmap a region of this buffer, and update the internal data if needed.
   /// EFL will update the internal image if the map had write access.
   /// 
   /// Note: The <c>slice</c> struct does not need to be the one returned by <see cref="Efl.Gfx.Buffer.BufferMap"/>, only its contents (<c>mem</c> and <c>len</c>) must match. But after a call to <see cref="Efl.Gfx.Buffer.BufferUnmap"/> the original <c>slice</c> structure is not valid anymore.</summary>
   /// <param name="slice">Data slice returned by a previous call to map.</param>
   /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
   virtual public bool BufferUnmap( Eina.RwSlice slice) {
                         var _ret_var = efl_gfx_buffer_unmap((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  slice);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_gfx_buffer_copy_set(System.IntPtr obj,    System.IntPtr slice,   Eina.Size2D_StructInternal size,    int stride,   Efl.Gfx.Colorspace cspace,    int plane);
   /// <summary>Set the pixels for this buffer by copying them, or allocate a new memory region.
   /// This will allocate a new buffer in memory and copy the input <c>pixels</c> to it. The internal colorspace is not guaranteed to be preserved, and colorspace conversion may happen internally.
   /// 
   /// If <c>pixels</c> is <c>null</c>, then a new empty buffer will be allocated. If the buffer already had pixel data, the previous image data will be dropped. This is the same as <see cref="Efl.Gfx.Buffer.SetBufferManaged"/>.
   /// 
   /// The memory buffer <c>pixels</c> must be large enough to hold <c>width</c> x <c>height</c> pixels encoded in the colorspace <c>cspace</c>.
   /// 
   /// <c>slice</c> should not be the return value of <see cref="Efl.Gfx.Buffer.GetBufferManaged"/>.</summary>
   /// <param name="slice">If <c>null</c>, allocates an empty buffer</param>
   /// <param name="size">The size in pixels.</param>
   /// <param name="stride">If 0, automatically guessed from the <c>width</c>.</param>
   /// <param name="cspace">argb8888 by default.</param>
   /// <param name="plane">Plane ID. 0 by default. Useful for planar formats only.</param>
   /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
   virtual public bool SetBufferCopy( Eina.Slice slice,  Eina.Size2D size,   int stride,  Efl.Gfx.Colorspace cspace,   int plane) {
       var _in_slice = Eina.PrimitiveConversion.ManagedToPointerAlloc(slice);
      var _in_size = Eina.Size2D_StructConversion.ToInternal(size);
                                                                                    var _ret_var = efl_gfx_buffer_copy_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  _in_slice,  _in_size,  stride,  cspace,  plane);
      Eina.Error.RaiseIfUnhandledException();
                                                                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_gfx_buffer_managed_set(System.IntPtr obj,    System.IntPtr slice,   Eina.Size2D_StructInternal size,    int stride,   Efl.Gfx.Colorspace cspace,    int plane);
   /// <summary>Set the pixels for this buffer, managed externally by the client.
   /// EFL will use the pixel data directly, and update the GPU-side texture if required. This will mark the image as dirty. If <c>slice</c> is <c>null</c>, this will detach the pixel data.
   /// 
   /// If the buffer already had pixel data, the previous image data will be dropped. This is the same as <see cref="Efl.Gfx.Buffer.SetBufferCopy"/>.
   /// 
   /// The memory buffer <c>pixels</c> must be large enough to hold <c>width</c> x <c>height</c> pixels encoded in the colorspace <c>cspace</c>.
   /// 
   /// See also <see cref="Efl.Gfx.Buffer.SetBufferCopy"/> if you want EFL to copy the input buffer internally.</summary>
   /// <param name="slice">If <c>null</c>, detaches the previous buffer.</param>
   /// <param name="size">The size in pixels.</param>
   /// <param name="stride">If 0, automatically guessed from the <c>width</c>.</param>
   /// <param name="cspace">argb8888 by default.</param>
   /// <param name="plane">Plane ID. 0 by default. Useful for planar formats only.</param>
   /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
   virtual public bool SetBufferManaged( Eina.Slice slice,  Eina.Size2D size,   int stride,  Efl.Gfx.Colorspace cspace,   int plane) {
       var _in_slice = Eina.PrimitiveConversion.ManagedToPointerAlloc(slice);
      var _in_size = Eina.Size2D_StructConversion.ToInternal(size);
                                                                                    var _ret_var = efl_gfx_buffer_managed_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  _in_slice,  _in_size,  stride,  cspace,  plane);
      Eina.Error.RaiseIfUnhandledException();
                                                                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern Eina.Slice efl_gfx_buffer_managed_get(System.IntPtr obj,    int plane);
   /// <summary>Get a direct pointer to the internal pixel data, if available.
   /// This will return <c>null</c> unless <see cref="Efl.Gfx.Buffer.SetBufferManaged"/> was used to pass in an external data pointer.</summary>
   /// <param name="plane">Plane ID. 0 by default. Useful for planar formats only.</param>
   /// <returns>The data slice. The memory pointer will be <c>null</c> in case of failure.</returns>
   virtual public Eina.Slice GetBufferManaged(  int plane) {
                         var _ret_var = efl_gfx_buffer_managed_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  plane);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_gfx_fill_auto_get(System.IntPtr obj);
   /// <summary>Binds the object&apos;s <see cref="Efl.Gfx.Fill.Fill"/> property to its actual geometry.
   /// If <c>true</c>, then every time the object is resized, it will automatically trigger a call to <see cref="Efl.Gfx.Fill.SetFill"/> with the new size (and 0, 0 as source image&apos;s origin), so the image will cover the whole object&apos;s area.
   /// 
   /// This property takes precedence over <see cref="Efl.Gfx.Fill.Fill"/>. If set to <c>false</c>, then <see cref="Efl.Gfx.Fill.Fill"/> should be set.
   /// 
   /// This flag is <c>true</c> by default (used to be <c>false</c> with the old APIs, and was known as &quot;filled&quot;).</summary>
   /// <returns><c>true</c> to make the fill property follow object size or <c>false</c> otherwise.</returns>
   virtual public bool GetFillAuto() {
       var _ret_var = efl_gfx_fill_auto_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_fill_auto_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool filled);
   /// <summary>Binds the object&apos;s <see cref="Efl.Gfx.Fill.Fill"/> property to its actual geometry.
   /// If <c>true</c>, then every time the object is resized, it will automatically trigger a call to <see cref="Efl.Gfx.Fill.SetFill"/> with the new size (and 0, 0 as source image&apos;s origin), so the image will cover the whole object&apos;s area.
   /// 
   /// This property takes precedence over <see cref="Efl.Gfx.Fill.Fill"/>. If set to <c>false</c>, then <see cref="Efl.Gfx.Fill.Fill"/> should be set.
   /// 
   /// This flag is <c>true</c> by default (used to be <c>false</c> with the old APIs, and was known as &quot;filled&quot;).</summary>
   /// <param name="filled"><c>true</c> to make the fill property follow object size or <c>false</c> otherwise.</param>
   /// <returns></returns>
   virtual public  void SetFillAuto( bool filled) {
                         efl_gfx_fill_auto_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  filled);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern Eina.Rect_StructInternal efl_gfx_fill_get(System.IntPtr obj);
   /// <summary>Specifies how to tile an image to fill its rectangle geometry.
   /// Note that if <c>w</c> or <c>h</c> are smaller than the dimensions of the object, the displayed image will be tiled around the object&apos;s area. To have only one copy of the bound image drawn, <c>x</c> and <c>y</c> must be 0 and <c>w</c> and <c>h</c> need to be the exact width and height of the image object itself, respectively.
   /// 
   /// Setting this property will reset the <see cref="Efl.Gfx.Fill.FillAuto"/> to <c>false</c>.</summary>
   /// <returns>The top-left corner to start drawing from as well as the size at which the bound image will be displayed.</returns>
   virtual public Eina.Rect GetFill() {
       var _ret_var = efl_gfx_fill_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return Eina.Rect_StructConversion.ToManaged(_ret_var);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_fill_set(System.IntPtr obj,   Eina.Rect_StructInternal fill);
   /// <summary>Specifies how to tile an image to fill its rectangle geometry.
   /// Note that if <c>w</c> or <c>h</c> are smaller than the dimensions of the object, the displayed image will be tiled around the object&apos;s area. To have only one copy of the bound image drawn, <c>x</c> and <c>y</c> must be 0 and <c>w</c> and <c>h</c> need to be the exact width and height of the image object itself, respectively.
   /// 
   /// Setting this property will reset the <see cref="Efl.Gfx.Fill.FillAuto"/> to <c>false</c>.</summary>
   /// <param name="fill">The top-left corner to start drawing from as well as the size at which the bound image will be displayed.</param>
   /// <returns></returns>
   virtual public  void SetFill( Eina.Rect fill) {
       var _in_fill = Eina.Rect_StructConversion.ToInternal(fill);
                  efl_gfx_fill_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  _in_fill);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_filter_program_get(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  out  System.String code,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  out  System.String name);
   /// <summary>Gets the code of the filter program set on this object. May be <c>null</c>.
   /// 1.18</summary>
   /// <param name="code">The Lua program source code.
   /// 1.18</param>
   /// <param name="name">An optional name for this filter.
   /// 1.18</param>
   /// <returns></returns>
   virtual public  void GetFilterProgram( out  System.String code,  out  System.String name) {
                                           efl_gfx_filter_program_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  out code,  out name);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_filter_program_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String code,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name);
   /// <summary>Set a graphical filter program on this object.
   /// Valid for Text and Image objects at the moment.
   /// 
   /// The argument passed to this function is a string containing a valid Lua program based on the filters API as described in the &quot;EFL Graphics Filters&quot; reference page.
   /// 
   /// Set to <c>null</c> to disable filtering.
   /// 1.18</summary>
   /// <param name="code">The Lua program source code.
   /// 1.18</param>
   /// <param name="name">An optional name for this filter.
   /// 1.18</param>
   /// <returns></returns>
   virtual public  void SetFilterProgram(  System.String code,   System.String name) {
                                           efl_gfx_filter_program_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  code,  name);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_filter_state_get(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  out  System.String cur_state,   out double cur_val,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  out  System.String next_state,   out double next_val,   out double pos);
   /// <summary>Set the current state of the filter.
   /// This should be used by Edje (EFL&apos;s internal layout engine), but could also be used when implementing animations programmatically.
   /// 
   /// A full state is defined by two states (name + value): origin state and target state of an ongoing animation, as well as the <c>pos</c> progress (from 0 to 1) of that animation timeline. The second state can be omitted if there is no ongoing animation.
   /// 1.18</summary>
   /// <param name="cur_state">Current state of the filter
   /// 1.18</param>
   /// <param name="cur_val">Current value
   /// 1.18</param>
   /// <param name="next_state">Next filter state, optional
   /// 1.18</param>
   /// <param name="next_val">Next value, optional
   /// 1.18</param>
   /// <param name="pos">Position, optional
   /// 1.18</param>
   /// <returns></returns>
   virtual public  void GetFilterState( out  System.String cur_state,  out double cur_val,  out  System.String next_state,  out double next_val,  out double pos) {
                                                                                                 efl_gfx_filter_state_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  out cur_state,  out cur_val,  out next_state,  out next_val,  out pos);
      Eina.Error.RaiseIfUnhandledException();
                                                                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_filter_state_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String cur_state,   double cur_val,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String next_state,   double next_val,   double pos);
   /// <summary>Set the current state of the filter.
   /// This should be used by Edje (EFL&apos;s internal layout engine), but could also be used when implementing animations programmatically.
   /// 
   /// A full state is defined by two states (name + value): origin state and target state of an ongoing animation, as well as the <c>pos</c> progress (from 0 to 1) of that animation timeline. The second state can be omitted if there is no ongoing animation.
   /// 1.18</summary>
   /// <param name="cur_state">Current state of the filter
   /// 1.18</param>
   /// <param name="cur_val">Current value
   /// 1.18</param>
   /// <param name="next_state">Next filter state, optional
   /// 1.18</param>
   /// <param name="next_val">Next value, optional
   /// 1.18</param>
   /// <param name="pos">Position, optional
   /// 1.18</param>
   /// <returns></returns>
   virtual public  void SetFilterState(  System.String cur_state,  double cur_val,   System.String next_state,  double next_val,  double pos) {
                                                                                                 efl_gfx_filter_state_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  cur_state,  cur_val,  next_state,  next_val,  pos);
      Eina.Error.RaiseIfUnhandledException();
                                                                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_filter_padding_get(System.IntPtr obj,   out  int l,   out  int r,   out  int t,   out  int b);
   /// <summary>Gets the padding required to apply this filter.
   /// 1.18</summary>
   /// <param name="l">Padding on the left
   /// 1.18</param>
   /// <param name="r">Padding on the right
   /// 1.18</param>
   /// <param name="t">Padding on the top
   /// 1.18</param>
   /// <param name="b">Padding on the bottom
   /// 1.18</param>
   /// <returns></returns>
   virtual public  void GetFilterPadding( out  int l,  out  int r,  out  int t,  out  int b) {
                                                                               efl_gfx_filter_padding_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  out l,  out r,  out t,  out b);
      Eina.Error.RaiseIfUnhandledException();
                                                       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))] protected static extern Efl.Gfx.Entity efl_gfx_filter_source_get(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name);
   /// <summary>Bind an object to use as a mask or texture in a filter program.
   /// This will create automatically a new RGBA buffer containing the source object&apos;s pixels (as it is rendered).
   /// 1.18</summary>
   /// <param name="name">Buffer name as used in the program.
   /// 1.18</param>
   /// <returns>Object to use as a source of pixels.
   /// 1.18</returns>
   virtual public Efl.Gfx.Entity GetFilterSource(  System.String name) {
                         var _ret_var = efl_gfx_filter_source_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  name);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_filter_source_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity source);
   /// <summary>Bind an object to use as a mask or texture in a filter program.
   /// This will create automatically a new RGBA buffer containing the source object&apos;s pixels (as it is rendered).
   /// 1.18</summary>
   /// <param name="name">Buffer name as used in the program.
   /// 1.18</param>
   /// <param name="source">Object to use as a source of pixels.
   /// 1.18</param>
   /// <returns></returns>
   virtual public  void SetFilterSource(  System.String name,  Efl.Gfx.Entity source) {
                                           efl_gfx_filter_source_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  name,  source);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_filter_data_get(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  out  System.String value,  [MarshalAs(UnmanagedType.U1)]  out bool execute);
   /// <summary>Extra data used by the filter program.
   /// Each data element is a string (<c>value</c>) stored as a global variable <c>name</c>. The program is then responsible for conversion to numbers, tables, etc...
   /// 
   /// If the <c>execute</c> flag is set, then the <c>value</c> can be complex and run, as if the original Lua program contained a line &apos;name = value&apos;. This can be used to pass in tables.
   /// 1.18</summary>
   /// <param name="name">Name of the global variable
   /// 1.18</param>
   /// <param name="value">String value to use as data
   /// 1.18</param>
   /// <param name="execute">If <c>true</c>, execute &apos;name = value&apos;
   /// 1.18</param>
   /// <returns></returns>
   virtual public  void GetFilterData(  System.String name,  out  System.String value,  out bool execute) {
                                                             efl_gfx_filter_data_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  name,  out value,  out execute);
      Eina.Error.RaiseIfUnhandledException();
                                           }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_filter_data_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String value,  [MarshalAs(UnmanagedType.U1)]  bool execute);
   /// <summary>Extra data used by the filter program.
   /// Each data element is a string (<c>value</c>) stored as a global variable <c>name</c>. The program is then responsible for conversion to numbers, tables, etc...
   /// 
   /// If the <c>execute</c> flag is set, then the <c>value</c> can be complex and run, as if the original Lua program contained a line &apos;name = value&apos;. This can be used to pass in tables.
   /// 1.18</summary>
   /// <param name="name">Name of the global variable
   /// 1.18</param>
   /// <param name="value">String value to use as data
   /// 1.18</param>
   /// <param name="execute">If <c>true</c>, execute &apos;name = value&apos;
   /// 1.18</param>
   /// <returns></returns>
   virtual public  void SetFilterData(  System.String name,   System.String value,  bool execute) {
                                                             efl_gfx_filter_data_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  name,  value,  execute);
      Eina.Error.RaiseIfUnhandledException();
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
    protected static extern Eina.Size2D_StructInternal efl_gfx_view_size_get(System.IntPtr obj);
   /// <summary>The dimensions of this object&apos;s viewport.
   /// This property represents the size of an image (file on disk, vector graphics, GL or 3D scene, ...) view: this is the logical size of a view, not the number of pixels in the buffer, nor its visible size on the window.
   /// 
   /// For scalable scenes (vector graphics, 3D or GL), this means scaling the contents of the scene and drawing more pixels as a result; For pixmaps this means zooming and stretching up or down the backing buffer to fit this view.
   /// 
   /// In most cases the view should have the same dimensions as the object on the canvas, for best quality.
   /// 
   /// <see cref="Efl.Gfx.View.SetViewSize"/> may not be implemented. If it is, it might trigger a complete recalculation of the scene, or reload of the pixel data.
   /// 
   /// Refer to each implementing class specific documentation for more details.</summary>
   /// <returns>Size of the view.</returns>
   virtual public Eina.Size2D GetViewSize() {
       var _ret_var = efl_gfx_view_size_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return Eina.Size2D_StructConversion.ToManaged(_ret_var);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_view_size_set(System.IntPtr obj,   Eina.Size2D_StructInternal size);
   /// <summary>The dimensions of this object&apos;s viewport.
   /// This property represents the size of an image (file on disk, vector graphics, GL or 3D scene, ...) view: this is the logical size of a view, not the number of pixels in the buffer, nor its visible size on the window.
   /// 
   /// For scalable scenes (vector graphics, 3D or GL), this means scaling the contents of the scene and drawing more pixels as a result; For pixmaps this means zooming and stretching up or down the backing buffer to fit this view.
   /// 
   /// In most cases the view should have the same dimensions as the object on the canvas, for best quality.
   /// 
   /// <see cref="Efl.Gfx.View.SetViewSize"/> may not be implemented. If it is, it might trigger a complete recalculation of the scene, or reload of the pixel data.
   /// 
   /// Refer to each implementing class specific documentation for more details.</summary>
   /// <param name="size">Size of the view.</param>
   /// <returns></returns>
   virtual public  void SetViewSize( Eina.Size2D size) {
       var _in_size = Eina.Size2D_StructConversion.ToInternal(size);
                  efl_gfx_view_size_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  _in_size);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Gets the (last) file loading error for a given object.</summary>
   public Efl.Gfx.ImageLoadError LoadError {
      get { return GetLoadError(); }
   }
   /// <summary>Control the orientation of a given object.
/// This can be used to set the rotation on an image or a window, for instance.</summary>
   public Efl.Orient Orientation {
      get { return GetOrientation(); }
      set { SetOrientation( value); }
   }
   /// <summary>Control the flip of the given image
/// Use this function to change how your image is to be flipped: vertically or horizontally or transpose or traverse.</summary>
   public Efl.Flip Flip {
      get { return GetFlip(); }
      set { SetFlip( value); }
   }
   /// <summary>Marks this filter as changed.</summary>
   public bool FilterChanged {
      set { SetFilterChanged( value); }
   }
   /// <summary>Marks this filter as invalid.</summary>
   public bool FilterInvalid {
      set { SetFilterInvalid( value); }
   }
   /// <summary>Retrieve cached output buffer, if any.
/// Does not increment the reference count.</summary>
   public  System.IntPtr FilterOutputBuffer {
      get { return GetFilterOutputBuffer(); }
   }
   /// <summary>Rectangular size of the pixel buffer as allocated in memory.</summary>
   public Eina.Size2D BufferSize {
      get { return GetBufferSize(); }
      set { SetBufferSize( value); }
   }
   /// <summary>The colorspace defines how pixels are encoded in the image in memory.
/// By default, images are encoded in 32-bit BGRA, ie. each pixel takes 4 bytes in memory, with each channel B,G,R,A encoding the color with values from 0 to 255.
/// 
/// All images used in EFL use alpha-premultipied BGRA values, which means that for each pixel, B &lt;= A, G &lt;= A and R &lt;= A.</summary>
   public Efl.Gfx.Colorspace Colorspace {
      get { return GetColorspace(); }
   }
   /// <summary>Indicates whether the alpha channel should be used.
/// This does not indicate whether the image source file contains an alpha channel, only whether to respect it or discard it.</summary>
   public bool Alpha {
      get { return GetAlpha(); }
      set { SetAlpha( value); }
   }
   /// <summary>Length in bytes of one row of pixels in memory.
/// Usually this will be equal to width * 4, with a plain BGRA image. This may return 0 if the stride is not applicable.
/// 
/// When applicable, this will include the <see cref="Efl.Gfx.Buffer.GetBufferBorders"/> as well as potential extra padding.</summary>
   public  int Stride {
      get { return GetStride(); }
   }
   /// <summary>Binds the object&apos;s <see cref="Efl.Gfx.Fill.Fill"/> property to its actual geometry.
/// If <c>true</c>, then every time the object is resized, it will automatically trigger a call to <see cref="Efl.Gfx.Fill.SetFill"/> with the new size (and 0, 0 as source image&apos;s origin), so the image will cover the whole object&apos;s area.
/// 
/// This property takes precedence over <see cref="Efl.Gfx.Fill.Fill"/>. If set to <c>false</c>, then <see cref="Efl.Gfx.Fill.Fill"/> should be set.
/// 
/// This flag is <c>true</c> by default (used to be <c>false</c> with the old APIs, and was known as &quot;filled&quot;).</summary>
   public bool FillAuto {
      get { return GetFillAuto(); }
      set { SetFillAuto( value); }
   }
   /// <summary>Specifies how to tile an image to fill its rectangle geometry.
/// Note that if <c>w</c> or <c>h</c> are smaller than the dimensions of the object, the displayed image will be tiled around the object&apos;s area. To have only one copy of the bound image drawn, <c>x</c> and <c>y</c> must be 0 and <c>w</c> and <c>h</c> need to be the exact width and height of the image object itself, respectively.
/// 
/// Setting this property will reset the <see cref="Efl.Gfx.Fill.FillAuto"/> to <c>false</c>.</summary>
   public Eina.Rect Fill {
      get { return GetFill(); }
      set { SetFill( value); }
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
   /// <summary>The dimensions of this object&apos;s viewport.
/// This property represents the size of an image (file on disk, vector graphics, GL or 3D scene, ...) view: this is the logical size of a view, not the number of pixels in the buffer, nor its visible size on the window.
/// 
/// For scalable scenes (vector graphics, 3D or GL), this means scaling the contents of the scene and drawing more pixels as a result; For pixmaps this means zooming and stretching up or down the backing buffer to fit this view.
/// 
/// In most cases the view should have the same dimensions as the object on the canvas, for best quality.
/// 
/// <see cref="Efl.Gfx.View.SetViewSize"/> may not be implemented. If it is, it might trigger a complete recalculation of the scene, or reload of the pixel data.
/// 
/// Refer to each implementing class specific documentation for more details.</summary>
   public Eina.Size2D ViewSize {
      get { return GetViewSize(); }
      set { SetViewSize( value); }
   }
}
public class ImageInternalNativeInherit : Efl.Canvas.ObjectNativeInherit{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_file_load_error_get_static_delegate = new efl_file_load_error_get_delegate(load_error_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_file_load_error_get"), func = Marshal.GetFunctionPointerForDelegate(efl_file_load_error_get_static_delegate)});
      efl_file_mmap_get_static_delegate = new efl_file_mmap_get_delegate(mmap_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_file_mmap_get"), func = Marshal.GetFunctionPointerForDelegate(efl_file_mmap_get_static_delegate)});
      efl_file_mmap_set_static_delegate = new efl_file_mmap_set_delegate(mmap_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_file_mmap_set"), func = Marshal.GetFunctionPointerForDelegate(efl_file_mmap_set_static_delegate)});
      efl_file_get_static_delegate = new efl_file_get_delegate(file_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_file_get"), func = Marshal.GetFunctionPointerForDelegate(efl_file_get_static_delegate)});
      efl_file_set_static_delegate = new efl_file_set_delegate(file_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_file_set"), func = Marshal.GetFunctionPointerForDelegate(efl_file_set_static_delegate)});
      efl_file_save_static_delegate = new efl_file_save_delegate(save);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_file_save"), func = Marshal.GetFunctionPointerForDelegate(efl_file_save_static_delegate)});
      efl_orientation_get_static_delegate = new efl_orientation_get_delegate(orientation_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_orientation_get"), func = Marshal.GetFunctionPointerForDelegate(efl_orientation_get_static_delegate)});
      efl_orientation_set_static_delegate = new efl_orientation_set_delegate(orientation_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_orientation_set"), func = Marshal.GetFunctionPointerForDelegate(efl_orientation_set_static_delegate)});
      efl_orientation_flip_get_static_delegate = new efl_orientation_flip_get_delegate(flip_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_orientation_flip_get"), func = Marshal.GetFunctionPointerForDelegate(efl_orientation_flip_get_static_delegate)});
      efl_orientation_flip_set_static_delegate = new efl_orientation_flip_set_delegate(flip_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_orientation_flip_set"), func = Marshal.GetFunctionPointerForDelegate(efl_orientation_flip_set_static_delegate)});
      evas_filter_changed_set_static_delegate = new evas_filter_changed_set_delegate(filter_changed_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "evas_filter_changed_set"), func = Marshal.GetFunctionPointerForDelegate(evas_filter_changed_set_static_delegate)});
      evas_filter_invalid_set_static_delegate = new evas_filter_invalid_set_delegate(filter_invalid_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "evas_filter_invalid_set"), func = Marshal.GetFunctionPointerForDelegate(evas_filter_invalid_set_static_delegate)});
      evas_filter_output_buffer_get_static_delegate = new evas_filter_output_buffer_get_delegate(filter_output_buffer_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "evas_filter_output_buffer_get"), func = Marshal.GetFunctionPointerForDelegate(evas_filter_output_buffer_get_static_delegate)});
      evas_filter_input_alpha_static_delegate = new evas_filter_input_alpha_delegate(filter_input_alpha);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "evas_filter_input_alpha"), func = Marshal.GetFunctionPointerForDelegate(evas_filter_input_alpha_static_delegate)});
      evas_filter_state_prepare_static_delegate = new evas_filter_state_prepare_delegate(filter_state_prepare);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "evas_filter_state_prepare"), func = Marshal.GetFunctionPointerForDelegate(evas_filter_state_prepare_static_delegate)});
      evas_filter_input_render_static_delegate = new evas_filter_input_render_delegate(filter_input_render);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "evas_filter_input_render"), func = Marshal.GetFunctionPointerForDelegate(evas_filter_input_render_static_delegate)});
      evas_filter_dirty_static_delegate = new evas_filter_dirty_delegate(filter_dirty);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "evas_filter_dirty"), func = Marshal.GetFunctionPointerForDelegate(evas_filter_dirty_static_delegate)});
      efl_gfx_buffer_size_get_static_delegate = new efl_gfx_buffer_size_get_delegate(buffer_size_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_buffer_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_buffer_size_get_static_delegate)});
      efl_gfx_buffer_size_set_static_delegate = new efl_gfx_buffer_size_set_delegate(buffer_size_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_buffer_size_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_buffer_size_set_static_delegate)});
      efl_gfx_buffer_colorspace_get_static_delegate = new efl_gfx_buffer_colorspace_get_delegate(colorspace_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_buffer_colorspace_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_buffer_colorspace_get_static_delegate)});
      efl_gfx_buffer_alpha_get_static_delegate = new efl_gfx_buffer_alpha_get_delegate(alpha_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_buffer_alpha_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_buffer_alpha_get_static_delegate)});
      efl_gfx_buffer_alpha_set_static_delegate = new efl_gfx_buffer_alpha_set_delegate(alpha_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_buffer_alpha_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_buffer_alpha_set_static_delegate)});
      efl_gfx_buffer_stride_get_static_delegate = new efl_gfx_buffer_stride_get_delegate(stride_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_buffer_stride_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_buffer_stride_get_static_delegate)});
      efl_gfx_buffer_borders_get_static_delegate = new efl_gfx_buffer_borders_get_delegate(buffer_borders_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_buffer_borders_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_buffer_borders_get_static_delegate)});
      efl_gfx_buffer_update_add_static_delegate = new efl_gfx_buffer_update_add_delegate(buffer_update_add);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_buffer_update_add"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_buffer_update_add_static_delegate)});
      efl_gfx_buffer_map_static_delegate = new efl_gfx_buffer_map_delegate(buffer_map);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_buffer_map"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_buffer_map_static_delegate)});
      efl_gfx_buffer_unmap_static_delegate = new efl_gfx_buffer_unmap_delegate(buffer_unmap);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_buffer_unmap"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_buffer_unmap_static_delegate)});
      efl_gfx_buffer_copy_set_static_delegate = new efl_gfx_buffer_copy_set_delegate(buffer_copy_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_buffer_copy_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_buffer_copy_set_static_delegate)});
      efl_gfx_buffer_managed_set_static_delegate = new efl_gfx_buffer_managed_set_delegate(buffer_managed_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_buffer_managed_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_buffer_managed_set_static_delegate)});
      efl_gfx_buffer_managed_get_static_delegate = new efl_gfx_buffer_managed_get_delegate(buffer_managed_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_buffer_managed_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_buffer_managed_get_static_delegate)});
      efl_gfx_fill_auto_get_static_delegate = new efl_gfx_fill_auto_get_delegate(fill_auto_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_fill_auto_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_fill_auto_get_static_delegate)});
      efl_gfx_fill_auto_set_static_delegate = new efl_gfx_fill_auto_set_delegate(fill_auto_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_fill_auto_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_fill_auto_set_static_delegate)});
      efl_gfx_fill_get_static_delegate = new efl_gfx_fill_get_delegate(fill_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_fill_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_fill_get_static_delegate)});
      efl_gfx_fill_set_static_delegate = new efl_gfx_fill_set_delegate(fill_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_fill_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_fill_set_static_delegate)});
      efl_gfx_filter_program_get_static_delegate = new efl_gfx_filter_program_get_delegate(filter_program_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_filter_program_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_filter_program_get_static_delegate)});
      efl_gfx_filter_program_set_static_delegate = new efl_gfx_filter_program_set_delegate(filter_program_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_filter_program_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_filter_program_set_static_delegate)});
      efl_gfx_filter_state_get_static_delegate = new efl_gfx_filter_state_get_delegate(filter_state_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_filter_state_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_filter_state_get_static_delegate)});
      efl_gfx_filter_state_set_static_delegate = new efl_gfx_filter_state_set_delegate(filter_state_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_filter_state_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_filter_state_set_static_delegate)});
      efl_gfx_filter_padding_get_static_delegate = new efl_gfx_filter_padding_get_delegate(filter_padding_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_filter_padding_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_filter_padding_get_static_delegate)});
      efl_gfx_filter_source_get_static_delegate = new efl_gfx_filter_source_get_delegate(filter_source_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_filter_source_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_filter_source_get_static_delegate)});
      efl_gfx_filter_source_set_static_delegate = new efl_gfx_filter_source_set_delegate(filter_source_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_filter_source_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_filter_source_set_static_delegate)});
      efl_gfx_filter_data_get_static_delegate = new efl_gfx_filter_data_get_delegate(filter_data_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_filter_data_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_filter_data_get_static_delegate)});
      efl_gfx_filter_data_set_static_delegate = new efl_gfx_filter_data_set_delegate(filter_data_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_filter_data_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_filter_data_set_static_delegate)});
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
      efl_gfx_view_size_get_static_delegate = new efl_gfx_view_size_get_delegate(view_size_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_view_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_view_size_get_static_delegate)});
      efl_gfx_view_size_set_static_delegate = new efl_gfx_view_size_set_delegate(view_size_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_view_size_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_view_size_set_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Canvas.ImageInternal.efl_canvas_image_internal_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Canvas.ImageInternal.efl_canvas_image_internal_class_get();
   }


    private delegate Efl.Gfx.ImageLoadError efl_file_load_error_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Efl.Gfx.ImageLoadError efl_file_load_error_get(System.IntPtr obj);
    private static Efl.Gfx.ImageLoadError load_error_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_file_load_error_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Gfx.ImageLoadError _ret_var = default(Efl.Gfx.ImageLoadError);
         try {
            _ret_var = ((ImageInternal)wrapper).GetLoadError();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_file_load_error_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_file_load_error_get_delegate efl_file_load_error_get_static_delegate;


    private delegate  void efl_file_mmap_get_delegate(System.IntPtr obj, System.IntPtr pd,   out Eina.File f,   out  System.IntPtr key);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_file_mmap_get(System.IntPtr obj,   out Eina.File f,   out  System.IntPtr key);
    private static  void mmap_get(System.IntPtr obj, System.IntPtr pd,  out Eina.File f,  out  System.IntPtr key)
   {
      Eina.Log.Debug("function efl_file_mmap_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           f = default(Eina.File);       System.String _out_key = default( System.String);
                     
         try {
            ((ImageInternal)wrapper).GetMmap( out f,  out _out_key);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            key= Efl.Eo.Globals.cached_string_to_intptr(((ImageInternal)wrapper).cached_strings, _out_key);
                        } else {
         efl_file_mmap_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out f,  out key);
      }
   }
   private efl_file_mmap_get_delegate efl_file_mmap_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_file_mmap_set_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.File f,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_file_mmap_set(System.IntPtr obj,   Eina.File f,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key);
    private static bool mmap_set(System.IntPtr obj, System.IntPtr pd,  Eina.File f,   System.String key)
   {
      Eina.Log.Debug("function efl_file_mmap_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      bool _ret_var = default(bool);
         try {
            _ret_var = ((ImageInternal)wrapper).SetMmap( f,  key);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_file_mmap_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  f,  key);
      }
   }
   private efl_file_mmap_set_delegate efl_file_mmap_set_static_delegate;


    private delegate  void efl_file_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  System.IntPtr file,   out  System.IntPtr key);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_file_get(System.IntPtr obj,   out  System.IntPtr file,   out  System.IntPtr key);
    private static  void file_get(System.IntPtr obj, System.IntPtr pd,  out  System.IntPtr file,  out  System.IntPtr key)
   {
      Eina.Log.Debug("function efl_file_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                            System.String _out_file = default( System.String);
       System.String _out_key = default( System.String);
                     
         try {
            ((ImageInternal)wrapper).GetFile( out _out_file,  out _out_key);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      file= Efl.Eo.Globals.cached_string_to_intptr(((ImageInternal)wrapper).cached_strings, _out_file);
      key= Efl.Eo.Globals.cached_string_to_intptr(((ImageInternal)wrapper).cached_strings, _out_key);
                        } else {
         efl_file_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out file,  out key);
      }
   }
   private efl_file_get_delegate efl_file_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_file_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String file,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_file_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String file,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key);
    private static bool file_set(System.IntPtr obj, System.IntPtr pd,   System.String file,   System.String key)
   {
      Eina.Log.Debug("function efl_file_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      bool _ret_var = default(bool);
         try {
            _ret_var = ((ImageInternal)wrapper).SetFile( file,  key);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_file_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  file,  key);
      }
   }
   private efl_file_set_delegate efl_file_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_file_save_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String file,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String flags);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_file_save(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String file,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String flags);
    private static bool save(System.IntPtr obj, System.IntPtr pd,   System.String file,   System.String key,   System.String flags)
   {
      Eina.Log.Debug("function efl_file_save was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                        bool _ret_var = default(bool);
         try {
            _ret_var = ((ImageInternal)wrapper).Save( file,  key,  flags);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                          return _ret_var;
      } else {
         return efl_file_save(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  file,  key,  flags);
      }
   }
   private efl_file_save_delegate efl_file_save_static_delegate;


    private delegate Efl.Orient efl_orientation_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Efl.Orient efl_orientation_get(System.IntPtr obj);
    private static Efl.Orient orientation_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_orientation_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Orient _ret_var = default(Efl.Orient);
         try {
            _ret_var = ((ImageInternal)wrapper).GetOrientation();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_orientation_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_orientation_get_delegate efl_orientation_get_static_delegate;


    private delegate  void efl_orientation_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Orient dir);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_orientation_set(System.IntPtr obj,   Efl.Orient dir);
    private static  void orientation_set(System.IntPtr obj, System.IntPtr pd,  Efl.Orient dir)
   {
      Eina.Log.Debug("function efl_orientation_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((ImageInternal)wrapper).SetOrientation( dir);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_orientation_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  dir);
      }
   }
   private efl_orientation_set_delegate efl_orientation_set_static_delegate;


    private delegate Efl.Flip efl_orientation_flip_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Efl.Flip efl_orientation_flip_get(System.IntPtr obj);
    private static Efl.Flip flip_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_orientation_flip_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Flip _ret_var = default(Efl.Flip);
         try {
            _ret_var = ((ImageInternal)wrapper).GetFlip();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_orientation_flip_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_orientation_flip_get_delegate efl_orientation_flip_get_static_delegate;


    private delegate  void efl_orientation_flip_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Flip flip);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_orientation_flip_set(System.IntPtr obj,   Efl.Flip flip);
    private static  void flip_set(System.IntPtr obj, System.IntPtr pd,  Efl.Flip flip)
   {
      Eina.Log.Debug("function efl_orientation_flip_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((ImageInternal)wrapper).SetFlip( flip);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_orientation_flip_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  flip);
      }
   }
   private efl_orientation_flip_set_delegate efl_orientation_flip_set_static_delegate;


    private delegate  void evas_filter_changed_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool val);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void evas_filter_changed_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool val);
    private static  void filter_changed_set(System.IntPtr obj, System.IntPtr pd,  bool val)
   {
      Eina.Log.Debug("function evas_filter_changed_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((ImageInternal)wrapper).SetFilterChanged( val);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         evas_filter_changed_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  val);
      }
   }
   private evas_filter_changed_set_delegate evas_filter_changed_set_static_delegate;


    private delegate  void evas_filter_invalid_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool val);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void evas_filter_invalid_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool val);
    private static  void filter_invalid_set(System.IntPtr obj, System.IntPtr pd,  bool val)
   {
      Eina.Log.Debug("function evas_filter_invalid_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((ImageInternal)wrapper).SetFilterInvalid( val);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         evas_filter_invalid_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  val);
      }
   }
   private evas_filter_invalid_set_delegate evas_filter_invalid_set_static_delegate;


    private delegate  System.IntPtr evas_filter_output_buffer_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  System.IntPtr evas_filter_output_buffer_get(System.IntPtr obj);
    private static  System.IntPtr filter_output_buffer_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function evas_filter_output_buffer_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.IntPtr _ret_var = default( System.IntPtr);
         try {
            _ret_var = ((ImageInternal)wrapper).GetFilterOutputBuffer();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return evas_filter_output_buffer_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private evas_filter_output_buffer_get_delegate evas_filter_output_buffer_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool evas_filter_input_alpha_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool evas_filter_input_alpha(System.IntPtr obj);
    private static bool filter_input_alpha(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function evas_filter_input_alpha was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((ImageInternal)wrapper).FilterInputAlpha();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return evas_filter_input_alpha(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private evas_filter_input_alpha_delegate evas_filter_input_alpha_static_delegate;


    private delegate  void evas_filter_state_prepare_delegate(System.IntPtr obj, System.IntPtr pd,   out Efl.Canvas.Filter.State_StructInternal state,    System.IntPtr data);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void evas_filter_state_prepare(System.IntPtr obj,   out Efl.Canvas.Filter.State_StructInternal state,    System.IntPtr data);
    private static  void filter_state_prepare(System.IntPtr obj, System.IntPtr pd,  out Efl.Canvas.Filter.State_StructInternal state,   System.IntPtr data)
   {
      Eina.Log.Debug("function evas_filter_state_prepare was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           Efl.Canvas.Filter.State _out_state = default(Efl.Canvas.Filter.State);
                           
         try {
            ((ImageInternal)wrapper).FilterStatePrepare( out _out_state,  data);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      state = Efl.Canvas.Filter.State_StructConversion.ToInternal(_out_state);
                              } else {
         evas_filter_state_prepare(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out state,  data);
      }
   }
   private evas_filter_state_prepare_delegate evas_filter_state_prepare_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool evas_filter_input_render_delegate(System.IntPtr obj, System.IntPtr pd,    System.IntPtr filter,    System.IntPtr engine,    System.IntPtr output,    System.IntPtr drawctx,    System.IntPtr data,    int l,    int r,    int t,    int b,    int x,    int y,  [MarshalAs(UnmanagedType.U1)]  bool do_async);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool evas_filter_input_render(System.IntPtr obj,    System.IntPtr filter,    System.IntPtr engine,    System.IntPtr output,    System.IntPtr drawctx,    System.IntPtr data,    int l,    int r,    int t,    int b,    int x,    int y,  [MarshalAs(UnmanagedType.U1)]  bool do_async);
    private static bool filter_input_render(System.IntPtr obj, System.IntPtr pd,   System.IntPtr filter,   System.IntPtr engine,   System.IntPtr output,   System.IntPtr drawctx,   System.IntPtr data,   int l,   int r,   int t,   int b,   int x,   int y,  bool do_async)
   {
      Eina.Log.Debug("function evas_filter_input_render was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                                                                                                                                                                          bool _ret_var = default(bool);
         try {
            _ret_var = ((ImageInternal)wrapper).FilterInputRender( filter,  engine,  output,  drawctx,  data,  l,  r,  t,  b,  x,  y,  do_async);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                                                                                                      return _ret_var;
      } else {
         return evas_filter_input_render(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  filter,  engine,  output,  drawctx,  data,  l,  r,  t,  b,  x,  y,  do_async);
      }
   }
   private evas_filter_input_render_delegate evas_filter_input_render_static_delegate;


    private delegate  void evas_filter_dirty_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void evas_filter_dirty(System.IntPtr obj);
    private static  void filter_dirty(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function evas_filter_dirty was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((ImageInternal)wrapper).FilterDirty();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         evas_filter_dirty(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private evas_filter_dirty_delegate evas_filter_dirty_static_delegate;


    private delegate Eina.Size2D_StructInternal efl_gfx_buffer_size_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Eina.Size2D_StructInternal efl_gfx_buffer_size_get(System.IntPtr obj);
    private static Eina.Size2D_StructInternal buffer_size_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_buffer_size_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Size2D _ret_var = default(Eina.Size2D);
         try {
            _ret_var = ((ImageInternal)wrapper).GetBufferSize();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Eina.Size2D_StructConversion.ToInternal(_ret_var);
      } else {
         return efl_gfx_buffer_size_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_buffer_size_get_delegate efl_gfx_buffer_size_get_static_delegate;


    private delegate  void efl_gfx_buffer_size_set_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Size2D_StructInternal sz);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_buffer_size_set(System.IntPtr obj,   Eina.Size2D_StructInternal sz);
    private static  void buffer_size_set(System.IntPtr obj, System.IntPtr pd,  Eina.Size2D_StructInternal sz)
   {
      Eina.Log.Debug("function efl_gfx_buffer_size_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_sz = Eina.Size2D_StructConversion.ToManaged(sz);
                     
         try {
            ((ImageInternal)wrapper).SetBufferSize( _in_sz);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_buffer_size_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  sz);
      }
   }
   private efl_gfx_buffer_size_set_delegate efl_gfx_buffer_size_set_static_delegate;


    private delegate Efl.Gfx.Colorspace efl_gfx_buffer_colorspace_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Efl.Gfx.Colorspace efl_gfx_buffer_colorspace_get(System.IntPtr obj);
    private static Efl.Gfx.Colorspace colorspace_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_buffer_colorspace_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Gfx.Colorspace _ret_var = default(Efl.Gfx.Colorspace);
         try {
            _ret_var = ((ImageInternal)wrapper).GetColorspace();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_buffer_colorspace_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_buffer_colorspace_get_delegate efl_gfx_buffer_colorspace_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_gfx_buffer_alpha_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_gfx_buffer_alpha_get(System.IntPtr obj);
    private static bool alpha_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_buffer_alpha_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((ImageInternal)wrapper).GetAlpha();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_buffer_alpha_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_buffer_alpha_get_delegate efl_gfx_buffer_alpha_get_static_delegate;


    private delegate  void efl_gfx_buffer_alpha_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool alpha);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_buffer_alpha_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool alpha);
    private static  void alpha_set(System.IntPtr obj, System.IntPtr pd,  bool alpha)
   {
      Eina.Log.Debug("function efl_gfx_buffer_alpha_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((ImageInternal)wrapper).SetAlpha( alpha);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_buffer_alpha_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  alpha);
      }
   }
   private efl_gfx_buffer_alpha_set_delegate efl_gfx_buffer_alpha_set_static_delegate;


    private delegate  int efl_gfx_buffer_stride_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  int efl_gfx_buffer_stride_get(System.IntPtr obj);
    private static  int stride_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_buffer_stride_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   int _ret_var = default( int);
         try {
            _ret_var = ((ImageInternal)wrapper).GetStride();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_buffer_stride_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_buffer_stride_get_delegate efl_gfx_buffer_stride_get_static_delegate;


    private delegate  void efl_gfx_buffer_borders_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  uint l,   out  uint r,   out  uint t,   out  uint b);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_buffer_borders_get(System.IntPtr obj,   out  uint l,   out  uint r,   out  uint t,   out  uint b);
    private static  void buffer_borders_get(System.IntPtr obj, System.IntPtr pd,  out  uint l,  out  uint r,  out  uint t,  out  uint b)
   {
      Eina.Log.Debug("function efl_gfx_buffer_borders_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                       l = default( uint);      r = default( uint);      t = default( uint);      b = default( uint);                                 
         try {
            ((ImageInternal)wrapper).GetBufferBorders( out l,  out r,  out t,  out b);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_gfx_buffer_borders_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out l,  out r,  out t,  out b);
      }
   }
   private efl_gfx_buffer_borders_get_delegate efl_gfx_buffer_borders_get_static_delegate;


    private delegate  void efl_gfx_buffer_update_add_delegate(System.IntPtr obj, System.IntPtr pd,   ref Eina.Rect_StructInternal region);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_buffer_update_add(System.IntPtr obj,   ref Eina.Rect_StructInternal region);
    private static  void buffer_update_add(System.IntPtr obj, System.IntPtr pd,  ref Eina.Rect_StructInternal region)
   {
      Eina.Log.Debug("function efl_gfx_buffer_update_add was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_region = Eina.Rect_StructConversion.ToManaged(region);
                     
         try {
            ((ImageInternal)wrapper).AddBufferUpdate( ref _in_region);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            region = Eina.Rect_StructConversion.ToInternal(_in_region);
            } else {
         efl_gfx_buffer_update_add(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  ref region);
      }
   }
   private efl_gfx_buffer_update_add_delegate efl_gfx_buffer_update_add_static_delegate;


    private delegate Eina.RwSlice efl_gfx_buffer_map_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Gfx.BufferAccessMode mode,   ref Eina.Rect_StructInternal region,   Efl.Gfx.Colorspace cspace,    int plane,   out  int stride);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Eina.RwSlice efl_gfx_buffer_map(System.IntPtr obj,   Efl.Gfx.BufferAccessMode mode,   ref Eina.Rect_StructInternal region,   Efl.Gfx.Colorspace cspace,    int plane,   out  int stride);
    private static Eina.RwSlice buffer_map(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.BufferAccessMode mode,  ref Eina.Rect_StructInternal region,  Efl.Gfx.Colorspace cspace,   int plane,  out  int stride)
   {
      Eina.Log.Debug("function efl_gfx_buffer_map was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                     var _in_region = Eina.Rect_StructConversion.ToManaged(region);
                                                stride = default( int);                                       Eina.RwSlice _ret_var = default(Eina.RwSlice);
         try {
            _ret_var = ((ImageInternal)wrapper).BufferMap( mode,  ref _in_region,  cspace,  plane,  out stride);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                          region = Eina.Rect_StructConversion.ToInternal(_in_region);
                        return _ret_var;
      } else {
         return efl_gfx_buffer_map(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  mode,  ref region,  cspace,  plane,  out stride);
      }
   }
   private efl_gfx_buffer_map_delegate efl_gfx_buffer_map_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_gfx_buffer_unmap_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.RwSlice slice);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_gfx_buffer_unmap(System.IntPtr obj,   Eina.RwSlice slice);
    private static bool buffer_unmap(System.IntPtr obj, System.IntPtr pd,  Eina.RwSlice slice)
   {
      Eina.Log.Debug("function efl_gfx_buffer_unmap was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((ImageInternal)wrapper).BufferUnmap( slice);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_gfx_buffer_unmap(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  slice);
      }
   }
   private efl_gfx_buffer_unmap_delegate efl_gfx_buffer_unmap_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_gfx_buffer_copy_set_delegate(System.IntPtr obj, System.IntPtr pd,    System.IntPtr slice,   Eina.Size2D_StructInternal size,    int stride,   Efl.Gfx.Colorspace cspace,    int plane);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_gfx_buffer_copy_set(System.IntPtr obj,    System.IntPtr slice,   Eina.Size2D_StructInternal size,    int stride,   Efl.Gfx.Colorspace cspace,    int plane);
    private static bool buffer_copy_set(System.IntPtr obj, System.IntPtr pd,   System.IntPtr slice,  Eina.Size2D_StructInternal size,   int stride,  Efl.Gfx.Colorspace cspace,   int plane)
   {
      Eina.Log.Debug("function efl_gfx_buffer_copy_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_slice = Eina.PrimitiveConversion.PointerToManaged<Eina.Slice>(slice);
      var _in_size = Eina.Size2D_StructConversion.ToManaged(size);
                                                                                       bool _ret_var = default(bool);
         try {
            _ret_var = ((ImageInternal)wrapper).SetBufferCopy( _in_slice,  _in_size,  stride,  cspace,  plane);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                  return _ret_var;
      } else {
         return efl_gfx_buffer_copy_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  slice,  size,  stride,  cspace,  plane);
      }
   }
   private efl_gfx_buffer_copy_set_delegate efl_gfx_buffer_copy_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_gfx_buffer_managed_set_delegate(System.IntPtr obj, System.IntPtr pd,    System.IntPtr slice,   Eina.Size2D_StructInternal size,    int stride,   Efl.Gfx.Colorspace cspace,    int plane);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_gfx_buffer_managed_set(System.IntPtr obj,    System.IntPtr slice,   Eina.Size2D_StructInternal size,    int stride,   Efl.Gfx.Colorspace cspace,    int plane);
    private static bool buffer_managed_set(System.IntPtr obj, System.IntPtr pd,   System.IntPtr slice,  Eina.Size2D_StructInternal size,   int stride,  Efl.Gfx.Colorspace cspace,   int plane)
   {
      Eina.Log.Debug("function efl_gfx_buffer_managed_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_slice = Eina.PrimitiveConversion.PointerToManaged<Eina.Slice>(slice);
      var _in_size = Eina.Size2D_StructConversion.ToManaged(size);
                                                                                       bool _ret_var = default(bool);
         try {
            _ret_var = ((ImageInternal)wrapper).SetBufferManaged( _in_slice,  _in_size,  stride,  cspace,  plane);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                  return _ret_var;
      } else {
         return efl_gfx_buffer_managed_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  slice,  size,  stride,  cspace,  plane);
      }
   }
   private efl_gfx_buffer_managed_set_delegate efl_gfx_buffer_managed_set_static_delegate;


    private delegate Eina.Slice efl_gfx_buffer_managed_get_delegate(System.IntPtr obj, System.IntPtr pd,    int plane);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Eina.Slice efl_gfx_buffer_managed_get(System.IntPtr obj,    int plane);
    private static Eina.Slice buffer_managed_get(System.IntPtr obj, System.IntPtr pd,   int plane)
   {
      Eina.Log.Debug("function efl_gfx_buffer_managed_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    Eina.Slice _ret_var = default(Eina.Slice);
         try {
            _ret_var = ((ImageInternal)wrapper).GetBufferManaged( plane);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_gfx_buffer_managed_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  plane);
      }
   }
   private efl_gfx_buffer_managed_get_delegate efl_gfx_buffer_managed_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_gfx_fill_auto_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_gfx_fill_auto_get(System.IntPtr obj);
    private static bool fill_auto_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_fill_auto_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((ImageInternal)wrapper).GetFillAuto();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_fill_auto_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_fill_auto_get_delegate efl_gfx_fill_auto_get_static_delegate;


    private delegate  void efl_gfx_fill_auto_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool filled);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_fill_auto_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool filled);
    private static  void fill_auto_set(System.IntPtr obj, System.IntPtr pd,  bool filled)
   {
      Eina.Log.Debug("function efl_gfx_fill_auto_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((ImageInternal)wrapper).SetFillAuto( filled);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_fill_auto_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  filled);
      }
   }
   private efl_gfx_fill_auto_set_delegate efl_gfx_fill_auto_set_static_delegate;


    private delegate Eina.Rect_StructInternal efl_gfx_fill_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Eina.Rect_StructInternal efl_gfx_fill_get(System.IntPtr obj);
    private static Eina.Rect_StructInternal fill_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_fill_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Rect _ret_var = default(Eina.Rect);
         try {
            _ret_var = ((ImageInternal)wrapper).GetFill();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Eina.Rect_StructConversion.ToInternal(_ret_var);
      } else {
         return efl_gfx_fill_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_fill_get_delegate efl_gfx_fill_get_static_delegate;


    private delegate  void efl_gfx_fill_set_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Rect_StructInternal fill);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_fill_set(System.IntPtr obj,   Eina.Rect_StructInternal fill);
    private static  void fill_set(System.IntPtr obj, System.IntPtr pd,  Eina.Rect_StructInternal fill)
   {
      Eina.Log.Debug("function efl_gfx_fill_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_fill = Eina.Rect_StructConversion.ToManaged(fill);
                     
         try {
            ((ImageInternal)wrapper).SetFill( _in_fill);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_fill_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  fill);
      }
   }
   private efl_gfx_fill_set_delegate efl_gfx_fill_set_static_delegate;


    private delegate  void efl_gfx_filter_program_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  System.IntPtr code,   out  System.IntPtr name);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_filter_program_get(System.IntPtr obj,   out  System.IntPtr code,   out  System.IntPtr name);
    private static  void filter_program_get(System.IntPtr obj, System.IntPtr pd,  out  System.IntPtr code,  out  System.IntPtr name)
   {
      Eina.Log.Debug("function efl_gfx_filter_program_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                            System.String _out_code = default( System.String);
       System.String _out_name = default( System.String);
                     
         try {
            ((ImageInternal)wrapper).GetFilterProgram( out _out_code,  out _out_name);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      code= Efl.Eo.Globals.cached_string_to_intptr(((ImageInternal)wrapper).cached_strings, _out_code);
      name= Efl.Eo.Globals.cached_string_to_intptr(((ImageInternal)wrapper).cached_strings, _out_name);
                        } else {
         efl_gfx_filter_program_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out code,  out name);
      }
   }
   private efl_gfx_filter_program_get_delegate efl_gfx_filter_program_get_static_delegate;


    private delegate  void efl_gfx_filter_program_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String code,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_filter_program_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String code,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name);
    private static  void filter_program_set(System.IntPtr obj, System.IntPtr pd,   System.String code,   System.String name)
   {
      Eina.Log.Debug("function efl_gfx_filter_program_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((ImageInternal)wrapper).SetFilterProgram( code,  name);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_gfx_filter_program_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  code,  name);
      }
   }
   private efl_gfx_filter_program_set_delegate efl_gfx_filter_program_set_static_delegate;


    private delegate  void efl_gfx_filter_state_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  System.IntPtr cur_state,   out double cur_val,   out  System.IntPtr next_state,   out double next_val,   out double pos);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_filter_state_get(System.IntPtr obj,   out  System.IntPtr cur_state,   out double cur_val,   out  System.IntPtr next_state,   out double next_val,   out double pos);
    private static  void filter_state_get(System.IntPtr obj, System.IntPtr pd,  out  System.IntPtr cur_state,  out double cur_val,  out  System.IntPtr next_state,  out double next_val,  out double pos)
   {
      Eina.Log.Debug("function efl_gfx_filter_state_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                              System.String _out_cur_state = default( System.String);
      cur_val = default(double);       System.String _out_next_state = default( System.String);
      next_val = default(double);      pos = default(double);                                       
         try {
            ((ImageInternal)wrapper).GetFilterState( out _out_cur_state,  out cur_val,  out _out_next_state,  out next_val,  out pos);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      cur_state= Efl.Eo.Globals.cached_string_to_intptr(((ImageInternal)wrapper).cached_strings, _out_cur_state);
            next_state= Efl.Eo.Globals.cached_string_to_intptr(((ImageInternal)wrapper).cached_strings, _out_next_state);
                                                      } else {
         efl_gfx_filter_state_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out cur_state,  out cur_val,  out next_state,  out next_val,  out pos);
      }
   }
   private efl_gfx_filter_state_get_delegate efl_gfx_filter_state_get_static_delegate;


    private delegate  void efl_gfx_filter_state_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String cur_state,   double cur_val,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String next_state,   double next_val,   double pos);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_filter_state_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String cur_state,   double cur_val,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String next_state,   double next_val,   double pos);
    private static  void filter_state_set(System.IntPtr obj, System.IntPtr pd,   System.String cur_state,  double cur_val,   System.String next_state,  double next_val,  double pos)
   {
      Eina.Log.Debug("function efl_gfx_filter_state_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                                            
         try {
            ((ImageInternal)wrapper).SetFilterState( cur_state,  cur_val,  next_state,  next_val,  pos);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                        } else {
         efl_gfx_filter_state_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur_state,  cur_val,  next_state,  next_val,  pos);
      }
   }
   private efl_gfx_filter_state_set_delegate efl_gfx_filter_state_set_static_delegate;


    private delegate  void efl_gfx_filter_padding_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  int l,   out  int r,   out  int t,   out  int b);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_filter_padding_get(System.IntPtr obj,   out  int l,   out  int r,   out  int t,   out  int b);
    private static  void filter_padding_get(System.IntPtr obj, System.IntPtr pd,  out  int l,  out  int r,  out  int t,  out  int b)
   {
      Eina.Log.Debug("function efl_gfx_filter_padding_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                       l = default( int);      r = default( int);      t = default( int);      b = default( int);                                 
         try {
            ((ImageInternal)wrapper).GetFilterPadding( out l,  out r,  out t,  out b);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_gfx_filter_padding_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out l,  out r,  out t,  out b);
      }
   }
   private efl_gfx_filter_padding_get_delegate efl_gfx_filter_padding_get_static_delegate;


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.Gfx.Entity efl_gfx_filter_source_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))] private static extern Efl.Gfx.Entity efl_gfx_filter_source_get(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name);
    private static Efl.Gfx.Entity filter_source_get(System.IntPtr obj, System.IntPtr pd,   System.String name)
   {
      Eina.Log.Debug("function efl_gfx_filter_source_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    Efl.Gfx.Entity _ret_var = default(Efl.Gfx.Entity);
         try {
            _ret_var = ((ImageInternal)wrapper).GetFilterSource( name);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_gfx_filter_source_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  name);
      }
   }
   private efl_gfx_filter_source_get_delegate efl_gfx_filter_source_get_static_delegate;


    private delegate  void efl_gfx_filter_source_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity source);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_filter_source_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity source);
    private static  void filter_source_set(System.IntPtr obj, System.IntPtr pd,   System.String name,  Efl.Gfx.Entity source)
   {
      Eina.Log.Debug("function efl_gfx_filter_source_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((ImageInternal)wrapper).SetFilterSource( name,  source);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_gfx_filter_source_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  name,  source);
      }
   }
   private efl_gfx_filter_source_set_delegate efl_gfx_filter_source_set_static_delegate;


    private delegate  void efl_gfx_filter_data_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name,   out  System.IntPtr value,  [MarshalAs(UnmanagedType.U1)]  out bool execute);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_filter_data_get(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name,   out  System.IntPtr value,  [MarshalAs(UnmanagedType.U1)]  out bool execute);
    private static  void filter_data_get(System.IntPtr obj, System.IntPtr pd,   System.String name,  out  System.IntPtr value,  out bool execute)
   {
      Eina.Log.Debug("function efl_gfx_filter_data_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                        System.String _out_value = default( System.String);
      execute = default(bool);                           
         try {
            ((ImageInternal)wrapper).GetFilterData( name,  out _out_value,  out execute);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            value= Efl.Eo.Globals.cached_string_to_intptr(((ImageInternal)wrapper).cached_strings, _out_value);
                                    } else {
         efl_gfx_filter_data_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  name,  out value,  out execute);
      }
   }
   private efl_gfx_filter_data_get_delegate efl_gfx_filter_data_get_static_delegate;


    private delegate  void efl_gfx_filter_data_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String value,  [MarshalAs(UnmanagedType.U1)]  bool execute);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_filter_data_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String value,  [MarshalAs(UnmanagedType.U1)]  bool execute);
    private static  void filter_data_set(System.IntPtr obj, System.IntPtr pd,   System.String name,   System.String value,  bool execute)
   {
      Eina.Log.Debug("function efl_gfx_filter_data_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                        
         try {
            ((ImageInternal)wrapper).SetFilterData( name,  value,  execute);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                } else {
         efl_gfx_filter_data_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  name,  value,  execute);
      }
   }
   private efl_gfx_filter_data_set_delegate efl_gfx_filter_data_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_gfx_image_smooth_scale_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_gfx_image_smooth_scale_get(System.IntPtr obj);
    private static bool smooth_scale_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_image_smooth_scale_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((ImageInternal)wrapper).GetSmoothScale();
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
            ((ImageInternal)wrapper).SetSmoothScale( smooth_scale);
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
            _ret_var = ((ImageInternal)wrapper).GetScaleType();
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
            ((ImageInternal)wrapper).SetScaleType( scale_type);
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
            _ret_var = ((ImageInternal)wrapper).GetRatio();
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
            ((ImageInternal)wrapper).GetBorder( out l,  out r,  out t,  out b);
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
            ((ImageInternal)wrapper).SetBorder( l,  r,  t,  b);
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
            _ret_var = ((ImageInternal)wrapper).GetBorderScale();
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
            ((ImageInternal)wrapper).SetBorderScale( scale);
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
            _ret_var = ((ImageInternal)wrapper).GetBorderCenterFill();
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
            ((ImageInternal)wrapper).SetBorderCenterFill( fill);
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
            _ret_var = ((ImageInternal)wrapper).GetImageSize();
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
            _ret_var = ((ImageInternal)wrapper).GetContentHint();
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
            ((ImageInternal)wrapper).SetContentHint( hint);
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
            _ret_var = ((ImageInternal)wrapper).GetScaleHint();
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
            ((ImageInternal)wrapper).SetScaleHint( hint);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_image_scale_hint_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  hint);
      }
   }
   private efl_gfx_image_scale_hint_set_delegate efl_gfx_image_scale_hint_set_static_delegate;


    private delegate Eina.Size2D_StructInternal efl_gfx_view_size_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Eina.Size2D_StructInternal efl_gfx_view_size_get(System.IntPtr obj);
    private static Eina.Size2D_StructInternal view_size_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_view_size_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Size2D _ret_var = default(Eina.Size2D);
         try {
            _ret_var = ((ImageInternal)wrapper).GetViewSize();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Eina.Size2D_StructConversion.ToInternal(_ret_var);
      } else {
         return efl_gfx_view_size_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_view_size_get_delegate efl_gfx_view_size_get_static_delegate;


    private delegate  void efl_gfx_view_size_set_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Size2D_StructInternal size);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_view_size_set(System.IntPtr obj,   Eina.Size2D_StructInternal size);
    private static  void view_size_set(System.IntPtr obj, System.IntPtr pd,  Eina.Size2D_StructInternal size)
   {
      Eina.Log.Debug("function efl_gfx_view_size_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_size = Eina.Size2D_StructConversion.ToManaged(size);
                     
         try {
            ((ImageInternal)wrapper).SetViewSize( _in_size);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_view_size_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  size);
      }
   }
   private efl_gfx_view_size_set_delegate efl_gfx_view_size_set_static_delegate;
}
} } 
