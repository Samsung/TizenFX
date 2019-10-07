#define EFL_BETA
#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Gfx {

/// <summary>Efl Gfx Size Class interface</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Gfx.SizeClassConcrete.NativeMethods]
[Efl.Eo.BindingEntity]
public interface ISizeClass : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Width and height of size class.
    /// This property sets width and height for a size class. This will make all edje parts in the specified object that have the specified size class update their size with given values. When reading, these values will only be valid until the size class is changed or the edje object is deleted.</summary>
    /// <param name="size_class">The name of size class</param>
    /// <param name="minw">minimum width</param>
    /// <param name="minh">minimum height</param>
    /// <param name="maxw">maximum width</param>
    /// <param name="maxh">maximum height</param>
    /// <returns><c>true</c>, on success or <c>false</c>, on error</returns>
    bool GetSizeClass(System.String size_class, out int minw, out int minh, out int maxw, out int maxh);

    /// <summary>Width and height of size class.
    /// This property sets width and height for a size class. This will make all edje parts in the specified object that have the specified size class update their size with given values. When reading, these values will only be valid until the size class is changed or the edje object is deleted.</summary>
    /// <param name="size_class">The name of size class</param>
    /// <param name="minw">minimum width</param>
    /// <param name="minh">minimum height</param>
    /// <param name="maxw">maximum width</param>
    /// <param name="maxh">maximum height</param>
    /// <returns><c>true</c>, on success or <c>false</c>, on error</returns>
    bool SetSizeClass(System.String size_class, int minw, int minh, int maxw, int maxh);

    /// <summary>Delete the size class.
    /// This function deletes any values for the specified size class.
    /// 
    /// Deleting the size class will revert it to the values defined by <see cref="Efl.Gfx.ISizeClass.GetSizeClass"/> or the size class defined in the theme file.</summary>
    /// <param name="size_class">The size class to be deleted.</param>
    void DelSizeClass(System.String size_class);

}

/// <summary>Efl Gfx Size Class interface</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
public sealed class SizeClassConcrete :
    Efl.Eo.EoWrapper
    , ISizeClass
    
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(SizeClassConcrete))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    private SizeClassConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
        efl_gfx_size_class_interface_get();

    /// <summary>Initializes a new instance of the <see cref="ISizeClass"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private SizeClassConcrete(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

#pragma warning disable CS0628
    /// <summary>Width and height of size class.
    /// This property sets width and height for a size class. This will make all edje parts in the specified object that have the specified size class update their size with given values. When reading, these values will only be valid until the size class is changed or the edje object is deleted.</summary>
    /// <param name="size_class">The name of size class</param>
    /// <param name="minw">minimum width</param>
    /// <param name="minh">minimum height</param>
    /// <param name="maxw">maximum width</param>
    /// <param name="maxh">maximum height</param>
    /// <returns><c>true</c>, on success or <c>false</c>, on error</returns>
    public bool GetSizeClass(System.String size_class, out int minw, out int minh, out int maxw, out int maxh) {
        var _ret_var = Efl.Gfx.SizeClassConcrete.NativeMethods.efl_gfx_size_class_get_ptr.Value.Delegate(this.NativeHandle,size_class, out minw, out minh, out maxw, out maxh);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Width and height of size class.
    /// This property sets width and height for a size class. This will make all edje parts in the specified object that have the specified size class update their size with given values. When reading, these values will only be valid until the size class is changed or the edje object is deleted.</summary>
    /// <param name="size_class">The name of size class</param>
    /// <param name="minw">minimum width</param>
    /// <param name="minh">minimum height</param>
    /// <param name="maxw">maximum width</param>
    /// <param name="maxh">maximum height</param>
    /// <returns><c>true</c>, on success or <c>false</c>, on error</returns>
    public bool SetSizeClass(System.String size_class, int minw, int minh, int maxw, int maxh) {
        var _ret_var = Efl.Gfx.SizeClassConcrete.NativeMethods.efl_gfx_size_class_set_ptr.Value.Delegate(this.NativeHandle,size_class, minw, minh, maxw, maxh);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Delete the size class.
    /// This function deletes any values for the specified size class.
    /// 
    /// Deleting the size class will revert it to the values defined by <see cref="Efl.Gfx.ISizeClass.GetSizeClass"/> or the size class defined in the theme file.</summary>
    /// <param name="size_class">The size class to be deleted.</param>
    public void DelSizeClass(System.String size_class) {
        Efl.Gfx.SizeClassConcrete.NativeMethods.efl_gfx_size_class_del_ptr.Value.Delegate(this.NativeHandle,size_class);
        Eina.Error.RaiseIfUnhandledException();
        
    }

#pragma warning restore CS0628
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Gfx.SizeClassConcrete.efl_gfx_size_class_interface_get();
    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Eo.EoWrapper.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(efl.Libs.Efl);

        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_gfx_size_class_get_static_delegate == null)
            {
                efl_gfx_size_class_get_static_delegate = new efl_gfx_size_class_get_delegate(size_class_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetSizeClass") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_size_class_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_size_class_get_static_delegate) });
            }

            if (efl_gfx_size_class_set_static_delegate == null)
            {
                efl_gfx_size_class_set_static_delegate = new efl_gfx_size_class_set_delegate(size_class_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetSizeClass") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_size_class_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_size_class_set_static_delegate) });
            }

            if (efl_gfx_size_class_del_static_delegate == null)
            {
                efl_gfx_size_class_del_static_delegate = new efl_gfx_size_class_del_delegate(size_class_del);
            }

            if (methods.FirstOrDefault(m => m.Name == "DelSizeClass") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_size_class_del"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_size_class_del_static_delegate) });
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
            return descs;
        }

        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Gfx.SizeClassConcrete.efl_gfx_size_class_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_gfx_size_class_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String size_class,  out int minw,  out int minh,  out int maxw,  out int maxh);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_gfx_size_class_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String size_class,  out int minw,  out int minh,  out int maxw,  out int maxh);

        public static Efl.Eo.FunctionWrapper<efl_gfx_size_class_get_api_delegate> efl_gfx_size_class_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_size_class_get_api_delegate>(Module, "efl_gfx_size_class_get");

        private static bool size_class_get(System.IntPtr obj, System.IntPtr pd, System.String size_class, out int minw, out int minh, out int maxw, out int maxh)
        {
            Eina.Log.Debug("function efl_gfx_size_class_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                minw = default(int);minh = default(int);maxw = default(int);maxh = default(int);bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((ISizeClass)ws.Target).GetSizeClass(size_class, out minw, out minh, out maxw, out maxh);
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
                return efl_gfx_size_class_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), size_class, out minw, out minh, out maxw, out maxh);
            }
        }

        private static efl_gfx_size_class_get_delegate efl_gfx_size_class_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_gfx_size_class_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String size_class,  int minw,  int minh,  int maxw,  int maxh);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_gfx_size_class_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String size_class,  int minw,  int minh,  int maxw,  int maxh);

        public static Efl.Eo.FunctionWrapper<efl_gfx_size_class_set_api_delegate> efl_gfx_size_class_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_size_class_set_api_delegate>(Module, "efl_gfx_size_class_set");

        private static bool size_class_set(System.IntPtr obj, System.IntPtr pd, System.String size_class, int minw, int minh, int maxw, int maxh)
        {
            Eina.Log.Debug("function efl_gfx_size_class_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((ISizeClass)ws.Target).SetSizeClass(size_class, minw, minh, maxw, maxh);
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
                return efl_gfx_size_class_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), size_class, minw, minh, maxw, maxh);
            }
        }

        private static efl_gfx_size_class_set_delegate efl_gfx_size_class_set_static_delegate;

        
        private delegate void efl_gfx_size_class_del_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String size_class);

        
        public delegate void efl_gfx_size_class_del_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String size_class);

        public static Efl.Eo.FunctionWrapper<efl_gfx_size_class_del_api_delegate> efl_gfx_size_class_del_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_size_class_del_api_delegate>(Module, "efl_gfx_size_class_del");

        private static void size_class_del(System.IntPtr obj, System.IntPtr pd, System.String size_class)
        {
            Eina.Log.Debug("function efl_gfx_size_class_del was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((ISizeClass)ws.Target).DelSizeClass(size_class);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_size_class_del_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), size_class);
            }
        }

        private static efl_gfx_size_class_del_delegate efl_gfx_size_class_del_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}
}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_GfxSizeClassConcrete_ExtensionMethods {
}
#pragma warning restore CS1591
#endif
