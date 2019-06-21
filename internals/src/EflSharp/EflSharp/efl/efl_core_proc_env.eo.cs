#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Core {

[Efl.Core.ProcEnv.NativeMethods]
public class ProcEnv : Efl.Core.Env
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(ProcEnv))
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
        efl_core_proc_env_class_get();
    /// <summary>Initializes a new instance of the <see cref="ProcEnv"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public ProcEnv(Efl.Object parent= null
            ) : base(efl_core_proc_env_class_get(), typeof(ProcEnv), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Initializes a new instance of the <see cref="ProcEnv"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="raw">The native pointer to be wrapped.</param>
    protected ProcEnv(System.IntPtr raw) : base(raw)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="ProcEnv"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="managedType">The managed type of the public constructor that originated this call.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected ProcEnv(IntPtr baseKlass, System.Type managedType, Efl.Object parent) : base(baseKlass, managedType, parent)
    {
    }

    /// <summary>Get a instance of this object
    /// The object will apply the environment operations onto this process.</summary>
    public static Efl.Core.Env Self() {
         var _ret_var = Efl.Core.ProcEnv.NativeMethods.efl_env_self_ptr.Value.Delegate();
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Core.ProcEnv.efl_core_proc_env_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Core.Env.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Ecore);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Core.ProcEnv.efl_core_proc_env_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Core.Env efl_env_self_delegate();

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Core.Env efl_env_self_api_delegate();

        public static Efl.Eo.FunctionWrapper<efl_env_self_api_delegate> efl_env_self_ptr = new Efl.Eo.FunctionWrapper<efl_env_self_api_delegate>(Module, "efl_env_self");

        private static Efl.Core.Env self(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_env_self was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Core.Env _ret_var = default(Efl.Core.Env);
                try
                {
                    _ret_var = ProcEnv.Self();
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
                return efl_env_self_ptr.Value.Delegate();
            }
        }

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

