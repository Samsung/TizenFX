#define EFL_BETA
#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Ui {

namespace Focus {

/// <summary>An interface to indicate the end of a focus chain.
/// Focus managers are ensuring that if they give focus to something, that is registered in the upper focus manager. The uppermost focus manager does not need to do that, and can implement this interface to indicate so.</summary>
/// <since_tizen> 6 </since_tizen>
[Efl.Ui.Focus.ManagerWindowRootConcrete.NativeMethods]
[Efl.Eo.BindingEntity]
public interface IManagerWindowRoot : 
    Efl.Eo.IWrapper, IDisposable
{
}

/// <summary>An interface to indicate the end of a focus chain.
/// Focus managers are ensuring that if they give focus to something, that is registered in the upper focus manager. The uppermost focus manager does not need to do that, and can implement this interface to indicate so.</summary>
/// <since_tizen> 6 </since_tizen>
public sealed class ManagerWindowRootConcrete :
    Efl.Eo.EoWrapper
    , IManagerWindowRoot
    
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(ManagerWindowRootConcrete))
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
    private ManagerWindowRootConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_ui_focus_manager_window_root_interface_get();

    /// <summary>Initializes a new instance of the <see cref="IManagerWindowRoot"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private ManagerWindowRootConcrete(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

#pragma warning disable CS0628
#pragma warning restore CS0628
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.Focus.ManagerWindowRootConcrete.efl_ui_focus_manager_window_root_interface_get();
    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Eo.EoWrapper.NativeMethods
    {
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
            return Efl.Ui.Focus.ManagerWindowRootConcrete.efl_ui_focus_manager_window_root_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}
}
}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_Ui_FocusManagerWindowRootConcrete_ExtensionMethods {
}
#pragma warning restore CS1591
#endif
