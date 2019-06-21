#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Ui {

/// <summary>Efl UI clickable interface</summary>
[Efl.Ui.IClickableConcrete.NativeMethods]
public interface IClickable : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Change internal states that a button got pressed.
/// When the button is already pressed, this is silently ignored.</summary>
/// <param name="button">The number of the button. FIXME ensure to have the right interval of possible input</param>
void Press(uint button);
    /// <summary>Change internal states that a button got unpressed.
/// When the button is not pressed, this is silently ignored.</summary>
/// <param name="button">The number of the button. FIXME ensure to have the right interval of possible input</param>
void Unpress(uint button);
    /// <summary>This aborts the internal state after a press call.
/// This will stop the timer for longpress. And set the state of the clickable mixin back into the unpressed state.</summary>
void ResetButtonState(uint button);
                /// <summary>Called when object is in sequence pressed and unpressed, by the primary button</summary>
    event EventHandler<Efl.Ui.IClickableClickedEvt_Args> ClickedEvt;
    /// <summary>Called when object is in sequence pressed and unpressed by any button. The button that triggered the event can be found in the event information.</summary>
    event EventHandler<Efl.Ui.IClickableClickedAnyEvt_Args> ClickedAnyEvt;
    /// <summary>Called when the object is pressed, event_info is the button that got pressed</summary>
    event EventHandler<Efl.Ui.IClickablePressedEvt_Args> PressedEvt;
    /// <summary>Called when the object is no longer pressed, event_info is the button that got pressed</summary>
    event EventHandler<Efl.Ui.IClickableUnpressedEvt_Args> UnpressedEvt;
    /// <summary>Called when the object receives a long press, event_info is the button that got pressed</summary>
    event EventHandler<Efl.Ui.IClickableLongpressedEvt_Args> LongpressedEvt;
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.IClickable.ClickedEvt"/>.</summary>
public class IClickableClickedEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Efl.Ui.ClickableClicked arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.IClickable.ClickedAnyEvt"/>.</summary>
public class IClickableClickedAnyEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Efl.Ui.ClickableClicked arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.IClickable.PressedEvt"/>.</summary>
public class IClickablePressedEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public int arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.IClickable.UnpressedEvt"/>.</summary>
public class IClickableUnpressedEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public int arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.IClickable.LongpressedEvt"/>.</summary>
public class IClickableLongpressedEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public int arg { get; set; }
}
/// <summary>Efl UI clickable interface</summary>
sealed public class IClickableConcrete :
    Efl.Eo.EoWrapper
    , IClickable
    
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(IClickableConcrete))
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
        efl_ui_clickable_mixin_get();
    /// <summary>Initializes a new instance of the <see cref="IClickable"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    private IClickableConcrete(System.IntPtr raw) : base(raw)
    {
    }

    /// <summary>Called when object is in sequence pressed and unpressed, by the primary button</summary>
    public event EventHandler<Efl.Ui.IClickableClickedEvt_Args> ClickedEvt
    {
        add
        {
            lock (eventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        Efl.Ui.IClickableClickedEvt_Args args = new Efl.Ui.IClickableClickedEvt_Args();
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

                string key = "_EFL_UI_EVENT_CLICKED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_UI_EVENT_CLICKED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event ClickedEvt.</summary>
    public void OnClickedEvt(Efl.Ui.IClickableClickedEvt_Args e)
    {
        var key = "_EFL_UI_EVENT_CLICKED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
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
    public event EventHandler<Efl.Ui.IClickableClickedAnyEvt_Args> ClickedAnyEvt
    {
        add
        {
            lock (eventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        Efl.Ui.IClickableClickedAnyEvt_Args args = new Efl.Ui.IClickableClickedAnyEvt_Args();
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

                string key = "_EFL_UI_EVENT_CLICKED_ANY";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_UI_EVENT_CLICKED_ANY";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event ClickedAnyEvt.</summary>
    public void OnClickedAnyEvt(Efl.Ui.IClickableClickedAnyEvt_Args e)
    {
        var key = "_EFL_UI_EVENT_CLICKED_ANY";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
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
    public event EventHandler<Efl.Ui.IClickablePressedEvt_Args> PressedEvt
    {
        add
        {
            lock (eventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        Efl.Ui.IClickablePressedEvt_Args args = new Efl.Ui.IClickablePressedEvt_Args();
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

                string key = "_EFL_UI_EVENT_PRESSED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_UI_EVENT_PRESSED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event PressedEvt.</summary>
    public void OnPressedEvt(Efl.Ui.IClickablePressedEvt_Args e)
    {
        var key = "_EFL_UI_EVENT_PRESSED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
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
    public event EventHandler<Efl.Ui.IClickableUnpressedEvt_Args> UnpressedEvt
    {
        add
        {
            lock (eventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        Efl.Ui.IClickableUnpressedEvt_Args args = new Efl.Ui.IClickableUnpressedEvt_Args();
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

                string key = "_EFL_UI_EVENT_UNPRESSED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_UI_EVENT_UNPRESSED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event UnpressedEvt.</summary>
    public void OnUnpressedEvt(Efl.Ui.IClickableUnpressedEvt_Args e)
    {
        var key = "_EFL_UI_EVENT_UNPRESSED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
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
    public event EventHandler<Efl.Ui.IClickableLongpressedEvt_Args> LongpressedEvt
    {
        add
        {
            lock (eventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        Efl.Ui.IClickableLongpressedEvt_Args args = new Efl.Ui.IClickableLongpressedEvt_Args();
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

                string key = "_EFL_UI_EVENT_LONGPRESSED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_UI_EVENT_LONGPRESSED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event LongpressedEvt.</summary>
    public void OnLongpressedEvt(Efl.Ui.IClickableLongpressedEvt_Args e)
    {
        var key = "_EFL_UI_EVENT_LONGPRESSED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
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
    /// <summary>Change internal states that a button got pressed.
    /// When the button is already pressed, this is silently ignored.</summary>
    /// <param name="button">The number of the button. FIXME ensure to have the right interval of possible input</param>
    public void Press(uint button) {
                                 Efl.Ui.IClickableConcrete.NativeMethods.efl_ui_clickable_press_ptr.Value.Delegate(this.NativeHandle,button);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Change internal states that a button got unpressed.
    /// When the button is not pressed, this is silently ignored.</summary>
    /// <param name="button">The number of the button. FIXME ensure to have the right interval of possible input</param>
    public void Unpress(uint button) {
                                 Efl.Ui.IClickableConcrete.NativeMethods.efl_ui_clickable_unpress_ptr.Value.Delegate(this.NativeHandle,button);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>This aborts the internal state after a press call.
    /// This will stop the timer for longpress. And set the state of the clickable mixin back into the unpressed state.</summary>
    public void ResetButtonState(uint button) {
                                 Efl.Ui.IClickableConcrete.NativeMethods.efl_ui_clickable_button_state_reset_ptr.Value.Delegate(this.NativeHandle,button);
        Eina.Error.RaiseIfUnhandledException();
                         }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.IClickableConcrete.efl_ui_clickable_mixin_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public class NativeMethods  : Efl.Eo.NativeClass
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Elementary);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_ui_clickable_press_static_delegate == null)
            {
                efl_ui_clickable_press_static_delegate = new efl_ui_clickable_press_delegate(press);
            }

            if (methods.FirstOrDefault(m => m.Name == "Press") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_clickable_press"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_clickable_press_static_delegate) });
            }

            if (efl_ui_clickable_unpress_static_delegate == null)
            {
                efl_ui_clickable_unpress_static_delegate = new efl_ui_clickable_unpress_delegate(unpress);
            }

            if (methods.FirstOrDefault(m => m.Name == "Unpress") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_clickable_unpress"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_clickable_unpress_static_delegate) });
            }

            if (efl_ui_clickable_button_state_reset_static_delegate == null)
            {
                efl_ui_clickable_button_state_reset_static_delegate = new efl_ui_clickable_button_state_reset_delegate(button_state_reset);
            }

            if (methods.FirstOrDefault(m => m.Name == "ResetButtonState") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_clickable_button_state_reset"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_clickable_button_state_reset_static_delegate) });
            }

            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.IClickableConcrete.efl_ui_clickable_mixin_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate void efl_ui_clickable_press_delegate(System.IntPtr obj, System.IntPtr pd,  uint button);

        
        public delegate void efl_ui_clickable_press_api_delegate(System.IntPtr obj,  uint button);

        public static Efl.Eo.FunctionWrapper<efl_ui_clickable_press_api_delegate> efl_ui_clickable_press_ptr = new Efl.Eo.FunctionWrapper<efl_ui_clickable_press_api_delegate>(Module, "efl_ui_clickable_press");

        private static void press(System.IntPtr obj, System.IntPtr pd, uint button)
        {
            Eina.Log.Debug("function efl_ui_clickable_press was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((IClickableConcrete)ws.Target).Press(button);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_clickable_press_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), button);
            }
        }

        private static efl_ui_clickable_press_delegate efl_ui_clickable_press_static_delegate;

        
        private delegate void efl_ui_clickable_unpress_delegate(System.IntPtr obj, System.IntPtr pd,  uint button);

        
        public delegate void efl_ui_clickable_unpress_api_delegate(System.IntPtr obj,  uint button);

        public static Efl.Eo.FunctionWrapper<efl_ui_clickable_unpress_api_delegate> efl_ui_clickable_unpress_ptr = new Efl.Eo.FunctionWrapper<efl_ui_clickable_unpress_api_delegate>(Module, "efl_ui_clickable_unpress");

        private static void unpress(System.IntPtr obj, System.IntPtr pd, uint button)
        {
            Eina.Log.Debug("function efl_ui_clickable_unpress was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((IClickableConcrete)ws.Target).Unpress(button);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_clickable_unpress_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), button);
            }
        }

        private static efl_ui_clickable_unpress_delegate efl_ui_clickable_unpress_static_delegate;

        
        private delegate void efl_ui_clickable_button_state_reset_delegate(System.IntPtr obj, System.IntPtr pd,  uint button);

        
        public delegate void efl_ui_clickable_button_state_reset_api_delegate(System.IntPtr obj,  uint button);

        public static Efl.Eo.FunctionWrapper<efl_ui_clickable_button_state_reset_api_delegate> efl_ui_clickable_button_state_reset_ptr = new Efl.Eo.FunctionWrapper<efl_ui_clickable_button_state_reset_api_delegate>(Module, "efl_ui_clickable_button_state_reset");

        private static void button_state_reset(System.IntPtr obj, System.IntPtr pd, uint button)
        {
            Eina.Log.Debug("function efl_ui_clickable_button_state_reset was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((IClickableConcrete)ws.Target).ResetButtonState(button);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_clickable_button_state_reset_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), button);
            }
        }

        private static efl_ui_clickable_button_state_reset_delegate efl_ui_clickable_button_state_reset_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

namespace Efl {

namespace Ui {

/// <summary>A struct that expresses a click in elementary.</summary>
[StructLayout(LayoutKind.Sequential)]
public struct ClickableClicked
{
    /// <summary>The amount of how often the clicked event was repeated in a certain amount of time</summary>
    public int Repeated;
    /// <summary>The Button that is pressed</summary>
    public int Button;
    ///<summary>Constructor for ClickableClicked.</summary>
    public ClickableClicked(
        int Repeated = default(int),
        int Button = default(int)    )
    {
        this.Repeated = Repeated;
        this.Button = Button;
    }

    ///<summary>Implicit conversion to the managed representation from a native pointer.</summary>
    ///<param name="ptr">Native pointer to be converted.</param>
    public static implicit operator ClickableClicked(IntPtr ptr)
    {
        var tmp = (ClickableClicked.NativeStruct)Marshal.PtrToStructure(ptr, typeof(ClickableClicked.NativeStruct));
        return tmp;
    }

    #pragma warning disable CS1591

    ///<summary>Internal wrapper for struct ClickableClicked.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        
        public int Repeated;
        
        public int Button;
        ///<summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator ClickableClicked.NativeStruct(ClickableClicked _external_struct)
        {
            var _internal_struct = new ClickableClicked.NativeStruct();
            _internal_struct.Repeated = _external_struct.Repeated;
            _internal_struct.Button = _external_struct.Button;
            return _internal_struct;
        }

        ///<summary>Implicit conversion to the managed representation.</summary>
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

