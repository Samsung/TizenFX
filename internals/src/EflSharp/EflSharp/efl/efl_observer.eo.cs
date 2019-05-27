#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

/// <summary>Efl observer interface</summary>
[Efl.IObserverConcrete.NativeMethods]
public interface IObserver : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Update observer according to the changes of observable object.</summary>
/// <param name="obs">An observable object</param>
/// <param name="key">A key to classify observer groups</param>
/// <param name="data">Required data to update the observer, usually passed by observable object</param>
void Update(Efl.Object obs, System.String key, System.IntPtr data);
    }
/// <summary>Efl observer interface</summary>
sealed public class IObserverConcrete : 

IObserver
    
{
    ///<summary>Pointer to the native class description.</summary>
    public System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(IObserverConcrete))
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

    [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] internal static extern System.IntPtr
        efl_observer_interface_get();
    /// <summary>Initializes a new instance of the <see cref="IObserver"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    private IObserverConcrete(System.IntPtr raw)
    {
        handle = raw;
    }
    ///<summary>Destructor.</summary>
    ~IObserverConcrete()
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

    /// <summary>Update observer according to the changes of observable object.</summary>
    /// <param name="obs">An observable object</param>
    /// <param name="key">A key to classify observer groups</param>
    /// <param name="data">Required data to update the observer, usually passed by observable object</param>
    public void Update(Efl.Object obs, System.String key, System.IntPtr data) {
                                                                                 Efl.IObserverConcrete.NativeMethods.efl_observer_update_ptr.Value.Delegate(this.NativeHandle,obs, key, data);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.IObserverConcrete.efl_observer_interface_get();
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

            if (efl_observer_update_static_delegate == null)
            {
                efl_observer_update_static_delegate = new efl_observer_update_delegate(update);
            }

            if (methods.FirstOrDefault(m => m.Name == "Update") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_observer_update"), func = Marshal.GetFunctionPointerForDelegate(efl_observer_update_static_delegate) });
            }

            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.IObserverConcrete.efl_observer_interface_get();
        }

        #pragma warning disable CA1707, SA1300, SA1600

        
        private delegate void efl_observer_update_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Object obs, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String key,  System.IntPtr data);

        
        public delegate void efl_observer_update_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Object obs, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String key,  System.IntPtr data);

        public static Efl.Eo.FunctionWrapper<efl_observer_update_api_delegate> efl_observer_update_ptr = new Efl.Eo.FunctionWrapper<efl_observer_update_api_delegate>(Module, "efl_observer_update");

        private static void update(System.IntPtr obj, System.IntPtr pd, Efl.Object obs, System.String key, System.IntPtr data)
        {
            Eina.Log.Debug("function efl_observer_update was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                                                                    
                try
                {
                    ((IObserver)wrapper).Update(obs, key, data);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                        
            }
            else
            {
                efl_observer_update_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), obs, key, data);
            }
        }

        private static efl_observer_update_delegate efl_observer_update_static_delegate;

        #pragma warning restore CA1707, SA1300, SA1600

}
}
}

