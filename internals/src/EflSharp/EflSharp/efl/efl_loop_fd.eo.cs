#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

/// <summary>Fds are objects that watch the activity on a given file descriptor. This file descriptor can be a network, a file, provided by a library.
/// The object will trigger relevant events depending on what&apos;s happening.</summary>
[Efl.LoopFd.NativeMethods]
public class LoopFd : Efl.LoopConsumer
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(LoopFd))
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
        efl_loop_fd_class_get();
    /// <summary>Initializes a new instance of the <see cref="LoopFd"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public LoopFd(Efl.Object parent= null
            ) : base(efl_loop_fd_class_get(), typeof(LoopFd), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Initializes a new instance of the <see cref="LoopFd"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="raw">The native pointer to be wrapped.</param>
    protected LoopFd(System.IntPtr raw) : base(raw)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="LoopFd"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="managedType">The managed type of the public constructor that originated this call.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected LoopFd(IntPtr baseKlass, System.Type managedType, Efl.Object parent) : base(baseKlass, managedType, parent)
    {
    }

    /// <summary>Called when a read happened on the file descriptor</summary>
    public event EventHandler ReadEvt
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

                string key = "_EFL_LOOP_FD_EVENT_READ";
                AddNativeEventHandler(efl.Libs.Ecore, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_LOOP_FD_EVENT_READ";
                RemoveNativeEventHandler(efl.Libs.Ecore, key, value);
            }
        }
    }
    ///<summary>Method to raise event ReadEvt.</summary>
    public void OnReadEvt(EventArgs e)
    {
        var key = "_EFL_LOOP_FD_EVENT_READ";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Ecore, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when a write happened on the file descriptor</summary>
    public event EventHandler WriteEvt
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

                string key = "_EFL_LOOP_FD_EVENT_WRITE";
                AddNativeEventHandler(efl.Libs.Ecore, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_LOOP_FD_EVENT_WRITE";
                RemoveNativeEventHandler(efl.Libs.Ecore, key, value);
            }
        }
    }
    ///<summary>Method to raise event WriteEvt.</summary>
    public void OnWriteEvt(EventArgs e)
    {
        var key = "_EFL_LOOP_FD_EVENT_WRITE";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Ecore, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when a error occurred on the file descriptor</summary>
    public event EventHandler ErrorEvt
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

                string key = "_EFL_LOOP_FD_EVENT_ERROR";
                AddNativeEventHandler(efl.Libs.Ecore, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_LOOP_FD_EVENT_ERROR";
                RemoveNativeEventHandler(efl.Libs.Ecore, key, value);
            }
        }
    }
    ///<summary>Method to raise event ErrorEvt.</summary>
    public void OnErrorEvt(EventArgs e)
    {
        var key = "_EFL_LOOP_FD_EVENT_ERROR";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Ecore, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Defines which file descriptor to watch. If it is a file, use file_fd variant.</summary>
    /// <returns>The file descriptor.</returns>
    virtual public int GetFd() {
         var _ret_var = Efl.LoopFd.NativeMethods.efl_loop_fd_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Defines the fd to watch.</summary>
    /// <param name="fd">The file descriptor.</param>
    virtual public void SetFd(int fd) {
                                 Efl.LoopFd.NativeMethods.efl_loop_fd_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),fd);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Defines which file descriptor to watch when watching a file.</summary>
    /// <returns>The file descriptor.</returns>
    virtual public int GetFdFile() {
         var _ret_var = Efl.LoopFd.NativeMethods.efl_loop_fd_file_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Defines the fd to watch on.</summary>
    /// <param name="fd">The file descriptor.</param>
    virtual public void SetFdFile(int fd) {
                                 Efl.LoopFd.NativeMethods.efl_loop_fd_file_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),fd);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Defines which file descriptor to watch. If it is a file, use file_fd variant.</summary>
    /// <value>The file descriptor.</value>
    public int Fd {
        get { return GetFd(); }
        set { SetFd(value); }
    }
    /// <summary>Defines which file descriptor to watch when watching a file.</summary>
    /// <value>The file descriptor.</value>
    public int FdFile {
        get { return GetFdFile(); }
        set { SetFdFile(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.LoopFd.efl_loop_fd_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.LoopConsumer.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Ecore);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_loop_fd_get_static_delegate == null)
            {
                efl_loop_fd_get_static_delegate = new efl_loop_fd_get_delegate(fd_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFd") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_loop_fd_get"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_fd_get_static_delegate) });
            }

            if (efl_loop_fd_set_static_delegate == null)
            {
                efl_loop_fd_set_static_delegate = new efl_loop_fd_set_delegate(fd_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFd") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_loop_fd_set"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_fd_set_static_delegate) });
            }

            if (efl_loop_fd_file_get_static_delegate == null)
            {
                efl_loop_fd_file_get_static_delegate = new efl_loop_fd_file_get_delegate(fd_file_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFdFile") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_loop_fd_file_get"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_fd_file_get_static_delegate) });
            }

            if (efl_loop_fd_file_set_static_delegate == null)
            {
                efl_loop_fd_file_set_static_delegate = new efl_loop_fd_file_set_delegate(fd_file_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFdFile") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_loop_fd_file_set"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_fd_file_set_static_delegate) });
            }

            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.LoopFd.efl_loop_fd_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate int efl_loop_fd_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_loop_fd_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_loop_fd_get_api_delegate> efl_loop_fd_get_ptr = new Efl.Eo.FunctionWrapper<efl_loop_fd_get_api_delegate>(Module, "efl_loop_fd_get");

        private static int fd_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_loop_fd_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            int _ret_var = default(int);
                try
                {
                    _ret_var = ((LoopFd)ws.Target).GetFd();
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
                return efl_loop_fd_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_loop_fd_get_delegate efl_loop_fd_get_static_delegate;

        
        private delegate void efl_loop_fd_set_delegate(System.IntPtr obj, System.IntPtr pd,  int fd);

        
        public delegate void efl_loop_fd_set_api_delegate(System.IntPtr obj,  int fd);

        public static Efl.Eo.FunctionWrapper<efl_loop_fd_set_api_delegate> efl_loop_fd_set_ptr = new Efl.Eo.FunctionWrapper<efl_loop_fd_set_api_delegate>(Module, "efl_loop_fd_set");

        private static void fd_set(System.IntPtr obj, System.IntPtr pd, int fd)
        {
            Eina.Log.Debug("function efl_loop_fd_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((LoopFd)ws.Target).SetFd(fd);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_loop_fd_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), fd);
            }
        }

        private static efl_loop_fd_set_delegate efl_loop_fd_set_static_delegate;

        
        private delegate int efl_loop_fd_file_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_loop_fd_file_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_loop_fd_file_get_api_delegate> efl_loop_fd_file_get_ptr = new Efl.Eo.FunctionWrapper<efl_loop_fd_file_get_api_delegate>(Module, "efl_loop_fd_file_get");

        private static int fd_file_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_loop_fd_file_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            int _ret_var = default(int);
                try
                {
                    _ret_var = ((LoopFd)ws.Target).GetFdFile();
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
                return efl_loop_fd_file_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_loop_fd_file_get_delegate efl_loop_fd_file_get_static_delegate;

        
        private delegate void efl_loop_fd_file_set_delegate(System.IntPtr obj, System.IntPtr pd,  int fd);

        
        public delegate void efl_loop_fd_file_set_api_delegate(System.IntPtr obj,  int fd);

        public static Efl.Eo.FunctionWrapper<efl_loop_fd_file_set_api_delegate> efl_loop_fd_file_set_ptr = new Efl.Eo.FunctionWrapper<efl_loop_fd_file_set_api_delegate>(Module, "efl_loop_fd_file_set");

        private static void fd_file_set(System.IntPtr obj, System.IntPtr pd, int fd)
        {
            Eina.Log.Debug("function efl_loop_fd_file_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((LoopFd)ws.Target).SetFdFile(fd);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_loop_fd_file_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), fd);
            }
        }

        private static efl_loop_fd_file_set_delegate efl_loop_fd_file_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

