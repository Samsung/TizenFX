#define EFL_BETA
#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

/// <summary>An object that describes an low-level source of I/O to listen to for available data to be read or written, depending on the OS and data source type. When I/O becomes available various events are produced and the callbacks attached to them will be called.</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.LoopHandler.NativeMethods]
[Efl.Eo.BindingEntity]
public class LoopHandler : Efl.Object
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(LoopHandler))
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
        efl_loop_handler_class_get();
    /// <summary>Initializes a new instance of the <see cref="LoopHandler"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public LoopHandler(Efl.Object parent= null
            ) : base(efl_loop_handler_class_get(), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected LoopHandler(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="LoopHandler"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected LoopHandler(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="LoopHandler"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected LoopHandler(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }

    /// <summary>Called when a read occurs on the descriptor.</summary>
    public event EventHandler ReadEvt
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

                string key = "_EFL_LOOP_HANDLER_EVENT_READ";
                AddNativeEventHandler(efl.Libs.Ecore, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_LOOP_HANDLER_EVENT_READ";
                RemoveNativeEventHandler(efl.Libs.Ecore, key, value);
            }
        }
    }
    /// <summary>Method to raise event ReadEvt.</summary>
    public void OnReadEvt(EventArgs e)
    {
        var key = "_EFL_LOOP_HANDLER_EVENT_READ";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Ecore, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when a write occurs on the descriptor.</summary>
    public event EventHandler WriteEvt
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

                string key = "_EFL_LOOP_HANDLER_EVENT_WRITE";
                AddNativeEventHandler(efl.Libs.Ecore, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_LOOP_HANDLER_EVENT_WRITE";
                RemoveNativeEventHandler(efl.Libs.Ecore, key, value);
            }
        }
    }
    /// <summary>Method to raise event WriteEvt.</summary>
    public void OnWriteEvt(EventArgs e)
    {
        var key = "_EFL_LOOP_HANDLER_EVENT_WRITE";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Ecore, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when a error occurrs on the descriptor.</summary>
    public event EventHandler ErrorEvt
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

                string key = "_EFL_LOOP_HANDLER_EVENT_ERROR";
                AddNativeEventHandler(efl.Libs.Ecore, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_LOOP_HANDLER_EVENT_ERROR";
                RemoveNativeEventHandler(efl.Libs.Ecore, key, value);
            }
        }
    }
    /// <summary>Method to raise event ErrorEvt.</summary>
    public void OnErrorEvt(EventArgs e)
    {
        var key = "_EFL_LOOP_HANDLER_EVENT_ERROR";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Ecore, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when buffered data already read from the descriptor should be processed.</summary>
    public event EventHandler BufferEvt
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

                string key = "_EFL_LOOP_HANDLER_EVENT_BUFFER";
                AddNativeEventHandler(efl.Libs.Ecore, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_LOOP_HANDLER_EVENT_BUFFER";
                RemoveNativeEventHandler(efl.Libs.Ecore, key, value);
            }
        }
    }
    /// <summary>Method to raise event BufferEvt.</summary>
    public void OnBufferEvt(EventArgs e)
    {
        var key = "_EFL_LOOP_HANDLER_EVENT_BUFFER";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Ecore, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when preparing a descriptor for listening.</summary>
    public event EventHandler PrepareEvt
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

                string key = "_EFL_LOOP_HANDLER_EVENT_PREPARE";
                AddNativeEventHandler(efl.Libs.Ecore, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_LOOP_HANDLER_EVENT_PREPARE";
                RemoveNativeEventHandler(efl.Libs.Ecore, key, value);
            }
        }
    }
    /// <summary>Method to raise event PrepareEvt.</summary>
    public void OnPrepareEvt(EventArgs e)
    {
        var key = "_EFL_LOOP_HANDLER_EVENT_PREPARE";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Ecore, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>This sets what kind of I/O should be listened to only when using a fd or fd_file for the handler</summary>
    /// <returns>The flags that indicate what kind of I/O should be listened for like read, write or error channels.</returns>
    virtual public Efl.LoopHandlerFlags GetActive() {
         var _ret_var = Efl.LoopHandler.NativeMethods.efl_loop_handler_active_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>This sets what kind of I/O should be listened to only when using a fd or fd_file for the handler</summary>
    /// <param name="flags">The flags that indicate what kind of I/O should be listened for like read, write or error channels.</param>
    virtual public void SetActive(Efl.LoopHandlerFlags flags) {
                                 Efl.LoopHandler.NativeMethods.efl_loop_handler_active_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),flags);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Controls a file descriptor to listen to for I/O, which points to a data pipe such as a device, socket or pipe etc.</summary>
    /// <returns>The file descriptor</returns>
    virtual public int GetFd() {
         var _ret_var = Efl.LoopHandler.NativeMethods.efl_loop_handler_fd_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Controls a file descriptor to listen to for I/O, which points to a data pipe such as a device, socket or pipe etc.</summary>
    /// <param name="fd">The file descriptor</param>
    virtual public void SetFd(int fd) {
                                 Efl.LoopHandler.NativeMethods.efl_loop_handler_fd_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),fd);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Controls a file descriptor to listen to for I/O that specifically points to a file in storage and not a device, socket or pipe etc.</summary>
    /// <returns>The file descriptor</returns>
    virtual public int GetFdFile() {
         var _ret_var = Efl.LoopHandler.NativeMethods.efl_loop_handler_fd_file_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Controls a file descriptor to listen to for I/O that specifically points to a file in storage and not a device, socket or pipe etc.</summary>
    /// <param name="fd">The file descriptor</param>
    virtual public void SetFdFile(int fd) {
                                 Efl.LoopHandler.NativeMethods.efl_loop_handler_fd_file_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),fd);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Controls a windows win32 object handle to listen to for I/O. When it becomes available for any data the read event will be produced.</summary>
    /// <returns>A win32 object handle</returns>
    virtual public System.IntPtr GetWin32() {
         var _ret_var = Efl.LoopHandler.NativeMethods.efl_loop_handler_win32_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Controls a windows win32 object handle to listen to for I/O. When it becomes available for any data the read event will be produced.</summary>
    /// <param name="handle">A win32 object handle</param>
    virtual public void SetWin32(System.IntPtr handle) {
                                 Efl.LoopHandler.NativeMethods.efl_loop_handler_win32_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),handle);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>This sets what kind of I/O should be listened to only when using a fd or fd_file for the handler</summary>
    /// <value>The flags that indicate what kind of I/O should be listened for like read, write or error channels.</value>
    public Efl.LoopHandlerFlags Active {
        get { return GetActive(); }
        set { SetActive(value); }
    }
    /// <summary>Controls a file descriptor to listen to for I/O, which points to a data pipe such as a device, socket or pipe etc.</summary>
    /// <value>The file descriptor</value>
    public int Fd {
        get { return GetFd(); }
        set { SetFd(value); }
    }
    /// <summary>Controls a file descriptor to listen to for I/O that specifically points to a file in storage and not a device, socket or pipe etc.</summary>
    /// <value>The file descriptor</value>
    public int FdFile {
        get { return GetFdFile(); }
        set { SetFdFile(value); }
    }
    /// <summary>Controls a windows win32 object handle to listen to for I/O. When it becomes available for any data the read event will be produced.</summary>
    /// <value>A win32 object handle</value>
    public System.IntPtr Win32 {
        get { return GetWin32(); }
        set { SetWin32(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.LoopHandler.efl_loop_handler_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Object.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Ecore);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_loop_handler_active_get_static_delegate == null)
            {
                efl_loop_handler_active_get_static_delegate = new efl_loop_handler_active_get_delegate(active_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetActive") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_loop_handler_active_get"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_handler_active_get_static_delegate) });
            }

            if (efl_loop_handler_active_set_static_delegate == null)
            {
                efl_loop_handler_active_set_static_delegate = new efl_loop_handler_active_set_delegate(active_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetActive") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_loop_handler_active_set"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_handler_active_set_static_delegate) });
            }

            if (efl_loop_handler_fd_get_static_delegate == null)
            {
                efl_loop_handler_fd_get_static_delegate = new efl_loop_handler_fd_get_delegate(fd_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFd") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_loop_handler_fd_get"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_handler_fd_get_static_delegate) });
            }

            if (efl_loop_handler_fd_set_static_delegate == null)
            {
                efl_loop_handler_fd_set_static_delegate = new efl_loop_handler_fd_set_delegate(fd_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFd") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_loop_handler_fd_set"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_handler_fd_set_static_delegate) });
            }

            if (efl_loop_handler_fd_file_get_static_delegate == null)
            {
                efl_loop_handler_fd_file_get_static_delegate = new efl_loop_handler_fd_file_get_delegate(fd_file_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFdFile") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_loop_handler_fd_file_get"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_handler_fd_file_get_static_delegate) });
            }

            if (efl_loop_handler_fd_file_set_static_delegate == null)
            {
                efl_loop_handler_fd_file_set_static_delegate = new efl_loop_handler_fd_file_set_delegate(fd_file_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFdFile") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_loop_handler_fd_file_set"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_handler_fd_file_set_static_delegate) });
            }

            if (efl_loop_handler_win32_get_static_delegate == null)
            {
                efl_loop_handler_win32_get_static_delegate = new efl_loop_handler_win32_get_delegate(win32_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetWin32") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_loop_handler_win32_get"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_handler_win32_get_static_delegate) });
            }

            if (efl_loop_handler_win32_set_static_delegate == null)
            {
                efl_loop_handler_win32_set_static_delegate = new efl_loop_handler_win32_set_delegate(win32_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetWin32") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_loop_handler_win32_set"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_handler_win32_set_static_delegate) });
            }

            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.LoopHandler.efl_loop_handler_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate Efl.LoopHandlerFlags efl_loop_handler_active_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.LoopHandlerFlags efl_loop_handler_active_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_loop_handler_active_get_api_delegate> efl_loop_handler_active_get_ptr = new Efl.Eo.FunctionWrapper<efl_loop_handler_active_get_api_delegate>(Module, "efl_loop_handler_active_get");

        private static Efl.LoopHandlerFlags active_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_loop_handler_active_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.LoopHandlerFlags _ret_var = default(Efl.LoopHandlerFlags);
                try
                {
                    _ret_var = ((LoopHandler)ws.Target).GetActive();
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
                return efl_loop_handler_active_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_loop_handler_active_get_delegate efl_loop_handler_active_get_static_delegate;

        
        private delegate void efl_loop_handler_active_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.LoopHandlerFlags flags);

        
        public delegate void efl_loop_handler_active_set_api_delegate(System.IntPtr obj,  Efl.LoopHandlerFlags flags);

        public static Efl.Eo.FunctionWrapper<efl_loop_handler_active_set_api_delegate> efl_loop_handler_active_set_ptr = new Efl.Eo.FunctionWrapper<efl_loop_handler_active_set_api_delegate>(Module, "efl_loop_handler_active_set");

        private static void active_set(System.IntPtr obj, System.IntPtr pd, Efl.LoopHandlerFlags flags)
        {
            Eina.Log.Debug("function efl_loop_handler_active_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((LoopHandler)ws.Target).SetActive(flags);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_loop_handler_active_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), flags);
            }
        }

        private static efl_loop_handler_active_set_delegate efl_loop_handler_active_set_static_delegate;

        
        private delegate int efl_loop_handler_fd_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_loop_handler_fd_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_loop_handler_fd_get_api_delegate> efl_loop_handler_fd_get_ptr = new Efl.Eo.FunctionWrapper<efl_loop_handler_fd_get_api_delegate>(Module, "efl_loop_handler_fd_get");

        private static int fd_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_loop_handler_fd_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            int _ret_var = default(int);
                try
                {
                    _ret_var = ((LoopHandler)ws.Target).GetFd();
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
                return efl_loop_handler_fd_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_loop_handler_fd_get_delegate efl_loop_handler_fd_get_static_delegate;

        
        private delegate void efl_loop_handler_fd_set_delegate(System.IntPtr obj, System.IntPtr pd,  int fd);

        
        public delegate void efl_loop_handler_fd_set_api_delegate(System.IntPtr obj,  int fd);

        public static Efl.Eo.FunctionWrapper<efl_loop_handler_fd_set_api_delegate> efl_loop_handler_fd_set_ptr = new Efl.Eo.FunctionWrapper<efl_loop_handler_fd_set_api_delegate>(Module, "efl_loop_handler_fd_set");

        private static void fd_set(System.IntPtr obj, System.IntPtr pd, int fd)
        {
            Eina.Log.Debug("function efl_loop_handler_fd_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((LoopHandler)ws.Target).SetFd(fd);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_loop_handler_fd_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), fd);
            }
        }

        private static efl_loop_handler_fd_set_delegate efl_loop_handler_fd_set_static_delegate;

        
        private delegate int efl_loop_handler_fd_file_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_loop_handler_fd_file_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_loop_handler_fd_file_get_api_delegate> efl_loop_handler_fd_file_get_ptr = new Efl.Eo.FunctionWrapper<efl_loop_handler_fd_file_get_api_delegate>(Module, "efl_loop_handler_fd_file_get");

        private static int fd_file_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_loop_handler_fd_file_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            int _ret_var = default(int);
                try
                {
                    _ret_var = ((LoopHandler)ws.Target).GetFdFile();
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
                return efl_loop_handler_fd_file_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_loop_handler_fd_file_get_delegate efl_loop_handler_fd_file_get_static_delegate;

        
        private delegate void efl_loop_handler_fd_file_set_delegate(System.IntPtr obj, System.IntPtr pd,  int fd);

        
        public delegate void efl_loop_handler_fd_file_set_api_delegate(System.IntPtr obj,  int fd);

        public static Efl.Eo.FunctionWrapper<efl_loop_handler_fd_file_set_api_delegate> efl_loop_handler_fd_file_set_ptr = new Efl.Eo.FunctionWrapper<efl_loop_handler_fd_file_set_api_delegate>(Module, "efl_loop_handler_fd_file_set");

        private static void fd_file_set(System.IntPtr obj, System.IntPtr pd, int fd)
        {
            Eina.Log.Debug("function efl_loop_handler_fd_file_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((LoopHandler)ws.Target).SetFdFile(fd);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_loop_handler_fd_file_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), fd);
            }
        }

        private static efl_loop_handler_fd_file_set_delegate efl_loop_handler_fd_file_set_static_delegate;

        
        private delegate System.IntPtr efl_loop_handler_win32_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate System.IntPtr efl_loop_handler_win32_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_loop_handler_win32_get_api_delegate> efl_loop_handler_win32_get_ptr = new Efl.Eo.FunctionWrapper<efl_loop_handler_win32_get_api_delegate>(Module, "efl_loop_handler_win32_get");

        private static System.IntPtr win32_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_loop_handler_win32_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            System.IntPtr _ret_var = default(System.IntPtr);
                try
                {
                    _ret_var = ((LoopHandler)ws.Target).GetWin32();
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
                return efl_loop_handler_win32_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_loop_handler_win32_get_delegate efl_loop_handler_win32_get_static_delegate;

        
        private delegate void efl_loop_handler_win32_set_delegate(System.IntPtr obj, System.IntPtr pd,  System.IntPtr handle);

        
        public delegate void efl_loop_handler_win32_set_api_delegate(System.IntPtr obj,  System.IntPtr handle);

        public static Efl.Eo.FunctionWrapper<efl_loop_handler_win32_set_api_delegate> efl_loop_handler_win32_set_ptr = new Efl.Eo.FunctionWrapper<efl_loop_handler_win32_set_api_delegate>(Module, "efl_loop_handler_win32_set");

        private static void win32_set(System.IntPtr obj, System.IntPtr pd, System.IntPtr handle)
        {
            Eina.Log.Debug("function efl_loop_handler_win32_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((LoopHandler)ws.Target).SetWin32(handle);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_loop_handler_win32_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), handle);
            }
        }

        private static efl_loop_handler_win32_set_delegate efl_loop_handler_win32_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

#if EFL_BETA
#pragma warning disable CS1591
public static class EflLoopHandler_ExtensionMethods {
    public static Efl.BindableProperty<Efl.LoopHandlerFlags> Active<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.LoopHandler, T>magic = null) where T : Efl.LoopHandler {
        return new Efl.BindableProperty<Efl.LoopHandlerFlags>("active", fac);
    }

    public static Efl.BindableProperty<int> Fd<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.LoopHandler, T>magic = null) where T : Efl.LoopHandler {
        return new Efl.BindableProperty<int>("fd", fac);
    }

    public static Efl.BindableProperty<int> FdFile<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.LoopHandler, T>magic = null) where T : Efl.LoopHandler {
        return new Efl.BindableProperty<int>("fd_file", fac);
    }

    public static Efl.BindableProperty<System.IntPtr> Win32<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.LoopHandler, T>magic = null) where T : Efl.LoopHandler {
        return new Efl.BindableProperty<System.IntPtr>("win32", fac);
    }

}
#pragma warning restore CS1591
#endif
namespace Efl {

/// <summary>A set of flags that can be OR&apos;d together to indicate which are desired</summary>
[Efl.Eo.BindingEntity]
public enum LoopHandlerFlags
{
/// <summary>No I/O is desired (generally useless)</summary>
None = 0,
/// <summary>Reading is desired</summary>
Read = 1,
/// <summary>Writing is desired</summary>
Write = 2,
/// <summary>Error channel input is desired</summary>
Error = 4,
}

}

