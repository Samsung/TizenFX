#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary>An off-screen window to be displayed in a remote process.
/// The window is rendered onto an image buffer to be displayed in another process&apos; plug image object. No actual window is created for this type. The window contents can then be sent over a socket so that another process displays it inside a plug image.</summary>
[WinSocketNativeInherit]
public class WinSocket : Efl.Ui.Win, Efl.Eo.IWrapper
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (WinSocket))
                return Efl.Ui.WinSocketNativeInherit.GetEflClassStatic();
            else
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
        }
    }
    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_ui_win_socket_class_get();
    ///<summary>Creates a new instance.</summary>
    ///<param name="parent">Parent instance.</param>
    ///<param name="style">The widget style to use. See <see cref="Efl.Ui.Widget.SetStyle"/></param>
    ///<param name="winName">The window name. See <see cref="Efl.Ui.Win.SetWinName"/></param>
    ///<param name="winType">The type of the window. See <see cref="Efl.Ui.Win.SetWinType"/></param>
    ///<param name="accelPreference">The hardware acceleration preference for this window. See <see cref="Efl.Ui.Win.SetAccelPreference"/></param>
    public WinSocket(Efl.Object parent
            , System.String style = null, System.String winName = null, Efl.Ui.WinType? winType = null, System.String accelPreference = null) :
        base(efl_ui_win_socket_class_get(), typeof(WinSocket), parent)
    {
        if (Efl.Eo.Globals.ParamHelperCheck(style))
            SetStyle(Efl.Eo.Globals.GetParamHelper(style));
        if (Efl.Eo.Globals.ParamHelperCheck(winName))
            SetWinName(Efl.Eo.Globals.GetParamHelper(winName));
        if (Efl.Eo.Globals.ParamHelperCheck(winType))
            SetWinType(Efl.Eo.Globals.GetParamHelper(winType));
        if (Efl.Eo.Globals.ParamHelperCheck(accelPreference))
            SetAccelPreference(Efl.Eo.Globals.GetParamHelper(accelPreference));
        FinishInstantiation();
    }
    ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    protected WinSocket(System.IntPtr raw) : base(raw)
    {
                RegisterEventProxies();
    }
    ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    protected WinSocket(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
    ///<summary>Verifies if the given object is equal to this one.</summary>
    public override bool Equals(object obj)
    {
        var other = obj as Efl.Object;
        if (other == null)
            return false;
        return this.NativeHandle == other.NativeHandle;
    }
    ///<summary>Gets the hash code for this object based on the native pointer it points to.</summary>
    public override int GetHashCode()
    {
        return this.NativeHandle.ToInt32();
    }
    ///<summary>Turns the native pointer into a string representation.</summary>
    public override String ToString()
    {
        return $"{this.GetType().Name}@[{this.NativeHandle.ToInt32():x}]";
    }
    ///<summary>Register the Eo event wrappers making the bridge to C# events. Internal usage only.</summary>
    protected override void RegisterEventProxies()
    {
        base.RegisterEventProxies();
    }
    /// <summary>Create a socket to provide the service for Plug widget.</summary>
    /// <param name="svcname">The name of the service to be advertised. Ensure that it is unique (when combined with <c>svcnum</c>) otherwise creation may fail.</param>
    /// <param name="svcnum">A number (any value, 0 being the common default) to differentiate multiple instances of services with the same name.</param>
    /// <param name="svcsys">A boolean which when true specifies the creation of a system-wide service to which all users can connect, otherwise the service is private to the user id that created it.</param>
    /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
    virtual public bool SocketListen( System.String svcname,  int svcnum,  bool svcsys) {
                                                                                 var _ret_var = Efl.Ui.WinSocketNativeInherit.efl_ui_win_socket_listen_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), svcname,  svcnum,  svcsys);
        Eina.Error.RaiseIfUnhandledException();
                                                        return _ret_var;
 }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.WinSocket.efl_ui_win_socket_class_get();
    }
}
public class WinSocketNativeInherit : Efl.Ui.WinNativeInherit{
    public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Elementary);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
        if (efl_ui_win_socket_listen_static_delegate == null)
            efl_ui_win_socket_listen_static_delegate = new efl_ui_win_socket_listen_delegate(socket_listen);
        if (methods.FirstOrDefault(m => m.Name == "SocketListen") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_win_socket_listen"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_socket_listen_static_delegate)});
        descs.AddRange(base.GetEoOps(type));
        return descs;
    }
    public override IntPtr GetEflClass()
    {
        return Efl.Ui.WinSocket.efl_ui_win_socket_class_get();
    }
    public static new  IntPtr GetEflClassStatic()
    {
        return Efl.Ui.WinSocket.efl_ui_win_socket_class_get();
    }


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_win_socket_listen_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String svcname,   int svcnum,  [MarshalAs(UnmanagedType.U1)]  bool svcsys);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_win_socket_listen_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String svcname,   int svcnum,  [MarshalAs(UnmanagedType.U1)]  bool svcsys);
     public static Efl.Eo.FunctionWrapper<efl_ui_win_socket_listen_api_delegate> efl_ui_win_socket_listen_ptr = new Efl.Eo.FunctionWrapper<efl_ui_win_socket_listen_api_delegate>(_Module, "efl_ui_win_socket_listen");
     private static bool socket_listen(System.IntPtr obj, System.IntPtr pd,  System.String svcname,  int svcnum,  bool svcsys)
    {
        Eina.Log.Debug("function efl_ui_win_socket_listen was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                                                bool _ret_var = default(bool);
            try {
                _ret_var = ((WinSocket)wrapper).SocketListen( svcname,  svcnum,  svcsys);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                        return _ret_var;
        } else {
            return efl_ui_win_socket_listen_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  svcname,  svcnum,  svcsys);
        }
    }
    private static efl_ui_win_socket_listen_delegate efl_ui_win_socket_listen_static_delegate;
}
} } 
