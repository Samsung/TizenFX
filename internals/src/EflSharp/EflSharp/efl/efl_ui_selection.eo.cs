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

/// <summary>Efl Ui Selection class</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Ui.SelectionConcrete.NativeMethods]
[Efl.Eo.BindingEntity]
public interface ISelection : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Set the selection data to the object</summary>
/// <param name="type">Selection Type</param>
/// <param name="format">Selection Format</param>
/// <param name="data">Selection data</param>
/// <param name="seat">Specified seat for multiple seats case.</param>
/// <returns>Future for tracking when the selection is lost</returns>
 Eina.Future SetSelection(Efl.Ui.SelectionType type, Efl.Ui.SelectionFormat format, Eina.Slice data, uint seat);
    /// <summary>Get the data from the object that has selection</summary>
/// <param name="type">Selection Type</param>
/// <param name="format">Selection Format</param>
/// <param name="data_func">Data ready function pointer</param>
/// <param name="seat">Specified seat for multiple seats case.</param>
void GetSelection(Efl.Ui.SelectionType type, Efl.Ui.SelectionFormat format, Efl.Ui.SelectionDataReady data_func, uint seat);
    /// <summary>Clear the selection data from the object</summary>
/// <param name="type">Selection Type</param>
/// <param name="seat">Specified seat for multiple seats case.</param>
void ClearSelection(Efl.Ui.SelectionType type, uint seat);
    /// <summary>Determine whether the selection data has owner</summary>
/// <param name="type">Selection type</param>
/// <param name="seat">Specified seat for multiple seats case.</param>
/// <returns>EINA_TRUE if there is object owns selection, otherwise EINA_FALSE</returns>
bool HasOwner(Efl.Ui.SelectionType type, uint seat);
        /// <summary>Async wrapper for <see cref="SetSelection" />.</summary>
    /// <param name="type">Selection Type</param>
    /// <param name="format">Selection Format</param>
    /// <param name="data">Selection data</param>
    /// <param name="seat">Specified seat for multiple seats case.</param>
    /// <param name="token">Token to notify the async operation of external request to cancel.</param>
    /// <returns>An async task wrapping the result of the operation.</returns>
    System.Threading.Tasks.Task<Eina.Value> SetSelectionAsync(Efl.Ui.SelectionType type,Efl.Ui.SelectionFormat format,Eina.Slice data,uint seat, System.Threading.CancellationToken token = default(System.Threading.CancellationToken));

                /// <summary>Called when display server&apos;s selection has changed</summary>
    /// <value><see cref="Efl.Ui.SelectionWmSelectionChangedEventArgs"/></value>
    event EventHandler<Efl.Ui.SelectionWmSelectionChangedEventArgs> WmSelectionChangedEvent;
}
/// <summary>Event argument wrapper for event <see cref="Efl.Ui.ISelection.WmSelectionChangedEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class SelectionWmSelectionChangedEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Called when display server&apos;s selection has changed</value>
    public Efl.Ui.SelectionChanged arg { get; set; }
}
/// <summary>Efl Ui Selection class</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
public sealed class SelectionConcrete :
    Efl.Eo.EoWrapper
    , ISelection
    
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(SelectionConcrete))
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
    private SelectionConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_ui_selection_mixin_get();
    /// <summary>Initializes a new instance of the <see cref="ISelection"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private SelectionConcrete(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Called when display server&apos;s selection has changed</summary>
    /// <value><see cref="Efl.Ui.SelectionWmSelectionChangedEventArgs"/></value>
    public event EventHandler<Efl.Ui.SelectionWmSelectionChangedEventArgs> WmSelectionChangedEvent
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
                        Efl.Ui.SelectionWmSelectionChangedEventArgs args = new Efl.Ui.SelectionWmSelectionChangedEventArgs();
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

                string key = "_EFL_UI_SELECTION_EVENT_WM_SELECTION_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_SELECTION_EVENT_WM_SELECTION_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event WmSelectionChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnWmSelectionChangedEvent(Efl.Ui.SelectionWmSelectionChangedEventArgs e)
    {
        var key = "_EFL_UI_SELECTION_EVENT_WM_SELECTION_CHANGED";
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
#pragma warning disable CS0628
    /// <summary>Set the selection data to the object</summary>
    /// <param name="type">Selection Type</param>
    /// <param name="format">Selection Format</param>
    /// <param name="data">Selection data</param>
    /// <param name="seat">Specified seat for multiple seats case.</param>
    /// <returns>Future for tracking when the selection is lost</returns>
    public  Eina.Future SetSelection(Efl.Ui.SelectionType type, Efl.Ui.SelectionFormat format, Eina.Slice data, uint seat) {
                                                                                                         var _ret_var = Efl.Ui.SelectionConcrete.NativeMethods.efl_ui_selection_set_ptr.Value.Delegate(this.NativeHandle,type, format, data, seat);
        Eina.Error.RaiseIfUnhandledException();
                                                                        return _ret_var;
 }
    /// <summary>Get the data from the object that has selection</summary>
    /// <param name="type">Selection Type</param>
    /// <param name="format">Selection Format</param>
    /// <param name="data_func">Data ready function pointer</param>
    /// <param name="seat">Specified seat for multiple seats case.</param>
    public void GetSelection(Efl.Ui.SelectionType type, Efl.Ui.SelectionFormat format, Efl.Ui.SelectionDataReady data_func, uint seat) {
                                                                                         GCHandle data_func_handle = GCHandle.Alloc(data_func);
                Efl.Ui.SelectionConcrete.NativeMethods.efl_ui_selection_get_ptr.Value.Delegate(this.NativeHandle,type, format, GCHandle.ToIntPtr(data_func_handle), Efl.Ui.SelectionDataReadyWrapper.Cb, Efl.Eo.Globals.free_gchandle, seat);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Clear the selection data from the object</summary>
    /// <param name="type">Selection Type</param>
    /// <param name="seat">Specified seat for multiple seats case.</param>
    public void ClearSelection(Efl.Ui.SelectionType type, uint seat) {
                                                         Efl.Ui.SelectionConcrete.NativeMethods.efl_ui_selection_clear_ptr.Value.Delegate(this.NativeHandle,type, seat);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Determine whether the selection data has owner</summary>
    /// <param name="type">Selection type</param>
    /// <param name="seat">Specified seat for multiple seats case.</param>
    /// <returns>EINA_TRUE if there is object owns selection, otherwise EINA_FALSE</returns>
    public bool HasOwner(Efl.Ui.SelectionType type, uint seat) {
                                                         var _ret_var = Efl.Ui.SelectionConcrete.NativeMethods.efl_ui_selection_has_owner_ptr.Value.Delegate(this.NativeHandle,type, seat);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Async wrapper for <see cref="SetSelection" />.</summary>
    /// <param name="type">Selection Type</param>
    /// <param name="format">Selection Format</param>
    /// <param name="data">Selection data</param>
    /// <param name="seat">Specified seat for multiple seats case.</param>
    /// <param name="token">Token to notify the async operation of external request to cancel.</param>
    /// <returns>An async task wrapping the result of the operation.</returns>
    public System.Threading.Tasks.Task<Eina.Value> SetSelectionAsync(Efl.Ui.SelectionType type,Efl.Ui.SelectionFormat format,Eina.Slice data,uint seat, System.Threading.CancellationToken token = default(System.Threading.CancellationToken))
    {
        Eina.Future future = SetSelection( type, format, data, seat);
        return Efl.Eo.Globals.WrapAsync(future, token);
    }

#pragma warning restore CS0628
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.SelectionConcrete.efl_ui_selection_mixin_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Eo.EoWrapper.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Elementary);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_ui_selection_set_static_delegate == null)
            {
                efl_ui_selection_set_static_delegate = new efl_ui_selection_set_delegate(selection_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetSelection") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_selection_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_selection_set_static_delegate) });
            }

            if (efl_ui_selection_get_static_delegate == null)
            {
                efl_ui_selection_get_static_delegate = new efl_ui_selection_get_delegate(selection_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetSelection") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_selection_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_selection_get_static_delegate) });
            }

            if (efl_ui_selection_clear_static_delegate == null)
            {
                efl_ui_selection_clear_static_delegate = new efl_ui_selection_clear_delegate(selection_clear);
            }

            if (methods.FirstOrDefault(m => m.Name == "ClearSelection") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_selection_clear"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_selection_clear_static_delegate) });
            }

            if (efl_ui_selection_has_owner_static_delegate == null)
            {
                efl_ui_selection_has_owner_static_delegate = new efl_ui_selection_has_owner_delegate(has_owner);
            }

            if (methods.FirstOrDefault(m => m.Name == "HasOwner") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_selection_has_owner"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_selection_has_owner_static_delegate) });
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
            return Efl.Ui.SelectionConcrete.efl_ui_selection_mixin_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))]
        private delegate  Eina.Future efl_ui_selection_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.SelectionType type,  Efl.Ui.SelectionFormat format,  Eina.Slice data,  uint seat);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))]
        public delegate  Eina.Future efl_ui_selection_set_api_delegate(System.IntPtr obj,  Efl.Ui.SelectionType type,  Efl.Ui.SelectionFormat format,  Eina.Slice data,  uint seat);

        public static Efl.Eo.FunctionWrapper<efl_ui_selection_set_api_delegate> efl_ui_selection_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_selection_set_api_delegate>(Module, "efl_ui_selection_set");

        private static  Eina.Future selection_set(System.IntPtr obj, System.IntPtr pd, Efl.Ui.SelectionType type, Efl.Ui.SelectionFormat format, Eina.Slice data, uint seat)
        {
            Eina.Log.Debug("function efl_ui_selection_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                                             Eina.Future _ret_var = default( Eina.Future);
                try
                {
                    _ret_var = ((ISelection)ws.Target).SetSelection(type, format, data, seat);
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
                return efl_ui_selection_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), type, format, data, seat);
            }
        }

        private static efl_ui_selection_set_delegate efl_ui_selection_set_static_delegate;

        
        private delegate void efl_ui_selection_get_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.SelectionType type,  Efl.Ui.SelectionFormat format,  IntPtr data_func_data, Efl.Ui.SelectionDataReadyInternal data_func, EinaFreeCb data_func_free_cb,  uint seat);

        
        public delegate void efl_ui_selection_get_api_delegate(System.IntPtr obj,  Efl.Ui.SelectionType type,  Efl.Ui.SelectionFormat format,  IntPtr data_func_data, Efl.Ui.SelectionDataReadyInternal data_func, EinaFreeCb data_func_free_cb,  uint seat);

        public static Efl.Eo.FunctionWrapper<efl_ui_selection_get_api_delegate> efl_ui_selection_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_selection_get_api_delegate>(Module, "efl_ui_selection_get");

        private static void selection_get(System.IntPtr obj, System.IntPtr pd, Efl.Ui.SelectionType type, Efl.Ui.SelectionFormat format, IntPtr data_func_data, Efl.Ui.SelectionDataReadyInternal data_func, EinaFreeCb data_func_free_cb, uint seat)
        {
            Eina.Log.Debug("function efl_ui_selection_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                            Efl.Ui.SelectionDataReadyWrapper data_func_wrapper = new Efl.Ui.SelectionDataReadyWrapper(data_func, data_func_data, data_func_free_cb);
                    
                try
                {
                    ((ISelection)ws.Target).GetSelection(type, format, data_func_wrapper.ManagedCb, seat);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        
            }
            else
            {
                efl_ui_selection_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), type, format, data_func_data, data_func, data_func_free_cb, seat);
            }
        }

        private static efl_ui_selection_get_delegate efl_ui_selection_get_static_delegate;

        
        private delegate void efl_ui_selection_clear_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.SelectionType type,  uint seat);

        
        public delegate void efl_ui_selection_clear_api_delegate(System.IntPtr obj,  Efl.Ui.SelectionType type,  uint seat);

        public static Efl.Eo.FunctionWrapper<efl_ui_selection_clear_api_delegate> efl_ui_selection_clear_ptr = new Efl.Eo.FunctionWrapper<efl_ui_selection_clear_api_delegate>(Module, "efl_ui_selection_clear");

        private static void selection_clear(System.IntPtr obj, System.IntPtr pd, Efl.Ui.SelectionType type, uint seat)
        {
            Eina.Log.Debug("function efl_ui_selection_clear was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((ISelection)ws.Target).ClearSelection(type, seat);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_selection_clear_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), type, seat);
            }
        }

        private static efl_ui_selection_clear_delegate efl_ui_selection_clear_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_selection_has_owner_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.SelectionType type,  uint seat);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_selection_has_owner_api_delegate(System.IntPtr obj,  Efl.Ui.SelectionType type,  uint seat);

        public static Efl.Eo.FunctionWrapper<efl_ui_selection_has_owner_api_delegate> efl_ui_selection_has_owner_ptr = new Efl.Eo.FunctionWrapper<efl_ui_selection_has_owner_api_delegate>(Module, "efl_ui_selection_has_owner");

        private static bool has_owner(System.IntPtr obj, System.IntPtr pd, Efl.Ui.SelectionType type, uint seat)
        {
            Eina.Log.Debug("function efl_ui_selection_has_owner was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((ISelection)ws.Target).HasOwner(type, seat);
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
                return efl_ui_selection_has_owner_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), type, seat);
            }
        }

        private static efl_ui_selection_has_owner_delegate efl_ui_selection_has_owner_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_UiSelectionConcrete_ExtensionMethods {
}
#pragma warning restore CS1591
#endif
