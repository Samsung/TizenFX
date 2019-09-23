#define EFL_BETA
#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Input {

/// <summary>Efl input state interface.
/// (Since EFL 1.22)</summary>
[Efl.Input.StateConcrete.NativeMethods]
[Efl.Eo.BindingEntity]
public interface IState : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Indicates whether a key modifier is on, such as Ctrl, Shift, ...
/// (Since EFL 1.22)
/// 
/// <b>This is a BETA method</b>. It can be modified or removed in the future. Do not use it for product development.</summary>
/// <param name="mod">The modifier key to test.</param>
/// <param name="seat">The seat device, may be <c>null</c></param>
/// <returns><c>true</c> if the key modifier is pressed.</returns>
bool GetModifierEnabled(Efl.Input.Modifier mod, Efl.Input.Device seat);
    /// <summary>Indicates whether a key lock is on, such as NumLock, CapsLock, ...
/// (Since EFL 1.22)
/// 
/// <b>This is a BETA method</b>. It can be modified or removed in the future. Do not use it for product development.</summary>
/// <param name="kw_lock">The lock key to test.</param>
/// <param name="seat">The seat device, may be <c>null</c></param>
/// <returns><c>true</c> if the key lock is on.</returns>
bool GetLockEnabled(Efl.Input.Lock kw_lock, Efl.Input.Device seat);
        }
/// <summary>Efl input state interface.
/// (Since EFL 1.22)</summary>
public sealed class StateConcrete :
    Efl.Eo.EoWrapper
    , IState
    
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(StateConcrete))
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
    private StateConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] internal static extern System.IntPtr
        efl_input_state_interface_get();
    /// <summary>Initializes a new instance of the <see cref="IState"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private StateConcrete(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

#pragma warning disable CS0628
    /// <summary>Indicates whether a key modifier is on, such as Ctrl, Shift, ...
    /// (Since EFL 1.22)
    /// 
    /// <b>This is a BETA method</b>. It can be modified or removed in the future. Do not use it for product development.</summary>
    /// <param name="mod">The modifier key to test.</param>
    /// <param name="seat">The seat device, may be <c>null</c></param>
    /// <returns><c>true</c> if the key modifier is pressed.</returns>
    public bool GetModifierEnabled(Efl.Input.Modifier mod, Efl.Input.Device seat) {
                                                         var _ret_var = Efl.Input.StateConcrete.NativeMethods.efl_input_modifier_enabled_get_ptr.Value.Delegate(this.NativeHandle,mod, seat);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Indicates whether a key lock is on, such as NumLock, CapsLock, ...
    /// (Since EFL 1.22)
    /// 
    /// <b>This is a BETA method</b>. It can be modified or removed in the future. Do not use it for product development.</summary>
    /// <param name="kw_lock">The lock key to test.</param>
    /// <param name="seat">The seat device, may be <c>null</c></param>
    /// <returns><c>true</c> if the key lock is on.</returns>
    public bool GetLockEnabled(Efl.Input.Lock kw_lock, Efl.Input.Device seat) {
                                                         var _ret_var = Efl.Input.StateConcrete.NativeMethods.efl_input_lock_enabled_get_ptr.Value.Delegate(this.NativeHandle,kw_lock, seat);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
#pragma warning restore CS0628
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Input.StateConcrete.efl_input_state_interface_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Eo.EoWrapper.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Evas);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_input_modifier_enabled_get_static_delegate == null)
            {
                efl_input_modifier_enabled_get_static_delegate = new efl_input_modifier_enabled_get_delegate(modifier_enabled_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetModifierEnabled") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_modifier_enabled_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_modifier_enabled_get_static_delegate) });
            }

            if (efl_input_lock_enabled_get_static_delegate == null)
            {
                efl_input_lock_enabled_get_static_delegate = new efl_input_lock_enabled_get_delegate(lock_enabled_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetLockEnabled") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_lock_enabled_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_lock_enabled_get_static_delegate) });
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
            return Efl.Input.StateConcrete.efl_input_state_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_input_modifier_enabled_get_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Input.Modifier mod, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Input.Device seat);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_input_modifier_enabled_get_api_delegate(System.IntPtr obj,  Efl.Input.Modifier mod, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Input.Device seat);

        public static Efl.Eo.FunctionWrapper<efl_input_modifier_enabled_get_api_delegate> efl_input_modifier_enabled_get_ptr = new Efl.Eo.FunctionWrapper<efl_input_modifier_enabled_get_api_delegate>(Module, "efl_input_modifier_enabled_get");

        private static bool modifier_enabled_get(System.IntPtr obj, System.IntPtr pd, Efl.Input.Modifier mod, Efl.Input.Device seat)
        {
            Eina.Log.Debug("function efl_input_modifier_enabled_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IState)ws.Target).GetModifierEnabled(mod, seat);
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
                return efl_input_modifier_enabled_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), mod, seat);
            }
        }

        private static efl_input_modifier_enabled_get_delegate efl_input_modifier_enabled_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_input_lock_enabled_get_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Input.Lock kw_lock, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Input.Device seat);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_input_lock_enabled_get_api_delegate(System.IntPtr obj,  Efl.Input.Lock kw_lock, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Input.Device seat);

        public static Efl.Eo.FunctionWrapper<efl_input_lock_enabled_get_api_delegate> efl_input_lock_enabled_get_ptr = new Efl.Eo.FunctionWrapper<efl_input_lock_enabled_get_api_delegate>(Module, "efl_input_lock_enabled_get");

        private static bool lock_enabled_get(System.IntPtr obj, System.IntPtr pd, Efl.Input.Lock kw_lock, Efl.Input.Device seat)
        {
            Eina.Log.Debug("function efl_input_lock_enabled_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IState)ws.Target).GetLockEnabled(kw_lock, seat);
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
                return efl_input_lock_enabled_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), kw_lock, seat);
            }
        }

        private static efl_input_lock_enabled_get_delegate efl_input_lock_enabled_get_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_InputStateConcrete_ExtensionMethods {
    
    
}
#pragma warning restore CS1591
#endif
