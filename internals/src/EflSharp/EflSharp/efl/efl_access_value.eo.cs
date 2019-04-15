#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Access { 
/// <summary>Elementary Access value interface</summary>
[IValueNativeInherit]
public interface IValue : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Gets value displayed by a accessible widget.</summary>
/// <param name="value">Value of widget casted to floating point number.</param>
/// <param name="text">string describing value in given context eg. small, enough</param>
/// <returns></returns>
void GetValueAndText( out double value,  out System.String text);
    /// <summary>Value and text property</summary>
/// <param name="value">Value of widget casted to floating point number.</param>
/// <param name="text">string describing value in given context eg. small, enough</param>
/// <returns><c>true</c> if setting widgets value has succeeded, otherwise <c>false</c> .</returns>
bool SetValueAndText( double value,  System.String text);
    /// <summary>Gets a range of all possible values and its description</summary>
/// <param name="lower_limit">Lower limit of the range</param>
/// <param name="upper_limit">Upper limit of the range</param>
/// <param name="description">Description of the range</param>
/// <returns></returns>
void GetRange( out double lower_limit,  out double upper_limit,  out System.String description);
    /// <summary>Gets an minimal incrementation value</summary>
/// <returns>Minimal incrementation value</returns>
double GetIncrement();
                    /// <summary>Gets an minimal incrementation value</summary>
/// <value>Minimal incrementation value</value>
    double Increment {
        get ;
    }
}
/// <summary>Elementary Access value interface</summary>
sealed public class IValueConcrete : 

IValue
    
{
    ///<summary>Pointer to the native class description.</summary>
    public System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (IValueConcrete))
                return Efl.Access.IValueNativeInherit.GetEflClassStatic();
            else
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
        }
    }
    private  System.IntPtr handle;
    ///<summary>Pointer to the native instance.</summary>
    public System.IntPtr NativeHandle {
        get { return handle; }
    }
    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_access_value_interface_get();
    ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    private IValueConcrete(System.IntPtr raw)
    {
        handle = raw;
        RegisterEventProxies();
    }
    ///<summary>Destructor.</summary>
    ~IValueConcrete()
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
    /// <summary>Gets value displayed by a accessible widget.</summary>
    /// <param name="value">Value of widget casted to floating point number.</param>
    /// <param name="text">string describing value in given context eg. small, enough</param>
    /// <returns></returns>
    public void GetValueAndText( out double value,  out System.String text) {
                                                         Efl.Access.IValueNativeInherit.efl_access_value_and_text_get_ptr.Value.Delegate(this.NativeHandle, out value,  out text);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Value and text property</summary>
    /// <param name="value">Value of widget casted to floating point number.</param>
    /// <param name="text">string describing value in given context eg. small, enough</param>
    /// <returns><c>true</c> if setting widgets value has succeeded, otherwise <c>false</c> .</returns>
    public bool SetValueAndText( double value,  System.String text) {
                                                         var _ret_var = Efl.Access.IValueNativeInherit.efl_access_value_and_text_set_ptr.Value.Delegate(this.NativeHandle, value,  text);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Gets a range of all possible values and its description</summary>
    /// <param name="lower_limit">Lower limit of the range</param>
    /// <param name="upper_limit">Upper limit of the range</param>
    /// <param name="description">Description of the range</param>
    /// <returns></returns>
    public void GetRange( out double lower_limit,  out double upper_limit,  out System.String description) {
                                                                                 Efl.Access.IValueNativeInherit.efl_access_value_range_get_ptr.Value.Delegate(this.NativeHandle, out lower_limit,  out upper_limit,  out description);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>Gets an minimal incrementation value</summary>
    /// <returns>Minimal incrementation value</returns>
    public double GetIncrement() {
         var _ret_var = Efl.Access.IValueNativeInherit.efl_access_value_increment_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Gets an minimal incrementation value</summary>
/// <value>Minimal incrementation value</value>
    public double Increment {
        get { return GetIncrement(); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Access.IValueConcrete.efl_access_value_interface_get();
    }
}
public class IValueNativeInherit  : Efl.Eo.NativeClass{
    public  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Elementary);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
        if (efl_access_value_and_text_get_static_delegate == null)
            efl_access_value_and_text_get_static_delegate = new efl_access_value_and_text_get_delegate(value_and_text_get);
        if (methods.FirstOrDefault(m => m.Name == "GetValueAndText") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_value_and_text_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_value_and_text_get_static_delegate)});
        if (efl_access_value_and_text_set_static_delegate == null)
            efl_access_value_and_text_set_static_delegate = new efl_access_value_and_text_set_delegate(value_and_text_set);
        if (methods.FirstOrDefault(m => m.Name == "SetValueAndText") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_value_and_text_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_value_and_text_set_static_delegate)});
        if (efl_access_value_range_get_static_delegate == null)
            efl_access_value_range_get_static_delegate = new efl_access_value_range_get_delegate(range_get);
        if (methods.FirstOrDefault(m => m.Name == "GetRange") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_value_range_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_value_range_get_static_delegate)});
        if (efl_access_value_increment_get_static_delegate == null)
            efl_access_value_increment_get_static_delegate = new efl_access_value_increment_get_delegate(increment_get);
        if (methods.FirstOrDefault(m => m.Name == "GetIncrement") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_value_increment_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_value_increment_get_static_delegate)});
        return descs;
    }
    public override IntPtr GetEflClass()
    {
        return Efl.Access.IValueConcrete.efl_access_value_interface_get();
    }
    public static  IntPtr GetEflClassStatic()
    {
        return Efl.Access.IValueConcrete.efl_access_value_interface_get();
    }


     private delegate void efl_access_value_and_text_get_delegate(System.IntPtr obj, System.IntPtr pd,   out double value,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  out System.String text);


     public delegate void efl_access_value_and_text_get_api_delegate(System.IntPtr obj,   out double value,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  out System.String text);
     public static Efl.Eo.FunctionWrapper<efl_access_value_and_text_get_api_delegate> efl_access_value_and_text_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_value_and_text_get_api_delegate>(_Module, "efl_access_value_and_text_get");
     private static void value_and_text_get(System.IntPtr obj, System.IntPtr pd,  out double value,  out System.String text)
    {
        Eina.Log.Debug("function efl_access_value_and_text_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                    value = default(double);        System.String _out_text = default(System.String);
                            
            try {
                ((IValue)wrapper).GetValueAndText( out value,  out _out_text);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                text = _out_text;
                                } else {
            efl_access_value_and_text_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out value,  out text);
        }
    }
    private static efl_access_value_and_text_get_delegate efl_access_value_and_text_get_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_access_value_and_text_set_delegate(System.IntPtr obj, System.IntPtr pd,   double value,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String text);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_access_value_and_text_set_api_delegate(System.IntPtr obj,   double value,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String text);
     public static Efl.Eo.FunctionWrapper<efl_access_value_and_text_set_api_delegate> efl_access_value_and_text_set_ptr = new Efl.Eo.FunctionWrapper<efl_access_value_and_text_set_api_delegate>(_Module, "efl_access_value_and_text_set");
     private static bool value_and_text_set(System.IntPtr obj, System.IntPtr pd,  double value,  System.String text)
    {
        Eina.Log.Debug("function efl_access_value_and_text_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                        bool _ret_var = default(bool);
            try {
                _ret_var = ((IValue)wrapper).SetValueAndText( value,  text);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                        return _ret_var;
        } else {
            return efl_access_value_and_text_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  value,  text);
        }
    }
    private static efl_access_value_and_text_set_delegate efl_access_value_and_text_set_static_delegate;


     private delegate void efl_access_value_range_get_delegate(System.IntPtr obj, System.IntPtr pd,   out double lower_limit,   out double upper_limit,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  out System.String description);


     public delegate void efl_access_value_range_get_api_delegate(System.IntPtr obj,   out double lower_limit,   out double upper_limit,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  out System.String description);
     public static Efl.Eo.FunctionWrapper<efl_access_value_range_get_api_delegate> efl_access_value_range_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_value_range_get_api_delegate>(_Module, "efl_access_value_range_get");
     private static void range_get(System.IntPtr obj, System.IntPtr pd,  out double lower_limit,  out double upper_limit,  out System.String description)
    {
        Eina.Log.Debug("function efl_access_value_range_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                            lower_limit = default(double);        upper_limit = default(double);        System.String _out_description = default(System.String);
                                    
            try {
                ((IValue)wrapper).GetRange( out lower_limit,  out upper_limit,  out _out_description);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                        description = _out_description;
                                        } else {
            efl_access_value_range_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out lower_limit,  out upper_limit,  out description);
        }
    }
    private static efl_access_value_range_get_delegate efl_access_value_range_get_static_delegate;


     private delegate double efl_access_value_increment_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate double efl_access_value_increment_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_access_value_increment_get_api_delegate> efl_access_value_increment_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_value_increment_get_api_delegate>(_Module, "efl_access_value_increment_get");
     private static double increment_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_access_value_increment_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        double _ret_var = default(double);
            try {
                _ret_var = ((IValue)wrapper).GetIncrement();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_access_value_increment_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_access_value_increment_get_delegate efl_access_value_increment_get_static_delegate;
}
} } 
