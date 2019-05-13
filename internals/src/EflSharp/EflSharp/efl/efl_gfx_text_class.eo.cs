#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Gfx {

/// <summary>Efl Gfx Text Class interface</summary>
[Efl.Gfx.ITextClassConcrete.NativeMethods]
public interface ITextClass : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Get font and font size from edje text class.
/// This function gets the font and the font size from text class. The font string will only be valid until the text class is changed or the edje object is deleted.</summary>
/// <param name="text_class">The text class name</param>
/// <param name="font">Font name</param>
/// <param name="size">Font Size</param>
/// <returns><c>true</c>, on success or <c>false</c>, on error</returns>
bool GetTextClass(System.String text_class, out System.String font, out Efl.Font.Size size);
    /// <summary>Set Edje text class.
/// This function sets the text class for the Edje.</summary>
/// <param name="text_class">The text class name</param>
/// <param name="font">Font name</param>
/// <param name="size">Font Size</param>
/// <returns><c>true</c>, on success or <c>false</c>, on error</returns>
bool SetTextClass(System.String text_class, System.String font, Efl.Font.Size size);
    /// <summary>Delete the text class.
/// This function deletes any values for the specified text class.
/// 
/// Deleting the text class will revert it to the values defined by <see cref="Efl.Gfx.ITextClass.GetTextClass"/> or the text class defined in the theme file.</summary>
/// <param name="text_class">The text class to be deleted.</param>
void DelTextClass(System.String text_class);
            }
/// <summary>Efl Gfx Text Class interface</summary>
sealed public class ITextClassConcrete : 

ITextClass
    
{
    ///<summary>Pointer to the native class description.</summary>
    public System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(ITextClassConcrete))
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
        efl_gfx_text_class_interface_get();
    /// <summary>Initializes a new instance of the <see cref="ITextClass"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    private ITextClassConcrete(System.IntPtr raw)
    {
        handle = raw;
    }
    ///<summary>Destructor.</summary>
    ~ITextClassConcrete()
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

    /// <summary>Get font and font size from edje text class.
    /// This function gets the font and the font size from text class. The font string will only be valid until the text class is changed or the edje object is deleted.</summary>
    /// <param name="text_class">The text class name</param>
    /// <param name="font">Font name</param>
    /// <param name="size">Font Size</param>
    /// <returns><c>true</c>, on success or <c>false</c>, on error</returns>
    public bool GetTextClass(System.String text_class, out System.String font, out Efl.Font.Size size) {
                                                                                 var _ret_var = Efl.Gfx.ITextClassConcrete.NativeMethods.efl_gfx_text_class_get_ptr.Value.Delegate(this.NativeHandle,text_class, out font, out size);
        Eina.Error.RaiseIfUnhandledException();
                                                        return _ret_var;
 }
    /// <summary>Set Edje text class.
    /// This function sets the text class for the Edje.</summary>
    /// <param name="text_class">The text class name</param>
    /// <param name="font">Font name</param>
    /// <param name="size">Font Size</param>
    /// <returns><c>true</c>, on success or <c>false</c>, on error</returns>
    public bool SetTextClass(System.String text_class, System.String font, Efl.Font.Size size) {
                                                                                 var _ret_var = Efl.Gfx.ITextClassConcrete.NativeMethods.efl_gfx_text_class_set_ptr.Value.Delegate(this.NativeHandle,text_class, font, size);
        Eina.Error.RaiseIfUnhandledException();
                                                        return _ret_var;
 }
    /// <summary>Delete the text class.
    /// This function deletes any values for the specified text class.
    /// 
    /// Deleting the text class will revert it to the values defined by <see cref="Efl.Gfx.ITextClass.GetTextClass"/> or the text class defined in the theme file.</summary>
    /// <param name="text_class">The text class to be deleted.</param>
    public void DelTextClass(System.String text_class) {
                                 Efl.Gfx.ITextClassConcrete.NativeMethods.efl_gfx_text_class_del_ptr.Value.Delegate(this.NativeHandle,text_class);
        Eina.Error.RaiseIfUnhandledException();
                         }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Gfx.ITextClassConcrete.efl_gfx_text_class_interface_get();
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

            if (efl_gfx_text_class_get_static_delegate == null)
            {
                efl_gfx_text_class_get_static_delegate = new efl_gfx_text_class_get_delegate(text_class_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetTextClass") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_text_class_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_text_class_get_static_delegate) });
            }

            if (efl_gfx_text_class_set_static_delegate == null)
            {
                efl_gfx_text_class_set_static_delegate = new efl_gfx_text_class_set_delegate(text_class_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetTextClass") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_text_class_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_text_class_set_static_delegate) });
            }

            if (efl_gfx_text_class_del_static_delegate == null)
            {
                efl_gfx_text_class_del_static_delegate = new efl_gfx_text_class_del_delegate(text_class_del);
            }

            if (methods.FirstOrDefault(m => m.Name == "DelTextClass") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_text_class_del"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_text_class_del_static_delegate) });
            }

            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Gfx.ITextClassConcrete.efl_gfx_text_class_interface_get();
        }

        #pragma warning disable CA1707, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_gfx_text_class_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String text_class, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] out System.String font,  out Efl.Font.Size size);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_gfx_text_class_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String text_class, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] out System.String font,  out Efl.Font.Size size);

        public static Efl.Eo.FunctionWrapper<efl_gfx_text_class_get_api_delegate> efl_gfx_text_class_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_text_class_get_api_delegate>(Module, "efl_gfx_text_class_get");

        private static bool text_class_get(System.IntPtr obj, System.IntPtr pd, System.String text_class, out System.String font, out Efl.Font.Size size)
        {
            Eina.Log.Debug("function efl_gfx_text_class_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                        System.String _out_font = default(System.String);
        size = default(Efl.Font.Size);                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((ITextClass)wrapper).GetTextClass(text_class, out _out_font, out size);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                font = _out_font;
                                        return _ret_var;

            }
            else
            {
                return efl_gfx_text_class_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), text_class, out font, out size);
            }
        }

        private static efl_gfx_text_class_get_delegate efl_gfx_text_class_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_gfx_text_class_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String text_class, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String font,  Efl.Font.Size size);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_gfx_text_class_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String text_class, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String font,  Efl.Font.Size size);

        public static Efl.Eo.FunctionWrapper<efl_gfx_text_class_set_api_delegate> efl_gfx_text_class_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_text_class_set_api_delegate>(Module, "efl_gfx_text_class_set");

        private static bool text_class_set(System.IntPtr obj, System.IntPtr pd, System.String text_class, System.String font, Efl.Font.Size size)
        {
            Eina.Log.Debug("function efl_gfx_text_class_set was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                                                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((ITextClass)wrapper).SetTextClass(text_class, font, size);
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
                return efl_gfx_text_class_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), text_class, font, size);
            }
        }

        private static efl_gfx_text_class_set_delegate efl_gfx_text_class_set_static_delegate;

        
        private delegate void efl_gfx_text_class_del_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String text_class);

        
        public delegate void efl_gfx_text_class_del_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String text_class);

        public static Efl.Eo.FunctionWrapper<efl_gfx_text_class_del_api_delegate> efl_gfx_text_class_del_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_text_class_del_api_delegate>(Module, "efl_gfx_text_class_del");

        private static void text_class_del(System.IntPtr obj, System.IntPtr pd, System.String text_class)
        {
            Eina.Log.Debug("function efl_gfx_text_class_del was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    
                try
                {
                    ((ITextClass)wrapper).DelTextClass(text_class);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gfx_text_class_del_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), text_class);
            }
        }

        private static efl_gfx_text_class_del_delegate efl_gfx_text_class_del_static_delegate;

        #pragma warning restore CA1707, SA1300, SA1600

}
}
}

}

