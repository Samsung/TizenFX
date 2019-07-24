#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Ui {

/// <summary>The bg (background) widget is used for setting (solid) background decorations
/// in a window (unless it has transparency enabled) or on any container object. It works just like an image but has some properties useful for backgrounds, such as setting it to tiled, centered, scaled or stretched.</summary>
[Efl.Ui.ILegacyConcrete.NativeMethods]
[Efl.Eo.BindingEntity]
public interface ILegacy : 
    Efl.Eo.IWrapper, IDisposable
{
}
/// <summary>The bg (background) widget is used for setting (solid) background decorations
/// in a window (unless it has transparency enabled) or on any container object. It works just like an image but has some properties useful for backgrounds, such as setting it to tiled, centered, scaled or stretched.</summary>
sealed public class ILegacyConcrete :
    Efl.Eo.EoWrapper
    , ILegacy
    
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(ILegacyConcrete))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    /// <summary>Constructor to be used when objects are expected to be constructed from native code.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    private ILegacyConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_ui_legacy_interface_get();
    /// <summary>Initializes a new instance of the <see cref="ILegacy"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private ILegacyConcrete(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.ILegacyConcrete.efl_ui_legacy_interface_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Eo.EoWrapper.NativeMethods
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
            return Efl.Ui.ILegacyConcrete.efl_ui_legacy_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

