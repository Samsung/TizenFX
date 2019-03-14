#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { 
/// <summary>Markup data that populates the text object&apos;s style and format
/// 1.22</summary>
[TextMarkupInteractiveNativeInherit]
public interface TextMarkupInteractive : 
   Efl.TextCursor ,
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>Markup of a given range in the text
/// 1.22</summary>
/// <param name="start"></param>
/// <param name="end"></param>
/// <returns>The markup-text representation set to this text of a given range
/// 1.22</returns>
 System.String GetMarkupRange( Efl.TextCursorCursor start,  Efl.TextCursorCursor end);
   /// <summary>Markup of a given range in the text
/// 1.22</summary>
/// <param name="start"></param>
/// <param name="end"></param>
/// <param name="markup">The markup-text representation set to this text of a given range
/// 1.22</param>
/// <returns></returns>
 void SetMarkupRange( Efl.TextCursorCursor start,  Efl.TextCursorCursor end,   System.String markup);
   /// <summary>Inserts a markup text to the text object in a given cursor position
/// 1.22</summary>
/// <param name="cur">Cursor position to insert markup
/// 1.22</param>
/// <param name="markup">The markup text to insert
/// 1.22</param>
/// <returns></returns>
 void CursorMarkupInsert( Efl.TextCursorCursor cur,   System.String markup);
         }
/// <summary>Markup data that populates the text object&apos;s style and format
/// 1.22</summary>
sealed public class TextMarkupInteractiveConcrete : 

TextMarkupInteractive
   , Efl.TextCursor
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (TextMarkupInteractiveConcrete))
            return Efl.TextMarkupInteractiveNativeInherit.GetEflClassStatic();
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
      efl_text_markup_interactive_interface_get();
   ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
   public TextMarkupInteractiveConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~TextMarkupInteractiveConcrete()
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
   public static TextMarkupInteractiveConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new TextMarkupInteractiveConcrete(obj.NativeHandle);
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
   /// <summary>Markup of a given range in the text
   /// 1.22</summary>
   /// <param name="start"></param>
   /// <param name="end"></param>
   /// <returns>The markup-text representation set to this text of a given range
   /// 1.22</returns>
   public  System.String GetMarkupRange( Efl.TextCursorCursor start,  Efl.TextCursorCursor end) {
                                           var _ret_var = Efl.TextMarkupInteractiveNativeInherit.efl_text_markup_interactive_markup_range_get_ptr.Value.Delegate(this.NativeHandle, start,  end);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }
   /// <summary>Markup of a given range in the text
   /// 1.22</summary>
   /// <param name="start"></param>
   /// <param name="end"></param>
   /// <param name="markup">The markup-text representation set to this text of a given range
   /// 1.22</param>
   /// <returns></returns>
   public  void SetMarkupRange( Efl.TextCursorCursor start,  Efl.TextCursorCursor end,   System.String markup) {
                                                             Efl.TextMarkupInteractiveNativeInherit.efl_text_markup_interactive_markup_range_set_ptr.Value.Delegate(this.NativeHandle, start,  end,  markup);
      Eina.Error.RaiseIfUnhandledException();
                                           }
   /// <summary>Inserts a markup text to the text object in a given cursor position
   /// 1.22</summary>
   /// <param name="cur">Cursor position to insert markup
   /// 1.22</param>
   /// <param name="markup">The markup text to insert
   /// 1.22</param>
   /// <returns></returns>
   public  void CursorMarkupInsert( Efl.TextCursorCursor cur,   System.String markup) {
                                           Efl.TextMarkupInteractiveNativeInherit.efl_text_markup_interactive_cursor_markup_insert_ptr.Value.Delegate(this.NativeHandle, cur,  markup);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>The object&apos;s main cursor.
   /// 1.18</summary>
   /// <param name="get_type">Cursor type
   /// 1.20</param>
   /// <returns>Text cursor object
   /// 1.20</returns>
   public Efl.TextCursorCursor GetTextCursor( Efl.TextCursorGetType get_type) {
                         var _ret_var = Efl.TextCursorNativeInherit.efl_text_cursor_get_ptr.Value.Delegate(this.NativeHandle, get_type);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Cursor position
   /// 1.20</summary>
   /// <param name="cur">Cursor object
   /// 1.20</param>
   /// <returns>Cursor position
   /// 1.20</returns>
   public  int GetCursorPosition( Efl.TextCursorCursor cur) {
                         var _ret_var = Efl.TextCursorNativeInherit.efl_text_cursor_position_get_ptr.Value.Delegate(this.NativeHandle, cur);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Cursor position
   /// 1.20</summary>
   /// <param name="cur">Cursor object
   /// 1.20</param>
   /// <param name="position">Cursor position
   /// 1.20</param>
   /// <returns></returns>
   public  void SetCursorPosition( Efl.TextCursorCursor cur,   int position) {
                                           Efl.TextCursorNativeInherit.efl_text_cursor_position_set_ptr.Value.Delegate(this.NativeHandle, cur,  position);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>The content of the cursor (the character under the cursor)
   /// 1.20</summary>
   /// <param name="cur">Cursor object
   /// 1.20</param>
   /// <returns>The unicode codepoint of the character
   /// 1.20</returns>
   public Eina.Unicode GetCursorContent( Efl.TextCursorCursor cur) {
                         var _ret_var = Efl.TextCursorNativeInherit.efl_text_cursor_content_get_ptr.Value.Delegate(this.NativeHandle, cur);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Returns the geometry of two cursors (&quot;split cursor&quot;), if logical cursor is between LTR/RTL text, also considering paragraph direction. Upper cursor is shown for the text of the same direction as paragraph, lower cursor - for opposite.
   /// Split cursor geometry is valid only  in &apos;|&apos; cursor mode. In this case <c>true</c> is returned and <c>cx2</c>, <c>cy2</c>, <c>cw2</c>, <c>ch2</c> are set.
   /// 1.20</summary>
   /// <param name="cur">Cursor object
   /// 1.20</param>
   /// <param name="ctype">The type of the cursor.
   /// 1.20</param>
   /// <param name="cx">The x of the cursor (or upper cursor)
   /// 1.20</param>
   /// <param name="cy">The y of the cursor (or upper cursor)
   /// 1.20</param>
   /// <param name="cw">The width of the cursor (or upper cursor)
   /// 1.20</param>
   /// <param name="ch">The height of the cursor (or upper cursor)
   /// 1.20</param>
   /// <param name="cx2">The x of the lower cursor
   /// 1.20</param>
   /// <param name="cy2">The y of the lower cursor
   /// 1.20</param>
   /// <param name="cw2">The width of the lower cursor
   /// 1.20</param>
   /// <param name="ch2">The height of the lower cursor
   /// 1.20</param>
   /// <returns><c>true</c> if split cursor, <c>false</c> otherwise.
   /// 1.20</returns>
   public bool GetCursorGeometry( Efl.TextCursorCursor cur,  Efl.TextCursorType ctype,  out  int cx,  out  int cy,  out  int cw,  out  int ch,  out  int cx2,  out  int cy2,  out  int cw2,  out  int ch2) {
                                                                                                                                                                                           var _ret_var = Efl.TextCursorNativeInherit.efl_text_cursor_geometry_get_ptr.Value.Delegate(this.NativeHandle, cur,  ctype,  out cx,  out cy,  out cw,  out ch,  out cx2,  out cy2,  out cw2,  out ch2);
      Eina.Error.RaiseIfUnhandledException();
                                                                                                                              return _ret_var;
 }
   /// <summary>Create new cursor
   /// 1.20</summary>
   /// <returns>Cursor object
   /// 1.20</returns>
   public Efl.TextCursorCursor NewCursor() {
       var _ret_var = Efl.TextCursorNativeInherit.efl_text_cursor_new_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Free existing cursor
   /// 1.20</summary>
   /// <param name="cur">Cursor object
   /// 1.20</param>
   /// <returns></returns>
   public  void CursorFree( Efl.TextCursorCursor cur) {
                         Efl.TextCursorNativeInherit.efl_text_cursor_free_ptr.Value.Delegate(this.NativeHandle, cur);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Check if two cursors are equal
   /// 1.20</summary>
   /// <param name="cur1">Cursor 1 object
   /// 1.20</param>
   /// <param name="cur2">Cursor 2 object
   /// 1.20</param>
   /// <returns><c>true</c> if cursors are equal, <c>false</c> otherwise
   /// 1.20</returns>
   public bool CursorEqual( Efl.TextCursorCursor cur1,  Efl.TextCursorCursor cur2) {
                                           var _ret_var = Efl.TextCursorNativeInherit.efl_text_cursor_equal_ptr.Value.Delegate(this.NativeHandle, cur1,  cur2);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }
   /// <summary>Compare two cursors
   /// 1.20</summary>
   /// <param name="cur1">Cursor 1 object
   /// 1.20</param>
   /// <param name="cur2">Cursor 2 object
   /// 1.20</param>
   /// <returns>Difference between cursors
   /// 1.20</returns>
   public  int CursorCompare( Efl.TextCursorCursor cur1,  Efl.TextCursorCursor cur2) {
                                           var _ret_var = Efl.TextCursorNativeInherit.efl_text_cursor_compare_ptr.Value.Delegate(this.NativeHandle, cur1,  cur2);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }
   /// <summary>Copy existing cursor
   /// 1.20</summary>
   /// <param name="dst">Destination cursor
   /// 1.20</param>
   /// <param name="src">Source cursor
   /// 1.20</param>
   /// <returns></returns>
   public  void CursorCopy( Efl.TextCursorCursor dst,  Efl.TextCursorCursor src) {
                                           Efl.TextCursorNativeInherit.efl_text_cursor_copy_ptr.Value.Delegate(this.NativeHandle, dst,  src);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Advances to the next character
   /// 1.20</summary>
   /// <param name="cur">Cursor object
   /// 1.20</param>
   /// <returns></returns>
   public  void CursorCharNext( Efl.TextCursorCursor cur) {
                         Efl.TextCursorNativeInherit.efl_text_cursor_char_next_ptr.Value.Delegate(this.NativeHandle, cur);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Advances to the previous character
   /// 1.20</summary>
   /// <param name="cur">Cursor object
   /// 1.20</param>
   /// <returns></returns>
   public  void CursorCharPrev( Efl.TextCursorCursor cur) {
                         Efl.TextCursorNativeInherit.efl_text_cursor_char_prev_ptr.Value.Delegate(this.NativeHandle, cur);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Advances to the next grapheme cluster
   /// 1.20</summary>
   /// <param name="cur">Cursor object
   /// 1.20</param>
   /// <returns></returns>
   public  void CursorClusterNext( Efl.TextCursorCursor cur) {
                         Efl.TextCursorNativeInherit.efl_text_cursor_cluster_next_ptr.Value.Delegate(this.NativeHandle, cur);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Advances to the previous grapheme cluster
   /// 1.20</summary>
   /// <param name="cur">Cursor object
   /// 1.20</param>
   /// <returns></returns>
   public  void CursorClusterPrev( Efl.TextCursorCursor cur) {
                         Efl.TextCursorNativeInherit.efl_text_cursor_cluster_prev_ptr.Value.Delegate(this.NativeHandle, cur);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Advances to the first character in this paragraph
   /// 1.20</summary>
   /// <param name="cur">Cursor object
   /// 1.20</param>
   /// <returns></returns>
   public  void CursorParagraphCharFirst( Efl.TextCursorCursor cur) {
                         Efl.TextCursorNativeInherit.efl_text_cursor_paragraph_char_first_ptr.Value.Delegate(this.NativeHandle, cur);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Advances to the last character in this paragraph
   /// 1.20</summary>
   /// <param name="cur">Cursor object
   /// 1.20</param>
   /// <returns></returns>
   public  void CursorParagraphCharLast( Efl.TextCursorCursor cur) {
                         Efl.TextCursorNativeInherit.efl_text_cursor_paragraph_char_last_ptr.Value.Delegate(this.NativeHandle, cur);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Advance to current word start
   /// 1.20</summary>
   /// <param name="cur">Cursor object
   /// 1.20</param>
   /// <returns></returns>
   public  void CursorWordStart( Efl.TextCursorCursor cur) {
                         Efl.TextCursorNativeInherit.efl_text_cursor_word_start_ptr.Value.Delegate(this.NativeHandle, cur);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Advance to current word end
   /// 1.20</summary>
   /// <param name="cur">Cursor object
   /// 1.20</param>
   /// <returns></returns>
   public  void CursorWordEnd( Efl.TextCursorCursor cur) {
                         Efl.TextCursorNativeInherit.efl_text_cursor_word_end_ptr.Value.Delegate(this.NativeHandle, cur);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Advance to current line first character
   /// 1.20</summary>
   /// <param name="cur">Cursor object
   /// 1.20</param>
   /// <returns></returns>
   public  void CursorLineCharFirst( Efl.TextCursorCursor cur) {
                         Efl.TextCursorNativeInherit.efl_text_cursor_line_char_first_ptr.Value.Delegate(this.NativeHandle, cur);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Advance to current line last character
   /// 1.20</summary>
   /// <param name="cur">Cursor object
   /// 1.20</param>
   /// <returns></returns>
   public  void CursorLineCharLast( Efl.TextCursorCursor cur) {
                         Efl.TextCursorNativeInherit.efl_text_cursor_line_char_last_ptr.Value.Delegate(this.NativeHandle, cur);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Advance to current paragraph first character
   /// 1.20</summary>
   /// <param name="cur">Cursor object
   /// 1.20</param>
   /// <returns></returns>
   public  void CursorParagraphFirst( Efl.TextCursorCursor cur) {
                         Efl.TextCursorNativeInherit.efl_text_cursor_paragraph_first_ptr.Value.Delegate(this.NativeHandle, cur);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Advance to current paragraph last character
   /// 1.20</summary>
   /// <param name="cur">Cursor object
   /// 1.20</param>
   /// <returns></returns>
   public  void CursorParagraphLast( Efl.TextCursorCursor cur) {
                         Efl.TextCursorNativeInherit.efl_text_cursor_paragraph_last_ptr.Value.Delegate(this.NativeHandle, cur);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Advances to the start of the next text node
   /// 1.20</summary>
   /// <param name="cur">Cursor object
   /// 1.20</param>
   /// <returns></returns>
   public  void CursorParagraphNext( Efl.TextCursorCursor cur) {
                         Efl.TextCursorNativeInherit.efl_text_cursor_paragraph_next_ptr.Value.Delegate(this.NativeHandle, cur);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Advances to the end of the previous text node
   /// 1.20</summary>
   /// <param name="cur">Cursor object
   /// 1.20</param>
   /// <returns></returns>
   public  void CursorParagraphPrev( Efl.TextCursorCursor cur) {
                         Efl.TextCursorNativeInherit.efl_text_cursor_paragraph_prev_ptr.Value.Delegate(this.NativeHandle, cur);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Jump the cursor by the given number of lines
   /// 1.20</summary>
   /// <param name="cur">Cursor object
   /// 1.20</param>
   /// <param name="by">Number of lines
   /// 1.20</param>
   /// <returns></returns>
   public  void CursorLineJumpBy( Efl.TextCursorCursor cur,   int by) {
                                           Efl.TextCursorNativeInherit.efl_text_cursor_line_jump_by_ptr.Value.Delegate(this.NativeHandle, cur,  by);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Set cursor coordinates
   /// 1.20</summary>
   /// <param name="cur">Cursor object
   /// 1.20</param>
   /// <param name="x">X coord to set by.
   /// 1.20</param>
   /// <param name="y">Y coord to set by.
   /// 1.20</param>
   /// <returns></returns>
   public  void SetCursorCoord( Efl.TextCursorCursor cur,   int x,   int y) {
                                                             Efl.TextCursorNativeInherit.efl_text_cursor_coord_set_ptr.Value.Delegate(this.NativeHandle, cur,  x,  y);
      Eina.Error.RaiseIfUnhandledException();
                                           }
   /// <summary>Set cursor coordinates according to grapheme clusters. It does not allow to put a cursor to the middle of a grapheme cluster.
   /// 1.20</summary>
   /// <param name="cur">Cursor object
   /// 1.20</param>
   /// <param name="x">X coord to set by.
   /// 1.20</param>
   /// <param name="y">Y coord to set by.
   /// 1.20</param>
   /// <returns></returns>
   public  void SetCursorClusterCoord( Efl.TextCursorCursor cur,   int x,   int y) {
                                                             Efl.TextCursorNativeInherit.efl_text_cursor_cluster_coord_set_ptr.Value.Delegate(this.NativeHandle, cur,  x,  y);
      Eina.Error.RaiseIfUnhandledException();
                                           }
   /// <summary>Adds text to the current cursor position and set the cursor to *after* the start of the text just added.
   /// 1.20</summary>
   /// <param name="cur">Cursor object
   /// 1.20</param>
   /// <param name="text">Text to append (UTF-8 format).
   /// 1.20</param>
   /// <returns>Length of the appended text.
   /// 1.20</returns>
   public  int CursorTextInsert( Efl.TextCursorCursor cur,   System.String text) {
                                           var _ret_var = Efl.TextCursorNativeInherit.efl_text_cursor_text_insert_ptr.Value.Delegate(this.NativeHandle, cur,  text);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }
   /// <summary>Deletes a single character from position pointed by given cursor.
   /// 1.20</summary>
   /// <param name="cur">Cursor object
   /// 1.20</param>
   /// <returns></returns>
   public  void CursorCharDelete( Efl.TextCursorCursor cur) {
                         Efl.TextCursorNativeInherit.efl_text_cursor_char_delete_ptr.Value.Delegate(this.NativeHandle, cur);
      Eina.Error.RaiseIfUnhandledException();
                   }
}
public class TextMarkupInteractiveNativeInherit  : Efl.Eo.NativeClass{
   public  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Efl);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      if (efl_text_markup_interactive_markup_range_get_static_delegate == null)
      efl_text_markup_interactive_markup_range_get_static_delegate = new efl_text_markup_interactive_markup_range_get_delegate(markup_range_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_markup_interactive_markup_range_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_markup_interactive_markup_range_get_static_delegate)});
      if (efl_text_markup_interactive_markup_range_set_static_delegate == null)
      efl_text_markup_interactive_markup_range_set_static_delegate = new efl_text_markup_interactive_markup_range_set_delegate(markup_range_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_markup_interactive_markup_range_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_markup_interactive_markup_range_set_static_delegate)});
      if (efl_text_markup_interactive_cursor_markup_insert_static_delegate == null)
      efl_text_markup_interactive_cursor_markup_insert_static_delegate = new efl_text_markup_interactive_cursor_markup_insert_delegate(cursor_markup_insert);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_markup_interactive_cursor_markup_insert"), func = Marshal.GetFunctionPointerForDelegate(efl_text_markup_interactive_cursor_markup_insert_static_delegate)});
      if (efl_text_cursor_get_static_delegate == null)
      efl_text_cursor_get_static_delegate = new efl_text_cursor_get_delegate(text_cursor_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_cursor_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_get_static_delegate)});
      if (efl_text_cursor_position_get_static_delegate == null)
      efl_text_cursor_position_get_static_delegate = new efl_text_cursor_position_get_delegate(cursor_position_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_cursor_position_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_position_get_static_delegate)});
      if (efl_text_cursor_position_set_static_delegate == null)
      efl_text_cursor_position_set_static_delegate = new efl_text_cursor_position_set_delegate(cursor_position_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_cursor_position_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_position_set_static_delegate)});
      if (efl_text_cursor_content_get_static_delegate == null)
      efl_text_cursor_content_get_static_delegate = new efl_text_cursor_content_get_delegate(cursor_content_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_cursor_content_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_content_get_static_delegate)});
      if (efl_text_cursor_geometry_get_static_delegate == null)
      efl_text_cursor_geometry_get_static_delegate = new efl_text_cursor_geometry_get_delegate(cursor_geometry_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_cursor_geometry_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_geometry_get_static_delegate)});
      if (efl_text_cursor_new_static_delegate == null)
      efl_text_cursor_new_static_delegate = new efl_text_cursor_new_delegate(cursor_new);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_cursor_new"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_new_static_delegate)});
      if (efl_text_cursor_free_static_delegate == null)
      efl_text_cursor_free_static_delegate = new efl_text_cursor_free_delegate(cursor_free);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_cursor_free"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_free_static_delegate)});
      if (efl_text_cursor_equal_static_delegate == null)
      efl_text_cursor_equal_static_delegate = new efl_text_cursor_equal_delegate(cursor_equal);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_cursor_equal"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_equal_static_delegate)});
      if (efl_text_cursor_compare_static_delegate == null)
      efl_text_cursor_compare_static_delegate = new efl_text_cursor_compare_delegate(cursor_compare);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_cursor_compare"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_compare_static_delegate)});
      if (efl_text_cursor_copy_static_delegate == null)
      efl_text_cursor_copy_static_delegate = new efl_text_cursor_copy_delegate(cursor_copy);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_cursor_copy"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_copy_static_delegate)});
      if (efl_text_cursor_char_next_static_delegate == null)
      efl_text_cursor_char_next_static_delegate = new efl_text_cursor_char_next_delegate(cursor_char_next);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_cursor_char_next"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_char_next_static_delegate)});
      if (efl_text_cursor_char_prev_static_delegate == null)
      efl_text_cursor_char_prev_static_delegate = new efl_text_cursor_char_prev_delegate(cursor_char_prev);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_cursor_char_prev"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_char_prev_static_delegate)});
      if (efl_text_cursor_cluster_next_static_delegate == null)
      efl_text_cursor_cluster_next_static_delegate = new efl_text_cursor_cluster_next_delegate(cursor_cluster_next);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_cursor_cluster_next"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_cluster_next_static_delegate)});
      if (efl_text_cursor_cluster_prev_static_delegate == null)
      efl_text_cursor_cluster_prev_static_delegate = new efl_text_cursor_cluster_prev_delegate(cursor_cluster_prev);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_cursor_cluster_prev"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_cluster_prev_static_delegate)});
      if (efl_text_cursor_paragraph_char_first_static_delegate == null)
      efl_text_cursor_paragraph_char_first_static_delegate = new efl_text_cursor_paragraph_char_first_delegate(cursor_paragraph_char_first);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_cursor_paragraph_char_first"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_paragraph_char_first_static_delegate)});
      if (efl_text_cursor_paragraph_char_last_static_delegate == null)
      efl_text_cursor_paragraph_char_last_static_delegate = new efl_text_cursor_paragraph_char_last_delegate(cursor_paragraph_char_last);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_cursor_paragraph_char_last"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_paragraph_char_last_static_delegate)});
      if (efl_text_cursor_word_start_static_delegate == null)
      efl_text_cursor_word_start_static_delegate = new efl_text_cursor_word_start_delegate(cursor_word_start);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_cursor_word_start"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_word_start_static_delegate)});
      if (efl_text_cursor_word_end_static_delegate == null)
      efl_text_cursor_word_end_static_delegate = new efl_text_cursor_word_end_delegate(cursor_word_end);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_cursor_word_end"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_word_end_static_delegate)});
      if (efl_text_cursor_line_char_first_static_delegate == null)
      efl_text_cursor_line_char_first_static_delegate = new efl_text_cursor_line_char_first_delegate(cursor_line_char_first);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_cursor_line_char_first"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_line_char_first_static_delegate)});
      if (efl_text_cursor_line_char_last_static_delegate == null)
      efl_text_cursor_line_char_last_static_delegate = new efl_text_cursor_line_char_last_delegate(cursor_line_char_last);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_cursor_line_char_last"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_line_char_last_static_delegate)});
      if (efl_text_cursor_paragraph_first_static_delegate == null)
      efl_text_cursor_paragraph_first_static_delegate = new efl_text_cursor_paragraph_first_delegate(cursor_paragraph_first);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_cursor_paragraph_first"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_paragraph_first_static_delegate)});
      if (efl_text_cursor_paragraph_last_static_delegate == null)
      efl_text_cursor_paragraph_last_static_delegate = new efl_text_cursor_paragraph_last_delegate(cursor_paragraph_last);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_cursor_paragraph_last"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_paragraph_last_static_delegate)});
      if (efl_text_cursor_paragraph_next_static_delegate == null)
      efl_text_cursor_paragraph_next_static_delegate = new efl_text_cursor_paragraph_next_delegate(cursor_paragraph_next);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_cursor_paragraph_next"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_paragraph_next_static_delegate)});
      if (efl_text_cursor_paragraph_prev_static_delegate == null)
      efl_text_cursor_paragraph_prev_static_delegate = new efl_text_cursor_paragraph_prev_delegate(cursor_paragraph_prev);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_cursor_paragraph_prev"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_paragraph_prev_static_delegate)});
      if (efl_text_cursor_line_jump_by_static_delegate == null)
      efl_text_cursor_line_jump_by_static_delegate = new efl_text_cursor_line_jump_by_delegate(cursor_line_jump_by);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_cursor_line_jump_by"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_line_jump_by_static_delegate)});
      if (efl_text_cursor_coord_set_static_delegate == null)
      efl_text_cursor_coord_set_static_delegate = new efl_text_cursor_coord_set_delegate(cursor_coord_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_cursor_coord_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_coord_set_static_delegate)});
      if (efl_text_cursor_cluster_coord_set_static_delegate == null)
      efl_text_cursor_cluster_coord_set_static_delegate = new efl_text_cursor_cluster_coord_set_delegate(cursor_cluster_coord_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_cursor_cluster_coord_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_cluster_coord_set_static_delegate)});
      if (efl_text_cursor_text_insert_static_delegate == null)
      efl_text_cursor_text_insert_static_delegate = new efl_text_cursor_text_insert_delegate(cursor_text_insert);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_cursor_text_insert"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_text_insert_static_delegate)});
      if (efl_text_cursor_char_delete_static_delegate == null)
      efl_text_cursor_char_delete_static_delegate = new efl_text_cursor_char_delete_delegate(cursor_char_delete);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_cursor_char_delete"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_char_delete_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.TextMarkupInteractiveConcrete.efl_text_markup_interactive_interface_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.TextMarkupInteractiveConcrete.efl_text_markup_interactive_interface_get();
   }


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringPassOwnershipMarshaler))] private delegate  System.String efl_text_markup_interactive_markup_range_get_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor start,   Efl.TextCursorCursor end);


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringPassOwnershipMarshaler))] public delegate  System.String efl_text_markup_interactive_markup_range_get_api_delegate(System.IntPtr obj,   Efl.TextCursorCursor start,   Efl.TextCursorCursor end);
    public static Efl.Eo.FunctionWrapper<efl_text_markup_interactive_markup_range_get_api_delegate> efl_text_markup_interactive_markup_range_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_markup_interactive_markup_range_get_api_delegate>(_Module, "efl_text_markup_interactive_markup_range_get");
    private static  System.String markup_range_get(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor start,  Efl.TextCursorCursor end)
   {
      Eina.Log.Debug("function efl_text_markup_interactive_markup_range_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                       System.String _ret_var = default( System.String);
         try {
            _ret_var = ((TextMarkupInteractive)wrapper).GetMarkupRange( start,  end);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_text_markup_interactive_markup_range_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  start,  end);
      }
   }
   private static efl_text_markup_interactive_markup_range_get_delegate efl_text_markup_interactive_markup_range_get_static_delegate;


    private delegate  void efl_text_markup_interactive_markup_range_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor start,   Efl.TextCursorCursor end,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringPassOwnershipMarshaler))]   System.String markup);


    public delegate  void efl_text_markup_interactive_markup_range_set_api_delegate(System.IntPtr obj,   Efl.TextCursorCursor start,   Efl.TextCursorCursor end,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringPassOwnershipMarshaler))]   System.String markup);
    public static Efl.Eo.FunctionWrapper<efl_text_markup_interactive_markup_range_set_api_delegate> efl_text_markup_interactive_markup_range_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_markup_interactive_markup_range_set_api_delegate>(_Module, "efl_text_markup_interactive_markup_range_set");
    private static  void markup_range_set(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor start,  Efl.TextCursorCursor end,   System.String markup)
   {
      Eina.Log.Debug("function efl_text_markup_interactive_markup_range_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                        
         try {
            ((TextMarkupInteractive)wrapper).SetMarkupRange( start,  end,  markup);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                } else {
         efl_text_markup_interactive_markup_range_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  start,  end,  markup);
      }
   }
   private static efl_text_markup_interactive_markup_range_set_delegate efl_text_markup_interactive_markup_range_set_static_delegate;


    private delegate  void efl_text_markup_interactive_cursor_markup_insert_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String markup);


    public delegate  void efl_text_markup_interactive_cursor_markup_insert_api_delegate(System.IntPtr obj,   Efl.TextCursorCursor cur,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String markup);
    public static Efl.Eo.FunctionWrapper<efl_text_markup_interactive_cursor_markup_insert_api_delegate> efl_text_markup_interactive_cursor_markup_insert_ptr = new Efl.Eo.FunctionWrapper<efl_text_markup_interactive_cursor_markup_insert_api_delegate>(_Module, "efl_text_markup_interactive_cursor_markup_insert");
    private static  void cursor_markup_insert(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur,   System.String markup)
   {
      Eina.Log.Debug("function efl_text_markup_interactive_cursor_markup_insert was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((TextMarkupInteractive)wrapper).CursorMarkupInsert( cur,  markup);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_text_markup_interactive_cursor_markup_insert_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur,  markup);
      }
   }
   private static efl_text_markup_interactive_cursor_markup_insert_delegate efl_text_markup_interactive_cursor_markup_insert_static_delegate;


    private delegate Efl.TextCursorCursor efl_text_cursor_get_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorGetType get_type);


    public delegate Efl.TextCursorCursor efl_text_cursor_get_api_delegate(System.IntPtr obj,   Efl.TextCursorGetType get_type);
    public static Efl.Eo.FunctionWrapper<efl_text_cursor_get_api_delegate> efl_text_cursor_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_get_api_delegate>(_Module, "efl_text_cursor_get");
    private static Efl.TextCursorCursor text_cursor_get(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorGetType get_type)
   {
      Eina.Log.Debug("function efl_text_cursor_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    Efl.TextCursorCursor _ret_var = default(Efl.TextCursorCursor);
         try {
            _ret_var = ((TextMarkupInteractive)wrapper).GetTextCursor( get_type);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_text_cursor_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  get_type);
      }
   }
   private static efl_text_cursor_get_delegate efl_text_cursor_get_static_delegate;


    private delegate  int efl_text_cursor_position_get_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur);


    public delegate  int efl_text_cursor_position_get_api_delegate(System.IntPtr obj,   Efl.TextCursorCursor cur);
    public static Efl.Eo.FunctionWrapper<efl_text_cursor_position_get_api_delegate> efl_text_cursor_position_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_position_get_api_delegate>(_Module, "efl_text_cursor_position_get");
    private static  int cursor_position_get(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur)
   {
      Eina.Log.Debug("function efl_text_cursor_position_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                     int _ret_var = default( int);
         try {
            _ret_var = ((TextMarkupInteractive)wrapper).GetCursorPosition( cur);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_text_cursor_position_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur);
      }
   }
   private static efl_text_cursor_position_get_delegate efl_text_cursor_position_get_static_delegate;


    private delegate  void efl_text_cursor_position_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur,    int position);


    public delegate  void efl_text_cursor_position_set_api_delegate(System.IntPtr obj,   Efl.TextCursorCursor cur,    int position);
    public static Efl.Eo.FunctionWrapper<efl_text_cursor_position_set_api_delegate> efl_text_cursor_position_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_position_set_api_delegate>(_Module, "efl_text_cursor_position_set");
    private static  void cursor_position_set(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur,   int position)
   {
      Eina.Log.Debug("function efl_text_cursor_position_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((TextMarkupInteractive)wrapper).SetCursorPosition( cur,  position);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_text_cursor_position_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur,  position);
      }
   }
   private static efl_text_cursor_position_set_delegate efl_text_cursor_position_set_static_delegate;


    private delegate Eina.Unicode efl_text_cursor_content_get_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur);


    public delegate Eina.Unicode efl_text_cursor_content_get_api_delegate(System.IntPtr obj,   Efl.TextCursorCursor cur);
    public static Efl.Eo.FunctionWrapper<efl_text_cursor_content_get_api_delegate> efl_text_cursor_content_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_content_get_api_delegate>(_Module, "efl_text_cursor_content_get");
    private static Eina.Unicode cursor_content_get(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur)
   {
      Eina.Log.Debug("function efl_text_cursor_content_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    Eina.Unicode _ret_var = default(Eina.Unicode);
         try {
            _ret_var = ((TextMarkupInteractive)wrapper).GetCursorContent( cur);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_text_cursor_content_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur);
      }
   }
   private static efl_text_cursor_content_get_delegate efl_text_cursor_content_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_text_cursor_geometry_get_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur,   Efl.TextCursorType ctype,   out  int cx,   out  int cy,   out  int cw,   out  int ch,   out  int cx2,   out  int cy2,   out  int cw2,   out  int ch2);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_text_cursor_geometry_get_api_delegate(System.IntPtr obj,   Efl.TextCursorCursor cur,   Efl.TextCursorType ctype,   out  int cx,   out  int cy,   out  int cw,   out  int ch,   out  int cx2,   out  int cy2,   out  int cw2,   out  int ch2);
    public static Efl.Eo.FunctionWrapper<efl_text_cursor_geometry_get_api_delegate> efl_text_cursor_geometry_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_geometry_get_api_delegate>(_Module, "efl_text_cursor_geometry_get");
    private static bool cursor_geometry_get(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur,  Efl.TextCursorType ctype,  out  int cx,  out  int cy,  out  int cw,  out  int ch,  out  int cx2,  out  int cy2,  out  int cw2,  out  int ch2)
   {
      Eina.Log.Debug("function efl_text_cursor_geometry_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                       cx = default( int);      cy = default( int);      cw = default( int);      ch = default( int);      cx2 = default( int);      cy2 = default( int);      cw2 = default( int);      ch2 = default( int);                                                                     bool _ret_var = default(bool);
         try {
            _ret_var = ((TextMarkupInteractive)wrapper).GetCursorGeometry( cur,  ctype,  out cx,  out cy,  out cw,  out ch,  out cx2,  out cy2,  out cw2,  out ch2);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                                                                              return _ret_var;
      } else {
         return efl_text_cursor_geometry_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur,  ctype,  out cx,  out cy,  out cw,  out ch,  out cx2,  out cy2,  out cw2,  out ch2);
      }
   }
   private static efl_text_cursor_geometry_get_delegate efl_text_cursor_geometry_get_static_delegate;


    private delegate Efl.TextCursorCursor efl_text_cursor_new_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Efl.TextCursorCursor efl_text_cursor_new_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_text_cursor_new_api_delegate> efl_text_cursor_new_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_new_api_delegate>(_Module, "efl_text_cursor_new");
    private static Efl.TextCursorCursor cursor_new(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_cursor_new was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.TextCursorCursor _ret_var = default(Efl.TextCursorCursor);
         try {
            _ret_var = ((TextMarkupInteractive)wrapper).NewCursor();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_cursor_new_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_text_cursor_new_delegate efl_text_cursor_new_static_delegate;


    private delegate  void efl_text_cursor_free_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur);


    public delegate  void efl_text_cursor_free_api_delegate(System.IntPtr obj,   Efl.TextCursorCursor cur);
    public static Efl.Eo.FunctionWrapper<efl_text_cursor_free_api_delegate> efl_text_cursor_free_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_free_api_delegate>(_Module, "efl_text_cursor_free");
    private static  void cursor_free(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur)
   {
      Eina.Log.Debug("function efl_text_cursor_free was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextMarkupInteractive)wrapper).CursorFree( cur);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_cursor_free_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur);
      }
   }
   private static efl_text_cursor_free_delegate efl_text_cursor_free_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_text_cursor_equal_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur1,   Efl.TextCursorCursor cur2);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_text_cursor_equal_api_delegate(System.IntPtr obj,   Efl.TextCursorCursor cur1,   Efl.TextCursorCursor cur2);
    public static Efl.Eo.FunctionWrapper<efl_text_cursor_equal_api_delegate> efl_text_cursor_equal_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_equal_api_delegate>(_Module, "efl_text_cursor_equal");
    private static bool cursor_equal(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur1,  Efl.TextCursorCursor cur2)
   {
      Eina.Log.Debug("function efl_text_cursor_equal was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      bool _ret_var = default(bool);
         try {
            _ret_var = ((TextMarkupInteractive)wrapper).CursorEqual( cur1,  cur2);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_text_cursor_equal_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur1,  cur2);
      }
   }
   private static efl_text_cursor_equal_delegate efl_text_cursor_equal_static_delegate;


    private delegate  int efl_text_cursor_compare_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur1,   Efl.TextCursorCursor cur2);


    public delegate  int efl_text_cursor_compare_api_delegate(System.IntPtr obj,   Efl.TextCursorCursor cur1,   Efl.TextCursorCursor cur2);
    public static Efl.Eo.FunctionWrapper<efl_text_cursor_compare_api_delegate> efl_text_cursor_compare_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_compare_api_delegate>(_Module, "efl_text_cursor_compare");
    private static  int cursor_compare(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur1,  Efl.TextCursorCursor cur2)
   {
      Eina.Log.Debug("function efl_text_cursor_compare was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                       int _ret_var = default( int);
         try {
            _ret_var = ((TextMarkupInteractive)wrapper).CursorCompare( cur1,  cur2);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_text_cursor_compare_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur1,  cur2);
      }
   }
   private static efl_text_cursor_compare_delegate efl_text_cursor_compare_static_delegate;


    private delegate  void efl_text_cursor_copy_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor dst,   Efl.TextCursorCursor src);


    public delegate  void efl_text_cursor_copy_api_delegate(System.IntPtr obj,   Efl.TextCursorCursor dst,   Efl.TextCursorCursor src);
    public static Efl.Eo.FunctionWrapper<efl_text_cursor_copy_api_delegate> efl_text_cursor_copy_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_copy_api_delegate>(_Module, "efl_text_cursor_copy");
    private static  void cursor_copy(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor dst,  Efl.TextCursorCursor src)
   {
      Eina.Log.Debug("function efl_text_cursor_copy was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((TextMarkupInteractive)wrapper).CursorCopy( dst,  src);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_text_cursor_copy_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  dst,  src);
      }
   }
   private static efl_text_cursor_copy_delegate efl_text_cursor_copy_static_delegate;


    private delegate  void efl_text_cursor_char_next_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur);


    public delegate  void efl_text_cursor_char_next_api_delegate(System.IntPtr obj,   Efl.TextCursorCursor cur);
    public static Efl.Eo.FunctionWrapper<efl_text_cursor_char_next_api_delegate> efl_text_cursor_char_next_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_char_next_api_delegate>(_Module, "efl_text_cursor_char_next");
    private static  void cursor_char_next(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur)
   {
      Eina.Log.Debug("function efl_text_cursor_char_next was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextMarkupInteractive)wrapper).CursorCharNext( cur);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_cursor_char_next_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur);
      }
   }
   private static efl_text_cursor_char_next_delegate efl_text_cursor_char_next_static_delegate;


    private delegate  void efl_text_cursor_char_prev_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur);


    public delegate  void efl_text_cursor_char_prev_api_delegate(System.IntPtr obj,   Efl.TextCursorCursor cur);
    public static Efl.Eo.FunctionWrapper<efl_text_cursor_char_prev_api_delegate> efl_text_cursor_char_prev_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_char_prev_api_delegate>(_Module, "efl_text_cursor_char_prev");
    private static  void cursor_char_prev(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur)
   {
      Eina.Log.Debug("function efl_text_cursor_char_prev was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextMarkupInteractive)wrapper).CursorCharPrev( cur);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_cursor_char_prev_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur);
      }
   }
   private static efl_text_cursor_char_prev_delegate efl_text_cursor_char_prev_static_delegate;


    private delegate  void efl_text_cursor_cluster_next_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur);


    public delegate  void efl_text_cursor_cluster_next_api_delegate(System.IntPtr obj,   Efl.TextCursorCursor cur);
    public static Efl.Eo.FunctionWrapper<efl_text_cursor_cluster_next_api_delegate> efl_text_cursor_cluster_next_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_cluster_next_api_delegate>(_Module, "efl_text_cursor_cluster_next");
    private static  void cursor_cluster_next(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur)
   {
      Eina.Log.Debug("function efl_text_cursor_cluster_next was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextMarkupInteractive)wrapper).CursorClusterNext( cur);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_cursor_cluster_next_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur);
      }
   }
   private static efl_text_cursor_cluster_next_delegate efl_text_cursor_cluster_next_static_delegate;


    private delegate  void efl_text_cursor_cluster_prev_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur);


    public delegate  void efl_text_cursor_cluster_prev_api_delegate(System.IntPtr obj,   Efl.TextCursorCursor cur);
    public static Efl.Eo.FunctionWrapper<efl_text_cursor_cluster_prev_api_delegate> efl_text_cursor_cluster_prev_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_cluster_prev_api_delegate>(_Module, "efl_text_cursor_cluster_prev");
    private static  void cursor_cluster_prev(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur)
   {
      Eina.Log.Debug("function efl_text_cursor_cluster_prev was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextMarkupInteractive)wrapper).CursorClusterPrev( cur);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_cursor_cluster_prev_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur);
      }
   }
   private static efl_text_cursor_cluster_prev_delegate efl_text_cursor_cluster_prev_static_delegate;


    private delegate  void efl_text_cursor_paragraph_char_first_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur);


    public delegate  void efl_text_cursor_paragraph_char_first_api_delegate(System.IntPtr obj,   Efl.TextCursorCursor cur);
    public static Efl.Eo.FunctionWrapper<efl_text_cursor_paragraph_char_first_api_delegate> efl_text_cursor_paragraph_char_first_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_paragraph_char_first_api_delegate>(_Module, "efl_text_cursor_paragraph_char_first");
    private static  void cursor_paragraph_char_first(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur)
   {
      Eina.Log.Debug("function efl_text_cursor_paragraph_char_first was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextMarkupInteractive)wrapper).CursorParagraphCharFirst( cur);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_cursor_paragraph_char_first_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur);
      }
   }
   private static efl_text_cursor_paragraph_char_first_delegate efl_text_cursor_paragraph_char_first_static_delegate;


    private delegate  void efl_text_cursor_paragraph_char_last_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur);


    public delegate  void efl_text_cursor_paragraph_char_last_api_delegate(System.IntPtr obj,   Efl.TextCursorCursor cur);
    public static Efl.Eo.FunctionWrapper<efl_text_cursor_paragraph_char_last_api_delegate> efl_text_cursor_paragraph_char_last_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_paragraph_char_last_api_delegate>(_Module, "efl_text_cursor_paragraph_char_last");
    private static  void cursor_paragraph_char_last(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur)
   {
      Eina.Log.Debug("function efl_text_cursor_paragraph_char_last was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextMarkupInteractive)wrapper).CursorParagraphCharLast( cur);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_cursor_paragraph_char_last_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur);
      }
   }
   private static efl_text_cursor_paragraph_char_last_delegate efl_text_cursor_paragraph_char_last_static_delegate;


    private delegate  void efl_text_cursor_word_start_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur);


    public delegate  void efl_text_cursor_word_start_api_delegate(System.IntPtr obj,   Efl.TextCursorCursor cur);
    public static Efl.Eo.FunctionWrapper<efl_text_cursor_word_start_api_delegate> efl_text_cursor_word_start_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_word_start_api_delegate>(_Module, "efl_text_cursor_word_start");
    private static  void cursor_word_start(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur)
   {
      Eina.Log.Debug("function efl_text_cursor_word_start was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextMarkupInteractive)wrapper).CursorWordStart( cur);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_cursor_word_start_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur);
      }
   }
   private static efl_text_cursor_word_start_delegate efl_text_cursor_word_start_static_delegate;


    private delegate  void efl_text_cursor_word_end_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur);


    public delegate  void efl_text_cursor_word_end_api_delegate(System.IntPtr obj,   Efl.TextCursorCursor cur);
    public static Efl.Eo.FunctionWrapper<efl_text_cursor_word_end_api_delegate> efl_text_cursor_word_end_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_word_end_api_delegate>(_Module, "efl_text_cursor_word_end");
    private static  void cursor_word_end(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur)
   {
      Eina.Log.Debug("function efl_text_cursor_word_end was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextMarkupInteractive)wrapper).CursorWordEnd( cur);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_cursor_word_end_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur);
      }
   }
   private static efl_text_cursor_word_end_delegate efl_text_cursor_word_end_static_delegate;


    private delegate  void efl_text_cursor_line_char_first_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur);


    public delegate  void efl_text_cursor_line_char_first_api_delegate(System.IntPtr obj,   Efl.TextCursorCursor cur);
    public static Efl.Eo.FunctionWrapper<efl_text_cursor_line_char_first_api_delegate> efl_text_cursor_line_char_first_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_line_char_first_api_delegate>(_Module, "efl_text_cursor_line_char_first");
    private static  void cursor_line_char_first(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur)
   {
      Eina.Log.Debug("function efl_text_cursor_line_char_first was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextMarkupInteractive)wrapper).CursorLineCharFirst( cur);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_cursor_line_char_first_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur);
      }
   }
   private static efl_text_cursor_line_char_first_delegate efl_text_cursor_line_char_first_static_delegate;


    private delegate  void efl_text_cursor_line_char_last_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur);


    public delegate  void efl_text_cursor_line_char_last_api_delegate(System.IntPtr obj,   Efl.TextCursorCursor cur);
    public static Efl.Eo.FunctionWrapper<efl_text_cursor_line_char_last_api_delegate> efl_text_cursor_line_char_last_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_line_char_last_api_delegate>(_Module, "efl_text_cursor_line_char_last");
    private static  void cursor_line_char_last(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur)
   {
      Eina.Log.Debug("function efl_text_cursor_line_char_last was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextMarkupInteractive)wrapper).CursorLineCharLast( cur);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_cursor_line_char_last_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur);
      }
   }
   private static efl_text_cursor_line_char_last_delegate efl_text_cursor_line_char_last_static_delegate;


    private delegate  void efl_text_cursor_paragraph_first_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur);


    public delegate  void efl_text_cursor_paragraph_first_api_delegate(System.IntPtr obj,   Efl.TextCursorCursor cur);
    public static Efl.Eo.FunctionWrapper<efl_text_cursor_paragraph_first_api_delegate> efl_text_cursor_paragraph_first_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_paragraph_first_api_delegate>(_Module, "efl_text_cursor_paragraph_first");
    private static  void cursor_paragraph_first(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur)
   {
      Eina.Log.Debug("function efl_text_cursor_paragraph_first was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextMarkupInteractive)wrapper).CursorParagraphFirst( cur);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_cursor_paragraph_first_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur);
      }
   }
   private static efl_text_cursor_paragraph_first_delegate efl_text_cursor_paragraph_first_static_delegate;


    private delegate  void efl_text_cursor_paragraph_last_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur);


    public delegate  void efl_text_cursor_paragraph_last_api_delegate(System.IntPtr obj,   Efl.TextCursorCursor cur);
    public static Efl.Eo.FunctionWrapper<efl_text_cursor_paragraph_last_api_delegate> efl_text_cursor_paragraph_last_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_paragraph_last_api_delegate>(_Module, "efl_text_cursor_paragraph_last");
    private static  void cursor_paragraph_last(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur)
   {
      Eina.Log.Debug("function efl_text_cursor_paragraph_last was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextMarkupInteractive)wrapper).CursorParagraphLast( cur);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_cursor_paragraph_last_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur);
      }
   }
   private static efl_text_cursor_paragraph_last_delegate efl_text_cursor_paragraph_last_static_delegate;


    private delegate  void efl_text_cursor_paragraph_next_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur);


    public delegate  void efl_text_cursor_paragraph_next_api_delegate(System.IntPtr obj,   Efl.TextCursorCursor cur);
    public static Efl.Eo.FunctionWrapper<efl_text_cursor_paragraph_next_api_delegate> efl_text_cursor_paragraph_next_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_paragraph_next_api_delegate>(_Module, "efl_text_cursor_paragraph_next");
    private static  void cursor_paragraph_next(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur)
   {
      Eina.Log.Debug("function efl_text_cursor_paragraph_next was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextMarkupInteractive)wrapper).CursorParagraphNext( cur);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_cursor_paragraph_next_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur);
      }
   }
   private static efl_text_cursor_paragraph_next_delegate efl_text_cursor_paragraph_next_static_delegate;


    private delegate  void efl_text_cursor_paragraph_prev_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur);


    public delegate  void efl_text_cursor_paragraph_prev_api_delegate(System.IntPtr obj,   Efl.TextCursorCursor cur);
    public static Efl.Eo.FunctionWrapper<efl_text_cursor_paragraph_prev_api_delegate> efl_text_cursor_paragraph_prev_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_paragraph_prev_api_delegate>(_Module, "efl_text_cursor_paragraph_prev");
    private static  void cursor_paragraph_prev(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur)
   {
      Eina.Log.Debug("function efl_text_cursor_paragraph_prev was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextMarkupInteractive)wrapper).CursorParagraphPrev( cur);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_cursor_paragraph_prev_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur);
      }
   }
   private static efl_text_cursor_paragraph_prev_delegate efl_text_cursor_paragraph_prev_static_delegate;


    private delegate  void efl_text_cursor_line_jump_by_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur,    int by);


    public delegate  void efl_text_cursor_line_jump_by_api_delegate(System.IntPtr obj,   Efl.TextCursorCursor cur,    int by);
    public static Efl.Eo.FunctionWrapper<efl_text_cursor_line_jump_by_api_delegate> efl_text_cursor_line_jump_by_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_line_jump_by_api_delegate>(_Module, "efl_text_cursor_line_jump_by");
    private static  void cursor_line_jump_by(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur,   int by)
   {
      Eina.Log.Debug("function efl_text_cursor_line_jump_by was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((TextMarkupInteractive)wrapper).CursorLineJumpBy( cur,  by);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_text_cursor_line_jump_by_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur,  by);
      }
   }
   private static efl_text_cursor_line_jump_by_delegate efl_text_cursor_line_jump_by_static_delegate;


    private delegate  void efl_text_cursor_coord_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur,    int x,    int y);


    public delegate  void efl_text_cursor_coord_set_api_delegate(System.IntPtr obj,   Efl.TextCursorCursor cur,    int x,    int y);
    public static Efl.Eo.FunctionWrapper<efl_text_cursor_coord_set_api_delegate> efl_text_cursor_coord_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_coord_set_api_delegate>(_Module, "efl_text_cursor_coord_set");
    private static  void cursor_coord_set(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur,   int x,   int y)
   {
      Eina.Log.Debug("function efl_text_cursor_coord_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                        
         try {
            ((TextMarkupInteractive)wrapper).SetCursorCoord( cur,  x,  y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                } else {
         efl_text_cursor_coord_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur,  x,  y);
      }
   }
   private static efl_text_cursor_coord_set_delegate efl_text_cursor_coord_set_static_delegate;


    private delegate  void efl_text_cursor_cluster_coord_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur,    int x,    int y);


    public delegate  void efl_text_cursor_cluster_coord_set_api_delegate(System.IntPtr obj,   Efl.TextCursorCursor cur,    int x,    int y);
    public static Efl.Eo.FunctionWrapper<efl_text_cursor_cluster_coord_set_api_delegate> efl_text_cursor_cluster_coord_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_cluster_coord_set_api_delegate>(_Module, "efl_text_cursor_cluster_coord_set");
    private static  void cursor_cluster_coord_set(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur,   int x,   int y)
   {
      Eina.Log.Debug("function efl_text_cursor_cluster_coord_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                        
         try {
            ((TextMarkupInteractive)wrapper).SetCursorClusterCoord( cur,  x,  y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                } else {
         efl_text_cursor_cluster_coord_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur,  x,  y);
      }
   }
   private static efl_text_cursor_cluster_coord_set_delegate efl_text_cursor_cluster_coord_set_static_delegate;


    private delegate  int efl_text_cursor_text_insert_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String text);


    public delegate  int efl_text_cursor_text_insert_api_delegate(System.IntPtr obj,   Efl.TextCursorCursor cur,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String text);
    public static Efl.Eo.FunctionWrapper<efl_text_cursor_text_insert_api_delegate> efl_text_cursor_text_insert_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_text_insert_api_delegate>(_Module, "efl_text_cursor_text_insert");
    private static  int cursor_text_insert(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur,   System.String text)
   {
      Eina.Log.Debug("function efl_text_cursor_text_insert was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                       int _ret_var = default( int);
         try {
            _ret_var = ((TextMarkupInteractive)wrapper).CursorTextInsert( cur,  text);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_text_cursor_text_insert_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur,  text);
      }
   }
   private static efl_text_cursor_text_insert_delegate efl_text_cursor_text_insert_static_delegate;


    private delegate  void efl_text_cursor_char_delete_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur);


    public delegate  void efl_text_cursor_char_delete_api_delegate(System.IntPtr obj,   Efl.TextCursorCursor cur);
    public static Efl.Eo.FunctionWrapper<efl_text_cursor_char_delete_api_delegate> efl_text_cursor_char_delete_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_char_delete_api_delegate>(_Module, "efl_text_cursor_char_delete");
    private static  void cursor_char_delete(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur)
   {
      Eina.Log.Debug("function efl_text_cursor_char_delete was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextMarkupInteractive)wrapper).CursorCharDelete( cur);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_cursor_char_delete_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur);
      }
   }
   private static efl_text_cursor_char_delete_delegate efl_text_cursor_char_delete_static_delegate;
}
} 
