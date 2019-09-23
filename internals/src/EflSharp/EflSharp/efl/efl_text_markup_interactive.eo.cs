#define EFL_BETA
#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

/// <summary>Markup data that populates the text object&apos;s style and format</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.TextMarkupInteractiveConcrete.NativeMethods]
[Efl.Eo.BindingEntity]
public interface ITextMarkupInteractive : 
    Efl.ITextCursor ,
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Markup of a given range in the text</summary>
/// <param name="start">Start of the markup region</param>
/// <param name="end">End of markup region</param>
/// <returns>The markup-text representation set to this text of a given range</returns>
System.String GetMarkupRange(Efl.TextCursorCursor start, Efl.TextCursorCursor end);
    /// <summary>Markup of a given range in the text</summary>
/// <param name="start">Start of the markup region</param>
/// <param name="end">End of markup region</param>
/// <param name="markup">The markup-text representation set to this text of a given range</param>
void SetMarkupRange(Efl.TextCursorCursor start, Efl.TextCursorCursor end, System.String markup);
    /// <summary>Inserts a markup text to the text object in a given cursor position</summary>
/// <param name="cur">Cursor position to insert markup</param>
/// <param name="markup">The markup text to insert</param>
void CursorMarkupInsert(Efl.TextCursorCursor cur, System.String markup);
            }
/// <summary>Markup data that populates the text object&apos;s style and format</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
public sealed class TextMarkupInteractiveConcrete :
    Efl.Eo.EoWrapper
    , ITextMarkupInteractive
    , Efl.ITextCursor
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(TextMarkupInteractiveConcrete))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    private TextMarkupInteractiveConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
        efl_text_markup_interactive_interface_get();
    /// <summary>Initializes a new instance of the <see cref="ITextMarkupInteractive"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private TextMarkupInteractiveConcrete(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

#pragma warning disable CS0628
    /// <summary>Markup of a given range in the text</summary>
    /// <param name="start">Start of the markup region</param>
    /// <param name="end">End of markup region</param>
    /// <returns>The markup-text representation set to this text of a given range</returns>
    public System.String GetMarkupRange(Efl.TextCursorCursor start, Efl.TextCursorCursor end) {
                                                         var _ret_var = Efl.TextMarkupInteractiveConcrete.NativeMethods.efl_text_markup_interactive_markup_range_get_ptr.Value.Delegate(this.NativeHandle,start, end);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Markup of a given range in the text</summary>
    /// <param name="start">Start of the markup region</param>
    /// <param name="end">End of markup region</param>
    /// <param name="markup">The markup-text representation set to this text of a given range</param>
    public void SetMarkupRange(Efl.TextCursorCursor start, Efl.TextCursorCursor end, System.String markup) {
                                                                                 Efl.TextMarkupInteractiveConcrete.NativeMethods.efl_text_markup_interactive_markup_range_set_ptr.Value.Delegate(this.NativeHandle,start, end, markup);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>Inserts a markup text to the text object in a given cursor position</summary>
    /// <param name="cur">Cursor position to insert markup</param>
    /// <param name="markup">The markup text to insert</param>
    public void CursorMarkupInsert(Efl.TextCursorCursor cur, System.String markup) {
                                                         Efl.TextMarkupInteractiveConcrete.NativeMethods.efl_text_markup_interactive_cursor_markup_insert_ptr.Value.Delegate(this.NativeHandle,cur, markup);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>The object&apos;s main cursor.</summary>
    /// <param name="get_type">Cursor type</param>
    /// <returns>Text cursor object</returns>
    public Efl.TextCursorCursor GetTextCursor(Efl.TextCursorGetType get_type) {
                                 var _ret_var = Efl.TextCursorConcrete.NativeMethods.efl_text_cursor_get_ptr.Value.Delegate(this.NativeHandle,get_type);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Cursor position</summary>
    /// <param name="cur">Cursor object</param>
    /// <returns>Cursor position</returns>
    public int GetCursorPosition(Efl.TextCursorCursor cur) {
                                 var _ret_var = Efl.TextCursorConcrete.NativeMethods.efl_text_cursor_position_get_ptr.Value.Delegate(this.NativeHandle,cur);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Cursor position</summary>
    /// <param name="cur">Cursor object</param>
    /// <param name="position">Cursor position</param>
    public void SetCursorPosition(Efl.TextCursorCursor cur, int position) {
                                                         Efl.TextCursorConcrete.NativeMethods.efl_text_cursor_position_set_ptr.Value.Delegate(this.NativeHandle,cur, position);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>The content of the cursor (the character under the cursor)</summary>
    /// <param name="cur">Cursor object</param>
    /// <returns>The unicode codepoint of the character</returns>
    public Eina.Unicode GetCursorContent(Efl.TextCursorCursor cur) {
                                 var _ret_var = Efl.TextCursorConcrete.NativeMethods.efl_text_cursor_content_get_ptr.Value.Delegate(this.NativeHandle,cur);
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
    public bool GetCursorGeometry(Efl.TextCursorCursor cur, Efl.TextCursorType ctype, out int cx, out int cy, out int cw, out int ch, out int cx2, out int cy2, out int cw2, out int ch2) {
                                                                                                                                                                                                                                                         var _ret_var = Efl.TextCursorConcrete.NativeMethods.efl_text_cursor_geometry_get_ptr.Value.Delegate(this.NativeHandle,cur, ctype, out cx, out cy, out cw, out ch, out cx2, out cy2, out cw2, out ch2);
        Eina.Error.RaiseIfUnhandledException();
                                                                                                                                                                        return _ret_var;
 }
    /// <summary>Create new cursor</summary>
    /// <returns>Cursor object</returns>
    public Efl.TextCursorCursor NewCursor() {
         var _ret_var = Efl.TextCursorConcrete.NativeMethods.efl_text_cursor_new_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Free existing cursor</summary>
    /// <param name="cur">Cursor object</param>
    public void CursorFree(Efl.TextCursorCursor cur) {
                                 Efl.TextCursorConcrete.NativeMethods.efl_text_cursor_free_ptr.Value.Delegate(this.NativeHandle,cur);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Check if two cursors are equal</summary>
    /// <param name="cur1">Cursor 1 object</param>
    /// <param name="cur2">Cursor 2 object</param>
    /// <returns><c>true</c> if cursors are equal, <c>false</c> otherwise</returns>
    public bool CursorEqual(Efl.TextCursorCursor cur1, Efl.TextCursorCursor cur2) {
                                                         var _ret_var = Efl.TextCursorConcrete.NativeMethods.efl_text_cursor_equal_ptr.Value.Delegate(this.NativeHandle,cur1, cur2);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Compare two cursors</summary>
    /// <param name="cur1">Cursor 1 object</param>
    /// <param name="cur2">Cursor 2 object</param>
    /// <returns>Difference between cursors</returns>
    public int CursorCompare(Efl.TextCursorCursor cur1, Efl.TextCursorCursor cur2) {
                                                         var _ret_var = Efl.TextCursorConcrete.NativeMethods.efl_text_cursor_compare_ptr.Value.Delegate(this.NativeHandle,cur1, cur2);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Copy existing cursor</summary>
    /// <param name="dst">Destination cursor</param>
    /// <param name="src">Source cursor</param>
    public void CursorCopy(Efl.TextCursorCursor dst, Efl.TextCursorCursor src) {
                                                         Efl.TextCursorConcrete.NativeMethods.efl_text_cursor_copy_ptr.Value.Delegate(this.NativeHandle,dst, src);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Advances to the next character</summary>
    /// <param name="cur">Cursor object</param>
    public void CursorCharNext(Efl.TextCursorCursor cur) {
                                 Efl.TextCursorConcrete.NativeMethods.efl_text_cursor_char_next_ptr.Value.Delegate(this.NativeHandle,cur);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Advances to the previous character</summary>
    /// <param name="cur">Cursor object</param>
    public void CursorCharPrev(Efl.TextCursorCursor cur) {
                                 Efl.TextCursorConcrete.NativeMethods.efl_text_cursor_char_prev_ptr.Value.Delegate(this.NativeHandle,cur);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Advances to the next grapheme cluster</summary>
    /// <param name="cur">Cursor object</param>
    public void CursorClusterNext(Efl.TextCursorCursor cur) {
                                 Efl.TextCursorConcrete.NativeMethods.efl_text_cursor_cluster_next_ptr.Value.Delegate(this.NativeHandle,cur);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Advances to the previous grapheme cluster</summary>
    /// <param name="cur">Cursor object</param>
    public void CursorClusterPrev(Efl.TextCursorCursor cur) {
                                 Efl.TextCursorConcrete.NativeMethods.efl_text_cursor_cluster_prev_ptr.Value.Delegate(this.NativeHandle,cur);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Advances to the first character in this paragraph</summary>
    /// <param name="cur">Cursor object</param>
    public void CursorParagraphCharFirst(Efl.TextCursorCursor cur) {
                                 Efl.TextCursorConcrete.NativeMethods.efl_text_cursor_paragraph_char_first_ptr.Value.Delegate(this.NativeHandle,cur);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Advances to the last character in this paragraph</summary>
    /// <param name="cur">Cursor object</param>
    public void CursorParagraphCharLast(Efl.TextCursorCursor cur) {
                                 Efl.TextCursorConcrete.NativeMethods.efl_text_cursor_paragraph_char_last_ptr.Value.Delegate(this.NativeHandle,cur);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Advance to current word start</summary>
    /// <param name="cur">Cursor object</param>
    public void CursorWordStart(Efl.TextCursorCursor cur) {
                                 Efl.TextCursorConcrete.NativeMethods.efl_text_cursor_word_start_ptr.Value.Delegate(this.NativeHandle,cur);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Advance to current word end</summary>
    /// <param name="cur">Cursor object</param>
    public void CursorWordEnd(Efl.TextCursorCursor cur) {
                                 Efl.TextCursorConcrete.NativeMethods.efl_text_cursor_word_end_ptr.Value.Delegate(this.NativeHandle,cur);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Advance to current line first character</summary>
    /// <param name="cur">Cursor object</param>
    public void CursorLineCharFirst(Efl.TextCursorCursor cur) {
                                 Efl.TextCursorConcrete.NativeMethods.efl_text_cursor_line_char_first_ptr.Value.Delegate(this.NativeHandle,cur);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Advance to current line last character</summary>
    /// <param name="cur">Cursor object</param>
    public void CursorLineCharLast(Efl.TextCursorCursor cur) {
                                 Efl.TextCursorConcrete.NativeMethods.efl_text_cursor_line_char_last_ptr.Value.Delegate(this.NativeHandle,cur);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Advance to current paragraph first character</summary>
    /// <param name="cur">Cursor object</param>
    public void CursorParagraphFirst(Efl.TextCursorCursor cur) {
                                 Efl.TextCursorConcrete.NativeMethods.efl_text_cursor_paragraph_first_ptr.Value.Delegate(this.NativeHandle,cur);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Advance to current paragraph last character</summary>
    /// <param name="cur">Cursor object</param>
    public void CursorParagraphLast(Efl.TextCursorCursor cur) {
                                 Efl.TextCursorConcrete.NativeMethods.efl_text_cursor_paragraph_last_ptr.Value.Delegate(this.NativeHandle,cur);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Advances to the start of the next text node</summary>
    /// <param name="cur">Cursor object</param>
    public void CursorParagraphNext(Efl.TextCursorCursor cur) {
                                 Efl.TextCursorConcrete.NativeMethods.efl_text_cursor_paragraph_next_ptr.Value.Delegate(this.NativeHandle,cur);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Advances to the end of the previous text node</summary>
    /// <param name="cur">Cursor object</param>
    public void CursorParagraphPrev(Efl.TextCursorCursor cur) {
                                 Efl.TextCursorConcrete.NativeMethods.efl_text_cursor_paragraph_prev_ptr.Value.Delegate(this.NativeHandle,cur);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Jump the cursor by the given number of lines</summary>
    /// <param name="cur">Cursor object</param>
    /// <param name="by">Number of lines</param>
    public void CursorLineJumpBy(Efl.TextCursorCursor cur, int by) {
                                                         Efl.TextCursorConcrete.NativeMethods.efl_text_cursor_line_jump_by_ptr.Value.Delegate(this.NativeHandle,cur, by);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Set cursor coordinates</summary>
    /// <param name="cur">Cursor object</param>
    /// <param name="x">X coord to set by.</param>
    /// <param name="y">Y coord to set by.</param>
    public void SetCursorCoord(Efl.TextCursorCursor cur, int x, int y) {
                                                                                 Efl.TextCursorConcrete.NativeMethods.efl_text_cursor_coord_set_ptr.Value.Delegate(this.NativeHandle,cur, x, y);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>Set cursor coordinates according to grapheme clusters. It does not allow to put a cursor to the middle of a grapheme cluster.</summary>
    /// <param name="cur">Cursor object</param>
    /// <param name="x">X coord to set by.</param>
    /// <param name="y">Y coord to set by.</param>
    public void SetCursorClusterCoord(Efl.TextCursorCursor cur, int x, int y) {
                                                                                 Efl.TextCursorConcrete.NativeMethods.efl_text_cursor_cluster_coord_set_ptr.Value.Delegate(this.NativeHandle,cur, x, y);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>Adds text to the current cursor position and set the cursor to *after* the start of the text just added.</summary>
    /// <param name="cur">Cursor object</param>
    /// <param name="text">Text to append (UTF-8 format).</param>
    /// <returns>Length of the appended text.</returns>
    public int CursorTextInsert(Efl.TextCursorCursor cur, System.String text) {
                                                         var _ret_var = Efl.TextCursorConcrete.NativeMethods.efl_text_cursor_text_insert_ptr.Value.Delegate(this.NativeHandle,cur, text);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Deletes a single character from position pointed by given cursor.</summary>
    /// <param name="cur">Cursor object</param>
    public void CursorCharDelete(Efl.TextCursorCursor cur) {
                                 Efl.TextCursorConcrete.NativeMethods.efl_text_cursor_char_delete_ptr.Value.Delegate(this.NativeHandle,cur);
        Eina.Error.RaiseIfUnhandledException();
                         }
#pragma warning restore CS0628
    private static IntPtr GetEflClassStatic()
    {
        return Efl.TextMarkupInteractiveConcrete.efl_text_markup_interactive_interface_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Eo.EoWrapper.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Efl);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_text_markup_interactive_markup_range_get_static_delegate == null)
            {
                efl_text_markup_interactive_markup_range_get_static_delegate = new efl_text_markup_interactive_markup_range_get_delegate(markup_range_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetMarkupRange") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_markup_interactive_markup_range_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_markup_interactive_markup_range_get_static_delegate) });
            }

            if (efl_text_markup_interactive_markup_range_set_static_delegate == null)
            {
                efl_text_markup_interactive_markup_range_set_static_delegate = new efl_text_markup_interactive_markup_range_set_delegate(markup_range_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetMarkupRange") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_markup_interactive_markup_range_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_markup_interactive_markup_range_set_static_delegate) });
            }

            if (efl_text_markup_interactive_cursor_markup_insert_static_delegate == null)
            {
                efl_text_markup_interactive_cursor_markup_insert_static_delegate = new efl_text_markup_interactive_cursor_markup_insert_delegate(cursor_markup_insert);
            }

            if (methods.FirstOrDefault(m => m.Name == "CursorMarkupInsert") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_markup_interactive_cursor_markup_insert"), func = Marshal.GetFunctionPointerForDelegate(efl_text_markup_interactive_cursor_markup_insert_static_delegate) });
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
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.TextMarkupInteractiveConcrete.efl_text_markup_interactive_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringPassOwnershipMarshaler))]
        private delegate System.String efl_text_markup_interactive_markup_range_get_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor start,  Efl.TextCursorCursor end);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringPassOwnershipMarshaler))]
        public delegate System.String efl_text_markup_interactive_markup_range_get_api_delegate(System.IntPtr obj,  Efl.TextCursorCursor start,  Efl.TextCursorCursor end);

        public static Efl.Eo.FunctionWrapper<efl_text_markup_interactive_markup_range_get_api_delegate> efl_text_markup_interactive_markup_range_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_markup_interactive_markup_range_get_api_delegate>(Module, "efl_text_markup_interactive_markup_range_get");

        private static System.String markup_range_get(System.IntPtr obj, System.IntPtr pd, Efl.TextCursorCursor start, Efl.TextCursorCursor end)
        {
            Eina.Log.Debug("function efl_text_markup_interactive_markup_range_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((ITextMarkupInteractive)ws.Target).GetMarkupRange(start, end);
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
                return efl_text_markup_interactive_markup_range_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), start, end);
            }
        }

        private static efl_text_markup_interactive_markup_range_get_delegate efl_text_markup_interactive_markup_range_get_static_delegate;

        
        private delegate void efl_text_markup_interactive_markup_range_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor start,  Efl.TextCursorCursor end, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringPassOwnershipMarshaler))] System.String markup);

        
        public delegate void efl_text_markup_interactive_markup_range_set_api_delegate(System.IntPtr obj,  Efl.TextCursorCursor start,  Efl.TextCursorCursor end, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringPassOwnershipMarshaler))] System.String markup);

        public static Efl.Eo.FunctionWrapper<efl_text_markup_interactive_markup_range_set_api_delegate> efl_text_markup_interactive_markup_range_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_markup_interactive_markup_range_set_api_delegate>(Module, "efl_text_markup_interactive_markup_range_set");

        private static void markup_range_set(System.IntPtr obj, System.IntPtr pd, Efl.TextCursorCursor start, Efl.TextCursorCursor end, System.String markup)
        {
            Eina.Log.Debug("function efl_text_markup_interactive_markup_range_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                    
                try
                {
                    ((ITextMarkupInteractive)ws.Target).SetMarkupRange(start, end, markup);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                        
            }
            else
            {
                efl_text_markup_interactive_markup_range_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), start, end, markup);
            }
        }

        private static efl_text_markup_interactive_markup_range_set_delegate efl_text_markup_interactive_markup_range_set_static_delegate;

        
        private delegate void efl_text_markup_interactive_cursor_markup_insert_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String markup);

        
        public delegate void efl_text_markup_interactive_cursor_markup_insert_api_delegate(System.IntPtr obj,  Efl.TextCursorCursor cur, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String markup);

        public static Efl.Eo.FunctionWrapper<efl_text_markup_interactive_cursor_markup_insert_api_delegate> efl_text_markup_interactive_cursor_markup_insert_ptr = new Efl.Eo.FunctionWrapper<efl_text_markup_interactive_cursor_markup_insert_api_delegate>(Module, "efl_text_markup_interactive_cursor_markup_insert");

        private static void cursor_markup_insert(System.IntPtr obj, System.IntPtr pd, Efl.TextCursorCursor cur, System.String markup)
        {
            Eina.Log.Debug("function efl_text_markup_interactive_cursor_markup_insert was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((ITextMarkupInteractive)ws.Target).CursorMarkupInsert(cur, markup);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_text_markup_interactive_cursor_markup_insert_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), cur, markup);
            }
        }

        private static efl_text_markup_interactive_cursor_markup_insert_delegate efl_text_markup_interactive_cursor_markup_insert_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

#if EFL_BETA
#pragma warning disable CS1591
public static class EflTextMarkupInteractiveConcrete_ExtensionMethods {
    
    
    
    
    
}
#pragma warning restore CS1591
#endif
