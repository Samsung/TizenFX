#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Ui {

[Efl.Ui.IDirectionReadonlyConcrete.NativeMethods]
public interface IDirectionReadonly : 
    Efl.Ui.IDirection ,
    Efl.Eo.IWrapper, IDisposable
{
}
sealed public class IDirectionReadonlyConcrete : 

IDirectionReadonly
    , Efl.Ui.IDirection
{
    ///<summary>Pointer to the native class description.</summary>
    public System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(IDirectionReadonlyConcrete))
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
        efl_ui_direction_readonly_mixin_get();
    /// <summary>Initializes a new instance of the <see cref="IDirectionReadonly"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    private IDirectionReadonlyConcrete(System.IntPtr raw)
    {
        handle = raw;
    }
    ///<summary>Destructor.</summary>
    ~IDirectionReadonlyConcrete()
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

    /// <summary>Control the direction of a given widget.
    /// Use this function to change how your widget is to be disposed: vertically or horizontally or inverted vertically or inverted horizontally.
    /// 
    /// Mirroring as defined in <see cref="Efl.Ui.II18n"/> can invert the <c>horizontal</c> direction: it is <c>ltr</c> by default, but becomes <c>rtl</c> if the object is mirrored.</summary>
    /// <returns>Direction of the widget.</returns>
    public Efl.Ui.Dir GetDirection() {
         var _ret_var = Efl.Ui.IDirectionConcrete.NativeMethods.efl_ui_direction_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Control the direction of a given widget.
    /// Use this function to change how your widget is to be disposed: vertically or horizontally or inverted vertically or inverted horizontally.
    /// 
    /// Mirroring as defined in <see cref="Efl.Ui.II18n"/> can invert the <c>horizontal</c> direction: it is <c>ltr</c> by default, but becomes <c>rtl</c> if the object is mirrored.</summary>
    /// <param name="dir">Direction of the widget.</param>
    public void SetDirection(Efl.Ui.Dir dir) {
                                 Efl.Ui.IDirectionConcrete.NativeMethods.efl_ui_direction_set_ptr.Value.Delegate(this.NativeHandle,dir);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Control the direction of a given widget.
/// Use this function to change how your widget is to be disposed: vertically or horizontally or inverted vertically or inverted horizontally.
/// 
/// Mirroring as defined in <see cref="Efl.Ui.II18n"/> can invert the <c>horizontal</c> direction: it is <c>ltr</c> by default, but becomes <c>rtl</c> if the object is mirrored.</summary>
/// <value>Direction of the widget.</value>
    public Efl.Ui.Dir Direction {
        get { return GetDirection(); }
        set { SetDirection(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.IDirectionReadonlyConcrete.efl_ui_direction_readonly_mixin_get();
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

            if (efl_ui_direction_get_static_delegate == null)
            {
                efl_ui_direction_get_static_delegate = new efl_ui_direction_get_delegate(direction_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetDirection") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_direction_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_direction_get_static_delegate) });
            }

            if (efl_ui_direction_set_static_delegate == null)
            {
                efl_ui_direction_set_static_delegate = new efl_ui_direction_set_delegate(direction_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetDirection") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_direction_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_direction_set_static_delegate) });
            }

            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.IDirectionReadonlyConcrete.efl_ui_direction_readonly_mixin_get();
        }

        #pragma warning disable CA1707, SA1300, SA1600

        
        private delegate Efl.Ui.Dir efl_ui_direction_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.Ui.Dir efl_ui_direction_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_direction_get_api_delegate> efl_ui_direction_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_direction_get_api_delegate>(Module, "efl_ui_direction_get");

        private static Efl.Ui.Dir direction_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_direction_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            Efl.Ui.Dir _ret_var = default(Efl.Ui.Dir);
                try
                {
                    _ret_var = ((IDirectionReadonlyConcrete)wrapper).GetDirection();
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
                return efl_ui_direction_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_direction_get_delegate efl_ui_direction_get_static_delegate;

        
        private delegate void efl_ui_direction_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.Dir dir);

        
        public delegate void efl_ui_direction_set_api_delegate(System.IntPtr obj,  Efl.Ui.Dir dir);

        public static Efl.Eo.FunctionWrapper<efl_ui_direction_set_api_delegate> efl_ui_direction_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_direction_set_api_delegate>(Module, "efl_ui_direction_set");

        private static void direction_set(System.IntPtr obj, System.IntPtr pd, Efl.Ui.Dir dir)
        {
            Eina.Log.Debug("function efl_ui_direction_set was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    
                try
                {
                    ((IDirectionReadonlyConcrete)wrapper).SetDirection(dir);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_direction_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), dir);
            }
        }

        private static efl_ui_direction_set_delegate efl_ui_direction_set_static_delegate;

        #pragma warning restore CA1707, SA1300, SA1600

}
}
}

}

