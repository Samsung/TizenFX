#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Ui {

namespace TextFactory {

/// <summary>Factory that creates images given key string
/// The key can be either a full image path, or associated with one. The factory will fallback if key was not matches with an image, and try to load it as a full path.</summary>
[Efl.Ui.TextFactory.Images.NativeMethods]
public class Images : Efl.Object, Efl.Eo.IWrapper,Efl.Canvas.ITextFactory
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(Images))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_ui_text_factory_images_class_get();
    /// <summary>Initializes a new instance of the <see cref="Images"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public Images(Efl.Object parent= null
            ) : base(efl_ui_text_factory_images_class_get(), typeof(Images), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Initializes a new instance of the <see cref="Images"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="raw">The native pointer to be wrapped.</param>
    protected Images(System.IntPtr raw) : base(raw)
    {
            }

    /// <summary>Initializes a new instance of the <see cref="Images"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="managedType">The managed type of the public constructor that originated this call.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected Images(IntPtr baseKlass, System.Type managedType, Efl.Object parent) : base(baseKlass, managedType, parent)
    {
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

    /// <summary>Associates given name with a path of an image or EET file.
    /// This can be used for quick retrieval (instead of providing actual filenames.
    /// 
    /// This <c>file</c> is associated with <c>name</c> is considered a full file path.
    /// 
    /// see <see cref="Efl.Ui.TextFactory.Images.AddMatchesMmap"/> for mmap version see <see cref="Efl.Ui.TextFactory.Images.DelMatches"/></summary>
    /// <param name="name">the name associated with filename</param>
    /// <param name="path">the image or EET file path</param>
    /// <param name="key">the key to use (in cases of loading an EET file</param>
    /// <returns><c>true</c> if successful, <c>false</c> otherwise</returns>
    virtual public bool AddMatches(System.String name, System.String path, System.String key) {
                                                                                 var _ret_var = Efl.Ui.TextFactory.Images.NativeMethods.efl_ui_text_factory_images_matches_add_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),name, path, key);
        Eina.Error.RaiseIfUnhandledException();
                                                        return _ret_var;
 }
    /// <summary>Deletes an association of <c>key</c> with its respective file path.
    /// see <see cref="Efl.Ui.TextFactory.Images.AddMatches"/></summary>
    /// <param name="key">the entry&apos;s key to delete</param>
    /// <returns><c>true</c> if successful, <c>false</c> otherwise</returns>
    virtual public bool DelMatches(System.String key) {
                                 var _ret_var = Efl.Ui.TextFactory.Images.NativeMethods.efl_ui_text_factory_images_matches_del_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),key);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Associates given name with a mmap&apos;d image or EET file and key.
    /// see <see cref="Efl.Ui.TextFactory.Images.AddMatches"/> for string file path version see <see cref="Efl.Ui.TextFactory.Images.DelMatchesMmap"/></summary>
    /// <param name="name">the name associated with filename</param>
    /// <param name="file">the image or EET file</param>
    /// <param name="key">the key to use (in cases of loading an EET file</param>
    /// <returns><c>true</c> if successful, <c>false</c> otherwise</returns>
    virtual public bool AddMatchesMmap(System.String name, Eina.File file, System.String key) {
                                                                                 var _ret_var = Efl.Ui.TextFactory.Images.NativeMethods.efl_ui_text_factory_images_matches_mmap_add_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),name, file, key);
        Eina.Error.RaiseIfUnhandledException();
                                                        return _ret_var;
 }
    /// <summary>Deletes an association of <c>key</c> with its respective file.
    /// see <see cref="Efl.Ui.TextFactory.Images.AddMatchesMmap"/></summary>
    /// <param name="key">the entry&apos;s key to delete</param>
    /// <returns><c>true</c> if successful, <c>false</c> otherwise</returns>
    virtual public bool DelMatchesMmap(System.String key) {
                                 var _ret_var = Efl.Ui.TextFactory.Images.NativeMethods.efl_ui_text_factory_images_matches_mmap_del_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),key);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Translates a given <c>key</c> to an item object, and returns the object. The returned object should be owned by the passed <c>object</c>.</summary>
    /// <param name="kw_object">The parent of the created object</param>
    /// <param name="key">Key that is associated to an item object</param>
    virtual public Efl.Canvas.Object Create(Efl.Canvas.Object kw_object, System.String key) {
                                                         var _ret_var = Efl.Canvas.ITextFactoryConcrete.NativeMethods.efl_canvas_text_factory_create_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),kw_object, key);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.TextFactory.Images.efl_ui_text_factory_images_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Object.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Elementary);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_ui_text_factory_images_matches_add_static_delegate == null)
            {
                efl_ui_text_factory_images_matches_add_static_delegate = new efl_ui_text_factory_images_matches_add_delegate(matches_add);
            }

            if (methods.FirstOrDefault(m => m.Name == "AddMatches") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_text_factory_images_matches_add"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_factory_images_matches_add_static_delegate) });
            }

            if (efl_ui_text_factory_images_matches_del_static_delegate == null)
            {
                efl_ui_text_factory_images_matches_del_static_delegate = new efl_ui_text_factory_images_matches_del_delegate(matches_del);
            }

            if (methods.FirstOrDefault(m => m.Name == "DelMatches") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_text_factory_images_matches_del"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_factory_images_matches_del_static_delegate) });
            }

            if (efl_ui_text_factory_images_matches_mmap_add_static_delegate == null)
            {
                efl_ui_text_factory_images_matches_mmap_add_static_delegate = new efl_ui_text_factory_images_matches_mmap_add_delegate(matches_mmap_add);
            }

            if (methods.FirstOrDefault(m => m.Name == "AddMatchesMmap") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_text_factory_images_matches_mmap_add"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_factory_images_matches_mmap_add_static_delegate) });
            }

            if (efl_ui_text_factory_images_matches_mmap_del_static_delegate == null)
            {
                efl_ui_text_factory_images_matches_mmap_del_static_delegate = new efl_ui_text_factory_images_matches_mmap_del_delegate(matches_mmap_del);
            }

            if (methods.FirstOrDefault(m => m.Name == "DelMatchesMmap") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_text_factory_images_matches_mmap_del"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_factory_images_matches_mmap_del_static_delegate) });
            }

            if (efl_canvas_text_factory_create_static_delegate == null)
            {
                efl_canvas_text_factory_create_static_delegate = new efl_canvas_text_factory_create_delegate(create);
            }

            if (methods.FirstOrDefault(m => m.Name == "Create") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_text_factory_create"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_text_factory_create_static_delegate) });
            }

            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.TextFactory.Images.efl_ui_text_factory_images_class_get();
        }

        #pragma warning disable CA1707, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_text_factory_images_matches_add_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String name, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String path, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String key);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_text_factory_images_matches_add_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String name, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String path, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String key);

        public static Efl.Eo.FunctionWrapper<efl_ui_text_factory_images_matches_add_api_delegate> efl_ui_text_factory_images_matches_add_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_factory_images_matches_add_api_delegate>(Module, "efl_ui_text_factory_images_matches_add");

        private static bool matches_add(System.IntPtr obj, System.IntPtr pd, System.String name, System.String path, System.String key)
        {
            Eina.Log.Debug("function efl_ui_text_factory_images_matches_add was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                                                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Images)wrapper).AddMatches(name, path, key);
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
                return efl_ui_text_factory_images_matches_add_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), name, path, key);
            }
        }

        private static efl_ui_text_factory_images_matches_add_delegate efl_ui_text_factory_images_matches_add_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_text_factory_images_matches_del_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String key);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_text_factory_images_matches_del_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String key);

        public static Efl.Eo.FunctionWrapper<efl_ui_text_factory_images_matches_del_api_delegate> efl_ui_text_factory_images_matches_del_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_factory_images_matches_del_api_delegate>(Module, "efl_ui_text_factory_images_matches_del");

        private static bool matches_del(System.IntPtr obj, System.IntPtr pd, System.String key)
        {
            Eina.Log.Debug("function efl_ui_text_factory_images_matches_del was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Images)wrapper).DelMatches(key);
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
                return efl_ui_text_factory_images_matches_del_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), key);
            }
        }

        private static efl_ui_text_factory_images_matches_del_delegate efl_ui_text_factory_images_matches_del_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_text_factory_images_matches_mmap_add_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String name,  Eina.File file, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String key);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_text_factory_images_matches_mmap_add_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String name,  Eina.File file, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String key);

        public static Efl.Eo.FunctionWrapper<efl_ui_text_factory_images_matches_mmap_add_api_delegate> efl_ui_text_factory_images_matches_mmap_add_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_factory_images_matches_mmap_add_api_delegate>(Module, "efl_ui_text_factory_images_matches_mmap_add");

        private static bool matches_mmap_add(System.IntPtr obj, System.IntPtr pd, System.String name, Eina.File file, System.String key)
        {
            Eina.Log.Debug("function efl_ui_text_factory_images_matches_mmap_add was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                                                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Images)wrapper).AddMatchesMmap(name, file, key);
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
                return efl_ui_text_factory_images_matches_mmap_add_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), name, file, key);
            }
        }

        private static efl_ui_text_factory_images_matches_mmap_add_delegate efl_ui_text_factory_images_matches_mmap_add_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_text_factory_images_matches_mmap_del_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String key);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_text_factory_images_matches_mmap_del_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String key);

        public static Efl.Eo.FunctionWrapper<efl_ui_text_factory_images_matches_mmap_del_api_delegate> efl_ui_text_factory_images_matches_mmap_del_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_factory_images_matches_mmap_del_api_delegate>(Module, "efl_ui_text_factory_images_matches_mmap_del");

        private static bool matches_mmap_del(System.IntPtr obj, System.IntPtr pd, System.String key)
        {
            Eina.Log.Debug("function efl_ui_text_factory_images_matches_mmap_del was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Images)wrapper).DelMatchesMmap(key);
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
                return efl_ui_text_factory_images_matches_mmap_del_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), key);
            }
        }

        private static efl_ui_text_factory_images_matches_mmap_del_delegate efl_ui_text_factory_images_matches_mmap_del_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.OwnTag>))]
        private delegate Efl.Canvas.Object efl_canvas_text_factory_create_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Object kw_object, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String key);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.OwnTag>))]
        public delegate Efl.Canvas.Object efl_canvas_text_factory_create_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Object kw_object, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String key);

        public static Efl.Eo.FunctionWrapper<efl_canvas_text_factory_create_api_delegate> efl_canvas_text_factory_create_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_text_factory_create_api_delegate>(Module, "efl_canvas_text_factory_create");

        private static Efl.Canvas.Object create(System.IntPtr obj, System.IntPtr pd, Efl.Canvas.Object kw_object, System.String key)
        {
            Eina.Log.Debug("function efl_canvas_text_factory_create was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                                            Efl.Canvas.Object _ret_var = default(Efl.Canvas.Object);
                try
                {
                    _ret_var = ((Images)wrapper).Create(kw_object, key);
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
                return efl_canvas_text_factory_create_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), kw_object, key);
            }
        }

        private static efl_canvas_text_factory_create_delegate efl_canvas_text_factory_create_static_delegate;

        #pragma warning restore CA1707, SA1300, SA1600

}
}
}

}

}

