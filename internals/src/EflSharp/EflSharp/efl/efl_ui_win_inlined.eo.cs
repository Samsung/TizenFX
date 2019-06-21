#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Ui {

/// <summary>An inlined window.
/// The window is rendered onto an image buffer. No actual window is created, instead the window and all of its contents will be rendered to an image buffer. This allows child windows inside a parent just like any other object.  You can also do other things like apply map effects. This window must have a valid <see cref="Efl.Canvas.Object"/> parent.</summary>
[Efl.Ui.WinInlined.NativeMethods]
public class WinInlined : Efl.Ui.Win
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(WinInlined))
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
        efl_ui_win_inlined_class_get();
    /// <summary>Initializes a new instance of the <see cref="WinInlined"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    /// <param name="style">The widget style to use. See <see cref="Efl.Ui.Widget.SetStyle"/></param>
    /// <param name="winName">The window name. See <see cref="Efl.Ui.Win.SetWinName"/></param>
    /// <param name="winType">The type of the window. See <see cref="Efl.Ui.Win.SetWinType"/></param>
    /// <param name="accelPreference">The hardware acceleration preference for this window. See <see cref="Efl.Ui.Win.SetAccelPreference"/></param>
    public WinInlined(Efl.Object parent
            , System.String style = null, System.String winName = null, Efl.Ui.WinType? winType = null, System.String accelPreference = null) : base(efl_ui_win_inlined_class_get(), typeof(WinInlined), parent)
    {
        if (Efl.Eo.Globals.ParamHelperCheck(style))
        {
            SetStyle(Efl.Eo.Globals.GetParamHelper(style));
        }

        if (Efl.Eo.Globals.ParamHelperCheck(winName))
        {
            SetWinName(Efl.Eo.Globals.GetParamHelper(winName));
        }

        if (Efl.Eo.Globals.ParamHelperCheck(winType))
        {
            SetWinType(Efl.Eo.Globals.GetParamHelper(winType));
        }

        if (Efl.Eo.Globals.ParamHelperCheck(accelPreference))
        {
            SetAccelPreference(Efl.Eo.Globals.GetParamHelper(accelPreference));
        }

        FinishInstantiation();
    }

    /// <summary>Initializes a new instance of the <see cref="WinInlined"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="raw">The native pointer to be wrapped.</param>
    protected WinInlined(System.IntPtr raw) : base(raw)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="WinInlined"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="managedType">The managed type of the public constructor that originated this call.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected WinInlined(IntPtr baseKlass, System.Type managedType, Efl.Object parent) : base(baseKlass, managedType, parent)
    {
    }

    /// <summary>This property holds the parent object in the parent canvas.</summary>
    /// <returns>An object in the parent canvas.</returns>
    virtual public Efl.Canvas.Object GetInlinedParent() {
         var _ret_var = Efl.Ui.WinInlined.NativeMethods.efl_ui_win_inlined_parent_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>This property holds the parent object in the parent canvas.</summary>
    /// <value>An object in the parent canvas.</value>
    public Efl.Canvas.Object InlinedParent {
        get { return GetInlinedParent(); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.WinInlined.efl_ui_win_inlined_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Ui.Win.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Elementary);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_ui_win_inlined_parent_get_static_delegate == null)
            {
                efl_ui_win_inlined_parent_get_static_delegate = new efl_ui_win_inlined_parent_get_delegate(inlined_parent_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetInlinedParent") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_inlined_parent_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_inlined_parent_get_static_delegate) });
            }

            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.WinInlined.efl_ui_win_inlined_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Canvas.Object efl_ui_win_inlined_parent_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Canvas.Object efl_ui_win_inlined_parent_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_win_inlined_parent_get_api_delegate> efl_ui_win_inlined_parent_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_win_inlined_parent_get_api_delegate>(Module, "efl_ui_win_inlined_parent_get");

        private static Efl.Canvas.Object inlined_parent_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_win_inlined_parent_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Canvas.Object _ret_var = default(Efl.Canvas.Object);
                try
                {
                    _ret_var = ((WinInlined)ws.Target).GetInlinedParent();
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
                return efl_ui_win_inlined_parent_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_win_inlined_parent_get_delegate efl_ui_win_inlined_parent_get_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

