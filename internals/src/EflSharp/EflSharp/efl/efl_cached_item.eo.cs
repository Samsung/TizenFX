#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Cached {

/// <summary>Efl Cached Item interface</summary>
[Efl.Cached.IItemConcrete.NativeMethods]
public interface IItem : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Get the memory size associated with an object.</summary>
/// <returns>Bytes of memory consumed by this object.</returns>
uint GetMemorySize();
        /// <summary>Get the memory size associated with an object.</summary>
/// <value>Bytes of memory consumed by this object.</value>
    uint MemorySize {
        get ;
    }
}
/// <summary>Efl Cached Item interface</summary>
sealed public class IItemConcrete : 

IItem
    
{
    ///<summary>Pointer to the native class description.</summary>
    public System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(IItemConcrete))
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
        efl_cached_item_interface_get();
    /// <summary>Initializes a new instance of the <see cref="IItem"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    private IItemConcrete(System.IntPtr raw)
    {
        handle = raw;
    }
    ///<summary>Destructor.</summary>
    ~IItemConcrete()
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

    /// <summary>Get the memory size associated with an object.</summary>
    /// <returns>Bytes of memory consumed by this object.</returns>
    public uint GetMemorySize() {
         var _ret_var = Efl.Cached.IItemConcrete.NativeMethods.efl_cached_item_memory_size_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Get the memory size associated with an object.</summary>
/// <value>Bytes of memory consumed by this object.</value>
    public uint MemorySize {
        get { return GetMemorySize(); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Cached.IItemConcrete.efl_cached_item_interface_get();
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

            if (efl_cached_item_memory_size_get_static_delegate == null)
            {
                efl_cached_item_memory_size_get_static_delegate = new efl_cached_item_memory_size_get_delegate(memory_size_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetMemorySize") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_cached_item_memory_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_cached_item_memory_size_get_static_delegate) });
            }

            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Cached.IItemConcrete.efl_cached_item_interface_get();
        }

        #pragma warning disable CA1707, SA1300, SA1600

        
        private delegate uint efl_cached_item_memory_size_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate uint efl_cached_item_memory_size_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_cached_item_memory_size_get_api_delegate> efl_cached_item_memory_size_get_ptr = new Efl.Eo.FunctionWrapper<efl_cached_item_memory_size_get_api_delegate>(Module, "efl_cached_item_memory_size_get");

        private static uint memory_size_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_cached_item_memory_size_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            uint _ret_var = default(uint);
                try
                {
                    _ret_var = ((IItem)wrapper).GetMemorySize();
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
                return efl_cached_item_memory_size_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_cached_item_memory_size_get_delegate efl_cached_item_memory_size_get_static_delegate;

        #pragma warning restore CA1707, SA1300, SA1600

}
}
}

}

