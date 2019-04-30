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
[Efl.Ui.ISelectionConcrete.NativeMethods]
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
        System.Threading.Tasks.Task<Eina.Value> SetSelectionAsync(Efl.Ui.SelectionType type,Efl.Ui.SelectionFormat format,Eina.Slice data,uint seat, System.Threading.CancellationToken token = default(System.Threading.CancellationToken));
                /// <summary>Called when display server&apos;s selection has changed</summary>
    event EventHandler<Efl.Ui.ISelectionWmSelectionChangedEvt_Args> WmSelectionChangedEvt;
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.ISelection.WmSelectionChangedEvt"/>.</summary>
public class ISelectionWmSelectionChangedEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Efl.Ui.SelectionChanged arg { get; set; }
}
/// <summary>Efl Ui Selection class</summary>
sealed public class ISelectionConcrete : 

ISelection
    
{
    ///<summary>Pointer to the native class description.</summary>
    public System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(ISelectionConcrete))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    private Dictionary<(IntPtr desc, object evtDelegate), (IntPtr evtCallerPtr, Efl.EventCb evtCaller)> eoEvents = new Dictionary<(IntPtr desc, object evtDelegate), (IntPtr evtCallerPtr, Efl.EventCb evtCaller)>();
    private readonly object eventLock = new object();
    private  System.IntPtr handle;
    ///<summary>Pointer to the native instance.</summary>
    public System.IntPtr NativeHandle
    {
        get { return handle; }
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_ui_selection_mixin_get();
    /// <summary>Initializes a new instance of the <see cref="ISelection"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    private ISelectionConcrete(System.IntPtr raw)
    {
        handle = raw;
    }
    ///<summary>Destructor.</summary>
    ~ISelectionConcrete()
    {
        Dispose(false);
    }

    ///<summary>Releases the underlying native instance.</summary>
    private void Dispose(bool disposing)
    {
        if (handle != System.IntPtr.Zero)
        {
            IntPtr h = handle;
            handle = IntPtr.Zero;

            IntPtr gcHandlePtr = IntPtr.Zero;
            if (eoEvents.Count != 0)
            {
                GCHandle gcHandle = GCHandle.Alloc(eoEvents);
                gcHandlePtr = GCHandle.ToIntPtr(gcHandle);
            }

            if (disposing)
            {
                Efl.Eo.Globals.efl_mono_native_dispose(h, gcHandlePtr);
            }
            else
            {
                Monitor.Enter(Efl.All.InitLock);
                if (Efl.All.MainLoopInitialized)
                {
                    Efl.Eo.Globals.efl_mono_thread_safe_native_dispose(h, gcHandlePtr);
                }

                Monitor.Exit(Efl.All.InitLock);
            }
        }

    }

    ///<summary>Releases the underlying native instance.</summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>Verifies if the given object is equal to this one.</summary>
    /// <param name="instance">The object to compare to.</param>
    /// <returns>True if both objects point to the same native object.</returns>
    public override bool Equals(object instance)
    {
        var other = instance as Efl.Object;
        if (other == null)
        {
            return false;
        }
        return this.NativeHandle == other.NativeHandle;
    }

    /// <summary>Gets the hash code for this object based on the native pointer it points to.</summary>
    /// <returns>The value of the pointer, to be used as the hash code of this object.</returns>
    public override int GetHashCode()
    {
        return this.NativeHandle.ToInt32();
    }

    /// <summary>Turns the native pointer into a string representation.</summary>
    /// <returns>A string with the type and the native pointer for this object.</returns>
    public override String ToString()
    {
        return $"{this.GetType().Name}@[{this.NativeHandle.ToInt32():x}]";
    }

    ///<summary>Adds a new event handler, registering it to the native event. For internal use only.</summary>
    ///<param name="lib">The name of the native library definining the event.</param>
    ///<param name="key">The name of the native event.</param>
    ///<param name="evtCaller">Delegate to be called by native code on event raising.</param>
    ///<param name="evtDelegate">Managed delegate that will be called by evtCaller on event raising.</param>
    private void AddNativeEventHandler(string lib, string key, Efl.EventCb evtCaller, object evtDelegate)
    {
        IntPtr desc = Efl.EventDescription.GetNative(lib, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
        }

        if (eoEvents.ContainsKey((desc, evtDelegate)))
        {
            Eina.Log.Warning($"Event proxy for event {key} already registered!");
            return;
        }

        IntPtr evtCallerPtr = Marshal.GetFunctionPointerForDelegate(evtCaller);
        if (!Efl.Eo.Globals.efl_event_callback_priority_add(handle, desc, 0, evtCallerPtr, IntPtr.Zero))
        {
            Eina.Log.Error($"Failed to add event proxy for event {key}");
            return;
        }

        eoEvents[(desc, evtDelegate)] = (evtCallerPtr, evtCaller);
        Eina.Error.RaiseIfUnhandledException();
    }

    ///<summary>Removes the given event handler for the given event. For internal use only.</summary>
    ///<param name="lib">The name of the native library definining the event.</param>
    ///<param name="key">The name of the native event.</param>
    ///<param name="evtDelegate">The delegate to be removed.</param>
    private void RemoveNativeEventHandler(string lib, string key, object evtDelegate)
    {
        IntPtr desc = Efl.EventDescription.GetNative(lib, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        var evtPair = (desc, evtDelegate);
        if (eoEvents.TryGetValue(evtPair, out var caller))
        {
            if (!Efl.Eo.Globals.efl_event_callback_del(handle, desc, caller.evtCallerPtr, IntPtr.Zero))
            {
                Eina.Log.Error($"Failed to remove event proxy for event {key}");
                return;
            }

            eoEvents.Remove(evtPair);
            Eina.Error.RaiseIfUnhandledException();
        }
        else
        {
            Eina.Log.Error($"Trying to remove proxy for event {key} when it is nothing registered.");
        }
    }

    /// <summary>Called when display server&apos;s selection has changed</summary>
    public event EventHandler<Efl.Ui.ISelectionWmSelectionChangedEvt_Args> WmSelectionChangedEvt
    {
        add
        {
            lock (eventLock)
            {
                var wRef = new WeakReference(this);
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = wRef.Target as Efl.Eo.IWrapper;
                    if (obj != null)
                    {
                                                Efl.Ui.ISelectionWmSelectionChangedEvt_Args args = new Efl.Ui.ISelectionWmSelectionChangedEvt_Args();
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
            lock (eventLock)
            {
                string key = "_EFL_UI_SELECTION_EVENT_WM_SELECTION_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event WmSelectionChangedEvt.</summary>
    public void OnWmSelectionChangedEvt(Efl.Ui.ISelectionWmSelectionChangedEvt_Args e)
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
    /// <summary>Set the selection data to the object</summary>
    /// <param name="type">Selection Type</param>
    /// <param name="format">Selection Format</param>
    /// <param name="data">Selection data</param>
    /// <param name="seat">Specified seat for multiple seats case.</param>
    /// <returns>Future for tracking when the selection is lost</returns>
    public  Eina.Future SetSelection(Efl.Ui.SelectionType type, Efl.Ui.SelectionFormat format, Eina.Slice data, uint seat) {
                                                                                                         var _ret_var = Efl.Ui.ISelectionConcrete.NativeMethods.efl_ui_selection_set_ptr.Value.Delegate(this.NativeHandle,type, format, data, seat);
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
                Efl.Ui.ISelectionConcrete.NativeMethods.efl_ui_selection_get_ptr.Value.Delegate(this.NativeHandle,type, format, GCHandle.ToIntPtr(data_func_handle), Efl.Ui.SelectionDataReadyWrapper.Cb, Efl.Eo.Globals.free_gchandle, seat);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Clear the selection data from the object</summary>
    /// <param name="type">Selection Type</param>
    /// <param name="seat">Specified seat for multiple seats case.</param>
    public void ClearSelection(Efl.Ui.SelectionType type, uint seat) {
                                                         Efl.Ui.ISelectionConcrete.NativeMethods.efl_ui_selection_clear_ptr.Value.Delegate(this.NativeHandle,type, seat);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Determine whether the selection data has owner</summary>
    /// <param name="type">Selection type</param>
    /// <param name="seat">Specified seat for multiple seats case.</param>
    /// <returns>EINA_TRUE if there is object owns selection, otherwise EINA_FALSE</returns>
    public bool HasOwner(Efl.Ui.SelectionType type, uint seat) {
                                                         var _ret_var = Efl.Ui.ISelectionConcrete.NativeMethods.efl_ui_selection_has_owner_ptr.Value.Delegate(this.NativeHandle,type, seat);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    public System.Threading.Tasks.Task<Eina.Value> SetSelectionAsync(Efl.Ui.SelectionType type,Efl.Ui.SelectionFormat format,Eina.Slice data,uint seat, System.Threading.CancellationToken token = default(System.Threading.CancellationToken))
    {
        Eina.Future future = SetSelection( type, format, data, seat);
        return Efl.Eo.Globals.WrapAsync(future, token);
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.ISelectionConcrete.efl_ui_selection_mixin_get();
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

            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.ISelectionConcrete.efl_ui_selection_mixin_get();
        }

        #pragma warning disable CA1707, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))]
        private delegate  Eina.Future efl_ui_selection_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.SelectionType type,  Efl.Ui.SelectionFormat format,  Eina.Slice data,  uint seat);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))]
        public delegate  Eina.Future efl_ui_selection_set_api_delegate(System.IntPtr obj,  Efl.Ui.SelectionType type,  Efl.Ui.SelectionFormat format,  Eina.Slice data,  uint seat);

        public static Efl.Eo.FunctionWrapper<efl_ui_selection_set_api_delegate> efl_ui_selection_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_selection_set_api_delegate>(Module, "efl_ui_selection_set");

        private static  Eina.Future selection_set(System.IntPtr obj, System.IntPtr pd, Efl.Ui.SelectionType type, Efl.Ui.SelectionFormat format, Eina.Slice data, uint seat)
        {
            Eina.Log.Debug("function efl_ui_selection_set was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                                                                                             Eina.Future _ret_var = default( Eina.Future);
                try
                {
                    _ret_var = ((ISelectionConcrete)wrapper).SetSelection(type, format, data, seat);
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
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                                                                            Efl.Ui.SelectionDataReadyWrapper data_func_wrapper = new Efl.Ui.SelectionDataReadyWrapper(data_func, data_func_data, data_func_free_cb);
                    
                try
                {
                    ((ISelectionConcrete)wrapper).GetSelection(type, format, data_func_wrapper.ManagedCb, seat);
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
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                                            
                try
                {
                    ((ISelectionConcrete)wrapper).ClearSelection(type, seat);
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
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                                            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((ISelectionConcrete)wrapper).HasOwner(type, seat);
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

        #pragma warning restore CA1707, SA1300, SA1600

}
}
}

}

