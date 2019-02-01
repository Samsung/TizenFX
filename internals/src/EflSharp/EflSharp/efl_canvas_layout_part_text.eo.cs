#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Canvas { 
/// <summary>Represents a TEXT part of a layout
/// Its lifetime is limited to one function call only, unless an extra reference is explicitly held.</summary>
[LayoutPartTextNativeInherit]
public class LayoutPartText : Efl.Canvas.LayoutPart, Efl.Eo.IWrapper,Efl.Text,Efl.TextCursor,Efl.TextFont,Efl.TextFormat,Efl.TextMarkup,Efl.TextStyle
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Canvas.LayoutPartTextNativeInherit nativeInherit = new Efl.Canvas.LayoutPartTextNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (LayoutPartText))
            return Efl.Canvas.LayoutPartTextNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   ///<summary>Delegate for function to be called from inside the native constructor.</summary>
   public new delegate void ConstructingMethod(LayoutPartText obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Edje)] internal static extern System.IntPtr
      efl_canvas_layout_part_text_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="init_cb">Delegate to call constructing methods that should be run inside the constructor.</param>
   public LayoutPartText(Efl.Object parent = null, ConstructingMethod init_cb=null) : base("LayoutPartText", efl_canvas_layout_part_text_class_get(), typeof(LayoutPartText), parent)
   {
      if (init_cb != null) {
         init_cb(this);
      }
      FinishInstantiation();
   }
   ///<summary>Internal constructor to forward the wrapper initialization to the root class.</summary>
   protected LayoutPartText(String klass_name, IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(klass_name, base_klass, managed_type, parent) {}
   ///<summary>Constructs an instance from a native pointer.</summary>
   public LayoutPartText(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static LayoutPartText static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new LayoutPartText(obj.NativeHandle);
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
   protected override void register_event_proxies()
   {
      base.register_event_proxies();
   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Edje)]
    protected static extern Efl.Canvas.LayoutPartTextExpand efl_canvas_layout_part_text_expand_get(System.IntPtr obj);
   /// <summary>Sizing policy for text parts.
   /// This will determine whether to consider height or width constraints, if text-specific behaviors occur (such as ellipsis, line-wrapping etc.</summary>
   /// <returns></returns>
   virtual public Efl.Canvas.LayoutPartTextExpand GetTextExpand() {
       var _ret_var = efl_canvas_layout_part_text_expand_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Edje)]
    protected static extern  void efl_canvas_layout_part_text_expand_set(System.IntPtr obj,   Efl.Canvas.LayoutPartTextExpand type);
   /// <summary>Sizing policy for text parts.
   /// This will determine whether to consider height or width constraints, if text-specific behaviors occur (such as ellipsis, line-wrapping etc.</summary>
   /// <param name="type"></param>
   /// <returns></returns>
   virtual public  void SetTextExpand( Efl.Canvas.LayoutPartTextExpand type) {
                         efl_canvas_layout_part_text_expand_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  type);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] protected static extern  System.String efl_text_get(System.IntPtr obj);
   /// <summary>Retrieves the text string currently being displayed by the given text object.
   /// Do not free() the return value.
   /// 
   /// See also <see cref="Efl.Text.GetText"/>.</summary>
   /// <returns>Text string to display on it.</returns>
   virtual public  System.String GetText() {
       var _ret_var = efl_text_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String text);
   /// <summary>Sets the text string to be displayed by the given text object.
   /// See also <see cref="Efl.Text.GetText"/>.</summary>
   /// <param name="text">Text string to display on it.</param>
   /// <returns></returns>
   virtual public  void SetText(  System.String text) {
                         efl_text_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  text);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern Efl.TextCursorCursor efl_text_cursor_get(System.IntPtr obj,   Efl.TextCursorGetType get_type);
   /// <summary>The object&apos;s main cursor.
   /// 1.18</summary>
   /// <param name="get_type">Cursor type
   /// 1.20</param>
   /// <returns>Text cursor object
   /// 1.20</returns>
   virtual public Efl.TextCursorCursor GetTextCursor( Efl.TextCursorGetType get_type) {
                         var _ret_var = efl_text_cursor_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  get_type);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  int efl_text_cursor_position_get(System.IntPtr obj,   Efl.TextCursorCursor cur);
   /// <summary>Cursor position
   /// 1.20</summary>
   /// <param name="cur">Cursor object
   /// 1.20</param>
   /// <returns>Cursor position
   /// 1.20</returns>
   virtual public  int GetCursorPosition( Efl.TextCursorCursor cur) {
                         var _ret_var = efl_text_cursor_position_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  cur);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_cursor_position_set(System.IntPtr obj,   Efl.TextCursorCursor cur,    int position);
   /// <summary>Cursor position
   /// 1.20</summary>
   /// <param name="cur">Cursor object
   /// 1.20</param>
   /// <param name="position">Cursor position
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetCursorPosition( Efl.TextCursorCursor cur,   int position) {
                                           efl_text_cursor_position_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  cur,  position);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern Eina.Unicode efl_text_cursor_content_get(System.IntPtr obj,   Efl.TextCursorCursor cur);
   /// <summary>The content of the cursor (the character under the cursor)
   /// 1.20</summary>
   /// <param name="cur">Cursor object
   /// 1.20</param>
   /// <returns>The unicode codepoint of the character
   /// 1.20</returns>
   virtual public Eina.Unicode GetCursorContent( Efl.TextCursorCursor cur) {
                         var _ret_var = efl_text_cursor_content_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  cur);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_text_cursor_geometry_get(System.IntPtr obj,   Efl.TextCursorCursor cur,   Efl.TextCursorType ctype,   out  int cx,   out  int cy,   out  int cw,   out  int ch,   out  int cx2,   out  int cy2,   out  int cw2,   out  int ch2);
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
   virtual public bool GetCursorGeometry( Efl.TextCursorCursor cur,  Efl.TextCursorType ctype,  out  int cx,  out  int cy,  out  int cw,  out  int ch,  out  int cx2,  out  int cy2,  out  int cw2,  out  int ch2) {
                                                                                                                                                                                           var _ret_var = efl_text_cursor_geometry_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  cur,  ctype,  out cx,  out cy,  out cw,  out ch,  out cx2,  out cy2,  out cw2,  out ch2);
      Eina.Error.RaiseIfUnhandledException();
                                                                                                                              return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern Efl.TextCursorCursor efl_text_cursor_new(System.IntPtr obj);
   /// <summary>Create new cursor
   /// 1.20</summary>
   /// <returns>Cursor object
   /// 1.20</returns>
   virtual public Efl.TextCursorCursor NewCursor() {
       var _ret_var = efl_text_cursor_new((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_cursor_free(System.IntPtr obj,   Efl.TextCursorCursor cur);
   /// <summary>Free existing cursor
   /// 1.20</summary>
   /// <param name="cur">Cursor object
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void CursorFree( Efl.TextCursorCursor cur) {
                         efl_text_cursor_free((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  cur);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_text_cursor_equal(System.IntPtr obj,   Efl.TextCursorCursor cur1,   Efl.TextCursorCursor cur2);
   /// <summary>Check if two cursors are equal
   /// 1.20</summary>
   /// <param name="cur1">Cursor 1 object
   /// 1.20</param>
   /// <param name="cur2">Cursor 2 object
   /// 1.20</param>
   /// <returns><c>true</c> if cursors are equal, <c>false</c> otherwise
   /// 1.20</returns>
   virtual public bool CursorEqual( Efl.TextCursorCursor cur1,  Efl.TextCursorCursor cur2) {
                                           var _ret_var = efl_text_cursor_equal((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  cur1,  cur2);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  int efl_text_cursor_compare(System.IntPtr obj,   Efl.TextCursorCursor cur1,   Efl.TextCursorCursor cur2);
   /// <summary>Compare two cursors
   /// 1.20</summary>
   /// <param name="cur1">Cursor 1 object
   /// 1.20</param>
   /// <param name="cur2">Cursor 2 object
   /// 1.20</param>
   /// <returns>Difference between cursors
   /// 1.20</returns>
   virtual public  int CursorCompare( Efl.TextCursorCursor cur1,  Efl.TextCursorCursor cur2) {
                                           var _ret_var = efl_text_cursor_compare((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  cur1,  cur2);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_cursor_copy(System.IntPtr obj,   Efl.TextCursorCursor dst,   Efl.TextCursorCursor src);
   /// <summary>Copy existing cursor
   /// 1.20</summary>
   /// <param name="dst">Destination cursor
   /// 1.20</param>
   /// <param name="src">Source cursor
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void CursorCopy( Efl.TextCursorCursor dst,  Efl.TextCursorCursor src) {
                                           efl_text_cursor_copy((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  dst,  src);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_cursor_char_next(System.IntPtr obj,   Efl.TextCursorCursor cur);
   /// <summary>Advances to the next character
   /// 1.20</summary>
   /// <param name="cur">Cursor object
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void CursorCharNext( Efl.TextCursorCursor cur) {
                         efl_text_cursor_char_next((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  cur);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_cursor_char_prev(System.IntPtr obj,   Efl.TextCursorCursor cur);
   /// <summary>Advances to the previous character
   /// 1.20</summary>
   /// <param name="cur">Cursor object
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void CursorCharPrev( Efl.TextCursorCursor cur) {
                         efl_text_cursor_char_prev((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  cur);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_cursor_cluster_next(System.IntPtr obj,   Efl.TextCursorCursor cur);
   /// <summary>Advances to the next grapheme cluster
   /// 1.20</summary>
   /// <param name="cur">Cursor object
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void CursorClusterNext( Efl.TextCursorCursor cur) {
                         efl_text_cursor_cluster_next((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  cur);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_cursor_cluster_prev(System.IntPtr obj,   Efl.TextCursorCursor cur);
   /// <summary>Advances to the previous grapheme cluster
   /// 1.20</summary>
   /// <param name="cur">Cursor object
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void CursorClusterPrev( Efl.TextCursorCursor cur) {
                         efl_text_cursor_cluster_prev((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  cur);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_cursor_paragraph_char_first(System.IntPtr obj,   Efl.TextCursorCursor cur);
   /// <summary>Advances to the first character in this paragraph
   /// 1.20</summary>
   /// <param name="cur">Cursor object
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void CursorParagraphCharFirst( Efl.TextCursorCursor cur) {
                         efl_text_cursor_paragraph_char_first((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  cur);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_cursor_paragraph_char_last(System.IntPtr obj,   Efl.TextCursorCursor cur);
   /// <summary>Advances to the last character in this paragraph
   /// 1.20</summary>
   /// <param name="cur">Cursor object
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void CursorParagraphCharLast( Efl.TextCursorCursor cur) {
                         efl_text_cursor_paragraph_char_last((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  cur);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_cursor_word_start(System.IntPtr obj,   Efl.TextCursorCursor cur);
   /// <summary>Advance to current word start
   /// 1.20</summary>
   /// <param name="cur">Cursor object
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void CursorWordStart( Efl.TextCursorCursor cur) {
                         efl_text_cursor_word_start((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  cur);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_cursor_word_end(System.IntPtr obj,   Efl.TextCursorCursor cur);
   /// <summary>Advance to current word end
   /// 1.20</summary>
   /// <param name="cur">Cursor object
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void CursorWordEnd( Efl.TextCursorCursor cur) {
                         efl_text_cursor_word_end((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  cur);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_cursor_line_char_first(System.IntPtr obj,   Efl.TextCursorCursor cur);
   /// <summary>Advance to current line first character
   /// 1.20</summary>
   /// <param name="cur">Cursor object
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void CursorLineCharFirst( Efl.TextCursorCursor cur) {
                         efl_text_cursor_line_char_first((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  cur);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_cursor_line_char_last(System.IntPtr obj,   Efl.TextCursorCursor cur);
   /// <summary>Advance to current line last character
   /// 1.20</summary>
   /// <param name="cur">Cursor object
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void CursorLineCharLast( Efl.TextCursorCursor cur) {
                         efl_text_cursor_line_char_last((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  cur);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_cursor_paragraph_first(System.IntPtr obj,   Efl.TextCursorCursor cur);
   /// <summary>Advance to current paragraph first character
   /// 1.20</summary>
   /// <param name="cur">Cursor object
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void CursorParagraphFirst( Efl.TextCursorCursor cur) {
                         efl_text_cursor_paragraph_first((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  cur);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_cursor_paragraph_last(System.IntPtr obj,   Efl.TextCursorCursor cur);
   /// <summary>Advance to current paragraph last character
   /// 1.20</summary>
   /// <param name="cur">Cursor object
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void CursorParagraphLast( Efl.TextCursorCursor cur) {
                         efl_text_cursor_paragraph_last((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  cur);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_cursor_paragraph_next(System.IntPtr obj,   Efl.TextCursorCursor cur);
   /// <summary>Advances to the start of the next text node
   /// 1.20</summary>
   /// <param name="cur">Cursor object
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void CursorParagraphNext( Efl.TextCursorCursor cur) {
                         efl_text_cursor_paragraph_next((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  cur);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_cursor_paragraph_prev(System.IntPtr obj,   Efl.TextCursorCursor cur);
   /// <summary>Advances to the end of the previous text node
   /// 1.20</summary>
   /// <param name="cur">Cursor object
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void CursorParagraphPrev( Efl.TextCursorCursor cur) {
                         efl_text_cursor_paragraph_prev((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  cur);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_cursor_line_jump_by(System.IntPtr obj,   Efl.TextCursorCursor cur,    int by);
   /// <summary>Jump the cursor by the given number of lines
   /// 1.20</summary>
   /// <param name="cur">Cursor object
   /// 1.20</param>
   /// <param name="by">Number of lines
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void CursorLineJumpBy( Efl.TextCursorCursor cur,   int by) {
                                           efl_text_cursor_line_jump_by((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  cur,  by);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_cursor_coord_set(System.IntPtr obj,   Efl.TextCursorCursor cur,    int x,    int y);
   /// <summary>Set cursor coordinates
   /// 1.20</summary>
   /// <param name="cur">Cursor object
   /// 1.20</param>
   /// <param name="x">X coord to set by.
   /// 1.20</param>
   /// <param name="y">Y coord to set by.
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetCursorCoord( Efl.TextCursorCursor cur,   int x,   int y) {
                                                             efl_text_cursor_coord_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  cur,  x,  y);
      Eina.Error.RaiseIfUnhandledException();
                                           }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_cursor_cluster_coord_set(System.IntPtr obj,   Efl.TextCursorCursor cur,    int x,    int y);
   /// <summary>Set cursor coordinates according to grapheme clusters. It does not allow to put a cursor to the middle of a grapheme cluster.
   /// 1.20</summary>
   /// <param name="cur">Cursor object
   /// 1.20</param>
   /// <param name="x">X coord to set by.
   /// 1.20</param>
   /// <param name="y">Y coord to set by.
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetCursorClusterCoord( Efl.TextCursorCursor cur,   int x,   int y) {
                                                             efl_text_cursor_cluster_coord_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  cur,  x,  y);
      Eina.Error.RaiseIfUnhandledException();
                                           }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  int efl_text_cursor_text_insert(System.IntPtr obj,   Efl.TextCursorCursor cur,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String text);
   /// <summary>Adds text to the current cursor position and set the cursor to *after* the start of the text just added.
   /// 1.20</summary>
   /// <param name="cur">Cursor object
   /// 1.20</param>
   /// <param name="text">Text to append (UTF-8 format).
   /// 1.20</param>
   /// <returns>Length of the appended text.
   /// 1.20</returns>
   virtual public  int CursorTextInsert( Efl.TextCursorCursor cur,   System.String text) {
                                           var _ret_var = efl_text_cursor_text_insert((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  cur,  text);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_cursor_char_delete(System.IntPtr obj,   Efl.TextCursorCursor cur);
   /// <summary>Deletes a single character from position pointed by given cursor.
   /// 1.20</summary>
   /// <param name="cur">Cursor object
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void CursorCharDelete( Efl.TextCursorCursor cur) {
                         efl_text_cursor_char_delete((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  cur);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_font_get(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  out  System.String font,   out Efl.Font.Size size);
   /// <summary>Retrieve the font family and size in use on a given text object.
   /// This function allows the font name and size of a text object to be queried. Remember that the font name string is still owned by Evas and should not have free() called on it by the caller of the function.
   /// 
   /// See also <see cref="Efl.TextFont.GetFont"/>.
   /// 1.20</summary>
   /// <param name="font">The font family name or filename.
   /// 1.20</param>
   /// <param name="size">The font size, in points.
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void GetFont( out  System.String font,  out Efl.Font.Size size) {
                                           efl_text_font_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  out font,  out size);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_font_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String font,   Efl.Font.Size size);
   /// <summary>Set the font family, filename and size for a given text object.
   /// This function allows the font name and size of a text object to be set. The font string has to follow fontconfig&apos;s convention for naming fonts, as it&apos;s the underlying library used to query system fonts by Evas (see the fc-list command&apos;s output, on your system, to get an idea). Alternatively, youe can use the full path to a font file.
   /// 
   /// See also <see cref="Efl.TextFont.GetFont"/>, <see cref="Efl.TextFont.GetFontSource"/>.
   /// 1.20</summary>
   /// <param name="font">The font family name or filename.
   /// 1.20</param>
   /// <param name="size">The font size, in points.
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetFont(  System.String font,  Efl.Font.Size size) {
                                           efl_text_font_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  font,  size);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] protected static extern  System.String efl_text_font_source_get(System.IntPtr obj);
   /// <summary>Get the font file&apos;s path which is being used on a given text object.
   /// See <see cref="Efl.TextFont.GetFont"/> for more details.
   /// 1.20</summary>
   /// <returns>The font file&apos;s path.
   /// 1.20</returns>
   virtual public  System.String GetFontSource() {
       var _ret_var = efl_text_font_source_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_font_source_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String font_source);
   /// <summary>Set the font (source) file to be used on a given text object.
   /// This function allows the font file to be explicitly set for a given text object, overriding system lookup, which will first occur in the given file&apos;s contents.
   /// 
   /// See also <see cref="Efl.TextFont.GetFont"/>.
   /// 1.20</summary>
   /// <param name="font_source">The font file&apos;s path.
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetFontSource(  System.String font_source) {
                         efl_text_font_source_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  font_source);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] protected static extern  System.String efl_text_font_fallbacks_get(System.IntPtr obj);
   /// <summary>Comma-separated list of font fallbacks
   /// Will be used in case the primary font isn&apos;t available.
   /// 1.20</summary>
   /// <returns>Font name fallbacks
   /// 1.20</returns>
   virtual public  System.String GetFontFallbacks() {
       var _ret_var = efl_text_font_fallbacks_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_font_fallbacks_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String font_fallbacks);
   /// <summary>Comma-separated list of font fallbacks
   /// Will be used in case the primary font isn&apos;t available.
   /// 1.20</summary>
   /// <param name="font_fallbacks">Font name fallbacks
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetFontFallbacks(  System.String font_fallbacks) {
                         efl_text_font_fallbacks_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  font_fallbacks);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern Efl.TextFontWeight efl_text_font_weight_get(System.IntPtr obj);
   /// <summary>Type of weight of the displayed font
   /// Default is <see cref="Efl.TextFontWeight.Normal"/>.
   /// 1.20</summary>
   /// <returns>Font weight
   /// 1.20</returns>
   virtual public Efl.TextFontWeight GetFontWeight() {
       var _ret_var = efl_text_font_weight_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_font_weight_set(System.IntPtr obj,   Efl.TextFontWeight font_weight);
   /// <summary>Type of weight of the displayed font
   /// Default is <see cref="Efl.TextFontWeight.Normal"/>.
   /// 1.20</summary>
   /// <param name="font_weight">Font weight
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetFontWeight( Efl.TextFontWeight font_weight) {
                         efl_text_font_weight_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  font_weight);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern Efl.TextFontSlant efl_text_font_slant_get(System.IntPtr obj);
   /// <summary>Type of slant of the displayed font
   /// Default is <see cref="Efl.TextFontSlant.Normal"/>.
   /// 1.20</summary>
   /// <returns>Font slant
   /// 1.20</returns>
   virtual public Efl.TextFontSlant GetFontSlant() {
       var _ret_var = efl_text_font_slant_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_font_slant_set(System.IntPtr obj,   Efl.TextFontSlant style);
   /// <summary>Type of slant of the displayed font
   /// Default is <see cref="Efl.TextFontSlant.Normal"/>.
   /// 1.20</summary>
   /// <param name="style">Font slant
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetFontSlant( Efl.TextFontSlant style) {
                         efl_text_font_slant_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  style);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern Efl.TextFontWidth efl_text_font_width_get(System.IntPtr obj);
   /// <summary>Type of width of the displayed font
   /// Default is <see cref="Efl.TextFontWidth.Normal"/>.
   /// 1.20</summary>
   /// <returns>Font width
   /// 1.20</returns>
   virtual public Efl.TextFontWidth GetFontWidth() {
       var _ret_var = efl_text_font_width_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_font_width_set(System.IntPtr obj,   Efl.TextFontWidth width);
   /// <summary>Type of width of the displayed font
   /// Default is <see cref="Efl.TextFontWidth.Normal"/>.
   /// 1.20</summary>
   /// <param name="width">Font width
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetFontWidth( Efl.TextFontWidth width) {
                         efl_text_font_width_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  width);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] protected static extern  System.String efl_text_font_lang_get(System.IntPtr obj);
   /// <summary>Specific language of the displayed font
   /// This is used to lookup fonts suitable to the specified language, as well as helping the font shaper backend. The language <c>lang</c> can be either a code e.g &quot;en_US&quot;, &quot;auto&quot; to use the system locale, or &quot;none&quot;.
   /// 1.20</summary>
   /// <returns>Language
   /// 1.20</returns>
   virtual public  System.String GetFontLang() {
       var _ret_var = efl_text_font_lang_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_font_lang_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String lang);
   /// <summary>Specific language of the displayed font
   /// This is used to lookup fonts suitable to the specified language, as well as helping the font shaper backend. The language <c>lang</c> can be either a code e.g &quot;en_US&quot;, &quot;auto&quot; to use the system locale, or &quot;none&quot;.
   /// 1.20</summary>
   /// <param name="lang">Language
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetFontLang(  System.String lang) {
                         efl_text_font_lang_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  lang);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern Efl.TextFontBitmapScalable efl_text_font_bitmap_scalable_get(System.IntPtr obj);
   /// <summary>The bitmap fonts have fixed size glyphs for several available sizes. Basically, it is not scalable. But, it needs to be scalable for some use cases. (ex. colorful emoji fonts)
   /// Default is <see cref="Efl.TextFontBitmapScalable.None"/>.
   /// 1.20</summary>
   /// <returns>Scalable
   /// 1.20</returns>
   virtual public Efl.TextFontBitmapScalable GetFontBitmapScalable() {
       var _ret_var = efl_text_font_bitmap_scalable_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_font_bitmap_scalable_set(System.IntPtr obj,   Efl.TextFontBitmapScalable scalable);
   /// <summary>The bitmap fonts have fixed size glyphs for several available sizes. Basically, it is not scalable. But, it needs to be scalable for some use cases. (ex. colorful emoji fonts)
   /// Default is <see cref="Efl.TextFontBitmapScalable.None"/>.
   /// 1.20</summary>
   /// <param name="scalable">Scalable
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetFontBitmapScalable( Efl.TextFontBitmapScalable scalable) {
                         efl_text_font_bitmap_scalable_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  scalable);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern double efl_text_ellipsis_get(System.IntPtr obj);
   /// <summary>Ellipsis value (number from -1.0 to 1.0)
   /// 1.20</summary>
   /// <returns>Ellipsis value
   /// 1.20</returns>
   virtual public double GetEllipsis() {
       var _ret_var = efl_text_ellipsis_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_ellipsis_set(System.IntPtr obj,   double value);
   /// <summary>Ellipsis value (number from -1.0 to 1.0)
   /// 1.20</summary>
   /// <param name="value">Ellipsis value
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetEllipsis( double value) {
                         efl_text_ellipsis_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  value);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern Efl.TextFormatWrap efl_text_wrap_get(System.IntPtr obj);
   /// <summary>Wrap mode for use in the text
   /// 1.20</summary>
   /// <returns>Wrap mode
   /// 1.20</returns>
   virtual public Efl.TextFormatWrap GetWrap() {
       var _ret_var = efl_text_wrap_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_wrap_set(System.IntPtr obj,   Efl.TextFormatWrap wrap);
   /// <summary>Wrap mode for use in the text
   /// 1.20</summary>
   /// <param name="wrap">Wrap mode
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetWrap( Efl.TextFormatWrap wrap) {
                         efl_text_wrap_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  wrap);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_text_multiline_get(System.IntPtr obj);
   /// <summary>Multiline is enabled or not
   /// 1.20</summary>
   /// <returns><c>true</c> if multiline is enabled, <c>false</c> otherwise
   /// 1.20</returns>
   virtual public bool GetMultiline() {
       var _ret_var = efl_text_multiline_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_multiline_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool enabled);
   /// <summary>Multiline is enabled or not
   /// 1.20</summary>
   /// <param name="enabled"><c>true</c> if multiline is enabled, <c>false</c> otherwise
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetMultiline( bool enabled) {
                         efl_text_multiline_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  enabled);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern Efl.TextFormatHorizontalAlignmentAutoType efl_text_halign_auto_type_get(System.IntPtr obj);
   /// <summary>Horizontal alignment of text
   /// 1.20</summary>
   /// <returns>Alignment type
   /// 1.20</returns>
   virtual public Efl.TextFormatHorizontalAlignmentAutoType GetHalignAutoType() {
       var _ret_var = efl_text_halign_auto_type_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_halign_auto_type_set(System.IntPtr obj,   Efl.TextFormatHorizontalAlignmentAutoType value);
   /// <summary>Horizontal alignment of text
   /// 1.20</summary>
   /// <param name="value">Alignment type
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetHalignAutoType( Efl.TextFormatHorizontalAlignmentAutoType value) {
                         efl_text_halign_auto_type_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  value);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern double efl_text_halign_get(System.IntPtr obj);
   /// <summary>Horizontal alignment of text
   /// 1.20</summary>
   /// <returns>Horizontal alignment value
   /// 1.20</returns>
   virtual public double GetHalign() {
       var _ret_var = efl_text_halign_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_halign_set(System.IntPtr obj,   double value);
   /// <summary>Horizontal alignment of text
   /// 1.20</summary>
   /// <param name="value">Horizontal alignment value
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetHalign( double value) {
                         efl_text_halign_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  value);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern double efl_text_valign_get(System.IntPtr obj);
   /// <summary>Vertical alignment of text
   /// 1.20</summary>
   /// <returns>Vertical alignment value
   /// 1.20</returns>
   virtual public double GetValign() {
       var _ret_var = efl_text_valign_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_valign_set(System.IntPtr obj,   double value);
   /// <summary>Vertical alignment of text
   /// 1.20</summary>
   /// <param name="value">Vertical alignment value
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetValign( double value) {
                         efl_text_valign_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  value);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern double efl_text_linegap_get(System.IntPtr obj);
   /// <summary>Minimal line gap (top and bottom) for each line in the text
   /// <c>value</c> is absolute size.
   /// 1.20</summary>
   /// <returns>Line gap value
   /// 1.20</returns>
   virtual public double GetLinegap() {
       var _ret_var = efl_text_linegap_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_linegap_set(System.IntPtr obj,   double value);
   /// <summary>Minimal line gap (top and bottom) for each line in the text
   /// <c>value</c> is absolute size.
   /// 1.20</summary>
   /// <param name="value">Line gap value
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetLinegap( double value) {
                         efl_text_linegap_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  value);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern double efl_text_linerelgap_get(System.IntPtr obj);
   /// <summary>Relative line gap (top and bottom) for each line in the text
   /// The original line gap value is multiplied by <c>value</c>.
   /// 1.20</summary>
   /// <returns>Relative line gap value
   /// 1.20</returns>
   virtual public double GetLinerelgap() {
       var _ret_var = efl_text_linerelgap_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_linerelgap_set(System.IntPtr obj,   double value);
   /// <summary>Relative line gap (top and bottom) for each line in the text
   /// The original line gap value is multiplied by <c>value</c>.
   /// 1.20</summary>
   /// <param name="value">Relative line gap value
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetLinerelgap( double value) {
                         efl_text_linerelgap_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  value);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  int efl_text_tabstops_get(System.IntPtr obj);
   /// <summary>Tabstops value
   /// 1.20</summary>
   /// <returns>Tapstops value
   /// 1.20</returns>
   virtual public  int GetTabstops() {
       var _ret_var = efl_text_tabstops_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_tabstops_set(System.IntPtr obj,    int value);
   /// <summary>Tabstops value
   /// 1.20</summary>
   /// <param name="value">Tapstops value
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetTabstops(  int value) {
                         efl_text_tabstops_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  value);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_text_password_get(System.IntPtr obj);
   /// <summary>Whether text is a password
   /// 1.20</summary>
   /// <returns><c>true</c> if the text is a password, <c>false</c> otherwise
   /// 1.20</returns>
   virtual public bool GetPassword() {
       var _ret_var = efl_text_password_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_password_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool enabled);
   /// <summary>Whether text is a password
   /// 1.20</summary>
   /// <param name="enabled"><c>true</c> if the text is a password, <c>false</c> otherwise
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetPassword( bool enabled) {
                         efl_text_password_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  enabled);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] protected static extern  System.String efl_text_replacement_char_get(System.IntPtr obj);
   /// <summary>The character used to replace characters that can&apos;t be displayed
   /// Currently only used to replace characters if <see cref="Efl.TextFormat.Password"/> is enabled.
   /// 1.20</summary>
   /// <returns>Replacement character
   /// 1.20</returns>
   virtual public  System.String GetReplacementChar() {
       var _ret_var = efl_text_replacement_char_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_replacement_char_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String repch);
   /// <summary>The character used to replace characters that can&apos;t be displayed
   /// Currently only used to replace characters if <see cref="Efl.TextFormat.Password"/> is enabled.
   /// 1.20</summary>
   /// <param name="repch">Replacement character
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetReplacementChar(  System.String repch) {
                         efl_text_replacement_char_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  repch);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] protected static extern  System.String efl_text_markup_get(System.IntPtr obj);
   /// <summary>Markup property
   /// 1.21</summary>
   /// <returns>The markup-text representation set to this text.
   /// 1.21</returns>
   virtual public  System.String GetMarkup() {
       var _ret_var = efl_text_markup_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_markup_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String markup);
   /// <summary>Markup property
   /// 1.21</summary>
   /// <param name="markup">The markup-text representation set to this text.
   /// 1.21</param>
   /// <returns></returns>
   virtual public  void SetMarkup(  System.String markup) {
                         efl_text_markup_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  markup);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringPassOwnershipMarshaler))] protected static extern  System.String efl_text_markup_range_get(System.IntPtr obj,   Efl.TextCursorCursor start,   Efl.TextCursorCursor end);
   /// <summary>Markup of a given range in the text
   /// 1.21</summary>
   /// <param name="start"></param>
   /// <param name="end"></param>
   /// <returns>The markup-text representation set to this text of a given range
   /// 1.21</returns>
   virtual public  System.String GetMarkupRange( Efl.TextCursorCursor start,  Efl.TextCursorCursor end) {
                                           var _ret_var = efl_text_markup_range_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  start,  end);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_markup_range_set(System.IntPtr obj,   Efl.TextCursorCursor start,   Efl.TextCursorCursor end,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringPassOwnershipMarshaler))]   System.String markup);
   /// <summary>Markup of a given range in the text
   /// 1.21</summary>
   /// <param name="start"></param>
   /// <param name="end"></param>
   /// <param name="markup">The markup-text representation set to this text of a given range
   /// 1.21</param>
   /// <returns></returns>
   virtual public  void SetMarkupRange( Efl.TextCursorCursor start,  Efl.TextCursorCursor end,   System.String markup) {
                                                             efl_text_markup_range_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  start,  end,  markup);
      Eina.Error.RaiseIfUnhandledException();
                                           }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_markup_cursor_markup_insert(System.IntPtr obj,   Efl.TextCursorCursor cur,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String markup);
   /// <summary>Inserts a markup text to the text object in a given cursor position
   /// 1.21</summary>
   /// <param name="cur">Cursor position to insert markup
   /// 1.21</param>
   /// <param name="markup">The markup text to insert
   /// 1.21</param>
   /// <returns></returns>
   virtual public  void CursorMarkupInsert( Efl.TextCursorCursor cur,   System.String markup) {
                                           efl_text_markup_cursor_markup_insert((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  cur,  markup);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_normal_color_get(System.IntPtr obj,   out  byte r,   out  byte g,   out  byte b,   out  byte a);
   /// <summary>Color of text, excluding style
   /// 1.20</summary>
   /// <param name="r">Red component
   /// 1.20</param>
   /// <param name="g">Green component
   /// 1.20</param>
   /// <param name="b">Blue component
   /// 1.20</param>
   /// <param name="a">Alpha component
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void GetNormalColor( out  byte r,  out  byte g,  out  byte b,  out  byte a) {
                                                                               efl_text_normal_color_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  out r,  out g,  out b,  out a);
      Eina.Error.RaiseIfUnhandledException();
                                                       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_normal_color_set(System.IntPtr obj,    byte r,    byte g,    byte b,    byte a);
   /// <summary>Color of text, excluding style
   /// 1.20</summary>
   /// <param name="r">Red component
   /// 1.20</param>
   /// <param name="g">Green component
   /// 1.20</param>
   /// <param name="b">Blue component
   /// 1.20</param>
   /// <param name="a">Alpha component
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetNormalColor(  byte r,   byte g,   byte b,   byte a) {
                                                                               efl_text_normal_color_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  r,  g,  b,  a);
      Eina.Error.RaiseIfUnhandledException();
                                                       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern Efl.TextStyleBackingType efl_text_backing_type_get(System.IntPtr obj);
   /// <summary>Enable or disable backing type
   /// 1.20</summary>
   /// <returns>Backing type
   /// 1.20</returns>
   virtual public Efl.TextStyleBackingType GetBackingType() {
       var _ret_var = efl_text_backing_type_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_backing_type_set(System.IntPtr obj,   Efl.TextStyleBackingType type);
   /// <summary>Enable or disable backing type
   /// 1.20</summary>
   /// <param name="type">Backing type
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetBackingType( Efl.TextStyleBackingType type) {
                         efl_text_backing_type_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  type);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_backing_color_get(System.IntPtr obj,   out  byte r,   out  byte g,   out  byte b,   out  byte a);
   /// <summary>Backing color
   /// 1.20</summary>
   /// <param name="r">Red component
   /// 1.20</param>
   /// <param name="g">Green component
   /// 1.20</param>
   /// <param name="b">Blue component
   /// 1.20</param>
   /// <param name="a">Alpha component
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void GetBackingColor( out  byte r,  out  byte g,  out  byte b,  out  byte a) {
                                                                               efl_text_backing_color_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  out r,  out g,  out b,  out a);
      Eina.Error.RaiseIfUnhandledException();
                                                       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_backing_color_set(System.IntPtr obj,    byte r,    byte g,    byte b,    byte a);
   /// <summary>Backing color
   /// 1.20</summary>
   /// <param name="r">Red component
   /// 1.20</param>
   /// <param name="g">Green component
   /// 1.20</param>
   /// <param name="b">Blue component
   /// 1.20</param>
   /// <param name="a">Alpha component
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetBackingColor(  byte r,   byte g,   byte b,   byte a) {
                                                                               efl_text_backing_color_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  r,  g,  b,  a);
      Eina.Error.RaiseIfUnhandledException();
                                                       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern Efl.TextStyleUnderlineType efl_text_underline_type_get(System.IntPtr obj);
   /// <summary>Sets an underline style on the text
   /// 1.20</summary>
   /// <returns>Underline type
   /// 1.20</returns>
   virtual public Efl.TextStyleUnderlineType GetUnderlineType() {
       var _ret_var = efl_text_underline_type_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_underline_type_set(System.IntPtr obj,   Efl.TextStyleUnderlineType type);
   /// <summary>Sets an underline style on the text
   /// 1.20</summary>
   /// <param name="type">Underline type
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetUnderlineType( Efl.TextStyleUnderlineType type) {
                         efl_text_underline_type_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  type);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_underline_color_get(System.IntPtr obj,   out  byte r,   out  byte g,   out  byte b,   out  byte a);
   /// <summary>Color of normal underline style
   /// 1.20</summary>
   /// <param name="r">Red component
   /// 1.20</param>
   /// <param name="g">Green component
   /// 1.20</param>
   /// <param name="b">Blue component
   /// 1.20</param>
   /// <param name="a">Alpha component
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void GetUnderlineColor( out  byte r,  out  byte g,  out  byte b,  out  byte a) {
                                                                               efl_text_underline_color_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  out r,  out g,  out b,  out a);
      Eina.Error.RaiseIfUnhandledException();
                                                       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_underline_color_set(System.IntPtr obj,    byte r,    byte g,    byte b,    byte a);
   /// <summary>Color of normal underline style
   /// 1.20</summary>
   /// <param name="r">Red component
   /// 1.20</param>
   /// <param name="g">Green component
   /// 1.20</param>
   /// <param name="b">Blue component
   /// 1.20</param>
   /// <param name="a">Alpha component
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetUnderlineColor(  byte r,   byte g,   byte b,   byte a) {
                                                                               efl_text_underline_color_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  r,  g,  b,  a);
      Eina.Error.RaiseIfUnhandledException();
                                                       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern double efl_text_underline_height_get(System.IntPtr obj);
   /// <summary>Height of underline style
   /// 1.20</summary>
   /// <returns>Height
   /// 1.20</returns>
   virtual public double GetUnderlineHeight() {
       var _ret_var = efl_text_underline_height_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_underline_height_set(System.IntPtr obj,   double height);
   /// <summary>Height of underline style
   /// 1.20</summary>
   /// <param name="height">Height
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetUnderlineHeight( double height) {
                         efl_text_underline_height_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  height);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_underline_dashed_color_get(System.IntPtr obj,   out  byte r,   out  byte g,   out  byte b,   out  byte a);
   /// <summary>Color of dashed underline style
   /// 1.20</summary>
   /// <param name="r">Red component
   /// 1.20</param>
   /// <param name="g">Green component
   /// 1.20</param>
   /// <param name="b">Blue component
   /// 1.20</param>
   /// <param name="a">Alpha component
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void GetUnderlineDashedColor( out  byte r,  out  byte g,  out  byte b,  out  byte a) {
                                                                               efl_text_underline_dashed_color_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  out r,  out g,  out b,  out a);
      Eina.Error.RaiseIfUnhandledException();
                                                       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_underline_dashed_color_set(System.IntPtr obj,    byte r,    byte g,    byte b,    byte a);
   /// <summary>Color of dashed underline style
   /// 1.20</summary>
   /// <param name="r">Red component
   /// 1.20</param>
   /// <param name="g">Green component
   /// 1.20</param>
   /// <param name="b">Blue component
   /// 1.20</param>
   /// <param name="a">Alpha component
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetUnderlineDashedColor(  byte r,   byte g,   byte b,   byte a) {
                                                                               efl_text_underline_dashed_color_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  r,  g,  b,  a);
      Eina.Error.RaiseIfUnhandledException();
                                                       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  int efl_text_underline_dashed_width_get(System.IntPtr obj);
   /// <summary>Width of dashed underline style
   /// 1.20</summary>
   /// <returns>Width
   /// 1.20</returns>
   virtual public  int GetUnderlineDashedWidth() {
       var _ret_var = efl_text_underline_dashed_width_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_underline_dashed_width_set(System.IntPtr obj,    int width);
   /// <summary>Width of dashed underline style
   /// 1.20</summary>
   /// <param name="width">Width
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetUnderlineDashedWidth(  int width) {
                         efl_text_underline_dashed_width_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  width);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  int efl_text_underline_dashed_gap_get(System.IntPtr obj);
   /// <summary>Gap of dashed underline style
   /// 1.20</summary>
   /// <returns>Gap
   /// 1.20</returns>
   virtual public  int GetUnderlineDashedGap() {
       var _ret_var = efl_text_underline_dashed_gap_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_underline_dashed_gap_set(System.IntPtr obj,    int gap);
   /// <summary>Gap of dashed underline style
   /// 1.20</summary>
   /// <param name="gap">Gap
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetUnderlineDashedGap(  int gap) {
                         efl_text_underline_dashed_gap_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  gap);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_underline2_color_get(System.IntPtr obj,   out  byte r,   out  byte g,   out  byte b,   out  byte a);
   /// <summary>Color of underline2 style
   /// 1.20</summary>
   /// <param name="r">Red component
   /// 1.20</param>
   /// <param name="g">Green component
   /// 1.20</param>
   /// <param name="b">Blue component
   /// 1.20</param>
   /// <param name="a">Alpha component
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void GetUnderline2Color( out  byte r,  out  byte g,  out  byte b,  out  byte a) {
                                                                               efl_text_underline2_color_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  out r,  out g,  out b,  out a);
      Eina.Error.RaiseIfUnhandledException();
                                                       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_underline2_color_set(System.IntPtr obj,    byte r,    byte g,    byte b,    byte a);
   /// <summary>Color of underline2 style
   /// 1.20</summary>
   /// <param name="r">Red component
   /// 1.20</param>
   /// <param name="g">Green component
   /// 1.20</param>
   /// <param name="b">Blue component
   /// 1.20</param>
   /// <param name="a">Alpha component
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetUnderline2Color(  byte r,   byte g,   byte b,   byte a) {
                                                                               efl_text_underline2_color_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  r,  g,  b,  a);
      Eina.Error.RaiseIfUnhandledException();
                                                       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern Efl.TextStyleStrikethroughType efl_text_strikethrough_type_get(System.IntPtr obj);
   /// <summary>Type of strikethrough style
   /// 1.20</summary>
   /// <returns>Strikethrough type
   /// 1.20</returns>
   virtual public Efl.TextStyleStrikethroughType GetStrikethroughType() {
       var _ret_var = efl_text_strikethrough_type_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_strikethrough_type_set(System.IntPtr obj,   Efl.TextStyleStrikethroughType type);
   /// <summary>Type of strikethrough style
   /// 1.20</summary>
   /// <param name="type">Strikethrough type
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetStrikethroughType( Efl.TextStyleStrikethroughType type) {
                         efl_text_strikethrough_type_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  type);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_strikethrough_color_get(System.IntPtr obj,   out  byte r,   out  byte g,   out  byte b,   out  byte a);
   /// <summary>Color of strikethrough_style
   /// 1.20</summary>
   /// <param name="r">Red component
   /// 1.20</param>
   /// <param name="g">Green component
   /// 1.20</param>
   /// <param name="b">Blue component
   /// 1.20</param>
   /// <param name="a">Alpha component
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void GetStrikethroughColor( out  byte r,  out  byte g,  out  byte b,  out  byte a) {
                                                                               efl_text_strikethrough_color_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  out r,  out g,  out b,  out a);
      Eina.Error.RaiseIfUnhandledException();
                                                       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_strikethrough_color_set(System.IntPtr obj,    byte r,    byte g,    byte b,    byte a);
   /// <summary>Color of strikethrough_style
   /// 1.20</summary>
   /// <param name="r">Red component
   /// 1.20</param>
   /// <param name="g">Green component
   /// 1.20</param>
   /// <param name="b">Blue component
   /// 1.20</param>
   /// <param name="a">Alpha component
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetStrikethroughColor(  byte r,   byte g,   byte b,   byte a) {
                                                                               efl_text_strikethrough_color_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  r,  g,  b,  a);
      Eina.Error.RaiseIfUnhandledException();
                                                       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern Efl.TextStyleEffectType efl_text_effect_type_get(System.IntPtr obj);
   /// <summary>Type of effect used for the displayed text
   /// 1.20</summary>
   /// <returns>Effect type
   /// 1.20</returns>
   virtual public Efl.TextStyleEffectType GetEffectType() {
       var _ret_var = efl_text_effect_type_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_effect_type_set(System.IntPtr obj,   Efl.TextStyleEffectType type);
   /// <summary>Type of effect used for the displayed text
   /// 1.20</summary>
   /// <param name="type">Effect type
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetEffectType( Efl.TextStyleEffectType type) {
                         efl_text_effect_type_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  type);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_outline_color_get(System.IntPtr obj,   out  byte r,   out  byte g,   out  byte b,   out  byte a);
   /// <summary>Color of outline effect
   /// 1.20</summary>
   /// <param name="r">Red component
   /// 1.20</param>
   /// <param name="g">Green component
   /// 1.20</param>
   /// <param name="b">Blue component
   /// 1.20</param>
   /// <param name="a">Alpha component
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void GetOutlineColor( out  byte r,  out  byte g,  out  byte b,  out  byte a) {
                                                                               efl_text_outline_color_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  out r,  out g,  out b,  out a);
      Eina.Error.RaiseIfUnhandledException();
                                                       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_outline_color_set(System.IntPtr obj,    byte r,    byte g,    byte b,    byte a);
   /// <summary>Color of outline effect
   /// 1.20</summary>
   /// <param name="r">Red component
   /// 1.20</param>
   /// <param name="g">Green component
   /// 1.20</param>
   /// <param name="b">Blue component
   /// 1.20</param>
   /// <param name="a">Alpha component
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetOutlineColor(  byte r,   byte g,   byte b,   byte a) {
                                                                               efl_text_outline_color_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  r,  g,  b,  a);
      Eina.Error.RaiseIfUnhandledException();
                                                       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern Efl.TextStyleShadowDirection efl_text_shadow_direction_get(System.IntPtr obj);
   /// <summary>Direction of shadow effect
   /// 1.20</summary>
   /// <returns>Shadow direction
   /// 1.20</returns>
   virtual public Efl.TextStyleShadowDirection GetShadowDirection() {
       var _ret_var = efl_text_shadow_direction_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_shadow_direction_set(System.IntPtr obj,   Efl.TextStyleShadowDirection type);
   /// <summary>Direction of shadow effect
   /// 1.20</summary>
   /// <param name="type">Shadow direction
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetShadowDirection( Efl.TextStyleShadowDirection type) {
                         efl_text_shadow_direction_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  type);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_shadow_color_get(System.IntPtr obj,   out  byte r,   out  byte g,   out  byte b,   out  byte a);
   /// <summary>Color of shadow effect
   /// 1.20</summary>
   /// <param name="r">Red component
   /// 1.20</param>
   /// <param name="g">Green component
   /// 1.20</param>
   /// <param name="b">Blue component
   /// 1.20</param>
   /// <param name="a">Alpha component
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void GetShadowColor( out  byte r,  out  byte g,  out  byte b,  out  byte a) {
                                                                               efl_text_shadow_color_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  out r,  out g,  out b,  out a);
      Eina.Error.RaiseIfUnhandledException();
                                                       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_shadow_color_set(System.IntPtr obj,    byte r,    byte g,    byte b,    byte a);
   /// <summary>Color of shadow effect
   /// 1.20</summary>
   /// <param name="r">Red component
   /// 1.20</param>
   /// <param name="g">Green component
   /// 1.20</param>
   /// <param name="b">Blue component
   /// 1.20</param>
   /// <param name="a">Alpha component
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetShadowColor(  byte r,   byte g,   byte b,   byte a) {
                                                                               efl_text_shadow_color_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  r,  g,  b,  a);
      Eina.Error.RaiseIfUnhandledException();
                                                       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_glow_color_get(System.IntPtr obj,   out  byte r,   out  byte g,   out  byte b,   out  byte a);
   /// <summary>Color of glow effect
   /// 1.20</summary>
   /// <param name="r">Red component
   /// 1.20</param>
   /// <param name="g">Green component
   /// 1.20</param>
   /// <param name="b">Blue component
   /// 1.20</param>
   /// <param name="a">Alpha component
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void GetGlowColor( out  byte r,  out  byte g,  out  byte b,  out  byte a) {
                                                                               efl_text_glow_color_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  out r,  out g,  out b,  out a);
      Eina.Error.RaiseIfUnhandledException();
                                                       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_glow_color_set(System.IntPtr obj,    byte r,    byte g,    byte b,    byte a);
   /// <summary>Color of glow effect
   /// 1.20</summary>
   /// <param name="r">Red component
   /// 1.20</param>
   /// <param name="g">Green component
   /// 1.20</param>
   /// <param name="b">Blue component
   /// 1.20</param>
   /// <param name="a">Alpha component
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetGlowColor(  byte r,   byte g,   byte b,   byte a) {
                                                                               efl_text_glow_color_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  r,  g,  b,  a);
      Eina.Error.RaiseIfUnhandledException();
                                                       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_glow2_color_get(System.IntPtr obj,   out  byte r,   out  byte g,   out  byte b,   out  byte a);
   /// <summary>Second color of the glow effect
   /// 1.20</summary>
   /// <param name="r">Red component
   /// 1.20</param>
   /// <param name="g">Green component
   /// 1.20</param>
   /// <param name="b">Blue component
   /// 1.20</param>
   /// <param name="a">Alpha component
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void GetGlow2Color( out  byte r,  out  byte g,  out  byte b,  out  byte a) {
                                                                               efl_text_glow2_color_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  out r,  out g,  out b,  out a);
      Eina.Error.RaiseIfUnhandledException();
                                                       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_glow2_color_set(System.IntPtr obj,    byte r,    byte g,    byte b,    byte a);
   /// <summary>Second color of the glow effect
   /// 1.20</summary>
   /// <param name="r">Red component
   /// 1.20</param>
   /// <param name="g">Green component
   /// 1.20</param>
   /// <param name="b">Blue component
   /// 1.20</param>
   /// <param name="a">Alpha component
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetGlow2Color(  byte r,   byte g,   byte b,   byte a) {
                                                                               efl_text_glow2_color_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  r,  g,  b,  a);
      Eina.Error.RaiseIfUnhandledException();
                                                       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] protected static extern  System.String efl_text_gfx_filter_get(System.IntPtr obj);
   /// <summary>Program that applies a special filter
   /// See <see cref="Efl.Gfx.Filter"/>.
   /// 1.20</summary>
   /// <returns>Filter code
   /// 1.20</returns>
   virtual public  System.String GetGfxFilter() {
       var _ret_var = efl_text_gfx_filter_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_gfx_filter_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String code);
   /// <summary>Program that applies a special filter
   /// See <see cref="Efl.Gfx.Filter"/>.
   /// 1.20</summary>
   /// <param name="code">Filter code
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetGfxFilter(  System.String code) {
                         efl_text_gfx_filter_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  code);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Sizing policy for text parts.
/// This will determine whether to consider height or width constraints, if text-specific behaviors occur (such as ellipsis, line-wrapping etc.</summary>
   public Efl.Canvas.LayoutPartTextExpand TextExpand {
      get { return GetTextExpand(); }
      set { SetTextExpand( value); }
   }
   /// <summary>Get the font file&apos;s path which is being used on a given text object.
/// See <see cref="Efl.TextFont.GetFont"/> for more details.
/// 1.20</summary>
   public  System.String FontSource {
      get { return GetFontSource(); }
      set { SetFontSource( value); }
   }
   /// <summary>Comma-separated list of font fallbacks
/// Will be used in case the primary font isn&apos;t available.
/// 1.20</summary>
   public  System.String FontFallbacks {
      get { return GetFontFallbacks(); }
      set { SetFontFallbacks( value); }
   }
   /// <summary>Type of weight of the displayed font
/// Default is <see cref="Efl.TextFontWeight.Normal"/>.
/// 1.20</summary>
   public Efl.TextFontWeight FontWeight {
      get { return GetFontWeight(); }
      set { SetFontWeight( value); }
   }
   /// <summary>Type of slant of the displayed font
/// Default is <see cref="Efl.TextFontSlant.Normal"/>.
/// 1.20</summary>
   public Efl.TextFontSlant FontSlant {
      get { return GetFontSlant(); }
      set { SetFontSlant( value); }
   }
   /// <summary>Type of width of the displayed font
/// Default is <see cref="Efl.TextFontWidth.Normal"/>.
/// 1.20</summary>
   public Efl.TextFontWidth FontWidth {
      get { return GetFontWidth(); }
      set { SetFontWidth( value); }
   }
   /// <summary>Specific language of the displayed font
/// This is used to lookup fonts suitable to the specified language, as well as helping the font shaper backend. The language <c>lang</c> can be either a code e.g &quot;en_US&quot;, &quot;auto&quot; to use the system locale, or &quot;none&quot;.
/// 1.20</summary>
   public  System.String FontLang {
      get { return GetFontLang(); }
      set { SetFontLang( value); }
   }
   /// <summary>The bitmap fonts have fixed size glyphs for several available sizes. Basically, it is not scalable. But, it needs to be scalable for some use cases. (ex. colorful emoji fonts)
/// Default is <see cref="Efl.TextFontBitmapScalable.None"/>.
/// 1.20</summary>
   public Efl.TextFontBitmapScalable FontBitmapScalable {
      get { return GetFontBitmapScalable(); }
      set { SetFontBitmapScalable( value); }
   }
   /// <summary>Ellipsis value (number from -1.0 to 1.0)
/// 1.20</summary>
   public double Ellipsis {
      get { return GetEllipsis(); }
      set { SetEllipsis( value); }
   }
   /// <summary>Wrap mode for use in the text
/// 1.20</summary>
   public Efl.TextFormatWrap Wrap {
      get { return GetWrap(); }
      set { SetWrap( value); }
   }
   /// <summary>Multiline is enabled or not
/// 1.20</summary>
   public bool Multiline {
      get { return GetMultiline(); }
      set { SetMultiline( value); }
   }
   /// <summary>Horizontal alignment of text
/// 1.20</summary>
   public Efl.TextFormatHorizontalAlignmentAutoType HalignAutoType {
      get { return GetHalignAutoType(); }
      set { SetHalignAutoType( value); }
   }
   /// <summary>Horizontal alignment of text
/// 1.20</summary>
   public double Halign {
      get { return GetHalign(); }
      set { SetHalign( value); }
   }
   /// <summary>Vertical alignment of text
/// 1.20</summary>
   public double Valign {
      get { return GetValign(); }
      set { SetValign( value); }
   }
   /// <summary>Minimal line gap (top and bottom) for each line in the text
/// <c>value</c> is absolute size.
/// 1.20</summary>
   public double Linegap {
      get { return GetLinegap(); }
      set { SetLinegap( value); }
   }
   /// <summary>Relative line gap (top and bottom) for each line in the text
/// The original line gap value is multiplied by <c>value</c>.
/// 1.20</summary>
   public double Linerelgap {
      get { return GetLinerelgap(); }
      set { SetLinerelgap( value); }
   }
   /// <summary>Tabstops value
/// 1.20</summary>
   public  int Tabstops {
      get { return GetTabstops(); }
      set { SetTabstops( value); }
   }
   /// <summary>Whether text is a password
/// 1.20</summary>
   public bool Password {
      get { return GetPassword(); }
      set { SetPassword( value); }
   }
   /// <summary>The character used to replace characters that can&apos;t be displayed
/// Currently only used to replace characters if <see cref="Efl.TextFormat.Password"/> is enabled.
/// 1.20</summary>
   public  System.String ReplacementChar {
      get { return GetReplacementChar(); }
      set { SetReplacementChar( value); }
   }
   /// <summary>Markup property
/// 1.21</summary>
   public  System.String Markup {
      get { return GetMarkup(); }
      set { SetMarkup( value); }
   }
   /// <summary>Enable or disable backing type
/// 1.20</summary>
   public Efl.TextStyleBackingType BackingType {
      get { return GetBackingType(); }
      set { SetBackingType( value); }
   }
   /// <summary>Sets an underline style on the text
/// 1.20</summary>
   public Efl.TextStyleUnderlineType UnderlineType {
      get { return GetUnderlineType(); }
      set { SetUnderlineType( value); }
   }
   /// <summary>Height of underline style
/// 1.20</summary>
   public double UnderlineHeight {
      get { return GetUnderlineHeight(); }
      set { SetUnderlineHeight( value); }
   }
   /// <summary>Width of dashed underline style
/// 1.20</summary>
   public  int UnderlineDashedWidth {
      get { return GetUnderlineDashedWidth(); }
      set { SetUnderlineDashedWidth( value); }
   }
   /// <summary>Gap of dashed underline style
/// 1.20</summary>
   public  int UnderlineDashedGap {
      get { return GetUnderlineDashedGap(); }
      set { SetUnderlineDashedGap( value); }
   }
   /// <summary>Type of strikethrough style
/// 1.20</summary>
   public Efl.TextStyleStrikethroughType StrikethroughType {
      get { return GetStrikethroughType(); }
      set { SetStrikethroughType( value); }
   }
   /// <summary>Type of effect used for the displayed text
/// 1.20</summary>
   public Efl.TextStyleEffectType EffectType {
      get { return GetEffectType(); }
      set { SetEffectType( value); }
   }
   /// <summary>Direction of shadow effect
/// 1.20</summary>
   public Efl.TextStyleShadowDirection ShadowDirection {
      get { return GetShadowDirection(); }
      set { SetShadowDirection( value); }
   }
   /// <summary>Program that applies a special filter
/// See <see cref="Efl.Gfx.Filter"/>.
/// 1.20</summary>
   public  System.String GfxFilter {
      get { return GetGfxFilter(); }
      set { SetGfxFilter( value); }
   }
}
public class LayoutPartTextNativeInherit : Efl.Canvas.LayoutPartNativeInherit{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_canvas_layout_part_text_expand_get_static_delegate = new efl_canvas_layout_part_text_expand_get_delegate(text_expand_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_layout_part_text_expand_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_layout_part_text_expand_get_static_delegate)});
      efl_canvas_layout_part_text_expand_set_static_delegate = new efl_canvas_layout_part_text_expand_set_delegate(text_expand_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_layout_part_text_expand_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_layout_part_text_expand_set_static_delegate)});
      efl_text_get_static_delegate = new efl_text_get_delegate(text_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_get_static_delegate)});
      efl_text_set_static_delegate = new efl_text_set_delegate(text_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_set_static_delegate)});
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
      efl_text_font_get_static_delegate = new efl_text_font_get_delegate(font_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_font_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_get_static_delegate)});
      efl_text_font_set_static_delegate = new efl_text_font_set_delegate(font_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_font_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_set_static_delegate)});
      efl_text_font_source_get_static_delegate = new efl_text_font_source_get_delegate(font_source_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_font_source_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_source_get_static_delegate)});
      efl_text_font_source_set_static_delegate = new efl_text_font_source_set_delegate(font_source_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_font_source_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_source_set_static_delegate)});
      efl_text_font_fallbacks_get_static_delegate = new efl_text_font_fallbacks_get_delegate(font_fallbacks_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_font_fallbacks_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_fallbacks_get_static_delegate)});
      efl_text_font_fallbacks_set_static_delegate = new efl_text_font_fallbacks_set_delegate(font_fallbacks_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_font_fallbacks_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_fallbacks_set_static_delegate)});
      efl_text_font_weight_get_static_delegate = new efl_text_font_weight_get_delegate(font_weight_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_font_weight_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_weight_get_static_delegate)});
      efl_text_font_weight_set_static_delegate = new efl_text_font_weight_set_delegate(font_weight_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_font_weight_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_weight_set_static_delegate)});
      efl_text_font_slant_get_static_delegate = new efl_text_font_slant_get_delegate(font_slant_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_font_slant_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_slant_get_static_delegate)});
      efl_text_font_slant_set_static_delegate = new efl_text_font_slant_set_delegate(font_slant_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_font_slant_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_slant_set_static_delegate)});
      efl_text_font_width_get_static_delegate = new efl_text_font_width_get_delegate(font_width_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_font_width_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_width_get_static_delegate)});
      efl_text_font_width_set_static_delegate = new efl_text_font_width_set_delegate(font_width_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_font_width_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_width_set_static_delegate)});
      efl_text_font_lang_get_static_delegate = new efl_text_font_lang_get_delegate(font_lang_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_font_lang_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_lang_get_static_delegate)});
      efl_text_font_lang_set_static_delegate = new efl_text_font_lang_set_delegate(font_lang_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_font_lang_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_lang_set_static_delegate)});
      efl_text_font_bitmap_scalable_get_static_delegate = new efl_text_font_bitmap_scalable_get_delegate(font_bitmap_scalable_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_font_bitmap_scalable_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_bitmap_scalable_get_static_delegate)});
      efl_text_font_bitmap_scalable_set_static_delegate = new efl_text_font_bitmap_scalable_set_delegate(font_bitmap_scalable_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_font_bitmap_scalable_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_bitmap_scalable_set_static_delegate)});
      efl_text_ellipsis_get_static_delegate = new efl_text_ellipsis_get_delegate(ellipsis_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_ellipsis_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_ellipsis_get_static_delegate)});
      efl_text_ellipsis_set_static_delegate = new efl_text_ellipsis_set_delegate(ellipsis_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_ellipsis_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_ellipsis_set_static_delegate)});
      efl_text_wrap_get_static_delegate = new efl_text_wrap_get_delegate(wrap_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_wrap_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_wrap_get_static_delegate)});
      efl_text_wrap_set_static_delegate = new efl_text_wrap_set_delegate(wrap_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_wrap_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_wrap_set_static_delegate)});
      efl_text_multiline_get_static_delegate = new efl_text_multiline_get_delegate(multiline_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_multiline_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_multiline_get_static_delegate)});
      efl_text_multiline_set_static_delegate = new efl_text_multiline_set_delegate(multiline_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_multiline_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_multiline_set_static_delegate)});
      efl_text_halign_auto_type_get_static_delegate = new efl_text_halign_auto_type_get_delegate(halign_auto_type_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_halign_auto_type_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_halign_auto_type_get_static_delegate)});
      efl_text_halign_auto_type_set_static_delegate = new efl_text_halign_auto_type_set_delegate(halign_auto_type_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_halign_auto_type_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_halign_auto_type_set_static_delegate)});
      efl_text_halign_get_static_delegate = new efl_text_halign_get_delegate(halign_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_halign_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_halign_get_static_delegate)});
      efl_text_halign_set_static_delegate = new efl_text_halign_set_delegate(halign_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_halign_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_halign_set_static_delegate)});
      efl_text_valign_get_static_delegate = new efl_text_valign_get_delegate(valign_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_valign_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_valign_get_static_delegate)});
      efl_text_valign_set_static_delegate = new efl_text_valign_set_delegate(valign_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_valign_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_valign_set_static_delegate)});
      efl_text_linegap_get_static_delegate = new efl_text_linegap_get_delegate(linegap_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_linegap_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_linegap_get_static_delegate)});
      efl_text_linegap_set_static_delegate = new efl_text_linegap_set_delegate(linegap_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_linegap_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_linegap_set_static_delegate)});
      efl_text_linerelgap_get_static_delegate = new efl_text_linerelgap_get_delegate(linerelgap_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_linerelgap_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_linerelgap_get_static_delegate)});
      efl_text_linerelgap_set_static_delegate = new efl_text_linerelgap_set_delegate(linerelgap_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_linerelgap_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_linerelgap_set_static_delegate)});
      efl_text_tabstops_get_static_delegate = new efl_text_tabstops_get_delegate(tabstops_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_tabstops_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_tabstops_get_static_delegate)});
      efl_text_tabstops_set_static_delegate = new efl_text_tabstops_set_delegate(tabstops_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_tabstops_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_tabstops_set_static_delegate)});
      efl_text_password_get_static_delegate = new efl_text_password_get_delegate(password_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_password_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_password_get_static_delegate)});
      efl_text_password_set_static_delegate = new efl_text_password_set_delegate(password_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_password_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_password_set_static_delegate)});
      efl_text_replacement_char_get_static_delegate = new efl_text_replacement_char_get_delegate(replacement_char_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_replacement_char_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_replacement_char_get_static_delegate)});
      efl_text_replacement_char_set_static_delegate = new efl_text_replacement_char_set_delegate(replacement_char_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_replacement_char_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_replacement_char_set_static_delegate)});
      efl_text_markup_get_static_delegate = new efl_text_markup_get_delegate(markup_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_markup_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_markup_get_static_delegate)});
      efl_text_markup_set_static_delegate = new efl_text_markup_set_delegate(markup_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_markup_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_markup_set_static_delegate)});
      efl_text_markup_range_get_static_delegate = new efl_text_markup_range_get_delegate(markup_range_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_markup_range_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_markup_range_get_static_delegate)});
      efl_text_markup_range_set_static_delegate = new efl_text_markup_range_set_delegate(markup_range_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_markup_range_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_markup_range_set_static_delegate)});
      efl_text_markup_cursor_markup_insert_static_delegate = new efl_text_markup_cursor_markup_insert_delegate(cursor_markup_insert);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_markup_cursor_markup_insert"), func = Marshal.GetFunctionPointerForDelegate(efl_text_markup_cursor_markup_insert_static_delegate)});
      efl_text_normal_color_get_static_delegate = new efl_text_normal_color_get_delegate(normal_color_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_normal_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_normal_color_get_static_delegate)});
      efl_text_normal_color_set_static_delegate = new efl_text_normal_color_set_delegate(normal_color_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_normal_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_normal_color_set_static_delegate)});
      efl_text_backing_type_get_static_delegate = new efl_text_backing_type_get_delegate(backing_type_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_backing_type_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_backing_type_get_static_delegate)});
      efl_text_backing_type_set_static_delegate = new efl_text_backing_type_set_delegate(backing_type_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_backing_type_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_backing_type_set_static_delegate)});
      efl_text_backing_color_get_static_delegate = new efl_text_backing_color_get_delegate(backing_color_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_backing_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_backing_color_get_static_delegate)});
      efl_text_backing_color_set_static_delegate = new efl_text_backing_color_set_delegate(backing_color_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_backing_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_backing_color_set_static_delegate)});
      efl_text_underline_type_get_static_delegate = new efl_text_underline_type_get_delegate(underline_type_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_underline_type_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_type_get_static_delegate)});
      efl_text_underline_type_set_static_delegate = new efl_text_underline_type_set_delegate(underline_type_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_underline_type_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_type_set_static_delegate)});
      efl_text_underline_color_get_static_delegate = new efl_text_underline_color_get_delegate(underline_color_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_underline_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_color_get_static_delegate)});
      efl_text_underline_color_set_static_delegate = new efl_text_underline_color_set_delegate(underline_color_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_underline_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_color_set_static_delegate)});
      efl_text_underline_height_get_static_delegate = new efl_text_underline_height_get_delegate(underline_height_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_underline_height_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_height_get_static_delegate)});
      efl_text_underline_height_set_static_delegate = new efl_text_underline_height_set_delegate(underline_height_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_underline_height_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_height_set_static_delegate)});
      efl_text_underline_dashed_color_get_static_delegate = new efl_text_underline_dashed_color_get_delegate(underline_dashed_color_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_underline_dashed_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_dashed_color_get_static_delegate)});
      efl_text_underline_dashed_color_set_static_delegate = new efl_text_underline_dashed_color_set_delegate(underline_dashed_color_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_underline_dashed_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_dashed_color_set_static_delegate)});
      efl_text_underline_dashed_width_get_static_delegate = new efl_text_underline_dashed_width_get_delegate(underline_dashed_width_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_underline_dashed_width_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_dashed_width_get_static_delegate)});
      efl_text_underline_dashed_width_set_static_delegate = new efl_text_underline_dashed_width_set_delegate(underline_dashed_width_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_underline_dashed_width_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_dashed_width_set_static_delegate)});
      efl_text_underline_dashed_gap_get_static_delegate = new efl_text_underline_dashed_gap_get_delegate(underline_dashed_gap_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_underline_dashed_gap_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_dashed_gap_get_static_delegate)});
      efl_text_underline_dashed_gap_set_static_delegate = new efl_text_underline_dashed_gap_set_delegate(underline_dashed_gap_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_underline_dashed_gap_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_dashed_gap_set_static_delegate)});
      efl_text_underline2_color_get_static_delegate = new efl_text_underline2_color_get_delegate(underline2_color_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_underline2_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline2_color_get_static_delegate)});
      efl_text_underline2_color_set_static_delegate = new efl_text_underline2_color_set_delegate(underline2_color_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_underline2_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline2_color_set_static_delegate)});
      efl_text_strikethrough_type_get_static_delegate = new efl_text_strikethrough_type_get_delegate(strikethrough_type_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_strikethrough_type_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_strikethrough_type_get_static_delegate)});
      efl_text_strikethrough_type_set_static_delegate = new efl_text_strikethrough_type_set_delegate(strikethrough_type_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_strikethrough_type_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_strikethrough_type_set_static_delegate)});
      efl_text_strikethrough_color_get_static_delegate = new efl_text_strikethrough_color_get_delegate(strikethrough_color_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_strikethrough_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_strikethrough_color_get_static_delegate)});
      efl_text_strikethrough_color_set_static_delegate = new efl_text_strikethrough_color_set_delegate(strikethrough_color_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_strikethrough_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_strikethrough_color_set_static_delegate)});
      efl_text_effect_type_get_static_delegate = new efl_text_effect_type_get_delegate(effect_type_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_effect_type_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_effect_type_get_static_delegate)});
      efl_text_effect_type_set_static_delegate = new efl_text_effect_type_set_delegate(effect_type_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_effect_type_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_effect_type_set_static_delegate)});
      efl_text_outline_color_get_static_delegate = new efl_text_outline_color_get_delegate(outline_color_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_outline_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_outline_color_get_static_delegate)});
      efl_text_outline_color_set_static_delegate = new efl_text_outline_color_set_delegate(outline_color_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_outline_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_outline_color_set_static_delegate)});
      efl_text_shadow_direction_get_static_delegate = new efl_text_shadow_direction_get_delegate(shadow_direction_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_shadow_direction_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_shadow_direction_get_static_delegate)});
      efl_text_shadow_direction_set_static_delegate = new efl_text_shadow_direction_set_delegate(shadow_direction_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_shadow_direction_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_shadow_direction_set_static_delegate)});
      efl_text_shadow_color_get_static_delegate = new efl_text_shadow_color_get_delegate(shadow_color_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_shadow_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_shadow_color_get_static_delegate)});
      efl_text_shadow_color_set_static_delegate = new efl_text_shadow_color_set_delegate(shadow_color_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_shadow_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_shadow_color_set_static_delegate)});
      efl_text_glow_color_get_static_delegate = new efl_text_glow_color_get_delegate(glow_color_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_glow_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_glow_color_get_static_delegate)});
      efl_text_glow_color_set_static_delegate = new efl_text_glow_color_set_delegate(glow_color_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_glow_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_glow_color_set_static_delegate)});
      efl_text_glow2_color_get_static_delegate = new efl_text_glow2_color_get_delegate(glow2_color_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_glow2_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_glow2_color_get_static_delegate)});
      efl_text_glow2_color_set_static_delegate = new efl_text_glow2_color_set_delegate(glow2_color_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_glow2_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_glow2_color_set_static_delegate)});
      efl_text_gfx_filter_get_static_delegate = new efl_text_gfx_filter_get_delegate(gfx_filter_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_gfx_filter_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_gfx_filter_get_static_delegate)});
      efl_text_gfx_filter_set_static_delegate = new efl_text_gfx_filter_set_delegate(gfx_filter_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_gfx_filter_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_gfx_filter_set_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Canvas.LayoutPartText.efl_canvas_layout_part_text_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Canvas.LayoutPartText.efl_canvas_layout_part_text_class_get();
   }


    private delegate Efl.Canvas.LayoutPartTextExpand efl_canvas_layout_part_text_expand_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Edje)]  private static extern Efl.Canvas.LayoutPartTextExpand efl_canvas_layout_part_text_expand_get(System.IntPtr obj);
    private static Efl.Canvas.LayoutPartTextExpand text_expand_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_canvas_layout_part_text_expand_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Canvas.LayoutPartTextExpand _ret_var = default(Efl.Canvas.LayoutPartTextExpand);
         try {
            _ret_var = ((LayoutPartText)wrapper).GetTextExpand();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_canvas_layout_part_text_expand_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_canvas_layout_part_text_expand_get_delegate efl_canvas_layout_part_text_expand_get_static_delegate;


    private delegate  void efl_canvas_layout_part_text_expand_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Canvas.LayoutPartTextExpand type);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Edje)]  private static extern  void efl_canvas_layout_part_text_expand_set(System.IntPtr obj,   Efl.Canvas.LayoutPartTextExpand type);
    private static  void text_expand_set(System.IntPtr obj, System.IntPtr pd,  Efl.Canvas.LayoutPartTextExpand type)
   {
      Eina.Log.Debug("function efl_canvas_layout_part_text_expand_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((LayoutPartText)wrapper).SetTextExpand( type);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_canvas_layout_part_text_expand_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  type);
      }
   }
   private efl_canvas_layout_part_text_expand_set_delegate efl_canvas_layout_part_text_expand_set_static_delegate;


    private delegate  System.IntPtr efl_text_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  System.IntPtr efl_text_get(System.IntPtr obj);
    private static  System.IntPtr text_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((LayoutPartText)wrapper).GetText();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Efl.Eo.Globals.cached_string_to_intptr(((LayoutPartText)wrapper).cached_strings, _ret_var);
      } else {
         return efl_text_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_text_get_delegate efl_text_get_static_delegate;


    private delegate  void efl_text_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String text);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String text);
    private static  void text_set(System.IntPtr obj, System.IntPtr pd,   System.String text)
   {
      Eina.Log.Debug("function efl_text_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((LayoutPartText)wrapper).SetText( text);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  text);
      }
   }
   private efl_text_set_delegate efl_text_set_static_delegate;


    private delegate Efl.TextCursorCursor efl_text_cursor_get_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorGetType get_type);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Efl.TextCursorCursor efl_text_cursor_get(System.IntPtr obj,   Efl.TextCursorGetType get_type);
    private static Efl.TextCursorCursor text_cursor_get(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorGetType get_type)
   {
      Eina.Log.Debug("function efl_text_cursor_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    Efl.TextCursorCursor _ret_var = default(Efl.TextCursorCursor);
         try {
            _ret_var = ((LayoutPartText)wrapper).GetTextCursor( get_type);
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
            _ret_var = ((LayoutPartText)wrapper).GetCursorPosition( cur);
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
            ((LayoutPartText)wrapper).SetCursorPosition( cur,  position);
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
            _ret_var = ((LayoutPartText)wrapper).GetCursorContent( cur);
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
            _ret_var = ((LayoutPartText)wrapper).GetCursorGeometry( cur,  ctype,  out cx,  out cy,  out cw,  out ch,  out cx2,  out cy2,  out cw2,  out ch2);
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
            _ret_var = ((LayoutPartText)wrapper).NewCursor();
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
            ((LayoutPartText)wrapper).CursorFree( cur);
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
            _ret_var = ((LayoutPartText)wrapper).CursorEqual( cur1,  cur2);
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
            _ret_var = ((LayoutPartText)wrapper).CursorCompare( cur1,  cur2);
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
            ((LayoutPartText)wrapper).CursorCopy( dst,  src);
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
            ((LayoutPartText)wrapper).CursorCharNext( cur);
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
            ((LayoutPartText)wrapper).CursorCharPrev( cur);
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
            ((LayoutPartText)wrapper).CursorClusterNext( cur);
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
            ((LayoutPartText)wrapper).CursorClusterPrev( cur);
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
            ((LayoutPartText)wrapper).CursorParagraphCharFirst( cur);
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
            ((LayoutPartText)wrapper).CursorParagraphCharLast( cur);
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
            ((LayoutPartText)wrapper).CursorWordStart( cur);
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
            ((LayoutPartText)wrapper).CursorWordEnd( cur);
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
            ((LayoutPartText)wrapper).CursorLineCharFirst( cur);
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
            ((LayoutPartText)wrapper).CursorLineCharLast( cur);
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
            ((LayoutPartText)wrapper).CursorParagraphFirst( cur);
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
            ((LayoutPartText)wrapper).CursorParagraphLast( cur);
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
            ((LayoutPartText)wrapper).CursorParagraphNext( cur);
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
            ((LayoutPartText)wrapper).CursorParagraphPrev( cur);
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
            ((LayoutPartText)wrapper).CursorLineJumpBy( cur,  by);
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
            ((LayoutPartText)wrapper).SetCursorCoord( cur,  x,  y);
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
            ((LayoutPartText)wrapper).SetCursorClusterCoord( cur,  x,  y);
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
            _ret_var = ((LayoutPartText)wrapper).CursorTextInsert( cur,  text);
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
            ((LayoutPartText)wrapper).CursorCharDelete( cur);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_cursor_char_delete(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur);
      }
   }
   private efl_text_cursor_char_delete_delegate efl_text_cursor_char_delete_static_delegate;


    private delegate  void efl_text_font_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  System.IntPtr font,   out Efl.Font.Size size);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_font_get(System.IntPtr obj,   out  System.IntPtr font,   out Efl.Font.Size size);
    private static  void font_get(System.IntPtr obj, System.IntPtr pd,  out  System.IntPtr font,  out Efl.Font.Size size)
   {
      Eina.Log.Debug("function efl_text_font_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                            System.String _out_font = default( System.String);
      size = default(Efl.Font.Size);                     
         try {
            ((LayoutPartText)wrapper).GetFont( out _out_font,  out size);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      font= Efl.Eo.Globals.cached_string_to_intptr(((LayoutPartText)wrapper).cached_strings, _out_font);
                              } else {
         efl_text_font_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out font,  out size);
      }
   }
   private efl_text_font_get_delegate efl_text_font_get_static_delegate;


    private delegate  void efl_text_font_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String font,   Efl.Font.Size size);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_font_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String font,   Efl.Font.Size size);
    private static  void font_set(System.IntPtr obj, System.IntPtr pd,   System.String font,  Efl.Font.Size size)
   {
      Eina.Log.Debug("function efl_text_font_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((LayoutPartText)wrapper).SetFont( font,  size);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_text_font_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  font,  size);
      }
   }
   private efl_text_font_set_delegate efl_text_font_set_static_delegate;


    private delegate  System.IntPtr efl_text_font_source_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  System.IntPtr efl_text_font_source_get(System.IntPtr obj);
    private static  System.IntPtr font_source_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_font_source_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((LayoutPartText)wrapper).GetFontSource();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Efl.Eo.Globals.cached_string_to_intptr(((LayoutPartText)wrapper).cached_strings, _ret_var);
      } else {
         return efl_text_font_source_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_text_font_source_get_delegate efl_text_font_source_get_static_delegate;


    private delegate  void efl_text_font_source_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String font_source);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_font_source_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String font_source);
    private static  void font_source_set(System.IntPtr obj, System.IntPtr pd,   System.String font_source)
   {
      Eina.Log.Debug("function efl_text_font_source_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((LayoutPartText)wrapper).SetFontSource( font_source);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_font_source_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  font_source);
      }
   }
   private efl_text_font_source_set_delegate efl_text_font_source_set_static_delegate;


    private delegate  System.IntPtr efl_text_font_fallbacks_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  System.IntPtr efl_text_font_fallbacks_get(System.IntPtr obj);
    private static  System.IntPtr font_fallbacks_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_font_fallbacks_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((LayoutPartText)wrapper).GetFontFallbacks();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Efl.Eo.Globals.cached_string_to_intptr(((LayoutPartText)wrapper).cached_strings, _ret_var);
      } else {
         return efl_text_font_fallbacks_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_text_font_fallbacks_get_delegate efl_text_font_fallbacks_get_static_delegate;


    private delegate  void efl_text_font_fallbacks_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String font_fallbacks);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_font_fallbacks_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String font_fallbacks);
    private static  void font_fallbacks_set(System.IntPtr obj, System.IntPtr pd,   System.String font_fallbacks)
   {
      Eina.Log.Debug("function efl_text_font_fallbacks_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((LayoutPartText)wrapper).SetFontFallbacks( font_fallbacks);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_font_fallbacks_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  font_fallbacks);
      }
   }
   private efl_text_font_fallbacks_set_delegate efl_text_font_fallbacks_set_static_delegate;


    private delegate Efl.TextFontWeight efl_text_font_weight_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Efl.TextFontWeight efl_text_font_weight_get(System.IntPtr obj);
    private static Efl.TextFontWeight font_weight_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_font_weight_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.TextFontWeight _ret_var = default(Efl.TextFontWeight);
         try {
            _ret_var = ((LayoutPartText)wrapper).GetFontWeight();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_font_weight_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_text_font_weight_get_delegate efl_text_font_weight_get_static_delegate;


    private delegate  void efl_text_font_weight_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextFontWeight font_weight);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_font_weight_set(System.IntPtr obj,   Efl.TextFontWeight font_weight);
    private static  void font_weight_set(System.IntPtr obj, System.IntPtr pd,  Efl.TextFontWeight font_weight)
   {
      Eina.Log.Debug("function efl_text_font_weight_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((LayoutPartText)wrapper).SetFontWeight( font_weight);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_font_weight_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  font_weight);
      }
   }
   private efl_text_font_weight_set_delegate efl_text_font_weight_set_static_delegate;


    private delegate Efl.TextFontSlant efl_text_font_slant_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Efl.TextFontSlant efl_text_font_slant_get(System.IntPtr obj);
    private static Efl.TextFontSlant font_slant_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_font_slant_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.TextFontSlant _ret_var = default(Efl.TextFontSlant);
         try {
            _ret_var = ((LayoutPartText)wrapper).GetFontSlant();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_font_slant_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_text_font_slant_get_delegate efl_text_font_slant_get_static_delegate;


    private delegate  void efl_text_font_slant_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextFontSlant style);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_font_slant_set(System.IntPtr obj,   Efl.TextFontSlant style);
    private static  void font_slant_set(System.IntPtr obj, System.IntPtr pd,  Efl.TextFontSlant style)
   {
      Eina.Log.Debug("function efl_text_font_slant_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((LayoutPartText)wrapper).SetFontSlant( style);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_font_slant_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  style);
      }
   }
   private efl_text_font_slant_set_delegate efl_text_font_slant_set_static_delegate;


    private delegate Efl.TextFontWidth efl_text_font_width_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Efl.TextFontWidth efl_text_font_width_get(System.IntPtr obj);
    private static Efl.TextFontWidth font_width_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_font_width_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.TextFontWidth _ret_var = default(Efl.TextFontWidth);
         try {
            _ret_var = ((LayoutPartText)wrapper).GetFontWidth();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_font_width_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_text_font_width_get_delegate efl_text_font_width_get_static_delegate;


    private delegate  void efl_text_font_width_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextFontWidth width);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_font_width_set(System.IntPtr obj,   Efl.TextFontWidth width);
    private static  void font_width_set(System.IntPtr obj, System.IntPtr pd,  Efl.TextFontWidth width)
   {
      Eina.Log.Debug("function efl_text_font_width_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((LayoutPartText)wrapper).SetFontWidth( width);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_font_width_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  width);
      }
   }
   private efl_text_font_width_set_delegate efl_text_font_width_set_static_delegate;


    private delegate  System.IntPtr efl_text_font_lang_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  System.IntPtr efl_text_font_lang_get(System.IntPtr obj);
    private static  System.IntPtr font_lang_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_font_lang_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((LayoutPartText)wrapper).GetFontLang();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Efl.Eo.Globals.cached_string_to_intptr(((LayoutPartText)wrapper).cached_strings, _ret_var);
      } else {
         return efl_text_font_lang_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_text_font_lang_get_delegate efl_text_font_lang_get_static_delegate;


    private delegate  void efl_text_font_lang_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String lang);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_font_lang_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String lang);
    private static  void font_lang_set(System.IntPtr obj, System.IntPtr pd,   System.String lang)
   {
      Eina.Log.Debug("function efl_text_font_lang_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((LayoutPartText)wrapper).SetFontLang( lang);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_font_lang_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  lang);
      }
   }
   private efl_text_font_lang_set_delegate efl_text_font_lang_set_static_delegate;


    private delegate Efl.TextFontBitmapScalable efl_text_font_bitmap_scalable_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Efl.TextFontBitmapScalable efl_text_font_bitmap_scalable_get(System.IntPtr obj);
    private static Efl.TextFontBitmapScalable font_bitmap_scalable_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_font_bitmap_scalable_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.TextFontBitmapScalable _ret_var = default(Efl.TextFontBitmapScalable);
         try {
            _ret_var = ((LayoutPartText)wrapper).GetFontBitmapScalable();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_font_bitmap_scalable_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_text_font_bitmap_scalable_get_delegate efl_text_font_bitmap_scalable_get_static_delegate;


    private delegate  void efl_text_font_bitmap_scalable_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextFontBitmapScalable scalable);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_font_bitmap_scalable_set(System.IntPtr obj,   Efl.TextFontBitmapScalable scalable);
    private static  void font_bitmap_scalable_set(System.IntPtr obj, System.IntPtr pd,  Efl.TextFontBitmapScalable scalable)
   {
      Eina.Log.Debug("function efl_text_font_bitmap_scalable_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((LayoutPartText)wrapper).SetFontBitmapScalable( scalable);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_font_bitmap_scalable_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  scalable);
      }
   }
   private efl_text_font_bitmap_scalable_set_delegate efl_text_font_bitmap_scalable_set_static_delegate;


    private delegate double efl_text_ellipsis_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern double efl_text_ellipsis_get(System.IntPtr obj);
    private static double ellipsis_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_ellipsis_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  double _ret_var = default(double);
         try {
            _ret_var = ((LayoutPartText)wrapper).GetEllipsis();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_ellipsis_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_text_ellipsis_get_delegate efl_text_ellipsis_get_static_delegate;


    private delegate  void efl_text_ellipsis_set_delegate(System.IntPtr obj, System.IntPtr pd,   double value);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_ellipsis_set(System.IntPtr obj,   double value);
    private static  void ellipsis_set(System.IntPtr obj, System.IntPtr pd,  double value)
   {
      Eina.Log.Debug("function efl_text_ellipsis_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((LayoutPartText)wrapper).SetEllipsis( value);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_ellipsis_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  value);
      }
   }
   private efl_text_ellipsis_set_delegate efl_text_ellipsis_set_static_delegate;


    private delegate Efl.TextFormatWrap efl_text_wrap_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Efl.TextFormatWrap efl_text_wrap_get(System.IntPtr obj);
    private static Efl.TextFormatWrap wrap_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_wrap_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.TextFormatWrap _ret_var = default(Efl.TextFormatWrap);
         try {
            _ret_var = ((LayoutPartText)wrapper).GetWrap();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_wrap_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_text_wrap_get_delegate efl_text_wrap_get_static_delegate;


    private delegate  void efl_text_wrap_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextFormatWrap wrap);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_wrap_set(System.IntPtr obj,   Efl.TextFormatWrap wrap);
    private static  void wrap_set(System.IntPtr obj, System.IntPtr pd,  Efl.TextFormatWrap wrap)
   {
      Eina.Log.Debug("function efl_text_wrap_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((LayoutPartText)wrapper).SetWrap( wrap);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_wrap_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  wrap);
      }
   }
   private efl_text_wrap_set_delegate efl_text_wrap_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_text_multiline_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_text_multiline_get(System.IntPtr obj);
    private static bool multiline_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_multiline_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((LayoutPartText)wrapper).GetMultiline();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_multiline_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_text_multiline_get_delegate efl_text_multiline_get_static_delegate;


    private delegate  void efl_text_multiline_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool enabled);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_multiline_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool enabled);
    private static  void multiline_set(System.IntPtr obj, System.IntPtr pd,  bool enabled)
   {
      Eina.Log.Debug("function efl_text_multiline_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((LayoutPartText)wrapper).SetMultiline( enabled);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_multiline_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  enabled);
      }
   }
   private efl_text_multiline_set_delegate efl_text_multiline_set_static_delegate;


    private delegate Efl.TextFormatHorizontalAlignmentAutoType efl_text_halign_auto_type_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Efl.TextFormatHorizontalAlignmentAutoType efl_text_halign_auto_type_get(System.IntPtr obj);
    private static Efl.TextFormatHorizontalAlignmentAutoType halign_auto_type_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_halign_auto_type_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.TextFormatHorizontalAlignmentAutoType _ret_var = default(Efl.TextFormatHorizontalAlignmentAutoType);
         try {
            _ret_var = ((LayoutPartText)wrapper).GetHalignAutoType();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_halign_auto_type_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_text_halign_auto_type_get_delegate efl_text_halign_auto_type_get_static_delegate;


    private delegate  void efl_text_halign_auto_type_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextFormatHorizontalAlignmentAutoType value);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_halign_auto_type_set(System.IntPtr obj,   Efl.TextFormatHorizontalAlignmentAutoType value);
    private static  void halign_auto_type_set(System.IntPtr obj, System.IntPtr pd,  Efl.TextFormatHorizontalAlignmentAutoType value)
   {
      Eina.Log.Debug("function efl_text_halign_auto_type_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((LayoutPartText)wrapper).SetHalignAutoType( value);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_halign_auto_type_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  value);
      }
   }
   private efl_text_halign_auto_type_set_delegate efl_text_halign_auto_type_set_static_delegate;


    private delegate double efl_text_halign_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern double efl_text_halign_get(System.IntPtr obj);
    private static double halign_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_halign_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  double _ret_var = default(double);
         try {
            _ret_var = ((LayoutPartText)wrapper).GetHalign();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_halign_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_text_halign_get_delegate efl_text_halign_get_static_delegate;


    private delegate  void efl_text_halign_set_delegate(System.IntPtr obj, System.IntPtr pd,   double value);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_halign_set(System.IntPtr obj,   double value);
    private static  void halign_set(System.IntPtr obj, System.IntPtr pd,  double value)
   {
      Eina.Log.Debug("function efl_text_halign_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((LayoutPartText)wrapper).SetHalign( value);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_halign_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  value);
      }
   }
   private efl_text_halign_set_delegate efl_text_halign_set_static_delegate;


    private delegate double efl_text_valign_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern double efl_text_valign_get(System.IntPtr obj);
    private static double valign_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_valign_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  double _ret_var = default(double);
         try {
            _ret_var = ((LayoutPartText)wrapper).GetValign();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_valign_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_text_valign_get_delegate efl_text_valign_get_static_delegate;


    private delegate  void efl_text_valign_set_delegate(System.IntPtr obj, System.IntPtr pd,   double value);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_valign_set(System.IntPtr obj,   double value);
    private static  void valign_set(System.IntPtr obj, System.IntPtr pd,  double value)
   {
      Eina.Log.Debug("function efl_text_valign_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((LayoutPartText)wrapper).SetValign( value);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_valign_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  value);
      }
   }
   private efl_text_valign_set_delegate efl_text_valign_set_static_delegate;


    private delegate double efl_text_linegap_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern double efl_text_linegap_get(System.IntPtr obj);
    private static double linegap_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_linegap_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  double _ret_var = default(double);
         try {
            _ret_var = ((LayoutPartText)wrapper).GetLinegap();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_linegap_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_text_linegap_get_delegate efl_text_linegap_get_static_delegate;


    private delegate  void efl_text_linegap_set_delegate(System.IntPtr obj, System.IntPtr pd,   double value);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_linegap_set(System.IntPtr obj,   double value);
    private static  void linegap_set(System.IntPtr obj, System.IntPtr pd,  double value)
   {
      Eina.Log.Debug("function efl_text_linegap_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((LayoutPartText)wrapper).SetLinegap( value);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_linegap_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  value);
      }
   }
   private efl_text_linegap_set_delegate efl_text_linegap_set_static_delegate;


    private delegate double efl_text_linerelgap_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern double efl_text_linerelgap_get(System.IntPtr obj);
    private static double linerelgap_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_linerelgap_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  double _ret_var = default(double);
         try {
            _ret_var = ((LayoutPartText)wrapper).GetLinerelgap();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_linerelgap_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_text_linerelgap_get_delegate efl_text_linerelgap_get_static_delegate;


    private delegate  void efl_text_linerelgap_set_delegate(System.IntPtr obj, System.IntPtr pd,   double value);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_linerelgap_set(System.IntPtr obj,   double value);
    private static  void linerelgap_set(System.IntPtr obj, System.IntPtr pd,  double value)
   {
      Eina.Log.Debug("function efl_text_linerelgap_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((LayoutPartText)wrapper).SetLinerelgap( value);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_linerelgap_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  value);
      }
   }
   private efl_text_linerelgap_set_delegate efl_text_linerelgap_set_static_delegate;


    private delegate  int efl_text_tabstops_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  int efl_text_tabstops_get(System.IntPtr obj);
    private static  int tabstops_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_tabstops_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   int _ret_var = default( int);
         try {
            _ret_var = ((LayoutPartText)wrapper).GetTabstops();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_tabstops_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_text_tabstops_get_delegate efl_text_tabstops_get_static_delegate;


    private delegate  void efl_text_tabstops_set_delegate(System.IntPtr obj, System.IntPtr pd,    int value);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_tabstops_set(System.IntPtr obj,    int value);
    private static  void tabstops_set(System.IntPtr obj, System.IntPtr pd,   int value)
   {
      Eina.Log.Debug("function efl_text_tabstops_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((LayoutPartText)wrapper).SetTabstops( value);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_tabstops_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  value);
      }
   }
   private efl_text_tabstops_set_delegate efl_text_tabstops_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_text_password_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_text_password_get(System.IntPtr obj);
    private static bool password_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_password_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((LayoutPartText)wrapper).GetPassword();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_password_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_text_password_get_delegate efl_text_password_get_static_delegate;


    private delegate  void efl_text_password_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool enabled);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_password_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool enabled);
    private static  void password_set(System.IntPtr obj, System.IntPtr pd,  bool enabled)
   {
      Eina.Log.Debug("function efl_text_password_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((LayoutPartText)wrapper).SetPassword( enabled);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_password_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  enabled);
      }
   }
   private efl_text_password_set_delegate efl_text_password_set_static_delegate;


    private delegate  System.IntPtr efl_text_replacement_char_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  System.IntPtr efl_text_replacement_char_get(System.IntPtr obj);
    private static  System.IntPtr replacement_char_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_replacement_char_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((LayoutPartText)wrapper).GetReplacementChar();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Efl.Eo.Globals.cached_string_to_intptr(((LayoutPartText)wrapper).cached_strings, _ret_var);
      } else {
         return efl_text_replacement_char_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_text_replacement_char_get_delegate efl_text_replacement_char_get_static_delegate;


    private delegate  void efl_text_replacement_char_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String repch);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_replacement_char_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String repch);
    private static  void replacement_char_set(System.IntPtr obj, System.IntPtr pd,   System.String repch)
   {
      Eina.Log.Debug("function efl_text_replacement_char_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((LayoutPartText)wrapper).SetReplacementChar( repch);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_replacement_char_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  repch);
      }
   }
   private efl_text_replacement_char_set_delegate efl_text_replacement_char_set_static_delegate;


    private delegate  System.IntPtr efl_text_markup_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  System.IntPtr efl_text_markup_get(System.IntPtr obj);
    private static  System.IntPtr markup_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_markup_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((LayoutPartText)wrapper).GetMarkup();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Efl.Eo.Globals.cached_string_to_intptr(((LayoutPartText)wrapper).cached_strings, _ret_var);
      } else {
         return efl_text_markup_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_text_markup_get_delegate efl_text_markup_get_static_delegate;


    private delegate  void efl_text_markup_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String markup);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_markup_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String markup);
    private static  void markup_set(System.IntPtr obj, System.IntPtr pd,   System.String markup)
   {
      Eina.Log.Debug("function efl_text_markup_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((LayoutPartText)wrapper).SetMarkup( markup);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_markup_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  markup);
      }
   }
   private efl_text_markup_set_delegate efl_text_markup_set_static_delegate;


    private delegate  System.String efl_text_markup_range_get_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor start,   Efl.TextCursorCursor end);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  System.String efl_text_markup_range_get(System.IntPtr obj,   Efl.TextCursorCursor start,   Efl.TextCursorCursor end);
    private static  System.String markup_range_get(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor start,  Efl.TextCursorCursor end)
   {
      Eina.Log.Debug("function efl_text_markup_range_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                       System.String _ret_var = default( System.String);
         try {
            _ret_var = ((LayoutPartText)wrapper).GetMarkupRange( start,  end);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_text_markup_range_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  start,  end);
      }
   }
   private efl_text_markup_range_get_delegate efl_text_markup_range_get_static_delegate;


    private delegate  void efl_text_markup_range_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor start,   Efl.TextCursorCursor end,    System.String markup);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_markup_range_set(System.IntPtr obj,   Efl.TextCursorCursor start,   Efl.TextCursorCursor end,    System.String markup);
    private static  void markup_range_set(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor start,  Efl.TextCursorCursor end,   System.String markup)
   {
      Eina.Log.Debug("function efl_text_markup_range_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                        
         try {
            ((LayoutPartText)wrapper).SetMarkupRange( start,  end,  markup);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                } else {
         efl_text_markup_range_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  start,  end,  markup);
      }
   }
   private efl_text_markup_range_set_delegate efl_text_markup_range_set_static_delegate;


    private delegate  void efl_text_markup_cursor_markup_insert_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String markup);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_markup_cursor_markup_insert(System.IntPtr obj,   Efl.TextCursorCursor cur,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String markup);
    private static  void cursor_markup_insert(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur,   System.String markup)
   {
      Eina.Log.Debug("function efl_text_markup_cursor_markup_insert was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((LayoutPartText)wrapper).CursorMarkupInsert( cur,  markup);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_text_markup_cursor_markup_insert(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur,  markup);
      }
   }
   private efl_text_markup_cursor_markup_insert_delegate efl_text_markup_cursor_markup_insert_static_delegate;


    private delegate  void efl_text_normal_color_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  byte r,   out  byte g,   out  byte b,   out  byte a);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_normal_color_get(System.IntPtr obj,   out  byte r,   out  byte g,   out  byte b,   out  byte a);
    private static  void normal_color_get(System.IntPtr obj, System.IntPtr pd,  out  byte r,  out  byte g,  out  byte b,  out  byte a)
   {
      Eina.Log.Debug("function efl_text_normal_color_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                       r = default( byte);      g = default( byte);      b = default( byte);      a = default( byte);                                 
         try {
            ((LayoutPartText)wrapper).GetNormalColor( out r,  out g,  out b,  out a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_text_normal_color_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out r,  out g,  out b,  out a);
      }
   }
   private efl_text_normal_color_get_delegate efl_text_normal_color_get_static_delegate;


    private delegate  void efl_text_normal_color_set_delegate(System.IntPtr obj, System.IntPtr pd,    byte r,    byte g,    byte b,    byte a);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_normal_color_set(System.IntPtr obj,    byte r,    byte g,    byte b,    byte a);
    private static  void normal_color_set(System.IntPtr obj, System.IntPtr pd,   byte r,   byte g,   byte b,   byte a)
   {
      Eina.Log.Debug("function efl_text_normal_color_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                          
         try {
            ((LayoutPartText)wrapper).SetNormalColor( r,  g,  b,  a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_text_normal_color_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  r,  g,  b,  a);
      }
   }
   private efl_text_normal_color_set_delegate efl_text_normal_color_set_static_delegate;


    private delegate Efl.TextStyleBackingType efl_text_backing_type_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Efl.TextStyleBackingType efl_text_backing_type_get(System.IntPtr obj);
    private static Efl.TextStyleBackingType backing_type_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_backing_type_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.TextStyleBackingType _ret_var = default(Efl.TextStyleBackingType);
         try {
            _ret_var = ((LayoutPartText)wrapper).GetBackingType();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_backing_type_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_text_backing_type_get_delegate efl_text_backing_type_get_static_delegate;


    private delegate  void efl_text_backing_type_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextStyleBackingType type);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_backing_type_set(System.IntPtr obj,   Efl.TextStyleBackingType type);
    private static  void backing_type_set(System.IntPtr obj, System.IntPtr pd,  Efl.TextStyleBackingType type)
   {
      Eina.Log.Debug("function efl_text_backing_type_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((LayoutPartText)wrapper).SetBackingType( type);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_backing_type_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  type);
      }
   }
   private efl_text_backing_type_set_delegate efl_text_backing_type_set_static_delegate;


    private delegate  void efl_text_backing_color_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  byte r,   out  byte g,   out  byte b,   out  byte a);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_backing_color_get(System.IntPtr obj,   out  byte r,   out  byte g,   out  byte b,   out  byte a);
    private static  void backing_color_get(System.IntPtr obj, System.IntPtr pd,  out  byte r,  out  byte g,  out  byte b,  out  byte a)
   {
      Eina.Log.Debug("function efl_text_backing_color_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                       r = default( byte);      g = default( byte);      b = default( byte);      a = default( byte);                                 
         try {
            ((LayoutPartText)wrapper).GetBackingColor( out r,  out g,  out b,  out a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_text_backing_color_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out r,  out g,  out b,  out a);
      }
   }
   private efl_text_backing_color_get_delegate efl_text_backing_color_get_static_delegate;


    private delegate  void efl_text_backing_color_set_delegate(System.IntPtr obj, System.IntPtr pd,    byte r,    byte g,    byte b,    byte a);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_backing_color_set(System.IntPtr obj,    byte r,    byte g,    byte b,    byte a);
    private static  void backing_color_set(System.IntPtr obj, System.IntPtr pd,   byte r,   byte g,   byte b,   byte a)
   {
      Eina.Log.Debug("function efl_text_backing_color_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                          
         try {
            ((LayoutPartText)wrapper).SetBackingColor( r,  g,  b,  a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_text_backing_color_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  r,  g,  b,  a);
      }
   }
   private efl_text_backing_color_set_delegate efl_text_backing_color_set_static_delegate;


    private delegate Efl.TextStyleUnderlineType efl_text_underline_type_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Efl.TextStyleUnderlineType efl_text_underline_type_get(System.IntPtr obj);
    private static Efl.TextStyleUnderlineType underline_type_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_underline_type_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.TextStyleUnderlineType _ret_var = default(Efl.TextStyleUnderlineType);
         try {
            _ret_var = ((LayoutPartText)wrapper).GetUnderlineType();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_underline_type_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_text_underline_type_get_delegate efl_text_underline_type_get_static_delegate;


    private delegate  void efl_text_underline_type_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextStyleUnderlineType type);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_underline_type_set(System.IntPtr obj,   Efl.TextStyleUnderlineType type);
    private static  void underline_type_set(System.IntPtr obj, System.IntPtr pd,  Efl.TextStyleUnderlineType type)
   {
      Eina.Log.Debug("function efl_text_underline_type_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((LayoutPartText)wrapper).SetUnderlineType( type);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_underline_type_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  type);
      }
   }
   private efl_text_underline_type_set_delegate efl_text_underline_type_set_static_delegate;


    private delegate  void efl_text_underline_color_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  byte r,   out  byte g,   out  byte b,   out  byte a);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_underline_color_get(System.IntPtr obj,   out  byte r,   out  byte g,   out  byte b,   out  byte a);
    private static  void underline_color_get(System.IntPtr obj, System.IntPtr pd,  out  byte r,  out  byte g,  out  byte b,  out  byte a)
   {
      Eina.Log.Debug("function efl_text_underline_color_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                       r = default( byte);      g = default( byte);      b = default( byte);      a = default( byte);                                 
         try {
            ((LayoutPartText)wrapper).GetUnderlineColor( out r,  out g,  out b,  out a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_text_underline_color_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out r,  out g,  out b,  out a);
      }
   }
   private efl_text_underline_color_get_delegate efl_text_underline_color_get_static_delegate;


    private delegate  void efl_text_underline_color_set_delegate(System.IntPtr obj, System.IntPtr pd,    byte r,    byte g,    byte b,    byte a);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_underline_color_set(System.IntPtr obj,    byte r,    byte g,    byte b,    byte a);
    private static  void underline_color_set(System.IntPtr obj, System.IntPtr pd,   byte r,   byte g,   byte b,   byte a)
   {
      Eina.Log.Debug("function efl_text_underline_color_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                          
         try {
            ((LayoutPartText)wrapper).SetUnderlineColor( r,  g,  b,  a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_text_underline_color_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  r,  g,  b,  a);
      }
   }
   private efl_text_underline_color_set_delegate efl_text_underline_color_set_static_delegate;


    private delegate double efl_text_underline_height_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern double efl_text_underline_height_get(System.IntPtr obj);
    private static double underline_height_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_underline_height_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  double _ret_var = default(double);
         try {
            _ret_var = ((LayoutPartText)wrapper).GetUnderlineHeight();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_underline_height_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_text_underline_height_get_delegate efl_text_underline_height_get_static_delegate;


    private delegate  void efl_text_underline_height_set_delegate(System.IntPtr obj, System.IntPtr pd,   double height);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_underline_height_set(System.IntPtr obj,   double height);
    private static  void underline_height_set(System.IntPtr obj, System.IntPtr pd,  double height)
   {
      Eina.Log.Debug("function efl_text_underline_height_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((LayoutPartText)wrapper).SetUnderlineHeight( height);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_underline_height_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  height);
      }
   }
   private efl_text_underline_height_set_delegate efl_text_underline_height_set_static_delegate;


    private delegate  void efl_text_underline_dashed_color_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  byte r,   out  byte g,   out  byte b,   out  byte a);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_underline_dashed_color_get(System.IntPtr obj,   out  byte r,   out  byte g,   out  byte b,   out  byte a);
    private static  void underline_dashed_color_get(System.IntPtr obj, System.IntPtr pd,  out  byte r,  out  byte g,  out  byte b,  out  byte a)
   {
      Eina.Log.Debug("function efl_text_underline_dashed_color_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                       r = default( byte);      g = default( byte);      b = default( byte);      a = default( byte);                                 
         try {
            ((LayoutPartText)wrapper).GetUnderlineDashedColor( out r,  out g,  out b,  out a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_text_underline_dashed_color_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out r,  out g,  out b,  out a);
      }
   }
   private efl_text_underline_dashed_color_get_delegate efl_text_underline_dashed_color_get_static_delegate;


    private delegate  void efl_text_underline_dashed_color_set_delegate(System.IntPtr obj, System.IntPtr pd,    byte r,    byte g,    byte b,    byte a);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_underline_dashed_color_set(System.IntPtr obj,    byte r,    byte g,    byte b,    byte a);
    private static  void underline_dashed_color_set(System.IntPtr obj, System.IntPtr pd,   byte r,   byte g,   byte b,   byte a)
   {
      Eina.Log.Debug("function efl_text_underline_dashed_color_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                          
         try {
            ((LayoutPartText)wrapper).SetUnderlineDashedColor( r,  g,  b,  a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_text_underline_dashed_color_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  r,  g,  b,  a);
      }
   }
   private efl_text_underline_dashed_color_set_delegate efl_text_underline_dashed_color_set_static_delegate;


    private delegate  int efl_text_underline_dashed_width_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  int efl_text_underline_dashed_width_get(System.IntPtr obj);
    private static  int underline_dashed_width_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_underline_dashed_width_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   int _ret_var = default( int);
         try {
            _ret_var = ((LayoutPartText)wrapper).GetUnderlineDashedWidth();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_underline_dashed_width_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_text_underline_dashed_width_get_delegate efl_text_underline_dashed_width_get_static_delegate;


    private delegate  void efl_text_underline_dashed_width_set_delegate(System.IntPtr obj, System.IntPtr pd,    int width);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_underline_dashed_width_set(System.IntPtr obj,    int width);
    private static  void underline_dashed_width_set(System.IntPtr obj, System.IntPtr pd,   int width)
   {
      Eina.Log.Debug("function efl_text_underline_dashed_width_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((LayoutPartText)wrapper).SetUnderlineDashedWidth( width);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_underline_dashed_width_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  width);
      }
   }
   private efl_text_underline_dashed_width_set_delegate efl_text_underline_dashed_width_set_static_delegate;


    private delegate  int efl_text_underline_dashed_gap_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  int efl_text_underline_dashed_gap_get(System.IntPtr obj);
    private static  int underline_dashed_gap_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_underline_dashed_gap_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   int _ret_var = default( int);
         try {
            _ret_var = ((LayoutPartText)wrapper).GetUnderlineDashedGap();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_underline_dashed_gap_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_text_underline_dashed_gap_get_delegate efl_text_underline_dashed_gap_get_static_delegate;


    private delegate  void efl_text_underline_dashed_gap_set_delegate(System.IntPtr obj, System.IntPtr pd,    int gap);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_underline_dashed_gap_set(System.IntPtr obj,    int gap);
    private static  void underline_dashed_gap_set(System.IntPtr obj, System.IntPtr pd,   int gap)
   {
      Eina.Log.Debug("function efl_text_underline_dashed_gap_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((LayoutPartText)wrapper).SetUnderlineDashedGap( gap);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_underline_dashed_gap_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  gap);
      }
   }
   private efl_text_underline_dashed_gap_set_delegate efl_text_underline_dashed_gap_set_static_delegate;


    private delegate  void efl_text_underline2_color_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  byte r,   out  byte g,   out  byte b,   out  byte a);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_underline2_color_get(System.IntPtr obj,   out  byte r,   out  byte g,   out  byte b,   out  byte a);
    private static  void underline2_color_get(System.IntPtr obj, System.IntPtr pd,  out  byte r,  out  byte g,  out  byte b,  out  byte a)
   {
      Eina.Log.Debug("function efl_text_underline2_color_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                       r = default( byte);      g = default( byte);      b = default( byte);      a = default( byte);                                 
         try {
            ((LayoutPartText)wrapper).GetUnderline2Color( out r,  out g,  out b,  out a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_text_underline2_color_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out r,  out g,  out b,  out a);
      }
   }
   private efl_text_underline2_color_get_delegate efl_text_underline2_color_get_static_delegate;


    private delegate  void efl_text_underline2_color_set_delegate(System.IntPtr obj, System.IntPtr pd,    byte r,    byte g,    byte b,    byte a);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_underline2_color_set(System.IntPtr obj,    byte r,    byte g,    byte b,    byte a);
    private static  void underline2_color_set(System.IntPtr obj, System.IntPtr pd,   byte r,   byte g,   byte b,   byte a)
   {
      Eina.Log.Debug("function efl_text_underline2_color_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                          
         try {
            ((LayoutPartText)wrapper).SetUnderline2Color( r,  g,  b,  a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_text_underline2_color_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  r,  g,  b,  a);
      }
   }
   private efl_text_underline2_color_set_delegate efl_text_underline2_color_set_static_delegate;


    private delegate Efl.TextStyleStrikethroughType efl_text_strikethrough_type_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Efl.TextStyleStrikethroughType efl_text_strikethrough_type_get(System.IntPtr obj);
    private static Efl.TextStyleStrikethroughType strikethrough_type_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_strikethrough_type_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.TextStyleStrikethroughType _ret_var = default(Efl.TextStyleStrikethroughType);
         try {
            _ret_var = ((LayoutPartText)wrapper).GetStrikethroughType();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_strikethrough_type_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_text_strikethrough_type_get_delegate efl_text_strikethrough_type_get_static_delegate;


    private delegate  void efl_text_strikethrough_type_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextStyleStrikethroughType type);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_strikethrough_type_set(System.IntPtr obj,   Efl.TextStyleStrikethroughType type);
    private static  void strikethrough_type_set(System.IntPtr obj, System.IntPtr pd,  Efl.TextStyleStrikethroughType type)
   {
      Eina.Log.Debug("function efl_text_strikethrough_type_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((LayoutPartText)wrapper).SetStrikethroughType( type);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_strikethrough_type_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  type);
      }
   }
   private efl_text_strikethrough_type_set_delegate efl_text_strikethrough_type_set_static_delegate;


    private delegate  void efl_text_strikethrough_color_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  byte r,   out  byte g,   out  byte b,   out  byte a);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_strikethrough_color_get(System.IntPtr obj,   out  byte r,   out  byte g,   out  byte b,   out  byte a);
    private static  void strikethrough_color_get(System.IntPtr obj, System.IntPtr pd,  out  byte r,  out  byte g,  out  byte b,  out  byte a)
   {
      Eina.Log.Debug("function efl_text_strikethrough_color_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                       r = default( byte);      g = default( byte);      b = default( byte);      a = default( byte);                                 
         try {
            ((LayoutPartText)wrapper).GetStrikethroughColor( out r,  out g,  out b,  out a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_text_strikethrough_color_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out r,  out g,  out b,  out a);
      }
   }
   private efl_text_strikethrough_color_get_delegate efl_text_strikethrough_color_get_static_delegate;


    private delegate  void efl_text_strikethrough_color_set_delegate(System.IntPtr obj, System.IntPtr pd,    byte r,    byte g,    byte b,    byte a);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_strikethrough_color_set(System.IntPtr obj,    byte r,    byte g,    byte b,    byte a);
    private static  void strikethrough_color_set(System.IntPtr obj, System.IntPtr pd,   byte r,   byte g,   byte b,   byte a)
   {
      Eina.Log.Debug("function efl_text_strikethrough_color_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                          
         try {
            ((LayoutPartText)wrapper).SetStrikethroughColor( r,  g,  b,  a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_text_strikethrough_color_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  r,  g,  b,  a);
      }
   }
   private efl_text_strikethrough_color_set_delegate efl_text_strikethrough_color_set_static_delegate;


    private delegate Efl.TextStyleEffectType efl_text_effect_type_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Efl.TextStyleEffectType efl_text_effect_type_get(System.IntPtr obj);
    private static Efl.TextStyleEffectType effect_type_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_effect_type_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.TextStyleEffectType _ret_var = default(Efl.TextStyleEffectType);
         try {
            _ret_var = ((LayoutPartText)wrapper).GetEffectType();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_effect_type_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_text_effect_type_get_delegate efl_text_effect_type_get_static_delegate;


    private delegate  void efl_text_effect_type_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextStyleEffectType type);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_effect_type_set(System.IntPtr obj,   Efl.TextStyleEffectType type);
    private static  void effect_type_set(System.IntPtr obj, System.IntPtr pd,  Efl.TextStyleEffectType type)
   {
      Eina.Log.Debug("function efl_text_effect_type_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((LayoutPartText)wrapper).SetEffectType( type);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_effect_type_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  type);
      }
   }
   private efl_text_effect_type_set_delegate efl_text_effect_type_set_static_delegate;


    private delegate  void efl_text_outline_color_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  byte r,   out  byte g,   out  byte b,   out  byte a);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_outline_color_get(System.IntPtr obj,   out  byte r,   out  byte g,   out  byte b,   out  byte a);
    private static  void outline_color_get(System.IntPtr obj, System.IntPtr pd,  out  byte r,  out  byte g,  out  byte b,  out  byte a)
   {
      Eina.Log.Debug("function efl_text_outline_color_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                       r = default( byte);      g = default( byte);      b = default( byte);      a = default( byte);                                 
         try {
            ((LayoutPartText)wrapper).GetOutlineColor( out r,  out g,  out b,  out a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_text_outline_color_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out r,  out g,  out b,  out a);
      }
   }
   private efl_text_outline_color_get_delegate efl_text_outline_color_get_static_delegate;


    private delegate  void efl_text_outline_color_set_delegate(System.IntPtr obj, System.IntPtr pd,    byte r,    byte g,    byte b,    byte a);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_outline_color_set(System.IntPtr obj,    byte r,    byte g,    byte b,    byte a);
    private static  void outline_color_set(System.IntPtr obj, System.IntPtr pd,   byte r,   byte g,   byte b,   byte a)
   {
      Eina.Log.Debug("function efl_text_outline_color_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                          
         try {
            ((LayoutPartText)wrapper).SetOutlineColor( r,  g,  b,  a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_text_outline_color_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  r,  g,  b,  a);
      }
   }
   private efl_text_outline_color_set_delegate efl_text_outline_color_set_static_delegate;


    private delegate Efl.TextStyleShadowDirection efl_text_shadow_direction_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Efl.TextStyleShadowDirection efl_text_shadow_direction_get(System.IntPtr obj);
    private static Efl.TextStyleShadowDirection shadow_direction_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_shadow_direction_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.TextStyleShadowDirection _ret_var = default(Efl.TextStyleShadowDirection);
         try {
            _ret_var = ((LayoutPartText)wrapper).GetShadowDirection();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_shadow_direction_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_text_shadow_direction_get_delegate efl_text_shadow_direction_get_static_delegate;


    private delegate  void efl_text_shadow_direction_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextStyleShadowDirection type);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_shadow_direction_set(System.IntPtr obj,   Efl.TextStyleShadowDirection type);
    private static  void shadow_direction_set(System.IntPtr obj, System.IntPtr pd,  Efl.TextStyleShadowDirection type)
   {
      Eina.Log.Debug("function efl_text_shadow_direction_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((LayoutPartText)wrapper).SetShadowDirection( type);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_shadow_direction_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  type);
      }
   }
   private efl_text_shadow_direction_set_delegate efl_text_shadow_direction_set_static_delegate;


    private delegate  void efl_text_shadow_color_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  byte r,   out  byte g,   out  byte b,   out  byte a);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_shadow_color_get(System.IntPtr obj,   out  byte r,   out  byte g,   out  byte b,   out  byte a);
    private static  void shadow_color_get(System.IntPtr obj, System.IntPtr pd,  out  byte r,  out  byte g,  out  byte b,  out  byte a)
   {
      Eina.Log.Debug("function efl_text_shadow_color_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                       r = default( byte);      g = default( byte);      b = default( byte);      a = default( byte);                                 
         try {
            ((LayoutPartText)wrapper).GetShadowColor( out r,  out g,  out b,  out a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_text_shadow_color_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out r,  out g,  out b,  out a);
      }
   }
   private efl_text_shadow_color_get_delegate efl_text_shadow_color_get_static_delegate;


    private delegate  void efl_text_shadow_color_set_delegate(System.IntPtr obj, System.IntPtr pd,    byte r,    byte g,    byte b,    byte a);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_shadow_color_set(System.IntPtr obj,    byte r,    byte g,    byte b,    byte a);
    private static  void shadow_color_set(System.IntPtr obj, System.IntPtr pd,   byte r,   byte g,   byte b,   byte a)
   {
      Eina.Log.Debug("function efl_text_shadow_color_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                          
         try {
            ((LayoutPartText)wrapper).SetShadowColor( r,  g,  b,  a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_text_shadow_color_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  r,  g,  b,  a);
      }
   }
   private efl_text_shadow_color_set_delegate efl_text_shadow_color_set_static_delegate;


    private delegate  void efl_text_glow_color_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  byte r,   out  byte g,   out  byte b,   out  byte a);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_glow_color_get(System.IntPtr obj,   out  byte r,   out  byte g,   out  byte b,   out  byte a);
    private static  void glow_color_get(System.IntPtr obj, System.IntPtr pd,  out  byte r,  out  byte g,  out  byte b,  out  byte a)
   {
      Eina.Log.Debug("function efl_text_glow_color_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                       r = default( byte);      g = default( byte);      b = default( byte);      a = default( byte);                                 
         try {
            ((LayoutPartText)wrapper).GetGlowColor( out r,  out g,  out b,  out a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_text_glow_color_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out r,  out g,  out b,  out a);
      }
   }
   private efl_text_glow_color_get_delegate efl_text_glow_color_get_static_delegate;


    private delegate  void efl_text_glow_color_set_delegate(System.IntPtr obj, System.IntPtr pd,    byte r,    byte g,    byte b,    byte a);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_glow_color_set(System.IntPtr obj,    byte r,    byte g,    byte b,    byte a);
    private static  void glow_color_set(System.IntPtr obj, System.IntPtr pd,   byte r,   byte g,   byte b,   byte a)
   {
      Eina.Log.Debug("function efl_text_glow_color_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                          
         try {
            ((LayoutPartText)wrapper).SetGlowColor( r,  g,  b,  a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_text_glow_color_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  r,  g,  b,  a);
      }
   }
   private efl_text_glow_color_set_delegate efl_text_glow_color_set_static_delegate;


    private delegate  void efl_text_glow2_color_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  byte r,   out  byte g,   out  byte b,   out  byte a);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_glow2_color_get(System.IntPtr obj,   out  byte r,   out  byte g,   out  byte b,   out  byte a);
    private static  void glow2_color_get(System.IntPtr obj, System.IntPtr pd,  out  byte r,  out  byte g,  out  byte b,  out  byte a)
   {
      Eina.Log.Debug("function efl_text_glow2_color_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                       r = default( byte);      g = default( byte);      b = default( byte);      a = default( byte);                                 
         try {
            ((LayoutPartText)wrapper).GetGlow2Color( out r,  out g,  out b,  out a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_text_glow2_color_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out r,  out g,  out b,  out a);
      }
   }
   private efl_text_glow2_color_get_delegate efl_text_glow2_color_get_static_delegate;


    private delegate  void efl_text_glow2_color_set_delegate(System.IntPtr obj, System.IntPtr pd,    byte r,    byte g,    byte b,    byte a);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_glow2_color_set(System.IntPtr obj,    byte r,    byte g,    byte b,    byte a);
    private static  void glow2_color_set(System.IntPtr obj, System.IntPtr pd,   byte r,   byte g,   byte b,   byte a)
   {
      Eina.Log.Debug("function efl_text_glow2_color_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                          
         try {
            ((LayoutPartText)wrapper).SetGlow2Color( r,  g,  b,  a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_text_glow2_color_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  r,  g,  b,  a);
      }
   }
   private efl_text_glow2_color_set_delegate efl_text_glow2_color_set_static_delegate;


    private delegate  System.IntPtr efl_text_gfx_filter_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  System.IntPtr efl_text_gfx_filter_get(System.IntPtr obj);
    private static  System.IntPtr gfx_filter_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_gfx_filter_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((LayoutPartText)wrapper).GetGfxFilter();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Efl.Eo.Globals.cached_string_to_intptr(((LayoutPartText)wrapper).cached_strings, _ret_var);
      } else {
         return efl_text_gfx_filter_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_text_gfx_filter_get_delegate efl_text_gfx_filter_get_static_delegate;


    private delegate  void efl_text_gfx_filter_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String code);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_gfx_filter_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String code);
    private static  void gfx_filter_set(System.IntPtr obj, System.IntPtr pd,   System.String code)
   {
      Eina.Log.Debug("function efl_text_gfx_filter_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((LayoutPartText)wrapper).SetGfxFilter( code);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_gfx_filter_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  code);
      }
   }
   private efl_text_gfx_filter_set_delegate efl_text_gfx_filter_set_static_delegate;
}
} } 
namespace Efl { namespace Canvas { 
/// <summary>Text layout policy to enforce. If none is set, min/max descriptions are taken in considerations solely.</summary>
public enum LayoutPartTextExpand
{
/// <summary>No policy. Use default description parameters.</summary>
None = 0,
/// <summary></summary>
MinX = 1,
/// <summary></summary>
MinY = 2,
/// <summary></summary>
MaxX = 4,
/// <summary></summary>
MaxY = 8,
}
} } 
