#define EFL_BETA
#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Canvas {

namespace Vg {

/// <summary>Efl vectopr graphics gradient abstract class</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Canvas.Vg.Gradient.NativeMethods]
[Efl.Eo.BindingEntity]
public abstract class Gradient : Efl.Canvas.Vg.Node, Efl.Gfx.IGradient
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(Gradient))
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
        efl_canvas_vg_gradient_class_get();

    /// <summary>Initializes a new instance of the <see cref="Gradient"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public Gradient(Efl.Object parent= null
            ) : base(efl_canvas_vg_gradient_class_get(), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected Gradient(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Gradient"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected Gradient(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    [Efl.Eo.PrivateNativeClass]
    private class GradientRealized : Gradient
    {
        private GradientRealized(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
        {
        }
    }
    /// <summary>Initializes a new instance of the <see cref="Gradient"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected Gradient(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }


    /// <summary>The list of color stops for the gradient</summary>
    /// <param name="colors">Color stops list</param>
    /// <param name="length">Length of the list</param>
    public virtual void GetStop(out Efl.Gfx.GradientStop colors, out uint length) {
        var _out_colors = new System.IntPtr();
Efl.Gfx.GradientConcrete.NativeMethods.efl_gfx_gradient_stop_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out _out_colors, out length);
        Eina.Error.RaiseIfUnhandledException();
colors = Eina.PrimitiveConversion.PointerToManaged<Efl.Gfx.GradientStop>(_out_colors);
        
    }

    /// <summary>The list of color stops for the gradient</summary>
    /// <param name="colors">Color stops list</param>
    /// <param name="length">Length of the list</param>
    public virtual void SetStop(ref Efl.Gfx.GradientStop colors, uint length) {
        Efl.Gfx.GradientStop.NativeStruct _in_colors = colors;
Efl.Gfx.GradientConcrete.NativeMethods.efl_gfx_gradient_stop_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),ref _in_colors, length);
        Eina.Error.RaiseIfUnhandledException();
colors = _in_colors;
        
    }

    /// <summary>The spread method that should be used for this gradient. The default is <see cref="Efl.Gfx.GradientSpread.Pad"/>.</summary>
    /// <returns>Spread type to be used.</returns>
    public virtual Efl.Gfx.GradientSpread GetSpread() {
        var _ret_var = Efl.Gfx.GradientConcrete.NativeMethods.efl_gfx_gradient_spread_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>The spread method that should be used for this gradient. The default is <see cref="Efl.Gfx.GradientSpread.Pad"/>.</summary>
    /// <param name="s">Spread type to be used.</param>
    public virtual void SetSpread(Efl.Gfx.GradientSpread s) {
        Efl.Gfx.GradientConcrete.NativeMethods.efl_gfx_gradient_spread_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),s);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>The list of color stops for the gradient</summary>
    /// <value>Color stops list</value>
    public (Efl.Gfx.GradientStop, uint) Stop {
        get {
            Efl.Gfx.GradientStop _out_colors = default(Efl.Gfx.GradientStop);
            uint _out_length = default(uint);
            GetStop(out _out_colors,out _out_length);
            return (_out_colors,_out_length);
        }
        set { SetStop(ref  value.Item1,  value.Item2); }
    }

    /// <summary>The spread method that should be used for this gradient. The default is <see cref="Efl.Gfx.GradientSpread.Pad"/>.</summary>
    /// <value>Spread type to be used.</value>
    public Efl.Gfx.GradientSpread Spread {
        get { return GetSpread(); }
        set { SetSpread(value); }
    }

    private static IntPtr GetEflClassStatic()
    {
        return Efl.Canvas.Vg.Gradient.efl_canvas_vg_gradient_class_get();
    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Canvas.Vg.Node.NativeMethods
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
            descs.AddRange(base.GetEoOps(type, false));
            return descs;
        }

        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Canvas.Vg.Gradient.efl_canvas_vg_gradient_class_get();
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
public static class Efl_Canvas_VgGradient_ExtensionMethods {
    public static Efl.BindableProperty<Efl.Gfx.GradientSpread> Spread<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Vg.Gradient, T>magic = null) where T : Efl.Canvas.Vg.Gradient {
        return new Efl.BindableProperty<Efl.Gfx.GradientSpread>("spread", fac);
    }

}
#pragma warning restore CS1591
#endif
