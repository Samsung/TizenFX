#define EFL_BETA
#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
/// <param name="parent">This object can be used to know when to cancel the future.</param>
/// <param name="child">You must reference this object for the duration of your use of it as the caller will not do that for you.</param>
/// <returns><c>true</c> if the model should be kept.</returns>
[Efl.Eo.BindingEntity]
public delegate  Eina.Future EflFilterModel(Efl.FilterModel parent, Efl.IModel child);
[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))]public delegate  Eina.Future EflFilterModelInternal(IntPtr data, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.FilterModel parent, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.IModel child);
internal class EflFilterModelWrapper : IDisposable
{

    private EflFilterModelInternal _cb;
    private IntPtr _cb_data;
    private EinaFreeCb _cb_free_cb;

    internal EflFilterModelWrapper (EflFilterModelInternal _cb, IntPtr _cb_data, EinaFreeCb _cb_free_cb)
    {
        this._cb = _cb;
        this._cb_data = _cb_data;
        this._cb_free_cb = _cb_free_cb;
    }

    ~EflFilterModelWrapper()
    {
        Dispose(false);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (this._cb_free_cb != null)
        {
            if (disposing)
            {
                this._cb_free_cb(this._cb_data);
            }
            else
            {
                Efl.Eo.Globals.ThreadSafeFreeCbExec(this._cb_free_cb, this._cb_data);
            }
            this._cb_free_cb = null;
            this._cb_data = IntPtr.Zero;
            this._cb = null;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    internal  Eina.Future ManagedCb(Efl.FilterModel parent,Efl.IModel child)
    {
                                                        var _ret_var = _cb(_cb_data, parent, child);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
    }

    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))]    internal static  Eina.Future Cb(IntPtr cb_data, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.FilterModel parent, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.IModel child)
    {
        GCHandle handle = GCHandle.FromIntPtr(cb_data);
        EflFilterModel cb = (EflFilterModel)handle.Target;
                                                             Eina.Future _ret_var = default( Eina.Future);
        try {
            _ret_var = cb(parent, child);
        } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
                                        return _ret_var;
    }
}


namespace Efl {

/// <summary>Efl model designed to filter its children.</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.FilterModel.NativeMethods]
[Efl.Eo.BindingEntity]
public class FilterModel : Efl.CompositeModel
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(FilterModel))
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
        efl_filter_model_class_get();
    /// <summary>Initializes a new instance of the <see cref="FilterModel"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    /// <param name="filterSet">Set a filter function that will catch children from the composited model. See <see cref="Efl.FilterModel.SetFilter" /></param>
    /// <param name="model">Model that is/will be See <see cref="Efl.Ui.IView.SetModel" /></param>
    /// <param name="index">Position of this object in the parent model. See <see cref="Efl.CompositeModel.SetIndex" /></param>
    public FilterModel(Efl.Object parent
            , EflFilterModel filterSet, Efl.IModel model, uint? index = null) : base(efl_filter_model_class_get(), parent)
    {
        if (Efl.Eo.Globals.ParamHelperCheck(filterSet))
        {
            SetFilter(Efl.Eo.Globals.GetParamHelper(filterSet));
        }

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
    protected FilterModel(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="FilterModel"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected FilterModel(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="FilterModel"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected FilterModel(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }

    /// <summary>Set a filter function that will catch children from the composited model.</summary>
    /// <param name="filter">Filter callback</param>
    public virtual void SetFilter(EflFilterModel filter) {
                         GCHandle filter_handle = GCHandle.Alloc(filter);
        Efl.FilterModel.NativeMethods.efl_filter_model_filter_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),GCHandle.ToIntPtr(filter_handle), EflFilterModelWrapper.Cb, Efl.Eo.Globals.free_gchandle);
        Eina.Error.RaiseIfUnhandledException();
                         }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.FilterModel.efl_filter_model_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.CompositeModel.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Ecore);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_filter_model_filter_set_static_delegate == null)
            {
                efl_filter_model_filter_set_static_delegate = new efl_filter_model_filter_set_delegate(filter_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFilter") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_filter_model_filter_set"), func = Marshal.GetFunctionPointerForDelegate(efl_filter_model_filter_set_static_delegate) });
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
            return Efl.FilterModel.efl_filter_model_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate void efl_filter_model_filter_set_delegate(System.IntPtr obj, System.IntPtr pd,  IntPtr filter_data, EflFilterModelInternal filter, EinaFreeCb filter_free_cb);

        
        public delegate void efl_filter_model_filter_set_api_delegate(System.IntPtr obj,  IntPtr filter_data, EflFilterModelInternal filter, EinaFreeCb filter_free_cb);

        public static Efl.Eo.FunctionWrapper<efl_filter_model_filter_set_api_delegate> efl_filter_model_filter_set_ptr = new Efl.Eo.FunctionWrapper<efl_filter_model_filter_set_api_delegate>(Module, "efl_filter_model_filter_set");

        private static void filter_set(System.IntPtr obj, System.IntPtr pd, IntPtr filter_data, EflFilterModelInternal filter, EinaFreeCb filter_free_cb)
        {
            Eina.Log.Debug("function efl_filter_model_filter_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                            EflFilterModelWrapper filter_wrapper = new EflFilterModelWrapper(filter, filter_data, filter_free_cb);
            
                try
                {
                    ((FilterModel)ws.Target).SetFilter(filter_wrapper.ManagedCb);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_filter_model_filter_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), filter_data, filter, filter_free_cb);
            }
        }

        private static efl_filter_model_filter_set_delegate efl_filter_model_filter_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

#if EFL_BETA
#pragma warning disable CS1591
public static class EflFilterModel_ExtensionMethods {
}
#pragma warning restore CS1591
#endif
