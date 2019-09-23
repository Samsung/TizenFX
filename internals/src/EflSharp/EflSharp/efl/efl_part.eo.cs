#define EFL_BETA
#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

/// <summary>Interface for objects supporting named parts.
/// An object implementing this interface will be able to provide access to some of its sub-objects by name. This gives access to parts as defined in a widget&apos;s theme.
/// 
/// Part proxy objects have a special lifetime that is limited to one and only one function call. This behavior is implemented in efl_part() which call Efl.Part.part_get. Calling Efl.Part.part_get directly should be avoided.
/// 
/// In other words, the caller does not hold a reference to this proxy object. It may be possible, in languages that allow it, to get an extra reference to this part object and extend its lifetime to more than a single function call.
/// 
/// In pseudo-code, this means only the following two use cases are supported:
/// 
/// obj.func(part(obj, &quot;part&quot;), args)
/// 
/// And:
/// 
/// part = ref(part(obj, &quot;part&quot;)) func1(part, args) func2(part, args) func3(part, args) unref(part)
/// (Since EFL 1.22)</summary>
[Efl.PartConcrete.NativeMethods]
[Efl.Eo.BindingEntity]
public interface IPart : 
    Efl.Eo.IWrapper, IDisposable
{
        }
/// <summary>Interface for objects supporting named parts.
/// An object implementing this interface will be able to provide access to some of its sub-objects by name. This gives access to parts as defined in a widget&apos;s theme.
/// 
/// Part proxy objects have a special lifetime that is limited to one and only one function call. This behavior is implemented in efl_part() which call Efl.Part.part_get. Calling Efl.Part.part_get directly should be avoided.
/// 
/// In other words, the caller does not hold a reference to this proxy object. It may be possible, in languages that allow it, to get an extra reference to this part object and extend its lifetime to more than a single function call.
/// 
/// In pseudo-code, this means only the following two use cases are supported:
/// 
/// obj.func(part(obj, &quot;part&quot;), args)
/// 
/// And:
/// 
/// part = ref(part(obj, &quot;part&quot;)) func1(part, args) func2(part, args) func3(part, args) unref(part)
/// (Since EFL 1.22)</summary>
public sealed class PartConcrete :
    Efl.Eo.EoWrapper
    , IPart
    
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(PartConcrete))
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
    private PartConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
        efl_part_interface_get();
    /// <summary>Initializes a new instance of the <see cref="IPart"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private PartConcrete(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

#pragma warning disable CS0628
    /// <summary>Get a proxy object referring to a part of an object.
    /// (Since EFL 1.22)</summary>
    /// <param name="name">The part name.</param>
    /// <returns>A (proxy) object, valid for a single call.</returns>
    protected Efl.Object GetPart(System.String name) {
                                 var _ret_var = Efl.PartConcrete.NativeMethods.efl_part_get_ptr.Value.Delegate(this.NativeHandle,name);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
#pragma warning restore CS0628
    private static IntPtr GetEflClassStatic()
    {
        return Efl.PartConcrete.efl_part_interface_get();
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
            return Efl.PartConcrete.efl_part_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Object efl_part_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String name);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Object efl_part_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String name);

        public static Efl.Eo.FunctionWrapper<efl_part_get_api_delegate> efl_part_get_ptr = new Efl.Eo.FunctionWrapper<efl_part_get_api_delegate>(Module, "efl_part_get");

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

#if EFL_BETA
#pragma warning disable CS1591
public static class EflPartConcrete_ExtensionMethods {
}
#pragma warning restore CS1591
#endif
