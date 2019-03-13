#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary>Efl UI Property_Bind interface. view object can have <see cref="Efl.Model"/> to manage the data, the interface can help loading and tracking child data from the model property. see <see cref="Efl.Model"/> see <see cref="Efl.Ui.Factory"/></summary>
[PropertyBindNativeInherit]
public interface PropertyBind : 
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>bind property data with the given key string. when the data is ready or changed, bind the data to the key action and process promised work.</summary>
/// <param name="key">key string for bind model property data</param>
/// <param name="property">Model property name</param>
/// <returns></returns>
 void PropertyBind(  System.String key,   System.String property);
   }
/// <summary>Efl UI Property_Bind interface. view object can have <see cref="Efl.Model"/> to manage the data, the interface can help loading and tracking child data from the model property. see <see cref="Efl.Model"/> see <see cref="Efl.Ui.Factory"/></summary>
sealed public class PropertyBindConcrete : 

PropertyBind
   
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (PropertyBindConcrete))
            return Efl.Ui.PropertyBindNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
      }
   }
   private  System.IntPtr handle;
   ///<summary>Pointer to the native instance.</summary>
   public System.IntPtr NativeHandle {
      get { return handle; }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] internal static extern System.IntPtr
      efl_ui_property_bind_interface_get();
   ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
   public PropertyBindConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~PropertyBindConcrete()
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
      Dispose(true);
      GC.SuppressFinalize(this);
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public static PropertyBindConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new PropertyBindConcrete(obj.NativeHandle);
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
   /// <summary>bind property data with the given key string. when the data is ready or changed, bind the data to the key action and process promised work.</summary>
   /// <param name="key">key string for bind model property data</param>
   /// <param name="property">Model property name</param>
   /// <returns></returns>
   public  void PropertyBind(  System.String key,   System.String property) {
                                           Efl.Ui.PropertyBindNativeInherit.efl_ui_property_bind_ptr.Value.Delegate(this.NativeHandle, key,  property);
      Eina.Error.RaiseIfUnhandledException();
                               }
}
public class PropertyBindNativeInherit  : Efl.Eo.NativeClass{
   public  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Efl);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      if (efl_ui_property_bind_static_delegate == null)
      efl_ui_property_bind_static_delegate = new efl_ui_property_bind_delegate(property_bind);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_property_bind"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_property_bind_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Ui.PropertyBindConcrete.efl_ui_property_bind_interface_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.PropertyBindConcrete.efl_ui_property_bind_interface_get();
   }


    private delegate  void efl_ui_property_bind_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String property);


    public delegate  void efl_ui_property_bind_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String property);
    public static Efl.Eo.FunctionWrapper<efl_ui_property_bind_api_delegate> efl_ui_property_bind_ptr = new Efl.Eo.FunctionWrapper<efl_ui_property_bind_api_delegate>(_Module, "efl_ui_property_bind");
    private static  void property_bind(System.IntPtr obj, System.IntPtr pd,   System.String key,   System.String property)
   {
      Eina.Log.Debug("function efl_ui_property_bind was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((PropertyBind)wrapper).PropertyBind( key,  property);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_ui_property_bind_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  key,  property);
      }
   }
   private static efl_ui_property_bind_delegate efl_ui_property_bind_static_delegate;
}
} } 
