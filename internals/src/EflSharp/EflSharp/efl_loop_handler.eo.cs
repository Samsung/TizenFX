#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { 
/// <summary>An object that describes an low-level source of I/O to listen to for available data to be read or written, depending on the OS and data source type. When I/O becomes available various events are produced and the callbacks attached to them will be called.</summary>
[LoopHandlerNativeInherit]
public class LoopHandler : Efl.Object, Efl.Eo.IWrapper
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.LoopHandlerNativeInherit nativeInherit = new Efl.LoopHandlerNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (LoopHandler))
            return Efl.LoopHandlerNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   ///<summary>Delegate for function to be called from inside the native constructor.</summary>
   public new delegate void ConstructingMethod(LoopHandler obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)] internal static extern System.IntPtr
      efl_loop_handler_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="init_cb">Delegate to call constructing methods that should be run inside the constructor.</param>
   public LoopHandler(Efl.Object parent = null, ConstructingMethod init_cb=null) : base("LoopHandler", efl_loop_handler_class_get(), typeof(LoopHandler), parent)
   {
      if (init_cb != null) {
         init_cb(this);
      }
      FinishInstantiation();
   }
   ///<summary>Internal constructor to forward the wrapper initialization to the root class.</summary>
   protected LoopHandler(String klass_name, IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(klass_name, base_klass, managed_type, parent) {}
   ///<summary>Constructs an instance from a native pointer.</summary>
   public LoopHandler(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static LoopHandler static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new LoopHandler(obj.NativeHandle);
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
private static object ReadEvtKey = new object();
   /// <summary>Called when a read occurs on the descriptor.</summary>
   public event EventHandler ReadEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_LOOP_HANDLER_EVENT_READ";
            if (add_cpp_event_handler(key, this.evt_ReadEvt_delegate)) {
               eventHandlers.AddHandler(ReadEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_LOOP_HANDLER_EVENT_READ";
            if (remove_cpp_event_handler(key, this.evt_ReadEvt_delegate)) { 
               eventHandlers.RemoveHandler(ReadEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ReadEvt.</summary>
   public void On_ReadEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[ReadEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ReadEvt_delegate;
   private void on_ReadEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_ReadEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object WriteEvtKey = new object();
   /// <summary>Called when a write occurs on the descriptor.</summary>
   public event EventHandler WriteEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_LOOP_HANDLER_EVENT_WRITE";
            if (add_cpp_event_handler(key, this.evt_WriteEvt_delegate)) {
               eventHandlers.AddHandler(WriteEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_LOOP_HANDLER_EVENT_WRITE";
            if (remove_cpp_event_handler(key, this.evt_WriteEvt_delegate)) { 
               eventHandlers.RemoveHandler(WriteEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event WriteEvt.</summary>
   public void On_WriteEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[WriteEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_WriteEvt_delegate;
   private void on_WriteEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_WriteEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object ErrorEvtKey = new object();
   /// <summary>Called when a error occurrs on the descriptor.</summary>
   public event EventHandler ErrorEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_LOOP_HANDLER_EVENT_ERROR";
            if (add_cpp_event_handler(key, this.evt_ErrorEvt_delegate)) {
               eventHandlers.AddHandler(ErrorEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_LOOP_HANDLER_EVENT_ERROR";
            if (remove_cpp_event_handler(key, this.evt_ErrorEvt_delegate)) { 
               eventHandlers.RemoveHandler(ErrorEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ErrorEvt.</summary>
   public void On_ErrorEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[ErrorEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ErrorEvt_delegate;
   private void on_ErrorEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_ErrorEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object BufferEvtKey = new object();
   /// <summary>Called when buffered data already read from the descriptor should be processed.</summary>
   public event EventHandler BufferEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_LOOP_HANDLER_EVENT_BUFFER";
            if (add_cpp_event_handler(key, this.evt_BufferEvt_delegate)) {
               eventHandlers.AddHandler(BufferEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_LOOP_HANDLER_EVENT_BUFFER";
            if (remove_cpp_event_handler(key, this.evt_BufferEvt_delegate)) { 
               eventHandlers.RemoveHandler(BufferEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event BufferEvt.</summary>
   public void On_BufferEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[BufferEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_BufferEvt_delegate;
   private void on_BufferEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_BufferEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object PrepareEvtKey = new object();
   /// <summary>Called when preparing a descriptor for listening.</summary>
   public event EventHandler PrepareEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_LOOP_HANDLER_EVENT_PREPARE";
            if (add_cpp_event_handler(key, this.evt_PrepareEvt_delegate)) {
               eventHandlers.AddHandler(PrepareEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_LOOP_HANDLER_EVENT_PREPARE";
            if (remove_cpp_event_handler(key, this.evt_PrepareEvt_delegate)) { 
               eventHandlers.RemoveHandler(PrepareEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event PrepareEvt.</summary>
   public void On_PrepareEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[PrepareEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_PrepareEvt_delegate;
   private void on_PrepareEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_PrepareEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

   protected override void register_event_proxies()
   {
      base.register_event_proxies();
      evt_ReadEvt_delegate = new Efl.EventCb(on_ReadEvt_NativeCallback);
      evt_WriteEvt_delegate = new Efl.EventCb(on_WriteEvt_NativeCallback);
      evt_ErrorEvt_delegate = new Efl.EventCb(on_ErrorEvt_NativeCallback);
      evt_BufferEvt_delegate = new Efl.EventCb(on_BufferEvt_NativeCallback);
      evt_PrepareEvt_delegate = new Efl.EventCb(on_PrepareEvt_NativeCallback);
   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]
    protected static extern Efl.LoopHandlerFlags efl_loop_handler_active_get(System.IntPtr obj);
   /// <summary>This sets what kind of I/O should be listened to only when using a fd or fd_file for the handler</summary>
   /// <returns>The flags that indicate what kind of I/O should be listened for like read, write or error channels.</returns>
   virtual public Efl.LoopHandlerFlags GetActive() {
       var _ret_var = efl_loop_handler_active_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]
    protected static extern  void efl_loop_handler_active_set(System.IntPtr obj,   Efl.LoopHandlerFlags flags);
   /// <summary>This sets what kind of I/O should be listened to only when using a fd or fd_file for the handler</summary>
   /// <param name="flags">The flags that indicate what kind of I/O should be listened for like read, write or error channels.</param>
   /// <returns></returns>
   virtual public  void SetActive( Efl.LoopHandlerFlags flags) {
                         efl_loop_handler_active_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  flags);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]
    protected static extern  int efl_loop_handler_fd_get(System.IntPtr obj);
   /// <summary>Controls a file descriptor to listen to for I/O, which points to a data pipe such as a device, socket or pipe etc.</summary>
   /// <returns>The file descriptor</returns>
   virtual public  int GetFd() {
       var _ret_var = efl_loop_handler_fd_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]
    protected static extern  void efl_loop_handler_fd_set(System.IntPtr obj,    int fd);
   /// <summary>Controls a file descriptor to listen to for I/O, which points to a data pipe such as a device, socket or pipe etc.</summary>
   /// <param name="fd">The file descriptor</param>
   /// <returns></returns>
   virtual public  void SetFd(  int fd) {
                         efl_loop_handler_fd_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  fd);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]
    protected static extern  int efl_loop_handler_fd_file_get(System.IntPtr obj);
   /// <summary>Controls a file descriptor to listen to for I/O that specifically points to a file in storage and not a device, socket or pipe etc.</summary>
   /// <returns>The file descriptor</returns>
   virtual public  int GetFdFile() {
       var _ret_var = efl_loop_handler_fd_file_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]
    protected static extern  void efl_loop_handler_fd_file_set(System.IntPtr obj,    int fd);
   /// <summary>Controls a file descriptor to listen to for I/O that specifically points to a file in storage and not a device, socket or pipe etc.</summary>
   /// <param name="fd">The file descriptor</param>
   /// <returns></returns>
   virtual public  void SetFdFile(  int fd) {
                         efl_loop_handler_fd_file_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  fd);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]
    protected static extern  System.IntPtr efl_loop_handler_win32_get(System.IntPtr obj);
   /// <summary>Controls a windows win32 object handle to listen to for I/O. When it becomes available for any data the read event will be produced.</summary>
   /// <returns>A win32 object handle</returns>
   virtual public  System.IntPtr GetWin32() {
       var _ret_var = efl_loop_handler_win32_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]
    protected static extern  void efl_loop_handler_win32_set(System.IntPtr obj,    System.IntPtr handle);
   /// <summary>Controls a windows win32 object handle to listen to for I/O. When it becomes available for any data the read event will be produced.</summary>
   /// <param name="handle">A win32 object handle</param>
   /// <returns></returns>
   virtual public  void SetWin32(  System.IntPtr handle) {
                         efl_loop_handler_win32_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  handle);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>This sets what kind of I/O should be listened to only when using a fd or fd_file for the handler</summary>
   public Efl.LoopHandlerFlags Active {
      get { return GetActive(); }
      set { SetActive( value); }
   }
   /// <summary>Controls a file descriptor to listen to for I/O, which points to a data pipe such as a device, socket or pipe etc.</summary>
   public  int Fd {
      get { return GetFd(); }
      set { SetFd( value); }
   }
   /// <summary>Controls a file descriptor to listen to for I/O that specifically points to a file in storage and not a device, socket or pipe etc.</summary>
   public  int FdFile {
      get { return GetFdFile(); }
      set { SetFdFile( value); }
   }
   /// <summary>Controls a windows win32 object handle to listen to for I/O. When it becomes available for any data the read event will be produced.</summary>
   public  System.IntPtr Win32 {
      get { return GetWin32(); }
      set { SetWin32( value); }
   }
}
public class LoopHandlerNativeInherit : Efl.ObjectNativeInherit{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_loop_handler_active_get_static_delegate = new efl_loop_handler_active_get_delegate(active_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_loop_handler_active_get"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_handler_active_get_static_delegate)});
      efl_loop_handler_active_set_static_delegate = new efl_loop_handler_active_set_delegate(active_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_loop_handler_active_set"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_handler_active_set_static_delegate)});
      efl_loop_handler_fd_get_static_delegate = new efl_loop_handler_fd_get_delegate(fd_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_loop_handler_fd_get"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_handler_fd_get_static_delegate)});
      efl_loop_handler_fd_set_static_delegate = new efl_loop_handler_fd_set_delegate(fd_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_loop_handler_fd_set"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_handler_fd_set_static_delegate)});
      efl_loop_handler_fd_file_get_static_delegate = new efl_loop_handler_fd_file_get_delegate(fd_file_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_loop_handler_fd_file_get"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_handler_fd_file_get_static_delegate)});
      efl_loop_handler_fd_file_set_static_delegate = new efl_loop_handler_fd_file_set_delegate(fd_file_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_loop_handler_fd_file_set"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_handler_fd_file_set_static_delegate)});
      efl_loop_handler_win32_get_static_delegate = new efl_loop_handler_win32_get_delegate(win32_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_loop_handler_win32_get"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_handler_win32_get_static_delegate)});
      efl_loop_handler_win32_set_static_delegate = new efl_loop_handler_win32_set_delegate(win32_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_loop_handler_win32_set"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_handler_win32_set_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.LoopHandler.efl_loop_handler_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.LoopHandler.efl_loop_handler_class_get();
   }


    private delegate Efl.LoopHandlerFlags efl_loop_handler_active_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]  private static extern Efl.LoopHandlerFlags efl_loop_handler_active_get(System.IntPtr obj);
    private static Efl.LoopHandlerFlags active_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_loop_handler_active_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.LoopHandlerFlags _ret_var = default(Efl.LoopHandlerFlags);
         try {
            _ret_var = ((LoopHandler)wrapper).GetActive();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_loop_handler_active_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_loop_handler_active_get_delegate efl_loop_handler_active_get_static_delegate;


    private delegate  void efl_loop_handler_active_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.LoopHandlerFlags flags);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]  private static extern  void efl_loop_handler_active_set(System.IntPtr obj,   Efl.LoopHandlerFlags flags);
    private static  void active_set(System.IntPtr obj, System.IntPtr pd,  Efl.LoopHandlerFlags flags)
   {
      Eina.Log.Debug("function efl_loop_handler_active_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((LoopHandler)wrapper).SetActive( flags);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_loop_handler_active_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  flags);
      }
   }
   private efl_loop_handler_active_set_delegate efl_loop_handler_active_set_static_delegate;


    private delegate  int efl_loop_handler_fd_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]  private static extern  int efl_loop_handler_fd_get(System.IntPtr obj);
    private static  int fd_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_loop_handler_fd_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   int _ret_var = default( int);
         try {
            _ret_var = ((LoopHandler)wrapper).GetFd();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_loop_handler_fd_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_loop_handler_fd_get_delegate efl_loop_handler_fd_get_static_delegate;


    private delegate  void efl_loop_handler_fd_set_delegate(System.IntPtr obj, System.IntPtr pd,    int fd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]  private static extern  void efl_loop_handler_fd_set(System.IntPtr obj,    int fd);
    private static  void fd_set(System.IntPtr obj, System.IntPtr pd,   int fd)
   {
      Eina.Log.Debug("function efl_loop_handler_fd_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((LoopHandler)wrapper).SetFd( fd);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_loop_handler_fd_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  fd);
      }
   }
   private efl_loop_handler_fd_set_delegate efl_loop_handler_fd_set_static_delegate;


    private delegate  int efl_loop_handler_fd_file_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]  private static extern  int efl_loop_handler_fd_file_get(System.IntPtr obj);
    private static  int fd_file_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_loop_handler_fd_file_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   int _ret_var = default( int);
         try {
            _ret_var = ((LoopHandler)wrapper).GetFdFile();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_loop_handler_fd_file_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_loop_handler_fd_file_get_delegate efl_loop_handler_fd_file_get_static_delegate;


    private delegate  void efl_loop_handler_fd_file_set_delegate(System.IntPtr obj, System.IntPtr pd,    int fd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]  private static extern  void efl_loop_handler_fd_file_set(System.IntPtr obj,    int fd);
    private static  void fd_file_set(System.IntPtr obj, System.IntPtr pd,   int fd)
   {
      Eina.Log.Debug("function efl_loop_handler_fd_file_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((LoopHandler)wrapper).SetFdFile( fd);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_loop_handler_fd_file_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  fd);
      }
   }
   private efl_loop_handler_fd_file_set_delegate efl_loop_handler_fd_file_set_static_delegate;


    private delegate  System.IntPtr efl_loop_handler_win32_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]  private static extern  System.IntPtr efl_loop_handler_win32_get(System.IntPtr obj);
    private static  System.IntPtr win32_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_loop_handler_win32_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.IntPtr _ret_var = default( System.IntPtr);
         try {
            _ret_var = ((LoopHandler)wrapper).GetWin32();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_loop_handler_win32_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_loop_handler_win32_get_delegate efl_loop_handler_win32_get_static_delegate;


    private delegate  void efl_loop_handler_win32_set_delegate(System.IntPtr obj, System.IntPtr pd,    System.IntPtr handle);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]  private static extern  void efl_loop_handler_win32_set(System.IntPtr obj,    System.IntPtr handle);
    private static  void win32_set(System.IntPtr obj, System.IntPtr pd,   System.IntPtr handle)
   {
      Eina.Log.Debug("function efl_loop_handler_win32_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((LoopHandler)wrapper).SetWin32( handle);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_loop_handler_win32_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  handle);
      }
   }
   private efl_loop_handler_win32_set_delegate efl_loop_handler_win32_set_static_delegate;
}
} 
namespace Efl { 
/// <summary>A set of flags that can be OR&apos;d together to indicate which are desired</summary>
public enum LoopHandlerFlags
{
/// <summary>No I/O is desired (generally useless)</summary>
None = 0,
/// <summary>Reading is desired</summary>
Read = 1,
/// <summary>Writing is desired</summary>
Write = 2,
/// <summary>Error channel input is desired</summary>
Error = 4,
}
} 
