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

/// <summary>This class ensures that the root is at least focusable, if nothing else is focusable.</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Ui.Focus.ManagerRootFocus.NativeMethods]
[Efl.Eo.BindingEntity]
public class ManagerRootFocus : Efl.Ui.Focus.ManagerCalc
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(ManagerRootFocus))
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
        efl_ui_focus_manager_root_focus_class_get();
    /// <summary>Initializes a new instance of the <see cref="ManagerRootFocus"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public ManagerRootFocus(Efl.Object parent= null
            ) : base(efl_ui_focus_manager_root_focus_class_get(), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected ManagerRootFocus(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="ManagerRootFocus"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected ManagerRootFocus(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="ManagerRootFocus"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected ManagerRootFocus(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }

    /// <summary>The default replacement object to use when there is no focusable object inside the manager. You can change this object by setting this value to something else. <c>null</c> means that the same value as <see cref="Efl.Ui.Focus.IManager.Root"/> will be used.</summary>
    /// <returns>Canvas object.</returns>
    public virtual Efl.Canvas.Object GetCanvasObject() {
         var _ret_var = Efl.Ui.Focus.ManagerRootFocus.NativeMethods.efl_ui_focus_manager_root_focus_canvas_object_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The default replacement object to use when there is no focusable object inside the manager. You can change this object by setting this value to something else. <c>null</c> means that the same value as <see cref="Efl.Ui.Focus.IManager.Root"/> will be used.</summary>
    /// <param name="canvas_object">Canvas object.</param>
    public virtual void SetCanvasObject(Efl.Canvas.Object canvas_object) {
                                 Efl.Ui.Focus.ManagerRootFocus.NativeMethods.efl_ui_focus_manager_root_focus_canvas_object_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),canvas_object);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The default replacement object to use when there is no focusable object inside the manager. You can change this object by setting this value to something else. <c>null</c> means that the same value as <see cref="Efl.Ui.Focus.IManager.Root"/> will be used.</summary>
    /// <value>Canvas object.</value>
    public Efl.Canvas.Object CanvasObject {
        get { return GetCanvasObject(); }
        set { SetCanvasObject(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.Focus.ManagerRootFocus.efl_ui_focus_manager_root_focus_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Ui.Focus.ManagerCalc.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Elementary);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_ui_focus_manager_root_focus_canvas_object_get_static_delegate == null)
            {
                efl_ui_focus_manager_root_focus_canvas_object_get_static_delegate = new efl_ui_focus_manager_root_focus_canvas_object_get_delegate(canvas_object_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetCanvasObject") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_focus_manager_root_focus_canvas_object_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_manager_root_focus_canvas_object_get_static_delegate) });
            }

            if (efl_ui_focus_manager_root_focus_canvas_object_set_static_delegate == null)
            {
                efl_ui_focus_manager_root_focus_canvas_object_set_static_delegate = new efl_ui_focus_manager_root_focus_canvas_object_set_delegate(canvas_object_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetCanvasObject") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_focus_manager_root_focus_canvas_object_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_manager_root_focus_canvas_object_set_static_delegate) });
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
            return Efl.Ui.Focus.ManagerRootFocus.efl_ui_focus_manager_root_focus_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Canvas.Object efl_ui_focus_manager_root_focus_canvas_object_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Canvas.Object efl_ui_focus_manager_root_focus_canvas_object_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_focus_manager_root_focus_canvas_object_get_api_delegate> efl_ui_focus_manager_root_focus_canvas_object_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_manager_root_focus_canvas_object_get_api_delegate>(Module, "efl_ui_focus_manager_root_focus_canvas_object_get");

        private static Efl.Canvas.Object canvas_object_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_focus_manager_root_focus_canvas_object_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Canvas.Object _ret_var = default(Efl.Canvas.Object);
                try
                {
                    _ret_var = ((ManagerRootFocus)ws.Target).GetCanvasObject();
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
                return efl_ui_focus_manager_root_focus_canvas_object_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_focus_manager_root_focus_canvas_object_get_delegate efl_ui_focus_manager_root_focus_canvas_object_get_static_delegate;

        
        private delegate void efl_ui_focus_manager_root_focus_canvas_object_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Object canvas_object);

        
        public delegate void efl_ui_focus_manager_root_focus_canvas_object_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Object canvas_object);

        public static Efl.Eo.FunctionWrapper<efl_ui_focus_manager_root_focus_canvas_object_set_api_delegate> efl_ui_focus_manager_root_focus_canvas_object_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_manager_root_focus_canvas_object_set_api_delegate>(Module, "efl_ui_focus_manager_root_focus_canvas_object_set");

        private static void canvas_object_set(System.IntPtr obj, System.IntPtr pd, Efl.Canvas.Object canvas_object)
        {
            Eina.Log.Debug("function efl_ui_focus_manager_root_focus_canvas_object_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((ManagerRootFocus)ws.Target).SetCanvasObject(canvas_object);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_focus_manager_root_focus_canvas_object_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), canvas_object);
            }
        }

        private static efl_ui_focus_manager_root_focus_canvas_object_set_delegate efl_ui_focus_manager_root_focus_canvas_object_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_Ui_FocusManagerRootFocus_ExtensionMethods {
    public static Efl.BindableProperty<Efl.Canvas.Object> CanvasObject<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Focus.ManagerRootFocus, T>magic = null) where T : Efl.Ui.Focus.ManagerRootFocus {
        return new Efl.BindableProperty<Efl.Canvas.Object>("canvas_object", fac);
    }

}
#pragma warning restore CS1591
#endif
