#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Datetime { 
/// <summary>Efl datetime manager class for Datepicker and Timepicker</summary>
[ManagerNativeInherit]
public class Manager : Efl.Object, Efl.Eo.IWrapper
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (Manager))
                return Efl.Datetime.ManagerNativeInherit.GetEflClassStatic();
            else
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
        }
    }
    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_datetime_manager_class_get();
    ///<summary>Creates a new instance.</summary>
    ///<param name="parent">Parent instance.</param>
    public Manager(Efl.Object parent= null
            ) :
        base(efl_datetime_manager_class_get(), typeof(Manager), parent)
    {
        FinishInstantiation();
    }
    ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    protected Manager(System.IntPtr raw) : base(raw)
    {
                RegisterEventProxies();
    }
    ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    protected Manager(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
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
    protected override void RegisterEventProxies()
    {
        base.RegisterEventProxies();
    }
    /// <summary>The value of a date, time for Datepicker or Timepicker.
    /// The value for Datepicker contains year, month, and day. (tm_year, tm_mon, and tm_mday in Efl_Time) The value for Timepicker contains hour, and min. (tm_hour, and tm_min in Efl_Time)</summary>
    /// <returns>Time structure containing date or time value.</returns>
    virtual public Efl.Time GetValue() {
         var _ret_var = Efl.Datetime.ManagerNativeInherit.efl_datetime_manager_value_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The value of a date, time for Datepicker or Timepicker.
    /// The value for Datepicker contains year, month, and day. (tm_year, tm_mon, and tm_mday in Efl_Time) The value for Timepicker contains hour, and min. (tm_hour, and tm_min in Efl_Time)</summary>
    /// <param name="newtime">Time structure containing date or time value.</param>
    /// <returns></returns>
    virtual public void SetValue( Efl.Time newtime) {
         Efl.Time.NativeStruct _in_newtime = newtime;
                        Efl.Datetime.ManagerNativeInherit.efl_datetime_manager_value_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), _in_newtime);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The format of date or time.
    /// Default format is taken as per the system locale settings.</summary>
    /// <returns>The format string</returns>
    virtual public System.String GetFormat() {
         var _ret_var = Efl.Datetime.ManagerNativeInherit.efl_datetime_manager_format_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The format of date or time.
    /// Default format is taken as per the system locale settings.</summary>
    /// <param name="fmt">The format string</param>
    /// <returns></returns>
    virtual public void SetFormat( System.String fmt) {
                                 Efl.Datetime.ManagerNativeInherit.efl_datetime_manager_format_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), fmt);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get the string that matches with the format.</summary>
    /// <param name="fmt">The format string</param>
    /// <returns>The string that matches with the format</returns>
    virtual public System.String GetString( System.String fmt) {
                                 var _ret_var = Efl.Datetime.ManagerNativeInherit.efl_datetime_manager_string_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), fmt);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>The value of a date, time for Datepicker or Timepicker.
/// The value for Datepicker contains year, month, and day. (tm_year, tm_mon, and tm_mday in Efl_Time) The value for Timepicker contains hour, and min. (tm_hour, and tm_min in Efl_Time)</summary>
/// <value>Time structure containing date or time value.</value>
    public Efl.Time Value {
        get { return GetValue(); }
        set { SetValue( value); }
    }
    /// <summary>The format of date or time.
/// Default format is taken as per the system locale settings.</summary>
/// <value>The format string</value>
    public System.String Format {
        get { return GetFormat(); }
        set { SetFormat( value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Datetime.Manager.efl_datetime_manager_class_get();
    }
}
public class ManagerNativeInherit : Efl.ObjectNativeInherit{
    public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Elementary);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
        if (efl_datetime_manager_value_get_static_delegate == null)
            efl_datetime_manager_value_get_static_delegate = new efl_datetime_manager_value_get_delegate(value_get);
        if (methods.FirstOrDefault(m => m.Name == "GetValue") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_datetime_manager_value_get"), func = Marshal.GetFunctionPointerForDelegate(efl_datetime_manager_value_get_static_delegate)});
        if (efl_datetime_manager_value_set_static_delegate == null)
            efl_datetime_manager_value_set_static_delegate = new efl_datetime_manager_value_set_delegate(value_set);
        if (methods.FirstOrDefault(m => m.Name == "SetValue") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_datetime_manager_value_set"), func = Marshal.GetFunctionPointerForDelegate(efl_datetime_manager_value_set_static_delegate)});
        if (efl_datetime_manager_format_get_static_delegate == null)
            efl_datetime_manager_format_get_static_delegate = new efl_datetime_manager_format_get_delegate(format_get);
        if (methods.FirstOrDefault(m => m.Name == "GetFormat") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_datetime_manager_format_get"), func = Marshal.GetFunctionPointerForDelegate(efl_datetime_manager_format_get_static_delegate)});
        if (efl_datetime_manager_format_set_static_delegate == null)
            efl_datetime_manager_format_set_static_delegate = new efl_datetime_manager_format_set_delegate(format_set);
        if (methods.FirstOrDefault(m => m.Name == "SetFormat") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_datetime_manager_format_set"), func = Marshal.GetFunctionPointerForDelegate(efl_datetime_manager_format_set_static_delegate)});
        if (efl_datetime_manager_string_get_static_delegate == null)
            efl_datetime_manager_string_get_static_delegate = new efl_datetime_manager_string_get_delegate(string_get);
        if (methods.FirstOrDefault(m => m.Name == "GetString") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_datetime_manager_string_get"), func = Marshal.GetFunctionPointerForDelegate(efl_datetime_manager_string_get_static_delegate)});
        descs.AddRange(base.GetEoOps(type));
        return descs;
    }
    public override IntPtr GetEflClass()
    {
        return Efl.Datetime.Manager.efl_datetime_manager_class_get();
    }
    public static new  IntPtr GetEflClassStatic()
    {
        return Efl.Datetime.Manager.efl_datetime_manager_class_get();
    }


     private delegate Efl.Time.NativeStruct efl_datetime_manager_value_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate Efl.Time.NativeStruct efl_datetime_manager_value_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_datetime_manager_value_get_api_delegate> efl_datetime_manager_value_get_ptr = new Efl.Eo.FunctionWrapper<efl_datetime_manager_value_get_api_delegate>(_Module, "efl_datetime_manager_value_get");
     private static Efl.Time.NativeStruct value_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_datetime_manager_value_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Efl.Time _ret_var = default(Efl.Time);
            try {
                _ret_var = ((Manager)wrapper).GetValue();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_datetime_manager_value_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_datetime_manager_value_get_delegate efl_datetime_manager_value_get_static_delegate;


     private delegate void efl_datetime_manager_value_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Time.NativeStruct newtime);


     public delegate void efl_datetime_manager_value_set_api_delegate(System.IntPtr obj,   Efl.Time.NativeStruct newtime);
     public static Efl.Eo.FunctionWrapper<efl_datetime_manager_value_set_api_delegate> efl_datetime_manager_value_set_ptr = new Efl.Eo.FunctionWrapper<efl_datetime_manager_value_set_api_delegate>(_Module, "efl_datetime_manager_value_set");
     private static void value_set(System.IntPtr obj, System.IntPtr pd,  Efl.Time.NativeStruct newtime)
    {
        Eina.Log.Debug("function efl_datetime_manager_value_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                    Efl.Time _in_newtime = newtime;
                            
            try {
                ((Manager)wrapper).SetValue( _in_newtime);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_datetime_manager_value_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  newtime);
        }
    }
    private static efl_datetime_manager_value_set_delegate efl_datetime_manager_value_set_static_delegate;


     [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate System.String efl_datetime_manager_format_get_delegate(System.IntPtr obj, System.IntPtr pd);


     [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate System.String efl_datetime_manager_format_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_datetime_manager_format_get_api_delegate> efl_datetime_manager_format_get_ptr = new Efl.Eo.FunctionWrapper<efl_datetime_manager_format_get_api_delegate>(_Module, "efl_datetime_manager_format_get");
     private static System.String format_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_datetime_manager_format_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        System.String _ret_var = default(System.String);
            try {
                _ret_var = ((Manager)wrapper).GetFormat();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_datetime_manager_format_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_datetime_manager_format_get_delegate efl_datetime_manager_format_get_static_delegate;


     private delegate void efl_datetime_manager_format_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String fmt);


     public delegate void efl_datetime_manager_format_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String fmt);
     public static Efl.Eo.FunctionWrapper<efl_datetime_manager_format_set_api_delegate> efl_datetime_manager_format_set_ptr = new Efl.Eo.FunctionWrapper<efl_datetime_manager_format_set_api_delegate>(_Module, "efl_datetime_manager_format_set");
     private static void format_set(System.IntPtr obj, System.IntPtr pd,  System.String fmt)
    {
        Eina.Log.Debug("function efl_datetime_manager_format_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((Manager)wrapper).SetFormat( fmt);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_datetime_manager_format_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  fmt);
        }
    }
    private static efl_datetime_manager_format_set_delegate efl_datetime_manager_format_set_static_delegate;


     [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate System.String efl_datetime_manager_string_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String fmt);


     [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate System.String efl_datetime_manager_string_get_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String fmt);
     public static Efl.Eo.FunctionWrapper<efl_datetime_manager_string_get_api_delegate> efl_datetime_manager_string_get_ptr = new Efl.Eo.FunctionWrapper<efl_datetime_manager_string_get_api_delegate>(_Module, "efl_datetime_manager_string_get");
     private static System.String string_get(System.IntPtr obj, System.IntPtr pd,  System.String fmt)
    {
        Eina.Log.Debug("function efl_datetime_manager_string_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                System.String _ret_var = default(System.String);
            try {
                _ret_var = ((Manager)wrapper).GetString( fmt);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                        return _ret_var;
        } else {
            return efl_datetime_manager_string_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  fmt);
        }
    }
    private static efl_datetime_manager_string_get_delegate efl_datetime_manager_string_get_static_delegate;
}
} } 
