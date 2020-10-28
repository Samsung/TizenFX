#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary>An interval slider.
/// This is a slider with two indicators.</summary>
[SliderIntervalNativeInherit]
public class SliderInterval : Efl.Ui.Slider, Efl.Eo.IWrapper
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (SliderInterval))
                return Efl.Ui.SliderIntervalNativeInherit.GetEflClassStatic();
            else
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
        }
    }
    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_ui_slider_interval_class_get();
    ///<summary>Creates a new instance.</summary>
    ///<param name="parent">Parent instance.</param>
    ///<param name="style">The widget style to use. See <see cref="Efl.Ui.Widget.SetStyle"/></param>
    public SliderInterval(Efl.Object parent
            , System.String style = null) :
        base(efl_ui_slider_interval_class_get(), typeof(SliderInterval), parent)
    {
        if (Efl.Eo.Globals.ParamHelperCheck(style))
            SetStyle(Efl.Eo.Globals.GetParamHelper(style));
        FinishInstantiation();
    }
    ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    protected SliderInterval(System.IntPtr raw) : base(raw)
    {
                RegisterEventProxies();
    }
    ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    protected SliderInterval(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
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
    protected override void RegisterEventProxies()
    {
        base.RegisterEventProxies();
    }
    /// <summary>Sets up position of two indicators at start and end position.</summary>
    /// <param name="from">interval minimum value</param>
    /// <param name="to">interval maximum value</param>
    /// <returns></returns>
    virtual public void GetIntervalValue( out double from,  out double to) {
                                                         Efl.Ui.SliderIntervalNativeInherit.efl_ui_slider_interval_value_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), out from,  out to);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Sets up position of two indicators at start and end position.</summary>
    /// <param name="from">interval minimum value</param>
    /// <param name="to">interval maximum value</param>
    /// <returns></returns>
    virtual public void SetIntervalValue( double from,  double to) {
                                                         Efl.Ui.SliderIntervalNativeInherit.efl_ui_slider_interval_value_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), from,  to);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.SliderInterval.efl_ui_slider_interval_class_get();
    }
}
public class SliderIntervalNativeInherit : Efl.Ui.SliderNativeInherit{
    public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Elementary);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
        if (efl_ui_slider_interval_value_get_static_delegate == null)
            efl_ui_slider_interval_value_get_static_delegate = new efl_ui_slider_interval_value_get_delegate(interval_value_get);
        if (methods.FirstOrDefault(m => m.Name == "GetIntervalValue") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_slider_interval_value_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_slider_interval_value_get_static_delegate)});
        if (efl_ui_slider_interval_value_set_static_delegate == null)
            efl_ui_slider_interval_value_set_static_delegate = new efl_ui_slider_interval_value_set_delegate(interval_value_set);
        if (methods.FirstOrDefault(m => m.Name == "SetIntervalValue") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_slider_interval_value_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_slider_interval_value_set_static_delegate)});
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


     private delegate void efl_ui_slider_interval_value_get_delegate(System.IntPtr obj, System.IntPtr pd,   out double from,   out double to);


     public delegate void efl_ui_slider_interval_value_get_api_delegate(System.IntPtr obj,   out double from,   out double to);
     public static Efl.Eo.FunctionWrapper<efl_ui_slider_interval_value_get_api_delegate> efl_ui_slider_interval_value_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_slider_interval_value_get_api_delegate>(_Module, "efl_ui_slider_interval_value_get");
     private static void interval_value_get(System.IntPtr obj, System.IntPtr pd,  out double from,  out double to)
    {
        Eina.Log.Debug("function efl_ui_slider_interval_value_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                    from = default(double);        to = default(double);                            
            try {
                ((SliderInterval)wrapper).GetIntervalValue( out from,  out to);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                } else {
            efl_ui_slider_interval_value_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out from,  out to);
        }
    }
    private static efl_ui_slider_interval_value_get_delegate efl_ui_slider_interval_value_get_static_delegate;


     private delegate void efl_ui_slider_interval_value_set_delegate(System.IntPtr obj, System.IntPtr pd,   double from,   double to);


     public delegate void efl_ui_slider_interval_value_set_api_delegate(System.IntPtr obj,   double from,   double to);
     public static Efl.Eo.FunctionWrapper<efl_ui_slider_interval_value_set_api_delegate> efl_ui_slider_interval_value_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_slider_interval_value_set_api_delegate>(_Module, "efl_ui_slider_interval_value_set");
     private static void interval_value_set(System.IntPtr obj, System.IntPtr pd,  double from,  double to)
    {
        Eina.Log.Debug("function efl_ui_slider_interval_value_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                        
            try {
                ((SliderInterval)wrapper).SetIntervalValue( from,  to);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                } else {
            efl_ui_slider_interval_value_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  from,  to);
        }
    }
    private static efl_ui_slider_interval_value_set_delegate efl_ui_slider_interval_value_set_static_delegate;
}
} } 
