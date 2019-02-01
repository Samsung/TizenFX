#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Io { 
/// <summary>Generic interface for objects that can resize or report size of themselves.
/// This interface allows external objects to transparently resize or report its size.
/// 1.19</summary>
[SizerConcreteNativeInherit]
public interface Sizer : 
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>Size property
/// 1.19</summary>
/// <returns>Object size
/// 1.19</returns>
 ulong GetSize();
   /// <summary>Try to resize the object, check with get if the value was accepted or not.
/// 1.19</summary>
/// <param name="size">Object size
/// 1.19</param>
/// <returns><c>true</c> if could resize, <c>false</c> if errors.
/// 1.19</returns>
bool SetSize(  ulong size);
   /// <summary>Resize object
/// 1.19</summary>
/// <param name="size">Object size
/// 1.19</param>
/// <returns>0 on succeed, a mapping of errno otherwise
/// 1.19</returns>
 Eina.Error Resize(  ulong size);
            /// <summary>Notifies size changed
   /// 1.19</summary>
   event EventHandler SizeChangedEvt;
   /// <summary>Size property
/// 1.19</summary>
    ulong Size {
      get ;
      set ;
   }
}
/// <summary>Generic interface for objects that can resize or report size of themselves.
/// This interface allows external objects to transparently resize or report its size.
/// 1.19</summary>
sealed public class SizerConcrete : 

Sizer
   
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (SizerConcrete))
            return Efl.Io.SizerConcreteNativeInherit.GetEflClassStatic();
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
      efl_io_sizer_mixin_get();
   ///<summary>Constructs an instance from a native pointer.</summary>
   public SizerConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~SizerConcrete()
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
   public static SizerConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new SizerConcrete(obj.NativeHandle);
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
private static object SizeChangedEvtKey = new object();
   /// <summary>Notifies size changed
   /// 1.19</summary>
   public event EventHandler SizeChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_IO_SIZER_EVENT_SIZE_CHANGED";
            if (add_cpp_event_handler(key, this.evt_SizeChangedEvt_delegate)) {
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

    void register_event_proxies()
   {
      evt_SizeChangedEvt_delegate = new Efl.EventCb(on_SizeChangedEvt_NativeCallback);
   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  ulong efl_io_sizer_size_get(System.IntPtr obj);
   /// <summary>Size property
   /// 1.19</summary>
   /// <returns>Object size
   /// 1.19</returns>
   public  ulong GetSize() {
       var _ret_var = efl_io_sizer_size_get(Efl.Io.SizerConcrete.efl_io_sizer_mixin_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_io_sizer_size_set(System.IntPtr obj,    ulong size);
   /// <summary>Try to resize the object, check with get if the value was accepted or not.
   /// 1.19</summary>
   /// <param name="size">Object size
   /// 1.19</param>
   /// <returns><c>true</c> if could resize, <c>false</c> if errors.
   /// 1.19</returns>
   public bool SetSize(  ulong size) {
                         var _ret_var = efl_io_sizer_size_set(Efl.Io.SizerConcrete.efl_io_sizer_mixin_get(),  size);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  Eina.Error efl_io_sizer_resize(System.IntPtr obj,    ulong size);
   /// <summary>Resize object
   /// 1.19</summary>
   /// <param name="size">Object size
   /// 1.19</param>
   /// <returns>0 on succeed, a mapping of errno otherwise
   /// 1.19</returns>
   public  Eina.Error Resize(  ulong size) {
                         var _ret_var = efl_io_sizer_resize(Efl.Io.SizerConcrete.efl_io_sizer_mixin_get(),  size);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Size property
/// 1.19</summary>
   public  ulong Size {
      get { return GetSize(); }
      set { SetSize( value); }
   }
}
public class SizerConcreteNativeInherit : Efl.Eo.NativeClass{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_io_sizer_size_get_static_delegate = new efl_io_sizer_size_get_delegate(size_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_io_sizer_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_io_sizer_size_get_static_delegate)});
      efl_io_sizer_size_set_static_delegate = new efl_io_sizer_size_set_delegate(size_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_io_sizer_size_set"), func = Marshal.GetFunctionPointerForDelegate(efl_io_sizer_size_set_static_delegate)});
      efl_io_sizer_resize_static_delegate = new efl_io_sizer_resize_delegate(resize);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_io_sizer_resize"), func = Marshal.GetFunctionPointerForDelegate(efl_io_sizer_resize_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Io.SizerConcrete.efl_io_sizer_mixin_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.Io.SizerConcrete.efl_io_sizer_mixin_get();
   }


    private delegate  ulong efl_io_sizer_size_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  ulong efl_io_sizer_size_get(System.IntPtr obj);
    private static  ulong size_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_io_sizer_size_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   ulong _ret_var = default( ulong);
         try {
            _ret_var = ((SizerConcrete)wrapper).GetSize();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_io_sizer_size_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_io_sizer_size_get_delegate efl_io_sizer_size_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_io_sizer_size_set_delegate(System.IntPtr obj, System.IntPtr pd,    ulong size);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_io_sizer_size_set(System.IntPtr obj,    ulong size);
    private static bool size_set(System.IntPtr obj, System.IntPtr pd,   ulong size)
   {
      Eina.Log.Debug("function efl_io_sizer_size_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((SizerConcrete)wrapper).SetSize( size);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_io_sizer_size_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  size);
      }
   }
   private efl_io_sizer_size_set_delegate efl_io_sizer_size_set_static_delegate;


    private delegate  Eina.Error efl_io_sizer_resize_delegate(System.IntPtr obj, System.IntPtr pd,    ulong size);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  Eina.Error efl_io_sizer_resize(System.IntPtr obj,    ulong size);
    private static  Eina.Error resize(System.IntPtr obj, System.IntPtr pd,   ulong size)
   {
      Eina.Log.Debug("function efl_io_sizer_resize was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                     Eina.Error _ret_var = default( Eina.Error);
         try {
            _ret_var = ((SizerConcrete)wrapper).Resize( size);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_io_sizer_resize(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  size);
      }
   }
   private efl_io_sizer_resize_delegate efl_io_sizer_resize_static_delegate;
}
} } 
