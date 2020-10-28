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

/// <summary>Selectable interface for ui objects
/// A object implementing this can be selected. When the selected property of this object changes, the selected,changed event is emitted.</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Ui.ISelectableConcrete.NativeMethods]
[Efl.Eo.BindingEntity]
public interface ISelectable : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>The selected state of this object
/// A change to this property emits the changed event.</summary>
/// <returns>The selected state of this object</returns>
bool GetSelected();
    /// <summary>The selected state of this object
/// A change to this property emits the changed event.</summary>
/// <param name="selected">The selected state of this object</param>
void SetSelected(bool selected);
            /// <summary>Called when the selected state has changed</summary>
    /// <value><see cref="Efl.Ui.ISelectableSelectedChangedEvt_Args"/></value>
    event EventHandler<Efl.Ui.ISelectableSelectedChangedEvt_Args> SelectedChangedEvt;
    /// <summary>The selected state of this object
    /// A change to this property emits the changed event.</summary>
    /// <value>The selected state of this object</value>
    bool Selected {
        get;
        set;
    }
}
/// <summary>Event argument wrapper for event <see cref="Efl.Ui.ISelectable.SelectedChangedEvt"/>.</summary>
[Efl.Eo.BindingEntity]
public class ISelectableSelectedChangedEvt_Args : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Called when the selected state has changed</value>
    public bool arg { get; set; }
}
/// <summary>Selectable interface for ui objects
/// A object implementing this can be selected. When the selected property of this object changes, the selected,changed event is emitted.</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
sealed public  class ISelectableConcrete :
    Efl.Eo.EoWrapper
    , ISelectable
    
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(ISelectableConcrete))
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
    private ISelectableConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_ui_selectable_interface_get();
    /// <summary>Initializes a new instance of the <see cref="ISelectable"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private ISelectableConcrete(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Called when the selected state has changed</summary>
    /// <value><see cref="Efl.Ui.ISelectableSelectedChangedEvt_Args"/></value>
    public event EventHandler<Efl.Ui.ISelectableSelectedChangedEvt_Args> SelectedChangedEvt
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
                        Efl.Ui.ISelectableSelectedChangedEvt_Args args = new Efl.Ui.ISelectableSelectedChangedEvt_Args();
                        args.arg = Marshal.ReadByte(evt.Info) != 0;
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

                string key = "_EFL_UI_EVENT_SELECTED_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_SELECTED_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event SelectedChangedEvt.</summary>
    public void OnSelectedChangedEvt(Efl.Ui.ISelectableSelectedChangedEvt_Args e)
    {
        var key = "_EFL_UI_EVENT_SELECTED_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = Eina.PrimitiveConversion.ManagedToPointerAlloc(e.arg ? (byte) 1 : (byte) 0);
        try
        {
            Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Marshal.FreeHGlobal(info);
        }
    }
    /// <summary>The selected state of this object
    /// A change to this property emits the changed event.</summary>
    /// <returns>The selected state of this object</returns>
    public bool GetSelected() {
         var _ret_var = Efl.Ui.ISelectableConcrete.NativeMethods.efl_ui_selectable_selected_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The selected state of this object
    /// A change to this property emits the changed event.</summary>
    /// <param name="selected">The selected state of this object</param>
    public void SetSelected(bool selected) {
                                 Efl.Ui.ISelectableConcrete.NativeMethods.efl_ui_selectable_selected_set_ptr.Value.Delegate(this.NativeHandle,selected);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The selected state of this object
    /// A change to this property emits the changed event.</summary>
    /// <value>The selected state of this object</value>
    public bool Selected {
        get { return GetSelected(); }
        set { SetSelected(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.ISelectableConcrete.efl_ui_selectable_interface_get();
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

            if (efl_ui_selectable_selected_get_static_delegate == null)
            {
                efl_ui_selectable_selected_get_static_delegate = new efl_ui_selectable_selected_get_delegate(selected_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetSelected") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_selectable_selected_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_selectable_selected_get_static_delegate) });
            }

            if (efl_ui_selectable_selected_set_static_delegate == null)
            {
                efl_ui_selectable_selected_set_static_delegate = new efl_ui_selectable_selected_set_delegate(selected_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetSelected") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_selectable_selected_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_selectable_selected_set_static_delegate) });
            }

            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.ISelectableConcrete.efl_ui_selectable_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_selectable_selected_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_selectable_selected_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_selectable_selected_get_api_delegate> efl_ui_selectable_selected_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_selectable_selected_get_api_delegate>(Module, "efl_ui_selectable_selected_get");

        private static bool selected_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_selectable_selected_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((ISelectable)ws.Target).GetSelected();
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
                return efl_ui_selectable_selected_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_selectable_selected_get_delegate efl_ui_selectable_selected_get_static_delegate;

        
        private delegate void efl_ui_selectable_selected_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool selected);

        
        public delegate void efl_ui_selectable_selected_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool selected);

        public static Efl.Eo.FunctionWrapper<efl_ui_selectable_selected_set_api_delegate> efl_ui_selectable_selected_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_selectable_selected_set_api_delegate>(Module, "efl_ui_selectable_selected_set");

        private static void selected_set(System.IntPtr obj, System.IntPtr pd, bool selected)
        {
            Eina.Log.Debug("function efl_ui_selectable_selected_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((ISelectable)ws.Target).SetSelected(selected);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_selectable_selected_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), selected);
            }
        }

        private static efl_ui_selectable_selected_set_delegate efl_ui_selectable_selected_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_UiISelectableConcrete_ExtensionMethods {
    public static Efl.BindableProperty<bool> Selected<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.ISelectable, T>magic = null) where T : Efl.Ui.ISelectable {
        return new Efl.BindableProperty<bool>("selected", fac);
    }

}
#pragma warning restore CS1591
#endif
