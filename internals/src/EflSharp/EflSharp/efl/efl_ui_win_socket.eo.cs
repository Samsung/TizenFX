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

/// <summary>An off-screen window to be displayed in a remote process.
/// The window is rendered onto an image buffer to be displayed in another process&apos; plug image object. No actual window is created for this type. The window contents can then be sent over a socket so that another process displays it inside a plug image.</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Ui.WinSocket.NativeMethods]
[Efl.Eo.BindingEntity]
public class WinSocket : Efl.Ui.Win
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(WinSocket))
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
        efl_ui_win_socket_class_get();
    /// <summary>Initializes a new instance of the <see cref="WinSocket"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    /// <param name="style">The widget style to use. See <see cref="Efl.Ui.Widget.SetStyle" /></param>
    /// <param name="winName">The window name. See <see cref="Efl.Ui.Win.SetWinName" /></param>
    /// <param name="winType">The type of the window. See <see cref="Efl.Ui.Win.SetWinType" /></param>
    /// <param name="accelPreference">The hardware acceleration preference for this window. See <see cref="Efl.Ui.Win.SetAccelPreference" /></param>
    public WinSocket(Efl.Object parent
            , System.String style = null, System.String winName = null, Efl.Ui.WinType? winType = null, System.String accelPreference = null) : base(efl_ui_win_socket_class_get(), parent)
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

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected WinSocket(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="WinSocket"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected WinSocket(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="WinSocket"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected WinSocket(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }

    /// <summary>Create a socket to provide the service for Plug widget.</summary>
    /// <param name="svcname">The name of the service to be advertised. Ensure that it is unique (when combined with <c>svcnum</c>) otherwise creation may fail.</param>
    /// <param name="svcnum">A number (any value, 0 being the common default) to differentiate multiple instances of services with the same name.</param>
    /// <param name="svcsys">A boolean which when true specifies the creation of a system-wide service to which all users can connect, otherwise the service is private to the user id that created it.</param>
    /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
    virtual public bool SocketListen(System.String svcname, int svcnum, bool svcsys) {
                                                                                 var _ret_var = Efl.Ui.WinSocket.NativeMethods.efl_ui_win_socket_listen_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),svcname, svcnum, svcsys);
        Eina.Error.RaiseIfUnhandledException();
                                                        return _ret_var;
 }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.WinSocket.efl_ui_win_socket_class_get();
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

            if (efl_ui_win_socket_listen_static_delegate == null)
            {
                efl_ui_win_socket_listen_static_delegate = new efl_ui_win_socket_listen_delegate(socket_listen);
            }

            if (methods.FirstOrDefault(m => m.Name == "SocketListen") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_socket_listen"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_socket_listen_static_delegate) });
            }

            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.WinSocket.efl_ui_win_socket_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_win_socket_listen_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String svcname,  int svcnum, [MarshalAs(UnmanagedType.U1)] bool svcsys);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_win_socket_listen_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String svcname,  int svcnum, [MarshalAs(UnmanagedType.U1)] bool svcsys);

        public static Efl.Eo.FunctionWrapper<efl_ui_win_socket_listen_api_delegate> efl_ui_win_socket_listen_ptr = new Efl.Eo.FunctionWrapper<efl_ui_win_socket_listen_api_delegate>(Module, "efl_ui_win_socket_listen");

        private static bool socket_listen(System.IntPtr obj, System.IntPtr pd, System.String svcname, int svcnum, bool svcsys)
        {
            Eina.Log.Debug("function efl_ui_win_socket_listen was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((WinSocket)ws.Target).SocketListen(svcname, svcnum, svcsys);
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
                return efl_ui_win_socket_listen_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), svcname, svcnum, svcsys);
            }
        }

        private static efl_ui_win_socket_listen_delegate efl_ui_win_socket_listen_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_UiWinSocket_ExtensionMethods {
}
#pragma warning restore CS1591
#endif
