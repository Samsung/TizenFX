#define EFL_BETA
#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Layout {

/// <summary>APIs representing static data from a group in an edje file.
/// (Since EFL 1.22)</summary>
[Efl.Layout.GroupConcrete.NativeMethods]
[Efl.Eo.BindingEntity]
public interface IGroup : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>The minimum size specified -- as an EDC property -- for a given Edje object
/// This property retrieves the obj object&apos;s minimum size values, as declared in its EDC group definition. For instance, for an Edje object of minimum size 100x100 pixels: collections { group { name: &quot;a_group&quot;; min: 100 100; } }
/// 
/// Note: If the <c>min</c> EDC property was not declared for this object, this call will return 0x0.
/// 
/// Note: On failure, this function also return 0x0.
/// 
/// See also <see cref="Efl.Layout.IGroup.GetGroupSizeMax"/>.
/// (Since EFL 1.22)</summary>
/// <returns>The minimum size as set in EDC.</returns>
Eina.Size2D GetGroupSizeMin();
    /// <summary>The maximum size specified -- as an EDC property -- for a given Edje object
/// This property retrieves the object&apos;s maximum size values, as declared in its EDC group definition. For instance, for an Edje object of maximum size 100x100 pixels: collections { group { name: &quot;a_group&quot;; max: 100 100; } }
/// 
/// Note: If the <c>max</c> EDC property was not declared for the object, this call will return the maximum size a given Edje object may have, for each axis.
/// 
/// Note: On failure, this function will return 0x0.
/// 
/// See also <see cref="Efl.Layout.IGroup.GetGroupSizeMin"/>.
/// (Since EFL 1.22)</summary>
/// <returns>The maximum size as set in EDC.</returns>
Eina.Size2D GetGroupSizeMax();
    /// <summary>The EDC data field&apos;s value from a given Edje object&apos;s group.
/// This property represents an EDC data field&apos;s value, which is declared on the objects building EDC file, under its group. EDC data blocks are most commonly used to pass arbitrary parameters from an application&apos;s theme to its code.
/// 
/// EDC data fields always hold  strings as values, hence the return type of this function. Check the complete &quot;syntax reference&quot; for EDC files.
/// 
/// This is how a data item is defined in EDC: collections { group { name: &quot;a_group&quot;; data { item: &quot;key1&quot; &quot;value1&quot;; item: &quot;key2&quot; &quot;value2&quot;; } } }
/// 
/// Warning: Do not confuse this call with edje_file_data_get(), which queries for a global EDC data field on an EDC declaration file.
/// (Since EFL 1.22)</summary>
/// <param name="key">The data field&apos;s key string</param>
/// <returns>The data&apos;s value string.</returns>
System.String GetGroupData(System.String key);
    /// <summary>Returns <c>true</c> if the part exists in the EDC group.
/// (Since EFL 1.22)</summary>
/// <param name="part">The part name to check.</param>
/// <returns><c>true</c> if the part exists, <c>false</c> otherwise.</returns>
bool GetPartExist(System.String part);
                    /// <summary>The minimum size specified -- as an EDC property -- for a given Edje object
    /// This property retrieves the obj object&apos;s minimum size values, as declared in its EDC group definition. For instance, for an Edje object of minimum size 100x100 pixels: collections { group { name: &quot;a_group&quot;; min: 100 100; } }
    /// 
    /// Note: If the <c>min</c> EDC property was not declared for this object, this call will return 0x0.
    /// 
    /// Note: On failure, this function also return 0x0.
    /// 
    /// See also <see cref="Efl.Layout.IGroup.GetGroupSizeMax"/>.
    /// (Since EFL 1.22)</summary>
    /// <value>The minimum size as set in EDC.</value>
    Eina.Size2D GroupSizeMin {
        get;
    }
    /// <summary>The maximum size specified -- as an EDC property -- for a given Edje object
    /// This property retrieves the object&apos;s maximum size values, as declared in its EDC group definition. For instance, for an Edje object of maximum size 100x100 pixels: collections { group { name: &quot;a_group&quot;; max: 100 100; } }
    /// 
    /// Note: If the <c>max</c> EDC property was not declared for the object, this call will return the maximum size a given Edje object may have, for each axis.
    /// 
    /// Note: On failure, this function will return 0x0.
    /// 
    /// See also <see cref="Efl.Layout.IGroup.GetGroupSizeMin"/>.
    /// (Since EFL 1.22)</summary>
    /// <value>The maximum size as set in EDC.</value>
    Eina.Size2D GroupSizeMax {
        get;
    }
}
/// <summary>APIs representing static data from a group in an edje file.
/// (Since EFL 1.22)</summary>
public sealed class GroupConcrete :
    Efl.Eo.EoWrapper
    , IGroup
    
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(GroupConcrete))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    private GroupConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Edje)] internal static extern System.IntPtr
        efl_layout_group_interface_get();
    /// <summary>Initializes a new instance of the <see cref="IGroup"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private GroupConcrete(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

#pragma warning disable CS0628
    /// <summary>The minimum size specified -- as an EDC property -- for a given Edje object
    /// This property retrieves the obj object&apos;s minimum size values, as declared in its EDC group definition. For instance, for an Edje object of minimum size 100x100 pixels: collections { group { name: &quot;a_group&quot;; min: 100 100; } }
    /// 
    /// Note: If the <c>min</c> EDC property was not declared for this object, this call will return 0x0.
    /// 
    /// Note: On failure, this function also return 0x0.
    /// 
    /// See also <see cref="Efl.Layout.IGroup.GetGroupSizeMax"/>.
    /// (Since EFL 1.22)</summary>
    /// <returns>The minimum size as set in EDC.</returns>
    public Eina.Size2D GetGroupSizeMin() {
         var _ret_var = Efl.Layout.GroupConcrete.NativeMethods.efl_layout_group_size_min_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The maximum size specified -- as an EDC property -- for a given Edje object
    /// This property retrieves the object&apos;s maximum size values, as declared in its EDC group definition. For instance, for an Edje object of maximum size 100x100 pixels: collections { group { name: &quot;a_group&quot;; max: 100 100; } }
    /// 
    /// Note: If the <c>max</c> EDC property was not declared for the object, this call will return the maximum size a given Edje object may have, for each axis.
    /// 
    /// Note: On failure, this function will return 0x0.
    /// 
    /// See also <see cref="Efl.Layout.IGroup.GetGroupSizeMin"/>.
    /// (Since EFL 1.22)</summary>
    /// <returns>The maximum size as set in EDC.</returns>
    public Eina.Size2D GetGroupSizeMax() {
         var _ret_var = Efl.Layout.GroupConcrete.NativeMethods.efl_layout_group_size_max_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The EDC data field&apos;s value from a given Edje object&apos;s group.
    /// This property represents an EDC data field&apos;s value, which is declared on the objects building EDC file, under its group. EDC data blocks are most commonly used to pass arbitrary parameters from an application&apos;s theme to its code.
    /// 
    /// EDC data fields always hold  strings as values, hence the return type of this function. Check the complete &quot;syntax reference&quot; for EDC files.
    /// 
    /// This is how a data item is defined in EDC: collections { group { name: &quot;a_group&quot;; data { item: &quot;key1&quot; &quot;value1&quot;; item: &quot;key2&quot; &quot;value2&quot;; } } }
    /// 
    /// Warning: Do not confuse this call with edje_file_data_get(), which queries for a global EDC data field on an EDC declaration file.
    /// (Since EFL 1.22)</summary>
    /// <param name="key">The data field&apos;s key string</param>
    /// <returns>The data&apos;s value string.</returns>
    public System.String GetGroupData(System.String key) {
                                 var _ret_var = Efl.Layout.GroupConcrete.NativeMethods.efl_layout_group_data_get_ptr.Value.Delegate(this.NativeHandle,key);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Returns <c>true</c> if the part exists in the EDC group.
    /// (Since EFL 1.22)</summary>
    /// <param name="part">The part name to check.</param>
    /// <returns><c>true</c> if the part exists, <c>false</c> otherwise.</returns>
    public bool GetPartExist(System.String part) {
                                 var _ret_var = Efl.Layout.GroupConcrete.NativeMethods.efl_layout_group_part_exist_get_ptr.Value.Delegate(this.NativeHandle,part);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>The minimum size specified -- as an EDC property -- for a given Edje object
    /// This property retrieves the obj object&apos;s minimum size values, as declared in its EDC group definition. For instance, for an Edje object of minimum size 100x100 pixels: collections { group { name: &quot;a_group&quot;; min: 100 100; } }
    /// 
    /// Note: If the <c>min</c> EDC property was not declared for this object, this call will return 0x0.
    /// 
    /// Note: On failure, this function also return 0x0.
    /// 
    /// See also <see cref="Efl.Layout.IGroup.GetGroupSizeMax"/>.
    /// (Since EFL 1.22)</summary>
    /// <value>The minimum size as set in EDC.</value>
    public Eina.Size2D GroupSizeMin {
        get { return GetGroupSizeMin(); }
    }
    /// <summary>The maximum size specified -- as an EDC property -- for a given Edje object
    /// This property retrieves the object&apos;s maximum size values, as declared in its EDC group definition. For instance, for an Edje object of maximum size 100x100 pixels: collections { group { name: &quot;a_group&quot;; max: 100 100; } }
    /// 
    /// Note: If the <c>max</c> EDC property was not declared for the object, this call will return the maximum size a given Edje object may have, for each axis.
    /// 
    /// Note: On failure, this function will return 0x0.
    /// 
    /// See also <see cref="Efl.Layout.IGroup.GetGroupSizeMin"/>.
    /// (Since EFL 1.22)</summary>
    /// <value>The maximum size as set in EDC.</value>
    public Eina.Size2D GroupSizeMax {
        get { return GetGroupSizeMax(); }
    }
#pragma warning restore CS0628
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Layout.GroupConcrete.efl_layout_group_interface_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Eo.EoWrapper.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Edje);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_layout_group_size_min_get_static_delegate == null)
            {
                efl_layout_group_size_min_get_static_delegate = new efl_layout_group_size_min_get_delegate(group_size_min_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetGroupSizeMin") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_layout_group_size_min_get"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_group_size_min_get_static_delegate) });
            }

            if (efl_layout_group_size_max_get_static_delegate == null)
            {
                efl_layout_group_size_max_get_static_delegate = new efl_layout_group_size_max_get_delegate(group_size_max_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetGroupSizeMax") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_layout_group_size_max_get"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_group_size_max_get_static_delegate) });
            }

            if (efl_layout_group_data_get_static_delegate == null)
            {
                efl_layout_group_data_get_static_delegate = new efl_layout_group_data_get_delegate(group_data_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetGroupData") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_layout_group_data_get"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_group_data_get_static_delegate) });
            }

            if (efl_layout_group_part_exist_get_static_delegate == null)
            {
                efl_layout_group_part_exist_get_static_delegate = new efl_layout_group_part_exist_get_delegate(part_exist_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetPartExist") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_layout_group_part_exist_get"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_group_part_exist_get_static_delegate) });
            }

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
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Layout.GroupConcrete.efl_layout_group_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate Eina.Size2D.NativeStruct efl_layout_group_size_min_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Size2D.NativeStruct efl_layout_group_size_min_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_layout_group_size_min_get_api_delegate> efl_layout_group_size_min_get_ptr = new Efl.Eo.FunctionWrapper<efl_layout_group_size_min_get_api_delegate>(Module, "efl_layout_group_size_min_get");

        private static Eina.Size2D.NativeStruct group_size_min_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_layout_group_size_min_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Size2D _ret_var = default(Eina.Size2D);
                try
                {
                    _ret_var = ((IGroup)ws.Target).GetGroupSizeMin();
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
                return efl_layout_group_size_min_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_layout_group_size_min_get_delegate efl_layout_group_size_min_get_static_delegate;

        
        private delegate Eina.Size2D.NativeStruct efl_layout_group_size_max_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Size2D.NativeStruct efl_layout_group_size_max_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_layout_group_size_max_get_api_delegate> efl_layout_group_size_max_get_ptr = new Efl.Eo.FunctionWrapper<efl_layout_group_size_max_get_api_delegate>(Module, "efl_layout_group_size_max_get");

        private static Eina.Size2D.NativeStruct group_size_max_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_layout_group_size_max_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Size2D _ret_var = default(Eina.Size2D);
                try
                {
                    _ret_var = ((IGroup)ws.Target).GetGroupSizeMax();
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
                return efl_layout_group_size_max_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_layout_group_size_max_get_delegate efl_layout_group_size_max_get_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_layout_group_data_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String key);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_layout_group_data_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String key);

        public static Efl.Eo.FunctionWrapper<efl_layout_group_data_get_api_delegate> efl_layout_group_data_get_ptr = new Efl.Eo.FunctionWrapper<efl_layout_group_data_get_api_delegate>(Module, "efl_layout_group_data_get");

        private static System.String group_data_get(System.IntPtr obj, System.IntPtr pd, System.String key)
        {
            Eina.Log.Debug("function efl_layout_group_data_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((IGroup)ws.Target).GetGroupData(key);
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
                return efl_layout_group_data_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), key);
            }
        }

        private static efl_layout_group_data_get_delegate efl_layout_group_data_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_layout_group_part_exist_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String part);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_layout_group_part_exist_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String part);

        public static Efl.Eo.FunctionWrapper<efl_layout_group_part_exist_get_api_delegate> efl_layout_group_part_exist_get_ptr = new Efl.Eo.FunctionWrapper<efl_layout_group_part_exist_get_api_delegate>(Module, "efl_layout_group_part_exist_get");

        private static bool part_exist_get(System.IntPtr obj, System.IntPtr pd, System.String part)
        {
            Eina.Log.Debug("function efl_layout_group_part_exist_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IGroup)ws.Target).GetPartExist(part);
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
                return efl_layout_group_part_exist_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), part);
            }
        }

        private static efl_layout_group_part_exist_get_delegate efl_layout_group_part_exist_get_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_LayoutGroupConcrete_ExtensionMethods {
    
    
    
    
}
#pragma warning restore CS1591
#endif
