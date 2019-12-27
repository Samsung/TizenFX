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
namespace CoreUI.UI {
    /// <summary>EFL layout widget class.
    /// 
    /// When loading layouts from a file, use the <see cref="CoreUI.IFile.Key"/> property to specify the group that the data belongs to, in case it&apos;s an EET file (including Edje files).
    /// 
    /// By default, layouts do not apply the finger_size global configuration value when calculating their geometries.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.UI.Layout.NativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public class Layout : CoreUI.UI.LayoutBase, CoreUI.IFile
    {
        /// <summary>Pointer to the native class description.</summary>
        public override System.IntPtr NativeClass
        {
            get
            {
                if (((object)this).GetType() == typeof(Layout))
                {
                    return GetCoreUIClassStatic();
                }
                else
                {
                    return CoreUI.Wrapper.ClassRegister.klassFromType[((object)this).GetType()];
                }
            }
        }

        [System.Runtime.InteropServices.DllImport(CoreUI.Libs.Elementary)] internal static extern System.IntPtr
            efl_ui_layout_class_get();

        /// <summary>Initializes a new instance of the <see cref="Layout"/> class.
        /// </summary>
        /// <param name="parent">Parent instance.</param>
    /// <param name="style">The widget style to use. See <see cref="CoreUI.UI.Widget.SetStyle" /></param>
        public Layout(CoreUI.Object parent, System.String style = null) : base(efl_ui_layout_class_get(), parent)
        {
            if (CoreUI.Wrapper.Globals.ParamHelperCheck(style))
            {
                SetStyle(CoreUI.Wrapper.Globals.GetParamHelper(style));
            }

            FinishInstantiation();
        }

        /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
        /// Do not call this constructor directly.
        /// </summary>
        /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
        protected Layout(ConstructingHandle ch) : base(ch)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="Layout"/> class.
        /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.
        /// </summary>
        /// <param name="wh">The native pointer to be wrapped.</param>
        internal Layout(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="Layout"/> class.
        /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.
        /// </summary>
        /// <param name="baseKlass">The pointer to the base native Eo class.</param>
        /// <param name="parent">The CoreUI.Object parent of this instance.</param>
        protected Layout(IntPtr baseKlass, CoreUI.Object parent) : base(baseKlass, parent)
        {
        }


        /// <summary>The mmaped file from where an object will fetch the real data (it must be an <see cref="CoreUI.DataTypes.File"/>).
        /// 
        /// If mmap is set during object construction, the object will automatically call <see cref="CoreUI.IFile.Load"/> during the finalize phase of construction.</summary>
        /// <returns>The handle to the <see cref="CoreUI.DataTypes.File"/> that will be used</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.DataTypes.File GetMmap() {
            var _ret_var = CoreUI.IFileNativeMethods.efl_file_mmap_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The mmaped file from where an object will fetch the real data (it must be an <see cref="CoreUI.DataTypes.File"/>).
        /// 
        /// If mmap is set during object construction, the object will automatically call <see cref="CoreUI.IFile.Load"/> during the finalize phase of construction.</summary>
        /// <param name="f">The handle to the <see cref="CoreUI.DataTypes.File"/> that will be used</param>
        /// <returns>0 on success, error code otherwise</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.DataTypes.Error SetMmap(CoreUI.DataTypes.File f) {
            var _ret_var = CoreUI.IFileNativeMethods.efl_file_mmap_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), f);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The file path from where an object will fetch the data.
        /// 
        /// If file is set during object construction, the object will automatically call <see cref="CoreUI.IFile.Load"/> during the finalize phase of construction.
        /// 
        /// You must not modify the strings on the returned pointers.</summary>
        /// <returns>The file path.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual System.String GetFile() {
            var _ret_var = CoreUI.IFileNativeMethods.efl_file_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The file path from where an object will fetch the data.
        /// 
        /// If file is set during object construction, the object will automatically call <see cref="CoreUI.IFile.Load"/> during the finalize phase of construction.
        /// 
        /// You must not modify the strings on the returned pointers.</summary>
        /// <param name="file">The file path.</param>
        /// <returns>0 on success, error code otherwise</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.DataTypes.Error SetFile(System.String file) {
            var _ret_var = CoreUI.IFileNativeMethods.efl_file_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), file);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The key which corresponds to the target data within a file.
        /// 
        /// Some file types can contain multiple data streams which are indexed by a key. Use this property for such cases (See for example <see cref="CoreUI.UI.Image"/> or <see cref="CoreUI.UI.Layout"/>).
        /// 
        /// You must not modify the strings on the returned pointers.</summary>
        /// <returns>The group that the data belongs to. See the class documentation for particular implementations of this interface to see how this property is used.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual System.String GetKey() {
            var _ret_var = CoreUI.IFileNativeMethods.efl_file_key_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The key which corresponds to the target data within a file.
        /// 
        /// Some file types can contain multiple data streams which are indexed by a key. Use this property for such cases (See for example <see cref="CoreUI.UI.Image"/> or <see cref="CoreUI.UI.Layout"/>).
        /// 
        /// You must not modify the strings on the returned pointers.</summary>
        /// <param name="key">The group that the data belongs to. See the class documentation for particular implementations of this interface to see how this property is used.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetKey(System.String key) {
            CoreUI.IFileNativeMethods.efl_file_key_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), key);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The load state of the object.</summary>
        /// <returns><c>true</c> if the object is loaded, <c>false</c> otherwise.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetLoaded() {
            var _ret_var = CoreUI.IFileNativeMethods.efl_file_loaded_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Perform all necessary operations to open and load file data into the object using the <see cref="CoreUI.IFile.File"/> (or <see cref="CoreUI.IFile.Mmap"/>) and <see cref="CoreUI.IFile.Key"/> properties.
        /// 
        /// In the case where <see cref="CoreUI.IFile.SetFile"/> has been called on an object, this will internally open the file and call <see cref="CoreUI.IFile.SetMmap"/> on the object using the opened file handle.
        /// 
        /// Calling <see cref="CoreUI.IFile.Load"/> on an object which has already performed file operations based on the currently set properties will have no effect.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <returns>0 on success, error code otherwise</returns>
        public virtual CoreUI.DataTypes.Error Load() {
            var _ret_var = CoreUI.IFileNativeMethods.efl_file_load_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Perform all necessary operations to unload file data from the object.
        /// 
        /// In the case where <see cref="CoreUI.IFile.SetMmap"/> has been externally called on an object, the file handle stored in the object will be preserved.
        /// 
        /// Calling <see cref="CoreUI.IFile.Unload"/> on an object which is not currently loaded will have no effect.</summary>
        /// <since_tizen> 6 </since_tizen>
        public virtual void Unload() {
            CoreUI.IFileNativeMethods.efl_file_unload_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The mmaped file from where an object will fetch the real data (it must be an <see cref="CoreUI.DataTypes.File"/>).
        /// 
        /// If mmap is set during object construction, the object will automatically call <see cref="CoreUI.IFile.Load"/> during the finalize phase of construction.</summary>
        /// <value>The handle to the <see cref="CoreUI.DataTypes.File"/> that will be used</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.DataTypes.File Mmap {
            get { return GetMmap(); }
            set { SetMmap(value); }
        }

        /// <summary>The file path from where an object will fetch the data.
        /// 
        /// If file is set during object construction, the object will automatically call <see cref="CoreUI.IFile.Load"/> during the finalize phase of construction.
        /// 
        /// You must not modify the strings on the returned pointers.</summary>
        /// <value>The file path.</value>
        /// <since_tizen> 6 </since_tizen>
        public System.String File {
            get { return GetFile(); }
            set { SetFile(value); }
        }

        /// <summary>The key which corresponds to the target data within a file.
        /// 
        /// Some file types can contain multiple data streams which are indexed by a key. Use this property for such cases (See for example <see cref="CoreUI.UI.Image"/> or <see cref="CoreUI.UI.Layout"/>).
        /// 
        /// You must not modify the strings on the returned pointers.</summary>
        /// <value>The group that the data belongs to. See the class documentation for particular implementations of this interface to see how this property is used.</value>
        /// <since_tizen> 6 </since_tizen>
        public System.String Key {
            get { return GetKey(); }
            set { SetKey(value); }
        }

        /// <summary>The load state of the object.</summary>
        /// <value><c>true</c> if the object is loaded, <c>false</c> otherwise.</value>
        /// <since_tizen> 6 </since_tizen>
        public bool Loaded {
            get { return GetLoaded(); }
        }

        private static IntPtr GetCoreUIClassStatic()
        {
            return CoreUI.UI.Layout.efl_ui_layout_class_get();
        }

        /// <summary>Wrapper for native methods and virtual method delegates.
        /// For internal use by generated code only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal new class NativeMethods : CoreUI.UI.LayoutBase.NativeMethods
        {
            /// <summary>Gets the list of Eo operations to override.
        /// </summary>
            /// <returns>The list of Eo operations to be overload.</returns>
            internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
            {
                var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
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
                descs.AddRange(base.GetEoOps(type, false));
                return descs;
            }

            /// <summary>Returns the Eo class for the native methods of this class.
            /// </summary>
            /// <returns>The native class pointer.</returns>
            internal override IntPtr GetCoreUIClass()
            {
                return CoreUI.UI.Layout.efl_ui_layout_class_get();
            }

            #pragma warning disable CA1707, CS1591, SA1300, SA1600

            #pragma warning restore CA1707, CS1591, SA1300, SA1600

        }
    }
}

namespace CoreUI.UI {
#pragma warning disable CS1591
    /// <since_tizen> 6 </since_tizen>
    public static class LayoutExtensions {
        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.DataTypes.File> Mmap<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Layout, T>magic = null) where T : CoreUI.UI.Layout {
            return new CoreUI.BindableProperty<CoreUI.DataTypes.File>("mmap", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<System.String> File<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Layout, T>magic = null) where T : CoreUI.UI.Layout {
            return new CoreUI.BindableProperty<System.String>("file", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<System.String> Key<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Layout, T>magic = null) where T : CoreUI.UI.Layout {
            return new CoreUI.BindableProperty<System.String>("key", fac.GetPropBind());
        }

    }
#pragma warning restore CS1591
}

