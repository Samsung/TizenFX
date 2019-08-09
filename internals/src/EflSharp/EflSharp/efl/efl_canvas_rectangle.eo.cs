#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Canvas {

/// <summary>Evas canvas rectangle class</summary>
[Efl.Canvas.Rectangle.NativeMethods]
[Efl.Eo.BindingEntity]
public class Rectangle : Efl.Canvas.Object
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(Rectangle))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] internal static extern System.IntPtr
        efl_canvas_rectangle_class_get();
    /// <summary>Initializes a new instance of the <see cref="Rectangle"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public Rectangle(Efl.Object parent= null
            ) : base(efl_canvas_rectangle_class_get(), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Constructor to be used when objects are expected to be constructed from native code.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected Rectangle(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Rectangle"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected Rectangle(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Rectangle"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected Rectangle(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }

    private static IntPtr GetEflClassStatic()
    {
        return Efl.Canvas.Rectangle.efl_canvas_rectangle_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Canvas.Object.NativeMethods
    {
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Canvas.Rectangle.efl_canvas_rectangle_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

