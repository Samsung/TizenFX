#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

///<summary>Event argument wrapper for event <see cref="Efl.SelectModel.SelectedEvt"/>.</summary>
[Efl.Eo.BindingEntity]
public class SelectModelSelectedEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Efl.Object arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.SelectModel.UnselectedEvt"/>.</summary>
[Efl.Eo.BindingEntity]
public class SelectModelUnselectedEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Efl.Object arg { get; set; }
}
/// <summary>Efl select model class</summary>
[Efl.SelectModel.NativeMethods]
[Efl.Eo.BindingEntity]
public class SelectModel : Efl.BooleanModel
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(SelectModel))
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
        efl_select_model_class_get();
    /// <summary>Initializes a new instance of the <see cref="SelectModel"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    /// <param name="model">Model that is/will be See <see cref="Efl.Ui.IView.SetModel" /></param>
    /// <param name="index">Position of this object in the parent model. See <see cref="Efl.CompositeModel.SetIndex" /></param>
    public SelectModel(Efl.Object parent
            , Efl.IModel model, uint? index = null) : base(efl_select_model_class_get(), parent)
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

    /// <summary>Constructor to be used when objects are expected to be constructed from native code.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected SelectModel(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="SelectModel"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected SelectModel(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="SelectModel"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected SelectModel(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }

    public event EventHandler<Efl.SelectModelSelectedEvt_Args> SelectedEvt
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
                        Efl.SelectModelSelectedEvt_Args args = new Efl.SelectModelSelectedEvt_Args();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Object);
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

                string key = "_EFL_SELECT_MODEL_EVENT_SELECTED";
                AddNativeEventHandler(efl.Libs.Ecore, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_SELECT_MODEL_EVENT_SELECTED";
                RemoveNativeEventHandler(efl.Libs.Ecore, key, value);
            }
        }
    }
    ///<summary>Method to raise event SelectedEvt.</summary>
    public void OnSelectedEvt(Efl.SelectModelSelectedEvt_Args e)
    {
        var key = "_EFL_SELECT_MODEL_EVENT_SELECTED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Ecore, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    public event EventHandler<Efl.SelectModelUnselectedEvt_Args> UnselectedEvt
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
                        Efl.SelectModelUnselectedEvt_Args args = new Efl.SelectModelUnselectedEvt_Args();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Object);
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

                string key = "_EFL_SELECT_MODEL_EVENT_UNSELECTED";
                AddNativeEventHandler(efl.Libs.Ecore, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_SELECT_MODEL_EVENT_UNSELECTED";
                RemoveNativeEventHandler(efl.Libs.Ecore, key, value);
            }
        }
    }
    ///<summary>Method to raise event UnselectedEvt.</summary>
    public void OnUnselectedEvt(Efl.SelectModelUnselectedEvt_Args e)
    {
        var key = "_EFL_SELECT_MODEL_EVENT_UNSELECTED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Ecore, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>Define if we support only one exclusive selection at a time when set to <c>true</c>.
    /// If disable with <c>false</c>, it will have the behavior of a multi select mode.</summary>
    /// <returns><c>true</c> will enable the exclusive mode.</returns>
    virtual public bool GetSingleSelection() {
         var _ret_var = Efl.SelectModel.NativeMethods.efl_select_model_single_selection_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Define if we support only one exclusive selection at a time when set to <c>true</c>.
    /// If disable with <c>false</c>, it will have the behavior of a multi select mode.</summary>
    /// <param name="enable"><c>true</c> will enable the exclusive mode.</param>
    virtual public void SetSingleSelection(bool enable) {
                                 Efl.SelectModel.NativeMethods.efl_select_model_single_selection_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),enable);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get an iterator of all the selected child of this model.</summary>
    /// <returns>The iterator give indexes of selected child. It is valid until any change is made on the model.</returns>
    virtual public Eina.Iterator<ulong> GetSelected() {
         var _ret_var = Efl.SelectModel.NativeMethods.efl_select_model_selected_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return new Eina.Iterator<ulong>(_ret_var, false);
 }
    /// <summary>Get an iterator of all the child of this model that are not selected.</summary>
    /// <returns>The iterator give indexes of unselected child. It is valid until any change is made on the model.</returns>
    virtual public Eina.Iterator<ulong> GetUnselected() {
         var _ret_var = Efl.SelectModel.NativeMethods.efl_select_model_unselected_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return new Eina.Iterator<ulong>(_ret_var, false);
 }
    /// <summary>Define if we support only one exclusive selection at a time when set to <c>true</c>.
    /// If disable with <c>false</c>, it will have the behavior of a multi select mode.</summary>
    /// <value><c>true</c> will enable the exclusive mode.</value>
    public bool SingleSelection {
        get { return GetSingleSelection(); }
        set { SetSingleSelection(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.SelectModel.efl_select_model_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.BooleanModel.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Ecore);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_select_model_single_selection_get_static_delegate == null)
            {
                efl_select_model_single_selection_get_static_delegate = new efl_select_model_single_selection_get_delegate(single_selection_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetSingleSelection") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_select_model_single_selection_get"), func = Marshal.GetFunctionPointerForDelegate(efl_select_model_single_selection_get_static_delegate) });
            }

            if (efl_select_model_single_selection_set_static_delegate == null)
            {
                efl_select_model_single_selection_set_static_delegate = new efl_select_model_single_selection_set_delegate(single_selection_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetSingleSelection") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_select_model_single_selection_set"), func = Marshal.GetFunctionPointerForDelegate(efl_select_model_single_selection_set_static_delegate) });
            }

            if (efl_select_model_selected_get_static_delegate == null)
            {
                efl_select_model_selected_get_static_delegate = new efl_select_model_selected_get_delegate(selected_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetSelected") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_select_model_selected_get"), func = Marshal.GetFunctionPointerForDelegate(efl_select_model_selected_get_static_delegate) });
            }

            if (efl_select_model_unselected_get_static_delegate == null)
            {
                efl_select_model_unselected_get_static_delegate = new efl_select_model_unselected_get_delegate(unselected_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetUnselected") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_select_model_unselected_get"), func = Marshal.GetFunctionPointerForDelegate(efl_select_model_unselected_get_static_delegate) });
            }

            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.SelectModel.efl_select_model_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_select_model_single_selection_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_select_model_single_selection_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_select_model_single_selection_get_api_delegate> efl_select_model_single_selection_get_ptr = new Efl.Eo.FunctionWrapper<efl_select_model_single_selection_get_api_delegate>(Module, "efl_select_model_single_selection_get");

        private static bool single_selection_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_select_model_single_selection_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((SelectModel)ws.Target).GetSingleSelection();
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
                return efl_select_model_single_selection_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_select_model_single_selection_get_delegate efl_select_model_single_selection_get_static_delegate;

        
        private delegate void efl_select_model_single_selection_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool enable);

        
        public delegate void efl_select_model_single_selection_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool enable);

        public static Efl.Eo.FunctionWrapper<efl_select_model_single_selection_set_api_delegate> efl_select_model_single_selection_set_ptr = new Efl.Eo.FunctionWrapper<efl_select_model_single_selection_set_api_delegate>(Module, "efl_select_model_single_selection_set");

        private static void single_selection_set(System.IntPtr obj, System.IntPtr pd, bool enable)
        {
            Eina.Log.Debug("function efl_select_model_single_selection_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((SelectModel)ws.Target).SetSingleSelection(enable);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_select_model_single_selection_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), enable);
            }
        }

        private static efl_select_model_single_selection_set_delegate efl_select_model_single_selection_set_static_delegate;

        
        private delegate System.IntPtr efl_select_model_selected_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate System.IntPtr efl_select_model_selected_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_select_model_selected_get_api_delegate> efl_select_model_selected_get_ptr = new Efl.Eo.FunctionWrapper<efl_select_model_selected_get_api_delegate>(Module, "efl_select_model_selected_get");

        private static System.IntPtr selected_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_select_model_selected_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Iterator<ulong> _ret_var = default(Eina.Iterator<ulong>);
                try
                {
                    _ret_var = ((SelectModel)ws.Target).GetSelected();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        return _ret_var.Handle;

            }
            else
            {
                return efl_select_model_selected_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_select_model_selected_get_delegate efl_select_model_selected_get_static_delegate;

        
        private delegate System.IntPtr efl_select_model_unselected_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate System.IntPtr efl_select_model_unselected_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_select_model_unselected_get_api_delegate> efl_select_model_unselected_get_ptr = new Efl.Eo.FunctionWrapper<efl_select_model_unselected_get_api_delegate>(Module, "efl_select_model_unselected_get");

        private static System.IntPtr unselected_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_select_model_unselected_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Iterator<ulong> _ret_var = default(Eina.Iterator<ulong>);
                try
                {
                    _ret_var = ((SelectModel)ws.Target).GetUnselected();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        return _ret_var.Handle;

            }
            else
            {
                return efl_select_model_unselected_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_select_model_unselected_get_delegate efl_select_model_unselected_get_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

