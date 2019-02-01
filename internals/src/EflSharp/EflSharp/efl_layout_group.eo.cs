#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Layout { 
/// <summary>APIs representing static data from a group in an edje file.
/// 1.21</summary>
[GroupConcreteNativeInherit]
public interface Group : 
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>Gets the minimum size specified -- as an EDC property -- for a given Edje object
/// This function retrieves the obj object&apos;s minimum size values, as declared in its EDC group definition. For instance, for an Edje object of minimum size 100x100 pixels: collections { group { name: &quot;a_group&quot;; min: 100 100; } }
/// 
/// Note: If the <c>min</c> EDC property was not declared for this object, this call will return 0x0.
/// 
/// Note: On failure, this function also return 0x0.
/// 
/// See also <see cref="Efl.Layout.Group.GetGroupSizeMax"/>.
/// 1.21</summary>
/// <returns>The minimum size as set in EDC.
/// 1.21</returns>
Eina.Size2D GetGroupSizeMin();
   /// <summary>Gets the maximum size specified -- as an EDC property -- for a given Edje object
/// This function retrieves the object&apos;s maximum size values, as declared in its EDC group definition. For instance, for an Edje object of maximum size 100x100 pixels: collections { group { name: &quot;a_group&quot;; max: 100 100; } }
/// 
/// Note: If the <c>max</c> EDC property was not declared for the object, this call will return the maximum size a given Edje object may have, for each axis.
/// 
/// Note: On failure, this function will return 0x0.
/// 
/// See also <see cref="Efl.Layout.Group.GetGroupSizeMin"/>.
/// 1.21</summary>
/// <returns>The maximum size as set in EDC.
/// 1.21</returns>
Eina.Size2D GetGroupSizeMax();
   /// <summary>Retrives an EDC data field&apos;s value from a given Edje object&apos;s group.
/// This function fetches an EDC data field&apos;s value, which is declared on the objects building EDC file, under its group. EDC data blocks are most commonly used to pass arbitrary parameters from an application&apos;s theme to its code.
/// 
/// EDC data fields always hold  strings as values, hence the return type of this function. Check the complete &quot;syntax reference&quot; for EDC files.
/// 
/// This is how a data item is defined in EDC: collections { group { name: &quot;a_group&quot;; data { item: &quot;key1&quot; &quot;value1&quot;; item: &quot;key2&quot; &quot;value2&quot;; } } }
/// 
/// Warning: Do not confuse this call with edje_file_data_get(), which queries for a global EDC data field on an EDC declaration file.
/// 1.21</summary>
/// <param name="key">The data field&apos;s key string
/// 1.21</param>
/// <returns>The data&apos;s value string.
/// 1.21</returns>
 System.String GetGroupData(  System.String key);
   /// <summary>Returns <c>true</c> if the part exists in the EDC group.
/// 1.21</summary>
/// <param name="part">The part name to check.
/// 1.21</param>
/// <returns><c>true</c> if the part exists, <c>false</c> otherwise.
/// 1.21</returns>
bool GetPartExist(  System.String part);
               /// <summary>Gets the minimum size specified -- as an EDC property -- for a given Edje object
/// This function retrieves the obj object&apos;s minimum size values, as declared in its EDC group definition. For instance, for an Edje object of minimum size 100x100 pixels: collections { group { name: &quot;a_group&quot;; min: 100 100; } }
/// 
/// Note: If the <c>min</c> EDC property was not declared for this object, this call will return 0x0.
/// 
/// Note: On failure, this function also return 0x0.
/// 
/// See also <see cref="Efl.Layout.Group.GetGroupSizeMax"/>.
/// 1.21</summary>
   Eina.Size2D GroupSizeMin {
      get ;
   }
   /// <summary>Gets the maximum size specified -- as an EDC property -- for a given Edje object
/// This function retrieves the object&apos;s maximum size values, as declared in its EDC group definition. For instance, for an Edje object of maximum size 100x100 pixels: collections { group { name: &quot;a_group&quot;; max: 100 100; } }
/// 
/// Note: If the <c>max</c> EDC property was not declared for the object, this call will return the maximum size a given Edje object may have, for each axis.
/// 
/// Note: On failure, this function will return 0x0.
/// 
/// See also <see cref="Efl.Layout.Group.GetGroupSizeMin"/>.
/// 1.21</summary>
   Eina.Size2D GroupSizeMax {
      get ;
   }
}
/// <summary>APIs representing static data from a group in an edje file.
/// 1.21</summary>
sealed public class GroupConcrete : 

Group
   
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (GroupConcrete))
            return Efl.Layout.GroupConcreteNativeInherit.GetEflClassStatic();
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
   [System.Runtime.InteropServices.DllImport(efl.Libs.Edje)] internal static extern System.IntPtr
      efl_layout_group_interface_get();
   ///<summary>Constructs an instance from a native pointer.</summary>
   public GroupConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~GroupConcrete()
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
   public static GroupConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new GroupConcrete(obj.NativeHandle);
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


   [System.Runtime.InteropServices.DllImport(efl.Libs.Edje)]
    private static extern Eina.Size2D_StructInternal efl_layout_group_size_min_get(System.IntPtr obj);
   /// <summary>Gets the minimum size specified -- as an EDC property -- for a given Edje object
   /// This function retrieves the obj object&apos;s minimum size values, as declared in its EDC group definition. For instance, for an Edje object of minimum size 100x100 pixels: collections { group { name: &quot;a_group&quot;; min: 100 100; } }
   /// 
   /// Note: If the <c>min</c> EDC property was not declared for this object, this call will return 0x0.
   /// 
   /// Note: On failure, this function also return 0x0.
   /// 
   /// See also <see cref="Efl.Layout.Group.GetGroupSizeMax"/>.
   /// 1.21</summary>
   /// <returns>The minimum size as set in EDC.
   /// 1.21</returns>
   public Eina.Size2D GetGroupSizeMin() {
       var _ret_var = efl_layout_group_size_min_get(Efl.Layout.GroupConcrete.efl_layout_group_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return Eina.Size2D_StructConversion.ToManaged(_ret_var);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Edje)]
    private static extern Eina.Size2D_StructInternal efl_layout_group_size_max_get(System.IntPtr obj);
   /// <summary>Gets the maximum size specified -- as an EDC property -- for a given Edje object
   /// This function retrieves the object&apos;s maximum size values, as declared in its EDC group definition. For instance, for an Edje object of maximum size 100x100 pixels: collections { group { name: &quot;a_group&quot;; max: 100 100; } }
   /// 
   /// Note: If the <c>max</c> EDC property was not declared for the object, this call will return the maximum size a given Edje object may have, for each axis.
   /// 
   /// Note: On failure, this function will return 0x0.
   /// 
   /// See also <see cref="Efl.Layout.Group.GetGroupSizeMin"/>.
   /// 1.21</summary>
   /// <returns>The maximum size as set in EDC.
   /// 1.21</returns>
   public Eina.Size2D GetGroupSizeMax() {
       var _ret_var = efl_layout_group_size_max_get(Efl.Layout.GroupConcrete.efl_layout_group_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return Eina.Size2D_StructConversion.ToManaged(_ret_var);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Edje)]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private static extern  System.String efl_layout_group_data_get(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key);
   /// <summary>Retrives an EDC data field&apos;s value from a given Edje object&apos;s group.
   /// This function fetches an EDC data field&apos;s value, which is declared on the objects building EDC file, under its group. EDC data blocks are most commonly used to pass arbitrary parameters from an application&apos;s theme to its code.
   /// 
   /// EDC data fields always hold  strings as values, hence the return type of this function. Check the complete &quot;syntax reference&quot; for EDC files.
   /// 
   /// This is how a data item is defined in EDC: collections { group { name: &quot;a_group&quot;; data { item: &quot;key1&quot; &quot;value1&quot;; item: &quot;key2&quot; &quot;value2&quot;; } } }
   /// 
   /// Warning: Do not confuse this call with edje_file_data_get(), which queries for a global EDC data field on an EDC declaration file.
   /// 1.21</summary>
   /// <param name="key">The data field&apos;s key string
   /// 1.21</param>
   /// <returns>The data&apos;s value string.
   /// 1.21</returns>
   public  System.String GetGroupData(  System.String key) {
                         var _ret_var = efl_layout_group_data_get(Efl.Layout.GroupConcrete.efl_layout_group_interface_get(),  key);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Edje)]
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_layout_group_part_exist_get(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String part);
   /// <summary>Returns <c>true</c> if the part exists in the EDC group.
   /// 1.21</summary>
   /// <param name="part">The part name to check.
   /// 1.21</param>
   /// <returns><c>true</c> if the part exists, <c>false</c> otherwise.
   /// 1.21</returns>
   public bool GetPartExist(  System.String part) {
                         var _ret_var = efl_layout_group_part_exist_get(Efl.Layout.GroupConcrete.efl_layout_group_interface_get(),  part);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Gets the minimum size specified -- as an EDC property -- for a given Edje object
/// This function retrieves the obj object&apos;s minimum size values, as declared in its EDC group definition. For instance, for an Edje object of minimum size 100x100 pixels: collections { group { name: &quot;a_group&quot;; min: 100 100; } }
/// 
/// Note: If the <c>min</c> EDC property was not declared for this object, this call will return 0x0.
/// 
/// Note: On failure, this function also return 0x0.
/// 
/// See also <see cref="Efl.Layout.Group.GetGroupSizeMax"/>.
/// 1.21</summary>
   public Eina.Size2D GroupSizeMin {
      get { return GetGroupSizeMin(); }
   }
   /// <summary>Gets the maximum size specified -- as an EDC property -- for a given Edje object
/// This function retrieves the object&apos;s maximum size values, as declared in its EDC group definition. For instance, for an Edje object of maximum size 100x100 pixels: collections { group { name: &quot;a_group&quot;; max: 100 100; } }
/// 
/// Note: If the <c>max</c> EDC property was not declared for the object, this call will return the maximum size a given Edje object may have, for each axis.
/// 
/// Note: On failure, this function will return 0x0.
/// 
/// See also <see cref="Efl.Layout.Group.GetGroupSizeMin"/>.
/// 1.21</summary>
   public Eina.Size2D GroupSizeMax {
      get { return GetGroupSizeMax(); }
   }
}
public class GroupConcreteNativeInherit : Efl.Eo.NativeClass{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_layout_group_size_min_get_static_delegate = new efl_layout_group_size_min_get_delegate(group_size_min_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_layout_group_size_min_get"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_group_size_min_get_static_delegate)});
      efl_layout_group_size_max_get_static_delegate = new efl_layout_group_size_max_get_delegate(group_size_max_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_layout_group_size_max_get"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_group_size_max_get_static_delegate)});
      efl_layout_group_data_get_static_delegate = new efl_layout_group_data_get_delegate(group_data_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_layout_group_data_get"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_group_data_get_static_delegate)});
      efl_layout_group_part_exist_get_static_delegate = new efl_layout_group_part_exist_get_delegate(part_exist_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_layout_group_part_exist_get"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_group_part_exist_get_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Layout.GroupConcrete.efl_layout_group_interface_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.Layout.GroupConcrete.efl_layout_group_interface_get();
   }


    private delegate Eina.Size2D_StructInternal efl_layout_group_size_min_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Edje)]  private static extern Eina.Size2D_StructInternal efl_layout_group_size_min_get(System.IntPtr obj);
    private static Eina.Size2D_StructInternal group_size_min_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_layout_group_size_min_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Size2D _ret_var = default(Eina.Size2D);
         try {
            _ret_var = ((Group)wrapper).GetGroupSizeMin();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Eina.Size2D_StructConversion.ToInternal(_ret_var);
      } else {
         return efl_layout_group_size_min_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_layout_group_size_min_get_delegate efl_layout_group_size_min_get_static_delegate;


    private delegate Eina.Size2D_StructInternal efl_layout_group_size_max_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Edje)]  private static extern Eina.Size2D_StructInternal efl_layout_group_size_max_get(System.IntPtr obj);
    private static Eina.Size2D_StructInternal group_size_max_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_layout_group_size_max_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Size2D _ret_var = default(Eina.Size2D);
         try {
            _ret_var = ((Group)wrapper).GetGroupSizeMax();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Eina.Size2D_StructConversion.ToInternal(_ret_var);
      } else {
         return efl_layout_group_size_max_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_layout_group_size_max_get_delegate efl_layout_group_size_max_get_static_delegate;


    private delegate  System.IntPtr efl_layout_group_data_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Edje)]  private static extern  System.IntPtr efl_layout_group_data_get(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key);
    private static  System.IntPtr group_data_get(System.IntPtr obj, System.IntPtr pd,   System.String key)
   {
      Eina.Log.Debug("function efl_layout_group_data_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                     System.String _ret_var = default( System.String);
         try {
            _ret_var = ((Group)wrapper).GetGroupData( key);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return Efl.Eo.Globals.cached_string_to_intptr(((GroupConcrete)wrapper).cached_strings, _ret_var);
      } else {
         return efl_layout_group_data_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  key);
      }
   }
   private efl_layout_group_data_get_delegate efl_layout_group_data_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_layout_group_part_exist_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String part);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Edje)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_layout_group_part_exist_get(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String part);
    private static bool part_exist_get(System.IntPtr obj, System.IntPtr pd,   System.String part)
   {
      Eina.Log.Debug("function efl_layout_group_part_exist_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((Group)wrapper).GetPartExist( part);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_layout_group_part_exist_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  part);
      }
   }
   private efl_layout_group_part_exist_get_delegate efl_layout_group_part_exist_get_static_delegate;
}
} } 
