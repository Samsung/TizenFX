#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { 
/// <summary>Cursor API
/// 1.20</summary>
[TextAnnotateConcreteNativeInherit]
public interface TextAnnotate : 
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>A new format for <c>annotation</c>.
/// This will replace the format applied by <c>annotation</c> with <c>format</c>. Assumes that <c>annotation</c> is a handle for an existing annotation, i.e. one that was added using <see cref="Efl.TextAnnotate.AnnotationInsert"/> to this object. Otherwise, this will fail and return <c>false</c>.
/// 1.18</summary>
/// <param name="annotation">Given annotation
/// 1.20</param>
/// <returns>The new format for the given annotation
/// 1.20</returns>
 System.String GetAnnotation( Efl.TextAnnotateAnnotation annotation);
   /// <summary>A new format for <c>annotation</c>.
/// This will replace the format applied by <c>annotation</c> with <c>format</c>. Assumes that <c>annotation</c> is a handle for an existing annotation, i.e. one that was added using <see cref="Efl.TextAnnotate.AnnotationInsert"/> to this object. Otherwise, this will fail and return <c>false</c>.
/// 1.18</summary>
/// <param name="annotation">Given annotation
/// 1.20</param>
/// <param name="format">The new format for the given annotation
/// 1.20</param>
/// <returns><c>true</c> on success, <c>false</c> otherwise.
/// 1.20</returns>
bool SetAnnotation( Efl.TextAnnotateAnnotation annotation,   System.String format);
   /// <summary>The object-item annotation at the cursor&apos;s position.
/// 1.20</summary>
/// <param name="cur">Cursor object
/// 1.20</param>
/// <returns>Annotation
/// 1.20</returns>
Efl.TextAnnotateAnnotation GetCursorItemAnnotation( Efl.TextCursorCursor cur);
   /// <summary>Returns an iterator of all the handles in a range.
/// 1.18</summary>
/// <param name="start">Start of range
/// 1.20</param>
/// <param name="end">End of range
/// 1.20</param>
/// <returns>Handle of the Annotation
/// 1.20</returns>
Eina.Iterator<Efl.TextAnnotateAnnotation> GetRangeAnnotations( Efl.TextCursorCursor start,  Efl.TextCursorCursor end);
   /// <summary>Inserts an annotation format in a specified range [<c>start</c>, <c>end</c> - 1].
/// The <c>format</c> will be applied to the given range, and the <c>annotation</c> handle will be returned for further handling.
/// 1.18</summary>
/// <param name="start">Start of range
/// 1.20</param>
/// <param name="end">End of range
/// 1.20</param>
/// <param name="format">Annotation format
/// 1.20</param>
/// <returns>Handle of inserted annotation
/// 1.20</returns>
Efl.TextAnnotateAnnotation AnnotationInsert( Efl.TextCursorCursor start,  Efl.TextCursorCursor end,   System.String format);
   /// <summary>Deletes given annotation.
/// All formats applied by <c>annotation</c> will be removed and it will be deleted.
/// 1.18</summary>
/// <param name="annotation">Annotation to be removed
/// 1.20</param>
/// <returns><c>true</c> on success, <c>false</c> otherwise.
/// 1.20</returns>
bool DelAnnotation( Efl.TextAnnotateAnnotation annotation);
   /// <summary>Sets given cursors to the start and end positions of the annotation.
/// The cursors <c>start</c> and <c>end</c> will be set to the start and end positions of the given annotation <c>annotation</c>.
/// 1.18</summary>
/// <param name="annotation">Annotation handle to query
/// 1.20</param>
/// <param name="start">Cursor to be set to the start position of the annotation in the text
/// 1.20</param>
/// <param name="end">Cursor to be set to the end position of the annotation in the text
/// 1.20</param>
/// <returns></returns>
 void GetAnnotationPositions( Efl.TextAnnotateAnnotation annotation,  Efl.TextCursorCursor start,  Efl.TextCursorCursor end);
   /// <summary>Whether this is an &quot;item&quot; type of annotation. Should be used before querying the annotation&apos;s geometry, as only &quot;item&quot; annotations have a geometry.
/// see <see cref="Efl.TextAnnotate.CursorItemInsert"/> see <see cref="Efl.TextAnnotate.GetItemGeometry"/>
/// 1.21</summary>
/// <param name="annotation">Given annotation
/// 1.20</param>
/// <returns><c>true</c> if given annotation is an object item, <c>false</c> otherwise
/// 1.20</returns>
bool AnnotationIsItem( Efl.TextAnnotateAnnotation annotation);
   /// <summary>Queries a given object item for its geometry.
/// Note that the provided annotation should be an object item type.
/// 1.18</summary>
/// <param name="an">Given annotation to query
/// 1.20</param>
/// <param name="x">X coordinate of the annotation
/// 1.20</param>
/// <param name="y">Y coordinate of the annotation
/// 1.20</param>
/// <param name="w">Width of the annotation
/// 1.20</param>
/// <param name="h">Height of the annotation
/// 1.20</param>
/// <returns><c>true</c> if given annotation is an object item, <c>false</c> otherwise
/// 1.20</returns>
bool GetItemGeometry( Efl.TextAnnotateAnnotation an,  out  int x,  out  int y,  out  int w,  out  int h);
   /// <summary>Inserts a object item at specified position.
/// This adds a placeholder to be queried by higher-level code, which in turn place graphics on top of it. It essentially places an OBJECT REPLACEMENT CHARACTER and set a special annotation to it.
/// 1.20</summary>
/// <param name="cur">Cursor object
/// 1.20</param>
/// <param name="item">Item key to be used in higher-up code to query and decided what image, emoticon etc. to embed.
/// 1.20</param>
/// <param name="format">Size format of the inserted item. This hints how to size the item in the text.
/// 1.20</param>
/// <returns>The annotation handle of the inserted item.
/// 1.20</returns>
Efl.TextAnnotateAnnotation CursorItemInsert( Efl.TextCursorCursor cur,   System.String item,   System.String format);
                              }
/// <summary>Cursor API
/// 1.20</summary>
sealed public class TextAnnotateConcrete : 

TextAnnotate
   
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (TextAnnotateConcrete))
            return Efl.TextAnnotateConcreteNativeInherit.GetEflClassStatic();
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
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] internal static extern System.IntPtr
      efl_text_annotate_interface_get();
   ///<summary>Constructs an instance from a native pointer.</summary>
   public TextAnnotateConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~TextAnnotateConcrete()
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
   public static TextAnnotateConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new TextAnnotateConcrete(obj.NativeHandle);
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


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private static extern  System.String efl_text_annotation_get(System.IntPtr obj,   Efl.TextAnnotateAnnotation annotation);
   /// <summary>A new format for <c>annotation</c>.
   /// This will replace the format applied by <c>annotation</c> with <c>format</c>. Assumes that <c>annotation</c> is a handle for an existing annotation, i.e. one that was added using <see cref="Efl.TextAnnotate.AnnotationInsert"/> to this object. Otherwise, this will fail and return <c>false</c>.
   /// 1.18</summary>
   /// <param name="annotation">Given annotation
   /// 1.20</param>
   /// <returns>The new format for the given annotation
   /// 1.20</returns>
   public  System.String GetAnnotation( Efl.TextAnnotateAnnotation annotation) {
                         var _ret_var = efl_text_annotation_get(Efl.TextAnnotateConcrete.efl_text_annotate_interface_get(),  annotation);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_text_annotation_set(System.IntPtr obj,   Efl.TextAnnotateAnnotation annotation,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String format);
   /// <summary>A new format for <c>annotation</c>.
   /// This will replace the format applied by <c>annotation</c> with <c>format</c>. Assumes that <c>annotation</c> is a handle for an existing annotation, i.e. one that was added using <see cref="Efl.TextAnnotate.AnnotationInsert"/> to this object. Otherwise, this will fail and return <c>false</c>.
   /// 1.18</summary>
   /// <param name="annotation">Given annotation
   /// 1.20</param>
   /// <param name="format">The new format for the given annotation
   /// 1.20</param>
   /// <returns><c>true</c> on success, <c>false</c> otherwise.
   /// 1.20</returns>
   public bool SetAnnotation( Efl.TextAnnotateAnnotation annotation,   System.String format) {
                                           var _ret_var = efl_text_annotation_set(Efl.TextAnnotateConcrete.efl_text_annotate_interface_get(),  annotation,  format);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern Efl.TextAnnotateAnnotation efl_text_cursor_item_annotation_get(System.IntPtr obj,   Efl.TextCursorCursor cur);
   /// <summary>The object-item annotation at the cursor&apos;s position.
   /// 1.20</summary>
   /// <param name="cur">Cursor object
   /// 1.20</param>
   /// <returns>Annotation
   /// 1.20</returns>
   public Efl.TextAnnotateAnnotation GetCursorItemAnnotation( Efl.TextCursorCursor cur) {
                         var _ret_var = efl_text_cursor_item_annotation_get(Efl.TextAnnotateConcrete.efl_text_annotate_interface_get(),  cur);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  System.IntPtr efl_text_range_annotations_get(System.IntPtr obj,   Efl.TextCursorCursor start,   Efl.TextCursorCursor end);
   /// <summary>Returns an iterator of all the handles in a range.
   /// 1.18</summary>
   /// <param name="start">Start of range
   /// 1.20</param>
   /// <param name="end">End of range
   /// 1.20</param>
   /// <returns>Handle of the Annotation
   /// 1.20</returns>
   public Eina.Iterator<Efl.TextAnnotateAnnotation> GetRangeAnnotations( Efl.TextCursorCursor start,  Efl.TextCursorCursor end) {
                                           var _ret_var = efl_text_range_annotations_get(Efl.TextAnnotateConcrete.efl_text_annotate_interface_get(),  start,  end);
      Eina.Error.RaiseIfUnhandledException();
                              return new Eina.Iterator<Efl.TextAnnotateAnnotation>(_ret_var, true, false);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern Efl.TextAnnotateAnnotation efl_text_annotation_insert(System.IntPtr obj,   Efl.TextCursorCursor start,   Efl.TextCursorCursor end,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String format);
   /// <summary>Inserts an annotation format in a specified range [<c>start</c>, <c>end</c> - 1].
   /// The <c>format</c> will be applied to the given range, and the <c>annotation</c> handle will be returned for further handling.
   /// 1.18</summary>
   /// <param name="start">Start of range
   /// 1.20</param>
   /// <param name="end">End of range
   /// 1.20</param>
   /// <param name="format">Annotation format
   /// 1.20</param>
   /// <returns>Handle of inserted annotation
   /// 1.20</returns>
   public Efl.TextAnnotateAnnotation AnnotationInsert( Efl.TextCursorCursor start,  Efl.TextCursorCursor end,   System.String format) {
                                                             var _ret_var = efl_text_annotation_insert(Efl.TextAnnotateConcrete.efl_text_annotate_interface_get(),  start,  end,  format);
      Eina.Error.RaiseIfUnhandledException();
                                          return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_text_annotation_del(System.IntPtr obj,   Efl.TextAnnotateAnnotation annotation);
   /// <summary>Deletes given annotation.
   /// All formats applied by <c>annotation</c> will be removed and it will be deleted.
   /// 1.18</summary>
   /// <param name="annotation">Annotation to be removed
   /// 1.20</param>
   /// <returns><c>true</c> on success, <c>false</c> otherwise.
   /// 1.20</returns>
   public bool DelAnnotation( Efl.TextAnnotateAnnotation annotation) {
                         var _ret_var = efl_text_annotation_del(Efl.TextAnnotateConcrete.efl_text_annotate_interface_get(),  annotation);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_text_annotation_positions_get(System.IntPtr obj,   Efl.TextAnnotateAnnotation annotation,   Efl.TextCursorCursor start,   Efl.TextCursorCursor end);
   /// <summary>Sets given cursors to the start and end positions of the annotation.
   /// The cursors <c>start</c> and <c>end</c> will be set to the start and end positions of the given annotation <c>annotation</c>.
   /// 1.18</summary>
   /// <param name="annotation">Annotation handle to query
   /// 1.20</param>
   /// <param name="start">Cursor to be set to the start position of the annotation in the text
   /// 1.20</param>
   /// <param name="end">Cursor to be set to the end position of the annotation in the text
   /// 1.20</param>
   /// <returns></returns>
   public  void GetAnnotationPositions( Efl.TextAnnotateAnnotation annotation,  Efl.TextCursorCursor start,  Efl.TextCursorCursor end) {
                                                             efl_text_annotation_positions_get(Efl.TextAnnotateConcrete.efl_text_annotate_interface_get(),  annotation,  start,  end);
      Eina.Error.RaiseIfUnhandledException();
                                           }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_text_annotation_is_item(System.IntPtr obj,   Efl.TextAnnotateAnnotation annotation);
   /// <summary>Whether this is an &quot;item&quot; type of annotation. Should be used before querying the annotation&apos;s geometry, as only &quot;item&quot; annotations have a geometry.
   /// see <see cref="Efl.TextAnnotate.CursorItemInsert"/> see <see cref="Efl.TextAnnotate.GetItemGeometry"/>
   /// 1.21</summary>
   /// <param name="annotation">Given annotation
   /// 1.20</param>
   /// <returns><c>true</c> if given annotation is an object item, <c>false</c> otherwise
   /// 1.20</returns>
   public bool AnnotationIsItem( Efl.TextAnnotateAnnotation annotation) {
                         var _ret_var = efl_text_annotation_is_item(Efl.TextAnnotateConcrete.efl_text_annotate_interface_get(),  annotation);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_text_item_geometry_get(System.IntPtr obj,   Efl.TextAnnotateAnnotation an,   out  int x,   out  int y,   out  int w,   out  int h);
   /// <summary>Queries a given object item for its geometry.
   /// Note that the provided annotation should be an object item type.
   /// 1.18</summary>
   /// <param name="an">Given annotation to query
   /// 1.20</param>
   /// <param name="x">X coordinate of the annotation
   /// 1.20</param>
   /// <param name="y">Y coordinate of the annotation
   /// 1.20</param>
   /// <param name="w">Width of the annotation
   /// 1.20</param>
   /// <param name="h">Height of the annotation
   /// 1.20</param>
   /// <returns><c>true</c> if given annotation is an object item, <c>false</c> otherwise
   /// 1.20</returns>
   public bool GetItemGeometry( Efl.TextAnnotateAnnotation an,  out  int x,  out  int y,  out  int w,  out  int h) {
                                                                                                 var _ret_var = efl_text_item_geometry_get(Efl.TextAnnotateConcrete.efl_text_annotate_interface_get(),  an,  out x,  out y,  out w,  out h);
      Eina.Error.RaiseIfUnhandledException();
                                                                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern Efl.TextAnnotateAnnotation efl_text_cursor_item_insert(System.IntPtr obj,   Efl.TextCursorCursor cur,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String item,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String format);
   /// <summary>Inserts a object item at specified position.
   /// This adds a placeholder to be queried by higher-level code, which in turn place graphics on top of it. It essentially places an OBJECT REPLACEMENT CHARACTER and set a special annotation to it.
   /// 1.20</summary>
   /// <param name="cur">Cursor object
   /// 1.20</param>
   /// <param name="item">Item key to be used in higher-up code to query and decided what image, emoticon etc. to embed.
   /// 1.20</param>
   /// <param name="format">Size format of the inserted item. This hints how to size the item in the text.
   /// 1.20</param>
   /// <returns>The annotation handle of the inserted item.
   /// 1.20</returns>
   public Efl.TextAnnotateAnnotation CursorItemInsert( Efl.TextCursorCursor cur,   System.String item,   System.String format) {
                                                             var _ret_var = efl_text_cursor_item_insert(Efl.TextAnnotateConcrete.efl_text_annotate_interface_get(),  cur,  item,  format);
      Eina.Error.RaiseIfUnhandledException();
                                          return _ret_var;
 }
}
public class TextAnnotateConcreteNativeInherit : Efl.Eo.NativeClass{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_text_annotation_get_static_delegate = new efl_text_annotation_get_delegate(annotation_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_annotation_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_annotation_get_static_delegate)});
      efl_text_annotation_set_static_delegate = new efl_text_annotation_set_delegate(annotation_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_annotation_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_annotation_set_static_delegate)});
      efl_text_cursor_item_annotation_get_static_delegate = new efl_text_cursor_item_annotation_get_delegate(cursor_item_annotation_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_cursor_item_annotation_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_item_annotation_get_static_delegate)});
      efl_text_range_annotations_get_static_delegate = new efl_text_range_annotations_get_delegate(range_annotations_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_range_annotations_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_range_annotations_get_static_delegate)});
      efl_text_annotation_insert_static_delegate = new efl_text_annotation_insert_delegate(annotation_insert);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_annotation_insert"), func = Marshal.GetFunctionPointerForDelegate(efl_text_annotation_insert_static_delegate)});
      efl_text_annotation_del_static_delegate = new efl_text_annotation_del_delegate(annotation_del);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_annotation_del"), func = Marshal.GetFunctionPointerForDelegate(efl_text_annotation_del_static_delegate)});
      efl_text_annotation_positions_get_static_delegate = new efl_text_annotation_positions_get_delegate(annotation_positions_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_annotation_positions_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_annotation_positions_get_static_delegate)});
      efl_text_annotation_is_item_static_delegate = new efl_text_annotation_is_item_delegate(annotation_is_item);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_annotation_is_item"), func = Marshal.GetFunctionPointerForDelegate(efl_text_annotation_is_item_static_delegate)});
      efl_text_item_geometry_get_static_delegate = new efl_text_item_geometry_get_delegate(item_geometry_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_item_geometry_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_item_geometry_get_static_delegate)});
      efl_text_cursor_item_insert_static_delegate = new efl_text_cursor_item_insert_delegate(cursor_item_insert);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_cursor_item_insert"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_item_insert_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.TextAnnotateConcrete.efl_text_annotate_interface_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.TextAnnotateConcrete.efl_text_annotate_interface_get();
   }


    private delegate  System.IntPtr efl_text_annotation_get_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextAnnotateAnnotation annotation);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  System.IntPtr efl_text_annotation_get(System.IntPtr obj,   Efl.TextAnnotateAnnotation annotation);
    private static  System.IntPtr annotation_get(System.IntPtr obj, System.IntPtr pd,  Efl.TextAnnotateAnnotation annotation)
   {
      Eina.Log.Debug("function efl_text_annotation_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                     System.String _ret_var = default( System.String);
         try {
            _ret_var = ((TextAnnotate)wrapper).GetAnnotation( annotation);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return Efl.Eo.Globals.cached_string_to_intptr(((TextAnnotateConcrete)wrapper).cached_strings, _ret_var);
      } else {
         return efl_text_annotation_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  annotation);
      }
   }
   private efl_text_annotation_get_delegate efl_text_annotation_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_text_annotation_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextAnnotateAnnotation annotation,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String format);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_text_annotation_set(System.IntPtr obj,   Efl.TextAnnotateAnnotation annotation,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String format);
    private static bool annotation_set(System.IntPtr obj, System.IntPtr pd,  Efl.TextAnnotateAnnotation annotation,   System.String format)
   {
      Eina.Log.Debug("function efl_text_annotation_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      bool _ret_var = default(bool);
         try {
            _ret_var = ((TextAnnotate)wrapper).SetAnnotation( annotation,  format);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_text_annotation_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  annotation,  format);
      }
   }
   private efl_text_annotation_set_delegate efl_text_annotation_set_static_delegate;


    private delegate Efl.TextAnnotateAnnotation efl_text_cursor_item_annotation_get_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Efl.TextAnnotateAnnotation efl_text_cursor_item_annotation_get(System.IntPtr obj,   Efl.TextCursorCursor cur);
    private static Efl.TextAnnotateAnnotation cursor_item_annotation_get(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur)
   {
      Eina.Log.Debug("function efl_text_cursor_item_annotation_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    Efl.TextAnnotateAnnotation _ret_var = default(Efl.TextAnnotateAnnotation);
         try {
            _ret_var = ((TextAnnotate)wrapper).GetCursorItemAnnotation( cur);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_text_cursor_item_annotation_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur);
      }
   }
   private efl_text_cursor_item_annotation_get_delegate efl_text_cursor_item_annotation_get_static_delegate;


    private delegate  System.IntPtr efl_text_range_annotations_get_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor start,   Efl.TextCursorCursor end);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  System.IntPtr efl_text_range_annotations_get(System.IntPtr obj,   Efl.TextCursorCursor start,   Efl.TextCursorCursor end);
    private static  System.IntPtr range_annotations_get(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor start,  Efl.TextCursorCursor end)
   {
      Eina.Log.Debug("function efl_text_range_annotations_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      Eina.Iterator<Efl.TextAnnotateAnnotation> _ret_var = default(Eina.Iterator<Efl.TextAnnotateAnnotation>);
         try {
            _ret_var = ((TextAnnotate)wrapper).GetRangeAnnotations( start,  end);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              _ret_var.Own = false; return _ret_var.Handle;
      } else {
         return efl_text_range_annotations_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  start,  end);
      }
   }
   private efl_text_range_annotations_get_delegate efl_text_range_annotations_get_static_delegate;


    private delegate Efl.TextAnnotateAnnotation efl_text_annotation_insert_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor start,   Efl.TextCursorCursor end,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String format);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Efl.TextAnnotateAnnotation efl_text_annotation_insert(System.IntPtr obj,   Efl.TextCursorCursor start,   Efl.TextCursorCursor end,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String format);
    private static Efl.TextAnnotateAnnotation annotation_insert(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor start,  Efl.TextCursorCursor end,   System.String format)
   {
      Eina.Log.Debug("function efl_text_annotation_insert was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                        Efl.TextAnnotateAnnotation _ret_var = default(Efl.TextAnnotateAnnotation);
         try {
            _ret_var = ((TextAnnotate)wrapper).AnnotationInsert( start,  end,  format);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                          return _ret_var;
      } else {
         return efl_text_annotation_insert(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  start,  end,  format);
      }
   }
   private efl_text_annotation_insert_delegate efl_text_annotation_insert_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_text_annotation_del_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextAnnotateAnnotation annotation);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_text_annotation_del(System.IntPtr obj,   Efl.TextAnnotateAnnotation annotation);
    private static bool annotation_del(System.IntPtr obj, System.IntPtr pd,  Efl.TextAnnotateAnnotation annotation)
   {
      Eina.Log.Debug("function efl_text_annotation_del was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((TextAnnotate)wrapper).DelAnnotation( annotation);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_text_annotation_del(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  annotation);
      }
   }
   private efl_text_annotation_del_delegate efl_text_annotation_del_static_delegate;


    private delegate  void efl_text_annotation_positions_get_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextAnnotateAnnotation annotation,   Efl.TextCursorCursor start,   Efl.TextCursorCursor end);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_annotation_positions_get(System.IntPtr obj,   Efl.TextAnnotateAnnotation annotation,   Efl.TextCursorCursor start,   Efl.TextCursorCursor end);
    private static  void annotation_positions_get(System.IntPtr obj, System.IntPtr pd,  Efl.TextAnnotateAnnotation annotation,  Efl.TextCursorCursor start,  Efl.TextCursorCursor end)
   {
      Eina.Log.Debug("function efl_text_annotation_positions_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                        
         try {
            ((TextAnnotate)wrapper).GetAnnotationPositions( annotation,  start,  end);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                } else {
         efl_text_annotation_positions_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  annotation,  start,  end);
      }
   }
   private efl_text_annotation_positions_get_delegate efl_text_annotation_positions_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_text_annotation_is_item_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextAnnotateAnnotation annotation);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_text_annotation_is_item(System.IntPtr obj,   Efl.TextAnnotateAnnotation annotation);
    private static bool annotation_is_item(System.IntPtr obj, System.IntPtr pd,  Efl.TextAnnotateAnnotation annotation)
   {
      Eina.Log.Debug("function efl_text_annotation_is_item was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((TextAnnotate)wrapper).AnnotationIsItem( annotation);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_text_annotation_is_item(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  annotation);
      }
   }
   private efl_text_annotation_is_item_delegate efl_text_annotation_is_item_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_text_item_geometry_get_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextAnnotateAnnotation an,   out  int x,   out  int y,   out  int w,   out  int h);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_text_item_geometry_get(System.IntPtr obj,   Efl.TextAnnotateAnnotation an,   out  int x,   out  int y,   out  int w,   out  int h);
    private static bool item_geometry_get(System.IntPtr obj, System.IntPtr pd,  Efl.TextAnnotateAnnotation an,  out  int x,  out  int y,  out  int w,  out  int h)
   {
      Eina.Log.Debug("function efl_text_item_geometry_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                   x = default( int);      y = default( int);      w = default( int);      h = default( int);                                       bool _ret_var = default(bool);
         try {
            _ret_var = ((TextAnnotate)wrapper).GetItemGeometry( an,  out x,  out y,  out w,  out h);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                  return _ret_var;
      } else {
         return efl_text_item_geometry_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  an,  out x,  out y,  out w,  out h);
      }
   }
   private efl_text_item_geometry_get_delegate efl_text_item_geometry_get_static_delegate;


    private delegate Efl.TextAnnotateAnnotation efl_text_cursor_item_insert_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String item,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String format);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Efl.TextAnnotateAnnotation efl_text_cursor_item_insert(System.IntPtr obj,   Efl.TextCursorCursor cur,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String item,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String format);
    private static Efl.TextAnnotateAnnotation cursor_item_insert(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur,   System.String item,   System.String format)
   {
      Eina.Log.Debug("function efl_text_cursor_item_insert was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                        Efl.TextAnnotateAnnotation _ret_var = default(Efl.TextAnnotateAnnotation);
         try {
            _ret_var = ((TextAnnotate)wrapper).CursorItemInsert( cur,  item,  format);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                          return _ret_var;
      } else {
         return efl_text_cursor_item_insert(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur,  item,  format);
      }
   }
   private efl_text_cursor_item_insert_delegate efl_text_cursor_item_insert_static_delegate;
}
} 
