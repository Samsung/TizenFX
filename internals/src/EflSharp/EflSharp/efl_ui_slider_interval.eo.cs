#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary>An interval slider.
/// This is a slider with two indicators.
/// 1.21</summary>
[SliderIntervalNativeInherit]
public class SliderInterval : Efl.Ui.Slider, Efl.Eo.IWrapper
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Ui.SliderIntervalNativeInherit nativeInherit = new Efl.Ui.SliderIntervalNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (SliderInterval))
            return Efl.Ui.SliderIntervalNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   ///<summary>Delegate for function to be called from inside the native constructor.</summary>
   public new delegate void ConstructingMethod(SliderInterval obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
      efl_ui_slider_interval_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="init_cb">Delegate to call constructing methods that should be run inside the constructor.</param>
   public SliderInterval(Efl.Object parent = null, ConstructingMethod init_cb=null) : base("SliderInterval", efl_ui_slider_interval_class_get(), typeof(SliderInterval), parent)
   {
      if (init_cb != null) {
         init_cb(this);
      }
      FinishInstantiation();
   }
   ///<summary>Internal constructor to forward the wrapper initialization to the root class.</summary>
   protected SliderInterval(String klass_name, IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(klass_name, base_klass, managed_type, parent) {}
   ///<summary>Constructs an instance from a native pointer.</summary>
   public SliderInterval(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static SliderInterval static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new SliderInterval(obj.NativeHandle);
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


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_slider_interval_value_get(System.IntPtr obj,   out double from,   out double to);
   /// <summary>Sets up position of two indicators at start and end position.
   /// 1.21</summary>
   /// <param name="from">interval minimum value
   /// 1.21</param>
   /// <param name="to">interval maximum value
   /// 1.21</param>
   /// <returns></returns>
   virtual public  void GetIntervalValue( out double from,  out double to) {
                                           efl_ui_slider_interval_value_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  out from,  out to);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_slider_interval_value_set(System.IntPtr obj,   double from,   double to);
   /// <summary>Sets up position of two indicators at start and end position.
   /// 1.21</summary>
   /// <param name="from">interval minimum value
   /// 1.21</param>
   /// <param name="to">interval maximum value
   /// 1.21</param>
   /// <returns></returns>
   virtual public  void SetIntervalValue( double from,  double to) {
                                           efl_ui_slider_interval_value_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  from,  to);
      Eina.Error.RaiseIfUnhandledException();
                               }
}
public class SliderIntervalNativeInherit : Efl.Ui.SliderNativeInherit{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_ui_slider_interval_value_get_static_delegate = new efl_ui_slider_interval_value_get_delegate(interval_value_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_slider_interval_value_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_slider_interval_value_get_static_delegate)});
      efl_ui_slider_interval_value_set_static_delegate = new efl_ui_slider_interval_value_set_delegate(interval_value_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_slider_interval_value_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_slider_interval_value_set_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Ui.SliderInterval.efl_ui_slider_interval_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.SliderInterval.efl_ui_slider_interval_class_get();
   }


    private delegate  void efl_ui_slider_interval_value_get_delegate(System.IntPtr obj, System.IntPtr pd,   out double from,   out double to);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_slider_interval_value_get(System.IntPtr obj,   out double from,   out double to);
    private static  void interval_value_get(System.IntPtr obj, System.IntPtr pd,  out double from,  out double to)
   {
      Eina.Log.Debug("function efl_ui_slider_interval_value_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           from = default(double);      to = default(double);                     
         try {
            ((SliderInterval)wrapper).GetIntervalValue( out from,  out to);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_ui_slider_interval_value_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out from,  out to);
      }
   }
   private efl_ui_slider_interval_value_get_delegate efl_ui_slider_interval_value_get_static_delegate;


    private delegate  void efl_ui_slider_interval_value_set_delegate(System.IntPtr obj, System.IntPtr pd,   double from,   double to);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_slider_interval_value_set(System.IntPtr obj,   double from,   double to);
    private static  void interval_value_set(System.IntPtr obj, System.IntPtr pd,  double from,  double to)
   {
      Eina.Log.Debug("function efl_ui_slider_interval_value_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((SliderInterval)wrapper).SetIntervalValue( from,  to);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_ui_slider_interval_value_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  from,  to);
      }
   }
   private efl_ui_slider_interval_value_set_delegate efl_ui_slider_interval_value_set_static_delegate;
}
} } 
