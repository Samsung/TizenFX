#define EFL_BETA
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
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Gfx.TextClassConcrete.NativeMethods]
[Efl.Eo.BindingEntity]
public interface ITextClass : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Font and font size from edje text class.
/// When reading the font string will only be valid until the text class is changed or the edje object is deleted.</summary>
/// <param name="text_class">The text class name</param>
/// <param name="font">Font name</param>
/// <param name="size">Font Size</param>
/// <returns><c>true</c>, on success or <c>false</c>, on error</returns>
bool GetTextClass(System.String text_class, out System.String font, out Efl.Font.Size size);
    /// <summary>Font and font size from edje text class.
/// When reading the font string will only be valid until the text class is changed or the edje object is deleted.</summary>
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
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
public sealed class TextClassConcrete :
    Efl.Eo.EoWrapper
    , ITextClass
    
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(TextClassConcrete))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    private TextClassConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
        efl_gfx_text_class_interface_get();
    /// <summary>Initializes a new instance of the <see cref="ITextClass"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private TextClassConcrete(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

#pragma warning disable CS0628
    /// <summary>Font and font size from edje text class.
    /// When reading the font string will only be valid until the text class is changed or the edje object is deleted.</summary>
    /// <param name="text_class">The text class name</param>
    /// <param name="font">Font name</param>
    /// <param name="size">Font Size</param>
    /// <returns><c>true</c>, on success or <c>false</c>, on error</returns>
    public bool GetTextClass(System.String text_class, out System.String font, out Efl.Font.Size size) {
                                                                                 var _ret_var = Efl.Gfx.TextClassConcrete.NativeMethods.efl_gfx_text_class_get_ptr.Value.Delegate(this.NativeHandle,text_class, out font, out size);
        Eina.Error.RaiseIfUnhandledException();
                                                        return _ret_var;
 }
    /// <summary>Font and font size from edje text class.
    /// When reading the font string will only be valid until the text class is changed or the edje object is deleted.</summary>
    /// <param name="text_class">The text class name</param>
    /// <param name="font">Font name</param>
    /// <param name="size">Font Size</param>
    /// <returns><c>true</c>, on success or <c>false</c>, on error</returns>
    public bool SetTextClass(System.String text_class, System.String font, Efl.Font.Size size) {
                                                                                 var _ret_var = Efl.Gfx.TextClassConcrete.NativeMethods.efl_gfx_text_class_set_ptr.Value.Delegate(this.NativeHandle,text_class, font, size);
        Eina.Error.RaiseIfUnhandledException();
                                                        return _ret_var;
 }
    /// <summary>Delete the text class.
    /// This function deletes any values for the specified text class.
    /// 
    /// Deleting the text class will revert it to the values defined by <see cref="Efl.Gfx.ITextClass.GetTextClass"/> or the text class defined in the theme file.</summary>
    /// <param name="text_class">The text class to be deleted.</param>
    public void DelTextClass(System.String text_class) {
                                 Efl.Gfx.TextClassConcrete.NativeMethods.efl_gfx_text_class_del_ptr.Value.Delegate(this.NativeHandle,text_class);
        Eina.Error.RaiseIfUnhandledException();
                         }
#pragma warning restore CS0628
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Gfx.TextClassConcrete.efl_gfx_text_class_interface_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Eo.EoWrapper.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Efl);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
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
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Gfx.TextClassConcrete.efl_gfx_text_class_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_gfx_text_class_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String text_class, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] out System.String font,  out Efl.Font.Size size);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_gfx_text_class_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String text_class, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] out System.String font,  out Efl.Font.Size size);

        public static Efl.Eo.FunctionWrapper<efl_gfx_text_class_get_api_delegate> efl_gfx_text_class_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_text_class_get_api_delegate>(Module, "efl_gfx_text_class_get");

        private static bool text_class_get(System.IntPtr obj, System.IntPtr pd, System.String text_class, out System.String font, out Efl.Font.Size size)
        {
            Eina.Log.Debug("function efl_gfx_text_class_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                        System.String _out_font = default(System.String);
        size = default(Efl.Font.Size);                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((ITextClass)ws.Target).GetTextClass(text_class, out _out_font, out size);
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
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((ITextClass)ws.Target).SetTextClass(text_class, font, size);
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
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((ITextClass)ws.Target).DelTextClass(text_class);
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

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_GfxTextClassConcrete_ExtensionMethods {
    
}
#pragma warning restore CS1591
#endif
