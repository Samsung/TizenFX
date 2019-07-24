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
[Efl.Eo.BindingEntity]
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
    Efl.Eo.EoWrapper
    , IItem
    
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
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

    /// <summary>Constructor to be used when objects are expected to be constructed from native code.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    private IItemConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
        efl_cached_item_interface_get();
    /// <summary>Initializes a new instance of the <see cref="IItem"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private IItemConcrete(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
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
    public new class NativeMethods : Efl.Eo.EoWrapper.NativeMethods
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

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate uint efl_cached_item_memory_size_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate uint efl_cached_item_memory_size_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_cached_item_memory_size_get_api_delegate> efl_cached_item_memory_size_get_ptr = new Efl.Eo.FunctionWrapper<efl_cached_item_memory_size_get_api_delegate>(Module, "efl_cached_item_memory_size_get");

        private static uint memory_size_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_cached_item_memory_size_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            uint _ret_var = default(uint);
                try
                {
                    _ret_var = ((IItem)ws.Target).GetMemorySize();
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

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

