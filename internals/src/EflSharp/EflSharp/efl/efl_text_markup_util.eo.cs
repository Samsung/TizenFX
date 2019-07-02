#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

/// <summary>Utility class for markup, such as conversions</summary>
[Efl.TextMarkupUtil.NativeMethods]
public class TextMarkupUtil : Efl.Eo.EoWrapper
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(TextMarkupUtil))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
        efl_text_markup_util_class_get();
    /// <summary>Initializes a new instance of the <see cref="TextMarkupUtil"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public TextMarkupUtil(Efl.Object parent= null
            ) : base(efl_text_markup_util_class_get(), typeof(TextMarkupUtil), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Initializes a new instance of the <see cref="TextMarkupUtil"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="raw">The native pointer to be wrapped.</param>
    protected TextMarkupUtil(System.IntPtr raw) : base(raw)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="TextMarkupUtil"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="managedType">The managed type of the public constructor that originated this call.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected TextMarkupUtil(IntPtr baseKlass, System.Type managedType, Efl.Object parent) : base(baseKlass, managedType, parent)
    {
    }

    /// <summary>Converts a given (UTF-8) text to a markup-compatible string. This is used mainly to set a plain text with the $.markup_set property.</summary>
    /// <param name="text">The text (UTF-8) to convert to markup</param>
    /// <returns>The markup representation of given text</returns>
    public static System.String TextToMarkup(System.String text) {
                                 var _ret_var = Efl.TextMarkupUtil.NativeMethods.efl_text_markup_util_text_to_markup_ptr.Value.Delegate(text);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Converts a given (UTF-8) text to a markup-compatible string. This is used mainly to set a plain text with the $.markup_set property.</summary>
    /// <param name="text">The markup-text to convert to text (UTF-8)</param>
    /// <returns>The text representation of given format</returns>
    public static System.String MarkupToText(System.String text) {
                                 var _ret_var = Efl.TextMarkupUtil.NativeMethods.efl_text_markup_util_markup_to_text_ptr.Value.Delegate(text);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.TextMarkupUtil.efl_text_markup_util_class_get();
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
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.TextMarkupUtil.efl_text_markup_util_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringPassOwnershipMarshaler))]
        private delegate System.String efl_text_markup_util_text_to_markup_delegate([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String text);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringPassOwnershipMarshaler))]
        public delegate System.String efl_text_markup_util_text_to_markup_api_delegate([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String text);

        public static Efl.Eo.FunctionWrapper<efl_text_markup_util_text_to_markup_api_delegate> efl_text_markup_util_text_to_markup_ptr = new Efl.Eo.FunctionWrapper<efl_text_markup_util_text_to_markup_api_delegate>(Module, "efl_text_markup_util_text_to_markup");

        private static System.String text_to_markup(System.IntPtr obj, System.IntPtr pd, System.String text)
        {
            Eina.Log.Debug("function efl_text_markup_util_text_to_markup was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = TextMarkupUtil.TextToMarkup(text);
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
                return efl_text_markup_util_text_to_markup_ptr.Value.Delegate(text);
            }
        }

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringPassOwnershipMarshaler))]
        private delegate System.String efl_text_markup_util_markup_to_text_delegate([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String text);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringPassOwnershipMarshaler))]
        public delegate System.String efl_text_markup_util_markup_to_text_api_delegate([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String text);

        public static Efl.Eo.FunctionWrapper<efl_text_markup_util_markup_to_text_api_delegate> efl_text_markup_util_markup_to_text_ptr = new Efl.Eo.FunctionWrapper<efl_text_markup_util_markup_to_text_api_delegate>(Module, "efl_text_markup_util_markup_to_text");

        private static System.String markup_to_text(System.IntPtr obj, System.IntPtr pd, System.String text)
        {
            Eina.Log.Debug("function efl_text_markup_util_markup_to_text was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = TextMarkupUtil.MarkupToText(text);
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
                return efl_text_markup_util_markup_to_text_ptr.Value.Delegate(text);
            }
        }

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

