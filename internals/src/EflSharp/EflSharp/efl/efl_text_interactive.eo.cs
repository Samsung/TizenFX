#define EFL_BETA
#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

/// <summary>This is an interface interactive text inputs should implement</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.ITextInteractiveConcrete.NativeMethods]
[Efl.Eo.BindingEntity]
public interface ITextInteractive : 
    Efl.IText ,
    Efl.ITextFont ,
    Efl.ITextFormat ,
    Efl.ITextStyle ,
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Whether or not selection is allowed on this object</summary>
/// <returns><c>true</c> if enabled, <c>false</c> otherwise</returns>
bool GetSelectionAllowed();
    /// <summary>Whether or not selection is allowed on this object</summary>
/// <param name="allowed"><c>true</c> if enabled, <c>false</c> otherwise</param>
void SetSelectionAllowed(bool allowed);
    /// <summary>The cursors used for selection handling.
/// If the cursors are equal there&apos;s no selection.
/// 
/// You are allowed to retain and modify them. Modifying them modifies the selection of the object.</summary>
/// <param name="start">The start of the selection</param>
/// <param name="end">The end of the selection</param>
void GetSelectionCursors(out Efl.TextCursorCursor start, out Efl.TextCursorCursor end);
    /// <summary>Whether the entry is editable.
/// By default text interactives are editable. However setting this property to <c>false</c> will make it so that key input will be disregarded.</summary>
/// <returns>If <c>true</c>, user input will be inserted in the entry, if not, the entry is read-only and no user input is allowed.</returns>
bool GetEditable();
    /// <summary>Whether the entry is editable.
/// By default text interactives are editable. However setting this property to <c>false</c> will make it so that key input will be disregarded.</summary>
/// <param name="editable">If <c>true</c>, user input will be inserted in the entry, if not, the entry is read-only and no user input is allowed.</param>
void SetEditable(bool editable);
    /// <summary>Clears the selection.</summary>
void SelectNone();
                            /// <summary>The selection on the object has changed. Query using <see cref="Efl.ITextInteractive.GetSelectionCursors"/></summary>
    event EventHandler TextSelectionChangedEvt;
    /// <summary>Whether or not selection is allowed on this object</summary>
    /// <value><c>true</c> if enabled, <c>false</c> otherwise</value>
    bool SelectionAllowed {
        get;
        set;
    }
    /// <summary>The cursors used for selection handling.
    /// If the cursors are equal there&apos;s no selection.
    /// 
    /// You are allowed to retain and modify them. Modifying them modifies the selection of the object.</summary>
    (Efl.TextCursorCursor, Efl.TextCursorCursor) SelectionCursors {
        get;
    }
    /// <summary>Whether the entry is editable.
    /// By default text interactives are editable. However setting this property to <c>false</c> will make it so that key input will be disregarded.</summary>
    /// <value>If <c>true</c>, user input will be inserted in the entry, if not, the entry is read-only and no user input is allowed.</value>
    bool Editable {
        get;
        set;
    }
}
/// <summary>This is an interface interactive text inputs should implement</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
sealed public  class ITextInteractiveConcrete :
    Efl.Eo.EoWrapper
    , ITextInteractive
    , Efl.IText, Efl.ITextFont, Efl.ITextFormat, Efl.ITextStyle
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(ITextInteractiveConcrete))
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
    private ITextInteractiveConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_text_interactive_interface_get();
    /// <summary>Initializes a new instance of the <see cref="ITextInteractive"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private ITextInteractiveConcrete(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>The selection on the object has changed. Query using <see cref="Efl.ITextInteractive.GetSelectionCursors"/></summary>
    public event EventHandler TextSelectionChangedEvt
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

                string key = "_EFL_TEXT_INTERACTIVE_EVENT_TEXT_SELECTION_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_TEXT_INTERACTIVE_EVENT_TEXT_SELECTION_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event TextSelectionChangedEvt.</summary>
    public void OnTextSelectionChangedEvt(EventArgs e)
    {
        var key = "_EFL_TEXT_INTERACTIVE_EVENT_TEXT_SELECTION_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Whether or not selection is allowed on this object</summary>
    /// <returns><c>true</c> if enabled, <c>false</c> otherwise</returns>
    public bool GetSelectionAllowed() {
         var _ret_var = Efl.ITextInteractiveConcrete.NativeMethods.efl_text_interactive_selection_allowed_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Whether or not selection is allowed on this object</summary>
    /// <param name="allowed"><c>true</c> if enabled, <c>false</c> otherwise</param>
    public void SetSelectionAllowed(bool allowed) {
                                 Efl.ITextInteractiveConcrete.NativeMethods.efl_text_interactive_selection_allowed_set_ptr.Value.Delegate(this.NativeHandle,allowed);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The cursors used for selection handling.
    /// If the cursors are equal there&apos;s no selection.
    /// 
    /// You are allowed to retain and modify them. Modifying them modifies the selection of the object.</summary>
    /// <param name="start">The start of the selection</param>
    /// <param name="end">The end of the selection</param>
    public void GetSelectionCursors(out Efl.TextCursorCursor start, out Efl.TextCursorCursor end) {
                                                         Efl.ITextInteractiveConcrete.NativeMethods.efl_text_interactive_selection_cursors_get_ptr.Value.Delegate(this.NativeHandle,out start, out end);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Whether the entry is editable.
    /// By default text interactives are editable. However setting this property to <c>false</c> will make it so that key input will be disregarded.</summary>
    /// <returns>If <c>true</c>, user input will be inserted in the entry, if not, the entry is read-only and no user input is allowed.</returns>
    public bool GetEditable() {
         var _ret_var = Efl.ITextInteractiveConcrete.NativeMethods.efl_text_interactive_editable_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Whether the entry is editable.
    /// By default text interactives are editable. However setting this property to <c>false</c> will make it so that key input will be disregarded.</summary>
    /// <param name="editable">If <c>true</c>, user input will be inserted in the entry, if not, the entry is read-only and no user input is allowed.</param>
    public void SetEditable(bool editable) {
                                 Efl.ITextInteractiveConcrete.NativeMethods.efl_text_interactive_editable_set_ptr.Value.Delegate(this.NativeHandle,editable);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Clears the selection.</summary>
    public void SelectNone() {
         Efl.ITextInteractiveConcrete.NativeMethods.efl_text_interactive_select_none_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Retrieves the text string currently being displayed by the given text object.
    /// Do not free() the return value.
    /// 
    /// See also <see cref="Efl.IText.GetText"/>.
    /// (Since EFL 1.22)</summary>
    /// <returns>Text string to display on it.</returns>
    public System.String GetText() {
         var _ret_var = Efl.ITextConcrete.NativeMethods.efl_text_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Sets the text string to be displayed by the given text object.
    /// See also <see cref="Efl.IText.GetText"/>.
    /// (Since EFL 1.22)</summary>
    /// <param name="text">Text string to display on it.</param>
    public void SetText(System.String text) {
                                 Efl.ITextConcrete.NativeMethods.efl_text_set_ptr.Value.Delegate(this.NativeHandle,text);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Retrieve the font family and size in use on a given text object.
    /// This function allows the font name and size of a text object to be queried. Remember that the font name string is still owned by Evas and should not have free() called on it by the caller of the function.
    /// 
    /// See also <see cref="Efl.ITextFont.GetFont"/>.</summary>
    /// <param name="font">The font family name or filename.</param>
    /// <param name="size">The font size, in points.</param>
    public void GetFont(out System.String font, out Efl.Font.Size size) {
                                                         Efl.ITextFontConcrete.NativeMethods.efl_text_font_get_ptr.Value.Delegate(this.NativeHandle,out font, out size);
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
    public void SetFont(System.String font, Efl.Font.Size size) {
                                                         Efl.ITextFontConcrete.NativeMethods.efl_text_font_set_ptr.Value.Delegate(this.NativeHandle,font, size);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Get the font file&apos;s path which is being used on a given text object.
    /// See <see cref="Efl.ITextFont.GetFont"/> for more details.</summary>
    /// <returns>The font file&apos;s path.</returns>
    public System.String GetFontSource() {
         var _ret_var = Efl.ITextFontConcrete.NativeMethods.efl_text_font_source_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the font (source) file to be used on a given text object.
    /// This function allows the font file to be explicitly set for a given text object, overriding system lookup, which will first occur in the given file&apos;s contents.
    /// 
    /// See also <see cref="Efl.ITextFont.GetFont"/>.</summary>
    /// <param name="font_source">The font file&apos;s path.</param>
    public void SetFontSource(System.String font_source) {
                                 Efl.ITextFontConcrete.NativeMethods.efl_text_font_source_set_ptr.Value.Delegate(this.NativeHandle,font_source);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Comma-separated list of font fallbacks
    /// Will be used in case the primary font isn&apos;t available.</summary>
    /// <returns>Font name fallbacks</returns>
    public System.String GetFontFallbacks() {
         var _ret_var = Efl.ITextFontConcrete.NativeMethods.efl_text_font_fallbacks_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Comma-separated list of font fallbacks
    /// Will be used in case the primary font isn&apos;t available.</summary>
    /// <param name="font_fallbacks">Font name fallbacks</param>
    public void SetFontFallbacks(System.String font_fallbacks) {
                                 Efl.ITextFontConcrete.NativeMethods.efl_text_font_fallbacks_set_ptr.Value.Delegate(this.NativeHandle,font_fallbacks);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Type of weight of the displayed font
    /// Default is <see cref="Efl.TextFontWeight.Normal"/>.</summary>
    /// <returns>Font weight</returns>
    public Efl.TextFontWeight GetFontWeight() {
         var _ret_var = Efl.ITextFontConcrete.NativeMethods.efl_text_font_weight_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Type of weight of the displayed font
    /// Default is <see cref="Efl.TextFontWeight.Normal"/>.</summary>
    /// <param name="font_weight">Font weight</param>
    public void SetFontWeight(Efl.TextFontWeight font_weight) {
                                 Efl.ITextFontConcrete.NativeMethods.efl_text_font_weight_set_ptr.Value.Delegate(this.NativeHandle,font_weight);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Type of slant of the displayed font
    /// Default is <see cref="Efl.TextFontSlant.Normal"/>.</summary>
    /// <returns>Font slant</returns>
    public Efl.TextFontSlant GetFontSlant() {
         var _ret_var = Efl.ITextFontConcrete.NativeMethods.efl_text_font_slant_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Type of slant of the displayed font
    /// Default is <see cref="Efl.TextFontSlant.Normal"/>.</summary>
    /// <param name="style">Font slant</param>
    public void SetFontSlant(Efl.TextFontSlant style) {
                                 Efl.ITextFontConcrete.NativeMethods.efl_text_font_slant_set_ptr.Value.Delegate(this.NativeHandle,style);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Type of width of the displayed font
    /// Default is <see cref="Efl.TextFontWidth.Normal"/>.</summary>
    /// <returns>Font width</returns>
    public Efl.TextFontWidth GetFontWidth() {
         var _ret_var = Efl.ITextFontConcrete.NativeMethods.efl_text_font_width_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Type of width of the displayed font
    /// Default is <see cref="Efl.TextFontWidth.Normal"/>.</summary>
    /// <param name="width">Font width</param>
    public void SetFontWidth(Efl.TextFontWidth width) {
                                 Efl.ITextFontConcrete.NativeMethods.efl_text_font_width_set_ptr.Value.Delegate(this.NativeHandle,width);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Specific language of the displayed font
    /// This is used to lookup fonts suitable to the specified language, as well as helping the font shaper backend. The language <c>lang</c> can be either a code e.g &quot;en_US&quot;, &quot;auto&quot; to use the system locale, or &quot;none&quot;.</summary>
    /// <returns>Language</returns>
    public System.String GetFontLang() {
         var _ret_var = Efl.ITextFontConcrete.NativeMethods.efl_text_font_lang_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Specific language of the displayed font
    /// This is used to lookup fonts suitable to the specified language, as well as helping the font shaper backend. The language <c>lang</c> can be either a code e.g &quot;en_US&quot;, &quot;auto&quot; to use the system locale, or &quot;none&quot;.</summary>
    /// <param name="lang">Language</param>
    public void SetFontLang(System.String lang) {
                                 Efl.ITextFontConcrete.NativeMethods.efl_text_font_lang_set_ptr.Value.Delegate(this.NativeHandle,lang);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The bitmap fonts have fixed size glyphs for several available sizes. Basically, it is not scalable. But, it needs to be scalable for some use cases. (ex. colorful emoji fonts)
    /// Default is <see cref="Efl.TextFontBitmapScalable.None"/>.</summary>
    /// <returns>Scalable</returns>
    public Efl.TextFontBitmapScalable GetFontBitmapScalable() {
         var _ret_var = Efl.ITextFontConcrete.NativeMethods.efl_text_font_bitmap_scalable_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The bitmap fonts have fixed size glyphs for several available sizes. Basically, it is not scalable. But, it needs to be scalable for some use cases. (ex. colorful emoji fonts)
    /// Default is <see cref="Efl.TextFontBitmapScalable.None"/>.</summary>
    /// <param name="scalable">Scalable</param>
    public void SetFontBitmapScalable(Efl.TextFontBitmapScalable scalable) {
                                 Efl.ITextFontConcrete.NativeMethods.efl_text_font_bitmap_scalable_set_ptr.Value.Delegate(this.NativeHandle,scalable);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Ellipsis value (number from -1.0 to 1.0)</summary>
    /// <returns>Ellipsis value</returns>
    public double GetEllipsis() {
         var _ret_var = Efl.ITextFormatConcrete.NativeMethods.efl_text_ellipsis_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Ellipsis value (number from -1.0 to 1.0)</summary>
    /// <param name="value">Ellipsis value</param>
    public void SetEllipsis(double value) {
                                 Efl.ITextFormatConcrete.NativeMethods.efl_text_ellipsis_set_ptr.Value.Delegate(this.NativeHandle,value);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Wrap mode for use in the text</summary>
    /// <returns>Wrap mode</returns>
    public Efl.TextFormatWrap GetWrap() {
         var _ret_var = Efl.ITextFormatConcrete.NativeMethods.efl_text_wrap_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Wrap mode for use in the text</summary>
    /// <param name="wrap">Wrap mode</param>
    public void SetWrap(Efl.TextFormatWrap wrap) {
                                 Efl.ITextFormatConcrete.NativeMethods.efl_text_wrap_set_ptr.Value.Delegate(this.NativeHandle,wrap);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Multiline is enabled or not</summary>
    /// <returns><c>true</c> if multiline is enabled, <c>false</c> otherwise</returns>
    public bool GetMultiline() {
         var _ret_var = Efl.ITextFormatConcrete.NativeMethods.efl_text_multiline_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Multiline is enabled or not</summary>
    /// <param name="enabled"><c>true</c> if multiline is enabled, <c>false</c> otherwise</param>
    public void SetMultiline(bool enabled) {
                                 Efl.ITextFormatConcrete.NativeMethods.efl_text_multiline_set_ptr.Value.Delegate(this.NativeHandle,enabled);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Horizontal alignment of text</summary>
    /// <returns>Alignment type</returns>
    public Efl.TextFormatHorizontalAlignmentAutoType GetHalignAutoType() {
         var _ret_var = Efl.ITextFormatConcrete.NativeMethods.efl_text_halign_auto_type_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Horizontal alignment of text</summary>
    /// <param name="value">Alignment type</param>
    public void SetHalignAutoType(Efl.TextFormatHorizontalAlignmentAutoType value) {
                                 Efl.ITextFormatConcrete.NativeMethods.efl_text_halign_auto_type_set_ptr.Value.Delegate(this.NativeHandle,value);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Horizontal alignment of text</summary>
    /// <returns>Horizontal alignment value</returns>
    public double GetHalign() {
         var _ret_var = Efl.ITextFormatConcrete.NativeMethods.efl_text_halign_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Horizontal alignment of text</summary>
    /// <param name="value">Horizontal alignment value</param>
    public void SetHalign(double value) {
                                 Efl.ITextFormatConcrete.NativeMethods.efl_text_halign_set_ptr.Value.Delegate(this.NativeHandle,value);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Vertical alignment of text</summary>
    /// <returns>Vertical alignment value</returns>
    public double GetValign() {
         var _ret_var = Efl.ITextFormatConcrete.NativeMethods.efl_text_valign_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Vertical alignment of text</summary>
    /// <param name="value">Vertical alignment value</param>
    public void SetValign(double value) {
                                 Efl.ITextFormatConcrete.NativeMethods.efl_text_valign_set_ptr.Value.Delegate(this.NativeHandle,value);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Minimal line gap (top and bottom) for each line in the text
    /// <c>value</c> is absolute size.</summary>
    /// <returns>Line gap value</returns>
    public double GetLinegap() {
         var _ret_var = Efl.ITextFormatConcrete.NativeMethods.efl_text_linegap_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Minimal line gap (top and bottom) for each line in the text
    /// <c>value</c> is absolute size.</summary>
    /// <param name="value">Line gap value</param>
    public void SetLinegap(double value) {
                                 Efl.ITextFormatConcrete.NativeMethods.efl_text_linegap_set_ptr.Value.Delegate(this.NativeHandle,value);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Relative line gap (top and bottom) for each line in the text
    /// The original line gap value is multiplied by <c>value</c>.</summary>
    /// <returns>Relative line gap value</returns>
    public double GetLinerelgap() {
         var _ret_var = Efl.ITextFormatConcrete.NativeMethods.efl_text_linerelgap_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Relative line gap (top and bottom) for each line in the text
    /// The original line gap value is multiplied by <c>value</c>.</summary>
    /// <param name="value">Relative line gap value</param>
    public void SetLinerelgap(double value) {
                                 Efl.ITextFormatConcrete.NativeMethods.efl_text_linerelgap_set_ptr.Value.Delegate(this.NativeHandle,value);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Tabstops value</summary>
    /// <returns>Tapstops value</returns>
    public int GetTabstops() {
         var _ret_var = Efl.ITextFormatConcrete.NativeMethods.efl_text_tabstops_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Tabstops value</summary>
    /// <param name="value">Tapstops value</param>
    public void SetTabstops(int value) {
                                 Efl.ITextFormatConcrete.NativeMethods.efl_text_tabstops_set_ptr.Value.Delegate(this.NativeHandle,value);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Whether text is a password</summary>
    /// <returns><c>true</c> if the text is a password, <c>false</c> otherwise</returns>
    public bool GetPassword() {
         var _ret_var = Efl.ITextFormatConcrete.NativeMethods.efl_text_password_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Whether text is a password</summary>
    /// <param name="enabled"><c>true</c> if the text is a password, <c>false</c> otherwise</param>
    public void SetPassword(bool enabled) {
                                 Efl.ITextFormatConcrete.NativeMethods.efl_text_password_set_ptr.Value.Delegate(this.NativeHandle,enabled);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The character used to replace characters that can&apos;t be displayed
    /// Currently only used to replace characters if <see cref="Efl.ITextFormat.Password"/> is enabled.</summary>
    /// <returns>Replacement character</returns>
    public System.String GetReplacementChar() {
         var _ret_var = Efl.ITextFormatConcrete.NativeMethods.efl_text_replacement_char_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The character used to replace characters that can&apos;t be displayed
    /// Currently only used to replace characters if <see cref="Efl.ITextFormat.Password"/> is enabled.</summary>
    /// <param name="repch">Replacement character</param>
    public void SetReplacementChar(System.String repch) {
                                 Efl.ITextFormatConcrete.NativeMethods.efl_text_replacement_char_set_ptr.Value.Delegate(this.NativeHandle,repch);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Color of text, excluding style</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    public void GetNormalColor(out byte r, out byte g, out byte b, out byte a) {
                                                                                                         Efl.ITextStyleConcrete.NativeMethods.efl_text_normal_color_get_ptr.Value.Delegate(this.NativeHandle,out r, out g, out b, out a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Color of text, excluding style</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    public void SetNormalColor(byte r, byte g, byte b, byte a) {
                                                                                                         Efl.ITextStyleConcrete.NativeMethods.efl_text_normal_color_set_ptr.Value.Delegate(this.NativeHandle,r, g, b, a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Enable or disable backing type</summary>
    /// <returns>Backing type</returns>
    public Efl.TextStyleBackingType GetBackingType() {
         var _ret_var = Efl.ITextStyleConcrete.NativeMethods.efl_text_backing_type_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Enable or disable backing type</summary>
    /// <param name="type">Backing type</param>
    public void SetBackingType(Efl.TextStyleBackingType type) {
                                 Efl.ITextStyleConcrete.NativeMethods.efl_text_backing_type_set_ptr.Value.Delegate(this.NativeHandle,type);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Backing color</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    public void GetBackingColor(out byte r, out byte g, out byte b, out byte a) {
                                                                                                         Efl.ITextStyleConcrete.NativeMethods.efl_text_backing_color_get_ptr.Value.Delegate(this.NativeHandle,out r, out g, out b, out a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Backing color</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    public void SetBackingColor(byte r, byte g, byte b, byte a) {
                                                                                                         Efl.ITextStyleConcrete.NativeMethods.efl_text_backing_color_set_ptr.Value.Delegate(this.NativeHandle,r, g, b, a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Sets an underline style on the text</summary>
    /// <returns>Underline type</returns>
    public Efl.TextStyleUnderlineType GetUnderlineType() {
         var _ret_var = Efl.ITextStyleConcrete.NativeMethods.efl_text_underline_type_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Sets an underline style on the text</summary>
    /// <param name="type">Underline type</param>
    public void SetUnderlineType(Efl.TextStyleUnderlineType type) {
                                 Efl.ITextStyleConcrete.NativeMethods.efl_text_underline_type_set_ptr.Value.Delegate(this.NativeHandle,type);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Color of normal underline style</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    public void GetUnderlineColor(out byte r, out byte g, out byte b, out byte a) {
                                                                                                         Efl.ITextStyleConcrete.NativeMethods.efl_text_underline_color_get_ptr.Value.Delegate(this.NativeHandle,out r, out g, out b, out a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Color of normal underline style</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    public void SetUnderlineColor(byte r, byte g, byte b, byte a) {
                                                                                                         Efl.ITextStyleConcrete.NativeMethods.efl_text_underline_color_set_ptr.Value.Delegate(this.NativeHandle,r, g, b, a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Height of underline style</summary>
    /// <returns>Height</returns>
    public double GetUnderlineHeight() {
         var _ret_var = Efl.ITextStyleConcrete.NativeMethods.efl_text_underline_height_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Height of underline style</summary>
    /// <param name="height">Height</param>
    public void SetUnderlineHeight(double height) {
                                 Efl.ITextStyleConcrete.NativeMethods.efl_text_underline_height_set_ptr.Value.Delegate(this.NativeHandle,height);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Color of dashed underline style</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    public void GetUnderlineDashedColor(out byte r, out byte g, out byte b, out byte a) {
                                                                                                         Efl.ITextStyleConcrete.NativeMethods.efl_text_underline_dashed_color_get_ptr.Value.Delegate(this.NativeHandle,out r, out g, out b, out a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Color of dashed underline style</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    public void SetUnderlineDashedColor(byte r, byte g, byte b, byte a) {
                                                                                                         Efl.ITextStyleConcrete.NativeMethods.efl_text_underline_dashed_color_set_ptr.Value.Delegate(this.NativeHandle,r, g, b, a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Width of dashed underline style</summary>
    /// <returns>Width</returns>
    public int GetUnderlineDashedWidth() {
         var _ret_var = Efl.ITextStyleConcrete.NativeMethods.efl_text_underline_dashed_width_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Width of dashed underline style</summary>
    /// <param name="width">Width</param>
    public void SetUnderlineDashedWidth(int width) {
                                 Efl.ITextStyleConcrete.NativeMethods.efl_text_underline_dashed_width_set_ptr.Value.Delegate(this.NativeHandle,width);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Gap of dashed underline style</summary>
    /// <returns>Gap</returns>
    public int GetUnderlineDashedGap() {
         var _ret_var = Efl.ITextStyleConcrete.NativeMethods.efl_text_underline_dashed_gap_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Gap of dashed underline style</summary>
    /// <param name="gap">Gap</param>
    public void SetUnderlineDashedGap(int gap) {
                                 Efl.ITextStyleConcrete.NativeMethods.efl_text_underline_dashed_gap_set_ptr.Value.Delegate(this.NativeHandle,gap);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Color of underline2 style</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    public void GetUnderline2Color(out byte r, out byte g, out byte b, out byte a) {
                                                                                                         Efl.ITextStyleConcrete.NativeMethods.efl_text_underline2_color_get_ptr.Value.Delegate(this.NativeHandle,out r, out g, out b, out a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Color of underline2 style</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    public void SetUnderline2Color(byte r, byte g, byte b, byte a) {
                                                                                                         Efl.ITextStyleConcrete.NativeMethods.efl_text_underline2_color_set_ptr.Value.Delegate(this.NativeHandle,r, g, b, a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Type of strikethrough style</summary>
    /// <returns>Strikethrough type</returns>
    public Efl.TextStyleStrikethroughType GetStrikethroughType() {
         var _ret_var = Efl.ITextStyleConcrete.NativeMethods.efl_text_strikethrough_type_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Type of strikethrough style</summary>
    /// <param name="type">Strikethrough type</param>
    public void SetStrikethroughType(Efl.TextStyleStrikethroughType type) {
                                 Efl.ITextStyleConcrete.NativeMethods.efl_text_strikethrough_type_set_ptr.Value.Delegate(this.NativeHandle,type);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Color of strikethrough_style</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    public void GetStrikethroughColor(out byte r, out byte g, out byte b, out byte a) {
                                                                                                         Efl.ITextStyleConcrete.NativeMethods.efl_text_strikethrough_color_get_ptr.Value.Delegate(this.NativeHandle,out r, out g, out b, out a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Color of strikethrough_style</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    public void SetStrikethroughColor(byte r, byte g, byte b, byte a) {
                                                                                                         Efl.ITextStyleConcrete.NativeMethods.efl_text_strikethrough_color_set_ptr.Value.Delegate(this.NativeHandle,r, g, b, a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Type of effect used for the displayed text</summary>
    /// <returns>Effect type</returns>
    public Efl.TextStyleEffectType GetEffectType() {
         var _ret_var = Efl.ITextStyleConcrete.NativeMethods.efl_text_effect_type_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Type of effect used for the displayed text</summary>
    /// <param name="type">Effect type</param>
    public void SetEffectType(Efl.TextStyleEffectType type) {
                                 Efl.ITextStyleConcrete.NativeMethods.efl_text_effect_type_set_ptr.Value.Delegate(this.NativeHandle,type);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Color of outline effect</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    public void GetOutlineColor(out byte r, out byte g, out byte b, out byte a) {
                                                                                                         Efl.ITextStyleConcrete.NativeMethods.efl_text_outline_color_get_ptr.Value.Delegate(this.NativeHandle,out r, out g, out b, out a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Color of outline effect</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    public void SetOutlineColor(byte r, byte g, byte b, byte a) {
                                                                                                         Efl.ITextStyleConcrete.NativeMethods.efl_text_outline_color_set_ptr.Value.Delegate(this.NativeHandle,r, g, b, a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Direction of shadow effect</summary>
    /// <returns>Shadow direction</returns>
    public Efl.TextStyleShadowDirection GetShadowDirection() {
         var _ret_var = Efl.ITextStyleConcrete.NativeMethods.efl_text_shadow_direction_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Direction of shadow effect</summary>
    /// <param name="type">Shadow direction</param>
    public void SetShadowDirection(Efl.TextStyleShadowDirection type) {
                                 Efl.ITextStyleConcrete.NativeMethods.efl_text_shadow_direction_set_ptr.Value.Delegate(this.NativeHandle,type);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Color of shadow effect</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    public void GetShadowColor(out byte r, out byte g, out byte b, out byte a) {
                                                                                                         Efl.ITextStyleConcrete.NativeMethods.efl_text_shadow_color_get_ptr.Value.Delegate(this.NativeHandle,out r, out g, out b, out a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Color of shadow effect</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    public void SetShadowColor(byte r, byte g, byte b, byte a) {
                                                                                                         Efl.ITextStyleConcrete.NativeMethods.efl_text_shadow_color_set_ptr.Value.Delegate(this.NativeHandle,r, g, b, a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Color of glow effect</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    public void GetGlowColor(out byte r, out byte g, out byte b, out byte a) {
                                                                                                         Efl.ITextStyleConcrete.NativeMethods.efl_text_glow_color_get_ptr.Value.Delegate(this.NativeHandle,out r, out g, out b, out a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Color of glow effect</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    public void SetGlowColor(byte r, byte g, byte b, byte a) {
                                                                                                         Efl.ITextStyleConcrete.NativeMethods.efl_text_glow_color_set_ptr.Value.Delegate(this.NativeHandle,r, g, b, a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Second color of the glow effect</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    public void GetGlow2Color(out byte r, out byte g, out byte b, out byte a) {
                                                                                                         Efl.ITextStyleConcrete.NativeMethods.efl_text_glow2_color_get_ptr.Value.Delegate(this.NativeHandle,out r, out g, out b, out a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Second color of the glow effect</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    public void SetGlow2Color(byte r, byte g, byte b, byte a) {
                                                                                                         Efl.ITextStyleConcrete.NativeMethods.efl_text_glow2_color_set_ptr.Value.Delegate(this.NativeHandle,r, g, b, a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Program that applies a special filter
    /// See <see cref="Efl.Gfx.IFilter"/>.</summary>
    /// <returns>Filter code</returns>
    public System.String GetGfxFilter() {
         var _ret_var = Efl.ITextStyleConcrete.NativeMethods.efl_text_gfx_filter_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Program that applies a special filter
    /// See <see cref="Efl.Gfx.IFilter"/>.</summary>
    /// <param name="code">Filter code</param>
    public void SetGfxFilter(System.String code) {
                                 Efl.ITextStyleConcrete.NativeMethods.efl_text_gfx_filter_set_ptr.Value.Delegate(this.NativeHandle,code);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Whether or not selection is allowed on this object</summary>
    /// <value><c>true</c> if enabled, <c>false</c> otherwise</value>
    public bool SelectionAllowed {
        get { return GetSelectionAllowed(); }
        set { SetSelectionAllowed(value); }
    }
    /// <summary>The cursors used for selection handling.
    /// If the cursors are equal there&apos;s no selection.
    /// 
    /// You are allowed to retain and modify them. Modifying them modifies the selection of the object.</summary>
    public (Efl.TextCursorCursor, Efl.TextCursorCursor) SelectionCursors {
        get {
            Efl.TextCursorCursor _out_start = default(Efl.TextCursorCursor);
            Efl.TextCursorCursor _out_end = default(Efl.TextCursorCursor);
            GetSelectionCursors(out _out_start,out _out_end);
            return (_out_start,_out_end);
        }
    }
    /// <summary>Whether the entry is editable.
    /// By default text interactives are editable. However setting this property to <c>false</c> will make it so that key input will be disregarded.</summary>
    /// <value>If <c>true</c>, user input will be inserted in the entry, if not, the entry is read-only and no user input is allowed.</value>
    public bool Editable {
        get { return GetEditable(); }
        set { SetEditable(value); }
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
    private static IntPtr GetEflClassStatic()
    {
        return Efl.ITextInteractiveConcrete.efl_text_interactive_interface_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Eo.EoWrapper.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Elementary);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_text_interactive_selection_allowed_get_static_delegate == null)
            {
                efl_text_interactive_selection_allowed_get_static_delegate = new efl_text_interactive_selection_allowed_get_delegate(selection_allowed_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetSelectionAllowed") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_interactive_selection_allowed_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_interactive_selection_allowed_get_static_delegate) });
            }

            if (efl_text_interactive_selection_allowed_set_static_delegate == null)
            {
                efl_text_interactive_selection_allowed_set_static_delegate = new efl_text_interactive_selection_allowed_set_delegate(selection_allowed_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetSelectionAllowed") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_interactive_selection_allowed_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_interactive_selection_allowed_set_static_delegate) });
            }

            if (efl_text_interactive_selection_cursors_get_static_delegate == null)
            {
                efl_text_interactive_selection_cursors_get_static_delegate = new efl_text_interactive_selection_cursors_get_delegate(selection_cursors_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetSelectionCursors") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_interactive_selection_cursors_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_interactive_selection_cursors_get_static_delegate) });
            }

            if (efl_text_interactive_editable_get_static_delegate == null)
            {
                efl_text_interactive_editable_get_static_delegate = new efl_text_interactive_editable_get_delegate(editable_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetEditable") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_interactive_editable_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_interactive_editable_get_static_delegate) });
            }

            if (efl_text_interactive_editable_set_static_delegate == null)
            {
                efl_text_interactive_editable_set_static_delegate = new efl_text_interactive_editable_set_delegate(editable_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetEditable") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_interactive_editable_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_interactive_editable_set_static_delegate) });
            }

            if (efl_text_interactive_select_none_static_delegate == null)
            {
                efl_text_interactive_select_none_static_delegate = new efl_text_interactive_select_none_delegate(select_none);
            }

            if (methods.FirstOrDefault(m => m.Name == "SelectNone") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_interactive_select_none"), func = Marshal.GetFunctionPointerForDelegate(efl_text_interactive_select_none_static_delegate) });
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

            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.ITextInteractiveConcrete.efl_text_interactive_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_text_interactive_selection_allowed_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_text_interactive_selection_allowed_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_text_interactive_selection_allowed_get_api_delegate> efl_text_interactive_selection_allowed_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_interactive_selection_allowed_get_api_delegate>(Module, "efl_text_interactive_selection_allowed_get");

        private static bool selection_allowed_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_text_interactive_selection_allowed_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((ITextInteractive)ws.Target).GetSelectionAllowed();
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
                return efl_text_interactive_selection_allowed_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_text_interactive_selection_allowed_get_delegate efl_text_interactive_selection_allowed_get_static_delegate;

        
        private delegate void efl_text_interactive_selection_allowed_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool allowed);

        
        public delegate void efl_text_interactive_selection_allowed_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool allowed);

        public static Efl.Eo.FunctionWrapper<efl_text_interactive_selection_allowed_set_api_delegate> efl_text_interactive_selection_allowed_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_interactive_selection_allowed_set_api_delegate>(Module, "efl_text_interactive_selection_allowed_set");

        private static void selection_allowed_set(System.IntPtr obj, System.IntPtr pd, bool allowed)
        {
            Eina.Log.Debug("function efl_text_interactive_selection_allowed_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((ITextInteractive)ws.Target).SetSelectionAllowed(allowed);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_interactive_selection_allowed_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), allowed);
            }
        }

        private static efl_text_interactive_selection_allowed_set_delegate efl_text_interactive_selection_allowed_set_static_delegate;

        
        private delegate void efl_text_interactive_selection_cursors_get_delegate(System.IntPtr obj, System.IntPtr pd,  out Efl.TextCursorCursor start,  out Efl.TextCursorCursor end);

        
        public delegate void efl_text_interactive_selection_cursors_get_api_delegate(System.IntPtr obj,  out Efl.TextCursorCursor start,  out Efl.TextCursorCursor end);

        public static Efl.Eo.FunctionWrapper<efl_text_interactive_selection_cursors_get_api_delegate> efl_text_interactive_selection_cursors_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_interactive_selection_cursors_get_api_delegate>(Module, "efl_text_interactive_selection_cursors_get");

        private static void selection_cursors_get(System.IntPtr obj, System.IntPtr pd, out Efl.TextCursorCursor start, out Efl.TextCursorCursor end)
        {
            Eina.Log.Debug("function efl_text_interactive_selection_cursors_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                        start = default(Efl.TextCursorCursor);        end = default(Efl.TextCursorCursor);                            
                try
                {
                    ((ITextInteractive)ws.Target).GetSelectionCursors(out start, out end);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_text_interactive_selection_cursors_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out start, out end);
            }
        }

        private static efl_text_interactive_selection_cursors_get_delegate efl_text_interactive_selection_cursors_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_text_interactive_editable_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_text_interactive_editable_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_text_interactive_editable_get_api_delegate> efl_text_interactive_editable_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_interactive_editable_get_api_delegate>(Module, "efl_text_interactive_editable_get");

        private static bool editable_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_text_interactive_editable_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((ITextInteractive)ws.Target).GetEditable();
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
                return efl_text_interactive_editable_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_text_interactive_editable_get_delegate efl_text_interactive_editable_get_static_delegate;

        
        private delegate void efl_text_interactive_editable_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool editable);

        
        public delegate void efl_text_interactive_editable_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool editable);

        public static Efl.Eo.FunctionWrapper<efl_text_interactive_editable_set_api_delegate> efl_text_interactive_editable_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_interactive_editable_set_api_delegate>(Module, "efl_text_interactive_editable_set");

        private static void editable_set(System.IntPtr obj, System.IntPtr pd, bool editable)
        {
            Eina.Log.Debug("function efl_text_interactive_editable_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((ITextInteractive)ws.Target).SetEditable(editable);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_interactive_editable_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), editable);
            }
        }

        private static efl_text_interactive_editable_set_delegate efl_text_interactive_editable_set_static_delegate;

        
        private delegate void efl_text_interactive_select_none_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_text_interactive_select_none_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_text_interactive_select_none_api_delegate> efl_text_interactive_select_none_ptr = new Efl.Eo.FunctionWrapper<efl_text_interactive_select_none_api_delegate>(Module, "efl_text_interactive_select_none");

        private static void select_none(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_text_interactive_select_none was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((ITextInteractive)ws.Target).SelectNone();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_text_interactive_select_none_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_text_interactive_select_none_delegate efl_text_interactive_select_none_static_delegate;

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
                    _ret_var = ((ITextInteractive)ws.Target).GetText();
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
                    ((ITextInteractive)ws.Target).SetText(text);
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
                    ((ITextInteractive)ws.Target).GetFont(out _out_font, out size);
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
                    ((ITextInteractive)ws.Target).SetFont(font, size);
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
                    _ret_var = ((ITextInteractive)ws.Target).GetFontSource();
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
                    ((ITextInteractive)ws.Target).SetFontSource(font_source);
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
                    _ret_var = ((ITextInteractive)ws.Target).GetFontFallbacks();
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
                    ((ITextInteractive)ws.Target).SetFontFallbacks(font_fallbacks);
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
                    _ret_var = ((ITextInteractive)ws.Target).GetFontWeight();
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
                    ((ITextInteractive)ws.Target).SetFontWeight(font_weight);
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
                    _ret_var = ((ITextInteractive)ws.Target).GetFontSlant();
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
                    ((ITextInteractive)ws.Target).SetFontSlant(style);
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
                    _ret_var = ((ITextInteractive)ws.Target).GetFontWidth();
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
                    ((ITextInteractive)ws.Target).SetFontWidth(width);
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
                    _ret_var = ((ITextInteractive)ws.Target).GetFontLang();
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
                    ((ITextInteractive)ws.Target).SetFontLang(lang);
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
                    _ret_var = ((ITextInteractive)ws.Target).GetFontBitmapScalable();
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
                    ((ITextInteractive)ws.Target).SetFontBitmapScalable(scalable);
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
                    _ret_var = ((ITextInteractive)ws.Target).GetEllipsis();
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
                    ((ITextInteractive)ws.Target).SetEllipsis(value);
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
                    _ret_var = ((ITextInteractive)ws.Target).GetWrap();
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
                    ((ITextInteractive)ws.Target).SetWrap(wrap);
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
                    _ret_var = ((ITextInteractive)ws.Target).GetMultiline();
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
                    ((ITextInteractive)ws.Target).SetMultiline(enabled);
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
                    _ret_var = ((ITextInteractive)ws.Target).GetHalignAutoType();
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
                    ((ITextInteractive)ws.Target).SetHalignAutoType(value);
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
                    _ret_var = ((ITextInteractive)ws.Target).GetHalign();
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
                    ((ITextInteractive)ws.Target).SetHalign(value);
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
                    _ret_var = ((ITextInteractive)ws.Target).GetValign();
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
                    ((ITextInteractive)ws.Target).SetValign(value);
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
                    _ret_var = ((ITextInteractive)ws.Target).GetLinegap();
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
                    ((ITextInteractive)ws.Target).SetLinegap(value);
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
                    _ret_var = ((ITextInteractive)ws.Target).GetLinerelgap();
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
                    ((ITextInteractive)ws.Target).SetLinerelgap(value);
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
                    _ret_var = ((ITextInteractive)ws.Target).GetTabstops();
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
                    ((ITextInteractive)ws.Target).SetTabstops(value);
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
                    _ret_var = ((ITextInteractive)ws.Target).GetPassword();
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
                    ((ITextInteractive)ws.Target).SetPassword(enabled);
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
                    _ret_var = ((ITextInteractive)ws.Target).GetReplacementChar();
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
                    ((ITextInteractive)ws.Target).SetReplacementChar(repch);
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
                    ((ITextInteractive)ws.Target).GetNormalColor(out r, out g, out b, out a);
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
                    ((ITextInteractive)ws.Target).SetNormalColor(r, g, b, a);
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
                    _ret_var = ((ITextInteractive)ws.Target).GetBackingType();
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
                    ((ITextInteractive)ws.Target).SetBackingType(type);
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
                    ((ITextInteractive)ws.Target).GetBackingColor(out r, out g, out b, out a);
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
                    ((ITextInteractive)ws.Target).SetBackingColor(r, g, b, a);
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
                    _ret_var = ((ITextInteractive)ws.Target).GetUnderlineType();
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
                    ((ITextInteractive)ws.Target).SetUnderlineType(type);
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
                    ((ITextInteractive)ws.Target).GetUnderlineColor(out r, out g, out b, out a);
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
                    ((ITextInteractive)ws.Target).SetUnderlineColor(r, g, b, a);
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
                    _ret_var = ((ITextInteractive)ws.Target).GetUnderlineHeight();
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
                    ((ITextInteractive)ws.Target).SetUnderlineHeight(height);
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
                    ((ITextInteractive)ws.Target).GetUnderlineDashedColor(out r, out g, out b, out a);
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
                    ((ITextInteractive)ws.Target).SetUnderlineDashedColor(r, g, b, a);
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
                    _ret_var = ((ITextInteractive)ws.Target).GetUnderlineDashedWidth();
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
                    ((ITextInteractive)ws.Target).SetUnderlineDashedWidth(width);
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
                    _ret_var = ((ITextInteractive)ws.Target).GetUnderlineDashedGap();
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
                    ((ITextInteractive)ws.Target).SetUnderlineDashedGap(gap);
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
                    ((ITextInteractive)ws.Target).GetUnderline2Color(out r, out g, out b, out a);
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
                    ((ITextInteractive)ws.Target).SetUnderline2Color(r, g, b, a);
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
                    _ret_var = ((ITextInteractive)ws.Target).GetStrikethroughType();
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
                    ((ITextInteractive)ws.Target).SetStrikethroughType(type);
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
                    ((ITextInteractive)ws.Target).GetStrikethroughColor(out r, out g, out b, out a);
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
                    ((ITextInteractive)ws.Target).SetStrikethroughColor(r, g, b, a);
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
                    _ret_var = ((ITextInteractive)ws.Target).GetEffectType();
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
                    ((ITextInteractive)ws.Target).SetEffectType(type);
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
                    ((ITextInteractive)ws.Target).GetOutlineColor(out r, out g, out b, out a);
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
                    ((ITextInteractive)ws.Target).SetOutlineColor(r, g, b, a);
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
                    _ret_var = ((ITextInteractive)ws.Target).GetShadowDirection();
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
                    ((ITextInteractive)ws.Target).SetShadowDirection(type);
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
                    ((ITextInteractive)ws.Target).GetShadowColor(out r, out g, out b, out a);
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
                    ((ITextInteractive)ws.Target).SetShadowColor(r, g, b, a);
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
                    ((ITextInteractive)ws.Target).GetGlowColor(out r, out g, out b, out a);
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
                    ((ITextInteractive)ws.Target).SetGlowColor(r, g, b, a);
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
                    ((ITextInteractive)ws.Target).GetGlow2Color(out r, out g, out b, out a);
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
                    ((ITextInteractive)ws.Target).SetGlow2Color(r, g, b, a);
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
                    _ret_var = ((ITextInteractive)ws.Target).GetGfxFilter();
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
                    ((ITextInteractive)ws.Target).SetGfxFilter(code);
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

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

#if EFL_BETA
#pragma warning disable CS1591
public static class EflITextInteractiveConcrete_ExtensionMethods {
    public static Efl.BindableProperty<bool> SelectionAllowed<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.ITextInteractive, T>magic = null) where T : Efl.ITextInteractive {
        return new Efl.BindableProperty<bool>("selection_allowed", fac);
    }

    
    public static Efl.BindableProperty<bool> Editable<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.ITextInteractive, T>magic = null) where T : Efl.ITextInteractive {
        return new Efl.BindableProperty<bool>("editable", fac);
    }

    
    
    public static Efl.BindableProperty<System.String> FontSource<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.ITextInteractive, T>magic = null) where T : Efl.ITextInteractive {
        return new Efl.BindableProperty<System.String>("font_source", fac);
    }

    public static Efl.BindableProperty<System.String> FontFallbacks<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.ITextInteractive, T>magic = null) where T : Efl.ITextInteractive {
        return new Efl.BindableProperty<System.String>("font_fallbacks", fac);
    }

    public static Efl.BindableProperty<Efl.TextFontWeight> FontWeight<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.ITextInteractive, T>magic = null) where T : Efl.ITextInteractive {
        return new Efl.BindableProperty<Efl.TextFontWeight>("font_weight", fac);
    }

    public static Efl.BindableProperty<Efl.TextFontSlant> FontSlant<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.ITextInteractive, T>magic = null) where T : Efl.ITextInteractive {
        return new Efl.BindableProperty<Efl.TextFontSlant>("font_slant", fac);
    }

    public static Efl.BindableProperty<Efl.TextFontWidth> FontWidth<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.ITextInteractive, T>magic = null) where T : Efl.ITextInteractive {
        return new Efl.BindableProperty<Efl.TextFontWidth>("font_width", fac);
    }

    public static Efl.BindableProperty<System.String> FontLang<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.ITextInteractive, T>magic = null) where T : Efl.ITextInteractive {
        return new Efl.BindableProperty<System.String>("font_lang", fac);
    }

    public static Efl.BindableProperty<Efl.TextFontBitmapScalable> FontBitmapScalable<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.ITextInteractive, T>magic = null) where T : Efl.ITextInteractive {
        return new Efl.BindableProperty<Efl.TextFontBitmapScalable>("font_bitmap_scalable", fac);
    }

    public static Efl.BindableProperty<double> Ellipsis<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.ITextInteractive, T>magic = null) where T : Efl.ITextInteractive {
        return new Efl.BindableProperty<double>("ellipsis", fac);
    }

    public static Efl.BindableProperty<Efl.TextFormatWrap> Wrap<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.ITextInteractive, T>magic = null) where T : Efl.ITextInteractive {
        return new Efl.BindableProperty<Efl.TextFormatWrap>("wrap", fac);
    }

    public static Efl.BindableProperty<bool> Multiline<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.ITextInteractive, T>magic = null) where T : Efl.ITextInteractive {
        return new Efl.BindableProperty<bool>("multiline", fac);
    }

    public static Efl.BindableProperty<Efl.TextFormatHorizontalAlignmentAutoType> HalignAutoType<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.ITextInteractive, T>magic = null) where T : Efl.ITextInteractive {
        return new Efl.BindableProperty<Efl.TextFormatHorizontalAlignmentAutoType>("halign_auto_type", fac);
    }

    public static Efl.BindableProperty<double> Halign<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.ITextInteractive, T>magic = null) where T : Efl.ITextInteractive {
        return new Efl.BindableProperty<double>("halign", fac);
    }

    public static Efl.BindableProperty<double> Valign<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.ITextInteractive, T>magic = null) where T : Efl.ITextInteractive {
        return new Efl.BindableProperty<double>("valign", fac);
    }

    public static Efl.BindableProperty<double> Linegap<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.ITextInteractive, T>magic = null) where T : Efl.ITextInteractive {
        return new Efl.BindableProperty<double>("linegap", fac);
    }

    public static Efl.BindableProperty<double> Linerelgap<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.ITextInteractive, T>magic = null) where T : Efl.ITextInteractive {
        return new Efl.BindableProperty<double>("linerelgap", fac);
    }

    public static Efl.BindableProperty<int> Tabstops<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.ITextInteractive, T>magic = null) where T : Efl.ITextInteractive {
        return new Efl.BindableProperty<int>("tabstops", fac);
    }

    public static Efl.BindableProperty<bool> Password<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.ITextInteractive, T>magic = null) where T : Efl.ITextInteractive {
        return new Efl.BindableProperty<bool>("password", fac);
    }

    public static Efl.BindableProperty<System.String> ReplacementChar<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.ITextInteractive, T>magic = null) where T : Efl.ITextInteractive {
        return new Efl.BindableProperty<System.String>("replacement_char", fac);
    }

    
    public static Efl.BindableProperty<Efl.TextStyleBackingType> BackingType<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.ITextInteractive, T>magic = null) where T : Efl.ITextInteractive {
        return new Efl.BindableProperty<Efl.TextStyleBackingType>("backing_type", fac);
    }

    
    public static Efl.BindableProperty<Efl.TextStyleUnderlineType> UnderlineType<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.ITextInteractive, T>magic = null) where T : Efl.ITextInteractive {
        return new Efl.BindableProperty<Efl.TextStyleUnderlineType>("underline_type", fac);
    }

    
    public static Efl.BindableProperty<double> UnderlineHeight<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.ITextInteractive, T>magic = null) where T : Efl.ITextInteractive {
        return new Efl.BindableProperty<double>("underline_height", fac);
    }

    
    public static Efl.BindableProperty<int> UnderlineDashedWidth<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.ITextInteractive, T>magic = null) where T : Efl.ITextInteractive {
        return new Efl.BindableProperty<int>("underline_dashed_width", fac);
    }

    public static Efl.BindableProperty<int> UnderlineDashedGap<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.ITextInteractive, T>magic = null) where T : Efl.ITextInteractive {
        return new Efl.BindableProperty<int>("underline_dashed_gap", fac);
    }

    
    public static Efl.BindableProperty<Efl.TextStyleStrikethroughType> StrikethroughType<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.ITextInteractive, T>magic = null) where T : Efl.ITextInteractive {
        return new Efl.BindableProperty<Efl.TextStyleStrikethroughType>("strikethrough_type", fac);
    }

    
    public static Efl.BindableProperty<Efl.TextStyleEffectType> EffectType<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.ITextInteractive, T>magic = null) where T : Efl.ITextInteractive {
        return new Efl.BindableProperty<Efl.TextStyleEffectType>("effect_type", fac);
    }

    
    public static Efl.BindableProperty<Efl.TextStyleShadowDirection> ShadowDirection<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.ITextInteractive, T>magic = null) where T : Efl.ITextInteractive {
        return new Efl.BindableProperty<Efl.TextStyleShadowDirection>("shadow_direction", fac);
    }

    
    
    
    public static Efl.BindableProperty<System.String> GfxFilter<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.ITextInteractive, T>magic = null) where T : Efl.ITextInteractive {
        return new Efl.BindableProperty<System.String>("gfx_filter", fac);
    }

}
#pragma warning restore CS1591
#endif
