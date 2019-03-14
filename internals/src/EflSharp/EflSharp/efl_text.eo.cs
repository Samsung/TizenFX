#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { 
/// <summary>Efl text interface</summary>
[TextNativeInherit]
public interface Text : 
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>Retrieves the text string currently being displayed by the given text object.
/// Do not free() the return value.
/// 
/// See also <see cref="Efl.Text.GetText"/>.</summary>
/// <returns>Text string to display on it.</returns>
 System.String GetText();
   /// <summary>Sets the text string to be displayed by the given text object.
/// See also <see cref="Efl.Text.GetText"/>.</summary>
/// <param name="text">Text string to display on it.</param>
/// <returns></returns>
 void SetText(  System.String text);
      }
/// <summary>Efl text interface</summary>
sealed public class TextConcrete : 

Text
   
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (TextConcrete))
            return Efl.TextNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
      }
   }
   private  System.IntPtr handle;
   ///<summary>Pointer to the native instance.</summary>
   public System.IntPtr NativeHandle {
      get { return handle; }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] internal static extern System.IntPtr
      efl_text_interface_get();
   ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
   public TextConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~TextConcrete()
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
   public static TextConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new TextConcrete(obj.NativeHandle);
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
   /// <summary>Retrieves the text string currently being displayed by the given text object.
   /// Do not free() the return value.
   /// 
   /// See also <see cref="Efl.Text.GetText"/>.</summary>
   /// <returns>Text string to display on it.</returns>
   public  System.String GetText() {
       var _ret_var = Efl.TextNativeInherit.efl_text_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Sets the text string to be displayed by the given text object.
   /// See also <see cref="Efl.Text.GetText"/>.</summary>
   /// <param name="text">Text string to display on it.</param>
   /// <returns></returns>
   public  void SetText(  System.String text) {
                         Efl.TextNativeInherit.efl_text_set_ptr.Value.Delegate(this.NativeHandle, text);
      Eina.Error.RaiseIfUnhandledException();
                   }
}
public class TextNativeInherit  : Efl.Eo.NativeClass{
   public  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Efl);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      if (efl_text_get_static_delegate == null)
      efl_text_get_static_delegate = new efl_text_get_delegate(text_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_get_static_delegate)});
      if (efl_text_set_static_delegate == null)
      efl_text_set_static_delegate = new efl_text_set_delegate(text_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_set_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.TextConcrete.efl_text_interface_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.TextConcrete.efl_text_interface_get();
   }


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate  System.String efl_text_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate  System.String efl_text_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_text_get_api_delegate> efl_text_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_get_api_delegate>(_Module, "efl_text_get");
    private static  System.String text_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((Text)wrapper).GetText();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_text_get_delegate efl_text_get_static_delegate;


    private delegate  void efl_text_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String text);


    public delegate  void efl_text_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String text);
    public static Efl.Eo.FunctionWrapper<efl_text_set_api_delegate> efl_text_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_set_api_delegate>(_Module, "efl_text_set");
    private static  void text_set(System.IntPtr obj, System.IntPtr pd,   System.String text)
   {
      Eina.Log.Debug("function efl_text_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Text)wrapper).SetText( text);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  text);
      }
   }
   private static efl_text_set_delegate efl_text_set_static_delegate;
}
} 
