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
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Ui.WinSocketNativeInherit nativeInherit = new Efl.Ui.WinSocketNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (WinSocket))
            return Efl.Ui.WinSocketNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   ///<summary>Delegate for function to be called from inside the native constructor.</summary>
   public new delegate void ConstructingMethod(WinSocket obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
      efl_ui_win_socket_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="init_cb">Delegate to call constructing methods that should be run inside the constructor.</param>
   public WinSocket(Efl.Object parent = null, ConstructingMethod init_cb=null) : base("WinSocket", efl_ui_win_socket_class_get(), typeof(WinSocket), parent)
   {
      if (init_cb != null) {
         init_cb(this);
      }
      FinishInstantiation();
   }
   ///<summary>Internal constructor to forward the wrapper initialization to the root class.</summary>
   protected WinSocket(String klass_name, IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(klass_name, base_klass, managed_type, parent) {}
   ///<summary>Constructs an instance from a native pointer.</summary>
   public WinSocket(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static WinSocket static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new WinSocket(obj.NativeHandle);
   }
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
   protected override void register_event_proxies()
   {
      base.register_event_proxies();
   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_ui_win_socket_listen(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String svcname,    int svcnum,  [MarshalAs(UnmanagedType.U1)]  bool svcsys);
   /// <summary>Create a socket to provide the service for Plug widget.</summary>
   /// <param name="svcname">The name of the service to be advertised. Ensure that it is unique (when combined with <c>svcnum</c>) otherwise creation may fail.</param>
   /// <param name="svcnum">A number (any value, 0 being the common default) to differentiate multiple instances of services with the same name.</param>
   /// <param name="svcsys">A boolean which when true specifies the creation of a system-wide service to which all users can connect, otherwise the service is private to the user id that created it.</param>
   /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
   virtual public bool SocketListen(  System.String svcname,   int svcnum,  bool svcsys) {
                                                             var _ret_var = efl_ui_win_socket_listen((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  svcname,  svcnum,  svcsys);
      Eina.Error.RaiseIfUnhandledException();
                                          return _ret_var;
 }
}
public class WinSocketNativeInherit : Efl.Ui.WinNativeInherit{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_ui_win_socket_listen_static_delegate = new efl_ui_win_socket_listen_delegate(socket_listen);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_win_socket_listen"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_socket_listen_static_delegate)});
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


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_win_socket_listen_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String svcname,    int svcnum,  [MarshalAs(UnmanagedType.U1)]  bool svcsys);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_win_socket_listen(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String svcname,    int svcnum,  [MarshalAs(UnmanagedType.U1)]  bool svcsys);
    private static bool socket_listen(System.IntPtr obj, System.IntPtr pd,   System.String svcname,   int svcnum,  bool svcsys)
   {
      Eina.Log.Debug("function efl_ui_win_socket_listen was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
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
         return efl_ui_win_socket_listen(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  svcname,  svcnum,  svcsys);
      }
   }
   private efl_ui_win_socket_listen_delegate efl_ui_win_socket_listen_static_delegate;
}
} } 
