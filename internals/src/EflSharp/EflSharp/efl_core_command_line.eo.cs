#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Core { 
/// <summary>A mixin that implements standard functions for command lines.
/// This object parses the command line that gets passed, later the object can be accessed via accessor or the string directly.</summary>
[CommandLineNativeInherit]
public interface CommandLine : 
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>A commandline that encodes arguments in a command string. This command is unix shell-style, thus whitespace separates arguments unless escaped. Also a semi-colon &apos;;&apos;, ampersand &apos;&amp;&apos;, pipe/bar &apos;|&apos;, hash &apos;#&apos;, bracket, square brace, brace character (&apos;(&apos;, &apos;)&apos;, &apos;[&apos;, &apos;]&apos;, &apos;{&apos;, &apos;}&apos;), exclamation mark &apos;!&apos;,  backquote &apos;`&apos;, greator or less than (&apos;&gt;&apos; &apos;&lt;&apos;) character unless escaped or in quotes would cause args_count/value to not be generated properly, because it would force complex shell interpretation which will not be supported in evaluating the arg_count/value information, but the final shell may interpret this if this is executed via a command-line shell. To not be a complex shell command, it should be simple with paths, options and variable expansions, but nothing more complex involving the above unescaped characters.
/// &quot;cat -option /path/file&quot; &quot;cat &apos;quoted argument&apos;&quot; &quot;cat ~/path/escaped argument&quot; &quot;/bin/cat escaped argument <c>VARIABLE</c>&quot; etc.
/// 
/// It should not try and use &quot;complex shell features&quot; if you want the arg_count and arg_value set to be correct after setting the command string. For example none of:
/// 
/// &quot;VAR=x /bin/command &amp;&amp; /bin/othercommand &gt;&amp; /dev/null&quot; &quot;VAR=x /bin/command `/bin/othercommand` | /bin/cmd2 &amp;&amp; cmd3 &amp;&quot; etc.
/// 
/// If you set the command the arg_count/value property contents can change and be completely re-evaluated by parsing the command string into an argument array set along with interpreting escapes back into individual argument strings.</summary>
/// <returns></returns>
 System.String GetCommand();
   /// <summary>Use an array to fill this object
/// Every element of a string is a argument.</summary>
/// <param name="array">An array where every array field is an argument</param>
/// <returns>On success <c>true</c>, <c>false</c> otherwise</returns>
bool SetCommandArray( Eina.Array< System.String> array);
   /// <summary>Use a string to fill this object
/// The string will be split at every unescaped &apos; &apos;, every resulting substring will be a new argument to the command line.</summary>
/// <param name="str">A command in form of a string</param>
/// <returns>On success <c>true</c>, <c>false</c> otherwise</returns>
bool SetCommandString(  System.String str);
   /// <summary>Get the accessor which enables access to each argument that got passed to this object.</summary>
/// <returns></returns>
Eina.Accessor< System.String> CommandAccess();
               /// <summary>A commandline that encodes arguments in a command string. This command is unix shell-style, thus whitespace separates arguments unless escaped. Also a semi-colon &apos;;&apos;, ampersand &apos;&amp;&apos;, pipe/bar &apos;|&apos;, hash &apos;#&apos;, bracket, square brace, brace character (&apos;(&apos;, &apos;)&apos;, &apos;[&apos;, &apos;]&apos;, &apos;{&apos;, &apos;}&apos;), exclamation mark &apos;!&apos;,  backquote &apos;`&apos;, greator or less than (&apos;&gt;&apos; &apos;&lt;&apos;) character unless escaped or in quotes would cause args_count/value to not be generated properly, because it would force complex shell interpretation which will not be supported in evaluating the arg_count/value information, but the final shell may interpret this if this is executed via a command-line shell. To not be a complex shell command, it should be simple with paths, options and variable expansions, but nothing more complex involving the above unescaped characters.
/// &quot;cat -option /path/file&quot; &quot;cat &apos;quoted argument&apos;&quot; &quot;cat ~/path/escaped argument&quot; &quot;/bin/cat escaped argument <c>VARIABLE</c>&quot; etc.
/// 
/// It should not try and use &quot;complex shell features&quot; if you want the arg_count and arg_value set to be correct after setting the command string. For example none of:
/// 
/// &quot;VAR=x /bin/command &amp;&amp; /bin/othercommand &gt;&amp; /dev/null&quot; &quot;VAR=x /bin/command `/bin/othercommand` | /bin/cmd2 &amp;&amp; cmd3 &amp;&quot; etc.
/// 
/// If you set the command the arg_count/value property contents can change and be completely re-evaluated by parsing the command string into an argument array set along with interpreting escapes back into individual argument strings.</summary>
/// <value></value>
    System.String Command {
      get ;
   }
   /// <summary>Use an array to fill this object
/// Every element of a string is a argument.</summary>
/// <value>An array where every array field is an argument</value>
   Eina.Array< System.String> CommandArray {
      set ;
   }
   /// <summary>Use a string to fill this object
/// The string will be split at every unescaped &apos; &apos;, every resulting substring will be a new argument to the command line.</summary>
/// <value>A command in form of a string</value>
    System.String CommandString {
      set ;
   }
}
/// <summary>A mixin that implements standard functions for command lines.
/// This object parses the command line that gets passed, later the object can be accessed via accessor or the string directly.</summary>
sealed public class CommandLineConcrete : 

CommandLine
   
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (CommandLineConcrete))
            return Efl.Core.CommandLineNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
      }
   }
   private  System.IntPtr handle;
   ///<summary>Pointer to the native instance.</summary>
   public System.IntPtr NativeHandle {
      get { return handle; }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)] internal static extern System.IntPtr
      efl_core_command_line_mixin_get();
   ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
   public CommandLineConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~CommandLineConcrete()
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
   public static CommandLineConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new CommandLineConcrete(obj.NativeHandle);
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
   /// <summary>A commandline that encodes arguments in a command string. This command is unix shell-style, thus whitespace separates arguments unless escaped. Also a semi-colon &apos;;&apos;, ampersand &apos;&amp;&apos;, pipe/bar &apos;|&apos;, hash &apos;#&apos;, bracket, square brace, brace character (&apos;(&apos;, &apos;)&apos;, &apos;[&apos;, &apos;]&apos;, &apos;{&apos;, &apos;}&apos;), exclamation mark &apos;!&apos;,  backquote &apos;`&apos;, greator or less than (&apos;&gt;&apos; &apos;&lt;&apos;) character unless escaped or in quotes would cause args_count/value to not be generated properly, because it would force complex shell interpretation which will not be supported in evaluating the arg_count/value information, but the final shell may interpret this if this is executed via a command-line shell. To not be a complex shell command, it should be simple with paths, options and variable expansions, but nothing more complex involving the above unescaped characters.
   /// &quot;cat -option /path/file&quot; &quot;cat &apos;quoted argument&apos;&quot; &quot;cat ~/path/escaped argument&quot; &quot;/bin/cat escaped argument <c>VARIABLE</c>&quot; etc.
   /// 
   /// It should not try and use &quot;complex shell features&quot; if you want the arg_count and arg_value set to be correct after setting the command string. For example none of:
   /// 
   /// &quot;VAR=x /bin/command &amp;&amp; /bin/othercommand &gt;&amp; /dev/null&quot; &quot;VAR=x /bin/command `/bin/othercommand` | /bin/cmd2 &amp;&amp; cmd3 &amp;&quot; etc.
   /// 
   /// If you set the command the arg_count/value property contents can change and be completely re-evaluated by parsing the command string into an argument array set along with interpreting escapes back into individual argument strings.</summary>
   /// <returns></returns>
   public  System.String GetCommand() {
       var _ret_var = Efl.Core.CommandLineNativeInherit.efl_core_command_line_command_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Use an array to fill this object
   /// Every element of a string is a argument.</summary>
   /// <param name="array">An array where every array field is an argument</param>
   /// <returns>On success <c>true</c>, <c>false</c> otherwise</returns>
   public bool SetCommandArray( Eina.Array< System.String> array) {
       var _in_array = array.Handle;
array.Own = false;
array.OwnContent = false;
                  var _ret_var = Efl.Core.CommandLineNativeInherit.efl_core_command_line_command_array_set_ptr.Value.Delegate(this.NativeHandle, _in_array);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Use a string to fill this object
   /// The string will be split at every unescaped &apos; &apos;, every resulting substring will be a new argument to the command line.</summary>
   /// <param name="str">A command in form of a string</param>
   /// <returns>On success <c>true</c>, <c>false</c> otherwise</returns>
   public bool SetCommandString(  System.String str) {
                         var _ret_var = Efl.Core.CommandLineNativeInherit.efl_core_command_line_command_string_set_ptr.Value.Delegate(this.NativeHandle, str);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Get the accessor which enables access to each argument that got passed to this object.</summary>
   /// <returns></returns>
   public Eina.Accessor< System.String> CommandAccess() {
       var _ret_var = Efl.Core.CommandLineNativeInherit.efl_core_command_line_command_access_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return new Eina.Accessor< System.String>(_ret_var, false, false);
 }
   /// <summary>A commandline that encodes arguments in a command string. This command is unix shell-style, thus whitespace separates arguments unless escaped. Also a semi-colon &apos;;&apos;, ampersand &apos;&amp;&apos;, pipe/bar &apos;|&apos;, hash &apos;#&apos;, bracket, square brace, brace character (&apos;(&apos;, &apos;)&apos;, &apos;[&apos;, &apos;]&apos;, &apos;{&apos;, &apos;}&apos;), exclamation mark &apos;!&apos;,  backquote &apos;`&apos;, greator or less than (&apos;&gt;&apos; &apos;&lt;&apos;) character unless escaped or in quotes would cause args_count/value to not be generated properly, because it would force complex shell interpretation which will not be supported in evaluating the arg_count/value information, but the final shell may interpret this if this is executed via a command-line shell. To not be a complex shell command, it should be simple with paths, options and variable expansions, but nothing more complex involving the above unescaped characters.
/// &quot;cat -option /path/file&quot; &quot;cat &apos;quoted argument&apos;&quot; &quot;cat ~/path/escaped argument&quot; &quot;/bin/cat escaped argument <c>VARIABLE</c>&quot; etc.
/// 
/// It should not try and use &quot;complex shell features&quot; if you want the arg_count and arg_value set to be correct after setting the command string. For example none of:
/// 
/// &quot;VAR=x /bin/command &amp;&amp; /bin/othercommand &gt;&amp; /dev/null&quot; &quot;VAR=x /bin/command `/bin/othercommand` | /bin/cmd2 &amp;&amp; cmd3 &amp;&quot; etc.
/// 
/// If you set the command the arg_count/value property contents can change and be completely re-evaluated by parsing the command string into an argument array set along with interpreting escapes back into individual argument strings.</summary>
/// <value></value>
   public  System.String Command {
      get { return GetCommand(); }
   }
   /// <summary>Use an array to fill this object
/// Every element of a string is a argument.</summary>
/// <value>An array where every array field is an argument</value>
   public Eina.Array< System.String> CommandArray {
      set { SetCommandArray( value); }
   }
   /// <summary>Use a string to fill this object
/// The string will be split at every unescaped &apos; &apos;, every resulting substring will be a new argument to the command line.</summary>
/// <value>A command in form of a string</value>
   public  System.String CommandString {
      set { SetCommandString( value); }
   }
}
public class CommandLineNativeInherit  : Efl.Eo.NativeClass{
   public  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Ecore);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      if (efl_core_command_line_command_get_static_delegate == null)
      efl_core_command_line_command_get_static_delegate = new efl_core_command_line_command_get_delegate(command_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_core_command_line_command_get"), func = Marshal.GetFunctionPointerForDelegate(efl_core_command_line_command_get_static_delegate)});
      if (efl_core_command_line_command_array_set_static_delegate == null)
      efl_core_command_line_command_array_set_static_delegate = new efl_core_command_line_command_array_set_delegate(command_array_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_core_command_line_command_array_set"), func = Marshal.GetFunctionPointerForDelegate(efl_core_command_line_command_array_set_static_delegate)});
      if (efl_core_command_line_command_string_set_static_delegate == null)
      efl_core_command_line_command_string_set_static_delegate = new efl_core_command_line_command_string_set_delegate(command_string_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_core_command_line_command_string_set"), func = Marshal.GetFunctionPointerForDelegate(efl_core_command_line_command_string_set_static_delegate)});
      if (efl_core_command_line_command_access_static_delegate == null)
      efl_core_command_line_command_access_static_delegate = new efl_core_command_line_command_access_delegate(command_access);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_core_command_line_command_access"), func = Marshal.GetFunctionPointerForDelegate(efl_core_command_line_command_access_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Core.CommandLineConcrete.efl_core_command_line_mixin_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.Core.CommandLineConcrete.efl_core_command_line_mixin_get();
   }


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate  System.String efl_core_command_line_command_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate  System.String efl_core_command_line_command_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_core_command_line_command_get_api_delegate> efl_core_command_line_command_get_ptr = new Efl.Eo.FunctionWrapper<efl_core_command_line_command_get_api_delegate>(_Module, "efl_core_command_line_command_get");
    private static  System.String command_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_core_command_line_command_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((CommandLineConcrete)wrapper).GetCommand();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_core_command_line_command_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_core_command_line_command_get_delegate efl_core_command_line_command_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_core_command_line_command_array_set_delegate(System.IntPtr obj, System.IntPtr pd,    System.IntPtr array);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_core_command_line_command_array_set_api_delegate(System.IntPtr obj,    System.IntPtr array);
    public static Efl.Eo.FunctionWrapper<efl_core_command_line_command_array_set_api_delegate> efl_core_command_line_command_array_set_ptr = new Efl.Eo.FunctionWrapper<efl_core_command_line_command_array_set_api_delegate>(_Module, "efl_core_command_line_command_array_set");
    private static bool command_array_set(System.IntPtr obj, System.IntPtr pd,   System.IntPtr array)
   {
      Eina.Log.Debug("function efl_core_command_line_command_array_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_array = new Eina.Array< System.String>(array, true, true);
                     bool _ret_var = default(bool);
         try {
            _ret_var = ((CommandLineConcrete)wrapper).SetCommandArray( _in_array);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_core_command_line_command_array_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  array);
      }
   }
   private static efl_core_command_line_command_array_set_delegate efl_core_command_line_command_array_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_core_command_line_command_string_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String str);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_core_command_line_command_string_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String str);
    public static Efl.Eo.FunctionWrapper<efl_core_command_line_command_string_set_api_delegate> efl_core_command_line_command_string_set_ptr = new Efl.Eo.FunctionWrapper<efl_core_command_line_command_string_set_api_delegate>(_Module, "efl_core_command_line_command_string_set");
    private static bool command_string_set(System.IntPtr obj, System.IntPtr pd,   System.String str)
   {
      Eina.Log.Debug("function efl_core_command_line_command_string_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((CommandLineConcrete)wrapper).SetCommandString( str);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_core_command_line_command_string_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  str);
      }
   }
   private static efl_core_command_line_command_string_set_delegate efl_core_command_line_command_string_set_static_delegate;


    private delegate  System.IntPtr efl_core_command_line_command_access_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  System.IntPtr efl_core_command_line_command_access_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_core_command_line_command_access_api_delegate> efl_core_command_line_command_access_ptr = new Efl.Eo.FunctionWrapper<efl_core_command_line_command_access_api_delegate>(_Module, "efl_core_command_line_command_access");
    private static  System.IntPtr command_access(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_core_command_line_command_access was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Accessor< System.String> _ret_var = default(Eina.Accessor< System.String>);
         try {
            _ret_var = ((CommandLineConcrete)wrapper).CommandAccess();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var.Handle;
      } else {
         return efl_core_command_line_command_access_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_core_command_line_command_access_delegate efl_core_command_line_command_access_static_delegate;
}
} } 
