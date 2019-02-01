#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { 
/// <summary>No description supplied.</summary>
[TaskNativeInherit]
public class Task : Efl.Object, Efl.Eo.IWrapper,Efl.Io.Closer,Efl.Io.Reader,Efl.Io.Writer
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.TaskNativeInherit nativeInherit = new Efl.TaskNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (Task))
            return Efl.TaskNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   ///<summary>Delegate for function to be called from inside the native constructor.</summary>
   public new delegate void ConstructingMethod(Task obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)] internal static extern System.IntPtr
      efl_task_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="init_cb">Delegate to call constructing methods that should be run inside the constructor.</param>
   public Task(Efl.Object parent = null, ConstructingMethod init_cb=null) : base("Task", efl_task_class_get(), typeof(Task), parent)
   {
      if (init_cb != null) {
         init_cb(this);
      }
      FinishInstantiation();
   }
   ///<summary>Internal constructor to forward the wrapper initialization to the root class.</summary>
   protected Task(String klass_name, IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(klass_name, base_klass, managed_type, parent) {}
   ///<summary>Constructs an instance from a native pointer.</summary>
   public Task(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static Task static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new Task(obj.NativeHandle);
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
private static object ClosedEvtKey = new object();
   /// <summary>Notifies closed, when property is marked as true
   /// 1.19</summary>
   public event EventHandler ClosedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_IO_CLOSER_EVENT_CLOSED";
            if (add_cpp_event_handler(key, this.evt_ClosedEvt_delegate)) {
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

private static object Can_readChangedEvtKey = new object();
   /// <summary>Notifies can_read property changed.
   /// If <see cref="Efl.Io.Reader.CanRead"/> is <c>true</c> there is data to <see cref="Efl.Io.Reader.Read"/> without blocking/error. If <see cref="Efl.Io.Reader.CanRead"/> is <c>false</c>, <see cref="Efl.Io.Reader.Read"/> would either block or fail.
   /// 
   /// Note that usually this event is dispatched from inside <see cref="Efl.Io.Reader.Read"/>, thus before it returns.
   /// 1.19</summary>
   public event EventHandler Can_readChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_IO_READER_EVENT_CAN_READ_CHANGED";
            if (add_cpp_event_handler(key, this.evt_Can_readChangedEvt_delegate)) {
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
   public void On_Can_readChangedEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[Can_readChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_Can_readChangedEvt_delegate;
   private void on_Can_readChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
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
            if (add_cpp_event_handler(key, this.evt_EosEvt_delegate)) {
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

private static object Can_writeChangedEvtKey = new object();
   /// <summary>Notifies can_write property changed.
   /// If <see cref="Efl.Io.Writer.CanWrite"/> is <c>true</c> there is data to <see cref="Efl.Io.Writer.Write"/> without blocking/error. If <see cref="Efl.Io.Writer.CanWrite"/> is <c>false</c>, <see cref="Efl.Io.Writer.Write"/> would either block or fail.
   /// 
   /// Note that usually this event is dispatched from inside <see cref="Efl.Io.Writer.Write"/>, thus before it returns.
   /// 1.19</summary>
   public event EventHandler Can_writeChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_IO_WRITER_EVENT_CAN_WRITE_CHANGED";
            if (add_cpp_event_handler(key, this.evt_Can_writeChangedEvt_delegate)) {
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
   public void On_Can_writeChangedEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[Can_writeChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_Can_writeChangedEvt_delegate;
   private void on_Can_writeChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
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
      evt_ClosedEvt_delegate = new Efl.EventCb(on_ClosedEvt_NativeCallback);
      evt_Can_readChangedEvt_delegate = new Efl.EventCb(on_Can_readChangedEvt_NativeCallback);
      evt_EosEvt_delegate = new Efl.EventCb(on_EosEvt_NativeCallback);
      evt_Can_writeChangedEvt_delegate = new Efl.EventCb(on_Can_writeChangedEvt_NativeCallback);
   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] protected static extern  System.String efl_task_command_get(System.IntPtr obj);
   /// <summary>A commandline that encodes arguments in a command string. This command is unix shell-style, thus whitespace separates arguments unless escaped. Also a semi-colon &apos;;&apos;, ampersand &apos;&amp;&apos;, pipe/bar &apos;|&apos;, hash &apos;#&apos;, bracket, square brace, brace character (&apos;(&apos;, &apos;)&apos;, &apos;[&apos;, &apos;]&apos;, &apos;{&apos;, &apos;}&apos;), exclamation mark &apos;!&apos;,  backquote &apos;`&apos;, greator or less than (&apos;&gt;&apos; &apos;&lt;&apos;) character unless escaped or in quotes would cause args_count/value to not be generated properly, because it would force complex shell interpretation which will not be supported in evaluating the arg_count/value information, but the final shell may interpret this if this is executed via a command-line shell. To not be a complex shell command, it should be simple with paths, options and variable expansions, but nothing more complex involving the above unescaped characters.
   /// &quot;cat -option /path/file&quot; &quot;cat &apos;quoted argument&apos;&quot; &quot;cat ~/path/escaped argument&quot; &quot;/bin/cat escaped argument <c>VARIABLE</c>&quot; etc.
   /// 
   /// It should not try and use &quot;complex shell features&quot; if you want the arg_count and arg_value set to be correct after setting the command string. For example none of:
   /// 
   /// &quot;VAR=x /bin/command &amp;&amp; /bin/othercommand &gt;&amp; /dev/null&quot; &quot;VAR=x /bin/command `/bin/othercommand` | /bin/cmd2 &amp;&amp; cmd3 &amp;&quot; etc.
   /// 
   /// If you set the command the arg_count/value property contents can change and be completely re-evaluated by parsing the command string into an argument array set along with interpreting escapes back into individual argument strings.</summary>
   /// <returns>The command string as described</returns>
   virtual public  System.String GetCommand() {
       var _ret_var = efl_task_command_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]
    protected static extern  void efl_task_command_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String command);
   /// <summary>A commandline that encodes arguments in a command string. This command is unix shell-style, thus whitespace separates arguments unless escaped. Also a semi-colon &apos;;&apos;, ampersand &apos;&amp;&apos;, pipe/bar &apos;|&apos;, hash &apos;#&apos;, bracket, square brace, brace character (&apos;(&apos;, &apos;)&apos;, &apos;[&apos;, &apos;]&apos;, &apos;{&apos;, &apos;}&apos;), exclamation mark &apos;!&apos;,  backquote &apos;`&apos;, greator or less than (&apos;&gt;&apos; &apos;&lt;&apos;) character unless escaped or in quotes would cause args_count/value to not be generated properly, because it would force complex shell interpretation which will not be supported in evaluating the arg_count/value information, but the final shell may interpret this if this is executed via a command-line shell. To not be a complex shell command, it should be simple with paths, options and variable expansions, but nothing more complex involving the above unescaped characters.
   /// &quot;cat -option /path/file&quot; &quot;cat &apos;quoted argument&apos;&quot; &quot;cat ~/path/escaped argument&quot; &quot;/bin/cat escaped argument <c>VARIABLE</c>&quot; etc.
   /// 
   /// It should not try and use &quot;complex shell features&quot; if you want the arg_count and arg_value set to be correct after setting the command string. For example none of:
   /// 
   /// &quot;VAR=x /bin/command &amp;&amp; /bin/othercommand &gt;&amp; /dev/null&quot; &quot;VAR=x /bin/command `/bin/othercommand` | /bin/cmd2 &amp;&amp; cmd3 &amp;&quot; etc.
   /// 
   /// If you set the command the arg_count/value property contents can change and be completely re-evaluated by parsing the command string into an argument array set along with interpreting escapes back into individual argument strings.</summary>
   /// <param name="command">The command string as described</param>
   /// <returns></returns>
   virtual public  void SetCommand(  System.String command) {
                         efl_task_command_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  command);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]
    protected static extern  uint efl_task_arg_count_get(System.IntPtr obj);
   /// <summary>Number of arguments passed in or arguments that are to be passed as sepcified by arg_value</summary>
   /// <returns>No description supplied.</returns>
   virtual public  uint GetArgCount() {
       var _ret_var = efl_task_arg_count_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] protected static extern  System.String efl_task_arg_value_get(System.IntPtr obj,    uint num);
   /// <summary>Argument number by index. If the index does not exist when set, it is allocated and created. Getting an argument that Has not been set yet will return <c>NULL</c>. Empty arguments will Be ignored. Setting an argument will result in the command porperty being re-evaluated and escaped into a single command string if needed.</summary>
   /// <param name="num">No description supplied.</param>
   /// <returns>No description supplied.</returns>
   virtual public  System.String GetArgValue(  uint num) {
                         var _ret_var = efl_task_arg_value_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  num);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]
    protected static extern  void efl_task_arg_value_set(System.IntPtr obj,    uint num,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String arg);
   /// <summary>Argument number by index. If the index does not exist when set, it is allocated and created. Getting an argument that Has not been set yet will return <c>NULL</c>. Empty arguments will Be ignored. Setting an argument will result in the command porperty being re-evaluated and escaped into a single command string if needed.</summary>
   /// <param name="num">No description supplied.</param>
   /// <param name="arg">No description supplied.</param>
   /// <returns></returns>
   virtual public  void SetArgValue(  uint num,   System.String arg) {
                                           efl_task_arg_value_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  num,  arg);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] protected static extern  System.String efl_task_env_get(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String var);
   /// <summary>The environment to be passed in or that was passed to the task. This is a string key, value list which map to environment variables where appropriate. The var string must contain only an underscore (&apos;_&apos;), letters (&apos;a-z&apos;, &apos;A-Z&apos;), numbers (&apos;0-9&apos;), but the first character may not be a number.</summary>
   /// <param name="var">The variable name as a string</param>
   /// <returns>Set var to this value if not <c>NULL</c>, otherwise clear this env value if value is <c>NULL</c> or if it is an empty string</returns>
   virtual public  System.String GetEnv(  System.String var) {
                         var _ret_var = efl_task_env_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  var);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]
    protected static extern  void efl_task_env_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String var,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String value);
   /// <summary>The environment to be passed in or that was passed to the task. This is a string key, value list which map to environment variables where appropriate. The var string must contain only an underscore (&apos;_&apos;), letters (&apos;a-z&apos;, &apos;A-Z&apos;), numbers (&apos;0-9&apos;), but the first character may not be a number.</summary>
   /// <param name="var">The variable name as a string</param>
   /// <param name="value">Set var to this value if not <c>NULL</c>, otherwise clear this env value if value is <c>NULL</c> or if it is an empty string</param>
   /// <returns></returns>
   virtual public  void SetEnv(  System.String var,   System.String value) {
                                           efl_task_env_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  var,  value);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]
    protected static extern Efl.TaskPriority efl_task_priority_get(System.IntPtr obj);
   /// <summary>The priority of this task.</summary>
   /// <returns>No description supplied.</returns>
   virtual public Efl.TaskPriority GetPriority() {
       var _ret_var = efl_task_priority_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]
    protected static extern  void efl_task_priority_set(System.IntPtr obj,   Efl.TaskPriority priority);
   /// <summary>The priority of this task.</summary>
   /// <param name="priority">No description supplied.</param>
   /// <returns></returns>
   virtual public  void SetPriority( Efl.TaskPriority priority) {
                         efl_task_priority_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  priority);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]
    protected static extern  int efl_task_exit_code_get(System.IntPtr obj);
   /// <summary>The final exit code of this task.</summary>
   /// <returns>No description supplied.</returns>
   virtual public  int GetExitCode() {
       var _ret_var = efl_task_exit_code_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]
    protected static extern Efl.TaskFlags efl_task_flags_get(System.IntPtr obj);
   /// <summary></summary>
   /// <returns>No description supplied.</returns>
   virtual public Efl.TaskFlags GetFlags() {
       var _ret_var = efl_task_flags_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]
    protected static extern  void efl_task_flags_set(System.IntPtr obj,   Efl.TaskFlags flags);
   /// <summary></summary>
   /// <param name="flags">No description supplied.</param>
   /// <returns></returns>
   virtual public  void SetFlags( Efl.TaskFlags flags) {
                         efl_task_flags_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  flags);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]
    protected static extern  void efl_task_arg_append(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String arg);
   /// <summary>Append a new string argument at the end of the arg set. This functions like setting an arg_value at the end of the current set so the set increases by 1 in size.</summary>
   /// <param name="arg">No description supplied.</param>
   /// <returns></returns>
   virtual public  void AppendArg(  System.String arg) {
                         efl_task_arg_append((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  arg);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]
    protected static extern  void efl_task_arg_reset(System.IntPtr obj);
   /// <summary>Clear all arguments in arg_value/count set. Will result in the command property also being cleared.</summary>
   /// <returns></returns>
   virtual public  void ResetArg() {
       efl_task_arg_reset((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]
    protected static extern  void efl_task_env_reset(System.IntPtr obj);
   /// <summary>Clear all environment variables.</summary>
   /// <returns></returns>
   virtual public  void ResetEnv() {
       efl_task_env_reset((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))] protected static extern  Eina.Future efl_task_run(System.IntPtr obj);
   /// <summary>Actually run the task</summary>
   /// <returns>A future triggered when task exits and is passed int exit code</returns>
   virtual public  Eina.Future Run() {
       var _ret_var = efl_task_run((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]
    protected static extern  void efl_task_end(System.IntPtr obj);
   /// <summary>Request the task end (may send a signal or interrupt signal resulting in a terminate event being tiggered in the target task loop)</summary>
   /// <returns></returns>
   virtual public  void End() {
       efl_task_end((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_io_closer_closed_get(System.IntPtr obj);
   /// <summary>If true will notify object was closed.
   /// 1.19</summary>
   /// <returns><c>true</c> if closed, <c>false</c> otherwise
   /// 1.19</returns>
   virtual public bool GetClosed() {
       var _ret_var = efl_io_closer_closed_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_io_closer_close_on_exec_get(System.IntPtr obj);
   /// <summary>If true will automatically close resources on exec() calls.
   /// When using file descriptors this should set FD_CLOEXEC so they are not inherited by the processes (children or self) doing exec().
   /// 1.19</summary>
   /// <returns><c>true</c> if close on exec(), <c>false</c> otherwise
   /// 1.19</returns>
   virtual public bool GetCloseOnExec() {
       var _ret_var = efl_io_closer_close_on_exec_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_io_closer_close_on_exec_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool close_on_exec);
   /// <summary>If <c>true</c>, will close on exec() call.
   /// 1.19</summary>
   /// <param name="close_on_exec"><c>true</c> if close on exec(), <c>false</c> otherwise
   /// 1.19</param>
   /// <returns><c>true</c> if could set, <c>false</c> if not supported or failed.
   /// 1.19</returns>
   virtual public bool SetCloseOnExec( bool close_on_exec) {
                         var _ret_var = efl_io_closer_close_on_exec_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  close_on_exec);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_io_closer_close_on_invalidate_get(System.IntPtr obj);
   /// <summary>If true will automatically close() on object invalidate.
   /// If the object was disconnected from its parent (including the main loop) without close, this property will state whenever it should be closed or not.
   /// 1.19</summary>
   /// <returns><c>true</c> if close on invalidate, <c>false</c> otherwise
   /// 1.19</returns>
   virtual public bool GetCloseOnInvalidate() {
       var _ret_var = efl_io_closer_close_on_invalidate_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_io_closer_close_on_invalidate_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool close_on_invalidate);
   /// <summary>If true will automatically close() on object invalidate.
   /// If the object was disconnected from its parent (including the main loop) without close, this property will state whenever it should be closed or not.
   /// 1.19</summary>
   /// <param name="close_on_invalidate"><c>true</c> if close on invalidate, <c>false</c> otherwise
   /// 1.19</param>
   /// <returns></returns>
   virtual public  void SetCloseOnInvalidate( bool close_on_invalidate) {
                         efl_io_closer_close_on_invalidate_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  close_on_invalidate);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  Eina.Error efl_io_closer_close(System.IntPtr obj);
   /// <summary>Closes the Input/Output object.
   /// This operation will be executed immediately and may or may not block the caller thread for some time. The details of blocking behavior is to be defined by the implementation and may be subject to other parameters such as non-blocking flags, maximum timeout or even retry attempts.
   /// 
   /// You can understand this method as close(2) libc function.
   /// 1.19</summary>
   /// <returns>0 on succeed, a mapping of errno otherwise
   /// 1.19</returns>
   virtual public  Eina.Error Close() {
       var _ret_var = efl_io_closer_close((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_io_reader_can_read_get(System.IntPtr obj);
   /// <summary>If <c>true</c> will notify <see cref="Efl.Io.Reader.Read"/> can be called without blocking or failing.
   /// 1.19</summary>
   /// <returns><c>true</c> if it can be read without blocking or failing, <c>false</c> otherwise
   /// 1.19</returns>
   virtual public bool GetCanRead() {
       var _ret_var = efl_io_reader_can_read_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_io_reader_can_read_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool can_read);
   /// <summary>If <c>true</c> will notify <see cref="Efl.Io.Reader.Read"/> can be called without blocking or failing.
   /// 1.19</summary>
   /// <param name="can_read"><c>true</c> if it can be read without blocking or failing, <c>false</c> otherwise
   /// 1.19</param>
   /// <returns></returns>
   virtual public  void SetCanRead( bool can_read) {
                         efl_io_reader_can_read_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  can_read);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_io_reader_eos_get(System.IntPtr obj);
   /// <summary>If <c>true</c> will notify end of stream.
   /// 1.19</summary>
   /// <returns><c>true</c> if end of stream, <c>false</c> otherwise
   /// 1.19</returns>
   virtual public bool GetEos() {
       var _ret_var = efl_io_reader_eos_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_io_reader_eos_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool is_eos);
   /// <summary>If <c>true</c> will notify end of stream.
   /// 1.19</summary>
   /// <param name="is_eos"><c>true</c> if end of stream, <c>false</c> otherwise
   /// 1.19</param>
   /// <returns></returns>
   virtual public  void SetEos( bool is_eos) {
                         efl_io_reader_eos_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  is_eos);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  Eina.Error efl_io_reader_read(System.IntPtr obj,   ref Eina.RwSlice rw_slice);
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
                         var _ret_var = efl_io_reader_read((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  ref rw_slice);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_io_writer_can_write_get(System.IntPtr obj);
   /// <summary>If <c>true</c> will notify <see cref="Efl.Io.Writer.Write"/> can be called without blocking or failing.
   /// 1.19</summary>
   /// <returns><c>true</c> if it can be written without blocking or failure, <c>false</c> otherwise
   /// 1.19</returns>
   virtual public bool GetCanWrite() {
       var _ret_var = efl_io_writer_can_write_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_io_writer_can_write_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool can_write);
   /// <summary>If <c>true</c> will notify <see cref="Efl.Io.Writer.Write"/> can be called without blocking or failing.
   /// 1.19</summary>
   /// <param name="can_write"><c>true</c> if it can be written without blocking or failure, <c>false</c> otherwise
   /// 1.19</param>
   /// <returns></returns>
   virtual public  void SetCanWrite( bool can_write) {
                         efl_io_writer_can_write_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  can_write);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  Eina.Error efl_io_writer_write(System.IntPtr obj,   ref Eina.Slice slice,   ref Eina.Slice remaining);
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
                                           var _ret_var = efl_io_writer_write((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  ref slice,  ref remaining);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }
   public System.Threading.Tasks.Task<Eina.Value> RunAsync( System.Threading.CancellationToken token=default(System.Threading.CancellationToken))
   {
      Eina.Future future = Run();
      return Efl.Eo.Globals.WrapAsync(future, token);
   }
   /// <summary>A commandline that encodes arguments in a command string. This command is unix shell-style, thus whitespace separates arguments unless escaped. Also a semi-colon &apos;;&apos;, ampersand &apos;&amp;&apos;, pipe/bar &apos;|&apos;, hash &apos;#&apos;, bracket, square brace, brace character (&apos;(&apos;, &apos;)&apos;, &apos;[&apos;, &apos;]&apos;, &apos;{&apos;, &apos;}&apos;), exclamation mark &apos;!&apos;,  backquote &apos;`&apos;, greator or less than (&apos;&gt;&apos; &apos;&lt;&apos;) character unless escaped or in quotes would cause args_count/value to not be generated properly, because it would force complex shell interpretation which will not be supported in evaluating the arg_count/value information, but the final shell may interpret this if this is executed via a command-line shell. To not be a complex shell command, it should be simple with paths, options and variable expansions, but nothing more complex involving the above unescaped characters.
/// &quot;cat -option /path/file&quot; &quot;cat &apos;quoted argument&apos;&quot; &quot;cat ~/path/escaped argument&quot; &quot;/bin/cat escaped argument <c>VARIABLE</c>&quot; etc.
/// 
/// It should not try and use &quot;complex shell features&quot; if you want the arg_count and arg_value set to be correct after setting the command string. For example none of:
/// 
/// &quot;VAR=x /bin/command &amp;&amp; /bin/othercommand &gt;&amp; /dev/null&quot; &quot;VAR=x /bin/command `/bin/othercommand` | /bin/cmd2 &amp;&amp; cmd3 &amp;&quot; etc.
/// 
/// If you set the command the arg_count/value property contents can change and be completely re-evaluated by parsing the command string into an argument array set along with interpreting escapes back into individual argument strings.</summary>
   public  System.String Command {
      get { return GetCommand(); }
      set { SetCommand( value); }
   }
   /// <summary>Number of arguments passed in or arguments that are to be passed as sepcified by arg_value</summary>
   public  uint ArgCount {
      get { return GetArgCount(); }
   }
   /// <summary>The priority of this task.</summary>
   public Efl.TaskPriority Priority {
      get { return GetPriority(); }
      set { SetPriority( value); }
   }
   /// <summary>The final exit code of this task.</summary>
   public  int ExitCode {
      get { return GetExitCode(); }
   }
   /// <summary></summary>
   public Efl.TaskFlags Flags {
      get { return GetFlags(); }
      set { SetFlags( value); }
   }
   /// <summary>If true will notify object was closed.
/// 1.19</summary>
   public bool Closed {
      get { return GetClosed(); }
   }
   /// <summary>If true will automatically close resources on exec() calls.
/// When using file descriptors this should set FD_CLOEXEC so they are not inherited by the processes (children or self) doing exec().
/// 1.19</summary>
   public bool CloseOnExec {
      get { return GetCloseOnExec(); }
      set { SetCloseOnExec( value); }
   }
   /// <summary>If true will automatically close() on object invalidate.
/// If the object was disconnected from its parent (including the main loop) without close, this property will state whenever it should be closed or not.
/// 1.19</summary>
   public bool CloseOnInvalidate {
      get { return GetCloseOnInvalidate(); }
      set { SetCloseOnInvalidate( value); }
   }
   /// <summary>If <c>true</c> will notify <see cref="Efl.Io.Reader.Read"/> can be called without blocking or failing.
/// 1.19</summary>
   public bool CanRead {
      get { return GetCanRead(); }
      set { SetCanRead( value); }
   }
   /// <summary>If <c>true</c> will notify end of stream.
/// 1.19</summary>
   public bool Eos {
      get { return GetEos(); }
      set { SetEos( value); }
   }
   /// <summary>If <c>true</c> will notify <see cref="Efl.Io.Writer.Write"/> can be called without blocking or failing.
/// 1.19</summary>
   public bool CanWrite {
      get { return GetCanWrite(); }
      set { SetCanWrite( value); }
   }
}
public class TaskNativeInherit : Efl.ObjectNativeInherit{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_task_command_get_static_delegate = new efl_task_command_get_delegate(command_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_task_command_get"), func = Marshal.GetFunctionPointerForDelegate(efl_task_command_get_static_delegate)});
      efl_task_command_set_static_delegate = new efl_task_command_set_delegate(command_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_task_command_set"), func = Marshal.GetFunctionPointerForDelegate(efl_task_command_set_static_delegate)});
      efl_task_arg_count_get_static_delegate = new efl_task_arg_count_get_delegate(arg_count_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_task_arg_count_get"), func = Marshal.GetFunctionPointerForDelegate(efl_task_arg_count_get_static_delegate)});
      efl_task_arg_value_get_static_delegate = new efl_task_arg_value_get_delegate(arg_value_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_task_arg_value_get"), func = Marshal.GetFunctionPointerForDelegate(efl_task_arg_value_get_static_delegate)});
      efl_task_arg_value_set_static_delegate = new efl_task_arg_value_set_delegate(arg_value_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_task_arg_value_set"), func = Marshal.GetFunctionPointerForDelegate(efl_task_arg_value_set_static_delegate)});
      efl_task_env_get_static_delegate = new efl_task_env_get_delegate(env_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_task_env_get"), func = Marshal.GetFunctionPointerForDelegate(efl_task_env_get_static_delegate)});
      efl_task_env_set_static_delegate = new efl_task_env_set_delegate(env_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_task_env_set"), func = Marshal.GetFunctionPointerForDelegate(efl_task_env_set_static_delegate)});
      efl_task_priority_get_static_delegate = new efl_task_priority_get_delegate(priority_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_task_priority_get"), func = Marshal.GetFunctionPointerForDelegate(efl_task_priority_get_static_delegate)});
      efl_task_priority_set_static_delegate = new efl_task_priority_set_delegate(priority_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_task_priority_set"), func = Marshal.GetFunctionPointerForDelegate(efl_task_priority_set_static_delegate)});
      efl_task_exit_code_get_static_delegate = new efl_task_exit_code_get_delegate(exit_code_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_task_exit_code_get"), func = Marshal.GetFunctionPointerForDelegate(efl_task_exit_code_get_static_delegate)});
      efl_task_flags_get_static_delegate = new efl_task_flags_get_delegate(flags_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_task_flags_get"), func = Marshal.GetFunctionPointerForDelegate(efl_task_flags_get_static_delegate)});
      efl_task_flags_set_static_delegate = new efl_task_flags_set_delegate(flags_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_task_flags_set"), func = Marshal.GetFunctionPointerForDelegate(efl_task_flags_set_static_delegate)});
      efl_task_arg_append_static_delegate = new efl_task_arg_append_delegate(arg_append);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_task_arg_append"), func = Marshal.GetFunctionPointerForDelegate(efl_task_arg_append_static_delegate)});
      efl_task_arg_reset_static_delegate = new efl_task_arg_reset_delegate(arg_reset);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_task_arg_reset"), func = Marshal.GetFunctionPointerForDelegate(efl_task_arg_reset_static_delegate)});
      efl_task_env_reset_static_delegate = new efl_task_env_reset_delegate(env_reset);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_task_env_reset"), func = Marshal.GetFunctionPointerForDelegate(efl_task_env_reset_static_delegate)});
      efl_task_run_static_delegate = new efl_task_run_delegate(run);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_task_run"), func = Marshal.GetFunctionPointerForDelegate(efl_task_run_static_delegate)});
      efl_task_end_static_delegate = new efl_task_end_delegate(end);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_task_end"), func = Marshal.GetFunctionPointerForDelegate(efl_task_end_static_delegate)});
      efl_io_closer_closed_get_static_delegate = new efl_io_closer_closed_get_delegate(closed_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_io_closer_closed_get"), func = Marshal.GetFunctionPointerForDelegate(efl_io_closer_closed_get_static_delegate)});
      efl_io_closer_close_on_exec_get_static_delegate = new efl_io_closer_close_on_exec_get_delegate(close_on_exec_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_io_closer_close_on_exec_get"), func = Marshal.GetFunctionPointerForDelegate(efl_io_closer_close_on_exec_get_static_delegate)});
      efl_io_closer_close_on_exec_set_static_delegate = new efl_io_closer_close_on_exec_set_delegate(close_on_exec_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_io_closer_close_on_exec_set"), func = Marshal.GetFunctionPointerForDelegate(efl_io_closer_close_on_exec_set_static_delegate)});
      efl_io_closer_close_on_invalidate_get_static_delegate = new efl_io_closer_close_on_invalidate_get_delegate(close_on_invalidate_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_io_closer_close_on_invalidate_get"), func = Marshal.GetFunctionPointerForDelegate(efl_io_closer_close_on_invalidate_get_static_delegate)});
      efl_io_closer_close_on_invalidate_set_static_delegate = new efl_io_closer_close_on_invalidate_set_delegate(close_on_invalidate_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_io_closer_close_on_invalidate_set"), func = Marshal.GetFunctionPointerForDelegate(efl_io_closer_close_on_invalidate_set_static_delegate)});
      efl_io_closer_close_static_delegate = new efl_io_closer_close_delegate(close);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_io_closer_close"), func = Marshal.GetFunctionPointerForDelegate(efl_io_closer_close_static_delegate)});
      efl_io_reader_can_read_get_static_delegate = new efl_io_reader_can_read_get_delegate(can_read_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_io_reader_can_read_get"), func = Marshal.GetFunctionPointerForDelegate(efl_io_reader_can_read_get_static_delegate)});
      efl_io_reader_can_read_set_static_delegate = new efl_io_reader_can_read_set_delegate(can_read_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_io_reader_can_read_set"), func = Marshal.GetFunctionPointerForDelegate(efl_io_reader_can_read_set_static_delegate)});
      efl_io_reader_eos_get_static_delegate = new efl_io_reader_eos_get_delegate(eos_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_io_reader_eos_get"), func = Marshal.GetFunctionPointerForDelegate(efl_io_reader_eos_get_static_delegate)});
      efl_io_reader_eos_set_static_delegate = new efl_io_reader_eos_set_delegate(eos_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_io_reader_eos_set"), func = Marshal.GetFunctionPointerForDelegate(efl_io_reader_eos_set_static_delegate)});
      efl_io_reader_read_static_delegate = new efl_io_reader_read_delegate(read);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_io_reader_read"), func = Marshal.GetFunctionPointerForDelegate(efl_io_reader_read_static_delegate)});
      efl_io_writer_can_write_get_static_delegate = new efl_io_writer_can_write_get_delegate(can_write_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_io_writer_can_write_get"), func = Marshal.GetFunctionPointerForDelegate(efl_io_writer_can_write_get_static_delegate)});
      efl_io_writer_can_write_set_static_delegate = new efl_io_writer_can_write_set_delegate(can_write_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_io_writer_can_write_set"), func = Marshal.GetFunctionPointerForDelegate(efl_io_writer_can_write_set_static_delegate)});
      efl_io_writer_write_static_delegate = new efl_io_writer_write_delegate(write);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_io_writer_write"), func = Marshal.GetFunctionPointerForDelegate(efl_io_writer_write_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Task.efl_task_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Task.efl_task_class_get();
   }


    private delegate  System.IntPtr efl_task_command_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]  private static extern  System.IntPtr efl_task_command_get(System.IntPtr obj);
    private static  System.IntPtr command_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_task_command_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((Task)wrapper).GetCommand();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Efl.Eo.Globals.cached_string_to_intptr(((Task)wrapper).cached_strings, _ret_var);
      } else {
         return efl_task_command_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_task_command_get_delegate efl_task_command_get_static_delegate;


    private delegate  void efl_task_command_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String command);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]  private static extern  void efl_task_command_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String command);
    private static  void command_set(System.IntPtr obj, System.IntPtr pd,   System.String command)
   {
      Eina.Log.Debug("function efl_task_command_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Task)wrapper).SetCommand( command);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_task_command_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  command);
      }
   }
   private efl_task_command_set_delegate efl_task_command_set_static_delegate;


    private delegate  uint efl_task_arg_count_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]  private static extern  uint efl_task_arg_count_get(System.IntPtr obj);
    private static  uint arg_count_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_task_arg_count_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   uint _ret_var = default( uint);
         try {
            _ret_var = ((Task)wrapper).GetArgCount();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_task_arg_count_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_task_arg_count_get_delegate efl_task_arg_count_get_static_delegate;


    private delegate  System.IntPtr efl_task_arg_value_get_delegate(System.IntPtr obj, System.IntPtr pd,    uint num);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]  private static extern  System.IntPtr efl_task_arg_value_get(System.IntPtr obj,    uint num);
    private static  System.IntPtr arg_value_get(System.IntPtr obj, System.IntPtr pd,   uint num)
   {
      Eina.Log.Debug("function efl_task_arg_value_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                     System.String _ret_var = default( System.String);
         try {
            _ret_var = ((Task)wrapper).GetArgValue( num);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return Efl.Eo.Globals.cached_string_to_intptr(((Task)wrapper).cached_strings, _ret_var);
      } else {
         return efl_task_arg_value_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  num);
      }
   }
   private efl_task_arg_value_get_delegate efl_task_arg_value_get_static_delegate;


    private delegate  void efl_task_arg_value_set_delegate(System.IntPtr obj, System.IntPtr pd,    uint num,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String arg);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]  private static extern  void efl_task_arg_value_set(System.IntPtr obj,    uint num,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String arg);
    private static  void arg_value_set(System.IntPtr obj, System.IntPtr pd,   uint num,   System.String arg)
   {
      Eina.Log.Debug("function efl_task_arg_value_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((Task)wrapper).SetArgValue( num,  arg);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_task_arg_value_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  num,  arg);
      }
   }
   private efl_task_arg_value_set_delegate efl_task_arg_value_set_static_delegate;


    private delegate  System.IntPtr efl_task_env_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String var);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]  private static extern  System.IntPtr efl_task_env_get(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String var);
    private static  System.IntPtr env_get(System.IntPtr obj, System.IntPtr pd,   System.String var)
   {
      Eina.Log.Debug("function efl_task_env_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                     System.String _ret_var = default( System.String);
         try {
            _ret_var = ((Task)wrapper).GetEnv( var);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return Efl.Eo.Globals.cached_string_to_intptr(((Task)wrapper).cached_strings, _ret_var);
      } else {
         return efl_task_env_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  var);
      }
   }
   private efl_task_env_get_delegate efl_task_env_get_static_delegate;


    private delegate  void efl_task_env_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String var,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String value);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]  private static extern  void efl_task_env_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String var,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String value);
    private static  void env_set(System.IntPtr obj, System.IntPtr pd,   System.String var,   System.String value)
   {
      Eina.Log.Debug("function efl_task_env_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((Task)wrapper).SetEnv( var,  value);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_task_env_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  var,  value);
      }
   }
   private efl_task_env_set_delegate efl_task_env_set_static_delegate;


    private delegate Efl.TaskPriority efl_task_priority_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]  private static extern Efl.TaskPriority efl_task_priority_get(System.IntPtr obj);
    private static Efl.TaskPriority priority_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_task_priority_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.TaskPriority _ret_var = default(Efl.TaskPriority);
         try {
            _ret_var = ((Task)wrapper).GetPriority();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_task_priority_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_task_priority_get_delegate efl_task_priority_get_static_delegate;


    private delegate  void efl_task_priority_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TaskPriority priority);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]  private static extern  void efl_task_priority_set(System.IntPtr obj,   Efl.TaskPriority priority);
    private static  void priority_set(System.IntPtr obj, System.IntPtr pd,  Efl.TaskPriority priority)
   {
      Eina.Log.Debug("function efl_task_priority_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Task)wrapper).SetPriority( priority);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_task_priority_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  priority);
      }
   }
   private efl_task_priority_set_delegate efl_task_priority_set_static_delegate;


    private delegate  int efl_task_exit_code_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]  private static extern  int efl_task_exit_code_get(System.IntPtr obj);
    private static  int exit_code_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_task_exit_code_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   int _ret_var = default( int);
         try {
            _ret_var = ((Task)wrapper).GetExitCode();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_task_exit_code_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_task_exit_code_get_delegate efl_task_exit_code_get_static_delegate;


    private delegate Efl.TaskFlags efl_task_flags_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]  private static extern Efl.TaskFlags efl_task_flags_get(System.IntPtr obj);
    private static Efl.TaskFlags flags_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_task_flags_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.TaskFlags _ret_var = default(Efl.TaskFlags);
         try {
            _ret_var = ((Task)wrapper).GetFlags();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_task_flags_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_task_flags_get_delegate efl_task_flags_get_static_delegate;


    private delegate  void efl_task_flags_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TaskFlags flags);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]  private static extern  void efl_task_flags_set(System.IntPtr obj,   Efl.TaskFlags flags);
    private static  void flags_set(System.IntPtr obj, System.IntPtr pd,  Efl.TaskFlags flags)
   {
      Eina.Log.Debug("function efl_task_flags_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Task)wrapper).SetFlags( flags);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_task_flags_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  flags);
      }
   }
   private efl_task_flags_set_delegate efl_task_flags_set_static_delegate;


    private delegate  void efl_task_arg_append_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String arg);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]  private static extern  void efl_task_arg_append(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String arg);
    private static  void arg_append(System.IntPtr obj, System.IntPtr pd,   System.String arg)
   {
      Eina.Log.Debug("function efl_task_arg_append was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Task)wrapper).AppendArg( arg);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_task_arg_append(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  arg);
      }
   }
   private efl_task_arg_append_delegate efl_task_arg_append_static_delegate;


    private delegate  void efl_task_arg_reset_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]  private static extern  void efl_task_arg_reset(System.IntPtr obj);
    private static  void arg_reset(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_task_arg_reset was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Task)wrapper).ResetArg();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_task_arg_reset(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_task_arg_reset_delegate efl_task_arg_reset_static_delegate;


    private delegate  void efl_task_env_reset_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]  private static extern  void efl_task_env_reset(System.IntPtr obj);
    private static  void env_reset(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_task_env_reset was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Task)wrapper).ResetEnv();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_task_env_reset(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_task_env_reset_delegate efl_task_env_reset_static_delegate;


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))] private delegate  Eina.Future efl_task_run_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))] private static extern  Eina.Future efl_task_run(System.IntPtr obj);
    private static  Eina.Future run(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_task_run was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   Eina.Future _ret_var = default( Eina.Future);
         try {
            _ret_var = ((Task)wrapper).Run();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_task_run(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_task_run_delegate efl_task_run_static_delegate;


    private delegate  void efl_task_end_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]  private static extern  void efl_task_end(System.IntPtr obj);
    private static  void end(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_task_end was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Task)wrapper).End();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_task_end(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_task_end_delegate efl_task_end_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_io_closer_closed_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_io_closer_closed_get(System.IntPtr obj);
    private static bool closed_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_io_closer_closed_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Task)wrapper).GetClosed();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_io_closer_closed_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_io_closer_closed_get_delegate efl_io_closer_closed_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_io_closer_close_on_exec_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_io_closer_close_on_exec_get(System.IntPtr obj);
    private static bool close_on_exec_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_io_closer_close_on_exec_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Task)wrapper).GetCloseOnExec();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_io_closer_close_on_exec_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_io_closer_close_on_exec_get_delegate efl_io_closer_close_on_exec_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_io_closer_close_on_exec_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool close_on_exec);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_io_closer_close_on_exec_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool close_on_exec);
    private static bool close_on_exec_set(System.IntPtr obj, System.IntPtr pd,  bool close_on_exec)
   {
      Eina.Log.Debug("function efl_io_closer_close_on_exec_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((Task)wrapper).SetCloseOnExec( close_on_exec);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_io_closer_close_on_exec_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  close_on_exec);
      }
   }
   private efl_io_closer_close_on_exec_set_delegate efl_io_closer_close_on_exec_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_io_closer_close_on_invalidate_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_io_closer_close_on_invalidate_get(System.IntPtr obj);
    private static bool close_on_invalidate_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_io_closer_close_on_invalidate_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Task)wrapper).GetCloseOnInvalidate();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_io_closer_close_on_invalidate_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_io_closer_close_on_invalidate_get_delegate efl_io_closer_close_on_invalidate_get_static_delegate;


    private delegate  void efl_io_closer_close_on_invalidate_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool close_on_invalidate);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_io_closer_close_on_invalidate_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool close_on_invalidate);
    private static  void close_on_invalidate_set(System.IntPtr obj, System.IntPtr pd,  bool close_on_invalidate)
   {
      Eina.Log.Debug("function efl_io_closer_close_on_invalidate_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Task)wrapper).SetCloseOnInvalidate( close_on_invalidate);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_io_closer_close_on_invalidate_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  close_on_invalidate);
      }
   }
   private efl_io_closer_close_on_invalidate_set_delegate efl_io_closer_close_on_invalidate_set_static_delegate;


    private delegate  Eina.Error efl_io_closer_close_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  Eina.Error efl_io_closer_close(System.IntPtr obj);
    private static  Eina.Error close(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_io_closer_close was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   Eina.Error _ret_var = default( Eina.Error);
         try {
            _ret_var = ((Task)wrapper).Close();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_io_closer_close(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_io_closer_close_delegate efl_io_closer_close_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_io_reader_can_read_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_io_reader_can_read_get(System.IntPtr obj);
    private static bool can_read_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_io_reader_can_read_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Task)wrapper).GetCanRead();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_io_reader_can_read_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_io_reader_can_read_get_delegate efl_io_reader_can_read_get_static_delegate;


    private delegate  void efl_io_reader_can_read_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool can_read);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_io_reader_can_read_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool can_read);
    private static  void can_read_set(System.IntPtr obj, System.IntPtr pd,  bool can_read)
   {
      Eina.Log.Debug("function efl_io_reader_can_read_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Task)wrapper).SetCanRead( can_read);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_io_reader_can_read_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  can_read);
      }
   }
   private efl_io_reader_can_read_set_delegate efl_io_reader_can_read_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_io_reader_eos_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_io_reader_eos_get(System.IntPtr obj);
    private static bool eos_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_io_reader_eos_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Task)wrapper).GetEos();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_io_reader_eos_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_io_reader_eos_get_delegate efl_io_reader_eos_get_static_delegate;


    private delegate  void efl_io_reader_eos_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool is_eos);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_io_reader_eos_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool is_eos);
    private static  void eos_set(System.IntPtr obj, System.IntPtr pd,  bool is_eos)
   {
      Eina.Log.Debug("function efl_io_reader_eos_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Task)wrapper).SetEos( is_eos);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_io_reader_eos_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  is_eos);
      }
   }
   private efl_io_reader_eos_set_delegate efl_io_reader_eos_set_static_delegate;


    private delegate  Eina.Error efl_io_reader_read_delegate(System.IntPtr obj, System.IntPtr pd,   ref Eina.RwSlice rw_slice);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  Eina.Error efl_io_reader_read(System.IntPtr obj,   ref Eina.RwSlice rw_slice);
    private static  Eina.Error read(System.IntPtr obj, System.IntPtr pd,  ref Eina.RwSlice rw_slice)
   {
      Eina.Log.Debug("function efl_io_reader_read was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                     Eina.Error _ret_var = default( Eina.Error);
         try {
            _ret_var = ((Task)wrapper).Read( ref rw_slice);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_io_reader_read(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  ref rw_slice);
      }
   }
   private efl_io_reader_read_delegate efl_io_reader_read_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_io_writer_can_write_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_io_writer_can_write_get(System.IntPtr obj);
    private static bool can_write_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_io_writer_can_write_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Task)wrapper).GetCanWrite();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_io_writer_can_write_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_io_writer_can_write_get_delegate efl_io_writer_can_write_get_static_delegate;


    private delegate  void efl_io_writer_can_write_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool can_write);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_io_writer_can_write_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool can_write);
    private static  void can_write_set(System.IntPtr obj, System.IntPtr pd,  bool can_write)
   {
      Eina.Log.Debug("function efl_io_writer_can_write_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Task)wrapper).SetCanWrite( can_write);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_io_writer_can_write_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  can_write);
      }
   }
   private efl_io_writer_can_write_set_delegate efl_io_writer_can_write_set_static_delegate;


    private delegate  Eina.Error efl_io_writer_write_delegate(System.IntPtr obj, System.IntPtr pd,   ref Eina.Slice slice,   ref Eina.Slice remaining);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  Eina.Error efl_io_writer_write(System.IntPtr obj,   ref Eina.Slice slice,   ref Eina.Slice remaining);
    private static  Eina.Error write(System.IntPtr obj, System.IntPtr pd,  ref Eina.Slice slice,  ref Eina.Slice remaining)
   {
      Eina.Log.Debug("function efl_io_writer_write was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                 remaining = default(Eina.Slice);                      Eina.Error _ret_var = default( Eina.Error);
         try {
            _ret_var = ((Task)wrapper).Write( ref slice,  ref remaining);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_io_writer_write(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  ref slice,  ref remaining);
      }
   }
   private efl_io_writer_write_delegate efl_io_writer_write_static_delegate;
}
} 
namespace Efl { 
/// <summary>No description supplied.</summary>
public enum TaskPriority
{
/// <summary></summary>
Normal = 0,
/// <summary></summary>
Background = 1,
/// <summary></summary>
Low = 2,
/// <summary></summary>
High = 3,
/// <summary></summary>
Ultra = 4,
}
} 
namespace Efl { 
/// <summary>No description supplied.</summary>
public enum TaskFlags
{
/// <summary></summary>
None = 0,
/// <summary></summary>
UseStdin = 1,
/// <summary></summary>
UseStdout = 2,
/// <summary></summary>
NoExitCodeError = 4,
}
} 
