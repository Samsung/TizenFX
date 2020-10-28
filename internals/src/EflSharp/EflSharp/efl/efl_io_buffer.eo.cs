#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Io { 
/// <summary>Generic In-memory buffer of data to be used as I/O.
/// This class offers both input and output, which can be used at the same time since <see cref="Efl.Io.IReader.Read"/> and <see cref="Efl.Io.IWriter.Write"/> use different offsets/position internally.
/// 
/// One can get temporary direct access to internal buffer with <see cref="Efl.Io.Buffer.GetSlice"/> or steal the buffer with <see cref="Efl.Io.Buffer.BinbufSteal"/>.
/// 
/// A fixed sized buffer can be implemented by setting <see cref="Efl.Io.Buffer.Limit"/> followed by <see cref="Efl.Io.Buffer.Preallocate"/></summary>
[BufferNativeInherit]
public class Buffer : Efl.Object, Efl.Eo.IWrapper,Efl.Io.ICloser,Efl.Io.IPositioner,Efl.Io.IReader,Efl.Io.ISizer,Efl.Io.IWriter
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (Buffer))
                return Efl.Io.BufferNativeInherit.GetEflClassStatic();
            else
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
        }
    }
    [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] internal static extern System.IntPtr
        efl_io_buffer_class_get();
    ///<summary>Creates a new instance.</summary>
    ///<param name="parent">Parent instance.</param>
    public Buffer(Efl.Object parent= null
            ) :
        base(efl_io_buffer_class_get(), typeof(Buffer), parent)
    {
        FinishInstantiation();
    }
    ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    protected Buffer(System.IntPtr raw) : base(raw)
    {
                RegisterEventProxies();
    }
    ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    protected Buffer(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
    ///<summary>Verifies if the given object is equal to this one.</summary>
    public override bool Equals(object obj)
    {
        var other = obj as Efl.Object;
        if (other == null)
            return false;
        return this.NativeHandle == other.NativeHandle;
    }
    ///<summary>Gets the hash code for this object based on the native pointer it points to.</summary>
    public override int GetHashCode()
    {
        return this.NativeHandle.ToInt32();
    }
    ///<summary>Turns the native pointer into a string representation.</summary>
    public override String ToString()
    {
        return $"{this.GetType().Name}@[{this.NativeHandle.ToInt32():x}]";
    }
private static object PositionReadChangedEvtKey = new object();
    /// <summary>Notifies <see cref="Efl.Io.Buffer.PositionRead"/> changed</summary>
    public event EventHandler PositionReadChangedEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_IO_BUFFER_EVENT_POSITION_READ_CHANGED";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_PositionReadChangedEvt_delegate)) {
                    eventHandlers.AddHandler(PositionReadChangedEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_IO_BUFFER_EVENT_POSITION_READ_CHANGED";
                if (RemoveNativeEventHandler(key, this.evt_PositionReadChangedEvt_delegate)) { 
                    eventHandlers.RemoveHandler(PositionReadChangedEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event PositionReadChangedEvt.</summary>
    public void On_PositionReadChangedEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[PositionReadChangedEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_PositionReadChangedEvt_delegate;
    private void on_PositionReadChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_PositionReadChangedEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object PositionWriteChangedEvtKey = new object();
    /// <summary>Notifies <see cref="Efl.Io.Buffer.PositionWrite"/> changed</summary>
    public event EventHandler PositionWriteChangedEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_IO_BUFFER_EVENT_POSITION_WRITE_CHANGED";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_PositionWriteChangedEvt_delegate)) {
                    eventHandlers.AddHandler(PositionWriteChangedEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_IO_BUFFER_EVENT_POSITION_WRITE_CHANGED";
                if (RemoveNativeEventHandler(key, this.evt_PositionWriteChangedEvt_delegate)) { 
                    eventHandlers.RemoveHandler(PositionWriteChangedEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event PositionWriteChangedEvt.</summary>
    public void On_PositionWriteChangedEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[PositionWriteChangedEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_PositionWriteChangedEvt_delegate;
    private void on_PositionWriteChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_PositionWriteChangedEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object ReallocatedEvtKey = new object();
    /// <summary>Notifies the internal buffer was reallocated, thus whatever was returned by <see cref="Efl.Io.Buffer.GetSlice"/> becomes invalid</summary>
    public event EventHandler ReallocatedEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_IO_BUFFER_EVENT_REALLOCATED";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_ReallocatedEvt_delegate)) {
                    eventHandlers.AddHandler(ReallocatedEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_IO_BUFFER_EVENT_REALLOCATED";
                if (RemoveNativeEventHandler(key, this.evt_ReallocatedEvt_delegate)) { 
                    eventHandlers.RemoveHandler(ReallocatedEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event ReallocatedEvt.</summary>
    public void On_ReallocatedEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[ReallocatedEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_ReallocatedEvt_delegate;
    private void on_ReallocatedEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_ReallocatedEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object ClosedEvtKey = new object();
    /// <summary>Notifies closed, when property is marked as true
    /// (Since EFL 1.22)</summary>
    public event EventHandler ClosedEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_IO_CLOSER_EVENT_CLOSED";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_ClosedEvt_delegate)) {
                    eventHandlers.AddHandler(ClosedEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_IO_CLOSER_EVENT_CLOSED";
                if (RemoveNativeEventHandler(key, this.evt_ClosedEvt_delegate)) { 
                    eventHandlers.RemoveHandler(ClosedEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event ClosedEvt.</summary>
    public void On_ClosedEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[ClosedEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_ClosedEvt_delegate;
    private void on_ClosedEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_ClosedEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object PositionChangedEvtKey = new object();
    /// <summary>Notifies position changed</summary>
    public event EventHandler PositionChangedEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_IO_POSITIONER_EVENT_POSITION_CHANGED";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_PositionChangedEvt_delegate)) {
                    eventHandlers.AddHandler(PositionChangedEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_IO_POSITIONER_EVENT_POSITION_CHANGED";
                if (RemoveNativeEventHandler(key, this.evt_PositionChangedEvt_delegate)) { 
                    eventHandlers.RemoveHandler(PositionChangedEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event PositionChangedEvt.</summary>
    public void On_PositionChangedEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[PositionChangedEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_PositionChangedEvt_delegate;
    private void on_PositionChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_PositionChangedEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object CanReadChangedEvtKey = new object();
    /// <summary>Notifies can_read property changed.
    /// If <see cref="Efl.Io.IReader.CanRead"/> is <c>true</c> there is data to <see cref="Efl.Io.IReader.Read"/> without blocking/error. If <see cref="Efl.Io.IReader.CanRead"/> is <c>false</c>, <see cref="Efl.Io.IReader.Read"/> would either block or fail.
    /// 
    /// Note that usually this event is dispatched from inside <see cref="Efl.Io.IReader.Read"/>, thus before it returns.
    /// (Since EFL 1.22)</summary>
    public event EventHandler<Efl.Io.IReaderCanReadChangedEvt_Args> CanReadChangedEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_IO_READER_EVENT_CAN_READ_CHANGED";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_CanReadChangedEvt_delegate)) {
                    eventHandlers.AddHandler(CanReadChangedEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_IO_READER_EVENT_CAN_READ_CHANGED";
                if (RemoveNativeEventHandler(key, this.evt_CanReadChangedEvt_delegate)) { 
                    eventHandlers.RemoveHandler(CanReadChangedEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event CanReadChangedEvt.</summary>
    public void On_CanReadChangedEvt(Efl.Io.IReaderCanReadChangedEvt_Args e)
    {
        EventHandler<Efl.Io.IReaderCanReadChangedEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.Io.IReaderCanReadChangedEvt_Args>)eventHandlers[CanReadChangedEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_CanReadChangedEvt_delegate;
    private void on_CanReadChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.Io.IReaderCanReadChangedEvt_Args args = new Efl.Io.IReaderCanReadChangedEvt_Args();
      args.arg = evt.Info != IntPtr.Zero;
        try {
            On_CanReadChangedEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object EosEvtKey = new object();
    /// <summary>Notifies end of stream, when property is marked as true.
    /// If this is used alongside with an <see cref="Efl.Io.ICloser"/>, then it should be emitted before that call.
    /// 
    /// It should be emitted only once for an object unless it implements <see cref="Efl.Io.IPositioner.Seek"/>.
    /// 
    /// The property <see cref="Efl.Io.IReader.CanRead"/> should change to <c>false</c> before this event is dispatched.
    /// (Since EFL 1.22)</summary>
    public event EventHandler EosEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_IO_READER_EVENT_EOS";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_EosEvt_delegate)) {
                    eventHandlers.AddHandler(EosEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_IO_READER_EVENT_EOS";
                if (RemoveNativeEventHandler(key, this.evt_EosEvt_delegate)) { 
                    eventHandlers.RemoveHandler(EosEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event EosEvt.</summary>
    public void On_EosEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[EosEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_EosEvt_delegate;
    private void on_EosEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_EosEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object SizeChangedEvtKey = new object();
    /// <summary>Notifies size changed</summary>
    public event EventHandler SizeChangedEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_IO_SIZER_EVENT_SIZE_CHANGED";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_SizeChangedEvt_delegate)) {
                    eventHandlers.AddHandler(SizeChangedEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_IO_SIZER_EVENT_SIZE_CHANGED";
                if (RemoveNativeEventHandler(key, this.evt_SizeChangedEvt_delegate)) { 
                    eventHandlers.RemoveHandler(SizeChangedEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event SizeChangedEvt.</summary>
    public void On_SizeChangedEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[SizeChangedEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_SizeChangedEvt_delegate;
    private void on_SizeChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_SizeChangedEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object CanWriteChangedEvtKey = new object();
    /// <summary>Notifies can_write property changed.
    /// If <see cref="Efl.Io.IWriter.CanWrite"/> is <c>true</c> there is data to <see cref="Efl.Io.IWriter.Write"/> without blocking/error. If <see cref="Efl.Io.IWriter.CanWrite"/> is <c>false</c>, <see cref="Efl.Io.IWriter.Write"/> would either block or fail.
    /// 
    /// Note that usually this event is dispatched from inside <see cref="Efl.Io.IWriter.Write"/>, thus before it returns.
    /// (Since EFL 1.22)</summary>
    public event EventHandler<Efl.Io.IWriterCanWriteChangedEvt_Args> CanWriteChangedEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_IO_WRITER_EVENT_CAN_WRITE_CHANGED";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_CanWriteChangedEvt_delegate)) {
                    eventHandlers.AddHandler(CanWriteChangedEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_IO_WRITER_EVENT_CAN_WRITE_CHANGED";
                if (RemoveNativeEventHandler(key, this.evt_CanWriteChangedEvt_delegate)) { 
                    eventHandlers.RemoveHandler(CanWriteChangedEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event CanWriteChangedEvt.</summary>
    public void On_CanWriteChangedEvt(Efl.Io.IWriterCanWriteChangedEvt_Args e)
    {
        EventHandler<Efl.Io.IWriterCanWriteChangedEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.Io.IWriterCanWriteChangedEvt_Args>)eventHandlers[CanWriteChangedEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_CanWriteChangedEvt_delegate;
    private void on_CanWriteChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.Io.IWriterCanWriteChangedEvt_Args args = new Efl.Io.IWriterCanWriteChangedEvt_Args();
      args.arg = evt.Info != IntPtr.Zero;
        try {
            On_CanWriteChangedEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

    ///<summary>Register the Eo event wrappers making the bridge to C# events. Internal usage only.</summary>
    protected override void RegisterEventProxies()
    {
        base.RegisterEventProxies();
        evt_PositionReadChangedEvt_delegate = new Efl.EventCb(on_PositionReadChangedEvt_NativeCallback);
        evt_PositionWriteChangedEvt_delegate = new Efl.EventCb(on_PositionWriteChangedEvt_NativeCallback);
        evt_ReallocatedEvt_delegate = new Efl.EventCb(on_ReallocatedEvt_NativeCallback);
        evt_ClosedEvt_delegate = new Efl.EventCb(on_ClosedEvt_NativeCallback);
        evt_PositionChangedEvt_delegate = new Efl.EventCb(on_PositionChangedEvt_NativeCallback);
        evt_CanReadChangedEvt_delegate = new Efl.EventCb(on_CanReadChangedEvt_NativeCallback);
        evt_EosEvt_delegate = new Efl.EventCb(on_EosEvt_NativeCallback);
        evt_SizeChangedEvt_delegate = new Efl.EventCb(on_SizeChangedEvt_NativeCallback);
        evt_CanWriteChangedEvt_delegate = new Efl.EventCb(on_CanWriteChangedEvt_NativeCallback);
    }
    /// <summary>Limit how big the buffer can grow.
    /// This affects both <see cref="Efl.Io.Buffer.Preallocate"/> and how buffer grows when <see cref="Efl.Io.IWriter.Write"/> is called.
    /// 
    /// If you want a buffer of an exact size always set the limit before any further calls that can expand it.</summary>
    /// <returns>Defines a maximum buffer size, or 0 to allow unlimited amount of bytes</returns>
    virtual public uint GetLimit() {
         var _ret_var = Efl.Io.BufferNativeInherit.efl_io_buffer_limit_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Constructor-only property to set buffer limit. 0 is unlimited</summary>
    /// <param name="size">Defines a maximum buffer size, or 0 to allow unlimited amount of bytes</param>
    /// <returns></returns>
    virtual public void SetLimit( uint size) {
                                 Efl.Io.BufferNativeInherit.efl_io_buffer_limit_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), size);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The position used by <see cref="Efl.Io.IReader.Read"/>.
    /// Note that <see cref="Efl.Io.IPositioner.Seek"/> or <see cref="Efl.Io.IPositioner.SetPosition"/> will affect this property and <see cref="Efl.Io.Buffer.PositionWrite"/>.
    /// 
    /// <see cref="Efl.Io.IPositioner.GetPosition"/> will return the greatest of <see cref="Efl.Io.Buffer.PositionRead"/> and <see cref="Efl.Io.Buffer.PositionWrite"/>.</summary>
    /// <returns>Position in buffer</returns>
    virtual public ulong GetPositionRead() {
         var _ret_var = Efl.Io.BufferNativeInherit.efl_io_buffer_position_read_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The position used by <see cref="Efl.Io.IReader.Read"/>.
    /// Note that <see cref="Efl.Io.IPositioner.Seek"/> or <see cref="Efl.Io.IPositioner.SetPosition"/> will affect this property and <see cref="Efl.Io.Buffer.PositionWrite"/>.
    /// 
    /// <see cref="Efl.Io.IPositioner.GetPosition"/> will return the greatest of <see cref="Efl.Io.Buffer.PositionRead"/> and <see cref="Efl.Io.Buffer.PositionWrite"/>.</summary>
    /// <param name="position">Position in buffer</param>
    /// <returns><c>true</c> if setting the position succeeded, <c>false</c> otherwise</returns>
    virtual public bool SetPositionRead( ulong position) {
                                 var _ret_var = Efl.Io.BufferNativeInherit.efl_io_buffer_position_read_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), position);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>The position used by <see cref="Efl.Io.IWriter.Write"/>.
    /// Note that <see cref="Efl.Io.IPositioner.Seek"/> or <see cref="Efl.Io.IPositioner.SetPosition"/> will affect this property and <see cref="Efl.Io.Buffer.PositionRead"/>.
    /// 
    /// <see cref="Efl.Io.IPositioner.GetPosition"/> will return the greatest of <see cref="Efl.Io.Buffer.PositionRead"/> and <see cref="Efl.Io.Buffer.PositionWrite"/>.</summary>
    /// <returns>Position in buffer</returns>
    virtual public ulong GetPositionWrite() {
         var _ret_var = Efl.Io.BufferNativeInherit.efl_io_buffer_position_write_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The position used by <see cref="Efl.Io.IWriter.Write"/>.
    /// Note that <see cref="Efl.Io.IPositioner.Seek"/> or <see cref="Efl.Io.IPositioner.SetPosition"/> will affect this property and <see cref="Efl.Io.Buffer.PositionRead"/>.
    /// 
    /// <see cref="Efl.Io.IPositioner.GetPosition"/> will return the greatest of <see cref="Efl.Io.Buffer.PositionRead"/> and <see cref="Efl.Io.Buffer.PositionWrite"/>.</summary>
    /// <param name="position">Position in buffer</param>
    /// <returns><c>true</c> if setting the position succeeded, <c>false</c> otherwise</returns>
    virtual public bool SetPositionWrite( ulong position) {
                                 var _ret_var = Efl.Io.BufferNativeInherit.efl_io_buffer_position_write_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), position);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Get a temporary access to buffer&apos;s internal memory.
    /// The memory pointed by slice may be changed by other methods of this class. The event &quot;reallocated&quot; will be called in those situations.</summary>
    /// <returns>Slice of the current buffer, may be invalidated if <see cref="Efl.Io.IWriter.Write"/>, <see cref="Efl.Io.ICloser.Close"/> or <see cref="Efl.Io.ISizer.Resize"/> are called. It is the full slice, not a partial one starting at current position.</returns>
    virtual public Eina.Slice GetSlice() {
         var _ret_var = Efl.Io.BufferNativeInherit.efl_io_buffer_slice_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Immediately pre-allocate a buffer of at least a given size.</summary>
    /// <param name="size">Amount of bytes to pre-allocate.</param>
    /// <returns></returns>
    virtual public void Preallocate( uint size) {
                                 Efl.Io.BufferNativeInherit.efl_io_buffer_preallocate_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), size);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Adopt a read-only slice as buffer&apos;s backing store.
    /// The slice memory will not be copied and must remain alive during the buffer&apos;s lifetime. Usually this is guaranteed by some global static-const memory or some parent object and this buffer being a view of that -- be aware of parent memory remaining alive, such as &quot;slice,changed&quot; events.</summary>
    /// <param name="slice">Slice to adopt as read-only</param>
    /// <returns></returns>
    virtual public void AdoptReadonly( Eina.Slice slice) {
                                 Efl.Io.BufferNativeInherit.efl_io_buffer_adopt_readonly_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), slice);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Adopt a read-write slice as buffer&apos;s backing store.
    /// The slice memory will not be copied and must remain alive during the buffer&apos;s lifetime. Usually this is guaranteed by some global static memory or some parent object and this buffer being a view of that -- be aware of parent memory remaining alive, such as &quot;slice,changed&quot; events.
    /// 
    /// The memory will be disposed using free() and reallocated using realloc().</summary>
    /// <param name="slice">Slice to adopt as read-write</param>
    /// <returns></returns>
    virtual public void AdoptReadwrite( Eina.RwSlice slice) {
                                 Efl.Io.BufferNativeInherit.efl_io_buffer_adopt_readwrite_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), slice);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Steals the internal buffer memory and returns it as a binbuf.
    /// The returned memory must be freed with eina_binbuf_free().
    /// 
    /// On failure, for example a read-only backing store was adopted with <see cref="Efl.Io.Buffer.AdoptReadonly"/>, NULL is returned.</summary>
    /// <returns>Binbuf</returns>
    virtual public Eina.Binbuf BinbufSteal() {
         var _ret_var = Efl.Io.BufferNativeInherit.efl_io_buffer_binbuf_steal_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        var _binbuf_ret = new Eina.Binbuf(_ret_var, true);
        return _binbuf_ret;
 }
    /// <summary>If true will notify object was closed.
    /// (Since EFL 1.22)</summary>
    /// <returns><c>true</c> if closed, <c>false</c> otherwise</returns>
    virtual public bool GetClosed() {
         var _ret_var = Efl.Io.ICloserNativeInherit.efl_io_closer_closed_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>If true will automatically close resources on exec() calls.
    /// When using file descriptors this should set FD_CLOEXEC so they are not inherited by the processes (children or self) doing exec().
    /// (Since EFL 1.22)</summary>
    /// <returns><c>true</c> if close on exec(), <c>false</c> otherwise</returns>
    virtual public bool GetCloseOnExec() {
         var _ret_var = Efl.Io.ICloserNativeInherit.efl_io_closer_close_on_exec_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>If <c>true</c>, will close on exec() call.
    /// (Since EFL 1.22)</summary>
    /// <param name="close_on_exec"><c>true</c> if close on exec(), <c>false</c> otherwise</param>
    /// <returns><c>true</c> if could set, <c>false</c> if not supported or failed.</returns>
    virtual public bool SetCloseOnExec( bool close_on_exec) {
                                 var _ret_var = Efl.Io.ICloserNativeInherit.efl_io_closer_close_on_exec_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), close_on_exec);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>If true will automatically close() on object invalidate.
    /// If the object was disconnected from its parent (including the main loop) without close, this property will state whenever it should be closed or not.
    /// (Since EFL 1.22)</summary>
    /// <returns><c>true</c> if close on invalidate, <c>false</c> otherwise</returns>
    virtual public bool GetCloseOnInvalidate() {
         var _ret_var = Efl.Io.ICloserNativeInherit.efl_io_closer_close_on_invalidate_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>If true will automatically close() on object invalidate.
    /// If the object was disconnected from its parent (including the main loop) without close, this property will state whenever it should be closed or not.
    /// (Since EFL 1.22)</summary>
    /// <param name="close_on_invalidate"><c>true</c> if close on invalidate, <c>false</c> otherwise</param>
    /// <returns></returns>
    virtual public void SetCloseOnInvalidate( bool close_on_invalidate) {
                                 Efl.Io.ICloserNativeInherit.efl_io_closer_close_on_invalidate_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), close_on_invalidate);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Closes the Input/Output object.
    /// This operation will be executed immediately and may or may not block the caller thread for some time. The details of blocking behavior is to be defined by the implementation and may be subject to other parameters such as non-blocking flags, maximum timeout or even retry attempts.
    /// 
    /// You can understand this method as close(2) libc function.
    /// (Since EFL 1.22)</summary>
    /// <returns>0 on succeed, a mapping of errno otherwise</returns>
    virtual public Eina.Error Close() {
         var _ret_var = Efl.Io.ICloserNativeInherit.efl_io_closer_close_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Position property</summary>
    /// <returns>Position in file or buffer</returns>
    virtual public ulong GetPosition() {
         var _ret_var = Efl.Io.IPositionerNativeInherit.efl_io_positioner_position_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Try to set position object, relative to start of file. See <see cref="Efl.Io.IPositioner.Seek"/></summary>
    /// <param name="position">Position in file or buffer</param>
    /// <returns><c>true</c> if could reposition, <c>false</c> if errors.</returns>
    virtual public bool SetPosition( ulong position) {
                                 var _ret_var = Efl.Io.IPositionerNativeInherit.efl_io_positioner_position_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), position);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Seek in data</summary>
    /// <param name="offset">Offset in byte relative to whence</param>
    /// <param name="whence">Whence</param>
    /// <returns>0 on succeed, a mapping of errno otherwise</returns>
    virtual public Eina.Error Seek( long offset,  Efl.Io.PositionerWhence whence) {
                                                         var _ret_var = Efl.Io.IPositionerNativeInherit.efl_io_positioner_seek_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), offset,  whence);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>If <c>true</c> will notify <see cref="Efl.Io.IReader.Read"/> can be called without blocking or failing.
    /// (Since EFL 1.22)</summary>
    /// <returns><c>true</c> if it can be read without blocking or failing, <c>false</c> otherwise</returns>
    virtual public bool GetCanRead() {
         var _ret_var = Efl.Io.IReaderNativeInherit.efl_io_reader_can_read_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>If <c>true</c> will notify <see cref="Efl.Io.IReader.Read"/> can be called without blocking or failing.
    /// (Since EFL 1.22)</summary>
    /// <param name="can_read"><c>true</c> if it can be read without blocking or failing, <c>false</c> otherwise</param>
    /// <returns></returns>
    virtual public void SetCanRead( bool can_read) {
                                 Efl.Io.IReaderNativeInherit.efl_io_reader_can_read_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), can_read);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>If <c>true</c> will notify end of stream.
    /// (Since EFL 1.22)</summary>
    /// <returns><c>true</c> if end of stream, <c>false</c> otherwise</returns>
    virtual public bool GetEos() {
         var _ret_var = Efl.Io.IReaderNativeInherit.efl_io_reader_eos_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>If <c>true</c> will notify end of stream.
    /// (Since EFL 1.22)</summary>
    /// <param name="is_eos"><c>true</c> if end of stream, <c>false</c> otherwise</param>
    /// <returns></returns>
    virtual public void SetEos( bool is_eos) {
                                 Efl.Io.IReaderNativeInherit.efl_io_reader_eos_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), is_eos);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Reads data into a pre-allocated buffer.
    /// This operation will be executed immediately and may or may not block the caller thread for some time. The details of blocking behavior is to be defined by the implementation and may be subject to other parameters such as non-blocking flags, maximum timeout or even retry attempts.
    /// 
    /// You can understand this method as read(2) libc function.
    /// (Since EFL 1.22)</summary>
    /// <param name="rw_slice">Provides a pre-allocated memory to be filled up to rw_slice.len. It will be populated and the length will be set to the actually used amount of bytes, which can be smaller than the request.</param>
    /// <returns>0 on succeed, a mapping of errno otherwise</returns>
    virtual public Eina.Error Read( ref Eina.RwSlice rw_slice) {
                                 var _ret_var = Efl.Io.IReaderNativeInherit.efl_io_reader_read_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), ref rw_slice);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Size property</summary>
    /// <returns>Object size</returns>
    virtual public ulong GetSize() {
         var _ret_var = Efl.Io.ISizerNativeInherit.efl_io_sizer_size_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Try to resize the object, check with get if the value was accepted or not.</summary>
    /// <param name="size">Object size</param>
    /// <returns><c>true</c> if could resize, <c>false</c> if errors.</returns>
    virtual public bool SetSize( ulong size) {
                                 var _ret_var = Efl.Io.ISizerNativeInherit.efl_io_sizer_size_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), size);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Resize object</summary>
    /// <param name="size">Object size</param>
    /// <returns>0 on succeed, a mapping of errno otherwise</returns>
    virtual public Eina.Error Resize( ulong size) {
                                 var _ret_var = Efl.Io.ISizerNativeInherit.efl_io_sizer_resize_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), size);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>If <c>true</c> will notify <see cref="Efl.Io.IWriter.Write"/> can be called without blocking or failing.
    /// (Since EFL 1.22)</summary>
    /// <returns><c>true</c> if it can be written without blocking or failure, <c>false</c> otherwise</returns>
    virtual public bool GetCanWrite() {
         var _ret_var = Efl.Io.IWriterNativeInherit.efl_io_writer_can_write_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>If <c>true</c> will notify <see cref="Efl.Io.IWriter.Write"/> can be called without blocking or failing.
    /// (Since EFL 1.22)</summary>
    /// <param name="can_write"><c>true</c> if it can be written without blocking or failure, <c>false</c> otherwise</param>
    /// <returns></returns>
    virtual public void SetCanWrite( bool can_write) {
                                 Efl.Io.IWriterNativeInherit.efl_io_writer_can_write_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), can_write);
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
    virtual public Eina.Error Write( ref Eina.Slice slice,  ref Eina.Slice remaining) {
                                                         var _ret_var = Efl.Io.IWriterNativeInherit.efl_io_writer_write_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), ref slice,  ref remaining);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Limit how big the buffer can grow.
/// This affects both <see cref="Efl.Io.Buffer.Preallocate"/> and how buffer grows when <see cref="Efl.Io.IWriter.Write"/> is called.
/// 
/// If you want a buffer of an exact size always set the limit before any further calls that can expand it.</summary>
/// <value>Defines a maximum buffer size, or 0 to allow unlimited amount of bytes</value>
    public uint Limit {
        get { return GetLimit(); }
        set { SetLimit( value); }
    }
    /// <summary>The position used by <see cref="Efl.Io.IReader.Read"/>.
/// Note that <see cref="Efl.Io.IPositioner.Seek"/> or <see cref="Efl.Io.IPositioner.SetPosition"/> will affect this property and <see cref="Efl.Io.Buffer.PositionWrite"/>.
/// 
/// <see cref="Efl.Io.IPositioner.GetPosition"/> will return the greatest of <see cref="Efl.Io.Buffer.PositionRead"/> and <see cref="Efl.Io.Buffer.PositionWrite"/>.</summary>
/// <value>Position in buffer</value>
    public ulong PositionRead {
        get { return GetPositionRead(); }
        set { SetPositionRead( value); }
    }
    /// <summary>The position used by <see cref="Efl.Io.IWriter.Write"/>.
/// Note that <see cref="Efl.Io.IPositioner.Seek"/> or <see cref="Efl.Io.IPositioner.SetPosition"/> will affect this property and <see cref="Efl.Io.Buffer.PositionRead"/>.
/// 
/// <see cref="Efl.Io.IPositioner.GetPosition"/> will return the greatest of <see cref="Efl.Io.Buffer.PositionRead"/> and <see cref="Efl.Io.Buffer.PositionWrite"/>.</summary>
/// <value>Position in buffer</value>
    public ulong PositionWrite {
        get { return GetPositionWrite(); }
        set { SetPositionWrite( value); }
    }
    /// <summary>Get a temporary access to buffer&apos;s internal memory.
/// The memory pointed by slice may be changed by other methods of this class. The event &quot;reallocated&quot; will be called in those situations.</summary>
/// <value>Slice of the current buffer, may be invalidated if <see cref="Efl.Io.IWriter.Write"/>, <see cref="Efl.Io.ICloser.Close"/> or <see cref="Efl.Io.ISizer.Resize"/> are called. It is the full slice, not a partial one starting at current position.</value>
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
        set { SetCloseOnExec( value); }
    }
    /// <summary>If true will automatically close() on object invalidate.
/// If the object was disconnected from its parent (including the main loop) without close, this property will state whenever it should be closed or not.
/// (Since EFL 1.22)</summary>
/// <value><c>true</c> if close on invalidate, <c>false</c> otherwise</value>
    public bool CloseOnInvalidate {
        get { return GetCloseOnInvalidate(); }
        set { SetCloseOnInvalidate( value); }
    }
    /// <summary>Position property</summary>
/// <value>Position in file or buffer</value>
    public ulong Position {
        get { return GetPosition(); }
        set { SetPosition( value); }
    }
    /// <summary>If <c>true</c> will notify <see cref="Efl.Io.IReader.Read"/> can be called without blocking or failing.
/// (Since EFL 1.22)</summary>
/// <value><c>true</c> if it can be read without blocking or failing, <c>false</c> otherwise</value>
    public bool CanRead {
        get { return GetCanRead(); }
        set { SetCanRead( value); }
    }
    /// <summary>If <c>true</c> will notify end of stream.
/// (Since EFL 1.22)</summary>
/// <value><c>true</c> if end of stream, <c>false</c> otherwise</value>
    public bool Eos {
        get { return GetEos(); }
        set { SetEos( value); }
    }
    /// <summary>Size property</summary>
/// <value>Object size</value>
    public ulong Size {
        get { return GetSize(); }
        set { SetSize( value); }
    }
    /// <summary>If <c>true</c> will notify <see cref="Efl.Io.IWriter.Write"/> can be called without blocking or failing.
/// (Since EFL 1.22)</summary>
/// <value><c>true</c> if it can be written without blocking or failure, <c>false</c> otherwise</value>
    public bool CanWrite {
        get { return GetCanWrite(); }
        set { SetCanWrite( value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Io.Buffer.efl_io_buffer_class_get();
    }
}
public class BufferNativeInherit : Efl.ObjectNativeInherit{
    public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Efl);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
        if (efl_io_buffer_limit_get_static_delegate == null)
            efl_io_buffer_limit_get_static_delegate = new efl_io_buffer_limit_get_delegate(limit_get);
        if (methods.FirstOrDefault(m => m.Name == "GetLimit") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_io_buffer_limit_get"), func = Marshal.GetFunctionPointerForDelegate(efl_io_buffer_limit_get_static_delegate)});
        if (efl_io_buffer_limit_set_static_delegate == null)
            efl_io_buffer_limit_set_static_delegate = new efl_io_buffer_limit_set_delegate(limit_set);
        if (methods.FirstOrDefault(m => m.Name == "SetLimit") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_io_buffer_limit_set"), func = Marshal.GetFunctionPointerForDelegate(efl_io_buffer_limit_set_static_delegate)});
        if (efl_io_buffer_position_read_get_static_delegate == null)
            efl_io_buffer_position_read_get_static_delegate = new efl_io_buffer_position_read_get_delegate(position_read_get);
        if (methods.FirstOrDefault(m => m.Name == "GetPositionRead") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_io_buffer_position_read_get"), func = Marshal.GetFunctionPointerForDelegate(efl_io_buffer_position_read_get_static_delegate)});
        if (efl_io_buffer_position_read_set_static_delegate == null)
            efl_io_buffer_position_read_set_static_delegate = new efl_io_buffer_position_read_set_delegate(position_read_set);
        if (methods.FirstOrDefault(m => m.Name == "SetPositionRead") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_io_buffer_position_read_set"), func = Marshal.GetFunctionPointerForDelegate(efl_io_buffer_position_read_set_static_delegate)});
        if (efl_io_buffer_position_write_get_static_delegate == null)
            efl_io_buffer_position_write_get_static_delegate = new efl_io_buffer_position_write_get_delegate(position_write_get);
        if (methods.FirstOrDefault(m => m.Name == "GetPositionWrite") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_io_buffer_position_write_get"), func = Marshal.GetFunctionPointerForDelegate(efl_io_buffer_position_write_get_static_delegate)});
        if (efl_io_buffer_position_write_set_static_delegate == null)
            efl_io_buffer_position_write_set_static_delegate = new efl_io_buffer_position_write_set_delegate(position_write_set);
        if (methods.FirstOrDefault(m => m.Name == "SetPositionWrite") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_io_buffer_position_write_set"), func = Marshal.GetFunctionPointerForDelegate(efl_io_buffer_position_write_set_static_delegate)});
        if (efl_io_buffer_slice_get_static_delegate == null)
            efl_io_buffer_slice_get_static_delegate = new efl_io_buffer_slice_get_delegate(slice_get);
        if (methods.FirstOrDefault(m => m.Name == "GetSlice") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_io_buffer_slice_get"), func = Marshal.GetFunctionPointerForDelegate(efl_io_buffer_slice_get_static_delegate)});
        if (efl_io_buffer_preallocate_static_delegate == null)
            efl_io_buffer_preallocate_static_delegate = new efl_io_buffer_preallocate_delegate(preallocate);
        if (methods.FirstOrDefault(m => m.Name == "Preallocate") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_io_buffer_preallocate"), func = Marshal.GetFunctionPointerForDelegate(efl_io_buffer_preallocate_static_delegate)});
        if (efl_io_buffer_adopt_readonly_static_delegate == null)
            efl_io_buffer_adopt_readonly_static_delegate = new efl_io_buffer_adopt_readonly_delegate(adopt_readonly);
        if (methods.FirstOrDefault(m => m.Name == "AdoptReadonly") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_io_buffer_adopt_readonly"), func = Marshal.GetFunctionPointerForDelegate(efl_io_buffer_adopt_readonly_static_delegate)});
        if (efl_io_buffer_adopt_readwrite_static_delegate == null)
            efl_io_buffer_adopt_readwrite_static_delegate = new efl_io_buffer_adopt_readwrite_delegate(adopt_readwrite);
        if (methods.FirstOrDefault(m => m.Name == "AdoptReadwrite") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_io_buffer_adopt_readwrite"), func = Marshal.GetFunctionPointerForDelegate(efl_io_buffer_adopt_readwrite_static_delegate)});
        if (efl_io_buffer_binbuf_steal_static_delegate == null)
            efl_io_buffer_binbuf_steal_static_delegate = new efl_io_buffer_binbuf_steal_delegate(binbuf_steal);
        if (methods.FirstOrDefault(m => m.Name == "BinbufSteal") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_io_buffer_binbuf_steal"), func = Marshal.GetFunctionPointerForDelegate(efl_io_buffer_binbuf_steal_static_delegate)});
        if (efl_io_closer_closed_get_static_delegate == null)
            efl_io_closer_closed_get_static_delegate = new efl_io_closer_closed_get_delegate(closed_get);
        if (methods.FirstOrDefault(m => m.Name == "GetClosed") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_io_closer_closed_get"), func = Marshal.GetFunctionPointerForDelegate(efl_io_closer_closed_get_static_delegate)});
        if (efl_io_closer_close_on_exec_get_static_delegate == null)
            efl_io_closer_close_on_exec_get_static_delegate = new efl_io_closer_close_on_exec_get_delegate(close_on_exec_get);
        if (methods.FirstOrDefault(m => m.Name == "GetCloseOnExec") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_io_closer_close_on_exec_get"), func = Marshal.GetFunctionPointerForDelegate(efl_io_closer_close_on_exec_get_static_delegate)});
        if (efl_io_closer_close_on_exec_set_static_delegate == null)
            efl_io_closer_close_on_exec_set_static_delegate = new efl_io_closer_close_on_exec_set_delegate(close_on_exec_set);
        if (methods.FirstOrDefault(m => m.Name == "SetCloseOnExec") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_io_closer_close_on_exec_set"), func = Marshal.GetFunctionPointerForDelegate(efl_io_closer_close_on_exec_set_static_delegate)});
        if (efl_io_closer_close_on_invalidate_get_static_delegate == null)
            efl_io_closer_close_on_invalidate_get_static_delegate = new efl_io_closer_close_on_invalidate_get_delegate(close_on_invalidate_get);
        if (methods.FirstOrDefault(m => m.Name == "GetCloseOnInvalidate") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_io_closer_close_on_invalidate_get"), func = Marshal.GetFunctionPointerForDelegate(efl_io_closer_close_on_invalidate_get_static_delegate)});
        if (efl_io_closer_close_on_invalidate_set_static_delegate == null)
            efl_io_closer_close_on_invalidate_set_static_delegate = new efl_io_closer_close_on_invalidate_set_delegate(close_on_invalidate_set);
        if (methods.FirstOrDefault(m => m.Name == "SetCloseOnInvalidate") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_io_closer_close_on_invalidate_set"), func = Marshal.GetFunctionPointerForDelegate(efl_io_closer_close_on_invalidate_set_static_delegate)});
        if (efl_io_closer_close_static_delegate == null)
            efl_io_closer_close_static_delegate = new efl_io_closer_close_delegate(close);
        if (methods.FirstOrDefault(m => m.Name == "Close") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_io_closer_close"), func = Marshal.GetFunctionPointerForDelegate(efl_io_closer_close_static_delegate)});
        if (efl_io_positioner_position_get_static_delegate == null)
            efl_io_positioner_position_get_static_delegate = new efl_io_positioner_position_get_delegate(position_get);
        if (methods.FirstOrDefault(m => m.Name == "GetPosition") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_io_positioner_position_get"), func = Marshal.GetFunctionPointerForDelegate(efl_io_positioner_position_get_static_delegate)});
        if (efl_io_positioner_position_set_static_delegate == null)
            efl_io_positioner_position_set_static_delegate = new efl_io_positioner_position_set_delegate(position_set);
        if (methods.FirstOrDefault(m => m.Name == "SetPosition") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_io_positioner_position_set"), func = Marshal.GetFunctionPointerForDelegate(efl_io_positioner_position_set_static_delegate)});
        if (efl_io_positioner_seek_static_delegate == null)
            efl_io_positioner_seek_static_delegate = new efl_io_positioner_seek_delegate(seek);
        if (methods.FirstOrDefault(m => m.Name == "Seek") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_io_positioner_seek"), func = Marshal.GetFunctionPointerForDelegate(efl_io_positioner_seek_static_delegate)});
        if (efl_io_reader_can_read_get_static_delegate == null)
            efl_io_reader_can_read_get_static_delegate = new efl_io_reader_can_read_get_delegate(can_read_get);
        if (methods.FirstOrDefault(m => m.Name == "GetCanRead") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_io_reader_can_read_get"), func = Marshal.GetFunctionPointerForDelegate(efl_io_reader_can_read_get_static_delegate)});
        if (efl_io_reader_can_read_set_static_delegate == null)
            efl_io_reader_can_read_set_static_delegate = new efl_io_reader_can_read_set_delegate(can_read_set);
        if (methods.FirstOrDefault(m => m.Name == "SetCanRead") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_io_reader_can_read_set"), func = Marshal.GetFunctionPointerForDelegate(efl_io_reader_can_read_set_static_delegate)});
        if (efl_io_reader_eos_get_static_delegate == null)
            efl_io_reader_eos_get_static_delegate = new efl_io_reader_eos_get_delegate(eos_get);
        if (methods.FirstOrDefault(m => m.Name == "GetEos") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_io_reader_eos_get"), func = Marshal.GetFunctionPointerForDelegate(efl_io_reader_eos_get_static_delegate)});
        if (efl_io_reader_eos_set_static_delegate == null)
            efl_io_reader_eos_set_static_delegate = new efl_io_reader_eos_set_delegate(eos_set);
        if (methods.FirstOrDefault(m => m.Name == "SetEos") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_io_reader_eos_set"), func = Marshal.GetFunctionPointerForDelegate(efl_io_reader_eos_set_static_delegate)});
        if (efl_io_reader_read_static_delegate == null)
            efl_io_reader_read_static_delegate = new efl_io_reader_read_delegate(read);
        if (methods.FirstOrDefault(m => m.Name == "Read") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_io_reader_read"), func = Marshal.GetFunctionPointerForDelegate(efl_io_reader_read_static_delegate)});
        if (efl_io_sizer_size_get_static_delegate == null)
            efl_io_sizer_size_get_static_delegate = new efl_io_sizer_size_get_delegate(size_get);
        if (methods.FirstOrDefault(m => m.Name == "GetSize") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_io_sizer_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_io_sizer_size_get_static_delegate)});
        if (efl_io_sizer_size_set_static_delegate == null)
            efl_io_sizer_size_set_static_delegate = new efl_io_sizer_size_set_delegate(size_set);
        if (methods.FirstOrDefault(m => m.Name == "SetSize") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_io_sizer_size_set"), func = Marshal.GetFunctionPointerForDelegate(efl_io_sizer_size_set_static_delegate)});
        if (efl_io_sizer_resize_static_delegate == null)
            efl_io_sizer_resize_static_delegate = new efl_io_sizer_resize_delegate(resize);
        if (methods.FirstOrDefault(m => m.Name == "Resize") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_io_sizer_resize"), func = Marshal.GetFunctionPointerForDelegate(efl_io_sizer_resize_static_delegate)});
        if (efl_io_writer_can_write_get_static_delegate == null)
            efl_io_writer_can_write_get_static_delegate = new efl_io_writer_can_write_get_delegate(can_write_get);
        if (methods.FirstOrDefault(m => m.Name == "GetCanWrite") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_io_writer_can_write_get"), func = Marshal.GetFunctionPointerForDelegate(efl_io_writer_can_write_get_static_delegate)});
        if (efl_io_writer_can_write_set_static_delegate == null)
            efl_io_writer_can_write_set_static_delegate = new efl_io_writer_can_write_set_delegate(can_write_set);
        if (methods.FirstOrDefault(m => m.Name == "SetCanWrite") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_io_writer_can_write_set"), func = Marshal.GetFunctionPointerForDelegate(efl_io_writer_can_write_set_static_delegate)});
        if (efl_io_writer_write_static_delegate == null)
            efl_io_writer_write_static_delegate = new efl_io_writer_write_delegate(write);
        if (methods.FirstOrDefault(m => m.Name == "Write") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_io_writer_write"), func = Marshal.GetFunctionPointerForDelegate(efl_io_writer_write_static_delegate)});
        descs.AddRange(base.GetEoOps(type));
        return descs;
    }
    public override IntPtr GetEflClass()
    {
        return Efl.Io.Buffer.efl_io_buffer_class_get();
    }
    public static new  IntPtr GetEflClassStatic()
    {
        return Efl.Io.Buffer.efl_io_buffer_class_get();
    }


     private delegate uint efl_io_buffer_limit_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate uint efl_io_buffer_limit_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_io_buffer_limit_get_api_delegate> efl_io_buffer_limit_get_ptr = new Efl.Eo.FunctionWrapper<efl_io_buffer_limit_get_api_delegate>(_Module, "efl_io_buffer_limit_get");
     private static uint limit_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_io_buffer_limit_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        uint _ret_var = default(uint);
            try {
                _ret_var = ((Buffer)wrapper).GetLimit();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_io_buffer_limit_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_io_buffer_limit_get_delegate efl_io_buffer_limit_get_static_delegate;


     private delegate void efl_io_buffer_limit_set_delegate(System.IntPtr obj, System.IntPtr pd,   uint size);


     public delegate void efl_io_buffer_limit_set_api_delegate(System.IntPtr obj,   uint size);
     public static Efl.Eo.FunctionWrapper<efl_io_buffer_limit_set_api_delegate> efl_io_buffer_limit_set_ptr = new Efl.Eo.FunctionWrapper<efl_io_buffer_limit_set_api_delegate>(_Module, "efl_io_buffer_limit_set");
     private static void limit_set(System.IntPtr obj, System.IntPtr pd,  uint size)
    {
        Eina.Log.Debug("function efl_io_buffer_limit_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((Buffer)wrapper).SetLimit( size);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_io_buffer_limit_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  size);
        }
    }
    private static efl_io_buffer_limit_set_delegate efl_io_buffer_limit_set_static_delegate;


     private delegate ulong efl_io_buffer_position_read_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate ulong efl_io_buffer_position_read_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_io_buffer_position_read_get_api_delegate> efl_io_buffer_position_read_get_ptr = new Efl.Eo.FunctionWrapper<efl_io_buffer_position_read_get_api_delegate>(_Module, "efl_io_buffer_position_read_get");
     private static ulong position_read_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_io_buffer_position_read_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        ulong _ret_var = default(ulong);
            try {
                _ret_var = ((Buffer)wrapper).GetPositionRead();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_io_buffer_position_read_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_io_buffer_position_read_get_delegate efl_io_buffer_position_read_get_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_io_buffer_position_read_set_delegate(System.IntPtr obj, System.IntPtr pd,   ulong position);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_io_buffer_position_read_set_api_delegate(System.IntPtr obj,   ulong position);
     public static Efl.Eo.FunctionWrapper<efl_io_buffer_position_read_set_api_delegate> efl_io_buffer_position_read_set_ptr = new Efl.Eo.FunctionWrapper<efl_io_buffer_position_read_set_api_delegate>(_Module, "efl_io_buffer_position_read_set");
     private static bool position_read_set(System.IntPtr obj, System.IntPtr pd,  ulong position)
    {
        Eina.Log.Debug("function efl_io_buffer_position_read_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                bool _ret_var = default(bool);
            try {
                _ret_var = ((Buffer)wrapper).SetPositionRead( position);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                        return _ret_var;
        } else {
            return efl_io_buffer_position_read_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  position);
        }
    }
    private static efl_io_buffer_position_read_set_delegate efl_io_buffer_position_read_set_static_delegate;


     private delegate ulong efl_io_buffer_position_write_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate ulong efl_io_buffer_position_write_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_io_buffer_position_write_get_api_delegate> efl_io_buffer_position_write_get_ptr = new Efl.Eo.FunctionWrapper<efl_io_buffer_position_write_get_api_delegate>(_Module, "efl_io_buffer_position_write_get");
     private static ulong position_write_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_io_buffer_position_write_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        ulong _ret_var = default(ulong);
            try {
                _ret_var = ((Buffer)wrapper).GetPositionWrite();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_io_buffer_position_write_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_io_buffer_position_write_get_delegate efl_io_buffer_position_write_get_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_io_buffer_position_write_set_delegate(System.IntPtr obj, System.IntPtr pd,   ulong position);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_io_buffer_position_write_set_api_delegate(System.IntPtr obj,   ulong position);
     public static Efl.Eo.FunctionWrapper<efl_io_buffer_position_write_set_api_delegate> efl_io_buffer_position_write_set_ptr = new Efl.Eo.FunctionWrapper<efl_io_buffer_position_write_set_api_delegate>(_Module, "efl_io_buffer_position_write_set");
     private static bool position_write_set(System.IntPtr obj, System.IntPtr pd,  ulong position)
    {
        Eina.Log.Debug("function efl_io_buffer_position_write_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                bool _ret_var = default(bool);
            try {
                _ret_var = ((Buffer)wrapper).SetPositionWrite( position);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                        return _ret_var;
        } else {
            return efl_io_buffer_position_write_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  position);
        }
    }
    private static efl_io_buffer_position_write_set_delegate efl_io_buffer_position_write_set_static_delegate;


     private delegate Eina.Slice efl_io_buffer_slice_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate Eina.Slice efl_io_buffer_slice_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_io_buffer_slice_get_api_delegate> efl_io_buffer_slice_get_ptr = new Efl.Eo.FunctionWrapper<efl_io_buffer_slice_get_api_delegate>(_Module, "efl_io_buffer_slice_get");
     private static Eina.Slice slice_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_io_buffer_slice_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Eina.Slice _ret_var = default(Eina.Slice);
            try {
                _ret_var = ((Buffer)wrapper).GetSlice();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_io_buffer_slice_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_io_buffer_slice_get_delegate efl_io_buffer_slice_get_static_delegate;


     private delegate void efl_io_buffer_preallocate_delegate(System.IntPtr obj, System.IntPtr pd,   uint size);


     public delegate void efl_io_buffer_preallocate_api_delegate(System.IntPtr obj,   uint size);
     public static Efl.Eo.FunctionWrapper<efl_io_buffer_preallocate_api_delegate> efl_io_buffer_preallocate_ptr = new Efl.Eo.FunctionWrapper<efl_io_buffer_preallocate_api_delegate>(_Module, "efl_io_buffer_preallocate");
     private static void preallocate(System.IntPtr obj, System.IntPtr pd,  uint size)
    {
        Eina.Log.Debug("function efl_io_buffer_preallocate was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((Buffer)wrapper).Preallocate( size);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_io_buffer_preallocate_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  size);
        }
    }
    private static efl_io_buffer_preallocate_delegate efl_io_buffer_preallocate_static_delegate;


     private delegate void efl_io_buffer_adopt_readonly_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Slice slice);


     public delegate void efl_io_buffer_adopt_readonly_api_delegate(System.IntPtr obj,   Eina.Slice slice);
     public static Efl.Eo.FunctionWrapper<efl_io_buffer_adopt_readonly_api_delegate> efl_io_buffer_adopt_readonly_ptr = new Efl.Eo.FunctionWrapper<efl_io_buffer_adopt_readonly_api_delegate>(_Module, "efl_io_buffer_adopt_readonly");
     private static void adopt_readonly(System.IntPtr obj, System.IntPtr pd,  Eina.Slice slice)
    {
        Eina.Log.Debug("function efl_io_buffer_adopt_readonly was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((Buffer)wrapper).AdoptReadonly( slice);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_io_buffer_adopt_readonly_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  slice);
        }
    }
    private static efl_io_buffer_adopt_readonly_delegate efl_io_buffer_adopt_readonly_static_delegate;


     private delegate void efl_io_buffer_adopt_readwrite_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.RwSlice slice);


     public delegate void efl_io_buffer_adopt_readwrite_api_delegate(System.IntPtr obj,   Eina.RwSlice slice);
     public static Efl.Eo.FunctionWrapper<efl_io_buffer_adopt_readwrite_api_delegate> efl_io_buffer_adopt_readwrite_ptr = new Efl.Eo.FunctionWrapper<efl_io_buffer_adopt_readwrite_api_delegate>(_Module, "efl_io_buffer_adopt_readwrite");
     private static void adopt_readwrite(System.IntPtr obj, System.IntPtr pd,  Eina.RwSlice slice)
    {
        Eina.Log.Debug("function efl_io_buffer_adopt_readwrite was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((Buffer)wrapper).AdoptReadwrite( slice);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_io_buffer_adopt_readwrite_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  slice);
        }
    }
    private static efl_io_buffer_adopt_readwrite_delegate efl_io_buffer_adopt_readwrite_static_delegate;


     private delegate System.IntPtr efl_io_buffer_binbuf_steal_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate System.IntPtr efl_io_buffer_binbuf_steal_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_io_buffer_binbuf_steal_api_delegate> efl_io_buffer_binbuf_steal_ptr = new Efl.Eo.FunctionWrapper<efl_io_buffer_binbuf_steal_api_delegate>(_Module, "efl_io_buffer_binbuf_steal");
     private static System.IntPtr binbuf_steal(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_io_buffer_binbuf_steal was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Eina.Binbuf _ret_var = default(Eina.Binbuf);
            try {
                _ret_var = ((Buffer)wrapper).BinbufSteal();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        _ret_var.Own = false; return _ret_var.Handle;
        } else {
            return efl_io_buffer_binbuf_steal_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_io_buffer_binbuf_steal_delegate efl_io_buffer_binbuf_steal_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_io_closer_closed_get_delegate(System.IntPtr obj, System.IntPtr pd);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_io_closer_closed_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_io_closer_closed_get_api_delegate> efl_io_closer_closed_get_ptr = new Efl.Eo.FunctionWrapper<efl_io_closer_closed_get_api_delegate>(_Module, "efl_io_closer_closed_get");
     private static bool closed_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_io_closer_closed_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        bool _ret_var = default(bool);
            try {
                _ret_var = ((Buffer)wrapper).GetClosed();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_io_closer_closed_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_io_closer_closed_get_delegate efl_io_closer_closed_get_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_io_closer_close_on_exec_get_delegate(System.IntPtr obj, System.IntPtr pd);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_io_closer_close_on_exec_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_io_closer_close_on_exec_get_api_delegate> efl_io_closer_close_on_exec_get_ptr = new Efl.Eo.FunctionWrapper<efl_io_closer_close_on_exec_get_api_delegate>(_Module, "efl_io_closer_close_on_exec_get");
     private static bool close_on_exec_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_io_closer_close_on_exec_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        bool _ret_var = default(bool);
            try {
                _ret_var = ((Buffer)wrapper).GetCloseOnExec();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_io_closer_close_on_exec_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_io_closer_close_on_exec_get_delegate efl_io_closer_close_on_exec_get_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_io_closer_close_on_exec_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool close_on_exec);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_io_closer_close_on_exec_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool close_on_exec);
     public static Efl.Eo.FunctionWrapper<efl_io_closer_close_on_exec_set_api_delegate> efl_io_closer_close_on_exec_set_ptr = new Efl.Eo.FunctionWrapper<efl_io_closer_close_on_exec_set_api_delegate>(_Module, "efl_io_closer_close_on_exec_set");
     private static bool close_on_exec_set(System.IntPtr obj, System.IntPtr pd,  bool close_on_exec)
    {
        Eina.Log.Debug("function efl_io_closer_close_on_exec_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                bool _ret_var = default(bool);
            try {
                _ret_var = ((Buffer)wrapper).SetCloseOnExec( close_on_exec);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                        return _ret_var;
        } else {
            return efl_io_closer_close_on_exec_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  close_on_exec);
        }
    }
    private static efl_io_closer_close_on_exec_set_delegate efl_io_closer_close_on_exec_set_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_io_closer_close_on_invalidate_get_delegate(System.IntPtr obj, System.IntPtr pd);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_io_closer_close_on_invalidate_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_io_closer_close_on_invalidate_get_api_delegate> efl_io_closer_close_on_invalidate_get_ptr = new Efl.Eo.FunctionWrapper<efl_io_closer_close_on_invalidate_get_api_delegate>(_Module, "efl_io_closer_close_on_invalidate_get");
     private static bool close_on_invalidate_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_io_closer_close_on_invalidate_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        bool _ret_var = default(bool);
            try {
                _ret_var = ((Buffer)wrapper).GetCloseOnInvalidate();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_io_closer_close_on_invalidate_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_io_closer_close_on_invalidate_get_delegate efl_io_closer_close_on_invalidate_get_static_delegate;


     private delegate void efl_io_closer_close_on_invalidate_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool close_on_invalidate);


     public delegate void efl_io_closer_close_on_invalidate_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool close_on_invalidate);
     public static Efl.Eo.FunctionWrapper<efl_io_closer_close_on_invalidate_set_api_delegate> efl_io_closer_close_on_invalidate_set_ptr = new Efl.Eo.FunctionWrapper<efl_io_closer_close_on_invalidate_set_api_delegate>(_Module, "efl_io_closer_close_on_invalidate_set");
     private static void close_on_invalidate_set(System.IntPtr obj, System.IntPtr pd,  bool close_on_invalidate)
    {
        Eina.Log.Debug("function efl_io_closer_close_on_invalidate_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((Buffer)wrapper).SetCloseOnInvalidate( close_on_invalidate);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_io_closer_close_on_invalidate_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  close_on_invalidate);
        }
    }
    private static efl_io_closer_close_on_invalidate_set_delegate efl_io_closer_close_on_invalidate_set_static_delegate;


     private delegate Eina.Error efl_io_closer_close_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate Eina.Error efl_io_closer_close_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_io_closer_close_api_delegate> efl_io_closer_close_ptr = new Efl.Eo.FunctionWrapper<efl_io_closer_close_api_delegate>(_Module, "efl_io_closer_close");
     private static Eina.Error close(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_io_closer_close was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Eina.Error _ret_var = default(Eina.Error);
            try {
                _ret_var = ((Buffer)wrapper).Close();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_io_closer_close_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_io_closer_close_delegate efl_io_closer_close_static_delegate;


     private delegate ulong efl_io_positioner_position_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate ulong efl_io_positioner_position_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_io_positioner_position_get_api_delegate> efl_io_positioner_position_get_ptr = new Efl.Eo.FunctionWrapper<efl_io_positioner_position_get_api_delegate>(_Module, "efl_io_positioner_position_get");
     private static ulong position_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_io_positioner_position_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        ulong _ret_var = default(ulong);
            try {
                _ret_var = ((Buffer)wrapper).GetPosition();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_io_positioner_position_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_io_positioner_position_get_delegate efl_io_positioner_position_get_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_io_positioner_position_set_delegate(System.IntPtr obj, System.IntPtr pd,   ulong position);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_io_positioner_position_set_api_delegate(System.IntPtr obj,   ulong position);
     public static Efl.Eo.FunctionWrapper<efl_io_positioner_position_set_api_delegate> efl_io_positioner_position_set_ptr = new Efl.Eo.FunctionWrapper<efl_io_positioner_position_set_api_delegate>(_Module, "efl_io_positioner_position_set");
     private static bool position_set(System.IntPtr obj, System.IntPtr pd,  ulong position)
    {
        Eina.Log.Debug("function efl_io_positioner_position_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                bool _ret_var = default(bool);
            try {
                _ret_var = ((Buffer)wrapper).SetPosition( position);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                        return _ret_var;
        } else {
            return efl_io_positioner_position_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  position);
        }
    }
    private static efl_io_positioner_position_set_delegate efl_io_positioner_position_set_static_delegate;


     private delegate Eina.Error efl_io_positioner_seek_delegate(System.IntPtr obj, System.IntPtr pd,   long offset,   Efl.Io.PositionerWhence whence);


     public delegate Eina.Error efl_io_positioner_seek_api_delegate(System.IntPtr obj,   long offset,   Efl.Io.PositionerWhence whence);
     public static Efl.Eo.FunctionWrapper<efl_io_positioner_seek_api_delegate> efl_io_positioner_seek_ptr = new Efl.Eo.FunctionWrapper<efl_io_positioner_seek_api_delegate>(_Module, "efl_io_positioner_seek");
     private static Eina.Error seek(System.IntPtr obj, System.IntPtr pd,  long offset,  Efl.Io.PositionerWhence whence)
    {
        Eina.Log.Debug("function efl_io_positioner_seek was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                        Eina.Error _ret_var = default(Eina.Error);
            try {
                _ret_var = ((Buffer)wrapper).Seek( offset,  whence);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                        return _ret_var;
        } else {
            return efl_io_positioner_seek_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  offset,  whence);
        }
    }
    private static efl_io_positioner_seek_delegate efl_io_positioner_seek_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_io_reader_can_read_get_delegate(System.IntPtr obj, System.IntPtr pd);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_io_reader_can_read_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_io_reader_can_read_get_api_delegate> efl_io_reader_can_read_get_ptr = new Efl.Eo.FunctionWrapper<efl_io_reader_can_read_get_api_delegate>(_Module, "efl_io_reader_can_read_get");
     private static bool can_read_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_io_reader_can_read_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        bool _ret_var = default(bool);
            try {
                _ret_var = ((Buffer)wrapper).GetCanRead();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_io_reader_can_read_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_io_reader_can_read_get_delegate efl_io_reader_can_read_get_static_delegate;


     private delegate void efl_io_reader_can_read_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool can_read);


     public delegate void efl_io_reader_can_read_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool can_read);
     public static Efl.Eo.FunctionWrapper<efl_io_reader_can_read_set_api_delegate> efl_io_reader_can_read_set_ptr = new Efl.Eo.FunctionWrapper<efl_io_reader_can_read_set_api_delegate>(_Module, "efl_io_reader_can_read_set");
     private static void can_read_set(System.IntPtr obj, System.IntPtr pd,  bool can_read)
    {
        Eina.Log.Debug("function efl_io_reader_can_read_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((Buffer)wrapper).SetCanRead( can_read);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_io_reader_can_read_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  can_read);
        }
    }
    private static efl_io_reader_can_read_set_delegate efl_io_reader_can_read_set_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_io_reader_eos_get_delegate(System.IntPtr obj, System.IntPtr pd);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_io_reader_eos_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_io_reader_eos_get_api_delegate> efl_io_reader_eos_get_ptr = new Efl.Eo.FunctionWrapper<efl_io_reader_eos_get_api_delegate>(_Module, "efl_io_reader_eos_get");
     private static bool eos_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_io_reader_eos_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        bool _ret_var = default(bool);
            try {
                _ret_var = ((Buffer)wrapper).GetEos();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_io_reader_eos_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_io_reader_eos_get_delegate efl_io_reader_eos_get_static_delegate;


     private delegate void efl_io_reader_eos_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool is_eos);


     public delegate void efl_io_reader_eos_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool is_eos);
     public static Efl.Eo.FunctionWrapper<efl_io_reader_eos_set_api_delegate> efl_io_reader_eos_set_ptr = new Efl.Eo.FunctionWrapper<efl_io_reader_eos_set_api_delegate>(_Module, "efl_io_reader_eos_set");
     private static void eos_set(System.IntPtr obj, System.IntPtr pd,  bool is_eos)
    {
        Eina.Log.Debug("function efl_io_reader_eos_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((Buffer)wrapper).SetEos( is_eos);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_io_reader_eos_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  is_eos);
        }
    }
    private static efl_io_reader_eos_set_delegate efl_io_reader_eos_set_static_delegate;


     private delegate Eina.Error efl_io_reader_read_delegate(System.IntPtr obj, System.IntPtr pd,   ref Eina.RwSlice rw_slice);


     public delegate Eina.Error efl_io_reader_read_api_delegate(System.IntPtr obj,   ref Eina.RwSlice rw_slice);
     public static Efl.Eo.FunctionWrapper<efl_io_reader_read_api_delegate> efl_io_reader_read_ptr = new Efl.Eo.FunctionWrapper<efl_io_reader_read_api_delegate>(_Module, "efl_io_reader_read");
     private static Eina.Error read(System.IntPtr obj, System.IntPtr pd,  ref Eina.RwSlice rw_slice)
    {
        Eina.Log.Debug("function efl_io_reader_read was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                Eina.Error _ret_var = default(Eina.Error);
            try {
                _ret_var = ((Buffer)wrapper).Read( ref rw_slice);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                        return _ret_var;
        } else {
            return efl_io_reader_read_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  ref rw_slice);
        }
    }
    private static efl_io_reader_read_delegate efl_io_reader_read_static_delegate;


     private delegate ulong efl_io_sizer_size_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate ulong efl_io_sizer_size_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_io_sizer_size_get_api_delegate> efl_io_sizer_size_get_ptr = new Efl.Eo.FunctionWrapper<efl_io_sizer_size_get_api_delegate>(_Module, "efl_io_sizer_size_get");
     private static ulong size_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_io_sizer_size_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        ulong _ret_var = default(ulong);
            try {
                _ret_var = ((Buffer)wrapper).GetSize();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_io_sizer_size_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_io_sizer_size_get_delegate efl_io_sizer_size_get_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_io_sizer_size_set_delegate(System.IntPtr obj, System.IntPtr pd,   ulong size);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_io_sizer_size_set_api_delegate(System.IntPtr obj,   ulong size);
     public static Efl.Eo.FunctionWrapper<efl_io_sizer_size_set_api_delegate> efl_io_sizer_size_set_ptr = new Efl.Eo.FunctionWrapper<efl_io_sizer_size_set_api_delegate>(_Module, "efl_io_sizer_size_set");
     private static bool size_set(System.IntPtr obj, System.IntPtr pd,  ulong size)
    {
        Eina.Log.Debug("function efl_io_sizer_size_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                bool _ret_var = default(bool);
            try {
                _ret_var = ((Buffer)wrapper).SetSize( size);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                        return _ret_var;
        } else {
            return efl_io_sizer_size_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  size);
        }
    }
    private static efl_io_sizer_size_set_delegate efl_io_sizer_size_set_static_delegate;


     private delegate Eina.Error efl_io_sizer_resize_delegate(System.IntPtr obj, System.IntPtr pd,   ulong size);


     public delegate Eina.Error efl_io_sizer_resize_api_delegate(System.IntPtr obj,   ulong size);
     public static Efl.Eo.FunctionWrapper<efl_io_sizer_resize_api_delegate> efl_io_sizer_resize_ptr = new Efl.Eo.FunctionWrapper<efl_io_sizer_resize_api_delegate>(_Module, "efl_io_sizer_resize");
     private static Eina.Error resize(System.IntPtr obj, System.IntPtr pd,  ulong size)
    {
        Eina.Log.Debug("function efl_io_sizer_resize was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                Eina.Error _ret_var = default(Eina.Error);
            try {
                _ret_var = ((Buffer)wrapper).Resize( size);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                        return _ret_var;
        } else {
            return efl_io_sizer_resize_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  size);
        }
    }
    private static efl_io_sizer_resize_delegate efl_io_sizer_resize_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_io_writer_can_write_get_delegate(System.IntPtr obj, System.IntPtr pd);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_io_writer_can_write_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_io_writer_can_write_get_api_delegate> efl_io_writer_can_write_get_ptr = new Efl.Eo.FunctionWrapper<efl_io_writer_can_write_get_api_delegate>(_Module, "efl_io_writer_can_write_get");
     private static bool can_write_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_io_writer_can_write_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        bool _ret_var = default(bool);
            try {
                _ret_var = ((Buffer)wrapper).GetCanWrite();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_io_writer_can_write_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_io_writer_can_write_get_delegate efl_io_writer_can_write_get_static_delegate;


     private delegate void efl_io_writer_can_write_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool can_write);


     public delegate void efl_io_writer_can_write_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool can_write);
     public static Efl.Eo.FunctionWrapper<efl_io_writer_can_write_set_api_delegate> efl_io_writer_can_write_set_ptr = new Efl.Eo.FunctionWrapper<efl_io_writer_can_write_set_api_delegate>(_Module, "efl_io_writer_can_write_set");
     private static void can_write_set(System.IntPtr obj, System.IntPtr pd,  bool can_write)
    {
        Eina.Log.Debug("function efl_io_writer_can_write_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((Buffer)wrapper).SetCanWrite( can_write);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_io_writer_can_write_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  can_write);
        }
    }
    private static efl_io_writer_can_write_set_delegate efl_io_writer_can_write_set_static_delegate;


     private delegate Eina.Error efl_io_writer_write_delegate(System.IntPtr obj, System.IntPtr pd,   ref Eina.Slice slice,   ref Eina.Slice remaining);


     public delegate Eina.Error efl_io_writer_write_api_delegate(System.IntPtr obj,   ref Eina.Slice slice,   ref Eina.Slice remaining);
     public static Efl.Eo.FunctionWrapper<efl_io_writer_write_api_delegate> efl_io_writer_write_ptr = new Efl.Eo.FunctionWrapper<efl_io_writer_write_api_delegate>(_Module, "efl_io_writer_write");
     private static Eina.Error write(System.IntPtr obj, System.IntPtr pd,  ref Eina.Slice slice,  ref Eina.Slice remaining)
    {
        Eina.Log.Debug("function efl_io_writer_write was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                            remaining = default(Eina.Slice);                            Eina.Error _ret_var = default(Eina.Error);
            try {
                _ret_var = ((Buffer)wrapper).Write( ref slice,  ref remaining);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                        return _ret_var;
        } else {
            return efl_io_writer_write_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  ref slice,  ref remaining);
        }
    }
    private static efl_io_writer_write_delegate efl_io_writer_write_static_delegate;
}
} } 
