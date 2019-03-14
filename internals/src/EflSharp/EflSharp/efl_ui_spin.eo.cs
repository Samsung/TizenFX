#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary>A Spin.
/// This is a widget which allows the user to increase or decrease numeric values using user interactions. It&apos;s a basic type of widget for choosing and displaying values.
/// 1.21</summary>
[SpinNativeInherit]
public class Spin : Efl.Ui.LayoutBase, Efl.Eo.IWrapper,Efl.Access.Value,Efl.Ui.Format,Efl.Ui.RangeDisplay,Efl.Ui.RangeInteractive
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Ui.SpinNativeInherit nativeInherit = new Efl.Ui.SpinNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (Spin))
            return Efl.Ui.SpinNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
      }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
      efl_ui_spin_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="style">The widget style to use. See <see cref="Efl.Ui.Widget.SetStyle"/></param>
   public Spin(Efl.Object parent
         ,  System.String style = null) :
      base(efl_ui_spin_class_get(), typeof(Spin), parent)
   {
      if (Efl.Eo.Globals.ParamHelperCheck(style))
         SetStyle(Efl.Eo.Globals.GetParamHelper(style));
      FinishInstantiation();
   }
   ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
   public Spin(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
   protected Spin(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static Spin static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new Spin(obj.NativeHandle);
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
   /// <summary>Called when spin changed
   /// 1.21</summary>
   public event EventHandler ChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_SPIN_EVENT_CHANGED";
            if (add_cpp_event_handler(efl.Libs.Elementary, key, this.evt_ChangedEvt_delegate)) {
               eventHandlers.AddHandler(ChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_SPIN_EVENT_CHANGED";
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

private static object MinReachedEvtKey = new object();
   /// <summary>Called when spin value reached min
   /// 1.21</summary>
   public event EventHandler MinReachedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_SPIN_EVENT_MIN_REACHED";
            if (add_cpp_event_handler(efl.Libs.Elementary, key, this.evt_MinReachedEvt_delegate)) {
               eventHandlers.AddHandler(MinReachedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_SPIN_EVENT_MIN_REACHED";
            if (remove_cpp_event_handler(key, this.evt_MinReachedEvt_delegate)) { 
               eventHandlers.RemoveHandler(MinReachedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event MinReachedEvt.</summary>
   public void On_MinReachedEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[MinReachedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_MinReachedEvt_delegate;
   private void on_MinReachedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_MinReachedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object MaxReachedEvtKey = new object();
   /// <summary>Called when spin value reached max
   /// 1.21</summary>
   public event EventHandler MaxReachedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_SPIN_EVENT_MAX_REACHED";
            if (add_cpp_event_handler(efl.Libs.Elementary, key, this.evt_MaxReachedEvt_delegate)) {
               eventHandlers.AddHandler(MaxReachedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_SPIN_EVENT_MAX_REACHED";
            if (remove_cpp_event_handler(key, this.evt_MaxReachedEvt_delegate)) { 
               eventHandlers.RemoveHandler(MaxReachedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event MaxReachedEvt.</summary>
   public void On_MaxReachedEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[MaxReachedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_MaxReachedEvt_delegate;
   private void on_MaxReachedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_MaxReachedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

   protected override void register_event_proxies()
   {
      base.register_event_proxies();
      evt_ChangedEvt_delegate = new Efl.EventCb(on_ChangedEvt_NativeCallback);
      evt_MinReachedEvt_delegate = new Efl.EventCb(on_MinReachedEvt_NativeCallback);
      evt_MaxReachedEvt_delegate = new Efl.EventCb(on_MaxReachedEvt_NativeCallback);
   }
   /// <summary>Control special string to display in the place of the numerical value.
   /// It&apos;s useful for cases when a user should select an item that is better indicated by a label than a value. For example, weekdays or months.
   /// 
   /// Note: If another label was previously set to <c>value</c>, it will be replaced by the new label.
   /// 1.21</summary>
   /// <returns>The array of special values, or NULL if none
   /// 1.21</returns>
   virtual public Eina.Array<Efl.Ui.SpinSpecialValue> GetSpecialValue() {
       var _ret_var = Efl.Ui.SpinNativeInherit.efl_ui_spin_special_value_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return new Eina.Array<Efl.Ui.SpinSpecialValue>(_ret_var, false, false);
 }
   /// <summary>Control special string to display in the place of the numerical value.
   /// It&apos;s useful for cases when a user should select an item that is better indicated by a label than a value. For example, weekdays or months.
   /// 
   /// Note: If another label was previously set to <c>value</c>, it will be replaced by the new label.
   /// 1.21</summary>
   /// <param name="values">The array of special values, or NULL if none
   /// 1.21</param>
   /// <returns></returns>
   virtual public  void SetSpecialValue( Eina.Array<Efl.Ui.SpinSpecialValue> values) {
       var _in_values = values.Handle;
                  Efl.Ui.SpinNativeInherit.efl_ui_spin_special_value_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), _in_values);
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
   /// <summary>Control the step used to increment or decrement values for given widget.
   /// This value will be incremented or decremented to the displayed value.
   /// 
   /// By default step value is equal to 1.
   /// 
   /// Warning: The step value should be bigger than 0.</summary>
   /// <returns>The step value.</returns>
   virtual public double GetRangeStep() {
       var _ret_var = Efl.Ui.RangeInteractiveNativeInherit.efl_ui_range_step_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Control the step used to increment or decrement values for given widget.
   /// This value will be incremented or decremented to the displayed value.
   /// 
   /// By default step value is equal to 1.
   /// 
   /// Warning: The step value should be bigger than 0.</summary>
   /// <param name="step">The step value.</param>
   /// <returns></returns>
   virtual public  void SetRangeStep( double step) {
                         Efl.Ui.RangeInteractiveNativeInherit.efl_ui_range_step_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), step);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Control special string to display in the place of the numerical value.
/// It&apos;s useful for cases when a user should select an item that is better indicated by a label than a value. For example, weekdays or months.
/// 
/// Note: If another label was previously set to <c>value</c>, it will be replaced by the new label.
/// 1.21</summary>
/// <value>The array of special values, or NULL if none
/// 1.21</value>
   public Eina.Array<Efl.Ui.SpinSpecialValue> SpecialValue {
      get { return GetSpecialValue(); }
      set { SetSpecialValue( value); }
   }
   /// <summary>Gets an minimal incrementation value</summary>
/// <value>Minimal incrementation value</value>
   public double Increment {
      get { return GetIncrement(); }
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
   /// <summary>Control the step used to increment or decrement values for given widget.
/// This value will be incremented or decremented to the displayed value.
/// 
/// By default step value is equal to 1.
/// 
/// Warning: The step value should be bigger than 0.</summary>
/// <value>The step value.</value>
   public double RangeStep {
      get { return GetRangeStep(); }
      set { SetRangeStep( value); }
   }
   private static new  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.Spin.efl_ui_spin_class_get();
   }
}
public class SpinNativeInherit : Efl.Ui.LayoutBaseNativeInherit{
   public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Elementary);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      if (efl_ui_spin_special_value_get_static_delegate == null)
      efl_ui_spin_special_value_get_static_delegate = new efl_ui_spin_special_value_get_delegate(special_value_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_spin_special_value_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_spin_special_value_get_static_delegate)});
      if (efl_ui_spin_special_value_set_static_delegate == null)
      efl_ui_spin_special_value_set_static_delegate = new efl_ui_spin_special_value_set_delegate(special_value_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_spin_special_value_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_spin_special_value_set_static_delegate)});
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
      if (efl_ui_range_step_get_static_delegate == null)
      efl_ui_range_step_get_static_delegate = new efl_ui_range_step_get_delegate(range_step_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_range_step_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_range_step_get_static_delegate)});
      if (efl_ui_range_step_set_static_delegate == null)
      efl_ui_range_step_set_static_delegate = new efl_ui_range_step_set_delegate(range_step_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_range_step_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_range_step_set_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Ui.Spin.efl_ui_spin_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.Spin.efl_ui_spin_class_get();
   }


    private delegate  System.IntPtr efl_ui_spin_special_value_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  System.IntPtr efl_ui_spin_special_value_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_spin_special_value_get_api_delegate> efl_ui_spin_special_value_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_spin_special_value_get_api_delegate>(_Module, "efl_ui_spin_special_value_get");
    private static  System.IntPtr special_value_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_spin_special_value_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Array<Efl.Ui.SpinSpecialValue> _ret_var = default(Eina.Array<Efl.Ui.SpinSpecialValue>);
         try {
            _ret_var = ((Spin)wrapper).GetSpecialValue();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var.Handle;
      } else {
         return efl_ui_spin_special_value_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_spin_special_value_get_delegate efl_ui_spin_special_value_get_static_delegate;


    private delegate  void efl_ui_spin_special_value_set_delegate(System.IntPtr obj, System.IntPtr pd,    System.IntPtr values);


    public delegate  void efl_ui_spin_special_value_set_api_delegate(System.IntPtr obj,    System.IntPtr values);
    public static Efl.Eo.FunctionWrapper<efl_ui_spin_special_value_set_api_delegate> efl_ui_spin_special_value_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_spin_special_value_set_api_delegate>(_Module, "efl_ui_spin_special_value_set");
    private static  void special_value_set(System.IntPtr obj, System.IntPtr pd,   System.IntPtr values)
   {
      Eina.Log.Debug("function efl_ui_spin_special_value_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_values = new Eina.Array<Efl.Ui.SpinSpecialValue>(values, false, false);
                     
         try {
            ((Spin)wrapper).SetSpecialValue( _in_values);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_spin_special_value_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  values);
      }
   }
   private static efl_ui_spin_special_value_set_delegate efl_ui_spin_special_value_set_static_delegate;


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
            ((Spin)wrapper).GetValueAndText( out value,  out _out_text);
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
            _ret_var = ((Spin)wrapper).SetValueAndText( value,  text);
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
            ((Spin)wrapper).GetRange( out lower_limit,  out upper_limit,  out _out_description);
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
            _ret_var = ((Spin)wrapper).GetIncrement();
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
            ((Spin)wrapper).SetFormatCb( func_wrapper.ManagedCb);
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
            _ret_var = ((Spin)wrapper).GetFormatString();
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
            ((Spin)wrapper).SetFormatString( units);
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
            _ret_var = ((Spin)wrapper).GetRangeValue();
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
            ((Spin)wrapper).SetRangeValue( val);
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
            ((Spin)wrapper).GetRangeMinMax( out min,  out max);
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
            ((Spin)wrapper).SetRangeMinMax( min,  max);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_ui_range_min_max_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  min,  max);
      }
   }
   private static efl_ui_range_min_max_set_delegate efl_ui_range_min_max_set_static_delegate;


    private delegate double efl_ui_range_step_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate double efl_ui_range_step_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_range_step_get_api_delegate> efl_ui_range_step_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_range_step_get_api_delegate>(_Module, "efl_ui_range_step_get");
    private static double range_step_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_range_step_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  double _ret_var = default(double);
         try {
            _ret_var = ((Spin)wrapper).GetRangeStep();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_range_step_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_range_step_get_delegate efl_ui_range_step_get_static_delegate;


    private delegate  void efl_ui_range_step_set_delegate(System.IntPtr obj, System.IntPtr pd,   double step);


    public delegate  void efl_ui_range_step_set_api_delegate(System.IntPtr obj,   double step);
    public static Efl.Eo.FunctionWrapper<efl_ui_range_step_set_api_delegate> efl_ui_range_step_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_range_step_set_api_delegate>(_Module, "efl_ui_range_step_set");
    private static  void range_step_set(System.IntPtr obj, System.IntPtr pd,  double step)
   {
      Eina.Log.Debug("function efl_ui_range_step_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Spin)wrapper).SetRangeStep( step);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_range_step_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  step);
      }
   }
   private static efl_ui_range_step_set_delegate efl_ui_range_step_set_static_delegate;
}
} } 
namespace Efl { namespace Ui { 
/// <summary>Special value</summary>
[StructLayout(LayoutKind.Sequential)]
public struct SpinSpecialValue
{
   /// <summary>Target value</summary>
   public double Value;
   /// <summary>String to replace</summary>
   public  System.String Label;
   ///<summary>Constructor for SpinSpecialValue.</summary>
   public SpinSpecialValue(
      double Value=default(double),
       System.String Label=default( System.String)   )
   {
      this.Value = Value;
      this.Label = Label;
   }
public static implicit operator SpinSpecialValue(IntPtr ptr)
   {
      var tmp = (SpinSpecialValue_StructInternal)Marshal.PtrToStructure(ptr, typeof(SpinSpecialValue_StructInternal));
      return SpinSpecialValue_StructConversion.ToManaged(tmp);
   }
}
///<summary>Internal wrapper for struct SpinSpecialValue.</summary>
[StructLayout(LayoutKind.Sequential)]
public struct SpinSpecialValue_StructInternal
{
   
   public double Value;
///<summary>Internal wrapper for field Label</summary>
public System.IntPtr Label;
   ///<summary>Implicit conversion to the internal/marshalling representation.</summary>
   public static implicit operator SpinSpecialValue(SpinSpecialValue_StructInternal struct_)
   {
      return SpinSpecialValue_StructConversion.ToManaged(struct_);
   }
   ///<summary>Implicit conversion to the managed representation.</summary>
   public static implicit operator SpinSpecialValue_StructInternal(SpinSpecialValue struct_)
   {
      return SpinSpecialValue_StructConversion.ToInternal(struct_);
   }
}
/// <summary>Conversion class for struct SpinSpecialValue</summary>
public static class SpinSpecialValue_StructConversion
{
   internal static SpinSpecialValue_StructInternal ToInternal(SpinSpecialValue _external_struct)
   {
      var _internal_struct = new SpinSpecialValue_StructInternal();

      _internal_struct.Value = _external_struct.Value;
      _internal_struct.Label = Eina.MemoryNative.StrDup(_external_struct.Label);

      return _internal_struct;
   }

   internal static SpinSpecialValue ToManaged(SpinSpecialValue_StructInternal _internal_struct)
   {
      var _external_struct = new SpinSpecialValue();

      _external_struct.Value = _internal_struct.Value;
      _external_struct.Label = Eina.StringConversion.NativeUtf8ToManagedString(_internal_struct.Label);

      return _external_struct;
   }

}
} } 
