#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { 
/// <summary>Low-level APIs for object that can lay their children out.
/// Used for containers (box, grid).</summary>
[PackLayoutConcreteNativeInherit]
public interface PackLayout : 
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>Requests EFL to call the <see cref="Efl.PackLayout.UpdateLayout"/> method on this object.
/// This <see cref="Efl.PackLayout.UpdateLayout"/> may be called asynchronously.</summary>
/// <returns></returns>
 void LayoutRequest();
   /// <summary>Implementation of this container&apos;s layout algorithm.
/// EFL will call this function whenever the contents of this container need to be re-layed out on the canvas.
/// 
/// This can be overriden to implement custom layout behaviours.</summary>
/// <returns></returns>
 void UpdateLayout();
      }
/// <summary>Low-level APIs for object that can lay their children out.
/// Used for containers (box, grid).</summary>
sealed public class PackLayoutConcrete : 

PackLayout
   
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (PackLayoutConcrete))
            return Efl.PackLayoutConcreteNativeInherit.GetEflClassStatic();
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
      efl_pack_layout_interface_get();
   ///<summary>Constructs an instance from a native pointer.</summary>
   public PackLayoutConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~PackLayoutConcrete()
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
   public static PackLayoutConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new PackLayoutConcrete(obj.NativeHandle);
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
    private static extern  void efl_pack_layout_request(System.IntPtr obj);
   /// <summary>Requests EFL to call the <see cref="Efl.PackLayout.UpdateLayout"/> method on this object.
   /// This <see cref="Efl.PackLayout.UpdateLayout"/> may be called asynchronously.</summary>
   /// <returns></returns>
   public  void LayoutRequest() {
       efl_pack_layout_request(Efl.PackLayoutConcrete.efl_pack_layout_interface_get());
      Eina.Error.RaiseIfUnhandledException();
       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_pack_layout_update(System.IntPtr obj);
   /// <summary>Implementation of this container&apos;s layout algorithm.
   /// EFL will call this function whenever the contents of this container need to be re-layed out on the canvas.
   /// 
   /// This can be overriden to implement custom layout behaviours.</summary>
   /// <returns></returns>
   public  void UpdateLayout() {
       efl_pack_layout_update(Efl.PackLayoutConcrete.efl_pack_layout_interface_get());
      Eina.Error.RaiseIfUnhandledException();
       }
}
public class PackLayoutConcreteNativeInherit : Efl.Eo.NativeClass{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_pack_layout_request_static_delegate = new efl_pack_layout_request_delegate(layout_request);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_pack_layout_request"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_layout_request_static_delegate)});
      efl_pack_layout_update_static_delegate = new efl_pack_layout_update_delegate(layout_update);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_pack_layout_update"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_layout_update_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.PackLayoutConcrete.efl_pack_layout_interface_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.PackLayoutConcrete.efl_pack_layout_interface_get();
   }


    private delegate  void efl_pack_layout_request_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_pack_layout_request(System.IntPtr obj);
    private static  void layout_request(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_pack_layout_request was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((PackLayout)wrapper).LayoutRequest();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_pack_layout_request(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_pack_layout_request_delegate efl_pack_layout_request_static_delegate;


    private delegate  void efl_pack_layout_update_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_pack_layout_update(System.IntPtr obj);
    private static  void layout_update(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_pack_layout_update was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((PackLayout)wrapper).UpdateLayout();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_pack_layout_update(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_pack_layout_update_delegate efl_pack_layout_update_static_delegate;
}
} 
