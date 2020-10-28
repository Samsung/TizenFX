#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { 
/// <summary>This class is a singleton representing the global configuration for the running application.</summary>
[ConfigGlobalNativeInherit]
public class ConfigGlobal : Efl.Object, Efl.Eo.IWrapper,Efl.IConfig
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (ConfigGlobal))
                return Efl.ConfigGlobalNativeInherit.GetEflClassStatic();
            else
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
        }
    }
    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_config_global_class_get();
    ///<summary>Creates a new instance.</summary>
    ///<param name="parent">Parent instance.</param>
    public ConfigGlobal(Efl.Object parent= null
            ) :
        base(efl_config_global_class_get(), typeof(ConfigGlobal), parent)
    {
        FinishInstantiation();
    }
    ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    protected ConfigGlobal(System.IntPtr raw) : base(raw)
    {
                RegisterEventProxies();
    }
    ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    protected ConfigGlobal(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
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
    /// <summary>The profile for the running application.
    /// Profiles are pre-set options that affect the whole look-and-feel of Elementary-based applications. There are, for example, profiles aimed at desktop computer applications and others aimed at mobile, touchscreen-based ones. You most probably don&apos;t want to use the functions in this group unless you&apos;re writing an elementary configuration manager.
    /// 
    /// This gets or sets the global profile that is applied to all Elementary applications.</summary>
    /// <returns>Profile name</returns>
    virtual public System.String GetProfile() {
         var _ret_var = Efl.ConfigGlobalNativeInherit.efl_config_profile_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The profile for the running application.
    /// Profiles are pre-set options that affect the whole look-and-feel of Elementary-based applications. There are, for example, profiles aimed at desktop computer applications and others aimed at mobile, touchscreen-based ones. You most probably don&apos;t want to use the functions in this group unless you&apos;re writing an elementary configuration manager.
    /// 
    /// This gets or sets the global profile that is applied to all Elementary applications.</summary>
    /// <param name="profile">Profile name</param>
    /// <returns></returns>
    virtual public void SetProfile( System.String profile) {
                                 Efl.ConfigGlobalNativeInherit.efl_config_profile_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), profile);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Saves Elementary configuration to disk.
    /// This function will take effect (does I/O) immediately. Use it when you want to save all configuration changes at once. The current configuration set will get saved onto the current profile configuration file.
    /// 
    /// If <c>profile</c> is <c>null</c>, this will flush all settings to all applications running on the same profile.
    /// 
    /// If <c>profile</c> is not <c>null</c>, this will take the current in-memory config and write it out to the named <c>profile</c>. This will not change profile for the application or make other processes switch profile.</summary>
    /// <param name="profile">The profile name.</param>
    /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
    virtual public bool Save( System.String profile) {
                                 var _ret_var = Efl.ConfigGlobalNativeInherit.efl_config_save_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), profile);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Returns the list of available profiles.</summary>
    /// <param name="hidden">If <c>true</c>, gets the full list of profiles, including those stored in hidden files.</param>
    /// <returns>Iterator to profiles</returns>
    virtual public Eina.Iterator<System.String> ProfileIterate( bool hidden) {
                                 var _ret_var = Efl.ConfigGlobalNativeInherit.efl_config_profile_iterate_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), hidden);
        Eina.Error.RaiseIfUnhandledException();
                        return new Eina.Iterator<System.String>(_ret_var, true, false);
 }
    /// <summary>Returns whether a profile exists or not.</summary>
    /// <param name="profile">Profile name</param>
    /// <returns><c>true</c> if profile exists, <c>false</c> otherwise</returns>
    virtual public bool ProfileExists( System.String profile) {
                                 var _ret_var = Efl.ConfigGlobalNativeInherit.efl_config_profile_exists_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), profile);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Returns the directory where a profile is stored.</summary>
    /// <param name="profile">Profile name</param>
    /// <param name="is_user"><c>true</c> to lookup for a user profile or <c>false</c> for a system one.</param>
    /// <returns>Directory of the profile, free after use.</returns>
    virtual public System.String GetProfileDir( System.String profile,  bool is_user) {
                                                         var _ret_var = Efl.ConfigGlobalNativeInherit.efl_config_profile_dir_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), profile,  is_user);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Add a new profile of the given name to be derived from the current profile.
    /// This creates a new profile of name <c>profile</c> that will be derived from the currently used profile using the modification commands encoded in the <c>options</c> string.
    /// 
    /// At this point it is not expected that anyone would generally use this API except if you are a desktop environment and so the user base of this API will be enlightenment itself.</summary>
    /// <param name="profile">The new profile&apos;s name.</param>
    /// <param name="options">Derive options detailing how to modify.</param>
    /// <returns></returns>
    virtual public void AddProfileDerived( System.String profile,  System.String options) {
                                                         Efl.ConfigGlobalNativeInherit.efl_config_profile_derived_add_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), profile,  options);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Deletes a profile that is derived from the current one.
    /// This deletes a derived profile added by <see cref="Efl.ConfigGlobal.AddProfileDerived"/>. This will delete the profile of the given name <c>profile</c> that is derived from the current profile.
    /// 
    /// At this point it is not expected that anyone would generally use this API except if you are a desktop environment and so the user base of this API will be enlightenment itself.</summary>
    /// <param name="profile">The name of the profile that is to be deleted.</param>
    /// <returns></returns>
    virtual public void DelProfileDerived( System.String profile) {
                                 Efl.ConfigGlobalNativeInherit.efl_config_profile_derived_del_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), profile);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>A generic configuration value, referred to by name.</summary>
    /// <param name="name">Configuration option name.</param>
    /// <returns>The value. It will be empty if it doesn&apos;t exist. The caller must free it after use (using <c>eina_value_free</c>() in C).</returns>
    virtual public Eina.Value GetConfig( System.String name) {
                                 var _ret_var = Efl.IConfigNativeInherit.efl_config_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), name);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>A generic configuration value, referred to by name.</summary>
    /// <param name="name">Configuration option name.</param>
    /// <param name="value">Configuration option value. May be <c>null</c> if not found.</param>
    /// <returns><c>false</c> in case of error: value type was invalid, the config can&apos;t be changed, config does not exist...</returns>
    virtual public bool SetConfig( System.String name,  Eina.Value value) {
                                                         var _ret_var = Efl.IConfigNativeInherit.efl_config_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), name,  value);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>The profile for the running application.
/// Profiles are pre-set options that affect the whole look-and-feel of Elementary-based applications. There are, for example, profiles aimed at desktop computer applications and others aimed at mobile, touchscreen-based ones. You most probably don&apos;t want to use the functions in this group unless you&apos;re writing an elementary configuration manager.
/// 
/// This gets or sets the global profile that is applied to all Elementary applications.</summary>
/// <value>Profile name</value>
    public System.String Profile {
        get { return GetProfile(); }
        set { SetProfile( value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.ConfigGlobal.efl_config_global_class_get();
    }
}
public class ConfigGlobalNativeInherit : Efl.ObjectNativeInherit{
    public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Elementary);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
        if (efl_config_profile_get_static_delegate == null)
            efl_config_profile_get_static_delegate = new efl_config_profile_get_delegate(profile_get);
        if (methods.FirstOrDefault(m => m.Name == "GetProfile") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_config_profile_get"), func = Marshal.GetFunctionPointerForDelegate(efl_config_profile_get_static_delegate)});
        if (efl_config_profile_set_static_delegate == null)
            efl_config_profile_set_static_delegate = new efl_config_profile_set_delegate(profile_set);
        if (methods.FirstOrDefault(m => m.Name == "SetProfile") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_config_profile_set"), func = Marshal.GetFunctionPointerForDelegate(efl_config_profile_set_static_delegate)});
        if (efl_config_save_static_delegate == null)
            efl_config_save_static_delegate = new efl_config_save_delegate(save);
        if (methods.FirstOrDefault(m => m.Name == "Save") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_config_save"), func = Marshal.GetFunctionPointerForDelegate(efl_config_save_static_delegate)});
        if (efl_config_profile_iterate_static_delegate == null)
            efl_config_profile_iterate_static_delegate = new efl_config_profile_iterate_delegate(profile_iterate);
        if (methods.FirstOrDefault(m => m.Name == "ProfileIterate") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_config_profile_iterate"), func = Marshal.GetFunctionPointerForDelegate(efl_config_profile_iterate_static_delegate)});
        if (efl_config_profile_exists_static_delegate == null)
            efl_config_profile_exists_static_delegate = new efl_config_profile_exists_delegate(profile_exists);
        if (methods.FirstOrDefault(m => m.Name == "ProfileExists") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_config_profile_exists"), func = Marshal.GetFunctionPointerForDelegate(efl_config_profile_exists_static_delegate)});
        if (efl_config_profile_dir_get_static_delegate == null)
            efl_config_profile_dir_get_static_delegate = new efl_config_profile_dir_get_delegate(profile_dir_get);
        if (methods.FirstOrDefault(m => m.Name == "GetProfileDir") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_config_profile_dir_get"), func = Marshal.GetFunctionPointerForDelegate(efl_config_profile_dir_get_static_delegate)});
        if (efl_config_profile_derived_add_static_delegate == null)
            efl_config_profile_derived_add_static_delegate = new efl_config_profile_derived_add_delegate(profile_derived_add);
        if (methods.FirstOrDefault(m => m.Name == "AddProfileDerived") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_config_profile_derived_add"), func = Marshal.GetFunctionPointerForDelegate(efl_config_profile_derived_add_static_delegate)});
        if (efl_config_profile_derived_del_static_delegate == null)
            efl_config_profile_derived_del_static_delegate = new efl_config_profile_derived_del_delegate(profile_derived_del);
        if (methods.FirstOrDefault(m => m.Name == "DelProfileDerived") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_config_profile_derived_del"), func = Marshal.GetFunctionPointerForDelegate(efl_config_profile_derived_del_static_delegate)});
        if (efl_config_get_static_delegate == null)
            efl_config_get_static_delegate = new efl_config_get_delegate(config_get);
        if (methods.FirstOrDefault(m => m.Name == "GetConfig") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_config_get"), func = Marshal.GetFunctionPointerForDelegate(efl_config_get_static_delegate)});
        if (efl_config_set_static_delegate == null)
            efl_config_set_static_delegate = new efl_config_set_delegate(config_set);
        if (methods.FirstOrDefault(m => m.Name == "SetConfig") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_config_set"), func = Marshal.GetFunctionPointerForDelegate(efl_config_set_static_delegate)});
        descs.AddRange(base.GetEoOps(type));
        return descs;
    }
    public override IntPtr GetEflClass()
    {
        return Efl.ConfigGlobal.efl_config_global_class_get();
    }
    public static new  IntPtr GetEflClassStatic()
    {
        return Efl.ConfigGlobal.efl_config_global_class_get();
    }


     [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate System.String efl_config_profile_get_delegate(System.IntPtr obj, System.IntPtr pd);


     [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate System.String efl_config_profile_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_config_profile_get_api_delegate> efl_config_profile_get_ptr = new Efl.Eo.FunctionWrapper<efl_config_profile_get_api_delegate>(_Module, "efl_config_profile_get");
     private static System.String profile_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_config_profile_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        System.String _ret_var = default(System.String);
            try {
                _ret_var = ((ConfigGlobal)wrapper).GetProfile();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_config_profile_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_config_profile_get_delegate efl_config_profile_get_static_delegate;


     private delegate void efl_config_profile_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String profile);


     public delegate void efl_config_profile_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String profile);
     public static Efl.Eo.FunctionWrapper<efl_config_profile_set_api_delegate> efl_config_profile_set_ptr = new Efl.Eo.FunctionWrapper<efl_config_profile_set_api_delegate>(_Module, "efl_config_profile_set");
     private static void profile_set(System.IntPtr obj, System.IntPtr pd,  System.String profile)
    {
        Eina.Log.Debug("function efl_config_profile_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((ConfigGlobal)wrapper).SetProfile( profile);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_config_profile_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  profile);
        }
    }
    private static efl_config_profile_set_delegate efl_config_profile_set_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_config_save_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String profile);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_config_save_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String profile);
     public static Efl.Eo.FunctionWrapper<efl_config_save_api_delegate> efl_config_save_ptr = new Efl.Eo.FunctionWrapper<efl_config_save_api_delegate>(_Module, "efl_config_save");
     private static bool save(System.IntPtr obj, System.IntPtr pd,  System.String profile)
    {
        Eina.Log.Debug("function efl_config_save was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                bool _ret_var = default(bool);
            try {
                _ret_var = ((ConfigGlobal)wrapper).Save( profile);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                        return _ret_var;
        } else {
            return efl_config_save_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  profile);
        }
    }
    private static efl_config_save_delegate efl_config_save_static_delegate;


     private delegate System.IntPtr efl_config_profile_iterate_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool hidden);


     public delegate System.IntPtr efl_config_profile_iterate_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool hidden);
     public static Efl.Eo.FunctionWrapper<efl_config_profile_iterate_api_delegate> efl_config_profile_iterate_ptr = new Efl.Eo.FunctionWrapper<efl_config_profile_iterate_api_delegate>(_Module, "efl_config_profile_iterate");
     private static System.IntPtr profile_iterate(System.IntPtr obj, System.IntPtr pd,  bool hidden)
    {
        Eina.Log.Debug("function efl_config_profile_iterate was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                Eina.Iterator<System.String> _ret_var = default(Eina.Iterator<System.String>);
            try {
                _ret_var = ((ConfigGlobal)wrapper).ProfileIterate( hidden);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                        _ret_var.Own = false; return _ret_var.Handle;
        } else {
            return efl_config_profile_iterate_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  hidden);
        }
    }
    private static efl_config_profile_iterate_delegate efl_config_profile_iterate_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_config_profile_exists_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String profile);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_config_profile_exists_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String profile);
     public static Efl.Eo.FunctionWrapper<efl_config_profile_exists_api_delegate> efl_config_profile_exists_ptr = new Efl.Eo.FunctionWrapper<efl_config_profile_exists_api_delegate>(_Module, "efl_config_profile_exists");
     private static bool profile_exists(System.IntPtr obj, System.IntPtr pd,  System.String profile)
    {
        Eina.Log.Debug("function efl_config_profile_exists was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                bool _ret_var = default(bool);
            try {
                _ret_var = ((ConfigGlobal)wrapper).ProfileExists( profile);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                        return _ret_var;
        } else {
            return efl_config_profile_exists_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  profile);
        }
    }
    private static efl_config_profile_exists_delegate efl_config_profile_exists_static_delegate;


     [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringsharePassOwnershipMarshaler))] private delegate System.String efl_config_profile_dir_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String profile,  [MarshalAs(UnmanagedType.U1)]  bool is_user);


     [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringsharePassOwnershipMarshaler))] public delegate System.String efl_config_profile_dir_get_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String profile,  [MarshalAs(UnmanagedType.U1)]  bool is_user);
     public static Efl.Eo.FunctionWrapper<efl_config_profile_dir_get_api_delegate> efl_config_profile_dir_get_ptr = new Efl.Eo.FunctionWrapper<efl_config_profile_dir_get_api_delegate>(_Module, "efl_config_profile_dir_get");
     private static System.String profile_dir_get(System.IntPtr obj, System.IntPtr pd,  System.String profile,  bool is_user)
    {
        Eina.Log.Debug("function efl_config_profile_dir_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                        System.String _ret_var = default(System.String);
            try {
                _ret_var = ((ConfigGlobal)wrapper).GetProfileDir( profile,  is_user);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                        return _ret_var;
        } else {
            return efl_config_profile_dir_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  profile,  is_user);
        }
    }
    private static efl_config_profile_dir_get_delegate efl_config_profile_dir_get_static_delegate;


     private delegate void efl_config_profile_derived_add_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String profile,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String options);


     public delegate void efl_config_profile_derived_add_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String profile,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String options);
     public static Efl.Eo.FunctionWrapper<efl_config_profile_derived_add_api_delegate> efl_config_profile_derived_add_ptr = new Efl.Eo.FunctionWrapper<efl_config_profile_derived_add_api_delegate>(_Module, "efl_config_profile_derived_add");
     private static void profile_derived_add(System.IntPtr obj, System.IntPtr pd,  System.String profile,  System.String options)
    {
        Eina.Log.Debug("function efl_config_profile_derived_add was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                        
            try {
                ((ConfigGlobal)wrapper).AddProfileDerived( profile,  options);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                } else {
            efl_config_profile_derived_add_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  profile,  options);
        }
    }
    private static efl_config_profile_derived_add_delegate efl_config_profile_derived_add_static_delegate;


     private delegate void efl_config_profile_derived_del_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String profile);


     public delegate void efl_config_profile_derived_del_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String profile);
     public static Efl.Eo.FunctionWrapper<efl_config_profile_derived_del_api_delegate> efl_config_profile_derived_del_ptr = new Efl.Eo.FunctionWrapper<efl_config_profile_derived_del_api_delegate>(_Module, "efl_config_profile_derived_del");
     private static void profile_derived_del(System.IntPtr obj, System.IntPtr pd,  System.String profile)
    {
        Eina.Log.Debug("function efl_config_profile_derived_del was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((ConfigGlobal)wrapper).DelProfileDerived( profile);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_config_profile_derived_del_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  profile);
        }
    }
    private static efl_config_profile_derived_del_delegate efl_config_profile_derived_del_static_delegate;


     [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.ValueMarshalerOwn))] private delegate Eina.Value efl_config_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String name);


     [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.ValueMarshalerOwn))] public delegate Eina.Value efl_config_get_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String name);
     public static Efl.Eo.FunctionWrapper<efl_config_get_api_delegate> efl_config_get_ptr = new Efl.Eo.FunctionWrapper<efl_config_get_api_delegate>(_Module, "efl_config_get");
     private static Eina.Value config_get(System.IntPtr obj, System.IntPtr pd,  System.String name)
    {
        Eina.Log.Debug("function efl_config_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                Eina.Value _ret_var = default(Eina.Value);
            try {
                _ret_var = ((ConfigGlobal)wrapper).GetConfig( name);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                        return _ret_var;
        } else {
            return efl_config_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  name);
        }
    }
    private static efl_config_get_delegate efl_config_get_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_config_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String name,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.ValueMarshaler))]  Eina.Value value);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_config_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String name,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.ValueMarshaler))]  Eina.Value value);
     public static Efl.Eo.FunctionWrapper<efl_config_set_api_delegate> efl_config_set_ptr = new Efl.Eo.FunctionWrapper<efl_config_set_api_delegate>(_Module, "efl_config_set");
     private static bool config_set(System.IntPtr obj, System.IntPtr pd,  System.String name,  Eina.Value value)
    {
        Eina.Log.Debug("function efl_config_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                        bool _ret_var = default(bool);
            try {
                _ret_var = ((ConfigGlobal)wrapper).SetConfig( name,  value);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                        return _ret_var;
        } else {
            return efl_config_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  name,  value);
        }
    }
    private static efl_config_set_delegate efl_config_set_static_delegate;
}
} 
