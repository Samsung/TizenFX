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

/// <summary>A interface to indicate the end of a focus chain.
/// Focusmanagers are ensuring that if they give focus to something, that they are registered in the upper focus manager. The most upper focus manager does not need to do that, and can implement this interface to indicate that.
/// (Since EFL 1.22)</summary>
[Efl.Ui.Focus.IManagerWindowRootConcrete.NativeMethods]
public interface IManagerWindowRoot : 
    Efl.Eo.IWrapper, IDisposable
{
}
/// <summary>A interface to indicate the end of a focus chain.
/// Focusmanagers are ensuring that if they give focus to something, that they are registered in the upper focus manager. The most upper focus manager does not need to do that, and can implement this interface to indicate that.
/// (Since EFL 1.22)</summary>
sealed public class IManagerWindowRootConcrete :
    Efl.Eo.EoWrapper
    , IManagerWindowRoot
    
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(IManagerWindowRootConcrete))
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
        efl_ui_focus_manager_window_root_interface_get();
    /// <summary>Initializes a new instance of the <see cref="IManagerWindowRoot"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    private IManagerWindowRootConcrete(System.IntPtr raw) : base(raw)
    {
    }

    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.Focus.IManagerWindowRootConcrete.efl_ui_focus_manager_window_root_interface_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public class NativeMethods  : Efl.Eo.NativeClass
    {
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
            return Efl.Ui.Focus.IManagerWindowRootConcrete.efl_ui_focus_manager_window_root_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

}

