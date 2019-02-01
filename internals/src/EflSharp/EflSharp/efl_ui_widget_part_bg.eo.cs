#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary>Elementary widget internal part background class</summary>
[WidgetPartBgNativeInherit]
public class WidgetPartBg : Efl.Ui.WidgetPart, Efl.Eo.IWrapper,Efl.File,Efl.Gfx.Color,Efl.Gfx.Image
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Ui.WidgetPartBgNativeInherit nativeInherit = new Efl.Ui.WidgetPartBgNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (WidgetPartBg))
            return Efl.Ui.WidgetPartBgNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   ///<summary>Delegate for function to be called from inside the native constructor.</summary>
   public new delegate void ConstructingMethod(WidgetPartBg obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
      efl_ui_widget_part_bg_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="init_cb">Delegate to call constructing methods that should be run inside the constructor.</param>
   public WidgetPartBg(Efl.Object parent = null, ConstructingMethod init_cb=null) : base("WidgetPartBg", efl_ui_widget_part_bg_class_get(), typeof(WidgetPartBg), parent)
   {
      if (init_cb != null) {
         init_cb(this);
      }
      FinishInstantiation();
   }
   ///<summary>Internal constructor to forward the wrapper initialization to the root class.</summary>
   protected WidgetPartBg(String klass_name, IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(klass_name, base_klass, managed_type, parent) {}
   ///<summary>Constructs an instance from a native pointer.</summary>
   public WidgetPartBg(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static WidgetPartBg static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new WidgetPartBg(obj.NativeHandle);
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

private static object ResizeEvtKey = new object();
   /// <summary>Image was resized (its pixel data).</summary>
   public event EventHandler ResizeEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_GFX_IMAGE_EVENT_RESIZE";
            if (add_cpp_event_handler(key, this.evt_ResizeEvt_delegate)) {
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
      evt_ResizeEvt_delegate = new Efl.EventCb(on_ResizeEvt_NativeCallback);
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
    protected static extern  void efl_gfx_color_get(System.IntPtr obj,   out  int r,   out  int g,   out  int b,   out  int a);
   /// <summary>Retrieves the general/main color of the given Evas object.
   /// Retrieves the main color&apos;s RGB component (and alpha channel) values, which range from 0 to 255. For the alpha channel, which defines the object&apos;s transparency level, 0 means totally transparent, while 255 means opaque. These color values are premultiplied by the alpha value.
   /// 
   /// Usually youll use this attribute for text and rectangle objects, where the main color is their unique one. If set for objects which themselves have colors, like the images one, those colors get modulated by this one.
   /// 
   /// All newly created Evas rectangles get the default color values of 255 255 255 255 (opaque white).
   /// 
   /// Use null pointers on the components you&apos;re not interested in: they&apos;ll be ignored by the function.</summary>
   /// <param name="r"></param>
   /// <param name="g"></param>
   /// <param name="b"></param>
   /// <param name="a"></param>
   /// <returns></returns>
   virtual public  void GetColor( out  int r,  out  int g,  out  int b,  out  int a) {
                                                                               efl_gfx_color_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  out r,  out g,  out b,  out a);
      Eina.Error.RaiseIfUnhandledException();
                                                       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_color_set(System.IntPtr obj,    int r,    int g,    int b,    int a);
   /// <summary>Sets the general/main color of the given Evas object to the given one.
   /// See also <see cref="Efl.Gfx.Color.GetColor"/> (for an example)
   /// 
   /// These color values are expected to be premultiplied by alpha.</summary>
   /// <param name="r"></param>
   /// <param name="g"></param>
   /// <param name="b"></param>
   /// <param name="a"></param>
   /// <returns></returns>
   virtual public  void SetColor(  int r,   int g,   int b,   int a) {
                                                                               efl_gfx_color_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  r,  g,  b,  a);
      Eina.Error.RaiseIfUnhandledException();
                                                       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] protected static extern  System.String efl_gfx_color_code_get(System.IntPtr obj);
   /// <summary>Get hex color code of given Evas object. This returns a short lived hex color code string.</summary>
   /// <returns>the hex color code.</returns>
   virtual public  System.String GetColorCode() {
       var _ret_var = efl_gfx_color_code_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_color_code_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String colorcode);
   /// <summary>Set the color of given Evas object to the given hex color code(#RRGGBBAA). e.g. efl_gfx_color_code_set(obj, &quot;#FFCCAACC&quot;);</summary>
   /// <param name="colorcode">the hex color code.</param>
   /// <returns></returns>
   virtual public  void SetColorCode(  System.String colorcode) {
                         efl_gfx_color_code_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  colorcode);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] protected static extern  System.String efl_gfx_color_class_code_get(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String color_class,   Efl.Gfx.ColorClassLayer layer);
   /// <summary>Get hex color class code of given Evas Object. This returns a short lived hex color class code string.</summary>
   /// <param name="color_class">The name of color class</param>
   /// <param name="layer">The layer to set the color</param>
   /// <returns>the hex color code.</returns>
   virtual public  System.String GetColorClassCode(  System.String color_class,  Efl.Gfx.ColorClassLayer layer) {
                                           var _ret_var = efl_gfx_color_class_code_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  color_class,  layer);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_color_class_code_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String color_class,   Efl.Gfx.ColorClassLayer layer,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String colorcode);
   /// <summary>Set the color class color of given Evas Object to the given hex color code(#RRGGBBAA). e.g. efl_gfx_color_class_code_set(obj, &quot;color_class_name&quot;, layer, &quot;#FFCCAACC&quot;);</summary>
   /// <param name="color_class">The name of color class</param>
   /// <param name="layer">The layer to set the color</param>
   /// <param name="colorcode">the hex color code.</param>
   /// <returns></returns>
   virtual public  void SetColorClassCode(  System.String color_class,  Efl.Gfx.ColorClassLayer layer,   System.String colorcode) {
                                                             efl_gfx_color_class_code_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  color_class,  layer,  colorcode);
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
   /// <summary>Gets the (last) file loading error for a given object.</summary>
   public Efl.Gfx.ImageLoadError LoadError {
      get { return GetLoadError(); }
   }
   /// <summary>Get hex color code of given Evas object. This returns a short lived hex color code string.</summary>
   public  System.String ColorCode {
      get { return GetColorCode(); }
      set { SetColorCode( value); }
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
}
public class WidgetPartBgNativeInherit : Efl.Ui.WidgetPartNativeInherit{
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
      efl_gfx_color_get_static_delegate = new efl_gfx_color_get_delegate(color_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_color_get_static_delegate)});
      efl_gfx_color_set_static_delegate = new efl_gfx_color_set_delegate(color_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_color_set_static_delegate)});
      efl_gfx_color_code_get_static_delegate = new efl_gfx_color_code_get_delegate(color_code_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_color_code_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_color_code_get_static_delegate)});
      efl_gfx_color_code_set_static_delegate = new efl_gfx_color_code_set_delegate(color_code_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_color_code_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_color_code_set_static_delegate)});
      efl_gfx_color_class_code_get_static_delegate = new efl_gfx_color_class_code_get_delegate(color_class_code_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_color_class_code_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_color_class_code_get_static_delegate)});
      efl_gfx_color_class_code_set_static_delegate = new efl_gfx_color_class_code_set_delegate(color_class_code_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_color_class_code_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_color_class_code_set_static_delegate)});
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
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Ui.WidgetPartBg.efl_ui_widget_part_bg_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.WidgetPartBg.efl_ui_widget_part_bg_class_get();
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
            _ret_var = ((WidgetPartBg)wrapper).GetLoadError();
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
            ((WidgetPartBg)wrapper).GetMmap( out f,  out _out_key);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            key= Efl.Eo.Globals.cached_string_to_intptr(((WidgetPartBg)wrapper).cached_strings, _out_key);
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
            _ret_var = ((WidgetPartBg)wrapper).SetMmap( f,  key);
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
            ((WidgetPartBg)wrapper).GetFile( out _out_file,  out _out_key);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      file= Efl.Eo.Globals.cached_string_to_intptr(((WidgetPartBg)wrapper).cached_strings, _out_file);
      key= Efl.Eo.Globals.cached_string_to_intptr(((WidgetPartBg)wrapper).cached_strings, _out_key);
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
            _ret_var = ((WidgetPartBg)wrapper).SetFile( file,  key);
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
            _ret_var = ((WidgetPartBg)wrapper).Save( file,  key,  flags);
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


    private delegate  void efl_gfx_color_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  int r,   out  int g,   out  int b,   out  int a);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_color_get(System.IntPtr obj,   out  int r,   out  int g,   out  int b,   out  int a);
    private static  void color_get(System.IntPtr obj, System.IntPtr pd,  out  int r,  out  int g,  out  int b,  out  int a)
   {
      Eina.Log.Debug("function efl_gfx_color_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                       r = default( int);      g = default( int);      b = default( int);      a = default( int);                                 
         try {
            ((WidgetPartBg)wrapper).GetColor( out r,  out g,  out b,  out a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_gfx_color_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out r,  out g,  out b,  out a);
      }
   }
   private efl_gfx_color_get_delegate efl_gfx_color_get_static_delegate;


    private delegate  void efl_gfx_color_set_delegate(System.IntPtr obj, System.IntPtr pd,    int r,    int g,    int b,    int a);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_color_set(System.IntPtr obj,    int r,    int g,    int b,    int a);
    private static  void color_set(System.IntPtr obj, System.IntPtr pd,   int r,   int g,   int b,   int a)
   {
      Eina.Log.Debug("function efl_gfx_color_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                          
         try {
            ((WidgetPartBg)wrapper).SetColor( r,  g,  b,  a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_gfx_color_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  r,  g,  b,  a);
      }
   }
   private efl_gfx_color_set_delegate efl_gfx_color_set_static_delegate;


    private delegate  System.IntPtr efl_gfx_color_code_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  System.IntPtr efl_gfx_color_code_get(System.IntPtr obj);
    private static  System.IntPtr color_code_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_color_code_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((WidgetPartBg)wrapper).GetColorCode();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Efl.Eo.Globals.cached_string_to_intptr(((WidgetPartBg)wrapper).cached_strings, _ret_var);
      } else {
         return efl_gfx_color_code_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_color_code_get_delegate efl_gfx_color_code_get_static_delegate;


    private delegate  void efl_gfx_color_code_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String colorcode);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_color_code_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String colorcode);
    private static  void color_code_set(System.IntPtr obj, System.IntPtr pd,   System.String colorcode)
   {
      Eina.Log.Debug("function efl_gfx_color_code_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((WidgetPartBg)wrapper).SetColorCode( colorcode);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_color_code_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  colorcode);
      }
   }
   private efl_gfx_color_code_set_delegate efl_gfx_color_code_set_static_delegate;


    private delegate  System.IntPtr efl_gfx_color_class_code_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String color_class,   Efl.Gfx.ColorClassLayer layer);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  System.IntPtr efl_gfx_color_class_code_get(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String color_class,   Efl.Gfx.ColorClassLayer layer);
    private static  System.IntPtr color_class_code_get(System.IntPtr obj, System.IntPtr pd,   System.String color_class,  Efl.Gfx.ColorClassLayer layer)
   {
      Eina.Log.Debug("function efl_gfx_color_class_code_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                       System.String _ret_var = default( System.String);
         try {
            _ret_var = ((WidgetPartBg)wrapper).GetColorClassCode( color_class,  layer);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return Efl.Eo.Globals.cached_string_to_intptr(((WidgetPartBg)wrapper).cached_strings, _ret_var);
      } else {
         return efl_gfx_color_class_code_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  color_class,  layer);
      }
   }
   private efl_gfx_color_class_code_get_delegate efl_gfx_color_class_code_get_static_delegate;


    private delegate  void efl_gfx_color_class_code_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String color_class,   Efl.Gfx.ColorClassLayer layer,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String colorcode);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_color_class_code_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String color_class,   Efl.Gfx.ColorClassLayer layer,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String colorcode);
    private static  void color_class_code_set(System.IntPtr obj, System.IntPtr pd,   System.String color_class,  Efl.Gfx.ColorClassLayer layer,   System.String colorcode)
   {
      Eina.Log.Debug("function efl_gfx_color_class_code_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                        
         try {
            ((WidgetPartBg)wrapper).SetColorClassCode( color_class,  layer,  colorcode);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                } else {
         efl_gfx_color_class_code_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  color_class,  layer,  colorcode);
      }
   }
   private efl_gfx_color_class_code_set_delegate efl_gfx_color_class_code_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_gfx_image_smooth_scale_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_gfx_image_smooth_scale_get(System.IntPtr obj);
    private static bool smooth_scale_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_image_smooth_scale_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((WidgetPartBg)wrapper).GetSmoothScale();
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
            ((WidgetPartBg)wrapper).SetSmoothScale( smooth_scale);
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
            _ret_var = ((WidgetPartBg)wrapper).GetScaleType();
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
            ((WidgetPartBg)wrapper).SetScaleType( scale_type);
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
            _ret_var = ((WidgetPartBg)wrapper).GetRatio();
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
            ((WidgetPartBg)wrapper).GetBorder( out l,  out r,  out t,  out b);
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
            ((WidgetPartBg)wrapper).SetBorder( l,  r,  t,  b);
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
            _ret_var = ((WidgetPartBg)wrapper).GetBorderScale();
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
            ((WidgetPartBg)wrapper).SetBorderScale( scale);
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
            _ret_var = ((WidgetPartBg)wrapper).GetBorderCenterFill();
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
            ((WidgetPartBg)wrapper).SetBorderCenterFill( fill);
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
            _ret_var = ((WidgetPartBg)wrapper).GetImageSize();
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
            _ret_var = ((WidgetPartBg)wrapper).GetContentHint();
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
            ((WidgetPartBg)wrapper).SetContentHint( hint);
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
            _ret_var = ((WidgetPartBg)wrapper).GetScaleHint();
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
            ((WidgetPartBg)wrapper).SetScaleHint( hint);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_image_scale_hint_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  hint);
      }
   }
   private efl_gfx_image_scale_hint_set_delegate efl_gfx_image_scale_hint_set_static_delegate;
}
} } 
