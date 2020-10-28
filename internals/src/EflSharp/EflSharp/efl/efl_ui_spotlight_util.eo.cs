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

namespace Spotlight {

/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Ui.Spotlight.Util.NativeMethods]
[Efl.Eo.BindingEntity]
public class Util : Efl.Eo.EoWrapper
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(Util))
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
        efl_ui_spotlight_util_class_get();
    /// <summary>Initializes a new instance of the <see cref="Util"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public Util(Efl.Object parent= null
            ) : base(efl_ui_spotlight_util_class_get(), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected Util(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Util"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected Util(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Util"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected Util(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }

    /// <summary>Get a preconfigured stack obejct</summary>
    public static Efl.Ui.Spotlight.Container StackGen(Efl.Ui.Widget parent) {
                                 var _ret_var = Efl.Ui.Spotlight.Util.NativeMethods.efl_ui_spotlight_util_stack_gen_ptr.Value.Delegate(parent);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.Spotlight.Util.efl_ui_spotlight_util_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Eo.EoWrapper.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Elementary);
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
            return Efl.Ui.Spotlight.Util.efl_ui_spotlight_util_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Ui.Spotlight.Container efl_ui_spotlight_util_stack_gen_delegate([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Ui.Widget parent);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Ui.Spotlight.Container efl_ui_spotlight_util_stack_gen_api_delegate([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Ui.Widget parent);

        public static Efl.Eo.FunctionWrapper<efl_ui_spotlight_util_stack_gen_api_delegate> efl_ui_spotlight_util_stack_gen_ptr = new Efl.Eo.FunctionWrapper<efl_ui_spotlight_util_stack_gen_api_delegate>(Module, "efl_ui_spotlight_util_stack_gen");

        private static Efl.Ui.Spotlight.Container stack_gen(System.IntPtr obj, System.IntPtr pd, Efl.Ui.Widget parent)
        {
            Eina.Log.Debug("function efl_ui_spotlight_util_stack_gen was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    Efl.Ui.Spotlight.Container _ret_var = default(Efl.Ui.Spotlight.Container);
                try
                {
                    _ret_var = Util.StackGen(parent);
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
                return efl_ui_spotlight_util_stack_gen_ptr.Value.Delegate(parent);
            }
        }

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_Ui_SpotlightUtil_ExtensionMethods {
}
#pragma warning restore CS1591
#endif
