#define EFL_BETA
#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Ui {

/// <summary>A Popup backwall is the background object for an <see cref="Efl.Ui.Popup"/> widget. It can be returned from a given Popup widget by using the <see cref="Efl.IPart"/> API to fetch the &quot;backwall&quot; part.
/// This object provides functionality for determining the look and interaction methods of a Popup&apos;s background.
/// 
/// If a Popup should allow input events to reach the objects behind the Popup, <see cref="Efl.Ui.PopupPartBackwall.RepeatEvents"/> can be enabled.
/// 
/// To set an image to be used as a background for the Popup, the <see cref="Efl.IFile"/> API can be used directly on the backwall object.</summary>
[Efl.Ui.PopupPartBackwall.NativeMethods]
[Efl.Eo.BindingEntity]
public class PopupPartBackwall : Efl.Ui.LayoutPart, Efl.IFile
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(PopupPartBackwall))
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
        efl_ui_popup_part_backwall_class_get();

    /// <summary>Initializes a new instance of the <see cref="PopupPartBackwall"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public PopupPartBackwall(Efl.Object parent= null
            ) : base(efl_ui_popup_part_backwall_class_get(), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected PopupPartBackwall(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="PopupPartBackwall"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected PopupPartBackwall(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="PopupPartBackwall"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected PopupPartBackwall(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }


    /// <summary>If this property is set to <c>true</c>, input events will be able to reach objects below the Popup. This allows for e.g., a click to activate a widget below the Popup while the Popup is active.</summary>
    /// <returns>Whether to repeat events to objects below the Popup. The default is <c>false</c>.</returns>
    public virtual bool GetRepeatEvents() {
        var _ret_var = Efl.Ui.PopupPartBackwall.NativeMethods.efl_ui_popup_part_backwall_repeat_events_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>If this property is set to <c>true</c>, input events will be able to reach objects below the Popup. This allows for e.g., a click to activate a widget below the Popup while the Popup is active.</summary>
    /// <param name="repeat">Whether to repeat events to objects below the Popup. The default is <c>false</c>.</param>
    public virtual void SetRepeatEvents(bool repeat) {
        Efl.Ui.PopupPartBackwall.NativeMethods.efl_ui_popup_part_backwall_repeat_events_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),repeat);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>The mmaped file from where an object will fetch the real data (it must be an <see cref="Eina.File"/>).
    /// If mmap is set during object construction, the object will automatically call <see cref="Efl.IFile.Load"/> during the finalize phase of construction.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The handle to the <see cref="Eina.File"/> that will be used</returns>
    public virtual Eina.File GetMmap() {
        var _ret_var = Efl.FileConcrete.NativeMethods.efl_file_mmap_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>The mmaped file from where an object will fetch the real data (it must be an <see cref="Eina.File"/>).
    /// If mmap is set during object construction, the object will automatically call <see cref="Efl.IFile.Load"/> during the finalize phase of construction.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="f">The handle to the <see cref="Eina.File"/> that will be used</param>
    /// <returns>0 on success, error code otherwise</returns>
    public virtual Eina.Error SetMmap(Eina.File f) {
        var _ret_var = Efl.FileConcrete.NativeMethods.efl_file_mmap_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),f);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>The file path from where an object will fetch the data.
    /// If file is set during object construction, the object will automatically call <see cref="Efl.IFile.Load"/> during the finalize phase of construction.
    /// 
    /// You must not modify the strings on the returned pointers.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The file path.</returns>
    public virtual System.String GetFile() {
        var _ret_var = Efl.FileConcrete.NativeMethods.efl_file_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>The file path from where an object will fetch the data.
    /// If file is set during object construction, the object will automatically call <see cref="Efl.IFile.Load"/> during the finalize phase of construction.
    /// 
    /// You must not modify the strings on the returned pointers.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="file">The file path.</param>
    /// <returns>0 on success, error code otherwise</returns>
    public virtual Eina.Error SetFile(System.String file) {
        var _ret_var = Efl.FileConcrete.NativeMethods.efl_file_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),file);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>The key which corresponds to the target data within a file.
    /// Some file types can contain multiple data streams which are indexed by a key. Use this property for such cases (See for example <see cref="Efl.Ui.Image"/> or <see cref="Efl.Ui.Layout"/>).
    /// 
    /// You must not modify the strings on the returned pointers.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The group that the data belongs to. See the class documentation for particular implementations of this interface to see how this property is used.</returns>
    public virtual System.String GetKey() {
        var _ret_var = Efl.FileConcrete.NativeMethods.efl_file_key_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>The key which corresponds to the target data within a file.
    /// Some file types can contain multiple data streams which are indexed by a key. Use this property for such cases (See for example <see cref="Efl.Ui.Image"/> or <see cref="Efl.Ui.Layout"/>).
    /// 
    /// You must not modify the strings on the returned pointers.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="key">The group that the data belongs to. See the class documentation for particular implementations of this interface to see how this property is used.</param>
    public virtual void SetKey(System.String key) {
        Efl.FileConcrete.NativeMethods.efl_file_key_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),key);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>The load state of the object.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns><c>true</c> if the object is loaded, <c>false</c> otherwise.</returns>
    public virtual bool GetLoaded() {
        var _ret_var = Efl.FileConcrete.NativeMethods.efl_file_loaded_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Perform all necessary operations to open and load file data into the object using the <see cref="Efl.IFile.File"/> (or <see cref="Efl.IFile.Mmap"/>) and <see cref="Efl.IFile.Key"/> properties.
    /// In the case where <see cref="Efl.IFile.SetFile"/> has been called on an object, this will internally open the file and call <see cref="Efl.IFile.SetMmap"/> on the object using the opened file handle.
    /// 
    /// Calling <see cref="Efl.IFile.Load"/> on an object which has already performed file operations based on the currently set properties will have no effect.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>0 on success, error code otherwise</returns>
    public virtual Eina.Error Load() {
        var _ret_var = Efl.FileConcrete.NativeMethods.efl_file_load_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Perform all necessary operations to unload file data from the object.
    /// In the case where <see cref="Efl.IFile.SetMmap"/> has been externally called on an object, the file handle stored in the object will be preserved.
    /// 
    /// Calling <see cref="Efl.IFile.Unload"/> on an object which is not currently loaded will have no effect.</summary>
    /// <since_tizen> 6 </since_tizen>
    public virtual void Unload() {
        Efl.FileConcrete.NativeMethods.efl_file_unload_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>If this property is set to <c>true</c>, input events will be able to reach objects below the Popup. This allows for e.g., a click to activate a widget below the Popup while the Popup is active.</summary>
    /// <value>Whether to repeat events to objects below the Popup. The default is <c>false</c>.</value>
    public bool RepeatEvents {
        get { return GetRepeatEvents(); }
        set { SetRepeatEvents(value); }
    }

    /// <summary>The mmaped file from where an object will fetch the real data (it must be an <see cref="Eina.File"/>).
    /// If mmap is set during object construction, the object will automatically call <see cref="Efl.IFile.Load"/> during the finalize phase of construction.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>The handle to the <see cref="Eina.File"/> that will be used</value>
    public Eina.File Mmap {
        get { return GetMmap(); }
        set { SetMmap(value); }
    }

    /// <summary>The file path from where an object will fetch the data.
    /// If file is set during object construction, the object will automatically call <see cref="Efl.IFile.Load"/> during the finalize phase of construction.
    /// 
    /// You must not modify the strings on the returned pointers.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>The file path.</value>
    public System.String File {
        get { return GetFile(); }
        set { SetFile(value); }
    }

    /// <summary>The key which corresponds to the target data within a file.
    /// Some file types can contain multiple data streams which are indexed by a key. Use this property for such cases (See for example <see cref="Efl.Ui.Image"/> or <see cref="Efl.Ui.Layout"/>).
    /// 
    /// You must not modify the strings on the returned pointers.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>The group that the data belongs to. See the class documentation for particular implementations of this interface to see how this property is used.</value>
    public System.String Key {
        get { return GetKey(); }
        set { SetKey(value); }
    }

    /// <summary>The load state of the object.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><c>true</c> if the object is loaded, <c>false</c> otherwise.</value>
    public bool Loaded {
        get { return GetLoaded(); }
    }

    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.PopupPartBackwall.efl_ui_popup_part_backwall_class_get();
    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Ui.LayoutPart.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(efl.Libs.Elementary);

        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_ui_popup_part_backwall_repeat_events_get_static_delegate == null)
            {
                efl_ui_popup_part_backwall_repeat_events_get_static_delegate = new efl_ui_popup_part_backwall_repeat_events_get_delegate(repeat_events_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetRepeatEvents") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_popup_part_backwall_repeat_events_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_popup_part_backwall_repeat_events_get_static_delegate) });
            }

            if (efl_ui_popup_part_backwall_repeat_events_set_static_delegate == null)
            {
                efl_ui_popup_part_backwall_repeat_events_set_static_delegate = new efl_ui_popup_part_backwall_repeat_events_set_delegate(repeat_events_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetRepeatEvents") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_popup_part_backwall_repeat_events_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_popup_part_backwall_repeat_events_set_static_delegate) });
            }

            if (includeInherited)
            {
                var all_interfaces = type.GetInterfaces();
                foreach (var iface in all_interfaces)
                {
                    var moredescs = ((Efl.Eo.NativeClass)iface.GetCustomAttributes(false)?.FirstOrDefault(attr => attr is Efl.Eo.NativeClass))?.GetEoOps(type, false);
                    if (moredescs != null)
                        descs.AddRange(moredescs);
                }
            }
            descs.AddRange(base.GetEoOps(type, false));
            return descs;
        }

        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.PopupPartBackwall.efl_ui_popup_part_backwall_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_popup_part_backwall_repeat_events_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_popup_part_backwall_repeat_events_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_popup_part_backwall_repeat_events_get_api_delegate> efl_ui_popup_part_backwall_repeat_events_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_popup_part_backwall_repeat_events_get_api_delegate>(Module, "efl_ui_popup_part_backwall_repeat_events_get");

        private static bool repeat_events_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_popup_part_backwall_repeat_events_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((PopupPartBackwall)ws.Target).GetRepeatEvents();
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
                return efl_ui_popup_part_backwall_repeat_events_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_popup_part_backwall_repeat_events_get_delegate efl_ui_popup_part_backwall_repeat_events_get_static_delegate;

        
        private delegate void efl_ui_popup_part_backwall_repeat_events_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool repeat);

        
        public delegate void efl_ui_popup_part_backwall_repeat_events_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool repeat);

        public static Efl.Eo.FunctionWrapper<efl_ui_popup_part_backwall_repeat_events_set_api_delegate> efl_ui_popup_part_backwall_repeat_events_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_popup_part_backwall_repeat_events_set_api_delegate>(Module, "efl_ui_popup_part_backwall_repeat_events_set");

        private static void repeat_events_set(System.IntPtr obj, System.IntPtr pd, bool repeat)
        {
            Eina.Log.Debug("function efl_ui_popup_part_backwall_repeat_events_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((PopupPartBackwall)ws.Target).SetRepeatEvents(repeat);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_popup_part_backwall_repeat_events_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), repeat);
            }
        }

        private static efl_ui_popup_part_backwall_repeat_events_set_delegate efl_ui_popup_part_backwall_repeat_events_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}
}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_UiPopupPartBackwall_ExtensionMethods {
    public static Efl.BindableProperty<bool> RepeatEvents<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.PopupPartBackwall, T>magic = null) where T : Efl.Ui.PopupPartBackwall {
        return new Efl.BindableProperty<bool>("repeat_events", fac);
    }

    public static Efl.BindableProperty<bool> RepeatEvents<T>(this Efl.BindablePart<T> part, Efl.Csharp.ExtensionTag<Efl.Ui.PopupPartBackwall, T>magic = null) where T : Efl.Ui.PopupPartBackwall {
        return new Efl.BindableProperty<bool>(part.PartName, "repeat_events", part.Binder);
    }

    public static Efl.BindableProperty<Eina.File> Mmap<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.PopupPartBackwall, T>magic = null) where T : Efl.Ui.PopupPartBackwall {
        return new Efl.BindableProperty<Eina.File>("mmap", fac);
    }

    public static Efl.BindableProperty<Eina.File> Mmap<T>(this Efl.BindablePart<T> part, Efl.Csharp.ExtensionTag<Efl.Ui.PopupPartBackwall, T>magic = null) where T : Efl.Ui.PopupPartBackwall {
        return new Efl.BindableProperty<Eina.File>(part.PartName, "mmap", part.Binder);
    }

    public static Efl.BindableProperty<System.String> File<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.PopupPartBackwall, T>magic = null) where T : Efl.Ui.PopupPartBackwall {
        return new Efl.BindableProperty<System.String>("file", fac);
    }

    public static Efl.BindableProperty<System.String> File<T>(this Efl.BindablePart<T> part, Efl.Csharp.ExtensionTag<Efl.Ui.PopupPartBackwall, T>magic = null) where T : Efl.Ui.PopupPartBackwall {
        return new Efl.BindableProperty<System.String>(part.PartName, "file", part.Binder);
    }

    public static Efl.BindableProperty<System.String> Key<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.PopupPartBackwall, T>magic = null) where T : Efl.Ui.PopupPartBackwall {
        return new Efl.BindableProperty<System.String>("key", fac);
    }

    public static Efl.BindableProperty<System.String> Key<T>(this Efl.BindablePart<T> part, Efl.Csharp.ExtensionTag<Efl.Ui.PopupPartBackwall, T>magic = null) where T : Efl.Ui.PopupPartBackwall {
        return new Efl.BindableProperty<System.String>(part.PartName, "key", part.Binder);
    }

}
#pragma warning restore CS1591
#endif
