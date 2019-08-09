#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Io {

/// <summary>Generic interface for objects that can close themselves.
/// This interface allows external objects to transparently close an input or output stream, cleaning up its resources.
/// 
/// Calls to <see cref="Efl.Io.ICloser.Close"/> may or may not block, that&apos;s not up to this interface to specify.
/// (Since EFL 1.22)</summary>
[Efl.Io.ICloserConcrete.NativeMethods]
[Efl.Eo.BindingEntity]
public interface ICloser : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>If true will notify object was closed.
/// (Since EFL 1.22)</summary>
/// <returns><c>true</c> if closed, <c>false</c> otherwise</returns>
bool GetClosed();
    /// <summary>If true will automatically close resources on exec() calls.
/// When using file descriptors this should set FD_CLOEXEC so they are not inherited by the processes (children or self) doing exec().
/// (Since EFL 1.22)</summary>
/// <returns><c>true</c> if close on exec(), <c>false</c> otherwise</returns>
bool GetCloseOnExec();
    /// <summary>If <c>true</c>, will close on exec() call.
/// (Since EFL 1.22)</summary>
/// <param name="close_on_exec"><c>true</c> if close on exec(), <c>false</c> otherwise</param>
/// <returns><c>true</c> if could set, <c>false</c> if not supported or failed.</returns>
bool SetCloseOnExec(bool close_on_exec);
    /// <summary>If true will automatically close() on object invalidate.
/// If the object was disconnected from its parent (including the main loop) without close, this property will state whenever it should be closed or not.
/// (Since EFL 1.22)</summary>
/// <returns><c>true</c> if close on invalidate, <c>false</c> otherwise</returns>
bool GetCloseOnInvalidate();
    /// <summary>If true will automatically close() on object invalidate.
/// If the object was disconnected from its parent (including the main loop) without close, this property will state whenever it should be closed or not.
/// (Since EFL 1.22)</summary>
/// <param name="close_on_invalidate"><c>true</c> if close on invalidate, <c>false</c> otherwise</param>
void SetCloseOnInvalidate(bool close_on_invalidate);
    /// <summary>Closes the Input/Output object.
/// This operation will be executed immediately and may or may not block the caller thread for some time. The details of blocking behavior is to be defined by the implementation and may be subject to other parameters such as non-blocking flags, maximum timeout or even retry attempts.
/// 
/// You can understand this method as close(2) libc function.
/// (Since EFL 1.22)</summary>
/// <returns>0 on succeed, a mapping of errno otherwise</returns>
Eina.Error Close();
                            /// <summary>Notifies closed, when property is marked as true
    /// (Since EFL 1.22)</summary>
    event EventHandler ClosedEvt;
    /// <summary>If true will notify object was closed.
    /// (Since EFL 1.22)</summary>
    /// <value><c>true</c> if closed, <c>false</c> otherwise</value>
    bool Closed {
        get ;
    }
    /// <summary>If true will automatically close resources on exec() calls.
    /// When using file descriptors this should set FD_CLOEXEC so they are not inherited by the processes (children or self) doing exec().
    /// (Since EFL 1.22)</summary>
    /// <value><c>true</c> if close on exec(), <c>false</c> otherwise</value>
    bool CloseOnExec {
        get ;
        set ;
    }
    /// <summary>If true will automatically close() on object invalidate.
    /// If the object was disconnected from its parent (including the main loop) without close, this property will state whenever it should be closed or not.
    /// (Since EFL 1.22)</summary>
    /// <value><c>true</c> if close on invalidate, <c>false</c> otherwise</value>
    bool CloseOnInvalidate {
        get ;
        set ;
    }
}
/// <summary>Generic interface for objects that can close themselves.
/// This interface allows external objects to transparently close an input or output stream, cleaning up its resources.
/// 
/// Calls to <see cref="Efl.Io.ICloser.Close"/> may or may not block, that&apos;s not up to this interface to specify.
/// (Since EFL 1.22)</summary>
sealed public class ICloserConcrete :
    Efl.Eo.EoWrapper
    , ICloser
    
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(ICloserConcrete))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    /// <summary>Constructor to be used when objects are expected to be constructed from native code.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    private ICloserConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
        efl_io_closer_interface_get();
    /// <summary>Initializes a new instance of the <see cref="ICloser"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private ICloserConcrete(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Notifies closed, when property is marked as true
    /// (Since EFL 1.22)</summary>
    public event EventHandler ClosedEvt
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

                string key = "_EFL_IO_CLOSER_EVENT_CLOSED";
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_IO_CLOSER_EVENT_CLOSED";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    ///<summary>Method to raise event ClosedEvt.</summary>
    public void OnClosedEvt(EventArgs e)
    {
        var key = "_EFL_IO_CLOSER_EVENT_CLOSED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>If true will notify object was closed.
    /// (Since EFL 1.22)</summary>
    /// <returns><c>true</c> if closed, <c>false</c> otherwise</returns>
    public bool GetClosed() {
         var _ret_var = Efl.Io.ICloserConcrete.NativeMethods.efl_io_closer_closed_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>If true will automatically close resources on exec() calls.
    /// When using file descriptors this should set FD_CLOEXEC so they are not inherited by the processes (children or self) doing exec().
    /// (Since EFL 1.22)</summary>
    /// <returns><c>true</c> if close on exec(), <c>false</c> otherwise</returns>
    public bool GetCloseOnExec() {
         var _ret_var = Efl.Io.ICloserConcrete.NativeMethods.efl_io_closer_close_on_exec_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>If <c>true</c>, will close on exec() call.
    /// (Since EFL 1.22)</summary>
    /// <param name="close_on_exec"><c>true</c> if close on exec(), <c>false</c> otherwise</param>
    /// <returns><c>true</c> if could set, <c>false</c> if not supported or failed.</returns>
    public bool SetCloseOnExec(bool close_on_exec) {
                                 var _ret_var = Efl.Io.ICloserConcrete.NativeMethods.efl_io_closer_close_on_exec_set_ptr.Value.Delegate(this.NativeHandle,close_on_exec);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>If true will automatically close() on object invalidate.
    /// If the object was disconnected from its parent (including the main loop) without close, this property will state whenever it should be closed or not.
    /// (Since EFL 1.22)</summary>
    /// <returns><c>true</c> if close on invalidate, <c>false</c> otherwise</returns>
    public bool GetCloseOnInvalidate() {
         var _ret_var = Efl.Io.ICloserConcrete.NativeMethods.efl_io_closer_close_on_invalidate_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>If true will automatically close() on object invalidate.
    /// If the object was disconnected from its parent (including the main loop) without close, this property will state whenever it should be closed or not.
    /// (Since EFL 1.22)</summary>
    /// <param name="close_on_invalidate"><c>true</c> if close on invalidate, <c>false</c> otherwise</param>
    public void SetCloseOnInvalidate(bool close_on_invalidate) {
                                 Efl.Io.ICloserConcrete.NativeMethods.efl_io_closer_close_on_invalidate_set_ptr.Value.Delegate(this.NativeHandle,close_on_invalidate);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Closes the Input/Output object.
    /// This operation will be executed immediately and may or may not block the caller thread for some time. The details of blocking behavior is to be defined by the implementation and may be subject to other parameters such as non-blocking flags, maximum timeout or even retry attempts.
    /// 
    /// You can understand this method as close(2) libc function.
    /// (Since EFL 1.22)</summary>
    /// <returns>0 on succeed, a mapping of errno otherwise</returns>
    public Eina.Error Close() {
         var _ret_var = Efl.Io.ICloserConcrete.NativeMethods.efl_io_closer_close_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>If true will notify object was closed.
    /// (Since EFL 1.22)</summary>
    /// <value><c>true</c> if closed, <c>false</c> otherwise</value>
    public bool Closed {
        get { return GetClosed(); }
    }
    /// <summary>If true will automatically close resources on exec() calls.
    /// When using file descriptors this should set FD_CLOEXEC so they are not inherited by the processes (children or self) doing exec().
    /// (Since EFL 1.22)</summary>
    /// <value><c>true</c> if close on exec(), <c>false</c> otherwise</value>
    public bool CloseOnExec {
        get { return GetCloseOnExec(); }
        set { SetCloseOnExec(value); }
    }
    /// <summary>If true will automatically close() on object invalidate.
    /// If the object was disconnected from its parent (including the main loop) without close, this property will state whenever it should be closed or not.
    /// (Since EFL 1.22)</summary>
    /// <value><c>true</c> if close on invalidate, <c>false</c> otherwise</value>
    public bool CloseOnInvalidate {
        get { return GetCloseOnInvalidate(); }
        set { SetCloseOnInvalidate(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Io.ICloserConcrete.efl_io_closer_interface_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Eo.EoWrapper.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Efl);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_io_closer_closed_get_static_delegate == null)
            {
                efl_io_closer_closed_get_static_delegate = new efl_io_closer_closed_get_delegate(closed_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetClosed") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_io_closer_closed_get"), func = Marshal.GetFunctionPointerForDelegate(efl_io_closer_closed_get_static_delegate) });
            }

            if (efl_io_closer_close_on_exec_get_static_delegate == null)
            {
                efl_io_closer_close_on_exec_get_static_delegate = new efl_io_closer_close_on_exec_get_delegate(close_on_exec_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetCloseOnExec") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_io_closer_close_on_exec_get"), func = Marshal.GetFunctionPointerForDelegate(efl_io_closer_close_on_exec_get_static_delegate) });
            }

            if (efl_io_closer_close_on_exec_set_static_delegate == null)
            {
                efl_io_closer_close_on_exec_set_static_delegate = new efl_io_closer_close_on_exec_set_delegate(close_on_exec_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetCloseOnExec") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_io_closer_close_on_exec_set"), func = Marshal.GetFunctionPointerForDelegate(efl_io_closer_close_on_exec_set_static_delegate) });
            }

            if (efl_io_closer_close_on_invalidate_get_static_delegate == null)
            {
                efl_io_closer_close_on_invalidate_get_static_delegate = new efl_io_closer_close_on_invalidate_get_delegate(close_on_invalidate_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetCloseOnInvalidate") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_io_closer_close_on_invalidate_get"), func = Marshal.GetFunctionPointerForDelegate(efl_io_closer_close_on_invalidate_get_static_delegate) });
            }

            if (efl_io_closer_close_on_invalidate_set_static_delegate == null)
            {
                efl_io_closer_close_on_invalidate_set_static_delegate = new efl_io_closer_close_on_invalidate_set_delegate(close_on_invalidate_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetCloseOnInvalidate") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_io_closer_close_on_invalidate_set"), func = Marshal.GetFunctionPointerForDelegate(efl_io_closer_close_on_invalidate_set_static_delegate) });
            }

            if (efl_io_closer_close_static_delegate == null)
            {
                efl_io_closer_close_static_delegate = new efl_io_closer_close_delegate(close);
            }

            if (methods.FirstOrDefault(m => m.Name == "Close") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_io_closer_close"), func = Marshal.GetFunctionPointerForDelegate(efl_io_closer_close_static_delegate) });
            }

            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Io.ICloserConcrete.efl_io_closer_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_io_closer_closed_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_io_closer_closed_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_io_closer_closed_get_api_delegate> efl_io_closer_closed_get_ptr = new Efl.Eo.FunctionWrapper<efl_io_closer_closed_get_api_delegate>(Module, "efl_io_closer_closed_get");

        private static bool closed_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_io_closer_closed_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((ICloser)ws.Target).GetClosed();
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
                return efl_io_closer_closed_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_io_closer_closed_get_delegate efl_io_closer_closed_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_io_closer_close_on_exec_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_io_closer_close_on_exec_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_io_closer_close_on_exec_get_api_delegate> efl_io_closer_close_on_exec_get_ptr = new Efl.Eo.FunctionWrapper<efl_io_closer_close_on_exec_get_api_delegate>(Module, "efl_io_closer_close_on_exec_get");

        private static bool close_on_exec_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_io_closer_close_on_exec_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((ICloser)ws.Target).GetCloseOnExec();
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
                return efl_io_closer_close_on_exec_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_io_closer_close_on_exec_get_delegate efl_io_closer_close_on_exec_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_io_closer_close_on_exec_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool close_on_exec);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_io_closer_close_on_exec_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool close_on_exec);

        public static Efl.Eo.FunctionWrapper<efl_io_closer_close_on_exec_set_api_delegate> efl_io_closer_close_on_exec_set_ptr = new Efl.Eo.FunctionWrapper<efl_io_closer_close_on_exec_set_api_delegate>(Module, "efl_io_closer_close_on_exec_set");

        private static bool close_on_exec_set(System.IntPtr obj, System.IntPtr pd, bool close_on_exec)
        {
            Eina.Log.Debug("function efl_io_closer_close_on_exec_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((ICloser)ws.Target).SetCloseOnExec(close_on_exec);
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
                return efl_io_closer_close_on_exec_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), close_on_exec);
            }
        }

        private static efl_io_closer_close_on_exec_set_delegate efl_io_closer_close_on_exec_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_io_closer_close_on_invalidate_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_io_closer_close_on_invalidate_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_io_closer_close_on_invalidate_get_api_delegate> efl_io_closer_close_on_invalidate_get_ptr = new Efl.Eo.FunctionWrapper<efl_io_closer_close_on_invalidate_get_api_delegate>(Module, "efl_io_closer_close_on_invalidate_get");

        private static bool close_on_invalidate_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_io_closer_close_on_invalidate_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((ICloser)ws.Target).GetCloseOnInvalidate();
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
                return efl_io_closer_close_on_invalidate_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_io_closer_close_on_invalidate_get_delegate efl_io_closer_close_on_invalidate_get_static_delegate;

        
        private delegate void efl_io_closer_close_on_invalidate_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool close_on_invalidate);

        
        public delegate void efl_io_closer_close_on_invalidate_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool close_on_invalidate);

        public static Efl.Eo.FunctionWrapper<efl_io_closer_close_on_invalidate_set_api_delegate> efl_io_closer_close_on_invalidate_set_ptr = new Efl.Eo.FunctionWrapper<efl_io_closer_close_on_invalidate_set_api_delegate>(Module, "efl_io_closer_close_on_invalidate_set");

        private static void close_on_invalidate_set(System.IntPtr obj, System.IntPtr pd, bool close_on_invalidate)
        {
            Eina.Log.Debug("function efl_io_closer_close_on_invalidate_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((ICloser)ws.Target).SetCloseOnInvalidate(close_on_invalidate);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_io_closer_close_on_invalidate_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), close_on_invalidate);
            }
        }

        private static efl_io_closer_close_on_invalidate_set_delegate efl_io_closer_close_on_invalidate_set_static_delegate;

        
        private delegate Eina.Error efl_io_closer_close_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Error efl_io_closer_close_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_io_closer_close_api_delegate> efl_io_closer_close_ptr = new Efl.Eo.FunctionWrapper<efl_io_closer_close_api_delegate>(Module, "efl_io_closer_close");

        private static Eina.Error close(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_io_closer_close was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Error _ret_var = default(Eina.Error);
                try
                {
                    _ret_var = ((ICloser)ws.Target).Close();
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
                return efl_io_closer_close_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_io_closer_close_delegate efl_io_closer_close_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

