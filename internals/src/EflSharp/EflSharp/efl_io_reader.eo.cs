#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Io { 
/// <summary>Generic interface for objects that can read data into a provided memory.
/// This interface allows external objects to transparently monitor for new data and as it to be read into a provided memory slice.
/// 
/// Calls to <see cref="Efl.Io.Reader.Read"/> may or may not block, that&apos;s not up to this interface to specify. The user can check based on <see cref="Efl.Io.Reader.Eos"/> property and signal if the stream reached an end, with event &quot;can_read,changed&quot; or property <see cref="Efl.Io.Reader.CanRead"/> to known whenever a read would have data to return.
/// 1.19</summary>
[ReaderNativeInherit]
public interface Reader : 
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>If <c>true</c> will notify <see cref="Efl.Io.Reader.Read"/> can be called without blocking or failing.
/// 1.19</summary>
/// <returns><c>true</c> if it can be read without blocking or failing, <c>false</c> otherwise
/// 1.19</returns>
bool GetCanRead();
   /// <summary>If <c>true</c> will notify <see cref="Efl.Io.Reader.Read"/> can be called without blocking or failing.
/// 1.19</summary>
/// <param name="can_read"><c>true</c> if it can be read without blocking or failing, <c>false</c> otherwise
/// 1.19</param>
/// <returns></returns>
 void SetCanRead( bool can_read);
   /// <summary>If <c>true</c> will notify end of stream.
/// 1.19</summary>
/// <returns><c>true</c> if end of stream, <c>false</c> otherwise
/// 1.19</returns>
bool GetEos();
   /// <summary>If <c>true</c> will notify end of stream.
/// 1.19</summary>
/// <param name="is_eos"><c>true</c> if end of stream, <c>false</c> otherwise
/// 1.19</param>
/// <returns></returns>
 void SetEos( bool is_eos);
   /// <summary>Reads data into a pre-allocated buffer.
/// This operation will be executed immediately and may or may not block the caller thread for some time. The details of blocking behavior is to be defined by the implementation and may be subject to other parameters such as non-blocking flags, maximum timeout or even retry attempts.
/// 
/// You can understand this method as read(2) libc function.
/// 1.19</summary>
/// <param name="rw_slice">Provides a pre-allocated memory to be filled up to rw_slice.len. It will be populated and the length will be set to the actually used amount of bytes, which can be smaller than the request.
/// 1.19</param>
/// <returns>0 on succeed, a mapping of errno otherwise
/// 1.19</returns>
 Eina.Error Read( ref Eina.RwSlice rw_slice);
                  /// <summary>Notifies can_read property changed.
   /// If <see cref="Efl.Io.Reader.CanRead"/> is <c>true</c> there is data to <see cref="Efl.Io.Reader.Read"/> without blocking/error. If <see cref="Efl.Io.Reader.CanRead"/> is <c>false</c>, <see cref="Efl.Io.Reader.Read"/> would either block or fail.
   /// 
   /// Note that usually this event is dispatched from inside <see cref="Efl.Io.Reader.Read"/>, thus before it returns.
   /// 1.19</summary>
   event EventHandler<Efl.Io.ReaderCan_readChangedEvt_Args> Can_readChangedEvt;
   /// <summary>Notifies end of stream, when property is marked as true.
   /// If this is used alongside with an <see cref="Efl.Io.Closer"/>, then it should be emitted before that call.
   /// 
   /// It should be emitted only once for an object unless it implements <see cref="Efl.Io.Positioner.Seek"/>.
   /// 
   /// The property <see cref="Efl.Io.Reader.CanRead"/> should change to <c>false</c> before this event is dispatched.
   /// 1.19</summary>
   event EventHandler EosEvt;
   /// <summary>If <c>true</c> will notify <see cref="Efl.Io.Reader.Read"/> can be called without blocking or failing.
/// 1.19</summary>
/// <value><c>true</c> if it can be read without blocking or failing, <c>false</c> otherwise
/// 1.19</value>
   bool CanRead {
      get ;
      set ;
   }
   /// <summary>If <c>true</c> will notify end of stream.
/// 1.19</summary>
/// <value><c>true</c> if end of stream, <c>false</c> otherwise
/// 1.19</value>
   bool Eos {
      get ;
      set ;
   }
}
///<summary>Event argument wrapper for event <see cref="Efl.Io.Reader.Can_readChangedEvt"/>.</summary>
public class ReaderCan_readChangedEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public bool arg { get; set; }
}
/// <summary>Generic interface for objects that can read data into a provided memory.
/// This interface allows external objects to transparently monitor for new data and as it to be read into a provided memory slice.
/// 
/// Calls to <see cref="Efl.Io.Reader.Read"/> may or may not block, that&apos;s not up to this interface to specify. The user can check based on <see cref="Efl.Io.Reader.Eos"/> property and signal if the stream reached an end, with event &quot;can_read,changed&quot; or property <see cref="Efl.Io.Reader.CanRead"/> to known whenever a read would have data to return.
/// 1.19</summary>
sealed public class ReaderConcrete : 

Reader
   
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (ReaderConcrete))
            return Efl.Io.ReaderNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
      }
   }
   private EventHandlerList eventHandlers = new EventHandlerList();
   private  System.IntPtr handle;
   ///<summary>Pointer to the native instance.</summary>
   public System.IntPtr NativeHandle {
      get { return handle; }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] internal static extern System.IntPtr
      efl_io_reader_interface_get();
   ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
   public ReaderConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~ReaderConcrete()
   {
      Dispose(false);
   }
   ///<summary>Releases the underlying native instance.</summary>
   void Dispose(bool disposing)
   {
      if (handle != System.IntPtr.Zero) {
         Efl.Eo.Globals.efl_unref(handle);
         handle = System.IntPtr.Zero;
      }
   }
   ///<summary>Releases the underlying native instance.</summary>
   public void Dispose()
   {
      Dispose(true);
      GC.SuppressFinalize(this);
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public static ReaderConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new ReaderConcrete(obj.NativeHandle);
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
   private readonly object eventLock = new object();
   private Dictionary<string, int> event_cb_count = new Dictionary<string, int>();
   private bool add_cpp_event_handler(string lib, string key, Efl.EventCb evt_delegate) {
      int event_count = 0;
      if (!event_cb_count.TryGetValue(key, out event_count))
         event_cb_count[key] = event_count;
      if (event_count == 0) {
         IntPtr desc = Efl.EventDescription.GetNative(lib, key);
         if (desc == IntPtr.Zero) {
            Eina.Log.Error($"Failed to get native event {key}");
            return false;
         }
          bool result = Efl.Eo.Globals.efl_event_callback_priority_add(handle, desc, 0, evt_delegate, System.IntPtr.Zero);
         if (!result) {
            Eina.Log.Error($"Failed to add event proxy for event {key}");
            return false;
         }
         Eina.Error.RaiseIfUnhandledException();
      } 
      event_cb_count[key]++;
      return true;
   }
   private bool remove_cpp_event_handler(string key, Efl.EventCb evt_delegate) {
      int event_count = 0;
      if (!event_cb_count.TryGetValue(key, out event_count))
         event_cb_count[key] = event_count;
      if (event_count == 1) {
         IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
         if (desc == IntPtr.Zero) {
            Eina.Log.Error($"Failed to get native event {key}");
            return false;
         }
         bool result = Efl.Eo.Globals.efl_event_callback_del(handle, desc, evt_delegate, System.IntPtr.Zero);
         if (!result) {
            Eina.Log.Error($"Failed to remove event proxy for event {key}");
            return false;
         }
         Eina.Error.RaiseIfUnhandledException();
      } else if (event_count == 0) {
         Eina.Log.Error($"Trying to remove proxy for event {key} when there is nothing registered.");
         return false;
      } 
      event_cb_count[key]--;
      return true;
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

    void register_event_proxies()
   {
      evt_Can_readChangedEvt_delegate = new Efl.EventCb(on_Can_readChangedEvt_NativeCallback);
      evt_EosEvt_delegate = new Efl.EventCb(on_EosEvt_NativeCallback);
   }
   /// <summary>If <c>true</c> will notify <see cref="Efl.Io.Reader.Read"/> can be called without blocking or failing.
   /// 1.19</summary>
   /// <returns><c>true</c> if it can be read without blocking or failing, <c>false</c> otherwise
   /// 1.19</returns>
   public bool GetCanRead() {
       var _ret_var = Efl.Io.ReaderNativeInherit.efl_io_reader_can_read_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>If <c>true</c> will notify <see cref="Efl.Io.Reader.Read"/> can be called without blocking or failing.
   /// 1.19</summary>
   /// <param name="can_read"><c>true</c> if it can be read without blocking or failing, <c>false</c> otherwise
   /// 1.19</param>
   /// <returns></returns>
   public  void SetCanRead( bool can_read) {
                         Efl.Io.ReaderNativeInherit.efl_io_reader_can_read_set_ptr.Value.Delegate(this.NativeHandle, can_read);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>If <c>true</c> will notify end of stream.
   /// 1.19</summary>
   /// <returns><c>true</c> if end of stream, <c>false</c> otherwise
   /// 1.19</returns>
   public bool GetEos() {
       var _ret_var = Efl.Io.ReaderNativeInherit.efl_io_reader_eos_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>If <c>true</c> will notify end of stream.
   /// 1.19</summary>
   /// <param name="is_eos"><c>true</c> if end of stream, <c>false</c> otherwise
   /// 1.19</param>
   /// <returns></returns>
   public  void SetEos( bool is_eos) {
                         Efl.Io.ReaderNativeInherit.efl_io_reader_eos_set_ptr.Value.Delegate(this.NativeHandle, is_eos);
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
   public  Eina.Error Read( ref Eina.RwSlice rw_slice) {
                         var _ret_var = Efl.Io.ReaderNativeInherit.efl_io_reader_read_ptr.Value.Delegate(this.NativeHandle, ref rw_slice);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
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
}
public class ReaderNativeInherit  : Efl.Eo.NativeClass{
   public  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Efl);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
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
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Io.ReaderConcrete.efl_io_reader_interface_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.Io.ReaderConcrete.efl_io_reader_interface_get();
   }


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
            _ret_var = ((Reader)wrapper).GetCanRead();
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
            ((Reader)wrapper).SetCanRead( can_read);
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
            _ret_var = ((Reader)wrapper).GetEos();
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
            ((Reader)wrapper).SetEos( is_eos);
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
            _ret_var = ((Reader)wrapper).Read( ref rw_slice);
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
}
} } 
