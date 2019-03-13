#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Canvas { namespace Vg { 
/// <summary>Efl vector graphics gradient radial class</summary>
[GradientRadialNativeInherit]
public class GradientRadial : Efl.Canvas.Vg.Gradient, Efl.Eo.IWrapper,Efl.Gfx.GradientRadial
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Canvas.Vg.GradientRadialNativeInherit nativeInherit = new Efl.Canvas.Vg.GradientRadialNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (GradientRadial))
            return Efl.Canvas.Vg.GradientRadialNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
      }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] internal static extern System.IntPtr
      efl_canvas_vg_gradient_radial_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   public GradientRadial(Efl.Object parent= null
         ) :
      base(efl_canvas_vg_gradient_radial_class_get(), typeof(GradientRadial), parent)
   {
      FinishInstantiation();
   }
   ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
   public GradientRadial(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
   protected GradientRadial(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static GradientRadial static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new GradientRadial(obj.NativeHandle);
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
   /// <summary>Gets the center of this radial gradient.</summary>
   /// <param name="x">X co-ordinate of center point</param>
   /// <param name="y">Y co-ordinate of center point</param>
   /// <returns></returns>
   virtual public  void GetCenter( out double x,  out double y) {
                                           Efl.Gfx.GradientRadialNativeInherit.efl_gfx_gradient_radial_center_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), out x,  out y);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Sets the center of this radial gradient.</summary>
   /// <param name="x">X co-ordinate of center point</param>
   /// <param name="y">Y co-ordinate of center point</param>
   /// <returns></returns>
   virtual public  void SetCenter( double x,  double y) {
                                           Efl.Gfx.GradientRadialNativeInherit.efl_gfx_gradient_radial_center_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), x,  y);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Gets the center radius of this radial gradient.</summary>
   /// <returns>Center radius</returns>
   virtual public double GetRadius() {
       var _ret_var = Efl.Gfx.GradientRadialNativeInherit.efl_gfx_gradient_radial_radius_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Sets the center radius of this radial gradient.</summary>
   /// <param name="r">Center radius</param>
   /// <returns></returns>
   virtual public  void SetRadius( double r) {
                         Efl.Gfx.GradientRadialNativeInherit.efl_gfx_gradient_radial_radius_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), r);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Gets the focal point of this radial gradient.</summary>
   /// <param name="x">X co-ordinate of focal point</param>
   /// <param name="y">Y co-ordinate of focal point</param>
   /// <returns></returns>
   virtual public  void GetFocal( out double x,  out double y) {
                                           Efl.Gfx.GradientRadialNativeInherit.efl_gfx_gradient_radial_focal_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), out x,  out y);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Sets the focal point of this radial gradient.</summary>
   /// <param name="x">X co-ordinate of focal point</param>
   /// <param name="y">Y co-ordinate of focal point</param>
   /// <returns></returns>
   virtual public  void SetFocal( double x,  double y) {
                                           Efl.Gfx.GradientRadialNativeInherit.efl_gfx_gradient_radial_focal_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), x,  y);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Gets the center radius of this radial gradient.</summary>
/// <value>Center radius</value>
   public double Radius {
      get { return GetRadius(); }
      set { SetRadius( value); }
   }
   private static new  IntPtr GetEflClassStatic()
   {
      return Efl.Canvas.Vg.GradientRadial.efl_canvas_vg_gradient_radial_class_get();
   }
}
public class GradientRadialNativeInherit : Efl.Canvas.Vg.GradientNativeInherit{
   public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Evas);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      if (efl_gfx_gradient_radial_center_get_static_delegate == null)
      efl_gfx_gradient_radial_center_get_static_delegate = new efl_gfx_gradient_radial_center_get_delegate(center_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_gradient_radial_center_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_gradient_radial_center_get_static_delegate)});
      if (efl_gfx_gradient_radial_center_set_static_delegate == null)
      efl_gfx_gradient_radial_center_set_static_delegate = new efl_gfx_gradient_radial_center_set_delegate(center_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_gradient_radial_center_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_gradient_radial_center_set_static_delegate)});
      if (efl_gfx_gradient_radial_radius_get_static_delegate == null)
      efl_gfx_gradient_radial_radius_get_static_delegate = new efl_gfx_gradient_radial_radius_get_delegate(radius_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_gradient_radial_radius_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_gradient_radial_radius_get_static_delegate)});
      if (efl_gfx_gradient_radial_radius_set_static_delegate == null)
      efl_gfx_gradient_radial_radius_set_static_delegate = new efl_gfx_gradient_radial_radius_set_delegate(radius_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_gradient_radial_radius_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_gradient_radial_radius_set_static_delegate)});
      if (efl_gfx_gradient_radial_focal_get_static_delegate == null)
      efl_gfx_gradient_radial_focal_get_static_delegate = new efl_gfx_gradient_radial_focal_get_delegate(focal_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_gradient_radial_focal_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_gradient_radial_focal_get_static_delegate)});
      if (efl_gfx_gradient_radial_focal_set_static_delegate == null)
      efl_gfx_gradient_radial_focal_set_static_delegate = new efl_gfx_gradient_radial_focal_set_delegate(focal_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_gradient_radial_focal_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_gradient_radial_focal_set_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Canvas.Vg.GradientRadial.efl_canvas_vg_gradient_radial_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Canvas.Vg.GradientRadial.efl_canvas_vg_gradient_radial_class_get();
   }


    private delegate  void efl_gfx_gradient_radial_center_get_delegate(System.IntPtr obj, System.IntPtr pd,   out double x,   out double y);


    public delegate  void efl_gfx_gradient_radial_center_get_api_delegate(System.IntPtr obj,   out double x,   out double y);
    public static Efl.Eo.FunctionWrapper<efl_gfx_gradient_radial_center_get_api_delegate> efl_gfx_gradient_radial_center_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_gradient_radial_center_get_api_delegate>(_Module, "efl_gfx_gradient_radial_center_get");
    private static  void center_get(System.IntPtr obj, System.IntPtr pd,  out double x,  out double y)
   {
      Eina.Log.Debug("function efl_gfx_gradient_radial_center_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           x = default(double);      y = default(double);                     
         try {
            ((GradientRadial)wrapper).GetCenter( out x,  out y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_gfx_gradient_radial_center_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out x,  out y);
      }
   }
   private static efl_gfx_gradient_radial_center_get_delegate efl_gfx_gradient_radial_center_get_static_delegate;


    private delegate  void efl_gfx_gradient_radial_center_set_delegate(System.IntPtr obj, System.IntPtr pd,   double x,   double y);


    public delegate  void efl_gfx_gradient_radial_center_set_api_delegate(System.IntPtr obj,   double x,   double y);
    public static Efl.Eo.FunctionWrapper<efl_gfx_gradient_radial_center_set_api_delegate> efl_gfx_gradient_radial_center_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_gradient_radial_center_set_api_delegate>(_Module, "efl_gfx_gradient_radial_center_set");
    private static  void center_set(System.IntPtr obj, System.IntPtr pd,  double x,  double y)
   {
      Eina.Log.Debug("function efl_gfx_gradient_radial_center_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((GradientRadial)wrapper).SetCenter( x,  y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_gfx_gradient_radial_center_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  x,  y);
      }
   }
   private static efl_gfx_gradient_radial_center_set_delegate efl_gfx_gradient_radial_center_set_static_delegate;


    private delegate double efl_gfx_gradient_radial_radius_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate double efl_gfx_gradient_radial_radius_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_gfx_gradient_radial_radius_get_api_delegate> efl_gfx_gradient_radial_radius_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_gradient_radial_radius_get_api_delegate>(_Module, "efl_gfx_gradient_radial_radius_get");
    private static double radius_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_gradient_radial_radius_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  double _ret_var = default(double);
         try {
            _ret_var = ((GradientRadial)wrapper).GetRadius();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_gradient_radial_radius_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_gfx_gradient_radial_radius_get_delegate efl_gfx_gradient_radial_radius_get_static_delegate;


    private delegate  void efl_gfx_gradient_radial_radius_set_delegate(System.IntPtr obj, System.IntPtr pd,   double r);


    public delegate  void efl_gfx_gradient_radial_radius_set_api_delegate(System.IntPtr obj,   double r);
    public static Efl.Eo.FunctionWrapper<efl_gfx_gradient_radial_radius_set_api_delegate> efl_gfx_gradient_radial_radius_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_gradient_radial_radius_set_api_delegate>(_Module, "efl_gfx_gradient_radial_radius_set");
    private static  void radius_set(System.IntPtr obj, System.IntPtr pd,  double r)
   {
      Eina.Log.Debug("function efl_gfx_gradient_radial_radius_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((GradientRadial)wrapper).SetRadius( r);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_gradient_radial_radius_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  r);
      }
   }
   private static efl_gfx_gradient_radial_radius_set_delegate efl_gfx_gradient_radial_radius_set_static_delegate;


    private delegate  void efl_gfx_gradient_radial_focal_get_delegate(System.IntPtr obj, System.IntPtr pd,   out double x,   out double y);


    public delegate  void efl_gfx_gradient_radial_focal_get_api_delegate(System.IntPtr obj,   out double x,   out double y);
    public static Efl.Eo.FunctionWrapper<efl_gfx_gradient_radial_focal_get_api_delegate> efl_gfx_gradient_radial_focal_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_gradient_radial_focal_get_api_delegate>(_Module, "efl_gfx_gradient_radial_focal_get");
    private static  void focal_get(System.IntPtr obj, System.IntPtr pd,  out double x,  out double y)
   {
      Eina.Log.Debug("function efl_gfx_gradient_radial_focal_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           x = default(double);      y = default(double);                     
         try {
            ((GradientRadial)wrapper).GetFocal( out x,  out y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_gfx_gradient_radial_focal_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out x,  out y);
      }
   }
   private static efl_gfx_gradient_radial_focal_get_delegate efl_gfx_gradient_radial_focal_get_static_delegate;


    private delegate  void efl_gfx_gradient_radial_focal_set_delegate(System.IntPtr obj, System.IntPtr pd,   double x,   double y);


    public delegate  void efl_gfx_gradient_radial_focal_set_api_delegate(System.IntPtr obj,   double x,   double y);
    public static Efl.Eo.FunctionWrapper<efl_gfx_gradient_radial_focal_set_api_delegate> efl_gfx_gradient_radial_focal_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_gradient_radial_focal_set_api_delegate>(_Module, "efl_gfx_gradient_radial_focal_set");
    private static  void focal_set(System.IntPtr obj, System.IntPtr pd,  double x,  double y)
   {
      Eina.Log.Debug("function efl_gfx_gradient_radial_focal_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((GradientRadial)wrapper).SetFocal( x,  y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_gfx_gradient_radial_focal_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  x,  y);
      }
   }
   private static efl_gfx_gradient_radial_focal_set_delegate efl_gfx_gradient_radial_focal_set_static_delegate;
}
} } } 
