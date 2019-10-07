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

/// <summary>This class provide a utility function that class that wish to use Efl.Ui.Factory.create should use.</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Ui.ViewFactory.NativeMethods]
[Efl.Eo.BindingEntity]
public class ViewFactory : Efl.Eo.EoWrapper
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(ViewFactory))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
        efl_ui_view_factory_class_get();

    /// <summary>Initializes a new instance of the <see cref="ViewFactory"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public ViewFactory(Efl.Object parent= null
            ) : base(efl_ui_view_factory_class_get(), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected ViewFactory(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="ViewFactory"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected ViewFactory(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="ViewFactory"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected ViewFactory(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }

    /// <summary>Create a UI object from the necessary properties in the specified model and generate the created event on the factory when the object is done building. This function must be use by all <see cref="Efl.Ui.IView"/> that need to create object. They should not use Efl.Ui.Factory.create directly.</summary>
    /// <param name="factory">The factory to use for requesting the new object from and generating the created event onto.</param>
    /// <param name="models">Efl iterator providing the model to be associated to the new item. It should remain valid until the end of the function call.</param>
    /// <returns>Created UI object</returns>
    public static  Eina.Future CreateWithEvent(Efl.Ui.IFactory factory, Eina.Iterator<Efl.IModel> models) {
        var _in_models = models.Handle;
var _ret_var = Efl.Ui.ViewFactory.NativeMethods.efl_ui_view_factory_create_with_event_ptr.Value.Delegate(factory, _in_models);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.ViewFactory.efl_ui_view_factory_class_get();
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
            return Efl.Ui.ViewFactory.efl_ui_view_factory_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))]
        private delegate  Eina.Future efl_ui_view_factory_create_with_event_delegate([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Ui.IFactory factory,  System.IntPtr models);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))]
        public delegate  Eina.Future efl_ui_view_factory_create_with_event_api_delegate([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Ui.IFactory factory,  System.IntPtr models);

        public static Efl.Eo.FunctionWrapper<efl_ui_view_factory_create_with_event_api_delegate> efl_ui_view_factory_create_with_event_ptr = new Efl.Eo.FunctionWrapper<efl_ui_view_factory_create_with_event_api_delegate>(Module, "efl_ui_view_factory_create_with_event");

        private static  Eina.Future create_with_event(System.IntPtr obj, System.IntPtr pd, Efl.Ui.IFactory factory, System.IntPtr models)
        {
            Eina.Log.Debug("function efl_ui_view_factory_create_with_event was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                var _in_models = new Eina.Iterator<Efl.IModel>(models, false);
 Eina.Future _ret_var = default( Eina.Future);
                try
                {
                    _ret_var = ViewFactory.CreateWithEvent(factory, _in_models);
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
                return efl_ui_view_factory_create_with_event_ptr.Value.Delegate(factory, models);
            }
        }

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}
}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_UiViewFactory_ExtensionMethods {
}
#pragma warning restore CS1591
#endif
