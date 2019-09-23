#define EFL_BETA
#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Access {

/// <summary>Accessible action mixin</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Access.ActionConcrete.NativeMethods]
[Efl.Eo.BindingEntity]
public interface IAction : 
    Efl.Eo.IWrapper, IDisposable
{
                                                        }
/// <summary>Accessible action mixin</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
public sealed class ActionConcrete :
    Efl.Eo.EoWrapper
    , IAction
    
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(ActionConcrete))
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
    private ActionConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_access_action_mixin_get();
    /// <summary>Initializes a new instance of the <see cref="IAction"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private ActionConcrete(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

#pragma warning disable CS0628
    /// <summary>Gets action name for given id</summary>
    /// <param name="id">ID to get action name for</param>
    /// <returns>Action name</returns>
    protected System.String GetActionName(int id) {
                                 var _ret_var = Efl.Access.ActionConcrete.NativeMethods.efl_access_action_name_get_ptr.Value.Delegate(this.NativeHandle,id);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Gets localized action name for given id</summary>
    /// <param name="id">ID to get localized name for</param>
    /// <returns>Localized name</returns>
    protected System.String GetActionLocalizedName(int id) {
                                 var _ret_var = Efl.Access.ActionConcrete.NativeMethods.efl_access_action_localized_name_get_ptr.Value.Delegate(this.NativeHandle,id);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Get list of available widget actions</summary>
    /// <returns>Contains statically allocated strings.</returns>
    protected Eina.List<Efl.Access.ActionData> GetActions() {
         var _ret_var = Efl.Access.ActionConcrete.NativeMethods.efl_access_action_actions_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return new Eina.List<Efl.Access.ActionData>(_ret_var, false, false);
 }
    /// <summary>Performs action on given widget.</summary>
    /// <param name="id">ID for widget</param>
    /// <returns><c>true</c> if action was performed, <c>false</c> otherwise</returns>
    protected bool ActionDo(int id) {
                                 var _ret_var = Efl.Access.ActionConcrete.NativeMethods.efl_access_action_do_ptr.Value.Delegate(this.NativeHandle,id);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Gets configured keybinding for specific action and widget.</summary>
    /// <param name="id">ID for widget</param>
    /// <returns>Should be freed by the user.</returns>
    protected System.String GetActionKeybinding(int id) {
                                 var _ret_var = Efl.Access.ActionConcrete.NativeMethods.efl_access_action_keybinding_get_ptr.Value.Delegate(this.NativeHandle,id);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Get list of available widget actions</summary>
    /// <value>Contains statically allocated strings.</value>
    protected Eina.List<Efl.Access.ActionData> Actions {
        get { return GetActions(); }
    }
#pragma warning restore CS0628
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Access.ActionConcrete.efl_access_action_mixin_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Eo.EoWrapper.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Elementary);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
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
            return Efl.Access.ActionConcrete.efl_access_action_mixin_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_access_action_name_get_delegate(System.IntPtr obj, System.IntPtr pd,  int id);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_access_action_name_get_api_delegate(System.IntPtr obj,  int id);

        public static Efl.Eo.FunctionWrapper<efl_access_action_name_get_api_delegate> efl_access_action_name_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_action_name_get_api_delegate>(Module, "efl_access_action_name_get");

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_access_action_localized_name_get_delegate(System.IntPtr obj, System.IntPtr pd,  int id);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_access_action_localized_name_get_api_delegate(System.IntPtr obj,  int id);

        public static Efl.Eo.FunctionWrapper<efl_access_action_localized_name_get_api_delegate> efl_access_action_localized_name_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_action_localized_name_get_api_delegate>(Module, "efl_access_action_localized_name_get");

        
        private delegate System.IntPtr efl_access_action_actions_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate System.IntPtr efl_access_action_actions_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_access_action_actions_get_api_delegate> efl_access_action_actions_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_action_actions_get_api_delegate>(Module, "efl_access_action_actions_get");

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_access_action_do_delegate(System.IntPtr obj, System.IntPtr pd,  int id);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_access_action_do_api_delegate(System.IntPtr obj,  int id);

        public static Efl.Eo.FunctionWrapper<efl_access_action_do_api_delegate> efl_access_action_do_ptr = new Efl.Eo.FunctionWrapper<efl_access_action_do_api_delegate>(Module, "efl_access_action_do");

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringPassOwnershipMarshaler))]
        private delegate System.String efl_access_action_keybinding_get_delegate(System.IntPtr obj, System.IntPtr pd,  int id);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringPassOwnershipMarshaler))]
        public delegate System.String efl_access_action_keybinding_get_api_delegate(System.IntPtr obj,  int id);

        public static Efl.Eo.FunctionWrapper<efl_access_action_keybinding_get_api_delegate> efl_access_action_keybinding_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_action_keybinding_get_api_delegate>(Module, "efl_access_action_keybinding_get");

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_AccessActionConcrete_ExtensionMethods {
    
    
    
    
}
#pragma warning restore CS1591
#endif
