#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary></summary>
/// <param name="str">the formated string to be appended by user.</param>
/// <param name="value">The <see cref="Eina.Value"/> passed by <c>obj</c>.</param>
/// <returns></returns>
public delegate void FormatFuncCb( Eina.Strbuf str,  Eina.Value value);
public delegate void FormatFuncCbInternal(IntPtr data,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StrbufKeepOwnershipMarshaler))]  Eina.Strbuf str,   Eina.ValueNative value);
internal class FormatFuncCbWrapper
{

    private FormatFuncCbInternal _cb;
    private IntPtr _cb_data;
    private EinaFreeCb _cb_free_cb;

    internal FormatFuncCbWrapper (FormatFuncCbInternal _cb, IntPtr _cb_data, EinaFreeCb _cb_free_cb)
    {
        this._cb = _cb;
        this._cb_data = _cb_data;
        this._cb_free_cb = _cb_free_cb;
    }

    ~FormatFuncCbWrapper()
    {
        if (this._cb_free_cb != null)
            this._cb_free_cb(this._cb_data);
    }

    internal void ManagedCb( Eina.Strbuf str, Eina.Value value)
    {
                                                        _cb(_cb_data,  str,  value);
        Eina.Error.RaiseIfUnhandledException();
                                            }

        internal static void Cb(IntPtr cb_data,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StrbufKeepOwnershipMarshaler))]  Eina.Strbuf str,   Eina.ValueNative value)
    {
        GCHandle handle = GCHandle.FromIntPtr(cb_data);
        FormatFuncCb cb = (FormatFuncCb)handle.Target;
                                                            
        try {
            cb( str,  value);
        } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
                                            }
}
} } 
namespace Efl { namespace Ui { 
/// <summary>interface class for format_func</summary>
[IFormatNativeInherit]
public interface IFormat : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Set the format function pointer to format the string.</summary>
/// <param name="func">The format function callback</param>
/// <returns></returns>
void SetFormatCb( Efl.Ui.FormatFuncCb func);
    /// <summary>Control the format string for a given units label
/// If <c>NULL</c> is passed to <c>format</c>, it will hide <c>obj</c>&apos;s units area completely. If not, it&apos;ll set the &lt;b&gt;format string&lt;/b&gt; for the units label text. The units label is provided as a floating point value, so the units text can display at most one floating point value. Note that the units label is optional. Use a format string such as &quot;%1.2f meters&quot; for example.
/// 
/// Note: The default format string is an integer percentage, as in $&quot;%.0f %%&quot;.</summary>
/// <returns>The format string for <c>obj</c>&apos;s units label.</returns>
System.String GetFormatString();
    /// <summary>Control the format string for a given units label
/// If <c>NULL</c> is passed to <c>format</c>, it will hide <c>obj</c>&apos;s units area completely. If not, it&apos;ll set the &lt;b&gt;format string&lt;/b&gt; for the units label text. The units label is provided as a floating point value, so the units text can display at most one floating point value. Note that the units label is optional. Use a format string such as &quot;%1.2f meters&quot; for example.
/// 
/// Note: The default format string is an integer percentage, as in $&quot;%.0f %%&quot;.</summary>
/// <param name="units">The format string for <c>obj</c>&apos;s units label.</param>
/// <returns></returns>
void SetFormatString( System.String units);
                /// <summary>Set the format function pointer to format the string.</summary>
/// <value>The format function callback</value>
    Efl.Ui.FormatFuncCb FormatCb {
        set ;
    }
    /// <summary>Control the format string for a given units label
/// If <c>NULL</c> is passed to <c>format</c>, it will hide <c>obj</c>&apos;s units area completely. If not, it&apos;ll set the &lt;b&gt;format string&lt;/b&gt; for the units label text. The units label is provided as a floating point value, so the units text can display at most one floating point value. Note that the units label is optional. Use a format string such as &quot;%1.2f meters&quot; for example.
/// 
/// Note: The default format string is an integer percentage, as in $&quot;%.0f %%&quot;.</summary>
/// <value>The format string for <c>obj</c>&apos;s units label.</value>
    System.String FormatString {
        get ;
        set ;
    }
}
/// <summary>interface class for format_func</summary>
sealed public class IFormatConcrete : 

IFormat
    
{
    ///<summary>Pointer to the native class description.</summary>
    public System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (IFormatConcrete))
                return Efl.Ui.IFormatNativeInherit.GetEflClassStatic();
            else
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
        }
    }
    private  System.IntPtr handle;
    ///<summary>Pointer to the native instance.</summary>
    public System.IntPtr NativeHandle {
        get { return handle; }
    }
    [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] internal static extern System.IntPtr
        efl_ui_format_mixin_get();
    ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    private IFormatConcrete(System.IntPtr raw)
    {
        handle = raw;
        RegisterEventProxies();
    }
    ///<summary>Destructor.</summary>
    ~IFormatConcrete()
    {
        Dispose(false);
    }
    ///<summary>Releases the underlying native instance.</summary>
    void Dispose(bool disposing)
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
     void RegisterEventProxies()
    {
    }
    /// <summary>Set the format function pointer to format the string.</summary>
    /// <param name="func">The format function callback</param>
    /// <returns></returns>
    public void SetFormatCb( Efl.Ui.FormatFuncCb func) {
                         GCHandle func_handle = GCHandle.Alloc(func);
        Efl.Ui.IFormatNativeInherit.efl_ui_format_cb_set_ptr.Value.Delegate(this.NativeHandle,GCHandle.ToIntPtr(func_handle), Efl.Ui.FormatFuncCbWrapper.Cb, Efl.Eo.Globals.free_gchandle);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Control the format string for a given units label
    /// If <c>NULL</c> is passed to <c>format</c>, it will hide <c>obj</c>&apos;s units area completely. If not, it&apos;ll set the &lt;b&gt;format string&lt;/b&gt; for the units label text. The units label is provided as a floating point value, so the units text can display at most one floating point value. Note that the units label is optional. Use a format string such as &quot;%1.2f meters&quot; for example.
    /// 
    /// Note: The default format string is an integer percentage, as in $&quot;%.0f %%&quot;.</summary>
    /// <returns>The format string for <c>obj</c>&apos;s units label.</returns>
    public System.String GetFormatString() {
         var _ret_var = Efl.Ui.IFormatNativeInherit.efl_ui_format_string_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Control the format string for a given units label
    /// If <c>NULL</c> is passed to <c>format</c>, it will hide <c>obj</c>&apos;s units area completely. If not, it&apos;ll set the &lt;b&gt;format string&lt;/b&gt; for the units label text. The units label is provided as a floating point value, so the units text can display at most one floating point value. Note that the units label is optional. Use a format string such as &quot;%1.2f meters&quot; for example.
    /// 
    /// Note: The default format string is an integer percentage, as in $&quot;%.0f %%&quot;.</summary>
    /// <param name="units">The format string for <c>obj</c>&apos;s units label.</param>
    /// <returns></returns>
    public void SetFormatString( System.String units) {
                                 Efl.Ui.IFormatNativeInherit.efl_ui_format_string_set_ptr.Value.Delegate(this.NativeHandle, units);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Set the format function pointer to format the string.</summary>
/// <value>The format function callback</value>
    public Efl.Ui.FormatFuncCb FormatCb {
        set { SetFormatCb( value); }
    }
    /// <summary>Control the format string for a given units label
/// If <c>NULL</c> is passed to <c>format</c>, it will hide <c>obj</c>&apos;s units area completely. If not, it&apos;ll set the &lt;b&gt;format string&lt;/b&gt; for the units label text. The units label is provided as a floating point value, so the units text can display at most one floating point value. Note that the units label is optional. Use a format string such as &quot;%1.2f meters&quot; for example.
/// 
/// Note: The default format string is an integer percentage, as in $&quot;%.0f %%&quot;.</summary>
/// <value>The format string for <c>obj</c>&apos;s units label.</value>
    public System.String FormatString {
        get { return GetFormatString(); }
        set { SetFormatString( value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.IFormatConcrete.efl_ui_format_mixin_get();
    }
}
public class IFormatNativeInherit  : Efl.Eo.NativeClass{
    public  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Efl);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
        if (efl_ui_format_cb_set_static_delegate == null)
            efl_ui_format_cb_set_static_delegate = new efl_ui_format_cb_set_delegate(format_cb_set);
        if (methods.FirstOrDefault(m => m.Name == "SetFormatCb") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_format_cb_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_format_cb_set_static_delegate)});
        if (efl_ui_format_string_get_static_delegate == null)
            efl_ui_format_string_get_static_delegate = new efl_ui_format_string_get_delegate(format_string_get);
        if (methods.FirstOrDefault(m => m.Name == "GetFormatString") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_format_string_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_format_string_get_static_delegate)});
        if (efl_ui_format_string_set_static_delegate == null)
            efl_ui_format_string_set_static_delegate = new efl_ui_format_string_set_delegate(format_string_set);
        if (methods.FirstOrDefault(m => m.Name == "SetFormatString") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_format_string_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_format_string_set_static_delegate)});
        return descs;
    }
    public override IntPtr GetEflClass()
    {
        return Efl.Ui.IFormatConcrete.efl_ui_format_mixin_get();
    }
    public static  IntPtr GetEflClassStatic()
    {
        return Efl.Ui.IFormatConcrete.efl_ui_format_mixin_get();
    }


     private delegate void efl_ui_format_cb_set_delegate(System.IntPtr obj, System.IntPtr pd,  IntPtr func_data, Efl.Ui.FormatFuncCbInternal func, EinaFreeCb func_free_cb);


     public delegate void efl_ui_format_cb_set_api_delegate(System.IntPtr obj,  IntPtr func_data, Efl.Ui.FormatFuncCbInternal func, EinaFreeCb func_free_cb);
     public static Efl.Eo.FunctionWrapper<efl_ui_format_cb_set_api_delegate> efl_ui_format_cb_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_format_cb_set_api_delegate>(_Module, "efl_ui_format_cb_set");
     private static void format_cb_set(System.IntPtr obj, System.IntPtr pd, IntPtr func_data, Efl.Ui.FormatFuncCbInternal func, EinaFreeCb func_free_cb)
    {
        Eina.Log.Debug("function efl_ui_format_cb_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                        Efl.Ui.FormatFuncCbWrapper func_wrapper = new Efl.Ui.FormatFuncCbWrapper(func, func_data, func_free_cb);
            
            try {
                ((IFormatConcrete)wrapper).SetFormatCb( func_wrapper.ManagedCb);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_ui_format_cb_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), func_data, func, func_free_cb);
        }
    }
    private static efl_ui_format_cb_set_delegate efl_ui_format_cb_set_static_delegate;


     [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate System.String efl_ui_format_string_get_delegate(System.IntPtr obj, System.IntPtr pd);


     [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate System.String efl_ui_format_string_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_ui_format_string_get_api_delegate> efl_ui_format_string_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_format_string_get_api_delegate>(_Module, "efl_ui_format_string_get");
     private static System.String format_string_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_ui_format_string_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        System.String _ret_var = default(System.String);
            try {
                _ret_var = ((IFormatConcrete)wrapper).GetFormatString();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_ui_format_string_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_ui_format_string_get_delegate efl_ui_format_string_get_static_delegate;


     private delegate void efl_ui_format_string_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String units);


     public delegate void efl_ui_format_string_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String units);
     public static Efl.Eo.FunctionWrapper<efl_ui_format_string_set_api_delegate> efl_ui_format_string_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_format_string_set_api_delegate>(_Module, "efl_ui_format_string_set");
     private static void format_string_set(System.IntPtr obj, System.IntPtr pd,  System.String units)
    {
        Eina.Log.Debug("function efl_ui_format_string_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((IFormatConcrete)wrapper).SetFormatString( units);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_ui_format_string_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  units);
        }
    }
    private static efl_ui_format_string_set_delegate efl_ui_format_string_set_static_delegate;
}
} } 
