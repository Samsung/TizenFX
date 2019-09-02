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

/// <summary>Interface for getting access to a single selected item in the implementor.
/// The implementor is free to allow a specific number of selectables beeing selected or not. This interface just covers always the latest selected selectable.</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Ui.ISingleSelectableConcrete.NativeMethods]
[Efl.Eo.BindingEntity]
public interface ISingleSelectable : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>The selectable that was selected most recently.</summary>
/// <returns>The latest selected item.</returns>
Efl.Ui.ISelectable GetLastSelected();
    /// <summary>A object that will be selected in case nothing is selected
/// A object set to this property will be selected instead of no item beeing selected. Which means, there will be always at least one element selected. If this property is NULL, the state of &quot;no item is selected&quot; can be reached.
/// 
/// Setting this property as a result of selection events results in undefined behavior.</summary>
Efl.Ui.ISelectable GetFallbackSelection();
    /// <summary>A object that will be selected in case nothing is selected
/// A object set to this property will be selected instead of no item beeing selected. Which means, there will be always at least one element selected. If this property is NULL, the state of &quot;no item is selected&quot; can be reached.
/// 
/// Setting this property as a result of selection events results in undefined behavior.</summary>
void SetFallbackSelection(Efl.Ui.ISelectable fallback);
                /// <summary>Called when there is a change in the selection state, this event will collect all the item selection change events that are happening within one loop iteration. This means, you will only get this event once, even if a lot of items have changed. If you are interested in detailed changes, subscribe to the selection,changed event of Efl.Ui.Selectable.</summary>
    event EventHandler SelectionChangedEvt;
    /// <summary>The selectable that was selected most recently.</summary>
    /// <value>The latest selected item.</value>
    Efl.Ui.ISelectable LastSelected {
        get;
    }
    /// <summary>A object that will be selected in case nothing is selected
    /// A object set to this property will be selected instead of no item beeing selected. Which means, there will be always at least one element selected. If this property is NULL, the state of &quot;no item is selected&quot; can be reached.
    /// 
    /// Setting this property as a result of selection events results in undefined behavior.</summary>
    Efl.Ui.ISelectable FallbackSelection {
        get;
        set;
    }
}
/// <summary>Interface for getting access to a single selected item in the implementor.
/// The implementor is free to allow a specific number of selectables beeing selected or not. This interface just covers always the latest selected selectable.</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
sealed public  class ISingleSelectableConcrete :
    Efl.Eo.EoWrapper
    , ISingleSelectable
    
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(ISingleSelectableConcrete))
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
    private ISingleSelectableConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_ui_single_selectable_interface_get();
    /// <summary>Initializes a new instance of the <see cref="ISingleSelectable"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private ISingleSelectableConcrete(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Called when there is a change in the selection state, this event will collect all the item selection change events that are happening within one loop iteration. This means, you will only get this event once, even if a lot of items have changed. If you are interested in detailed changes, subscribe to the selection,changed event of Efl.Ui.Selectable.</summary>
    public event EventHandler SelectionChangedEvt
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
                        EventArgs args = EventArgs.Empty;
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

                string key = "_EFL_UI_SINGLE_SELECTABLE_EVENT_SELECTION_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_SINGLE_SELECTABLE_EVENT_SELECTION_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event SelectionChangedEvt.</summary>
    public void OnSelectionChangedEvt(EventArgs e)
    {
        var key = "_EFL_UI_SINGLE_SELECTABLE_EVENT_SELECTION_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>The selectable that was selected most recently.</summary>
    /// <returns>The latest selected item.</returns>
    public Efl.Ui.ISelectable GetLastSelected() {
         var _ret_var = Efl.Ui.ISingleSelectableConcrete.NativeMethods.efl_ui_single_selectable_last_selected_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>A object that will be selected in case nothing is selected
    /// A object set to this property will be selected instead of no item beeing selected. Which means, there will be always at least one element selected. If this property is NULL, the state of &quot;no item is selected&quot; can be reached.
    /// 
    /// Setting this property as a result of selection events results in undefined behavior.</summary>
    public Efl.Ui.ISelectable GetFallbackSelection() {
         var _ret_var = Efl.Ui.ISingleSelectableConcrete.NativeMethods.efl_ui_single_selectable_fallback_selection_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>A object that will be selected in case nothing is selected
    /// A object set to this property will be selected instead of no item beeing selected. Which means, there will be always at least one element selected. If this property is NULL, the state of &quot;no item is selected&quot; can be reached.
    /// 
    /// Setting this property as a result of selection events results in undefined behavior.</summary>
    public void SetFallbackSelection(Efl.Ui.ISelectable fallback) {
                                 Efl.Ui.ISingleSelectableConcrete.NativeMethods.efl_ui_single_selectable_fallback_selection_set_ptr.Value.Delegate(this.NativeHandle,fallback);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The selectable that was selected most recently.</summary>
    /// <value>The latest selected item.</value>
    public Efl.Ui.ISelectable LastSelected {
        get { return GetLastSelected(); }
    }
    /// <summary>A object that will be selected in case nothing is selected
    /// A object set to this property will be selected instead of no item beeing selected. Which means, there will be always at least one element selected. If this property is NULL, the state of &quot;no item is selected&quot; can be reached.
    /// 
    /// Setting this property as a result of selection events results in undefined behavior.</summary>
    public Efl.Ui.ISelectable FallbackSelection {
        get { return GetFallbackSelection(); }
        set { SetFallbackSelection(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.ISingleSelectableConcrete.efl_ui_single_selectable_interface_get();
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
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_ui_single_selectable_last_selected_get_static_delegate == null)
            {
                efl_ui_single_selectable_last_selected_get_static_delegate = new efl_ui_single_selectable_last_selected_get_delegate(last_selected_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetLastSelected") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_single_selectable_last_selected_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_single_selectable_last_selected_get_static_delegate) });
            }

            if (efl_ui_single_selectable_fallback_selection_get_static_delegate == null)
            {
                efl_ui_single_selectable_fallback_selection_get_static_delegate = new efl_ui_single_selectable_fallback_selection_get_delegate(fallback_selection_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFallbackSelection") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_single_selectable_fallback_selection_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_single_selectable_fallback_selection_get_static_delegate) });
            }

            if (efl_ui_single_selectable_fallback_selection_set_static_delegate == null)
            {
                efl_ui_single_selectable_fallback_selection_set_static_delegate = new efl_ui_single_selectable_fallback_selection_set_delegate(fallback_selection_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFallbackSelection") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_single_selectable_fallback_selection_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_single_selectable_fallback_selection_set_static_delegate) });
            }

            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.ISingleSelectableConcrete.efl_ui_single_selectable_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Ui.ISelectable efl_ui_single_selectable_last_selected_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Ui.ISelectable efl_ui_single_selectable_last_selected_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_single_selectable_last_selected_get_api_delegate> efl_ui_single_selectable_last_selected_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_single_selectable_last_selected_get_api_delegate>(Module, "efl_ui_single_selectable_last_selected_get");

        private static Efl.Ui.ISelectable last_selected_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_single_selectable_last_selected_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Ui.ISelectable _ret_var = default(Efl.Ui.ISelectable);
                try
                {
                    _ret_var = ((ISingleSelectable)ws.Target).GetLastSelected();
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
                return efl_ui_single_selectable_last_selected_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_single_selectable_last_selected_get_delegate efl_ui_single_selectable_last_selected_get_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Ui.ISelectable efl_ui_single_selectable_fallback_selection_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Ui.ISelectable efl_ui_single_selectable_fallback_selection_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_single_selectable_fallback_selection_get_api_delegate> efl_ui_single_selectable_fallback_selection_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_single_selectable_fallback_selection_get_api_delegate>(Module, "efl_ui_single_selectable_fallback_selection_get");

        private static Efl.Ui.ISelectable fallback_selection_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_single_selectable_fallback_selection_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Ui.ISelectable _ret_var = default(Efl.Ui.ISelectable);
                try
                {
                    _ret_var = ((ISingleSelectable)ws.Target).GetFallbackSelection();
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
                return efl_ui_single_selectable_fallback_selection_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_single_selectable_fallback_selection_get_delegate efl_ui_single_selectable_fallback_selection_get_static_delegate;

        
        private delegate void efl_ui_single_selectable_fallback_selection_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Ui.ISelectable fallback);

        
        public delegate void efl_ui_single_selectable_fallback_selection_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Ui.ISelectable fallback);

        public static Efl.Eo.FunctionWrapper<efl_ui_single_selectable_fallback_selection_set_api_delegate> efl_ui_single_selectable_fallback_selection_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_single_selectable_fallback_selection_set_api_delegate>(Module, "efl_ui_single_selectable_fallback_selection_set");

        private static void fallback_selection_set(System.IntPtr obj, System.IntPtr pd, Efl.Ui.ISelectable fallback)
        {
            Eina.Log.Debug("function efl_ui_single_selectable_fallback_selection_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((ISingleSelectable)ws.Target).SetFallbackSelection(fallback);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_single_selectable_fallback_selection_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), fallback);
            }
        }

        private static efl_ui_single_selectable_fallback_selection_set_delegate efl_ui_single_selectable_fallback_selection_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_UiISingleSelectableConcrete_ExtensionMethods {
    
    public static Efl.BindableProperty<Efl.Ui.ISelectable> FallbackSelection<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.ISingleSelectable, T>magic = null) where T : Efl.Ui.ISingleSelectable {
        return new Efl.BindableProperty<Efl.Ui.ISelectable>("fallback_selection", fac);
    }

}
#pragma warning restore CS1591
#endif
