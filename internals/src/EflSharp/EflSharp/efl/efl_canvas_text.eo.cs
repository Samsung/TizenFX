#define EFL_BETA
#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Canvas {

/// <summary>Efl canvas text class</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Canvas.Text.NativeMethods]
[Efl.Eo.BindingEntity]
public class Text : Efl.Canvas.Object, Efl.IText, Efl.ITextAnnotate, Efl.ITextCursor, Efl.ITextFont, Efl.ITextFormat, Efl.ITextMarkup, Efl.ITextMarkupInteractive, Efl.ITextStyle, Efl.Canvas.Filter.IInternal, Efl.Gfx.IFilter, Efl.Ui.II18n
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(Text))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] internal static extern System.IntPtr
        efl_canvas_text_class_get();
    /// <summary>Initializes a new instance of the <see cref="Text"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public Text(Efl.Object parent= null
            ) : base(efl_canvas_text_class_get(), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected Text(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Text"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected Text(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Text"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected Text(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }

    /// <summary>Called when cursor changed</summary>
    public event EventHandler CursorChangedEvt
    {
        add
        {
            lock (eflBindingEventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        EventArgs args = EventArgs.Empty;
                        try
                        {
                            value?.Invoke(obj, args);
                        }
                        catch (Exception e)
                        {
                            Eina.Log.Error(e.ToString());
                            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                        }
                    }
                };

                string key = "_EFL_CANVAS_TEXT_EVENT_CURSOR_CHANGED";
                AddNativeEventHandler(efl.Libs.Evas, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_CANVAS_TEXT_EVENT_CURSOR_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }
    /// <summary>Method to raise event CursorChangedEvt.</summary>
    public void OnCursorChangedEvt(EventArgs e)
    {
        var key = "_EFL_CANVAS_TEXT_EVENT_CURSOR_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Evas, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when canvas text changed</summary>
    public event EventHandler ChangedEvt
    {
        add
        {
            lock (eflBindingEventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        EventArgs args = EventArgs.Empty;
                        try
                        {
                            value?.Invoke(obj, args);
                        }
                        catch (Exception e)
                        {
                            Eina.Log.Error(e.ToString());
                            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                        }
                    }
                };

                string key = "_EFL_CANVAS_TEXT_EVENT_CHANGED";
                AddNativeEventHandler(efl.Libs.Evas, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_CANVAS_TEXT_EVENT_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }
    /// <summary>Method to raise event ChangedEvt.</summary>
    public void OnChangedEvt(EventArgs e)
    {
        var key = "_EFL_CANVAS_TEXT_EVENT_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Evas, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when the property <see cref="Efl.Canvas.Text.GetStyleInsets"/> changed.</summary>
    public event EventHandler StyleInsetsChangedEvt
    {
        add
        {
            lock (eflBindingEventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        EventArgs args = EventArgs.Empty;
                        try
                        {
                            value?.Invoke(obj, args);
                        }
                        catch (Exception e)
                        {
                            Eina.Log.Error(e.ToString());
                            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                        }
                    }
                };

                string key = "_EFL_CANVAS_TEXT_EVENT_STYLE_INSETS_CHANGED";
                AddNativeEventHandler(efl.Libs.Evas, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_CANVAS_TEXT_EVENT_STYLE_INSETS_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }
    /// <summary>Method to raise event StyleInsetsChangedEvt.</summary>
    public void OnStyleInsetsChangedEvt(EventArgs e)
    {
        var key = "_EFL_CANVAS_TEXT_EVENT_STYLE_INSETS_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Evas, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Whether the object is empty (no text) or not</summary>
    /// <returns><c>true</c> if empty, <c>false</c> otherwise</returns>
    virtual public bool GetIsEmpty() {
         var _ret_var = Efl.Canvas.Text.NativeMethods.efl_canvas_text_is_empty_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Gets the left, right, top and bottom insets of the text.
    /// The inset is any applied padding on the text.</summary>
    /// <param name="l">Left padding</param>
    /// <param name="r">Right padding</param>
    /// <param name="t">Top padding</param>
    /// <param name="b">Bottom padding</param>
    virtual public void GetStyleInsets(out int l, out int r, out int t, out int b) {
                                                                                                         Efl.Canvas.Text.NativeMethods.efl_canvas_text_style_insets_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out l, out r, out t, out b);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>BiDi delimiters are used for in-paragraph separation of bidi segments. This is useful, for example, in the recipient fields of e-mail clients where bidi oddities can occur when mixing RTL and LTR.</summary>
    /// <returns>A null terminated string of delimiters, e.g &quot;,|&quot; or <c>null</c> if empty</returns>
    virtual public System.String GetBidiDelimiters() {
         var _ret_var = Efl.Canvas.Text.NativeMethods.efl_canvas_text_bidi_delimiters_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>BiDi delimiters are used for in-paragraph separation of bidi segments. This is useful, for example, in the recipient fields of e-mail clients where bidi oddities can occur when mixing RTL and LTR.</summary>
    /// <param name="delim">A null terminated string of delimiters, e.g &quot;,|&quot; or <c>null</c> if empty</param>
    virtual public void SetBidiDelimiters(System.String delim) {
                                 Efl.Canvas.Text.NativeMethods.efl_canvas_text_bidi_delimiters_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),delim);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>When <c>true</c>, newline character will behave as a paragraph separator.</summary>
    /// <returns><c>true</c> for legacy mode, <c>false</c> otherwise</returns>
    virtual public bool GetLegacyNewline() {
         var _ret_var = Efl.Canvas.Text.NativeMethods.efl_canvas_text_legacy_newline_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>When <c>true</c>, newline character will behave as a paragraph separator.</summary>
    /// <param name="mode"><c>true</c> for legacy mode, <c>false</c> otherwise</param>
    virtual public void SetLegacyNewline(bool mode) {
                                 Efl.Canvas.Text.NativeMethods.efl_canvas_text_legacy_newline_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),mode);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The text style of the object.
    /// <c>key</c> is how you reference the style (for deletion or fetching). <c>NULL</c> as key indicates the style has the highest priority (default style). The style priority is the order of creation, styles created first are applied first with the exception of <c>NULL</c> which is implicitly first.
    /// 
    /// Set <c>style</c> to <c>NULL</c> to delete it.</summary>
    /// <param name="key">The name to the style. <c>NULL</c> is the default style</param>
    /// <returns>The style</returns>
    virtual public System.String GetStyle(System.String key) {
                                 var _ret_var = Efl.Canvas.Text.NativeMethods.efl_canvas_text_style_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),key);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>The text style of the object.
    /// <c>key</c> is how you reference the style (for deletion or fetching). <c>NULL</c> as key indicates the style has the highest priority (default style). The style priority is the order of creation, styles created first are applied first with the exception of <c>NULL</c> which is implicitly first.
    /// 
    /// Set <c>style</c> to <c>NULL</c> to delete it.</summary>
    /// <param name="key">The name to the style. <c>NULL</c> is the default style</param>
    /// <param name="style">The style</param>
    virtual public void SetStyle(System.String key, System.String style) {
                                                         Efl.Canvas.Text.NativeMethods.efl_canvas_text_style_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),key, style);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>The formatted width and height.
    /// This calculates the actual size after restricting the textblock to the current size of the object.
    /// 
    /// The main difference between this and <see cref="Efl.Canvas.Text.GetSizeNative"/> is that the &quot;native&quot; function does not wrapping into account it just calculates the real width of the object if it was placed on an infinite canvas, while this function gives the size after wrapping according to the size restrictions of the object.
    /// 
    /// For example for a textblock containing the text: &quot;You shall not pass!&quot; with no margins or padding and assuming a monospace font and a size of 7x10 char widths (for simplicity) has a native size of 19x1 and a formatted size of 5x4.</summary>
    /// <param name="w">The width of the object.</param>
    /// <param name="h">The height of the object.</param>
    virtual public void GetSizeFormatted(out int w, out int h) {
                                                         Efl.Canvas.Text.NativeMethods.efl_canvas_text_size_formatted_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out w, out h);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>The native width and height.
    /// This calculates the actual size without taking account the current size of the object.
    /// 
    /// The main difference between this and <see cref="Efl.Canvas.Text.GetSizeFormatted"/> is that the &quot;native&quot; function does not take wrapping into account it just calculates the real width of the object if it was placed on an infinite canvas, while the &quot;formatted&quot; function gives the size after  wrapping text according to the size restrictions of the object.
    /// 
    /// For example for a textblock containing the text: &quot;You shall not pass!&quot; with no margins or padding and assuming a monospace font and a size of 7x10 char widths (for simplicity) has a native size of 19x1 and a formatted size of 5x4.</summary>
    /// <param name="w">The width returned.</param>
    /// <param name="h">The height returned.</param>
    virtual public void GetSizeNative(out int w, out int h) {
                                                         Efl.Canvas.Text.NativeMethods.efl_canvas_text_size_native_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out w, out h);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Returns the currently visible range.
    /// The given <c>start</c> and <c>end</c> cursor act like out-variables here, as they are set to the positions of the start and the end of the visible range in the text, respectively.</summary>
    /// <param name="start">Range start position</param>
    /// <param name="end">Range end position</param>
    /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
    virtual public bool GetVisibleRange(Efl.TextCursorCursor start, Efl.TextCursorCursor end) {
                                                         var _ret_var = Efl.Canvas.Text.NativeMethods.efl_canvas_text_visible_range_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),start, end);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Returns the text in the range between <c>cur1</c> and <c>cur2</c>.</summary>
    /// <param name="cur1">Start of range</param>
    /// <param name="cur2">End of range</param>
    /// <returns>The text in the given range</returns>
    virtual public System.String GetRangeText(Efl.TextCursorCursor cur1, Efl.TextCursorCursor cur2) {
                                                         var _ret_var = Efl.Canvas.Text.NativeMethods.efl_canvas_text_range_text_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),cur1, cur2);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Get the geometry of a range in the text.
    /// The geometry is represented as rectangles for each of the line segments in the given range [<c>cur1</c>, <c>cur2</c>].</summary>
    /// <param name="cur1">Start of range</param>
    /// <param name="cur2">End of range</param>
    /// <returns>Iterator on all geoemtries of the given range</returns>
    virtual public Eina.Iterator<Eina.Rect> GetRangeGeometry(Efl.TextCursorCursor cur1, Efl.TextCursorCursor cur2) {
                                                         var _ret_var = Efl.Canvas.Text.NativeMethods.efl_canvas_text_range_geometry_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),cur1, cur2);
        Eina.Error.RaiseIfUnhandledException();
                                        return new Eina.Iterator<Eina.Rect>(_ret_var, true);
 }
    /// <summary>Get the &quot;simple&quot; geometry of a range.
    /// The geometry is the geometry in which rectangles in middle lines of range are merged into one big rectangle. This is an optimized version of <see cref="Efl.Canvas.Text.GetRangeGeometry"/>.</summary>
    /// <param name="cur1">Start of range</param>
    /// <param name="cur2">End of range</param>
    /// <returns>Iterator on all simple geometries of the given range</returns>
    virtual public Eina.Iterator<Eina.Rect> GetRangeSimpleGeometry(Efl.TextCursorCursor cur1, Efl.TextCursorCursor cur2) {
                                                         var _ret_var = Efl.Canvas.Text.NativeMethods.efl_canvas_text_range_simple_geometry_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),cur1, cur2);
        Eina.Error.RaiseIfUnhandledException();
                                        return new Eina.Iterator<Eina.Rect>(_ret_var, true);
 }
    /// <summary>Deletes the range between given cursors.
    /// This removes all the text in given range [<c>start</c>,<c>end</c>].</summary>
    /// <param name="cur1">Range start position</param>
    /// <param name="cur2">Range end position</param>
    virtual public void RangeDelete(Efl.TextCursorCursor cur1, Efl.TextCursorCursor cur2) {
                                                         Efl.Canvas.Text.NativeMethods.efl_canvas_text_range_delete_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),cur1, cur2);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Add obstacle evas object <c>eo_obs</c> to be observed during layout of text.
    /// The textblock does the layout of the text according to the position of the obstacle.</summary>
    /// <param name="eo_obs">Obstacle object</param>
    /// <returns><c>true</c> on success, <c>false</c> otherwise.</returns>
    virtual public bool AddObstacle(Efl.Canvas.Object eo_obs) {
                                 var _ret_var = Efl.Canvas.Text.NativeMethods.efl_canvas_text_obstacle_add_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),eo_obs);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Removes <c>eo_obs</c> from observation during text layout.</summary>
    /// <param name="eo_obs">Obstacle object</param>
    /// <returns><c>true</c> on success, <c>false</c> otherwise.</returns>
    virtual public bool DelObstacle(Efl.Canvas.Object eo_obs) {
                                 var _ret_var = Efl.Canvas.Text.NativeMethods.efl_canvas_text_obstacle_del_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),eo_obs);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Triggers for relayout due to obstacles&apos; state change.
    /// The obstacles alone don&apos;t affect the layout, until this is called. Use this after doing changes (moving, positioning etc.) in the obstacles that you  would like to be considered in the layout.
    /// 
    /// For example: if you have just repositioned the obstacles to differrent coordinates relative to the textblock, you need to call this so it will consider this new state and will relayout the text.</summary>
    virtual public void UpdateObstacles() {
         Efl.Canvas.Text.NativeMethods.efl_canvas_text_obstacles_update_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Requests to layout the text off the mainloop.
    /// Once layout is complete, the result is returned as <see cref="Eina.Rect"/>, with w, h fields set.</summary>
    /// <returns>Future for layout result</returns>
    virtual public  Eina.Future AsyncLayout() {
         var _ret_var = Efl.Canvas.Text.NativeMethods.efl_canvas_text_async_layout_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Retrieves the text string currently being displayed by the given text object.
    /// Do not free() the return value.
    /// 
    /// See also <see cref="Efl.IText.GetText"/>.
    /// (Since EFL 1.22)</summary>
    /// <returns>Text string to display on it.</returns>
    virtual public System.String GetText() {
         var _ret_var = Efl.ITextConcrete.NativeMethods.efl_text_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Sets the text string to be displayed by the given text object.
    /// See also <see cref="Efl.IText.GetText"/>.
    /// (Since EFL 1.22)</summary>
    /// <param name="text">Text string to display on it.</param>
    virtual public void SetText(System.String text) {
                                 Efl.ITextConcrete.NativeMethods.efl_text_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),text);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>A new format for <c>annotation</c>.
    /// This will replace the format applied by <c>annotation</c> with <c>format</c>. Assumes that <c>annotation</c> is a handle for an existing annotation, i.e. one that was added using <see cref="Efl.ITextAnnotate.AnnotationInsert"/> to this object. Otherwise, this will fail and return <c>false</c>.</summary>
    /// <param name="annotation">Given annotation</param>
    /// <returns>The new format for the given annotation</returns>
    virtual public System.String GetAnnotation(Efl.TextAnnotateAnnotation annotation) {
                                 var _ret_var = Efl.ITextAnnotateConcrete.NativeMethods.efl_text_annotation_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),annotation);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>A new format for <c>annotation</c>.
    /// This will replace the format applied by <c>annotation</c> with <c>format</c>. Assumes that <c>annotation</c> is a handle for an existing annotation, i.e. one that was added using <see cref="Efl.ITextAnnotate.AnnotationInsert"/> to this object. Otherwise, this will fail and return <c>false</c>.</summary>
    /// <param name="annotation">Given annotation</param>
    /// <param name="format">The new format for the given annotation</param>
    /// <returns><c>true</c> on success, <c>false</c> otherwise.</returns>
    virtual public bool SetAnnotation(Efl.TextAnnotateAnnotation annotation, System.String format) {
                                                         var _ret_var = Efl.ITextAnnotateConcrete.NativeMethods.efl_text_annotation_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),annotation, format);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>The object-item annotation at the cursor&apos;s position.</summary>
    /// <param name="cur">Cursor object</param>
    /// <returns>Annotation</returns>
    virtual public Efl.TextAnnotateAnnotation GetCursorItemAnnotation(Efl.TextCursorCursor cur) {
                                 var _ret_var = Efl.ITextAnnotateConcrete.NativeMethods.efl_text_cursor_item_annotation_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),cur);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Returns an iterator of all the handles in a range.</summary>
    /// <param name="start">Start of range</param>
    /// <param name="end">End of range</param>
    /// <returns>Handle of the Annotation</returns>
    virtual public Eina.Iterator<Efl.TextAnnotateAnnotation> GetRangeAnnotations(Efl.TextCursorCursor start, Efl.TextCursorCursor end) {
                                                         var _ret_var = Efl.ITextAnnotateConcrete.NativeMethods.efl_text_range_annotations_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),start, end);
        Eina.Error.RaiseIfUnhandledException();
                                        return new Eina.Iterator<Efl.TextAnnotateAnnotation>(_ret_var, true);
 }
    /// <summary>Inserts an annotation format in a specified range [<c>start</c>, <c>end</c> - 1].
    /// The <c>format</c> will be applied to the given range, and the <c>annotation</c> handle will be returned for further handling.</summary>
    /// <param name="start">Start of range</param>
    /// <param name="end">End of range</param>
    /// <param name="format">Annotation format</param>
    /// <returns>Handle of inserted annotation</returns>
    virtual public Efl.TextAnnotateAnnotation AnnotationInsert(Efl.TextCursorCursor start, Efl.TextCursorCursor end, System.String format) {
                                                                                 var _ret_var = Efl.ITextAnnotateConcrete.NativeMethods.efl_text_annotation_insert_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),start, end, format);
        Eina.Error.RaiseIfUnhandledException();
                                                        return _ret_var;
 }
    /// <summary>Deletes given annotation.
    /// All formats applied by <c>annotation</c> will be removed and it will be deleted.</summary>
    /// <param name="annotation">Annotation to be removed</param>
    /// <returns><c>true</c> on success, <c>false</c> otherwise.</returns>
    virtual public bool DelAnnotation(Efl.TextAnnotateAnnotation annotation) {
                                 var _ret_var = Efl.ITextAnnotateConcrete.NativeMethods.efl_text_annotation_del_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),annotation);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Sets given cursors to the start and end positions of the annotation.
    /// The cursors <c>start</c> and <c>end</c> will be set to the start and end positions of the given annotation <c>annotation</c>.</summary>
    /// <param name="annotation">Annotation handle to query</param>
    /// <param name="start">Cursor to be set to the start position of the annotation in the text</param>
    /// <param name="end">Cursor to be set to the end position of the annotation in the text</param>
    virtual public void GetAnnotationPositions(Efl.TextAnnotateAnnotation annotation, Efl.TextCursorCursor start, Efl.TextCursorCursor end) {
                                                                                 Efl.ITextAnnotateConcrete.NativeMethods.efl_text_annotation_positions_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),annotation, start, end);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>Whether this is an &quot;item&quot; type of annotation. Should be used before querying the annotation&apos;s geometry, as only &quot;item&quot; annotations have a geometry.
    /// see <see cref="Efl.ITextAnnotate.CursorItemInsert"/> see <see cref="Efl.ITextAnnotate.GetItemGeometry"/></summary>
    /// <param name="annotation">Given annotation</param>
    /// <returns><c>true</c> if given annotation is an object item, <c>false</c> otherwise</returns>
    virtual public bool AnnotationIsItem(Efl.TextAnnotateAnnotation annotation) {
                                 var _ret_var = Efl.ITextAnnotateConcrete.NativeMethods.efl_text_annotation_is_item_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),annotation);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Queries a given object item for its geometry.
    /// Note that the provided annotation should be an object item type.</summary>
    /// <param name="an">Given annotation to query</param>
    /// <param name="x">X coordinate of the annotation</param>
    /// <param name="y">Y coordinate of the annotation</param>
    /// <param name="w">Width of the annotation</param>
    /// <param name="h">Height of the annotation</param>
    /// <returns><c>true</c> if given annotation is an object item, <c>false</c> otherwise</returns>
    virtual public bool GetItemGeometry(Efl.TextAnnotateAnnotation an, out int x, out int y, out int w, out int h) {
                                                                                                                                 var _ret_var = Efl.ITextAnnotateConcrete.NativeMethods.efl_text_item_geometry_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),an, out x, out y, out w, out h);
        Eina.Error.RaiseIfUnhandledException();
                                                                                        return _ret_var;
 }
    /// <summary>Inserts a object item at specified position.
    /// This adds a placeholder to be queried by higher-level code, which in turn place graphics on top of it. It essentially places an OBJECT REPLACEMENT CHARACTER and set a special annotation to it.</summary>
    /// <param name="cur">Cursor object</param>
    /// <param name="item">Item key to be used in higher-up code to query and decided what image, emoticon etc. to embed.</param>
    /// <param name="format">Size format of the inserted item. This hints how to size the item in the text.</param>
    /// <returns>The annotation handle of the inserted item.</returns>
    virtual public Efl.TextAnnotateAnnotation CursorItemInsert(Efl.TextCursorCursor cur, System.String item, System.String format) {
                                                                                 var _ret_var = Efl.ITextAnnotateConcrete.NativeMethods.efl_text_cursor_item_insert_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),cur, item, format);
        Eina.Error.RaiseIfUnhandledException();
                                                        return _ret_var;
 }
    /// <summary>The object&apos;s main cursor.</summary>
    /// <param name="get_type">Cursor type</param>
    /// <returns>Text cursor object</returns>
    virtual public Efl.TextCursorCursor GetTextCursor(Efl.TextCursorGetType get_type) {
                                 var _ret_var = Efl.ITextCursorConcrete.NativeMethods.efl_text_cursor_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),get_type);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Cursor position</summary>
    /// <param name="cur">Cursor object</param>
    /// <returns>Cursor position</returns>
    virtual public int GetCursorPosition(Efl.TextCursorCursor cur) {
                                 var _ret_var = Efl.ITextCursorConcrete.NativeMethods.efl_text_cursor_position_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),cur);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Cursor position</summary>
    /// <param name="cur">Cursor object</param>
    /// <param name="position">Cursor position</param>
    virtual public void SetCursorPosition(Efl.TextCursorCursor cur, int position) {
                                                         Efl.ITextCursorConcrete.NativeMethods.efl_text_cursor_position_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),cur, position);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>The content of the cursor (the character under the cursor)</summary>
    /// <param name="cur">Cursor object</param>
    /// <returns>The unicode codepoint of the character</returns>
    virtual public Eina.Unicode GetCursorContent(Efl.TextCursorCursor cur) {
                                 var _ret_var = Efl.ITextCursorConcrete.NativeMethods.efl_text_cursor_content_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),cur);
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
    virtual public bool GetCursorGeometry(Efl.TextCursorCursor cur, Efl.TextCursorType ctype, out int cx, out int cy, out int cw, out int ch, out int cx2, out int cy2, out int cw2, out int ch2) {
                                                                                                                                                                                                                                                         var _ret_var = Efl.ITextCursorConcrete.NativeMethods.efl_text_cursor_geometry_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),cur, ctype, out cx, out cy, out cw, out ch, out cx2, out cy2, out cw2, out ch2);
        Eina.Error.RaiseIfUnhandledException();
                                                                                                                                                                        return _ret_var;
 }
    /// <summary>Create new cursor</summary>
    /// <returns>Cursor object</returns>
    virtual public Efl.TextCursorCursor NewCursor() {
         var _ret_var = Efl.ITextCursorConcrete.NativeMethods.efl_text_cursor_new_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Free existing cursor</summary>
    /// <param name="cur">Cursor object</param>
    virtual public void CursorFree(Efl.TextCursorCursor cur) {
                                 Efl.ITextCursorConcrete.NativeMethods.efl_text_cursor_free_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),cur);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Check if two cursors are equal</summary>
    /// <param name="cur1">Cursor 1 object</param>
    /// <param name="cur2">Cursor 2 object</param>
    /// <returns><c>true</c> if cursors are equal, <c>false</c> otherwise</returns>
    virtual public bool CursorEqual(Efl.TextCursorCursor cur1, Efl.TextCursorCursor cur2) {
                                                         var _ret_var = Efl.ITextCursorConcrete.NativeMethods.efl_text_cursor_equal_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),cur1, cur2);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Compare two cursors</summary>
    /// <param name="cur1">Cursor 1 object</param>
    /// <param name="cur2">Cursor 2 object</param>
    /// <returns>Difference between cursors</returns>
    virtual public int CursorCompare(Efl.TextCursorCursor cur1, Efl.TextCursorCursor cur2) {
                                                         var _ret_var = Efl.ITextCursorConcrete.NativeMethods.efl_text_cursor_compare_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),cur1, cur2);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Copy existing cursor</summary>
    /// <param name="dst">Destination cursor</param>
    /// <param name="src">Source cursor</param>
    virtual public void CursorCopy(Efl.TextCursorCursor dst, Efl.TextCursorCursor src) {
                                                         Efl.ITextCursorConcrete.NativeMethods.efl_text_cursor_copy_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),dst, src);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Advances to the next character</summary>
    /// <param name="cur">Cursor object</param>
    virtual public void CursorCharNext(Efl.TextCursorCursor cur) {
                                 Efl.ITextCursorConcrete.NativeMethods.efl_text_cursor_char_next_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),cur);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Advances to the previous character</summary>
    /// <param name="cur">Cursor object</param>
    virtual public void CursorCharPrev(Efl.TextCursorCursor cur) {
                                 Efl.ITextCursorConcrete.NativeMethods.efl_text_cursor_char_prev_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),cur);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Advances to the next grapheme cluster</summary>
    /// <param name="cur">Cursor object</param>
    virtual public void CursorClusterNext(Efl.TextCursorCursor cur) {
                                 Efl.ITextCursorConcrete.NativeMethods.efl_text_cursor_cluster_next_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),cur);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Advances to the previous grapheme cluster</summary>
    /// <param name="cur">Cursor object</param>
    virtual public void CursorClusterPrev(Efl.TextCursorCursor cur) {
                                 Efl.ITextCursorConcrete.NativeMethods.efl_text_cursor_cluster_prev_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),cur);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Advances to the first character in this paragraph</summary>
    /// <param name="cur">Cursor object</param>
    virtual public void CursorParagraphCharFirst(Efl.TextCursorCursor cur) {
                                 Efl.ITextCursorConcrete.NativeMethods.efl_text_cursor_paragraph_char_first_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),cur);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Advances to the last character in this paragraph</summary>
    /// <param name="cur">Cursor object</param>
    virtual public void CursorParagraphCharLast(Efl.TextCursorCursor cur) {
                                 Efl.ITextCursorConcrete.NativeMethods.efl_text_cursor_paragraph_char_last_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),cur);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Advance to current word start</summary>
    /// <param name="cur">Cursor object</param>
    virtual public void CursorWordStart(Efl.TextCursorCursor cur) {
                                 Efl.ITextCursorConcrete.NativeMethods.efl_text_cursor_word_start_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),cur);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Advance to current word end</summary>
    /// <param name="cur">Cursor object</param>
    virtual public void CursorWordEnd(Efl.TextCursorCursor cur) {
                                 Efl.ITextCursorConcrete.NativeMethods.efl_text_cursor_word_end_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),cur);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Advance to current line first character</summary>
    /// <param name="cur">Cursor object</param>
    virtual public void CursorLineCharFirst(Efl.TextCursorCursor cur) {
                                 Efl.ITextCursorConcrete.NativeMethods.efl_text_cursor_line_char_first_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),cur);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Advance to current line last character</summary>
    /// <param name="cur">Cursor object</param>
    virtual public void CursorLineCharLast(Efl.TextCursorCursor cur) {
                                 Efl.ITextCursorConcrete.NativeMethods.efl_text_cursor_line_char_last_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),cur);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Advance to current paragraph first character</summary>
    /// <param name="cur">Cursor object</param>
    virtual public void CursorParagraphFirst(Efl.TextCursorCursor cur) {
                                 Efl.ITextCursorConcrete.NativeMethods.efl_text_cursor_paragraph_first_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),cur);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Advance to current paragraph last character</summary>
    /// <param name="cur">Cursor object</param>
    virtual public void CursorParagraphLast(Efl.TextCursorCursor cur) {
                                 Efl.ITextCursorConcrete.NativeMethods.efl_text_cursor_paragraph_last_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),cur);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Advances to the start of the next text node</summary>
    /// <param name="cur">Cursor object</param>
    virtual public void CursorParagraphNext(Efl.TextCursorCursor cur) {
                                 Efl.ITextCursorConcrete.NativeMethods.efl_text_cursor_paragraph_next_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),cur);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Advances to the end of the previous text node</summary>
    /// <param name="cur">Cursor object</param>
    virtual public void CursorParagraphPrev(Efl.TextCursorCursor cur) {
                                 Efl.ITextCursorConcrete.NativeMethods.efl_text_cursor_paragraph_prev_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),cur);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Jump the cursor by the given number of lines</summary>
    /// <param name="cur">Cursor object</param>
    /// <param name="by">Number of lines</param>
    virtual public void CursorLineJumpBy(Efl.TextCursorCursor cur, int by) {
                                                         Efl.ITextCursorConcrete.NativeMethods.efl_text_cursor_line_jump_by_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),cur, by);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Set cursor coordinates</summary>
    /// <param name="cur">Cursor object</param>
    /// <param name="x">X coord to set by.</param>
    /// <param name="y">Y coord to set by.</param>
    virtual public void SetCursorCoord(Efl.TextCursorCursor cur, int x, int y) {
                                                                                 Efl.ITextCursorConcrete.NativeMethods.efl_text_cursor_coord_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),cur, x, y);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>Set cursor coordinates according to grapheme clusters. It does not allow to put a cursor to the middle of a grapheme cluster.</summary>
    /// <param name="cur">Cursor object</param>
    /// <param name="x">X coord to set by.</param>
    /// <param name="y">Y coord to set by.</param>
    virtual public void SetCursorClusterCoord(Efl.TextCursorCursor cur, int x, int y) {
                                                                                 Efl.ITextCursorConcrete.NativeMethods.efl_text_cursor_cluster_coord_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),cur, x, y);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>Adds text to the current cursor position and set the cursor to *after* the start of the text just added.</summary>
    /// <param name="cur">Cursor object</param>
    /// <param name="text">Text to append (UTF-8 format).</param>
    /// <returns>Length of the appended text.</returns>
    virtual public int CursorTextInsert(Efl.TextCursorCursor cur, System.String text) {
                                                         var _ret_var = Efl.ITextCursorConcrete.NativeMethods.efl_text_cursor_text_insert_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),cur, text);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Deletes a single character from position pointed by given cursor.</summary>
    /// <param name="cur">Cursor object</param>
    virtual public void CursorCharDelete(Efl.TextCursorCursor cur) {
                                 Efl.ITextCursorConcrete.NativeMethods.efl_text_cursor_char_delete_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),cur);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Retrieve the font family and size in use on a given text object.
    /// This function allows the font name and size of a text object to be queried. Remember that the font name string is still owned by Evas and should not have free() called on it by the caller of the function.
    /// 
    /// See also <see cref="Efl.ITextFont.GetFont"/>.</summary>
    /// <param name="font">The font family name or filename.</param>
    /// <param name="size">The font size, in points.</param>
    virtual public void GetFont(out System.String font, out Efl.Font.Size size) {
                                                         Efl.ITextFontConcrete.NativeMethods.efl_text_font_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out font, out size);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Set the font family, filename and size for a given text object.
    /// This function allows the font name and size of a text object to be set. The font string has to follow fontconfig&apos;s convention for naming fonts, as it&apos;s the underlying library used to query system fonts by Evas (see the fc-list command&apos;s output, on your system, to get an idea). Alternatively, youe can use the full path to a font file.
    /// 
    /// To skip changing font family pass null as font family. To skip changing font size pass 0 as font size.
    /// 
    /// See also <see cref="Efl.ITextFont.GetFont"/>, <see cref="Efl.ITextFont.GetFontSource"/>.</summary>
    /// <param name="font">The font family name or filename.</param>
    /// <param name="size">The font size, in points.</param>
    virtual public void SetFont(System.String font, Efl.Font.Size size) {
                                                         Efl.ITextFontConcrete.NativeMethods.efl_text_font_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),font, size);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Get the font file&apos;s path which is being used on a given text object.
    /// See <see cref="Efl.ITextFont.GetFont"/> for more details.</summary>
    /// <returns>The font file&apos;s path.</returns>
    virtual public System.String GetFontSource() {
         var _ret_var = Efl.ITextFontConcrete.NativeMethods.efl_text_font_source_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the font (source) file to be used on a given text object.
    /// This function allows the font file to be explicitly set for a given text object, overriding system lookup, which will first occur in the given file&apos;s contents.
    /// 
    /// See also <see cref="Efl.ITextFont.GetFont"/>.</summary>
    /// <param name="font_source">The font file&apos;s path.</param>
    virtual public void SetFontSource(System.String font_source) {
                                 Efl.ITextFontConcrete.NativeMethods.efl_text_font_source_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),font_source);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Comma-separated list of font fallbacks
    /// Will be used in case the primary font isn&apos;t available.</summary>
    /// <returns>Font name fallbacks</returns>
    virtual public System.String GetFontFallbacks() {
         var _ret_var = Efl.ITextFontConcrete.NativeMethods.efl_text_font_fallbacks_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Comma-separated list of font fallbacks
    /// Will be used in case the primary font isn&apos;t available.</summary>
    /// <param name="font_fallbacks">Font name fallbacks</param>
    virtual public void SetFontFallbacks(System.String font_fallbacks) {
                                 Efl.ITextFontConcrete.NativeMethods.efl_text_font_fallbacks_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),font_fallbacks);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Type of weight of the displayed font
    /// Default is <see cref="Efl.TextFontWeight.Normal"/>.</summary>
    /// <returns>Font weight</returns>
    virtual public Efl.TextFontWeight GetFontWeight() {
         var _ret_var = Efl.ITextFontConcrete.NativeMethods.efl_text_font_weight_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Type of weight of the displayed font
    /// Default is <see cref="Efl.TextFontWeight.Normal"/>.</summary>
    /// <param name="font_weight">Font weight</param>
    virtual public void SetFontWeight(Efl.TextFontWeight font_weight) {
                                 Efl.ITextFontConcrete.NativeMethods.efl_text_font_weight_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),font_weight);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Type of slant of the displayed font
    /// Default is <see cref="Efl.TextFontSlant.Normal"/>.</summary>
    /// <returns>Font slant</returns>
    virtual public Efl.TextFontSlant GetFontSlant() {
         var _ret_var = Efl.ITextFontConcrete.NativeMethods.efl_text_font_slant_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Type of slant of the displayed font
    /// Default is <see cref="Efl.TextFontSlant.Normal"/>.</summary>
    /// <param name="style">Font slant</param>
    virtual public void SetFontSlant(Efl.TextFontSlant style) {
                                 Efl.ITextFontConcrete.NativeMethods.efl_text_font_slant_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),style);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Type of width of the displayed font
    /// Default is <see cref="Efl.TextFontWidth.Normal"/>.</summary>
    /// <returns>Font width</returns>
    virtual public Efl.TextFontWidth GetFontWidth() {
         var _ret_var = Efl.ITextFontConcrete.NativeMethods.efl_text_font_width_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Type of width of the displayed font
    /// Default is <see cref="Efl.TextFontWidth.Normal"/>.</summary>
    /// <param name="width">Font width</param>
    virtual public void SetFontWidth(Efl.TextFontWidth width) {
                                 Efl.ITextFontConcrete.NativeMethods.efl_text_font_width_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),width);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Specific language of the displayed font
    /// This is used to lookup fonts suitable to the specified language, as well as helping the font shaper backend. The language <c>lang</c> can be either a code e.g &quot;en_US&quot;, &quot;auto&quot; to use the system locale, or &quot;none&quot;.</summary>
    /// <returns>Language</returns>
    virtual public System.String GetFontLang() {
         var _ret_var = Efl.ITextFontConcrete.NativeMethods.efl_text_font_lang_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Specific language of the displayed font
    /// This is used to lookup fonts suitable to the specified language, as well as helping the font shaper backend. The language <c>lang</c> can be either a code e.g &quot;en_US&quot;, &quot;auto&quot; to use the system locale, or &quot;none&quot;.</summary>
    /// <param name="lang">Language</param>
    virtual public void SetFontLang(System.String lang) {
                                 Efl.ITextFontConcrete.NativeMethods.efl_text_font_lang_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),lang);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The bitmap fonts have fixed size glyphs for several available sizes. Basically, it is not scalable. But, it needs to be scalable for some use cases. (ex. colorful emoji fonts)
    /// Default is <see cref="Efl.TextFontBitmapScalable.None"/>.</summary>
    /// <returns>Scalable</returns>
    virtual public Efl.TextFontBitmapScalable GetFontBitmapScalable() {
         var _ret_var = Efl.ITextFontConcrete.NativeMethods.efl_text_font_bitmap_scalable_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The bitmap fonts have fixed size glyphs for several available sizes. Basically, it is not scalable. But, it needs to be scalable for some use cases. (ex. colorful emoji fonts)
    /// Default is <see cref="Efl.TextFontBitmapScalable.None"/>.</summary>
    /// <param name="scalable">Scalable</param>
    virtual public void SetFontBitmapScalable(Efl.TextFontBitmapScalable scalable) {
                                 Efl.ITextFontConcrete.NativeMethods.efl_text_font_bitmap_scalable_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),scalable);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Ellipsis value (number from -1.0 to 1.0)</summary>
    /// <returns>Ellipsis value</returns>
    virtual public double GetEllipsis() {
         var _ret_var = Efl.ITextFormatConcrete.NativeMethods.efl_text_ellipsis_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Ellipsis value (number from -1.0 to 1.0)</summary>
    /// <param name="value">Ellipsis value</param>
    virtual public void SetEllipsis(double value) {
                                 Efl.ITextFormatConcrete.NativeMethods.efl_text_ellipsis_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),value);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Wrap mode for use in the text</summary>
    /// <returns>Wrap mode</returns>
    virtual public Efl.TextFormatWrap GetWrap() {
         var _ret_var = Efl.ITextFormatConcrete.NativeMethods.efl_text_wrap_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Wrap mode for use in the text</summary>
    /// <param name="wrap">Wrap mode</param>
    virtual public void SetWrap(Efl.TextFormatWrap wrap) {
                                 Efl.ITextFormatConcrete.NativeMethods.efl_text_wrap_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),wrap);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Multiline is enabled or not</summary>
    /// <returns><c>true</c> if multiline is enabled, <c>false</c> otherwise</returns>
    virtual public bool GetMultiline() {
         var _ret_var = Efl.ITextFormatConcrete.NativeMethods.efl_text_multiline_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Multiline is enabled or not</summary>
    /// <param name="enabled"><c>true</c> if multiline is enabled, <c>false</c> otherwise</param>
    virtual public void SetMultiline(bool enabled) {
                                 Efl.ITextFormatConcrete.NativeMethods.efl_text_multiline_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),enabled);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Horizontal alignment of text</summary>
    /// <returns>Alignment type</returns>
    virtual public Efl.TextFormatHorizontalAlignmentAutoType GetHalignAutoType() {
         var _ret_var = Efl.ITextFormatConcrete.NativeMethods.efl_text_halign_auto_type_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Horizontal alignment of text</summary>
    /// <param name="value">Alignment type</param>
    virtual public void SetHalignAutoType(Efl.TextFormatHorizontalAlignmentAutoType value) {
                                 Efl.ITextFormatConcrete.NativeMethods.efl_text_halign_auto_type_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),value);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Horizontal alignment of text</summary>
    /// <returns>Horizontal alignment value</returns>
    virtual public double GetHalign() {
         var _ret_var = Efl.ITextFormatConcrete.NativeMethods.efl_text_halign_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Horizontal alignment of text</summary>
    /// <param name="value">Horizontal alignment value</param>
    virtual public void SetHalign(double value) {
                                 Efl.ITextFormatConcrete.NativeMethods.efl_text_halign_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),value);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Vertical alignment of text</summary>
    /// <returns>Vertical alignment value</returns>
    virtual public double GetValign() {
         var _ret_var = Efl.ITextFormatConcrete.NativeMethods.efl_text_valign_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Vertical alignment of text</summary>
    /// <param name="value">Vertical alignment value</param>
    virtual public void SetValign(double value) {
                                 Efl.ITextFormatConcrete.NativeMethods.efl_text_valign_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),value);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Minimal line gap (top and bottom) for each line in the text
    /// <c>value</c> is absolute size.</summary>
    /// <returns>Line gap value</returns>
    virtual public double GetLinegap() {
         var _ret_var = Efl.ITextFormatConcrete.NativeMethods.efl_text_linegap_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Minimal line gap (top and bottom) for each line in the text
    /// <c>value</c> is absolute size.</summary>
    /// <param name="value">Line gap value</param>
    virtual public void SetLinegap(double value) {
                                 Efl.ITextFormatConcrete.NativeMethods.efl_text_linegap_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),value);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Relative line gap (top and bottom) for each line in the text
    /// The original line gap value is multiplied by <c>value</c>.</summary>
    /// <returns>Relative line gap value</returns>
    virtual public double GetLinerelgap() {
         var _ret_var = Efl.ITextFormatConcrete.NativeMethods.efl_text_linerelgap_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Relative line gap (top and bottom) for each line in the text
    /// The original line gap value is multiplied by <c>value</c>.</summary>
    /// <param name="value">Relative line gap value</param>
    virtual public void SetLinerelgap(double value) {
                                 Efl.ITextFormatConcrete.NativeMethods.efl_text_linerelgap_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),value);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Tabstops value</summary>
    /// <returns>Tapstops value</returns>
    virtual public int GetTabstops() {
         var _ret_var = Efl.ITextFormatConcrete.NativeMethods.efl_text_tabstops_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Tabstops value</summary>
    /// <param name="value">Tapstops value</param>
    virtual public void SetTabstops(int value) {
                                 Efl.ITextFormatConcrete.NativeMethods.efl_text_tabstops_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),value);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Whether text is a password</summary>
    /// <returns><c>true</c> if the text is a password, <c>false</c> otherwise</returns>
    virtual public bool GetPassword() {
         var _ret_var = Efl.ITextFormatConcrete.NativeMethods.efl_text_password_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Whether text is a password</summary>
    /// <param name="enabled"><c>true</c> if the text is a password, <c>false</c> otherwise</param>
    virtual public void SetPassword(bool enabled) {
                                 Efl.ITextFormatConcrete.NativeMethods.efl_text_password_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),enabled);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The character used to replace characters that can&apos;t be displayed
    /// Currently only used to replace characters if <see cref="Efl.ITextFormat.Password"/> is enabled.</summary>
    /// <returns>Replacement character</returns>
    virtual public System.String GetReplacementChar() {
         var _ret_var = Efl.ITextFormatConcrete.NativeMethods.efl_text_replacement_char_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The character used to replace characters that can&apos;t be displayed
    /// Currently only used to replace characters if <see cref="Efl.ITextFormat.Password"/> is enabled.</summary>
    /// <param name="repch">Replacement character</param>
    virtual public void SetReplacementChar(System.String repch) {
                                 Efl.ITextFormatConcrete.NativeMethods.efl_text_replacement_char_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),repch);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Markup property</summary>
    /// <returns>The markup-text representation set to this text.</returns>
    virtual public System.String GetMarkup() {
         var _ret_var = Efl.ITextMarkupConcrete.NativeMethods.efl_text_markup_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Markup property</summary>
    /// <param name="markup">The markup-text representation set to this text.</param>
    virtual public void SetMarkup(System.String markup) {
                                 Efl.ITextMarkupConcrete.NativeMethods.efl_text_markup_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),markup);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Markup of a given range in the text</summary>
    /// <param name="start">Start of the markup region</param>
    /// <param name="end">End of markup region</param>
    /// <returns>The markup-text representation set to this text of a given range</returns>
    virtual public System.String GetMarkupRange(Efl.TextCursorCursor start, Efl.TextCursorCursor end) {
                                                         var _ret_var = Efl.ITextMarkupInteractiveConcrete.NativeMethods.efl_text_markup_interactive_markup_range_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),start, end);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Markup of a given range in the text</summary>
    /// <param name="start">Start of the markup region</param>
    /// <param name="end">End of markup region</param>
    /// <param name="markup">The markup-text representation set to this text of a given range</param>
    virtual public void SetMarkupRange(Efl.TextCursorCursor start, Efl.TextCursorCursor end, System.String markup) {
                                                                                 Efl.ITextMarkupInteractiveConcrete.NativeMethods.efl_text_markup_interactive_markup_range_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),start, end, markup);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>Inserts a markup text to the text object in a given cursor position</summary>
    /// <param name="cur">Cursor position to insert markup</param>
    /// <param name="markup">The markup text to insert</param>
    virtual public void CursorMarkupInsert(Efl.TextCursorCursor cur, System.String markup) {
                                                         Efl.ITextMarkupInteractiveConcrete.NativeMethods.efl_text_markup_interactive_cursor_markup_insert_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),cur, markup);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Color of text, excluding style</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    virtual public void GetNormalColor(out byte r, out byte g, out byte b, out byte a) {
                                                                                                         Efl.ITextStyleConcrete.NativeMethods.efl_text_normal_color_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out r, out g, out b, out a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Color of text, excluding style</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    virtual public void SetNormalColor(byte r, byte g, byte b, byte a) {
                                                                                                         Efl.ITextStyleConcrete.NativeMethods.efl_text_normal_color_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),r, g, b, a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Enable or disable backing type</summary>
    /// <returns>Backing type</returns>
    virtual public Efl.TextStyleBackingType GetBackingType() {
         var _ret_var = Efl.ITextStyleConcrete.NativeMethods.efl_text_backing_type_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Enable or disable backing type</summary>
    /// <param name="type">Backing type</param>
    virtual public void SetBackingType(Efl.TextStyleBackingType type) {
                                 Efl.ITextStyleConcrete.NativeMethods.efl_text_backing_type_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),type);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Backing color</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    virtual public void GetBackingColor(out byte r, out byte g, out byte b, out byte a) {
                                                                                                         Efl.ITextStyleConcrete.NativeMethods.efl_text_backing_color_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out r, out g, out b, out a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Backing color</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    virtual public void SetBackingColor(byte r, byte g, byte b, byte a) {
                                                                                                         Efl.ITextStyleConcrete.NativeMethods.efl_text_backing_color_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),r, g, b, a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Sets an underline style on the text</summary>
    /// <returns>Underline type</returns>
    virtual public Efl.TextStyleUnderlineType GetUnderlineType() {
         var _ret_var = Efl.ITextStyleConcrete.NativeMethods.efl_text_underline_type_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Sets an underline style on the text</summary>
    /// <param name="type">Underline type</param>
    virtual public void SetUnderlineType(Efl.TextStyleUnderlineType type) {
                                 Efl.ITextStyleConcrete.NativeMethods.efl_text_underline_type_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),type);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Color of normal underline style</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    virtual public void GetUnderlineColor(out byte r, out byte g, out byte b, out byte a) {
                                                                                                         Efl.ITextStyleConcrete.NativeMethods.efl_text_underline_color_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out r, out g, out b, out a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Color of normal underline style</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    virtual public void SetUnderlineColor(byte r, byte g, byte b, byte a) {
                                                                                                         Efl.ITextStyleConcrete.NativeMethods.efl_text_underline_color_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),r, g, b, a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Height of underline style</summary>
    /// <returns>Height</returns>
    virtual public double GetUnderlineHeight() {
         var _ret_var = Efl.ITextStyleConcrete.NativeMethods.efl_text_underline_height_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Height of underline style</summary>
    /// <param name="height">Height</param>
    virtual public void SetUnderlineHeight(double height) {
                                 Efl.ITextStyleConcrete.NativeMethods.efl_text_underline_height_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),height);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Color of dashed underline style</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    virtual public void GetUnderlineDashedColor(out byte r, out byte g, out byte b, out byte a) {
                                                                                                         Efl.ITextStyleConcrete.NativeMethods.efl_text_underline_dashed_color_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out r, out g, out b, out a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Color of dashed underline style</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    virtual public void SetUnderlineDashedColor(byte r, byte g, byte b, byte a) {
                                                                                                         Efl.ITextStyleConcrete.NativeMethods.efl_text_underline_dashed_color_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),r, g, b, a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Width of dashed underline style</summary>
    /// <returns>Width</returns>
    virtual public int GetUnderlineDashedWidth() {
         var _ret_var = Efl.ITextStyleConcrete.NativeMethods.efl_text_underline_dashed_width_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Width of dashed underline style</summary>
    /// <param name="width">Width</param>
    virtual public void SetUnderlineDashedWidth(int width) {
                                 Efl.ITextStyleConcrete.NativeMethods.efl_text_underline_dashed_width_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),width);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Gap of dashed underline style</summary>
    /// <returns>Gap</returns>
    virtual public int GetUnderlineDashedGap() {
         var _ret_var = Efl.ITextStyleConcrete.NativeMethods.efl_text_underline_dashed_gap_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Gap of dashed underline style</summary>
    /// <param name="gap">Gap</param>
    virtual public void SetUnderlineDashedGap(int gap) {
                                 Efl.ITextStyleConcrete.NativeMethods.efl_text_underline_dashed_gap_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),gap);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Color of underline2 style</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    virtual public void GetUnderline2Color(out byte r, out byte g, out byte b, out byte a) {
                                                                                                         Efl.ITextStyleConcrete.NativeMethods.efl_text_underline2_color_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out r, out g, out b, out a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Color of underline2 style</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    virtual public void SetUnderline2Color(byte r, byte g, byte b, byte a) {
                                                                                                         Efl.ITextStyleConcrete.NativeMethods.efl_text_underline2_color_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),r, g, b, a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Type of strikethrough style</summary>
    /// <returns>Strikethrough type</returns>
    virtual public Efl.TextStyleStrikethroughType GetStrikethroughType() {
         var _ret_var = Efl.ITextStyleConcrete.NativeMethods.efl_text_strikethrough_type_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Type of strikethrough style</summary>
    /// <param name="type">Strikethrough type</param>
    virtual public void SetStrikethroughType(Efl.TextStyleStrikethroughType type) {
                                 Efl.ITextStyleConcrete.NativeMethods.efl_text_strikethrough_type_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),type);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Color of strikethrough_style</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    virtual public void GetStrikethroughColor(out byte r, out byte g, out byte b, out byte a) {
                                                                                                         Efl.ITextStyleConcrete.NativeMethods.efl_text_strikethrough_color_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out r, out g, out b, out a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Color of strikethrough_style</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    virtual public void SetStrikethroughColor(byte r, byte g, byte b, byte a) {
                                                                                                         Efl.ITextStyleConcrete.NativeMethods.efl_text_strikethrough_color_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),r, g, b, a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Type of effect used for the displayed text</summary>
    /// <returns>Effect type</returns>
    virtual public Efl.TextStyleEffectType GetEffectType() {
         var _ret_var = Efl.ITextStyleConcrete.NativeMethods.efl_text_effect_type_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Type of effect used for the displayed text</summary>
    /// <param name="type">Effect type</param>
    virtual public void SetEffectType(Efl.TextStyleEffectType type) {
                                 Efl.ITextStyleConcrete.NativeMethods.efl_text_effect_type_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),type);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Color of outline effect</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    virtual public void GetOutlineColor(out byte r, out byte g, out byte b, out byte a) {
                                                                                                         Efl.ITextStyleConcrete.NativeMethods.efl_text_outline_color_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out r, out g, out b, out a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Color of outline effect</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    virtual public void SetOutlineColor(byte r, byte g, byte b, byte a) {
                                                                                                         Efl.ITextStyleConcrete.NativeMethods.efl_text_outline_color_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),r, g, b, a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Direction of shadow effect</summary>
    /// <returns>Shadow direction</returns>
    virtual public Efl.TextStyleShadowDirection GetShadowDirection() {
         var _ret_var = Efl.ITextStyleConcrete.NativeMethods.efl_text_shadow_direction_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Direction of shadow effect</summary>
    /// <param name="type">Shadow direction</param>
    virtual public void SetShadowDirection(Efl.TextStyleShadowDirection type) {
                                 Efl.ITextStyleConcrete.NativeMethods.efl_text_shadow_direction_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),type);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Color of shadow effect</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    virtual public void GetShadowColor(out byte r, out byte g, out byte b, out byte a) {
                                                                                                         Efl.ITextStyleConcrete.NativeMethods.efl_text_shadow_color_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out r, out g, out b, out a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Color of shadow effect</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    virtual public void SetShadowColor(byte r, byte g, byte b, byte a) {
                                                                                                         Efl.ITextStyleConcrete.NativeMethods.efl_text_shadow_color_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),r, g, b, a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Color of glow effect</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    virtual public void GetGlowColor(out byte r, out byte g, out byte b, out byte a) {
                                                                                                         Efl.ITextStyleConcrete.NativeMethods.efl_text_glow_color_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out r, out g, out b, out a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Color of glow effect</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    virtual public void SetGlowColor(byte r, byte g, byte b, byte a) {
                                                                                                         Efl.ITextStyleConcrete.NativeMethods.efl_text_glow_color_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),r, g, b, a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Second color of the glow effect</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    virtual public void GetGlow2Color(out byte r, out byte g, out byte b, out byte a) {
                                                                                                         Efl.ITextStyleConcrete.NativeMethods.efl_text_glow2_color_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out r, out g, out b, out a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Second color of the glow effect</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    virtual public void SetGlow2Color(byte r, byte g, byte b, byte a) {
                                                                                                         Efl.ITextStyleConcrete.NativeMethods.efl_text_glow2_color_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),r, g, b, a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Program that applies a special filter
    /// See <see cref="Efl.Gfx.IFilter"/>.</summary>
    /// <returns>Filter code</returns>
    virtual public System.String GetGfxFilter() {
         var _ret_var = Efl.ITextStyleConcrete.NativeMethods.efl_text_gfx_filter_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Program that applies a special filter
    /// See <see cref="Efl.Gfx.IFilter"/>.</summary>
    /// <param name="code">Filter code</param>
    virtual public void SetGfxFilter(System.String code) {
                                 Efl.ITextStyleConcrete.NativeMethods.efl_text_gfx_filter_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),code);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Marks this filter as changed.</summary>
    /// <param name="val"><c>true</c> if filter changed, <c>false</c> otherwise</param>
    virtual public void SetFilterChanged(bool val) {
                                 Efl.Canvas.Filter.IInternalConcrete.NativeMethods.evas_filter_changed_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),val);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Marks this filter as invalid.</summary>
    /// <param name="val"><c>true</c> if filter is invalid, <c>false</c> otherwise</param>
    virtual public void SetFilterInvalid(bool val) {
                                 Efl.Canvas.Filter.IInternalConcrete.NativeMethods.evas_filter_invalid_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),val);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Retrieve cached output buffer, if any.
    /// Does not increment the reference count.</summary>
    /// <returns>Output buffer</returns>
    virtual public System.IntPtr GetFilterOutputBuffer() {
         var _ret_var = Efl.Canvas.Filter.IInternalConcrete.NativeMethods.evas_filter_output_buffer_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Called by Efl.Canvas.Filter.Internal to determine whether the input is alpha or rgba.</summary>
    /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
    virtual public bool FilterInputAlpha() {
         var _ret_var = Efl.Canvas.Filter.IInternalConcrete.NativeMethods.evas_filter_input_alpha_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Called by Efl.Canvas.Filter.Internal to request the parent class for state information (color, etc...).</summary>
    /// <param name="state">State info to fill in</param>
    /// <param name="data">Private data for the class</param>
    virtual public void FilterStatePrepare(out Efl.Canvas.Filter.State state, System.IntPtr data) {
                         var _out_state = new Efl.Canvas.Filter.State.NativeStruct();
                                Efl.Canvas.Filter.IInternalConcrete.NativeMethods.evas_filter_state_prepare_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out _out_state, data);
        Eina.Error.RaiseIfUnhandledException();
        state = _out_state;
                                 }
    /// <summary>Called by Efl.Canvas.Filter.Internal when the parent class must render the input.</summary>
    /// <param name="filter">Current filter context</param>
    /// <param name="engine">Engine context</param>
    /// <param name="output">Output context</param>
    /// <param name="drawctx">Draw context (for evas engine)</param>
    /// <param name="data">Private data used by textblock</param>
    /// <param name="l">Left</param>
    /// <param name="r">Right</param>
    /// <param name="t">Top</param>
    /// <param name="b">Bottom</param>
    /// <param name="x">X offset</param>
    /// <param name="y">Y offset</param>
    /// <param name="do_async"><c>true</c> when the operation should be done asynchronously, <c>false</c> otherwise</param>
    /// <returns>Indicates success from the object render function.</returns>
    virtual public bool FilterInputRender(System.IntPtr filter, System.IntPtr engine, System.IntPtr output, System.IntPtr drawctx, System.IntPtr data, int l, int r, int t, int b, int x, int y, bool do_async) {
                                                                                                                                                                                                                                                                                                         var _ret_var = Efl.Canvas.Filter.IInternalConcrete.NativeMethods.evas_filter_input_render_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),filter, engine, output, drawctx, data, l, r, t, b, x, y, do_async);
        Eina.Error.RaiseIfUnhandledException();
                                                                                                                                                                                                        return _ret_var;
 }
    /// <summary>Called when filter changes must trigger a redraw of the object.
    /// Virtual, to be implemented in the parent class.</summary>
    virtual public void FilterDirty() {
         Efl.Canvas.Filter.IInternalConcrete.NativeMethods.evas_filter_dirty_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Gets the code of the filter program set on this object. May be <c>null</c>.</summary>
    /// <param name="code">The Lua program source code.</param>
    /// <param name="name">An optional name for this filter.</param>
    virtual public void GetFilterProgram(out System.String code, out System.String name) {
                                                         Efl.Gfx.IFilterConcrete.NativeMethods.efl_gfx_filter_program_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out code, out name);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Set a graphical filter program on this object.
    /// Valid for Text and Image objects at the moment.
    /// 
    /// The argument passed to this function is a string containing a valid Lua program based on the filters API as described in the &quot;EFL Graphics Filters&quot; reference page.
    /// 
    /// Set to <c>null</c> to disable filtering.</summary>
    /// <param name="code">The Lua program source code.</param>
    /// <param name="name">An optional name for this filter.</param>
    virtual public void SetFilterProgram(System.String code, System.String name) {
                                                         Efl.Gfx.IFilterConcrete.NativeMethods.efl_gfx_filter_program_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),code, name);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Set the current state of the filter.
    /// This should be used by Edje (EFL&apos;s internal layout engine), but could also be used when implementing animations programmatically.
    /// 
    /// A full state is defined by two states (name + value): origin state and target state of an ongoing animation, as well as the <c>pos</c> progress (from 0 to 1) of that animation timeline. The second state can be omitted if there is no ongoing animation.</summary>
    /// <param name="cur_state">Current state of the filter</param>
    /// <param name="cur_val">Current value</param>
    /// <param name="next_state">Next filter state, optional</param>
    /// <param name="next_val">Next value, optional</param>
    /// <param name="pos">Position, optional</param>
    virtual public void GetFilterState(out System.String cur_state, out double cur_val, out System.String next_state, out double next_val, out double pos) {
                                                                                                                                 Efl.Gfx.IFilterConcrete.NativeMethods.efl_gfx_filter_state_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out cur_state, out cur_val, out next_state, out next_val, out pos);
        Eina.Error.RaiseIfUnhandledException();
                                                                                         }
    /// <summary>Set the current state of the filter.
    /// This should be used by Edje (EFL&apos;s internal layout engine), but could also be used when implementing animations programmatically.
    /// 
    /// A full state is defined by two states (name + value): origin state and target state of an ongoing animation, as well as the <c>pos</c> progress (from 0 to 1) of that animation timeline. The second state can be omitted if there is no ongoing animation.</summary>
    /// <param name="cur_state">Current state of the filter</param>
    /// <param name="cur_val">Current value</param>
    /// <param name="next_state">Next filter state, optional</param>
    /// <param name="next_val">Next value, optional</param>
    /// <param name="pos">Position, optional</param>
    virtual public void SetFilterState(System.String cur_state, double cur_val, System.String next_state, double next_val, double pos) {
                                                                                                                                 Efl.Gfx.IFilterConcrete.NativeMethods.efl_gfx_filter_state_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),cur_state, cur_val, next_state, next_val, pos);
        Eina.Error.RaiseIfUnhandledException();
                                                                                         }
    /// <summary>Gets the padding required to apply this filter.</summary>
    /// <param name="l">Padding on the left</param>
    /// <param name="r">Padding on the right</param>
    /// <param name="t">Padding on the top</param>
    /// <param name="b">Padding on the bottom</param>
    virtual public void GetFilterPadding(out int l, out int r, out int t, out int b) {
                                                                                                         Efl.Gfx.IFilterConcrete.NativeMethods.efl_gfx_filter_padding_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out l, out r, out t, out b);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Bind an object to use as a mask or texture in a filter program.
    /// This will create automatically a new RGBA buffer containing the source object&apos;s pixels (as it is rendered).</summary>
    /// <param name="name">Buffer name as used in the program.</param>
    /// <returns>Object to use as a source of pixels.</returns>
    virtual public Efl.Gfx.IEntity GetFilterSource(System.String name) {
                                 var _ret_var = Efl.Gfx.IFilterConcrete.NativeMethods.efl_gfx_filter_source_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),name);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Bind an object to use as a mask or texture in a filter program.
    /// This will create automatically a new RGBA buffer containing the source object&apos;s pixels (as it is rendered).</summary>
    /// <param name="name">Buffer name as used in the program.</param>
    /// <param name="source">Object to use as a source of pixels.</param>
    virtual public void SetFilterSource(System.String name, Efl.Gfx.IEntity source) {
                                                         Efl.Gfx.IFilterConcrete.NativeMethods.efl_gfx_filter_source_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),name, source);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Extra data used by the filter program.
    /// Each data element is a string (<c>value</c>) stored as a global variable <c>name</c>. The program is then responsible for conversion to numbers, tables, etc...
    /// 
    /// If the <c>execute</c> flag is set, then the <c>value</c> can be complex and run, as if the original Lua program contained a line &apos;name = value&apos;. This can be used to pass in tables.</summary>
    /// <param name="name">Name of the global variable</param>
    /// <param name="value">String value to use as data</param>
    /// <param name="execute">If <c>true</c>, execute &apos;name = value&apos;</param>
    virtual public void GetFilterData(System.String name, out System.String value, out bool execute) {
                                                                                 Efl.Gfx.IFilterConcrete.NativeMethods.efl_gfx_filter_data_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),name, out value, out execute);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>Extra data used by the filter program.
    /// Each data element is a string (<c>value</c>) stored as a global variable <c>name</c>. The program is then responsible for conversion to numbers, tables, etc...
    /// 
    /// If the <c>execute</c> flag is set, then the <c>value</c> can be complex and run, as if the original Lua program contained a line &apos;name = value&apos;. This can be used to pass in tables.</summary>
    /// <param name="name">Name of the global variable</param>
    /// <param name="value">String value to use as data</param>
    /// <param name="execute">If <c>true</c>, execute &apos;name = value&apos;</param>
    virtual public void SetFilterData(System.String name, System.String value, bool execute) {
                                                                                 Efl.Gfx.IFilterConcrete.NativeMethods.efl_gfx_filter_data_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),name, value, execute);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>Whether this object should be mirrored.
    /// If mirrored, an object is in RTL (right to left) mode instead of LTR (left to right).</summary>
    /// <returns><c>true</c> for RTL, <c>false</c> for LTR (default).</returns>
    virtual public bool GetMirrored() {
         var _ret_var = Efl.Ui.II18nConcrete.NativeMethods.efl_ui_mirrored_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Whether this object should be mirrored.
    /// If mirrored, an object is in RTL (right to left) mode instead of LTR (left to right).</summary>
    /// <param name="rtl"><c>true</c> for RTL, <c>false</c> for LTR (default).</param>
    virtual public void SetMirrored(bool rtl) {
                                 Efl.Ui.II18nConcrete.NativeMethods.efl_ui_mirrored_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),rtl);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Whether the property <see cref="Efl.Ui.II18n.Mirrored"/> should be set automatically.
    /// If enabled, the system or application configuration will be used to set the value of <see cref="Efl.Ui.II18n.Mirrored"/>.
    /// 
    /// This property may be implemented by high-level widgets (in Efl.Ui) but not by low-level widgets (in <see cref="Efl.Canvas.IScene"/>) as the configuration should affect only high-level widgets.</summary>
    /// <returns>Whether the widget uses automatic mirroring</returns>
    virtual public bool GetMirroredAutomatic() {
         var _ret_var = Efl.Ui.II18nConcrete.NativeMethods.efl_ui_mirrored_automatic_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Whether the property <see cref="Efl.Ui.II18n.Mirrored"/> should be set automatically.
    /// If enabled, the system or application configuration will be used to set the value of <see cref="Efl.Ui.II18n.Mirrored"/>.
    /// 
    /// This property may be implemented by high-level widgets (in Efl.Ui) but not by low-level widgets (in <see cref="Efl.Canvas.IScene"/>) as the configuration should affect only high-level widgets.</summary>
    /// <param name="automatic">Whether the widget uses automatic mirroring</param>
    virtual public void SetMirroredAutomatic(bool automatic) {
                                 Efl.Ui.II18nConcrete.NativeMethods.efl_ui_mirrored_automatic_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),automatic);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Gets the language for this object.</summary>
    /// <returns>The current language.</returns>
    virtual public System.String GetLanguage() {
         var _ret_var = Efl.Ui.II18nConcrete.NativeMethods.efl_ui_language_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Sets the language for this object.</summary>
    /// <param name="language">The current language.</param>
    virtual public void SetLanguage(System.String language) {
                                 Efl.Ui.II18nConcrete.NativeMethods.efl_ui_language_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),language);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Async wrapper for <see cref="AsyncLayout" />.</summary>
    /// <param name="token">Token to notify the async operation of external request to cancel.</param>
    /// <returns>An async task wrapping the result of the operation.</returns>
    public System.Threading.Tasks.Task<Eina.Value> AsyncLayoutAsync( System.Threading.CancellationToken token = default(System.Threading.CancellationToken))
    {
        Eina.Future future = AsyncLayout();
        return Efl.Eo.Globals.WrapAsync(future, token);
    }

    /// <summary>Whether the object is empty (no text) or not</summary>
    /// <value><c>true</c> if empty, <c>false</c> otherwise</value>
    public bool IsEmpty {
        get { return GetIsEmpty(); }
    }
    /// <summary>Gets the left, right, top and bottom insets of the text.
    /// The inset is any applied padding on the text.</summary>
    public (int, int, int, int) StyleInsets {
        get {
            int _out_l = default(int);
            int _out_r = default(int);
            int _out_t = default(int);
            int _out_b = default(int);
            GetStyleInsets(out _out_l,out _out_r,out _out_t,out _out_b);
            return (_out_l,_out_r,_out_t,_out_b);
        }
    }
    /// <summary>BiDi delimiters are used for in-paragraph separation of bidi segments. This is useful, for example, in the recipient fields of e-mail clients where bidi oddities can occur when mixing RTL and LTR.</summary>
    /// <value>A null terminated string of delimiters, e.g &quot;,|&quot; or <c>null</c> if empty</value>
    public System.String BidiDelimiters {
        get { return GetBidiDelimiters(); }
        set { SetBidiDelimiters(value); }
    }
    /// <summary>When <c>true</c>, newline character will behave as a paragraph separator.</summary>
    /// <value><c>true</c> for legacy mode, <c>false</c> otherwise</value>
    public bool LegacyNewline {
        get { return GetLegacyNewline(); }
        set { SetLegacyNewline(value); }
    }
    /// <summary>The formatted width and height.
    /// This calculates the actual size after restricting the textblock to the current size of the object.
    /// 
    /// The main difference between this and <see cref="Efl.Canvas.Text.GetSizeNative"/> is that the &quot;native&quot; function does not wrapping into account it just calculates the real width of the object if it was placed on an infinite canvas, while this function gives the size after wrapping according to the size restrictions of the object.
    /// 
    /// For example for a textblock containing the text: &quot;You shall not pass!&quot; with no margins or padding and assuming a monospace font and a size of 7x10 char widths (for simplicity) has a native size of 19x1 and a formatted size of 5x4.</summary>
    public (int, int) SizeFormatted {
        get {
            int _out_w = default(int);
            int _out_h = default(int);
            GetSizeFormatted(out _out_w,out _out_h);
            return (_out_w,_out_h);
        }
    }
    /// <summary>The native width and height.
    /// This calculates the actual size without taking account the current size of the object.
    /// 
    /// The main difference between this and <see cref="Efl.Canvas.Text.GetSizeFormatted"/> is that the &quot;native&quot; function does not take wrapping into account it just calculates the real width of the object if it was placed on an infinite canvas, while the &quot;formatted&quot; function gives the size after  wrapping text according to the size restrictions of the object.
    /// 
    /// For example for a textblock containing the text: &quot;You shall not pass!&quot; with no margins or padding and assuming a monospace font and a size of 7x10 char widths (for simplicity) has a native size of 19x1 and a formatted size of 5x4.</summary>
    public (int, int) SizeNative {
        get {
            int _out_w = default(int);
            int _out_h = default(int);
            GetSizeNative(out _out_w,out _out_h);
            return (_out_w,_out_h);
        }
    }
    /// <summary>Retrieve the font family and size in use on a given text object.
    /// This function allows the font name and size of a text object to be queried. Remember that the font name string is still owned by Evas and should not have free() called on it by the caller of the function.
    /// 
    /// See also <see cref="Efl.ITextFont.GetFont"/>.</summary>
    /// <value>The font family name or filename.</value>
    public (System.String, Efl.Font.Size) Font {
        get {
            System.String _out_font = default(System.String);
            Efl.Font.Size _out_size = default(Efl.Font.Size);
            GetFont(out _out_font,out _out_size);
            return (_out_font,_out_size);
        }
        set { SetFont( value.Item1,  value.Item2); }
    }
    /// <summary>Get the font file&apos;s path which is being used on a given text object.
    /// See <see cref="Efl.ITextFont.GetFont"/> for more details.</summary>
    /// <value>The font file&apos;s path.</value>
    public System.String FontSource {
        get { return GetFontSource(); }
        set { SetFontSource(value); }
    }
    /// <summary>Comma-separated list of font fallbacks
    /// Will be used in case the primary font isn&apos;t available.</summary>
    /// <value>Font name fallbacks</value>
    public System.String FontFallbacks {
        get { return GetFontFallbacks(); }
        set { SetFontFallbacks(value); }
    }
    /// <summary>Type of weight of the displayed font
    /// Default is <see cref="Efl.TextFontWeight.Normal"/>.</summary>
    /// <value>Font weight</value>
    public Efl.TextFontWeight FontWeight {
        get { return GetFontWeight(); }
        set { SetFontWeight(value); }
    }
    /// <summary>Type of slant of the displayed font
    /// Default is <see cref="Efl.TextFontSlant.Normal"/>.</summary>
    /// <value>Font slant</value>
    public Efl.TextFontSlant FontSlant {
        get { return GetFontSlant(); }
        set { SetFontSlant(value); }
    }
    /// <summary>Type of width of the displayed font
    /// Default is <see cref="Efl.TextFontWidth.Normal"/>.</summary>
    /// <value>Font width</value>
    public Efl.TextFontWidth FontWidth {
        get { return GetFontWidth(); }
        set { SetFontWidth(value); }
    }
    /// <summary>Specific language of the displayed font
    /// This is used to lookup fonts suitable to the specified language, as well as helping the font shaper backend. The language <c>lang</c> can be either a code e.g &quot;en_US&quot;, &quot;auto&quot; to use the system locale, or &quot;none&quot;.</summary>
    /// <value>Language</value>
    public System.String FontLang {
        get { return GetFontLang(); }
        set { SetFontLang(value); }
    }
    /// <summary>The bitmap fonts have fixed size glyphs for several available sizes. Basically, it is not scalable. But, it needs to be scalable for some use cases. (ex. colorful emoji fonts)
    /// Default is <see cref="Efl.TextFontBitmapScalable.None"/>.</summary>
    /// <value>Scalable</value>
    public Efl.TextFontBitmapScalable FontBitmapScalable {
        get { return GetFontBitmapScalable(); }
        set { SetFontBitmapScalable(value); }
    }
    /// <summary>Ellipsis value (number from -1.0 to 1.0)</summary>
    /// <value>Ellipsis value</value>
    public double Ellipsis {
        get { return GetEllipsis(); }
        set { SetEllipsis(value); }
    }
    /// <summary>Wrap mode for use in the text</summary>
    /// <value>Wrap mode</value>
    public Efl.TextFormatWrap Wrap {
        get { return GetWrap(); }
        set { SetWrap(value); }
    }
    /// <summary>Multiline is enabled or not</summary>
    /// <value><c>true</c> if multiline is enabled, <c>false</c> otherwise</value>
    public bool Multiline {
        get { return GetMultiline(); }
        set { SetMultiline(value); }
    }
    /// <summary>Horizontal alignment of text</summary>
    /// <value>Alignment type</value>
    public Efl.TextFormatHorizontalAlignmentAutoType HalignAutoType {
        get { return GetHalignAutoType(); }
        set { SetHalignAutoType(value); }
    }
    /// <summary>Horizontal alignment of text</summary>
    /// <value>Horizontal alignment value</value>
    public double Halign {
        get { return GetHalign(); }
        set { SetHalign(value); }
    }
    /// <summary>Vertical alignment of text</summary>
    /// <value>Vertical alignment value</value>
    public double Valign {
        get { return GetValign(); }
        set { SetValign(value); }
    }
    /// <summary>Minimal line gap (top and bottom) for each line in the text
    /// <c>value</c> is absolute size.</summary>
    /// <value>Line gap value</value>
    public double Linegap {
        get { return GetLinegap(); }
        set { SetLinegap(value); }
    }
    /// <summary>Relative line gap (top and bottom) for each line in the text
    /// The original line gap value is multiplied by <c>value</c>.</summary>
    /// <value>Relative line gap value</value>
    public double Linerelgap {
        get { return GetLinerelgap(); }
        set { SetLinerelgap(value); }
    }
    /// <summary>Tabstops value</summary>
    /// <value>Tapstops value</value>
    public int Tabstops {
        get { return GetTabstops(); }
        set { SetTabstops(value); }
    }
    /// <summary>Whether text is a password</summary>
    /// <value><c>true</c> if the text is a password, <c>false</c> otherwise</value>
    public bool Password {
        get { return GetPassword(); }
        set { SetPassword(value); }
    }
    /// <summary>The character used to replace characters that can&apos;t be displayed
    /// Currently only used to replace characters if <see cref="Efl.ITextFormat.Password"/> is enabled.</summary>
    /// <value>Replacement character</value>
    public System.String ReplacementChar {
        get { return GetReplacementChar(); }
        set { SetReplacementChar(value); }
    }
    /// <summary>Markup property</summary>
    /// <value>The markup-text representation set to this text.</value>
    public System.String Markup {
        get { return GetMarkup(); }
        set { SetMarkup(value); }
    }
    /// <summary>Color of text, excluding style</summary>
    /// <value>Red component</value>
    public (byte, byte, byte, byte) NormalColor {
        get {
            byte _out_r = default(byte);
            byte _out_g = default(byte);
            byte _out_b = default(byte);
            byte _out_a = default(byte);
            GetNormalColor(out _out_r,out _out_g,out _out_b,out _out_a);
            return (_out_r,_out_g,_out_b,_out_a);
        }
        set { SetNormalColor( value.Item1,  value.Item2,  value.Item3,  value.Item4); }
    }
    /// <summary>Enable or disable backing type</summary>
    /// <value>Backing type</value>
    public Efl.TextStyleBackingType BackingType {
        get { return GetBackingType(); }
        set { SetBackingType(value); }
    }
    /// <summary>Backing color</summary>
    /// <value>Red component</value>
    public (byte, byte, byte, byte) BackingColor {
        get {
            byte _out_r = default(byte);
            byte _out_g = default(byte);
            byte _out_b = default(byte);
            byte _out_a = default(byte);
            GetBackingColor(out _out_r,out _out_g,out _out_b,out _out_a);
            return (_out_r,_out_g,_out_b,_out_a);
        }
        set { SetBackingColor( value.Item1,  value.Item2,  value.Item3,  value.Item4); }
    }
    /// <summary>Sets an underline style on the text</summary>
    /// <value>Underline type</value>
    public Efl.TextStyleUnderlineType UnderlineType {
        get { return GetUnderlineType(); }
        set { SetUnderlineType(value); }
    }
    /// <summary>Color of normal underline style</summary>
    /// <value>Red component</value>
    public (byte, byte, byte, byte) UnderlineColor {
        get {
            byte _out_r = default(byte);
            byte _out_g = default(byte);
            byte _out_b = default(byte);
            byte _out_a = default(byte);
            GetUnderlineColor(out _out_r,out _out_g,out _out_b,out _out_a);
            return (_out_r,_out_g,_out_b,_out_a);
        }
        set { SetUnderlineColor( value.Item1,  value.Item2,  value.Item3,  value.Item4); }
    }
    /// <summary>Height of underline style</summary>
    /// <value>Height</value>
    public double UnderlineHeight {
        get { return GetUnderlineHeight(); }
        set { SetUnderlineHeight(value); }
    }
    /// <summary>Color of dashed underline style</summary>
    /// <value>Red component</value>
    public (byte, byte, byte, byte) UnderlineDashedColor {
        get {
            byte _out_r = default(byte);
            byte _out_g = default(byte);
            byte _out_b = default(byte);
            byte _out_a = default(byte);
            GetUnderlineDashedColor(out _out_r,out _out_g,out _out_b,out _out_a);
            return (_out_r,_out_g,_out_b,_out_a);
        }
        set { SetUnderlineDashedColor( value.Item1,  value.Item2,  value.Item3,  value.Item4); }
    }
    /// <summary>Width of dashed underline style</summary>
    /// <value>Width</value>
    public int UnderlineDashedWidth {
        get { return GetUnderlineDashedWidth(); }
        set { SetUnderlineDashedWidth(value); }
    }
    /// <summary>Gap of dashed underline style</summary>
    /// <value>Gap</value>
    public int UnderlineDashedGap {
        get { return GetUnderlineDashedGap(); }
        set { SetUnderlineDashedGap(value); }
    }
    /// <summary>Color of underline2 style</summary>
    /// <value>Red component</value>
    public (byte, byte, byte, byte) Underline2Color {
        get {
            byte _out_r = default(byte);
            byte _out_g = default(byte);
            byte _out_b = default(byte);
            byte _out_a = default(byte);
            GetUnderline2Color(out _out_r,out _out_g,out _out_b,out _out_a);
            return (_out_r,_out_g,_out_b,_out_a);
        }
        set { SetUnderline2Color( value.Item1,  value.Item2,  value.Item3,  value.Item4); }
    }
    /// <summary>Type of strikethrough style</summary>
    /// <value>Strikethrough type</value>
    public Efl.TextStyleStrikethroughType StrikethroughType {
        get { return GetStrikethroughType(); }
        set { SetStrikethroughType(value); }
    }
    /// <summary>Color of strikethrough_style</summary>
    /// <value>Red component</value>
    public (byte, byte, byte, byte) StrikethroughColor {
        get {
            byte _out_r = default(byte);
            byte _out_g = default(byte);
            byte _out_b = default(byte);
            byte _out_a = default(byte);
            GetStrikethroughColor(out _out_r,out _out_g,out _out_b,out _out_a);
            return (_out_r,_out_g,_out_b,_out_a);
        }
        set { SetStrikethroughColor( value.Item1,  value.Item2,  value.Item3,  value.Item4); }
    }
    /// <summary>Type of effect used for the displayed text</summary>
    /// <value>Effect type</value>
    public Efl.TextStyleEffectType EffectType {
        get { return GetEffectType(); }
        set { SetEffectType(value); }
    }
    /// <summary>Color of outline effect</summary>
    /// <value>Red component</value>
    public (byte, byte, byte, byte) OutlineColor {
        get {
            byte _out_r = default(byte);
            byte _out_g = default(byte);
            byte _out_b = default(byte);
            byte _out_a = default(byte);
            GetOutlineColor(out _out_r,out _out_g,out _out_b,out _out_a);
            return (_out_r,_out_g,_out_b,_out_a);
        }
        set { SetOutlineColor( value.Item1,  value.Item2,  value.Item3,  value.Item4); }
    }
    /// <summary>Direction of shadow effect</summary>
    /// <value>Shadow direction</value>
    public Efl.TextStyleShadowDirection ShadowDirection {
        get { return GetShadowDirection(); }
        set { SetShadowDirection(value); }
    }
    /// <summary>Color of shadow effect</summary>
    /// <value>Red component</value>
    public (byte, byte, byte, byte) ShadowColor {
        get {
            byte _out_r = default(byte);
            byte _out_g = default(byte);
            byte _out_b = default(byte);
            byte _out_a = default(byte);
            GetShadowColor(out _out_r,out _out_g,out _out_b,out _out_a);
            return (_out_r,_out_g,_out_b,_out_a);
        }
        set { SetShadowColor( value.Item1,  value.Item2,  value.Item3,  value.Item4); }
    }
    /// <summary>Color of glow effect</summary>
    /// <value>Red component</value>
    public (byte, byte, byte, byte) GlowColor {
        get {
            byte _out_r = default(byte);
            byte _out_g = default(byte);
            byte _out_b = default(byte);
            byte _out_a = default(byte);
            GetGlowColor(out _out_r,out _out_g,out _out_b,out _out_a);
            return (_out_r,_out_g,_out_b,_out_a);
        }
        set { SetGlowColor( value.Item1,  value.Item2,  value.Item3,  value.Item4); }
    }
    /// <summary>Second color of the glow effect</summary>
    /// <value>Red component</value>
    public (byte, byte, byte, byte) Glow2Color {
        get {
            byte _out_r = default(byte);
            byte _out_g = default(byte);
            byte _out_b = default(byte);
            byte _out_a = default(byte);
            GetGlow2Color(out _out_r,out _out_g,out _out_b,out _out_a);
            return (_out_r,_out_g,_out_b,_out_a);
        }
        set { SetGlow2Color( value.Item1,  value.Item2,  value.Item3,  value.Item4); }
    }
    /// <summary>Program that applies a special filter
    /// See <see cref="Efl.Gfx.IFilter"/>.</summary>
    /// <value>Filter code</value>
    public System.String GfxFilter {
        get { return GetGfxFilter(); }
        set { SetGfxFilter(value); }
    }
    /// <summary>Marks this filter as changed.</summary>
    /// <value><c>true</c> if filter changed, <c>false</c> otherwise</value>
    public bool FilterChanged {
        set { SetFilterChanged(value); }
    }
    /// <summary>Marks this filter as invalid.</summary>
    /// <value><c>true</c> if filter is invalid, <c>false</c> otherwise</value>
    public bool FilterInvalid {
        set { SetFilterInvalid(value); }
    }
    /// <summary>Retrieve cached output buffer, if any.
    /// Does not increment the reference count.</summary>
    /// <value>Output buffer</value>
    public System.IntPtr FilterOutputBuffer {
        get { return GetFilterOutputBuffer(); }
    }
    /// <summary>Gets the code of the filter program set on this object. May be <c>null</c>.</summary>
    /// <value>The Lua program source code.</value>
    public (System.String, System.String) FilterProgram {
        get {
            System.String _out_code = default(System.String);
            System.String _out_name = default(System.String);
            GetFilterProgram(out _out_code,out _out_name);
            return (_out_code,_out_name);
        }
        set { SetFilterProgram( value.Item1,  value.Item2); }
    }
    /// <summary>Set the current state of the filter.
    /// This should be used by Edje (EFL&apos;s internal layout engine), but could also be used when implementing animations programmatically.
    /// 
    /// A full state is defined by two states (name + value): origin state and target state of an ongoing animation, as well as the <c>pos</c> progress (from 0 to 1) of that animation timeline. The second state can be omitted if there is no ongoing animation.</summary>
    /// <value>Current state of the filter</value>
    public (System.String, double, System.String, double, double) FilterState {
        get {
            System.String _out_cur_state = default(System.String);
            double _out_cur_val = default(double);
            System.String _out_next_state = default(System.String);
            double _out_next_val = default(double);
            double _out_pos = default(double);
            GetFilterState(out _out_cur_state,out _out_cur_val,out _out_next_state,out _out_next_val,out _out_pos);
            return (_out_cur_state,_out_cur_val,_out_next_state,_out_next_val,_out_pos);
        }
        set { SetFilterState( value.Item1,  value.Item2,  value.Item3,  value.Item4,  value.Item5); }
    }
    /// <summary>Required padding to apply this filter without cropping.
    /// Read-only property that can be used to calculate the object&apos;s final geometry. This can be overridden (set) from inside the filter program by using the function &apos;padding_set&apos; in the Lua program.</summary>
    public (int, int, int, int) FilterPadding {
        get {
            int _out_l = default(int);
            int _out_r = default(int);
            int _out_t = default(int);
            int _out_b = default(int);
            GetFilterPadding(out _out_l,out _out_r,out _out_t,out _out_b);
            return (_out_l,_out_r,_out_t,_out_b);
        }
    }
    /// <summary>Whether this object should be mirrored.
    /// If mirrored, an object is in RTL (right to left) mode instead of LTR (left to right).</summary>
    /// <value><c>true</c> for RTL, <c>false</c> for LTR (default).</value>
    public bool Mirrored {
        get { return GetMirrored(); }
        set { SetMirrored(value); }
    }
    /// <summary>Whether the property <see cref="Efl.Ui.II18n.Mirrored"/> should be set automatically.
    /// If enabled, the system or application configuration will be used to set the value of <see cref="Efl.Ui.II18n.Mirrored"/>.
    /// 
    /// This property may be implemented by high-level widgets (in Efl.Ui) but not by low-level widgets (in <see cref="Efl.Canvas.IScene"/>) as the configuration should affect only high-level widgets.</summary>
    /// <value>Whether the widget uses automatic mirroring</value>
    public bool MirroredAutomatic {
        get { return GetMirroredAutomatic(); }
        set { SetMirroredAutomatic(value); }
    }
    /// <summary>The (human) language for this object.</summary>
    /// <value>The current language.</value>
    public System.String Language {
        get { return GetLanguage(); }
        set { SetLanguage(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Canvas.Text.efl_canvas_text_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Canvas.Object.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Evas);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_canvas_text_is_empty_get_static_delegate == null)
            {
                efl_canvas_text_is_empty_get_static_delegate = new efl_canvas_text_is_empty_get_delegate(is_empty_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetIsEmpty") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_text_is_empty_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_text_is_empty_get_static_delegate) });
            }

            if (efl_canvas_text_style_insets_get_static_delegate == null)
            {
                efl_canvas_text_style_insets_get_static_delegate = new efl_canvas_text_style_insets_get_delegate(style_insets_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetStyleInsets") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_text_style_insets_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_text_style_insets_get_static_delegate) });
            }

            if (efl_canvas_text_bidi_delimiters_get_static_delegate == null)
            {
                efl_canvas_text_bidi_delimiters_get_static_delegate = new efl_canvas_text_bidi_delimiters_get_delegate(bidi_delimiters_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetBidiDelimiters") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_text_bidi_delimiters_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_text_bidi_delimiters_get_static_delegate) });
            }

            if (efl_canvas_text_bidi_delimiters_set_static_delegate == null)
            {
                efl_canvas_text_bidi_delimiters_set_static_delegate = new efl_canvas_text_bidi_delimiters_set_delegate(bidi_delimiters_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetBidiDelimiters") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_text_bidi_delimiters_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_text_bidi_delimiters_set_static_delegate) });
            }

            if (efl_canvas_text_legacy_newline_get_static_delegate == null)
            {
                efl_canvas_text_legacy_newline_get_static_delegate = new efl_canvas_text_legacy_newline_get_delegate(legacy_newline_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetLegacyNewline") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_text_legacy_newline_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_text_legacy_newline_get_static_delegate) });
            }

            if (efl_canvas_text_legacy_newline_set_static_delegate == null)
            {
                efl_canvas_text_legacy_newline_set_static_delegate = new efl_canvas_text_legacy_newline_set_delegate(legacy_newline_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetLegacyNewline") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_text_legacy_newline_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_text_legacy_newline_set_static_delegate) });
            }

            if (efl_canvas_text_style_get_static_delegate == null)
            {
                efl_canvas_text_style_get_static_delegate = new efl_canvas_text_style_get_delegate(style_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetStyle") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_text_style_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_text_style_get_static_delegate) });
            }

            if (efl_canvas_text_style_set_static_delegate == null)
            {
                efl_canvas_text_style_set_static_delegate = new efl_canvas_text_style_set_delegate(style_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetStyle") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_text_style_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_text_style_set_static_delegate) });
            }

            if (efl_canvas_text_size_formatted_get_static_delegate == null)
            {
                efl_canvas_text_size_formatted_get_static_delegate = new efl_canvas_text_size_formatted_get_delegate(size_formatted_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetSizeFormatted") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_text_size_formatted_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_text_size_formatted_get_static_delegate) });
            }

            if (efl_canvas_text_size_native_get_static_delegate == null)
            {
                efl_canvas_text_size_native_get_static_delegate = new efl_canvas_text_size_native_get_delegate(size_native_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetSizeNative") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_text_size_native_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_text_size_native_get_static_delegate) });
            }

            if (efl_canvas_text_visible_range_get_static_delegate == null)
            {
                efl_canvas_text_visible_range_get_static_delegate = new efl_canvas_text_visible_range_get_delegate(visible_range_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetVisibleRange") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_text_visible_range_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_text_visible_range_get_static_delegate) });
            }

            if (efl_canvas_text_range_text_get_static_delegate == null)
            {
                efl_canvas_text_range_text_get_static_delegate = new efl_canvas_text_range_text_get_delegate(range_text_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetRangeText") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_text_range_text_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_text_range_text_get_static_delegate) });
            }

            if (efl_canvas_text_range_geometry_get_static_delegate == null)
            {
                efl_canvas_text_range_geometry_get_static_delegate = new efl_canvas_text_range_geometry_get_delegate(range_geometry_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetRangeGeometry") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_text_range_geometry_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_text_range_geometry_get_static_delegate) });
            }

            if (efl_canvas_text_range_simple_geometry_get_static_delegate == null)
            {
                efl_canvas_text_range_simple_geometry_get_static_delegate = new efl_canvas_text_range_simple_geometry_get_delegate(range_simple_geometry_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetRangeSimpleGeometry") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_text_range_simple_geometry_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_text_range_simple_geometry_get_static_delegate) });
            }

            if (efl_canvas_text_range_delete_static_delegate == null)
            {
                efl_canvas_text_range_delete_static_delegate = new efl_canvas_text_range_delete_delegate(range_delete);
            }

            if (methods.FirstOrDefault(m => m.Name == "RangeDelete") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_text_range_delete"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_text_range_delete_static_delegate) });
            }

            if (efl_canvas_text_obstacle_add_static_delegate == null)
            {
                efl_canvas_text_obstacle_add_static_delegate = new efl_canvas_text_obstacle_add_delegate(obstacle_add);
            }

            if (methods.FirstOrDefault(m => m.Name == "AddObstacle") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_text_obstacle_add"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_text_obstacle_add_static_delegate) });
            }

            if (efl_canvas_text_obstacle_del_static_delegate == null)
            {
                efl_canvas_text_obstacle_del_static_delegate = new efl_canvas_text_obstacle_del_delegate(obstacle_del);
            }

            if (methods.FirstOrDefault(m => m.Name == "DelObstacle") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_text_obstacle_del"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_text_obstacle_del_static_delegate) });
            }

            if (efl_canvas_text_obstacles_update_static_delegate == null)
            {
                efl_canvas_text_obstacles_update_static_delegate = new efl_canvas_text_obstacles_update_delegate(obstacles_update);
            }

            if (methods.FirstOrDefault(m => m.Name == "UpdateObstacles") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_text_obstacles_update"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_text_obstacles_update_static_delegate) });
            }

            if (efl_canvas_text_async_layout_static_delegate == null)
            {
                efl_canvas_text_async_layout_static_delegate = new efl_canvas_text_async_layout_delegate(async_layout);
            }

            if (methods.FirstOrDefault(m => m.Name == "AsyncLayout") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_text_async_layout"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_text_async_layout_static_delegate) });
            }

            if (efl_text_get_static_delegate == null)
            {
                efl_text_get_static_delegate = new efl_text_get_delegate(text_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetText") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_get_static_delegate) });
            }

            if (efl_text_set_static_delegate == null)
            {
                efl_text_set_static_delegate = new efl_text_set_delegate(text_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetText") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_set_static_delegate) });
            }

            if (efl_text_annotation_get_static_delegate == null)
            {
                efl_text_annotation_get_static_delegate = new efl_text_annotation_get_delegate(annotation_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetAnnotation") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_annotation_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_annotation_get_static_delegate) });
            }

            if (efl_text_annotation_set_static_delegate == null)
            {
                efl_text_annotation_set_static_delegate = new efl_text_annotation_set_delegate(annotation_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetAnnotation") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_annotation_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_annotation_set_static_delegate) });
            }

            if (efl_text_cursor_item_annotation_get_static_delegate == null)
            {
                efl_text_cursor_item_annotation_get_static_delegate = new efl_text_cursor_item_annotation_get_delegate(cursor_item_annotation_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetCursorItemAnnotation") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_cursor_item_annotation_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_item_annotation_get_static_delegate) });
            }

            if (efl_text_range_annotations_get_static_delegate == null)
            {
                efl_text_range_annotations_get_static_delegate = new efl_text_range_annotations_get_delegate(range_annotations_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetRangeAnnotations") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_range_annotations_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_range_annotations_get_static_delegate) });
            }

            if (efl_text_annotation_insert_static_delegate == null)
            {
                efl_text_annotation_insert_static_delegate = new efl_text_annotation_insert_delegate(annotation_insert);
            }

            if (methods.FirstOrDefault(m => m.Name == "AnnotationInsert") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_annotation_insert"), func = Marshal.GetFunctionPointerForDelegate(efl_text_annotation_insert_static_delegate) });
            }

            if (efl_text_annotation_del_static_delegate == null)
            {
                efl_text_annotation_del_static_delegate = new efl_text_annotation_del_delegate(annotation_del);
            }

            if (methods.FirstOrDefault(m => m.Name == "DelAnnotation") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_annotation_del"), func = Marshal.GetFunctionPointerForDelegate(efl_text_annotation_del_static_delegate) });
            }

            if (efl_text_annotation_positions_get_static_delegate == null)
            {
                efl_text_annotation_positions_get_static_delegate = new efl_text_annotation_positions_get_delegate(annotation_positions_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetAnnotationPositions") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_annotation_positions_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_annotation_positions_get_static_delegate) });
            }

            if (efl_text_annotation_is_item_static_delegate == null)
            {
                efl_text_annotation_is_item_static_delegate = new efl_text_annotation_is_item_delegate(annotation_is_item);
            }

            if (methods.FirstOrDefault(m => m.Name == "AnnotationIsItem") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_annotation_is_item"), func = Marshal.GetFunctionPointerForDelegate(efl_text_annotation_is_item_static_delegate) });
            }

            if (efl_text_item_geometry_get_static_delegate == null)
            {
                efl_text_item_geometry_get_static_delegate = new efl_text_item_geometry_get_delegate(item_geometry_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetItemGeometry") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_item_geometry_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_item_geometry_get_static_delegate) });
            }

            if (efl_text_cursor_item_insert_static_delegate == null)
            {
                efl_text_cursor_item_insert_static_delegate = new efl_text_cursor_item_insert_delegate(cursor_item_insert);
            }

            if (methods.FirstOrDefault(m => m.Name == "CursorItemInsert") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_cursor_item_insert"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_item_insert_static_delegate) });
            }

            if (efl_text_cursor_get_static_delegate == null)
            {
                efl_text_cursor_get_static_delegate = new efl_text_cursor_get_delegate(text_cursor_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetTextCursor") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_cursor_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_get_static_delegate) });
            }

            if (efl_text_cursor_position_get_static_delegate == null)
            {
                efl_text_cursor_position_get_static_delegate = new efl_text_cursor_position_get_delegate(cursor_position_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetCursorPosition") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_cursor_position_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_position_get_static_delegate) });
            }

            if (efl_text_cursor_position_set_static_delegate == null)
            {
                efl_text_cursor_position_set_static_delegate = new efl_text_cursor_position_set_delegate(cursor_position_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetCursorPosition") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_cursor_position_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_position_set_static_delegate) });
            }

            if (efl_text_cursor_content_get_static_delegate == null)
            {
                efl_text_cursor_content_get_static_delegate = new efl_text_cursor_content_get_delegate(cursor_content_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetCursorContent") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_cursor_content_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_content_get_static_delegate) });
            }

            if (efl_text_cursor_geometry_get_static_delegate == null)
            {
                efl_text_cursor_geometry_get_static_delegate = new efl_text_cursor_geometry_get_delegate(cursor_geometry_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetCursorGeometry") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_cursor_geometry_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_geometry_get_static_delegate) });
            }

            if (efl_text_cursor_new_static_delegate == null)
            {
                efl_text_cursor_new_static_delegate = new efl_text_cursor_new_delegate(cursor_new);
            }

            if (methods.FirstOrDefault(m => m.Name == "NewCursor") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_cursor_new"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_new_static_delegate) });
            }

            if (efl_text_cursor_free_static_delegate == null)
            {
                efl_text_cursor_free_static_delegate = new efl_text_cursor_free_delegate(cursor_free);
            }

            if (methods.FirstOrDefault(m => m.Name == "CursorFree") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_cursor_free"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_free_static_delegate) });
            }

            if (efl_text_cursor_equal_static_delegate == null)
            {
                efl_text_cursor_equal_static_delegate = new efl_text_cursor_equal_delegate(cursor_equal);
            }

            if (methods.FirstOrDefault(m => m.Name == "CursorEqual") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_cursor_equal"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_equal_static_delegate) });
            }

            if (efl_text_cursor_compare_static_delegate == null)
            {
                efl_text_cursor_compare_static_delegate = new efl_text_cursor_compare_delegate(cursor_compare);
            }

            if (methods.FirstOrDefault(m => m.Name == "CursorCompare") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_cursor_compare"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_compare_static_delegate) });
            }

            if (efl_text_cursor_copy_static_delegate == null)
            {
                efl_text_cursor_copy_static_delegate = new efl_text_cursor_copy_delegate(cursor_copy);
            }

            if (methods.FirstOrDefault(m => m.Name == "CursorCopy") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_cursor_copy"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_copy_static_delegate) });
            }

            if (efl_text_cursor_char_next_static_delegate == null)
            {
                efl_text_cursor_char_next_static_delegate = new efl_text_cursor_char_next_delegate(cursor_char_next);
            }

            if (methods.FirstOrDefault(m => m.Name == "CursorCharNext") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_cursor_char_next"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_char_next_static_delegate) });
            }

            if (efl_text_cursor_char_prev_static_delegate == null)
            {
                efl_text_cursor_char_prev_static_delegate = new efl_text_cursor_char_prev_delegate(cursor_char_prev);
            }

            if (methods.FirstOrDefault(m => m.Name == "CursorCharPrev") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_cursor_char_prev"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_char_prev_static_delegate) });
            }

            if (efl_text_cursor_cluster_next_static_delegate == null)
            {
                efl_text_cursor_cluster_next_static_delegate = new efl_text_cursor_cluster_next_delegate(cursor_cluster_next);
            }

            if (methods.FirstOrDefault(m => m.Name == "CursorClusterNext") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_cursor_cluster_next"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_cluster_next_static_delegate) });
            }

            if (efl_text_cursor_cluster_prev_static_delegate == null)
            {
                efl_text_cursor_cluster_prev_static_delegate = new efl_text_cursor_cluster_prev_delegate(cursor_cluster_prev);
            }

            if (methods.FirstOrDefault(m => m.Name == "CursorClusterPrev") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_cursor_cluster_prev"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_cluster_prev_static_delegate) });
            }

            if (efl_text_cursor_paragraph_char_first_static_delegate == null)
            {
                efl_text_cursor_paragraph_char_first_static_delegate = new efl_text_cursor_paragraph_char_first_delegate(cursor_paragraph_char_first);
            }

            if (methods.FirstOrDefault(m => m.Name == "CursorParagraphCharFirst") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_cursor_paragraph_char_first"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_paragraph_char_first_static_delegate) });
            }

            if (efl_text_cursor_paragraph_char_last_static_delegate == null)
            {
                efl_text_cursor_paragraph_char_last_static_delegate = new efl_text_cursor_paragraph_char_last_delegate(cursor_paragraph_char_last);
            }

            if (methods.FirstOrDefault(m => m.Name == "CursorParagraphCharLast") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_cursor_paragraph_char_last"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_paragraph_char_last_static_delegate) });
            }

            if (efl_text_cursor_word_start_static_delegate == null)
            {
                efl_text_cursor_word_start_static_delegate = new efl_text_cursor_word_start_delegate(cursor_word_start);
            }

            if (methods.FirstOrDefault(m => m.Name == "CursorWordStart") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_cursor_word_start"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_word_start_static_delegate) });
            }

            if (efl_text_cursor_word_end_static_delegate == null)
            {
                efl_text_cursor_word_end_static_delegate = new efl_text_cursor_word_end_delegate(cursor_word_end);
            }

            if (methods.FirstOrDefault(m => m.Name == "CursorWordEnd") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_cursor_word_end"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_word_end_static_delegate) });
            }

            if (efl_text_cursor_line_char_first_static_delegate == null)
            {
                efl_text_cursor_line_char_first_static_delegate = new efl_text_cursor_line_char_first_delegate(cursor_line_char_first);
            }

            if (methods.FirstOrDefault(m => m.Name == "CursorLineCharFirst") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_cursor_line_char_first"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_line_char_first_static_delegate) });
            }

            if (efl_text_cursor_line_char_last_static_delegate == null)
            {
                efl_text_cursor_line_char_last_static_delegate = new efl_text_cursor_line_char_last_delegate(cursor_line_char_last);
            }

            if (methods.FirstOrDefault(m => m.Name == "CursorLineCharLast") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_cursor_line_char_last"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_line_char_last_static_delegate) });
            }

            if (efl_text_cursor_paragraph_first_static_delegate == null)
            {
                efl_text_cursor_paragraph_first_static_delegate = new efl_text_cursor_paragraph_first_delegate(cursor_paragraph_first);
            }

            if (methods.FirstOrDefault(m => m.Name == "CursorParagraphFirst") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_cursor_paragraph_first"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_paragraph_first_static_delegate) });
            }

            if (efl_text_cursor_paragraph_last_static_delegate == null)
            {
                efl_text_cursor_paragraph_last_static_delegate = new efl_text_cursor_paragraph_last_delegate(cursor_paragraph_last);
            }

            if (methods.FirstOrDefault(m => m.Name == "CursorParagraphLast") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_cursor_paragraph_last"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_paragraph_last_static_delegate) });
            }

            if (efl_text_cursor_paragraph_next_static_delegate == null)
            {
                efl_text_cursor_paragraph_next_static_delegate = new efl_text_cursor_paragraph_next_delegate(cursor_paragraph_next);
            }

            if (methods.FirstOrDefault(m => m.Name == "CursorParagraphNext") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_cursor_paragraph_next"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_paragraph_next_static_delegate) });
            }

            if (efl_text_cursor_paragraph_prev_static_delegate == null)
            {
                efl_text_cursor_paragraph_prev_static_delegate = new efl_text_cursor_paragraph_prev_delegate(cursor_paragraph_prev);
            }

            if (methods.FirstOrDefault(m => m.Name == "CursorParagraphPrev") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_cursor_paragraph_prev"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_paragraph_prev_static_delegate) });
            }

            if (efl_text_cursor_line_jump_by_static_delegate == null)
            {
                efl_text_cursor_line_jump_by_static_delegate = new efl_text_cursor_line_jump_by_delegate(cursor_line_jump_by);
            }

            if (methods.FirstOrDefault(m => m.Name == "CursorLineJumpBy") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_cursor_line_jump_by"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_line_jump_by_static_delegate) });
            }

            if (efl_text_cursor_coord_set_static_delegate == null)
            {
                efl_text_cursor_coord_set_static_delegate = new efl_text_cursor_coord_set_delegate(cursor_coord_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetCursorCoord") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_cursor_coord_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_coord_set_static_delegate) });
            }

            if (efl_text_cursor_cluster_coord_set_static_delegate == null)
            {
                efl_text_cursor_cluster_coord_set_static_delegate = new efl_text_cursor_cluster_coord_set_delegate(cursor_cluster_coord_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetCursorClusterCoord") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_cursor_cluster_coord_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_cluster_coord_set_static_delegate) });
            }

            if (efl_text_cursor_text_insert_static_delegate == null)
            {
                efl_text_cursor_text_insert_static_delegate = new efl_text_cursor_text_insert_delegate(cursor_text_insert);
            }

            if (methods.FirstOrDefault(m => m.Name == "CursorTextInsert") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_cursor_text_insert"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_text_insert_static_delegate) });
            }

            if (efl_text_cursor_char_delete_static_delegate == null)
            {
                efl_text_cursor_char_delete_static_delegate = new efl_text_cursor_char_delete_delegate(cursor_char_delete);
            }

            if (methods.FirstOrDefault(m => m.Name == "CursorCharDelete") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_cursor_char_delete"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_char_delete_static_delegate) });
            }

            if (efl_text_font_get_static_delegate == null)
            {
                efl_text_font_get_static_delegate = new efl_text_font_get_delegate(font_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFont") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_font_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_get_static_delegate) });
            }

            if (efl_text_font_set_static_delegate == null)
            {
                efl_text_font_set_static_delegate = new efl_text_font_set_delegate(font_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFont") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_font_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_set_static_delegate) });
            }

            if (efl_text_font_source_get_static_delegate == null)
            {
                efl_text_font_source_get_static_delegate = new efl_text_font_source_get_delegate(font_source_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFontSource") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_font_source_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_source_get_static_delegate) });
            }

            if (efl_text_font_source_set_static_delegate == null)
            {
                efl_text_font_source_set_static_delegate = new efl_text_font_source_set_delegate(font_source_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFontSource") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_font_source_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_source_set_static_delegate) });
            }

            if (efl_text_font_fallbacks_get_static_delegate == null)
            {
                efl_text_font_fallbacks_get_static_delegate = new efl_text_font_fallbacks_get_delegate(font_fallbacks_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFontFallbacks") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_font_fallbacks_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_fallbacks_get_static_delegate) });
            }

            if (efl_text_font_fallbacks_set_static_delegate == null)
            {
                efl_text_font_fallbacks_set_static_delegate = new efl_text_font_fallbacks_set_delegate(font_fallbacks_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFontFallbacks") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_font_fallbacks_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_fallbacks_set_static_delegate) });
            }

            if (efl_text_font_weight_get_static_delegate == null)
            {
                efl_text_font_weight_get_static_delegate = new efl_text_font_weight_get_delegate(font_weight_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFontWeight") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_font_weight_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_weight_get_static_delegate) });
            }

            if (efl_text_font_weight_set_static_delegate == null)
            {
                efl_text_font_weight_set_static_delegate = new efl_text_font_weight_set_delegate(font_weight_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFontWeight") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_font_weight_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_weight_set_static_delegate) });
            }

            if (efl_text_font_slant_get_static_delegate == null)
            {
                efl_text_font_slant_get_static_delegate = new efl_text_font_slant_get_delegate(font_slant_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFontSlant") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_font_slant_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_slant_get_static_delegate) });
            }

            if (efl_text_font_slant_set_static_delegate == null)
            {
                efl_text_font_slant_set_static_delegate = new efl_text_font_slant_set_delegate(font_slant_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFontSlant") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_font_slant_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_slant_set_static_delegate) });
            }

            if (efl_text_font_width_get_static_delegate == null)
            {
                efl_text_font_width_get_static_delegate = new efl_text_font_width_get_delegate(font_width_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFontWidth") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_font_width_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_width_get_static_delegate) });
            }

            if (efl_text_font_width_set_static_delegate == null)
            {
                efl_text_font_width_set_static_delegate = new efl_text_font_width_set_delegate(font_width_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFontWidth") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_font_width_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_width_set_static_delegate) });
            }

            if (efl_text_font_lang_get_static_delegate == null)
            {
                efl_text_font_lang_get_static_delegate = new efl_text_font_lang_get_delegate(font_lang_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFontLang") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_font_lang_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_lang_get_static_delegate) });
            }

            if (efl_text_font_lang_set_static_delegate == null)
            {
                efl_text_font_lang_set_static_delegate = new efl_text_font_lang_set_delegate(font_lang_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFontLang") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_font_lang_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_lang_set_static_delegate) });
            }

            if (efl_text_font_bitmap_scalable_get_static_delegate == null)
            {
                efl_text_font_bitmap_scalable_get_static_delegate = new efl_text_font_bitmap_scalable_get_delegate(font_bitmap_scalable_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFontBitmapScalable") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_font_bitmap_scalable_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_bitmap_scalable_get_static_delegate) });
            }

            if (efl_text_font_bitmap_scalable_set_static_delegate == null)
            {
                efl_text_font_bitmap_scalable_set_static_delegate = new efl_text_font_bitmap_scalable_set_delegate(font_bitmap_scalable_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFontBitmapScalable") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_font_bitmap_scalable_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_bitmap_scalable_set_static_delegate) });
            }

            if (efl_text_ellipsis_get_static_delegate == null)
            {
                efl_text_ellipsis_get_static_delegate = new efl_text_ellipsis_get_delegate(ellipsis_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetEllipsis") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_ellipsis_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_ellipsis_get_static_delegate) });
            }

            if (efl_text_ellipsis_set_static_delegate == null)
            {
                efl_text_ellipsis_set_static_delegate = new efl_text_ellipsis_set_delegate(ellipsis_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetEllipsis") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_ellipsis_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_ellipsis_set_static_delegate) });
            }

            if (efl_text_wrap_get_static_delegate == null)
            {
                efl_text_wrap_get_static_delegate = new efl_text_wrap_get_delegate(wrap_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetWrap") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_wrap_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_wrap_get_static_delegate) });
            }

            if (efl_text_wrap_set_static_delegate == null)
            {
                efl_text_wrap_set_static_delegate = new efl_text_wrap_set_delegate(wrap_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetWrap") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_wrap_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_wrap_set_static_delegate) });
            }

            if (efl_text_multiline_get_static_delegate == null)
            {
                efl_text_multiline_get_static_delegate = new efl_text_multiline_get_delegate(multiline_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetMultiline") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_multiline_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_multiline_get_static_delegate) });
            }

            if (efl_text_multiline_set_static_delegate == null)
            {
                efl_text_multiline_set_static_delegate = new efl_text_multiline_set_delegate(multiline_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetMultiline") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_multiline_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_multiline_set_static_delegate) });
            }

            if (efl_text_halign_auto_type_get_static_delegate == null)
            {
                efl_text_halign_auto_type_get_static_delegate = new efl_text_halign_auto_type_get_delegate(halign_auto_type_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetHalignAutoType") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_halign_auto_type_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_halign_auto_type_get_static_delegate) });
            }

            if (efl_text_halign_auto_type_set_static_delegate == null)
            {
                efl_text_halign_auto_type_set_static_delegate = new efl_text_halign_auto_type_set_delegate(halign_auto_type_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetHalignAutoType") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_halign_auto_type_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_halign_auto_type_set_static_delegate) });
            }

            if (efl_text_halign_get_static_delegate == null)
            {
                efl_text_halign_get_static_delegate = new efl_text_halign_get_delegate(halign_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetHalign") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_halign_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_halign_get_static_delegate) });
            }

            if (efl_text_halign_set_static_delegate == null)
            {
                efl_text_halign_set_static_delegate = new efl_text_halign_set_delegate(halign_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetHalign") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_halign_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_halign_set_static_delegate) });
            }

            if (efl_text_valign_get_static_delegate == null)
            {
                efl_text_valign_get_static_delegate = new efl_text_valign_get_delegate(valign_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetValign") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_valign_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_valign_get_static_delegate) });
            }

            if (efl_text_valign_set_static_delegate == null)
            {
                efl_text_valign_set_static_delegate = new efl_text_valign_set_delegate(valign_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetValign") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_valign_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_valign_set_static_delegate) });
            }

            if (efl_text_linegap_get_static_delegate == null)
            {
                efl_text_linegap_get_static_delegate = new efl_text_linegap_get_delegate(linegap_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetLinegap") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_linegap_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_linegap_get_static_delegate) });
            }

            if (efl_text_linegap_set_static_delegate == null)
            {
                efl_text_linegap_set_static_delegate = new efl_text_linegap_set_delegate(linegap_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetLinegap") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_linegap_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_linegap_set_static_delegate) });
            }

            if (efl_text_linerelgap_get_static_delegate == null)
            {
                efl_text_linerelgap_get_static_delegate = new efl_text_linerelgap_get_delegate(linerelgap_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetLinerelgap") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_linerelgap_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_linerelgap_get_static_delegate) });
            }

            if (efl_text_linerelgap_set_static_delegate == null)
            {
                efl_text_linerelgap_set_static_delegate = new efl_text_linerelgap_set_delegate(linerelgap_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetLinerelgap") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_linerelgap_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_linerelgap_set_static_delegate) });
            }

            if (efl_text_tabstops_get_static_delegate == null)
            {
                efl_text_tabstops_get_static_delegate = new efl_text_tabstops_get_delegate(tabstops_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetTabstops") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_tabstops_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_tabstops_get_static_delegate) });
            }

            if (efl_text_tabstops_set_static_delegate == null)
            {
                efl_text_tabstops_set_static_delegate = new efl_text_tabstops_set_delegate(tabstops_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetTabstops") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_tabstops_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_tabstops_set_static_delegate) });
            }

            if (efl_text_password_get_static_delegate == null)
            {
                efl_text_password_get_static_delegate = new efl_text_password_get_delegate(password_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetPassword") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_password_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_password_get_static_delegate) });
            }

            if (efl_text_password_set_static_delegate == null)
            {
                efl_text_password_set_static_delegate = new efl_text_password_set_delegate(password_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetPassword") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_password_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_password_set_static_delegate) });
            }

            if (efl_text_replacement_char_get_static_delegate == null)
            {
                efl_text_replacement_char_get_static_delegate = new efl_text_replacement_char_get_delegate(replacement_char_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetReplacementChar") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_replacement_char_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_replacement_char_get_static_delegate) });
            }

            if (efl_text_replacement_char_set_static_delegate == null)
            {
                efl_text_replacement_char_set_static_delegate = new efl_text_replacement_char_set_delegate(replacement_char_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetReplacementChar") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_replacement_char_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_replacement_char_set_static_delegate) });
            }

            if (efl_text_markup_get_static_delegate == null)
            {
                efl_text_markup_get_static_delegate = new efl_text_markup_get_delegate(markup_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetMarkup") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_markup_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_markup_get_static_delegate) });
            }

            if (efl_text_markup_set_static_delegate == null)
            {
                efl_text_markup_set_static_delegate = new efl_text_markup_set_delegate(markup_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetMarkup") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_markup_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_markup_set_static_delegate) });
            }

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

            if (efl_text_normal_color_get_static_delegate == null)
            {
                efl_text_normal_color_get_static_delegate = new efl_text_normal_color_get_delegate(normal_color_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetNormalColor") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_normal_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_normal_color_get_static_delegate) });
            }

            if (efl_text_normal_color_set_static_delegate == null)
            {
                efl_text_normal_color_set_static_delegate = new efl_text_normal_color_set_delegate(normal_color_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetNormalColor") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_normal_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_normal_color_set_static_delegate) });
            }

            if (efl_text_backing_type_get_static_delegate == null)
            {
                efl_text_backing_type_get_static_delegate = new efl_text_backing_type_get_delegate(backing_type_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetBackingType") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_backing_type_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_backing_type_get_static_delegate) });
            }

            if (efl_text_backing_type_set_static_delegate == null)
            {
                efl_text_backing_type_set_static_delegate = new efl_text_backing_type_set_delegate(backing_type_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetBackingType") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_backing_type_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_backing_type_set_static_delegate) });
            }

            if (efl_text_backing_color_get_static_delegate == null)
            {
                efl_text_backing_color_get_static_delegate = new efl_text_backing_color_get_delegate(backing_color_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetBackingColor") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_backing_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_backing_color_get_static_delegate) });
            }

            if (efl_text_backing_color_set_static_delegate == null)
            {
                efl_text_backing_color_set_static_delegate = new efl_text_backing_color_set_delegate(backing_color_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetBackingColor") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_backing_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_backing_color_set_static_delegate) });
            }

            if (efl_text_underline_type_get_static_delegate == null)
            {
                efl_text_underline_type_get_static_delegate = new efl_text_underline_type_get_delegate(underline_type_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetUnderlineType") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_underline_type_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_type_get_static_delegate) });
            }

            if (efl_text_underline_type_set_static_delegate == null)
            {
                efl_text_underline_type_set_static_delegate = new efl_text_underline_type_set_delegate(underline_type_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetUnderlineType") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_underline_type_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_type_set_static_delegate) });
            }

            if (efl_text_underline_color_get_static_delegate == null)
            {
                efl_text_underline_color_get_static_delegate = new efl_text_underline_color_get_delegate(underline_color_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetUnderlineColor") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_underline_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_color_get_static_delegate) });
            }

            if (efl_text_underline_color_set_static_delegate == null)
            {
                efl_text_underline_color_set_static_delegate = new efl_text_underline_color_set_delegate(underline_color_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetUnderlineColor") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_underline_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_color_set_static_delegate) });
            }

            if (efl_text_underline_height_get_static_delegate == null)
            {
                efl_text_underline_height_get_static_delegate = new efl_text_underline_height_get_delegate(underline_height_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetUnderlineHeight") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_underline_height_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_height_get_static_delegate) });
            }

            if (efl_text_underline_height_set_static_delegate == null)
            {
                efl_text_underline_height_set_static_delegate = new efl_text_underline_height_set_delegate(underline_height_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetUnderlineHeight") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_underline_height_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_height_set_static_delegate) });
            }

            if (efl_text_underline_dashed_color_get_static_delegate == null)
            {
                efl_text_underline_dashed_color_get_static_delegate = new efl_text_underline_dashed_color_get_delegate(underline_dashed_color_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetUnderlineDashedColor") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_underline_dashed_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_dashed_color_get_static_delegate) });
            }

            if (efl_text_underline_dashed_color_set_static_delegate == null)
            {
                efl_text_underline_dashed_color_set_static_delegate = new efl_text_underline_dashed_color_set_delegate(underline_dashed_color_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetUnderlineDashedColor") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_underline_dashed_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_dashed_color_set_static_delegate) });
            }

            if (efl_text_underline_dashed_width_get_static_delegate == null)
            {
                efl_text_underline_dashed_width_get_static_delegate = new efl_text_underline_dashed_width_get_delegate(underline_dashed_width_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetUnderlineDashedWidth") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_underline_dashed_width_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_dashed_width_get_static_delegate) });
            }

            if (efl_text_underline_dashed_width_set_static_delegate == null)
            {
                efl_text_underline_dashed_width_set_static_delegate = new efl_text_underline_dashed_width_set_delegate(underline_dashed_width_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetUnderlineDashedWidth") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_underline_dashed_width_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_dashed_width_set_static_delegate) });
            }

            if (efl_text_underline_dashed_gap_get_static_delegate == null)
            {
                efl_text_underline_dashed_gap_get_static_delegate = new efl_text_underline_dashed_gap_get_delegate(underline_dashed_gap_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetUnderlineDashedGap") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_underline_dashed_gap_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_dashed_gap_get_static_delegate) });
            }

            if (efl_text_underline_dashed_gap_set_static_delegate == null)
            {
                efl_text_underline_dashed_gap_set_static_delegate = new efl_text_underline_dashed_gap_set_delegate(underline_dashed_gap_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetUnderlineDashedGap") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_underline_dashed_gap_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_dashed_gap_set_static_delegate) });
            }

            if (efl_text_underline2_color_get_static_delegate == null)
            {
                efl_text_underline2_color_get_static_delegate = new efl_text_underline2_color_get_delegate(underline2_color_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetUnderline2Color") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_underline2_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline2_color_get_static_delegate) });
            }

            if (efl_text_underline2_color_set_static_delegate == null)
            {
                efl_text_underline2_color_set_static_delegate = new efl_text_underline2_color_set_delegate(underline2_color_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetUnderline2Color") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_underline2_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline2_color_set_static_delegate) });
            }

            if (efl_text_strikethrough_type_get_static_delegate == null)
            {
                efl_text_strikethrough_type_get_static_delegate = new efl_text_strikethrough_type_get_delegate(strikethrough_type_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetStrikethroughType") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_strikethrough_type_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_strikethrough_type_get_static_delegate) });
            }

            if (efl_text_strikethrough_type_set_static_delegate == null)
            {
                efl_text_strikethrough_type_set_static_delegate = new efl_text_strikethrough_type_set_delegate(strikethrough_type_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetStrikethroughType") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_strikethrough_type_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_strikethrough_type_set_static_delegate) });
            }

            if (efl_text_strikethrough_color_get_static_delegate == null)
            {
                efl_text_strikethrough_color_get_static_delegate = new efl_text_strikethrough_color_get_delegate(strikethrough_color_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetStrikethroughColor") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_strikethrough_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_strikethrough_color_get_static_delegate) });
            }

            if (efl_text_strikethrough_color_set_static_delegate == null)
            {
                efl_text_strikethrough_color_set_static_delegate = new efl_text_strikethrough_color_set_delegate(strikethrough_color_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetStrikethroughColor") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_strikethrough_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_strikethrough_color_set_static_delegate) });
            }

            if (efl_text_effect_type_get_static_delegate == null)
            {
                efl_text_effect_type_get_static_delegate = new efl_text_effect_type_get_delegate(effect_type_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetEffectType") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_effect_type_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_effect_type_get_static_delegate) });
            }

            if (efl_text_effect_type_set_static_delegate == null)
            {
                efl_text_effect_type_set_static_delegate = new efl_text_effect_type_set_delegate(effect_type_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetEffectType") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_effect_type_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_effect_type_set_static_delegate) });
            }

            if (efl_text_outline_color_get_static_delegate == null)
            {
                efl_text_outline_color_get_static_delegate = new efl_text_outline_color_get_delegate(outline_color_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetOutlineColor") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_outline_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_outline_color_get_static_delegate) });
            }

            if (efl_text_outline_color_set_static_delegate == null)
            {
                efl_text_outline_color_set_static_delegate = new efl_text_outline_color_set_delegate(outline_color_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetOutlineColor") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_outline_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_outline_color_set_static_delegate) });
            }

            if (efl_text_shadow_direction_get_static_delegate == null)
            {
                efl_text_shadow_direction_get_static_delegate = new efl_text_shadow_direction_get_delegate(shadow_direction_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetShadowDirection") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_shadow_direction_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_shadow_direction_get_static_delegate) });
            }

            if (efl_text_shadow_direction_set_static_delegate == null)
            {
                efl_text_shadow_direction_set_static_delegate = new efl_text_shadow_direction_set_delegate(shadow_direction_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetShadowDirection") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_shadow_direction_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_shadow_direction_set_static_delegate) });
            }

            if (efl_text_shadow_color_get_static_delegate == null)
            {
                efl_text_shadow_color_get_static_delegate = new efl_text_shadow_color_get_delegate(shadow_color_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetShadowColor") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_shadow_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_shadow_color_get_static_delegate) });
            }

            if (efl_text_shadow_color_set_static_delegate == null)
            {
                efl_text_shadow_color_set_static_delegate = new efl_text_shadow_color_set_delegate(shadow_color_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetShadowColor") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_shadow_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_shadow_color_set_static_delegate) });
            }

            if (efl_text_glow_color_get_static_delegate == null)
            {
                efl_text_glow_color_get_static_delegate = new efl_text_glow_color_get_delegate(glow_color_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetGlowColor") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_glow_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_glow_color_get_static_delegate) });
            }

            if (efl_text_glow_color_set_static_delegate == null)
            {
                efl_text_glow_color_set_static_delegate = new efl_text_glow_color_set_delegate(glow_color_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetGlowColor") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_glow_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_glow_color_set_static_delegate) });
            }

            if (efl_text_glow2_color_get_static_delegate == null)
            {
                efl_text_glow2_color_get_static_delegate = new efl_text_glow2_color_get_delegate(glow2_color_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetGlow2Color") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_glow2_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_glow2_color_get_static_delegate) });
            }

            if (efl_text_glow2_color_set_static_delegate == null)
            {
                efl_text_glow2_color_set_static_delegate = new efl_text_glow2_color_set_delegate(glow2_color_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetGlow2Color") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_glow2_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_glow2_color_set_static_delegate) });
            }

            if (efl_text_gfx_filter_get_static_delegate == null)
            {
                efl_text_gfx_filter_get_static_delegate = new efl_text_gfx_filter_get_delegate(gfx_filter_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetGfxFilter") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_gfx_filter_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_gfx_filter_get_static_delegate) });
            }

            if (efl_text_gfx_filter_set_static_delegate == null)
            {
                efl_text_gfx_filter_set_static_delegate = new efl_text_gfx_filter_set_delegate(gfx_filter_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetGfxFilter") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_gfx_filter_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_gfx_filter_set_static_delegate) });
            }

            if (evas_filter_changed_set_static_delegate == null)
            {
                evas_filter_changed_set_static_delegate = new evas_filter_changed_set_delegate(filter_changed_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFilterChanged") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "evas_filter_changed_set"), func = Marshal.GetFunctionPointerForDelegate(evas_filter_changed_set_static_delegate) });
            }

            if (evas_filter_invalid_set_static_delegate == null)
            {
                evas_filter_invalid_set_static_delegate = new evas_filter_invalid_set_delegate(filter_invalid_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFilterInvalid") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "evas_filter_invalid_set"), func = Marshal.GetFunctionPointerForDelegate(evas_filter_invalid_set_static_delegate) });
            }

            if (evas_filter_output_buffer_get_static_delegate == null)
            {
                evas_filter_output_buffer_get_static_delegate = new evas_filter_output_buffer_get_delegate(filter_output_buffer_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFilterOutputBuffer") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "evas_filter_output_buffer_get"), func = Marshal.GetFunctionPointerForDelegate(evas_filter_output_buffer_get_static_delegate) });
            }

            if (evas_filter_input_alpha_static_delegate == null)
            {
                evas_filter_input_alpha_static_delegate = new evas_filter_input_alpha_delegate(filter_input_alpha);
            }

            if (methods.FirstOrDefault(m => m.Name == "FilterInputAlpha") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "evas_filter_input_alpha"), func = Marshal.GetFunctionPointerForDelegate(evas_filter_input_alpha_static_delegate) });
            }

            if (evas_filter_state_prepare_static_delegate == null)
            {
                evas_filter_state_prepare_static_delegate = new evas_filter_state_prepare_delegate(filter_state_prepare);
            }

            if (methods.FirstOrDefault(m => m.Name == "FilterStatePrepare") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "evas_filter_state_prepare"), func = Marshal.GetFunctionPointerForDelegate(evas_filter_state_prepare_static_delegate) });
            }

            if (evas_filter_input_render_static_delegate == null)
            {
                evas_filter_input_render_static_delegate = new evas_filter_input_render_delegate(filter_input_render);
            }

            if (methods.FirstOrDefault(m => m.Name == "FilterInputRender") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "evas_filter_input_render"), func = Marshal.GetFunctionPointerForDelegate(evas_filter_input_render_static_delegate) });
            }

            if (evas_filter_dirty_static_delegate == null)
            {
                evas_filter_dirty_static_delegate = new evas_filter_dirty_delegate(filter_dirty);
            }

            if (methods.FirstOrDefault(m => m.Name == "FilterDirty") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "evas_filter_dirty"), func = Marshal.GetFunctionPointerForDelegate(evas_filter_dirty_static_delegate) });
            }

            if (efl_gfx_filter_program_get_static_delegate == null)
            {
                efl_gfx_filter_program_get_static_delegate = new efl_gfx_filter_program_get_delegate(filter_program_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFilterProgram") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_filter_program_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_filter_program_get_static_delegate) });
            }

            if (efl_gfx_filter_program_set_static_delegate == null)
            {
                efl_gfx_filter_program_set_static_delegate = new efl_gfx_filter_program_set_delegate(filter_program_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFilterProgram") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_filter_program_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_filter_program_set_static_delegate) });
            }

            if (efl_gfx_filter_state_get_static_delegate == null)
            {
                efl_gfx_filter_state_get_static_delegate = new efl_gfx_filter_state_get_delegate(filter_state_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFilterState") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_filter_state_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_filter_state_get_static_delegate) });
            }

            if (efl_gfx_filter_state_set_static_delegate == null)
            {
                efl_gfx_filter_state_set_static_delegate = new efl_gfx_filter_state_set_delegate(filter_state_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFilterState") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_filter_state_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_filter_state_set_static_delegate) });
            }

            if (efl_gfx_filter_padding_get_static_delegate == null)
            {
                efl_gfx_filter_padding_get_static_delegate = new efl_gfx_filter_padding_get_delegate(filter_padding_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFilterPadding") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_filter_padding_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_filter_padding_get_static_delegate) });
            }

            if (efl_gfx_filter_source_get_static_delegate == null)
            {
                efl_gfx_filter_source_get_static_delegate = new efl_gfx_filter_source_get_delegate(filter_source_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFilterSource") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_filter_source_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_filter_source_get_static_delegate) });
            }

            if (efl_gfx_filter_source_set_static_delegate == null)
            {
                efl_gfx_filter_source_set_static_delegate = new efl_gfx_filter_source_set_delegate(filter_source_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFilterSource") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_filter_source_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_filter_source_set_static_delegate) });
            }

            if (efl_gfx_filter_data_get_static_delegate == null)
            {
                efl_gfx_filter_data_get_static_delegate = new efl_gfx_filter_data_get_delegate(filter_data_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFilterData") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_filter_data_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_filter_data_get_static_delegate) });
            }

            if (efl_gfx_filter_data_set_static_delegate == null)
            {
                efl_gfx_filter_data_set_static_delegate = new efl_gfx_filter_data_set_delegate(filter_data_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFilterData") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_filter_data_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_filter_data_set_static_delegate) });
            }

            if (efl_ui_mirrored_get_static_delegate == null)
            {
                efl_ui_mirrored_get_static_delegate = new efl_ui_mirrored_get_delegate(mirrored_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetMirrored") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_mirrored_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_mirrored_get_static_delegate) });
            }

            if (efl_ui_mirrored_set_static_delegate == null)
            {
                efl_ui_mirrored_set_static_delegate = new efl_ui_mirrored_set_delegate(mirrored_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetMirrored") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_mirrored_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_mirrored_set_static_delegate) });
            }

            if (efl_ui_mirrored_automatic_get_static_delegate == null)
            {
                efl_ui_mirrored_automatic_get_static_delegate = new efl_ui_mirrored_automatic_get_delegate(mirrored_automatic_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetMirroredAutomatic") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_mirrored_automatic_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_mirrored_automatic_get_static_delegate) });
            }

            if (efl_ui_mirrored_automatic_set_static_delegate == null)
            {
                efl_ui_mirrored_automatic_set_static_delegate = new efl_ui_mirrored_automatic_set_delegate(mirrored_automatic_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetMirroredAutomatic") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_mirrored_automatic_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_mirrored_automatic_set_static_delegate) });
            }

            if (efl_ui_language_get_static_delegate == null)
            {
                efl_ui_language_get_static_delegate = new efl_ui_language_get_delegate(language_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetLanguage") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_language_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_language_get_static_delegate) });
            }

            if (efl_ui_language_set_static_delegate == null)
            {
                efl_ui_language_set_static_delegate = new efl_ui_language_set_delegate(language_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetLanguage") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_language_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_language_set_static_delegate) });
            }

            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Canvas.Text.efl_canvas_text_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_canvas_text_is_empty_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_canvas_text_is_empty_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_canvas_text_is_empty_get_api_delegate> efl_canvas_text_is_empty_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_text_is_empty_get_api_delegate>(Module, "efl_canvas_text_is_empty_get");

        private static bool is_empty_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_canvas_text_is_empty_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Text)ws.Target).GetIsEmpty();
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
                return efl_canvas_text_is_empty_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_canvas_text_is_empty_get_delegate efl_canvas_text_is_empty_get_static_delegate;

        
        private delegate void efl_canvas_text_style_insets_get_delegate(System.IntPtr obj, System.IntPtr pd,  out int l,  out int r,  out int t,  out int b);

        
        public delegate void efl_canvas_text_style_insets_get_api_delegate(System.IntPtr obj,  out int l,  out int r,  out int t,  out int b);

        public static Efl.Eo.FunctionWrapper<efl_canvas_text_style_insets_get_api_delegate> efl_canvas_text_style_insets_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_text_style_insets_get_api_delegate>(Module, "efl_canvas_text_style_insets_get");

        private static void style_insets_get(System.IntPtr obj, System.IntPtr pd, out int l, out int r, out int t, out int b)
        {
            Eina.Log.Debug("function efl_canvas_text_style_insets_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                        l = default(int);        r = default(int);        t = default(int);        b = default(int);                                            
                try
                {
                    ((Text)ws.Target).GetStyleInsets(out l, out r, out t, out b);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        
            }
            else
            {
                efl_canvas_text_style_insets_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out l, out r, out t, out b);
            }
        }

        private static efl_canvas_text_style_insets_get_delegate efl_canvas_text_style_insets_get_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_canvas_text_bidi_delimiters_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_canvas_text_bidi_delimiters_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_canvas_text_bidi_delimiters_get_api_delegate> efl_canvas_text_bidi_delimiters_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_text_bidi_delimiters_get_api_delegate>(Module, "efl_canvas_text_bidi_delimiters_get");

        private static System.String bidi_delimiters_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_canvas_text_bidi_delimiters_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((Text)ws.Target).GetBidiDelimiters();
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
                return efl_canvas_text_bidi_delimiters_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_canvas_text_bidi_delimiters_get_delegate efl_canvas_text_bidi_delimiters_get_static_delegate;

        
        private delegate void efl_canvas_text_bidi_delimiters_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String delim);

        
        public delegate void efl_canvas_text_bidi_delimiters_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String delim);

        public static Efl.Eo.FunctionWrapper<efl_canvas_text_bidi_delimiters_set_api_delegate> efl_canvas_text_bidi_delimiters_set_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_text_bidi_delimiters_set_api_delegate>(Module, "efl_canvas_text_bidi_delimiters_set");

        private static void bidi_delimiters_set(System.IntPtr obj, System.IntPtr pd, System.String delim)
        {
            Eina.Log.Debug("function efl_canvas_text_bidi_delimiters_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetBidiDelimiters(delim);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_canvas_text_bidi_delimiters_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), delim);
            }
        }

        private static efl_canvas_text_bidi_delimiters_set_delegate efl_canvas_text_bidi_delimiters_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_canvas_text_legacy_newline_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_canvas_text_legacy_newline_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_canvas_text_legacy_newline_get_api_delegate> efl_canvas_text_legacy_newline_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_text_legacy_newline_get_api_delegate>(Module, "efl_canvas_text_legacy_newline_get");

        private static bool legacy_newline_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_canvas_text_legacy_newline_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Text)ws.Target).GetLegacyNewline();
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
                return efl_canvas_text_legacy_newline_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_canvas_text_legacy_newline_get_delegate efl_canvas_text_legacy_newline_get_static_delegate;

        
        private delegate void efl_canvas_text_legacy_newline_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool mode);

        
        public delegate void efl_canvas_text_legacy_newline_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool mode);

        public static Efl.Eo.FunctionWrapper<efl_canvas_text_legacy_newline_set_api_delegate> efl_canvas_text_legacy_newline_set_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_text_legacy_newline_set_api_delegate>(Module, "efl_canvas_text_legacy_newline_set");

        private static void legacy_newline_set(System.IntPtr obj, System.IntPtr pd, bool mode)
        {
            Eina.Log.Debug("function efl_canvas_text_legacy_newline_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetLegacyNewline(mode);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_canvas_text_legacy_newline_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), mode);
            }
        }

        private static efl_canvas_text_legacy_newline_set_delegate efl_canvas_text_legacy_newline_set_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_canvas_text_style_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String key);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_canvas_text_style_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String key);

        public static Efl.Eo.FunctionWrapper<efl_canvas_text_style_get_api_delegate> efl_canvas_text_style_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_text_style_get_api_delegate>(Module, "efl_canvas_text_style_get");

        private static System.String style_get(System.IntPtr obj, System.IntPtr pd, System.String key)
        {
            Eina.Log.Debug("function efl_canvas_text_style_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((Text)ws.Target).GetStyle(key);
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
                return efl_canvas_text_style_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), key);
            }
        }

        private static efl_canvas_text_style_get_delegate efl_canvas_text_style_get_static_delegate;

        
        private delegate void efl_canvas_text_style_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String key, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String style);

        
        public delegate void efl_canvas_text_style_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String key, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String style);

        public static Efl.Eo.FunctionWrapper<efl_canvas_text_style_set_api_delegate> efl_canvas_text_style_set_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_text_style_set_api_delegate>(Module, "efl_canvas_text_style_set");

        private static void style_set(System.IntPtr obj, System.IntPtr pd, System.String key, System.String style)
        {
            Eina.Log.Debug("function efl_canvas_text_style_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((Text)ws.Target).SetStyle(key, style);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_canvas_text_style_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), key, style);
            }
        }

        private static efl_canvas_text_style_set_delegate efl_canvas_text_style_set_static_delegate;

        
        private delegate void efl_canvas_text_size_formatted_get_delegate(System.IntPtr obj, System.IntPtr pd,  out int w,  out int h);

        
        public delegate void efl_canvas_text_size_formatted_get_api_delegate(System.IntPtr obj,  out int w,  out int h);

        public static Efl.Eo.FunctionWrapper<efl_canvas_text_size_formatted_get_api_delegate> efl_canvas_text_size_formatted_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_text_size_formatted_get_api_delegate>(Module, "efl_canvas_text_size_formatted_get");

        private static void size_formatted_get(System.IntPtr obj, System.IntPtr pd, out int w, out int h)
        {
            Eina.Log.Debug("function efl_canvas_text_size_formatted_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                        w = default(int);        h = default(int);                            
                try
                {
                    ((Text)ws.Target).GetSizeFormatted(out w, out h);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_canvas_text_size_formatted_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out w, out h);
            }
        }

        private static efl_canvas_text_size_formatted_get_delegate efl_canvas_text_size_formatted_get_static_delegate;

        
        private delegate void efl_canvas_text_size_native_get_delegate(System.IntPtr obj, System.IntPtr pd,  out int w,  out int h);

        
        public delegate void efl_canvas_text_size_native_get_api_delegate(System.IntPtr obj,  out int w,  out int h);

        public static Efl.Eo.FunctionWrapper<efl_canvas_text_size_native_get_api_delegate> efl_canvas_text_size_native_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_text_size_native_get_api_delegate>(Module, "efl_canvas_text_size_native_get");

        private static void size_native_get(System.IntPtr obj, System.IntPtr pd, out int w, out int h)
        {
            Eina.Log.Debug("function efl_canvas_text_size_native_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                        w = default(int);        h = default(int);                            
                try
                {
                    ((Text)ws.Target).GetSizeNative(out w, out h);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_canvas_text_size_native_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out w, out h);
            }
        }

        private static efl_canvas_text_size_native_get_delegate efl_canvas_text_size_native_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_canvas_text_visible_range_get_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor start,  Efl.TextCursorCursor end);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_canvas_text_visible_range_get_api_delegate(System.IntPtr obj,  Efl.TextCursorCursor start,  Efl.TextCursorCursor end);

        public static Efl.Eo.FunctionWrapper<efl_canvas_text_visible_range_get_api_delegate> efl_canvas_text_visible_range_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_text_visible_range_get_api_delegate>(Module, "efl_canvas_text_visible_range_get");

        private static bool visible_range_get(System.IntPtr obj, System.IntPtr pd, Efl.TextCursorCursor start, Efl.TextCursorCursor end)
        {
            Eina.Log.Debug("function efl_canvas_text_visible_range_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Text)ws.Target).GetVisibleRange(start, end);
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
                return efl_canvas_text_visible_range_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), start, end);
            }
        }

        private static efl_canvas_text_visible_range_get_delegate efl_canvas_text_visible_range_get_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringPassOwnershipMarshaler))]
        private delegate System.String efl_canvas_text_range_text_get_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur1,  Efl.TextCursorCursor cur2);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringPassOwnershipMarshaler))]
        public delegate System.String efl_canvas_text_range_text_get_api_delegate(System.IntPtr obj,  Efl.TextCursorCursor cur1,  Efl.TextCursorCursor cur2);

        public static Efl.Eo.FunctionWrapper<efl_canvas_text_range_text_get_api_delegate> efl_canvas_text_range_text_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_text_range_text_get_api_delegate>(Module, "efl_canvas_text_range_text_get");

        private static System.String range_text_get(System.IntPtr obj, System.IntPtr pd, Efl.TextCursorCursor cur1, Efl.TextCursorCursor cur2)
        {
            Eina.Log.Debug("function efl_canvas_text_range_text_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((Text)ws.Target).GetRangeText(cur1, cur2);
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
                return efl_canvas_text_range_text_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), cur1, cur2);
            }
        }

        private static efl_canvas_text_range_text_get_delegate efl_canvas_text_range_text_get_static_delegate;

        
        private delegate System.IntPtr efl_canvas_text_range_geometry_get_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur1,  Efl.TextCursorCursor cur2);

        
        public delegate System.IntPtr efl_canvas_text_range_geometry_get_api_delegate(System.IntPtr obj,  Efl.TextCursorCursor cur1,  Efl.TextCursorCursor cur2);

        public static Efl.Eo.FunctionWrapper<efl_canvas_text_range_geometry_get_api_delegate> efl_canvas_text_range_geometry_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_text_range_geometry_get_api_delegate>(Module, "efl_canvas_text_range_geometry_get");

        private static System.IntPtr range_geometry_get(System.IntPtr obj, System.IntPtr pd, Efl.TextCursorCursor cur1, Efl.TextCursorCursor cur2)
        {
            Eina.Log.Debug("function efl_canvas_text_range_geometry_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            Eina.Iterator<Eina.Rect> _ret_var = default(Eina.Iterator<Eina.Rect>);
                try
                {
                    _ret_var = ((Text)ws.Target).GetRangeGeometry(cur1, cur2);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        _ret_var.Own = false; return _ret_var.Handle;

            }
            else
            {
                return efl_canvas_text_range_geometry_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), cur1, cur2);
            }
        }

        private static efl_canvas_text_range_geometry_get_delegate efl_canvas_text_range_geometry_get_static_delegate;

        
        private delegate System.IntPtr efl_canvas_text_range_simple_geometry_get_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur1,  Efl.TextCursorCursor cur2);

        
        public delegate System.IntPtr efl_canvas_text_range_simple_geometry_get_api_delegate(System.IntPtr obj,  Efl.TextCursorCursor cur1,  Efl.TextCursorCursor cur2);

        public static Efl.Eo.FunctionWrapper<efl_canvas_text_range_simple_geometry_get_api_delegate> efl_canvas_text_range_simple_geometry_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_text_range_simple_geometry_get_api_delegate>(Module, "efl_canvas_text_range_simple_geometry_get");

        private static System.IntPtr range_simple_geometry_get(System.IntPtr obj, System.IntPtr pd, Efl.TextCursorCursor cur1, Efl.TextCursorCursor cur2)
        {
            Eina.Log.Debug("function efl_canvas_text_range_simple_geometry_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            Eina.Iterator<Eina.Rect> _ret_var = default(Eina.Iterator<Eina.Rect>);
                try
                {
                    _ret_var = ((Text)ws.Target).GetRangeSimpleGeometry(cur1, cur2);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        _ret_var.Own = false; return _ret_var.Handle;

            }
            else
            {
                return efl_canvas_text_range_simple_geometry_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), cur1, cur2);
            }
        }

        private static efl_canvas_text_range_simple_geometry_get_delegate efl_canvas_text_range_simple_geometry_get_static_delegate;

        
        private delegate void efl_canvas_text_range_delete_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur1,  Efl.TextCursorCursor cur2);

        
        public delegate void efl_canvas_text_range_delete_api_delegate(System.IntPtr obj,  Efl.TextCursorCursor cur1,  Efl.TextCursorCursor cur2);

        public static Efl.Eo.FunctionWrapper<efl_canvas_text_range_delete_api_delegate> efl_canvas_text_range_delete_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_text_range_delete_api_delegate>(Module, "efl_canvas_text_range_delete");

        private static void range_delete(System.IntPtr obj, System.IntPtr pd, Efl.TextCursorCursor cur1, Efl.TextCursorCursor cur2)
        {
            Eina.Log.Debug("function efl_canvas_text_range_delete was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((Text)ws.Target).RangeDelete(cur1, cur2);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_canvas_text_range_delete_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), cur1, cur2);
            }
        }

        private static efl_canvas_text_range_delete_delegate efl_canvas_text_range_delete_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_canvas_text_obstacle_add_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Object eo_obs);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_canvas_text_obstacle_add_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Object eo_obs);

        public static Efl.Eo.FunctionWrapper<efl_canvas_text_obstacle_add_api_delegate> efl_canvas_text_obstacle_add_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_text_obstacle_add_api_delegate>(Module, "efl_canvas_text_obstacle_add");

        private static bool obstacle_add(System.IntPtr obj, System.IntPtr pd, Efl.Canvas.Object eo_obs)
        {
            Eina.Log.Debug("function efl_canvas_text_obstacle_add was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Text)ws.Target).AddObstacle(eo_obs);
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
                return efl_canvas_text_obstacle_add_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), eo_obs);
            }
        }

        private static efl_canvas_text_obstacle_add_delegate efl_canvas_text_obstacle_add_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_canvas_text_obstacle_del_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Object eo_obs);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_canvas_text_obstacle_del_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Object eo_obs);

        public static Efl.Eo.FunctionWrapper<efl_canvas_text_obstacle_del_api_delegate> efl_canvas_text_obstacle_del_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_text_obstacle_del_api_delegate>(Module, "efl_canvas_text_obstacle_del");

        private static bool obstacle_del(System.IntPtr obj, System.IntPtr pd, Efl.Canvas.Object eo_obs)
        {
            Eina.Log.Debug("function efl_canvas_text_obstacle_del was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Text)ws.Target).DelObstacle(eo_obs);
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
                return efl_canvas_text_obstacle_del_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), eo_obs);
            }
        }

        private static efl_canvas_text_obstacle_del_delegate efl_canvas_text_obstacle_del_static_delegate;

        
        private delegate void efl_canvas_text_obstacles_update_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_canvas_text_obstacles_update_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_canvas_text_obstacles_update_api_delegate> efl_canvas_text_obstacles_update_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_text_obstacles_update_api_delegate>(Module, "efl_canvas_text_obstacles_update");

        private static void obstacles_update(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_canvas_text_obstacles_update was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((Text)ws.Target).UpdateObstacles();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_canvas_text_obstacles_update_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_canvas_text_obstacles_update_delegate efl_canvas_text_obstacles_update_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))]
        private delegate  Eina.Future efl_canvas_text_async_layout_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))]
        public delegate  Eina.Future efl_canvas_text_async_layout_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_canvas_text_async_layout_api_delegate> efl_canvas_text_async_layout_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_text_async_layout_api_delegate>(Module, "efl_canvas_text_async_layout");

        private static  Eina.Future async_layout(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_canvas_text_async_layout was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
             Eina.Future _ret_var = default( Eina.Future);
                try
                {
                    _ret_var = ((Text)ws.Target).AsyncLayout();
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
                return efl_canvas_text_async_layout_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_canvas_text_async_layout_delegate efl_canvas_text_async_layout_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_text_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_text_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_text_get_api_delegate> efl_text_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_get_api_delegate>(Module, "efl_text_get");

        private static System.String text_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_text_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((Text)ws.Target).GetText();
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
                return efl_text_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_text_get_delegate efl_text_get_static_delegate;

        
        private delegate void efl_text_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String text);

        
        public delegate void efl_text_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String text);

        public static Efl.Eo.FunctionWrapper<efl_text_set_api_delegate> efl_text_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_set_api_delegate>(Module, "efl_text_set");

        private static void text_set(System.IntPtr obj, System.IntPtr pd, System.String text)
        {
            Eina.Log.Debug("function efl_text_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetText(text);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), text);
            }
        }

        private static efl_text_set_delegate efl_text_set_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_text_annotation_get_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextAnnotateAnnotation annotation);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_text_annotation_get_api_delegate(System.IntPtr obj,  Efl.TextAnnotateAnnotation annotation);

        public static Efl.Eo.FunctionWrapper<efl_text_annotation_get_api_delegate> efl_text_annotation_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_annotation_get_api_delegate>(Module, "efl_text_annotation_get");

        private static System.String annotation_get(System.IntPtr obj, System.IntPtr pd, Efl.TextAnnotateAnnotation annotation)
        {
            Eina.Log.Debug("function efl_text_annotation_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((Text)ws.Target).GetAnnotation(annotation);
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
                return efl_text_annotation_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), annotation);
            }
        }

        private static efl_text_annotation_get_delegate efl_text_annotation_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_text_annotation_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextAnnotateAnnotation annotation, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String format);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_text_annotation_set_api_delegate(System.IntPtr obj,  Efl.TextAnnotateAnnotation annotation, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String format);

        public static Efl.Eo.FunctionWrapper<efl_text_annotation_set_api_delegate> efl_text_annotation_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_annotation_set_api_delegate>(Module, "efl_text_annotation_set");

        private static bool annotation_set(System.IntPtr obj, System.IntPtr pd, Efl.TextAnnotateAnnotation annotation, System.String format)
        {
            Eina.Log.Debug("function efl_text_annotation_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Text)ws.Target).SetAnnotation(annotation, format);
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
                return efl_text_annotation_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), annotation, format);
            }
        }

        private static efl_text_annotation_set_delegate efl_text_annotation_set_static_delegate;

        
        private delegate Efl.TextAnnotateAnnotation efl_text_cursor_item_annotation_get_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur);

        
        public delegate Efl.TextAnnotateAnnotation efl_text_cursor_item_annotation_get_api_delegate(System.IntPtr obj,  Efl.TextCursorCursor cur);

        public static Efl.Eo.FunctionWrapper<efl_text_cursor_item_annotation_get_api_delegate> efl_text_cursor_item_annotation_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_item_annotation_get_api_delegate>(Module, "efl_text_cursor_item_annotation_get");

        private static Efl.TextAnnotateAnnotation cursor_item_annotation_get(System.IntPtr obj, System.IntPtr pd, Efl.TextCursorCursor cur)
        {
            Eina.Log.Debug("function efl_text_cursor_item_annotation_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    Efl.TextAnnotateAnnotation _ret_var = default(Efl.TextAnnotateAnnotation);
                try
                {
                    _ret_var = ((Text)ws.Target).GetCursorItemAnnotation(cur);
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
                return efl_text_cursor_item_annotation_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), cur);
            }
        }

        private static efl_text_cursor_item_annotation_get_delegate efl_text_cursor_item_annotation_get_static_delegate;

        
        private delegate System.IntPtr efl_text_range_annotations_get_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor start,  Efl.TextCursorCursor end);

        
        public delegate System.IntPtr efl_text_range_annotations_get_api_delegate(System.IntPtr obj,  Efl.TextCursorCursor start,  Efl.TextCursorCursor end);

        public static Efl.Eo.FunctionWrapper<efl_text_range_annotations_get_api_delegate> efl_text_range_annotations_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_range_annotations_get_api_delegate>(Module, "efl_text_range_annotations_get");

        private static System.IntPtr range_annotations_get(System.IntPtr obj, System.IntPtr pd, Efl.TextCursorCursor start, Efl.TextCursorCursor end)
        {
            Eina.Log.Debug("function efl_text_range_annotations_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            Eina.Iterator<Efl.TextAnnotateAnnotation> _ret_var = default(Eina.Iterator<Efl.TextAnnotateAnnotation>);
                try
                {
                    _ret_var = ((Text)ws.Target).GetRangeAnnotations(start, end);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        _ret_var.Own = false; return _ret_var.Handle;

            }
            else
            {
                return efl_text_range_annotations_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), start, end);
            }
        }

        private static efl_text_range_annotations_get_delegate efl_text_range_annotations_get_static_delegate;

        
        private delegate Efl.TextAnnotateAnnotation efl_text_annotation_insert_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor start,  Efl.TextCursorCursor end, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String format);

        
        public delegate Efl.TextAnnotateAnnotation efl_text_annotation_insert_api_delegate(System.IntPtr obj,  Efl.TextCursorCursor start,  Efl.TextCursorCursor end, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String format);

        public static Efl.Eo.FunctionWrapper<efl_text_annotation_insert_api_delegate> efl_text_annotation_insert_ptr = new Efl.Eo.FunctionWrapper<efl_text_annotation_insert_api_delegate>(Module, "efl_text_annotation_insert");

        private static Efl.TextAnnotateAnnotation annotation_insert(System.IntPtr obj, System.IntPtr pd, Efl.TextCursorCursor start, Efl.TextCursorCursor end, System.String format)
        {
            Eina.Log.Debug("function efl_text_annotation_insert was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                    Efl.TextAnnotateAnnotation _ret_var = default(Efl.TextAnnotateAnnotation);
                try
                {
                    _ret_var = ((Text)ws.Target).AnnotationInsert(start, end, format);
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
                return efl_text_annotation_insert_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), start, end, format);
            }
        }

        private static efl_text_annotation_insert_delegate efl_text_annotation_insert_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_text_annotation_del_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextAnnotateAnnotation annotation);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_text_annotation_del_api_delegate(System.IntPtr obj,  Efl.TextAnnotateAnnotation annotation);

        public static Efl.Eo.FunctionWrapper<efl_text_annotation_del_api_delegate> efl_text_annotation_del_ptr = new Efl.Eo.FunctionWrapper<efl_text_annotation_del_api_delegate>(Module, "efl_text_annotation_del");

        private static bool annotation_del(System.IntPtr obj, System.IntPtr pd, Efl.TextAnnotateAnnotation annotation)
        {
            Eina.Log.Debug("function efl_text_annotation_del was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Text)ws.Target).DelAnnotation(annotation);
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
                return efl_text_annotation_del_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), annotation);
            }
        }

        private static efl_text_annotation_del_delegate efl_text_annotation_del_static_delegate;

        
        private delegate void efl_text_annotation_positions_get_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextAnnotateAnnotation annotation,  Efl.TextCursorCursor start,  Efl.TextCursorCursor end);

        
        public delegate void efl_text_annotation_positions_get_api_delegate(System.IntPtr obj,  Efl.TextAnnotateAnnotation annotation,  Efl.TextCursorCursor start,  Efl.TextCursorCursor end);

        public static Efl.Eo.FunctionWrapper<efl_text_annotation_positions_get_api_delegate> efl_text_annotation_positions_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_annotation_positions_get_api_delegate>(Module, "efl_text_annotation_positions_get");

        private static void annotation_positions_get(System.IntPtr obj, System.IntPtr pd, Efl.TextAnnotateAnnotation annotation, Efl.TextCursorCursor start, Efl.TextCursorCursor end)
        {
            Eina.Log.Debug("function efl_text_annotation_positions_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                    
                try
                {
                    ((Text)ws.Target).GetAnnotationPositions(annotation, start, end);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                        
            }
            else
            {
                efl_text_annotation_positions_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), annotation, start, end);
            }
        }

        private static efl_text_annotation_positions_get_delegate efl_text_annotation_positions_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_text_annotation_is_item_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextAnnotateAnnotation annotation);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_text_annotation_is_item_api_delegate(System.IntPtr obj,  Efl.TextAnnotateAnnotation annotation);

        public static Efl.Eo.FunctionWrapper<efl_text_annotation_is_item_api_delegate> efl_text_annotation_is_item_ptr = new Efl.Eo.FunctionWrapper<efl_text_annotation_is_item_api_delegate>(Module, "efl_text_annotation_is_item");

        private static bool annotation_is_item(System.IntPtr obj, System.IntPtr pd, Efl.TextAnnotateAnnotation annotation)
        {
            Eina.Log.Debug("function efl_text_annotation_is_item was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Text)ws.Target).AnnotationIsItem(annotation);
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
                return efl_text_annotation_is_item_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), annotation);
            }
        }

        private static efl_text_annotation_is_item_delegate efl_text_annotation_is_item_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_text_item_geometry_get_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextAnnotateAnnotation an,  out int x,  out int y,  out int w,  out int h);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_text_item_geometry_get_api_delegate(System.IntPtr obj,  Efl.TextAnnotateAnnotation an,  out int x,  out int y,  out int w,  out int h);

        public static Efl.Eo.FunctionWrapper<efl_text_item_geometry_get_api_delegate> efl_text_item_geometry_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_item_geometry_get_api_delegate>(Module, "efl_text_item_geometry_get");

        private static bool item_geometry_get(System.IntPtr obj, System.IntPtr pd, Efl.TextAnnotateAnnotation an, out int x, out int y, out int w, out int h)
        {
            Eina.Log.Debug("function efl_text_item_geometry_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                        x = default(int);        y = default(int);        w = default(int);        h = default(int);                                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Text)ws.Target).GetItemGeometry(an, out x, out y, out w, out h);
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
                return efl_text_item_geometry_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), an, out x, out y, out w, out h);
            }
        }

        private static efl_text_item_geometry_get_delegate efl_text_item_geometry_get_static_delegate;

        
        private delegate Efl.TextAnnotateAnnotation efl_text_cursor_item_insert_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String item, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String format);

        
        public delegate Efl.TextAnnotateAnnotation efl_text_cursor_item_insert_api_delegate(System.IntPtr obj,  Efl.TextCursorCursor cur, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String item, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String format);

        public static Efl.Eo.FunctionWrapper<efl_text_cursor_item_insert_api_delegate> efl_text_cursor_item_insert_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_item_insert_api_delegate>(Module, "efl_text_cursor_item_insert");

        private static Efl.TextAnnotateAnnotation cursor_item_insert(System.IntPtr obj, System.IntPtr pd, Efl.TextCursorCursor cur, System.String item, System.String format)
        {
            Eina.Log.Debug("function efl_text_cursor_item_insert was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                    Efl.TextAnnotateAnnotation _ret_var = default(Efl.TextAnnotateAnnotation);
                try
                {
                    _ret_var = ((Text)ws.Target).CursorItemInsert(cur, item, format);
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
                return efl_text_cursor_item_insert_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), cur, item, format);
            }
        }

        private static efl_text_cursor_item_insert_delegate efl_text_cursor_item_insert_static_delegate;

        
        private delegate Efl.TextCursorCursor efl_text_cursor_get_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorGetType get_type);

        
        public delegate Efl.TextCursorCursor efl_text_cursor_get_api_delegate(System.IntPtr obj,  Efl.TextCursorGetType get_type);

        public static Efl.Eo.FunctionWrapper<efl_text_cursor_get_api_delegate> efl_text_cursor_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_get_api_delegate>(Module, "efl_text_cursor_get");

        private static Efl.TextCursorCursor text_cursor_get(System.IntPtr obj, System.IntPtr pd, Efl.TextCursorGetType get_type)
        {
            Eina.Log.Debug("function efl_text_cursor_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    Efl.TextCursorCursor _ret_var = default(Efl.TextCursorCursor);
                try
                {
                    _ret_var = ((Text)ws.Target).GetTextCursor(get_type);
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
                return efl_text_cursor_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), get_type);
            }
        }

        private static efl_text_cursor_get_delegate efl_text_cursor_get_static_delegate;

        
        private delegate int efl_text_cursor_position_get_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur);

        
        public delegate int efl_text_cursor_position_get_api_delegate(System.IntPtr obj,  Efl.TextCursorCursor cur);

        public static Efl.Eo.FunctionWrapper<efl_text_cursor_position_get_api_delegate> efl_text_cursor_position_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_position_get_api_delegate>(Module, "efl_text_cursor_position_get");

        private static int cursor_position_get(System.IntPtr obj, System.IntPtr pd, Efl.TextCursorCursor cur)
        {
            Eina.Log.Debug("function efl_text_cursor_position_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    int _ret_var = default(int);
                try
                {
                    _ret_var = ((Text)ws.Target).GetCursorPosition(cur);
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
                return efl_text_cursor_position_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), cur);
            }
        }

        private static efl_text_cursor_position_get_delegate efl_text_cursor_position_get_static_delegate;

        
        private delegate void efl_text_cursor_position_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur,  int position);

        
        public delegate void efl_text_cursor_position_set_api_delegate(System.IntPtr obj,  Efl.TextCursorCursor cur,  int position);

        public static Efl.Eo.FunctionWrapper<efl_text_cursor_position_set_api_delegate> efl_text_cursor_position_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_position_set_api_delegate>(Module, "efl_text_cursor_position_set");

        private static void cursor_position_set(System.IntPtr obj, System.IntPtr pd, Efl.TextCursorCursor cur, int position)
        {
            Eina.Log.Debug("function efl_text_cursor_position_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((Text)ws.Target).SetCursorPosition(cur, position);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_text_cursor_position_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), cur, position);
            }
        }

        private static efl_text_cursor_position_set_delegate efl_text_cursor_position_set_static_delegate;

        
        private delegate Eina.Unicode efl_text_cursor_content_get_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur);

        
        public delegate Eina.Unicode efl_text_cursor_content_get_api_delegate(System.IntPtr obj,  Efl.TextCursorCursor cur);

        public static Efl.Eo.FunctionWrapper<efl_text_cursor_content_get_api_delegate> efl_text_cursor_content_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_content_get_api_delegate>(Module, "efl_text_cursor_content_get");

        private static Eina.Unicode cursor_content_get(System.IntPtr obj, System.IntPtr pd, Efl.TextCursorCursor cur)
        {
            Eina.Log.Debug("function efl_text_cursor_content_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    Eina.Unicode _ret_var = default(Eina.Unicode);
                try
                {
                    _ret_var = ((Text)ws.Target).GetCursorContent(cur);
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
                return efl_text_cursor_content_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), cur);
            }
        }

        private static efl_text_cursor_content_get_delegate efl_text_cursor_content_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_text_cursor_geometry_get_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur,  Efl.TextCursorType ctype,  out int cx,  out int cy,  out int cw,  out int ch,  out int cx2,  out int cy2,  out int cw2,  out int ch2);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_text_cursor_geometry_get_api_delegate(System.IntPtr obj,  Efl.TextCursorCursor cur,  Efl.TextCursorType ctype,  out int cx,  out int cy,  out int cw,  out int ch,  out int cx2,  out int cy2,  out int cw2,  out int ch2);

        public static Efl.Eo.FunctionWrapper<efl_text_cursor_geometry_get_api_delegate> efl_text_cursor_geometry_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_geometry_get_api_delegate>(Module, "efl_text_cursor_geometry_get");

        private static bool cursor_geometry_get(System.IntPtr obj, System.IntPtr pd, Efl.TextCursorCursor cur, Efl.TextCursorType ctype, out int cx, out int cy, out int cw, out int ch, out int cx2, out int cy2, out int cw2, out int ch2)
        {
            Eina.Log.Debug("function efl_text_cursor_geometry_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                                        cx = default(int);        cy = default(int);        cw = default(int);        ch = default(int);        cx2 = default(int);        cy2 = default(int);        cw2 = default(int);        ch2 = default(int);                                                                                            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Text)ws.Target).GetCursorGeometry(cur, ctype, out cx, out cy, out cw, out ch, out cx2, out cy2, out cw2, out ch2);
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
                return efl_text_cursor_geometry_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), cur, ctype, out cx, out cy, out cw, out ch, out cx2, out cy2, out cw2, out ch2);
            }
        }

        private static efl_text_cursor_geometry_get_delegate efl_text_cursor_geometry_get_static_delegate;

        
        private delegate Efl.TextCursorCursor efl_text_cursor_new_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.TextCursorCursor efl_text_cursor_new_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_text_cursor_new_api_delegate> efl_text_cursor_new_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_new_api_delegate>(Module, "efl_text_cursor_new");

        private static Efl.TextCursorCursor cursor_new(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_text_cursor_new was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.TextCursorCursor _ret_var = default(Efl.TextCursorCursor);
                try
                {
                    _ret_var = ((Text)ws.Target).NewCursor();
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
                return efl_text_cursor_new_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_text_cursor_new_delegate efl_text_cursor_new_static_delegate;

        
        private delegate void efl_text_cursor_free_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur);

        
        public delegate void efl_text_cursor_free_api_delegate(System.IntPtr obj,  Efl.TextCursorCursor cur);

        public static Efl.Eo.FunctionWrapper<efl_text_cursor_free_api_delegate> efl_text_cursor_free_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_free_api_delegate>(Module, "efl_text_cursor_free");

        private static void cursor_free(System.IntPtr obj, System.IntPtr pd, Efl.TextCursorCursor cur)
        {
            Eina.Log.Debug("function efl_text_cursor_free was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).CursorFree(cur);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_cursor_free_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), cur);
            }
        }

        private static efl_text_cursor_free_delegate efl_text_cursor_free_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_text_cursor_equal_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur1,  Efl.TextCursorCursor cur2);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_text_cursor_equal_api_delegate(System.IntPtr obj,  Efl.TextCursorCursor cur1,  Efl.TextCursorCursor cur2);

        public static Efl.Eo.FunctionWrapper<efl_text_cursor_equal_api_delegate> efl_text_cursor_equal_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_equal_api_delegate>(Module, "efl_text_cursor_equal");

        private static bool cursor_equal(System.IntPtr obj, System.IntPtr pd, Efl.TextCursorCursor cur1, Efl.TextCursorCursor cur2)
        {
            Eina.Log.Debug("function efl_text_cursor_equal was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Text)ws.Target).CursorEqual(cur1, cur2);
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
                return efl_text_cursor_equal_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), cur1, cur2);
            }
        }

        private static efl_text_cursor_equal_delegate efl_text_cursor_equal_static_delegate;

        
        private delegate int efl_text_cursor_compare_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur1,  Efl.TextCursorCursor cur2);

        
        public delegate int efl_text_cursor_compare_api_delegate(System.IntPtr obj,  Efl.TextCursorCursor cur1,  Efl.TextCursorCursor cur2);

        public static Efl.Eo.FunctionWrapper<efl_text_cursor_compare_api_delegate> efl_text_cursor_compare_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_compare_api_delegate>(Module, "efl_text_cursor_compare");

        private static int cursor_compare(System.IntPtr obj, System.IntPtr pd, Efl.TextCursorCursor cur1, Efl.TextCursorCursor cur2)
        {
            Eina.Log.Debug("function efl_text_cursor_compare was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            int _ret_var = default(int);
                try
                {
                    _ret_var = ((Text)ws.Target).CursorCompare(cur1, cur2);
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
                return efl_text_cursor_compare_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), cur1, cur2);
            }
        }

        private static efl_text_cursor_compare_delegate efl_text_cursor_compare_static_delegate;

        
        private delegate void efl_text_cursor_copy_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor dst,  Efl.TextCursorCursor src);

        
        public delegate void efl_text_cursor_copy_api_delegate(System.IntPtr obj,  Efl.TextCursorCursor dst,  Efl.TextCursorCursor src);

        public static Efl.Eo.FunctionWrapper<efl_text_cursor_copy_api_delegate> efl_text_cursor_copy_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_copy_api_delegate>(Module, "efl_text_cursor_copy");

        private static void cursor_copy(System.IntPtr obj, System.IntPtr pd, Efl.TextCursorCursor dst, Efl.TextCursorCursor src)
        {
            Eina.Log.Debug("function efl_text_cursor_copy was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((Text)ws.Target).CursorCopy(dst, src);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_text_cursor_copy_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), dst, src);
            }
        }

        private static efl_text_cursor_copy_delegate efl_text_cursor_copy_static_delegate;

        
        private delegate void efl_text_cursor_char_next_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur);

        
        public delegate void efl_text_cursor_char_next_api_delegate(System.IntPtr obj,  Efl.TextCursorCursor cur);

        public static Efl.Eo.FunctionWrapper<efl_text_cursor_char_next_api_delegate> efl_text_cursor_char_next_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_char_next_api_delegate>(Module, "efl_text_cursor_char_next");

        private static void cursor_char_next(System.IntPtr obj, System.IntPtr pd, Efl.TextCursorCursor cur)
        {
            Eina.Log.Debug("function efl_text_cursor_char_next was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).CursorCharNext(cur);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_cursor_char_next_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), cur);
            }
        }

        private static efl_text_cursor_char_next_delegate efl_text_cursor_char_next_static_delegate;

        
        private delegate void efl_text_cursor_char_prev_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur);

        
        public delegate void efl_text_cursor_char_prev_api_delegate(System.IntPtr obj,  Efl.TextCursorCursor cur);

        public static Efl.Eo.FunctionWrapper<efl_text_cursor_char_prev_api_delegate> efl_text_cursor_char_prev_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_char_prev_api_delegate>(Module, "efl_text_cursor_char_prev");

        private static void cursor_char_prev(System.IntPtr obj, System.IntPtr pd, Efl.TextCursorCursor cur)
        {
            Eina.Log.Debug("function efl_text_cursor_char_prev was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).CursorCharPrev(cur);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_cursor_char_prev_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), cur);
            }
        }

        private static efl_text_cursor_char_prev_delegate efl_text_cursor_char_prev_static_delegate;

        
        private delegate void efl_text_cursor_cluster_next_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur);

        
        public delegate void efl_text_cursor_cluster_next_api_delegate(System.IntPtr obj,  Efl.TextCursorCursor cur);

        public static Efl.Eo.FunctionWrapper<efl_text_cursor_cluster_next_api_delegate> efl_text_cursor_cluster_next_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_cluster_next_api_delegate>(Module, "efl_text_cursor_cluster_next");

        private static void cursor_cluster_next(System.IntPtr obj, System.IntPtr pd, Efl.TextCursorCursor cur)
        {
            Eina.Log.Debug("function efl_text_cursor_cluster_next was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).CursorClusterNext(cur);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_cursor_cluster_next_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), cur);
            }
        }

        private static efl_text_cursor_cluster_next_delegate efl_text_cursor_cluster_next_static_delegate;

        
        private delegate void efl_text_cursor_cluster_prev_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur);

        
        public delegate void efl_text_cursor_cluster_prev_api_delegate(System.IntPtr obj,  Efl.TextCursorCursor cur);

        public static Efl.Eo.FunctionWrapper<efl_text_cursor_cluster_prev_api_delegate> efl_text_cursor_cluster_prev_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_cluster_prev_api_delegate>(Module, "efl_text_cursor_cluster_prev");

        private static void cursor_cluster_prev(System.IntPtr obj, System.IntPtr pd, Efl.TextCursorCursor cur)
        {
            Eina.Log.Debug("function efl_text_cursor_cluster_prev was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).CursorClusterPrev(cur);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_cursor_cluster_prev_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), cur);
            }
        }

        private static efl_text_cursor_cluster_prev_delegate efl_text_cursor_cluster_prev_static_delegate;

        
        private delegate void efl_text_cursor_paragraph_char_first_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur);

        
        public delegate void efl_text_cursor_paragraph_char_first_api_delegate(System.IntPtr obj,  Efl.TextCursorCursor cur);

        public static Efl.Eo.FunctionWrapper<efl_text_cursor_paragraph_char_first_api_delegate> efl_text_cursor_paragraph_char_first_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_paragraph_char_first_api_delegate>(Module, "efl_text_cursor_paragraph_char_first");

        private static void cursor_paragraph_char_first(System.IntPtr obj, System.IntPtr pd, Efl.TextCursorCursor cur)
        {
            Eina.Log.Debug("function efl_text_cursor_paragraph_char_first was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).CursorParagraphCharFirst(cur);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_cursor_paragraph_char_first_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), cur);
            }
        }

        private static efl_text_cursor_paragraph_char_first_delegate efl_text_cursor_paragraph_char_first_static_delegate;

        
        private delegate void efl_text_cursor_paragraph_char_last_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur);

        
        public delegate void efl_text_cursor_paragraph_char_last_api_delegate(System.IntPtr obj,  Efl.TextCursorCursor cur);

        public static Efl.Eo.FunctionWrapper<efl_text_cursor_paragraph_char_last_api_delegate> efl_text_cursor_paragraph_char_last_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_paragraph_char_last_api_delegate>(Module, "efl_text_cursor_paragraph_char_last");

        private static void cursor_paragraph_char_last(System.IntPtr obj, System.IntPtr pd, Efl.TextCursorCursor cur)
        {
            Eina.Log.Debug("function efl_text_cursor_paragraph_char_last was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).CursorParagraphCharLast(cur);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_cursor_paragraph_char_last_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), cur);
            }
        }

        private static efl_text_cursor_paragraph_char_last_delegate efl_text_cursor_paragraph_char_last_static_delegate;

        
        private delegate void efl_text_cursor_word_start_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur);

        
        public delegate void efl_text_cursor_word_start_api_delegate(System.IntPtr obj,  Efl.TextCursorCursor cur);

        public static Efl.Eo.FunctionWrapper<efl_text_cursor_word_start_api_delegate> efl_text_cursor_word_start_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_word_start_api_delegate>(Module, "efl_text_cursor_word_start");

        private static void cursor_word_start(System.IntPtr obj, System.IntPtr pd, Efl.TextCursorCursor cur)
        {
            Eina.Log.Debug("function efl_text_cursor_word_start was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).CursorWordStart(cur);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_cursor_word_start_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), cur);
            }
        }

        private static efl_text_cursor_word_start_delegate efl_text_cursor_word_start_static_delegate;

        
        private delegate void efl_text_cursor_word_end_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur);

        
        public delegate void efl_text_cursor_word_end_api_delegate(System.IntPtr obj,  Efl.TextCursorCursor cur);

        public static Efl.Eo.FunctionWrapper<efl_text_cursor_word_end_api_delegate> efl_text_cursor_word_end_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_word_end_api_delegate>(Module, "efl_text_cursor_word_end");

        private static void cursor_word_end(System.IntPtr obj, System.IntPtr pd, Efl.TextCursorCursor cur)
        {
            Eina.Log.Debug("function efl_text_cursor_word_end was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).CursorWordEnd(cur);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_cursor_word_end_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), cur);
            }
        }

        private static efl_text_cursor_word_end_delegate efl_text_cursor_word_end_static_delegate;

        
        private delegate void efl_text_cursor_line_char_first_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur);

        
        public delegate void efl_text_cursor_line_char_first_api_delegate(System.IntPtr obj,  Efl.TextCursorCursor cur);

        public static Efl.Eo.FunctionWrapper<efl_text_cursor_line_char_first_api_delegate> efl_text_cursor_line_char_first_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_line_char_first_api_delegate>(Module, "efl_text_cursor_line_char_first");

        private static void cursor_line_char_first(System.IntPtr obj, System.IntPtr pd, Efl.TextCursorCursor cur)
        {
            Eina.Log.Debug("function efl_text_cursor_line_char_first was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).CursorLineCharFirst(cur);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_cursor_line_char_first_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), cur);
            }
        }

        private static efl_text_cursor_line_char_first_delegate efl_text_cursor_line_char_first_static_delegate;

        
        private delegate void efl_text_cursor_line_char_last_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur);

        
        public delegate void efl_text_cursor_line_char_last_api_delegate(System.IntPtr obj,  Efl.TextCursorCursor cur);

        public static Efl.Eo.FunctionWrapper<efl_text_cursor_line_char_last_api_delegate> efl_text_cursor_line_char_last_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_line_char_last_api_delegate>(Module, "efl_text_cursor_line_char_last");

        private static void cursor_line_char_last(System.IntPtr obj, System.IntPtr pd, Efl.TextCursorCursor cur)
        {
            Eina.Log.Debug("function efl_text_cursor_line_char_last was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).CursorLineCharLast(cur);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_cursor_line_char_last_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), cur);
            }
        }

        private static efl_text_cursor_line_char_last_delegate efl_text_cursor_line_char_last_static_delegate;

        
        private delegate void efl_text_cursor_paragraph_first_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur);

        
        public delegate void efl_text_cursor_paragraph_first_api_delegate(System.IntPtr obj,  Efl.TextCursorCursor cur);

        public static Efl.Eo.FunctionWrapper<efl_text_cursor_paragraph_first_api_delegate> efl_text_cursor_paragraph_first_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_paragraph_first_api_delegate>(Module, "efl_text_cursor_paragraph_first");

        private static void cursor_paragraph_first(System.IntPtr obj, System.IntPtr pd, Efl.TextCursorCursor cur)
        {
            Eina.Log.Debug("function efl_text_cursor_paragraph_first was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).CursorParagraphFirst(cur);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_cursor_paragraph_first_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), cur);
            }
        }

        private static efl_text_cursor_paragraph_first_delegate efl_text_cursor_paragraph_first_static_delegate;

        
        private delegate void efl_text_cursor_paragraph_last_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur);

        
        public delegate void efl_text_cursor_paragraph_last_api_delegate(System.IntPtr obj,  Efl.TextCursorCursor cur);

        public static Efl.Eo.FunctionWrapper<efl_text_cursor_paragraph_last_api_delegate> efl_text_cursor_paragraph_last_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_paragraph_last_api_delegate>(Module, "efl_text_cursor_paragraph_last");

        private static void cursor_paragraph_last(System.IntPtr obj, System.IntPtr pd, Efl.TextCursorCursor cur)
        {
            Eina.Log.Debug("function efl_text_cursor_paragraph_last was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).CursorParagraphLast(cur);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_cursor_paragraph_last_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), cur);
            }
        }

        private static efl_text_cursor_paragraph_last_delegate efl_text_cursor_paragraph_last_static_delegate;

        
        private delegate void efl_text_cursor_paragraph_next_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur);

        
        public delegate void efl_text_cursor_paragraph_next_api_delegate(System.IntPtr obj,  Efl.TextCursorCursor cur);

        public static Efl.Eo.FunctionWrapper<efl_text_cursor_paragraph_next_api_delegate> efl_text_cursor_paragraph_next_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_paragraph_next_api_delegate>(Module, "efl_text_cursor_paragraph_next");

        private static void cursor_paragraph_next(System.IntPtr obj, System.IntPtr pd, Efl.TextCursorCursor cur)
        {
            Eina.Log.Debug("function efl_text_cursor_paragraph_next was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).CursorParagraphNext(cur);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_cursor_paragraph_next_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), cur);
            }
        }

        private static efl_text_cursor_paragraph_next_delegate efl_text_cursor_paragraph_next_static_delegate;

        
        private delegate void efl_text_cursor_paragraph_prev_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur);

        
        public delegate void efl_text_cursor_paragraph_prev_api_delegate(System.IntPtr obj,  Efl.TextCursorCursor cur);

        public static Efl.Eo.FunctionWrapper<efl_text_cursor_paragraph_prev_api_delegate> efl_text_cursor_paragraph_prev_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_paragraph_prev_api_delegate>(Module, "efl_text_cursor_paragraph_prev");

        private static void cursor_paragraph_prev(System.IntPtr obj, System.IntPtr pd, Efl.TextCursorCursor cur)
        {
            Eina.Log.Debug("function efl_text_cursor_paragraph_prev was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).CursorParagraphPrev(cur);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_cursor_paragraph_prev_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), cur);
            }
        }

        private static efl_text_cursor_paragraph_prev_delegate efl_text_cursor_paragraph_prev_static_delegate;

        
        private delegate void efl_text_cursor_line_jump_by_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur,  int by);

        
        public delegate void efl_text_cursor_line_jump_by_api_delegate(System.IntPtr obj,  Efl.TextCursorCursor cur,  int by);

        public static Efl.Eo.FunctionWrapper<efl_text_cursor_line_jump_by_api_delegate> efl_text_cursor_line_jump_by_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_line_jump_by_api_delegate>(Module, "efl_text_cursor_line_jump_by");

        private static void cursor_line_jump_by(System.IntPtr obj, System.IntPtr pd, Efl.TextCursorCursor cur, int by)
        {
            Eina.Log.Debug("function efl_text_cursor_line_jump_by was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((Text)ws.Target).CursorLineJumpBy(cur, by);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_text_cursor_line_jump_by_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), cur, by);
            }
        }

        private static efl_text_cursor_line_jump_by_delegate efl_text_cursor_line_jump_by_static_delegate;

        
        private delegate void efl_text_cursor_coord_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur,  int x,  int y);

        
        public delegate void efl_text_cursor_coord_set_api_delegate(System.IntPtr obj,  Efl.TextCursorCursor cur,  int x,  int y);

        public static Efl.Eo.FunctionWrapper<efl_text_cursor_coord_set_api_delegate> efl_text_cursor_coord_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_coord_set_api_delegate>(Module, "efl_text_cursor_coord_set");

        private static void cursor_coord_set(System.IntPtr obj, System.IntPtr pd, Efl.TextCursorCursor cur, int x, int y)
        {
            Eina.Log.Debug("function efl_text_cursor_coord_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                    
                try
                {
                    ((Text)ws.Target).SetCursorCoord(cur, x, y);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                        
            }
            else
            {
                efl_text_cursor_coord_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), cur, x, y);
            }
        }

        private static efl_text_cursor_coord_set_delegate efl_text_cursor_coord_set_static_delegate;

        
        private delegate void efl_text_cursor_cluster_coord_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur,  int x,  int y);

        
        public delegate void efl_text_cursor_cluster_coord_set_api_delegate(System.IntPtr obj,  Efl.TextCursorCursor cur,  int x,  int y);

        public static Efl.Eo.FunctionWrapper<efl_text_cursor_cluster_coord_set_api_delegate> efl_text_cursor_cluster_coord_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_cluster_coord_set_api_delegate>(Module, "efl_text_cursor_cluster_coord_set");

        private static void cursor_cluster_coord_set(System.IntPtr obj, System.IntPtr pd, Efl.TextCursorCursor cur, int x, int y)
        {
            Eina.Log.Debug("function efl_text_cursor_cluster_coord_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                    
                try
                {
                    ((Text)ws.Target).SetCursorClusterCoord(cur, x, y);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                        
            }
            else
            {
                efl_text_cursor_cluster_coord_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), cur, x, y);
            }
        }

        private static efl_text_cursor_cluster_coord_set_delegate efl_text_cursor_cluster_coord_set_static_delegate;

        
        private delegate int efl_text_cursor_text_insert_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String text);

        
        public delegate int efl_text_cursor_text_insert_api_delegate(System.IntPtr obj,  Efl.TextCursorCursor cur, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String text);

        public static Efl.Eo.FunctionWrapper<efl_text_cursor_text_insert_api_delegate> efl_text_cursor_text_insert_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_text_insert_api_delegate>(Module, "efl_text_cursor_text_insert");

        private static int cursor_text_insert(System.IntPtr obj, System.IntPtr pd, Efl.TextCursorCursor cur, System.String text)
        {
            Eina.Log.Debug("function efl_text_cursor_text_insert was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            int _ret_var = default(int);
                try
                {
                    _ret_var = ((Text)ws.Target).CursorTextInsert(cur, text);
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
                return efl_text_cursor_text_insert_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), cur, text);
            }
        }

        private static efl_text_cursor_text_insert_delegate efl_text_cursor_text_insert_static_delegate;

        
        private delegate void efl_text_cursor_char_delete_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur);

        
        public delegate void efl_text_cursor_char_delete_api_delegate(System.IntPtr obj,  Efl.TextCursorCursor cur);

        public static Efl.Eo.FunctionWrapper<efl_text_cursor_char_delete_api_delegate> efl_text_cursor_char_delete_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_char_delete_api_delegate>(Module, "efl_text_cursor_char_delete");

        private static void cursor_char_delete(System.IntPtr obj, System.IntPtr pd, Efl.TextCursorCursor cur)
        {
            Eina.Log.Debug("function efl_text_cursor_char_delete was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).CursorCharDelete(cur);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_cursor_char_delete_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), cur);
            }
        }

        private static efl_text_cursor_char_delete_delegate efl_text_cursor_char_delete_static_delegate;

        
        private delegate void efl_text_font_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] out System.String font,  out Efl.Font.Size size);

        
        public delegate void efl_text_font_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] out System.String font,  out Efl.Font.Size size);

        public static Efl.Eo.FunctionWrapper<efl_text_font_get_api_delegate> efl_text_font_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_get_api_delegate>(Module, "efl_text_font_get");

        private static void font_get(System.IntPtr obj, System.IntPtr pd, out System.String font, out Efl.Font.Size size)
        {
            Eina.Log.Debug("function efl_text_font_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                        System.String _out_font = default(System.String);
        size = default(Efl.Font.Size);                            
                try
                {
                    ((Text)ws.Target).GetFont(out _out_font, out size);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        font = _out_font;
                                
            }
            else
            {
                efl_text_font_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out font, out size);
            }
        }

        private static efl_text_font_get_delegate efl_text_font_get_static_delegate;

        
        private delegate void efl_text_font_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String font,  Efl.Font.Size size);

        
        public delegate void efl_text_font_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String font,  Efl.Font.Size size);

        public static Efl.Eo.FunctionWrapper<efl_text_font_set_api_delegate> efl_text_font_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_set_api_delegate>(Module, "efl_text_font_set");

        private static void font_set(System.IntPtr obj, System.IntPtr pd, System.String font, Efl.Font.Size size)
        {
            Eina.Log.Debug("function efl_text_font_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((Text)ws.Target).SetFont(font, size);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_text_font_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), font, size);
            }
        }

        private static efl_text_font_set_delegate efl_text_font_set_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_text_font_source_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_text_font_source_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_text_font_source_get_api_delegate> efl_text_font_source_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_source_get_api_delegate>(Module, "efl_text_font_source_get");

        private static System.String font_source_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_text_font_source_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((Text)ws.Target).GetFontSource();
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
                return efl_text_font_source_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_text_font_source_get_delegate efl_text_font_source_get_static_delegate;

        
        private delegate void efl_text_font_source_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String font_source);

        
        public delegate void efl_text_font_source_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String font_source);

        public static Efl.Eo.FunctionWrapper<efl_text_font_source_set_api_delegate> efl_text_font_source_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_source_set_api_delegate>(Module, "efl_text_font_source_set");

        private static void font_source_set(System.IntPtr obj, System.IntPtr pd, System.String font_source)
        {
            Eina.Log.Debug("function efl_text_font_source_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetFontSource(font_source);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_font_source_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), font_source);
            }
        }

        private static efl_text_font_source_set_delegate efl_text_font_source_set_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_text_font_fallbacks_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_text_font_fallbacks_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_text_font_fallbacks_get_api_delegate> efl_text_font_fallbacks_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_fallbacks_get_api_delegate>(Module, "efl_text_font_fallbacks_get");

        private static System.String font_fallbacks_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_text_font_fallbacks_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((Text)ws.Target).GetFontFallbacks();
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
                return efl_text_font_fallbacks_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_text_font_fallbacks_get_delegate efl_text_font_fallbacks_get_static_delegate;

        
        private delegate void efl_text_font_fallbacks_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String font_fallbacks);

        
        public delegate void efl_text_font_fallbacks_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String font_fallbacks);

        public static Efl.Eo.FunctionWrapper<efl_text_font_fallbacks_set_api_delegate> efl_text_font_fallbacks_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_fallbacks_set_api_delegate>(Module, "efl_text_font_fallbacks_set");

        private static void font_fallbacks_set(System.IntPtr obj, System.IntPtr pd, System.String font_fallbacks)
        {
            Eina.Log.Debug("function efl_text_font_fallbacks_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetFontFallbacks(font_fallbacks);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_font_fallbacks_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), font_fallbacks);
            }
        }

        private static efl_text_font_fallbacks_set_delegate efl_text_font_fallbacks_set_static_delegate;

        
        private delegate Efl.TextFontWeight efl_text_font_weight_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.TextFontWeight efl_text_font_weight_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_text_font_weight_get_api_delegate> efl_text_font_weight_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_weight_get_api_delegate>(Module, "efl_text_font_weight_get");

        private static Efl.TextFontWeight font_weight_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_text_font_weight_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.TextFontWeight _ret_var = default(Efl.TextFontWeight);
                try
                {
                    _ret_var = ((Text)ws.Target).GetFontWeight();
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
                return efl_text_font_weight_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_text_font_weight_get_delegate efl_text_font_weight_get_static_delegate;

        
        private delegate void efl_text_font_weight_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextFontWeight font_weight);

        
        public delegate void efl_text_font_weight_set_api_delegate(System.IntPtr obj,  Efl.TextFontWeight font_weight);

        public static Efl.Eo.FunctionWrapper<efl_text_font_weight_set_api_delegate> efl_text_font_weight_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_weight_set_api_delegate>(Module, "efl_text_font_weight_set");

        private static void font_weight_set(System.IntPtr obj, System.IntPtr pd, Efl.TextFontWeight font_weight)
        {
            Eina.Log.Debug("function efl_text_font_weight_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetFontWeight(font_weight);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_font_weight_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), font_weight);
            }
        }

        private static efl_text_font_weight_set_delegate efl_text_font_weight_set_static_delegate;

        
        private delegate Efl.TextFontSlant efl_text_font_slant_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.TextFontSlant efl_text_font_slant_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_text_font_slant_get_api_delegate> efl_text_font_slant_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_slant_get_api_delegate>(Module, "efl_text_font_slant_get");

        private static Efl.TextFontSlant font_slant_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_text_font_slant_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.TextFontSlant _ret_var = default(Efl.TextFontSlant);
                try
                {
                    _ret_var = ((Text)ws.Target).GetFontSlant();
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
                return efl_text_font_slant_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_text_font_slant_get_delegate efl_text_font_slant_get_static_delegate;

        
        private delegate void efl_text_font_slant_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextFontSlant style);

        
        public delegate void efl_text_font_slant_set_api_delegate(System.IntPtr obj,  Efl.TextFontSlant style);

        public static Efl.Eo.FunctionWrapper<efl_text_font_slant_set_api_delegate> efl_text_font_slant_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_slant_set_api_delegate>(Module, "efl_text_font_slant_set");

        private static void font_slant_set(System.IntPtr obj, System.IntPtr pd, Efl.TextFontSlant style)
        {
            Eina.Log.Debug("function efl_text_font_slant_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetFontSlant(style);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_font_slant_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), style);
            }
        }

        private static efl_text_font_slant_set_delegate efl_text_font_slant_set_static_delegate;

        
        private delegate Efl.TextFontWidth efl_text_font_width_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.TextFontWidth efl_text_font_width_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_text_font_width_get_api_delegate> efl_text_font_width_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_width_get_api_delegate>(Module, "efl_text_font_width_get");

        private static Efl.TextFontWidth font_width_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_text_font_width_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.TextFontWidth _ret_var = default(Efl.TextFontWidth);
                try
                {
                    _ret_var = ((Text)ws.Target).GetFontWidth();
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
                return efl_text_font_width_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_text_font_width_get_delegate efl_text_font_width_get_static_delegate;

        
        private delegate void efl_text_font_width_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextFontWidth width);

        
        public delegate void efl_text_font_width_set_api_delegate(System.IntPtr obj,  Efl.TextFontWidth width);

        public static Efl.Eo.FunctionWrapper<efl_text_font_width_set_api_delegate> efl_text_font_width_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_width_set_api_delegate>(Module, "efl_text_font_width_set");

        private static void font_width_set(System.IntPtr obj, System.IntPtr pd, Efl.TextFontWidth width)
        {
            Eina.Log.Debug("function efl_text_font_width_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetFontWidth(width);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_font_width_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), width);
            }
        }

        private static efl_text_font_width_set_delegate efl_text_font_width_set_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_text_font_lang_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_text_font_lang_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_text_font_lang_get_api_delegate> efl_text_font_lang_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_lang_get_api_delegate>(Module, "efl_text_font_lang_get");

        private static System.String font_lang_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_text_font_lang_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((Text)ws.Target).GetFontLang();
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
                return efl_text_font_lang_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_text_font_lang_get_delegate efl_text_font_lang_get_static_delegate;

        
        private delegate void efl_text_font_lang_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String lang);

        
        public delegate void efl_text_font_lang_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String lang);

        public static Efl.Eo.FunctionWrapper<efl_text_font_lang_set_api_delegate> efl_text_font_lang_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_lang_set_api_delegate>(Module, "efl_text_font_lang_set");

        private static void font_lang_set(System.IntPtr obj, System.IntPtr pd, System.String lang)
        {
            Eina.Log.Debug("function efl_text_font_lang_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetFontLang(lang);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_font_lang_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), lang);
            }
        }

        private static efl_text_font_lang_set_delegate efl_text_font_lang_set_static_delegate;

        
        private delegate Efl.TextFontBitmapScalable efl_text_font_bitmap_scalable_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.TextFontBitmapScalable efl_text_font_bitmap_scalable_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_text_font_bitmap_scalable_get_api_delegate> efl_text_font_bitmap_scalable_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_bitmap_scalable_get_api_delegate>(Module, "efl_text_font_bitmap_scalable_get");

        private static Efl.TextFontBitmapScalable font_bitmap_scalable_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_text_font_bitmap_scalable_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.TextFontBitmapScalable _ret_var = default(Efl.TextFontBitmapScalable);
                try
                {
                    _ret_var = ((Text)ws.Target).GetFontBitmapScalable();
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
                return efl_text_font_bitmap_scalable_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_text_font_bitmap_scalable_get_delegate efl_text_font_bitmap_scalable_get_static_delegate;

        
        private delegate void efl_text_font_bitmap_scalable_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextFontBitmapScalable scalable);

        
        public delegate void efl_text_font_bitmap_scalable_set_api_delegate(System.IntPtr obj,  Efl.TextFontBitmapScalable scalable);

        public static Efl.Eo.FunctionWrapper<efl_text_font_bitmap_scalable_set_api_delegate> efl_text_font_bitmap_scalable_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_bitmap_scalable_set_api_delegate>(Module, "efl_text_font_bitmap_scalable_set");

        private static void font_bitmap_scalable_set(System.IntPtr obj, System.IntPtr pd, Efl.TextFontBitmapScalable scalable)
        {
            Eina.Log.Debug("function efl_text_font_bitmap_scalable_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetFontBitmapScalable(scalable);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_font_bitmap_scalable_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), scalable);
            }
        }

        private static efl_text_font_bitmap_scalable_set_delegate efl_text_font_bitmap_scalable_set_static_delegate;

        
        private delegate double efl_text_ellipsis_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate double efl_text_ellipsis_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_text_ellipsis_get_api_delegate> efl_text_ellipsis_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_ellipsis_get_api_delegate>(Module, "efl_text_ellipsis_get");

        private static double ellipsis_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_text_ellipsis_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            double _ret_var = default(double);
                try
                {
                    _ret_var = ((Text)ws.Target).GetEllipsis();
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
                return efl_text_ellipsis_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_text_ellipsis_get_delegate efl_text_ellipsis_get_static_delegate;

        
        private delegate void efl_text_ellipsis_set_delegate(System.IntPtr obj, System.IntPtr pd,  double value);

        
        public delegate void efl_text_ellipsis_set_api_delegate(System.IntPtr obj,  double value);

        public static Efl.Eo.FunctionWrapper<efl_text_ellipsis_set_api_delegate> efl_text_ellipsis_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_ellipsis_set_api_delegate>(Module, "efl_text_ellipsis_set");

        private static void ellipsis_set(System.IntPtr obj, System.IntPtr pd, double value)
        {
            Eina.Log.Debug("function efl_text_ellipsis_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetEllipsis(value);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_ellipsis_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), value);
            }
        }

        private static efl_text_ellipsis_set_delegate efl_text_ellipsis_set_static_delegate;

        
        private delegate Efl.TextFormatWrap efl_text_wrap_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.TextFormatWrap efl_text_wrap_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_text_wrap_get_api_delegate> efl_text_wrap_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_wrap_get_api_delegate>(Module, "efl_text_wrap_get");

        private static Efl.TextFormatWrap wrap_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_text_wrap_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.TextFormatWrap _ret_var = default(Efl.TextFormatWrap);
                try
                {
                    _ret_var = ((Text)ws.Target).GetWrap();
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
                return efl_text_wrap_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_text_wrap_get_delegate efl_text_wrap_get_static_delegate;

        
        private delegate void efl_text_wrap_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextFormatWrap wrap);

        
        public delegate void efl_text_wrap_set_api_delegate(System.IntPtr obj,  Efl.TextFormatWrap wrap);

        public static Efl.Eo.FunctionWrapper<efl_text_wrap_set_api_delegate> efl_text_wrap_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_wrap_set_api_delegate>(Module, "efl_text_wrap_set");

        private static void wrap_set(System.IntPtr obj, System.IntPtr pd, Efl.TextFormatWrap wrap)
        {
            Eina.Log.Debug("function efl_text_wrap_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetWrap(wrap);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_wrap_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), wrap);
            }
        }

        private static efl_text_wrap_set_delegate efl_text_wrap_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_text_multiline_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_text_multiline_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_text_multiline_get_api_delegate> efl_text_multiline_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_multiline_get_api_delegate>(Module, "efl_text_multiline_get");

        private static bool multiline_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_text_multiline_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Text)ws.Target).GetMultiline();
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
                return efl_text_multiline_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_text_multiline_get_delegate efl_text_multiline_get_static_delegate;

        
        private delegate void efl_text_multiline_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool enabled);

        
        public delegate void efl_text_multiline_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool enabled);

        public static Efl.Eo.FunctionWrapper<efl_text_multiline_set_api_delegate> efl_text_multiline_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_multiline_set_api_delegate>(Module, "efl_text_multiline_set");

        private static void multiline_set(System.IntPtr obj, System.IntPtr pd, bool enabled)
        {
            Eina.Log.Debug("function efl_text_multiline_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetMultiline(enabled);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_multiline_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), enabled);
            }
        }

        private static efl_text_multiline_set_delegate efl_text_multiline_set_static_delegate;

        
        private delegate Efl.TextFormatHorizontalAlignmentAutoType efl_text_halign_auto_type_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.TextFormatHorizontalAlignmentAutoType efl_text_halign_auto_type_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_text_halign_auto_type_get_api_delegate> efl_text_halign_auto_type_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_halign_auto_type_get_api_delegate>(Module, "efl_text_halign_auto_type_get");

        private static Efl.TextFormatHorizontalAlignmentAutoType halign_auto_type_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_text_halign_auto_type_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.TextFormatHorizontalAlignmentAutoType _ret_var = default(Efl.TextFormatHorizontalAlignmentAutoType);
                try
                {
                    _ret_var = ((Text)ws.Target).GetHalignAutoType();
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
                return efl_text_halign_auto_type_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_text_halign_auto_type_get_delegate efl_text_halign_auto_type_get_static_delegate;

        
        private delegate void efl_text_halign_auto_type_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextFormatHorizontalAlignmentAutoType value);

        
        public delegate void efl_text_halign_auto_type_set_api_delegate(System.IntPtr obj,  Efl.TextFormatHorizontalAlignmentAutoType value);

        public static Efl.Eo.FunctionWrapper<efl_text_halign_auto_type_set_api_delegate> efl_text_halign_auto_type_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_halign_auto_type_set_api_delegate>(Module, "efl_text_halign_auto_type_set");

        private static void halign_auto_type_set(System.IntPtr obj, System.IntPtr pd, Efl.TextFormatHorizontalAlignmentAutoType value)
        {
            Eina.Log.Debug("function efl_text_halign_auto_type_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetHalignAutoType(value);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_halign_auto_type_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), value);
            }
        }

        private static efl_text_halign_auto_type_set_delegate efl_text_halign_auto_type_set_static_delegate;

        
        private delegate double efl_text_halign_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate double efl_text_halign_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_text_halign_get_api_delegate> efl_text_halign_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_halign_get_api_delegate>(Module, "efl_text_halign_get");

        private static double halign_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_text_halign_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            double _ret_var = default(double);
                try
                {
                    _ret_var = ((Text)ws.Target).GetHalign();
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
                return efl_text_halign_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_text_halign_get_delegate efl_text_halign_get_static_delegate;

        
        private delegate void efl_text_halign_set_delegate(System.IntPtr obj, System.IntPtr pd,  double value);

        
        public delegate void efl_text_halign_set_api_delegate(System.IntPtr obj,  double value);

        public static Efl.Eo.FunctionWrapper<efl_text_halign_set_api_delegate> efl_text_halign_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_halign_set_api_delegate>(Module, "efl_text_halign_set");

        private static void halign_set(System.IntPtr obj, System.IntPtr pd, double value)
        {
            Eina.Log.Debug("function efl_text_halign_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetHalign(value);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_halign_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), value);
            }
        }

        private static efl_text_halign_set_delegate efl_text_halign_set_static_delegate;

        
        private delegate double efl_text_valign_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate double efl_text_valign_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_text_valign_get_api_delegate> efl_text_valign_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_valign_get_api_delegate>(Module, "efl_text_valign_get");

        private static double valign_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_text_valign_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            double _ret_var = default(double);
                try
                {
                    _ret_var = ((Text)ws.Target).GetValign();
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
                return efl_text_valign_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_text_valign_get_delegate efl_text_valign_get_static_delegate;

        
        private delegate void efl_text_valign_set_delegate(System.IntPtr obj, System.IntPtr pd,  double value);

        
        public delegate void efl_text_valign_set_api_delegate(System.IntPtr obj,  double value);

        public static Efl.Eo.FunctionWrapper<efl_text_valign_set_api_delegate> efl_text_valign_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_valign_set_api_delegate>(Module, "efl_text_valign_set");

        private static void valign_set(System.IntPtr obj, System.IntPtr pd, double value)
        {
            Eina.Log.Debug("function efl_text_valign_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetValign(value);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_valign_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), value);
            }
        }

        private static efl_text_valign_set_delegate efl_text_valign_set_static_delegate;

        
        private delegate double efl_text_linegap_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate double efl_text_linegap_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_text_linegap_get_api_delegate> efl_text_linegap_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_linegap_get_api_delegate>(Module, "efl_text_linegap_get");

        private static double linegap_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_text_linegap_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            double _ret_var = default(double);
                try
                {
                    _ret_var = ((Text)ws.Target).GetLinegap();
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
                return efl_text_linegap_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_text_linegap_get_delegate efl_text_linegap_get_static_delegate;

        
        private delegate void efl_text_linegap_set_delegate(System.IntPtr obj, System.IntPtr pd,  double value);

        
        public delegate void efl_text_linegap_set_api_delegate(System.IntPtr obj,  double value);

        public static Efl.Eo.FunctionWrapper<efl_text_linegap_set_api_delegate> efl_text_linegap_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_linegap_set_api_delegate>(Module, "efl_text_linegap_set");

        private static void linegap_set(System.IntPtr obj, System.IntPtr pd, double value)
        {
            Eina.Log.Debug("function efl_text_linegap_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetLinegap(value);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_linegap_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), value);
            }
        }

        private static efl_text_linegap_set_delegate efl_text_linegap_set_static_delegate;

        
        private delegate double efl_text_linerelgap_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate double efl_text_linerelgap_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_text_linerelgap_get_api_delegate> efl_text_linerelgap_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_linerelgap_get_api_delegate>(Module, "efl_text_linerelgap_get");

        private static double linerelgap_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_text_linerelgap_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            double _ret_var = default(double);
                try
                {
                    _ret_var = ((Text)ws.Target).GetLinerelgap();
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
                return efl_text_linerelgap_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_text_linerelgap_get_delegate efl_text_linerelgap_get_static_delegate;

        
        private delegate void efl_text_linerelgap_set_delegate(System.IntPtr obj, System.IntPtr pd,  double value);

        
        public delegate void efl_text_linerelgap_set_api_delegate(System.IntPtr obj,  double value);

        public static Efl.Eo.FunctionWrapper<efl_text_linerelgap_set_api_delegate> efl_text_linerelgap_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_linerelgap_set_api_delegate>(Module, "efl_text_linerelgap_set");

        private static void linerelgap_set(System.IntPtr obj, System.IntPtr pd, double value)
        {
            Eina.Log.Debug("function efl_text_linerelgap_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetLinerelgap(value);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_linerelgap_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), value);
            }
        }

        private static efl_text_linerelgap_set_delegate efl_text_linerelgap_set_static_delegate;

        
        private delegate int efl_text_tabstops_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_text_tabstops_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_text_tabstops_get_api_delegate> efl_text_tabstops_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_tabstops_get_api_delegate>(Module, "efl_text_tabstops_get");

        private static int tabstops_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_text_tabstops_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            int _ret_var = default(int);
                try
                {
                    _ret_var = ((Text)ws.Target).GetTabstops();
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
                return efl_text_tabstops_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_text_tabstops_get_delegate efl_text_tabstops_get_static_delegate;

        
        private delegate void efl_text_tabstops_set_delegate(System.IntPtr obj, System.IntPtr pd,  int value);

        
        public delegate void efl_text_tabstops_set_api_delegate(System.IntPtr obj,  int value);

        public static Efl.Eo.FunctionWrapper<efl_text_tabstops_set_api_delegate> efl_text_tabstops_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_tabstops_set_api_delegate>(Module, "efl_text_tabstops_set");

        private static void tabstops_set(System.IntPtr obj, System.IntPtr pd, int value)
        {
            Eina.Log.Debug("function efl_text_tabstops_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetTabstops(value);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_tabstops_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), value);
            }
        }

        private static efl_text_tabstops_set_delegate efl_text_tabstops_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_text_password_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_text_password_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_text_password_get_api_delegate> efl_text_password_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_password_get_api_delegate>(Module, "efl_text_password_get");

        private static bool password_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_text_password_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Text)ws.Target).GetPassword();
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
                return efl_text_password_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_text_password_get_delegate efl_text_password_get_static_delegate;

        
        private delegate void efl_text_password_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool enabled);

        
        public delegate void efl_text_password_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool enabled);

        public static Efl.Eo.FunctionWrapper<efl_text_password_set_api_delegate> efl_text_password_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_password_set_api_delegate>(Module, "efl_text_password_set");

        private static void password_set(System.IntPtr obj, System.IntPtr pd, bool enabled)
        {
            Eina.Log.Debug("function efl_text_password_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetPassword(enabled);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_password_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), enabled);
            }
        }

        private static efl_text_password_set_delegate efl_text_password_set_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_text_replacement_char_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_text_replacement_char_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_text_replacement_char_get_api_delegate> efl_text_replacement_char_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_replacement_char_get_api_delegate>(Module, "efl_text_replacement_char_get");

        private static System.String replacement_char_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_text_replacement_char_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((Text)ws.Target).GetReplacementChar();
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
                return efl_text_replacement_char_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_text_replacement_char_get_delegate efl_text_replacement_char_get_static_delegate;

        
        private delegate void efl_text_replacement_char_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String repch);

        
        public delegate void efl_text_replacement_char_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String repch);

        public static Efl.Eo.FunctionWrapper<efl_text_replacement_char_set_api_delegate> efl_text_replacement_char_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_replacement_char_set_api_delegate>(Module, "efl_text_replacement_char_set");

        private static void replacement_char_set(System.IntPtr obj, System.IntPtr pd, System.String repch)
        {
            Eina.Log.Debug("function efl_text_replacement_char_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetReplacementChar(repch);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_replacement_char_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), repch);
            }
        }

        private static efl_text_replacement_char_set_delegate efl_text_replacement_char_set_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_text_markup_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_text_markup_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_text_markup_get_api_delegate> efl_text_markup_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_markup_get_api_delegate>(Module, "efl_text_markup_get");

        private static System.String markup_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_text_markup_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((Text)ws.Target).GetMarkup();
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
                return efl_text_markup_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_text_markup_get_delegate efl_text_markup_get_static_delegate;

        
        private delegate void efl_text_markup_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String markup);

        
        public delegate void efl_text_markup_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String markup);

        public static Efl.Eo.FunctionWrapper<efl_text_markup_set_api_delegate> efl_text_markup_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_markup_set_api_delegate>(Module, "efl_text_markup_set");

        private static void markup_set(System.IntPtr obj, System.IntPtr pd, System.String markup)
        {
            Eina.Log.Debug("function efl_text_markup_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetMarkup(markup);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_markup_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), markup);
            }
        }

        private static efl_text_markup_set_delegate efl_text_markup_set_static_delegate;

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
                    _ret_var = ((Text)ws.Target).GetMarkupRange(start, end);
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
                    ((Text)ws.Target).SetMarkupRange(start, end, markup);
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
                    ((Text)ws.Target).CursorMarkupInsert(cur, markup);
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

        
        private delegate void efl_text_normal_color_get_delegate(System.IntPtr obj, System.IntPtr pd,  out byte r,  out byte g,  out byte b,  out byte a);

        
        public delegate void efl_text_normal_color_get_api_delegate(System.IntPtr obj,  out byte r,  out byte g,  out byte b,  out byte a);

        public static Efl.Eo.FunctionWrapper<efl_text_normal_color_get_api_delegate> efl_text_normal_color_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_normal_color_get_api_delegate>(Module, "efl_text_normal_color_get");

        private static void normal_color_get(System.IntPtr obj, System.IntPtr pd, out byte r, out byte g, out byte b, out byte a)
        {
            Eina.Log.Debug("function efl_text_normal_color_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                        r = default(byte);        g = default(byte);        b = default(byte);        a = default(byte);                                            
                try
                {
                    ((Text)ws.Target).GetNormalColor(out r, out g, out b, out a);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        
            }
            else
            {
                efl_text_normal_color_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out r, out g, out b, out a);
            }
        }

        private static efl_text_normal_color_get_delegate efl_text_normal_color_get_static_delegate;

        
        private delegate void efl_text_normal_color_set_delegate(System.IntPtr obj, System.IntPtr pd,  byte r,  byte g,  byte b,  byte a);

        
        public delegate void efl_text_normal_color_set_api_delegate(System.IntPtr obj,  byte r,  byte g,  byte b,  byte a);

        public static Efl.Eo.FunctionWrapper<efl_text_normal_color_set_api_delegate> efl_text_normal_color_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_normal_color_set_api_delegate>(Module, "efl_text_normal_color_set");

        private static void normal_color_set(System.IntPtr obj, System.IntPtr pd, byte r, byte g, byte b, byte a)
        {
            Eina.Log.Debug("function efl_text_normal_color_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                                            
                try
                {
                    ((Text)ws.Target).SetNormalColor(r, g, b, a);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        
            }
            else
            {
                efl_text_normal_color_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), r, g, b, a);
            }
        }

        private static efl_text_normal_color_set_delegate efl_text_normal_color_set_static_delegate;

        
        private delegate Efl.TextStyleBackingType efl_text_backing_type_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.TextStyleBackingType efl_text_backing_type_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_text_backing_type_get_api_delegate> efl_text_backing_type_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_backing_type_get_api_delegate>(Module, "efl_text_backing_type_get");

        private static Efl.TextStyleBackingType backing_type_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_text_backing_type_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.TextStyleBackingType _ret_var = default(Efl.TextStyleBackingType);
                try
                {
                    _ret_var = ((Text)ws.Target).GetBackingType();
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
                return efl_text_backing_type_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_text_backing_type_get_delegate efl_text_backing_type_get_static_delegate;

        
        private delegate void efl_text_backing_type_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextStyleBackingType type);

        
        public delegate void efl_text_backing_type_set_api_delegate(System.IntPtr obj,  Efl.TextStyleBackingType type);

        public static Efl.Eo.FunctionWrapper<efl_text_backing_type_set_api_delegate> efl_text_backing_type_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_backing_type_set_api_delegate>(Module, "efl_text_backing_type_set");

        private static void backing_type_set(System.IntPtr obj, System.IntPtr pd, Efl.TextStyleBackingType type)
        {
            Eina.Log.Debug("function efl_text_backing_type_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetBackingType(type);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_backing_type_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), type);
            }
        }

        private static efl_text_backing_type_set_delegate efl_text_backing_type_set_static_delegate;

        
        private delegate void efl_text_backing_color_get_delegate(System.IntPtr obj, System.IntPtr pd,  out byte r,  out byte g,  out byte b,  out byte a);

        
        public delegate void efl_text_backing_color_get_api_delegate(System.IntPtr obj,  out byte r,  out byte g,  out byte b,  out byte a);

        public static Efl.Eo.FunctionWrapper<efl_text_backing_color_get_api_delegate> efl_text_backing_color_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_backing_color_get_api_delegate>(Module, "efl_text_backing_color_get");

        private static void backing_color_get(System.IntPtr obj, System.IntPtr pd, out byte r, out byte g, out byte b, out byte a)
        {
            Eina.Log.Debug("function efl_text_backing_color_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                        r = default(byte);        g = default(byte);        b = default(byte);        a = default(byte);                                            
                try
                {
                    ((Text)ws.Target).GetBackingColor(out r, out g, out b, out a);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        
            }
            else
            {
                efl_text_backing_color_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out r, out g, out b, out a);
            }
        }

        private static efl_text_backing_color_get_delegate efl_text_backing_color_get_static_delegate;

        
        private delegate void efl_text_backing_color_set_delegate(System.IntPtr obj, System.IntPtr pd,  byte r,  byte g,  byte b,  byte a);

        
        public delegate void efl_text_backing_color_set_api_delegate(System.IntPtr obj,  byte r,  byte g,  byte b,  byte a);

        public static Efl.Eo.FunctionWrapper<efl_text_backing_color_set_api_delegate> efl_text_backing_color_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_backing_color_set_api_delegate>(Module, "efl_text_backing_color_set");

        private static void backing_color_set(System.IntPtr obj, System.IntPtr pd, byte r, byte g, byte b, byte a)
        {
            Eina.Log.Debug("function efl_text_backing_color_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                                            
                try
                {
                    ((Text)ws.Target).SetBackingColor(r, g, b, a);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        
            }
            else
            {
                efl_text_backing_color_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), r, g, b, a);
            }
        }

        private static efl_text_backing_color_set_delegate efl_text_backing_color_set_static_delegate;

        
        private delegate Efl.TextStyleUnderlineType efl_text_underline_type_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.TextStyleUnderlineType efl_text_underline_type_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_text_underline_type_get_api_delegate> efl_text_underline_type_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_underline_type_get_api_delegate>(Module, "efl_text_underline_type_get");

        private static Efl.TextStyleUnderlineType underline_type_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_text_underline_type_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.TextStyleUnderlineType _ret_var = default(Efl.TextStyleUnderlineType);
                try
                {
                    _ret_var = ((Text)ws.Target).GetUnderlineType();
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
                return efl_text_underline_type_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_text_underline_type_get_delegate efl_text_underline_type_get_static_delegate;

        
        private delegate void efl_text_underline_type_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextStyleUnderlineType type);

        
        public delegate void efl_text_underline_type_set_api_delegate(System.IntPtr obj,  Efl.TextStyleUnderlineType type);

        public static Efl.Eo.FunctionWrapper<efl_text_underline_type_set_api_delegate> efl_text_underline_type_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_underline_type_set_api_delegate>(Module, "efl_text_underline_type_set");

        private static void underline_type_set(System.IntPtr obj, System.IntPtr pd, Efl.TextStyleUnderlineType type)
        {
            Eina.Log.Debug("function efl_text_underline_type_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetUnderlineType(type);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_underline_type_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), type);
            }
        }

        private static efl_text_underline_type_set_delegate efl_text_underline_type_set_static_delegate;

        
        private delegate void efl_text_underline_color_get_delegate(System.IntPtr obj, System.IntPtr pd,  out byte r,  out byte g,  out byte b,  out byte a);

        
        public delegate void efl_text_underline_color_get_api_delegate(System.IntPtr obj,  out byte r,  out byte g,  out byte b,  out byte a);

        public static Efl.Eo.FunctionWrapper<efl_text_underline_color_get_api_delegate> efl_text_underline_color_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_underline_color_get_api_delegate>(Module, "efl_text_underline_color_get");

        private static void underline_color_get(System.IntPtr obj, System.IntPtr pd, out byte r, out byte g, out byte b, out byte a)
        {
            Eina.Log.Debug("function efl_text_underline_color_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                        r = default(byte);        g = default(byte);        b = default(byte);        a = default(byte);                                            
                try
                {
                    ((Text)ws.Target).GetUnderlineColor(out r, out g, out b, out a);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        
            }
            else
            {
                efl_text_underline_color_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out r, out g, out b, out a);
            }
        }

        private static efl_text_underline_color_get_delegate efl_text_underline_color_get_static_delegate;

        
        private delegate void efl_text_underline_color_set_delegate(System.IntPtr obj, System.IntPtr pd,  byte r,  byte g,  byte b,  byte a);

        
        public delegate void efl_text_underline_color_set_api_delegate(System.IntPtr obj,  byte r,  byte g,  byte b,  byte a);

        public static Efl.Eo.FunctionWrapper<efl_text_underline_color_set_api_delegate> efl_text_underline_color_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_underline_color_set_api_delegate>(Module, "efl_text_underline_color_set");

        private static void underline_color_set(System.IntPtr obj, System.IntPtr pd, byte r, byte g, byte b, byte a)
        {
            Eina.Log.Debug("function efl_text_underline_color_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                                            
                try
                {
                    ((Text)ws.Target).SetUnderlineColor(r, g, b, a);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        
            }
            else
            {
                efl_text_underline_color_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), r, g, b, a);
            }
        }

        private static efl_text_underline_color_set_delegate efl_text_underline_color_set_static_delegate;

        
        private delegate double efl_text_underline_height_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate double efl_text_underline_height_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_text_underline_height_get_api_delegate> efl_text_underline_height_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_underline_height_get_api_delegate>(Module, "efl_text_underline_height_get");

        private static double underline_height_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_text_underline_height_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            double _ret_var = default(double);
                try
                {
                    _ret_var = ((Text)ws.Target).GetUnderlineHeight();
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
                return efl_text_underline_height_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_text_underline_height_get_delegate efl_text_underline_height_get_static_delegate;

        
        private delegate void efl_text_underline_height_set_delegate(System.IntPtr obj, System.IntPtr pd,  double height);

        
        public delegate void efl_text_underline_height_set_api_delegate(System.IntPtr obj,  double height);

        public static Efl.Eo.FunctionWrapper<efl_text_underline_height_set_api_delegate> efl_text_underline_height_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_underline_height_set_api_delegate>(Module, "efl_text_underline_height_set");

        private static void underline_height_set(System.IntPtr obj, System.IntPtr pd, double height)
        {
            Eina.Log.Debug("function efl_text_underline_height_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetUnderlineHeight(height);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_underline_height_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), height);
            }
        }

        private static efl_text_underline_height_set_delegate efl_text_underline_height_set_static_delegate;

        
        private delegate void efl_text_underline_dashed_color_get_delegate(System.IntPtr obj, System.IntPtr pd,  out byte r,  out byte g,  out byte b,  out byte a);

        
        public delegate void efl_text_underline_dashed_color_get_api_delegate(System.IntPtr obj,  out byte r,  out byte g,  out byte b,  out byte a);

        public static Efl.Eo.FunctionWrapper<efl_text_underline_dashed_color_get_api_delegate> efl_text_underline_dashed_color_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_underline_dashed_color_get_api_delegate>(Module, "efl_text_underline_dashed_color_get");

        private static void underline_dashed_color_get(System.IntPtr obj, System.IntPtr pd, out byte r, out byte g, out byte b, out byte a)
        {
            Eina.Log.Debug("function efl_text_underline_dashed_color_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                        r = default(byte);        g = default(byte);        b = default(byte);        a = default(byte);                                            
                try
                {
                    ((Text)ws.Target).GetUnderlineDashedColor(out r, out g, out b, out a);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        
            }
            else
            {
                efl_text_underline_dashed_color_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out r, out g, out b, out a);
            }
        }

        private static efl_text_underline_dashed_color_get_delegate efl_text_underline_dashed_color_get_static_delegate;

        
        private delegate void efl_text_underline_dashed_color_set_delegate(System.IntPtr obj, System.IntPtr pd,  byte r,  byte g,  byte b,  byte a);

        
        public delegate void efl_text_underline_dashed_color_set_api_delegate(System.IntPtr obj,  byte r,  byte g,  byte b,  byte a);

        public static Efl.Eo.FunctionWrapper<efl_text_underline_dashed_color_set_api_delegate> efl_text_underline_dashed_color_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_underline_dashed_color_set_api_delegate>(Module, "efl_text_underline_dashed_color_set");

        private static void underline_dashed_color_set(System.IntPtr obj, System.IntPtr pd, byte r, byte g, byte b, byte a)
        {
            Eina.Log.Debug("function efl_text_underline_dashed_color_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                                            
                try
                {
                    ((Text)ws.Target).SetUnderlineDashedColor(r, g, b, a);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        
            }
            else
            {
                efl_text_underline_dashed_color_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), r, g, b, a);
            }
        }

        private static efl_text_underline_dashed_color_set_delegate efl_text_underline_dashed_color_set_static_delegate;

        
        private delegate int efl_text_underline_dashed_width_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_text_underline_dashed_width_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_text_underline_dashed_width_get_api_delegate> efl_text_underline_dashed_width_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_underline_dashed_width_get_api_delegate>(Module, "efl_text_underline_dashed_width_get");

        private static int underline_dashed_width_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_text_underline_dashed_width_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            int _ret_var = default(int);
                try
                {
                    _ret_var = ((Text)ws.Target).GetUnderlineDashedWidth();
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
                return efl_text_underline_dashed_width_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_text_underline_dashed_width_get_delegate efl_text_underline_dashed_width_get_static_delegate;

        
        private delegate void efl_text_underline_dashed_width_set_delegate(System.IntPtr obj, System.IntPtr pd,  int width);

        
        public delegate void efl_text_underline_dashed_width_set_api_delegate(System.IntPtr obj,  int width);

        public static Efl.Eo.FunctionWrapper<efl_text_underline_dashed_width_set_api_delegate> efl_text_underline_dashed_width_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_underline_dashed_width_set_api_delegate>(Module, "efl_text_underline_dashed_width_set");

        private static void underline_dashed_width_set(System.IntPtr obj, System.IntPtr pd, int width)
        {
            Eina.Log.Debug("function efl_text_underline_dashed_width_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetUnderlineDashedWidth(width);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_underline_dashed_width_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), width);
            }
        }

        private static efl_text_underline_dashed_width_set_delegate efl_text_underline_dashed_width_set_static_delegate;

        
        private delegate int efl_text_underline_dashed_gap_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_text_underline_dashed_gap_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_text_underline_dashed_gap_get_api_delegate> efl_text_underline_dashed_gap_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_underline_dashed_gap_get_api_delegate>(Module, "efl_text_underline_dashed_gap_get");

        private static int underline_dashed_gap_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_text_underline_dashed_gap_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            int _ret_var = default(int);
                try
                {
                    _ret_var = ((Text)ws.Target).GetUnderlineDashedGap();
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
                return efl_text_underline_dashed_gap_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_text_underline_dashed_gap_get_delegate efl_text_underline_dashed_gap_get_static_delegate;

        
        private delegate void efl_text_underline_dashed_gap_set_delegate(System.IntPtr obj, System.IntPtr pd,  int gap);

        
        public delegate void efl_text_underline_dashed_gap_set_api_delegate(System.IntPtr obj,  int gap);

        public static Efl.Eo.FunctionWrapper<efl_text_underline_dashed_gap_set_api_delegate> efl_text_underline_dashed_gap_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_underline_dashed_gap_set_api_delegate>(Module, "efl_text_underline_dashed_gap_set");

        private static void underline_dashed_gap_set(System.IntPtr obj, System.IntPtr pd, int gap)
        {
            Eina.Log.Debug("function efl_text_underline_dashed_gap_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetUnderlineDashedGap(gap);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_underline_dashed_gap_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), gap);
            }
        }

        private static efl_text_underline_dashed_gap_set_delegate efl_text_underline_dashed_gap_set_static_delegate;

        
        private delegate void efl_text_underline2_color_get_delegate(System.IntPtr obj, System.IntPtr pd,  out byte r,  out byte g,  out byte b,  out byte a);

        
        public delegate void efl_text_underline2_color_get_api_delegate(System.IntPtr obj,  out byte r,  out byte g,  out byte b,  out byte a);

        public static Efl.Eo.FunctionWrapper<efl_text_underline2_color_get_api_delegate> efl_text_underline2_color_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_underline2_color_get_api_delegate>(Module, "efl_text_underline2_color_get");

        private static void underline2_color_get(System.IntPtr obj, System.IntPtr pd, out byte r, out byte g, out byte b, out byte a)
        {
            Eina.Log.Debug("function efl_text_underline2_color_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                        r = default(byte);        g = default(byte);        b = default(byte);        a = default(byte);                                            
                try
                {
                    ((Text)ws.Target).GetUnderline2Color(out r, out g, out b, out a);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        
            }
            else
            {
                efl_text_underline2_color_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out r, out g, out b, out a);
            }
        }

        private static efl_text_underline2_color_get_delegate efl_text_underline2_color_get_static_delegate;

        
        private delegate void efl_text_underline2_color_set_delegate(System.IntPtr obj, System.IntPtr pd,  byte r,  byte g,  byte b,  byte a);

        
        public delegate void efl_text_underline2_color_set_api_delegate(System.IntPtr obj,  byte r,  byte g,  byte b,  byte a);

        public static Efl.Eo.FunctionWrapper<efl_text_underline2_color_set_api_delegate> efl_text_underline2_color_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_underline2_color_set_api_delegate>(Module, "efl_text_underline2_color_set");

        private static void underline2_color_set(System.IntPtr obj, System.IntPtr pd, byte r, byte g, byte b, byte a)
        {
            Eina.Log.Debug("function efl_text_underline2_color_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                                            
                try
                {
                    ((Text)ws.Target).SetUnderline2Color(r, g, b, a);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        
            }
            else
            {
                efl_text_underline2_color_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), r, g, b, a);
            }
        }

        private static efl_text_underline2_color_set_delegate efl_text_underline2_color_set_static_delegate;

        
        private delegate Efl.TextStyleStrikethroughType efl_text_strikethrough_type_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.TextStyleStrikethroughType efl_text_strikethrough_type_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_text_strikethrough_type_get_api_delegate> efl_text_strikethrough_type_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_strikethrough_type_get_api_delegate>(Module, "efl_text_strikethrough_type_get");

        private static Efl.TextStyleStrikethroughType strikethrough_type_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_text_strikethrough_type_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.TextStyleStrikethroughType _ret_var = default(Efl.TextStyleStrikethroughType);
                try
                {
                    _ret_var = ((Text)ws.Target).GetStrikethroughType();
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
                return efl_text_strikethrough_type_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_text_strikethrough_type_get_delegate efl_text_strikethrough_type_get_static_delegate;

        
        private delegate void efl_text_strikethrough_type_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextStyleStrikethroughType type);

        
        public delegate void efl_text_strikethrough_type_set_api_delegate(System.IntPtr obj,  Efl.TextStyleStrikethroughType type);

        public static Efl.Eo.FunctionWrapper<efl_text_strikethrough_type_set_api_delegate> efl_text_strikethrough_type_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_strikethrough_type_set_api_delegate>(Module, "efl_text_strikethrough_type_set");

        private static void strikethrough_type_set(System.IntPtr obj, System.IntPtr pd, Efl.TextStyleStrikethroughType type)
        {
            Eina.Log.Debug("function efl_text_strikethrough_type_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetStrikethroughType(type);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_strikethrough_type_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), type);
            }
        }

        private static efl_text_strikethrough_type_set_delegate efl_text_strikethrough_type_set_static_delegate;

        
        private delegate void efl_text_strikethrough_color_get_delegate(System.IntPtr obj, System.IntPtr pd,  out byte r,  out byte g,  out byte b,  out byte a);

        
        public delegate void efl_text_strikethrough_color_get_api_delegate(System.IntPtr obj,  out byte r,  out byte g,  out byte b,  out byte a);

        public static Efl.Eo.FunctionWrapper<efl_text_strikethrough_color_get_api_delegate> efl_text_strikethrough_color_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_strikethrough_color_get_api_delegate>(Module, "efl_text_strikethrough_color_get");

        private static void strikethrough_color_get(System.IntPtr obj, System.IntPtr pd, out byte r, out byte g, out byte b, out byte a)
        {
            Eina.Log.Debug("function efl_text_strikethrough_color_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                        r = default(byte);        g = default(byte);        b = default(byte);        a = default(byte);                                            
                try
                {
                    ((Text)ws.Target).GetStrikethroughColor(out r, out g, out b, out a);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        
            }
            else
            {
                efl_text_strikethrough_color_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out r, out g, out b, out a);
            }
        }

        private static efl_text_strikethrough_color_get_delegate efl_text_strikethrough_color_get_static_delegate;

        
        private delegate void efl_text_strikethrough_color_set_delegate(System.IntPtr obj, System.IntPtr pd,  byte r,  byte g,  byte b,  byte a);

        
        public delegate void efl_text_strikethrough_color_set_api_delegate(System.IntPtr obj,  byte r,  byte g,  byte b,  byte a);

        public static Efl.Eo.FunctionWrapper<efl_text_strikethrough_color_set_api_delegate> efl_text_strikethrough_color_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_strikethrough_color_set_api_delegate>(Module, "efl_text_strikethrough_color_set");

        private static void strikethrough_color_set(System.IntPtr obj, System.IntPtr pd, byte r, byte g, byte b, byte a)
        {
            Eina.Log.Debug("function efl_text_strikethrough_color_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                                            
                try
                {
                    ((Text)ws.Target).SetStrikethroughColor(r, g, b, a);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        
            }
            else
            {
                efl_text_strikethrough_color_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), r, g, b, a);
            }
        }

        private static efl_text_strikethrough_color_set_delegate efl_text_strikethrough_color_set_static_delegate;

        
        private delegate Efl.TextStyleEffectType efl_text_effect_type_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.TextStyleEffectType efl_text_effect_type_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_text_effect_type_get_api_delegate> efl_text_effect_type_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_effect_type_get_api_delegate>(Module, "efl_text_effect_type_get");

        private static Efl.TextStyleEffectType effect_type_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_text_effect_type_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.TextStyleEffectType _ret_var = default(Efl.TextStyleEffectType);
                try
                {
                    _ret_var = ((Text)ws.Target).GetEffectType();
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
                return efl_text_effect_type_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_text_effect_type_get_delegate efl_text_effect_type_get_static_delegate;

        
        private delegate void efl_text_effect_type_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextStyleEffectType type);

        
        public delegate void efl_text_effect_type_set_api_delegate(System.IntPtr obj,  Efl.TextStyleEffectType type);

        public static Efl.Eo.FunctionWrapper<efl_text_effect_type_set_api_delegate> efl_text_effect_type_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_effect_type_set_api_delegate>(Module, "efl_text_effect_type_set");

        private static void effect_type_set(System.IntPtr obj, System.IntPtr pd, Efl.TextStyleEffectType type)
        {
            Eina.Log.Debug("function efl_text_effect_type_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetEffectType(type);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_effect_type_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), type);
            }
        }

        private static efl_text_effect_type_set_delegate efl_text_effect_type_set_static_delegate;

        
        private delegate void efl_text_outline_color_get_delegate(System.IntPtr obj, System.IntPtr pd,  out byte r,  out byte g,  out byte b,  out byte a);

        
        public delegate void efl_text_outline_color_get_api_delegate(System.IntPtr obj,  out byte r,  out byte g,  out byte b,  out byte a);

        public static Efl.Eo.FunctionWrapper<efl_text_outline_color_get_api_delegate> efl_text_outline_color_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_outline_color_get_api_delegate>(Module, "efl_text_outline_color_get");

        private static void outline_color_get(System.IntPtr obj, System.IntPtr pd, out byte r, out byte g, out byte b, out byte a)
        {
            Eina.Log.Debug("function efl_text_outline_color_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                        r = default(byte);        g = default(byte);        b = default(byte);        a = default(byte);                                            
                try
                {
                    ((Text)ws.Target).GetOutlineColor(out r, out g, out b, out a);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        
            }
            else
            {
                efl_text_outline_color_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out r, out g, out b, out a);
            }
        }

        private static efl_text_outline_color_get_delegate efl_text_outline_color_get_static_delegate;

        
        private delegate void efl_text_outline_color_set_delegate(System.IntPtr obj, System.IntPtr pd,  byte r,  byte g,  byte b,  byte a);

        
        public delegate void efl_text_outline_color_set_api_delegate(System.IntPtr obj,  byte r,  byte g,  byte b,  byte a);

        public static Efl.Eo.FunctionWrapper<efl_text_outline_color_set_api_delegate> efl_text_outline_color_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_outline_color_set_api_delegate>(Module, "efl_text_outline_color_set");

        private static void outline_color_set(System.IntPtr obj, System.IntPtr pd, byte r, byte g, byte b, byte a)
        {
            Eina.Log.Debug("function efl_text_outline_color_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                                            
                try
                {
                    ((Text)ws.Target).SetOutlineColor(r, g, b, a);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        
            }
            else
            {
                efl_text_outline_color_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), r, g, b, a);
            }
        }

        private static efl_text_outline_color_set_delegate efl_text_outline_color_set_static_delegate;

        
        private delegate Efl.TextStyleShadowDirection efl_text_shadow_direction_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.TextStyleShadowDirection efl_text_shadow_direction_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_text_shadow_direction_get_api_delegate> efl_text_shadow_direction_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_shadow_direction_get_api_delegate>(Module, "efl_text_shadow_direction_get");

        private static Efl.TextStyleShadowDirection shadow_direction_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_text_shadow_direction_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.TextStyleShadowDirection _ret_var = default(Efl.TextStyleShadowDirection);
                try
                {
                    _ret_var = ((Text)ws.Target).GetShadowDirection();
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
                return efl_text_shadow_direction_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_text_shadow_direction_get_delegate efl_text_shadow_direction_get_static_delegate;

        
        private delegate void efl_text_shadow_direction_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextStyleShadowDirection type);

        
        public delegate void efl_text_shadow_direction_set_api_delegate(System.IntPtr obj,  Efl.TextStyleShadowDirection type);

        public static Efl.Eo.FunctionWrapper<efl_text_shadow_direction_set_api_delegate> efl_text_shadow_direction_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_shadow_direction_set_api_delegate>(Module, "efl_text_shadow_direction_set");

        private static void shadow_direction_set(System.IntPtr obj, System.IntPtr pd, Efl.TextStyleShadowDirection type)
        {
            Eina.Log.Debug("function efl_text_shadow_direction_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetShadowDirection(type);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_shadow_direction_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), type);
            }
        }

        private static efl_text_shadow_direction_set_delegate efl_text_shadow_direction_set_static_delegate;

        
        private delegate void efl_text_shadow_color_get_delegate(System.IntPtr obj, System.IntPtr pd,  out byte r,  out byte g,  out byte b,  out byte a);

        
        public delegate void efl_text_shadow_color_get_api_delegate(System.IntPtr obj,  out byte r,  out byte g,  out byte b,  out byte a);

        public static Efl.Eo.FunctionWrapper<efl_text_shadow_color_get_api_delegate> efl_text_shadow_color_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_shadow_color_get_api_delegate>(Module, "efl_text_shadow_color_get");

        private static void shadow_color_get(System.IntPtr obj, System.IntPtr pd, out byte r, out byte g, out byte b, out byte a)
        {
            Eina.Log.Debug("function efl_text_shadow_color_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                        r = default(byte);        g = default(byte);        b = default(byte);        a = default(byte);                                            
                try
                {
                    ((Text)ws.Target).GetShadowColor(out r, out g, out b, out a);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        
            }
            else
            {
                efl_text_shadow_color_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out r, out g, out b, out a);
            }
        }

        private static efl_text_shadow_color_get_delegate efl_text_shadow_color_get_static_delegate;

        
        private delegate void efl_text_shadow_color_set_delegate(System.IntPtr obj, System.IntPtr pd,  byte r,  byte g,  byte b,  byte a);

        
        public delegate void efl_text_shadow_color_set_api_delegate(System.IntPtr obj,  byte r,  byte g,  byte b,  byte a);

        public static Efl.Eo.FunctionWrapper<efl_text_shadow_color_set_api_delegate> efl_text_shadow_color_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_shadow_color_set_api_delegate>(Module, "efl_text_shadow_color_set");

        private static void shadow_color_set(System.IntPtr obj, System.IntPtr pd, byte r, byte g, byte b, byte a)
        {
            Eina.Log.Debug("function efl_text_shadow_color_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                                            
                try
                {
                    ((Text)ws.Target).SetShadowColor(r, g, b, a);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        
            }
            else
            {
                efl_text_shadow_color_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), r, g, b, a);
            }
        }

        private static efl_text_shadow_color_set_delegate efl_text_shadow_color_set_static_delegate;

        
        private delegate void efl_text_glow_color_get_delegate(System.IntPtr obj, System.IntPtr pd,  out byte r,  out byte g,  out byte b,  out byte a);

        
        public delegate void efl_text_glow_color_get_api_delegate(System.IntPtr obj,  out byte r,  out byte g,  out byte b,  out byte a);

        public static Efl.Eo.FunctionWrapper<efl_text_glow_color_get_api_delegate> efl_text_glow_color_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_glow_color_get_api_delegate>(Module, "efl_text_glow_color_get");

        private static void glow_color_get(System.IntPtr obj, System.IntPtr pd, out byte r, out byte g, out byte b, out byte a)
        {
            Eina.Log.Debug("function efl_text_glow_color_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                        r = default(byte);        g = default(byte);        b = default(byte);        a = default(byte);                                            
                try
                {
                    ((Text)ws.Target).GetGlowColor(out r, out g, out b, out a);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        
            }
            else
            {
                efl_text_glow_color_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out r, out g, out b, out a);
            }
        }

        private static efl_text_glow_color_get_delegate efl_text_glow_color_get_static_delegate;

        
        private delegate void efl_text_glow_color_set_delegate(System.IntPtr obj, System.IntPtr pd,  byte r,  byte g,  byte b,  byte a);

        
        public delegate void efl_text_glow_color_set_api_delegate(System.IntPtr obj,  byte r,  byte g,  byte b,  byte a);

        public static Efl.Eo.FunctionWrapper<efl_text_glow_color_set_api_delegate> efl_text_glow_color_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_glow_color_set_api_delegate>(Module, "efl_text_glow_color_set");

        private static void glow_color_set(System.IntPtr obj, System.IntPtr pd, byte r, byte g, byte b, byte a)
        {
            Eina.Log.Debug("function efl_text_glow_color_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                                            
                try
                {
                    ((Text)ws.Target).SetGlowColor(r, g, b, a);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        
            }
            else
            {
                efl_text_glow_color_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), r, g, b, a);
            }
        }

        private static efl_text_glow_color_set_delegate efl_text_glow_color_set_static_delegate;

        
        private delegate void efl_text_glow2_color_get_delegate(System.IntPtr obj, System.IntPtr pd,  out byte r,  out byte g,  out byte b,  out byte a);

        
        public delegate void efl_text_glow2_color_get_api_delegate(System.IntPtr obj,  out byte r,  out byte g,  out byte b,  out byte a);

        public static Efl.Eo.FunctionWrapper<efl_text_glow2_color_get_api_delegate> efl_text_glow2_color_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_glow2_color_get_api_delegate>(Module, "efl_text_glow2_color_get");

        private static void glow2_color_get(System.IntPtr obj, System.IntPtr pd, out byte r, out byte g, out byte b, out byte a)
        {
            Eina.Log.Debug("function efl_text_glow2_color_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                        r = default(byte);        g = default(byte);        b = default(byte);        a = default(byte);                                            
                try
                {
                    ((Text)ws.Target).GetGlow2Color(out r, out g, out b, out a);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        
            }
            else
            {
                efl_text_glow2_color_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out r, out g, out b, out a);
            }
        }

        private static efl_text_glow2_color_get_delegate efl_text_glow2_color_get_static_delegate;

        
        private delegate void efl_text_glow2_color_set_delegate(System.IntPtr obj, System.IntPtr pd,  byte r,  byte g,  byte b,  byte a);

        
        public delegate void efl_text_glow2_color_set_api_delegate(System.IntPtr obj,  byte r,  byte g,  byte b,  byte a);

        public static Efl.Eo.FunctionWrapper<efl_text_glow2_color_set_api_delegate> efl_text_glow2_color_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_glow2_color_set_api_delegate>(Module, "efl_text_glow2_color_set");

        private static void glow2_color_set(System.IntPtr obj, System.IntPtr pd, byte r, byte g, byte b, byte a)
        {
            Eina.Log.Debug("function efl_text_glow2_color_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                                            
                try
                {
                    ((Text)ws.Target).SetGlow2Color(r, g, b, a);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        
            }
            else
            {
                efl_text_glow2_color_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), r, g, b, a);
            }
        }

        private static efl_text_glow2_color_set_delegate efl_text_glow2_color_set_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_text_gfx_filter_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_text_gfx_filter_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_text_gfx_filter_get_api_delegate> efl_text_gfx_filter_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_gfx_filter_get_api_delegate>(Module, "efl_text_gfx_filter_get");

        private static System.String gfx_filter_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_text_gfx_filter_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((Text)ws.Target).GetGfxFilter();
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
                return efl_text_gfx_filter_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_text_gfx_filter_get_delegate efl_text_gfx_filter_get_static_delegate;

        
        private delegate void efl_text_gfx_filter_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String code);

        
        public delegate void efl_text_gfx_filter_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String code);

        public static Efl.Eo.FunctionWrapper<efl_text_gfx_filter_set_api_delegate> efl_text_gfx_filter_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_gfx_filter_set_api_delegate>(Module, "efl_text_gfx_filter_set");

        private static void gfx_filter_set(System.IntPtr obj, System.IntPtr pd, System.String code)
        {
            Eina.Log.Debug("function efl_text_gfx_filter_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetGfxFilter(code);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_gfx_filter_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), code);
            }
        }

        private static efl_text_gfx_filter_set_delegate efl_text_gfx_filter_set_static_delegate;

        
        private delegate void evas_filter_changed_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool val);

        
        public delegate void evas_filter_changed_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool val);

        public static Efl.Eo.FunctionWrapper<evas_filter_changed_set_api_delegate> evas_filter_changed_set_ptr = new Efl.Eo.FunctionWrapper<evas_filter_changed_set_api_delegate>(Module, "evas_filter_changed_set");

        private static void filter_changed_set(System.IntPtr obj, System.IntPtr pd, bool val)
        {
            Eina.Log.Debug("function evas_filter_changed_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetFilterChanged(val);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                evas_filter_changed_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), val);
            }
        }

        private static evas_filter_changed_set_delegate evas_filter_changed_set_static_delegate;

        
        private delegate void evas_filter_invalid_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool val);

        
        public delegate void evas_filter_invalid_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool val);

        public static Efl.Eo.FunctionWrapper<evas_filter_invalid_set_api_delegate> evas_filter_invalid_set_ptr = new Efl.Eo.FunctionWrapper<evas_filter_invalid_set_api_delegate>(Module, "evas_filter_invalid_set");

        private static void filter_invalid_set(System.IntPtr obj, System.IntPtr pd, bool val)
        {
            Eina.Log.Debug("function evas_filter_invalid_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetFilterInvalid(val);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                evas_filter_invalid_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), val);
            }
        }

        private static evas_filter_invalid_set_delegate evas_filter_invalid_set_static_delegate;

        
        private delegate System.IntPtr evas_filter_output_buffer_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate System.IntPtr evas_filter_output_buffer_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<evas_filter_output_buffer_get_api_delegate> evas_filter_output_buffer_get_ptr = new Efl.Eo.FunctionWrapper<evas_filter_output_buffer_get_api_delegate>(Module, "evas_filter_output_buffer_get");

        private static System.IntPtr filter_output_buffer_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function evas_filter_output_buffer_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            System.IntPtr _ret_var = default(System.IntPtr);
                try
                {
                    _ret_var = ((Text)ws.Target).GetFilterOutputBuffer();
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
                return evas_filter_output_buffer_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static evas_filter_output_buffer_get_delegate evas_filter_output_buffer_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool evas_filter_input_alpha_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool evas_filter_input_alpha_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<evas_filter_input_alpha_api_delegate> evas_filter_input_alpha_ptr = new Efl.Eo.FunctionWrapper<evas_filter_input_alpha_api_delegate>(Module, "evas_filter_input_alpha");

        private static bool filter_input_alpha(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function evas_filter_input_alpha was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Text)ws.Target).FilterInputAlpha();
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
                return evas_filter_input_alpha_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static evas_filter_input_alpha_delegate evas_filter_input_alpha_static_delegate;

        
        private delegate void evas_filter_state_prepare_delegate(System.IntPtr obj, System.IntPtr pd,  out Efl.Canvas.Filter.State.NativeStruct state,  System.IntPtr data);

        
        public delegate void evas_filter_state_prepare_api_delegate(System.IntPtr obj,  out Efl.Canvas.Filter.State.NativeStruct state,  System.IntPtr data);

        public static Efl.Eo.FunctionWrapper<evas_filter_state_prepare_api_delegate> evas_filter_state_prepare_ptr = new Efl.Eo.FunctionWrapper<evas_filter_state_prepare_api_delegate>(Module, "evas_filter_state_prepare");

        private static void filter_state_prepare(System.IntPtr obj, System.IntPtr pd, out Efl.Canvas.Filter.State.NativeStruct state, System.IntPtr data)
        {
            Eina.Log.Debug("function evas_filter_state_prepare was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                        Efl.Canvas.Filter.State _out_state = default(Efl.Canvas.Filter.State);
                                    
                try
                {
                    ((Text)ws.Target).FilterStatePrepare(out _out_state, data);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        state = _out_state;
                                
            }
            else
            {
                evas_filter_state_prepare_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out state, data);
            }
        }

        private static evas_filter_state_prepare_delegate evas_filter_state_prepare_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool evas_filter_input_render_delegate(System.IntPtr obj, System.IntPtr pd,  System.IntPtr filter,  System.IntPtr engine,  System.IntPtr output,  System.IntPtr drawctx,  System.IntPtr data,  int l,  int r,  int t,  int b,  int x,  int y, [MarshalAs(UnmanagedType.U1)] bool do_async);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool evas_filter_input_render_api_delegate(System.IntPtr obj,  System.IntPtr filter,  System.IntPtr engine,  System.IntPtr output,  System.IntPtr drawctx,  System.IntPtr data,  int l,  int r,  int t,  int b,  int x,  int y, [MarshalAs(UnmanagedType.U1)] bool do_async);

        public static Efl.Eo.FunctionWrapper<evas_filter_input_render_api_delegate> evas_filter_input_render_ptr = new Efl.Eo.FunctionWrapper<evas_filter_input_render_api_delegate>(Module, "evas_filter_input_render");

        private static bool filter_input_render(System.IntPtr obj, System.IntPtr pd, System.IntPtr filter, System.IntPtr engine, System.IntPtr output, System.IntPtr drawctx, System.IntPtr data, int l, int r, int t, int b, int x, int y, bool do_async)
        {
            Eina.Log.Debug("function evas_filter_input_render was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                                                                                                                                                                                                                                            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Text)ws.Target).FilterInputRender(filter, engine, output, drawctx, data, l, r, t, b, x, y, do_async);
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
                return evas_filter_input_render_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), filter, engine, output, drawctx, data, l, r, t, b, x, y, do_async);
            }
        }

        private static evas_filter_input_render_delegate evas_filter_input_render_static_delegate;

        
        private delegate void evas_filter_dirty_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void evas_filter_dirty_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<evas_filter_dirty_api_delegate> evas_filter_dirty_ptr = new Efl.Eo.FunctionWrapper<evas_filter_dirty_api_delegate>(Module, "evas_filter_dirty");

        private static void filter_dirty(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function evas_filter_dirty was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((Text)ws.Target).FilterDirty();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                evas_filter_dirty_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static evas_filter_dirty_delegate evas_filter_dirty_static_delegate;

        
        private delegate void efl_gfx_filter_program_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] out System.String code, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] out System.String name);

        
        public delegate void efl_gfx_filter_program_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] out System.String code, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] out System.String name);

        public static Efl.Eo.FunctionWrapper<efl_gfx_filter_program_get_api_delegate> efl_gfx_filter_program_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_filter_program_get_api_delegate>(Module, "efl_gfx_filter_program_get");

        private static void filter_program_get(System.IntPtr obj, System.IntPtr pd, out System.String code, out System.String name)
        {
            Eina.Log.Debug("function efl_gfx_filter_program_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                        System.String _out_code = default(System.String);
        System.String _out_name = default(System.String);
                            
                try
                {
                    ((Text)ws.Target).GetFilterProgram(out _out_code, out _out_name);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        code = _out_code;
        name = _out_name;
                        
            }
            else
            {
                efl_gfx_filter_program_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out code, out name);
            }
        }

        private static efl_gfx_filter_program_get_delegate efl_gfx_filter_program_get_static_delegate;

        
        private delegate void efl_gfx_filter_program_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String code, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String name);

        
        public delegate void efl_gfx_filter_program_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String code, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String name);

        public static Efl.Eo.FunctionWrapper<efl_gfx_filter_program_set_api_delegate> efl_gfx_filter_program_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_filter_program_set_api_delegate>(Module, "efl_gfx_filter_program_set");

        private static void filter_program_set(System.IntPtr obj, System.IntPtr pd, System.String code, System.String name)
        {
            Eina.Log.Debug("function efl_gfx_filter_program_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((Text)ws.Target).SetFilterProgram(code, name);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_gfx_filter_program_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), code, name);
            }
        }

        private static efl_gfx_filter_program_set_delegate efl_gfx_filter_program_set_static_delegate;

        
        private delegate void efl_gfx_filter_state_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] out System.String cur_state,  out double cur_val, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] out System.String next_state,  out double next_val,  out double pos);

        
        public delegate void efl_gfx_filter_state_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] out System.String cur_state,  out double cur_val, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] out System.String next_state,  out double next_val,  out double pos);

        public static Efl.Eo.FunctionWrapper<efl_gfx_filter_state_get_api_delegate> efl_gfx_filter_state_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_filter_state_get_api_delegate>(Module, "efl_gfx_filter_state_get");

        private static void filter_state_get(System.IntPtr obj, System.IntPtr pd, out System.String cur_state, out double cur_val, out System.String next_state, out double next_val, out double pos)
        {
            Eina.Log.Debug("function efl_gfx_filter_state_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                System.String _out_cur_state = default(System.String);
        cur_val = default(double);        System.String _out_next_state = default(System.String);
        next_val = default(double);        pos = default(double);                                                    
                try
                {
                    ((Text)ws.Target).GetFilterState(out _out_cur_state, out cur_val, out _out_next_state, out next_val, out pos);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        cur_state = _out_cur_state;
                next_state = _out_next_state;
                                                                
            }
            else
            {
                efl_gfx_filter_state_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out cur_state, out cur_val, out next_state, out next_val, out pos);
            }
        }

        private static efl_gfx_filter_state_get_delegate efl_gfx_filter_state_get_static_delegate;

        
        private delegate void efl_gfx_filter_state_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String cur_state,  double cur_val, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String next_state,  double next_val,  double pos);

        
        public delegate void efl_gfx_filter_state_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String cur_state,  double cur_val, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String next_state,  double next_val,  double pos);

        public static Efl.Eo.FunctionWrapper<efl_gfx_filter_state_set_api_delegate> efl_gfx_filter_state_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_filter_state_set_api_delegate>(Module, "efl_gfx_filter_state_set");

        private static void filter_state_set(System.IntPtr obj, System.IntPtr pd, System.String cur_state, double cur_val, System.String next_state, double next_val, double pos)
        {
            Eina.Log.Debug("function efl_gfx_filter_state_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                                                                    
                try
                {
                    ((Text)ws.Target).SetFilterState(cur_state, cur_val, next_state, next_val, pos);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                                        
            }
            else
            {
                efl_gfx_filter_state_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), cur_state, cur_val, next_state, next_val, pos);
            }
        }

        private static efl_gfx_filter_state_set_delegate efl_gfx_filter_state_set_static_delegate;

        
        private delegate void efl_gfx_filter_padding_get_delegate(System.IntPtr obj, System.IntPtr pd,  out int l,  out int r,  out int t,  out int b);

        
        public delegate void efl_gfx_filter_padding_get_api_delegate(System.IntPtr obj,  out int l,  out int r,  out int t,  out int b);

        public static Efl.Eo.FunctionWrapper<efl_gfx_filter_padding_get_api_delegate> efl_gfx_filter_padding_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_filter_padding_get_api_delegate>(Module, "efl_gfx_filter_padding_get");

        private static void filter_padding_get(System.IntPtr obj, System.IntPtr pd, out int l, out int r, out int t, out int b)
        {
            Eina.Log.Debug("function efl_gfx_filter_padding_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                        l = default(int);        r = default(int);        t = default(int);        b = default(int);                                            
                try
                {
                    ((Text)ws.Target).GetFilterPadding(out l, out r, out t, out b);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        
            }
            else
            {
                efl_gfx_filter_padding_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out l, out r, out t, out b);
            }
        }

        private static efl_gfx_filter_padding_get_delegate efl_gfx_filter_padding_get_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Gfx.IEntity efl_gfx_filter_source_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String name);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Gfx.IEntity efl_gfx_filter_source_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String name);

        public static Efl.Eo.FunctionWrapper<efl_gfx_filter_source_get_api_delegate> efl_gfx_filter_source_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_filter_source_get_api_delegate>(Module, "efl_gfx_filter_source_get");

        private static Efl.Gfx.IEntity filter_source_get(System.IntPtr obj, System.IntPtr pd, System.String name)
        {
            Eina.Log.Debug("function efl_gfx_filter_source_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    Efl.Gfx.IEntity _ret_var = default(Efl.Gfx.IEntity);
                try
                {
                    _ret_var = ((Text)ws.Target).GetFilterSource(name);
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
                return efl_gfx_filter_source_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), name);
            }
        }

        private static efl_gfx_filter_source_get_delegate efl_gfx_filter_source_get_static_delegate;

        
        private delegate void efl_gfx_filter_source_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String name, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity source);

        
        public delegate void efl_gfx_filter_source_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String name, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity source);

        public static Efl.Eo.FunctionWrapper<efl_gfx_filter_source_set_api_delegate> efl_gfx_filter_source_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_filter_source_set_api_delegate>(Module, "efl_gfx_filter_source_set");

        private static void filter_source_set(System.IntPtr obj, System.IntPtr pd, System.String name, Efl.Gfx.IEntity source)
        {
            Eina.Log.Debug("function efl_gfx_filter_source_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((Text)ws.Target).SetFilterSource(name, source);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_gfx_filter_source_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), name, source);
            }
        }

        private static efl_gfx_filter_source_set_delegate efl_gfx_filter_source_set_static_delegate;

        
        private delegate void efl_gfx_filter_data_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String name, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] out System.String value, [MarshalAs(UnmanagedType.U1)] out bool execute);

        
        public delegate void efl_gfx_filter_data_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String name, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] out System.String value, [MarshalAs(UnmanagedType.U1)] out bool execute);

        public static Efl.Eo.FunctionWrapper<efl_gfx_filter_data_get_api_delegate> efl_gfx_filter_data_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_filter_data_get_api_delegate>(Module, "efl_gfx_filter_data_get");

        private static void filter_data_get(System.IntPtr obj, System.IntPtr pd, System.String name, out System.String value, out bool execute)
        {
            Eina.Log.Debug("function efl_gfx_filter_data_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                        System.String _out_value = default(System.String);
        execute = default(bool);                                    
                try
                {
                    ((Text)ws.Target).GetFilterData(name, out _out_value, out execute);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                value = _out_value;
                                        
            }
            else
            {
                efl_gfx_filter_data_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), name, out value, out execute);
            }
        }

        private static efl_gfx_filter_data_get_delegate efl_gfx_filter_data_get_static_delegate;

        
        private delegate void efl_gfx_filter_data_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String name, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String value, [MarshalAs(UnmanagedType.U1)] bool execute);

        
        public delegate void efl_gfx_filter_data_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String name, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String value, [MarshalAs(UnmanagedType.U1)] bool execute);

        public static Efl.Eo.FunctionWrapper<efl_gfx_filter_data_set_api_delegate> efl_gfx_filter_data_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_filter_data_set_api_delegate>(Module, "efl_gfx_filter_data_set");

        private static void filter_data_set(System.IntPtr obj, System.IntPtr pd, System.String name, System.String value, bool execute)
        {
            Eina.Log.Debug("function efl_gfx_filter_data_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                    
                try
                {
                    ((Text)ws.Target).SetFilterData(name, value, execute);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                        
            }
            else
            {
                efl_gfx_filter_data_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), name, value, execute);
            }
        }

        private static efl_gfx_filter_data_set_delegate efl_gfx_filter_data_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_mirrored_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_mirrored_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_mirrored_get_api_delegate> efl_ui_mirrored_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_mirrored_get_api_delegate>(Module, "efl_ui_mirrored_get");

        private static bool mirrored_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_mirrored_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Text)ws.Target).GetMirrored();
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
                return efl_ui_mirrored_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_mirrored_get_delegate efl_ui_mirrored_get_static_delegate;

        
        private delegate void efl_ui_mirrored_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool rtl);

        
        public delegate void efl_ui_mirrored_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool rtl);

        public static Efl.Eo.FunctionWrapper<efl_ui_mirrored_set_api_delegate> efl_ui_mirrored_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_mirrored_set_api_delegate>(Module, "efl_ui_mirrored_set");

        private static void mirrored_set(System.IntPtr obj, System.IntPtr pd, bool rtl)
        {
            Eina.Log.Debug("function efl_ui_mirrored_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetMirrored(rtl);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_mirrored_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), rtl);
            }
        }

        private static efl_ui_mirrored_set_delegate efl_ui_mirrored_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_mirrored_automatic_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_mirrored_automatic_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_mirrored_automatic_get_api_delegate> efl_ui_mirrored_automatic_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_mirrored_automatic_get_api_delegate>(Module, "efl_ui_mirrored_automatic_get");

        private static bool mirrored_automatic_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_mirrored_automatic_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Text)ws.Target).GetMirroredAutomatic();
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
                return efl_ui_mirrored_automatic_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_mirrored_automatic_get_delegate efl_ui_mirrored_automatic_get_static_delegate;

        
        private delegate void efl_ui_mirrored_automatic_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool automatic);

        
        public delegate void efl_ui_mirrored_automatic_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool automatic);

        public static Efl.Eo.FunctionWrapper<efl_ui_mirrored_automatic_set_api_delegate> efl_ui_mirrored_automatic_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_mirrored_automatic_set_api_delegate>(Module, "efl_ui_mirrored_automatic_set");

        private static void mirrored_automatic_set(System.IntPtr obj, System.IntPtr pd, bool automatic)
        {
            Eina.Log.Debug("function efl_ui_mirrored_automatic_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetMirroredAutomatic(automatic);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_mirrored_automatic_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), automatic);
            }
        }

        private static efl_ui_mirrored_automatic_set_delegate efl_ui_mirrored_automatic_set_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_ui_language_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_ui_language_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_language_get_api_delegate> efl_ui_language_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_language_get_api_delegate>(Module, "efl_ui_language_get");

        private static System.String language_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_language_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((Text)ws.Target).GetLanguage();
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
                return efl_ui_language_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_language_get_delegate efl_ui_language_get_static_delegate;

        
        private delegate void efl_ui_language_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String language);

        
        public delegate void efl_ui_language_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String language);

        public static Efl.Eo.FunctionWrapper<efl_ui_language_set_api_delegate> efl_ui_language_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_language_set_api_delegate>(Module, "efl_ui_language_set");

        private static void language_set(System.IntPtr obj, System.IntPtr pd, System.String language)
        {
            Eina.Log.Debug("function efl_ui_language_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetLanguage(language);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_language_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), language);
            }
        }

        private static efl_ui_language_set_delegate efl_ui_language_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_CanvasText_ExtensionMethods {
    
    
    public static Efl.BindableProperty<System.String> BidiDelimiters<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Text, T>magic = null) where T : Efl.Canvas.Text {
        return new Efl.BindableProperty<System.String>("bidi_delimiters", fac);
    }

    public static Efl.BindableProperty<bool> LegacyNewline<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Text, T>magic = null) where T : Efl.Canvas.Text {
        return new Efl.BindableProperty<bool>("legacy_newline", fac);
    }

    
    
    
    
    
    
    
    
    
    
    
    public static Efl.BindableProperty<System.String> FontSource<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Text, T>magic = null) where T : Efl.Canvas.Text {
        return new Efl.BindableProperty<System.String>("font_source", fac);
    }

    public static Efl.BindableProperty<System.String> FontFallbacks<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Text, T>magic = null) where T : Efl.Canvas.Text {
        return new Efl.BindableProperty<System.String>("font_fallbacks", fac);
    }

    public static Efl.BindableProperty<Efl.TextFontWeight> FontWeight<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Text, T>magic = null) where T : Efl.Canvas.Text {
        return new Efl.BindableProperty<Efl.TextFontWeight>("font_weight", fac);
    }

    public static Efl.BindableProperty<Efl.TextFontSlant> FontSlant<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Text, T>magic = null) where T : Efl.Canvas.Text {
        return new Efl.BindableProperty<Efl.TextFontSlant>("font_slant", fac);
    }

    public static Efl.BindableProperty<Efl.TextFontWidth> FontWidth<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Text, T>magic = null) where T : Efl.Canvas.Text {
        return new Efl.BindableProperty<Efl.TextFontWidth>("font_width", fac);
    }

    public static Efl.BindableProperty<System.String> FontLang<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Text, T>magic = null) where T : Efl.Canvas.Text {
        return new Efl.BindableProperty<System.String>("font_lang", fac);
    }

    public static Efl.BindableProperty<Efl.TextFontBitmapScalable> FontBitmapScalable<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Text, T>magic = null) where T : Efl.Canvas.Text {
        return new Efl.BindableProperty<Efl.TextFontBitmapScalable>("font_bitmap_scalable", fac);
    }

    public static Efl.BindableProperty<double> Ellipsis<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Text, T>magic = null) where T : Efl.Canvas.Text {
        return new Efl.BindableProperty<double>("ellipsis", fac);
    }

    public static Efl.BindableProperty<Efl.TextFormatWrap> Wrap<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Text, T>magic = null) where T : Efl.Canvas.Text {
        return new Efl.BindableProperty<Efl.TextFormatWrap>("wrap", fac);
    }

    public static Efl.BindableProperty<bool> Multiline<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Text, T>magic = null) where T : Efl.Canvas.Text {
        return new Efl.BindableProperty<bool>("multiline", fac);
    }

    public static Efl.BindableProperty<Efl.TextFormatHorizontalAlignmentAutoType> HalignAutoType<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Text, T>magic = null) where T : Efl.Canvas.Text {
        return new Efl.BindableProperty<Efl.TextFormatHorizontalAlignmentAutoType>("halign_auto_type", fac);
    }

    public static Efl.BindableProperty<double> Halign<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Text, T>magic = null) where T : Efl.Canvas.Text {
        return new Efl.BindableProperty<double>("halign", fac);
    }

    public static Efl.BindableProperty<double> Valign<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Text, T>magic = null) where T : Efl.Canvas.Text {
        return new Efl.BindableProperty<double>("valign", fac);
    }

    public static Efl.BindableProperty<double> Linegap<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Text, T>magic = null) where T : Efl.Canvas.Text {
        return new Efl.BindableProperty<double>("linegap", fac);
    }

    public static Efl.BindableProperty<double> Linerelgap<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Text, T>magic = null) where T : Efl.Canvas.Text {
        return new Efl.BindableProperty<double>("linerelgap", fac);
    }

    public static Efl.BindableProperty<int> Tabstops<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Text, T>magic = null) where T : Efl.Canvas.Text {
        return new Efl.BindableProperty<int>("tabstops", fac);
    }

    public static Efl.BindableProperty<bool> Password<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Text, T>magic = null) where T : Efl.Canvas.Text {
        return new Efl.BindableProperty<bool>("password", fac);
    }

    public static Efl.BindableProperty<System.String> ReplacementChar<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Text, T>magic = null) where T : Efl.Canvas.Text {
        return new Efl.BindableProperty<System.String>("replacement_char", fac);
    }

    public static Efl.BindableProperty<System.String> Markup<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Text, T>magic = null) where T : Efl.Canvas.Text {
        return new Efl.BindableProperty<System.String>("markup", fac);
    }

    
    
    public static Efl.BindableProperty<Efl.TextStyleBackingType> BackingType<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Text, T>magic = null) where T : Efl.Canvas.Text {
        return new Efl.BindableProperty<Efl.TextStyleBackingType>("backing_type", fac);
    }

    
    public static Efl.BindableProperty<Efl.TextStyleUnderlineType> UnderlineType<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Text, T>magic = null) where T : Efl.Canvas.Text {
        return new Efl.BindableProperty<Efl.TextStyleUnderlineType>("underline_type", fac);
    }

    
    public static Efl.BindableProperty<double> UnderlineHeight<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Text, T>magic = null) where T : Efl.Canvas.Text {
        return new Efl.BindableProperty<double>("underline_height", fac);
    }

    
    public static Efl.BindableProperty<int> UnderlineDashedWidth<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Text, T>magic = null) where T : Efl.Canvas.Text {
        return new Efl.BindableProperty<int>("underline_dashed_width", fac);
    }

    public static Efl.BindableProperty<int> UnderlineDashedGap<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Text, T>magic = null) where T : Efl.Canvas.Text {
        return new Efl.BindableProperty<int>("underline_dashed_gap", fac);
    }

    
    public static Efl.BindableProperty<Efl.TextStyleStrikethroughType> StrikethroughType<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Text, T>magic = null) where T : Efl.Canvas.Text {
        return new Efl.BindableProperty<Efl.TextStyleStrikethroughType>("strikethrough_type", fac);
    }

    
    public static Efl.BindableProperty<Efl.TextStyleEffectType> EffectType<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Text, T>magic = null) where T : Efl.Canvas.Text {
        return new Efl.BindableProperty<Efl.TextStyleEffectType>("effect_type", fac);
    }

    
    public static Efl.BindableProperty<Efl.TextStyleShadowDirection> ShadowDirection<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Text, T>magic = null) where T : Efl.Canvas.Text {
        return new Efl.BindableProperty<Efl.TextStyleShadowDirection>("shadow_direction", fac);
    }

    
    
    
    public static Efl.BindableProperty<System.String> GfxFilter<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Text, T>magic = null) where T : Efl.Canvas.Text {
        return new Efl.BindableProperty<System.String>("gfx_filter", fac);
    }

    public static Efl.BindableProperty<bool> FilterChanged<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Text, T>magic = null) where T : Efl.Canvas.Text {
        return new Efl.BindableProperty<bool>("filter_changed", fac);
    }

    public static Efl.BindableProperty<bool> FilterInvalid<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Text, T>magic = null) where T : Efl.Canvas.Text {
        return new Efl.BindableProperty<bool>("filter_invalid", fac);
    }

    
    
    
    
    
    
    public static Efl.BindableProperty<bool> Mirrored<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Text, T>magic = null) where T : Efl.Canvas.Text {
        return new Efl.BindableProperty<bool>("mirrored", fac);
    }

    public static Efl.BindableProperty<bool> MirroredAutomatic<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Text, T>magic = null) where T : Efl.Canvas.Text {
        return new Efl.BindableProperty<bool>("mirrored_automatic", fac);
    }

    public static Efl.BindableProperty<System.String> Language<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Text, T>magic = null) where T : Efl.Canvas.Text {
        return new Efl.BindableProperty<System.String>("language", fac);
    }

}
#pragma warning restore CS1591
#endif
