#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { 
/// <summary>Cursor API
/// 1.20</summary>
[TextCursorConcreteNativeInherit]
public interface TextCursor : 
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>The object&apos;s main cursor.
/// 1.18</summary>
/// <param name="get_type">Cursor type
/// 1.20</param>
/// <returns>Text cursor object
/// 1.20</returns>
Efl.TextCursorCursor GetTextCursor( Efl.TextCursorGetType get_type);
   /// <summary>Cursor position
/// 1.20</summary>
/// <param name="cur">Cursor object
/// 1.20</param>
/// <returns>Cursor position
/// 1.20</returns>
 int GetCursorPosition( Efl.TextCursorCursor cur);
   /// <summary>Cursor position
/// 1.20</summary>
/// <param name="cur">Cursor object
/// 1.20</param>
/// <param name="position">Cursor position
/// 1.20</param>
/// <returns></returns>
 void SetCursorPosition( Efl.TextCursorCursor cur,   int position);
   /// <summary>The content of the cursor (the character under the cursor)
/// 1.20</summary>
/// <param name="cur">Cursor object
/// 1.20</param>
/// <returns>The unicode codepoint of the character
/// 1.20</returns>
Eina.Unicode GetCursorContent( Efl.TextCursorCursor cur);
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
bool GetCursorGeometry( Efl.TextCursorCursor cur,  Efl.TextCursorType ctype,  out  int cx,  out  int cy,  out  int cw,  out  int ch,  out  int cx2,  out  int cy2,  out  int cw2,  out  int ch2);
   /// <summary>Create new cursor
/// 1.20</summary>
/// <returns>Cursor object
/// 1.20</returns>
Efl.TextCursorCursor NewCursor();
   /// <summary>Free existing cursor
/// 1.20</summary>
/// <param name="cur">Cursor object
/// 1.20</param>
/// <returns></returns>
 void CursorFree( Efl.TextCursorCursor cur);
   /// <summary>Check if two cursors are equal
/// 1.20</summary>
/// <param name="cur1">Cursor 1 object
/// 1.20</param>
/// <param name="cur2">Cursor 2 object
/// 1.20</param>
/// <returns><c>true</c> if cursors are equal, <c>false</c> otherwise
/// 1.20</returns>
bool CursorEqual( Efl.TextCursorCursor cur1,  Efl.TextCursorCursor cur2);
   /// <summary>Compare two cursors
/// 1.20</summary>
/// <param name="cur1">Cursor 1 object
/// 1.20</param>
/// <param name="cur2">Cursor 2 object
/// 1.20</param>
/// <returns>Difference between cursors
/// 1.20</returns>
 int CursorCompare( Efl.TextCursorCursor cur1,  Efl.TextCursorCursor cur2);
   /// <summary>Copy existing cursor
/// 1.20</summary>
/// <param name="dst">Destination cursor
/// 1.20</param>
/// <param name="src">Source cursor
/// 1.20</param>
/// <returns></returns>
 void CursorCopy( Efl.TextCursorCursor dst,  Efl.TextCursorCursor src);
   /// <summary>Advances to the next character
/// 1.20</summary>
/// <param name="cur">Cursor object
/// 1.20</param>
/// <returns></returns>
 void CursorCharNext( Efl.TextCursorCursor cur);
   /// <summary>Advances to the previous character
/// 1.20</summary>
/// <param name="cur">Cursor object
/// 1.20</param>
/// <returns></returns>
 void CursorCharPrev( Efl.TextCursorCursor cur);
   /// <summary>Advances to the next grapheme cluster
/// 1.20</summary>
/// <param name="cur">Cursor object
/// 1.20</param>
/// <returns></returns>
 void CursorClusterNext( Efl.TextCursorCursor cur);
   /// <summary>Advances to the previous grapheme cluster
/// 1.20</summary>
/// <param name="cur">Cursor object
/// 1.20</param>
/// <returns></returns>
 void CursorClusterPrev( Efl.TextCursorCursor cur);
   /// <summary>Advances to the first character in this paragraph
/// 1.20</summary>
/// <param name="cur">Cursor object
/// 1.20</param>
/// <returns></returns>
 void CursorParagraphCharFirst( Efl.TextCursorCursor cur);
   /// <summary>Advances to the last character in this paragraph
/// 1.20</summary>
/// <param name="cur">Cursor object
/// 1.20</param>
/// <returns></returns>
 void CursorParagraphCharLast( Efl.TextCursorCursor cur);
   /// <summary>Advance to current word start
/// 1.20</summary>
/// <param name="cur">Cursor object
/// 1.20</param>
/// <returns></returns>
 void CursorWordStart( Efl.TextCursorCursor cur);
   /// <summary>Advance to current word end
/// 1.20</summary>
/// <param name="cur">Cursor object
/// 1.20</param>
/// <returns></returns>
 void CursorWordEnd( Efl.TextCursorCursor cur);
   /// <summary>Advance to current line first character
/// 1.20</summary>
/// <param name="cur">Cursor object
/// 1.20</param>
/// <returns></returns>
 void CursorLineCharFirst( Efl.TextCursorCursor cur);
   /// <summary>Advance to current line last character
/// 1.20</summary>
/// <param name="cur">Cursor object
/// 1.20</param>
/// <returns></returns>
 void CursorLineCharLast( Efl.TextCursorCursor cur);
   /// <summary>Advance to current paragraph first character
/// 1.20</summary>
/// <param name="cur">Cursor object
/// 1.20</param>
/// <returns></returns>
 void CursorParagraphFirst( Efl.TextCursorCursor cur);
   /// <summary>Advance to current paragraph last character
/// 1.20</summary>
/// <param name="cur">Cursor object
/// 1.20</param>
/// <returns></returns>
 void CursorParagraphLast( Efl.TextCursorCursor cur);
   /// <summary>Advances to the start of the next text node
/// 1.20</summary>
/// <param name="cur">Cursor object
/// 1.20</param>
/// <returns></returns>
 void CursorParagraphNext( Efl.TextCursorCursor cur);
   /// <summary>Advances to the end of the previous text node
/// 1.20</summary>
/// <param name="cur">Cursor object
/// 1.20</param>
/// <returns></returns>
 void CursorParagraphPrev( Efl.TextCursorCursor cur);
   /// <summary>Jump the cursor by the given number of lines
/// 1.20</summary>
/// <param name="cur">Cursor object
/// 1.20</param>
/// <param name="by">Number of lines
/// 1.20</param>
/// <returns></returns>
 void CursorLineJumpBy( Efl.TextCursorCursor cur,   int by);
   /// <summary>Set cursor coordinates
/// 1.20</summary>
/// <param name="cur">Cursor object
/// 1.20</param>
/// <param name="x">X coord to set by.
/// 1.20</param>
/// <param name="y">Y coord to set by.
/// 1.20</param>
/// <returns></returns>
 void SetCursorCoord( Efl.TextCursorCursor cur,   int x,   int y);
   /// <summary>Set cursor coordinates according to grapheme clusters. It does not allow to put a cursor to the middle of a grapheme cluster.
/// 1.20</summary>
/// <param name="cur">Cursor object
/// 1.20</param>
/// <param name="x">X coord to set by.
/// 1.20</param>
/// <param name="y">Y coord to set by.
/// 1.20</param>
/// <returns></returns>
 void SetCursorClusterCoord( Efl.TextCursorCursor cur,   int x,   int y);
   /// <summary>Adds text to the current cursor position and set the cursor to *after* the start of the text just added.
/// 1.20</summary>
/// <param name="cur">Cursor object
/// 1.20</param>
/// <param name="text">Text to append (UTF-8 format).
/// 1.20</param>
/// <returns>Length of the appended text.
/// 1.20</returns>
 int CursorTextInsert( Efl.TextCursorCursor cur,   System.String text);
   /// <summary>Deletes a single character from position pointed by given cursor.
/// 1.20</summary>
/// <param name="cur">Cursor object
/// 1.20</param>
/// <returns></returns>
 void CursorCharDelete( Efl.TextCursorCursor cur);
                                                                                       }
/// <summary>Cursor API
/// 1.20</summary>
sealed public class TextCursorConcrete : 

TextCursor
   
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (TextCursorConcrete))
            return Efl.TextCursorConcreteNativeInherit.GetEflClassStatic();
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
      efl_text_cursor_interface_get();
   ///<summary>Constructs an instance from a native pointer.</summary>
   public TextCursorConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~TextCursorConcrete()
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
   public static TextCursorConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new TextCursorConcrete(obj.NativeHandle);
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
    private static extern Efl.TextCursorCursor efl_text_cursor_get(System.IntPtr obj,   Efl.TextCursorGetType get_type);
   /// <summary>The object&apos;s main cursor.
   /// 1.18</summary>
   /// <param name="get_type">Cursor type
   /// 1.20</param>
   /// <returns>Text cursor object
   /// 1.20</returns>
   public Efl.TextCursorCursor GetTextCursor( Efl.TextCursorGetType get_type) {
                         var _ret_var = efl_text_cursor_get(Efl.TextCursorConcrete.efl_text_cursor_interface_get(),  get_type);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  int efl_text_cursor_position_get(System.IntPtr obj,   Efl.TextCursorCursor cur);
   /// <summary>Cursor position
   /// 1.20</summary>
   /// <param name="cur">Cursor object
   /// 1.20</param>
   /// <returns>Cursor position
   /// 1.20</returns>
   public  int GetCursorPosition( Efl.TextCursorCursor cur) {
                         var _ret_var = efl_text_cursor_position_get(Efl.TextCursorConcrete.efl_text_cursor_interface_get(),  cur);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_text_cursor_position_set(System.IntPtr obj,   Efl.TextCursorCursor cur,    int position);
   /// <summary>Cursor position
   /// 1.20</summary>
   /// <param name="cur">Cursor object
   /// 1.20</param>
   /// <param name="position">Cursor position
   /// 1.20</param>
   /// <returns></returns>
   public  void SetCursorPosition( Efl.TextCursorCursor cur,   int position) {
                                           efl_text_cursor_position_set(Efl.TextCursorConcrete.efl_text_cursor_interface_get(),  cur,  position);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern Eina.Unicode efl_text_cursor_content_get(System.IntPtr obj,   Efl.TextCursorCursor cur);
   /// <summary>The content of the cursor (the character under the cursor)
   /// 1.20</summary>
   /// <param name="cur">Cursor object
   /// 1.20</param>
   /// <returns>The unicode codepoint of the character
   /// 1.20</returns>
   public Eina.Unicode GetCursorContent( Efl.TextCursorCursor cur) {
                         var _ret_var = efl_text_cursor_content_get(Efl.TextCursorConcrete.efl_text_cursor_interface_get(),  cur);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_text_cursor_geometry_get(System.IntPtr obj,   Efl.TextCursorCursor cur,   Efl.TextCursorType ctype,   out  int cx,   out  int cy,   out  int cw,   out  int ch,   out  int cx2,   out  int cy2,   out  int cw2,   out  int ch2);
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
                                                                                                                                                                                           var _ret_var = efl_text_cursor_geometry_get(Efl.TextCursorConcrete.efl_text_cursor_interface_get(),  cur,  ctype,  out cx,  out cy,  out cw,  out ch,  out cx2,  out cy2,  out cw2,  out ch2);
      Eina.Error.RaiseIfUnhandledException();
                                                                                                                              return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern Efl.TextCursorCursor efl_text_cursor_new(System.IntPtr obj);
   /// <summary>Create new cursor
   /// 1.20</summary>
   /// <returns>Cursor object
   /// 1.20</returns>
   public Efl.TextCursorCursor NewCursor() {
       var _ret_var = efl_text_cursor_new(Efl.TextCursorConcrete.efl_text_cursor_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_text_cursor_free(System.IntPtr obj,   Efl.TextCursorCursor cur);
   /// <summary>Free existing cursor
   /// 1.20</summary>
   /// <param name="cur">Cursor object
   /// 1.20</param>
   /// <returns></returns>
   public  void CursorFree( Efl.TextCursorCursor cur) {
                         efl_text_cursor_free(Efl.TextCursorConcrete.efl_text_cursor_interface_get(),  cur);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_text_cursor_equal(System.IntPtr obj,   Efl.TextCursorCursor cur1,   Efl.TextCursorCursor cur2);
   /// <summary>Check if two cursors are equal
   /// 1.20</summary>
   /// <param name="cur1">Cursor 1 object
   /// 1.20</param>
   /// <param name="cur2">Cursor 2 object
   /// 1.20</param>
   /// <returns><c>true</c> if cursors are equal, <c>false</c> otherwise
   /// 1.20</returns>
   public bool CursorEqual( Efl.TextCursorCursor cur1,  Efl.TextCursorCursor cur2) {
                                           var _ret_var = efl_text_cursor_equal(Efl.TextCursorConcrete.efl_text_cursor_interface_get(),  cur1,  cur2);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  int efl_text_cursor_compare(System.IntPtr obj,   Efl.TextCursorCursor cur1,   Efl.TextCursorCursor cur2);
   /// <summary>Compare two cursors
   /// 1.20</summary>
   /// <param name="cur1">Cursor 1 object
   /// 1.20</param>
   /// <param name="cur2">Cursor 2 object
   /// 1.20</param>
   /// <returns>Difference between cursors
   /// 1.20</returns>
   public  int CursorCompare( Efl.TextCursorCursor cur1,  Efl.TextCursorCursor cur2) {
                                           var _ret_var = efl_text_cursor_compare(Efl.TextCursorConcrete.efl_text_cursor_interface_get(),  cur1,  cur2);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_text_cursor_copy(System.IntPtr obj,   Efl.TextCursorCursor dst,   Efl.TextCursorCursor src);
   /// <summary>Copy existing cursor
   /// 1.20</summary>
   /// <param name="dst">Destination cursor
   /// 1.20</param>
   /// <param name="src">Source cursor
   /// 1.20</param>
   /// <returns></returns>
   public  void CursorCopy( Efl.TextCursorCursor dst,  Efl.TextCursorCursor src) {
                                           efl_text_cursor_copy(Efl.TextCursorConcrete.efl_text_cursor_interface_get(),  dst,  src);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_text_cursor_char_next(System.IntPtr obj,   Efl.TextCursorCursor cur);
   /// <summary>Advances to the next character
   /// 1.20</summary>
   /// <param name="cur">Cursor object
   /// 1.20</param>
   /// <returns></returns>
   public  void CursorCharNext( Efl.TextCursorCursor cur) {
                         efl_text_cursor_char_next(Efl.TextCursorConcrete.efl_text_cursor_interface_get(),  cur);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_text_cursor_char_prev(System.IntPtr obj,   Efl.TextCursorCursor cur);
   /// <summary>Advances to the previous character
   /// 1.20</summary>
   /// <param name="cur">Cursor object
   /// 1.20</param>
   /// <returns></returns>
   public  void CursorCharPrev( Efl.TextCursorCursor cur) {
                         efl_text_cursor_char_prev(Efl.TextCursorConcrete.efl_text_cursor_interface_get(),  cur);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_text_cursor_cluster_next(System.IntPtr obj,   Efl.TextCursorCursor cur);
   /// <summary>Advances to the next grapheme cluster
   /// 1.20</summary>
   /// <param name="cur">Cursor object
   /// 1.20</param>
   /// <returns></returns>
   public  void CursorClusterNext( Efl.TextCursorCursor cur) {
                         efl_text_cursor_cluster_next(Efl.TextCursorConcrete.efl_text_cursor_interface_get(),  cur);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_text_cursor_cluster_prev(System.IntPtr obj,   Efl.TextCursorCursor cur);
   /// <summary>Advances to the previous grapheme cluster
   /// 1.20</summary>
   /// <param name="cur">Cursor object
   /// 1.20</param>
   /// <returns></returns>
   public  void CursorClusterPrev( Efl.TextCursorCursor cur) {
                         efl_text_cursor_cluster_prev(Efl.TextCursorConcrete.efl_text_cursor_interface_get(),  cur);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_text_cursor_paragraph_char_first(System.IntPtr obj,   Efl.TextCursorCursor cur);
   /// <summary>Advances to the first character in this paragraph
   /// 1.20</summary>
   /// <param name="cur">Cursor object
   /// 1.20</param>
   /// <returns></returns>
   public  void CursorParagraphCharFirst( Efl.TextCursorCursor cur) {
                         efl_text_cursor_paragraph_char_first(Efl.TextCursorConcrete.efl_text_cursor_interface_get(),  cur);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_text_cursor_paragraph_char_last(System.IntPtr obj,   Efl.TextCursorCursor cur);
   /// <summary>Advances to the last character in this paragraph
   /// 1.20</summary>
   /// <param name="cur">Cursor object
   /// 1.20</param>
   /// <returns></returns>
   public  void CursorParagraphCharLast( Efl.TextCursorCursor cur) {
                         efl_text_cursor_paragraph_char_last(Efl.TextCursorConcrete.efl_text_cursor_interface_get(),  cur);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_text_cursor_word_start(System.IntPtr obj,   Efl.TextCursorCursor cur);
   /// <summary>Advance to current word start
   /// 1.20</summary>
   /// <param name="cur">Cursor object
   /// 1.20</param>
   /// <returns></returns>
   public  void CursorWordStart( Efl.TextCursorCursor cur) {
                         efl_text_cursor_word_start(Efl.TextCursorConcrete.efl_text_cursor_interface_get(),  cur);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_text_cursor_word_end(System.IntPtr obj,   Efl.TextCursorCursor cur);
   /// <summary>Advance to current word end
   /// 1.20</summary>
   /// <param name="cur">Cursor object
   /// 1.20</param>
   /// <returns></returns>
   public  void CursorWordEnd( Efl.TextCursorCursor cur) {
                         efl_text_cursor_word_end(Efl.TextCursorConcrete.efl_text_cursor_interface_get(),  cur);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_text_cursor_line_char_first(System.IntPtr obj,   Efl.TextCursorCursor cur);
   /// <summary>Advance to current line first character
   /// 1.20</summary>
   /// <param name="cur">Cursor object
   /// 1.20</param>
   /// <returns></returns>
   public  void CursorLineCharFirst( Efl.TextCursorCursor cur) {
                         efl_text_cursor_line_char_first(Efl.TextCursorConcrete.efl_text_cursor_interface_get(),  cur);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_text_cursor_line_char_last(System.IntPtr obj,   Efl.TextCursorCursor cur);
   /// <summary>Advance to current line last character
   /// 1.20</summary>
   /// <param name="cur">Cursor object
   /// 1.20</param>
   /// <returns></returns>
   public  void CursorLineCharLast( Efl.TextCursorCursor cur) {
                         efl_text_cursor_line_char_last(Efl.TextCursorConcrete.efl_text_cursor_interface_get(),  cur);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_text_cursor_paragraph_first(System.IntPtr obj,   Efl.TextCursorCursor cur);
   /// <summary>Advance to current paragraph first character
   /// 1.20</summary>
   /// <param name="cur">Cursor object
   /// 1.20</param>
   /// <returns></returns>
   public  void CursorParagraphFirst( Efl.TextCursorCursor cur) {
                         efl_text_cursor_paragraph_first(Efl.TextCursorConcrete.efl_text_cursor_interface_get(),  cur);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_text_cursor_paragraph_last(System.IntPtr obj,   Efl.TextCursorCursor cur);
   /// <summary>Advance to current paragraph last character
   /// 1.20</summary>
   /// <param name="cur">Cursor object
   /// 1.20</param>
   /// <returns></returns>
   public  void CursorParagraphLast( Efl.TextCursorCursor cur) {
                         efl_text_cursor_paragraph_last(Efl.TextCursorConcrete.efl_text_cursor_interface_get(),  cur);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_text_cursor_paragraph_next(System.IntPtr obj,   Efl.TextCursorCursor cur);
   /// <summary>Advances to the start of the next text node
   /// 1.20</summary>
   /// <param name="cur">Cursor object
   /// 1.20</param>
   /// <returns></returns>
   public  void CursorParagraphNext( Efl.TextCursorCursor cur) {
                         efl_text_cursor_paragraph_next(Efl.TextCursorConcrete.efl_text_cursor_interface_get(),  cur);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_text_cursor_paragraph_prev(System.IntPtr obj,   Efl.TextCursorCursor cur);
   /// <summary>Advances to the end of the previous text node
   /// 1.20</summary>
   /// <param name="cur">Cursor object
   /// 1.20</param>
   /// <returns></returns>
   public  void CursorParagraphPrev( Efl.TextCursorCursor cur) {
                         efl_text_cursor_paragraph_prev(Efl.TextCursorConcrete.efl_text_cursor_interface_get(),  cur);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_text_cursor_line_jump_by(System.IntPtr obj,   Efl.TextCursorCursor cur,    int by);
   /// <summary>Jump the cursor by the given number of lines
   /// 1.20</summary>
   /// <param name="cur">Cursor object
   /// 1.20</param>
   /// <param name="by">Number of lines
   /// 1.20</param>
   /// <returns></returns>
   public  void CursorLineJumpBy( Efl.TextCursorCursor cur,   int by) {
                                           efl_text_cursor_line_jump_by(Efl.TextCursorConcrete.efl_text_cursor_interface_get(),  cur,  by);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_text_cursor_coord_set(System.IntPtr obj,   Efl.TextCursorCursor cur,    int x,    int y);
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
                                                             efl_text_cursor_coord_set(Efl.TextCursorConcrete.efl_text_cursor_interface_get(),  cur,  x,  y);
      Eina.Error.RaiseIfUnhandledException();
                                           }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_text_cursor_cluster_coord_set(System.IntPtr obj,   Efl.TextCursorCursor cur,    int x,    int y);
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
                                                             efl_text_cursor_cluster_coord_set(Efl.TextCursorConcrete.efl_text_cursor_interface_get(),  cur,  x,  y);
      Eina.Error.RaiseIfUnhandledException();
                                           }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  int efl_text_cursor_text_insert(System.IntPtr obj,   Efl.TextCursorCursor cur,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String text);
   /// <summary>Adds text to the current cursor position and set the cursor to *after* the start of the text just added.
   /// 1.20</summary>
   /// <param name="cur">Cursor object
   /// 1.20</param>
   /// <param name="text">Text to append (UTF-8 format).
   /// 1.20</param>
   /// <returns>Length of the appended text.
   /// 1.20</returns>
   public  int CursorTextInsert( Efl.TextCursorCursor cur,   System.String text) {
                                           var _ret_var = efl_text_cursor_text_insert(Efl.TextCursorConcrete.efl_text_cursor_interface_get(),  cur,  text);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_text_cursor_char_delete(System.IntPtr obj,   Efl.TextCursorCursor cur);
   /// <summary>Deletes a single character from position pointed by given cursor.
   /// 1.20</summary>
   /// <param name="cur">Cursor object
   /// 1.20</param>
   /// <returns></returns>
   public  void CursorCharDelete( Efl.TextCursorCursor cur) {
                         efl_text_cursor_char_delete(Efl.TextCursorConcrete.efl_text_cursor_interface_get(),  cur);
      Eina.Error.RaiseIfUnhandledException();
                   }
}
public class TextCursorConcreteNativeInherit : Efl.Eo.NativeClass{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_text_cursor_get_static_delegate = new efl_text_cursor_get_delegate(text_cursor_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_cursor_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_get_static_delegate)});
      efl_text_cursor_position_get_static_delegate = new efl_text_cursor_position_get_delegate(cursor_position_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_cursor_position_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_position_get_static_delegate)});
      efl_text_cursor_position_set_static_delegate = new efl_text_cursor_position_set_delegate(cursor_position_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_cursor_position_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_position_set_static_delegate)});
      efl_text_cursor_content_get_static_delegate = new efl_text_cursor_content_get_delegate(cursor_content_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_cursor_content_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_content_get_static_delegate)});
      efl_text_cursor_geometry_get_static_delegate = new efl_text_cursor_geometry_get_delegate(cursor_geometry_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_cursor_geometry_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_geometry_get_static_delegate)});
      efl_text_cursor_new_static_delegate = new efl_text_cursor_new_delegate(cursor_new);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_cursor_new"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_new_static_delegate)});
      efl_text_cursor_free_static_delegate = new efl_text_cursor_free_delegate(cursor_free);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_cursor_free"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_free_static_delegate)});
      efl_text_cursor_equal_static_delegate = new efl_text_cursor_equal_delegate(cursor_equal);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_cursor_equal"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_equal_static_delegate)});
      efl_text_cursor_compare_static_delegate = new efl_text_cursor_compare_delegate(cursor_compare);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_cursor_compare"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_compare_static_delegate)});
      efl_text_cursor_copy_static_delegate = new efl_text_cursor_copy_delegate(cursor_copy);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_cursor_copy"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_copy_static_delegate)});
      efl_text_cursor_char_next_static_delegate = new efl_text_cursor_char_next_delegate(cursor_char_next);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_cursor_char_next"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_char_next_static_delegate)});
      efl_text_cursor_char_prev_static_delegate = new efl_text_cursor_char_prev_delegate(cursor_char_prev);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_cursor_char_prev"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_char_prev_static_delegate)});
      efl_text_cursor_cluster_next_static_delegate = new efl_text_cursor_cluster_next_delegate(cursor_cluster_next);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_cursor_cluster_next"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_cluster_next_static_delegate)});
      efl_text_cursor_cluster_prev_static_delegate = new efl_text_cursor_cluster_prev_delegate(cursor_cluster_prev);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_cursor_cluster_prev"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_cluster_prev_static_delegate)});
      efl_text_cursor_paragraph_char_first_static_delegate = new efl_text_cursor_paragraph_char_first_delegate(cursor_paragraph_char_first);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_cursor_paragraph_char_first"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_paragraph_char_first_static_delegate)});
      efl_text_cursor_paragraph_char_last_static_delegate = new efl_text_cursor_paragraph_char_last_delegate(cursor_paragraph_char_last);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_cursor_paragraph_char_last"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_paragraph_char_last_static_delegate)});
      efl_text_cursor_word_start_static_delegate = new efl_text_cursor_word_start_delegate(cursor_word_start);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_cursor_word_start"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_word_start_static_delegate)});
      efl_text_cursor_word_end_static_delegate = new efl_text_cursor_word_end_delegate(cursor_word_end);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_cursor_word_end"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_word_end_static_delegate)});
      efl_text_cursor_line_char_first_static_delegate = new efl_text_cursor_line_char_first_delegate(cursor_line_char_first);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_cursor_line_char_first"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_line_char_first_static_delegate)});
      efl_text_cursor_line_char_last_static_delegate = new efl_text_cursor_line_char_last_delegate(cursor_line_char_last);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_cursor_line_char_last"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_line_char_last_static_delegate)});
      efl_text_cursor_paragraph_first_static_delegate = new efl_text_cursor_paragraph_first_delegate(cursor_paragraph_first);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_cursor_paragraph_first"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_paragraph_first_static_delegate)});
      efl_text_cursor_paragraph_last_static_delegate = new efl_text_cursor_paragraph_last_delegate(cursor_paragraph_last);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_cursor_paragraph_last"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_paragraph_last_static_delegate)});
      efl_text_cursor_paragraph_next_static_delegate = new efl_text_cursor_paragraph_next_delegate(cursor_paragraph_next);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_cursor_paragraph_next"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_paragraph_next_static_delegate)});
      efl_text_cursor_paragraph_prev_static_delegate = new efl_text_cursor_paragraph_prev_delegate(cursor_paragraph_prev);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_cursor_paragraph_prev"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_paragraph_prev_static_delegate)});
      efl_text_cursor_line_jump_by_static_delegate = new efl_text_cursor_line_jump_by_delegate(cursor_line_jump_by);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_cursor_line_jump_by"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_line_jump_by_static_delegate)});
      efl_text_cursor_coord_set_static_delegate = new efl_text_cursor_coord_set_delegate(cursor_coord_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_cursor_coord_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_coord_set_static_delegate)});
      efl_text_cursor_cluster_coord_set_static_delegate = new efl_text_cursor_cluster_coord_set_delegate(cursor_cluster_coord_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_cursor_cluster_coord_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_cluster_coord_set_static_delegate)});
      efl_text_cursor_text_insert_static_delegate = new efl_text_cursor_text_insert_delegate(cursor_text_insert);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_cursor_text_insert"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_text_insert_static_delegate)});
      efl_text_cursor_char_delete_static_delegate = new efl_text_cursor_char_delete_delegate(cursor_char_delete);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_cursor_char_delete"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_char_delete_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.TextCursorConcrete.efl_text_cursor_interface_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.TextCursorConcrete.efl_text_cursor_interface_get();
   }


    private delegate Efl.TextCursorCursor efl_text_cursor_get_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorGetType get_type);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Efl.TextCursorCursor efl_text_cursor_get(System.IntPtr obj,   Efl.TextCursorGetType get_type);
    private static Efl.TextCursorCursor text_cursor_get(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorGetType get_type)
   {
      Eina.Log.Debug("function efl_text_cursor_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    Efl.TextCursorCursor _ret_var = default(Efl.TextCursorCursor);
         try {
            _ret_var = ((TextCursor)wrapper).GetTextCursor( get_type);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_text_cursor_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  get_type);
      }
   }
   private efl_text_cursor_get_delegate efl_text_cursor_get_static_delegate;


    private delegate  int efl_text_cursor_position_get_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  int efl_text_cursor_position_get(System.IntPtr obj,   Efl.TextCursorCursor cur);
    private static  int cursor_position_get(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur)
   {
      Eina.Log.Debug("function efl_text_cursor_position_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                     int _ret_var = default( int);
         try {
            _ret_var = ((TextCursor)wrapper).GetCursorPosition( cur);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_text_cursor_position_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur);
      }
   }
   private efl_text_cursor_position_get_delegate efl_text_cursor_position_get_static_delegate;


    private delegate  void efl_text_cursor_position_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur,    int position);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_cursor_position_set(System.IntPtr obj,   Efl.TextCursorCursor cur,    int position);
    private static  void cursor_position_set(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur,   int position)
   {
      Eina.Log.Debug("function efl_text_cursor_position_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((TextCursor)wrapper).SetCursorPosition( cur,  position);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_text_cursor_position_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur,  position);
      }
   }
   private efl_text_cursor_position_set_delegate efl_text_cursor_position_set_static_delegate;


    private delegate Eina.Unicode efl_text_cursor_content_get_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Eina.Unicode efl_text_cursor_content_get(System.IntPtr obj,   Efl.TextCursorCursor cur);
    private static Eina.Unicode cursor_content_get(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur)
   {
      Eina.Log.Debug("function efl_text_cursor_content_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    Eina.Unicode _ret_var = default(Eina.Unicode);
         try {
            _ret_var = ((TextCursor)wrapper).GetCursorContent( cur);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_text_cursor_content_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur);
      }
   }
   private efl_text_cursor_content_get_delegate efl_text_cursor_content_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_text_cursor_geometry_get_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur,   Efl.TextCursorType ctype,   out  int cx,   out  int cy,   out  int cw,   out  int ch,   out  int cx2,   out  int cy2,   out  int cw2,   out  int ch2);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_text_cursor_geometry_get(System.IntPtr obj,   Efl.TextCursorCursor cur,   Efl.TextCursorType ctype,   out  int cx,   out  int cy,   out  int cw,   out  int ch,   out  int cx2,   out  int cy2,   out  int cw2,   out  int ch2);
    private static bool cursor_geometry_get(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur,  Efl.TextCursorType ctype,  out  int cx,  out  int cy,  out  int cw,  out  int ch,  out  int cx2,  out  int cy2,  out  int cw2,  out  int ch2)
   {
      Eina.Log.Debug("function efl_text_cursor_geometry_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                       cx = default( int);      cy = default( int);      cw = default( int);      ch = default( int);      cx2 = default( int);      cy2 = default( int);      cw2 = default( int);      ch2 = default( int);                                                                     bool _ret_var = default(bool);
         try {
            _ret_var = ((TextCursor)wrapper).GetCursorGeometry( cur,  ctype,  out cx,  out cy,  out cw,  out ch,  out cx2,  out cy2,  out cw2,  out ch2);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                                                                              return _ret_var;
      } else {
         return efl_text_cursor_geometry_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur,  ctype,  out cx,  out cy,  out cw,  out ch,  out cx2,  out cy2,  out cw2,  out ch2);
      }
   }
   private efl_text_cursor_geometry_get_delegate efl_text_cursor_geometry_get_static_delegate;


    private delegate Efl.TextCursorCursor efl_text_cursor_new_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Efl.TextCursorCursor efl_text_cursor_new(System.IntPtr obj);
    private static Efl.TextCursorCursor cursor_new(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_cursor_new was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.TextCursorCursor _ret_var = default(Efl.TextCursorCursor);
         try {
            _ret_var = ((TextCursor)wrapper).NewCursor();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_cursor_new(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_text_cursor_new_delegate efl_text_cursor_new_static_delegate;


    private delegate  void efl_text_cursor_free_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_cursor_free(System.IntPtr obj,   Efl.TextCursorCursor cur);
    private static  void cursor_free(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur)
   {
      Eina.Log.Debug("function efl_text_cursor_free was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextCursor)wrapper).CursorFree( cur);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_cursor_free(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur);
      }
   }
   private efl_text_cursor_free_delegate efl_text_cursor_free_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_text_cursor_equal_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur1,   Efl.TextCursorCursor cur2);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_text_cursor_equal(System.IntPtr obj,   Efl.TextCursorCursor cur1,   Efl.TextCursorCursor cur2);
    private static bool cursor_equal(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur1,  Efl.TextCursorCursor cur2)
   {
      Eina.Log.Debug("function efl_text_cursor_equal was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      bool _ret_var = default(bool);
         try {
            _ret_var = ((TextCursor)wrapper).CursorEqual( cur1,  cur2);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_text_cursor_equal(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur1,  cur2);
      }
   }
   private efl_text_cursor_equal_delegate efl_text_cursor_equal_static_delegate;


    private delegate  int efl_text_cursor_compare_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur1,   Efl.TextCursorCursor cur2);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  int efl_text_cursor_compare(System.IntPtr obj,   Efl.TextCursorCursor cur1,   Efl.TextCursorCursor cur2);
    private static  int cursor_compare(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur1,  Efl.TextCursorCursor cur2)
   {
      Eina.Log.Debug("function efl_text_cursor_compare was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                       int _ret_var = default( int);
         try {
            _ret_var = ((TextCursor)wrapper).CursorCompare( cur1,  cur2);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_text_cursor_compare(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur1,  cur2);
      }
   }
   private efl_text_cursor_compare_delegate efl_text_cursor_compare_static_delegate;


    private delegate  void efl_text_cursor_copy_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor dst,   Efl.TextCursorCursor src);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_cursor_copy(System.IntPtr obj,   Efl.TextCursorCursor dst,   Efl.TextCursorCursor src);
    private static  void cursor_copy(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor dst,  Efl.TextCursorCursor src)
   {
      Eina.Log.Debug("function efl_text_cursor_copy was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((TextCursor)wrapper).CursorCopy( dst,  src);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_text_cursor_copy(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  dst,  src);
      }
   }
   private efl_text_cursor_copy_delegate efl_text_cursor_copy_static_delegate;


    private delegate  void efl_text_cursor_char_next_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_cursor_char_next(System.IntPtr obj,   Efl.TextCursorCursor cur);
    private static  void cursor_char_next(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur)
   {
      Eina.Log.Debug("function efl_text_cursor_char_next was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextCursor)wrapper).CursorCharNext( cur);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_cursor_char_next(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur);
      }
   }
   private efl_text_cursor_char_next_delegate efl_text_cursor_char_next_static_delegate;


    private delegate  void efl_text_cursor_char_prev_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_cursor_char_prev(System.IntPtr obj,   Efl.TextCursorCursor cur);
    private static  void cursor_char_prev(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur)
   {
      Eina.Log.Debug("function efl_text_cursor_char_prev was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextCursor)wrapper).CursorCharPrev( cur);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_cursor_char_prev(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur);
      }
   }
   private efl_text_cursor_char_prev_delegate efl_text_cursor_char_prev_static_delegate;


    private delegate  void efl_text_cursor_cluster_next_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_cursor_cluster_next(System.IntPtr obj,   Efl.TextCursorCursor cur);
    private static  void cursor_cluster_next(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur)
   {
      Eina.Log.Debug("function efl_text_cursor_cluster_next was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextCursor)wrapper).CursorClusterNext( cur);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_cursor_cluster_next(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur);
      }
   }
   private efl_text_cursor_cluster_next_delegate efl_text_cursor_cluster_next_static_delegate;


    private delegate  void efl_text_cursor_cluster_prev_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_cursor_cluster_prev(System.IntPtr obj,   Efl.TextCursorCursor cur);
    private static  void cursor_cluster_prev(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur)
   {
      Eina.Log.Debug("function efl_text_cursor_cluster_prev was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextCursor)wrapper).CursorClusterPrev( cur);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_cursor_cluster_prev(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur);
      }
   }
   private efl_text_cursor_cluster_prev_delegate efl_text_cursor_cluster_prev_static_delegate;


    private delegate  void efl_text_cursor_paragraph_char_first_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_cursor_paragraph_char_first(System.IntPtr obj,   Efl.TextCursorCursor cur);
    private static  void cursor_paragraph_char_first(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur)
   {
      Eina.Log.Debug("function efl_text_cursor_paragraph_char_first was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextCursor)wrapper).CursorParagraphCharFirst( cur);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_cursor_paragraph_char_first(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur);
      }
   }
   private efl_text_cursor_paragraph_char_first_delegate efl_text_cursor_paragraph_char_first_static_delegate;


    private delegate  void efl_text_cursor_paragraph_char_last_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_cursor_paragraph_char_last(System.IntPtr obj,   Efl.TextCursorCursor cur);
    private static  void cursor_paragraph_char_last(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur)
   {
      Eina.Log.Debug("function efl_text_cursor_paragraph_char_last was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextCursor)wrapper).CursorParagraphCharLast( cur);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_cursor_paragraph_char_last(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur);
      }
   }
   private efl_text_cursor_paragraph_char_last_delegate efl_text_cursor_paragraph_char_last_static_delegate;


    private delegate  void efl_text_cursor_word_start_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_cursor_word_start(System.IntPtr obj,   Efl.TextCursorCursor cur);
    private static  void cursor_word_start(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur)
   {
      Eina.Log.Debug("function efl_text_cursor_word_start was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextCursor)wrapper).CursorWordStart( cur);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_cursor_word_start(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur);
      }
   }
   private efl_text_cursor_word_start_delegate efl_text_cursor_word_start_static_delegate;


    private delegate  void efl_text_cursor_word_end_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_cursor_word_end(System.IntPtr obj,   Efl.TextCursorCursor cur);
    private static  void cursor_word_end(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur)
   {
      Eina.Log.Debug("function efl_text_cursor_word_end was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextCursor)wrapper).CursorWordEnd( cur);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_cursor_word_end(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur);
      }
   }
   private efl_text_cursor_word_end_delegate efl_text_cursor_word_end_static_delegate;


    private delegate  void efl_text_cursor_line_char_first_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_cursor_line_char_first(System.IntPtr obj,   Efl.TextCursorCursor cur);
    private static  void cursor_line_char_first(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur)
   {
      Eina.Log.Debug("function efl_text_cursor_line_char_first was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextCursor)wrapper).CursorLineCharFirst( cur);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_cursor_line_char_first(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur);
      }
   }
   private efl_text_cursor_line_char_first_delegate efl_text_cursor_line_char_first_static_delegate;


    private delegate  void efl_text_cursor_line_char_last_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_cursor_line_char_last(System.IntPtr obj,   Efl.TextCursorCursor cur);
    private static  void cursor_line_char_last(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur)
   {
      Eina.Log.Debug("function efl_text_cursor_line_char_last was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextCursor)wrapper).CursorLineCharLast( cur);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_cursor_line_char_last(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur);
      }
   }
   private efl_text_cursor_line_char_last_delegate efl_text_cursor_line_char_last_static_delegate;


    private delegate  void efl_text_cursor_paragraph_first_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_cursor_paragraph_first(System.IntPtr obj,   Efl.TextCursorCursor cur);
    private static  void cursor_paragraph_first(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur)
   {
      Eina.Log.Debug("function efl_text_cursor_paragraph_first was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextCursor)wrapper).CursorParagraphFirst( cur);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_cursor_paragraph_first(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur);
      }
   }
   private efl_text_cursor_paragraph_first_delegate efl_text_cursor_paragraph_first_static_delegate;


    private delegate  void efl_text_cursor_paragraph_last_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_cursor_paragraph_last(System.IntPtr obj,   Efl.TextCursorCursor cur);
    private static  void cursor_paragraph_last(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur)
   {
      Eina.Log.Debug("function efl_text_cursor_paragraph_last was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextCursor)wrapper).CursorParagraphLast( cur);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_cursor_paragraph_last(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur);
      }
   }
   private efl_text_cursor_paragraph_last_delegate efl_text_cursor_paragraph_last_static_delegate;


    private delegate  void efl_text_cursor_paragraph_next_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_cursor_paragraph_next(System.IntPtr obj,   Efl.TextCursorCursor cur);
    private static  void cursor_paragraph_next(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur)
   {
      Eina.Log.Debug("function efl_text_cursor_paragraph_next was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextCursor)wrapper).CursorParagraphNext( cur);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_cursor_paragraph_next(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur);
      }
   }
   private efl_text_cursor_paragraph_next_delegate efl_text_cursor_paragraph_next_static_delegate;


    private delegate  void efl_text_cursor_paragraph_prev_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_cursor_paragraph_prev(System.IntPtr obj,   Efl.TextCursorCursor cur);
    private static  void cursor_paragraph_prev(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur)
   {
      Eina.Log.Debug("function efl_text_cursor_paragraph_prev was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextCursor)wrapper).CursorParagraphPrev( cur);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_cursor_paragraph_prev(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur);
      }
   }
   private efl_text_cursor_paragraph_prev_delegate efl_text_cursor_paragraph_prev_static_delegate;


    private delegate  void efl_text_cursor_line_jump_by_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur,    int by);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_cursor_line_jump_by(System.IntPtr obj,   Efl.TextCursorCursor cur,    int by);
    private static  void cursor_line_jump_by(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur,   int by)
   {
      Eina.Log.Debug("function efl_text_cursor_line_jump_by was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((TextCursor)wrapper).CursorLineJumpBy( cur,  by);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_text_cursor_line_jump_by(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur,  by);
      }
   }
   private efl_text_cursor_line_jump_by_delegate efl_text_cursor_line_jump_by_static_delegate;


    private delegate  void efl_text_cursor_coord_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur,    int x,    int y);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_cursor_coord_set(System.IntPtr obj,   Efl.TextCursorCursor cur,    int x,    int y);
    private static  void cursor_coord_set(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur,   int x,   int y)
   {
      Eina.Log.Debug("function efl_text_cursor_coord_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                        
         try {
            ((TextCursor)wrapper).SetCursorCoord( cur,  x,  y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                } else {
         efl_text_cursor_coord_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur,  x,  y);
      }
   }
   private efl_text_cursor_coord_set_delegate efl_text_cursor_coord_set_static_delegate;


    private delegate  void efl_text_cursor_cluster_coord_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur,    int x,    int y);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_cursor_cluster_coord_set(System.IntPtr obj,   Efl.TextCursorCursor cur,    int x,    int y);
    private static  void cursor_cluster_coord_set(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur,   int x,   int y)
   {
      Eina.Log.Debug("function efl_text_cursor_cluster_coord_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                        
         try {
            ((TextCursor)wrapper).SetCursorClusterCoord( cur,  x,  y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                } else {
         efl_text_cursor_cluster_coord_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur,  x,  y);
      }
   }
   private efl_text_cursor_cluster_coord_set_delegate efl_text_cursor_cluster_coord_set_static_delegate;


    private delegate  int efl_text_cursor_text_insert_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String text);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  int efl_text_cursor_text_insert(System.IntPtr obj,   Efl.TextCursorCursor cur,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String text);
    private static  int cursor_text_insert(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur,   System.String text)
   {
      Eina.Log.Debug("function efl_text_cursor_text_insert was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                       int _ret_var = default( int);
         try {
            _ret_var = ((TextCursor)wrapper).CursorTextInsert( cur,  text);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_text_cursor_text_insert(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur,  text);
      }
   }
   private efl_text_cursor_text_insert_delegate efl_text_cursor_text_insert_static_delegate;


    private delegate  void efl_text_cursor_char_delete_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_cursor_char_delete(System.IntPtr obj,   Efl.TextCursorCursor cur);
    private static  void cursor_char_delete(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur)
   {
      Eina.Log.Debug("function efl_text_cursor_char_delete was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextCursor)wrapper).CursorCharDelete( cur);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_cursor_char_delete(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur);
      }
   }
   private efl_text_cursor_char_delete_delegate efl_text_cursor_char_delete_static_delegate;
}
} 
namespace Efl { 
/// <summary>All available cursor states</summary>
public enum TextCursorGetType
{
/// <summary>Main cursor state (alias to &quot;main&quot;)</summary>
Default = 0,
/// <summary>Main cursor state</summary>
Main = 1,
/// <summary>Selection begin cursor state</summary>
SelectionBegin = 2,
/// <summary>Selection end cursor state</summary>
SelectionEnd = 3,
/// <summary>Pre-edit start cursor state</summary>
PreeditStart = 4,
/// <summary>Pre-edit end cursor state</summary>
PreeditEnd = 5,
/// <summary>User cursor state</summary>
User = 6,
/// <summary>User extra cursor state</summary>
UserExtra = 7,
}
} 
namespace Efl { 
/// <summary>Text cursor types</summary>
public enum TextCursorType
{
/// <summary>Cursor type before</summary>
Before = 0,
/// <summary>Cursor type under</summary>
Under = 1,
}
} 
