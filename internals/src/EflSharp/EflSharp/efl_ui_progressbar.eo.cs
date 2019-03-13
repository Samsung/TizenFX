#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary>Elementary progressbar class</summary>
[ProgressbarNativeInherit]
public class Progressbar : Efl.Ui.LayoutBase, Efl.Eo.IWrapper,Efl.Content,Efl.Text,Efl.TextMarkup,Efl.Access.Value,Efl.Ui.Direction,Efl.Ui.Format,Efl.Ui.RangeDisplay
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Ui.ProgressbarNativeInherit nativeInherit = new Efl.Ui.ProgressbarNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (Progressbar))
            return Efl.Ui.ProgressbarNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
      }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
      efl_ui_progressbar_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="style">The widget style to use. See <see cref="Efl.Ui.Widget.SetStyle"/></param>
   public Progressbar(Efl.Object parent
         ,  System.String style = null) :
      base(efl_ui_progressbar_class_get(), typeof(Progressbar), parent)
   {
      if (Efl.Eo.Globals.ParamHelperCheck(style))
         SetStyle(Efl.Eo.Globals.GetParamHelper(style));
      FinishInstantiation();
   }
   ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
   public Progressbar(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
   protected Progressbar(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static Progressbar static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new Progressbar(obj.NativeHandle);
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
private static object ChangedEvtKey = new object();
   /// <summary>Called when progressbar changed</summary>
   public event EventHandler ChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_PROGRESSBAR_EVENT_CHANGED";
            if (add_cpp_event_handler(efl.Libs.Elementary, key, this.evt_ChangedEvt_delegate)) {
               eventHandlers.AddHandler(ChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_PROGRESSBAR_EVENT_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_ChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(ChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ChangedEvt.</summary>
   public void On_ChangedEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[ChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ChangedEvt_delegate;
   private void on_ChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_ChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object ContentChangedEvtKey = new object();
   /// <summary>Sent after the content is set or unset using the current content object.</summary>
   public event EventHandler<Efl.ContentContentChangedEvt_Args> ContentChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_CONTENT_EVENT_CONTENT_CHANGED";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_ContentChangedEvt_delegate)) {
               eventHandlers.AddHandler(ContentChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_CONTENT_EVENT_CONTENT_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_ContentChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(ContentChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ContentChangedEvt.</summary>
   public void On_ContentChangedEvt(Efl.ContentContentChangedEvt_Args e)
   {
      EventHandler<Efl.ContentContentChangedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.ContentContentChangedEvt_Args>)eventHandlers[ContentChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ContentChangedEvt_delegate;
   private void on_ContentChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.ContentContentChangedEvt_Args args = new Efl.ContentContentChangedEvt_Args();
      args.arg = new Efl.Gfx.EntityConcrete(evt.Info);
      try {
         On_ContentChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

   protected override void register_event_proxies()
   {
      base.register_event_proxies();
      evt_ChangedEvt_delegate = new Efl.EventCb(on_ChangedEvt_NativeCallback);
      evt_ContentChangedEvt_delegate = new Efl.EventCb(on_ContentChangedEvt_NativeCallback);
   }
   /// <summary>Control whether a given progress bar widget is at &quot;pulsing mode&quot; or not.
   /// By default progress bars display values from low to high boundaries. There are situations however in which the progress of a given task is unknown. In these cases, you can set a progress bar widget to a &quot;pulsing state&quot; to give the user an idea that some computation is being done without showing the precise progress rate. In the default theme, it will animate the bar with content, switching constantly between filling it and back to non-filled in a loop. To start and stop this pulsing animation you need to explicitly call efl_ui_progressbar_pulse_set().
   /// 1.20</summary>
   /// <returns><c>true</c> to put <c>obj</c> in pulsing mode, <c>false</c> to put it back to its default one</returns>
   virtual public bool GetPulseMode() {
       var _ret_var = Efl.Ui.ProgressbarNativeInherit.efl_ui_progressbar_pulse_mode_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Control whether a given progress bar widget is at &quot;pulsing mode&quot; or not.
   /// By default progress bars display values from low to high boundaries. There are situations however in which the progress of a given task is unknown. In these cases, you can set a progress bar widget to a &quot;pulsing state&quot; to give the user an idea that some computation is being done without showing the precise progress rate. In the default theme, it will animate the bar with content, switching constantly between filling it and back to non-filled in a loop. To start and stop this pulsing animation you need to explicitly call efl_ui_progressbar_pulse_set().
   /// 1.20</summary>
   /// <param name="pulse"><c>true</c> to put <c>obj</c> in pulsing mode, <c>false</c> to put it back to its default one</param>
   /// <returns></returns>
   virtual public  void SetPulseMode( bool pulse) {
                         Efl.Ui.ProgressbarNativeInherit.efl_ui_progressbar_pulse_mode_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), pulse);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Get the pulsing state on a given progressbar widget.
   /// 1.20</summary>
   /// <returns><c>true</c>, to start the pulsing animation, <c>false</c> to stop it</returns>
   virtual public bool GetPulse() {
       var _ret_var = Efl.Ui.ProgressbarNativeInherit.efl_ui_progressbar_pulse_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Start/stop a given progress bar &quot;pulsing&quot; animation, if its under that mode
   /// Note: This call won&apos;t do anything if <c>obj</c> is not under &quot;pulsing mode&quot;.
   /// 1.20</summary>
   /// <param name="state"><c>true</c>, to start the pulsing animation, <c>false</c> to stop it</param>
   /// <returns></returns>
   virtual public  void SetPulse( bool state) {
                         Efl.Ui.ProgressbarNativeInherit.efl_ui_progressbar_pulse_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), state);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Swallowed sub-object contained in this object.</summary>
   /// <returns>The object to swallow.</returns>
   virtual public Efl.Gfx.Entity GetContent() {
       var _ret_var = Efl.ContentNativeInherit.efl_content_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Swallowed sub-object contained in this object.</summary>
   /// <param name="content">The object to swallow.</param>
   /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
   virtual public bool SetContent( Efl.Gfx.Entity content) {
                         var _ret_var = Efl.ContentNativeInherit.efl_content_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), content);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Unswallow the object in the current container and return it.</summary>
   /// <returns>Unswallowed object</returns>
   virtual public Efl.Gfx.Entity UnsetContent() {
       var _ret_var = Efl.ContentNativeInherit.efl_content_unset_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Retrieves the text string currently being displayed by the given text object.
   /// Do not free() the return value.
   /// 
   /// See also <see cref="Efl.Text.GetText"/>.</summary>
   /// <returns>Text string to display on it.</returns>
   virtual public  System.String GetText() {
       var _ret_var = Efl.TextNativeInherit.efl_text_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Sets the text string to be displayed by the given text object.
   /// See also <see cref="Efl.Text.GetText"/>.</summary>
   /// <param name="text">Text string to display on it.</param>
   /// <returns></returns>
   virtual public  void SetText(  System.String text) {
                         Efl.TextNativeInherit.efl_text_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), text);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Markup property
   /// 1.21</summary>
   /// <returns>The markup-text representation set to this text.
   /// 1.21</returns>
   virtual public  System.String GetMarkup() {
       var _ret_var = Efl.TextMarkupNativeInherit.efl_text_markup_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Markup property
   /// 1.21</summary>
   /// <param name="markup">The markup-text representation set to this text.
   /// 1.21</param>
   /// <returns></returns>
   virtual public  void SetMarkup(  System.String markup) {
                         Efl.TextMarkupNativeInherit.efl_text_markup_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), markup);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Gets value displayed by a accessible widget.</summary>
   /// <param name="value">Value of widget casted to floating point number.</param>
   /// <param name="text">string describing value in given context eg. small, enough</param>
   /// <returns></returns>
   virtual public  void GetValueAndText( out double value,  out  System.String text) {
                                           Efl.Access.ValueNativeInherit.efl_access_value_and_text_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), out value,  out text);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Value and text property</summary>
   /// <param name="value">Value of widget casted to floating point number.</param>
   /// <param name="text">string describing value in given context eg. small, enough</param>
   /// <returns><c>true</c> if setting widgets value has succeeded, otherwise <c>false</c> .</returns>
   virtual public bool SetValueAndText( double value,   System.String text) {
                                           var _ret_var = Efl.Access.ValueNativeInherit.efl_access_value_and_text_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), value,  text);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }
   /// <summary>Gets a range of all possible values and its description</summary>
   /// <param name="lower_limit">Lower limit of the range</param>
   /// <param name="upper_limit">Upper limit of the range</param>
   /// <param name="description">Description of the range</param>
   /// <returns></returns>
   virtual public  void GetRange( out double lower_limit,  out double upper_limit,  out  System.String description) {
                                                             Efl.Access.ValueNativeInherit.efl_access_value_range_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), out lower_limit,  out upper_limit,  out description);
      Eina.Error.RaiseIfUnhandledException();
                                           }
   /// <summary>Gets an minimal incrementation value</summary>
   /// <returns>Minimal incrementation value</returns>
   virtual public double GetIncrement() {
       var _ret_var = Efl.Access.ValueNativeInherit.efl_access_value_increment_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Control the direction of a given widget.
   /// Use this function to change how your widget is to be disposed: vertically or horizontally or inverted vertically or inverted horizontally.
   /// 
   /// Mirroring as defined in <see cref="Efl.Ui.I18n"/> can invert the <c>horizontal</c> direction: it is <c>ltr</c> by default, but becomes <c>rtl</c> if the object is mirrored.</summary>
   /// <returns>Direction of the widget.</returns>
   virtual public Efl.Ui.Dir GetDirection() {
       var _ret_var = Efl.Ui.DirectionNativeInherit.efl_ui_direction_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Control the direction of a given widget.
   /// Use this function to change how your widget is to be disposed: vertically or horizontally or inverted vertically or inverted horizontally.
   /// 
   /// Mirroring as defined in <see cref="Efl.Ui.I18n"/> can invert the <c>horizontal</c> direction: it is <c>ltr</c> by default, but becomes <c>rtl</c> if the object is mirrored.</summary>
   /// <param name="dir">Direction of the widget.</param>
   /// <returns></returns>
   virtual public  void SetDirection( Efl.Ui.Dir dir) {
                         Efl.Ui.DirectionNativeInherit.efl_ui_direction_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), dir);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Set the format function pointer to format the string.</summary>
   /// <param name="func">The format function callback</param>
   /// <returns></returns>
   virtual public  void SetFormatCb( Efl.Ui.FormatFuncCb func) {
                   GCHandle func_handle = GCHandle.Alloc(func);
      Efl.Ui.FormatNativeInherit.efl_ui_format_cb_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),GCHandle.ToIntPtr(func_handle), Efl.Ui.FormatFuncCbWrapper.Cb, Efl.Eo.Globals.free_gchandle);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Control the format string for a given units label
   /// If <c>NULL</c> is passed to <c>format</c>, it will hide <c>obj</c>&apos;s units area completely. If not, it&apos;ll set the &lt;b&gt;format string&lt;/b&gt; for the units label text. The units label is provided as a floating point value, so the units text can display at most one floating point value. Note that the units label is optional. Use a format string such as &quot;%1.2f meters&quot; for example.
   /// 
   /// Note: The default format string is an integer percentage, as in $&quot;%.0f %%&quot;.</summary>
   /// <returns>The format string for <c>obj</c>&apos;s units label.</returns>
   virtual public  System.String GetFormatString() {
       var _ret_var = Efl.Ui.FormatNativeInherit.efl_ui_format_string_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Control the format string for a given units label
   /// If <c>NULL</c> is passed to <c>format</c>, it will hide <c>obj</c>&apos;s units area completely. If not, it&apos;ll set the &lt;b&gt;format string&lt;/b&gt; for the units label text. The units label is provided as a floating point value, so the units text can display at most one floating point value. Note that the units label is optional. Use a format string such as &quot;%1.2f meters&quot; for example.
   /// 
   /// Note: The default format string is an integer percentage, as in $&quot;%.0f %%&quot;.</summary>
   /// <param name="units">The format string for <c>obj</c>&apos;s units label.</param>
   /// <returns></returns>
   virtual public  void SetFormatString(  System.String units) {
                         Efl.Ui.FormatNativeInherit.efl_ui_format_string_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), units);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Control the range value (in percentage) on a given range widget
   /// Use this call to set range levels.
   /// 
   /// Note: If you pass a value out of the specified interval for <c>val</c>, it will be interpreted as the closest of the boundary values in the interval.</summary>
   /// <returns>The range value (must be between $0.0 and 1.0)</returns>
   virtual public double GetRangeValue() {
       var _ret_var = Efl.Ui.RangeDisplayNativeInherit.efl_ui_range_value_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Control the range value (in percentage) on a given range widget
   /// Use this call to set range levels.
   /// 
   /// Note: If you pass a value out of the specified interval for <c>val</c>, it will be interpreted as the closest of the boundary values in the interval.</summary>
   /// <param name="val">The range value (must be between $0.0 and 1.0)</param>
   /// <returns></returns>
   virtual public  void SetRangeValue( double val) {
                         Efl.Ui.RangeDisplayNativeInherit.efl_ui_range_value_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), val);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Get the minimum and maximum values of the given range widget.
   /// Note: If only one value is needed, the other pointer can be passed as <c>null</c>.</summary>
   /// <param name="min">The minimum value.</param>
   /// <param name="max">The maximum value.</param>
   /// <returns></returns>
   virtual public  void GetRangeMinMax( out double min,  out double max) {
                                           Efl.Ui.RangeDisplayNativeInherit.efl_ui_range_min_max_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), out min,  out max);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Set the minimum and maximum values for given range widget.
   /// Define the allowed range of values to be selected by the user.
   /// 
   /// If actual value is less than <c>min</c>, it will be updated to <c>min</c>. If it is bigger then <c>max</c>, will be updated to <c>max</c>. The actual value can be obtained with <see cref="Efl.Ui.RangeDisplay.GetRangeValue"/>
   /// 
   /// The minimum and maximum values may be different for each class.
   /// 
   /// Warning: maximum must be greater than minimum, otherwise behavior is undefined.</summary>
   /// <param name="min">The minimum value.</param>
   /// <param name="max">The maximum value.</param>
   /// <returns></returns>
   virtual public  void SetRangeMinMax( double min,  double max) {
                                           Efl.Ui.RangeDisplayNativeInherit.efl_ui_range_min_max_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), min,  max);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Control whether a given progress bar widget is at &quot;pulsing mode&quot; or not.
/// By default progress bars display values from low to high boundaries. There are situations however in which the progress of a given task is unknown. In these cases, you can set a progress bar widget to a &quot;pulsing state&quot; to give the user an idea that some computation is being done without showing the precise progress rate. In the default theme, it will animate the bar with content, switching constantly between filling it and back to non-filled in a loop. To start and stop this pulsing animation you need to explicitly call efl_ui_progressbar_pulse_set().
/// 1.20</summary>
/// <value><c>true</c> to put <c>obj</c> in pulsing mode, <c>false</c> to put it back to its default one</value>
   public bool PulseMode {
      get { return GetPulseMode(); }
      set { SetPulseMode( value); }
   }
   /// <summary>Get the pulsing state on a given progressbar widget.
/// 1.20</summary>
/// <value><c>true</c>, to start the pulsing animation, <c>false</c> to stop it</value>
   public bool Pulse {
      get { return GetPulse(); }
      set { SetPulse( value); }
   }
   /// <summary>Swallowed sub-object contained in this object.</summary>
/// <value>The object to swallow.</value>
   public Efl.Gfx.Entity Content {
      get { return GetContent(); }
      set { SetContent( value); }
   }
   /// <summary>Markup property
/// 1.21</summary>
/// <value>The markup-text representation set to this text.
/// 1.21</value>
   public  System.String Markup {
      get { return GetMarkup(); }
      set { SetMarkup( value); }
   }
   /// <summary>Gets an minimal incrementation value</summary>
/// <value>Minimal incrementation value</value>
   public double Increment {
      get { return GetIncrement(); }
   }
   /// <summary>Control the direction of a given widget.
/// Use this function to change how your widget is to be disposed: vertically or horizontally or inverted vertically or inverted horizontally.
/// 
/// Mirroring as defined in <see cref="Efl.Ui.I18n"/> can invert the <c>horizontal</c> direction: it is <c>ltr</c> by default, but becomes <c>rtl</c> if the object is mirrored.</summary>
/// <value>Direction of the widget.</value>
   public Efl.Ui.Dir Direction {
      get { return GetDirection(); }
      set { SetDirection( value); }
   }
   /// <summary>Set the format function pointer to format the string.</summary>
/// <value>The format function callback</value>
   public Efl.Ui.FormatFuncCb FormatCb {
      set { SetFormatCb( value); }
   }
   /// <summary>Control the format string for a given units label
/// If <c>NULL</c> is passed to <c>format</c>, it will hide <c>obj</c>&apos;s units area completely. If not, it&apos;ll set the &lt;b&gt;format string&lt;/b&gt; for the units label text. The units label is provided as a floating point value, so the units text can display at most one floating point value. Note that the units label is optional. Use a format string such as &quot;%1.2f meters&quot; for example.
/// 
/// Note: The default format string is an integer percentage, as in $&quot;%.0f %%&quot;.</summary>
/// <value>The format string for <c>obj</c>&apos;s units label.</value>
   public  System.String FormatString {
      get { return GetFormatString(); }
      set { SetFormatString( value); }
   }
   /// <summary>Control the range value (in percentage) on a given range widget
/// Use this call to set range levels.
/// 
/// Note: If you pass a value out of the specified interval for <c>val</c>, it will be interpreted as the closest of the boundary values in the interval.</summary>
/// <value>The range value (must be between $0.0 and 1.0)</value>
   public double RangeValue {
      get { return GetRangeValue(); }
      set { SetRangeValue( value); }
   }
   private static new  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.Progressbar.efl_ui_progressbar_class_get();
   }
}
public class ProgressbarNativeInherit : Efl.Ui.LayoutBaseNativeInherit{
   public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Elementary);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      if (efl_ui_progressbar_pulse_mode_get_static_delegate == null)
      efl_ui_progressbar_pulse_mode_get_static_delegate = new efl_ui_progressbar_pulse_mode_get_delegate(pulse_mode_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_progressbar_pulse_mode_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_progressbar_pulse_mode_get_static_delegate)});
      if (efl_ui_progressbar_pulse_mode_set_static_delegate == null)
      efl_ui_progressbar_pulse_mode_set_static_delegate = new efl_ui_progressbar_pulse_mode_set_delegate(pulse_mode_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_progressbar_pulse_mode_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_progressbar_pulse_mode_set_static_delegate)});
      if (efl_ui_progressbar_pulse_get_static_delegate == null)
      efl_ui_progressbar_pulse_get_static_delegate = new efl_ui_progressbar_pulse_get_delegate(pulse_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_progressbar_pulse_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_progressbar_pulse_get_static_delegate)});
      if (efl_ui_progressbar_pulse_set_static_delegate == null)
      efl_ui_progressbar_pulse_set_static_delegate = new efl_ui_progressbar_pulse_set_delegate(pulse_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_progressbar_pulse_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_progressbar_pulse_set_static_delegate)});
      if (efl_content_get_static_delegate == null)
      efl_content_get_static_delegate = new efl_content_get_delegate(content_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_content_get"), func = Marshal.GetFunctionPointerForDelegate(efl_content_get_static_delegate)});
      if (efl_content_set_static_delegate == null)
      efl_content_set_static_delegate = new efl_content_set_delegate(content_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_content_set"), func = Marshal.GetFunctionPointerForDelegate(efl_content_set_static_delegate)});
      if (efl_content_unset_static_delegate == null)
      efl_content_unset_static_delegate = new efl_content_unset_delegate(content_unset);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_content_unset"), func = Marshal.GetFunctionPointerForDelegate(efl_content_unset_static_delegate)});
      if (efl_text_get_static_delegate == null)
      efl_text_get_static_delegate = new efl_text_get_delegate(text_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_get_static_delegate)});
      if (efl_text_set_static_delegate == null)
      efl_text_set_static_delegate = new efl_text_set_delegate(text_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_set_static_delegate)});
      if (efl_text_markup_get_static_delegate == null)
      efl_text_markup_get_static_delegate = new efl_text_markup_get_delegate(markup_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_markup_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_markup_get_static_delegate)});
      if (efl_text_markup_set_static_delegate == null)
      efl_text_markup_set_static_delegate = new efl_text_markup_set_delegate(markup_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_markup_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_markup_set_static_delegate)});
      if (efl_access_value_and_text_get_static_delegate == null)
      efl_access_value_and_text_get_static_delegate = new efl_access_value_and_text_get_delegate(value_and_text_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_value_and_text_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_value_and_text_get_static_delegate)});
      if (efl_access_value_and_text_set_static_delegate == null)
      efl_access_value_and_text_set_static_delegate = new efl_access_value_and_text_set_delegate(value_and_text_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_value_and_text_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_value_and_text_set_static_delegate)});
      if (efl_access_value_range_get_static_delegate == null)
      efl_access_value_range_get_static_delegate = new efl_access_value_range_get_delegate(range_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_value_range_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_value_range_get_static_delegate)});
      if (efl_access_value_increment_get_static_delegate == null)
      efl_access_value_increment_get_static_delegate = new efl_access_value_increment_get_delegate(increment_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_value_increment_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_value_increment_get_static_delegate)});
      if (efl_ui_direction_get_static_delegate == null)
      efl_ui_direction_get_static_delegate = new efl_ui_direction_get_delegate(direction_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_direction_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_direction_get_static_delegate)});
      if (efl_ui_direction_set_static_delegate == null)
      efl_ui_direction_set_static_delegate = new efl_ui_direction_set_delegate(direction_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_direction_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_direction_set_static_delegate)});
      if (efl_ui_format_cb_set_static_delegate == null)
      efl_ui_format_cb_set_static_delegate = new efl_ui_format_cb_set_delegate(format_cb_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_format_cb_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_format_cb_set_static_delegate)});
      if (efl_ui_format_string_get_static_delegate == null)
      efl_ui_format_string_get_static_delegate = new efl_ui_format_string_get_delegate(format_string_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_format_string_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_format_string_get_static_delegate)});
      if (efl_ui_format_string_set_static_delegate == null)
      efl_ui_format_string_set_static_delegate = new efl_ui_format_string_set_delegate(format_string_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_format_string_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_format_string_set_static_delegate)});
      if (efl_ui_range_value_get_static_delegate == null)
      efl_ui_range_value_get_static_delegate = new efl_ui_range_value_get_delegate(range_value_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_range_value_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_range_value_get_static_delegate)});
      if (efl_ui_range_value_set_static_delegate == null)
      efl_ui_range_value_set_static_delegate = new efl_ui_range_value_set_delegate(range_value_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_range_value_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_range_value_set_static_delegate)});
      if (efl_ui_range_min_max_get_static_delegate == null)
      efl_ui_range_min_max_get_static_delegate = new efl_ui_range_min_max_get_delegate(range_min_max_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_range_min_max_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_range_min_max_get_static_delegate)});
      if (efl_ui_range_min_max_set_static_delegate == null)
      efl_ui_range_min_max_set_static_delegate = new efl_ui_range_min_max_set_delegate(range_min_max_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_range_min_max_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_range_min_max_set_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Ui.Progressbar.efl_ui_progressbar_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.Progressbar.efl_ui_progressbar_class_get();
   }


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_progressbar_pulse_mode_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_progressbar_pulse_mode_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_progressbar_pulse_mode_get_api_delegate> efl_ui_progressbar_pulse_mode_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_progressbar_pulse_mode_get_api_delegate>(_Module, "efl_ui_progressbar_pulse_mode_get");
    private static bool pulse_mode_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_progressbar_pulse_mode_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Progressbar)wrapper).GetPulseMode();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_progressbar_pulse_mode_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_progressbar_pulse_mode_get_delegate efl_ui_progressbar_pulse_mode_get_static_delegate;


    private delegate  void efl_ui_progressbar_pulse_mode_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool pulse);


    public delegate  void efl_ui_progressbar_pulse_mode_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool pulse);
    public static Efl.Eo.FunctionWrapper<efl_ui_progressbar_pulse_mode_set_api_delegate> efl_ui_progressbar_pulse_mode_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_progressbar_pulse_mode_set_api_delegate>(_Module, "efl_ui_progressbar_pulse_mode_set");
    private static  void pulse_mode_set(System.IntPtr obj, System.IntPtr pd,  bool pulse)
   {
      Eina.Log.Debug("function efl_ui_progressbar_pulse_mode_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Progressbar)wrapper).SetPulseMode( pulse);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_progressbar_pulse_mode_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  pulse);
      }
   }
   private static efl_ui_progressbar_pulse_mode_set_delegate efl_ui_progressbar_pulse_mode_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_progressbar_pulse_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_progressbar_pulse_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_progressbar_pulse_get_api_delegate> efl_ui_progressbar_pulse_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_progressbar_pulse_get_api_delegate>(_Module, "efl_ui_progressbar_pulse_get");
    private static bool pulse_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_progressbar_pulse_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Progressbar)wrapper).GetPulse();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_progressbar_pulse_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_progressbar_pulse_get_delegate efl_ui_progressbar_pulse_get_static_delegate;


    private delegate  void efl_ui_progressbar_pulse_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool state);


    public delegate  void efl_ui_progressbar_pulse_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool state);
    public static Efl.Eo.FunctionWrapper<efl_ui_progressbar_pulse_set_api_delegate> efl_ui_progressbar_pulse_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_progressbar_pulse_set_api_delegate>(_Module, "efl_ui_progressbar_pulse_set");
    private static  void pulse_set(System.IntPtr obj, System.IntPtr pd,  bool state)
   {
      Eina.Log.Debug("function efl_ui_progressbar_pulse_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Progressbar)wrapper).SetPulse( state);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_progressbar_pulse_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  state);
      }
   }
   private static efl_ui_progressbar_pulse_set_delegate efl_ui_progressbar_pulse_set_static_delegate;


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.Gfx.Entity efl_content_get_delegate(System.IntPtr obj, System.IntPtr pd);


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))] public delegate Efl.Gfx.Entity efl_content_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_content_get_api_delegate> efl_content_get_ptr = new Efl.Eo.FunctionWrapper<efl_content_get_api_delegate>(_Module, "efl_content_get");
    private static Efl.Gfx.Entity content_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_content_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Gfx.Entity _ret_var = default(Efl.Gfx.Entity);
         try {
            _ret_var = ((Progressbar)wrapper).GetContent();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_content_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_content_get_delegate efl_content_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_content_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity content);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_content_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity content);
    public static Efl.Eo.FunctionWrapper<efl_content_set_api_delegate> efl_content_set_ptr = new Efl.Eo.FunctionWrapper<efl_content_set_api_delegate>(_Module, "efl_content_set");
    private static bool content_set(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.Entity content)
   {
      Eina.Log.Debug("function efl_content_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((Progressbar)wrapper).SetContent( content);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_content_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  content);
      }
   }
   private static efl_content_set_delegate efl_content_set_static_delegate;


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.Gfx.Entity efl_content_unset_delegate(System.IntPtr obj, System.IntPtr pd);


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))] public delegate Efl.Gfx.Entity efl_content_unset_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_content_unset_api_delegate> efl_content_unset_ptr = new Efl.Eo.FunctionWrapper<efl_content_unset_api_delegate>(_Module, "efl_content_unset");
    private static Efl.Gfx.Entity content_unset(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_content_unset was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Gfx.Entity _ret_var = default(Efl.Gfx.Entity);
         try {
            _ret_var = ((Progressbar)wrapper).UnsetContent();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_content_unset_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_content_unset_delegate efl_content_unset_static_delegate;


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
            _ret_var = ((Progressbar)wrapper).GetText();
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
            ((Progressbar)wrapper).SetText( text);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  text);
      }
   }
   private static efl_text_set_delegate efl_text_set_static_delegate;


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate  System.String efl_text_markup_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate  System.String efl_text_markup_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_text_markup_get_api_delegate> efl_text_markup_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_markup_get_api_delegate>(_Module, "efl_text_markup_get");
    private static  System.String markup_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_markup_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((Progressbar)wrapper).GetMarkup();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_markup_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_text_markup_get_delegate efl_text_markup_get_static_delegate;


    private delegate  void efl_text_markup_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String markup);


    public delegate  void efl_text_markup_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String markup);
    public static Efl.Eo.FunctionWrapper<efl_text_markup_set_api_delegate> efl_text_markup_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_markup_set_api_delegate>(_Module, "efl_text_markup_set");
    private static  void markup_set(System.IntPtr obj, System.IntPtr pd,   System.String markup)
   {
      Eina.Log.Debug("function efl_text_markup_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Progressbar)wrapper).SetMarkup( markup);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_markup_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  markup);
      }
   }
   private static efl_text_markup_set_delegate efl_text_markup_set_static_delegate;


    private delegate  void efl_access_value_and_text_get_delegate(System.IntPtr obj, System.IntPtr pd,   out double value,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  out  System.String text);


    public delegate  void efl_access_value_and_text_get_api_delegate(System.IntPtr obj,   out double value,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  out  System.String text);
    public static Efl.Eo.FunctionWrapper<efl_access_value_and_text_get_api_delegate> efl_access_value_and_text_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_value_and_text_get_api_delegate>(_Module, "efl_access_value_and_text_get");
    private static  void value_and_text_get(System.IntPtr obj, System.IntPtr pd,  out double value,  out  System.String text)
   {
      Eina.Log.Debug("function efl_access_value_and_text_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           value = default(double);       System.String _out_text = default( System.String);
                     
         try {
            ((Progressbar)wrapper).GetValueAndText( out value,  out _out_text);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            text = _out_text;
                        } else {
         efl_access_value_and_text_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out value,  out text);
      }
   }
   private static efl_access_value_and_text_get_delegate efl_access_value_and_text_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_access_value_and_text_set_delegate(System.IntPtr obj, System.IntPtr pd,   double value,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String text);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_access_value_and_text_set_api_delegate(System.IntPtr obj,   double value,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String text);
    public static Efl.Eo.FunctionWrapper<efl_access_value_and_text_set_api_delegate> efl_access_value_and_text_set_ptr = new Efl.Eo.FunctionWrapper<efl_access_value_and_text_set_api_delegate>(_Module, "efl_access_value_and_text_set");
    private static bool value_and_text_set(System.IntPtr obj, System.IntPtr pd,  double value,   System.String text)
   {
      Eina.Log.Debug("function efl_access_value_and_text_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      bool _ret_var = default(bool);
         try {
            _ret_var = ((Progressbar)wrapper).SetValueAndText( value,  text);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_access_value_and_text_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  value,  text);
      }
   }
   private static efl_access_value_and_text_set_delegate efl_access_value_and_text_set_static_delegate;


    private delegate  void efl_access_value_range_get_delegate(System.IntPtr obj, System.IntPtr pd,   out double lower_limit,   out double upper_limit,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  out  System.String description);


    public delegate  void efl_access_value_range_get_api_delegate(System.IntPtr obj,   out double lower_limit,   out double upper_limit,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  out  System.String description);
    public static Efl.Eo.FunctionWrapper<efl_access_value_range_get_api_delegate> efl_access_value_range_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_value_range_get_api_delegate>(_Module, "efl_access_value_range_get");
    private static  void range_get(System.IntPtr obj, System.IntPtr pd,  out double lower_limit,  out double upper_limit,  out  System.String description)
   {
      Eina.Log.Debug("function efl_access_value_range_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                 lower_limit = default(double);      upper_limit = default(double);       System.String _out_description = default( System.String);
                           
         try {
            ((Progressbar)wrapper).GetRange( out lower_limit,  out upper_limit,  out _out_description);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  description = _out_description;
                              } else {
         efl_access_value_range_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out lower_limit,  out upper_limit,  out description);
      }
   }
   private static efl_access_value_range_get_delegate efl_access_value_range_get_static_delegate;


    private delegate double efl_access_value_increment_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate double efl_access_value_increment_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_access_value_increment_get_api_delegate> efl_access_value_increment_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_value_increment_get_api_delegate>(_Module, "efl_access_value_increment_get");
    private static double increment_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_value_increment_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  double _ret_var = default(double);
         try {
            _ret_var = ((Progressbar)wrapper).GetIncrement();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_access_value_increment_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_access_value_increment_get_delegate efl_access_value_increment_get_static_delegate;


    private delegate Efl.Ui.Dir efl_ui_direction_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Efl.Ui.Dir efl_ui_direction_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_direction_get_api_delegate> efl_ui_direction_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_direction_get_api_delegate>(_Module, "efl_ui_direction_get");
    private static Efl.Ui.Dir direction_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_direction_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Ui.Dir _ret_var = default(Efl.Ui.Dir);
         try {
            _ret_var = ((Progressbar)wrapper).GetDirection();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_direction_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_direction_get_delegate efl_ui_direction_get_static_delegate;


    private delegate  void efl_ui_direction_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.Dir dir);


    public delegate  void efl_ui_direction_set_api_delegate(System.IntPtr obj,   Efl.Ui.Dir dir);
    public static Efl.Eo.FunctionWrapper<efl_ui_direction_set_api_delegate> efl_ui_direction_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_direction_set_api_delegate>(_Module, "efl_ui_direction_set");
    private static  void direction_set(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.Dir dir)
   {
      Eina.Log.Debug("function efl_ui_direction_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Progressbar)wrapper).SetDirection( dir);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_direction_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  dir);
      }
   }
   private static efl_ui_direction_set_delegate efl_ui_direction_set_static_delegate;


    private delegate  void efl_ui_format_cb_set_delegate(System.IntPtr obj, System.IntPtr pd,  IntPtr func_data, Efl.Ui.FormatFuncCbInternal func, EinaFreeCb func_free_cb);


    public delegate  void efl_ui_format_cb_set_api_delegate(System.IntPtr obj,  IntPtr func_data, Efl.Ui.FormatFuncCbInternal func, EinaFreeCb func_free_cb);
    public static Efl.Eo.FunctionWrapper<efl_ui_format_cb_set_api_delegate> efl_ui_format_cb_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_format_cb_set_api_delegate>(_Module, "efl_ui_format_cb_set");
    private static  void format_cb_set(System.IntPtr obj, System.IntPtr pd, IntPtr func_data, Efl.Ui.FormatFuncCbInternal func, EinaFreeCb func_free_cb)
   {
      Eina.Log.Debug("function efl_ui_format_cb_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                              Efl.Ui.FormatFuncCbWrapper func_wrapper = new Efl.Ui.FormatFuncCbWrapper(func, func_data, func_free_cb);
         
         try {
            ((Progressbar)wrapper).SetFormatCb( func_wrapper.ManagedCb);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_format_cb_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), func_data, func, func_free_cb);
      }
   }
   private static efl_ui_format_cb_set_delegate efl_ui_format_cb_set_static_delegate;


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate  System.String efl_ui_format_string_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate  System.String efl_ui_format_string_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_format_string_get_api_delegate> efl_ui_format_string_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_format_string_get_api_delegate>(_Module, "efl_ui_format_string_get");
    private static  System.String format_string_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_format_string_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((Progressbar)wrapper).GetFormatString();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_format_string_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_format_string_get_delegate efl_ui_format_string_get_static_delegate;


    private delegate  void efl_ui_format_string_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String units);


    public delegate  void efl_ui_format_string_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String units);
    public static Efl.Eo.FunctionWrapper<efl_ui_format_string_set_api_delegate> efl_ui_format_string_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_format_string_set_api_delegate>(_Module, "efl_ui_format_string_set");
    private static  void format_string_set(System.IntPtr obj, System.IntPtr pd,   System.String units)
   {
      Eina.Log.Debug("function efl_ui_format_string_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Progressbar)wrapper).SetFormatString( units);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_format_string_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  units);
      }
   }
   private static efl_ui_format_string_set_delegate efl_ui_format_string_set_static_delegate;


    private delegate double efl_ui_range_value_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate double efl_ui_range_value_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_range_value_get_api_delegate> efl_ui_range_value_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_range_value_get_api_delegate>(_Module, "efl_ui_range_value_get");
    private static double range_value_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_range_value_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  double _ret_var = default(double);
         try {
            _ret_var = ((Progressbar)wrapper).GetRangeValue();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_range_value_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_range_value_get_delegate efl_ui_range_value_get_static_delegate;


    private delegate  void efl_ui_range_value_set_delegate(System.IntPtr obj, System.IntPtr pd,   double val);


    public delegate  void efl_ui_range_value_set_api_delegate(System.IntPtr obj,   double val);
    public static Efl.Eo.FunctionWrapper<efl_ui_range_value_set_api_delegate> efl_ui_range_value_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_range_value_set_api_delegate>(_Module, "efl_ui_range_value_set");
    private static  void range_value_set(System.IntPtr obj, System.IntPtr pd,  double val)
   {
      Eina.Log.Debug("function efl_ui_range_value_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Progressbar)wrapper).SetRangeValue( val);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_range_value_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  val);
      }
   }
   private static efl_ui_range_value_set_delegate efl_ui_range_value_set_static_delegate;


    private delegate  void efl_ui_range_min_max_get_delegate(System.IntPtr obj, System.IntPtr pd,   out double min,   out double max);


    public delegate  void efl_ui_range_min_max_get_api_delegate(System.IntPtr obj,   out double min,   out double max);
    public static Efl.Eo.FunctionWrapper<efl_ui_range_min_max_get_api_delegate> efl_ui_range_min_max_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_range_min_max_get_api_delegate>(_Module, "efl_ui_range_min_max_get");
    private static  void range_min_max_get(System.IntPtr obj, System.IntPtr pd,  out double min,  out double max)
   {
      Eina.Log.Debug("function efl_ui_range_min_max_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           min = default(double);      max = default(double);                     
         try {
            ((Progressbar)wrapper).GetRangeMinMax( out min,  out max);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_ui_range_min_max_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out min,  out max);
      }
   }
   private static efl_ui_range_min_max_get_delegate efl_ui_range_min_max_get_static_delegate;


    private delegate  void efl_ui_range_min_max_set_delegate(System.IntPtr obj, System.IntPtr pd,   double min,   double max);


    public delegate  void efl_ui_range_min_max_set_api_delegate(System.IntPtr obj,   double min,   double max);
    public static Efl.Eo.FunctionWrapper<efl_ui_range_min_max_set_api_delegate> efl_ui_range_min_max_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_range_min_max_set_api_delegate>(_Module, "efl_ui_range_min_max_set");
    private static  void range_min_max_set(System.IntPtr obj, System.IntPtr pd,  double min,  double max)
   {
      Eina.Log.Debug("function efl_ui_range_min_max_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((Progressbar)wrapper).SetRangeMinMax( min,  max);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_ui_range_min_max_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  min,  max);
      }
   }
   private static efl_ui_range_min_max_set_delegate efl_ui_range_min_max_set_static_delegate;
}
} } 
