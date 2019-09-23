#define EFL_BETA
#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Ui {

namespace Focus {

/// <summary>EFL UI Focus Utility class.
/// This class contains a series of static methods that simplify common focus management operations. There&apos;s no need to instantiate this class.</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Ui.Focus.Util.NativeMethods]
[Efl.Eo.BindingEntity]
public class Util : Efl.Object
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(Util))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_ui_focus_util_class_get();
    /// <summary>Initializes a new instance of the <see cref="Util"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public Util(Efl.Object parent= null
            ) : base(efl_ui_focus_util_class_get(), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected Util(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Util"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected Util(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Util"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected Util(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }

    /// <summary>Sets the focus to the given object.</summary>
    /// <param name="focus_elem">Object to receive focus.</param>
    public static void Focus(Efl.Ui.Focus.IObject focus_elem) {
                                 Efl.Ui.Focus.Util.NativeMethods.efl_ui_focus_util_focus_ptr.Value.Delegate(focus_elem);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Gets the highest manager in the redirect chain.</summary>
    /// <param name="manager">Manager to start looking from.</param>
    public static Efl.Ui.Focus.IManager ActiveManager(Efl.Ui.Focus.IManager manager) {
                                 var _ret_var = Efl.Ui.Focus.Util.NativeMethods.efl_ui_focus_util_active_manager_ptr.Value.Delegate(manager);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Returns the complementary (opposite) focus direction.
    /// The defined opposites are Left-Right, Up-Down and Next-Previous.</summary>
    /// <param name="dir">Direction to complement.</param>
    /// <returns>The opposite direction.</returns>
    public static Efl.Ui.Focus.Direction DirectionComplement(Efl.Ui.Focus.Direction dir) {
                                 var _ret_var = Efl.Ui.Focus.Util.NativeMethods.efl_ui_focus_util_direction_complement_ptr.Value.Delegate(dir);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.Focus.Util.efl_ui_focus_util_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Object.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Elementary);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
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
            return Efl.Ui.Focus.Util.efl_ui_focus_util_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate void efl_ui_focus_util_focus_delegate([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Ui.Focus.IObject focus_elem);

        
        public delegate void efl_ui_focus_util_focus_api_delegate([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Ui.Focus.IObject focus_elem);

        public static Efl.Eo.FunctionWrapper<efl_ui_focus_util_focus_api_delegate> efl_ui_focus_util_focus_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_util_focus_api_delegate>(Module, "efl_ui_focus_util_focus");

        private static void focus(System.IntPtr obj, System.IntPtr pd, Efl.Ui.Focus.IObject focus_elem)
        {
            Eina.Log.Debug("function efl_ui_focus_util_focus was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    Util.Focus(focus_elem);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_focus_util_focus_ptr.Value.Delegate(focus_elem);
            }
        }

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Ui.Focus.IManager efl_ui_focus_util_active_manager_delegate([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Ui.Focus.IManager manager);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Ui.Focus.IManager efl_ui_focus_util_active_manager_api_delegate([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Ui.Focus.IManager manager);

        public static Efl.Eo.FunctionWrapper<efl_ui_focus_util_active_manager_api_delegate> efl_ui_focus_util_active_manager_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_util_active_manager_api_delegate>(Module, "efl_ui_focus_util_active_manager");

        private static Efl.Ui.Focus.IManager active_manager(System.IntPtr obj, System.IntPtr pd, Efl.Ui.Focus.IManager manager)
        {
            Eina.Log.Debug("function efl_ui_focus_util_active_manager was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    Efl.Ui.Focus.IManager _ret_var = default(Efl.Ui.Focus.IManager);
                try
                {
                    _ret_var = Util.ActiveManager(manager);
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
                return efl_ui_focus_util_active_manager_ptr.Value.Delegate(manager);
            }
        }

        
        private delegate Efl.Ui.Focus.Direction efl_ui_focus_util_direction_complement_delegate( Efl.Ui.Focus.Direction dir);

        
        public delegate Efl.Ui.Focus.Direction efl_ui_focus_util_direction_complement_api_delegate( Efl.Ui.Focus.Direction dir);

        public static Efl.Eo.FunctionWrapper<efl_ui_focus_util_direction_complement_api_delegate> efl_ui_focus_util_direction_complement_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_util_direction_complement_api_delegate>(Module, "efl_ui_focus_util_direction_complement");

        private static Efl.Ui.Focus.Direction direction_complement(System.IntPtr obj, System.IntPtr pd, Efl.Ui.Focus.Direction dir)
        {
            Eina.Log.Debug("function efl_ui_focus_util_direction_complement was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    Efl.Ui.Focus.Direction _ret_var = default(Efl.Ui.Focus.Direction);
                try
                {
                    _ret_var = Util.DirectionComplement(dir);
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
                return efl_ui_focus_util_direction_complement_ptr.Value.Delegate(dir);
            }
        }

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_Ui_FocusUtil_ExtensionMethods {
}
#pragma warning restore CS1591
#endif
