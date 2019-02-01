#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { 
/// <summary>Efl file interface</summary>
[FileConcreteNativeInherit]
public interface File : 
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>Gets the (last) file loading error for a given object.</summary>
/// <returns>The load error code.</returns>
Efl.Gfx.ImageLoadError GetLoadError();
   /// <summary>Get the source mmaped file from where an image object must fetch the real image data (it must be an Eina_File).
/// If the file supports multiple data stored in it (as Eet files do), you can get the key to be used as the index of the image in this file.
/// 1.10</summary>
/// <param name="f">The handler to an Eina_File that will be used as image source</param>
/// <param name="key">The group that the image belongs to, in case  it&apos;s an EET(including Edje case) file. This can be used as a key inside evas image cache if this is a normal image file not eet file.</param>
/// <returns></returns>
 void GetMmap( out Eina.File f,  out  System.String key);
   /// <summary>Set the source mmaped file from where an image object must fetch the real image data (it must be an Eina_File).
/// If the file supports multiple data stored in it (as Eet files do), you can specify the key to be used as the index of the image in this file.
/// 1.8</summary>
/// <param name="f">The handler to an Eina_File that will be used as image source</param>
/// <param name="key">The group that the image belongs to, in case  it&apos;s an EET(including Edje case) file. This can be used as a key inside evas image cache if this is a normal image file not eet file.</param>
/// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
bool SetMmap( Eina.File f,   System.String key);
   /// <summary>Retrieve the source file from where an image object is to fetch the real image data (it may be an Eet file, besides pure image ones).
/// You must not modify the strings on the returned pointers.
/// 
/// Note: Use <c>null</c> pointers on the file components you&apos;re not interested in: they&apos;ll be ignored by the function.</summary>
/// <param name="file">The image file path.</param>
/// <param name="key">The image key in <c>file</c> (if its an Eet one), or <c>null</c>, otherwise.</param>
/// <returns></returns>
 void GetFile( out  System.String file,  out  System.String key);
   /// <summary>Set the source file from where an image object must fetch the real image data (it may be an Eet file, besides pure image ones).
/// If the file supports multiple data stored in it (as Eet files do), you can specify the key to be used as the index of the image in this file.</summary>
/// <param name="file">The image file path.</param>
/// <param name="key">The image key in <c>file</c> (if its an Eet one), or <c>null</c>, otherwise.</param>
/// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
bool SetFile(  System.String file,   System.String key);
   /// <summary>Save the given image object&apos;s contents to an (image) file.
/// The extension suffix on <c>file</c> will determine which saver module Evas is to use when saving, thus the final file&apos;s format. If the file supports multiple data stored in it (Eet ones), you can specify the key to be used as the index of the image in it.
/// 
/// You can specify some flags when saving the image.  Currently acceptable flags are <c>quality</c> and <c>compress</c>. Eg.: &quot;quality=100 compress=9&quot;.</summary>
/// <param name="file">The filename to be used to save the image (extension obligatory).</param>
/// <param name="key">The image key in the file (if an Eet one), or <c>null</c>, otherwise.</param>
/// <param name="flags">String containing the flags to be used (<c>null</c> for none).</param>
/// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
bool Save(  System.String file,   System.String key,   System.String flags);
                     /// <summary>Gets the (last) file loading error for a given object.</summary>
   Efl.Gfx.ImageLoadError LoadError {
      get ;
   }
}
/// <summary>Efl file interface</summary>
sealed public class FileConcrete : 

File
   
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (FileConcrete))
            return Efl.FileConcreteNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   private  System.IntPtr handle;
   public Dictionary<String, IntPtr> cached_strings = new Dictionary<String, IntPtr>();
   public Dictionary<String, IntPtr> cached_stringshares = new Dictionary<String, IntPtr>();
   ///<summary>Pointer to the native instance.</summary>
   public System.IntPtr NativeHandle {
      get { return handle; }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] internal static extern System.IntPtr
      efl_file_mixin_get();
   ///<summary>Constructs an instance from a native pointer.</summary>
   public FileConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~FileConcrete()
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
   public static FileConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new FileConcrete(obj.NativeHandle);
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
    void register_event_proxies()
   {
   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern Efl.Gfx.ImageLoadError efl_file_load_error_get(System.IntPtr obj);
   /// <summary>Gets the (last) file loading error for a given object.</summary>
   /// <returns>The load error code.</returns>
   public Efl.Gfx.ImageLoadError GetLoadError() {
       var _ret_var = efl_file_load_error_get(Efl.FileConcrete.efl_file_mixin_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_file_mmap_get(System.IntPtr obj,   out Eina.File f,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  out  System.String key);
   /// <summary>Get the source mmaped file from where an image object must fetch the real image data (it must be an Eina_File).
   /// If the file supports multiple data stored in it (as Eet files do), you can get the key to be used as the index of the image in this file.
   /// 1.10</summary>
   /// <param name="f">The handler to an Eina_File that will be used as image source</param>
   /// <param name="key">The group that the image belongs to, in case  it&apos;s an EET(including Edje case) file. This can be used as a key inside evas image cache if this is a normal image file not eet file.</param>
   /// <returns></returns>
   public  void GetMmap( out Eina.File f,  out  System.String key) {
                                           efl_file_mmap_get(Efl.FileConcrete.efl_file_mixin_get(),  out f,  out key);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_file_mmap_set(System.IntPtr obj,   Eina.File f,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key);
   /// <summary>Set the source mmaped file from where an image object must fetch the real image data (it must be an Eina_File).
   /// If the file supports multiple data stored in it (as Eet files do), you can specify the key to be used as the index of the image in this file.
   /// 1.8</summary>
   /// <param name="f">The handler to an Eina_File that will be used as image source</param>
   /// <param name="key">The group that the image belongs to, in case  it&apos;s an EET(including Edje case) file. This can be used as a key inside evas image cache if this is a normal image file not eet file.</param>
   /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
   public bool SetMmap( Eina.File f,   System.String key) {
                                           var _ret_var = efl_file_mmap_set(Efl.FileConcrete.efl_file_mixin_get(),  f,  key);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_file_get(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  out  System.String file,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  out  System.String key);
   /// <summary>Retrieve the source file from where an image object is to fetch the real image data (it may be an Eet file, besides pure image ones).
   /// You must not modify the strings on the returned pointers.
   /// 
   /// Note: Use <c>null</c> pointers on the file components you&apos;re not interested in: they&apos;ll be ignored by the function.</summary>
   /// <param name="file">The image file path.</param>
   /// <param name="key">The image key in <c>file</c> (if its an Eet one), or <c>null</c>, otherwise.</param>
   /// <returns></returns>
   public  void GetFile( out  System.String file,  out  System.String key) {
                                           efl_file_get(Efl.FileConcrete.efl_file_mixin_get(),  out file,  out key);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_file_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String file,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key);
   /// <summary>Set the source file from where an image object must fetch the real image data (it may be an Eet file, besides pure image ones).
   /// If the file supports multiple data stored in it (as Eet files do), you can specify the key to be used as the index of the image in this file.</summary>
   /// <param name="file">The image file path.</param>
   /// <param name="key">The image key in <c>file</c> (if its an Eet one), or <c>null</c>, otherwise.</param>
   /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
   public bool SetFile(  System.String file,   System.String key) {
                                           var _ret_var = efl_file_set(Efl.FileConcrete.efl_file_mixin_get(),  file,  key);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_file_save(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String file,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String flags);
   /// <summary>Save the given image object&apos;s contents to an (image) file.
   /// The extension suffix on <c>file</c> will determine which saver module Evas is to use when saving, thus the final file&apos;s format. If the file supports multiple data stored in it (Eet ones), you can specify the key to be used as the index of the image in it.
   /// 
   /// You can specify some flags when saving the image.  Currently acceptable flags are <c>quality</c> and <c>compress</c>. Eg.: &quot;quality=100 compress=9&quot;.</summary>
   /// <param name="file">The filename to be used to save the image (extension obligatory).</param>
   /// <param name="key">The image key in the file (if an Eet one), or <c>null</c>, otherwise.</param>
   /// <param name="flags">String containing the flags to be used (<c>null</c> for none).</param>
   /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
   public bool Save(  System.String file,   System.String key,   System.String flags) {
                                                             var _ret_var = efl_file_save(Efl.FileConcrete.efl_file_mixin_get(),  file,  key,  flags);
      Eina.Error.RaiseIfUnhandledException();
                                          return _ret_var;
 }
   /// <summary>Gets the (last) file loading error for a given object.</summary>
   public Efl.Gfx.ImageLoadError LoadError {
      get { return GetLoadError(); }
   }
}
public class FileConcreteNativeInherit : Efl.Eo.NativeClass{
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
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.FileConcrete.efl_file_mixin_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.FileConcrete.efl_file_mixin_get();
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
            _ret_var = ((FileConcrete)wrapper).GetLoadError();
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
            ((FileConcrete)wrapper).GetMmap( out f,  out _out_key);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            key= Efl.Eo.Globals.cached_string_to_intptr(((FileConcrete)wrapper).cached_strings, _out_key);
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
            _ret_var = ((FileConcrete)wrapper).SetMmap( f,  key);
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
            ((FileConcrete)wrapper).GetFile( out _out_file,  out _out_key);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      file= Efl.Eo.Globals.cached_string_to_intptr(((FileConcrete)wrapper).cached_strings, _out_file);
      key= Efl.Eo.Globals.cached_string_to_intptr(((FileConcrete)wrapper).cached_strings, _out_key);
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
            _ret_var = ((FileConcrete)wrapper).SetFile( file,  key);
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
            _ret_var = ((FileConcrete)wrapper).Save( file,  key,  flags);
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
}
} 
