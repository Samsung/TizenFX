#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { 
/// <summary>Efl sinusoidal interpolator class
/// output = (1 - cos(input * Pi)) / 2;</summary>
[SinusoidalInterpolatorNativeInherit]
public class SinusoidalInterpolator : Efl.Object, Efl.Eo.IWrapper,Efl.Interpolator
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.SinusoidalInterpolatorNativeInherit nativeInherit = new Efl.SinusoidalInterpolatorNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (SinusoidalInterpolator))
            return Efl.SinusoidalInterpolatorNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   ///<summary>Delegate for function to be called from inside the native constructor.</summary>
   public new delegate void ConstructingMethod(SinusoidalInterpolator obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)] internal static extern System.IntPtr
      efl_sinusoidal_interpolator_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="init_cb">Delegate to call constructing methods that should be run inside the constructor.</param>
   public SinusoidalInterpolator(Efl.Object parent = null, ConstructingMethod init_cb=null) : base("SinusoidalInterpolator", efl_sinusoidal_interpolator_class_get(), typeof(SinusoidalInterpolator), parent)
   {
      if (init_cb != null) {
         init_cb(this);
      }
      FinishInstantiation();
   }
   ///<summary>Internal constructor to forward the wrapper initialization to the root class.</summary>
   protected SinusoidalInterpolator(String klass_name, IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(klass_name, base_klass, managed_type, parent) {}
   ///<summary>Constructs an instance from a native pointer.</summary>
   public SinusoidalInterpolator(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static SinusoidalInterpolator static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new SinusoidalInterpolator(obj.NativeHandle);
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


   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]
    protected static extern double efl_sinusoidal_interpolator_factor_get(System.IntPtr obj);
   /// <summary>Factor property</summary>
   /// <returns>Factor of the interpolation function.</returns>
   virtual public double GetFactor() {
       var _ret_var = efl_sinusoidal_interpolator_factor_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]
    protected static extern  void efl_sinusoidal_interpolator_factor_set(System.IntPtr obj,   double factor);
   /// <summary>Factor property</summary>
   /// <param name="factor">Factor of the interpolation function.</param>
   /// <returns></returns>
   virtual public  void SetFactor( double factor) {
                         efl_sinusoidal_interpolator_factor_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  factor);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern double efl_interpolator_interpolate(System.IntPtr obj,   double progress);
   /// <summary>Interpolate the given value.</summary>
   /// <param name="progress">Input value mapped from 0.0 to 1.0.</param>
   /// <returns>Output value calculated by interpolating the input value.</returns>
   virtual public double Interpolate( double progress) {
                         var _ret_var = efl_interpolator_interpolate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  progress);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Factor property</summary>
   public double Factor {
      get { return GetFactor(); }
      set { SetFactor( value); }
   }
}
public class SinusoidalInterpolatorNativeInherit : Efl.ObjectNativeInherit{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_sinusoidal_interpolator_factor_get_static_delegate = new efl_sinusoidal_interpolator_factor_get_delegate(factor_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_sinusoidal_interpolator_factor_get"), func = Marshal.GetFunctionPointerForDelegate(efl_sinusoidal_interpolator_factor_get_static_delegate)});
      efl_sinusoidal_interpolator_factor_set_static_delegate = new efl_sinusoidal_interpolator_factor_set_delegate(factor_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_sinusoidal_interpolator_factor_set"), func = Marshal.GetFunctionPointerForDelegate(efl_sinusoidal_interpolator_factor_set_static_delegate)});
      efl_interpolator_interpolate_static_delegate = new efl_interpolator_interpolate_delegate(interpolate);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_interpolator_interpolate"), func = Marshal.GetFunctionPointerForDelegate(efl_interpolator_interpolate_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.SinusoidalInterpolator.efl_sinusoidal_interpolator_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.SinusoidalInterpolator.efl_sinusoidal_interpolator_class_get();
   }


    private delegate double efl_sinusoidal_interpolator_factor_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]  private static extern double efl_sinusoidal_interpolator_factor_get(System.IntPtr obj);
    private static double factor_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_sinusoidal_interpolator_factor_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  double _ret_var = default(double);
         try {
            _ret_var = ((SinusoidalInterpolator)wrapper).GetFactor();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_sinusoidal_interpolator_factor_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_sinusoidal_interpolator_factor_get_delegate efl_sinusoidal_interpolator_factor_get_static_delegate;


    private delegate  void efl_sinusoidal_interpolator_factor_set_delegate(System.IntPtr obj, System.IntPtr pd,   double factor);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]  private static extern  void efl_sinusoidal_interpolator_factor_set(System.IntPtr obj,   double factor);
    private static  void factor_set(System.IntPtr obj, System.IntPtr pd,  double factor)
   {
      Eina.Log.Debug("function efl_sinusoidal_interpolator_factor_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((SinusoidalInterpolator)wrapper).SetFactor( factor);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_sinusoidal_interpolator_factor_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  factor);
      }
   }
   private efl_sinusoidal_interpolator_factor_set_delegate efl_sinusoidal_interpolator_factor_set_static_delegate;


    private delegate double efl_interpolator_interpolate_delegate(System.IntPtr obj, System.IntPtr pd,   double progress);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern double efl_interpolator_interpolate(System.IntPtr obj,   double progress);
    private static double interpolate(System.IntPtr obj, System.IntPtr pd,  double progress)
   {
      Eina.Log.Debug("function efl_interpolator_interpolate was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    double _ret_var = default(double);
         try {
            _ret_var = ((SinusoidalInterpolator)wrapper).Interpolate( progress);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_interpolator_interpolate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  progress);
      }
   }
   private efl_interpolator_interpolate_delegate efl_interpolator_interpolate_static_delegate;
}
} 
