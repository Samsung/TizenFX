#define EFL_BETA
#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

/// <summary>EFL object that provide a model to all.
/// You can use this when you would otherwise have to call <see cref="Efl.Ui.IView.SetModel"/> on multiple widgets by registering this object using <see cref="Efl.Object.ProviderRegister"/> on a parent that they all depends on.</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.ModelProvider.NativeMethods]
[Efl.Eo.BindingEntity]
public class ModelProvider : Efl.Object, Efl.Ui.IView
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(ModelProvider))
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
        efl_model_provider_class_get();
    /// <summary>Initializes a new instance of the <see cref="ModelProvider"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public ModelProvider(Efl.Object parent= null
            ) : base(efl_model_provider_class_get(), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected ModelProvider(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="ModelProvider"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected ModelProvider(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="ModelProvider"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected ModelProvider(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }

    /// <summary>Event dispatched when a new model is set.</summary>
    /// <value><see cref="Efl.Ui.IViewModelChangedEvt_Args"/></value>
    public event EventHandler<Efl.Ui.IViewModelChangedEvt_Args> ModelChangedEvt
    {
        add
        {
            lock (eflBindingEventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        Efl.Ui.IViewModelChangedEvt_Args args = new Efl.Ui.IViewModelChangedEvt_Args();
                        args.arg =  evt.Info;
                        try
                        {
                            value?.Invoke(obj, args);
                        }
                        catch (Exception e)
                        {
                            Eina.Log.Error(e.ToString());
                            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                        }
                    }
                };

                string key = "_EFL_UI_VIEW_EVENT_MODEL_CHANGED";
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_VIEW_EVENT_MODEL_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    /// <summary>Method to raise event ModelChangedEvt.</summary>
    public void OnModelChangedEvt(Efl.Ui.IViewModelChangedEvt_Args e)
    {
        var key = "_EFL_UI_VIEW_EVENT_MODEL_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = Marshal.AllocHGlobal(Marshal.SizeOf(e.arg));
        try
        {
            Marshal.StructureToPtr(e.arg, info, false);
            Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Marshal.FreeHGlobal(info);
        }
    }
    /// <summary>Model that is/will be</summary>
    /// <returns>Efl model</returns>
    virtual public Efl.IModel GetModel() {
         var _ret_var = Efl.Ui.IViewConcrete.NativeMethods.efl_ui_view_model_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Model that is/will be</summary>
    /// <param name="model">Efl model</param>
    virtual public void SetModel(Efl.IModel model) {
                                 Efl.Ui.IViewConcrete.NativeMethods.efl_ui_view_model_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),model);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Model that is/will be</summary>
    /// <value>Efl model</value>
    public Efl.IModel Model {
        get { return GetModel(); }
        set { SetModel(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.ModelProvider.efl_model_provider_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Object.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Efl);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_ui_view_model_get_static_delegate == null)
            {
                efl_ui_view_model_get_static_delegate = new efl_ui_view_model_get_delegate(model_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetModel") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_view_model_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_view_model_get_static_delegate) });
            }

            if (efl_ui_view_model_set_static_delegate == null)
            {
                efl_ui_view_model_set_static_delegate = new efl_ui_view_model_set_delegate(model_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetModel") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_view_model_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_view_model_set_static_delegate) });
            }

            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.ModelProvider.efl_model_provider_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.IModel efl_ui_view_model_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.IModel efl_ui_view_model_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_view_model_get_api_delegate> efl_ui_view_model_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_view_model_get_api_delegate>(Module, "efl_ui_view_model_get");

        private static Efl.IModel model_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_view_model_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.IModel _ret_var = default(Efl.IModel);
                try
                {
                    _ret_var = ((ModelProvider)ws.Target).GetModel();
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
                return efl_ui_view_model_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_view_model_get_delegate efl_ui_view_model_get_static_delegate;

        
        private delegate void efl_ui_view_model_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.IModel model);

        
        public delegate void efl_ui_view_model_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.IModel model);

        public static Efl.Eo.FunctionWrapper<efl_ui_view_model_set_api_delegate> efl_ui_view_model_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_view_model_set_api_delegate>(Module, "efl_ui_view_model_set");

        private static void model_set(System.IntPtr obj, System.IntPtr pd, Efl.IModel model)
        {
            Eina.Log.Debug("function efl_ui_view_model_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((ModelProvider)ws.Target).SetModel(model);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_view_model_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), model);
            }
        }

        private static efl_ui_view_model_set_delegate efl_ui_view_model_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

#if EFL_BETA
#pragma warning disable CS1591
public static class EflModelProvider_ExtensionMethods {
    public static Efl.BindableProperty<Efl.IModel> Model<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.ModelProvider, T>magic = null) where T : Efl.ModelProvider {
        return new Efl.BindableProperty<Efl.IModel>("model", fac);
    }

}
#pragma warning restore CS1591
#endif
