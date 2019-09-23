#define EFL_BETA
#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

/// <summary>Object representing the application itself.
/// (Since EFL 1.22)</summary>
[Efl.App.NativeMethods]
[Efl.Eo.BindingEntity]
public abstract class App : Efl.Loop, Efl.Core.ICommandLine
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(App))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)] internal static extern System.IntPtr
        efl_app_class_get();
    /// <summary>Initializes a new instance of the <see cref="App"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public App(Efl.Object parent= null
            ) : base(efl_app_class_get(), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected App(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="App"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected App(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    [Efl.Eo.PrivateNativeClass]
    private class AppRealized : App
    {
        private AppRealized(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
        {
        }
    }
    /// <summary>Initializes a new instance of the <see cref="App"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected App(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }

    /// <summary>Called when the application is not going be displayed or otherwise used by a user for some time
    /// (Since EFL 1.22)</summary>
    public event EventHandler PauseEvent
    {
        add
        {
            lock (eflBindingEventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        EventArgs args = EventArgs.Empty;
                        try
                        {
                            value?.Invoke(obj, args);
                        }
                        catch (Exception e)
                        {
                            Eina.Log.Error(e.ToString());
                            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                        }
                    }
                };

                string key = "_EFL_APP_EVENT_PAUSE";
                AddNativeEventHandler(efl.Libs.Ecore, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_APP_EVENT_PAUSE";
                RemoveNativeEventHandler(efl.Libs.Ecore, key, value);
            }
        }
    }
    /// <summary>Method to raise event PauseEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnPauseEvent(EventArgs e)
    {
        var key = "_EFL_APP_EVENT_PAUSE";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Ecore, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called before a window is rendered after a pause event
    /// (Since EFL 1.22)</summary>
    public event EventHandler ResumeEvent
    {
        add
        {
            lock (eflBindingEventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        EventArgs args = EventArgs.Empty;
                        try
                        {
                            value?.Invoke(obj, args);
                        }
                        catch (Exception e)
                        {
                            Eina.Log.Error(e.ToString());
                            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                        }
                    }
                };

                string key = "_EFL_APP_EVENT_RESUME";
                AddNativeEventHandler(efl.Libs.Ecore, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_APP_EVENT_RESUME";
                RemoveNativeEventHandler(efl.Libs.Ecore, key, value);
            }
        }
    }
    /// <summary>Method to raise event ResumeEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnResumeEvent(EventArgs e)
    {
        var key = "_EFL_APP_EVENT_RESUME";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Ecore, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when the application&apos;s windows are all destroyed
    /// (Since EFL 1.22)</summary>
    public event EventHandler StandbyEvent
    {
        add
        {
            lock (eflBindingEventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        EventArgs args = EventArgs.Empty;
                        try
                        {
                            value?.Invoke(obj, args);
                        }
                        catch (Exception e)
                        {
                            Eina.Log.Error(e.ToString());
                            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                        }
                    }
                };

                string key = "_EFL_APP_EVENT_STANDBY";
                AddNativeEventHandler(efl.Libs.Ecore, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_APP_EVENT_STANDBY";
                RemoveNativeEventHandler(efl.Libs.Ecore, key, value);
            }
        }
    }
    /// <summary>Method to raise event StandbyEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnStandbyEvent(EventArgs e)
    {
        var key = "_EFL_APP_EVENT_STANDBY";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Ecore, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called before starting the shutdown of the application
    /// (Since EFL 1.22)</summary>
    public event EventHandler TerminateEvent
    {
        add
        {
            lock (eflBindingEventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        EventArgs args = EventArgs.Empty;
                        try
                        {
                            value?.Invoke(obj, args);
                        }
                        catch (Exception e)
                        {
                            Eina.Log.Error(e.ToString());
                            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                        }
                    }
                };

                string key = "_EFL_APP_EVENT_TERMINATE";
                AddNativeEventHandler(efl.Libs.Ecore, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_APP_EVENT_TERMINATE";
                RemoveNativeEventHandler(efl.Libs.Ecore, key, value);
            }
        }
    }
    /// <summary>Method to raise event TerminateEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnTerminateEvent(EventArgs e)
    {
        var key = "_EFL_APP_EVENT_TERMINATE";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Ecore, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>System specific, but on unix maps to SIGUSR1 signal to the process - only called on main loop object
    /// (Since EFL 1.22)</summary>
    public event EventHandler SignalUsr1Event
    {
        add
        {
            lock (eflBindingEventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        EventArgs args = EventArgs.Empty;
                        try
                        {
                            value?.Invoke(obj, args);
                        }
                        catch (Exception e)
                        {
                            Eina.Log.Error(e.ToString());
                            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                        }
                    }
                };

                string key = "_EFL_APP_EVENT_SIGNAL_USR1";
                AddNativeEventHandler(efl.Libs.Ecore, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_APP_EVENT_SIGNAL_USR1";
                RemoveNativeEventHandler(efl.Libs.Ecore, key, value);
            }
        }
    }
    /// <summary>Method to raise event SignalUsr1Event.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnSignalUsr1Event(EventArgs e)
    {
        var key = "_EFL_APP_EVENT_SIGNAL_USR1";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Ecore, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>System specific, but on unix maps to SIGUSR2 signal to the process - only called on main loop object
    /// (Since EFL 1.22)</summary>
    public event EventHandler SignalUsr2Event
    {
        add
        {
            lock (eflBindingEventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        EventArgs args = EventArgs.Empty;
                        try
                        {
                            value?.Invoke(obj, args);
                        }
                        catch (Exception e)
                        {
                            Eina.Log.Error(e.ToString());
                            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                        }
                    }
                };

                string key = "_EFL_APP_EVENT_SIGNAL_USR2";
                AddNativeEventHandler(efl.Libs.Ecore, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_APP_EVENT_SIGNAL_USR2";
                RemoveNativeEventHandler(efl.Libs.Ecore, key, value);
            }
        }
    }
    /// <summary>Method to raise event SignalUsr2Event.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnSignalUsr2Event(EventArgs e)
    {
        var key = "_EFL_APP_EVENT_SIGNAL_USR2";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Ecore, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>System specific, but on unix maps to SIGHUP signal to the process - only called on main loop object
    /// (Since EFL 1.22)</summary>
    public event EventHandler SignalHupEvent
    {
        add
        {
            lock (eflBindingEventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        EventArgs args = EventArgs.Empty;
                        try
                        {
                            value?.Invoke(obj, args);
                        }
                        catch (Exception e)
                        {
                            Eina.Log.Error(e.ToString());
                            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                        }
                    }
                };

                string key = "_EFL_APP_EVENT_SIGNAL_HUP";
                AddNativeEventHandler(efl.Libs.Ecore, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_APP_EVENT_SIGNAL_HUP";
                RemoveNativeEventHandler(efl.Libs.Ecore, key, value);
            }
        }
    }
    /// <summary>Method to raise event SignalHupEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnSignalHupEvent(EventArgs e)
    {
        var key = "_EFL_APP_EVENT_SIGNAL_HUP";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Ecore, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Returns the app object that is representing this process
    /// Note: This function call only works in the main loop thread of the process.
    /// (Since EFL 1.22)</summary>
    /// <returns>Application for this process</returns>
    public static Efl.App GetAppMain() {
         var _ret_var = Efl.App.NativeMethods.efl_app_main_get_ptr.Value.Delegate();
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Indicates the version of EFL with which this application was compiled against/for.
    /// This might differ from <see cref="Efl.App.GetEflVersion"/>.
    /// (Since EFL 1.22)</summary>
    /// <returns>Efl build version</returns>
    public virtual Efl.Version GetBuildEflVersion() {
         var _ret_var = Efl.App.NativeMethods.efl_app_build_efl_version_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        var __ret_tmp = Eina.PrimitiveConversion.PointerToManaged<Efl.Version>(_ret_var);
        
        return __ret_tmp;
 }
    /// <summary>Indicates the currently running version of EFL.
    /// This might differ from <see cref="Efl.App.GetBuildEflVersion"/>.
    /// (Since EFL 1.22)</summary>
    /// <returns>Efl version</returns>
    public virtual Efl.Version GetEflVersion() {
         var _ret_var = Efl.App.NativeMethods.efl_app_efl_version_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        var __ret_tmp = Eina.PrimitiveConversion.PointerToManaged<Efl.Version>(_ret_var);
        
        return __ret_tmp;
 }
    /// <summary>A commandline that encodes arguments in a command string. This command is unix shell-style, thus whitespace separates arguments unless escaped. Also a semi-colon &apos;;&apos;, ampersand &apos;&amp;&apos;, pipe/bar &apos;|&apos;, hash &apos;#&apos;, bracket, square brace, brace character (&apos;(&apos;, &apos;)&apos;, &apos;[&apos;, &apos;]&apos;, &apos;{&apos;, &apos;}&apos;), exclamation mark &apos;!&apos;,  backquote &apos;`&apos;, greator or less than (&apos;&gt;&apos; &apos;&lt;&apos;) character unless escaped or in quotes would cause args_count/value to not be generated properly, because it would force complex shell interpretation which will not be supported in evaluating the arg_count/value information, but the final shell may interpret this if this is executed via a command-line shell. To not be a complex shell command, it should be simple with paths, options and variable expansions, but nothing more complex involving the above unescaped characters.
    /// &quot;cat -option /path/file&quot; &quot;cat &apos;quoted argument&apos;&quot; &quot;cat ~/path/escaped argument&quot; &quot;/bin/cat escaped argument <c>VARIABLE</c>&quot; etc.
    /// 
    /// It should not try and use &quot;complex shell features&quot; if you want the arg_count and arg_value set to be correct after setting the command string. For example none of:
    /// 
    /// &quot;VAR=x /bin/command &amp;&amp; /bin/othercommand &gt;&amp; /dev/null&quot; &quot;VAR=x /bin/command `/bin/othercommand` | /bin/cmd2 &amp;&amp; cmd3 &amp;&quot; etc.
    /// 
    /// If you set the command the arg_count/value property contents can change and be completely re-evaluated by parsing the command string into an argument array set along with interpreting escapes back into individual argument strings.</summary>
    public virtual System.String GetCommand() {
         var _ret_var = Efl.Core.CommandLineConcrete.NativeMethods.efl_core_command_line_command_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Use an array to fill this object
    /// Every element of a string is a argument.</summary>
    /// <param name="array">An array where every array field is an argument</param>
    /// <returns>On success <c>true</c>, <c>false</c> otherwise</returns>
    public virtual bool SetCommandArray(Eina.Array<Eina.Stringshare> array) {
         var _in_array = array.Handle;
array.Own = false;
array.OwnContent = false;
                        var _ret_var = Efl.Core.CommandLineConcrete.NativeMethods.efl_core_command_line_command_array_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_array);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Use a string to fill this object
    /// The string will be split at every unescaped &apos; &apos;, every resulting substring will be a new argument to the command line.</summary>
    /// <param name="str">A command in form of a string</param>
    /// <returns>On success <c>true</c>, <c>false</c> otherwise</returns>
    public virtual bool SetCommandString(System.String str) {
                                 var _ret_var = Efl.Core.CommandLineConcrete.NativeMethods.efl_core_command_line_command_string_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),str);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Get the accessor which enables access to each argument that got passed to this object.</summary>
    public virtual Eina.Accessor<Eina.Stringshare> CommandAccess() {
         var _ret_var = Efl.Core.CommandLineConcrete.NativeMethods.efl_core_command_line_command_access_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return new Eina.Accessor<Eina.Stringshare>(_ret_var, false);
 }
    /// <summary>Returns the app object that is representing this process
    /// Note: This function call only works in the main loop thread of the process.
    /// (Since EFL 1.22)</summary>
    /// <value>Application for this process</value>
    public static Efl.App AppMain {
        get { return GetAppMain(); }
    }
    /// <summary>Indicates the version of EFL with which this application was compiled against/for.
    /// This might differ from <see cref="Efl.App.GetEflVersion"/>.
    /// (Since EFL 1.22)</summary>
    /// <value>Efl build version</value>
    public Efl.Version BuildEflVersion {
        get { return GetBuildEflVersion(); }
    }
    /// <summary>Indicates the currently running version of EFL.
    /// This might differ from <see cref="Efl.App.GetBuildEflVersion"/>.
    /// (Since EFL 1.22)</summary>
    /// <value>Efl version</value>
    public Efl.Version EflVersion {
        get { return GetEflVersion(); }
    }
    /// <summary>A commandline that encodes arguments in a command string. This command is unix shell-style, thus whitespace separates arguments unless escaped. Also a semi-colon &apos;;&apos;, ampersand &apos;&amp;&apos;, pipe/bar &apos;|&apos;, hash &apos;#&apos;, bracket, square brace, brace character (&apos;(&apos;, &apos;)&apos;, &apos;[&apos;, &apos;]&apos;, &apos;{&apos;, &apos;}&apos;), exclamation mark &apos;!&apos;,  backquote &apos;`&apos;, greator or less than (&apos;&gt;&apos; &apos;&lt;&apos;) character unless escaped or in quotes would cause args_count/value to not be generated properly, because it would force complex shell interpretation which will not be supported in evaluating the arg_count/value information, but the final shell may interpret this if this is executed via a command-line shell. To not be a complex shell command, it should be simple with paths, options and variable expansions, but nothing more complex involving the above unescaped characters.
    /// &quot;cat -option /path/file&quot; &quot;cat &apos;quoted argument&apos;&quot; &quot;cat ~/path/escaped argument&quot; &quot;/bin/cat escaped argument <c>VARIABLE</c>&quot; etc.
    /// 
    /// It should not try and use &quot;complex shell features&quot; if you want the arg_count and arg_value set to be correct after setting the command string. For example none of:
    /// 
    /// &quot;VAR=x /bin/command &amp;&amp; /bin/othercommand &gt;&amp; /dev/null&quot; &quot;VAR=x /bin/command `/bin/othercommand` | /bin/cmd2 &amp;&amp; cmd3 &amp;&quot; etc.
    /// 
    /// If you set the command the arg_count/value property contents can change and be completely re-evaluated by parsing the command string into an argument array set along with interpreting escapes back into individual argument strings.</summary>
    public System.String Command {
        get { return GetCommand(); }
    }
    /// <summary>Use an array to fill this object
    /// Every element of a string is a argument.</summary>
    /// <value>An array where every array field is an argument</value>
    public Eina.Array<Eina.Stringshare> CommandArray {
        set { SetCommandArray(value); }
    }
    /// <summary>Use a string to fill this object
    /// The string will be split at every unescaped &apos; &apos;, every resulting substring will be a new argument to the command line.</summary>
    /// <value>A command in form of a string</value>
    public System.String CommandString {
        set { SetCommandString(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.App.efl_app_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Loop.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Ecore);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_app_build_efl_version_get_static_delegate == null)
            {
                efl_app_build_efl_version_get_static_delegate = new efl_app_build_efl_version_get_delegate(build_efl_version_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetBuildEflVersion") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_app_build_efl_version_get"), func = Marshal.GetFunctionPointerForDelegate(efl_app_build_efl_version_get_static_delegate) });
            }

            if (efl_app_efl_version_get_static_delegate == null)
            {
                efl_app_efl_version_get_static_delegate = new efl_app_efl_version_get_delegate(efl_version_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetEflVersion") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_app_efl_version_get"), func = Marshal.GetFunctionPointerForDelegate(efl_app_efl_version_get_static_delegate) });
            }

            if (includeInherited)
            {
                var all_interfaces = type.GetInterfaces();
                foreach (var iface in all_interfaces)
                {
                    var moredescs = ((Efl.Eo.NativeClass)iface.GetCustomAttributes(false)?.FirstOrDefault(attr => attr is Efl.Eo.NativeClass))?.GetEoOps(type, false);
                    if (moredescs != null)
                        descs.AddRange(moredescs);
                }
            }
            descs.AddRange(base.GetEoOps(type, false));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.App.efl_app_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.App efl_app_main_get_delegate();

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.App efl_app_main_get_api_delegate();

        public static Efl.Eo.FunctionWrapper<efl_app_main_get_api_delegate> efl_app_main_get_ptr = new Efl.Eo.FunctionWrapper<efl_app_main_get_api_delegate>(Module, "efl_app_main_get");

        private static Efl.App app_main_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_app_main_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.App _ret_var = default(Efl.App);
                try
                {
                    _ret_var = App.GetAppMain();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        return _ret_var;

            }
            else
            {
                return efl_app_main_get_ptr.Value.Delegate();
            }
        }

        
        private delegate System.IntPtr efl_app_build_efl_version_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate System.IntPtr efl_app_build_efl_version_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_app_build_efl_version_get_api_delegate> efl_app_build_efl_version_get_ptr = new Efl.Eo.FunctionWrapper<efl_app_build_efl_version_get_api_delegate>(Module, "efl_app_build_efl_version_get");

        private static System.IntPtr build_efl_version_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_app_build_efl_version_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Version _ret_var = default(Efl.Version);
                try
                {
                    _ret_var = ((App)ws.Target).GetBuildEflVersion();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        return Eina.PrimitiveConversion.ManagedToPointerAlloc(_ret_var);

            }
            else
            {
                return efl_app_build_efl_version_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_app_build_efl_version_get_delegate efl_app_build_efl_version_get_static_delegate;

        
        private delegate System.IntPtr efl_app_efl_version_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate System.IntPtr efl_app_efl_version_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_app_efl_version_get_api_delegate> efl_app_efl_version_get_ptr = new Efl.Eo.FunctionWrapper<efl_app_efl_version_get_api_delegate>(Module, "efl_app_efl_version_get");

        private static System.IntPtr efl_version_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_app_efl_version_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Version _ret_var = default(Efl.Version);
                try
                {
                    _ret_var = ((App)ws.Target).GetEflVersion();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        return Eina.PrimitiveConversion.ManagedToPointerAlloc(_ret_var);

            }
            else
            {
                return efl_app_efl_version_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_app_efl_version_get_delegate efl_app_efl_version_get_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

#if EFL_BETA
#pragma warning disable CS1591
public static class EflApp_ExtensionMethods {
    
    
    
    
    public static Efl.BindableProperty<Eina.Array<Eina.Stringshare>> CommandArray<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.App, T>magic = null) where T : Efl.App {
        return new Efl.BindableProperty<Eina.Array<Eina.Stringshare>>("command_array", fac);
    }

    public static Efl.BindableProperty<System.String> CommandString<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.App, T>magic = null) where T : Efl.App {
        return new Efl.BindableProperty<System.String>("command_string", fac);
    }

}
#pragma warning restore CS1591
#endif
