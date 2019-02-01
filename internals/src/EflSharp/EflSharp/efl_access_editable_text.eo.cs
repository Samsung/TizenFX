#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Access { namespace Editable { 
/// <summary>Elementary editable text interface</summary>
[TextConcreteNativeInherit]
public interface Text : 
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>Editable content property</summary>
/// <param name="kw_string">Content</param>
/// <returns><c>true</c> if setting the value succeeded, <c>false</c> otherwise</returns>
bool SetTextContent(  System.String kw_string);
   /// <summary>Insert text at given position</summary>
/// <param name="kw_string">String to be inserted</param>
/// <param name="position">Position to insert string</param>
/// <returns><c>true</c> if insert succeeded, <c>false</c> otherwise</returns>
bool Insert(  System.String kw_string,   int position);
   /// <summary>Copy text between start and end parameter</summary>
/// <param name="start">Start position to copy</param>
/// <param name="end">End position to copy</param>
/// <returns><c>true</c> if copy succeeded, <c>false</c> otherwise</returns>
bool Copy(  int start,   int end);
   /// <summary>Cut text between start and end parameter</summary>
/// <param name="start">Start position to cut</param>
/// <param name="end">End position to cut</param>
/// <returns><c>true</c> if cut succeeded, <c>false</c> otherwise</returns>
bool Cut(  int start,   int end);
   /// <summary>Delete text between start and end parameter</summary>
/// <param name="start">Start position to delete</param>
/// <param name="end">End position to delete</param>
/// <returns><c>true</c> if delete succeeded, <c>false</c> otherwise</returns>
bool Delete(  int start,   int end);
   /// <summary>Paste text at given position</summary>
/// <param name="position">Position to insert text</param>
/// <returns><c>true</c> if paste succeeded, <c>false</c> otherwise</returns>
bool Paste(  int position);
                     /// <summary>Editable content property</summary>
    System.String TextContent {
      set ;
   }
}
/// <summary>Elementary editable text interface</summary>
sealed public class TextConcrete : 

Text
   
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (TextConcrete))
            return Efl.Access.Editable.TextConcreteNativeInherit.GetEflClassStatic();
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
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
      efl_access_editable_text_interface_get();
   ///<summary>Constructs an instance from a native pointer.</summary>
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
   Efl.Eo.Globals.free_dict_values(cached_strings);
   Efl.Eo.Globals.free_stringshare_values(cached_stringshares);
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


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_access_editable_text_content_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String kw_string);
   /// <summary>Editable content property</summary>
   /// <param name="kw_string">Content</param>
   /// <returns><c>true</c> if setting the value succeeded, <c>false</c> otherwise</returns>
   public bool SetTextContent(  System.String kw_string) {
                         var _ret_var = efl_access_editable_text_content_set(Efl.Access.Editable.TextConcrete.efl_access_editable_text_interface_get(),  kw_string);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_access_editable_text_insert(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String kw_string,    int position);
   /// <summary>Insert text at given position</summary>
   /// <param name="kw_string">String to be inserted</param>
   /// <param name="position">Position to insert string</param>
   /// <returns><c>true</c> if insert succeeded, <c>false</c> otherwise</returns>
   public bool Insert(  System.String kw_string,   int position) {
                                           var _ret_var = efl_access_editable_text_insert(Efl.Access.Editable.TextConcrete.efl_access_editable_text_interface_get(),  kw_string,  position);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_access_editable_text_copy(System.IntPtr obj,    int start,    int end);
   /// <summary>Copy text between start and end parameter</summary>
   /// <param name="start">Start position to copy</param>
   /// <param name="end">End position to copy</param>
   /// <returns><c>true</c> if copy succeeded, <c>false</c> otherwise</returns>
   public bool Copy(  int start,   int end) {
                                           var _ret_var = efl_access_editable_text_copy(Efl.Access.Editable.TextConcrete.efl_access_editable_text_interface_get(),  start,  end);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_access_editable_text_cut(System.IntPtr obj,    int start,    int end);
   /// <summary>Cut text between start and end parameter</summary>
   /// <param name="start">Start position to cut</param>
   /// <param name="end">End position to cut</param>
   /// <returns><c>true</c> if cut succeeded, <c>false</c> otherwise</returns>
   public bool Cut(  int start,   int end) {
                                           var _ret_var = efl_access_editable_text_cut(Efl.Access.Editable.TextConcrete.efl_access_editable_text_interface_get(),  start,  end);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_access_editable_text_delete(System.IntPtr obj,    int start,    int end);
   /// <summary>Delete text between start and end parameter</summary>
   /// <param name="start">Start position to delete</param>
   /// <param name="end">End position to delete</param>
   /// <returns><c>true</c> if delete succeeded, <c>false</c> otherwise</returns>
   public bool Delete(  int start,   int end) {
                                           var _ret_var = efl_access_editable_text_delete(Efl.Access.Editable.TextConcrete.efl_access_editable_text_interface_get(),  start,  end);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_access_editable_text_paste(System.IntPtr obj,    int position);
   /// <summary>Paste text at given position</summary>
   /// <param name="position">Position to insert text</param>
   /// <returns><c>true</c> if paste succeeded, <c>false</c> otherwise</returns>
   public bool Paste(  int position) {
                         var _ret_var = efl_access_editable_text_paste(Efl.Access.Editable.TextConcrete.efl_access_editable_text_interface_get(),  position);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Editable content property</summary>
   public  System.String TextContent {
      set { SetTextContent( value); }
   }
}
public class TextConcreteNativeInherit : Efl.Eo.NativeClass{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_access_editable_text_content_set_static_delegate = new efl_access_editable_text_content_set_delegate(text_content_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_editable_text_content_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_editable_text_content_set_static_delegate)});
      efl_access_editable_text_insert_static_delegate = new efl_access_editable_text_insert_delegate(insert);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_editable_text_insert"), func = Marshal.GetFunctionPointerForDelegate(efl_access_editable_text_insert_static_delegate)});
      efl_access_editable_text_copy_static_delegate = new efl_access_editable_text_copy_delegate(copy);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_editable_text_copy"), func = Marshal.GetFunctionPointerForDelegate(efl_access_editable_text_copy_static_delegate)});
      efl_access_editable_text_cut_static_delegate = new efl_access_editable_text_cut_delegate(cut);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_editable_text_cut"), func = Marshal.GetFunctionPointerForDelegate(efl_access_editable_text_cut_static_delegate)});
      efl_access_editable_text_delete_static_delegate = new efl_access_editable_text_delete_delegate(kw_delete);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_editable_text_delete"), func = Marshal.GetFunctionPointerForDelegate(efl_access_editable_text_delete_static_delegate)});
      efl_access_editable_text_paste_static_delegate = new efl_access_editable_text_paste_delegate(paste);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_editable_text_paste"), func = Marshal.GetFunctionPointerForDelegate(efl_access_editable_text_paste_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Access.Editable.TextConcrete.efl_access_editable_text_interface_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.Access.Editable.TextConcrete.efl_access_editable_text_interface_get();
   }


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_access_editable_text_content_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String kw_string);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_access_editable_text_content_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String kw_string);
    private static bool text_content_set(System.IntPtr obj, System.IntPtr pd,   System.String kw_string)
   {
      Eina.Log.Debug("function efl_access_editable_text_content_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((Text)wrapper).SetTextContent( kw_string);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_access_editable_text_content_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  kw_string);
      }
   }
   private efl_access_editable_text_content_set_delegate efl_access_editable_text_content_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_access_editable_text_insert_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String kw_string,    int position);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_access_editable_text_insert(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String kw_string,    int position);
    private static bool insert(System.IntPtr obj, System.IntPtr pd,   System.String kw_string,   int position)
   {
      Eina.Log.Debug("function efl_access_editable_text_insert was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      bool _ret_var = default(bool);
         try {
            _ret_var = ((Text)wrapper).Insert( kw_string,  position);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_access_editable_text_insert(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  kw_string,  position);
      }
   }
   private efl_access_editable_text_insert_delegate efl_access_editable_text_insert_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_access_editable_text_copy_delegate(System.IntPtr obj, System.IntPtr pd,    int start,    int end);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_access_editable_text_copy(System.IntPtr obj,    int start,    int end);
    private static bool copy(System.IntPtr obj, System.IntPtr pd,   int start,   int end)
   {
      Eina.Log.Debug("function efl_access_editable_text_copy was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      bool _ret_var = default(bool);
         try {
            _ret_var = ((Text)wrapper).Copy( start,  end);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_access_editable_text_copy(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  start,  end);
      }
   }
   private efl_access_editable_text_copy_delegate efl_access_editable_text_copy_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_access_editable_text_cut_delegate(System.IntPtr obj, System.IntPtr pd,    int start,    int end);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_access_editable_text_cut(System.IntPtr obj,    int start,    int end);
    private static bool cut(System.IntPtr obj, System.IntPtr pd,   int start,   int end)
   {
      Eina.Log.Debug("function efl_access_editable_text_cut was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      bool _ret_var = default(bool);
         try {
            _ret_var = ((Text)wrapper).Cut( start,  end);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_access_editable_text_cut(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  start,  end);
      }
   }
   private efl_access_editable_text_cut_delegate efl_access_editable_text_cut_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_access_editable_text_delete_delegate(System.IntPtr obj, System.IntPtr pd,    int start,    int end);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_access_editable_text_delete(System.IntPtr obj,    int start,    int end);
    private static bool kw_delete(System.IntPtr obj, System.IntPtr pd,   int start,   int end)
   {
      Eina.Log.Debug("function efl_access_editable_text_delete was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      bool _ret_var = default(bool);
         try {
            _ret_var = ((Text)wrapper).Delete( start,  end);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_access_editable_text_delete(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  start,  end);
      }
   }
   private efl_access_editable_text_delete_delegate efl_access_editable_text_delete_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_access_editable_text_paste_delegate(System.IntPtr obj, System.IntPtr pd,    int position);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_access_editable_text_paste(System.IntPtr obj,    int position);
    private static bool paste(System.IntPtr obj, System.IntPtr pd,   int position)
   {
      Eina.Log.Debug("function efl_access_editable_text_paste was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((Text)wrapper).Paste( position);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_access_editable_text_paste(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  position);
      }
   }
   private efl_access_editable_text_paste_delegate efl_access_editable_text_paste_static_delegate;
}
} } } 
