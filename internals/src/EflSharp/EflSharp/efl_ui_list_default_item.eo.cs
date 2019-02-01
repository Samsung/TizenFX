#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary>List Default Item class. This class need to be sub object of list widget. text and contents can be appliable by efl_text, efl_content or efl_part APIs.</summary>
[ListDefaultItemNativeInherit]
public class ListDefaultItem : Efl.Ui.ListItem, Efl.Eo.IWrapper,Efl.Content,Efl.Text,Efl.TextCursor,Efl.TextMarkup
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Ui.ListDefaultItemNativeInherit nativeInherit = new Efl.Ui.ListDefaultItemNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (ListDefaultItem))
            return Efl.Ui.ListDefaultItemNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   ///<summary>Delegate for function to be called from inside the native constructor.</summary>
   public new delegate void ConstructingMethod(ListDefaultItem obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
      efl_ui_list_default_item_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="init_cb">Delegate to call constructing methods that should be run inside the constructor.</param>
   public ListDefaultItem(Efl.Object parent = null, ConstructingMethod init_cb=null) : base("ListDefaultItem", efl_ui_list_default_item_class_get(), typeof(ListDefaultItem), parent)
   {
      if (init_cb != null) {
         init_cb(this);
      }
      FinishInstantiation();
   }
   ///<summary>Internal constructor to forward the wrapper initialization to the root class.</summary>
   protected ListDefaultItem(String klass_name, IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(klass_name, base_klass, managed_type, parent) {}
   ///<summary>Constructs an instance from a native pointer.</summary>
   public ListDefaultItem(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static ListDefaultItem static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new ListDefaultItem(obj.NativeHandle);
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


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))] protected static extern Efl.Gfx.Entity efl_content_get(System.IntPtr obj);
   /// <summary>Swallowed sub-object contained in this object.</summary>
   /// <returns>The object to swallow.</returns>
   virtual public Efl.Gfx.Entity GetContent() {
       var _ret_var = efl_content_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_content_set(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity content);
   /// <summary>Swallowed sub-object contained in this object.</summary>
   /// <param name="content">The object to swallow.</param>
   /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
   virtual public bool SetContent( Efl.Gfx.Entity content) {
                         var _ret_var = efl_content_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  content);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))] protected static extern Efl.Gfx.Entity efl_content_unset(System.IntPtr obj);
   /// <summary>Unswallow the object in the current container and return it.</summary>
   /// <returns>Unswallowed object</returns>
   virtual public Efl.Gfx.Entity UnsetContent() {
       var _ret_var = efl_content_unset((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
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
   /// <summary>Swallowed sub-object contained in this object.</summary>
   public Efl.Gfx.Entity Content {
      get { return GetContent(); }
      set { SetContent( value); }
   }
   /// <summary>Markup property
/// 1.21</summary>
   public  System.String Markup {
      get { return GetMarkup(); }
      set { SetMarkup( value); }
   }
}
public class ListDefaultItemNativeInherit : Efl.Ui.ListItemNativeInherit{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_content_get_static_delegate = new efl_content_get_delegate(content_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_content_get"), func = Marshal.GetFunctionPointerForDelegate(efl_content_get_static_delegate)});
      efl_content_set_static_delegate = new efl_content_set_delegate(content_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_content_set"), func = Marshal.GetFunctionPointerForDelegate(efl_content_set_static_delegate)});
      efl_content_unset_static_delegate = new efl_content_unset_delegate(content_unset);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_content_unset"), func = Marshal.GetFunctionPointerForDelegate(efl_content_unset_static_delegate)});
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
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Ui.ListDefaultItem.efl_ui_list_default_item_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.ListDefaultItem.efl_ui_list_default_item_class_get();
   }


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.Gfx.Entity efl_content_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))] private static extern Efl.Gfx.Entity efl_content_get(System.IntPtr obj);
    private static Efl.Gfx.Entity content_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_content_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Gfx.Entity _ret_var = default(Efl.Gfx.Entity);
         try {
            _ret_var = ((ListDefaultItem)wrapper).GetContent();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_content_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_content_get_delegate efl_content_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_content_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity content);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_content_set(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity content);
    private static bool content_set(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.Entity content)
   {
      Eina.Log.Debug("function efl_content_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((ListDefaultItem)wrapper).SetContent( content);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_content_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  content);
      }
   }
   private efl_content_set_delegate efl_content_set_static_delegate;


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.Gfx.Entity efl_content_unset_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))] private static extern Efl.Gfx.Entity efl_content_unset(System.IntPtr obj);
    private static Efl.Gfx.Entity content_unset(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_content_unset was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Gfx.Entity _ret_var = default(Efl.Gfx.Entity);
         try {
            _ret_var = ((ListDefaultItem)wrapper).UnsetContent();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_content_unset(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_content_unset_delegate efl_content_unset_static_delegate;


    private delegate  System.IntPtr efl_text_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  System.IntPtr efl_text_get(System.IntPtr obj);
    private static  System.IntPtr text_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((ListDefaultItem)wrapper).GetText();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Efl.Eo.Globals.cached_string_to_intptr(((ListDefaultItem)wrapper).cached_strings, _ret_var);
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
            ((ListDefaultItem)wrapper).SetText( text);
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
            _ret_var = ((ListDefaultItem)wrapper).GetTextCursor( get_type);
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
            _ret_var = ((ListDefaultItem)wrapper).GetCursorPosition( cur);
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
            ((ListDefaultItem)wrapper).SetCursorPosition( cur,  position);
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
            _ret_var = ((ListDefaultItem)wrapper).GetCursorContent( cur);
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
            _ret_var = ((ListDefaultItem)wrapper).GetCursorGeometry( cur,  ctype,  out cx,  out cy,  out cw,  out ch,  out cx2,  out cy2,  out cw2,  out ch2);
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
            _ret_var = ((ListDefaultItem)wrapper).NewCursor();
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
            ((ListDefaultItem)wrapper).CursorFree( cur);
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
            _ret_var = ((ListDefaultItem)wrapper).CursorEqual( cur1,  cur2);
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
            _ret_var = ((ListDefaultItem)wrapper).CursorCompare( cur1,  cur2);
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
            ((ListDefaultItem)wrapper).CursorCopy( dst,  src);
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
            ((ListDefaultItem)wrapper).CursorCharNext( cur);
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
            ((ListDefaultItem)wrapper).CursorCharPrev( cur);
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
            ((ListDefaultItem)wrapper).CursorClusterNext( cur);
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
            ((ListDefaultItem)wrapper).CursorClusterPrev( cur);
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
            ((ListDefaultItem)wrapper).CursorParagraphCharFirst( cur);
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
            ((ListDefaultItem)wrapper).CursorParagraphCharLast( cur);
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
            ((ListDefaultItem)wrapper).CursorWordStart( cur);
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
            ((ListDefaultItem)wrapper).CursorWordEnd( cur);
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
            ((ListDefaultItem)wrapper).CursorLineCharFirst( cur);
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
            ((ListDefaultItem)wrapper).CursorLineCharLast( cur);
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
            ((ListDefaultItem)wrapper).CursorParagraphFirst( cur);
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
            ((ListDefaultItem)wrapper).CursorParagraphLast( cur);
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
            ((ListDefaultItem)wrapper).CursorParagraphNext( cur);
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
            ((ListDefaultItem)wrapper).CursorParagraphPrev( cur);
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
            ((ListDefaultItem)wrapper).CursorLineJumpBy( cur,  by);
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
            ((ListDefaultItem)wrapper).SetCursorCoord( cur,  x,  y);
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
            ((ListDefaultItem)wrapper).SetCursorClusterCoord( cur,  x,  y);
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
            _ret_var = ((ListDefaultItem)wrapper).CursorTextInsert( cur,  text);
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
            ((ListDefaultItem)wrapper).CursorCharDelete( cur);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_cursor_char_delete(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur);
      }
   }
   private efl_text_cursor_char_delete_delegate efl_text_cursor_char_delete_static_delegate;


    private delegate  System.IntPtr efl_text_markup_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  System.IntPtr efl_text_markup_get(System.IntPtr obj);
    private static  System.IntPtr markup_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_markup_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((ListDefaultItem)wrapper).GetMarkup();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Efl.Eo.Globals.cached_string_to_intptr(((ListDefaultItem)wrapper).cached_strings, _ret_var);
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
            ((ListDefaultItem)wrapper).SetMarkup( markup);
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
            _ret_var = ((ListDefaultItem)wrapper).GetMarkupRange( start,  end);
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
            ((ListDefaultItem)wrapper).SetMarkupRange( start,  end,  markup);
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
            ((ListDefaultItem)wrapper).CursorMarkupInsert( cur,  markup);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_text_markup_cursor_markup_insert(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur,  markup);
      }
   }
   private efl_text_markup_cursor_markup_insert_delegate efl_text_markup_cursor_markup_insert_static_delegate;
}
} } 
