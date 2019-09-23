#define EFL_BETA
#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Input {

/// <summary>Efl input clickable interface</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Input.ClickableConcrete.NativeMethods]
[Efl.Eo.BindingEntity]
public interface IClickable : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>This returns true if the given object is currently in event emission</summary>
bool GetInteraction();
                                        /// <summary>Called when object is in sequence pressed and unpressed by the primary button</summary>
    /// <value><see cref="Efl.Input.ClickableClickedEventArgs"/></value>
    event EventHandler<Efl.Input.ClickableClickedEventArgs> ClickedEvent;
    /// <summary>Called when object is in sequence pressed and unpressed by any button. The button that triggered the event can be found in the event information.</summary>
    /// <value><see cref="Efl.Input.ClickableClickedAnyEventArgs"/></value>
    event EventHandler<Efl.Input.ClickableClickedAnyEventArgs> ClickedAnyEvent;
    /// <summary>Called when the object is pressed, event_info is the button that got pressed</summary>
    /// <value><see cref="Efl.Input.ClickablePressedEventArgs"/></value>
    event EventHandler<Efl.Input.ClickablePressedEventArgs> PressedEvent;
    /// <summary>Called when the object is no longer pressed, event_info is the button that got pressed</summary>
    /// <value><see cref="Efl.Input.ClickableUnpressedEventArgs"/></value>
    event EventHandler<Efl.Input.ClickableUnpressedEventArgs> UnpressedEvent;
    /// <summary>Called when the object receives a long press, event_info is the button that got pressed</summary>
    /// <value><see cref="Efl.Input.ClickableLongpressedEventArgs"/></value>
    event EventHandler<Efl.Input.ClickableLongpressedEventArgs> LongpressedEvent;
    /// <summary>This returns true if the given object is currently in event emission</summary>
    bool Interaction {
        get;
    }
}
/// <summary>Event argument wrapper for event <see cref="Efl.Input.IClickable.ClickedEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class ClickableClickedEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Called when object is in sequence pressed and unpressed by the primary button</value>
    public Efl.Input.ClickableClicked arg { get; set; }
}
/// <summary>Event argument wrapper for event <see cref="Efl.Input.IClickable.ClickedAnyEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class ClickableClickedAnyEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Called when object is in sequence pressed and unpressed by any button. The button that triggered the event can be found in the event information.</value>
    public Efl.Input.ClickableClicked arg { get; set; }
}
/// <summary>Event argument wrapper for event <see cref="Efl.Input.IClickable.PressedEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class ClickablePressedEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Called when the object is pressed, event_info is the button that got pressed</value>
    public int arg { get; set; }
}
/// <summary>Event argument wrapper for event <see cref="Efl.Input.IClickable.UnpressedEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class ClickableUnpressedEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Called when the object is no longer pressed, event_info is the button that got pressed</value>
    public int arg { get; set; }
}
/// <summary>Event argument wrapper for event <see cref="Efl.Input.IClickable.LongpressedEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class ClickableLongpressedEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Called when the object receives a long press, event_info is the button that got pressed</value>
    public int arg { get; set; }
}
/// <summary>Efl input clickable interface</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
public sealed class ClickableConcrete :
    Efl.Eo.EoWrapper
    , IClickable
    
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(ClickableConcrete))
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
    private ClickableConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] internal static extern System.IntPtr
        efl_input_clickable_mixin_get();
    /// <summary>Initializes a new instance of the <see cref="IClickable"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private ClickableConcrete(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Called when object is in sequence pressed and unpressed by the primary button</summary>
    /// <value><see cref="Efl.Input.ClickableClickedEventArgs"/></value>
    public event EventHandler<Efl.Input.ClickableClickedEventArgs> ClickedEvent
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
                        Efl.Input.ClickableClickedEventArgs args = new Efl.Input.ClickableClickedEventArgs();
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

                string key = "_EFL_INPUT_EVENT_CLICKED";
                AddNativeEventHandler(efl.Libs.Evas, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_INPUT_EVENT_CLICKED";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }
    /// <summary>Method to raise event ClickedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnClickedEvent(Efl.Input.ClickableClickedEventArgs e)
    {
        var key = "_EFL_INPUT_EVENT_CLICKED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Evas, key);
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
    /// <summary>Called when object is in sequence pressed and unpressed by any button. The button that triggered the event can be found in the event information.</summary>
    /// <value><see cref="Efl.Input.ClickableClickedAnyEventArgs"/></value>
    public event EventHandler<Efl.Input.ClickableClickedAnyEventArgs> ClickedAnyEvent
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
                        Efl.Input.ClickableClickedAnyEventArgs args = new Efl.Input.ClickableClickedAnyEventArgs();
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

                string key = "_EFL_INPUT_EVENT_CLICKED_ANY";
                AddNativeEventHandler(efl.Libs.Evas, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_INPUT_EVENT_CLICKED_ANY";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }
    /// <summary>Method to raise event ClickedAnyEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnClickedAnyEvent(Efl.Input.ClickableClickedAnyEventArgs e)
    {
        var key = "_EFL_INPUT_EVENT_CLICKED_ANY";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Evas, key);
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
    /// <summary>Called when the object is pressed, event_info is the button that got pressed</summary>
    /// <value><see cref="Efl.Input.ClickablePressedEventArgs"/></value>
    public event EventHandler<Efl.Input.ClickablePressedEventArgs> PressedEvent
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
                        Efl.Input.ClickablePressedEventArgs args = new Efl.Input.ClickablePressedEventArgs();
                        args.arg = Marshal.ReadInt32(evt.Info);
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

                string key = "_EFL_INPUT_EVENT_PRESSED";
                AddNativeEventHandler(efl.Libs.Evas, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_INPUT_EVENT_PRESSED";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }
    /// <summary>Method to raise event PressedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnPressedEvent(Efl.Input.ClickablePressedEventArgs e)
    {
        var key = "_EFL_INPUT_EVENT_PRESSED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Evas, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = Eina.PrimitiveConversion.ManagedToPointerAlloc(e.arg);
        try
        {
            Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Marshal.FreeHGlobal(info);
        }
    }
    /// <summary>Called when the object is no longer pressed, event_info is the button that got pressed</summary>
    /// <value><see cref="Efl.Input.ClickableUnpressedEventArgs"/></value>
    public event EventHandler<Efl.Input.ClickableUnpressedEventArgs> UnpressedEvent
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
                        Efl.Input.ClickableUnpressedEventArgs args = new Efl.Input.ClickableUnpressedEventArgs();
                        args.arg = Marshal.ReadInt32(evt.Info);
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

                string key = "_EFL_INPUT_EVENT_UNPRESSED";
                AddNativeEventHandler(efl.Libs.Evas, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_INPUT_EVENT_UNPRESSED";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }
    /// <summary>Method to raise event UnpressedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnUnpressedEvent(Efl.Input.ClickableUnpressedEventArgs e)
    {
        var key = "_EFL_INPUT_EVENT_UNPRESSED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Evas, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = Eina.PrimitiveConversion.ManagedToPointerAlloc(e.arg);
        try
        {
            Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Marshal.FreeHGlobal(info);
        }
    }
    /// <summary>Called when the object receives a long press, event_info is the button that got pressed</summary>
    /// <value><see cref="Efl.Input.ClickableLongpressedEventArgs"/></value>
    public event EventHandler<Efl.Input.ClickableLongpressedEventArgs> LongpressedEvent
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
                        Efl.Input.ClickableLongpressedEventArgs args = new Efl.Input.ClickableLongpressedEventArgs();
                        args.arg = Marshal.ReadInt32(evt.Info);
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

                string key = "_EFL_INPUT_EVENT_LONGPRESSED";
                AddNativeEventHandler(efl.Libs.Evas, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_INPUT_EVENT_LONGPRESSED";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }
    /// <summary>Method to raise event LongpressedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnLongpressedEvent(Efl.Input.ClickableLongpressedEventArgs e)
    {
        var key = "_EFL_INPUT_EVENT_LONGPRESSED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Evas, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = Eina.PrimitiveConversion.ManagedToPointerAlloc(e.arg);
        try
        {
            Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Marshal.FreeHGlobal(info);
        }
    }
#pragma warning disable CS0628
    /// <summary>This returns true if the given object is currently in event emission</summary>
    public bool GetInteraction() {
         var _ret_var = Efl.Input.ClickableConcrete.NativeMethods.efl_input_clickable_interaction_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Change internal states that a button got pressed.
    /// When the button is already pressed, this is silently ignored.</summary>
    /// <param name="button">The number of the button. FIXME ensure to have the right interval of possible input</param>
    protected void Press(uint button) {
                                 Efl.Input.ClickableConcrete.NativeMethods.efl_input_clickable_press_ptr.Value.Delegate(this.NativeHandle,button);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Change internal states that a button got unpressed.
    /// When the button is not pressed, this is silently ignored.</summary>
    /// <param name="button">The number of the button. FIXME ensure to have the right interval of possible input</param>
    protected void Unpress(uint button) {
                                 Efl.Input.ClickableConcrete.NativeMethods.efl_input_clickable_unpress_ptr.Value.Delegate(this.NativeHandle,button);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>This aborts the internal state after a press call.
    /// This will stop the timer for longpress and set the state of the clickable mixin back into the unpressed state.</summary>
    protected void ResetButtonState(uint button) {
                                 Efl.Input.ClickableConcrete.NativeMethods.efl_input_clickable_button_state_reset_ptr.Value.Delegate(this.NativeHandle,button);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>This aborts ongoing longpress event.
    /// That is, this will stop the timer for longpress.</summary>
    protected void LongpressAbort(uint button) {
                                 Efl.Input.ClickableConcrete.NativeMethods.efl_input_clickable_longpress_abort_ptr.Value.Delegate(this.NativeHandle,button);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>This returns true if the given object is currently in event emission</summary>
    public bool Interaction {
        get { return GetInteraction(); }
    }
#pragma warning restore CS0628
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Input.ClickableConcrete.efl_input_clickable_mixin_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Eo.EoWrapper.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Evas);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_input_clickable_interaction_get_static_delegate == null)
            {
                efl_input_clickable_interaction_get_static_delegate = new efl_input_clickable_interaction_get_delegate(interaction_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetInteraction") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_clickable_interaction_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_clickable_interaction_get_static_delegate) });
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
            return Efl.Input.ClickableConcrete.efl_input_clickable_mixin_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_input_clickable_interaction_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_input_clickable_interaction_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_input_clickable_interaction_get_api_delegate> efl_input_clickable_interaction_get_ptr = new Efl.Eo.FunctionWrapper<efl_input_clickable_interaction_get_api_delegate>(Module, "efl_input_clickable_interaction_get");

        private static bool interaction_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_input_clickable_interaction_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IClickable)ws.Target).GetInteraction();
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
                return efl_input_clickable_interaction_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_input_clickable_interaction_get_delegate efl_input_clickable_interaction_get_static_delegate;

        
        private delegate void efl_input_clickable_press_delegate(System.IntPtr obj, System.IntPtr pd,  uint button);

        
        public delegate void efl_input_clickable_press_api_delegate(System.IntPtr obj,  uint button);

        public static Efl.Eo.FunctionWrapper<efl_input_clickable_press_api_delegate> efl_input_clickable_press_ptr = new Efl.Eo.FunctionWrapper<efl_input_clickable_press_api_delegate>(Module, "efl_input_clickable_press");

        
        private delegate void efl_input_clickable_unpress_delegate(System.IntPtr obj, System.IntPtr pd,  uint button);

        
        public delegate void efl_input_clickable_unpress_api_delegate(System.IntPtr obj,  uint button);

        public static Efl.Eo.FunctionWrapper<efl_input_clickable_unpress_api_delegate> efl_input_clickable_unpress_ptr = new Efl.Eo.FunctionWrapper<efl_input_clickable_unpress_api_delegate>(Module, "efl_input_clickable_unpress");

        
        private delegate void efl_input_clickable_button_state_reset_delegate(System.IntPtr obj, System.IntPtr pd,  uint button);

        
        public delegate void efl_input_clickable_button_state_reset_api_delegate(System.IntPtr obj,  uint button);

        public static Efl.Eo.FunctionWrapper<efl_input_clickable_button_state_reset_api_delegate> efl_input_clickable_button_state_reset_ptr = new Efl.Eo.FunctionWrapper<efl_input_clickable_button_state_reset_api_delegate>(Module, "efl_input_clickable_button_state_reset");

        
        private delegate void efl_input_clickable_longpress_abort_delegate(System.IntPtr obj, System.IntPtr pd,  uint button);

        
        public delegate void efl_input_clickable_longpress_abort_api_delegate(System.IntPtr obj,  uint button);

        public static Efl.Eo.FunctionWrapper<efl_input_clickable_longpress_abort_api_delegate> efl_input_clickable_longpress_abort_ptr = new Efl.Eo.FunctionWrapper<efl_input_clickable_longpress_abort_api_delegate>(Module, "efl_input_clickable_longpress_abort");

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_InputClickableConcrete_ExtensionMethods {
    
}
#pragma warning restore CS1591
#endif
namespace Efl {

namespace Input {

/// <summary>A struct that expresses a click in elementary.</summary>
[StructLayout(LayoutKind.Sequential)]
[Efl.Eo.BindingEntity]
public struct ClickableClicked
{
    /// <summary>The amount of how often the clicked event was repeated in a certain amount of time</summary>
    public uint Repeated;
    /// <summary>The Button that is pressed</summary>
    public uint Button;
    /// <summary>Constructor for ClickableClicked.</summary>
    /// <param name="Repeated">The amount of how often the clicked event was repeated in a certain amount of time</param>
    /// <param name="Button">The Button that is pressed</param>
    public ClickableClicked(
        uint Repeated = default(uint),
        uint Button = default(uint)    )
    {
        this.Repeated = Repeated;
        this.Button = Button;
    }

    /// <summary>Implicit conversion to the managed representation from a native pointer.</summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator ClickableClicked(IntPtr ptr)
    {
        var tmp = (ClickableClicked.NativeStruct)Marshal.PtrToStructure(ptr, typeof(ClickableClicked.NativeStruct));
        return tmp;
    }

    #pragma warning disable CS1591

    /// <summary>Internal wrapper for struct ClickableClicked.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        
        public uint Repeated;
        
        public uint Button;
        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator ClickableClicked.NativeStruct(ClickableClicked _external_struct)
        {
            var _internal_struct = new ClickableClicked.NativeStruct();
            _internal_struct.Repeated = _external_struct.Repeated;
            _internal_struct.Button = _external_struct.Button;
            return _internal_struct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator ClickableClicked(ClickableClicked.NativeStruct _internal_struct)
        {
            var _external_struct = new ClickableClicked();
            _external_struct.Repeated = _internal_struct.Repeated;
            _external_struct.Button = _internal_struct.Button;
            return _external_struct;
        }

    }

    #pragma warning restore CS1591

}

}

}

