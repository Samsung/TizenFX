#define EFL_BETA
#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Canvas {

/// <summary>Native surfaces usually bound to an externally-managed buffer.
/// The attached <see cref="Efl.Canvas.Surface.NativeBuffer"/> is entirely platform-dependent, which means some of this mixin&apos;s subclasses will not work (constructor returns <c>null</c>) on some platforms. This class is meant to be used from native code only (C or C++), with direct access to the display system or a buffer allocation system.</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Canvas.Surface.NativeMethods]
[Efl.Eo.BindingEntity]
public abstract class Surface : Efl.Canvas.ImageInternal
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(Surface))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] internal static extern System.IntPtr
        efl_canvas_surface_class_get();

    /// <summary>Initializes a new instance of the <see cref="Surface"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public Surface(Efl.Object parent= null
            ) : base(efl_canvas_surface_class_get(), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected Surface(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Surface"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected Surface(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    [Efl.Eo.PrivateNativeClass]
    private class SurfaceRealized : Surface
    {
        private SurfaceRealized(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
        {
        }
    }
    /// <summary>Initializes a new instance of the <see cref="Surface"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected Surface(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }


    /// <summary>External buffer attached to this native surface.
    /// Set to <c>null</c> to detach this surface from the external buffer.</summary>
    /// <returns>The external buffer, depends on its type.</returns>
    public virtual System.IntPtr GetNativeBuffer() {
        var _ret_var = Efl.Canvas.Surface.NativeMethods.efl_canvas_surface_native_buffer_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Set the buffer. If this fails, this function returns <c>false</c>, and the surface is left without any attached buffer.</summary>
    /// <param name="buffer">The external buffer, depends on its type.</param>
    /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
    public virtual bool SetNativeBuffer(System.IntPtr buffer) {
        var _ret_var = Efl.Canvas.Surface.NativeMethods.efl_canvas_surface_native_buffer_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),buffer);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>External buffer attached to this native surface.
    /// Set to <c>null</c> to detach this surface from the external buffer.</summary>
    /// <value>The external buffer, depends on its type.</value>
    public System.IntPtr NativeBuffer {
        get { return GetNativeBuffer(); }
        set { SetNativeBuffer(value); }
    }

    private static IntPtr GetEflClassStatic()
    {
        return Efl.Canvas.Surface.efl_canvas_surface_class_get();
    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Canvas.ImageInternal.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(efl.Libs.Evas);

        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_canvas_surface_native_buffer_get_static_delegate == null)
            {
                efl_canvas_surface_native_buffer_get_static_delegate = new efl_canvas_surface_native_buffer_get_delegate(native_buffer_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetNativeBuffer") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_surface_native_buffer_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_surface_native_buffer_get_static_delegate) });
            }

            if (efl_canvas_surface_native_buffer_set_static_delegate == null)
            {
                efl_canvas_surface_native_buffer_set_static_delegate = new efl_canvas_surface_native_buffer_set_delegate(native_buffer_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetNativeBuffer") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_surface_native_buffer_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_surface_native_buffer_set_static_delegate) });
            }

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
            descs.AddRange(base.GetEoOps(type, false));
            return descs;
        }

        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Canvas.Surface.efl_canvas_surface_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate System.IntPtr efl_canvas_surface_native_buffer_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate System.IntPtr efl_canvas_surface_native_buffer_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_canvas_surface_native_buffer_get_api_delegate> efl_canvas_surface_native_buffer_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_surface_native_buffer_get_api_delegate>(Module, "efl_canvas_surface_native_buffer_get");

        private static System.IntPtr native_buffer_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_canvas_surface_native_buffer_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                System.IntPtr _ret_var = default(System.IntPtr);
                try
                {
                    _ret_var = ((Surface)ws.Target).GetNativeBuffer();
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
                return efl_canvas_surface_native_buffer_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_canvas_surface_native_buffer_get_delegate efl_canvas_surface_native_buffer_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_canvas_surface_native_buffer_set_delegate(System.IntPtr obj, System.IntPtr pd,  System.IntPtr buffer);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_canvas_surface_native_buffer_set_api_delegate(System.IntPtr obj,  System.IntPtr buffer);

        public static Efl.Eo.FunctionWrapper<efl_canvas_surface_native_buffer_set_api_delegate> efl_canvas_surface_native_buffer_set_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_surface_native_buffer_set_api_delegate>(Module, "efl_canvas_surface_native_buffer_set");

        private static bool native_buffer_set(System.IntPtr obj, System.IntPtr pd, System.IntPtr buffer)
        {
            Eina.Log.Debug("function efl_canvas_surface_native_buffer_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Surface)ws.Target).SetNativeBuffer(buffer);
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
                return efl_canvas_surface_native_buffer_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), buffer);
            }
        }

        private static efl_canvas_surface_native_buffer_set_delegate efl_canvas_surface_native_buffer_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}
}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_CanvasSurface_ExtensionMethods {
    public static Efl.BindableProperty<System.IntPtr> NativeBuffer<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Surface, T>magic = null) where T : Efl.Canvas.Surface {
        return new Efl.BindableProperty<System.IntPtr>("native_buffer", fac);
    }

}
#pragma warning restore CS1591
#endif
