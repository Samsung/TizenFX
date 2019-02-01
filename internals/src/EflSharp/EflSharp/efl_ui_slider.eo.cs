#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary>Elementary slider class</summary>
[SliderNativeInherit]
public class Slider : Efl.Ui.Layout, Efl.Eo.IWrapper,Efl.Content,Efl.Access.Value,Efl.Ui.Direction,Efl.Ui.RangeDisplay,Efl.Ui.RangeInteractive
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Ui.SliderNativeInherit nativeInherit = new Efl.Ui.SliderNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (Slider))
            return Efl.Ui.SliderNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   ///<summary>Delegate for function to be called from inside the native constructor.</summary>
   public new delegate void ConstructingMethod(Slider obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
      efl_ui_slider_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="init_cb">Delegate to call constructing methods that should be run inside the constructor.</param>
   public Slider(Efl.Object parent = null, ConstructingMethod init_cb=null) : base("Slider", efl_ui_slider_class_get(), typeof(Slider), parent)
   {
      if (init_cb != null) {
         init_cb(this);
      }
      FinishInstantiation();
   }
   ///<summary>Internal constructor to forward the wrapper initialization to the root class.</summary>
   protected Slider(String klass_name, IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(klass_name, base_klass, managed_type, parent) {}
   ///<summary>Constructs an instance from a native pointer.</summary>
   public Slider(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static Slider static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new Slider(obj.NativeHandle);
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
   /// <summary>Called when slider changed</summary>
   public event EventHandler ChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_SLIDER_EVENT_CHANGED";
            if (add_cpp_event_handler(key, this.evt_ChangedEvt_delegate)) {
               eventHandlers.AddHandler(ChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_SLIDER_EVENT_CHANGED";
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

private static object DelayChangedEvtKey = new object();
   /// <summary>Called when delay changed</summary>
   public event EventHandler DelayChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_SLIDER_EVENT_DELAY_CHANGED";
            if (add_cpp_event_handler(key, this.evt_DelayChangedEvt_delegate)) {
               eventHandlers.AddHandler(DelayChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_SLIDER_EVENT_DELAY_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_DelayChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(DelayChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event DelayChangedEvt.</summary>
   public void On_DelayChangedEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[DelayChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_DelayChangedEvt_delegate;
   private void on_DelayChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_DelayChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object SliderDragStartEvtKey = new object();
   /// <summary>Called when slider drag started</summary>
   public event EventHandler SliderDragStartEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_SLIDER_EVENT_SLIDER_DRAG_START";
            if (add_cpp_event_handler(key, this.evt_SliderDragStartEvt_delegate)) {
               eventHandlers.AddHandler(SliderDragStartEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_SLIDER_EVENT_SLIDER_DRAG_START";
            if (remove_cpp_event_handler(key, this.evt_SliderDragStartEvt_delegate)) { 
               eventHandlers.RemoveHandler(SliderDragStartEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event SliderDragStartEvt.</summary>
   public void On_SliderDragStartEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[SliderDragStartEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_SliderDragStartEvt_delegate;
   private void on_SliderDragStartEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_SliderDragStartEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object SliderDragStopEvtKey = new object();
   /// <summary>Called when slider drag stopped</summary>
   public event EventHandler SliderDragStopEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_SLIDER_EVENT_SLIDER_DRAG_STOP";
            if (add_cpp_event_handler(key, this.evt_SliderDragStopEvt_delegate)) {
               eventHandlers.AddHandler(SliderDragStopEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_SLIDER_EVENT_SLIDER_DRAG_STOP";
            if (remove_cpp_event_handler(key, this.evt_SliderDragStopEvt_delegate)) { 
               eventHandlers.RemoveHandler(SliderDragStopEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event SliderDragStopEvt.</summary>
   public void On_SliderDragStopEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[SliderDragStopEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_SliderDragStopEvt_delegate;
   private void on_SliderDragStopEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_SliderDragStopEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

   protected override void register_event_proxies()
   {
      base.register_event_proxies();
      evt_ChangedEvt_delegate = new Efl.EventCb(on_ChangedEvt_NativeCallback);
      evt_DelayChangedEvt_delegate = new Efl.EventCb(on_DelayChangedEvt_NativeCallback);
      evt_SliderDragStartEvt_delegate = new Efl.EventCb(on_SliderDragStartEvt_NativeCallback);
      evt_SliderDragStopEvt_delegate = new Efl.EventCb(on_SliderDragStopEvt_NativeCallback);
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


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_access_value_and_text_get(System.IntPtr obj,   out double value,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  out  System.String text);
   /// <summary>Gets value displayed by a accessible widget.</summary>
   /// <param name="value">Value of widget casted to floating point number.</param>
   /// <param name="text">string describing value in given context eg. small, enough</param>
   /// <returns></returns>
   virtual public  void GetValueAndText( out double value,  out  System.String text) {
                                           efl_access_value_and_text_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  out value,  out text);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_access_value_and_text_set(System.IntPtr obj,   double value,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String text);
   /// <summary>Value and text property</summary>
   /// <param name="value">Value of widget casted to floating point number.</param>
   /// <param name="text">string describing value in given context eg. small, enough</param>
   /// <returns><c>true</c> if setting widgets value has succeeded, otherwise <c>false</c> .</returns>
   virtual public bool SetValueAndText( double value,   System.String text) {
                                           var _ret_var = efl_access_value_and_text_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  value,  text);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_access_value_range_get(System.IntPtr obj,   out double lower_limit,   out double upper_limit,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  out  System.String description);
   /// <summary>Gets a range of all possible values and its description</summary>
   /// <param name="lower_limit">Lower limit of the range</param>
   /// <param name="upper_limit">Upper limit of the range</param>
   /// <param name="description">Description of the range</param>
   /// <returns></returns>
   virtual public  void GetRange( out double lower_limit,  out double upper_limit,  out  System.String description) {
                                                             efl_access_value_range_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  out lower_limit,  out upper_limit,  out description);
      Eina.Error.RaiseIfUnhandledException();
                                           }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern double efl_access_value_increment_get(System.IntPtr obj);
   /// <summary>Gets an minimal incrementation value</summary>
   /// <returns>Minimal incrementation value</returns>
   virtual public double GetIncrement() {
       var _ret_var = efl_access_value_increment_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern Efl.Ui.Dir efl_ui_direction_get(System.IntPtr obj);
   /// <summary>Control the direction of a given widget.
   /// Use this function to change how your widget is to be disposed: vertically or horizontally or inverted vertically or inverted horizontally.
   /// 
   /// Mirroring as defined in <see cref="Efl.Ui.I18n"/> can invert the <c>horizontal</c> direction: it is <c>ltr</c> by default, but becomes <c>rtl</c> if the object is mirrored.</summary>
   /// <returns>Direction of the widget.</returns>
   virtual public Efl.Ui.Dir GetDirection() {
       var _ret_var = efl_ui_direction_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_ui_direction_set(System.IntPtr obj,   Efl.Ui.Dir dir);
   /// <summary>Control the direction of a given widget.
   /// Use this function to change how your widget is to be disposed: vertically or horizontally or inverted vertically or inverted horizontally.
   /// 
   /// Mirroring as defined in <see cref="Efl.Ui.I18n"/> can invert the <c>horizontal</c> direction: it is <c>ltr</c> by default, but becomes <c>rtl</c> if the object is mirrored.</summary>
   /// <param name="dir">Direction of the widget.</param>
   /// <returns></returns>
   virtual public  void SetDirection( Efl.Ui.Dir dir) {
                         efl_ui_direction_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  dir);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern double efl_ui_range_value_get(System.IntPtr obj);
   /// <summary>Control the range value (in percentage) on a given range widget
   /// Use this call to set range levels.
   /// 
   /// Note: If you pass a value out of the specified interval for <c>val</c>, it will be interpreted as the closest of the boundary values in the interval.</summary>
   /// <returns>The range value (must be between $0.0 and 1.0)</returns>
   virtual public double GetRangeValue() {
       var _ret_var = efl_ui_range_value_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_ui_range_value_set(System.IntPtr obj,   double val);
   /// <summary>Control the range value (in percentage) on a given range widget
   /// Use this call to set range levels.
   /// 
   /// Note: If you pass a value out of the specified interval for <c>val</c>, it will be interpreted as the closest of the boundary values in the interval.</summary>
   /// <param name="val">The range value (must be between $0.0 and 1.0)</param>
   /// <returns></returns>
   virtual public  void SetRangeValue( double val) {
                         efl_ui_range_value_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  val);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_ui_range_min_max_get(System.IntPtr obj,   out double min,   out double max);
   /// <summary>Get the minimum and maximum values of the given range widget.
   /// Note: If only one value is needed, the other pointer can be passed as <c>null</c>.</summary>
   /// <param name="min">The minimum value.</param>
   /// <param name="max">The maximum value.</param>
   /// <returns></returns>
   virtual public  void GetRangeMinMax( out double min,  out double max) {
                                           efl_ui_range_min_max_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  out min,  out max);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_ui_range_min_max_set(System.IntPtr obj,   double min,   double max);
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
                                           efl_ui_range_min_max_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  min,  max);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern double efl_ui_range_step_get(System.IntPtr obj);
   /// <summary>Control the step used to increment or decrement values for given widget.
   /// This value will be incremented or decremented to the displayed value.
   /// 
   /// By default step value is equal to 1.
   /// 
   /// Warning: The step value should be bigger than 0.</summary>
   /// <returns>The step value.</returns>
   virtual public double GetRangeStep() {
       var _ret_var = efl_ui_range_step_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_ui_range_step_set(System.IntPtr obj,   double step);
   /// <summary>Control the step used to increment or decrement values for given widget.
   /// This value will be incremented or decremented to the displayed value.
   /// 
   /// By default step value is equal to 1.
   /// 
   /// Warning: The step value should be bigger than 0.</summary>
   /// <param name="step">The step value.</param>
   /// <returns></returns>
   virtual public  void SetRangeStep( double step) {
                         efl_ui_range_step_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  step);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Swallowed sub-object contained in this object.</summary>
   public Efl.Gfx.Entity Content {
      get { return GetContent(); }
      set { SetContent( value); }
   }
   /// <summary>Gets an minimal incrementation value</summary>
   public double Increment {
      get { return GetIncrement(); }
   }
   /// <summary>Control the direction of a given widget.
/// Use this function to change how your widget is to be disposed: vertically or horizontally or inverted vertically or inverted horizontally.
/// 
/// Mirroring as defined in <see cref="Efl.Ui.I18n"/> can invert the <c>horizontal</c> direction: it is <c>ltr</c> by default, but becomes <c>rtl</c> if the object is mirrored.</summary>
   public Efl.Ui.Dir Direction {
      get { return GetDirection(); }
      set { SetDirection( value); }
   }
   /// <summary>Control the range value (in percentage) on a given range widget
/// Use this call to set range levels.
/// 
/// Note: If you pass a value out of the specified interval for <c>val</c>, it will be interpreted as the closest of the boundary values in the interval.</summary>
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
   public double RangeStep {
      get { return GetRangeStep(); }
      set { SetRangeStep( value); }
   }
}
public class SliderNativeInherit : Efl.Ui.LayoutNativeInherit{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_content_get_static_delegate = new efl_content_get_delegate(content_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_content_get"), func = Marshal.GetFunctionPointerForDelegate(efl_content_get_static_delegate)});
      efl_content_set_static_delegate = new efl_content_set_delegate(content_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_content_set"), func = Marshal.GetFunctionPointerForDelegate(efl_content_set_static_delegate)});
      efl_content_unset_static_delegate = new efl_content_unset_delegate(content_unset);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_content_unset"), func = Marshal.GetFunctionPointerForDelegate(efl_content_unset_static_delegate)});
      efl_access_value_and_text_get_static_delegate = new efl_access_value_and_text_get_delegate(value_and_text_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_value_and_text_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_value_and_text_get_static_delegate)});
      efl_access_value_and_text_set_static_delegate = new efl_access_value_and_text_set_delegate(value_and_text_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_value_and_text_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_value_and_text_set_static_delegate)});
      efl_access_value_range_get_static_delegate = new efl_access_value_range_get_delegate(range_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_value_range_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_value_range_get_static_delegate)});
      efl_access_value_increment_get_static_delegate = new efl_access_value_increment_get_delegate(increment_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_value_increment_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_value_increment_get_static_delegate)});
      efl_ui_direction_get_static_delegate = new efl_ui_direction_get_delegate(direction_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_direction_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_direction_get_static_delegate)});
      efl_ui_direction_set_static_delegate = new efl_ui_direction_set_delegate(direction_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_direction_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_direction_set_static_delegate)});
      efl_ui_range_value_get_static_delegate = new efl_ui_range_value_get_delegate(range_value_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_range_value_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_range_value_get_static_delegate)});
      efl_ui_range_value_set_static_delegate = new efl_ui_range_value_set_delegate(range_value_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_range_value_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_range_value_set_static_delegate)});
      efl_ui_range_min_max_get_static_delegate = new efl_ui_range_min_max_get_delegate(range_min_max_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_range_min_max_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_range_min_max_get_static_delegate)});
      efl_ui_range_min_max_set_static_delegate = new efl_ui_range_min_max_set_delegate(range_min_max_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_range_min_max_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_range_min_max_set_static_delegate)});
      efl_ui_range_step_get_static_delegate = new efl_ui_range_step_get_delegate(range_step_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_range_step_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_range_step_get_static_delegate)});
      efl_ui_range_step_set_static_delegate = new efl_ui_range_step_set_delegate(range_step_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_range_step_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_range_step_set_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Ui.Slider.efl_ui_slider_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.Slider.efl_ui_slider_class_get();
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
            _ret_var = ((Slider)wrapper).GetContent();
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
            _ret_var = ((Slider)wrapper).SetContent( content);
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
            _ret_var = ((Slider)wrapper).UnsetContent();
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


    private delegate  void efl_access_value_and_text_get_delegate(System.IntPtr obj, System.IntPtr pd,   out double value,   out  System.IntPtr text);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_access_value_and_text_get(System.IntPtr obj,   out double value,   out  System.IntPtr text);
    private static  void value_and_text_get(System.IntPtr obj, System.IntPtr pd,  out double value,  out  System.IntPtr text)
   {
      Eina.Log.Debug("function efl_access_value_and_text_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           value = default(double);       System.String _out_text = default( System.String);
                     
         try {
            ((Slider)wrapper).GetValueAndText( out value,  out _out_text);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            text= Efl.Eo.Globals.cached_string_to_intptr(((Slider)wrapper).cached_strings, _out_text);
                        } else {
         efl_access_value_and_text_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out value,  out text);
      }
   }
   private efl_access_value_and_text_get_delegate efl_access_value_and_text_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_access_value_and_text_set_delegate(System.IntPtr obj, System.IntPtr pd,   double value,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String text);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_access_value_and_text_set(System.IntPtr obj,   double value,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String text);
    private static bool value_and_text_set(System.IntPtr obj, System.IntPtr pd,  double value,   System.String text)
   {
      Eina.Log.Debug("function efl_access_value_and_text_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      bool _ret_var = default(bool);
         try {
            _ret_var = ((Slider)wrapper).SetValueAndText( value,  text);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_access_value_and_text_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  value,  text);
      }
   }
   private efl_access_value_and_text_set_delegate efl_access_value_and_text_set_static_delegate;


    private delegate  void efl_access_value_range_get_delegate(System.IntPtr obj, System.IntPtr pd,   out double lower_limit,   out double upper_limit,   out  System.IntPtr description);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_access_value_range_get(System.IntPtr obj,   out double lower_limit,   out double upper_limit,   out  System.IntPtr description);
    private static  void range_get(System.IntPtr obj, System.IntPtr pd,  out double lower_limit,  out double upper_limit,  out  System.IntPtr description)
   {
      Eina.Log.Debug("function efl_access_value_range_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                 lower_limit = default(double);      upper_limit = default(double);       System.String _out_description = default( System.String);
                           
         try {
            ((Slider)wrapper).GetRange( out lower_limit,  out upper_limit,  out _out_description);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  description= Efl.Eo.Globals.cached_string_to_intptr(((Slider)wrapper).cached_strings, _out_description);
                              } else {
         efl_access_value_range_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out lower_limit,  out upper_limit,  out description);
      }
   }
   private efl_access_value_range_get_delegate efl_access_value_range_get_static_delegate;


    private delegate double efl_access_value_increment_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern double efl_access_value_increment_get(System.IntPtr obj);
    private static double increment_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_value_increment_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  double _ret_var = default(double);
         try {
            _ret_var = ((Slider)wrapper).GetIncrement();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_access_value_increment_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_access_value_increment_get_delegate efl_access_value_increment_get_static_delegate;


    private delegate Efl.Ui.Dir efl_ui_direction_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Efl.Ui.Dir efl_ui_direction_get(System.IntPtr obj);
    private static Efl.Ui.Dir direction_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_direction_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Ui.Dir _ret_var = default(Efl.Ui.Dir);
         try {
            _ret_var = ((Slider)wrapper).GetDirection();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_direction_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_direction_get_delegate efl_ui_direction_get_static_delegate;


    private delegate  void efl_ui_direction_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.Dir dir);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_ui_direction_set(System.IntPtr obj,   Efl.Ui.Dir dir);
    private static  void direction_set(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.Dir dir)
   {
      Eina.Log.Debug("function efl_ui_direction_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Slider)wrapper).SetDirection( dir);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_direction_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  dir);
      }
   }
   private efl_ui_direction_set_delegate efl_ui_direction_set_static_delegate;


    private delegate double efl_ui_range_value_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern double efl_ui_range_value_get(System.IntPtr obj);
    private static double range_value_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_range_value_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  double _ret_var = default(double);
         try {
            _ret_var = ((Slider)wrapper).GetRangeValue();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_range_value_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_range_value_get_delegate efl_ui_range_value_get_static_delegate;


    private delegate  void efl_ui_range_value_set_delegate(System.IntPtr obj, System.IntPtr pd,   double val);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_ui_range_value_set(System.IntPtr obj,   double val);
    private static  void range_value_set(System.IntPtr obj, System.IntPtr pd,  double val)
   {
      Eina.Log.Debug("function efl_ui_range_value_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Slider)wrapper).SetRangeValue( val);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_range_value_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  val);
      }
   }
   private efl_ui_range_value_set_delegate efl_ui_range_value_set_static_delegate;


    private delegate  void efl_ui_range_min_max_get_delegate(System.IntPtr obj, System.IntPtr pd,   out double min,   out double max);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_ui_range_min_max_get(System.IntPtr obj,   out double min,   out double max);
    private static  void range_min_max_get(System.IntPtr obj, System.IntPtr pd,  out double min,  out double max)
   {
      Eina.Log.Debug("function efl_ui_range_min_max_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           min = default(double);      max = default(double);                     
         try {
            ((Slider)wrapper).GetRangeMinMax( out min,  out max);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_ui_range_min_max_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out min,  out max);
      }
   }
   private efl_ui_range_min_max_get_delegate efl_ui_range_min_max_get_static_delegate;


    private delegate  void efl_ui_range_min_max_set_delegate(System.IntPtr obj, System.IntPtr pd,   double min,   double max);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_ui_range_min_max_set(System.IntPtr obj,   double min,   double max);
    private static  void range_min_max_set(System.IntPtr obj, System.IntPtr pd,  double min,  double max)
   {
      Eina.Log.Debug("function efl_ui_range_min_max_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((Slider)wrapper).SetRangeMinMax( min,  max);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_ui_range_min_max_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  min,  max);
      }
   }
   private efl_ui_range_min_max_set_delegate efl_ui_range_min_max_set_static_delegate;


    private delegate double efl_ui_range_step_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern double efl_ui_range_step_get(System.IntPtr obj);
    private static double range_step_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_range_step_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  double _ret_var = default(double);
         try {
            _ret_var = ((Slider)wrapper).GetRangeStep();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_range_step_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_range_step_get_delegate efl_ui_range_step_get_static_delegate;


    private delegate  void efl_ui_range_step_set_delegate(System.IntPtr obj, System.IntPtr pd,   double step);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_ui_range_step_set(System.IntPtr obj,   double step);
    private static  void range_step_set(System.IntPtr obj, System.IntPtr pd,  double step)
   {
      Eina.Log.Debug("function efl_ui_range_step_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Slider)wrapper).SetRangeStep( step);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_range_step_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  step);
      }
   }
   private efl_ui_range_step_set_delegate efl_ui_range_step_set_static_delegate;
}
} } 
