#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { 
/// <summary>Utility class for markup, such as conversions</summary>
[TextMarkupUtilNativeInherit]
public class TextMarkupUtil :  Efl.Eo.IWrapper, IDisposable
{
    ///<summary>Pointer to the native class description.</summary>
    public virtual System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (TextMarkupUtil))
                return Efl.TextMarkupUtilNativeInherit.GetEflClassStatic();
            else
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
        }
    }
    protected bool inherited;
    protected  System.IntPtr handle;
    ///<summary>Pointer to the native instance.</summary>
    public System.IntPtr NativeHandle {
        get { return handle; }
    }
    [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] internal static extern System.IntPtr
        efl_text_markup_util_class_get();
    ///<summary>Creates a new instance.</summary>
    ///<param name="parent">Parent instance.</param>
    public TextMarkupUtil(Efl.Object parent= null
            ) :
        this(efl_text_markup_util_class_get(), typeof(TextMarkupUtil), parent)
    {
        FinishInstantiation();
    }
    ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    protected TextMarkupUtil(System.IntPtr raw)
    {
        handle = raw;
        RegisterEventProxies();
    }
    protected TextMarkupUtil(IntPtr base_klass, System.Type managed_type, Efl.Object parent)
    {
        inherited = ((object)this).GetType() != managed_type;
        IntPtr actual_klass = base_klass;
        if (inherited) {
            actual_klass = Efl.Eo.ClassRegister.GetInheritKlassOrRegister(base_klass, ((object)this).GetType());
        }
        handle = Efl.Eo.Globals.instantiate_start(actual_klass, parent);
        RegisterEventProxies();
        if (inherited)
        {
            Efl.Eo.Globals.PrivateDataSet(this);
        }
    }
    protected void FinishInstantiation()
    {
        handle = Efl.Eo.Globals.instantiate_end(handle);
        Eina.Error.RaiseIfUnhandledException();
    }
    ///<summary>Destructor.</summary>
    ~TextMarkupUtil()
    {
        Dispose(false);
    }
    ///<summary>Releases the underlying native instance.</summary>
    protected virtual void Dispose(bool disposing)
    {
        if (handle != System.IntPtr.Zero) {
            Efl.Eo.Globals.efl_unref(handle);
            handle = System.IntPtr.Zero;
        }
    }
    ///<summary>Releases the underlying native instance.</summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    ///<summary>Verifies if the given object is equal to this one.</summary>
    public override bool Equals(object obj)
    {
        var other = obj as Efl.Object;
        if (other == null)
            return false;
        return this.NativeHandle == other.NativeHandle;
    }
    ///<summary>Gets the hash code for this object based on the native pointer it points to.</summary>
    public override int GetHashCode()
    {
        return this.NativeHandle.ToInt32();
    }
    ///<summary>Turns the native pointer into a string representation.</summary>
    public override String ToString()
    {
        return $"{this.GetType().Name}@[{this.NativeHandle.ToInt32():x}]";
    }
    ///<summary>Register the Eo event wrappers making the bridge to C# events. Internal usage only.</summary>
    protected virtual void RegisterEventProxies()
    {
    }
    /// <summary>Converts a given (UTF-8) text to a markup-compatible string. This is used mainly to set a plain text with the $.markup_set property.</summary>
    /// <param name="text">The text (UTF-8) to convert to markup</param>
    /// <returns>The markup representation of given text</returns>
    public static System.String TextToMarkup( System.String text) {
                                 var _ret_var = Efl.TextMarkupUtilNativeInherit.efl_text_markup_util_text_to_markup_ptr.Value.Delegate( text);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Converts a given (UTF-8) text to a markup-compatible string. This is used mainly to set a plain text with the $.markup_set property.</summary>
    /// <param name="text">The markup-text to convert to text (UTF-8)</param>
    /// <returns>The text representation of given format</returns>
    public static System.String MarkupToText( System.String text) {
                                 var _ret_var = Efl.TextMarkupUtilNativeInherit.efl_text_markup_util_markup_to_text_ptr.Value.Delegate( text);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.TextMarkupUtil.efl_text_markup_util_class_get();
    }
}
public class TextMarkupUtilNativeInherit  : Efl.Eo.NativeClass{
    public  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Efl);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
        return descs;
    }
    public override IntPtr GetEflClass()
    {
        return Efl.TextMarkupUtil.efl_text_markup_util_class_get();
    }
    public static  IntPtr GetEflClassStatic()
    {
        return Efl.TextMarkupUtil.efl_text_markup_util_class_get();
    }


     [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringPassOwnershipMarshaler))] private delegate System.String efl_text_markup_util_text_to_markup_delegate( [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String text);


     [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringPassOwnershipMarshaler))] public delegate System.String efl_text_markup_util_text_to_markup_api_delegate( [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String text);
     public static Efl.Eo.FunctionWrapper<efl_text_markup_util_text_to_markup_api_delegate> efl_text_markup_util_text_to_markup_ptr = new Efl.Eo.FunctionWrapper<efl_text_markup_util_text_to_markup_api_delegate>(_Module, "efl_text_markup_util_text_to_markup");
     private static System.String text_to_markup(System.IntPtr obj, System.IntPtr pd,  System.String text)
    {
        Eina.Log.Debug("function efl_text_markup_util_text_to_markup was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                System.String _ret_var = default(System.String);
            try {
                _ret_var = TextMarkupUtil.TextToMarkup( text);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                        return _ret_var;
        } else {
            return efl_text_markup_util_text_to_markup_ptr.Value.Delegate( text);
        }
    }


     [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringPassOwnershipMarshaler))] private delegate System.String efl_text_markup_util_markup_to_text_delegate( [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String text);


     [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringPassOwnershipMarshaler))] public delegate System.String efl_text_markup_util_markup_to_text_api_delegate( [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String text);
     public static Efl.Eo.FunctionWrapper<efl_text_markup_util_markup_to_text_api_delegate> efl_text_markup_util_markup_to_text_ptr = new Efl.Eo.FunctionWrapper<efl_text_markup_util_markup_to_text_api_delegate>(_Module, "efl_text_markup_util_markup_to_text");
     private static System.String markup_to_text(System.IntPtr obj, System.IntPtr pd,  System.String text)
    {
        Eina.Log.Debug("function efl_text_markup_util_markup_to_text was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                System.String _ret_var = default(System.String);
            try {
                _ret_var = TextMarkupUtil.MarkupToText( text);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                        return _ret_var;
        } else {
            return efl_text_markup_util_markup_to_text_ptr.Value.Delegate( text);
        }
    }
}
} 
