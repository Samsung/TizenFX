#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Io { 
/// <summary>Generic interface for objects that can change or report position.
/// 1.19</summary>
[PositionerConcreteNativeInherit]
public interface Positioner : 
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>Position property
/// 1.19</summary>
/// <returns>Position in file or buffer
/// 1.19</returns>
 ulong GetPosition();
   /// <summary>Try to set position object, relative to start of file. See <see cref="Efl.Io.Positioner.Seek"/>
/// 1.19</summary>
/// <param name="position">Position in file or buffer
/// 1.19</param>
/// <returns><c>true</c> if could reposition, <c>false</c> if errors.
/// 1.19</returns>
bool SetPosition(  ulong position);
   /// <summary>Seek in data
/// 1.19</summary>
/// <param name="offset">Offset in byte relative to whence
/// 1.19</param>
/// <param name="whence">Whence
/// 1.19</param>
/// <returns>0 on succeed, a mapping of errno otherwise
/// 1.19</returns>
 Eina.Error Seek(  long offset,  Efl.Io.PositionerWhence whence);
            /// <summary>Notifies position changed
   /// 1.19</summary>
   event EventHandler PositionChangedEvt;
   /// <summary>Position property
/// 1.19</summary>
    ulong Position {
      get ;
      set ;
   }
}
/// <summary>Generic interface for objects that can change or report position.
/// 1.19</summary>
sealed public class PositionerConcrete : 

Positioner
   
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (PositionerConcrete))
            return Efl.Io.PositionerConcreteNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   private EventHandlerList eventHandlers = new EventHandlerList();
   private  System.IntPtr handle;
   public Dictionary<String, IntPtr> cached_strings = new Dictionary<String, IntPtr>();
   public Dictionary<String, IntPtr> cached_stringshares = new Dictionary<String, IntPtr>();
   ///<summary>Pointer to the native instance.</summary>
   public System.IntPtr NativeHandle {
      get { return handle; }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] internal static extern System.IntPtr
      efl_io_positioner_mixin_get();
   ///<summary>Constructs an instance from a native pointer.</summary>
   public PositionerConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~PositionerConcrete()
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
   Efl.Eo.Globals.free_dict_values(cached_strings);
   Efl.Eo.Globals.free_stringshare_values(cached_stringshares);
      Dispose(true);
      GC.SuppressFinalize(this);
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public static PositionerConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new PositionerConcrete(obj.NativeHandle);
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
   private bool add_cpp_event_handler(string key, Efl.EventCb evt_delegate) {
      int event_count = 0;
      if (!event_cb_count.TryGetValue(key, out event_count))
         event_cb_count[key] = event_count;
      if (event_count == 0) {
         IntPtr desc = Efl.EventDescription.GetNative(key);
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
         IntPtr desc = Efl.EventDescription.GetNative(key);
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
private static object PositionChangedEvtKey = new object();
   /// <summary>Notifies position changed
   /// 1.19</summary>
   public event EventHandler PositionChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_IO_POSITIONER_EVENT_POSITION_CHANGED";
            if (add_cpp_event_handler(key, this.evt_PositionChangedEvt_delegate)) {
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

    void register_event_proxies()
   {
      evt_PositionChangedEvt_delegate = new Efl.EventCb(on_PositionChangedEvt_NativeCallback);
   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  ulong efl_io_positioner_position_get(System.IntPtr obj);
   /// <summary>Position property
   /// 1.19</summary>
   /// <returns>Position in file or buffer
   /// 1.19</returns>
   public  ulong GetPosition() {
       var _ret_var = efl_io_positioner_position_get(Efl.Io.PositionerConcrete.efl_io_positioner_mixin_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_io_positioner_position_set(System.IntPtr obj,    ulong position);
   /// <summary>Try to set position object, relative to start of file. See <see cref="Efl.Io.Positioner.Seek"/>
   /// 1.19</summary>
   /// <param name="position">Position in file or buffer
   /// 1.19</param>
   /// <returns><c>true</c> if could reposition, <c>false</c> if errors.
   /// 1.19</returns>
   public bool SetPosition(  ulong position) {
                         var _ret_var = efl_io_positioner_position_set(Efl.Io.PositionerConcrete.efl_io_positioner_mixin_get(),  position);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  Eina.Error efl_io_positioner_seek(System.IntPtr obj,    long offset,   Efl.Io.PositionerWhence whence);
   /// <summary>Seek in data
   /// 1.19</summary>
   /// <param name="offset">Offset in byte relative to whence
   /// 1.19</param>
   /// <param name="whence">Whence
   /// 1.19</param>
   /// <returns>0 on succeed, a mapping of errno otherwise
   /// 1.19</returns>
   public  Eina.Error Seek(  long offset,  Efl.Io.PositionerWhence whence) {
                                           var _ret_var = efl_io_positioner_seek(Efl.Io.PositionerConcrete.efl_io_positioner_mixin_get(),  offset,  whence);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }
   /// <summary>Position property
/// 1.19</summary>
   public  ulong Position {
      get { return GetPosition(); }
      set { SetPosition( value); }
   }
}
public class PositionerConcreteNativeInherit : Efl.Eo.NativeClass{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_io_positioner_position_get_static_delegate = new efl_io_positioner_position_get_delegate(position_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_io_positioner_position_get"), func = Marshal.GetFunctionPointerForDelegate(efl_io_positioner_position_get_static_delegate)});
      efl_io_positioner_position_set_static_delegate = new efl_io_positioner_position_set_delegate(position_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_io_positioner_position_set"), func = Marshal.GetFunctionPointerForDelegate(efl_io_positioner_position_set_static_delegate)});
      efl_io_positioner_seek_static_delegate = new efl_io_positioner_seek_delegate(seek);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_io_positioner_seek"), func = Marshal.GetFunctionPointerForDelegate(efl_io_positioner_seek_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Io.PositionerConcrete.efl_io_positioner_mixin_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.Io.PositionerConcrete.efl_io_positioner_mixin_get();
   }


    private delegate  ulong efl_io_positioner_position_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  ulong efl_io_positioner_position_get(System.IntPtr obj);
    private static  ulong position_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_io_positioner_position_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   ulong _ret_var = default( ulong);
         try {
            _ret_var = ((PositionerConcrete)wrapper).GetPosition();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_io_positioner_position_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_io_positioner_position_get_delegate efl_io_positioner_position_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_io_positioner_position_set_delegate(System.IntPtr obj, System.IntPtr pd,    ulong position);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_io_positioner_position_set(System.IntPtr obj,    ulong position);
    private static bool position_set(System.IntPtr obj, System.IntPtr pd,   ulong position)
   {
      Eina.Log.Debug("function efl_io_positioner_position_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((PositionerConcrete)wrapper).SetPosition( position);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_io_positioner_position_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  position);
      }
   }
   private efl_io_positioner_position_set_delegate efl_io_positioner_position_set_static_delegate;


    private delegate  Eina.Error efl_io_positioner_seek_delegate(System.IntPtr obj, System.IntPtr pd,    long offset,   Efl.Io.PositionerWhence whence);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  Eina.Error efl_io_positioner_seek(System.IntPtr obj,    long offset,   Efl.Io.PositionerWhence whence);
    private static  Eina.Error seek(System.IntPtr obj, System.IntPtr pd,   long offset,  Efl.Io.PositionerWhence whence)
   {
      Eina.Log.Debug("function efl_io_positioner_seek was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                       Eina.Error _ret_var = default( Eina.Error);
         try {
            _ret_var = ((PositionerConcrete)wrapper).Seek( offset,  whence);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_io_positioner_seek(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  offset,  whence);
      }
   }
   private efl_io_positioner_seek_delegate efl_io_positioner_seek_static_delegate;
}
} } 
namespace Efl { namespace Io { 
/// <summary>Seek position modes</summary>
public enum PositionerWhence
{
/// <summary>Seek from start of the stream/file</summary>
Start = 0,
/// <summary>Seek from current position</summary>
Current = 1,
/// <summary>Seek from the end of stream/file</summary>
End = 2,
}
} } 
