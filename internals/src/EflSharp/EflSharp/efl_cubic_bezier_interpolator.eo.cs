#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { 
/// <summary>Efl cubic_bezier interpolator class</summary>
[CubicBezierInterpolatorNativeInherit]
public class CubicBezierInterpolator : Efl.Object, Efl.Eo.IWrapper,Efl.Interpolator
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.CubicBezierInterpolatorNativeInherit nativeInherit = new Efl.CubicBezierInterpolatorNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (CubicBezierInterpolator))
            return Efl.CubicBezierInterpolatorNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   ///<summary>Delegate for function to be called from inside the native constructor.</summary>
   public new delegate void ConstructingMethod(CubicBezierInterpolator obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)] internal static extern System.IntPtr
      efl_cubic_bezier_interpolator_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="init_cb">Delegate to call constructing methods that should be run inside the constructor.</param>
   public CubicBezierInterpolator(Efl.Object parent = null, ConstructingMethod init_cb=null) : base("CubicBezierInterpolator", efl_cubic_bezier_interpolator_class_get(), typeof(CubicBezierInterpolator), parent)
   {
      if (init_cb != null) {
         init_cb(this);
      }
      FinishInstantiation();
   }
   ///<summary>Internal constructor to forward the wrapper initialization to the root class.</summary>
   protected CubicBezierInterpolator(String klass_name, IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(klass_name, base_klass, managed_type, parent) {}
   ///<summary>Constructs an instance from a native pointer.</summary>
   public CubicBezierInterpolator(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static CubicBezierInterpolator static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new CubicBezierInterpolator(obj.NativeHandle);
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
    protected static extern  void efl_cubic_bezier_interpolator_factors_get(System.IntPtr obj,   out double factor1,   out double factor2,   out double factor3,   out double factor4);
   /// <summary>Factors property</summary>
   /// <param name="factor1">First factor of the interpolation function.</param>
   /// <param name="factor2">Second factor of the interpolation function.</param>
   /// <param name="factor3">Third factor of the interpolation function.</param>
   /// <param name="factor4">Fourth factor of the interpolation function.</param>
   /// <returns></returns>
   virtual public  void GetFactors( out double factor1,  out double factor2,  out double factor3,  out double factor4) {
                                                                               efl_cubic_bezier_interpolator_factors_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  out factor1,  out factor2,  out factor3,  out factor4);
      Eina.Error.RaiseIfUnhandledException();
                                                       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]
    protected static extern  void efl_cubic_bezier_interpolator_factors_set(System.IntPtr obj,   double factor1,   double factor2,   double factor3,   double factor4);
   /// <summary>Factors property</summary>
   /// <param name="factor1">First factor of the interpolation function.</param>
   /// <param name="factor2">Second factor of the interpolation function.</param>
   /// <param name="factor3">Third factor of the interpolation function.</param>
   /// <param name="factor4">Fourth factor of the interpolation function.</param>
   /// <returns></returns>
   virtual public  void SetFactors( double factor1,  double factor2,  double factor3,  double factor4) {
                                                                               efl_cubic_bezier_interpolator_factors_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  factor1,  factor2,  factor3,  factor4);
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
}
public class CubicBezierInterpolatorNativeInherit : Efl.ObjectNativeInherit{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_cubic_bezier_interpolator_factors_get_static_delegate = new efl_cubic_bezier_interpolator_factors_get_delegate(factors_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_cubic_bezier_interpolator_factors_get"), func = Marshal.GetFunctionPointerForDelegate(efl_cubic_bezier_interpolator_factors_get_static_delegate)});
      efl_cubic_bezier_interpolator_factors_set_static_delegate = new efl_cubic_bezier_interpolator_factors_set_delegate(factors_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_cubic_bezier_interpolator_factors_set"), func = Marshal.GetFunctionPointerForDelegate(efl_cubic_bezier_interpolator_factors_set_static_delegate)});
      efl_interpolator_interpolate_static_delegate = new efl_interpolator_interpolate_delegate(interpolate);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_interpolator_interpolate"), func = Marshal.GetFunctionPointerForDelegate(efl_interpolator_interpolate_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.CubicBezierInterpolator.efl_cubic_bezier_interpolator_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.CubicBezierInterpolator.efl_cubic_bezier_interpolator_class_get();
   }


    private delegate  void efl_cubic_bezier_interpolator_factors_get_delegate(System.IntPtr obj, System.IntPtr pd,   out double factor1,   out double factor2,   out double factor3,   out double factor4);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]  private static extern  void efl_cubic_bezier_interpolator_factors_get(System.IntPtr obj,   out double factor1,   out double factor2,   out double factor3,   out double factor4);
    private static  void factors_get(System.IntPtr obj, System.IntPtr pd,  out double factor1,  out double factor2,  out double factor3,  out double factor4)
   {
      Eina.Log.Debug("function efl_cubic_bezier_interpolator_factors_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                       factor1 = default(double);      factor2 = default(double);      factor3 = default(double);      factor4 = default(double);                                 
         try {
            ((CubicBezierInterpolator)wrapper).GetFactors( out factor1,  out factor2,  out factor3,  out factor4);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_cubic_bezier_interpolator_factors_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out factor1,  out factor2,  out factor3,  out factor4);
      }
   }
   private efl_cubic_bezier_interpolator_factors_get_delegate efl_cubic_bezier_interpolator_factors_get_static_delegate;


    private delegate  void efl_cubic_bezier_interpolator_factors_set_delegate(System.IntPtr obj, System.IntPtr pd,   double factor1,   double factor2,   double factor3,   double factor4);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]  private static extern  void efl_cubic_bezier_interpolator_factors_set(System.IntPtr obj,   double factor1,   double factor2,   double factor3,   double factor4);
    private static  void factors_set(System.IntPtr obj, System.IntPtr pd,  double factor1,  double factor2,  double factor3,  double factor4)
   {
      Eina.Log.Debug("function efl_cubic_bezier_interpolator_factors_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                          
         try {
            ((CubicBezierInterpolator)wrapper).SetFactors( factor1,  factor2,  factor3,  factor4);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_cubic_bezier_interpolator_factors_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  factor1,  factor2,  factor3,  factor4);
      }
   }
   private efl_cubic_bezier_interpolator_factors_set_delegate efl_cubic_bezier_interpolator_factors_set_static_delegate;


    private delegate double efl_interpolator_interpolate_delegate(System.IntPtr obj, System.IntPtr pd,   double progress);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern double efl_interpolator_interpolate(System.IntPtr obj,   double progress);
    private static double interpolate(System.IntPtr obj, System.IntPtr pd,  double progress)
   {
      Eina.Log.Debug("function efl_interpolator_interpolate was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    double _ret_var = default(double);
         try {
            _ret_var = ((CubicBezierInterpolator)wrapper).Interpolate( progress);
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
