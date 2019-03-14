#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Io { 
/// <summary>Generic interface for objects that can write data from a provided memory.
/// This interface allows external objects to transparently write data to this object and be notified whether more data can be written or if it&apos;s reached capacity.
/// 
/// Calls to <see cref="Efl.Io.Writer.Write"/> may or may not block: that&apos;s not up to this interface to specify. The user can check with event &quot;can_write,changed&quot; or property <see cref="Efl.Io.Writer.CanWrite"/> to known whenever a write could push more data.
/// 1.19</summary>
[WriterNativeInherit]
public interface Writer : 
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>If <c>true</c> will notify <see cref="Efl.Io.Writer.Write"/> can be called without blocking or failing.
/// 1.19</summary>
/// <returns><c>true</c> if it can be written without blocking or failure, <c>false</c> otherwise
/// 1.19</returns>
bool GetCanWrite();
   /// <summary>If <c>true</c> will notify <see cref="Efl.Io.Writer.Write"/> can be called without blocking or failing.
/// 1.19</summary>
/// <param name="can_write"><c>true</c> if it can be written without blocking or failure, <c>false</c> otherwise
/// 1.19</param>
/// <returns></returns>
 void SetCanWrite( bool can_write);
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
 Eina.Error Write( ref Eina.Slice slice,  ref Eina.Slice remaining);
            /// <summary>Notifies can_write property changed.
   /// If <see cref="Efl.Io.Writer.CanWrite"/> is <c>true</c> there is data to <see cref="Efl.Io.Writer.Write"/> without blocking/error. If <see cref="Efl.Io.Writer.CanWrite"/> is <c>false</c>, <see cref="Efl.Io.Writer.Write"/> would either block or fail.
   /// 
   /// Note that usually this event is dispatched from inside <see cref="Efl.Io.Writer.Write"/>, thus before it returns.
   /// 1.19</summary>
   event EventHandler<Efl.Io.WriterCan_writeChangedEvt_Args> Can_writeChangedEvt;
   /// <summary>If <c>true</c> will notify <see cref="Efl.Io.Writer.Write"/> can be called without blocking or failing.
/// 1.19</summary>
/// <value><c>true</c> if it can be written without blocking or failure, <c>false</c> otherwise
/// 1.19</value>
   bool CanWrite {
      get ;
      set ;
   }
}
///<summary>Event argument wrapper for event <see cref="Efl.Io.Writer.Can_writeChangedEvt"/>.</summary>
public class WriterCan_writeChangedEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public bool arg { get; set; }
}
/// <summary>Generic interface for objects that can write data from a provided memory.
/// This interface allows external objects to transparently write data to this object and be notified whether more data can be written or if it&apos;s reached capacity.
/// 
/// Calls to <see cref="Efl.Io.Writer.Write"/> may or may not block: that&apos;s not up to this interface to specify. The user can check with event &quot;can_write,changed&quot; or property <see cref="Efl.Io.Writer.CanWrite"/> to known whenever a write could push more data.
/// 1.19</summary>
sealed public class WriterConcrete : 

Writer
   
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (WriterConcrete))
            return Efl.Io.WriterNativeInherit.GetEflClassStatic();
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
      efl_io_writer_interface_get();
   ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
   public WriterConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~WriterConcrete()
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
   public static WriterConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new WriterConcrete(obj.NativeHandle);
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

    void register_event_proxies()
   {
      evt_Can_writeChangedEvt_delegate = new Efl.EventCb(on_Can_writeChangedEvt_NativeCallback);
   }
   /// <summary>If <c>true</c> will notify <see cref="Efl.Io.Writer.Write"/> can be called without blocking or failing.
   /// 1.19</summary>
   /// <returns><c>true</c> if it can be written without blocking or failure, <c>false</c> otherwise
   /// 1.19</returns>
   public bool GetCanWrite() {
       var _ret_var = Efl.Io.WriterNativeInherit.efl_io_writer_can_write_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>If <c>true</c> will notify <see cref="Efl.Io.Writer.Write"/> can be called without blocking or failing.
   /// 1.19</summary>
   /// <param name="can_write"><c>true</c> if it can be written without blocking or failure, <c>false</c> otherwise
   /// 1.19</param>
   /// <returns></returns>
   public  void SetCanWrite( bool can_write) {
                         Efl.Io.WriterNativeInherit.efl_io_writer_can_write_set_ptr.Value.Delegate(this.NativeHandle, can_write);
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
   public  Eina.Error Write( ref Eina.Slice slice,  ref Eina.Slice remaining) {
                                           var _ret_var = Efl.Io.WriterNativeInherit.efl_io_writer_write_ptr.Value.Delegate(this.NativeHandle, ref slice,  ref remaining);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }
   /// <summary>If <c>true</c> will notify <see cref="Efl.Io.Writer.Write"/> can be called without blocking or failing.
/// 1.19</summary>
/// <value><c>true</c> if it can be written without blocking or failure, <c>false</c> otherwise
/// 1.19</value>
   public bool CanWrite {
      get { return GetCanWrite(); }
      set { SetCanWrite( value); }
   }
}
public class WriterNativeInherit  : Efl.Eo.NativeClass{
   public  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Efl);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      if (efl_io_writer_can_write_get_static_delegate == null)
      efl_io_writer_can_write_get_static_delegate = new efl_io_writer_can_write_get_delegate(can_write_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_io_writer_can_write_get"), func = Marshal.GetFunctionPointerForDelegate(efl_io_writer_can_write_get_static_delegate)});
      if (efl_io_writer_can_write_set_static_delegate == null)
      efl_io_writer_can_write_set_static_delegate = new efl_io_writer_can_write_set_delegate(can_write_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_io_writer_can_write_set"), func = Marshal.GetFunctionPointerForDelegate(efl_io_writer_can_write_set_static_delegate)});
      if (efl_io_writer_write_static_delegate == null)
      efl_io_writer_write_static_delegate = new efl_io_writer_write_delegate(write);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_io_writer_write"), func = Marshal.GetFunctionPointerForDelegate(efl_io_writer_write_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Io.WriterConcrete.efl_io_writer_interface_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.Io.WriterConcrete.efl_io_writer_interface_get();
   }


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
            _ret_var = ((Writer)wrapper).GetCanWrite();
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
            ((Writer)wrapper).SetCanWrite( can_write);
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
            _ret_var = ((Writer)wrapper).Write( ref slice,  ref remaining);
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
