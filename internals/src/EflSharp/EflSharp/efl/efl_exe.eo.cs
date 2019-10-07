#define EFL_BETA
#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

/// <summary>This is a specialized <see cref="Efl.Task"/> which abstracts an operating system process. This class provides a way to start a task by running an executable file (specified using the <see cref="Efl.Core.ICommandLine"/> interface) and further customize its execution flags (<see cref="Efl.Exe.ExeFlags"/>) and environment variables (<see cref="Efl.Exe.Env"/>). It also allows communicating with the process through signals (<see cref="Efl.Exe.Signal"/>).</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Exe.NativeMethods]
[Efl.Eo.BindingEntity]
public class Exe : Efl.Task, Efl.Core.ICommandLine, Efl.Io.ICloser, Efl.Io.IReader, Efl.Io.IWriter
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(Exe))
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
        efl_exe_class_get();

    /// <summary>Initializes a new instance of the <see cref="Exe"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public Exe(Efl.Object parent= null
            ) : base(efl_exe_class_get(), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected Exe(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Exe"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected Exe(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Exe"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected Exe(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }


    /// <summary>Notifies closed, when property is marked as true</summary>
    /// <since_tizen> 6 </since_tizen>
    public event EventHandler ClosedEvent
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
                AddNativeEventHandler(efl.Libs.Ecore, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_IO_CLOSER_EVENT_CLOSED";
                RemoveNativeEventHandler(efl.Libs.Ecore, key, value);
            }
        }
    }

    /// <summary>Method to raise event ClosedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnClosedEvent(EventArgs e)
    {
        var key = "_EFL_IO_CLOSER_EVENT_CLOSED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Ecore, key);
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
    /// Note that usually this event is dispatched from inside <see cref="Efl.Io.IReader.Read"/>, thus before it returns.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="Efl.Io.ReaderCanReadChangedEventArgs"/></value>
    public event EventHandler<Efl.Io.ReaderCanReadChangedEventArgs> CanReadChangedEvent
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
                        Efl.Io.ReaderCanReadChangedEventArgs args = new Efl.Io.ReaderCanReadChangedEventArgs();
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
                AddNativeEventHandler(efl.Libs.Ecore, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_IO_READER_EVENT_CAN_READ_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Ecore, key, value);
            }
        }
    }

    /// <summary>Method to raise event CanReadChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnCanReadChangedEvent(Efl.Io.ReaderCanReadChangedEventArgs e)
    {
        var key = "_EFL_IO_READER_EVENT_CAN_READ_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Ecore, key);
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
    /// The property <see cref="Efl.Io.IReader.CanRead"/> should change to <c>false</c> before this event is dispatched.</summary>
    /// <since_tizen> 6 </since_tizen>
    public event EventHandler EosEvent
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

                string key = "_EFL_IO_READER_EVENT_EOS";
                AddNativeEventHandler(efl.Libs.Ecore, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_IO_READER_EVENT_EOS";
                RemoveNativeEventHandler(efl.Libs.Ecore, key, value);
            }
        }
    }

    /// <summary>Method to raise event EosEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnEosEvent(EventArgs e)
    {
        var key = "_EFL_IO_READER_EVENT_EOS";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Ecore, key);
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
    /// Note that usually this event is dispatched from inside <see cref="Efl.Io.IWriter.Write"/>, thus before it returns.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="Efl.Io.WriterCanWriteChangedEventArgs"/></value>
    public event EventHandler<Efl.Io.WriterCanWriteChangedEventArgs> CanWriteChangedEvent
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
                        Efl.Io.WriterCanWriteChangedEventArgs args = new Efl.Io.WriterCanWriteChangedEventArgs();
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
                AddNativeEventHandler(efl.Libs.Ecore, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_IO_WRITER_EVENT_CAN_WRITE_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Ecore, key, value);
            }
        }
    }

    /// <summary>Method to raise event CanWriteChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnCanWriteChangedEvent(Efl.Io.WriterCanWriteChangedEventArgs e)
    {
        var key = "_EFL_IO_WRITER_EVENT_CAN_WRITE_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Ecore, key);
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

    /// <summary>Customize the process&apos; behavior.</summary>
    /// <returns>Flags.</returns>
    public virtual Efl.ExeFlags GetExeFlags() {
        var _ret_var = Efl.Exe.NativeMethods.efl_exe_flags_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Customize the process&apos; behavior.</summary>
    /// <param name="flags">Flags.</param>
    public virtual void SetExeFlags(Efl.ExeFlags flags) {
        Efl.Exe.NativeMethods.efl_exe_flags_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),flags);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>The signal this process emitted upon exiting, if any.</summary>
    /// <returns>The exit signal, or -1 if no exit signal happened.</returns>
    public virtual int GetExitSignal() {
        var _ret_var = Efl.Exe.NativeMethods.efl_exe_exit_signal_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>If <c>env</c> is <c>NULL</c> then the process created by this object is going to inherit the environment of this process.
    /// In case <c>env</c> is not <c>NULL</c> then the environment variables declared in this object will represent the environment passed to the new process.</summary>
    /// <returns><c>env</c> will be referenced until this object does not need it anymore.</returns>
    public virtual Efl.Core.Env GetEnv() {
        var _ret_var = Efl.Exe.NativeMethods.efl_exe_env_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>If <c>env</c> is <c>NULL</c> then the process created by this object is going to inherit the environment of this process.
    /// In case <c>env</c> is not <c>NULL</c> then the environment variables declared in this object will represent the environment passed to the new process.</summary>
    /// <param name="env"><c>env</c> will be referenced until this object does not need it anymore.</param>
    public virtual void SetEnv(Efl.Core.Env env) {
        Efl.Exe.NativeMethods.efl_exe_env_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),env);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Send a signal to this process.</summary>
    /// <param name="sig">Signal number to send.</param>
    public virtual void Signal(Efl.ExeSignal sig) {
        Efl.Exe.NativeMethods.efl_exe_signal_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),sig);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>A commandline that encodes arguments in a command string. This command is unix shell-style, thus whitespace separates arguments unless escaped. Also a semi-colon &apos;;&apos;, ampersand &apos;&amp;&apos;, pipe/bar &apos;|&apos;, hash &apos;#&apos;, bracket, square brace, brace character (&apos;(&apos;, &apos;)&apos;, &apos;[&apos;, &apos;]&apos;, &apos;{&apos;, &apos;}&apos;), exclamation mark &apos;!&apos;,  backquote &apos;`&apos;, greator or less than (&apos;&gt;&apos; &apos;&lt;&apos;) character unless escaped or in quotes would cause args_count/value to not be generated properly, because it would force complex shell interpretation which will not be supported in evaluating the arg_count/value information, but the final shell may interpret this if this is executed via a command-line shell. To not be a complex shell command, it should be simple with paths, options and variable expansions, but nothing more complex involving the above unescaped characters.
    /// &quot;cat -option /path/file&quot; &quot;cat &apos;quoted argument&apos;&quot; &quot;cat ~/path/escaped argument&quot; &quot;/bin/cat escaped argument <c>VARIABLE</c>&quot; etc.
    /// 
    /// It should not try and use &quot;complex shell features&quot; if you want the arg_count and arg_value set to be correct after setting the command string. For example none of:
    /// 
    /// &quot;VAR=x /bin/command &amp;&amp; /bin/othercommand &gt;&amp; /dev/null&quot; &quot;VAR=x /bin/command `/bin/othercommand` | /bin/cmd2 &amp;&amp; cmd3 &amp;&quot; etc.
    /// 
    /// If you set the command the arg_count/value property contents can change and be completely re-evaluated by parsing the command string into an argument array set along with interpreting escapes back into individual argument strings.</summary>
    public virtual System.String GetCommand() {
        var _ret_var = Efl.Core.CommandLineConcrete.NativeMethods.efl_core_command_line_command_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Use an array to fill this object
    /// Every element of a string is a argument.</summary>
    /// <param name="array">An array where every array field is an argument</param>
    /// <returns>On success <c>true</c>, <c>false</c> otherwise</returns>
    public virtual bool SetCommandArray(Eina.Array<Eina.Stringshare> array) {
        var _in_array = array.Handle;
array.Own = false;
array.OwnContent = false;
var _ret_var = Efl.Core.CommandLineConcrete.NativeMethods.efl_core_command_line_command_array_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_array);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Use a string to fill this object
    /// The string will be split at every unescaped &apos; &apos;, every resulting substring will be a new argument to the command line.</summary>
    /// <param name="str">A command in form of a string</param>
    /// <returns>On success <c>true</c>, <c>false</c> otherwise</returns>
    public virtual bool SetCommandString(System.String str) {
        var _ret_var = Efl.Core.CommandLineConcrete.NativeMethods.efl_core_command_line_command_string_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),str);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Get the accessor which enables access to each argument that got passed to this object.</summary>
    public virtual Eina.Accessor<Eina.Stringshare> CommandAccess() {
        var _ret_var = Efl.Core.CommandLineConcrete.NativeMethods.efl_core_command_line_command_access_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return new Eina.Accessor<Eina.Stringshare>(_ret_var, false);

    }

    /// <summary>If true will notify object was closed.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns><c>true</c> if closed, <c>false</c> otherwise</returns>
    public virtual bool GetClosed() {
        var _ret_var = Efl.Io.CloserConcrete.NativeMethods.efl_io_closer_closed_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>If true will automatically close resources on exec() calls.
    /// When using file descriptors this should set FD_CLOEXEC so they are not inherited by the processes (children or self) doing exec().</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns><c>true</c> if close on exec(), <c>false</c> otherwise</returns>
    public virtual bool GetCloseOnExec() {
        var _ret_var = Efl.Io.CloserConcrete.NativeMethods.efl_io_closer_close_on_exec_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>If <c>true</c>, will close on exec() call.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="close_on_exec"><c>true</c> if close on exec(), <c>false</c> otherwise</param>
    /// <returns><c>true</c> if could set, <c>false</c> if not supported or failed.</returns>
    public virtual bool SetCloseOnExec(bool close_on_exec) {
        var _ret_var = Efl.Io.CloserConcrete.NativeMethods.efl_io_closer_close_on_exec_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),close_on_exec);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>If true will automatically close() on object invalidate.
    /// If the object was disconnected from its parent (including the main loop) without close, this property will state whenever it should be closed or not.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns><c>true</c> if close on invalidate, <c>false</c> otherwise</returns>
    public virtual bool GetCloseOnInvalidate() {
        var _ret_var = Efl.Io.CloserConcrete.NativeMethods.efl_io_closer_close_on_invalidate_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>If true will automatically close() on object invalidate.
    /// If the object was disconnected from its parent (including the main loop) without close, this property will state whenever it should be closed or not.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="close_on_invalidate"><c>true</c> if close on invalidate, <c>false</c> otherwise</param>
    public virtual void SetCloseOnInvalidate(bool close_on_invalidate) {
        Efl.Io.CloserConcrete.NativeMethods.efl_io_closer_close_on_invalidate_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),close_on_invalidate);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Closes the Input/Output object.
    /// This operation will be executed immediately and may or may not block the caller thread for some time. The details of blocking behavior is to be defined by the implementation and may be subject to other parameters such as non-blocking flags, maximum timeout or even retry attempts.
    /// 
    /// You can understand this method as close(2) libc function.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>0 on succeed, a mapping of errno otherwise</returns>
    public virtual Eina.Error Close() {
        var _ret_var = Efl.Io.CloserConcrete.NativeMethods.efl_io_closer_close_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>If <c>true</c> will notify <see cref="Efl.Io.IReader.Read"/> can be called without blocking or failing.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns><c>true</c> if it can be read without blocking or failing, <c>false</c> otherwise</returns>
    public virtual bool GetCanRead() {
        var _ret_var = Efl.Io.ReaderConcrete.NativeMethods.efl_io_reader_can_read_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>If <c>true</c> will notify <see cref="Efl.Io.IReader.Read"/> can be called without blocking or failing.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="can_read"><c>true</c> if it can be read without blocking or failing, <c>false</c> otherwise</param>
    protected virtual void SetCanRead(bool can_read) {
        Efl.Io.ReaderConcrete.NativeMethods.efl_io_reader_can_read_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),can_read);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>If <c>true</c> will notify end of stream.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns><c>true</c> if end of stream, <c>false</c> otherwise</returns>
    public virtual bool GetEos() {
        var _ret_var = Efl.Io.ReaderConcrete.NativeMethods.efl_io_reader_eos_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>If <c>true</c> will notify end of stream.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="is_eos"><c>true</c> if end of stream, <c>false</c> otherwise</param>
    protected virtual void SetEos(bool is_eos) {
        Efl.Io.ReaderConcrete.NativeMethods.efl_io_reader_eos_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),is_eos);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Reads data into a pre-allocated buffer.
    /// This operation will be executed immediately and may or may not block the caller thread for some time. The details of blocking behavior is to be defined by the implementation and may be subject to other parameters such as non-blocking flags, maximum timeout or even retry attempts.
    /// 
    /// You can understand this method as read(2) libc function.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="rw_slice">Provides a pre-allocated memory to be filled up to rw_slice.len. It will be populated and the length will be set to the actually used amount of bytes, which can be smaller than the request.</param>
    /// <returns>0 on succeed, a mapping of errno otherwise</returns>
    public virtual Eina.Error Read(ref  Eina.RwSlice rw_slice) {
        var _ret_var = Efl.Io.ReaderConcrete.NativeMethods.efl_io_reader_read_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),ref rw_slice);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>If <c>true</c> will notify <see cref="Efl.Io.IWriter.Write"/> can be called without blocking or failing.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns><c>true</c> if it can be written without blocking or failure, <c>false</c> otherwise</returns>
    public virtual bool GetCanWrite() {
        var _ret_var = Efl.Io.WriterConcrete.NativeMethods.efl_io_writer_can_write_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>If <c>true</c> will notify <see cref="Efl.Io.IWriter.Write"/> can be called without blocking or failing.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="can_write"><c>true</c> if it can be written without blocking or failure, <c>false</c> otherwise</param>
    protected virtual void SetCanWrite(bool can_write) {
        Efl.Io.WriterConcrete.NativeMethods.efl_io_writer_can_write_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),can_write);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Writes data from a pre-populated buffer.
    /// This operation will be executed immediately and may or may not block the caller thread for some time. The details of blocking behavior is defined by the implementation and may be subject to other parameters such as non-blocking flags, maximum timeout or even retry attempts.
    /// 
    /// You can understand this method as write(2) libc function.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="slice">Provides a pre-populated memory to be used up to slice.len. The returned slice will be adapted as length will be set to the actually used amount of bytes, which can be smaller than the request.</param>
    /// <param name="remaining">Convenience to output the remaining parts of slice that were not written. If the full slice was written, this will be a slice of zero-length.</param>
    /// <returns>0 on succeed, a mapping of errno otherwise</returns>
    public virtual Eina.Error Write(ref  Eina.Slice slice, ref  Eina.Slice remaining) {
        var _ret_var = Efl.Io.WriterConcrete.NativeMethods.efl_io_writer_write_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),ref slice, ref remaining);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Customize the process&apos; behavior.</summary>
    /// <value>Flags.</value>
    public Efl.ExeFlags ExeFlags {
        get { return GetExeFlags(); }
        set { SetExeFlags(value); }
    }

    /// <summary>The signal this process emitted upon exiting, if any.</summary>
    /// <value>The exit signal, or -1 if no exit signal happened.</value>
    public int ExitSignal {
        get { return GetExitSignal(); }
    }

    /// <summary>If <c>env</c> is <c>NULL</c> then the process created by this object is going to inherit the environment of this process.
    /// In case <c>env</c> is not <c>NULL</c> then the environment variables declared in this object will represent the environment passed to the new process.</summary>
    /// <value><c>env</c> will be referenced until this object does not need it anymore.</value>
    public Efl.Core.Env Env {
        get { return GetEnv(); }
        set { SetEnv(value); }
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
    public Eina.Array<Eina.Stringshare> CommandArray {
        set { SetCommandArray(value); }
    }

    /// <summary>Use a string to fill this object
    /// The string will be split at every unescaped &apos; &apos;, every resulting substring will be a new argument to the command line.</summary>
    /// <value>A command in form of a string</value>
    public System.String CommandString {
        set { SetCommandString(value); }
    }

    /// <summary>If true will notify object was closed.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><c>true</c> if closed, <c>false</c> otherwise</value>
    public bool Closed {
        get { return GetClosed(); }
    }

    /// <summary>If true will automatically close resources on exec() calls.
    /// When using file descriptors this should set FD_CLOEXEC so they are not inherited by the processes (children or self) doing exec().</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><c>true</c> if close on exec(), <c>false</c> otherwise</value>
    public bool CloseOnExec {
        get { return GetCloseOnExec(); }
        set { SetCloseOnExec(value); }
    }

    /// <summary>If true will automatically close() on object invalidate.
    /// If the object was disconnected from its parent (including the main loop) without close, this property will state whenever it should be closed or not.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><c>true</c> if close on invalidate, <c>false</c> otherwise</value>
    public bool CloseOnInvalidate {
        get { return GetCloseOnInvalidate(); }
        set { SetCloseOnInvalidate(value); }
    }

    /// <summary>If <c>true</c> will notify <see cref="Efl.Io.IReader.Read"/> can be called without blocking or failing.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><c>true</c> if it can be read without blocking or failing, <c>false</c> otherwise</value>
    public bool CanRead {
        get { return GetCanRead(); }
        protected set { SetCanRead(value); }
    }

    /// <summary>If <c>true</c> will notify end of stream.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><c>true</c> if end of stream, <c>false</c> otherwise</value>
    public bool Eos {
        get { return GetEos(); }
        protected set { SetEos(value); }
    }

    /// <summary>If <c>true</c> will notify <see cref="Efl.Io.IWriter.Write"/> can be called without blocking or failing.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><c>true</c> if it can be written without blocking or failure, <c>false</c> otherwise</value>
    public bool CanWrite {
        get { return GetCanWrite(); }
        protected set { SetCanWrite(value); }
    }

    private static IntPtr GetEflClassStatic()
    {
        return Efl.Exe.efl_exe_class_get();
    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Task.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(efl.Libs.Ecore);

        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_exe_flags_get_static_delegate == null)
            {
                efl_exe_flags_get_static_delegate = new efl_exe_flags_get_delegate(exe_flags_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetExeFlags") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_exe_flags_get"), func = Marshal.GetFunctionPointerForDelegate(efl_exe_flags_get_static_delegate) });
            }

            if (efl_exe_flags_set_static_delegate == null)
            {
                efl_exe_flags_set_static_delegate = new efl_exe_flags_set_delegate(exe_flags_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetExeFlags") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_exe_flags_set"), func = Marshal.GetFunctionPointerForDelegate(efl_exe_flags_set_static_delegate) });
            }

            if (efl_exe_exit_signal_get_static_delegate == null)
            {
                efl_exe_exit_signal_get_static_delegate = new efl_exe_exit_signal_get_delegate(exit_signal_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetExitSignal") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_exe_exit_signal_get"), func = Marshal.GetFunctionPointerForDelegate(efl_exe_exit_signal_get_static_delegate) });
            }

            if (efl_exe_env_get_static_delegate == null)
            {
                efl_exe_env_get_static_delegate = new efl_exe_env_get_delegate(env_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetEnv") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_exe_env_get"), func = Marshal.GetFunctionPointerForDelegate(efl_exe_env_get_static_delegate) });
            }

            if (efl_exe_env_set_static_delegate == null)
            {
                efl_exe_env_set_static_delegate = new efl_exe_env_set_delegate(env_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetEnv") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_exe_env_set"), func = Marshal.GetFunctionPointerForDelegate(efl_exe_env_set_static_delegate) });
            }

            if (efl_exe_signal_static_delegate == null)
            {
                efl_exe_signal_static_delegate = new efl_exe_signal_delegate(signal);
            }

            if (methods.FirstOrDefault(m => m.Name == "Signal") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_exe_signal"), func = Marshal.GetFunctionPointerForDelegate(efl_exe_signal_static_delegate) });
            }

            if (efl_io_reader_can_read_set_static_delegate == null)
            {
                efl_io_reader_can_read_set_static_delegate = new efl_io_reader_can_read_set_delegate(can_read_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetCanRead") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_io_reader_can_read_set"), func = Marshal.GetFunctionPointerForDelegate(efl_io_reader_can_read_set_static_delegate) });
            }

            if (efl_io_reader_eos_set_static_delegate == null)
            {
                efl_io_reader_eos_set_static_delegate = new efl_io_reader_eos_set_delegate(eos_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetEos") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_io_reader_eos_set"), func = Marshal.GetFunctionPointerForDelegate(efl_io_reader_eos_set_static_delegate) });
            }

            if (efl_io_writer_can_write_set_static_delegate == null)
            {
                efl_io_writer_can_write_set_static_delegate = new efl_io_writer_can_write_set_delegate(can_write_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetCanWrite") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_io_writer_can_write_set"), func = Marshal.GetFunctionPointerForDelegate(efl_io_writer_can_write_set_static_delegate) });
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
            descs.AddRange(base.GetEoOps(type, false));
            return descs;
        }

        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Exe.efl_exe_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate Efl.ExeFlags efl_exe_flags_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.ExeFlags efl_exe_flags_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_exe_flags_get_api_delegate> efl_exe_flags_get_ptr = new Efl.Eo.FunctionWrapper<efl_exe_flags_get_api_delegate>(Module, "efl_exe_flags_get");

        private static Efl.ExeFlags exe_flags_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_exe_flags_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                Efl.ExeFlags _ret_var = default(Efl.ExeFlags);
                try
                {
                    _ret_var = ((Exe)ws.Target).GetExeFlags();
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
                return efl_exe_flags_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_exe_flags_get_delegate efl_exe_flags_get_static_delegate;

        
        private delegate void efl_exe_flags_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.ExeFlags flags);

        
        public delegate void efl_exe_flags_set_api_delegate(System.IntPtr obj,  Efl.ExeFlags flags);

        public static Efl.Eo.FunctionWrapper<efl_exe_flags_set_api_delegate> efl_exe_flags_set_ptr = new Efl.Eo.FunctionWrapper<efl_exe_flags_set_api_delegate>(Module, "efl_exe_flags_set");

        private static void exe_flags_set(System.IntPtr obj, System.IntPtr pd, Efl.ExeFlags flags)
        {
            Eina.Log.Debug("function efl_exe_flags_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((Exe)ws.Target).SetExeFlags(flags);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_exe_flags_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), flags);
            }
        }

        private static efl_exe_flags_set_delegate efl_exe_flags_set_static_delegate;

        
        private delegate int efl_exe_exit_signal_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_exe_exit_signal_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_exe_exit_signal_get_api_delegate> efl_exe_exit_signal_get_ptr = new Efl.Eo.FunctionWrapper<efl_exe_exit_signal_get_api_delegate>(Module, "efl_exe_exit_signal_get");

        private static int exit_signal_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_exe_exit_signal_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                int _ret_var = default(int);
                try
                {
                    _ret_var = ((Exe)ws.Target).GetExitSignal();
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
                return efl_exe_exit_signal_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_exe_exit_signal_get_delegate efl_exe_exit_signal_get_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Core.Env efl_exe_env_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Core.Env efl_exe_env_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_exe_env_get_api_delegate> efl_exe_env_get_ptr = new Efl.Eo.FunctionWrapper<efl_exe_env_get_api_delegate>(Module, "efl_exe_env_get");

        private static Efl.Core.Env env_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_exe_env_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                Efl.Core.Env _ret_var = default(Efl.Core.Env);
                try
                {
                    _ret_var = ((Exe)ws.Target).GetEnv();
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
                return efl_exe_env_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_exe_env_get_delegate efl_exe_env_get_static_delegate;

        
        private delegate void efl_exe_env_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Core.Env env);

        
        public delegate void efl_exe_env_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Core.Env env);

        public static Efl.Eo.FunctionWrapper<efl_exe_env_set_api_delegate> efl_exe_env_set_ptr = new Efl.Eo.FunctionWrapper<efl_exe_env_set_api_delegate>(Module, "efl_exe_env_set");

        private static void env_set(System.IntPtr obj, System.IntPtr pd, Efl.Core.Env env)
        {
            Eina.Log.Debug("function efl_exe_env_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((Exe)ws.Target).SetEnv(env);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_exe_env_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), env);
            }
        }

        private static efl_exe_env_set_delegate efl_exe_env_set_static_delegate;

        
        private delegate void efl_exe_signal_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.ExeSignal sig);

        
        public delegate void efl_exe_signal_api_delegate(System.IntPtr obj,  Efl.ExeSignal sig);

        public static Efl.Eo.FunctionWrapper<efl_exe_signal_api_delegate> efl_exe_signal_ptr = new Efl.Eo.FunctionWrapper<efl_exe_signal_api_delegate>(Module, "efl_exe_signal");

        private static void signal(System.IntPtr obj, System.IntPtr pd, Efl.ExeSignal sig)
        {
            Eina.Log.Debug("function efl_exe_signal was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((Exe)ws.Target).Signal(sig);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_exe_signal_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), sig);
            }
        }

        private static efl_exe_signal_delegate efl_exe_signal_static_delegate;

        
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
                    ((Exe)ws.Target).SetCanRead(can_read);
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
                    ((Exe)ws.Target).SetEos(is_eos);
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
                    ((Exe)ws.Target).SetCanWrite(can_write);
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

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

#if EFL_BETA
#pragma warning disable CS1591
public static class EflExe_ExtensionMethods {
    public static Efl.BindableProperty<Efl.ExeFlags> ExeFlags<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Exe, T>magic = null) where T : Efl.Exe {
        return new Efl.BindableProperty<Efl.ExeFlags>("exe_flags", fac);
    }

    public static Efl.BindableProperty<Efl.Core.Env> Env<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Exe, T>magic = null) where T : Efl.Exe {
        return new Efl.BindableProperty<Efl.Core.Env>("env", fac);
    }

    public static Efl.BindableProperty<Eina.Array<Eina.Stringshare>> CommandArray<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Exe, T>magic = null) where T : Efl.Exe {
        return new Efl.BindableProperty<Eina.Array<Eina.Stringshare>>("command_array", fac);
    }

    public static Efl.BindableProperty<System.String> CommandString<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Exe, T>magic = null) where T : Efl.Exe {
        return new Efl.BindableProperty<System.String>("command_string", fac);
    }

    public static Efl.BindableProperty<bool> CloseOnExec<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Exe, T>magic = null) where T : Efl.Exe {
        return new Efl.BindableProperty<bool>("close_on_exec", fac);
    }

    public static Efl.BindableProperty<bool> CloseOnInvalidate<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Exe, T>magic = null) where T : Efl.Exe {
        return new Efl.BindableProperty<bool>("close_on_invalidate", fac);
    }

    public static Efl.BindableProperty<bool> CanRead<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Exe, T>magic = null) where T : Efl.Exe {
        return new Efl.BindableProperty<bool>("can_read", fac);
    }

    public static Efl.BindableProperty<bool> Eos<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Exe, T>magic = null) where T : Efl.Exe {
        return new Efl.BindableProperty<bool>("eos", fac);
    }

    public static Efl.BindableProperty<bool> CanWrite<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Exe, T>magic = null) where T : Efl.Exe {
        return new Efl.BindableProperty<bool>("can_write", fac);
    }

}
#pragma warning restore CS1591
#endif
namespace Efl {

/// <summary>Signal is a notification, a message sent by either operating system or some application to our program. Signals are a mechanism for one-way asynchronous notifications. A signal may be sent from the kernel to a process, from a process to another process, or from a process to itself. Signal typically alert a process to some event, such as a segmentation fault, or the user pressing Ctrl-C.</summary>
[Efl.Eo.BindingEntity]
public enum ExeSignal
{
/// <summary>Terminal interrupt.</summary>
Int = 0,
/// <summary>Terminal quit.</summary>
Quit = 1,
/// <summary>Termination.</summary>
Term = 2,
/// <summary>Kill(can&apos;t be caught or ignored).</summary>
Kill = 3,
/// <summary>Continue executing, if stopped.</summary>
Cont = 4,
/// <summary>Stop executing(can&apos;t be caught or ignored).</summary>
Stop = 5,
/// <summary>Hangup.</summary>
Hup = 6,
/// <summary>User defined signal 1.</summary>
Usr1 = 7,
/// <summary>User defined signal 2.</summary>
Usr2 = 8,
}
}

namespace Efl {

/// <summary>Flags to customize process behavior.</summary>
[Efl.Eo.BindingEntity]
public enum ExeFlags
{
/// <summary>No special flags.</summary>
None = 0,
/// <summary>Process will be executed in its own session.</summary>
GroupLeader = 1,
/// <summary>All console IO will be hidden.</summary>
HideIo = 4,
}
}

