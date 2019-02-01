#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { namespace Model { 
/// <summary>Efl UI model connect interface</summary>
[ConnectConcreteNativeInherit]
public interface Connect : 
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>Connect property</summary>
/// <param name="name">Model name</param>
/// <param name="property">Property name</param>
/// <returns></returns>
 void DoConnect(  System.String name,   System.String property);
   }
/// <summary>Efl UI model connect interface</summary>
sealed public class ConnectConcrete : 

Connect
   
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (ConnectConcrete))
            return Efl.Ui.Model.ConnectConcreteNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   private  System.IntPtr handle;
   public Dictionary<String, IntPtr> cached_strings = new Dictionary<String, IntPtr>();
   public Dictionary<String, IntPtr> cached_stringshares = new Dictionary<String, IntPtr>();
   ///<summary>Pointer to the native instance.</summary>
   public System.IntPtr NativeHandle {
      get { return handle; }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] internal static extern System.IntPtr
      efl_ui_model_connect_interface_get();
   ///<summary>Constructs an instance from a native pointer.</summary>
   public ConnectConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~ConnectConcrete()
   {
      Dispose(false);
   }
   ///<summary>Releases the underlying native instance.</summary>
   void Dispose(bool disposing)
   {
      if (handle != System.IntPtr.Zero) {
         Efl.Eo.Globals.efl_unref(handle);
         handle = System.IntPtr.Zero;
      }
   }
   ///<summary>Releases the underlying native instance.</summary>
   public void Dispose()
   {
   Efl.Eo.Globals.free_dict_values(cached_strings);
   Efl.Eo.Globals.free_stringshare_values(cached_stringshares);
      Dispose(true);
      GC.SuppressFinalize(this);
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public static ConnectConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new ConnectConcrete(obj.NativeHandle);
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
    void register_event_proxies()
   {
   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_ui_model_connect(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String property);
   /// <summary>Connect property</summary>
   /// <param name="name">Model name</param>
   /// <param name="property">Property name</param>
   /// <returns></returns>
   public  void DoConnect(  System.String name,   System.String property) {
                                           efl_ui_model_connect(Efl.Ui.Model.ConnectConcrete.efl_ui_model_connect_interface_get(),  name,  property);
      Eina.Error.RaiseIfUnhandledException();
                               }
}
public class ConnectConcreteNativeInherit : Efl.Eo.NativeClass{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_ui_model_connect_static_delegate = new efl_ui_model_connect_delegate(connect);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_model_connect"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_model_connect_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Ui.Model.ConnectConcrete.efl_ui_model_connect_interface_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.Model.ConnectConcrete.efl_ui_model_connect_interface_get();
   }


    private delegate  void efl_ui_model_connect_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String property);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_ui_model_connect(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String property);
    private static  void connect(System.IntPtr obj, System.IntPtr pd,   System.String name,   System.String property)
   {
      Eina.Log.Debug("function efl_ui_model_connect was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((Connect)wrapper).DoConnect( name,  property);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_ui_model_connect(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  name,  property);
      }
   }
   private efl_ui_model_connect_delegate efl_ui_model_connect_static_delegate;
}
} } } 
