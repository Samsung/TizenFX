#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { 
/// <summary>Fds are objects that watch the activity on a given file descriptor. This file descriptor can be a network, a file, provided by a library.
/// The object will trigger relevant events depending on what&apos;s happening.</summary>
[LoopFdNativeInherit]
public class LoopFd : Efl.LoopConsumer, Efl.Eo.IWrapper
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.LoopFdNativeInherit nativeInherit = new Efl.LoopFdNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (LoopFd))
            return Efl.LoopFdNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
      }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)] internal static extern System.IntPtr
      efl_loop_fd_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   public LoopFd(Efl.Object parent= null
         ) :
      base(efl_loop_fd_class_get(), typeof(LoopFd), parent)
   {
      FinishInstantiation();
   }
   ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
   public LoopFd(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
   protected LoopFd(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static LoopFd static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new LoopFd(obj.NativeHandle);
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
   /// <summary>Called when a read happened on the file descriptor</summary>
   public event EventHandler ReadEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_LOOP_FD_EVENT_READ";
            if (add_cpp_event_handler(efl.Libs.Ecore, key, this.evt_ReadEvt_delegate)) {
               eventHandlers.AddHandler(ReadEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_LOOP_FD_EVENT_READ";
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
   /// <summary>Called when a write happened on the file descriptor</summary>
   public event EventHandler WriteEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_LOOP_FD_EVENT_WRITE";
            if (add_cpp_event_handler(efl.Libs.Ecore, key, this.evt_WriteEvt_delegate)) {
               eventHandlers.AddHandler(WriteEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_LOOP_FD_EVENT_WRITE";
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
   /// <summary>Called when a error occurred on the file descriptor</summary>
   public event EventHandler ErrorEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_LOOP_FD_EVENT_ERROR";
            if (add_cpp_event_handler(efl.Libs.Ecore, key, this.evt_ErrorEvt_delegate)) {
               eventHandlers.AddHandler(ErrorEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_LOOP_FD_EVENT_ERROR";
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

   protected override void register_event_proxies()
   {
      base.register_event_proxies();
      evt_ReadEvt_delegate = new Efl.EventCb(on_ReadEvt_NativeCallback);
      evt_WriteEvt_delegate = new Efl.EventCb(on_WriteEvt_NativeCallback);
      evt_ErrorEvt_delegate = new Efl.EventCb(on_ErrorEvt_NativeCallback);
   }
   /// <summary>Defines which file descriptor to watch. If it is a file, use file_fd variant.</summary>
   /// <returns>The file descriptor.</returns>
   virtual public  int GetFd() {
       var _ret_var = Efl.LoopFdNativeInherit.efl_loop_fd_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Defines the fd to watch.</summary>
   /// <param name="fd">The file descriptor.</param>
   /// <returns></returns>
   virtual public  void SetFd(  int fd) {
                         Efl.LoopFdNativeInherit.efl_loop_fd_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), fd);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Defines which file descriptor to watch when watching a file.</summary>
   /// <returns>The file descriptor.</returns>
   virtual public  int GetFdFile() {
       var _ret_var = Efl.LoopFdNativeInherit.efl_loop_fd_file_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Defines the fd to watch on.</summary>
   /// <param name="fd">The file descriptor.</param>
   /// <returns></returns>
   virtual public  void SetFdFile(  int fd) {
                         Efl.LoopFdNativeInherit.efl_loop_fd_file_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), fd);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Defines which file descriptor to watch. If it is a file, use file_fd variant.</summary>
/// <value>The file descriptor.</value>
   public  int Fd {
      get { return GetFd(); }
      set { SetFd( value); }
   }
   /// <summary>Defines which file descriptor to watch when watching a file.</summary>
/// <value>The file descriptor.</value>
   public  int FdFile {
      get { return GetFdFile(); }
      set { SetFdFile( value); }
   }
   private static new  IntPtr GetEflClassStatic()
   {
      return Efl.LoopFd.efl_loop_fd_class_get();
   }
}
public class LoopFdNativeInherit : Efl.LoopConsumerNativeInherit{
   public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Ecore);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      if (efl_loop_fd_get_static_delegate == null)
      efl_loop_fd_get_static_delegate = new efl_loop_fd_get_delegate(fd_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_loop_fd_get"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_fd_get_static_delegate)});
      if (efl_loop_fd_set_static_delegate == null)
      efl_loop_fd_set_static_delegate = new efl_loop_fd_set_delegate(fd_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_loop_fd_set"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_fd_set_static_delegate)});
      if (efl_loop_fd_file_get_static_delegate == null)
      efl_loop_fd_file_get_static_delegate = new efl_loop_fd_file_get_delegate(fd_file_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_loop_fd_file_get"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_fd_file_get_static_delegate)});
      if (efl_loop_fd_file_set_static_delegate == null)
      efl_loop_fd_file_set_static_delegate = new efl_loop_fd_file_set_delegate(fd_file_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_loop_fd_file_set"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_fd_file_set_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.LoopFd.efl_loop_fd_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.LoopFd.efl_loop_fd_class_get();
   }


    private delegate  int efl_loop_fd_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  int efl_loop_fd_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_loop_fd_get_api_delegate> efl_loop_fd_get_ptr = new Efl.Eo.FunctionWrapper<efl_loop_fd_get_api_delegate>(_Module, "efl_loop_fd_get");
    private static  int fd_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_loop_fd_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   int _ret_var = default( int);
         try {
            _ret_var = ((LoopFd)wrapper).GetFd();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_loop_fd_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_loop_fd_get_delegate efl_loop_fd_get_static_delegate;


    private delegate  void efl_loop_fd_set_delegate(System.IntPtr obj, System.IntPtr pd,    int fd);


    public delegate  void efl_loop_fd_set_api_delegate(System.IntPtr obj,    int fd);
    public static Efl.Eo.FunctionWrapper<efl_loop_fd_set_api_delegate> efl_loop_fd_set_ptr = new Efl.Eo.FunctionWrapper<efl_loop_fd_set_api_delegate>(_Module, "efl_loop_fd_set");
    private static  void fd_set(System.IntPtr obj, System.IntPtr pd,   int fd)
   {
      Eina.Log.Debug("function efl_loop_fd_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((LoopFd)wrapper).SetFd( fd);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_loop_fd_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  fd);
      }
   }
   private static efl_loop_fd_set_delegate efl_loop_fd_set_static_delegate;


    private delegate  int efl_loop_fd_file_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  int efl_loop_fd_file_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_loop_fd_file_get_api_delegate> efl_loop_fd_file_get_ptr = new Efl.Eo.FunctionWrapper<efl_loop_fd_file_get_api_delegate>(_Module, "efl_loop_fd_file_get");
    private static  int fd_file_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_loop_fd_file_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   int _ret_var = default( int);
         try {
            _ret_var = ((LoopFd)wrapper).GetFdFile();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_loop_fd_file_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_loop_fd_file_get_delegate efl_loop_fd_file_get_static_delegate;


    private delegate  void efl_loop_fd_file_set_delegate(System.IntPtr obj, System.IntPtr pd,    int fd);


    public delegate  void efl_loop_fd_file_set_api_delegate(System.IntPtr obj,    int fd);
    public static Efl.Eo.FunctionWrapper<efl_loop_fd_file_set_api_delegate> efl_loop_fd_file_set_ptr = new Efl.Eo.FunctionWrapper<efl_loop_fd_file_set_api_delegate>(_Module, "efl_loop_fd_file_set");
    private static  void fd_file_set(System.IntPtr obj, System.IntPtr pd,   int fd)
   {
      Eina.Log.Debug("function efl_loop_fd_file_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((LoopFd)wrapper).SetFdFile( fd);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_loop_fd_file_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  fd);
      }
   }
   private static efl_loop_fd_file_set_delegate efl_loop_fd_file_set_static_delegate;
}
} 
