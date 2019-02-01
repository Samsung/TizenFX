#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Layout { 
/// <summary>Layouts asynchronous messaging and signaling interface.
/// 1.21</summary>
[SignalConcreteNativeInherit]
public interface Signal : 
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>Sends an (Edje) message to a given Edje object
/// This function sends an Edje message to obj and to all of its child objects, if it has any (swallowed objects are one kind of child object). Only a few types are supported: - int, - float/double, - string/stringshare, - arrays of int, float, double or strings.
/// 
/// Messages can go both ways, from code to theme, or theme to code.
/// 
/// The id argument as a form of code and theme defining a common interface on message communication. One should define the same IDs on both code and EDC declaration, to individualize messages (binding them to a given context).
/// 1.21</summary>
/// <param name="id">A identification number for the message to be sent
/// 1.21</param>
/// <param name="msg">The message&apos;s payload
/// 1.21</param>
/// <returns></returns>
 void MessageSend(  int id,   Eina.Value msg);
   /// <summary>Adds a callback for an arriving Edje signal, emitted by a given Edje object.
/// Edje signals are one of the communication interfaces between code and a given Edje object&apos;s theme. With signals, one can communicate two string values at a time, which are: - &quot;emission&quot; value: the name of the signal, in general - &quot;source&quot; value: a name for the signal&apos;s context, in general
/// 
/// Signals can go both ways, from code to theme, or theme to code.
/// 
/// Though there are those common uses for the two strings, one is free to use them however they like.
/// 
/// Signal callback registration is powerful, in the way that blobs may be used to match multiple signals at once. All the &quot;*?[&quot; set of <c>fnmatch</c>() operators can be used, both for emission and source.
/// 
/// Edje has internal signals it will emit, automatically, on various actions taking place on group parts. For example, the mouse cursor being moved, pressed, released, etc., over a given part&apos;s area, all generate individual signals.
/// 
/// With something like emission = &quot;mouse,down,*&quot;, source = &quot;button.*&quot; where &quot;button.*&quot; is the pattern for the names of parts implementing buttons on an interface, you&apos;d be registering for notifications on events of mouse buttons being pressed down on either of those parts (those events all have the &quot;mouse,down,&quot; common prefix on their names, with a suffix giving the button number). The actual emission and source strings of an event will be passed in as the emission and source parameters of the callback function (e.g. &quot;mouse,down,2&quot; and &quot;button.close&quot;), for each of those events.
/// 
/// See also the Edje Data Collection Reference for EDC files.
/// 
/// See <see cref="Efl.Layout.Signal.EmitSignal"/> on how to emit signals from code to a an object See <see cref="Efl.Layout.Signal.DelSignalCallback"/>.
/// 1.21</summary>
/// <param name="emission">The signal&apos;s &quot;emission&quot; string
/// 1.21</param>
/// <param name="source">The signal&apos;s &quot;source&quot; string
/// 1.21</param>
/// <param name="func">The callback function to be executed when the signal is emitted.
/// 1.21</param>
/// <param name="data">A pointer to data to pass to <c>func</c>.
/// 1.21</param>
/// <returns><c>true</c> in case of success, <c>false</c> in case of error.
/// 1.21</returns>
bool AddSignalCallback(  System.String emission,   System.String source,  Efl.SignalCb func,   System.IntPtr data);
   /// <summary>Removes a signal-triggered callback from an object.
/// This function removes a callback, previously attached to the emission of a signal, from the object  obj. The parameters emission, source and func must match exactly those passed to a previous call to <see cref="Efl.Layout.Signal.AddSignalCallback"/>.
/// 
/// See <see cref="Efl.Layout.Signal.AddSignalCallback"/>.
/// 1.21</summary>
/// <param name="emission">The signal&apos;s &quot;emission&quot; string
/// 1.21</param>
/// <param name="source">The signal&apos;s &quot;source&quot; string
/// 1.21</param>
/// <param name="func">The callback function to be executed when the signal is emitted.
/// 1.21</param>
/// <param name="data">A pointer to data to pass to <c>func</c>.
/// 1.21</param>
/// <returns><c>true</c> in case of success, <c>false</c> in case of error.
/// 1.21</returns>
bool DelSignalCallback(  System.String emission,   System.String source,  Efl.SignalCb func,   System.IntPtr data);
   /// <summary>Sends/emits an Edje signal to this layout.
/// This function sends a signal to the object. An Edje program, at the EDC specification level, can respond to a signal by having declared matching &quot;signal&quot; and &quot;source&quot; fields on its block.
/// 
/// See also the Edje Data Collection Reference for EDC files.
/// 
/// See <see cref="Efl.Layout.Signal.AddSignalCallback"/> for more on Edje signals.
/// 1.21</summary>
/// <param name="emission">The signal&apos;s &quot;emission&quot; string
/// 1.21</param>
/// <param name="source">The signal&apos;s &quot;source&quot; string
/// 1.21</param>
/// <returns></returns>
 void EmitSignal(  System.String emission,   System.String source);
   /// <summary>Processes an object&apos;s messages and signals queue.
/// This function goes through the object message queue processing the pending messages for this specific Edje object. Normally they&apos;d be processed only at idle time.
/// 
/// If <c>recurse</c> is <c>true</c>, this function will be called recursively on all subobjects.
/// 1.21</summary>
/// <param name="recurse">Whether to process messages on children objects.
/// 1.21</param>
/// <returns></returns>
 void SignalProcess( bool recurse);
               }
/// <summary>Layouts asynchronous messaging and signaling interface.
/// 1.21</summary>
sealed public class SignalConcrete : 

Signal
   
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (SignalConcrete))
            return Efl.Layout.SignalConcreteNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   private  System.IntPtr handle;
   public Dictionary<String, IntPtr> cached_strings = new Dictionary<String, IntPtr>();
   public Dictionary<String, IntPtr> cached_stringshares = new Dictionary<String, IntPtr>();
   ///<summary>Pointer to the native instance.</summary>
   public System.IntPtr NativeHandle {
      get { return handle; }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Edje)] internal static extern System.IntPtr
      efl_layout_signal_interface_get();
   ///<summary>Constructs an instance from a native pointer.</summary>
   public SignalConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~SignalConcrete()
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
   public static SignalConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new SignalConcrete(obj.NativeHandle);
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
    void register_event_proxies()
   {
   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Edje)]
    private static extern  void efl_layout_signal_message_send(System.IntPtr obj,    int id,    Eina.ValueNative msg);
   /// <summary>Sends an (Edje) message to a given Edje object
   /// This function sends an Edje message to obj and to all of its child objects, if it has any (swallowed objects are one kind of child object). Only a few types are supported: - int, - float/double, - string/stringshare, - arrays of int, float, double or strings.
   /// 
   /// Messages can go both ways, from code to theme, or theme to code.
   /// 
   /// The id argument as a form of code and theme defining a common interface on message communication. One should define the same IDs on both code and EDC declaration, to individualize messages (binding them to a given context).
   /// 1.21</summary>
   /// <param name="id">A identification number for the message to be sent
   /// 1.21</param>
   /// <param name="msg">The message&apos;s payload
   /// 1.21</param>
   /// <returns></returns>
   public  void MessageSend(  int id,   Eina.Value msg) {
                                           efl_layout_signal_message_send(Efl.Layout.SignalConcrete.efl_layout_signal_interface_get(),  id,  msg);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Edje)]
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_layout_signal_callback_add(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String emission,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String source,   Efl.SignalCb func,    System.IntPtr data);
   /// <summary>Adds a callback for an arriving Edje signal, emitted by a given Edje object.
   /// Edje signals are one of the communication interfaces between code and a given Edje object&apos;s theme. With signals, one can communicate two string values at a time, which are: - &quot;emission&quot; value: the name of the signal, in general - &quot;source&quot; value: a name for the signal&apos;s context, in general
   /// 
   /// Signals can go both ways, from code to theme, or theme to code.
   /// 
   /// Though there are those common uses for the two strings, one is free to use them however they like.
   /// 
   /// Signal callback registration is powerful, in the way that blobs may be used to match multiple signals at once. All the &quot;*?[&quot; set of <c>fnmatch</c>() operators can be used, both for emission and source.
   /// 
   /// Edje has internal signals it will emit, automatically, on various actions taking place on group parts. For example, the mouse cursor being moved, pressed, released, etc., over a given part&apos;s area, all generate individual signals.
   /// 
   /// With something like emission = &quot;mouse,down,*&quot;, source = &quot;button.*&quot; where &quot;button.*&quot; is the pattern for the names of parts implementing buttons on an interface, you&apos;d be registering for notifications on events of mouse buttons being pressed down on either of those parts (those events all have the &quot;mouse,down,&quot; common prefix on their names, with a suffix giving the button number). The actual emission and source strings of an event will be passed in as the emission and source parameters of the callback function (e.g. &quot;mouse,down,2&quot; and &quot;button.close&quot;), for each of those events.
   /// 
   /// See also the Edje Data Collection Reference for EDC files.
   /// 
   /// See <see cref="Efl.Layout.Signal.EmitSignal"/> on how to emit signals from code to a an object See <see cref="Efl.Layout.Signal.DelSignalCallback"/>.
   /// 1.21</summary>
   /// <param name="emission">The signal&apos;s &quot;emission&quot; string
   /// 1.21</param>
   /// <param name="source">The signal&apos;s &quot;source&quot; string
   /// 1.21</param>
   /// <param name="func">The callback function to be executed when the signal is emitted.
   /// 1.21</param>
   /// <param name="data">A pointer to data to pass to <c>func</c>.
   /// 1.21</param>
   /// <returns><c>true</c> in case of success, <c>false</c> in case of error.
   /// 1.21</returns>
   public bool AddSignalCallback(  System.String emission,   System.String source,  Efl.SignalCb func,   System.IntPtr data) {
                                                                               var _ret_var = efl_layout_signal_callback_add(Efl.Layout.SignalConcrete.efl_layout_signal_interface_get(),  emission,  source,  func,  data);
      Eina.Error.RaiseIfUnhandledException();
                                                      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Edje)]
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_layout_signal_callback_del(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String emission,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String source,   Efl.SignalCb func,    System.IntPtr data);
   /// <summary>Removes a signal-triggered callback from an object.
   /// This function removes a callback, previously attached to the emission of a signal, from the object  obj. The parameters emission, source and func must match exactly those passed to a previous call to <see cref="Efl.Layout.Signal.AddSignalCallback"/>.
   /// 
   /// See <see cref="Efl.Layout.Signal.AddSignalCallback"/>.
   /// 1.21</summary>
   /// <param name="emission">The signal&apos;s &quot;emission&quot; string
   /// 1.21</param>
   /// <param name="source">The signal&apos;s &quot;source&quot; string
   /// 1.21</param>
   /// <param name="func">The callback function to be executed when the signal is emitted.
   /// 1.21</param>
   /// <param name="data">A pointer to data to pass to <c>func</c>.
   /// 1.21</param>
   /// <returns><c>true</c> in case of success, <c>false</c> in case of error.
   /// 1.21</returns>
   public bool DelSignalCallback(  System.String emission,   System.String source,  Efl.SignalCb func,   System.IntPtr data) {
                                                                               var _ret_var = efl_layout_signal_callback_del(Efl.Layout.SignalConcrete.efl_layout_signal_interface_get(),  emission,  source,  func,  data);
      Eina.Error.RaiseIfUnhandledException();
                                                      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Edje)]
    private static extern  void efl_layout_signal_emit(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String emission,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String source);
   /// <summary>Sends/emits an Edje signal to this layout.
   /// This function sends a signal to the object. An Edje program, at the EDC specification level, can respond to a signal by having declared matching &quot;signal&quot; and &quot;source&quot; fields on its block.
   /// 
   /// See also the Edje Data Collection Reference for EDC files.
   /// 
   /// See <see cref="Efl.Layout.Signal.AddSignalCallback"/> for more on Edje signals.
   /// 1.21</summary>
   /// <param name="emission">The signal&apos;s &quot;emission&quot; string
   /// 1.21</param>
   /// <param name="source">The signal&apos;s &quot;source&quot; string
   /// 1.21</param>
   /// <returns></returns>
   public  void EmitSignal(  System.String emission,   System.String source) {
                                           efl_layout_signal_emit(Efl.Layout.SignalConcrete.efl_layout_signal_interface_get(),  emission,  source);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Edje)]
    private static extern  void efl_layout_signal_process(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool recurse);
   /// <summary>Processes an object&apos;s messages and signals queue.
   /// This function goes through the object message queue processing the pending messages for this specific Edje object. Normally they&apos;d be processed only at idle time.
   /// 
   /// If <c>recurse</c> is <c>true</c>, this function will be called recursively on all subobjects.
   /// 1.21</summary>
   /// <param name="recurse">Whether to process messages on children objects.
   /// 1.21</param>
   /// <returns></returns>
   public  void SignalProcess( bool recurse) {
                         efl_layout_signal_process(Efl.Layout.SignalConcrete.efl_layout_signal_interface_get(),  recurse);
      Eina.Error.RaiseIfUnhandledException();
                   }
}
public class SignalConcreteNativeInherit : Efl.Eo.NativeClass{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_layout_signal_message_send_static_delegate = new efl_layout_signal_message_send_delegate(message_send);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_layout_signal_message_send"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_signal_message_send_static_delegate)});
      efl_layout_signal_callback_add_static_delegate = new efl_layout_signal_callback_add_delegate(signal_callback_add);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_layout_signal_callback_add"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_signal_callback_add_static_delegate)});
      efl_layout_signal_callback_del_static_delegate = new efl_layout_signal_callback_del_delegate(signal_callback_del);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_layout_signal_callback_del"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_signal_callback_del_static_delegate)});
      efl_layout_signal_emit_static_delegate = new efl_layout_signal_emit_delegate(signal_emit);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_layout_signal_emit"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_signal_emit_static_delegate)});
      efl_layout_signal_process_static_delegate = new efl_layout_signal_process_delegate(signal_process);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_layout_signal_process"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_signal_process_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Layout.SignalConcrete.efl_layout_signal_interface_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.Layout.SignalConcrete.efl_layout_signal_interface_get();
   }


    private delegate  void efl_layout_signal_message_send_delegate(System.IntPtr obj, System.IntPtr pd,    int id,    Eina.ValueNative msg);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Edje)]  private static extern  void efl_layout_signal_message_send(System.IntPtr obj,    int id,    Eina.ValueNative msg);
    private static  void message_send(System.IntPtr obj, System.IntPtr pd,   int id,   Eina.ValueNative msg)
   {
      Eina.Log.Debug("function efl_layout_signal_message_send was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((Signal)wrapper).MessageSend( id,  msg);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_layout_signal_message_send(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  id,  msg);
      }
   }
   private efl_layout_signal_message_send_delegate efl_layout_signal_message_send_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_layout_signal_callback_add_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String emission,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String source,   Efl.SignalCb func,    System.IntPtr data);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Edje)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_layout_signal_callback_add(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String emission,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String source,   Efl.SignalCb func,    System.IntPtr data);
    private static bool signal_callback_add(System.IntPtr obj, System.IntPtr pd,   System.String emission,   System.String source,  Efl.SignalCb func,   System.IntPtr data)
   {
      Eina.Log.Debug("function efl_layout_signal_callback_add was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                          bool _ret_var = default(bool);
         try {
            _ret_var = ((Signal)wrapper).AddSignalCallback( emission,  source,  func,  data);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                      return _ret_var;
      } else {
         return efl_layout_signal_callback_add(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  emission,  source,  func,  data);
      }
   }
   private efl_layout_signal_callback_add_delegate efl_layout_signal_callback_add_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_layout_signal_callback_del_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String emission,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String source,   Efl.SignalCb func,    System.IntPtr data);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Edje)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_layout_signal_callback_del(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String emission,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String source,   Efl.SignalCb func,    System.IntPtr data);
    private static bool signal_callback_del(System.IntPtr obj, System.IntPtr pd,   System.String emission,   System.String source,  Efl.SignalCb func,   System.IntPtr data)
   {
      Eina.Log.Debug("function efl_layout_signal_callback_del was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                          bool _ret_var = default(bool);
         try {
            _ret_var = ((Signal)wrapper).DelSignalCallback( emission,  source,  func,  data);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                      return _ret_var;
      } else {
         return efl_layout_signal_callback_del(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  emission,  source,  func,  data);
      }
   }
   private efl_layout_signal_callback_del_delegate efl_layout_signal_callback_del_static_delegate;


    private delegate  void efl_layout_signal_emit_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String emission,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String source);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Edje)]  private static extern  void efl_layout_signal_emit(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String emission,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String source);
    private static  void signal_emit(System.IntPtr obj, System.IntPtr pd,   System.String emission,   System.String source)
   {
      Eina.Log.Debug("function efl_layout_signal_emit was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((Signal)wrapper).EmitSignal( emission,  source);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_layout_signal_emit(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  emission,  source);
      }
   }
   private efl_layout_signal_emit_delegate efl_layout_signal_emit_static_delegate;


    private delegate  void efl_layout_signal_process_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool recurse);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Edje)]  private static extern  void efl_layout_signal_process(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool recurse);
    private static  void signal_process(System.IntPtr obj, System.IntPtr pd,  bool recurse)
   {
      Eina.Log.Debug("function efl_layout_signal_process was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Signal)wrapper).SignalProcess( recurse);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_layout_signal_process(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  recurse);
      }
   }
   private efl_layout_signal_process_delegate efl_layout_signal_process_static_delegate;
}
} } 
