#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { 
/// <summary>Efl file saving interface</summary>
[FileSaveNativeInherit]
public interface FileSave : 
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>Save the given image object&apos;s contents to an (image) file.
/// The extension suffix on <c>file</c> will determine which saver module Evas is to use when saving, thus the final file&apos;s format. If the file supports multiple data stored in it (Eet ones), you can specify the key to be used as the index of the image in it.
/// 
/// You can specify some flags when saving the image.  Currently acceptable flags are <c>quality</c> and <c>compress</c>. Eg.: &quot;quality=100 compress=9&quot;.</summary>
/// <param name="file">The filename to be used to save the image (extension obligatory).</param>
/// <param name="key">The image key in the file (if an Eet one), or <c>null</c>, otherwise.</param>
/// <param name="info">The flags to be used (<c>null</c> for defaults).</param>
/// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
bool Save(  System.String file,   System.String key,  ref Efl.FileSaveInfo info);
   }
/// <summary>Efl file saving interface</summary>
sealed public class FileSaveConcrete : 

FileSave
   
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (FileSaveConcrete))
            return Efl.FileSaveNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
      }
   }
   private  System.IntPtr handle;
   ///<summary>Pointer to the native instance.</summary>
   public System.IntPtr NativeHandle {
      get { return handle; }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] internal static extern System.IntPtr
      efl_file_save_interface_get();
   ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
   public FileSaveConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~FileSaveConcrete()
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
   public static FileSaveConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new FileSaveConcrete(obj.NativeHandle);
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
   /// <summary>Save the given image object&apos;s contents to an (image) file.
   /// The extension suffix on <c>file</c> will determine which saver module Evas is to use when saving, thus the final file&apos;s format. If the file supports multiple data stored in it (Eet ones), you can specify the key to be used as the index of the image in it.
   /// 
   /// You can specify some flags when saving the image.  Currently acceptable flags are <c>quality</c> and <c>compress</c>. Eg.: &quot;quality=100 compress=9&quot;.</summary>
   /// <param name="file">The filename to be used to save the image (extension obligatory).</param>
   /// <param name="key">The image key in the file (if an Eet one), or <c>null</c>, otherwise.</param>
   /// <param name="info">The flags to be used (<c>null</c> for defaults).</param>
   /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
   public bool Save(  System.String file,   System.String key,  ref Efl.FileSaveInfo info) {
                   var _in_info = Efl.FileSaveInfo_StructConversion.ToInternal(info);
                                          var _ret_var = Efl.FileSaveNativeInherit.efl_file_save_ptr.Value.Delegate(this.NativeHandle, file,  key,  ref _in_info);
      Eina.Error.RaiseIfUnhandledException();
                                    info = Efl.FileSaveInfo_StructConversion.ToManaged(_in_info);
      return _ret_var;
 }
}
public class FileSaveNativeInherit  : Efl.Eo.NativeClass{
   public  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Efl);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      if (efl_file_save_static_delegate == null)
      efl_file_save_static_delegate = new efl_file_save_delegate(save);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_file_save"), func = Marshal.GetFunctionPointerForDelegate(efl_file_save_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.FileSaveConcrete.efl_file_save_interface_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.FileSaveConcrete.efl_file_save_interface_get();
   }


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_file_save_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String file,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key,   ref Efl.FileSaveInfo_StructInternal info);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_file_save_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String file,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key,   ref Efl.FileSaveInfo_StructInternal info);
    public static Efl.Eo.FunctionWrapper<efl_file_save_api_delegate> efl_file_save_ptr = new Efl.Eo.FunctionWrapper<efl_file_save_api_delegate>(_Module, "efl_file_save");
    private static bool save(System.IntPtr obj, System.IntPtr pd,   System.String file,   System.String key,  ref Efl.FileSaveInfo_StructInternal info)
   {
      Eina.Log.Debug("function efl_file_save was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           var _in_info = Efl.FileSaveInfo_StructConversion.ToManaged(info);
                                             bool _ret_var = default(bool);
         try {
            _ret_var = ((FileSave)wrapper).Save( file,  key,  ref _in_info);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    info = Efl.FileSaveInfo_StructConversion.ToInternal(_in_info);
      return _ret_var;
      } else {
         return efl_file_save_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  file,  key,  ref info);
      }
   }
   private static efl_file_save_delegate efl_file_save_static_delegate;
}
} 
namespace Efl { 
/// <summary>Info used to determine various attributes when saving a file.</summary>
[StructLayout(LayoutKind.Sequential)]
public struct FileSaveInfo
{
   /// <summary>The quality level (0-100) to save the file with; commonly used when saving image files.</summary>
   public  uint Quality;
   /// <summary>The compression level (0-100) to save the file with.</summary>
   public  uint Compression;
   /// <summary>The encoding to use when saving the file.</summary>
   public  System.String Encoding;
   ///<summary>Constructor for FileSaveInfo.</summary>
   public FileSaveInfo(
       uint Quality=default( uint),
       uint Compression=default( uint),
       System.String Encoding=default( System.String)   )
   {
      this.Quality = Quality;
      this.Compression = Compression;
      this.Encoding = Encoding;
   }
public static implicit operator FileSaveInfo(IntPtr ptr)
   {
      var tmp = (FileSaveInfo_StructInternal)Marshal.PtrToStructure(ptr, typeof(FileSaveInfo_StructInternal));
      return FileSaveInfo_StructConversion.ToManaged(tmp);
   }
}
///<summary>Internal wrapper for struct FileSaveInfo.</summary>
[StructLayout(LayoutKind.Sequential)]
public struct FileSaveInfo_StructInternal
{
   
   public  uint Quality;
   
   public  uint Compression;
///<summary>Internal wrapper for field Encoding</summary>
public System.IntPtr Encoding;
   ///<summary>Implicit conversion to the internal/marshalling representation.</summary>
   public static implicit operator FileSaveInfo(FileSaveInfo_StructInternal struct_)
   {
      return FileSaveInfo_StructConversion.ToManaged(struct_);
   }
   ///<summary>Implicit conversion to the managed representation.</summary>
   public static implicit operator FileSaveInfo_StructInternal(FileSaveInfo struct_)
   {
      return FileSaveInfo_StructConversion.ToInternal(struct_);
   }
}
/// <summary>Conversion class for struct FileSaveInfo</summary>
public static class FileSaveInfo_StructConversion
{
   internal static FileSaveInfo_StructInternal ToInternal(FileSaveInfo _external_struct)
   {
      var _internal_struct = new FileSaveInfo_StructInternal();

      _internal_struct.Quality = _external_struct.Quality;
      _internal_struct.Compression = _external_struct.Compression;
      _internal_struct.Encoding = Eina.MemoryNative.StrDup(_external_struct.Encoding);

      return _internal_struct;
   }

   internal static FileSaveInfo ToManaged(FileSaveInfo_StructInternal _internal_struct)
   {
      var _external_struct = new FileSaveInfo();

      _external_struct.Quality = _internal_struct.Quality;
      _external_struct.Compression = _internal_struct.Compression;
      _external_struct.Encoding = Eina.StringConversion.NativeUtf8ToManagedString(_internal_struct.Encoding);

      return _external_struct;
   }

}
} 
