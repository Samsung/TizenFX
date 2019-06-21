#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Io {

/// <summary>Generic In-memory queue of data to be used as I/O.
/// This class is to be used to receive temporary data using <see cref="Efl.Io.IWriter.Write"/> and hold it until someone calls <see cref="Efl.Io.IReader.Read"/> to consume it.
/// 
/// A fixed sized queue can be implemented by setting <see cref="Efl.Io.Queue.Limit"/> followed by <see cref="Efl.Io.Queue.Preallocate"/></summary>
[Efl.Io.Queue.NativeMethods]
public class Queue : Efl.Object, Efl.Io.ICloser, Efl.Io.IReader, Efl.Io.IWriter
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(Queue))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] internal static extern System.IntPtr
        efl_io_queue_class_get();
    /// <summary>Initializes a new instance of the <see cref="Queue"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public Queue(Efl.Object parent= null
            ) : base(efl_io_queue_class_get(), typeof(Queue), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Initializes a new instance of the <see cref="Queue"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="raw">The native pointer to be wrapped.</param>
    protected Queue(System.IntPtr raw) : base(raw)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Queue"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="managedType">The managed type of the public constructor that originated this call.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected Queue(IntPtr baseKlass, System.Type managedType, Efl.Object parent) : base(baseKlass, managedType, parent)
    {
    }

    /// <summary>The read-slice returned by <see cref="Efl.Io.Queue.GetSlice"/> may have changed.</summary>
    public event EventHandler SliceChangedEvt
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

                string key = "_EFL_IO_QUEUE_EVENT_SLICE_CHANGED";
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_IO_QUEUE_EVENT_SLICE_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    ///<summary>Method to raise event SliceChangedEvt.</summary>
    public void OnSliceChangedEvt(EventArgs e)
    {
        var key = "_EFL_IO_QUEUE_EVENT_SLICE_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
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
    /// <summary>Limit how big the buffer can grow.
    /// This affects both <see cref="Efl.Io.Queue.Preallocate"/> and how buffer grows when <see cref="Efl.Io.IWriter.Write"/> is called.
    /// 
    /// If you want a buffer of an exact size, always set the limit before any further calls that can expand it.</summary>
    /// <returns>Defines a maximum buffer size, or 0 to allow unlimited amount of bytes</returns>
    virtual public uint GetLimit() {
         var _ret_var = Efl.Io.Queue.NativeMethods.efl_io_queue_limit_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Constructor-only property to set buffer limit. 0 is unlimited</summary>
    /// <param name="size">Defines a maximum buffer size, or 0 to allow unlimited amount of bytes</param>
    virtual public void SetLimit(uint size) {
                                 Efl.Io.Queue.NativeMethods.efl_io_queue_limit_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),size);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>How many bytes are available for read</summary>
    /// <returns>Bytes available to read</returns>
    virtual public uint GetUsage() {
         var _ret_var = Efl.Io.Queue.NativeMethods.efl_io_queue_usage_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Gain temporary access to queue&apos;s internal read memory.
    /// The memory pointed to by slice may be changed by other methods of this class. The event &quot;slice,changed&quot; will be called in those situations.</summary>
    /// <returns>Slice of the current buffer, may be invalidated if <see cref="Efl.Io.IWriter.Write"/>, <see cref="Efl.Io.ICloser.Close"/> or <see cref="Efl.Io.IReader.Read"/> are called. It is the full slice available for reading.</returns>
    virtual public Eina.Slice GetSlice() {
         var _ret_var = Efl.Io.Queue.NativeMethods.efl_io_queue_slice_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Immediately pre-allocate a buffer of at least a given size.</summary>
    /// <param name="size">Amount of bytes to pre-allocate.</param>
    virtual public void Preallocate(uint size) {
                                 Efl.Io.Queue.NativeMethods.efl_io_queue_preallocate_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),size);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Discard the given number of bytes.
    /// This has the same effect as reading and discarding the given amount of bytes, without executing the actual copy.
    /// 
    /// It&apos;s often paired with <see cref="Efl.Io.Queue.GetSlice"/>, if users read the information from the slice and once they&apos;re done, that data must be discarded.
    /// 
    /// As an example, some protocols provide messages with a &quot;size&quot; header, in which case <see cref="Efl.Io.Queue.GetSlice"/> is used to peek into the available memory to see if there is a &quot;size&quot; and if the rest of the slice is the full payload. In that situation the slice may be handled by a processing function. When the function is complete the defined amount of data must be discarded -- with this function.</summary>
    /// <param name="amount">Bytes to discard</param>
    virtual public void Discard(uint amount) {
                                 Efl.Io.Queue.NativeMethods.efl_io_queue_discard_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),amount);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Clears the queue. Same as reading all data.
    /// This is equivalent to calling <see cref="Efl.Io.Queue.Discard"/> with <see cref="Efl.Io.Queue.GetUsage"/> amount of bytes.</summary>
    virtual public void Clear() {
         Efl.Io.Queue.NativeMethods.efl_io_queue_clear_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Mark this end-of-stream.
    /// That will set <see cref="Efl.Io.IReader.Eos"/> to <c>true</c> and forbid any further writes.
    /// 
    /// Unlike <see cref="Efl.Io.ICloser.Close"/>, this won&apos;t clear anything.</summary>
    virtual public void EosMark() {
         Efl.Io.Queue.NativeMethods.efl_io_queue_eos_mark_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
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
    /// <summary>Limit how big the buffer can grow.
    /// This affects both <see cref="Efl.Io.Queue.Preallocate"/> and how buffer grows when <see cref="Efl.Io.IWriter.Write"/> is called.
    /// 
    /// If you want a buffer of an exact size, always set the limit before any further calls that can expand it.</summary>
    /// <value>Defines a maximum buffer size, or 0 to allow unlimited amount of bytes</value>
    public uint Limit {
        get { return GetLimit(); }
        set { SetLimit(value); }
    }
    /// <summary>How many bytes are available for read</summary>
    /// <value>Bytes available to read</value>
    public uint Usage {
        get { return GetUsage(); }
    }
    /// <summary>Gain temporary access to queue&apos;s internal read memory.
    /// The memory pointed to by slice may be changed by other methods of this class. The event &quot;slice,changed&quot; will be called in those situations.</summary>
    /// <value>Slice of the current buffer, may be invalidated if <see cref="Efl.Io.IWriter.Write"/>, <see cref="Efl.Io.ICloser.Close"/> or <see cref="Efl.Io.IReader.Read"/> are called. It is the full slice available for reading.</value>
    public Eina.Slice Slice {
        get { return GetSlice(); }
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
        return Efl.Io.Queue.efl_io_queue_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Object.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Efl);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_io_queue_limit_get_static_delegate == null)
            {
                efl_io_queue_limit_get_static_delegate = new efl_io_queue_limit_get_delegate(limit_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetLimit") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_io_queue_limit_get"), func = Marshal.GetFunctionPointerForDelegate(efl_io_queue_limit_get_static_delegate) });
            }

            if (efl_io_queue_limit_set_static_delegate == null)
            {
                efl_io_queue_limit_set_static_delegate = new efl_io_queue_limit_set_delegate(limit_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetLimit") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_io_queue_limit_set"), func = Marshal.GetFunctionPointerForDelegate(efl_io_queue_limit_set_static_delegate) });
            }

            if (efl_io_queue_usage_get_static_delegate == null)
            {
                efl_io_queue_usage_get_static_delegate = new efl_io_queue_usage_get_delegate(usage_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetUsage") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_io_queue_usage_get"), func = Marshal.GetFunctionPointerForDelegate(efl_io_queue_usage_get_static_delegate) });
            }

            if (efl_io_queue_slice_get_static_delegate == null)
            {
                efl_io_queue_slice_get_static_delegate = new efl_io_queue_slice_get_delegate(slice_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetSlice") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_io_queue_slice_get"), func = Marshal.GetFunctionPointerForDelegate(efl_io_queue_slice_get_static_delegate) });
            }

            if (efl_io_queue_preallocate_static_delegate == null)
            {
                efl_io_queue_preallocate_static_delegate = new efl_io_queue_preallocate_delegate(preallocate);
            }

            if (methods.FirstOrDefault(m => m.Name == "Preallocate") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_io_queue_preallocate"), func = Marshal.GetFunctionPointerForDelegate(efl_io_queue_preallocate_static_delegate) });
            }

            if (efl_io_queue_discard_static_delegate == null)
            {
                efl_io_queue_discard_static_delegate = new efl_io_queue_discard_delegate(discard);
            }

            if (methods.FirstOrDefault(m => m.Name == "Discard") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_io_queue_discard"), func = Marshal.GetFunctionPointerForDelegate(efl_io_queue_discard_static_delegate) });
            }

            if (efl_io_queue_clear_static_delegate == null)
            {
                efl_io_queue_clear_static_delegate = new efl_io_queue_clear_delegate(clear);
            }

            if (methods.FirstOrDefault(m => m.Name == "Clear") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_io_queue_clear"), func = Marshal.GetFunctionPointerForDelegate(efl_io_queue_clear_static_delegate) });
            }

            if (efl_io_queue_eos_mark_static_delegate == null)
            {
                efl_io_queue_eos_mark_static_delegate = new efl_io_queue_eos_mark_delegate(eos_mark);
            }

            if (methods.FirstOrDefault(m => m.Name == "EosMark") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_io_queue_eos_mark"), func = Marshal.GetFunctionPointerForDelegate(efl_io_queue_eos_mark_static_delegate) });
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
            return Efl.Io.Queue.efl_io_queue_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate uint efl_io_queue_limit_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate uint efl_io_queue_limit_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_io_queue_limit_get_api_delegate> efl_io_queue_limit_get_ptr = new Efl.Eo.FunctionWrapper<efl_io_queue_limit_get_api_delegate>(Module, "efl_io_queue_limit_get");

        private static uint limit_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_io_queue_limit_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            uint _ret_var = default(uint);
                try
                {
                    _ret_var = ((Queue)ws.Target).GetLimit();
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
                return efl_io_queue_limit_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_io_queue_limit_get_delegate efl_io_queue_limit_get_static_delegate;

        
        private delegate void efl_io_queue_limit_set_delegate(System.IntPtr obj, System.IntPtr pd,  uint size);

        
        public delegate void efl_io_queue_limit_set_api_delegate(System.IntPtr obj,  uint size);

        public static Efl.Eo.FunctionWrapper<efl_io_queue_limit_set_api_delegate> efl_io_queue_limit_set_ptr = new Efl.Eo.FunctionWrapper<efl_io_queue_limit_set_api_delegate>(Module, "efl_io_queue_limit_set");

        private static void limit_set(System.IntPtr obj, System.IntPtr pd, uint size)
        {
            Eina.Log.Debug("function efl_io_queue_limit_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Queue)ws.Target).SetLimit(size);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_io_queue_limit_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), size);
            }
        }

        private static efl_io_queue_limit_set_delegate efl_io_queue_limit_set_static_delegate;

        
        private delegate uint efl_io_queue_usage_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate uint efl_io_queue_usage_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_io_queue_usage_get_api_delegate> efl_io_queue_usage_get_ptr = new Efl.Eo.FunctionWrapper<efl_io_queue_usage_get_api_delegate>(Module, "efl_io_queue_usage_get");

        private static uint usage_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_io_queue_usage_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            uint _ret_var = default(uint);
                try
                {
                    _ret_var = ((Queue)ws.Target).GetUsage();
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
                return efl_io_queue_usage_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_io_queue_usage_get_delegate efl_io_queue_usage_get_static_delegate;

        
        private delegate Eina.Slice efl_io_queue_slice_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Slice efl_io_queue_slice_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_io_queue_slice_get_api_delegate> efl_io_queue_slice_get_ptr = new Efl.Eo.FunctionWrapper<efl_io_queue_slice_get_api_delegate>(Module, "efl_io_queue_slice_get");

        private static Eina.Slice slice_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_io_queue_slice_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Slice _ret_var = default(Eina.Slice);
                try
                {
                    _ret_var = ((Queue)ws.Target).GetSlice();
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
                return efl_io_queue_slice_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_io_queue_slice_get_delegate efl_io_queue_slice_get_static_delegate;

        
        private delegate void efl_io_queue_preallocate_delegate(System.IntPtr obj, System.IntPtr pd,  uint size);

        
        public delegate void efl_io_queue_preallocate_api_delegate(System.IntPtr obj,  uint size);

        public static Efl.Eo.FunctionWrapper<efl_io_queue_preallocate_api_delegate> efl_io_queue_preallocate_ptr = new Efl.Eo.FunctionWrapper<efl_io_queue_preallocate_api_delegate>(Module, "efl_io_queue_preallocate");

        private static void preallocate(System.IntPtr obj, System.IntPtr pd, uint size)
        {
            Eina.Log.Debug("function efl_io_queue_preallocate was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Queue)ws.Target).Preallocate(size);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_io_queue_preallocate_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), size);
            }
        }

        private static efl_io_queue_preallocate_delegate efl_io_queue_preallocate_static_delegate;

        
        private delegate void efl_io_queue_discard_delegate(System.IntPtr obj, System.IntPtr pd,  uint amount);

        
        public delegate void efl_io_queue_discard_api_delegate(System.IntPtr obj,  uint amount);

        public static Efl.Eo.FunctionWrapper<efl_io_queue_discard_api_delegate> efl_io_queue_discard_ptr = new Efl.Eo.FunctionWrapper<efl_io_queue_discard_api_delegate>(Module, "efl_io_queue_discard");

        private static void discard(System.IntPtr obj, System.IntPtr pd, uint amount)
        {
            Eina.Log.Debug("function efl_io_queue_discard was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Queue)ws.Target).Discard(amount);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_io_queue_discard_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), amount);
            }
        }

        private static efl_io_queue_discard_delegate efl_io_queue_discard_static_delegate;

        
        private delegate void efl_io_queue_clear_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_io_queue_clear_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_io_queue_clear_api_delegate> efl_io_queue_clear_ptr = new Efl.Eo.FunctionWrapper<efl_io_queue_clear_api_delegate>(Module, "efl_io_queue_clear");

        private static void clear(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_io_queue_clear was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((Queue)ws.Target).Clear();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_io_queue_clear_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_io_queue_clear_delegate efl_io_queue_clear_static_delegate;

        
        private delegate void efl_io_queue_eos_mark_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_io_queue_eos_mark_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_io_queue_eos_mark_api_delegate> efl_io_queue_eos_mark_ptr = new Efl.Eo.FunctionWrapper<efl_io_queue_eos_mark_api_delegate>(Module, "efl_io_queue_eos_mark");

        private static void eos_mark(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_io_queue_eos_mark was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((Queue)ws.Target).EosMark();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_io_queue_eos_mark_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_io_queue_eos_mark_delegate efl_io_queue_eos_mark_static_delegate;

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
                    _ret_var = ((Queue)ws.Target).GetClosed();
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
                    _ret_var = ((Queue)ws.Target).GetCloseOnExec();
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
                    _ret_var = ((Queue)ws.Target).SetCloseOnExec(close_on_exec);
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
                    _ret_var = ((Queue)ws.Target).GetCloseOnInvalidate();
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
                    ((Queue)ws.Target).SetCloseOnInvalidate(close_on_invalidate);
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
                    _ret_var = ((Queue)ws.Target).Close();
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
                    _ret_var = ((Queue)ws.Target).GetCanRead();
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
                    ((Queue)ws.Target).SetCanRead(can_read);
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
                    _ret_var = ((Queue)ws.Target).GetEos();
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
                    ((Queue)ws.Target).SetEos(is_eos);
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
                    _ret_var = ((Queue)ws.Target).Read(ref rw_slice);
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
                    _ret_var = ((Queue)ws.Target).GetCanWrite();
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
                    ((Queue)ws.Target).SetCanWrite(can_write);
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
                    _ret_var = ((Queue)ws.Target).Write(ref slice, ref remaining);
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

}

