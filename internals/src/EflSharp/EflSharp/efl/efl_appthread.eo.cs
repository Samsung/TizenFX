#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

/// <summary>No description supplied.</summary>
[Efl.Appthread.NativeMethods]
public class Appthread : Efl.Loop, Efl.IThreadIO, Efl.Core.ICommandLine, Efl.Io.ICloser, Efl.Io.IReader, Efl.Io.IWriter
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(Appthread))
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
        efl_appthread_class_get();
    /// <summary>Initializes a new instance of the <see cref="Appthread"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public Appthread(Efl.Object parent= null
            ) : base(efl_appthread_class_get(), typeof(Appthread), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Initializes a new instance of the <see cref="Appthread"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="raw">The native pointer to be wrapped.</param>
    protected Appthread(System.IntPtr raw) : base(raw)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Appthread"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="managedType">The managed type of the public constructor that originated this call.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected Appthread(IntPtr baseKlass, System.Type managedType, Efl.Object parent) : base(baseKlass, managedType, parent)
    {
    }

    /// <summary>Notifies closed, when property is marked as true
    /// (Since EFL 1.22)</summary>
    public event EventHandler ClosedEvt
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

                string key = "_EFL_IO_CLOSER_EVENT_CLOSED";
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
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
    /// <summary>Notifies can_read property changed.
    /// If <see cref="Efl.Io.IReader.CanRead"/> is <c>true</c> there is data to <see cref="Efl.Io.IReader.Read"/> without blocking/error. If <see cref="Efl.Io.IReader.CanRead"/> is <c>false</c>, <see cref="Efl.Io.IReader.Read"/> would either block or fail.
    /// 
    /// Note that usually this event is dispatched from inside <see cref="Efl.Io.IReader.Read"/>, thus before it returns.
    /// (Since EFL 1.22)</summary>
    public event EventHandler<Efl.Io.IReaderCanReadChangedEvt_Args> CanReadChangedEvt
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
                        Efl.Io.IReaderCanReadChangedEvt_Args args = new Efl.Io.IReaderCanReadChangedEvt_Args();
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

                string key = "_EFL_IO_READER_EVENT_CAN_READ_CHANGED";
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_IO_READER_EVENT_CAN_READ_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    ///<summary>Method to raise event CanReadChangedEvt.</summary>
    public void OnCanReadChangedEvt(Efl.Io.IReaderCanReadChangedEvt_Args e)
    {
        var key = "_EFL_IO_READER_EVENT_CAN_READ_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
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
    /// <summary>Notifies end of stream, when property is marked as true.
    /// If this is used alongside with an <see cref="Efl.Io.ICloser"/>, then it should be emitted before that call.
    /// 
    /// It should be emitted only once for an object unless it implements <see cref="Efl.Io.IPositioner.Seek"/>.
    /// 
    /// The property <see cref="Efl.Io.IReader.CanRead"/> should change to <c>false</c> before this event is dispatched.
    /// (Since EFL 1.22)</summary>
    public event EventHandler EosEvt
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

                string key = "_EFL_IO_READER_EVENT_EOS";
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_IO_READER_EVENT_EOS";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    ///<summary>Method to raise event EosEvt.</summary>
    public void OnEosEvt(EventArgs e)
    {
        var key = "_EFL_IO_READER_EVENT_EOS";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Notifies can_write property changed.
    /// If <see cref="Efl.Io.IWriter.CanWrite"/> is <c>true</c> there is data to <see cref="Efl.Io.IWriter.Write"/> without blocking/error. If <see cref="Efl.Io.IWriter.CanWrite"/> is <c>false</c>, <see cref="Efl.Io.IWriter.Write"/> would either block or fail.
    /// 
    /// Note that usually this event is dispatched from inside <see cref="Efl.Io.IWriter.Write"/>, thus before it returns.
    /// (Since EFL 1.22)</summary>
    public event EventHandler<Efl.Io.IWriterCanWriteChangedEvt_Args> CanWriteChangedEvt
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
                        Efl.Io.IWriterCanWriteChangedEvt_Args args = new Efl.Io.IWriterCanWriteChangedEvt_Args();
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

                string key = "_EFL_IO_WRITER_EVENT_CAN_WRITE_CHANGED";
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_IO_WRITER_EVENT_CAN_WRITE_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    ///<summary>Method to raise event CanWriteChangedEvt.</summary>
    public void OnCanWriteChangedEvt(Efl.Io.IWriterCanWriteChangedEvt_Args e)
    {
        var key = "_EFL_IO_WRITER_EVENT_CAN_WRITE_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
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
    /// <returns>No description supplied.</returns>
    virtual public System.IntPtr GetIndata() {
         var _ret_var = Efl.IThreadIOConcrete.NativeMethods.efl_threadio_indata_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <param name="data">No description supplied.</param>
    virtual public void SetIndata(System.IntPtr data) {
                                 Efl.IThreadIOConcrete.NativeMethods.efl_threadio_indata_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),data);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <returns>No description supplied.</returns>
    virtual public System.IntPtr GetOutdata() {
         var _ret_var = Efl.IThreadIOConcrete.NativeMethods.efl_threadio_outdata_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <param name="data">No description supplied.</param>
    virtual public void SetOutdata(System.IntPtr data) {
                                 Efl.IThreadIOConcrete.NativeMethods.efl_threadio_outdata_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),data);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <param name="func">No description supplied.</param>
    virtual public void Call(EFlThreadIOCall func) {
                         GCHandle func_handle = GCHandle.Alloc(func);
        Efl.IThreadIOConcrete.NativeMethods.efl_threadio_call_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),GCHandle.ToIntPtr(func_handle), EFlThreadIOCallWrapper.Cb, Efl.Eo.Globals.free_gchandle);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <param name="func">No description supplied.</param>
    /// <returns>No description supplied.</returns>
    virtual public System.IntPtr CallSync(EFlThreadIOCallSync func) {
                         GCHandle func_handle = GCHandle.Alloc(func);
        var _ret_var = Efl.IThreadIOConcrete.NativeMethods.efl_threadio_call_sync_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),GCHandle.ToIntPtr(func_handle), EFlThreadIOCallSyncWrapper.Cb, Efl.Eo.Globals.free_gchandle);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>A commandline that encodes arguments in a command string. This command is unix shell-style, thus whitespace separates arguments unless escaped. Also a semi-colon &apos;;&apos;, ampersand &apos;&amp;&apos;, pipe/bar &apos;|&apos;, hash &apos;#&apos;, bracket, square brace, brace character (&apos;(&apos;, &apos;)&apos;, &apos;[&apos;, &apos;]&apos;, &apos;{&apos;, &apos;}&apos;), exclamation mark &apos;!&apos;,  backquote &apos;`&apos;, greator or less than (&apos;&gt;&apos; &apos;&lt;&apos;) character unless escaped or in quotes would cause args_count/value to not be generated properly, because it would force complex shell interpretation which will not be supported in evaluating the arg_count/value information, but the final shell may interpret this if this is executed via a command-line shell. To not be a complex shell command, it should be simple with paths, options and variable expansions, but nothing more complex involving the above unescaped characters.
    /// &quot;cat -option /path/file&quot; &quot;cat &apos;quoted argument&apos;&quot; &quot;cat ~/path/escaped argument&quot; &quot;/bin/cat escaped argument <c>VARIABLE</c>&quot; etc.
    /// 
    /// It should not try and use &quot;complex shell features&quot; if you want the arg_count and arg_value set to be correct after setting the command string. For example none of:
    /// 
    /// &quot;VAR=x /bin/command &amp;&amp; /bin/othercommand &gt;&amp; /dev/null&quot; &quot;VAR=x /bin/command `/bin/othercommand` | /bin/cmd2 &amp;&amp; cmd3 &amp;&quot; etc.
    /// 
    /// If you set the command the arg_count/value property contents can change and be completely re-evaluated by parsing the command string into an argument array set along with interpreting escapes back into individual argument strings.</summary>
    virtual public System.String GetCommand() {
         var _ret_var = Efl.Core.ICommandLineConcrete.NativeMethods.efl_core_command_line_command_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Use an array to fill this object
    /// Every element of a string is a argument.</summary>
    /// <param name="array">An array where every array field is an argument</param>
    /// <returns>On success <c>true</c>, <c>false</c> otherwise</returns>
    virtual public bool SetCommandArray(Eina.Array<System.String> array) {
         var _in_array = array.Handle;
array.Own = false;
array.OwnContent = false;
                        var _ret_var = Efl.Core.ICommandLineConcrete.NativeMethods.efl_core_command_line_command_array_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),_in_array);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Use a string to fill this object
    /// The string will be split at every unescaped &apos; &apos;, every resulting substring will be a new argument to the command line.</summary>
    /// <param name="str">A command in form of a string</param>
    /// <returns>On success <c>true</c>, <c>false</c> otherwise</returns>
    virtual public bool SetCommandString(System.String str) {
                                 var _ret_var = Efl.Core.ICommandLineConcrete.NativeMethods.efl_core_command_line_command_string_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),str);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Get the accessor which enables access to each argument that got passed to this object.</summary>
    virtual public Eina.Accessor<System.String> CommandAccess() {
         var _ret_var = Efl.Core.ICommandLineConcrete.NativeMethods.efl_core_command_line_command_access_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return new Eina.Accessor<System.String>(_ret_var, false, false);
 }
    /// <summary>If true will notify object was closed.
    /// (Since EFL 1.22)</summary>
    /// <returns><c>true</c> if closed, <c>false</c> otherwise</returns>
    virtual public bool GetClosed() {
         var _ret_var = Efl.Io.ICloserConcrete.NativeMethods.efl_io_closer_closed_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>If true will automatically close resources on exec() calls.
    /// When using file descriptors this should set FD_CLOEXEC so they are not inherited by the processes (children or self) doing exec().
    /// (Since EFL 1.22)</summary>
    /// <returns><c>true</c> if close on exec(), <c>false</c> otherwise</returns>
    virtual public bool GetCloseOnExec() {
         var _ret_var = Efl.Io.ICloserConcrete.NativeMethods.efl_io_closer_close_on_exec_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>If <c>true</c>, will close on exec() call.
    /// (Since EFL 1.22)</summary>
    /// <param name="close_on_exec"><c>true</c> if close on exec(), <c>false</c> otherwise</param>
    /// <returns><c>true</c> if could set, <c>false</c> if not supported or failed.</returns>
    virtual public bool SetCloseOnExec(bool close_on_exec) {
                                 var _ret_var = Efl.Io.ICloserConcrete.NativeMethods.efl_io_closer_close_on_exec_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),close_on_exec);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>If true will automatically close() on object invalidate.
    /// If the object was disconnected from its parent (including the main loop) without close, this property will state whenever it should be closed or not.
    /// (Since EFL 1.22)</summary>
    /// <returns><c>true</c> if close on invalidate, <c>false</c> otherwise</returns>
    virtual public bool GetCloseOnInvalidate() {
         var _ret_var = Efl.Io.ICloserConcrete.NativeMethods.efl_io_closer_close_on_invalidate_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>If true will automatically close() on object invalidate.
    /// If the object was disconnected from its parent (including the main loop) without close, this property will state whenever it should be closed or not.
    /// (Since EFL 1.22)</summary>
    /// <param name="close_on_invalidate"><c>true</c> if close on invalidate, <c>false</c> otherwise</param>
    virtual public void SetCloseOnInvalidate(bool close_on_invalidate) {
                                 Efl.Io.ICloserConcrete.NativeMethods.efl_io_closer_close_on_invalidate_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),close_on_invalidate);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Closes the Input/Output object.
    /// This operation will be executed immediately and may or may not block the caller thread for some time. The details of blocking behavior is to be defined by the implementation and may be subject to other parameters such as non-blocking flags, maximum timeout or even retry attempts.
    /// 
    /// You can understand this method as close(2) libc function.
    /// (Since EFL 1.22)</summary>
    /// <returns>0 on succeed, a mapping of errno otherwise</returns>
    virtual public Eina.Error Close() {
         var _ret_var = Efl.Io.ICloserConcrete.NativeMethods.efl_io_closer_close_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>If <c>true</c> will notify <see cref="Efl.Io.IReader.Read"/> can be called without blocking or failing.
    /// (Since EFL 1.22)</summary>
    /// <returns><c>true</c> if it can be read without blocking or failing, <c>false</c> otherwise</returns>
    virtual public bool GetCanRead() {
         var _ret_var = Efl.Io.IReaderConcrete.NativeMethods.efl_io_reader_can_read_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>If <c>true</c> will notify <see cref="Efl.Io.IReader.Read"/> can be called without blocking or failing.
    /// (Since EFL 1.22)</summary>
    /// <param name="can_read"><c>true</c> if it can be read without blocking or failing, <c>false</c> otherwise</param>
    virtual public void SetCanRead(bool can_read) {
                                 Efl.Io.IReaderConcrete.NativeMethods.efl_io_reader_can_read_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),can_read);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>If <c>true</c> will notify end of stream.
    /// (Since EFL 1.22)</summary>
    /// <returns><c>true</c> if end of stream, <c>false</c> otherwise</returns>
    virtual public bool GetEos() {
         var _ret_var = Efl.Io.IReaderConcrete.NativeMethods.efl_io_reader_eos_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>If <c>true</c> will notify end of stream.
    /// (Since EFL 1.22)</summary>
    /// <param name="is_eos"><c>true</c> if end of stream, <c>false</c> otherwise</param>
    virtual public void SetEos(bool is_eos) {
                                 Efl.Io.IReaderConcrete.NativeMethods.efl_io_reader_eos_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),is_eos);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Reads data into a pre-allocated buffer.
    /// This operation will be executed immediately and may or may not block the caller thread for some time. The details of blocking behavior is to be defined by the implementation and may be subject to other parameters such as non-blocking flags, maximum timeout or even retry attempts.
    /// 
    /// You can understand this method as read(2) libc function.
    /// (Since EFL 1.22)</summary>
    /// <param name="rw_slice">Provides a pre-allocated memory to be filled up to rw_slice.len. It will be populated and the length will be set to the actually used amount of bytes, which can be smaller than the request.</param>
    /// <returns>0 on succeed, a mapping of errno otherwise</returns>
    virtual public Eina.Error Read(ref Eina.RwSlice rw_slice) {
                                 var _ret_var = Efl.Io.IReaderConcrete.NativeMethods.efl_io_reader_read_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),ref rw_slice);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>If <c>true</c> will notify <see cref="Efl.Io.IWriter.Write"/> can be called without blocking or failing.
    /// (Since EFL 1.22)</summary>
    /// <returns><c>true</c> if it can be written without blocking or failure, <c>false</c> otherwise</returns>
    virtual public bool GetCanWrite() {
         var _ret_var = Efl.Io.IWriterConcrete.NativeMethods.efl_io_writer_can_write_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>If <c>true</c> will notify <see cref="Efl.Io.IWriter.Write"/> can be called without blocking or failing.
    /// (Since EFL 1.22)</summary>
    /// <param name="can_write"><c>true</c> if it can be written without blocking or failure, <c>false</c> otherwise</param>
    virtual public void SetCanWrite(bool can_write) {
                                 Efl.Io.IWriterConcrete.NativeMethods.efl_io_writer_can_write_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),can_write);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Writes data from a pre-populated buffer.
    /// This operation will be executed immediately and may or may not block the caller thread for some time. The details of blocking behavior is defined by the implementation and may be subject to other parameters such as non-blocking flags, maximum timeout or even retry attempts.
    /// 
    /// You can understand this method as write(2) libc function.
    /// (Since EFL 1.22)</summary>
    /// <param name="slice">Provides a pre-populated memory to be used up to slice.len. The returned slice will be adapted as length will be set to the actually used amount of bytes, which can be smaller than the request.</param>
    /// <param name="remaining">Convenience to output the remaining parts of slice that was not written. If the full slice was written, this will be a slice of zero-length.</param>
    /// <returns>0 on succeed, a mapping of errno otherwise</returns>
    virtual public Eina.Error Write(ref Eina.Slice slice, ref Eina.Slice remaining) {
                                                         var _ret_var = Efl.Io.IWriterConcrete.NativeMethods.efl_io_writer_write_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),ref slice, ref remaining);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <value>No description supplied.</value>
    public System.IntPtr Indata {
        get { return GetIndata(); }
        set { SetIndata(value); }
    }
    /// <value>No description supplied.</value>
    public System.IntPtr Outdata {
        get { return GetOutdata(); }
        set { SetOutdata(value); }
    }
    /// <summary>A commandline that encodes arguments in a command string. This command is unix shell-style, thus whitespace separates arguments unless escaped. Also a semi-colon &apos;;&apos;, ampersand &apos;&amp;&apos;, pipe/bar &apos;|&apos;, hash &apos;#&apos;, bracket, square brace, brace character (&apos;(&apos;, &apos;)&apos;, &apos;[&apos;, &apos;]&apos;, &apos;{&apos;, &apos;}&apos;), exclamation mark &apos;!&apos;,  backquote &apos;`&apos;, greator or less than (&apos;&gt;&apos; &apos;&lt;&apos;) character unless escaped or in quotes would cause args_count/value to not be generated properly, because it would force complex shell interpretation which will not be supported in evaluating the arg_count/value information, but the final shell may interpret this if this is executed via a command-line shell. To not be a complex shell command, it should be simple with paths, options and variable expansions, but nothing more complex involving the above unescaped characters.
    /// &quot;cat -option /path/file&quot; &quot;cat &apos;quoted argument&apos;&quot; &quot;cat ~/path/escaped argument&quot; &quot;/bin/cat escaped argument <c>VARIABLE</c>&quot; etc.
    /// 
    /// It should not try and use &quot;complex shell features&quot; if you want the arg_count and arg_value set to be correct after setting the command string. For example none of:
    /// 
    /// &quot;VAR=x /bin/command &amp;&amp; /bin/othercommand &gt;&amp; /dev/null&quot; &quot;VAR=x /bin/command `/bin/othercommand` | /bin/cmd2 &amp;&amp; cmd3 &amp;&quot; etc.
    /// 
    /// If you set the command the arg_count/value property contents can change and be completely re-evaluated by parsing the command string into an argument array set along with interpreting escapes back into individual argument strings.</summary>
    public System.String Command {
        get { return GetCommand(); }
    }
    /// <summary>Use an array to fill this object
    /// Every element of a string is a argument.</summary>
    /// <value>An array where every array field is an argument</value>
    public Eina.Array<System.String> CommandArray {
        set { SetCommandArray(value); }
    }
    /// <summary>Use a string to fill this object
    /// The string will be split at every unescaped &apos; &apos;, every resulting substring will be a new argument to the command line.</summary>
    /// <value>A command in form of a string</value>
    public System.String CommandString {
        set { SetCommandString(value); }
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
    /// <summary>If <c>true</c> will notify <see cref="Efl.Io.IReader.Read"/> can be called without blocking or failing.
    /// (Since EFL 1.22)</summary>
    /// <value><c>true</c> if it can be read without blocking or failing, <c>false</c> otherwise</value>
    public bool CanRead {
        get { return GetCanRead(); }
        set { SetCanRead(value); }
    }
    /// <summary>If <c>true</c> will notify end of stream.
    /// (Since EFL 1.22)</summary>
    /// <value><c>true</c> if end of stream, <c>false</c> otherwise</value>
    public bool Eos {
        get { return GetEos(); }
        set { SetEos(value); }
    }
    /// <summary>If <c>true</c> will notify <see cref="Efl.Io.IWriter.Write"/> can be called without blocking or failing.
    /// (Since EFL 1.22)</summary>
    /// <value><c>true</c> if it can be written without blocking or failure, <c>false</c> otherwise</value>
    public bool CanWrite {
        get { return GetCanWrite(); }
        set { SetCanWrite(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Appthread.efl_appthread_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Loop.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Ecore);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_threadio_indata_get_static_delegate == null)
            {
                efl_threadio_indata_get_static_delegate = new efl_threadio_indata_get_delegate(indata_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetIndata") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_threadio_indata_get"), func = Marshal.GetFunctionPointerForDelegate(efl_threadio_indata_get_static_delegate) });
            }

            if (efl_threadio_indata_set_static_delegate == null)
            {
                efl_threadio_indata_set_static_delegate = new efl_threadio_indata_set_delegate(indata_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetIndata") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_threadio_indata_set"), func = Marshal.GetFunctionPointerForDelegate(efl_threadio_indata_set_static_delegate) });
            }

            if (efl_threadio_outdata_get_static_delegate == null)
            {
                efl_threadio_outdata_get_static_delegate = new efl_threadio_outdata_get_delegate(outdata_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetOutdata") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_threadio_outdata_get"), func = Marshal.GetFunctionPointerForDelegate(efl_threadio_outdata_get_static_delegate) });
            }

            if (efl_threadio_outdata_set_static_delegate == null)
            {
                efl_threadio_outdata_set_static_delegate = new efl_threadio_outdata_set_delegate(outdata_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetOutdata") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_threadio_outdata_set"), func = Marshal.GetFunctionPointerForDelegate(efl_threadio_outdata_set_static_delegate) });
            }

            if (efl_threadio_call_static_delegate == null)
            {
                efl_threadio_call_static_delegate = new efl_threadio_call_delegate(call);
            }

            if (methods.FirstOrDefault(m => m.Name == "Call") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_threadio_call"), func = Marshal.GetFunctionPointerForDelegate(efl_threadio_call_static_delegate) });
            }

            if (efl_threadio_call_sync_static_delegate == null)
            {
                efl_threadio_call_sync_static_delegate = new efl_threadio_call_sync_delegate(call_sync);
            }

            if (methods.FirstOrDefault(m => m.Name == "CallSync") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_threadio_call_sync"), func = Marshal.GetFunctionPointerForDelegate(efl_threadio_call_sync_static_delegate) });
            }

            if (efl_core_command_line_command_get_static_delegate == null)
            {
                efl_core_command_line_command_get_static_delegate = new efl_core_command_line_command_get_delegate(command_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetCommand") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_core_command_line_command_get"), func = Marshal.GetFunctionPointerForDelegate(efl_core_command_line_command_get_static_delegate) });
            }

            if (efl_core_command_line_command_array_set_static_delegate == null)
            {
                efl_core_command_line_command_array_set_static_delegate = new efl_core_command_line_command_array_set_delegate(command_array_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetCommandArray") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_core_command_line_command_array_set"), func = Marshal.GetFunctionPointerForDelegate(efl_core_command_line_command_array_set_static_delegate) });
            }

            if (efl_core_command_line_command_string_set_static_delegate == null)
            {
                efl_core_command_line_command_string_set_static_delegate = new efl_core_command_line_command_string_set_delegate(command_string_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetCommandString") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_core_command_line_command_string_set"), func = Marshal.GetFunctionPointerForDelegate(efl_core_command_line_command_string_set_static_delegate) });
            }

            if (efl_core_command_line_command_access_static_delegate == null)
            {
                efl_core_command_line_command_access_static_delegate = new efl_core_command_line_command_access_delegate(command_access);
            }

            if (methods.FirstOrDefault(m => m.Name == "CommandAccess") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_core_command_line_command_access"), func = Marshal.GetFunctionPointerForDelegate(efl_core_command_line_command_access_static_delegate) });
            }

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

            if (efl_io_reader_can_read_get_static_delegate == null)
            {
                efl_io_reader_can_read_get_static_delegate = new efl_io_reader_can_read_get_delegate(can_read_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetCanRead") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_io_reader_can_read_get"), func = Marshal.GetFunctionPointerForDelegate(efl_io_reader_can_read_get_static_delegate) });
            }

            if (efl_io_reader_can_read_set_static_delegate == null)
            {
                efl_io_reader_can_read_set_static_delegate = new efl_io_reader_can_read_set_delegate(can_read_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetCanRead") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_io_reader_can_read_set"), func = Marshal.GetFunctionPointerForDelegate(efl_io_reader_can_read_set_static_delegate) });
            }

            if (efl_io_reader_eos_get_static_delegate == null)
            {
                efl_io_reader_eos_get_static_delegate = new efl_io_reader_eos_get_delegate(eos_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetEos") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_io_reader_eos_get"), func = Marshal.GetFunctionPointerForDelegate(efl_io_reader_eos_get_static_delegate) });
            }

            if (efl_io_reader_eos_set_static_delegate == null)
            {
                efl_io_reader_eos_set_static_delegate = new efl_io_reader_eos_set_delegate(eos_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetEos") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_io_reader_eos_set"), func = Marshal.GetFunctionPointerForDelegate(efl_io_reader_eos_set_static_delegate) });
            }

            if (efl_io_reader_read_static_delegate == null)
            {
                efl_io_reader_read_static_delegate = new efl_io_reader_read_delegate(read);
            }

            if (methods.FirstOrDefault(m => m.Name == "Read") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_io_reader_read"), func = Marshal.GetFunctionPointerForDelegate(efl_io_reader_read_static_delegate) });
            }

            if (efl_io_writer_can_write_get_static_delegate == null)
            {
                efl_io_writer_can_write_get_static_delegate = new efl_io_writer_can_write_get_delegate(can_write_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetCanWrite") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_io_writer_can_write_get"), func = Marshal.GetFunctionPointerForDelegate(efl_io_writer_can_write_get_static_delegate) });
            }

            if (efl_io_writer_can_write_set_static_delegate == null)
            {
                efl_io_writer_can_write_set_static_delegate = new efl_io_writer_can_write_set_delegate(can_write_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetCanWrite") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_io_writer_can_write_set"), func = Marshal.GetFunctionPointerForDelegate(efl_io_writer_can_write_set_static_delegate) });
            }

            if (efl_io_writer_write_static_delegate == null)
            {
                efl_io_writer_write_static_delegate = new efl_io_writer_write_delegate(write);
            }

            if (methods.FirstOrDefault(m => m.Name == "Write") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_io_writer_write"), func = Marshal.GetFunctionPointerForDelegate(efl_io_writer_write_static_delegate) });
            }

            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Appthread.efl_appthread_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate System.IntPtr efl_threadio_indata_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate System.IntPtr efl_threadio_indata_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_threadio_indata_get_api_delegate> efl_threadio_indata_get_ptr = new Efl.Eo.FunctionWrapper<efl_threadio_indata_get_api_delegate>(Module, "efl_threadio_indata_get");

        private static System.IntPtr indata_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_threadio_indata_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            System.IntPtr _ret_var = default(System.IntPtr);
                try
                {
                    _ret_var = ((Appthread)ws.Target).GetIndata();
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
                return efl_threadio_indata_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_threadio_indata_get_delegate efl_threadio_indata_get_static_delegate;

        
        private delegate void efl_threadio_indata_set_delegate(System.IntPtr obj, System.IntPtr pd,  System.IntPtr data);

        
        public delegate void efl_threadio_indata_set_api_delegate(System.IntPtr obj,  System.IntPtr data);

        public static Efl.Eo.FunctionWrapper<efl_threadio_indata_set_api_delegate> efl_threadio_indata_set_ptr = new Efl.Eo.FunctionWrapper<efl_threadio_indata_set_api_delegate>(Module, "efl_threadio_indata_set");

        private static void indata_set(System.IntPtr obj, System.IntPtr pd, System.IntPtr data)
        {
            Eina.Log.Debug("function efl_threadio_indata_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Appthread)ws.Target).SetIndata(data);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_threadio_indata_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), data);
            }
        }

        private static efl_threadio_indata_set_delegate efl_threadio_indata_set_static_delegate;

        
        private delegate System.IntPtr efl_threadio_outdata_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate System.IntPtr efl_threadio_outdata_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_threadio_outdata_get_api_delegate> efl_threadio_outdata_get_ptr = new Efl.Eo.FunctionWrapper<efl_threadio_outdata_get_api_delegate>(Module, "efl_threadio_outdata_get");

        private static System.IntPtr outdata_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_threadio_outdata_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            System.IntPtr _ret_var = default(System.IntPtr);
                try
                {
                    _ret_var = ((Appthread)ws.Target).GetOutdata();
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
                return efl_threadio_outdata_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_threadio_outdata_get_delegate efl_threadio_outdata_get_static_delegate;

        
        private delegate void efl_threadio_outdata_set_delegate(System.IntPtr obj, System.IntPtr pd,  System.IntPtr data);

        
        public delegate void efl_threadio_outdata_set_api_delegate(System.IntPtr obj,  System.IntPtr data);

        public static Efl.Eo.FunctionWrapper<efl_threadio_outdata_set_api_delegate> efl_threadio_outdata_set_ptr = new Efl.Eo.FunctionWrapper<efl_threadio_outdata_set_api_delegate>(Module, "efl_threadio_outdata_set");

        private static void outdata_set(System.IntPtr obj, System.IntPtr pd, System.IntPtr data)
        {
            Eina.Log.Debug("function efl_threadio_outdata_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Appthread)ws.Target).SetOutdata(data);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_threadio_outdata_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), data);
            }
        }

        private static efl_threadio_outdata_set_delegate efl_threadio_outdata_set_static_delegate;

        
        private delegate void efl_threadio_call_delegate(System.IntPtr obj, System.IntPtr pd,  IntPtr func_data, EFlThreadIOCallInternal func, EinaFreeCb func_free_cb);

        
        public delegate void efl_threadio_call_api_delegate(System.IntPtr obj,  IntPtr func_data, EFlThreadIOCallInternal func, EinaFreeCb func_free_cb);

        public static Efl.Eo.FunctionWrapper<efl_threadio_call_api_delegate> efl_threadio_call_ptr = new Efl.Eo.FunctionWrapper<efl_threadio_call_api_delegate>(Module, "efl_threadio_call");

        private static void call(System.IntPtr obj, System.IntPtr pd, IntPtr func_data, EFlThreadIOCallInternal func, EinaFreeCb func_free_cb)
        {
            Eina.Log.Debug("function efl_threadio_call was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                            EFlThreadIOCallWrapper func_wrapper = new EFlThreadIOCallWrapper(func, func_data, func_free_cb);
            
                try
                {
                    ((Appthread)ws.Target).Call(func_wrapper.ManagedCb);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_threadio_call_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), func_data, func, func_free_cb);
            }
        }

        private static efl_threadio_call_delegate efl_threadio_call_static_delegate;

        
        private delegate System.IntPtr efl_threadio_call_sync_delegate(System.IntPtr obj, System.IntPtr pd,  IntPtr func_data, EFlThreadIOCallSyncInternal func, EinaFreeCb func_free_cb);

        
        public delegate System.IntPtr efl_threadio_call_sync_api_delegate(System.IntPtr obj,  IntPtr func_data, EFlThreadIOCallSyncInternal func, EinaFreeCb func_free_cb);

        public static Efl.Eo.FunctionWrapper<efl_threadio_call_sync_api_delegate> efl_threadio_call_sync_ptr = new Efl.Eo.FunctionWrapper<efl_threadio_call_sync_api_delegate>(Module, "efl_threadio_call_sync");

        private static System.IntPtr call_sync(System.IntPtr obj, System.IntPtr pd, IntPtr func_data, EFlThreadIOCallSyncInternal func, EinaFreeCb func_free_cb)
        {
            Eina.Log.Debug("function efl_threadio_call_sync was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                            EFlThreadIOCallSyncWrapper func_wrapper = new EFlThreadIOCallSyncWrapper(func, func_data, func_free_cb);
            System.IntPtr _ret_var = default(System.IntPtr);
                try
                {
                    _ret_var = ((Appthread)ws.Target).CallSync(func_wrapper.ManagedCb);
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
                return efl_threadio_call_sync_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), func_data, func, func_free_cb);
            }
        }

        private static efl_threadio_call_sync_delegate efl_threadio_call_sync_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_core_command_line_command_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_core_command_line_command_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_core_command_line_command_get_api_delegate> efl_core_command_line_command_get_ptr = new Efl.Eo.FunctionWrapper<efl_core_command_line_command_get_api_delegate>(Module, "efl_core_command_line_command_get");

        private static System.String command_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_core_command_line_command_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((Appthread)ws.Target).GetCommand();
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
                return efl_core_command_line_command_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_core_command_line_command_get_delegate efl_core_command_line_command_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_core_command_line_command_array_set_delegate(System.IntPtr obj, System.IntPtr pd,  System.IntPtr array);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_core_command_line_command_array_set_api_delegate(System.IntPtr obj,  System.IntPtr array);

        public static Efl.Eo.FunctionWrapper<efl_core_command_line_command_array_set_api_delegate> efl_core_command_line_command_array_set_ptr = new Efl.Eo.FunctionWrapper<efl_core_command_line_command_array_set_api_delegate>(Module, "efl_core_command_line_command_array_set");

        private static bool command_array_set(System.IntPtr obj, System.IntPtr pd, System.IntPtr array)
        {
            Eina.Log.Debug("function efl_core_command_line_command_array_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        var _in_array = new Eina.Array<System.String>(array, true, true);
                            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Appthread)ws.Target).SetCommandArray(_in_array);
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
                return efl_core_command_line_command_array_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), array);
            }
        }

        private static efl_core_command_line_command_array_set_delegate efl_core_command_line_command_array_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_core_command_line_command_string_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String str);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_core_command_line_command_string_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String str);

        public static Efl.Eo.FunctionWrapper<efl_core_command_line_command_string_set_api_delegate> efl_core_command_line_command_string_set_ptr = new Efl.Eo.FunctionWrapper<efl_core_command_line_command_string_set_api_delegate>(Module, "efl_core_command_line_command_string_set");

        private static bool command_string_set(System.IntPtr obj, System.IntPtr pd, System.String str)
        {
            Eina.Log.Debug("function efl_core_command_line_command_string_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Appthread)ws.Target).SetCommandString(str);
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
                return efl_core_command_line_command_string_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), str);
            }
        }

        private static efl_core_command_line_command_string_set_delegate efl_core_command_line_command_string_set_static_delegate;

        
        private delegate System.IntPtr efl_core_command_line_command_access_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate System.IntPtr efl_core_command_line_command_access_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_core_command_line_command_access_api_delegate> efl_core_command_line_command_access_ptr = new Efl.Eo.FunctionWrapper<efl_core_command_line_command_access_api_delegate>(Module, "efl_core_command_line_command_access");

        private static System.IntPtr command_access(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_core_command_line_command_access was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Accessor<System.String> _ret_var = default(Eina.Accessor<System.String>);
                try
                {
                    _ret_var = ((Appthread)ws.Target).CommandAccess();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        return _ret_var.Handle;

            }
            else
            {
                return efl_core_command_line_command_access_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_core_command_line_command_access_delegate efl_core_command_line_command_access_static_delegate;

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
                    _ret_var = ((Appthread)ws.Target).GetClosed();
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
                    _ret_var = ((Appthread)ws.Target).GetCloseOnExec();
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
                    _ret_var = ((Appthread)ws.Target).SetCloseOnExec(close_on_exec);
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
                    _ret_var = ((Appthread)ws.Target).GetCloseOnInvalidate();
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
                    ((Appthread)ws.Target).SetCloseOnInvalidate(close_on_invalidate);
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
                    _ret_var = ((Appthread)ws.Target).Close();
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

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_io_reader_can_read_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_io_reader_can_read_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_io_reader_can_read_get_api_delegate> efl_io_reader_can_read_get_ptr = new Efl.Eo.FunctionWrapper<efl_io_reader_can_read_get_api_delegate>(Module, "efl_io_reader_can_read_get");

        private static bool can_read_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_io_reader_can_read_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Appthread)ws.Target).GetCanRead();
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
                return efl_io_reader_can_read_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_io_reader_can_read_get_delegate efl_io_reader_can_read_get_static_delegate;

        
        private delegate void efl_io_reader_can_read_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool can_read);

        
        public delegate void efl_io_reader_can_read_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool can_read);

        public static Efl.Eo.FunctionWrapper<efl_io_reader_can_read_set_api_delegate> efl_io_reader_can_read_set_ptr = new Efl.Eo.FunctionWrapper<efl_io_reader_can_read_set_api_delegate>(Module, "efl_io_reader_can_read_set");

        private static void can_read_set(System.IntPtr obj, System.IntPtr pd, bool can_read)
        {
            Eina.Log.Debug("function efl_io_reader_can_read_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Appthread)ws.Target).SetCanRead(can_read);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_io_reader_can_read_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), can_read);
            }
        }

        private static efl_io_reader_can_read_set_delegate efl_io_reader_can_read_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_io_reader_eos_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_io_reader_eos_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_io_reader_eos_get_api_delegate> efl_io_reader_eos_get_ptr = new Efl.Eo.FunctionWrapper<efl_io_reader_eos_get_api_delegate>(Module, "efl_io_reader_eos_get");

        private static bool eos_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_io_reader_eos_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Appthread)ws.Target).GetEos();
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
                return efl_io_reader_eos_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_io_reader_eos_get_delegate efl_io_reader_eos_get_static_delegate;

        
        private delegate void efl_io_reader_eos_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool is_eos);

        
        public delegate void efl_io_reader_eos_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool is_eos);

        public static Efl.Eo.FunctionWrapper<efl_io_reader_eos_set_api_delegate> efl_io_reader_eos_set_ptr = new Efl.Eo.FunctionWrapper<efl_io_reader_eos_set_api_delegate>(Module, "efl_io_reader_eos_set");

        private static void eos_set(System.IntPtr obj, System.IntPtr pd, bool is_eos)
        {
            Eina.Log.Debug("function efl_io_reader_eos_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Appthread)ws.Target).SetEos(is_eos);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_io_reader_eos_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), is_eos);
            }
        }

        private static efl_io_reader_eos_set_delegate efl_io_reader_eos_set_static_delegate;

        
        private delegate Eina.Error efl_io_reader_read_delegate(System.IntPtr obj, System.IntPtr pd,  ref Eina.RwSlice rw_slice);

        
        public delegate Eina.Error efl_io_reader_read_api_delegate(System.IntPtr obj,  ref Eina.RwSlice rw_slice);

        public static Efl.Eo.FunctionWrapper<efl_io_reader_read_api_delegate> efl_io_reader_read_ptr = new Efl.Eo.FunctionWrapper<efl_io_reader_read_api_delegate>(Module, "efl_io_reader_read");

        private static Eina.Error read(System.IntPtr obj, System.IntPtr pd, ref Eina.RwSlice rw_slice)
        {
            Eina.Log.Debug("function efl_io_reader_read was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    Eina.Error _ret_var = default(Eina.Error);
                try
                {
                    _ret_var = ((Appthread)ws.Target).Read(ref rw_slice);
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
                return efl_io_reader_read_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), ref rw_slice);
            }
        }

        private static efl_io_reader_read_delegate efl_io_reader_read_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_io_writer_can_write_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_io_writer_can_write_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_io_writer_can_write_get_api_delegate> efl_io_writer_can_write_get_ptr = new Efl.Eo.FunctionWrapper<efl_io_writer_can_write_get_api_delegate>(Module, "efl_io_writer_can_write_get");

        private static bool can_write_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_io_writer_can_write_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Appthread)ws.Target).GetCanWrite();
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
                return efl_io_writer_can_write_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_io_writer_can_write_get_delegate efl_io_writer_can_write_get_static_delegate;

        
        private delegate void efl_io_writer_can_write_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool can_write);

        
        public delegate void efl_io_writer_can_write_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool can_write);

        public static Efl.Eo.FunctionWrapper<efl_io_writer_can_write_set_api_delegate> efl_io_writer_can_write_set_ptr = new Efl.Eo.FunctionWrapper<efl_io_writer_can_write_set_api_delegate>(Module, "efl_io_writer_can_write_set");

        private static void can_write_set(System.IntPtr obj, System.IntPtr pd, bool can_write)
        {
            Eina.Log.Debug("function efl_io_writer_can_write_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Appthread)ws.Target).SetCanWrite(can_write);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_io_writer_can_write_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), can_write);
            }
        }

        private static efl_io_writer_can_write_set_delegate efl_io_writer_can_write_set_static_delegate;

        
        private delegate Eina.Error efl_io_writer_write_delegate(System.IntPtr obj, System.IntPtr pd,  ref Eina.Slice slice,  ref Eina.Slice remaining);

        
        public delegate Eina.Error efl_io_writer_write_api_delegate(System.IntPtr obj,  ref Eina.Slice slice,  ref Eina.Slice remaining);

        public static Efl.Eo.FunctionWrapper<efl_io_writer_write_api_delegate> efl_io_writer_write_ptr = new Efl.Eo.FunctionWrapper<efl_io_writer_write_api_delegate>(Module, "efl_io_writer_write");

        private static Eina.Error write(System.IntPtr obj, System.IntPtr pd, ref Eina.Slice slice, ref Eina.Slice remaining)
        {
            Eina.Log.Debug("function efl_io_writer_write was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                remaining = default(Eina.Slice);                            Eina.Error _ret_var = default(Eina.Error);
                try
                {
                    _ret_var = ((Appthread)ws.Target).Write(ref slice, ref remaining);
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
                return efl_io_writer_write_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), ref slice, ref remaining);
            }
        }

        private static efl_io_writer_write_delegate efl_io_writer_write_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

