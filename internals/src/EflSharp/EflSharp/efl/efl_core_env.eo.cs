#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Core {

/// <summary>This object can maintain a set of key value pairs
/// A object of this type alone does not apply the object to the system. For getting the value into the system, see <see cref="Efl.Core.ProcEnv"/>.
/// 
/// A object can be forked, which will only copy its values, changes to the returned object will not change the object where it is forked off.</summary>
[Efl.Core.Env.NativeMethods]
[Efl.Eo.BindingEntity]
public class Env : Efl.Object, Efl.IDuplicate
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(Env))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)] internal static extern System.IntPtr
        efl_core_env_class_get();
    /// <summary>Initializes a new instance of the <see cref="Env"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public Env(Efl.Object parent= null
            ) : base(efl_core_env_class_get(), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Constructor to be used when objects are expected to be constructed from native code.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected Env(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Env"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected Env(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Env"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected Env(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }

    /// <summary>Get the value of the <c>var</c>, or <c>null</c> if no such <c>var</c> exists in the object</summary>
    /// <param name="var">The name of the variable</param>
    /// <returns>Set var to this value if not <c>NULL</c>, otherwise clear this env value if value is <c>NULL</c> or if it is an empty string</returns>
    virtual public System.String GetEnv(System.String var) {
                                 var _ret_var = Efl.Core.Env.NativeMethods.efl_core_env_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),var);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Add a new pair to this object</summary>
    /// <param name="var">The name of the variable</param>
    /// <param name="value">Set var to this value if not <c>NULL</c>, otherwise clear this env value if value is <c>NULL</c> or if it is an empty string</param>
    virtual public void SetEnv(System.String var, System.String value) {
                                                         Efl.Core.Env.NativeMethods.efl_core_env_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),var, value);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Get the content of this object.
    /// This will return a iterator that contains all keys that are part of this object.</summary>
    virtual public Eina.Iterator<System.String> GetContent() {
         var _ret_var = Efl.Core.Env.NativeMethods.efl_core_env_content_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return new Eina.Iterator<System.String>(_ret_var, false);
 }
    /// <summary>Remove the pair with the matching <c>var</c> from this object</summary>
    /// <param name="var">The name of the variable</param>
    virtual public void Unset(System.String var) {
                                 Efl.Core.Env.NativeMethods.efl_core_env_unset_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),var);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Remove all pairs from this object</summary>
    virtual public void Clear() {
         Efl.Core.Env.NativeMethods.efl_core_env_clear_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Creates a carbon copy of this object and returns it.
    /// The newly created object will have no event handlers or anything of the sort.</summary>
    /// <returns>Returned carbon copy</returns>
    virtual public Efl.IDuplicate Duplicate() {
         var _ret_var = Efl.IDuplicateConcrete.NativeMethods.efl_duplicate_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Get the content of this object.
    /// This will return a iterator that contains all keys that are part of this object.</summary>
    public Eina.Iterator<System.String> Content {
        get { return GetContent(); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Core.Env.efl_core_env_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Object.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Ecore);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_core_env_get_static_delegate == null)
            {
                efl_core_env_get_static_delegate = new efl_core_env_get_delegate(env_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetEnv") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_core_env_get"), func = Marshal.GetFunctionPointerForDelegate(efl_core_env_get_static_delegate) });
            }

            if (efl_core_env_set_static_delegate == null)
            {
                efl_core_env_set_static_delegate = new efl_core_env_set_delegate(env_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetEnv") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_core_env_set"), func = Marshal.GetFunctionPointerForDelegate(efl_core_env_set_static_delegate) });
            }

            if (efl_core_env_content_get_static_delegate == null)
            {
                efl_core_env_content_get_static_delegate = new efl_core_env_content_get_delegate(content_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetContent") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_core_env_content_get"), func = Marshal.GetFunctionPointerForDelegate(efl_core_env_content_get_static_delegate) });
            }

            if (efl_core_env_unset_static_delegate == null)
            {
                efl_core_env_unset_static_delegate = new efl_core_env_unset_delegate(unset);
            }

            if (methods.FirstOrDefault(m => m.Name == "Unset") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_core_env_unset"), func = Marshal.GetFunctionPointerForDelegate(efl_core_env_unset_static_delegate) });
            }

            if (efl_core_env_clear_static_delegate == null)
            {
                efl_core_env_clear_static_delegate = new efl_core_env_clear_delegate(clear);
            }

            if (methods.FirstOrDefault(m => m.Name == "Clear") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_core_env_clear"), func = Marshal.GetFunctionPointerForDelegate(efl_core_env_clear_static_delegate) });
            }

            if (efl_duplicate_static_delegate == null)
            {
                efl_duplicate_static_delegate = new efl_duplicate_delegate(duplicate);
            }

            if (methods.FirstOrDefault(m => m.Name == "Duplicate") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_duplicate"), func = Marshal.GetFunctionPointerForDelegate(efl_duplicate_static_delegate) });
            }

            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Core.Env.efl_core_env_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_core_env_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String var);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_core_env_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String var);

        public static Efl.Eo.FunctionWrapper<efl_core_env_get_api_delegate> efl_core_env_get_ptr = new Efl.Eo.FunctionWrapper<efl_core_env_get_api_delegate>(Module, "efl_core_env_get");

        private static System.String env_get(System.IntPtr obj, System.IntPtr pd, System.String var)
        {
            Eina.Log.Debug("function efl_core_env_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((Env)ws.Target).GetEnv(var);
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
                return efl_core_env_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), var);
            }
        }

        private static efl_core_env_get_delegate efl_core_env_get_static_delegate;

        
        private delegate void efl_core_env_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String var, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String value);

        
        public delegate void efl_core_env_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String var, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String value);

        public static Efl.Eo.FunctionWrapper<efl_core_env_set_api_delegate> efl_core_env_set_ptr = new Efl.Eo.FunctionWrapper<efl_core_env_set_api_delegate>(Module, "efl_core_env_set");

        private static void env_set(System.IntPtr obj, System.IntPtr pd, System.String var, System.String value)
        {
            Eina.Log.Debug("function efl_core_env_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((Env)ws.Target).SetEnv(var, value);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_core_env_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), var, value);
            }
        }

        private static efl_core_env_set_delegate efl_core_env_set_static_delegate;

        
        private delegate System.IntPtr efl_core_env_content_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate System.IntPtr efl_core_env_content_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_core_env_content_get_api_delegate> efl_core_env_content_get_ptr = new Efl.Eo.FunctionWrapper<efl_core_env_content_get_api_delegate>(Module, "efl_core_env_content_get");

        private static System.IntPtr content_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_core_env_content_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Iterator<System.String> _ret_var = default(Eina.Iterator<System.String>);
                try
                {
                    _ret_var = ((Env)ws.Target).GetContent();
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
                return efl_core_env_content_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_core_env_content_get_delegate efl_core_env_content_get_static_delegate;

        
        private delegate void efl_core_env_unset_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String var);

        
        public delegate void efl_core_env_unset_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String var);

        public static Efl.Eo.FunctionWrapper<efl_core_env_unset_api_delegate> efl_core_env_unset_ptr = new Efl.Eo.FunctionWrapper<efl_core_env_unset_api_delegate>(Module, "efl_core_env_unset");

        private static void unset(System.IntPtr obj, System.IntPtr pd, System.String var)
        {
            Eina.Log.Debug("function efl_core_env_unset was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Env)ws.Target).Unset(var);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_core_env_unset_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), var);
            }
        }

        private static efl_core_env_unset_delegate efl_core_env_unset_static_delegate;

        
        private delegate void efl_core_env_clear_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_core_env_clear_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_core_env_clear_api_delegate> efl_core_env_clear_ptr = new Efl.Eo.FunctionWrapper<efl_core_env_clear_api_delegate>(Module, "efl_core_env_clear");

        private static void clear(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_core_env_clear was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((Env)ws.Target).Clear();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_core_env_clear_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_core_env_clear_delegate efl_core_env_clear_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.OwnTag>))]
        private delegate Efl.IDuplicate efl_duplicate_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.OwnTag>))]
        public delegate Efl.IDuplicate efl_duplicate_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_duplicate_api_delegate> efl_duplicate_ptr = new Efl.Eo.FunctionWrapper<efl_duplicate_api_delegate>(Module, "efl_duplicate");

        private static Efl.IDuplicate duplicate(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_duplicate was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.IDuplicate _ret_var = default(Efl.IDuplicate);
                try
                {
                    _ret_var = ((Env)ws.Target).Duplicate();
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
                return efl_duplicate_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_duplicate_delegate efl_duplicate_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

