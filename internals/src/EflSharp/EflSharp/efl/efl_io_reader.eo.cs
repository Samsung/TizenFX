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
/// Calls to <see cref="Efl.Io.IReader.Read"/> may or may not block, that&apos;s not up to this interface to specify. The user can check based on <see cref="Efl.Io.IReader.Eos"/> property and signal if the stream reached an end, with event &quot;can_read,changed&quot; or property <see cref="Efl.Io.IReader.CanRead"/> to known whenever a read would have data to return.
/// (Since EFL 1.22)</summary>
[IReaderNativeInherit]
public interface IReader : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>If <c>true</c> will notify <see cref="Efl.Io.IReader.Read"/> can be called without blocking or failing.
/// (Since EFL 1.22)</summary>
/// <returns><c>true</c> if it can be read without blocking or failing, <c>false</c> otherwise</returns>
bool GetCanRead();
    /// <summary>If <c>true</c> will notify <see cref="Efl.Io.IReader.Read"/> can be called without blocking or failing.
/// (Since EFL 1.22)</summary>
/// <param name="can_read"><c>true</c> if it can be read without blocking or failing, <c>false</c> otherwise</param>
/// <returns></returns>
void SetCanRead( bool can_read);
    /// <summary>If <c>true</c> will notify end of stream.
/// (Since EFL 1.22)</summary>
/// <returns><c>true</c> if end of stream, <c>false</c> otherwise</returns>
bool GetEos();
    /// <summary>If <c>true</c> will notify end of stream.
/// (Since EFL 1.22)</summary>
/// <param name="is_eos"><c>true</c> if end of stream, <c>false</c> otherwise</param>
/// <returns></returns>
void SetEos( bool is_eos);
    /// <summary>Reads data into a pre-allocated buffer.
/// This operation will be executed immediately and may or may not block the caller thread for some time. The details of blocking behavior is to be defined by the implementation and may be subject to other parameters such as non-blocking flags, maximum timeout or even retry attempts.
/// 
/// You can understand this method as read(2) libc function.
/// (Since EFL 1.22)</summary>
/// <param name="rw_slice">Provides a pre-allocated memory to be filled up to rw_slice.len. It will be populated and the length will be set to the actually used amount of bytes, which can be smaller than the request.</param>
/// <returns>0 on succeed, a mapping of errno otherwise</returns>
Eina.Error Read( ref Eina.RwSlice rw_slice);
                        /// <summary>Notifies can_read property changed.
    /// If <see cref="Efl.Io.IReader.CanRead"/> is <c>true</c> there is data to <see cref="Efl.Io.IReader.Read"/> without blocking/error. If <see cref="Efl.Io.IReader.CanRead"/> is <c>false</c>, <see cref="Efl.Io.IReader.Read"/> would either block or fail.
    /// 
    /// Note that usually this event is dispatched from inside <see cref="Efl.Io.IReader.Read"/>, thus before it returns.
    /// (Since EFL 1.22)</summary>
    event EventHandler<Efl.Io.IReaderCanReadChangedEvt_Args> CanReadChangedEvt;
    /// <summary>Notifies end of stream, when property is marked as true.
    /// If this is used alongside with an <see cref="Efl.Io.ICloser"/>, then it should be emitted before that call.
    /// 
    /// It should be emitted only once for an object unless it implements <see cref="Efl.Io.IPositioner.Seek"/>.
    /// 
    /// The property <see cref="Efl.Io.IReader.CanRead"/> should change to <c>false</c> before this event is dispatched.
    /// (Since EFL 1.22)</summary>
    event EventHandler EosEvt;
    /// <summary>If <c>true</c> will notify <see cref="Efl.Io.IReader.Read"/> can be called without blocking or failing.
/// (Since EFL 1.22)</summary>
/// <value><c>true</c> if it can be read without blocking or failing, <c>false</c> otherwise</value>
    bool CanRead {
        get ;
        set ;
    }
    /// <summary>If <c>true</c> will notify end of stream.
/// (Since EFL 1.22)</summary>
/// <value><c>true</c> if end of stream, <c>false</c> otherwise</value>
    bool Eos {
        get ;
        set ;
    }
}
///<summary>Event argument wrapper for event <see cref="Efl.Io.IReader.CanReadChangedEvt"/>.</summary>
public class IReaderCanReadChangedEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public bool arg { get; set; }
}
/// <summary>Generic interface for objects that can read data into a provided memory.
/// This interface allows external objects to transparently monitor for new data and as it to be read into a provided memory slice.
/// 
/// Calls to <see cref="Efl.Io.IReader.Read"/> may or may not block, that&apos;s not up to this interface to specify. The user can check based on <see cref="Efl.Io.IReader.Eos"/> property and signal if the stream reached an end, with event &quot;can_read,changed&quot; or property <see cref="Efl.Io.IReader.CanRead"/> to known whenever a read would have data to return.
/// (Since EFL 1.22)</summary>
sealed public class IReaderConcrete : 

IReader
    
{
    ///<summary>Pointer to the native class description.</summary>
    public System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (IReaderConcrete))
                return Efl.Io.IReaderNativeInherit.GetEflClassStatic();
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
    private IReaderConcrete(System.IntPtr raw)
    {
        handle = raw;
        RegisterEventProxies();
    }
    ///<summary>Destructor.</summary>
    ~IReaderConcrete()
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
    ///<summary>Adds a new event handler, registering it to the native event. For internal use only.</summary>
    ///<param name="lib">The name of the native library definining the event.</param>
    ///<param name="key">The name of the native event.</param>
    ///<param name="evt_delegate">The delegate to be called on event raising.</param>
    ///<returns>True if the delegate was successfully registered.</returns>
    private bool AddNativeEventHandler(string lib, string key, Efl.EventCb evt_delegate) {
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
    ///<summary>Removes the given event handler for the given event. For internal use only.</summary>
    ///<param name="key">The name of the native event.</param>
    ///<param name="evt_delegate">The delegate to be removed.</param>
    ///<returns>True if the delegate was successfully registered.</returns>
    private bool RemoveNativeEventHandler(string key, Efl.EventCb evt_delegate) {
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

    ///<summary>Register the Eo event wrappers making the bridge to C# events. Internal usage only.</summary>
     void RegisterEventProxies()
    {
        evt_CanReadChangedEvt_delegate = new Efl.EventCb(on_CanReadChangedEvt_NativeCallback);
        evt_EosEvt_delegate = new Efl.EventCb(on_EosEvt_NativeCallback);
    }
    /// <summary>If <c>true</c> will notify <see cref="Efl.Io.IReader.Read"/> can be called without blocking or failing.
    /// (Since EFL 1.22)</summary>
    /// <returns><c>true</c> if it can be read without blocking or failing, <c>false</c> otherwise</returns>
    public bool GetCanRead() {
         var _ret_var = Efl.Io.IReaderNativeInherit.efl_io_reader_can_read_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>If <c>true</c> will notify <see cref="Efl.Io.IReader.Read"/> can be called without blocking or failing.
    /// (Since EFL 1.22)</summary>
    /// <param name="can_read"><c>true</c> if it can be read without blocking or failing, <c>false</c> otherwise</param>
    /// <returns></returns>
    public void SetCanRead( bool can_read) {
                                 Efl.Io.IReaderNativeInherit.efl_io_reader_can_read_set_ptr.Value.Delegate(this.NativeHandle, can_read);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>If <c>true</c> will notify end of stream.
    /// (Since EFL 1.22)</summary>
    /// <returns><c>true</c> if end of stream, <c>false</c> otherwise</returns>
    public bool GetEos() {
         var _ret_var = Efl.Io.IReaderNativeInherit.efl_io_reader_eos_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>If <c>true</c> will notify end of stream.
    /// (Since EFL 1.22)</summary>
    /// <param name="is_eos"><c>true</c> if end of stream, <c>false</c> otherwise</param>
    /// <returns></returns>
    public void SetEos( bool is_eos) {
                                 Efl.Io.IReaderNativeInherit.efl_io_reader_eos_set_ptr.Value.Delegate(this.NativeHandle, is_eos);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Reads data into a pre-allocated buffer.
    /// This operation will be executed immediately and may or may not block the caller thread for some time. The details of blocking behavior is to be defined by the implementation and may be subject to other parameters such as non-blocking flags, maximum timeout or even retry attempts.
    /// 
    /// You can understand this method as read(2) libc function.
    /// (Since EFL 1.22)</summary>
    /// <param name="rw_slice">Provides a pre-allocated memory to be filled up to rw_slice.len. It will be populated and the length will be set to the actually used amount of bytes, which can be smaller than the request.</param>
    /// <returns>0 on succeed, a mapping of errno otherwise</returns>
    public Eina.Error Read( ref Eina.RwSlice rw_slice) {
                                 var _ret_var = Efl.Io.IReaderNativeInherit.efl_io_reader_read_ptr.Value.Delegate(this.NativeHandle, ref rw_slice);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
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
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Io.IReaderConcrete.efl_io_reader_interface_get();
    }
}
public class IReaderNativeInherit  : Efl.Eo.NativeClass{
    public  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Efl);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
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
        return descs;
    }
    public override IntPtr GetEflClass()
    {
        return Efl.Io.IReaderConcrete.efl_io_reader_interface_get();
    }
    public static  IntPtr GetEflClassStatic()
    {
        return Efl.Io.IReaderConcrete.efl_io_reader_interface_get();
    }


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
                _ret_var = ((IReader)wrapper).GetCanRead();
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
                ((IReader)wrapper).SetCanRead( can_read);
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
                _ret_var = ((IReader)wrapper).GetEos();
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
                ((IReader)wrapper).SetEos( is_eos);
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
                _ret_var = ((IReader)wrapper).Read( ref rw_slice);
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
