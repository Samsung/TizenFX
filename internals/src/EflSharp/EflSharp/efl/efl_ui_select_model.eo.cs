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

/// <summary>Event argument wrapper for event <see cref="Efl.Ui.SelectModel.SelectedEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class SelectModelSelectedEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value></value>
    public Efl.Object arg { get; set; }
}
/// <summary>Event argument wrapper for event <see cref="Efl.Ui.SelectModel.UnselectedEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class SelectModelUnselectedEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value></value>
    public Efl.Object arg { get; set; }
}
/// <summary>Efl ui select model class</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Ui.SelectModel.NativeMethods]
[Efl.Eo.BindingEntity]
public class SelectModel : Efl.BooleanModel
{
    /// <summary>Pointer to the native class description.</summary>
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

    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_ui_select_model_class_get();
    /// <summary>Initializes a new instance of the <see cref="SelectModel"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    /// <param name="model">Model that is/will be See <see cref="Efl.Ui.IView.SetModel" /></param>
    /// <param name="index">Position of this object in the parent model. See <see cref="Efl.CompositeModel.SetIndex" /></param>
    public SelectModel(Efl.Object parent
            , Efl.IModel model, uint? index = null) : base(efl_ui_select_model_class_get(), parent)
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

    /// <value><see cref="Efl.Ui.SelectModelSelectedEventArgs"/></value>
    public event EventHandler<Efl.Ui.SelectModelSelectedEventArgs> SelectedEvent
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
                        Efl.Ui.SelectModelSelectedEventArgs args = new Efl.Ui.SelectModelSelectedEventArgs();
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

                string key = "_EFL_UI_SELECT_MODEL_EVENT_SELECTED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_SELECT_MODEL_EVENT_SELECTED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event SelectedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnSelectedEvent(Efl.Ui.SelectModelSelectedEventArgs e)
    {
        var key = "_EFL_UI_SELECT_MODEL_EVENT_SELECTED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <value><see cref="Efl.Ui.SelectModelUnselectedEventArgs"/></value>
    public event EventHandler<Efl.Ui.SelectModelUnselectedEventArgs> UnselectedEvent
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
                        Efl.Ui.SelectModelUnselectedEventArgs args = new Efl.Ui.SelectModelUnselectedEventArgs();
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

                string key = "_EFL_UI_SELECT_MODEL_EVENT_UNSELECTED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_SELECT_MODEL_EVENT_UNSELECTED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event UnselectedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnUnselectedEvent(Efl.Ui.SelectModelUnselectedEventArgs e)
    {
        var key = "_EFL_UI_SELECT_MODEL_EVENT_UNSELECTED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>Defines if we support only one exclusive selection at a time when set to <c>true</c>.
    /// If disable with <c>false</c>, it will have the behavior of a multi select mode.</summary>
    /// <returns><c>true</c> will enable the exclusive mode.</returns>
    public virtual bool GetSingleSelection() {
         var _ret_var = Efl.Ui.SelectModel.NativeMethods.efl_ui_select_model_single_selection_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Defines if we support only one exclusive selection at a time when set to <c>true</c>.
    /// If disable with <c>false</c>, it will have the behavior of a multi select mode.</summary>
    /// <param name="enable"><c>true</c> will enable the exclusive mode.</param>
    public virtual void SetSingleSelection(bool enable) {
                                 Efl.Ui.SelectModel.NativeMethods.efl_ui_select_model_single_selection_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),enable);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Gets an iterator of all the selected child of this model.</summary>
    /// <returns>The iterator gives indices of selected children. It is valid until any change is made on the model.</returns>
    public virtual Eina.Iterator<ulong> GetSelected() {
         var _ret_var = Efl.Ui.SelectModel.NativeMethods.efl_ui_select_model_selected_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return new Eina.Iterator<ulong>(_ret_var, false);
 }
    /// <summary>Gets an iterator of all the child of this model that are not selected.</summary>
    /// <returns>The iterator gives indices of unselected children. It is valid until any change is made on the model.</returns>
    public virtual Eina.Iterator<ulong> GetUnselected() {
         var _ret_var = Efl.Ui.SelectModel.NativeMethods.efl_ui_select_model_unselected_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return new Eina.Iterator<ulong>(_ret_var, false);
 }
    /// <summary>Defines if we support only one exclusive selection at a time when set to <c>true</c>.
    /// If disable with <c>false</c>, it will have the behavior of a multi select mode.</summary>
    /// <value><c>true</c> will enable the exclusive mode.</value>
    public bool SingleSelection {
        get { return GetSingleSelection(); }
        set { SetSingleSelection(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.SelectModel.efl_ui_select_model_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.BooleanModel.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Elementary);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_ui_select_model_single_selection_get_static_delegate == null)
            {
                efl_ui_select_model_single_selection_get_static_delegate = new efl_ui_select_model_single_selection_get_delegate(single_selection_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetSingleSelection") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_select_model_single_selection_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_select_model_single_selection_get_static_delegate) });
            }

            if (efl_ui_select_model_single_selection_set_static_delegate == null)
            {
                efl_ui_select_model_single_selection_set_static_delegate = new efl_ui_select_model_single_selection_set_delegate(single_selection_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetSingleSelection") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_select_model_single_selection_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_select_model_single_selection_set_static_delegate) });
            }

            if (efl_ui_select_model_selected_get_static_delegate == null)
            {
                efl_ui_select_model_selected_get_static_delegate = new efl_ui_select_model_selected_get_delegate(selected_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetSelected") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_select_model_selected_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_select_model_selected_get_static_delegate) });
            }

            if (efl_ui_select_model_unselected_get_static_delegate == null)
            {
                efl_ui_select_model_unselected_get_static_delegate = new efl_ui_select_model_unselected_get_delegate(unselected_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetUnselected") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_select_model_unselected_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_select_model_unselected_get_static_delegate) });
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
            return Efl.Ui.SelectModel.efl_ui_select_model_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_select_model_single_selection_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_select_model_single_selection_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_select_model_single_selection_get_api_delegate> efl_ui_select_model_single_selection_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_select_model_single_selection_get_api_delegate>(Module, "efl_ui_select_model_single_selection_get");

        private static bool single_selection_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_select_model_single_selection_get was called");
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
                return efl_ui_select_model_single_selection_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_select_model_single_selection_get_delegate efl_ui_select_model_single_selection_get_static_delegate;

        
        private delegate void efl_ui_select_model_single_selection_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool enable);

        
        public delegate void efl_ui_select_model_single_selection_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool enable);

        public static Efl.Eo.FunctionWrapper<efl_ui_select_model_single_selection_set_api_delegate> efl_ui_select_model_single_selection_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_select_model_single_selection_set_api_delegate>(Module, "efl_ui_select_model_single_selection_set");

        private static void single_selection_set(System.IntPtr obj, System.IntPtr pd, bool enable)
        {
            Eina.Log.Debug("function efl_ui_select_model_single_selection_set was called");
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
                efl_ui_select_model_single_selection_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), enable);
            }
        }

        private static efl_ui_select_model_single_selection_set_delegate efl_ui_select_model_single_selection_set_static_delegate;

        
        private delegate System.IntPtr efl_ui_select_model_selected_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate System.IntPtr efl_ui_select_model_selected_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_select_model_selected_get_api_delegate> efl_ui_select_model_selected_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_select_model_selected_get_api_delegate>(Module, "efl_ui_select_model_selected_get");

        private static System.IntPtr selected_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_select_model_selected_get was called");
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
                return efl_ui_select_model_selected_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_select_model_selected_get_delegate efl_ui_select_model_selected_get_static_delegate;

        
        private delegate System.IntPtr efl_ui_select_model_unselected_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate System.IntPtr efl_ui_select_model_unselected_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_select_model_unselected_get_api_delegate> efl_ui_select_model_unselected_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_select_model_unselected_get_api_delegate>(Module, "efl_ui_select_model_unselected_get");

        private static System.IntPtr unselected_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_select_model_unselected_get was called");
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
                return efl_ui_select_model_unselected_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_select_model_unselected_get_delegate efl_ui_select_model_unselected_get_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_UiSelectModel_ExtensionMethods {
    public static Efl.BindableProperty<bool> SingleSelection<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.SelectModel, T>magic = null) where T : Efl.Ui.SelectModel {
        return new Efl.BindableProperty<bool>("single_selection", fac);
    }

}
#pragma warning restore CS1591
#endif
