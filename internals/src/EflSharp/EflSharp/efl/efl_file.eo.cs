#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

/// <summary>Efl file interface
/// (Since EFL 1.22)</summary>
[Efl.IFileConcrete.NativeMethods]
public interface IFile : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Get the mmaped file from where an object will fetch the real data (it must be an <see cref="Eina.File"/>).
/// (Since EFL 1.22)</summary>
/// <returns>The handle to the <see cref="Eina.File"/> that will be used</returns>
Eina.File GetMmap();
    /// <summary>Set the mmaped file from where an object will fetch the real data (it must be an <see cref="Eina.File"/>).
/// If mmap is set during object construction, the object will automatically call <see cref="Efl.IFile.Load"/> during the finalize phase of construction.
/// (Since EFL 1.22)</summary>
/// <param name="f">The handle to the <see cref="Eina.File"/> that will be used</param>
/// <returns>0 on success, error code otherwise</returns>
Eina.Error SetMmap(Eina.File f);
    /// <summary>Retrieve the file path from where an object is to fetch the data.
/// You must not modify the strings on the returned pointers.
/// (Since EFL 1.22)</summary>
/// <returns>The file path.</returns>
System.String GetFile();
    /// <summary>Set the file path from where an object will fetch the data.
/// If file is set during object construction, the object will automatically call <see cref="Efl.IFile.Load"/> during the finalize phase of construction.
/// (Since EFL 1.22)</summary>
/// <param name="file">The file path.</param>
/// <returns>0 on success, error code otherwise</returns>
Eina.Error SetFile(System.String file);
    /// <summary>Get the previously-set key which corresponds to the target data within a file.
/// Some filetypes can contain multiple data streams which are indexed by a key. Use this property for such cases (See for example <see cref="Efl.Ui.Image"/> or <see cref="Efl.Ui.Layout"/>).
/// 
/// You must not modify the strings on the returned pointers.
/// (Since EFL 1.22)</summary>
/// <returns>The group that the data belongs to. See the class documentation for particular implementations of this interface to see how this property is used.</returns>
System.String GetKey();
    /// <summary>Set the key which corresponds to the target data within a file.
/// Some filetypes can contain multiple data streams which are indexed by a key. Use this property for such cases.
/// (Since EFL 1.22)</summary>
/// <param name="key">The group that the data belongs to. See the class documentation for particular implementations of this interface to see how this property is used.</param>
void SetKey(System.String key);
    /// <summary>Get the load state of the object.
/// (Since EFL 1.22)</summary>
/// <returns><c>true</c> if the object is loaded, <c>false</c> otherwise.</returns>
bool GetLoaded();
    /// <summary>Perform all necessary operations to open and load file data into the object using the <see cref="Efl.IFile.File"/> (or <see cref="Efl.IFile.Mmap"/>) and <see cref="Efl.IFile.Key"/> properties.
/// In the case where <see cref="Efl.IFile.SetFile"/> has been called on an object, this will internally open the file and call <see cref="Efl.IFile.SetMmap"/> on the object using the opened file handle.
/// 
/// Calling <see cref="Efl.IFile.Load"/> on an object which has already performed file operations based on the currently set properties will have no effect.
/// (Since EFL 1.22)</summary>
/// <returns>0 on success, error code otherwise</returns>
Eina.Error Load();
    /// <summary>Perform all necessary operations to unload file data from the object.
/// In the case where <see cref="Efl.IFile.SetMmap"/> has been externally called on an object, the file handle stored in the object will be preserved.
/// 
/// Calling <see cref="Efl.IFile.Unload"/> on an object which is not currently loaded will have no effect.
/// (Since EFL 1.22)</summary>
void Unload();
                                        /// <summary>Get the mmaped file from where an object will fetch the real data (it must be an <see cref="Eina.File"/>).
/// (Since EFL 1.22)</summary>
/// <value>The handle to the <see cref="Eina.File"/> that will be used</value>
    Eina.File Mmap {
        get ;
        set ;
    }
    /// <summary>Retrieve the file path from where an object is to fetch the data.
/// You must not modify the strings on the returned pointers.
/// (Since EFL 1.22)</summary>
/// <value>The file path.</value>
    System.String File {
        get ;
        set ;
    }
    /// <summary>Get the previously-set key which corresponds to the target data within a file.
/// Some filetypes can contain multiple data streams which are indexed by a key. Use this property for such cases (See for example <see cref="Efl.Ui.Image"/> or <see cref="Efl.Ui.Layout"/>).
/// 
/// You must not modify the strings on the returned pointers.
/// (Since EFL 1.22)</summary>
/// <value>The group that the data belongs to. See the class documentation for particular implementations of this interface to see how this property is used.</value>
    System.String Key {
        get ;
        set ;
    }
    /// <summary>Get the load state of the object.
/// (Since EFL 1.22)</summary>
/// <value><c>true</c> if the object is loaded, <c>false</c> otherwise.</value>
    bool Loaded {
        get ;
    }
}
/// <summary>Efl file interface
/// (Since EFL 1.22)</summary>
sealed public class IFileConcrete : 

IFile
    
{
    ///<summary>Pointer to the native class description.</summary>
    public System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(IFileConcrete))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    private  System.IntPtr handle;
    ///<summary>Pointer to the native instance.</summary>
    public System.IntPtr NativeHandle
    {
        get { return handle; }
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] internal static extern System.IntPtr
        efl_file_mixin_get();
    /// <summary>Initializes a new instance of the <see cref="IFile"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    private IFileConcrete(System.IntPtr raw)
    {
        handle = raw;
    }
    ///<summary>Destructor.</summary>
    ~IFileConcrete()
    {
        Dispose(false);
    }

    ///<summary>Releases the underlying native instance.</summary>
    private void Dispose(bool disposing)
    {
        if (handle != System.IntPtr.Zero)
        {
            IntPtr h = handle;
            handle = IntPtr.Zero;

            IntPtr gcHandlePtr = IntPtr.Zero;
            if (disposing)
            {
                Efl.Eo.Globals.efl_mono_native_dispose(h, gcHandlePtr);
            }
            else
            {
                Monitor.Enter(Efl.All.InitLock);
                if (Efl.All.MainLoopInitialized)
                {
                    Efl.Eo.Globals.efl_mono_thread_safe_native_dispose(h, gcHandlePtr);
                }

                Monitor.Exit(Efl.All.InitLock);
            }
        }

    }

    ///<summary>Releases the underlying native instance.</summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>Verifies if the given object is equal to this one.</summary>
    /// <param name="instance">The object to compare to.</param>
    /// <returns>True if both objects point to the same native object.</returns>
    public override bool Equals(object instance)
    {
        var other = instance as Efl.Object;
        if (other == null)
        {
            return false;
        }
        return this.NativeHandle == other.NativeHandle;
    }

    /// <summary>Gets the hash code for this object based on the native pointer it points to.</summary>
    /// <returns>The value of the pointer, to be used as the hash code of this object.</returns>
    public override int GetHashCode()
    {
        return this.NativeHandle.ToInt32();
    }

    /// <summary>Turns the native pointer into a string representation.</summary>
    /// <returns>A string with the type and the native pointer for this object.</returns>
    public override String ToString()
    {
        return $"{this.GetType().Name}@[{this.NativeHandle.ToInt32():x}]";
    }

    /// <summary>Get the mmaped file from where an object will fetch the real data (it must be an <see cref="Eina.File"/>).
    /// (Since EFL 1.22)</summary>
    /// <returns>The handle to the <see cref="Eina.File"/> that will be used</returns>
    public Eina.File GetMmap() {
         var _ret_var = Efl.IFileConcrete.NativeMethods.efl_file_mmap_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the mmaped file from where an object will fetch the real data (it must be an <see cref="Eina.File"/>).
    /// If mmap is set during object construction, the object will automatically call <see cref="Efl.IFile.Load"/> during the finalize phase of construction.
    /// (Since EFL 1.22)</summary>
    /// <param name="f">The handle to the <see cref="Eina.File"/> that will be used</param>
    /// <returns>0 on success, error code otherwise</returns>
    public Eina.Error SetMmap(Eina.File f) {
                                 var _ret_var = Efl.IFileConcrete.NativeMethods.efl_file_mmap_set_ptr.Value.Delegate(this.NativeHandle,f);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Retrieve the file path from where an object is to fetch the data.
    /// You must not modify the strings on the returned pointers.
    /// (Since EFL 1.22)</summary>
    /// <returns>The file path.</returns>
    public System.String GetFile() {
         var _ret_var = Efl.IFileConcrete.NativeMethods.efl_file_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the file path from where an object will fetch the data.
    /// If file is set during object construction, the object will automatically call <see cref="Efl.IFile.Load"/> during the finalize phase of construction.
    /// (Since EFL 1.22)</summary>
    /// <param name="file">The file path.</param>
    /// <returns>0 on success, error code otherwise</returns>
    public Eina.Error SetFile(System.String file) {
                                 var _ret_var = Efl.IFileConcrete.NativeMethods.efl_file_set_ptr.Value.Delegate(this.NativeHandle,file);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Get the previously-set key which corresponds to the target data within a file.
    /// Some filetypes can contain multiple data streams which are indexed by a key. Use this property for such cases (See for example <see cref="Efl.Ui.Image"/> or <see cref="Efl.Ui.Layout"/>).
    /// 
    /// You must not modify the strings on the returned pointers.
    /// (Since EFL 1.22)</summary>
    /// <returns>The group that the data belongs to. See the class documentation for particular implementations of this interface to see how this property is used.</returns>
    public System.String GetKey() {
         var _ret_var = Efl.IFileConcrete.NativeMethods.efl_file_key_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the key which corresponds to the target data within a file.
    /// Some filetypes can contain multiple data streams which are indexed by a key. Use this property for such cases.
    /// (Since EFL 1.22)</summary>
    /// <param name="key">The group that the data belongs to. See the class documentation for particular implementations of this interface to see how this property is used.</param>
    public void SetKey(System.String key) {
                                 Efl.IFileConcrete.NativeMethods.efl_file_key_set_ptr.Value.Delegate(this.NativeHandle,key);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get the load state of the object.
    /// (Since EFL 1.22)</summary>
    /// <returns><c>true</c> if the object is loaded, <c>false</c> otherwise.</returns>
    public bool GetLoaded() {
         var _ret_var = Efl.IFileConcrete.NativeMethods.efl_file_loaded_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Perform all necessary operations to open and load file data into the object using the <see cref="Efl.IFile.File"/> (or <see cref="Efl.IFile.Mmap"/>) and <see cref="Efl.IFile.Key"/> properties.
    /// In the case where <see cref="Efl.IFile.SetFile"/> has been called on an object, this will internally open the file and call <see cref="Efl.IFile.SetMmap"/> on the object using the opened file handle.
    /// 
    /// Calling <see cref="Efl.IFile.Load"/> on an object which has already performed file operations based on the currently set properties will have no effect.
    /// (Since EFL 1.22)</summary>
    /// <returns>0 on success, error code otherwise</returns>
    public Eina.Error Load() {
         var _ret_var = Efl.IFileConcrete.NativeMethods.efl_file_load_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Perform all necessary operations to unload file data from the object.
    /// In the case where <see cref="Efl.IFile.SetMmap"/> has been externally called on an object, the file handle stored in the object will be preserved.
    /// 
    /// Calling <see cref="Efl.IFile.Unload"/> on an object which is not currently loaded will have no effect.
    /// (Since EFL 1.22)</summary>
    public void Unload() {
         Efl.IFileConcrete.NativeMethods.efl_file_unload_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Get the mmaped file from where an object will fetch the real data (it must be an <see cref="Eina.File"/>).
/// (Since EFL 1.22)</summary>
/// <value>The handle to the <see cref="Eina.File"/> that will be used</value>
    public Eina.File Mmap {
        get { return GetMmap(); }
        set { SetMmap(value); }
    }
    /// <summary>Retrieve the file path from where an object is to fetch the data.
/// You must not modify the strings on the returned pointers.
/// (Since EFL 1.22)</summary>
/// <value>The file path.</value>
    public System.String File {
        get { return GetFile(); }
        set { SetFile(value); }
    }
    /// <summary>Get the previously-set key which corresponds to the target data within a file.
/// Some filetypes can contain multiple data streams which are indexed by a key. Use this property for such cases (See for example <see cref="Efl.Ui.Image"/> or <see cref="Efl.Ui.Layout"/>).
/// 
/// You must not modify the strings on the returned pointers.
/// (Since EFL 1.22)</summary>
/// <value>The group that the data belongs to. See the class documentation for particular implementations of this interface to see how this property is used.</value>
    public System.String Key {
        get { return GetKey(); }
        set { SetKey(value); }
    }
    /// <summary>Get the load state of the object.
/// (Since EFL 1.22)</summary>
/// <value><c>true</c> if the object is loaded, <c>false</c> otherwise.</value>
    public bool Loaded {
        get { return GetLoaded(); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.IFileConcrete.efl_file_mixin_get();
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

            if (efl_file_mmap_get_static_delegate == null)
            {
                efl_file_mmap_get_static_delegate = new efl_file_mmap_get_delegate(mmap_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetMmap") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_file_mmap_get"), func = Marshal.GetFunctionPointerForDelegate(efl_file_mmap_get_static_delegate) });
            }

            if (efl_file_mmap_set_static_delegate == null)
            {
                efl_file_mmap_set_static_delegate = new efl_file_mmap_set_delegate(mmap_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetMmap") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_file_mmap_set"), func = Marshal.GetFunctionPointerForDelegate(efl_file_mmap_set_static_delegate) });
            }

            if (efl_file_get_static_delegate == null)
            {
                efl_file_get_static_delegate = new efl_file_get_delegate(file_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFile") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_file_get"), func = Marshal.GetFunctionPointerForDelegate(efl_file_get_static_delegate) });
            }

            if (efl_file_set_static_delegate == null)
            {
                efl_file_set_static_delegate = new efl_file_set_delegate(file_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFile") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_file_set"), func = Marshal.GetFunctionPointerForDelegate(efl_file_set_static_delegate) });
            }

            if (efl_file_key_get_static_delegate == null)
            {
                efl_file_key_get_static_delegate = new efl_file_key_get_delegate(key_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetKey") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_file_key_get"), func = Marshal.GetFunctionPointerForDelegate(efl_file_key_get_static_delegate) });
            }

            if (efl_file_key_set_static_delegate == null)
            {
                efl_file_key_set_static_delegate = new efl_file_key_set_delegate(key_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetKey") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_file_key_set"), func = Marshal.GetFunctionPointerForDelegate(efl_file_key_set_static_delegate) });
            }

            if (efl_file_loaded_get_static_delegate == null)
            {
                efl_file_loaded_get_static_delegate = new efl_file_loaded_get_delegate(loaded_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetLoaded") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_file_loaded_get"), func = Marshal.GetFunctionPointerForDelegate(efl_file_loaded_get_static_delegate) });
            }

            if (efl_file_load_static_delegate == null)
            {
                efl_file_load_static_delegate = new efl_file_load_delegate(load);
            }

            if (methods.FirstOrDefault(m => m.Name == "Load") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_file_load"), func = Marshal.GetFunctionPointerForDelegate(efl_file_load_static_delegate) });
            }

            if (efl_file_unload_static_delegate == null)
            {
                efl_file_unload_static_delegate = new efl_file_unload_delegate(unload);
            }

            if (methods.FirstOrDefault(m => m.Name == "Unload") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_file_unload"), func = Marshal.GetFunctionPointerForDelegate(efl_file_unload_static_delegate) });
            }

            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.IFileConcrete.efl_file_mixin_get();
        }

        #pragma warning disable CA1707, SA1300, SA1600

        
        private delegate Eina.File efl_file_mmap_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.File efl_file_mmap_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_file_mmap_get_api_delegate> efl_file_mmap_get_ptr = new Efl.Eo.FunctionWrapper<efl_file_mmap_get_api_delegate>(Module, "efl_file_mmap_get");

        private static Eina.File mmap_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_file_mmap_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            Eina.File _ret_var = default(Eina.File);
                try
                {
                    _ret_var = ((IFileConcrete)wrapper).GetMmap();
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
                return efl_file_mmap_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_file_mmap_get_delegate efl_file_mmap_get_static_delegate;

        
        private delegate Eina.Error efl_file_mmap_set_delegate(System.IntPtr obj, System.IntPtr pd,  Eina.File f);

        
        public delegate Eina.Error efl_file_mmap_set_api_delegate(System.IntPtr obj,  Eina.File f);

        public static Efl.Eo.FunctionWrapper<efl_file_mmap_set_api_delegate> efl_file_mmap_set_ptr = new Efl.Eo.FunctionWrapper<efl_file_mmap_set_api_delegate>(Module, "efl_file_mmap_set");

        private static Eina.Error mmap_set(System.IntPtr obj, System.IntPtr pd, Eina.File f)
        {
            Eina.Log.Debug("function efl_file_mmap_set was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    Eina.Error _ret_var = default(Eina.Error);
                try
                {
                    _ret_var = ((IFileConcrete)wrapper).SetMmap(f);
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
                return efl_file_mmap_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), f);
            }
        }

        private static efl_file_mmap_set_delegate efl_file_mmap_set_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_file_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_file_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_file_get_api_delegate> efl_file_get_ptr = new Efl.Eo.FunctionWrapper<efl_file_get_api_delegate>(Module, "efl_file_get");

        private static System.String file_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_file_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((IFileConcrete)wrapper).GetFile();
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
                return efl_file_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_file_get_delegate efl_file_get_static_delegate;

        
        private delegate Eina.Error efl_file_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String file);

        
        public delegate Eina.Error efl_file_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String file);

        public static Efl.Eo.FunctionWrapper<efl_file_set_api_delegate> efl_file_set_ptr = new Efl.Eo.FunctionWrapper<efl_file_set_api_delegate>(Module, "efl_file_set");

        private static Eina.Error file_set(System.IntPtr obj, System.IntPtr pd, System.String file)
        {
            Eina.Log.Debug("function efl_file_set was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    Eina.Error _ret_var = default(Eina.Error);
                try
                {
                    _ret_var = ((IFileConcrete)wrapper).SetFile(file);
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
                return efl_file_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), file);
            }
        }

        private static efl_file_set_delegate efl_file_set_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_file_key_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_file_key_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_file_key_get_api_delegate> efl_file_key_get_ptr = new Efl.Eo.FunctionWrapper<efl_file_key_get_api_delegate>(Module, "efl_file_key_get");

        private static System.String key_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_file_key_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((IFileConcrete)wrapper).GetKey();
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
                return efl_file_key_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_file_key_get_delegate efl_file_key_get_static_delegate;

        
        private delegate void efl_file_key_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String key);

        
        public delegate void efl_file_key_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String key);

        public static Efl.Eo.FunctionWrapper<efl_file_key_set_api_delegate> efl_file_key_set_ptr = new Efl.Eo.FunctionWrapper<efl_file_key_set_api_delegate>(Module, "efl_file_key_set");

        private static void key_set(System.IntPtr obj, System.IntPtr pd, System.String key)
        {
            Eina.Log.Debug("function efl_file_key_set was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    
                try
                {
                    ((IFileConcrete)wrapper).SetKey(key);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_file_key_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), key);
            }
        }

        private static efl_file_key_set_delegate efl_file_key_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_file_loaded_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_file_loaded_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_file_loaded_get_api_delegate> efl_file_loaded_get_ptr = new Efl.Eo.FunctionWrapper<efl_file_loaded_get_api_delegate>(Module, "efl_file_loaded_get");

        private static bool loaded_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_file_loaded_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IFileConcrete)wrapper).GetLoaded();
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
                return efl_file_loaded_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_file_loaded_get_delegate efl_file_loaded_get_static_delegate;

        
        private delegate Eina.Error efl_file_load_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Error efl_file_load_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_file_load_api_delegate> efl_file_load_ptr = new Efl.Eo.FunctionWrapper<efl_file_load_api_delegate>(Module, "efl_file_load");

        private static Eina.Error load(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_file_load was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            Eina.Error _ret_var = default(Eina.Error);
                try
                {
                    _ret_var = ((IFileConcrete)wrapper).Load();
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
                return efl_file_load_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_file_load_delegate efl_file_load_static_delegate;

        
        private delegate void efl_file_unload_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_file_unload_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_file_unload_api_delegate> efl_file_unload_ptr = new Efl.Eo.FunctionWrapper<efl_file_unload_api_delegate>(Module, "efl_file_unload");

        private static void unload(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_file_unload was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            
                try
                {
                    ((IFileConcrete)wrapper).Unload();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_file_unload_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_file_unload_delegate efl_file_unload_static_delegate;

        #pragma warning restore CA1707, SA1300, SA1600

}
}
}

