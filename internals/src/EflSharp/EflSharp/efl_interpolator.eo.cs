#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { 
/// <summary>Efl interpolator interface</summary>
[InterpolatorConcreteNativeInherit]
public interface Interpolator : 
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>Interpolate the given value.</summary>
/// <param name="progress">Input value mapped from 0.0 to 1.0.</param>
/// <returns>Output value calculated by interpolating the input value.</returns>
double Interpolate( double progress);
   }
/// <summary>Efl interpolator interface</summary>
sealed public class InterpolatorConcrete : 

Interpolator
   
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (InterpolatorConcrete))
            return Efl.InterpolatorConcreteNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   private  System.IntPtr handle;
   public Dictionary<String, IntPtr> cached_strings = new Dictionary<String, IntPtr>();
   public Dictionary<String, IntPtr> cached_stringshares = new Dictionary<String, IntPtr>();
   ///<summary>Pointer to the native instance.</summary>
   public System.IntPtr NativeHandle {
      get { return handle; }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] internal static extern System.IntPtr
      efl_interpolator_interface_get();
   ///<summary>Constructs an instance from a native pointer.</summary>
   public InterpolatorConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~InterpolatorConcrete()
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
   Efl.Eo.Globals.free_dict_values(cached_strings);
   Efl.Eo.Globals.free_stringshare_values(cached_stringshares);
      Dispose(true);
      GC.SuppressFinalize(this);
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public static InterpolatorConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new InterpolatorConcrete(obj.NativeHandle);
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
    void register_event_proxies()
   {
   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern double efl_interpolator_interpolate(System.IntPtr obj,   double progress);
   /// <summary>Interpolate the given value.</summary>
   /// <param name="progress">Input value mapped from 0.0 to 1.0.</param>
   /// <returns>Output value calculated by interpolating the input value.</returns>
   public double Interpolate( double progress) {
                         var _ret_var = efl_interpolator_interpolate(Efl.InterpolatorConcrete.efl_interpolator_interface_get(),  progress);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
}
public class InterpolatorConcreteNativeInherit : Efl.Eo.NativeClass{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_interpolator_interpolate_static_delegate = new efl_interpolator_interpolate_delegate(interpolate);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_interpolator_interpolate"), func = Marshal.GetFunctionPointerForDelegate(efl_interpolator_interpolate_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.InterpolatorConcrete.efl_interpolator_interface_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.InterpolatorConcrete.efl_interpolator_interface_get();
   }


    private delegate double efl_interpolator_interpolate_delegate(System.IntPtr obj, System.IntPtr pd,   double progress);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern double efl_interpolator_interpolate(System.IntPtr obj,   double progress);
    private static double interpolate(System.IntPtr obj, System.IntPtr pd,  double progress)
   {
      Eina.Log.Debug("function efl_interpolator_interpolate was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    double _ret_var = default(double);
         try {
            _ret_var = ((Interpolator)wrapper).Interpolate( progress);
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
