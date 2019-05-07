#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Canvas {

/// <summary>Object factory that creates Efl.Canvas.Object objects.
/// Translates a given key to an object (item), to be later placed in a text for higher level usages. The translation implementation is left to be decided by the inheriting class, whether it is by treating the <c>key</c> as an image path, or a key associated with a real-path in a hashtable or something else entirely.</summary>
[Efl.Canvas.ITextFactoryConcrete.NativeMethods]
public interface ITextFactory : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Translates a given <c>key</c> to an item object, and returns the object. The returned object should be owned by the passed <c>object</c>.</summary>
/// <param name="kw_object">The parent of the created object</param>
/// <param name="key">Key that is associated to an item object</param>
Efl.Canvas.Object Create(Efl.Canvas.Object kw_object, System.String key);
    }
/// <summary>Object factory that creates Efl.Canvas.Object objects.
/// Translates a given key to an object (item), to be later placed in a text for higher level usages. The translation implementation is left to be decided by the inheriting class, whether it is by treating the <c>key</c> as an image path, or a key associated with a real-path in a hashtable or something else entirely.</summary>
sealed public class ITextFactoryConcrete : 

ITextFactory
    
{
    ///<summary>Pointer to the native class description.</summary>
    public System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(ITextFactoryConcrete))
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

    [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] internal static extern System.IntPtr
        efl_canvas_text_factory_interface_get();
    /// <summary>Initializes a new instance of the <see cref="ITextFactory"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    private ITextFactoryConcrete(System.IntPtr raw)
    {
        handle = raw;
    }
    ///<summary>Destructor.</summary>
    ~ITextFactoryConcrete()
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

    /// <summary>Translates a given <c>key</c> to an item object, and returns the object. The returned object should be owned by the passed <c>object</c>.</summary>
    /// <param name="kw_object">The parent of the created object</param>
    /// <param name="key">Key that is associated to an item object</param>
    public Efl.Canvas.Object Create(Efl.Canvas.Object kw_object, System.String key) {
                                                         var _ret_var = Efl.Canvas.ITextFactoryConcrete.NativeMethods.efl_canvas_text_factory_create_ptr.Value.Delegate(this.NativeHandle,kw_object, key);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Canvas.ITextFactoryConcrete.efl_canvas_text_factory_interface_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public class NativeMethods  : Efl.Eo.NativeClass
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Evas);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_canvas_text_factory_create_static_delegate == null)
            {
                efl_canvas_text_factory_create_static_delegate = new efl_canvas_text_factory_create_delegate(create);
            }

            if (methods.FirstOrDefault(m => m.Name == "Create") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_text_factory_create"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_text_factory_create_static_delegate) });
            }

            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Canvas.ITextFactoryConcrete.efl_canvas_text_factory_interface_get();
        }

        #pragma warning disable CA1707, SA1300, SA1600

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.OwnTag>))]
        private delegate Efl.Canvas.Object efl_canvas_text_factory_create_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Object kw_object, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String key);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.OwnTag>))]
        public delegate Efl.Canvas.Object efl_canvas_text_factory_create_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Object kw_object, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String key);

        public static Efl.Eo.FunctionWrapper<efl_canvas_text_factory_create_api_delegate> efl_canvas_text_factory_create_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_text_factory_create_api_delegate>(Module, "efl_canvas_text_factory_create");

        private static Efl.Canvas.Object create(System.IntPtr obj, System.IntPtr pd, Efl.Canvas.Object kw_object, System.String key)
        {
            Eina.Log.Debug("function efl_canvas_text_factory_create was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                                            Efl.Canvas.Object _ret_var = default(Efl.Canvas.Object);
                try
                {
                    _ret_var = ((ITextFactory)wrapper).Create(kw_object, key);
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
                return efl_canvas_text_factory_create_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), kw_object, key);
            }
        }

        private static efl_canvas_text_factory_create_delegate efl_canvas_text_factory_create_static_delegate;

        #pragma warning restore CA1707, SA1300, SA1600

}
}
}

}

