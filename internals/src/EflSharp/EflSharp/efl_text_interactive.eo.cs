#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { 
/// <summary>This is an interface interactive text inputs should implement</summary>
[TextInteractiveNativeInherit]
public interface TextInteractive : 
   Efl.Text ,
   Efl.TextFont ,
   Efl.TextFormat ,
   Efl.TextStyle ,
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>Whether or not selection is allowed on this object</summary>
/// <returns><c>true</c> if enabled, <c>false</c> otherwise</returns>
bool GetSelectionAllowed();
   /// <summary>Whether or not selection is allowed on this object</summary>
/// <param name="allowed"><c>true</c> if enabled, <c>false</c> otherwise</param>
/// <returns></returns>
 void SetSelectionAllowed( bool allowed);
   /// <summary>The cursors used for selection handling.
/// If the cursors are equal there&apos;s no selection.
/// 
/// You are allowed to retain and modify them. Modifying them modifies the selection of the object.</summary>
/// <param name="start">The start of the selection</param>
/// <param name="end">The end of the selection</param>
/// <returns></returns>
 void GetSelectionCursors( out Efl.TextCursorCursor start,  out Efl.TextCursorCursor end);
   /// <summary>Whether the entry is editable.
/// By default text interactives are editable. However setting this property to <c>false</c> will make it so that key input will be disregarded.</summary>
/// <returns>If <c>true</c>, user input will be inserted in the entry, if not, the entry is read-only and no user input is allowed.</returns>
bool GetEditable();
   /// <summary>Whether the entry is editable.
/// By default text interactives are editable. However setting this property to <c>false</c> will make it so that key input will be disregarded.</summary>
/// <param name="editable">If <c>true</c>, user input will be inserted in the entry, if not, the entry is read-only and no user input is allowed.</param>
/// <returns></returns>
 void SetEditable( bool editable);
   /// <summary>Clears the selection.</summary>
/// <returns></returns>
 void SelectNone();
                     /// <summary>The selection on the object has changed. Query using <see cref="Efl.TextInteractive.GetSelectionCursors"/></summary>
   event EventHandler SelectionChangedEvt;
   /// <summary>Whether or not selection is allowed on this object</summary>
/// <value><c>true</c> if enabled, <c>false</c> otherwise</value>
   bool SelectionAllowed {
      get ;
      set ;
   }
   /// <summary>Whether the entry is editable.
/// By default text interactives are editable. However setting this property to <c>false</c> will make it so that key input will be disregarded.</summary>
/// <value>If <c>true</c>, user input will be inserted in the entry, if not, the entry is read-only and no user input is allowed.</value>
   bool Editable {
      get ;
      set ;
   }
}
/// <summary>This is an interface interactive text inputs should implement</summary>
sealed public class TextInteractiveConcrete : 

TextInteractive
   , Efl.Text, Efl.TextFont, Efl.TextFormat, Efl.TextStyle
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (TextInteractiveConcrete))
            return Efl.TextInteractiveNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
      }
   }
   private EventHandlerList eventHandlers = new EventHandlerList();
   private  System.IntPtr handle;
   ///<summary>Pointer to the native instance.</summary>
   public System.IntPtr NativeHandle {
      get { return handle; }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
      efl_text_interactive_interface_get();
   ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
   public TextInteractiveConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~TextInteractiveConcrete()
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
   public static TextInteractiveConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new TextInteractiveConcrete(obj.NativeHandle);
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
   private readonly object eventLock = new object();
   private Dictionary<string, int> event_cb_count = new Dictionary<string, int>();
   private bool add_cpp_event_handler(string lib, string key, Efl.EventCb evt_delegate) {
      int event_count = 0;
      if (!event_cb_count.TryGetValue(key, out event_count))
         event_cb_count[key] = event_count;
      if (event_count == 0) {
         IntPtr desc = Efl.EventDescription.GetNative(lib, key);
         if (desc == IntPtr.Zero) {
            Eina.Log.Error($"Failed to get native event {key}");
            return false;
         }
          bool result = Efl.Eo.Globals.efl_event_callback_priority_add(handle, desc, 0, evt_delegate, System.IntPtr.Zero);
         if (!result) {
            Eina.Log.Error($"Failed to add event proxy for event {key}");
            return false;
         }
         Eina.Error.RaiseIfUnhandledException();
      } 
      event_cb_count[key]++;
      return true;
   }
   private bool remove_cpp_event_handler(string key, Efl.EventCb evt_delegate) {
      int event_count = 0;
      if (!event_cb_count.TryGetValue(key, out event_count))
         event_cb_count[key] = event_count;
      if (event_count == 1) {
         IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
         if (desc == IntPtr.Zero) {
            Eina.Log.Error($"Failed to get native event {key}");
            return false;
         }
         bool result = Efl.Eo.Globals.efl_event_callback_del(handle, desc, evt_delegate, System.IntPtr.Zero);
         if (!result) {
            Eina.Log.Error($"Failed to remove event proxy for event {key}");
            return false;
         }
         Eina.Error.RaiseIfUnhandledException();
      } else if (event_count == 0) {
         Eina.Log.Error($"Trying to remove proxy for event {key} when there is nothing registered.");
         return false;
      } 
      event_cb_count[key]--;
      return true;
   }
private static object SelectionChangedEvtKey = new object();
   /// <summary>The selection on the object has changed. Query using <see cref="Efl.TextInteractive.GetSelectionCursors"/></summary>
   public event EventHandler SelectionChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_TEXT_INTERACTIVE_EVENT_SELECTION_CHANGED";
            if (add_cpp_event_handler(efl.Libs.Elementary, key, this.evt_SelectionChangedEvt_delegate)) {
               eventHandlers.AddHandler(SelectionChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_TEXT_INTERACTIVE_EVENT_SELECTION_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_SelectionChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(SelectionChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event SelectionChangedEvt.</summary>
   public void On_SelectionChangedEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[SelectionChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_SelectionChangedEvt_delegate;
   private void on_SelectionChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_SelectionChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

    void register_event_proxies()
   {
      evt_SelectionChangedEvt_delegate = new Efl.EventCb(on_SelectionChangedEvt_NativeCallback);
   }
   /// <summary>Whether or not selection is allowed on this object</summary>
   /// <returns><c>true</c> if enabled, <c>false</c> otherwise</returns>
   public bool GetSelectionAllowed() {
       var _ret_var = Efl.TextInteractiveNativeInherit.efl_text_interactive_selection_allowed_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Whether or not selection is allowed on this object</summary>
   /// <param name="allowed"><c>true</c> if enabled, <c>false</c> otherwise</param>
   /// <returns></returns>
   public  void SetSelectionAllowed( bool allowed) {
                         Efl.TextInteractiveNativeInherit.efl_text_interactive_selection_allowed_set_ptr.Value.Delegate(this.NativeHandle, allowed);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>The cursors used for selection handling.
   /// If the cursors are equal there&apos;s no selection.
   /// 
   /// You are allowed to retain and modify them. Modifying them modifies the selection of the object.</summary>
   /// <param name="start">The start of the selection</param>
   /// <param name="end">The end of the selection</param>
   /// <returns></returns>
   public  void GetSelectionCursors( out Efl.TextCursorCursor start,  out Efl.TextCursorCursor end) {
                                           Efl.TextInteractiveNativeInherit.efl_text_interactive_selection_cursors_get_ptr.Value.Delegate(this.NativeHandle, out start,  out end);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Whether the entry is editable.
   /// By default text interactives are editable. However setting this property to <c>false</c> will make it so that key input will be disregarded.</summary>
   /// <returns>If <c>true</c>, user input will be inserted in the entry, if not, the entry is read-only and no user input is allowed.</returns>
   public bool GetEditable() {
       var _ret_var = Efl.TextInteractiveNativeInherit.efl_text_interactive_editable_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Whether the entry is editable.
   /// By default text interactives are editable. However setting this property to <c>false</c> will make it so that key input will be disregarded.</summary>
   /// <param name="editable">If <c>true</c>, user input will be inserted in the entry, if not, the entry is read-only and no user input is allowed.</param>
   /// <returns></returns>
   public  void SetEditable( bool editable) {
                         Efl.TextInteractiveNativeInherit.efl_text_interactive_editable_set_ptr.Value.Delegate(this.NativeHandle, editable);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Clears the selection.</summary>
   /// <returns></returns>
   public  void SelectNone() {
       Efl.TextInteractiveNativeInherit.efl_text_interactive_select_none_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
       }
   /// <summary>Retrieves the text string currently being displayed by the given text object.
   /// Do not free() the return value.
   /// 
   /// See also <see cref="Efl.Text.GetText"/>.</summary>
   /// <returns>Text string to display on it.</returns>
   public  System.String GetText() {
       var _ret_var = Efl.TextNativeInherit.efl_text_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Sets the text string to be displayed by the given text object.
   /// See also <see cref="Efl.Text.GetText"/>.</summary>
   /// <param name="text">Text string to display on it.</param>
   /// <returns></returns>
   public  void SetText(  System.String text) {
                         Efl.TextNativeInherit.efl_text_set_ptr.Value.Delegate(this.NativeHandle, text);
      Eina.Error.RaiseIfUnhandledException();
                   }
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
   public  void GetFont( out  System.String font,  out Efl.Font.Size size) {
                                           Efl.TextFontNativeInherit.efl_text_font_get_ptr.Value.Delegate(this.NativeHandle, out font,  out size);
      Eina.Error.RaiseIfUnhandledException();
                               }
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
   public  void SetFont(  System.String font,  Efl.Font.Size size) {
                                           Efl.TextFontNativeInherit.efl_text_font_set_ptr.Value.Delegate(this.NativeHandle, font,  size);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Get the font file&apos;s path which is being used on a given text object.
   /// See <see cref="Efl.TextFont.GetFont"/> for more details.
   /// 1.20</summary>
   /// <returns>The font file&apos;s path.
   /// 1.20</returns>
   public  System.String GetFontSource() {
       var _ret_var = Efl.TextFontNativeInherit.efl_text_font_source_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Set the font (source) file to be used on a given text object.
   /// This function allows the font file to be explicitly set for a given text object, overriding system lookup, which will first occur in the given file&apos;s contents.
   /// 
   /// See also <see cref="Efl.TextFont.GetFont"/>.
   /// 1.20</summary>
   /// <param name="font_source">The font file&apos;s path.
   /// 1.20</param>
   /// <returns></returns>
   public  void SetFontSource(  System.String font_source) {
                         Efl.TextFontNativeInherit.efl_text_font_source_set_ptr.Value.Delegate(this.NativeHandle, font_source);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Comma-separated list of font fallbacks
   /// Will be used in case the primary font isn&apos;t available.
   /// 1.20</summary>
   /// <returns>Font name fallbacks
   /// 1.20</returns>
   public  System.String GetFontFallbacks() {
       var _ret_var = Efl.TextFontNativeInherit.efl_text_font_fallbacks_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Comma-separated list of font fallbacks
   /// Will be used in case the primary font isn&apos;t available.
   /// 1.20</summary>
   /// <param name="font_fallbacks">Font name fallbacks
   /// 1.20</param>
   /// <returns></returns>
   public  void SetFontFallbacks(  System.String font_fallbacks) {
                         Efl.TextFontNativeInherit.efl_text_font_fallbacks_set_ptr.Value.Delegate(this.NativeHandle, font_fallbacks);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Type of weight of the displayed font
   /// Default is <see cref="Efl.TextFontWeight.Normal"/>.
   /// 1.20</summary>
   /// <returns>Font weight
   /// 1.20</returns>
   public Efl.TextFontWeight GetFontWeight() {
       var _ret_var = Efl.TextFontNativeInherit.efl_text_font_weight_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Type of weight of the displayed font
   /// Default is <see cref="Efl.TextFontWeight.Normal"/>.
   /// 1.20</summary>
   /// <param name="font_weight">Font weight
   /// 1.20</param>
   /// <returns></returns>
   public  void SetFontWeight( Efl.TextFontWeight font_weight) {
                         Efl.TextFontNativeInherit.efl_text_font_weight_set_ptr.Value.Delegate(this.NativeHandle, font_weight);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Type of slant of the displayed font
   /// Default is <see cref="Efl.TextFontSlant.Normal"/>.
   /// 1.20</summary>
   /// <returns>Font slant
   /// 1.20</returns>
   public Efl.TextFontSlant GetFontSlant() {
       var _ret_var = Efl.TextFontNativeInherit.efl_text_font_slant_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Type of slant of the displayed font
   /// Default is <see cref="Efl.TextFontSlant.Normal"/>.
   /// 1.20</summary>
   /// <param name="style">Font slant
   /// 1.20</param>
   /// <returns></returns>
   public  void SetFontSlant( Efl.TextFontSlant style) {
                         Efl.TextFontNativeInherit.efl_text_font_slant_set_ptr.Value.Delegate(this.NativeHandle, style);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Type of width of the displayed font
   /// Default is <see cref="Efl.TextFontWidth.Normal"/>.
   /// 1.20</summary>
   /// <returns>Font width
   /// 1.20</returns>
   public Efl.TextFontWidth GetFontWidth() {
       var _ret_var = Efl.TextFontNativeInherit.efl_text_font_width_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Type of width of the displayed font
   /// Default is <see cref="Efl.TextFontWidth.Normal"/>.
   /// 1.20</summary>
   /// <param name="width">Font width
   /// 1.20</param>
   /// <returns></returns>
   public  void SetFontWidth( Efl.TextFontWidth width) {
                         Efl.TextFontNativeInherit.efl_text_font_width_set_ptr.Value.Delegate(this.NativeHandle, width);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Specific language of the displayed font
   /// This is used to lookup fonts suitable to the specified language, as well as helping the font shaper backend. The language <c>lang</c> can be either a code e.g &quot;en_US&quot;, &quot;auto&quot; to use the system locale, or &quot;none&quot;.
   /// 1.20</summary>
   /// <returns>Language
   /// 1.20</returns>
   public  System.String GetFontLang() {
       var _ret_var = Efl.TextFontNativeInherit.efl_text_font_lang_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Specific language of the displayed font
   /// This is used to lookup fonts suitable to the specified language, as well as helping the font shaper backend. The language <c>lang</c> can be either a code e.g &quot;en_US&quot;, &quot;auto&quot; to use the system locale, or &quot;none&quot;.
   /// 1.20</summary>
   /// <param name="lang">Language
   /// 1.20</param>
   /// <returns></returns>
   public  void SetFontLang(  System.String lang) {
                         Efl.TextFontNativeInherit.efl_text_font_lang_set_ptr.Value.Delegate(this.NativeHandle, lang);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>The bitmap fonts have fixed size glyphs for several available sizes. Basically, it is not scalable. But, it needs to be scalable for some use cases. (ex. colorful emoji fonts)
   /// Default is <see cref="Efl.TextFontBitmapScalable.None"/>.
   /// 1.20</summary>
   /// <returns>Scalable
   /// 1.20</returns>
   public Efl.TextFontBitmapScalable GetFontBitmapScalable() {
       var _ret_var = Efl.TextFontNativeInherit.efl_text_font_bitmap_scalable_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>The bitmap fonts have fixed size glyphs for several available sizes. Basically, it is not scalable. But, it needs to be scalable for some use cases. (ex. colorful emoji fonts)
   /// Default is <see cref="Efl.TextFontBitmapScalable.None"/>.
   /// 1.20</summary>
   /// <param name="scalable">Scalable
   /// 1.20</param>
   /// <returns></returns>
   public  void SetFontBitmapScalable( Efl.TextFontBitmapScalable scalable) {
                         Efl.TextFontNativeInherit.efl_text_font_bitmap_scalable_set_ptr.Value.Delegate(this.NativeHandle, scalable);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Ellipsis value (number from -1.0 to 1.0)
   /// 1.20</summary>
   /// <returns>Ellipsis value
   /// 1.20</returns>
   public double GetEllipsis() {
       var _ret_var = Efl.TextFormatNativeInherit.efl_text_ellipsis_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Ellipsis value (number from -1.0 to 1.0)
   /// 1.20</summary>
   /// <param name="value">Ellipsis value
   /// 1.20</param>
   /// <returns></returns>
   public  void SetEllipsis( double value) {
                         Efl.TextFormatNativeInherit.efl_text_ellipsis_set_ptr.Value.Delegate(this.NativeHandle, value);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Wrap mode for use in the text
   /// 1.20</summary>
   /// <returns>Wrap mode
   /// 1.20</returns>
   public Efl.TextFormatWrap GetWrap() {
       var _ret_var = Efl.TextFormatNativeInherit.efl_text_wrap_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Wrap mode for use in the text
   /// 1.20</summary>
   /// <param name="wrap">Wrap mode
   /// 1.20</param>
   /// <returns></returns>
   public  void SetWrap( Efl.TextFormatWrap wrap) {
                         Efl.TextFormatNativeInherit.efl_text_wrap_set_ptr.Value.Delegate(this.NativeHandle, wrap);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Multiline is enabled or not
   /// 1.20</summary>
   /// <returns><c>true</c> if multiline is enabled, <c>false</c> otherwise
   /// 1.20</returns>
   public bool GetMultiline() {
       var _ret_var = Efl.TextFormatNativeInherit.efl_text_multiline_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Multiline is enabled or not
   /// 1.20</summary>
   /// <param name="enabled"><c>true</c> if multiline is enabled, <c>false</c> otherwise
   /// 1.20</param>
   /// <returns></returns>
   public  void SetMultiline( bool enabled) {
                         Efl.TextFormatNativeInherit.efl_text_multiline_set_ptr.Value.Delegate(this.NativeHandle, enabled);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Horizontal alignment of text
   /// 1.20</summary>
   /// <returns>Alignment type
   /// 1.20</returns>
   public Efl.TextFormatHorizontalAlignmentAutoType GetHalignAutoType() {
       var _ret_var = Efl.TextFormatNativeInherit.efl_text_halign_auto_type_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Horizontal alignment of text
   /// 1.20</summary>
   /// <param name="value">Alignment type
   /// 1.20</param>
   /// <returns></returns>
   public  void SetHalignAutoType( Efl.TextFormatHorizontalAlignmentAutoType value) {
                         Efl.TextFormatNativeInherit.efl_text_halign_auto_type_set_ptr.Value.Delegate(this.NativeHandle, value);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Horizontal alignment of text
   /// 1.20</summary>
   /// <returns>Horizontal alignment value
   /// 1.20</returns>
   public double GetHalign() {
       var _ret_var = Efl.TextFormatNativeInherit.efl_text_halign_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Horizontal alignment of text
   /// 1.20</summary>
   /// <param name="value">Horizontal alignment value
   /// 1.20</param>
   /// <returns></returns>
   public  void SetHalign( double value) {
                         Efl.TextFormatNativeInherit.efl_text_halign_set_ptr.Value.Delegate(this.NativeHandle, value);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Vertical alignment of text
   /// 1.20</summary>
   /// <returns>Vertical alignment value
   /// 1.20</returns>
   public double GetValign() {
       var _ret_var = Efl.TextFormatNativeInherit.efl_text_valign_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Vertical alignment of text
   /// 1.20</summary>
   /// <param name="value">Vertical alignment value
   /// 1.20</param>
   /// <returns></returns>
   public  void SetValign( double value) {
                         Efl.TextFormatNativeInherit.efl_text_valign_set_ptr.Value.Delegate(this.NativeHandle, value);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Minimal line gap (top and bottom) for each line in the text
   /// <c>value</c> is absolute size.
   /// 1.20</summary>
   /// <returns>Line gap value
   /// 1.20</returns>
   public double GetLinegap() {
       var _ret_var = Efl.TextFormatNativeInherit.efl_text_linegap_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Minimal line gap (top and bottom) for each line in the text
   /// <c>value</c> is absolute size.
   /// 1.20</summary>
   /// <param name="value">Line gap value
   /// 1.20</param>
   /// <returns></returns>
   public  void SetLinegap( double value) {
                         Efl.TextFormatNativeInherit.efl_text_linegap_set_ptr.Value.Delegate(this.NativeHandle, value);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Relative line gap (top and bottom) for each line in the text
   /// The original line gap value is multiplied by <c>value</c>.
   /// 1.20</summary>
   /// <returns>Relative line gap value
   /// 1.20</returns>
   public double GetLinerelgap() {
       var _ret_var = Efl.TextFormatNativeInherit.efl_text_linerelgap_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Relative line gap (top and bottom) for each line in the text
   /// The original line gap value is multiplied by <c>value</c>.
   /// 1.20</summary>
   /// <param name="value">Relative line gap value
   /// 1.20</param>
   /// <returns></returns>
   public  void SetLinerelgap( double value) {
                         Efl.TextFormatNativeInherit.efl_text_linerelgap_set_ptr.Value.Delegate(this.NativeHandle, value);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Tabstops value
   /// 1.20</summary>
   /// <returns>Tapstops value
   /// 1.20</returns>
   public  int GetTabstops() {
       var _ret_var = Efl.TextFormatNativeInherit.efl_text_tabstops_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Tabstops value
   /// 1.20</summary>
   /// <param name="value">Tapstops value
   /// 1.20</param>
   /// <returns></returns>
   public  void SetTabstops(  int value) {
                         Efl.TextFormatNativeInherit.efl_text_tabstops_set_ptr.Value.Delegate(this.NativeHandle, value);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Whether text is a password
   /// 1.20</summary>
   /// <returns><c>true</c> if the text is a password, <c>false</c> otherwise
   /// 1.20</returns>
   public bool GetPassword() {
       var _ret_var = Efl.TextFormatNativeInherit.efl_text_password_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Whether text is a password
   /// 1.20</summary>
   /// <param name="enabled"><c>true</c> if the text is a password, <c>false</c> otherwise
   /// 1.20</param>
   /// <returns></returns>
   public  void SetPassword( bool enabled) {
                         Efl.TextFormatNativeInherit.efl_text_password_set_ptr.Value.Delegate(this.NativeHandle, enabled);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>The character used to replace characters that can&apos;t be displayed
   /// Currently only used to replace characters if <see cref="Efl.TextFormat.Password"/> is enabled.
   /// 1.20</summary>
   /// <returns>Replacement character
   /// 1.20</returns>
   public  System.String GetReplacementChar() {
       var _ret_var = Efl.TextFormatNativeInherit.efl_text_replacement_char_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>The character used to replace characters that can&apos;t be displayed
   /// Currently only used to replace characters if <see cref="Efl.TextFormat.Password"/> is enabled.
   /// 1.20</summary>
   /// <param name="repch">Replacement character
   /// 1.20</param>
   /// <returns></returns>
   public  void SetReplacementChar(  System.String repch) {
                         Efl.TextFormatNativeInherit.efl_text_replacement_char_set_ptr.Value.Delegate(this.NativeHandle, repch);
      Eina.Error.RaiseIfUnhandledException();
                   }
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
   public  void GetNormalColor( out  byte r,  out  byte g,  out  byte b,  out  byte a) {
                                                                               Efl.TextStyleNativeInherit.efl_text_normal_color_get_ptr.Value.Delegate(this.NativeHandle, out r,  out g,  out b,  out a);
      Eina.Error.RaiseIfUnhandledException();
                                                       }
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
   public  void SetNormalColor(  byte r,   byte g,   byte b,   byte a) {
                                                                               Efl.TextStyleNativeInherit.efl_text_normal_color_set_ptr.Value.Delegate(this.NativeHandle, r,  g,  b,  a);
      Eina.Error.RaiseIfUnhandledException();
                                                       }
   /// <summary>Enable or disable backing type
   /// 1.20</summary>
   /// <returns>Backing type
   /// 1.20</returns>
   public Efl.TextStyleBackingType GetBackingType() {
       var _ret_var = Efl.TextStyleNativeInherit.efl_text_backing_type_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Enable or disable backing type
   /// 1.20</summary>
   /// <param name="type">Backing type
   /// 1.20</param>
   /// <returns></returns>
   public  void SetBackingType( Efl.TextStyleBackingType type) {
                         Efl.TextStyleNativeInherit.efl_text_backing_type_set_ptr.Value.Delegate(this.NativeHandle, type);
      Eina.Error.RaiseIfUnhandledException();
                   }
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
   public  void GetBackingColor( out  byte r,  out  byte g,  out  byte b,  out  byte a) {
                                                                               Efl.TextStyleNativeInherit.efl_text_backing_color_get_ptr.Value.Delegate(this.NativeHandle, out r,  out g,  out b,  out a);
      Eina.Error.RaiseIfUnhandledException();
                                                       }
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
   public  void SetBackingColor(  byte r,   byte g,   byte b,   byte a) {
                                                                               Efl.TextStyleNativeInherit.efl_text_backing_color_set_ptr.Value.Delegate(this.NativeHandle, r,  g,  b,  a);
      Eina.Error.RaiseIfUnhandledException();
                                                       }
   /// <summary>Sets an underline style on the text
   /// 1.20</summary>
   /// <returns>Underline type
   /// 1.20</returns>
   public Efl.TextStyleUnderlineType GetUnderlineType() {
       var _ret_var = Efl.TextStyleNativeInherit.efl_text_underline_type_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Sets an underline style on the text
   /// 1.20</summary>
   /// <param name="type">Underline type
   /// 1.20</param>
   /// <returns></returns>
   public  void SetUnderlineType( Efl.TextStyleUnderlineType type) {
                         Efl.TextStyleNativeInherit.efl_text_underline_type_set_ptr.Value.Delegate(this.NativeHandle, type);
      Eina.Error.RaiseIfUnhandledException();
                   }
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
   public  void GetUnderlineColor( out  byte r,  out  byte g,  out  byte b,  out  byte a) {
                                                                               Efl.TextStyleNativeInherit.efl_text_underline_color_get_ptr.Value.Delegate(this.NativeHandle, out r,  out g,  out b,  out a);
      Eina.Error.RaiseIfUnhandledException();
                                                       }
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
   public  void SetUnderlineColor(  byte r,   byte g,   byte b,   byte a) {
                                                                               Efl.TextStyleNativeInherit.efl_text_underline_color_set_ptr.Value.Delegate(this.NativeHandle, r,  g,  b,  a);
      Eina.Error.RaiseIfUnhandledException();
                                                       }
   /// <summary>Height of underline style
   /// 1.20</summary>
   /// <returns>Height
   /// 1.20</returns>
   public double GetUnderlineHeight() {
       var _ret_var = Efl.TextStyleNativeInherit.efl_text_underline_height_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Height of underline style
   /// 1.20</summary>
   /// <param name="height">Height
   /// 1.20</param>
   /// <returns></returns>
   public  void SetUnderlineHeight( double height) {
                         Efl.TextStyleNativeInherit.efl_text_underline_height_set_ptr.Value.Delegate(this.NativeHandle, height);
      Eina.Error.RaiseIfUnhandledException();
                   }
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
   public  void GetUnderlineDashedColor( out  byte r,  out  byte g,  out  byte b,  out  byte a) {
                                                                               Efl.TextStyleNativeInherit.efl_text_underline_dashed_color_get_ptr.Value.Delegate(this.NativeHandle, out r,  out g,  out b,  out a);
      Eina.Error.RaiseIfUnhandledException();
                                                       }
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
   public  void SetUnderlineDashedColor(  byte r,   byte g,   byte b,   byte a) {
                                                                               Efl.TextStyleNativeInherit.efl_text_underline_dashed_color_set_ptr.Value.Delegate(this.NativeHandle, r,  g,  b,  a);
      Eina.Error.RaiseIfUnhandledException();
                                                       }
   /// <summary>Width of dashed underline style
   /// 1.20</summary>
   /// <returns>Width
   /// 1.20</returns>
   public  int GetUnderlineDashedWidth() {
       var _ret_var = Efl.TextStyleNativeInherit.efl_text_underline_dashed_width_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Width of dashed underline style
   /// 1.20</summary>
   /// <param name="width">Width
   /// 1.20</param>
   /// <returns></returns>
   public  void SetUnderlineDashedWidth(  int width) {
                         Efl.TextStyleNativeInherit.efl_text_underline_dashed_width_set_ptr.Value.Delegate(this.NativeHandle, width);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Gap of dashed underline style
   /// 1.20</summary>
   /// <returns>Gap
   /// 1.20</returns>
   public  int GetUnderlineDashedGap() {
       var _ret_var = Efl.TextStyleNativeInherit.efl_text_underline_dashed_gap_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Gap of dashed underline style
   /// 1.20</summary>
   /// <param name="gap">Gap
   /// 1.20</param>
   /// <returns></returns>
   public  void SetUnderlineDashedGap(  int gap) {
                         Efl.TextStyleNativeInherit.efl_text_underline_dashed_gap_set_ptr.Value.Delegate(this.NativeHandle, gap);
      Eina.Error.RaiseIfUnhandledException();
                   }
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
   public  void GetUnderline2Color( out  byte r,  out  byte g,  out  byte b,  out  byte a) {
                                                                               Efl.TextStyleNativeInherit.efl_text_underline2_color_get_ptr.Value.Delegate(this.NativeHandle, out r,  out g,  out b,  out a);
      Eina.Error.RaiseIfUnhandledException();
                                                       }
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
   public  void SetUnderline2Color(  byte r,   byte g,   byte b,   byte a) {
                                                                               Efl.TextStyleNativeInherit.efl_text_underline2_color_set_ptr.Value.Delegate(this.NativeHandle, r,  g,  b,  a);
      Eina.Error.RaiseIfUnhandledException();
                                                       }
   /// <summary>Type of strikethrough style
   /// 1.20</summary>
   /// <returns>Strikethrough type
   /// 1.20</returns>
   public Efl.TextStyleStrikethroughType GetStrikethroughType() {
       var _ret_var = Efl.TextStyleNativeInherit.efl_text_strikethrough_type_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Type of strikethrough style
   /// 1.20</summary>
   /// <param name="type">Strikethrough type
   /// 1.20</param>
   /// <returns></returns>
   public  void SetStrikethroughType( Efl.TextStyleStrikethroughType type) {
                         Efl.TextStyleNativeInherit.efl_text_strikethrough_type_set_ptr.Value.Delegate(this.NativeHandle, type);
      Eina.Error.RaiseIfUnhandledException();
                   }
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
   public  void GetStrikethroughColor( out  byte r,  out  byte g,  out  byte b,  out  byte a) {
                                                                               Efl.TextStyleNativeInherit.efl_text_strikethrough_color_get_ptr.Value.Delegate(this.NativeHandle, out r,  out g,  out b,  out a);
      Eina.Error.RaiseIfUnhandledException();
                                                       }
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
   public  void SetStrikethroughColor(  byte r,   byte g,   byte b,   byte a) {
                                                                               Efl.TextStyleNativeInherit.efl_text_strikethrough_color_set_ptr.Value.Delegate(this.NativeHandle, r,  g,  b,  a);
      Eina.Error.RaiseIfUnhandledException();
                                                       }
   /// <summary>Type of effect used for the displayed text
   /// 1.20</summary>
   /// <returns>Effect type
   /// 1.20</returns>
   public Efl.TextStyleEffectType GetEffectType() {
       var _ret_var = Efl.TextStyleNativeInherit.efl_text_effect_type_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Type of effect used for the displayed text
   /// 1.20</summary>
   /// <param name="type">Effect type
   /// 1.20</param>
   /// <returns></returns>
   public  void SetEffectType( Efl.TextStyleEffectType type) {
                         Efl.TextStyleNativeInherit.efl_text_effect_type_set_ptr.Value.Delegate(this.NativeHandle, type);
      Eina.Error.RaiseIfUnhandledException();
                   }
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
   public  void GetOutlineColor( out  byte r,  out  byte g,  out  byte b,  out  byte a) {
                                                                               Efl.TextStyleNativeInherit.efl_text_outline_color_get_ptr.Value.Delegate(this.NativeHandle, out r,  out g,  out b,  out a);
      Eina.Error.RaiseIfUnhandledException();
                                                       }
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
   public  void SetOutlineColor(  byte r,   byte g,   byte b,   byte a) {
                                                                               Efl.TextStyleNativeInherit.efl_text_outline_color_set_ptr.Value.Delegate(this.NativeHandle, r,  g,  b,  a);
      Eina.Error.RaiseIfUnhandledException();
                                                       }
   /// <summary>Direction of shadow effect
   /// 1.20</summary>
   /// <returns>Shadow direction
   /// 1.20</returns>
   public Efl.TextStyleShadowDirection GetShadowDirection() {
       var _ret_var = Efl.TextStyleNativeInherit.efl_text_shadow_direction_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Direction of shadow effect
   /// 1.20</summary>
   /// <param name="type">Shadow direction
   /// 1.20</param>
   /// <returns></returns>
   public  void SetShadowDirection( Efl.TextStyleShadowDirection type) {
                         Efl.TextStyleNativeInherit.efl_text_shadow_direction_set_ptr.Value.Delegate(this.NativeHandle, type);
      Eina.Error.RaiseIfUnhandledException();
                   }
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
   public  void GetShadowColor( out  byte r,  out  byte g,  out  byte b,  out  byte a) {
                                                                               Efl.TextStyleNativeInherit.efl_text_shadow_color_get_ptr.Value.Delegate(this.NativeHandle, out r,  out g,  out b,  out a);
      Eina.Error.RaiseIfUnhandledException();
                                                       }
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
   public  void SetShadowColor(  byte r,   byte g,   byte b,   byte a) {
                                                                               Efl.TextStyleNativeInherit.efl_text_shadow_color_set_ptr.Value.Delegate(this.NativeHandle, r,  g,  b,  a);
      Eina.Error.RaiseIfUnhandledException();
                                                       }
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
   public  void GetGlowColor( out  byte r,  out  byte g,  out  byte b,  out  byte a) {
                                                                               Efl.TextStyleNativeInherit.efl_text_glow_color_get_ptr.Value.Delegate(this.NativeHandle, out r,  out g,  out b,  out a);
      Eina.Error.RaiseIfUnhandledException();
                                                       }
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
   public  void SetGlowColor(  byte r,   byte g,   byte b,   byte a) {
                                                                               Efl.TextStyleNativeInherit.efl_text_glow_color_set_ptr.Value.Delegate(this.NativeHandle, r,  g,  b,  a);
      Eina.Error.RaiseIfUnhandledException();
                                                       }
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
   public  void GetGlow2Color( out  byte r,  out  byte g,  out  byte b,  out  byte a) {
                                                                               Efl.TextStyleNativeInherit.efl_text_glow2_color_get_ptr.Value.Delegate(this.NativeHandle, out r,  out g,  out b,  out a);
      Eina.Error.RaiseIfUnhandledException();
                                                       }
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
   public  void SetGlow2Color(  byte r,   byte g,   byte b,   byte a) {
                                                                               Efl.TextStyleNativeInherit.efl_text_glow2_color_set_ptr.Value.Delegate(this.NativeHandle, r,  g,  b,  a);
      Eina.Error.RaiseIfUnhandledException();
                                                       }
   /// <summary>Program that applies a special filter
   /// See <see cref="Efl.Gfx.Filter"/>.
   /// 1.20</summary>
   /// <returns>Filter code
   /// 1.20</returns>
   public  System.String GetGfxFilter() {
       var _ret_var = Efl.TextStyleNativeInherit.efl_text_gfx_filter_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Program that applies a special filter
   /// See <see cref="Efl.Gfx.Filter"/>.
   /// 1.20</summary>
   /// <param name="code">Filter code
   /// 1.20</param>
   /// <returns></returns>
   public  void SetGfxFilter(  System.String code) {
                         Efl.TextStyleNativeInherit.efl_text_gfx_filter_set_ptr.Value.Delegate(this.NativeHandle, code);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Whether or not selection is allowed on this object</summary>
/// <value><c>true</c> if enabled, <c>false</c> otherwise</value>
   public bool SelectionAllowed {
      get { return GetSelectionAllowed(); }
      set { SetSelectionAllowed( value); }
   }
   /// <summary>Whether the entry is editable.
/// By default text interactives are editable. However setting this property to <c>false</c> will make it so that key input will be disregarded.</summary>
/// <value>If <c>true</c>, user input will be inserted in the entry, if not, the entry is read-only and no user input is allowed.</value>
   public bool Editable {
      get { return GetEditable(); }
      set { SetEditable( value); }
   }
   /// <summary>Get the font file&apos;s path which is being used on a given text object.
/// See <see cref="Efl.TextFont.GetFont"/> for more details.
/// 1.20</summary>
/// <value>The font file&apos;s path.
/// 1.20</value>
   public  System.String FontSource {
      get { return GetFontSource(); }
      set { SetFontSource( value); }
   }
   /// <summary>Comma-separated list of font fallbacks
/// Will be used in case the primary font isn&apos;t available.
/// 1.20</summary>
/// <value>Font name fallbacks
/// 1.20</value>
   public  System.String FontFallbacks {
      get { return GetFontFallbacks(); }
      set { SetFontFallbacks( value); }
   }
   /// <summary>Type of weight of the displayed font
/// Default is <see cref="Efl.TextFontWeight.Normal"/>.
/// 1.20</summary>
/// <value>Font weight
/// 1.20</value>
   public Efl.TextFontWeight FontWeight {
      get { return GetFontWeight(); }
      set { SetFontWeight( value); }
   }
   /// <summary>Type of slant of the displayed font
/// Default is <see cref="Efl.TextFontSlant.Normal"/>.
/// 1.20</summary>
/// <value>Font slant
/// 1.20</value>
   public Efl.TextFontSlant FontSlant {
      get { return GetFontSlant(); }
      set { SetFontSlant( value); }
   }
   /// <summary>Type of width of the displayed font
/// Default is <see cref="Efl.TextFontWidth.Normal"/>.
/// 1.20</summary>
/// <value>Font width
/// 1.20</value>
   public Efl.TextFontWidth FontWidth {
      get { return GetFontWidth(); }
      set { SetFontWidth( value); }
   }
   /// <summary>Specific language of the displayed font
/// This is used to lookup fonts suitable to the specified language, as well as helping the font shaper backend. The language <c>lang</c> can be either a code e.g &quot;en_US&quot;, &quot;auto&quot; to use the system locale, or &quot;none&quot;.
/// 1.20</summary>
/// <value>Language
/// 1.20</value>
   public  System.String FontLang {
      get { return GetFontLang(); }
      set { SetFontLang( value); }
   }
   /// <summary>The bitmap fonts have fixed size glyphs for several available sizes. Basically, it is not scalable. But, it needs to be scalable for some use cases. (ex. colorful emoji fonts)
/// Default is <see cref="Efl.TextFontBitmapScalable.None"/>.
/// 1.20</summary>
/// <value>Scalable
/// 1.20</value>
   public Efl.TextFontBitmapScalable FontBitmapScalable {
      get { return GetFontBitmapScalable(); }
      set { SetFontBitmapScalable( value); }
   }
   /// <summary>Ellipsis value (number from -1.0 to 1.0)
/// 1.20</summary>
/// <value>Ellipsis value
/// 1.20</value>
   public double Ellipsis {
      get { return GetEllipsis(); }
      set { SetEllipsis( value); }
   }
   /// <summary>Wrap mode for use in the text
/// 1.20</summary>
/// <value>Wrap mode
/// 1.20</value>
   public Efl.TextFormatWrap Wrap {
      get { return GetWrap(); }
      set { SetWrap( value); }
   }
   /// <summary>Multiline is enabled or not
/// 1.20</summary>
/// <value><c>true</c> if multiline is enabled, <c>false</c> otherwise
/// 1.20</value>
   public bool Multiline {
      get { return GetMultiline(); }
      set { SetMultiline( value); }
   }
   /// <summary>Horizontal alignment of text
/// 1.20</summary>
/// <value>Alignment type
/// 1.20</value>
   public Efl.TextFormatHorizontalAlignmentAutoType HalignAutoType {
      get { return GetHalignAutoType(); }
      set { SetHalignAutoType( value); }
   }
   /// <summary>Horizontal alignment of text
/// 1.20</summary>
/// <value>Horizontal alignment value
/// 1.20</value>
   public double Halign {
      get { return GetHalign(); }
      set { SetHalign( value); }
   }
   /// <summary>Vertical alignment of text
/// 1.20</summary>
/// <value>Vertical alignment value
/// 1.20</value>
   public double Valign {
      get { return GetValign(); }
      set { SetValign( value); }
   }
   /// <summary>Minimal line gap (top and bottom) for each line in the text
/// <c>value</c> is absolute size.
/// 1.20</summary>
/// <value>Line gap value
/// 1.20</value>
   public double Linegap {
      get { return GetLinegap(); }
      set { SetLinegap( value); }
   }
   /// <summary>Relative line gap (top and bottom) for each line in the text
/// The original line gap value is multiplied by <c>value</c>.
/// 1.20</summary>
/// <value>Relative line gap value
/// 1.20</value>
   public double Linerelgap {
      get { return GetLinerelgap(); }
      set { SetLinerelgap( value); }
   }
   /// <summary>Tabstops value
/// 1.20</summary>
/// <value>Tapstops value
/// 1.20</value>
   public  int Tabstops {
      get { return GetTabstops(); }
      set { SetTabstops( value); }
   }
   /// <summary>Whether text is a password
/// 1.20</summary>
/// <value><c>true</c> if the text is a password, <c>false</c> otherwise
/// 1.20</value>
   public bool Password {
      get { return GetPassword(); }
      set { SetPassword( value); }
   }
   /// <summary>The character used to replace characters that can&apos;t be displayed
/// Currently only used to replace characters if <see cref="Efl.TextFormat.Password"/> is enabled.
/// 1.20</summary>
/// <value>Replacement character
/// 1.20</value>
   public  System.String ReplacementChar {
      get { return GetReplacementChar(); }
      set { SetReplacementChar( value); }
   }
   /// <summary>Enable or disable backing type
/// 1.20</summary>
/// <value>Backing type
/// 1.20</value>
   public Efl.TextStyleBackingType BackingType {
      get { return GetBackingType(); }
      set { SetBackingType( value); }
   }
   /// <summary>Sets an underline style on the text
/// 1.20</summary>
/// <value>Underline type
/// 1.20</value>
   public Efl.TextStyleUnderlineType UnderlineType {
      get { return GetUnderlineType(); }
      set { SetUnderlineType( value); }
   }
   /// <summary>Height of underline style
/// 1.20</summary>
/// <value>Height
/// 1.20</value>
   public double UnderlineHeight {
      get { return GetUnderlineHeight(); }
      set { SetUnderlineHeight( value); }
   }
   /// <summary>Width of dashed underline style
/// 1.20</summary>
/// <value>Width
/// 1.20</value>
   public  int UnderlineDashedWidth {
      get { return GetUnderlineDashedWidth(); }
      set { SetUnderlineDashedWidth( value); }
   }
   /// <summary>Gap of dashed underline style
/// 1.20</summary>
/// <value>Gap
/// 1.20</value>
   public  int UnderlineDashedGap {
      get { return GetUnderlineDashedGap(); }
      set { SetUnderlineDashedGap( value); }
   }
   /// <summary>Type of strikethrough style
/// 1.20</summary>
/// <value>Strikethrough type
/// 1.20</value>
   public Efl.TextStyleStrikethroughType StrikethroughType {
      get { return GetStrikethroughType(); }
      set { SetStrikethroughType( value); }
   }
   /// <summary>Type of effect used for the displayed text
/// 1.20</summary>
/// <value>Effect type
/// 1.20</value>
   public Efl.TextStyleEffectType EffectType {
      get { return GetEffectType(); }
      set { SetEffectType( value); }
   }
   /// <summary>Direction of shadow effect
/// 1.20</summary>
/// <value>Shadow direction
/// 1.20</value>
   public Efl.TextStyleShadowDirection ShadowDirection {
      get { return GetShadowDirection(); }
      set { SetShadowDirection( value); }
   }
   /// <summary>Program that applies a special filter
/// See <see cref="Efl.Gfx.Filter"/>.
/// 1.20</summary>
/// <value>Filter code
/// 1.20</value>
   public  System.String GfxFilter {
      get { return GetGfxFilter(); }
      set { SetGfxFilter( value); }
   }
}
public class TextInteractiveNativeInherit  : Efl.Eo.NativeClass{
   public  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Elementary);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      if (efl_text_interactive_selection_allowed_get_static_delegate == null)
      efl_text_interactive_selection_allowed_get_static_delegate = new efl_text_interactive_selection_allowed_get_delegate(selection_allowed_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_interactive_selection_allowed_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_interactive_selection_allowed_get_static_delegate)});
      if (efl_text_interactive_selection_allowed_set_static_delegate == null)
      efl_text_interactive_selection_allowed_set_static_delegate = new efl_text_interactive_selection_allowed_set_delegate(selection_allowed_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_interactive_selection_allowed_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_interactive_selection_allowed_set_static_delegate)});
      if (efl_text_interactive_selection_cursors_get_static_delegate == null)
      efl_text_interactive_selection_cursors_get_static_delegate = new efl_text_interactive_selection_cursors_get_delegate(selection_cursors_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_interactive_selection_cursors_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_interactive_selection_cursors_get_static_delegate)});
      if (efl_text_interactive_editable_get_static_delegate == null)
      efl_text_interactive_editable_get_static_delegate = new efl_text_interactive_editable_get_delegate(editable_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_interactive_editable_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_interactive_editable_get_static_delegate)});
      if (efl_text_interactive_editable_set_static_delegate == null)
      efl_text_interactive_editable_set_static_delegate = new efl_text_interactive_editable_set_delegate(editable_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_interactive_editable_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_interactive_editable_set_static_delegate)});
      if (efl_text_interactive_select_none_static_delegate == null)
      efl_text_interactive_select_none_static_delegate = new efl_text_interactive_select_none_delegate(select_none);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_interactive_select_none"), func = Marshal.GetFunctionPointerForDelegate(efl_text_interactive_select_none_static_delegate)});
      if (efl_text_get_static_delegate == null)
      efl_text_get_static_delegate = new efl_text_get_delegate(text_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_get_static_delegate)});
      if (efl_text_set_static_delegate == null)
      efl_text_set_static_delegate = new efl_text_set_delegate(text_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_set_static_delegate)});
      if (efl_text_font_get_static_delegate == null)
      efl_text_font_get_static_delegate = new efl_text_font_get_delegate(font_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_font_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_get_static_delegate)});
      if (efl_text_font_set_static_delegate == null)
      efl_text_font_set_static_delegate = new efl_text_font_set_delegate(font_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_font_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_set_static_delegate)});
      if (efl_text_font_source_get_static_delegate == null)
      efl_text_font_source_get_static_delegate = new efl_text_font_source_get_delegate(font_source_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_font_source_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_source_get_static_delegate)});
      if (efl_text_font_source_set_static_delegate == null)
      efl_text_font_source_set_static_delegate = new efl_text_font_source_set_delegate(font_source_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_font_source_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_source_set_static_delegate)});
      if (efl_text_font_fallbacks_get_static_delegate == null)
      efl_text_font_fallbacks_get_static_delegate = new efl_text_font_fallbacks_get_delegate(font_fallbacks_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_font_fallbacks_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_fallbacks_get_static_delegate)});
      if (efl_text_font_fallbacks_set_static_delegate == null)
      efl_text_font_fallbacks_set_static_delegate = new efl_text_font_fallbacks_set_delegate(font_fallbacks_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_font_fallbacks_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_fallbacks_set_static_delegate)});
      if (efl_text_font_weight_get_static_delegate == null)
      efl_text_font_weight_get_static_delegate = new efl_text_font_weight_get_delegate(font_weight_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_font_weight_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_weight_get_static_delegate)});
      if (efl_text_font_weight_set_static_delegate == null)
      efl_text_font_weight_set_static_delegate = new efl_text_font_weight_set_delegate(font_weight_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_font_weight_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_weight_set_static_delegate)});
      if (efl_text_font_slant_get_static_delegate == null)
      efl_text_font_slant_get_static_delegate = new efl_text_font_slant_get_delegate(font_slant_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_font_slant_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_slant_get_static_delegate)});
      if (efl_text_font_slant_set_static_delegate == null)
      efl_text_font_slant_set_static_delegate = new efl_text_font_slant_set_delegate(font_slant_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_font_slant_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_slant_set_static_delegate)});
      if (efl_text_font_width_get_static_delegate == null)
      efl_text_font_width_get_static_delegate = new efl_text_font_width_get_delegate(font_width_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_font_width_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_width_get_static_delegate)});
      if (efl_text_font_width_set_static_delegate == null)
      efl_text_font_width_set_static_delegate = new efl_text_font_width_set_delegate(font_width_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_font_width_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_width_set_static_delegate)});
      if (efl_text_font_lang_get_static_delegate == null)
      efl_text_font_lang_get_static_delegate = new efl_text_font_lang_get_delegate(font_lang_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_font_lang_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_lang_get_static_delegate)});
      if (efl_text_font_lang_set_static_delegate == null)
      efl_text_font_lang_set_static_delegate = new efl_text_font_lang_set_delegate(font_lang_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_font_lang_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_lang_set_static_delegate)});
      if (efl_text_font_bitmap_scalable_get_static_delegate == null)
      efl_text_font_bitmap_scalable_get_static_delegate = new efl_text_font_bitmap_scalable_get_delegate(font_bitmap_scalable_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_font_bitmap_scalable_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_bitmap_scalable_get_static_delegate)});
      if (efl_text_font_bitmap_scalable_set_static_delegate == null)
      efl_text_font_bitmap_scalable_set_static_delegate = new efl_text_font_bitmap_scalable_set_delegate(font_bitmap_scalable_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_font_bitmap_scalable_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_bitmap_scalable_set_static_delegate)});
      if (efl_text_ellipsis_get_static_delegate == null)
      efl_text_ellipsis_get_static_delegate = new efl_text_ellipsis_get_delegate(ellipsis_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_ellipsis_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_ellipsis_get_static_delegate)});
      if (efl_text_ellipsis_set_static_delegate == null)
      efl_text_ellipsis_set_static_delegate = new efl_text_ellipsis_set_delegate(ellipsis_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_ellipsis_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_ellipsis_set_static_delegate)});
      if (efl_text_wrap_get_static_delegate == null)
      efl_text_wrap_get_static_delegate = new efl_text_wrap_get_delegate(wrap_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_wrap_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_wrap_get_static_delegate)});
      if (efl_text_wrap_set_static_delegate == null)
      efl_text_wrap_set_static_delegate = new efl_text_wrap_set_delegate(wrap_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_wrap_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_wrap_set_static_delegate)});
      if (efl_text_multiline_get_static_delegate == null)
      efl_text_multiline_get_static_delegate = new efl_text_multiline_get_delegate(multiline_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_multiline_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_multiline_get_static_delegate)});
      if (efl_text_multiline_set_static_delegate == null)
      efl_text_multiline_set_static_delegate = new efl_text_multiline_set_delegate(multiline_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_multiline_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_multiline_set_static_delegate)});
      if (efl_text_halign_auto_type_get_static_delegate == null)
      efl_text_halign_auto_type_get_static_delegate = new efl_text_halign_auto_type_get_delegate(halign_auto_type_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_halign_auto_type_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_halign_auto_type_get_static_delegate)});
      if (efl_text_halign_auto_type_set_static_delegate == null)
      efl_text_halign_auto_type_set_static_delegate = new efl_text_halign_auto_type_set_delegate(halign_auto_type_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_halign_auto_type_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_halign_auto_type_set_static_delegate)});
      if (efl_text_halign_get_static_delegate == null)
      efl_text_halign_get_static_delegate = new efl_text_halign_get_delegate(halign_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_halign_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_halign_get_static_delegate)});
      if (efl_text_halign_set_static_delegate == null)
      efl_text_halign_set_static_delegate = new efl_text_halign_set_delegate(halign_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_halign_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_halign_set_static_delegate)});
      if (efl_text_valign_get_static_delegate == null)
      efl_text_valign_get_static_delegate = new efl_text_valign_get_delegate(valign_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_valign_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_valign_get_static_delegate)});
      if (efl_text_valign_set_static_delegate == null)
      efl_text_valign_set_static_delegate = new efl_text_valign_set_delegate(valign_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_valign_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_valign_set_static_delegate)});
      if (efl_text_linegap_get_static_delegate == null)
      efl_text_linegap_get_static_delegate = new efl_text_linegap_get_delegate(linegap_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_linegap_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_linegap_get_static_delegate)});
      if (efl_text_linegap_set_static_delegate == null)
      efl_text_linegap_set_static_delegate = new efl_text_linegap_set_delegate(linegap_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_linegap_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_linegap_set_static_delegate)});
      if (efl_text_linerelgap_get_static_delegate == null)
      efl_text_linerelgap_get_static_delegate = new efl_text_linerelgap_get_delegate(linerelgap_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_linerelgap_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_linerelgap_get_static_delegate)});
      if (efl_text_linerelgap_set_static_delegate == null)
      efl_text_linerelgap_set_static_delegate = new efl_text_linerelgap_set_delegate(linerelgap_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_linerelgap_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_linerelgap_set_static_delegate)});
      if (efl_text_tabstops_get_static_delegate == null)
      efl_text_tabstops_get_static_delegate = new efl_text_tabstops_get_delegate(tabstops_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_tabstops_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_tabstops_get_static_delegate)});
      if (efl_text_tabstops_set_static_delegate == null)
      efl_text_tabstops_set_static_delegate = new efl_text_tabstops_set_delegate(tabstops_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_tabstops_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_tabstops_set_static_delegate)});
      if (efl_text_password_get_static_delegate == null)
      efl_text_password_get_static_delegate = new efl_text_password_get_delegate(password_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_password_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_password_get_static_delegate)});
      if (efl_text_password_set_static_delegate == null)
      efl_text_password_set_static_delegate = new efl_text_password_set_delegate(password_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_password_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_password_set_static_delegate)});
      if (efl_text_replacement_char_get_static_delegate == null)
      efl_text_replacement_char_get_static_delegate = new efl_text_replacement_char_get_delegate(replacement_char_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_replacement_char_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_replacement_char_get_static_delegate)});
      if (efl_text_replacement_char_set_static_delegate == null)
      efl_text_replacement_char_set_static_delegate = new efl_text_replacement_char_set_delegate(replacement_char_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_replacement_char_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_replacement_char_set_static_delegate)});
      if (efl_text_normal_color_get_static_delegate == null)
      efl_text_normal_color_get_static_delegate = new efl_text_normal_color_get_delegate(normal_color_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_normal_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_normal_color_get_static_delegate)});
      if (efl_text_normal_color_set_static_delegate == null)
      efl_text_normal_color_set_static_delegate = new efl_text_normal_color_set_delegate(normal_color_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_normal_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_normal_color_set_static_delegate)});
      if (efl_text_backing_type_get_static_delegate == null)
      efl_text_backing_type_get_static_delegate = new efl_text_backing_type_get_delegate(backing_type_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_backing_type_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_backing_type_get_static_delegate)});
      if (efl_text_backing_type_set_static_delegate == null)
      efl_text_backing_type_set_static_delegate = new efl_text_backing_type_set_delegate(backing_type_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_backing_type_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_backing_type_set_static_delegate)});
      if (efl_text_backing_color_get_static_delegate == null)
      efl_text_backing_color_get_static_delegate = new efl_text_backing_color_get_delegate(backing_color_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_backing_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_backing_color_get_static_delegate)});
      if (efl_text_backing_color_set_static_delegate == null)
      efl_text_backing_color_set_static_delegate = new efl_text_backing_color_set_delegate(backing_color_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_backing_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_backing_color_set_static_delegate)});
      if (efl_text_underline_type_get_static_delegate == null)
      efl_text_underline_type_get_static_delegate = new efl_text_underline_type_get_delegate(underline_type_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_underline_type_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_type_get_static_delegate)});
      if (efl_text_underline_type_set_static_delegate == null)
      efl_text_underline_type_set_static_delegate = new efl_text_underline_type_set_delegate(underline_type_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_underline_type_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_type_set_static_delegate)});
      if (efl_text_underline_color_get_static_delegate == null)
      efl_text_underline_color_get_static_delegate = new efl_text_underline_color_get_delegate(underline_color_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_underline_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_color_get_static_delegate)});
      if (efl_text_underline_color_set_static_delegate == null)
      efl_text_underline_color_set_static_delegate = new efl_text_underline_color_set_delegate(underline_color_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_underline_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_color_set_static_delegate)});
      if (efl_text_underline_height_get_static_delegate == null)
      efl_text_underline_height_get_static_delegate = new efl_text_underline_height_get_delegate(underline_height_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_underline_height_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_height_get_static_delegate)});
      if (efl_text_underline_height_set_static_delegate == null)
      efl_text_underline_height_set_static_delegate = new efl_text_underline_height_set_delegate(underline_height_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_underline_height_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_height_set_static_delegate)});
      if (efl_text_underline_dashed_color_get_static_delegate == null)
      efl_text_underline_dashed_color_get_static_delegate = new efl_text_underline_dashed_color_get_delegate(underline_dashed_color_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_underline_dashed_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_dashed_color_get_static_delegate)});
      if (efl_text_underline_dashed_color_set_static_delegate == null)
      efl_text_underline_dashed_color_set_static_delegate = new efl_text_underline_dashed_color_set_delegate(underline_dashed_color_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_underline_dashed_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_dashed_color_set_static_delegate)});
      if (efl_text_underline_dashed_width_get_static_delegate == null)
      efl_text_underline_dashed_width_get_static_delegate = new efl_text_underline_dashed_width_get_delegate(underline_dashed_width_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_underline_dashed_width_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_dashed_width_get_static_delegate)});
      if (efl_text_underline_dashed_width_set_static_delegate == null)
      efl_text_underline_dashed_width_set_static_delegate = new efl_text_underline_dashed_width_set_delegate(underline_dashed_width_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_underline_dashed_width_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_dashed_width_set_static_delegate)});
      if (efl_text_underline_dashed_gap_get_static_delegate == null)
      efl_text_underline_dashed_gap_get_static_delegate = new efl_text_underline_dashed_gap_get_delegate(underline_dashed_gap_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_underline_dashed_gap_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_dashed_gap_get_static_delegate)});
      if (efl_text_underline_dashed_gap_set_static_delegate == null)
      efl_text_underline_dashed_gap_set_static_delegate = new efl_text_underline_dashed_gap_set_delegate(underline_dashed_gap_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_underline_dashed_gap_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_dashed_gap_set_static_delegate)});
      if (efl_text_underline2_color_get_static_delegate == null)
      efl_text_underline2_color_get_static_delegate = new efl_text_underline2_color_get_delegate(underline2_color_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_underline2_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline2_color_get_static_delegate)});
      if (efl_text_underline2_color_set_static_delegate == null)
      efl_text_underline2_color_set_static_delegate = new efl_text_underline2_color_set_delegate(underline2_color_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_underline2_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline2_color_set_static_delegate)});
      if (efl_text_strikethrough_type_get_static_delegate == null)
      efl_text_strikethrough_type_get_static_delegate = new efl_text_strikethrough_type_get_delegate(strikethrough_type_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_strikethrough_type_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_strikethrough_type_get_static_delegate)});
      if (efl_text_strikethrough_type_set_static_delegate == null)
      efl_text_strikethrough_type_set_static_delegate = new efl_text_strikethrough_type_set_delegate(strikethrough_type_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_strikethrough_type_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_strikethrough_type_set_static_delegate)});
      if (efl_text_strikethrough_color_get_static_delegate == null)
      efl_text_strikethrough_color_get_static_delegate = new efl_text_strikethrough_color_get_delegate(strikethrough_color_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_strikethrough_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_strikethrough_color_get_static_delegate)});
      if (efl_text_strikethrough_color_set_static_delegate == null)
      efl_text_strikethrough_color_set_static_delegate = new efl_text_strikethrough_color_set_delegate(strikethrough_color_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_strikethrough_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_strikethrough_color_set_static_delegate)});
      if (efl_text_effect_type_get_static_delegate == null)
      efl_text_effect_type_get_static_delegate = new efl_text_effect_type_get_delegate(effect_type_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_effect_type_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_effect_type_get_static_delegate)});
      if (efl_text_effect_type_set_static_delegate == null)
      efl_text_effect_type_set_static_delegate = new efl_text_effect_type_set_delegate(effect_type_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_effect_type_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_effect_type_set_static_delegate)});
      if (efl_text_outline_color_get_static_delegate == null)
      efl_text_outline_color_get_static_delegate = new efl_text_outline_color_get_delegate(outline_color_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_outline_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_outline_color_get_static_delegate)});
      if (efl_text_outline_color_set_static_delegate == null)
      efl_text_outline_color_set_static_delegate = new efl_text_outline_color_set_delegate(outline_color_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_outline_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_outline_color_set_static_delegate)});
      if (efl_text_shadow_direction_get_static_delegate == null)
      efl_text_shadow_direction_get_static_delegate = new efl_text_shadow_direction_get_delegate(shadow_direction_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_shadow_direction_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_shadow_direction_get_static_delegate)});
      if (efl_text_shadow_direction_set_static_delegate == null)
      efl_text_shadow_direction_set_static_delegate = new efl_text_shadow_direction_set_delegate(shadow_direction_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_shadow_direction_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_shadow_direction_set_static_delegate)});
      if (efl_text_shadow_color_get_static_delegate == null)
      efl_text_shadow_color_get_static_delegate = new efl_text_shadow_color_get_delegate(shadow_color_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_shadow_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_shadow_color_get_static_delegate)});
      if (efl_text_shadow_color_set_static_delegate == null)
      efl_text_shadow_color_set_static_delegate = new efl_text_shadow_color_set_delegate(shadow_color_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_shadow_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_shadow_color_set_static_delegate)});
      if (efl_text_glow_color_get_static_delegate == null)
      efl_text_glow_color_get_static_delegate = new efl_text_glow_color_get_delegate(glow_color_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_glow_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_glow_color_get_static_delegate)});
      if (efl_text_glow_color_set_static_delegate == null)
      efl_text_glow_color_set_static_delegate = new efl_text_glow_color_set_delegate(glow_color_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_glow_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_glow_color_set_static_delegate)});
      if (efl_text_glow2_color_get_static_delegate == null)
      efl_text_glow2_color_get_static_delegate = new efl_text_glow2_color_get_delegate(glow2_color_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_glow2_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_glow2_color_get_static_delegate)});
      if (efl_text_glow2_color_set_static_delegate == null)
      efl_text_glow2_color_set_static_delegate = new efl_text_glow2_color_set_delegate(glow2_color_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_glow2_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_glow2_color_set_static_delegate)});
      if (efl_text_gfx_filter_get_static_delegate == null)
      efl_text_gfx_filter_get_static_delegate = new efl_text_gfx_filter_get_delegate(gfx_filter_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_gfx_filter_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_gfx_filter_get_static_delegate)});
      if (efl_text_gfx_filter_set_static_delegate == null)
      efl_text_gfx_filter_set_static_delegate = new efl_text_gfx_filter_set_delegate(gfx_filter_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_gfx_filter_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_gfx_filter_set_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.TextInteractiveConcrete.efl_text_interactive_interface_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.TextInteractiveConcrete.efl_text_interactive_interface_get();
   }


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_text_interactive_selection_allowed_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_text_interactive_selection_allowed_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_text_interactive_selection_allowed_get_api_delegate> efl_text_interactive_selection_allowed_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_interactive_selection_allowed_get_api_delegate>(_Module, "efl_text_interactive_selection_allowed_get");
    private static bool selection_allowed_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_interactive_selection_allowed_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((TextInteractive)wrapper).GetSelectionAllowed();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_interactive_selection_allowed_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_text_interactive_selection_allowed_get_delegate efl_text_interactive_selection_allowed_get_static_delegate;


    private delegate  void efl_text_interactive_selection_allowed_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool allowed);


    public delegate  void efl_text_interactive_selection_allowed_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool allowed);
    public static Efl.Eo.FunctionWrapper<efl_text_interactive_selection_allowed_set_api_delegate> efl_text_interactive_selection_allowed_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_interactive_selection_allowed_set_api_delegate>(_Module, "efl_text_interactive_selection_allowed_set");
    private static  void selection_allowed_set(System.IntPtr obj, System.IntPtr pd,  bool allowed)
   {
      Eina.Log.Debug("function efl_text_interactive_selection_allowed_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextInteractive)wrapper).SetSelectionAllowed( allowed);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_interactive_selection_allowed_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  allowed);
      }
   }
   private static efl_text_interactive_selection_allowed_set_delegate efl_text_interactive_selection_allowed_set_static_delegate;


    private delegate  void efl_text_interactive_selection_cursors_get_delegate(System.IntPtr obj, System.IntPtr pd,   out Efl.TextCursorCursor start,   out Efl.TextCursorCursor end);


    public delegate  void efl_text_interactive_selection_cursors_get_api_delegate(System.IntPtr obj,   out Efl.TextCursorCursor start,   out Efl.TextCursorCursor end);
    public static Efl.Eo.FunctionWrapper<efl_text_interactive_selection_cursors_get_api_delegate> efl_text_interactive_selection_cursors_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_interactive_selection_cursors_get_api_delegate>(_Module, "efl_text_interactive_selection_cursors_get");
    private static  void selection_cursors_get(System.IntPtr obj, System.IntPtr pd,  out Efl.TextCursorCursor start,  out Efl.TextCursorCursor end)
   {
      Eina.Log.Debug("function efl_text_interactive_selection_cursors_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           start = default(Efl.TextCursorCursor);      end = default(Efl.TextCursorCursor);                     
         try {
            ((TextInteractive)wrapper).GetSelectionCursors( out start,  out end);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_text_interactive_selection_cursors_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out start,  out end);
      }
   }
   private static efl_text_interactive_selection_cursors_get_delegate efl_text_interactive_selection_cursors_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_text_interactive_editable_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_text_interactive_editable_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_text_interactive_editable_get_api_delegate> efl_text_interactive_editable_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_interactive_editable_get_api_delegate>(_Module, "efl_text_interactive_editable_get");
    private static bool editable_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_interactive_editable_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((TextInteractive)wrapper).GetEditable();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_interactive_editable_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_text_interactive_editable_get_delegate efl_text_interactive_editable_get_static_delegate;


    private delegate  void efl_text_interactive_editable_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool editable);


    public delegate  void efl_text_interactive_editable_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool editable);
    public static Efl.Eo.FunctionWrapper<efl_text_interactive_editable_set_api_delegate> efl_text_interactive_editable_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_interactive_editable_set_api_delegate>(_Module, "efl_text_interactive_editable_set");
    private static  void editable_set(System.IntPtr obj, System.IntPtr pd,  bool editable)
   {
      Eina.Log.Debug("function efl_text_interactive_editable_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextInteractive)wrapper).SetEditable( editable);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_interactive_editable_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  editable);
      }
   }
   private static efl_text_interactive_editable_set_delegate efl_text_interactive_editable_set_static_delegate;


    private delegate  void efl_text_interactive_select_none_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  void efl_text_interactive_select_none_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_text_interactive_select_none_api_delegate> efl_text_interactive_select_none_ptr = new Efl.Eo.FunctionWrapper<efl_text_interactive_select_none_api_delegate>(_Module, "efl_text_interactive_select_none");
    private static  void select_none(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_interactive_select_none was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((TextInteractive)wrapper).SelectNone();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_text_interactive_select_none_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_text_interactive_select_none_delegate efl_text_interactive_select_none_static_delegate;


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate  System.String efl_text_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate  System.String efl_text_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_text_get_api_delegate> efl_text_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_get_api_delegate>(_Module, "efl_text_get");
    private static  System.String text_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((TextInteractive)wrapper).GetText();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_text_get_delegate efl_text_get_static_delegate;


    private delegate  void efl_text_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String text);


    public delegate  void efl_text_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String text);
    public static Efl.Eo.FunctionWrapper<efl_text_set_api_delegate> efl_text_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_set_api_delegate>(_Module, "efl_text_set");
    private static  void text_set(System.IntPtr obj, System.IntPtr pd,   System.String text)
   {
      Eina.Log.Debug("function efl_text_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextInteractive)wrapper).SetText( text);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  text);
      }
   }
   private static efl_text_set_delegate efl_text_set_static_delegate;


    private delegate  void efl_text_font_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  out  System.String font,   out Efl.Font.Size size);


    public delegate  void efl_text_font_get_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  out  System.String font,   out Efl.Font.Size size);
    public static Efl.Eo.FunctionWrapper<efl_text_font_get_api_delegate> efl_text_font_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_get_api_delegate>(_Module, "efl_text_font_get");
    private static  void font_get(System.IntPtr obj, System.IntPtr pd,  out  System.String font,  out Efl.Font.Size size)
   {
      Eina.Log.Debug("function efl_text_font_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                            System.String _out_font = default( System.String);
      size = default(Efl.Font.Size);                     
         try {
            ((TextInteractive)wrapper).GetFont( out _out_font,  out size);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      font = _out_font;
                              } else {
         efl_text_font_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out font,  out size);
      }
   }
   private static efl_text_font_get_delegate efl_text_font_get_static_delegate;


    private delegate  void efl_text_font_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String font,   Efl.Font.Size size);


    public delegate  void efl_text_font_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String font,   Efl.Font.Size size);
    public static Efl.Eo.FunctionWrapper<efl_text_font_set_api_delegate> efl_text_font_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_set_api_delegate>(_Module, "efl_text_font_set");
    private static  void font_set(System.IntPtr obj, System.IntPtr pd,   System.String font,  Efl.Font.Size size)
   {
      Eina.Log.Debug("function efl_text_font_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((TextInteractive)wrapper).SetFont( font,  size);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_text_font_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  font,  size);
      }
   }
   private static efl_text_font_set_delegate efl_text_font_set_static_delegate;


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate  System.String efl_text_font_source_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate  System.String efl_text_font_source_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_text_font_source_get_api_delegate> efl_text_font_source_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_source_get_api_delegate>(_Module, "efl_text_font_source_get");
    private static  System.String font_source_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_font_source_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((TextInteractive)wrapper).GetFontSource();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_font_source_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_text_font_source_get_delegate efl_text_font_source_get_static_delegate;


    private delegate  void efl_text_font_source_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String font_source);


    public delegate  void efl_text_font_source_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String font_source);
    public static Efl.Eo.FunctionWrapper<efl_text_font_source_set_api_delegate> efl_text_font_source_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_source_set_api_delegate>(_Module, "efl_text_font_source_set");
    private static  void font_source_set(System.IntPtr obj, System.IntPtr pd,   System.String font_source)
   {
      Eina.Log.Debug("function efl_text_font_source_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextInteractive)wrapper).SetFontSource( font_source);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_font_source_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  font_source);
      }
   }
   private static efl_text_font_source_set_delegate efl_text_font_source_set_static_delegate;


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate  System.String efl_text_font_fallbacks_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate  System.String efl_text_font_fallbacks_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_text_font_fallbacks_get_api_delegate> efl_text_font_fallbacks_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_fallbacks_get_api_delegate>(_Module, "efl_text_font_fallbacks_get");
    private static  System.String font_fallbacks_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_font_fallbacks_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((TextInteractive)wrapper).GetFontFallbacks();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_font_fallbacks_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_text_font_fallbacks_get_delegate efl_text_font_fallbacks_get_static_delegate;


    private delegate  void efl_text_font_fallbacks_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String font_fallbacks);


    public delegate  void efl_text_font_fallbacks_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String font_fallbacks);
    public static Efl.Eo.FunctionWrapper<efl_text_font_fallbacks_set_api_delegate> efl_text_font_fallbacks_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_fallbacks_set_api_delegate>(_Module, "efl_text_font_fallbacks_set");
    private static  void font_fallbacks_set(System.IntPtr obj, System.IntPtr pd,   System.String font_fallbacks)
   {
      Eina.Log.Debug("function efl_text_font_fallbacks_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextInteractive)wrapper).SetFontFallbacks( font_fallbacks);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_font_fallbacks_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  font_fallbacks);
      }
   }
   private static efl_text_font_fallbacks_set_delegate efl_text_font_fallbacks_set_static_delegate;


    private delegate Efl.TextFontWeight efl_text_font_weight_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Efl.TextFontWeight efl_text_font_weight_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_text_font_weight_get_api_delegate> efl_text_font_weight_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_weight_get_api_delegate>(_Module, "efl_text_font_weight_get");
    private static Efl.TextFontWeight font_weight_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_font_weight_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.TextFontWeight _ret_var = default(Efl.TextFontWeight);
         try {
            _ret_var = ((TextInteractive)wrapper).GetFontWeight();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_font_weight_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_text_font_weight_get_delegate efl_text_font_weight_get_static_delegate;


    private delegate  void efl_text_font_weight_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextFontWeight font_weight);


    public delegate  void efl_text_font_weight_set_api_delegate(System.IntPtr obj,   Efl.TextFontWeight font_weight);
    public static Efl.Eo.FunctionWrapper<efl_text_font_weight_set_api_delegate> efl_text_font_weight_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_weight_set_api_delegate>(_Module, "efl_text_font_weight_set");
    private static  void font_weight_set(System.IntPtr obj, System.IntPtr pd,  Efl.TextFontWeight font_weight)
   {
      Eina.Log.Debug("function efl_text_font_weight_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextInteractive)wrapper).SetFontWeight( font_weight);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_font_weight_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  font_weight);
      }
   }
   private static efl_text_font_weight_set_delegate efl_text_font_weight_set_static_delegate;


    private delegate Efl.TextFontSlant efl_text_font_slant_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Efl.TextFontSlant efl_text_font_slant_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_text_font_slant_get_api_delegate> efl_text_font_slant_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_slant_get_api_delegate>(_Module, "efl_text_font_slant_get");
    private static Efl.TextFontSlant font_slant_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_font_slant_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.TextFontSlant _ret_var = default(Efl.TextFontSlant);
         try {
            _ret_var = ((TextInteractive)wrapper).GetFontSlant();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_font_slant_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_text_font_slant_get_delegate efl_text_font_slant_get_static_delegate;


    private delegate  void efl_text_font_slant_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextFontSlant style);


    public delegate  void efl_text_font_slant_set_api_delegate(System.IntPtr obj,   Efl.TextFontSlant style);
    public static Efl.Eo.FunctionWrapper<efl_text_font_slant_set_api_delegate> efl_text_font_slant_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_slant_set_api_delegate>(_Module, "efl_text_font_slant_set");
    private static  void font_slant_set(System.IntPtr obj, System.IntPtr pd,  Efl.TextFontSlant style)
   {
      Eina.Log.Debug("function efl_text_font_slant_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextInteractive)wrapper).SetFontSlant( style);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_font_slant_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  style);
      }
   }
   private static efl_text_font_slant_set_delegate efl_text_font_slant_set_static_delegate;


    private delegate Efl.TextFontWidth efl_text_font_width_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Efl.TextFontWidth efl_text_font_width_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_text_font_width_get_api_delegate> efl_text_font_width_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_width_get_api_delegate>(_Module, "efl_text_font_width_get");
    private static Efl.TextFontWidth font_width_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_font_width_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.TextFontWidth _ret_var = default(Efl.TextFontWidth);
         try {
            _ret_var = ((TextInteractive)wrapper).GetFontWidth();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_font_width_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_text_font_width_get_delegate efl_text_font_width_get_static_delegate;


    private delegate  void efl_text_font_width_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextFontWidth width);


    public delegate  void efl_text_font_width_set_api_delegate(System.IntPtr obj,   Efl.TextFontWidth width);
    public static Efl.Eo.FunctionWrapper<efl_text_font_width_set_api_delegate> efl_text_font_width_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_width_set_api_delegate>(_Module, "efl_text_font_width_set");
    private static  void font_width_set(System.IntPtr obj, System.IntPtr pd,  Efl.TextFontWidth width)
   {
      Eina.Log.Debug("function efl_text_font_width_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextInteractive)wrapper).SetFontWidth( width);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_font_width_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  width);
      }
   }
   private static efl_text_font_width_set_delegate efl_text_font_width_set_static_delegate;


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate  System.String efl_text_font_lang_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate  System.String efl_text_font_lang_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_text_font_lang_get_api_delegate> efl_text_font_lang_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_lang_get_api_delegate>(_Module, "efl_text_font_lang_get");
    private static  System.String font_lang_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_font_lang_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((TextInteractive)wrapper).GetFontLang();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_font_lang_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_text_font_lang_get_delegate efl_text_font_lang_get_static_delegate;


    private delegate  void efl_text_font_lang_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String lang);


    public delegate  void efl_text_font_lang_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String lang);
    public static Efl.Eo.FunctionWrapper<efl_text_font_lang_set_api_delegate> efl_text_font_lang_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_lang_set_api_delegate>(_Module, "efl_text_font_lang_set");
    private static  void font_lang_set(System.IntPtr obj, System.IntPtr pd,   System.String lang)
   {
      Eina.Log.Debug("function efl_text_font_lang_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextInteractive)wrapper).SetFontLang( lang);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_font_lang_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  lang);
      }
   }
   private static efl_text_font_lang_set_delegate efl_text_font_lang_set_static_delegate;


    private delegate Efl.TextFontBitmapScalable efl_text_font_bitmap_scalable_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Efl.TextFontBitmapScalable efl_text_font_bitmap_scalable_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_text_font_bitmap_scalable_get_api_delegate> efl_text_font_bitmap_scalable_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_bitmap_scalable_get_api_delegate>(_Module, "efl_text_font_bitmap_scalable_get");
    private static Efl.TextFontBitmapScalable font_bitmap_scalable_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_font_bitmap_scalable_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.TextFontBitmapScalable _ret_var = default(Efl.TextFontBitmapScalable);
         try {
            _ret_var = ((TextInteractive)wrapper).GetFontBitmapScalable();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_font_bitmap_scalable_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_text_font_bitmap_scalable_get_delegate efl_text_font_bitmap_scalable_get_static_delegate;


    private delegate  void efl_text_font_bitmap_scalable_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextFontBitmapScalable scalable);


    public delegate  void efl_text_font_bitmap_scalable_set_api_delegate(System.IntPtr obj,   Efl.TextFontBitmapScalable scalable);
    public static Efl.Eo.FunctionWrapper<efl_text_font_bitmap_scalable_set_api_delegate> efl_text_font_bitmap_scalable_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_bitmap_scalable_set_api_delegate>(_Module, "efl_text_font_bitmap_scalable_set");
    private static  void font_bitmap_scalable_set(System.IntPtr obj, System.IntPtr pd,  Efl.TextFontBitmapScalable scalable)
   {
      Eina.Log.Debug("function efl_text_font_bitmap_scalable_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextInteractive)wrapper).SetFontBitmapScalable( scalable);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_font_bitmap_scalable_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  scalable);
      }
   }
   private static efl_text_font_bitmap_scalable_set_delegate efl_text_font_bitmap_scalable_set_static_delegate;


    private delegate double efl_text_ellipsis_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate double efl_text_ellipsis_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_text_ellipsis_get_api_delegate> efl_text_ellipsis_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_ellipsis_get_api_delegate>(_Module, "efl_text_ellipsis_get");
    private static double ellipsis_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_ellipsis_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  double _ret_var = default(double);
         try {
            _ret_var = ((TextInteractive)wrapper).GetEllipsis();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_ellipsis_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_text_ellipsis_get_delegate efl_text_ellipsis_get_static_delegate;


    private delegate  void efl_text_ellipsis_set_delegate(System.IntPtr obj, System.IntPtr pd,   double value);


    public delegate  void efl_text_ellipsis_set_api_delegate(System.IntPtr obj,   double value);
    public static Efl.Eo.FunctionWrapper<efl_text_ellipsis_set_api_delegate> efl_text_ellipsis_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_ellipsis_set_api_delegate>(_Module, "efl_text_ellipsis_set");
    private static  void ellipsis_set(System.IntPtr obj, System.IntPtr pd,  double value)
   {
      Eina.Log.Debug("function efl_text_ellipsis_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextInteractive)wrapper).SetEllipsis( value);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_ellipsis_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  value);
      }
   }
   private static efl_text_ellipsis_set_delegate efl_text_ellipsis_set_static_delegate;


    private delegate Efl.TextFormatWrap efl_text_wrap_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Efl.TextFormatWrap efl_text_wrap_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_text_wrap_get_api_delegate> efl_text_wrap_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_wrap_get_api_delegate>(_Module, "efl_text_wrap_get");
    private static Efl.TextFormatWrap wrap_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_wrap_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.TextFormatWrap _ret_var = default(Efl.TextFormatWrap);
         try {
            _ret_var = ((TextInteractive)wrapper).GetWrap();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_wrap_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_text_wrap_get_delegate efl_text_wrap_get_static_delegate;


    private delegate  void efl_text_wrap_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextFormatWrap wrap);


    public delegate  void efl_text_wrap_set_api_delegate(System.IntPtr obj,   Efl.TextFormatWrap wrap);
    public static Efl.Eo.FunctionWrapper<efl_text_wrap_set_api_delegate> efl_text_wrap_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_wrap_set_api_delegate>(_Module, "efl_text_wrap_set");
    private static  void wrap_set(System.IntPtr obj, System.IntPtr pd,  Efl.TextFormatWrap wrap)
   {
      Eina.Log.Debug("function efl_text_wrap_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextInteractive)wrapper).SetWrap( wrap);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_wrap_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  wrap);
      }
   }
   private static efl_text_wrap_set_delegate efl_text_wrap_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_text_multiline_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_text_multiline_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_text_multiline_get_api_delegate> efl_text_multiline_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_multiline_get_api_delegate>(_Module, "efl_text_multiline_get");
    private static bool multiline_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_multiline_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((TextInteractive)wrapper).GetMultiline();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_multiline_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_text_multiline_get_delegate efl_text_multiline_get_static_delegate;


    private delegate  void efl_text_multiline_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool enabled);


    public delegate  void efl_text_multiline_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool enabled);
    public static Efl.Eo.FunctionWrapper<efl_text_multiline_set_api_delegate> efl_text_multiline_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_multiline_set_api_delegate>(_Module, "efl_text_multiline_set");
    private static  void multiline_set(System.IntPtr obj, System.IntPtr pd,  bool enabled)
   {
      Eina.Log.Debug("function efl_text_multiline_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextInteractive)wrapper).SetMultiline( enabled);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_multiline_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  enabled);
      }
   }
   private static efl_text_multiline_set_delegate efl_text_multiline_set_static_delegate;


    private delegate Efl.TextFormatHorizontalAlignmentAutoType efl_text_halign_auto_type_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Efl.TextFormatHorizontalAlignmentAutoType efl_text_halign_auto_type_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_text_halign_auto_type_get_api_delegate> efl_text_halign_auto_type_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_halign_auto_type_get_api_delegate>(_Module, "efl_text_halign_auto_type_get");
    private static Efl.TextFormatHorizontalAlignmentAutoType halign_auto_type_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_halign_auto_type_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.TextFormatHorizontalAlignmentAutoType _ret_var = default(Efl.TextFormatHorizontalAlignmentAutoType);
         try {
            _ret_var = ((TextInteractive)wrapper).GetHalignAutoType();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_halign_auto_type_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_text_halign_auto_type_get_delegate efl_text_halign_auto_type_get_static_delegate;


    private delegate  void efl_text_halign_auto_type_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextFormatHorizontalAlignmentAutoType value);


    public delegate  void efl_text_halign_auto_type_set_api_delegate(System.IntPtr obj,   Efl.TextFormatHorizontalAlignmentAutoType value);
    public static Efl.Eo.FunctionWrapper<efl_text_halign_auto_type_set_api_delegate> efl_text_halign_auto_type_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_halign_auto_type_set_api_delegate>(_Module, "efl_text_halign_auto_type_set");
    private static  void halign_auto_type_set(System.IntPtr obj, System.IntPtr pd,  Efl.TextFormatHorizontalAlignmentAutoType value)
   {
      Eina.Log.Debug("function efl_text_halign_auto_type_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextInteractive)wrapper).SetHalignAutoType( value);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_halign_auto_type_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  value);
      }
   }
   private static efl_text_halign_auto_type_set_delegate efl_text_halign_auto_type_set_static_delegate;


    private delegate double efl_text_halign_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate double efl_text_halign_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_text_halign_get_api_delegate> efl_text_halign_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_halign_get_api_delegate>(_Module, "efl_text_halign_get");
    private static double halign_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_halign_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  double _ret_var = default(double);
         try {
            _ret_var = ((TextInteractive)wrapper).GetHalign();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_halign_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_text_halign_get_delegate efl_text_halign_get_static_delegate;


    private delegate  void efl_text_halign_set_delegate(System.IntPtr obj, System.IntPtr pd,   double value);


    public delegate  void efl_text_halign_set_api_delegate(System.IntPtr obj,   double value);
    public static Efl.Eo.FunctionWrapper<efl_text_halign_set_api_delegate> efl_text_halign_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_halign_set_api_delegate>(_Module, "efl_text_halign_set");
    private static  void halign_set(System.IntPtr obj, System.IntPtr pd,  double value)
   {
      Eina.Log.Debug("function efl_text_halign_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextInteractive)wrapper).SetHalign( value);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_halign_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  value);
      }
   }
   private static efl_text_halign_set_delegate efl_text_halign_set_static_delegate;


    private delegate double efl_text_valign_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate double efl_text_valign_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_text_valign_get_api_delegate> efl_text_valign_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_valign_get_api_delegate>(_Module, "efl_text_valign_get");
    private static double valign_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_valign_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  double _ret_var = default(double);
         try {
            _ret_var = ((TextInteractive)wrapper).GetValign();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_valign_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_text_valign_get_delegate efl_text_valign_get_static_delegate;


    private delegate  void efl_text_valign_set_delegate(System.IntPtr obj, System.IntPtr pd,   double value);


    public delegate  void efl_text_valign_set_api_delegate(System.IntPtr obj,   double value);
    public static Efl.Eo.FunctionWrapper<efl_text_valign_set_api_delegate> efl_text_valign_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_valign_set_api_delegate>(_Module, "efl_text_valign_set");
    private static  void valign_set(System.IntPtr obj, System.IntPtr pd,  double value)
   {
      Eina.Log.Debug("function efl_text_valign_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextInteractive)wrapper).SetValign( value);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_valign_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  value);
      }
   }
   private static efl_text_valign_set_delegate efl_text_valign_set_static_delegate;


    private delegate double efl_text_linegap_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate double efl_text_linegap_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_text_linegap_get_api_delegate> efl_text_linegap_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_linegap_get_api_delegate>(_Module, "efl_text_linegap_get");
    private static double linegap_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_linegap_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  double _ret_var = default(double);
         try {
            _ret_var = ((TextInteractive)wrapper).GetLinegap();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_linegap_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_text_linegap_get_delegate efl_text_linegap_get_static_delegate;


    private delegate  void efl_text_linegap_set_delegate(System.IntPtr obj, System.IntPtr pd,   double value);


    public delegate  void efl_text_linegap_set_api_delegate(System.IntPtr obj,   double value);
    public static Efl.Eo.FunctionWrapper<efl_text_linegap_set_api_delegate> efl_text_linegap_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_linegap_set_api_delegate>(_Module, "efl_text_linegap_set");
    private static  void linegap_set(System.IntPtr obj, System.IntPtr pd,  double value)
   {
      Eina.Log.Debug("function efl_text_linegap_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextInteractive)wrapper).SetLinegap( value);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_linegap_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  value);
      }
   }
   private static efl_text_linegap_set_delegate efl_text_linegap_set_static_delegate;


    private delegate double efl_text_linerelgap_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate double efl_text_linerelgap_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_text_linerelgap_get_api_delegate> efl_text_linerelgap_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_linerelgap_get_api_delegate>(_Module, "efl_text_linerelgap_get");
    private static double linerelgap_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_linerelgap_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  double _ret_var = default(double);
         try {
            _ret_var = ((TextInteractive)wrapper).GetLinerelgap();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_linerelgap_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_text_linerelgap_get_delegate efl_text_linerelgap_get_static_delegate;


    private delegate  void efl_text_linerelgap_set_delegate(System.IntPtr obj, System.IntPtr pd,   double value);


    public delegate  void efl_text_linerelgap_set_api_delegate(System.IntPtr obj,   double value);
    public static Efl.Eo.FunctionWrapper<efl_text_linerelgap_set_api_delegate> efl_text_linerelgap_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_linerelgap_set_api_delegate>(_Module, "efl_text_linerelgap_set");
    private static  void linerelgap_set(System.IntPtr obj, System.IntPtr pd,  double value)
   {
      Eina.Log.Debug("function efl_text_linerelgap_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextInteractive)wrapper).SetLinerelgap( value);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_linerelgap_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  value);
      }
   }
   private static efl_text_linerelgap_set_delegate efl_text_linerelgap_set_static_delegate;


    private delegate  int efl_text_tabstops_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  int efl_text_tabstops_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_text_tabstops_get_api_delegate> efl_text_tabstops_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_tabstops_get_api_delegate>(_Module, "efl_text_tabstops_get");
    private static  int tabstops_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_tabstops_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   int _ret_var = default( int);
         try {
            _ret_var = ((TextInteractive)wrapper).GetTabstops();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_tabstops_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_text_tabstops_get_delegate efl_text_tabstops_get_static_delegate;


    private delegate  void efl_text_tabstops_set_delegate(System.IntPtr obj, System.IntPtr pd,    int value);


    public delegate  void efl_text_tabstops_set_api_delegate(System.IntPtr obj,    int value);
    public static Efl.Eo.FunctionWrapper<efl_text_tabstops_set_api_delegate> efl_text_tabstops_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_tabstops_set_api_delegate>(_Module, "efl_text_tabstops_set");
    private static  void tabstops_set(System.IntPtr obj, System.IntPtr pd,   int value)
   {
      Eina.Log.Debug("function efl_text_tabstops_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextInteractive)wrapper).SetTabstops( value);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_tabstops_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  value);
      }
   }
   private static efl_text_tabstops_set_delegate efl_text_tabstops_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_text_password_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_text_password_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_text_password_get_api_delegate> efl_text_password_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_password_get_api_delegate>(_Module, "efl_text_password_get");
    private static bool password_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_password_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((TextInteractive)wrapper).GetPassword();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_password_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_text_password_get_delegate efl_text_password_get_static_delegate;


    private delegate  void efl_text_password_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool enabled);


    public delegate  void efl_text_password_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool enabled);
    public static Efl.Eo.FunctionWrapper<efl_text_password_set_api_delegate> efl_text_password_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_password_set_api_delegate>(_Module, "efl_text_password_set");
    private static  void password_set(System.IntPtr obj, System.IntPtr pd,  bool enabled)
   {
      Eina.Log.Debug("function efl_text_password_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextInteractive)wrapper).SetPassword( enabled);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_password_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  enabled);
      }
   }
   private static efl_text_password_set_delegate efl_text_password_set_static_delegate;


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate  System.String efl_text_replacement_char_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate  System.String efl_text_replacement_char_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_text_replacement_char_get_api_delegate> efl_text_replacement_char_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_replacement_char_get_api_delegate>(_Module, "efl_text_replacement_char_get");
    private static  System.String replacement_char_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_replacement_char_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((TextInteractive)wrapper).GetReplacementChar();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_replacement_char_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_text_replacement_char_get_delegate efl_text_replacement_char_get_static_delegate;


    private delegate  void efl_text_replacement_char_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String repch);


    public delegate  void efl_text_replacement_char_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String repch);
    public static Efl.Eo.FunctionWrapper<efl_text_replacement_char_set_api_delegate> efl_text_replacement_char_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_replacement_char_set_api_delegate>(_Module, "efl_text_replacement_char_set");
    private static  void replacement_char_set(System.IntPtr obj, System.IntPtr pd,   System.String repch)
   {
      Eina.Log.Debug("function efl_text_replacement_char_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextInteractive)wrapper).SetReplacementChar( repch);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_replacement_char_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  repch);
      }
   }
   private static efl_text_replacement_char_set_delegate efl_text_replacement_char_set_static_delegate;


    private delegate  void efl_text_normal_color_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  byte r,   out  byte g,   out  byte b,   out  byte a);


    public delegate  void efl_text_normal_color_get_api_delegate(System.IntPtr obj,   out  byte r,   out  byte g,   out  byte b,   out  byte a);
    public static Efl.Eo.FunctionWrapper<efl_text_normal_color_get_api_delegate> efl_text_normal_color_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_normal_color_get_api_delegate>(_Module, "efl_text_normal_color_get");
    private static  void normal_color_get(System.IntPtr obj, System.IntPtr pd,  out  byte r,  out  byte g,  out  byte b,  out  byte a)
   {
      Eina.Log.Debug("function efl_text_normal_color_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                       r = default( byte);      g = default( byte);      b = default( byte);      a = default( byte);                                 
         try {
            ((TextInteractive)wrapper).GetNormalColor( out r,  out g,  out b,  out a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_text_normal_color_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out r,  out g,  out b,  out a);
      }
   }
   private static efl_text_normal_color_get_delegate efl_text_normal_color_get_static_delegate;


    private delegate  void efl_text_normal_color_set_delegate(System.IntPtr obj, System.IntPtr pd,    byte r,    byte g,    byte b,    byte a);


    public delegate  void efl_text_normal_color_set_api_delegate(System.IntPtr obj,    byte r,    byte g,    byte b,    byte a);
    public static Efl.Eo.FunctionWrapper<efl_text_normal_color_set_api_delegate> efl_text_normal_color_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_normal_color_set_api_delegate>(_Module, "efl_text_normal_color_set");
    private static  void normal_color_set(System.IntPtr obj, System.IntPtr pd,   byte r,   byte g,   byte b,   byte a)
   {
      Eina.Log.Debug("function efl_text_normal_color_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                          
         try {
            ((TextInteractive)wrapper).SetNormalColor( r,  g,  b,  a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_text_normal_color_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  r,  g,  b,  a);
      }
   }
   private static efl_text_normal_color_set_delegate efl_text_normal_color_set_static_delegate;


    private delegate Efl.TextStyleBackingType efl_text_backing_type_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Efl.TextStyleBackingType efl_text_backing_type_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_text_backing_type_get_api_delegate> efl_text_backing_type_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_backing_type_get_api_delegate>(_Module, "efl_text_backing_type_get");
    private static Efl.TextStyleBackingType backing_type_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_backing_type_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.TextStyleBackingType _ret_var = default(Efl.TextStyleBackingType);
         try {
            _ret_var = ((TextInteractive)wrapper).GetBackingType();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_backing_type_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_text_backing_type_get_delegate efl_text_backing_type_get_static_delegate;


    private delegate  void efl_text_backing_type_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextStyleBackingType type);


    public delegate  void efl_text_backing_type_set_api_delegate(System.IntPtr obj,   Efl.TextStyleBackingType type);
    public static Efl.Eo.FunctionWrapper<efl_text_backing_type_set_api_delegate> efl_text_backing_type_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_backing_type_set_api_delegate>(_Module, "efl_text_backing_type_set");
    private static  void backing_type_set(System.IntPtr obj, System.IntPtr pd,  Efl.TextStyleBackingType type)
   {
      Eina.Log.Debug("function efl_text_backing_type_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextInteractive)wrapper).SetBackingType( type);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_backing_type_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  type);
      }
   }
   private static efl_text_backing_type_set_delegate efl_text_backing_type_set_static_delegate;


    private delegate  void efl_text_backing_color_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  byte r,   out  byte g,   out  byte b,   out  byte a);


    public delegate  void efl_text_backing_color_get_api_delegate(System.IntPtr obj,   out  byte r,   out  byte g,   out  byte b,   out  byte a);
    public static Efl.Eo.FunctionWrapper<efl_text_backing_color_get_api_delegate> efl_text_backing_color_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_backing_color_get_api_delegate>(_Module, "efl_text_backing_color_get");
    private static  void backing_color_get(System.IntPtr obj, System.IntPtr pd,  out  byte r,  out  byte g,  out  byte b,  out  byte a)
   {
      Eina.Log.Debug("function efl_text_backing_color_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                       r = default( byte);      g = default( byte);      b = default( byte);      a = default( byte);                                 
         try {
            ((TextInteractive)wrapper).GetBackingColor( out r,  out g,  out b,  out a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_text_backing_color_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out r,  out g,  out b,  out a);
      }
   }
   private static efl_text_backing_color_get_delegate efl_text_backing_color_get_static_delegate;


    private delegate  void efl_text_backing_color_set_delegate(System.IntPtr obj, System.IntPtr pd,    byte r,    byte g,    byte b,    byte a);


    public delegate  void efl_text_backing_color_set_api_delegate(System.IntPtr obj,    byte r,    byte g,    byte b,    byte a);
    public static Efl.Eo.FunctionWrapper<efl_text_backing_color_set_api_delegate> efl_text_backing_color_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_backing_color_set_api_delegate>(_Module, "efl_text_backing_color_set");
    private static  void backing_color_set(System.IntPtr obj, System.IntPtr pd,   byte r,   byte g,   byte b,   byte a)
   {
      Eina.Log.Debug("function efl_text_backing_color_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                          
         try {
            ((TextInteractive)wrapper).SetBackingColor( r,  g,  b,  a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_text_backing_color_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  r,  g,  b,  a);
      }
   }
   private static efl_text_backing_color_set_delegate efl_text_backing_color_set_static_delegate;


    private delegate Efl.TextStyleUnderlineType efl_text_underline_type_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Efl.TextStyleUnderlineType efl_text_underline_type_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_text_underline_type_get_api_delegate> efl_text_underline_type_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_underline_type_get_api_delegate>(_Module, "efl_text_underline_type_get");
    private static Efl.TextStyleUnderlineType underline_type_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_underline_type_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.TextStyleUnderlineType _ret_var = default(Efl.TextStyleUnderlineType);
         try {
            _ret_var = ((TextInteractive)wrapper).GetUnderlineType();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_underline_type_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_text_underline_type_get_delegate efl_text_underline_type_get_static_delegate;


    private delegate  void efl_text_underline_type_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextStyleUnderlineType type);


    public delegate  void efl_text_underline_type_set_api_delegate(System.IntPtr obj,   Efl.TextStyleUnderlineType type);
    public static Efl.Eo.FunctionWrapper<efl_text_underline_type_set_api_delegate> efl_text_underline_type_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_underline_type_set_api_delegate>(_Module, "efl_text_underline_type_set");
    private static  void underline_type_set(System.IntPtr obj, System.IntPtr pd,  Efl.TextStyleUnderlineType type)
   {
      Eina.Log.Debug("function efl_text_underline_type_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextInteractive)wrapper).SetUnderlineType( type);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_underline_type_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  type);
      }
   }
   private static efl_text_underline_type_set_delegate efl_text_underline_type_set_static_delegate;


    private delegate  void efl_text_underline_color_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  byte r,   out  byte g,   out  byte b,   out  byte a);


    public delegate  void efl_text_underline_color_get_api_delegate(System.IntPtr obj,   out  byte r,   out  byte g,   out  byte b,   out  byte a);
    public static Efl.Eo.FunctionWrapper<efl_text_underline_color_get_api_delegate> efl_text_underline_color_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_underline_color_get_api_delegate>(_Module, "efl_text_underline_color_get");
    private static  void underline_color_get(System.IntPtr obj, System.IntPtr pd,  out  byte r,  out  byte g,  out  byte b,  out  byte a)
   {
      Eina.Log.Debug("function efl_text_underline_color_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                       r = default( byte);      g = default( byte);      b = default( byte);      a = default( byte);                                 
         try {
            ((TextInteractive)wrapper).GetUnderlineColor( out r,  out g,  out b,  out a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_text_underline_color_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out r,  out g,  out b,  out a);
      }
   }
   private static efl_text_underline_color_get_delegate efl_text_underline_color_get_static_delegate;


    private delegate  void efl_text_underline_color_set_delegate(System.IntPtr obj, System.IntPtr pd,    byte r,    byte g,    byte b,    byte a);


    public delegate  void efl_text_underline_color_set_api_delegate(System.IntPtr obj,    byte r,    byte g,    byte b,    byte a);
    public static Efl.Eo.FunctionWrapper<efl_text_underline_color_set_api_delegate> efl_text_underline_color_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_underline_color_set_api_delegate>(_Module, "efl_text_underline_color_set");
    private static  void underline_color_set(System.IntPtr obj, System.IntPtr pd,   byte r,   byte g,   byte b,   byte a)
   {
      Eina.Log.Debug("function efl_text_underline_color_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                          
         try {
            ((TextInteractive)wrapper).SetUnderlineColor( r,  g,  b,  a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_text_underline_color_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  r,  g,  b,  a);
      }
   }
   private static efl_text_underline_color_set_delegate efl_text_underline_color_set_static_delegate;


    private delegate double efl_text_underline_height_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate double efl_text_underline_height_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_text_underline_height_get_api_delegate> efl_text_underline_height_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_underline_height_get_api_delegate>(_Module, "efl_text_underline_height_get");
    private static double underline_height_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_underline_height_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  double _ret_var = default(double);
         try {
            _ret_var = ((TextInteractive)wrapper).GetUnderlineHeight();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_underline_height_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_text_underline_height_get_delegate efl_text_underline_height_get_static_delegate;


    private delegate  void efl_text_underline_height_set_delegate(System.IntPtr obj, System.IntPtr pd,   double height);


    public delegate  void efl_text_underline_height_set_api_delegate(System.IntPtr obj,   double height);
    public static Efl.Eo.FunctionWrapper<efl_text_underline_height_set_api_delegate> efl_text_underline_height_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_underline_height_set_api_delegate>(_Module, "efl_text_underline_height_set");
    private static  void underline_height_set(System.IntPtr obj, System.IntPtr pd,  double height)
   {
      Eina.Log.Debug("function efl_text_underline_height_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextInteractive)wrapper).SetUnderlineHeight( height);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_underline_height_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  height);
      }
   }
   private static efl_text_underline_height_set_delegate efl_text_underline_height_set_static_delegate;


    private delegate  void efl_text_underline_dashed_color_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  byte r,   out  byte g,   out  byte b,   out  byte a);


    public delegate  void efl_text_underline_dashed_color_get_api_delegate(System.IntPtr obj,   out  byte r,   out  byte g,   out  byte b,   out  byte a);
    public static Efl.Eo.FunctionWrapper<efl_text_underline_dashed_color_get_api_delegate> efl_text_underline_dashed_color_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_underline_dashed_color_get_api_delegate>(_Module, "efl_text_underline_dashed_color_get");
    private static  void underline_dashed_color_get(System.IntPtr obj, System.IntPtr pd,  out  byte r,  out  byte g,  out  byte b,  out  byte a)
   {
      Eina.Log.Debug("function efl_text_underline_dashed_color_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                       r = default( byte);      g = default( byte);      b = default( byte);      a = default( byte);                                 
         try {
            ((TextInteractive)wrapper).GetUnderlineDashedColor( out r,  out g,  out b,  out a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_text_underline_dashed_color_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out r,  out g,  out b,  out a);
      }
   }
   private static efl_text_underline_dashed_color_get_delegate efl_text_underline_dashed_color_get_static_delegate;


    private delegate  void efl_text_underline_dashed_color_set_delegate(System.IntPtr obj, System.IntPtr pd,    byte r,    byte g,    byte b,    byte a);


    public delegate  void efl_text_underline_dashed_color_set_api_delegate(System.IntPtr obj,    byte r,    byte g,    byte b,    byte a);
    public static Efl.Eo.FunctionWrapper<efl_text_underline_dashed_color_set_api_delegate> efl_text_underline_dashed_color_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_underline_dashed_color_set_api_delegate>(_Module, "efl_text_underline_dashed_color_set");
    private static  void underline_dashed_color_set(System.IntPtr obj, System.IntPtr pd,   byte r,   byte g,   byte b,   byte a)
   {
      Eina.Log.Debug("function efl_text_underline_dashed_color_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                          
         try {
            ((TextInteractive)wrapper).SetUnderlineDashedColor( r,  g,  b,  a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_text_underline_dashed_color_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  r,  g,  b,  a);
      }
   }
   private static efl_text_underline_dashed_color_set_delegate efl_text_underline_dashed_color_set_static_delegate;


    private delegate  int efl_text_underline_dashed_width_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  int efl_text_underline_dashed_width_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_text_underline_dashed_width_get_api_delegate> efl_text_underline_dashed_width_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_underline_dashed_width_get_api_delegate>(_Module, "efl_text_underline_dashed_width_get");
    private static  int underline_dashed_width_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_underline_dashed_width_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   int _ret_var = default( int);
         try {
            _ret_var = ((TextInteractive)wrapper).GetUnderlineDashedWidth();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_underline_dashed_width_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_text_underline_dashed_width_get_delegate efl_text_underline_dashed_width_get_static_delegate;


    private delegate  void efl_text_underline_dashed_width_set_delegate(System.IntPtr obj, System.IntPtr pd,    int width);


    public delegate  void efl_text_underline_dashed_width_set_api_delegate(System.IntPtr obj,    int width);
    public static Efl.Eo.FunctionWrapper<efl_text_underline_dashed_width_set_api_delegate> efl_text_underline_dashed_width_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_underline_dashed_width_set_api_delegate>(_Module, "efl_text_underline_dashed_width_set");
    private static  void underline_dashed_width_set(System.IntPtr obj, System.IntPtr pd,   int width)
   {
      Eina.Log.Debug("function efl_text_underline_dashed_width_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextInteractive)wrapper).SetUnderlineDashedWidth( width);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_underline_dashed_width_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  width);
      }
   }
   private static efl_text_underline_dashed_width_set_delegate efl_text_underline_dashed_width_set_static_delegate;


    private delegate  int efl_text_underline_dashed_gap_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  int efl_text_underline_dashed_gap_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_text_underline_dashed_gap_get_api_delegate> efl_text_underline_dashed_gap_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_underline_dashed_gap_get_api_delegate>(_Module, "efl_text_underline_dashed_gap_get");
    private static  int underline_dashed_gap_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_underline_dashed_gap_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   int _ret_var = default( int);
         try {
            _ret_var = ((TextInteractive)wrapper).GetUnderlineDashedGap();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_underline_dashed_gap_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_text_underline_dashed_gap_get_delegate efl_text_underline_dashed_gap_get_static_delegate;


    private delegate  void efl_text_underline_dashed_gap_set_delegate(System.IntPtr obj, System.IntPtr pd,    int gap);


    public delegate  void efl_text_underline_dashed_gap_set_api_delegate(System.IntPtr obj,    int gap);
    public static Efl.Eo.FunctionWrapper<efl_text_underline_dashed_gap_set_api_delegate> efl_text_underline_dashed_gap_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_underline_dashed_gap_set_api_delegate>(_Module, "efl_text_underline_dashed_gap_set");
    private static  void underline_dashed_gap_set(System.IntPtr obj, System.IntPtr pd,   int gap)
   {
      Eina.Log.Debug("function efl_text_underline_dashed_gap_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextInteractive)wrapper).SetUnderlineDashedGap( gap);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_underline_dashed_gap_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  gap);
      }
   }
   private static efl_text_underline_dashed_gap_set_delegate efl_text_underline_dashed_gap_set_static_delegate;


    private delegate  void efl_text_underline2_color_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  byte r,   out  byte g,   out  byte b,   out  byte a);


    public delegate  void efl_text_underline2_color_get_api_delegate(System.IntPtr obj,   out  byte r,   out  byte g,   out  byte b,   out  byte a);
    public static Efl.Eo.FunctionWrapper<efl_text_underline2_color_get_api_delegate> efl_text_underline2_color_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_underline2_color_get_api_delegate>(_Module, "efl_text_underline2_color_get");
    private static  void underline2_color_get(System.IntPtr obj, System.IntPtr pd,  out  byte r,  out  byte g,  out  byte b,  out  byte a)
   {
      Eina.Log.Debug("function efl_text_underline2_color_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                       r = default( byte);      g = default( byte);      b = default( byte);      a = default( byte);                                 
         try {
            ((TextInteractive)wrapper).GetUnderline2Color( out r,  out g,  out b,  out a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_text_underline2_color_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out r,  out g,  out b,  out a);
      }
   }
   private static efl_text_underline2_color_get_delegate efl_text_underline2_color_get_static_delegate;


    private delegate  void efl_text_underline2_color_set_delegate(System.IntPtr obj, System.IntPtr pd,    byte r,    byte g,    byte b,    byte a);


    public delegate  void efl_text_underline2_color_set_api_delegate(System.IntPtr obj,    byte r,    byte g,    byte b,    byte a);
    public static Efl.Eo.FunctionWrapper<efl_text_underline2_color_set_api_delegate> efl_text_underline2_color_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_underline2_color_set_api_delegate>(_Module, "efl_text_underline2_color_set");
    private static  void underline2_color_set(System.IntPtr obj, System.IntPtr pd,   byte r,   byte g,   byte b,   byte a)
   {
      Eina.Log.Debug("function efl_text_underline2_color_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                          
         try {
            ((TextInteractive)wrapper).SetUnderline2Color( r,  g,  b,  a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_text_underline2_color_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  r,  g,  b,  a);
      }
   }
   private static efl_text_underline2_color_set_delegate efl_text_underline2_color_set_static_delegate;


    private delegate Efl.TextStyleStrikethroughType efl_text_strikethrough_type_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Efl.TextStyleStrikethroughType efl_text_strikethrough_type_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_text_strikethrough_type_get_api_delegate> efl_text_strikethrough_type_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_strikethrough_type_get_api_delegate>(_Module, "efl_text_strikethrough_type_get");
    private static Efl.TextStyleStrikethroughType strikethrough_type_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_strikethrough_type_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.TextStyleStrikethroughType _ret_var = default(Efl.TextStyleStrikethroughType);
         try {
            _ret_var = ((TextInteractive)wrapper).GetStrikethroughType();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_strikethrough_type_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_text_strikethrough_type_get_delegate efl_text_strikethrough_type_get_static_delegate;


    private delegate  void efl_text_strikethrough_type_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextStyleStrikethroughType type);


    public delegate  void efl_text_strikethrough_type_set_api_delegate(System.IntPtr obj,   Efl.TextStyleStrikethroughType type);
    public static Efl.Eo.FunctionWrapper<efl_text_strikethrough_type_set_api_delegate> efl_text_strikethrough_type_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_strikethrough_type_set_api_delegate>(_Module, "efl_text_strikethrough_type_set");
    private static  void strikethrough_type_set(System.IntPtr obj, System.IntPtr pd,  Efl.TextStyleStrikethroughType type)
   {
      Eina.Log.Debug("function efl_text_strikethrough_type_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextInteractive)wrapper).SetStrikethroughType( type);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_strikethrough_type_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  type);
      }
   }
   private static efl_text_strikethrough_type_set_delegate efl_text_strikethrough_type_set_static_delegate;


    private delegate  void efl_text_strikethrough_color_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  byte r,   out  byte g,   out  byte b,   out  byte a);


    public delegate  void efl_text_strikethrough_color_get_api_delegate(System.IntPtr obj,   out  byte r,   out  byte g,   out  byte b,   out  byte a);
    public static Efl.Eo.FunctionWrapper<efl_text_strikethrough_color_get_api_delegate> efl_text_strikethrough_color_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_strikethrough_color_get_api_delegate>(_Module, "efl_text_strikethrough_color_get");
    private static  void strikethrough_color_get(System.IntPtr obj, System.IntPtr pd,  out  byte r,  out  byte g,  out  byte b,  out  byte a)
   {
      Eina.Log.Debug("function efl_text_strikethrough_color_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                       r = default( byte);      g = default( byte);      b = default( byte);      a = default( byte);                                 
         try {
            ((TextInteractive)wrapper).GetStrikethroughColor( out r,  out g,  out b,  out a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_text_strikethrough_color_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out r,  out g,  out b,  out a);
      }
   }
   private static efl_text_strikethrough_color_get_delegate efl_text_strikethrough_color_get_static_delegate;


    private delegate  void efl_text_strikethrough_color_set_delegate(System.IntPtr obj, System.IntPtr pd,    byte r,    byte g,    byte b,    byte a);


    public delegate  void efl_text_strikethrough_color_set_api_delegate(System.IntPtr obj,    byte r,    byte g,    byte b,    byte a);
    public static Efl.Eo.FunctionWrapper<efl_text_strikethrough_color_set_api_delegate> efl_text_strikethrough_color_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_strikethrough_color_set_api_delegate>(_Module, "efl_text_strikethrough_color_set");
    private static  void strikethrough_color_set(System.IntPtr obj, System.IntPtr pd,   byte r,   byte g,   byte b,   byte a)
   {
      Eina.Log.Debug("function efl_text_strikethrough_color_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                          
         try {
            ((TextInteractive)wrapper).SetStrikethroughColor( r,  g,  b,  a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_text_strikethrough_color_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  r,  g,  b,  a);
      }
   }
   private static efl_text_strikethrough_color_set_delegate efl_text_strikethrough_color_set_static_delegate;


    private delegate Efl.TextStyleEffectType efl_text_effect_type_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Efl.TextStyleEffectType efl_text_effect_type_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_text_effect_type_get_api_delegate> efl_text_effect_type_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_effect_type_get_api_delegate>(_Module, "efl_text_effect_type_get");
    private static Efl.TextStyleEffectType effect_type_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_effect_type_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.TextStyleEffectType _ret_var = default(Efl.TextStyleEffectType);
         try {
            _ret_var = ((TextInteractive)wrapper).GetEffectType();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_effect_type_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_text_effect_type_get_delegate efl_text_effect_type_get_static_delegate;


    private delegate  void efl_text_effect_type_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextStyleEffectType type);


    public delegate  void efl_text_effect_type_set_api_delegate(System.IntPtr obj,   Efl.TextStyleEffectType type);
    public static Efl.Eo.FunctionWrapper<efl_text_effect_type_set_api_delegate> efl_text_effect_type_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_effect_type_set_api_delegate>(_Module, "efl_text_effect_type_set");
    private static  void effect_type_set(System.IntPtr obj, System.IntPtr pd,  Efl.TextStyleEffectType type)
   {
      Eina.Log.Debug("function efl_text_effect_type_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextInteractive)wrapper).SetEffectType( type);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_effect_type_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  type);
      }
   }
   private static efl_text_effect_type_set_delegate efl_text_effect_type_set_static_delegate;


    private delegate  void efl_text_outline_color_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  byte r,   out  byte g,   out  byte b,   out  byte a);


    public delegate  void efl_text_outline_color_get_api_delegate(System.IntPtr obj,   out  byte r,   out  byte g,   out  byte b,   out  byte a);
    public static Efl.Eo.FunctionWrapper<efl_text_outline_color_get_api_delegate> efl_text_outline_color_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_outline_color_get_api_delegate>(_Module, "efl_text_outline_color_get");
    private static  void outline_color_get(System.IntPtr obj, System.IntPtr pd,  out  byte r,  out  byte g,  out  byte b,  out  byte a)
   {
      Eina.Log.Debug("function efl_text_outline_color_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                       r = default( byte);      g = default( byte);      b = default( byte);      a = default( byte);                                 
         try {
            ((TextInteractive)wrapper).GetOutlineColor( out r,  out g,  out b,  out a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_text_outline_color_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out r,  out g,  out b,  out a);
      }
   }
   private static efl_text_outline_color_get_delegate efl_text_outline_color_get_static_delegate;


    private delegate  void efl_text_outline_color_set_delegate(System.IntPtr obj, System.IntPtr pd,    byte r,    byte g,    byte b,    byte a);


    public delegate  void efl_text_outline_color_set_api_delegate(System.IntPtr obj,    byte r,    byte g,    byte b,    byte a);
    public static Efl.Eo.FunctionWrapper<efl_text_outline_color_set_api_delegate> efl_text_outline_color_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_outline_color_set_api_delegate>(_Module, "efl_text_outline_color_set");
    private static  void outline_color_set(System.IntPtr obj, System.IntPtr pd,   byte r,   byte g,   byte b,   byte a)
   {
      Eina.Log.Debug("function efl_text_outline_color_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                          
         try {
            ((TextInteractive)wrapper).SetOutlineColor( r,  g,  b,  a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_text_outline_color_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  r,  g,  b,  a);
      }
   }
   private static efl_text_outline_color_set_delegate efl_text_outline_color_set_static_delegate;


    private delegate Efl.TextStyleShadowDirection efl_text_shadow_direction_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Efl.TextStyleShadowDirection efl_text_shadow_direction_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_text_shadow_direction_get_api_delegate> efl_text_shadow_direction_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_shadow_direction_get_api_delegate>(_Module, "efl_text_shadow_direction_get");
    private static Efl.TextStyleShadowDirection shadow_direction_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_shadow_direction_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.TextStyleShadowDirection _ret_var = default(Efl.TextStyleShadowDirection);
         try {
            _ret_var = ((TextInteractive)wrapper).GetShadowDirection();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_shadow_direction_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_text_shadow_direction_get_delegate efl_text_shadow_direction_get_static_delegate;


    private delegate  void efl_text_shadow_direction_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextStyleShadowDirection type);


    public delegate  void efl_text_shadow_direction_set_api_delegate(System.IntPtr obj,   Efl.TextStyleShadowDirection type);
    public static Efl.Eo.FunctionWrapper<efl_text_shadow_direction_set_api_delegate> efl_text_shadow_direction_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_shadow_direction_set_api_delegate>(_Module, "efl_text_shadow_direction_set");
    private static  void shadow_direction_set(System.IntPtr obj, System.IntPtr pd,  Efl.TextStyleShadowDirection type)
   {
      Eina.Log.Debug("function efl_text_shadow_direction_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextInteractive)wrapper).SetShadowDirection( type);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_shadow_direction_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  type);
      }
   }
   private static efl_text_shadow_direction_set_delegate efl_text_shadow_direction_set_static_delegate;


    private delegate  void efl_text_shadow_color_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  byte r,   out  byte g,   out  byte b,   out  byte a);


    public delegate  void efl_text_shadow_color_get_api_delegate(System.IntPtr obj,   out  byte r,   out  byte g,   out  byte b,   out  byte a);
    public static Efl.Eo.FunctionWrapper<efl_text_shadow_color_get_api_delegate> efl_text_shadow_color_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_shadow_color_get_api_delegate>(_Module, "efl_text_shadow_color_get");
    private static  void shadow_color_get(System.IntPtr obj, System.IntPtr pd,  out  byte r,  out  byte g,  out  byte b,  out  byte a)
   {
      Eina.Log.Debug("function efl_text_shadow_color_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                       r = default( byte);      g = default( byte);      b = default( byte);      a = default( byte);                                 
         try {
            ((TextInteractive)wrapper).GetShadowColor( out r,  out g,  out b,  out a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_text_shadow_color_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out r,  out g,  out b,  out a);
      }
   }
   private static efl_text_shadow_color_get_delegate efl_text_shadow_color_get_static_delegate;


    private delegate  void efl_text_shadow_color_set_delegate(System.IntPtr obj, System.IntPtr pd,    byte r,    byte g,    byte b,    byte a);


    public delegate  void efl_text_shadow_color_set_api_delegate(System.IntPtr obj,    byte r,    byte g,    byte b,    byte a);
    public static Efl.Eo.FunctionWrapper<efl_text_shadow_color_set_api_delegate> efl_text_shadow_color_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_shadow_color_set_api_delegate>(_Module, "efl_text_shadow_color_set");
    private static  void shadow_color_set(System.IntPtr obj, System.IntPtr pd,   byte r,   byte g,   byte b,   byte a)
   {
      Eina.Log.Debug("function efl_text_shadow_color_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                          
         try {
            ((TextInteractive)wrapper).SetShadowColor( r,  g,  b,  a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_text_shadow_color_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  r,  g,  b,  a);
      }
   }
   private static efl_text_shadow_color_set_delegate efl_text_shadow_color_set_static_delegate;


    private delegate  void efl_text_glow_color_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  byte r,   out  byte g,   out  byte b,   out  byte a);


    public delegate  void efl_text_glow_color_get_api_delegate(System.IntPtr obj,   out  byte r,   out  byte g,   out  byte b,   out  byte a);
    public static Efl.Eo.FunctionWrapper<efl_text_glow_color_get_api_delegate> efl_text_glow_color_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_glow_color_get_api_delegate>(_Module, "efl_text_glow_color_get");
    private static  void glow_color_get(System.IntPtr obj, System.IntPtr pd,  out  byte r,  out  byte g,  out  byte b,  out  byte a)
   {
      Eina.Log.Debug("function efl_text_glow_color_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                       r = default( byte);      g = default( byte);      b = default( byte);      a = default( byte);                                 
         try {
            ((TextInteractive)wrapper).GetGlowColor( out r,  out g,  out b,  out a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_text_glow_color_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out r,  out g,  out b,  out a);
      }
   }
   private static efl_text_glow_color_get_delegate efl_text_glow_color_get_static_delegate;


    private delegate  void efl_text_glow_color_set_delegate(System.IntPtr obj, System.IntPtr pd,    byte r,    byte g,    byte b,    byte a);


    public delegate  void efl_text_glow_color_set_api_delegate(System.IntPtr obj,    byte r,    byte g,    byte b,    byte a);
    public static Efl.Eo.FunctionWrapper<efl_text_glow_color_set_api_delegate> efl_text_glow_color_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_glow_color_set_api_delegate>(_Module, "efl_text_glow_color_set");
    private static  void glow_color_set(System.IntPtr obj, System.IntPtr pd,   byte r,   byte g,   byte b,   byte a)
   {
      Eina.Log.Debug("function efl_text_glow_color_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                          
         try {
            ((TextInteractive)wrapper).SetGlowColor( r,  g,  b,  a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_text_glow_color_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  r,  g,  b,  a);
      }
   }
   private static efl_text_glow_color_set_delegate efl_text_glow_color_set_static_delegate;


    private delegate  void efl_text_glow2_color_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  byte r,   out  byte g,   out  byte b,   out  byte a);


    public delegate  void efl_text_glow2_color_get_api_delegate(System.IntPtr obj,   out  byte r,   out  byte g,   out  byte b,   out  byte a);
    public static Efl.Eo.FunctionWrapper<efl_text_glow2_color_get_api_delegate> efl_text_glow2_color_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_glow2_color_get_api_delegate>(_Module, "efl_text_glow2_color_get");
    private static  void glow2_color_get(System.IntPtr obj, System.IntPtr pd,  out  byte r,  out  byte g,  out  byte b,  out  byte a)
   {
      Eina.Log.Debug("function efl_text_glow2_color_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                       r = default( byte);      g = default( byte);      b = default( byte);      a = default( byte);                                 
         try {
            ((TextInteractive)wrapper).GetGlow2Color( out r,  out g,  out b,  out a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_text_glow2_color_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out r,  out g,  out b,  out a);
      }
   }
   private static efl_text_glow2_color_get_delegate efl_text_glow2_color_get_static_delegate;


    private delegate  void efl_text_glow2_color_set_delegate(System.IntPtr obj, System.IntPtr pd,    byte r,    byte g,    byte b,    byte a);


    public delegate  void efl_text_glow2_color_set_api_delegate(System.IntPtr obj,    byte r,    byte g,    byte b,    byte a);
    public static Efl.Eo.FunctionWrapper<efl_text_glow2_color_set_api_delegate> efl_text_glow2_color_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_glow2_color_set_api_delegate>(_Module, "efl_text_glow2_color_set");
    private static  void glow2_color_set(System.IntPtr obj, System.IntPtr pd,   byte r,   byte g,   byte b,   byte a)
   {
      Eina.Log.Debug("function efl_text_glow2_color_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                          
         try {
            ((TextInteractive)wrapper).SetGlow2Color( r,  g,  b,  a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_text_glow2_color_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  r,  g,  b,  a);
      }
   }
   private static efl_text_glow2_color_set_delegate efl_text_glow2_color_set_static_delegate;


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate  System.String efl_text_gfx_filter_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate  System.String efl_text_gfx_filter_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_text_gfx_filter_get_api_delegate> efl_text_gfx_filter_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_gfx_filter_get_api_delegate>(_Module, "efl_text_gfx_filter_get");
    private static  System.String gfx_filter_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_gfx_filter_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((TextInteractive)wrapper).GetGfxFilter();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_gfx_filter_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_text_gfx_filter_get_delegate efl_text_gfx_filter_get_static_delegate;


    private delegate  void efl_text_gfx_filter_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String code);


    public delegate  void efl_text_gfx_filter_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String code);
    public static Efl.Eo.FunctionWrapper<efl_text_gfx_filter_set_api_delegate> efl_text_gfx_filter_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_gfx_filter_set_api_delegate>(_Module, "efl_text_gfx_filter_set");
    private static  void gfx_filter_set(System.IntPtr obj, System.IntPtr pd,   System.String code)
   {
      Eina.Log.Debug("function efl_text_gfx_filter_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextInteractive)wrapper).SetGfxFilter( code);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_gfx_filter_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  code);
      }
   }
   private static efl_text_gfx_filter_set_delegate efl_text_gfx_filter_set_static_delegate;
}
} 
