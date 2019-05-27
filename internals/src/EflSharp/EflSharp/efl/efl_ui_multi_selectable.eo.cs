#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Ui {

/// <summary>Efl UI Multi selectable interface. The container have to control select property of multiple chidren.</summary>
[Efl.Ui.IMultiSelectableConcrete.NativeMethods]
public interface IMultiSelectable : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>The mode type for children selection.</summary>
/// <returns>Type of selection of children</returns>
Efl.Ui.SelectMode GetSelectMode();
    /// <summary>The mode type for children selection.</summary>
/// <param name="mode">Type of selection of children</param>
void SetSelectMode(Efl.Ui.SelectMode mode);
            /// <summary>The mode type for children selection.</summary>
/// <value>Type of selection of children</value>
    Efl.Ui.SelectMode SelectMode {
        get ;
        set ;
    }
}
/// <summary>Efl UI Multi selectable interface. The container have to control select property of multiple chidren.</summary>
sealed public class IMultiSelectableConcrete : 

IMultiSelectable
    
{
    ///<summary>Pointer to the native class description.</summary>
    public System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(IMultiSelectableConcrete))
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
        efl_ui_multi_selectable_interface_get();
    /// <summary>Initializes a new instance of the <see cref="IMultiSelectable"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    private IMultiSelectableConcrete(System.IntPtr raw)
    {
        handle = raw;
    }
    ///<summary>Destructor.</summary>
    ~IMultiSelectableConcrete()
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

    /// <summary>The mode type for children selection.</summary>
    /// <returns>Type of selection of children</returns>
    public Efl.Ui.SelectMode GetSelectMode() {
         var _ret_var = Efl.Ui.IMultiSelectableConcrete.NativeMethods.efl_ui_select_mode_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The mode type for children selection.</summary>
    /// <param name="mode">Type of selection of children</param>
    public void SetSelectMode(Efl.Ui.SelectMode mode) {
                                 Efl.Ui.IMultiSelectableConcrete.NativeMethods.efl_ui_select_mode_set_ptr.Value.Delegate(this.NativeHandle,mode);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The mode type for children selection.</summary>
/// <value>Type of selection of children</value>
    public Efl.Ui.SelectMode SelectMode {
        get { return GetSelectMode(); }
        set { SetSelectMode(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.IMultiSelectableConcrete.efl_ui_multi_selectable_interface_get();
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

            if (efl_ui_select_mode_get_static_delegate == null)
            {
                efl_ui_select_mode_get_static_delegate = new efl_ui_select_mode_get_delegate(select_mode_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetSelectMode") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_select_mode_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_select_mode_get_static_delegate) });
            }

            if (efl_ui_select_mode_set_static_delegate == null)
            {
                efl_ui_select_mode_set_static_delegate = new efl_ui_select_mode_set_delegate(select_mode_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetSelectMode") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_select_mode_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_select_mode_set_static_delegate) });
            }

            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.IMultiSelectableConcrete.efl_ui_multi_selectable_interface_get();
        }

        #pragma warning disable CA1707, SA1300, SA1600

        
        private delegate Efl.Ui.SelectMode efl_ui_select_mode_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.Ui.SelectMode efl_ui_select_mode_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_select_mode_get_api_delegate> efl_ui_select_mode_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_select_mode_get_api_delegate>(Module, "efl_ui_select_mode_get");

        private static Efl.Ui.SelectMode select_mode_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_select_mode_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            Efl.Ui.SelectMode _ret_var = default(Efl.Ui.SelectMode);
                try
                {
                    _ret_var = ((IMultiSelectable)wrapper).GetSelectMode();
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
                return efl_ui_select_mode_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_select_mode_get_delegate efl_ui_select_mode_get_static_delegate;

        
        private delegate void efl_ui_select_mode_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.SelectMode mode);

        
        public delegate void efl_ui_select_mode_set_api_delegate(System.IntPtr obj,  Efl.Ui.SelectMode mode);

        public static Efl.Eo.FunctionWrapper<efl_ui_select_mode_set_api_delegate> efl_ui_select_mode_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_select_mode_set_api_delegate>(Module, "efl_ui_select_mode_set");

        private static void select_mode_set(System.IntPtr obj, System.IntPtr pd, Efl.Ui.SelectMode mode)
        {
            Eina.Log.Debug("function efl_ui_select_mode_set was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    
                try
                {
                    ((IMultiSelectable)wrapper).SetSelectMode(mode);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_select_mode_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), mode);
            }
        }

        private static efl_ui_select_mode_set_delegate efl_ui_select_mode_set_static_delegate;

        #pragma warning restore CA1707, SA1300, SA1600

}
}
}

}

namespace Efl {

namespace Ui {

/// <summary>Type of multi selectable object.</summary>
public enum SelectMode
{
/// <summary>Only single child is selected. if the child is selected, previous selected child will be unselected.</summary>
Single = 0,
/// <summary>Same as single select except, this will be selected in every select calls though child is already been selected.</summary>
SingleAlways = 1,
/// <summary>allow multiple selection of children.</summary>
Multi = 2,
/// <summary>Last value of select mode. child cannot be selected at all.</summary>
None = 3,
}

}

}

