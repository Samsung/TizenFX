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

/// <summary>Temporare interface, this is here until collection_view lands</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Ui.IContainerSelectableConcrete.NativeMethods]
[Efl.Eo.BindingEntity]
public interface IContainerSelectable : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Called when selected</summary>
    /// <value><see cref="Efl.Ui.IContainerSelectableItemSelectedEvt_Args"/></value>
    event EventHandler<Efl.Ui.IContainerSelectableItemSelectedEvt_Args> ItemSelectedEvt;
    /// <summary>Called when no longer selected</summary>
    /// <value><see cref="Efl.Ui.IContainerSelectableItemUnselectedEvt_Args"/></value>
    event EventHandler<Efl.Ui.IContainerSelectableItemUnselectedEvt_Args> ItemUnselectedEvt;
}
/// <summary>Event argument wrapper for event <see cref="Efl.Ui.IContainerSelectable.ItemSelectedEvt"/>.</summary>
[Efl.Eo.BindingEntity]
public class IContainerSelectableItemSelectedEvt_Args : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Called when selected</value>
    public Efl.Object arg { get; set; }
}
/// <summary>Event argument wrapper for event <see cref="Efl.Ui.IContainerSelectable.ItemUnselectedEvt"/>.</summary>
[Efl.Eo.BindingEntity]
public class IContainerSelectableItemUnselectedEvt_Args : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Called when no longer selected</value>
    public Efl.Object arg { get; set; }
}
/// <summary>Temporare interface, this is here until collection_view lands</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
sealed public  class IContainerSelectableConcrete :
    Efl.Eo.EoWrapper
    , IContainerSelectable
    
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(IContainerSelectableConcrete))
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
    private IContainerSelectableConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
        efl_ui_container_selectable_interface_get();
    /// <summary>Initializes a new instance of the <see cref="IContainerSelectable"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private IContainerSelectableConcrete(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Called when selected</summary>
    /// <value><see cref="Efl.Ui.IContainerSelectableItemSelectedEvt_Args"/></value>
    public event EventHandler<Efl.Ui.IContainerSelectableItemSelectedEvt_Args> ItemSelectedEvt
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
                        Efl.Ui.IContainerSelectableItemSelectedEvt_Args args = new Efl.Ui.IContainerSelectableItemSelectedEvt_Args();
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

                string key = "_EFL_UI_EVENT_ITEM_SELECTED";
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_ITEM_SELECTED";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    /// <summary>Method to raise event ItemSelectedEvt.</summary>
    public void OnItemSelectedEvt(Efl.Ui.IContainerSelectableItemSelectedEvt_Args e)
    {
        var key = "_EFL_UI_EVENT_ITEM_SELECTED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>Called when no longer selected</summary>
    /// <value><see cref="Efl.Ui.IContainerSelectableItemUnselectedEvt_Args"/></value>
    public event EventHandler<Efl.Ui.IContainerSelectableItemUnselectedEvt_Args> ItemUnselectedEvt
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
                        Efl.Ui.IContainerSelectableItemUnselectedEvt_Args args = new Efl.Ui.IContainerSelectableItemUnselectedEvt_Args();
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

                string key = "_EFL_UI_EVENT_ITEM_UNSELECTED";
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_ITEM_UNSELECTED";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    /// <summary>Method to raise event ItemUnselectedEvt.</summary>
    public void OnItemUnselectedEvt(Efl.Ui.IContainerSelectableItemUnselectedEvt_Args e)
    {
        var key = "_EFL_UI_EVENT_ITEM_UNSELECTED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.IContainerSelectableConcrete.efl_ui_container_selectable_interface_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Eo.EoWrapper.NativeMethods
    {
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.IContainerSelectableConcrete.efl_ui_container_selectable_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_UiIContainerSelectableConcrete_ExtensionMethods {
}
#pragma warning restore CS1591
#endif
