#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Ui {

/// <summary>Interface for all translatable text APIs.
/// This is intended for translation of human readable on-screen text strings but may also be used in text-to-speech situations.</summary>
[Efl.Ui.IL10nConcrete.NativeMethods]
public interface IL10n : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>A unique string to be translated.
/// Often this will be a human-readable string (e.g. in English) but it can also be a unique string identifier that must then be translated to the current locale with <c>dgettext</c>() or any similar mechanism.
/// 
/// Setting this property will enable translation for this object or part.</summary>
/// <param name="domain">A translation domain. If <c>null</c> this means the default domain is used.</param>
/// <returns>This returns the untranslated value of <c>label</c>. The translated string can usually be retrieved with <see cref="Efl.IText.GetText"/>.</returns>
System.String GetL10nText(out System.String domain);
    /// <summary>Sets the new untranslated string and domain for this object.</summary>
/// <param name="label">A unique (untranslated) string.</param>
/// <param name="domain">A translation domain. If <c>null</c> this uses the default domain (eg. set by <c>textdomain</c>()).</param>
void SetL10nText(System.String label, System.String domain);
    /// <summary>Requests this object to update its text strings for the current locale.
/// Currently strings are translated with <c>dgettext</c>, so support for this function may depend on the platform. It is up to the application to provide its own translation data.
/// 
/// This function is a hook meant to be implemented by any object that supports translation. This can be called whenever a new object is created or when the current locale changes, for instance. This should only trigger further calls to <see cref="Efl.Ui.IL10n.UpdateTranslation"/> to children objects.</summary>
void UpdateTranslation();
            }
/// <summary>Interface for all translatable text APIs.
/// This is intended for translation of human readable on-screen text strings but may also be used in text-to-speech situations.</summary>
sealed public class IL10nConcrete : 

IL10n
    
{
    ///<summary>Pointer to the native class description.</summary>
    public System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(IL10nConcrete))
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

    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_ui_l10n_interface_get();
    /// <summary>Initializes a new instance of the <see cref="IL10n"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    private IL10nConcrete(System.IntPtr raw)
    {
        handle = raw;
    }
    ///<summary>Destructor.</summary>
    ~IL10nConcrete()
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

    /// <summary>A unique string to be translated.
    /// Often this will be a human-readable string (e.g. in English) but it can also be a unique string identifier that must then be translated to the current locale with <c>dgettext</c>() or any similar mechanism.
    /// 
    /// Setting this property will enable translation for this object or part.</summary>
    /// <param name="domain">A translation domain. If <c>null</c> this means the default domain is used.</param>
    /// <returns>This returns the untranslated value of <c>label</c>. The translated string can usually be retrieved with <see cref="Efl.IText.GetText"/>.</returns>
    public System.String GetL10nText(out System.String domain) {
                                 var _ret_var = Efl.Ui.IL10nConcrete.NativeMethods.efl_ui_l10n_text_get_ptr.Value.Delegate(this.NativeHandle,out domain);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Sets the new untranslated string and domain for this object.</summary>
    /// <param name="label">A unique (untranslated) string.</param>
    /// <param name="domain">A translation domain. If <c>null</c> this uses the default domain (eg. set by <c>textdomain</c>()).</param>
    public void SetL10nText(System.String label, System.String domain) {
                                                         Efl.Ui.IL10nConcrete.NativeMethods.efl_ui_l10n_text_set_ptr.Value.Delegate(this.NativeHandle,label, domain);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Requests this object to update its text strings for the current locale.
    /// Currently strings are translated with <c>dgettext</c>, so support for this function may depend on the platform. It is up to the application to provide its own translation data.
    /// 
    /// This function is a hook meant to be implemented by any object that supports translation. This can be called whenever a new object is created or when the current locale changes, for instance. This should only trigger further calls to <see cref="Efl.Ui.IL10n.UpdateTranslation"/> to children objects.</summary>
    public void UpdateTranslation() {
         Efl.Ui.IL10nConcrete.NativeMethods.efl_ui_l10n_translation_update_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
         }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.IL10nConcrete.efl_ui_l10n_interface_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public class NativeMethods  : Efl.Eo.NativeClass
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Elementary);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_ui_l10n_text_get_static_delegate == null)
            {
                efl_ui_l10n_text_get_static_delegate = new efl_ui_l10n_text_get_delegate(l10n_text_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetL10nText") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_l10n_text_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_l10n_text_get_static_delegate) });
            }

            if (efl_ui_l10n_text_set_static_delegate == null)
            {
                efl_ui_l10n_text_set_static_delegate = new efl_ui_l10n_text_set_delegate(l10n_text_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetL10nText") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_l10n_text_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_l10n_text_set_static_delegate) });
            }

            if (efl_ui_l10n_translation_update_static_delegate == null)
            {
                efl_ui_l10n_translation_update_static_delegate = new efl_ui_l10n_translation_update_delegate(translation_update);
            }

            if (methods.FirstOrDefault(m => m.Name == "UpdateTranslation") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_l10n_translation_update"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_l10n_translation_update_static_delegate) });
            }

            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.IL10nConcrete.efl_ui_l10n_interface_get();
        }

        #pragma warning disable CA1707, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_ui_l10n_text_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] out System.String domain);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_ui_l10n_text_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] out System.String domain);

        public static Efl.Eo.FunctionWrapper<efl_ui_l10n_text_get_api_delegate> efl_ui_l10n_text_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_l10n_text_get_api_delegate>(Module, "efl_ui_l10n_text_get");

        private static System.String l10n_text_get(System.IntPtr obj, System.IntPtr pd, out System.String domain)
        {
            Eina.Log.Debug("function efl_ui_l10n_text_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                System.String _out_domain = default(System.String);
                    System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((IL10n)wrapper).GetL10nText(out _out_domain);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        domain = _out_domain;
                return _ret_var;

            }
            else
            {
                return efl_ui_l10n_text_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out domain);
            }
        }

        private static efl_ui_l10n_text_get_delegate efl_ui_l10n_text_get_static_delegate;

        
        private delegate void efl_ui_l10n_text_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String label, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String domain);

        
        public delegate void efl_ui_l10n_text_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String label, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String domain);

        public static Efl.Eo.FunctionWrapper<efl_ui_l10n_text_set_api_delegate> efl_ui_l10n_text_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_l10n_text_set_api_delegate>(Module, "efl_ui_l10n_text_set");

        private static void l10n_text_set(System.IntPtr obj, System.IntPtr pd, System.String label, System.String domain)
        {
            Eina.Log.Debug("function efl_ui_l10n_text_set was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                                            
                try
                {
                    ((IL10n)wrapper).SetL10nText(label, domain);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_l10n_text_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), label, domain);
            }
        }

        private static efl_ui_l10n_text_set_delegate efl_ui_l10n_text_set_static_delegate;

        
        private delegate void efl_ui_l10n_translation_update_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_ui_l10n_translation_update_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_l10n_translation_update_api_delegate> efl_ui_l10n_translation_update_ptr = new Efl.Eo.FunctionWrapper<efl_ui_l10n_translation_update_api_delegate>(Module, "efl_ui_l10n_translation_update");

        private static void translation_update(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_l10n_translation_update was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            
                try
                {
                    ((IL10n)wrapper).UpdateTranslation();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_ui_l10n_translation_update_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_l10n_translation_update_delegate efl_ui_l10n_translation_update_static_delegate;

        #pragma warning restore CA1707, SA1300, SA1600

}
}
}

}

