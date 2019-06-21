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

/// <summary>This class ensures that the root is at least focusable, if nothing else is focusable</summary>
[Efl.Ui.Focus.ManagerRootFocus.NativeMethods]
public class ManagerRootFocus : Efl.Ui.Focus.ManagerCalc
{
    ///<summary>Pointer to the native class description.</summary>
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
            ) : base(efl_ui_focus_manager_root_focus_class_get(), typeof(ManagerRootFocus), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Initializes a new instance of the <see cref="ManagerRootFocus"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="raw">The native pointer to be wrapped.</param>
    protected ManagerRootFocus(System.IntPtr raw) : base(raw)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="ManagerRootFocus"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="managedType">The managed type of the public constructor that originated this call.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected ManagerRootFocus(IntPtr baseKlass, System.Type managedType, Efl.Object parent) : base(baseKlass, managedType, parent)
    {
    }

    /// <summary>The default replacement object for the case that there is no focusable object inside the manager is the root object. However, you can change this by setting this value to something else. <c>null</c> is triggered as the same value as Efl.Ui.Focus.Manager.root.get</summary>
    /// <returns>Canvas object</returns>
    virtual public Efl.Canvas.Object GetCanvasObject() {
         var _ret_var = Efl.Ui.Focus.ManagerRootFocus.NativeMethods.efl_ui_focus_manager_root_focus_canvas_object_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The default replacement object for the case that there is no focusable object inside the manager is the root object. However, you can change this by setting this value to something else. <c>null</c> is triggered as the same value as Efl.Ui.Focus.Manager.root.get</summary>
    /// <param name="canvas_object">Canvas object</param>
    virtual public void SetCanvasObject(Efl.Canvas.Object canvas_object) {
                                 Efl.Ui.Focus.ManagerRootFocus.NativeMethods.efl_ui_focus_manager_root_focus_canvas_object_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),canvas_object);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The default replacement object for the case that there is no focusable object inside the manager is the root object. However, you can change this by setting this value to something else. <c>null</c> is triggered as the same value as Efl.Ui.Focus.Manager.root.get</summary>
    /// <value>Canvas object</value>
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
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
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

            descs.AddRange(base.GetEoOps(type));
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

