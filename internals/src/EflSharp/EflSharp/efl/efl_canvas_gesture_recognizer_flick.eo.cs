#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Canvas {

/// <summary>EFL Gesture Recognizer Flick Class</summary>
[Efl.Canvas.GestureRecognizerFlick.NativeMethods]
public class GestureRecognizerFlick : Efl.Canvas.GestureRecognizer
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(GestureRecognizerFlick))
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
        efl_canvas_gesture_recognizer_flick_class_get();
    /// <summary>Initializes a new instance of the <see cref="GestureRecognizerFlick"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public GestureRecognizerFlick(Efl.Object parent= null
            ) : base(efl_canvas_gesture_recognizer_flick_class_get(), typeof(GestureRecognizerFlick), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Initializes a new instance of the <see cref="GestureRecognizerFlick"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="raw">The native pointer to be wrapped.</param>
    protected GestureRecognizerFlick(System.IntPtr raw) : base(raw)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="GestureRecognizerFlick"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="managedType">The managed type of the public constructor that originated this call.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected GestureRecognizerFlick(IntPtr baseKlass, System.Type managedType, Efl.Object parent) : base(baseKlass, managedType, parent)
    {
    }

    private static IntPtr GetEflClassStatic()
    {
        return Efl.Canvas.GestureRecognizerFlick.efl_canvas_gesture_recognizer_flick_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Canvas.GestureRecognizer.NativeMethods
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
            return Efl.Canvas.GestureRecognizerFlick.efl_canvas_gesture_recognizer_flick_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

