#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Io { 
/// <summary>Generic interface for objects that can close themselves.
/// This interface allows external objects to transparently close an input or output stream, cleaning up its resources.
/// 
/// Calls to <see cref="Efl.Io.Closer.Close"/> may or may not block, that&apos;s not up to this interface to specify.
/// 1.19</summary>
[CloserNativeInherit]
public interface Closer : 
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>If true will notify object was closed.
/// 1.19</summary>
/// <returns><c>true</c> if closed, <c>false</c> otherwise
/// 1.19</returns>
bool GetClosed();
   /// <summary>If true will automatically close resources on exec() calls.
/// When using file descriptors this should set FD_CLOEXEC so they are not inherited by the processes (children or self) doing exec().
/// 1.19</summary>
/// <returns><c>true</c> if close on exec(), <c>false</c> otherwise
/// 1.19</returns>
bool GetCloseOnExec();
   /// <summary>If <c>true</c>, will close on exec() call.
/// 1.19</summary>
/// <param name="close_on_exec"><c>true</c> if close on exec(), <c>false</c> otherwise
/// 1.19</param>
/// <returns><c>true</c> if could set, <c>false</c> if not supported or failed.
/// 1.19</returns>
bool SetCloseOnExec( bool close_on_exec);
   /// <summary>If true will automatically close() on object invalidate.
/// If the object was disconnected from its parent (including the main loop) without close, this property will state whenever it should be closed or not.
/// 1.19</summary>
/// <returns><c>true</c> if close on invalidate, <c>false</c> otherwise
/// 1.19</returns>
bool GetCloseOnInvalidate();
   /// <summary>If true will automatically close() on object invalidate.
/// If the object was disconnected from its parent (including the main loop) without close, this property will state whenever it should be closed or not.
/// 1.19</summary>
/// <param name="close_on_invalidate"><c>true</c> if close on invalidate, <c>false</c> otherwise
/// 1.19</param>
/// <returns></returns>
 void SetCloseOnInvalidate( bool close_on_invalidate);
   /// <summary>Closes the Input/Output object.
/// This operation will be executed immediately and may or may not block the caller thread for some time. The details of blocking behavior is to be defined by the implementation and may be subject to other parameters such as non-blocking flags, maximum timeout or even retry attempts.
/// 
/// You can understand this method as close(2) libc function.
/// 1.19</summary>
/// <returns>0 on succeed, a mapping of errno otherwise
/// 1.19</returns>
 Eina.Error Close();
                     /// <summary>Notifies closed, when property is marked as true
   /// 1.19</summary>
   event EventHandler ClosedEvt;
   /// <summary>If true will notify object was closed.
/// 1.19</summary>
/// <value><c>true</c> if closed, <c>false</c> otherwise
/// 1.19</value>
   bool Closed {
      get ;
   }
   /// <summary>If true will automatically close resources on exec() calls.
/// When using file descriptors this should set FD_CLOEXEC so they are not inherited by the processes (children or self) doing exec().
/// 1.19</summary>
/// <value><c>true</c> if close on exec(), <c>false</c> otherwise
/// 1.19</value>
   bool CloseOnExec {
      get ;
      set ;
   }
   /// <summary>If true will automatically close() on object invalidate.
/// If the object was disconnected from its parent (including the main loop) without close, this property will state whenever it should be closed or not.
/// 1.19</summary>
/// <value><c>true</c> if close on invalidate, <c>false</c> otherwise
/// 1.19</value>
   bool CloseOnInvalidate {
      get ;
      set ;
   }
}
/// <summary>Generic interface for objects that can close themselves.
/// This interface allows external objects to transparently close an input or output stream, cleaning up its resources.
/// 
/// Calls to <see cref="Efl.Io.Closer.Close"/> may or may not block, that&apos;s not up to this interface to specify.
/// 1.19</summary>
sealed public class CloserConcrete : 

Closer
   
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (CloserConcrete))
            return Efl.Io.CloserNativeInherit.GetEflClassStatic();
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
      efl_io_closer_interface_get();
   ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
   public CloserConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~CloserConcrete()
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
   public static CloserConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new CloserConcrete(obj.NativeHandle);
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

    void register_event_proxies()
   {
      evt_ClosedEvt_delegate = new Efl.EventCb(on_ClosedEvt_NativeCallback);
   }
   /// <summary>If true will notify object was closed.
   /// 1.19</summary>
   /// <returns><c>true</c> if closed, <c>false</c> otherwise
   /// 1.19</returns>
   public bool GetClosed() {
       var _ret_var = Efl.Io.CloserNativeInherit.efl_io_closer_closed_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>If true will automatically close resources on exec() calls.
   /// When using file descriptors this should set FD_CLOEXEC so they are not inherited by the processes (children or self) doing exec().
   /// 1.19</summary>
   /// <returns><c>true</c> if close on exec(), <c>false</c> otherwise
   /// 1.19</returns>
   public bool GetCloseOnExec() {
       var _ret_var = Efl.Io.CloserNativeInherit.efl_io_closer_close_on_exec_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>If <c>true</c>, will close on exec() call.
   /// 1.19</summary>
   /// <param name="close_on_exec"><c>true</c> if close on exec(), <c>false</c> otherwise
   /// 1.19</param>
   /// <returns><c>true</c> if could set, <c>false</c> if not supported or failed.
   /// 1.19</returns>
   public bool SetCloseOnExec( bool close_on_exec) {
                         var _ret_var = Efl.Io.CloserNativeInherit.efl_io_closer_close_on_exec_set_ptr.Value.Delegate(this.NativeHandle, close_on_exec);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>If true will automatically close() on object invalidate.
   /// If the object was disconnected from its parent (including the main loop) without close, this property will state whenever it should be closed or not.
   /// 1.19</summary>
   /// <returns><c>true</c> if close on invalidate, <c>false</c> otherwise
   /// 1.19</returns>
   public bool GetCloseOnInvalidate() {
       var _ret_var = Efl.Io.CloserNativeInherit.efl_io_closer_close_on_invalidate_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>If true will automatically close() on object invalidate.
   /// If the object was disconnected from its parent (including the main loop) without close, this property will state whenever it should be closed or not.
   /// 1.19</summary>
   /// <param name="close_on_invalidate"><c>true</c> if close on invalidate, <c>false</c> otherwise
   /// 1.19</param>
   /// <returns></returns>
   public  void SetCloseOnInvalidate( bool close_on_invalidate) {
                         Efl.Io.CloserNativeInherit.efl_io_closer_close_on_invalidate_set_ptr.Value.Delegate(this.NativeHandle, close_on_invalidate);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Closes the Input/Output object.
   /// This operation will be executed immediately and may or may not block the caller thread for some time. The details of blocking behavior is to be defined by the implementation and may be subject to other parameters such as non-blocking flags, maximum timeout or even retry attempts.
   /// 
   /// You can understand this method as close(2) libc function.
   /// 1.19</summary>
   /// <returns>0 on succeed, a mapping of errno otherwise
   /// 1.19</returns>
   public  Eina.Error Close() {
       var _ret_var = Efl.Io.CloserNativeInherit.efl_io_closer_close_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
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
}
public class CloserNativeInherit  : Efl.Eo.NativeClass{
   public  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Efl);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
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
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Io.CloserConcrete.efl_io_closer_interface_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.Io.CloserConcrete.efl_io_closer_interface_get();
   }


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
            _ret_var = ((Closer)wrapper).GetClosed();
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
            _ret_var = ((Closer)wrapper).GetCloseOnExec();
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
            _ret_var = ((Closer)wrapper).SetCloseOnExec( close_on_exec);
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
            _ret_var = ((Closer)wrapper).GetCloseOnInvalidate();
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
            ((Closer)wrapper).SetCloseOnInvalidate( close_on_invalidate);
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
            _ret_var = ((Closer)wrapper).Close();
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
}
} } 
