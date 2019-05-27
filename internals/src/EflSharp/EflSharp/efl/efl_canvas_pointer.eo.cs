#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Canvas {

/// <summary>Efl Canvas Pointer interface
/// (Since EFL 1.22)</summary>
[Efl.Canvas.IPointerConcrete.NativeMethods]
public interface IPointer : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Returns whether the mouse pointer is logically inside the canvas.
/// When this function is called it will return a value of either <c>false</c> or <c>true</c>, depending on whether a pointer,in or pointer,out event has been called previously.
/// 
/// A return value of <c>true</c> indicates the mouse is logically inside the canvas, and <c>false</c> implies it is logically outside the canvas.
/// 
/// A canvas begins with the mouse being assumed outside (<c>false</c>).
/// (Since EFL 1.22)</summary>
/// <param name="seat">The seat to consider, if <c>null</c> then the default seat will be used.</param>
/// <returns><c>true</c> if the mouse pointer is inside the canvas, <c>false</c> otherwise</returns>
bool GetPointerInside(Efl.Input.Device seat);
    }
/// <summary>Efl Canvas Pointer interface
/// (Since EFL 1.22)</summary>
sealed public class IPointerConcrete : 

IPointer
    
{
    ///<summary>Pointer to the native class description.</summary>
    public System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(IPointerConcrete))
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
        efl_canvas_pointer_interface_get();
    /// <summary>Initializes a new instance of the <see cref="IPointer"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    private IPointerConcrete(System.IntPtr raw)
    {
        handle = raw;
    }
    ///<summary>Destructor.</summary>
    ~IPointerConcrete()
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

    /// <summary>Returns whether the mouse pointer is logically inside the canvas.
    /// When this function is called it will return a value of either <c>false</c> or <c>true</c>, depending on whether a pointer,in or pointer,out event has been called previously.
    /// 
    /// A return value of <c>true</c> indicates the mouse is logically inside the canvas, and <c>false</c> implies it is logically outside the canvas.
    /// 
    /// A canvas begins with the mouse being assumed outside (<c>false</c>).
    /// (Since EFL 1.22)</summary>
    /// <param name="seat">The seat to consider, if <c>null</c> then the default seat will be used.</param>
    /// <returns><c>true</c> if the mouse pointer is inside the canvas, <c>false</c> otherwise</returns>
    public bool GetPointerInside(Efl.Input.Device seat) {
                                 var _ret_var = Efl.Canvas.IPointerConcrete.NativeMethods.efl_canvas_pointer_inside_get_ptr.Value.Delegate(this.NativeHandle,seat);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Canvas.IPointerConcrete.efl_canvas_pointer_interface_get();
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

            if (efl_canvas_pointer_inside_get_static_delegate == null)
            {
                efl_canvas_pointer_inside_get_static_delegate = new efl_canvas_pointer_inside_get_delegate(pointer_inside_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetPointerInside") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_pointer_inside_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_pointer_inside_get_static_delegate) });
            }

            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Canvas.IPointerConcrete.efl_canvas_pointer_interface_get();
        }

        #pragma warning disable CA1707, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_canvas_pointer_inside_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Input.Device seat);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_canvas_pointer_inside_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Input.Device seat);

        public static Efl.Eo.FunctionWrapper<efl_canvas_pointer_inside_get_api_delegate> efl_canvas_pointer_inside_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_pointer_inside_get_api_delegate>(Module, "efl_canvas_pointer_inside_get");

        private static bool pointer_inside_get(System.IntPtr obj, System.IntPtr pd, Efl.Input.Device seat)
        {
            Eina.Log.Debug("function efl_canvas_pointer_inside_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IPointer)wrapper).GetPointerInside(seat);
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
                return efl_canvas_pointer_inside_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), seat);
            }
        }

        private static efl_canvas_pointer_inside_get_delegate efl_canvas_pointer_inside_get_static_delegate;

        #pragma warning restore CA1707, SA1300, SA1600

}
}
}

}

