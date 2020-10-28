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

/// <summary>Helper class that connects theme signals or object events to the interfaces which are for actions.
/// For example, this simplifies creating widgets that implement the <see cref="Efl.Input.IClickable"/> interface.</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Ui.ActionConnector.NativeMethods]
[Efl.Eo.BindingEntity]
public class ActionConnector : Efl.Eo.EoWrapper
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(ActionConnector))
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
        efl_ui_action_connector_class_get();
    /// <summary>Initializes a new instance of the <see cref="ActionConnector"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public ActionConnector(Efl.Object parent= null
            ) : base(efl_ui_action_connector_class_get(), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected ActionConnector(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="ActionConnector"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected ActionConnector(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="ActionConnector"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected ActionConnector(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }

    /// <summary>This will listen to the standard &quot;click&quot; events on a theme and emit the appropriate events through the <see cref="Efl.Input.IClickable"/> interface.
    /// Using these methods widgets do not need to listen to the theme signals. This class does it and calls the correct clickable functions.
    /// 
    /// This handles theme signals &quot;efl,action,press&quot;, &quot;efl,action,unpress&quot; and &quot;efl,action,mouse_out&quot;, and the <see cref="Efl.Input.IInterface.PointerMoveEvt"/> event.</summary>
    /// <param name="kw_object">The object to listen on.</param>
    /// <param name="clickable">The object to call the clickable methods on.</param>
    public static void BindClickableToTheme(Efl.Canvas.Layout kw_object, Efl.Input.IClickable clickable) {
                                                         Efl.Ui.ActionConnector.NativeMethods.efl_ui_action_connector_bind_clickable_to_theme_ptr.Value.Delegate(kw_object, clickable);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>This will listen to the standard &quot;click&quot; events on an object, and emit the appropriate events through the <see cref="Efl.Input.IClickable"/> interface.
    /// Using these methods widgets do not need to listen to the object events. This class does it and calls the correct clickable functions.
    /// 
    /// The handled events are <see cref="Efl.Input.IInterface.PointerUpEvt"/> and <see cref="Efl.Input.IInterface.PointerDownEvt"/>.</summary>
    /// <param name="kw_object">The object to listen on.</param>
    /// <param name="clickable">The object to call the clickable methods on.</param>
    public static void BindClickableToObject(Efl.Input.IInterface kw_object, Efl.Input.IClickable clickable) {
                                                         Efl.Ui.ActionConnector.NativeMethods.efl_ui_action_connector_bind_clickable_to_object_ptr.Value.Delegate(kw_object, clickable);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.ActionConnector.efl_ui_action_connector_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Eo.EoWrapper.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Elementary);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.ActionConnector.efl_ui_action_connector_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate void efl_ui_action_connector_bind_clickable_to_theme_delegate([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Layout kw_object, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Input.IClickable clickable);

        
        public delegate void efl_ui_action_connector_bind_clickable_to_theme_api_delegate([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Layout kw_object, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Input.IClickable clickable);

        public static Efl.Eo.FunctionWrapper<efl_ui_action_connector_bind_clickable_to_theme_api_delegate> efl_ui_action_connector_bind_clickable_to_theme_ptr = new Efl.Eo.FunctionWrapper<efl_ui_action_connector_bind_clickable_to_theme_api_delegate>(Module, "efl_ui_action_connector_bind_clickable_to_theme");

        private static void bind_clickable_to_theme(System.IntPtr obj, System.IntPtr pd, Efl.Canvas.Layout kw_object, Efl.Input.IClickable clickable)
        {
            Eina.Log.Debug("function efl_ui_action_connector_bind_clickable_to_theme was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ActionConnector.BindClickableToTheme(kw_object, clickable);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_action_connector_bind_clickable_to_theme_ptr.Value.Delegate(kw_object, clickable);
            }
        }

        
        private delegate void efl_ui_action_connector_bind_clickable_to_object_delegate([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Input.IInterface kw_object, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Input.IClickable clickable);

        
        public delegate void efl_ui_action_connector_bind_clickable_to_object_api_delegate([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Input.IInterface kw_object, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Input.IClickable clickable);

        public static Efl.Eo.FunctionWrapper<efl_ui_action_connector_bind_clickable_to_object_api_delegate> efl_ui_action_connector_bind_clickable_to_object_ptr = new Efl.Eo.FunctionWrapper<efl_ui_action_connector_bind_clickable_to_object_api_delegate>(Module, "efl_ui_action_connector_bind_clickable_to_object");

        private static void bind_clickable_to_object(System.IntPtr obj, System.IntPtr pd, Efl.Input.IInterface kw_object, Efl.Input.IClickable clickable)
        {
            Eina.Log.Debug("function efl_ui_action_connector_bind_clickable_to_object was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ActionConnector.BindClickableToObject(kw_object, clickable);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_action_connector_bind_clickable_to_object_ptr.Value.Delegate(kw_object, clickable);
            }
        }

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_UiActionConnector_ExtensionMethods {
}
#pragma warning restore CS1591
#endif
