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
[Efl.Access.IActionConcrete.NativeMethods]
public interface IAction : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Gets action name for given id</summary>
/// <param name="id">ID to get action name for</param>
/// <returns>Action name</returns>
System.String GetActionName(int id);
    /// <summary>Gets localized action name for given id</summary>
/// <param name="id">ID to get localized name for</param>
/// <returns>Localized name</returns>
System.String GetActionLocalizedName(int id);
            /// <summary>Get list of available widget actions</summary>
/// <returns>Contains statically allocated strings.</returns>
Eina.List<Efl.Access.ActionData> GetActions();
    /// <summary>Performs action on given widget.</summary>
/// <param name="id">ID for widget</param>
/// <returns><c>true</c> if action was performed, <c>false</c> otherwise</returns>
bool ActionDo(int id);
    /// <summary>Gets configured keybinding for specific action and widget.</summary>
/// <param name="id">ID for widget</param>
/// <returns>Should be freed by the user.</returns>
System.String GetActionKeybinding(int id);
                                /// <summary>Get list of available widget actions</summary>
/// <value>Contains statically allocated strings.</value>
    Eina.List<Efl.Access.ActionData> Actions {
        get ;
    }
}
/// <summary>Accessible action mixin</summary>
sealed public class IActionConcrete : 

IAction
    
{
    ///<summary>Pointer to the native class description.</summary>
    public System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(IActionConcrete))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    private  System.IntPtr handle;
    ///<summary>Pointer to the native instance.</summary>
    public System.IntPtr NativeHandle
    {
        get { return handle; }
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_access_action_mixin_get();
    /// <summary>Initializes a new instance of the <see cref="IAction"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    private IActionConcrete(System.IntPtr raw)
    {
        handle = raw;
    }
    ///<summary>Destructor.</summary>
    ~IActionConcrete()
    {
        Dispose(false);
    }

    ///<summary>Releases the underlying native instance.</summary>
    private void Dispose(bool disposing)
    {
        if (handle != System.IntPtr.Zero)
        {
            IntPtr h = handle;
            handle = IntPtr.Zero;

            IntPtr gcHandlePtr = IntPtr.Zero;
            if (disposing)
            {
                Efl.Eo.Globals.efl_mono_native_dispose(h, gcHandlePtr);
            }
            else
            {
                Monitor.Enter(Efl.All.InitLock);
                if (Efl.All.MainLoopInitialized)
                {
                    Efl.Eo.Globals.efl_mono_thread_safe_native_dispose(h, gcHandlePtr);
                }

                Monitor.Exit(Efl.All.InitLock);
            }
        }

    }

    ///<summary>Releases the underlying native instance.</summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>Verifies if the given object is equal to this one.</summary>
    /// <param name="instance">The object to compare to.</param>
    /// <returns>True if both objects point to the same native object.</returns>
    public override bool Equals(object instance)
    {
        var other = instance as Efl.Object;
        if (other == null)
        {
            return false;
        }
        return this.NativeHandle == other.NativeHandle;
    }

    /// <summary>Gets the hash code for this object based on the native pointer it points to.</summary>
    /// <returns>The value of the pointer, to be used as the hash code of this object.</returns>
    public override int GetHashCode()
    {
        return this.NativeHandle.ToInt32();
    }

    /// <summary>Turns the native pointer into a string representation.</summary>
    /// <returns>A string with the type and the native pointer for this object.</returns>
    public override String ToString()
    {
        return $"{this.GetType().Name}@[{this.NativeHandle.ToInt32():x}]";
    }

    /// <summary>Gets action name for given id</summary>
    /// <param name="id">ID to get action name for</param>
    /// <returns>Action name</returns>
    public System.String GetActionName(int id) {
                                 var _ret_var = Efl.Access.IActionConcrete.NativeMethods.efl_access_action_name_get_ptr.Value.Delegate(this.NativeHandle,id);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Gets localized action name for given id</summary>
    /// <param name="id">ID to get localized name for</param>
    /// <returns>Localized name</returns>
    public System.String GetActionLocalizedName(int id) {
                                 var _ret_var = Efl.Access.IActionConcrete.NativeMethods.efl_access_action_localized_name_get_ptr.Value.Delegate(this.NativeHandle,id);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Get list of available widget actions</summary>
    /// <returns>Contains statically allocated strings.</returns>
    public Eina.List<Efl.Access.ActionData> GetActions() {
         var _ret_var = Efl.Access.IActionConcrete.NativeMethods.efl_access_action_actions_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return new Eina.List<Efl.Access.ActionData>(_ret_var, false, false);
 }
    /// <summary>Performs action on given widget.</summary>
    /// <param name="id">ID for widget</param>
    /// <returns><c>true</c> if action was performed, <c>false</c> otherwise</returns>
    public bool ActionDo(int id) {
                                 var _ret_var = Efl.Access.IActionConcrete.NativeMethods.efl_access_action_do_ptr.Value.Delegate(this.NativeHandle,id);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Gets configured keybinding for specific action and widget.</summary>
    /// <param name="id">ID for widget</param>
    /// <returns>Should be freed by the user.</returns>
    public System.String GetActionKeybinding(int id) {
                                 var _ret_var = Efl.Access.IActionConcrete.NativeMethods.efl_access_action_keybinding_get_ptr.Value.Delegate(this.NativeHandle,id);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Get list of available widget actions</summary>
/// <value>Contains statically allocated strings.</value>
    public Eina.List<Efl.Access.ActionData> Actions {
        get { return GetActions(); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Access.IActionConcrete.efl_access_action_mixin_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public class NativeMethods  : Efl.Eo.NativeClass
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Elementary);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_access_action_name_get_static_delegate == null)
            {
                efl_access_action_name_get_static_delegate = new efl_access_action_name_get_delegate(action_name_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetActionName") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_action_name_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_action_name_get_static_delegate) });
            }

            if (efl_access_action_localized_name_get_static_delegate == null)
            {
                efl_access_action_localized_name_get_static_delegate = new efl_access_action_localized_name_get_delegate(action_localized_name_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetActionLocalizedName") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_action_localized_name_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_action_localized_name_get_static_delegate) });
            }

            if (efl_access_action_actions_get_static_delegate == null)
            {
                efl_access_action_actions_get_static_delegate = new efl_access_action_actions_get_delegate(actions_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetActions") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_action_actions_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_action_actions_get_static_delegate) });
            }

            if (efl_access_action_do_static_delegate == null)
            {
                efl_access_action_do_static_delegate = new efl_access_action_do_delegate(action_do);
            }

            if (methods.FirstOrDefault(m => m.Name == "ActionDo") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_action_do"), func = Marshal.GetFunctionPointerForDelegate(efl_access_action_do_static_delegate) });
            }

            if (efl_access_action_keybinding_get_static_delegate == null)
            {
                efl_access_action_keybinding_get_static_delegate = new efl_access_action_keybinding_get_delegate(action_keybinding_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetActionKeybinding") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_action_keybinding_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_action_keybinding_get_static_delegate) });
            }

            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Access.IActionConcrete.efl_access_action_mixin_get();
        }

        #pragma warning disable CA1707, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_access_action_name_get_delegate(System.IntPtr obj, System.IntPtr pd,  int id);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_access_action_name_get_api_delegate(System.IntPtr obj,  int id);

        public static Efl.Eo.FunctionWrapper<efl_access_action_name_get_api_delegate> efl_access_action_name_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_action_name_get_api_delegate>(Module, "efl_access_action_name_get");

        private static System.String action_name_get(System.IntPtr obj, System.IntPtr pd, int id)
        {
            Eina.Log.Debug("function efl_access_action_name_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((IActionConcrete)wrapper).GetActionName(id);
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
                return efl_access_action_name_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), id);
            }
        }

        private static efl_access_action_name_get_delegate efl_access_action_name_get_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_access_action_localized_name_get_delegate(System.IntPtr obj, System.IntPtr pd,  int id);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_access_action_localized_name_get_api_delegate(System.IntPtr obj,  int id);

        public static Efl.Eo.FunctionWrapper<efl_access_action_localized_name_get_api_delegate> efl_access_action_localized_name_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_action_localized_name_get_api_delegate>(Module, "efl_access_action_localized_name_get");

        private static System.String action_localized_name_get(System.IntPtr obj, System.IntPtr pd, int id)
        {
            Eina.Log.Debug("function efl_access_action_localized_name_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((IActionConcrete)wrapper).GetActionLocalizedName(id);
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
                return efl_access_action_localized_name_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), id);
            }
        }

        private static efl_access_action_localized_name_get_delegate efl_access_action_localized_name_get_static_delegate;

        
        private delegate System.IntPtr efl_access_action_actions_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate System.IntPtr efl_access_action_actions_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_access_action_actions_get_api_delegate> efl_access_action_actions_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_action_actions_get_api_delegate>(Module, "efl_access_action_actions_get");

        private static System.IntPtr actions_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_access_action_actions_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            Eina.List<Efl.Access.ActionData> _ret_var = default(Eina.List<Efl.Access.ActionData>);
                try
                {
                    _ret_var = ((IActionConcrete)wrapper).GetActions();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        return _ret_var.Handle;

            }
            else
            {
                return efl_access_action_actions_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_access_action_actions_get_delegate efl_access_action_actions_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_access_action_do_delegate(System.IntPtr obj, System.IntPtr pd,  int id);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_access_action_do_api_delegate(System.IntPtr obj,  int id);

        public static Efl.Eo.FunctionWrapper<efl_access_action_do_api_delegate> efl_access_action_do_ptr = new Efl.Eo.FunctionWrapper<efl_access_action_do_api_delegate>(Module, "efl_access_action_do");

        private static bool action_do(System.IntPtr obj, System.IntPtr pd, int id)
        {
            Eina.Log.Debug("function efl_access_action_do was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IActionConcrete)wrapper).ActionDo(id);
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
                return efl_access_action_do_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), id);
            }
        }

        private static efl_access_action_do_delegate efl_access_action_do_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringPassOwnershipMarshaler))]
        private delegate System.String efl_access_action_keybinding_get_delegate(System.IntPtr obj, System.IntPtr pd,  int id);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringPassOwnershipMarshaler))]
        public delegate System.String efl_access_action_keybinding_get_api_delegate(System.IntPtr obj,  int id);

        public static Efl.Eo.FunctionWrapper<efl_access_action_keybinding_get_api_delegate> efl_access_action_keybinding_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_action_keybinding_get_api_delegate>(Module, "efl_access_action_keybinding_get");

        private static System.String action_keybinding_get(System.IntPtr obj, System.IntPtr pd, int id)
        {
            Eina.Log.Debug("function efl_access_action_keybinding_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((IActionConcrete)wrapper).GetActionKeybinding(id);
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
                return efl_access_action_keybinding_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), id);
            }
        }

        private static efl_access_action_keybinding_get_delegate efl_access_action_keybinding_get_static_delegate;

        #pragma warning restore CA1707, SA1300, SA1600

}
}
}

}

