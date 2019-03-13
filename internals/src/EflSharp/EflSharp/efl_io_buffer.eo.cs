#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Io { 
/// <summary>Generic In-memory buffer of data to be used as I/O.
/// This class offers both input and output, which can be used at the same time since <see cref="Efl.Io.Reader.Read"/> and <see cref="Efl.Io.Writer.Write"/> use different offsets/position internally.
/// 
/// One can get temporary direct access to internal buffer with <see cref="Efl.Io.Buffer.GetSlice"/> or steal the buffer with <see cref="Efl.Io.Buffer.BinbufSteal"/>.
/// 
/// A fixed sized buffer can be implemented by setting <see cref="Efl.Io.Buffer.Limit"/> followed by <see cref="Efl.Io.Buffer.Preallocate"/>
/// 1.19</summary>
[BufferNativeInherit]
public class Buffer : Efl.Object, Efl.Eo.IWrapper,Efl.Io.Closer,Efl.Io.Positioner,Efl.Io.Reader,Efl.Io.Sizer,Efl.Io.Writer
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Io.BufferNativeInherit nativeInherit = new Efl.Io.BufferNativeInherit();
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
   public Buffer(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
   protected Buffer(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static Buffer static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new Buffer(obj.NativeHandle);
   }
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
private static object Position_readChangedEvtKey = new object();
   /// <summary>Notifies <see cref="Efl.Io.Buffer.PositionRead"/> changed
   /// 1.19</summary>
   public event EventHandler Position_readChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_IO_BUFFER_EVENT_POSITION_READ_CHANGED";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_Position_readChangedEvt_delegate)) {
               eventHandlers.AddHandler(Position_readChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_IO_BUFFER_EVENT_POSITION_READ_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_Position_readChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(Position_readChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event Position_readChangedEvt.</summary>
   public void On_Position_readChangedEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[Position_readChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_Position_readChangedEvt_delegate;
   private void on_Position_readChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_Position_readChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object Position_writeChangedEvtKey = new object();
   /// <summary>Notifies <see cref="Efl.Io.Buffer.PositionWrite"/> changed
   /// 1.19</summary>
   public event EventHandler Position_writeChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_IO_BUFFER_EVENT_POSITION_WRITE_CHANGED";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_Position_writeChangedEvt_delegate)) {
               eventHandlers.AddHandler(Position_writeChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_IO_BUFFER_EVENT_POSITION_WRITE_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_Position_writeChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(Position_writeChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event Position_writeChangedEvt.</summary>
   public void On_Position_writeChangedEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[Position_writeChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_Position_writeChangedEvt_delegate;
   private void on_Position_writeChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_Position_writeChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object ReallocatedEvtKey = new object();
   /// <summary>Notifies the internal buffer was reallocated, thus whatever was returned by <see cref="Efl.Io.Buffer.GetSlice"/> becomes invalid
   /// 1.19</summary>
   public event EventHandler ReallocatedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_IO_BUFFER_EVENT_REALLOCATED";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_ReallocatedEvt_delegate)) {
               eventHandlers.AddHandler(ReallocatedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_IO_BUFFER_EVENT_REALLOCATED";
            if (remove_cpp_event_handler(key, this.evt_ReallocatedEvt_delegate)) { 
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
   private void on_ReallocatedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
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
   /// 1.19</summary>
   public event EventHandler ClosedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_IO_CLOSER_EVENT_CLOSED";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_ClosedEvt_delegate)) {
               eventHandlers.AddHandler(ClosedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_IO_CLOSER_EVENT_CLOSED";
            if (remove_cpp_event_handler(key, this.evt_ClosedEvt_delegate)) { 
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
   private void on_ClosedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
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
   /// <summary>Notifies position changed
   /// 1.19</summary>
   public event EventHandler PositionChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_IO_POSITIONER_EVENT_POSITION_CHANGED";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_PositionChangedEvt_delegate)) {
               eventHandlers.AddHandler(PositionChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_IO_POSITIONER_EVENT_POSITION_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_PositionChangedEvt_delegate)) { 
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
   private void on_PositionChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_PositionChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object Can_readChangedEvtKey = new object();
   /// <summary>Notifies can_read property changed.
   /// If <see cref="Efl.Io.Reader.CanRead"/> is <c>true</c> there is data to <see cref="Efl.Io.Reader.Read"/> without blocking/error. If <see cref="Efl.Io.Reader.CanRead"/> is <c>false</c>, <see cref="Efl.Io.Reader.Read"/> would either block or fail.
   /// 
   /// Note that usually this event is dispatched from inside <see cref="Efl.Io.Reader.Read"/>, thus before it returns.
   /// 1.19</summary>
   public event EventHandler<Efl.Io.ReaderCan_readChangedEvt_Args> Can_readChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_IO_READER_EVENT_CAN_READ_CHANGED";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_Can_readChangedEvt_delegate)) {
               eventHandlers.AddHandler(Can_readChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_IO_READER_EVENT_CAN_READ_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_Can_readChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(Can_readChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event Can_readChangedEvt.</summary>
   public void On_Can_readChangedEvt(Efl.Io.ReaderCan_readChangedEvt_Args e)
   {
      EventHandler<Efl.Io.ReaderCan_readChangedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Io.ReaderCan_readChangedEvt_Args>)eventHandlers[Can_readChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_Can_readChangedEvt_delegate;
   private void on_Can_readChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Io.ReaderCan_readChangedEvt_Args args = new Efl.Io.ReaderCan_readChangedEvt_Args();
      args.arg = evt.Info != IntPtr.Zero;
      try {
         On_Can_readChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object EosEvtKey = new object();
   /// <summary>Notifies end of stream, when property is marked as true.
   /// If this is used alongside with an <see cref="Efl.Io.Closer"/>, then it should be emitted before that call.
   /// 
   /// It should be emitted only once for an object unless it implements <see cref="Efl.Io.Positioner.Seek"/>.
   /// 
   /// The property <see cref="Efl.Io.Reader.CanRead"/> should change to <c>false</c> before this event is dispatched.
   /// 1.19</summary>
   public event EventHandler EosEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_IO_READER_EVENT_EOS";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_EosEvt_delegate)) {
               eventHandlers.AddHandler(EosEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_IO_READER_EVENT_EOS";
            if (remove_cpp_event_handler(key, this.evt_EosEvt_delegate)) { 
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
   private void on_EosEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
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
   /// <summary>Notifies size changed
   /// 1.19</summary>
   public event EventHandler SizeChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_IO_SIZER_EVENT_SIZE_CHANGED";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_SizeChangedEvt_delegate)) {
               eventHandlers.AddHandler(SizeChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_IO_SIZER_EVENT_SIZE_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_SizeChangedEvt_delegate)) { 
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
   private void on_SizeChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_SizeChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object Can_writeChangedEvtKey = new object();
   /// <summary>Notifies can_write property changed.
   /// If <see cref="Efl.Io.Writer.CanWrite"/> is <c>true</c> there is data to <see cref="Efl.Io.Writer.Write"/> without blocking/error. If <see cref="Efl.Io.Writer.CanWrite"/> is <c>false</c>, <see cref="Efl.Io.Writer.Write"/> would either block or fail.
   /// 
   /// Note that usually this event is dispatched from inside <see cref="Efl.Io.Writer.Write"/>, thus before it returns.
   /// 1.19</summary>
   public event EventHandler<Efl.Io.WriterCan_writeChangedEvt_Args> Can_writeChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_IO_WRITER_EVENT_CAN_WRITE_CHANGED";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_Can_writeChangedEvt_delegate)) {
               eventHandlers.AddHandler(Can_writeChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_IO_WRITER_EVENT_CAN_WRITE_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_Can_writeChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(Can_writeChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event Can_writeChangedEvt.</summary>
   public void On_Can_writeChangedEvt(Efl.Io.WriterCan_writeChangedEvt_Args e)
   {
      EventHandler<Efl.Io.WriterCan_writeChangedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Io.WriterCan_writeChangedEvt_Args>)eventHandlers[Can_writeChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_Can_writeChangedEvt_delegate;
   private void on_Can_writeChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Io.WriterCan_writeChangedEvt_Args args = new Efl.Io.WriterCan_writeChangedEvt_Args();
      args.arg = evt.Info != IntPtr.Zero;
      try {
         On_Can_writeChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

   protected override void register_event_proxies()
   {
      base.register_event_proxies();
      evt_Position_readChangedEvt_delegate = new Efl.EventCb(on_Position_readChangedEvt_NativeCallback);
      evt_Position_writeChangedEvt_delegate = new Efl.EventCb(on_Position_writeChangedEvt_NativeCallback);
      evt_ReallocatedEvt_delegate = new Efl.EventCb(on_ReallocatedEvt_NativeCallback);
      evt_ClosedEvt_delegate = new Efl.EventCb(on_ClosedEvt_NativeCallback);
      evt_PositionChangedEvt_delegate = new Efl.EventCb(on_PositionChangedEvt_NativeCallback);
      evt_Can_readChangedEvt_delegate = new Efl.EventCb(on_Can_readChangedEvt_NativeCallback);
      evt_EosEvt_delegate = new Efl.EventCb(on_EosEvt_NativeCallback);
      evt_SizeChangedEvt_delegate = new Efl.EventCb(on_SizeChangedEvt_NativeCallback);
      evt_Can_writeChangedEvt_delegate = new Efl.EventCb(on_Can_writeChangedEvt_NativeCallback);
   }
   /// <summary>Limit how big the buffer can grow.
   /// This affects both <see cref="Efl.Io.Buffer.Preallocate"/> and how buffer grows when <see cref="Efl.Io.Writer.Write"/> is called.
   /// 
   /// If you want a buffer of an exact size always set the limit before any further calls that can expand it.
   /// 1.19</summary>
   /// <returns>Defines a maximum buffer size, or 0 to allow unlimited amount of bytes
   /// 1.19</returns>
   virtual public  uint GetLimit() {
       var _ret_var = Efl.Io.BufferNativeInherit.efl_io_buffer_limit_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Constructor-only property to set buffer limit. 0 is unlimited
   /// 1.19</summary>
   /// <param name="size">Defines a maximum buffer size, or 0 to allow unlimited amount of bytes
   /// 1.19</param>
   /// <returns></returns>
   virtual public  void SetLimit(  uint size) {
                         Efl.Io.BufferNativeInherit.efl_io_buffer_limit_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), size);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>The position used by <see cref="Efl.Io.Reader.Read"/>.
   /// Note that <see cref="Efl.Io.Positioner.Seek"/> or <see cref="Efl.Io.Positioner.SetPosition"/> will affect this property and <see cref="Efl.Io.Buffer.PositionWrite"/>.
   /// 
   /// <see cref="Efl.Io.Positioner.GetPosition"/> will return the greatest of <see cref="Efl.Io.Buffer.PositionRead"/> and <see cref="Efl.Io.Buffer.PositionWrite"/>.
   /// 1.19</summary>
   /// <returns>Position in buffer
   /// 1.19</returns>
   virtual public  ulong GetPositionRead() {
       var _ret_var = Efl.Io.BufferNativeInherit.efl_io_buffer_position_read_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>The position used by <see cref="Efl.Io.Reader.Read"/>.
   /// Note that <see cref="Efl.Io.Positioner.Seek"/> or <see cref="Efl.Io.Positioner.SetPosition"/> will affect this property and <see cref="Efl.Io.Buffer.PositionWrite"/>.
   /// 
   /// <see cref="Efl.Io.Positioner.GetPosition"/> will return the greatest of <see cref="Efl.Io.Buffer.PositionRead"/> and <see cref="Efl.Io.Buffer.PositionWrite"/>.
   /// 1.19</summary>
   /// <param name="position">Position in buffer
   /// 1.19</param>
   /// <returns><c>true</c> if setting the position succeeded, <c>false</c> otherwise
   /// 1.19</returns>
   virtual public bool SetPositionRead(  ulong position) {
                         var _ret_var = Efl.Io.BufferNativeInherit.efl_io_buffer_position_read_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), position);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>The position used by <see cref="Efl.Io.Writer.Write"/>.
   /// Note that <see cref="Efl.Io.Positioner.Seek"/> or <see cref="Efl.Io.Positioner.SetPosition"/> will affect this property and <see cref="Efl.Io.Buffer.PositionRead"/>.
   /// 
   /// <see cref="Efl.Io.Positioner.GetPosition"/> will return the greatest of <see cref="Efl.Io.Buffer.PositionRead"/> and <see cref="Efl.Io.Buffer.PositionWrite"/>.
   /// 1.19</summary>
   /// <returns>Position in buffer
   /// 1.19</returns>
   virtual public  ulong GetPositionWrite() {
       var _ret_var = Efl.Io.BufferNativeInherit.efl_io_buffer_position_write_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>The position used by <see cref="Efl.Io.Writer.Write"/>.
   /// Note that <see cref="Efl.Io.Positioner.Seek"/> or <see cref="Efl.Io.Positioner.SetPosition"/> will affect this property and <see cref="Efl.Io.Buffer.PositionRead"/>.
   /// 
   /// <see cref="Efl.Io.Positioner.GetPosition"/> will return the greatest of <see cref="Efl.Io.Buffer.PositionRead"/> and <see cref="Efl.Io.Buffer.PositionWrite"/>.
   /// 1.19</summary>
   /// <param name="position">Position in buffer
   /// 1.19</param>
   /// <returns><c>true</c> if setting the position succeeded, <c>false</c> otherwise
   /// 1.19</returns>
   virtual public bool SetPositionWrite(  ulong position) {
                         var _ret_var = Efl.Io.BufferNativeInherit.efl_io_buffer_position_write_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), position);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Get a temporary access to buffer&apos;s internal memory.
   /// The memory pointed by slice may be changed by other methods of this class. The event &quot;reallocated&quot; will be called in those situations.
   /// 1.19</summary>
   /// <returns>Slice of the current buffer, may be invalidated if <see cref="Efl.Io.Writer.Write"/>, <see cref="Efl.Io.Closer.Close"/> or <see cref="Efl.Io.Sizer.Resize"/> are called. It is the full slice, not a partial one starting at current position.
   /// 1.19</returns>
   virtual public Eina.Slice GetSlice() {
       var _ret_var = Efl.Io.BufferNativeInherit.efl_io_buffer_slice_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Immediately pre-allocate a buffer of at least a given size.
   /// 1.19</summary>
   /// <param name="size">Amount of bytes to pre-allocate.
   /// 1.19</param>
   /// <returns></returns>
   virtual public  void Preallocate(  uint size) {
                         Efl.Io.BufferNativeInherit.efl_io_buffer_preallocate_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), size);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Adopt a read-only slice as buffer&apos;s backing store.
   /// The slice memory will not be copied and must remain alive during the buffer&apos;s lifetime. Usually this is guaranteed by some global static-const memory or some parent object and this buffer being a view of that -- be aware of parent memory remaining alive, such as &quot;slice,changed&quot; events.
   /// 1.19</summary>
   /// <param name="slice">Slice to adopt as read-only
   /// 1.19</param>
   /// <returns></returns>
   virtual public  void AdoptReadonly( Eina.Slice slice) {
                         Efl.Io.BufferNativeInherit.efl_io_buffer_adopt_readonly_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), slice);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Adopt a read-write slice as buffer&apos;s backing store.
   /// The slice memory will not be copied and must remain alive during the buffer&apos;s lifetime. Usually this is guaranteed by some global static memory or some parent object and this buffer being a view of that -- be aware of parent memory remaining alive, such as &quot;slice,changed&quot; events.
   /// 
   /// The memory will be disposed using free() and reallocated using realloc().
   /// 1.19</summary>
   /// <param name="slice">Slice to adopt as read-write
   /// 1.19</param>
   /// <returns></returns>
   virtual public  void AdoptReadwrite( Eina.RwSlice slice) {
                         Efl.Io.BufferNativeInherit.efl_io_buffer_adopt_readwrite_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), slice);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Steals the internal buffer memory and returns it as a binbuf.
   /// The returned memory must be freed with eina_binbuf_free().
   /// 
   /// On failure, for example a read-only backing store was adopted with <see cref="Efl.Io.Buffer.AdoptReadonly"/>, NULL is returned.
   /// 1.19</summary>
   /// <returns>Binbuf
   /// 1.19</returns>
   virtual public Eina.Binbuf BinbufSteal() {
       var _ret_var = Efl.Io.BufferNativeInherit.efl_io_buffer_binbuf_steal_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      var _binbuf_ret = new Eina.Binbuf(_ret_var, true);
      return _binbuf_ret;
 }
   /// <summary>If true will notify object was closed.
   /// 1.19</summary>
   /// <returns><c>true</c> if closed, <c>false</c> otherwise
   /// 1.19</returns>
   virtual public bool GetClosed() {
       var _ret_var = Efl.Io.CloserNativeInherit.efl_io_closer_closed_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>If true will automatically close resources on exec() calls.
   /// When using file descriptors this should set FD_CLOEXEC so they are not inherited by the processes (children or self) doing exec().
   /// 1.19</summary>
   /// <returns><c>true</c> if close on exec(), <c>false</c> otherwise
   /// 1.19</returns>
   virtual public bool GetCloseOnExec() {
       var _ret_var = Efl.Io.CloserNativeInherit.efl_io_closer_close_on_exec_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>If <c>true</c>, will close on exec() call.
   /// 1.19</summary>
   /// <param name="close_on_exec"><c>true</c> if close on exec(), <c>false</c> otherwise
   /// 1.19</param>
   /// <returns><c>true</c> if could set, <c>false</c> if not supported or failed.
   /// 1.19</returns>
   virtual public bool SetCloseOnExec( bool close_on_exec) {
                         var _ret_var = Efl.Io.CloserNativeInherit.efl_io_closer_close_on_exec_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), close_on_exec);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>If true will automatically close() on object invalidate.
   /// If the object was disconnected from its parent (including the main loop) without close, this property will state whenever it should be closed or not.
   /// 1.19</summary>
   /// <returns><c>true</c> if close on invalidate, <c>false</c> otherwise
   /// 1.19</returns>
   virtual public bool GetCloseOnInvalidate() {
       var _ret_var = Efl.Io.CloserNativeInherit.efl_io_closer_close_on_invalidate_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>If true will automatically close() on object invalidate.
   /// If the object was disconnected from its parent (including the main loop) without close, this property will state whenever it should be closed or not.
   /// 1.19</summary>
   /// <param name="close_on_invalidate"><c>true</c> if close on invalidate, <c>false</c> otherwise
   /// 1.19</param>
   /// <returns></returns>
   virtual public  void SetCloseOnInvalidate( bool close_on_invalidate) {
                         Efl.Io.CloserNativeInherit.efl_io_closer_close_on_invalidate_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), close_on_invalidate);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Closes the Input/Output object.
   /// This operation will be executed immediately and may or may not block the caller thread for some time. The details of blocking behavior is to be defined by the implementation and may be subject to other parameters such as non-blocking flags, maximum timeout or even retry attempts.
   /// 
   /// You can understand this method as close(2) libc function.
   /// 1.19</summary>
   /// <returns>0 on succeed, a mapping of errno otherwise
   /// 1.19</returns>
   virtual public  Eina.Error Close() {
       var _ret_var = Efl.Io.CloserNativeInherit.efl_io_closer_close_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Position property
   /// 1.19</summary>
   /// <returns>Position in file or buffer
   /// 1.19</returns>
   virtual public  ulong GetPosition() {
       var _ret_var = Efl.Io.PositionerNativeInherit.efl_io_positioner_position_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Try to set position object, relative to start of file. See <see cref="Efl.Io.Positioner.Seek"/>
   /// 1.19</summary>
   /// <param name="position">Position in file or buffer
   /// 1.19</param>
   /// <returns><c>true</c> if could reposition, <c>false</c> if errors.
   /// 1.19</returns>
   virtual public bool SetPosition(  ulong position) {
                         var _ret_var = Efl.Io.PositionerNativeInherit.efl_io_positioner_position_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), position);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Seek in data
   /// 1.19</summary>
   /// <param name="offset">Offset in byte relative to whence
   /// 1.19</param>
   /// <param name="whence">Whence
   /// 1.19</param>
   /// <returns>0 on succeed, a mapping of errno otherwise
   /// 1.19</returns>
   virtual public  Eina.Error Seek(  long offset,  Efl.Io.PositionerWhence whence) {
                                           var _ret_var = Efl.Io.PositionerNativeInherit.efl_io_positioner_seek_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), offset,  whence);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }
   /// <summary>If <c>true</c> will notify <see cref="Efl.Io.Reader.Read"/> can be called without blocking or failing.
   /// 1.19</summary>
   /// <returns><c>true</c> if it can be read without blocking or failing, <c>false</c> otherwise
   /// 1.19</returns>
   virtual public bool GetCanRead() {
       var _ret_var = Efl.Io.ReaderNativeInherit.efl_io_reader_can_read_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>If <c>true</c> will notify <see cref="Efl.Io.Reader.Read"/> can be called without blocking or failing.
   /// 1.19</summary>
   /// <param name="can_read"><c>true</c> if it can be read without blocking or failing, <c>false</c> otherwise
   /// 1.19</param>
   /// <returns></returns>
   virtual public  void SetCanRead( bool can_read) {
                         Efl.Io.ReaderNativeInherit.efl_io_reader_can_read_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), can_read);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>If <c>true</c> will notify end of stream.
   /// 1.19</summary>
   /// <returns><c>true</c> if end of stream, <c>false</c> otherwise
   /// 1.19</returns>
   virtual public bool GetEos() {
       var _ret_var = Efl.Io.ReaderNativeInherit.efl_io_reader_eos_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>If <c>true</c> will notify end of stream.
   /// 1.19</summary>
   /// <param name="is_eos"><c>true</c> if end of stream, <c>false</c> otherwise
   /// 1.19</param>
   /// <returns></returns>
   virtual public  void SetEos( bool is_eos) {
                         Efl.Io.ReaderNativeInherit.efl_io_reader_eos_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), is_eos);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Reads data into a pre-allocated buffer.
   /// This operation will be executed immediately and may or may not block the caller thread for some time. The details of blocking behavior is to be defined by the implementation and may be subject to other parameters such as non-blocking flags, maximum timeout or even retry attempts.
   /// 
   /// You can understand this method as read(2) libc function.
   /// 1.19</summary>
   /// <param name="rw_slice">Provides a pre-allocated memory to be filled up to rw_slice.len. It will be populated and the length will be set to the actually used amount of bytes, which can be smaller than the request.
   /// 1.19</param>
   /// <returns>0 on succeed, a mapping of errno otherwise
   /// 1.19</returns>
   virtual public  Eina.Error Read( ref Eina.RwSlice rw_slice) {
                         var _ret_var = Efl.Io.ReaderNativeInherit.efl_io_reader_read_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), ref rw_slice);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Size property
   /// 1.19</summary>
   /// <returns>Object size
   /// 1.19</returns>
   virtual public  ulong GetSize() {
       var _ret_var = Efl.Io.SizerNativeInherit.efl_io_sizer_size_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Try to resize the object, check with get if the value was accepted or not.
   /// 1.19</summary>
   /// <param name="size">Object size
   /// 1.19</param>
   /// <returns><c>true</c> if could resize, <c>false</c> if errors.
   /// 1.19</returns>
   virtual public bool SetSize(  ulong size) {
                         var _ret_var = Efl.Io.SizerNativeInherit.efl_io_sizer_size_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), size);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Resize object
   /// 1.19</summary>
   /// <param name="size">Object size
   /// 1.19</param>
   /// <returns>0 on succeed, a mapping of errno otherwise
   /// 1.19</returns>
   virtual public  Eina.Error Resize(  ulong size) {
                         var _ret_var = Efl.Io.SizerNativeInherit.efl_io_sizer_resize_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), size);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>If <c>true</c> will notify <see cref="Efl.Io.Writer.Write"/> can be called without blocking or failing.
   /// 1.19</summary>
   /// <returns><c>true</c> if it can be written without blocking or failure, <c>false</c> otherwise
   /// 1.19</returns>
   virtual public bool GetCanWrite() {
       var _ret_var = Efl.Io.WriterNativeInherit.efl_io_writer_can_write_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>If <c>true</c> will notify <see cref="Efl.Io.Writer.Write"/> can be called without blocking or failing.
   /// 1.19</summary>
   /// <param name="can_write"><c>true</c> if it can be written without blocking or failure, <c>false</c> otherwise
   /// 1.19</param>
   /// <returns></returns>
   virtual public  void SetCanWrite( bool can_write) {
                         Efl.Io.WriterNativeInherit.efl_io_writer_can_write_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), can_write);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Writes data from a pre-populated buffer.
   /// This operation will be executed immediately and may or may not block the caller thread for some time. The details of blocking behavior is defined by the implementation and may be subject to other parameters such as non-blocking flags, maximum timeout or even retry attempts.
   /// 
   /// You can understand this method as write(2) libc function.
   /// 1.19</summary>
   /// <param name="slice">Provides a pre-populated memory to be used up to slice.len. The returned slice will be adapted as length will be set to the actually used amount of bytes, which can be smaller than the request.
   /// 1.19</param>
   /// <param name="remaining">Convenience to output the remaining parts of slice that was not written. If the full slice was written, this will be a slice of zero-length.
   /// 1.19</param>
   /// <returns>0 on succeed, a mapping of errno otherwise
   /// 1.19</returns>
   virtual public  Eina.Error Write( ref Eina.Slice slice,  ref Eina.Slice remaining) {
                                           var _ret_var = Efl.Io.WriterNativeInherit.efl_io_writer_write_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), ref slice,  ref remaining);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }
   /// <summary>Limit how big the buffer can grow.
/// This affects both <see cref="Efl.Io.Buffer.Preallocate"/> and how buffer grows when <see cref="Efl.Io.Writer.Write"/> is called.
/// 
/// If you want a buffer of an exact size always set the limit before any further calls that can expand it.
/// 1.19</summary>
/// <value>Defines a maximum buffer size, or 0 to allow unlimited amount of bytes
/// 1.19</value>
   public  uint Limit {
      get { return GetLimit(); }
      set { SetLimit( value); }
   }
   /// <summary>The position used by <see cref="Efl.Io.Reader.Read"/>.
/// Note that <see cref="Efl.Io.Positioner.Seek"/> or <see cref="Efl.Io.Positioner.SetPosition"/> will affect this property and <see cref="Efl.Io.Buffer.PositionWrite"/>.
/// 
/// <see cref="Efl.Io.Positioner.GetPosition"/> will return the greatest of <see cref="Efl.Io.Buffer.PositionRead"/> and <see cref="Efl.Io.Buffer.PositionWrite"/>.
/// 1.19</summary>
/// <value>Position in buffer
/// 1.19</value>
   public  ulong PositionRead {
      get { return GetPositionRead(); }
      set { SetPositionRead( value); }
   }
   /// <summary>The position used by <see cref="Efl.Io.Writer.Write"/>.
/// Note that <see cref="Efl.Io.Positioner.Seek"/> or <see cref="Efl.Io.Positioner.SetPosition"/> will affect this property and <see cref="Efl.Io.Buffer.PositionRead"/>.
/// 
/// <see cref="Efl.Io.Positioner.GetPosition"/> will return the greatest of <see cref="Efl.Io.Buffer.PositionRead"/> and <see cref="Efl.Io.Buffer.PositionWrite"/>.
/// 1.19</summary>
/// <value>Position in buffer
/// 1.19</value>
   public  ulong PositionWrite {
      get { return GetPositionWrite(); }
      set { SetPositionWrite( value); }
   }
   /// <summary>Get a temporary access to buffer&apos;s internal memory.
/// The memory pointed by slice may be changed by other methods of this class. The event &quot;reallocated&quot; will be called in those situations.
/// 1.19</summary>
/// <value>Slice of the current buffer, may be invalidated if <see cref="Efl.Io.Writer.Write"/>, <see cref="Efl.Io.Closer.Close"/> or <see cref="Efl.Io.Sizer.Resize"/> are called. It is the full slice, not a partial one starting at current position.
/// 1.19</value>
   public Eina.Slice Slice {
      get { return GetSlice(); }
   }
   /// <summary>If true will notify object was closed.
/// 1.19</summary>
/// <value><c>true</c> if closed, <c>false</c> otherwise
/// 1.19</value>
   public bool Closed {
      get { return GetClosed(); }
   }
   /// <summary>If true will automatically close resources on exec() calls.
/// When using file descriptors this should set FD_CLOEXEC so they are not inherited by the processes (children or self) doing exec().
/// 1.19</summary>
/// <value><c>true</c> if close on exec(), <c>false</c> otherwise
/// 1.19</value>
   public bool CloseOnExec {
      get { return GetCloseOnExec(); }
      set { SetCloseOnExec( value); }
   }
   /// <summary>If true will automatically close() on object invalidate.
/// If the object was disconnected from its parent (including the main loop) without close, this property will state whenever it should be closed or not.
/// 1.19</summary>
/// <value><c>true</c> if close on invalidate, <c>false</c> otherwise
/// 1.19</value>
   public bool CloseOnInvalidate {
      get { return GetCloseOnInvalidate(); }
      set { SetCloseOnInvalidate( value); }
   }
   /// <summary>Position property
/// 1.19</summary>
/// <value>Position in file or buffer
/// 1.19</value>
   public  ulong Position {
      get { return GetPosition(); }
      set { SetPosition( value); }
   }
   /// <summary>If <c>true</c> will notify <see cref="Efl.Io.Reader.Read"/> can be called without blocking or failing.
/// 1.19</summary>
/// <value><c>true</c> if it can be read without blocking or failing, <c>false</c> otherwise
/// 1.19</value>
   public bool CanRead {
      get { return GetCanRead(); }
      set { SetCanRead( value); }
   }
   /// <summary>If <c>true</c> will notify end of stream.
/// 1.19</summary>
/// <value><c>true</c> if end of stream, <c>false</c> otherwise
/// 1.19</value>
   public bool Eos {
      get { return GetEos(); }
      set { SetEos( value); }
   }
   /// <summary>Size property
/// 1.19</summary>
/// <value>Object size
/// 1.19</value>
   public  ulong Size {
      get { return GetSize(); }
      set { SetSize( value); }
   }
   /// <summary>If <c>true</c> will notify <see cref="Efl.Io.Writer.Write"/> can be called without blocking or failing.
/// 1.19</summary>
/// <value><c>true</c> if it can be written without blocking or failure, <c>false</c> otherwise
/// 1.19</value>
   public bool CanWrite {
      get { return GetCanWrite(); }
      set { SetCanWrite( value); }
   }
   private static new  IntPtr GetEflClassStatic()
   {
      return Efl.Io.Buffer.efl_io_buffer_class_get();
   }
}
public class BufferNativeInherit : Efl.ObjectNativeInherit{
   public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Efl);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      if (efl_io_buffer_limit_get_static_delegate == null)
      efl_io_buffer_limit_get_static_delegate = new efl_io_buffer_limit_get_delegate(limit_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_io_buffer_limit_get"), func = Marshal.GetFunctionPointerForDelegate(efl_io_buffer_limit_get_static_delegate)});
      if (efl_io_buffer_limit_set_static_delegate == null)
      efl_io_buffer_limit_set_static_delegate = new efl_io_buffer_limit_set_delegate(limit_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_io_buffer_limit_set"), func = Marshal.GetFunctionPointerForDelegate(efl_io_buffer_limit_set_static_delegate)});
      if (efl_io_buffer_position_read_get_static_delegate == null)
      efl_io_buffer_position_read_get_static_delegate = new efl_io_buffer_position_read_get_delegate(position_read_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_io_buffer_position_read_get"), func = Marshal.GetFunctionPointerForDelegate(efl_io_buffer_position_read_get_static_delegate)});
      if (efl_io_buffer_position_read_set_static_delegate == null)
      efl_io_buffer_position_read_set_static_delegate = new efl_io_buffer_position_read_set_delegate(position_read_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_io_buffer_position_read_set"), func = Marshal.GetFunctionPointerForDelegate(efl_io_buffer_position_read_set_static_delegate)});
      if (efl_io_buffer_position_write_get_static_delegate == null)
      efl_io_buffer_position_write_get_static_delegate = new efl_io_buffer_position_write_get_delegate(position_write_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_io_buffer_position_write_get"), func = Marshal.GetFunctionPointerForDelegate(efl_io_buffer_position_write_get_static_delegate)});
      if (efl_io_buffer_position_write_set_static_delegate == null)
      efl_io_buffer_position_write_set_static_delegate = new efl_io_buffer_position_write_set_delegate(position_write_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_io_buffer_position_write_set"), func = Marshal.GetFunctionPointerForDelegate(efl_io_buffer_position_write_set_static_delegate)});
      if (efl_io_buffer_slice_get_static_delegate == null)
      efl_io_buffer_slice_get_static_delegate = new efl_io_buffer_slice_get_delegate(slice_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_io_buffer_slice_get"), func = Marshal.GetFunctionPointerForDelegate(efl_io_buffer_slice_get_static_delegate)});
      if (efl_io_buffer_preallocate_static_delegate == null)
      efl_io_buffer_preallocate_static_delegate = new efl_io_buffer_preallocate_delegate(preallocate);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_io_buffer_preallocate"), func = Marshal.GetFunctionPointerForDelegate(efl_io_buffer_preallocate_static_delegate)});
      if (efl_io_buffer_adopt_readonly_static_delegate == null)
      efl_io_buffer_adopt_readonly_static_delegate = new efl_io_buffer_adopt_readonly_delegate(adopt_readonly);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_io_buffer_adopt_readonly"), func = Marshal.GetFunctionPointerForDelegate(efl_io_buffer_adopt_readonly_static_delegate)});
      if (efl_io_buffer_adopt_readwrite_static_delegate == null)
      efl_io_buffer_adopt_readwrite_static_delegate = new efl_io_buffer_adopt_readwrite_delegate(adopt_readwrite);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_io_buffer_adopt_readwrite"), func = Marshal.GetFunctionPointerForDelegate(efl_io_buffer_adopt_readwrite_static_delegate)});
      if (efl_io_buffer_binbuf_steal_static_delegate == null)
      efl_io_buffer_binbuf_steal_static_delegate = new efl_io_buffer_binbuf_steal_delegate(binbuf_steal);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_io_buffer_binbuf_steal"), func = Marshal.GetFunctionPointerForDelegate(efl_io_buffer_binbuf_steal_static_delegate)});
      if (efl_io_closer_closed_get_static_delegate == null)
      efl_io_closer_closed_get_static_delegate = new efl_io_closer_closed_get_delegate(closed_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_io_closer_closed_get"), func = Marshal.GetFunctionPointerForDelegate(efl_io_closer_closed_get_static_delegate)});
      if (efl_io_closer_close_on_exec_get_static_delegate == null)
      efl_io_closer_close_on_exec_get_static_delegate = new efl_io_closer_close_on_exec_get_delegate(close_on_exec_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_io_closer_close_on_exec_get"), func = Marshal.GetFunctionPointerForDelegate(efl_io_closer_close_on_exec_get_static_delegate)});
      if (efl_io_closer_close_on_exec_set_static_delegate == null)
      efl_io_closer_close_on_exec_set_static_delegate = new efl_io_closer_close_on_exec_set_delegate(close_on_exec_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_io_closer_close_on_exec_set"), func = Marshal.GetFunctionPointerForDelegate(efl_io_closer_close_on_exec_set_static_delegate)});
      if (efl_io_closer_close_on_invalidate_get_static_delegate == null)
      efl_io_closer_close_on_invalidate_get_static_delegate = new efl_io_closer_close_on_invalidate_get_delegate(close_on_invalidate_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_io_closer_close_on_invalidate_get"), func = Marshal.GetFunctionPointerForDelegate(efl_io_closer_close_on_invalidate_get_static_delegate)});
      if (efl_io_closer_close_on_invalidate_set_static_delegate == null)
      efl_io_closer_close_on_invalidate_set_static_delegate = new efl_io_closer_close_on_invalidate_set_delegate(close_on_invalidate_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_io_closer_close_on_invalidate_set"), func = Marshal.GetFunctionPointerForDelegate(efl_io_closer_close_on_invalidate_set_static_delegate)});
      if (efl_io_closer_close_static_delegate == null)
      efl_io_closer_close_static_delegate = new efl_io_closer_close_delegate(close);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_io_closer_close"), func = Marshal.GetFunctionPointerForDelegate(efl_io_closer_close_static_delegate)});
      if (efl_io_positioner_position_get_static_delegate == null)
      efl_io_positioner_position_get_static_delegate = new efl_io_positioner_position_get_delegate(position_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_io_positioner_position_get"), func = Marshal.GetFunctionPointerForDelegate(efl_io_positioner_position_get_static_delegate)});
      if (efl_io_positioner_position_set_static_delegate == null)
      efl_io_positioner_position_set_static_delegate = new efl_io_positioner_position_set_delegate(position_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_io_positioner_position_set"), func = Marshal.GetFunctionPointerForDelegate(efl_io_positioner_position_set_static_delegate)});
      if (efl_io_positioner_seek_static_delegate == null)
      efl_io_positioner_seek_static_delegate = new efl_io_positioner_seek_delegate(seek);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_io_positioner_seek"), func = Marshal.GetFunctionPointerForDelegate(efl_io_positioner_seek_static_delegate)});
      if (efl_io_reader_can_read_get_static_delegate == null)
      efl_io_reader_can_read_get_static_delegate = new efl_io_reader_can_read_get_delegate(can_read_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_io_reader_can_read_get"), func = Marshal.GetFunctionPointerForDelegate(efl_io_reader_can_read_get_static_delegate)});
      if (efl_io_reader_can_read_set_static_delegate == null)
      efl_io_reader_can_read_set_static_delegate = new efl_io_reader_can_read_set_delegate(can_read_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_io_reader_can_read_set"), func = Marshal.GetFunctionPointerForDelegate(efl_io_reader_can_read_set_static_delegate)});
      if (efl_io_reader_eos_get_static_delegate == null)
      efl_io_reader_eos_get_static_delegate = new efl_io_reader_eos_get_delegate(eos_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_io_reader_eos_get"), func = Marshal.GetFunctionPointerForDelegate(efl_io_reader_eos_get_static_delegate)});
      if (efl_io_reader_eos_set_static_delegate == null)
      efl_io_reader_eos_set_static_delegate = new efl_io_reader_eos_set_delegate(eos_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_io_reader_eos_set"), func = Marshal.GetFunctionPointerForDelegate(efl_io_reader_eos_set_static_delegate)});
      if (efl_io_reader_read_static_delegate == null)
      efl_io_reader_read_static_delegate = new efl_io_reader_read_delegate(read);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_io_reader_read"), func = Marshal.GetFunctionPointerForDelegate(efl_io_reader_read_static_delegate)});
      if (efl_io_sizer_size_get_static_delegate == null)
      efl_io_sizer_size_get_static_delegate = new efl_io_sizer_size_get_delegate(size_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_io_sizer_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_io_sizer_size_get_static_delegate)});
      if (efl_io_sizer_size_set_static_delegate == null)
      efl_io_sizer_size_set_static_delegate = new efl_io_sizer_size_set_delegate(size_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_io_sizer_size_set"), func = Marshal.GetFunctionPointerForDelegate(efl_io_sizer_size_set_static_delegate)});
      if (efl_io_sizer_resize_static_delegate == null)
      efl_io_sizer_resize_static_delegate = new efl_io_sizer_resize_delegate(resize);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_io_sizer_resize"), func = Marshal.GetFunctionPointerForDelegate(efl_io_sizer_resize_static_delegate)});
      if (efl_io_writer_can_write_get_static_delegate == null)
      efl_io_writer_can_write_get_static_delegate = new efl_io_writer_can_write_get_delegate(can_write_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_io_writer_can_write_get"), func = Marshal.GetFunctionPointerForDelegate(efl_io_writer_can_write_get_static_delegate)});
      if (efl_io_writer_can_write_set_static_delegate == null)
      efl_io_writer_can_write_set_static_delegate = new efl_io_writer_can_write_set_delegate(can_write_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_io_writer_can_write_set"), func = Marshal.GetFunctionPointerForDelegate(efl_io_writer_can_write_set_static_delegate)});
      if (efl_io_writer_write_static_delegate == null)
      efl_io_writer_write_static_delegate = new efl_io_writer_write_delegate(write);
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


    private delegate  uint efl_io_buffer_limit_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  uint efl_io_buffer_limit_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_io_buffer_limit_get_api_delegate> efl_io_buffer_limit_get_ptr = new Efl.Eo.FunctionWrapper<efl_io_buffer_limit_get_api_delegate>(_Module, "efl_io_buffer_limit_get");
    private static  uint limit_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_io_buffer_limit_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   uint _ret_var = default( uint);
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


    private delegate  void efl_io_buffer_limit_set_delegate(System.IntPtr obj, System.IntPtr pd,    uint size);


    public delegate  void efl_io_buffer_limit_set_api_delegate(System.IntPtr obj,    uint size);
    public static Efl.Eo.FunctionWrapper<efl_io_buffer_limit_set_api_delegate> efl_io_buffer_limit_set_ptr = new Efl.Eo.FunctionWrapper<efl_io_buffer_limit_set_api_delegate>(_Module, "efl_io_buffer_limit_set");
    private static  void limit_set(System.IntPtr obj, System.IntPtr pd,   uint size)
   {
      Eina.Log.Debug("function efl_io_buffer_limit_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
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


    private delegate  ulong efl_io_buffer_position_read_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  ulong efl_io_buffer_position_read_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_io_buffer_position_read_get_api_delegate> efl_io_buffer_position_read_get_ptr = new Efl.Eo.FunctionWrapper<efl_io_buffer_position_read_get_api_delegate>(_Module, "efl_io_buffer_position_read_get");
    private static  ulong position_read_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_io_buffer_position_read_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   ulong _ret_var = default( ulong);
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


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_io_buffer_position_read_set_delegate(System.IntPtr obj, System.IntPtr pd,    ulong position);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_io_buffer_position_read_set_api_delegate(System.IntPtr obj,    ulong position);
    public static Efl.Eo.FunctionWrapper<efl_io_buffer_position_read_set_api_delegate> efl_io_buffer_position_read_set_ptr = new Efl.Eo.FunctionWrapper<efl_io_buffer_position_read_set_api_delegate>(_Module, "efl_io_buffer_position_read_set");
    private static bool position_read_set(System.IntPtr obj, System.IntPtr pd,   ulong position)
   {
      Eina.Log.Debug("function efl_io_buffer_position_read_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
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


    private delegate  ulong efl_io_buffer_position_write_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  ulong efl_io_buffer_position_write_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_io_buffer_position_write_get_api_delegate> efl_io_buffer_position_write_get_ptr = new Efl.Eo.FunctionWrapper<efl_io_buffer_position_write_get_api_delegate>(_Module, "efl_io_buffer_position_write_get");
    private static  ulong position_write_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_io_buffer_position_write_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   ulong _ret_var = default( ulong);
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


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_io_buffer_position_write_set_delegate(System.IntPtr obj, System.IntPtr pd,    ulong position);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_io_buffer_position_write_set_api_delegate(System.IntPtr obj,    ulong position);
    public static Efl.Eo.FunctionWrapper<efl_io_buffer_position_write_set_api_delegate> efl_io_buffer_position_write_set_ptr = new Efl.Eo.FunctionWrapper<efl_io_buffer_position_write_set_api_delegate>(_Module, "efl_io_buffer_position_write_set");
    private static bool position_write_set(System.IntPtr obj, System.IntPtr pd,   ulong position)
   {
      Eina.Log.Debug("function efl_io_buffer_position_write_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
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
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
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


    private delegate  void efl_io_buffer_preallocate_delegate(System.IntPtr obj, System.IntPtr pd,    uint size);


    public delegate  void efl_io_buffer_preallocate_api_delegate(System.IntPtr obj,    uint size);
    public static Efl.Eo.FunctionWrapper<efl_io_buffer_preallocate_api_delegate> efl_io_buffer_preallocate_ptr = new Efl.Eo.FunctionWrapper<efl_io_buffer_preallocate_api_delegate>(_Module, "efl_io_buffer_preallocate");
    private static  void preallocate(System.IntPtr obj, System.IntPtr pd,   uint size)
   {
      Eina.Log.Debug("function efl_io_buffer_preallocate was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
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


    private delegate  void efl_io_buffer_adopt_readonly_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Slice slice);


    public delegate  void efl_io_buffer_adopt_readonly_api_delegate(System.IntPtr obj,   Eina.Slice slice);
    public static Efl.Eo.FunctionWrapper<efl_io_buffer_adopt_readonly_api_delegate> efl_io_buffer_adopt_readonly_ptr = new Efl.Eo.FunctionWrapper<efl_io_buffer_adopt_readonly_api_delegate>(_Module, "efl_io_buffer_adopt_readonly");
    private static  void adopt_readonly(System.IntPtr obj, System.IntPtr pd,  Eina.Slice slice)
   {
      Eina.Log.Debug("function efl_io_buffer_adopt_readonly was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
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


    private delegate  void efl_io_buffer_adopt_readwrite_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.RwSlice slice);


    public delegate  void efl_io_buffer_adopt_readwrite_api_delegate(System.IntPtr obj,   Eina.RwSlice slice);
    public static Efl.Eo.FunctionWrapper<efl_io_buffer_adopt_readwrite_api_delegate> efl_io_buffer_adopt_readwrite_ptr = new Efl.Eo.FunctionWrapper<efl_io_buffer_adopt_readwrite_api_delegate>(_Module, "efl_io_buffer_adopt_readwrite");
    private static  void adopt_readwrite(System.IntPtr obj, System.IntPtr pd,  Eina.RwSlice slice)
   {
      Eina.Log.Debug("function efl_io_buffer_adopt_readwrite was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
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


    private delegate  System.IntPtr efl_io_buffer_binbuf_steal_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  System.IntPtr efl_io_buffer_binbuf_steal_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_io_buffer_binbuf_steal_api_delegate> efl_io_buffer_binbuf_steal_ptr = new Efl.Eo.FunctionWrapper<efl_io_buffer_binbuf_steal_api_delegate>(_Module, "efl_io_buffer_binbuf_steal");
    private static  System.IntPtr binbuf_steal(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_io_buffer_binbuf_steal was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
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
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
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
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
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
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
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
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
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


    private delegate  void efl_io_closer_close_on_invalidate_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool close_on_invalidate);


    public delegate  void efl_io_closer_close_on_invalidate_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool close_on_invalidate);
    public static Efl.Eo.FunctionWrapper<efl_io_closer_close_on_invalidate_set_api_delegate> efl_io_closer_close_on_invalidate_set_ptr = new Efl.Eo.FunctionWrapper<efl_io_closer_close_on_invalidate_set_api_delegate>(_Module, "efl_io_closer_close_on_invalidate_set");
    private static  void close_on_invalidate_set(System.IntPtr obj, System.IntPtr pd,  bool close_on_invalidate)
   {
      Eina.Log.Debug("function efl_io_closer_close_on_invalidate_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
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


    private delegate  Eina.Error efl_io_closer_close_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  Eina.Error efl_io_closer_close_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_io_closer_close_api_delegate> efl_io_closer_close_ptr = new Efl.Eo.FunctionWrapper<efl_io_closer_close_api_delegate>(_Module, "efl_io_closer_close");
    private static  Eina.Error close(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_io_closer_close was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   Eina.Error _ret_var = default( Eina.Error);
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


    private delegate  ulong efl_io_positioner_position_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  ulong efl_io_positioner_position_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_io_positioner_position_get_api_delegate> efl_io_positioner_position_get_ptr = new Efl.Eo.FunctionWrapper<efl_io_positioner_position_get_api_delegate>(_Module, "efl_io_positioner_position_get");
    private static  ulong position_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_io_positioner_position_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   ulong _ret_var = default( ulong);
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


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_io_positioner_position_set_delegate(System.IntPtr obj, System.IntPtr pd,    ulong position);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_io_positioner_position_set_api_delegate(System.IntPtr obj,    ulong position);
    public static Efl.Eo.FunctionWrapper<efl_io_positioner_position_set_api_delegate> efl_io_positioner_position_set_ptr = new Efl.Eo.FunctionWrapper<efl_io_positioner_position_set_api_delegate>(_Module, "efl_io_positioner_position_set");
    private static bool position_set(System.IntPtr obj, System.IntPtr pd,   ulong position)
   {
      Eina.Log.Debug("function efl_io_positioner_position_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
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


    private delegate  Eina.Error efl_io_positioner_seek_delegate(System.IntPtr obj, System.IntPtr pd,    long offset,   Efl.Io.PositionerWhence whence);


    public delegate  Eina.Error efl_io_positioner_seek_api_delegate(System.IntPtr obj,    long offset,   Efl.Io.PositionerWhence whence);
    public static Efl.Eo.FunctionWrapper<efl_io_positioner_seek_api_delegate> efl_io_positioner_seek_ptr = new Efl.Eo.FunctionWrapper<efl_io_positioner_seek_api_delegate>(_Module, "efl_io_positioner_seek");
    private static  Eina.Error seek(System.IntPtr obj, System.IntPtr pd,   long offset,  Efl.Io.PositionerWhence whence)
   {
      Eina.Log.Debug("function efl_io_positioner_seek was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                       Eina.Error _ret_var = default( Eina.Error);
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
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
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


    private delegate  void efl_io_reader_can_read_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool can_read);


    public delegate  void efl_io_reader_can_read_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool can_read);
    public static Efl.Eo.FunctionWrapper<efl_io_reader_can_read_set_api_delegate> efl_io_reader_can_read_set_ptr = new Efl.Eo.FunctionWrapper<efl_io_reader_can_read_set_api_delegate>(_Module, "efl_io_reader_can_read_set");
    private static  void can_read_set(System.IntPtr obj, System.IntPtr pd,  bool can_read)
   {
      Eina.Log.Debug("function efl_io_reader_can_read_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
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
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
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


    private delegate  void efl_io_reader_eos_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool is_eos);


    public delegate  void efl_io_reader_eos_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool is_eos);
    public static Efl.Eo.FunctionWrapper<efl_io_reader_eos_set_api_delegate> efl_io_reader_eos_set_ptr = new Efl.Eo.FunctionWrapper<efl_io_reader_eos_set_api_delegate>(_Module, "efl_io_reader_eos_set");
    private static  void eos_set(System.IntPtr obj, System.IntPtr pd,  bool is_eos)
   {
      Eina.Log.Debug("function efl_io_reader_eos_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
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


    private delegate  Eina.Error efl_io_reader_read_delegate(System.IntPtr obj, System.IntPtr pd,   ref Eina.RwSlice rw_slice);


    public delegate  Eina.Error efl_io_reader_read_api_delegate(System.IntPtr obj,   ref Eina.RwSlice rw_slice);
    public static Efl.Eo.FunctionWrapper<efl_io_reader_read_api_delegate> efl_io_reader_read_ptr = new Efl.Eo.FunctionWrapper<efl_io_reader_read_api_delegate>(_Module, "efl_io_reader_read");
    private static  Eina.Error read(System.IntPtr obj, System.IntPtr pd,  ref Eina.RwSlice rw_slice)
   {
      Eina.Log.Debug("function efl_io_reader_read was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                     Eina.Error _ret_var = default( Eina.Error);
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


    private delegate  ulong efl_io_sizer_size_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  ulong efl_io_sizer_size_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_io_sizer_size_get_api_delegate> efl_io_sizer_size_get_ptr = new Efl.Eo.FunctionWrapper<efl_io_sizer_size_get_api_delegate>(_Module, "efl_io_sizer_size_get");
    private static  ulong size_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_io_sizer_size_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   ulong _ret_var = default( ulong);
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


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_io_sizer_size_set_delegate(System.IntPtr obj, System.IntPtr pd,    ulong size);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_io_sizer_size_set_api_delegate(System.IntPtr obj,    ulong size);
    public static Efl.Eo.FunctionWrapper<efl_io_sizer_size_set_api_delegate> efl_io_sizer_size_set_ptr = new Efl.Eo.FunctionWrapper<efl_io_sizer_size_set_api_delegate>(_Module, "efl_io_sizer_size_set");
    private static bool size_set(System.IntPtr obj, System.IntPtr pd,   ulong size)
   {
      Eina.Log.Debug("function efl_io_sizer_size_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
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


    private delegate  Eina.Error efl_io_sizer_resize_delegate(System.IntPtr obj, System.IntPtr pd,    ulong size);


    public delegate  Eina.Error efl_io_sizer_resize_api_delegate(System.IntPtr obj,    ulong size);
    public static Efl.Eo.FunctionWrapper<efl_io_sizer_resize_api_delegate> efl_io_sizer_resize_ptr = new Efl.Eo.FunctionWrapper<efl_io_sizer_resize_api_delegate>(_Module, "efl_io_sizer_resize");
    private static  Eina.Error resize(System.IntPtr obj, System.IntPtr pd,   ulong size)
   {
      Eina.Log.Debug("function efl_io_sizer_resize was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                     Eina.Error _ret_var = default( Eina.Error);
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
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
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


    private delegate  void efl_io_writer_can_write_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool can_write);


    public delegate  void efl_io_writer_can_write_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool can_write);
    public static Efl.Eo.FunctionWrapper<efl_io_writer_can_write_set_api_delegate> efl_io_writer_can_write_set_ptr = new Efl.Eo.FunctionWrapper<efl_io_writer_can_write_set_api_delegate>(_Module, "efl_io_writer_can_write_set");
    private static  void can_write_set(System.IntPtr obj, System.IntPtr pd,  bool can_write)
   {
      Eina.Log.Debug("function efl_io_writer_can_write_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
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


    private delegate  Eina.Error efl_io_writer_write_delegate(System.IntPtr obj, System.IntPtr pd,   ref Eina.Slice slice,   ref Eina.Slice remaining);


    public delegate  Eina.Error efl_io_writer_write_api_delegate(System.IntPtr obj,   ref Eina.Slice slice,   ref Eina.Slice remaining);
    public static Efl.Eo.FunctionWrapper<efl_io_writer_write_api_delegate> efl_io_writer_write_ptr = new Efl.Eo.FunctionWrapper<efl_io_writer_write_api_delegate>(_Module, "efl_io_writer_write");
    private static  Eina.Error write(System.IntPtr obj, System.IntPtr pd,  ref Eina.Slice slice,  ref Eina.Slice remaining)
   {
      Eina.Log.Debug("function efl_io_writer_write was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                 remaining = default(Eina.Slice);                      Eina.Error _ret_var = default( Eina.Error);
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
