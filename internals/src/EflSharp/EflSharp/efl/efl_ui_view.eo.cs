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

/// <summary>Efl UI view interface</summary>
[Efl.Ui.ViewConcrete.NativeMethods]
[Efl.Eo.BindingEntity]
public interface IView : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Model that is/will be</summary>
    /// <returns>Efl model</returns>
    Efl.IModel GetModel();

    /// <summary>Model that is/will be</summary>
    /// <param name="model">Efl model</param>
    void SetModel(Efl.IModel model);

    /// <summary>Event dispatched when a new model is set.</summary>
    /// <value><see cref="Efl.Ui.ViewModelChangedEventArgs"/></value>
    event EventHandler<Efl.Ui.ViewModelChangedEventArgs> ModelChangedEvent;
    /// <summary>Model that is/will be</summary>
    /// <value>Efl model</value>
    Efl.IModel Model {
        get;
        set;
    }

}

/// <summary>Event argument wrapper for event <see cref="Efl.Ui.IView.ModelChangedEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class ViewModelChangedEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Event dispatched when a new model is set.</value>
    public Efl.ModelChangedEvent arg { get; set; }
}

/// <summary>Efl UI view interface</summary>
public sealed class ViewConcrete :
    Efl.Eo.EoWrapper
    , IView
    
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(ViewConcrete))
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
    private ViewConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
        efl_ui_view_interface_get();

    /// <summary>Initializes a new instance of the <see cref="IView"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private ViewConcrete(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Event dispatched when a new model is set.</summary>
    /// <value><see cref="Efl.Ui.ViewModelChangedEventArgs"/></value>
    public event EventHandler<Efl.Ui.ViewModelChangedEventArgs> ModelChangedEvent
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
                        Efl.Ui.ViewModelChangedEventArgs args = new Efl.Ui.ViewModelChangedEventArgs();
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

    /// <summary>Method to raise event ModelChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnModelChangedEvent(Efl.Ui.ViewModelChangedEventArgs e)
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


#pragma warning disable CS0628
    /// <summary>Model that is/will be</summary>
    /// <returns>Efl model</returns>
    public Efl.IModel GetModel() {
        var _ret_var = Efl.Ui.ViewConcrete.NativeMethods.efl_ui_view_model_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Model that is/will be</summary>
    /// <param name="model">Efl model</param>
    public void SetModel(Efl.IModel model) {
        Efl.Ui.ViewConcrete.NativeMethods.efl_ui_view_model_set_ptr.Value.Delegate(this.NativeHandle,model);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Model that is/will be</summary>
    /// <value>Efl model</value>
    public Efl.IModel Model {
        get { return GetModel(); }
        set { SetModel(value); }
    }

#pragma warning restore CS0628
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.ViewConcrete.efl_ui_view_interface_get();
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
            return Efl.Ui.ViewConcrete.efl_ui_view_interface_get();
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
                    _ret_var = ((IView)ws.Target).GetModel();
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
                    ((IView)ws.Target).SetModel(model);
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
}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_UiViewConcrete_ExtensionMethods {
    public static Efl.BindableProperty<Efl.IModel> Model<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.IView, T>magic = null) where T : Efl.Ui.IView {
        return new Efl.BindableProperty<Efl.IModel>("model", fac);
    }

}
#pragma warning restore CS1591
#endif
namespace Efl {

/// <summary>Every time the model is changed on the object.</summary>
[StructLayout(LayoutKind.Sequential)]
[Efl.Eo.BindingEntity]
public struct ModelChangedEvent
{
    /// <summary>The newly set model.</summary>
    public Efl.IModel Current;
    /// <summary>The previously set model.</summary>
    public Efl.IModel Previous;
    /// <summary>Constructor for ModelChangedEvent.</summary>
    /// <param name="Current">The newly set model.</param>
    /// <param name="Previous">The previously set model.</param>
    public ModelChangedEvent(
        Efl.IModel Current = default(Efl.IModel),
        Efl.IModel Previous = default(Efl.IModel)    )
    {
        this.Current = Current;
        this.Previous = Previous;
    }

    /// <summary>Implicit conversion to the managed representation from a native pointer.</summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator ModelChangedEvent(IntPtr ptr)
    {
        var tmp = (ModelChangedEvent.NativeStruct)Marshal.PtrToStructure(ptr, typeof(ModelChangedEvent.NativeStruct));
        return tmp;
    }

    #pragma warning disable CS1591

    /// <summary>Internal wrapper for struct ModelChangedEvent.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        /// <summary>Internal wrapper for field Current</summary>
        public System.IntPtr Current;
        /// <summary>Internal wrapper for field Previous</summary>
        public System.IntPtr Previous;
        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator ModelChangedEvent.NativeStruct(ModelChangedEvent _external_struct)
        {
            var _internal_struct = new ModelChangedEvent.NativeStruct();
            _internal_struct.Current = _external_struct.Current?.NativeHandle ?? System.IntPtr.Zero;
            _internal_struct.Previous = _external_struct.Previous?.NativeHandle ?? System.IntPtr.Zero;
            return _internal_struct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator ModelChangedEvent(ModelChangedEvent.NativeStruct _internal_struct)
        {
            var _external_struct = new ModelChangedEvent();

            _external_struct.Current = (Efl.ModelConcrete) Efl.Eo.Globals.CreateWrapperFor(_internal_struct.Current);

            _external_struct.Previous = (Efl.ModelConcrete) Efl.Eo.Globals.CreateWrapperFor(_internal_struct.Previous);
            return _external_struct;
        }
    }
    #pragma warning restore CS1591
}

}

