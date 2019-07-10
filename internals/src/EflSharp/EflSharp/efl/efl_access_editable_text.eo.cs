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
[Efl.Access.Editable.ITextConcrete.NativeMethods]
public interface IText : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Editable content property</summary>
/// <param name="kw_string">Content</param>
/// <returns><c>true</c> if setting the value succeeded, <c>false</c> otherwise</returns>
bool SetTextContent(System.String kw_string);
    /// <summary>Insert text at given position</summary>
/// <param name="kw_string">String to be inserted</param>
/// <param name="position">Position to insert string</param>
/// <returns><c>true</c> if insert succeeded, <c>false</c> otherwise</returns>
bool Insert(System.String kw_string, int position);
    /// <summary>Copy text between start and end parameter</summary>
/// <param name="start">Start position to copy</param>
/// <param name="end">End position to copy</param>
/// <returns><c>true</c> if copy succeeded, <c>false</c> otherwise</returns>
bool Copy(int start, int end);
    /// <summary>Cut text between start and end parameter</summary>
/// <param name="start">Start position to cut</param>
/// <param name="end">End position to cut</param>
/// <returns><c>true</c> if cut succeeded, <c>false</c> otherwise</returns>
bool Cut(int start, int end);
    /// <summary>Delete text between start and end parameter</summary>
/// <param name="start">Start position to delete</param>
/// <param name="end">End position to delete</param>
/// <returns><c>true</c> if delete succeeded, <c>false</c> otherwise</returns>
bool Delete(int start, int end);
    /// <summary>Paste text at given position</summary>
/// <param name="position">Position to insert text</param>
/// <returns><c>true</c> if paste succeeded, <c>false</c> otherwise</returns>
bool Paste(int position);
                            /// <summary>Editable content property</summary>
    /// <value>Content</value>
    System.String TextContent {
        set ;
    }
}
/// <summary>Elementary editable text interface</summary>
sealed public class ITextConcrete :
    Efl.Eo.EoWrapper
    , IText
    
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(ITextConcrete))
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
        efl_access_editable_text_interface_get();
    /// <summary>Initializes a new instance of the <see cref="IText"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    private ITextConcrete(System.IntPtr raw) : base(raw)
    {
    }

    /// <summary>Editable content property</summary>
    /// <param name="kw_string">Content</param>
    /// <returns><c>true</c> if setting the value succeeded, <c>false</c> otherwise</returns>
    public bool SetTextContent(System.String kw_string) {
                                 var _ret_var = Efl.Access.Editable.ITextConcrete.NativeMethods.efl_access_editable_text_content_set_ptr.Value.Delegate(this.NativeHandle,kw_string);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Insert text at given position</summary>
    /// <param name="kw_string">String to be inserted</param>
    /// <param name="position">Position to insert string</param>
    /// <returns><c>true</c> if insert succeeded, <c>false</c> otherwise</returns>
    public bool Insert(System.String kw_string, int position) {
                                                         var _ret_var = Efl.Access.Editable.ITextConcrete.NativeMethods.efl_access_editable_text_insert_ptr.Value.Delegate(this.NativeHandle,kw_string, position);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Copy text between start and end parameter</summary>
    /// <param name="start">Start position to copy</param>
    /// <param name="end">End position to copy</param>
    /// <returns><c>true</c> if copy succeeded, <c>false</c> otherwise</returns>
    public bool Copy(int start, int end) {
                                                         var _ret_var = Efl.Access.Editable.ITextConcrete.NativeMethods.efl_access_editable_text_copy_ptr.Value.Delegate(this.NativeHandle,start, end);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Cut text between start and end parameter</summary>
    /// <param name="start">Start position to cut</param>
    /// <param name="end">End position to cut</param>
    /// <returns><c>true</c> if cut succeeded, <c>false</c> otherwise</returns>
    public bool Cut(int start, int end) {
                                                         var _ret_var = Efl.Access.Editable.ITextConcrete.NativeMethods.efl_access_editable_text_cut_ptr.Value.Delegate(this.NativeHandle,start, end);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Delete text between start and end parameter</summary>
    /// <param name="start">Start position to delete</param>
    /// <param name="end">End position to delete</param>
    /// <returns><c>true</c> if delete succeeded, <c>false</c> otherwise</returns>
    public bool Delete(int start, int end) {
                                                         var _ret_var = Efl.Access.Editable.ITextConcrete.NativeMethods.efl_access_editable_text_delete_ptr.Value.Delegate(this.NativeHandle,start, end);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Paste text at given position</summary>
    /// <param name="position">Position to insert text</param>
    /// <returns><c>true</c> if paste succeeded, <c>false</c> otherwise</returns>
    public bool Paste(int position) {
                                 var _ret_var = Efl.Access.Editable.ITextConcrete.NativeMethods.efl_access_editable_text_paste_ptr.Value.Delegate(this.NativeHandle,position);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Editable content property</summary>
    /// <value>Content</value>
    public System.String TextContent {
        set { SetTextContent(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Access.Editable.ITextConcrete.efl_access_editable_text_interface_get();
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

            if (efl_access_editable_text_content_set_static_delegate == null)
            {
                efl_access_editable_text_content_set_static_delegate = new efl_access_editable_text_content_set_delegate(text_content_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetTextContent") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_editable_text_content_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_editable_text_content_set_static_delegate) });
            }

            if (efl_access_editable_text_insert_static_delegate == null)
            {
                efl_access_editable_text_insert_static_delegate = new efl_access_editable_text_insert_delegate(insert);
            }

            if (methods.FirstOrDefault(m => m.Name == "Insert") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_editable_text_insert"), func = Marshal.GetFunctionPointerForDelegate(efl_access_editable_text_insert_static_delegate) });
            }

            if (efl_access_editable_text_copy_static_delegate == null)
            {
                efl_access_editable_text_copy_static_delegate = new efl_access_editable_text_copy_delegate(copy);
            }

            if (methods.FirstOrDefault(m => m.Name == "Copy") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_editable_text_copy"), func = Marshal.GetFunctionPointerForDelegate(efl_access_editable_text_copy_static_delegate) });
            }

            if (efl_access_editable_text_cut_static_delegate == null)
            {
                efl_access_editable_text_cut_static_delegate = new efl_access_editable_text_cut_delegate(cut);
            }

            if (methods.FirstOrDefault(m => m.Name == "Cut") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_editable_text_cut"), func = Marshal.GetFunctionPointerForDelegate(efl_access_editable_text_cut_static_delegate) });
            }

            if (efl_access_editable_text_delete_static_delegate == null)
            {
                efl_access_editable_text_delete_static_delegate = new efl_access_editable_text_delete_delegate(kw_delete);
            }

            if (methods.FirstOrDefault(m => m.Name == "Delete") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_editable_text_delete"), func = Marshal.GetFunctionPointerForDelegate(efl_access_editable_text_delete_static_delegate) });
            }

            if (efl_access_editable_text_paste_static_delegate == null)
            {
                efl_access_editable_text_paste_static_delegate = new efl_access_editable_text_paste_delegate(paste);
            }

            if (methods.FirstOrDefault(m => m.Name == "Paste") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_editable_text_paste"), func = Marshal.GetFunctionPointerForDelegate(efl_access_editable_text_paste_static_delegate) });
            }

            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Access.Editable.ITextConcrete.efl_access_editable_text_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_access_editable_text_content_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String kw_string);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_access_editable_text_content_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String kw_string);

        public static Efl.Eo.FunctionWrapper<efl_access_editable_text_content_set_api_delegate> efl_access_editable_text_content_set_ptr = new Efl.Eo.FunctionWrapper<efl_access_editable_text_content_set_api_delegate>(Module, "efl_access_editable_text_content_set");

        private static bool text_content_set(System.IntPtr obj, System.IntPtr pd, System.String kw_string)
        {
            Eina.Log.Debug("function efl_access_editable_text_content_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IText)ws.Target).SetTextContent(kw_string);
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
                return efl_access_editable_text_content_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), kw_string);
            }
        }

        private static efl_access_editable_text_content_set_delegate efl_access_editable_text_content_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_access_editable_text_insert_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String kw_string,  int position);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_access_editable_text_insert_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String kw_string,  int position);

        public static Efl.Eo.FunctionWrapper<efl_access_editable_text_insert_api_delegate> efl_access_editable_text_insert_ptr = new Efl.Eo.FunctionWrapper<efl_access_editable_text_insert_api_delegate>(Module, "efl_access_editable_text_insert");

        private static bool insert(System.IntPtr obj, System.IntPtr pd, System.String kw_string, int position)
        {
            Eina.Log.Debug("function efl_access_editable_text_insert was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IText)ws.Target).Insert(kw_string, position);
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
                return efl_access_editable_text_insert_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), kw_string, position);
            }
        }

        private static efl_access_editable_text_insert_delegate efl_access_editable_text_insert_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_access_editable_text_copy_delegate(System.IntPtr obj, System.IntPtr pd,  int start,  int end);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_access_editable_text_copy_api_delegate(System.IntPtr obj,  int start,  int end);

        public static Efl.Eo.FunctionWrapper<efl_access_editable_text_copy_api_delegate> efl_access_editable_text_copy_ptr = new Efl.Eo.FunctionWrapper<efl_access_editable_text_copy_api_delegate>(Module, "efl_access_editable_text_copy");

        private static bool copy(System.IntPtr obj, System.IntPtr pd, int start, int end)
        {
            Eina.Log.Debug("function efl_access_editable_text_copy was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IText)ws.Target).Copy(start, end);
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
                return efl_access_editable_text_copy_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), start, end);
            }
        }

        private static efl_access_editable_text_copy_delegate efl_access_editable_text_copy_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_access_editable_text_cut_delegate(System.IntPtr obj, System.IntPtr pd,  int start,  int end);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_access_editable_text_cut_api_delegate(System.IntPtr obj,  int start,  int end);

        public static Efl.Eo.FunctionWrapper<efl_access_editable_text_cut_api_delegate> efl_access_editable_text_cut_ptr = new Efl.Eo.FunctionWrapper<efl_access_editable_text_cut_api_delegate>(Module, "efl_access_editable_text_cut");

        private static bool cut(System.IntPtr obj, System.IntPtr pd, int start, int end)
        {
            Eina.Log.Debug("function efl_access_editable_text_cut was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IText)ws.Target).Cut(start, end);
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
                return efl_access_editable_text_cut_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), start, end);
            }
        }

        private static efl_access_editable_text_cut_delegate efl_access_editable_text_cut_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_access_editable_text_delete_delegate(System.IntPtr obj, System.IntPtr pd,  int start,  int end);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_access_editable_text_delete_api_delegate(System.IntPtr obj,  int start,  int end);

        public static Efl.Eo.FunctionWrapper<efl_access_editable_text_delete_api_delegate> efl_access_editable_text_delete_ptr = new Efl.Eo.FunctionWrapper<efl_access_editable_text_delete_api_delegate>(Module, "efl_access_editable_text_delete");

        private static bool kw_delete(System.IntPtr obj, System.IntPtr pd, int start, int end)
        {
            Eina.Log.Debug("function efl_access_editable_text_delete was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IText)ws.Target).Delete(start, end);
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
                return efl_access_editable_text_delete_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), start, end);
            }
        }

        private static efl_access_editable_text_delete_delegate efl_access_editable_text_delete_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_access_editable_text_paste_delegate(System.IntPtr obj, System.IntPtr pd,  int position);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_access_editable_text_paste_api_delegate(System.IntPtr obj,  int position);

        public static Efl.Eo.FunctionWrapper<efl_access_editable_text_paste_api_delegate> efl_access_editable_text_paste_ptr = new Efl.Eo.FunctionWrapper<efl_access_editable_text_paste_api_delegate>(Module, "efl_access_editable_text_paste");

        private static bool paste(System.IntPtr obj, System.IntPtr pd, int position)
        {
            Eina.Log.Debug("function efl_access_editable_text_paste was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IText)ws.Target).Paste(position);
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
                return efl_access_editable_text_paste_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), position);
            }
        }

        private static efl_access_editable_text_paste_delegate efl_access_editable_text_paste_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

}

