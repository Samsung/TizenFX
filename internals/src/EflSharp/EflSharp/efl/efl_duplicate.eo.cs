#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

/// <summary>An interface for duplication of objects.
/// Objects implementing this interface can be duplicated with <see cref="Efl.IDuplicate.Duplicate"/>.</summary>
[Efl.IDuplicateConcrete.NativeMethods]
public interface IDuplicate : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Creates a carbon copy of this object and returns it.
/// The newly created object will have no event handlers or anything of the sort.</summary>
/// <returns>Returned carbon copy</returns>
Efl.IDuplicate Duplicate();
    }
/// <summary>An interface for duplication of objects.
/// Objects implementing this interface can be duplicated with <see cref="Efl.IDuplicate.Duplicate"/>.</summary>
sealed public class IDuplicateConcrete :
    Efl.Eo.EoWrapper
    , IDuplicate
    
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(IDuplicateConcrete))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] internal static extern System.IntPtr
        efl_duplicate_interface_get();
    /// <summary>Initializes a new instance of the <see cref="IDuplicate"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    private IDuplicateConcrete(System.IntPtr raw) : base(raw)
    {
    }

    /// <summary>Creates a carbon copy of this object and returns it.
    /// The newly created object will have no event handlers or anything of the sort.</summary>
    /// <returns>Returned carbon copy</returns>
    public Efl.IDuplicate Duplicate() {
         var _ret_var = Efl.IDuplicateConcrete.NativeMethods.efl_duplicate_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.IDuplicateConcrete.efl_duplicate_interface_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public class NativeMethods  : Efl.Eo.NativeClass
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Efl);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_duplicate_static_delegate == null)
            {
                efl_duplicate_static_delegate = new efl_duplicate_delegate(duplicate);
            }

            if (methods.FirstOrDefault(m => m.Name == "Duplicate") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_duplicate"), func = Marshal.GetFunctionPointerForDelegate(efl_duplicate_static_delegate) });
            }

            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.IDuplicateConcrete.efl_duplicate_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

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
                    _ret_var = ((IDuplicate)ws.Target).Duplicate();
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

