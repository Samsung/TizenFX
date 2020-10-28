#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Input { 
/// <summary>Efl input state interface.
/// (Since EFL 1.22)</summary>
[IStateNativeInherit]
public interface IState : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Indicates whether a key modifier is on, such as Ctrl, Shift, ...
/// (Since EFL 1.22)</summary>
/// <param name="mod">The modifier key to test.</param>
/// <param name="seat">The seat device, may be <c>null</c></param>
/// <returns><c>true</c> if the key modifier is pressed.</returns>
bool GetModifierEnabled( Efl.Input.Modifier mod,  Efl.Input.Device seat);
    /// <summary>Indicates whether a key lock is on, such as NumLock, CapsLock, ...
/// (Since EFL 1.22)</summary>
/// <param name="kw_lock">The lock key to test.</param>
/// <param name="seat">The seat device, may be <c>null</c></param>
/// <returns><c>true</c> if the key lock is on.</returns>
bool GetLockEnabled( Efl.Input.Lock kw_lock,  Efl.Input.Device seat);
        }
/// <summary>Efl input state interface.
/// (Since EFL 1.22)</summary>
sealed public class IStateConcrete : 

IState
    
{
    ///<summary>Pointer to the native class description.</summary>
    public System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (IStateConcrete))
                return Efl.Input.IStateNativeInherit.GetEflClassStatic();
            else
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
        }
    }
    private  System.IntPtr handle;
    ///<summary>Pointer to the native instance.</summary>
    public System.IntPtr NativeHandle {
        get { return handle; }
    }
    [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] internal static extern System.IntPtr
        efl_input_state_interface_get();
    ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    private IStateConcrete(System.IntPtr raw)
    {
        handle = raw;
        RegisterEventProxies();
    }
    ///<summary>Destructor.</summary>
    ~IStateConcrete()
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
    /// <summary>Indicates whether a key modifier is on, such as Ctrl, Shift, ...
    /// (Since EFL 1.22)</summary>
    /// <param name="mod">The modifier key to test.</param>
    /// <param name="seat">The seat device, may be <c>null</c></param>
    /// <returns><c>true</c> if the key modifier is pressed.</returns>
    public bool GetModifierEnabled( Efl.Input.Modifier mod,  Efl.Input.Device seat) {
                                                         var _ret_var = Efl.Input.IStateNativeInherit.efl_input_modifier_enabled_get_ptr.Value.Delegate(this.NativeHandle, mod,  seat);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Indicates whether a key lock is on, such as NumLock, CapsLock, ...
    /// (Since EFL 1.22)</summary>
    /// <param name="kw_lock">The lock key to test.</param>
    /// <param name="seat">The seat device, may be <c>null</c></param>
    /// <returns><c>true</c> if the key lock is on.</returns>
    public bool GetLockEnabled( Efl.Input.Lock kw_lock,  Efl.Input.Device seat) {
                                                         var _ret_var = Efl.Input.IStateNativeInherit.efl_input_lock_enabled_get_ptr.Value.Delegate(this.NativeHandle, kw_lock,  seat);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Input.IStateConcrete.efl_input_state_interface_get();
    }
}
public class IStateNativeInherit  : Efl.Eo.NativeClass{
    public  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Evas);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
        if (efl_input_modifier_enabled_get_static_delegate == null)
            efl_input_modifier_enabled_get_static_delegate = new efl_input_modifier_enabled_get_delegate(modifier_enabled_get);
        if (methods.FirstOrDefault(m => m.Name == "GetModifierEnabled") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_modifier_enabled_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_modifier_enabled_get_static_delegate)});
        if (efl_input_lock_enabled_get_static_delegate == null)
            efl_input_lock_enabled_get_static_delegate = new efl_input_lock_enabled_get_delegate(lock_enabled_get);
        if (methods.FirstOrDefault(m => m.Name == "GetLockEnabled") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_lock_enabled_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_lock_enabled_get_static_delegate)});
        return descs;
    }
    public override IntPtr GetEflClass()
    {
        return Efl.Input.IStateConcrete.efl_input_state_interface_get();
    }
    public static  IntPtr GetEflClassStatic()
    {
        return Efl.Input.IStateConcrete.efl_input_state_interface_get();
    }


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_input_modifier_enabled_get_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Input.Modifier mod, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device seat);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_input_modifier_enabled_get_api_delegate(System.IntPtr obj,   Efl.Input.Modifier mod, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device seat);
     public static Efl.Eo.FunctionWrapper<efl_input_modifier_enabled_get_api_delegate> efl_input_modifier_enabled_get_ptr = new Efl.Eo.FunctionWrapper<efl_input_modifier_enabled_get_api_delegate>(_Module, "efl_input_modifier_enabled_get");
     private static bool modifier_enabled_get(System.IntPtr obj, System.IntPtr pd,  Efl.Input.Modifier mod,  Efl.Input.Device seat)
    {
        Eina.Log.Debug("function efl_input_modifier_enabled_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                        bool _ret_var = default(bool);
            try {
                _ret_var = ((IState)wrapper).GetModifierEnabled( mod,  seat);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                        return _ret_var;
        } else {
            return efl_input_modifier_enabled_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  mod,  seat);
        }
    }
    private static efl_input_modifier_enabled_get_delegate efl_input_modifier_enabled_get_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_input_lock_enabled_get_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Input.Lock kw_lock, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device seat);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_input_lock_enabled_get_api_delegate(System.IntPtr obj,   Efl.Input.Lock kw_lock, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device seat);
     public static Efl.Eo.FunctionWrapper<efl_input_lock_enabled_get_api_delegate> efl_input_lock_enabled_get_ptr = new Efl.Eo.FunctionWrapper<efl_input_lock_enabled_get_api_delegate>(_Module, "efl_input_lock_enabled_get");
     private static bool lock_enabled_get(System.IntPtr obj, System.IntPtr pd,  Efl.Input.Lock kw_lock,  Efl.Input.Device seat)
    {
        Eina.Log.Debug("function efl_input_lock_enabled_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                        bool _ret_var = default(bool);
            try {
                _ret_var = ((IState)wrapper).GetLockEnabled( kw_lock,  seat);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                        return _ret_var;
        } else {
            return efl_input_lock_enabled_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  kw_lock,  seat);
        }
    }
    private static efl_input_lock_enabled_get_delegate efl_input_lock_enabled_get_static_delegate;
}
} } 
