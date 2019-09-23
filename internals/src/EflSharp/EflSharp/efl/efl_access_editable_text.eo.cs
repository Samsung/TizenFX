#define EFL_BETA
#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Access {

namespace Editable {

/// <summary>Elementary editable text interface</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Access.Editable.TextConcrete.NativeMethods]
[Efl.Eo.BindingEntity]
public interface IText : 
    Efl.Eo.IWrapper, IDisposable
{
                                                }
/// <summary>Elementary editable text interface</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
public sealed class TextConcrete :
    Efl.Eo.EoWrapper
    , IText
    
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(TextConcrete))
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
    private TextConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_access_editable_text_interface_get();
    /// <summary>Initializes a new instance of the <see cref="IText"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private TextConcrete(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

#pragma warning disable CS0628
    /// <summary>Editable content property</summary>
    /// <param name="kw_string">Content</param>
    /// <returns><c>true</c> if setting the value succeeded, <c>false</c> otherwise</returns>
    protected bool SetTextContent(System.String kw_string) {
                                 var _ret_var = Efl.Access.Editable.TextConcrete.NativeMethods.efl_access_editable_text_content_set_ptr.Value.Delegate(this.NativeHandle,kw_string);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Insert text at given position</summary>
    /// <param name="kw_string">String to be inserted</param>
    /// <param name="position">Position to insert string</param>
    /// <returns><c>true</c> if insert succeeded, <c>false</c> otherwise</returns>
    protected bool Insert(System.String kw_string, int position) {
                                                         var _ret_var = Efl.Access.Editable.TextConcrete.NativeMethods.efl_access_editable_text_insert_ptr.Value.Delegate(this.NativeHandle,kw_string, position);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Copy text between start and end parameter</summary>
    /// <param name="start">Start position to copy</param>
    /// <param name="end">End position to copy</param>
    /// <returns><c>true</c> if copy succeeded, <c>false</c> otherwise</returns>
    protected bool Copy(int start, int end) {
                                                         var _ret_var = Efl.Access.Editable.TextConcrete.NativeMethods.efl_access_editable_text_copy_ptr.Value.Delegate(this.NativeHandle,start, end);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Cut text between start and end parameter</summary>
    /// <param name="start">Start position to cut</param>
    /// <param name="end">End position to cut</param>
    /// <returns><c>true</c> if cut succeeded, <c>false</c> otherwise</returns>
    protected bool Cut(int start, int end) {
                                                         var _ret_var = Efl.Access.Editable.TextConcrete.NativeMethods.efl_access_editable_text_cut_ptr.Value.Delegate(this.NativeHandle,start, end);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Delete text between start and end parameter</summary>
    /// <param name="start">Start position to delete</param>
    /// <param name="end">End position to delete</param>
    /// <returns><c>true</c> if delete succeeded, <c>false</c> otherwise</returns>
    protected bool Delete(int start, int end) {
                                                         var _ret_var = Efl.Access.Editable.TextConcrete.NativeMethods.efl_access_editable_text_delete_ptr.Value.Delegate(this.NativeHandle,start, end);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Paste text at given position</summary>
    /// <param name="position">Position to insert text</param>
    /// <returns><c>true</c> if paste succeeded, <c>false</c> otherwise</returns>
    protected bool Paste(int position) {
                                 var _ret_var = Efl.Access.Editable.TextConcrete.NativeMethods.efl_access_editable_text_paste_ptr.Value.Delegate(this.NativeHandle,position);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Editable content property</summary>
    /// <value>Content</value>
    protected System.String TextContent {
        set { SetTextContent(value); }
    }
#pragma warning restore CS0628
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Access.Editable.TextConcrete.efl_access_editable_text_interface_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Eo.EoWrapper.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Elementary);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
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
            return Efl.Access.Editable.TextConcrete.efl_access_editable_text_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_access_editable_text_content_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String kw_string);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_access_editable_text_content_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String kw_string);

        public static Efl.Eo.FunctionWrapper<efl_access_editable_text_content_set_api_delegate> efl_access_editable_text_content_set_ptr = new Efl.Eo.FunctionWrapper<efl_access_editable_text_content_set_api_delegate>(Module, "efl_access_editable_text_content_set");

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_access_editable_text_insert_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String kw_string,  int position);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_access_editable_text_insert_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String kw_string,  int position);

        public static Efl.Eo.FunctionWrapper<efl_access_editable_text_insert_api_delegate> efl_access_editable_text_insert_ptr = new Efl.Eo.FunctionWrapper<efl_access_editable_text_insert_api_delegate>(Module, "efl_access_editable_text_insert");

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_access_editable_text_copy_delegate(System.IntPtr obj, System.IntPtr pd,  int start,  int end);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_access_editable_text_copy_api_delegate(System.IntPtr obj,  int start,  int end);

        public static Efl.Eo.FunctionWrapper<efl_access_editable_text_copy_api_delegate> efl_access_editable_text_copy_ptr = new Efl.Eo.FunctionWrapper<efl_access_editable_text_copy_api_delegate>(Module, "efl_access_editable_text_copy");

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_access_editable_text_cut_delegate(System.IntPtr obj, System.IntPtr pd,  int start,  int end);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_access_editable_text_cut_api_delegate(System.IntPtr obj,  int start,  int end);

        public static Efl.Eo.FunctionWrapper<efl_access_editable_text_cut_api_delegate> efl_access_editable_text_cut_ptr = new Efl.Eo.FunctionWrapper<efl_access_editable_text_cut_api_delegate>(Module, "efl_access_editable_text_cut");

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_access_editable_text_delete_delegate(System.IntPtr obj, System.IntPtr pd,  int start,  int end);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_access_editable_text_delete_api_delegate(System.IntPtr obj,  int start,  int end);

        public static Efl.Eo.FunctionWrapper<efl_access_editable_text_delete_api_delegate> efl_access_editable_text_delete_ptr = new Efl.Eo.FunctionWrapper<efl_access_editable_text_delete_api_delegate>(Module, "efl_access_editable_text_delete");

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_access_editable_text_paste_delegate(System.IntPtr obj, System.IntPtr pd,  int position);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_access_editable_text_paste_api_delegate(System.IntPtr obj,  int position);

        public static Efl.Eo.FunctionWrapper<efl_access_editable_text_paste_api_delegate> efl_access_editable_text_paste_ptr = new Efl.Eo.FunctionWrapper<efl_access_editable_text_paste_api_delegate>(Module, "efl_access_editable_text_paste");

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_Access_EditableTextConcrete_ExtensionMethods {
    public static Efl.BindableProperty<System.String> TextContent<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Access.Editable.IText, T>magic = null) where T : Efl.Access.Editable.IText {
        return new Efl.BindableProperty<System.String>("text_content", fac);
    }

}
#pragma warning restore CS1591
#endif
