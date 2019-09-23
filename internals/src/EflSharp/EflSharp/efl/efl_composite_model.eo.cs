#define EFL_BETA
#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

/// <summary>Efl model for all composite class which provide a unified API to set source of data.
/// This class also provide an <see cref="Efl.IModel.GetProperty"/> &quot;child.index&quot; that match the value of <see cref="Efl.CompositeModel.Index"/>.</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.CompositeModel.NativeMethods]
[Efl.Eo.BindingEntity]
public class CompositeModel : Efl.LoopModel, Efl.Ui.IView
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(CompositeModel))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)] internal static extern System.IntPtr
        efl_composite_model_class_get();
    /// <summary>Initializes a new instance of the <see cref="CompositeModel"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    /// <param name="model">Model that is/will be See <see cref="Efl.Ui.IView.SetModel" /></param>
    /// <param name="index">Position of this object in the parent model. See <see cref="Efl.CompositeModel.SetIndex" /></param>
    public CompositeModel(Efl.Object parent
            , Efl.IModel model, uint? index = null) : base(efl_composite_model_class_get(), parent)
    {
        if (Efl.Eo.Globals.ParamHelperCheck(model))
        {
            SetModel(Efl.Eo.Globals.GetParamHelper(model));
        }

        if (Efl.Eo.Globals.ParamHelperCheck(index))
        {
            SetIndex(Efl.Eo.Globals.GetParamHelper(index));
        }

        FinishInstantiation();
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected CompositeModel(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="CompositeModel"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected CompositeModel(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="CompositeModel"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected CompositeModel(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
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
                AddNativeEventHandler(efl.Libs.Ecore, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_VIEW_EVENT_MODEL_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Ecore, key, value);
            }
        }
    }
    /// <summary>Method to raise event ModelChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnModelChangedEvent(Efl.Ui.ViewModelChangedEventArgs e)
    {
        var key = "_EFL_UI_VIEW_EVENT_MODEL_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Ecore, key);
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
    /// <summary>Position of this object in the parent model.
    /// It can only be set before the object is finalized but after the Model it composes is set (and only if that Model does not provide an index already). It can only be retrieved after the object has been finalized.</summary>
    /// <returns>Index of the object in the parent model. The index is unique and starts from zero.</returns>
    public virtual uint GetIndex() {
         var _ret_var = Efl.CompositeModel.NativeMethods.efl_composite_model_index_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Position of this object in the parent model.
    /// It can only be set before the object is finalized but after the Model it composes is set (and only if that Model does not provide an index already). It can only be retrieved after the object has been finalized.</summary>
    /// <param name="index">Index of the object in the parent model. The index is unique and starts from zero.</param>
    public virtual void SetIndex(uint index) {
                                 Efl.CompositeModel.NativeMethods.efl_composite_model_index_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),index);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Model that is/will be</summary>
    /// <returns>Efl model</returns>
    public virtual Efl.IModel GetModel() {
         var _ret_var = Efl.Ui.ViewConcrete.NativeMethods.efl_ui_view_model_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Model that is/will be</summary>
    /// <param name="model">Efl model</param>
    public virtual void SetModel(Efl.IModel model) {
                                 Efl.Ui.ViewConcrete.NativeMethods.efl_ui_view_model_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),model);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Position of this object in the parent model.
    /// It can only be set before the object is finalized but after the Model it composes is set (and only if that Model does not provide an index already). It can only be retrieved after the object has been finalized.</summary>
    /// <value>Index of the object in the parent model. The index is unique and starts from zero.</value>
    public uint Index {
        get { return GetIndex(); }
        set { SetIndex(value); }
    }
    /// <summary>Model that is/will be</summary>
    /// <value>Efl model</value>
    public Efl.IModel Model {
        get { return GetModel(); }
        set { SetModel(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.CompositeModel.efl_composite_model_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.LoopModel.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Ecore);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_composite_model_index_get_static_delegate == null)
            {
                efl_composite_model_index_get_static_delegate = new efl_composite_model_index_get_delegate(index_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetIndex") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_composite_model_index_get"), func = Marshal.GetFunctionPointerForDelegate(efl_composite_model_index_get_static_delegate) });
            }

            if (efl_composite_model_index_set_static_delegate == null)
            {
                efl_composite_model_index_set_static_delegate = new efl_composite_model_index_set_delegate(index_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetIndex") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_composite_model_index_set"), func = Marshal.GetFunctionPointerForDelegate(efl_composite_model_index_set_static_delegate) });
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
            return Efl.CompositeModel.efl_composite_model_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate uint efl_composite_model_index_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate uint efl_composite_model_index_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_composite_model_index_get_api_delegate> efl_composite_model_index_get_ptr = new Efl.Eo.FunctionWrapper<efl_composite_model_index_get_api_delegate>(Module, "efl_composite_model_index_get");

        private static uint index_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_composite_model_index_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            uint _ret_var = default(uint);
                try
                {
                    _ret_var = ((CompositeModel)ws.Target).GetIndex();
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
                return efl_composite_model_index_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_composite_model_index_get_delegate efl_composite_model_index_get_static_delegate;

        
        private delegate void efl_composite_model_index_set_delegate(System.IntPtr obj, System.IntPtr pd,  uint index);

        
        public delegate void efl_composite_model_index_set_api_delegate(System.IntPtr obj,  uint index);

        public static Efl.Eo.FunctionWrapper<efl_composite_model_index_set_api_delegate> efl_composite_model_index_set_ptr = new Efl.Eo.FunctionWrapper<efl_composite_model_index_set_api_delegate>(Module, "efl_composite_model_index_set");

        private static void index_set(System.IntPtr obj, System.IntPtr pd, uint index)
        {
            Eina.Log.Debug("function efl_composite_model_index_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((CompositeModel)ws.Target).SetIndex(index);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_composite_model_index_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), index);
            }
        }

        private static efl_composite_model_index_set_delegate efl_composite_model_index_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

#if EFL_BETA
#pragma warning disable CS1591
public static class EflCompositeModel_ExtensionMethods {
    public static Efl.BindableProperty<uint> Index<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.CompositeModel, T>magic = null) where T : Efl.CompositeModel {
        return new Efl.BindableProperty<uint>("index", fac);
    }

    public static Efl.BindableProperty<Efl.IModel> Model<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.CompositeModel, T>magic = null) where T : Efl.CompositeModel {
        return new Efl.BindableProperty<Efl.IModel>("model", fac);
    }

}
#pragma warning restore CS1591
#endif
