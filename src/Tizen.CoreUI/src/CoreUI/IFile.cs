/*
 * Copyright 2019 by its authors. See AUTHORS.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
namespace CoreUI {
    /// <summary>CoreUI file interface</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.IFileNativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    public interface IFile : 
        CoreUI.Wrapper.IWrapper, IDisposable
    {
        /// <summary>The mmaped file from where an object will fetch the real data (it must be an <see cref="CoreUI.DataTypes.File"/>).
        /// 
        /// If mmap is set during object construction, the object will automatically call <see cref="CoreUI.IFile.Load"/> during the finalize phase of construction.</summary>
        /// <returns>The handle to the <see cref="CoreUI.DataTypes.File"/> that will be used</returns>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.DataTypes.File GetMmap();

        /// <summary>The mmaped file from where an object will fetch the real data (it must be an <see cref="CoreUI.DataTypes.File"/>).
        /// 
        /// If mmap is set during object construction, the object will automatically call <see cref="CoreUI.IFile.Load"/> during the finalize phase of construction.</summary>
        /// <param name="f">The handle to the <see cref="CoreUI.DataTypes.File"/> that will be used</param>
        /// <returns>0 on success, error code otherwise</returns>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.DataTypes.Error SetMmap(CoreUI.DataTypes.File f);

        /// <summary>The file path from where an object will fetch the data.
        /// 
        /// If file is set during object construction, the object will automatically call <see cref="CoreUI.IFile.Load"/> during the finalize phase of construction.
        /// 
        /// You must not modify the strings on the returned pointers.</summary>
        /// <returns>The file path.</returns>
        /// <since_tizen> 6 </since_tizen>
        System.String GetFile();

        /// <summary>The file path from where an object will fetch the data.
        /// 
        /// If file is set during object construction, the object will automatically call <see cref="CoreUI.IFile.Load"/> during the finalize phase of construction.
        /// 
        /// You must not modify the strings on the returned pointers.</summary>
        /// <param name="file">The file path.</param>
        /// <returns>0 on success, error code otherwise</returns>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.DataTypes.Error SetFile(System.String file);

        /// <summary>The key which corresponds to the target data within a file.
        /// 
        /// Some file types can contain multiple data streams which are indexed by a key. Use this property for such cases (See for example <see cref="CoreUI.UI.Image"/> or <see cref="CoreUI.UI.Layout"/>).
        /// 
        /// You must not modify the strings on the returned pointers.</summary>
        /// <returns>The group that the data belongs to. See the class documentation for particular implementations of this interface to see how this property is used.</returns>
        /// <since_tizen> 6 </since_tizen>
        System.String GetKey();

        /// <summary>The key which corresponds to the target data within a file.
        /// 
        /// Some file types can contain multiple data streams which are indexed by a key. Use this property for such cases (See for example <see cref="CoreUI.UI.Image"/> or <see cref="CoreUI.UI.Layout"/>).
        /// 
        /// You must not modify the strings on the returned pointers.</summary>
        /// <param name="key">The group that the data belongs to. See the class documentation for particular implementations of this interface to see how this property is used.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetKey(System.String key);

        /// <summary>The load state of the object.</summary>
        /// <returns><c>true</c> if the object is loaded, <c>false</c> otherwise.</returns>
        /// <since_tizen> 6 </since_tizen>
        bool GetLoaded();

        /// <summary>Perform all necessary operations to open and load file data into the object using the <see cref="CoreUI.IFile.File"/> (or <see cref="CoreUI.IFile.Mmap"/>) and <see cref="CoreUI.IFile.Key"/> properties.
        /// 
        /// In the case where <see cref="CoreUI.IFile.SetFile"/> has been called on an object, this will internally open the file and call <see cref="CoreUI.IFile.SetMmap"/> on the object using the opened file handle.
        /// 
        /// Calling <see cref="CoreUI.IFile.Load"/> on an object which has already performed file operations based on the currently set properties will have no effect.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <returns>0 on success, error code otherwise</returns>
        CoreUI.DataTypes.Error Load();

        /// <summary>Perform all necessary operations to unload file data from the object.
        /// 
        /// In the case where <see cref="CoreUI.IFile.SetMmap"/> has been externally called on an object, the file handle stored in the object will be preserved.
        /// 
        /// Calling <see cref="CoreUI.IFile.Unload"/> on an object which is not currently loaded will have no effect.</summary>
        /// <since_tizen> 6 </since_tizen>
        void Unload();

        /// <summary>The mmaped file from where an object will fetch the real data (it must be an <see cref="CoreUI.DataTypes.File"/>).
        /// 
        /// If mmap is set during object construction, the object will automatically call <see cref="CoreUI.IFile.Load"/> during the finalize phase of construction.</summary>
        /// <value>The handle to the <see cref="CoreUI.DataTypes.File"/> that will be used</value>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.DataTypes.File Mmap {
            get;
            set;
        }

        /// <summary>The file path from where an object will fetch the data.
        /// 
        /// If file is set during object construction, the object will automatically call <see cref="CoreUI.IFile.Load"/> during the finalize phase of construction.
        /// 
        /// You must not modify the strings on the returned pointers.</summary>
        /// <value>The file path.</value>
        /// <since_tizen> 6 </since_tizen>
        System.String File {
            get;
            set;
        }

        /// <summary>The key which corresponds to the target data within a file.
        /// 
        /// Some file types can contain multiple data streams which are indexed by a key. Use this property for such cases (See for example <see cref="CoreUI.UI.Image"/> or <see cref="CoreUI.UI.Layout"/>).
        /// 
        /// You must not modify the strings on the returned pointers.</summary>
        /// <value>The group that the data belongs to. See the class documentation for particular implementations of this interface to see how this property is used.</value>
        /// <since_tizen> 6 </since_tizen>
        System.String Key {
            get;
            set;
        }

        /// <summary>The load state of the object.</summary>
        /// <value><c>true</c> if the object is loaded, <c>false</c> otherwise.</value>
        /// <since_tizen> 6 </since_tizen>
        bool Loaded {
            get;
        }

    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class IFileNativeMethods : CoreUI.Wrapper.ObjectWrapper.NativeMethods
    {
        [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
            efl_file_mixin_get();
        private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.CoreUI);

        /// <summary>Gets the list of Eo operations to override.
    /// </summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
            var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

            if (efl_file_mmap_get_static_delegate == null)
            {
                efl_file_mmap_get_static_delegate = new efl_file_mmap_get_delegate(mmap_get);
            }

            if (methods.Contains("GetMmap"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_file_mmap_get"), func = Marshal.GetFunctionPointerForDelegate(efl_file_mmap_get_static_delegate) });
            }

            if (efl_file_mmap_set_static_delegate == null)
            {
                efl_file_mmap_set_static_delegate = new efl_file_mmap_set_delegate(mmap_set);
            }

            if (methods.Contains("SetMmap"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_file_mmap_set"), func = Marshal.GetFunctionPointerForDelegate(efl_file_mmap_set_static_delegate) });
            }

            if (efl_file_get_static_delegate == null)
            {
                efl_file_get_static_delegate = new efl_file_get_delegate(file_get);
            }

            if (methods.Contains("GetFile"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_file_get"), func = Marshal.GetFunctionPointerForDelegate(efl_file_get_static_delegate) });
            }

            if (efl_file_set_static_delegate == null)
            {
                efl_file_set_static_delegate = new efl_file_set_delegate(file_set);
            }

            if (methods.Contains("SetFile"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_file_set"), func = Marshal.GetFunctionPointerForDelegate(efl_file_set_static_delegate) });
            }

            if (efl_file_key_get_static_delegate == null)
            {
                efl_file_key_get_static_delegate = new efl_file_key_get_delegate(key_get);
            }

            if (methods.Contains("GetKey"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_file_key_get"), func = Marshal.GetFunctionPointerForDelegate(efl_file_key_get_static_delegate) });
            }

            if (efl_file_key_set_static_delegate == null)
            {
                efl_file_key_set_static_delegate = new efl_file_key_set_delegate(key_set);
            }

            if (methods.Contains("SetKey"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_file_key_set"), func = Marshal.GetFunctionPointerForDelegate(efl_file_key_set_static_delegate) });
            }

            if (efl_file_loaded_get_static_delegate == null)
            {
                efl_file_loaded_get_static_delegate = new efl_file_loaded_get_delegate(loaded_get);
            }

            if (methods.Contains("GetLoaded"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_file_loaded_get"), func = Marshal.GetFunctionPointerForDelegate(efl_file_loaded_get_static_delegate) });
            }

            if (efl_file_load_static_delegate == null)
            {
                efl_file_load_static_delegate = new efl_file_load_delegate(load);
            }

            if (methods.Contains("Load"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_file_load"), func = Marshal.GetFunctionPointerForDelegate(efl_file_load_static_delegate) });
            }

            if (efl_file_unload_static_delegate == null)
            {
                efl_file_unload_static_delegate = new efl_file_unload_delegate(unload);
            }

            if (methods.Contains("Unload"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_file_unload"), func = Marshal.GetFunctionPointerForDelegate(efl_file_unload_static_delegate) });
            }

            if (includeInherited)
            {
                var all_interfaces = type.GetInterfaces();
                foreach (var iface in all_interfaces)
                {
                    var moredescs = ((CoreUI.Wrapper.NativeClass)iface.GetCustomAttributes(false)?.FirstOrDefault(attr => attr is CoreUI.Wrapper.NativeClass))?.GetEoOps(type, false);
                    if (moredescs != null)
                        descs.AddRange(moredescs);
                }
            }
            return descs;
        }

        /// <summary>Returns the Eo class for the native methods of this class.
        /// </summary>
        /// <returns>The native class pointer.</returns>
        internal override IntPtr GetCoreUIClass()
        {
            return efl_file_mixin_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate CoreUI.DataTypes.File efl_file_mmap_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate CoreUI.DataTypes.File efl_file_mmap_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_file_mmap_get_api_delegate> efl_file_mmap_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_file_mmap_get_api_delegate>(Module, "efl_file_mmap_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static CoreUI.DataTypes.File mmap_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_file_mmap_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.DataTypes.File _ret_var = default(CoreUI.DataTypes.File);
                try
                {
                    _ret_var = ((IFile)ws.Target).GetMmap();
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_file_mmap_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_file_mmap_get_delegate efl_file_mmap_get_static_delegate;

        
        private delegate CoreUI.DataTypes.Error efl_file_mmap_set_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.DataTypes.File f);

        
        internal delegate CoreUI.DataTypes.Error efl_file_mmap_set_api_delegate(System.IntPtr obj,  CoreUI.DataTypes.File f);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_file_mmap_set_api_delegate> efl_file_mmap_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_file_mmap_set_api_delegate>(Module, "efl_file_mmap_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static CoreUI.DataTypes.Error mmap_set(System.IntPtr obj, System.IntPtr pd, CoreUI.DataTypes.File f)
        {
            CoreUI.DataTypes.Log.Debug("function efl_file_mmap_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.DataTypes.Error _ret_var = default(CoreUI.DataTypes.Error);
                try
                {
                    _ret_var = ((IFile)ws.Target).SetMmap(f);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_file_mmap_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), f);
            }
        }

        private static efl_file_mmap_set_delegate efl_file_mmap_set_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_file_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))]
        internal delegate System.String efl_file_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_file_get_api_delegate> efl_file_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_file_get_api_delegate>(Module, "efl_file_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static System.String file_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_file_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((IFile)ws.Target).GetFile();
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_file_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_file_get_delegate efl_file_get_static_delegate;

        
        private delegate CoreUI.DataTypes.Error efl_file_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String file);

        
        internal delegate CoreUI.DataTypes.Error efl_file_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String file);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_file_set_api_delegate> efl_file_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_file_set_api_delegate>(Module, "efl_file_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static CoreUI.DataTypes.Error file_set(System.IntPtr obj, System.IntPtr pd, System.String file)
        {
            CoreUI.DataTypes.Log.Debug("function efl_file_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.DataTypes.Error _ret_var = default(CoreUI.DataTypes.Error);
                try
                {
                    _ret_var = ((IFile)ws.Target).SetFile(file);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_file_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), file);
            }
        }

        private static efl_file_set_delegate efl_file_set_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_file_key_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))]
        internal delegate System.String efl_file_key_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_file_key_get_api_delegate> efl_file_key_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_file_key_get_api_delegate>(Module, "efl_file_key_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static System.String key_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_file_key_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((IFile)ws.Target).GetKey();
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_file_key_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_file_key_get_delegate efl_file_key_get_static_delegate;

        
        private delegate void efl_file_key_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String key);

        
        internal delegate void efl_file_key_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String key);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_file_key_set_api_delegate> efl_file_key_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_file_key_set_api_delegate>(Module, "efl_file_key_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void key_set(System.IntPtr obj, System.IntPtr pd, System.String key)
        {
            CoreUI.DataTypes.Log.Debug("function efl_file_key_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IFile)ws.Target).SetKey(key);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_file_key_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), key);
            }
        }

        private static efl_file_key_set_delegate efl_file_key_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_file_loaded_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        internal delegate bool efl_file_loaded_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_file_loaded_get_api_delegate> efl_file_loaded_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_file_loaded_get_api_delegate>(Module, "efl_file_loaded_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static bool loaded_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_file_loaded_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IFile)ws.Target).GetLoaded();
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_file_loaded_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_file_loaded_get_delegate efl_file_loaded_get_static_delegate;

        
        private delegate CoreUI.DataTypes.Error efl_file_load_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate CoreUI.DataTypes.Error efl_file_load_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_file_load_api_delegate> efl_file_load_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_file_load_api_delegate>(Module, "efl_file_load");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static CoreUI.DataTypes.Error load(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_file_load was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.DataTypes.Error _ret_var = default(CoreUI.DataTypes.Error);
                try
                {
                    _ret_var = ((IFile)ws.Target).Load();
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_file_load_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_file_load_delegate efl_file_load_static_delegate;

        
        private delegate void efl_file_unload_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate void efl_file_unload_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_file_unload_api_delegate> efl_file_unload_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_file_unload_api_delegate>(Module, "efl_file_unload");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void unload(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_file_unload was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IFile)ws.Target).Unload();
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_file_unload_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_file_unload_delegate efl_file_unload_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

    }
}

namespace CoreUI {
#pragma warning disable CS1591
    /// <since_tizen> 6 </since_tizen>
    public static class FileExtensions {
        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.DataTypes.File> Mmap<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.IFile, T>magic = null) where T : CoreUI.IFile {
            return new CoreUI.BindableProperty<CoreUI.DataTypes.File>("mmap", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<System.String> File<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.IFile, T>magic = null) where T : CoreUI.IFile {
            return new CoreUI.BindableProperty<System.String>("file", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<System.String> Key<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.IFile, T>magic = null) where T : CoreUI.IFile {
            return new CoreUI.BindableProperty<System.String>("key", fac.GetPropBind());
        }

    }
#pragma warning restore CS1591
}

