#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

/// <summary>Efl file saving interface
/// (Since EFL 1.22)</summary>
[Efl.IFileSaveConcrete.NativeMethods]
public interface IFileSave : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Save the given image object&apos;s contents to an (image) file.
/// The extension suffix on <c>file</c> will determine which saver module Evas is to use when saving, thus the final file&apos;s format. If the file supports multiple data stored in it (Eet ones), you can specify the key to be used as the index of the image in it.
/// 
/// You can specify some flags when saving the image.  Currently acceptable flags are <c>quality</c> and <c>compress</c>. Eg.: &quot;quality=100 compress=9&quot;.
/// (Since EFL 1.22)</summary>
/// <param name="file">The filename to be used to save the image (extension obligatory).</param>
/// <param name="key">The image key in the file (if an Eet one), or <c>null</c>, otherwise.</param>
/// <param name="info">The flags to be used (<c>null</c> for defaults).</param>
/// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
bool Save(System.String file, System.String key, ref Efl.FileSaveInfo info);
    }
/// <summary>Efl file saving interface
/// (Since EFL 1.22)</summary>
sealed public class IFileSaveConcrete :
    Efl.Eo.EoWrapper
    , IFileSave
    
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(IFileSaveConcrete))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
        efl_file_save_interface_get();
    /// <summary>Initializes a new instance of the <see cref="IFileSave"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    private IFileSaveConcrete(System.IntPtr raw) : base(raw)
    {
    }

    /// <summary>Save the given image object&apos;s contents to an (image) file.
    /// The extension suffix on <c>file</c> will determine which saver module Evas is to use when saving, thus the final file&apos;s format. If the file supports multiple data stored in it (Eet ones), you can specify the key to be used as the index of the image in it.
    /// 
    /// You can specify some flags when saving the image.  Currently acceptable flags are <c>quality</c> and <c>compress</c>. Eg.: &quot;quality=100 compress=9&quot;.
    /// (Since EFL 1.22)</summary>
    /// <param name="file">The filename to be used to save the image (extension obligatory).</param>
    /// <param name="key">The image key in the file (if an Eet one), or <c>null</c>, otherwise.</param>
    /// <param name="info">The flags to be used (<c>null</c> for defaults).</param>
    /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
    public bool Save(System.String file, System.String key, ref Efl.FileSaveInfo info) {
                         Efl.FileSaveInfo.NativeStruct _in_info = info;
                                                        var _ret_var = Efl.IFileSaveConcrete.NativeMethods.efl_file_save_ptr.Value.Delegate(this.NativeHandle,file, key, ref _in_info);
        Eina.Error.RaiseIfUnhandledException();
                                                info = _in_info;
        return _ret_var;
 }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.IFileSaveConcrete.efl_file_save_interface_get();
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

            if (efl_file_save_static_delegate == null)
            {
                efl_file_save_static_delegate = new efl_file_save_delegate(save);
            }

            if (methods.FirstOrDefault(m => m.Name == "Save") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_file_save"), func = Marshal.GetFunctionPointerForDelegate(efl_file_save_static_delegate) });
            }

            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.IFileSaveConcrete.efl_file_save_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_file_save_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String file, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String key,  ref Efl.FileSaveInfo.NativeStruct info);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_file_save_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String file, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String key,  ref Efl.FileSaveInfo.NativeStruct info);

        public static Efl.Eo.FunctionWrapper<efl_file_save_api_delegate> efl_file_save_ptr = new Efl.Eo.FunctionWrapper<efl_file_save_api_delegate>(Module, "efl_file_save");

        private static bool save(System.IntPtr obj, System.IntPtr pd, System.String file, System.String key, ref Efl.FileSaveInfo.NativeStruct info)
        {
            Eina.Log.Debug("function efl_file_save was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                        Efl.FileSaveInfo _in_info = info;
                                                            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IFileSave)ws.Target).Save(file, key, ref _in_info);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                info = _in_info;
        return _ret_var;

            }
            else
            {
                return efl_file_save_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), file, key, ref info);
            }
        }

        private static efl_file_save_delegate efl_file_save_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

namespace Efl {

/// <summary>Info used to determine various attributes when saving a file.
/// (Since EFL 1.22)</summary>
[StructLayout(LayoutKind.Sequential)]
public struct FileSaveInfo
{
    /// <summary>The quality level (0-100) to save the file with; commonly used when saving image files.</summary>
    public uint Quality;
    /// <summary>The compression level (0-100) to save the file with.</summary>
    public uint Compression;
    /// <summary>The encoding to use when saving the file.</summary>
    public System.String Encoding;
    ///<summary>Constructor for FileSaveInfo.</summary>
    public FileSaveInfo(
        uint Quality = default(uint),
        uint Compression = default(uint),
        System.String Encoding = default(System.String)    )
    {
        this.Quality = Quality;
        this.Compression = Compression;
        this.Encoding = Encoding;
    }

    ///<summary>Implicit conversion to the managed representation from a native pointer.</summary>
    ///<param name="ptr">Native pointer to be converted.</param>
    public static implicit operator FileSaveInfo(IntPtr ptr)
    {
        var tmp = (FileSaveInfo.NativeStruct)Marshal.PtrToStructure(ptr, typeof(FileSaveInfo.NativeStruct));
        return tmp;
    }

    #pragma warning disable CS1591

    ///<summary>Internal wrapper for struct FileSaveInfo.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        
        public uint Quality;
        
        public uint Compression;
        ///<summary>Internal wrapper for field Encoding</summary>
        public System.IntPtr Encoding;
        ///<summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator FileSaveInfo.NativeStruct(FileSaveInfo _external_struct)
        {
            var _internal_struct = new FileSaveInfo.NativeStruct();
            _internal_struct.Quality = _external_struct.Quality;
            _internal_struct.Compression = _external_struct.Compression;
            _internal_struct.Encoding = Eina.MemoryNative.StrDup(_external_struct.Encoding);
            return _internal_struct;
        }

        ///<summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator FileSaveInfo(FileSaveInfo.NativeStruct _internal_struct)
        {
            var _external_struct = new FileSaveInfo();
            _external_struct.Quality = _internal_struct.Quality;
            _external_struct.Compression = _internal_struct.Compression;
            _external_struct.Encoding = Eina.StringConversion.NativeUtf8ToManagedString(_internal_struct.Encoding);
            return _external_struct;
        }

    }

    #pragma warning restore CS1591

}

}

