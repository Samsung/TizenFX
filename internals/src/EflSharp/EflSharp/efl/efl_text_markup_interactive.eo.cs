#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { 
/// <summary>Markup data that populates the text object&apos;s style and format</summary>
[ITextMarkupInteractiveNativeInherit]
public interface ITextMarkupInteractive : 
    Efl.ITextCursor ,
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Markup of a given range in the text</summary>
/// <param name="start">Start of the markup region</param>
/// <param name="end">End of markup region</param>
/// <returns>The markup-text representation set to this text of a given range</returns>
System.String GetMarkupRange( Efl.TextCursorCursor start,  Efl.TextCursorCursor end);
    /// <summary>Markup of a given range in the text</summary>
/// <param name="start">Start of the markup region</param>
/// <param name="end">End of markup region</param>
/// <param name="markup">The markup-text representation set to this text of a given range</param>
/// <returns></returns>
void SetMarkupRange( Efl.TextCursorCursor start,  Efl.TextCursorCursor end,  System.String markup);
    /// <summary>Inserts a markup text to the text object in a given cursor position</summary>
/// <param name="cur">Cursor position to insert markup</param>
/// <param name="markup">The markup text to insert</param>
/// <returns></returns>
void CursorMarkupInsert( Efl.TextCursorCursor cur,  System.String markup);
            }
/// <summary>Markup data that populates the text object&apos;s style and format</summary>
sealed public class ITextMarkupInteractiveConcrete : 

ITextMarkupInteractive
    , Efl.ITextCursor
{
    ///<summary>Pointer to the native class description.</summary>
    public System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (ITextMarkupInteractiveConcrete))
                return Efl.ITextMarkupInteractiveNativeInherit.GetEflClassStatic();
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
    private ITextMarkupInteractiveConcrete(System.IntPtr raw)
    {
        handle = raw;
        RegisterEventProxies();
    }
    ///<summary>Destructor.</summary>
    ~ITextMarkupInteractiveConcrete()
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
    ///<summary>Register the Eo event wrappers making the bridge to C# events. Internal usage only.</summary>
     void RegisterEventProxies()
    {
    }
    /// <summary>Markup of a given range in the text</summary>
    /// <param name="start">Start of the markup region</param>
    /// <param name="end">End of markup region</param>
    /// <returns>The markup-text representation set to this text of a given range</returns>
    public System.String GetMarkupRange( Efl.TextCursorCursor start,  Efl.TextCursorCursor end) {
                                                         var _ret_var = Efl.ITextMarkupInteractiveNativeInherit.efl_text_markup_interactive_markup_range_get_ptr.Value.Delegate(this.NativeHandle, start,  end);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Markup of a given range in the text</summary>
    /// <param name="start">Start of the markup region</param>
    /// <param name="end">End of markup region</param>
    /// <param name="markup">The markup-text representation set to this text of a given range</param>
    /// <returns></returns>
    public void SetMarkupRange( Efl.TextCursorCursor start,  Efl.TextCursorCursor end,  System.String markup) {
                                                                                 Efl.ITextMarkupInteractiveNativeInherit.efl_text_markup_interactive_markup_range_set_ptr.Value.Delegate(this.NativeHandle, start,  end,  markup);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>Inserts a markup text to the text object in a given cursor position</summary>
    /// <param name="cur">Cursor position to insert markup</param>
    /// <param name="markup">The markup text to insert</param>
    /// <returns></returns>
    public void CursorMarkupInsert( Efl.TextCursorCursor cur,  System.String markup) {
                                                         Efl.ITextMarkupInteractiveNativeInherit.efl_text_markup_interactive_cursor_markup_insert_ptr.Value.Delegate(this.NativeHandle, cur,  markup);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>The object&apos;s main cursor.</summary>
    /// <param name="get_type">Cursor type</param>
    /// <returns>Text cursor object</returns>
    public Efl.TextCursorCursor GetTextCursor( Efl.TextCursorGetType get_type) {
                                 var _ret_var = Efl.ITextCursorNativeInherit.efl_text_cursor_get_ptr.Value.Delegate(this.NativeHandle, get_type);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Cursor position</summary>
    /// <param name="cur">Cursor object</param>
    /// <returns>Cursor position</returns>
    public int GetCursorPosition( Efl.TextCursorCursor cur) {
                                 var _ret_var = Efl.ITextCursorNativeInherit.efl_text_cursor_position_get_ptr.Value.Delegate(this.NativeHandle, cur);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Cursor position</summary>
    /// <param name="cur">Cursor object</param>
    /// <param name="position">Cursor position</param>
    /// <returns></returns>
    public void SetCursorPosition( Efl.TextCursorCursor cur,  int position) {
                                                         Efl.ITextCursorNativeInherit.efl_text_cursor_position_set_ptr.Value.Delegate(this.NativeHandle, cur,  position);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>The content of the cursor (the character under the cursor)</summary>
    /// <param name="cur">Cursor object</param>
    /// <returns>The unicode codepoint of the character</returns>
    public Eina.Unicode GetCursorContent( Efl.TextCursorCursor cur) {
                                 var _ret_var = Efl.ITextCursorNativeInherit.efl_text_cursor_content_get_ptr.Value.Delegate(this.NativeHandle, cur);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Returns the geometry of two cursors (&quot;split cursor&quot;), if logical cursor is between LTR/RTL text, also considering paragraph direction. Upper cursor is shown for the text of the same direction as paragraph, lower cursor - for opposite.
    /// Split cursor geometry is valid only  in &apos;|&apos; cursor mode. In this case <c>true</c> is returned and <c>cx2</c>, <c>cy2</c>, <c>cw2</c>, <c>ch2</c> are set.</summary>
    /// <param name="cur">Cursor object</param>
    /// <param name="ctype">The type of the cursor.</param>
    /// <param name="cx">The x of the cursor (or upper cursor)</param>
    /// <param name="cy">The y of the cursor (or upper cursor)</param>
    /// <param name="cw">The width of the cursor (or upper cursor)</param>
    /// <param name="ch">The height of the cursor (or upper cursor)</param>
    /// <param name="cx2">The x of the lower cursor</param>
    /// <param name="cy2">The y of the lower cursor</param>
    /// <param name="cw2">The width of the lower cursor</param>
    /// <param name="ch2">The height of the lower cursor</param>
    /// <returns><c>true</c> if split cursor, <c>false</c> otherwise.</returns>
    public bool GetCursorGeometry( Efl.TextCursorCursor cur,  Efl.TextCursorType ctype,  out int cx,  out int cy,  out int cw,  out int ch,  out int cx2,  out int cy2,  out int cw2,  out int ch2) {
                                                                                                                                                                                                                                                         var _ret_var = Efl.ITextCursorNativeInherit.efl_text_cursor_geometry_get_ptr.Value.Delegate(this.NativeHandle, cur,  ctype,  out cx,  out cy,  out cw,  out ch,  out cx2,  out cy2,  out cw2,  out ch2);
        Eina.Error.RaiseIfUnhandledException();
                                                                                                                                                                        return _ret_var;
 }
    /// <summary>Create new cursor</summary>
    /// <returns>Cursor object</returns>
    public Efl.TextCursorCursor NewCursor() {
         var _ret_var = Efl.ITextCursorNativeInherit.efl_text_cursor_new_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Free existing cursor</summary>
    /// <param name="cur">Cursor object</param>
    /// <returns></returns>
    public void CursorFree( Efl.TextCursorCursor cur) {
                                 Efl.ITextCursorNativeInherit.efl_text_cursor_free_ptr.Value.Delegate(this.NativeHandle, cur);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Check if two cursors are equal</summary>
    /// <param name="cur1">Cursor 1 object</param>
    /// <param name="cur2">Cursor 2 object</param>
    /// <returns><c>true</c> if cursors are equal, <c>false</c> otherwise</returns>
    public bool CursorEqual( Efl.TextCursorCursor cur1,  Efl.TextCursorCursor cur2) {
                                                         var _ret_var = Efl.ITextCursorNativeInherit.efl_text_cursor_equal_ptr.Value.Delegate(this.NativeHandle, cur1,  cur2);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Compare two cursors</summary>
    /// <param name="cur1">Cursor 1 object</param>
    /// <param name="cur2">Cursor 2 object</param>
    /// <returns>Difference between cursors</returns>
    public int CursorCompare( Efl.TextCursorCursor cur1,  Efl.TextCursorCursor cur2) {
                                                         var _ret_var = Efl.ITextCursorNativeInherit.efl_text_cursor_compare_ptr.Value.Delegate(this.NativeHandle, cur1,  cur2);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Copy existing cursor</summary>
    /// <param name="dst">Destination cursor</param>
    /// <param name="src">Source cursor</param>
    /// <returns></returns>
    public void CursorCopy( Efl.TextCursorCursor dst,  Efl.TextCursorCursor src) {
                                                         Efl.ITextCursorNativeInherit.efl_text_cursor_copy_ptr.Value.Delegate(this.NativeHandle, dst,  src);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Advances to the next character</summary>
    /// <param name="cur">Cursor object</param>
    /// <returns></returns>
    public void CursorCharNext( Efl.TextCursorCursor cur) {
                                 Efl.ITextCursorNativeInherit.efl_text_cursor_char_next_ptr.Value.Delegate(this.NativeHandle, cur);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Advances to the previous character</summary>
    /// <param name="cur">Cursor object</param>
    /// <returns></returns>
    public void CursorCharPrev( Efl.TextCursorCursor cur) {
                                 Efl.ITextCursorNativeInherit.efl_text_cursor_char_prev_ptr.Value.Delegate(this.NativeHandle, cur);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Advances to the next grapheme cluster</summary>
    /// <param name="cur">Cursor object</param>
    /// <returns></returns>
    public void CursorClusterNext( Efl.TextCursorCursor cur) {
                                 Efl.ITextCursorNativeInherit.efl_text_cursor_cluster_next_ptr.Value.Delegate(this.NativeHandle, cur);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Advances to the previous grapheme cluster</summary>
    /// <param name="cur">Cursor object</param>
    /// <returns></returns>
    public void CursorClusterPrev( Efl.TextCursorCursor cur) {
                                 Efl.ITextCursorNativeInherit.efl_text_cursor_cluster_prev_ptr.Value.Delegate(this.NativeHandle, cur);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Advances to the first character in this paragraph</summary>
    /// <param name="cur">Cursor object</param>
    /// <returns></returns>
    public void CursorParagraphCharFirst( Efl.TextCursorCursor cur) {
                                 Efl.ITextCursorNativeInherit.efl_text_cursor_paragraph_char_first_ptr.Value.Delegate(this.NativeHandle, cur);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Advances to the last character in this paragraph</summary>
    /// <param name="cur">Cursor object</param>
    /// <returns></returns>
    public void CursorParagraphCharLast( Efl.TextCursorCursor cur) {
                                 Efl.ITextCursorNativeInherit.efl_text_cursor_paragraph_char_last_ptr.Value.Delegate(this.NativeHandle, cur);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Advance to current word start</summary>
    /// <param name="cur">Cursor object</param>
    /// <returns></returns>
    public void CursorWordStart( Efl.TextCursorCursor cur) {
                                 Efl.ITextCursorNativeInherit.efl_text_cursor_word_start_ptr.Value.Delegate(this.NativeHandle, cur);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Advance to current word end</summary>
    /// <param name="cur">Cursor object</param>
    /// <returns></returns>
    public void CursorWordEnd( Efl.TextCursorCursor cur) {
                                 Efl.ITextCursorNativeInherit.efl_text_cursor_word_end_ptr.Value.Delegate(this.NativeHandle, cur);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Advance to current line first character</summary>
    /// <param name="cur">Cursor object</param>
    /// <returns></returns>
    public void CursorLineCharFirst( Efl.TextCursorCursor cur) {
                                 Efl.ITextCursorNativeInherit.efl_text_cursor_line_char_first_ptr.Value.Delegate(this.NativeHandle, cur);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Advance to current line last character</summary>
    /// <param name="cur">Cursor object</param>
    /// <returns></returns>
    public void CursorLineCharLast( Efl.TextCursorCursor cur) {
                                 Efl.ITextCursorNativeInherit.efl_text_cursor_line_char_last_ptr.Value.Delegate(this.NativeHandle, cur);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Advance to current paragraph first character</summary>
    /// <param name="cur">Cursor object</param>
    /// <returns></returns>
    public void CursorParagraphFirst( Efl.TextCursorCursor cur) {
                                 Efl.ITextCursorNativeInherit.efl_text_cursor_paragraph_first_ptr.Value.Delegate(this.NativeHandle, cur);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Advance to current paragraph last character</summary>
    /// <param name="cur">Cursor object</param>
    /// <returns></returns>
    public void CursorParagraphLast( Efl.TextCursorCursor cur) {
                                 Efl.ITextCursorNativeInherit.efl_text_cursor_paragraph_last_ptr.Value.Delegate(this.NativeHandle, cur);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Advances to the start of the next text node</summary>
    /// <param name="cur">Cursor object</param>
    /// <returns></returns>
    public void CursorParagraphNext( Efl.TextCursorCursor cur) {
                                 Efl.ITextCursorNativeInherit.efl_text_cursor_paragraph_next_ptr.Value.Delegate(this.NativeHandle, cur);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Advances to the end of the previous text node</summary>
    /// <param name="cur">Cursor object</param>
    /// <returns></returns>
    public void CursorParagraphPrev( Efl.TextCursorCursor cur) {
                                 Efl.ITextCursorNativeInherit.efl_text_cursor_paragraph_prev_ptr.Value.Delegate(this.NativeHandle, cur);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Jump the cursor by the given number of lines</summary>
    /// <param name="cur">Cursor object</param>
    /// <param name="by">Number of lines</param>
    /// <returns></returns>
    public void CursorLineJumpBy( Efl.TextCursorCursor cur,  int by) {
                                                         Efl.ITextCursorNativeInherit.efl_text_cursor_line_jump_by_ptr.Value.Delegate(this.NativeHandle, cur,  by);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Set cursor coordinates</summary>
    /// <param name="cur">Cursor object</param>
    /// <param name="x">X coord to set by.</param>
    /// <param name="y">Y coord to set by.</param>
    /// <returns></returns>
    public void SetCursorCoord( Efl.TextCursorCursor cur,  int x,  int y) {
                                                                                 Efl.ITextCursorNativeInherit.efl_text_cursor_coord_set_ptr.Value.Delegate(this.NativeHandle, cur,  x,  y);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>Set cursor coordinates according to grapheme clusters. It does not allow to put a cursor to the middle of a grapheme cluster.</summary>
    /// <param name="cur">Cursor object</param>
    /// <param name="x">X coord to set by.</param>
    /// <param name="y">Y coord to set by.</param>
    /// <returns></returns>
    public void SetCursorClusterCoord( Efl.TextCursorCursor cur,  int x,  int y) {
                                                                                 Efl.ITextCursorNativeInherit.efl_text_cursor_cluster_coord_set_ptr.Value.Delegate(this.NativeHandle, cur,  x,  y);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>Adds text to the current cursor position and set the cursor to *after* the start of the text just added.</summary>
    /// <param name="cur">Cursor object</param>
    /// <param name="text">Text to append (UTF-8 format).</param>
    /// <returns>Length of the appended text.</returns>
    public int CursorTextInsert( Efl.TextCursorCursor cur,  System.String text) {
                                                         var _ret_var = Efl.ITextCursorNativeInherit.efl_text_cursor_text_insert_ptr.Value.Delegate(this.NativeHandle, cur,  text);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Deletes a single character from position pointed by given cursor.</summary>
    /// <param name="cur">Cursor object</param>
    /// <returns></returns>
    public void CursorCharDelete( Efl.TextCursorCursor cur) {
                                 Efl.ITextCursorNativeInherit.efl_text_cursor_char_delete_ptr.Value.Delegate(this.NativeHandle, cur);
        Eina.Error.RaiseIfUnhandledException();
                         }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.ITextMarkupInteractiveConcrete.efl_text_markup_interactive_interface_get();
    }
}
public class ITextMarkupInteractiveNativeInherit  : Efl.Eo.NativeClass{
    public  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Efl);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
        if (efl_text_markup_interactive_markup_range_get_static_delegate == null)
            efl_text_markup_interactive_markup_range_get_static_delegate = new efl_text_markup_interactive_markup_range_get_delegate(markup_range_get);
        if (methods.FirstOrDefault(m => m.Name == "GetMarkupRange") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_markup_interactive_markup_range_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_markup_interactive_markup_range_get_static_delegate)});
        if (efl_text_markup_interactive_markup_range_set_static_delegate == null)
            efl_text_markup_interactive_markup_range_set_static_delegate = new efl_text_markup_interactive_markup_range_set_delegate(markup_range_set);
        if (methods.FirstOrDefault(m => m.Name == "SetMarkupRange") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_markup_interactive_markup_range_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_markup_interactive_markup_range_set_static_delegate)});
        if (efl_text_markup_interactive_cursor_markup_insert_static_delegate == null)
            efl_text_markup_interactive_cursor_markup_insert_static_delegate = new efl_text_markup_interactive_cursor_markup_insert_delegate(cursor_markup_insert);
        if (methods.FirstOrDefault(m => m.Name == "CursorMarkupInsert") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_markup_interactive_cursor_markup_insert"), func = Marshal.GetFunctionPointerForDelegate(efl_text_markup_interactive_cursor_markup_insert_static_delegate)});
        if (efl_text_cursor_get_static_delegate == null)
            efl_text_cursor_get_static_delegate = new efl_text_cursor_get_delegate(text_cursor_get);
        if (methods.FirstOrDefault(m => m.Name == "GetTextCursor") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_cursor_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_get_static_delegate)});
        if (efl_text_cursor_position_get_static_delegate == null)
            efl_text_cursor_position_get_static_delegate = new efl_text_cursor_position_get_delegate(cursor_position_get);
        if (methods.FirstOrDefault(m => m.Name == "GetCursorPosition") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_cursor_position_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_position_get_static_delegate)});
        if (efl_text_cursor_position_set_static_delegate == null)
            efl_text_cursor_position_set_static_delegate = new efl_text_cursor_position_set_delegate(cursor_position_set);
        if (methods.FirstOrDefault(m => m.Name == "SetCursorPosition") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_cursor_position_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_position_set_static_delegate)});
        if (efl_text_cursor_content_get_static_delegate == null)
            efl_text_cursor_content_get_static_delegate = new efl_text_cursor_content_get_delegate(cursor_content_get);
        if (methods.FirstOrDefault(m => m.Name == "GetCursorContent") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_cursor_content_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_content_get_static_delegate)});
        if (efl_text_cursor_geometry_get_static_delegate == null)
            efl_text_cursor_geometry_get_static_delegate = new efl_text_cursor_geometry_get_delegate(cursor_geometry_get);
        if (methods.FirstOrDefault(m => m.Name == "GetCursorGeometry") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_cursor_geometry_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_geometry_get_static_delegate)});
        if (efl_text_cursor_new_static_delegate == null)
            efl_text_cursor_new_static_delegate = new efl_text_cursor_new_delegate(cursor_new);
        if (methods.FirstOrDefault(m => m.Name == "NewCursor") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_cursor_new"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_new_static_delegate)});
        if (efl_text_cursor_free_static_delegate == null)
            efl_text_cursor_free_static_delegate = new efl_text_cursor_free_delegate(cursor_free);
        if (methods.FirstOrDefault(m => m.Name == "CursorFree") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_cursor_free"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_free_static_delegate)});
        if (efl_text_cursor_equal_static_delegate == null)
            efl_text_cursor_equal_static_delegate = new efl_text_cursor_equal_delegate(cursor_equal);
        if (methods.FirstOrDefault(m => m.Name == "CursorEqual") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_cursor_equal"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_equal_static_delegate)});
        if (efl_text_cursor_compare_static_delegate == null)
            efl_text_cursor_compare_static_delegate = new efl_text_cursor_compare_delegate(cursor_compare);
        if (methods.FirstOrDefault(m => m.Name == "CursorCompare") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_cursor_compare"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_compare_static_delegate)});
        if (efl_text_cursor_copy_static_delegate == null)
            efl_text_cursor_copy_static_delegate = new efl_text_cursor_copy_delegate(cursor_copy);
        if (methods.FirstOrDefault(m => m.Name == "CursorCopy") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_cursor_copy"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_copy_static_delegate)});
        if (efl_text_cursor_char_next_static_delegate == null)
            efl_text_cursor_char_next_static_delegate = new efl_text_cursor_char_next_delegate(cursor_char_next);
        if (methods.FirstOrDefault(m => m.Name == "CursorCharNext") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_cursor_char_next"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_char_next_static_delegate)});
        if (efl_text_cursor_char_prev_static_delegate == null)
            efl_text_cursor_char_prev_static_delegate = new efl_text_cursor_char_prev_delegate(cursor_char_prev);
        if (methods.FirstOrDefault(m => m.Name == "CursorCharPrev") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_cursor_char_prev"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_char_prev_static_delegate)});
        if (efl_text_cursor_cluster_next_static_delegate == null)
            efl_text_cursor_cluster_next_static_delegate = new efl_text_cursor_cluster_next_delegate(cursor_cluster_next);
        if (methods.FirstOrDefault(m => m.Name == "CursorClusterNext") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_cursor_cluster_next"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_cluster_next_static_delegate)});
        if (efl_text_cursor_cluster_prev_static_delegate == null)
            efl_text_cursor_cluster_prev_static_delegate = new efl_text_cursor_cluster_prev_delegate(cursor_cluster_prev);
        if (methods.FirstOrDefault(m => m.Name == "CursorClusterPrev") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_cursor_cluster_prev"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_cluster_prev_static_delegate)});
        if (efl_text_cursor_paragraph_char_first_static_delegate == null)
            efl_text_cursor_paragraph_char_first_static_delegate = new efl_text_cursor_paragraph_char_first_delegate(cursor_paragraph_char_first);
        if (methods.FirstOrDefault(m => m.Name == "CursorParagraphCharFirst") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_cursor_paragraph_char_first"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_paragraph_char_first_static_delegate)});
        if (efl_text_cursor_paragraph_char_last_static_delegate == null)
            efl_text_cursor_paragraph_char_last_static_delegate = new efl_text_cursor_paragraph_char_last_delegate(cursor_paragraph_char_last);
        if (methods.FirstOrDefault(m => m.Name == "CursorParagraphCharLast") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_cursor_paragraph_char_last"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_paragraph_char_last_static_delegate)});
        if (efl_text_cursor_word_start_static_delegate == null)
            efl_text_cursor_word_start_static_delegate = new efl_text_cursor_word_start_delegate(cursor_word_start);
        if (methods.FirstOrDefault(m => m.Name == "CursorWordStart") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_cursor_word_start"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_word_start_static_delegate)});
        if (efl_text_cursor_word_end_static_delegate == null)
            efl_text_cursor_word_end_static_delegate = new efl_text_cursor_word_end_delegate(cursor_word_end);
        if (methods.FirstOrDefault(m => m.Name == "CursorWordEnd") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_cursor_word_end"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_word_end_static_delegate)});
        if (efl_text_cursor_line_char_first_static_delegate == null)
            efl_text_cursor_line_char_first_static_delegate = new efl_text_cursor_line_char_first_delegate(cursor_line_char_first);
        if (methods.FirstOrDefault(m => m.Name == "CursorLineCharFirst") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_cursor_line_char_first"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_line_char_first_static_delegate)});
        if (efl_text_cursor_line_char_last_static_delegate == null)
            efl_text_cursor_line_char_last_static_delegate = new efl_text_cursor_line_char_last_delegate(cursor_line_char_last);
        if (methods.FirstOrDefault(m => m.Name == "CursorLineCharLast") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_cursor_line_char_last"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_line_char_last_static_delegate)});
        if (efl_text_cursor_paragraph_first_static_delegate == null)
            efl_text_cursor_paragraph_first_static_delegate = new efl_text_cursor_paragraph_first_delegate(cursor_paragraph_first);
        if (methods.FirstOrDefault(m => m.Name == "CursorParagraphFirst") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_cursor_paragraph_first"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_paragraph_first_static_delegate)});
        if (efl_text_cursor_paragraph_last_static_delegate == null)
            efl_text_cursor_paragraph_last_static_delegate = new efl_text_cursor_paragraph_last_delegate(cursor_paragraph_last);
        if (methods.FirstOrDefault(m => m.Name == "CursorParagraphLast") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_cursor_paragraph_last"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_paragraph_last_static_delegate)});
        if (efl_text_cursor_paragraph_next_static_delegate == null)
            efl_text_cursor_paragraph_next_static_delegate = new efl_text_cursor_paragraph_next_delegate(cursor_paragraph_next);
        if (methods.FirstOrDefault(m => m.Name == "CursorParagraphNext") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_cursor_paragraph_next"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_paragraph_next_static_delegate)});
        if (efl_text_cursor_paragraph_prev_static_delegate == null)
            efl_text_cursor_paragraph_prev_static_delegate = new efl_text_cursor_paragraph_prev_delegate(cursor_paragraph_prev);
        if (methods.FirstOrDefault(m => m.Name == "CursorParagraphPrev") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_cursor_paragraph_prev"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_paragraph_prev_static_delegate)});
        if (efl_text_cursor_line_jump_by_static_delegate == null)
            efl_text_cursor_line_jump_by_static_delegate = new efl_text_cursor_line_jump_by_delegate(cursor_line_jump_by);
        if (methods.FirstOrDefault(m => m.Name == "CursorLineJumpBy") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_cursor_line_jump_by"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_line_jump_by_static_delegate)});
        if (efl_text_cursor_coord_set_static_delegate == null)
            efl_text_cursor_coord_set_static_delegate = new efl_text_cursor_coord_set_delegate(cursor_coord_set);
        if (methods.FirstOrDefault(m => m.Name == "SetCursorCoord") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_cursor_coord_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_coord_set_static_delegate)});
        if (efl_text_cursor_cluster_coord_set_static_delegate == null)
            efl_text_cursor_cluster_coord_set_static_delegate = new efl_text_cursor_cluster_coord_set_delegate(cursor_cluster_coord_set);
        if (methods.FirstOrDefault(m => m.Name == "SetCursorClusterCoord") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_cursor_cluster_coord_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_cluster_coord_set_static_delegate)});
        if (efl_text_cursor_text_insert_static_delegate == null)
            efl_text_cursor_text_insert_static_delegate = new efl_text_cursor_text_insert_delegate(cursor_text_insert);
        if (methods.FirstOrDefault(m => m.Name == "CursorTextInsert") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_cursor_text_insert"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_text_insert_static_delegate)});
        if (efl_text_cursor_char_delete_static_delegate == null)
            efl_text_cursor_char_delete_static_delegate = new efl_text_cursor_char_delete_delegate(cursor_char_delete);
        if (methods.FirstOrDefault(m => m.Name == "CursorCharDelete") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_cursor_char_delete"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_char_delete_static_delegate)});
        return descs;
    }
    public override IntPtr GetEflClass()
    {
        return Efl.ITextMarkupInteractiveConcrete.efl_text_markup_interactive_interface_get();
    }
    public static  IntPtr GetEflClassStatic()
    {
        return Efl.ITextMarkupInteractiveConcrete.efl_text_markup_interactive_interface_get();
    }


     [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringPassOwnershipMarshaler))] private delegate System.String efl_text_markup_interactive_markup_range_get_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor start,   Efl.TextCursorCursor end);


     [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringPassOwnershipMarshaler))] public delegate System.String efl_text_markup_interactive_markup_range_get_api_delegate(System.IntPtr obj,   Efl.TextCursorCursor start,   Efl.TextCursorCursor end);
     public static Efl.Eo.FunctionWrapper<efl_text_markup_interactive_markup_range_get_api_delegate> efl_text_markup_interactive_markup_range_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_markup_interactive_markup_range_get_api_delegate>(_Module, "efl_text_markup_interactive_markup_range_get");
     private static System.String markup_range_get(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor start,  Efl.TextCursorCursor end)
    {
        Eina.Log.Debug("function efl_text_markup_interactive_markup_range_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                        System.String _ret_var = default(System.String);
            try {
                _ret_var = ((ITextMarkupInteractive)wrapper).GetMarkupRange( start,  end);
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


     private delegate void efl_text_markup_interactive_markup_range_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor start,   Efl.TextCursorCursor end,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringPassOwnershipMarshaler))]  System.String markup);


     public delegate void efl_text_markup_interactive_markup_range_set_api_delegate(System.IntPtr obj,   Efl.TextCursorCursor start,   Efl.TextCursorCursor end,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringPassOwnershipMarshaler))]  System.String markup);
     public static Efl.Eo.FunctionWrapper<efl_text_markup_interactive_markup_range_set_api_delegate> efl_text_markup_interactive_markup_range_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_markup_interactive_markup_range_set_api_delegate>(_Module, "efl_text_markup_interactive_markup_range_set");
     private static void markup_range_set(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor start,  Efl.TextCursorCursor end,  System.String markup)
    {
        Eina.Log.Debug("function efl_text_markup_interactive_markup_range_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                                                
            try {
                ((ITextMarkupInteractive)wrapper).SetMarkupRange( start,  end,  markup);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                                } else {
            efl_text_markup_interactive_markup_range_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  start,  end,  markup);
        }
    }
    private static efl_text_markup_interactive_markup_range_set_delegate efl_text_markup_interactive_markup_range_set_static_delegate;


     private delegate void efl_text_markup_interactive_cursor_markup_insert_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String markup);


     public delegate void efl_text_markup_interactive_cursor_markup_insert_api_delegate(System.IntPtr obj,   Efl.TextCursorCursor cur,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String markup);
     public static Efl.Eo.FunctionWrapper<efl_text_markup_interactive_cursor_markup_insert_api_delegate> efl_text_markup_interactive_cursor_markup_insert_ptr = new Efl.Eo.FunctionWrapper<efl_text_markup_interactive_cursor_markup_insert_api_delegate>(_Module, "efl_text_markup_interactive_cursor_markup_insert");
     private static void cursor_markup_insert(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur,  System.String markup)
    {
        Eina.Log.Debug("function efl_text_markup_interactive_cursor_markup_insert was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                        
            try {
                ((ITextMarkupInteractive)wrapper).CursorMarkupInsert( cur,  markup);
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
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                Efl.TextCursorCursor _ret_var = default(Efl.TextCursorCursor);
            try {
                _ret_var = ((ITextMarkupInteractive)wrapper).GetTextCursor( get_type);
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


     private delegate int efl_text_cursor_position_get_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur);


     public delegate int efl_text_cursor_position_get_api_delegate(System.IntPtr obj,   Efl.TextCursorCursor cur);
     public static Efl.Eo.FunctionWrapper<efl_text_cursor_position_get_api_delegate> efl_text_cursor_position_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_position_get_api_delegate>(_Module, "efl_text_cursor_position_get");
     private static int cursor_position_get(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur)
    {
        Eina.Log.Debug("function efl_text_cursor_position_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                int _ret_var = default(int);
            try {
                _ret_var = ((ITextMarkupInteractive)wrapper).GetCursorPosition( cur);
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


     private delegate void efl_text_cursor_position_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur,   int position);


     public delegate void efl_text_cursor_position_set_api_delegate(System.IntPtr obj,   Efl.TextCursorCursor cur,   int position);
     public static Efl.Eo.FunctionWrapper<efl_text_cursor_position_set_api_delegate> efl_text_cursor_position_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_position_set_api_delegate>(_Module, "efl_text_cursor_position_set");
     private static void cursor_position_set(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur,  int position)
    {
        Eina.Log.Debug("function efl_text_cursor_position_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                        
            try {
                ((ITextMarkupInteractive)wrapper).SetCursorPosition( cur,  position);
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
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                Eina.Unicode _ret_var = default(Eina.Unicode);
            try {
                _ret_var = ((ITextMarkupInteractive)wrapper).GetCursorContent( cur);
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


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_text_cursor_geometry_get_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur,   Efl.TextCursorType ctype,   out int cx,   out int cy,   out int cw,   out int ch,   out int cx2,   out int cy2,   out int cw2,   out int ch2);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_text_cursor_geometry_get_api_delegate(System.IntPtr obj,   Efl.TextCursorCursor cur,   Efl.TextCursorType ctype,   out int cx,   out int cy,   out int cw,   out int ch,   out int cx2,   out int cy2,   out int cw2,   out int ch2);
     public static Efl.Eo.FunctionWrapper<efl_text_cursor_geometry_get_api_delegate> efl_text_cursor_geometry_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_geometry_get_api_delegate>(_Module, "efl_text_cursor_geometry_get");
     private static bool cursor_geometry_get(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur,  Efl.TextCursorType ctype,  out int cx,  out int cy,  out int cw,  out int ch,  out int cx2,  out int cy2,  out int cw2,  out int ch2)
    {
        Eina.Log.Debug("function efl_text_cursor_geometry_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                                                                    cx = default(int);        cy = default(int);        cw = default(int);        ch = default(int);        cx2 = default(int);        cy2 = default(int);        cw2 = default(int);        ch2 = default(int);                                                                                            bool _ret_var = default(bool);
            try {
                _ret_var = ((ITextMarkupInteractive)wrapper).GetCursorGeometry( cur,  ctype,  out cx,  out cy,  out cw,  out ch,  out cx2,  out cy2,  out cw2,  out ch2);
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
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Efl.TextCursorCursor _ret_var = default(Efl.TextCursorCursor);
            try {
                _ret_var = ((ITextMarkupInteractive)wrapper).NewCursor();
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


     private delegate void efl_text_cursor_free_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur);


     public delegate void efl_text_cursor_free_api_delegate(System.IntPtr obj,   Efl.TextCursorCursor cur);
     public static Efl.Eo.FunctionWrapper<efl_text_cursor_free_api_delegate> efl_text_cursor_free_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_free_api_delegate>(_Module, "efl_text_cursor_free");
     private static void cursor_free(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur)
    {
        Eina.Log.Debug("function efl_text_cursor_free was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((ITextMarkupInteractive)wrapper).CursorFree( cur);
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
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                        bool _ret_var = default(bool);
            try {
                _ret_var = ((ITextMarkupInteractive)wrapper).CursorEqual( cur1,  cur2);
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


     private delegate int efl_text_cursor_compare_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur1,   Efl.TextCursorCursor cur2);


     public delegate int efl_text_cursor_compare_api_delegate(System.IntPtr obj,   Efl.TextCursorCursor cur1,   Efl.TextCursorCursor cur2);
     public static Efl.Eo.FunctionWrapper<efl_text_cursor_compare_api_delegate> efl_text_cursor_compare_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_compare_api_delegate>(_Module, "efl_text_cursor_compare");
     private static int cursor_compare(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur1,  Efl.TextCursorCursor cur2)
    {
        Eina.Log.Debug("function efl_text_cursor_compare was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                        int _ret_var = default(int);
            try {
                _ret_var = ((ITextMarkupInteractive)wrapper).CursorCompare( cur1,  cur2);
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


     private delegate void efl_text_cursor_copy_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor dst,   Efl.TextCursorCursor src);


     public delegate void efl_text_cursor_copy_api_delegate(System.IntPtr obj,   Efl.TextCursorCursor dst,   Efl.TextCursorCursor src);
     public static Efl.Eo.FunctionWrapper<efl_text_cursor_copy_api_delegate> efl_text_cursor_copy_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_copy_api_delegate>(_Module, "efl_text_cursor_copy");
     private static void cursor_copy(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor dst,  Efl.TextCursorCursor src)
    {
        Eina.Log.Debug("function efl_text_cursor_copy was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                        
            try {
                ((ITextMarkupInteractive)wrapper).CursorCopy( dst,  src);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                } else {
            efl_text_cursor_copy_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  dst,  src);
        }
    }
    private static efl_text_cursor_copy_delegate efl_text_cursor_copy_static_delegate;


     private delegate void efl_text_cursor_char_next_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur);


     public delegate void efl_text_cursor_char_next_api_delegate(System.IntPtr obj,   Efl.TextCursorCursor cur);
     public static Efl.Eo.FunctionWrapper<efl_text_cursor_char_next_api_delegate> efl_text_cursor_char_next_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_char_next_api_delegate>(_Module, "efl_text_cursor_char_next");
     private static void cursor_char_next(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur)
    {
        Eina.Log.Debug("function efl_text_cursor_char_next was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((ITextMarkupInteractive)wrapper).CursorCharNext( cur);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_text_cursor_char_next_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur);
        }
    }
    private static efl_text_cursor_char_next_delegate efl_text_cursor_char_next_static_delegate;


     private delegate void efl_text_cursor_char_prev_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur);


     public delegate void efl_text_cursor_char_prev_api_delegate(System.IntPtr obj,   Efl.TextCursorCursor cur);
     public static Efl.Eo.FunctionWrapper<efl_text_cursor_char_prev_api_delegate> efl_text_cursor_char_prev_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_char_prev_api_delegate>(_Module, "efl_text_cursor_char_prev");
     private static void cursor_char_prev(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur)
    {
        Eina.Log.Debug("function efl_text_cursor_char_prev was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((ITextMarkupInteractive)wrapper).CursorCharPrev( cur);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_text_cursor_char_prev_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur);
        }
    }
    private static efl_text_cursor_char_prev_delegate efl_text_cursor_char_prev_static_delegate;


     private delegate void efl_text_cursor_cluster_next_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur);


     public delegate void efl_text_cursor_cluster_next_api_delegate(System.IntPtr obj,   Efl.TextCursorCursor cur);
     public static Efl.Eo.FunctionWrapper<efl_text_cursor_cluster_next_api_delegate> efl_text_cursor_cluster_next_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_cluster_next_api_delegate>(_Module, "efl_text_cursor_cluster_next");
     private static void cursor_cluster_next(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur)
    {
        Eina.Log.Debug("function efl_text_cursor_cluster_next was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((ITextMarkupInteractive)wrapper).CursorClusterNext( cur);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_text_cursor_cluster_next_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur);
        }
    }
    private static efl_text_cursor_cluster_next_delegate efl_text_cursor_cluster_next_static_delegate;


     private delegate void efl_text_cursor_cluster_prev_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur);


     public delegate void efl_text_cursor_cluster_prev_api_delegate(System.IntPtr obj,   Efl.TextCursorCursor cur);
     public static Efl.Eo.FunctionWrapper<efl_text_cursor_cluster_prev_api_delegate> efl_text_cursor_cluster_prev_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_cluster_prev_api_delegate>(_Module, "efl_text_cursor_cluster_prev");
     private static void cursor_cluster_prev(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur)
    {
        Eina.Log.Debug("function efl_text_cursor_cluster_prev was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((ITextMarkupInteractive)wrapper).CursorClusterPrev( cur);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_text_cursor_cluster_prev_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur);
        }
    }
    private static efl_text_cursor_cluster_prev_delegate efl_text_cursor_cluster_prev_static_delegate;


     private delegate void efl_text_cursor_paragraph_char_first_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur);


     public delegate void efl_text_cursor_paragraph_char_first_api_delegate(System.IntPtr obj,   Efl.TextCursorCursor cur);
     public static Efl.Eo.FunctionWrapper<efl_text_cursor_paragraph_char_first_api_delegate> efl_text_cursor_paragraph_char_first_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_paragraph_char_first_api_delegate>(_Module, "efl_text_cursor_paragraph_char_first");
     private static void cursor_paragraph_char_first(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur)
    {
        Eina.Log.Debug("function efl_text_cursor_paragraph_char_first was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((ITextMarkupInteractive)wrapper).CursorParagraphCharFirst( cur);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_text_cursor_paragraph_char_first_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur);
        }
    }
    private static efl_text_cursor_paragraph_char_first_delegate efl_text_cursor_paragraph_char_first_static_delegate;


     private delegate void efl_text_cursor_paragraph_char_last_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur);


     public delegate void efl_text_cursor_paragraph_char_last_api_delegate(System.IntPtr obj,   Efl.TextCursorCursor cur);
     public static Efl.Eo.FunctionWrapper<efl_text_cursor_paragraph_char_last_api_delegate> efl_text_cursor_paragraph_char_last_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_paragraph_char_last_api_delegate>(_Module, "efl_text_cursor_paragraph_char_last");
     private static void cursor_paragraph_char_last(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur)
    {
        Eina.Log.Debug("function efl_text_cursor_paragraph_char_last was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((ITextMarkupInteractive)wrapper).CursorParagraphCharLast( cur);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_text_cursor_paragraph_char_last_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur);
        }
    }
    private static efl_text_cursor_paragraph_char_last_delegate efl_text_cursor_paragraph_char_last_static_delegate;


     private delegate void efl_text_cursor_word_start_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur);


     public delegate void efl_text_cursor_word_start_api_delegate(System.IntPtr obj,   Efl.TextCursorCursor cur);
     public static Efl.Eo.FunctionWrapper<efl_text_cursor_word_start_api_delegate> efl_text_cursor_word_start_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_word_start_api_delegate>(_Module, "efl_text_cursor_word_start");
     private static void cursor_word_start(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur)
    {
        Eina.Log.Debug("function efl_text_cursor_word_start was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((ITextMarkupInteractive)wrapper).CursorWordStart( cur);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_text_cursor_word_start_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur);
        }
    }
    private static efl_text_cursor_word_start_delegate efl_text_cursor_word_start_static_delegate;


     private delegate void efl_text_cursor_word_end_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur);


     public delegate void efl_text_cursor_word_end_api_delegate(System.IntPtr obj,   Efl.TextCursorCursor cur);
     public static Efl.Eo.FunctionWrapper<efl_text_cursor_word_end_api_delegate> efl_text_cursor_word_end_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_word_end_api_delegate>(_Module, "efl_text_cursor_word_end");
     private static void cursor_word_end(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur)
    {
        Eina.Log.Debug("function efl_text_cursor_word_end was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((ITextMarkupInteractive)wrapper).CursorWordEnd( cur);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_text_cursor_word_end_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur);
        }
    }
    private static efl_text_cursor_word_end_delegate efl_text_cursor_word_end_static_delegate;


     private delegate void efl_text_cursor_line_char_first_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur);


     public delegate void efl_text_cursor_line_char_first_api_delegate(System.IntPtr obj,   Efl.TextCursorCursor cur);
     public static Efl.Eo.FunctionWrapper<efl_text_cursor_line_char_first_api_delegate> efl_text_cursor_line_char_first_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_line_char_first_api_delegate>(_Module, "efl_text_cursor_line_char_first");
     private static void cursor_line_char_first(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur)
    {
        Eina.Log.Debug("function efl_text_cursor_line_char_first was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((ITextMarkupInteractive)wrapper).CursorLineCharFirst( cur);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_text_cursor_line_char_first_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur);
        }
    }
    private static efl_text_cursor_line_char_first_delegate efl_text_cursor_line_char_first_static_delegate;


     private delegate void efl_text_cursor_line_char_last_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur);


     public delegate void efl_text_cursor_line_char_last_api_delegate(System.IntPtr obj,   Efl.TextCursorCursor cur);
     public static Efl.Eo.FunctionWrapper<efl_text_cursor_line_char_last_api_delegate> efl_text_cursor_line_char_last_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_line_char_last_api_delegate>(_Module, "efl_text_cursor_line_char_last");
     private static void cursor_line_char_last(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur)
    {
        Eina.Log.Debug("function efl_text_cursor_line_char_last was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((ITextMarkupInteractive)wrapper).CursorLineCharLast( cur);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_text_cursor_line_char_last_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur);
        }
    }
    private static efl_text_cursor_line_char_last_delegate efl_text_cursor_line_char_last_static_delegate;


     private delegate void efl_text_cursor_paragraph_first_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur);


     public delegate void efl_text_cursor_paragraph_first_api_delegate(System.IntPtr obj,   Efl.TextCursorCursor cur);
     public static Efl.Eo.FunctionWrapper<efl_text_cursor_paragraph_first_api_delegate> efl_text_cursor_paragraph_first_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_paragraph_first_api_delegate>(_Module, "efl_text_cursor_paragraph_first");
     private static void cursor_paragraph_first(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur)
    {
        Eina.Log.Debug("function efl_text_cursor_paragraph_first was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((ITextMarkupInteractive)wrapper).CursorParagraphFirst( cur);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_text_cursor_paragraph_first_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur);
        }
    }
    private static efl_text_cursor_paragraph_first_delegate efl_text_cursor_paragraph_first_static_delegate;


     private delegate void efl_text_cursor_paragraph_last_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur);


     public delegate void efl_text_cursor_paragraph_last_api_delegate(System.IntPtr obj,   Efl.TextCursorCursor cur);
     public static Efl.Eo.FunctionWrapper<efl_text_cursor_paragraph_last_api_delegate> efl_text_cursor_paragraph_last_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_paragraph_last_api_delegate>(_Module, "efl_text_cursor_paragraph_last");
     private static void cursor_paragraph_last(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur)
    {
        Eina.Log.Debug("function efl_text_cursor_paragraph_last was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((ITextMarkupInteractive)wrapper).CursorParagraphLast( cur);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_text_cursor_paragraph_last_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur);
        }
    }
    private static efl_text_cursor_paragraph_last_delegate efl_text_cursor_paragraph_last_static_delegate;


     private delegate void efl_text_cursor_paragraph_next_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur);


     public delegate void efl_text_cursor_paragraph_next_api_delegate(System.IntPtr obj,   Efl.TextCursorCursor cur);
     public static Efl.Eo.FunctionWrapper<efl_text_cursor_paragraph_next_api_delegate> efl_text_cursor_paragraph_next_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_paragraph_next_api_delegate>(_Module, "efl_text_cursor_paragraph_next");
     private static void cursor_paragraph_next(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur)
    {
        Eina.Log.Debug("function efl_text_cursor_paragraph_next was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((ITextMarkupInteractive)wrapper).CursorParagraphNext( cur);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_text_cursor_paragraph_next_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur);
        }
    }
    private static efl_text_cursor_paragraph_next_delegate efl_text_cursor_paragraph_next_static_delegate;


     private delegate void efl_text_cursor_paragraph_prev_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur);


     public delegate void efl_text_cursor_paragraph_prev_api_delegate(System.IntPtr obj,   Efl.TextCursorCursor cur);
     public static Efl.Eo.FunctionWrapper<efl_text_cursor_paragraph_prev_api_delegate> efl_text_cursor_paragraph_prev_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_paragraph_prev_api_delegate>(_Module, "efl_text_cursor_paragraph_prev");
     private static void cursor_paragraph_prev(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur)
    {
        Eina.Log.Debug("function efl_text_cursor_paragraph_prev was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((ITextMarkupInteractive)wrapper).CursorParagraphPrev( cur);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_text_cursor_paragraph_prev_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur);
        }
    }
    private static efl_text_cursor_paragraph_prev_delegate efl_text_cursor_paragraph_prev_static_delegate;


     private delegate void efl_text_cursor_line_jump_by_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur,   int by);


     public delegate void efl_text_cursor_line_jump_by_api_delegate(System.IntPtr obj,   Efl.TextCursorCursor cur,   int by);
     public static Efl.Eo.FunctionWrapper<efl_text_cursor_line_jump_by_api_delegate> efl_text_cursor_line_jump_by_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_line_jump_by_api_delegate>(_Module, "efl_text_cursor_line_jump_by");
     private static void cursor_line_jump_by(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur,  int by)
    {
        Eina.Log.Debug("function efl_text_cursor_line_jump_by was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                        
            try {
                ((ITextMarkupInteractive)wrapper).CursorLineJumpBy( cur,  by);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                } else {
            efl_text_cursor_line_jump_by_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur,  by);
        }
    }
    private static efl_text_cursor_line_jump_by_delegate efl_text_cursor_line_jump_by_static_delegate;


     private delegate void efl_text_cursor_coord_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur,   int x,   int y);


     public delegate void efl_text_cursor_coord_set_api_delegate(System.IntPtr obj,   Efl.TextCursorCursor cur,   int x,   int y);
     public static Efl.Eo.FunctionWrapper<efl_text_cursor_coord_set_api_delegate> efl_text_cursor_coord_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_coord_set_api_delegate>(_Module, "efl_text_cursor_coord_set");
     private static void cursor_coord_set(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur,  int x,  int y)
    {
        Eina.Log.Debug("function efl_text_cursor_coord_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                                                
            try {
                ((ITextMarkupInteractive)wrapper).SetCursorCoord( cur,  x,  y);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                                } else {
            efl_text_cursor_coord_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur,  x,  y);
        }
    }
    private static efl_text_cursor_coord_set_delegate efl_text_cursor_coord_set_static_delegate;


     private delegate void efl_text_cursor_cluster_coord_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur,   int x,   int y);


     public delegate void efl_text_cursor_cluster_coord_set_api_delegate(System.IntPtr obj,   Efl.TextCursorCursor cur,   int x,   int y);
     public static Efl.Eo.FunctionWrapper<efl_text_cursor_cluster_coord_set_api_delegate> efl_text_cursor_cluster_coord_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_cluster_coord_set_api_delegate>(_Module, "efl_text_cursor_cluster_coord_set");
     private static void cursor_cluster_coord_set(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur,  int x,  int y)
    {
        Eina.Log.Debug("function efl_text_cursor_cluster_coord_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                                                
            try {
                ((ITextMarkupInteractive)wrapper).SetCursorClusterCoord( cur,  x,  y);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                                } else {
            efl_text_cursor_cluster_coord_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur,  x,  y);
        }
    }
    private static efl_text_cursor_cluster_coord_set_delegate efl_text_cursor_cluster_coord_set_static_delegate;


     private delegate int efl_text_cursor_text_insert_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String text);


     public delegate int efl_text_cursor_text_insert_api_delegate(System.IntPtr obj,   Efl.TextCursorCursor cur,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String text);
     public static Efl.Eo.FunctionWrapper<efl_text_cursor_text_insert_api_delegate> efl_text_cursor_text_insert_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_text_insert_api_delegate>(_Module, "efl_text_cursor_text_insert");
     private static int cursor_text_insert(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur,  System.String text)
    {
        Eina.Log.Debug("function efl_text_cursor_text_insert was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                        int _ret_var = default(int);
            try {
                _ret_var = ((ITextMarkupInteractive)wrapper).CursorTextInsert( cur,  text);
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


     private delegate void efl_text_cursor_char_delete_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextCursorCursor cur);


     public delegate void efl_text_cursor_char_delete_api_delegate(System.IntPtr obj,   Efl.TextCursorCursor cur);
     public static Efl.Eo.FunctionWrapper<efl_text_cursor_char_delete_api_delegate> efl_text_cursor_char_delete_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_char_delete_api_delegate>(_Module, "efl_text_cursor_char_delete");
     private static void cursor_char_delete(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur)
    {
        Eina.Log.Debug("function efl_text_cursor_char_delete was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((ITextMarkupInteractive)wrapper).CursorCharDelete( cur);
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
