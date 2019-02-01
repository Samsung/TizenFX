#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Access { 
/// <summary>Accessible action mixin</summary>
[ActionConcreteNativeInherit]
public interface Action : 
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>Gets action name for given id</summary>
/// <param name="id">ID to get action name for</param>
/// <returns>Action name</returns>
 System.String GetActionName(  int id);
   /// <summary>Gets localized action name for given id</summary>
/// <param name="id">ID to get localized name for</param>
/// <returns>Localized name</returns>
 System.String GetActionLocalizedName(  int id);
         /// <summary>Get list of available widget actions</summary>
/// <returns>Contains statically allocated strings.</returns>
Eina.List<Efl.Access.ActionData> GetActions();
   /// <summary>Performs action on given widget.</summary>
/// <param name="id">ID for widget</param>
/// <returns><c>true</c> if action was performed, <c>false</c> otherwise</returns>
bool ActionDo(  int id);
   /// <summary>Gets configured keybinding for specific action and widget.</summary>
/// <param name="id">ID for widget</param>
/// <returns>Should be freed by the user.</returns>
 System.String GetActionKeybinding(  int id);
                        /// <summary>Get list of available widget actions</summary>
   Eina.List<Efl.Access.ActionData> Actions {
      get ;
   }
}
/// <summary>Accessible action mixin</summary>
sealed public class ActionConcrete : 

Action
   
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (ActionConcrete))
            return Efl.Access.ActionConcreteNativeInherit.GetEflClassStatic();
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
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
      efl_access_action_mixin_get();
   ///<summary>Constructs an instance from a native pointer.</summary>
   public ActionConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~ActionConcrete()
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
   public static ActionConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new ActionConcrete(obj.NativeHandle);
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


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private static extern  System.String efl_access_action_name_get(System.IntPtr obj,    int id);
   /// <summary>Gets action name for given id</summary>
   /// <param name="id">ID to get action name for</param>
   /// <returns>Action name</returns>
   public  System.String GetActionName(  int id) {
                         var _ret_var = efl_access_action_name_get(Efl.Access.ActionConcrete.efl_access_action_mixin_get(),  id);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private static extern  System.String efl_access_action_localized_name_get(System.IntPtr obj,    int id);
   /// <summary>Gets localized action name for given id</summary>
   /// <param name="id">ID to get localized name for</param>
   /// <returns>Localized name</returns>
   public  System.String GetActionLocalizedName(  int id) {
                         var _ret_var = efl_access_action_localized_name_get(Efl.Access.ActionConcrete.efl_access_action_mixin_get(),  id);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    private static extern  System.IntPtr efl_access_action_actions_get(System.IntPtr obj);
   /// <summary>Get list of available widget actions</summary>
   /// <returns>Contains statically allocated strings.</returns>
   public Eina.List<Efl.Access.ActionData> GetActions() {
       var _ret_var = efl_access_action_actions_get(Efl.Access.ActionConcrete.efl_access_action_mixin_get());
      Eina.Error.RaiseIfUnhandledException();
      return new Eina.List<Efl.Access.ActionData>(_ret_var, false, false);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_access_action_do(System.IntPtr obj,    int id);
   /// <summary>Performs action on given widget.</summary>
   /// <param name="id">ID for widget</param>
   /// <returns><c>true</c> if action was performed, <c>false</c> otherwise</returns>
   public bool ActionDo(  int id) {
                         var _ret_var = efl_access_action_do(Efl.Access.ActionConcrete.efl_access_action_mixin_get(),  id);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringPassOwnershipMarshaler))] private static extern  System.String efl_access_action_keybinding_get(System.IntPtr obj,    int id);
   /// <summary>Gets configured keybinding for specific action and widget.</summary>
   /// <param name="id">ID for widget</param>
   /// <returns>Should be freed by the user.</returns>
   public  System.String GetActionKeybinding(  int id) {
                         var _ret_var = efl_access_action_keybinding_get(Efl.Access.ActionConcrete.efl_access_action_mixin_get(),  id);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Get list of available widget actions</summary>
   public Eina.List<Efl.Access.ActionData> Actions {
      get { return GetActions(); }
   }
}
public class ActionConcreteNativeInherit : Efl.Eo.NativeClass{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_access_action_name_get_static_delegate = new efl_access_action_name_get_delegate(action_name_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_action_name_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_action_name_get_static_delegate)});
      efl_access_action_localized_name_get_static_delegate = new efl_access_action_localized_name_get_delegate(action_localized_name_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_action_localized_name_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_action_localized_name_get_static_delegate)});
      efl_access_action_actions_get_static_delegate = new efl_access_action_actions_get_delegate(actions_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_action_actions_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_action_actions_get_static_delegate)});
      efl_access_action_do_static_delegate = new efl_access_action_do_delegate(action_do);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_action_do"), func = Marshal.GetFunctionPointerForDelegate(efl_access_action_do_static_delegate)});
      efl_access_action_keybinding_get_static_delegate = new efl_access_action_keybinding_get_delegate(action_keybinding_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_action_keybinding_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_action_keybinding_get_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Access.ActionConcrete.efl_access_action_mixin_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.Access.ActionConcrete.efl_access_action_mixin_get();
   }


    private delegate  System.IntPtr efl_access_action_name_get_delegate(System.IntPtr obj, System.IntPtr pd,    int id);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  System.IntPtr efl_access_action_name_get(System.IntPtr obj,    int id);
    private static  System.IntPtr action_name_get(System.IntPtr obj, System.IntPtr pd,   int id)
   {
      Eina.Log.Debug("function efl_access_action_name_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                     System.String _ret_var = default( System.String);
         try {
            _ret_var = ((ActionConcrete)wrapper).GetActionName( id);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return Efl.Eo.Globals.cached_string_to_intptr(((ActionConcrete)wrapper).cached_strings, _ret_var);
      } else {
         return efl_access_action_name_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  id);
      }
   }
   private efl_access_action_name_get_delegate efl_access_action_name_get_static_delegate;


    private delegate  System.IntPtr efl_access_action_localized_name_get_delegate(System.IntPtr obj, System.IntPtr pd,    int id);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  System.IntPtr efl_access_action_localized_name_get(System.IntPtr obj,    int id);
    private static  System.IntPtr action_localized_name_get(System.IntPtr obj, System.IntPtr pd,   int id)
   {
      Eina.Log.Debug("function efl_access_action_localized_name_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                     System.String _ret_var = default( System.String);
         try {
            _ret_var = ((ActionConcrete)wrapper).GetActionLocalizedName( id);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return Efl.Eo.Globals.cached_string_to_intptr(((ActionConcrete)wrapper).cached_strings, _ret_var);
      } else {
         return efl_access_action_localized_name_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  id);
      }
   }
   private efl_access_action_localized_name_get_delegate efl_access_action_localized_name_get_static_delegate;


    private delegate  System.IntPtr efl_access_action_actions_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  System.IntPtr efl_access_action_actions_get(System.IntPtr obj);
    private static  System.IntPtr actions_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_action_actions_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.List<Efl.Access.ActionData> _ret_var = default(Eina.List<Efl.Access.ActionData>);
         try {
            _ret_var = ((ActionConcrete)wrapper).GetActions();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var.Handle;
      } else {
         return efl_access_action_actions_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_access_action_actions_get_delegate efl_access_action_actions_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_access_action_do_delegate(System.IntPtr obj, System.IntPtr pd,    int id);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_access_action_do(System.IntPtr obj,    int id);
    private static bool action_do(System.IntPtr obj, System.IntPtr pd,   int id)
   {
      Eina.Log.Debug("function efl_access_action_do was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((ActionConcrete)wrapper).ActionDo( id);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_access_action_do(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  id);
      }
   }
   private efl_access_action_do_delegate efl_access_action_do_static_delegate;


    private delegate  System.String efl_access_action_keybinding_get_delegate(System.IntPtr obj, System.IntPtr pd,    int id);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  System.String efl_access_action_keybinding_get(System.IntPtr obj,    int id);
    private static  System.String action_keybinding_get(System.IntPtr obj, System.IntPtr pd,   int id)
   {
      Eina.Log.Debug("function efl_access_action_keybinding_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                     System.String _ret_var = default( System.String);
         try {
            _ret_var = ((ActionConcrete)wrapper).GetActionKeybinding( id);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_access_action_keybinding_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  id);
      }
   }
   private efl_access_action_keybinding_get_delegate efl_access_action_keybinding_get_static_delegate;
}
} } 
